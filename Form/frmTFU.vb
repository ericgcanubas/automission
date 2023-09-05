Imports System.Data.Odbc
Public Class frmTFU

    Public gsText As String

    Private Sub frmTFU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMS_ComboBox(cmbConnectionSelected, "select connection_name as `B`,connection_name as `A` from tblconnection", "B", "A")
        fMS_ComboBox(cmbConnectionAnalyst, "select connection_name as `B`,connection_name as `A` from tblconnection", "B", "A")
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        ListBox1.Items.Clear()
        Dim dbname1 As String = ""
        Dim dbname2 As String = ""

        Dim mysqlConSelect As String = fGetConnectionString(cmbConnectionSelected.Text, dbname1)
        Dim mysqlConAnalyst As String = fGetConnectionString(cmbConnectionAnalyst.Text, dbname2)


        Dim cn_selected As New OdbcConnection(mysqlConSelect)
        Dim cn_analyst As New OdbcConnection(mysqlConAnalyst)
        Try

            cn_selected.Open()

            cn_analyst.Open()

            If cn_analyst.State = ConnectionState.Open And cn_selected.State = ConnectionState.Open Then

                If fMessageBoxQuestion("Do you want to continue?") = True Then

                    Dim rd1 As OdbcDataReader = fReader("SELECT table_name FROM information_schema.tables where table_schema='" & dbname1 & "'")
                    Dim td As New DataTable
                    td.Load(rd1)
                    Dim t As Integer = td.Rows.Count
                    cn_selected.Close()
                    cn_selected.Open()
                    rd1 = Nothing
                    rd1 = fReader("SELECT table_name FROM information_schema.tables where table_schema='" & dbname1 & "'")
                    Dim r As Integer = 0
                    ProgressBar1.Minimum = 0
                    ProgressBar1.Value = 0

                    ProgressBar1.Maximum = t
                    While rd1.Read
                        r = r + 1
                        If fCheckingTable(rd1("table_name"), mysqlConSelect, mysqlConAnalyst) = False Then
                            ListBox1.Items.Add("Error " & rd1("table_name"))
                            ListBox1.SelectedIndex = ListBox1.Items.Count - 1
                            Exit While
                        Else
                            ListBox1.Items.Add(rd1("table_name"))
                            ListBox1.SelectedIndex = ListBox1.Items.Count - 1
                        End If

                        ProgressBar1.Value = r

                    End While

                    ListBox1.Items.Add("Checking Complete...")

                End If
            End If

            cn_selected.Close()
            cn_analyst.Close()


        Catch ex As Exception

            If cn_selected.State = ConnectionState.Open Then
                cn_selected.Close()
            End If

            If cn_analyst.State = ConnectionState.Open Then
                cn_analyst.Close()
            End If

            fMessageboxWarning(ex.Message)
        End Try


    End Sub
    Private Function fCheckingTable(ByVal prTable_name As String, ByVal constr_select As String, ByVal constr_analsyt As String) As Boolean
        Dim bGood As Boolean = True
        Dim cn_s As New OdbcConnection(constr_select)
        Try
            cn_s.Open()
            Dim rd As OdbcDataReader = fReader("SHOW COLUMNS FROM  `" & prTable_name & "`")
            While rd.Read
                If fAnalyst_Column(rd, constr_analsyt, prTable_name, rd("FIELD")) = False Then
                    bGood = False
                    Exit While
                End If
            End While
            cn_s.Close()
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
            If cn_s.State = ConnectionState.Open Then
                cn_s.Close()
            End If

        End Try

        Return bGood
    End Function
    Private Function fAnalyst_Column(ByVal rd_select As OdbcDataReader, ByVal prCon_A As String, ByVal prTable_name As String, ByVal prField_name As String) As Boolean

        Dim b As Boolean = False
        Dim cn_a As New OdbcConnection(prCon_A)
        Try
            cn_a.Open()
            Dim rd As OdbcDataReader = fReader("SHOW COLUMNS FROM `" & prTable_name & "` WHERE FIELD = '" & prField_name & "'")
            If rd.Read Then
                If fTextisNULL(rd_select("FIELD")) = fTextisNULL(rd("FIELD")) Then
                    b = True
                Else
                    b = False
                    ListBox1.Items.Add("Field not match (" & rd_select("FIELD") & ") Problem from " & prTable_name)
                End If
            Else
                b = False
                ListBox1.Items.Add("Not found " & rd_select("FIELD") & " Field from " & prTable_name)
            End If
            cn_a.Close()
        Catch ex As Exception
            b = False
            If cn_a.State = ConnectionState.Open Then
                cn_a.Close()
            End If

            ListBox1.Items.Add("Table not found " & prTable_name)

        End Try
        Return b
    End Function
    Private Function fGetConnectionString(ByVal getString As String, ByRef pr_Db As String) As String

        Dim path As String = AppDomain.CurrentDomain.BaseDirectory
        Dim file_path As String = path & "temp_db.mdb"
        Dim cn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & file_path & ";")

        Dim db_server_ex As String = ""
        Dim db_name_ex As String = ""
        Dim db_username_ex As String = ""
        Dim db_password_ex As String = ""
        Dim db_port_ex As String = ""

        cn.Open()
        Dim rd As OleDb.OleDbDataReader = fMSgetReader("select * from tblconnection where connection_name ='" & getString & "' ", cn)
        If rd.Read Then
            db_server_ex = rd("db_server")
            db_name_ex = rd("db_name")
            db_username_ex = rd("db_username")
            db_password_ex = Decrypt(rd("db_password"))
            db_port_ex = rd("db_port")
            pr_Db = db_name_ex
        Else
            fMessageboxInfo("Invalid data!")
        End If

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Return "server=" & db_server_ex & ";user id=" & db_username_ex & ";password=" & db_password_ex & ";database=" & db_name_ex & ";port=" & db_port_ex & ";"


    End Function
End Class