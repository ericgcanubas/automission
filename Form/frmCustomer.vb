Public Class FrmCustomer
    Public contact_BS As BindingSource

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefreshData()
        dgvCustomer.Columns(1).Width = 150
        dgvCustomer.Columns(2).Width = 200
        dgvCustomer.Columns(3).Width = 150


    End Sub
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs)


        'RefreshData()
    End Sub
    Private Sub fRefreshData()

        LoadDataGridViewBinding(dgvCustomer, "SELECT 
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
  if(c.Inactive=0,'No','Yes') as `Inactive` 
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





    Private Sub dgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellDoubleClick
        tsUpdate.PerformClick()
    End Sub

    Private Sub dgvCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub frmCustomer_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub

    Private Sub frmCustomer_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If gsHotKey = True Then
            gsHotKey = False

            NewRecordsToolStripMenuItem_Click(sender, e)
        End If
    End Sub




    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ExportingExcel(dgvCustomer, "Customer_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub
    Private Sub fSearchload()
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



    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub tsbtnSearch_Click(sender As Object, e As EventArgs)
        fSearchload()
    End Sub

    Private Sub frmCustomer_Shown(sender As Object, e As EventArgs) Handles Me.Shown



    End Sub

    Private Sub dgvCustomer_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCustomer.CellContentClick

    End Sub

    Private Sub dgvCustomer_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvCustomer.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsTxtSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsCreate_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmContactDetails.ContactTypeId = "1"
        frmContactDetails.IsNew = True
        frmContactDetails.ID = 0
        frmContactDetails.gsDgv = dgvCustomer
        frmContactDetails.this_BS = contact_BS
        frmContactDetails.ShowDialog()
        frmContactDetails.Dispose()
        frmContactDetails = Nothing
    End Sub

    Private Sub tsReload_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        fRefreshData()
    End Sub

    Private Sub tsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        fSearchload()
    End Sub

    Private Sub tsColumn_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvCustomer, 1)

        ViewColumn(dgvCustomer, 1)
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvCustomer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If
            dgvCustomer.Focus()
            Dim i As Integer = dgvCustomer.CurrentRow.Index
            Dim dID As String = dgvCustomer.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvCustomer.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact where id='" & dID & "'")
                fRefreshData()
            End If

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub tsUpdate_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvCustomer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If

            dgvCustomer.Focus()
            Dim i As Integer = dgvCustomer.CurrentRow.Index
            Dim dID As String = dgvCustomer.Rows.Item(i).Cells(0).Value
            frmContactDetails.ContactTypeId = "1"

            frmContactDetails.IsNew = False
            frmContactDetails.ID = dID
            frmContactDetails.this_BS = contact_BS
            frmContactDetails.gsDgv = dgvCustomer
            frmContactDetails.ShowDialog()
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            ' RefreshData()
        Catch ex As Exception

        End Try

    End Sub
End Class