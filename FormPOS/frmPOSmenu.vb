Imports System.Data.Odbc
Public Class FrmPOSmenu
    Dim PrintSave As Boolean = False
    Dim bSaveAccept As Boolean
    Dim OR_REF As Boolean
    Public gsCloseCall As Boolean = False
    Dim bNewContact As Boolean = False
    Dim gsMemberDiscount As Double
    Public ID As String = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Dim h As Integer = 0
    Dim REF_NAME As String

    Private Sub Master_KeyDown(sender As Object, e As KeyEventArgs)
        If txtSearchEntry.Focused = True Then
            If dgvProductItem.Rows.Count <> 0 Then
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Control Then
            PrintAndSave(True)
            Exit Sub
        End If


        Select Case e.KeyCode
            Case Keys.S
                TsSaveFile.PerformClick()
            Case Keys.T
                tsTax.PerformClick()
            Case Keys.B
                tsBuyer.PerformClick()
            Case Keys.M
                tsSalesman.PerformClick()

            Case Keys.P
                tsPayment.PerformClick()
            Case Keys.F1
                TsSaveFile.PerformClick()

            Case Keys.F2
                tsRefresh.PerformClick()
            Case Keys.F3
                tsTax.PerformClick()
            Case Keys.F4
              '  btnPrintOnly.PerformClick()
            Case Keys.F5
                'ts.PerformClick()
            Case Keys.F6
              '  btnITEMLIST.PerformClick()
            Case Keys.F7
                tsBuyer.PerformClick()
            Case Keys.F8
                tsSalesman.PerformClick()
            Case Keys.F9
                tsPayment.PerformClick()
            Case Keys.F10
              '  btnORDERLIST.PerformClick()
            Case Keys.F11
                'btnDrawer.PerformClick()
            Case Keys.F12
                tsBack.PerformClick()
            Case Keys.Insert
                tsAdd.PerformClick()

            Case Keys.A
                tsAdd.PerformClick()
            Case Keys.Delete
                tsDelete.PerformClick()
            Case Keys.D
                tsDelete.PerformClick()

            Case Keys.U
                tsUpdateItem.PerformClick()
            Case Keys.Print

            Case Keys.Enter
                If dgvProductItem.Rows.Count <> 0 Then
                    If dgvProductItem.Focused = True Then
                        tsUpdateItem.PerformClick()
                    End If
                End If
            Case Keys.Up
                dgvProductItem.Select()
            Case Keys.Down
                dgvProductItem.Select()
            Case Keys.Escape
                tsBack.PerformClick()
            Case Else
                If dgvProductItem.Rows.Count <> 0 Then
                    txtSearchEntry.Select()
                End If
        End Select


    End Sub
    Private Function CheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function

    Public Sub PosLogMenu()
        SetNew()
        With FrmPOSLog
            GS_CollectPosLog()
            .ShowDialog()
            If .gsType = 1 Then

                LoadMenu()

            ElseIf .gsType = 0 Then

                gsCloseCall = True
                Me.Close()
            End If
            .Dispose()

        End With
        FrmPOSLog = Nothing

    End Sub

    Private Sub SalesReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gsPOS_DEFAULT_PRINTER = GetDBAccessValueByText("POS_DEFAULT_PRINTER")
        gsDEFAULT_PRINTER = GetDBAccessValueByText("DEFAULT_PRINTER")


        lblCODE.Text = ""
        xlblCustomer_Name.Text = ""
        xlblAcctNo.Text = ""
        xlblTax.Text = " TAX"
        lblOUTPUT_TAX_AMOUNT.Text = "0.00"
        lblAMOUNT.Text = "0.00"
        xlblChange.Text = "0.00"
        lblPAYMENT_AMOUNT.Text = "0.00"
        xxxlblSUB_TOTAL.Text = "0.00"

        GS_Label_Digital_M(xxxlblSUB_TOTAL)
        ' GS_Label_Digital_M(xxxxSUB_TOTAL)

        GS_Label_Digital_L(lblAMOUNT)
        ' GS_Label_Digital_L(xlblTOTAL)

        GS_Label_Digital_M(lblOUTPUT_TAX_AMOUNT)
        ' GS_Label_Digital_M(xlblTax)

        'GS_Label_Digital_S(xlblTender)
        ' GS_Label_Digital_S(xlblChangeLab)

        GS_Label_Digital_L(xlblChange)
        GS_Label_Digital_L(lblPAYMENT_AMOUNT)

        ComboxRefresh()
        ClearAndRefresh(Me)

        Me.Icon = gsIcon
        Tender_Column()

        pcLOGO.BackgroundImage = gsImageNameApp
        pcLOGO.BackgroundImageLayout = ImageLayout.Stretch

        gsPOS_TOTAL = 0
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
        gsSTARTING_RECEIPT_NO = 0
        gsENDING_RECEIPT_NO = 0

        Me.AccessibleName = GF_GetStringFieldValue("tblsub_menu", "form", "frmSalesReceipt", "sub_id")

        gsUserDefaulLockNegativePerUser = GF_UserDefaulLockNegativePerUser()

        OR_REF = GF_IsPosOfficialReceiptRequired()

        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        gsPOSDefaultCustomer_ID = GetSystemSettingValueByText("POSDefaultCustomerId")
        gsDefault_unit_price_level_id = GF_UserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPOS_MACHINE_ID = GF_GetPosMachineId()
        gsDRAWER_ACCOUNT_ID = GF_GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")
        gsPOS_TYPE_ID = GF_PosMachineTypeMap()

        Me.Text = "POS - " & gsSystemName
        ColumnGrid_U_SalesReceipt(dgvProductItem)
        gsMainWith = Me.Width
        gsMainHeight = Me.Height
        POSComputed()

    End Sub

    Private Sub POSRefreshInfo(ByVal prID As String)
        Try
            Dim sQuery As String = "select * from sales_receipt where ID = '" & prID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)
            CUSTOMER_ID_SelectedIndexChanged(1, Nothing)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                POSRefreshInfo(prID)
            Else
                End
            End If
        End Try
    End Sub

    Private Sub RefreshItem(prID As String)
        dgvProductItem.Rows.Clear()
        bRefreshItem = True
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0
        Dim sQuery As String = "SELECT 
  ii.`ID`,
  RowNum.`CODE`,
  RowNum.`DESCRIPTION`,
  ii.`QUANTITY`,
  u.`SYMBOL`,
  ii.`RATE`,
  d.`DESCRIPTION`,
  ii.`DISCOUNT_RATE`,
  ii.`AMOUNT`,
  ii.`TAXABLE`,
  u.`ID` AS UNIT_ID,
  'S' AS `CONTROL_STATUS`,
  rt.`ID` AS `RATE_TYPE`,
  ii.`UNIT_BASE_QUANTITY`,
  d.`ID` AS `DISCOUNT_ID`,
  ii.`TAXABLE_AMOUNT`,
  ii.`TAX_AMOUNT`,
  ii.`COGS_ACCOUNT_ID`,
  ii.`ASSET_ACCOUNT_ID`,
  ii.`INCOME_ACCOUNT_ID`,
  ii.`PRICE_LEVEL_ID` ,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`POS_TRX_TYPE`,
  ii.`POS_EDIT_QTY`,
  ii.`POS_NOTES`,
  ii.`PRINT_IN_FORMS`,
  ii.`DEPOSITED`,
  RowNum.TYPE as `ITEM_TYPE`,
  RowNum.`NON_DISCOUNTED_ITEM`,
  ii.GROUP_LINE_ID,
  ii.BATCH_ID,
  B.BATCH_NO
   
