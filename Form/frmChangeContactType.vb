Public Class FrmChangeContactType
    Public gsID As Integer = 0
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmChangeContactType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GS_ComboBoxLoad(cmbTYPE, "Select * from contact_type_map where id in('1','5','6')", "ID", "DESCRIPTION")
        cmbTYPE.SelectedValue = gsID
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If cmbTYPE.SelectedValue = gsID Then
            MessageBoxInfo(cmbTYPE.Text & " type  already used!")
            Exit Sub
        End If
        gsID = cmbTYPE.SelectedValue
        Me.Close()
    End Sub
End Class