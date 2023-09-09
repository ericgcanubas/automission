Public Class FrmSalesVatSales
    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        Dim SQL As String = $"SELECT 
  sri.`ID`,
  i.`CODE`,
  i.`DESCRIPTION`,
  sri.`QUANTITY`,
  sri.`RATE`,
  sri.`AMOUNT` ,
  sri.`TAXABLE_AMOUNT` as `Tax Amount`,
  (SELECT aj.Amount FROM account_journal AS aj WHERE aj.`LOCATION_ID` =  sr.LOCATION_ID AND aj.`ACCOUNT_ID` IN ('37','39') AND aj.`OBJECT_TYPE` ='53' AND object_id = sri.`ID` AND aj.`OBJECT_DATE` = sr.DATE LIMIT 1) AS `Journal Amount`,
    sr.`CODE` AS refer
FROM
  sales_receipt_items AS sri 
  INNER JOIN sales_receipt AS sr 
    ON sr.`ID` = sri.`SALES_RECEIPT_ID` 
  INNER JOIN item AS i 
    ON i.`ID` = sri.`ITEM_ID` 
WHERE 
   i.`TYPE` IN (0,7)
  AND sr.`LOCATION_ID` = '{cmbLocation_ID.SelectedValue}'
  AND  sr.`DATE` between '{ DateFormatMySql(dtpDateFrom.Value)}' and '{DateFormatMySql(dtpDateTo.Value)}'"

        LoadDataGridView(dgvDataList, SQL)

        For I As Integer = 0 To dgvDataList.Rows.Count - 1
            With dgvDataList.Rows(I)
                If NumIsNull(.Cells("Tax Amount").Value) = NumIsNull(.Cells("Journal Amount").Value) Then
                    .DefaultCellStyle.ForeColor = Color.Blue

                Else
                    .DefaultCellStyle.ForeColor = Color.Red
                End If

            End With
        Next

    End Sub

    Private Sub FrmSalesVatSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbLocation_ID, "Select * from location", "ID", "NAME")
        dtpDateFrom.Value = gsFirstDate
        cmbLocation_ID.SelectedValue = gsDefault_LOCATION_ID
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportingExcel(dgvDataList, "Sales_vs_VSales_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub
End Class