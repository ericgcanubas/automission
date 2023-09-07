Imports System.Data.Odbc
Public Class frmSecurity
    Dim bSelected As Boolean

    Dim NodesThatMatch As New List(Of TreeNode)
    Dim bSelectCheck As Boolean = False
    Dim bItemCheck As Boolean = False
    Private Sub fCheckInfo(ByVal prUser_ID As String)
        bSelected = True
        fFalseAll(trvMENU)


        Try

            Dim rd As OdbcDataReader = SqlReader("select `NAME` as T from system_security where USER_ID = '" & prUser_ID & "' Limit 300")
            While rd.Read
                fRefreshDataUser(trvMENU, rd("T"), True)
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fCheckInfo(prUser_ID)
            Else
                End
            End If
        End Try
        bSelected = False
    End Sub
    Private Sub fRefreshDataUser(ByVal t As TreeView, ByVal prName As String, ByVal chk As Boolean)
        Dim I As Integer = 0
        For Each tnC As TreeNode In t.Nodes
            If tnC.Text = prName Then
                tnC.Checked = chk
                tnC.ToolTipText = "S"
            End If

            I = I + 1
            If tnC.Nodes.Count > 0 Then
                For Each n As TreeNode In tnC.Nodes
                    If n.Text = prName Then
                        n.Checked = chk
                        n.ToolTipText = "S"
                    End If

                    I = I + 1

                Next
            End If

        Next

    End Sub
    Private Sub fFalseAll(ByVal t As TreeView)
        Dim I As Integer = 0
        For Each tnC As TreeNode In t.Nodes

            tnC.Checked = False
            tnC.ToolTipText = ""

            I = I + 1
            If tnC.Nodes.Count > 0 Then
                For Each n As TreeNode In tnC.Nodes

                    n.Checked = False
                    n.ToolTipText = ""

                    I = I + 1

                Next
            End If

        Next

    End Sub
    Private Sub CheckChildNodes(ByVal parent As TreeNode, checked As Boolean)
        For Each child As TreeNode In parent.Nodes
            child.Checked = checked
            If child.Nodes.Count > 0 Then
                CheckChildNodes(child, checked)
            Else

            End If
        Next
    End Sub
    Private Sub fRefreshUser()

        LoadDataGridView(dgvUser, "Select u.ID,u.`Name` as `Username`,utm.`Description` as `User type` from User as u inner join user_type_map as utm on u.`Type` = utm.ID ")
        dgvUser.Columns.Item("ID").Visible = False
        'DatagridViewMode(dgvUser)
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub

    Private Sub frmSecurity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fColumn()
        fRefreshUser()
        fRefreshList()

    End Sub
    Private Function fCheckBoxColumn(ByVal prName As String) As DataGridViewCheckBoxColumn

        Dim dt As New DataGridViewCheckBoxColumn
        dt.Name = prName
        dt.HeaderText = prName.Replace("_", " ")
        Return dt
    End Function
    Private Sub fColumn()

        DatagridViewMode(dgvAccessControl)
        With dgvAccessControl.Columns
            .Clear()
            .Add("SUB_ID", "SUB_ID")
            .Item("SUB_ID").Visible = False
            .Add("Menu", "Menu")
            .Item("Menu").Width = 200
            .Add(fCheckBoxColumn("New"))
            .Item("New").Width = 70
            .Add(fCheckBoxColumn("Edit"))
            .Item("Edit").Width = 70
            .Add(fCheckBoxColumn("Delete"))
            .Item("Delete").Width = 70
            .Add(fCheckBoxColumn("Find"))
            .Item("Find").Width = 70
            .Add(fCheckBoxColumn("Print_Preview"))
            .Item("Print_Preview").Width = 70
            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False
        End With



    End Sub

    Private Sub fRefreshList()
        Try
            Dim i As Integer = 0
            Dim rd As OdbcDataReader = SqlReader("select * from tblmenu ")
            trvMENU.BeginUpdate()
            While rd.Read

                trvMENU.Nodes.Add(rd("MENU_ID"), rd("DESCRIPTION"))
                trvMENU.Nodes.Item(i).NodeFont = New Font(trvMENU.Font, FontStyle.Bold)

                Dim rd_sub As OdbcDataReader = SqlReader("select ml.sub_id,sm.description,sm.access_control from  tblmenu_list as ml inner join tblsub_menu as sm on sm.sub_id = ml.sub_id  where  ml.menu_id = '" & rd("menu_id") & "' order by sm.description")
                While rd_sub.Read
                    Dim T As Integer = NumIsNull(rd_sub("access_control"))
                    trvMENU.Nodes(i).Nodes.Add(rd_sub("sub_id"), rd_sub("description"), T)
                End While
                rd_sub.Close()

                i = i + 1

            End While
            trvMENU.EndUpdate()
            rd.Close()

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshList()
            Else
                End
            End If
        End Try


    End Sub


    Private Sub frefreshAccessControl()
        'dgvUser.Focus()
        dgvAccessControl.Rows.Clear()
        Dim user_id As Integer = dgvUser.Rows(dgvUser.CurrentRow.Index).Cells(0).Value
        Try

            Dim rd As OdbcDataReader = SqlReader("select u.*,s.description,s.SUB_ID as 'IDx' from tblsub_menu as s inner join tblmenu_list ml on ml.sub_id = s.sub_id left outer join user_security_access as u  on u.sub_id = s.sub_id and u.user_id = '" & user_id & "' where s.access_control = '1' order by ml.menu_id,s.description")
            While rd.Read
                dgvAccessControl.Rows.Add(NumIsNull(rd("IDx")), TextIsNull(rd("description")), NumIsNull(rd("NEW")), NumIsNull(rd("EDIT")), NumIsNull(rd("DELETE")), NumIsNull(rd("FIND")), NumIsNull(rd("PRINT_PREVIEW")), IIf(IsDBNull(rd("NEW")), "A", "S"))
            End While
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                frefreshAccessControl()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub fAutoAccessChange(ByVal prSUB_ID As Integer, ByVal bBool As Boolean)

        For i As Integer = 0 To dgvAccessControl.Rows.Count - 1
            Dim dt As DataGridViewRow = dgvAccessControl.Rows(i)
            If dt.Cells("SUB_ID").Value = prSUB_ID Then
                If bBool = True Then
                    dt.Cells("New").Value = chkNew.Checked
                    dt.Cells("Edit").Value = chkEdit.Checked
                    dt.Cells("Delete").Value = chkDelete.Checked
                    dt.Cells("Find").Value = chkFind.Checked
                    dt.Cells("Print_Preview").Value = chkPrint_Preview.Checked
                Else
                    dt.Cells("New").Value = bBool
                    dt.Cells("Edit").Value = bBool
                    dt.Cells("Delete").Value = bBool
                    dt.Cells("Find").Value = bBool
                    dt.Cells("Print_Preview").Value = bBool
                End If
                dt.Cells("status").Value = IIf(dt.Cells("status").Value = "C", "C", IIf(dt.Cells("status").Value = "S", "C", "A"))

            End If
        Next

    End Sub
    Private Sub trvMENU_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles trvMENU.AfterCheck
        If bSelectCheck = True Then Exit Sub
        If bSelected = True Then Exit Sub

        'after a node checked/unchecked, all its children should be checked/unchecked
        Dim Pnode As TreeNode = e.Node
            For Each cnode As TreeNode In Pnode.Nodes
                cnode.Checked = Pnode.Checked
            Next

            ' when all child nodes are checked/unchecked, the parent should be checked/unchecked
            ' if you don't need this feature, just remove it, please.
            Dim PPnode As TreeNode = Pnode.Parent
            If PPnode Is Nothing Then
                Exit Sub 'the current node is the root node
            End If

            If Pnode.Checked = True Then
                While PPnode IsNot Nothing
                RemoveHandler PPnode.TreeView.AfterCheck, AddressOf trvMENU_AfterCheck
                PPnode.Checked = True
                AddHandler PPnode.TreeView.AfterCheck, AddressOf trvMENU_AfterCheck
                PPnode = PPnode.Parent
                End While
            Else
                UncheckParent(PPnode)
            End If


            If e.Node.Parent IsNot Nothing AndAlso e.Node.Parent.[GetType]() = GetType(TreeNode) Then


                If chkAUTO.Checked = True Then
                    If e.Node.ImageIndex < 0 And e.Node.Checked = True Then
                        fAutoAccessChange(e.Node.Name, True)
                    ElseIf e.Node.ImageIndex < 0 And e.Node.Checked = False Then
                        fAutoAccessChange(e.Node.Name, False)
                    End If
                End If



            End If




    End Sub


    Public Sub UncheckParent(ByVal PPnode As TreeNode)
        If PPnode Is Nothing Then
            Exit Sub
        End If
        For Each node As TreeNode In PPnode.Nodes
            If node.Checked <> False Then
                'there is a different status node 
                Exit Sub
            End If
        Next
        RemoveHandler PPnode.TreeView.AfterCheck, AddressOf trvMENU_AfterCheck
        PPnode.Checked = False
        AddHandler PPnode.TreeView.AfterCheck, AddressOf trvMENU_AfterCheck
        'check the grandpa
        UncheckParent(PPnode.Parent)

    End Sub
    Private Sub tsSave_Click(sender As Object, e As EventArgs) Handles tsSave.Click
        Try
            Dim I As Integer = 0
            Dim sQuery As String = ""
            Dim User_ID As String = dgvUser.Rows(dgvUser.CurrentRow.Index).Cells("ID").Value
            For Each tnC As TreeNode In trvMENU.Nodes
                If tnC.Checked = True Then
                    If tnC.ToolTipText = "S" Then

                    Else
                        'INSERT
                        sQuery = sQuery & fAddSystemSecurity(tnC.Text, User_ID)
                    End If

                Else
                    If tnC.ToolTipText = "S" Then
                        'DELETE
                        sQuery = sQuery & fDeleteSystemSecurity(tnC.Text, User_ID)
                    End If
                End If


                I = I + 1
                If tnC.Nodes.Count > 0 Then
                    For Each n As TreeNode In tnC.Nodes
                        If n.Checked = True Then
                            If n.ToolTipText = "S" Then

                            Else
                                'INSERT
                                sQuery = sQuery & fAddSystemSecurity(n.Text, User_ID)
                            End If

                        Else
                            If n.ToolTipText = "S" Then
                                'DELETE
                                sQuery = sQuery & fDeleteSystemSecurity(n.Text, User_ID)
                            End If
                        End If

                        I = I + 1

                    Next
                End If

            Next
            If sQuery <> "" Then
                SqlExecuted(sQuery)
            End If


            fUpdateDataAccessControl()

            fCheckInfo(User_ID)
            frefreshAccessControl()
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Sub fUpdateDataAccessControl()
        'Saving
        Dim User_ID As String = dgvUser.Rows(dgvUser.CurrentRow.Index).Cells("ID").Value
        Dim sQuery As String = ""
        For i As Integer = 0 To dgvAccessControl.Rows.Count - 1

            Dim dt As DataGridViewRow = dgvAccessControl.Rows(i)


            If dt.Cells("STATUS").Value = "A" Then
                'INSERT
                sQuery = "INSERT INTO user_security_access SET `SUB_ID`='" & dt.Cells("SUB_ID").Value & "',`USER_ID`='" & User_ID & "',`NEW`='" & Val(dt.Cells("NEW").Value) & "',`EDIT`='" & Val(dt.Cells("EDIT").Value) & "',`DELETE`='" & Val(dt.Cells("DELETE").Value) & "',`FIND`='" & Val(dt.Cells("FIND").Value) & "',`PRINT_PREVIEW`='" & Val(dt.Cells("PRINT_PREVIEW").Value) & "',`MODIFY`=NOW();"
            ElseIf dt.Cells("STATUS").Value = "C" Then
                'UPDATE 
                sQuery = "UPDATE user_security_access SET `NEW`='" & Val(dt.Cells("NEW").Value) & "',`EDIT`='" & Val(dt.Cells("EDIT").Value) & "',`DELETE`='" & Val(dt.Cells("DELETE").Value) & "',`FIND`='" & Val(dt.Cells("FIND").Value) & "',`PRINT_PREVIEW`='" & Val(dt.Cells("PRINT_PREVIEW").Value) & "',`MODIFY`=NOW() WHERE `SUB_ID`='" & dt.Cells("SUB_ID").Value & "' and `USER_ID`='" & User_ID & "';"
            End If

            SqlExecuted(sQuery)

        Next

    End Sub
    Private Function fCheckingAccessControl(ByVal prSub_ID As String, ByVal prUser_ID As String) As Boolean
        Dim b As Boolean = False
        Dim rd As OdbcDataReader = SqlReader("select * from user_security_access where sub_id = '" & prSub_ID & "' and user_id ='" & prUser_ID & "' limit 1")
        If rd.Read Then
            b = True
        End If
        rd.Close()
        Return b
    End Function
    Private Function fAddSystemSecurity(ByVal prName As String, ByVal prUser_Id As String) As String

        Return "INSERT INTO system_security SET `NAME` = '" & prName & "',USER_ID = '" & prUser_Id & "';"

    End Function
    Private Function fDeleteSystemSecurity(ByVal prName As String, ByVal prUser_Id As String) As String

        Return "DELETE FROM system_security WHERE `NAME` = '" & prName & "' and USER_ID = '" & prUser_Id & "';"

    End Function

    Private Sub dgvUser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellContentClick

    End Sub

    Private Sub dgvUser_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUser.SelectionChanged
        Try
            If dgvUser.Rows.Count = 0 Then
                fFalseAll(trvMENU)
                Exit Sub
            End If
            fCheckInfo(dgvUser.Rows(dgvUser.CurrentRow.Index).Cells(0).Value)
            frefreshAccessControl()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvAccessControl_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccessControl.CellClick
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Then Exit Sub

        If e.ColumnIndex > 1 And e.ColumnIndex < 7 Then
            Dim t As Boolean = dgvAccessControl.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            dgvAccessControl.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = IIf(t = True, False, True)
            bSelectCheck = True
            With dgvAccessControl.Rows(e.RowIndex)
                If .Cells(2).Value = False And .Cells(3).Value = False And .Cells(4).Value = False And .Cells(5).Value = False And .Cells(6).Value = False Then
                    bItemCheck = False
                Else
                    bItemCheck = True
                End If
                .Cells(7).Value = IIf(.Cells(7).Value = "C", "C", IIf(.Cells(7).Value = "S", "C", "A"))
            End With
            SearchTheTreeView(trvMENU, dgvAccessControl.Rows(e.RowIndex).Cells(1).Value)

        Else

            SearchTheTreeView(trvMENU, dgvAccessControl.Rows(e.RowIndex).Cells(1).Value)
        End If
        bSelectCheck = False
        bItemCheck = False
    End Sub



    Private Function SearchTheTreeView(ByVal TV As TreeView, ByVal TextToFind As String) As TreeNode
        '  Empty previous
        NodesThatMatch.Clear()

        ' Keep calling RecursiveSearch
        For Each TN As TreeNode In TV.Nodes
            If TN.Text = TextToFind Then
                NodesThatMatch.Add(TN)
            End If

            RecursiveSearch(TN, TextToFind)
        Next

        If NodesThatMatch.Count > 0 Then
            Return NodesThatMatch(0)
        Else
            Return Nothing
        End If

    End Function

    Private Sub RecursiveSearch(ByVal treeNode As TreeNode, ByVal TextToFind As String)

        ' Keep calling the test recursively.
        For Each TN As TreeNode In treeNode.Nodes
            If TN.Text = TextToFind Then
                NodesThatMatch.Add(TN)
                trvMENU.SelectedNode = TN
                If bSelectCheck = True Then
                    TN.Checked = bItemCheck
                End If

                trvMENU.Focus()
                Exit Sub
            End If

            RecursiveSearch(TN, TextToFind)
        Next
    End Sub

    Private Sub trvMENU_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvMENU.AfterSelect

    End Sub

    Private Sub dgvAccessControl_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccessControl.CellContentClick

    End Sub

    Private Sub chkAUTO_CheckedChanged(sender As Object, e As EventArgs) Handles chkAUTO.CheckedChanged
        chkNew.Enabled = chkAUTO.Checked
        chkEdit.Enabled = chkAUTO.Checked
        chkDelete.Enabled = chkAUTO.Checked
        chkFind.Enabled = chkAUTO.Checked
        chkPrint_Preview.Enabled = chkAUTO.Checked

    End Sub



    Private Sub SaveConfigOnUserTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveConfigOnUserTypeToolStripMenuItem.Click
        'Update Type
        If dgvUser.Rows.Count = 0 Then
            MessageBoxInfo("User not found")
            Exit Sub
        End If
        Dim user_id As Integer = dgvUser.Rows(dgvUser.CurrentRow.Index).Cells(0).Value
        Dim user_type As Integer = GetNumberFieldValue("user", "ID", user_id, "TYPE")

        If MessageBoxQuestion("Do you want to update user type " & GetStringFieldValue("user_type_map", "ID", user_type, "DESCRIPTION") & " base on user " & dgvUser.Rows(dgvUser.CurrentRow.Index).Cells(1).Value) = True Then
            fSecurityUpdate(False, True, user_id, user_type)
            
            If MessageBoxQuestion("Do you want to update all user in this user type " & GetStringFieldValue("user_type_map", "ID", user_type, "DESCRIPTION")) = True Then
                fSecurityUpdate(True, False, "", user_type)

            End If
        End If
    End Sub

    Private Sub UpdateAllUserTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateAllUserTypeToolStripMenuItem.Click
        'All User
        'Update Type
        If dgvUser.Rows.Count = 0 Then
            MessageBoxInfo("User not found")
            Exit Sub
        End If
        Dim user_id As Integer = dgvUser.Rows(dgvUser.CurrentRow.Index).Cells(0).Value
        Dim user_type As Integer = GetNumberFieldValue("user", "ID", user_id, "TYPE")


        If MessageBoxQuestion("Do you want to update all user base on user type = " & GetStringFieldValue("user_type_map", "ID", user_type, "DESCRIPTION")) = True Then
            fSecurityUpdate(True, False, "", user_type)
        End If


    End Sub

    Private Sub frmSecurity_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvAccessControl)
        ViewNotSort(dgvUser)
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        fGetQuickFind(dgvUser, txtFind.Text)
    End Sub

    Private Sub txtFind2_TextChanged(sender As Object, e As EventArgs) Handles txtFind2.TextChanged
        fGetQuickFind(dgvAccessControl, txtFind2.Text)
    End Sub
End Class