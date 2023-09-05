Imports System.Data.Odbc
Public Class frmPOSmenu
    Dim PrintSave As Boolean = False
    Dim bSaveAccept As Boolean
    Dim OR_REF As Boolean
    Public gsCloseCall As Boolean = False
    Dim bNewContact As Boolean = False
    Dim gsMemberDiscount As Double
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New frmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Dim h As Integer = 0
    Dim REF_NAME As String

    Private Sub fMaster_KeyDown(sender As Object, e As KeyEventArgs)
        If txtSearchEntry.Focused = True Then
            If dgvProductItem.Rows.Count <> 0 Then
                Exit Sub
            End If
        End If

        If e.KeyCode = Keys.F4 AndAlso e.Modifiers = Keys.Control Then
            fPrintSave(True)
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
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function

    Public Sub fPOS_LOG_MENU()
        fSetNew()
        With frmPOSLog
            fCollect_POSLog()
            .ShowDialog()
            If .gsType = 1 Then

                fLoadMenu()

            ElseIf .gsType = 0 Then

                gsCloseCall = True
                Me.Close()
            End If
            .Dispose()

        End With
        frmPOSLog = Nothing

    End Sub

    Private Sub frmSalesReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gsPOS_DEFAULT_PRINTER = fGet_System_VALUE("POS_DEFAULT_PRINTER")
        gsDEFAULT_PRINTER = fGet_System_VALUE("DEFAULT_PRINTER")


        lblCODE.Text = ""
        xlblCustomer_Name.Text = ""
        xlblAcctNo.Text = ""
        xlblTax.Text = " TAX"
        lblOUTPUT_TAX_AMOUNT.Text = "0.00"
        lblAMOUNT.Text = "0.00"
        xlblChange.Text = "0.00"
        lblPAYMENT_AMOUNT.Text = "0.00"
        xxxlblSUB_TOTAL.Text = "0.00"

        fLabel_Digital_M(xxxlblSUB_TOTAL)
        ' fLabel_Digital_M(xxxxSUB_TOTAL)

        fLabel_Digital_L(lblAMOUNT)
        ' fLabel_Digital_L(xlblTOTAL)

        fLabel_Digital_M(lblOUTPUT_TAX_AMOUNT)
        ' fLabel_Digital_M(xlblTax)

        'fLabel_Digital_S(xlblTender)
        ' fLabel_Digital_S(xlblChangeLab)

        fLabel_Digital_L(xlblChange)
        fLabel_Digital_L(lblPAYMENT_AMOUNT)

        fComboxRefresh()
        fCLean_and_refresh(Me)
        fMaterialSkin(Me)
        Me.Icon = gsIcon
        fTender_Column()

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

        Me.AccessibleName = fGetFieldValue("tblsub_menu", "form", "frmSalesReceipt", "sub_id")

        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()

        OR_REF = fPOS_OR_Required()

        gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = fCashOverShortExpense()
        gsPOSDefaultCustomer_ID = fSystemSettingValue("POSDefaultCustomerId")
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = fLoadLocationDefault()
        gsIncRefNoByLocation = fIncRefNoByLocation()
        gsPOS_MACHINE_ID = fPOS_MACHINE_ID()
        gsDRAWER_ACCOUNT_ID = fGetFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")
        gsPOS_TYPE_ID = fPOS_machine_type_map()

        Me.Text = "POS - " & gsSystemName



        fcolumnGrid_U_SalesReceipt(dgvProductItem)
        gsMainWith = Me.Width
        gsMainHeight = Me.Height
        fComputed()

    End Sub

    Private Sub fRefreshInfo(ByVal prID As String)
        Try
            Dim sQuery As String = "select * from sales_receipt where ID = '" & prID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)
            cmbCUSTOMER_ID_SelectedIndexChanged(1, Nothing)
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo(prID)
            Else
                End
            End If
        End Try
    End Sub

    Private Sub fRefreshItem(prID As String)
        dgvProductItem.Rows.Clear()
        bRefreshItem = True
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0
        Dim sQuery As String = "SELECT 
  ii.`ID`,
  i.`CODE`,
  i.`DESCRIPTION`,
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
  i.TYPE as `ITEM_TYPE`,
  i.`NON_DISCOUNTED_ITEM`,
  ii.GROUP_LINE_ID,
  ii.BATCH_ID,
  B.BATCH_NO
   
FROM

  sales_receipt_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
