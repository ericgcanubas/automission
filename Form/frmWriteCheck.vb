Imports System.Data.Odbc
Public Class frmWriteCheck
    Dim f As Form = New frmFindDocument
    Public ID As String = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim bRefreshExpenses As Boolean = False
    Dim tdgv As DataGridView
    Dim tdgvE As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False



    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
        If Val(lblCount.Text) = 0 And Val(lblCount2.Text) = 0 Then
            cmbPAY_TO_ID.Enabled = True
        Else
            cmbPAY_TO_ID.Enabled = False
        End If
    End Sub
    Private Sub dgvExpenses_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvExpenses.RowStateChanged
        lblCount2.Text = DirectCast(sender, DataGridView).Rows.Count
        If Val(lblCount.Text) = 0 And Val(lblCount2.Text) = 0 Then
            cmbPAY_TO_ID.Enabled = True
        Else
            cmbPAY_TO_ID.Enabled = False
        End If
    End Sub
    Private Function fCheckHasChange() As Boolean
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

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub
    Private Sub fClear_Info()
        fComboBoxRefresh()
        ClearAndRefresh(Me)

        dgvProductItem.Rows.Clear()
        dgvExpenses.Rows.Clear()
        fComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbINPUT_TAX_ID.SelectedValue = fInPutTaxDefault()
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID

    End Sub

    Private Sub fComboBoxRefresh()

        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        ComboBoxLoad(cmbBANK_ACCOUNT_ID, "SELECT a.ID,a.`NAME` AS `BANK`  FROM account AS a WHERE a.`type` IN ('0', '6')", "ID", "BANK")
        'ComboBoxLoad(cmbPAY_TO_ID, "SELECT c.`ID`, CONCAT(c.`NAME`,' / ',ctm.`DESCRIPTION` ) AS `PAY_TO` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE  c.TYPE = '0' and  c.`INACTIVE` ='0' ORDER BY c.`TYPE`", "ID", "PAY_TO")
        ComboBoxLoad(cmbPAY_TO_ID, "SELECT c.`ID`, c.`NAME` AS `PAY_TO` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE c.`INACTIVE` ='0' ORDER BY c.TYPE,c.NAME ", "ID", "PAY_TO")
        ComboBoxLoad(cmbINPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")

    End Sub
    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmWriteCheck_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '    fBackGroundImageStyle(Me)
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

        fClear_Info()

        DatagridViewMode(dgvProductItem)
        DatagridViewMode(dgvExpenses)



        If IsNew = False Then
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

    Private Sub fRefreshField()

        Try

            Dim sQuery As String = "select * from `check` where `Type` = '0' and id ='" & ID & "'"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshField()
            Else
                End
            End If
        End Try

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

 check_items AS ii 
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

    WHERE  ii.`Check_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0
            ' cn.Open()
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
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception

        End Try

        bRefreshItem = False
        fComputed()
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
  check_expenses AS bs 
  LEFT OUTER JOIN account AS a 
    ON a.`ID` = bs.`ACCOUNT_ID`
    LEFT OUTER JOIN class AS c
    ON c.`ID` = bs.`CLASS_ID`
    WHERE bs.`Check_ID` ='" & ID & "' ORDER by bs.`LINE_NO`"

        ' Dim cn As New MySqlConnection(mysqlConstr)
        Try
            Dim x As Integer = 0
            '    cn.Open()
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
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception

        End Try
        bRefreshExpenses = False
        fComputed()

        tdgv = New DataGridView
        tdgv = dgvProductItem
        tdgvE = New DataGridView
        tdgvE = dgvExpenses

        tQuery = SqlUpdate(Me)

    End Sub
    Private Function fgetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function

    Private Sub fComputed()


        lblCount.Text = DataGridViewCounting(dgvProductItem)
        lblCount2.Text = DataGridViewCounting(dgvExpenses)

        fBill_Vendor_Computation(dgvProductItem, dgvExpenses, cmbINPUT_TAX_ID, lblINPUT_TAX_AMOUNT, lblAMOUNT, lblINPUT_TAX_RATE, lbsTotal_Amount_Item, lbsTotal_Amount_Expense)

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

    Private Sub cmbINPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Try
            Dim rd As OdbcDataReader = SqlReader("Select VAT_METHOD,ASSET_ACCOUNT_ID from tax where ID ='" & NumIsNull(cmbINPUT_TAX_ID.SelectedValue) & "' limit 1")
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
    Private Sub fEditItem()
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

            With frmAddItem
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
            frmAddItem.ShowDialog()
            With frmAddItem
                If .gsSave = True Then
                    fRow_Data_Item_Write_Check(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsSelection_ID, .gsBATCH_ID)
                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Sub lklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub fRow_Data_Expenses(ByVal pradd As Boolean, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prTax As Boolean, ByVal prParticular As String, ByVal prClass_ID As String, ByVal prControl_Status As String)
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
    Private Sub lklNewE_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


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
                If NumIsNull(dr.Cells("ID").Value) = 0 Then
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

    Private Sub dgvExpenses_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvExpenses.CellDoubleClick
        fEditExpense()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        If Val(cmbPAY_TO_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Pay to is Required!")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            If dgvExpenses.Rows.Count = 0 Then
                MessageBoxInfo("No items or Expenses entry")
                Exit Sub
            End If
        End If
        If fACCESS_NEW_EDIT(Me, IsNew) = False Then
            Exit Sub
        End If
        If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then


            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("Check", cmbLOCATION_ID.SelectedValue)
            End If
            ID = ObjectTypeMapId("CHECK")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO `check` ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE,PRINTED,`TYPE`) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',15,'{GetDateTimeNowSql()}',0,0) ")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "New", cmbPAY_TO_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            tChangeAccept = True
            GotChangeTransaction("`CHECK`", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            SqlExecuted("UPDATE `check` SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "' and `Type`='0' ")
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbPAY_TO_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If








        If IsTransactionSuccess(ID, "`CHECK`") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If


        '===========================================
        If gsSkipJournalEntry = False Then

            If gsGotChangeDate = True Then
                'Main
                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 57, ID, gsLast_Location_ID, gsLast_Date)
                'TAX
                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(lblINPUT_TAX_ACCOUNT_ID.Text), 57, ID, gsLast_Location_ID, gsLast_Date)
            End If

            If gsGotChangeLocation1 = True Then
                'Main
                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 57, ID, dtpDATE.Value, gsLast_Location_ID)
                'TAX
                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(lblINPUT_TAX_ACCOUNT_ID.Text), 57, ID, dtpDATE.Value, gsLast_Location_ID)
            End If

            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 57, ID, dtpDATE.Value, 1, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If NumIsNull(lblINPUT_TAX_AMOUNT.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblINPUT_TAX_ACCOUNT_ID.Text), 57, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 57, ID, dtpDATE.Value, 0, NumIsNull(lblINPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================


        fSaveItem()  ' Save item
        fSaveExpenses()


        fItemUpdateStatus()
        fExpensesUpdateStatus()

        SaveNotify(Me, IsNew)

        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            Else

            End If
        Catch ex As Exception
        Finally
            If ID <> "" Then
                IsNew = False
                fRefreshField()
                fRefreshItem()
                fRefreshExpense()
            End If
        End Try

    End Sub

    Private Sub fItemUpdateStatus()

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
    Private Sub fExpensesUpdateStatus()

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
    Private Sub fInventorySetUpdate()
        For I As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(I)
                fUpdateItemInventory_AccountJournalCost(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ID").Value, 21, 75)
            End With
        Next
    End Sub
    Private Sub fSetNew()

        fClear_Info()
        dgvProductItem.Rows.Clear()
        dgvExpenses.Rows.Clear()
        fComputed()
        ID = ""
        IsNew = True

    End Sub
    Private Sub fSaveItem()



        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE check_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE CHECK_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " Limit 1;")

                        If gsSkipJournalEntry = False Then
                            If gsGotChangeDate = True Then
                                AccountJournalChangeDate(dtpDATE.Value, .Cells("ACCOUNT_ID").Value, 75, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If
                            If gsGotChangeLocation1 = True Then
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ACCOUNT_ID").Value, 75, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If
                        End If

                        If gsGotChangeDate = True Then
                            ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 21, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                        End If

                        If gsGotChangeLocation1 = True Then
                            ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 21, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                        End If


                        fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, False, 75, 21, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        '================================
                    Case "A"
                        Dim i_ID As Double = ObjectTypeMapId("CHECK_ITEMS")
                        .Cells("ID").Value = i_ID
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("INSERT INTO check_items SET BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",CHECK_ID ='" & ID & "',ACCOUNT_ID='" & .Cells("ACCOUNT_ID").Value & "',CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & ";")
                        fBILL_ITEM_COST_UPDATE_NEW(NumIsNull(.Cells("ITEM_ID").Value), NumIsNull(.Cells("UNIT_PRICE").Value))
                        fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, False, 75, 21, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)




                    Case "E"
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE check_items SET BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',QUANTITY='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & " WHERE CHECK_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, False, 75, 21, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)



                    Case "D"
                        SqlExecuted("DELETE FROM check_items WHERE CHECK_ID ='" & ID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;")
                        fINVENTORY_JOURNAL_VENDOR(dgvProductItem, i, False, 75, 21, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                End Select

            End With

        Next


    End Sub
    Private Sub fSaveExpenses()
        For i As Integer = 0 To dgvExpenses.Rows.Count - 1
            With dgvExpenses.Rows(i)


                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))

                        SqlExecuted("UPDATE check_expenses SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE CHECK_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        If gsSkipJournalEntry = False Then
                            If gsGotChangeDate = True Then
                                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(.Cells("Account_ID").Value), 79, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If
                            If gsGotChangeLocation1 = True Then
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("Account_ID").Value), 79, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If

                            Dim E As Integer
                            Dim AMT As Double
                            If NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                E = 0
                            Else
                                E = 1
                            End If
                            If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                            Else
                                AMT = NumIsNull(.Cells("AMOUNT").Value)
                            End If
                            fAccount_Journal_SQL(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 79, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                        End If
                    Case "A"
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("CHECK_EXPENSES")
                        SqlExecuted("INSERT INTO check_expenses SET LINE_NO='" & i & "',ID='" & i_ID & "',AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',CHECK_ID ='" & ID & "',ACCOUNT_ID='" & NumIsNull(.Cells("Account_ID").Value) & "',PARTICULARS='" & TextIsNull(.Cells("Particular").Value) & "',CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & ";")
                        .Cells("ID").Value = i_ID
                        If gsSkipJournalEntry = False Then
                            Dim E As Integer
                            Dim AMT As Double
                            If NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                E = 0
                            Else
                                E = 1
                            End If
                            If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                            Else
                                AMT = NumIsNull(.Cells("AMOUNT").Value)
                            End If
                            fAccount_Journal_SQL(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 79, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)

                        End If


                    Case "E"
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvExpenses.Rows(i))
                        .Cells("CONTROL_STATUS").Value = "S"
                        SqlExecuted("UPDATE check_expenses SET LINE_NO='" & i & "',PARTICULARS='" & TextIsNull(.Cells("Particular").Value) & "',ACCOUNT_ID='" & NumIsNull(.Cells("Account_ID").Value) & "',AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',CLASS_ID=" & GotNullNumber(NumIsNull(.Cells("CLASS_ID").Value)) & " WHERE CHECK_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        If gsSkipJournalEntry = False Then
                            Dim E As Integer
                            Dim AMT As Double
                            If NumIsNull(.Cells("AMOUNT").Value) >= 0 Then
                                E = 0
                            Else
                                E = 1
                            End If

                            If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                                AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                            Else
                                AMT = NumIsNull(.Cells("AMOUNT").Value)
                            End If
                            fAccount_Journal_SQL(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 79, .Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                        End If

                    Case "D"

                        SqlExecuted("DELETE FROM check_expenses WHERE CHECK_ID ='" & ID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;")
                        If gsSkipJournalEntry = False Then
                            fAccount_journal_Delete(NumIsNull(.Cells("Account_ID").Value), cmbLOCATION_ID.SelectedValue, 79, .Cells("ID").Value, dtpDATE.Value)
                        End If
                End Select
            End With
        Next

    End Sub

    Private Sub numAMOUNT_ValueChanged(sender As Object, e As EventArgs)


    End Sub

    Private Sub numAMOUNT_Leave(sender As Object, e As EventArgs)
        fComputed()
    End Sub

    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click

        If fACCESS_FIND(Me) = False Then
            Exit Sub

        Else
            If IsNew = False And ID <> "" Then
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

        f.AccessibleName = "write_check"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClear_Info()
                ID = f.AccessibleDescription
                IsNew = False
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

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If



            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)

                'End re-compute


                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next

                fSaveItem()

                For N As Integer = 0 To dgvExpenses.Rows.Count - 1
                    With dgvExpenses.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next

                fSaveExpenses()

                If gsSkipJournalEntry = False Then
                    fAccount_journal_Delete(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 57, ID, dtpDATE.Value)
                    If NumIsNull(lblINPUT_TAX_AMOUNT.Text) <> 0 Then
                        fAccount_journal_Delete(Val(lblINPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 57, ID, dtpDATE.Value)
                    End If
                End If



                SqlExecuted("DELETE FROM `check` where type ='0' and ID = '" & ID & "' LIMIT 1;")
                DeleteNotify(Me)
                fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbPAY_TO_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                ID = ""
                IsNew = True
                fClear_Info()
                CursorLoadingOn(False)
            End If
        End If
    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            fSetNew()
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

    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        fComputed()
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

    Private Sub frmWriteCheck_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmWriteCheck_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewItemDisplay(dgvProductItem)
        ViewExpensesDisplay(dgvExpenses)

        ViewNotSort(dgvProductItem)
        ViewNotSort(dgvExpenses)
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
            gsToolPanelView = False
            fPreviewReport(prPrint_Title)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'Dim prFile_name As String = "cryCashCheckVoucher.rpt"
        'Dim prPrint_Title As String = "Cash/Check Voucher"
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
        If IsNew = False Then
            fTransactionJournal(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 57, cmbBANK_ACCOUNT_ID.SelectedValue, cmbPAY_TO_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, ID)
    End Sub

    Private Sub dgvProductItem_UserAddedRow(sender As Object, e As DataGridViewRowEventArgs) Handles dgvProductItem.UserAddedRow
        If bRefreshItem = False Then
            fComputed()
        End If
    End Sub

    Private Sub dgvExpenses_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvExpenses.RowsAdded
        If bRefreshExpenses = False Then
            fComputed()
        End If
    End Sub


    Private Sub VendorTax()
        Application.DoEvents()
        Dim s As Integer
        Try
            s = cmbPAY_TO_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbPAY_TO_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbPAY_TO_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from `contact` where id ='{s}' and `type` = '0' limit 1 ")
        If rd.Read Then
            If NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbINPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub

    Private Sub cmbPAY_TO_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbPAY_TO_ID.LostFocus
        VendorTax()
        ' dgvSearch.Visible = False
        fCType()
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub



    Private Sub cmbPAY_TO_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPAY_TO_ID.KeyDown

        If e.KeyCode = Keys.Insert Then


            Dim StrText As String = Trim(cmbPAY_TO_ID.Text)
            If cmbPAY_TO_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If fACCESS_NEW_EDIT(frmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/vendor.png")

                    frmContactDetails.ContactTypeId = "0"
                    frmContactDetails.txtNAME.Text = StrText ' must auto insert
                    frmContactDetails.txtCOMPANY_NAME.Text = StrText
                    frmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    frmContactDetails.IsNew = True
                    frmContactDetails.ID = ""
                    frmContactDetails.gsDgv = Nothing
                    frmContactDetails.this_BS = Nothing
                    frmContactDetails.ShowDialog()
                    If frmContactDetails.gsOK = True Then
                        ComboBoxLoad(cmbPAY_TO_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbPAY_TO_ID.SelectedValue = frmContactDetails.ID
                        cmbPAY_TO_ID_LostFocus(sender, e)
                    End If
                    frmContactDetails.Dispose()
                    frmContactDetails = Nothing
                End If

            End If

        End If

    End Sub

    Private Sub UpdateCostSaveToolStripMenuItem_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub frmWriteCheck_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = "", True, False)

        If IsNew = False Then
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

    Private Sub SelectPagePrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPagePrintToolStripMenuItem.Click
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

        If IsNew = True Then Exit Sub

        If fACCESS_PRINT_PREVIEW(Me) = False Then
            Exit Sub
        End If

        frmPrintPage.frmName = Me.Name
        frmPrintPage.ShowDialog()

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
            fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False
                fPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles AccountLabel.Click

    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If NumIsNull(cmbBANK_ACCOUNT_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Select bank account")
            Exit Sub
        End If

        If NumIsNull(cmbPAY_TO_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Select pay to")
            Exit Sub
        End If



        With frmAddItem
            .gsUseItemBatch = True
            .gsCOST_AMOUNT_ONLY = True
            .sFormName = Me.Name
            .dgv = dgvProductItem

            .gsSelection = True
            .gsSelection_Query = "select * from class"
            .gsSelection_Label = "Class"
            .gsSelection_DESCRIPTION = "NAME"
            .gsSelection_VALUE = "ID"
            .gsSelection_ID = ""

            .gsDate = dtpDATE.Value
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue

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

                If NumIsNull(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
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
        If NumIsNull(cmbBANK_ACCOUNT_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Select bank account")
            Exit Sub
        End If

        If NumIsNull(cmbPAY_TO_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Select pay to")
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

                If NumIsNull(dgvExpenses.Rows(i).Cells(0).Value) <> 0 Then
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

    Private Sub tsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub


    Private Sub tsFindText2_TextChanged(sender As Object, e As EventArgs) Handles tsFindText2.TextChanged
        fGetQuickFind(dgvExpenses, tsFindText2.Text)
    End Sub

    Private Sub cmbBANK_ACCOUNT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBANK_ACCOUNT_ID.SelectedIndexChanged

        ' fType()
    End Sub
    'Private Sub fType()
    '    Try
    '        xlblBankType.Text = GetStringFieldValueOneReturn($"SELECT atm.description FROM account AS a inner join account_type_map as atm on  a.type = atm.id WHERE a.id = '{cmbBANK_ACCOUNT_ID.SelectedValue}' limit 1;")

    '    Catch ex As Exception
    '        xlblBankType.Text = ""
    '    End Try
    'End Sub
    Private Sub fCType()
        Try
            Dim STR As String = GetStringFieldValueOneReturn($"select ctm.description from contact as c inner join contact_type_map as ctm on ctm.id = c.type where c.id = '{cmbPAY_TO_ID.SelectedValue}' limit 1; ")
            xlblPayTo.Text = STR
        Catch ex As Exception
            xlblPayTo.Text = "Pay To"
        End Try

        If xlblPayTo.Text = "" Then
            xlblPayTo.Text = "Pay To"
        End If
    End Sub
    Private Sub cmbPAY_TO_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAY_TO_ID.SelectedIndexChanged
        fCType()
    End Sub

    Private Sub TxtCODE_TextChanged(sender As Object, e As EventArgs) Handles txtCODE.TextChanged

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class