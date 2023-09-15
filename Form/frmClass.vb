Public Class FrmClass
    Dim item_BS As BindingSource

    Private Sub FrmClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshLoad()
    End Sub

    Private Sub RefreshLoad()
        GS_LoadDataGridViewBinding(dgvCLASS, "Select ID,`Name`, if(`Inactive`=0,'No','Yes') as `Inactive` from Class ", item_BS)
        dgvCLASS.Columns(0).Visible = False
        ViewColumn(dgvCLASS, 36)
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click

        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If
        FrmClassDetails.This_BS = item_BS
        FrmClassDetails.Dgv = dgvCLASS
        FrmClassDetails.ShowDialog()
        FrmClassDetails.Dispose()
        FrmClassDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvCLASS.Rows.Count = 0 Then Exit Sub
        If SecurityAccessMode(Me, False) = False Then
            Exit Sub
        End If
        FrmClassDetails.This_BS = item_BS
        FrmClassDetails.Dgv = dgvCLASS
        FrmClassDetails.ID = dgvCLASS.Rows(dgvCLASS.CurrentRow.Index).Cells(0).Value
        FrmClassDetails.ShowDialog()
        FrmClassDetails.Dispose()
        FrmClassDetails = Nothing

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvCLASS.Rows.Count = 0 Then Exit Sub

        If SecurityAccessDelete(Me) = False Then
            Exit Sub
        End If
        If MessageBoxQuestion("Are you sure to delete this class") = True Then
            SqlExecuted("Delete FROM class WHERE ID = '" & dgvCLASS.Rows(dgvCLASS.CurrentRow.Index).Cells(0).Value & "'")
            DeleteNotify(Me)
            RefreshLoad()
        End If


    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshLoad()
    End Sub



    Private Sub DgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCLASS.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvCLASS, 36)

        ViewColumn(dgvCLASS, 36)
    End Sub

    Private Sub SearchLoad()
        Try

            Dim strFInd As String = ""
            For I As Integer = 0 To dgvCLASS.Columns.Count - 1

                If dgvCLASS.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then

                        If strFInd = "" Then
                            strFInd = $"[{dgvCLASS.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvCLASS.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        End If
                    End If
                End If
            Next
            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub

    Private Sub DgvCLASS_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvCLASS.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class