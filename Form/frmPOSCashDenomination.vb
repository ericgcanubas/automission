Public Class FrmPOSCashDenomination
    Public item_BS As BindingSource
    Public gsFindID As Double

    Private Sub RefreshData()
        Dim SQL As String = "select cd.`ID`,cd.`CODE`,cd.`DESCRIPTION`,cd.NOMINAL_VALUE as `NOMINAL VALUE`,ct.DESCRIPTION as `TYPE`, if( cd.`INACTIVE`=0,'No','Yes') as `INACTIVE` from pos_cash_denomination  as cd inner join pos_cash_type_map as ct on ct.id = cd.type "

        GS_LoadDataGridViewBinding(dgvList, SQL, item_BS)

        With dgvList.Columns
            .Item(0).Visible = False
            .Item(3).DefaultCellStyle.Format = "N2"
        End With
        ViewColumn(dgvList, 47)

    End Sub
    Private Sub SearchLoad()
        Try
            Dim Search_It As String = ""
            For I As Integer = 0 To dgvList.Columns.Count - 1
                If Search_It = "" Then
                    Search_It = $"[{dgvList.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                Else
                    Search_It = Search_It & $" OR [{dgvList.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                End If

            Next
            item_BS.Filter = Search_It
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsTxtSearch_Click(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub

    Private Sub DgvList_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvList.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub FrmPOSCashDenomination_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
    End Sub

    Private Sub Tscolumn_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvList, 47) ' 2 = for vendor
        ViewColumn(dgvList, 46) ' 2 = for vendor
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        With FrmPOSCashDenominationDetails
            .ID = 0
            .ShowDialog()
            If .gsOK = True Then
                RefreshData()
            End If
            .Dispose()

        End With
        FrmPOSCashDenominationDetails = Nothing
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvList.Rows.Count = 0 Then
            MessageBoxInfo("data not found.")
            Exit Sub
        End If
        If SecurityAccessDelete(Me) = False Then
            Exit Sub
        End If


        If MessageBoxQuestion("Are you sure to delete this cash denomination?") = True Then
            Try
                dgvList.Select()
                Dim ID As Integer = dgvList.CurrentRow.Cells(0).Value
                SqlExecuted($"delete from pos_cash_denomination where id = '{ID}' limit 1;")
                DeleteNotify(Me)
                RefreshData()
            Catch ex As Exception
                MessageBoxExclamation(ex.Message)
            End Try
        End If



    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvList.Rows.Count = 0 Then
            MessageBoxInfo("data not found.")
            Exit Sub
        End If

        With FrmPOSCashDenominationDetails
            dgvList.Select()
            .ID = dgvList.CurrentRow.Cells(0).Value
            .ShowDialog()
            If .gsOK = True Then
                RefreshData()
            End If
            .Dispose()

        End With
        frmPOSCashDenominationDetails = Nothing
    End Sub

End Class