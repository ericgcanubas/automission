Public Class FrmPriceLevel
    Dim item_BS As BindingSource
    Private Sub FrmPriceLevel_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        GS_LoadDataGridViewBinding(dgvPriceLevel, "Select pl.ID,pl.Code,pl.Description, pltm.`Description` as `Type`,ig.Description as `Item Group`, IF(pl.`Inactive`=0,'No','Yes') as `Inactive` from price_level as pl inner join price_level_type_map as pltm on pltm.id = pl.`type` left outer join item_group as ig on ig.id = pl.item_group_id ", item_BS)
        ViewColumn(dgvPriceLevel, 42)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvPriceLevel, 42)
        ViewColumn(dgvPriceLevel, 42)
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmPriceLevelDetails.This_BS = item_BS
        FrmPriceLevelDetails.Dgv = dgvPriceLevel
        FrmPriceLevelDetails.ShowDialog()
        FrmPriceLevelDetails.Dispose()
        FrmPriceLevelDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try

            If dgvPriceLevel.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            FrmPriceLevelDetails.This_BS = item_BS
            FrmPriceLevelDetails.Dgv = dgvPriceLevel
            FrmPriceLevelDetails.ID = dgvPriceLevel.Rows(dgvPriceLevel.CurrentRow.Index).Cells("ID").Value
            FrmPriceLevelDetails.ShowDialog()
            FrmPriceLevelDetails.Dispose()
            FrmPriceLevelDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvPriceLevel.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Do you really want to delete " & dgvPriceLevel.Rows(dgvPriceLevel.CurrentRow.Index).Cells("Description").Value & "?") = True Then
                SqlExecuted("delete from price_level where ID = '" & dgvPriceLevel.Rows(dgvPriceLevel.CurrentRow.Index).Cells("ID").Value & "' limit 1;")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub


    Private Sub DgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPriceLevel.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvPriceLevel.Columns.Count - 1
                If dgvPriceLevel.Columns(I).Visible = True Then
                    If dgvPriceLevel.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then
                        If strFInd = "" Then
                            strFInd = $"[{dgvPriceLevel.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvPriceLevel.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub DgvPriceLevel_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvPriceLevel.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class