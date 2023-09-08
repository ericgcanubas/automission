Public Class FrmInsertValue
    Public gsID As String
    Public gsFORM_NAME As String = "Enter Value"
    Public gsDescription As String
    Public bSave As Boolean
    Public gsValue As String


    'Declare the variables

    Private Sub frmInsertValue_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMaterialSkin(Me)
        lblDescription.Text = gsDescription
        txtValue.Text = gsValue
        gsValue = ""
        Me.Text = gsFORM_NAME
        bSave = False

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtValue_TextChanged(sender As Object, e As EventArgs) Handles txtValue.TextChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtValue_KeyDown(sender As Object, e As KeyEventArgs) Handles txtValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.Focus()
        End If
    End Sub

    Private Sub txtValue_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtValue.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers
        Dim N As Integer = Asc(e.KeyChar)
        If Me.CausesValidation = True Then
            If N <> 8 Then
                If N = 46 Then

                ElseIf N < 48 Or N > 57 Then
                    e.Handled = True
                End If
            End If

        Else
            If N <> 8 Then
                If N < 97 Or N > 122 Then
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        bSave = True
        gsValue = txtValue.Text
        Me.Close()
    End Sub
End Class