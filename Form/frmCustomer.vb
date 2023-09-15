Public Class FrmCustomer
    Public contact_BS As BindingSource

    Private Sub FrmCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        RefreshData()
        dgvCustomer.Columns(1).Width = 150
        dgvCustomer.Columns(2).Width = 200
        dgvCustomer.Columns(3).Width = 150


    End Sub

    Private Sub RefreshData()

        GS_LoadDataGridViewBinding(dgvCustomer, "SELECT 
c.ID,
c.Name,
c.POSTAL_ADDRESS AS 'Postal Address',
c.CONTACT_PERSON AS 'Contact Person',
c.TELEPHONE_NO AS 'Telephone Number',
c.MOBILE_NO As `Mobile Number`,
c.CUSTOM_FIELD4 as `Date Sign-In`,
g.DESCRIPTION AS 'Group',
s.name AS 'Sales Rep',
d.name AS 'Dealer',
p.DESCRIPTION AS 'Pmt. Terms',
format(c.Credit_limit,2) AS 'Credit Limit',
pl.DESCRIPTION AS 'Price Level',
c.ACCOUNT_NO AS 'Account Number',
c.Taxpayer_id AS 'Taxpayer Id No.',
if (c.Inactive=0,'No','Yes') as `Inactive` 
FROM
contact AS c 
LEFT OUTER JOIN contact_group AS g 
ON g.ID = c.GROUP_ID
LEFT  OUTER JOIN contact AS s 
ON c.sales_rep_id = s.ID 
AND s.Type = '2' 
LEFT  OUTER JOIN contact AS d 
ON c.other_contact_id = d.ID 
AND d.Type = '6'
LEFT OUTER JOIN payment_terms AS p
ON p.id = c.payment_terms_id 
LEFT OUTER JOIN price_level AS pl 
ON pl.id = c.price_level_id 
WHERE c.Type = '1' ", contact_BS)

        With dgvCustomer.Columns
            .Item(0).Visible = False

        End With
        ViewColumn(dgvCustomer, "1")
    End Sub

    Private Sub DgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellDoubleClick
        tsUpdate.PerformClick()
    End Sub
    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ExportingExcel(dgvCustomer, "Customer_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub
    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvCustomer.Columns.Count - 1

                If dgvCustomer.Columns(I).Visible = True Then

                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvCustomer.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvCustomer.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next



            contact_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub



    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub
    Private Sub DgvCustomer_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvCustomer.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub TsCreate_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmContactDetails.ContactTypeId = "1"
        FrmContactDetails.IsNew = True
        FrmContactDetails.ID = 0
        FrmContactDetails.gsDgv = dgvCustomer
        FrmContactDetails.this_BS = contact_BS
        FrmContactDetails.ShowDialog()
        FrmContactDetails.Dispose()
        FrmContactDetails = Nothing
    End Sub

    Private Sub TsReload_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub

    Private Sub TsColumn_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvCustomer, 1)
        ViewColumn(dgvCustomer, 1)
    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvCustomer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If
            dgvCustomer.Focus()
            Dim i As Integer = dgvCustomer.CurrentRow.Index
            Dim dID As String = dgvCustomer.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvCustomer.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact where id='" & dID & "'")
                RefreshData()
            End If

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub TsUpdate_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvCustomer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            dgvCustomer.Focus()
            Dim i As Integer = dgvCustomer.CurrentRow.Index
            Dim dID As String = dgvCustomer.Rows.Item(i).Cells(0).Value
            FrmContactDetails.ContactTypeId = "1"

            FrmContactDetails.IsNew = False
            FrmContactDetails.ID = dID
            FrmContactDetails.this_BS = contact_BS
            FrmContactDetails.gsDgv = dgvCustomer
            FrmContactDetails.ShowDialog()
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
            ' RefreshData()
        Catch ex As Exception

        End Try

    End Sub
End Class