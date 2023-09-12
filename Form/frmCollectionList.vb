
Public Class FrmCollectionList
    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        Dim path As String = AppDomain.CurrentDomain.BaseDirectory
        Dim file_path As String = path & "temp_db.mdb"
        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & file_path & ";")
        cn.Open()
        Try


            lvCollect.Items.Clear()

            Dim db_connection_name As String = ""
            Dim db_server_ex As String = ""
            Dim db_name_ex As String = ""

            Dim db_username_ex As String = ""
            Dim db_password_ex As String = ""
            Dim db_port_ex As String = ""

            Dim rd1 As OleDb.OleDbDataReader = DbAccessReader("select * from tblconnection ", cn)
            Dim dt As New DataTable
            dt.Load(rd1)
            cn.Close()
            Dim tr As Integer = dt.Rows.Count
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader("select * from tblconnection ", cn)
            pgbLoading2.Minimum = 0
            pgbLoading2.Maximum = tr
            pgbLoading2.Value = 0
            Dim i As Integer = 0
            dtpFrom.Enabled = False
            dtpTo.Enabled = False

            While rd.Read

                i += 1
                pgbLoading2.Value = i

                db_connection_name = rd("connection_name")
                db_server_ex = rd("db_server")
                db_name_ex = rd("db_name")
                db_username_ex = rd("db_username")
                db_password_ex = Decrypt(rd("db_password"))
                db_port_ex = rd("db_port")

                Dim mySQLCON As String = "server=" & db_server_ex & ";user id=" & db_username_ex & ";password=" & db_password_ex & ";database=" & db_name_ex & ";port=" & db_port_ex & ";"

                Collected(mySQLCON, db_connection_name)

            End While
            cn.Close()
            dtpFrom.Enabled = True
            dtpTo.Enabled = True

        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            '   fMessageboxError(ex)

        End Try
    End Sub
    Private Sub Collected(ByVal prSQLCon As String, ByVal prName As String)
        'Dim cn As New MySqlConnection(prSQLCon)
        'Dim lv As ListViewItem = lvCollect.Items.Add(prName)
        'Try
        '    cn.Open()
        '    Dim rd As MySqlDataReader = fExecutedReader("SELECT sum(AMOUNT) AS `AMT` FROM payment WHERE `DATE` BETWEEN '" & Format(dtpFrom.Value, "yyyy-MM-dd") & "' and  '" & Format(dtpTo.Value, "yyyy-MM-dd") & "' limit 1", cn)
        '    If rd.Read Then

        '        Dim amt As Double = NumIsNull(rd("AMT"))
        '        lv.SubItems.Add(Format(amt, "standard"))
        '    Else
        '        lv.SubItems.Add("No collection")
        '    End If
        '    cn.Close()
        'Catch ex As Exception

        '    If cn.State = ConnectionState.Open Then
        '        cn.Close()
        '    End If
        '    '  fMessageboxError(ex)
        'End Try
    End Sub

    Private Sub FrmCollectionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpFrom.Value = Format(Now.Month & "/1/" & Now.Year)
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        BtnStart_Click(sender, e)
    End Sub

    Private Sub Preview_Click(sender As Object, e As EventArgs) Handles Preview.Click
        btnStart_Click(sender, e)
    End Sub
End Class