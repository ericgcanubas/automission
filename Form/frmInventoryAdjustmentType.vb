
Public Class FrmInventoryAdjustmentType
    Dim item_BS As BindingSource
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvInventoryAdjustmentType, 43)
        ViewColumn(dgvInventoryAdjustmentType, 43)

    End Sub
    Private Sub RefreshData()
        LoadDataGridViewBinding(dgvInventoryAdjustmentType, "select i.ID,i.Code,i.Description, a.`Name`  as `Account` from Inventory_Adjustment_Type as i left outer join account as a on a.ID = i.account_id", item_BS)
        ViewColumn(dgvInventoryAdjustmentType, 43)
    End Sub
    Private Sub FrmInventoryAdjustmentType_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        Refresh()
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmInventoryAdjustmentTypeDetails.This_BS = item_BS
        FrmInventoryAdjustmentTypeDetails.Dgv = dgvInventoryAdjustmentType
        FrmInventoryAdjustmentTypeDetails.ShowDialog()
        FrmInventoryAdjustmentTypeDetails.Dispose()
        FrmInventoryAdjustmentTypeDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvInventoryAdjustmentType.Rows.Count = 0 Then
                MessageBoxInfo("Data not found!")
                Exit Sub
            End If

            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If


            FrmInventoryAdjustmentTypeDetails.This_BS = item_BS
            FrmInventoryAdjustmentTypeDetails.Dgv = dgvInventoryAdjustmentType
            FrmInventoryAdjustmentTypeDetails.ID = dgvInventoryAdjustmentType.Rows(dgvInventoryAdjustmentType.CurrentRow.Index).Cells("ID").Value
            FrmInventoryAdjustmentTypeDetails.ShowDialog()
            FrmInventoryAdjustmentTypeDetails.Dispose()
            FrmInventoryAdjustmentTypeDetails = Nothing

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvInventoryAdjustmentType.Rows.Count = 0 Then
                MessageBoxInfo("Data not found!")
                Exit Sub
            End If

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Do you really want to delete " & dgvInventoryAdjustmentType.Rows(dgvInventoryAdjustmentType.CurrentRow.Index).Cells("Description").Value & "?") = True Then
                SqlExecuted("Delete FROM inventory_adjustment_type where id = '" & dgvInventoryAdjustmentType.Rows(dgvInventoryAdjustmentType.CurrentRow.Index).Cells("ID").Value & "'")
                DeleteNotify(Me)
                Refresh()
            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub DgvInventoryAdjustmentType_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventoryAdjustmentType.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        Refresh()
    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""

            For I As Integer = 0 To dgvInventoryAdjustmentType.Columns.Count - 1

                If dgvInventoryAdjustmentType.Columns(I).Visible = True Then

                    If dgvInventoryAdjustmentType.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvInventoryAdjustmentType.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvInventoryAdjustmentType.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub DgvInventoryAdjustmentType_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvInventoryAdjustmentType.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class