Public Class frmItemGroup
    Public Item_BS As BindingSource
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvItemGroup, 39)
        ViewColumn(dgvItemGroup, 39)
    End Sub

    Private Sub frmItemGroup_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvItemGroup, "Select ig.ID,ig.Code,ig.Description,itm.Description as `Item Type` from item_group as ig inner join item_type_map as itm on itm.ID = ig.item_type ", Item_BS)
        ViewColumn(dgvItemGroup, 39)

    End Sub

    Private Sub frmItemGroup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click

        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmItemGroupDetails.This_BS = Item_BS
        frmItemGroupDetails.Dgv = dgvItemGroup
        frmItemGroupDetails.ShowDialog()
        frmItemGroupDetails.Dispose()
        frmItemGroupDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvItemGroup.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If
            frmItemGroupDetails.This_BS = Item_BS
            frmItemGroupDetails.Dgv = dgvItemGroup
            frmItemGroupDetails.ID = dgvItemGroup.Rows(dgvItemGroup.CurrentRow.Index).Cells("ID").Value
            frmItemGroupDetails.ShowDialog()
            frmItemGroupDetails.Dispose()
            frmItemGroupDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvItemGroup.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Are you sure to delete this item group?") = True Then
                SqlExecuted("Delete from item_group where id = '" & dgvItemGroup.Rows(dgvItemGroup.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                fRefresh()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub
    Private Sub dgvItemGroup_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItemGroup.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
        Try

            Dim strFInd As String = ""
            For I As Integer = 0 To dgvItemGroup.Columns.Count - 1
                If dgvItemGroup.Columns(I).Visible = True Then
                    If dgvItemGroup.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then
                        If strFInd = "" Then
                            strFInd = $"[{dgvItemGroup.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvItemGroup.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        End If
                    End If
                End If
            Next

            Item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub
    Private Sub dgvItemGroup_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItemGroup.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
End Class