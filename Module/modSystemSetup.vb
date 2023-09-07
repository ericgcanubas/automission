

Module modSystemSetup

    Public Function fGet_System_VALUE(ByVal prID As String) As String
        Dim sValue As String = ""
        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = fMSgetReader("select [SYSTEM_VALUE] AS V FROM [TBLSYSTEM] WHERE ID = '" & prID & "'", cn)
            If rd.Read Then
                sValue = rd("V")
                cn.Close()
            Else
                cn.Close()
                sValue = ""
                fMS_execute("INSERT INTO [TBLSYSTEM] ([ID],[SYSTEM_VALUE]) VALUES ('" & prID & "','')")
                MessageBoxInfo("NEW SYSTEM SETUP CREATED " & prID)

            End If

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MessageBoxWarning(ex.Message)
        End Try
        Return sValue


    End Function
    Public Function fGet_System_VALUE_Bool(ByVal prID As String) As Boolean
        Dim sValue As Boolean = False
        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = fMSgetReader("select [SYSTEM_VALUE] AS V FROM [TBLSYSTEM] WHERE ID = '" & prID & "'", cn)
            If rd.Read Then
                sValue = CBool(rd("V"))
                cn.Close()
            Else
                cn.Close()
                sValue = False
                fMS_execute("INSERT INTO [TBLSYSTEM] ([ID],[SYSTEM_VALUE]) VALUES ('" & prID & "','0')")
                MessageBoxInfo("NEW SYSTEM SETUP CREATED " & prID)
                sValue = False
            End If

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MessageBoxWarning(ex.Message)
        End Try
        Return sValue


    End Function
    Public Sub fSET_SYSTEM_VALUE(ByVal prID As String, prVALUE As String)

        fMS_execute("UPDATE  [TBLSYSTEM] SET [SYSTEM_VALUE] ='" & prVALUE & "'  WHERE [ID] ='" & prID & "'")

    End Sub


End Module
