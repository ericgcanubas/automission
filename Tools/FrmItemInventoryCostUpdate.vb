Imports System.Data.Odbc
Public Class FrmItemInventoryCostUpdate
    Dim Last_COST As Double
    Private Sub FrmItemInventoryCostUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbLOCATION_ID, "SELECT `id`,`name` FROM location UNION SELECT '%' AS `id`,'All Location' AS `NAME`  ORDER BY `ID`", "ID", "NAME")
        fComboBox(cmbITEM, "select ID,DESCRIPTION from item Where inactive = '0' and type ='0' order by DESCRIPTION", "ID", "DESCRIPTION")
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        fControl(False)
        If chkUseSelectItem.Checked = True Then
            Dim rd As OdbcDataReader = fReader($"select ID,COST,COGS_ACCOUNT_ID,ASSET_ACCOUNT_ID from item Where inactive = '0' and type ='0' and ID = '{cmbITEM.SelectedValue}'  limit 1;")
            If rd.Read Then
                fDoEvents()
                fInventoryRead(rd("ID"), fNumisNULL(rd("COST")), fNumisNULL(rd("COGS_ACCOUNT_ID")), fNumisNULL(rd("ASSET_ACCOUNT_ID")))
                fMessageboxInfo("Update Complete.")

            Else
                fMessageboxInfo("Item Not found.")
            End If
            rd.Close()

        Else

            PBItemList.Minimum = 0
            PBItemList.Value = 0

            Dim TotalRow As Integer


            Dim rd As OdbcDataReader = fReaderCounting("select ID,COST,COGS_ACCOUNT_ID,ASSET_ACCOUNT_ID from item Where inactive = '0' and type ='0' ", TotalRow)
            While rd.Read

                PBItemList.Maximum = TotalRow
                PBItemList.Value = PBItemList.Value + 1
                lblItemList.Text = "Item List :" & PBItemList.Value & "/" & PBItemList.Maximum
                fDoEvents()
                fInventoryRead(rd("ID"), fNumisNULL(rd("COST")), fNumisNULL(rd("COGS_ACCOUNT_ID")), fNumisNULL(rd("ASSET_ACCOUNT_ID")))
            End While
            fMessageboxInfo("Update Complete.")
        End If

        fControl(True)
    End Sub
    Private Sub fInventoryRead(ByVal prItem_ID As Integer, ByVal COST As Double, ByVal COGS_ACCOUNT_ID As Integer, ByVal ASSET_ACCOUNT_ID As Integer)
        Dim TotalRow As Integer
        PBInventory.Minimum = 0
        PBInventory.Value = 0
        Dim d_COST As Double = 0
        Dim h_COST As Double = 0

        Dim SQL_LIST As String
        If dtpDateStart.Checked = False Then
            SQL_LIST = $"select ID,SOURCE_REF_TYPE,SOURCE_REF_ID,SOURCE_REF_DATE,QUANTITY,COST,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST,LOCATION_ID from item_inventory where item_id = '{prItem_ID}' and LOCATION_ID ='{cmbLOCATION_ID.SelectedValue}' order by SOURCE_REF_DATE,ID "
        Else
            SQL_LIST = $"select ID,SOURCE_REF_TYPE,SOURCE_REF_ID,SOURCE_REF_DATE,QUANTITY,COST,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST,LOCATION_ID from item_inventory where SOURCE_REF_DATE >='{fDateFormatMYSQL(dtpDateStart.Value)}' and item_id = '{prItem_ID}' and LOCATION_ID ='{cmbLOCATION_ID.SelectedValue}' order by SOURCE_REF_DATE,ID "
        End If

        Dim rd As OdbcDataReader = fReaderCounting(SQL_LIST, TotalRow)
        While rd.Read
            PBInventory.Maximum = TotalRow
            PBInventory.Value = PBInventory.Value + 1
            lblInventory.Text = "Inventory :" & PBInventory.Value & "/" & PBInventory.Maximum
            fDoEvents()
            h_COST = fNumisNULL(rd("ENDING_UNIT_COST"))
            If chkBaseOnItemCost.Checked = False Then
                If COST = h_COST Then

                    d_COST = COST
                    Last_COST = d_COST

                ElseIf h_COST = 0 Then
                    d_COST = COST
                    Last_COST = d_COST
                Else
                    If COST < h_COST Then
                        'malaki is item
                        If fMessageBoxQuestion($"N:{COST} < O:{h_COST}. Do you want to Use this NEW cost?") = True Then
                            d_COST = COST
                            Last_COST = d_COST
                        Else

                            d_COST = h_COST
                            Last_COST = d_COST
                        End If
                    Else
                        'malaki is inventory

                        If COST > h_COST Then
                            If fMessageBoxQuestion($"N:{COST} > O:{h_COST}. Do you want to Use this OLD cost?") = True Then
                                d_COST = h_COST
                                Last_COST = d_COST
                            Else
                                d_COST = COST
                                Last_COST = d_COST
                            End If
                        Else
                            fMessageboxInfo("sssss")
                        End If

                    End If

                End If
            Else
                d_COST = COST
            End If
            Dim Qty As Integer = rd("QUANTITY")
            fJournal(COGS_ACCOUNT_ID, d_COST * IIf(Qty < 0, Qty * -1, Qty), fDateFormatMYSQL(rd("SOURCE_REF_DATE")), rd("SOURCE_REF_ID"), rd("LOCATION_ID"), rd("SOURCE_REF_TYPE"), prItem_ID)
            fDoEvents()
            fJournal(ASSET_ACCOUNT_ID, d_COST * IIf(Qty < 0, Qty * -1, Qty), fDateFormatMYSQL(rd("SOURCE_REF_DATE")), rd("SOURCE_REF_ID"), rd("LOCATION_ID"), rd("SOURCE_REF_TYPE"), prItem_ID)
            fDoEvents()
            fExecutedOnly($"UPDATE item_inventory SET  COST={fGotNullNumber(IIf(Qty < 0, 0, d_COST))},ENDING_UNIT_COST = '{d_COST}',ENDING_COST='{ fNumisNULL(rd("ENDING_QUANTITY")) * d_COST}' where id = '{rd("ID")}' limit 1;")

        End While


    End Sub
    Private Sub fJournal(ByVal ACCOUNT_ID As Integer, ByVal AMOUNT As Double, ByVal OBJECT_DATE As String, ByVal OBJECT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal DOC_TYPE As Integer, ByVal SUBSIDIARY_ID As Integer)
        Dim RowCount As Integer
        Dim rd As OdbcDataReader = fReaderCounting($"select ID from account_journal Where ACCOUNT_ID ='{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' and OBJECT_DATE = '{OBJECT_DATE}' and OBJECT_ID = '{OBJECT_ID}' and  OBJECT_TYPE ='{ThisObjectID(DOC_TYPE)}' and SUBSIDIARY_ID = '{SUBSIDIARY_ID}' ", RowCount)
        While rd.Read
            If RowCount = 1 Then
                fExecutedOnly($"UPDATE account_journal SET AMOUNT = '{AMOUNT}' WHERE ID ='{rd("ID")}' Limit 1;")
            Else
                fMessageBoxQuestion(rd("ID"))
            End If
        End While

        rd.Close()
    End Sub
    Private Function ThisObjectID(ByVal DOC_TYPE As Integer) As Integer
        Dim This_ID As Integer = 0
        Dim rd As OdbcDataReader = fReader($"select ID from object_type_map Where DOCUMENT_TYPE = '{DOC_TYPE}' and IS_DOCUMENT  = '0' order by ID limit 1;")
        If rd.Read Then
            This_ID = rd("ID")

        End If
        rd.Close()
        Return This_ID
    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub chkUseSelectItem_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseSelectItem.CheckedChanged
        cmbITEM.Enabled = chkUseSelectItem.Checked


    End Sub


    Private Sub fControl(ByVal E As Boolean)

        chkBaseOnItemCost.Enabled = E
        chkUseSelectItem.Enabled = E
        cmbITEM.Enabled = E
        cmbLOCATION_ID.Enabled = E
        btnCancel.Enabled = E
        btnStart.Enabled = E
        dtpDateStart.Enabled = E

    End Sub
End Class