Public Class frmItemExpired
    Dim item_BS As BindingSource
    Private Sub frmShipVia_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvList, "SELECT b.`ID`,i.`CODE` as `BARCODE`,i.`PURCHASE_DESCRIPTION` AS `DESCRIPTION`,b.`BATCH_NO` AS `BATCH #`,b.`EXPIRY_DATE` AS `EXPIRED ON`  FROM `item_batches`  AS b INNER JOIN item AS i ON i.`ID` = b.`ITEM_ID` WHERE i.`INACTIVE` = '0';", item_BS)
        ViewColumn(dgvList, 48)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvList, 48)

        ViewColumn(dgvList, 48)
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

        frmItemExpiredDetails.This_BS = item_BS
        frmItemExpiredDetails.Dgv = dgvList
        frmItemExpiredDetails.ShowDialog()
        frmItemExpiredDetails.Dispose()
        frmItemExpiredDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try

            If dgvList.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            frmItemExpiredDetails.This_BS = item_BS
            frmItemExpiredDetails.Dgv = dgvList
            frmItemExpiredDetails.ID = dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value
            frmItemExpiredDetails.ShowDialog()
            frmItemExpiredDetails.Dispose()
            frmItemExpiredDetails = Nothing

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

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Do you really want to delete " & dgvList.Rows(dgvList.CurrentRow.Index).Cells("BATCH #").Value & "?") = True Then
                SqlExecuted("delete from item_batches where ID = '" & dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                fRefresh()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub dgvShipVia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub

    Private Sub dgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
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

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub dgvShipVia_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvList.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class