Public Class frmLocation
    Dim item_BS As BindingSource
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmLocationDetails.This_BS = item_BS
        frmLocationDetails.Dgv = dgvLocation
        frmLocationDetails.ShowDialog()
        frmLocationDetails.Dispose()
        frmLocationDetails = Nothing


    End Sub

    Private Sub frmLocation_Load(sender As Object, e As EventArgs) Handles Me.Load

        fRefreshList()
        ViewColumn(dgvLocation, "29")
    End Sub
    Private Sub fRefreshList()
        LoadDataGridViewBinding(dgvLocation, "select  l.`ID`,l.`Code`,l.`Name`,ifnull(p.DESCRIPTION,'') as `Price level`,l.Inactive from location as l left outer join price_level as p on p.ID = l.price_level_id", item_BS)

        With dgvLocation.Columns
            .Item(0).Visible = False

        End With
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvLocation, 29)

        ViewColumn(dgvLocation, 29)
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvLocation.Rows.Count = 0 Then Exit Sub
        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If
            dgvLocation.Focus()

            frmLocationDetails.This_BS = item_BS
            frmLocationDetails.Dgv = dgvLocation
            Dim i As Integer = dgvLocation.CurrentRow.Index
            frmLocationDetails.ID = dgvLocation.Rows(i).Cells("ID").Value
            frmLocationDetails.ShowDialog()
            frmLocationDetails.Dispose()
            frmLocationDetails = Nothing

        Catch ex As Exception

        End Try

    End Sub
    Private Sub dgvLocation_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocation.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If dgvLocation.Rows.Count = 0 Then Exit Sub
        If fACCESS_DELETE(Me) = False Then
            Exit Sub
        End If

        If MessageBoxQuestion("Are you sure to delete this location?") = True Then
            Dim i As Integer = dgvLocation.CurrentRow.Index

            SqlExecuted("DELETE FROM location where ID = '" & dgvLocation.Rows(i).Cells("ID").Value & "' limit 1;")
            DeleteNotify(Me)
            fRefreshList()
        End If
    End Sub
    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefreshList()
    End Sub
    Private Sub fSearchload()
        Try


            Dim strFInd As String = ""

            For I As Integer = 0 To dgvLocation.Columns.Count - 1

                If dgvLocation.Columns(I).Visible = True Then

                    If dgvLocation.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvLocation.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvLocation.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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
    Private Sub dgvLocation_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvLocation.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub frmLocation_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class