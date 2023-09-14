Imports System.Data.Odbc

Public Class FrmBuildAssembly
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim Basic_Unit_ID As String = ""
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function CheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvComponents, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub SetNew()
        ClearInfo()
        Computed()
        ID = 0
        IsNew = True
    End Sub

    Private Sub DgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvComponents.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvComponents.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvComponents.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub
    Private Sub FrmBuildAssembly_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        spJournal.Visible = gsShowAccounts
        tsJounral.Visible = gsShowAccounts
        tsTITLE.Text = gsSubMenuForm
        ColumnGrid()
        ClearInfo()

        If IsNew = False Then
            RefreshInfo()
        End If
    End Sub
    Private Sub ClearInfo()
        RefreshCombo()
        ClearAndRefresh(Me)

        dgvComponents.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
    End Sub
    Private Sub RefreshInfo()
        Dim sQuery As String = "select * from `build_assembly` where id = '" & ID & "' limit 1"
        Try
            SqlExecutedUsingReading(Me, sQuery)
            Computed()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If


        Finally
            tdgv = New DataGridView
            tdgv = dgvComponents
            tQuery = SqlUpdate(Me)

        End Try

    End Sub
    Private Sub RefreshCombo()
        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbASSEMBLY_ITEM_ID, "SELECT  ID,DESCRIPTION FROM ITEM WHERE INACTIVE='0' AND TYPE ='1'", "ID", "DESCRIPTION")
    End Sub
    Private Sub ColumnGrid()
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
    Private Sub LoadUnitList()
        Try
            ComboBoxLoad(cmbUNIT_ID, "select ID,SYMBOL from unit_of_measure where  ID = '0' limit 1 ", "ID", "SYMBOL")
            Dim in_sql As String = ""
            Basic_Unit_ID = GetStringFieldValue("ITEM", "ID", cmbASSEMBLY_ITEM_ID.SelectedValue, "BASE_UNIT_ID") 'Gate Unit Base_ID
            If Basic_Unit_ID <> "" Then

                in_sql = "In ('" & Basic_Unit_ID & "'"

                Dim rd As OdbcDataReader = SqlReader("select UNIT_ID from item_units where ITEM_ID ='" & cmbASSEMBLY_ITEM_ID.SelectedValue & "'")
                While rd.Read
                    in_sql = in_sql & ",'" & rd("UNIT_ID") & "'"
                End While
                rd.Close()

                in_sql &= ")"
                ComboBoxLoad(cmbUNIT_ID, "select ID,SYMBOL from unit_of_measure where  ID " & in_sql, "ID", "SYMBOL")
                cmbUNIT_ID.SelectedValue = Basic_Unit_ID
                lblUNIT_BASE_QUANTITY.Text = "1"
            End If
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                LoadUnitList()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub CmbASSEMBLY_ITEM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbASSEMBLY_ITEM_ID.SelectedIndexChanged
        Try
            LoadComponents(cmbASSEMBLY_ITEM_ID.SelectedValue)
            Computed()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadComponents(ByVal pritem_ID As String)

        dtpDATE.Checked = True
        dgvComponents.Rows.Clear()
        Dim sQuery As String = "Select ic.component_id as `Item_ID`,i.code,i.description,i.cost,i.rate,i.ASSET_ACCOUNT_ID from item_components as ic inner join item as i on i.id = ic.component_id  where ic.Item_ID = '" & pritem_ID & "' order by ic.ID"
        Try

            Dim I_ON_HAND As Double = 0
            Dim i_NEEDED As Double = 0
            Dim i_AMOUNT As Double = 0
            Dim i_ASSET_ACCOUNT_ID As String = ""
            Dim i_ID As Double = 0
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                i_AMOUNT = rd("COST")
                GetItemApplied(rd("ITEM_ID"), i_NEEDED, i_AMOUNT, i_ASSET_ACCOUNT_ID, i_ID)

                I_ON_HAND = Val(fItemInventoryReturnValue(rd("ITEM_ID"), cmbLOCATION_ID.SelectedValue, 19, i_ID, dtpDATE.Value, "ENDING_QUANTITY"))
                If i_ASSET_ACCOUNT_ID = "" Then

                    i_ASSET_ACCOUNT_ID = NumIsNull(rd("ASSET_ACCOUNT_ID"))
                End If

                If IsNew = False And i_NEEDED = 0 Then

                Else
                    dgvComponents.Rows.Add(rd("item_ID"), rd("CODE"), rd("DESCRIPTION"), (I_ON_HAND + i_NEEDED), i_NEEDED, i_AMOUNT, i_ASSET_ACCOUNT_ID)
                End If


            End While
            rd.Close()

            LoadUnitList()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try
        Computed()
    End Sub
    Private Sub GetItemApplied(ByVal prItem_ID As String, ByRef prQty As Double, ByRef prAmount As Double, ByRef prASSET_ACCOUNT_ID As String, ByRef prID As Double)

        Try

            Dim rd As OdbcDataReader = SqlReader("select ID,QUANTITY,AMOUNT,ASSET_ACCOUNT_ID from build_assembly_items where BUILD_ASSEMBLY_ID = '" & ID & "' and item_ID = '" & prItem_ID & "' Limit 1")
            If rd.Read Then
                prID = NumIsNull(rd("ID"))
                prQty = NumIsNull(rd("QUANTITY"))
                prAmount = NumIsNull(rd("AMOUNT"))
                prASSET_ACCOUNT_ID = TextIsNull(rd("ASSET_ACCOUNT_ID"))
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
        FrmInsertValue.gsValue = dgvComponents.Rows(i).Cells("QTY_NEEDED").Value
        FrmInsertValue.gsDescription = "Quantity Needed"
        FrmInsertValue.gsFORM_NAME = "Build Assembly"
        FrmInsertValue.ShowDialog()

        If FrmInsertValue.bSave = True Then

            Dim i_NEEDED As Double = 0
            Dim i_AMOUNT As Double = 0
            Dim i_ASSET_ACCOUNT_ID As Double = 0
            Dim i_ID As Double = 0


            Dim Qty As Double = FrmInsertValue.gsValue
            GetItemApplied(dgvComponents.Rows(i).Cells("ITEM_ID").Value, i_NEEDED, i_AMOUNT, i_ASSET_ACCOUNT_ID, i_ID)
            Dim END_UNIT_COST As Double = GetNumberFieldValue("item", "id", dgvComponents.Rows(i).Cells("ITEM_ID").Value, "cost")
            dgvComponents.Rows(i).Cells("QTY_NEEDED").Value = Qty
            dgvComponents.Rows(i).Cells("AMOUNT").Value = NumberFormatFixed(Qty * END_UNIT_COST)
        End If
        FrmInsertValue.Dispose()
        FrmInsertValue = Nothing

        Computed()

    End Sub
    Private Sub DgvComponents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComponents.CellDoubleClick
        FcHANGE_vALUE_nEEDED()
    End Sub

    Private Sub CmbUNIT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUNIT_ID.SelectedIndexChanged

        If Basic_Unit_ID = NumIsNull(cmbUNIT_ID.SelectedValue) Then
            lblUNIT_BASE_QUANTITY.Text = "1"
        Else

            Try

                Dim rd As OdbcDataReader = SqlReader("select quantity as q, rate as r from item_units where unit_id = '" & NumIsNull(cmbUNIT_ID.SelectedValue) & "' and item_id ='" & cmbASSEMBLY_ITEM_ID.SelectedValue & "' limit 1")
                If rd.Read Then
                    If NumIsNull(rd("q")) <> 0 Then
                        lblUNIT_BASE_QUANTITY.Text = NumIsNull(rd("q"))
                    Else
                        lblUNIT_BASE_QUANTITY.Text = "1"
                    End If
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    CmbUNIT_ID_SelectedIndexChanged(sender, e)
                Else
                    End
                End If

            End Try

        End If

    End Sub

    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbASSEMBLY_ITEM_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Select Item")
            Exit Sub
        End If

        If numQUANTITY.Value = 0 Then
            MessageBoxInfo("Quantity Required!")
            Exit Sub
        End If

        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If
        gsGotChangeDate = False
        gsGotChangeLocation1 = False

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If


        If IsNew = True Then



            lblASSET_ACCOUNT_ID.Text = gsDefault_ITEM_ACCOUNT_ID
            dtpDATE.Checked = True
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("BUILD_ASSEMBLY", cmbLOCATION_ID.SelectedValue)
            End If


            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO build_assembly ({SQL_Field},ID,RECORDED_ON,STATUS) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',15) ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", "", "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else



            GotChangeTransaction("BUILD_ASSEMBLY", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            If gsGotChangeDate = True Then
                'Main
                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(lblASSET_ACCOUNT_ID.Text), 70, ID, gsLast_Location_ID, gsLast_Date)
                ItemInventoryChangeDate(dtpDATE.Value, cmbASSEMBLY_ITEM_ID.SelectedValue, 19, NumIsNull(ID), gsLast_Location_ID, gsLast_Date)
            End If
            If gsGotChangeLocation1 = True Then
                'Main
                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(lblASSET_ACCOUNT_ID.Text), 70, ID, dtpDATE.Value, gsLast_Location_ID)
                ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, cmbASSEMBLY_ITEM_ID.SelectedValue, 19, NumIsNull(ID), dtpDATE.Value, gsLast_Location_ID)
            End If



            tChangeAccept = True
            Dim sQuery As String = SqlUpdate(Me)
            SqlExecuted("UPDATE build_assembly SET " & sQuery & " Where ID ='" & ID & "'")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", "", "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If




        'INVENTORY ITEM
        fItem_Inventory_SQL(cmbASSEMBLY_ITEM_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, numQUANTITY.Value, 0, 19, NumIsNull(ID), dtpDATE.Value, NumIsNull(cmbBATCH_ID.SelectedValue))

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            GS_AccountJournalExecute(lblASSET_ACCOUNT_ID.Text, cmbLOCATION_ID.SelectedValue, cmbASSEMBLY_ITEM_ID.SelectedValue, 70, ID, dtpDATE.Value, 0, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
        End If
        '================================
        SaveAppliedItem()
        gsGotChangeDate = False
        gsGotChangeLocation1 = False

        If GF_IsTransactionSuccess(ID, "BUILD_ASSEMBLY") = False Then
            MessageBoxWarning("Try Again!")
            Exit Sub
        End If



        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
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
                RefreshInfo()
            End If


        End Try

    End Sub
    Private Sub SaveAppliedItem()
        For i As Integer = 0 To dgvComponents.Rows.Count - 1
            With dgvComponents.Rows(i)
                Dim qty As Double = .Cells("QTY_NEEDED").Value
                If IsCheckQtyNeed(.Cells("item_ID").Value) = True Then

                    If qty = 0 Then
                        'DELETE
                        Dim xID As String = GetStringFieldValueByTwoCondtion("build_assembly_items", "build_assembly_id", ID, "item_Id", .Cells("item_ID").Value, "ID")
                        If xID <> "" Then
                            SqlExecuted("DELETE FROM `build_assembly_items` where  ID = '" & xID & "' limit 1 ")
                            GS_ItemInventoryRemove(19, xID, dtpDATE.Value, NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                            fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                            If gsSkipJournalEntry = False Then
                                GS_AccountJournalDelete(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 71, NumIsNull(xID), dtpDATE.Value)
                            End If
                        End If

                    Else
                        Dim xID As String = GetStringFieldValueByTwoCondtion("build_assembly_items", "build_assembly_id", ID, "item_Id", .Cells("item_ID").Value, "ID")
                        If gsSkipJournalEntry = False Then

                            If gsGotChangeDate = True Then
                                AccountJournalChangeDate(dtpDATE.Value, NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 71, NumIsNull(xID), gsLast_Location_ID, gsLast_Date)
                            End If

                            If gsGotChangeLocation1 = True Then
                                AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), 71, NumIsNull(xID), dtpDATE.Value, gsLast_Location_ID)
                            End If
                        End If

                        If gsGotChangeDate = True Then
                            ItemInventoryChangeDate(dtpDATE.Value, NumIsNull(.Cells("ITEM_ID").Value), 19, NumIsNull(xID), gsLast_Location_ID, gsLast_Date)
                        End If

                        If gsGotChangeLocation1 = True Then
                            ItemInventoryChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("ITEM_ID").Value), 19, NumIsNull(xID), dtpDATE.Value, gsLast_Location_ID)
                        End If

                        'UPDATE
                        'MISSING FUNCTION
                        SqlExecuted($"UPDATE `build_assembly_items` set QUANTITY = '" & NumIsNull(.Cells("QTY_NEEDED").Value) & "',AMOUNT='" & .Cells("AMOUNT").Value & "',ASSET_ACCOUNT_ID = " & GotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & " where  id = '" & xID & "' and  build_assembly_id = '" & ID & "' and item_Id = '" & .Cells("item_ID").Value & "' limit 1;")
                        'INVENTORY ITEM
                        fItem_Inventory_SQL(.Cells("item_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("QTY_NEEDED").Value * -1, 0, 19, NumIsNull(xID), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))
                        '===========================================
                        If gsSkipJournalEntry = False Then
                            GS_AccountJournalExecute(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("item_ID").Value), 71, NumIsNull(xID), dtpDATE.Value, 1, NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If
                        '================================

                    End If
                Else

                    If qty <> 0 Then
                        'INSERT
                        Dim i_ID As Double = ObjectTypeMapId("build_assembly_items")
                        SqlExecuted("INSERT INTO `build_assembly_items` SET  ID ='" & i_ID & "', build_assembly_id = '" & ID & "',item_Id = '" & .Cells("item_ID").Value & "', QUANTITY = '" & .Cells("QTY_NEEDED").Value & "',AMOUNT='" & .Cells("AMOUNT").Value & "',ASSET_ACCOUNT_ID = " & GotNullNumber(.Cells("ASSET_ACCOUNT_ID").Value) & ";")
                        'INVENTORY ITEM
                        fItem_Inventory_SQL(.Cells("item_ID").Value, cmbLOCATION_ID.SelectedValue, NumIsNull(.Cells("QTY_NEEDED").Value) * -1, 0, 19, NumIsNull(i_ID), dtpDATE.Value, NumIsNull(.Cells("BATCH_ID").Value))
                        '===========================================
                        If gsSkipJournalEntry = False Then
                            GS_AccountJournalExecute(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("item_ID").Value, 71, NumIsNull(i_ID), dtpDATE.Value, 1, NumIsNull(.Cells("AMOUNT").Value), gsJOURNAL_NO_FORM)
                        End If
                        '================================
                    End If

                End If

            End With

        Next

    End Sub
    Private Function IsCheckQtyNeed(ByVal prItem_ID As String) As Boolean
        Dim v As Boolean = False
        Try

            Dim rd As OdbcDataReader = SqlReader("select ID from `build_assembly_items` where  build_assembly_id = '" & ID & "' and item_id = '" & prItem_ID & "' limit 1;")
            If rd.Read Then
                v = True
            End If
            rd.Close()
        Catch ex As Exception
            v = False
        End Try

        Return v
    End Function
    Private Sub Computed()
        Dim dTotal As Double = 0
        For i As Integer = 0 To dgvComponents.Rows.Count - 1
            dTotal += NumIsNull(dgvComponents.Rows(i).Cells("AMOUNT").Value)
        Next
        lblAMOUNT.Text = NumberFormatFixed(dTotal)
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

        f.AccessibleName = "build_assembly"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                ID = f.AccessibleDescription
                IsNew = False
                ''
                ClearInfo()
                If IsNew = False Then

                    RefreshInfo()

                End If
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

            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)
                For N As Integer = 0 To dgvComponents.Rows.Count - 1
                    With dgvComponents.Rows(N)
                        Dim xID As String = GetStringFieldValueByTwoCondtion("build_assembly_items", "build_assembly_id", ID, "item_Id", .Cells("item_ID").Value, "ID")
                        If xID <> "" Then
                            SqlExecuted("DELETE FROM `build_assembly_items` where  ID = '" & xID & "' limit 1 ")
                            GS_ItemInventoryRemove(19, xID, dtpDATE.Value, NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                            fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                            If gsSkipJournalEntry = False Then
                                GS_AccountJournalDelete(.Cells("ASSET_ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 71, NumIsNull(xID), dtpDATE.Value)
                            End If


                        End If
                    End With
                Next


                '===========================================
                If gsSkipJournalEntry = False Then
                    GS_AccountJournalDelete(NumIsNull(lblASSET_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 70, ID, dtpDATE.Value)
                End If
                '================================

                ' SqlExecuted("delete from build_assembly_items where build_assembly_id = '" & ID & "'")
                SqlExecuted("delete from build_assembly where id = '" & ID & "' limit 1;")
                   DeleteNotify(Me)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", "", "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ID = 0
                ClearInfo()
                IsNew = True
                CursorLoadingOn(False)
            End If


        End If
    End Sub
    Private Sub FrmBuildAssembly_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dgvComponents.Columns
            .Item("CODE").Width = 150
            .Item("DESCRIPTION").Width = 400
        End With
        ViewNotSort(dgvComponents)
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



    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then
                RefreshInfo()

            End If
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJounral.Click
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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 70, 6, cmbASSEMBLY_ITEM_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub
    Private Sub FrmBuildAssembly_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If IsNew = False Then
            RefreshInfo()
        End If
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

        frmPrintPage.frmName = Me.Name
        frmPrintPage.ShowDialog()

        Dim v As Integer = frmPrintPage.prValue
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

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class