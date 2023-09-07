Imports System.Data.Odbc
Module modSystemSettings

    Public Sub fLoadDefaultValue()
        gsDefaultItemAssetAccountId = fSystemSettingValue_Num("DefaultItemAssetAccountId")
        gsDefaultItemIncomeAccountId = fSystemSettingValue_Num("DefaultItemIncomeAccountId")
        gsDefaultItemCOGSAccountId = fSystemSettingValue_Num("DefaultItemCOGSAccountId")
        gsDefaultItemDiscountAccountId = fSystemSettingValue_Num("DefaultItemDiscountAccountId")
        gsDefaultItemOtherChargeAccountId = fSystemSettingValue_Num("DefaultItemOtherChargeAccountId")
        gsDefaultItemClassId = fSystemSettingValue_Num("DefaultItemClassId")
        gsDefaultItemSubClassId = fSystemSettingValue_Num("DefaultItemSubClassId")
        gsDefaultItemGroupId = fSystemSettingValue_Num("DefaultItemGroupId")
        gsApproved_By = fSystemSettingValue("Approved_By")

    End Sub
    Public Sub fSaveSystemControl(ByVal TabCon As TabControl)
        ' Dim str_Query As String = ""
        ' Dim Querycollection As String = ""
        For Each c As Control In TabCon.Controls
            If (TypeOf c Is TabPage) Then
                Dim t As TabPage = c
                For Each v As Control In t.Controls
                    If (TypeOf v Is GroupBox) Then
                        Dim g As GroupBox = v
                        If g.Name <> "grpExport" Then
                            For Each z As Control In g.Controls
                                If (TypeOf z Is ComboBox) Then
                                    Dim ojb As ComboBox = z
                                    SqlExecuted("UPDATE system_settings SET `VALUE` ='" & IIf(ojb.Name.Contains("cmb") = True, ojb.SelectedValue, ojb.Text) & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                                ElseIf (TypeOf z Is TextBox) Or (TypeOf z Is RichTextBox) Then
                                    SqlExecuted("UPDATE system_settings SET `VALUE` ='" & z.Text & "' WHERE `NAME` = '" & Mid(z.Name, 4, z.Name.Length) & "' limit 1;")
                                ElseIf (TypeOf z Is CheckBox) Then
                                    Dim ojb As CheckBox = z
                                    SqlExecuted("UPDATE system_settings SET `VALUE` ='" & ojb.Checked & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                                ElseIf (TypeOf z Is NumericUpDown) Then
                                    Dim ojb As NumericUpDown = z
                                    SqlExecuted("UPDATE system_settings SET `VALUE` ='" & ojb.Value & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                                ElseIf (TypeOf z Is DateTimePicker) Then
                                    Dim ojb As DateTimePicker = z
                                    SqlExecuted("UPDATE system_settings SET `VALUE` ='" & IIf(ojb.Checked = False, "", ojb.Value) & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "'limit 1;")
                                End If
                            Next
                        End If
                    ElseIf (TypeOf v Is ComboBox) Then
                        Dim ojb As ComboBox = v
                        SqlExecuted("UPDATE system_settings SET `VALUE` ='" & IIf(ojb.Name.Contains("cmb") = True, ojb.SelectedValue, ojb.Text) & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                    ElseIf (TypeOf v Is TextBox) Or (TypeOf v Is RichTextBox) Then
                        SqlExecuted("UPDATE system_settings SET `VALUE` ='" & v.Text & "' WHERE `NAME` = '" & Mid(v.Name, 4, v.Name.Length) & "' limit 1;")
                    ElseIf (TypeOf v Is CheckBox) Then
                        Dim ojb As CheckBox = v
                        SqlExecuted("UPDATE system_settings SET `VALUE` ='" & ojb.Checked & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                    ElseIf (TypeOf v Is NumericUpDown) Then
                        Dim ojb As NumericUpDown = v
                        SqlExecuted("UPDATE system_settings SET `VALUE` ='" & ojb.Value & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                    ElseIf (TypeOf v Is DateTimePicker) Then
                        Dim ojb As DateTimePicker = v
                        SqlExecuted("UPDATE system_settings SET `VALUE` ='" & IIf(ojb.Checked = False, "", ojb.Value) & "' WHERE `NAME` = '" & Mid(ojb.Name, 4, ojb.Name.Length) & "' limit 1;")
                    End If

                Next


            End If

        Next



        ' SqlExecuted(str_Query) 'MAIN
        MessageBoxInfo("Save! Re-login")
    End Sub
    Public Sub fObject_Type(ByVal c As Control, ByVal i As Integer, ByVal v As String)
        Select Case StrLeft(c.Controls(i).Name, 3)


            Case "lbl"
                Dim lbl As Label = c.Controls(i)
                lbl.Text = v
            Case "txt"
                Dim txt As TextBox = c.Controls(i)
                txt.Text = v
            Case "cmb"
                Dim cmb As ComboBox = c.Controls(i)
                If v.Length = 0 Then
                    If cmb.DropDownStyle = ComboBoxStyle.DropDownList Then

                        If cmb.Items.Count <> 0 Then
                            cmb.SelectedIndex = 0
                        Else
                            cmb.SelectedIndex = -1
                        End If
                    Else
                        cmb.SelectedIndex = -1
                    End If

                Else
                    cmb.SelectedValue = Val(v)
                End If

            Case "cbo"
                Dim cbo As ComboBox = c.Controls(i)
                cbo.Text = v
            Case "dtp"
                Dim dtp As DateTimePicker = c.Controls(i)
                dtp.Format = DateTimePickerFormat.Custom
                dtp.CustomFormat = "MM/dd/yyyy"

                If IsDate(v) = True Then
                    dtp.Value = v
                    dtp.Checked = True
                Else
                    dtp.Checked = False
                End If

            Case "rtb"
                Dim rtb As RichTextBox = c.Controls(i)
                rtb.Text = v
            Case "num"
                Dim num As NumericUpDown = c.Controls(i)
                num.DecimalPlaces = 2
                num.Value = Val(v)
               ' c.Controls(i).Controls(0).Hide()
            Case "chk"
                Dim chk As CheckBox = c.Controls(i)
                Dim b As Boolean
                If v = "" Then
                    b = False
                Else
                    b = v
                End If

                If b = False Then
                    chk.Checked = False
                Else
                    chk.Checked = True
                End If


            Case Else







        End Select

    End Sub
    Public Function fGetObjectNow(ByVal prName As String, ByVal c As Control, ByVal i As Integer) As Boolean
        Dim b As Boolean = False
        Try
            Dim s As String = Mid(c.Controls(i).Name, 4, c.Controls(i).Name.Length).ToUpper
            If prName.ToUpper = s Then
                b = True
            Else
                b = False
            End If

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
        Return b
    End Function
    Public Sub fLoadSubMenuTypeItem()
        Dim rd As OdbcDataReader = SqlReader("select description,form from `tblsub_menu` where active <> '0' ")
        While rd.Read
            Dim sName As String = rd("Description")
            Select Case rd("form")
                '// customer
                Case "frmInvoice"
                    gsTextInvoice = sName
                Case "frmReceivePayment"
                    gsTextReceivePayment = sName
                Case "frmSalesOrder"
                    gsTextSalesOrder = sName
                Case "frmSalesReceipt"
                    gsTextSalesReceipt = sName
                Case "frmEstimate"
                    gsTextEstimate = sName
                Case "frmCreditMemo"
                    gsTextCreditMemo = sName
                Case "frmTaxCredit"
                    gsTextTaxCredit = sName
                    '// vendor
                Case "frmPurchaseOrder"
                    gsTextPurchaseOrder = sName
                Case "frmPurchaseRequest"
                    gsTextPurchaseRequest = sName
                Case "frmStockReceived"
                    gsTextStockReceived = sName
                Case "frmBills"
                    gsTextBills = sName
                Case "frmBillCredit"
                    gsTextBillCredit = sName
                Case "frmBillPayment"
                    gsTextBillPayment = sName
                Case "frmWithholdingTax"
                    gsTextWithholdingTax = sName
                    '// Inventory
                Case "frmBuildAssembly"
                    gsTextBuildAssembly = sName
                Case "frmInventoryAdjustment"
                    gsTextInventoryAdjustment = sName
                Case "frmStockTransfer"
                    gsTextStockTransfer = sName
                Case "frmGeneralJournal"
                    gsTextGeneralJournal = sName
                    '//Banking
                Case "frmDeposit"
                    gsTextDeposit = sName
                Case "frmFundTransfer"
                    gsTextFundTransfer = sName
                Case "frmWriteCheck"
                    gsTextWriteCheck = sName

            End Select
        End While
        rd.Close()
    End Sub
    Public Function fIsClosingDate(ByVal prDate As Date, ByVal IsNew As Boolean) As Boolean
        Dim bResult As Boolean = False
        If prDate <= fClosingDate() Then
            If IsNew = True Then
                bResult = False
                MessageBoxWarning("Closing date not allowed")
            Else

                If CBool(fSystemSettingValue("ClosingDatePassword")) = False Then

                    bResult = False
                Else
                    If fAccessDeniedIsYes(gsMessageClosingDatePassword) = False Then
                        bResult = True
                    Else
                        bResult = False
                    End If
                End If
            End If
        Else
            bResult = True
        End If
        Return bResult
    End Function
    Public Function fClosingDate() As Date
        Try
            Return fSystemSettingValue("ClosingDate")
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
            Return Date.Today
        End Try
    End Function
    Public Sub fDefaultAccountLoad()
        gsDefault_ACCOUNTS_RECEIVABLE_ID = fSystemSettingValue_Num("DefaultAccountReceivableId")
        gsDefault_ACCOUNTS_PAYABALE_ID = fSystemSettingValue_Num("DefaultAccountPayableId")
        gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID = fSystemSettingValue_Num("DefaultUndepositedFundAccountId")
        gsDefault_ITEM_ACCOUNT_ID = fSystemSettingValue_Num("DefaultItemAccountId")
        gsSTOCK_TRANSFER_ACCOUNT_ID = fSystemSettingValue_Num("StockTransferAccountId")
        gsSTOCK_RECEIVED_ACCOUNT_ID = fSystemSettingValue_Num("StockReceivedAccountId")
        gsINTER_LOCATION_ACCOUNT_ID = fSystemSettingValue_Num("InterLocationAccountId")
        'gsTAX_PAYABLE_ACCOUNT_ID = fSystemSettingValue("TaxPayableAccountId")
        'gsTAX_CREDIT_ACCOUNT_ID = fSystemSettingValue("TaxCreditAccountId")
    End Sub
    Public Function fSystemSettingValue(ByVal prName As String) As String


        Dim sValue As String = Trim(fMSgetField("system_value", "tblsystem", "ID", prName))

        If sValue = "" Then
            Try
                Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings where `NAME` = '" & prName & "' Limit 1")
                If rd.Read Then
                    sValue = rd("VALUE")
                Else
                    SqlExecuted("INSERT INTO system_settings SET `VALUE`='', `NAME` = '" & prName & "'")
                    MessageBoxInfo("New settings = " & prName)
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fSystemSettingValue(prName)
                Else
                    End
                End If
            End Try
        End If
        Return sValue
    End Function
    Public Function fSystemSettingValue_Bool(ByVal prName As String) As Boolean

        Dim sValue As Boolean = False
        Try
            sValue = CBool(fMSgetField("system_value", "tblsystem", "ID", prName))
        Catch ex As Exception
            sValue = False
        End Try


        If sValue = False Then
            Try
                Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings where `NAME` = '" & prName & "' Limit 1")
                If rd.Read Then
                    sValue = rd("VALUE")
                Else
                    SqlExecuted("INSERT INTO system_settings SET `VALUE`='0', `NAME` = '" & prName & "'")
                    MessageBoxInfo("New settings = " & prName)
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fSystemSettingValue_Bool(prName)
                Else
                    End
                End If
            End Try
        End If
        Return sValue
    End Function

    Public Sub fSystemSettingUpdateByBool(ByVal prName As String, ByVal prValue As Boolean)



        Try
            Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings where `NAME` = '" & prName & "' Limit 1")
            If rd.Read Then
                SqlExecuted("UPDATE system_settings SET `VALUE`='" & prValue & "' WHERE `NAME` = '" & prName & "'  limit 1;")
            Else
                MessageBoxInfo("System Settings not found.")
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fSystemSettingUpdateByBool(prName, prValue)
            Else
                End ' exit program
            End If
        End Try


    End Sub
    Public Sub fSystemSettingUpdateByString(ByVal prName As String, ByVal prValue As String)



        Try
            Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings WHERE `NAME` = '" & prName & "' Limit 1;")
            If rd.Read Then

                SqlExecuted("UPDATE system_settings SET `VALUE`='" & prValue & "' WHERE `NAME` = '" & prName & "'  limit 1;")
            Else
                MessageBoxInfo("System Settings not found.")
            End If
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fSystemSettingUpdateByString(prName, prValue)
            Else
                End ' exit program
            End If
        End Try


    End Sub
    Public Sub fSystemSettingUpdateByNumber(ByVal prName As String, ByVal prValue As Double)
        Try
            Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings where `NAME` = '" & prName & "' Limit 1;")
            If rd.Read Then
                SqlExecuted("UPDATE system_settings SET `VALUE`='" & prValue & "' WHERE `NAME` = '" & prName & "'  limit 1;")
            Else
                MessageBoxInfo("System Settings not found.")
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fSystemSettingUpdateByNumber(prName, prValue)
            Else
                End ' exit program
            End If
        End Try


    End Sub
    Public Function fSystemSettingValue_Num(ByVal prName As String) As Double

        Dim sValue As Double = NumIsNull(fMSgetField("system_value", "tblsystem", "ID", prName))

        If sValue = 0 Then
            Try
                Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings where `NAME` = '" & prName & "' Limit 1")
                If rd.Read Then
                    sValue = NumIsNull(rd("VALUE"))
                Else
                    SqlExecuted("INSERT INTO system_settings SET `VALUE`='0', `NAME` = '" & prName & "'")
                    MessageBoxInfo("New settings = " & prName)
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fSystemSettingValue_Num(prName)
                Else
                    End
                End If
            End Try
        End If
        Return sValue
    End Function
    Public Function fTransactionDefaultDate() As Date
        If Val(fSystemSettingValue("NewTransactionsDefaultDate")) = 0 Then
            Return Date.Now.Date
        Else
            Dim sDate As String = fMSgetField("system_value", "tblsystem", "ID", "LAST_DATE_TRANSACTION")
            If IsDate(sDate) = True Then
                Return sDate
            Else
                Return Date.Now.Date
            End If
        End If
    End Function
    Public Sub fTransactionDateSelectUpdate(ByVal dtp As Date)
        fMS_execute("UPDATE tblsystem set system_value = '" & Format(dtp, "yyyy-MM-dd") & "' where ID = 'LAST_DATE_TRANSACTION' ")
    End Sub
    Public Function fLoadLocationDefault() As Integer

        Dim user_location_id As Integer = fUserDefaultLocation()
        If user_location_id = 0 Then
            Return Val(fSystemSettingValue("DefaultLocationId"))
        Else
            Return user_location_id
        End If

    End Function

    Public Function fLoadStorageLocation() As Integer
        If CBool(Val(fSystemSettingValue("NotUseStorageLocation"))) = False Then
            Return 0
        Else
            Return Val(fSystemSettingValue("StorageLocationId"))
        End If

    End Function
    Public Function fIncRefNoByLocation() As Boolean
        Return CBool(fSystemSettingValue("IncRefNoByLocation"))
    End Function

    Public Function fCashOverShortExpense() As Integer
        Return Val(fSystemSettingValue("CashOverShortExpenseId"))
    End Function
    Public Function fPettyCashAccount() As Integer
        Return Val(fSystemSettingValue("PettyCashAccountId"))
    End Function
    Public Function fDrawerAccount() As Integer
        Dim I As Integer = fPOS_Drawer_Account_PER_UNIT()
        If I <> 0 Then
            Return I
        Else
            Return Val(fSystemSettingValue("DrawerAccountId"))
        End If

    End Function
    Public Function fOutPutTaxDefault() As Integer
        Return Val(fSystemSettingValue("OutputTaxId"))
    End Function
    Public Function fInPutTaxDefault() As Integer
        Return Val(fSystemSettingValue("InputTaxId"))
    End Function
    Public Function fPaymentMethodDefault() As Integer
        Return Val(fSystemSettingValue("DefaultPaymentMethodId"))
    End Function
    Public Function fPaymentTermsDefault() As Integer
        Return Val(fSystemSettingValue("DefaultPaymentTermsId"))
    End Function
    Public Function fLockLocation() As Boolean
        Try


            If CBool(fSystemSettingValue("LockLocation")) = True Then
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            Return True
        End Try
    End Function
    Public Function fCreditLimitPolicy() As Integer
        '0 = Promp warning message only
        '1 = Enforce transaction blocking
        Return Val(fSystemSettingValue("CreditLimitPolicy"))
    End Function
    Public Function fArAgingLimit() As Integer
        '0 = None
        '1 = Current balance only
        '2 = 1 - 30 day past due
        '3 = 31 - 60 day past due
        '4 = 61 - 90 day past due
        Return Val(fSystemSettingValue("ArAgingLimit"))
    End Function
    Public Function fAllowNegativeInventory() As Boolean

        If gsUserDefaulLockNegativePerUser = True Then
            Return False
        Else
            Return fSystemSettingValue("AllowZeroOnHand")
        End If

    End Function
End Module
