Imports System.Data.Odbc
Public Class FrmPOSRoomDetails

    Public gsWalkInCustomer As Boolean = False
    Public gsCHECK_IN As Integer
    Public gsCHECK_OUT As Integer = 11
    Public gsRoomID As Integer

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


    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        fCountItem()

        If Val(lblCount.Text) = 0 Then
            cmbLOCATION_ID.Enabled = True
            cmbCUSTOMER_ID.Enabled = True
        Else
            cmbLOCATION_ID.Enabled = False
            cmbCUSTOMER_ID.Enabled = False
        End If

    End Sub
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If

        Return HasChange
    End Function
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub


    Private Sub fRefreshCombo()

        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select ID,NAME from class", "ID", "NAME")
        GS_ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select ID,DESCRIPTION from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select ID,`NAME` from contact where type ='2' ORDER BY `NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select ID,NAME from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbSHIP_VIA_ID, "select ID,DESCRIPTION from ship_via", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        GS_ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")


    End Sub

    Private Sub fRefreshItem()
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
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else
                            dgvProductItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                        End If
                    End With

                Next
                If CBool(GF_NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If
                x = x + 1
            End While
            rd.Close()

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        Finally
            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try

        bRefreshItem = False



    End Sub

    Private Sub fclear_Info()
        fRefreshCombo()
        ClearAndRefresh(Me)

        dtpDISCOUNT_DATE.Checked = False
        dtpDUE_DATE.Checked = False
        dgvProductItem.Rows.Clear()
        fComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = GetPaymentTermsDefault()
        dtpDATE.Value = TransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID
    End Sub
    Private Function fCheckingfGotCreditLimit() As Boolean
        Dim bHold As Boolean = False
        Try


            Dim credit_limit As Double = 0
            Dim total_invoice As Double = 0
            GS_GotCreditLimitLineStatus(cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, credit_limit, total_invoice)
            Dim total_new_invoice As Double = NumberFormatFixed(lblAMOUNT.Text)
            Dim total As Double = total_invoice + total_new_invoice
            Dim bLimit As Boolean = False

            If credit_limit <> 0 Then
                If credit_limit <= total Then
                    bLimit = True
                End If

                If bLimit = True Then


                    Select Case GetCreditLimitPolicy()
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
    Private Function fCheckingfGotAgingLimit() As Boolean
        Dim d As Date = Date.Now.Date
        Dim b As Boolean = False
        Dim i As Integer = GetArAgingLimit()

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
                        If GF_TextIsNull(rd("due_date")) = "" Then
                            bGotBalance = False
                        Else
                            DUE_DATE = FixDate(GF_TextIsNull(rd("due_date")))
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
                        b = fCheckingfGotAgingLimit()
                    Else
                        End
                    End If


                End Try

        End Select
        Return b
    End Function

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub fRefreshPaymentList()


        GS_LoadDataGridView(dgvPaymentList, $"select p.CODE as `Payment No.`, format( pn.AMOUNT_APPLIED,2) as `Payment` from payment_invoices as pn  inner join payment as p on p.id = pn.payment_id WHERE pn.invoice_id = '{ID}' and p.POS_LOG_ID = '{gsPOS_LOG_ID}'  ")

    End Sub
    Private Sub frmInvoice_Load(sender As Object, e As EventArgs) Handles Me.Load




        fLabel_Digital_M(lblAMOUNT)
        fLabel_Digital_M(lblBALANCE_DUE)
        fLabel_Digital_M(lbxPaymentApplied)

        gsGotChangeData = False
        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts
        fcolumnGrid_U_Invoice(dgvProductItem)
        dgvProductItem.Columns("CODE").Visible = False
        dgvProductItem.Columns("UM").Visible = False
        dgvProductItem.Columns("DISCOUNT_TYPE").Visible = False
        dgvProductItem.Columns("DISCOUNT_RATE").Visible = False
        dgvProductItem.Columns("TAX").Visible = False

        fclear_Info()
        cmbCUSTOMER_ID.SelectedValue = gsPOSDefaultCustomer_ID
        If IsNew = False Then
            fRefreshInfo()
            fRefreshItem()

            If gsWalkInCustomer = False Then

                'If dtpCUSTOM_FIELD2.Value = DateTime.Now Then
                '    dtpCUSTOM_FIELD2.Checked = False
                'Else
                '    dtpCUSTOM_FIELD2.Checked = True
                'End If

                tsSaveNew.Text = "Update"
                btnSave.Text = "Update"
                btnSave.Visible = True
                If cmbSHIP_VIA_ID.SelectedValue = gsCHECK_OUT Then
                    btnCheckOut.Visible = False
                End If

            Else

                btnCheckOut.Visible = False
                btnSave.Visible = False
                btnDelete.Visible = False

                xxxCO.Visible = False
                xxxlblCI.Visible = False
                tsTransfer.Visible = False


                dtpDATE.Visible = False
                dtpCUSTOM_FIELD1.Visible = False

                dtpDISCOUNT_DATE.Visible = False
                dtpCUSTOM_FIELD2.Visible = False

            End If



        Else

            '  tsPayment.Enabled = False
            txtCODE.Text = GF_NextCodePreview("INVOICE", cmbLOCATION_ID.SelectedValue) 'Display only


            If gsWalkInCustomer = False Then

                tsCheckOut.Enabled = False
                btnCheckOut.Enabled = False
                btnDelete.Enabled = False

                tsSaveNew.Text = "Check-IN"
                btnSave.Text = "Check-IN"
                btnSave.Visible = False

                dtpCUSTOM_FIELD1.Value = DateTime.Now
                dtpDISCOUNT_DATE.Checked = False
                dtpCUSTOM_FIELD2.Checked = False

                dtpDISCOUNT_DATE.Enabled = False
                dtpCUSTOM_FIELD2.Enabled = False

                cmbSHIP_VIA_ID.SelectedValue = gsCHECK_IN
                Dim rate As Double = GF_GetNumberFieldValue("item", "id", gsRoomID, "rate")
                GS_RowDataItemInvoice(dgvProductItem, True, gsRoomID, 1, rate, "", 0, rate, False, 0, "A", 1, 0, rate, "", 0, 0, False, 0)


            Else
                cmbSHIP_VIA_ID.SelectedValue = 1

                btnSave.Visible = False
                btnDelete.Visible = False
                btnCheckOut.Visible = False
                tsTransfer.Visible = False


                dtpCUSTOM_FIELD1.Value = DateTime.Now
                dtpDISCOUNT_DATE.Checked = False
                dtpCUSTOM_FIELD2.Checked = False

                dtpDATE.Visible = False
                dtpCUSTOM_FIELD1.Visible = False

                dtpDISCOUNT_DATE.Visible = False
                dtpCUSTOM_FIELD2.Visible = False

                xxxCO.Visible = False
                xxxlblCI.Visible = False

            End If


        End If
        fRefreshPaymentList()
        fSetDueDate_PaymentTerms(cmbPAYMENT_TERMS_ID, dtpDUE_DATE, dtpDATE)
        fComputed()

    End Sub

    Private Sub fRoomFinder()
        For N As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(N)
                If .Cells("ITEM_TYPE").Value = 10 Then
                    .Cells("QTY").Style.ForeColor = Color.White
                    .Cells("UNIT_PRICE").Style.ForeColor = Color.White
                    .Cells("AMOUNT").Style.ForeColor = Color.White

                    .Cells("QTY").Style.SelectionForeColor = Color.DarkCyan
                    .Cells("UNIT_PRICE").Style.SelectionForeColor = Color.DarkCyan
                    .Cells("AMOUNT").Style.SelectionForeColor = Color.DarkCyan
                    Exit Sub
                End If

            End With
        Next
    End Sub


    Private Sub fRefreshInfo()
        Try

            Dim sQuery As String = "select * from invoice where ID = '" & ID & "' Limit 1;"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo()
            Else
                End
            End If
        End Try
    End Sub
    Private Function fSO_ITEM_UPDATE(ByVal REF_LINE_ID As Integer, ByVal prINVOICED_QTY As Double, ByVal isUPDATE As Boolean, ByRef THIS_SO_ID As Integer) As String

        Dim SO_SQL As String = ""
        If REF_LINE_ID <> 0 Then
            Dim Get_SO_ID As Integer = GF_GetNumberFieldValue("sales_order_items", "ID", REF_LINE_ID, "SALES_ORDER_ID")
            If isUPDATE = True Then
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & REF_LINE_ID & "' Limit 1;"
            Else
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = NULL,`CLOSED` = '0' where ID = '" & REF_LINE_ID & "' Limit 1;"
            End If
            THIS_SO_ID = Get_SO_ID
        End If

        Return SO_SQL
    End Function

    Private Sub fCheck_Status_SO(ByVal THIS_SO_ID As Integer)

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



    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click


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


        If IsNew = True Then

            If gsWalkInCustomer = False Then
                'check if have hours
                ' if meron isa
                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)

                        If .Cells("ITEM_ID").Value = gsHours_Item_ID Then
                            If .Cells("CONTROL_STATUS").Value = "A" Then
                                GoTo APPROVED
                            ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                                GoTo APPROVED
                            ElseIf .Cells("CONTROL_STATUS").Value = "S" Then
                                GoTo APPROVED
                            End If
                        End If

                    End With
                Next
                MessageBoxExclamation("No item hours. added.")
                Exit Sub
APPROVED:
            End If

            txtCODE.Text = GF_GetNextCode("INVOICE", cmbLOCATION_ID.SelectedValue)
            dtpCUSTOM_FIELD1.Value = DateTime.Now
            dtpCUSTOM_FIELD1.Checked = True
            dtpDATE.Checked = True


            SqlCreate(Me, SQL_FIELD, SQL_VALUE)
            ID = ObjectTypeMapId("invoice")
            SqlExecuted($"INSERT INTO invoice ({SQL_FIELD},ID,RECORDED_ON,STATUS,STATUS_DATE,IS_FC,MANAGER_ID) VALUES ({SQL_VALUE},{ID},'{GetDateTimeNowSql()}','{2}','{GetDateTimeNowSql()}','0','{gsPOS_LOG_ID}') ")

            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else
            dtpCUSTOM_FIELD1.Checked = True
            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me)
            Dim bTotal_Balance As Double = NumberFormatFixed(lblBALANCE_DUE.Text)

            Dim nStatus As Integer = 0
            If 0 >= bTotal_Balance Then
                nStatus = 11
            Else
                nStatus = 2
            End If

            squery = squery & ",STATUS='" & nStatus & "',STATUS_DATE ='" & GetDateTimeNowSql() & "' WHERE ID = '" & ID & "'"
            SqlExecuted("UPDATE invoice SET " & squery)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            GS_AccountJournalExecute(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 0, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 23, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                GS_AccountJournalExecute(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 1, GF_NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================ 
        SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

        If GF_IsTransactionSuccess(ID, "INVOICE") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        gsGotChangeData = True
        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = tsSaveNew.Name Then



                'SetNew()
                Me.Close()
                Exit Sub
            End If

        Catch ex As Exception

        Finally
            If ID <> 0 Then
                IsNew = False
                fRefreshInfo()
                fRefreshItem() 'Must Refresh Item

                If gsWalkInCustomer = False Then
                    tsSaveNew.Text = "Update"
                    btnSave.Text = "Update"
                    btnSave.Visible = True
                    btnDelete.Enabled = True
                    btnCheckOut.Enabled = True
                    tsCheckOut.Enabled = True

                    dtpDISCOUNT_DATE.Checked = False
                    dtpCUSTOM_FIELD2.Checked = False

                    dtpDISCOUNT_DATE.Enabled = True
                    dtpCUSTOM_FIELD2.Enabled = True
                Else
                    btnCheckOut.Visible = False
                    btnSave.Visible = False
                    btnDelete.Visible = False
                    xxxCO.Visible = False
                    xxxlblCI.Visible = False


                End If


            End If

        End Try


    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()

        ID = 0
        IsNew = True
        gsMemberDiscount = 0

    End Sub

    Private Sub fEditItem()
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

            ElseIf d.Cells("ITEM_TYPE").Value = 6 And Val(d.Cells("ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub

            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf GF_NumIsNull(d.Cells("ITEM_TYPE").Value) = 10 Then
                MessageBoxInfo("Invalid edit room")
                Exit Sub
            ElseIf GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 And GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> GF_NumIsNull(d.Cells("ITEM_ID").Value) Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            Dim gsGROUP_ID As Integer = 0
            With frmAddItem

                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                gsGROUP_ID = GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("GROUP_LINE_ID").Value)
                .gsUseItemBatch = True
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = GF_TextIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value)
                .gsDiscount_Rate = GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value)
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
                frmAddItem.ShowDialog()

                If .gsSave = True Then
                    GS_RowDataItemInvoice(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, dgvProductItem.Rows.Item(I).Cells("REF_LINE_ID").Value, .gsPRICE_LEVEL_ID, gsGROUP_ID, False, .gsBATCH_ID)
                End If


            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub


    Private Function fGet_Discount_Item()
        Dim Amt As Double = 0
        If dgvProductItem.Rows.Count <> 0 Then


        End If
        Return Amt
    End Function
    Private Function fCheckifDiscountNext(ByVal ndex As Integer) As Boolean
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
    Public Sub fComputed()
        fRoomFinder()
        Dim gsSalesSubTotal As Double
        GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
        Dim dPayment_applied As Double = fGetSumPaymentApplied(ID, cmbCUSTOMER_ID.SelectedValue) + fGetSumCreditApplied(ID, cmbCUSTOMER_ID.SelectedValue) + fInvoiceSumTaxApplied_Amount(ID, cmbCUSTOMER_ID.SelectedValue)


        lbxPaymentApplied.Text = NumberFormatStandard(dPayment_applied)
        Dim dBalance As Double = GF_NumIsNull(NumberFormatFixed(lblAMOUNT.Text)) - dPayment_applied

        lblBALANCE_DUE.Text = NumberFormatStandard(dBalance)

        lbxBalance.Text = IIf(dtpDUE_DATE.Value > Date.Now.Date, "0.00", NumberFormatStandard(dBalance))

    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        '    Dim cn As New MySqlConnection(mysqlConstr)

        Try
            '   cn.Open()
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
            MessageBoxWarning(ex.Message)
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
            Exit Sub

        Else
            If IsNew = False And ID <> 0 Then
                If fCheckHasChange() = True Then
                    If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        tsSaveNew_Click(sender, e)
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


                fclear_Info()
                ID = f.AccessibleDescription

                fRefreshInfo()
                fRefreshItem()

            End If


        End If

        'Frm.Dispose()
        'Frm = Nothing




    End Sub





    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then
                fclear_Info()
                fRefreshInfo()
                fRefreshItem()
            End If

        End If
    End Sub

    Private Sub dgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_TaxValue(dgvProductItem)
            fComputed()
        End If
    End Sub

    Private Sub tsApplyCredits_Click(sender As Object, e As EventArgs) Handles tsApplyCredits.Click
        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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

        With frmApplyCredits
            .ID = ID
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
                fComputed()

                IsNew = False
                tsSaveNew_Click(1, e)
            End If
            .Dispose()

        End With
        frmApplyCredits = Nothing

    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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

        If SecurityAccessPrint(Me) = False Then
            Exit Sub
        End If


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
        CryParameterInsertValue(gscryRpt, Val(ID), "myid")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        ReportExporPDF(gscryRpt, prPrint_Title)
        gsToolPanelView = False
        GlobalPreviewReport(prPrint_Title)


    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click



        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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
        If SecurityAccessPrint(Me) = False Then
            Exit Sub
        End If

        frmPrintPage.frmName = Me.Name
        frmPrintPage.ShowDialog()

        Dim v As Integer = frmPrintPage.prValue
        If v = 1 Or v = 2 Then

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
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
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False
                GlobalPreviewReport("Invoice Report")
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing



    End Sub

    Private Sub tsPrint_Click(sender As Object, e As EventArgs) Handles tsPrint.Click
        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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

            If SecurityAccessPrint(Me) = False Then

                Exit Sub
            End If

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
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
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
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

                SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0

                    GS_AccountJournalDelete(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        GS_AccountJournalDelete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    End If

                End If
                SqlExecuted("delete from invoice where id ='" & ID & "' limit 1;")
                gsGotChangeData = True
                   DeleteNotify(Me)

                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                ID = 0
                IsNew = True
                GS_CursorLoadingOn(False)
            End If


        End If

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
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

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GS_ViewItemDisplay(dgvProductItem)
        '    GS_ViewItemDisplay(dgvProductItem)
        dgvProductItem.Columns("AMOUNT").Width = 200
        GS_ViewNotSort(dgvProductItem)

        tsRoomName.Text = Me.Text

    End Sub

    Private Sub cmbMANAGER_ID_SelectedIndexChanged(sender As Object, e As EventArgs)
        '    fDepotAvailDiscount()
    End Sub
    'Private Sub fDepotAvailDiscount()
    '    Dim dBasicDiscount As Double = 0
    '    Dim dRabites As Double = 0
    '    Try
    '        If cmbMANAGER_ID.Text <> "" Then


    '            dBasicDiscount = GF_GetStringFieldValue("contact", "ID", cmbMANAGER_ID.SelectedValue, "DISCOUNT")


    '            If cmbMANAGER_ID.SelectedValue = cmbCUSTOMER_ID.SelectedValue Then
    '                dtpDATE.Checked = True
    '                Dim dt1 As Date = FirstDayOfMonth(dtpDATE.Value)
    '                dt1 = dt1.AddMonths(-1)
    '                Dim dt2 As Date = LastDayOfMonth(dt1)
    '                Dim R_number As Double = 0


    '                If fManagerHitSalesTargetViaDealer(Format(dt1, "yyyy-MM-dd"), Format(dt2, "yyyy-MM-dd"), cmbCUSTOMER_ID.SelectedValue, R_number) = True Then
    '                    dRabites = R_number * (Val(GetSystemSettingValueByText("ManagerRebites")) / 100)
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
    '                lblPENALTY_RATE.Text = GF_GetNumberFieldValue("contact", "ID", cmbCUSTOMER_ID.SelectedValue, "FIXED_PENALTY")
    '            Case 2
    '                lblPENALTY_RATE.Text = GF_GetNumberFieldValue("contact", "ID", cmbCUSTOMER_ID.SelectedValue, "RUNNING_PENALTY")
    '            Case Else
    '                lblPENALTY_RATE.Text = "0"
    '        End Select
    '        POSComputed()

    '    Catch ex As Exception
    '        lblPENALTY_RATE.Text = "0"
    '    End Try

    'End Sub

    Private Sub dtpDUE_DATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpDUE_DATE.ValueChanged
        fComputed()
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
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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
        AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 23, 4, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

        ShowHistoryList(ID, Me)

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tsMenu.ItemClicked

    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbCUSTOMER_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCUSTOMER_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbCUSTOMER_ID.Text)
            If cmbCUSTOMER_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If SecurityAccessMode(frmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/customer.png")

                    frmContactDetails.ContactTypeId = "1"
                    frmContactDetails.txtNAME.Text = StrText ' must auto insert
                    frmContactDetails.txtCOMPANY_NAME.Text = StrText
                    frmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    frmContactDetails.IsNew = True
                    frmContactDetails.ID = 0
                    frmContactDetails.gsDgv = Nothing
                    frmContactDetails.this_BS = Nothing
                    frmContactDetails.ShowDialog()
                    If frmContactDetails.gsOK = True Then
                        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbCUSTOMER_ID.SelectedValue = frmContactDetails.ID
                        cmbCUSTOMER_ID_LostFocus(sender, e)
                    End If
                    frmContactDetails.Dispose()
                    frmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Or cmbCUSTOMER_ID.SelectedValue Is Nothing Or cmbCUSTOMER_ID.Text = "" Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If

        With frmAddItemTouchScreen
            gsPOS_SELECTED_ROOM_ID = gsRoomID
            bRefreshItem = False
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE
            .sFormName = "frmInvoice"

            .StartPosition = FormStartPosition.Manual

            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            If gsMemberDiscount <> 0 Then
                .gsMEMBER = True
                .gsMEMEBER_DISCOUNT = gsMemberDiscount
            End If




            If My.Computer.Screen.WorkingArea.Width < 1200 Then

            Else
                .Size = New Size(.Width, Me.Height)
            End If

            .Location = New Point(0, 0)
            .ShowDialog()
            gsPOS_SELECTED_ROOM_ID = 0
        End With
        fComputed()
        frmAddItemTouchScreen.Dispose()
        frmAddItemTouchScreen = Nothing
    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        fDeleteItem()
    End Sub
    Private Sub fDeleteItem()

        Try

            If dgvProductItem.Rows.Count <> 0 Then
                dgvProductItem.Select()
                Dim I As Integer = dgvProductItem.CurrentRow.Index
                Dim d As DataGridViewRow = dgvProductItem.Rows(I)
                If d.Cells("ITEM_TYPE").Value = 6 And Val(d.Cells("ID").Value) <> 0 Then
                    If SecurityAccessDelete(Me) = False Then
                        Exit Sub
                    End If
                End If
                GS_RemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
                fCountItem()
                fComputed()
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub fCountItem()
        Dim T As Integer = 0
        For N As Integer = 0 To dgvProductItem.Rows.Count - 1
            If dgvProductItem.Rows(N).Visible = True Then
                T = T + 1
            End If

        Next
        lblCount.Text = T
    End Sub

    Private Sub frmInvoice_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged



        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)


        If IsNew = False Then
            fRefreshInfo()
            fRefreshItem()
        End If

    End Sub
    Private Sub txtCODE_TextChanged(sender As Object, e As EventArgs) Handles txtCODE.TextChanged

    End Sub
    'Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs)
    '    GetQuickFind(dgvProductItem, tsFindText.Text)
    'End Sub

    Private Sub LblOUTPUT_TAX_AMOUNT_Click(sender As Object, e As EventArgs) Handles lblOUTPUT_TAX_AMOUNT.Click

    End Sub

    Private Sub ToolStripLabel11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToCreditMemoToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        CustomerTax()
        xxxCustomer.Text = cmbCUSTOMER_ID.Text
        'If bEntryAddItem = True Then
        '    Exit Sub
        'End If

        'If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        'If IsNew = False Then Exit Sub
        'If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        'If cmbCUSTOMER_ID.Text = "" Then Exit Sub
        'Dim sql As String = ""
        ''  fDepotConnected(cmbCUSTOMER_ID, cmbDEALER_ID, cmbSALES_REP_ID)
        'Try
        '    sql = "Select count(p.`CODE`) As t FROM  sales_order As p   LEFT OUTER JOIN payment_terms As t  On t.ID = p.payment_terms_id   INNER JOIN sales_order_items As pt    On pt.`SALES_ORDER_ID` = p.`ID` WHERE pt.`CLOSED` = '0'   AND p.Customer_ID = '" & cmbCUSTOMER_ID.SelectedValue & "'   GROUP BY p.`CODE`"
        'Catch ex As Exception
        '    Exit Sub
        'End Try
        'Try

        '    Dim rd As OdbcDataReader = SqlReader(sql)
        '    If rd.Read Then

        '        If GF_NumIsNull(rd("t")) <> 0 Then
        '            With frmAvailableItem
        '                bEntryAddItem = True
        '                .gsdgv = dgvProductItem
        '                .gsCONTACT_ID = cmbCUSTOMER_ID.SelectedValue
        '                .gsType = 1
        '                bRefreshItem = True
        '                .ShowDialog()
        '                If .bClickOK = True Then
        '                    cmbLOCATION_ID.SelectedValue = .gsLocation_Select_ID
        '                End If
        '                ' cmbCUSTOMER_ID.SelectedValue = .gsCONTACT_ID
        '                .Dispose()
        '                POSComputed() ' i forgot
        '                bRefreshItem = False
        '            End With
        '            frmAvailableItem = Nothing
        '        End If
        '    End If
        '    rd.Close()
        'Catch ex As Exception

        '    MessageBoxWarning(ex.Message)
        'Finally
        '    bEntryAddItem = False
        'End Try
    End Sub

    Private Sub tsCancel_Click(sender As Object, e As EventArgs) Handles tsCancel.Click
        Me.Close()
    End Sub

    Private Sub tsCustomer_Click(sender As Object, e As EventArgs) Handles tsCustomer.Click
        Dim bNewContact As Boolean = False
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
            '  frmContactDetails.PictureBox1.Image = tsCustomer.Image
            frmContactDetails.ContactTypeId = 1
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                '  xlblCustomer_Name.Text = ""
                ' xlblAcctNo.Text = ""

                GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = frmContactDetails.ID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub tsCheckOut_Click(sender As Object, e As EventArgs) Handles tsCheckOut.Click

        If MessageBoxPointOfSalesYesNO($"Do you want to Check-Out this { Me.Text }") = False Then Exit Sub

        cmbSHIP_VIA_ID.SelectedValue = gsCHECK_OUT
        dtpDISCOUNT_DATE.Checked = True
        dtpCUSTOM_FIELD2.Checked = True

        dtpDISCOUNT_DATE.Enabled = True
        dtpCUSTOM_FIELD2.Enabled = True

        dtpDISCOUNT_DATE.Value = DateTime.Now
        dtpCUSTOM_FIELD2.Value = DateTime.Now

        tsSaveNew.PerformClick()

    End Sub

    Private Sub tsPayment_Click(sender As Object, e As EventArgs) Handles tsPayment.Click

        If GF_NumIsNull(lblAMOUNT.Text) = 0 Then
            MessageBoxInfo("No Transaction entry")
            Exit Sub
        End If




        If IsNew = False And ID <> 0 Then
            If fCheckHasChange() = True Then
                If MessageBoxPointOfSalesYesNO(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        MessageBoxInfo("Cancel")
                        Exit Sub
                    End If
                Else

                End If
            End If
        Else
            Dim strMsg As String


            strMsg = "Do you want to Save this new bill entry?"

            If MessageBoxPointOfSalesYesNO(strMsg) = True Then
                tsSaveNew_Click(sender, e)

                If ID = 0 Then
                    Exit Sub
                End If

            Else
                Exit Sub
            End If

        End If

        gsPOS_DATE = DateTime.Now.Date
        FrmPOSRoomPayment.gsInvoice_ID = ID
        FrmPOSRoomPayment.ShowDialog()
        Dim gsOK As Boolean = FrmPOSRoomPayment.gsOK
        FrmPOSRoomPayment.Dispose()
        FrmPOSRoomPayment = Nothing

        If gsOK = True Then
            gsGotChangeData = True
            fRefreshInfo()
            fRefreshItem()
            fRefreshPaymentList()
            Me.Close()
        End If


    End Sub



    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles xxxCO.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        tsPayment.PerformClick()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        tsCancel.PerformClick()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        tsSaveNew.PerformClick()
    End Sub

    Private Sub btnCustomer_Click(sender As Object, e As EventArgs) Handles btnCustomer.Click
        tsCustomer.PerformClick()
    End Sub

    Private Sub btnCheckOut_Click(sender As Object, e As EventArgs) Handles btnCheckOut.Click

        tsCheckOut.PerformClick()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        tsDelete.PerformClick()
    End Sub
    Public Function fCheckingGotVisibleIndex(ByVal isUp As Boolean) As Integer
        Dim This_number As Integer = dgvProductItem.CurrentRow.Index
        Dim Current As Integer = dgvProductItem.CurrentRow.Index
        If isUp = True Then

            For N As Integer = Current To 0 Step -1
                If dgvProductItem.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If

            Next


        Else
            For N As Integer = Current To dgvProductItem.Rows.Count - 1
                If dgvProductItem.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If

                End If

            Next
        End If

        Return This_number
    End Function
    Private Sub tsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvProductItem.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvProductItem.Select()
            dgvProductItem.CurrentCell = dgvProductItem.Rows(fCheckingGotVisibleIndex(False)).Cells("DESCRIPTION")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvProductItem.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvProductItem.Select()

            dgvProductItem.CurrentCell = dgvProductItem.Rows(fCheckingGotVisibleIndex(True)).Cells("DESCRIPTION")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tsTransfer_Click(sender As Object, e As EventArgs) Handles tsTransfer.Click

        If IsNew = True Then
            MessageBoxInfo("Invalid transfer.")
            Exit Sub
        End If

        frmPOSRoomTransfer.ShowDialog()
        Dim Item_ID As Integer = frmPOSRoomTransfer.gsTransfer_Item_ID
        frmPOSRoomTransfer.Dispose()
        frmPOSRoomTransfer = Nothing

        If Item_ID <> 0 Then

            Try
                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        If .Cells("ITEM_TYPE").Value = 10 Then
                            Dim rd As OdbcDataReader = SqlReader($"select * from item as i where i.id = '{Item_ID}' and i.inactive = '0' limit 1;")
                            If rd.Read Then
                                .Cells("item_id").Value = Item_ID
                                .Cells("description").Value = rd("description")
                                .Cells("code").Value = rd("code")
                                If .Cells("CONTROL_STATUS").Value = "S" Then
                                    .Cells("CONTROL_STATUS").Value = "E"
                                End If
                            End If
                            rd.Close()
                        End If
                    End With


                Next
            Catch ex As Exception
                MessageBoxExclamation(ex.Message)
            End Try





        End If
    End Sub
End Class