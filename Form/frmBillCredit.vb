Imports System.Data.Odbc
Public Class FrmBillCredit
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
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub DgvExpenses_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvExpenses.RowStateChanged
        lblCount2.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Function IsCheckHasChange() As Boolean
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
    Private Sub FrmBillCredit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        End If

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
  bill_credit_expenses AS bs 
  LEFT OUTER JOIN account AS a 
    ON a.`ID` = bs.`ACCOUNT_ID`
    LEFT OUTER JOIN class AS c
    ON c.`ID` = bs.`CLASS_ID`
    WHERE bs.`Bill_CREDIT_ID` ='" & ID & "' ORDER by bs.`LINE_NO`"


        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvExpenses.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvExpenses.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = NumberFormatStandard(NumIsNull(rd(i)))
                        ElseIf CheckNumNoDecimal(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = NumberFormatNoDecimal(NumIsNull(rd(i)))
                        ElseIf CheckBoolType(.Name) = True Then
                            dgvExpenses.Rows(x).Cells(i).Value = CBool(NumIsNull(rd(i)))
                        Else
                            dgvExpenses.Rows(x).Cells(i).Value = TextIsNull(rd(i))
                        End If
                    End With

                Next
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            RefreshExpense()
        Finally
            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tdgvE = New DataGridView
            tdgvE = dgvExpenses
            tQuery = SqlUpdate(Me)

        End Try
        bRefreshExpenses = False
    End Sub
    Private Sub RefreshItem()

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

    WHERE  ii.`Bill_CREDIT_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

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
            Computed()
        End Try




        bRefreshItem = False


    End Sub
    Private Sub RefreshField()
        Try
            Dim sQuery As String = "select * from bill_credit where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)

            cmbACCOUNTS_PAYABLE_ID.Enabled = False
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshField()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub RefreshCombo()
        ComboBoxLoad(cmbVENDOR_ID, "select * from contact where type='0' ", "ID", "NAME")
        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbINPUT_TAX_ID, "select * from tax where tax_type = '3' order by ID DESC", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")

    End Sub

    Private Sub ClearInfo()
        RefreshCombo()
        ClearAndRefresh(Me)

        dgvProductItem.Rows.Clear()
        dgvExpenses.Rows.Clear()
        dgvProductItem.Rows.Clear()
        If Val(gsDefault_Vendor_ID) <> 0 Then
            cmbVENDOR_ID.SelectedValue = gsDefault_Vendor_ID
            cmbVENDOR_ID.Enabled = False


        End If

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
        cmbINPUT_TAX_ID.SelectedValue = GetInPutTaxDefault()
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID
    End Sub
    Private Sub ColumnGrid()
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
    Private Sub Computed()


        lblCount.Text = DataGridViewCounting(dgvProductItem)
        lblCount2.Text = DataGridViewCounting(dgvExpenses)

        fBill_Vendor_Computation(dgvProductItem, dgvExpenses, cmbINPUT_TAX_ID, lblINPUT_TAX_AMOUNT, lblAMOUNT, lblINPUT_TAX_RATE, lbsTotal_Amount_Item, lbsTotal_Amount_Expense)

        Dim dPayment_applied As Double = fBillCreditApplied_Amount(ID, cmbVENDOR_ID.SelectedValue)
        lblAMOUNT_APPLIED.Text = NumberFormatStandard(dPayment_applied)
        Dim dBalance As Double = NumIsNull(NumberFormatFixed(lblAMOUNT.Text)) - dPayment_applied
        lbsCredits.Text = NumberFormatStandard(dBalance)



    End Sub

    Private Sub CmbINPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINPUT_TAX_ID.SelectedIndexChanged
        Computed()
        Try

            Dim rd As OdbcDataReader = SqlReader("Select VAT_METHOD , ASSET_ACCOUNT_ID from tax where ID ='" & NumIsNull(cmbINPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblINPUT_TAX_VAT_METHOD.Text = TextIsNull(rd("VAT_METHOD"))
                lblINPUT_TAX_ACCOUNT_ID.Text = TextIsNull(rd("ASSET_ACCOUNT_ID"))
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

    Private Sub TsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
            Exit Sub

        Else
            If IsNew = False And ID > 0 Then
                If IsCheckHasChange() = True Then
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

        f.AccessibleName = "bill_credit"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                ClearInfo()
                ID = f.AccessibleDescription
                IsNew = False

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
                .gsSelection_ID = TextIsNull(dgvProductItem.Rows.Item(I).Cells("CLASS_ID").Value)

                If NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
            FrmAddItem.ShowDialog()
            With FrmAddItem
                If .gsSave = True Then
                    fRow_Data_Item_Bill_Credit(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsSelection_ID, .gsBATCH_ID)

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
            fTax_Value(dgvProductItem)
            Computed()
        End If
    End Sub
    Private Sub DgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
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
                If NumIsNull(dr.Cells("ID").Value) = 0 Then
                    C_STATUS = "A"
                Else
                    C_STATUS = "E"
                End If


                Row_Data_Expenses(False, .gsAccount_ID, .gsAmount, .gsTax, .gsParticular, .gsClass_ID, C_STATUS)
            End If
            .Dispose()

        End With
        FrmAddExpenses = Nothing
        Computed()
    End Sub
    Private Sub Row_Data_Expenses(ByVal pradd As Boolean, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prTax As Boolean, ByVal prParticular As String, ByVal prClass_ID As String, ByVal prControl_Status As String)
        Dim sAccount_Name As String = GetStringFieldValue("account", "ID", prAccount_ID, "NAME")
        Dim sclass_name As String = GetStringFieldValue("class", "ID", prClass_ID, "NAME")
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
    Private Sub DgvExpenses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellDoubleClick
        EditExpense()
    End Sub
    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Vendor")
            Exit Sub
        End If

        If NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue) = 0 Then
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
                txtCODE.Text = GetNextCode("bill_credit", cmbLOCATION_ID.SelectedValue)
            End If


            dtpDATE.Checked = True

            SqlCreate(Me, SQL_Field, SQL_Value)

            ID = ObjectTypeMapId("bill_credit")
            SqlExecuted($"INSERT INTO bill_credit ({SQL_Field},ID,RECORDED_ON,STATUS) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}','2') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbVENDOR_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            'bill_credit_bills / Returns
            If GetNumberFieldValue("bill_credit_bills", "bill_credit_id", ID, "id") <> 0 Then
                If gsAdmin_User = False Then
                    MessageBoxWarning("Invalid update bill credit already applied refund.")
                    Exit Sub
                Else
                    If MessageBoxWarningYesNo("Invalid update bill credit already applied refund. do you want to proceed?") = False Then
                        Exit Sub
                    End If
                End If
            End If



            tChangeAccept = True
            If gsSkipJournalEntry = False Then
                GotChangeTransaction("bill_credit", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
                If gsGotChangeDate = True Then
                    AccountJournalChangeDate(dtpDATE.Value, NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 59, ID, gsLast_Location_ID, gsLast_Date)
                    AccountJournalChangeDate(dtpDATE.Value, NumIsNull(lblINPUT_TAX_ACCOUNT_ID.Text), 59, ID, gsLast_Location_ID, gsLast_Date)
                End If

                If gsGotChangeLocation1 = True Then
                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 59, ID, dtpDATE.Value, gsLast_Location_ID)
                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(lblINPUT_TAX_ACCOUNT_ID.Text), 59, ID, dtpDATE.Value, gsLast_Location_ID)
                End If
            End If

            Dim squery As String = SqlUpdate(Me)
            squery = squery & " WHERE ID = '" & ID & "'"
            SqlExecuted("UPDATE bill_credit SET " & squery)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbVENDOR_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            fAccount_Journal_SQL(cmbACCOUNTS_PAYABLE_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 59, ID, dtpDATE.Value, 0, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            If NumIsNull(lblINPUT_TAX_AMOUNT.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblINPUT_TAX_ACCOUNT_ID.Text), 59, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 59, ID, dtpDATE.Value, 1, NumIsNull(lblINPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If
        End If


        SaveItem()  '60 Save item
        SaveExpenses() ' 80



        If IsTransactionSuccess(ID, "BILL_CREDIT") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        ItemStatusUpdate()
        ExpensesStatusUpdate()

        gsGotChangeDate = False
        gsGotChangeLocation1 = False


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
                RefreshField()
                RefreshItem()
                RefreshExpense()
            End If
        End Try


    End Sub
    Private Sub InventorySetUpdate()
        For I As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(I)
                fUpdateItemInventory_AccountJournalCost(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ID").Value, 3, 60)
            End With
        Next
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
                            fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            SqlExecuted("UPDATE bill_credit_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE BILL_CREDIT_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & ";")

                            If gsSkipJournalEntry = False Then

                                If gsGotChangeDate = True Then
                                    AccountJournalChangeDate(dtpDATE.Value, .Cells("ACCOUNT_ID").Value, 60, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                End If
                                If gsGotChangeLocation1 = True Then
                                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ACCOUNT_ID").Value, 60, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                End If
                            End If
                            If gsGotChangeDate = True Then
                                ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 3, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If
                            If gsGotChangeLocation1 = True Then
                                ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 3, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        Case "A"
                            fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            Dim i_ID As Double = ObjectTypeMapId("BILL_CREDIT_ITEMS")
                            SqlExecuted("INSERT INTO bill_credit_items SET BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",BILL_CREDIT_ID ='" & ID & "',ACCOUNT_ID=" & GotNullNumber(NumIsNull(.Cells("ACCOUNT_ID").Value)) & ",CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & ";")
                            .Cells("ID").Value = i_ID
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        Case "E"
                            fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                            SqlExecuted("UPDATE bill_credit_items SET BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',QUANTITY='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & " WHERE BILL_CREDIT_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        Case "D"
                            SqlExecuted("DELETE FROM bill_credit_items WHERE BILL_CREDIT_ID ='" & ID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;")
                            fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, True, 60, 3, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    End Select
                End With
            Next

        End If

    End Sub

    Private Sub ItemStatusUpdate()

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                If .Cells("CONTROL_STATUS").Value = "D" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    If Date.Now.Date <> dtpDATE.Value Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    End If
                    .Cells("CONTROL_STATUS").Value = "S"
                End If
            End With
        Next
    End Sub
    Private Sub SaveExpenses()

        If dgvExpenses.Rows.Count <> 0 Then
            For i As Integer = 0 To dgvExpenses.Rows.Count - 1
                With dgvExpenses.Rows(i)
                    Select Case .Cells("CONTROL_STATUS").Value
                        Case "S"
                            'UPDATE TAX
                            fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))
                            SqlExecuted("UPDATE bill_credit_expenses SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE BILL_CREDIT_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                            If gsSkipJournalEntry = False Then
                                If gsGotChangeDate = True Then
                                    AccountJournalChangeDate(dtpDATE.Value, NumIsNull(.Cells("Account_ID").Value), 80, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                End If
                                If gsGotChangeLocation1 = True Then
                                    AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("Account_ID").Value), 80, NumIsNull(.Cells("ID").Value), gsLast_Date, gsLast_Location_ID)
                                End If

                                Dim E As Integer
                                If NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 1
                                Else
                                    E = 0
                                End If

                                Dim AMT As Double
                                If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = NumIsNull(.Cells("AMOUNT").Value)
                                End If
                                fAccount_Journal_SQL(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                            End If
                        Case "A"
                            fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))
                            Dim i_ID As Double = ObjectTypeMapId("BILL_CREDIT_EXPENSES")
                            SqlExecuted("INSERT INTO bill_credit_expenses SET LINE_NO='" & i & "',ID='" & i_ID & "',AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',BILL_CREDIT_ID ='" & ID & "',ACCOUNT_ID='" & NumIsNull(.Cells("Account_ID").Value) & "',PARTICULARS='" & TextIsNull(.Cells("Particular").Value) & "',CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & ";")

                            .Cells("ID").Value = i_ID
                            .Cells("CONTROL_STATUS").Value = "S"
                            If gsSkipJournalEntry = False Then
                                Dim E As Integer
                                If NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 1
                                Else
                                    E = 0
                                End If
                                Dim AMT As Double
                                If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = NumIsNull(.Cells("AMOUNT").Value)
                                End If
                                fAccount_Journal_SQL(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                            End If

                        Case "E"

                            fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))

                            SqlExecuted("UPDATE bill_credit_expenses SET LINE_NO='" & i & "',PARTICULARS='" & TextIsNull(.Cells("Particular").Value) & "',ACCOUNT_ID='" & NumIsNull(.Cells("Account_ID").Value) & "',AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & " WHERE BILL_CREDIT_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                            If gsSkipJournalEntry = False Then
                                Dim E As Integer
                                If NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                    E = 1
                                Else
                                    E = 0
                                End If
                                Dim AMT As Double
                                If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                    AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                                Else
                                    AMT = NumIsNull(.Cells("AMOUNT").Value)
                                End If
                                fAccount_Journal_SQL(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbVENDOR_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                            End If
                        Case "D"
                            SqlExecuted("DELETE FROM bill_credit_expenses WHERE BILL_CREDIT_ID ='" & ID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;")
                            If gsSkipJournalEntry = False Then
                                fAccount_journal_Delete(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, 80, .Cells("ID").Value, dtpDATE.Value)
                            End If

                    End Select
                End With
            Next

        End If


    End Sub
    Private Sub ExpensesStatusUpdate()
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
    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If
            Try
                If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                    Exit Sub
                End If


                If MessageBoxQuestion(gsMessageQuestion) = True Then
                    CursorLoadingOn(True)
                    '  
                    Try

                        Dim rd As OdbcDataReader = SqlReader("select BILL_ID from BILL_CREDIT_BILLS where bill_CREDIT_ID = '" & ID & "'")
                        While rd.Read

                            Dim prORG_Amount As Double = GetNumberFieldValue("BILL", "ID", rd("BILL_ID"), "AMOUNT")

                            Dim total_pay As Double = fGetCreditOtherBill(ID, rd("BILL_ID")) + GetBillSumTaxAppliedAmount(rd("BILL_ID"), cmbVENDOR_ID.SelectedValue) + GetBillSumPaymentApplied(rd("BILL_ID"), cmbVENDOR_ID.SelectedValue)

                            Dim New_Balance As Double = prORG_Amount - total_pay

                            Dim nStatus As Integer = 0

                            If prORG_Amount <= total_pay Then
                                nStatus = 11 ' paid
                            Else
                                nStatus = 13 'unpaid
                            End If

                            SqlExecuted("UPDATE bill SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & rd("BILL_ID") & "'")


                        End While
                        rd.Close()
                    Catch ex As Exception

                        MessageBoxExclamation(ex.Message)
                        Exit Sub
                    End Try


                    ''Remove list 
                    'fJournalTransaction_Bill_Credit_Delete(ID)

                    ''Inventory re-Compute
                    'fDeleteItem_INVENTORY_ITEM_RECALCULATE(dgvProductItem, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    ''End re-compute
                    For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                        With dgvProductItem.Rows(N)
                            .Cells("CONTROL_STATUS").Value = "D"
                        End With
                    Next

                    SaveItem()

                    For N As Integer = 0 To dgvExpenses.Rows.Count - 1
                        With dgvProductItem.Rows(N)
                            .Cells("CONTROL_STATUS").Value = "D"
                        End With
                    Next

                    SaveExpenses()
                    '===========================================
                    If gsSkipJournalEntry = False Then
                        gsJOURNAL_NO_FORM = 0

                        fAccount_journal_Delete(cmbACCOUNTS_PAYABLE_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 59, ID, dtpDATE.Value)
                        If NumIsNull(lblINPUT_TAX_AMOUNT.Text) <> 0 Then
                            fAccount_journal_Delete(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 59, ID, dtpDATE.Value)
                        End If


                    End If



                    SqlExecuted("delete from bill_credit_bills where bill_CREDIT_ID ='" & ID & "'")
                    SqlExecuted("delete from bill_credit_items where bill_CREDIT_ID ='" & ID & "'")
                    SqlExecuted("delete from bill_credit_expenses where bill_CREDIT_ID ='" & ID & "'")
                    SqlExecuted("delete from bill_credit where ID ='" & ID & "' limit 1;")
                    PrompNotify(Me.Text, DeleteMsg, True)
                    SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbVENDOR_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                    ClearInfo()
                    dgvProductItem.Rows.Clear()
                    dgvExpenses.Rows.Clear()
                    Computed()
                    ID = 0
                    IsNew = True
                    CursorLoadingOn(False)
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If
    End Sub
    Private Sub FrmBillCredit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewItemDisplay(dgvProductItem)
        ViewExpensesDisplay(dgvExpenses)

        ViewNotSort(dgvProductItem)
        ViewNotSort(dgvExpenses)

    End Sub
    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)

        Else
            If IsCheckHasChange() = True Then
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
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        If IsNew = True Then
            TsSaveNew_Click(sender, e)

        Else
            If IsCheckHasChange() = True Then
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

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If IsCheckHasChange() = True Then
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

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If IsCheckHasChange() = True Then
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
            fTransactionJournal(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 59, 21, cmbVENDOR_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If

    End Sub

    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            ClearInfo()
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

    Private Sub DgvExpenses_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvExpenses.RowsAdded
        If bRefreshExpenses = False Then
            Computed()
        End If
    End Sub
    Private Sub CmbVENDOR_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVENDOR_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbVENDOR_ID.Text)
            If cmbVENDOR_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If SecurityAccessMode(FrmCustomer, True) = False Then
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
                        ComboBoxLoad(cmbVENDOR_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbVENDOR_ID.SelectedValue = FrmContactDetails.ID
                        CmbVENDOR_ID_LostFocus(sender, e)
                    End If
                    FrmContactDetails.Dispose()
                    FrmContactDetails = Nothing
                End If

            End If
        End If
    End Sub
    Private Sub CmbVENDOR_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbVENDOR_ID.LostFocus
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
        If IsNew = False Then Exit Sub
        If cmbVENDOR_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from contact where id ='{s}' and `type` = '0' limit 1 ")
        If rd.Read Then
            If NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbINPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub
    Private Sub FrmBillCredit_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
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
        End If
        DatagridViewMode(dgvProductItem)
        DatagridViewMode(dgvExpenses)
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select vendor")
            Exit Sub
        End If

        With FrmAddItem
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
                If NumIsNull(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                    dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvProductItem.Rows(i).Visible = False
                Else
                    dgvProductItem.Rows.RemoveAt(i)
                End If

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

                If NumIsNull(dgvExpenses.Rows(i).Cells(0).Value) <> 0 Then
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

    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub TsFindText2_Click(sender As Object, e As EventArgs) Handles tsFindText2.Click

    End Sub

    Private Sub TsFindText2_TextChanged(sender As Object, e As EventArgs) Handles tsFindText2.TextChanged
        GetQuickFind(dgvExpenses, tsFindText2.Text)
    End Sub
    Private Sub ToCreditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToCreditsToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If IsCheckHasChange() = True Then
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
            With FrmBillCreditBills
                .gsLocation_ID = cmbLOCATION_ID.SelectedValue
                .gsVendor_ID = cmbVENDOR_ID.SelectedValue
                .gsID = ID
                .lblName.Text = cmbVENDOR_ID.Text
                .lblDATE.Text = dtpDATE.Value
                .lblCreditAmount.Text = lblAMOUNT.Text
                .lblCODE.Text = txtCODE.Text
                .ShowDialog()
                If .gsOk = True Then
                    Computed()
                    If IsNew = True Then
                        TsSaveNew_Click(sender, e)
                    End If
                End If
                .Dispose()
            End With
            FrmBillCreditBills = Nothing
        End If
    End Sub

End Class