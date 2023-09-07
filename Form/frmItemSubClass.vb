Public Class frmItemSubClass
    Public item_BS As BindingSource
    Private Sub frmItemSubClass_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvSubClass, "select  isc.ID, isc.Code,isc.Description, ic.Description as `Class` from item_sub_class as isc  inner join item_class as ic on ic.id = isc.class_id ", item_BS)
        ViewColumn(dgvSubClass, 38)
    End Sub



    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvSubClass, 38)

        ViewColumn(dgvSubClass, 38)
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmItemSubClassDetails.BS = item_BS
        frmItemSubClassDetails.View = dgvSubClass
        frmItemSubClassDetails.ShowDialog()
        frmItemSubClassDetails.Dispose()
        frmItemSubClassDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        Try
            If dgvSubClass.Rows.Count = 0 Then
                MessageBoxInfo("Data now found!")
                Exit Sub
            End If
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            frmItemSubClassDetails.BS = item_BS
            frmItemSubClassDetails.View = dgvSubClass
            frmItemSubClassDetails.ID = dgvSubClass.Rows(dgvSubClass.CurrentRow.Index).Cells("ID").Value
            frmItemSubClassDetails.ShowDialog()
            frmItemSubClassDetails.Dispose()
            frmItemSubClassDetails = Nothing

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try

    End Sub
    Private Sub dgvSubClass_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubClass.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        Try
            If dgvSubClass.Rows.Count = 0 Then
                MessageBoxInfo("Data now found!")
                Exit Sub
            End If

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Are you sure to delete this item sub-class?") = True Then
                SqlExecuted("DELETE FROM item_sub_class where id = '" & dgvSubClass.Rows(dgvSubClass.CurrentRow.Index).Cells("ID").Value & "' limit 1")
                DeleteNotify(Me)
                fRefresh()
            End If
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub
    Private Sub fSearchload()
        Try




            Dim strFInd As String = ""


            For I As Integer = 0 To dgvSubClass.Columns.Count - 1

                If dgvSubClass.Columns(I).Visible = True Then


                    If dgvSubClass.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvSubClass.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvSubClass.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub dgvSubClass_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSubClass.CellContentClick

    End Sub

    Private Sub dgvSubClass_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvSubClass.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class