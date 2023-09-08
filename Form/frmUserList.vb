
Public Class FrmUserList

    Dim Item_BS As BindingSource

    Private Sub frmUserList_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefreshDataGrid()
    End Sub

    Private Sub fRefreshDataGrid()

        LoadDataGridViewBinding(dgvUser, "SELECT 
  u.`ID`,
  u.`Name`,
  u.`Description`,
  u.`PWD_NEVER_EXPIRES` as `Password Never Expires`,
  utm.`DESCRIPTION` AS `Type`,
 us.`DESCRIPTION` AS `Status`,
  c.`NAME` AS `Contact` ,
  u1.`NAME` AS `Registered By`,
  u.`REGISTERED_ON` as `Registered On`,
  u.`LOCKOUT_COUNTER` as `Lockout Counter`,
  u.`LOCKOUT_ON` as `Lockout On`,
  u.`EXPIRATION_DATE` as `Expiration Date`,
  u.`LOGIN_FAILED_ON` as `Login Failed  On`
FROM
  `user` AS u 
  LEFT OUTER JOIN contact AS c 
    ON c.id = u.`CONTACT_ID` 
    LEFT OUTER JOIN user_status_map AS us
    ON us.`ID` = u.`STATUS`
    LEFT OUTER JOIN `user` AS u1
ON u1.`ID` = u.`REGISTERED_BY_ID`
LEFT OUTER JOIN  user_type_map AS utm
ON utm.`ID` = u.`TYPE` ", Item_BS)

        With dgvUser
            .Columns(0).Width = 30
            .Columns(1).Width = 150
            .Columns(2).Width = 150
            .Columns(3).Width = 60
            .Columns(4).Width = 50
            .Columns(5).Width = 60
            .Columns(6).Width = 100
            .Columns(7).Width = 100
            .Columns(8).Width = 80
            .Columns(9).Width = 80
            .Columns(10).Width = 60
            .Columns(11).Width = 70
            .Columns(12).Width = 50

        End With


        ViewColumn(dgvUser, 11)
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvUser, 11)
        ViewColumn(dgvUser, 11)
    End Sub


    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefreshDataGrid()
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        With frmUserDetails

            .gsDgv = dgvUser
            .gsBS = Item_BS
            .IsNew = True
            .ShowDialog()
            .Dispose()
        End With
        frmUserDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvUser.Rows.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If
        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            dgvUser.Focus()
            Dim i As Integer = dgvUser.CurrentRow.Index
            Dim dID As String = dgvUser.Rows.Item(i).Cells(0).Value

            frmUserDetails.IsNew = False
            frmUserDetails.ID = dID
            frmUserDetails.gsDgv = dgvUser
            frmUserDetails.gsBS = Item_BS
            frmUserDetails.ShowDialog()
            frmUserDetails.Dispose()
            frmUserDetails = Nothing

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub dgvUser_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellContentClick

    End Sub

    Private Sub dgvUser_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUser.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvUser.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If fACCESS_DELETE(Me) = False Then

                Exit Sub
            End If
            dgvUser.Focus()
            Dim i As Integer = dgvUser.CurrentRow.Index
            Dim dID As String = dgvUser.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvUser.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete this user: " & dName & "?") = True Then
                SqlExecuted($"DELETE FROM user_sessions where user_id ='{dID}'")
                SqlExecuted($"delete from user_default where user_id ='{dID}' ")
                SqlExecuted($"delete from user_security_access where user_id ='{dID}' ")
                SqlExecuted($"delete from user_access_control where user_id ='{dID}' ")
                SqlExecuted($"delete from system_security where user_id ='{dID}' ")
                SqlExecuted("Delete From user where id='" & dID & "' limit 1")
                DeleteNotify(Me)
                fRefreshDataGrid()
            End If

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub UserDefaultToolStripMenuItem_Click(sender As Object, e As EventArgs)



    End Sub
    Private Sub fSearchload()
        Try

            Dim strFInd As String = ""


            For I As Integer = 0 To dgvUser.Columns.Count - 1

                If dgvUser.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvUser.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvUser.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next




            Item_BS.Filter = strFInd
        Catch ex As Exception

        End Try

    End Sub
    Private Sub frmUserList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvUser)
    End Sub

    Private Sub tsTxtSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsbtnSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub UserSecurityToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub UpdateAccessToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateAccessToolStripMenuItem.Click
        If dgvUser.Rows.Count = 0 Then
            MessageBoxInfo("User not selected")
            Exit Sub
        End If

        Try
            dgvUser.Select()

            frmUserSecurity.gsSelect_User_ID = dgvUser.CurrentRow.Cells("ID").Value
            frmUserSecurity.gsSelect_UserName = dgvUser.CurrentRow.Cells("Name").Value
            frmUserSecurity.ShowDialog()
            frmUserSecurity.Dispose()
            frmUserSecurity = Nothing
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub DefaultToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultToolStripMenuItem.Click
        With frmUserDefault
            Dim i As Integer = dgvUser.CurrentRow.Index
            Dim dID As String = dgvUser.Rows.Item(i).Cells(0).Value
            .ID = dID
            .ShowDialog()
            .Dispose()
        End With
        frmUserDefault = Nothing
    End Sub
End Class