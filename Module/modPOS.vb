Imports System.Data.Odbc
Module modPOS


    Public gsPOS_SELECTED_ROOM_ID As Integer = 0
    Public gsClose_Date_Run_Per_Unit As Boolean
    Public gsPOS_DATE As Date
    Public gsPOS_LOG_ID As Double
    Public gsPOS_MACHINE_ID As String
    Public gsPOS_TYPE_ID As String
    Public gsSTARTING_RECEIPT_NO As Double
    Public gsENDING_RECEIPT_NO As Double
    Public gsDRAWER_ACCOUNT_ID As Integer
    Public gsPOS_SERVED_ONLY As Boolean = True
    Public gsDINE_IN_ID As Integer
    Public gsTAKE_OUT_ID As Integer
    Public gsDELIVERY_ID As Integer

    Public gsDINE_NAME As String
    Public gsTAKE_OUT_NAME As String
    Public gsDELIVERY_NAME As String
    Public Const gsPOS_WINDOWS_PRINTER As String = "Microsoft XPS Document Writer"
    Public gsPOS_DEFAULT_PRINTER As String

    Public gsPOS_RESTAURANT_TABLE_NO As Integer

    Public gsPETTY_CASH_ACCOUNT_ID As Integer
    Public gsCASH_OVER_SHORT_EXPENSES As Integer
    Public gsSTARTING_CASH_ID As Integer
    Public LOG_DATE As String
    Public gsCASH_COUNT_ID As Integer

    Public gsPOS_TOTAL As Double = 0
    Public gsPOS_GRAND_TOTAL As Double = 0
    Public gsPOS_DISCOUNT As Double = 0
    Public gsPOS_RETURN As Double = 0
    Public gsPOS_COUPON As Double = 0
    Public gsPOS_GIFT_CERT As Double = 0
    Public gsPOS_TRADE_IN As Double = 0
    Public gsPOS_VOID As Double = 0
    Public gsPOS_CASH As Double = 0
    Public gsPOS_CHECK As Double = 0
    Public gsPOS_AMEX As Double = 0
    Public gsPOS_DISCOVER As Double = 0
    Public gsPOS_MASTER_CARD As Double = 0
    Public gsPOS_VISA As Double = 0
    Public gsPOS_DINNERS As Double = 0
    Public gsPOS_JCB As Double = 0
    Public gsPOS_OTHER_CARD As Double = 0
    Public gsPOS_PAIDOUT As String = 0
    Public gsPOS_PAIDIN As String = 0
    Public gsPOS_TRANSACTION_COUNT As Integer = 0


    Public gsPOS_TAXABLE_AMOUNT As Double = 0
    Public gsPOS_OUTPUT_TAX_AMOUNT As Double = 0
    Public gsPOS_NONTAXABLE_AMOUNT As Double = 0


    Public Sub GS_PointOfSalesReset()
        gsPOS_LOG_ID = 0

        gsSTARTING_RECEIPT_NO = 0
        gsENDING_RECEIPT_NO = 0

        gsPOS_TOTAL = 0
        gsPOS_GRAND_TOTAL = 0
        gsPOS_DISCOUNT = 0
        gsPOS_RETURN = 0
        gsPOS_COUPON = 0
        gsPOS_GIFT_CERT = 0
        gsPOS_TRADE_IN = 0
        gsPOS_VOID = 0
        gsPOS_CASH = 0
        gsPOS_CHECK = 0
        gsPOS_AMEX = 0
        gsPOS_DISCOVER = 0
        gsPOS_MASTER_CARD = 0
        gsPOS_VISA = 0
        gsPOS_DINNERS = 0
        gsPOS_JCB = 0
        gsPOS_OTHER_CARD = 0
        gsPOS_PAIDOUT = 0
        gsPOS_PAIDIN = 0
    End Sub
    Public Function GF_GetPosMachineId() As Integer

        Return Val(GetDBAccessValueByText("POS_MACHINE_ID"))
    End Function
    Public Function GF_PosDrawerAccountIdPerUnit() As Integer
        Return Val(GetDBAccessValueByText("POS_DRAWER_ACCOUNT_ID_PER_UNIT"))
    End Function
    Public Function GF_IsPosOfficialReceiptRequired() As Boolean
        Try
            Return CBool(GetDBAccessValueByText("OR_REQUIRED"))
        Catch ex As Exception
            Return False
        End Try

    End Function
    Public Function GF_PosStartingCash() As Boolean
        Try
            Return CBool(GetDBAccessValueByText("POS_STARTING_CASH"))
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function GF_PosMachineTypeMap() As Integer
        Dim t As Integer = -1
        Dim rd As OdbcDataReader = SqlReader("select type as t from pos_machine where id = '" & gsPOS_MACHINE_ID & "' limit 1")
        If rd.Read Then
            t = GF_NumIsNull(rd("t"))
        End If
        rd.Close()
        Return t
    End Function

    Public Function GS_IsServedOnly() As Boolean
        Dim sValue As Boolean
        Dim rd As OdbcDataReader = SqlReader("select RESTO_SERVED_ONLY from POS_MACHINE where ID = '" & gsPOS_MACHINE_ID & "' limit 1")
        If rd.Read Then
            sValue = IIf(GF_NumIsNull(rd("RESTO_SERVED_ONLY")) = 1, True, False)
        Else
            sValue = False
        End If
        rd.Close()
        Return sValue
    End Function
    Public Function GF_GetNextReceiptNumber() As String
        Dim sValue As String
        Dim rd As OdbcDataReader = SqlReader("select NEXT_RECEIPT_NO,NO_OF_DIGITS from POS_MACHINE where ID = '" & gsPOS_MACHINE_ID & "' limit 1")
        If rd.Read Then
            Dim d As String = ""
            For i As Integer = 1 To GF_NumIsNull(rd("NO_OF_DIGITS"))
                d &= "0"
            Next
            sValue = GF_NumIsNull(rd("NEXT_RECEIPT_NO")).ToString(d)
        Else
            sValue = ""
        End If
        rd.Close()
        Return sValue

    End Function
    Private Function GF_GetNextLOgSerialNumber() As Integer
        Dim i As Integer = 0
        Dim rd As OdbcDataReader = SqlReader("select NEXT_LOG_SERIAL_NO from POS_MACHINE where ID = '" & gsPOS_MACHINE_ID & "' limit 1")
        If rd.Read Then
            i = GF_NumIsNull(rd("NEXT_LOG_SERIAL_NO"))
        End If
        rd.Close()
        SqlExecuted("Update pos_machine set NEXT_LOG_SERIAL_NO = '" & i + 1 & "' where ID ='" & gsPOS_MACHINE_ID & "' limit 1 ")
        Return 1
    End Function
    Public Sub GS_UpdateNextReceiptNumber()
        Dim r As Integer = GF_GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "NEXT_RECEIPT_NO") + 1
        SqlExecuted("Update pos_machine SET NEXT_RECEIPT_NO = '" & r & "' where ID = '" & gsPOS_MACHINE_ID & "'")
    End Sub


    Public Sub GS_OpenCashDrawer()

        If gsOpenCashDrawer = True Then

        End If

    End Sub
    Public Sub GS_CollectPosLog()
        gsPOS_TOTAL = 0
        gsPOS_GRAND_TOTAL = 0
        gsPOS_TRANSACTION_COUNT = 0
        gsPOS_CASH = 0
        gsPOS_TAXABLE_AMOUNT = 0
        gsPOS_OUTPUT_TAX_AMOUNT = 0
        gsPOS_NONTAXABLE_AMOUNT = 0


        gsPOS_CHECK = 0
        gsPOS_VISA = 0
        gsPOS_MASTER_CARD = 0

        Try
            Dim rd As OdbcDataReader = SqlReader($" SELECT  SUM(IF(PTM.`ID` = 0, sr.`AMOUNT`, 0)) AS CASH_TOTAL,
  SUM(IF(PTM.`ID` = 1, sr.`AMOUNT`, 0)) AS CHECK_TOTAL,
  SUM(IF(PTM.`ID` = 4, sr.`AMOUNT`, 0)) AS MASTER_CARD_TOTAL,
  SUM(IF(PTM.`ID` = 5, sr.`AMOUNT`, 0)) AS VISA_TOTAL,
  SUM(IF(PTM.`ID` >= 8, sr.`AMOUNT`, 0)) AS OTHERS_TOTAL,
  SUM(sr.`AMOUNT`) AS TOTAL,
  SUM(sr.TAXABLE_AMOUNT) AS `TA`,
  SUM(sr.OUTPUT_TAX_AMOUNT) AS `OTA`,
  SUM(sr.NONTAXABLE_AMOUNT) AS `NA`,
  COUNT(sr.`ID`) AS COUNT_NO 
FROM   sales_receipt AS sr 
  INNER JOIN pos_log AS pl 
    ON pl.`ID` = sr.`POS_LOG_ID` 
  INNER JOIN PAYMENT_METHOD AS PM 
    ON PM.`ID` = SR.`PAYMENT_METHOD_ID` 
  INNER JOIN PAYMENT_TYPE_MAP AS PTM 
    ON PTM.`ID` = PM.`PAYMENT_TYPE`  WHERE  sr.`STATUS` = '3' and pl.`ID` = '{gsPOS_LOG_ID}' and pl.CASHIER_ID = '{gsCashier_ID}'")

            If rd.Read Then
                gsPOS_TOTAL = GF_NumIsNull(rd("TOTAL"))
                gsPOS_CASH = GF_NumIsNull(rd("CASH_TOTAL"))
                gsPOS_CHECK = GF_NumIsNull(rd("CHECK_TOTAL"))
                gsPOS_VISA = GF_NumIsNull(rd("VISA_TOTAL"))
                gsPOS_MASTER_CARD = GF_NumIsNull(rd("MASTER_CARD_TOTAL"))
                gsPOS_OTHER_CARD = GF_NumIsNull(rd("OTHERS_TOTAL"))
                gsPOS_TRANSACTION_COUNT = GF_NumIsNull(rd("COUNT_NO"))
                gsPOS_GRAND_TOTAL = gsPOS_TOTAL + GF_GetGrandToTaLSalesReceipt()
                gsPOS_TAXABLE_AMOUNT = GF_NumIsNull(rd("TA"))
                gsPOS_OUTPUT_TAX_AMOUNT = GF_NumIsNull(rd("OTA"))
                gsPOS_NONTAXABLE_AMOUNT = GF_NumIsNull(rd("NA"))
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Public Sub GS_PosLogLoad()
        If gsPOS_TYPE_ID = 0 Then
            Dim sQuery As String
            Dim sValueSet As String = "TAXABLE_AMOUNT='" & gsPOS_TAXABLE_AMOUNT & "',OUTPUT_TAX_AMOUNT='" & gsPOS_OUTPUT_TAX_AMOUNT & "',NONTAXABLE_AMOUNT='" & gsPOS_NONTAXABLE_AMOUNT & "',`TOTAL`='" & gsPOS_TOTAL & "',`DISCOUNT`='" & gsPOS_DISCOUNT & "',`RETURN`='" & gsPOS_RETURN & "',`COUPON`='" & gsPOS_COUPON & "',`GIFT_CERT`='" & gsPOS_GIFT_CERT & "',`TRADE_IN`='" & gsPOS_TRADE_IN & "',`VOID`='" & gsPOS_VOID & "',`CASH`='" & gsPOS_CASH & "',`CHECK`='" & gsPOS_CHECK & "',GRAND_TOTAL='" & gsPOS_GRAND_TOTAL & "',`AMEX`='" & gsPOS_AMEX & "',`DISCOVER`='" & gsPOS_DISCOVER & "',`MASTER_CARD`='" & gsPOS_MASTER_CARD & "',`VISA`='" & gsPOS_VISA & "',`DINNERS`='" & gsPOS_DINNERS & "',`JCB`='" & gsPOS_JCB & "',`OTHER_CARD`='" & gsPOS_OTHER_CARD & "',`PAIDOUT`='" & gsPOS_PAIDOUT & "',`PAIDIN`='" & gsPOS_PAIDIN & "',TRANSACTION_COUNT='" & gsPOS_TRANSACTION_COUNT & "',STARTING_RECEIPT_NO='" & gsSTARTING_RECEIPT_NO & "',ENDING_RECEIPT_NO='" & gsENDING_RECEIPT_NO & "'"

            If gsPOS_LOG_ID = 0 Then
                gsPOS_LOG_ID = ObjectTypeMapId("POS_LOG")
                Dim iSerial_No As Integer = GF_GetNextLOgSerialNumber()
                sQuery = "INSERT pos_log SET TRANSACTION_DATE='" & DateFormatMySql(gsPOS_DATE) & "',RECORDED_ON='" & LOG_DATE & "',
SERIAL_NO='" & iSerial_No & "',
ID = '" & gsPOS_LOG_ID & "',
POS_MACHINE_ID ='" & gsPOS_MACHINE_ID & "', 
CASHIER_ID = '" & gsCashier_ID & "',
LOCATION_ID = '" & gsDefault_LOCATION_ID & "',
DRAWER_ACCOUNT_ID='" & gsDRAWER_ACCOUNT_ID & "',
UNDEPOSITED_FUNDS_ACCOUNT_ID='" & gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID & "',
DEPOSITED='0',
STARTING_CASH_ID='" & gsSTARTING_CASH_ID & "',
CASH_COUNT_ID=null," & sValueSet
                'INSERT
                SqlExecuted(sQuery)
            Else
                sQuery = "Update pos_log set " & sValueSet & " where ID = '" & gsPOS_LOG_ID & "' Limit 1"
                'Update
                SqlExecuted(sQuery)
            End If

        End If
    End Sub
    Public Sub GS_CollectPosLogResto()
        gsPOS_TOTAL = 0
        gsPOS_GRAND_TOTAL = 0
        gsPOS_TRANSACTION_COUNT = 0
        gsPOS_CASH = 0
        gsPOS_TAXABLE_AMOUNT = 0
        gsPOS_OUTPUT_TAX_AMOUNT = 0
        gsPOS_NONTAXABLE_AMOUNT = 0


        gsPOS_CHECK = 0
        gsPOS_VISA = 0
        gsPOS_MASTER_CARD = 0
        Try
            Dim rd As OdbcDataReader = SqlReader($" SELECT  SUM(IF(PTM.`ID` = 0, sr.`AMOUNT`, 0)) AS CASH_TOTAL,
  SUM(IF(PTM.`ID` = 1, sr.`AMOUNT_APPLIED`, 0)) AS CHECK_TOTAL,
  SUM(IF(PTM.`ID` = 4, sr.`AMOUNT_APPLIED`, 0)) AS MASTER_CARD_TOTAL,
  SUM(IF(PTM.`ID` = 5, sr.`AMOUNT_APPLIED`, 0)) AS VISA_TOTAL,
  SUM(IF(PTM.`ID` = 8, sr.`AMOUNT_APPLIED`, 0)) AS OTHERS_TOTAL,
  SUM(sr.`AMOUNT_APPLIED`) AS TOTAL,
  SUM((SELECT IFNULL( sum( i.`TAXABLE_AMOUNT`),0) AS `N` FROM payment_invoices AS pn INNER JOIN invoice AS i ON i.`ID` = pn.`INVOICE_ID` WHERE pn.`PAYMENT_ID` = sr.ID )) AS `TA`,
  SUM((SELECT IFNULL(sum( i.`OUTPUT_TAX_AMOUNT`),0) AS `N` FROM payment_invoices AS pn INNER JOIN invoice AS i ON i.`ID` = pn.`INVOICE_ID` WHERE pn.`PAYMENT_ID` = sr.ID )) AS `OTA`,
  SUM((SELECT IFNULL(sum( i.`NONTAXABLE_AMOUNT`),0) AS `N` FROM payment_invoices AS pn INNER JOIN invoice AS i ON i.`ID` = pn.`INVOICE_ID` WHERE pn.`PAYMENT_ID` = sr.ID )) AS `NA`,
  COUNT(sr.`ID`) AS COUNT_NO 
FROM   payment AS sr 
  INNER JOIN pos_log AS pl 
    ON pl.`ID` = sr.`POS_LOG_ID` 
  INNER JOIN PAYMENT_METHOD AS PM 
    ON PM.`ID` = SR.`PAYMENT_METHOD_ID` 
  INNER JOIN PAYMENT_TYPE_MAP AS PTM 
    ON PTM.`ID` = PM.`PAYMENT_TYPE`
WHERE  pl.`ID` = '{gsPOS_LOG_ID}' and pl.CASHIER_ID = '{gsCashier_ID}'")

            If rd.Read Then

                gsPOS_TOTAL = GF_NumIsNull(rd("TOTAL"))

                gsPOS_CASH = GF_NumIsNull(rd("CASH_TOTAL"))
                gsPOS_CHECK = GF_NumIsNull(rd("CHECK_TOTAL"))
                gsPOS_VISA = GF_NumIsNull(rd("VISA_TOTAL"))
                gsPOS_MASTER_CARD = GF_NumIsNull(rd("MASTER_CARD_TOTAL"))
                gsPOS_OTHER_CARD = GF_NumIsNull(rd("OTHERS_TOTAL"))
                gsPOS_TRANSACTION_COUNT = GF_NumIsNull(rd("COUNT_NO"))
                gsPOS_GRAND_TOTAL = gsPOS_TOTAL + GF_GetGrandTotalPayment()
                gsPOS_TAXABLE_AMOUNT = GF_NumIsNull(rd("TA"))
                gsPOS_OUTPUT_TAX_AMOUNT = GF_NumIsNull(rd("OTA"))
                gsPOS_NONTAXABLE_AMOUNT = GF_NumIsNull(rd("NA"))

            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub
    Private Function GF_GetGrandTotalPayment() As Double
        Dim G_TOTAL As Double = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT pl.`GRAND_TOTAL`
FROM
 pos_log AS pl 

WHERE pl.id < '{gsPOS_LOG_ID}' AND
pl.`POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}' and pl.LOCATION_ID = '{gsDefault_LOCATION_ID}'
ORDER BY pl.ID DESC
LIMIT 1")

        If rd.Read Then
            G_TOTAL = GF_NumIsNull(rd("GRAND_TOTAL"))

        End If

        Return G_TOTAL
    End Function
    Private Function GF_GetGrandToTaLSalesReceipt() As Double
        Dim G_TOTAL As Double = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT 
        pl.`GRAND_TOTAL`
        FROM
        pos_log AS pl    
        WHERE pl.id < '{gsPOS_LOG_ID}' AND
        pl.`POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}' and
        pl.LOCATION_ID = '{gsDefault_LOCATION_ID}'
        ORDER BY pl.ID DESC
        LIMIT 1")

        If rd.Read Then
            G_TOTAL = GF_NumIsNull(rd("GRAND_TOTAL"))
        End If

        Return G_TOTAL
    End Function
    Public Sub GS_PosRefreshFormat(ByVal cmb As ComboBox, ByVal frmName As String)
        DBAccessComboBoxLoad(cmb, "select [file_name],[print_title] from tblprint Where [form_name] ='" & frmName & "' order by [print_default] desc ", "file_name", "print_title")
    End Sub
End Module
