Public Class FrmPaymentMethods
    Public item_BS As BindingSource
    Private Sub frmPaymentTerms_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefresh()
    End Sub
    Private Sub fRefresh()
        LoadDataGridViewBinding(dgvPaymentMethods, "SELECT pm.`ID`,pm.`Code`,pm.`Description`,p.`DESCRIPTION` AS `Payment Type`, CONCAT(a.`NAME` , ' / ' ,a.`TYPE`) AS `G/L Account` FROM payment_method AS pm LEFT OUTER JOIN  payment_type_map AS p ON p.`ID` = pm.`PAYMENT_TYPE` LEFT OUTER JOIN account AS a ON a.`ID` = pm.`GL_ACCOUNT_ID`", item_BS)
        ViewColumn(dgvPaymentMethods, 33)
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvPaymentMethods, 33)
        ViewColumn(dgvPaymentMethods, 33)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmPaymentMethodsDetails.This_BS = item_BS
        frmPaymentMethodsDetails.Dgv = dgvPaymentMethods
        frmPaymentMethodsDetails.ShowDialog()
        frmPaymentMethodsDetails.Dispose()
        frmPaymentMethodsDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvPaymentMethods.Rows.Count = 0 Then Exit Sub
        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            dgvPaymentMethods.Focus()
            Dim i As Integer = dgvPaymentMethods.CurrentRow.Index


            frmPaymentMethodsDetails.This_BS = item_BS

            frmPaymentMethodsDetails.Dgv = dgvPaymentMethods
            frmPaymentMethodsDetails.ID = dgvPaymentMethods.Rows(i).Cells("ID").Value
            frmPaymentMethodsDetails.ShowDialog()
            frmPaymentMethodsDetails.Dispose()
            frmPaymentMethodsDetails = Nothing

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub dgvPaymentTerms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentMethods.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        Try
            If dgvPaymentMethods.Rows.Count = 0 Then Exit Sub
            Dim i As Integer = dgvPaymentMethods.CurrentRow.Index

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Are you sure to delete this payment method") = True Then
                SqlExecuted("DELETE FROM payment_method WHERE ID = '" & dgvPaymentMethods.Rows(i).Cells("ID").Value & "' limit 1;")
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

            For I As Integer = 0 To dgvPaymentMethods.Columns.Count - 1

                If dgvPaymentMethods.Columns(I).Visible = True Then

                    If dgvPaymentMethods.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvPaymentMethods.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvPaymentMethods.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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

    Private Sub dgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvPaymentMethods.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class