﻿Imports System.Data.Odbc
Public Class frmEstimate
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
    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub frmEstimate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fcolumnGrid()
        fclear_Info()

        If gsNew = False Then
            fRefreshInfo(gsID)
            fRefreshItem(gsID)
        End If

    End Sub
    Private Sub fclear_Info()

        fRefreshCombo()
        fCLean_and_refresh(Me)



        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        'fComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = fPaymentTermsDefault()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
    End Sub
    Private Sub fRefreshInfo(ByVal prID As String)


        Try

            Dim sQuery As String = "select * from estimate where ID = '" & prID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)


        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo(prID)
            Else
                End
            End If



        End Try
    End Sub
    Private Sub fRefreshItem(prID As String)
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
   WHERE ii.`ESTIMATE_ID` = '" & gsID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

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
                            dgvProductItem.Rows(x).Cells(i).Value = fTextisNULL(rd(i))

                        End If
                    End With

                Next
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshItem(prID)
            Else
                End
            End If
        Finally
            bRefreshItem = False
            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = fFieldCollector(Me)


        End Try


    End Sub

    'Private Function fgetTypeValue(ByVal dt As String) As String
    '    If IsNumeric(dt) = True Then
    '        Return Format(dt, "Standard")
    '    Else
    '        Return dt
    '    End If
    'End Function
    Private Sub fRefreshCombo()
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        fComboBox(cmbCLASS_ID, "select * from class", "ID", "NAME")
        fComboBox(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        fComboBox(cmbSALES_REP_ID, "select * from contact where type ='2'", "ID", "NAME")
        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        fComboBox(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
    End Sub
    Private Sub fcolumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = gsCUSTOM_TAX
        chk.Name = "TAX"

        Dim closed As New DataGridViewCheckBoxColumn
        closed.HeaderText = gsCUSTOM_CLOSED
        closed.Name = "CLOSED"

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
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub

    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub
    Private Sub fComputed()
        Dim gsSalesSubTotal As Double
        fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)

    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()

        Try

            Dim rd As OdbcDataReader = fReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & cmbOUTPUT_TAX_ID.SelectedValue & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = fTextisNULL(rd("VAT_METHOD"))

            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""

            End If
            rd.Close()
        Catch ex As Exception

            lblOUTPUT_TAX_VAT_METHOD.Text = ""

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
            If d.Cells("ITEM_TYPE").Value = 5 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fDISCOUNT_ITEM(d.Cells("ITEM_TYPE").Value) = True Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value = "" Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem
                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
                    fRow_Data_Item_Estimate(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID)
                    ' fDiscount_ReComputed(dgvProductItem)
                    fGROUP_ReComputed(dgvProductItem)
                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
    End Sub

    Private Sub lklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub


    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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
        f.AccessibleName = "estimate"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fclear_Info()
                gsID = f.AccessibleDescription
                gsNew = False

                fRefreshInfo(gsID)
                fRefreshItem(gsID)

            End If


        End If


    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs)

    End Sub
    Private Sub dgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            fTax_Value(dgvProductItem)
            fComputed()

        ElseIf e.ColumnIndex = 21 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            fClosed_Value(dgvProductItem)
            fComputed()
        End If
    End Sub
    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

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
        Dim SQL_SCRIPT As String = ""
        If gsNew = True Then

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("ESTIMATE", cmbLOCATION_ID.SelectedValue)
            End If


            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("ESTIMATE")
            squery = squery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='2',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            squery = fNullOTherField(squery, "ESTIMATE")
            SQL_SCRIPT = "INSERT INTO estimate SET " & squery & ";"

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else


            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)

            squery = squery & " WHERE ID = '" & gsID & "'"
            SQL_SCRIPT = "UPDATE estimate SET " & squery & " limit 1;"
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If
        fExecutedOnly(SQL_SCRIPT)
        fSaveItem()

        If fTransactionCheck(gsID, "estimate") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If
        fItemUpdateStatus()

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
                fRefreshInfo(gsID)
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

    End Sub
    Private Sub fSaveItem()

        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        Dim SQL_SCRIPT As String = ""

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)


                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE estimate_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE ESTIMATE_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;"

                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("estimate_items")
                        SQL_SCRIPT = "INSERT INTO estimate_items SET PRINT_IN_FORMS='" & CBool(fNumisNULL(.Cells("PRINT_IN_FORMS").Value)) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',RATE_TYPE='0',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value).ToString.Replace("-", "") & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",ESTIMATE_ID ='" & gsID & "',CLOSED ='" & fNumisNULL(.Cells("CLOSED").Value) & "',FINAL_QTY=" & fGotNullNumber(fNumisNULL(.Cells("FINAL_QTY").Value)) & ",PRICE_LEVEL_ID = " & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",GROUP_LINE_ID = " & fGotNullNumber(fNumisNULL(.Cells("GROUP_LINE_ID").Value)) & ";"

                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE estimate_items SET LINE_NO='" & i & "', QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',RATE_TYPE='0',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value).ToString.Replace("-", "") & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',CLOSED ='" & fNumisNULL(.Cells("CLOSED").Value) & "',FINAL_QTY=" & fGotNullNumber(fNumisNULL(.Cells("FINAL_QTY").Value)) & ",UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & " WHERE ESTIMATE_ID ='" & gsID & "' and ID = " & fNumisNULL(.Cells("ID").Value) & " limit 1;"

                    Case "D"
                        SQL_SCRIPT = "DELETE FROM estimate_items WHERE ESTIMATE_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;"

                End Select
            End With
            fExecutedOnly(SQL_SCRIPT)
        Next


    End Sub
    Private Sub fItemUpdateStatus()
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
    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If



            If fMessageBoxQuestion(gsMessageQuestion) = True Then

                fExecutedOnly("DELETE FROM estimate_items WHERE ESTIMATE_ID = '" & gsID & "'")

                fExecutedOnly("DELETE FROM estimate WHERE ID = '" & gsID & "' limit 1")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                gsID = ""
                gsNew = True

            End If

        End If

    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If
    End Sub

    Private Sub frmSalesOrder_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmSalesOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fdgvItemDisplay(dgvProductItem)
        fDgvNotSort(dgvProductItem)
    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged

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

            Dim prFile_name As String = "cryEstimate.rpt"
            Dim prPrint_Title As String = tsTITLE.Text

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
            Dim prFile_name As String = "cryEstimate.rpt"
            Dim prPrint_Title As String = tsTITLE.Text
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
                fclear_Info()
                fRefreshInfo(gsID)
                fRefreshItem(gsID)
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub cmbPAYMENT_TERMS_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_TERMS_ID.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles tsCreateSalesOrder.Click

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

    Private Sub frmEstimate_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged


        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If Me.Text = "" Then

        End If
        If gsNew = False Then
            fRefreshInfo(gsID)
            fRefreshItem(gsID)
        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If



        With frmAddItem
            .sFormName = Me.Name
            .dgv = dgvProductItem
            .ShowDialog()
            'If .gsSave = True Then

            '    fRow_Data_Item_Estimate(dgvProductItem, True, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "A", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount)


            'End If
        End With
        fComputed()
        frmAddItem.Dispose()
        frmAddItem = Nothing
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvProductItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvProductItem.CurrentRow.Index
                Dim d As DataGridViewRow = dgvProductItem.Rows(i)

                If fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value = "" Then
                    fMessageboxInfo("Invalid Delete")
                    Exit Sub

                ElseIf fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, False) = True And d.Cells("CODE").Value <> "" Then
                    Dim tmp_ID As Integer = d.Cells("ITEM_ID").Value
                    Dim sTemp_ID As Integer = 0
                    Dim sTemp_CODE As String = ""
