Imports System.Data.Odbc
Module modQuery


    Public Sub fInvoice_Save_item_set(ByVal gsID As Integer, ByVal dgvProductItem As DataGridView, ByVal cmbOUTPUT_TAX_ID As ComboBox, ByVal cmbLOCATION_ID As ComboBox, ByVal dtpDATE As DateTimePicker)
        Dim GET_SO_ID As Integer = 0
        If dgvProductItem.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        fExecutedOnly("UPDATE invoice_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE INVOICE_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    Case "A"

                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("INVOICE_ITEMS")
                        fExecutedOnly("INSERT INTO invoice_items SET BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ",PRINT_IN_FORMS ='" & fNumisNULL(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",REF_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("REF_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",INVOICE_ID ='" & gsID & "',GROUP_LINE_ID = " & fGotNullNumber(.Cells("GROUP_LINE_ID").Value) & ",CUSTOM_FIELD5='" & gsPOS_LOG_ID & "';")
                        .Cells("ID").Value = i_ID

                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        fSO_ITEM_UPDATE(fNumisNULL(.Cells("REF_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True, GET_SO_ID)
                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        fExecutedOnly("UPDATE invoice_items SET  BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ", LINE_NO='" & i & "',QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",REF_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("REF_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & " WHERE INVOICE_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        fSO_ITEM_UPDATE(fNumisNULL(.Cells("REF_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True, GET_SO_ID)
                        '10 = src type
                        '24 =object
                    Case "D"

                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        fSO_ITEM_UPDATE(fNumisNULL(.Cells("REF_LINE_ID").Value), 0, False, GET_SO_ID)
                        fExecutedOnly("DELETE FROM invoice_items WHERE INVOICE_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;")

                End Select
            End With
        Next

        fItem_Calculate(dgvProductItem, cmbLOCATION_ID, dtpDATE)
    End Sub
    Private Sub fItem_Calculate(ByVal dgvProductItem As DataGridView, ByVal cmbLOCATION_ID As ComboBox, ByVal dtpDATE As DateTimePicker)
        Dim LAST_SO As Integer = 0
        For N As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(N)
                If fNumisNULL(.Cells("REF_LINE_ID").Value) <> 0 Then

                    Dim SO_ID As Integer = fNumFieldValue("sales_order_items", "id", fNumisNULL(.Cells("REF_LINE_ID").Value), "SALES_ORDER_ID")
                    If LAST_SO <> SO_ID Then
                        fCheck_Status_SO(SO_ID, cmbLOCATION_ID)
                    End If

                    LAST_SO = SO_ID
                End If

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
    Private Sub fCheck_Status_SO(ByVal THIS_SO_ID As Integer, ByVal cmbLOCATION_ID As ComboBox)

        Dim rd As OdbcDataReader = fReader($"select  * from sales_order_items Where SALES_ORDER_ID = '{THIS_SO_ID}' and `CLOSED` = '1' limit 1;")
        Dim E As Integer
        If rd.Read Then
            E = 12 ' item received
        Else
            E = 2
        End If
        rd.Close()
        fExecutedOnly($"Update sales_order set `STATUS` = '{E}'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}' limit 1")

    End Sub
    Private Sub fCheck_Status_SO_DEL(ByVal THIS_SO_ID As Integer, ByVal cmbLOCATION_ID As ComboBox)

        Dim SQL As String = $"UPDATE sales_order_items set `INVOICED_QTY` = NULL, `CLOSED` = '0'  Where SALES_ORDER_ID = '{THIS_SO_ID}';"
        SQL = SQL & $"Update sales_order set `STATUS` = '16'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}' limit 1;"

        fExecutedOnly(SQL)

    End Sub
    Private Sub fSO_ITEM_UPDATE(ByVal REF_LINE_ID As Integer, ByVal prINVOICED_QTY As Double, ByVal isUPDATE As Boolean, ByRef THIS_SO_ID As Integer)

        Dim SO_SQL As String = ""
        If REF_LINE_ID <> 0 Then
            Dim Get_SO_ID As Integer = fNumFieldValue("sales_order_items", "ID", REF_LINE_ID, "SALES_ORDER_ID")
            If isUPDATE = True Then
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & REF_LINE_ID & "' Limit 1;"
            Else
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = NULL,`CLOSED` = '0' where ID = '" & REF_LINE_ID & "' Limit 1;"
            End If

            THIS_SO_ID = Get_SO_ID
        End If
        fExecutedOnly(SO_SQL)
    End Sub

    Public Sub fSales_Receipt_Save_Item_Set(ByVal gsID As Integer, ByVal dgvProductItem As DataGridView, ByVal cmbOUTPUT_TAX_ID As ComboBox, ByVal cmbLOCATION_ID As ComboBox, ByVal dtpDATE As DateTimePicker)
        'obk = 53
        'src = 13
        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        fExecutedOnly("UPDATE sales_receipt_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_RECEIPT_ID ='" & gsID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & ";")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("SALES_RECEIPT_ITEMS")
                        fExecutedOnly("INSERT INTO sales_receipt_items SET  BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ", GROUP_LINE_ID=" & fGotNullNumber(.Cells("GROUP_LINE_ID").Value) & ",LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",SALES_RECEIPT_ID ='" & gsID & "',POS_TRX_TYPE=" & fGotNullNumber(.Cells("POS_TRX_TYPE").Value) & ",POS_EDIT_QTY=" & fGotNullNumber(.Cells("POS_EDIT_QTY").Value) & ",POS_NOTES=" & fGotNullText(.Cells("POS_NOTES").Value) & ",PRINT_IN_FORMS=" & fGotNullNumber(.Cells("PRINT_IN_FORMS").Value) & ",DEPOSITED=" & fGotNullNumber(.Cells("DEPOSITED").Value) & ";")
                        .Cells("ID").Value = i_ID
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        fExecutedOnly("UPDATE sales_receipt_items SET BATCH_ID=" & fGotNullNumber(.Cells("BATCH_ID").Value) & ", GROUP_LINE_ID=" & fGotNullNumber(.Cells("GROUP_LINE_ID").Value) & ",QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",POS_TRX_TYPE=" & fGotNullNumber(fNumisNULL(.Cells("POS_TRX_TYPE").Value)) & ",POS_EDIT_QTY=" & fGotNullNumber(fNumisNULL(.Cells("POS_EDIT_QTY").Value)) & ",POS_NOTES=" & fGotNullText(fTextisNULL(.Cells("POS_NOTES").Value)) & ",PRINT_IN_FORMS=" & fGotNullNumber(fNumisNULL(.Cells("PRINT_IN_FORMS").Value)) & ",DEPOSITED=" & fGotNullNumber(fNumisNULL(.Cells("DEPOSITED").Value)) & " WHERE SALES_RECEIPT_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' Limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    Case "D"

                        fExecutedOnly("DELETE FROM sales_receipt_items WHERE SALES_RECEIPT_ID ='" & gsID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                End Select
            End With
        Next

        fItemCalculate(dgvProductItem, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

    End Sub

    Private Sub fItemCalculate(ByVal dgvProductItem As DataGridView, ByVal LOC_ID As Integer, ByVal DT As Date)
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                If .Cells("CONTROL_STATUS").Value = "D" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), LOC_ID, DT)
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), LOC_ID, DT)
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    If Date.Now.Date <> DT Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(fNumisNULL(.Cells("ITEM_ID").Value), LOC_ID, DT)
                    End If
                    .Cells("CONTROL_STATUS").Value = "S"
                End If
            End With
        Next
    End Sub
    Public Sub fEnterToTab(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub
    Private Function fObject_Get(ByVal c As Control, ByVal i As Integer) As Boolean
        Dim b As Boolean = False
        Select Case fLeft(c.Controls(i).Name, 3)
            Case "lbl"
                Dim lbl As Label = c.Controls(i)
                b = True
            Case "txt"
                Dim txt As TextBox = c.Controls(i)
                RemoveHandler txt.KeyDown, AddressOf fEnterToTab
                AddHandler txt.KeyDown, AddressOf fEnterToTab
                b = True
            Case "cmb"
                Dim cmb As ComboBox = c.Controls(i)
                If cmb.AccessibleName = "0" Then
                    b = False
                Else
                    b = True
                End If
            Case "cbo"
                Dim cbo As ComboBox = c.Controls(i)
                b = True
            Case "dtp"
                Dim dtp As DateTimePicker = c.Controls(i)
                RemoveHandler dtp.KeyDown, AddressOf fEnterToTab
                AddHandler dtp.KeyDown, AddressOf fEnterToTab
                b = True
            Case "rtb"
                Dim rtb As RichTextBox = c.Controls(i)
                RemoveHandler rtb.KeyDown, AddressOf fEnterToTab
                AddHandler rtb.KeyDown, AddressOf fEnterToTab
                b = True
            Case "num"
                Dim num As NumericUpDown = c.Controls(i)

                RemoveHandler num.KeyDown, AddressOf fEnterToTab
                AddHandler num.KeyDown, AddressOf fEnterToTab
                b = True
            Case "chk"
                Dim chk As CheckBox = c.Controls(i)
                RemoveHandler chk.KeyDown, AddressOf fEnterToTab
                AddHandler chk.KeyDown, AddressOf fEnterToTab
                b = True
            Case Else
                b = False
        End Select
        Return b
    End Function

    Private Function fObject_Value(ByVal c As Control, ByVal i As Integer) As String

        Select Case fLeft(c.Controls(i).Name, 3)
            Case "lbl"
                Dim lbl As Label = c.Controls(i)
                If lbl.Text = "" Then
                    Return "NULL"
                ElseIf lbl.AccessibleDescription = "null" Then
                    If lbl.Text = "" Or Val(lbl.Text) = 0 Then
                        Return "NULL"
                    Else
                        Return lbl.Text
                    End If
                Else
                    If lbl.Name.ToUpper Like "*ACCOUNT*" Then
                        Return lbl.Text
                    ElseIf IsNumeric(lbl.Text) = True Then
                        Return fNumFormatFixed(lbl.Text)
                    Else
                        Return lbl.Text
                    End If
                End If
            Case "txt"
                Dim txt As TextBox = c.Controls(i)
                If txt.AccessibleDescription = "null" And Trim(txt.Text) = "" Then
                    Return "NULL"
                Else
                    Return txt.Text
                End If

            Case "cmb"
                Dim cmb As ComboBox = c.Controls(i)
                Dim vx As Integer = fNumisNULL(cmb.SelectedValue)
                If vx = 0 Then
                    If cmb.DropDownStyle = ComboBoxStyle.DropDown Or cmb.AccessibleDescription = "null" Then
                        Return "NULL"

                    ElseIf cmb.AccessibleDescription = "0" Then
                        Return "0"
                    Else

                        Return ""
                    End If
                Else
                    Return vx
                End If


            Case "cbo"
                Dim cbo As ComboBox = c.Controls(i)
                Return cbo.Text
            Case "dtp"
                Dim dtp As DateTimePicker = c.Controls(i)

                If dtp.Format = DateTimePickerFormat.Time Then
                    If dtp.Checked = True Then
                        Return dtp.Value.ToLongTimeString
                    Else
                        Return "NULL"
                    End If
                Else
                    If dtp.Checked = True Then
                        Return Format(dtp.Value, "yyyy-MM-dd")
                    Else
                        Return "NULL"
                    End If
                End If


            Case "rtb"
                Dim rtb As RichTextBox = c.Controls(i)
                Return rtb.Text
            Case "num"
                Dim num As NumericUpDown = c.Controls(i)

                Return num.Value

            Case "chk"

                Dim chk As CheckBox = c.Controls(i)
                If chk.Checked = True Then
                    Return "1"
                Else
                    Return "0"
                End If
            Case Else
                Return ""
        End Select
    End Function
    Private Sub fObject_Type(ByVal c As Control, ByVal i As Integer, ByVal v As String)
        Select Case fLeft(c.Controls(i).Name, 3)
            Case "lbl"
                Dim lbl As Label = c.Controls(i)
                If lbl.AccessibleDescription = "bool" Then
                    If v = "True" Then
                        lbl.Text = "1"
                    ElseIf v = "False" Then
                        lbl.Text = "0"
                    ElseIf IsNumeric(v) = True Then
                        lbl.Text = v
                    Else
                        lbl.Text = "0"
                    End If
                Else
                    lbl.Text = v
                End If
            Case "txt"
                Dim txt As TextBox = c.Controls(i)
                txt.Text = v
            Case "cmb"
                Dim cmb As ComboBox = c.Controls(i)
                If v.Length = 0 Then
                    If cmb.DropDownStyle = ComboBoxStyle.DropDownList Then
                        If cmb.Items.Count <> 0 Then
                            cmb.SelectedIndex = 0
                        Else
                            cmb.SelectedIndex = -1
                        End If
                    Else
                        cmb.SelectedIndex = -1
                    End If
                    cmb.Enabled = True
                Else
                    cmb.SelectedValue = Val(v)
                    'If cmb.Name = "cmbLOCATION_ID" Or cmb.Name = "cmbTRANSFER_TO_ID" Or cmb.Name = "cmbASSEMBLY_ITEM_ID" Or cmb.Name = "cmbBANK_ACCOUNT_ID" Or cmb.Name = "cmbCUSTOMER_ID" Or cmb.Name = "cmbVENDOR_ID" Then
                    '    If fNumisNULL(v) = 0 Then
                    '        cmb.Enabled = True
                    '    Else
                    '        cmb.Enabled = False
                    '    End If
                    'End If
                End If
            Case "cbo"
                Dim cbo As ComboBox = c.Controls(i)
                cbo.Text = v
            Case "dtp"
                Dim dtp As DateTimePicker = c.Controls(i)
                If dtp.Format = DateTimePickerFormat.Time Then

                Else
                    dtp.Format = DateTimePickerFormat.Custom
                    dtp.CustomFormat = "MM/dd/yyyy"
                End If
                If gsClearObject = True Then
                    dtp.Checked = True
                End If

                If IsDate(v) = True And dtp.Format <> DateTimePickerFormat.Time Then
                    dtp.Value = v
                    dtp.Checked = True
                    If dtp.Name = "dtpDATE" And v <> "" Then
                        ' dtp.Enabled = False
                    Else
                        'dtp.Enabled = True
                    End If
                ElseIf dtp.Format = DateTimePickerFormat.Time Then
                    If v = "" Then
                        dtp.Value = DateTime.Now
                        dtp.Checked = False
                    Else
                        dtp.Value = Date.Now.Date.ToString("yyyy-MM-dd") & " " & v
                        dtp.Checked = True
                    End If

                Else
                    If dtp.ShowCheckBox = True Then
                        dtp.Checked = False
                        dtp.Enabled = True
                    Else
                        dtp.Checked = True
                        dtp.Enabled = True
                    End If
                End If
            Case "rtb"
                Dim rtb As RichTextBox = c.Controls(i)
                rtb.Text = v
            Case "num"
                Dim num As NumericUpDown = c.Controls(i)
                If Val(num.AccessibleName) = 0 Then
                Else
                    num.DecimalPlaces = 2
                End If
                num.Value = Val(v)

            Case "chk"
                Dim chk As CheckBox = c.Controls(i)
                Dim b As Boolean
                If v = "" Then
                    b = False
                Else
                    b = v
                End If
                If b = False Then
                    chk.Checked = False
                Else
                    chk.Checked = True
                End If
            Case Else
        End Select
    End Sub
    Public Sub fCLean_and_refresh(ByVal c As Control)
        gsClearObject = True
        For i As Integer = 0 To c.Controls.Count - 1
            Dim stvalue As String = c.Controls.Item(i).Name
            If fObject_Get(c, i) = True Then
                fObject_Type(c, i, "")
            End If
        Next
        gsClearObject = False
    End Sub
    Private Sub fSearchControl(ByVal c As Control, ByVal sField As String, ByVal xValue As String)
        For i As Integer = 0 To c.Controls.Count - 1
            If TypeOf c.Controls(i) Is TabControl Then
                Dim T As TabControl = c.Controls(i)
                fSearchControl(T, sField, xValue)

            ElseIf TypeOf c.Controls(i) Is TabPage Then
                Dim T As TabPage = c.Controls(i)
                fSearchControl(T, sField, xValue)
            ElseIf TypeOf c.Controls(i) Is GroupBox Then
                Dim T As GroupBox = c.Controls(i)
                fSearchControl(T, sField, xValue)

            Else
                Dim stvalue As String = c.Controls.Item(i).Name
                Dim d As String = stvalue.ToLower.Substring(3)
                If d = sField.ToLower Then
                    fObject_Type(c, i, xValue)
                    Exit For
                End If
            End If
        Next
    End Sub
    Public Sub fDisplayField(ByVal c As Control, ByVal rd As OdbcDataReader)
        Try
            If rd.Read() Then
                For i As Integer = 0 To rd.FieldCount - 1
                    fSearchControl(c, rd.GetName(i), rd(i).ToString)
                Next
            End If
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fDisplayField(c, rd)
            Else
                End
            End If
        End Try
    End Sub
    Private Function fRemoveLastnum(ByVal xvalue As String) As String
        If IsNumeric(fRight(xvalue, 1)) = True Then
            Return fLeft(xvalue, xvalue.Length - 1)
        Else
            Return xvalue
        End If

    End Function
    ' UPDATING
    Public Function fFieldCollector(ByVal c As Control) As String
        Dim err_i As Integer = 0
        Try
            Dim xQuery As String = ""
            For i As Integer = 0 To c.Controls.Count - 1
                err_i = i
                Dim stvalue As String = c.Controls.Item(i).Name
                '// CHECKING if LAST WORD IS NUMBER
                If Trim(c.Controls.Item(i).Tag) = "" Then
                    If IsNumeric(stvalue.Substring(stvalue.Length - 1, 1)) = True Then
                        Dim lastNum As String = stvalue.Substring(stvalue.Length - 1, 1)
                        Dim temp_text As String = stvalue.Replace(lastNum, "")

                        If temp_text.Substring(3) = "CUSTOM_FIELD" Then
                            temp_text = ""
                        Else
                            stvalue = temp_text
                        End If

                    End If
                End If

                Dim obj_value As String = fObject_Value(c, i)

                If fObject_Get(c, i) = True Then
                    Dim st_field_value As String
                    Dim ex_value As String = fObject_Value(c, i)
                    If ex_value = "NULL" Then
                        st_field_value = stvalue.Substring(3) & " = " & ex_value & ""
                    Else
                        st_field_value = stvalue.Substring(3) & " = '" & Trim(ex_value.Replace("'", "`")) & "'"
                    End If


                    If xQuery = "" Then
                        xQuery = st_field_value
                    Else
                        xQuery = xQuery & "," & st_field_value
                    End If

                End If
            Next
            Return xQuery
        Catch ex As Exception
            fMessageboxExclamation(ex.Message & "(" & err_i & ")")
            Return Nothing
        End Try
    End Function

    Public Function fFieldCollector_INSERT(ByVal c As Control) As String
        Dim err_i As Integer = 0
        Try
            Dim str_Field As String = ""
            Dim str_value As String = ""
            Dim xQuery As String = ""
            For i As Integer = 0 To c.Controls.Count - 1
                err_i = i
                Dim stvalue As String = c.Controls.Item(i).Name
                '// CHECKING if LAST WORD IS NUMBER
                If Trim(c.Controls.Item(i).Tag) = "" Then
                    If IsNumeric(stvalue.Substring(stvalue.Length - 1, 1)) = True Then
                        Dim lastNum As String = stvalue.Substring(stvalue.Length - 1, 1)
                        Dim temp_text As String = stvalue.Replace(lastNum, "")

                        If temp_text.Substring(3) = "CUSTOM_FIELD" Then
                            temp_text = ""
                        Else
                            stvalue = temp_text
                        End If

                    End If
                End If

                Dim obj_value As String = fObject_Value(c, i)

                If fObject_Get(c, i) = True Then

                    Dim ex_value As String = fObject_Value(c, i)
                    If ex_value = "NULL" Then
                        ' 

                        str_Field = str_Field & $"{IIf(str_Field <> "", ",", "")} { stvalue.Substring(3)}"

                        str_value = str_value & $"{IIf(str_Field <> "", ",", "")} {ex_value}"
                    Else


                        str_Field = str_Field & $"{IIf(str_Field <> "", ",", "")} { stvalue.Substring(3)}"

                        str_value = str_value & $"{IIf(str_Field <> "", ",", "")} '{Trim(ex_value.Replace("'", "`"))}'"
                    End If




                End If
            Next

            xQuery = $"{str_Field} VALUES({str_value})"
            Return xQuery
        Catch ex As Exception
            fMessageboxExclamation(ex.Message & "(" & err_i & ")")
            Return Nothing
        End Try
    End Function
End Module
