﻿Imports System.Data.Odbc
Public Class frmBillPayment
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
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub
    Private Sub frmBillPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_PAYABLE_ID.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        spJournal.Visible = gsShowAccounts


        tsTITLE.Text = gsSubMenuForm
        ' fBackGroundImageStyle(Me)
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "  "
        chk.Name = "SELECTED"

        With dgvBill.Columns
            .Add("ID", "ID")
            .Item(0).Visible = False
            .Add(chk)
            .Item(1).Width = 30
            .Add("DATE", "DATE")
            .Item(2).Width = 150
            .Add("NUMBER", "REF NO.")
            .Item(3).Width = 150
            .Add("ORG_AMOUNT", "AMOUNT")
            .Item(4).Width = 150
            .Item(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISC_DATE", "DISC. DATE")
            .Item(5).Width = 120
            .Add("BALANCE_DUE", "AMOUNT DUE")
            .Item(6).Width = 150
            .Item(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISCOUNT", "DISC. AMT")
            .Item(7).Width = 150
            .Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("PAYMENT", "PAID")
            .Item(8).Width = 150
            .Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("BILL_ID", "BILL_ID")
            .Item(9).Visible = False
            .Add("DISCOUNT_ACCOUNT_ID", "DISCOUNT_ACCOUNT_ID")
            .Item(10).Visible = False
            .Add("ACCOUNTS_PAYABLE_ID", "ACCOUNTS_PAYABLE_ID")
            .Item(11).Visible = False
        End With



        fClear_Info()


        If gsNew = False Then
            fRefreshInfo()

        End If
    End Sub
    Private Sub fClear_Info()
        fComboBoxRefresh()
        fCLean_and_refresh(Me)

        dgvBill.Rows.Clear()


        cmbLOCATION_ID.SelectedValue = 0

        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID
        fGotCheckPaymentbill()
    End Sub
    Private Sub fComboBoxRefresh()
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        fComboBox(cmbBANK_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '6')", "ID", "BANK")
        fComboBox(cmbPAY_TO_ID, "select * from contact where type='0'", "ID", "NAME")
        fComboBox(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbBANK_ACCOUNT_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select bank account")
            Exit Sub
        End If

        If Val(cmbPAY_TO_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Select Vendor")
            Exit Sub
        End If

        If fNumisNULL(cmbLOCATION_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select location.")
            Exit Sub
        End If

        If numAMOUNT.Value = 0 Then
            fMessageboxWarning("Payment Amount value is 0")
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
                txtCODE.Text = fNEXT_CODE("CHECK", cmbLOCATION_ID.SelectedValue)
            End If

            Dim sQuery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("CHECK")
            sQuery = sQuery & ",ID='" & gsID & "',RECORDED_ON ='" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',STATUS='15',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "',PRINTED='0',`TYPE`='1';"
            sQuery = fNullOTherField(sQuery, "`CHECK`")
            fExecutedOnly("INSERT INTO `check` SET " & sQuery)
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbPAY_TO_ID.SelectedValue, "", fNumisNULL(numAMOUNT.Value), cmbLOCATION_ID.SelectedValue)

        Else


            tChangeAccept = True
            If gsSkipJournalEntry = False Then
                '=============================================================================
                fGotChangeTransaction("`CHECK`", gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)

                If gsGotChangeDate = True Then
                    'Main
                    fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 57, gsID, gsLast_Location_ID, gsLast_Date)
                End If
                '=============================================================================
            End If


            Dim sQuery As String = fFieldCollector(Me)
            sQuery = sQuery & ",STATUS_DATE = '" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            fExecutedOnly("UPDATE `check` SET " & sQuery & " WHERE ID ='" & gsID & "' and `TYPE`='1' limit 1;")
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbPAY_TO_ID.SelectedValue, "", fNumisNULL(numAMOUNT.Value), cmbLOCATION_ID.SelectedValue)

            End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 57, gsID, dtpDATE.Value, 1, fNumFormatFixed(lbsAMOUNT_APPLIED.Text), gsJOURNAL_NO_FORM)
        End If
        '================================

        fPaymentSaving(dgvBill, gsID, True, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, cmbPAY_TO_ID.SelectedValue)


        If fTransactionCheck(gsID, "`CHECK`") = False Then
            fMessageboxWarning("Please try again")
            Exit Sub
        End If

        'fJournalTransaction_Bill_Payment(gsID)
        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        gsGotChangeLocation2 = False

        If gsNew = True Then

            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If

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

    End Sub

    Private Sub fRefreshInfo()


        Dim sQuery As String = "select * from `check` where `Type` = '1' and id ='" & gsID & "' limit 1"
        Try
            fExecutedUsingReading(Me, sQuery)

            If Val(gsID) <> 0 Then
                cmbPAY_TO_ID.Enabled = False
                cmbLOCATION_ID.Enabled = False
                cmbBANK_ACCOUNT_ID.Enabled = False

                cmbACCOUNTS_PAYABLE_ID.Enabled = False
                fGotCheckPaymentbill()
            End If
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo()
            Else
                End
            End If
        Finally
            tdgv = New DataGridView
            tdgv = dgvBill
            tQuery = fFieldCollector(Me)
        End Try



    End Sub
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


        f.AccessibleName = "bill_payment"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                gsID = f.AccessibleDescription
                gsNew = False

                fClear_Info()
                If gsNew = False Then
                    dtpDATE.Checked = True
                    fRefreshInfo()

                End If
            End If

        End If


    End Sub
    Private Sub fPay_Bill()
        Dim prPAY_ID As Integer = fNumisNULL(cmbPAY_TO_ID.SelectedValue)

        dgvBill.Rows.Clear()
        dgvBill.Columns("SELECTED").Width = 30
        '  Dim cn As New MySqlConnection(mysqlConstr)
        dtpDATE.Checked = True
        If prPAY_ID = 0 Then Exit Sub

        Try
            Dim sQuery As String


            sQuery = "SELECT 
  i.ID,
  i.DATE,
  i.CODE,
  i.DISCOUNT_DATE,
  i.AMOUNT,
  i.BALANCE_DUE,
  i.ACCOUNTS_PAYABLE_ID
FROM
  Bill AS i 
WHERE  EXISTS 
  (SELECT 
    pv.bill_id AS ID 
  FROM
    `check_bills` AS pv 
    INNER JOIN `check` AS p 
      ON p.id = pv.`Check_ID` 
  WHERE  p.`PAY_TO_ID` = '" & prPAY_ID & "' AND p.ID ='" & gsID & "') 
  AND i.`VENDOR_ID` ='" & prPAY_ID & "' OR i.`BALANCE_DUE` >='0' AND i.`VENDOR_ID` ='" & prPAY_ID & "'  limit 1000;"


            Dim rd As OdbcDataReader = fReader(sQuery)

            While rd.Read
                Dim bill_ID As String = fNumisNULL(rd("ID"))
                Dim dPayment As Double = 0
                Dim sLine_ID As String = ""
                Dim dDiscount As Double = 0
                Dim sDISCOUNT_ACCOUNT_ID As String = ""
                Dim sACCOUNTS_PAYABLE_ID As String = ""

                fGetAppliedPayment(bill_ID, gsID, sLine_ID, dPayment, dDiscount, sDISCOUNT_ACCOUNT_ID, sACCOUNTS_PAYABLE_ID)

                If sACCOUNTS_PAYABLE_ID = "" Then
                    sACCOUNTS_PAYABLE_ID = fTextisNULL(rd("ACCOUNTS_PAYABLE_ID"))
                End If

                Dim dBalance As Double = fNumisNULL(rd("BALANCE_DUE")) + dPayment

                Dim bSelected As Boolean = False
                If dPayment <> 0 Then
                    bSelected = True
                End If

                'Open New Item Transaction
                If dBalance <> 0 Then
                    fAdditem(sLine_ID, bSelected, rd("Date"), rd("CODE"), fNumisNULL(rd("AMOUNT")), fTextisNULL(rd("DISCOUNT_DATE")), dBalance, dDiscount, dPayment, bill_ID, sDISCOUNT_ACCOUNT_ID, sACCOUNTS_PAYABLE_ID)
                End If

            End While
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fPay_Bill()
            Else
                End
            End If
        End Try
        fCheckBill()

    End Sub
    Private Sub fGetAppliedPayment(ByVal prbill_ID As String, ByVal prPayment_ID As String, ByRef refPayment_ID_Line As String, ByRef refPayment_Applied As Double, ByRef refDiscount As Double, ByRef refDISCOUNT_ACCOUNT_ID As String, ByRef refACCOUNTS_PAYABLE_ID As String)

        Try

            Dim sQuery As String = "Select ID,AMOUNT_PAID,DISCOUNT,DISCOUNT_ACCOUNT_ID,ACCOUNTS_PAYABLE_ID from check_bills where check_id = '" & prPayment_ID & "' and bill_id = '" & prbill_ID & "' Limit 1"
            Dim rd As OdbcDataReader = fReader(sQuery)
            If rd.Read Then
                refPayment_ID_Line = rd("ID")
                refPayment_Applied = rd("AMOUNT_PAID")
                refDiscount = fNumisNULL(rd("DISCOUNT"))
                refDISCOUNT_ACCOUNT_ID = fTextisNULL(rd("DISCOUNT_ACCOUNT_ID"))
                refACCOUNTS_PAYABLE_ID = fTextisNULL(rd("ACCOUNTS_PAYABLE_ID"))
            Else
                refPayment_Applied = 0
                refPayment_ID_Line = "N"
                refDiscount = 0
                refDISCOUNT_ACCOUNT_ID = ""
                refACCOUNTS_PAYABLE_ID = ""
            End If
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fGetAppliedPayment(prbill_ID, prPayment_ID, refPayment_ID_Line, refPayment_Applied, refDiscount, refDISCOUNT_ACCOUNT_ID, refACCOUNTS_PAYABLE_ID)
            Else
                End
            End If

        End Try

    End Sub
    Private Sub fAdditem(ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As Date, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prDisc_date As String, ByVal prBalance_due As String, ByVal prDiscount As Double, ByVal prPayment As Double, ByVal prBill_ID As String, ByVal prDISCOUNT_ACCOUNT_ID As String, ByVal prACCOUNTS_PAYABLE_ID As String)
        dgvBill.Rows.Add(gsID, prSelect, Format(prDate, "MM/dd/yyyy"), prCode, fNumFormatStandard(prOrg_Amount), prDisc_date, fNumFormatStandard(prBalance_due), fNumFormatStandard(prDiscount), fNumFormatStandard(prPayment), prBill_ID, prDISCOUNT_ACCOUNT_ID, prACCOUNTS_PAYABLE_ID)
    End Sub
    Private Sub fCheckBill()
        Dim bNotSelected As Boolean = True

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                bNotSelected = False
                Exit For
            End If
        Next




        Dim dPayment As Double = 0

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                dPayment = dPayment + (fNumisNULL(dgvBill.Rows(i).Cells(8).Value) + fNumisNULL(dgvBill.Rows(i).Cells(7).Value))
            End If
        Next


        lbsAMOUNT_APPLIED.Text = Format(dPayment, "Standard")
    End Sub
    Private Sub dgvBill_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellClick
        If e.ColumnIndex = 1 Then

            If dgvBill.Rows.Count = 0 Then
                Exit Sub
            End If
            ' Requiredments
            Dim bPay As Double
            If numAMOUNT.Value = 0 Then
                fMessageboxExclamation("No amount Value")
                Exit Sub
            Else

            End If


            With dgvBill.Rows(e.RowIndex)
                Dim b As Boolean = .Cells(1).Value

                If b = True Then
                    b = False
                    bPay = 0

                Else
                    b = True
                    bPay = numAMOUNT.Value
                    Dim dSelect_balance As Double = fNumisNULL(.Cells(6).Value)
                    'get remaining amount
                    Dim dAmount_remain As Double = 0
                    Dim Balance_Due As Double = 0
                    Dim Remaining_balance As Double = 0
                    Dim dPayment As Double = 0

                    Dim r As Integer = 0
                    Dim c As Integer = 0
                    For i As Integer = 0 To dgvBill.Rows.Count - 1
                        r = +1

                        If dgvBill.Rows(i).Cells(1).Value = True And i <> e.RowIndex Then
                            c = +1
                            dPayment = dPayment + (fNumisNULL(dgvBill.Rows(i).Cells(8).Value) + fNumisNULL(dgvBill.Rows(i).Cells(7).Value))


                        End If
                    Next

                    dAmount_remain = bPay - dPayment
                    If dAmount_remain > dSelect_balance Then
                        bPay = dSelect_balance
                    Else
                        If dAmount_remain <= 0 Then
                            Exit Sub
                        Else
                            bPay = dAmount_remain
                        End If
                    End If

                End If

                If b = True And bPay = 0 Then
                    fMessageboxExclamation("Can`t apply greater than the total payment")
                    Exit Sub
                End If
                fEdititem_with_Row(e.RowIndex, .Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, bPay, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
            End With

            fCheckBill()
        End If
        fGotCheckPaymentbill()
    End Sub
    Private Sub fGotCheckPaymentbill()
        For I As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(I).Cells(1).Value = True Then
                numAMOUNT.Enabled = False
                Exit Sub
            End If
        Next

        numAMOUNT.Enabled = True
    End Sub

    Private Sub fEdititem_with_Row(ByVal I As Integer, ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As String, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prDisc_date As String, ByVal prBalance_due As String, ByVal prDiscount As Double, ByVal prPayment As Double, ByVal prInvoice_ID As String, ByVal prDISCOUNT_ACCOUNT_ID As String, ByVal prACCOUNTS_PAYABLE_ID As String)

        With dgvBill.Rows(i)
                .Cells(0).Value = gsID
                .Cells(1).Value = prSelect
                .Cells(2).Value = prDate
                .Cells(3).Value = prCode
                .Cells(4).Value = fNumFormatStandard(prOrg_Amount)
                .Cells(5).Value = prDisc_date
                .Cells(6).Value = fNumFormatStandard(prBalance_due)
                .Cells(7).Value = fNumFormatStandard(prDiscount)
                .Cells(8).Value = fNumFormatStandard(prPayment)
                .Cells(9).Value = prInvoice_ID
                .Cells(10).Value = fTextisNULL(prDISCOUNT_ACCOUNT_ID)
                .Cells(11).Value = fTextisNULL(prACCOUNTS_PAYABLE_ID)
            End With

    End Sub
    Private Sub cmbPAY_TO_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAY_TO_ID.SelectedIndexChanged
        Try
            fPay_Bill()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbBANK_ACCOUNT_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBANK_ACCOUNT_ID.SelectedIndexChanged

    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If gsNew = False Then

            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                Exit Sub
            End If

            If gsNew = False And gsID <> "" Then ' if got change
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

                For i As Integer = 0 To dgvBill.Rows.Count - 1

                    With dgvBill.Rows(i)
                        .Cells("SELECTED").Value = False
                    End With
                Next

                fPaymentSaving(dgvBill, gsID, True, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, cmbPAY_TO_ID.SelectedValue)

                '===========================================
                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0
                    fAccount_journal_Delete(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 57, gsID, dtpDATE.Value)
                End If
                '================================

                fExecutedOnly("DELETE FROM `check` where ID = '" & gsID & "' limit 1;")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)

                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", cmbPAY_TO_ID.SelectedValue, "", fNumisNULL(numAMOUNT.Value), cmbLOCATION_ID.SelectedValue)
                fClear_Info()
                gsNew = True
                gsID = ""
                fCursorLoadingOn(False)
            End If


        End If

    End Sub

    Private Sub frmBillPayment_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmBillPayment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvBill.Columns("SELECTED").Width = 30

        fDgvNotSort(dgvBill)

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

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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


            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            gsToolPanelView = False
            fPreviewReport(prPrint_Title)
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
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

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

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

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub btnCredit_Click(sender As Object, e As EventArgs)
        '   If Me.Text = Me.Name Then Exit Sub

    End Sub
    'Private Function fBillBalance_Update(ByVal gsBill As String, prORG_Amount As Double) As Double
    '    Dim total_pay As Double = fBillSumPaymentApplied(gsBill, cmbPAY_TO_ID.SelectedValue) + fBillSumCreditApplied(gsBill, cmbPAY_TO_ID.SelectedValue) + fBillSumTaxApplied_Amount(gsBill, cmbPAY_TO_ID.SelectedValue)
    '    Dim New_Balance As Double = prORG_Amount - total_pay
    '    Dim squery As String
    '    Dim nStatus As Integer = 0
    '    If 0 >= New_Balance Then
    '        nStatus = 11
    '    Else
    '        nStatus = 13
    '    End If
    '    squery = "UPDATE `BILL` SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsBill & "'"
    '    fExecutedOnly(squery)
    '    Return New_Balance
    'End Function
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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 57, cmbBANK_ACCOUNT_ID.SelectedValue, cmbPAY_TO_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub SelectPagePrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPagePrintToolStripMenuItem.Click
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

        If gsNew = True Then Exit Sub

        If fACCESS_PRINT_PREVIEW(Me) = False Then
            Exit Sub
        End If

        frmPrintPage.frmName = Me.Name
        frmPrintPage.ShowDialog()

        Dim v As Integer = frmPrintPage.prValue
        If v = 1 Or v = 2 Then

            Dim prFile_name As String = ""
            Dim prPrint_Title As String = ""
            Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Try
                cn.Open()
                Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
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

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False
                fPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing
    End Sub

    Private Sub txtFind_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmBillPayment_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then
            fRefreshInfo()

        End If
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged

        fPay_Bill()



    End Sub
    Private Function fCheckAlreadyCheck() As Boolean
        Dim AlreadyCheck As Boolean = False
        For I As Integer = 0 To dgvBill.Rows.Count - 1
            With dgvBill.Rows(I).Cells("SELECTED")
                If fNumisNULL(.Value) <> 0 Then

                    AlreadyCheck = True


                End If
            End With

        Next

        Return AlreadyCheck
    End Function
    Private Function fCheckSaveBillPayment() As Boolean
        Dim not_related As Boolean = False
        Dim Selected_Location_ID As Integer = cmbLOCATION_ID.SelectedValue
        For I As Integer = 0 To dgvBill.Rows.Count - 1
            With dgvBill.Rows(I)
                If fNumisNULL(.Cells("SELECTED").Value) <> 0 Then
                    If fNumFieldValue("bill", "id", .Cells("BILL_ID").Value, "LOCATION_ID") <> Selected_Location_ID Then
                        not_related = True
                    End If
                End If
            End With

        Next

        Return not_related
    End Function
    Private Sub DgvBill_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellContentClick

    End Sub

    Private Sub tsCheckAll_Click(sender As Object, e As EventArgs) Handles tsCheckAll.Click
        If dgvBill.Rows.Count = 0 Then
            Exit Sub
        End If
        ' Requiredments
        Dim bPay As Double
        If numAMOUNT.Value = 0 Then
            fMessageboxExclamation("No amount Value")
            Exit Sub
        Else

        End If

        For N As Integer = 0 To dgvBill.Rows.Count - 1
            '==================================

            With dgvBill.Rows(N)
                Dim b As Boolean
                b = True
                If b = False Then

                    b = False
                    bPay = 0

                Else
                    b = True
                    bPay = numAMOUNT.Value
                    Dim dSelect_balance As Double = fNumisNULL(.Cells(6).Value)
                    'get remaining amount
                    Dim dAmount_remain As Double = 0
                    Dim Balance_Due As Double = 0
                    Dim Remaining_balance As Double = 0
                    Dim dPayment As Double = 0

                    Dim r As Integer = 0
                    Dim c As Integer = 0
                    For i As Integer = 0 To dgvBill.Rows.Count - 1
                        r = +1

                        If dgvBill.Rows(i).Cells(1).Value = True And i <> N Then
                            c = +1
                            dPayment = dPayment + (fNumisNULL(dgvBill.Rows(i).Cells(8).Value) + fNumisNULL(dgvBill.Rows(i).Cells(7).Value))


                        End If
                    Next

                    dAmount_remain = bPay - dPayment
                    If dAmount_remain > dSelect_balance Then
                        bPay = dSelect_balance
                    Else
                        If dAmount_remain <= 0 Then
                            Exit Sub
                        Else
                            bPay = dAmount_remain
                        End If
                    End If

                End If



                If b = True And bPay = 0 Then
                    fMessageboxExclamation("Can`t apply greater than the total payment")
                    Exit Sub
                End If
                fEdititem_with_Row(N, .Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, bPay, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
            End With

            fCheckBill()

            fGotCheckPaymentbill()

            '==================
        Next
    End Sub

    Private Sub tsUncheckAll_Click(sender As Object, e As EventArgs) Handles tsUncheckAll.Click
        If dgvBill.Rows.Count = 0 Then
            Exit Sub
        End If
        ' Requiredments
        Dim bPay As Double
        If numAMOUNT.Value = 0 Then
            fMessageboxExclamation("No amount Value")
            Exit Sub
        Else

        End If

        For N As Integer = 0 To dgvBill.Rows.Count - 1
            '==================================

            With dgvBill.Rows(N)
                Dim b As Boolean

                b = False
                If b = False Then
                    b = False
                    bPay = 0

                Else
                    b = True
                    bPay = numAMOUNT.Value
                    Dim dSelect_balance As Double = fNumisNULL(.Cells(6).Value)
                    'get remaining amount
                    Dim dAmount_remain As Double = 0
                    Dim Balance_Due As Double = 0
                    Dim Remaining_balance As Double = 0
                    Dim dPayment As Double = 0

                    Dim r As Integer = 0
                    Dim c As Integer = 0
                    For i As Integer = 0 To dgvBill.Rows.Count - 1
                        r = +1

                        If dgvBill.Rows(i).Cells(1).Value = True And i <> N Then
                            c = +1
                            dPayment = dPayment + (fNumisNULL(dgvBill.Rows(i).Cells(8).Value) + fNumisNULL(dgvBill.Rows(i).Cells(7).Value))


                        End If
                    Next

                    dAmount_remain = bPay - dPayment
                    If dAmount_remain > dSelect_balance Then
                        bPay = dSelect_balance
                    Else
                        If dAmount_remain <= 0 Then
                            Exit Sub
                        Else
                            bPay = dAmount_remain
                        End If
                    End If

                End If


                If b = True And bPay = 0 Then
                    fMessageboxExclamation("Can`t apply greater than the total payment")
                    Exit Sub
                End If
                fEdititem_with_Row(N, .Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, bPay, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
            End With

            fCheckBill()

            fGotCheckPaymentbill()

            '==================
        Next
    End Sub



    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvBill, tsFindText.Text)
    End Sub

    Private Sub DiscountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscountToolStripMenuItem.Click
        If dgvBill.Rows.Count = 0 Then
            fMessageboxWarning("Bill not found!")
            Exit Sub
        End If
        Dim i As Integer = dgvBill.CurrentRow.Index
        Dim d As DataGridViewRow = dgvBill.Rows(i)
        With frmDiscountBill
            .lblName.Text = cmbPAY_TO_ID.Text
            .lblDATE.Text = d.Cells(2).Value
            .lblCreditUsed.Text = ""
            .lblCODE.Text = d.Cells(3).Value
            .lblAMOUNT.Text = fNumFormatStandard(fNumisNULL(d.Cells("ORG_AMOUNT").Value))
            .lblAmount_Due.Text = fNumFormatStandard(fNumisNULL(d.Cells("ORG_AMOUNT").Value) - fNumisNULL(d.Cells("PAYMENT").Value))
            .lblBALANCE.Text = fNumisNULL(d.Cells("ORG_AMOUNT").Value) - fNumisNULL(d.Cells("PAYMENT").Value)
            If IsDate(d.Cells("DISC_DATE").Value) = True Then
                .dtpDISCOUNT_DATE.Value = CDate(d.Cells("DISC_DATE").Value)
            Else
                .dtpDISCOUNT_DATE.Value = Date.Now.Date
            End If

            .lblTERMS.Text = fGetFieldValue("PAYMENT_TERMS", "ID", fGetFieldValue("BILL", "ID", d.Cells("BILL_ID").Value, "PAYMENT_TERMS_ID"), "DESCRIPTION")
            .lblSuggested_Discount.Text = "0"
            .gsDISCOUNT_ACCOUNT_ID = d.Cells("DISCOUNT_ACCOUNT_ID").Value
            .gsDISCOUNT_AMOUNT = d.Cells("DISCOUNT").Value
            .ShowDialog()
            If .gsOK = True Then
                d.Cells("DISCOUNT_ACCOUNT_ID").Value = .gsDISCOUNT_ACCOUNT_ID
                d.Cells("DISCOUNT").Value = fNumFormatStandard(.gsDISCOUNT_AMOUNT)
                d.Cells("DISC_DATE").Value = .dtpDISCOUNT_DATE.Value.ToShortDateString
                fCheckBill()
            End If
            .Dispose()
        End With
        frmDiscountBill = Nothing
    End Sub

    Private Sub CreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditToolStripMenuItem.Click

        If dgvBill.Rows.Count = 0 Then
            fMessageboxWarning("Bill not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvBill.CurrentRow.Index
        Dim d As DataGridViewRow = dgvBill.Rows(i)
        With frmApplyBillCredit
            .gsID = d.Cells(9).Value
            .gsVendor_ID = cmbPAY_TO_ID.SelectedValue
            .gsLocation_ID = cmbLOCATION_ID.SelectedValue
            .lblName.Text = cmbPAY_TO_ID.Text
            .lblCODE.Text = txtCODE.Text
            .lblDATE.Text = dtpDATE.Value
            .lblORG_AMOUNT.Text = fNumFormatStandard(d.Cells(4).Value)
            .gsBalance = fNumFormatFixed(d.Cells(4).Value - d.Cells(8).Value)
            .ShowDialog()
            If .gsOk = True Then
                'DO NOTHING
                Dim p As Double = fNumFormatFixed(d.Cells(8).Value)
                'UPDATE BILL BALANCE
                If fMessageBoxQuestion("Do you want apply credit?") = True Then
                    fMessageboxInfo("Not applicable")
                    Exit Sub
                    'Dim bd As Double = fBillBalance_Update(d.Cells(9).Value, d.Cells(4).Value)
                    'd.Cells(6).Value = fNumFormatStandard(bd + p)

                End If
            End If
            .Dispose()

        End With
        frmApplyBillCredit = Nothing
    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub
End Class