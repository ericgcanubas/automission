Imports System.Data.Odbc
Public Class FrmConnectionSetup
    Public bNew As Boolean
    Dim bTest As Boolean = False
    Public strCon_Name As String
    Private Sub ftemp_Refresh()

        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = fMSgetReader("select * from tblconnection where connection_name = '" & strCon_Name & "'", cn)
            If rd.Read Then
                txtConnectionName.Text = TextIsNull(rd("connection_name"))
                txtServer.Text = TextIsNull(rd("db_server"))
                txtDatabase.Text = TextIsNull(rd("db_name"))
                txtUsername.Text = TextIsNull(rd("db_username"))
                txtPassword.Text = TextIsNull(Decrypt(rd("db_password")))
                txtPort.Text = TextIsNull(rd("db_port"))
                cmbPOS_TYPE.SelectedIndex = NumIsNull(rd("db_datasource_name"))
                chkPOS_MODE.Checked = rd("POS_MODE")

            End If
            cn.Close()
        Catch ex As Exception
            MessageBoxExclamation("Something Wrong the Temporaty Data")
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub


    Private Sub frmConnectionSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If bNew = False Then

            ftemp_Refresh()
            txtConnectionName.ReadOnly = True
        End If

    End Sub
    Private Sub btnCanceled_Click(sender As Object, e As EventArgs) Handles btnCanceled.Click
        Me.Close()
    End Sub

    Private Sub btnSaveIT_Click(sender As Object, e As EventArgs) Handles btnSaveIT.Click

        Dim sql_query As String
        If bNew = True Then


            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim rd As OleDb.OleDbDataReader = fMSgetReader("select * from tblconnection where connection_name ='" & txtConnectionName.Text & "'", cn)
                If rd.Read Then
                    MessageBoxWarning("Connection name is already use!")
                    cn.Close()
                    Exit Sub

                End If
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                Exit Sub
            End Try
            cn.Close()
            sql_query = "INSERT INTO tblconnection (connection_name,db_server,db_name,db_username,db_password,db_port,db_datasource_name,pos_mode) values ('" & txtConnectionName.Text & "','" & txtServer.Text & "','" & txtDatabase.Text & "','" & txtUsername.Text & "','" & Encrypt(txtPassword.Text) & "','" & txtPort.Text & "','" & cmbPOS_TYPE.SelectedIndex & "'," & chkPOS_MODE.Checked & ")"
        Else
            sql_query = "UPDATE tblconnection set db_server = '" & txtServer.Text & "',db_name='" & txtDatabase.Text & "',db_username ='" & txtUsername.Text & "',db_password='" & Encrypt(txtPassword.Text) & "',db_port='" & txtPort.Text & "',db_datasource_name = '" & cmbPOS_TYPE.SelectedIndex & "',POS_MODE = " & chkPOS_MODE.Checked & " where connection_name = '" & txtConnectionName.Text & "'"
        End If

        fMS_execute(sql_query)

        If bNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        Me.Close()
    End Sub



    Private Sub btnTesting_Click(sender As Object, e As EventArgs) Handles btnTesting.Click

        If txtServer.Text.Length < 3 Then
            PrompNotify("Test Connection", "Server Character must above 3 ", False)
            Exit Sub
        End If

        If txtDatabase.Text.Length < 3 Then
            PrompNotify("Test Connection", "Database Character must above 3 ", False)
            Exit Sub
        End If

        If txtUsername.Text.Length < 3 Then
            PrompNotify("Test Connection", "Username Character must above 3 ", False)
            Exit Sub
        End If

        If txtPort.Text.Length < 3 Then
            PrompNotify("Test Connection", "Port Character must above 3 ", False)
            Exit Sub
        End If

        Dim strConnect As String = "DRIVER={MySQL ODBC 8.0 Unicode Driver};SERVER=" & txtServer.Text & ";DATABASE=" & txtDatabase.Text & ";UID=" & txtUsername.Text & ";PASSWORD=" & txtPassword.Text & ";PORT=" & txtPort.Text & ";OPTION=3;"
        CreateUserDSN(txtDatabase.Text, txtServer.Text, txtDatabase.Text, txtUsername.Text, txtPassword.Text, txtPort.Text)

        Dim cn As New OdbcConnection(strConnect)
        Try
            cn.Open()
            PrompNotify(Me.Text, "Successfully connected.", True)
            bTest = True
            cn.Close()
        Catch ex As Exception
            bTest = False
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
End Class