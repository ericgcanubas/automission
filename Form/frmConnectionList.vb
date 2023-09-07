

Public Class frmConnectionList


    Dim HiLiteBrush As New SolidBrush(Color.FromKnownColor(KnownColor.LightSkyBlue))

    Private Sub fRefreshList()

        Dim cn As New OleDb.OleDbConnection(fMS_Con())

        Dim temp_index As Integer = 0
        Try
            cn.Open()
            If listCon.Items.Count <> 0 Then
                temp_index = listCon.SelectedIndex
            End If

            listCon.Items.Clear()
            Dim rd As OleDb.OleDbDataReader = fMSgetReader("select connection_name from tblconnection", cn)
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
            listCon.SelectedIndex = Val(fGet_System_VALUE("SELECT_CONNECTION"))
        Catch ex As Exception

        End Try


    End Sub

    'Private Sub ftemp_connection()

    '    Dim cn As New OleDb.OleDbConnection(fMS_Con)
    '    Try
    '        cn.Open()
    '        cn.Close()
    '    Catch ex As Exception
    '        MessageBoxExclamation("Something Wrong the Temporaty Data")
    '        If cn.State = ConnectionState.Open Then
    '            cn.Close()
    '        End If
    '    End Try
    'End Sub

    Private Sub fCreate()
        If fAdministrator() = False Then
            Exit Sub
        End If
        frmConnectionSetup.bNew = True
        frmConnectionSetup.ShowDialog()
        frmConnectionSetup.Dispose()
        frmConnectionSetup = Nothing
        fRefreshList()
    End Sub
    Private Sub frmConnectionList_Load(sender As Object, e As EventArgs) Handles Me.Load

        gsSYSTEM_UPGRADE = Val(fGet_System_VALUE("SYSTEM_UPGRADE"))

        gsSystemName = fGet_System_VALUE("SYSTEM_NAME")

        If gsSystemName = "" Then
            fSET_SYSTEM_VALUE("SYSTEM_NAME", Application.ProductName)
            gsSystemName = fGet_System_VALUE("SYSTEM_NAME")
        End If



        gsThemeNo = Val(fGet_System_VALUE("MATERIAL_SKIN")) '  SkinEngine1.SkinFile = SkinPath() & "vista1.ssk"


        fRefreshList()

        If fAdministrator() = True Then
            Me.Text = gsSystemName & "*"
        Else

            Me.Text = gsSystemName
        End If
    End Sub
    Private Sub fEdit()
        If fAdministrator() = False Then

            Exit Sub
        End If

        listCon.Focus()

        If listCon.Items.Count = 0 Then

            PrompNotify(Me.Text, "Connection has not found.", True)
            Exit Sub
        End If

        Try
            Dim getString As String = listCon.Items(listCon.SelectedIndex).ToString

            frmConnectionSetup.bNew = False
            frmConnectionSetup.strCon_Name = getString
            frmConnectionSetup.ShowDialog()
            frmConnectionSetup.Dispose()
            frmConnectionSetup = Nothing

        Catch ex As Exception

            PrompNotify(Me.Text, "Please select connection", True)
        End Try

    End Sub
    Private Sub fConnect()
        frmSplash = Nothing
        If listCon.Items.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If

        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            Dim getString As String = listCon.Items(listCon.SelectedIndex).ToString
            Try
                cn.Open()
                Dim rd As OleDb.OleDbDataReader = fMSgetReader("select * from tblconnection where connection_name ='" & getString & "' ", cn)
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
                    fSET_SYSTEM_VALUE("SELECT_CONNECTION", listCon.SelectedIndex)
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
                        frmSplash.Show()
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
    Private Sub fDelete()
        If fAdministrator() = False Then
            '  MessageBoxWarning("Not accessible. Run as administrator required!")
            Exit Sub
        End If

        If listCon.Items.Count <> 0 Then
            Dim con_name As String = listCon.Items(listCon.SelectedIndex).ToString
            If MessageBoxQuestion("Do you want to Remove this Connection (" & con_name & ")") = True Then
                fMS_execute("delete from tblconnection where connection_name = '" & con_name & "'")
                PrompNotify(Me.Text, "Connection deleted.", True)
                fRefreshList()
            End If
        End If
    End Sub

    Private Sub listCon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listCon.SelectedIndexChanged

    End Sub

    Private Sub listCon_DoubleClick(sender As Object, e As EventArgs) Handles listCon.DoubleClick
        fConnect()
    End Sub

    Private Sub frmConnectionList_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub listCon_DrawItem(sender As Object, e As DrawItemEventArgs) Handles listCon.DrawItem
        Try
            e.DrawBackground()
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(HiLiteBrush, e.Bounds)
            End If
            If e.Index <> -1 Then
                Using b As New SolidBrush(e.ForeColor)
                    e.Graphics.DrawString(listCon.GetItemText(listCon.Items(e.Index)), e.Font, b, e.Bounds)
                End Using
            End If
            e.DrawFocusRectangle()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub listCon_KeyDown(sender As Object, e As KeyEventArgs) Handles listCon.KeyDown

        If e.KeyCode = Keys.Enter Then
            fConnect()
        ElseIf e.KeyCode = Keys.Delete Then
            fDelete()
        ElseIf e.KeyCode = Keys.Insert Then
            fCreate()
        ElseIf e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.E Then

            fEdit()

        ElseIf e.KeyCode = Keys.F12 Then




            If fAdministrator() = False Then
                Exit Sub
            End If
            frmTFU.ShowDialog()
            frmTFU.Dispose()
            frmTFU = Nothing
        ElseIf e.KeyCode = Keys.F11 Then
            If fAdministrator() = False Then
                Exit Sub
            End If
            frmCollectionList.ShowDialog()
            frmCollectionList.Dispose()
            frmCollectionList = Nothing
        End If
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub xTarget_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub xTarget_DoubleClick(sender As Object, e As EventArgs)

        Dim N As Integer = Val(fGet_System_VALUE("MATERIAL_SKIN")) + 1

        If N = 6 Then
            N = 0

        End If
        fSET_SYSTEM_VALUE("MATERIAL_SKIN", N)
        gsThemeNo = Val(fGet_System_VALUE("MATERIAL_SKIN")) '  SkinEngine1.SkinFile = SkinPath() & "vista1.ssk"

    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        fConnect()
    End Sub

    Private Sub BunifuCustomLabel1_Click(sender As Object, e As EventArgs) Handles BunifuCustomLabel1.Click

    End Sub
End Class