FROM

  sales_receipt_items AS ii 
  LEFT OUTER JOIN item AS RowNum 
    ON RowNum.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
LEFT OUTER JOIN ITEM_BATCHES as B
B.ID = ii.BATCH_ID

    WHERE  ii.`sales_receipt_ID` = '" & ID & "' Order by ii.LINE_NO"

        Try
            Dim XRow As Integer = 0
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For RowNum As Integer = 0 To rd.FieldCount - 1
                    With dgvProductItem.Columns(RowNum)
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(XRow).Cells(RowNum).Value = NumberFormatStandard(GF_NumIsNull(rd(RowNum)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(XRow).Cells(RowNum).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(RowNum)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(XRow).Cells(RowNum).Value = CBool(GF_NumIsNull(rd(RowNum)))
                        Else



                            dgvProductItem.Rows(XRow).Cells(RowNum).Value = GF_TextIsNull(rd(RowNum))

                        End If
                    End With
                Next
                XRow += 1
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItem(prID)
            Else
                End
            End If
        End Try
        bRefreshItem = False
        POSComputed()
        tdgv = New DataGridView
        tdgv = dgvProductItem
        tQuery = SqlUpdate(Me)

    End Sub
    Private Sub GetTenderList()
        dgvTENDER_LIST.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader($"select s.ID,s.PAYMENT_METHOD_ID,s.AMOUNT,s.PAYMENT_REF_NO,s.CARD_NO,p.DESCRIPTION from sales_receipt_tender as s inner join payment_method as p on p.id = s.payment_method_id where sales_receipt_id = '{ID}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}'")
        While rd.Read
            dgvTENDER_LIST.Rows.Add(rd("PAYMENT_METHOD_ID"), rd("DESCRIPTION"), NumberFormatStandard(rd("AMOUNT")), rd("PAYMENT_REF_NO"), rd("CARD_NO"))
        End While
        PaymentMethodPOS()

    End Sub
    Private Sub ClearInfoPOS()

        ClearAndRefresh(Me)

        dgvProductItem.Rows.Clear()
        dgvTENDER_LIST.Rows.Clear()

        xlblAcctNo.Text = ""
        xlblCustomer_Name.Text = ""
        xlblSalesRep.Text = ""
        xlblTax.Text = " TAX"

    End Sub
    Private Sub ComboxRefresh()
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        cmbCUSTOMER_ID.SelectedIndex = -1
        GS_ComboBoxLoad(cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
        cmbPAYMENT_METHOD_ID.SelectedIndex = -1
        GS_ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select * from class", "ID", "NAME")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
        cmbSALES_REP_ID.SelectedIndex = -1
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")

    End Sub
    Private Sub Find_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
            Exit Sub
        Else
            If IsNew = False And ID > 0 Then
                If CheckHasChange() = True Then
                    If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        POSSaveEntry()

                        If tChangeAccept = False Then
                            MessageBoxInfo("Cancel")
                            Exit Sub
                        End If
                    Else
                    End If
                End If
            End If
        End If
        f.AccessibleName = "sales_receipt"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                ClearInfoPOS()
                ID = f.AccessibleDescription
                IsNew = False
                POSRefreshInfo(ID)
                RefreshItem(ID)
            End If
        End If


    End Sub
    Private Function POSCheckifDiscountNext(ByVal ndex As Integer) As Boolean
        Try
            If IsDiscountItem(dgvProductItem.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub POSComputed()
        Dim gsSalesSubTotal As Double
        GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
        xxxlblSUB_TOTAL.Text = NumberFormatStandard(gsSalesSubTotal)

    End Sub

    Private Sub PAYMENT_METHOD_ID_SelectedValueChanged(sender As Object, e As EventArgs)

        Dim card_no As Boolean
        Dim card_value As Boolean = False
        Try
            Dim I As Integer = 0
            If cmbPAYMENT_METHOD_ID.Items.Count <> 0 Then
                I = Val(cmbPAYMENT_METHOD_ID.SelectedValue)
            End If

            Select Case I
                Case 1 'Cash
                    REF_NAME = "O.R No."
                    card_no = False
                    card_value = False
                Case 2 'Check
                    REF_NAME = "Check No."
                    card_no = False
                    card_value = False

                Case 3 'Master Card

                    REF_NAME = "Approval No."
                    card_no = True
                    card_value = True


                Case 4 'Others

                    REF_NAME = "Approval No."
                    card_no = True
                    card_value = True


                Case 5
                    REF_NAME = "Approval No."
                    card_no = True
                    card_value = True

                Case Else

            End Select


        Catch ex As Exception
            REF_NAME = "O.R No."

            card_value = False
        End Try


        txtCARD_NO.Visible = card_value

    End Sub

    Private Sub POSSaveEntry()

        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please  select customer")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item entry")
            Exit Sub
        End If
        If cmbPAYMENT_METHOD_ID.Text = "" Then
            MessageBoxInfo("Please select payment method")
            Exit Sub
        End If


        If GF_NumIsNull(lblPAYMENT_AMOUNT.Text) = 0 Then
            MessageBoxInfo("Please enter payment")
            Exit Sub
        End If


        If OR_REF = True Then
            If txtPAYMENT_REF_NO.Text.Length = 0 Then


                If dgvTENDER_LIST.Rows.Count = 1 Then
                    With dgvTENDER_LIST.CurrentRow
                        cmbPAYMENT_METHOD_ID.SelectedValue = .Cells("PAYMENT_METHOD_ID").Value
                        txtPAYMENT_REF_NO.Text = .Cells("PAYMENT_REF_NO").Value
                        txtCARD_NO.Text = .Cells("CARD_NO").Value
                    End With
                End If
                ' lets check
                Try

                    Dim rdExists_OR As OdbcDataReader = SqlReader($"select RECORDED_ON from SALES_RECEIPT WHERE PAYMENT_REF_NO = '{txtPAYMENT_REF_NO.Text.Replace("'", "`")}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' limit 1;")
                    If rdExists_OR.Read Then
                        rdExists_OR.Close()

                        MessageBoxWarning($"O.R # {txtPAYMENT_REF_NO.Text} already exists.")
                        Exit Sub
                    End If
                    rdExists_OR.Close()

                Catch ex As Exception
                    MessageBoxInfo(ex.Message)
                    Exit Sub
                End Try



                If txtPAYMENT_REF_NO.Text.Length = 0 Then
                    MessageBoxExclamation($"{REF_NAME} is required. save entry canceled.")
                    Exit Sub
                End If

            Else

                ' lets check
                Try

                    Dim rdExists_OR As OdbcDataReader = SqlReader($"select RECORDED_ON from SALES_RECEIPT WHERE PAYMENT_REF_NO = '{txtPAYMENT_REF_NO.Text.Replace("'", "`")}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' limit 1;")
                    If rdExists_OR.Read Then
                        rdExists_OR.Close()

                        MessageBoxWarning($"O.R # {txtPAYMENT_REF_NO.Text} already exists.")
                        Exit Sub
                    End If
                    rdExists_OR.Close()

                Catch ex As Exception
                    MessageBoxInfo(ex.Message)
                    Exit Sub
                End Try


                If txtPAYMENT_REF_NO.Text.Length = 0 Then
                    MessageBoxExclamation($"{REF_NAME} is required. save entry canceled.")
                    Exit Sub
                End If
            End If
        End If


        If dgvTENDER_LIST.Rows.Count = 0 Then
            MessageBoxInfo("No Payment added. save entry canceled.")
            Exit Sub
        End If

        If TsSaveFile.Enabled = False Then
            Exit Sub
        End If

        If TsSaveFile.Enabled = True Then
            TsSaveFile.Enabled = False
        End If

        If IsNew = True Then

            lblCASHIER_ID.Text = gsCashier_ID
            lblCODE.Text = GF_GetNextCode("SALES_RECEIPT", cmbLOCATION_ID.SelectedValue)
            lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text = gsDRAWER_ACCOUNT_ID 'POS user only
            lblDEPOSITED.Text = "0"


            SqlCreate(Me, SQL_Field, SQL_Value)
            ID = ObjectTypeMapId("SALES_RECEIPT")
            SqlExecuted($"INSERT INTO sales_receipt ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},'{ID}','{GetDateTimeNowSql()}','3','{GetDateTimeNowSql()}')")


            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else

            tChangeAccept = True
            SqlExecuted("UPDATE sales_receipt SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "' limit 1")
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If

        '================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            GS_AccountJournalExecute(Val(lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 52, ID, CDate(dtpDATE.Value), 0, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                GS_JournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 52, ID, CDate(dtpDATE.Value), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                GS_AccountJournalExecute(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 52, ID, CDate(dtpDATE.Value), 1, GF_NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================

        If IsNew = True Then
            If OR_REF = False Then
                GS_UpdateNextReceiptNumber()
            Else
                SqlExecuted("Update pos_machine SET NEXT_RECEIPT_NO = '" & Val(txtPAYMENT_REF_NO.Text) + 1 & "' where ID = '" & gsPOS_MACHINE_ID & "' limit 1;")
            End If

        End If
        PosTender(ID)
        SaveSalesReceiptItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)
        If GF_IsTransactionSuccess(ID, "SALES_RECEIPT") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        End If


        bSaveAccept = True
        SaveNotify(Me, IsNew)


        If gsSTARTING_RECEIPT_NO = 0 Then
            gsSTARTING_RECEIPT_NO = Val(txtPAYMENT_REF_NO.Text)
            gsENDING_RECEIPT_NO = gsSTARTING_RECEIPT_NO
        Else
            gsENDING_RECEIPT_NO = Val(txtPAYMENT_REF_NO.Text)
        End If

        IsNew = False
        TsSaveFile.Enabled = True

    End Sub

    Private Sub PosTender(ByVal SALES_RECEIPT_ID As Integer)

        For I As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1

            Dim R As DataGridViewRow = dgvTENDER_LIST.Rows(I)
            Dim rd As OdbcDataReader = SqlReader($"select * from sales_receipt_tender where SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}' and PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}' limit 5;")
            If rd.Read Then
                If R.Visible = True Then
                    SqlExecuted($"UPDATE sales_receipt_tender  SET AMOUNT = '{R.Cells("AMOUNT").Value}',PAYMENT_REF_NO='{R.Cells("PAYMENT_REF_NO").Value}',CARD_NO='{R.Cells("CARD_NO").Value}'  WHERE SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}' and PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}' limit 1;")
                Else
                    SqlExecuted($"DELETE FROM sales_receipt_tender WHERE SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}' and PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}' limit 1; ")
                End If
            Else

                SqlExecuted($"INSERT INTO sales_receipt_tender  SET AMOUNT = '{R.Cells("AMOUNT").Value}',PAYMENT_REF_NO='{R.Cells("PAYMENT_REF_NO").Value}',CARD_NO='{R.Cells("CARD_NO").Value}',SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}',PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}',POS_LOG_ID ='{lblPOS_LOG_ID.Text}';")
            End If
            rd.Close()

        Next

    End Sub
    Private Sub SetNew()
        ClearInfoPOS()
        dgvProductItem.Rows.Clear()
        dgvTENDER_LIST.Rows.Clear()
        POSComputed()
        ID = 0
        IsNew = True
        gsMemberDiscount = 0
        lblPAYMENT_AMOUNT.Text = "0.00"
        xlblChange.Text = "0.00"
        POSComputed()
    End Sub
    Private Sub OUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        POSComputed()
        Select Case GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue)
            Case 14
                xlblTax.Text = " 0% VAT"
            Case 12
                xlblTax.Text = " 12% VAT(I)"
            Case 13
                xlblTax.Text = " 12% VAT(E)"
            Case 2
        End Select

        Try

            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = GF_TextIsNull(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = GF_TextIsNull(rd("TAX_ACCOUNT_ID"))
            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""
                lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub EditItem()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                MessageBoxExclamation("Data Not Found!")
                Exit Sub
            End If

            If Val(lblPAYMENT_AMOUNT.Text) <> 0 Then
                MessageBoxInfo($"Please remove {xlblTender.Text} amount")
                Exit Sub
            End If

            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index

            Dim d As DataGridViewRow = dgvProductItem.Rows(I)
            If d.Cells("ITEM_TYPE").Value = 5 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If
            Dim GROUP_LINE_ID As Integer = 0
            tsITEM_MENU_TOOLS.Enabled = False
            With FrmAddItem

                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If

                .sFormName = "FrmSalesReceipt"
                GROUP_LINE_ID = Val(dgvProductItem.Rows.Item(I).Cells("GROUP_LINE_ID").Value)
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value
                .gsDiscount_Rate = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsPRICE_LEVEL_ID = dgvProductItem.Rows.Item(I).Cells("PRICE_LEVEL_ID").Value
                .gsBATCH_ID = dgvProductItem.Rows.Item(I).Cells("BATCH_ID").Value
                .dgv = dgvProductItem
                .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
                .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
                .gslblAMOUNT = lblAMOUNT
                .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
                .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
                .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE
                .StartPosition = FormStartPosition.Manual
                Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height - (.Height)
                .Location = New Point(dgvProductItem.Location.X, H_PC)
                .ShowDialog()

                If .gsSave = True Then
                    GS_RowDataItemSalesReceipt(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID, False, GROUP_LINE_ID, .gsBATCH_ID)

                End If
            End With
            POSComputed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
        tsITEM_MENU_TOOLS.Enabled = True
    End Sub

    Private Sub ProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_TaxValue(dgvProductItem)
            POSComputed()
        End If
    End Sub
    Private Sub ProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        Master_KeyDown(sender, e)
    End Sub

    Private Sub ProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
    End Sub

    Private Sub TSClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub
    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            POSComputed()
        End If
    End Sub
    Private Function GET_GRAND_TOTAL(ByVal prDATE As Date) As Double
        Dim G_TOTAL As Double = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT pl.`GRAND_TOTAL`
FROM
  sales_receipt AS sr 
  INNER JOIN pos_log AS pl 
    ON pl.`ID` = sr.`POS_LOG_ID` 
WHERE sr.`DATE` < '{DateFormatMySql(prDATE)}' AND
sr.`POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}' and sr.LOCATION_ID = '{gsDefault_LOCATION_ID}'
ORDER BY sr.`DATE` DESC, sr.`ID` DESC 
LIMIT 1")

        If rd.Read Then
            G_TOTAL = GF_NumIsNull(rd("GRAND_TOTAL"))

        End If

        Return G_TOTAL
    End Function

    Private Sub POSMenu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height
        GS_ViewItemDisplay(dgvProductItem)
        GS_ViewNotSort(dgvProductItem)

        Dim IsExit As Boolean = False
        With FrmPOSTransactionList
            .ShowDialog()
            If .gsResume = True Then
                gsPOS_LOG_ID = .Select_POS_LOG_ID
            ElseIf .gsNew = True Then

                gsPOS_LOG_ID = 0
            Else
                IsExit = True
            End If

            FrmPOSTransactionList.Dispose()
        End With
        FrmPOSTransactionList = Nothing
        If IsExit = True Then
            gsCloseCall = True
            Me.Close()
            Exit Sub
        End If


        Dim bStartNew As Boolean = False
        'POS LOG
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID,TRANSACTION_DATE,RECORDED_ON FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and ID ='{gsPOS_LOG_ID}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and CASHIER_ID = '{gsCashier_ID}' ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            LOG_DATE = DateTimeFormatMySql(rd("RECORDED_ON"))

            If GF_NumIsNull(rd("CASH_COUNT_ID")) <> 0 Then
                FrmPOSLogSwitch.ShowDialog()
                bStartNew = FrmPOSLogSwitch.gsStartNew
                FrmPOSLogSwitch.Dispose()
                FrmPOSLogSwitch = Nothing
            End If

            If bStartNew = True Then
                GoTo NewPOS_LOG
            End If

            gsSTARTING_RECEIPT_NO = GF_NumIsNull(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = GF_NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = GF_NumIsNull(rd("STARTING_CASH_ID"))
            gsStartingCash_Amount = GF_GetNumberFieldValue("pos_starting_cash", "ID", gsSTARTING_CASH_ID, "AMOUNT")
            gsENDING_RECEIPT_NO = GF_NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = GF_NumIsNull(rd("CASH_COUNT_ID"))
            gsPOS_DATE = CDate(rd("TRANSACTION_DATE"))
        Else
NewPOS_LOG:
            gsCASH_COUNT_ID = 0
            gsStartingCash_Amount = 0
            gsSTARTING_CASH_ID = 0
            If GF_PosStartingCash() = True Then
                FrmPOSStartingCash.ShowDialog()
                gsStartingCash_Amount = FrmPOSStartingCash.gsStartAmount
                FrmPOSStartingCash.Dispose()
                FrmPOSStartingCash = Nothing
            End If

            gsSTARTING_CASH_ID = ObjectTypeMapId("POS_STARTING_CASH")

            LOG_DATE = GetDateTimeNowSql()

            SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{gsStartingCash_Amount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
            GS_PosStartingCashJournal(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
            GS_PosLogLoad()
        End If
        rd.Close()
        PosLogMenu()
        Exit Sub


    End Sub
    Private Sub ClickMenu(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        gsPOSEntryType = btn.Name
        Dim f As Form = btn.FindForm
        f.Close()
    End Sub
    Private Sub CreateMenu(ByVal prName As String, ByVal prDesplay As String, ByVal f As Form)
        h += 163
        f.Size = New Size(h, f.Height)
        Dim b As New Button With {
            .Font = New Font(gsFont, 20, FontStyle.Bold),
            .Name = prName,
            .Text = prDesplay,
            .Size = New Size(163, 123),
            .Dock = DockStyle.Left
        }
        f.Controls.Add(b)
        AddHandler b.Click, AddressOf ClickMenu
        gsPublicButton = b
    End Sub

    Private Sub POSTypeEntry(ByVal f As Form)
        Dim rd As OdbcDataReader = SqlReader("select * from pos_machine_type_map  where inactive = '0' order by id desc")
        While rd.Read
            Dim id As Integer = rd("ID")
            Dim sName As String = "&" & rd("DESCRIPTION")
            CreateMenu(id, sName, f)
        End While
        rd.Close()
        h = 0
    End Sub
    Private Sub LoadMenu()
        Select Case Val(gsPOS_TYPE_ID)

            Case 0
                'Cash Registry
                ClearInfoPOS()

                LoadDefaultAccount()

                ' fGetCashierName()
                dtpDATE.Value = gsPOS_DATE
                cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID

                cmbCUSTOMER_ID.SelectedValue = Val(gsPOSDefaultCustomer_ID)
                cmbPAYMENT_METHOD_ID.SelectedValue = GetPaymentMethodDefault()
                If OR_REF = False Then
                    txtPAYMENT_REF_NO.Text = GF_GetNextReceiptNumber()
                    PAYMENT_METHOD_ID_SelectedIndexChanged(0, EventArgs.Empty)
                End If

                lblCODE.Text = GF_NextCodePreview("SALES_RECEIPT", cmbLOCATION_ID.SelectedValue)
                lblPOS_MACHINE_ID.Text = gsPOS_MACHINE_ID
                lblPOS_TIMESTAMP.Text = Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss")
                lblPOS_POSTED.Text = "1"
                lblPOS_LOG_ID.Text = gsPOS_LOG_ID
                lblPAYMENT_AMOUNT.Text = "0.00"
                xlblChange.Text = "0.00"

            Case 1
                'Order Entry 
                ClearInfoPOS()

                LoadDefaultAccount()

                'fGetCashierName()
                dtpDATE.Value = TransactionDefaultDate()
                cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
                cmbPAYMENT_METHOD_ID.SelectedValue = GetPaymentMethodDefault()
                cmbCUSTOMER_ID.SelectedValue = Val(gsPOSDefaultCustomer_ID)
                cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
                lblCODE.Text = GF_GetNextReceiptNumber()
                lblSO_MACHINE_ID.Text = gsPOS_MACHINE_ID
                lblPOS_TIMESTAMP.Text = Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss")
                lblPOS_POSTED.Text = "0"
        End Select

        ' PaymentMethodPOS()
        POSComputed()
    End Sub
    Private Sub CUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged

        Dim s As String

        Try
            s = cmbCUSTOMER_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        ' If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub
        xlblCustomer_Name.Text = cmbCUSTOMER_ID.Text
        xlblAcctNo.Text = GF_GetStringFieldValue("CONTACT", "ID", cmbCUSTOMER_ID.SelectedValue, "ACCOUNT_NO")
        Dim rd As OdbcDataReader = SqlReader($"select TAX_ID from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()

            End If

        End If
        rd.Close()
    End Sub
    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If IsNew = True Then
            POSSaveEntry()

        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    POSSaveEntry()

                    If tChangeAccept = False Then
                        MessageBoxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If IsNew = False Then

            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
                If r.Read Then
                    prPrint_Title = r("print_title")
                    prFile_name = r("file_name")
                End If
                cn.Close()
            Catch ex As Exception
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            POSReportParam()
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            GlobalPreviewReport(prPrint_Title & "Report")

        End If
    End Sub
    Private Sub POSReportParam()
        CryParameterInsertValue(gscryRpt, Val(ID), "myid")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")

    End Sub
    Private Sub PrintNow_Click(sender As Object, e As EventArgs) Handles tsPrintNow.Click
        If IsNew = True Then
            POSSaveEntry()

        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    POSSaveEntry()

                    If tChangeAccept = False Then
                        MessageBoxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If


        If bSaveAccept = True Then

            SystemSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)

            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesReceipt' and  [print_default] = '1' ", cn)
                If r.Read Then
                    prPrint_Title = r("print_title")
                    prFile_name = r("file_name")
                End If
                cn.Close()

            Catch ex As Exception
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            POSReportParam()
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)

        End If


    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If IsNew = True Then
            POSSaveEntry()
        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    POSSaveEntry()
                    If tChangeAccept = False Then
                        MessageBoxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If
        If IsNew = False Then
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 52, 5, cmbCUSTOMER_ID.Text, lblCODE.Text, txtNOTES.Text)
        End If
    End Sub
    Private Sub Discard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()
        Else
            If MessageBoxQuestion("Create new?") = True Then
                SetNew()
            Else

                POSRefreshInfo(ID)
                RefreshItem(ID)
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub POSmenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            FrmSplash.Show()
            FrmSplash.Timer1.Enabled = True
            gsMenuSubID = 0
            gsMenuID = 0
            Me.Dispose()
        End If
    End Sub

    Private Sub PaymentMethodPOS()
        xlblTender.Text = "PAYMENT TENDER"
        lblPAYMENT_AMOUNT.Text = NumberFormatStandard(TenderSum())
        xlblChange.Text = NumberFormatStandard(GF_NumIsNull(lblAMOUNT.Text) - GF_NumIsNull(lblPAYMENT_AMOUNT.Text))
    End Sub
    Private Function TenderSum() As Double
        Dim Amount As Double = 0
        For i As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1
            If dgvTENDER_LIST.Rows(i).Visible = True Then
                Amount += GF_NumIsNull(dgvTENDER_LIST.Rows(i).Cells("AMOUNT").Value)
            End If
        Next
        Return Amount
    End Function
    Private Sub PAYMENT_METHOD_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedIndexChanged
        PaymentMethodPOS()
    End Sub

    Private Sub ResetForm()
        ClearInfoPOS()
    End Sub
    Private Sub POSmenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub SALES_REP_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSALES_REP_ID.SelectedIndexChanged
        Try
            Dim s As String = cmbSALES_REP_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try
        If cmbSALES_REP_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbSALES_REP_ID.Text = "" Then Exit Sub
        xlblSalesRep.Text = cmbSALES_REP_ID.Text
    End Sub

    Private Sub ResetFile()
        If dgvProductItem.Rows.Count <> 0 Then
            If MessageBoxQuestion("Do you want to reset?") = False Then
                Exit Sub
            End If
        End If
        LoadMenu()

    End Sub

    Private Sub SaveFile()
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item entry")
            Exit Sub
        End If


        If dgvTENDER_LIST.Rows.Count = 0 Then
            tsPayment.PerformClick()
            If dgvTENDER_LIST.Rows.Count = 0 Then
                Exit Sub
            End If


        End If

        bSaveAccept = False

        POSSaveEntry()

        If bSaveAccept = True Then
            If PrintSave = False Then
                GS_CollectPosLog()
                GS_PosLogLoad()
                PosLogMenu()
            End If

        End If

        PrintSave = False

    End Sub
    Private Sub PrintAndSave(ByVal IsOption As Boolean)
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item entry")
            Exit Sub
        End If
        PrintSave = True

        TsSaveFile.PerformClick()

        bSaveAccept = False
        If IsOption = True Then
            SelectPrintPageToolStripMenuItem.PerformClick()
        Else
            tsPrintNow.PerformClick()
        End If



        If bSaveAccept = True Then
            PrintSave = False
            GS_CollectPosLog()
            GS_PosLogLoad()
            PosLogMenu()
        End If


    End Sub
    Private Sub TaxFile()
        frmPOSTax.ShowDialog()
        If frmPOSTax.gsOk = True Then
            cmbOUTPUT_TAX_ID.SelectedValue = frmPOSTax.gsTax_Id
        End If


        frmPOSTax.Dispose()
        frmPOSTax = Nothing

    End Sub

    Private Sub CustomerLoad()

        frmPOSContacts.gsContact_Type = 1
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

            cmbCUSTOMER_ID.SelectedValue = frmPOSContacts.gsContact_ID
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing

        If bNewContact = True Then
            frmContactDetails.IsNew = True
            frmContactDetails.ContactTypeId = 1
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblCustomer_Name.Text = ""
                xlblAcctNo.Text = ""
                GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = frmContactDetails.ID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub
    Private Sub EmployeeLoad()

        frmPOSContacts.gsContact_Type = 2
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            If frmPOSContacts.gsContact_ID = 0 Then
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedIndex = -1
                xlblSalesRep.Text = ""
            Else
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmPOSContacts.gsContact_ID
            End If
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing
        If bNewContact = True Then
            '   frmContactDetails.PictureBox1.Image = tsSalesRep.Image
            frmContactDetails.IsNew = True
            frmContactDetails.ContactTypeId = 2
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblSalesRep.Text = ""
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmContactDetails.ID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub
    Private Sub ToolStrip2_KeyDown(sender As Object, e As KeyEventArgs) Handles tsITEM_MENU_TOOLS.KeyDown
        Master_KeyDown(sender, e)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If IsNew = True Then
            POSSaveEntry()

        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    POSSaveEntry()

                    If tChangeAccept = False Then
                        MessageBoxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If IsNew = True Then
            Exit Sub
        End If

        frmPrintPage.frmName = "frmSalesReceipt"
        frmPrintPage.ShowDialog()

        Dim v As Integer = frmPrintPage.prValue
        If v = 1 Or v = 2 Then

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesReceipt' and  [print_default] = '1' ", cn)
                If r.Read Then
                    prPrint_Title = r("print_title")
                    prFile_name = r("file_name")
                End If
                cn.Close()
            Catch ex As Exception
                If cn.State = ConnectionState.Open Then
                    cn.Close()
                End If
            End Try

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            POSReportParam()
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False

                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

                frmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
                frmReportViewer.WindowState = FormWindowState.Normal
                frmReportViewer.ShowDialog()
                frmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub
    Private Sub PaymentModeFunc()
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("Please enter item.")
            Exit Sub
        End If

        If dgvTENDER_LIST.Rows.Count <> 0 Then
            Dim N As Integer = MessageBoxQuestionYesNoCancel($"Please select payment option? {vbNewLine}{vbNewLine} Edit payment = [YES] {vbNewLine}{vbNewLine} Add Payment = [NO] {vbNewLine}{vbNewLine} ")
            If N = 1 Then
                EditPayment()

            ElseIf N = 2 Then
                AddPayment()
            End If
        Else
            AddPayment()
        End If

    End Sub

    Private Sub Set_From_Main()
        For I As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1
            Dim R As DataGridViewRow = dgvTENDER_LIST.Rows(I)
            If dgvTENDER_LIST.Rows.Count = 1 Then
                If R.Visible = True Then
                    txtPAYMENT_REF_NO.Text = R.Cells("PAYMENT_REF_NO").Value
                    txtCARD_NO.Text = R.Cells("CARD_NO").Value
                    cmbPAYMENT_METHOD_ID.SelectedValue = R.Cells("PAYMENT_METHOD_ID").Value
                End If
            End If

        Next

    End Sub
    Private Sub AddPayment()
        With frmPOSPayment

            .gsTransTotal = GF_NumIsNull(lblAMOUNT.Text)

            .numAMOUNT.Visible = True
            GS_ComboBoxLoad(.cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
            .gsPaymentMethod_ID = GetPaymentMethodDefault()
            .gsPAYMENT_REF_NO = ""
            .gsCARD_NO = ""
            .gsAMOUNT = NumberFormatFixed(lblAMOUNT.Text)
            .gsNOTES = txtNOTES.Text

            .ShowDialog()
            If .gsOk = True Then
                txtNOTES.Text = .gsNOTES

                For i As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1
                    Dim R As DataGridViewRow = dgvTENDER_LIST.Rows(i)
                    If R.Cells("PAYMENT_METHOD_ID").Value = .gsPaymentMethod_ID Then
                        txtNOTES.Text = .gsNOTES

                        If MessageBoxQuestion("Payment Type already exists. do you want to replace?") = True Then
                            R.Visible = True
                            R.Cells("AMOUNT").Value = .gsAMOUNT
                            R.Cells("PAYMENT_REF_NO").Value = .gsPAYMENT_REF_NO
                            R.Cells("CARD_NO").Value = .gsCARD_NO
                            PaymentMethodPOS()
                        Else
                            MessageBoxInfo("Cancel proccess.")
                        End If

                        Exit Sub
                    End If

                Next


                dgvTENDER_LIST.Rows.Add(.gsPaymentMethod_ID, .cmbPAYMENT_METHOD_ID.Text, .gsAMOUNT, .gsPAYMENT_REF_NO, .gsCARD_NO)

                PaymentMethodPOS()
                Set_From_Main()
            End If
            .Dispose()
        End With
        frmPOSPayment = Nothing
    End Sub
    Private Sub Tender_Column()

        With dgvTENDER_LIST.Columns
            .Clear()
            .Add("PAYMENT_METHOD_ID", "PAYMENT_METHOD_ID")
            .Item("PAYMENT_METHOD_ID").Visible = False
            .Add("METHOD", "METHOD")
            .Add("AMOUNT", "AMOUNT")
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("PAYMENT_REF_NO", "REF #.")
            .Item("PAYMENT_REF_NO").Visible = False
            .Add("CARD_NO", "CARD_NO")
            .Item("CARD_NO").Visible = False

            'METHOD,PAYMENT_REF_NO,CARD_NO,
        End With
        'ss
    End Sub

    Private Sub EditPayment()
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("Please enter item.")
            Exit Sub
        End If
        If dgvTENDER_LIST.Rows.Count = 0 Then

            MessageBoxInfo("No payment selected")
            Exit Sub


        End If

        With frmPOSPayment
            .gsTransTotal = GF_NumIsNull(lblAMOUNT.Text)
            .btnDelete.Visible = True
            .numAMOUNT.Visible = True
            GS_ComboBoxLoad(.cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
            .gsPaymentMethod_ID = dgvTENDER_LIST.CurrentRow.Cells("PAYMENT_METHOD_ID").Value
            .gsPAYMENT_REF_NO = dgvTENDER_LIST.CurrentRow.Cells("PAYMENT_REF_NO").Value
            .gsCARD_NO = dgvTENDER_LIST.CurrentRow.Cells("CARD_NO").Value
            .gsAMOUNT = dgvTENDER_LIST.CurrentRow.Cells("AMOUNT").Value
            .gsNOTES = txtNOTES.Text
            .ShowDialog()
            If .gsOk = True Then
                txtNOTES.Text = .gsNOTES
                For i As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1
                    Dim R As DataGridViewRow = dgvTENDER_LIST.Rows(i)

                    If R.Cells("PAYMENT_METHOD_ID").Value = .gsPaymentMethod_ID Then
                        R.Cells("AMOUNT").Value = .gsAMOUNT
                        R.Cells("PAYMENT_REF_NO").Value = .gsPAYMENT_REF_NO
                        R.Cells("CARD_NO").Value = .gsCARD_NO
                        PaymentMethodPOS()
                        Set_From_Main()
                        Exit For
                    End If

                Next
                PaymentMethodPOS()

            ElseIf .gsRemove = True Then
                dgvTENDER_LIST.CurrentRow.Visible = False
                PaymentMethodPOS()
            End If
            .Dispose()
        End With
        frmPOSPayment = Nothing
    End Sub
    Private Sub Refresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
        ResetFile()
    End Sub

    Private Sub TsSaveFile_Click(sender As Object, e As EventArgs) Handles TsSaveFile.Click
        SaveFile()
    End Sub

    Private Sub Tax_Click_1(sender As Object, e As EventArgs) Handles tsTax.Click
        TaxFile()
    End Sub

    Private Sub Buyer_Click(sender As Object, e As EventArgs) Handles tsBuyer.Click
        CustomerLoad()
    End Sub

    Private Sub Salesman_Click(sender As Object, e As EventArgs) Handles tsSalesman.Click
        EmployeeLoad()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles tsPayment.Click
        PaymentModeFunc()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles tsBack.Click
        If dgvProductItem.Rows.Count <> 0 Then
            If MessageBoxQuestion("Are you sure want to back?") = False Then
                Exit Sub
            End If
        End If
        PosLogMenu()
    End Sub

    Private Sub DeleteItem_Click(sender As Object, e As EventArgs) Handles tsDeleteItem.Click
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            GS_RemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            POSComputed()
        End If
    End Sub

    Private Sub UpdateItem_Click(sender As Object, e As EventArgs) Handles tsUpdateItem.Click
        EditItem()
        dgvProductItem.Focus()
    End Sub

    Private Sub TSAdd_Click(sender As Object, e As EventArgs) Handles tsAdd.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If

        If Val(lblPAYMENT_AMOUNT.Text) <> 0 Then
            MessageBoxInfo($"Please remove {xlblTender.Text} amount")
            Exit Sub
        End If


        tsITEM_MENU_TOOLS.Enabled = False
        With frmAddItemSidePanel
            .StartPosition = FormStartPosition.Manual
            .sFormName = "FrmSalesReceipt"
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE
            .gsPRICE_LEVEL_ID = 0

            If gsMemberDiscount <> 0 Then
                .gsMEMBER = True
                .gsMEMEBER_DISCOUNT = gsMemberDiscount
            End If




            Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height '- (.Height)
            .Location = New Point(-10, 0)

            If My.Computer.Screen.WorkingArea.Width < 1200 Then

            Else
                .Size = New Size(.Size.Width, H_PC)
            End If
            .ShowDialog()

        End With
        POSComputed()
        frmAddItemSidePanel.Dispose()
        frmAddItemSidePanel = Nothing
        dgvProductItem.Focus()
        tsITEM_MENU_TOOLS.Enabled = True
    End Sub
    Private Sub TxtSearchEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchEntry.KeyDown
        Master_KeyDown(sender, e)
    End Sub
    Private Sub DgvTENDER_LIST_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvTENDER_LIST.KeyDown
        Master_KeyDown(sender, e)
    End Sub

End Class