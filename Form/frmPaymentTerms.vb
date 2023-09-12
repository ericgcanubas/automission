Public Class FrmPaymentTerms
    Dim item_BS As BindingSource
    Private Sub FrmPaymentTerms_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        LoadDataGridViewBinding(dgvPaymentTerms, "select  ID,CODE,DESCRIPTION,INACTIVE from payment_terms", item_BS)

        With dgvPaymentTerms.Columns
            .Item(0).Visible = False
        End With
        ViewColumn(dgvPaymentTerms, "30")
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvPaymentTerms, 30)

        ViewColumn(dgvPaymentTerms, 30)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If


        FrmPaymentTermsDetails.This_BS = item_BS
        FrmPaymentTermsDetails.Dgv = dgvPaymentTerms
        FrmPaymentTermsDetails.ID = 0
        FrmPaymentTermsDetails.ShowDialog()
        FrmPaymentTermsDetails.Dispose()
        FrmPaymentTermsDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvPaymentTerms.Rows.Count = 0 Then Exit Sub

        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            dgvPaymentTerms.Focus()
            Dim i As Integer = dgvPaymentTerms.CurrentRow.Index

            FrmPaymentTermsDetails.This_BS = item_BS
            FrmPaymentTermsDetails.Dgv = dgvPaymentTerms
            FrmPaymentTermsDetails.ID = dgvPaymentTerms.Rows(i).Cells("ID").Value
            FrmPaymentTermsDetails.ShowDialog()
            FrmPaymentTermsDetails.Dispose()
            FrmPaymentTermsDetails = Nothing

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub


    Private Sub DgvPaymentTerms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentTerms.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvPaymentTerms.Rows.Count = 0 Then Exit Sub
        Try
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If
            dgvPaymentTerms.Focus()
            Dim i As Integer = dgvPaymentTerms.CurrentRow.Index
            If MessageBoxQuestion("Are you sure to delete this payment terms") = True Then
                SqlExecuted("DELETE FROM payment_terms WHERE ID = '" & dgvPaymentTerms.Rows(i).Cells("ID").Value & "' limit 1;")
                DeleteNotify(Me)
                RefreshData()
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""

            For I As Integer = 0 To dgvPaymentTerms.Columns.Count - 1

                If dgvPaymentTerms.Columns(I).Visible = True Then

                    If dgvPaymentTerms.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvPaymentTerms.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvPaymentTerms.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub DgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvPaymentTerms.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class