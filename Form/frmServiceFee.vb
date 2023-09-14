Public Class FrmServiceFee
    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub

    Private Sub FrmServiceFee_Load(sender As Object, e As EventArgs) Handles Me.Load

        DateTSComboBoxLoad(tsYEAR, 1, True)
        DateTSComboBoxLoad(tsMONTH, 2, True)

        ViewColumn(dgvServiceFee, 31)
    End Sub
    Private Sub RefreshData()
        LoadDataGridView(dgvServiceFee, "SELECT ID,Description,Service_Fee_PCT as `Service Fee %`,Format(Sales_Target,2) as `Sales Target`,year_sf as `Year`, monthname(concat('2013/',month_sf,'/1')) as `Month`,Inactive FROM service_fee where YEAR_SF like '" & IIf(tsYEAR.ComboBox.SelectedValue = 0, "%", tsYEAR.ComboBox.SelectedValue) & "' and MONTH_SF like '" & IIf(tsMONTH.ComboBox.SelectedValue = 0, "%", tsMONTH.ComboBox.SelectedValue) & "' ")
        With dgvServiceFee.Columns
            .Item(0).Visible = False
            .Item(1).Width = 300
        End With
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvServiceFee, 31)

        ViewColumn(dgvServiceFee, 31)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRecordsToolStripMenuItem.Click

        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmServiceFeeDetails.ShowDialog()
        FrmServiceFeeDetails.Dispose()
        FrmServiceFeeDetails = Nothing
        RefreshData()
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click
        If dgvServiceFee.Rows.Count = 0 Then Exit Sub
        If SecurityAccessMode(Me, False) = False Then
            Exit Sub
        End If

        Dim i As Integer = dgvServiceFee.CurrentRow.Index
        FrmServiceFeeDetails.ID = dgvServiceFee.Rows(i).Cells("ID").Value
        FrmServiceFeeDetails.ShowDialog()
        FrmServiceFeeDetails.Dispose()
        FrmServiceFeeDetails = Nothing
        RefreshData()
    End Sub

    Private Sub DgvServiceFee_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServiceFee.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvServiceFee.Rows.Count = 0 Then Exit Sub
        If SecurityAccessDelete(Me) = False Then
            Exit Sub
        End If
        Dim i As Integer = dgvServiceFee.CurrentRow.Index
        If MessageBoxQuestion("Are you sure to delete this service fee?") = True Then
            SqlExecuted("DELETE from service_fee WHERE ID ='" & dgvServiceFee.Rows(i).Cells("ID").Value & "'")
            RefreshData()
        End If

    End Sub

    Private Sub TsYEAR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsYEAR.SelectedIndexChanged
        RefreshData()
    End Sub


    Private Sub TsMONTH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsMONTH.SelectedIndexChanged
        RefreshData()
    End Sub
End Class