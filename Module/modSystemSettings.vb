Imports System.Data.Odbc
Module modSystemSettings

    Public Sub SystemSettingLoadDefaultValue()
        gsDefaultItemAssetAccountId = GetSystemSettingValueByNumber("DefaultItemAssetAccountId")
        gsDefaultItemIncomeAccountId = GetSystemSettingValueByNumber("DefaultItemIncomeAccountId")
        gsDefaultItemCOGSAccountId = GetSystemSettingValueByNumber("DefaultItemCOGSAccountId")
        gsDefaultItemDiscountAccountId = GetSystemSettingValueByNumber("DefaultItemDiscountAccountId")
        gsDefaultItemOtherChargeAccountId = GetSystemSettingValueByNumber("DefaultItemOtherChargeAccountId")
        gsDefaultItemClassId = GetSystemSettingValueByNumber("DefaultItemClassId")
        gsDefaultItemSubClassId = GetSystemSettingValueByNumber("DefaultItemSubClassId")
        gsDefaultItemGroupId = GetSystemSettingValueByNumber("DefaultItemGroupId")
        gsApproved_By = GetSystemSettingValueByText("Approved_By")

    End Sub
    Public Sub SaveSystemControl(ByVal TabCon As TabControl)

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
    Public Sub SetSettingObject(ByVal c As Control, ByVal i As Integer, ByVal v As String)
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
    Public Function GetSettingObject(ByVal prName As String, ByVal c As Control, ByVal i As Integer) As Boolean
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
    Public Sub LoadSubMenuTypeItem()
        Dim rd As OdbcDataReader = SqlReader("select description,form from `tblsub_menu` where active <> '0' ")
        While rd.Read
            Dim sName As String = rd("Description")
            Select Case rd("form")
                '// customer
                Case "FrmInvoice"
                    gsTextInvoice = sName
                Case "FrmReceivePayment"
                    gsTextReceivePayment = sName
                Case "FrmSalesOrder"
                    gsTextSalesOrder = sName
                Case "FrmSalesReceipt"
                    gsTextSalesReceipt = sName
                Case "FrmEstimate"
                    gsTextEstimate = sName
                Case "FrmCreditMemo"
                    gsTextCreditMemo = sName
                Case "FrmTaxCredit"
                    gsTextTaxCredit = sName
                    '// vendor
                Case "FrmPurchaseOrder"
                    gsTextPurchaseOrder = sName
                Case "FrmPurchaseRequest"
                    gsTextPurchaseRequest = sName
                Case "FrmStockReceived"
                    gsTextStockReceived = sName
                Case "FrmBills"
                    gsTextBills = sName
                Case "FrmBillCredit"
                    gsTextBillCredit = sName
                Case "FrmBillPayment"
                    gsTextBillPayment = sName
                Case "FrmWithholdingTax"
                    gsTextWithholdingTax = sName
                    '// Inventory
                Case "FrmBuildAssembly"
                    gsTextBuildAssembly = sName
                Case "FrmInventoryAdjustment"
                    gsTextInventoryAdjustment = sName
                Case "FrmStockTransfer"
                    gsTextStockTransfer = sName
                Case "FrmGeneralJournal"
                    gsTextGeneralJournal = sName
                    '//Banking
                Case "FrmDeposit"
                    gsTextDeposit = sName
                Case "FrmFundTransfer"
                    gsTextFundTransfer = sName
                Case "FrmWriteCheck"
                    gsTextWriteCheck = sName

            End Select
        End While
        rd.Close()
    End Sub
    Public Function IsClosingDate(ByVal prDate As Date, ByVal IsNew As Boolean) As Boolean
        Dim IsDone As Boolean
        If prDate <= ClosingDate() Then
            If IsNew = True Then
                IsDone = False
                MessageBoxWarning("Closing date not allowed")
            Else

                If CBool(GetSystemSettingValueByText("ClosingDatePassword")) = False Then

                    IsDone = False
                Else
                    If IsAccessDenied(gsMessageClosingDatePassword) = False Then
                        IsDone = True
                    Else
                        IsDone = False
                    End If
                End If
            End If
        Else
            IsDone = True
        End If
        Return IsDone
    End Function
    Public Function ClosingDate() As Date
        Try
            Return GetSystemSettingValueByText("ClosingDate")
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
            Return Date.Today
        End Try
    End Function
    Public Sub LoadDefaultAccount()
        gsDefault_ACCOUNTS_RECEIVABLE_ID = GetSystemSettingValueByNumber("DefaultAccountReceivableId")
        gsDefault_ACCOUNTS_PAYABALE_ID = GetSystemSettingValueByNumber("DefaultAccountPayableId")
        gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID = GetSystemSettingValueByNumber("DefaultUndepositedFundAccountId")
        gsDefault_ITEM_ACCOUNT_ID = GetSystemSettingValueByNumber("DefaultItemAccountId")
        gsSTOCK_TRANSFER_ACCOUNT_ID = GetSystemSettingValueByNumber("StockTransferAccountId")
        gsSTOCK_RECEIVED_ACCOUNT_ID = GetSystemSettingValueByNumber("StockReceivedAccountId")
        gsINTER_LOCATION_ACCOUNT_ID = GetSystemSettingValueByNumber("InterLocationAccountId")
        'gsTAX_PAYABLE_ACCOUNT_ID = GetSystemSettingValueByText("TaxPayableAccountId")
        'gsTAX_CREDIT_ACCOUNT_ID = GetSystemSettingValueByText("TaxCreditAccountId")
    End Sub
    Public Function GetSystemSettingValueByText(ByVal prName As String) As String


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
                    sValue = GetSystemSettingValueByText(prName)
                Else
                    End
                End If
            End Try
        End If
        Return sValue
    End Function
    Public Function GetSystemSettingValueByBool(ByVal prName As String) As Boolean
        Dim bValue As Boolean
        Try
            bValue = CBool(fMSgetField("system_value", "tblsystem", "ID", prName))
        Catch ex As Exception
            bValue = False
        End Try


        If bValue = False Then
            Try
                Dim rd As OdbcDataReader = SqlReader("select `VALUE` from system_settings where `NAME` = '" & prName & "' Limit 1")
                If rd.Read Then
                    bValue = rd("VALUE")
                Else
                    SqlExecuted("INSERT INTO system_settings SET `VALUE`='0', `NAME` = '" & prName & "'")
                    MessageBoxInfo("New settings = " & prName)
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    bValue = GetSystemSettingValueByBool(prName)
                Else
                    MessageBox.Show("System Exit")
                    End
                End If
            End Try
        End If
        Return bValue
    End Function

    Public Sub SetSystemSettingUpdateByBool(ByVal prName As String, ByVal prValue As Boolean)
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
                SetSystemSettingUpdateByBool(prName, prValue)
            Else
                MessageBox.Show("System Exit")
                End ' exit program
            End If
        End Try


    End Sub
    Public Sub SetSystemSettingUpdateByText(ByVal prName As String, ByVal prValue As String)

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
                SetSystemSettingUpdateByText(prName, prValue)
            Else
                End ' exit program
            End If
        End Try


    End Sub
    Public Sub SetSystemSettingUpdateByNumber(ByVal prName As String, ByVal prValue As Double)
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
                SetSystemSettingUpdateByNumber(prName, prValue)
            Else
                End ' exit program
            End If
        End Try


    End Sub
    Public Function GetSystemSettingValueByNumber(ByVal prName As String) As Double

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
                    sValue = GetSystemSettingValueByNumber(prName)
                Else
                    End
                End If
            End Try
        End If
        Return sValue
    End Function
    Public Function TransactionDefaultDate() As Date
        If Val(GetSystemSettingValueByText("NewTransactionsDefaultDate")) = 0 Then
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
    Public Sub SetTransactionDateSelectUpdate(ByVal dtp As Date)
        fMS_execute("UPDATE tblsystem set system_value = '" & Format(dtp, "yyyy-MM-dd") & "' where ID = 'LAST_DATE_TRANSACTION' ")
    End Sub
    Public Function GetLoadLocationDefault() As Integer
        Dim user_location_id As Integer = fUserDefaultLocation()
        If user_location_id = 0 Then
            Return Val(GetSystemSettingValueByText("DefaultLocationId"))
        Else
            Return user_location_id
        End If
    End Function

    Public Function GetLoadStorageLocation() As Integer
        If CBool(Val(GetSystemSettingValueByText("NotUseStorageLocation"))) = False Then
            Return 0
        Else
            Return Val(GetSystemSettingValueByText("StorageLocationId"))
        End If
    End Function
    Public Function GetIncRefNoByLocation() As Boolean
        Return CBool(GetSystemSettingValueByText("IncRefNoByLocation"))
    End Function

    Public Function GetCashOverShortExpense() As Integer
        Return Val(GetSystemSettingValueByText("CashOverShortExpenseId"))
    End Function
    Public Function GetPettyCashAccount() As Integer
        Return Val(GetSystemSettingValueByText("PettyCashAccountId"))
    End Function
    Public Function GetDrawerAccount() As Integer
        Dim I As Integer = fPOS_Drawer_Account_PER_UNIT()
        If I <> 0 Then
            Return I
        Else
            Return Val(GetSystemSettingValueByText("DrawerAccountId"))
        End If
    End Function
    Public Function GetOutPutTaxDefault() As Integer
        Return Val(GetSystemSettingValueByText("OutputTaxId"))
    End Function
    Public Function GetInPutTaxDefault() As Integer
        Return Val(GetSystemSettingValueByText("InputTaxId"))
    End Function
    Public Function GetPaymentMethodDefault() As Integer
        Return Val(GetSystemSettingValueByText("DefaultPaymentMethodId"))
    End Function
    Public Function GetPaymentTermsDefault() As Integer
        Return Val(GetSystemSettingValueByText("DefaultPaymentTermsId"))
    End Function
    Public Function IsLockLocation() As Boolean
        Try
            If GetSystemSettingValueByBool("LockLocation") = True Then
                Return False
            Else
                Return True
            End If

        Catch ex As Exception
            Return True
        End Try
    End Function
    Public Function GetCreditLimitPolicy() As Integer
        '0 = Promp warning message only
        '1 = Enforce transaction blocking
        Return Val(GetSystemSettingValueByText("CreditLimitPolicy"))
    End Function
    Public Function GetArAgingLimit() As Integer
        '0 = None
        '1 = Current balance only
        '2 = 1 - 30 day past due
        '3 = 31 - 60 day past due
        '4 = 61 - 90 day past due
        Return GetSystemSettingValueByNumber("ArAgingLimit")
    End Function
    Public Function IsAllowNegativeInventory() As Boolean

        If gsUserDefaulLockNegativePerUser = True Then
            Return False
        Else
            Return GetSystemSettingValueByBool("AllowZeroOnHand")
        End If

    End Function
End Module
