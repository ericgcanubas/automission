﻿Imports System.Data.Odbc
Public Class FrmSalesOrder
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim bEntryAddItem As Boolean = False
    Dim f As Form = New FrmFindDocument

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False

    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Function CheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub FrmSalesOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm

        GS_ColumnGrid_U_SalesOrder(dgvProductItem)
        ClearInfo()
        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If

    End Sub
    Private Sub ClearInfo()

        RefreshComboBox()
        ClearAndRefresh(Me)

        '  ClearAndRefresh(GroupBox4)
        cmbCUSTOMER_ID.Enabled = True
        dtpDATE_NEEDED.Checked = False
        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        'POSComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = GetPaymentTermsDefault()
        dtpDATE.Value = TransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
    End Sub
    Private Sub RefreshInfo()



        Try

            Dim sQuery As String = "select * from sales_order where ID = '" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub RefreshItem()
        dgvProductItem.Rows.Clear()
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0

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
  ii.`ESTIMATE_LINE_ID`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`GROUP_LINE_ID`,
i.TYPE as `ITEM_TYPE`,
ii.PRINT_IN_FORMS

FROM

  sales_order_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
   WHERE ii.`SALES_ORDER_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvProductItem.Columns(i)
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = GF_NumIsNull(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                            End If
                        End If
                    End With

                Next

                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        Finally

            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try


    End Sub
    Private Sub RefreshComboBox()
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select * from class order by `NAME`", "ID", "NAME")
        GS_ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2' order by `NAME`", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
    End Sub
    Private Function IsDiscountNext(ByVal ndex As Integer) As Boolean
        Try
            If IsDiscountItem(dgvProductItem.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub Computed()
        Dim gsSalesSubTotal As Double
        GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)

    End Sub

    Private Sub CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        Computed()
        Try

            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = GF_TextIsNull(rd("VAT_METHOD"))
            End If
            rd.Close()
        Catch ex As Exception
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            If MessageBoxErrorYesNo(ex.Message) = True Then
                CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If
        End Try
    End Sub

    Private Sub EditItem()
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
            ElseIf GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With FrmAddItem
                .gsNonInventoryItem = True
                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
                    GS_RowDataItemSalesOrder(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, "", .gsPRICE_LEVEL_ID, False, 0)
                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub DgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
    End Sub
    Private Sub TsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
            Exit Sub
        Else
            If IsNew = False And ID > 0 Then
                If CheckHasChange() = True Then
                    If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        TsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            MessageBoxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If
        End If
        f.AccessibleName = "sales_order"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                ClearInfo()
                ID = f.AccessibleDescription
                IsNew = False


                RefreshInfo()
                RefreshItem()

            End If


        End If


    End Sub

    Private Sub DgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_TaxValue(dgvProductItem)
            Computed()
        End If
    End Sub


    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Customer")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If

        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then


            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GF_GetNextCode("SALES_ORDER", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            ID = ObjectTypeMapId("sales_order")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO sales_order ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',2,'{GetDateTimeNowSql()}') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

            If GF_IsTransactionSuccess(ID, "sales_order") = False Then
                MessageBoxWarning("Please try again")
                Exit Sub
            End If
        Else

            tChangeAccept = True
            SqlExecuted("UPDATE sales_order SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "'")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        SaveItem()
        SaveNotify(Me, IsNew)
        ItemUpdateStatus()

        Try

            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = tsSaveNew.Name Then
                SetNew()
            End If
        Catch ex As Exception

        Finally
            If ID > 0 Then
                IsNew = False
                RefreshInfo()
                RefreshItem()
            End If

        End Try
    End Sub
    Private Sub SetNew()
        ClearInfo()
        dgvProductItem.Rows.Clear()
        Computed()
        ID = 0
        IsNew = True

    End Sub
    Private Sub EstimateItemUpdate(ByVal prITEM_ID As Integer, ByVal prINVOICED_QTY As Double, ByVal ADD_EDIT As Boolean)

        If prITEM_ID <> 0 Then
            Dim get_SO_ID As String = GF_GetStringFieldValue("estimate_items", "ID", prITEM_ID, "estimate_ID")
            If ADD_EDIT = True Then
                SqlExecuted("Update Estimate_items SET `FINAL_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & prITEM_ID & "' Limit 1;")
            Else
                SqlExecuted("Update Estimate_items SET `FINAL_QTY` = NULL,`CLOSED` = '0' where ID = '" & prITEM_ID & "' Limit 1;")
            End If

            SqlExecuted("Update Estimate set `STATUS` = '3'  where ID = '" & get_SO_ID & "' limit 1;")
        End If


    End Sub

    Private Sub SaveItem()

        If dgvProductItem.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE sales_order_items SET TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_ORDER_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;")

                    Case "A"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("sales_order_items")
                        .Cells("ID").Value = i_ID
                        SqlExecuted("INSERT INTO sales_order_items SET GROUP_LINE_ID=" & GotNullNumber((.Cells("GROUP_LINE_ID").Value)) & ", PRINT_IN_FORMS ='" & GF_NumIsNull(.Cells("PRINT_IN_FORMS").Value) & "', LINE_NO='" & i & "',ID='" & .Cells("ID").Value & "',QUANTITY ='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",SALES_ORDER_ID ='" & ID & "',CLOSED ='0',INVOICED_QTY= NULL,PRICE_LEVEL_ID = " & GotNullNumber(GF_NumIsNull(.Cells("PRICE_LEVEL_ID").Value)) & ";")
                        EstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)
                    Case "E"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SqlExecuted("UPDATE sales_order_items SET QUANTITY='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE SALES_ORDER_ID ='" & ID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & " limit 1;")
                        EstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)

                    Case "D"
                        SqlExecuted("DELETE FROM sales_order_items WHERE SALES_ORDER_ID ='" & ID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "' limit 1;")
                        EstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), False)

                End Select

            End With


        Next








    End Sub
    Private Sub ItemUpdateStatus()
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
    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsNew = False And ID > 0 Then
                If CheckHasChange() = True Then
                    If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        TsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            MessageBoxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then

                SqlExecuted("DELETE FROM sales_order_items WHERE SALES_ORDER_ID = '" & ID & "'")

                SqlExecuted("DELETE FROM sales_order WHERE ID = '" & ID & "' limit 1")
                   DeleteNotify(Me)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True

            End If

        End If

    End Sub

    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If
    End Sub



    Private Sub FrmSalesOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GS_ViewItemDisplay(dgvProductItem)
        GS_ViewNotSort(dgvProductItem)
    End Sub

    Private Sub CmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        If bEntryAddItem = True Then
            Exit Sub
        End If

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub
        Dim sql As String = ""

        Try

            sql = "SELECT count(p.`CODE`) as t FROM  estimate AS p   LEFT OUTER JOIN payment_terms AS t  ON t.ID = p.payment_terms_id     INNER JOIN estimate_items AS pt    ON pt.`estimate_ID` = p.`ID` WHERE pt.`CLOSED` = '0'   AND p.Customer_ID = '" & cmbCUSTOMER_ID.SelectedValue & "'   GROUP BY p.`CODE`"

        Catch ex As Exception
            Exit Sub
        End Try

        Try

            Dim rd As OdbcDataReader = SqlReader(sql)

            If rd.Read Then

                If GF_NumIsNull(rd("t")) <> 0 Then

                    bEntryAddItem = True
                    With FrmAvailableItem
                        .gsdgv = dgvProductItem
                        .gsCONTACT_ID = cmbCUSTOMER_ID.SelectedValue
                        .gsType = 2
                        bRefreshItem = True
                        .ShowDialog()
                        GS_DoEvents()
                        cmbCUSTOMER_ID.SelectedValue = .gsCONTACT_ID
                        .Dispose()
                        Computed() ' i forgot
                        bRefreshItem = False


                    End With

                    FrmAvailableItem = Nothing
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                CmbCUSTOMER_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If

        Finally
            bEntryAddItem = False
        End Try
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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
            If SecurityAccessPrint(Me) = False Then
                Exit Sub
            End If
            '   Dim prFile_name As String = "crySalesOrder.rpt"
            ' Dim prPrint_Title As String = "Sales Order"
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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



            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            GlobalPreviewReport(prPrint_Title)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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
            If SecurityAccessPrint(Me) = False Then
                Exit Sub
            End If
            '   Dim prFile_name As String = "crySalesOrder.rpt"
            '  Dim prPrint_Title As String = "Sales Order"
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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


            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If


    End Sub

    Private Sub TsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            SetNew()

        Else
            Dim R As Integer = GF_RefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then
                ClearInfo()
                RefreshInfo()
                RefreshItem()
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub CmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
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
        If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub


    Private Sub CmbCUSTOMER_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCUSTOMER_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbCUSTOMER_ID.Text)
            If cmbCUSTOMER_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If SecurityAccessMode(FrmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/customer.png")

                    FrmContactDetails.ContactTypeId = 1
                    FrmContactDetails.txtNAME.Text = StrText ' must auto insert
                    FrmContactDetails.txtCOMPANY_NAME.Text = StrText
                    FrmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    FrmContactDetails.IsNew = True
                    FrmContactDetails.ID = 0
                    FrmContactDetails.gsDgv = Nothing
                    FrmContactDetails.this_BS = Nothing
                    FrmContactDetails.ShowDialog()
                    If FrmContactDetails.gsOK = True Then
                        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbCUSTOMER_ID.SelectedValue = FrmContactDetails.ID
                        CmbCUSTOMER_ID_LostFocus(sender, e)
                    End If
                    FrmContactDetails.Dispose()
                    FrmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If



        With FrmAddItem
            .gsNonInventoryItem = True
            .sFormName = Me.Name
            .dgv = dgvProductItem
            .ShowDialog()

        End With
        Computed()
        FrmAddItem.Dispose()
        FrmAddItem = Nothing
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        EditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click

        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            GS_RemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            Computed()
        End If

    End Sub

    Private Sub FrmSalesOrder_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If Me.Text = "" Then

        End If
        If IsNew = False Then
            RefreshInfo()
            RefreshItem()
        End If
    End Sub
    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        If IsNew = True Then
            TsSaveNew_Click(sender, e)
        Else
            If CheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    TsSaveNew_Click(sender, e)
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

        frmPrintPage.frmName = Me.Name
        frmPrintPage.ShowDialog()

        Dim v As Integer = frmPrintPage.prValue
        If v = 1 Or v = 2 Then

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False

                GlobalPreviewReport(prPrint_Title & "Report")
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing

    End Sub
End Class