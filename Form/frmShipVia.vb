Public Class frmShipVia
    Dim item_BS As BindingSource
    Private Sub frmShipVia_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvShipVia, "Select ID,Code,Description from Ship_via", item_BS)
        ViewColumn(dgvShipVia, 40)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvShipVia, 40)

        ViewColumn(dgvShipVia, 40)
    End Sub

    Private Sub frmShipVia_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fRefresh()

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmShipViaDetails.This_BS = item_BS
        frmShipViaDetails.Dgv = dgvShipVia
        frmShipViaDetails.ShowDialog()
        frmShipViaDetails.Dispose()
        frmShipViaDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try

            If dgvShipVia.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            frmShipViaDetails.This_BS = item_BS
            frmShipViaDetails.Dgv = dgvShipVia
            frmShipViaDetails.ID = dgvShipVia.Rows(dgvShipVia.CurrentRow.Index).Cells("ID").Value
            frmShipViaDetails.ShowDialog()
            frmShipViaDetails.Dispose()
            frmShipViaDetails = Nothing

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

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Do you really want to delete " & dgvShipVia.Rows(dgvShipVia.CurrentRow.Index).Cells("Description").Value & "?") = True Then
                SqlExecuted("delete from ship_via where ID = '" & dgvShipVia.Rows(dgvShipVia.CurrentRow.Index).Cells("ID").Value & "'")
                DeleteNotify(Me)
                fRefresh()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub dgvShipVia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShipVia.CellContentClick

    End Sub

    Private Sub dgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvShipVia.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
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

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub dgvShipVia_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvShipVia.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class