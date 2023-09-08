Public Class FrmReferenceSettings
    Private Sub frmReferenceSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(xmbMenu, "select * from object_type_map where IS_DOCUMENT = '1' ", "ID", "NAME")
        ClearAndRefresh(Me)

    End Sub
    Private Sub fRefresh()
        SqlExecutedUsingReading(Me, "select * from object_type_map where ID = '" & NumIsNull(xmbMenu.SelectedValue) & "' limit 1")
    End Sub
    Private Sub xmbMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles xmbMenu.SelectedIndexChanged
        fRefresh()
    End Sub

    Private Sub frmReferenceSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fRefresh()
    End Sub
    Private Sub fOutPut()
        Dim d As String = ""
        For i As Integer = 1 To numDIGIT_CODE.Value
            d = d & "0"
        Next

        TheResult.Text = txtSYMBOL_CODE.Text & IIf(chkUSE_YEAR.Checked = True, Date.Now.Year, "") & numNEXT_CODE.Value.ToString(d)

    End Sub

    Private Sub chkUSE_YEAR_CheckedChanged(sender As Object, e As EventArgs) Handles chkUSE_YEAR.CheckedChanged
        fOutPut()
    End Sub

    Private Sub txtSYMBOL_CODE_TextChanged(sender As Object, e As EventArgs) Handles txtSYMBOL_CODE.TextChanged
        fOutPut()
    End Sub

    Private Sub numDIGIT_CODE_ValueChanged(sender As Object, e As EventArgs) Handles numDIGIT_CODE.ValueChanged
        fOutPut()
    End Sub

    Private Sub numNEXT_CODE_ValueChanged(sender As Object, e As EventArgs) Handles numNEXT_CODE.ValueChanged
        fOutPut()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        SqlExecuted("Update object_type_map set " & SqlUpdate(Me) & " Where ID ='" & xmbMenu.SelectedValue & "'")
        MessageBoxInfo("Save")
    End Sub
End Class