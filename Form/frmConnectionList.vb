

Public Class FrmConnectionList


    Dim HiLiteBrush As New SolidBrush(Color.FromKnownColor(KnownColor.LightSkyBlue))
    Dim IsAdmin As Boolean = True
    Private Sub RefreshList()

        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection())

        Dim temp_index As Integer = 0
        Try
            cn.Open()
            If listCon.Items.Count <> 0 Then
                temp_index = listCon.SelectedIndex
            End If

            listCon.Items.Clear()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader("select connection_name from tblconnection", cn)
            While rd.Read
                listCon.Items.Add(rd("connection_name"))
            End While
            If listCon.Items.Count <> 0 Then
                listCon.SelectedIndex = temp_index
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try


        Try
            listCon.SelectedIndex = Val(GetDBAccessValueByText("SELECT_CONNECTION"))
        Catch ex As Exception

        End Try


    End Sub
    Private Sub CreateConnection()
        If IsAdmin = False Then
            Exit Sub
        End If
        FrmConnectionSetup.bNew = True
        FrmConnectionSetup.ShowDialog()
        FrmConnectionSetup.Dispose()
        FrmConnectionSetup = Nothing
        RefreshList()
    End Sub
    Private Sub FrmConnectionList_Load(sender As Object, e As EventArgs) Handles Me.Load
        IsAdmin = IsRunAdministrator()

        If IsAdmin = True Then
            listCon.ContextMenuStrip = ContextMenuStrip1
        End If

        gsSYSTEM_UPGRADE = Val(GetDBAccessValueByText("SYSTEM_UPGRADE"))

        gsSystemName = GetDBAccessValueByText("SYSTEM_NAME")

        If gsSystemName = "" Then
            SetDBAccessValue("SYSTEM_NAME", Application.ProductName)
            gsSystemName = GetDBAccessValueByText("SYSTEM_NAME")
        End If
        gsThemeNo = Val(GetDBAccessValueByText("MATERIAL_SKIN")) '  SkinEngine1.SkinFile = SkinPath() & "vista1.ssk"
        RefreshList()

        If IsRunAdministrator() = True Then
            Me.Text = gsSystemName & "*"
        Else

            Me.Text = gsSystemName
        End If
    End Sub
    Private Sub EditConnection()
        If IsAdmin = False Then
            Exit Sub
        End If

        listCon.Focus()

        If listCon.Items.Count = 0 Then

            PrompNotify(Me.Text, "Connection has not found.", True)
            Exit Sub
        End If

        Try
            Dim getString As String = listCon.Items(listCon.SelectedIndex).ToString

            FrmConnectionSetup.bNew = False
            FrmConnectionSetup.strCon_Name = getString
            FrmConnectionSetup.ShowDialog()
            FrmConnectionSetup.Dispose()
            FrmConnectionSetup = Nothing

        Catch ex As Exception

            PrompNotify(Me.Text, "Please select connection", True)
        End Try

    End Sub
    Private Sub Connection()
        FrmSplash = Nothing
        If listCon.Items.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If

        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
        Try
            Dim getString As String = listCon.Items(listCon.SelectedIndex).ToString
            Try
                cn.Open()
                Dim rd As OleDb.OleDbDataReader = DbAccessReader("select * from tblconnection where connection_name ='" & getString & "' ", cn)
                If rd.Read Then
                    db_server = rd("db_server")
                    db_name = rd("db_name")
                    db_username = rd("db_username")
                    db_password = Decrypt(rd("db_password"))
                    db_port = rd("db_port")
                    gsPOS_Mode = rd("pos_mode")
                    gsPOS_TYPE = NumIsNull(rd("db_datasource_name"))
                    db_Connection = db_server
                    db_Connection_Name = getString
                    SetDBAccessValue("SELECT_CONNECTION", listCon.SelectedIndex)
                Else
                    cn.Close()
                    MessageBoxInfo("Invalid data!")
                    Exit Sub
                End If
                cn.Close()

                '                Dim XSQL As String = "server=" & db_server & ";user id=" & db_username & ";password=" & db_password & ";database=" & db_name & ";port=" & db_port & ";"
                Dim XSQL As String = "DRIVER={MySQL ODBC 8.0 Unicode Driver};SERVER=" & db_server & ";DATABASE=" & db_name & ";UID=" & db_username & ";PASSWORD=" & db_password & ";PORT=" & db_port & ";OPTION=3;"

                mysqlConstr = XSQL
                If gsPOS_Mode = True Then

                    Dim path As String = AppDomain.CurrentDomain.BaseDirectory

                    pfc.AddFontFile($"{path}font\digital-7.ttf")
                End If

                Try

                    If cnn.State = ConnectionState.Open Then
                        cnn.Close()
                    End If
                    CreateUserDSN(db_name, db_server, db_name, db_username, db_password, db_port)
                    fResetConnection()
                    If cnn.State = ConnectionState.Open Then
                        Me.Visible = False
                        fThemeLoad()
                        PrompNotify(Me.Text, $"{getString} connected to {db_server}.", True)
                        FrmSplash.Show()
                    End If
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                    If cnn.State = ConnectionState.Open Then
                        cnn.Close()
                    End If
                Finally

                End Try

            Catch ex As Exception
                MessageBoxWarning(ex.Message)
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
                'MS ACCESS CONNECTION
            End Try

        Catch ex As Exception
            '    MessageBoxExclamation(ex.Message)
        End Try

    End Sub
    Private Sub DeleteConnection()
        If IsAdmin = False Then
            '  MessageBoxWarning("Not accessible. Run as administrator required!")
            Exit Sub
        End If

        If listCon.Items.Count <> 0 Then
            Dim con_name As String = listCon.Items(listCon.SelectedIndex).ToString
            If MessageBoxQuestion("Do you want to Remove this Connection (" & con_name & ")") = True Then
                DbAccessExecute("delete from tblconnection where connection_name = '" & con_name & "'")
                PrompNotify(Me.Text, "Connection deleted.", True)
                RefreshList()
            End If
        End If
    End Sub

    Private Sub ListCon_DoubleClick(sender As Object, e As EventArgs) Handles listCon.DoubleClick
        Connection()
    End Sub

    Private Sub FrmConnectionList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    'Private Sub ListCon_DrawItem(sender As Object, e As DrawItemEventArgs) Handles listCon.DrawItem
    '    Try
    '        e.DrawBackground()
    '        If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
    '            e.Graphics.FillRectangle(HiLiteBrush, e.Bounds)
    '        End If
    '        If e.Index <> -1 Then
    '            Using b As New SolidBrush(e.ForeColor)
    '                e.Graphics.DrawString(listCon.GetItemText(listCon.Items(e.Index)), e.Font, b, e.Bounds)
    '            End Using
    '        End If
    '        e.DrawFocusRectangle()
    '    Catch ex As Exception

    '    End Try

    'End Sub

    Private Sub ListCon_KeyDown(sender As Object, e As KeyEventArgs) Handles listCon.KeyDown

        If e.KeyCode = Keys.Enter Then
            Connection()
        ElseIf e.KeyCode = Keys.Delete Then
            DeleteConnection()
        ElseIf e.KeyCode = Keys.Insert Then
            CreateConnection()
        ElseIf e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.E Then

            EditConnection()

        ElseIf e.KeyCode = Keys.F12 Then




            If IsRunAdministrator() = False Then
                Exit Sub
            End If
            FrmTFU.ShowDialog()
            FrmTFU.Dispose()
            FrmTFU = Nothing
        ElseIf e.KeyCode = Keys.F11 Then
            If IsRunAdministrator() = False Then
                Exit Sub
            End If
            FrmCollectionList.ShowDialog()
            FrmCollectionList.Dispose()
            FrmCollectionList = Nothing
        End If
    End Sub
    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles BtnConnect.Click
        Connection()
    End Sub

    Private Sub ListCon_MouseClick(sender As Object, e As MouseEventArgs) Handles listCon.MouseClick
        If IsAdmin = True Then
            If e.Button = MouseButtons.Right Then

                ContextMenuStrip1.Show(e.Location)
            End If

        End If
    End Sub

    Private Sub NewConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewConnectionToolStripMenuItem.Click
        CreateConnection()
    End Sub

    Private Sub EditConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditConnectionToolStripMenuItem.Click
        EditConnection()
    End Sub

    Private Sub DeleteConnectionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteConnectionToolStripMenuItem.Click
        DeleteConnection()
    End Sub
End Class