Module modVRObject
    Public gsUSE_SCREEN_BUTTON As Boolean

    Public gsKEY_PASS As Boolean
    Public Sub fnumPadKeyToTouch(ByVal num As NumericUpDown, ByVal Title As String)
        If gsUSE_SCREEN_BUTTON = False Then

            Exit Sub
        End If
        With frmPOSNumpad
            .lblTITLE.Text = Title
            .ShowDialog()
            If .gsEnter = True Then
                num.Value = Val(.gsValue)
            End If
            .Dispose()
        End With
        frmPOSNumpad = Nothing
    End Sub
    Public Sub fKeyBoardToTouch(ByVal txt As TextBox, ByVal Title As String)
        If gsUSE_SCREEN_BUTTON = False Then

            Exit Sub
        End If

        With frmPOSKeyboard
            .gsIsPassword = gsKEY_PASS
            .lblTITLE.Text = Title
            .ShowDialog()
            If .gsEnter = True Then
                txt.Text = .gsValue
            End If
            .Dispose()
        End With
        frmPOSKeyboard = Nothing
        gsKEY_PASS = False
    End Sub
End Module
