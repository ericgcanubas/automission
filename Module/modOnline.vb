

Imports System.Data.Odbc
Module modOnline


    Public Sub PS_ResetConnection()
        Try
            cnn = New OdbcConnection(mysqlConstr)
            cnn.Open()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                PS_ResetConnection()
            Else
                End
            End If
        End Try
    End Sub
End Module
