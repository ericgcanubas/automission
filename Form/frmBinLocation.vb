Public Class frmBinLocation
    Public item_BS As BindingSource
    Private Sub frmShipVia_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm

        fRefresh()

    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvBinLocation, "Select ID,Code,Description from stock_bin", item_BS)
        ViewColumn(dgvBinLocation, 41)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvBinLocation, 41)

        ViewColumn(dgvBinLocation, 41)
    End Sub

    Private Sub frmShipVia_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvShipVia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBinLocation.CellContentClick

    End Sub

    Private Sub dgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBinLocation.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fRefresh()
    End Sub
    Private Sub fSearchload()
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

    Private Sub dgvBinLocation_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvBinLocation.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsCreate_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If


        frmBinLocationDetails.This_BS = item_BS
        frmBinLocationDetails.Dgv = dgvBinLocation
        frmBinLocationDetails.ShowDialog()
        frmBinLocationDetails.Dispose()
        frmBinLocationDetails = Nothing

    End Sub

    Private Sub tsUpdate_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvBinLocation.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If


            frmBinLocationDetails.This_BS = item_BS
            frmBinLocationDetails.Dgv = dgvBinLocation
            frmBinLocationDetails.ID = dgvBinLocation.Rows(dgvBinLocation.CurrentRow.Index).Cells("ID").Value
            frmBinLocationDetails.ShowDialog()
            frmBinLocationDetails.Dispose()
            frmBinLocationDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
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
                fRefresh()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsTxtSearch_Click(sender As Object, e As EventArgs) Handles tsTxtSearch.Click

    End Sub

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class