Public Class FrmPOSTax
    Public gsTax_Id As Integer
    Public gsOk As Boolean
    Private Sub FrmPOSTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '  Me.BackColor = ColorTranslator.FromHtml(gsColor_Code)

    End Sub




    Private Sub BtnVatEx_Click(sender As Object, e As EventArgs) Handles btnVatEx.Click
        gsOk = True
        gsTax_Id = 13
        Me.Close()
    End Sub

    Private Sub BtnVatZero_Click(sender As Object, e As EventArgs) Handles btnVatZero.Click
        gsOk = True
        gsTax_Id = 14
        Me.Close()
    End Sub

    Private Sub BtnVatIn_Click(sender As Object, e As EventArgs) Handles btnVatIn.Click
        gsOk = True
        gsTax_Id = 12
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsOk = False
        Me.Close()
    End Sub
End Class