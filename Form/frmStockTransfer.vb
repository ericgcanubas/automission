Imports System.Data.Odbc

Public Class FrmStockTransfer
    Dim f As Form = New FrmFindDocument
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Private Function CheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvStock, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub DgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvStock.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvStock.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvStock.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub FrmStockTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm

        ColumnGrid()
        ClearInfo()

        xlblcost_total.Text = $"{gsCUSTOM_COST} Total"
        xlblrate_total.Text = $"{gsCUSTOM_RATE} Total"

        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If
    End Sub
    Private Sub InventorySetUpdateOnly()
        For I As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(I)
                GS_UpdateItemInventory_AccountJournalCost(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ID").Value, 7, 39)
            End With
        Next
    End Sub

    Private Sub ClearInfo()
        RefreshComboBox()
        ClearAndRefresh(Me)

        dgvStock.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
    End Sub
    Private Sub RefreshItem()
        dgvStock.Rows.Clear()

        Try
            Dim sQuery As String = "SELECT s.`ID`,s.`ITEM_ID`,i.`CODE`, i.`DESCRIPTION`,s.`QUANTITY`,u.`NAME`,s.`UNIT_ID`,s.`UNIT_BASE_QUANTITY`,s.`UNIT_COST`,s.`UNIT_PRICE`,s.`AMOUNT`,s.`RETAIL_VALUE`,s.`ASSET_ACCOUNT_ID`,'S' AS `CONTROL_STATUS`  FROM stock_transfer_items AS s INNER JOIN item AS i ON i.`ID` = s.`ITEM_ID` LEFT OUTER JOIN unit_of_measure AS u ON u.`ID` = s.`UNIT_ID` WHERE s.Stock_Transfer_ID = '" & ID & "'"

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            Dim x As Integer = 0

            While rd.Read
                dgvStock.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvStock.Columns(i)


                        If GF_CheckNumStandard(.Name) = True Then
                            dgvStock.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))

                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then

                            dgvStock.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        Else
                            dgvStock.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                        End If
                    End With
                Next
                x += 1
            End While
            rd.Close()
            Computed()
            tdgv = New DataGridView
            tdgv = dgvStock
            tQuery = SqlUpdate(Me)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItem()
            Else
                End
            End If
        End Try


    End Sub
    Private Function GetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub ColumnGrid()
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

    Private Sub RefreshInfo()

        Try
            Dim squery As String = "Select * from stock_transfer where id = '" & ID & "' limit 1"

            SqlExecutedUsingReading(Me, squery)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub RefreshComboBox()

        GS_ComboBoxLoad(cmbPREPARED_BY_ID, "select * from contact where type='2'", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbTRANSFER_TO_ID, "select * from location where ID <> '" & cmbLOCATION_ID.SelectedValue & "' AND Inactive ='0' order by NAME ", "ID", "NAME")

    End Sub
    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        Try
            GS_ComboBoxLoad(cmbTRANSFER_TO_ID, "select * from location where ID <> '" & cmbLOCATION_ID.SelectedValue & "' AND Inactive ='0' ", "ID", "NAME")
        Catch ex As Exception

        End Try

    End Sub
    Private Sub EditItem()
        If dgvStock.Rows.Count = 0 Then
            Exit Sub
        End If
        Dim d As DataGridViewRow = dgvStock.Rows(dgvStock.CurrentRow.Index)
        With FrmAddItem

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
                GS_RowDataStockTransfer(dgvStock, False, .gsItem_ID, .gsQty, .gsBase_Qty, .gsUM, .gsUnit_Price, .gsAmount, "E", .gsBATCH_ID)
            End If
            .Dispose()
        End With
        FrmAddItem = Nothing
        Computed()
    End Sub
    Private Sub DgvStock_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellDoubleClick
        EditItem()
    End Sub
    Private Sub Computed()

        Dim total_retail As Double = 0
        For i As Integer = 0 To dgvStock.Rows.Count - 1
            total_retail += NumberFormatFixed(dgvStock.Rows(i).Cells("RETAIL_VALUE").Value)
        Next

        lblRETAIL_VALUE.Text = NumberFormatFixed(total_retail)

        ComputedTotalCost()
    End Sub
    Private Sub ComputedTotalCost()

        Dim temp_total_cost As Double = 0
        For i As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(i).Cells
                temp_total_cost += GF_NumIsNull(.Item("AMOUNT").Value)
            End With
        Next
        lblAMOUNT.Text = NumberFormatFixed(temp_total_cost)

    End Sub
    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbPREPARED_BY_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select prepared by")
            Exit Sub
        End If
        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then


            lblACCOUNT_ID.Text = gsSTOCK_TRANSFER_ACCOUNT_ID
            dtpDATE.Checked = True

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GF_GetNextCode("STOCK_TRANSFER", cmbLOCATION_ID.SelectedValue)
            End If


            ID = ObjectTypeMapId("STOCK_TRANSFER")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO stock_transfer ({SQL_Field},ID,RECORDED_ON,STATUS) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',0) ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbPREPARED_BY_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else


            If GS_IsInventoryLastEntry(dgvStock, cmbLOCATION_ID.SelectedValue, 7, dtpDATE.Value) = False Then
                Exit Sub
            End If


            tChangeAccept = True
            GotChangeTransactionToStockTransfer(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbTRANSFER_TO_ID.SelectedValue)

            If gsGotChangeDate = True Then
                'Main
                AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(lblACCOUNT_ID.Text), 38, ID, gsLast_Location_ID, gsLast_Date)
                AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(lblACCOUNT_ID.Text), 38, ID, gsLast_location_Transfer_ID, gsLast_Date)
            End If

            If gsGotChangeLocation1 = True Then
                'Source
                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, GF_NumIsNull(lblACCOUNT_ID.Text), 38, ID, dtpDATE.Value, gsLast_Location_ID)
            End If

            If gsGotChangeLocation2 = True Then
                'Transfer
                AccountJournalChangeLocation(cmbTRANSFER_TO_ID.SelectedValue, GF_NumIsNull(lblACCOUNT_ID.Text), 38, ID, dtpDATE.Value, gsLast_location_Transfer_ID)
            End If

            SqlExecuted("UPDATE stock_transfer SET " & SqlUpdate(Me) & " Where ID = '" & ID & "' ")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbPREPARED_BY_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If

        If GF_IsTransactionSuccess(ID, "STOCK_TRANSFER") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        End If


        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            'LOCATION
            GS_AccountJournalExecute(lblACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbTRANSFER_TO_ID.SelectedValue, 38, ID, dtpDATE.Value, 0, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            'Transfer to
            GS_AccountJournalExecute(GF_NumIsNull(lblACCOUNT_ID.Text), cmbTRANSFER_TO_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 38, ID, dtpDATE.Value, 1, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)


        End If
        '===========================================


        SaveItem()






        SaveNotify(Me, IsNew)
        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        gsGotChangeLocation2 = False

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = tsSaveNew.Name Then
                SetNew()
            Else
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
        ID = 0
        IsNew = True

    End Sub

    Private Sub SaveItem()


        For i As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        SqlExecuted("UPDATE stock_transfer_Items SET LINE_NO='" & i & "' WHERE id = '" & Val(.Cells("ID").Value) & "' and Stock_transfer_ID = '" & ID & "' LIMIT 1;")

                        If gsSkipJournalEntry = False Then
                            If gsGotChangeDate = True Then
                                'Main
                                AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                                AccountJournalChangeDate(dtpDATE.Value, GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, gsLast_location_Transfer_ID, gsLast_Date)


                            End If
                            If gsGotChangeLocation1 = True Then
                                'Source
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)

                            End If
                            If gsGotChangeLocation2 = True Then
                                'Transfer
                                AccountJournalChangeLocation(cmbTRANSFER_TO_ID.SelectedValue, GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 39, .Cells("ID").Value, dtpDATE.Value, gsLast_location_Transfer_ID)

                            End If
                        End If

                        If gsGotChangeDate = True Then
                            'MaiN
                            ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                            ItemInventoryChangeDate(dtpDATE.Value, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, gsLast_location_Transfer_ID, gsLast_Date)
                        End If
                        If gsGotChangeLocation1 = True Then
                            'Source
                            ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                        End If
                        If gsGotChangeLocation2 = True Then
                            'Transfer
                            ItemInventoryChangeLocation(cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 7, .Cells("ID").Value, dtpDATE.Value, gsLast_location_Transfer_ID)
                        End If


                    Case "A"
                        Dim i_ID As Double = ObjectTypeMapId("stock_transfer_Items")
                        SqlExecuted("INSERT INTO stock_transfer_Items SET BATCH_ID =" & GotNullNumber(GF_NumIsNull(.Cells("BATCH_ID").Value)) & ",id = '" & i_ID & "',LINE_NO='" & i & "',Stock_transfer_ID = '" & ID & "',item_id ='" & .Cells("item_ID").Value & "',QUANTITY='" & .Cells("QUANTITY").Value & "',UNIT_ID = " & GotNullNumber(.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY='" & .Cells("UNIT_BASE_QUANTITY").Value & "',UNIT_COST='" & GF_NumIsNull(.Cells("UNIT_COST").Value) & "',UNIT_PRICE='" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',AMOUNT='" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',RETAIL_VALUE='" & GF_NumIsNull(.Cells("RETAIL_VALUE").Value) & "',ASSET_ACCOUNT_ID =" & GotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & ";")

                        .Cells("ID").Value = i_ID

                        'INVENTORY ITEM
                        StockTransfer_Inventory(dgvStock, i)

                        If gsSkipJournalEntry = False Then
                            'Location
                            GS_AccountJournalExecute(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, 1, GF_NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                            'Transfer to
                            GS_AccountJournalExecute(.Cells("ASSET_ACCOUNT_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, 0, GF_NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If

                    Case "E"
                        SqlExecuted("UPDATE stock_transfer_Items SET BATCH_ID =" & GotNullNumber(GF_NumIsNull(.Cells("BATCH_ID").Value)) & ",LINE_NO='" & i & "',item_id ='" & .Cells("item_ID").Value & "',QUANTITY='" & GF_NumIsNull(.Cells("QUANTITY").Value) & "',UNIT_ID = " & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",UNIT_BASE_QUANTITY='" & .Cells("UNIT_BASE_QUANTITY").Value & "',UNIT_COST='" & GF_NumIsNull(.Cells("UNIT_COST").Value) & "',UNIT_PRICE='" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',AMOUNT='" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',RETAIL_VALUE='" & GF_NumIsNull(.Cells("RETAIL_VALUE").Value) & "',ASSET_ACCOUNT_ID =" & GotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & " WHERE id = '" & Val(.Cells("ID").Value) & "' and Stock_transfer_ID = '" & ID & "' limit 1;")

                        If gsSkipJournalEntry = False Then
                            'Location
                            GS_AccountJournalExecute(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, 1, GF_NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                            'Transfer to
                            GS_AccountJournalExecute(.Cells("ASSET_ACCOUNT_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, .Cells("ITEM_ID").Value, 39, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, 0, GF_NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If


                        StockTransfer_Inventory(dgvStock, i)

                    Case "D"
                        SqlExecuted("DELETE FROM stock_transfer_Items  WHERE ID='" & Val(.Cells(0).Value) & "' and Stock_transfer_ID = '" & ID & "' limit 1;")

                        If gsSkipJournalEntry = False Then
                            'Location
                            GS_AccountJournalDelete(GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 39, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value)
                            'Transfer to
                            GS_AccountJournalDelete(GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), cmbTRANSFER_TO_ID.SelectedValue, 39, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value)
                        End If

                        GS_ItemInventoryRemove(7, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, GF_NumIsNull(.Cells("ITEM_ID").Value), cmbTRANSFER_TO_ID.SelectedValue)
                        GS_ItemInventoryRemove(7, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, GF_NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)

                End Select
            End With
        Next





    End Sub
    Private Sub StockTransfer_Inventory(ByVal dgv As DataGridView, ByVal I As Integer)
        Dim SQL_SCRIPT As String = ""
        With dgv.Rows(I)
            Dim QTY_BASE As Integer = GF_NumIsNull(.Cells("UNIT_BASE_QUANTITY").Value)
            Dim QTY_IN As Double = QTY_BASE * GF_NumIsNull(.Cells("QUANTITY").Value)
            GS_Item_Inventory_SQL(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, QTY_IN * -1, GF_NumIsNull(.Cells("UNIT_COST").Value), 7, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, GF_NumIsNull(.Cells("BATCH_ID").Value))
            GS_Item_Inventory_SQL(.Cells("ITEM_ID").Value, cmbTRANSFER_TO_ID.SelectedValue, QTY_IN, GF_NumIsNull(.Cells("UNIT_COST").Value), 7, GF_NumIsNull(.Cells("ID").Value), dtpDATE.Value, GF_NumIsNull(.Cells("BATCH_ID").Value))
        End With
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

        f.AccessibleName = "stock_transfer"
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



    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If


            If GS_IsInventoryLastEntry(dgvStock, cmbLOCATION_ID.SelectedValue, 7, dtpDATE.Value) = False Then
                Exit Sub
            End If



            If MessageBoxQuestion(gsMessageQuestion) = True Then
                RefreshInfo()
                RefreshItem()
                GS_CursorLoadingOn(True)
                For N As Integer = 0 To dgvStock.Rows.Count - 1
                    dgvStock.Rows(N).Cells("CONTROL_STATUS").Value = "D"
                Next

                SaveItem()

                '===========================================
                If gsSkipJournalEntry = False Then
                    GS_AccountJournalDelete(GF_NumIsNull(lblACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 38, ID, dtpDATE.Value)
                    'Transfer to
                    GS_AccountJournalDelete(GF_NumIsNull(lblACCOUNT_ID.Text), cmbTRANSFER_TO_ID.SelectedValue, 38, ID, dtpDATE.Value)

                End If
                '===========================================

                SqlExecuted("Delete from stock_transfer WHERE ID ='" & ID & "' limit 1;")
                DeleteNotify(Me)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbPREPARED_BY_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                ID = 0
                IsNew = True
                GS_CursorLoadingOn(False)
            End If
        Else

        End If
    End Sub
    Private Sub FrmStockTransfer_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        GS_ViewItemDisplay(dgvStock)
        GS_ViewNotSort(dgvStock)
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        'PREVIEW =====================================================================
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
            GlobalPreviewReport(prPrint_Title)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'PRINT ========================================================================

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

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 38, 100, cmbTRANSFER_TO_ID.Text, txtCODE.Text, txtNOTES.Text)

        End If

    End Sub

    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then
                ClearInfo()
                RefreshInfo()
                RefreshItem()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub
    Private Sub DgvStock_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvStock.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub FrmStockTransfer_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If
    End Sub


    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        With FrmAddItem
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
        FrmAddItem = Nothing
        Computed()
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        EditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click

        Try
            If dgvStock.Rows.Count <> 0 Then
                Dim i As Integer = dgvStock.CurrentRow.Index

                If GF_NumIsNull(dgvStock.Rows(i).Cells(0).Value) <> 0 Then
                    dgvStock.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvStock.Rows(i).Visible = False
                Else
                    dgvStock.Rows.RemoveAt(i)
                End If

                Computed()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvStock, tsFindText.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'Select Print Page ============================================================
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

        If IsNew = True Then Exit Sub

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
                GlobalPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If
        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub
End Class