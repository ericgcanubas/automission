Imports System.Data.Odbc
Public Class FrmMessageUserControl
    Dim n As Integer = 10

    Public gsAllowed As Boolean = False
    Private Sub FrmMessageUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim rd As OdbcDataReader = SqlReader("select * from user_access_control where user_id = '" & gsUser_ID & "' limit 1")
        If rd.Read Then
            lblmsg.Text = "Someone trying to access your User Account (IP Address : " & rd("req_ip_address") & ") .  Are you to Log-out?"

        End If
        rd.Close()
    End Sub

    Private Sub BtnYes_Click(sender As Object, e As EventArgs) Handles btnYes.Click
        gsAllowed = True
        Me.Close()
    End Sub

    Private Sub BtnNo_Click(sender As Object, e As EventArgs) Handles btnNo.Click
        gsAllowed = False
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        n -= 1
        btnYes.Text = "Yes (" & n & ")"
        If n = 0 Then
            Timer1.Stop()
            btnYes_Click(sender, e)

        End If
    End Sub
End Class