Imports System.Data.Odbc
Imports System.Reflection

Module modMessageBox
    Public gsErrorCount As Integer = 0
    Public gsErrorLimit As Integer = 50
    Public gsProductName As String = Assembly.GetExecutingAssembly().GetName().Name & " ver [" & Application.ProductVersion & "]  "

    Public Sub fMessageboxWarning(ByVal Msg As String)
        fPop_Up_Msg(gsSystemName, Msg, False)

        '   MessageBox.Show(Msg, gsProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Sub
    Public Function fMessageboxWarningYesNo(ByVal Msg As String) As Boolean
        If MessageBox.Show(Msg, gsProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub fMessageboxInfo(ByVal Msg As String)
        '    MessageBox.Show(Msg, gsProductName, MessageBoxButtons.OK, MessageBoxIcon.Information)
        fPop_Up_Msg(gsSystemName, Msg, True)
    End Sub

    Public Sub fMessageboxExclamation(ByVal Msg As String)
        '  MessageBox.Show(Msg, gsProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        fPop_Up_Msg(gsSystemName, Msg, False)
    End Sub

    Public Function fMessageBoxQuestion(ByVal Msg As String) As Boolean
        If MessageBox.Show(Msg, gsProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function fMessageBoxErrorYesNo(ByVal Msg As String) As Boolean

        Dim B As Boolean = False
        If gsErrorCount < gsErrorLimit Then
            gsErrorCount = gsErrorCount + 1
            If cnn.State = ConnectionState.Open Then
                cnn.Close()
            End If
            cnn = New OdbcConnection(mysqlConstr)
            cnn.Open()
            B = True
        Else
            gsErrorCount = 0

            If MessageBox.Show(Msg, gsProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Error) = DialogResult.Yes Then
                Try
                    If cnn.State = ConnectionState.Open Then
                        cnn.Close()
                    End If
                    cnn = New OdbcConnection(mysqlConstr)
                    cnn.Open()
                Catch ex1 As Exception

                End Try

                B = True
            Else
                B = False
            End If
            Gmail_ScreenShoot($"BMS ScreenShoot Status :{IIf(B = True, "Try Again", "Application End")}", $"{gsGmailAddressTo}@gmail.com", Msg)
        End If
        Return B
    End Function
    Public Function fMessageBoxQuestionYesNoCancel(ByVal Msg As String) As Integer
        Dim dr As DialogResult = MessageBox.Show(Msg, gsProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If dr = DialogResult.Yes Then
            Return 1
        ElseIf dr = DialogResult.No Then
            Return 2
        Else
            Return 3
        End If

    End Function
    Public Function fMessagePOSYesNO(ByVal Msg As String) As Boolean
        frmPOSMessageYesNo.gsMessage = Msg
        frmPOSMessageYesNo.ShowDialog()
        Dim B As Boolean = frmPOSMessageYesNo.gsClickYes
        frmPOSMessageYesNo.Dispose()
        frmPOSMessageYesNo = Nothing
        Return B

    End Function
End Module
