

Imports System.Data.Odbc
Module modOnline


    Public Sub fResetConnection()
        Try

            cnn = New OdbcConnection(mysqlConstr)
            cnn.Open()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fResetConnection()
            Else
                End
            End If
        End Try
    End Sub
End Module
