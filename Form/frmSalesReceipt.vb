Imports System.Data.Odbc
Public Class FrmSalesReceipt '

    Dim gsMemberDiscount As Double
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
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
    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub frmSalesReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        ' AccountLabel.Visible = gsShowAccounts
        ' cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm

        fcolumnGrid_U_SalesReceipt(dgvProductItem)
        fclear_Info()

        If IsNew = False Then
            fRefreshInfo(ID)
            fRefreshItem(ID)
            fComputed()
        End If

    End Sub
    Private Sub fRefreshInfo(ByVal prID As String)
        Try
            Dim sQuery As String = "select * from sales_receipt where ID = '" & prID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo(prID)
            Else
                End
            End If
        End Try
    End Sub

    Private Sub fRefreshItem(prID As String)
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
  'S' AS `CONTROL_STATUS`,
  rt.`ID` AS `RATE_TYPE`,
  ii.`UNIT_BASE_QUANTITY`,
  d.`ID` AS `DISCOUNT_ID`,
  ii.`TAXABLE_AMOUNT`,
  ii.`TAX_AMOUNT`,
  ii.`COGS_ACCOUNT_ID`,
  ii.`ASSET_ACCOUNT_ID`,
  ii.`INCOME_ACCOUNT_ID`,
  ii.`PRICE_LEVEL_ID` ,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`POS_TRX_TYPE`,
  ii.`POS_EDIT_QTY`,
  ii.`POS_NOTES`,
  ii.`PRINT_IN_FORMS`,
  ii.`DEPOSITED`,
  i.`TYPE` as `ITEM_TYPE`,
  i.`NON_DISCOUNTED_ITEM`,
  ii.GROUP_LINE_ID,
ii.BATCH_ID,
B.BATCH_NO


