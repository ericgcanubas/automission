Public Class frmEmailSetup
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Dim str_Query As String = ""
        str_Query = str_Query & "UPDATE system_settings SET `VALUE` ='" & txtGmailUsername.Text & "' WHERE `NAME` = 'GmailUsername';"
        str_Query = str_Query & "UPDATE system_settings SET `VALUE` ='" & Encrypt(txtGmailPassword.Text) & "' WHERE `NAME` = 'GmailPassword';"
        str_Query = str_Query & "UPDATE system_settings SET `VALUE` ='" & txtGmailAddressTo.Text & "' WHERE `NAME` = 'GmailAddressTo';"

        SqlExecuted(str_Query)
        MessageBoxInfo("Save = Please restart all running bms.")
    End Sub

    Private Sub frmEmailSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtGmailUsername.Text = gsGmailUsername
        txtGmailPassword.Text = gsGmailPassword
        txtGmailAddressTo.Text = gsGmailAddressTo

    End Sub
End Class