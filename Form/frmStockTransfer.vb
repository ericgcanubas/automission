Imports System.Data.Odbc

Public Class frmStockTransfer
    Dim f As Form = New frmFindDocument

    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvStock, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvStock.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvStock.Rows.Count <> 0 And gsNew = False Then
                InventoryVDetailsQuickView(dgvStock.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmStockTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm

        fcolumngrid()
        fClear_Info()

        xlblcost_total.Text = $"{gsCUSTOM_COST} Total"
        xlblrate_total.Text = $"{gsCUSTOM_RATE} Total"

        If gsNew = False Then
            fRefresh_info()
            fRefresh_item()
        End If
    End Sub
    Private Sub fInventorySetUpdateOnly()
        For I As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(I)
                fUpdateItemInventory_AccountJournalCost(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ID").Value, 7, 39)
            End With
        Next
    End Sub

    Private Sub fClear_Info()
        fRefreshComboBox()
        fCLean_and_refresh(Me)

        dgvStock.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub fRefresh_item()
        dgvStock.Rows.Clear()

        Try
            Dim sQuery As String = "SELECT s.`ID`,s.`ITEM_ID`,i.`CODE`, i.`DESCRIPTION`,s.`QUANTITY`,u.`NAME`,s.`UNIT_ID`,s.`UNIT_BASE_QUANTITY`,s.`UNIT_COST`,s.`UNIT_PRICE`,s.`AMOUNT`,s.`RETAIL_VALUE`,s.`ASSET_ACCOUNT_ID`,'S' AS `CONTROL_STATUS`  FROM stock_transfer_items AS s INNER JOIN item AS i ON i.`ID` = s.`ITEM_ID` LEFT OUTER JOIN unit_of_measure AS u ON u.`ID` = s.`UNIT_ID` WHERE s.Stock_Transfer_ID = '" & gsID & "'"

            Dim rd As OdbcDataReader = fReader(sQuery)
            Dim x As Integer = 0

            While rd.Read
                dgvStock.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvStock.Columns(i)


                        If fCheckNumStandard(.Name) = True Then
                            dgvStock.Rows(x).Cells(i).Value = fNumFormatStandard(fNumisNULL(rd(i)))

                        ElseIf fCheckNumNoDecimal(.Name) = True Then

                            dgvStock.Rows(x).Cells(i).Value = fNumFormatNoDecimal(fNumisNULL(rd(i)))
                        Else
                            dgvStock.Rows(x).Cells(i).Value = fTextisNULL(rd(i))
                        End If
                    End With
                Next
                x = x + 1
            End While
            rd.Close()
            fComputed()
            tdgv = New DataGridView
            tdgv = dgvStock
            tQuery = fFieldCollector(Me)

        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh_item()
            Else
                End
            End If
        End Try


    End Sub
    Private Function fgetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function


    Private Sub fcolumngrid()
        With dgvStock.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
            .Add("CODE", gsCUSTOM_CODE) '2

            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '3

            .Add("QUANTITY", gsCUSTOM_QTY) '4
            .Add("UNIT_DESCRIPTION", gsCUSTOM_UNIT) '5
            .Add("UNIT_ID", "UNIT_ID")
            .Item("UNIT_ID").Visible = False
            .Add("UNIT_BASE_QUANTITY", "UNIT_BASE_QUANTITY")
            .Item("UNIT_BASE_QUANTITY").Visible = False
            .Add("UNIT_COST", gsCUSTOM_COST)
            .Add("UNIT_PRICE", gsCUSTOM_RATE) '9
            .Add("AMOUNT", $"{gsCUSTOM_COST} Amount")
            .Add("RETAIL_VALUE", $"{gsCUSTOM_RATE} Amount") '11

            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID")
            .Item("ASSET_ACCOUNT_ID").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS")
            .Item("CONTROL_STATUS").Visible = False
            .Add("BATCH_ID", "BATCH_ID")
            .Item("BATCH_ID").Visible = False
            .Add("BATCH_NO", gsCUSTOM_BATCH)
        End With
    End Sub

    Private Sub fRefresh_info()

        Try
            Dim squery As String = "Select * from stock_transfer where id = '" & gsID & "' limit 1"

            fExecutedUsingReading(Me, squery)

        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh_info()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub fRefreshComboBox()

        fComboBox(cmbPREPARED_BY_ID, "select * from contact where type='2'", "ID", "NAME")

        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")

        fComboBox(cmbTRANSFER_TO_ID, "select * from location where ID <> '" & cmbLOCATION_ID.SelectedValue & "' AND Inactive ='0' order by NAME ", "ID", "NAME")

    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub

    Private Sub cmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        Try
            fComboBox(cmbTRANSFER_TO_ID, "select * from location where ID <> '" & cmbLOCATION_ID.SelectedValue & "' AND Inactive ='0' ", "ID", "NAME")

        Catch ex As Exception

        End Try

    End Sub


    Private Sub fEditItem()
        If dgvStock.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim d As DataGridViewRow = dgvStock.Rows(dgvStock.CurrentRow.Index)
        With frmAddItem

            .gsUseItemBatch = True
            .xlblDISCOUNT.Visible = False
            .numDiscountValue.Visible = False
            .cmbDiscount_Type.Visible = False
            .chkTax.Visible = False
            .gsItem_ID = d.Cells(1).Value
            .gsQty = d.Cells("QUANTITY").Value
            .gsUM = d.Cells("UNIT_ID").Value
            .gsUnit_Price = d.Cells("UNIT_COST").Value
            .gsCOST_AMOUNT_ONLY = True
            .ShowDialog()

            If .gsSave = True Then
                fRow_Data_StockTransfer(dgvStock, False, .gsItem_ID, .gsQty, .gsBase_Qty, .gsUM, .gsUnit_Price, .gsAmount, "E", .gsBATCH_ID)
            End If
            .Dispose()
        End With
        frmAddItem = Nothing
        fComputed()
    End Sub

    Private Sub dgvStock_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellContentClick

    End Sub

    Private Sub dgvStock_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellDoubleClick
        fEditItem()
    End Sub
    Private Sub fComputed()
        Dim total_cost As Double = 0
        Dim total_retail As Double = 0
        For i As Integer = 0 To dgvStock.Rows.Count - 1
            total_retail = total_retail + fNumFormatFixed(dgvStock.Rows(i).Cells("RETAIL_VALUE").Value)
        Next

        lblRETAIL_VALUE.Text = fNumFormatFixed(total_retail)

        fComputedTotalCost()
    End Sub
    Private Sub fComputedTotalCost()

        Dim temp_total_cost As Double = 0
        For i As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(i).Cells

                temp_total_cost = temp_total_cost + fNumisNULL(.Item("AMOUNT").Value)
            End With
        Next
        lblAMOUNT.Text = fNumFormatFixed(temp_total_cost)

    End Sub
    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbPREPARED_BY_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select prepared by")
            Exit Sub
        End If
        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then


            lblACCOUNT_ID.Text = gsSTOCK_TRANSFER_ACCOUNT_ID
            dtpDATE.Checked = True

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("STOCK_TRANSFER", cmbLOCATION_ID.SelectedValue)
            End If

            Dim sQuery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("STOCK_TRANSFER")
            fExecutedOnly("INSERT INTO stock_transfer SET " & sQuery & ",ID = '" & gsID & "',STATUS ='0',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "';")

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbPREPARED_BY_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else


            tChangeAccept = True


            fGotChangeTransaction_To_Stock_Transfer(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbTRANSFER_TO_ID.SelectedValue)

            If gsGotChangeDate = True Then
                'Main
                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(lblACCOUNT_ID.Text), 38, gsID, gsLast_Location_ID, gsLast_Date)
                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(lblACCOUNT_ID.Text), 38, gsID, gsLast_location_Transfer_ID, gsLast_Date)
            End If

            If gsGotChangeLocation1 = True Then
                'Source
                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(lblACCOUNT_ID.Text), 38, gsID, dtpDATE.Value, gsLast_Location_ID)
            End If

            If gsGotChangeLocation2 = True Then
                'Transfer
                fAccount_journal_Change_Location(cmbTRANSFER_TO_ID.SelectedValue, fNumisNULL(lblACCOUNT_ID.Text), 38, gsID, dtpDATE.Value, gsLast_location_Transfer_ID)
            End If


            Dim sQuery As String = fFieldCollector(Me)
            fExecutedOnly("UPDATE stock_transfer SET " & sQuery & " Where ID = '" & gsID & "' limit 1;")
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbPREPARED_BY_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If





        '===========================================
        If gsSkipJournalEntry = False Then
                gsJOURNAL_NO_FORM = 0

            'LOCATION
            fAccount_Journal_SQL(lblACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbTRANSFER_TO_ID.SelectedValue, 38, gsID, dtpDATE.Value, 0, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            'Transfer to
            fAccount_Journal_SQL(fNumisNULL(lblACCOUNT_ID.Text), cmbTRANSFER_TO_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 38, gsID, dtpDATE.Value, 1, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)


        End If
        '===========================================


        fSaveItem()


        If fTransactionCheck(gsID, "STOCK_TRANSFER") = False Then
            fMessageboxWarning("Please try again")
            Exit Sub
        End If

        fUpdateItemStatus()

        fSavePopUp(Me, gsNew)
        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        gsGotChangeLocation2 = False

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            Else
            End If
        Catch ex As Exception
        Finally
            If gsID <> "" Then
                gsNew = False
                fRefresh_info()
                fRefresh_item()
            End If
        End Try


    End Sub

    Private Sub fSetNew()
        fClear_Info()
        gsID = ""
        gsNew = True

    End Sub

    Private Sub fSaveItem()


        For i As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        fExecutedOnly("UPDATE stock_transfer_Items SET LINE_NO='" & i & "' WHERE id = '" & Val(.Cells("ID").Value) & "' and Stock_transfer_ID = '" & gsID & "' LIMIT 1;")

                        If gsSkipJournalEntry = False Then
                            If gsGotChangeDate = True Then
                                'Main
                                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, gsLast_location_Transfer_ID, gsLast_Date)


                            End If
                            If gsGotChangeLocation1 = True Then
                                'Source
                                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)

                            End If
                            If gsGotChangeLocation2 = True Then
                                'Transfer
                                fAccount_journal_Change_Location(cmbTRANSFER_TO_ID.SelectedValue, fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, dtpDATE.Value, gsLast_location_Transfer_ID)

                            End If
                        End If

                        If gsGotChangeDate = True Then
                            'MaiN
                            fItem_inventory_change_date(dtpDATE.Value, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                            fItem_inventory_change_date(dtpDATE.Value, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, gsLast_location_Transfer_ID, gsLast_Date)
                        End If
                        If gsGotChangeLocation1 = True Then
                            'Source
                            fItem_inventory_change_Location(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                        End If
                        If gsGotChangeLocation2 = True Then
                            'Transfer
                            fItem_inventory_change_Location(cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, dtpDATE.Value, gsLast_location_Transfer_ID)
                        End If


                    Case "A"
                        Dim i_ID As Double = fObjectTypeMap_ID("stock_transfer_Items")
                        fExecutedOnly("INSERT INTO stock_transfer_Items SET BATCH_ID =" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & ",id = '" & i_ID & "',LINE_NO='" & i & "',Stock_transfer_ID = '" & gsID & "',item_id ='" & .Cells("item_ID").Value & "',QUANTITY='" & .Cells("QUANTITY").Value & "',UNIT_ID = " & fGotNullNumber(.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY='" & .Cells("UNIT_BASE_QUANTITY").Value & "',UNIT_COST='" & fNumisNULL(.Cells("UNIT_COST").Value) & "',UNIT_PRICE='" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',AMOUNT='" & fNumisNULL(.Cells("AMOUNT").Value) & "',RETAIL_VALUE='" & fNumisNULL(.Cells("RETAIL_VALUE").Value) & "',ASSET_ACCOUNT_ID =" & fGotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & ";")

                        .Cells("ID").Value = i_ID

                        'INVENTORY ITEM
                        fStockTransfer_Inventory(dgvStock, i)

                        If gsSkipJournalEntry = False Then
                            'Location
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 1, fNumisNULL(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                            'Transfer to
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 0, fNumisNULL(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If

                    Case "E"
                        fExecutedOnly("UPDATE stock_transfer_Items SET BATCH_ID =" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',item_id ='" & .Cells("item_ID").Value & "',QUANTITY='" & fNumisNULL(.Cells("QUANTITY").Value) & "',UNIT_ID = " & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",UNIT_BASE_QUANTITY='" & .Cells("UNIT_BASE_QUANTITY").Value & "',UNIT_COST='" & fNumisNULL(.Cells("UNIT_COST").Value) & "',UNIT_PRICE='" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',AMOUNT='" & fNumisNULL(.Cells("AMOUNT").Value) & "',RETAIL_VALUE='" & fNumisNULL(.Cells("RETAIL_VALUE").Value) & "',ASSET_ACCOUNT_ID =" & fGotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & " WHERE id = '" & Val(.Cells("ID").Value) & "' and Stock_transfer_ID = '" & gsID & "' limit 1;")

                        If gsSkipJournalEntry = False Then
                            'Location
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 1, fNumisNULL(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                            'Transfer to
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 0, fNumisNULL(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If


                        fStockTransfer_Inventory(dgvStock, i)

                    Case "D"
                        fExecutedOnly("DELETE FROM stock_transfer_Items  WHERE ID='" & Val(.Cells(0).Value) & "' and Stock_transfer_ID = '" & gsID & "' limit 1;")

                        If gsSkipJournalEntry = False Then
                            'Location
                            fAccount_journal_Delete(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 39, fNumisNULL(.Cells("ID").Value), dtpDATE.Value)
                            'Transfer to
                            fAccount_journal_Delete(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, 39, fNumisNULL(.Cells("ID").Value), dtpDATE.Value)
                        End If

                        fItemInventoryRemove_SQL(7, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue)
                        fItemInventoryRemove_SQL(7, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)

                End Select
            End With
        Next





    End Sub
    Private Sub fUpdateItemStatus()




        For i As Integer = 0 To dgvStock.Rows.Count - 1
                With dgvStock.Rows(i)
                    If .Cells("CONTROL_STATUS").Value = "D" Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, dtpDATE.Value)
                    ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, dtpDATE.Value)
                        .Cells("CONTROL_STATUS").Value = "S"
                    ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                        If Date.Now.Date <> dtpDATE.Value Then
                            fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                            fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, dtpDATE.Value)
                        End If
                        .Cells("CONTROL_STATUS").Value = "S"
                    End If
                End With
            Next


    End Sub
    Private Sub fStockTransfer_Inventory(ByVal dgv As DataGridView, ByVal I As Integer)
        Dim SQL_SCRIPT As String = ""
        With dgv.Rows(I)
            Dim QTY_BASE As Integer = fNumisNULL(.Cells("UNIT_BASE_QUANTITY").Value)
            Dim QTY_IN As Double = QTY_BASE * fNumisNULL(.Cells("QUANTITY").Value)
            fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, QTY_IN * -1, fNumisNULL(.Cells("UNIT_COST").Value), 7, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("BATCH_ID").Value))
            fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, QTY_IN, fNumisNULL(.Cells("UNIT_COST").Value), 7, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("BATCH_ID").Value))
        End With
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

        f.AccessibleName = "stock_transfer"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClear_Info()
                gsID = f.AccessibleDescription
                gsNew = False
                fRefresh_info()
                fRefresh_item()

            End If


        End If


    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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
                fRefresh_info()
                fRefresh_item()
                fCursorLoadingOn(True)
                For N As Integer = 0 To dgvStock.Rows.Count - 1
                    dgvStock.Rows(N).Cells("CONTROL_STATUS").Value = "D"
                Next

                fSaveItem()

                '===========================================
                If gsSkipJournalEntry = False Then
                    fAccount_journal_Delete(fNumisNULL(lblACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 38, gsID, dtpDATE.Value)
                    'Transfer to
                    fAccount_journal_Delete(fNumisNULL(lblACCOUNT_ID.Text), cmbTRANSFER_TO_ID.SelectedValue, 38, gsID, dtpDATE.Value)

                End If
                '===========================================

                fExecutedOnly("Delete from stock_transfer WHERE ID ='" & gsID & "' limit 1;")
                fDeletePopUp(Me)
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbPREPARED_BY_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fClear_Info()
                gsID = ""
                gsNew = True
                fCursorLoadingOn(False)
            End If
        Else

        End If
    End Sub
    Private Sub frmStockTransfer_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        fdgvItemDisplay(dgvStock)
        fDgvNotSort(dgvStock)
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        'PREVIEW =====================================================================
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
            fPreviewReport(prPrint_Title)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'PRINT ========================================================================

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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 38, 100, cmbTRANSFER_TO_ID.Text, txtCODE.Text, txtNOTES.Text)

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
                fClear_Info()
                fRefresh_info()
                fRefresh_item()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvStock_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvStock.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub CostUpdateSaveToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmStockTransfer_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then
            fRefresh_info()
            fRefresh_item()
        End If
    End Sub


    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        With frmAddItem
            .gsUseItemBatch = True
            .gsCOST_AMOUNT_ONLY = True
            .dgv = dgvStock
            .sFormName = Me.Name
            .xlblDISCOUNT.Visible = False
            .numDiscountValue.Visible = False
            .cmbDiscount_Type.Visible = False
            .chkTax.Visible = False

            .ShowDialog()
            .Dispose()

        End With
        frmAddItem = Nothing
        fComputed()
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click

        Try
            If dgvStock.Rows.Count <> 0 Then
                Dim i As Integer = dgvStock.CurrentRow.Index

                If fNumisNULL(dgvStock.Rows(i).Cells(0).Value) <> 0 Then
                    dgvStock.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvStock.Rows(i).Visible = False
                Else
                    dgvStock.Rows.RemoveAt(i)
                End If

                fComputed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtCODE_TextChanged(sender As Object, e As EventArgs) Handles txtCODE.TextChanged

    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvStock, tsFindText.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'Select Print Page ============================================================
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
                fPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub

    Private Sub tsApplyCredits_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbTRANSFER_TO_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTRANSFER_TO_ID.SelectedIndexChanged

    End Sub
End Class