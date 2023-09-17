Imports System.Data.Odbc
Module modAddItem

    Public Sub GS_GetExpiration(ByVal BATCH_ID As Integer, ByVal ITEM_ID As Integer, ByRef Expired_Date As Date, ByRef IsExpired As Boolean)
        Dim rd As OdbcDataReader = SqlReader($"select EXPIRY_DATE from item_batches where ID = '{BATCH_ID}' and ITEM_ID ='{ITEM_ID}' limit 1")
        If rd.Read Then
            IsExpired = True
            Expired_Date = CDate(GF_TextIsNull(rd("EXPIRY_DATE")))
        Else
            IsExpired = False
        End If
        rd.Close()
    End Sub
    Public Function GF_SetExpiration(ByVal ITEM_ID As Integer, ByVal dtpDate As DateTimePicker) As Integer
        Dim BATCH_ID As Integer
        If dtpDate.Visible = False Or dtpDate.Checked = False Then
            BATCH_ID = 0
        Else

            Dim rd As OdbcDataReader = SqlReader($"select ID from item_batches where ITEM_ID ='{ITEM_ID}' and EXPIRY_DATE = '{ DateFormatMySql(dtpDate.Value)}' limit 1")
            If rd.Read Then
                BATCH_ID = GF_NumIsNull(rd("ID"))

            Else
                BATCH_ID = GF_GetNewItemBatch(ITEM_ID, dtpDate.Value)
            End If
            rd.Close()
        End If

        Return BATCH_ID
    End Function
    Private Function GF_GetNewItemBatch(ByVal ITEM_ID As Integer, ByVal DT As Date) As Integer
        Dim ThisID As Integer = ObjectTypeMapId("item_batches")
        Dim BATCH_NO As String = Format(Val(GF_GetMaxFieldLine("BATCH_NO", "item_batches", "ITEM_ID", ITEM_ID)), "000000")
        SqlExecuted($"INSERT INTO item_batches SET ID = '{ThisID}',ITEM_ID='{ITEM_ID}',BATCH_NO='{BATCH_NO}',EXPIRY_DATE='{DateFormatMySql(DT)}'")
        PrompNotify("Item batch expiration", "New batch entry save.", True)

        Return ThisID
    End Function
    Public Function GF_InventoryAdjustmentGotLatestEntry(ByVal prItem_ID As Integer, ByVal DateTarget As Date, ByVal Location_ID As Integer)
        Dim IsExist As Boolean = False
        Dim SQL As String = $"SELECT * FROM inventory_adjustment  AS i INNER JOIN inventory_adjustment_items AS a ON a.`INVENTORY_ADJUSTMENT_ID` = i.`ID`  WHERE a.`ITEM_ID` = '{prItem_ID}' AND i.`DATE` >= '{DateFormatMySql(DateTarget)}' AND i.`LOCATION_ID` = '{Location_ID}'  limit 1"

        Dim rd As OdbcDataReader = SqlReader(SQL)
        If rd.Read Then
            IsExist = True
        End If
        rd.Close()
        Return IsExist
    End Function
    Public Sub GS_TaxValue(ByVal dvg As DataGridView)
        Dim i As Integer = dvg.CurrentRow.Index
        With dvg.Rows.Item(i)
            Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
            .Cells(11).Value = IIf(ID_is_number = True, "E", "A")
            Dim t As Boolean = .Cells("Tax").Value
            If t = True Then
                .Cells("Tax").Value = False
            Else
                .Cells("Tax").Value = True
            End If
        End With

    End Sub
    Public Sub GS_ClosedValue(ByVal dvg As DataGridView)
        Dim i As Integer = dvg.CurrentRow.Index
        With dvg.Rows.Item(i)
            Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
            .Cells(11).Value = IIf(ID_is_number = True, "E", "A")
            Dim t As Boolean = .Cells("Closed").Value
            If t = True Then
                .Cells("Closed").Value = False
            Else
                .Cells("Closed").Value = True
            End If
        End With

    End Sub
    Public Sub GS_RowDataItemWriteCheck(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prClass_ID As String, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0 'default is zero  only
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim REF_LINE_ID As String = ""
        Dim RATE_TYPE As String = ""
        Dim ITEM_TYPE As Integer = 0
        Dim CLASS_NAME As String = GF_GetStringFieldValue("CLASS", "ID", prClass_ID, "NAME")
        Dim BATCH_NO As String = GF_GetStringFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        '  Dim cn As New MySqlConnection(mysqlConstr)
        Try

            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then


                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, NumberFormatStandard(price), discount_type, NumberFormatStandard(discount_rate), NumberFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, CLASS_NAME, prClass_ID, ITEM_TYPE, ASSET_ACCOUNT_ID, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = NumberFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = NumberFormatStandard(discount_rate)
                        .Cells(8).Value = NumberFormatStandard(Amt)
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ORG_AMT
                        .Cells(18).Value = item_ID
                        .Cells(19).Value = CLASS_NAME
                        .Cells(20).Value = prClass_ID
                        .Cells(21).Value = ITEM_TYPE
                        .Cells(22).Value = ASSET_ACCOUNT_ID
                        .Cells(23).Value = prBATCH_ID
                        .Cells(24).Value = BATCH_NO
                    End With

                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_RowDataItemPurchaseOrder(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal PR_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim REF_LINE_ID As String = ""
        Dim RATE_TYPE As String = ""

        '  Dim cn As New MySqlConnection(mysqlConstr)
        Try

            '  cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, Format(price, "standard"), discount_type, Format(discount_rate, "standard"), Format(Amt, "Standard"), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, PR_ID)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = Format(price, "standard")
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = Format(discount_rate, "standard")
                        .Cells(8).Value = Format(Amt, "Standard")
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ORG_AMT
                        .Cells(18).Value = item_ID
                        .Cells(19).Value = PR_ID

                    End With

                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try

    End Sub

    Public Sub GS_RowDataItemPurchaseRequest(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim REF_LINE_ID As String = ""
        Dim RATE_TYPE As String = ""

        '  Dim cn As New MySqlConnection(mysqlConstr)
        Try

            '  cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, Format(price, "standard"), discount_type, Format(discount_rate, "standard"), Format(Amt, "Standard"), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = Format(price, "standard")
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = Format(discount_rate, "standard")
                        .Cells(8).Value = Format(Amt, "Standard")
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ORG_AMT
                        .Cells(18).Value = item_ID


                    End With

                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If


        End Try

    End Sub
    Public Sub GS_RowDataItemSalesReceipt(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prPRICE_LEVEL_ID As String, ByVal prPrintINForm As Boolean, ByVal prGROUP_LINE_ID As Integer, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim BATCH_NO As String = GF_GetStringFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""

        Dim RATE_TYPE As String = ""
        Dim PRICE_LEVEL_ID As String = prPRICE_LEVEL_ID

        Dim ITEM_TYPE As Integer
        Dim G_PRINT_IN_FORMS As Boolean = False
        Dim NON_DISCOUNTED_ITEM As Integer
        Dim NON_PORFOLIO_COMPUTATION As Integer
        Try

            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then

                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    NON_DISCOUNTED_ITEM = GF_NumIsNull(rd("NON_DISCOUNTED_ITEM"))
                    G_PRINT_IN_FORMS = CBool(GF_NumIsNull(rd("PRINT_INDIVIDUAL_ITEMS")))
                    NON_PORFOLIO_COMPUTATION = CBool(GF_NumIsNull(rd("NON_PORFOLIO_COMPUTATION")))
                End If
                rd.Close()

                Dim POS_TRX_TYPE As Integer = 0
                Dim POS_EDIT_QTY As Integer = 0
                Dim POS_NOTES As String = ""


                Dim DEPOSITED As Integer = 0


                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

                If bNEw = True Then


                    If ITEM_TYPE = 6 And NON_PORFOLIO_COMPUTATION = True Then
                        'CUSTOM BUNDLE
                        .Rows.Add("N", gsITEM_CODE, Item_Description, qty, UM_Description, 0, discount_type, IIf(DISCOUNT_ID = "1", Val(discount_rate), NumberFormatStandard(discount_rate)), 0, tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, COGS_AMOUNT_ID, ASSET_ACCOUNT_ID, INCOME_ACCOUNT_ID, PRICE_LEVEL_ID, ORG_AMT, item_ID, POS_TRX_TYPE, POS_EDIT_QTY, POS_NOTES, prPrintINForm, DEPOSITED, ITEM_TYPE, NON_DISCOUNTED_ITEM, prGROUP_LINE_ID, prBATCH_ID, BATCH_NO)
                        Dim dgvTop_Index As Integer = dgv.Rows.Count - 1
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        'CUSTOM DATA
                        FrmCustomGroupItem.gsITEM_ID = item_ID
                        FrmCustomGroupItem.ShowDialog()
                        Dim d As DataGridView = FrmCustomGroupItem.dgvSelected
                        Dim gsGROUP_ID As Integer = FrmCustomGroupItem.gsITEM_ID
                        Dim D_TOTAL As Double = 0
                        If d.Rows.Count <> 0 Then

                            For N As Integer = 0 To d.Rows.Count - 1
                                Dim r As DataGridViewRow = d.Rows(N)
                                'ADD ITEM GROUP
                                Dim rd_item As OdbcDataReader = SqlReader($"select * from item where `id` = '{r.Cells("ITEM_ID").Value}' limit 1;")
                                D_TOTAL += GF_NumIsNull(r.Cells("RATE").Value)

                                If rd_item.Read Then
                                    GS_RowDataItemSalesReceipt(dgv, True, r.Cells("ITEM_ID").Value, r.Cells("QTY").Value, NumberFormatStandard(r.Cells("RATE").Value / r.Cells("QTY").Value), IIf(GF_NumIsNull(r.Cells("RATE").Value) = 0, 0, discount_type), IIf(GF_NumIsNull(r.Cells("RATE").Value) = 0, 0, discount_rate), NumberFormatStandard(r.Cells("RATE").Value), IIf(GF_NumIsNull(rd_item("TAXABLE")) = 0, False, True), GF_NumIsNull(rd_item("BASE_UNIT_ID")), "A", 1, 0, 0, "", G_PRINT_IN_FORMS, item_ID, 0)
                                End If
                                rd_item.Close()

                            Next
                            dgv.Rows(dgvTop_Index).Cells("UNIT_PRICE").Value = NumberFormatStandard(D_TOTAL)
                            dgv.Rows(dgvTop_Index).Cells("AMOUNT").Value = NumberFormatStandard(D_TOTAL)
                        Else
                            dgv.Rows.RemoveAt(dgvTop_Index)

                            MessageBoxInfo("No Item Selected - Transaction canceled.")
                        End If
                        FrmCustomGroupItem.Dispose()
                        FrmCustomGroupItem = Nothing

                    Else

                        .Rows.Add("N", gsITEM_CODE, Item_Description, qty, UM_Description, NumberFormatStandard(price), discount_type, IIf(DISCOUNT_ID = "1", Val(discount_rate), NumberFormatStandard(Val(discount_rate))), NumberFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, COGS_AMOUNT_ID, ASSET_ACCOUNT_ID, INCOME_ACCOUNT_ID, PRICE_LEVEL_ID, ORG_AMT, item_ID, POS_TRX_TYPE, POS_EDIT_QTY, POS_NOTES, prPrintINForm, DEPOSITED, ITEM_TYPE, NON_DISCOUNTED_ITEM, prGROUP_LINE_ID, prBATCH_ID, BATCH_NO)
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        Dim rd_group As OdbcDataReader = SqlReader("SELECT ic.*,s.`TAXABLE`,i.TYPE,s.BASE_UNIT_ID FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                        While rd_group.Read

                            'ADD ITEM GROUP
                            Dim r_rate As Double = IIf(GF_NumIsNull(rd_group("RATE")) <= Amt, GF_NumIsNull(rd_group("RATE")), Amt)
                            Dim BS_UNIT As String = GF_TextIsNull(rd_group("BASE_UNIT_ID"))
                            GS_RowDataItemSalesReceipt(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, discount_type), IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, discount_rate), (r_rate * Int(qty)), IIf(GF_NumIsNull(rd_group("TAXABLE")) = 0, False, True), BS_UNIT, "A", 1, IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, DISCOUNT_ID), 0, "", G_PRINT_IN_FORMS, item_ID, 0)
                        End While
                        rd_group.Close()
                    End If





                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = NumberFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = NumberFormatStandard(discount_rate)
                        .Cells(8).Value = NumberFormatStandard(Amt)
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = COGS_AMOUNT_ID
                        .Cells(18).Value = ASSET_ACCOUNT_ID
                        .Cells(19).Value = INCOME_ACCOUNT_ID
                        .Cells(20).Value = PRICE_LEVEL_ID
                        .Cells(21).Value = ORG_AMT
                        .Cells(22).Value = item_ID
                        '23 ~ 27

                        .Cells(28).Value = ITEM_TYPE
                        .Cells(29).Value = NON_DISCOUNTED_ITEM
                        .Cells(30).Value = prGROUP_LINE_ID
                        .Cells(31).Value = prBATCH_ID
                        .Cells(32).Value = BATCH_NO
                    End With

                    If ITEM_TYPE = 6 Or ITEM_TYPE = 9 Then
                        'GROUP OR RECEIPT UPDATE
                        i += 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = SqlReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = NumberFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i += 1
                                If (dgv.Rows.Count - 1) < i Then
                                    Exit While
                                End If

                            End While
                        Catch ex As Exception

                        End Try
                    End If

                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try

    End Sub
    Public Sub GS_RowDataItemSalesOrder(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prREF_LINE_ID As String, ByVal prPRICE_LEVEL_ID As String, ByVal prPrintINForm As Boolean, ByVal GROUP_LINE_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim ESTIMATE_LINE_ID As String = prREF_LINE_ID
        Dim RATE_TYPE As String = ""
        Dim ITEM_TYPE As Integer
        Dim PRICE_LEVEL_ID As String = prPRICE_LEVEL_ID
        Dim G_PRINT_IN_FORMS As Boolean = False
        Dim NON_PORFOLIO_COMPUTATION As Boolean = False
        Try

            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION"))
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    G_PRINT_IN_FORMS = CBool(GF_NumIsNull(rd("PRINT_INDIVIDUAL_ITEMS")))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    NON_PORFOLIO_COMPUTATION = CBool(GF_NumIsNull(rd("PRINT_INDIVIDUAL_ITEMS")))
                End If
                rd.Close()

                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL")

                If bNEw = True Then


                    If ITEM_TYPE = 6 And NON_PORFOLIO_COMPUTATION = True Then
                        'CUSTOM BUNDLE
                        .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, NumberFormatStandard(price), discount_type, NumberFormatStandard(discount_rate), 0, tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ESTIMATE_LINE_ID, ORG_AMT, item_ID, PRICE_LEVEL_ID, ITEM_TYPE, prPrintINForm, GROUP_LINE_ID)
                        Dim dgvTop_Index As Integer = dgv.Rows.Count - 1
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        'CUSTOM DATA
                        FrmCustomGroupItem.gsITEM_ID = item_ID
                        FrmCustomGroupItem.ShowDialog()
                        Dim d As DataGridView = FrmCustomGroupItem.dgvSelected
                        Dim gsGROUP_ID As Integer = FrmCustomGroupItem.gsITEM_ID
                        Dim D_TOTAL As Double = 0
                        If d.Rows.Count <> 0 Then

                            For N As Integer = 0 To d.Rows.Count - 1
                                Dim r As DataGridViewRow = d.Rows(N)
                                'ADD ITEM GROUP
                                Dim rd_item As OdbcDataReader = SqlReader($"select * from item where `id` = '{r.Cells("ITEM_ID").Value}' limit 1;")
                                D_TOTAL += GF_NumIsNull(r.Cells("RATE").Value)
                                If rd_item.Read Then

                                    GS_RowDataItemSalesOrder(dgv, True, r.Cells("ITEM_ID").Value, r.Cells("QTY").Value, NumberFormatStandard(r.Cells("RATE").Value), 0, 0, GF_NumIsNull(r.Cells("RATE").Value), GF_NumIsNull(rd_item("TAXABLE")), GF_NumIsNull(rd_item("BASE_UNIT_ID")), "A", 1, "", 0, "", "", G_PRINT_IN_FORMS, item_ID)
                                End If
                                rd_item.Close()

                            Next
                            dgv.Rows(dgvTop_Index).Cells("UNIT_PRICE").Value = NumberFormatStandard(D_TOTAL)
                            dgv.Rows(dgvTop_Index).Cells("AMOUNT").Value = NumberFormatStandard(D_TOTAL)
                        Else
                            dgv.Rows.RemoveAt(dgvTop_Index)

                            MessageBoxInfo("No Item Selected - Transaction canceled.")
                        End If
                        FrmCustomGroupItem.Dispose()
                        FrmCustomGroupItem = Nothing


                    Else

                        .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, NumberFormatStandard(price), discount_type, NumberFormatStandard(discount_rate), NumberFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ESTIMATE_LINE_ID, ORG_AMT, item_ID, PRICE_LEVEL_ID, ITEM_TYPE, prPrintINForm, GROUP_LINE_ID)
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        Dim bGroup As Boolean = True

                        Dim rd_group As OdbcDataReader = SqlReader("SELECT ic.*,s.`TAXABLE` FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                        While rd_group.Read
                            GS_RowDataItemSalesOrder(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), 0, 0, (rd_group("RATE") * Int(qty)), IIf(GF_NumIsNull(rd_group("TAXABLE")) = 0, False, True), 0, "A", 1, "", 0, "", "", G_PRINT_IN_FORMS, item_ID)
                        End While
                        rd.Close()
                    End If




                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = Format(price, "standard")
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = Format(discount_rate, "standard")
                        .Cells(8).Value = Format(Amt, "Standard")
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ESTIMATE_LINE_ID
                        .Cells(18).Value = ORG_AMT
                        .Cells(19).Value = item_ID
                        .Cells(20).Value = PRICE_LEVEL_ID
                        .Cells(21).Value = ITEM_TYPE
                    End With


                    If ITEM_TYPE = 6 Or ITEM_TYPE = 9 Then
                        'GROUP OR RECEIPT UPDATE
                        i += 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = SqlReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = NumberFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i += 1
                                If (dgv.Rows.Count - 1) < i Then
                                    Exit While
                                End If

                            End While
                        Catch ex As Exception

                        End Try
                    End If


                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
    End Sub
    Public Sub GS_RowDataItemEstimate(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prPRICE_LEVEL_ID As String)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim RATE_TYPE As String = ""
        Dim PRICE_LEVEL_ID As String = prPRICE_LEVEL_ID
        Dim ITEM_TYPE As Integer
        ' Dim cn As New MySqlConnection(mysqlConstr)
        Try
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                End If
                rd.Close()
                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, Format(price, "standard"), discount_type, Format(discount_rate, "standard"), Format(Amt, "Standard"), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, PRICE_LEVEL_ID, ITEM_TYPE)

                    Dim bGroup As Boolean = True
                    Dim i_group_amount As Double = 0
                    Dim rd_group As OdbcDataReader = SqlReader("SELECT ic.*,s.`TAXABLE` FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` = '6' and i.ID = '" & item_ID & "' Limit 100 ")
                    While rd_group.Read
                        If bGroup = True Then
                            .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Yellow
                            bGroup = False
                        End If
                        'ADD ITEM GROUP
                        i_group_amount += (rd_group("RATE") * Int(qty))
                        GS_RowDataItemSalesOrder(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), 0, 0, (rd_group("RATE") * Int(qty)), IIf(GF_NumIsNull(rd_group("TAXABLE")) = 0, False, True), 0, "A", 1, "", 0, "", "", False, item_ID)
                    End While
                    rd_group.Close()
                    i_group_amount = 0

                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = Format(price, "standard")
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = Format(discount_rate, "standard")
                        .Cells(8).Value = Format(Amt, "Standard")
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ORG_AMT
                        .Cells(18).Value = item_ID
                        .Cells(19).Value = PRICE_LEVEL_ID
                        .Cells(20).Value = ITEM_TYPE
                    End With
                    Dim sGROUP_ITEM_ACTIVE As Boolean = False

                    If IsGroupItem(ITEM_TYPE, sGROUP_ITEM_ACTIVE) = True Then
                        'EDIT ITEM GROUP


                        Do Until sGROUP_ITEM_ACTIVE = False
                            i += 1
                            With .Rows.Item(i)
                                If .Cells(18).Value = item_ID Then
                                    sGROUP_ITEM_ACTIVE = False
                                    Exit Do
                                End If

                                '   cn.Open()
                                Dim rd_group As OdbcDataReader = SqlReader("select * from item_components where ITEM_ID = '" & item_ID & "' and component_id = '" & .Cells(19).Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                                    .Cells(3).Value = Int(rd_group("QUANTITY") * qty)
                                    .Cells(5).Value = NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    .Cells(8).Value = Format(Int(rd_group("QUANTITY") * qty) * rd_group("RATE"), "Standard")
                                    .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                            End With
                        Loop
                    End If
                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
    End Sub

    Public Sub GS_RowDataItemCreditMemo(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prPRICE_LEVEL_ID As String, ByVal prGROUP_LINE_ID As Integer, ByVal prPrintINForm As Boolean, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim BATCH_NO As String = GF_GetStringFieldValue("item_batches", "id", prBATCH_ID, "batch_no")
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim ITEM_TYPE As Integer
        Dim RATE_TYPE As String = ""
        Dim PRICE_LEVEL_ID As String = ""
        Dim G_PRINT_IN_FORMS As Boolean = False
        Try


            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    G_PRINT_IN_FORMS = CBool(GF_NumIsNull(rd("PRINT_INDIVIDUAL_ITEMS")))
                End If
                rd.Close()

                PRICE_LEVEL_ID = prPRICE_LEVEL_ID
                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, NumberFormatStandard(price), discount_type, IIf(DISCOUNT_ID = "1", Val(discount_rate), NumberFormatStandard(discount_rate)), NumberFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, COGS_AMOUNT_ID, ASSET_ACCOUNT_ID, INCOME_ACCOUNT_ID, PRICE_LEVEL_ID, ORG_AMT, item_ID, prGROUP_LINE_ID, ITEM_TYPE, prPrintINForm, prBATCH_ID, BATCH_NO)

                    If prPrintINForm = True Then
                        .Rows(.Rows.Count - 1).Visible = False
                    End If

                    Dim rd_group As OdbcDataReader = SqlReader("SELECT ic.*,s.`TAXABLE`,i.TYPE,s.BASE_UNIT_ID FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                    While rd_group.Read

                        Dim r_rate As Double = IIf(GF_NumIsNull(rd_group("RATE")) <= Amt, GF_NumIsNull(rd_group("RATE")), Amt)
                        Dim BS_UNIT As String = GF_TextIsNull(rd_group("BASE_UNIT_ID"))

                        GS_RowDataItemCreditMemo(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, discount_type), IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, discount_rate), (r_rate * Int(qty)), IIf(GF_NumIsNull(rd_group("TAXABLE")) = 0, False, True), BS_UNIT, "A", 1, "", 0, "", item_ID, G_PRINT_IN_FORMS, 0)
                    End While

                    rd_group.Close()

                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = NumberFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = NumberFormatStandard(discount_rate)
                        .Cells(8).Value = NumberFormatStandard(Amt)
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = COGS_AMOUNT_ID
                        .Cells(18).Value = ASSET_ACCOUNT_ID
                        .Cells(19).Value = INCOME_ACCOUNT_ID
                        .Cells(20).Value = PRICE_LEVEL_ID
                        .Cells(21).Value = ORG_AMT
                        .Cells(22).Value = item_ID
                        .Cells(23).Value = prGROUP_LINE_ID
                        .Cells(24).Value = ITEM_TYPE
                        .Cells(25).Value = prPrintINForm
                        .Cells(26).Value = prBATCH_ID
                        .Cells(27).Value = BATCH_NO
                    End With


                    If ITEM_TYPE = 6 Or ITEM_TYPE = 9 Then
                        'GROUP OR RECEIPT UPDATE
                        i += 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = SqlReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = NumberFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i += 1
                                If (dgv.Rows.Count - 1) < i Then
                                    Exit While
                                End If

                            End While
                        Catch ex As Exception

                        End Try
                    End If


                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_RemoveItems(ByVal dgv As DataGridView, ByVal Ndex As Integer)
        Try
            If dgv.Rows.Count <> 0 Then
                Dim i As Integer = Ndex
                Dim d As DataGridViewRow = dgv.Rows(i)

                If GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                    MessageBoxInfo("Invalid Delete")
                    Exit Sub
                ElseIf GF_NumIsNull(d.Cells("ITEM_TYPE").Value) = 10 Then
                    MessageBoxInfo("Invalid room delete")
                    Exit Sub
                ElseIf GF_NumIsNull(d.Cells("ITEM_TYPE").Value) = 6 Or GF_NumIsNull(d.Cells("ITEM_TYPE").Value) = 9 Then
                    '===============================================================================================
                    Dim THIS_ITEM_ID As Integer = d.Cells("ITEM_ID").Value
                    If GF_NumIsNull(dgv.Rows(i).Cells(0).Value) <> 0 Then
                        dgv.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgv.Rows(i).Visible = False
                        i += 1
                        For G As Integer = i To dgv.Rows.Count - 1
                            If dgv.Rows(i).Cells("GROUP_LINE_ID").Value = THIS_ITEM_ID Then
                                dgv.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                                dgv.Rows(i).Visible = False
                            End If

                            If i > (dgv.Rows.Count - 1) Then
                                Exit For
                            End If
                        Next
                    Else
                        dgv.Rows.RemoveAt(i)
                        Try
                            While GF_NumIsNull(dgv.Rows(i).Cells("GROUP_LINE_ID").Value) = THIS_ITEM_ID
                                dgv.Rows.RemoveAt(i)
                            End While
                        Catch ex As Exception
                        End Try
                    End If

                    '=========================================================================================
                Else

                    If GF_NumIsNull(dgv.Rows(i).Cells(0).Value) <> 0 Then
                        dgv.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgv.Rows(i).Visible = False
                    Else
                        dgv.Rows.RemoveAt(i)
                    End If

                End If
            End If
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
    End Sub

    Public Sub GS_RowDataItemBillCredit(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prClass_ID As String, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0 'default is zero  only
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim REF_LINE_ID As String = ""
        Dim RATE_TYPE As String = ""
        Dim CLASS_NAME As String = GF_GetStringFieldValue("CLASS", "ID", prClass_ID, "NAME")
        Dim BATCH_NO As String = GF_GetStringFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        Dim ITEM_TYPE As Integer = 0
        ' Dim cn As New MySqlConnection(mysqlConstr)
        Try

            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, NumberFormatStandard(price), discount_type, NumberFormatStandard(discount_rate), NumberFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, CLASS_NAME, prClass_ID, ITEM_TYPE, ASSET_ACCOUNT_ID, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = NumberFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = NumberFormatStandard(discount_rate)
                        .Cells(8).Value = NumberFormatStandard(Amt)
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ORG_AMT
                        .Cells(18).Value = item_ID
                        .Cells(19).Value = CLASS_NAME
                        .Cells(20).Value = prClass_ID
                        .Cells(21).Value = ITEM_TYPE
                        .Cells(22).Value = ASSET_ACCOUNT_ID
                        .Cells(23).Value = prBATCH_ID
                        .Cells(24).Value = BATCH_NO
                    End With

                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_RowDataItemBills(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prClass_ID As String, ByVal prPO_ITEM_ID As String, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0 'default is zero  only
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim REF_LINE_ID As String = ""
        Dim RATE_TYPE As String = ""
        Dim CLASS_NAME As String = GF_GetStringFieldValue("CLASS", "ID", prClass_ID, "NAME")
        Dim BATCH_NO As String = GF_GetStringFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")

        Try
            Dim ITEM_TYPE As Integer = 0

            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                End If
                rd.Close()
                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, NumberFormatStandard(price), discount_type, NumberFormatStandard(discount_rate), NumberFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, CLASS_NAME, prClass_ID, prPO_ITEM_ID, ITEM_TYPE, ASSET_ACCOUNT_ID, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = NumberFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = NumberFormatStandard(discount_rate)
                        .Cells(8).Value = NumberFormatStandard(Amt)
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = ORG_AMT
                        .Cells(18).Value = item_ID
                        .Cells(19).Value = CLASS_NAME
                        .Cells(20).Value = prClass_ID
                        .Cells(21).Value = prPO_ITEM_ID
                        .Cells(22).Value = ITEM_TYPE
                        .Cells(23).Value = ASSET_ACCOUNT_ID
                        .Cells(24).Value = prBATCH_ID
                        .Cells(25).Value = BATCH_NO
                    End With

                End If

            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_RowDataStockTransfer(ByVal dgv As DataGridView, ByVal bAdd As Boolean, ByVal pritem_ID As String, ByVal prQty As Double, ByVal prQty_BASE As Double, ByVal prUnit_ID As Integer, ByVal prUnit_Price As Double, ByVal prTotal_Retail As Double, ByVal prCONTROL_STATUS As String, ByVal prBATCH_ID As Integer)

        Dim BATCH_NO As String = GF_GetStringFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")

        Dim sDESCRIPTION As String = ""
        Dim sUNIT_NAME As String = GF_GetStringFieldValue("UNIT_OF_MEASURE", "ID", prUnit_ID, "NAME")

        Dim sAccount_ID As Integer = 0
        Dim iUnit_Cost As Double = prUnit_Price
        Dim iUnit_Price As Double = 0
        Dim iTotal_Amount As Double = 0
        Dim item_CODE As String = ""

        Try

            '  cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & pritem_ID & "'  limit 1")

            If rd.Read Then
                sAccount_ID = GF_NumIsNull(rd("ASSET_ACCOUNT_ID"))
                item_CODE = GF_TextIsNull(rd("CODE"))
                sDESCRIPTION = GF_TextIsNull(rd("DESCRIPTION"))

                iUnit_Price = GF_NumIsNull(rd("RATE")) ' Rate now

                iTotal_Amount = iUnit_Cost * prQty ' Costing
                prTotal_Retail = iUnit_Price * prQty

                If bAdd = True Then
                    dgv.Rows.Add("N", pritem_ID, item_CODE, sDESCRIPTION, prQty, sUNIT_NAME, prUnit_ID, prQty_BASE, NumberFormatStandard(iUnit_Cost), NumberFormatStandard(iUnit_Price), NumberFormatStandard(iTotal_Amount), NumberFormatStandard(prTotal_Retail), sAccount_ID, prCONTROL_STATUS, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = dgv.CurrentRow.Index
                    With dgv.Rows(i)
                        .Cells(0).Value = .Cells(0).Value
                        .Cells(1).Value = pritem_ID
                        .Cells(2).Value = item_CODE
                        .Cells(3).Value = sDESCRIPTION
                        .Cells(4).Value = prQty
                        .Cells(5).Value = sUNIT_NAME
                        .Cells(6).Value = prUnit_ID
                        .Cells(7).Value = prQty_BASE

                        .Cells(8).Value = NumberFormatStandard(iUnit_Cost)
                        .Cells(9).Value = NumberFormatStandard(iUnit_Price)

                        .Cells(10).Value = NumberFormatStandard(iTotal_Amount)

                        .Cells(11).Value = NumberFormatStandard(prTotal_Retail)
                        .Cells(12).Value = sAccount_ID

                        If Val(.Cells(0).Value) <> 0 Then
                            .Cells(13).Value = prCONTROL_STATUS
                        Else
                            .Cells(13).Value = "A"
                        End If
                        .Cells(14).Value = prBATCH_ID
                        .Cells(15).Value = BATCH_NO
                    End With
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_RowDataStockReceived(ByVal dgv As DataGridView, ByVal bAdd As Boolean, ByVal pritem_ID As String, ByVal prQty As Double, ByVal prQty_BASE As Double, ByVal prUnit_ID As Integer, ByVal prUnit_COST As Double, ByVal prUNIT_RATE As Double, ByVal prCONTROL_STATUS As String, ByVal prBill_Item_ID As String)


        Dim sDESCRIPTION As String = ""
        Dim sUNIT_NAME As String = ""

        Dim sAccount_ID As Integer = 0


        Dim iTotal_Amount As Double = 0
        Dim item_CODE As String = ""
        Dim iTotal_Retails As Double = 0
        Try

            '  cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & pritem_ID & "'  limit 1")

            If rd.Read Then
                sAccount_ID = GF_NumIsNull(rd("ASSET_ACCOUNT_ID"))
                item_CODE = GF_TextIsNull(rd("CODE"))
                sDESCRIPTION = GF_TextIsNull(rd("DESCRIPTION"))
                sUNIT_NAME = GF_GetStringFieldValue("UNIT_OF_MEASURE", "ID", prUnit_ID, "NAME")


                iTotal_Amount = prUnit_COST * prQty ' Costing
                iTotal_Retails = prUNIT_RATE * prQty

                If bAdd = True Then
                    dgv.Rows.Add("N", pritem_ID, item_CODE, sDESCRIPTION, prQty, sUNIT_NAME, prUnit_ID, prQty_BASE, NumberFormatStandard(prUnit_COST), NumberFormatStandard(prUNIT_RATE), NumberFormatStandard(iTotal_Amount), NumberFormatStandard(iTotal_Retails), sAccount_ID, prCONTROL_STATUS, prBill_Item_ID)
                Else
                    Dim i As Integer = dgv.CurrentRow.Index
                    With dgv.Rows(i)
                        .Cells(0).Value = .Cells(0).Value
                        .Cells(1).Value = pritem_ID
                        .Cells(2).Value = item_CODE
                        .Cells(3).Value = sDESCRIPTION
                        .Cells(4).Value = prQty
                        .Cells(5).Value = sUNIT_NAME
                        .Cells(6).Value = prUnit_ID
                        .Cells(7).Value = prQty_BASE

                        .Cells(8).Value = NumberFormatStandard(prUnit_COST)
                        .Cells(9).Value = NumberFormatStandard(prUNIT_RATE)

                        .Cells(10).Value = NumberFormatStandard(iTotal_Amount)

                        .Cells(11).Value = NumberFormatStandard(iTotal_Retails)
                        .Cells(12).Value = sAccount_ID

                        If Val(.Cells(0).Value) <> 0 Then
                            .Cells(13).Value = prCONTROL_STATUS
                        Else
                            .Cells(13).Value = "A"
                        End If
                        .Cells(14).Value = prBill_Item_ID
                    End With
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_RowDataItemInvoice(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prREF_LINE_ID As String, ByVal prPRICE_LEVEL_ID As String, ByVal prGROUP_LINE_ID As Integer, ByVal prPrintINForm As Boolean, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim NON_PORFOLIO_COMPUTATION As Boolean = False
        Dim BATCH_NAME As String = GF_GetStringFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        Dim REF_LINE_ID As String = prREF_LINE_ID
        Dim RATE_TYPE As String = ""
        Dim PRICE_LEVEL_ID As String = prPRICE_LEVEL_ID
        Dim G_PRINT_IN_FORM As Boolean = False
        Dim ITEM_TYPE As Integer
        Try
            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = GF_TextIsNull(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = GF_TextIsNull(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = GF_TextIsNull(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = GF_TextIsNull(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = GF_TextIsNull(rd("CODE"))
                    RATE_TYPE = GF_TextIsNull(rd("RATE_TYPE"))
                    ITEM_TYPE = GF_NumIsNull(rd("TYPE"))
                    G_PRINT_IN_FORM = GF_NumIsNull(rd("PRINT_INDIVIDUAL_ITEMS"))
                    NON_PORFOLIO_COMPUTATION = GF_NumIsNull(rd("NON_PORFOLIO_COMPUTATION"))
                End If
                rd.Close()

                Dim UM_Description As String = GF_GetStringFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

                If bNEw = True Then

                    If ITEM_TYPE = 6 And NON_PORFOLIO_COMPUTATION = True Then
                        'CUSTOM BUNDLE
                        .Rows.Add("N", '0
                              gsITEM_CODE, '1
                              Item_Description,'2
                              NumberFormatFixed(qty),'3
                              UM_Description,'4
                              NumberFormatStandard(price), '5
                              discount_type, '6
                              IIf(DISCOUNT_ID = "1", Val(discount_rate), NumberFormatStandard(discount_rate)), '7
                              NumberFormatStandard(Amt), '8
                              tax, '9
                              Unit_ID, '10
                              constrol_status, '11
                              RATE_TYPE, '12
                              UNIT_QUANTITY_BASE, '13
                              DISCOUNT_ID, '14
                              TAXABLE_AMOUNT, '15
                              TAX_AMOUNT, '16
                              COGS_AMOUNT_ID, '17
                              ASSET_ACCOUNT_ID, '18
                              INCOME_ACCOUNT_ID, '19
                              REF_LINE_ID, '20
                              ORG_AMT, '21
                              item_ID, '22
                              prGROUP_LINE_ID, '23
                              PRICE_LEVEL_ID, '24
                              ITEM_TYPE, '25
                              prPrintINForm,
                              prBATCH_ID,
                              BATCH_NAME) ' 26

                        Dim dgvTop_Index As Integer = dgv.Rows.Count - 1
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        'CUSTOM DATA
                        FrmCustomGroupItem.gsITEM_ID = item_ID
                        FrmCustomGroupItem.ShowDialog()
                        Dim d As DataGridView = FrmCustomGroupItem.dgvSelected
                        Dim gsGROUP_ID As Integer = FrmCustomGroupItem.gsITEM_ID
                        Dim D_TOTAL As Double = 0
                        If d.Rows.Count <> 0 Then

                            For N As Integer = 0 To d.Rows.Count - 1
                                Dim r As DataGridViewRow = d.Rows(N)

                                Dim rd_item As OdbcDataReader = SqlReader($"select * from item where `id` = '{r.Cells("ITEM_ID").Value}' limit 1;")
                                D_TOTAL += GF_NumIsNull(r.Cells("RATE").Value)
                                If rd_item.Read Then
                                    GS_RowDataItemInvoice(dgv, True, r.Cells("ITEM_ID").Value, r.Cells("QTY").Value, (r.Cells("RATE").Value / r.Cells("QTY").Value), 0, 0, r.Cells("RATE").Value, rd_item("TAXABLE"), GF_NumIsNull(rd_item("BASE_UNIT_ID")), "A", 1, "", 0, "", "", item_ID, G_PRINT_IN_FORM, 0)
                                End If
                                rd_item.Close()

                            Next
                            dgv.Rows(dgvTop_Index).Cells("UNIT_PRICE").Value = NumberFormatStandard(D_TOTAL)
                            dgv.Rows(dgvTop_Index).Cells("AMOUNT").Value = NumberFormatStandard(D_TOTAL)
                        Else
                            dgv.Rows.RemoveAt(dgvTop_Index)

                            MessageBoxInfo("No Item Selected - Transaction canceled.")
                        End If
                        FrmCustomGroupItem.Dispose()
                        FrmCustomGroupItem = Nothing


                    Else


                        .Rows.Add("N", '0
                              gsITEM_CODE, '1
                              Item_Description,'2
                              NumberFormatFixed(qty),'3
                              UM_Description,'4
                              NumberFormatStandard(price), '5
                              discount_type, '6
                              IIf(DISCOUNT_ID = "1", Val(discount_rate), NumberFormatStandard(discount_rate)), '7
                              NumberFormatStandard(Amt), '8
                              tax, '9
                              Unit_ID, '10
                              constrol_status, '11
                              RATE_TYPE, '12
                              UNIT_QUANTITY_BASE, '13
                              DISCOUNT_ID, '14
                              TAXABLE_AMOUNT, '15
                              TAX_AMOUNT, '16
                              COGS_AMOUNT_ID, '17
                              ASSET_ACCOUNT_ID, '18
                              INCOME_ACCOUNT_ID, '19
                              REF_LINE_ID, '20
                              ORG_AMT, '21
                              item_ID, '22
                              prGROUP_LINE_ID, '23
                              PRICE_LEVEL_ID, '24
                              ITEM_TYPE, '25
                              prPrintINForm, '26
                              prBATCH_ID, '27
                              BATCH_NAME) ' 28

                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        Dim bGroup As Boolean = True
                        Dim rd_group As OdbcDataReader = SqlReader("SELECT ic.*,s.`TAXABLE`,i.TYPE,s.BASE_UNIT_ID FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                        While rd_group.Read

                            Dim r_rate As Double = IIf(GF_NumIsNull(rd_group("RATE")) <= Amt, GF_NumIsNull(rd_group("RATE")), Amt)
                            Dim BS_UNIT As String = GF_TextIsNull(rd_group("BASE_UNIT_ID"))

                            GS_RowDataItemInvoice(dgv, True, rd_group("COMPONENT_ID"), GF_NumIsNull(rd_group("QUANTITY")) * qty, NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, discount_type), IIf(GF_NumIsNull(rd_group("RATE")) = 0, 0, discount_rate), (r_rate * Int(qty)), IIf(GF_NumIsNull(rd_group("TAXABLE")) = 0, False, True), BS_UNIT, "A", 1, "", 0, "", "", item_ID, G_PRINT_IN_FORM, 0)

                        End While
                        rd_group.Close()
                    End If
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = qty
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = NumberFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = IIf(DISCOUNT_ID = "1", Val(discount_rate), NumberFormatStandard(discount_rate))
                        .Cells(8).Value = NumberFormatStandard(Amt)
                        .Cells(9).Value = tax
                        .Cells(10).Value = Unit_ID
                        .Cells(11).Value = IIf(ID_is_number = True, constrol_status, "A")
                        .Cells(12).Value = RATE_TYPE
                        .Cells(13).Value = UNIT_QUANTITY_BASE
                        .Cells(14).Value = DISCOUNT_ID
                        .Cells(15).Value = TAXABLE_AMOUNT
                        .Cells(16).Value = TAX_AMOUNT
                        .Cells(17).Value = COGS_AMOUNT_ID
                        .Cells(18).Value = ASSET_ACCOUNT_ID
                        .Cells(19).Value = INCOME_ACCOUNT_ID
                        .Cells(20).Value = REF_LINE_ID
                        .Cells(21).Value = ORG_AMT
                        .Cells(22).Value = item_ID
                        ' .Cells(23).Value = 0 // not recomended to change
                        .Cells(24).Value = PRICE_LEVEL_ID
                        .Cells(25).Value = ITEM_TYPE
                        .Cells(26).Value = prPrintINForm
                        .Cells(27).Value = prBATCH_ID
                        .Cells(28).Value = BATCH_NAME
                    End With

                    If ITEM_TYPE = 6 Or ITEM_TYPE = 9 Then
                        'GROUP OR RECEIPT UPDATE
                        i += 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = SqlReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = NumberFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = NumberFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i += 1
                                If (dgv.Rows.Count - 1) < i Then
                                    Exit While
                                End If

                            End While
                        Catch ex As Exception

                        End Try
                    End If


                End If
            End With

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try

    End Sub
    Public Sub GS_ContactUpdate(ByVal dgv As DataGridView, ByVal gsNew As Boolean, ByVal BS As BindingSource, ByVal sQuery As String)

        Try
            Dim rd As OdbcDataReader = SqlReader(sQuery)

            If rd.Read Then

                If gsNew = True Then

                    Dim dt As New DataTable
                    dt = CType(BS.DataSource, DataTable)
                    Dim drToAdd As DataRow = dt.NewRow()

                    'dgv.Rows.Add()
                    For i As Integer = 0 To rd.FieldCount - 1
                        If IsDBNull(rd(i)) = True Then
                            '
                            drToAdd(i) = System.DBNull.Value
                            'do nothing
                        ElseIf IsNumeric(rd(i)) = False Or rd.GetName(i) = "Account Number" Then
                            drToAdd(i) = GF_TextIsNull(rd(i))

                        Else
                            If Int(rd(i)) = True Then
                                drToAdd(i) = GF_NumIsNull(rd(i))
                            Else
                                drToAdd(i) = rd(i)
                            End If


                        End If

                    Next
                    dt.Rows.Add(drToAdd)
                    dt.AcceptChanges()
                    BS.Position = dgv.Rows.Count + 1
                Else

                    For i As Integer = 0 To rd.FieldCount - 1

                        If IsDBNull(rd(i)) = True Then
                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = System.DBNull.Value
                            'do nothing
                        ElseIf IsNumeric(rd(i)) = False Or rd.GetName(i) = "Account Number" Then
                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = GF_TextIsNull(rd(i))
                        Else
                            If Int(rd(i)) = True Then
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = GF_NumIsNull(rd(i))
                            Else
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = rd(i)
                            End If


                        End If
                    Next
                    BS.Position = dgv.CurrentRow.Index
                End If

            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub GS_ItemPerUpdate(ByVal dgv As DataGridView, ByVal gsID As String, ByVal gsNew As Boolean, ByVal BS As BindingSource, ByVal M As Boolean)
        Dim xSQL As String

        If M = True Then
            xSQL = "SELECT 
  i.ID,
  i.CODE AS `Code`,
  i.`DESCRIPTION` AS `Description`,
  i.`PURCHASE_DESCRIPTION` AS `Purchase Description`,
  itm.`DESCRIPTION` AS `Type`,
  ig.`DESCRIPTION` AS `Group`,
  ic.`DESCRIPTION` AS `Class`,
  isc.`DESCRIPTION` AS `Sub Class`,
  stm.`DESCRIPTION` AS `Stock Type`,
  ctt.`NAME` AS `Vendor`,
  m.`NAME` as `Manufacturer`,
  Format(i.Cost,2) as `Cost`,
 Format(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) as `Rate`,
   uom.`Name` as `Unit Of Measurement`, 
a_GL.`NAME` AS `G/L Account`,
  a_COGS.`NAME` AS `COGS Account`,
  a_asset.`NAME` AS `Asset Account`,
  if(i.`TAXABLE`=0,'No','Yes') AS `Tax`,
  if(i.`INACTIVE`='0','No','Yes') AS `Inactive`  
                FROM
                  item AS i 
                  LEFT OUTER JOIN item_type_map AS itm 
                    ON i.`TYPE` = itm.`ID` 
                  LEFT OUTER JOIN item_group AS ig 
                    ON ig.`ID` = i.`GROUP_ID` 
                  LEFT OUTER JOIN item_sub_class AS isc 
                    ON isc.`ID` = i.`SUB_CLASS_ID` 
                  LEFT OUTER JOIN item_class AS ic 
                    ON isc.`CLASS_ID` = ic.`ID` 
                  LEFT OUTER JOIN stock_type_map AS stm 
                    ON stm.`ID` = i.`STOCK_TYPE` 
                  LEFT OUTER JOIN contact AS ctt 
                    ON ctt.`ID` = i.`PREFERRED_VENDOR_ID` 
                  LEFT OUTER JOIN manufacturer AS m 
                    ON m.`ID` = i.`MANUFACTURER_ID` 
                  LEFT OUTER JOIN  account AS a_GL
                   ON a_GL.id = i.`GL_ACCOUNT_ID`
                     LEFT OUTER JOIN  account AS a_COGS
                   ON a_COGS.id = i.`COGS_ACCOUNT_ID`
                  LEFT OUTER JOIN  account AS a_ASSET
                   ON a_ASSET.id = i.`ASSET_ACCOUNT_ID` 
                LEFT OUTER JOIN `unit_of_measure` as uom 
                ON uom.`ID` = i.`BASE_UNIT_ID`
                     WHERE i.ID = '" & gsID & "' LIMIT 1"
        Else
            Dim dt As Date = Now.Date.Date
            Dim sLocation_ID As Integer = gsDefault_LOCATION_ID

            Dim sON_HAND As String = " format((((IFNULL((SELECT SUM(IFNULL(bi.`QUANTITY`, 0) * IFNULL(bi.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM BILL_ITEMS AS bi INNER JOIN BILL AS b ON bi.`BILL_ID` = b.`ID` WHERE bi.`ITEM_ID` = i.`ID` AND b.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND b.location_ID LIKE '%" & sLocation_ID & "%'),0)+
   IFNULL((SELECT SUM(IFNULL(cmi.`QUANTITY`, 0) * IFNULL(cmi.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM credit_memo_ITEMS AS cmi INNER JOIN credit_memo AS cm ON cmi.`credit_memo_ID` = cm.`ID` WHERE  cmi.`ITEM_ID` = i.`ID` AND cm.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND cm.location_ID LIKE '%" & sLocation_ID & "%' ),0) +
   IFNULL((SELECT SUM(IFNULL(baa.`QUANTITY`, 0) * IFNULL(baa.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM BUILD_ASSEMBLY AS baa  WHERE baa.`ASSEMBLY_ITEM_ID` = i.`ID` AND baa.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND baa.location_ID LIKE '%" & sLocation_ID & "%'),0) +
   IFNULL((SELECT SUM(IFNULL(sti.`QUANTITY`, 0) * IFNULL(sti.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM  stock_transfer_items AS sti INNER JOIN stock_transfer AS st ON sti.`stock_transfer_ID` = st.`ID` WHERE sti.`ITEM_ID` = i.`ID` AND st.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND st.TRANSFER_TO_ID LIKE '%" & sLocation_ID & "%' ),0)+
   IFNULL((SELECT SUM(IFNULL(iai.`QTY_DIFFERENCE`, 0) * IFNULL(iai.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM  inventory_adjustment_items AS iai INNER JOIN inventory_adjustment AS ia ON iai.`inventory_adjustment_ID` = ia.`ID` WHERE iai.`ITEM_ID` = i.`ID` AND ia.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND ia.location_ID LIKE '%" & sLocation_ID & "%' ),0)+
   IFNULL((SELECT SUM(IFNULL(ci.`QUANTITY`, 0) * IFNULL(ci.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM CHECK_ITEMS AS ci INNER JOIN `CHECK` AS c ON ci.`CHECK_ID` = c.`ID` WHERE ci.`ITEM_ID` = i.`ID` AND c.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND c.location_ID LIKE '%" & sLocation_ID & "%'),0)) ) 
    -
  (
  IFNULL((SELECT SUM(IFNULL(iix.`QUANTITY`, 0) * IFNULL(iix.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM invoice_items AS iix INNER JOIN invoice AS ix ON iix.`INVOICE_ID` = ix.`ID` WHERE iix.`ITEM_ID` = i.`ID` AND ix.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND ix.location_ID LIKE '%" & sLocation_ID & "%'),0)  +
  IFNULL((SELECT SUM(IFNULL(bai.`QUANTITY`, 0) * 1) AS `QTY` FROM BUILD_ASSEMBLY_ITEMS AS bai  INNER JOIN BUILD_ASSEMBLY AS ba ON bai.BUILD_ASSEMBLY_ID = ba.`ID`  WHERE bai.`ITEM_ID` = i.`ID` AND ba.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND ba.location_ID LIKE '%" & sLocation_ID & "%'),0) +
   IFNULL((SELECT SUM(IFNULL(sri.`QUANTITY`, 0) * IFNULL(sri.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM sales_receipt_items AS sri INNER JOIN sales_receipt AS sr ON sri.`sales_receipt_ID` = sr.`ID` WHERE sri.`ITEM_ID` = i.`ID` AND sr.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND sr.location_ID LIKE '%" & sLocation_ID & "%'),0) +
   IFNULL((SELECT SUM(IFNULL(bci.`QUANTITY`, 0) * IFNULL(bci.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM  bill_credit_items AS bci INNER JOIN bill_credit AS bc ON bci.`bill_credit_ID` = bc.`ID` WHERE bci.`ITEM_ID` = i.`ID` AND bc.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND bc.location_ID LIKE '%" & sLocation_ID & "%'),0) +
   IFNULL((SELECT SUM(IFNULL(stii.`QUANTITY`, 0) * IFNULL(stii.`UNIT_BASE_QUANTITY`, 1)) AS `QTY` FROM  stock_transfer_items AS stii INNER JOIN stock_transfer AS sti ON stii.`stock_transfer_ID` = sti.`ID` WHERE stii.`ITEM_ID` = i.`ID` AND sti.`DATE` <= '" & Format(dt, "yyyy-MM-dd") & "' AND sti.LOCATION_ID LIKE '%" & sLocation_ID & "%' ),0)) 
  ),2)
   AS `On Hand`"

            xSQL = "SELECT 
  i.ID,
  i.CODE AS `Code`,
  i.`DESCRIPTION` AS `Description`,
  i.`PURCHASE_DESCRIPTION` AS `Purchase Description`,
  itm.`DESCRIPTION` AS `Type`,
  ig.`DESCRIPTION` AS `Group`,
  ic.`DESCRIPTION` AS `Class`,
  isc.`DESCRIPTION` AS `Sub Class`,
  stm.`DESCRIPTION` AS `Stock Type`,
  ctt.`NAME` AS `Vendor`,
  m.`NAME` as `Manufacturer`,
" & sON_HAND & ",
  Format(i.Cost,2) as `Cost`,
  Format(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) as `Rate`,
   uom.`Name` as `Unit Of Measurement`,  
a_GL.`NAME` AS `G/L Account`,
  a_COGS.`NAME` AS `COGS Account`,
  a_asset.`NAME` AS `Asset Account`,
  if(i.`TAXABLE`=0,'No','Yes') AS `Tax`,
  if(i.`INACTIVE`='0','No','Yes') AS `Inactive` 
FROM
  item AS i 
  LEFT OUTER JOIN item_type_map AS itm 
    ON i.`TYPE` = itm.`ID` 
  LEFT OUTER JOIN item_group AS ig 
    ON ig.`ID` = i.`GROUP_ID` 
  LEFT OUTER JOIN item_sub_class AS isc 
    ON isc.`ID` = i.`SUB_CLASS_ID` 
  LEFT OUTER JOIN item_class AS ic 
    ON isc.`CLASS_ID` = ic.`ID` 
  LEFT OUTER JOIN stock_type_map AS stm 
    ON stm.`ID` = i.`STOCK_TYPE` 
  LEFT OUTER JOIN contact AS ctt 
    ON ctt.`ID` = i.`PREFERRED_VENDOR_ID` 
  LEFT OUTER JOIN manufacturer AS m 
    ON m.`ID` = i.`MANUFACTURER_ID` 
  LEFT OUTER JOIN  account AS a_GL
   ON a_GL.id = i.`GL_ACCOUNT_ID`
     LEFT OUTER JOIN  account AS a_COGS
   ON a_COGS.id = i.`COGS_ACCOUNT_ID`
  LEFT OUTER JOIN  account AS a_ASSET
   ON a_ASSET.id = i.`ASSET_ACCOUNT_ID` 
LEFT OUTER JOIN `unit_of_measure` as uom 
ON uom.`ID` = i.`BASE_UNIT_ID`
where i.inactive = '0'  and i.ID = '" & gsID & "' Limit 1;"

        End If

        Try

            Dim rd As OdbcDataReader = SqlReader(xSQL)
            If rd.Read Then

                If gsNew = True Then

                    Dim dt As New DataTable
                    dt = CType(BS.DataSource, DataTable)
                    Dim drToAdd As DataRow = dt.NewRow()

                    'dgv.Rows.Add()
                    For i As Integer = 0 To rd.FieldCount - 1
                        If IsDBNull(rd(i)) = True Then
                            '
                            drToAdd(i) = System.DBNull.Value
                        ElseIf IsNumeric(rd(i)) = True Then

                            If Int(rd(i)) = True Then
                                drToAdd(i) = GF_NumIsNull(rd(i))
                            Else
                                drToAdd(i) = rd(i)
                            End If

                        Else

                            drToAdd(i) = GF_TextIsNull(rd(i))
                        End If

                    Next
                    dt.Rows.Add(drToAdd)
                    dt.AcceptChanges()
                    BS.Position = dgv.Rows.Count - 1
                Else

                    For i As Integer = 0 To rd.FieldCount - 1

                        If IsDBNull(rd(i)) = True Then
                            '
                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = System.DBNull.Value
                        ElseIf IsNumeric(rd(i)) = True Then

                            If Int(rd(i)) = True Then
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = GF_NumIsNull(rd(i))
                            Else
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = rd(i)
                            End If


                        Else

                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = GF_TextIsNull(rd(i))
                        End If
                    Next
                    BS.Position = dgv.CurrentRow.Index
                End If

            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Private Function IsDiscountNext(ByVal dgv As DataGridView, ByVal ndex As Integer) As Boolean
        Try
            If IsDiscountItem(dgv.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub GS_PurchaseVendorComputation(ByVal dgv As DataGridView, ByVal cmbINPUT_TAX_ID As ComboBox, ByVal lblINPUT_TAX_AMOUNT As Label, ByVal lblAMOUNT As Label, ByVal lblTAXABLE_AMOUNT As Label, ByVal lblNONTAXABLE_AMOUNT As Label, ByVal lblINPUT_TAX_RATE As Label)
        Dim dINput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim n As Integer = 0
        Dim dVat As Double = 0

        Try

            Dim iSUB_Total As Double = 0
            Dim iSUB_TAX As Double = 0
            Dim iSUB_NON_TAX As Double = 0
            For i As Integer = 0 To dgv.Rows.Count - 1
                If dgv.Rows(i).Cells("CONTROL_STATUS").Value <> "D" Then

                    If dgv.Rows(i).Cells("ITEM_TYPE").Value = 5 Then

                    ElseIf dgv.Rows(i).Cells("ITEM_TYPE").Value = 6 Then
                        'Do nothing
                        dgv.Rows(i).DefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                    Else
                        Select Case dgv.Rows(i).Cells("ITEM_TYPE").Value
                            Case 4
                                dgv.Rows(i).DefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold + FontStyle.Italic)
                            Case 7
                                dgv.Rows(i).DefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold + FontStyle.Italic)
                        End Select
                        dTotal_amount += NumberFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        If dgv.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax += NumberFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax += NumberFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                n += 1
            Next
            dTotal_amount = iSUB_Total + dTotal_amount
            dTax = iSUB_TAX + dTax
            dNon_Tax = iSUB_NON_TAX + dNon_Tax
            Dim total As Double
            If GF_TextIsNull(cmbINPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = GS_Tax_Rate_Find(GF_NumIsNull(cmbINPUT_TAX_ID.SelectedValue))
                dINput_value = (dVat / 100) * dTax
                total = dINput_value + dTax

                If cmbINPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dINput_value = t * dINput_value
                    dTax -= dINput_value
                    total = dINput_value + dTax
                End If
                total += dNon_Tax
                lblINPUT_TAX_AMOUNT.Text = NumberFormatStandard(dINput_value)
                lblAMOUNT.Text = NumberFormatStandard(total)


                lblTAXABLE_AMOUNT.Text = NumberFormatStandard(dTax)
                lblNONTAXABLE_AMOUNT.Text = NumberFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblINPUT_TAX_AMOUNT.Text = NumberFormatStandard(dINput_value)
                lblAMOUNT.Text = NumberFormatStandard(total)

                lblTAXABLE_AMOUNT.Text = NumberFormatStandard(0)
                lblNONTAXABLE_AMOUNT.Text = NumberFormatStandard(total)
            End If

            lblINPUT_TAX_RATE.Text = dVat


        Catch ex As Exception

        End Try

    End Sub
    Public Sub GS_BillVendorComputation(ByVal dgvItem As DataGridView, ByVal dgvExpenses As DataGridView, ByVal cmbINPUT_TAX_ID As ComboBox, ByVal lblINPUT_TAX_AMOUNT As Label, ByVal lblAMOUNT As Label, ByVal lblINPUT_TAX_RATE As Label, ByVal lbsTotal_Amount_Item As ToolStripLabel, ByVal lbsTotal_Amount_Expense As ToolStripLabel)
        Dim dINput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTotal_item As Double = 0
        Dim dTotal_Expenses As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim dVat As Double = 0




        Try

            '======================================================== ITEMS
            For i As Integer = 0 To dgvItem.Rows.Count - 1
                If dgvItem.Rows(i).Cells("CONTROL_STATUS").Value <> "D" Then

                    If dgvItem.Rows(i).Cells("ITEM_TYPE").Value = 5 Then

                    ElseIf dgvItem.Rows(i).Cells("ITEM_TYPE").Value = 6 Then
                        'Do nothing
                        dgvItem.Rows(i).DefaultCellStyle.Font = New Font(dgvItem.Font, FontStyle.Bold)
                    Else
                        Select Case dgvItem.Rows(i).Cells("ITEM_TYPE").Value
                            Case 4
                                dgvItem.Rows(i).DefaultCellStyle.Font = New Font(dgvItem.Font, FontStyle.Bold + FontStyle.Italic)
                            Case 7
                                dgvItem.Rows(i).DefaultCellStyle.Font = New Font(dgvItem.Font, FontStyle.Bold + FontStyle.Italic)
                        End Select
                        dTotal_item += NumberFormatFixed(dgvItem.Rows(i).Cells("AMOUNT").Value)

                        If dgvItem.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax += NumberFormatFixed(dgvItem.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax += NumberFormatFixed(dgvItem.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                '  n = n + 1
            Next

            dTotal_amount += dTotal_item
            '============================================================= END ITEMS

            '============================================================== EXPENSE
            For i As Integer = 0 To dgvExpenses.Rows.Count - 1
                If dgvExpenses.Rows(i).Cells("CONTROL_STATUS").Value <> "D" Then
                    dTotal_Expenses += NumberFormatFixed(dgvExpenses.Rows(i).Cells("AMOUNT").Value)
                    If GF_NumIsNull(dgvExpenses.Rows(i).Cells("Tax").Value) = 0 Then
                        dNon_Tax += NumberFormatFixed(dgvExpenses.Rows(i).Cells("AMOUNT").Value)
                    Else
                        dTax += NumberFormatFixed(dgvExpenses.Rows(i).Cells("AMOUNT").Value)
                    End If
                End If
            Next
            dTotal_amount += dTotal_Expenses
            '============================================================== END  EXPENSE

            lbsTotal_Amount_Item.Text = NumberFormatStandard(dTotal_item)
            lbsTotal_Amount_Expense.Text = NumberFormatStandard(dTotal_Expenses)



            Dim total As Double
            If GF_TextIsNull(cmbINPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = GS_Tax_Rate_Find(GF_NumIsNull(cmbINPUT_TAX_ID.SelectedValue))
                dINput_value = (dVat / 100) * dTax
                total = dINput_value + dTax

                If cmbINPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dINput_value = t * dINput_value
                    dTax -= dINput_value
                    total = dINput_value + dTax
                End If
                total += dNon_Tax
                lblINPUT_TAX_AMOUNT.Text = NumberFormatStandard(dINput_value)
                lblAMOUNT.Text = NumberFormatStandard(total)


                'lblTAXABLE_AMOUNT.Text = NumberFormatStandard(dTax)
                'lblNONTAXABLE_AMOUNT.Text = NumberFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblINPUT_TAX_AMOUNT.Text = NumberFormatStandard(dINput_value)
                lblAMOUNT.Text = NumberFormatStandard(total)

                'lblTAXABLE_AMOUNT.Text = NumberFormatStandard(0)
                'lblNONTAXABLE_AMOUNT.Text = NumberFormatStandard(total)
            End If

            lblINPUT_TAX_RATE.Text = dVat

        Catch ex As Exception

        End Try

    End Sub
    Public Sub GS_SalesCustomerComputation(ByVal dgv As DataGridView, ByVal cmbOUTPUT_TAX_ID As ComboBox, ByVal lblOUTPUT_TAX_AMOUNT As Label, ByVal lblAMOUNT As Label, ByVal lblTAXABLE_AMOUNT As Label, ByVal lblNONTAXABLE_AMOUNT As Label, ByVal lblOUTPUT_TAX_RATE As Label, ByRef SubTotal As Double)
        Dim dOutput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim n As Integer = 0
        Dim dVat As Double = 0

        Try


            Dim iSUB_NON_TAX As Double = 0
            For i As Integer = 0 To dgv.Rows.Count - 1
                If dgv.Rows(i).Cells("CONTROL_STATUS").Value <> "D" Then

                    If dgv.Rows(i).Cells("ITEM_TYPE").Value = 5 Then

                    ElseIf dgv.Rows(i).Cells("ITEM_TYPE").Value = 6 Then
                        'Do nothing
                        dgv.Rows(i).DefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold)
                    Else
                        Select Case dgv.Rows(i).Cells("ITEM_TYPE").Value
                            Case 4
                                dgv.Rows(i).DefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold + FontStyle.Italic)
                            Case 7
                                dgv.Rows(i).DefaultCellStyle.Font = New Font(dgv.Font, FontStyle.Bold + FontStyle.Italic)
                        End Select
                        dTotal_amount += NumberFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        If dgv.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax += NumberFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax += NumberFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                n += 1
            Next

            SubTotal = dTotal_amount

            dNon_Tax = iSUB_NON_TAX + dNon_Tax

            Dim total As Double
            If GF_TextIsNull(cmbOUTPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = GS_Tax_Rate_Find(GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue))
                dOutput_value = (dVat / 100) * dTax
                total = dOutput_value + dTax

                If cmbOUTPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dOutput_value = t * dOutput_value
                    dTax -= dOutput_value
                    total = dOutput_value + dTax
                End If
                total += dNon_Tax
                lblOUTPUT_TAX_AMOUNT.Text = NumberFormatStandard(dOutput_value)
                lblAMOUNT.Text = NumberFormatStandard(total)


                lblTAXABLE_AMOUNT.Text = NumberFormatStandard(dTax)
                lblNONTAXABLE_AMOUNT.Text = NumberFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblOUTPUT_TAX_AMOUNT.Text = NumberFormatStandard(dOutput_value)
                lblAMOUNT.Text = NumberFormatStandard(total)

                lblTAXABLE_AMOUNT.Text = NumberFormatStandard(0)
                lblNONTAXABLE_AMOUNT.Text = NumberFormatStandard(total)
            End If

            lblOUTPUT_TAX_RATE.Text = dVat


        Catch ex As Exception

        End Try
    End Sub
    Public Function GS_DiscountOtherCharge(ByVal SubTotal As Double, ByVal ItemType As Integer, ByVal gsRate_Type As Integer, ByVal Unit_Value As Double)
        Dim ReturnValue As Double = 0
        Dim LineNo As Double

        Select Case ItemType
            Case 4
                'OTHER CHRGE
                If gsRate_Type = 0 Then
                    ReturnValue = NumberFormatFixed(Unit_Value)
                Else
                    LineNo = SubTotal * (Unit_Value / 100)
                    ReturnValue = NumberFormatFixed(LineNo)
                End If

            Case 7
                'DISCOUNT
                If gsRate_Type = 0 Then
                    ReturnValue = NumberFormatFixed(Unit_Value) * -1
                Else
                    LineNo = SubTotal * (Unit_Value / 100)
                    ReturnValue = NumberFormatFixed(LineNo) * -1
                End If
        End Select

        Return ReturnValue
    End Function
End Module