FROM

  sales_receipt_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    LEFT OUTER JOIN ITEM_BATCHES AS B
    ON B.ID = II.BATCH_ID
    WHERE  ii.`sales_receipt_ID` = '" & ID & "' Order by ii.LINE_NO, ii.ID"

        Try
            Dim x As Integer = 0
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvProductItem.Columns(i)
                        If CheckNumStandard(.Name) = True Then
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
                fRefreshItem(prID)
            Else
                End
            End If

        End Try




    End Sub
    'Private Function GetTypeValue(ByVal dt As String) As String
    '    If IsNumeric(dt) = True Then
    '        Return Format(dt, "Standard")
    '    Else
    '        Return dt
    '    End If
    'End Function
    Private Sub fclear_Info()
        fComboxRefresh()
        ClearAndRefresh(Me)
        cmbSTATUS.Enabled = False
        cmbSTATUS.SelectedValue = 3
        '  ClearAndRefresh(GroupBox4)


        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        'POSComputed()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_METHOD_ID.SelectedValue = GetPaymentMethodDefault()
        dtpDATE.Value = TransactionDefaultDate()
        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
    End Sub
    Private Sub fComboxRefresh()

        ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        ComboBoxLoad(cmbCLASS_ID, "select * from class", "ID", "NAME")
        ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2'", "ID", "NAME")
        ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        ComboBoxLoad(cmbSTATUS, "SELECT ID,DESCRIPTION FROM document_status_map ", "ID", "DESCRIPTION")
    End Sub
    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If SecurityAccessFind(Me) = False Then
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
        f.AccessibleName = "sales_receipt"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fclear_Info()
                ID = f.AccessibleDescription
                IsNew = False
                fRefreshInfo(ID)
                fRefreshItem(ID)
            End If
        End If


    End Sub
    Private Function fCheckifDiscountNext(ByVal ndex As Integer) As Boolean
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
    Private Sub fComputed()

        Dim gsSalesSubTotal As Double = 0
        fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)

    End Sub

    Private Sub cmbPAYMENT_METHOD_ID_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedValueChanged

        Dim card_no As Boolean = False
        Dim card_value As Boolean = False
        Try



            Dim I As Integer = 0
            If cmbPAYMENT_METHOD_ID.Items.Count <> 0 Then
                I = Val(cmbPAYMENT_METHOD_ID.SelectedValue)
            End If

            Select Case I
                Case 1 'Cash
                    lbslREF_No.Text = "O.R No."
                    card_no = False
                    card_value = False
                Case 2 'Check
                    lbslREF_No.Text = "Check No."
                    card_no = False
                    card_value = False

                Case 3 'Master Card

                    lbslREF_No.Text = "Approval No."
                    card_no = True
                    card_value = True


                Case 4 'Others

                    lbslREF_No.Text = "Approval No."
                    card_no = True
                    card_value = True


                Case 5
                    lbslREF_No.Text = "Approval No."
                    card_no = True
                    card_value = True

                Case Else

            End Select


        Catch ex As Exception
            lbslREF_No.Text = "O.R No."
            card_no = False
            card_value = False
        End Try

        lbslCARD_NO.Visible = card_no
        txtCARD_NO.Visible = card_value

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please  Name")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If
        If cmbPAYMENT_METHOD_ID.Text = "" Then
            MessageBoxInfo("Please select payment method")
            Exit Sub
        End If

        If cmbSTATUS.SelectedValue = 7 Then
            MessageBoxExclamation("Invalid to modify this transaction is void")
            Exit Sub
        End If

        cmbSTATUS.SelectedValue = 3

        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If



        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If



        If IsNew = True Then

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("SALES_RECEIPT", cmbLOCATION_ID.SelectedValue)
            End If

            lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text = gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID
            lblDEPOSITED.Text = "0"
            dtpDATE.Checked = True

            ID = ObjectTypeMapId("SALES_RECEIPT")

            CursorLoadingOn(True)
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO sales_receipt ({SQL_Field},ID,RECORDED_ON,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}','{GetDateTimeNowSql()}') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else

            tChangeAccept = True
            CursorLoadingOn(True)
            SqlExecuted("UPDATE sales_receipt SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "'")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If IsTransactionSuccess(ID, "SALES_RECEIPT") = False Then
            CursorLoadingOn(False)
            MessageBoxWarning("Please try again")
            Exit Sub
        End If

        '======================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(Val(lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 52, ID, dtpDATE.Value, 0, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 52, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 52, ID, dtpDATE.Value, 1, NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If
        End If
        '================================
        SaveSalesReceiptItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)
        SaveNotify(Me, IsNew)

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = tsSaveNew.Name Then
                fSetNew()
            End If
        Catch ex As Exception

        Finally
            If ID > 0 Then
                IsNew = False
                fRefreshInfo(ID)
                fRefreshItem(ID)
            End If
        End Try
        CursorLoadingOn(False)
    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()
        ID = 0
        IsNew = True
        gsMemberDiscount = 0
        cmbSTATUS.SelectedValue = 3

    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Try
            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = TextIsNull(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = TextIsNull(rd("TAX_ACCOUNT_ID"))
            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""
                lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub


    Private Sub fDeleteItem()
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            Try
                fRemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            Catch ex As Exception

            End Try

            fComputed()
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
            If fCheckModify(dgvProductItem, I) = True Then
                Exit Sub
            End If
            Dim d As DataGridViewRow = dgvProductItem.Rows(I)
            If d.Cells("ITEM_TYPE").Value = 5 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 And NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> NumIsNull(d.Cells("ITEM_ID").Value) Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            Dim gsGROUP_ID As Integer = 0
            With frmAddItem
                If NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If

                gsGROUP_ID = NumIsNull(dgvProductItem.Rows.Item(I).Cells("GROUP_LINE_ID").Value)
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value
                .gsDiscount_Rate = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsPRICE_LEVEL_ID = dgvProductItem.Rows.Item(I).Cells("PRICE_LEVEL_ID").Value
                .gsUseItemBatch = True
                .gsBATCH_ID = dgvProductItem.Rows.Item(I).Cells("BATCH_ID").Value
                .dgv = dgvProductItem
                .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
                .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
                .gslblAMOUNT = lblAMOUNT
                .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
                .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
                .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE

            End With

            frmAddItem.ShowDialog()
            With frmAddItem
                If .gsSave = True Then
                    fRow_Data_Item_Sales_Receipt(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, .gsPRICE_LEVEL_ID, False, gsGROUP_ID, .gsBATCH_ID)
                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
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

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvProductItem.Rows.Count <> 0 And IsNew = False Then
                InventoryVDetailsQuickView(dgvProductItem.CurrentRow.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, gsBusinessDateStart, txtCODE.Text)
            End If
        End If
    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False And ID > 0 Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

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


            If MessageBoxQuestion(gsMessageQuestion) = True Then

                CursorLoadingOn(True)

                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    dgvProductItem.Rows(N).Cells("CONTROL_STATUS").Value = "D"
                Next

                SaveSalesReceiptItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

                '======================================
                If gsSkipJournalEntry = False Then

                    fAccount_journal_Delete(Val(lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 52, ID, dtpDATE.Value)
                    If NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        fAccount_journal_Delete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 52, ID, dtpDATE.Value)
                    End If

                End If

                SqlExecuted("DELETE FROM sales_receipt WHERE ID ='" & ID & "' limit 1; ")
                PrompNotify(Me.Text, DeleteMsg, True)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ID = 0
                IsNew = True
                CursorLoadingOn(False)


                If MessageBoxQuestion("Without clear details?") = True Then
                    cmbLOCATION_ID.Enabled = True
                    dtpDATE.Enabled = True
                    For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                        With dgvProductItem.Rows(i)
                            .Cells("CONTROL_STATUS").Value = "A"
                        End With
                    Next
                Else
                    fclear_Info()
                    dgvProductItem.Rows.Clear()
                    fComputed()
                End If
            End If
        End If
    End Sub

    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If

    End Sub

    Private Sub frmSalesReceipt_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged


    End Sub

    Private Sub frmSalesReceipt_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewItemDisplay(dgvProductItem)
        ViewNotSort(dgvProductItem)
    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged

        Application.DoEvents()
        Try
            Dim s As String = cmbCUSTOMER_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
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

            If SecurityAccessPrint(Me) = False Then
                Exit Sub
            End If

            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
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
            fReportParam()
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            GlobalPreviewReport(prPrint_Title & "Report")

        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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
            If SecurityAccessPrint(Me) = False Then
                Exit Sub
            End If
            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
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
            fReportParam()
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)

        End If

    End Sub
    Private Sub fReportParam()
        CryParameterInsertValue(gscryRpt, Val(ID), "myid")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")

    End Sub
    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
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
            Dim getACCOUNT_ID As Integer = 5

            Dim rd As OdbcDataReader = SqlReader($"select ACCOUNT_ID from account_journal where OBJECT_TYPE ='52' and OBJECT_ID ='{ID}' and OBJECT_DATE = '{DateFormatMySql(dtpDATE.Value)}' and ENTRY_TYPE ='0' and LOCATION_ID ='{cmbLOCATION_ID.SelectedValue}' limit 1 ")
            If rd.Read Then
                getACCOUNT_ID = NumIsNull(rd("ACCOUNT_ID"))
            End If
            rd.Close()
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 52, getACCOUNT_ID, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then

                fRefreshInfo(ID)
                fRefreshItem(ID)
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripLabel7_Click(sender As Object, e As EventArgs) Handles ToolStripLabel7.Click

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub cmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
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
            If NumIsNull(rd("TAX_ID")) <> 0 Then

                cmbOUTPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()

    End Sub


    Private Sub cmbCUSTOMER_ID_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbCUSTOMER_ID.KeyDown
        If e.KeyCode = Keys.Insert Then
            Dim StrText As String = Trim(cmbCUSTOMER_ID.Text)
            If cmbCUSTOMER_ID.SelectedIndex = -1 Then
                If StrText.Length = 0 Then Exit Sub
                If IsNew = True Then
                    If SecurityAccessMode(frmCustomer, True) = False Then
                        Exit Sub
                    End If
                    Dim img As Image = Image.FromFile(Application.StartupPath & "/image/sub/customer.png")

                    frmContactDetails.ContactTypeId = 1
                    frmContactDetails.txtNAME.Text = StrText ' must auto insert
                    frmContactDetails.txtCOMPANY_NAME.Text = StrText
                    frmContactDetails.txtPRINT_NAME_AS.Text = StrText
                    frmContactDetails.IsNew = True
                    frmContactDetails.ID = 0
                    frmContactDetails.gsDgv = Nothing
                    frmContactDetails.this_BS = Nothing
                    frmContactDetails.ShowDialog()
                    If frmContactDetails.gsOK = True Then
                        ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                        cmbCUSTOMER_ID.SelectedValue = frmContactDetails.ID
                        cmbCUSTOMER_ID_LostFocus(sender, e)
                    End If
                    frmContactDetails.Dispose()
                    frmContactDetails = Nothing
                End If

            End If
        End If
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If

        With frmAddItem
            .gsUseItemBatch = True
            .sFormName = Me.Name
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE

            If gsMemberDiscount <> 0 Then
                .gsMEMBER = True
                .gsMEMEBER_DISCOUNT = gsMemberDiscount
            End If
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
        fDeleteItem()
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
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

        If IsNew = True Then
            Exit Sub
        End If

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
            fReportParam()
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

    Private Sub frmSalesReceipt_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If IsNew = False Then
            fRefreshInfo(ID)
            fRefreshItem(ID)
            fComputed()
        End If
    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvProductItem, tsFindText.Text)
    End Sub

End Class