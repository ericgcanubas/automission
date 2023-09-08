
Imports System.Data.Odbc
Public Class FrmPOSCashCount

    Private Sub frmPOSCashCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gsCashCOUNT_AMOUNT = 0

        fLabel_Digital_S(lblTOTAL)
        xlblStartingCash.Text = NumberFormatStandard(gsStartingCash_Amount)

        If gsUseCashDenomination = True Then
            Me.Size = New Size(519, 543)
            Me.gpbCD.Visible = True
            Me.numCASH.Increment = 0
            Me.numCASH.ReadOnly = True

            Dim pnl As Panel = Panel1
            Dim num As NumericUpDown = NumericUpDown1
            Dim lbl As Label = Label6

            FlowLayoutPanel1.Controls.Clear()
            Dim rd As OdbcDataReader = SqlReader("select * from `pos_cash_denomination` where INACTIVE ='0' order by TYPE ASC,NOMINAL_VALUE DESC")
            While rd.Read
                Dim new_pnl As New Panel
                new_pnl.Name = $"pnl{rd("id")}"
                new_pnl.Size = pnl.Size
                new_pnl.Tag = rd("id")

                Dim new_num As New NumericUpDown
                new_num.Name = $"num{rd("id")}"
                new_pnl.Controls.Add(new_num)
                new_num.Size = num.Size
                new_num.TextAlign = num.TextAlign
                new_num.Maximum = num.Maximum
                new_num.Left = num.Left
                new_num.Top = num.Top
                new_num.AccessibleDescription = TextIsNull(rd("DESCRIPTION"))

                new_num.Tag = NumIsNull(rd("NOMINAL_VALUE"))
                AddHandler new_num.ValueChanged, AddressOf numCustom_ValueChanged
                AddHandler new_num.Click, AddressOf numCustom_Click

                Dim new_lbl As New Label
                new_lbl.Name = $"lbl{rd("id")}"
                new_pnl.Controls.Add(new_lbl)
                new_lbl.Font = lbl.Font
                new_lbl.Left = lbl.Left
                new_lbl.Top = lbl.Top
                new_lbl.Text = TextIsNull(rd("DESCRIPTION"))
                If NumIsNull(rd("TYPE")) = 0 Then
                    new_lbl.ForeColor = Color.DarkBlue
                Else
                    new_lbl.ForeColor = Color.Brown
                End If

                FlowLayoutPanel1.Controls.Add(new_pnl)

            End While
            rd.Close()

        Else
            Me.Size = New Size(286, 543)
            Me.gpbCD.Visible = False
            Me.numCASH.Increment = 1
            Me.numCASH.ReadOnly = False
        End If

        Me.Icon = gsIcon
        fMaterialSkin(Me)
        ClearAndRefresh(Me)
        AutoTotalFromOthers()
        fCal()


    End Sub

    Private Sub AutoTotalFromOthers()


        If fSystemSettingValue_Bool("autocomputeothers") = True Then
            numOtherPayment.Value = fgetTotalOther()
            numOtherPayment.Enabled = False
        End If


    End Sub
    Private Function fgetTotalOther() As Double
        Dim total As Double = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT  IFNULL(SUM(pmm.`AMOUNT_APPLIED`),0) AS `TOTAL` FROM payment AS p INNER JOIN `payment_multi_method` AS pmm ON pmm.`PAYMENT_ID` = p.`ID` INNER JOIN payment_method AS pm ON pm.`ID` = pmm.`PAYMENT_METHOD_ID`  WHERE p.`POS_LOG_ID` =  {gsPOS_LOG_ID} AND pm.`PAYMENT_TYPE` = 8 ")
        If rd.Read Then
            total = Val(rd("TOTAL"))
        End If

        Return total

    End Function
    Private Sub numCustom_ValueChanged(sender As Object, e As EventArgs)
        numCASH.Value = fTotalCash()
    End Sub
    Private Sub numCustom_Click(sender As Object, e As EventArgs)
        Dim num As NumericUpDown = DirectCast(sender, NumericUpDown)
        fnumPadKeyToTouch(num, num.AccessibleDescription & " Total Count ")
    End Sub
    Private Sub fCal()
        Dim T As Double = numCASH.Value + numCHECK.Value + numCreditCard.Value + numOtherPayment.Value
        Dim AMT As Double = 0
        AMT = T - gsStartingCash_Amount
        lblTOTAL.Text = NumberFormatStandard(AMT)
    End Sub
    Private Sub numCHECK_ValueChanged(sender As Object, e As EventArgs) Handles numCHECK.ValueChanged
        fCal()
    End Sub
    Private Sub numCreditCard_ValueChanged(sender As Object, e As EventArgs) Handles numCreditCard.ValueChanged
        fCal()
    End Sub
    Private Sub numOtherPayment_ValueChanged(sender As Object, e As EventArgs) Handles numOtherPayment.ValueChanged
        fCal()
    End Sub
    Private Sub numCASH_ValueChanged(sender As Object, e As EventArgs) Handles numCASH.ValueChanged
        fCal()
    End Sub
    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If NumIsNull(lblTOTAL.Text) <= 0 Then
            MessageBoxInfo("No cash collection.")
            Exit Sub
        End If

        If MessageBoxPointOfSalesYesNO("Do you want to save your cash count?") = True Then
            LOG_DATE = GetDateTimeNowSql()
            '  If DateFormatMySql(gsPOS_DATE) = DateFormatMySql(Date.Now.Date) Then

            'Else
            '   LOG_DATE = $"{DateFormatMySql(gsPOS_DATE)} 08:00:01"
            'End If

            gsCASH_COUNT_ID = ObjectTypeMapId("POS_CASH_COUNT")

            SqlExecuted($"INSERT INTO pos_cash_count SET TOTAL='{NumIsNull(lblTOTAL.Text)}',CASH='{numCASH.Value}',`CHECK`='{numCHECK.Value}',CREDIT_CARD='{numCreditCard.Value}',OTHER_PAYMENT='{numOtherPayment.Value}',NOTES='{txtNOTES.Text.Replace("'", "`")}', ID ='{gsCASH_COUNT_ID}' ,POS_MACHINE_ID = '{gsPOS_MACHINE_ID}', POSTED = '1',RECORDED_ON='{LOG_DATE}'")

            If gsUseCashDenomination = True Then
                Dim SQL As String = ""
                For N As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
                    Dim pnl As Panel = FlowLayoutPanel1.Controls(N)
                    Dim num As NumericUpDown = pnl.Controls($"num{pnl.Tag}")
                    If num.Value <> 0 Then
                        Dim CD_ID As Integer = ObjectTypeMapId("POS_CASH_COUNT_LINES")
                        Dim THIS_AMOUNT As Double = (num.Value * num.Tag)
                        SqlExecuted($"INSERT INTO pos_cash_count_lines SET ID='{CD_ID}',CASH_COUNT_ID='{gsCASH_COUNT_ID}',DENOMINATION_ID='{pnl.Tag}',NOMINAL_VALUE='{NumIsNull(num.Tag)}',COUNT='{num.Value}',AMOUNT='{THIS_AMOUNT}';")
                    End If
                Next


            End If

            SqlExecuted($"UPDATE pos_log SET CASH_COUNT_ID = '{gsCASH_COUNT_ID}' WHERE ID ='{gsPOS_LOG_ID}' Limit 1")

            If gsPOS_TYPE = 0 Then
                SqlExecuted($"UPDATE sales_receipt SET CASH_COUNT_ID ='{gsCASH_COUNT_ID}' WHERE POS_LOG_ID='{gsPOS_LOG_ID}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' ")
            ElseIf gsPOS_TYPE = 2 Then
                SqlExecuted($"UPDATE payment SET CASH_COUNT_ID ='{gsCASH_COUNT_ID}' WHERE POS_LOG_ID='{gsPOS_LOG_ID}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' ")
            End If


            fPOS_LOG_JOURNAL(gsPOS_LOG_ID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)

            gsCashCOUNT_AMOUNT = NumIsNull(lblTOTAL.Text)

            If gsCashCountDisplayDiscripancy = True Then

                frmCashCountConfirm.ShowDialog()
                frmCashCountConfirm.Dispose()
                frmCashCountConfirm = Nothing
            Else
                MessageBoxInfo("Successfully")
            End If

            Me.Close()
        End If
    End Sub
    Private Function fTotalCash() As Double
        Dim ThisAmount As Double = 0
        If gsUseCashDenomination = True Then
            For N As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
                Dim pnl As Panel = FlowLayoutPanel1.Controls(N)
                Dim num As NumericUpDown = pnl.Controls($"num{pnl.Tag}")
                ThisAmount = ThisAmount + (num.Value * NumIsNull(num.Tag))
            Next
        End If

        Return ThisAmount
    End Function
    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub txtNOTES_TextChanged(sender As Object, e As EventArgs) Handles txtNOTES.TextChanged

    End Sub

    Private Sub txtNOTES_Click(sender As Object, e As EventArgs) Handles txtNOTES.Click
        fKeyBoardToTouch(txtNOTES, "NOTES")
    End Sub

    Private Sub numCASH_Click(sender As Object, e As EventArgs) Handles numCASH.Click
        If gsUseCashDenomination = False Then
            fnumPadKeyToTouch(numCASH, "CASH")
        End If

    End Sub

    Private Sub numCreditCard_KeyDown(sender As Object, e As KeyEventArgs) Handles numCreditCard.KeyDown

    End Sub

    Private Sub numCHECK_Click(sender As Object, e As EventArgs) Handles numCHECK.Click
        fnumPadKeyToTouch(numCHECK, "CHECK")
    End Sub

    Private Sub numOtherPayment_Click(sender As Object, e As EventArgs) Handles numOtherPayment.Click
        fnumPadKeyToTouch(numOtherPayment, "OTHER PAYMENT")
    End Sub

    Private Sub numCreditCard_Click(sender As Object, e As EventArgs) Handles numCreditCard.Click
        fnumPadKeyToTouch(numCreditCard, "CREDIT CARD")
    End Sub
End Class