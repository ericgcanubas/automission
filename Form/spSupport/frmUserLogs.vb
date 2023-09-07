Public Class frmUserLogs


    Private Sub frmUserLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataGridView(dgvLogs, Me.AccessibleDescription)
    End Sub

    Private Sub frmUserLogs_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvLogs)
    End Sub
End Class