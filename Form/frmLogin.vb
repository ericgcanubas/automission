Imports System.Data.Odbc
Public Class FrmLogin
    Public IsLogin As Boolean = False


    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        FrmPOSRestoMenu = Nothing
        FrmPOSmenu = Nothing
        FrmPOSOrderEntry = Nothing
        gsUser_ID = 0
        Dim SystemStatusType As Integer
        Dim sql_query As String
        If gsPOS_Mode = False Then
            sql_query = "select * from user where name ='" & txtUsername.Text & "' and password='" & Encrypt(txtPassword.Text) & "'"
        Else
            sql_query = "select * from user where name ='" & txtUsername.Text & "' and password='" & Encrypt(txtPassword.Text) & "'"
        End If
        Try
            Dim rd As OdbcDataReader = SqlReader(sql_query)
            If rd.Read Then
                gsUser_ID = NumIsNull(rd("ID"))
                SystemStatusType = NumIsNull(rd("STATUS"))

                Select Case SystemStatusType
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
                    FrmMessageUserControLoading.ShowDialog()
                    FrmMessageUserControLoading.Dispose()
                    FrmMessageUserControLoading = Nothing
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
                IsLogin = True
                Me.Close()

                rd.Close()
                FrmSplash.Hide()


                If gsPOS_Mode = False Then

                    '  Gmail("User Login on BMS", $"Username:{gsUser_Name} {vbNewLine} DateTime:{GetDateTimeNowSql()} {vbNewLine} On BMS", $"{gsGmailAddressTo}@gmail.com")

                    '    frmMenu.Show()
                    FrmMainMenu.Show()
                Else
                    ' Gmail("User Login on BMS", $"Username:{gsUser_Name} {vbNewLine} DateTime:{GetDateTimeNowSql()} {vbNewLine} On BMS-POS", $"{gsGmailAddressTo}@gmail.com")
                    Select Case gsPOS_TYPE
                        Case 0
                            fPOS_Reset()
                            FrmPOSmenu.Show()
                        Case 1
                            fPOS_Reset()
                            FrmPOSOrderEntry.Show()

                        Case 2

                            fPOS_Reset()
                            FrmPOSRestoMenu.Show()
                        Case 3
                            FrmPOSRestoKitchenMonitoring.Show()

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

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load

        IsLogin = False
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

    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
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

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text.Length = 0 Then
                PrompNotify(Me.Text, "Please enter password", True)
                Exit Sub
            End If
            btnLogin.PerformClick()

        End If
    End Sub
    Private Sub FrmLogin_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        If txtUsername.Text.Length = 0 Then
            txtUsername.Focus()
        ElseIf txtPassword.Text.Length = 0 Then
            txtPassword.Focus()
        Else
            btnLogin.PerformClick()
        End If
    End Sub

    Private Sub FrmLogin_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        If txtUsername.Text.Length <> 0 Then
            txtPassword.Focus()
        End If

    End Sub


    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If IsLogin = False Then
            FrmConnectionList.Visible = True
        End If
    End Sub
    Private Sub TxtUsername_Click(sender As Object, e As EventArgs) Handles txtUsername.Click
        KeyBoardToTouch(txtUsername, "Enter Username")

    End Sub

    Private Sub TxtPassword_Click(sender As Object, e As EventArgs) Handles txtPassword.Click
        gsKEY_PASS = True
        KeyBoardToTouch(txtPassword, "Enter Password")
    End Sub
End Class
