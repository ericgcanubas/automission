
Public Class frmInventoryAdjustmentType
    Dim item_BS As BindingSource
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        fDataGrid_Switch(dgvInventoryAdjustmentType, 43)
        fDataGrid_Column(dgvInventoryAdjustmentType, 43)

    End Sub
    Private Sub fRefresh()
        fDataGridView_Binding(dgvInventoryAdjustmentType, "select i.ID,i.Code,i.Description, a.`Name`  as `Account` from Inventory_Adjustment_Type as i left outer join account as a on a.ID = i.account_id", item_BS)
        fDataGrid_Column(dgvInventoryAdjustmentType, 43)
    End Sub
    Private Sub frmInventoryAdjustmentType_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub

    Private Sub frmInventoryAdjustmentType_Shown(sender As Object, e As EventArgs) Handles Me.Shown


    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmInventoryAdjustmentTypeDetails.This_BS = item_BS
        frmInventoryAdjustmentTypeDetails.Dgv = dgvInventoryAdjustmentType
        frmInventoryAdjustmentTypeDetails.ShowDialog()
        frmInventoryAdjustmentTypeDetails.Dispose()
        frmInventoryAdjustmentTypeDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvInventoryAdjustmentType.Rows.Count = 0 Then
                fMessageboxInfo("Data not found!")
                Exit Sub
            End If
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If


            frmInventoryAdjustmentTypeDetails.This_BS = item_BS
            frmInventoryAdjustmentTypeDetails.Dgv = dgvInventoryAdjustmentType
            frmInventoryAdjustmentTypeDetails.gsID = dgvInventoryAdjustmentType.Rows(dgvInventoryAdjustmentType.CurrentRow.Index).Cells("ID").Value
            frmInventoryAdjustmentTypeDetails.ShowDialog()
            frmInventoryAdjustmentTypeDetails.Dispose()
            frmInventoryAdjustmentTypeDetails = Nothing

        Catch ex As Exception

        End Try


    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvInventoryAdjustmentType.Rows.Count = 0 Then
                fMessageboxInfo("Data not found!")
                Exit Sub
            End If

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fMessageBoxQuestion("Do you really want to delete " & dgvInventoryAdjustmentType.Rows(dgvInventoryAdjustmentType.CurrentRow.Index).Cells("Description").Value & "?") = True Then
                fExecutedOnly("Delete FROM inventory_adjustment_type where id = '" & dgvInventoryAdjustmentType.Rows(dgvInventoryAdjustmentType.CurrentRow.Index).Cells("ID").Value & "'")
                fDeletePopUp(Me)
                fRefresh()
            End If


        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvInventoryAdjustmentType_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventoryAdjustmentType.CellContentClick

    End Sub

    Private Sub dgvInventoryAdjustmentType_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInventoryAdjustmentType.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
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

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub dgvInventoryAdjustmentType_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvInventoryAdjustmentType.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class