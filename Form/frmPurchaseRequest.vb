﻿Imports System.Data.Odbc
Public Class frmPurchaseRequest

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
    Private Sub fclear_Info()
        fRefreshCombo()
        fCLean_and_refresh(Me)


        '  dtpDATE_EXPECTED.Checked = False
        dgvProductItem.Rows.Clear()

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()

        dtpDATE.Value = fTransactionDefaultDate()
        cmbINPUT_TAX_ID.SelectedValue = fInPutTaxDefault()
    End Sub
    Private Sub fcolumnGrid()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = gsCUSTOM_TAX
        chk.Name = "TAX"

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", gsCUSTOM_CODE) '1
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '2
            .Add("QTY", gsCUSTOM_QTY) '3
            .Add("UM", gsCUSTOM_UNIT) '4
            .Add("UNIT_PRICE", gsCUSTOM_COST) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8

            .Add(chk) '9

            .Item("TAX").Visible = False
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

            .Add("ITEM_TYPE", "ITEM_TYPE") '19
            .Item("ITEM_TYPE").Visible = False

        End With
    End Sub
    Private Sub fRefreshItem(ByVal xID As String)
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
  's' AS `CONTROL_STATUS`,
  rt.`ID` AS `RATE_TYPE`,
  ii.`UNIT_BASE_QUANTITY`,
  d.`ID` AS `DISCOUNT_ID`,
  ii.`TAXABLE_AMOUNT`,
  ii.`TAX_AMOUNT`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
i.TYPE as `ITEM_TYPE`
  
