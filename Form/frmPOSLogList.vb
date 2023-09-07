Public Class frmPOSLogList
    Public item_BS As BindingSource
    Dim firstLoad As Boolean = True
    Private Sub fRefreshData()

        LoadDataGridViewBinding(dgvLog, $"SELECT 
  p.`ID`,
  p.`RECORDED_ON` AS `Recorded On`,
  p.TRANSACTION_DATE as `Date Entry`,
  c.`NAME` AS `Cashier`,
  l.`NAME` AS `Location`,
  m.`NAME` AS `Pos Machine`,
 Format( s.`AMOUNT`,2) AS `Starting Cash`,
 Format( cc.`TOTAL`,2) AS `Cash Count`,
 Format(p.`TOTAL`,2) as `TOTAL`,
 Format(  p.`GRAND_TOTAL`,2)  AS `Grand Total`,
  p.`STARTING_RECEIPT_NO` AS `Start No.`,
  p.`ENDING_RECEIPT_NO` AS `End No.`,
  p.`TRANSACTION_COUNT` AS `Trans Count`
   
FROM

  pos_log AS p 
  INNER JOIN contact AS c 
    ON c.`ID` = p.`CASHIER_ID` 
  INNER JOIN location AS l 
    ON l.`ID` = p.`LOCATION_ID` 
    INNER JOIN pos_machine AS m
    ON m.`ID` = p.`POS_MACHINE_ID`
    right outer JOIN pos_starting_cash AS s 
    ON s.`ID`  = p.`STARTING_CASH_ID`
    LEFT OUTER JOIN pos_cash_count AS cc 
    ON cc.`ID` = p.`CASH_COUNT_ID`
    WHERE p.`LOCATION_ID` like '{tscmbLocation.ComboBox.SelectedValue}'
    ORDER BY p.`RECORDED_ON` desc", item_BS)

        ViewColumn(dgvLog, 46)

        fCashCountVsTotal()
        With dgvLog.Columns
            .Item(0).Visible = True
        End With
    End Sub

    Private Sub fCashCountVsTotal()

        For I As Integer = 0 To dgvLog.Rows.Count - 1
            With dgvLog.Rows(I)
                If NumIsNull(.Cells("TOTAL").Value) <> NumIsNull(.Cells("Cash Count").Value) Then
                    .DefaultCellStyle.ForeColor = Color.Red
                End If

            End With
        Next
    End Sub



    Private Sub fRefreshLocation()
        TSComboBoxLoad(tscmbLocation, "SELECT `id`,`name` FROM location UNION SELECT '%' AS `id`,'All Location' AS `NAME` ORDER BY `ID`", "ID", "NAME")
    End Sub

    Private Sub frmCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load

        fRefreshLocation()
        Dim loc_value As String = gsDefault_LOCATION_ID
        tscmbLocation.ComboBox.SelectedValue = IIf(loc_value = "0", "%", loc_value)
        tscmbLocation.Enabled = fLockLocation()
        firstLoad = False

        RecomputeJournalToolStripMenuItem.Visible = gsAdmin_User
        fRefreshData()
    End Sub





    Private Sub tsClose_Click_1(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub


    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs)

    End Sub



    Private Sub dgvCustomer_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLog.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvLog, 46)

        ViewColumn(dgvLog, 46)


    End Sub

    Private Sub frmChartOfAccount_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'With dgvAccount.Columns
        '    .Item("Name").Width = 400
        '    .Item("INACTIVE").Width = 50
        '    .Item("Line No.").Width = 60
        'End With

    End Sub
    Private Sub fSearchload()
        Try

            Dim strFInd As String = ""

            For I As Integer = 0 To dgvLog.Columns.Count - 1

                If dgvLog.Columns(I).Visible = True Then

                    If dgvLog.Columns(I).HeaderText.ToUpper = "INACTIVE" Then
                        Exit For
                    End If

                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvLog.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvLog.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

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



    Private Sub dgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvLog.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tscmbLocation_Click(sender As Object, e As EventArgs) Handles tscmbLocation.Click

    End Sub

    Private Sub tscmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbLocation.SelectedIndexChanged
        If firstLoad = False Then
            fRefreshData()
        End If
    End Sub

    Private Sub RecomputeJournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RecomputeJournalToolStripMenuItem.Click
        CursorLoadingOn(True)
        For I As Integer = 0 To dgvLog.Rows.Count - 1
            With dgvLog.Rows(I)
                gsPOS_DATE = DateFormatMySql(.Cells(1).Value)
                gsPOS_LOG_ID = .Cells(0).Value
            End With

            fPOS_LOG_JOURNAL(gsPOS_LOG_ID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)

        Next
        CursorLoadingOn(False)

    End Sub

    Private Sub TsbtnSearch_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        fRefreshData()
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        fExport(dgvLog, $"{tscmbLocation.Text} POS_LOG_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub

    Private Sub dgvLog_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvLog.KeyDown
        If (e.KeyCode = Keys.F1 AndAlso e.Modifiers = Keys.Control) Then
            For I As Integer = 0 To dgvLog.Rows.Count - 1
                With dgvLog.Rows(I)
                    fsubStartFixed(.Cells("ID").Value, .Cells(11).Value, .Cells(10).Value)
                End With

            Next
            MessageBoxInfo("done")
            fRefreshData()
        End If

    End Sub
    Private Sub fsubStartFixed(ByVal log_id As Integer, ByVal T_COUNT As Integer, ByVal T_END As Integer)
        Dim S As Integer = T_END - (T_COUNT - 1)
        SqlExecuted($"UPDATE  pos_log SET STARTING_RECEIPT_NO = '{S}' WHERE ID ='{log_id}' limit 1")
    End Sub

    Private Sub dgvLog_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLog.CellDoubleClick
        If dgvLog.Rows.Count = 0 Then

            Exit Sub
        End If

        With frmPOSLogDetails
            .gsID = dgvLog.Rows(e.RowIndex).Cells(0).Value
            .ShowDialog()
            If .AutoFixPOSLOG = True Then

                If gsAdmin_User = True Then
                    MessageBoxInfo("Please perform POS Log Computation.")
                    frmPOS_LOG_STATING_COUNT_FIXED.ShowDialog()
                    frmPOS_LOG_STATING_COUNT_FIXED.Dispose()
                    frmPOS_LOG_STATING_COUNT_FIXED = Nothing


                End If
            End If
            .Dispose()
        End With
        frmPOSLogDetails = Nothing
    End Sub
End Class