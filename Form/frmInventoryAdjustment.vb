Imports System.Data.Odbc
Public Class FrmInventoryAdjustment
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim Frm As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Dim Qty As Double
    Dim Qty_End As Double
    Dim Cost As Double
    Dim Ending_unit_cost As Double
    Dim Ending_cost As Double
    Dim DateStart As Date
    Dim IsBackDate As Boolean = False
    Dim gsImportActive As Boolean = False

    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub
    Private Sub fColumnGrid()
        With dgvItem.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
            .Add("CODE", gsCUSTOM_CODE)
            .Item("CODE").Width = 110
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION)
            .Add("UNIT_ID", "Unit_ID")
            .Item("UNIT_ID").Visible = False
            .Add("UNIT_NAME", gsCUSTOM_UNIT)
            .Item("UNIT_NAME").Width = 100
            .Add("CURRENT_QTY", "Current. Qty")
            .Item("CURRENT_QTY").Width = 90
            .Add("NEW_QTY", "New Qty")
            .Item("NEW_QTY").Width = 90
            .Add("QTY_DIFFERENCE", "Qty Difference")
            .Item("QTY_DIFFERENCE").Visible = False
            .Item("QTY_DIFFERENCE").Width = 90

            .Add("Curr_Value", "Current Value")
            .Item("Curr_Value").Visible = False
            .Item("Curr_Value").Width = 90

            .Add("New_Value", "New Value")
            .Item("New_Value").Visible = False
            .Item("New_Value").Width = 90
            .Add("ASSET_VALUE", "ASSET_VALUE")
            .Item("ASSET_VALUE").Visible = False
            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID")
            .Item("ASSET_ACCOUNT_ID").Visible = False
            .Add("UNIT_BASE_QUANTITY", "UNIT_BASE_QUANTITY")
            .Item("UNIT_BASE_QUANTITY").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS")
            .Item("CONTROL_STATUS").Visible = False

            .Add("VALUE_DIFFERENCE", "Value Difference")
            .Item("VALUE_DIFFERENCE").Visible = False

            .Add("BATCH_ID", "BATCH_ID")
            .Item("BATCH_ID").Visible = False
            .Add("BATCH_NO", gsCUSTOM_BATCH)
            .Item("BATCH_NO").Visible = gsExpiredReference

        End With
    End Sub
    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmInventoryAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm

        fColumnGrid()
        fClear_Info()
        If IsNew = False Then
            fRefresh_Info()
        End If
        fcolumn_adjustment()
    End Sub
    Private Sub fRefresh_Info()
        Try
            dgvItem.Rows.Clear()
            Dim sQuery As String = "select * from inventory_adjustment where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)
            cmbLOCATION_ID.Enabled = False
            dtpDATE.Enabled = False


            fcolumn_adjustment()
            Dim rd As OdbcDataReader = SqlReader("SELECT a.id,
a.item_ID,
i.CODE,
i.DESCRIPTION,
a.Unit_ID,
u.Name AS `unit_name`,
a.QTY_DIFFERENCE,
a.VALUE_DIFFERENCE,
a.unit_base_quantity,
a.asset_account_id,
a.ASSET_VALUE,
a.BATCH_ID,
b.BATCH_NO
FROM inventory_adjustment_items AS a 
LEFT OUTER JOIN item AS i
ON i.id = a.item_id 
LEFT OUTER JOIN unit_of_measure AS u
ON u.id = a.unit_id 
LEFT OUTER JOIN item_batches AS b 
ON b.id = a.batch_ID 
where a.inventory_adjustment_id = '" & ID & "' order by a.LINE_NO ")

            While rd.Read
                dgvItem.Rows.Add(NumIsNull(rd("id")), NumIsNull(rd("item_ID")), TextIsNull(rd("CODE")), rd("DESCRIPTION"), NumIsNull(rd("UNIT_ID")), TextIsNull(rd("UNIT_NAME")), "", "", NumIsNull(rd("QTY_DIFFERENCE")), "", "", NumIsNull(rd("ASSET_VALUE")), NumIsNull(rd("ASSET_ACCOUNT_ID")), NumIsNull(rd("unit_base_quantity")), "S", NumIsNull(rd("VALUE_DIFFERENCE")), NumIsNull(rd("BATCH_ID")), TextIsNull(rd("BATCH_NO")))
            End While

            rd.Close()

        Catch ex As Exception

            MessageBoxWarning(ex.Message)

        End Try
        fcolumn_adjustment()
        fItemCount()

        tdgv = New DataGridView
        tdgv = dgvItem
        tQuery = SqlUpdate(Me)

    End Sub

    Private Sub fRefreshCombox()
        ComboBoxLoad(cmbADJUSTMENT_TYPE_ID, "select ID,DESCRIPTION FROM inventory_adjustment_type ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
    End Sub
    Private Sub fClear_Info()
        fRefreshCombox()
        ClearAndRefresh(Me)


        dgvItem.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
    End Sub

    Private Sub cmbADJUSTMENT_TYPE_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbADJUSTMENT_TYPE_ID.SelectedIndexChanged

    End Sub

    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub fItemCount()
        If dgvItem.Rows.Count <> 0 Then

            cmbADJUSTMENT_TYPE_ID.Enabled = False
        Else
            cmbADJUSTMENT_TYPE_ID.Enabled = True
        End If
        lblCount.Text = DataGridViewCounting(dgvItem)
    End Sub
    Private Sub fcolumn_adjustment()
        Dim b As Boolean = IsNew
        With dgvItem.Columns

            If b = True Then

                .Item("VALUE_DIFFERENCE").Visible = Not b
                .Item("CURRENT_QTY").Visible = True
                .Item("NEW_QTY").Visible = True

                If chxValueAdjustment.Checked = True Then
                    .Item("QTY_DIFFERENCE").Visible = False
                    .Item("NEW_VALUE").Visible = True
                    .Item("CURR_VALUE").Visible = True
                Else
                    .Item("NEW_VALUE").Visible = False
                    .Item("CURR_VALUE").Visible = False
                    .Item("QTY_DIFFERENCE").Visible = True
                End If

            Else
                .Item("QTY_DIFFERENCE").Visible = True
                .Item("CURRENT_QTY").Visible = False
                .Item("NEW_QTY").Visible = False
                .Item("NEW_VALUE").Visible = False
                .Item("CURR_VALUE").Visible = False

                If chxValueAdjustment.Checked = True Then

                    .Item("VALUE_DIFFERENCE").Visible = True

                Else


                    .Item("VALUE_DIFFERENCE").Visible = False
                End If
            End If





        End With
    End Sub
    Private Sub fEdit_Item()
        If IsNew = True Then


            If dgvItem.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim r As DataGridViewRow = dgvItem.Rows(dgvItem.CurrentRow.Index)
            With frmAddItem
                .gsDate = dtpDATE.Value
                .gsUseItemBatch = True
                .gsCOST_AMOUNT_ONLY = True
                .gsItem_ID = r.Cells("item_ID").Value
                .gsQty = r.Cells("NEW_QTY").Value
                .gsUM = r.Cells("UNIT_ID").Value
                .gsUnit_Price = r.Cells("NEW_VALUE").Value / r.Cells("NEW_QTY").Value
                .xlblDISCOUNT.Visible = False
                .numDiscountValue.Visible = False
                .cmbDiscount_Type.Visible = False
                .lblAmount.Visible = False
                .xlblLabel_Amount.Visible = False
                .chkTax.Visible = False
                .ShowDialog()
                If .gsSave = True Then


                End If

            End With

            frmAddItem.Dispose()
            frmAddItem = Nothing
        Else
            If gsAdmin_User = True Then



                With frmEditAdjustmentItem
                    .aAdjustment_ID = ID
                    .aITEM_ID = dgvItem.CurrentRow.Cells("ITEM_ID").Value
                    .aLocation_ID = cmbLOCATION_ID.SelectedValue
                    .aSOURCE_REF_ID = dgvItem.CurrentRow.Cells("ID").Value
                    .aDGV_Row = dgvItem.CurrentRow
                    .ShowDialog()

                    .Dispose()
                End With
                frmEditAdjustmentItem = Nothing

            Else


            End If

        End If
        fItemCount()
    End Sub



    Private Sub dgvItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellDoubleClick
        fEdit_Item()
    End Sub



    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbADJUSTMENT_TYPE_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select payment adjustment type")
            Exit Sub
        End If

        If dgvItem.Rows.Count = 0 Then
            MessageBoxInfo("No item entry.")
            Exit Sub
        End If


        Try
            lblACCOUNT_ID.Text = GetStringFieldValue("inventory_adjustment_type", "ID", cmbADJUSTMENT_TYPE_ID.SelectedValue, "ACCOUNT_ID")
        Catch ex As Exception
        End Try

        If fACCESS_NEW_EDIT(Me, IsNew) = False Then
            Exit Sub
        End If

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then


            If gsImportActive = False Then

                If dtpDATE.Value = Date.Now.Date Then
                    IsBackDate = False
                Else
                    IsBackDate = True
                End If

            End If

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("INVENTORY_ADJUSTMENT", cmbLOCATION_ID.SelectedValue)
            End If

            ID = ObjectTypeMapId("INVENTORY_ADJUSTMENT")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO inventory_adjustment ({SQL_Field},ID,RECORDED_ON,STATUS) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',0) ")
            gsImportActive = False
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "New", "", "", 0, cmbLOCATION_ID.SelectedValue)
        Else



            tChangeAccept = True
            GotChangeTransaction("inventory_adjustment", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            If gsGotChangeDate = True Then
                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(lblACCOUNT_ID.Text), 19, ID, gsLast_Location_ID, gsLast_Date)
            End If
            If gsGotChangeLocation1 = True Then
                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(lblACCOUNT_ID.Text), 19, ID, dtpDATE.Value, gsLast_Location_ID)
            End If

            Dim sQuery As String = SqlUpdate(Me)
            SqlExecuted("UPDATE inventory_adjustment SET " & sQuery & " Where ID = '" & ID & "'")
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Edit", "", "", 0, cmbLOCATION_ID.SelectedValue)

        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            Dim T As Integer
            Dim ASSET As Double = fGetTotalAssetValue(T)
            fAccount_Journal_SQL(lblACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbADJUSTMENT_TYPE_ID.SelectedValue, 19, ID, dtpDATE.Value, T, ASSET, gsJOURNAL_NO_FORM)
        End If
        '===========================================
        fSaveItem()

        If IsTransactionSuccess(ID, "INVENTORY_ADJUSTMENT") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        cmbLOCATION_ID.Enabled = True
        dtpDATE.Enabled = True

        IsBackDate = False
        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            End If
        Catch ex As Exception
        Finally
            If ID > 0 Then
                IsNew = False
                fRefresh_Info()
            End If
        End Try


    End Sub
    Private Function fGetTotalAssetValue(ByRef TYPE As Integer)
        Dim D As Double = 0
        Dim C As Double = 0
        For I As Integer = 0 To dgvItem.Rows.Count - 1
            With dgvItem.Rows(I)
                If .Cells("QTY_DIFFERENCE").Value >= 0 Then
                    D = D + .Cells("ASSET_VALUE").Value
                Else
                    C = C + .Cells("ASSET_VALUE").Value
                End If

            End With
        Next

        Dim N As Double = 0
        If D > C Then

            If D = 0 Then

                TYPE = 0
                N = D - C
            Else

                TYPE = 1
                N = D - C
            End If

        Else
            If C = 0 Then
                TYPE = 1
            Else
                TYPE = 0
                N = C - D
            End If

        End If

        Return N
    End Function
    Private Sub fSetNew()

        fClear_Info()
        ID = 0
        IsNew = True
        gsImportActive = False
        fcolumn_adjustment()
    End Sub
    Private Sub fSaveItem()


        For i As Integer = 0 To dgvItem.Rows.Count - 1
            Dim r As DataGridViewRow = dgvItem.Rows(i)
            With r
                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        If gsGotChangeDate = True Or gsGotChangeLocation1 = True Then
                            Dim This_Account_ID As Integer = NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)
                            Dim QTY_DIFFERENCE As Double = 0
                            If gsGotChangeDate = True Then
                                AccountJournalChangeDate(dtpDATE.Value, This_Account_ID, 20, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                QTY_DIFFERENCE = ItemInventoryChangeDateAdjust(dtpDATE.Value, .Cells("ITEM_ID").Value, 6, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If

                            If gsGotChangeLocation1 = True Then
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, This_Account_ID, 20, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                QTY_DIFFERENCE = ItemInventoryChangeLocationAdjust(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 6, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If

                            SqlExecuted($"UPDATE inventory_adjustment_items SET  QTY_DIFFERENCE = '{QTY_DIFFERENCE}',LINE_NO='" & i & "' WHERE ID ='" & r.Cells(0).Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & ID & "' limit 1;")

                        Else
                            SqlExecuted("UPDATE inventory_adjustment_items SET  LINE_NO = '" & i & "' WHERE ID ='" & r.Cells(0).Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & ID & "' limit 1;")

                        End If




                    Case "A"

                        Dim i_ID As Double = ObjectTypeMapId("INVENTORY_ADJUSTMENT_ITEMS")
                        SqlExecuted("INSERT INTO inventory_adjustment_items SET INVENTORY_ADJUSTMENT_ID ='" & ID & "',ID ='" & i_ID & "',LINE_NO='" & i & "',ITEM_ID ='" & r.Cells("ITEM_ID").Value & "',QTY_DIFFERENCE='" & r.Cells("QTY_DIFFERENCE").Value & "',VALUE_DIFFERENCE=" & GotNullNumber(r.Cells("VALUE_DIFFERENCE").Value) & ",ASSET_ACCOUNT_ID='" & r.Cells("ASSET_ACCOUNT_ID").Value & "',ASSET_VALUE='" & r.Cells("ASSET_VALUE").Value & "',UNIT_ID=" & GotNullNumber(r.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY=" & GotNullNumber(r.Cells("UNIT_BASE_QUANTITY").Value) & ",BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & ";")
                        fBILL_ITEM_COST_UPDATE_NEW(r.Cells("ITEM_ID").Value, NumIsNull(r.Cells("NEW_VALUE").Value))
                        r.Cells("ID").Value = i_ID


                        fItem_Inventory_SQL(r.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("QTY_DIFFERENCE").Value, NumIsNull(r.Cells("NEW_VALUE").Value), 6, i_ID, dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))
                        '===========================================
                        If gsSkipJournalEntry = False Then
                            fAccount_Journal_SQL(r.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("ITEM_ID").Value, 20, r.Cells("ID").Value, dtpDATE.Value, IIf(r.Cells("QTY_DIFFERENCE").Value >= 0, 0, 1), r.Cells("ASSET_VALUE").Value, gsJOURNAL_NO_FORM)
                        End If
                      '===========================================


                    Case "E"

                        If gsGotChangeDate = True Or gsGotChangeLocation1 = True Then
                            Dim QTY_DIFFERENCE As Double = 0
                            Dim This_Account_ID As Integer = NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)

                            If gsGotChangeDate = True Then
                                AccountJournalChangeDate(dtpDATE.Value, This_Account_ID, 20, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                QTY_DIFFERENCE = ItemInventoryChangeDateAdjust(dtpDATE.Value, .Cells("ITEM_ID").Value, 6, NumIsNull(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If

                            If gsGotChangeLocation1 = True Then
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, This_Account_ID, 20, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                QTY_DIFFERENCE = ItemInventoryChangeLocationAdjust(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 6, NumIsNull(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If

                            SqlExecuted("UPDATE inventory_adjustment_items SET QTY_DIFFERENCE ='" & QTY_DIFFERENCE & "',LINE_NO='" & i & "',VALUE_DIFFERENCE=" & GotNullNumber(r.Cells("VALUE_DIFFERENCE").Value) & ",ASSET_VALUE='" & r.Cells("ASSET_VALUE").Value & "',UNIT_ID=" & GotNullNumber(r.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY=" & GotNullNumber(r.Cells("UNIT_BASE_QUANTITY").Value) & "  WHERE ID ='" & r.Cells("ID").Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & ID & "' limit 1;")

                        Else
                            SqlExecuted("UPDATE inventory_adjustment_items SET LINE_NO='" & i & "', QTY_DIFFERENCE ='" & r.Cells("QTY_DIFFERENCE").Value & "',VALUE_DIFFERENCE=" & GotNullNumber(r.Cells("VALUE_DIFFERENCE").Value) & ",ASSET_VALUE='" & r.Cells("ASSET_VALUE").Value & "',UNIT_ID=" & GotNullNumber(r.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY=" & GotNullNumber(r.Cells("UNIT_BASE_QUANTITY").Value) & ",BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & " WHERE ID ='" & r.Cells("ID").Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & ID & "' limit 1;")

                            fItem_Inventory_SQL(r.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("QTY_DIFFERENCE").Value, NumIsNull(r.Cells("NEW_VALUE").Value), 6, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))
                            '=========================================== 
                            If gsSkipJournalEntry = False Then
                                fAccount_Journal_SQL(r.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("ITEM_ID").Value, 20, r.Cells("ID").Value, dtpDATE.Value, IIf(r.Cells("QTY_DIFFERENCE").Value >= 0, 0, 1), r.Cells("ASSET_VALUE").Value, gsJOURNAL_NO_FORM)
                            End If
                            '===========================================
                        End If



                    Case "D"
                        SqlExecuted("DELETE FROM inventory_adjustment_items WHERE ID ='" & r.Cells(0).Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and INVENTORY_ADJUSTMENT_ID ='" & ID & "' limit 1;")
                        fItemInventoryRemove_SQL(6, NumIsNull(r.Cells("ID").Value), dtpDATE.Value, NumIsNull(r.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                        If gsSkipJournalEntry = False Then
                            fAccount_journal_Delete(NumIsNull(r.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 20, r.Cells("ID").Value, dtpDATE.Value)
                        End If
                End Select
            End With

        Next


        For i As Integer = 0 To dgvItem.Rows.Count - 1
            With dgvItem.Rows(i)
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

    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub
        Else
            If IsNew = False And ID > 0 Then
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

        Frm.AccessibleName = "inventory_adjustment"
        Frm.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        Frm.ShowDialog()
        If Frm.AccessibleDescription <> "" Then
            If Frm.AccessibleDescription <> "cancel" Then
                fClear_Info()
                ID = Frm.AccessibleDescription
                IsNew = False
                fRefresh_Info()


            End If


        End If

    End Sub

    Private Sub chxValueAdjustment_CheckedChanged(sender As Object, e As EventArgs) Handles chxValueAdjustment.CheckedChanged
        fcolumn_adjustment()
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click


        If IsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If
            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

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


            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)
                For I As Integer = 0 To dgvItem.Rows.Count - 1
                    dgvItem.Rows(I).Cells("CONTROL_STATUS").Value = "D"
                Next
                fSaveItem()

                'Inventory re-Compute
                fDeleteItem_INVENTORY_ITEM_RECALCULATE(dgvItem, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                'End re-compute
                Dim SQL_STR As String = ""
                '===========================================
                If gsSkipJournalEntry = False Then

                    fAccount_journal_Delete(NumIsNull(lblACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 19, ID, dtpDATE.Value)

                End If
                '===========================================
                SqlExecuted("DELETE FROM inventory_adjustment where ID = '" & ID & "' limit 1;")

                PrompNotify(Me.Text, DeleteMsg, True)

                fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Delete", "", "", 0, cmbLOCATION_ID.SelectedValue)
                ID = 0
                IsNew = True
                fClear_Info()
                CursorLoadingOn(False)
            End If
        End If
    End Sub

    Private Sub frmInventoryAdjustment_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmInventoryAdjustment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewItemDisplay(dgvItem)
        ViewNotSort(dgvItem)



    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        'PREVIEW =====================================================================
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
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            fPreviewReport(prPrint_Title)
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'PRINT ========================================================================

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
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
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
            fTransactionJournal(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 19, lblACCOUNT_ID.Text, cmbADJUSTMENT_TYPE_ID.Text, txtCODE.Text, txtNOTES.Text)
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

                fRefresh_Info()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, ID)
    End Sub

    Private Sub dgvItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvItem.RowsAdded
        fItemCount()
    End Sub


    Private Sub dgvItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItem.RowStateChanged
        lblCount.Text = DataGridViewCounting(dgvItem)
    End Sub

    Private Sub tsChangeDate_Click(sender As Object, e As EventArgs)


    End Sub

    Private Function fGetInventoryAdjustmentENDING(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prSOURCE_REF_ID As Integer) As Double
        Dim T_QTY As Double = 0

        Dim rd As OdbcDataReader = SqlReader($"SELECT i.ENDING_QUANTITY FROM item_inventory  AS i WHERE i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' AND i.SOURCE_REF_TYPE ='6' and SOURCE_REF_ID = '{prSOURCE_REF_ID}' order by i.ID desc Limit 1 ")
        If rd.Read Then

            T_QTY = NumIsNull(rd("ENDING_QUANTITY"))

        End If
        rd.Close()
        Return T_QTY
    End Function

    Private Sub ChangeDateToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If IsNew = True Then
            Exit Sub
        End If
        If Val(ID) <> 0 Then

            If dgvItem.Rows.Count <> 0 Then

                If gsAdmin_User = False Then
                    MessageBoxWarning("Sorry, You Are Not Allowed to Change Date")
                    Exit Sub
                End If


                frmSelectDate.ShowDialog()
                If frmSelectDate.gsOK = True Then
                    If frmSelectDate.dtpSelect.Value = dtpDATE.Value Then

                        MessageBoxInfo($"{dtpDATE.Value} is already applied.")
                        Exit Sub

                    Else
                        If MessageBoxQuestion("Do you want to proceed") = True Then
                            CursorLoadingOn(True)
                            dtpDATE.Value = frmSelectDate.dtpSelect.Value
                            SqlExecuted($"Update inventory_adjustment SET `DATE` = '{DateFormatMySql(dtpDATE.Value)}'  Where ID = '{ID}' and LOCATION_ID ='" & cmbLOCATION_ID.SelectedValue & "' limit 1")

                            Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM inventory_adjustment_items AS ii WHERE ii.`INVENTORY_ADJUSTMENT_ID` = '{ID}' ")
                            While rd.Read

                                Dim dCurrent_Qty As Double = QtyActualOnDateLocation(rd("ITEM_ID"), dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
                                Dim prNew_Qty As Double = fGetInventoryAdjustmentENDING(rd("ITEM_ID"), cmbLOCATION_ID.SelectedValue, rd("ID"))
                                Dim dQty_Diff As Integer = prNew_Qty - dCurrent_Qty

                                SqlExecuted($"UPDATE inventory_adjustment_items SET QTY_DIFFERENCE = '{dQty_Diff}' WHERE ID ='{rd("ID")}' LIMIT 1;")

                                SqlExecuted($"UPDATE item_inventory SET SOURCE_REF_DATE = '{DateFormatMySql(dtpDATE.Value)}',QUANTITY='{dQty_Diff}', ENDING_QUANTITY = '{prNew_Qty}' WHERE `ITEM_ID` = '{rd("ITEM_ID")}' AND `LOCATION_ID` = '{cmbLOCATION_ID.SelectedValue}' AND SOURCE_REF_TYPE ='6' and SOURCE_REF_ID = '{rd("ID")}' Limit 1;")

                                SqlExecuted($"UPDATE account_journal SET SEQUENCE_GROUP = '{dtpDATE.Value.Year}' , OBJECT_DATE ='{DateFormatMySql(dtpDATE.Value)}' WHERE SUBSIDIARY_ID = '{rd("ITEM_ID")}' and OBJECT_TYPE = '20' and OBJECT_ID ='{rd("ID")}' and LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}' and ACCOUNT_ID ='{rd("ASSET_ACCOUNT_ID")}' limit 1;")

                            End While
                            'Item Inventory
                            fSetNew()
                            CursorLoadingOn(False)
                            MessageBoxInfo("Change date complete.")


                        End If
                    End If
                    frmSelectDate.Dispose()
                    frmSelectDate = Nothing
                    CursorLoadingOn(False)
                End If
            End If

        End If
    End Sub

    Private Sub RecomputeWithNewCostToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Function fgetInventoryEndningUnitCost(ByVal prITEM_ID As Integer, ByVal prOB_ID As Integer) As Double
        Dim dCOST As Double = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT ENDING_UNIT_COST from item_inventory where LOCATION_ID ='{cmbLOCATION_ID}' and SOURCE_REF_DATE ='{DateFormatMySql(dtpDATE.Value)}' and item_Id = '{prITEM_ID}' and SOURCE_REF_ID = '{prOB_ID}' and SOURCE_REF_TYPE ='6' LIMIT 1")
        If rd.Read Then
            dCOST = NumIsNull(rd("ENDING_UNIT_COST"))
        End If
        rd.Close()

        Return dCOST
    End Function

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmInventoryAdjustment_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        If gsBIR_Active = True Then

            cmbADJUSTMENT_TYPE_ID.SelectedValue = gsBIR_Adjustment_Type_ID
            cmbLOCATION_ID.SelectedValue = gsBIR_LOCATION_ID
            dtpDATE.Value = gsBIR_Date

            dtpDATE.Enabled = False
            cmbLOCATION_ID.Enabled = False

            ID = 0
            IsNew = True
            gsBIR_Active = False
            dgvItem.Rows.Clear()
            CursorLoadingOn(True)
            For i As Integer = 0 To gsBIR_dgvImportBIRItemList.Rows.Count - 1
                Dim item_ID As Integer = 0

                With gsBIR_dgvImportBIRItemList.Rows(i)
                    Dim rd As OdbcDataReader = SqlReader($"select * from item where `code`='{ TextIsNull(.Cells("code").Value)}' limit 1")
                    If rd.Read Then
                        '  fAddItem_Inventory_Row(dgvItem, True, NumIsNull(rd("ID")), NumIsNull(rd("BASE_UNIT_ID")), NumIsNull(.Cells("qty").Value), 1, NumIsNull(rd("COST")), "A", cmbLOCATION_ID.SelectedValue, dtpDATE.Value,)
                    End If
                    rd.Close()

                End With

            Next
            gsImportActive = True
            CursorLoadingOn(False)


            Exit Sub
        End If


        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then

            fRefresh_Info()
        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If IsNew = True Then
            With frmAddItem
                .gsUseItemBatch = True
                .dgv = dgvItem
                .gsNew = True
                .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
                .gsDate = dtpDATE.Value
                .sFormName = Me.Name
                .gsCOST_AMOUNT_ONLY = True
                .xlblDISCOUNT.Visible = False
                .numDiscountValue.Visible = False
                .cmbDiscount_Type.Visible = False
                .lblAmount.Visible = False
                .xlblLabel_Amount.Visible = False
                .chkTax.Visible = False
                .ShowDialog()
                'If .gsSave = True Then
                '    fAddItem_Row(True, .gsItem_ID, .gsUM, .gsQty, .gsBase_Qty, .gsUnit_Price, "A")
                'End If
            End With
            frmAddItem.Dispose()
            frmAddItem = Nothing
            tsAddItem.Select()
        End If
        fItemCount()
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEdit_Item()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvItem.CurrentRow.Index
                If NumIsNull(dgvItem.Rows(i).Cells(0).Value) <> 0 Then
                    dgvItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvItem.Rows(i).Visible = False
                Else
                    dgvItem.Rows.RemoveAt(i)
                End If
            End If
        Catch ex As Exception
        Finally
            fItemCount()
        End Try
    End Sub

    Private Sub dtpDATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpDATE.ValueChanged
        If dtpDATE.Value > Date.Now.Date Then
            dtpDATE.Value = Date.Now.Date
        End If

    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvItem, tsFindText.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'Select Print Page ============================================================
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
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
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

    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class