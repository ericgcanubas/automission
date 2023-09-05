Imports System.Data.Odbc
Module modAddItem

    Public Sub fGetExpiration(ByVal BATCH_ID As Integer, ByVal ITEM_ID As Integer, ByRef Expired_Date As Date, ByRef IsExpired As Boolean)
        Dim rd As OdbcDataReader = fReader($"select EXPIRY_DATE from item_batches where ID = '{BATCH_ID}' and ITEM_ID ='{ITEM_ID}' limit 1")
        If rd.Read Then
            IsExpired = True
            Expired_Date = CDate(fTextisNULL(rd("EXPIRY_DATE")))
        Else
            IsExpired = False
        End If
        rd.Close()
    End Sub
    Public Function fSetExpiration(ByVal ITEM_ID As Integer, ByVal dtpDate As DateTimePicker) As Integer
        Dim BATCH_ID As Integer
        If dtpDate.Visible = False Or dtpDate.Checked = False Then

            BATCH_ID = 0
        Else

            Dim rd As OdbcDataReader = fReader($"select ID from item_batches where ITEM_ID ='{ITEM_ID}' and EXPIRY_DATE = '{ fDateFormatMYSQL(dtpDate.Value)}' limit 1")
            If rd.Read Then
                BATCH_ID = fNumisNULL(rd("ID"))

            Else
                BATCH_ID = fGetNewItemBatch(ITEM_ID, dtpDate.Value)
            End If
            rd.Close()
        End If

        Return BATCH_ID
    End Function
    Private Function fGetNewItemBatch(ByVal ITEM_ID As Integer, ByVal DT As Date) As Integer
        Dim ThisID As Integer = fObjectTypeMap_ID("item_batches")
        Dim BATCH_NO As String = Format(Val(fGetMaxField_LINE("BATCH_NO", "item_batches", "ITEM_ID", ITEM_ID)), "000000")
        fExecutedOnly($"INSERT INTO item_batches SET ID = '{ThisID}',ITEM_ID='{ITEM_ID}',BATCH_NO='{BATCH_NO}',EXPIRY_DATE='{fDateFormatMYSQL(DT)}'")
        fPop_Up_Msg("Item batch expiration", "New batch entry save.", True)

        Return ThisID
    End Function
    Public Function fInventoryAdjustmentGotLatestEntry(ByVal prItem_ID As Integer, ByVal DateTarget As Date, ByVal Location_ID As Integer)
        Dim IsExist As Boolean = False
        Dim SQL As String = $"SELECT * FROM inventory_adjustment  AS i INNER JOIN inventory_adjustment_items AS a ON a.`INVENTORY_ADJUSTMENT_ID` = i.`ID`  WHERE a.`ITEM_ID` = '{prItem_ID}' AND i.`DATE` >= '{fDateFormatMYSQL(DateTarget)}' AND i.`LOCATION_ID` = '{Location_ID}'  limit 1"

        Dim rd As OdbcDataReader = fReader(SQL)
        If rd.Read Then
            IsExist = True
        End If
        rd.Close()
        Return IsExist
    End Function
    Public Sub fTax_Value(ByVal dvg As DataGridView)
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
    Public Sub fClosed_Value(ByVal dvg As DataGridView)
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
    Public Sub fRow_Data_Item_Write_Check(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prClass_ID As String, ByVal prBATCH_ID As Integer)
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
        Dim CLASS_NAME As String = fGetFieldValue("CLASS", "ID", prClass_ID, "NAME")
        Dim BATCH_NO As String = fGetFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        '  Dim cn As New MySqlConnection(mysqlConstr)
        Try

            ' cn.Open()
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then


                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, fNumFormatStandard(price), discount_type, fNumFormatStandard(discount_rate), fNumFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, CLASS_NAME, prClass_ID, ITEM_TYPE, ASSET_ACCOUNT_ID, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = fNumFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = fNumFormatStandard(discount_rate)
                        .Cells(8).Value = fNumFormatStandard(Amt)
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fRow_Data_Item_Purchase_Order(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal PR_ID As Integer)
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
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try

    End Sub

    Public Sub fRow_Data_Item_Purchase_Request(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double)
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
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If


        End Try

    End Sub
    Public Sub fRow_Data_Item_Sales_Receipt(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prPRICE_LEVEL_ID As String, ByVal prPrintINForm As Boolean, ByVal prGROUP_LINE_ID As Integer, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim BATCH_NO As String = fGetFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
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
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then

                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    NON_DISCOUNTED_ITEM = fNumisNULL(rd("NON_DISCOUNTED_ITEM"))
                    G_PRINT_IN_FORMS = CBool(fNumisNULL(rd("PRINT_INDIVIDUAL_ITEMS")))
                    NON_PORFOLIO_COMPUTATION = CBool(fNumisNULL(rd("NON_PORFOLIO_COMPUTATION")))
                End If
                rd.Close()

                Dim POS_TRX_TYPE As Integer = 0
                Dim POS_EDIT_QTY As Integer = 0
                Dim POS_NOTES As String = ""


                Dim DEPOSITED As Integer = 0


                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

                If bNEw = True Then


                    If ITEM_TYPE = 6 And NON_PORFOLIO_COMPUTATION = True Then
                        'CUSTOM BUNDLE
                        .Rows.Add("N", gsITEM_CODE, Item_Description, qty, UM_Description, 0, discount_type, IIf(DISCOUNT_ID = "1", Val(discount_rate), fNumFormatStandard(discount_rate)), 0, tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, COGS_AMOUNT_ID, ASSET_ACCOUNT_ID, INCOME_ACCOUNT_ID, PRICE_LEVEL_ID, ORG_AMT, item_ID, POS_TRX_TYPE, POS_EDIT_QTY, POS_NOTES, prPrintINForm, DEPOSITED, ITEM_TYPE, NON_DISCOUNTED_ITEM, prGROUP_LINE_ID, prBATCH_ID, BATCH_NO)
                        Dim dgvTop_Index As Integer = dgv.Rows.Count - 1
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        'CUSTOM DATA
                        frmCustomGroupItem.gsITEM_ID = item_ID
                        frmCustomGroupItem.ShowDialog()
                        Dim d As DataGridView = frmCustomGroupItem.dgvSelected
                        Dim gsGROUP_ID As Integer = frmCustomGroupItem.gsITEM_ID
                        Dim D_TOTAL As Double = 0
                        If d.Rows.Count <> 0 Then

                            For N As Integer = 0 To d.Rows.Count - 1
                                Dim r As DataGridViewRow = d.Rows(N)
                                'ADD ITEM GROUP
                                Dim rd_item As OdbcDataReader = fReader($"select * from item where `id` = '{r.Cells("ITEM_ID").Value}' limit 1;")
                                D_TOTAL = D_TOTAL + fNumisNULL(r.Cells("RATE").Value)

                                If rd_item.Read Then
                                    fRow_Data_Item_Sales_Receipt(dgv, True, r.Cells("ITEM_ID").Value, r.Cells("QTY").Value, fNumFormatStandard(r.Cells("RATE").Value / r.Cells("QTY").Value), IIf(fNumisNULL(r.Cells("RATE").Value) = 0, 0, discount_type), IIf(fNumisNULL(r.Cells("RATE").Value) = 0, 0, discount_rate), fNumFormatStandard(r.Cells("RATE").Value), IIf(fNumisNULL(rd_item("TAXABLE")) = 0, False, True), fNumisNULL(rd_item("BASE_UNIT_ID")), "A", 1, 0, 0, "", G_PRINT_IN_FORMS, item_ID, 0)
                                End If
                                rd_item.Close()

                            Next
                            dgv.Rows(dgvTop_Index).Cells("UNIT_PRICE").Value = fNumFormatStandard(D_TOTAL)
                            dgv.Rows(dgvTop_Index).Cells("AMOUNT").Value = fNumFormatStandard(D_TOTAL)
                        Else
                            dgv.Rows.RemoveAt(dgvTop_Index)

                            fMessageboxInfo("No Item Selected - Transaction canceled.")
                        End If
                        frmCustomGroupItem.Dispose()
                        frmCustomGroupItem = Nothing

                    Else

                        .Rows.Add("N", gsITEM_CODE, Item_Description, qty, UM_Description, fNumFormatStandard(price), discount_type, IIf(DISCOUNT_ID = "1", Val(discount_rate), fNumFormatStandard(Val(discount_rate))), fNumFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, COGS_AMOUNT_ID, ASSET_ACCOUNT_ID, INCOME_ACCOUNT_ID, PRICE_LEVEL_ID, ORG_AMT, item_ID, POS_TRX_TYPE, POS_EDIT_QTY, POS_NOTES, prPrintINForm, DEPOSITED, ITEM_TYPE, NON_DISCOUNTED_ITEM, prGROUP_LINE_ID, prBATCH_ID, BATCH_NO)
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        Dim rd_group As OdbcDataReader = fReader("SELECT ic.*,s.`TAXABLE`,i.TYPE,s.BASE_UNIT_ID FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                        While rd_group.Read

                            'ADD ITEM GROUP
                            Dim r_rate As Double = IIf(fNumisNULL(rd_group("RATE")) <= Amt, fNumisNULL(rd_group("RATE")), Amt)
                            Dim BS_UNIT As String = fTextisNULL(rd_group("BASE_UNIT_ID"))
                            fRow_Data_Item_Sales_Receipt(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), IIf(fNumisNULL(rd_group("RATE")) = 0, 0, discount_type), IIf(fNumisNULL(rd_group("RATE")) = 0, 0, discount_rate), (r_rate * Int(qty)), IIf(fNumisNULL(rd_group("TAXABLE")) = 0, False, True), BS_UNIT, "A", 1, IIf(fNumisNULL(rd_group("RATE")) = 0, 0, DISCOUNT_ID), 0, "", G_PRINT_IN_FORMS, item_ID, 0)
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
                        .Cells(5).Value = fNumFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = fNumFormatStandard(discount_rate)
                        .Cells(8).Value = fNumFormatStandard(Amt)
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
                        i = i + 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = fReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = fNumFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i = i + 1
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try

    End Sub
    Public Sub fRow_Data_Item_Sales_Order(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prREF_LINE_ID As String, ByVal prPRICE_LEVEL_ID As String, ByVal prPrintINForm As Boolean, ByVal GROUP_LINE_ID As Integer)
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

            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION"))
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    G_PRINT_IN_FORMS = CBool(fNumisNULL(rd("PRINT_INDIVIDUAL_ITEMS")))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    NON_PORFOLIO_COMPUTATION = CBool(fNumisNULL(rd("PRINT_INDIVIDUAL_ITEMS")))
                End If
                rd.Close()

                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL")

                If bNEw = True Then


                    If ITEM_TYPE = 6 And NON_PORFOLIO_COMPUTATION = True Then
                        'CUSTOM BUNDLE
                        .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, fNumFormatStandard(price), discount_type, fNumFormatStandard(discount_rate), 0, tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ESTIMATE_LINE_ID, ORG_AMT, item_ID, PRICE_LEVEL_ID, ITEM_TYPE, prPrintINForm, GROUP_LINE_ID)
                        Dim dgvTop_Index As Integer = dgv.Rows.Count - 1
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        'CUSTOM DATA
                        frmCustomGroupItem.gsITEM_ID = item_ID
                        frmCustomGroupItem.ShowDialog()
                        Dim d As DataGridView = frmCustomGroupItem.dgvSelected
                        Dim gsGROUP_ID As Integer = frmCustomGroupItem.gsITEM_ID
                        Dim D_TOTAL As Double = 0
                        If d.Rows.Count <> 0 Then

                            For N As Integer = 0 To d.Rows.Count - 1
                                Dim r As DataGridViewRow = d.Rows(N)
                                'ADD ITEM GROUP
                                Dim rd_item As OdbcDataReader = fReader($"select * from item where `id` = '{r.Cells("ITEM_ID").Value}' limit 1;")
                                D_TOTAL = D_TOTAL + fNumisNULL(r.Cells("RATE").Value)
                                If rd_item.Read Then

                                    fRow_Data_Item_Sales_Order(dgv, True, r.Cells("ITEM_ID").Value, r.Cells("QTY").Value, fNumFormatStandard(r.Cells("RATE").Value), 0, 0, fNumisNULL(r.Cells("RATE").Value), fNumisNULL(rd_item("TAXABLE")), fNumisNULL(rd_item("BASE_UNIT_ID")), "A", 1, "", 0, "", "", G_PRINT_IN_FORMS, item_ID)
                                End If
                                rd_item.Close()

                            Next
                            dgv.Rows(dgvTop_Index).Cells("UNIT_PRICE").Value = fNumFormatStandard(D_TOTAL)
                            dgv.Rows(dgvTop_Index).Cells("AMOUNT").Value = fNumFormatStandard(D_TOTAL)
                        Else
                            dgv.Rows.RemoveAt(dgvTop_Index)

                            fMessageboxInfo("No Item Selected - Transaction canceled.")
                        End If
                        frmCustomGroupItem.Dispose()
                        frmCustomGroupItem = Nothing


                    Else

                        .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, fNumFormatStandard(price), discount_type, fNumFormatStandard(discount_rate), fNumFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ESTIMATE_LINE_ID, ORG_AMT, item_ID, PRICE_LEVEL_ID, ITEM_TYPE, prPrintINForm, GROUP_LINE_ID)
                        If prPrintINForm = True Then
                            .Rows(.Rows.Count - 1).Visible = False
                        End If

                        Dim bGroup As Boolean = True

                        Dim rd_group As OdbcDataReader = fReader("SELECT ic.*,s.`TAXABLE` FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                        While rd_group.Read
                            fRow_Data_Item_Sales_Order(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), 0, 0, (rd_group("RATE") * Int(qty)), IIf(fNumisNULL(rd_group("TAXABLE")) = 0, False, True), 0, "A", 1, "", 0, "", "", G_PRINT_IN_FORMS, item_ID)
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
                        i = i + 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = fReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = fNumFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i = i + 1
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
    End Sub
    Public Sub fRow_Data_Item_Estimate(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prPRICE_LEVEL_ID As String)
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
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                End If
                rd.Close()
                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, Format(price, "standard"), discount_type, Format(discount_rate, "standard"), Format(Amt, "Standard"), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, PRICE_LEVEL_ID, ITEM_TYPE)
                    'fDiscount_ReComputed(dgv)
                    'cn.Open()
                    Dim bGroup As Boolean = True
                    Dim i_group_amount As Double = 0
                    Dim rd_group As OdbcDataReader = fReader("SELECT ic.*,s.`TAXABLE` FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` = '6' and i.ID = '" & item_ID & "' Limit 100 ")
                    While rd_group.Read
                        If bGroup = True Then
                            .Rows(.Rows.Count - 1).DefaultCellStyle.BackColor = Color.Yellow
                            bGroup = False
                        End If
                        'ADD ITEM GROUP
                        i_group_amount = i_group_amount + (rd_group("RATE") * Int(qty))
                        fRow_Data_Item_Sales_Order(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), 0, 0, (rd_group("RATE") * Int(qty)), IIf(fNumisNULL(rd_group("TAXABLE")) = 0, False, True), 0, "A", 1, "", 0, "", "", False, item_ID)
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

                    If fGROUP_ITEM(ITEM_TYPE, sGROUP_ITEM_ACTIVE) = True Then
                        'EDIT ITEM GROUP


                        Do Until sGROUP_ITEM_ACTIVE = False
                            i = i + 1
                            With .Rows.Item(i)
                                If .Cells(18).Value = item_ID Then
                                    sGROUP_ITEM_ACTIVE = False
                                    Exit Do
                                End If

                                '   cn.Open()
                                Dim rd_group As OdbcDataReader = fReader("select * from item_components where ITEM_ID = '" & item_ID & "' and component_id = '" & .Cells(19).Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                                    .Cells(3).Value = Int(rd_group("QUANTITY") * qty)
                                    .Cells(5).Value = fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
    End Sub

    Public Sub fRow_Data_Item_Credit_Memo(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prPRICE_LEVEL_ID As String, ByVal prGROUP_LINE_ID As Integer, ByVal prPrintINForm As Boolean, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim BATCH_NO As String = fGetFieldValue("item_batches", "id", prBATCH_ID, "batch_no")
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


            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    G_PRINT_IN_FORMS = CBool(fNumisNULL(rd("PRINT_INDIVIDUAL_ITEMS")))
                End If
                rd.Close()

                PRICE_LEVEL_ID = prPRICE_LEVEL_ID
                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, fNumFormatStandard(price), discount_type, IIf(DISCOUNT_ID = "1", Val(discount_rate), fNumFormatStandard(discount_rate)), fNumFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, COGS_AMOUNT_ID, ASSET_ACCOUNT_ID, INCOME_ACCOUNT_ID, PRICE_LEVEL_ID, ORG_AMT, item_ID, prGROUP_LINE_ID, ITEM_TYPE, prPrintINForm, prBATCH_ID, BATCH_NO)

                    If prPrintINForm = True Then
                        .Rows(.Rows.Count - 1).Visible = False
                    End If

                    Dim rd_group As OdbcDataReader = fReader("SELECT ic.*,s.`TAXABLE`,i.TYPE,s.BASE_UNIT_ID FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                    While rd_group.Read

                        Dim r_rate As Double = IIf(fNumisNULL(rd_group("RATE")) <= Amt, fNumisNULL(rd_group("RATE")), Amt)
                        Dim BS_UNIT As String = fTextisNULL(rd_group("BASE_UNIT_ID"))

                        fRow_Data_Item_Credit_Memo(dgv, True, rd_group("COMPONENT_ID"), rd_group("QUANTITY") * Int(qty), fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), IIf(fNumisNULL(rd_group("RATE")) = 0, 0, discount_type), IIf(fNumisNULL(rd_group("RATE")) = 0, 0, discount_rate), (r_rate * Int(qty)), IIf(fNumisNULL(rd_group("TAXABLE")) = 0, False, True), BS_UNIT, "A", 1, "", 0, "", item_ID, G_PRINT_IN_FORMS, 0)
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
                        .Cells(5).Value = fNumFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = fNumFormatStandard(discount_rate)
                        .Cells(8).Value = fNumFormatStandard(Amt)
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
                        i = i + 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = fReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = fNumFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i = i + 1
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fRemoveItems(ByVal dgv As DataGridView, ByVal Ndex As Integer)
        Try
            If dgv.Rows.Count <> 0 Then
                Dim i As Integer = Ndex
                Dim d As DataGridViewRow = dgv.Rows(i)

                If fNumisNULL(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                    fMessageboxInfo("Invalid Delete")
                    Exit Sub
                ElseIf fNumisNULL(d.Cells("ITEM_TYPE").Value) = 10 Then
                    fMessageboxInfo("Invalid room delete")
                    Exit Sub
                ElseIf fNumisNULL(d.Cells("ITEM_TYPE").Value) = 6 Or fNumisNULL(d.Cells("ITEM_TYPE").Value) = 9 Then
                    '===============================================================================================
                    Dim THIS_ITEM_ID As Integer = d.Cells("ITEM_ID").Value
                    If fNumisNULL(dgv.Rows(i).Cells(0).Value) <> 0 Then
                        dgv.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgv.Rows(i).Visible = False
                        i = i + 1
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
                            While fNumisNULL(dgv.Rows(i).Cells("GROUP_LINE_ID").Value) = THIS_ITEM_ID
                                dgv.Rows.RemoveAt(i)
                            End While
                        Catch ex As Exception
                        End Try
                    End If

                    '=========================================================================================
                Else

                    If fNumisNULL(dgv.Rows(i).Cells(0).Value) <> 0 Then
                        dgv.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                        dgv.Rows(i).Visible = False
                    Else
                        dgv.Rows.RemoveAt(i)
                    End If

                End If
            End If
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
    End Sub

    Public Sub fRow_Data_Item_Bill_Credit(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prClass_ID As String, ByVal prBATCH_ID As Integer)
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
        Dim CLASS_NAME As String = fGetFieldValue("CLASS", "ID", prClass_ID, "NAME")
        Dim BATCH_NO As String = fGetFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        Dim ITEM_TYPE As Integer = 0
        ' Dim cn As New MySqlConnection(mysqlConstr)
        Try

            ' cn.Open()
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                End If
                rd.Close()

                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, fNumFormatStandard(price), discount_type, fNumFormatStandard(discount_rate), fNumFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, CLASS_NAME, prClass_ID, ITEM_TYPE, ASSET_ACCOUNT_ID, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = fNumFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = fNumFormatStandard(discount_rate)
                        .Cells(8).Value = fNumFormatStandard(Amt)
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fRow_Data_Item_Bill(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prClass_ID As String, ByVal prPO_ITEM_ID As String, ByVal prBATCH_ID As Integer)
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
        Dim CLASS_NAME As String = fGetFieldValue("CLASS", "ID", prClass_ID, "NAME")
        Dim BATCH_NO As String = fGetFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")

        Try
            Dim ITEM_TYPE As Integer = 0

            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    REF_LINE_ID = ""
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                End If
                rd.Close()
                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT
                If bNEw = True Then
                    .Rows.Add("N", gsITEM_CODE, Item_Description, Int(qty), UM_Description, fNumFormatStandard(price), discount_type, fNumFormatStandard(discount_rate), fNumFormatStandard(Amt), tax, Unit_ID, constrol_status, RATE_TYPE, UNIT_QUANTITY_BASE, DISCOUNT_ID, TAXABLE_AMOUNT, TAX_AMOUNT, ORG_AMT, item_ID, CLASS_NAME, prClass_ID, prPO_ITEM_ID, ITEM_TYPE, ASSET_ACCOUNT_ID, prBATCH_ID, BATCH_NO)
                Else
                    Dim i As Integer = .CurrentRow.Index
                    With .Rows.Item(i)
                        Dim ID_is_number As Boolean = IIf(IsNumeric(.Cells(0).Value) = True, True, False)
                        .Cells(1).Value = gsITEM_CODE
                        .Cells(2).Value = Item_Description
                        .Cells(3).Value = Int(qty)
                        .Cells(4).Value = UM_Description
                        .Cells(5).Value = fNumFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = fNumFormatStandard(discount_rate)
                        .Cells(8).Value = fNumFormatStandard(Amt)
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fRow_Data_StockTransfer(ByVal dgv As DataGridView, ByVal bAdd As Boolean, ByVal pritem_ID As String, ByVal prQty As Double, ByVal prQty_BASE As Double, ByVal prUnit_ID As Integer, ByVal prUnit_Price As Double, ByVal prTotal_Retail As Double, ByVal prCONTROL_STATUS As String, ByVal prBATCH_ID As Integer)

        Dim BATCH_NO As String = fGetFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")

        Dim sDESCRIPTION As String = ""
        Dim sUNIT_NAME As String = fGetFieldValue("UNIT_OF_MEASURE", "ID", prUnit_ID, "NAME")

        Dim sAccount_ID As Integer = 0
        Dim iUnit_Cost As Double = prUnit_Price
        Dim iUnit_Price As Double = 0
        Dim iTotal_Amount As Double = 0
        Dim item_CODE As String = ""

        Try

            '  cn.Open()
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & pritem_ID & "'  limit 1")

            If rd.Read Then
                sAccount_ID = fNumisNULL(rd("ASSET_ACCOUNT_ID"))
                item_CODE = fTextisNULL(rd("CODE"))
                sDESCRIPTION = fTextisNULL(rd("DESCRIPTION"))

                iUnit_Price = fNumisNULL(rd("RATE")) ' Rate now

                iTotal_Amount = iUnit_Cost * prQty ' Costing
                prTotal_Retail = iUnit_Price * prQty

                If bAdd = True Then
                    dgv.Rows.Add("N", pritem_ID, item_CODE, sDESCRIPTION, prQty, sUNIT_NAME, prUnit_ID, prQty_BASE, fNumFormatStandard(iUnit_Cost), fNumFormatStandard(iUnit_Price), fNumFormatStandard(iTotal_Amount), fNumFormatStandard(prTotal_Retail), sAccount_ID, prCONTROL_STATUS, prBATCH_ID, BATCH_NO)
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

                        .Cells(8).Value = fNumFormatStandard(iUnit_Cost)
                        .Cells(9).Value = fNumFormatStandard(iUnit_Price)

                        .Cells(10).Value = fNumFormatStandard(iTotal_Amount)

                        .Cells(11).Value = fNumFormatStandard(prTotal_Retail)
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fRow_Data_StockReceived(ByVal dgv As DataGridView, ByVal bAdd As Boolean, ByVal pritem_ID As String, ByVal prQty As Double, ByVal prQty_BASE As Double, ByVal prUnit_ID As Integer, ByVal prUnit_COST As Double, ByVal prUNIT_RATE As Double, ByVal prCONTROL_STATUS As String, ByVal prBill_Item_ID As String)


        Dim sDESCRIPTION As String = ""
        Dim sUNIT_NAME As String = ""

        Dim sAccount_ID As Integer = 0


        Dim iTotal_Amount As Double = 0
        Dim item_CODE As String = ""
        Dim iTotal_Retails As Double = 0
        Try

            '  cn.Open()
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & pritem_ID & "'  limit 1")

            If rd.Read Then
                sAccount_ID = fNumisNULL(rd("ASSET_ACCOUNT_ID"))
                item_CODE = fTextisNULL(rd("CODE"))
                sDESCRIPTION = fTextisNULL(rd("DESCRIPTION"))
                sUNIT_NAME = fGetFieldValue("UNIT_OF_MEASURE", "ID", prUnit_ID, "NAME")


                iTotal_Amount = prUnit_COST * prQty ' Costing
                iTotal_Retails = prUNIT_RATE * prQty

                If bAdd = True Then
                    dgv.Rows.Add("N", pritem_ID, item_CODE, sDESCRIPTION, prQty, sUNIT_NAME, prUnit_ID, prQty_BASE, fNumFormatStandard(prUnit_COST), fNumFormatStandard(prUNIT_RATE), fNumFormatStandard(iTotal_Amount), fNumFormatStandard(iTotal_Retails), sAccount_ID, prCONTROL_STATUS, prBill_Item_ID)
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

                        .Cells(8).Value = fNumFormatStandard(prUnit_COST)
                        .Cells(9).Value = fNumFormatStandard(prUNIT_RATE)

                        .Cells(10).Value = fNumFormatStandard(iTotal_Amount)

                        .Cells(11).Value = fNumFormatStandard(iTotal_Retails)
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fRow_Data_Item_Invoice(ByVal dgv As DataGridView, ByVal bNEw As Boolean, ByVal item_ID As String, ByVal qty As Double, ByVal price As Double, ByVal discount_type As String, ByVal discount_rate As String, ByVal Amt As Double, ByVal tax As Boolean, ByVal Unit_ID As String, ByVal constrol_status As String, ByVal UNIT_QUANTITY_BASE As Double, ByVal DISCOUNT_ID As String, ByVal ORG_AMT As Double, ByVal prREF_LINE_ID As String, ByVal prPRICE_LEVEL_ID As String, ByVal prGROUP_LINE_ID As Integer, ByVal prPrintINForm As Boolean, ByVal prBATCH_ID As Integer)
        If item_ID = "" Then Exit Sub
        Dim Item_Description As String = ""
        Dim TAXABLE_AMOUNT As Double = 0
        Dim TAX_AMOUNT As Double = 0
        Dim COGS_AMOUNT_ID As String = ""
        Dim ASSET_ACCOUNT_ID As String = ""
        Dim INCOME_ACCOUNT_ID As String = ""
        Dim gsITEM_CODE As String = ""
        Dim NON_PORFOLIO_COMPUTATION As Boolean = False
        Dim BATCH_NAME As String = fGetFieldValue("ITEM_BATCHES", "ID", prBATCH_ID, "BATCH_NO")
        Dim REF_LINE_ID As String = prREF_LINE_ID
        Dim RATE_TYPE As String = ""
        Dim PRICE_LEVEL_ID As String = prPRICE_LEVEL_ID
        Dim G_PRINT_IN_FORM As Boolean = False
        Dim ITEM_TYPE As Integer
        Try
            Dim rd As OdbcDataReader = fReader("select * from item where id = '" & item_ID & "' limit 1")
            With dgv
                If rd.Read Then
                    Item_Description = fTextisNULL(rd("DESCRIPTION")) ' Description_ITem
                    TAXABLE_AMOUNT = 0
                    TAX_AMOUNT = 0
                    COGS_AMOUNT_ID = fTextisNULL(rd("COGS_ACCOUNT_ID"))
                    ASSET_ACCOUNT_ID = fTextisNULL(rd("ASSET_ACCOUNT_ID"))
                    INCOME_ACCOUNT_ID = fTextisNULL(rd("GL_ACCOUNT_ID"))
                    gsITEM_CODE = fTextisNULL(rd("CODE"))
                    RATE_TYPE = fTextisNULL(rd("RATE_TYPE"))
                    ITEM_TYPE = fNumisNULL(rd("TYPE"))
                    G_PRINT_IN_FORM = fNumisNULL(rd("PRINT_INDIVIDUAL_ITEMS"))
                    NON_PORFOLIO_COMPUTATION = fNumisNULL(rd("NON_PORFOLIO_COMPUTATION"))
                End If
                rd.Close()

                Dim UM_Description As String = fGetFieldValue("unit_of_measure", "ID", Unit_ID, "SYMBOL") ' Discripion_UNIT

                If bNEw = True Then

                    If ITEM_TYPE = 6 And NON_PORFOLIO_COMPUTATION = True Then
                        'CUSTOM BUNDLE
                        .Rows.Add("N", '0
                              gsITEM_CODE, '1
                              Item_Description,'2
                              fNumFormatFixed(qty),'3
                              UM_Description,'4
                              fNumFormatStandard(price), '5
                              discount_type, '6
                              IIf(DISCOUNT_ID = "1", Val(discount_rate), fNumFormatStandard(discount_rate)), '7
                              fNumFormatStandard(Amt), '8
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
                        frmCustomGroupItem.gsITEM_ID = item_ID
                        frmCustomGroupItem.ShowDialog()
                        Dim d As DataGridView = frmCustomGroupItem.dgvSelected
                        Dim gsGROUP_ID As Integer = frmCustomGroupItem.gsITEM_ID
                        Dim D_TOTAL As Double = 0
                        If d.Rows.Count <> 0 Then

                            For N As Integer = 0 To d.Rows.Count - 1
                                Dim r As DataGridViewRow = d.Rows(N)

                                Dim rd_item As OdbcDataReader = fReader($"select * from item where `id` = '{r.Cells("ITEM_ID").Value}' limit 1;")
                                D_TOTAL = D_TOTAL + fNumisNULL(r.Cells("RATE").Value)
                                If rd_item.Read Then
                                    fRow_Data_Item_Invoice(dgv, True, r.Cells("ITEM_ID").Value, r.Cells("QTY").Value, (r.Cells("RATE").Value / r.Cells("QTY").Value), 0, 0, r.Cells("RATE").Value, rd_item("TAXABLE"), fNumisNULL(rd_item("BASE_UNIT_ID")), "A", 1, "", 0, "", "", item_ID, G_PRINT_IN_FORM, 0)
                                End If
                                rd_item.Close()

                            Next
                            dgv.Rows(dgvTop_Index).Cells("UNIT_PRICE").Value = fNumFormatStandard(D_TOTAL)
                            dgv.Rows(dgvTop_Index).Cells("AMOUNT").Value = fNumFormatStandard(D_TOTAL)
                        Else
                            dgv.Rows.RemoveAt(dgvTop_Index)

                            fMessageboxInfo("No Item Selected - Transaction canceled.")
                        End If
                        frmCustomGroupItem.Dispose()
                        frmCustomGroupItem = Nothing


                    Else


                        .Rows.Add("N", '0
                              gsITEM_CODE, '1
                              Item_Description,'2
                              fNumFormatFixed(qty),'3
                              UM_Description,'4
                              fNumFormatStandard(price), '5
                              discount_type, '6
                              IIf(DISCOUNT_ID = "1", Val(discount_rate), fNumFormatStandard(discount_rate)), '7
                              fNumFormatStandard(Amt), '8
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
                        Dim rd_group As OdbcDataReader = fReader("SELECT ic.*,s.`TAXABLE`,i.TYPE,s.BASE_UNIT_ID FROM item_components AS ic  INNER JOIN item AS i ON ic.item_ID = i.ID  INNER JOIN item AS s ON s.`ID` = ic.`COMPONENT_ID` WHERE i.`TYPE` IN ('6','9') and i.ID = '" & item_ID & "' Limit 100 ")
                        While rd_group.Read

                            Dim r_rate As Double = IIf(fNumisNULL(rd_group("RATE")) <= Amt, fNumisNULL(rd_group("RATE")), Amt)
                            Dim BS_UNIT As String = fTextisNULL(rd_group("BASE_UNIT_ID"))

                            fRow_Data_Item_Invoice(dgv, True, rd_group("COMPONENT_ID"), fNumisNULL(rd_group("QUANTITY")) * qty, fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY")), IIf(fNumisNULL(rd_group("RATE")) = 0, 0, discount_type), IIf(fNumisNULL(rd_group("RATE")) = 0, 0, discount_rate), (r_rate * Int(qty)), IIf(fNumisNULL(rd_group("TAXABLE")) = 0, False, True), BS_UNIT, "A", 1, "", 0, "", "", item_ID, G_PRINT_IN_FORM, 0)

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
                        .Cells(5).Value = fNumFormatStandard(price)
                        .Cells(6).Value = discount_type
                        .Cells(7).Value = IIf(DISCOUNT_ID = "1", Val(discount_rate), fNumFormatStandard(discount_rate))
                        .Cells(8).Value = fNumFormatStandard(Amt)
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
                        i = i + 1 ' NEXT 1

                        Try
                            While dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value = item_ID
                                Dim rd_group As OdbcDataReader = fReader("select * from item_components where ITEM_ID = '" & dgv.Rows.Item(i).Cells("GROUP_LINE_ID").Value & "' and component_id = '" & dgv.Rows.Item(i).Cells("ITEM_ID").Value & "' Limit 1")
                                If rd_group.Read Then
                                    Dim ID_is_number As Boolean = IIf(IsNumeric(dgv.Rows.Item(i).Cells("ID").Value) = True, True, False)
                                    dgv.Rows.Item(i).Cells("QTY").Value = CDbl(rd_group("QUANTITY") * qty)
                                    dgv.Rows.Item(i).Cells("UNIT_PRICE").Value = fNumFormatStandard(rd_group("RATE") / rd_group("QUANTITY"))
                                    dgv.Rows.Item(i).Cells("AMOUNT").Value = fNumFormatStandard(CDbl(rd_group("QUANTITY") * qty) * rd_group("RATE"))
                                    dgv.Rows.Item(i).Cells("CONTROL_STATUS").Value = IIf(ID_is_number = True, constrol_status, "A")
                                End If
                                rd_group.Close()
                                i = i + 1
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If

        End Try

    End Sub
    Public Sub fContactUpdate(ByVal dgv As DataGridView, ByVal gsNew As Boolean, ByVal BS As BindingSource, ByVal sQuery As String)

        Try
            Dim rd As OdbcDataReader = fReader(sQuery)

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
                            drToAdd(i) = fTextisNULL(rd(i))

                        Else
                            If Int(rd(i)) = True Then
                                drToAdd(i) = fNumisNULL(rd(i))
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
                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = fTextisNULL(rd(i))
                        Else
                            If Int(rd(i)) = True Then
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = fNumisNULL(rd(i))
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
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Public Sub fItemPerUpdate(ByVal dgv As DataGridView, ByVal gsID As String, ByVal gsNew As Boolean, ByVal BS As BindingSource, ByVal M As Boolean)
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

            Dim rd As OdbcDataReader = fReader(xSQL)
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
                                drToAdd(i) = fNumisNULL(rd(i))
                            Else
                                drToAdd(i) = rd(i)
                            End If

                        Else

                            drToAdd(i) = fTextisNULL(rd(i))
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
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = fNumisNULL(rd(i))
                            Else
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = rd(i)
                            End If


                        Else

                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = fTextisNULL(rd(i))
                        End If
                    Next
                    BS.Position = dgv.CurrentRow.Index
                End If

            End If
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try

    End Sub
    Private Function fCheckifDiscountNext(ByVal dgv As DataGridView, ByVal ndex As Integer) As Boolean
        Try
            If fDISCOUNT_ITEM(dgv.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Sub fPurchase_Vendor_Computation(ByVal dgv As DataGridView, ByVal cmbINPUT_TAX_ID As ComboBox, ByVal lblINPUT_TAX_AMOUNT As Label, ByVal lblAMOUNT As Label, ByVal lblTAXABLE_AMOUNT As Label, ByVal lblNONTAXABLE_AMOUNT As Label, ByVal lblINPUT_TAX_RATE As Label)
        Dim total As Double = 0
        Dim dINput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim n As Integer = 0
        Dim dVat As Double = 0

        Dim group_item_active As Boolean = False
        Dim group_item_id As Integer = 0


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
                        dTotal_amount = dTotal_amount + fNumFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        If dgv.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax = dNon_Tax + fNumFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax = dTax + fNumFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                n = n + 1
            Next
            dTotal_amount = iSUB_Total + dTotal_amount
            dTax = iSUB_TAX + dTax
            dNon_Tax = iSUB_NON_TAX + dNon_Tax
            If fTextisNULL(cmbINPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = fTax_Rate_Find(fNumisNULL(cmbINPUT_TAX_ID.SelectedValue))
                dINput_value = (dVat / 100) * dTax
                total = dINput_value + dTax

                If cmbINPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dINput_value = t * dINput_value
                    dTax = dTax - dINput_value
                    total = dINput_value + dTax
                End If
                total = total + dNon_Tax
                lblINPUT_TAX_AMOUNT.Text = fNumFormatStandard(dINput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)


                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(dTax)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblINPUT_TAX_AMOUNT.Text = fNumFormatStandard(dINput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)

                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(0)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(total)
            End If

            lblINPUT_TAX_RATE.Text = dVat


        Catch ex As Exception

        End Try

    End Sub
    Public Sub fBill_Vendor_Computation(ByVal dgvItem As DataGridView, ByVal dgvExpenses As DataGridView, ByVal cmbINPUT_TAX_ID As ComboBox, ByVal lblINPUT_TAX_AMOUNT As Label, ByVal lblAMOUNT As Label, ByVal lblINPUT_TAX_RATE As Label, ByVal lbsTotal_Amount_Item As ToolStripLabel, ByVal lbsTotal_Amount_Expense As ToolStripLabel)
        Dim total As Double = 0
        Dim dINput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTotal_item As Double = 0
        Dim dTotal_Expenses As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        'Dim n As Integer = 0
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
                        dTotal_item = dTotal_item + fNumFormatFixed(dgvItem.Rows(i).Cells("AMOUNT").Value)

                        If dgvItem.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax = dNon_Tax + fNumFormatFixed(dgvItem.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax = dTax + fNumFormatFixed(dgvItem.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                '  n = n + 1
            Next

            dTotal_amount = dTotal_amount + dTotal_item
            '============================================================= END ITEMS

            '============================================================== EXPENSE
            For i As Integer = 0 To dgvExpenses.Rows.Count - 1
                If dgvExpenses.Rows(i).Cells("CONTROL_STATUS").Value <> "D" Then
                    dTotal_Expenses = dTotal_Expenses + fNumFormatFixed(dgvExpenses.Rows(i).Cells("AMOUNT").Value)
                    If fNumisNULL(dgvExpenses.Rows(i).Cells("Tax").Value) = 0 Then
                        dNon_Tax = dNon_Tax + fNumFormatFixed(dgvExpenses.Rows(i).Cells("AMOUNT").Value)
                    Else
                        dTax = dTax + fNumFormatFixed(dgvExpenses.Rows(i).Cells("AMOUNT").Value)
                    End If
                End If
            Next
            dTotal_amount = dTotal_amount + dTotal_Expenses
            '============================================================== END  EXPENSE

            lbsTotal_Amount_Item.Text = fNumFormatStandard(dTotal_item)
            lbsTotal_Amount_Expense.Text = fNumFormatStandard(dTotal_Expenses)



            If fTextisNULL(cmbINPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = fTax_Rate_Find(fNumisNULL(cmbINPUT_TAX_ID.SelectedValue))
                dINput_value = (dVat / 100) * dTax
                total = dINput_value + dTax

                If cmbINPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dINput_value = t * dINput_value
                    dTax = dTax - dINput_value
                    total = dINput_value + dTax
                End If
                total = total + dNon_Tax
                lblINPUT_TAX_AMOUNT.Text = fNumFormatStandard(dINput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)


                'lblTAXABLE_AMOUNT.Text = fNumFormatStandard(dTax)
                'lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblINPUT_TAX_AMOUNT.Text = fNumFormatStandard(dINput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)

                'lblTAXABLE_AMOUNT.Text = fNumFormatStandard(0)
                'lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(total)
            End If

            lblINPUT_TAX_RATE.Text = dVat

        Catch ex As Exception

        End Try

    End Sub
    Public Sub fSales_Customer_Computation(ByVal dgv As DataGridView, ByVal cmbOUTPUT_TAX_ID As ComboBox, ByVal lblOUTPUT_TAX_AMOUNT As Label, ByVal lblAMOUNT As Label, ByVal lblTAXABLE_AMOUNT As Label, ByVal lblNONTAXABLE_AMOUNT As Label, ByVal lblOUTPUT_TAX_RATE As Label, ByRef SubTotal As Double)

        Dim total As Double = 0
        Dim dOutput_value As Double = 0

        Dim dTotal_amount As Double = 0
        Dim dTax As Double = 0
        Dim dNon_Tax As Double = 0
        Dim n As Integer = 0
        Dim dVat As Double = 0

        Dim group_item_active As Boolean = False
        Dim group_item_id As Integer = 0


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
                        dTotal_amount = dTotal_amount + fNumFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        If dgv.Rows(i).Cells("Tax").Value = False Then
                            dNon_Tax = dNon_Tax + fNumFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        Else
                            dTax = dTax + fNumFormatFixed(dgv.Rows(i).Cells("AMOUNT").Value)
                        End If
                    End If
                End If
                n = n + 1
            Next

            SubTotal = dTotal_amount

            dNon_Tax = iSUB_NON_TAX + dNon_Tax
            If fTextisNULL(cmbOUTPUT_TAX_ID.Text) <> "" Then
                'add tax
                dVat = fTax_Rate_Find(fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue))
                dOutput_value = (dVat / 100) * dTax
                total = dOutput_value + dTax

                If cmbOUTPUT_TAX_ID.SelectedValue = 12 Then
                    Dim t As Double = (100 / 112)
                    dOutput_value = t * dOutput_value
                    dTax = dTax - dOutput_value
                    total = dOutput_value + dTax
                End If
                total = total + dNon_Tax
                lblOUTPUT_TAX_AMOUNT.Text = fNumFormatStandard(dOutput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)


                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(dTax)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(dNon_Tax)
            Else
                total = dTotal_amount

                lblOUTPUT_TAX_AMOUNT.Text = fNumFormatStandard(dOutput_value)
                lblAMOUNT.Text = fNumFormatStandard(total)

                lblTAXABLE_AMOUNT.Text = fNumFormatStandard(0)
                lblNONTAXABLE_AMOUNT.Text = fNumFormatStandard(total)
            End If

            lblOUTPUT_TAX_RATE.Text = dVat


        Catch ex As Exception

        End Try
    End Sub
    Public Function fDISCOUNT_OTHERCHARGE(ByVal SubTotal As Double, ByVal ItemType As Integer, ByVal gsRate_Type As Integer, ByVal Unit_Value As Double)
        Dim ReturnValue As Double = 0
        Dim L As Double = 0
        Select Case ItemType
            Case 4
                'OTHER CHRGE
                If gsRate_Type = 0 Then
                    ReturnValue = fNumFormatFixed(Unit_Value)
                Else
                    L = SubTotal * (Unit_Value / 100)
                    ReturnValue = fNumFormatFixed(L)
                End If

            Case 7
                'DISCOUNT
                If gsRate_Type = 0 Then
                    ReturnValue = fNumFormatFixed(Unit_Value) * -1
                Else
                    L = SubTotal * (Unit_Value / 100)
                    ReturnValue = fNumFormatFixed(L) * -1
                End If
        End Select

        Return ReturnValue
    End Function
End Module
