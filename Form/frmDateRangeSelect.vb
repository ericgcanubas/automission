Public Class FrmDateRangeSelect
    Public DateFrom As Date
    Public DateTo As Date
    Public gsOK As Boolean = False

    Private Sub frmDateRangeSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsOK = False
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        DateFrom = dtpDT1.Value
        DateTo = dtpDT2.Value
        gsOK = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsOK = False
        Me.Close()
    End Sub
End Class