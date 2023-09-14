
Public Class FrmSubDiscount
    Private Sub FrmSubDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()

    End Sub
    Private Sub RefreshData()
        LoadDataGridView(dgvSub, "select ID,CODE,DESCRIPTION from sub_discount ")
        dgvSub.Columns(0).Visible = False

    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRecordsToolStripMenuItem.Click
        FrmSubDiscountDetails.IsNew = True
        FrmSubDiscountDetails.ShowDialog()
        FrmSubDiscountDetails = Nothing
        RefreshData()

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click
        If dgvSub.Rows.Count <> 0 Then
            FrmSubDiscountDetails.ID = dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(0).Value
            FrmSubDiscountDetails.IsNew = False
            FrmSubDiscountDetails.ShowDialog()
            FrmSubDiscountDetails = Nothing
            RefreshData()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvSub.Rows.Count <> 0 Then
            Dim id As Integer = dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(0).Value
            If MessageBoxQuestion("Are you sure delete " & dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(2).Value) = True Then
                SqlExecuted("delete from sub_discount_details where  sub_discount_id='" & id & "'")
                SqlExecuted("delete from sub_discount where id='" & id & "'")
                RefreshData()
            End If
        End If
    End Sub

    Private Sub DgvSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
End Class