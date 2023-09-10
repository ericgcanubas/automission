Module modVRObject
    Public gsUSE_SCREEN_BUTTON As Boolean

    Public gsKEY_PASS As Boolean
    Public Sub NumberPadKeyToTouch(ByVal num As NumericUpDown, ByVal Title As String)
        If gsUSE_SCREEN_BUTTON = False Then

            Exit Sub
        End If
        With FrmPOSNumpad
            .lblTITLE.Text = Title
            .ShowDialog()
            If .gsEnter = True Then
                num.Value = Val(.gsValue)
            End If
            .Dispose()
        End With
        FrmPOSNumpad = Nothing
    End Sub
    Public Sub KeyBoardToTouch(ByVal txt As TextBox, ByVal Title As String)
        If gsUSE_SCREEN_BUTTON = False Then

            Exit Sub
        End If

        With FrmPOSKeyboard
            .gsIsPassword = gsKEY_PASS
            .lblTITLE.Text = Title
            .ShowDialog()
            If .gsEnter = True Then
                txt.Text = .gsValue
            End If
            .Dispose()
        End With
        FrmPOSKeyboard = Nothing
        gsKEY_PASS = False
    End Sub
End Module
