Imports System.Data.Odbc
Public Class FrmBills
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim bRefreshExpenses As Boolean = False
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tdgvE As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = GF_DataGridViewCounting(dgvProductItem)
    End Sub

    Private Function CheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        ElseIf DataGridGotChange(dgvExpenses, tdgvE) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub DgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub Frmbill_Load(sender As Object, e As EventArgs) Handles Me.Load

        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_PAYABLE_ID.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        spJournal.Visible = gsShowAccounts
        If gsShowAccounts = False Then
            TabControl1.TabPages.RemoveAt(1)
        End If

        tsTITLE.Text = gsSubMenuForm

        ColumnGrid()
        ColumnExpense()
        ClearInfo()

        If IsNew = False Then
            RefreshField()
            RefreshItem()
            RefreshExpense()


            If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                TabControl1.SelectedTab = TabPage1
            Else
                TabControl1.SelectedTab = TabPage2
            End If
            Computed()
        End If



    End Sub

    Private Sub RefreshItem()
        If dgvProductItem.Columns.Count = 0 Then Exit Sub
        dgvProductItem.Rows.Clear()
        bRefreshItem = True
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
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  c.`NAME` AS `CLASS`,
  ii.`CLASS_ID`,
  ii.`PO_ITEM_ID`,
 i.TYPE as `ITEM_TYPE`,
ii.ACCOUNT_ID,
ii.BATCH_ID,
 b.BATCH_NO

FROM

  bill_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    LEFT OUTER JOIN class AS c 
    ON c.`ID` =  ii.`CLASS_ID`
    LEFT OUTER JOIN `item_batches` AS b
    ON b.id = ii.BATCH_ID
    WHERE  ii.`Bill_ID` = '" & ID & "' Order by ii.LINE_NO"

        Try
            Dim x As Integer = 0

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
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItem()
            Else
                End
            End If
        Finally
            bRefreshItem = False
        End Try
        Computed()
    End Sub
    Private Sub RefreshExpense()
        dgvExpenses.Rows.Clear()
        bRefreshExpenses = True
        Dim sQuery As String = "SELECT 
  bs.`ID`,
  a.`NAME` AS `ACCOUNT`,
  bs.`AMOUNT`,
  bs.`TAXABLE` AS `TAX`,
  bs.`TAXABLE_AMOUNT`,
  bs.`TAX_AMOUNT`,
  bs.`PARTICULARS`,
  c.`NAME` AS `CLASS`,
  bs.`CLASS_ID`,
  'S' as `CONTROL_STATUS`,
   bs.`ACCOUNT_ID`
