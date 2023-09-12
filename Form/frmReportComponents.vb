Public Class FrmReportComponents
    Private Sub LklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklNew.LinkClicked
        With FrmReportComponentItems
            .ID = 0
            .ShowDialog()
            .Dispose()
        End With
        FrmReportComponentItems = Nothing
        LoadComponents()
    End Sub
    Private Sub LoadComponents()
        LoadDataGridView(dgvReportComponent, "select c.ID,t.DESCRIPTION as `Type`,c.`NAME` from COMPONENT as c inner join COMPONENT_TYPE as t on t.ID = c.`TYPE` order by c.ID ")
    End Sub

    Private Sub FrmReportComponents_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        LoadComponents()
    End Sub
    Private Sub LklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklEdit.LinkClicked
        EditCompo()
    End Sub
    Private Sub EditCompo()
        If dgvReportComponent.Rows.Count = 0 Then Exit Sub
        Dim I As Integer = dgvReportComponent.Rows(dgvReportComponent.CurrentRow.Index).Cells(0).Value
        With FrmReportComponentItems
            .ID = I
            .ShowDialog()
            .Dispose()
        End With
        FrmReportComponentItems = Nothing
        LoadComponents()
    End Sub

    Private Sub DgvReportComponent_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReportComponent.CellDoubleClick
        EditCompo()
    End Sub
End Class