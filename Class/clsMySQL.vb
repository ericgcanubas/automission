Imports MySql.Data.MySqlClient
Public Class clsMySQL
    Private Property connection As MySqlConnection
    Public Sub New(ByVal con As MySqlConnection)
        connection = con
    End Sub
    Private Function Connect() As Boolean
        Dim ReturnValue As Boolean = False
        connection = New MySqlConnection
        connection.ConnectionString = mysqlConstr
        Try
            connection.Open()
            ReturnValue = True
        Catch myerror As MySqlException
            fMessageboxError("Error Connecting to Database: " & myerror.Message)
        End Try

        Return ReturnValue
    End Function
End Class
