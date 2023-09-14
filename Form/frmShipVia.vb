Public Class FrmShipVia
    Dim item_BS As BindingSource
    Private Sub FrmShipVia_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
    End Sub
    Private Sub RefreshData()
        LoadDataGridViewBinding(dgvShipVia, "Select ID,Code,Description from Ship_via", item_BS)
        ViewColumn(dgvShipVia, 40)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvShipVia, 40)

        ViewColumn(dgvShipVia, 40)
    End Sub

    Private Sub FrmShipVia_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshData()
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmShipViaDetails.This_BS = item_BS
        FrmShipViaDetails.Dgv = dgvShipVia
        FrmShipViaDetails.ShowDialog()
        FrmShipViaDetails.Dispose()
        FrmShipViaDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try

            If dgvShipVia.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            FrmShipViaDetails.This_BS = item_BS
            FrmShipViaDetails.Dgv = dgvShipVia
            FrmShipViaDetails.ID = dgvShipVia.Rows(dgvShipVia.CurrentRow.Index).Cells("ID").Value
            FrmShipViaDetails.ShowDialog()
            FrmShipViaDetails.Dispose()
            FrmShipViaDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvShipVia.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Do you really want to delete " & dgvShipVia.Rows(dgvShipVia.CurrentRow.Index).Cells("Description").Value & "?") = True Then
                SqlExecuted("delete from ship_via where ID = '" & dgvShipVia.Rows(dgvShipVia.CurrentRow.Index).Cells("ID").Value & "'")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub



    Private Sub DgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShipVia.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvShipVia.Columns.Count - 1
                If dgvShipVia.Columns(I).Visible = True Then
                    If dgvShipVia.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvShipVia.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvShipVia.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub DgvShipVia_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvShipVia.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class