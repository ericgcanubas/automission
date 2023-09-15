
Public Class FrmPenalty
    Private Sub FrmPenaltyInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load


        RefreshData()


    End Sub
    Private Sub RefreshData()
        fUpdatePenalty()
        Dim gsQuery As String = "SELECT 
i.`ID`,
i.`CODE` AS `Invoice No.`,
i.`Date`,
c.`NAME` AS `Name of Order`,
i.`DUE_DATE` AS `Due Date`,
FORMAT(i.`AMOUNT`,2) AS `Org. Amount`,
FORMAT( i.`BALANCE_DUE`,2) AS `Orig. Balance`,
ptm.`DESCRIPTION` AS `Penalty Type`,
CONCAT(i.penalty_rate,'%') AS `Rate %`,
FORMAT(i.`PENALTY`,2) AS `Penalty`,
(select FORMAT(IFNULL(sum(penalty_paid),0),2) from payment_invoices where invoice_id = i.ID) as `Penalty Paid`,
FORMAT(IFNULL(i.`PENALTY`, 0) + IFNULL(i.`BALANCE_DUE`, 0),2) AS `Total Balance`  
FROM
invoice AS i 
INNER JOIN contact AS c 
ON c.`ID` = i.`CUSTOMER_ID` 
INNER JOIN penalty_type_map AS ptm ON ptm.`ID` = i.`PENALTY_TYPE_ID`
WHERE i.penalty_type_id IN ('1','2','3') and i.due_date <= '" & GetDateNow() & "' "
        GS_LoadDataGridView(dgvInvoice, gsQuery)
        dgvInvoice.Columns(0).Visible = False
        dgvInvoice.Columns(0).Width = 40
        dgvInvoice.Columns("Total Balance").Width = 110
        dgvInvoice.Columns("Rate %").Width = 80
        dgvInvoice.Columns("Name of Order").Width = 100
        ' DatagridViewMode(dgvInvoice)

        ViewColumn(dgvInvoice, 35)
    End Sub
    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub
    Private Sub DgvInvoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellDoubleClick

        gsMenuSubID = 2
        gsRefresh = True
        gsDocument_Finder_ID = dgvInvoice.Rows(dgvInvoice.CurrentRow.Index).Cells(0).Value

        MenuSet()

        gsDocument_Finder_ID = 0

        If gscryRpt IsNot Nothing Then
            gscryRpt.Close()
            gscryRpt.Dispose()
            gscryRpt = Nothing
        End If

        Dim fName As String = ""
        Dim frm As New Form
        frm = GetFormModule(fName)
        Dim TPage As New TabPage(fName)
        Dim i_selected As Integer = 0

        For x As Integer = 0 To gsTabControl.Controls.Count - 1
            If gsTabControl.Controls.Item(x).Name = fName Then

                i_selected = x
                gsTabControl.Controls.RemoveAt(x)
                If gsTabControl.Controls.Count = 0 Then
                    gsTabControl.Visible = False
                End If
                Exit For
            End If


        Next

        If gsTabControl.Controls.Count <> 0 Then
            i_selected -= 1

            If i_selected > 0 Then
                gsTabControl.SelectTab(i_selected)

            End If

        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RefreshToolStripMenuItem.Click
        RefreshData()
    End Sub
    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvInvoice, 35)

        ViewColumn(dgvInvoice, 35)
    End Sub
End Class