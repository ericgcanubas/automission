Public Class FrmReportManager
    Public gsSUB_ID As String
    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklNew.LinkClicked
        With frmReportManagerComponent
            .FormMain = Me
            .SUB_ID = gsSUB_ID
            .ID = 0
            .ShowDialog()
            .Dispose()
        End With
        frmReportManagerComponent = Nothing
        fRefreshComponent()
    End Sub
    Private Sub fEdit()
        If dgvReportComponent.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = dgvReportComponent.Rows(dgvReportComponent.CurrentRow.Index).Cells(0).Value
        With frmReportManagerComponent
            .SUB_ID = gsSUB_ID
            .ID = i
            .ShowDialog()
            .Dispose()
        End With
        frmReportManagerComponent = Nothing
        fRefreshComponent()
    End Sub
    Public Sub fRefreshComponent()
        LoadDataGridView(dgvReportComponent, "Select r.ID,r.LINE_NO as `POSITION NO.`,t.DESCRIPTION as `TYPE`,c.`NAME` from COMPONENT as c inner join  COMPONENT_TYPE as t on t.ID = c.TYPE inner join report_components as r on r.COMPONENT_ID = c.ID  WHERE r.SUB_ID = '" & gsSUB_ID & "' order by r.ID")
        dgvReportComponent.Columns(0).Visible = False
    End Sub

    Private Sub frmReportManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fRefreshComponent()
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        frmReportComponents.ShowDialog()
        frmReportComponents.Dispose()
        frmReportComponents = Nothing
    End Sub

    Private Sub lklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklEdit.LinkClicked
        fEdit()
    End Sub


    Private Sub dgvReportComponent_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReportComponent.CellDoubleClick
        fEdit()
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklDelete.LinkClicked
        If dgvReportComponent.Rows.Count = 0 Then Exit Sub
        Dim ID As Integer = dgvReportComponent.Rows(dgvReportComponent.CurrentRow.Index).Cells(0).Value
        SqlExecuted("Delete from report_components where ID = '" & ID & "'")
        fRefreshComponent()
    End Sub

    Private Sub frmReportManager_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        fRefreshComponent()
    End Sub
End Class