Public Class FrmReportManager
    Public gsSUB_ID As String
    Private Sub LklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklNew.LinkClicked
        With FrmReportManagerComponent
            .FormMain = Me
            .SUB_ID = gsSUB_ID
            .ID = 0
            .ShowDialog()
            .Dispose()
        End With
        FrmReportManagerComponent = Nothing
        RefreshComponent()
    End Sub
    Private Sub EditMode()
        If dgvReportComponent.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = dgvReportComponent.Rows(dgvReportComponent.CurrentRow.Index).Cells(0).Value
        With FrmReportManagerComponent
            .SUB_ID = gsSUB_ID
            .ID = i
            .ShowDialog()
            .Dispose()
        End With
        FrmReportManagerComponent = Nothing
        RefreshComponent()
    End Sub
    Public Sub RefreshComponent()
        LoadDataGridView(dgvReportComponent, "Select r.ID,r.LINE_NO as `POSITION NO.`,t.DESCRIPTION as `TYPE`,c.`NAME` from COMPONENT as c inner join  COMPONENT_TYPE as t on t.ID = c.TYPE inner join report_components as r on r.COMPONENT_ID = c.ID  WHERE r.SUB_ID = '" & gsSUB_ID & "' order by r.ID")
        dgvReportComponent.Columns(0).Visible = False
    End Sub

    Private Sub FrmReportManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RefreshComponent()
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
        FrmReportComponents.ShowDialog()
        FrmReportComponents.Dispose()
        FrmReportComponents = Nothing
    End Sub

    Private Sub LklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklEdit.LinkClicked
        EditMode()
    End Sub


    Private Sub DgvReportComponent_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReportComponent.CellDoubleClick
        EditMode()
    End Sub

    Private Sub LklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklDelete.LinkClicked
        If dgvReportComponent.Rows.Count = 0 Then Exit Sub
        Dim ID As Integer = dgvReportComponent.Rows(dgvReportComponent.CurrentRow.Index).Cells(0).Value
        SqlExecuted("Delete from report_components where ID = '" & ID & "'")
        RefreshComponent()
    End Sub

    Private Sub FrmReportManager_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        RefreshComponent()
    End Sub
End Class