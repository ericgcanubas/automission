Public Class FrmEmployee
    Public contact_BS As BindingSource
    Private Sub fRefreshData()

        LoadDataGridViewBinding(dgvEmployee, "SELECT 
  c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  g.DESCRIPTION AS 'Group',
  s.name AS 'Sales Rep',
  p.DESCRIPTION AS 'Pmt. Terms',
  c.Credit_limit AS 'Credit Limit',
  pl.DESCRIPTION AS 'Price Level',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
  if(c.Inactive=0,'No','Yes') as `Inactive`
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
LEFT  OUTER JOIN contact AS s 
    ON c.sales_rep_id = s.ID 
    AND s.Type = '2' 
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
 LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '2'", contact_BS)

        With dgvEmployee.Columns
            .Item(0).Visible = False
            .Item(1).Width = 110
            .Item(2).Width = 140
            .Item(3).Width = 110
            .Item(4).Width = 100
            .Item(5).Width = 60
            .Item(6).Width = 60
            .Item(7).Width = 60
            .Item(8).Width = 100
            .Item(9).Width = 100
            .Item(10).Width = 60
            .Item(11).Width = 60
            .Item(12).Width = 60

        End With
        ViewColumn(dgvEmployee, 12) ' 12 = for employee
    End Sub


    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmContactDetails.ContactTypeId = "2"

        frmContactDetails.IsNew = True
        frmContactDetails.ID = 0
        frmContactDetails.gsDgv = dgvEmployee
        frmContactDetails.this_BS = contact_BS

        frmContactDetails.ShowDialog()
        frmContactDetails.Dispose()
        frmContactDetails = Nothing
        'fRefreshData()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub frmVendor_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefreshData()
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click

        If dgvEmployee.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            dgvEmployee.Focus()
            Dim i As Integer = dgvEmployee.CurrentRow.Index
            Dim dID As String = dgvEmployee.Rows.Item(i).Cells(0).Value
            frmContactDetails.ContactTypeId = "2"

            frmContactDetails.IsNew = False
            frmContactDetails.ID = dID
            frmContactDetails.gsDgv = dgvEmployee
            frmContactDetails.this_BS = contact_BS
            frmContactDetails.ShowDialog()
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            '  fRefreshData()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvEmployee.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            dgvEmployee.Focus()
            Dim i As Integer = dgvEmployee.CurrentRow.Index
            Dim dID As String = dgvEmployee.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvEmployee.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact where id='" & dID & "' limit 1;")
                DeleteNotify(Me)
                fRefreshData()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsClose_Click_1(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub
    Private Sub dgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployee.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub



    Private Sub dgvCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmployee.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvEmployee, 12) ' 12 = for employee

        ViewColumn(dgvEmployee, 12) ' 12 = for employee

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub tsbtnSearch_Click(sender As Object, e As EventArgs)
        fRefreshData()
    End Sub

    Private Sub tstxtFindItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tstxtFindItem_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            fRefreshData()
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fExport(dgvEmployee, "Employee_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub
    Private Sub fSearchload()
        Try


            Dim strFInd As String = ""


            For I As Integer = 0 To dgvEmployee.Columns.Count - 1

                If dgvEmployee.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvEmployee.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvEmployee.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next




            contact_BS.Filter = strFInd


        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmEmployee_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        '  fSearchGet()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fRefreshData()
    End Sub

    Private Sub dgvEmployee_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvEmployee.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tscmbSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsReload_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefreshData()
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub
End Class