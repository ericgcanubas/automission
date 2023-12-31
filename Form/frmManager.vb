﻿Public Class FrmManager
    Public contact_BS As BindingSource
    Private Sub frmManager_Load(sender As Object, e As EventArgs) Handles Me.Load


    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub
    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRecordsToolStripMenuItem.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If

        frmContactDetails.ContactTypeId = "5"

        frmContactDetails.IsNew = True
        frmContactDetails.ID = 0
        frmContactDetails.ShowDialog()
        frmContactDetails.Dispose()
        frmContactDetails = Nothing
        fRefreshData()
    End Sub
    Private Sub fRefreshData()

        GS_LoadDataGridView(dgvManager, "SELECT 
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
  c.Inactive 
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
WHERE c.Type = '5'")
        With dgvManager.Columns
            .Item(0).Visible = False

        End With
        ViewColumn(dgvManager, 27)
    End Sub






    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click

        If dgvManager.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If

        If SecurityAccessMode(Me, False) = False Then
            Exit Sub
        End If

        Try
            dgvManager.Focus()
            Dim i As Integer = dgvManager.CurrentRow.Index
            Dim dID As String = dgvManager.Rows.Item(i).Cells(0).Value
            frmContactDetails.ContactTypeId = "5"

            frmContactDetails.IsNew = False
            frmContactDetails.ID = dID
            frmContactDetails.ShowDialog()
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            fRefreshData()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvManager.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If
            dgvManager.Focus()
            Dim i As Integer = dgvManager.CurrentRow.Index
            Dim dID As String = dgvManager.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvManager.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact where id='" & dID & "'")
                fRefreshData()
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub tsClose_Click_1(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub
    Private Sub dgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvManager.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvManager, 27)

        ViewColumn(dgvManager, 27)


    End Sub

    Private Sub tsChangeContactType_Click(sender As Object, e As EventArgs) Handles tsChangeContactType.Click
        If dgvManager.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Dim sID As Integer = 5

        With frmChangeContactType
            .gsID = 5
            .ShowDialog()
            sID = .gsID
            .Dispose()
        End With
        If sID <> 5 Then
            Dim i As Integer = dgvManager.CurrentRow.Index
            SqlExecuted("update contact set `TYPE` = '" & sID & "' where id = '" & dgvManager.Rows(i).Cells(0).Value & "'")
            fRefreshData()
        End If
        frmChangeContactType = Nothing
    End Sub

    Private Sub frmManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fRefreshData()
    End Sub
End Class