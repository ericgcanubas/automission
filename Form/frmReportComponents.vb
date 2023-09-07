Public Class frmReportComponents
    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklNew.LinkClicked
        With frmReportComponentItems
            .ID = 0
            .ShowDialog()
            .Dispose()
        End With
        frmReportComponentItems = Nothing
        fLoadComponent()
    End Sub
    Private Sub fLoadComponent()
        LoadDataGridView(dgvReportComponent, "select c.ID,t.DESCRIPTION as `Type`,c.`NAME` from COMPONENT as c inner join COMPONENT_TYPE as t on t.ID = c.`TYPE` order by c.ID ")
    End Sub

    Private Sub frmReportComponents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fLoadComponent()
    End Sub
    Private Sub lklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklEdit.LinkClicked
        fEDIT()
    End Sub
    Private Sub fEDIT()
        If dgvReportComponent.Rows.Count = 0 Then Exit Sub
        Dim I As Integer = dgvReportComponent.Rows(dgvReportComponent.CurrentRow.Index).Cells(0).Value
        With frmReportComponentItems
            .ID = I
            .ShowDialog()
            .Dispose()
        End With
        frmReportComponentItems = Nothing
        fLoadComponent()
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklDelete.LinkClicked

    End Sub



    Private Sub dgvReportComponent_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReportComponent.CellDoubleClick
        fEDIT()
    End Sub
End Class