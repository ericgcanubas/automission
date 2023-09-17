Imports System.Data.Odbc
Public Class FrmPOS_LOG_STATING_COUNT_FIXED


    Private Sub FrmPOS_LOG_STATING_COUNT_FIXED_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(cmbLOCATION_ID, "SELECT ID,NAME FROM LOCATION ", "ID", "NAME")
        GS_ComboBoxLoad(cmbPOS_MACHINE_ID, "SELECT ID,NAME FROM POS_MACHINE ", "ID", "NAME")
        GS_ComboBoxLoad(cmbCASHIER_ID, "SELECT ID,NAME FROM CONTACT WHERE `TYPE` ='2' ", "ID", "NAME")
    End Sub

    Private Sub BtnRUN_Click(sender As Object, e As EventArgs) Handles btnRUN.Click
UP_NOW:

        Dim dt As Date = dtpDATE.Value
        Dim dn As Date = Date.Now
        If dt <= dn Then
            RunningLoad(dt)
        Else

            MessageBoxInfo("Done")
            Exit Sub
        End If


        dt = dt.AddDays(1)
        dtpDATE.Value = dt
        GoTo UP_NOW
    End Sub
    Private Sub RunningLoad(ByVal dt As Date)
        gsPOS_DATE = dt
        gsPOS_LOG_ID = 0
        gsCashier_ID = cmbCASHIER_ID.SelectedValue
        gsPOS_MACHINE_ID = cmbPOS_MACHINE_ID.SelectedValue
        gsDRAWER_ACCOUNT_ID = GF_GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")
        gsDefault_LOCATION_ID = cmbLOCATION_ID.SelectedValue
        Dim rd As OdbcDataReader
        If chkRESTO_MODE.Checked = False Then
            rd = SqlReader($"SELECT *  FROM SALES_RECEIPT WHERE  `DATE`='{GetDateFormatMySql(dt)}' and `LOCATION_ID` ='{gsDefault_LOCATION_ID}'")
        Else
            rd = SqlReader($"SELECT *  FROM PAYMENT WHERE  `DATE`='{GetDateFormatMySql(dt)}' and `LOCATION_ID` ='{gsDefault_LOCATION_ID}'")
        End If

        If rd.Read Then


            Dim rd_pos_start As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}' and  CASHIER_ID = '{gsCashier_ID}'  and DATE(RECORDED_ON) ='{GetDateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' ")
            While rd_pos_start.Read()

                gsPOS_LOG_ID = GF_NumIsNull(rd_pos_start("ID"))
                gsSTARTING_CASH_ID = GF_NumIsNull(rd_pos_start("STARTING_CASH_ID"))
                gsENDING_RECEIPT_NO = GF_NumIsNull(rd_pos_start("ENDING_RECEIPT_NO"))
                gsCASH_COUNT_ID = GF_NumIsNull(rd_pos_start("CASH_COUNT_ID"))


                If gsPOS_LOG_ID <> 0 Then

                    If chkRESTO_MODE.Checked = False Then
                        SqlExecuted($" UPDATE sales_receipt SET `CASHIER_ID` ='{gsCashier_ID}',POS_LOG_ID ='{gsPOS_LOG_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',POS_POSTED='1' WHERE `DATE`='{GetDateFormatMySql(gsPOS_DATE)}' and `LOCATION_ID` ='{cmbLOCATION_ID.SelectedValue}' ")

                    Else
                        SqlExecuted($" UPDATE payment SET POS_LOG_ID ='{gsPOS_LOG_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}' WHERE `DATE`='{GetDateFormatMySql(gsPOS_DATE)}' and `LOCATION_ID` ='{cmbLOCATION_ID.SelectedValue}' ")
                    End If

                    D_PLOG(gsPOS_DATE)
                    If chkRESTO_MODE.Checked = False Then
                        GS_CollectPosLog()
                    Else
                        GS_CollectPosLogResto()
                    End If

                    D_PLOG(gsPOS_DATE)

                    Dim ID As Integer
                    Dim rd_c As OdbcDataReader = SqlReader($"SELECT `ID` from POS_CASH_COUNT WHERE DATE(RECORDED_ON)='{GetDateFormatMySql(dt)}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' limit 1 ")
                    If rd_c.Read Then

                        'NO LONGER TO CHANGE
                    Else

                        ID = ObjectTypeMapId("pos_cash_count")
                        SqlExecuted($"INSERT INTO pos_cash_count SET TOTAL='{gsPOS_TOTAL}',CASH='{gsPOS_CASH}',`CHECK`='{gsPOS_CHECK}',CREDIT_CARD='{gsPOS_MASTER_CARD}',OTHER_PAYMENT='{gsPOS_OTHER_CARD}',NOTES='', ID ='{ID}',POS_MACHINE_ID = '{gsPOS_MACHINE_ID}', POSTED = '1',RECORDED_ON='{GetDateFormatMySql(dt)} 08:00:01'")
                        SqlExecuted($"UPDATE pos_log SET CASH_COUNT_ID = '{ID}' WHERE ID ='{gsPOS_LOG_ID}' Limit 1")

                        If chkRESTO_MODE.Checked = False Then
                            SqlExecuted($"UPDATE sales_receipt SET CASH_COUNT_ID ='{ID}' WHERE POS_LOG_ID='{gsPOS_LOG_ID}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' ")
                        Else
                            SqlExecuted($"UPDATE payment SET CASH_COUNT_ID ='{ID}' WHERE POS_LOG_ID='{gsPOS_LOG_ID}' and POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' ")
                        End If

                    End If


                    GS_PosLogJournal(gsPOS_LOG_ID, gsCASH_OVER_SHORT_EXPENSES, gsPOS_DATE)
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
        Dim sValueSet As String = "TAXABLE_AMOUNT='" & gsPOS_TAXABLE_AMOUNT & "',OUTPUT_TAX_AMOUNT='" & gsPOS_OUTPUT_TAX_AMOUNT & "',NONTAXABLE_AMOUNT='" & gsPOS_NONTAXABLE_AMOUNT & "',`TOTAL`='" & gsPOS_TOTAL & "',`DISCOUNT`='" & gsPOS_DISCOUNT & "',`RETURN`='" & gsPOS_RETURN & "',`COUPON`='" & gsPOS_COUPON & "',`GIFT_CERT`='" & gsPOS_GIFT_CERT & "',`TRADE_IN`='" & gsPOS_TRADE_IN & "',`VOID`='" & gsPOS_VOID & "',`CASH`='" & gsPOS_CASH & "',`CHECK`='" & gsPOS_CHECK & "',GRAND_TOTAL='" & gsPOS_GRAND_TOTAL & "',`AMEX`='" & gsPOS_AMEX & "',`DISCOVER`='" & gsPOS_DISCOVER & "',`MASTER_CARD`='" & gsPOS_MASTER_CARD & "',`VISA`='" & gsPOS_VISA & "',`DINNERS`='" & gsPOS_DINNERS & "',`JCB`='" & gsPOS_JCB & "',`OTHER_CARD`='" & gsPOS_OTHER_CARD & "',`PAIDOUT`='" & gsPOS_PAIDOUT & "',`PAIDIN`='" & gsPOS_PAIDIN & "',TRANSACTION_COUNT='" & gsPOS_TRANSACTION_COUNT & "'"



        Dim sQuery As String

        If gsPOS_LOG_ID = 0 Then
            gsPOS_LOG_ID = ObjectTypeMapId("POS_LOG")
            Dim iSerial_No As Integer = 0
            sQuery = $"INSERT pos_log SET RECORDED_ON='{GetDateFormatMySql(dt)} 08:00:01',
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

    Private Sub STARTING_CASH(ByVal dt As Date)
        gsPOS_DATE = dt
        gsPOS_LOG_ID = 0
        'POS LOG
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and DATE(recorded_On) ='{GetDateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}'  Limit 1;")

        If rd.Read Then
            gsPOS_LOG_ID = GF_NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = GF_NumIsNull(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = GF_NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = GF_NumIsNull(rd("CASH_COUNT_ID"))
        Else
            gsCASH_COUNT_ID = 0
            gsSTARTING_CASH_ID = ObjectTypeMapId("POS_STARTING_CASH")
            SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{GetDateFormatMySql(dt)} 08:00:01',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{cmbCASHIER_ID.SelectedValue}',AMOUNT='0',POSTED='0',DRAWER_ACCOUNT_ID='{ gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
        End If
        GS_PosStartingCashJournal(gsSTARTING_CASH_ID, gsPOS_DATE, cmbLOCATION_ID.SelectedValue)
        D_PLOG(dt)
        rd.Close()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gsSTARTING_CASH_ID = Val(txtSTART.Text)
        If gsSTARTING_CASH_ID = 0 Then
            Exit Sub
        End If

        GS_PosStartingCashJournal(gsSTARTING_CASH_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
    End Sub
End Class