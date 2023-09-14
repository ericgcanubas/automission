Public Class FrmSubMenuGroup
    Private Sub FrmSubMenuGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshMenu()
        RefreshSubMenuGroup()
    End Sub
    Private Sub RefreshMenu()
        LoadDataGridView(dgvMenu, "Select MENU_ID as `ID`,DESCRIPTION from tblMenu where MENU_ID <> '5' ")
        If dgvMenu.Rows.Count <> 0 Then
            RefreshSubMenu()
        End If
    End Sub
    Private Sub RefreshSubMenu()
        Dim i As Integer = 0
        If dgvMenu.Rows.Count <> 0 Then
            i = dgvMenu.Rows(dgvMenu.CurrentRow.Index).Cells(0).Value
        End If
        LoadDataGridView(dgvSubMenu, "select s.SUB_ID as `ID`,s.DESCRIPTION from tblsub_menu as s inner join tblmenu_list as ml on ml.sub_id = s.sub_id where ml.menu_id = '" & i & "' order by s.sub_id ")
    End Sub
    Private Sub DgvMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellContentClick
        RefreshSubMenu()
    End Sub

    Private Sub DgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
        RefreshSubMenu()
    End Sub
    Private Sub RefreshSubMenuGroup()
        LoadDataGridView(dgvSUB_MENU_GROUP, "select GROUP_ID as `ID`,DESCRIPTION from tblsub_group")
        If dgvSUB_MENU_GROUP.Rows.Count <> 0 Then
            RefreshSMGD()
        End If
    End Sub
    Private Sub RefreshSMGD()
        Dim i As Integer = 0
        If dgvSUB_MENU_GROUP.Rows.Count <> 0 Then
            i = dgvSUB_MENU_GROUP.Rows(dgvSUB_MENU_GROUP.CurrentRow.Index).Cells(0).Value
        End If

        LoadDataGridView(dgvSUB_MENU_GROUP_DETAILS, "select sm.ID,s.sub_ID as`SUB ID`,s.DESCRIPTION  from tblsub_group_details as sm inner join tblsub_menu as s on s.sub_id = sm.sub_id where sm.group_id = '" & i & "' order by sm.ID")

    End Sub

    Private Sub DgvSUB_MENU_GROUP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSUB_MENU_GROUP.CellContentClick
        RefreshSMGD()
    End Sub

    Private Sub DgvSUB_MENU_GROUP_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSUB_MENU_GROUP.SelectionChanged
        RefreshSMGD()
    End Sub
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SqlExecuted("INSERT INTO tblsub_group_details SET GROUP_ID = '" & dgvSUB_MENU_GROUP.Rows(dgvSUB_MENU_GROUP.CurrentRow.Index).Cells(0).Value & "', SUB_ID = '" & dgvSubMenu.Rows(dgvSubMenu.CurrentRow.Index).Cells(0).Value & "'")
        RefreshSMGD()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        SqlExecuted("DELETE FROM tblsub_group_details Where  ID = '" & dgvSUB_MENU_GROUP_DETAILS.Rows(dgvSUB_MENU_GROUP_DETAILS.CurrentRow.Index).Cells(0).Value & "'")
        RefreshSMGD()
    End Sub
End Class