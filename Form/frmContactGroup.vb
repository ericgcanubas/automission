Public Class FrmContactGroup
    Dim item_BS As BindingSource
    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm

        RefreshData()
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If
        FrmContactGroupDetails.This_BS = item_BS
        FrmContactGroupDetails.dgv = dgvContactGroup
        FrmContactGroupDetails.ShowDialog()
        FrmContactGroupDetails.Dispose()
        FrmContactGroupDetails = Nothing

    End Sub
    Private Sub RefreshData()

        LoadDataGridViewBinding(dgvContactGroup, "SELECT cg.ID,cg.`Code`,cg.`Description`, cm.`DESCRIPTION` AS `Type` FROM contact_group AS cg INNER JOIN contact_type_map AS cm ON cm.`ID` = cg.`TYPE`", item_BS)
        With dgvContactGroup.Columns
            .Item(0).Visible = False
        End With
        ViewColumn(dgvContactGroup, 32)
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click

        If dgvContactGroup.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If
            dgvContactGroup.Focus()
            Dim i As Integer = dgvContactGroup.CurrentRow.Index
            Dim dID As String = dgvContactGroup.Rows.Item(i).Cells(0).Value
            FrmContactGroupDetails.This_BS = item_BS
            FrmContactGroupDetails.dgv = dgvContactGroup
            FrmContactGroupDetails.ID = dID
            FrmContactGroupDetails.ShowDialog()
            FrmContactGroupDetails.Dispose()
            FrmContactGroupDetails = Nothing

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvContactGroup.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If
            dgvContactGroup.Focus()
            Dim i As Integer = dgvContactGroup.CurrentRow.Index
            Dim dID As String = dgvContactGroup.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvContactGroup.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact_group where id='" & dID & "' limit 1")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception

        End Try
    End Sub



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvContactGroup, 32)
        ViewColumn(dgvContactGroup, 32)
    End Sub

    Private Sub DgvContactGroup_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContactGroup.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub


    Private Sub Searchload()
        Try
            Dim strFInd As String = ""

            For I As Integer = 0 To dgvContactGroup.Columns.Count - 1

                If dgvContactGroup.Columns(I).Visible = True Then

                    If dgvContactGroup.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvContactGroup.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvContactGroup.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next



            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        Searchload()
    End Sub
    Private Sub DgvContactGroup_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvContactGroup.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        Searchload()
    End Sub

    Private Sub TsReload_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub
End Class