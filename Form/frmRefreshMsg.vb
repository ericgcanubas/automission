Public Class FrmRefreshMsg
    Public gsSelect As Integer = 0
    Private Sub FrmRefreshMsg_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsSelect = 0
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsSelect = 0
        Me.Close()
    End Sub

    Private Sub BtnCreateNew_Click(sender As Object, e As EventArgs) Handles btnCreateNew.Click
        gsSelect = 1
        Me.Close()
    End Sub

    Private Sub BtnReload_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        gsSelect = 2
        Me.Close()
    End Sub
End Class