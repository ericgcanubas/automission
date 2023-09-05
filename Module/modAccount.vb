Imports System.Data.Odbc
Module modAccount



    Public Sub fLoadAccountTag()
        Try
            For i As Integer = 0 To 9999
                gsACCOUNT_TAG_ID(i) = ""
            Next
            '=============
            Dim rd As OdbcDataReader = fReader("select ID,TAG from account ")
            While rd.Read
                gsACCOUNT_TAG_ID(rd("ID")) = fTextisNULL(rd("TAG"))
            End While
            rd.Close()
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try

    End Sub
End Module
