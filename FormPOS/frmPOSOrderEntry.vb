Imports System.Data.Odbc
Public Class FrmPOSOrderEntry

    Public gsCloseCall As Boolean = False
    Dim bNewContact As Boolean = False

    Public ID As String = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim bEntryAddItem As Boolean = False
    Dim f As Form = New FrmFindDocument

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        tsCOUNT.Text = DirectCast(sender, DataGridView).Rows.Count
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
    Private Sub FrmSalesOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_Label_Digital_L(lblAMOUNT)

        GS_Label_Digital_L(xlblTOTAL)
        GS_Label_Digital_M(lblOUTPUT_TAX_AMOUNT)


        gsUserDefaulLockNegativePerUser = GF_UserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = GF_UserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsStorage_Location_ID = GetLoadStorageLocation()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        LoadDefaultAccount()

        ColumnGrid()
        ClearInfo()
        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If
        '=============================

        ClearAndRefresh(Me)

        Me.Icon = gsIcon



        pcLOGO.BackgroundImage = gsImageNameApp
        pcLOGO.BackgroundImageLayout = ImageLayout.Stretch


        'End Design
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

        Me.AccessibleName = GF_GetStringFieldValue("tblsub_menu", "form", "frmSalesOrder", "sub_id")
        gsUserDefaulLockNegativePerUser = GF_UserDefaulLockNegativePerUser()

        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        gsPOSDefaultCustomer_ID = GetSystemSettingValueByText("POSDefaultCustomerId")
        gsDefault_unit_price_level_id = GF_UserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPOS_MACHINE_ID = GF_GetPosMachineId()
        gsPOS_TYPE_ID = GF_PosMachineTypeMap()
        Me.Text = "Point of Sales : Order Entry"


        gsMainWith = Me.Width
        gsMainHeight = Me.Height
        Computed()

    End Sub
    Private Sub ClearInfo()

        RefreshComboBox()
        ClearAndRefresh(Me)
        lblCODE.Text = ""
        xlblAcctNo.Text = ""
        xlblCustomer_Name.Text = ""
        xlblSalesRep.Text = ""
        xlblTax.Text = ""

        cmbCUSTOMER_ID.Enabled = True
        dtpDATE_NEEDED.Checked = False
        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = GetPaymentTermsDefault()
        dtpDATE.Value = TransactionDefaultDate()

        ' LoadDefaultAccount()
        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
        cmbCUSTOMER_ID.SelectedValue = Val(gsPOSDefaultCustomer_ID)




    End Sub
    Private Sub RefreshInfo()


        Try

            Dim sQuery As String = "select * from sales_order where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub RefreshItem()
        dgvProductItem.Rows.Clear()
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
  ii.`ESTIMATE_LINE_ID`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`GROUP_LINE_ID`,
i.TYPE as `ITEM_TYPE`

