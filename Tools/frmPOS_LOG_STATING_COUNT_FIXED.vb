Imports System.Data.Odbc
Public Class frmPOS_LOG_STATING_COUNT_FIXED


    Private Sub frmPOS_LOG_STATING_COUNT_FIXED_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(cmbLOCATION_ID, "SELECT ID,NAME FROM LOCATION ", "ID", "NAME")
        GS_ComboBoxLoad(cmbPOS_MACHINE_ID, "SELECT ID,NAME FROM POS_MACHINE ", "ID", "NAME")
        GS_ComboBoxLoad(cmbCASHIER_ID, "SELECT ID,NAME FROM CONTACT WHERE `TYPE` ='2' ", "ID", "NAME")
    End Sub

    Private Sub btnRUN_Click(sender As Object, e As EventArgs) Handles btnRUN.Click
UP_NOW:
        ' GS_DoEvents()
        'GS_CursorLoadingOn(True)
        Dim dt As Date = dtpDATE.Value
        Dim dn As Date = Date.Now
        If dt <= dn Then
            fRunning(dt)
        Else
            ' GS_CursorLoadingOn(False)
            MessageBoxInfo("Done")
            Exit Sub
        End If


        dt = dt.AddDays(1)
        dtpDATE.Value = dt
        GoTo UP_NOW
    End Sub
    Private Sub fRunning(ByVal dt As Date)
        gsPOS_DATE = dt
        gsPOS_LOG_ID = 0
        gsCashier_ID = cmbCASHIER_ID.SelectedValue
        gsPOS_MACHINE_ID = cmbPOS_MACHINE_ID.SelectedValue
        gsDRAWER_ACCOUNT_ID = GF_GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")
        gsDefault_LOCATION_ID = cmbLOCATION_ID.SelectedValue
        Dim rd As OdbcDataReader
        If chkRESTO_MODE.Checked = False Then
            rd = SqlReader($"SELECT *  FROM SALES_RECEIPT WHERE  `DATE`='{DateFormatMySql(dt)}' and `LOCATION_ID` ='{gsDefault_LOCATION_ID}'")
        Else
            rd = SqlReader($"SELECT *  FROM PAYMENT WHERE  `DATE`='{DateFormatMySql(dt)}' and `LOCATION_ID` ='{gsDefault_LOCATION_ID}'")
        End If

        If rd.Read Then


            'POS_STARTING_CASH
            'fSTARTING_CASH(dt)
            Dim rd_pos_start As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}' and  CASHIER_ID = '{gsCashier_ID}'  and DATE(RECORDED_ON) ='{DateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' ")
            While rd_pos_start.Read()

                gsPOS_LOG_ID = GF_NumIsNull(rd_pos_start("ID"))
                gsSTARTING_CASH_ID = GF_NumIsNull(rd_pos_start("STARTING_CASH_ID"))
                gsENDING_RECEIPT_NO = GF_NumIsNull(rd_pos_start("ENDING_RECEIPT_NO"))
                gsCASH_COUNT_ID = GF_NumIsNull(rd_pos_start("CASH_COUNT_ID"))


                If gsPOS_LOG_ID <> 0 Then

                    If chkRESTO_MODE.Checked = False Then
                        SqlExecuted($" UPDATE sales_receipt SET `CASHIER_ID` ='{gsCashier_ID}',POS_LOG_ID ='{gsPOS_LOG_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',POS_POSTED='1' WHERE `DATE`='{DateFormatMySql(gsPOS_DATE)}' and `LOCATION_ID` ='{cmbLOCATION_ID.SelectedValue}' ")

                    Else
                        SqlExecuted($" UPDATE payment SET POS_LOG_ID ='{gsPOS_LOG_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}' WHERE `DATE`='{DateFormatMySql(gsPOS_DATE)}' and `LOCATION_ID` ='{cmbLOCATION_ID.SelectedValue}' ")
                    End If

                    D_PLOG(gsPOS_DATE)
                    If chkRESTO_MODE.Checked = False Then
                        GS_CollectPosLog()
                    Else
                        GS_CollectPosLogResto()
                    End If

                    D_PLOG(gsPOS_DATE)

                    Dim ID As Integer = 0
                    Dim rd_c As OdbcDataReader = SqlReader($"SELECT `ID` from POS_CASH_COUNT WHERE DATE(RECORDED_ON)='{DateFormatMySql(dt)}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' limit 1 ")
                    If rd_c.Read Then
                        ID = rd_c("ID")
                        'NO LONGER TO CHANGE
                    Else

                        ID = ObjectTypeMapId("pos_cash_count")
                        SqlExecuted($"INSERT INTO pos_cash_count SET TOTAL='{gsPOS_TOTAL}',CASH='{gsPOS_CASH}',`CHECK`='{gsPOS_CHECK}',CREDIT_CARD='{gsPOS_MASTER_CARD}',OTHER_PAYMENT='{gsPOS_OTHER_CARD}',NOTES='', ID ='{ID}',POS_MACHINE_ID = '{gsPOS_MACHINE_ID}', POSTED = '1',RECORDED_ON='{DateFormatMySql(dt)} 08:00:01'")
                        SqlExecuted($"UPDATE pos_log SET CASH_COUNT_ID = '{ID}' WHERE ID ='{gsPOS_LOG_ID}' Limit 1")

                        If chkRESTO_MODE.Checked = False Then
                            SqlExecuted($"UPDATE sales_receipt SET CASH_COUNT_ID ='{ID}' WHERE POS_LOG_ID='{gsPOS_LOG_ID}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' ")
                        Else
                            SqlExecuted($"UPDATE payment SET CASH_COUNT_ID ='{ID}' WHERE POS_LOG_ID='{gsPOS_LOG_ID}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' ")
                        End If

                    End If


                    fPOS_LOG_JOURNAL(gsPOS_LOG_ID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)
                Else

                End If
            End While
            rd_pos_start.Close()
        End If
        rd.Close()
        'POS_LOG
        'POS_CASH_COUNT
    End Sub

    Private Sub D_PLOG(ByVal dt As Date)


        Dim sQuery As String = ""

        Dim sValueSet As String = "TAXABLE_AMOUNT='" & gsPOS_TAXABLE_AMOUNT & "',OUTPUT_TAX_AMOUNT='" & gsPOS_OUTPUT_TAX_AMOUNT & "',NONTAXABLE_AMOUNT='" & gsPOS_NONTAXABLE_AMOUNT & "',`TOTAL`='" & gsPOS_TOTAL & "',`DISCOUNT`='" & gsPOS_DISCOUNT & "',`RETURN`='" & gsPOS_RETURN & "',`COUPON`='" & gsPOS_COUPON & "',`GIFT_CERT`='" & gsPOS_GIFT_CERT & "',`TRADE_IN`='" & gsPOS_TRADE_IN & "',`VOID`='" & gsPOS_VOID & "',`CASH`='" & gsPOS_CASH & "',`CHECK`='" & gsPOS_CHECK & "',GRAND_TOTAL='" & gsPOS_GRAND_TOTAL & "',`AMEX`='" & gsPOS_AMEX & "',`DISCOVER`='" & gsPOS_DISCOVER & "',`MASTER_CARD`='" & gsPOS_MASTER_CARD & "',`VISA`='" & gsPOS_VISA & "',`DINNERS`='" & gsPOS_DINNERS & "',`JCB`='" & gsPOS_JCB & "',`OTHER_CARD`='" & gsPOS_OTHER_CARD & "',`PAIDOUT`='" & gsPOS_PAIDOUT & "',`PAIDIN`='" & gsPOS_PAIDIN & "',TRANSACTION_COUNT='" & gsPOS_TRANSACTION_COUNT & "'"

        If gsPOS_LOG_ID = 0 Then
            gsPOS_LOG_ID = ObjectTypeMapId("POS_LOG")
            Dim iSerial_No As Integer = 0
            sQuery = $"INSERT pos_log SET RECORDED_ON='{DateFormatMySql(dt)} 08:00:01',
SERIAL_NO='" & iSerial_No & "',
ID = '" & gsPOS_LOG_ID & "',
POS_MACHINE_ID ='" & gsPOS_MACHINE_ID & "', 
CASHIER_ID = '" & gsCashier_ID & "',
LOCATION_ID = '" & cmbLOCATION_ID.SelectedValue & "',
DRAWER_ACCOUNT_ID='" & gsDRAWER_ACCOUNT_ID & "',
UNDEPOSITED_FUNDS_ACCOUNT_ID='" & gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID & "',
DEPOSITED='0',
STARTING_CASH_ID='" & gsSTARTING_CASH_ID & "',
CASH_COUNT_ID=null," & sValueSet
            'INSERT
            SqlExecuted(sQuery)
        Else
            sQuery = "Update pos_log set " & sValueSet & " where ID= '" & gsPOS_LOG_ID & "' Limit 1"
            'Update
            SqlExecuted(sQuery)
        End If



    End Sub

    Private Sub fSTARTING_CASH(ByVal dt As Date)
        gsPOS_DATE = dt
        gsPOS_LOG_ID = 0
        'POS LOG
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and DATE(recorded_On) ='{DateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}'  Limit 1;")

        If rd.Read Then
            gsPOS_LOG_ID = GF_NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = GF_NumIsNull(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = GF_NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = GF_NumIsNull(rd("CASH_COUNT_ID"))
        Else
            gsCASH_COUNT_ID = 0
            gsSTARTING_CASH_ID = ObjectTypeMapId("POS_STARTING_CASH")
            SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{DateFormatMySql(dt)} 08:00:01',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{cmbCASHIER_ID.SelectedValue}',AMOUNT='0',POSTED='0',DRAWER_ACCOUNT_ID='{ gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
        End If
        fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, gsPOS_DATE, cmbLOCATION_ID.SelectedValue)
        D_PLOG(dt)
        rd.Close()
    End Sub

    '    Private Function GET_GRAND_TOTAL(ByVal prDATE As Date) As Double
    '        Dim G_TOTAL As Double = 0
    '        Dim rd As OdbcDataReader = SqlReader($"SELECT pl.`GRAND_TOTAL`
    'FROM
    '  sales_receipt AS sr 
    '  INNER JOIN pos_log AS pl 
    '    ON pl.`ID` = sr.`POS_LOG_ID` 
    'WHERE sr.`DATE` < '{DateFormatMySql(prDATE)}' AND
    'sr.`POS_MACHINE_ID` = '{cmbPOS_MACHINE_ID.SelectedValue}' and sr.LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}'
    'ORDER BY sr.`DATE` DESC, sr.`ID` DESC 
    'LIMIT 1")

    '        If rd.Read Then
    '            G_TOTAL = GF_NumIsNull(rd("GRAND_TOTAL"))

    '        End If 

    '        Return G_TOTAL
    '    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gsSTARTING_CASH_ID = Val(txtSTART.Text)
        If gsSTARTING_CASH_ID = 0 Then
            Exit Sub
        End If

        fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
    End Sub
End Class