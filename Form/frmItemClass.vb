Public Class FrmItemClass
    Dim item_BS As BindingSource
    Private Sub FrmItemClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        LoadDataGridViewBinding(dgvItemClass, "Select ID,Code,Description from item_class ", item_BS)
        ViewColumn(dgvItemClass, 37)
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvItemClass, 37)
        ViewColumn(dgvItemClass, 37)
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If
        FrmItemClassDetails.This_BS = item_BS
        FrmItemClassDetails.Dgv = dgvItemClass
        FrmItemClassDetails.ShowDialog()
        FrmItemClassDetails.Dispose()
        FrmItemClassDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvItemClass.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            FrmItemClassDetails.This_BS = item_BS
            FrmItemClassDetails.Dgv = dgvItemClass
            FrmItemClassDetails.ID = dgvItemClass.Rows(dgvItemClass.CurrentRow.Index).Cells("ID").Value
            FrmItemClassDetails.ShowDialog()
            FrmItemClassDetails.Dispose()
            FrmItemClassDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try

    End Sub
    Private Sub DgvItemClass_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItemClass.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvItemClass.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Are you sure to delete this item class") = True Then
                SqlExecuted("delete from item_class where id = '" & dgvItemClass.Rows(dgvItemClass.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub
    Private Sub SearchLoad()
        Try

            Dim strFInd As String = ""
            For I As Integer = 0 To dgvItemClass.Columns.Count - 1

                If dgvItemClass.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then

                        If strFInd = "" Then
                            strFInd = $"[{dgvItemClass.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvItemClass.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If
            Next
            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub



    Private Sub DgvItemClass_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItemClass.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub



    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub

    Private Sub TsTxtSearch_TextChanged_1(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub
End Class