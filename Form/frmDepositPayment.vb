Public Class frmDepositPayment
    Public gsOK As Boolean = False
    Public gsLocation_ID As Integer
    Private Sub frmDepositPayment_Load(sender As Object, e As EventArgs) Handles Me.Load
        fBackGroundImageStyle(Me)

        fRefreshLocation()
        fRefreshMethod()
        Dim loc_value As String = gsDefault_LOCATION_ID
        tscmbLocation.ComboBox.SelectedValue = IIf(loc_value = "0", "*", loc_value)


        fRefreshList()
        gsOK = False
    End Sub
    Private Sub fRefreshLocation()
        fTSComboBox(tscmbLocation, "SELECT `id`,`name` FROM location UNION SELECT '' AS `id`,'All Location' AS `NAME` FROM location ORDER BY `ID`", "ID", "NAME")
    End Sub
    Private Sub fRefreshMethod()
        fTSComboBox(tscmbPaymentMethod, " select '' as `ID`  , 'All Payment Methods' as DESCRIPTION  union select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
    End Sub
    Private Sub fRefreshList()
        fCursorLoadingOn(True)
        Dim dt As New DataGridViewCheckBoxColumn
        dt.HeaderText = " "
        dt.Name = "select"
        dgvAvailable.Columns.Clear()

        fDataGridView(dgvAvailable, "SELECT * FROM (SELECT '41' AS `SOT`,p.`ID` AS `SOI`, p.Date,'Payment' AS `Type`,p.`CODE` AS `Reference`,p.`PAYMENT_METHOD_ID`, (SELECT Description FROM payment_method  WHERE ID = p.`PAYMENT_METHOD_ID` LIMIT 1 ) AS `Payment Method`,p.`CUSTOMER_ID` , (SELECT `Name` FROM contact WHERE ID = p.`CUSTOMER_ID` LIMIT 1 ) AS `Received From`,p.`LOCATION_ID`,(SELECT `NAME` FROM location WHERE id = p.`LOCATION_ID` LIMIT 1) AS `Location`, p.`Amount` FROM payment AS p WHERE p.POS_LOG_ID = NULL and  p.`DEPOSITED` = '0' and  p.`PAYMENT_METHOD_ID`  like '%" & tscmbPaymentMethod.ComboBox.SelectedValue & "%' and p.`location_id` like '%" & tscmbLocation.ComboBox.SelectedValue & "%' and p.UNDEPOSITED_FUNDS_ACCOUNT_ID IS NOT NULL UNION 
SELECT '52' AS `SOT`,p.`ID` AS `SOI`, p.Date,'Sales Receipt' AS `Type`,p.`CODE` AS `Reference`,p.`PAYMENT_METHOD_ID`, (SELECT Description FROM payment_method  WHERE ID = p.`PAYMENT_METHOD_ID` LIMIT 1 ) AS `Payment Method`,p.`CUSTOMER_ID` , (SELECT `Name` FROM contact WHERE ID = p.`CUSTOMER_ID` LIMIT 1 ) AS `Received From`,p.`LOCATION_ID`,(SELECT `NAME` FROM location WHERE id = p.`LOCATION_ID` LIMIT 1) AS `Location`, p.`Amount` FROM sales_receipt AS p WHERE p.POS_LOG_ID = null and p.`DEPOSITED` = '0' and  p.`PAYMENT_METHOD_ID`  like '%" & tscmbPaymentMethod.ComboBox.SelectedValue & "%' and p.`location_id` like '%" & tscmbLocation.ComboBox.SelectedValue & "%' and p.UNDEPOSITED_FUNDS_ACCOUNT_ID IS NOT NULL UNION 
SELECT '64' AS `SOT`,p.`ID` AS `SOI`, date(p.RECORDED_ON) as Date,'POS Log' AS `Type`,'' AS `Reference`, '' AS `PAYMENT_METHOD_ID`, '' AS `Payment Method`, '' as `CUSTOMER_ID` , '' AS `Received From`,p.`LOCATION_ID`,(SELECT `NAME` FROM location WHERE id = p.`LOCATION_ID` LIMIT 1) AS `Branch`, cc.TOTAL as `Amount` FROM pos_log AS p inner join pos_cash_count as cc on cc.id = p.cash_count_id WHERE p.`DEPOSITED` = '0' and p.`location_id` like '%" & tscmbLocation.ComboBox.SelectedValue & "%' and p.UNDEPOSITED_FUNDS_ACCOUNT_ID IS NOT NULL)  AS t WHERE t.AMOUNT <>  '0'  ORDER BY t.`Date` DESC")

        With dgvAvailable.Columns
            .Insert(0, dt)
            .Item("select").Width = 20
            .Item("SOT").Visible = False
            .Item("SOI").Visible = False
            .Item("CUSTOMER_ID").Visible = False
            .Item("PAYMENT_METHOD_ID").Visible = False
            .Item("LOCATION_ID").Visible = False
            .Item("Received From").Width = 150
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
        End With

        fCursorLoadingOn(False)
    End Sub



    Private Sub tsOk_Click(sender As Object, e As EventArgs) Handles tsOk.Click
        gsOK = False
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            If dgvAvailable.Rows(i).Cells(0).Value = True Then
                gsOK = True
                Exit For
            End If
        Next

        If gsOK = False Then
            fMessageboxInfo("Payment not selected")
            Exit Sub
        End If
        gsLocation_ID = Val(tscmbLocation.ComboBox.SelectedValue)
        Me.Close()
    End Sub

    Private Sub dgvAvailable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellContentClick

    End Sub

    Private Sub dgvAvailable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellClick
        If e.ColumnIndex = 0 Then

            If dgvAvailable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                dgvAvailable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = False
            Else
                dgvAvailable.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True
            End If

        End If
        fCal_Total()
    End Sub



    Private Sub tsClear_Click(sender As Object, e As EventArgs) Handles tsClear.Click
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            dgvAvailable.Rows(i).Cells(0).Value = False
        Next
        fCal_Total()
    End Sub

    Private Sub tscmbPaymentMethod_Click(sender As Object, e As EventArgs) Handles tscmbPaymentMethod.Click

    End Sub

    Private Sub tscmbPaymentMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbPaymentMethod.SelectedIndexChanged
        Try
            fRefreshList()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tscmbLocation_Click(sender As Object, e As EventArgs) Handles tscmbLocation.Click

    End Sub

    Private Sub tscmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbLocation.SelectedIndexChanged
        Try
            fRefreshList()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub fCal_Total()
        Dim T As Double = 0
        For I As Integer = 0 To dgvAvailable.Rows.Count - 1
            With dgvAvailable.Rows(I)
                If .Cells("select").Value = True Then
                    T = T + .Cells("AMOUNT").Value
                End If

            End With

        Next
        lblTotal.Text = fNumFormatStandard(T)

    End Sub

    Private Sub tsCheckSelectedDate_Click(sender As Object, e As EventArgs) Handles tsCheckSelectedDate.Click
        With frmDateRangeSelect


            .ShowDialog()
            If .gsOK = True Then

                Dim DT_From As Date = .DateFrom
                Dim DT_To As Date = .DateTo

                For I As Integer = 0 To dgvAvailable.Rows.Count - 1
                    With dgvAvailable.Rows(I)
                        Dim DT As Date = .Cells("DATE").Value
                        If DT.Date >= DT_From.Date And DT.Date <= DT_To.Date Then
                            .Cells("select").Value = True
                        Else
                            .Cells("select").Value = False
                        End If
                    End With




                Next

            End If
            .Dispose()
        End With
        frmDateRangeSelect = Nothing
        fCal_Total()
    End Sub

    Private Sub tsCheck_Click(sender As Object, e As EventArgs) Handles tsCheck.Click
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            dgvAvailable.Rows(i).Cells(0).Value = True
        Next
        fCal_Total()
    End Sub
End Class