X_A:
                    For n As Integer = i To dgvProductItem.Rows.Count - 1
                        sTemp_ID = dgvProductItem.Rows(n).Cells("ITEM_ID").Value
                        sTemp_CODE = dgvProductItem.Rows(n).Cells("CODE").Value

                        If fNumisNULL(dgvProductItem.Rows(n).Cells(0).Value) <> 0 Then
                            dgvProductItem.Rows(n).Cells("CONTROL_STATUS").Value = "D"
                            dgvProductItem.Rows(n).Visible = False
                        Else
                            If sTemp_ID = tmp_ID And sTemp_CODE = "" Then
                                dgvProductItem.Rows.RemoveAt(n)
                                ' fDiscount_ReComputed(dgvProductItem)
                                fGROUP_ReComputed(dgvProductItem)
                                fComputed()
                                Exit Sub
                            Else
                                dgvProductItem.Rows.RemoveAt(n)
                                GoTo X_A
                            End If

                        End If

                        If sTemp_ID = tmp_ID And sTemp_CODE = "" Then
                            '  fDiscount_ReComputed(dgvProductItem)
                            fGROUP_ReComputed(dgvProductItem)
                            fComputed()
                            Exit Sub
                        End If
                    Next
                Else
                    If fNumisNULL(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                        dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgvProductItem.Rows(i).Visible = False
                    Else
                        dgvProductItem.Rows.RemoveAt(i)
                    End If

                End If

                fGROUP_ReComputed(dgvProductItem)
                fComputed()
            End If
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub
End Class