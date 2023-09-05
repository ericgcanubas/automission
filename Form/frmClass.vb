Public Class frmClass
    Dim item_BS As BindingSource
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub
    Private Sub frmClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fRefresh()
    End Sub

    Private Sub fRefresh()
        fDataGridView_Binding(dgvCLASS, "Select ID,`Name`, if(`Inactive`=0,'No','Yes') as `Inactive` from Class", item_BS)
        dgvCLASS.Columns(0).Visible = False
        fDataGrid_Column(dgvCLASS, 36)
    End Sub

    Private Sub frmClass_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        '  fSearchGet()
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click

        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If
        frmClassDetails.This_BS = item_BS
        frmClassDetails.Dgv = dgvCLASS
        frmClassDetails.ShowDialog()
        frmClassDetails.Dispose()
        frmClassDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvCLASS.Rows.Count = 0 Then Exit Sub
        If fACCESS_NEW_EDIT(Me, False) = False Then
            Exit Sub
        End If
        frmClassDetails.This_BS = item_BS
        frmClassDetails.Dgv = dgvCLASS
        frmClassDetails.gsID = dgvCLASS.Rows(dgvCLASS.CurrentRow.Index).Cells(0).Value
        frmClassDetails.ShowDialog()
        frmClassDetails.Dispose()
        frmClassDetails = Nothing

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvCLASS.Rows.Count = 0 Then Exit Sub

        If fACCESS_DELETE(Me) = False Then
            Exit Sub
        End If
        If fMessageBoxQuestion("Are you sure to delete this class") = True Then
            fExecutedOnly("Delete FROM class WHERE ID = '" & dgvCLASS.Rows(dgvCLASS.CurrentRow.Index).Cells(0).Value & "'")
            fDeletePopUp(Me)
            fRefresh()
        End If


    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub



    Private Sub dgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCLASS.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        fDataGrid_Switch(dgvCLASS, 36)

        fDataGrid_Column(dgvCLASS, 36)
    End Sub

    Private Sub fSearchload()
        Try

            Dim strFInd As String = ""
            For I As Integer = 0 To dgvCLASS.Columns.Count - 1

                If dgvCLASS.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvCLASS.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvCLASS.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
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

    Private Sub dgvCLASS_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvCLASS.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class