FROM

  sales_order_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
   WHERE ii.`SALES_ORDER_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 2
                    With dgvProductItem.Columns(i)
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = GF_NumIsNull(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                            End If
                        End If
                    End With

                Next
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        Finally

            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try


    End Sub

    Private Function GetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub RefreshComboBox()
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select * from class order by `NAME`", "ID", "NAME")
        GS_ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2' order by `NAME`", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        'GS_ComboBoxLoad(cmbSHIP_VIA_ID, "select * from ship_via", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")

    End Sub
    Private Sub ColumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = "TAX",
            .Name = "TAX"
        }

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", "CODE") '1

            .Add("DESCRIPTION", "DESCRIPTION") '2

            .Add("QTY", "QTY") '3

            .Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("UM", "UNIT") '4

            .Add("UNIT_PRICE", "RATE") '5

            .Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISCOUNT_TYPE", "DISC. TYPE") '6

            .Add("DISCOUNT_RATE", "DISC. RATE") '7

            .Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("AMOUNT", "AMOUNT") '8

            .Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
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


            .Add("ESTIMATE_LINE_ID", "ESTIMATE_LINE_ID") '17
            .Item("ESTIMATE_LINE_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '18
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '19
            .Item("ITEM_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL") '20
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") '21
            .Item("ITEM_TYPE").Visible = False
            'EROOR


        End With
    End Sub
    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub


    Private Function IsDiscountNext(ByVal ndex As Integer) As Boolean
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
    Private Sub Computed()
        Dim gsSalesSubTotal As Double
        GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)

    End Sub

    Private Sub CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged

        Computed()

        Select Case GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue)
            Case 14
                xlblTax.Text = "0% Vat"
            Case 12
                xlblTax.Text = "12% Vat(I)"
            Case 13
                xlblTax.Text = "12% Vat(E)"
            Case 2
        End Select

        Try

            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = GF_TextIsNull(rd("VAT_METHOD"))
            End If
            rd.Close()
        Catch ex As Exception
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            If MessageBoxErrorYesNo(ex.Message) = True Then
                CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If
        End Try
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
            ElseIf GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With FrmAddItem
                .gsNonInventoryItem = True
                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If

                .sFormName = "frmSalesOrder"
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value
                .gsDiscount_Rate = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsPRICE_LEVEL_ID = dgvProductItem.Rows.Item(I).Cells("PRICE_LEVEL_ID").Value

                .dgv = dgvProductItem
                .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
                .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
                .gslblAMOUNT = lblAMOUNT
                .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
                .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
                .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE

                .StartPosition = FormStartPosition.Manual
                Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height - (.Height)
                .Location = New Point(405, H_PC)
                .ShowDialog()


                If .gsSave = True Then
                    GS_RowDataItemSalesOrder(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, "", .gsPRICE_LEVEL_ID, False, 0)

                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Sub DgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
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
        f.AccessibleName = "sales_order"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                ClearInfo()
                ID = f.AccessibleDescription
                IsNew = False


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
            GS_TaxValue(dgvProductItem)
            Computed()
        End If
    End Sub
    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Customer")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If

        If SecurityAccessMode(FrmSalesOrder, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then


            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = GF_GetNextCode("SALES_ORDER", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            ID = ObjectTypeMapId("sales_order")

            SqlCreate(Me, SQL_Field, SQL_Value)

            SqlExecuted($"INSERT INTO sales_order ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},{GetDateTimeNowSql()},2,{GetDateTimeNowSql()})")

            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me) & " WHERE ID = '" & ID & "' "
            SqlExecuted("UPDATE sales_order SET " & squery)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If GF_IsTransactionSuccess(ID, "sales_order") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        Else
            SaveItem()  ' Save item
        End If

        Try


            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = tsSaveNew.Name Then
                SetNew()
            End If
        Catch ex As Exception

        Finally
            If ID > 0 Then
                IsNew = False
                RefreshInfo()
                RefreshItem()
            End If

        End Try
    End Sub
    Private Sub SetNew()
        ClearInfo()
        dgvProductItem.Rows.Clear()
        Computed()
        ID = 0
        IsNew = True

    End Sub
    Private Sub EstimateItemUpdate(ByVal prITEM_ID As Double, ByVal prINVOICED_QTY As Double, ByVal ADD_EDIT As Boolean)
        If prITEM_ID = 0 Then
            Exit Sub
        End If

        Dim SO_SQL As String

        Dim get_SO_ID As String = GF_GetStringFieldValue("estimate_items", "ID", prITEM_ID, "estimate_ID")

        If ADD_EDIT = True Then
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & prITEM_ID & "' Limit 1"
        Else
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = NULL,`CLOSED` = '0' where ID = '" & prITEM_ID & "' Limit 1"
        End If
        SqlExecuted(SO_SQL)

        SqlExecuted("Update Estimate set `STATUS` = '3'  where ID = '" & get_SO_ID & "' limit 1")
    End Sub

    Private Sub SaveItem()

        If dgvProductItem.Rows.Count = 0 Then Exit Sub
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim SQL_SCRIPT As String = ""
        Dim SQL_LIST As String = ""
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)


                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX ONLY
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_ORDER_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value))
                        SqlExecuted(SQL_SCRIPT)
                    Case "A"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("SALES_ORDER_ITEMS")
                        SQL_SCRIPT = "INSERT INTO sales_order_items SET LINE_NO='" & GF_GetMaxFieldLine("LINE_NO", "SALES_ORDER_ITEMS", "SALES_ORDER_ID", ID) & "',ID='" & i_ID & "',QUANTITY ='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",SALES_ORDER_ID ='" & ID & "',CLOSED ='0',INVOICED_QTY= NULL,PRICE_LEVEL_ID = " & GotNullNumber(GF_NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",GROUP_LINE_ID = " & GotNullNumber(sGROUP_ITEM_ID)
                        SqlExecuted(SQL_SCRIPT)

                        EstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)

                        If IsGroupItem(GF_NumIsNull(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = GF_NumIsNull(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf GF_NumIsNull(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If

                    Case "E"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET QUANTITY='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE SALES_ORDER_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & ""
                        SqlExecuted(SQL_SCRIPT)
                        EstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM sales_order_items WHERE SALES_ORDER_ID ='" & ID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "'"
                        SqlExecuted(SQL_SCRIPT)
                End Select

            End With


        Next


    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If
            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If
            If MessageBoxQuestion(gsMessageQuestion) = True Then

                SqlExecuted("DELETE FROM sales_order_items WHERE SALES_ORDER_ID = '" & ID & "'")

                SqlExecuted("DELETE FROM sales_order WHERE ID = '" & ID & "'")

                SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True

            End If

        End If

    End Sub

    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If
    End Sub
    Private Sub FrmSalesOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = H_PC
        Me.Location = New Point(0, 0)


        GS_ViewItemDisplay(dgvProductItem)
        GS_ViewNotSort(dgvProductItem)
        btnDISCON.PerformClick()
    End Sub

    Private Sub CmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        If bEntryAddItem = True Then
            Exit Sub
        End If

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub

        If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        xlblCustomer_Name.Text = cmbCUSTOMER_ID.Text
        xlblAcctNo.Text = GF_GetStringFieldValue("CONTACT", "ID", GF_NumIsNull(cmbCUSTOMER_ID.SelectedValue), "ACCOUNT_NO")
        Dim rd As OdbcDataReader = SqlReader($"select TAX_ID from contact where id ='{GF_NumIsNull(cmbCUSTOMER_ID.SelectedValue)}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
            End If
        End If

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
            If SecurityAccessPrint(FrmSalesOrder) = False Then
                Exit Sub
            End If
            '   Dim prFile_name As String = "crySalesOrder.rpt"
            ' Dim prPrint_Title As String = "Sales Order"
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesOrder' and  [print_default] = '1' ", cn)
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
            If SecurityAccessPrint(FrmSalesOrder) = False Then
                Exit Sub
            End If
            '   Dim prFile_name As String = "crySalesOrder.rpt"
            '  Dim prPrint_Title As String = "Sales Order"
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesOrder' and  [print_default] = '1' ", cn)
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

    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            ClearInfo()

        Else
            If MessageBoxQuestion("Create new?") = True Then
                IsNew = True
                ID = 0
                ClearInfo()

            Else
                ClearInfo()
                RefreshInfo()
                RefreshItem()
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub
    Private Sub CmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
        CustomerTax()
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


    Private Sub CmbCUSTOMER_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCUSTOMER_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbCUSTOMER_ID.Text)
            If cmbCUSTOMER_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If SecurityAccessMode(FrmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/customer.png")

                    FrmContactDetails.ContactTypeId = "1"
                    FrmContactDetails.txtNAME.Text = StrText ' must auto insert
                    FrmContactDetails.txtCOMPANY_NAME.Text = StrText
                    FrmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    FrmContactDetails.IsNew = True
                    FrmContactDetails.ID = 0
                    FrmContactDetails.gsDgv = Nothing
                    FrmContactDetails.this_BS = Nothing
                    FrmContactDetails.ShowDialog()
                    If FrmContactDetails.gsOK = True Then
                        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbCUSTOMER_ID.SelectedValue = FrmContactDetails.ID
                        CmbCUSTOMER_ID_LostFocus(sender, e)
                    End If
                    FrmContactDetails.Dispose()
                    FrmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If
        With FrmAddItem

            .sFormName = "frmSalesOrder"
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
            .StartPosition = FormStartPosition.Manual
            .gsNonInventoryItem = True

            Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height - (.Height)
            .Location = New Point(405, H_PC)
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
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            GS_RemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            Computed()
        End If
    End Sub

    Private Sub FrmSalesOrder_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If Me.Text = "" Then

        End If
        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If
    End Sub

    Private Sub CmbSALES_REP_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSALES_REP_ID.SelectedIndexChanged
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
    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub BtnDISCON_Click(sender As Object, e As EventArgs) Handles btnDISCON.Click
        tsDiscard.PerformClick()

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        tsSaveNew.PerformClick()

    End Sub

    Private Sub BtnTAX_Click(sender As Object, e As EventArgs) Handles btnTAX.Click

        FrmPOSTax.ShowDialog()
        If FrmPOSTax.gsOk = True Then
            cmbOUTPUT_TAX_ID.SelectedValue = FrmPOSTax.gsTax_Id
        End If


        FrmPOSTax.Dispose()
        FrmPOSTax = Nothing
    End Sub

    Private Sub BtnPrintOnly_Click(sender As Object, e As EventArgs) Handles btnPrintOnly.Click
        ToolStripButton1.PerformClick()
    End Sub

    Private Sub FrmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            FrmSplash.Show()
            FrmSplash.Timer1.Enabled = True
            gsMenuSubID = 0
            gsMenuID = 0
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmPOSOrderEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub BtnBACK_Click(sender As Object, e As EventArgs) Handles btnBACK.Click
        If dgvProductItem.Rows.Count <> 0 Then
            If MessageBoxQuestion("Are you sure want to back?") = False Then
                Exit Sub
            End If
        End If
        gsCloseCall = True

        Me.Close()

    End Sub

    Private Sub BtnCUSTOMER_Click(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
        FrmPOSContacts.gsContact_Type = 1
        FrmPOSContacts.ShowDialog()
        If FrmPOSContacts.gsOK = True Then
            GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

            cmbCUSTOMER_ID.SelectedValue = FrmPOSContacts.gsContact_ID
        Else
            bNewContact = FrmPOSContacts.gsNewContact
        End If
        FrmPOSContacts.Dispose()
        FrmPOSContacts = Nothing

        If bNewContact = True Then
            FrmContactDetails.IsNew = True
            '  frmContactDetails.PictureBox1.Image = tsCustomer.Image
            FrmContactDetails.ContactTypeId = 1
            FrmContactDetails.ShowDialog()
            If FrmContactDetails.gsOK = True Then
                xlblCustomer_Name.Text = ""
                xlblAcctNo.Text = ""

                GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = FrmContactDetails.ID
            End If
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub BtnSALESMAN_Click(sender As Object, e As EventArgs) Handles btnSALESMAN.Click
        FrmPOSContacts.gsContact_Type = 2
        FrmPOSContacts.ShowDialog()

        If FrmPOSContacts.gsOK = True Then
            If FrmPOSContacts.gsContact_ID = 0 Then
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedIndex = -1
                xlblSalesRep.Text = ""
            Else
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = FrmPOSContacts.gsContact_ID
            End If
        Else
            bNewContact = FrmPOSContacts.gsNewContact
        End If
        FrmPOSContacts.Dispose()
        FrmPOSContacts = Nothing
        If bNewContact = True Then
            '   frmContactDetails.PictureBox1.Image = tsSalesRep.Image
            FrmContactDetails.IsNew = True
            FrmContactDetails.ContactTypeId = 2
            FrmContactDetails.ShowDialog()
            If FrmContactDetails.gsOK = True Then
                xlblSalesRep.Text = ""
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = FrmContactDetails.ID
            End If
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub
    Private Sub Master_Keydown(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.F1
                btnSave.PerformClick()

            Case Keys.F2
                btnDISCON.PerformClick()
            Case Keys.F3
                btnTAX.PerformClick()
            Case Keys.F4
                btnPrintOnly.PerformClick()

            Case Keys.F6
                btnITEMLIST.PerformClick()
            Case Keys.F7
                btnCUSTOMER.PerformClick()
            Case Keys.F8
                btnSALESMAN.PerformClick()



            Case Keys.F12
                btnBACK.PerformClick()
            Case Keys.Insert
                tsAddItem.PerformClick()

            Case Keys.A
                tsAddItem.PerformClick()
            Case Keys.Delete
                tsRemoveItem.PerformClick()
            Case Keys.D
                tsRemoveItem.PerformClick()
            Case Keys.E
                tsEditItem.PerformClick()
            Case Keys.Print

            Case Keys.Enter
                If dgvProductItem.Rows.Count <> 0 Then
                    If dgvProductItem.Focused = True Then
                        tsEditItem.PerformClick()
                    End If
                End If
            Case Keys.Up
                dgvProductItem.Select()
            Case Keys.Down
                dgvProductItem.Select()
            Case Keys.Escape
                btnBACK.PerformClick()
            Case Else
                If dgvProductItem.Rows.Count <> 0 Then
                    tsFindText.Select()
                End If
        End Select

    End Sub

    Private Sub BtnSALESMAN_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSALESMAN.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub FrmPOSOrderEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnSave_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSave.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnDISCON_KeyDown(sender As Object, e As KeyEventArgs) Handles btnDISCON.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnTAX_KeyDown(sender As Object, e As KeyEventArgs) Handles btnTAX.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnPrintOnly_KeyDown(sender As Object, e As KeyEventArgs) Handles btnPrintOnly.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnITEMLIST_KeyDown(sender As Object, e As KeyEventArgs) Handles btnITEMLIST.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnCUSTOMER_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCUSTOMER.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub BtnBACK_KeyDown(sender As Object, e As KeyEventArgs) Handles btnBACK.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub DgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub TsFindText_KeyDown(sender As Object, e As KeyEventArgs) Handles tsFindText.KeyDown
        Master_Keydown(sender, e)
    End Sub

    Private Sub ToolStrip2_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip2.KeyDown
        Master_Keydown(sender, e)
    End Sub
End Class