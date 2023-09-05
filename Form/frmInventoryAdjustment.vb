Imports System.Data.Odbc
Public Class frmInventoryAdjustment
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim f As Form = New frmFindDocument
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
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
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
    'Private Sub fAddItem_Row(ByVal prAdd As Boolean, ByVal prItem_ID As String, ByVal prUNIT_ID As String, ByVal prNew_Qty As Integer, ByVal prUNIT_BASE_QUANTITY As Integer, ByVal prNew_Value As Double, ByVal prControl_Status As String)
    '    ' Dim cn As New MySqlConnection(mysqlConstr)
    '    Dim Unit_Name As String = fGetFieldValue("unit_of_measure", "ID", prUNIT_ID, "NAME")
    '    Dim dCurrent_Qty As Double = Val(fItemInventoryReturnValue(prItem_ID, cmbLOCATION_ID.SelectedValue, 6, 0, dtpDATE.Value, "ENDING_QUANTITY"))
    '    Dim dQty_Diff As Integer = prNew_Qty - dCurrent_Qty
    '    Dim iAsset_Account_ID As Integer = 0
    '    Dim i_Asset_Value As Double = 0
    '    Dim i_DEFFERENCE_VALUE As Double = 0
    '    Dim i_Current_value As Double = 0
    '    Dim dCOST As Double = Val(fItemInventoryReturnValue(prItem_ID, cmbLOCATION_ID.SelectedValue, 6, 0, dtpDATE.Value, "ENDING_UNIT_COST"))
    '    Try
    '        '   cn.Open()
    '        Dim rd As OdbcDataReader = fReader("select * from item where id = '" & prItem_ID & "' limit 1")
    '        If rd.Read() Then
    '            iAsset_Account_ID = fNumisNULL(rd("ASSET_ACCOUNT_ID"))
    '            If prNew_Value <> 0 Then
    '                i_DEFFERENCE_VALUE = (dCOST * dQty_Diff) - (prNew_Value * dQty_Diff)
    '                i_Asset_Value = prNew_Value * dQty_Diff
    '            Else
    '                i_DEFFERENCE_VALUE = 0
    '                i_Asset_Value = dCOST * dQty_Diff
    '            End If
    '            If prAdd = True Then
    '                dgvItem.Rows.Add("N", prItem_ID, fTextisNULL(rd("CODE")), fTextisNULL(rd("DESCRIPTION")), prUNIT_ID, Unit_Name, dCurrent_Qty, prNew_Qty, dQty_Diff, i_Current_value, prNew_Value, i_Asset_Value, iAsset_Account_ID, prUNIT_BASE_QUANTITY, prControl_Status, i_DEFFERENCE_VALUE)
    '            Else
    '                Dim i As Integer = dgvItem.CurrentRow.Index
    '                With dgvItem.Rows(i)
    '                    .Cells(1).Value = prItem_ID
    '                    .Cells(2).Value = fTextisNULL(rd("CODE"))
    '                    .Cells(3).Value = fTextisNULL(rd("DESCRIPTION"))
    '                    .Cells(4).Value = prUNIT_ID
    '                    .Cells(5).Value = Unit_Name
    '                    .Cells(6).Value = dCurrent_Qty
    '                    .Cells(7).Value = prNew_Qty
    '                    .Cells(8).Value = dQty_Diff
    '                    .Cells(9).Value = i_Current_value
    '                    .Cells(10).Value = prNew_Value
    '                    .Cells(11).Value = i_Asset_Value
    '                    .Cells(12).Value = iAsset_Account_ID
    '                    .Cells(13).Value = prUNIT_BASE_QUANTITY
    '                    If Val(.Cells(0).Value) = 0 Then
    '                        .Cells(14).Value = "A"
    '                    Else
    '                        .Cells(14).Value = prControl_Status
    '                    End If
    '                    .Cells(15).Value = i_DEFFERENCE_VALUE
    '                End With


    '            End If
    '        End If
    '        rd.Close()
    '    Catch ex As Exception
    '        fMessageboxWarning(ex.Message)
    '    End Try
    'End Sub

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvItem.Rows.Count <> 0 And gsNew = False Then
                InventoryVDetailsQuickView(dgvItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmInventoryAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fColumnGrid()
        fClear_Info()
        If gsNew = False Then
            fRefresh_Info()
        End If
        fcolumn_adjustment()
    End Sub
    Private Sub fRefresh_Info()
        Try
            dgvItem.Rows.Clear()
            Dim sQuery As String = "select * from inventory_adjustment where ID = '" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)
            cmbLOCATION_ID.Enabled = False
            dtpDATE.Enabled = False


            fcolumn_adjustment()
            Dim rd As OdbcDataReader = fReader("SELECT a.id,
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
where a.inventory_adjustment_id = '" & gsID & "' order by a.LINE_NO ")

            While rd.Read
                dgvItem.Rows.Add(fNumisNULL(rd("id")), fNumisNULL(rd("item_ID")), fTextisNULL(rd("CODE")), rd("DESCRIPTION"), fNumisNULL(rd("UNIT_ID")), fTextisNULL(rd("UNIT_NAME")), "", "", fNumisNULL(rd("QTY_DIFFERENCE")), "", "", fNumisNULL(rd("ASSET_VALUE")), fNumisNULL(rd("ASSET_ACCOUNT_ID")), fNumisNULL(rd("unit_base_quantity")), "S", fNumisNULL(rd("VALUE_DIFFERENCE")), fNumisNULL(rd("BATCH_ID")), fTextisNULL(rd("BATCH_NO")))
            End While

            rd.Close()

        Catch ex As Exception

            fMessageboxWarning(ex.Message)

        End Try
        fcolumn_adjustment()
        fItemCount()

        tdgv = New DataGridView
        tdgv = dgvItem
        tQuery = fFieldCollector(Me)

    End Sub

    Private Sub fRefreshCombox()
        fComboBox(cmbADJUSTMENT_TYPE_ID, "select ID,DESCRIPTION FROM inventory_adjustment_type ", "ID", "DESCRIPTION")
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
    End Sub
    Private Sub fClear_Info()
        fRefreshCombox()
        fCLean_and_refresh(Me)


        dgvItem.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
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
        lblCount.Text = fDgvCounting(dgvItem)
    End Sub
    Private Sub fcolumn_adjustment()
        Dim b As Boolean = gsNew
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
        If gsNew = True Then


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
                    .aAdjustment_ID = gsID
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
            fMessageboxInfo("Please select payment adjustment type")
            Exit Sub
        End If

        If dgvItem.Rows.Count = 0 Then
            fMessageboxInfo("No item entry.")
            Exit Sub
        End If


        Try
            lblACCOUNT_ID.Text = fGetFieldValue("inventory_adjustment_type", "ID", cmbADJUSTMENT_TYPE_ID.SelectedValue, "ACCOUNT_ID")
        Catch ex As Exception
        End Try

        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then


            If gsImportActive = False Then

                If dtpDATE.Value = Date.Now.Date Then
                    IsBackDate = False
                Else
                    IsBackDate = True
                End If

            End If

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("INVENTORY_ADJUSTMENT", cmbLOCATION_ID.SelectedValue)
            End If

            gsID = fObjectTypeMap_ID("INVENTORY_ADJUSTMENT")
            Dim sQuery As String = fFieldCollector(Me)
            fExecutedOnly("INSERT INTO inventory_adjustment SET " & sQuery & ",ID = '" & gsID & "',STATUS ='0',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "';")

            gsImportActive = False
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", "", "", 0, cmbLOCATION_ID.SelectedValue)
        Else



            tChangeAccept = True
            fGotChangeTransaction("inventory_adjustment", gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            If gsGotChangeDate = True Then
                'Main
                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(lblACCOUNT_ID.Text), 19, gsID, gsLast_Location_ID, gsLast_Date)
            End If
            If gsGotChangeLocation1 = True Then
                'Main
                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(lblACCOUNT_ID.Text), 19, gsID, dtpDATE.Value, gsLast_Location_ID)
            End If

            Dim sQuery As String = fFieldCollector(Me)
            fExecutedOnly("UPDATE inventory_adjustment SET " & sQuery & " Where ID = '" & gsID & "' limit 1;")
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", "", "", 0, cmbLOCATION_ID.SelectedValue)

        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            Dim T As Integer
            Dim ASSET As Double = fGetTotalAssetValue(T)
            fAccount_Journal_SQL(lblACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbADJUSTMENT_TYPE_ID.SelectedValue, 19, gsID, dtpDATE.Value, T, ASSET, gsJOURNAL_NO_FORM)
        End If
        '===========================================
        fSaveItem()

        If fTransactionCheck(gsID, "INVENTORY_ADJUSTMENT") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If

        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
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
            If gsID <> "" Then
                gsNew = False
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
        gsID = ""
        gsNew = True
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
                            Dim This_Account_ID As Integer = fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)
                            Dim QTY_DIFFERENCE As Double = 0
                            If gsGotChangeDate = True Then
                                fAccount_journal_Change_date(dtpDATE.Value, This_Account_ID, 20, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                QTY_DIFFERENCE = fItem_inventory_change_date_Adjust(dtpDATE.Value, .Cells("ITEM_ID").Value, 6, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If

                            If gsGotChangeLocation1 = True Then
                                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, This_Account_ID, 20, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                QTY_DIFFERENCE = fItem_inventory_change_Location_Adjust(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 6, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If

                            fExecutedOnly($"UPDATE inventory_adjustment_items SET  QTY_DIFFERENCE = '{QTY_DIFFERENCE}',LINE_NO='" & i & "' WHERE ID ='" & r.Cells(0).Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & gsID & "' limit 1;")

                        Else
                            fExecutedOnly("UPDATE inventory_adjustment_items SET  LINE_NO='" & i & "' WHERE ID ='" & r.Cells(0).Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & gsID & "' limit 1;")

                        End If




                    Case "A"

                        Dim i_ID As Double = fObjectTypeMap_ID("INVENTORY_ADJUSTMENT_ITEMS")
                        fExecutedOnly("INSERT INTO inventory_adjustment_items SET INVENTORY_ADJUSTMENT_ID ='" & gsID & "',ID ='" & i_ID & "',LINE_NO='" & i & "',ITEM_ID ='" & r.Cells("ITEM_ID").Value & "',QTY_DIFFERENCE='" & r.Cells("QTY_DIFFERENCE").Value & "',VALUE_DIFFERENCE=" & fGotNullNumber(r.Cells("VALUE_DIFFERENCE").Value) & ",ASSET_ACCOUNT_ID='" & r.Cells("ASSET_ACCOUNT_ID").Value & "',ASSET_VALUE='" & r.Cells("ASSET_VALUE").Value & "',UNIT_ID=" & fGotNullNumber(r.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY=" & fGotNullNumber(r.Cells("UNIT_BASE_QUANTITY").Value) & ",BATCH_ID =" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & ";")
                        fBILL_ITEM_COST_UPDATE_NEW(r.Cells("ITEM_ID").Value, fNumisNULL(r.Cells("NEW_VALUE").Value))
                        r.Cells("ID").Value = i_ID


                        fItem_Inventory_SQL(r.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("QTY_DIFFERENCE").Value, fNumisNULL(r.Cells("NEW_VALUE").Value), 6, i_ID, dtpDATE.Value, fNumisNULL(.Cells("BATCH_ID").Value))
                        '===========================================
                        If gsSkipJournalEntry = False Then
                            fAccount_Journal_SQL(r.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("ITEM_ID").Value, 20, r.Cells("ID").Value, dtpDATE.Value, IIf(r.Cells("QTY_DIFFERENCE").Value >= 0, 0, 1), r.Cells("ASSET_VALUE").Value, gsJOURNAL_NO_FORM)
                        End If
                      '===========================================


                    Case "E"

                        If gsGotChangeDate = True Or gsGotChangeLocation1 = True Then
                            Dim QTY_DIFFERENCE As Double = 0
                            Dim This_Account_ID As Integer = fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)

                            If gsGotChangeDate = True Then
                                fAccount_journal_Change_date(dtpDATE.Value, This_Account_ID, 20, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                                QTY_DIFFERENCE = fItem_inventory_change_date_Adjust(dtpDATE.Value, .Cells("ITEM_ID").Value, 6, fNumisNULL(.Cells("ID").Value), gsLast_Location_ID, gsLast_Date)
                            End If

                            If gsGotChangeLocation1 = True Then
                                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, This_Account_ID, 20, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                                QTY_DIFFERENCE = fItem_inventory_change_Location_Adjust(cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 6, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, gsLast_Location_ID)
                            End If

                            fExecutedOnly("UPDATE inventory_adjustment_items SET QTY_DIFFERENCE ='" & QTY_DIFFERENCE & "',LINE_NO='" & i & "',VALUE_DIFFERENCE=" & fGotNullNumber(r.Cells("VALUE_DIFFERENCE").Value) & ",ASSET_VALUE='" & r.Cells("ASSET_VALUE").Value & "',UNIT_ID=" & fGotNullNumber(r.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY=" & fGotNullNumber(r.Cells("UNIT_BASE_QUANTITY").Value) & "  WHERE ID ='" & r.Cells("ID").Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & gsID & "' limit 1;")

                        Else
                            fExecutedOnly("UPDATE inventory_adjustment_items SET LINE_NO='" & i & "', QTY_DIFFERENCE ='" & r.Cells("QTY_DIFFERENCE").Value & "',VALUE_DIFFERENCE=" & fGotNullNumber(r.Cells("VALUE_DIFFERENCE").Value) & ",ASSET_VALUE='" & r.Cells("ASSET_VALUE").Value & "',UNIT_ID=" & fGotNullNumber(r.Cells("UNIT_ID").Value) & ",UNIT_BASE_QUANTITY=" & fGotNullNumber(r.Cells("UNIT_BASE_QUANTITY").Value) & ",BATCH_ID =" & fGotNullNumber(fNumisNULL(.Cells("BATCH_ID").Value)) & " WHERE ID ='" & r.Cells("ID").Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and  INVENTORY_ADJUSTMENT_ID ='" & gsID & "' limit 1;")

                            fItem_Inventory_SQL(r.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("QTY_DIFFERENCE").Value, fNumisNULL(r.Cells("NEW_VALUE").Value), 6, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("BATCH_ID").Value))
                            '=========================================== 
                            If gsSkipJournalEntry = False Then
                                fAccount_Journal_SQL(r.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, r.Cells("ITEM_ID").Value, 20, r.Cells("ID").Value, dtpDATE.Value, IIf(r.Cells("QTY_DIFFERENCE").Value >= 0, 0, 1), r.Cells("ASSET_VALUE").Value, gsJOURNAL_NO_FORM)
                            End If
                            '===========================================
                        End If



                    Case "D"
                        fExecutedOnly("DELETE FROM inventory_adjustment_items WHERE ID ='" & r.Cells(0).Value & "' and ITEM_ID ='" & r.Cells("ITEM_ID").Value & "' and INVENTORY_ADJUSTMENT_ID ='" & gsID & "' limit 1;")
                        fItemInventoryRemove_SQL(6, fNumisNULL(r.Cells("ID").Value), dtpDATE.Value, fNumisNULL(r.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                        If gsSkipJournalEntry = False Then
                            fAccount_journal_Delete(fNumisNULL(r.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 20, r.Cells("ID").Value, dtpDATE.Value)
                        End If
                End Select
            End With

        Next


        For i As Integer = 0 To dgvItem.Rows.Count - 1
                With dgvItem.Rows(i)
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

        f.AccessibleName = "inventory_adjustment"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClear_Info()
                gsID = f.AccessibleDescription
                gsNew = False
                fRefresh_Info()


            End If


        End If

    End Sub

    Private Sub chxValueAdjustment_CheckedChanged(sender As Object, e As EventArgs) Handles chxValueAdjustment.CheckedChanged
        fcolumn_adjustment()
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click


        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If
            If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                Exit Sub
            End If

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


            If fMessageBoxQuestion(gsMessageQuestion) = True Then
                fCursorLoadingOn(True)
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

                    fAccount_journal_Delete(fNumisNULL(lblACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 19, gsID, dtpDATE.Value)

                End If
                '===========================================
                fExecutedOnly("DELETE FROM inventory_adjustment where ID = '" & gsID & "' limit 1;")

                fPop_Up_Msg(Me.Text, gsDeleteStr, True)

                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", "", "", 0, cmbLOCATION_ID.SelectedValue)
                gsID = ""
                gsNew = True
                fClear_Info()
                fCursorLoadingOn(False)
            End If
        End If
    End Sub

    Private Sub frmInventoryAdjustment_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmInventoryAdjustment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fdgvItemDisplay(dgvItem)
        fDgvNotSort(dgvItem)



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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 19, lblACCOUNT_ID.Text, cmbADJUSTMENT_TYPE_ID.Text, txtCODE.Text, txtNOTES.Text)
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

                fRefresh_Info()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub dgvItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvItem.RowsAdded
        fItemCount()
    End Sub


    Private Sub dgvItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItem.RowStateChanged
        lblCount.Text = fDgvCounting(dgvItem)
    End Sub

    Private Sub tsChangeDate_Click(sender As Object, e As EventArgs)


    End Sub

    Private Function fGetInventoryAdjustmentENDING(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prSOURCE_REF_ID As Integer) As Double
        Dim T_QTY As Double = 0

        Dim rd As OdbcDataReader = fReader($"SELECT i.ENDING_QUANTITY FROM item_inventory  AS i WHERE i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' AND i.SOURCE_REF_TYPE ='6' and SOURCE_REF_ID = '{prSOURCE_REF_ID}' order by i.ID desc Limit 1 ")
        If rd.Read Then

            T_QTY = fNumisNULL(rd("ENDING_QUANTITY"))

        End If
        rd.Close()
        Return T_QTY
    End Function

    Private Sub ChangeDateToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If gsNew = True Then
            Exit Sub
        End If
        If Val(gsID) <> 0 Then

            If dgvItem.Rows.Count <> 0 Then

                If gsAdmin_User = False Then
                    fMessageboxWarning("Sorry, You Are Not Allowed to Change Date")
                    Exit Sub
                End If


                frmSelectDate.ShowDialog()
                If frmSelectDate.gsOK = True Then
                    If frmSelectDate.dtpSelect.Value = dtpDATE.Value Then

                        fMessageboxInfo($"{dtpDATE.Value} is already applied.")
                        Exit Sub

                    Else
                        If fMessageBoxQuestion("Do you want to proceed") = True Then
                            fCursorLoadingOn(True)
                            dtpDATE.Value = frmSelectDate.dtpSelect.Value
                            fExecutedOnly($"Update inventory_adjustment SET `DATE` = '{fDateFormatMYSQL(dtpDATE.Value)}'  Where ID = '{gsID}' and LOCATION_ID ='" & cmbLOCATION_ID.SelectedValue & "' limit 1")

                            Dim rd As OdbcDataReader = fReader($"SELECT * FROM inventory_adjustment_items AS ii WHERE ii.`INVENTORY_ADJUSTMENT_ID` = '{gsID}' ")
                            While rd.Read

                                Dim dCurrent_Qty As Double = fQTY_ACTUAL_ON_DATE_LOCATION(rd("ITEM_ID"), dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
                                Dim prNew_Qty As Double = fGetInventoryAdjustmentENDING(rd("ITEM_ID"), cmbLOCATION_ID.SelectedValue, rd("ID"))
                                Dim dQty_Diff As Integer = prNew_Qty - dCurrent_Qty

                                fExecutedOnly($"UPDATE inventory_adjustment_items SET QTY_DIFFERENCE = '{dQty_Diff}' WHERE ID ='{rd("ID")}' LIMIT 1;")

                                fExecutedOnly($"UPDATE item_inventory SET SOURCE_REF_DATE = '{fDateFormatMYSQL(dtpDATE.Value)}',QUANTITY='{dQty_Diff}', ENDING_QUANTITY = '{prNew_Qty}' WHERE `ITEM_ID` = '{rd("ITEM_ID")}' AND `LOCATION_ID` = '{cmbLOCATION_ID.SelectedValue}' AND SOURCE_REF_TYPE ='6' and SOURCE_REF_ID = '{rd("ID")}' Limit 1;")

                                fExecutedOnly($"UPDATE account_journal SET SEQUENCE_GROUP = '{dtpDATE.Value.Year}' , OBJECT_DATE ='{fDateFormatMYSQL(dtpDATE.Value)}' WHERE SUBSIDIARY_ID = '{rd("ITEM_ID")}' and OBJECT_TYPE = '20' and OBJECT_ID ='{rd("ID")}' and LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}' and ACCOUNT_ID ='{rd("ASSET_ACCOUNT_ID")}' limit 1;")

                            End While
                            'Item Inventory
                            fSetNew()
                            fCursorLoadingOn(False)
                            fMessageboxInfo("Change date complete.")


                        End If
                    End If
                    frmSelectDate.Dispose()
                    frmSelectDate = Nothing
                    fCursorLoadingOn(False)
                End If
            End If

        End If
    End Sub

    Private Sub RecomputeWithNewCostToolStripMenuItem_Click(sender As Object, e As EventArgs)
    End Sub

    Private Function fgetInventoryEndningUnitCost(ByVal prITEM_ID As Integer, ByVal prOB_ID As Integer) As Double
        Dim dCOST As Double = 0
        Dim rd As OdbcDataReader = fReader($"SELECT ENDING_UNIT_COST from item_inventory where LOCATION_ID ='{cmbLOCATION_ID}' and SOURCE_REF_DATE ='{fDateFormatMYSQL(dtpDATE.Value)}' and item_Id = '{prITEM_ID}' and SOURCE_REF_ID = '{prOB_ID}' and SOURCE_REF_TYPE ='6' LIMIT 1")
        If rd.Read Then
            dCOST = fNumisNULL(rd("ENDING_UNIT_COST"))
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

            gsID = ""
            gsNew = True
            gsBIR_Active = False
            dgvItem.Rows.Clear()
            fCursorLoadingOn(True)
            For i As Integer = 0 To gsBIR_dgvImportBIRItemList.Rows.Count - 1
                Dim item_ID As Integer = 0

                With gsBIR_dgvImportBIRItemList.Rows(i)
                    Dim rd As OdbcDataReader = fReader($"select * from item where `code`='{ fTextisNULL(.Cells("code").Value)}' limit 1")
                    If rd.Read Then
                        '  fAddItem_Inventory_Row(dgvItem, True, fNumisNULL(rd("ID")), fNumisNULL(rd("BASE_UNIT_ID")), fNumisNULL(.Cells("qty").Value), 1, fNumisNULL(rd("COST")), "A", cmbLOCATION_ID.SelectedValue, dtpDATE.Value,)
                    End If
                    rd.Close()

                End With

            Next
            gsImportActive = True
            fCursorLoadingOn(False)


            Exit Sub
        End If


        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then

            fRefresh_Info()
        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If gsNew = True Then
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
                If fNumisNULL(dgvItem.Rows(i).Cells(0).Value) <> 0 Then
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
        fGetQuickFind(dgvItem, tsFindText.Text)
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

    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged

    End Sub

    Private Sub ToolStripLabel1_Click(sender As Object, e As EventArgs) Handles ToolStripLabel1.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub
End Class