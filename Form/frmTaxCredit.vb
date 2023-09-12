Imports System.Data.Odbc
Public Class FrmTaxCredit
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvInvoice, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub frmWithHoldingTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm
        ComboBoxLoad(cmbEWT_ID, "select * from tax where tax_type='2' order by ID", "ID", "NAME")
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "  "
        chk.Name = "SELECTED"
        With dgvInvoice.Columns
            .Add("INVOICE_ID", "INVOICE_ID")
            .Item("INVOICE_ID").Visible = False

            .Add(chk)
            .Item("SELECTED").Width = 60

            .Add("DATE", gsCUSTOM_DATE)
            .Item("DATE").Width = 170

            .Add("NUMBER", gsCUSTOM_NUMBER)
            .Item("NUMBER").Width = 220

            .Add("ORG_AMOUNT", gsCUSTOM_ORG_AMOUNT)
            .Item("ORG_AMOUNT").Width = 170
            .Item("ORG_AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("ORG_AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("ORG_AMOUNT").DefaultCellStyle.Format = "N2"

            .Add("Taxable_Amount", gsCUSTOM_TAXABLE_AMOUNT)
            .Item("Taxable_Amount").Width = 170
            .Item("Taxable_Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Taxable_Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Taxable_Amount").DefaultCellStyle.Format = "N2"

            .Add("BALANCE_DUE", gsCUSTOM_BALANCE_DUE)
            .Item("BALANCE_DUE").Width = 170
            .Item("BALANCE_DUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("BALANCE_DUE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("BALANCE_DUE").DefaultCellStyle.Format = "N2"

            .Add("Amt_WithHold", gsCUSTOM_AMT_TAX_CREDIT)
            .Item("Amt_WithHold").Width = 170
            .Item("Amt_WithHold").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amt_WithHold").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amt_WithHold").DefaultCellStyle.Format = "N2"

            .Add("ACCOUNTS_RECEIVABLE_ID", "ACCOUNTS_RECEIVABLE_ID")
            .Item("ACCOUNTS_RECEIVABLE_ID").Visible = False

        End With
        fClear_Info()
        cmbEWT_ID_SelectedIndexChanged(sender, e)

        If IsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub fColumnRefresh()


    End Sub
    Private Sub fComboBoxRefresh()
        ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")

        ComboBoxLoad(cmbCUSTOMER_ID, "select ID,NAME from contact where type='1'", "ID", "NAME")

    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub
    Private Sub fClear_Info()
        fComboBoxRefresh()
        ClearAndRefresh(Me)


        dgvInvoice.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID
    End Sub

    Private Sub cmbEWT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEWT_ID.SelectedIndexChanged


        Try

            Dim rd As OdbcDataReader = SqlReader("select RATE,TAX_ACCOUNT_ID from TAX where ID ='" & NumIsNull(cmbEWT_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblEWT_RATE.Text = NumIsNull(rd("RATE"))
                lblEWT_ACCOUNT_ID.Text = NumIsNull(rd("TAX_ACCOUNT_ID"))
            Else
                lblEWT_RATE.Text = ""
                lblEWT_ACCOUNT_ID.Text = ""
            End If
            rd.Close()

        Catch ex As Exception

            lblEWT_RATE.Text = ""
            lblEWT_ACCOUNT_ID.Text = ""
        End Try
        fCheckBill()

    End Sub

    Private Sub cmbWITHHELD_FROM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        Try
            fCustomer_Invoice(cmbCUSTOMER_ID.SelectedValue)
            fCheckBill()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub fAdditem(ByVal prID As String, ByVal prSelect As Boolean, ByVal prDate As Date, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prTaxable_Amount As Double, ByVal prBalance_due As Double, ByVal prTax_Paid As Double, ByVal prACCOUNTS_RECEIVABLE_ID As Integer)
        dgvInvoice.Rows.Add(prID, prSelect, Format(prDate, "MM/dd/yyyy"), prCode, NumberFormatStandard(prOrg_Amount), NumberFormatStandard(prTaxable_Amount), NumberFormatStandard(prBalance_due), NumberFormatStandard(prTax_Paid), prACCOUNTS_RECEIVABLE_ID)
    End Sub
    Private Sub fCustomer_Invoice(ByVal prPAY_ID As String)
        dgvInvoice.Rows.Clear()
        ' Dim cn As New MySqlConnection(mysqlConstr)
        dtpDATE.Checked = True
        Try

            '   cn.Open()
            Dim rd As OdbcDataReader = SqlReader("SELECT B.`ID` as `INVOICE_ID`,B.`DATE`,B.`CODE`,B.`AMOUNT`,B.`BALANCE_DUE`,   B.`TAXABLE_AMOUNT`,B.ACCOUNTS_RECEIVABLE_ID FROM Invoice AS B Where B.`Customer_ID` = '" & prPAY_ID & "' and B.LOCATION_ID ='" & NumIsNull(cmbLOCATION_ID.SelectedValue) & "'  GROUP BY B.`ID`,B.`DATE`,B.`CODE`,B.`AMOUNT`,B.`BALANCE_DUE`, B.`TAXABLE_AMOUNT`")

            While rd.Read
                Dim INVOICE_ID As Integer = rd("INVOICE_ID")
                Dim dTax As Double = fInvoiceSumTaxApplied_Amount(INVOICE_ID, prPAY_ID)
                Dim Taxable_Amount As Double = NumIsNull(rd("TAXABLE_AMOUNT"))

                dTax = fGetAppliedCreditTax(INVOICE_ID, ID)

                Dim dBalance As Double = NumIsNull(rd("BALANCE_DUE")) + dTax

                Dim bSelected As Boolean = False
                If dTax <> 0 Then
                    bSelected = True
                End If
                'Open New Item Transaction
                If dBalance <> 0 Then
                    fAdditem(INVOICE_ID, bSelected, rd("Date"), rd("CODE"), NumIsNull(rd("AMOUNT")), Taxable_Amount, dBalance, dTax, NumIsNull(rd("ACCOUNTS_RECEIVABLE_ID")))
                End If
            End While
            rd.Close()

            fCheckBill()

        Catch ex As Exception
            fCustomer_Invoice(prPAY_ID)

        End Try




    End Sub
    Private Sub fCheckBill()
        Dim bNotSelected As Boolean = True

        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
            If dgvInvoice.Rows(i).Cells(1).Value = True Then
                bNotSelected = False
                Exit For
            End If
        Next

        cmbCUSTOMER_ID.Enabled = IsNew



        Dim dPayment As Double = 0

        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
            If dgvInvoice.Rows(i).Cells(1).Value = True Then
                fAutoCompute(i)
                dPayment = dPayment + NumberFormatFixed(dgvInvoice.Rows(i).Cells(7).Value)
            End If
        Next


        lblAMOUNT.Text = NumberFormatStandard(dPayment)

    End Sub

    Private Sub fRefreshInfo()


        Dim sQuery As String = "select * from `TAX_CREDIT` where id ='" & ID & "' "
        Try

            SqlExecutedUsingReading(Me, sQuery)


            fCheckBill()

            tdgv = New DataGridView
            tdgv = dgvInvoice
            tQuery = SqlUpdate(Me)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo()
            Else
                End
            End If
        End Try


    End Sub
    Private Function fGetAppliedCreditTax(ByVal prInvoice_ID As String, ByVal prTAX_CREDIT_ID As String) As Double
        Dim v As Double = 0
        Try
            Dim sQuery As String = "Select AMOUNT_WITHHELD AS A from `TAX_CREDIT_invoices` where TAX_CREDIT_ID = '" & prTAX_CREDIT_ID & "' and Invoice_id = '" & prInvoice_ID & "' Limit 1"
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                v = NumIsNull(rd("A"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                v = fGetAppliedCreditTax(prInvoice_ID, prTAX_CREDIT_ID)
            Else
                End
            End If
        End Try
        Return v
    End Function

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


        f.AccessibleName = "tax_credit"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                ID = f.AccessibleDescription
                IsNew = False
                ''
                fClear_Info()
                If IsNew = False Then

                    fRefreshInfo()

                End If
            End If

        End If


    End Sub


    Private Sub dgvBill_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellClick
        If e.ColumnIndex = 1 Then

            If dgvInvoice.Rows.Count = 0 Then
                Exit Sub
            End If

            With dgvInvoice.Rows(e.RowIndex)

                Dim b As Boolean = .Cells(1).Value

                If b = True Then
                    b = False
                Else
                    b = True
                End If

                fEdititem(b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, 0)
            End With

            fCheckBill()
        End If
    End Sub
    Private Sub fEdititem(ByVal prSelect As Boolean, ByVal prDate As String, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prTaxable_Amount As Double, ByVal prBalance_due As String, ByVal prPayment As Double)
        If dgvInvoice.Rows.Count <> 0 Then
            Dim i As Integer = dgvInvoice.CurrentRow.Index
            With dgvInvoice.Rows(i)

                .Cells(1).Value = prSelect
                .Cells(2).Value = prDate
                .Cells(3).Value = prCode
                .Cells(4).Value = Format(prOrg_Amount, "STANDARD")
                .Cells(5).Value = Format(prTaxable_Amount, "STANDARD")
                .Cells(6).Value = Format(prBalance_due, "STANDARD")
                .Cells(7).Value = Format(prPayment, "STANDARD")

            End With
        End If
    End Sub

    Private Sub fAutoCompute(ByVal i As Integer)
        If dgvInvoice.Rows.Count <> 0 Then

            With dgvInvoice.Rows(i)


                Dim t_amiount As Double = NumberFormatFixed(.Cells(5).Value) * NumberFormatFixed((Val(lblEWT_RATE.Text) / 100))

                Dim t_balance As Double = NumberFormatFixed(.Cells(6).Value)
                If t_balance < t_amiount Then

                    .Cells(7).Value = NumberFormatStandard(t_balance)

                Else
                    .Cells(7).Value = NumberFormatStandard(t_amiount)
                End If


            End With
        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click


        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Select Customer")
            Exit Sub
        End If


        If dgvInvoice.Rows.Count = 0 Then
            MessageBoxInfo("Invoice not found!")
            Exit Sub
        End If

        If SecurityAccessMode(Me, IsNew) = False Then
            Exit Sub
        End If

        Dim bValue_is_checked As Boolean = False
        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
            If dgvInvoice.Rows(i).Cells(1).Value = True Then
                bValue_is_checked = True
                Exit For
            End If
        Next

        If bValue_is_checked = False Then
            MessageBoxWarning("Amount not applied. please select bills.")
            Exit Sub
        End If

        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("TAX_CREDIT", cmbLOCATION_ID.SelectedValue)
            End If

            ID = ObjectTypeMapId("TAX_CREDIT")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO tax_credit ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',15,'{GetDateTimeNowSql()}') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            tChangeAccept = True
            SqlExecuted("UPDATE `tax_credit` SET " & SqlUpdate(Me) & " WHERE ID ='" & ID & "' ")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If IsTransactionSuccess(ID, "TAX_CREDIT") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(Val(lblEWT_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 72, ID, dtpDATE.Value, 0, NumberFormatFixed(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
        End If
        '================================

        fSaveItem()

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
                fRefreshInfo()

            End If
        End Try

    End Sub
    Private Sub fSetNew()
        fClear_Info()
        IsNew = True
        ID = 0
        fCheckBill()

    End Sub
    Private Sub fSaveItem()
        For i As Integer = 0 To dgvInvoice.Rows.Count - 1

            With dgvInvoice.Rows(i)
                If .Cells(1).Value = True Then
                    Dim GET_ID As Integer = 0
                    If fChecK_TAX_CREDIT(.Cells(0).Value, ID, GET_ID) = True Then

                        SqlExecuted("UPDATE `tax_credit_invoices` SET AMOUNT_WITHHELD = " & GotNullNumber(.Cells(7).Value) & ",ACCOUNTS_RECEIVABLE_ID='" & .Cells("ACCOUNTS_RECEIVABLE_ID").Value & "' WHERE ID ='" & GET_ID & "'  TAX_CREDIT_ID='" & ID & "' and INVOICE_ID ='" & .Cells("INVOICE_ID").Value & "' limit 1;")
                        fUpdateInvoiceBalance(.Cells(0).Value, cmbCUSTOMER_ID.SelectedValue)
                    Else
                        GET_ID = ObjectTypeMapId("TAX_CREDIT_invoices")
                        SqlExecuted("INSERT INTO `tax_credit_invoices` SET ID='" & GET_ID & "',TAX_CREDIT_ID='" & ID & "',INVOICE_ID='" & .Cells("INVOICE_ID").Value & "', AMOUNT_WITHHELD = " & GotNullNumber(.Cells(7).Value) & ",ACCOUNTS_RECEIVABLE_ID='" & .Cells("ACCOUNTS_RECEIVABLE_ID").Value & "'")
                        fUpdateInvoiceBalance(.Cells(0).Value, cmbCUSTOMER_ID.SelectedValue)
                    End If

                    '==============================================
                    If gsSkipJournalEntry = False Then
                        fAccount_Journal_SQL(.Cells("ACCOUNTS_RECEIVABLE_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("INVOICE_ID").Value, 73, GET_ID, dtpDATE.Value, 1, NumIsNull(.Cells("AMT_WITHHOLDAMT").Value), gsJOURNAL_NO_FORM)
                    End If
                    '===============================================
                Else
                    Dim GET_ID As Integer = 0
                    If fChecK_TAX_CREDIT(.Cells("INVOICE_ID").Value, ID, GET_ID) = True Then

                        If gsSkipJournalEntry = False Then
                            fJournalAccountRemoveFixed_Account_ID(.Cells("ACCOUNTS_RECEIVABLE_ID").Value, 73, GET_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, .Cells("INVOICE_ID").Value)
                        End If

                        SqlExecuted("DELETE  FROM `tax_credit_invoices` WHERE ID = '" & GET_ID & "' and TAX_CREDIT_ID = '" & ID & "' and INVOICE_ID ='" & .Cells("INVOICE_ID").Value & "' limit 1;")
                        fUpdateInvoiceBalance(.Cells("INVOICE_ID").Value, cmbCUSTOMER_ID.SelectedValue)
                    End If
                End If

            End With
        Next

    End Sub
    Private Function fChecK_TAX_CREDIT(ByVal prinvoice_ID As String, ByVal prTAX_CREDIT_ID As String, ByRef GET_ID As Integer) As Boolean
        Dim gsUpdate As Boolean = False

        Try

            Dim rd As OdbcDataReader = SqlReader("select ID from `tax_credit_invoices` where invoice_id = '" & prinvoice_ID & "' and TAX_CREDIT_id = '" & prTAX_CREDIT_ID & "' limit 1")
            If rd.Read Then
                GET_ID = rd("ID")
                gsUpdate = True
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                gsUpdate = fChecK_TAX_CREDIT(prinvoice_ID, prTAX_CREDIT_ID, GET_ID)
            Else
                End
            End If
        End Try
        Return gsUpdate
    End Function
    Private Sub fUpdateInvoiceBalance(ByVal prInvoice_Id As String, ByVal prCustomer_ID As String)
        'ok kol

        Dim dTotal_Payment As Double = fGetSumPaymentApplied(prInvoice_Id, prCustomer_ID) + fGetSumCreditApplied(prInvoice_Id, prCustomer_ID) + fInvoiceSumTaxApplied_Amount(prInvoice_Id, prCustomer_ID)
        Dim dTotal_Amount As Double = GetNumberFieldValue("INVOICE", "ID", prInvoice_Id, "AMOUNT")
        Dim dTotal_Balance As Double = dTotal_Amount - dTotal_Payment
        Dim nStatus As Integer = 0

        If 0 >= dTotal_Balance Then
            'Paid
            nStatus = 11
        Else
            'Not Paid
            nStatus = 2
        End If

        SqlExecuted("UPDATE invoice SET BALANCE_DUE ='" & NumberFormatFixed(dTotal_Balance) & "',STATUS='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "' WHERE Customer_ID ='" & prCustomer_ID & "' and ID ='" & prInvoice_Id & "' ")
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)
                ' fJournalTransaction_Tax_Credit_Delete(ID)
                For i As Integer = 0 To dgvInvoice.Rows.Count - 1
                    With dgvInvoice.Rows(i)
                        Dim GET_ID As Integer = 0
                        If fChecK_TAX_CREDIT(.Cells(0).Value, ID, GET_ID) = True Then
                            If gsSkipJournalEntry = False Then
                                fJournalAccountRemoveFixed_Account_ID(.Cells("ACCOUNTS_RECEIVABLE_ID").Value, 73, GET_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, .Cells("INVOICE_ID").Value)
                            End If

                            SqlExecuted("DELETE  FROM `tax_credit_invoices` WHERE ID='" & GET_ID & "' and TAX_CREDIT_ID = '" & ID & "' and INVOICE_ID ='" & .Cells(0).Value & "'")
                            fUpdateInvoiceBalance(.Cells(0).Value, cmbCUSTOMER_ID.SelectedValue)
                        End If
                    End With
                Next
                If gsSkipJournalEntry = False Then
                    fJournalAccountRemoveFixed_Account_ID(Val(lblEWT_ACCOUNT_ID.Text), 72, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
                End If
                SqlExecuted("DELETE FROM `tax_credit` WHERE ID = '" & ID & "' limit 1;")
                DeleteNotify(Me)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fClear_Info()
                IsNew = True
                ID = 0
                CursorLoadingOn(False)
            End If

        End If


    End Sub

    Private Sub frmTaxCredit_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmTaxCredit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvInvoice.Columns("SELECTED").Width = 30
        ViewNotSort(dgvInvoice)
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
            Dim prFile_name As String = "cryTaxCredit.rpt"
            Dim prPrint_Title As String = "Tax Credit "

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
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

            Dim prFile_name As String = "cryTaxCredit.rpt"
            Dim prPrint_Title As String = "Tax Credit "

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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 72, lblEWT_ACCOUNT_ID.Text, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
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

                fRefreshInfo()
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub



    Private Sub frmTaxCredit_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub dgvInvoice_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick

    End Sub

    Private Sub dgvInvoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellDoubleClick

        If dgvInvoice.Rows.Count = 0 Then Exit Sub
        If MessageBoxQuestion($"Do you want to open this Invoice no. {dgvInvoice.CurrentRow.Cells("NUMBER").Value }?") = False Then Exit Sub

        gsMenuSubID = 2
        gsRefresh = True
        gsDocument_Finder_ID = dgvInvoice.Rows(e.RowIndex).Cells("INVOICE_ID").Value

        Dim rd As OdbcDataReader = SqlReader($"select * from `tblsub_menu` where sub_id = '{gsMenuSubID}' limit 1")
        Dim i As Integer = 0
        Dim F As Form = Nothing
        Dim Img As Image = Nothing
        If rd.Read Then
            i = NumIsNull(rd("sub_id"))
            F = GetFormModule(rd("Form"))
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            Img = Image.FromFile(folder & rd("image_file"))
            gsSubMenuForm = rd("description")
            F.Text = rd("description")
            F.Tag = i
        End If

        For n As Integer = 0 To frmMainMenu.MyTab.TabPages.Count - 1
            Dim Frm As Form = frmMainMenu.MyTab.TabPages.Item(n).Form
            If Frm.Text = F.Text Then
                Frm.Close()
                Exit For
            End If
        Next
        gsMenuSubID = i
        gsRefresh = True

        TabFormOpen(F, frmMainMenu.MyTab, Img)
        F.TabIndex = gsDocument_Finder_ID
        gsDocument_Finder_ID = 0
    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvInvoice, tsFindText.Text)
    End Sub

    Private Sub cmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        If cmbLOCATION_ID.Items.Count <> 0 Then
            cmbWITHHELD_FROM_ID_SelectedIndexChanged(sender, e)
        End If

    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ToolStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip1.ItemClicked

    End Sub
End Class