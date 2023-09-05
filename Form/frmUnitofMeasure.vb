Public Class frmUnitofMeasure
    Dim item_BS As BindingSource
    Private Sub frmShipVia_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        fDataGridView_Binding(dgvUnitOfMeasure, "Select ID,`Name`,Symbol, If(Inactive=0,'No','Yes') as `Inactive` from Unit_of_measure", item_BS)
        fDataGrid_Column(dgvUnitOfMeasure, 45)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        fDataGrid_Switch(dgvUnitOfMeasure, 45)

        fDataGrid_Column(dgvUnitOfMeasure, 45)
    End Sub

    Private Sub frmShipVia_Shown(sender As Object, e As EventArgs) Handles Me.Shown


    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmUnitofMeasureDetails.Dgv = dgvUnitOfMeasure
        frmUnitofMeasureDetails.This_BS = item_BS
        frmUnitofMeasureDetails.ShowDialog()
        frmUnitofMeasureDetails.Dispose()
        frmUnitofMeasureDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvUnitOfMeasure.Rows.Count = 0 Then
                fMessageboxInfo("Data not found")
                Exit Sub
            End If
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            frmUnitofMeasureDetails.Dgv = dgvUnitOfMeasure
            frmUnitofMeasureDetails.This_BS = item_BS
            frmUnitofMeasureDetails.gsID = dgvUnitOfMeasure.Rows(dgvUnitOfMeasure.CurrentRow.Index).Cells("ID").Value
            frmUnitofMeasureDetails.ShowDialog()
            frmUnitofMeasureDetails.Dispose()
            frmUnitofMeasureDetails = Nothing

        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        Try
            If dgvUnitOfMeasure.Rows.Count = 0 Then
                fMessageboxInfo("Data not found")
                Exit Sub
            End If
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fMessageBoxQuestion("Do you really want to delete " & dgvUnitOfMeasure.Rows(dgvUnitOfMeasure.CurrentRow.Index).Cells("NAME").Value & "?") = True Then
                fExecutedOnly("delete from unit_of_measure where ID = '" & dgvUnitOfMeasure.Rows(dgvUnitOfMeasure.CurrentRow.Index).Cells("ID").Value & "'")
                fDeletePopUp(Me)
                fRefresh()
            End If

        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try
    End Sub
    Private Sub dgvShipVia_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUnitOfMeasure.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
        Try
            Dim strFInd As String = ""

            For I As Integer = 0 To dgvUnitOfMeasure.Columns.Count - 1

                If dgvUnitOfMeasure.Columns(I).Visible = True Then

                    If dgvUnitOfMeasure.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then
                        If strFInd = "" Then
                            strFInd = $"[{dgvUnitOfMeasure.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvUnitOfMeasure.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub dgvUnitOfMeasure_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvUnitOfMeasure.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsTxtSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class