Public Class FrmUserLogs


    Private Sub FrmUserLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_LoadDataGridView(dgvLogs, Me.AccessibleDescription)
    End Sub

    Private Sub FrmUserLogs_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GS_ViewNotSort(dgvLogs)
    End Sub
End Class