FROM
  bill_expenses AS bs 
  LEFT OUTER JOIN account AS a 
    ON a.`ID` = bs.`ACCOUNT_ID`
    LEFT OUTER JOIN class AS c
    ON c.`ID` = bs.`CLASS_ID`
    WHERE bs.`BILL_ID` ='" & ID & "' ORDER by bs.`LINE_NO`"

        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvExpenses.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvExpenses.Columns(i)
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else
                            dgvExpenses.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                        End If
                    End With

                Next
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshExpense()
            Else
                End
            End If
        Finally
            bRefreshExpenses = False
        End Try
        Computed()

        tdgv = New DataGridView
        tdgv = dgvProductItem
        tdgvE = New DataGridView
        tdgvE = dgvExpenses
        tQuery = SqlUpdate(Me)

    End Sub

    Private Sub RefreshField()


        Try


            SqlExecutedUsingReading(Me, "select * from bill where ID = '" & ID & "' Limit 1")
            cmbACCOUNTS_PAYABLE_ID.Enabled = False

            PrFormLoad()

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshField()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub Computed()

        GS_BillVendorComputation(dgvProductItem, dgvExpenses, cmbINPUT_TAX_ID, lblINPUT_TAX_AMOUNT, lblAMOUNT, lblINPUT_TAX_RATE, lbsTotal_Amount_Item, lbsTotal_Amount_Expense)
        Dim dPayment_applied As Double = GF_GetBillSumPaymentApplied(ID, cmbVENDOR_ID.SelectedValue) + GF_GetBillSumCreditApplied(ID, cmbVENDOR_ID.SelectedValue) + GF_GetBillSumTaxAppliedAmount(ID, cmbVENDOR_ID.SelectedValue)
        lblCount.Text = GF_DataGridViewCounting(dgvProductItem)
        lblCount2.Text = GF_DataGridViewCounting(dgvExpenses)
        lbxPaymentApplied.Text = NumberFormatStandard(dPayment_applied)
        Dim dBalance As Double = GF_NumIsNull(NumberFormatFixed(lblAMOUNT.Text)) - dPayment_applied
        lblBALANCE_DUE.Text = NumberFormatStandard(dBalance)

    End Sub
    Private Sub RefreshCombo()
        GS_ComboBoxLoad(cmbVENDOR_ID, "select ID,NAME from contact where type='0' order by `NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select ID,NAME from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbINPUT_TAX_ID, "select ID,NAME from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        GS_ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select ID,DESCRIPTION from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")
    End Sub
    Private Sub ClearInfo()
        RefreshCombo()
        ClearAndRefresh(Me)

        dtpDUE_DATE.Checked = False
        dgvProductItem.Rows.Clear()
        Computed()
        dgvExpenses.Rows.Clear()
        dgvProductItem.Rows.Clear()

        If Val(gsDefault_Vendor_ID) <> 0 Then
            cmbVENDOR_ID.SelectedValue = gsDefault_Vendor_ID
            cmbVENDOR_ID.Enabled = False

        End If

        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = GetPaymentTermsDefault()
        dtpDATE.Value = TransactionDefaultDate()
        cmbINPUT_TAX_ID.SelectedValue = GetInPutTaxDefault()

        PrFormLoad()

    End Sub
    Private Sub PrFormLoad()
        If GF_NumIsNull(lblRECEIVED_LOCATION_ID.Text) <> 0 Then
            xlblRECEIVED_LOCATION.Text = GF_GetStringFieldValue("LOCATION", "ID", lblRECEIVED_LOCATION_ID.Text, "NAME")
            xlblRECEIVED.Text = "To Received"
            xlblLOCATION.Text = "From "
            xlblRECEIVED_LOCATION.Visible = True
        Else
            xlblLOCATION.Text = "Branch"
            xlblRECEIVED.Text = ""
            xlblRECEIVED_LOCATION.Text = ""
            xlblRECEIVED_LOCATION.Visible = False
        End If
    End Sub
    Private Sub ColumnGrid()

        Dim ic As New DataGridViewImageColumn()
        Dim inImg As Image = gsImageBackground

        ic.Image = inImg
        ic.ImageLayout = DataGridViewImageCellLayout.Stretch

        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = gsCUSTOM_TAX,
            .Name = "TAX"
        }

        With dgvProductItem.Columns
            .Clear()

            .Add("ID", "ID") ' 0
            .Item(0).Visible = False

            .Add("CODE", gsCUSTOM_CODE) '1
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '2
            .Add("QTY", gsCUSTOM_QTY) '3
            .Add("UM", gsCUSTOM_UNIT) '4
            .Add("UNIT_PRICE", gsCUSTOM_COST) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8


            .Add(chk) '9


            .Add("UNIT_ID", "UNIT_ID") '10
            .Item("UNIT_ID").Visible = False

            .Add("CONTROL_STATUS", "CONTROL_STATUS") '11
            .Item("CONTROL_STATUS").Visible = False

            ' Control_Status_value
            ' S - Stable
            ' A - Added
            ' E - Editted
            ' D - Deleted

            .Add("RATE_TYPE", "RATE_TYPE") '12
            .Item("RATE_TYPE").Visible = False

            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '13
            .Item("UNIT_QUANTITY_BASE").Visible = False

            .Add("DISCOUNT_ID", "DISCOUNT_ID") '14
            .Item("DISCOUNT_ID").Visible = False

            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '15
            .Item("TAXABLE_AMOUNT").Visible = False

            .Add("TAX_AMOUNT", "TAX_AMOUNT") '16
            .Item("TAX_AMOUNT").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '17
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '18
            .Item("ITEM_ID").Visible = False

            .Add("CLASS", gsCUSTOM_CLASS) '19


            .Add("CLASS_ID", "CLASS_ID") '20
            .Item("CLASS_ID").Visible = False


            .Add("PO_ITEM_ID", "PO_ITEM_ID") '21
            .Item("PO_ITEM_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") '22
            .Item("ITEM_TYPE").Visible = False

            .Add("ACCOUNT_ID", "ACCOUNT_ID") '23
            .Item("ACCOUNT_ID").Visible = False


            .Add("BATCH_ID", "BATCH_ID") '24
            .Item("BATCH_ID").Visible = False

            .Add("BATCH_NO", gsCUSTOM_BATCH) '25
            .Item("BATCH_NO").Visible = gsExpiredReference

        End With

    End Sub

    Private Sub CmbINPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINPUT_TAX_ID.SelectedIndexChanged
        Computed()

        Try

            Dim rd As OdbcDataReader = SqlReader("Select VAT_METHOD,ASSET_ACCOUNT_ID from tax where ID ='" & GF_NumIsNull(cmbINPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblINPUT_TAX_VAT_METHOD.Text = GF_TextIsNull(rd("VAT_METHOD"))
                lblINPUT_TAX_ACCOUNT_ID.Text = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
            Else
                lblINPUT_TAX_VAT_METHOD.Text = ""
                lblINPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                CmbINPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If
            lblINPUT_TAX_VAT_METHOD.Text = ""
            lblINPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub RowDataExpenses(ByVal pradd As Boolean, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prTax As Boolean, ByVal prParticular As String, ByVal prClass_ID As String, ByVal prControl_Status As String)
        Dim sAccount_Name As String = GF_GetStringFieldValue("account", "ID", prAccount_ID, "NAME")
        Dim sclass_name As String = GF_GetStringFieldValue("class", "ID", prClass_ID, "NAME")
        Dim taxable_amount As Double = 0
        Dim tax_amount As Double = 0
        If pradd = True Then
            dgvExpenses.Rows.Add("N", sAccount_Name, NumberFormatStandard(prAmount), prTax, taxable_amount, tax_amount, prParticular, sclass_name, prClass_ID, prControl_Status, prAccount_ID)
        Else
            With dgvExpenses.Rows(dgvExpenses.CurrentRow.Index)
                .Cells("Account").Value = sAccount_Name
                .Cells("Amount").Value = NumberFormatStandard(prAmount)
                .Cells("Tax").Value = prTax
                .Cells("Taxable_Amount").Value = taxable_amount
                .Cells("Tax_Amount").Value = tax_amount
                .Cells("Particular").Value = prParticular
                .Cells("Class").Value = sclass_name
                .Cells("Class_ID").Value = prClass_ID
                .Cells("CONTROL_STATUS").Value = prControl_Status
                .Cells("Account_ID").Value = prAccount_ID
            End With
        End If
    End Sub

    Private Sub EditItem()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                MessageBoxExclamation("Data Not Found!")
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
            End If

            With FrmAddItem
                .gsUseItemBatch = True
                .gsCOST_AMOUNT_ONLY = True
                .gsSelection = True
                .gsSelection_Query = "select * from class"
                .gsSelection_Label = "Class"
                .gsSelection_DESCRIPTION = "NAME"
                .gsSelection_VALUE = "ID"
                .gsSelection_ID = GF_TextIsNull(dgvProductItem.Rows.Item(I).Cells("CLASS_ID").Value)

                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                .sFormName = ""
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value
                .gsDiscount_Rate = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsBATCH_ID = dgvProductItem.Rows(I).Cells("BATCH_ID").Value
            End With
            FrmAddItem.ShowDialog()
            With FrmAddItem
                If .gsSave = True Then
                    GS_RowDataItemBills(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsSelection_ID, dgvProductItem.Rows.Item(I).Cells("PO_ITEM_ID").Value, .gsBATCH_ID)
                    '  fDiscount_ReComputed(dgvProductItem)
                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub



    Private Sub DgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_TaxValue(dgvProductItem)
            Computed()
        End If
    End Sub
    Private Sub DgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
    End Sub

    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Vendor")
            Exit Sub
        End If

        If GF_NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select account payable")
            Exit Sub
        End If


        If dgvProductItem.Rows.Count = 0 Then
            If dgvExpenses.Rows.Count = 0 Then
                MessageBoxInfo("No items or Expenses enter")
                Exit Sub
            End If
        End If

        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GF_GetNextCode("BILL", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True
            ID = ObjectTypeMapId("BILL")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO bill ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',13,'{GetDateTimeNowSql()}') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbVENDOR_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            If GS_IsInventoryLastEntry(dgvProductItem, cmbLOCATION_ID.SelectedValue, 1, dtpDATE.Value) = False Then
                Exit Sub
            End If

            'Check bills / payments
            If GF_GetNumberFieldValue("check_bills", "bill_id", ID, "id") <> 0 Then
                If gsAdmin_User = False Then
                    MessageBoxWarning("Invalid to update bill already applied payment.")
                    Exit Sub
                Else
                    If MessageBoxWarningYesNo("Invalid to update bill already applied payment. do you want to proceed?") = False Then
                        Exit Sub
                    End If
                End If
            End If
            'bill_credit_bills / Returns
            If GF_GetNumberFieldValue("bill_credit_bills", "bill_id", ID, "id") <> 0 Then
                If gsAdmin_User = False Then
                    MessageBoxWarning("Invalid update bill already applied refund.")
                    Exit Sub
                Else
                    If MessageBoxWarningYesNo("Invalid update bill already applied refund. do you want to proceed?") = False Then
                        Exit Sub
                    End If
                End If
            End If

            tChangeAccept = True
            If gsSkipJournalEntry = False Then
                GotChangeTransaction("bill", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
                If gsGotChangeDate = True Then
                    'Main
                    AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 2, ID, gsLast_Location_ID, gsLast_Date)
                    'TAX
                    AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(lblINPUT_TAX_ACCOUNT_ID.Text), 2, ID, gsLast_Location_ID, gsLast_Date)
                End If

                If gsGotChangeLocation1 = True Then
                    'Main
                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, GF_NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 2, ID, dtpDATE.Value, gsLast_Location_ID)
                    'TAX
                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, GF_NumIsNull(lblINPUT_TAX_ACCOUNT_ID.Text), 2, ID, dtpDATE.Value, gsLast_Location_ID)
                End If
            End If

            Dim squery As String = SqlUpdate(Me)
            squery = squery & " WHERE ID = '" & ID & "'"
            SqlExecuted("UPDATE bill SET " & squery)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbVENDOR_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If GF_IsTransactionSuccess(ID, "BILL") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        End If

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            GS_AccountJournalExecute(cmbACCOUNTS_PAYABLE_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 2, ID, dtpDATE.Value, 1, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If GF_NumIsNull(lblINPUT_TAX_AMOUNT.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblINPUT_TAX_ACCOUNT_ID.Text), 2, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue)
            Else
                GS_AccountJournalExecute(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 2, ID, dtpDATE.Value, 0, GF_NumIsNull(lblINPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================

        SaveItem()  ' Save item
        SaveExpenses()

        ExpensesUpdateStatus()

        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        SaveNotify(Me, IsNew)

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = tsSaveNew.Name Then
                SetNew()
            End If
        Catch ex As Exception

        Finally
            If ID > 0 Then
                IsNew = False
                RefreshField()
                RefreshItem()
                RefreshExpense()
            End If
        End Try

    End Sub


    Private Sub SetNew()

        ClearInfo()
        dgvProductItem.Rows.Clear()
        dgvExpenses.Rows.Clear()
        Computed()
        ID = 0
        IsNew = True

    End Sub
    Private Sub SaveItem()
        If dgvProductItem.Rows.Count <> 0 Then
            For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                With dgvProductItem.Rows(i)
                    Select Case .Cells("CONTROL_STATUS").Value
                        Case "S"
                            'UPDATE TAX ONLY
                            fTax_Computation(cmbINPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            SqlExecuted("UPDATE bill_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE BILL_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;")
                            If gsSkipJournalEntry = False Then
                                If gsGotChangeDate = True Then
                                    AccountJournalChangeDate(dtpDATE.Value, .Cells("ACCOUNT_ID").Value, 3, GF_NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                End If
                                If gsGotChangeLocation1 = True Then
                                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ACCOUNT_ID").Value, 3, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                End If
                            End If
                            If gsGotChangeDate = True Then
                                ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 1, GF_NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If
                            If gsGotChangeLocation1 = True Then
                                ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 1, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If
                            GS_InventoryJournalVendors(dgvProductItem, i, False, 3, 1, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, GF_NumIsNull(.Cells("UNIT_PRICE").Value))

                        Case "A"
                            fTax_Computation(cmbINPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            Dim i_ID As Double = ObjectTypeMapId("BILL_ITEMS")
                            .Cells("ID").Value = i_ID
                            SqlExecuted("INSERT INTO bill_items SET LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",BILL_ID ='" & ID & "',ACCOUNT_ID=" & GotNullNumber(GF_NumIsNull(.Cells("ACCOUNT_ID").Value)) & ",CLASS_ID=" & GotNullNumber(GF_NumIsNull(.Cells("CLASS_ID").Value)) & ",PO_ITEM_ID=" & GotNullNumber(GF_NumIsNull(.Cells("PO_ITEM_ID").Value)) & ",BATCH_ID = " & GotNullNumber(GF_NumIsNull(.Cells("BATCH_ID").Value)) & ";")
                            GS_InventoryJournalVendors(dgvProductItem, i, False, 3, 1, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, GF_NumIsNull(.Cells("UNIT_PRICE").Value))
                            PurchaseItemUpdate(GF_NumIsNull(.Cells("PO_ITEM_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)
                            GS_BILL_ITEM_COST_UPDATE_NEW(GF_NumIsNull(.Cells("ITEM_ID").Value), GF_NumIsNull(.Cells("UNIT_PRICE").Value))

                        Case "E"
                            fTax_Computation(cmbINPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            SqlExecuted("UPDATE bill_items SET LINE_NO='" & i & "',QUANTITY='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",CLASS_ID=" & GotNullNumber(GF_NumIsNull(.Cells("CLASS_ID").Value)) & ",PO_ITEM_ID=" & GotNullNumber(GF_NumIsNull(.Cells("PO_ITEM_ID").Value)) & ",BATCH_ID = " & GotNullNumber(GF_NumIsNull(.Cells("BATCH_ID").Value)) & " WHERE BILL_ID ='" & ID & "' and ID = " & GF_NumIsNull(.Cells("ID").Value) & " limit 1;")
                            GS_InventoryJournalVendors(dgvProductItem, i, False, 3, 1, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, GF_NumIsNull(.Cells("UNIT_PRICE").Value))
                            PurchaseItemUpdate(GF_NumIsNull(.Cells("PO_ITEM_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)
                        Case "D"
                            SqlExecuted("DELETE FROM bill_items WHERE BILL_ID ='" & ID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "' limit 1;")
                            GS_InventoryJournalVendors(dgvProductItem, i, False, 3, 1, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, GF_NumIsNull(.Cells("UNIT_PRICE").Value))
                            PurchaseItemUpdate(GF_NumIsNull(.Cells("PO_ITEM_ID").Value), GF_NumIsNull(.Cells("QTY").Value), False)
                    End Select

                End With


            Next
        End If



    End Sub
    Private Sub PurchaseItemUpdate(ByVal gsID As Integer, ByVal prRECEIVED_QTY As Double, ByVal ADD_EDIT As Boolean)
        Dim SQL As String = ""
        If gsID <> 0 Then
            If ADD_EDIT = True Then
                SQL = "Update purchase_order_items SET `RECEIVED_QTY` = '" & prRECEIVED_QTY & "' ,`CLOSED` = '1' where ID = '" & gsID & "' Limit 1"
            Else
                SQL = "Update purchase_order_items SET `RECEIVED_QTY` = NULL,`CLOSED` = '0' where ID = '" & gsID & "' Limit 1"
            End If
        End If
        SqlExecuted(SQL)
    End Sub
    Private Sub SaveExpenses()

        If dgvExpenses.Rows.Count <> 0 Then
            For i As Integer = 0 To dgvExpenses.Rows.Count - 1
                With dgvExpenses.Rows(i)
                    Select Case .Cells("CONTROL_STATUS").Value
                        Case "S"
                            'UPDATE TAX
                            fTax_Computation(cmbINPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))

                            SqlExecuted("UPDATE bill_expenses SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE BILL_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;")

                            If gsSkipJournalEntry = False Then
                                If gsGotChangeDate = True Then
                                    AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(.Cells("Account_ID").Value), 78, GF_NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                End If

                                If gsGotChangeLocation1 = True Then
                                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, GF_NumIsNull(.Cells("Account_ID").Value), 78, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                End If

                                Dim E As Integer
                                If GF_NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 0
                                Else
                                    E = 1
                                End If
                                Dim AMT As Double
                                If GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = GF_NumIsNull(.Cells("AMOUNT").Value)
                                End If
                                GS_AccountJournalExecute(GF_NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 78, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)

                            End If

                        Case "A"
                            fTax_Computation(cmbINPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))
                            Dim i_ID As Double = ObjectTypeMapId("BILL_EXPENSES")
                            .Cells("ID").Value = i_ID
                            .Cells("CONTROL_STATUS").Value = "S"
                            SqlExecuted("INSERT INTO bill_expenses SET LINE_NO='" & i & "',ID='" & .Cells("ID").Value & "',AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',BILL_ID ='" & ID & "',ACCOUNT_ID='" & GF_NumIsNull(.Cells("Account_ID").Value) & "',PARTICULARS='" & GF_TextIsNull(.Cells("Particular").Value) & "',CLASS_ID=" & GotNullNumber(GF_NumIsNull(.Cells("CLASS_ID").Value)) & ";")


                            '===========================================
                            If gsSkipJournalEntry = False Then
                                Dim E As Integer
                                Dim AMT As Double
                                If GF_NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 0
                                Else
                                    E = 1
                                End If
                                If GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) > 0 Then
                                    AMT = GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = GF_NumIsNull(.Cells("AMOUNT").Value)
                                End If
                                GS_AccountJournalExecute(GF_NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 78, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)

                            End If
                             '================================
                        Case "E"

                            fTax_Computation(cmbINPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))
                            SqlExecuted("UPDATE bill_expenses SET LINE_NO='" & i & "',PARTICULARS='" & GF_TextIsNull(.Cells("Particular").Value) & "',ACCOUNT_ID='" & GF_NumIsNull(.Cells("Account_ID").Value) & "',AMOUNT ='" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',CLASS_ID=" & GotNullNumber(GF_NumIsNull(.Cells("CLASS_ID").Value)) & " WHERE BILL_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " Limit 1;")

                            If gsSkipJournalEntry = False Then
                                Dim E As Integer
                                Dim AMT As Double
                                If GF_NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 0
                                Else
                                    E = 1
                                End If
                                If GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = GF_NumIsNull(.Cells("AMOUNT").Value)
                                End If
                                GS_AccountJournalExecute(GF_NumIsNull(.Cells("ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 78, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)

                            End If
                        Case "D"
                            SqlExecuted("DELETE FROM bill_expenses WHERE BILL_ID ='" & ID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "' limit 1;")
                            If gsSkipJournalEntry = False Then
                                GS_AccountJournalDelete(GF_NumIsNull(.Cells("ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 78, .Cells("ID").Value, dtpDATE.Value)
                            End If
                    End Select
                End With
            Next
        End If

    End Sub
    Private Sub ExpensesUpdateStatus()
        For i As Integer = 0 To dgvExpenses.Rows.Count - 1
            With dgvExpenses.Rows(i)
                If .Cells("CONTROL_STATUS").Value = "D" Then
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    .Cells("CONTROL_STATUS").Value = "S"
                End If
            End With
        Next
    End Sub
    Private Sub TsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
            Exit Sub
        Else
            If IsNew = False And ID > 0 Then
                If CheckHasChange() = True Then
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

        f.AccessibleName = "bill"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                IsNew = False
                ClearInfo()
                ID = f.AccessibleDescription

                RefreshField()
                RefreshItem()
                RefreshExpense()

                If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                    TabControl1.SelectedTab = TabPage1
                Else
                    TabControl1.SelectedTab = TabPage2
                End If
            End If


        End If


    End Sub


    Private Sub ColumnExpense()
        Dim Tax As New DataGridViewCheckBoxColumn With {
            .Name = gsCUSTOM_TAX,
            .HeaderText = "Tax",
            .Width = 40
        }
        With dgvExpenses.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("Account", gsCUSTOM_ACCOUNT_NAME)
            .Add("Amount", gsCUSTOM_AMOUNT)
            .Add(Tax)
            .Add("Taxable_Amount", "Taxable Amount")
            .Item("Taxable_Amount").Visible = False
            .Add("Tax_Amount", "Tax Amount")
            .Item("Tax_Amount").Visible = False
            .Add("Particular", gsCUSTOM_PARTICULAR)
            .Item("Particular").Width = 200
            .Add("Class", gsCUSTOM_CLASS)
            .Add("Class_ID", "Class_ID")
            .Item("Class_ID").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS")
            .Item("CONTROL_STATUS").Visible = False
            .Add("account_ID", "account_ID")
            .Item("account_ID").Visible = False
        End With
    End Sub

    Private Sub EditExpense()
        If dgvExpenses.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim i As Integer = dgvExpenses.CurrentRow.Index
        Dim dr As DataGridViewRow = dgvExpenses.Rows(i)
        With FrmAddExpenses
            .gsAccount_ID = dr.Cells("account_id").Value
            .gsAmount = dr.Cells("amount").Value
            .gsClass_ID = dr.Cells("class_Id").Value
            .gsParticular = dr.Cells("particular").Value
            .gsTax = dr.Cells("Tax").Value
            .ShowDialog()
            If .gsSave = True Then
                Dim C_STATUS As String
                If GF_NumIsNull(dr.Cells("ID").Value) = 0 Then
                    C_STATUS = "A"
                Else
                    C_STATUS = "E"
                End If
                RowDataExpenses(False, .gsAccount_ID, .gsAmount, .gsTax, .gsParticular, .gsClass_ID, C_STATUS)
            End If
            .Dispose()
        End With
        FrmAddExpenses = Nothing
        Computed()
    End Sub
    Private Sub DgvExpenses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellDoubleClick
        EditExpense()
    End Sub
    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If


            If GS_IsInventoryLastEntry(dgvProductItem, cmbLOCATION_ID.SelectedValue, 1, dtpDATE.Value) = False Then
                Exit Sub
            End If


            If MessageBoxQuestion(gsMessageQuestion) = True Then

                Try

                    Dim rd As OdbcDataReader = SqlReader("select * from bill_credit_bills where Bill_ID = '" & ID & "' Limit 1")
                    If rd.Read Then
                        If gsForceDeleteBill = False Then
                            MessageBoxWarning("Invalid delete bill credit are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted(" Delete from bill_credit_bills where Bill_ID = '" & ID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception

                    If MessageBoxErrorYesNo(ex.Message) = True Then

                    Else
                        End
                    End If

                End Try
                'Check Bill/ Bill Payment

                Try

                    Dim rd As OdbcDataReader = SqlReader("select * from check_bills where Bill_ID = '" & ID & "' Limit 1")
                    If rd.Read Then
                        If gsForceDeleteBill = False Then
                            MessageBoxWarning("Invalid delete bill. bill payments are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("Delete from check_bills where Bill_ID = '" & ID & "'")
                            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbVENDOR_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception
                    If MessageBoxErrorYesNo(ex.Message) = True Then

                    Else
                        End
                    End If

                End Try

                'WithholdingTax
                Try

                    Dim rd As OdbcDataReader = SqlReader("select * from `withholding_tax_bills` where Bill_ID = '" & ID & "' Limit 1")
                    If rd.Read Then
                        If gsForceDeleteBill = False Then
                            MessageBoxWarning("Invalid delete bill. withholding tax are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted(" Delete from `withholding_tax_bills` where Bill_ID = '" & ID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception

                    If MessageBoxErrorYesNo(ex.Message) = True Then

                    Else
                        End
                    End If

                End Try




                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next

                SaveItem()

                For N As Integer = 0 To dgvExpenses.Rows.Count - 1
                    With dgvExpenses.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next

                SaveExpenses()
                '===========================================
                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0
                    GS_AccountJournalDelete(cmbACCOUNTS_PAYABLE_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 2, ID, dtpDATE.Value)
                    If GF_NumIsNull(lblINPUT_TAX_AMOUNT.Text) <> 0 Then
                        GS_AccountJournalDelete(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 2, ID, dtpDATE.Value)
                    End If



                End If
                '===============================

                SqlExecuted("Delete from `bill` where ID = '" & ID & "' limit 1;")

                DeleteNotify(Me)

                If MessageBoxQuestion("Without clear details?") = True Then
                    cmbLOCATION_ID.Enabled = True
                    dtpDATE.Enabled = True

                    For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                        With dgvProductItem.Rows(i)
                            .Cells("CONTROL_STATUS").Value = "A"
                        End With
                    Next

                    For i As Integer = 0 To dgvExpenses.Rows.Count - 1
                        With dgvExpenses.Rows(i)
                            .Cells("CONTROL_STATUS").Value = "A"
                        End With
                    Next

                    Computed()
                    ID = 0
                    IsNew = True
                Else

                    ClearInfo()
                    dgvProductItem.Rows.Clear()
                    dgvExpenses.Rows.Clear()
                    Computed()
                    ID = 0
                    IsNew = True
                End If
            End If
        End If

    End Sub

    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If

    End Sub
    Private Sub CmbVENDOR_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVENDOR_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbVENDOR_ID.Text)
            If cmbVENDOR_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If SecurityAccessMode(FrmVendor, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/vendor.png")

                    FrmContactDetails.ContactTypeId = 0
                    FrmContactDetails.txtNAME.Text = StrText ' must auto insert
                    FrmContactDetails.txtCOMPANY_NAME.Text = StrText
                    FrmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    FrmContactDetails.IsNew = True
                    FrmContactDetails.ID = 0
                    FrmContactDetails.gsDgv = Nothing
                    FrmContactDetails.this_BS = Nothing
                    FrmContactDetails.ShowDialog()
                    If FrmContactDetails.gsOK = True Then
                        GS_ComboBoxLoad(cmbVENDOR_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbVENDOR_ID.SelectedValue = FrmContactDetails.ID
                        CmbVENDOR_ID_LostFocus(sender, e)
                    End If
                    FrmContactDetails.Dispose()
                    FrmContactDetails = Nothing
                End If

            End If
        End If
    End Sub
    Private Sub CmbVENDOR_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVENDOR_ID.SelectedIndexChanged
        If IsNew = False Then Exit Sub
        If cmbVENDOR_ID.Text = "" Then Exit Sub
        Dim sql As String
        Try

            Dim xID As Integer = cmbVENDOR_ID.SelectedValue
            sql = "SELECT count(p.`CODE`) as t FROM  purchase_order AS p LEFT OUTER JOIN payment_terms AS t ON t.ID = p.payment_terms_id     INNER JOIN purchase_order_items AS pt  ON pt.`PO_ID` = p.`ID` WHERE pt.`CLOSED` = '0'  AND p.vendor_id = '" & xID & "'   GROUP BY p.`CODE`"

        Catch ex As Exception
            Exit Sub
        End Try


        Try

            Dim rd As OdbcDataReader = SqlReader(sql)
            If rd.Read Then
                If GF_NumIsNull(rd("t")) <> 0 Then
                    With FrmAvailableItem
                        .gsdgv = dgvProductItem
                        .gsCONTACT_ID = cmbVENDOR_ID.SelectedValue
                        .gsType = 0
                        .ShowDialog()
                        If .bClickOK = True Then
                            If gsStorage_Location_ID <> 0 Then
                                cmbLOCATION_ID.SelectedValue = .gsLocation_Select_ID
                                lblRECEIVED_LOCATION_ID.Text = .PR_TO_LOC_ID
                                PrFormLoad()
                            Else
                                cmbLOCATION_ID.SelectedValue = .PR_TO_LOC_ID
                                lblRECEIVED_LOCATION_ID.Text = ""
                                PrFormLoad()
                            End If
                        End If
                        .Dispose()
                    End With
                    FrmAvailableItem = Nothing
                End If
            End If
            rd.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CmbVENDOR_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbVENDOR_ID.LostFocus
        VendorTax()
    End Sub

    Private Sub CmbPAYMENT_TERMS_ID_SelectedIndexChanged(sender As Object, e As EventArgs)
        fSetDueDate_PaymentTerms(cmbPAYMENT_TERMS_ID, dtpDUE_DATE, dtpDATE)
    End Sub

    Private Sub FrmBills_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GS_ViewItemDisplay(dgvProductItem)
        GS_ViewExpensesDisplay(dgvExpenses)

        GS_ViewNotSort(dgvProductItem)
        GS_ViewNotSort(dgvExpenses)
    End Sub

    Private Sub TsNowPrint_Click(sender As Object, e As EventArgs) Handles tsNowPrint.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
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
        If IsNew = True Then Exit Sub
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
        CryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "received_by")
        If prPrint_Title = "Bill Item Received" Then
            CryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "checked_by")
        End If
        ReportExporPDF(gscryRpt, prPrint_Title)
        gscryRpt.PrintToPrinter(1, False, 0, 0)
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
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

            CryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "received_by")
            If prFile_name = "cryBill.rpt" Then
                CryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "checked_by")
            End If



            ReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            GlobalPreviewReport("Bill Report")
        End If
    End Sub



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 2, 21, cmbVENDOR_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If

    End Sub

    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then

                RefreshField()
                RefreshItem()
                RefreshExpense()

                If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                    TabControl1.SelectedTab = TabPage1
                Else
                    TabControl1.SelectedTab = TabPage2
                End If
                Computed()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
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

        If IsNew = True Then Exit Sub
        If SecurityAccessPrint(Me) = False Then
            Exit Sub
        End If
        FrmPrintPage.frmName = Me.Name
        FrmPrintPage.ShowDialog()
        Application.DoEvents()
        Dim v As Integer = FrmPrintPage.prValue
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

            CryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "received_by")
            If prFile_name = "cryBill.rpt" Then
                CryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "checked_by")
            End If

            ReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                GlobalPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        FrmPrintPage.Dispose()
        FrmPrintPage = Nothing

    End Sub


    Private Sub VendorTax()
        Application.DoEvents()
        Dim s As Integer
        Try
            s = cmbVENDOR_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbVENDOR_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbVENDOR_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from contact where id ='{s}' and `type` = '0' limit 1 ")
        If rd.Read Then
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbINPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub

    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        Try
            If IsNew = False Then Exit Sub

            If cmbLOCATION_ID.Enabled = True Then
                If cmbLOCATION_ID.Items.Count = 0 Then Exit Sub

                If gsStorage_Location_ID = cmbLOCATION_ID.SelectedValue Then

                    FrmSelectLocation.ShowDialog()
                    If FrmSelectLocation.gsOK = True Then
                        If FrmSelectLocation.cmbLOCATION_ID.SelectedValue = cmbLOCATION_ID.SelectedValue Then
                            MessageBoxInfo("Invalid. Please select any branch")
                            lblRECEIVED_LOCATION_ID.Text = ""
                        Else
                            lblRECEIVED_LOCATION_ID.Text = FrmSelectLocation.cmbLOCATION_ID.SelectedValue
                        End If

                    End If
                    FrmSelectLocation.Dispose()
                    FrmSelectLocation = Nothing
                Else
                    lblRECEIVED_LOCATION_ID.Text = ""
                End If
                PrFormLoad()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub FrmBills_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If IsNew = False Then
            RefreshField()
            RefreshItem()
            RefreshExpense()
            If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                TabControl1.SelectedTab = TabPage1
            Else
                TabControl1.SelectedTab = TabPage2
            End If
            Computed()




        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select vendor")
            Exit Sub
        End If
        With FrmAddItem
            .gsUseItemBatch = True
            .gsCOST_AMOUNT_ONLY = True
            .dgv = dgvProductItem
            .gsDate = dtpDATE.Value
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .sFormName = Me.Name
            .gsSelection = True
            .gsSelection_Query = "select * from class"
            .gsSelection_Label = "Class"
            .gsSelection_DESCRIPTION = "NAME"
            .gsSelection_VALUE = "ID"
            .gsSelection_ID = ""
        End With

        FrmAddItem.ShowDialog()

        Computed()
        FrmAddItem.Dispose()
        FrmAddItem = Nothing
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        EditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvProductItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvProductItem.CurrentRow.Index

                If GF_NumIsNull(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                    dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvProductItem.Rows(i).Visible = False
                Else
                    dgvProductItem.Rows.RemoveAt(i)
                End If
                ' fDiscount_ReComputed(dgvProductItem)
                Computed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsAddExpenses_Click(sender As Object, e As EventArgs) Handles tsAddExpenses.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select vendor")
            Exit Sub
        End If


        With FrmAddExpenses
            .gsNew = True
            .gsDGV = dgvExpenses
            .ShowDialog()
            .Dispose()
        End With
        FrmAddExpenses = Nothing
        Computed()
    End Sub

    Private Sub TsEditExpenses_Click(sender As Object, e As EventArgs) Handles tsEditExpenses.Click
        EditExpense()
    End Sub

    Private Sub TsRemoveExpenses_Click(sender As Object, e As EventArgs) Handles tsRemoveExpenses.Click
        Try
            If dgvExpenses.Rows.Count <> 0 Then
                Dim i As Integer = dgvExpenses.CurrentRow.Index
                If GF_NumIsNull(dgvExpenses.Rows(i).Cells(0).Value) <> 0 Then
                    dgvExpenses.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvExpenses.Rows(i).Visible = False
                Else
                    dgvExpenses.Rows.RemoveAt(i)
                End If
                Computed()
            End If
        Catch ex As Exception

        End Try
    End Sub



    Private Sub DgvExpenses_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvExpenses.RowStateChanged
        lblCount2.Text = GF_DataGridViewCounting(dgvExpenses)
    End Sub

    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub TsFindText2_TextChanged(sender As Object, e As EventArgs) Handles tsFindText2.TextChanged
        GetQuickFind(dgvExpenses, tsFindText2.Text)
    End Sub

    Private Sub ToCreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCreditsToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
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
            With FrmApplyBillCredit
                .gsID = ID
                .gsLocation_ID = cmbLOCATION_ID.SelectedValue
                .gsVendor_ID = cmbVENDOR_ID.SelectedValue
                .lblName.Text = cmbVENDOR_ID.Text
                .lblCODE.Text = txtCODE.Text
                .lblDATE.Text = dtpDATE.Value
                .lblORG_AMOUNT.Text = lblAMOUNT.Text
                .gsBalance = NumberFormatFixed(lblBALANCE_DUE.Text)
                .ShowDialog()
                If .gsOk = True Then
                    Computed()
                    TsSaveNew_Click(sender, e)
                End If
                .Dispose()
            End With
            FrmApplyCredits = Nothing
        End If
    End Sub
End Class