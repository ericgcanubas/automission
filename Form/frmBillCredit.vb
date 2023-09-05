Imports System.Data.Odbc
Public Class frmBillCredit
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim bRefreshItem As Boolean = False
    Dim bRefreshExpenses As Boolean = False
    Dim f As Form = New frmFindDocument
    Dim tdgv As DataGridView
    Dim tdgvE As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub dgvExpenses_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvExpenses.RowStateChanged
        lblCount2.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        ElseIf fdgvChange(dgvExpenses, tdgvE) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And gsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmBillCredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_PAYABLE_ID.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        spJournal.Visible = gsShowAccounts
        If gsShowAccounts = False Then
            TabControl1.TabPages.RemoveAt(1)
        End If


        tsTITLE.Text = gsSubMenuForm

        fcolumnGrid()
        fColumn_Expense()
        fclear_Info()


        If gsNew = False Then
            fRefreshField()
            fRefreshItem()
            fRefreshExpense()

            If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                TabControl1.SelectedTab = TabPage1
            Else
                TabControl1.SelectedTab = TabPage2
            End If
        End If

    End Sub

    Private Sub fRefreshExpense()
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
  bill_credit_expenses AS bs 
  LEFT OUTER JOIN account AS a 
    ON a.`ID` = bs.`ACCOUNT_ID`
    LEFT OUTER JOIN class AS c
    ON c.`ID` = bs.`CLASS_ID`
    WHERE bs.`Bill_CREDIT_ID` ='" & gsID & "' ORDER by bs.`LINE_NO`"


        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                dgvExpenses.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvExpenses.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = fNumFormatStandard(fNumisNULL(rd(i)))
                        ElseIf fCheckNumNoDecimal(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = fNumFormatNoDecimal(fNumisNULL(rd(i)))
                        ElseIf fCheckBoolType(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = CBool(fNumisNULL(rd(i)))
                        Else
                            dgvExpenses.Rows(x).Cells(i).Value = fTextisNULL(rd(i))
                        End If
                    End With

                Next
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            fRefreshExpense()
        Finally
            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tdgvE = New DataGridView
            tdgvE = dgvExpenses
            tQuery = fFieldCollector(Me)

        End Try
        bRefreshExpenses = False
    End Sub
    Private Sub fRefreshItem()

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
  i.TYPE as `ITEM_TYPE`,
  ii.ACCOUNT_ID,
  ii.BATCH_ID,
  b.BATCH_NO
FROM

  bill_credit_items AS ii 
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

    WHERE  ii.`Bill_CREDIT_ID` = '" & gsID & "' Order by ii.LINE_NO"


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
                fRefreshItem()
            Else
                End
            End If
        Finally
            fComputed()
        End Try




        bRefreshItem = False


    End Sub
    Private Sub fRefreshField()
        Try
            Dim sQuery As String = "select * from bill_credit where ID = '" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)

            cmbACCOUNTS_PAYABLE_ID.Enabled = False
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshField()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub fRefreshCombo()
        fComboBox(cmbVENDOR_ID, "select * from contact where type='0' ", "ID", "NAME")
        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        fComboBox(cmbINPUT_TAX_ID, "select * from tax where tax_type = '3' order by ID DESC", "ID", "NAME")
        fComboBox(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub
    Private Sub fclear_Info()
        fRefreshCombo()
        fCLean_and_refresh(Me)

        dgvProductItem.Rows.Clear()
        dgvExpenses.Rows.Clear()
        dgvProductItem.Rows.Clear()
        If Val(gsDefault_Vendor_ID) <> 0 Then
            cmbVENDOR_ID.SelectedValue = gsDefault_Vendor_ID
            cmbVENDOR_ID.Enabled = False


        End If

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbINPUT_TAX_ID.SelectedValue = fInPutTaxDefault()
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID
    End Sub
    Private Sub fcolumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = gsCUSTOM_TAX
        chk.Name = "TAX"

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

            .Add("ITEM_TYPE", "ITEM_TYPE") '21
            .Item("ITEM_TYPE").Visible = False

            .Add("ACCOUNT_ID", "ACCOUNT_ID") '22
            .Item("ACCOUNT_ID").Visible = False

            .Add("BATCH_ID", "BATCH_ID") '23
            .Item("BATCH_ID").Visible = False

            .Add("BATCH_NO", gsCUSTOM_BATCH) '24
            .Item("BATCH_NO").Visible = gsExpiredReference

        End With
    End Sub
    Private Sub fColumn_Expense()
        Dim Tax As New DataGridViewCheckBoxColumn
        Tax.Name = gsCUSTOM_TAX
        Tax.HeaderText = "Tax"
        Tax.Width = 40
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
    Private Sub fComputed()


        lblCount.Text = fDgvCounting(dgvProductItem)
        lblCount2.Text = fDgvCounting(dgvExpenses)

        fBill_Vendor_Computation(dgvProductItem, dgvExpenses, cmbINPUT_TAX_ID, lblINPUT_TAX_AMOUNT, lblAMOUNT, lblINPUT_TAX_RATE, lbsTotal_Amount_Item, lbsTotal_Amount_Expense)

        Dim dPayment_applied As Double = fBillCreditApplied_Amount(gsID, cmbVENDOR_ID.SelectedValue)
        lblAMOUNT_APPLIED.Text = fNumFormatStandard(dPayment_applied)
        Dim dBalance As Double = fNumisNULL(fNumFormatFixed(lblAMOUNT.Text)) - dPayment_applied
        lbsCredits.Text = fNumFormatStandard(dBalance)



    End Sub

    Private Sub cmbINPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINPUT_TAX_ID.SelectedIndexChanged

        fComputed()

        Try

            Dim rd As OdbcDataReader = fReader("Select VAT_METHOD , ASSET_ACCOUNT_ID from tax where ID ='" & fNumisNULL(cmbINPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblINPUT_TAX_VAT_METHOD.Text = fTextisNULL(rd("VAT_METHOD"))
                lblINPUT_TAX_ACCOUNT_ID.Text = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
            Else
                lblINPUT_TAX_VAT_METHOD.Text = ""
                lblINPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception

            lblINPUT_TAX_VAT_METHOD.Text = ""
            lblINPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub

        Else
            If gsNew = False And gsID <> "" Then
                If fCheckHasChange() = True Then
                    If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        tsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            fMessageboxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If
        End If

        f.AccessibleName = "bill_credit"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fclear_Info()
                gsID = f.AccessibleDescription
                gsNew = False

                fRefreshField()
                fRefreshItem()
                fRefreshExpense()

                If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                    TabControl1.SelectedTab = TabPage1
                Else
                    TabControl1.SelectedTab = TabPage2
                End If

            End If


        End If


    End Sub

    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub fEditItem()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                fMessageboxExclamation("Data Not Found!")
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
            End If

            With frmAddItem
                .gsUseItemBatch = True
                .gsCOST_AMOUNT_ONLY = True
                .gsSelection = True
                .gsSelection_Query = "select * from class"
                .gsSelection_Label = "Class"
                .gsSelection_DESCRIPTION = "NAME"
                .gsSelection_VALUE = "ID"
                .gsSelection_ID = fTextisNULL(dgvProductItem.Rows.Item(I).Cells("CLASS_ID").Value)

                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If

                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value
                .gsDiscount_Rate = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsBATCH_ID = dgvProductItem.Rows(I).Cells("BATCH_ID").Value

            End With
            frmAddItem.ShowDialog()
            With frmAddItem
                If .gsSave = True Then
                    fRow_Data_Item_Bill_Credit(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsSelection_ID, .gsBATCH_ID)

                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
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

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub fEditExpense()
        If dgvExpenses.Rows.Count = 0 Then
            Exit Sub
        End If



        Dim i As Integer = dgvExpenses.CurrentRow.Index
        Dim dr As DataGridViewRow = dgvExpenses.Rows(i)

        With frmAddExpenses
            .gsAccount_ID = dr.Cells("account_id").Value
            .gsAmount = dr.Cells("amount").Value
            .gsClass_ID = dr.Cells("class_Id").Value
            .gsParticular = dr.Cells("particular").Value
            .gsTax = dr.Cells("Tax").Value
            .ShowDialog()
            If .gsSave = True Then
                Dim C_STATUS As String
                If fNumisNULL(dr.Cells("ID").Value) = 0 Then
                    C_STATUS = "A"
                Else
                    C_STATUS = "E"
                End If


                fRow_Data_Expenses(False, .gsAccount_ID, .gsAmount, .gsTax, .gsParticular, .gsClass_ID, C_STATUS)
            End If
            .Dispose()

        End With
        frmAddExpenses = Nothing
        fComputed()
    End Sub
    Private Sub fRow_Data_Expenses(ByVal pradd As Boolean, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prTax As Boolean, ByVal prParticular As String, ByVal prClass_ID As String, ByVal prControl_Status As String)
        Dim sAccount_Name As String = fGetFieldValue("account", "ID", prAccount_ID, "NAME")
        Dim sclass_name As String = fGetFieldValue("class", "ID", prClass_ID, "NAME")
        Dim taxable_amount As Double = 0
        Dim tax_amount As Double = 0
        If pradd = True Then
            dgvExpenses.Rows.Add("N", sAccount_Name, Format(prAmount, "Standard"), prTax, taxable_amount, tax_amount, prParticular, sclass_name, prClass_ID, prControl_Status, prAccount_ID)
        Else
            With dgvExpenses.Rows(dgvExpenses.CurrentRow.Index)
                .Cells("Account").Value = sAccount_Name
                .Cells("Amount").Value = Format(prAmount, "Standard")
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
    Private Sub dgvExpenses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellDoubleClick
        fEditExpense()
    End Sub
    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Vendor")
            Exit Sub
        End If

        If fNumisNULL(cmbACCOUNTS_PAYABLE_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select account payable")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            If dgvExpenses.Rows.Count = 0 Then
                fMessageboxInfo("No items or Expenses enter")
                Exit Sub
            End If
        End If


        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("bill_credit", cmbLOCATION_ID.SelectedValue)
            End If


            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("bill_credit")
            squery = squery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='2'"
            squery = fNullOTherField(squery, "BILL_CREDIT")
            fExecutedOnly("INSERT INTO bill_credit SET " & squery & ";")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbVENDOR_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            'bill_credit_bills / Returns
            If fNumFieldValue("bill_credit_bills", "bill_credit_id", gsID, "id") <> 0 Then
                If gsAdmin_User = False Then
                    fMessageboxWarning("Invalid update bill credit already applied refund.")
                    Exit Sub
                Else
                    If fMessageboxWarningYesNo("Invalid update bill credit already applied refund. do you want to proceed?") = False Then
                        Exit Sub
                    End If
                End If
            End If



            tChangeAccept = True
            If gsSkipJournalEntry = False  Then
                fGotChangeTransaction("bill_credit", gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)

                If gsGotChangeDate = True Then
                    fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 59, gsID, gsLast_Location_ID, gsLast_Date)
                    fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(lblINPUT_TAX_ACCOUNT_ID.Text), 59, gsID, gsLast_Location_ID, gsLast_Date)
                End If

                If gsGotChangeLocation1 = True Then
                    fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 59, gsID, dtpDATE.Value, gsLast_Location_ID)
                    fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(lblINPUT_TAX_ACCOUNT_ID.Text), 59, gsID, dtpDATE.Value, gsLast_Location_ID)
                End If
            End If



            Dim squery As String = fFieldCollector(Me)
            squery = squery & " WHERE ID = '" & gsID & "' limit 1;"
            fExecutedOnly("UPDATE bill_credit SET " & squery)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbVENDOR_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            fAccount_Journal_SQL(cmbACCOUNTS_PAYABLE_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 59, gsID, dtpDATE.Value, 0, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            If fNumisNULL(lblINPUT_TAX_AMOUNT.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblINPUT_TAX_ACCOUNT_ID.Text), 59, gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 59, gsID, dtpDATE.Value, 1, fNumisNULL(lblINPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If
        End If


        fSaveItem()  '60 Save item
        fSaveExpenses() ' 80



        If fTransactionCheck(gsID, "BILL_CREDIT") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If

        fItemStatusUpdate()
        fExpensesStatusUpdate()

        gsGotChangeDate = False
        gsGotChangeLocation1 = False


        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            End If
        Catch ex As Exception

        Finally
            If gsID <> "" Then
                gsNew = False
                fRefreshField()
                fRefreshItem()
                fRefreshExpense()
            End If
        End Try


    End Sub
    Private Sub fInventorySetUpdate()
        For I As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(I)
                fUpdateItemInventory_AccountJournalCost(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ID").Value, 3, 60)
            End With
        Next
    End Sub

    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        dgvExpenses.Rows.Clear()
        fComputed()
        gsID = ""
        gsNew = True

    End Sub
    Private Sub fSaveItem()


        If dgvProductItem.Rows.Count <> 0 Then

            For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                With dgvProductItem.Rows(i)
                    Select Case .Cells("CONTROL_STATUS").Value
                        Case "S"
                            'UPDATE TAX ONLY
                            fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            fExecutedOnly("UPDATE bill_credit_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE BILL_CREDIT_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & ";")

                            If gsSkipJournalEntry = False Then

                                If gsGotChangeDate = True Then
                                    fAccount_journal_Change_date(dtpDATE.Value, .Cells("ACCOUNT_ID").Value, 60, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                End If
                                If gsGotChangeLocation1 = True Then
                                    fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, .Cells("ACCOUNT_ID").Value, 60, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                End If
                            End If
                            If gsGotChangeDate = True Then
                                fItem_inventory_change_date(dtpDATE.Value, .Cells("ITEM_ID").Value, 3, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If
                            If gsGotChangeLocation1 = True Then
                                fItem_inventory_change_Location(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 3, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        Case "A"
                            fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            Dim i_ID As Double = fObjectTypeMap_ID("BILL_CREDIT_ITEMS")
                            fExecutedOnly("INSERT INTO bill_credit_items SET BATCH_ID =" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",BILL_CREDIT_ID ='" & gsID & "',ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ACCOUNT_ID").Value)) & ",CLASS_ID=" & fGotNullNumber(fNumisNULL(.Cells("CLASS_ID").Value)) & ";")
                            .Cells("ID").Value = i_ID
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        Case "E"
                            fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            fExecutedOnly("UPDATE bill_credit_items SET BATCH_ID =" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",CLASS_ID=" & fGotNullNumber(fNumisNULL(.Cells("CLASS_ID").Value)) & " WHERE BILL_CREDIT_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        Case "D"
                            fExecutedOnly("DELETE FROM bill_credit_items WHERE BILL_CREDIT_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;")
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    End Select
                End With
            Next

        End If

    End Sub

    Private Sub fItemStatusUpdate()

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                If .Cells("CONTROL_STATUS").Value = "D" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    If Date.Now.Date <> dtpDATE.Value Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    End If
                    .Cells("CONTROL_STATUS").Value = "S"
                End If
            End With
        Next
    End Sub
    Private Sub fSaveExpenses()

        If dgvExpenses.Rows.Count <> 0 Then




            For i As Integer = 0 To dgvExpenses.Rows.Count - 1
                With dgvExpenses.Rows(i)


                    Select Case .Cells("CONTROL_STATUS").Value

                        Case "S"
                            'UPDATE TAX
                            fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvExpenses.Rows(i))

                            fExecutedOnly("UPDATE bill_credit_expenses SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE BILL_CREDIT_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")


                            If gsSkipJournalEntry = False Then
                                If gsGotChangeDate = True Then
                                    fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(.Cells("Account_ID").Value), 80, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                End If
                                If gsGotChangeLocation1 = True Then
                                    fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("Account_ID").Value), 80, fNumisNULL(.Cells("ID").Value), gsLast_Date, gsLast_Location_ID)
                                End If

                                Dim E As Integer
                                If fNumisNULL(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 1
                                Else
                                    E = 0
                                End If

                                Dim AMT As Double
                                If fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = fNumisNULL(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = fNumisNULL(.Cells("AMOUNT").Value)
                                End If
                                fAccount_Journal_SQL(fNumisNULL(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                            End If
                        Case "A"
                            fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvExpenses.Rows(i))
                            Dim i_ID As Double = fObjectTypeMap_ID("BILL_CREDIT_EXPENSES")
                            fExecutedOnly("INSERT INTO bill_credit_expenses SET LINE_NO='" & i & "',ID='" & i_ID & "',AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',BILL_CREDIT_ID ='" & gsID & "',ACCOUNT_ID='" & fNumisNULL(.Cells("Account_ID").Value) & "',PARTICULARS='" & fTextisNULL(.Cells("Particular").Value) & "',CLASS_ID=" & fGotNullNumber(fNumisNULL(.Cells("CLASS_ID").Value)) & ";")

                            .Cells("ID").Value = i_ID
                            .Cells("CONTROL_STATUS").Value = "S"
                            If gsSkipJournalEntry = False Then
                                Dim E As Integer
                                If fNumisNULL(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 1
                                Else
                                    E = 0
                                End If
                                Dim AMT As Double
                                If fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = fNumisNULL(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = fNumisNULL(.Cells("AMOUNT").Value)
                                End If
                                fAccount_Journal_SQL(fNumisNULL(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                            End If

                        Case "E"

                            fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvExpenses.Rows(i))

                            fExecutedOnly("UPDATE bill_credit_expenses SET LINE_NO='" & i & "',PARTICULARS='" & fTextisNULL(.Cells("Particular").Value) & "',ACCOUNT_ID='" & fNumisNULL(.Cells("Account_ID").Value) & "',AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',CLASS_ID=" & fGotNullNumber(fNumisNULL(.Cells("CLASS_ID").Value)) & " WHERE BILL_CREDIT_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")
                            If gsSkipJournalEntry = False Then
                                Dim E As Integer
                                If fNumisNULL(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 1
                                Else
                                    E = 0
                                End If
                                Dim AMT As Double
                                If fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = fNumisNULL(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = fNumisNULL(.Cells("AMOUNT").Value)
                                End If
                                fAccount_Journal_SQL(fNumisNULL(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                            End If
                        Case "D"
                            fExecutedOnly("DELETE FROM bill_credit_expenses WHERE BILL_CREDIT_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;")
                            If gsSkipJournalEntry = False Then
                                fAccount_journal_Delete(fNumisNULL(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value)
                            End If

                    End Select
                End With
            Next

        End If


    End Sub
    Private Sub fExpensesStatusUpdate()
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
    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If
            Try
                If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                    Exit Sub
                End If


                If fMessageBoxQuestion(gsMessageQuestion) = True Then
                    fCursorLoadingOn(True)
                    '  
                    Try

                        Dim rd As OdbcDataReader = fReader("select BILL_ID from BILL_CREDIT_BILLS where bill_CREDIT_ID = '" & gsID & "'")
                        While rd.Read

                            Dim prORG_Amount As Double = fNumFieldValue("BILL", "ID", rd("BILL_ID"), "AMOUNT")

                            Dim total_pay As Double = fGetCreditOtherBill(gsID, rd("BILL_ID")) + fBillSumTaxApplied_Amount(rd("BILL_ID"), cmbVENDOR_ID.SelectedValue) + fBillSumPaymentApplied(rd("BILL_ID"), cmbVENDOR_ID.SelectedValue)

                            Dim New_Balance As Double = prORG_Amount - total_pay

                            Dim nStatus As Integer = 0

                            If prORG_Amount <= total_pay Then
                                nStatus = 11 ' paid
                            Else
                                nStatus = 13 'unpaid
                            End If

                            fExecutedOnly("UPDATE bill SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & rd("BILL_ID") & "'")


                        End While
                        rd.Close()
                    Catch ex As Exception

                        fMessageboxExclamation(ex.Message)
                        Exit Sub
                    End Try


                    ''Remove list 
                    'fJournalTransaction_Bill_Credit_Delete(gsID)

                    ''Inventory re-Compute
                    'fDeleteItem_INVENTORY_ITEM_RECALCULATE(dgvProductItem, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    ''End re-compute
                    For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                        With dgvProductItem.Rows(N)
                            .Cells("CONTROL_STATUS").Value = "D"
                        End With
                    Next

                    fSaveItem()

                    For N As Integer = 0 To dgvExpenses.Rows.Count - 1
                        With dgvProductItem.Rows(N)
                            .Cells("CONTROL_STATUS").Value = "D"
                        End With
                    Next

                    fSaveExpenses()
                    '===========================================
                    If gsSkipJournalEntry = False Then
                        gsJOURNAL_NO_FORM = 0

                        fAccount_journal_Delete(cmbACCOUNTS_PAYABLE_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 59, gsID, dtpDATE.Value)
                        If fNumisNULL(lblINPUT_TAX_AMOUNT.Text) <> 0 Then
                            fAccount_journal_Delete(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 59, gsID, dtpDATE.Value)
                        End If


                    End If



                    fExecutedOnly("delete from bill_credit_bills where bill_CREDIT_ID ='" & gsID & "'")
                    fExecutedOnly("delete from bill_credit_items where bill_CREDIT_ID ='" & gsID & "'")
                    fExecutedOnly("delete from bill_credit_expenses where bill_CREDIT_ID ='" & gsID & "'")
                    fExecutedOnly("delete from bill_credit where ID ='" & gsID & "' limit 1;")
                    fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                    fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbVENDOR_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                    fclear_Info()
                    dgvProductItem.Rows.Clear()
                    dgvExpenses.Rows.Clear()
                    fComputed()
                    gsID = ""
                    gsNew = True
                    fCursorLoadingOn(False)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If
    End Sub

    Private Sub frmBillCredit_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmBillCredit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fdgvItemDisplay(dgvProductItem)
        fdgvExpensesDisplay(dgvExpenses)

        fDgvNotSort(dgvProductItem)
        fDgvNotSort(dgvExpenses)

    End Sub



    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)

        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")

            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            fPreviewReport(prPrint_Title)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If gsNew = True Then
            tsSaveNew_Click(sender, e)

        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If

    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If gsNew = True Then Exit Sub
        If fACCESS_PRINT_PREVIEW(Me) = False Then
            Exit Sub
        End If
        frmPrintPage.frmName = Me.Name
        frmPrintPage.ShowDialog()
        Application.DoEvents()
        Dim v As Integer = frmPrintPage.prValue
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
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                fPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing

    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 59, 21, cmbVENDOR_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
            fclear_Info()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then

                fRefreshField()
                fRefreshItem()
                fRefreshExpense()

                If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                    TabControl1.SelectedTab = TabPage1
                Else
                    TabControl1.SelectedTab = TabPage2
                End If
                fComputed()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub txtNOTES_TextChanged(sender As Object, e As EventArgs) Handles txtNOTES.TextChanged

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub dgvExpenses_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvExpenses.RowsAdded
        If bRefreshExpenses = False Then
            fComputed()
        End If
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub
    Private Sub fApplytoBill()


    End Sub
    Private Sub cmbVENDOR_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVENDOR_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbVENDOR_ID.Text)
            If cmbVENDOR_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If gsNew = True Then
                    If fACCESS_NEW_EDIT(frmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/vendor.png")

                    frmContactDetails.gsContact_Type = "0"
                    frmContactDetails.txtNAME.Text = StrText ' must auto insert
                    frmContactDetails.txtCOMPANY_NAME.Text = StrText
                    frmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    frmContactDetails.bNew = True
                    frmContactDetails.gsID = ""
                    frmContactDetails.gsDgv = Nothing
                    frmContactDetails.this_BS = Nothing
                    frmContactDetails.ShowDialog()
                    If frmContactDetails.gsOK = True Then
                        fComboBox(cmbVENDOR_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbVENDOR_ID.SelectedValue = frmContactDetails.gsID
                        cmbVENDOR_ID_LostFocus(sender, e)
                    End If
                    frmContactDetails.Dispose()
                    frmContactDetails = Nothing
                End If

            End If
        End If
    End Sub
    Private Sub cmbVENDOR_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbVENDOR_ID.LostFocus
        VendorTax()
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
        If gsNew = False Then Exit Sub
        If cmbVENDOR_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = fReader($"select * from contact where id ='{s}' and `type` = '0' limit 1 ")
        If rd.Read Then
            If fNumisNULL(rd("TAX_ID")) <> 0 Then
                cmbINPUT_TAX_ID.SelectedValue = fNumisNULL(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub


    Private Sub frmBillCredit_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If gsNew = False Then
            fRefreshField()
            fRefreshItem()
            fRefreshExpense()

            If dgvProductItem.Rows.Count > dgvExpenses.Rows.Count Then
                TabControl1.SelectedTab = TabPage1
            Else
                TabControl1.SelectedTab = TabPage2
            End If
        End If
        fDatagridViewMode(dgvProductItem)
        fDatagridViewMode(dgvExpenses)
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select vendor")
            Exit Sub
        End If

        With frmAddItem
            .gsUseItemBatch = True
            .sFormName = Me.Name
            .gsCOST_AMOUNT_ONLY = True
            .dgv = dgvProductItem
            .gsDate = dtpDATE.Value
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsSelection = True
            .gsSelection_Query = "select * from class"
            .gsSelection_Label = "Class"
            .gsSelection_DESCRIPTION = "NAME"
            .gsSelection_VALUE = "ID"
            .gsSelection_ID = ""
            .ShowDialog()


        End With
        fComputed()
        frmAddItem.Dispose()
        frmAddItem = Nothing
    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvProductItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvProductItem.CurrentRow.Index

                If fNumisNULL(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                    dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvProductItem.Rows(i).Visible = False

                Else
                    dgvProductItem.Rows.RemoveAt(i)
                End If
                '  fDiscount_ReComputed(dgvProductItem)
                fComputed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsAddExpenses_Click(sender As Object, e As EventArgs) Handles tsAddExpenses.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select vendor")
            Exit Sub
        End If


        With frmAddExpenses
            .gsNew = True
            .gsDGV = dgvExpenses
            .ShowDialog()
            .Dispose()
        End With
        frmAddExpenses = Nothing
        fComputed()
    End Sub

    Private Sub tsEditExpenses_Click(sender As Object, e As EventArgs) Handles tsEditExpenses.Click
        fEditExpense()
    End Sub

    Private Sub tsRemoveExpenses_Click(sender As Object, e As EventArgs) Handles tsRemoveExpenses.Click
        Try
            If dgvExpenses.Rows.Count <> 0 Then
                Dim i As Integer = dgvExpenses.CurrentRow.Index

                If fNumisNULL(dgvExpenses.Rows(i).Cells(0).Value) <> 0 Then
                    dgvExpenses.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvExpenses.Rows(i).Visible = False
                Else
                    dgvExpenses.Rows.RemoveAt(i)
                End If
                fComputed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToBillsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LblINPUT_TAX_AMOUNT_Click(sender As Object, e As EventArgs) Handles lblINPUT_TAX_AMOUNT.Click

    End Sub

    Private Sub LblAMOUNT_Click(sender As Object, e As EventArgs) Handles lblAMOUNT.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub TsFindText2_Click(sender As Object, e As EventArgs) Handles tsFindText2.Click

    End Sub

    Private Sub tsFindText2_TextChanged(sender As Object, e As EventArgs) Handles tsFindText2.TextChanged
        fGetQuickFind(dgvExpenses, tsFindText2.Text)
    End Sub

    Private Sub tsApplyCredits_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub ToCreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCreditsToolStripMenuItem.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
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

            With frmBillCreditBills
                .gsLocation_ID = cmbLOCATION_ID.SelectedValue
                .gsVendor_ID = cmbVENDOR_ID.SelectedValue

                .gsID = gsID
                .lblName.Text = cmbVENDOR_ID.Text
                .lblDATE.Text = dtpDATE.Value
                .lblCreditAmount.Text = lblAMOUNT.Text
                .lblCODE.Text = txtCODE.Text
                .ShowDialog()
                If .gsOk = True Then
                    fComputed()
                    If gsNew = True Then
                        tsSaveNew_Click(sender, e)
                    End If
                End If
                .Dispose()
            End With
            frmBillCreditBills = Nothing
        End If
    End Sub

End Class