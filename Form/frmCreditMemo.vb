Imports System.Data.Odbc
Public Class frmCreditMemo

    Public gsMemberDiscount As Double = 0
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New frmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
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
    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And gsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmCreditMemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts



        tsTITLE.Text = gsSubMenuForm
        '  fBackGroundImageStyle(Me)
        fcolumnGrid()
        fclear_Info()

        If gsNew = False Then
            fRefreshField(gsID)
            fRefreshItem(gsID)
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If

        fdgvItemDisplay(dgvProductItem)
        fDgvNotSort(dgvProductItem)
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
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
            .Add("UNIT_PRICE", gsCUSTOM_RATE) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8t
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

            .Add("GROUP_LINE_ID", "GROUP_LINE_ID") '23
            .Item("GROUP_LINE_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") ' 24
            .Item("ITEM_TYPE").Visible = False

            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") ' 25
            .Item("PRINT_IN_FORMS").Visible = False

            .Add("BATCH_ID", "BATCH_ID") '26
            .Item("BATCH_ID").Visible = False
            .Add("BATCH_NO", gsCUSTOM_BATCH) '27
            .Item("BATCH_NO").Visible = gsExpiredReference

        End With
    End Sub
    Private Sub fRefreshField(ByVal id As String)

        Try

            Dim sQuery As String = "select * from credit_memo where ID = '" & id & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshField(id)
            Else
                End
            End If
        End Try


        If gsNew = False Then
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If
    End Sub
    Private Sub fRefreshItem(ByVal xID As String)
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
  ii.`PRICE_LEVEL_ID`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`GROUP_LINE_ID`,
 i.TYPE as `ITEM_TYPE`,
ii.PRINT_IN_FORMS,
II.BATCH_ID,
B.BATCH_NO

