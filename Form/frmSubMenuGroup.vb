Public Class frmSubMenuGroup
    Private Sub frmSubMenuGroup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fRefreshMenu()
        fRefreshSubMenuGroup()
    End Sub
    Private Sub fRefreshMenu()
        LoadDataGridView(dgvMenu, "Select MENU_ID as `ID`,DESCRIPTION from tblMenu where MENU_ID <> '5' ")
        If dgvMenu.Rows.Count <> 0 Then

            fRefreshSubMenu()
        End If
    End Sub


    Private Sub fRefreshSubMenu()
        Dim i As Integer = 0
        If dgvMenu.Rows.Count <> 0 Then
            i = dgvMenu.Rows(dgvMenu.CurrentRow.Index).Cells(0).Value

        End If

        LoadDataGridView(dgvSubMenu, "select s.SUB_ID as `ID`,s.DESCRIPTION from tblsub_menu as s inner join tblmenu_list as ml on ml.sub_id = s.sub_id where ml.menu_id = '" & i & "' order by s.sub_id ")

    End Sub

    Private Sub dgvSubMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubMenu.CellContentClick

    End Sub

    Private Sub dgvMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellContentClick
        fRefreshSubMenu()
    End Sub

    Private Sub dgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
        fRefreshSubMenu()

    End Sub
    Private Sub fRefreshSubMenuGroup()
        LoadDataGridView(dgvSUB_MENU_GROUP, "select GROUP_ID as `ID`,DESCRIPTION from tblsub_group")
        If dgvSUB_MENU_GROUP.Rows.Count <> 0 Then
            fRefreshSMGD()
        End If

    End Sub
    Private Sub fRefreshSMGD()
        Dim i As Integer = 0
        If dgvSUB_MENU_GROUP.Rows.Count <> 0 Then
            i = dgvSUB_MENU_GROUP.Rows(dgvSUB_MENU_GROUP.CurrentRow.Index).Cells(0).Value
        Else
            i = 0
        End If

        LoadDataGridView(dgvSUB_MENU_GROUP_DETAILS, "select sm.ID,s.sub_ID as`SUB ID`,s.DESCRIPTION  from tblsub_group_details as sm inner join tblsub_menu as s on s.sub_id = sm.sub_id where sm.group_id = '" & i & "' order by sm.ID")

    End Sub

    Private Sub dgvSUB_MENU_GROUP_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSUB_MENU_GROUP.CellContentClick
        fRefreshSMGD()
    End Sub

    Private Sub dgvSUB_MENU_GROUP_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSUB_MENU_GROUP.SelectionChanged
        fRefreshSMGD()
    End Sub

    Private Sub frmSubMenuGroup_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub dgvSUB_MENU_GROUP_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSUB_MENU_GROUP.RowEnter
        ' fRefreshSubMenuGroup()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        SqlExecuted("INSERT INTO tblsub_group_details SET GROUP_ID = '" & dgvSUB_MENU_GROUP.Rows(dgvSUB_MENU_GROUP.CurrentRow.Index).Cells(0).Value & "', SUB_ID = '" & dgvSubMenu.Rows(dgvSubMenu.CurrentRow.Index).Cells(0).Value & "'")
        fRefreshSMGD()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        SqlExecuted("DELETE FROM tblsub_group_details Where  ID = '" & dgvSUB_MENU_GROUP_DETAILS.Rows(dgvSUB_MENU_GROUP_DETAILS.CurrentRow.Index).Cells(0).Value & "'")
        fRefreshSMGD()
    End Sub
End Class