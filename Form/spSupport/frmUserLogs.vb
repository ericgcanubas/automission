Public Class frmUserLogs


    Private Sub frmUserLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fDataGridView(dgvLogs, Me.AccessibleDescription)
    End Sub

    Private Sub frmUserLogs_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fDgvNotSort(dgvLogs)
    End Sub
End Class