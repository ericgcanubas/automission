Public Class frmTax
    Dim item_BS As BindingSource
    Private Sub frmPaymentTerms_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvTax, "SELECT tx.`ID`,tx.`Name`,t.`DESCRIPTION` AS `Tax Type`, IF(IFNULL(tx.`Rate`,'') = '','', CONCAT(FORMAT(tx.`Rate`,0),'%')) AS `Rate`,l.`NAME` AS `Liability Account`,a.`NAME` AS `Asset Account`, tx.`Inactive` FROM tax AS tx  INNER JOIN tax_type_map AS t ON t.`ID` = tx.`TAX_TYPE` LEFT OUTER JOIN account AS l ON l.`ID` = tx.`TAX_ACCOUNT_ID`	 LEFT OUTER JOIN account AS a ON a.`ID` = tx.`ASSET_ACCOUNT_ID`", item_BS)
        ViewColumn(dgvTax, 34)
        fTax_Rate_Load()
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvTax, 34)
        ViewColumn(dgvTax, 34)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If


        frmTaxDetails.This_BS = item_BS
        frmTaxDetails.Dgv = dgvTax
        frmTaxDetails.ShowDialog()
        frmTaxDetails.Dispose()
        frmTaxDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvTax.Rows.Count = 0 Then Exit Sub

        If fACCESS_NEW_EDIT(Me, False) = False Then
            Exit Sub
        End If

        Dim i As Integer = dgvTax.CurrentRow.Index


        frmTaxDetails.This_BS = item_BS
        frmTaxDetails.Dgv = dgvTax
        frmTaxDetails.ID = dgvTax.Rows(i).Cells("ID").Value
        frmTaxDetails.ShowDialog()
        frmTaxDetails.Dispose()
        frmTaxDetails = Nothing

    End Sub

    Private Sub dgvPaymentTerms_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTax.CellContentClick

    End Sub

    Private Sub dgvPaymentTerms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTax.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvTax.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = dgvTax.CurrentRow.Index

        If fACCESS_DELETE(Me) = False Then
            Exit Sub
        End If

        If MessageBoxQuestion("Are you sure to delete this Tax?") = True Then
            SqlExecuted("DELETE FROM tax WHERE ID = '" & dgvTax.Rows(i).Cells("ID").Value & "' Limit 1")
            DeleteNotify(Me)
            fRefresh()
        End If

    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub fSearchload()
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
    'Private Sub fSearchGet()
    '    For I As Integer = 0 To dgvTax.Columns.Count - 1
    '        tscmbSearch.ComboBox.Items.Add(dgvTax.Columns(I).HeaderText)
    '    Next
    '    tscmbSearch.ComboBox.SelectedIndex = 1
    'End Sub
    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub

    Private Sub dgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvTax.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub frmTax_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub tsTxtSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class