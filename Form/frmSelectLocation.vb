Public Class frmSelectLocation
    Public gsOK As Boolean
    Private Sub frmSelectLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbLOCATION_ID, "SELECT ID,NAME FROM LOCATION WHERE INACTIVE ='0'", "ID", "NAME")
        gsOK = False
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        gsOK = True
        Me.Close()
    End Sub
End Class