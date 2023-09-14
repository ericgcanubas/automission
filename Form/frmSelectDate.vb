Public Class FrmSelectDate
    Public gsOK As Boolean
    Private Sub FrmSelectDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsOK = False
    End Sub
    Private Sub BtnYES_Click(sender As Object, e As EventArgs) Handles btnYES.Click
        gsOK = True
        Me.Close()
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub DtpSelect_ValueChanged(sender As Object, e As EventArgs) Handles dtpSelect.ValueChanged
        If dtpSelect.Value > Date.Now.Date Then
            dtpSelect.Value = Date.Now.Date
        End If
    End Sub
End Class