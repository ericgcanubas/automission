
Public Class frmSalesReceipt
    Dim gsMemberDiscount As Double
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New frmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2) & "," & fFieldCollector(GroupBox3)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub frmSalesReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fcolumnGrid()
        fclear_Info()

        If gsNew = False Then
            fRefreshInfo(gsID)
            fRefreshItem(gsID)
            fComputed()
        End If
    End Sub
    Private Sub fRefreshInfo(ByVal prID As String)

        Try

            Dim sQuery As String = "select * from sales_receipt where ID = '" & prID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)
            fExecutedUsingReading(GroupBox1, sQuery)
            fExecutedUsingReading(GroupBox2, sQuery)
            fExecutedUsingReading(GroupBox3, sQuery)


        Catch ex As Exception

            fMessageboxError(ex)


        End Try
    End Sub
    Private Sub fcolumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "Tax"
        chk.Name = "TAX"

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", "Item Code") '1
            .Item(1).Width = 200
            .Add("DESCRIPTION", "Description") '2
            .Item(2).Width = 250
            .Add("QTY", "Qty") '3
            .Item(3).Width = 50
            .Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("UM", "U/M") '4
            .Item(4).Width = 70
            .Add("UNIT_PRICE", "Unit Price") '5
            .Item(5).Width = 50
            .Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISCOUNT_TYPE", "Discount Type") '6
            .Item(6).Width = 70
            .Add("DISCOUNT_RATE", "Discount Rate") '7
            .Item(7).Width = 70
            .Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("AMOUNT", "Amount") '8
            .Item(8).Width = 80
            .Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add(chk) '9
            .Item(9).Width = 30

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

            .Add("COGS_ACCOUNT_ID", "COGS_ACCOUNT_ID") '17
            .Item("COGS_ACCOUNT_ID").Visible = False

            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID") '18
            .Item("ASSET_ACCOUNT_ID").Visible = False

            .Add("INCOME_ACCOUNT_ID", "INCOME_ACCOUNT_ID") '19
            .Item("INCOME_ACCOUNT_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL_ID") '20
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '21
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '22
            .Item("ITEM_ID").Visible = False
            '================================================================
            .Add("POS_TRX_TYPE", "POS_TRX_TYPE") '23
            .Item("POS_TRX_TYPE").Visible = False

            .Add("POS_EDIT_QTY", "POS_EDIT_QTY") '24
            .Item("POS_EDIT_QTY").Visible = False
            .Add("POS_NOTES", "POS_NOTES") '25
            .Item("POS_NOTES").Visible = False
            .Add("BATCH_ID", "BATCH_ID") '26
            .Item("BATCH_ID").Visible = False
            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") '27
            .Item("PRINT_IN_FORMS").Visible = False
            .Add("DEPOSITED", "DEPOSITED") '28
            .Item("DEPOSITED").Visible = False
            .Add("ITEM_TYPE", "ITEM_TYPE") '29
            .Item("ITEM_TYPE").Visible = False
            .Add("NON_DISCOUNTED_ITEM", "NON_DISCOUNTED_ITEM") '30
            .Item("NON_DISCOUNTED_ITEM").Visible = False
        End With
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
  ii.`BATCH_ID`,
  ii.`PRINT_IN_FORMS`,
  ii.`DEPOSITED`,
  i.`TYPE` as `ITEM_TYPE`,
  i.`NON_DISCOUNTED_ITEM`
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
    WHERE  ii.`sales_receipt_ID` = '" & gsID & "' Order by ii.LINE_NO, ii.ID"

        Try
            Dim x As Integer = 0
            Dim rd As DataTableReader = fReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    If i = 3 Or i = 5 Or i = 7 Or i = 8 Then
                        dgvProductItem.Rows(x).Cells(i).Value = fgetTypeValue(fNumisNULL(rd(i)))
                    ElseIf i = 9 Then
                        Dim bTax As Boolean = fNumisNULL(rd(i))
                        dgvProductItem.Rows(x).Cells(i).Value = bTax
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
                Next
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            fMessageboxError(ex)
        End Try

        bRefreshItem = False
        fComputed()
        tdgv = New DataGridView
        tdgv = dgvProductItem
        tQuery = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2) & "," & fFieldCollector(GroupBox3)


    End Sub
    Private Function fgetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub fclear_Info()
        fComboxRefresh()
        fCLean_and_refresh(Me)
        fCLean_and_refresh(GroupBox1)
        fCLean_and_refresh(GroupBox2)
        fCLean_and_refresh(GroupBox3)
        '  fCLean_and_refresh(GroupBox4)

        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        'fComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_METHOD_ID.SelectedValue = fPaymentMethodDefault()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
    End Sub
    Private Sub fComboxRefresh()
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        fComboBox(cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        fComboBox(cmbCLASS_ID, "select * from class", "ID", "NAME")
        fComboBox(cmbSALES_REP_ID, "select * from contact where type ='2'", "ID", "NAME")
        fComboBox(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        fComboBox(cmbMANAGER_ID, "select * from contact where type ='5'", "ID", "NAME")
        fComboBox(cmbDEALER_ID, "select * from contact where type ='6'", "ID", "NAME")
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
        Dim total As Double = 0
        Dim dOutput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim n As Integer = 0
        Dim dVat As Double = 0

        Dim group_item_active As Boolean = False
        Dim group_item_id As Integer = 0


        Try

            Dim iSUB_Total As Double = 0
            Dim iSUB_TAX As Double = 0
            Dim iSUB_NON_TAX As Double = 0
            For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                If dgvProductItem.Rows(i).Visible = True Then
                    If 5 = dgvProductItem.Rows(i).Cells("ITEM_TYPE").Value Then
                        'Sub Total
                        If fCheckifDiscountNext(i) = False Then

                            If dTotal_amount <> 0 Then
                                iSUB_Total = iSUB_Total + dTotal_amount
                                dTotal_amount = 0
                            End If

                            If dTax <> 0 Then
                                iSUB_TAX = iSUB_TAX + dTax
                                dTax = 0
                            End If

                            If dNon_Tax <> 0 Then
                                iSUB_NON_TAX = iSUB_NON_TAX + dNon_Tax
                                dNon_Tax = 0
                            End If
                        End If
                    ElseIf fDISCOUNT_ITEM(dgvProductItem.Rows(i).Cells("ITEM_TYPE").Value) = True Then
                        'Discount Item
                        If dTotal_amount <> 0 Then
                            Dim NonDiscountAmount As Double = 0
                            Dim NonDiscountTax As Double = 0
                            Dim NonDiscountNonTax As Double = 0
                            For H As Integer = 0 To dgvProductItem.Rows.Count - 1

                                With dgvProductItem.Rows(H)
                                    If i = H Then
                                        Exit For
                                    Else
                                        Dim IsNonDiscountItem As Boolean = .Cells("NON_DISCOUNTED_ITEM").Value

                                        If IsNonDiscountItem = True And .Cells("ITEM_TYPE").Value = 0 Then
                                            NonDiscountAmount = NonDiscountAmount + fNumFormatFixed(.Cells("AMOUNT").Value)
                                            If .Cells("Tax").Value = False Then
                                                NonDiscountNonTax = NonDiscountNonTax + fNumFormatFixed(.Cells("AMOUNT").Value)
                                            Else
                                                NonDiscountTax = NonDiscountTax + fNumFormatFixed(.Cells("AMOUNT").Value)
                                            End If

                                        End If

                                    End If
                                End With

                            Next



                            Dim dtDiscount_Less As Double = fNumFormatFixed((dTotal_amount - NonDiscountAmount) * (fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value) * -1 / 100))

                            dTotal_amount = dTotal_amount - dtDiscount_Less
                            dgvProductItem.Rows(i).Cells("AMOUNT").Value = (dtDiscount_Less * -1)

                            If dTax <> 0 Then
                                dtDiscount_Less = fNumFormatFixed((dTax - NonDiscountTax) * (fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value) * -1 / 100))

                                dTax = dTax - dtDiscount_Less
                            End If
                            If dNon_Tax <> 0 Then

                                dtDiscount_Less = fNumFormatFixed((dNon_Tax - NonDiscountNonTax) * (fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value) * -1 / 100))

                                dNon_Tax = dNon_Tax - dtDiscount_Less

                            End If

                        Else

                            Dim dtDiscount_Less As Double = fNumFormatFixed(iSUB_Total * (fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value) * -1 / 100))
                            iSUB_Total = iSUB_Total - dtDiscount_Less
                            If iSUB_TAX <> 0 Then
                                dtDiscount_Less = fNumFormatFixed(iSUB_TAX * (fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value) * -1 / 100))
                                iSUB_TAX = iSUB_TAX - dtDiscount_Less
                            End If
                            If iSUB_NON_TAX <> 0 Then
                                dtDiscount_Less = fNumFormatFixed(iSUB_NON_TAX * (fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value) * -1 / 100))
                                iSUB_NON_TAX = iSUB_NON_TAX - dtDiscount_Less
                            End If
                        End If

                    ElseIf fGROUP_ITEM(dgvProductItem.Rows(i).Cells("ITEM_TYPE").Value, group_item_active) = True Then
                        If group_item_active = True And group_item_id = 0 Then
                            group_item_id = dgvProductItem.Rows(i).Cells("ITEM_ID").Value
                        ElseIf group_item_id = dgvProductItem.Rows(i).Cells("ITEM_ID").Value Then
                            group_item_active = False
                            group_item_id = 0
                            dTotal_amount = dTotal_amount + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                        ElseIf group_item_active = True And group_item_id <> 0 Then
                            If dgvProductItem.Rows(i).Cells("Tax").Value = False Then
                                dNon_Tax = dNon_Tax + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                            Else
                                dTax = dTax + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                            End If
                        End If
                    Else

                        dTotal_amount = dTotal_amount + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                        If dgvProductItem.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax = dNon_Tax + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax = dTax + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                n = n + 1
            Next

            dTotal_amount = iSUB_Total + dTotal_amount
            dTax = iSUB_TAX + dTax
            dNon_Tax = iSUB_NON_TAX + dNon_Tax

            If fTextisNULL(cmbOUTPUT_TAX_ID.Text) <> "" Then
                'add tax
                 dVat = fTax_Rate_Find(fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue))
                dOutput_value = (dVat / 100) * dTax
                total = dOutput_value + dTax

                If cmbOUTPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dOutput_value = t * dOutput_value

                    dTax = dTax - dOutput_value

                    total = dOutput_value + dTax

                End If
                total = total + dNon_Tax
                lblOUTPUT_TAX_AMOUNT.Text = fNumFormatStandard(dOutput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)


                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(dTax)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblOUTPUT_TAX_AMOUNT.Text = fNumFormatStandard(dOutput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)

                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(0)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(total)
            End If

            lblOUTPUT_TAX_RATE.Text = dVat
            If n = 0 Then
                
            Else
                
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbPAYMENT_METHOD_ID_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedValueChanged

        Dim card_no As Boolean = False
        Dim card_value As Boolean = False
        Try



            Dim I As Integer = 0
            If cmbPAYMENT_METHOD_ID.Items.Count <> 0 Then
                I = Val(cmbPAYMENT_METHOD_ID.SelectedValue)
            End If

            Select Case I
                Case 1 'Cash
                    lbslREF_No.Text = "O.R No."
                    card_no = False
                    card_value = False
                Case 2 'Check
                    lbslREF_No.Text = "Check No."
                    card_no = False
                    card_value = False

                Case 3 'Master Card

                    lbslREF_No.Text = "Approval No."
                    card_no = True
                    card_value = True


                Case 4 'Others

                    lbslREF_No.Text = "Approval No."
                    card_no = True
                    card_value = True


                Case 5
                    lbslREF_No.Text = "Approval No."
                    card_no = True
                    card_value = True

                Case Else

            End Select


        Catch ex As Exception
            lbslREF_No.Text = "O.R No."
            card_no = False
            card_value = False
        End Try

        lbslCARD_NO.Visible = card_no
        txtCARD_NO.Visible = card_value

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please  Name")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item Enter")
            Exit Sub
        End If
        If cmbPAYMENT_METHOD_ID.Text = "" Then
            fMessageboxInfo("Please select payment method")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then


            If fIsClosingDate(dtpDATE.Value) = False Then
                    Exit Sub
                End If


                If Trim(txtCODE.Text) = "" Then
                    txtCODE.Text = fNEXT_CODE("SALES_RECEIPT", cmbLOCATION_ID.SelectedValue)
                End If

                lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text = gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID
                lblDEPOSITED.Text = "0"
                dtpDATE.Checked = True
                Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2) & "," & fFieldCollector(GroupBox3)
                gsID = fObjectTypeMap_ID("SALES_RECEIPT")
                squery = squery & ",ID='" & gsID & "',RECORDED_ON='" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='3',STATUS_DATE='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
                squery = fNullOTherField(squery, "SALES_RECEIPT")
                fCursorLoadingOn(True)
                fExecutedOnly("INSERT INTO SALES_RECEIPT SET " & squery)
                fTransactionDateSelectUpdate(dtpDATE.Value)
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
            Else
            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If

            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2) & "," & fFieldCollector(GroupBox3)
            squery = squery & " WHERE ID = '" & gsID & "'"
            fCursorLoadingOn(True)
            fExecutedOnly("UPDATE SALES_RECEIPT SET " & squery)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If
        If fTransactionCheck(gsID, "SALES_RECEIPT") = False Then
            fCursorLoadingOn(False)
            fMessageboxWarning("Please try again")
            Exit Sub
        Else
            fSaveItem(gsID)  ' Save item
            fJournalTransaction_Sales_Receipt(gsID)
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
        fCursorLoadingOn(False)
    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()
        gsID = ""
        gsNew = True
        gsMemberDiscount = 0

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
                        SQL_SCRIPT = "UPDATE SALES_RECEIPT_ITEMS SET TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_RECEIPT_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value))
                        fExecutedOnly(SQL_SCRIPT)
                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("SALES_RECEIPT_ITEMS")
                        SQL_SCRIPT = "INSERT INTO SALES_RECEIPT_ITEMS SET LINE_NO='" & fGetMaxField_LINE("LINE_NO", "SALES_RECEIPT_ITEMS", "SALES_RECEIPT_ID", dID) & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",SALES_RECEIPT_ID ='" & dID & "',GROUP_LINE_ID = " & fGotNullNumber(sGROUP_ITEM_ID) & ",POS_TRX_TYPE=" & fGotNullNumber(.Cells("POS_TRX_TYPE").Value) & ",POS_EDIT_QTY=" & fGotNullNumber(.Cells("POS_EDIT_QTY").Value) & ",POS_NOTES=" & fGotNullText(.Cells("POS_NOTES").Value) & ",BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ",PRINT_IN_FORMS=" & fGotNullNumber(.Cells("PRINT_IN_FORMS").Value) & ",DEPOSITED=" & fGotNullNumber(.Cells("DEPOSITED").Value)
                        fExecutedOnly(SQL_SCRIPT)

                        If fGROUP_ITEM(fNumisNULL(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = fNumisNULL(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf fNumisNULL(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If
                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE SALES_RECEIPT_ITEMS SET QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",POS_TRX_TYPE=" & fGotNullNumber(fNumisNULL(.Cells("POS_TRX_TYPE").Value)) & ",POS_EDIT_QTY=" & fGotNullNumber(fNumisNULL(.Cells("POS_EDIT_QTY").Value)) & ",POS_NOTES=" & fGotNullText(fTextisNULL(.Cells("POS_NOTES").Value)) & ",BATCH_ID=" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & ",PRINT_IN_FORMS=" & fGotNullNumber(fNumisNULL(.Cells("PRINT_IN_FORMS").Value)) & ",DEPOSITED=" & fGotNullNumber(fNumisNULL(.Cells("DEPOSITED").Value)) & " WHERE SALES_RECEIPT_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " Limit 1;"
                        fExecutedOnly(SQL_SCRIPT)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM SALES_RECEIPT_ITEMS WHERE SALES_RECEIPT_ID ='" & dID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "'"
                        fExecutedOnly(SQL_SCRIPT)
                        fItemInventoryRemoveFixed("SALES RECEIPT", fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                        fJournalAccountRemoveFixed("SALES_RECEIPT_ITEMS", .Cells("ID").Value, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("ITEM_ID").Value))
                        fJournalAccountRemoveFixed("SALES_RECEIPT_ITEMS", .Cells("ID").Value, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
                End Select
            End With
        Next
    End Sub
    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()

        Try

            Dim rd As DataTableReader = fReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
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


    Private Sub fDeleteItem()
        Try
            If dgvProductItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvProductItem.CurrentRow.Index
                Dim d As DataGridViewRow = dgvProductItem.Rows(i)

                If fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value = "" Then
                    fMessageboxInfo("Invalid Delete")
                    Exit Sub

                ElseIf fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value <> "" Then
                    Dim tmp_ID As Integer = d.Cells("ITEM_ID").Value
                    Dim sTemp_ID As Integer = 0
                    Dim sTemp_CODE As String = ""
X_A:
                    For n As Integer = i To dgvProductItem.Rows.Count - 1
                        sTemp_ID = dgvProductItem.Rows(n).Cells("ITEM_ID").Value
                        sTemp_CODE = dgvProductItem.Rows(n).Cells("CODE").Value

                        If fNumisNULL(dgvProductItem.Rows(n).Cells(0).Value) <> 0 Then
                            dgvProductItem.Rows(n).Cells("CONTROL_STATUS").Value = "D"
                            dgvProductItem.Rows(n).Visible = False
                        Else
                            If sTemp_ID = tmp_ID And sTemp_CODE = "" Then
                                dgvProductItem.Rows.RemoveAt(n)
                                fDiscount_ReComputed(dgvProductItem)
                                fGROUP_ReComputed(dgvProductItem)
                                fComputed()
                                Exit Sub
                            Else
                                dgvProductItem.Rows.RemoveAt(n)
                                GoTo X_A
                            End If

                        End If

                        If sTemp_ID = tmp_ID And sTemp_CODE = "" Then
                            fDiscount_ReComputed(dgvProductItem)
                            fGROUP_ReComputed(dgvProductItem)
                            fComputed()
                            Exit Sub
                        End If
                    Next
                Else
                    If fNumisNULL(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                        dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgvProductItem.Rows(i).Visible = False
                    Else
                        dgvProductItem.Rows.RemoveAt(i)
                    End If

                End If
                fDiscount_ReComputed(dgvProductItem)
                fGROUP_ReComputed(dgvProductItem)
                fComputed()
            End If
        Catch ex As Exception
            fMessageboxError(ex)
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
            ElseIf fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value = "" Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem
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
                .gsPRICE_LEVEL_ID = dgvProductItem.Rows.Item(I).Cells("PRICE_LEVEL_ID").Value
            End With
            frmAddItem.ShowDialog()
            With frmAddItem
                If .gsSave = True Then
                    fRow_Data_Item_Sales_Receipt(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID)
                    fDiscount_ReComputed(dgvProductItem)
                    fGROUP_ReComputed(dgvProductItem)

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

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And gsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        fCloseForm(Me)
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If

            If fMessageBoxQuestion(gsMessageQuestion) = True Then



                fCursorLoadingOn(True)
                fJournalTransaction_Sales_Receipt_Delete(gsID)
                fExecutedOnly("DELETE FROM SALES_RECEIPT_ITEMS WHERE SALES_RECEIPT_ID ='" & gsID & "' ")
                fExecutedOnly("DELETE FROM SALES_RECEIPT WHERE ID ='" & gsID & "' ")
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                gsID = ""
                gsNew = True
                fCursorLoadingOn(False)


                If fMessageBoxQuestion("Without clear details?") = True Then
                    cmbLOCATION_ID.Enabled = True
                    dtpDATE.Enabled = True
                    For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                        With dgvProductItem.Rows(i)
                            .Cells("CONTROL_STATUS").Value = "A"
                        End With
                    Next
                Else
                    fclear_Info()
                    dgvProductItem.Rows.Clear()
                    fComputed()
                End If





            End If


        End If
    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If

    End Sub

    Private Sub frmSalesReceipt_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged


    End Sub

    Private Sub frmSalesReceipt_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        StandardColWith(dgvProductItem)
        fDgvNotSort(dgvProductItem)
    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged


        Application.DoEvents()
        Try
            Dim s As String = cmbCUSTOMER_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try



        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If gsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub


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
            fPreviewReport(prPrint_Title & "Report")

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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
            Dim getACCOUNT_ID As Integer = 5

            Dim rd As DataTableReader = fReader($"select ACCOUNT_ID from account_journal where OBJECT_TYPE ='52' and OBJECT_ID ='{gsID}' and OBJECT_DATE = '{fDateFormatMYSQL(dtpDATE.Value)}' and ENTRY_TYPE ='0' and LOCATION_ID ='{cmbLOCATION_ID.SelectedValue}' limit 1 ")
            If rd.Read Then
                getACCOUNT_ID = fNumisNULL(rd("ACCOUNT_ID"))
            End If
            rd.Close()
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 52, getACCOUNT_ID, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
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

    Private Sub cmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
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

        Dim rd As DataTableReader = fReader($"select * from contact where id ='{s}' and `type` = '1' limit 1 ")
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
                    frmContactDetails.PictureBox1.Image = img
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

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        fGetQuickFind(dgvProductItem, txtFind.Text)
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If

        With frmAddItem


            .sFormName = Me.Name
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            .dgv = dgvProductItem

            If gsMemberDiscount <> 0 Then
                .gsMEMBER = True
                .gsMEMEBER_DISCOUNT = gsMemberDiscount
            End If
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
        fDeleteItem()
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If gsNew = True Then Exit Sub
        If fACCESS_PRINT_PREVIEW(Me) = False Then
            Exit Sub
        End If

        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        End If

        If gsNew = True Then

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
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False

                fPreviewReport(prPrint_Title & "Report")
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub

    Private Sub frmSalesReceipt_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If gsNew = False Then

            fRefreshInfo(gsID)
            fRefreshItem(gsID)
            fComputed()
        End If
    End Sub
End Class