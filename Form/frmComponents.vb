
Public Class frmComponents
    Dim f As Form = New frmFindItem
    Public gsID As String
    Public gsQTY As Double
    Public gsRATE As Double
    Public gsITEM_ID As Double
    Public gsNew As Boolean
    Public gsDGV As DataGridView
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub frmComponents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '634, 209   default size

        fMaterialSkin(Me)

        If Me.HelpButton = True Then

            numQty.Visible = False
            numRate.Visible = False
            xQty.Visible = False
            xRate.Visible = False

            Me.Text = "Item Hours"
            fComboBox(cmbCode, gsItemCodeHoursList, "ID", "CODE")
            fComboBox(cmbDescription, gsItemDescriptionHoursList, "ID", "DESCRIPTION")

        ElseIf Me.CausesValidation = True Then
            Me.Text = "Item Components"
            fComboBox(cmbCode, gsItemCodeAssembly, "ID", "CODE")
            fComboBox(cmbDescription, gsItemDescriptionAssembly, "ID", "DESCRIPTION")
        Else
            Me.Text = "Item Group"
            fComboBox(cmbCode, gsItemCodeGROUP, "ID", "CODE")
            fComboBox(cmbDescription, gsItemDescriptionGROUP, "ID", "DESCRIPTION")
        End If


        fCLean_and_refresh(Me)
        If gsNew = True Then
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

    Private Sub SearchItemToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Try
        '    f.AccessibleName = "A"
        '    f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        '    f.ShowDialog()
        '    If f.AccessibleDescription <> "" Then
        '        If f.AccessibleDescription <> "cancel" Then
        '            cmbCode.SelectedValue = f.AccessibleDescription

        '            fBlueLight(numQty)
        '            numQty.Focus()

        '        End If
        '    End If

        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub cmbCode_LostFocus(sender As Object, e As EventArgs) Handles cmbCode.LostFocus
        If fNumisNULL(cmbCode.SelectedValue) <> 0 Then
            fBlueLight(numQty)
            numQty.Focus()
        End If
    End Sub

    Private Sub cmbDescription_LostFocus(sender As Object, e As EventArgs) Handles cmbDescription.LostFocus
        If fNumisNULL(cmbDescription.SelectedValue) <> 0 Then
            fBlueLight(numQty)
            numQty.Focus()
        End If
    End Sub

    Private Sub numRate_ValueChanged(sender As Object, e As EventArgs) Handles numRate.ValueChanged

    End Sub

    Private Sub numRate_GotFocus(sender As Object, e As EventArgs) Handles numRate.GotFocus
        fBlueLight(numRate)
    End Sub

    Private Sub numQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged

    End Sub

    Private Sub numQty_GotFocus(sender As Object, e As EventArgs) Handles numQty.GotFocus
        fBlueLight(numQty)
    End Sub

    Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If cmbCode.Text = "" Then
            fMessageboxExclamation("Invalid item code")
            Exit Sub
        ElseIf cmbDescription.Text = "" Then
            fMessageboxExclamation("Invalid description")
            Exit Sub
        ElseIf numQty.Value = 0 Then
            fMessageboxExclamation("Please enter quantity")
            Exit Sub
        End If

        'gsID = cmbCode.SelectedValue
        'gsQty = numQty.Value
        'gsRate = numRate.Value

        'bSave = True
        'Me.Close()

        If gsNew = True Then
            gsDGV.Rows.Add("", cmbCode.Text, cmbDescription.Text, numQty.Value, numRate.Value, "n", cmbCode.SelectedValue)
            gsDGV.CurrentCell = gsDGV.Rows(gsDGV.Rows.Count - 1).Cells(1) 'Last Row HighLight
        Else
            With gsDGV.Rows(gsDGV.CurrentRow.Index)
                .Cells("CODE").Value = cmbCode.Text
                .Cells("DESCRIPTION").Value = cmbDescription.Text
                .Cells("QTY").Value = numQty.Value
                .Cells("RATE").Value = numRate.Value
                .Cells("STATUS").Value = IIf(gsID = "", "n", "e")
                .Cells("ITEM_ID").Value = cmbCode.SelectedValue
            End With

        End If
        gsNew = True
        btnOK.Text = "Add"
        cmbCode.SelectedIndex = -1
        cmbDescription.SelectedIndex = -1
        numQty.Value = 1
        numRate.Value = 0
        cmbCode.Focus()
    End Sub
End Class