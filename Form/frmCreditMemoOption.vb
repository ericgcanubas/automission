Public Class FrmCreditMemoOption
    Public iSelect As Integer = 0
    Private Sub FrmCreditMemoOption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'fBackGroundImageStyle(Me)
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If opt1.Checked = True Then
            iSelect = 1
        End If

        If opt2.Checked = True Then
            iSelect = 2
        End If

        If opt3.Checked = True Then

            iSelect = 3

        End If

        If iSelect = 0 Then

        Else

            Me.Close()
        End If


    End Sub
End Class