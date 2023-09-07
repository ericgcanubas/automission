Public Class frmServiceFee
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub

    Private Sub frmServiceFee_Load(sender As Object, e As EventArgs) Handles Me.Load

        DateTSComboBoxLoad(tsYEAR, 1, True)
        DateTSComboBoxLoad(tsMONTH, 2, True)

        ViewColumn(dgvServiceFee, 31)
    End Sub
    Private Sub fRefresh()
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


        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmServiceFeeDetails.ShowDialog()
        frmServiceFeeDetails.Dispose()
        frmServiceFeeDetails = Nothing
        fRefresh()
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click
        If dgvServiceFee.Rows.Count = 0 Then Exit Sub
        If fACCESS_NEW_EDIT(Me, False) = False Then
            Exit Sub
        End If

        Dim i As Integer = dgvServiceFee.CurrentRow.Index
        frmServiceFeeDetails.ID = dgvServiceFee.Rows(i).Cells("ID").Value
        frmServiceFeeDetails.ShowDialog()
        frmServiceFeeDetails.Dispose()
        frmServiceFeeDetails = Nothing
        fRefresh()
    End Sub

    Private Sub dgvServiceFee_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServiceFee.CellContentClick

    End Sub

    Private Sub dgvServiceFee_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvServiceFee.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvServiceFee.Rows.Count = 0 Then Exit Sub
        If fACCESS_DELETE(Me) = False Then
            Exit Sub
        End If
        Dim i As Integer = dgvServiceFee.CurrentRow.Index
        If MessageBoxQuestion("Are you sure to delete this service fee?") = True Then
            SqlExecuted("DELETE from service_fee WHERE ID ='" & dgvServiceFee.Rows(i).Cells("ID").Value & "'")
            fRefresh()
        End If

    End Sub

    Private Sub tsYEAR_Click(sender As Object, e As EventArgs) Handles tsYEAR.Click

    End Sub

    Private Sub tsYEAR_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsYEAR.SelectedIndexChanged
        fRefresh()
    End Sub

    Private Sub tsMONTH_Click(sender As Object, e As EventArgs) Handles tsMONTH.Click

    End Sub

    Private Sub tsMONTH_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsMONTH.SelectedIndexChanged
        fRefresh()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class