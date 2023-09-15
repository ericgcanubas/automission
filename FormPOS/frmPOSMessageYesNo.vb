Public Class FrmPOSMessageYesNo
    Public gsClickYes As Boolean = False
    Public gsMessage As String
    Private Sub FrmPOSMessageYesNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsClickYes = False
        lblmsg.Text = gsMessage
    End Sub

    Private Sub BtnYES_Click(sender As Object, e As EventArgs) Handles btnYES.Click
        gsClickYes = True
        Me.Close()
    End Sub

    Private Sub BtnNO_Click(sender As Object, e As EventArgs) Handles btnNO.Click
        gsClickYes = False
        Me.Close()
    End Sub

End Class