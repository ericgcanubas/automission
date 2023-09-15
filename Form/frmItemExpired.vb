Public Class FrmItemExpired
    Dim item_BS As BindingSource
    Private Sub FrmItemExpired_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        GS_LoadDataGridViewBinding(dgvList, "SELECT b.`ID`,i.`CODE` as `BARCODE`,i.`PURCHASE_DESCRIPTION` AS `DESCRIPTION`,b.`BATCH_NO` AS `BATCH #`,b.`EXPIRY_DATE` AS `EXPIRED ON`  FROM `item_batches`  AS b INNER JOIN item AS i ON i.`ID` = b.`ITEM_ID` WHERE i.`INACTIVE` = '0';", item_BS)
        ViewColumn(dgvList, 48)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvList, 48)
        ViewColumn(dgvList, 48)
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmItemExpiredDetails.This_BS = item_BS
        FrmItemExpiredDetails.Dgv = dgvList
        FrmItemExpiredDetails.ShowDialog()
        FrmItemExpiredDetails.Dispose()
        FrmItemExpiredDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try

            If dgvList.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            FrmItemExpiredDetails.This_BS = item_BS
            FrmItemExpiredDetails.Dgv = dgvList
            FrmItemExpiredDetails.ID = dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value
            FrmItemExpiredDetails.ShowDialog()
            FrmItemExpiredDetails.Dispose()
            FrmItemExpiredDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvList.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Do you really want to delete " & dgvList.Rows(dgvList.CurrentRow.Index).Cells("BATCH #").Value & "?") = True Then
                SqlExecuted("delete from item_batches where ID = '" & dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub



    Private Sub DgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""


            For I As Integer = 0 To dgvList.Columns.Count - 1

                If dgvList.Columns(I).Visible = True Then


                    If dgvList.Columns(I).HeaderText.ToUpper = "EXPIRED ON" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvList.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvList.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub DgvShipVia_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvList.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class