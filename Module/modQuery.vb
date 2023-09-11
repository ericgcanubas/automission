Imports System.Data.Odbc
Module modQuery


    Public Sub SaveInvoiceItem(ByVal gsID As Integer, ByVal dgvProductItem As DataGridView, ByVal cmbOUTPUT_TAX_ID As ComboBox, ByVal cmbLOCATION_ID As ComboBox, ByVal dtpDATE As DateTimePicker)
        Dim GET_SO_ID As Integer = 0
        If dgvProductItem.Rows.Count = 0 Then Exit Sub
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE invoice_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE INVOICE_ID ='" & gsID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    Case "A"

                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("INVOICE_ITEMS")
                        SqlExecuted("INSERT INTO invoice_items SET BATCH_ID=" & GotNullNumber(.Cells("BATCH_ID").Value) & ",PRINT_IN_FORMS ='" & NumIsNull(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & GotNullNumber(NumIsNull(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & GotNullNumber(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & GotNullNumber(NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value)) & ",REF_LINE_ID =" & GotNullNumber(NumIsNull(.Cells("REF_LINE_ID").Value)) & ",ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",PRICE_LEVEL_ID =" & GotNullNumber(NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",INVOICE_ID ='" & gsID & "',GROUP_LINE_ID = " & GotNullNumber(.Cells("GROUP_LINE_ID").Value) & ",CUSTOM_FIELD5='" & gsPOS_LOG_ID & "';")
                        .Cells("ID").Value = i_ID

                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        SalesOrderItemUpdated(NumIsNull(.Cells("REF_LINE_ID").Value), NumIsNull(.Cells("QTY").Value), True, GET_SO_ID)
                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE invoice_items SET  BATCH_ID=" & GotNullNumber(.Cells("BATCH_ID").Value) & ", LINE_NO='" & i & "',QUANTITY='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & GotNullNumber(NumIsNull(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & GotNullNumber(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & GotNullNumber(NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value)) & ",REF_LINE_ID =" & GotNullNumber(NumIsNull(.Cells("REF_LINE_ID").Value)) & ",ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",PRICE_LEVEL_ID =" & GotNullNumber(NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & " WHERE INVOICE_ID ='" & gsID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        SalesOrderItemUpdated(NumIsNull(.Cells("REF_LINE_ID").Value), NumIsNull(.Cells("QTY").Value), True, GET_SO_ID)
                        '10 = src type
                        '24 =object
                    Case "D"

                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 24, 10, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                        SalesOrderItemUpdated(NumIsNull(.Cells("REF_LINE_ID").Value), 0, False, GET_SO_ID)
                        SqlExecuted("DELETE FROM invoice_items WHERE INVOICE_ID ='" & gsID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;")

                End Select
            End With
        Next

        InvoiceItemCalculate(dgvProductItem, cmbLOCATION_ID, dtpDATE)
    End Sub
    Private Sub InvoiceItemCalculate(ByVal dgvProductItem As DataGridView, ByVal cmbLOCATION_ID As ComboBox, ByVal dtpDATE As DateTimePicker)
        Dim LAST_SO As Integer = 0
        For N As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(N)
                If NumIsNull(.Cells("REF_LINE_ID").Value) <> 0 Then

                    Dim SO_ID As Integer = GetNumberFieldValue("sales_order_items", "id", NumIsNull(.Cells("REF_LINE_ID").Value), "SALES_ORDER_ID")
                    If LAST_SO <> SO_ID Then
                        CheckStatusSalesOrder(SO_ID, cmbLOCATION_ID)
                    End If

                    LAST_SO = SO_ID
                End If

                If .Cells("CONTROL_STATUS").Value = "D" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    If Date.Now.Date <> dtpDATE.Value Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    End If
                    .Cells("CONTROL_STATUS").Value = "S"
                End If


            End With
        Next
    End Sub
    Private Sub CheckStatusSalesOrder(ByVal THIS_SO_ID As Integer, ByVal cmbLOCATION_ID As ComboBox)
        Dim rd As OdbcDataReader = SqlReader($"select  * from sales_order_items Where SALES_ORDER_ID = '{THIS_SO_ID}' and `CLOSED` = '1' limit 1;")
        Dim E As Integer
        If rd.Read Then
            E = 12
        Else
            E = 2
        End If
        rd.Close()
        SqlExecuted($"Update sales_order SET `STATUS` = '{E}'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}'")

    End Sub
    Private Sub CheckStatusSalesOrderDelete(ByVal THIS_SO_ID As Integer, ByVal cmbLOCATION_ID As ComboBox)
        SqlExecuted($"UPDATE sales_order_items set `INVOICED_QTY` = NULL, `CLOSED` = '0'  Where SALES_ORDER_ID = '{THIS_SO_ID}';")
        SqlExecuted($"Update sales_order set `STATUS`='16'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}';")
    End Sub
    Private Sub SalesOrderItemUpdated(ByVal REF_LINE_ID As Integer, ByVal prINVOICED_QTY As Double, ByVal isUPDATE As Boolean, ByRef THIS_SO_ID As Integer)


        If REF_LINE_ID <> 0 Then
            Dim SqlStr As String
            Dim Get_SO_ID As Integer = GetNumberFieldValue("sales_order_items", "ID", REF_LINE_ID, "SALES_ORDER_ID")
            If isUPDATE = True Then
                SqlStr = "Update sales_order_items SET `INVOICED_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & REF_LINE_ID & "'"
            Else
                SqlStr = "Update sales_order_items SET `INVOICED_QTY` = NULL,`CLOSED` = '0' where ID = '" & REF_LINE_ID & "' "
            End If
            SqlExecuted(SqlStr)
            THIS_SO_ID = Get_SO_ID
        End If

    End Sub

    Public Sub SaveSalesReceiptItem(ByVal gsID As Integer, ByVal dgvProductItem As DataGridView, ByVal cmbOUTPUT_TAX_ID As ComboBox, ByVal cmbLOCATION_ID As ComboBox, ByVal dtpDATE As DateTimePicker)
        'obk = 53
        'src = 13
        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE sales_receipt_items SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_RECEIPT_ID ='" & gsID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & ";")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("SALES_RECEIPT_ITEMS")
                        SqlExecuted("INSERT INTO sales_receipt_items SET  BATCH_ID=" & GotNullNumber(.Cells("BATCH_ID").Value) & ", GROUP_LINE_ID=" & GotNullNumber(.Cells("GROUP_LINE_ID").Value) & ",LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & GotNullNumber(NumIsNull(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & GotNullNumber(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & GotNullNumber(NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & GotNullNumber(NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",SALES_RECEIPT_ID ='" & gsID & "',POS_TRX_TYPE=" & GotNullNumber(.Cells("POS_TRX_TYPE").Value) & ",POS_EDIT_QTY=" & GotNullNumber(.Cells("POS_EDIT_QTY").Value) & ",POS_NOTES=" & GotNullText(.Cells("POS_NOTES").Value) & ",PRINT_IN_FORMS=" & GotNullNumber(.Cells("PRINT_IN_FORMS").Value) & ",DEPOSITED=" & GotNullNumber(.Cells("DEPOSITED").Value) & ";")
                        .Cells("ID").Value = i_ID
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE sales_receipt_items SET BATCH_ID=" & GotNullNumber(.Cells("BATCH_ID").Value) & ", GROUP_LINE_ID=" & GotNullNumber(.Cells("GROUP_LINE_ID").Value) & ",QUANTITY='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & GotNullNumber(NumIsNull(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & GotNullNumber(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & GotNullNumber(NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value)) & ",PRICE_LEVEL_ID =" & GotNullNumber(NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ",ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",POS_TRX_TYPE=" & GotNullNumber(NumIsNull(.Cells("POS_TRX_TYPE").Value)) & ",POS_EDIT_QTY=" & GotNullNumber(NumIsNull(.Cells("POS_EDIT_QTY").Value)) & ",POS_NOTES=" & GotNullText(TextIsNull(.Cells("POS_NOTES").Value)) & ",PRINT_IN_FORMS=" & GotNullNumber(NumIsNull(.Cells("PRINT_IN_FORMS").Value)) & ",DEPOSITED=" & GotNullNumber(NumIsNull(.Cells("DEPOSITED").Value)) & " WHERE SALES_RECEIPT_ID ='" & gsID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "'")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)
                    Case "D"

                        SqlExecuted("DELETE FROM sales_receipt_items WHERE SALES_RECEIPT_ID ='" & gsID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "' limit 1;")
                        fINVENTORY_JOURNAL_PROCESS(dgvProductItem, i, True, 53, 13, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                End Select
            End With
        Next

        SalesReceiptItemCalculate(dgvProductItem, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

    End Sub

    Private Sub SalesReceiptItemCalculate(ByVal dgvProductItem As DataGridView, ByVal LOC_ID As Integer, ByVal DT As Date)
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                If .Cells("CONTROL_STATUS").Value = "D" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), LOC_ID, DT)
                ElseIf .Cells("CONTROL_STATUS").Value = "E" Then
                    fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), LOC_ID, DT)
                    .Cells("CONTROL_STATUS").Value = "S"
                ElseIf .Cells("CONTROL_STATUS").Value = "A" Then
                    If Date.Now.Date <> DT Then
                        fINVENTORY_ITEM_RECALCULATE_QTY(NumIsNull(.Cells("ITEM_ID").Value), LOC_ID, DT)
                    End If
                    .Cells("CONTROL_STATUS").Value = "S"
                End If
            End With
        Next
    End Sub
    Public Sub EnterToTabHandle(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

        End If
    End Sub
    Private Function GetObjectValue(ByVal c As Control, ByVal i As Integer) As Boolean
        Dim b As Boolean = False
        Select Case StrLeft(c.Controls(i).Name, 3)
            Case "lbl"
                Dim lbl As Label = c.Controls(i)
                b = True
            Case "txt"
                Dim txt As TextBox = c.Controls(i)
                RemoveHandler txt.KeyDown, AddressOf EnterToTabHandle
                AddHandler txt.KeyDown, AddressOf EnterToTabHandle
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
                RemoveHandler dtp.KeyDown, AddressOf EnterToTabHandle
                AddHandler dtp.KeyDown, AddressOf EnterToTabHandle
                b = True
            Case "rtb"
                Dim rtb As RichTextBox = c.Controls(i)
                RemoveHandler rtb.KeyDown, AddressOf EnterToTabHandle
                AddHandler rtb.KeyDown, AddressOf EnterToTabHandle
                b = True
            Case "num"
                Dim num As NumericUpDown = c.Controls(i)

                RemoveHandler num.KeyDown, AddressOf EnterToTabHandle
                AddHandler num.KeyDown, AddressOf EnterToTabHandle
                b = True
            Case "chk"
                Dim chk As CheckBox = c.Controls(i)
                RemoveHandler chk.KeyDown, AddressOf EnterToTabHandle
                AddHandler chk.KeyDown, AddressOf EnterToTabHandle
                b = True
            Case Else
                b = False
        End Select
        Return b
    End Function

    Private Function SetObjectValue(ByVal c As Control, ByVal i As Integer) As String

        Select Case StrLeft(c.Controls(i).Name, 3)
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
                        Return NumberFormatFixed(lbl.Text)
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
                Dim vx As Integer = NumIsNull(cmb.SelectedValue)
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
    Private Sub ObjectTypes(ByVal c As Control, ByVal i As Integer, ByVal v As String)
        Select Case StrLeft(c.Controls(i).Name, 3)
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
                    '    If NumIsNull(v) = 0 Then
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
    Public Sub ClearAndRefresh(ByVal c As Control)
        gsClearObject = True
        For i As Integer = 0 To c.Controls.Count - 1
            Dim stvalue As String = c.Controls.Item(i).Name
            If GetObjectValue(c, i) = True Then
                ObjectTypes(c, i, "")
            End If
        Next
        gsClearObject = False
    End Sub
    Private Sub SearchingControl(ByVal c As Control, ByVal sField As String, ByVal xValue As String)
        For i As Integer = 0 To c.Controls.Count - 1
            If TypeOf c.Controls(i) Is TabControl Then
                Dim T As TabControl = c.Controls(i)
                SearchingControl(T, sField, xValue)
            ElseIf TypeOf c.Controls(i) Is TabPage Then
                Dim T As TabPage = c.Controls(i)
                SearchingControl(T, sField, xValue)
            ElseIf TypeOf c.Controls(i) Is GroupBox Then
                Dim T As GroupBox = c.Controls(i)
                SearchingControl(T, sField, xValue)

            Else
                Dim stvalue As String = c.Controls.Item(i).Name
                Dim d As String = stvalue.ToLower.Substring(3)
                If d = sField.ToLower Then
                    ObjectTypes(c, i, xValue)
                    Exit For
                End If
            End If
        Next
    End Sub
    Public Sub DisplayFields(ByVal c As Control, ByVal rd As OdbcDataReader)
        Try
            If rd.Read() Then
                For i As Integer = 0 To rd.FieldCount - 1
                    SearchingControl(c, rd.GetName(i), rd(i).ToString)
                Next
            End If
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                DisplayFields(c, rd)
            Else
                End
            End If
        End Try
    End Sub
    Private Function RemoveLastNumber(ByVal xvalue As String) As String
        If IsNumeric(StrRight(xvalue, 1)) = True Then
            Return StrLeft(xvalue, xvalue.Length - 1)
        Else
            Return xvalue
        End If

    End Function

    Public Function SqlUpdate(ByVal ctrls As Control) As String
        Dim err_i As Integer = 0
        Try
            Dim xQuery As String = ""
            For i As Integer = 0 To ctrls.Controls.Count - 1
                err_i = i
                Dim stvalue As String = ctrls.Controls.Item(i).Name
                If Trim(ctrls.Controls.Item(i).Tag) = "" Then
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

                Dim obj_value As String = SetObjectValue(ctrls, i)

                If GetObjectValue(ctrls, i) = True Then
                    Dim st_field_value As String
                    Dim ex_value As String = SetObjectValue(ctrls, i)
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
            MessageBoxExclamation(ex.Message & "(" & err_i & ")")
            Return Nothing
        End Try
    End Function

    Public Sub SqlCreate(ByVal ctrls As Control, ByRef RefField As String, ByRef RefValue As String)
        Dim err_i As Integer = 0
        Dim str_Field As String = ""
        Dim str_Value As String = ""
        Try


            For i As Integer = 0 To ctrls.Controls.Count - 1
                err_i = i
                Dim stvalue As String = ctrls.Controls.Item(i).Name
                If Trim(ctrls.Controls.Item(i).Tag) = "" Then
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

                Dim obj_value As String = SetObjectValue(ctrls, i)

                If GetObjectValue(ctrls, i) = True Then

                    Dim ex_value As String = SetObjectValue(ctrls, i)
                    If ex_value = "NULL" Then
                        str_Value &= $"{IIf(str_Field <> "", ",", "")}{ex_value}"
                        str_Field &= $"{IIf(str_Field <> "", ",", "")}{stvalue.Substring(3)}"

                    Else

                        str_Value &= $"{IIf(str_Field <> "", ",", "")}'{Trim(ex_value.Replace("'", "`"))}'"
                        str_Field &= $"{IIf(str_Field <> "", ",", "")}{stvalue.Substring(3)}"

                    End If




                End If
            Next

            RefField = str_Field
            RefValue = str_Value
        Catch ex As Exception
            MessageBoxExclamation(ex.Message & "(" & err_i & ")")

        End Try

    End Sub
End Module
