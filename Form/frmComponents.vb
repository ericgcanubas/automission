
Public Class frmComponents
    Dim f As Form = New frmFindItem
    Public ID As Integer
    Public gsQTY As Double
    Public gsRATE As Double
    Public gsITEM_ID As Double
    Public IsNew As Boolean
    Public gsDGV As DataGridView
    Private Sub frmComponents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '634, 209   default size
        If Me.HelpButton = True Then

            numQty.Visible = False
            numRate.Visible = False
            xQty.Visible = False
            xRate.Visible = False

            Me.Text = "Item Hours"
            ComboBoxLoad(cmbCode, gsItemCodeHoursList, "ID", "CODE")
            ComboBoxLoad(cmbDescription, gsItemDescriptionHoursList, "ID", "DESCRIPTION")

        ElseIf Me.CausesValidation = True Then
            Me.Text = "Item Components"
            ComboBoxLoad(cmbCode, gsItemCodeAssembly, "ID", "CODE")
            ComboBoxLoad(cmbDescription, gsItemDescriptionAssembly, "ID", "DESCRIPTION")
        Else
            Me.Text = "Item Group"
            ComboBoxLoad(cmbCode, gsItemCodeGROUP, "ID", "CODE")
            ComboBoxLoad(cmbDescription, gsItemDescriptionGROUP, "ID", "DESCRIPTION")
        End If


        ClearAndRefresh(Me)
        If IsNew = True Then
            numQty.Value = 1
            btnOK.Text = "&Add"
        Else
            cmbCode.SelectedValue = gsITEM_ID
            cmbDescription.SelectedValue = gsITEM_ID
            btnOK.Text = "&Update"
            numQty.Value = gsQTY
            numRate.Value = gsRATE
        End If

    End Sub

    Private Sub cmbCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCode.SelectedIndexChanged
        Try
            cmbDescription.SelectedValue = cmbCode.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbDescription_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDescription.SelectedIndexChanged
        Try
            cmbCode.SelectedValue = cmbDescription.SelectedValue
        Catch ex As Exception

        End Try

    End Sub
    Private Sub cmbCode_LostFocus(sender As Object, e As EventArgs) Handles cmbCode.LostFocus
        If NumIsNull(cmbCode.SelectedValue) <> 0 Then
            BlueLight(numQty)
            numQty.Focus()
        End If
    End Sub

    Private Sub cmbDescription_LostFocus(sender As Object, e As EventArgs) Handles cmbDescription.LostFocus
        If NumIsNull(cmbDescription.SelectedValue) <> 0 Then
            BlueLight(numQty)
            numQty.Focus()
        End If
    End Sub

    Private Sub numRate_ValueChanged(sender As Object, e As EventArgs) Handles numRate.ValueChanged

    End Sub

    Private Sub numRate_GotFocus(sender As Object, e As EventArgs) Handles numRate.GotFocus
        BlueLight(numRate)
    End Sub

    Private Sub numQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged

    End Sub

    Private Sub numQty_GotFocus(sender As Object, e As EventArgs) Handles numQty.GotFocus
        BlueLight(numQty)
    End Sub
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cmbCode.Text = "" Then
            MessageBoxExclamation("Invalid item code")
            Exit Sub
        ElseIf cmbDescription.Text = "" Then
            MessageBoxExclamation("Invalid description")
            Exit Sub
        ElseIf numQty.Value = 0 Then
            MessageBoxExclamation("Please enter quantity")
            Exit Sub
        End If

        If IsNew = True Then
            gsDGV.Rows.Add("", cmbCode.Text, cmbDescription.Text, numQty.Value, numRate.Value, "n", cmbCode.SelectedValue)
            gsDGV.CurrentCell = gsDGV.Rows(gsDGV.Rows.Count - 1).Cells(1) 'Last Row HighLight
        Else
            With gsDGV.Rows(gsDGV.CurrentRow.Index)
                .Cells("CODE").Value = cmbCode.Text
                .Cells("DESCRIPTION").Value = cmbDescription.Text
                .Cells("QTY").Value = numQty.Value
                .Cells("RATE").Value = numRate.Value
                .Cells("STATUS").Value = IIf(ID = 0, "n", "e")
                .Cells("ITEM_ID").Value = cmbCode.SelectedValue
            End With

        End If
        IsNew = True
        btnOK.Text = "Add"
        cmbCode.SelectedIndex = -1
        cmbDescription.SelectedIndex = -1
        numQty.Value = 1
        numRate.Value = 0
        cmbCode.Focus()
    End Sub
End Class