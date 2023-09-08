Imports System.Data.Odbc
Public Class FrmInvoice
    Public gsMemberDiscount As Double = 0
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Public gDGV As New DataGridView

    Dim bRefreshItem As Boolean = False
    Dim bEntryAddItem As Boolean = False
    Dim f As Form = New FrmFindDocument
    Dim bLoadOn As Boolean = False

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count

        If Val(lblCount.Text) = 0 Then
            cmbLOCATION_ID.Enabled = True
            cmbCUSTOMER_ID.Enabled = True
        Else
            cmbLOCATION_ID.Enabled = False
            cmbCUSTOMER_ID.Enabled = False
        End If
    End Sub


    Private Sub RefreshCombo()

        ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbCLASS_ID, "select ID,NAME from class", "ID", "NAME")
        ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select ID,DESCRIPTION from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbSALES_REP_ID, "select ID,`NAME` from contact where type ='2' ORDER BY `NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbLOCATION_ID, "select ID,NAME from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbSHIP_VIA_ID, "select ID,DESCRIPTION from ship_via", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")
    End Sub

    Private Sub RefreshItem()
        bRefreshItem = True
        dgvProductItem.Rows.Clear()

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
  ii.`REF_LINE_ID`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`GROUP_LINE_ID`,
  ii.`PRICE_LEVEL_ID`,
  i.TYPE as `ITEM_TYPE`,
  ii.PRINT_IN_FORMS,
  II.BATCH_ID,
  B.BATCH_NO

FROM

  invoice_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
