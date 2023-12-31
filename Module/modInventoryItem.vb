﻿Imports System.Data.Odbc
Module modInventoryItem
    Public Qty As Double
    Public Qty_End As Double
    Public Cost As Double
    Public Ending_unit_cost As Double
    Public Ending_cost As Double
    Dim DateStart As Date
    Public Function GF_ItemInventoryReturnValue(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prTYPE As Integer, ByVal prID As Double, ByVal prDate As Date, ByVal prField As String) As String
        Dim prReturn As String = ""

        Try
            Dim sQuery As String = ""
            If prID = 0 Then
                sQuery = "select " & prField & " from item_inventory where ITEM_ID  = '" & prITEM_ID & "' and LOCATION_ID = '" & prLOCATION_ID & "' and  SOURCE_REF_DATE <= '" & Format(prDate, "yyyy-MM-dd") & "' order by SOURCE_REF_DATE DESC,ID DESC limit 1"
            Else
                sQuery = "select " & prField & " from item_inventory where ITEM_ID  = '" & prITEM_ID & "' and LOCATION_ID = '" & prLOCATION_ID & "' and SOURCE_REF_TYPE = '" & prTYPE & "' and  SOURCE_REF_ID = '" & prID & "' and SOURCE_REF_DATE = '" & GetDateFormatMySql(prDate) & "'  limit 1"
            End If
            GetDateTimeNowSql()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                prReturn = rd(prField)
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return prReturn
    End Function

    Public Sub GS_BILL_ITEM_COST_UPDATE_NEW(ByVal prItem_ID As Integer, ByVal prCOST As Double)
        SqlExecuted("UPDATE item SET COST = '" & prCOST & "' where ID = '" & prItem_ID & "'")
    End Sub


    Private Function LatestAdjustment(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prSOURCE_REF_ID As Integer, ByVal prSOURCE_REF_TYPE As Integer) As Boolean
        Dim B As Boolean
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.SOURCE_REF_DATE,i.QUANTITY,i.ENDING_QUANTITY,i.COST,i.ENDING_UNIT_COST,i.ENDING_COST FROM item_inventory  AS i WHERE i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' AND i.SOURCE_REF_TYPE ='{prSOURCE_REF_TYPE}' and i.SOURCE_REF_ID = '{prSOURCE_REF_ID}' order by i.ID desc Limit 1 ")
        If rd.Read Then
            DateStart = rd("SOURCE_REF_DATE")
            Qty = GF_NumIsNull(rd("QUANTITY"))
            Qty_End = GF_NumIsNull(rd("ENDING_QUANTITY"))
            Cost = GF_NumIsNull(rd("COST"))
            Ending_unit_cost = GF_NumIsNull(rd("ENDING_UNIT_COST"))
            Ending_cost = GF_NumIsNull(rd("ENDING_COST"))
            B = True
        Else
            Qty = 0
            B = False
        End If
        rd.Close()
        Return B
    End Function

    'Public Sub ReCalculateInventory(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal ThisDate As Date)
    '    GS_CursorLoadingOn(True)
    '    Dim Qty_END_T As Double = QtyActualOnDateLocation(prITEM_ID, ThisDate, prLOCATION_ID)

    '    Dim NewSQL As String = ""

    '    Dim rd As OdbcDataReader = SqlReader($"SELECT i.* FROM item_inventory  AS i WHERE i.SOURCE_REF_DATE >='{ GetDateFormatMySql(ThisDate) }' and i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' order by i.SOURCE_REF_DATE,i.ID")
    '    While rd.Read
    '        If GF_NumIsNull(rd("SOURCE_REF_TYPE")) = 6 Then
    '            Dim L_QTY As Double = Qty_END_T
    '            Qty_END_T = GF_NumIsNull(rd("ENDING_QUANTITY"))
    '            Dim D_QTY As Double = Qty_END_T - L_QTY
    '            NewSQL = NewSQL & $"UPDATE item_inventory SET QUANTITY='{GF_NumIsNull(D_QTY)}' WHERE ID ='{rd("ID")}' and ITEM_ID = '{prITEM_ID}' and LOCATION_ID ='{prLOCATION_ID}' Limit 1;"
    '        Else
    '            Qty_END_T = Qty_END_T + GF_NumIsNull(rd("QUANTITY"))
    '            NewSQL = NewSQL & $"UPDATE item_inventory SET ENDING_QUANTITY='{GF_NumIsNull(Qty_END_T)}' WHERE ID ='{rd("ID")}' and ITEM_ID = '{prITEM_ID}' and LOCATION_ID ='{prLOCATION_ID}' Limit 1;"
    '        End If

    '    End While
    '    rd.Close()
    '    If NewSQL <> "" Then
    '        SqlExecuted(NewSQL)

    '    End If
    '    GS_CursorLoadingOn(False)


    'End Sub
    'Public Sub fDeleteItem_INVENTORY_ITEM_RECALCULATE(ByVal dgv As DataGridView, ByVal LOCATION_ID As Integer, ByVal SOURCE_DATE As Date)

    '    For I As Integer = 0 To dgv.Rows.Count - 1

    '        Dim R As DataGridViewRow = dgv.Rows(I)
    '        Dim ITEM_ID As Integer = R.Cells("ITEM_ID").Value
    '        ReCalculateInventory(ITEM_ID, LOCATION_ID, SOURCE_DATE.AddDays(-1))

    '    Next

    'End Sub
    'Public Sub fINVENTORY_ITEM_RECALCULATE_QTY(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal SOURCE_DATE As Date)
    '    ReCalculateInventory(ITEM_ID, LOCATION_ID, SOURCE_DATE.AddDays(-1))
    'End Sub


    Public Sub GS_UpdateItemInventory_AccountJournalCost(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prSOURCE_REF_ID As Integer, ByVal prSOURCE_REF_TYPE As Integer, ByVal prOBJECT_TYPE As Integer)
        If LatestAdjustment(prITEM_ID, prLOCATION_ID, prSOURCE_REF_ID, prSOURCE_REF_TYPE) = True Then

            Dim Qty_END_T As Double = Qty_End
            Dim COST_T As Double
            '  Dim NewSQL As String = ""
            Dim Cost_UN_END As Double
            Dim Temp_ENDING_COST As Double
            Dim Last_COST As Double = Ending_unit_cost


            Dim rd As OdbcDataReader = SqlReader($"SELECT i.* FROM item_inventory  AS i WHERE i.SOURCE_REF_DATE >='{ GetDateFormatMySql(DateStart) }' and i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' AND i.SOURCE_REF_TYPE <> '{prSOURCE_REF_TYPE}' order by i.ID")
            While rd.Read
                Qty_END_T += GF_NumIsNull(rd("QUANTITY"))
                Cost_UN_END = Ending_unit_cost

                If GF_NumIsNull(rd("QUANTITY")) <= 0 Then
                    COST_T = 0
                    Temp_ENDING_COST = Last_COST * Qty_END_T
                Else
                    Last_COST = Cost_UN_END
                    Temp_ENDING_COST = Qty_END_T * Last_COST
                    COST_T = Qty_END_T * Last_COST
                End If

                SqlExecuted($"UPDATE item_inventory SET ENDING_QUANTITY='{GF_NumIsNull(Qty_END_T)}',COST={GotNullNumber(COST_T)},ENDING_COST={GotNullNumber(Temp_ENDING_COST)},ENDING_UNIT_COST={GotNullNumber(Cost_UN_END)} WHERE ID ='{rd("ID")}' and ITEM_ID = '{prITEM_ID}' and LOCATION_ID ='{prLOCATION_ID}' Limit 1;")

            End While
            rd.Close()

            Dim item_rd As OdbcDataReader = SqlReader($"Select COGS_ACCOUNT_ID,ASSET_ACCOUNT_ID from item Where ID = '{prITEM_ID}'  Limit 1")
            If item_rd.Read Then
                CostUpdateJournal(item_rd("COGS_ACCOUNT_ID"), prITEM_ID, prLOCATION_ID, Ending_unit_cost, DateStart, prOBJECT_TYPE)
                CostUpdateJournal(item_rd("ASSET_ACCOUNT_ID"), prITEM_ID, prLOCATION_ID, Ending_unit_cost, DateStart, prOBJECT_TYPE)
            End If
            item_rd.Close()
        End If


    End Sub

    Private Sub CostUpdateJournal(ByVal ACCOUNT_ID As Integer, ByVal ITEM_SUBSI As Integer, ByVal LOCATION_ID As Integer, ByVal ThisCost As Double, ByVal ThisDate As Date, ByVal prOBJECT_TYPE As Integer)
        Dim Tmp_SQL As String = ""
        Dim T_Balance As Double = GF_GET_ENDING_BALANCE(ACCOUNT_ID, ITEM_SUBSI, LOCATION_ID, ThisDate)
        Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM account_journal WHERE OBJECT_TYPE <> '{prOBJECT_TYPE}' and SUBSIDIARY_ID = '{ITEM_SUBSI}' AND location_id ='{LOCATION_ID}' AND account_id = '{ACCOUNT_ID}' and OBJECT_DATE >='{GetDateFormatMySql(ThisDate)}' ORDER BY OBJECT_DATE,ID")
        While rd.Read

            Dim SQL_ITEM As String
            If 20 = GF_NumIsNull(rd("OBJECT_TYPE")) Then

                SQL_ITEM = $"SELECT ENDING_QUANTITY as QUANTITY FROM ITEM_INVENTORY WHERE SOURCE_REF_TYPE ='6' and  SOURCE_REF_ID='{rd("OBJECT_ID")}'  and ITEM_ID ='{ITEM_SUBSI}' and SOURCE_REF_DATE = '{rd("OBJECT_DATE")}' Limit 1; "

            Else
                SQL_ITEM = $"SELECT QUANTITY FROM {GF_GetStringFieldValue("OBJECT_TYPE_MAP", "ID", rd("OBJECT_TYPE"), "TABLE_NAME")} WHERE ID='{rd("OBJECT_ID")}'  and ITEM_ID ='{ITEM_SUBSI}' Limit 1; "

            End If

            Dim rd_item As OdbcDataReader = SqlReader(SQL_ITEM)
            If rd_item.Read Then
                If GF_NumIsNull(rd("ENTRY_TYPE")) = 0 Then
                    T_Balance += (ThisCost * GF_NumIsNull(rd_item("QUANTITY")))
                Else
                    T_Balance -= (ThisCost * GF_NumIsNull(rd_item("QUANTITY")))
                End If

                Tmp_SQL &= $"UPDATE account_journal SET AMOUNT = '{(ThisCost * GF_NumIsNull(rd_item("QUANTITY")))}', ENDING_BALANCE ='{T_Balance}' WHERE ID ='{rd("ID")}' and SUBSIDIARY_ID = '{ITEM_SUBSI}' AND location_id ='{LOCATION_ID}' AND account_id = '{ACCOUNT_ID}' Limit 1;"
            End If
            rd_item.Close()
        End While
        rd.Close()

        If Tmp_SQL <> "" Then
            SqlExecuted(Tmp_SQL)
        End If
    End Sub
    Private Function GF_GET_ENDING_BALANCE(ByVal ACCOUNT_ID As Integer, ByVal ITEM_SUBSI As Integer, ByVal LOCATION_ID As Integer, ByVal ThisDate As Date) As Double
        Dim ThisBalance As Double
        Dim rd As OdbcDataReader = SqlReader($"SELECT ENDING_BALANCE FROM account_journal WHERE SUBSIDIARY_ID = '{ITEM_SUBSI}' AND location_id ='{LOCATION_ID}' AND account_id = '{ACCOUNT_ID}' and OBJECT_DATE < '{GetDateFormatMySql(ThisDate)}' ORDER BY OBJECT_DATE DESC,ID DESC LIMIT 1")
        If rd.Read Then
            ThisBalance = GF_NumIsNull(rd("ENDING_BALANCE"))
        End If
        rd.Close()
        Return ThisBalance
    End Function
    Public Sub InventoryVDetailsQuickView(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal dtSTART As Date, ByVal prFind As String)

        If UserSecurtySystemDOCShow("Item Valuation Details") = False Then

            If IsAccessDenied("You are not allowed access to Item Valuation Details or perform the request function operation. For more information, contact the BMS administrator ") = True Then
                Exit Sub
            End If

        End If

        Dim prFile_name As String = "cryItemValuationDetails.rpt"
        gsToolPanelView = False
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, GetDateFormatMySql(dtSTART), "fdate")
        CryParameterInsertValue(gscryRpt, GetDateNow, "tdate")
        CryParameterInsertValue(gscryRpt, "*", "customerid")
        CryParameterInsertValue(gscryRpt, prLOCATION_ID, "locationid")
        CryParameterInsertValue(gscryRpt, "*", "statusid")
        CryParameterInsertValue(gscryRpt, "*", "doctype")
        CryParameterInsertValue(gscryRpt, "*", "salesrepid")
        CryParameterInsertValue(gscryRpt, "*", "customergroupid")
        CryParameterInsertValue(gscryRpt, prITEM_ID, "item_code_id")
        CryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        CryParameterInsertValue(gscryRpt, "*", "item_group_id")
        CryParameterInsertValue(gscryRpt, "", "freference")
        CryParameterInsertValue(gscryRpt, "", "treference")

        CryParameterInsertValue(gscryRpt, "", "myremark")
        CryParameterInsertValue(gscryRpt, DateFormatStandard(GetDateNow), "date_remark")
        CryParameterInsertValue(gscryRpt, "", "amount_label")
        CryParameterInsertValue(gscryRpt, "false", "accrual")
        CryParameterInsertValue(gscryRpt, "", "basis_label")
        CryParameterInsertValue(gscryRpt, "", "name_by")

        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
        frmReportViewer.Text = "Item Valuation Details " & GetDateTimeNowSql()
        If prFind <> "" Then
            '  frmReportViewer.CrystalReportViewer1.Frm
            '  gscryRpt.DataDefinition.FormulaFields(6).Text = prFind
            frmReportViewer.gsSearchRedBox = prFind
        End If

        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()

    End Sub



End Module
