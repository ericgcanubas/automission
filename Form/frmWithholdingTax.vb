Imports System.Data.Odbc
Public Class FrmWithholdingTax

    Public ID As String = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim f As Form = New FrmFindDocument
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function CheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvBill, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function

    Private Sub FrmWithHoldingTax_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_PAYABLE_ID.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm

        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = "  ",
            .Name = "SELECTED"
        }
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




        ClearInfo()
        CmbEWT_ID_SelectedIndexChanged(sender, e)


        If IsNew = False Then
            RefreshInfo()
        End If
    End Sub
    Private Sub ComboBoxRefresh()
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        ComboBoxLoad(cmbEWT_ID, "select * from tax where tax_type='2' order by ID", "ID", "NAME")
        ComboBoxLoad(cmbWITHHELD_FROM_ID, "select ID,NAME from contact where type='0'", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")
    End Sub
    Private Sub ClearInfo()
        ComboBoxRefresh()
        ClearAndRefresh(Me)



        dgvBill.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID

        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
    End Sub

    Private Sub CmbEWT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEWT_ID.SelectedIndexChanged


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
        CheckBilling()

    End Sub

    Private Sub CmbWITHHELD_FROM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWITHHELD_FROM_ID.SelectedIndexChanged
        Try
            VendorBilling(cmbWITHHELD_FROM_ID.SelectedValue)
            CmbEWT_ID_SelectedIndexChanged(sender, e)
        Catch ex As Exception

        End Try

    End Sub
    Private Sub AddItem(ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As Date, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prTaxable_Amount As Double, ByVal prBalance_due As String, ByVal prTax_Paid As Double, ByVal ACCOUNTS_PAYABLE_ID As Integer)
        dgvBill.Rows.Add(gsID, prSelect, Format(prDate, "MM/dd/yyyy"), prCode, Format(prOrg_Amount, "Standard"), Format(prTaxable_Amount, "Standard"), Format(prBalance_due, "Standard"), Format(prTax_Paid, "Standard"), ACCOUNTS_PAYABLE_ID)
    End Sub
    Private Sub VendorBilling(ByVal prPAY_ID As String)
        dgvBill.Rows.Clear()
        dtpDATE.Checked = True
        Try


            Dim rd As OdbcDataReader = SqlReader("SELECT B.`ID` as `BILL_ID`,B.`DATE`,B.`CODE`,B.`AMOUNT`,B.`BALANCE_DUE`, (B.`AMOUNT`- IFNULL(B.`INPUT_TAX_AMOUNT`,0))  AS `TAXABLE_TOTAL`,b.ACCOUNTS_PAYABLE_ID FROM bill AS B WHERE  B.VENDOR_ID = '" & prPAY_ID & "' and B.LOCATION_ID = '" & NumIsNull(cmbLOCATION_ID.SelectedValue) & "'  GROUP BY B.`ID`,B.`DATE`,B.`CODE`,B.`AMOUNT`,B.`BALANCE_DUE`")

            While rd.Read
                Dim ACCOUNTS_PAYABLE_ID As Integer = NumIsNull(rd("ACCOUNTS_PAYABLE_ID"))
                Dim bill_ID As Integer = rd("BILL_ID")
                Dim dTax As Double = GF_GetBillSumTaxAppliedAmount(bill_ID, prPAY_ID)
                Dim Taxable_Amount As Double = NumIsNull(rd("TAXABLE_TOTAL"))

                dTax = GetAppliedWithholdingTax(bill_ID, ID)

                Dim dBalance As Double = NumIsNull(rd("BALANCE_DUE")) + dTax

                Dim bSelected As Boolean = False
                If dTax <> 0 Then
                    bSelected = True
                End If

                If dBalance <> 0 Then
                    AddItem(bill_ID, bSelected, rd("Date"), rd("CODE"), rd("AMOUNT"), Taxable_Amount, dBalance, dTax, ACCOUNTS_PAYABLE_ID)
                End If
            End While
            rd.Close()


            CheckBilling()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                VendorBilling(prPAY_ID)
            Else
                End
            End If

        End Try




    End Sub
    Private Sub CheckBilling()

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then

                Exit For
            End If
        Next

        cmbWITHHELD_FROM_ID.Enabled = IsNew
        Dim dPayment As Double = 0

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                AutoCompute(i)
                dPayment += NumberFormatFixed(dgvBill.Rows(i).Cells(7).Value)
            End If
        Next

        lblAMOUNT.Text = NumberFormatStandard(dPayment)
    End Sub

    Private Sub RefreshInfo()
        Dim sQuery As String = "select * from `withholding_tax` where id ='" & ID & "' limit 1;"
        Try

            SqlExecutedUsingReading(Me, sQuery)
            tdgv = New DataGridView
            tdgv = dgvBill
            tQuery = SqlUpdate(Me)

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        End Try



    End Sub
    Private Function GetAppliedWithholdingTax(ByVal prbill_ID As String, ByVal prWithholding_Tax_ID As String) As Double
        Dim v As Double = 0

        Try

            Dim sQuery As String = "Select AMOUNT_WITHHELD AS A from `withholding_tax_bills` where Withholding_Tax_ID = '" & prWithholding_Tax_ID & "' and bill_id = '" & prbill_ID & "' Limit 1"
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                v = NumIsNull(rd("A"))
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                v = GetAppliedWithholdingTax(prbill_ID, prWithholding_Tax_ID)
            Else
                End
            End If
        End Try

        Return v
    End Function

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

        f.AccessibleName = "withholding_tax"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                ID = f.AccessibleDescription
                IsNew = False

                ClearInfo()
                If IsNew = False Then

                    RefreshInfo()

                End If
            End If

        End If


    End Sub

    Private Sub DgvBill_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellClick
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

                Edititem(b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, 0)
            End With

            CheckBilling()
        End If
    End Sub
    Private Sub Edititem(ByVal prSelect As Boolean, ByVal prDate As String, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prTaxable_Amount As Double, ByVal prBalance_due As String, ByVal prPayment As Double)
        If dgvBill.Rows.Count <> 0 Then
            Dim i As Integer = dgvBill.CurrentRow.Index
            With dgvBill.Rows(i)

                .Cells(1).Value = prSelect
                .Cells(2).Value = prDate
                .Cells(3).Value = prCode
                .Cells(4).Value = NumberFormatStandard(prOrg_Amount)
                .Cells(5).Value = NumberFormatStandard(prTaxable_Amount)
                .Cells(6).Value = NumberFormatStandard(prBalance_due)
                .Cells(7).Value = NumberFormatStandard(prPayment)

            End With
        End If
    End Sub

    Private Sub AutoCompute(ByVal I As Integer)
        If dgvBill.Rows.Count <> 0 Then

            With dgvBill.Rows(I)


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

    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If Val(cmbWITHHELD_FROM_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Select Vendor")
            Exit Sub
        End If


        If dgvBill.Rows.Count = 0 Then
            MessageBoxInfo("bill not found!")
            Exit Sub
        End If

        If SecurityAccessMode(Me, IsNew) = False Then
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
            MessageBoxWarning("Amount not applied. please select bills.")
            Exit Sub
        End If
        If IsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("withholding_tax", cmbLOCATION_ID.SelectedValue)
            End If


            ID = ObjectTypeMapId("withholding_tax")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO withholding_tax ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',15,'{GetDateTimeNowSql()}') ")



            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbWITHHELD_FROM_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else




            tChangeAccept = True

            SqlExecuted("UPDATE `withholding_tax` SET " & SqlUpdate(Me) & " WHERE ID ='" & ID & "' ")


            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbWITHHELD_FROM_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If GF_IsTransactionSuccess(ID, "WITHHOLDING_TAX") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If


        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0

            GS_AccountJournalExecute(Val(lblEWT_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbWITHHELD_FROM_ID.SelectedValue, 67, ID, dtpDATE.Value, 1, NumberFormatFixed(lblAMOUNT.Text), gsJOURNAL_NO_FORM)

        End If
        '================================

        SaveItem()
        SaveNotify(Me, IsNew)

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
            End If
        End Try



    End Sub
    Private Sub SetNew()

        ClearInfo()
        IsNew = True
        ID = 0
        CheckBilling()

    End Sub
    Private Sub SaveItem()
        For i As Integer = 0 To dgvBill.Rows.Count - 1

            With dgvBill.Rows(i)
                If .Cells(1).Value = True Then
                    Dim GET_ID As Integer = 0
                    If CheckWithholdingTax(.Cells("BILL_ID").Value, ID, GET_ID) = True Then
                        SqlExecuted("UPDATE `withholding_tax_bills` SET AMOUNT_WITHHELD = '" & NumIsNull(.Cells("AMT_WITHHOLDAMT").Value) & "',ACCOUNTS_PAYABLE_ID='" & .Cells("ACCOUNTS_PAYABLE_ID").Value & "' WHERE ID = '" & GET_ID & "' and  WITHHOLDING_TAX_ID='" & ID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                        UpdateBillBalance(.Cells("BILL_ID").Value, cmbWITHHELD_FROM_ID.SelectedValue)

                    Else

                        GET_ID = ObjectTypeMapId("WITHHOLDING_TAX_BILLS")
                        SqlExecuted("INSERT INTO `withholding_tax_bills` SET ID='" & GET_ID & "',WITHHOLDING_TAX_ID='" & ID & "',BILL_ID='" & .Cells("BILL_ID").Value & "', AMOUNT_WITHHELD = '" & NumIsNull(.Cells("AMT_WITHHOLDAMT").Value) & "',ACCOUNTS_PAYABLE_ID='" & .Cells("ACCOUNTS_PAYABLE_ID").Value & "'")
                        UpdateBillBalance(.Cells("BILL_ID").Value, cmbWITHHELD_FROM_ID.SelectedValue)

                    End If
                    '==============================================
                    If gsSkipJournalEntry = False Then
                        GS_AccountJournalExecute(.Cells("ACCOUNTS_PAYABLE_ID").Value, cmbLOCATION_ID.SelectedValue, .Cells("BILL_ID").Value, 68, GET_ID, dtpDATE.Value, 0, NumIsNull(.Cells("AMT_WITHHOLDAMT").Value), gsJOURNAL_NO_FORM)
                    End If
                    '===============================================
                Else
                    Dim GET_ID As Integer = 0
                    If CheckWithholdingTax(.Cells("BILL_ID").Value, ID, GET_ID) = True Then

                        If gsSkipJournalEntry = False Then
                            fJournalAccountRemoveFixed_Account_ID(.Cells("ACCOUNTS_PAYABLE_ID").Value, 68, GET_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, .Cells("BILL_ID").Value)
                        End If

                        SqlExecuted("DELETE  FROM `withholding_tax_bills` WHERE ID ='" & GET_ID & "' and  WITHHOLDING_TAX_ID = '" & ID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                        '   fJournalAccountRemoveFixed("WITHHOLDING_TAX_BILLS", GET_ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbWITHHELD_FROM_ID.SelectedValue)
                        UpdateBillBalance(.Cells("BILL_ID").Value, cmbWITHHELD_FROM_ID.SelectedValue)

                    End If
                End If

            End With
        Next

    End Sub
    Private Function CheckWithholdingTax(ByVal bill_ID As String, ByVal withholding_tax_ID As String, ByRef GetID As Integer) As Boolean
        Dim gsUpdate As Boolean = False
        GetID = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select * from `withholding_tax_bills` where bill_id = '" & bill_ID & "' and withholding_tax_id = '" & withholding_tax_ID & "' limit 1")
            If rd.Read Then
                gsUpdate = True
                GetID = NumIsNull(rd("ID"))
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                GetID = CheckWithholdingTax(bill_ID, withholding_tax_ID, GetID)
                If GetID <> 0 Then
                    gsUpdate = True
                End If
            Else
                End
            End If
        End Try
        Return gsUpdate
    End Function
    Private Sub UpdateBillBalance(ByVal prbill_Id As String, ByVal prVendor_ID As String)
        Dim dTotal_Payment As Double = GF_GetBillSumPaymentApplied(prbill_Id, prVendor_ID) + GF_GetBillSumCreditApplied(prbill_Id, prVendor_ID) + GF_GetBillSumTaxAppliedAmount(prbill_Id, prVendor_ID)
        Dim dTotal_Amount As Double = GetNumberFieldValue("BILL", "ID", prbill_Id, "AMOUNT")
        Dim dTotal_Balance As Double = dTotal_Amount - dTotal_Payment
        Dim nStatus As Integer
        If 0 >= dTotal_Balance Then
            'Paid
            nStatus = 11
        Else
            'Not Paid
            nStatus = 13
        End If
        SqlExecuted("UPDATE bill SET BALANCE_DUE ='" & Format(dTotal_Balance, "FIXED") & "',STATUS='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "' WHERE Vendor_ID ='" & prVendor_ID & "' and ID ='" & prbill_Id & "' ")
    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If


            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
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


            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)

                Try
                    For i As Integer = 0 To dgvBill.Rows.Count - 1
                        With dgvBill.Rows(i)
                            .Cells("SELECTED").Value = False

                        End With
                    Next
                    SaveItem()

                    If gsSkipJournalEntry = False Then
                        GS_AccountJournalDelete(Val(lblEWT_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 67, ID, dtpDATE.Value)
                    End If

                    SqlExecuted("DELETE FROM `withholding_tax` WHERE ID ='" & ID & "' Limit 1")
                    DeleteNotify(Me)
                    SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbWITHHELD_FROM_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                End Try

                ID = 0
                IsNew = True
                ClearInfo()
                CursorLoadingOn(False)
            End If
        End If


    End Sub

    Private Sub FrmWithholdingTax_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvBill.Columns("SELECTED").Width = 30
        ViewNotSort(dgvBill)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles tsJournal.Click
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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 67, lblEWT_ACCOUNT_ID.Text, cmbWITHHELD_FROM_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
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

            Dim prFile_name As String = "cryWithholdingTax.rpt"
            Dim prPrint_Title As String = "Withholding Tax Form "

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

    Private Sub ToolStripDropDownButton1_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton1.Click
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
            Dim prFile_name As String = "cryWithholdingTax.rpt"
            Dim prPrint_Title As String = "Withholding Tax Form "

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
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                SetNew()
            ElseIf R = 2 Then

                RefreshInfo()
            End If

        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub
    Private Sub FrmWithholdingTax_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            RefreshInfo()
        End If
    End Sub

    Private Sub DgvBill_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellDoubleClick

        If dgvBill.Rows.Count = 0 Then Exit Sub
        If MessageBoxQuestion($"Do you want to open this bill no. {dgvBill.CurrentRow.Cells("NUMBER").Value }?") = False Then Exit Sub

        gsMenuSubID = 18
        gsRefresh = True
        gsDocument_Finder_ID = dgvBill.Rows(e.RowIndex).Cells("BILL_ID").Value
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

        For n As Integer = 0 To FrmMainMenu.MyTab.TabPages.Count - 1
            Dim Frm As Form = FrmMainMenu.MyTab.TabPages.Item(n).Form
            If Frm.Text = F.Text Then
                Frm.Close()
                Exit For
            End If
        Next
        gsMenuSubID = i
        gsRefresh = True

        TabFormOpen(F, FrmMainMenu.MyTab, Img)
        F.TabIndex = gsDocument_Finder_ID
        gsDocument_Finder_ID = 0
    End Sub

    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvBill, tsFindText.Text)
    End Sub

    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        If cmbLOCATION_ID.Items.Count <> 0 Then
            CmbWITHHELD_FROM_ID_SelectedIndexChanged(sender, e)
        End If

    End Sub
End Class