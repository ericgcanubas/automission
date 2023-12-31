﻿Imports System.Data.Odbc
Public Class FrmCreditMemo

    Public gsMemberDiscount As Double = 0
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
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
    Private Sub DgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub FrmCreditMemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm

        ColumnGrid()
        ClearInfo()

        If IsNew = False Then
            RefreshField()
            RefreshItem()
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If

        GS_ViewItemDisplay(dgvProductItem)
        GS_ViewNotSort(dgvProductItem)
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
    Private Sub RefreshField()

        Try
            Dim sQuery As String = "select * from credit_memo where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshField()
            Else
                End
            End If
        End Try


        If IsNew = False Then
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If
    End Sub
    Private Sub RefreshItem()
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
    WHERE  ii.`credit_memo_id` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0
            ' cn.Open()
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

                If CBool(GF_NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If

                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItem()
            Else
                End
            End If
        End Try

        bRefreshItem = False
        Computed()
        tdgv = New DataGridView
        tdgv = dgvProductItem
        tQuery = SqlUpdate(Me)

    End Sub

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
    Private Sub Computed()

        Dim dPayment_applied As Double = GF_GetCreditApplied_Amount(ID, cmbCUSTOMER_ID.SelectedValue)
        Dim gsSalesSubTotal As Double
        GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
        lblAMOUNT_APPLIED.Text = NumberFormatStandard(dPayment_applied)
        lbxUNAPPLIED_AMOUNT.Text = NumberFormatStandard(Val(NumberFormatFixed(lblAMOUNT.Text)) - dPayment_applied)
        lblCount.Text = GF_DataGridViewCounting(dgvProductItem)
    End Sub

    Private Sub ComboxRefresh()
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select * from class", "ID", "NAME")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2'", "ID", "NAME")
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        GS_ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")


    End Sub
    Private Sub ClearInfo()
        ComboxRefresh()
        ClearAndRefresh(Me)
        cmbCUSTOMER_ID.Enabled = True
        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
        dtpDATE.Value = TransactionDefaultDate()
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID
    End Sub

    Private Sub TsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
            Exit Sub
        Else
            If IsNew = False And ID > 0 Then
                If CheckHasChange() = True Then
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

        f.AccessibleName = "credit_memo"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                ClearInfo()
                ID = f.AccessibleDescription
                IsNew = False

                RefreshField()
                RefreshItem()

            End If


        End If

    End Sub

    Private Sub CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        Computed()

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
            If MessageBoxErrorYesNo(ex.Message) = True Then
                CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
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

            If d.Cells("ITEM_ID").Value = 5 Then
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
                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
            FrmAddItem.ShowDialog()
            With FrmAddItem
                If .gsSave = True Then
                    GS_RowDataItemCreditMemo(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID, 0, False, .gsBATCH_ID)
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
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Customer")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If
        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GF_GetNextCode("CREDIT_MEMO", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            ID = ObjectTypeMapId("CREDIT_MEMO")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO credit_memo ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',2,'{GetDateTimeNowSql()}') ")

            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            If GS_IsInventoryLastEntry(dgvProductItem, cmbLOCATION_ID.SelectedValue, 12, dtpDATE.Value) = False Then
                Exit Sub
            End If


            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me)
            Dim nStatus As Integer
            If 0 >= NumberFormatFixed(lbxUNAPPLIED_AMOUNT.Text) Then
                nStatus = 15
            Else
                nStatus = 2
            End If
            squery = squery & ",STATUS='" & nStatus & "',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & ID & "' "
            SqlExecuted("UPDATE credit_memo SET " & squery)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        '================================
        If GF_IsTransactionSuccess(ID, "CREDIT_MEMO") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If


        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            GS_AccountJournalExecute(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 12, ID, dtpDATE.Value, 1, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                GS_JournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 12, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                GS_AccountJournalExecute(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 12, ID, dtpDATE.Value, 0, GF_NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If


        SaveItem()  ' Save item



        SaveNotify(Me, IsNew)


        If IsNew = True Then
            IsNew = False
            'Dim iSelect As Integer
            'With FrmCreditMemoOption
            '    .ShowDialog()
            '    'Create proccess
            '    iSelect = .iSelect
            '    .Dispose()
            'End With
            'FrmCreditMemoOption = Nothing
            'If iSelect = 2 Then
            '    GiveARefund()
            'ElseIf iSelect = 3 Then
            '    ApplytoInvoice()
            '    Exit Sub
            'End If
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
                RefreshField()
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
        gsMemberDiscount = 0

        If IsNew = False Then
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If
    End Sub
    Private Sub SaveItem()
        'src= 12
        'obj =14

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE credit_memo_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE CREDIT_MEMO_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        GS_InventoryJournalProcess(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "A"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("CREDIT_MEMO_ITEMS")
                        SqlExecuted("INSERT INTO credit_memo_items SET   BATCH_ID=" & GotNullNumber(.Cells("BATCH_ID").Value) & ",PRINT_IN_FORMS ='" & GF_NumIsNull(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & GotNullNumber(GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & GotNullNumber(GF_NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & GotNullNumber(GF_NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",CREDIT_MEMO_ID ='" & ID & "',GROUP_LINE_ID = " & GotNullNumber(.Cells("GROUP_LINE_ID").Value) & ";")
                        .Cells("ID").Value = i_ID
                        GS_InventoryJournalProcess(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "E"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE credit_memo_items SET   BATCH_ID=" & GotNullNumber(.Cells("BATCH_ID").Value) & ",LINE_NO='" & i & "',QUANTITY='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & GotNullNumber(GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & GotNullNumber(GF_NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & GotNullNumber(GF_NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE CREDIT_MEMO_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        GS_InventoryJournalProcess(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "D"

                        SqlExecuted("DELETE FROM credit_memo_items WHERE CREDIT_MEMO_ID ='" & ID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "' limit 1;")
                        GS_InventoryJournalProcess(dgvProductItem, i, False, 14, 12, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                End Select
            End With
        Next

    End Sub
    Private Sub ApplytoInvoice()
        With FrmCreditMemoInvoice
            .gsCustomer_ID = cmbCUSTOMER_ID.SelectedValue
            .gsLocation_ID = cmbLOCATION_ID.SelectedValue

            .gsID = ID
            .lblName.Text = cmbCUSTOMER_ID.Text
            .lblDATE.Text = dtpDATE.Value
            .lblCreditAmount.Text = lblAMOUNT.Text
            .lblCODE.Text = txtCODE.Text
            .ShowDialog()

            If .gsOk = True Then

                'ADD UPDATE ' to 
                Computed()
                Dim e As Object = Nothing

                If IsNew = True Then
                    TsSaveNew_Click(1, e)
                End If
            End If
            .Dispose()

        End With


        FrmCreditMemoInvoice = Nothing
    End Sub
    Private Sub GiveARefund()
        If IsNew = True Then
            Dim ob As Object = Nothing
            TsSaveNew_Click(1, ob)
        End If
    End Sub
    Private Sub ApplyToInvoiceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApplyToInvoiceToolStripMenuItem.Click
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
            ApplytoInvoice()
        End If
    End Sub

    Private Sub GiveARefundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GiveARefundToolStripMenuItem.Click
        GiveARefund()
    End Sub
    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If


            If GS_IsInventoryLastEntry(dgvProductItem, cmbLOCATION_ID.SelectedValue, 12, dtpDATE.Value) = False Then
                Exit Sub
            End If


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

            If MessageBoxQuestion(gsMessageQuestion) = True Then

                Try

                    Dim rd As OdbcDataReader = SqlReader("SELECT INVOICE_ID FROM CREDIT_MEMO_INVOICES WHERE CREDIT_MEMO_ID = '" & ID & "'")
                    While rd.Read

                        InvoiceBalanceUpdate(rd("INVOICE_ID"), GF_GetNumberFieldValue("INVOICE", "ID", rd("INVOICE_ID"), "AMOUNT"))

                    End While
                    rd.Close()
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try

                GS_CursorLoadingOn(True)
                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next
                SaveItem()  ' delete
                '===========================================

                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0

                    GS_AccountJournalDelete(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, 12, ID, dtpDATE.Value)

                    If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        GS_AccountJournalDelete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 12, ID, dtpDATE.Value)
                    End If

                End If
                '================================


                SqlExecuted("DELETE FROM credit_memo WHERE ID = '" & ID & "' limit 1;")
                DeleteNotify(Me)

                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True
                GS_CursorLoadingOn(False)
                If IsNew = False Then
                    tsApplyCredits.Enabled = True
                Else
                    tsApplyCredits.Enabled = False
                End If
            End If
        End If


    End Sub
    Private Sub InvoiceBalanceUpdate(ByVal gsInvoice As String, prORG_Amount As Double)
        SqlExecuted("DELETE FROM credit_memo_invoices WHERE CREDIT_MEMO_ID = '" & ID & "' and INVOICE_ID = '" & gsInvoice & "'")
        Dim total_pay As Double = GF_GetSumPaymentApplied(gsInvoice, cmbCUSTOMER_ID.SelectedValue) + GF_GetSumCreditApplied(gsInvoice, cmbCUSTOMER_ID.SelectedValue) + GF_InvoiceSumTaxApplied_Amount(gsInvoice, cmbCUSTOMER_ID.SelectedValue)
        Dim New_Balance As Double = prORG_Amount - total_pay
        Dim squery As String

        Dim nStatus As Integer
        If 0 >= New_Balance Then
            nStatus = 11
        Else
            nStatus = 2
        End If
        squery = "UPDATE invoice SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsInvoice & "'"
        SqlExecuted(squery)

    End Sub


    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
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
            gsToolPanelView = False
            GlobalPreviewReport(prPrint_Title & "Report")

        End If
    End Sub

    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()
        Else
            Dim R As Integer = GF_RefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then

                RefreshField()
                RefreshItem()
            End If

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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 12, 4, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
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

    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = GF_DataGridViewCounting(dgvProductItem)
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If

        With FrmAddItem
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

    Private Sub FrmCreditMemo_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            RefreshField()
            RefreshItem()
            tsApplyCredits.Enabled = True
        Else
            tsApplyCredits.Enabled = False
        End If
    End Sub
    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
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

        If IsNew = True Then
            Exit Sub
        End If
        If SecurityAccessPrint(Me) = False Then
            Exit Sub
        End If

        FrmPrintPage.frmName = Me.Name
        FrmPrintPage.ShowDialog()

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
End Class