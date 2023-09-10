Imports System.DateTime
Public Class FrmDealer
    Public contact_BS As BindingSource
    Private Sub frmDealer_Load(sender As Object, e As EventArgs) Handles Me.Load
        TSComboBoxLoad(tsManager, " SELECT '%' as ID, 'All Manager' as `NAME` UNION SELECT ID,`NAME` FROM contact WHERE `type`='2'", "ID", "NAME")
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewRecordsToolStripMenuItem.Click
        If SecurityAccessMode(Me, True) = False Then

            Exit Sub
        End If

        frmContactDetails.ContactTypeId = 6

        frmContactDetails.IsNew = True
        frmContactDetails.ID = 0
        frmContactDetails.this_BS = contact_BS
        frmContactDetails.gsDgv = dgvDealer
        frmContactDetails.ShowDialog()
        frmContactDetails.Dispose()
        frmContactDetails = Nothing
        'RefreshData()
    End Sub
    Private Sub fRefreshData()

        Dim m As String = "%"
        Try
            m = tsManager.ComboBox.SelectedValue
        Catch ex As Exception

        End Try


        '    Dim d As Date = New Date(Val(tsYEAR.ComboBox.SelectedValue), tsMONTH.ComboBox.SelectedValue, 1)
        '   Dim F As Date = FirstDayOfMonth(d)

        '  Dim sx As String = "  (SELECT IFNULL(SUM(pp.AMOUNT_APPLIED),0) + IFNULL( SUM( pp.penalty_paid),0) FROM  payment_invoices AS pp INNER JOIN  payment AS p ON p.ID = pp.payment_ID INNER JOIN invoice AS i ON i.id = pp.invoice_id WHERE i.ID = (SELECT i.ID FROM  invoice AS i WHERE i.balance_due > '0' AND i.DEALER_ID = c.`ID` AND MONTH(i.DUE_DATE) = '" & F.Month & "' AND YEAR(i.DUE_DATE) = '" & F.Year & "'  AND i.DEALER_ID = c.`ID` AND MONTH(p.`DATE`) = '" & F.Month & "' AND YEAR(p.`DATE`) = '" & F.Year & "' limit 1) + (SELECT IFNULL(SUM(sr.`AMOUNT`),0) FROM sales_receipt AS sr WHERE MONTH(sr.date) = '" & F.Month & "' AND YEAR(sr.date) ='" & F.Year & "' AND sr.DEALER_ID = c.`ID` limit 1)) "

        LoadDataGridViewBinding(dgvDealer, "SELECT 
  c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  g.DESCRIPTION AS 'Group',
  s.name AS 'Sale Manager',
  p.DESCRIPTION AS 'Pmt. Terms',
  format(c.Credit_limit,2) AS 'Credit Limit',
  pl.DESCRIPTION AS 'Price Level',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
  c.Inactive 
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
LEFT OUTER JOIN contact AS s 
    ON c.Sales_REP_ID = s.ID 
    AND s.Type = '2' 
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
 LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '6' and IFNULL(c.Sales_REP_ID,'') like '" & m & "' and ( c.`NAME` like '%" & tstxtFindItem.Text & "%' or c.`ACCOUNT_NO` like '%" & tstxtFindItem.Text & "%') limit 3000", contact_BS)
        With dgvDealer.Columns
            .Item(0).Visible = False
        End With
        ViewColumn(dgvDealer, 28)
        ' dgvDealer.Columns("Collection Payment").DefaultCellStyle.Format = "N2"
    End Sub






    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click

        If dgvDealer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessMode(Me, False) = False Then
                Exit Sub
            End If

            dgvDealer.Focus()
            Dim i As Integer = dgvDealer.CurrentRow.Index
            Dim dID As String = dgvDealer.Rows.Item(i).Cells(0).Value
            frmContactDetails.ContactTypeId = "6"

            frmContactDetails.IsNew = False
            frmContactDetails.ID = dID
            frmContactDetails.this_BS = contact_BS
            frmContactDetails.gsDgv = dgvDealer
            frmContactDetails.ShowDialog()
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            ' RefreshData()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click
        If dgvDealer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            dgvDealer.Focus()
            Dim i As Integer = dgvDealer.CurrentRow.Index
            Dim dID As String = dgvDealer.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvDealer.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From contact where id='" & dID & "' limit 1")
                fRefreshData()
            End If

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub tsClose_Click_1(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub
    Private Sub dgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDealer.CellDoubleClick

        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvDealer, 28)

        ViewColumn(dgvDealer, 28)


    End Sub

    Private Sub tsChangeContactType_Click(sender As Object, e As EventArgs) Handles tsChangeContactType.Click
        If dgvDealer.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Dim sID As Integer = 6

        With frmChangeContactType
            .gsID = 6
            .ShowDialog()
            sID = .gsID
            .Dispose()
        End With
        If sID <> 6 Then
            Dim i As Integer = dgvDealer.CurrentRow.Index
            SqlExecuted("update contact set `TYPE` = '" & sID & "' where id = '" & dgvDealer.Rows(i).Cells(0).Value & "'")
            fRefreshData()
        End If
        frmChangeContactType = Nothing
    End Sub

    Private Sub frmDealer_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fRefreshData()
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        fRefreshData()
    End Sub

    Private Sub tsYEAR_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsYEAR_SelectedIndexChanged(sender As Object, e As EventArgs)
        fRefreshData()
    End Sub

    Private Sub tsMONTH_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsMONTH_SelectedIndexChanged(sender As Object, e As EventArgs)
        fRefreshData()
    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsManager_Click(sender As Object, e As EventArgs) Handles tsManager.Click

    End Sub

    Private Sub tsManager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tsManager.SelectedIndexChanged
        fRefreshData()
    End Sub

    Private Sub tsMONTH_LostFocus(sender As Object, e As EventArgs)
        fRefreshData()
    End Sub

    Private Sub dgvDealer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDealer.CellContentClick

    End Sub

    Private Sub CustomerListToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CustomerListToolStripMenuItem.Click
        If dgvDealer.Rows.Count <> 0 Then
            frmDealerCustomerList.gsDEALER_ID = dgvDealer.Rows(dgvDealer.CurrentRow.Index).Cells(0).Value
            frmDealerCustomerList.ShowDialog()
            frmDealerCustomerList.Dispose()
            frmDealerCustomerList = Nothing

        End If
    End Sub

    Private Sub dgvDealer_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvDealer.CellMouseDoubleClick
        If e.Button = MouseButtons.Right Then
            CustomerListToolStripMenuItem_Click(sender, e)
        End If

    End Sub

    Private Sub tstxtFindItem_Click(sender As Object, e As EventArgs) Handles tstxtFindItem.Click

    End Sub

    Private Sub tstxtFindItem_KeyDown(sender As Object, e As KeyEventArgs) Handles tstxtFindItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            fRefreshData()
        End If
    End Sub

    Private Sub tsbtnSearch_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        fRefreshData()
    End Sub
End Class