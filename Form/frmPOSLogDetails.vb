Imports System.Data.Odbc
Public Class FrmPOSLogDetails
    Public gsID As Integer
    Dim ThisLocationID As Integer
    Dim POS_STARTING_CASH_ID As Integer
    Dim POS_CASH_COUNT_ID As Integer

    Public gsPOS_DATE_Cash_Count As Date
    Public gsPOS_DATE_Starting_Cash As Date

    Public AutoFixPOSLOG As Boolean

    Private Sub frmPOSLogDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AutoFixPOSLOG = False
        If gsAdmin_User = False Then
            btnRemoveCashCount.Visible = False
            btnUpdateCashCount.Visible = False
        End If
        fPOS_LOG_LOAD()
        fPOS_STARTING_C()
        fPOS_CASH_C()
        fTransactionLIST()
    End Sub
    Private Sub fPOS_LOG_LOAD()
        POS_STARTING_CASH_ID = 0
        POS_CASH_COUNT_ID = 0

        Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM `POS_LOG` WHERE ID = '{gsID}' limit 1;")

        If rd.Read Then
            POS_STARTING_CASH_ID = NumIsNull(rd("STARTING_CASH_ID"))
            POS_CASH_COUNT_ID = NumIsNull(rd("CASH_COUNT_ID"))

            xlblRecorded_on1.Text = TextIsNull(rd("RECORDED_ON"))
            ThisLocationID = rd("LOCATION_ID")
            lblLOG_LOCATION.Text = GetStringFieldValue("LOCATION", "ID", ThisLocationID, "NAME")
            lblPOS_MACHINE.Text = GetStringFieldValue("POS_MACHINE", "ID", rd("POS_MACHINE_ID"), "NAME")
            lblLOG_CASHIER.Text = GetStringFieldValue("CONTACT", "ID", rd("CASHIER_ID"), "NAME")

            numLOG_DISCOUNT.Value = NumIsNull(rd("DISCOUNT"))
            numLOG_RETURN.Value = NumIsNull(rd("RETURN"))
            numLOG_COUPON.Value = NumIsNull(rd("COUPON"))
            numLOG_GIFT_CERT.Value = NumIsNull(rd("GIFT_CERT"))
            numLOG_TRADE_IN.Value = NumIsNull(rd("TRADE_IN"))
            numLOG_VOID.Value = NumIsNull(rd("VOID"))

            numLOG_CASH.Value = NumIsNull(rd("CASH"))
            numLOG_CHECK.Value = NumIsNull(rd("CHECK"))
            numLOG_AMEX.Value = NumIsNull(rd("AMEX"))
            numLOG_DISCOVER.Value = NumIsNull(rd("DISCOVER"))
            numLOG_MASTER_CARD.Value = NumIsNull(rd("MASTER_CARD"))
            numLOG_VISA.Value = NumIsNull(rd("VISA"))

            numLOG_DINNERS.Value = NumIsNull(rd("DINNERS"))
            numLOG_JCB.Value = NumIsNull(rd("JCB"))
            numLOG_OTHER_CARD.Value = NumIsNull(rd("OTHER_CARD"))
            numLOG_PAIDIN.Value = NumIsNull(rd("PAIDIN"))
            numLOG_PAIDOUT.Value = NumIsNull(rd("PAIDOUT"))

            numLOG_TAXABLE_AMOUNT.Value = NumIsNull(rd("TAXABLE_AMOUNT"))
            numLOG_OUTPUT_TAX_AMOUNT.Value = NumIsNull(rd("OUTPUT_TAX_AMOUNT"))
            numLOG_NONTAXABLE_AMOUNT.Value = NumIsNull(rd("NONTAXABLE_AMOUNT"))

            lblLOG_TOTAL.Text = NumberFormatStandard(NumIsNull(rd("TOTAL")))
            lblLOG_GRAND_TOTAL.Text = NumberFormatStandard(NumIsNull(rd("GRAND_TOTAL")))
        End If



    End Sub

    Private Sub fPOS_STARTING_C()

        If POS_STARTING_CASH_ID <> 0 Then
            Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM `pos_starting_cash` where id ='{POS_STARTING_CASH_ID}' LIMIT 1")

            If rd.Read Then
                xlblRecorded_on2.Text = TextIsNull(rd("RECORDED_ON"))
                numSTARTING_AMOUNT.Value = NumIsNull(rd("AMOUNT"))

            End If
        End If
    End Sub

    Private Sub fPOS_CASH_C()
        If POS_CASH_COUNT_ID <> 0 Then

            Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM `pos_cash_count` where id ='{POS_CASH_COUNT_ID}' LIMIT 1")
            If rd.Read Then

                xlblRecorded_on3.Text = TextIsNull(rd("RECORDED_ON"))
                numCASH.Value = NumIsNull(rd("CASH"))
                numCHECK.Value = NumIsNull(rd("CHECK"))
                numCREDIT_CARD.Value = NumIsNull(rd("CREDIT_CARD"))
                numOTHER_PAYMENT.Value = NumIsNull(rd("OTHER_PAYMENT"))
                lblTOTAL.Text = NumberFormatStandard(NumIsNull(rd("TOTAL")))


            End If
            rd.Close()

        End If

        fCASH_DENOMINATION()
    End Sub
    Private Sub fCASH_DENOMINATION()

        LoadDataGridView(dgvCASH_DENOMINATION, $"SELECT cl.`ID`,cd.`DESCRIPTION` AS `DENOMINATION`,cl.`NOMINAL_VALUE` AS `NOMINAL VALUE`,cl.`COUNT`,cl.`AMOUNT` FROM pos_cash_count_lines AS cl  INNER JOIN pos_cash_denomination AS  cd ON cd.`ID` = cl.`DENOMINATION_ID` WHERE cl.`CASH_COUNT_ID` ='{POS_CASH_COUNT_ID}' ")
        dgvCASH_DENOMINATION.Columns(0).Visible = False
    End Sub
    Private Sub fTransactionLIST()
        LoadDataGridView(dgvTransaction, $"SELECT * FROM(
(SELECT s.`RECORDED_ON` AS `Recorded On`,s.`CODE` AS `Reference`, s.`Date`, c.`NAME` AS `Customer`,pm.`DESCRIPTION` AS `Payment Method`, s.`PAYMENT_REF_NO` AS `Ref No.`,s.`Amount` FROM sales_receipt AS s LEFT OUTER JOIN payment_method AS pm ON pm.`ID` = s.`PAYMENT_METHOD_ID` INNER JOIN contact AS c ON c.`ID` = s.`CUSTOMER_ID` WHERE s.STATUS <> '7' AND s.`POS_LOG_ID` = '{gsID}')
UNION ALL
(SELECT p.`RECORDED_ON` AS `Recorded On`,p.`CODE` AS `Reference`, p.`Date`, c.`NAME` AS `Customer`,pm.`DESCRIPTION` AS `Payment Method`, p.`RECEIPT_REF_NO` AS `Ref No.`,p.`Amount` FROM `payment` AS p LEFT OUTER JOIN payment_method AS pm ON pm.`ID` =  p.PAYMENT_METHOD_ID INNER JOIN contact AS c ON c.`ID` = p.`CUSTOMER_ID` WHERE p.STATUS <> '7' AND p.`POS_LOG_ID` = '{gsID}')
) AS T ORDER BY T.Date ")

        dgvTransaction.Columns("Amount").DefaultCellStyle.Format = "N2"
        dgvTransaction.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub fCal()
        Dim T As Double = numCASH.Value + numCHECK.Value + numCREDIT_CARD.Value + numOTHER_PAYMENT.Value
        lblTOTAL.Text = NumberFormatFixed(T)


    End Sub
    Private Sub BtnUpdateCashCount_Click(sender As Object, e As EventArgs) Handles btnUpdateCashCount.Click
        gsPOS_DATE = DateFormatMySql(xlblRecorded_on3.Text)

        SqlExecuted($"UPDATE pos_cash_count SET TOTAL='{lblTOTAL.Text}',CASH='{numCASH.Value}',`CHECK`='{numCHECK.Value}',CREDIT_CARD='{numCREDIT_CARD.Value}',OTHER_PAYMENT='{numOTHER_PAYMENT.Value}',NOTES='{txtNOTES.Text}' WHERE ID ='{POS_CASH_COUNT_ID}' ")
        fPOS_LOG_JOURNAL(gsID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)
        MessageBoxInfo("Successful update.")
    End Sub

    Private Sub NumCASH_ValueChanged(sender As Object, e As EventArgs) Handles numCASH.ValueChanged
        fCal()
    End Sub

    Private Sub NumCHECK_ValueChanged(sender As Object, e As EventArgs) Handles numCHECK.ValueChanged
        fCal()
    End Sub

    Private Sub NumCREDIT_CARD_ValueChanged(sender As Object, e As EventArgs) Handles numCREDIT_CARD.ValueChanged
        fCal()
    End Sub

    Private Sub NumOTHER_PAYMENT_ValueChanged(sender As Object, e As EventArgs) Handles numOTHER_PAYMENT.ValueChanged
        fCal()
    End Sub

    Private Sub btnRemoveCashCount_Click(sender As Object, e As EventArgs) Handles btnRemoveCashCount.Click

        If MessageBoxQuestion("Do you want to remove this cash count?") = True Then
            gsPOS_DATE = DateFormatMySql(xlblRecorded_on3.Text)
            fPOS_LOG_JOURNAL_DELETE(gsID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)
            SqlExecuted($"UPDATE pos_log SET CASH_COUNT_ID = null WHERE ID ='{gsID}' Limit 1")
            SqlExecuted($"UPDATE sales_receipt SET CASH_COUNT_ID = null WHERE POS_LOG_ID='{gsID}' ")
            SqlExecuted($"DELETE FROM pos_cash_count WHERE ID ='{POS_CASH_COUNT_ID}'")
            MessageBoxInfo("successful")
            fPOS_LOG_LOAD()
            fPOS_STARTING_C()
            fPOS_CASH_C()
            fTransactionLIST()
        End If

    End Sub

    Private Sub btnTransferNow_Click(sender As Object, e As EventArgs) Handles btnTransferNow.Click
        If gsAdmin_User = False Then
            MessageBoxInfo("Administrator type is require")
            Exit Sub
        End If
        With FrmPOSLogTransfer
            Dim DT As Date = CDate(xlblRecorded_on1.Text)
            .ThisPOS_DATE = DateFormatMySql(DT)
            .ThisPOSlogID = gsID
            .ThisLocationID = ThisLocationID

            .ThisPOS_STARTING_CASH_ID = POS_STARTING_CASH_ID
            .ThisPOS_Cash_Count_ID = POS_CASH_COUNT_ID

            .ShowDialog()
            If .Transfer_ClickOK = True Then
                AutoFixPOSLOG = True
            End If
            .Dispose()
        End With
        FrmPOSLogTransfer = Nothing

        If AutoFixPOSLOG = True Then

            Me.Close()
        End If
    End Sub
End Class