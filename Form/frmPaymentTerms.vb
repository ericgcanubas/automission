Public Class frmPaymentTerms
    Dim item_BS As BindingSource
    Private Sub frmPaymentTerms_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvPaymentTerms, "select  ID,CODE,DESCRIPTION,INACTIVE from payment_terms", item_BS)

        With dgvPaymentTerms.Columns
            .Item(0).Visible = False
        End With
        ViewColumn(dgvPaymentTerms, "30")
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvPaymentTerms, 30)

        ViewColumn(dgvPaymentTerms, 30)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If


        frmPaymentTermsDetails.This_BS = item_BS
        frmPaymentTermsDetails.Dgv = dgvPaymentTerms

        frmPaymentTermsDetails.ShowDialog()
        frmPaymentTermsDetails.Dispose()
        frmPaymentTermsDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvPaymentTerms.Rows.Count = 0 Then Exit Sub

        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            dgvPaymentTerms.Focus()
            Dim i As Integer = dgvPaymentTerms.CurrentRow.Index

            frmPaymentTermsDetails.This_BS = item_BS
            frmPaymentTermsDetails.Dgv = dgvPaymentTerms
            frmPaymentTermsDetails.ID = dgvPaymentTerms.Rows(i).Cells("ID").Value
            frmPaymentTermsDetails.ShowDialog()
            frmPaymentTermsDetails.Dispose()
            frmPaymentTermsDetails = Nothing

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub


    Private Sub dgvPaymentTerms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentTerms.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvPaymentTerms.Rows.Count = 0 Then Exit Sub
        Try
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If
            dgvPaymentTerms.Focus()
            Dim i As Integer = dgvPaymentTerms.CurrentRow.Index
            If MessageBoxQuestion("Are you sure to delete this payment terms") = True Then
                SqlExecuted("DELETE FROM payment_terms WHERE ID = '" & dgvPaymentTerms.Rows(i).Cells("ID").Value & "' limit 1;")
                DeleteNotify(Me)
                fRefresh()
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub fSearchload()
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

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefresh()
    End Sub

    Private Sub dgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvPaymentTerms.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub frmPaymentTerms_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub dgvPaymentTerms_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentTerms.CellContentClick

    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class