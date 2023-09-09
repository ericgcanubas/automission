Public Class FrmBinLocation
    Public item_BS As BindingSource
    Private Sub FrmBinLocation_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshLoad()
    End Sub
    Private Sub RefreshLoad()
        LoadDataGridViewBinding(dgvBinLocation, "Select ID,Code,Description from stock_bin", item_BS)
        ViewColumn(dgvBinLocation, 41)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvBinLocation, 41)

        ViewColumn(dgvBinLocation, 41)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RefreshLoad()
    End Sub
    Private Sub SearchLoad()
        Try


            Dim strFInd As String = ""


            For I As Integer = 0 To dgvBinLocation.Columns.Count - 1

                If dgvBinLocation.Columns(I).Visible = True Then

                    If dgvBinLocation.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvBinLocation.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvBinLocation.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next


            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub




    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DgvBinLocation_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvBinLocation.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TsCreate_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If


        FrmBinLocationDetails.This_BS = item_BS
        FrmBinLocationDetails.Dgv = dgvBinLocation
        FrmBinLocationDetails.ShowDialog()
        FrmBinLocationDetails.Dispose()
        FrmBinLocationDetails = Nothing

    End Sub

    Private Sub TsUpdate_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvBinLocation.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If


            FrmBinLocationDetails.This_BS = item_BS
            FrmBinLocationDetails.Dgv = dgvBinLocation
            FrmBinLocationDetails.ID = dgvBinLocation.Rows(dgvBinLocation.CurrentRow.Index).Cells("ID").Value
            FrmBinLocationDetails.ShowDialog()
            FrmBinLocationDetails.Dispose()
            FrmBinLocationDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvBinLocation.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If fACCESS_DELETE(Me) = True Then

                Exit Sub
            End If
            If MessageBoxQuestion("Do you really want to delete " & dgvBinLocation.Rows(dgvBinLocation.CurrentRow.Index).Cells("Description").Value & "?") = True Then
                SqlExecuted("delete from stock_bin where ID = '" & dgvBinLocation.Rows(dgvBinLocation.CurrentRow.Index).Cells("ID").Value & "'")
                DeleteNotify(Me)
                RefreshLoad()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub



    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class