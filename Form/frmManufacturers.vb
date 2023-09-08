Public Class FrmManufacturers
    Public item_BS As BindingSource
    Private Sub frmShipVia_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvManufacturer, "Select ID,Code,`Name` from Manufacturer ", item_BS)
        ViewColumn(dgvManufacturer, 44)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click

        ViewSwitch(dgvManufacturer, 44)
        ViewColumn(dgvManufacturer, 44)

    End Sub

    Private Sub frmShipVia_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If


        frmManufacturersDetails.This_BS = item_BS
        frmManufacturersDetails.Dgv = dgvManufacturer
        frmManufacturersDetails.ShowDialog()
        frmManufacturersDetails.Dispose()
        frmManufacturersDetails = Nothing
        fRefresh()
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvManufacturer.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If
            dgvManufacturer.Focus()
            frmManufacturersDetails.This_BS = item_BS
            frmManufacturersDetails.Dgv = dgvManufacturer
            frmManufacturersDetails.ID = dgvManufacturer.Rows(dgvManufacturer.CurrentRow.Index).Cells("ID").Value
            frmManufacturersDetails.ShowDialog()
            frmManufacturersDetails.Dispose()
            frmManufacturersDetails = Nothing
            fRefresh()
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

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            dgvManufacturer.Focus()
            If MessageBoxQuestion("Do you really want to delete " & dgvManufacturer.Rows(dgvManufacturer.CurrentRow.Index).Cells("NAME").Value & "?") = True Then
                SqlExecuted("delete from Manufacturer where ID = '" & dgvManufacturer.Rows(dgvManufacturer.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                fRefresh()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub dgvShipVia_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManufacturer.CellContentClick

    End Sub

    Private Sub dgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManufacturer.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
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

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub dgvManufacturer_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvManufacturer.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class