LEFT OUTER JOIN ITEM_BATCHES as B
B.ID = ii.BATCH_ID

    WHERE  ii.`sales_receipt_ID` = '" & gsID & "' Order by ii.LINE_NO"

        Try
            Dim x As Integer = 0
            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatStandard(fNumisNULL(rd(i)))
                        ElseIf fCheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatNoDecimal(fNumisNULL(rd(i)))
                        ElseIf fCheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(fNumisNULL(rd(i)))
                        Else



                            dgvProductItem.Rows(x).Cells(i).Value = fTextisNULL(rd(i))

                        End If
                    End With
                Next
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshItem(prID)
            Else
                End
            End If
        End Try
        bRefreshItem = False
        fComputed()
        tdgv = New DataGridView
        tdgv = dgvProductItem
        tQuery = fFieldCollector(Me)

    End Sub
    Private Sub fGet_TENDER_LIST()
        dgvTENDER_LIST.Rows.Clear()
        Dim rd As OdbcDataReader = fReader($"select s.ID,s.PAYMENT_METHOD_ID,s.AMOUNT,s.PAYMENT_REF_NO,s.CARD_NO,p.DESCRIPTION from sales_receipt_tender as s inner join payment_method as p on p.id = s.payment_method_id where sales_receipt_id = '{gsID}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}'")
        While rd.Read
            dgvTENDER_LIST.Rows.Add(rd("PAYMENT_METHOD_ID"), rd("DESCRIPTION"), fNumFormatStandard(rd("AMOUNT")), rd("PAYMENT_REF_NO"), rd("CARD_NO"))
        End While
        fpaymethod()

    End Sub
    'Private Function fgetTypeValue(ByVal dt As String) As String
    '    If IsNumeric(dt) = True Then
    '        Return Format(dt, "Standard")
    '    Else
    '        Return Nothing
    '    End If
    'End Function
    Private Sub fclear_Info()

        fCLean_and_refresh(Me)

        dgvProductItem.Rows.Clear()
        dgvTENDER_LIST.Rows.Clear()

        xlblAcctNo.Text = ""
        xlblCustomer_Name.Text = ""
        xlblSalesRep.Text = ""
        xlblTax.Text = " TAX"

    End Sub
    Private Sub fComboxRefresh()
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        cmbCUSTOMER_ID.SelectedIndex = -1
        fComboBox(cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
        cmbPAYMENT_METHOD_ID.SelectedIndex = -1
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        fComboBox(cmbCLASS_ID, "select * from class", "ID", "NAME")
        fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
        cmbSALES_REP_ID.SelectedIndex = -1
        fComboBox(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")

    End Sub
    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub
        Else
            If gsNew = False And gsID <> "" Then
                If fCheckHasChange() = True Then
                    If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        fSaveEntry()

                        If tChangeAccept = False Then
                            fMessageboxInfo("Cancel")
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
                fclear_Info()
                gsID = f.AccessibleDescription
                gsNew = False
                fRefreshInfo(gsID)
                fRefreshItem(gsID)
            End If
        End If


    End Sub
    Private Function fCheckifDiscountNext(ByVal ndex As Integer) As Boolean
        Try
            If fDISCOUNT_ITEM(dgvProductItem.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub fComputed()
        Dim gsSalesSubTotal As Double
        fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
        xxxlblSUB_TOTAL.Text = fNumFormatStandard(gsSalesSubTotal)

    End Sub

    Private Sub cmbPAYMENT_METHOD_ID_SelectedValueChanged(sender As Object, e As EventArgs)

        Dim card_no As Boolean = False
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
            card_no = False
            card_value = False
        End Try


        txtCARD_NO.Visible = card_value

    End Sub

    Private Sub fSaveEntry()

        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please  select customer")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item entry")
            Exit Sub
        End If
        If cmbPAYMENT_METHOD_ID.Text = "" Then
            fMessageboxInfo("Please select payment method")
            Exit Sub
        End If


        If fNumisNULL(lblPAYMENT_AMOUNT.Text) = 0 Then
            fMessageboxInfo("Please enter payment")
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

                    Dim rdExists_OR As OdbcDataReader = fReader($"select RECORDED_ON from SALES_RECEIPT WHERE PAYMENT_REF_NO = '{txtPAYMENT_REF_NO.Text.Replace("'", "`")}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' limit 1;")
                    If rdExists_OR.Read Then
                        rdExists_OR.Close()

                        fMessageboxWarning($"O.R # {txtPAYMENT_REF_NO.Text} already exists.")
                        Exit Sub
                    End If
                    rdExists_OR.Close()

                Catch ex As Exception
                    fMessageboxInfo(ex.Message)
                    Exit Sub
                End Try



                If txtPAYMENT_REF_NO.Text.Length = 0 Then
                    fMessageboxExclamation($"{REF_NAME} is required. save entry canceled.")
                    Exit Sub
                End If

            Else

                ' lets check
                Try

                    Dim rdExists_OR As OdbcDataReader = fReader($"select RECORDED_ON from SALES_RECEIPT WHERE PAYMENT_REF_NO = '{txtPAYMENT_REF_NO.Text.Replace("'", "`")}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' limit 1;")
                    If rdExists_OR.Read Then
                        rdExists_OR.Close()

                        fMessageboxWarning($"O.R # {txtPAYMENT_REF_NO.Text} already exists.")
                        Exit Sub
                    End If
                    rdExists_OR.Close()

                Catch ex As Exception
                    fMessageboxInfo(ex.Message)
                    Exit Sub
                End Try


                If txtPAYMENT_REF_NO.Text.Length = 0 Then
                    fMessageboxExclamation($"{REF_NAME} is required. save entry canceled.")
                    Exit Sub
                End If
            End If
        End If


        If dgvTENDER_LIST.Rows.Count = 0 Then
            fMessageboxInfo("No Payment added. save entry canceled.")
            Exit Sub
        End If

        If TsSaveFile.Enabled = False Then
            Exit Sub
        End If

        If TsSaveFile.Enabled = True Then
            TsSaveFile.Enabled = False
        End If

        If gsNew = True Then

            lblCASHIER_ID.Text = gsCashier_ID
            lblCODE.Text = fNEXT_CODE("SALES_RECEIPT", cmbLOCATION_ID.SelectedValue)
            lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text = gsDRAWER_ACCOUNT_ID 'POS user only
            lblDEPOSITED.Text = "0"

            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("SALES_RECEIPT")
            squery = squery & ",ID='" & gsID & "',RECORDED_ON='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "',STATUS='3',STATUS_DATE='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            squery = fNullOTherField(squery, "SALES_RECEIPT")

            fExecutedOnly("INSERT INTO sales_receipt SET " & squery & ";")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else

            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)
            squery = squery & " WHERE ID = '" & gsID & "' limit 1;"

            fExecutedOnly("UPDATE sales_receipt SET " & squery)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If


        '================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            fAccount_Journal_SQL(Val(lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 52, gsID, CDate(dtpDATE.Value), 0, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If fNumisNULL(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 52, gsID, CDate(dtpDATE.Value), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 52, gsID, CDate(dtpDATE.Value), 1, fNumisNULL(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================

        If gsNew = True Then

            If OR_REF = False Then

                fUPDATE_NEXT_RECEIPT_NO()
            Else
                fExecutedOnly("Update pos_machine SET NEXT_RECEIPT_NO = '" & Val(txtPAYMENT_REF_NO.Text) + 1 & "' where ID = '" & gsPOS_MACHINE_ID & "' limit 1;")
            End If

        End If
        fPOS_TENDER(gsID)
        '   fSaveItem()  ' Save item
        fSales_Receipt_Save_Item_Set(gsID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

        If fTransactionCheck(gsID, "SALES_RECEIPT") = False Then
            fMessageboxWarning("Please try again")
            Exit Sub
        End If


        bSaveAccept = True
        fSavePopUp(Me, gsNew)


        If gsSTARTING_RECEIPT_NO = 0 Then
            gsSTARTING_RECEIPT_NO = Val(txtPAYMENT_REF_NO.Text)
            gsENDING_RECEIPT_NO = gsSTARTING_RECEIPT_NO
        Else
            gsENDING_RECEIPT_NO = Val(txtPAYMENT_REF_NO.Text)
        End If

        gsNew = False
        TsSaveFile.Enabled = True

    End Sub

    Private Sub fPOS_TENDER(ByVal SALES_RECEIPT_ID As Integer)

        For I As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1

            Dim R As DataGridViewRow = dgvTENDER_LIST.Rows(I)
            Dim rd As OdbcDataReader = fReader($"select * from sales_receipt_tender where SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}' and PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}' limit 5;")
            If rd.Read Then
                If R.Visible = True Then
                    fExecutedOnly($"UPDATE sales_receipt_tender  SET AMOUNT = '{R.Cells("AMOUNT").Value}',PAYMENT_REF_NO='{R.Cells("PAYMENT_REF_NO").Value}',CARD_NO='{R.Cells("CARD_NO").Value}'  WHERE SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}' and PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}' limit 1;")
                Else
                    fExecutedOnly($"DELETE FROM sales_receipt_tender WHERE SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}' and PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}' and POS_LOG_ID ='{lblPOS_LOG_ID.Text}' limit 1; ")
                End If
            Else

                fExecutedOnly($"INSERT INTO sales_receipt_tender  SET AMOUNT = '{R.Cells("AMOUNT").Value}',PAYMENT_REF_NO='{R.Cells("PAYMENT_REF_NO").Value}',CARD_NO='{R.Cells("CARD_NO").Value}',SALES_RECEIPT_ID = '{SALES_RECEIPT_ID}',PAYMENT_METHOD_ID ='{R.Cells("PAYMENT_METHOD_ID").Value}',POS_LOG_ID ='{lblPOS_LOG_ID.Text}';")
            End If
            rd.Close()

        Next

    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        dgvTENDER_LIST.Rows.Clear()
        fComputed()
        gsID = ""
        gsNew = True
        gsMemberDiscount = 0
        lblPAYMENT_AMOUNT.Text = "0.00"
        xlblChange.Text = "0.00"
        fComputed()
    End Sub
    'Private Sub fSaveItem()



    'End Sub
    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Select Case fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue)
            Case 14
                xlblTax.Text = " 0% VAT"
            Case 12
                xlblTax.Text = " 12% VAT(I)"
            Case 13
                xlblTax.Text = " 12% VAT(E)"
            Case 2
        End Select

        Try

            Dim rd As OdbcDataReader = fReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = fTextisNULL(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = fTextisNULL(rd("TAX_ACCOUNT_ID"))
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

    Private Sub fEditItem()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                fMessageboxExclamation("Data Not Found!")
                Exit Sub
            End If

            If Val(lblPAYMENT_AMOUNT.Text) <> 0 Then
                fMessageboxInfo($"Please remove {xlblTender.Text} amount")
                Exit Sub
            End If

            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index

            Dim d As DataGridViewRow = dgvProductItem.Rows(I)
            If d.Cells("ITEM_TYPE").Value = 5 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fDISCOUNT_ITEM(d.Cells("ITEM_TYPE").Value) = True Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fNumisNULL(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            End If
            Dim GROUP_LINE_ID As Integer = 0
            tsITEM_MENU_TOOLS.Enabled = False
            With frmAddItem

                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If

                .sFormName = "frmSalesReceipt"
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
                    fRow_Data_Item_Sales_Receipt(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID, False, GROUP_LINE_ID, .gsBATCH_ID)

                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
        tsITEM_MENU_TOOLS.Enabled = True
    End Sub



    Private Sub lklEdit_LinkClicked()
        fEditItem()
    End Sub
    Private Sub dgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            fTax_Value(dgvProductItem)
            fComputed()
        End If
    End Sub
    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

    End Sub

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        fCloseForm(Me)
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If

    End Sub

    Private Sub frmSalesReceipt_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Function fGET_GRAND_TOTAL(ByVal prDATE As Date) As Double
        Dim G_TOTAL As Double = 0
        Dim rd As OdbcDataReader = fReader($"SELECT pl.`GRAND_TOTAL`
FROM
  sales_receipt AS sr 
  INNER JOIN pos_log AS pl 
    ON pl.`ID` = sr.`POS_LOG_ID` 
WHERE sr.`DATE` < '{fDateFormatMYSQL(prDATE)}' AND
sr.`POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}' and sr.LOCATION_ID = '{gsDefault_LOCATION_ID}'
ORDER BY sr.`DATE` DESC, sr.`ID` DESC 
LIMIT 1")

        If rd.Read Then
            G_TOTAL = fNumisNULL(rd("GRAND_TOTAL"))

        End If

        Return G_TOTAL
    End Function

    Private Sub frmSalesReceipt_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height
        ' Dim H_ As Integer = Screen.PrimaryScreen.Bounds.Height
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = H_PC
        'Me.Location = New Point(0, 0)

        fdgvItemDisplay(dgvProductItem)
        fDgvNotSort(dgvProductItem)

        Dim IsExit As Boolean = False
        With frmPOSTransactionList
            .ShowDialog()
            If .gsResume = True Then
                gsPOS_LOG_ID = .Select_POS_LOG_ID
            ElseIf .gsNew = True Then

                gsPOS_LOG_ID = 0
            Else
                IsExit = True
            End If

            frmPOSTransactionList.Dispose()
        End With
        frmPOSTransactionList = Nothing
        If IsExit = True Then
            gsCloseCall = True
            Me.Close()
            Exit Sub
        End If


        Dim bStartNew As Boolean = False
        'POS LOG
        Dim rd As OdbcDataReader = fReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID,TRANSACTION_DATE,RECORDED_ON FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and ID ='{gsPOS_LOG_ID}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and CASHIER_ID = '{gsCashier_ID}' ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            LOG_DATE = fDateTimeFormatStandard(rd("RECORDED_ON"))

            If fNumisNULL(rd("CASH_COUNT_ID")) <> 0 Then
                FrmPOSLogSwitch.ShowDialog()
                bStartNew = FrmPOSLogSwitch.gsStartNew
                FrmPOSLogSwitch.Dispose()
                FrmPOSLogSwitch = Nothing
            End If

            If bStartNew = True Then
                GoTo NewPOS_LOG
            End If

            gsSTARTING_RECEIPT_NO = fNumisNULL(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = fNumisNULL(rd("ID"))
            gsSTARTING_CASH_ID = fNumisNULL(rd("STARTING_CASH_ID"))
            gsStartingCash_Amount = fNumFieldValue("pos_starting_cash", "ID", gsSTARTING_CASH_ID, "AMOUNT")
            gsENDING_RECEIPT_NO = fNumisNULL(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = fNumisNULL(rd("CASH_COUNT_ID"))
            gsPOS_DATE = CDate(rd("TRANSACTION_DATE"))
        Else
NewPOS_LOG:
            gsCASH_COUNT_ID = 0
            gsStartingCash_Amount = 0
            gsSTARTING_CASH_ID = 0
            If fPOS_STARTING_CASH() = True Then
                frmPOSStartingCash.ShowDialog()
                gsStartingCash_Amount = frmPOSStartingCash.gsStartAmount
                frmPOSStartingCash.Dispose()
                frmPOSStartingCash = Nothing
            End If

            gsSTARTING_CASH_ID = fObjectTypeMap_ID("POS_STARTING_CASH")

            LOG_DATE = fDateTimeNow()

            fExecutedOnly($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{gsStartingCash_Amount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
            fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
            fPOS_LOG()
        End If
        rd.Close()
        fPOS_LOG_MENU()
        Exit Sub


    End Sub
    Private Sub fClickMenu(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        gsPOSEntryType = btn.Name
        Dim f As Form = btn.FindForm
        f.Close()
    End Sub
    Private Sub fCreateMenu(ByVal prName As String, ByVal prDesplay As String, ByVal f As Form)
        h = h + 163
        f.Size = New Size(h, f.Height)
        Dim b As New Button
        b.Font = New Font(gsFont, 20, FontStyle.Bold)
        b.Name = prName
        b.Text = prDesplay
        b.Size = New Size(163, 123)
        b.Dock = DockStyle.Left
        f.Controls.Add(b)
        AddHandler b.Click, AddressOf fClickMenu
        gsPublicButton = b
    End Sub

    Private Sub fPOSTypeEntry(ByVal f As Form)
        Dim rd As OdbcDataReader = fReader("select * from pos_machine_type_map  where inactive = '0' order by id desc")
        While rd.Read
            Dim id As Integer = rd("ID")
            Dim sName As String = "&" & rd("DESCRIPTION")
            fCreateMenu(id, sName, f)
        End While
        rd.Close()
        h = 0
    End Sub
    Private Sub fLoadMenu()



        Select Case Val(gsPOS_TYPE_ID)

            Case 0
                'Cash Registry
                fclear_Info()

                fDefaultAccountLoad()

                ' fGetCashierName()
                dtpDATE.Value = gsPOS_DATE
                cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID

                cmbCUSTOMER_ID.SelectedValue = Val(gsPOSDefaultCustomer_ID)
                cmbPAYMENT_METHOD_ID.SelectedValue = fPaymentMethodDefault()
                If OR_REF = False Then
                    txtPAYMENT_REF_NO.Text = fGET_NEXT_RECEIPT_NO()
                    cmbPAYMENT_METHOD_ID_SelectedIndexChanged(0, EventArgs.Empty)
                End If

                lblCODE.Text = fNEXT_CODE_Preview("SALES_RECEIPT", cmbLOCATION_ID.SelectedValue)
                lblPOS_MACHINE_ID.Text = gsPOS_MACHINE_ID
                lblPOS_TIMESTAMP.Text = Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss")
                lblPOS_POSTED.Text = "1"
                lblPOS_LOG_ID.Text = gsPOS_LOG_ID
                lblPAYMENT_AMOUNT.Text = "0.00"
                xlblChange.Text = "0.00"

            Case 1
                'Order Entry 
                fclear_Info()

                fDefaultAccountLoad()

                'fGetCashierName()
                dtpDATE.Value = fTransactionDefaultDate()
                cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
                cmbPAYMENT_METHOD_ID.SelectedValue = fPaymentMethodDefault()
                cmbCUSTOMER_ID.SelectedValue = Val(gsPOSDefaultCustomer_ID)
                cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
                lblCODE.Text = fGET_NEXT_RECEIPT_NO()
                lblSO_MACHINE_ID.Text = gsPOS_MACHINE_ID
                lblPOS_TIMESTAMP.Text = Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss")
                lblPOS_POSTED.Text = "0"
        End Select

        ' fpaymethod()
        fComputed()
    End Sub
    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged

        Dim s As String = ""

        Try
            s = cmbCUSTOMER_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        ' If gsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub
        xlblCustomer_Name.Text = cmbCUSTOMER_ID.Text
        xlblAcctNo.Text = fGetFieldValue("CONTACT", "ID", cmbCUSTOMER_ID.SelectedValue, "ACCOUNT_NO")
        Dim rd As OdbcDataReader = fReader($"select TAX_ID from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If fNumisNULL(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = fNumisNULL(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()

            End If

        End If
        rd.Close()
    End Sub





    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If gsNew = True Then
            fSaveEntry()

        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    fSaveEntry()

                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If gsNew = False Then

            'If fACCESS_PRINT_PREVIEW(Me) = False Then
            '    Exit Sub
            'End If

            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fReportParam()
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            fPreviewReport(prPrint_Title & "Report")

        End If
    End Sub
    Private Sub fReportParam()
        fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyTin"), "tin_number")

    End Sub
    Private Sub tsPrintNow_Click(sender As Object, e As EventArgs) Handles tsPrintNow.Click
        If gsNew = True Then
            fSaveEntry()

        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    fSaveEntry()

                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If


        If bSaveAccept = True Then

            fSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesReceipt' and  [print_default] = '1' ", cn)
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

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fReportParam()
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)

        End If


    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If gsNew = True Then
            fSaveEntry()
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    fSaveEntry()

                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If
        If gsNew = False Then
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 52, 5, cmbCUSTOMER_ID.Text, lblCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
            fSetNew()
        Else
            If fMessageBoxQuestion("Create new?") = True Then
                fSetNew()
            Else

                fRefreshInfo(gsID)
                fRefreshItem(gsID)
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub txtNOTES_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub frmPOSmenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            frmSplash.Show()
            frmSplash.Timer1.Enabled = True
            gsMenuSubID = ""
            gsMenuID = ""
            Me.Dispose()
        End If
    End Sub

    Private Sub tsCustomer_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsTax_Click(sender As Object, e As EventArgs)



    End Sub
    Private Sub fpaymethod()
        ' xlblPaymentMethod.Text = "P. Method : " & cmbPAYMENT_METHOD_ID.Text & IIf(txtPAYMENT_REF_NO.Text.Length = 0, "", vbNewLine & lbslREF_No.Text & " : ") & txtPAYMENT_REF_NO.Text & IIf(txtCARD_NO.Text.Length = 0, "", vbNewLine & lbslCARD_NO.Text & " : ") & txtCARD_NO.Text

        xlblTender.Text = "PAYMENT TENDER"
        lblPAYMENT_AMOUNT.Text = fNumFormatStandard(fTenderSum())
        xlblChange.Text = fNumFormatStandard(fNumisNULL(lblAMOUNT.Text) - fNumisNULL(lblPAYMENT_AMOUNT.Text))


    End Sub
    Private Function fTenderSum() As Double
        Dim AMT As Double = 0

        For i As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1
            If dgvTENDER_LIST.Rows(i).Visible = True Then
                AMT = AMT + dgvTENDER_LIST.Rows(i).Cells("AMOUNT").Value
                ' txtNOTES.Text = txtNOTES.Text & $"TYPE->{dgvTENDER_LIST.Rows(i).Cells("METHOD").Value}/ REF#->{dgvTENDER_LIST.Rows(i).Cells("PAYMENT_REF_NO").Value.ToString.Replace("'", "")}/ OTHER No.->{dgvTENDER_LIST.Rows(i).Cells("CARD_NO").Value.ToString.Replace("'", "")}"
                'METHOD,PAYMENT_REF_NO,CARD_NO,
            End If
        Next
        Return AMT
    End Function
    Private Sub cmbPAYMENT_METHOD_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedIndexChanged
        fpaymethod()
    End Sub

    Private Sub fReset()
        fclear_Info()

    End Sub




    Private Sub frmPOSmenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If




    End Sub

    Private Sub tsTendered_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsExit_Click(sender As Object, e As EventArgs)
        fPOS_LOG_MENU()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsSalesRep_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSALES_REP_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSALES_REP_ID.SelectedIndexChanged
        Try
            Dim s As String = cmbSALES_REP_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try
        If cmbSALES_REP_ID Is Nothing Then Exit Sub
        If gsNew = False Then Exit Sub
        If cmbSALES_REP_ID.Text = "" Then Exit Sub
        xlblSalesRep.Text = cmbSALES_REP_ID.Text
    End Sub
    Private Sub tsPrintReceipt_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        tsCustomer_Click(sender, e)
    End Sub



    Private Sub TaxToolStripMenuItem_Click(sender As Object, e As EventArgs)
        tsTax_Click(sender, e)
    End Sub

    Private Sub SalesRepToolStripMenuItem_Click(sender As Object, e As EventArgs)
        tsSalesRep_Click(sender, e)
    End Sub

    Private Sub ClassToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OrderListToolStripMenuItem_Click(sender As Object, e As EventArgs)
        tsOrderEntry_Click(sender, e)
    End Sub

    Private Sub tsOrderEntry_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TenderedToolStripMenuItem_Click(sender As Object, e As EventArgs)
        tsTendered_Click(sender, e)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(sender As Object, e As EventArgs)
        tsPrintReceipt_Click(sender, e)
    End Sub

    Private Sub DrawerToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsOpenDrawer_Click(sender As Object, e As EventArgs)

    End Sub

    'Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
    '    tsReset_Click(sender, e)
    'End Sub



    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub tsAddItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub tsTextFind_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsTextFind_TextChanged(sender As Object, e As EventArgs)
        fGetQuickFind(dgvProductItem, txtSearchEntry.Text)
    End Sub

    Private Sub fResetFile()
        If dgvProductItem.Rows.Count <> 0 Then
            If fMessageBoxQuestion("Do you want to reset?") = False Then
                Exit Sub
            End If
        End If
        fLoadMenu()

    End Sub

    Private Sub MaterialRaisedButton7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub fSaveFile()
        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item entry")
            Exit Sub
        End If


        If dgvTENDER_LIST.Rows.Count = 0 Then
            tsPayment.PerformClick()
            If dgvTENDER_LIST.Rows.Count = 0 Then
                Exit Sub
            End If


        End If

        bSaveAccept = False

        fSaveEntry()

        If bSaveAccept = True Then
            If PrintSave = False Then
                fCollect_POSLog()
                fPOS_LOG()
                fPOS_LOG_MENU()
            End If

        End If

        PrintSave = False

    End Sub
    Private Sub fPrintSave(ByVal IsOption As Boolean)
        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item entry")
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
            fCollect_POSLog()
            fPOS_LOG()
            fPOS_LOG_MENU()
        End If


    End Sub
    Private Sub ftaxFile()
        frmPOSTax.ShowDialog()
        If frmPOSTax.gsOk = True Then
            cmbOUTPUT_TAX_ID.SelectedValue = frmPOSTax.gsTax_Id
        End If


        frmPOSTax.Dispose()
        frmPOSTax = Nothing

    End Sub

    Private Sub BtnSavePrint_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub MaterialRaisedButton9_Click(sender As Object, e As EventArgs)
        '  tsOpenDrawer_Click(sender, e)
    End Sub


    Private Sub BtnTAX_Click(sender As Object, e As EventArgs)
        '    fPrintSave(False)
    End Sub
    Private Sub fBuyer()

        frmPOSContacts.gsContact_Type = 1
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

            cmbCUSTOMER_ID.SelectedValue = frmPOSContacts.gsContact_ID
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing

        If bNewContact = True Then
            frmContactDetails.bNew = True
            '  frmContactDetails.PictureBox1.Image = tsCustomer.Image
            frmContactDetails.gsContact_Type = 1
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblCustomer_Name.Text = ""
                xlblAcctNo.Text = ""

                fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = frmContactDetails.gsID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub



    Private Sub fMember()
        frmPOSContacts.gsContact_Type = 2
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            If frmPOSContacts.gsContact_ID = 0 Then
                fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedIndex = -1
                xlblSalesRep.Text = ""
            Else
                fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmPOSContacts.gsContact_ID
            End If
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing
        If bNewContact = True Then
            '   frmContactDetails.PictureBox1.Image = tsSalesRep.Image
            frmContactDetails.bNew = True
            frmContactDetails.gsContact_Type = 2
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblSalesRep.Text = ""
                fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmContactDetails.gsID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub
    Private Sub BtnSALESMAN_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnBACK_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnFIND_Click(sender As Object, e As EventArgs)
        'With frmPOSFindEntry
        '    .ShowDialog()
        '    If .GetID <> 0 Then
        '        fclear_Info()
        '        gsID = .GetID
        '        gsNew = False
        '        fRefreshInfo(gsID)
        '        fRefreshItem(gsID)
        '        fGet_TENDER_LIST()
        '        Dim P As Double = lblPAYMENT_AMOUNT.Text
        '        lblPAYMENT_AMOUNT.Text = fNumFormatStandard(P)
        '    End If
        'End With
    End Sub

    Private Sub btnSave_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnSavePrint_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnTAX_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnBACK_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnCUSTOMER_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnDISCON_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnDrawer_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnFIND_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnITEMLIST_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnORDER_ENTRY_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnPaymentMethod_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnSALESMAN_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles xlblChangeLab.Click

    End Sub

    Private Sub LblOUTPUT_TAX_AMOUNT_Click(sender As Object, e As EventArgs) Handles lblOUTPUT_TAX_AMOUNT.Click

    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tsITEM_MENU_TOOLS.ItemClicked

    End Sub

    Private Sub ToolStrip2_KeyDown(sender As Object, e As KeyEventArgs) Handles tsITEM_MENU_TOOLS.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub Panel1_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub TsTextFind_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsTextFind_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)

    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If gsNew = True Then
            fSaveEntry()

        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    fSaveEntry()

                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If gsNew = True Then
            Exit Sub
        End If

        frmPrintPage.frmName = "frmSalesReceipt"
        frmPrintPage.ShowDialog()

        Dim v As Integer = frmPrintPage.prValue
        If v = 1 Or v = 2 Then

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesReceipt' and  [print_default] = '1' ", cn)
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

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fReportParam()
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False

                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

                frmReportViewer.Text = "POS Preview " & fDateTimeNow()
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

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub LblPAYMENT_AMOUNT_Click(sender As Object, e As EventArgs) Handles lblPAYMENT_AMOUNT.Click

    End Sub

    Private Sub lblPAYMENT_AMOUNT_TextChanged(sender As Object, e As EventArgs) Handles lblPAYMENT_AMOUNT.TextChanged

    End Sub
    Private Sub fPayment()
        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("Please enter item.")
            Exit Sub
        End If

        If dgvTENDER_LIST.Rows.Count <> 0 Then
            Dim N As Integer = fMessageBoxQuestionYesNoCancel($"Please select payment option? {vbNewLine}{vbNewLine} Edit payment = [YES] {vbNewLine}{vbNewLine} Add Payment = [NO] {vbNewLine}{vbNewLine} ")
            If N = 1 Then
                fEditPayment()

            ElseIf N = 2 Then

                fAddPayment()
            End If
        Else
            fAddPayment()
        End If

    End Sub
    Private Sub btnPaymentOption_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub fSet_From_Main()
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
    Private Sub fAddPayment()
        With frmPOSPayment

            .gsTransTotal = fNumisNULL(lblAMOUNT.Text)

            .numAMOUNT.Visible = True
            fComboBox(.cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
            .gsPaymentMethod_ID = fPaymentMethodDefault()
            .gsPAYMENT_REF_NO = ""
            .gsCARD_NO = ""
            .gsAMOUNT = fNumFormatFixed(lblAMOUNT.Text)
            .gsNOTES = txtNOTES.Text

            .ShowDialog()
            If .gsOk = True Then
                txtNOTES.Text = .gsNOTES

                For i As Integer = 0 To dgvTENDER_LIST.Rows.Count - 1
                    Dim R As DataGridViewRow = dgvTENDER_LIST.Rows(i)
                    If R.Cells("PAYMENT_METHOD_ID").Value = .gsPaymentMethod_ID Then
                        txtNOTES.Text = .gsNOTES

                        If fMessageBoxQuestion("Payment Type already exists. do you want to replace?") = True Then
                            R.Visible = True
                            R.Cells("AMOUNT").Value = .gsAMOUNT
                            R.Cells("PAYMENT_REF_NO").Value = .gsPAYMENT_REF_NO
                            R.Cells("CARD_NO").Value = .gsCARD_NO
                            fpaymethod()
                        Else
                            fMessageboxInfo("Cancel proccess.")
                        End If

                        Exit Sub
                    End If

                Next


                dgvTENDER_LIST.Rows.Add(.gsPaymentMethod_ID, .cmbPAYMENT_METHOD_ID.Text, .gsAMOUNT, .gsPAYMENT_REF_NO, .gsCARD_NO)

                fpaymethod()
                fSet_From_Main()
            End If
            .Dispose()
        End With
        frmPOSPayment = Nothing
    End Sub
    Private Sub fTender_Column()

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

    Private Sub btnORDERLIST_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnAddPaymentOption_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub DgvTENDER_LIST_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnEditPaymentOption_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles xlblAcctNo.Click

    End Sub
    Private Sub fEditPayment()
        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("Please enter item.")
            Exit Sub
        End If
        If dgvTENDER_LIST.Rows.Count = 0 Then

            fMessageboxInfo("No payment selected")
            Exit Sub


        End If

        With frmPOSPayment
            .gsTransTotal = fNumisNULL(lblAMOUNT.Text)
            .btnDelete.Visible = True
            .numAMOUNT.Visible = True
            fComboBox(.cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
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
                        fpaymethod()
                        fSet_From_Main()
                        Exit For
                    End If

                Next
                fpaymethod()

            ElseIf .gsRemove = True Then
                dgvTENDER_LIST.CurrentRow.Visible = False
                fpaymethod()
            End If
            .Dispose()
        End With
        frmPOSPayment = Nothing
    End Sub
    Private Sub btnAddPaymentOption_DoubleClick(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvTENDER_LIST_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub btnITEMLIST_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub tsRefresh_Click(sender As Object, e As EventArgs) Handles tsRefresh.Click
        fResetFile()
    End Sub

    Private Sub TsSaveFile_Click(sender As Object, e As EventArgs) Handles TsSaveFile.Click
        fSaveFile()
    End Sub

    Private Sub tsTax_Click_1(sender As Object, e As EventArgs) Handles tsTax.Click
        ftaxFile()
    End Sub

    Private Sub tsBuyer_Click(sender As Object, e As EventArgs) Handles tsBuyer.Click
        fBuyer()
    End Sub

    Private Sub tsSalesman_Click(sender As Object, e As EventArgs) Handles tsSalesman.Click
        fMember()
    End Sub

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles tsPayment.Click
        fPayment()
    End Sub

    Private Sub ToolStripButton11_Click(sender As Object, e As EventArgs) Handles tsBack.Click
        If dgvProductItem.Rows.Count <> 0 Then

            If fMessageBoxQuestion("Are you sure want to back?") = False Then
                Exit Sub
            End If
        End If

        fPOS_LOG_MENU()
    End Sub

    Private Sub tsDeleteItem_Click(sender As Object, e As EventArgs) Handles tsDeleteItem.Click
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            fRemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            fComputed()
        End If
    End Sub

    Private Sub tsUpdateItem_Click(sender As Object, e As EventArgs) Handles tsUpdateItem.Click
        fEditItem()
        dgvProductItem.Focus()
    End Sub

    Private Sub tsAdd_Click(sender As Object, e As EventArgs) Handles tsAdd.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If

        If Val(lblPAYMENT_AMOUNT.Text) <> 0 Then
            fMessageboxInfo($"Please remove {xlblTender.Text} amount")
            Exit Sub
        End If


        tsITEM_MENU_TOOLS.Enabled = False
        With frmAddItemSidePanel
            .StartPosition = FormStartPosition.Manual
            .sFormName = "frmSalesReceipt"
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
        fComputed()
        frmAddItemSidePanel.Dispose()
        frmAddItemSidePanel = Nothing
        dgvProductItem.Focus()
        tsITEM_MENU_TOOLS.Enabled = True
    End Sub

    Private Sub txtSearchEntry_TextChanged(sender As Object, e As EventArgs) Handles txtSearchEntry.TextChanged

    End Sub

    Private Sub txtSearchEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchEntry.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub dgvTENDER_LIST_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTENDER_LIST.CellContentClick

    End Sub

    Private Sub dgvTENDER_LIST_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvTENDER_LIST.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub xlblSalesRep_Click(sender As Object, e As EventArgs) Handles xlblSalesRep.Click

    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub
End Class