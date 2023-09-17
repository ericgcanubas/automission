Public Class FrmCheckingAccountReference
    Private Sub FrmCheckingAccountJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GS_ComboBoxLoad(cmbOBJECT, "select * from object_type_map", "ID", "NAME")
        cmbOBJECT.SelectedValue = 53
        GS_ComboBoxLoad(cmbACCOUNT_ID, "select * from Account ", "ID", "NAME")
        cmbACCOUNT_ID.SelectedValue = 37
        GS_ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        dtpDATE1.Value = gsFirstDate
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
    End Sub

    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click



        Dim SQL As String = $"select 
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
  and aj.`OBJECT_DATE` between '{GetDateFormatMySql(dtpDATE1.Value)}' 
  and '{GetDateFormatMySql(dtpDATE2.Value)}' "

        GS_LoadDataGridView(dgvList, SQL)
        dgvList.Columns(0).Visible = False

    End Sub
    Private Sub DocumentSelected()

        If dgvList.Rows.Count <> 0 Then



            Dim i As Integer = 7

            gsMenuSubID = i
            gsRefresh = True
            gsDocument_Finder_ID = dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value

            MenuSet()

            gsDocument_Finder_ID = 0

            If gscryRpt IsNot Nothing Then
                gscryRpt.Close()
                gscryRpt.Dispose()
                gscryRpt = Nothing
            End If

            Dim fName As String = ""
            Dim frm As New Form
            frm = GetFormModule(fName)
            Dim TPage As New TabPage(fName)
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
                i_selected &= i_selected - 1

                If i_selected > 0 Then
                    gsTabControl.SelectTab(i_selected)

                End If

            End If

            Me.Close()
        End If

    End Sub


    Private Sub ShowMe_Click(sender As Object, e As EventArgs) Handles btnShowMe.Click
        DocumentSelected()
    End Sub

    Private Sub DgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        DocumentSelected()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If dgvList.Rows.Count = 0 Then Exit Sub

        Dim ID As Integer = dgvList.CurrentRow.Cells(0).Value
        Dim PREVIOUS_ID As Integer = GF_GetNumberFieldValue("ACCOUNT_JOURNAL", "ID", ID, "PREVIOUS_ID")
        Dim HOLDER_ID As Integer = GF_GetNumberFieldValue("ACCOUNT_JOURNAL", "PREVIOUS_ID", ID, "ID")

        SqlExecuted($"UPDATE account_journal SET PREVIOUS_ID ='{PREVIOUS_ID}' WHERE `ID` ='{HOLDER_ID}' limit 1;")
        SqlExecuted($"UPDATE account_journal SET PREVIOUS_ID = NULL WHERE `ID` ='{ID}' limit 1;")
        SqlExecuted($"DELETE FROM account_journal WHERE `ID` ='{ID}' limit 1;")
        btnRefresh.PerformClick()
        MessageBoxInfo("Successfuly.")

    End Sub
End Class