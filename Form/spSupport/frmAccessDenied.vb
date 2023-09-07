Imports System.Data.Odbc
Public Class frmAccessDenied

    Dim stop_image As Image = Image.FromFile(Application.StartupPath & "\image\toolbar\access_denied.png")
    Dim locker_image As Image = Image.FromFile(Application.StartupPath & "\image\toolbar\key_locker.png")

    Public gsCancel As Boolean = True
    Public gsMessage As String
    Private Sub frmMessage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gsCancel = True
        PictureBox1.Image = stop_image
        PictureBox2.Image = locker_image
        lblMessage.Text = gsMessage
        System.Media.SystemSounds.Hand.Play()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Trim(txtPASSWORD.Text).Length = 0 Then
            MessageBoxInfo("Please enter authorized password account")
            Exit Sub
        End If

        Try

            Dim rd As OdbcDataReader = SqlReader("Select * FROM `user` where PASSWORD = '" & Encrypt(txtPASSWORD.Text) & "' and AUTHORIZED_PASSWORD = '1' Limit 1 ")
            If rd.Read Then
                gsCancel = False
                Me.Close()
            Else
                txtPASSWORD.Clear()
                gsCancel = True
                MessageBoxExclamation("Invalid Authorized Password")
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub txtPASSWORD_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPASSWORD.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk_Click(sender, e)
        End If
    End Sub
End Class