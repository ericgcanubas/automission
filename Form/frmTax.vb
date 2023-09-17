Public Class FrmTax
    Dim item_BS As BindingSource
    Private Sub FrmPaymentTerms_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        GS_LoadDataGridViewBinding(dgvTax, "SELECT tx.`ID`,tx.`Name`,t.`DESCRIPTION` AS `Tax Type`, IF(IFNULL(tx.`Rate`,'') = '','', CONCAT(FORMAT(tx.`Rate`,0),'%')) AS `Rate`,l.`NAME` AS `Liability Account`,a.`NAME` AS `Asset Account`, tx.`Inactive` FROM tax AS tx  INNER JOIN tax_type_map AS t ON t.`ID` = tx.`TAX_TYPE` LEFT OUTER JOIN account AS l ON l.`ID` = tx.`TAX_ACCOUNT_ID`	 LEFT OUTER JOIN account AS a ON a.`ID` = tx.`ASSET_ACCOUNT_ID`", item_BS)
        ViewColumn(dgvTax, 34)
        GS_Tax_Rate_Load()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvTax, 34)
        ViewColumn(dgvTax, 34)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If


        FrmTaxDetails.This_BS = item_BS
        FrmTaxDetails.Dgv = dgvTax
        FrmTaxDetails.ShowDialog()
        FrmTaxDetails.Dispose()
        FrmTaxDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvTax.Rows.Count = 0 Then Exit Sub

        If SecurityAccessMode(Me, False) = False Then
            Exit Sub
        End If

        Dim i As Integer = dgvTax.CurrentRow.Index


        FrmTaxDetails.This_BS = item_BS
        FrmTaxDetails.Dgv = dgvTax
        FrmTaxDetails.ID = dgvTax.Rows(i).Cells("ID").Value
        FrmTaxDetails.ShowDialog()
        FrmTaxDetails.Dispose()
        FrmTaxDetails = Nothing

    End Sub
    Private Sub DgvPaymentTerms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTax.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvTax.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = dgvTax.CurrentRow.Index

        If SecurityAccessDelete(Me) = False Then
            Exit Sub
        End If

        If MessageBoxQuestion("Are you sure to delete this Tax?") = True Then
            SqlExecuted("DELETE FROM tax WHERE ID = '" & dgvTax.Rows(i).Cells("ID").Value & "' Limit 1")
            DeleteNotify(Me)
            RefreshData()
        End If

    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvTax.Columns.Count - 1

                If dgvTax.Columns(I).Visible = True Then

                    If dgvTax.Columns(I).HeaderText.ToUpper <> "INACTIVE" Then
                        Exit For
                    End If

                    If strFInd = "" Then
                        strFInd = $"[{dgvTax.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                    Else
                        strFInd = strFInd & $" OR [{dgvTax.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                    End If

                End If


            Next




            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub DgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvTax.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class