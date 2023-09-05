Imports System.Data.Odbc
Public Class frmWithholdingTax

    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim f As Form = New frmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvBill, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function

    Private Sub frmWithHoldingTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_PAYABLE_ID.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm
        ' fBackGroundImageStyle(Me)
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "  "
        chk.Name = "SELECTED"
        With dgvBill.Columns
            .Add("Bill_ID", "Bill_ID")
            .Item("Bill_ID").Visible = False
            .Add(chk)
            .Item("SELECTED").Width = 60
            .Add("DATE", "DATE")
            .Item("DATE").Width = 170

            .Add("NUMBER", gsCUSTOM_NUMBER)
            .Item("NUMBER").Width = 220

            .Add("ORG_AMOUNT", gsCUSTOM_AMOUNT)
            .Item("ORG_AMOUNT").Width = 170
            .Item("ORG_AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("ORG_AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("ORG_AMOUNT").DefaultCellStyle.Format = "N2"

            .Add("TAXABLE_AMOUNT", gsCUSTOM_TAXABLE_AMOUNT)
            .Item("TAXABLE_AMOUNT").Width = 170
            .Item("TAXABLE_AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("TAXABLE_AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("TAXABLE_AMOUNT").DefaultCellStyle.Format = "N2"

            .Add("BALANCE_DUE", gsCUSTOM_BALANCE_DUE)
            .Item("BALANCE_DUE").Width = 170
            .Item("BALANCE_DUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("BALANCE_DUE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("BALANCE_DUE").DefaultCellStyle.Format = "N2"


            .Add("AMT_WITHHOLDAMT", gsCUSTOM_AMT_WITHHOLDAMT)
            .Item("AMT_WITHHOLDAMT").Width = 170
            .Item("AMT_WITHHOLDAMT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMT_WITHHOLDAMT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMT_WITHHOLDAMT").DefaultCellStyle.Format = "N2"

            .Add("ACCOUNTS_PAYABLE_ID", "ACCOUNTS_PAYABLE_ID")
            .Item("ACCOUNTS_PAYABLE_ID").Visible = False

        End With




        fClear_Info()
        cmbEWT_ID_SelectedIndexChanged(sender, e)


        If gsNew = False Then
            fRefreshInfo()
        End If
    End Sub
    Private Sub fComboBoxRefresh()
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        fComboBox(cmbEWT_ID, "select * from tax where tax_type='2' order by ID", "ID", "NAME")
        fComboBox(cmbWITHHELD_FROM_ID, "select ID,NAME from contact where type='0'", "ID", "NAME")
        fComboBox(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub
    Private Sub fClear_Info()
        fComboBoxRefresh()
        fCLean_and_refresh(Me)



        dgvBill.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID

        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub

    Private Sub cmbEWT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEWT_ID.SelectedIndexChanged


        Try

            Dim rd As OdbcDataReader = fReader("select RATE,TAX_ACCOUNT_ID from TAX where ID ='" & fNumisNULL(cmbEWT_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblEWT_RATE.Text = fNumisNULL(rd("RATE"))
                lblEWT_ACCOUNT_ID.Text = fNumisNULL(rd("TAX_ACCOUNT_ID"))
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

    Private Sub cmbWITHHELD_FROM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWITHHELD_FROM_ID.SelectedIndexChanged
        Try
            fVendor_Bill(cmbWITHHELD_FROM_ID.SelectedValue)
            cmbEWT_ID_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub fAdditem(ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As Date, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prTaxable_Amount As Double, ByVal prBalance_due As String, ByVal prTax_Paid As Double, ByVal ACCOUNTS_PAYABLE_ID As Integer)
        dgvBill.Rows.Add(gsID, prSelect, Format(prDate, "MM/dd/yyyy"), prCode, Format(prOrg_Amount, "Standard"), Format(prTaxable_Amount, "Standard"), Format(prBalance_due, "Standard"), Format(prTax_Paid, "Standard"), ACCOUNTS_PAYABLE_ID)
    End Sub
    Private Sub fVendor_Bill(ByVal prPAY_ID As String)
        dgvBill.Rows.Clear()

        dtpDATE.Checked = True
        Try


            Dim rd As OdbcDataReader = fReader("SELECT B.`ID` as `BILL_ID`,B.`DATE`,B.`CODE`,B.`AMOUNT`,B.`BALANCE_DUE`, (B.`AMOUNT`- IFNULL(B.`INPUT_TAX_AMOUNT`,0))  AS `TAXABLE_TOTAL`,b.ACCOUNTS_PAYABLE_ID FROM bill AS B WHERE  B.VENDOR_ID = '" & prPAY_ID & "' and B.LOCATION_ID = '" & fNumisNULL(cmbLOCATION_ID.SelectedValue) & "'  GROUP BY B.`ID`,B.`DATE`,B.`CODE`,B.`AMOUNT`,B.`BALANCE_DUE`")

            While rd.Read
                Dim ACCOUNTS_PAYABLE_ID As Integer = fNumisNULL(rd("ACCOUNTS_PAYABLE_ID"))
                Dim bill_ID As Integer = rd("BILL_ID")
                Dim dTax As Double = fBillSumTaxApplied_Amount(bill_ID, prPAY_ID)
                Dim Taxable_Amount As Double = fNumisNULL(rd("TAXABLE_TOTAL"))

                dTax = fGetAppliedWithholdingTax(bill_ID, gsID)

                Dim dBalance As Double = fNumisNULL(rd("BALANCE_DUE")) + dTax

                Dim bSelected As Boolean = False
                If dTax <> 0 Then
                    bSelected = True
                End If

                If dBalance <> 0 Then
                    fAdditem(bill_ID, bSelected, rd("Date"), rd("CODE"), rd("AMOUNT"), Taxable_Amount, dBalance, dTax, ACCOUNTS_PAYABLE_ID)
                End If
            End While
            rd.Close()


            fCheckBill()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fVendor_Bill(prPAY_ID)
            Else
                End
            End If

        End Try




    End Sub
    Private Sub fCheckBill()
        Dim bNotSelected As Boolean = True

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                bNotSelected = False
                Exit For
            End If
        Next

        cmbWITHHELD_FROM_ID.Enabled = gsnew



        Dim dPayment As Double = 0

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                fAutoCompute(i)
                dPayment = dPayment + fNumFormatFixed(dgvBill.Rows(i).Cells(7).Value)
            End If
        Next


        lblAMOUNT.Text = fNumFormatStandard(dPayment)
    End Sub

    Private Sub fRefreshInfo()


        Dim sQuery As String = "select * from `withholding_tax` where id ='" & gsID & "' limit 1;"
        Try

            fExecutedUsingReading(Me, sQuery)
            tdgv = New DataGridView
            tdgv = dgvBill
            tQuery = fFieldCollector(Me)

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo()
            Else
                End
            End If
        End Try



    End Sub
    Private Function fGetAppliedWithholdingTax(ByVal prbill_ID As String, ByVal prWithholding_Tax_ID As String) As Double
        Dim v As Double = 0

        Try

            Dim sQuery As String = "Select AMOUNT_WITHHELD AS A from `withholding_tax_bills` where Withholding_Tax_ID = '" & prWithholding_Tax_ID & "' and bill_id = '" & prbill_ID & "' Limit 1"
            Dim rd As OdbcDataReader = fReader(sQuery)
            If rd.Read Then
                v = fNumisNULL(rd("A"))
            End If
            rd.Close()
        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                v = fGetAppliedWithholdingTax(prbill_ID, prWithholding_Tax_ID)
            Else
                End
            End If
        End Try

        Return v
    End Function

    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub
        Else
            If gsNew = False And gsID <> "" Then
                If fCheckHasChange() = True Then
                    If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        tsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            fMessageboxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If
        End If

        f.AccessibleName = "withholding_tax"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                gsID = f.AccessibleDescription
                gsNew = False

                fClear_Info()
                If gsNew = False Then

                    fRefreshInfo()

                End If
            End If

        End If


    End Sub

    Private Sub dgvBill_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellContentClick

    End Sub

    Private Sub dgvBill_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellClick
        If e.ColumnIndex = 1 Then

            If dgvBill.Rows.Count = 0 Then
                Exit Sub
            End If

            With dgvBill.Rows(e.RowIndex)

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
        If dgvBill.Rows.Count <> 0 Then
            Dim i As Integer = dgvBill.CurrentRow.Index
            With dgvBill.Rows(i)

                .Cells(1).Value = prSelect
                .Cells(2).Value = prDate
                .Cells(3).Value = prCode
                .Cells(4).Value = fNumFormatStandard(prOrg_Amount)
                .Cells(5).Value = fNumFormatStandard(prTaxable_Amount)
                .Cells(6).Value = fNumFormatStandard(prBalance_due)
                .Cells(7).Value = fNumFormatStandard(prPayment)

            End With
        End If
    End Sub

    Private Sub fAutoCompute(ByVal i As Integer)
        If dgvBill.Rows.Count <> 0 Then

            With dgvBill.Rows(i)


                Dim t_amiount As Double = fNumFormatFixed(.Cells(5).Value) * fNumFormatFixed((Val(lblEWT_RATE.Text) / 100))

                Dim t_balance As Double = fNumFormatFixed(.Cells(6).Value)
                If t_balance < t_amiount Then

                    .Cells(7).Value = fNumFormatStandard(t_balance)

                Else
                    .Cells(7).Value = fNumFormatStandard(t_amiount)
                End If


            End With
        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click


        If Val(cmbWITHHELD_FROM_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Select Vendor")
            Exit Sub
        End If


        If dgvBill.Rows.Count = 0 Then
            fMessageboxInfo("bill not found!")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        Dim bValue_is_checked As Boolean = False
        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                bValue_is_checked = True
                Exit For
            End If
        Next

        If bValue_is_checked = False Then
            fMessageboxWarning("Amount not applied. please select bills.")
            Exit Sub
        End If
        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If
        If gsNew = True Then

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("withholding_tax", cmbLOCATION_ID.SelectedValue)
            End If

            Dim sQuery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("withholding_tax")
            sQuery = sQuery & ",ID='" & gsID & "',RECORDED_ON ='" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='15',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            sQuery = fNullOTherField(sQuery, "`withholding_tax`")
            fExecutedOnly("INSERT INTO `withholding_tax` SET " & sQuery)

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbWITHHELD_FROM_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else




            tChangeAccept = True
            Dim sQuery As String = fFieldCollector(Me)
            sQuery = sQuery & ",STATUS_DATE = '" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            fExecutedOnly("UPDATE `withholding_tax` SET " & sQuery & " WHERE ID ='" & gsID & "' limit 1")
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbWITHHELD_FROM_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If fTransactionCheck(gsID, "WITHHOLDING_TAX") = False Then
           fMessageboxWarning("Please Try Again")
            Exit Sub
        End If


        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            fAccount_Journal_SQL(Val(lblEWT_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbWITHHELD_FROM_ID.SelectedValue, 67, gsID, dtpDATE.Value, 1, fNumFormatFixed(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

        End If
        '================================

        fSaveItem()
        fSavePopUp(Me, gsNew)

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            End If
        Catch ex As Exception

        Finally
            If gsID <> "" Then
                gsNew = False
                fRefreshInfo()
            End If
        End Try



    End Sub
    Private Sub fSetNew()

        fClear_Info()
        gsNew = True
        gsID = ""
        fCheckBill()

    End Sub
    Private Sub fSaveItem()
        For i As Integer = 0 To dgvBill.Rows.Count - 1

            With dgvBill.Rows(i)
                If .Cells(1).Value = True Then
                    Dim GET_ID As Integer = 0
                    If fChecK_Withholding_tax(.Cells("BILL_ID").Value, gsID, GET_ID) = True Then
                        fExecutedOnly("UPDATE `withholding_tax_bills` SET AMOUNT_WITHHELD = '" & fNumisNULL(.Cells("AMT_WITHHOLDAMT").Value) & "',ACCOUNTS_PAYABLE_ID='" & .Cells("ACCOUNTS_PAYABLE_ID").Value & "' WHERE ID = '" & GET_ID & "' and  WITHHOLDING_TAX_ID='" & gsID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                        fUpdateBILLBalance(.Cells("BILL_ID").Value, cmbWITHHELD_FROM_ID.SelectedValue)

                    Else

                        GET_ID = fObjectTypeMap_ID("WITHHOLDING_TAX_BILLS")
                        fExecutedOnly("INSERT INTO `withholding_tax_bills` SET ID='" & GET_ID & "',WITHHOLDING_TAX_ID='" & gsID & "',BILL_ID='" & .Cells("BILL_ID").Value & "', AMOUNT_WITHHELD = '" & fNumisNULL(.Cells("AMT_WITHHOLDAMT").Value) & "',ACCOUNTS_PAYABLE_ID='" & .Cells("ACCOUNTS_PAYABLE_ID").Value & "'")
                        fUpdateBILLBalance(.Cells("BILL_ID").Value, cmbWITHHELD_FROM_ID.SelectedValue)

                    End If
                    '==============================================
                    If gsSkipJournalEntry = False Then
                        fAccount_Journal_SQL(.Cells("ACCOUNTS_PAYABLE_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("BILL_ID").Value, 68, GET_ID, dtpDATE.Value, 0, fNumisNULL(.Cells("AMT_WITHHOLDAMT").Value), gsJOURNAL_NO_FORM)
                    End If
                    '===============================================
                Else
                    Dim GET_ID As Integer = 0
                    If fChecK_Withholding_tax(.Cells("BILL_ID").Value, gsID, GET_ID) = True Then

                        If gsSkipJournalEntry = False Then
                            fJournalAccountRemoveFixed_Account_ID(.Cells("ACCOUNTS_PAYABLE_ID").Value, 68, GET_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, .Cells("BILL_ID").Value)
                        End If

                        fExecutedOnly("DELETE  FROM `withholding_tax_bills` WHERE ID ='" & GET_ID & "' and  WITHHOLDING_TAX_ID = '" & gsID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                        '   fJournalAccountRemoveFixed("WITHHOLDING_TAX_BILLS", GET_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbWITHHELD_FROM_ID.SelectedValue)
                        fUpdateBILLBalance(.Cells("BILL_ID").Value, cmbWITHHELD_FROM_ID.SelectedValue)

                    End If
                End If

            End With
        Next

    End Sub
    Private Function fChecK_Withholding_tax(ByVal bill_ID As String, ByVal withholding_tax_ID As String, ByRef GetID As Integer) As Boolean
        Dim gsUpdate As Boolean = False
        GetID = 0
        Try

            Dim rd As OdbcDataReader = fReader("select * from `withholding_tax_bills` where bill_id = '" & bill_ID & "' and withholding_tax_id = '" & withholding_tax_ID & "' limit 1")
            If rd.Read Then
                gsUpdate = True
                GetID = fNumisNULL(rd("ID"))
            End If
            rd.Close()
        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                GetID = fChecK_Withholding_tax(bill_ID, withholding_tax_ID, GetID)
                If GetID <> 0 Then
                    gsUpdate = True
                End If
            Else
                End
            End If
        End Try
        Return gsUpdate
    End Function
    Private Sub fUpdateBILLBalance(ByVal prbill_Id As String, ByVal prVendor_ID As String)



        Dim dTotal_Payment As Double = fBillSumPaymentApplied(prbill_Id, prVendor_ID) + fBillSumCreditApplied(prbill_Id, prVendor_ID) + fBillSumTaxApplied_Amount(prbill_Id, prVendor_ID)
        Dim dTotal_Amount As Double = fNumFieldValue("BILL", "ID", prbill_Id, "AMOUNT")
        Dim dTotal_Balance As Double = dTotal_Amount - dTotal_Payment
        Dim nStatus As Integer = 0

        If 0 >= dTotal_Balance Then
            'Paid
            nStatus = 11
        Else
            'Not Paid
            nStatus = 13
        End If
        fExecutedOnly("UPDATE bill SET BALANCE_DUE ='" & Format(dTotal_Balance, "FIXED") & "',STATUS='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "' WHERE Vendor_ID ='" & prVendor_ID & "' and ID ='" & prbill_Id & "' ")
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If


            If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                Exit Sub
            End If


            If gsNew = False And gsID <> "" Then
                If fCheckHasChange() = True Then
                    If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        tsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            fMessageboxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If


            If fMessageBoxQuestion(gsMessageQuestion) = True Then
                fCursorLoadingOn(True)

                Try
                    For i As Integer = 0 To dgvBill.Rows.Count - 1
                        With dgvBill.Rows(i)
                            .Cells("SELECTED").Value = False

                        End With
                    Next
                    fSaveItem()

                    If gsSkipJournalEntry = False Then
                        fAccount_journal_Delete(Val(lblEWT_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 67, gsID, dtpDATE.Value)
                    End If

                    fExecutedOnly("DELETE FROM `withholding_tax` WHERE ID ='" & gsID & "' Limit 1")
                    fDeletePopUp(Me)
                    fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbWITHHELD_FROM_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                Catch ex As Exception
                    fMessageboxWarning(ex.Message)
                End Try

                gsID = ""
                gsNew = True
                fClear_Info()
                fCursorLoadingOn(False)
            End If
        End If


    End Sub

    Private Sub frmWithholdingTax_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmWithholdingTax_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvBill.Columns("SELECTED").Width = 30
        fDgvNotSort(dgvBill)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If gsNew = False Then
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 67, lblEWT_ACCOUNT_ID.Text, cmbWITHHELD_FROM_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If
        If gsNew = False Then
            If fACCESS_PRINT_PREVIEW(Me) = False Then
                Exit Sub
            End If

            Dim prFile_name As String = "cryWithholdingTax.rpt"
            Dim prPrint_Title As String = "Withholding Tax Form "

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            fPreviewReport(prPrint_Title & "Report")

        End If


    End Sub

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If
        If gsNew = False Then
            If fACCESS_PRINT_PREVIEW(Me) = False Then
                Exit Sub
            End If
            Dim prFile_name As String = "cryWithholdingTax.rpt"
            Dim prPrint_Title As String = "Withholding Tax Form "

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
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
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmWithholdingTax_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub dgvBill_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellDoubleClick

        If dgvBill.Rows.Count = 0 Then Exit Sub
        If fMessageBoxQuestion($"Do you want to open this bill no. {dgvBill.CurrentRow.Cells("NUMBER").Value }?") = False Then Exit Sub

        gsMenuSubID = 18
        gsRefresh = True
        gsDocument_Finder_ID = dgvBill.Rows(e.RowIndex).Cells("BILL_ID").Value
        Dim rd As OdbcDataReader = fReader($"select * from `tblsub_menu` where sub_id = '{gsMenuSubID}' limit 1")
        Dim i As Integer = 0
        Dim F As Form = Nothing
        Dim Img As Image = Nothing
        If rd.Read Then
            i = fNumisNULL(rd("sub_id"))
            F = fGetForm(rd("Form"))
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
        gsDocument_Finder_ID = ""
    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvBill, tsFindText.Text)
    End Sub

    Private Sub cmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        If cmbLOCATION_ID.Items.Count <> 0 Then
            cmbWITHHELD_FROM_ID_SelectedIndexChanged(sender, e)
        End If

    End Sub
End Class