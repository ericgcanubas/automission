Public Class FrmPOSRestoNoteDT
    Public gsRemarks As String = ""
    Private Sub BtnOne_Click(sender As Object, e As EventArgs) Handles btnOne.Click
        gsRemarks = btnOne.Text
        Me.Close()
    End Sub

    Private Sub BtnTwo_Click(sender As Object, e As EventArgs) Handles btnTwo.Click
        gsRemarks = btnTwo.Text
        Me.Close()
    End Sub

    Private Sub FrmPOSRestoNoteDT_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsRemarks = ""
    End Sub
End Class