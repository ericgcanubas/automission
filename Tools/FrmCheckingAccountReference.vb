﻿Public Class FrmCheckingAccountReference
    Private Sub FrmCheckingAccountJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fComboBox(cmbOBJECT, "select * from object_type_map", "ID", "NAME")
        cmbOBJECT.SelectedValue = 53
        fComboBox(cmbACCOUNT_ID, "select * from Account ", "ID", "NAME")
        cmbACCOUNT_ID.SelectedValue = 37
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        dtpDATE1.Value = gsFirstDate
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        Dim SQL  As String = ""

        '        $"SELECT 
        'sr.`ID`,  
        'sr.`CODE` AS `Ref`,
        '  sr.`DATE`,
        '  sri.`QUANTITY`,
        '  sri.`RATE`,
        '  sri.`AMOUNT`,
        '  i.`CODE`,
        '  i.`DESCRIPTION` ,
        '  sr.`LOCATION_ID`
        'FROM
        '  sales_receipt_items AS sri 
        '  INNER JOIN sales_receipt AS sr 
        '    ON sr.`ID` = sri.`SALES_RECEIPT_ID` 
        '  INNER JOIN item AS i 
        '    ON i.`ID` = sri.`ITEM_ID` 
        'WHERE NOT EXISTS 
        '  (SELECT 
        '    * 
        '  FROM
        '    account_journal AS aj 
        '  WHERE aj.`ACCOUNT_ID` = '{cmbACCOUNT_ID.SelectedValue}' 
        '    AND aj.`LOCATION_ID` = sr.`LOCATION_ID` 
        '    AND aj.`OBJECT_TYPE` = '{cmbOBJECT.SelectedValue}' 
        '    AND aj.`OBJECT_DATE` = sr.`DATE` 
        '    AND aj.`OBJECT_ID` = sri.`ID`
        '    ) AND sr.`DATE` BETWEEN '{ fDateFormatMYSQL(dtpDATE1.Value)}' 
        '  AND '{fDateFormatMYSQL(dtpDATE2.Value)}' 
        '  AND sr.`LOCATION_ID` = '{cmbLOCATION_ID.SelectedValue}' 
        '  AND i.`TYPE` IN (0, 1, 2, 3, 4, 7)"


        SQL = $"select 
  aj.ID,
  aj.`OBJECT_DATE`,
  aj.JOURNAL_NO,
  aj.OBJECT_ID,
  (select 
    sales_receipt.code 
  from
    sales_receipt 
    inner join sales_receipt_items 
      on sales_receipt_items.`SALES_RECEIPT_ID` = sales_receipt.`ID` 
  where sales_receipt_items.`ID` = aj.`OBJECT_ID`) as `Reference`,
  (select 
    sales_receipt_items.`AMOUNT` 
  from
    sales_receipt 
    inner join sales_receipt_items 
      on sales_receipt_items.`SALES_RECEIPT_ID` = sales_receipt.`ID` 
  where sales_receipt_items.`ID` = aj.`OBJECT_ID`) as `AMOUNT_ITEMS`,
  aj.`AMOUNT` as `AMOUNT_JOURNAL` 
from
  account_journal as aj 
where aj.`ACCOUNT_ID` = '{cmbACCOUNT_ID.SelectedValue}' 
  and aj.`LOCATION_ID` = '{cmbLOCATION_ID.SelectedValue}' 
      AND aj.`OBJECT_TYPE` = '{cmbOBJECT.SelectedValue}' 
  and aj.`OBJECT_DATE` between '{fDateFormatMYSQL(dtpDATE1.Value)}' 
  and '{fDateFormatMYSQL(dtpDATE2.Value)}' "

        fDataGridView(dgvList, SQL)
        dgvList.Columns(0).Visible = False

    End Sub
    Private Sub fDOC_Selected()

        If dgvList.Rows.Count <> 0 Then



            Dim i As Integer = 7

            gsMenuSubID = i
            gsRefresh = True
            gsDocument_Finder_ID = dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value

            fmenuSet()

            gsDocument_Finder_ID = ""

            If gscryRpt IsNot Nothing Then
                gscryRpt.Close()
                gscryRpt.Dispose()
                gscryRpt = Nothing
            End If

            Dim fName As String = ""
            Dim frm As New Form
            frm = fGetForm(fName)
            Dim tp As TabPage = New TabPage(fName)


            Dim i_selected As Integer = 0

            For x As Integer = 0 To gsTabControl.Controls.Count - 1
                If gsTabControl.Controls.Item(x).Name = fName Then

                    i_selected = x
                    gsTabControl.Controls.RemoveAt(x)
                    If gsTabControl.Controls.Count = 0 Then
                        gsTabControl.Visible = False
                    End If
                    Exit For
                End If


            Next

            If gsTabControl.Controls.Count <> 0 Then
                i_selected = i_selected - 1

                If i_selected > 0 Then
                    gsTabControl.SelectTab(i_selected)

                End If

            End If

            Me.Close()


        End If




    End Sub
    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub

    Private Sub btnShowMe_Click(sender As Object, e As EventArgs) Handles btnShowMe.Click
        fDOC_Selected()
    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        fDOC_Selected()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvList.Rows.Count = 0 Then Exit Sub

        Dim ID As Integer = dgvList.CurrentRow.Cells(0).Value
        Dim PREVIOUS_ID As Integer = fNumFieldValue("ACCOUNT_JOURNAL", "ID", ID, "PREVIOUS_ID")
        Dim HOLDER_ID As Integer = fNumFieldValue("ACCOUNT_JOURNAL", "PREVIOUS_ID", ID, "ID")

        fExecutedOnly($"UPDATE account_journal SET PREVIOUS_ID ='{PREVIOUS_ID}' WHERE `ID` ='{HOLDER_ID}' limit 1;")
        fExecutedOnly($"UPDATE account_journal SET PREVIOUS_ID = NULL WHERE `ID` ='{ID}' limit 1;")
        fExecutedOnly($"DELETE FROM account_journal WHERE `ID` ='{ID}' limit 1;")
        btnRefresh.PerformClick()
        fMessageboxInfo("Successfuly.")

    End Sub
End Class