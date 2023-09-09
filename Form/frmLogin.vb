Imports System.Data.Odbc
Public Class FrmLogin
    Public bLogin As Boolean = False


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        frmPOSRestoMenu = Nothing
        frmPOSmenu = Nothing
        frmPOSOrderEntry = Nothing

        gsUser_ID = 0
        '  Dim cn As New MySqlConnection(mysqlConstr)
        Dim system_status_type As Integer = 0
        Dim sql_query As String
        If gsPOS_Mode = False Then
            sql_query = "select * from user where name ='" & txtUsername.Text & "' and password='" & Encrypt(txtPassword.Text) & "'"
        Else
            sql_query = "select * from user where name ='" & txtUsername.Text & "' and password='" & Encrypt(txtPassword.Text) & "'"
        End If


        Try
            ' cn.Open()

            Dim rd As OdbcDataReader = SqlReader(sql_query)
            If rd.Read Then
                gsUser_ID = NumIsNull(rd("ID"))
                system_status_type = NumIsNull(rd("STATUS"))

                Select Case system_status_type
                    Case 1
                        If gsPOS_Mode = False Then

                        Else
                            MessageBoxWarning("User status -> cannot access")
                            Exit Sub
                        End If
                    Case 2
                        'POS
                        If gsPOS_Mode = True Then

                        Else
                            MessageBoxWarning("User status -> cannot access")
                            Exit Sub
                        End If

                    Case 3

                        MessageBoxWarning("User Locked")
                        Exit Sub
                        'LOCKED

                End Select

                If fUserDefaulDisabled() = True Then

                    PrompNotify(Me.Text, "Sorry, you are not allowed to access right now.", False)
                    rd.Close()
                    Exit Sub
                End If
                If gsPOS_TYPE = 4 Then
                    gsMeasureHoursID = GetSystemSettingValueByNumber("measure_hours")

                    If gsMeasureHoursID = 0 Then
                        MessageBoxInfo("Please set default Measure Hours")
                        Exit Sub
                    End If
                End If



                If NumIsNull(rd("TYPE")) = 1 Then
                    gsAdmin_User = True
                Else
                    gsAdmin_User = False
                End If

                If gsPOS_Mode = True Then
                    gsCashier_ID = TextIsNull(rd("CONTACT_ID"))
                    If GetStringFieldValue("contact", "id", gsCashier_ID, "id") = "" Then

                        PrompNotify(Me.Text, "Please set a  USER -> CONTACT", False)
                        Exit Sub
                    End If

                    If fPOS_MACHINE_ID() = 0 Then

                        PrompNotify(Me.Text, "POS machine No. is not set", False)
                        Exit Sub
                    End If
                End If


                If fGet_user_access_control(gsUser_ID) = True Then
                    ' account is already access
                    SqlExecuted("update user_access_control set req_ip_address = '" & GetIPv4Address() & "' ,`status` = '2' where  user_id = '" & gsUser_ID & "' and `status` = '1' limit 1")
                    frmMessageUserControLoading.ShowDialog()
                    frmMessageUserControLoading.Dispose()
                    frmMessageUserControLoading = Nothing
                    rd.Close()
                    Exit Sub
                Else
                    gsUserPriceLock = fUserPriceLock()
                End If

                'load default

                Dim pass_value As String = ""
                gsUser_Name = TextIsNull(rd("Name"))
                gsUserDescription = TextIsNull(rd("DESCRIPTION"))
                'If chkRemember_password.Checked = True Then
                '    pass_value = txtPassword.Text
                'End If
                fMS_execute("UPDATE tbllogin SET [username] = '" & txtUsername.Text & "', [password] = '" & pass_value & "' WHERE [ID] = '1'")
                Me.Hide()
                bLogin = True
                Me.Close()

                rd.Close()
                frmSplash.Hide()


                If gsPOS_Mode = False Then

                    '  Gmail("User Login on BMS", $"Username:{gsUser_Name} {vbNewLine} DateTime:{GetDateTimeNowSql()} {vbNewLine} On BMS", $"{gsGmailAddressTo}@gmail.com")

                    '    frmMenu.Show()
                    frmMainMenu.Show()
                Else
                    ' Gmail("User Login on BMS", $"Username:{gsUser_Name} {vbNewLine} DateTime:{GetDateTimeNowSql()} {vbNewLine} On BMS-POS", $"{gsGmailAddressTo}@gmail.com")
                    Select Case gsPOS_TYPE
                        Case 0
                            fPOS_Reset()
                            frmPOSmenu.Show()
                        Case 1
                            fPOS_Reset()
                            frmPOSOrderEntry.Show()

                        Case 2

                            fPOS_Reset()
                            frmPOSRestoMenu.Show()
                        Case 3
                            frmPOSRestoKitchenMonitoring.Show()

                        Case 4

                            fPOS_Reset()
                            FrmPOSRoom.Show()

                    End Select


                End If

                bActiveFirst = True
            Else
                rd.Close()
                txtPassword.Clear()
                txtPassword.Focus()
                PrompNotify(Me.Text, "Invalid username or password", False)
            End If

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load

        bLogin = False
        Me.Icon = gsIcon


        If gsPOS_Mode = True Then

            Select Case gsPOS_TYPE
                Case 0
                    Me.Text = "POS CASH REGISTER"
                Case 1
                    Me.Text = "POS ORDER ENTRY"
                Case 2
                    Me.Text = "POS RESTUARANT"
            End Select

        Else
            Me.Text = "LOGIN "
        End If

        txtUsername.Text = fMSgetField("username", "tbllogin", "id", "1")
        txtPassword.Text = fMSgetField("password", "tbllogin", "id", "1")
        'If txtPassword.Text.Length <> 0 Then
        '    chkRemember_password.Checked = True
        'End If


        Try
            Dim DT As String = GetSystemSettingValueByText("BusinessStart")
            If IsDate(DT) = True Then
                gsBusinessDateStart = DT
            Else
                gsBusinessDateStart = "1/1/2010"
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtUsername.Text.Length = 0 Then

                PrompNotify(Me.Text, "Please enter username", True)
                Exit Sub
            End If
            txtPassword.Focus()
        ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Shift) Then
            txtUsername.Text = Decrypt(GetStringFieldValue("`USER`", "`NAME`", txtUsername.Text, "PASSWORD"))
        ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control) Then
            txtPassword.Text = Decrypt(GetStringFieldValue("`USER`", "`NAME`", txtUsername.Text, "PASSWORD"))
        End If

    End Sub


    Private Sub txtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text.Length = 0 Then

                PrompNotify(Me.Text, "Please enter password", True)

                Exit Sub
            End If
            btnLogin.PerformClick()

        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If txtUsername.Text.Length = 0 Then
            txtUsername.Focus()
        ElseIf txtPassword.Text.Length = 0 Then
            txtPassword.Focus()
        Else
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub frmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'chkRemember_password.Checked = False
        If txtUsername.Text.Length <> 0 Then
            txtPassword.Focus()
        End If

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If bLogin = True Then

        Else


            bLogin = False
            frmConnectionList.Visible = True
        End If
    End Sub

    Private Sub TxtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub

    Private Sub txtUsername_Click(sender As Object, e As EventArgs) Handles txtUsername.Click
        fKeyBoardToTouch(txtUsername, "Enter Username")

    End Sub

    Private Sub txtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        gsKEY_PASS = True
        fKeyBoardToTouch(txtPassword, "Enter Password")

    End Sub
End Class
