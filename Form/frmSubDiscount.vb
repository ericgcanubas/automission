Imports MySql.Data.MySqlClient
Public Class frmSubDiscount
    Private Sub frmSubDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)

        fRefresh()

    End Sub
    Private Sub fRefresh()
        fDataGridView(dgvSub, "select ID,CODE,DESCRIPTION from sub_discount ")
        dgvSub.Columns(0).Visible = False

    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRecordsToolStripMenuItem.Click
        frmSubDiscountDetails.gsNew = True
        frmSubDiscountDetails.ShowDialog()
        frmSubDiscountDetails = Nothing
        fRefresh()

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click
        If dgvSub.Rows.Count <> 0 Then
            frmSubDiscountDetails.gsID = dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(0).Value
            frmSubDiscountDetails.gsNew = False
            frmSubDiscountDetails.ShowDialog()
            frmSubDiscountDetails = Nothing
            fRefresh()
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvSub.Rows.Count <> 0 Then
            Dim id As Integer = dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(0).Value
            If fMessageBoxQuestion("Are you sure delete " & dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(2).Value) = True Then
                fExecutedOnly("delete from sub_discount_details where  sub_discount_id='" & id & "'")
                fExecutedOnly("delete from sub_discount where id='" & id & "'")
                fRefresh()
            End If
        End If
    End Sub

    Private Sub dgvSub_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellContentClick

    End Sub

    Private Sub dgvSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
End Class