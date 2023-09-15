Public Class FrmManufacturers
    Public item_BS As BindingSource
    Private Sub FrmManufacturer_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        GS_LoadDataGridViewBinding(dgvManufacturer, "Select ID,Code,`Name` from Manufacturer ", item_BS)
        ViewColumn(dgvManufacturer, 44)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click

        ViewSwitch(dgvManufacturer, 44)
        ViewColumn(dgvManufacturer, 44)

    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmManufacturersDetails.This_BS = item_BS
        FrmManufacturersDetails.Dgv = dgvManufacturer
        FrmManufacturersDetails.ShowDialog()
        FrmManufacturersDetails.Dispose()
        FrmManufacturersDetails = Nothing
        RefreshData()
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvManufacturer.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If
            dgvManufacturer.Focus()
            FrmManufacturersDetails.This_BS = item_BS
            FrmManufacturersDetails.Dgv = dgvManufacturer
            FrmManufacturersDetails.ID = dgvManufacturer.Rows(dgvManufacturer.CurrentRow.Index).Cells("ID").Value
            FrmManufacturersDetails.ShowDialog()
            FrmManufacturersDetails.Dispose()
            FrmManufacturersDetails = Nothing
            RefreshData()
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvManufacturer.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            dgvManufacturer.Focus()
            If MessageBoxQuestion("Do you really want to delete " & dgvManufacturer.Rows(dgvManufacturer.CurrentRow.Index).Cells("NAME").Value & "?") = True Then
                SqlExecuted("delete from Manufacturer where ID = '" & dgvManufacturer.Rows(dgvManufacturer.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub
    Private Sub DgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManufacturer.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvManufacturer.Columns.Count - 1

                If dgvManufacturer.Columns(I).Visible = True Then


                    If dgvManufacturer.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvManufacturer.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvManufacturer.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub DgvManufacturer_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvManufacturer.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class