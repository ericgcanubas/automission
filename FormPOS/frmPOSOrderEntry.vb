Imports System.Data.Odbc
Public Class frmPOSOrderEntry

    Public gsCloseCall As Boolean = False
    Dim bNewContact As Boolean = False

    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim bRefreshItem As Boolean = False
    Dim bEntryAddItem As Boolean = False
    Dim f As Form = New frmFindDocument

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        tsCOUNT.Text = DirectCast(sender, DataGridView).Rows.Count
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
    Private Sub frmSalesOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fLabel_Digital_L(lblAMOUNT)

        fLabel_Digital_L(xlblTOTAL)
        fLabel_Digital_M(lblOUTPUT_TAX_AMOUNT)


        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = fLoadLocationDefault()
        gsStorage_Location_ID = fLoadStorageLocation()
        gsIncRefNoByLocation = fIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = fCashOverShortExpense()
        fDefaultAccountLoad()

        fcolumnGrid()
        fclear_Info()
        If gsNew = False Then
            fRefreshInfo(gsID)
            fRefreshItem(gsID)
        End If
        '=============================

        fCLean_and_refresh(Me)
        fMaterialSkin(Me)
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

        Me.AccessibleName = fGetFieldValue("tblsub_menu", "form", "frmSalesOrder", "sub_id")

        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()



        gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = fCashOverShortExpense()
        gsPOSDefaultCustomer_ID = fSystemSettingValue("POSDefaultCustomerId")
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = fLoadLocationDefault()
        gsIncRefNoByLocation = fIncRefNoByLocation()
        gsPOS_MACHINE_ID = fPOS_MACHINE_ID()

        gsPOS_TYPE_ID = fPOS_machine_type_map()
        Me.Text = "Point of Sales : Order Entry"


        gsMainWith = Me.Width
        gsMainHeight = Me.Height
        fComputed()

    End Sub
    Private Sub fclear_Info()

        fRefreshCombo()
        fCLean_and_refresh(Me)
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
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = fPaymentTermsDefault()
        dtpDATE.Value = fTransactionDefaultDate()

        ' fDefaultAccountLoad()
        cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
        cmbCUSTOMER_ID.SelectedValue = Val(gsPOSDefaultCustomer_ID)




    End Sub
    Private Sub fRefreshInfo(ByVal prID As String)


        Try

            Dim sQuery As String = "select * from sales_order where ID = '" & prID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)

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
   WHERE ii.`SALES_ORDER_ID` = '" & gsID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 2
                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatStandard(fNumisNULL(rd(i)))
                        ElseIf fCheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatNoDecimal(fNumisNULL(rd(i)))
                        ElseIf fCheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(fNumisNULL(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = fNumisNULL(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = fTextisNULL(rd(i))
                            End If
                        End If
                    End With

                Next
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        Finally

            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = fFieldCollector(Me)

        End Try


    End Sub

    Private Function fgetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub fRefreshCombo()
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        fComboBox(cmbCLASS_ID, "select * from class order by `NAME`", "ID", "NAME")
        fComboBox(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        fComboBox(cmbSALES_REP_ID, "select * from contact where type ='2' order by `NAME`", "ID", "NAME")
        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        'fComboBox(cmbSHIP_VIA_ID, "select * from ship_via", "ID", "DESCRIPTION")
        fComboBox(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")

    End Sub
    Private Sub fcolumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "TAX"
        chk.Name = "TAX"

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
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        fCloseForm(Me)
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

    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged

        fComputed()

        Select Case fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue)
            Case 14
                xlblTax.Text = "0% Vat"
            Case 12
                xlblTax.Text = "12% Vat(I)"
            Case 13
                xlblTax.Text = "12% Vat(E)"
            Case 2
        End Select

        Try

            Dim rd As OdbcDataReader = fReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = fTextisNULL(rd("VAT_METHOD"))
            End If
            rd.Close()
        Catch ex As Exception
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If
        End Try
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
            ElseIf fNumisNULL(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem
                .gsNonInventoryItem = True
                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
                    fRow_Data_Item_Sales_Order(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, "", .gsPRICE_LEVEL_ID, False, 0)

                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
    End Sub




    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
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
        f.AccessibleName = "sales_order"
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

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs)

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

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Customer")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item Enter")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(frmSalesOrder, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then

            'If fIsClosingDate(dtpDATE.Value) = False Then
            '    Exit Sub
            'End If

            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = fNEXT_CODE("SALES_ORDER", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("sales_order")
            squery = squery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='2',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            squery = fNullOTherField(squery, "sales_order")
            fExecutedOnly("INSERT INTO sales_order SET " & squery)

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            'If fIsClosingDate(dtpDATE.Value) = False Then
            '    Exit Sub
            'End If

            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)

            squery = squery & " WHERE ID = '" & gsID & "' limit 1"
            fExecutedOnly("UPDATE sales_order SET " & squery)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If fTransactionCheck(gsID, "sales_order") = False Then
            fMessageboxWarning("Please try again")
            Exit Sub
        Else
            fSaveItem(gsID)  ' Save item
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
                fRefreshInfo(gsID)
                fRefreshItem(gsID)
            End If

        End Try
    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()
        gsID = ""
        gsNew = True

    End Sub
    Private Sub fEstimate_ITEM_UPDATE(ByVal prITEM_ID As Double, ByVal prINVOICED_QTY As Double, ByVal ADD_EDIT As Boolean)
        If prITEM_ID = 0 Then
            Exit Sub
        End If

        Dim SO_SQL As String

        Dim get_SO_ID As String = fGetFieldValue("estimate_items", "ID", prITEM_ID, "estimate_ID")

        If ADD_EDIT = True Then
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & prITEM_ID & "' Limit 1"
        Else
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = NULL,`CLOSED` = '0' where ID = '" & prITEM_ID & "' Limit 1"
        End If
        fExecutedOnly(SO_SQL)

        fExecutedOnly("Update Estimate set `STATUS` = '3'  where ID = '" & get_SO_ID & "' limit 1")
    End Sub

    Private Sub fSaveItem(ByVal dID As String)

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
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value))
                        fExecutedOnly(SQL_SCRIPT)
                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("SALES_ORDER_ITEMS")
                        SQL_SCRIPT = "INSERT INTO sales_order_items SET LINE_NO='" & fGetMaxField_LINE("LINE_NO", "SALES_ORDER_ITEMS", "SALES_ORDER_ID", dID) & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",SALES_ORDER_ID ='" & dID & "',CLOSED ='0',INVOICED_QTY= NULL,PRICE_LEVEL_ID = " & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",GROUP_LINE_ID = " & fGotNullNumber(sGROUP_ITEM_ID)
                        fExecutedOnly(SQL_SCRIPT)

                        fEstimate_ITEM_UPDATE(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True)

                        If fGROUP_ITEM(fNumisNULL(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = fNumisNULL(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf fNumisNULL(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If

                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & " WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & ""
                        fExecutedOnly(SQL_SCRIPT)
                        fEstimate_ITEM_UPDATE(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM sales_order_items WHERE SALES_ORDER_ID ='" & dID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "'"
                        fExecutedOnly(SQL_SCRIPT)
                End Select

            End With


        Next


    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If
            If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                Exit Sub
            End If
            If fMessageBoxQuestion(gsMessageQuestion) = True Then

                fExecutedOnly("DELETE FROM sales_order_items WHERE SALES_ORDER_ID = '" & gsID & "'")

                fExecutedOnly("DELETE FROM sales_order WHERE ID = '" & gsID & "'")

                fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                gsID = ""
                gsNew = True

            End If

        End If

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If
    End Sub

    Private Sub frmSalesOrder_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmSalesOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height
        ' Dim H_ As Integer = Screen.PrimaryScreen.Bounds.Height
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = H_PC
        Me.Location = New Point(0, 0)


        fdgvItemDisplay(dgvProductItem)
        fDgvNotSort(dgvProductItem)
        btnDISCON.PerformClick()
    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        If bEntryAddItem = True Then
            Exit Sub
        End If

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub

        If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        xlblCustomer_Name.Text = cmbCUSTOMER_ID.Text
        xlblAcctNo.Text = fGetFieldValue("CONTACT", "ID", fNumisNULL(cmbCUSTOMER_ID.SelectedValue), "ACCOUNT_NO")
        Dim rd As OdbcDataReader = fReader($"select TAX_ID from contact where id ='{fNumisNULL(cmbCUSTOMER_ID.SelectedValue)}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If fNumisNULL(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = fNumisNULL(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
            End If
        End If

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
            If fACCESS_PRINT_PREVIEW(frmSalesOrder) = False Then
                Exit Sub
            End If
            '   Dim prFile_name As String = "crySalesOrder.rpt"
            ' Dim prPrint_Title As String = "Sales Order"
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesOrder' and  [print_default] = '1' ", cn)
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
            If fACCESS_PRINT_PREVIEW(frmSalesOrder) = False Then
                Exit Sub
            End If
            '   Dim prFile_name As String = "crySalesOrder.rpt"
            '  Dim prPrint_Title As String = "Sales Order"
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesOrder' and  [print_default] = '1' ", cn)
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

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
            fclear_Info()

        Else
            If fMessageBoxQuestion("Create new?") = True Then
                gsNew = True
                gsID = ""
                fclear_Info()

            Else
                fclear_Info()
                fRefreshInfo(gsID)
                fRefreshItem(gsID)
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub cmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
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
        If gsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = fReader($"select * from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If fNumisNULL(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = fNumisNULL(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub


    Private Sub cmbCUSTOMER_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCUSTOMER_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbCUSTOMER_ID.Text)
            If cmbCUSTOMER_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If gsNew = True Then
                    If fACCESS_NEW_EDIT(frmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/customer.png")

                    frmContactDetails.gsContact_Type = "1"
                    frmContactDetails.txtNAME.Text = StrText ' must auto insert
                    frmContactDetails.txtCOMPANY_NAME.Text = StrText
                    frmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    frmContactDetails.bNew = True
                    frmContactDetails.gsID = ""
                    frmContactDetails.gsDgv = Nothing
                    frmContactDetails.this_BS = Nothing
                    frmContactDetails.ShowDialog()
                    If frmContactDetails.gsOK = True Then
                        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbCUSTOMER_ID.SelectedValue = frmContactDetails.gsID
                        cmbCUSTOMER_ID_LostFocus(sender, e)
                    End If
                    frmContactDetails.Dispose()
                    frmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If



        With frmAddItem

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
        fComputed()
        frmAddItem.Dispose()
        frmAddItem = Nothing
    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            fRemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            fComputed()
        End If
    End Sub

    Private Sub frmSalesOrder_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If Me.Text = "" Then

        End If
        If gsNew = False Then
            fRefreshInfo(gsID)
            fRefreshItem(gsID)
        End If
    End Sub

    Private Sub CmbSALES_REP_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSALES_REP_ID.SelectedIndexChanged
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

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub btnDISCON_Click(sender As Object, e As EventArgs) Handles btnDISCON.Click
        tsDiscard.PerformClick()

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        tsSaveNew.PerformClick()

    End Sub

    Private Sub btnTAX_Click(sender As Object, e As EventArgs) Handles btnTAX.Click

        frmPOSTax.ShowDialog()
        If frmPOSTax.gsOk = True Then
            cmbOUTPUT_TAX_ID.SelectedValue = frmPOSTax.gsTax_Id
        End If


        frmPOSTax.Dispose()
        frmPOSTax = Nothing
    End Sub

    Private Sub btnPrintOnly_Click(sender As Object, e As EventArgs) Handles btnPrintOnly.Click
        ToolStripButton1.PerformClick()

    End Sub

    Private Sub frmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            frmSplash.Show()
            frmSplash.Timer1.Enabled = True
            gsMenuSubID = ""
            gsMenuID = ""
            Me.Dispose()
        End If
    End Sub

    Private Sub frmPOSOrderEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub btnBACK_Click(sender As Object, e As EventArgs) Handles btnBACK.Click
        If dgvProductItem.Rows.Count <> 0 Then

            If fMessageBoxQuestion("Are you sure want to back?") = False Then
                Exit Sub
            End If
        End If
        gsCloseCall = True

        Me.Close()

    End Sub

    Private Sub btnCUSTOMER_Click(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
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

    Private Sub btnSALESMAN_Click(sender As Object, e As EventArgs) Handles btnSALESMAN.Click
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
    Private Sub fMaster_Keydown(sender As Object, e As KeyEventArgs)




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

    Private Sub btnSALESMAN_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSALESMAN.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub frmPOSOrderEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnSave_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSave.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnDISCON_KeyDown(sender As Object, e As KeyEventArgs) Handles btnDISCON.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnTAX_KeyDown(sender As Object, e As KeyEventArgs) Handles btnTAX.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnPrintOnly_KeyDown(sender As Object, e As KeyEventArgs) Handles btnPrintOnly.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnITEMLIST_Click(sender As Object, e As EventArgs) Handles btnITEMLIST.Click

    End Sub

    Private Sub btnITEMLIST_KeyDown(sender As Object, e As KeyEventArgs) Handles btnITEMLIST.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnCUSTOMER_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCUSTOMER.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub btnBACK_KeyDown(sender As Object, e As KeyEventArgs) Handles btnBACK.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub tsAddItem_EnabledChanged(sender As Object, e As EventArgs) Handles tsAddItem.EnabledChanged

    End Sub

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub tsFindText_KeyDown(sender As Object, e As KeyEventArgs) Handles tsFindText.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub

    Private Sub ToolStrip2_KeyDown(sender As Object, e As KeyEventArgs) Handles ToolStrip2.KeyDown
        fMaster_Keydown(sender, e)
    End Sub
End Class