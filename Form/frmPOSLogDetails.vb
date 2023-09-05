Imports System.Data.Odbc
Public Class frmPOSLogDetails
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

        Dim rd As OdbcDataReader = fReader($"SELECT * FROM `POS_LOG` WHERE ID = '{gsID}' limit 1;")

        If rd.Read Then
            POS_STARTING_CASH_ID = fNumisNULL(rd("STARTING_CASH_ID"))
            POS_CASH_COUNT_ID = fNumisNULL(rd("CASH_COUNT_ID"))

            xlblRecorded_on1.Text = fTextisNULL(rd("RECORDED_ON"))
            ThisLocationID = rd("LOCATION_ID")
            lblLOG_LOCATION.Text = fGetFieldValue("LOCATION", "ID", ThisLocationID, "NAME")
            lblPOS_MACHINE.Text = fGetFieldValue("POS_MACHINE", "ID", rd("POS_MACHINE_ID"), "NAME")
            lblLOG_CASHIER.Text = fGetFieldValue("CONTACT", "ID", rd("CASHIER_ID"), "NAME")

            numLOG_DISCOUNT.Value = fNumisNULL(rd("DISCOUNT"))
            numLOG_RETURN.Value = fNumisNULL(rd("RETURN"))
            numLOG_COUPON.Value = fNumisNULL(rd("COUPON"))
            numLOG_GIFT_CERT.Value = fNumisNULL(rd("GIFT_CERT"))
            numLOG_TRADE_IN.Value = fNumisNULL(rd("TRADE_IN"))
            numLOG_VOID.Value = fNumisNULL(rd("VOID"))

            numLOG_CASH.Value = fNumisNULL(rd("CASH"))
            numLOG_CHECK.Value = fNumisNULL(rd("CHECK"))
            numLOG_AMEX.Value = fNumisNULL(rd("AMEX"))
            numLOG_DISCOVER.Value = fNumisNULL(rd("DISCOVER"))
            numLOG_MASTER_CARD.Value = fNumisNULL(rd("MASTER_CARD"))
            numLOG_VISA.Value = fNumisNULL(rd("VISA"))

            numLOG_DINNERS.Value = fNumisNULL(rd("DINNERS"))
            numLOG_JCB.Value = fNumisNULL(rd("JCB"))
            numLOG_OTHER_CARD.Value = fNumisNULL(rd("OTHER_CARD"))
            numLOG_PAIDIN.Value = fNumisNULL(rd("PAIDIN"))
            numLOG_PAIDOUT.Value = fNumisNULL(rd("PAIDOUT"))

            numLOG_TAXABLE_AMOUNT.Value = fNumisNULL(rd("TAXABLE_AMOUNT"))
            numLOG_OUTPUT_TAX_AMOUNT.Value = fNumisNULL(rd("OUTPUT_TAX_AMOUNT"))
            numLOG_NONTAXABLE_AMOUNT.Value = fNumisNULL(rd("NONTAXABLE_AMOUNT"))

            lblLOG_TOTAL.Text = fNumFormatStandard(fNumisNULL(rd("TOTAL")))
            lblLOG_GRAND_TOTAL.Text = fNumFormatStandard(fNumisNULL(rd("GRAND_TOTAL")))
        End If



    End Sub

    Private Sub fPOS_STARTING_C()

        If POS_STARTING_CASH_ID <> 0 Then
            Dim rd As OdbcDataReader = fReader($"SELECT * FROM `pos_starting_cash` where id ='{POS_STARTING_CASH_ID}' LIMIT 1")

            If rd.Read Then
                xlblRecorded_on2.Text = fTextisNULL(rd("RECORDED_ON"))
                numSTARTING_AMOUNT.Value = fNumisNULL(rd("AMOUNT"))

            End If
        End If
    End Sub

    Private Sub fPOS_CASH_C()
        If POS_CASH_COUNT_ID <> 0 Then

            Dim rd As OdbcDataReader = fReader($"SELECT * FROM `pos_cash_count` where id ='{POS_CASH_COUNT_ID}' LIMIT 1")
            If rd.Read Then

                xlblRecorded_on3.Text = fTextisNULL(rd("RECORDED_ON"))
                numCASH.Value = fNumisNULL(rd("CASH"))
                numCHECK.Value = fNumisNULL(rd("CHECK"))
                numCREDIT_CARD.Value = fNumisNULL(rd("CREDIT_CARD"))
                numOTHER_PAYMENT.Value = fNumisNULL(rd("OTHER_PAYMENT"))
                lblTOTAL.Text = fNumFormatStandard(fNumisNULL(rd("TOTAL")))


            End If
            rd.Close()

        End If

        fCASH_DENOMINATION()
    End Sub
    Private Sub fCASH_DENOMINATION()

        fDataGridView(dgvCASH_DENOMINATION, $"SELECT cl.`ID`,cd.`DESCRIPTION` AS `DENOMINATION`,cl.`NOMINAL_VALUE` AS `NOMINAL VALUE`,cl.`COUNT`,cl.`AMOUNT` FROM pos_cash_count_lines AS cl  INNER JOIN pos_cash_denomination AS  cd ON cd.`ID` = cl.`DENOMINATION_ID` WHERE cl.`CASH_COUNT_ID` ='{POS_CASH_COUNT_ID}' ")
        dgvCASH_DENOMINATION.Columns(0).Visible = False
    End Sub
    Private Sub fTransactionLIST()
        fDataGridView(dgvTransaction, $"SELECT * FROM(
(SELECT s.`RECORDED_ON` AS `Recorded On`,s.`CODE` AS `Reference`, s.`Date`, c.`NAME` AS `Customer`,pm.`DESCRIPTION` AS `Payment Method`, s.`PAYMENT_REF_NO` AS `Ref No.`,s.`Amount` FROM sales_receipt AS s LEFT OUTER JOIN payment_method AS pm ON pm.`ID` = s.`PAYMENT_METHOD_ID` INNER JOIN contact AS c ON c.`ID` = s.`CUSTOMER_ID` WHERE s.STATUS <> '7' AND s.`POS_LOG_ID` = '{gsID}')
UNION ALL
(SELECT p.`RECORDED_ON` AS `Recorded On`,p.`CODE` AS `Reference`, p.`Date`, c.`NAME` AS `Customer`,pm.`DESCRIPTION` AS `Payment Method`, p.`RECEIPT_REF_NO` AS `Ref No.`,p.`Amount` FROM `payment` AS p LEFT OUTER JOIN payment_method AS pm ON pm.`ID` =  p.PAYMENT_METHOD_ID INNER JOIN contact AS c ON c.`ID` = p.`CUSTOMER_ID` WHERE p.STATUS <> '7' AND p.`POS_LOG_ID` = '{gsID}')
) AS T ORDER BY T.Date ")

        dgvTransaction.Columns("Amount").DefaultCellStyle.Format = "N2"
        dgvTransaction.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub
    Private Sub fCal()
        Dim T As Double = numCASH.Value + numCHECK.Value + numCREDIT_CARD.Value + numOTHER_PAYMENT.Value
        lblTOTAL.Text = fNumFormatFixed(T)


    End Sub
    Private Sub BtnUpdateCashCount_Click(sender As Object, e As EventArgs) Handles btnUpdateCashCount.Click
        gsPOS_DATE = fDateFormatMYSQL(xlblRecorded_on3.Text)

        fExecutedOnly($"UPDATE pos_cash_count SET TOTAL='{lblTOTAL.Text}',CASH='{numCASH.Value}',`CHECK`='{numCHECK.Value}',CREDIT_CARD='{numCREDIT_CARD.Value}',OTHER_PAYMENT='{numOTHER_PAYMENT.Value}',NOTES='{txtNOTES.Text}' WHERE ID ='{POS_CASH_COUNT_ID}' ")
        fPOS_LOG_JOURNAL(gsID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)
        fMessageboxInfo("Successful update.")
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

        If fMessageBoxQuestion("Do you want to remove this cash count?") = True Then
            gsPOS_DATE = fDateFormatMYSQL(xlblRecorded_on3.Text)
            fPOS_LOG_JOURNAL_DELETE(gsID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)
            fExecutedOnly($"UPDATE pos_log SET CASH_COUNT_ID = null WHERE ID ='{gsID}' Limit 1")
            fExecutedOnly($"UPDATE sales_receipt SET CASH_COUNT_ID = null WHERE POS_LOG_ID='{gsID}' ")
            fExecutedOnly($"DELETE FROM pos_cash_count WHERE ID ='{POS_CASH_COUNT_ID}'")
            fMessageboxInfo("successful")
            fPOS_LOG_LOAD()
            fPOS_STARTING_C()
            fPOS_CASH_C()
            fTransactionLIST()
        End If

    End Sub

    Private Sub btnTransferNow_Click(sender As Object, e As EventArgs) Handles btnTransferNow.Click
        If gsAdmin_User = False Then
            fMessageboxInfo("Administrator type is require")
            Exit Sub
        End If
        With FrmPOSLogTransfer
            Dim DT As Date = CDate(xlblRecorded_on1.Text)
            .ThisPOS_DATE = fDateFormatMYSQL(DT)
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