Imports System.Data.Odbc
Module modInventoryItem
    Dim Qty As Double
    Dim Qty_End As Double
    Dim Cost As Double
    Dim Ending_unit_cost As Double
    Dim Ending_cost As Double
    Dim DateStart As Date
    Public Function fItemInventoryReturnValue(ByVal prITEM_ID As String, ByVal prLOCATION_ID As Integer, ByVal prTYPE As Integer, ByVal prID As Double, ByVal prDate As Date, ByVal prField As String) As String
        Dim prReturn As String = ""

        Try
            Dim sQuery As String = ""
            If prID = 0 Then
                sQuery = "select " & prField & " from item_inventory where ITEM_ID  = '" & prITEM_ID & "' and LOCATION_ID = '" & prLOCATION_ID & "' and  SOURCE_REF_DATE <= '" & Format(prDate, "yyyy-MM-dd") & "' order by SOURCE_REF_DATE DESC,ID DESC limit 1"
            Else
                sQuery = "select " & prField & " from item_inventory where ITEM_ID  = '" & prITEM_ID & "' and LOCATION_ID = '" & prLOCATION_ID & "' and SOURCE_REF_TYPE = '" & prTYPE & "' and  SOURCE_REF_ID = '" & prID & "' and SOURCE_REF_DATE = '" & Format(prDate, "yyyy-MM-dd") & "'  limit 1"
            End If
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

    Public Sub fBILL_ITEM_COST_UPDATE_NEW(ByVal prItem_ID As String, ByVal prCOST As Double)
        SqlExecuted("UPDATE item SET COST = '" & prCOST & "' where ID = '" & prItem_ID & "' Limit 1;")
    End Sub


    Private Function fLatestAdjustment(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prSOURCE_REF_ID As Integer, ByVal prSOURCE_REF_TYPE As Integer) As Boolean
        Dim B As Boolean
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.SOURCE_REF_DATE,i.QUANTITY,i.ENDING_QUANTITY,i.COST,i.ENDING_UNIT_COST,i.ENDING_COST FROM item_inventory  AS i WHERE i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' AND i.SOURCE_REF_TYPE ='{prSOURCE_REF_TYPE}' and i.SOURCE_REF_ID = '{prSOURCE_REF_ID}' order by i.ID desc Limit 1 ")
        If rd.Read Then
            DateStart = rd("SOURCE_REF_DATE")
            Qty = NumIsNull(rd("QUANTITY"))
            Qty_End = NumIsNull(rd("ENDING_QUANTITY"))
            Cost = NumIsNull(rd("COST"))
            Ending_unit_cost = NumIsNull(rd("ENDING_UNIT_COST"))
            Ending_cost = NumIsNull(rd("ENDING_COST"))
            B = True
        Else
            Qty = 0
            B = False
        End If
        rd.Close()
        Return B
    End Function

    Public Sub ReCalculateInventory(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal ThisDate As Date)
        CursorLoadingOn(True)
        Dim Qty_END_T As Double = fQTY_ACTUAL_ON_DATE_LOCATION(prITEM_ID, ThisDate, prLOCATION_ID)

        Dim NewSQL As String = ""

        Dim rd As OdbcDataReader = SqlReader($"SELECT i.* FROM item_inventory  AS i WHERE i.SOURCE_REF_DATE >='{ DateFormatMySql(ThisDate) }' and i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' order by i.SOURCE_REF_DATE,i.ID")
        While rd.Read
            If NumIsNull(rd("SOURCE_REF_TYPE")) = 6 Then
                Dim L_QTY As Double = Qty_END_T
                Qty_END_T = NumIsNull(rd("ENDING_QUANTITY"))
                Dim D_QTY As Double = Qty_END_T - L_QTY
                NewSQL = NewSQL & $"UPDATE item_inventory SET QUANTITY='{NumIsNull(D_QTY)}' WHERE ID ='{rd("ID")}' and ITEM_ID = '{prITEM_ID}' and LOCATION_ID ='{prLOCATION_ID}' Limit 1;"
            Else
                Qty_END_T = Qty_END_T + NumIsNull(rd("QUANTITY"))
                NewSQL = NewSQL & $"UPDATE item_inventory SET ENDING_QUANTITY='{NumIsNull(Qty_END_T)}' WHERE ID ='{rd("ID")}' and ITEM_ID = '{prITEM_ID}' and LOCATION_ID ='{prLOCATION_ID}' Limit 1;"
            End If

        End While
        rd.Close()
        If NewSQL <> "" Then
            SqlExecuted(NewSQL)

        End If
        CursorLoadingOn(False)


    End Sub
    Public Sub fDeleteItem_INVENTORY_ITEM_RECALCULATE(ByVal dgv As DataGridView, ByVal LOCATION_ID As Integer, ByVal SOURCE_DATE As Date)

        For I As Integer = 0 To dgv.Rows.Count - 1

            Dim R As DataGridViewRow = dgv.Rows(I)
            Dim ITEM_ID As Integer = R.Cells("ITEM_ID").Value
            ReCalculateInventory(ITEM_ID, LOCATION_ID, SOURCE_DATE.AddDays(-1))

        Next

    End Sub
    Public Sub fINVENTORY_ITEM_RECALCULATE_QTY(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal SOURCE_DATE As Date)
        ReCalculateInventory(ITEM_ID, LOCATION_ID, SOURCE_DATE.AddDays(-1))
    End Sub


    Public Sub fUpdateItemInventory_AccountJournalCost(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal prSOURCE_REF_ID As Integer, ByVal prSOURCE_REF_TYPE As Integer, ByVal prOBJECT_TYPE As Integer)
        If fLatestAdjustment(prITEM_ID, prLOCATION_ID, prSOURCE_REF_ID, prSOURCE_REF_TYPE) = True Then

            Dim Qty_END_T As Double = Qty_End
            Dim COST_T As Double
            '  Dim NewSQL As String = ""
            Dim Cost_UN_END As Double
            Dim Temp_ENDING_COST As Double
            Dim Last_COST As Double = Ending_unit_cost


            Dim rd As OdbcDataReader = SqlReader($"SELECT i.* FROM item_inventory  AS i WHERE i.SOURCE_REF_DATE >='{ DateFormatMySql(DateStart) }' and i.`ITEM_ID` = '{prITEM_ID}' AND i.`LOCATION_ID` = '{prLOCATION_ID}' AND i.SOURCE_REF_TYPE <> '{prSOURCE_REF_TYPE}' order by i.ID")
            While rd.Read
                Qty_END_T = Qty_END_T + NumIsNull(rd("QUANTITY"))
                Cost_UN_END = Ending_unit_cost

                If NumIsNull(rd("QUANTITY")) <= 0 Then
                    COST_T = 0
                    Temp_ENDING_COST = Last_COST * Qty_END_T
                Else
                    Last_COST = Cost_UN_END
                    Temp_ENDING_COST = Qty_END_T * Last_COST
                    COST_T = Qty_END_T * Last_COST
                End If

                SqlExecuted($"UPDATE item_inventory SET ENDING_QUANTITY='{NumIsNull(Qty_END_T)}',COST={GotNullNumber(COST_T)},ENDING_COST={GotNullNumber(Temp_ENDING_COST)},ENDING_UNIT_COST={GotNullNumber(Cost_UN_END)} WHERE ID ='{rd("ID")}' and ITEM_ID = '{prITEM_ID}' and LOCATION_ID ='{prLOCATION_ID}' Limit 1;")

            End While
            rd.Close()

            Dim item_rd As OdbcDataReader = SqlReader($"Select COGS_ACCOUNT_ID,ASSET_ACCOUNT_ID from item Where ID = '{prITEM_ID}'  Limit 1")
            If item_rd.Read Then
                fCostUpdateJournal(item_rd("COGS_ACCOUNT_ID"), prITEM_ID, prLOCATION_ID, Ending_unit_cost, DateStart, prOBJECT_TYPE)
                fCostUpdateJournal(item_rd("ASSET_ACCOUNT_ID"), prITEM_ID, prLOCATION_ID, Ending_unit_cost, DateStart, prOBJECT_TYPE)
            End If
            item_rd.Close()
        End If


    End Sub

    Private Sub fCostUpdateJournal(ByVal ACCOUNT_ID As Integer, ByVal ITEM_SUBSI As Integer, ByVal LOCATION_ID As Integer, ByVal ThisCost As Double, ByVal ThisDate As Date, ByVal prOBJECT_TYPE As Integer)
        Dim Tmp_SQL As String = ""
        Dim T_Balance As Double = fGET_ENDING_BALANCE(ACCOUNT_ID, ITEM_SUBSI, LOCATION_ID, ThisDate)
        Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM account_journal WHERE OBJECT_TYPE <> '{prOBJECT_TYPE}' and SUBSIDIARY_ID = '{ITEM_SUBSI}' AND location_id ='{LOCATION_ID}' AND account_id = '{ACCOUNT_ID}' and OBJECT_DATE >='{DateFormatMySql(ThisDate)}' ORDER BY OBJECT_DATE,ID")
        While rd.Read

            Dim SQL_ITEM As String
            If 20 = NumIsNull(rd("OBJECT_TYPE")) Then

                SQL_ITEM = $"SELECT ENDING_QUANTITY as QUANTITY FROM ITEM_INVENTORY WHERE SOURCE_REF_TYPE ='6' and  SOURCE_REF_ID='{rd("OBJECT_ID")}'  and ITEM_ID ='{ITEM_SUBSI}' and SOURCE_REF_DATE = '{rd("OBJECT_DATE")}' Limit 1; "

            Else
                SQL_ITEM = $"SELECT QUANTITY FROM {GetStringFieldValue("OBJECT_TYPE_MAP", "ID", rd("OBJECT_TYPE"), "TABLE_NAME")} WHERE ID='{rd("OBJECT_ID")}'  and ITEM_ID ='{ITEM_SUBSI}' Limit 1; "

            End If

            Dim rd_item As OdbcDataReader = SqlReader(SQL_ITEM)
            If rd_item.Read Then
                If NumIsNull(rd("ENTRY_TYPE")) = 0 Then
                    T_Balance = T_Balance + (ThisCost * NumIsNull(rd_item("QUANTITY")))
                Else
                    T_Balance = T_Balance - (ThisCost * NumIsNull(rd_item("QUANTITY")))
                End If

                Tmp_SQL = Tmp_SQL & $"UPDATE account_journal SET AMOUNT = '{(ThisCost * NumIsNull(rd_item("QUANTITY")))}', ENDING_BALANCE ='{T_Balance}' WHERE ID ='{rd("ID")}' and SUBSIDIARY_ID = '{ITEM_SUBSI}' AND location_id ='{LOCATION_ID}' AND account_id = '{ACCOUNT_ID}' Limit 1;"
            End If
            rd_item.Close()
        End While
        rd.Close()

        If Tmp_SQL <> "" Then
            SqlExecuted(Tmp_SQL)
        End If
    End Sub
    Private Function fGET_ENDING_BALANCE(ByVal ACCOUNT_ID As Integer, ByVal ITEM_SUBSI As Integer, ByVal LOCATION_ID As Integer, ByVal ThisDate As Date) As Double
        Dim ThisBalance As Double
        Dim rd As OdbcDataReader = SqlReader($"SELECT ENDING_BALANCE FROM account_journal WHERE SUBSIDIARY_ID = '{ITEM_SUBSI}' AND location_id ='{LOCATION_ID}' AND account_id = '{ACCOUNT_ID}' and OBJECT_DATE < '{DateFormatMySql(ThisDate)}' ORDER BY OBJECT_DATE DESC,ID DESC LIMIT 1")
        If rd.Read Then
            ThisBalance = NumIsNull(rd("ENDING_BALANCE"))
        End If
        rd.Close()
        Return ThisBalance
    End Function
    Public Sub InventoryVDetailsQuickView(ByVal prITEM_ID As Integer, ByVal prLOCATION_ID As Integer, ByVal dtSTART As Date, ByVal prFind As String)

        If UserSecurtySystemDOCShow("Item Valuation Details") = False Then

            If fAccessDeniedIsYes("You are not allowed access to Item Valuation Details or perform the request function operation. For more information, contact the BMS administrator ") = True Then
                Exit Sub
            End If

        End If

        Dim prFile_name As String = "cryItemValuationDetails.rpt"
        Dim prPrint_Title As String = "Item Valuation"
        gsToolPanelView = False
        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, DateFormatMySql(dtSTART), "fdate")
        fCryParameterInsertValue(gscryRpt, GetDateNow, "tdate")
        fCryParameterInsertValue(gscryRpt, "*", "customerid")
        fCryParameterInsertValue(gscryRpt, prLOCATION_ID, "locationid")
        fCryParameterInsertValue(gscryRpt, "*", "statusid")
        fCryParameterInsertValue(gscryRpt, "*", "doctype")
        fCryParameterInsertValue(gscryRpt, "*", "salesrepid")
        fCryParameterInsertValue(gscryRpt, "*", "customergroupid")
        fCryParameterInsertValue(gscryRpt, prITEM_ID, "item_code_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_group_id")
        fCryParameterInsertValue(gscryRpt, "", "freference")
        fCryParameterInsertValue(gscryRpt, "", "treference")

        fCryParameterInsertValue(gscryRpt, "", "myremark")
        fCryParameterInsertValue(gscryRpt, DateFormatStandard(GetDateNow), "date_remark")
        fCryParameterInsertValue(gscryRpt, "", "amount_label")
        fCryParameterInsertValue(gscryRpt, "false", "accrual")
        fCryParameterInsertValue(gscryRpt, "", "basis_label")
        fCryParameterInsertValue(gscryRpt, "", "name_by")

        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
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
