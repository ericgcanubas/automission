Public Class FrmSelectLocation
    Public gsOK As Boolean
    Private Sub FrmSelectLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbLOCATION_ID, "SELECT ID,NAME FROM LOCATION WHERE INACTIVE ='0'", "ID", "NAME")
        gsOK = False
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        gsOK = True
        Me.Close()
    End Sub
End Class