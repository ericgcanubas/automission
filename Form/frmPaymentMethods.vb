Public Class FrmPaymentMethods
    Public item_BS As BindingSource
    Private Sub FrmPaymentTerms_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub
    Private Sub RefreshData()
        GS_LoadDataGridViewBinding(dgvPaymentMethods, "SELECT pm.`ID`,pm.`Code`,pm.`Description`,p.`DESCRIPTION` AS `Payment Type`, CONCAT(a.`NAME` , ' / ' ,a.`TYPE`) AS `G/L Account` FROM payment_method AS pm LEFT OUTER JOIN  payment_type_map AS p ON p.`ID` = pm.`PAYMENT_TYPE` LEFT OUTER JOIN account AS a ON a.`ID` = pm.`GL_ACCOUNT_ID`", item_BS)
        ViewColumn(dgvPaymentMethods, 33)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvPaymentMethods, 33)
        ViewColumn(dgvPaymentMethods, 33)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmPaymentMethodsDetails.This_BS = item_BS
        FrmPaymentMethodsDetails.Dgv = dgvPaymentMethods
        FrmPaymentMethodsDetails.ShowDialog()
        FrmPaymentMethodsDetails.Dispose()
        FrmPaymentMethodsDetails = Nothing

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvPaymentMethods.Rows.Count = 0 Then Exit Sub
        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            dgvPaymentMethods.Focus()
            Dim i As Integer = dgvPaymentMethods.CurrentRow.Index


            FrmPaymentMethodsDetails.This_BS = item_BS

            FrmPaymentMethodsDetails.Dgv = dgvPaymentMethods
            FrmPaymentMethodsDetails.ID = dgvPaymentMethods.Rows(i).Cells("ID").Value
            FrmPaymentMethodsDetails.ShowDialog()
            FrmPaymentMethodsDetails.Dispose()
            FrmPaymentMethodsDetails = Nothing

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub DgvPaymentTerms_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPaymentMethods.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        Try
            If dgvPaymentMethods.Rows.Count = 0 Then Exit Sub
            Dim i As Integer = dgvPaymentMethods.CurrentRow.Index

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion("Are you sure to delete this payment method") = True Then
                SqlExecuted("DELETE FROM payment_method WHERE ID = '" & dgvPaymentMethods.Rows(i).Cells("ID").Value & "' limit 1;")
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

    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub DgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvPaymentMethods.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class