FROM

  purchase_request_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    WHERE  ii.`PR_ID` = '" & gsID & "' Order by ii.LINE_NO"


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


            bRefreshItem = False
            fComputed()

            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = fFieldCollector(Me)

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshItem(xID)
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

    Private Sub fRefreshCombo()
        fComboBox(cmbVENDOR_ID, "select * from contact where type='0'", "ID", "NAME")

        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        '
        fComboBox(cmbINPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
    End Sub
    Private Sub fRefreshField(ByVal id As String)


        Try

            Dim sQuery As String = "select * from purchase_request where ID = '" & id & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)


            '  cn.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshField(id)
            Else
                End
            End If

        End Try

    End Sub
    Private Sub frmPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
        '   fBackGroundImageStyle(Me)
        fcolumnGrid()
        fclear_Info()


        If gsNew = False Then
            fRefreshField(gsID)
            fRefreshItem(gsID)
        End If

    End Sub



    Private Sub tsClose_Click_1(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub

    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

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
            End If

            With frmAddItem

                .gsCOST_AMOUNT_ONLY = True
                '.gsSelection = True
                '.gsSelection_Query = "select * from class"
                '.gsSelection_Label = "Class"
                '.gsSelection_DESCRIPTION = "NAME"
                '.gsSelection_VALUE = "ID"
                '.gsSelection_ID = fTextisNULL(dgvProductItem.Rows.Item(I).Cells("CLASS_ID").Value)

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

            End With
            frmAddItem.ShowDialog()
            With frmAddItem

                If .gsSave = True Then
                    '
                    fRow_Data_Item_Purchase_Request(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount)
                    'fDiscount_ReComputed(dgvProductItem)
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
    Private Sub dgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            fTax_Value(dgvProductItem)
            fComputed()
        End If
    End Sub
    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub fComputed()
        Dim total As Double = 0
        Dim dOutput_value As Double = 0
        Dim dTotal_amount As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim n As Integer = 0
        Dim dVat As Double = 0
        Try

            For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                If dgvProductItem.Rows(i).Visible = True Then
                    If 5 = dgvProductItem.Rows(i).Cells("ITEM_TYPE").Value Then
                        'Sub Total
                    ElseIf fDISCOUNT_ITEM(dgvProductItem.Rows(i).Cells("ITEM_TYPE").Value) = True Then
                        'Discount Item
                        Dim dtDiscount_Less As Double = (dTotal_amount * (Format(fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value)) * -1 / 100))
                        dTotal_amount = dTotal_amount - fNumFormatFixed(dtDiscount_Less)

                        dtDiscount_Less = (dTax * (fNumFormatFixed(fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value)) * -1 / 100))
                        dTax = dTax - fNumFormatFixed(dtDiscount_Less)

                        dtDiscount_Less = (dNon_Tax * (fNumFormatFixed(fNumisNULL(dgvProductItem.Rows(i).Cells("UNIT_PRICE").Value)) * -1 / 100))
                        dNon_Tax = dNon_Tax - fNumFormatFixed(dtDiscount_Less)
                    Else
                        dTotal_amount = dTotal_amount + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)

                        If dgvProductItem.Rows(i).Cells("Tax").Value = False Then

                            dNon_Tax = dNon_Tax + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax = dTax + fNumFormatFixed(dgvProductItem.Rows(i).Cells("AMOUNT").Value)
                        End If

                    End If

                End If
                n = n + 1
            Next

            If fTextisNULL(cmbINPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = fTax_Rate_Find(fNumisNULL(cmbINPUT_TAX_ID.SelectedValue))
                dOutput_value = (dVat / 100) * dTax
                total = dOutput_value + dTax

                If cmbINPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dOutput_value = t * dOutput_value
                    dTax = dTax - dOutput_value
                    total = dOutput_value + dTax
                End If

                total = total + dNon_Tax
                lblINPUT_TAX_AMOUNT.Text = fNumFormatStandard(dOutput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)

                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(dTax)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblINPUT_TAX_AMOUNT.Text = fNumFormatStandard(dOutput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)
                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(0)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(total)
            End If

            lblINPUT_TAX_RATE.Text = dVat
            If n = 0 Then

            Else

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbINPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Try

            Dim rd As OdbcDataReader = fReader("select VAT_METHOD,ASSET_ACCOUNT_ID from tax where ID ='" & fNumisNULL(cmbINPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblINPUT_TAX_VAT_METHOD.Text = fTextisNULL(rd("VAT_METHOD"))
                lblINPUT_TAX_ACCOUNT_ID.Text = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
            Else
                lblINPUT_TAX_VAT_METHOD.Text = ""
                lblINPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception

            lblINPUT_TAX_VAT_METHOD.Text = ""
            lblINPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
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
        f.AccessibleName = "purchase_request"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fclear_Info()
                gsID = f.AccessibleDescription
                gsNew = False

                fRefreshField(gsID)
                fRefreshItem(gsID)

            End If


        End If




    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Vendor")
            Exit Sub
        End If


        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item Enter")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then


            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("PURCHASE_REQUEST", cmbLOCATION_ID.SelectedValue)
            End If
            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("PURCHASE_REQUEST")
            squery = squery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='2'"
            squery = fNullOTherField(squery, "PURCHASE_REQUEST")
            fExecutedOnly("INSERT INTO purchase_request SET " & squery)

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbVENDOR_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)
            squery = squery & " WHERE ID = '" & gsID & "'"
            fExecutedOnly("UPDATE purchase_request SET " & squery)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbVENDOR_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If

        If fTransactionCheck(gsID, "PURCHASE_REQUEST") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If

        fSaveItem(gsID)  ' Save item

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
                fRefreshField(gsID)
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
    Private Sub fSaveItem(ByVal dID As String)

        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        Dim SQL_SCRIPT As String = ""
        Dim SQL_LIST As String = ""
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)

                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE purchase_request_items SET TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE PR_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value))
                        fExecutedOnly(SQL_SCRIPT)
                    Case "A"
                        fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("PURCHASE_REQUEST_ITEMS")

                        SQL_SCRIPT = "INSERT INTO purchase_request_items SET LINE_NO='" & fGetMaxField_LINE("LINE_NO", "PURCHASE_REQUEST_ITEMS", "PR_ID", dID) & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",PR_ID ='" & dID & "',CLOSED='0'"
                        fExecutedOnly(SQL_SCRIPT)
                        .Cells("ID").Value = i_ID

                    Case "E"
                        fTax_Computation(cmbINPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE purchase_request_items SET QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & " WHERE PR_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & ""
                        fExecutedOnly(SQL_SCRIPT)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM purchase_request_items WHERE PR_ID ='" & dID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "'"
                        fExecutedOnly(SQL_SCRIPT)
                End Select

            End With


        Next


    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
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
                fExecutedOnly("DELETE FROM purchase_request_items WHERE PR_ID = '" & gsID & "'")
                fExecutedOnly("DELETE FROM purchase_request WHERE ID = '" & gsID & "' limit 1;")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbVENDOR_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                gsID = ""
                gsNew = True
            End If
        End If


    End Sub

    Private Sub frmPurchaseOrder_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        fDgvNotSort(dgvProductItem)
        fdgvItemDisplay(dgvProductItem)
        '  fdgvItemDisplay(dgvProductItem)


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

            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "prepared_by")
            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "noted_by")
            fCryParameterInsertValue(gscryRpt, "Mirasol Cadotdot", "approved_by")

            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            fPreviewReport(prPrint_Title & " Report")

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

            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "prepared_by")
            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "noted_by")
            fCryParameterInsertValue(gscryRpt, gsApproved_By.ToUpper, "approved_by")

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

                fRefreshField(gsID)
                fRefreshItem(gsID)
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbVENDOR_ID_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub







    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select Vendor")
            Exit Sub
        End If

        With frmAddItem
            .sFormName = Me.Name
            .gsCOST_AMOUNT_ONLY = True
            .dgv = dgvProductItem
            '.gsSelection = True
            '.gsSelection_Query = "select * from class"
            '.gsSelection_Label = "Class"
            '.gsSelection_DESCRIPTION = "NAME"
            '.gsSelection_VALUE = "ID"
            '.gsSelection_ID = ""
            .gsDate = dtpDATE.Value
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .ShowDialog()

        End With
        fComputed()
        frmAddItem.Dispose()
        frmAddItem = Nothing
    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvProductItem.Rows.Count <> 0 Then
                Dim i As Integer = dgvProductItem.CurrentRow.Index
                If fNumisNULL(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                    dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvProductItem.Rows(i).Visible = False
                Else
                    dgvProductItem.Rows.RemoveAt(i)
                End If
                '  fDiscount_ReComputed(dgvProductItem)
                fComputed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmPurchaseRequest_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then
            fRefreshField(gsID)
            fRefreshItem(gsID)

        End If
    End Sub

    Private Sub tsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
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

            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "prepared_by")
            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "noted_by")
            fCryParameterInsertValue(gscryRpt, "Mirasol Cadotdot", "approved_by")

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
End Class