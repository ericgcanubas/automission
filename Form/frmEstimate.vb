﻿Imports System.Data.Odbc
Public Class FrmEstimate
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
    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub FrmEstimate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
        ColumnGrid()
        ClearInfo()

        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If

    End Sub
    Private Sub ClearInfo()

        RefreshCombo()
        ClearAndRefresh(Me)

        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        'POSComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = GetPaymentTermsDefault()
        dtpDATE.Value = TransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
    End Sub
    Private Sub RefreshInfo()


        Try

            Dim sQuery As String = "select * from estimate where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub RefreshItem()
        dgvProductItem.Rows.Clear()
        bRefreshItem = True
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
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`PRICE_LEVEL_ID`,
  ii.FINAL_QTY,
  ii.CLOSED,
  i.TYPE as `ITEM_TYPE`,
  ii.`GROUP_LINE_ID`,
  ii.PRINT_IN_FORMS

FROM

  estimate_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
   WHERE ii.`ESTIMATE_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

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
                            dgvProductItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))

                        End If
                    End With

                Next
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItem()
            Else
                End
            End If
        Finally
            bRefreshItem = False
            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)


        End Try


    End Sub

    Private Sub RefreshCombo()
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select * from class", "ID", "NAME")
        GS_ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2'", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
    End Sub
    Private Sub ColumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = gsCUSTOM_TAX,
            .Name = "TAX"
        }

        Dim closed As New DataGridViewCheckBoxColumn With {
            .HeaderText = gsCUSTOM_CLOSED,
            .Name = "CLOSED"
        }

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item("ID").Visible = False
            .Add("CODE", gsCUSTOM_CODE) '1
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '2
            .Add("QTY", gsCUSTOM_QTY) '3
            .Add("UM", gsCUSTOM_UNIT) '4
            .Add("UNIT_PRICE", gsCUSTOM_RATE) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8
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

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '17
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '18
            .Item("ITEM_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL") '19
            .Item("PRICE_LEVEL_ID").Visible = False


            .Add("FINAL_QTY", gsCUSTOM_FINAL_QTY) '20
            .Add(closed) '20
            .Add("ITEM_TYPE", "ITEM_TYPE") '21
            .Item("ITEM_TYPE").Visible = False

            .Add("GROUP_LINE_ID", "GROUP_LINE_ID") '22
            .Item("GROUP_LINE_ID").Visible = False

            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") '23
            .Item("PRINT_IN_FORMS").Visible = False


        End With
    End Sub

    Private Sub Computed()
        Dim gsSalesSubTotal As Double
        GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)

    End Sub

    Private Sub CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        Computed()

        Try

            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & cmbOUTPUT_TAX_ID.SelectedValue & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = GF_TextIsNull(rd("VAT_METHOD"))

            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""

            End If
            rd.Close()
        Catch ex As Exception

            lblOUTPUT_TAX_VAT_METHOD.Text = ""

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
            If d.Cells("ITEM_TYPE").Value = 5 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsGroupItem(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value = "" Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With FrmAddItem
                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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

                .ShowDialog()

                If .gsSave = True Then
                    GS_RowDataItemEstimate(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID)
                    ' fDiscount_ReComputed(dgvProductItem)
                    GoupItemComputed(dgvProductItem)
                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Sub DgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
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
        f.AccessibleName = "estimate"
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

    Private Sub DgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_TaxValue(dgvProductItem)
            Computed()

        ElseIf e.ColumnIndex = 21 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_ClosedValue(dgvProductItem)
            Computed()
        End If
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

        If IsNew = True Then
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GF_GetNextCode("ESTIMATE", cmbLOCATION_ID.SelectedValue)
            End If
            dtpDATE.Checked = True
            ID = ObjectTypeMapId("ESTIMATE")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO estimate ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',2,'{GetDateTimeNowSql()}') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            tChangeAccept = True
            SqlExecuted("UPDATE estimate SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "'")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If


        If GF_IsTransactionSuccess(ID, "estimate") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        SaveItem()
        ItemUpdateStatus()
        SaveNotify(Me, IsNew)


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

    End Sub
    Private Sub SaveItem()

        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        Dim SQL_SCRIPT As String = ""

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)


                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX ONLY
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE estimate_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE ESTIMATE_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;"

                    Case "A"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("estimate_items")
                        SQL_SCRIPT = "INSERT INTO estimate_items SET PRINT_IN_FORMS='" & CBool(GF_NumIsNull(.Cells("PRINT_IN_FORMS").Value)) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',RATE_TYPE='0',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value).ToString.Replace("-", "") & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",ESTIMATE_ID ='" & ID & "',CLOSED ='" & GF_NumIsNull(.Cells("CLOSED").Value) & "',FINAL_QTY=" & GotNullNumber(GF_NumIsNull(.Cells("FINAL_QTY").Value)) & ",PRICE_LEVEL_ID = " & GotNullNumber(GF_NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",GROUP_LINE_ID = " & GotNullNumber(GF_NumIsNull(.Cells("GROUP_LINE_ID").Value)) & ";"

                    Case "E"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE estimate_items SET LINE_NO='" & i & "', QUANTITY='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',RATE_TYPE='0',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value).ToString.Replace("-", "") & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',CLOSED ='" & GF_NumIsNull(.Cells("CLOSED").Value) & "',FINAL_QTY=" & GotNullNumber(GF_NumIsNull(.Cells("FINAL_QTY").Value)) & ",UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE ESTIMATE_ID ='" & ID & "' and ID = " & GF_NumIsNull(.Cells("ID").Value) & " limit 1;"

                    Case "D"
                        SQL_SCRIPT = "DELETE FROM estimate_items WHERE ESTIMATE_ID ='" & ID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "' limit 1;"

                End Select
            End With
            SqlExecuted(SQL_SCRIPT)
        Next


    End Sub
    Private Sub ItemUpdateStatus()
Again:
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "A"
                        .Cells("CONTROL_STATUS").Value = "S"
                    Case "E"
                        .Cells("CONTROL_STATUS").Value = "S"
                    Case "D"
                        dgvProductItem.Rows.RemoveAt(i)
                        GoTo Again
                End Select
            End With

        Next
    End Sub
    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then

                SqlExecuted("DELETE FROM estimate_items WHERE ESTIMATE_ID = '" & ID & "'")
                SqlExecuted("DELETE FROM estimate WHERE ID = '" & ID & "' limit 1")
                   DeleteNotify(Me)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True

            End If

        End If

    End Sub

    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If
    End Sub
    Private Sub FrmEstimate_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GS_ViewItemDisplay(dgvProductItem)
        GS_ViewNotSort(dgvProductItem)
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

            Dim prFile_name As String = "cryEstimate.rpt"
            Dim prPrint_Title As String = tsTITLE.Text

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
            Dim prFile_name As String = "cryEstimate.rpt"
            Dim prPrint_Title As String = tsTITLE.Text
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
            Dim R As Integer = GF_RefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then
                ClearInfo()
                RefreshInfo()
                RefreshItem()
            End If

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

    Private Sub FrmEstimate_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged


        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If Me.Text = "" Then

        End If
        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If



        With FrmAddItem
            .sFormName = Me.Name
            .dgv = dgvProductItem
            .ShowDialog()
            'If .gsSave = True Then

            '    GS_RowDataItemEstimate(dgvProductItem, True, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "A", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount)


            'End If
        End With
        Computed()
        FrmAddItem.Dispose()
        FrmAddItem = Nothing
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        EditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvProductItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvProductItem.CurrentRow.Index
                Dim d As DataGridViewRow = dgvProductItem.Rows(i)

                If IsGroupItem(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value = "" Then
                    MessageBoxInfo("Invalid Delete")
                    Exit Sub

                ElseIf IsGroupItem(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value <> "" Then
                    Dim tmp_ID As Integer = d.Cells("ITEM_ID").Value
                    Dim sTemp_ID As Integer = 0
                    Dim sTemp_CODE As String = ""
X_A:
                    For n As Integer = i To dgvProductItem.Rows.Count - 1
                        sTemp_ID = dgvProductItem.Rows(n).Cells("ITEM_ID").Value
                        sTemp_CODE = dgvProductItem.Rows(n).Cells("CODE").Value

                        If GF_NumIsNull(dgvProductItem.Rows(n).Cells(0).Value) <> 0 Then
                            dgvProductItem.Rows(n).Cells("CONTROL_STATUS").Value = "D"
                            dgvProductItem.Rows(n).Visible = False
                        Else
                            If sTemp_ID = tmp_ID And sTemp_CODE = "" Then
                                dgvProductItem.Rows.RemoveAt(n)
                                ' fDiscount_ReComputed(dgvProductItem)
                                GoupItemComputed(dgvProductItem)
                                Computed()
                                Exit Sub
                            Else
                                dgvProductItem.Rows.RemoveAt(n)
                                GoTo X_A
                            End If

                        End If

                        If sTemp_ID = tmp_ID And sTemp_CODE = "" Then
                            '  fDiscount_ReComputed(dgvProductItem)
                            GoupItemComputed(dgvProductItem)
                            Computed()
                            Exit Sub
                        End If
                    Next
                Else
                    If GF_NumIsNull(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                        dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgvProductItem.Rows(i).Visible = False
                    Else
                        dgvProductItem.Rows.RemoveAt(i)
                    End If

                End If

                GoupItemComputed(dgvProductItem)
                Computed()
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub
End Class