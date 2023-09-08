Imports System.Data.Odbc
Public Class FrmPurchaseOrder

    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DataGridViewCounting(dgvProductItem)

    End Sub
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)

        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub fclear_Info()
        fRefreshCombo()
        ClearAndRefresh(Me)


        dtpDATE_EXPECTED.Checked = False
        dgvProductItem.Rows.Clear()

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = fPaymentTermsDefault()
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

            .Add("PR_ID", "PR_ID") '19
            .Item("PR_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") '20
            .Item("ITEM_TYPE").Visible = False

        End With
    End Sub
    Private Sub fRefreshItem()
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
  ii.`PR_ID`,
 i.TYPE as `ITEM_TYPE`

FROM

  purchase_order_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    WHERE  ii.`PO_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0
            'cn.Open()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1

                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(NumIsNull(rd(i)))
                        ElseIf CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(NumIsNull(rd(i)))
                        ElseIf CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(NumIsNull(rd(i)))
                        Else
                            dgvProductItem.Rows(x).Cells(i).Value = TextIsNull(rd(i))
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
            tQuery = SqlUpdate(Me)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshItem()
            Else
                End
            End If
        End Try






    End Sub


    Private Sub fRefreshCombo()
        ComboBoxLoad(cmbVENDOR_ID, "select * from contact where type='0'", "ID", "NAME")
        ComboBoxLoad(cmbCLASS_ID, "select * from class", "ID", "NAME")
        ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")

        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbSHIP_VIA_ID, "select ID, DESCRIPTION as D from ship_via", "ID", "D")
        ComboBoxLoad(cmbINPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")

    End Sub
    Private Sub fRefreshField()


        Try

            Dim sQuery As String = "select * from purchase_order where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)


            Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM purchase_order_items AS p WHERE NOT EXISTS(SELECT * FROM bill_items AS b  WHERE b.`PO_ITEM_ID`= p.`ID`) AND  p.`PO_ID` = '{ID}' limit 1;")
            If rd.Read Then
                cmbLOCATION_ID.Enabled = True
            Else
                cmbLOCATION_ID.Enabled = False
            End If
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshField()
            Else
                End
            End If
        Finally


        End Try

    End Sub
    Private Sub frmPurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
        'fBackGroundImageStyle(Me)
        fcolumnGrid()
        fclear_Info()


        If IsNew = False Then
            fRefreshField()
            fRefreshItem()
        End If

    End Sub
    Private Sub fEditItem()
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
            End If

            With frmAddItem

                .gsCOST_AMOUNT_ONLY = True
                If NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
                    fRow_Data_Item_Purchase_Order(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, NumIsNull(dgvProductItem.CurrentRow.Cells("PR_ID").Value))
                    '  fDiscount_ReComputed(dgvProductItem)
                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub lklEdit_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub dgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs)
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
        fPurchase_Vendor_Computation(dgvProductItem, cmbINPUT_TAX_ID, lblINPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblINPUT_TAX_RATE)
        lblCount.Text = DataGridViewCounting(dgvProductItem)
    End Sub

    Private Sub cmbINPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbINPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Try

            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,ASSET_ACCOUNT_ID from tax where ID ='" & NumIsNull(cmbINPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblINPUT_TAX_VAT_METHOD.Text = TextIsNull(rd("VAT_METHOD"))
                lblINPUT_TAX_ACCOUNT_ID.Text = TextIsNull(rd("ASSET_ACCOUNT_ID"))
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
        f.AccessibleName = "purchase_order"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fclear_Info()
                ID = f.AccessibleDescription
                IsNew = False

                fRefreshField()
                fRefreshItem()
            End If
        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Vendor")
            Exit Sub
        End If


        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, IsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("PURCHASE_ORDER", cmbLOCATION_ID.SelectedValue)
            End If
            dtpDATE.Checked = True
            ID = ObjectTypeMapId("PURCHASE_ORDER")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO PURCHASE_ORDER ({SQL_Field},ID,RECORDED_ON,STATUS) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',2) ")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "New", cmbVENDOR_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

            If Val(lblPR_ID.Text) <> 0 Then
                SqlExecuted($"UPDATE PURCHASE_REQUEST SET `status` = '3' WHERE `id` = '{Val(lblPR_ID.Text)}' ")
            End If
        Else
            tChangeAccept = True
            SqlExecuted("UPDATE PURCHASE_ORDER SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "' ")
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbVENDOR_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If IsTransactionSuccess(ID, "PURCHASE_ORDER") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If
        fSaveItem()  ' Save item
        StatusGridUpdateRefresh(dgvProductItem)

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)

        End If

        Try

            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            End If
        Catch ex As Exception

        Finally
            If ID > 0 Then
                IsNew = False
                fRefreshField()
                fRefreshItem()
            End If
        End Try

    End Sub

    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()
        ID = 0
        IsNew = True

    End Sub
    Private Sub fSaveItem()

        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        Dim SQL_SCRIPT As String = ""

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)


                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE purchase_order_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE PO_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & ";"

                    Case "A"
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("purchase_order_items")
                        .Cells("ID").Value = i_ID
                        SQL_SCRIPT = $"INSERT INTO purchase_order_items SET LINE_NO='" & i & "',ID='" & NumIsNull(.Cells("ID").Value) & "',QUANTITY ='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",PO_ID ='" & ID & "',CLOSED='0',PR_ID =" & GotNullNumber(NumIsNull(.Cells("PR_ID").Value)) & ";"
                    Case "E"
                        fTax_Computation(cmbINPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE purchase_order_items SET LINE_NO='" & i & "',QUANTITY='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE PO_ID ='" & ID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;"
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM purchase_order_items WHERE PO_ID ='" & ID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;"

                End Select

            End With
            SqlExecuted(SQL_SCRIPT)

        Next


    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If

    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If


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






            If MessageBoxQuestion(gsMessageQuestion) = True Then
                SqlExecuted("DELETE FROM purchase_order_items WHERE PO_ID = '" & ID & "'")
                SqlExecuted("DELETE FROM purchase_order WHERE ID = '" & ID & "' limit 1")

                PrompNotify(Me.Text, DeleteMsg, True)

                fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbVENDOR_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                ID = 0
                IsNew = True
            End If
        End If


    End Sub

    Private Sub frmPurchaseOrder_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmPurchaseOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        ViewItemDisplay(dgvProductItem)

        ViewNotSort(dgvProductItem)

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
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "prepared_by")
            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "noted_by")
            fCryParameterInsertValue(gscryRpt, gsApproved_By.ToUpper, "approved_by")


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
        If IsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then
                fRefreshField()
                fRefreshItem()
            End If
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, ID)
    End Sub
    Private Sub cmbVENDOR_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbVENDOR_ID.LostFocus
        VendorTax()
    End Sub
    Private Sub VendorTax()
        Application.DoEvents()
        Dim s As Integer
        Try
            s = cmbVENDOR_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbVENDOR_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbVENDOR_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from contact where id ='{s}' and `type` = '0' limit 1 ")
        If rd.Read Then
            If NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbINPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub



    Private Sub cmbVENDOR_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbVENDOR_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbVENDOR_ID.Text)
            If cmbVENDOR_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If fACCESS_NEW_EDIT(frmVendor, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/vendor.png")

                    frmContactDetails.ContactTypeId = 0
                    frmContactDetails.txtNAME.Text = StrText ' must auto insert
                    frmContactDetails.txtCOMPANY_NAME.Text = StrText
                    frmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    frmContactDetails.IsNew = True
                    frmContactDetails.ID = 0
                    frmContactDetails.gsDgv = Nothing
                    frmContactDetails.this_BS = Nothing
                    frmContactDetails.ShowDialog()
                    If frmContactDetails.gsOK = True Then
                        ComboBoxLoad(cmbVENDOR_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbVENDOR_ID.SelectedValue = frmContactDetails.ID
                        cmbVENDOR_ID_LostFocus(sender, e)
                    End If
                    frmContactDetails.Dispose()
                    frmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbVENDOR_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select vendor")
            Exit Sub
        End If
        With frmAddItem
            .sFormName = Me.Name
            .gsCOST_AMOUNT_ONLY = True
            .dgv = dgvProductItem
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
                If NumIsNull(dgvProductItem.Rows(i).Cells(0).Value) <> 0 Then
                    dgvProductItem.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvProductItem.Rows(i).Visible = False
                Else
                    dgvProductItem.Rows.RemoveAt(i)
                End If
                ' fDiscount_ReComputed(dgvProductItem)
                fComputed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsPurchaseRequest_Click(sender As Object, e As EventArgs) Handles tsPurchaseRequest.Click
        gsDGV = dgvProductItem
        With frmRequestForm
            .ShowDialog()
            If .bClickOK = True Then
                cmbVENDOR_ID.SelectedValue = .gsVendor_select_Id
                cmbLOCATION_ID.SelectedValue = .gslocation_select_Id
                lblPR_ID.Text = .gsPR_select_Id
            End If
            frmRequestForm.Dispose()
        End With
        frmRequestForm = Nothing
    End Sub

    Private Sub frmPurchaseOrder_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            fRefreshField()
            fRefreshItem()
        End If
    End Sub
    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvProductItem, tsFindText.Text)
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
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "prepared_by")
            fCryParameterInsertValue(gscryRpt, gsUserDescription.ToUpper, "noted_by")
            fCryParameterInsertValue(gscryRpt, gsApproved_By.ToUpper, "approved_by")
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

    Private Sub dtpDATE_ValueChanged(sender As Object, e As EventArgs) Handles dtpDATE.ValueChanged

    End Sub

    Private Sub ToolStripLabel8_Click(sender As Object, e As EventArgs) Handles ToolStripLabel8.Click

    End Sub

    Private Sub cmbVENDOR_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbVENDOR_ID.SelectedIndexChanged

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub
End Class