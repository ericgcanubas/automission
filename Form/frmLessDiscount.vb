
Public Class FrmLessDiscount
    Private Sub frmLessDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridView(dgvLDP, "SELECT ID,DESCRIPTION,day_from as `FROM`, day_to as `TO`, less_percent as `PERCENT`,INACTIVE  FROM less_discount_penalty ")
        dgvLDP.Columns(0).Visible = False
        dgvLDP.Columns(1).Width = 300
        dgvLDP.Columns(2).Width = 50
        dgvLDP.Columns(3).Width = 50
        dgvLDP.Columns(4).Width = 60
        dgvLDP.Columns(5).Width = 60
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        With frmLessDiscountDetails
            .IsNew = True
            .ShowDialog()
            .Dispose()
            frmLessDiscountDetails = Nothing
            fRefresh()
        End With
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If dgvLDP.Rows.Count = 0 Then Exit Sub
        With frmLessDiscountDetails
            .ID = dgvLDP.Rows(dgvLDP.CurrentRow.Index).Cells(0).Value
            .IsNew = False
            .ShowDialog()
            .Dispose()
            frmLessDiscountDetails = Nothing
            fRefresh()
        End With
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click

    End Sub
End Class