LEFT OUTER JOIN ITEM_BATCHES AS B
ON B.ID = II.BATCH_ID

    WHERE  ii.`INVOICE_ID` = '" & ID & "' Order by ii.LINE_NO"
        If dgvProductItem.Columns.Count = 0 Then Exit Sub

        Try
            Dim x As Integer = 0
            '  cn.Open()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1

                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(NumIsNull(rd(i)))
                        ElseIf CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(NumIsNull(rd(i)))
                        ElseIf CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(NumIsNull(rd(i)))
                        Else
                            dgvProductItem.Rows(x).Cells(i).Value = TextIsNull(rd(i))
                        End If
                    End With

                Next
                If CBool(NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If
                x += 1
            End While
            rd.Close()

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        Finally
            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try

        bRefreshItem = False



    End Sub

    Private Sub ClearInfo()
        RefreshCombo()
        ClearAndRefresh(Me)

        dtpDISCOUNT_DATE.Checked = False
        dtpDUE_DATE.Checked = False
        dgvProductItem.Rows.Clear()
        Computed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = fPaymentTermsDefault()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID
    End Sub
    Private Function CheckingfGotCreditLimit() As Boolean
        Dim bHold As Boolean = False
        Try


            Dim credit_limit As Double = 0
            Dim total_invoice As Double = 0
            fGotCreditLimitLineStatus(cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, credit_limit, total_invoice)
            Dim total_new_invoice As Double = NumberFormatFixed(lblAMOUNT.Text)
            Dim total As Double = total_invoice + total_new_invoice
            Dim bLimit As Boolean = False

            If credit_limit <> 0 Then
                If credit_limit <= total Then
                    bLimit = True
                End If

                If bLimit = True Then


                    Select Case fCreditLimitPolicy()
                        Case 0
                            MessageBoxWarning("The credit limit for this customer is " & NumberFormatStandard(credit_limit) & ". The current balance is " & NumberFormatStandard(total) & ".")
                        Case 1
                            bHold = True
                            MessageBoxExclamation("You cannot create invoice to this customer. The allowed credit balance for this customer is up  to " & NumberFormatStandard(credit_limit) & " only. The current balance is " & Format(total, "Standard") & ".")
                    End Select

                End If
            End If




        Catch ex As Exception

        End Try
        Return bHold


    End Function
    Private Function CheckingfGotAgingLimit() As Boolean
        Dim d As Date = Date.Now.Date
        Dim b As Boolean = False
        Dim i As Integer = fArAgingLimit()

        Select Case i

            Case 0
                'NONE
                b = False
            Case Else
                '  Dim cn As New MySqlConnection(mysqlConstr)
                Dim DUE_DATE As Date = Date.Now.Date
                Dim bGotBalance As Boolean = False
                Try
                    ' cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("Select due_date from invoice where BALANCE_DUE > '0' and customer_id = '" & cmbCUSTOMER_ID.SelectedValue & "'  Order by due_date ")
                    If rd.Read Then
                        If TextIsNull(rd("due_date")) = "" Then
                            bGotBalance = False
                        Else
                            DUE_DATE = FixDate(TextIsNull(rd("due_date")))
                            bGotBalance = True
                        End If
                    End If
                    rd.Close()

                    If bGotBalance = True Then

                        Dim daycount As Integer = DateDiff(DateInterval.Day, DUE_DATE, d)
                        Select Case i
                            Case 1
                                'Current Balance
                                If daycount <= 0 Then
                                    b = False
                                Else
                                    b = True
                                    MessageBoxWarning("You cannot create invoice to this customer. This customer has overdue invoice. The allowed A/R aging is current balanace only.")
                                End If

                            Case 2
                                '1-30

                                If daycount <= 30 Then
                                    b = False
                                Else
                                    b = True
                                    MessageBoxWarning("You cannot create invoice to this customer. This customer has open invoices with  over-30-day past due. The allowed A/R aging is up to 30-days only.")
                                End If
                            Case 3
                                '31-60
                                If daycount <= 60 Then
                                    b = False
                                Else
                                    b = True
                                    MessageBoxWarning("You cannot create invoice to this customer. This customer has open invoices with  over-60-day past due. The allowed A/R aging is up to 60-days only.")
                                End If
                            Case 4
                                '61-90 
                                If daycount <= 90 Then
                                    b = False
                                Else
                                    b = True
                                    MessageBoxWarning("You cannot create invoice to this customer. This customer has open invoices with  over-90-day past due. The allowed A/R aging is up to 90-days only.")
                                End If
                        End Select

                    End If
                Catch ex As Exception
                    If MessageBoxErrorYesNo(ex.Message) = True Then
                        b = CheckingfGotAgingLimit()
                    Else
                        End
                    End If


                End Try

        End Select
        Return b
    End Function

    Private Sub DgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub FrmInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load
        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm
        fcolumnGrid_U_Invoice(dgvProductItem)

        ClearInfo()


        If IsNew = False Then
            RefreshInfo()
            RefreshItem()

        End If



    End Sub



    Private Sub RefreshInfo()
        Try

            Dim sQuery As String = "select * from invoice where ID = '" & ID & "' Limit 1;"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        End Try
    End Sub
    Private Function SalesOrderIitemUpdate(ByVal REF_LINE_ID As Integer, ByVal prINVOICED_QTY As Double, ByVal isUPDATE As Boolean, ByRef THIS_SO_ID As Integer) As String

        Dim SO_SQL As String = ""
        If REF_LINE_ID <> 0 Then
            Dim Get_SO_ID As Integer = GetNumberFieldValue("sales_order_items", "ID", REF_LINE_ID, "SALES_ORDER_ID")
            If isUPDATE = True Then
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & REF_LINE_ID & "' Limit 1;"
            Else
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = NULL,`CLOSED` = '0' where ID = '" & REF_LINE_ID & "' Limit 1;"
            End If
            THIS_SO_ID = Get_SO_ID
        End If

        Return SO_SQL
    End Function

    Private Sub Check_Status_SO(ByVal THIS_SO_ID As Integer)

        Dim rd As OdbcDataReader = SqlReader($"select  * from sales_order_items Where SALES_ORDER_ID = '{THIS_SO_ID}' and `CLOSED` = '1' limit 1;")
        Dim E As Integer
        If rd.Read Then
            E = 3
        Else
            E = 2
        End If
        rd.Close()
        SqlExecuted($"Update sales_order set `STATUS` = '{E}'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}' limit 1")

    End Sub



    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click


        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Name")
            Exit Sub
        End If


        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If


        If cmbPAYMENT_TERMS_ID.Text = "" Then
            MessageBoxInfo("Please select payment terms")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, IsNew) = False Then
            'Acccess Denied
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then


            If CheckingfGotCreditLimit() = True Then
                Exit Sub
            End If

            If CheckingfGotAgingLimit() = True Then
                Exit Sub
            End If

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("INVOICE", cmbLOCATION_ID.SelectedValue)
            End If


            dtpDATE.Checked = True
            ID = ObjectTypeMapId("invoice")


            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO invoice ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE,IS_FC) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',13,'{GetDateTimeNowSql()}',0) ")

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            tChangeAccept = True

            Dim bTotal_Balance As Double = NumberFormatFixed(lblBALANCE_DUE.Text)
            Dim nStatus As Integer
            If 0 >= bTotal_Balance Then
                nStatus = 11
            Else
                nStatus = 2
            End If
            SqlExecuted("UPDATE invoice SET " & SqlUpdate(Me) & ",STATUS='" & nStatus & "',STATUS_DATE ='" & GetDateTimeNowSql() & "' WHERE ID = '" & ID & "'")
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 0, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            If NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 23, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 1, NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================

        SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

        If IsTransactionSuccess(ID, "INVOICE") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If


        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                SetNew()
            End If

        Catch ex As Exception

        Finally
            If ID > 0 Then
                IsNew = False
                RefreshInfo()
                RefreshItem() 'Must Refresh Item
            End If

        End Try


    End Sub
    Private Sub SetNew()
        ClearInfo()
        dgvProductItem.Rows.Clear()
        Computed()

        ID = 0
        IsNew = True
        gsMemberDiscount = 0

    End Sub

    Private Sub EditItem()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                MessageBoxExclamation("Data Not Found!")
                Exit Sub
            End If
            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index
            If fCheckModify(dgvProductItem, I) = True Then
                Exit Sub
            End If
            Dim d As DataGridViewRow = dgvProductItem.Rows(I)


            If d.Cells("ITEM_TYPE").Value = 5 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 And NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> NumIsNull(d.Cells("ITEM_ID").Value) Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            Dim gsGROUP_ID As Integer = 0
            With FrmAddItem

                If NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                gsGROUP_ID = NumIsNull(dgvProductItem.Rows.Item(I).Cells("GROUP_LINE_ID").Value)
                .gsUseItemBatch = True
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = TextIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value)
                .gsDiscount_Rate = NumIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value)
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
                FrmAddItem.ShowDialog()

                If .gsSave = True Then

                    fRow_Data_Item_Invoice(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, dgvProductItem.Rows.Item(I).Cells("REF_LINE_ID").Value, .gsPRICE_LEVEL_ID, gsGROUP_ID, False, .gsBATCH_ID)

                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Function Get_Discount_Item()
        Dim Amt As Double = 0
        If dgvProductItem.Rows.Count <> 0 Then
        End If
        Return Amt
    End Function
    Private Function CheckifDiscountNext(ByVal ndex As Integer) As Boolean
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
    Public Sub Computed()
        Dim gsSalesSubTotal As Double
        fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
        Dim dPayment_applied As Double = fGetSumPaymentApplied(ID, cmbCUSTOMER_ID.SelectedValue) + fGetSumCreditApplied(ID, cmbCUSTOMER_ID.SelectedValue) + fInvoiceSumTaxApplied_Amount(ID, cmbCUSTOMER_ID.SelectedValue)


        lbxPaymentApplied.Text = NumberFormatStandard(dPayment_applied)
        Dim dBalance As Double = NumIsNull(NumberFormatFixed(lblAMOUNT.Text)) - dPayment_applied

        lblBALANCE_DUE.Text = NumberFormatStandard(dBalance)

        lbxBalance.Text = IIf(dtpDUE_DATE.Value > Date.Now.Date, "0.00", NumberFormatStandard(dBalance))

    End Sub

    Private Sub CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        Computed()
        Try

            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = TextIsNull(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = TextIsNull(rd("TAX_ACCOUNT_ID"))
            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""
                lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub
    Private Sub TsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub

        Else
            If IsNew = False And ID > 0 Then
                If CheckingHasChange(Me, tQuery, dgvProductItem, tdgv) = True Then
                    If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        TsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            MessageBoxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If
        End If

        f.AccessibleName = "invoice"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                IsNew = False


                ClearInfo()
                ID = f.AccessibleDescription

                RefreshInfo()
                RefreshItem()

            End If


        End If

        'Frm.Dispose()
        'Frm = Nothing

    End Sub
    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then
                ClearInfo()
                RefreshInfo()
                RefreshItem()
            End If

        End If
    End Sub

    Private Sub DgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            fTax_Value(dgvProductItem)
            Computed()
        End If
    End Sub
    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckingHasChange(Me, tQuery, dgvProductItem, tdgv) = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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

        If fACCESS_PRINT_PREVIEW(Me) = False Then
            Exit Sub
        End If


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
        fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
        fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        fReportExporPDF(gscryRpt, prPrint_Title)
        gsToolPanelView = False
        fPreviewReport(prPrint_Title)


    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click



        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckingHasChange(Me, tQuery, dgvProductItem, tdgv) = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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
        If fACCESS_PRINT_PREVIEW(Me) = False Then
            Exit Sub
        End If

        FrmPrintPage.frmName = Me.Name
        FrmPrintPage.ShowDialog()

        Dim v As Integer = FrmPrintPage.prValue
        If v = 1 Or v = 2 Then

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
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
            fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False
                fPreviewReport("Invoice Report")
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        FrmPrintPage.Dispose()
        FrmPrintPage = Nothing



    End Sub

    Private Sub tsPrint_Click(sender As Object, e As EventArgs) Handles tsPrint.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckingHasChange(Me, tQuery, dgvProductItem, tdgv) = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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

            If fACCESS_PRINT_PREVIEW(Me) = False Then

                Exit Sub
            End If

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
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
            fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then

                '   Dim cn As New MySqlConnection(mysqlConstr)
                'Payment
                Try
                    '  cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("select * from payment_invoices where invoice_id = '" & ID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            MessageBoxWarning("Invalid delete invoice. payment are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("delete from payment_invoices where invoice_id = '" & ID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception

                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try
                'credit memo
                Try

                    Dim rd As OdbcDataReader = SqlReader("select * from `credit_memo_invoices` where invoice_id = '" & ID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            MessageBoxWarning("Invalid delete invoice. credit memo are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("delete from `credit_memo_invoices` where invoice_id = '" & ID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception
                    'If cn.State = ConnectionState.Open Then
                    '    cn.Close()
                    'End If
                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try
                'tax credit
                Try
                    ' cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("select * from `tax_credit_invoices` where invoice_id = '" & ID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            MessageBoxWarning("Invalid delete invoice. tax credit are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("delete from `tax_credit_invoices` where invoice_id = '" & ID & "'")
                        End If


                    End If
                    rd.Close()
                Catch ex As Exception

                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try


                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next
                '===
                SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)
                '====
                '===========================================
                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0

                    fAccount_journal_Delete(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    If NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        fAccount_journal_Delete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    End If

                End If
                '================================

                SqlExecuted("delete from invoice where id ='" & ID & "' limit 1;")

                PrompNotify(Me.Text, DeleteMsg, True)

                fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True
                CursorLoadingOn(False)
            End If


        End If

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If

    End Sub

    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

    End Sub

    Private Sub frmInvoice_Activated(sender As Object, e As EventArgs) Handles Me.Activated

    End Sub
    Public Sub fDocumentRequest()

    End Sub

    Private Sub frmInvoice_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged


    End Sub

    Private Sub cmbPAYMENT_TERMS_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_TERMS_ID.SelectedIndexChanged

        fSetDueDate_PaymentTerms(cmbPAYMENT_TERMS_ID, dtpDUE_DATE, dtpDATE)


    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub frmInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewItemDisplay(dgvProductItem)
        '    ViewItemDisplay(dgvProductItem)
        ViewNotSort(dgvProductItem)
    End Sub

    Private Sub cmbMANAGER_ID_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    fDepotAvailDiscount()
    End Sub
    'Private Sub fDepotAvailDiscount()
    '    Dim dBasicDiscount As Double = 0
    '    Dim dRabites As Double = 0
    '    Try
    '        If cmbMANAGER_ID.Text <> "" Then


    '            dBasicDiscount = GetStringFieldValue("contact", "ID", cmbMANAGER_ID.SelectedValue, "DISCOUNT")


    '            If cmbMANAGER_ID.SelectedValue = cmbCUSTOMER_ID.SelectedValue Then
    '                dtpDATE.Checked = True
    '                Dim dt1 As Date = FirstDayOfMonth(dtpDATE.Value)
    '                dt1 = dt1.AddMonths(-1)
    '                Dim dt2 As Date = LastDayOfMonth(dt1)
    '                Dim R_number As Double = 0


    '                If fManagerHitSalesTargetViaDealer(Format(dt1, "yyyy-MM-dd"), Format(dt2, "yyyy-MM-dd"), cmbCUSTOMER_ID.SelectedValue, R_number) = True Then
    '                    dRabites = R_number * (Val(fSystemSettingValue("ManagerRebites")) / 100)
    '                    gsMemberDiscount = dBasicDiscount
    '                Else
    '                    gsMemberDiscount = dBasicDiscount
    '                End If
    '            Else
    '                gsMemberDiscount = dBasicDiscount
    '            End If
    '        Else
    '            gsMemberDiscount = 0
    '        End If
    '    Catch ex As Exception
    '        'fMessageboxError(ex)
    '    End Try






    'End Sub

    'Private Sub cmbMANAGER_ID_SelectedValueChanged(sender As Object, e As EventArgs)
    '    fDepotAvailDiscount()
    'End Sub

    'Private Sub cmbMANAGER_ID_TextChanged(sender As Object, e As EventArgs)
    '    fDepotAvailDiscount()
    'End Sub

    'Private Sub cmbPENALTY_TYPE_ID_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    Try

    '        Dim gsTYPE As String = ""
    '        Select Case cmbPENALTY_TYPE_ID.SelectedValue
    '            Case 0
    '                lblPENALTY_RATE.Text = "0"
    '            Case 1
    '                lblPENALTY_RATE.Text = GetNumberFieldValue("contact", "ID", cmbCUSTOMER_ID.SelectedValue, "FIXED_PENALTY")
    '            Case 2
    '                lblPENALTY_RATE.Text = GetNumberFieldValue("contact", "ID", cmbCUSTOMER_ID.SelectedValue, "RUNNING_PENALTY")
    '            Case Else
    '                lblPENALTY_RATE.Text = "0"
    '        End Select
    '        POSComputed()

    '    Catch ex As Exception
    '        lblPENALTY_RATE.Text = "0"
    '    End Try

    'End Sub

    Private Sub dtpDUE_DATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpDUE_DATE.ValueChanged
        Computed()
    End Sub

    Private Sub tsPrint_DisplayStyleChanged(sender As Object, e As EventArgs) Handles tsPrint.DisplayStyleChanged

    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub

    Private Sub cmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
        '   fLESS_PENALTY_DISCOUNT_ACTIVE()

    End Sub
    Private Sub CustomerTax()
        Application.DoEvents()
        Dim s As Integer
        Try
            s = cmbCUSTOMER_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckingHasChange(Me, tQuery, dgvProductItem, tdgv) = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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
        fTransactionJournal(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 23, 4, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        fHistoryList(ID, Me)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        fTransactionLog(Me, ID)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbCUSTOMER_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCUSTOMER_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbCUSTOMER_ID.Text)
            If cmbCUSTOMER_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If fACCESS_NEW_EDIT(FrmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/customer.png")

                    FrmContactDetails.ContactTypeId = 1
                    FrmContactDetails.txtNAME.Text = StrText ' must auto insert
                    FrmContactDetails.txtCOMPANY_NAME.Text = StrText
                    FrmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    FrmContactDetails.IsNew = True
                    FrmContactDetails.ID = 0
                    FrmContactDetails.gsDgv = Nothing
                    FrmContactDetails.this_BS = Nothing
                    FrmContactDetails.ShowDialog()
                    If FrmContactDetails.gsOK = True Then
                        ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbCUSTOMER_ID.SelectedValue = FrmContactDetails.ID
                        cmbCUSTOMER_ID_LostFocus(sender, e)
                    End If
                    FrmContactDetails.Dispose()
                    FrmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Or cmbCUSTOMER_ID.SelectedValue Is Nothing Or cmbCUSTOMER_ID.Text = "" Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If

        If IsNew = True Then
            If CheckingfGotCreditLimit() = True Then
                cmbCUSTOMER_ID.Text = ""
                Exit Sub
            End If

            If CheckingfGotAgingLimit() = True Then
                cmbCUSTOMER_ID.Text = ""
                Exit Sub
            End If
        End If

        With FrmAddItem
            .gsUseItemBatch = True
            bRefreshItem = False
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE

            .sFormName = Me.Name
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            If gsMemberDiscount <> 0 Then
                .gsMEMBER = True
                .gsMEMEBER_DISCOUNT = gsMemberDiscount
            End If
            .ShowDialog()

        End With
        Computed()
        FrmAddItem.Dispose()
        FrmAddItem = Nothing
    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        EditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        fDeleteItem()
    End Sub
    Private Sub fDeleteItem()

        Try
            If dgvProductItem.Rows.Count <> 0 Then
                dgvProductItem.Select()
                fRemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
                Computed()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmInvoice_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged



        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)


        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If

    End Sub
    Private Sub txtCODE_TextChanged(sender As Object, e As EventArgs) Handles txtCODE.TextChanged

    End Sub
    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub LblOUTPUT_TAX_AMOUNT_Click(sender As Object, e As EventArgs) Handles lblOUTPUT_TAX_AMOUNT.Click

    End Sub

    Private Sub ToolStripLabel11_Click(sender As Object, e As EventArgs) Handles ToolStripLabel11.Click

    End Sub

    Private Sub ToCreditMemoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCreditMemoToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckingHasChange(Me, tQuery, dgvProductItem, tdgv) = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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

        With FrmApplyCredits
            .gsID = ID
            .gsCustomer_ID = cmbCUSTOMER_ID.SelectedValue
            .gsLocation_ID = cmbLOCATION_ID.SelectedValue
            .lblName.Text = cmbCUSTOMER_ID.Text
            .lblCODE.Text = txtCODE.Text
            .lblDATE.Text = dtpDATE.Value
            .lblORG_AMOUNT.Text = lblAMOUNT.Text
            .gsBalance = NumberFormatFixed(lblBALANCE_DUE.Text)

            .ShowDialog()
            If .gsOk = True Then
                'ADD UPDATE ' to 
                Computed()

                IsNew = False
                TsSaveNew_Click(1, e)
            End If
            .Dispose()

        End With
        FrmApplyCredits = Nothing
    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        CustomerTax()

        If bEntryAddItem = True Then
            Exit Sub
        End If

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub
        Dim sql As String = ""
        '  fDepotConnected(cmbCUSTOMER_ID, cmbDEALER_ID, cmbSALES_REP_ID)
        Try
            sql = "SELECT count(p.`CODE`) as t FROM  sales_order AS p   LEFT OUTER JOIN payment_terms AS t  ON t.ID = p.payment_terms_id   INNER JOIN sales_order_items AS pt    ON pt.`SALES_ORDER_ID` = p.`ID` WHERE pt.`CLOSED` = '0'   AND p.Customer_ID = '" & cmbCUSTOMER_ID.SelectedValue & "'   GROUP BY p.`CODE`"
        Catch ex As Exception
            Exit Sub
        End Try
        Try

            Dim rd As OdbcDataReader = SqlReader(sql)
            If rd.Read Then

                If NumIsNull(rd("t")) <> 0 Then
                    With FrmAvailableItem
                        bEntryAddItem = True
                        .gsdgv = dgvProductItem
                        .gsCONTACT_ID = cmbCUSTOMER_ID.SelectedValue
                        .gsType = 1
                        bRefreshItem = True
                        .ShowDialog()
                        If .bClickOK = True Then
                            cmbLOCATION_ID.SelectedValue = .gsLocation_Select_ID
                        End If
                        ' cmbCUSTOMER_ID.SelectedValue = .gsCONTACT_ID
                        .Dispose()
                        Computed() ' i forgot
                        bRefreshItem = False
                    End With
                    frmAvailableItem = Nothing
                End If
            End If
            rd.Close()
        Catch ex As Exception

            MessageBoxWarning(ex.Message)
        Finally
            bEntryAddItem = False
        End Try
    End Sub
End Class