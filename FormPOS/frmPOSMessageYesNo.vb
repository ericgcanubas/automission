Public Class FrmPOSMessageYesNo
    Public gsClickYes As Boolean = False
    Public gsMessage As String
    Private Sub frmPOSMessageYesNo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsClickYes = False
        lblmsg.Text = gsMessage

    End Sub

    Private Sub btnYES_Click(sender As Object, e As EventArgs) Handles btnYES.Click
        gsClickYes = True
        Me.Close()
    End Sub

    Private Sub btnNO_Click(sender As Object, e As EventArgs) Handles btnNO.Click
        gsClickYes = False
        Me.Close()

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class