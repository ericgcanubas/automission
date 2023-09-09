Public Class FrmFinanceCharge
    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub

    Private Sub FrmFinanceCharge_Load(sender As Object, e As EventArgs) Handles Me.Load
        Label1.Text = gsSubMenuForm

    End Sub
End Class