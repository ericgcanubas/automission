Public Class FrmReferenceSettings
    Private Sub FrmReferenceSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(xmbMenu, "select * from object_type_map where IS_DOCUMENT = '1' ", "ID", "NAME")
        ClearAndRefresh(Me)

    End Sub
    Private Sub RefreshData()
        SqlExecutedUsingReading(Me, "select * from object_type_map where ID = '" & GF_NumIsNull(xmbMenu.SelectedValue) & "' limit 1")
    End Sub
    Private Sub XmbMenu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles xmbMenu.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub FrmReferenceSettings_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshData()
    End Sub
    Private Sub OutputChange()
        Dim d As String = ""
        For i As Integer = 1 To numDIGIT_CODE.Value
            d &= "0"
        Next

        TheResult.Text = txtSYMBOL_CODE.Text & IIf(chkUSE_YEAR.Checked = True, Date.Now.Year, "") & numNEXT_CODE.Value.ToString(d)

    End Sub

    Private Sub ChkUSE_YEAR_CheckedChanged(sender As Object, e As EventArgs) Handles chkUSE_YEAR.CheckedChanged
        OutputChange()
    End Sub

    Private Sub TxtSYMBOL_CODE_TextChanged(sender As Object, e As EventArgs) Handles txtSYMBOL_CODE.TextChanged
        OutputChange()
    End Sub

    Private Sub NumDIGIT_CODE_ValueChanged(sender As Object, e As EventArgs) Handles numDIGIT_CODE.ValueChanged
        OutputChange()
    End Sub

    Private Sub NumNEXT_CODE_ValueChanged(sender As Object, e As EventArgs) Handles numNEXT_CODE.ValueChanged
        OutputChange()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SqlExecuted("Update object_type_map set " & SqlUpdate(Me) & " Where ID ='" & xmbMenu.SelectedValue & "'")
        MessageBoxInfo("Save")
    End Sub
End Class