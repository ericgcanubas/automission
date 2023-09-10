Imports System.Data.Odbc

Public Class FrmStockReceived
    Dim f As Form = New FrmFindDocument
    Dim bRefreshItem As Boolean = False
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvStock, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvStock.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvStock.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvStock.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmStockTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm

        fcolumngrid()
        fClear_Info()

        If IsNew = False Then
            fRefresh_info()
            fRefresh_item()
            fComputed()
        End If
        bRefreshItem = True
    End Sub
    Private Sub fInventorySetUpdate()
        For I As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(I)
                fUpdateItemInventory_AccountJournalCost(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ID").Value, 28, 97)
            End With
        Next
    End Sub

    Private Sub fClear_Info()
        fRefreshComboBox()
        ClearAndRefresh(Me)

        dgvStock.Rows.Clear()

        cmbLOCATION_ID.SelectedValue = gsStorage_Location_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()

        cmbTRANSFER_TO_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbTRANSFER_TO_ID.Enabled = IsLockLocation()

        dtpDATE.Value = TransactionDefaultDate()
    End Sub
    Private Sub fRefresh_item()
        dgvStock.Rows.Clear()

        Try
            Dim sQuery As String = "SELECT s.`ID`,s.`ITEM_ID`,i.`CODE`, i.`DESCRIPTION`,s.`QUANTITY`,u.`NAME`,s.`UNIT_ID`,s.`UNIT_BASE_QUANTITY`,s.`UNIT_COST`,s.`UNIT_PRICE`,s.`AMOUNT`,s.`RETAIL_VALUE`,s.`ASSET_ACCOUNT_ID`,'S' AS `CONTROL_STATUS`  FROM STOCK_RECEIVED_items AS s INNER JOIN item AS i ON i.`ID` = s.`ITEM_ID` LEFT OUTER JOIN unit_of_measure AS u ON u.`ID` = s.`UNIT_ID` WHERE s.STOCK_RECEIVED_ID = '" & ID & "'"

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            Dim x As Integer = 0

            While rd.Read
                dgvStock.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvStock.Columns(i)

                        If fCheckNumStandard(.Name) = True Then
                            dgvStock.Rows(x).Cells(i).Value = NumberFormatStandard(NumIsNull(rd(i)))

                        ElseIf CheckNumNoDecimal(.Name) = True Then

                            dgvStock.Rows(x).Cells(i).Value = NumberFormatNoDecimal(NumIsNull(rd(i)))
                        Else
                            dgvStock.Rows(x).Cells(i).Value = TextIsNull(rd(i))
                        End If
                    End With

                Next
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh_item()
            Else
                End
            End If
        End Try
        bRefreshItem = False

        fComputed()
        tdgv = New DataGridView
        tdgv = dgvStock
        tQuery = SqlUpdate(Me)

        bRefreshItem = True
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
            .Item("UNIT_COST").Visible = False

            .Add("UNIT_PRICE", gsCUSTOM_RATE) '9
            .Item("UNIT_PRICE").Visible = False

            .Add("AMOUNT", $"{gsCUSTOM_COST} Amount")
            .Item("AMOUNT").Visible = False

            .Add("RETAIL_VALUE", $"{gsCUSTOM_RATE} Amount") '11
            .Item("RETAIL_VALUE").Visible = False

            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID")
            .Item("ASSET_ACCOUNT_ID").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS")
            .Item("CONTROL_STATUS").Visible = False
            .Add("BILL_ITEM_ID", "BILL_ITEM_ID")
            .Item("BILL_ITEM_ID").Visible = False

            .Add("BATCH_ID", "BATCH_ID")
            .Item("BATCH_ID").Visible = False
            .Add("BATCH_NO", gsCUSTOM_BATCH)
            .Item("BATCH_NO").Visible = gsExpiredReference
        End With
    End Sub

    Private Sub fRefresh_info()

        Try
            Dim squery As String = "Select * from STOCK_RECEIVED where id = '" & ID & "' limit 1"

            SqlExecutedUsingReading(Me, squery)


        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh_info()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub fRefreshComboBox()

        ComboBoxLoad(cmbPREPARED_BY_ID, "select * from contact where type='2'", "ID", "NAME")

        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")

        ComboBoxLoad(cmbTRANSFER_TO_ID, "select * from location where ID <> '" & cmbLOCATION_ID.SelectedValue & "' AND Inactive ='0' order by NAME ", "ID", "NAME")

    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub cmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        Try
            ComboBoxLoad(cmbTRANSFER_TO_ID, "select * from location where ID <> '" & cmbLOCATION_ID.SelectedValue & "' AND Inactive ='0' ", "ID", "NAME")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub lklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub fEditItem()
        If dgvStock.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim d As DataGridViewRow = dgvStock.Rows(dgvStock.CurrentRow.Index)
        With frmAddItem
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
                fRow_Data_StockReceived(dgvStock, False, .gsItem_ID, .gsQty, .gsBase_Qty, .gsUM, .gsUnit_Price, .gsAmount, "E", dgvStock.CurrentRow.Cells("BILL_ITEM_ID").Value)
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
            ' total_cost = total_cost + Format(dgvStock.Rows(i).Cells("AMOUNT").Value, "FIXED")
            total_retail = total_retail + NumberFormatFixed(NumIsNull(dgvStock.Rows(i).Cells("RETAIL_VALUE").Value))
            total_cost = total_cost + NumberFormatFixed(NumIsNull(dgvStock.Rows(i).Cells("AMOUNT").Value))
        Next

        lblAMOUNT.Text = NumberFormatFixed(total_cost)
        lblRETAIL_VALUE.Text = NumberFormatFixed(total_retail)


    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        gsGotChangeLocation2 = False

        If Val(cmbPREPARED_BY_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select received by")
            Exit Sub
        End If
        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If
        lblACCOUNT_ID.Text = gsSTOCK_RECEIVED_ACCOUNT_ID

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then
            dtpDATE.Checked = True
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("STOCK_RECEIVED", cmbLOCATION_ID.SelectedValue)
            End If


            ID = ObjectTypeMapId("STOCK_RECEIVED")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO stock_received ({SQL_Field},ID,RECORDED_ON,STATUS) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',0) ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbPREPARED_BY_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else



            tChangeAccept = True

            GotChangeTransactionToStockReceived(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbTRANSFER_TO_ID.SelectedValue)

            If gsGotChangeDate = True Then
                'Main
                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(lblACCOUNT_ID.Text), 96, ID, gsLast_Location_ID, gsLast_Date)
                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(lblACCOUNT_ID.Text), 96, ID, gsLast_location_Transfer_ID, gsLast_Date)
            End If

            If gsGotChangeLocation1 = True Then
                'Source
                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(lblACCOUNT_ID.Text), 96, ID, dtpDATE.Value, gsLast_Location_ID)
            End If

            If gsGotChangeLocation2 = True Then
                'Transfer
                AccountJournalChangeLocation(cmbTRANSFER_TO_ID.SelectedValue, NumIsNull(lblACCOUNT_ID.Text), 96, ID, dtpDATE.Value, gsLast_location_Transfer_ID)
            End If

            SqlExecuted("UPDATE stock_received SET " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbPREPARED_BY_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If


        If IsTransactionSuccess(ID, "STOCK_RECEIVED") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        Else



            '===========================================
            If gsSkipJournalEntry = False Then
                gsJOURNAL_NO_FORM = 0

                'LOCATION
                fAccount_Journal_SQL(lblACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbTRANSFER_TO_ID.SelectedValue, 96, ID, dtpDATE.Value, 0, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
                'Transfer to
                fAccount_Journal_SQL(lblACCOUNT_ID.Text, cmbTRANSFER_TO_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 96, ID, dtpDATE.Value, 1, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

            End If
            '===========================================




            fSaveItem()
            SaveNotify(Me, IsNew)

        End If
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
            If ID > 0 Then
                IsNew = False
                fRefresh_info()
                fRefresh_item()
            End If
        End Try


    End Sub

    Private Sub fSetNew()
        fClear_Info()
        ID = 0
        IsNew = True

    End Sub

    Private Sub fSaveItem()
        '97 = obj
        '28 = src

        For i As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        SqlExecuted("UPDATE stock_received_items SET LINE_NO='" & i & "' WHERE id = '" & Val(.Cells("ID").Value) & "' and Stock_received_ID = '" & ID & "' LIMIT 1;")

                        If gsSkipJournalEntry = False Then
                            If gsGotChangeDate = True Then
                                'Main
                                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 97, .Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 97, .Cells("ID").Value, gsLast_location_Transfer_ID, gsLast_Date)


                            End If
                            If gsGotChangeLocation1 = True Then
                                'Source
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 97, .Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)

                            End If
                            If gsGotChangeLocation2 = True Then
                                'Transfer
                                AccountJournalChangeLocation(cmbTRANSFER_TO_ID.SelectedValue, NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 97, .Cells("ID").Value, dtpDATE.Value, gsLast_location_Transfer_ID)

                            End If
                        End If

                        If gsGotChangeDate = True Then
                            'MaiN
                            ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 28, .Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                            ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 28, .Cells("ID").Value, gsLast_location_Transfer_ID, gsLast_Date)
                        End If
                        If gsGotChangeLocation1 = True Then
                            'Source
                            ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 28, .Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                        End If
                        If gsGotChangeLocation2 = True Then
                            'Transfer
                            ItemInventoryChangeLocation(cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 28, .Cells("ID").Value, dtpDATE.Value, gsLast_location_Transfer_ID)
                        End If


                    Case "A"
                        Dim i_ID As Double = ObjectTypeMapId("stock_received_items")
                        SqlExecuted("INSERT INTO stock_received_items SET id = '" & i_ID & "',LINE_NO='" & i & "',Stock_received_ID = '" & ID & "',item_id ='" & .Cells("item_ID").Value & "',QUANTITY='" & .Cells("QUANTITY").Value & "',UNIT_ID = " & GotNullNumber(.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY='" & .Cells("UNIT_BASE_QUANTITY").Value & "',UNIT_COST='" & NumIsNull(.Cells("UNIT_COST").Value) & "',UNIT_PRICE='" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',AMOUNT='" & NumIsNull(.Cells("AMOUNT").Value) & "',RETAIL_VALUE='" & NumIsNull(.Cells("RETAIL_VALUE").Value) & "',ASSET_ACCOUNT_ID =" & GotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & ";")

                        .Cells("ID").Value = i_ID

                        'INVENTORY ITEM
                        fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("QUANTITY").Value) * -1, NumIsNull(.Cells("UNIT_COST").Value), 28, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))
                        fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, NumIsNull(.Cells("QUANTITY").Value), NumIsNull(.Cells("UNIT_COST").Value), 28, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))

                        If gsSkipJournalEntry = False Then
                            'Location
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 97, NumIsNull(.Cells("ID").Value), dtpDATE.Value, 1, NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                            'Transfer to
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 97, NumIsNull(.Cells("ID").Value), dtpDATE.Value, 0, NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If

                    Case "E"
                        SqlExecuted("UPDATE stock_transfer_Items SET LINE_NO='" & i & "',item_id ='" & .Cells("item_ID").Value & "',QUANTITY='" & NumIsNull(.Cells("QUANTITY").Value) & "',UNIT_ID = " & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",UNIT_BASE_QUANTITY='" & .Cells("UNIT_BASE_QUANTITY").Value & "',UNIT_COST='" & NumIsNull(.Cells("UNIT_COST").Value) & "',UNIT_PRICE='" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',AMOUNT='" & NumIsNull(.Cells("AMOUNT").Value) & "',RETAIL_VALUE='" & NumIsNull(.Cells("RETAIL_VALUE").Value) & "',ASSET_ACCOUNT_ID =" & GotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & ",BATCH_ID =" & GotNullNumber(NumIsNull(.Cells("BATCH_ID").Value)) & " WHERE id = '" & Val(.Cells("ID").Value) & "' and Stock_received_ID  = '" & ID & "' limit 1;")

                        If gsSkipJournalEntry = False Then
                            'Location
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 97, NumIsNull(.Cells("ID").Value), dtpDATE.Value, 1, NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                            'Transfer to
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 97, NumIsNull(.Cells("ID").Value), dtpDATE.Value, 0, NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If

                        fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("QUANTITY").Value) * -1, NumIsNull(.Cells("UNIT_COST").Value), 7, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))
                        fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, NumIsNull(.Cells("QUANTITY").Value), NumIsNull(.Cells("UNIT_COST").Value), 7, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))

                    Case "D"
                        SqlExecuted("DELETE FROM stock_received_items  WHERE ID='" & Val(.Cells(0).Value) & "' and Stock_received_ID = '" & ID & "' limit 1;")

                        If gsSkipJournalEntry = False Then
                            'Location
                            fAccount_journal_Delete(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 97, NumIsNull(.Cells("ID").Value), dtpDATE.Value)
                            'Transfer to
                            fAccount_journal_Delete(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, 97, NumIsNull(.Cells("ID").Value), dtpDATE.Value)
                        End If

                        fItemInventoryRemove_SQL(28, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue)
                        fItemInventoryRemove_SQL(28, NumIsNull(.Cells("ID").Value), dtpDATE.Value, NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)

                End Select
            End With
        Next





        For i As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(i)
                If .Cells("CONTROL_STATUS").Value = "D" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, dtpDATE.Value)
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, dtpDATE.Value)
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    If Date.Now.Date <> dtpDATE.Value Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, dtpDATE.Value)
                    End If
                    .Cells("CONTROL_STATUS").Value = "S"
                End If
            End With
        Next





    End Sub
    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
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

        f.AccessibleName = "stock_received"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClear_Info()
                ID = f.AccessibleDescription
                IsNew = False
                fRefresh_info()
                fRefresh_item()

            End If


        End If


    End Sub



    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)
                fRefresh_info()
                fRefresh_item()
                CursorLoadingOn(True)
                For N As Integer = 0 To dgvStock.Rows.Count - 1
                    dgvStock.Rows(N).Cells("CONTROL_STATUS").Value = "D"
                Next

                fSaveItem()

                '===========================================
                If gsSkipJournalEntry = False Then
                    'LOCATION
                    fAccount_journal_Delete(NumIsNull(lblACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 96, ID, dtpDATE.Value)
                    'Transfer to
                    fAccount_journal_Delete(NumIsNull(lblACCOUNT_ID.Text), cmbTRANSFER_TO_ID.SelectedValue, 96, ID, dtpDATE.Value)

                End If
                '===========================================



                SqlExecuted("DELETE from stock_received WHERE ID ='" & ID & "' limit 1;")
                DeleteNotify(Me)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbPREPARED_BY_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fClear_Info()
                ID = 0
                IsNew = True
                CursorLoadingOn(False)
            End If
        End If
    End Sub

    Private Sub frmStockTransfer_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        If Me.Text = Me.Name Then Exit Sub
        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            fRefresh_info()
            fRefresh_item()
        End If
    End Sub

    Private Sub frmStockTransfer_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ViewItemDisplay(dgvStock)
        ViewNotSort(dgvStock)
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
            If SecurityAccessPrint(Me) = False Then
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

            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
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

            If SecurityAccessPrint(Me) = False Then
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
            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
            fTransactionJournal(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 96, gsSTOCK_RECEIVED_ACCOUNT_ID, cmbTRANSFER_TO_ID.Text, txtCODE.Text, txtNOTES.Text)

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
                fClear_Info()
                fRefresh_info()
                fRefresh_item()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvStock_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvStock.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count

    End Sub
    Private Sub tsPRequest_Click(sender As Object, e As EventArgs) Handles tsPRequest.Click

        If dgvStock.Rows.Count <> 0 Then
            MessageBoxInfo("Item must empty.")
            Exit Sub
        End If

        frmPRAvailable.dgv = dgvStock
        frmPRAvailable.ShowDialog()
        frmPRAvailable.Dispose()
        frmPRAvailable = Nothing

    End Sub

    Private Sub dgvStock_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvStock.RowsAdded
        If bRefreshItem = True Then
            fComputed()
        End If

    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        With frmAddItem
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

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvStock.Rows.Count <> 0 Then
                Dim i As Integer = dgvStock.CurrentRow.Index

                If NumIsNull(dgvStock.Rows(i).Cells(0).Value) <> 0 Then
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

    Private Sub tsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvStock, tsFindText.Text)
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

        If SecurityAccessPrint(Me) = False Then
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
            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False
                GlobalPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub
End Class