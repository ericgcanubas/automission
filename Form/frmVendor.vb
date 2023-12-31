﻿
Public Class FrmVendor
    Public contact_BS As BindingSource
    Private Sub RefreshData()

        GS_LoadDataGridViewBinding(dgvVendor, "SELECT 
  c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  g.DESCRIPTION AS 'Group',
  p.DESCRIPTION AS 'Pmt. Terms',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
 if(c.Inactive=0,'No','Yes') as `Inactive` 
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
WHERE c.Type = '0' ", contact_BS)

        With dgvVendor.Columns
            .Item(0).Visible = False
        End With
        ViewColumn(dgvVendor, 2) ' 2 = for vendor
    End Sub


    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        FrmContactDetails.ContactTypeId = "0"

        FrmContactDetails.IsNew = True
        FrmContactDetails.ID = 0
        FrmContactDetails.this_BS = contact_BS
        FrmContactDetails.gsDgv = dgvVendor
        FrmContactDetails.ShowDialog()
        FrmContactDetails.Dispose()
        FrmContactDetails = Nothing
        'RefreshData()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub FrmVendor_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm

        RefreshData()
        dgvVendor.Columns(1).Width = 300
        dgvVendor.Columns(2).Width = 200
        dgvVendor.Columns(3).Width = 150

    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click

        If dgvVendor.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            dgvVendor.Focus()
            Dim i As Integer = dgvVendor.CurrentRow.Index
            Dim dID As String = dgvVendor.Rows.Item(i).Cells(0).Value
            FrmContactDetails.ContactTypeId = "0"

            FrmContactDetails.IsNew = False
            FrmContactDetails.ID = dID
            FrmContactDetails.this_BS = contact_BS
            FrmContactDetails.gsDgv = dgvVendor
            FrmContactDetails.ShowDialog()
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
            'RefreshData()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvVendor.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            dgvVendor.Focus()
            Dim i As Integer = dgvVendor.CurrentRow.Index
            Dim dID As String = dgvVendor.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvVendor.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact where id='" & dID & "' limit 1;")
                DeleteNotify(Me)
                RefreshData()
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Sub DgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVendor.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvVendor, 2) ' 2 = for vendor
        ViewColumn(dgvVendor, 2) ' 2 = for vendor
    End Sub
    Private Sub SearchLoad()
        Try

            Dim strFInd As String = ""


            For I As Integer = 0 To dgvVendor.Columns.Count - 1

                If dgvVendor.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvVendor.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvVendor.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next

            contact_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TstxtFindItem_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            RefreshData()
        End If
    End Sub
    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ExportingExcel(dgvVendor, "Vendor_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub
    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub
    Private Sub DgvVendor_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvVendor.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub TsReload_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub
End Class