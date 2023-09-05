Imports System.Data.Odbc
'            Dim prFile_name As String = "cryBuildAssembly.rpt"
'            Dim prPrint_Title As String = "Build Assembly"
Public Class frmBuildAssembly
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim Basic_Unit_ID As String = ""
    Dim f As Form = New frmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvComponents, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub
    Private Sub fSetNew()
        fclear_info()
        fComputed()
        gsID = ""
        gsNew = True
    End Sub

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvComponents.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvComponents.Rows.Count <> 0 And gsNew = False Then
                InventoryVDetailsQuickView(dgvComponents.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub frmBuildAssembly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        spJournal.Visible = gsShowAccounts
        tsJounral.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fcolumngrid()
        fclear_info()

        If gsNew = False Then
            fRefreshInfo()
        End If
    End Sub
    Private Sub fclear_info()
        fRefreshCombo()
        fCLean_and_refresh(Me)

        dgvComponents.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub fRefreshInfo()


        Dim sQuery As String = "select * from `build_assembly` where id = '" & gsID & "' limit 1;"
        Try

            fExecutedUsingReading(Me, sQuery)

            fComputed()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo()
            Else
                End
            End If


        Finally
            tdgv = New DataGridView
            tdgv = dgvComponents
            tQuery = fFieldCollector(Me)

        End Try

    End Sub
    Private Sub fRefreshCombo()
        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")

        fComboBox(cmbASSEMBLY_ITEM_ID, "SELECT  ID,DESCRIPTION FROM ITEM WHERE INACTIVE='0' AND TYPE ='1'", "ID", "DESCRIPTION")

    End Sub
    Private Sub fcolumngrid()
        With dgvComponents.Columns
            .Clear()
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False

            .Add("CODE", gsCUSTOM_CODE)
            .Item("CODE").Width = 250
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION)
            .Item("DESCRIPTION").Width = 400
            .Add("QTY_ON_HAND", "Qty OnHand")
            .Item("QTY_ON_HAND").Width = 150
            .Add("QTY_NEEDED", "Qty Need")
            .Item("QTY_NEEDED").Width = 150

            .Add("AMOUNT", gsCUSTOM_AMOUNT)
            .Item("AMOUNT").Visible = False
            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID")
            .Item("ASSET_ACCOUNT_ID").Visible = False
            .Add("BATCH_ID", "BATCH_ID")
            .Item("BATCH_ID").Visible = False
            .Add("BATCH_NO", gsCUSTOM_BATCH)

        End With
    End Sub
    Private Sub fUnit_List()
        Try
            fComboBox(cmbUNIT_ID, "select ID,SYMBOL from unit_of_measure where  ID = '0' limit 1 ", "ID", "SYMBOL")


            Dim in_sql As String = ""
            Basic_Unit_ID = fGetFieldValue("ITEM", "ID", cmbASSEMBLY_ITEM_ID.SelectedValue, "BASE_UNIT_ID") 'Gate Unit Base_ID


            If Basic_Unit_ID <> "" Then

                in_sql = "In ('" & Basic_Unit_ID & "'"




                Dim rd As OdbcDataReader = fReader("select UNIT_ID from item_units where ITEM_ID ='" & cmbASSEMBLY_ITEM_ID.SelectedValue & "'")
                    While rd.Read
                        in_sql = in_sql & ",'" & rd("UNIT_ID") & "'"
                    End While
                    rd.Close()

                    in_sql = in_sql & ")"
                fComboBox(cmbUNIT_ID, "select ID,SYMBOL from unit_of_measure where  ID " & in_sql, "ID", "SYMBOL")
                cmbUNIT_ID.SelectedValue = Basic_Unit_ID
                lblUNIT_BASE_QUANTITY.Text = "1"
            End If
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fUnit_List()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub cmbASSEMBLY_ITEM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbASSEMBLY_ITEM_ID.SelectedIndexChanged
        Try
            fLoadComponents(cmbASSEMBLY_ITEM_ID.SelectedValue)
            fComputed()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub fLoadComponents(ByVal pritem_ID As String)

        dtpDATE.Checked = True
        dgvComponents.Rows.Clear()
        Dim sQuery As String = "Select ic.component_id as `Item_ID`,i.code,i.description,i.cost,i.rate,i.ASSET_ACCOUNT_ID from item_components as ic inner join item as i on i.id = ic.component_id  where ic.Item_ID = '" & pritem_ID & "' order by ic.ID"


        Try

            Dim I_ON_HAND As Double = 0
            Dim i_NEEDED As Double = 0
            Dim i_AMOUNT As Double = 0
            Dim i_ASSET_ACCOUNT_ID As String = ""
            Dim i_ID As Double = 0
            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                i_AMOUNT = rd("COST")
                fGetItemApplied(rd("ITEM_ID"), i_NEEDED, i_AMOUNT, i_ASSET_ACCOUNT_ID, i_ID)

                I_ON_HAND = Val(fItemInventoryReturnValue(rd("ITEM_ID"), cmbLOCATION_ID.SelectedValue, 19, i_ID, dtpDATE.Value, "ENDING_QUANTITY"))
                If i_ASSET_ACCOUNT_ID = "" Then

                    i_ASSET_ACCOUNT_ID = fNumisNULL(rd("ASSET_ACCOUNT_ID"))
                End If

                If gsNew = False And i_NEEDED = 0 Then

                Else
                    dgvComponents.Rows.Add(rd("item_ID"), rd("CODE"), rd("DESCRIPTION"), (I_ON_HAND + i_NEEDED), i_NEEDED, i_AMOUNT, i_ASSET_ACCOUNT_ID)
                End If


            End While
            rd.Close()

            fUnit_List()

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try
        fComputed()
    End Sub
    Private Sub fGetItemApplied(ByVal prItem_ID As String, ByRef prQty As Double, ByRef prAmount As Double, ByVal prASSET_ACCOUNT_ID As String, ByRef prID As Double)

        Try

            Dim rd As OdbcDataReader = fReader("select ID,QUANTITY,AMOUNT,ASSET_ACCOUNT_ID from build_assembly_items where BUILD_ASSEMBLY_ID = '" & gsID & "' and item_ID = '" & prItem_ID & "' Limit 1")
            If rd.Read Then
                prID = fNumisNULL(rd("ID"))
                prQty = fNumisNULL(rd("QUANTITY"))
                prAmount = fNumisNULL(rd("AMOUNT"))
                prASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
            Else
                'prID = 0
                'prQty = 0
                'prAmount = 0
                'prASSET_ACCOUNT_ID = ""
            End If
            rd.Close()
        Catch ex As Exception

            prQty = 0
            prAmount = 0
            prASSET_ACCOUNT_ID = ""
        End Try


    End Sub
    Private Sub FcHANGE_vALUE_nEEDED()

        If dgvComponents.Rows.Count = 0 Then

            Exit Sub
        End If

        Dim i As Integer = dgvComponents.CurrentRow.Index
        frmInsertValue.gsValue = dgvComponents.Rows(i).Cells("QTY_NEEDED").Value
        frmInsertValue.gsDescription = "Quantity Needed"
        frmInsertValue.gsFORM_NAME = "Build Assembly"
        frmInsertValue.ShowDialog()

        If frmInsertValue.bSave = True Then

            Dim i_NEEDED As Double = 0
            Dim i_AMOUNT As Double = 0
            Dim i_ASSET_ACCOUNT_ID As Double = 0
            Dim i_ID As Double = 0


            Dim Qty As Double = frmInsertValue.gsValue
            fGetItemApplied(dgvComponents.Rows(i).Cells("ITEM_ID").Value, i_NEEDED, i_AMOUNT, i_ASSET_ACCOUNT_ID, i_ID)
            Dim END_UNIT_COST As Double = fNumFieldValue("item", "id", dgvComponents.Rows(i).Cells("ITEM_ID").Value, "cost")
            dgvComponents.Rows(i).Cells("QTY_NEEDED").Value = Qty
            dgvComponents.Rows(i).Cells("AMOUNT").Value = fNumFormatFixed(Qty * END_UNIT_COST)
        End If
        frmInsertValue.Dispose()
        frmInsertValue = Nothing

        fComputed()

    End Sub

    Private Sub dgvComponents_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComponents.CellContentClick

    End Sub

    Private Sub dgvComponents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComponents.CellDoubleClick
        FcHANGE_vALUE_nEEDED()
    End Sub

    Private Sub cmbUNIT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUNIT_ID.SelectedIndexChanged

        If Basic_Unit_ID = fNumisNULL(cmbUNIT_ID.SelectedValue) Then
            lblUNIT_BASE_QUANTITY.Text = "1"
        Else

            Try

                Dim rd As OdbcDataReader = fReader("select quantity as q, rate as r from item_units where unit_id = '" & fNumisNULL(cmbUNIT_ID.SelectedValue) & "' and item_id ='" & cmbASSEMBLY_ITEM_ID.SelectedValue & "' limit 1")
                If rd.Read Then
                    If fNumisNULL(rd("q")) <> 0 Then
                        lblUNIT_BASE_QUANTITY.Text = fNumisNULL(rd("q"))
                    Else
                        lblUNIT_BASE_QUANTITY.Text = "1"
                    End If
                End If
                rd.Close()
            Catch ex As Exception
                If fMessageBoxErrorYesNo(ex.Message) = True Then
                    cmbUNIT_ID_SelectedIndexChanged(sender, e)
                Else
                    End
                End If

            End Try

        End If

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbASSEMBLY_ITEM_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Select Item")
            Exit Sub
        End If

        If numQUANTITY.Value = 0 Then
            fMessageboxInfo("Quantity Required!")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If
        gsGotChangeDate = False
        gsGotChangeLocation1 = False

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If


        If gsNew = True Then



            lblASSET_ACCOUNT_ID.Text = gsDefault_ITEM_ACCOUNT_ID
            dtpDATE.Checked = True
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("BUILD_ASSEMBLY", cmbLOCATION_ID.SelectedValue)
            End If

            Dim sQuery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("BUILD_ASSEMBLY")
            sQuery = sQuery & ",ID='" & gsID & "',RECORDED_ON ='" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='15'"
            sQuery = fNullOTherField(sQuery, "BUILD_ASSEMBLY")

            fExecutedOnly("INSERT INTO build_assembly SET " & sQuery & " ;")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", "", "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else



            fGotChangeTransaction("BUILD_ASSEMBLY", gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            If gsGotChangeDate = True Then
                'Main
                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(lblASSET_ACCOUNT_ID.Text), 70, gsID, gsLast_Location_ID, gsLast_Date)
                fItem_inventory_change_date(dtpDATE.Value, cmbASSEMBLY_ITEM_ID.SelectedValue, 19, fNumisNULL(gsID), gsLast_Location_ID, gsLast_Date)
            End If
            If gsGotChangeLocation1 = True Then
                'Main
                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(lblASSET_ACCOUNT_ID.Text), 70, gsID, dtpDATE.Value, gsLast_Location_ID)
                fItem_inventory_change_Location(cmbLOCATION_ID.SelectedValue, cmbASSEMBLY_ITEM_ID.SelectedValue, 19, fNumisNULL(gsID), dtpDATE.Value, gsLast_Location_ID)
            End If



            tChangeAccept = True
            Dim sQuery As String = fFieldCollector(Me)
            fExecutedOnly("UPDATE build_assembly SET " & sQuery & " Where ID ='" & gsID & "' limit 1;")
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", "", "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If




        'INVENTORY ITEM
        fItem_Inventory_SQL(cmbASSEMBLY_ITEM_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, numQUANTITY.Value, 0, 19, fNumisNULL(gsID), dtpDATE.Value, fNumisNULL(cmbBATCH_ID.SelectedValue))

        '  fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(cmbASSEMBLY_ITEM_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(lblASSET_ACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbASSEMBLY_ITEM_ID.SelectedValue, 70, gsID, dtpDATE.Value, 0, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
        End If
        '================================
        fSaveAppliedItem()
        gsGotChangeDate = False
        gsGotChangeLocation1 = False

        If fTransactionCheck(gsID, "BUILD_ASSEMBLY") = False Then
            fMessageboxWarning("Try Again!")
            Exit Sub
        End If



        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
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
                fRefreshInfo()
            End If


        End Try

    End Sub
    Private Sub fSaveAppliedItem()


        For i As Integer = 0 To dgvComponents.Rows.Count - 1
            With dgvComponents.Rows(i)
                Dim qty As Double = .Cells("QTY_NEEDED").Value
                If fCheck_QTY_NEED(.Cells("item_ID").Value) = True Then

                    If qty = 0 Then
                        'DELETE
                        Dim xID As String = fGetFieldValueByTwoCondtion("build_assembly_items", "build_assembly_id", gsID, "item_Id", .Cells("item_ID").Value, "ID")
                        If xID <> "" Then
                            fExecutedOnly("DELETE FROM `build_assembly_items` where  ID = '" & xID & "' limit 1 ")
                            fItemInventoryRemove_SQL(19, xID, dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                            fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                            If gsSkipJournalEntry = False Then
                                fAccount_journal_Delete(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 71, fNumisNULL(xID), dtpDATE.Value)
                            End If
                        End If

                    Else
                        Dim xID As String = fGetFieldValueByTwoCondtion("build_assembly_items", "build_assembly_id", gsID, "item_Id", .Cells("item_ID").Value, "ID")
                        If gsSkipJournalEntry = False Then

                            If gsGotChangeDate = True Then
                                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), 71, fNumisNULL(xID), gsLast_Location_ID, gsLast_Date)
                            End If

                            If gsGotChangeLocation1 = True Then
                                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), 71, fNumisNULL(xID), dtpDATE.Value, gsLast_Location_ID)
                            End If
                        End If

                        If gsGotChangeDate = True Then
                            fItem_inventory_change_date(dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), 19, fNumisNULL(xID), gsLast_Location_ID, gsLast_Date)
                        End If

                        If gsGotChangeLocation1 = True Then
                            fItem_inventory_change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("ITEM_ID").Value), 19, fNumisNULL(xID), dtpDATE.Value, gsLast_Location_ID)
                        End If

                        'UPDATE
                        'MISSING FUNCTION
                        fExecutedOnly($"UPDATE `build_assembly_items` set QUANTITY = '" & fNumisNULL(.Cells("QTY_NEEDED").Value) & "',AMOUNT='" & .Cells("AMOUNT").Value & "',ASSET_ACCOUNT_ID = " & fGotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & " where  id = '" & xID & "' and  build_assembly_id = '" & gsID & "' and item_Id = '" & .Cells("item_ID").Value & "' limit 1;")
                        'INVENTORY ITEM
                        fItem_Inventory_SQL(.Cells("item_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("QTY_NEEDED").Value * -1, 0, 19, fNumisNULL(xID), dtpDATE.Value, fNumisNULL(.Cells("BATCH_ID").Value))
                        '===========================================
                        If gsSkipJournalEntry = False Then
                            fAccount_Journal_SQL(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("item_ID").Value), 71, fNumisNULL(xID), dtpDATE.Value, 1, fNumisNULL(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If
                        '================================

                    End If
                Else

                    If qty <> 0 Then
                        'INSERT
                        Dim i_ID As Double = fObjectTypeMap_ID("build_assembly_items")
                        fExecutedOnly("INSERT INTO `build_assembly_items` SET  ID ='" & i_ID & "', build_assembly_id = '" & gsID & "',item_Id = '" & .Cells("item_ID").Value & "', QUANTITY = '" & .Cells("QTY_NEEDED").Value & "',AMOUNT='" & .Cells("AMOUNT").Value & "',ASSET_ACCOUNT_ID = " & fGotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & ";")
                        'INVENTORY ITEM
                        fItem_Inventory_SQL(.Cells("item_ID").Value, cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("QTY_NEEDED").Value) * -1, 0, 19, fNumisNULL(i_ID), dtpDATE.Value, fNumisNULL(.Cells("BATCH_ID").Value))
                        '===========================================
                        If gsSkipJournalEntry = False Then
                            fAccount_Journal_SQL(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("item_ID").Value, 71, fNumisNULL(i_ID), dtpDATE.Value, 1, fNumisNULL(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If
                        '================================
                    End If

                End If

            End With

        Next

    End Sub
    Private Function fCheck_QTY_NEED(ByVal prItem_ID As String) As Boolean
        Dim v As Boolean = False
        Try

            Dim rd As OdbcDataReader = fReader("select ID from `build_assembly_items` where  build_assembly_id = '" & gsID & "' and item_id = '" & prItem_ID & "' limit 1;")
            If rd.Read Then
                v = True
            End If
            rd.Close()
        Catch ex As Exception
            v = False
        End Try

        Return v
    End Function
    Private Sub fComputed()
        Dim dTotal As Double = 0
        For i As Integer = 0 To dgvComponents.Rows.Count - 1

            dTotal = dTotal + fNumisNULL(dgvComponents.Rows(i).Cells("AMOUNT").Value)

        Next


        lblAMOUNT.Text = fNumFormatFixed(dTotal)
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

        f.AccessibleName = "build_assembly"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                gsID = f.AccessibleDescription
                gsNew = False
                ''
                fclear_info()
                If gsNew = False Then

                    fRefreshInfo()

                End If
            End If

        End If


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
                fCursorLoadingOn(True)
                ' fJournalTransaction_Build_Assembly_Delete(gsID)

                'Inventory re-Compute
                ' fDeleteItem_INVENTORY_ITEM_RECALCULATE(dgvComponents, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                'End re-compute

                For N As Integer = 0 To dgvComponents.Rows.Count - 1
                    With dgvComponents.Rows(N)
                        Dim xID As String = fGetFieldValueByTwoCondtion("build_assembly_items", "build_assembly_id", gsID, "item_Id", .Cells("item_ID").Value, "ID")
                        If xID <> "" Then
                            fExecutedOnly("DELETE FROM `build_assembly_items` where  ID = '" & xID & "' limit 1 ")
                            fItemInventoryRemove_SQL(19, xID, dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                            fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                            If gsSkipJournalEntry = False Then
                                fAccount_journal_Delete(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 71, fNumisNULL(xID), dtpDATE.Value)
                            End If


                        End If
                    End With
                Next


                '===========================================
                If gsSkipJournalEntry = False Then
                    fAccount_journal_Delete(fNumisNULL(lblASSET_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 70, gsID, dtpDATE.Value)
                End If
                '================================

                ' fExecutedOnly("delete from build_assembly_items where build_assembly_id = '" & gsID & "'")
                fExecutedOnly("delete from build_assembly where id = '" & gsID & "' limit 1;")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", "", "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                gsID = ""
                fclear_info()
                gsNew = True
                fCursorLoadingOn(False)
            End If


        End If
    End Sub
    Private Sub frmBuildAssembly_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dgvComponents.Columns
            .Item("CODE").Width = 150
            .Item("DESCRIPTION").Width = 400
        End With
        fDgvNotSort(dgvComponents)
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

    Private Sub dtpDATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpDATE.ValueChanged

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



    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then
                fRefreshInfo()

            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJounral.Click
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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 70, 6, cmbASSEMBLY_ITEM_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmBuildAssembly_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If gsNew = False Then
            fRefreshInfo()
        End If
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

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class