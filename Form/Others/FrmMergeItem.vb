Imports System.Data.Odbc
Public Class FrmMergeItem
    Dim n_cnn As OdbcConnection
    Private Sub n_fExecutedOnly(ByVal sQuery As String)
        Try
            CursorLoadingOn(True)
            Dim cmd As New OdbcCommand(sQuery, n_cnn)
            cmd.CommandTimeout = 999999
            cmd.ExecuteNonQuery()
            CursorLoadingOn(False)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                SqlExecuted(sQuery)
            Else
                End
            End If

        End Try

    End Sub
    Private Function n_fMySqlDataReader(ByVal sQuery As String) As OdbcDataReader
        Try

            Dim cmd As New OdbcCommand(sQuery, n_cnn)
            cmd.CommandTimeout = 999999
            Return cmd.ExecuteReader
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                Return n_fMySqlDataReader(sQuery)
            Else
                End
            End If
            Return Nothing
        End Try
    End Function
    Private Function n_fReader(ByVal sQuery) As OdbcDataReader

        Return n_fMySqlDataReader(sQuery)

    End Function
    Private Sub btnMerge_Click(sender As Object, e As EventArgs) Handles btnMerge.Click
        fNewCheck()
        Dim rd As OdbcDataReader = SqlReader("select i.code,i.description,i.cost,i.rate from item  as i inner join item_sub_class  as s on s.id = i.SUB_CLASS_ID   where  i.type ='0' and s.class_id in ('40','38') and i.inactive ='0' ")

        While rd.Read
            fBMS_Item(rd("CODE"), rd("DESCRIPTION"), NumIsNull(rd("COST")), NumIsNull(rd("RATE")))

        End While
        CursorLoadingOn(False)
        If n_cnn.State = ConnectionState.Open Then
            n_cnn.Close()
        End If
    End Sub
    Private Sub fNewCheck()

        Dim SQL_Con As String

        SQL_Con = "server=192.168.1.3;user id=root;password=root;database=activeone_inknow;port=3307;"


        Try
            CursorLoadingOn(True)

            n_cnn = New OdbcConnection(SQL_Con)
            n_cnn.Open()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        Finally

        End Try





    End Sub

    Private Sub fBMS_Item(ByVal CODE As String, ByVal DESCRIPTION As String, ByVal Cost As Double, ByVal Rate As Double)

        Dim rd As OdbcDataReader = n_fReader($"select * from item Where `CODE` like '%{CODE}%' limit 1")

        If rd.Read Then
            'UPDATE COST,RATE ONLY
            n_fExecutedOnly($"UPDATE item SET COST ='{Cost}',RATE ='{Rate}' where Id = '{rd("id")}' limit 1;")
            fDoEvents()
        Else
            'INSERT 

        End If
        rd.Close()
    End Sub

End Class