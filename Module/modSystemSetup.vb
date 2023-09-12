

Module modSystemSetup

    Public Function GetDBAccessValueByText(ByVal prID As String) As String
        Dim sValue As String = ""
        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader("select [SYSTEM_VALUE] AS V FROM [TBLSYSTEM] WHERE ID = '" & prID & "'", cn)
            If rd.Read Then
                sValue = rd("V")
                cn.Close()
            Else
                cn.Close()
                sValue = ""
                DbAccessExecute("INSERT INTO [TBLSYSTEM] ([ID],[SYSTEM_VALUE]) VALUES ('" & prID & "','')")
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
    Public Function GetDBAccessValueByBool(ByVal prID As String) As Boolean
        Dim sValue As Boolean = False
        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader("select [SYSTEM_VALUE] AS V FROM [TBLSYSTEM] WHERE ID = '" & prID & "'", cn)
            If rd.Read Then
                sValue = CBool(rd("V"))
                cn.Close()
            Else
                cn.Close()
                sValue = False
                DbAccessExecute("INSERT INTO [TBLSYSTEM] ([ID],[SYSTEM_VALUE]) VALUES ('" & prID & "','0')")
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
    Public Sub SetDBAccessValue(ByVal prID As String, prVALUE As String)

        DbAccessExecute("UPDATE  [TBLSYSTEM] SET [SYSTEM_VALUE] ='" & prVALUE & "'  WHERE [ID] ='" & prID & "'")

    End Sub


End Module
