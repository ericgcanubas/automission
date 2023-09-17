Module modDSN
    Private Declare Function SQLConfigDataSource Lib "ODBCCP32.DLL" (ByVal hwndParent As Integer, ByVal ByValfRequest As Integer, ByVal lpszDriver As String, ByVal lpszAttributes As String) As Integer
    Private Declare Function SQLInstallerError Lib "ODBCCP32.DLL" (ByVal iError As Integer, ByRef pfErrorCode As Integer, ByVal lpszErrorMsg As System.Text.StringBuilder, ByVal cbErrorMsgMax As Integer, ByRef pcbErrorMsg As Integer) As Integer

    Private Const ODBC_ADD_DSN As Short = 1 ' Add data source
    Private Const vbAPINull As Integer = 0 ' NULL Pointer

    Public Sub CreateUserDSN(ByVal prDSN As String, ByVal prServer As String, ByVal prDatabase As String, ByVal prUser As String, ByVal prPassword As String, ByVal prPort As Integer)

        Try


            Dim intRet As Integer
            Dim Driver As String
            Dim Attributes As String

            'Set the driver to SQL Server because it is most common.
            Driver = "MySQL ODBC 8.0 Unicode Driver"
            'Set the attributes delimited by null.
            'See driver documentation for a complete
            'list of supported attributes.
            Attributes = $"SERVER={prServer}" & Chr(0)
            Attributes = Attributes & $"USER={prUser}" & Chr(0)
            Attributes = Attributes & $"PASSWORD={prPassword}" & Chr(0)
            Attributes = Attributes & $"PORT={prPort}" & Chr(0)
            Attributes = Attributes & $"DESCRIPTION={prDatabase}" & Chr(0)
            Attributes = Attributes & $"DSN={prDSN}" & Chr(0)
            Attributes = Attributes & $"DATABASE={prDatabase}" & Chr(0)
            'Unsupported by SQL Server
            'Attributes = Attributes & "Uid=" & Chr(0) & "pwd=" & Chr(0)
            'To show dialog, use Form1.Hwnd instead of vbAPINull.
            intRet = SQLConfigDataSource(vbAPINull, ODBC_ADD_DSN, Driver, Attributes)
            If intRet <> 0 Then

            Else
                Dim nErrorCode As Integer
                Dim strError As New System.Text.StringBuilder(255)
                Dim nErrorLen As Integer
                intRet = SQLInstallerError(1, nErrorCode, strError, 255, nErrorLen)
                MsgBox("Create Failed - " & Left$(strError.ToString, nErrorLen))
            End If
        Catch ex As Exception
            MessageBoxExclamation(ex.Message & " [Create User DSN INFO Message]")
        End Try
    End Sub
End Module