FROM

  credit_memo_items AS ii 
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
    WHERE  ii.`credit_memo_id` = '" & gsID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0
            ' cn.Open()
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

                If CBool(fNumisNULL(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If

                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshItem(xID)
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

        Dim dPayment_applied As Double = fGetCreditApplied_Amount(gsID, cmbCUSTOMER_ID.SelectedValue)
        Dim gsSalesSubTotal As Double
        fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
        lblAMOUNT_APPLIED.Text = fNumFormatStandard(dPayment_applied)
        lbxUNAPPLIED_AMOUNT.Text = fNumFormatStandard(Val(fNumFormatFixed(lblAMOUNT.Text)) - dPayment_applied)
        lblCount.Text = fDgvCounting(dgvProductItem)
    End Sub

    Private Sub fComboxRefresh()
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        fComboBox(cmbCLASS_ID, "select * from class", "ID", "NAME")
        fComboBox(cmbSALES_REP_ID, "select * from contact where type ='2'", "ID", "NAME")
        fComboBox(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        fComboBox(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")


    End Sub
    Private Sub fclear_Info()
        fComboxRefresh()
        fCLean_and_refresh(Me)


        cmbCUSTOMER_ID.Enabled = True
        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID
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

        f.AccessibleName = "credit_memo"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fclear_Info()
                gsID = f.AccessibleDescription
                gsNew = False

                fRefreshField(gsID)
                fRefreshItem(gsID)

            End If


        End If

        'f.Dispose()
        'f = Nothing
    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        ' Dim cn As New MySqlConnection(mysqlConstr)
        Try
            '   cn.Open()
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If
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
            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index

            Dim d As DataGridViewRow = dgvProductItem.Rows(I)

            If d.Cells("ITEM_ID").Value = 5 Then
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
                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                .gsUseItemBatch = True
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
            End With
            frmAddItem.ShowDialog()
            With frmAddItem
                If .gsSave = True Then
                    fRow_Data_Item_Credit_Memo(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID, 0, False, .gsBATCH_ID)
                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
    End Sub



    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

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
    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
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
        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then


            If Trim(txtCODE.Text) = "" Then

                txtCODE.Text = fNEXT_CODE("CREDIT_MEMO", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("CREDIT_MEMO")
            squery = squery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='2',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            squery = fNullOTherField(squery, "CREDIT_MEMO")
            fExecutedOnly("INSERT INTO credit_memo SET " & squery & ";")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)
            Dim nStatus As Integer = 0
            If 0 >= fNumFormatFixed(lbxUNAPPLIED_AMOUNT.Text) Then
                nStatus = 15
            Else
                nStatus = 2
            End If
            squery = squery & ",STATUS='" & nStatus & "',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsID & "' limit 1;"
            fExecutedOnly("UPDATE credit_memo SET " & squery)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            fAccount_Journal_SQL(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 12, gsID, dtpDATE.Value, 1, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            If fNumisNULL(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 12, gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 12, gsID, dtpDATE.Value, 0, fNumisNULL(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================


        fSaveItem()  ' Save item

        If fTransactionCheck(gsID, "CREDIT_MEMO") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If

        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If


        If gsNew = True Then
            gsNew = False
            Dim iSelect As Integer
            With frmCreditMemoOption
                .ShowDialog()
                'Create proccess
                iSelect = .iSelect
                .Dispose()
            End With
            frmCreditMemoOption = Nothing
            If iSelect = 2 Then
                fGiveARefund()
            ElseIf iSelect = 3 Then
                fApplytoInvoice()
                Exit Sub
            End If
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
                fRefreshField(gsID)
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
        gsMemberDiscount = 0

        If gsNew = False Then
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If
    End Sub
    Private Sub fSaveItem()
        'src= 12
        'obj =14


        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        fExecutedOnly("UPDATE credit_memo_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE CREDIT_MEMO_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("CREDIT_MEMO_ITEMS")
                        fExecutedOnly("INSERT INTO credit_memo_items SET   BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ",PRINT_IN_FORMS ='" & fNumisNULL(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",CREDIT_MEMO_ID ='" & gsID & "',GROUP_LINE_ID = " & fGotNullNumber(.Cells("GROUP_LINE_ID").Value) & ";")
                        .Cells("ID").Value = i_ID
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        fExecutedOnly("UPDATE credit_memo_items SET   BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ",LINE_NO='" & i & "',QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & " WHERE CREDIT_MEMO_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "D"

                        fExecutedOnly("DELETE FROM credit_memo_items WHERE CREDIT_MEMO_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                End Select
            End With
        Next


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
    'Public Function fINVENTORY_JOURNAL(ByVal dgvROW As DataGridViewRow) As String
    '    Dim StrSQL As String = ""
    '    With dgvROW

    '        If .Cells("ITEM_TYPE").Value = 5 Or .Cells("ITEM_TYPE").Value = 6 Then

    '        Else

    '            'INVENTORY ITEM
    '            Dim LAST_ENDING_UNIT_COST As Double = 0
    '            If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
    '                'ITEM INVENTORY/ ASSEMBLY ONLY
    '                Dim THIS_QTY As Double = fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) * fNumisNULL(.Cells("QTY").Value)
    '                StrSQL = StrSQL & fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, THIS_QTY, LAST_ENDING_UNIT_COST, 12, fNumisNULL(.Cells("ID").Value), dtpDATE.Value)
    '            End If

    '            If gsSkipJournalEntry = False Then
    '                'INCOME_ACCOUNT_ID
    '                Dim AMT As Double = 0
    '                If fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
    '                    AMT = fNumisNULL(.Cells("TAXABLE_AMOUNT").Value)
    '                Else
    '                    AMT = fNumisNULL(.Cells("AMOUNT").Value)
    '                End If

    '                Dim E As Integer = 0
    '                If fNumisNULL(.Cells("AMOUNT").Value) <= 0 Then
    '                    E = 1
    '                Else
    '                    E = 0
    '                End If

    '                StrSQL = StrSQL & fAccount_Journal_SQL(.Cells("INCOME_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 14, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)

    '                If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
    '                    'ITEM INVENTORY/ ASSEMBLY
    '                    'COST ONLY
    '                    Dim AMT_COST As Double = LAST_ENDING_UNIT_COST * fNumisNULL(.Cells("QTY").Value)
    '                    'ASSET_ACCOUNT_ID
    '                    StrSQL = StrSQL & fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 14, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 0, AMT_COST, gsJOURNAL_NO_FORM)
    '                    'COGS_ACCOUNT_ID
    '                    StrSQL = StrSQL & fAccount_Journal_SQL(.Cells("COGS_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 14, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 1, AMT_COST, gsJOURNAL_NO_FORM)

    '                End If

    '            End If

    '        End If
    '    End With
    '    Return StrSQL
    'End Function
    Private Sub fApplytoInvoice()
        With frmCreditMemoInvoice
            .gsCustomer_ID = cmbCUSTOMER_ID.SelectedValue
            .gsLocation_ID = cmbLOCATION_ID.SelectedValue

            .gsID = gsID
            .lblName.Text = cmbCUSTOMER_ID.Text
            .lblDATE.Text = dtpDATE.Value
            .lblCreditAmount.Text = lblAMOUNT.Text
            .lblCODE.Text = txtCODE.Text
            .ShowDialog()


            If .gsOk = True Then

                'ADD UPDATE ' to 
                fComputed()
                Dim e As Object = Nothing

                If gsNew = True Then
                    tsSaveNew_Click(1, e)
                End If
            End If
            .Dispose()

        End With


        frmCreditMemoInvoice = Nothing
    End Sub
    Private Sub fGiveARefund()
        If gsNew = True Then
            Dim ob As Object = Nothing
            tsSaveNew_Click(1, ob)
        End If
    End Sub
    Private Sub ApplyToInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyToInvoiceToolStripMenuItem.Click
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
            fApplytoInvoice()
        End If


    End Sub

    Private Sub GiveARefundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiveARefundToolStripMenuItem.Click
        fGiveARefund()
    End Sub


    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If gsNew = False Then

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                Exit Sub
            End If

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

            If fMessageBoxQuestion(gsMessageQuestion) = True Then

                Try

                    Dim rd As OdbcDataReader = fReader("SELECT INVOICE_ID FROM CREDIT_MEMO_INVOICES WHERE CREDIT_MEMO_ID = '" & gsID & "'")
                    While rd.Read

                        fInvoiceBalance_Update(rd("INVOICE_ID"), fNumFieldValue("INVOICE", "ID", rd("INVOICE_ID"), "AMOUNT"))

                    End While
                    rd.Close()
                Catch ex As Exception
                    fMessageboxWarning(ex.Message)
                    Exit Sub
                End Try

                fCursorLoadingOn(True)
                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next
                fSaveItem()  ' delete
                '===========================================

                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0

                    fAccount_journal_Delete(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, 12, gsID, dtpDATE.Value)

                    If fNumisNULL(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        fAccount_journal_Delete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 12, gsID, dtpDATE.Value)
                    End If

                End If
                '================================


                fExecutedOnly("DELETE FROM credit_memo WHERE ID = '" & gsID & "' limit 1;")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)

                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                gsID = ""
                gsNew = True
                fCursorLoadingOn(False)
                If gsNew = False Then
                    tsApplyCredits.Enabled = True
                Else
                    tsApplyCredits.Enabled = False
                End If
            End If
        End If


    End Sub
    Private Sub fInvoiceBalance_Update(ByVal gsInvoice As String, prORG_Amount As Double)


        fExecutedOnly("DELETE FROM credit_memo_invoices WHERE CREDIT_MEMO_ID = '" & gsID & "' and INVOICE_ID = '" & gsInvoice & "'")

        Dim total_pay As Double = fGetSumPaymentApplied(gsInvoice, cmbCUSTOMER_ID.SelectedValue) + fGetSumCreditApplied(gsInvoice, cmbCUSTOMER_ID.SelectedValue) + fInvoiceSumTaxApplied_Amount(gsInvoice, cmbCUSTOMER_ID.SelectedValue)
        Dim New_Balance As Double = prORG_Amount - total_pay


        Dim squery As String

        Dim nStatus As Integer = 0
        If 0 >= New_Balance Then
            nStatus = 11
        Else
            nStatus = 2
        End If
        squery = "UPDATE invoice SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsInvoice & "'"
        fExecutedOnly(squery)

    End Sub
    Private Sub tsApplyCredits_Click(sender As Object, e As EventArgs) Handles tsApplyCredits.Click

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If

    End Sub

    Private Sub frmCreditMemo_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmCreditMemo_Shown(sender As Object, e As EventArgs) Handles Me.Shown

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
            gsToolPanelView = False
            fPreviewReport(prPrint_Title & "Report")

        End If
    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then

                fRefreshField(gsID)
                fRefreshItem(gsID)
            End If

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
            gscryRpt.PrintToPrinter(1, False, 0, 0)

        End If
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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 12, 4, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
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

    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = fDgvCounting(dgvProductItem)
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If

        With frmAddItem
            .gsUseItemBatch = True
            .sFormName = Me.Name
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE
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
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            fRemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            fComputed()
        End If
    End Sub

    Private Sub frmCreditMemo_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then
            fRefreshField(gsID)
            fRefreshItem(gsID)
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If
    End Sub

    Private Sub cmbCLASS_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCLASS_ID.SelectedIndexChanged

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
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

        If gsNew = True Then
            Exit Sub
        End If
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
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
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
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub
End Class