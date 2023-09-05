Imports System.Data.Odbc
Public Class frmDeposit
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim bRefreshItem As Boolean = False
    Dim f As Form = New frmFindDocument

    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvDeposit, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub
    Private Sub frefreshcombox()
        fComboBox(cmbBANK_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '6')", "ID", "BANK")
        fComboBox(cmbCASH_BACK_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '6')", "ID", "BANK")
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
    End Sub
    Private Sub fClear_Info()
        frefreshcombox()

        fCLean_and_refresh(Me)

        dgvDeposit.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub frmDeposit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsJournal.Visible = gsShowAccounts
        spJournal.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm
        '   fBackGroundImageStyle(Me)
        fRefreshColumn()
        fClear_Info()


        If gsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub fRefreshInfo()

        Try

            fClear_Info()
            bRefreshItem = True
            Dim sQuery As String = "select * from deposit where ID ='" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)


            Dim rd As OdbcDataReader = fReader("select d.ID,d.RECEIVED_FROM_ID,c.NAME as `RECEIVED_NAME`,d.ACCOUNT_ID, a.NAME as `ACCOUNT_NAME`, d.payment_method_id, p.`DESCRIPTION` as `payment_method_name`,d.CHECK_NO,d.AMOUNT,d.SOURCE_OBJECT_TYPE,d.SOURCE_OBJECT_ID from deposit_funds as d left outer join contact as c on c.ID = d.Received_From_ID left outer join  account as a on a.ID = d.ACCOUNT_ID left outer join payment_method as p on p.ID = d.payment_method_ID where d.DEPOSIT_ID = '" & gsID & "' ")
            While rd.Read
                dgvDeposit.Rows.Add(rd("ID"), rd("RECEIVED_FROM_ID"), rd("RECEIVED_NAME"), rd("ACCOUNT_ID"), rd("ACCOUNT_NAME"), rd("PAYMENT_METHOD_ID"), rd("PAYMENT_METHOD_NAME"), fTextisNULL(rd("CHECK_NO")), fNumFormatStandard(fNumisNULL(rd("AMOUNT"))), fNumisNULL(rd("SOURCE_OBJECT_TYPE")), fNumisNULL(rd("SOURCE_OBJECT_ID")), "S")
            End While
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo()
            Else
                End
            End If
        End Try
        bRefreshItem = False
        fComputed()

        tdgv = New DataGridView
        tdgv = dgvDeposit
        tQuery = fFieldCollector(Me)

    End Sub
    Private Sub fRefreshColumn()
        With dgvDeposit.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("RECEIVED_FROM_ID", "Received_FROM_ID")
            .Item("RECEIVED_FROM_ID").Visible = False
            .Add("Received_From", "Received From")
            .Add("ACCOUNT_ID", "Account_ID")
            .Item("ACCOUNT_ID").Visible = False
            .Add("ACCOUNT_NAME", "Account")
            .Add("PAYMENT_METHOD_ID", "PAYMENT_METHOD_ID")
            .Item("PAYMENT_METHOD_ID").Visible = False
            .Add("PAYMENT_METHOD_NAME", "Payment Method")
            .Add("CHECK_NO", "Ref No.")
            .Add("AMOUNT", "Amount")
            .Add("SOT", "SOT")
            .Item("SOT").Visible = False
            .Add("SOI", "SOI")
            .Item("SOI").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS")
            .Item("CONTROL_STATUS").Visible = False

        End With
    End Sub


    Private Sub fEditItem()
        Try
            If dgvDeposit.Rows.Count = 0 Then
                fMessageboxWarning("Data not found!")
                Exit Sub
            End If
            Dim r As DataGridViewRow = dgvDeposit.Rows(dgvDeposit.CurrentRow.Index)
            With frmDepositFunds
                If fNumisNULL(r.Cells("SOT").Value) <> 0 Then
                    fMessageboxExclamation("Invalid to edit. this value is set on " & fGetFieldValue("object_type_map", "ID", fNumisNULL(r.Cells("SOT").Value), "NAME"))
                    Exit Sub
                End If
                .gsReceivedFrom_ID = fTextisNULL(r.Cells("RECEIVED_FROM_ID").Value)
                .gsAccount_ID = fTextisNULL(r.Cells("ACCOUNT_ID").Value)
                .gsPayment_Method_ID = fTextisNULL(r.Cells("PAYMENT_METHOD_ID").Value)
                .gsCheck_NO = fTextisNULL(r.Cells("CHECK_NO").Value)
                .gsAmount = fNumFormatFixed(r.Cells("AMOUNT").Value)
                .chkAuto.Visible = False
                .btnOK.Text = "Update"
                .ShowDialog()


                If .gsSave = True Then
                    fAdd_Deposit_fund(dgvDeposit, False, .gsReceivedFrom_ID, .gsAccount_ID, .gsPayment_Method_ID, .gsCheck_NO, .gsAmount)
                End If
                .Dispose()
            End With
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try
        frmDepositFunds = Nothing
        fComputed()
    End Sub


    Private Sub dgvDeposit_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeposit.CellContentClick

    End Sub

    Private Sub dgvDeposit_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDeposit.CellDoubleClick
        fEditItem()
    End Sub

    Private Sub numCASH_BANK_AMOUNT_ValueChanged(sender As Object, e As EventArgs) Handles numCASH_BACK_AMOUNT.ValueChanged

    End Sub
    Private Sub fComputed()
        Dim dTotal As Double = 0
        For i As Integer = 0 To dgvDeposit.Rows.Count - 1
            Dim r As DataGridViewRow = dgvDeposit.Rows(i)
            dTotal = dTotal + fNumFormatFixed(r.Cells("AMOUNT").Value)
        Next
        lblAMOUNT.Text = fNumFormatStandard(dTotal)
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If Val(cmbBANK_ACCOUNT_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select bank account")
            Exit Sub
        End If


        If dgvDeposit.Rows.Count = 0 Then
            fMessageboxInfo("Deposit fund not found!")
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then




            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("DEPOSIT", cmbLOCATION_ID.SelectedValue)
            End If
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("DEPOSIT")
            squery = squery & ",ID='" & gsID & "',RECORDED_ON ='" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "'"
            squery = fNullOTherField(squery, "`DEPOSIT`")
            fExecutedOnly("INSERT INTO `deposit` SET " & squery & ";")
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", "", cmbCASH_BACK_ACCOUNT_ID.SelectedValue, fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else


            tChangeAccept = True

            fGotChangeTransaction("DEPOSIT", gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)

            If gsGotChangeDate = True Then
                'Main
                fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(cmbBANK_ACCOUNT_ID.SelectedValue), 81, gsID, gsLast_Location_ID, gsLast_Date)
            End If

            If gsGotChangeLocation1 = True Then
                'Main
                fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(cmbBANK_ACCOUNT_ID.SelectedValue), 81, gsID, dtpDATE.Value, gsLast_Location_ID)
            End If

            Dim squery As String = fFieldCollector(Me)
            squery = squery & " WHERE ID = '" & gsID & "' limit 1;"
            fExecutedOnly("UPDATE `deposit` SET " & squery)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", "", cmbCASH_BACK_ACCOUNT_ID.SelectedValue, fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If


        fCursorLoadingOn(True)

        fSaveItem()  ' Save 

        If fTransactionCheck(gsID, "DEPOSIT") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 0, 81, gsID, dtpDATE.Value, 0, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
        End If
        '================================

        ' fJournalTransaction_Deposit(gsID)
        gsGotChangeDate = False
        gsGotChangeLocation1 = False

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
        fCursorLoadingOn(False)
    End Sub
    Private Sub fSetNew()
        fClear_Info()
        fComputed()
        gsID = ""
        gsNew = True

    End Sub
    Private Sub fSaveItem()


        For i As Integer = 0 To dgvDeposit.Rows.Count - 1
            Dim r As DataGridViewRow = dgvDeposit.Rows(i)
            Select Case r.Cells("CONTROL_STATUS").Value
                Case "S"
                    'Do nothing
                    If gsSkipJournalEntry = False Then
                        If gsGotChangeDate = True Then
                            'Main
                            fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 82, r.Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                        End If

                        If gsGotChangeLocation1 = True Then
                            'Main
                            fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 82, r.Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                        End If

                    End If

                Case "A"
                    Dim i_ID As Double = fObjectTypeMap_ID("deposit_funds")
                    fExecutedOnly("INSERT INTO `deposit_funds` set ID = '" & i_ID & "',DEPOSIT_ID='" & gsID & "',RECEIVED_FROM_ID=" & fGotNullText(r.Cells("RECEIVED_FROM_ID").Value) & ",ACCOUNT_ID=" & fGotNullNumber(r.Cells("ACCOUNT_ID").Value) & ",PAYMENT_METHOD_ID=" & fGotNullText(r.Cells("PAYMENT_METHOD_ID").Value) & ",CHECK_NO=" & fGotNullText(r.Cells("CHECK_NO").Value) & ",AMOUNT='" & Format(r.Cells("AMOUNT").Value, "FIXED") & "',SOURCE_OBJECT_TYPE=" & fGotNullNumber(r.Cells("SOT").Value) & ",SOURCE_OBJECT_ID=" & fGotNullNumber(r.Cells("SOI").Value) & ";")
                    If (r.Cells("SOI").Value) <> 0 Then
                        fDepostUpdate(r.Cells("SOT").Value, r.Cells("SOI").Value, True)
                    End If
                    r.Cells("ID").Value = i_ID
                    r.Cells("CONTROL_STATUS").Value = "S"
                    '===========================================
                    If gsSkipJournalEntry = False Then
                        Dim AMT As Double = Format(r.Cells("AMOUNT").Value, "FIXED")
                        Dim E As Integer = 0
                        If AMT < 0 Then
                            E = 0
                        Else
                            E = 1
                        End If
                        fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 82, r.Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                    End If

                     '================================
                Case "E"
                    fExecutedOnly("UPDATE `deposit_funds` set RECEIVED_FROM_ID=" & fGotNullText(r.Cells("RECEIVED_FROM_ID").Value) & ",ACCOUNT_ID='" & r.Cells("ACCOUNT_ID").Value & "',PAYMENT_METHOD_ID=" & fGotNullText(r.Cells("PAYMENT_METHOD_ID").Value) & ",CHECK_NO=" & fGotNullText(r.Cells("CHECK_NO").Value) & ",AMOUNT='" & Format(r.Cells("AMOUNT").Value, "FIXED") & "' WHERE ID='" & r.Cells("ID").Value & "' and DEPOSIT_ID='" & gsID & "' limit 1;")
                    r.Cells("CONTROL_STATUS").Value = "S"
                    '===========================================
                    If gsSkipJournalEntry = False Then
                        If gsGotChangeDate = True Then
                            'Main
                            fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 82, r.Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                        End If

                        If gsGotChangeLocation1 = True Then
                            'Main
                            fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 82, r.Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                        End If
                        Dim AMT As Double = fNumFormatFixed(r.Cells("AMOUNT").Value)
                        Dim E As Integer = 0
                        If AMT < 0 Then
                            E = 0
                        Else
                            E = 1
                        End If
                        fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 82, r.Cells("ID").Value, dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)
                    End If
                     '================================
                Case "D"
                    fExecutedOnly("DELETE FROM `deposit_funds`  WHERE ID ='" & r.Cells("ID").Value & "' and DEPOSIT_ID='" & gsID & "' limit 1;")

                    fAccount_journal_Delete(fNumisNULL(r.Cells("ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, 82, r.Cells("ID").Value, dtpDATE.Value)

                    If (r.Cells("SOI").Value) <> 0 Then
                        fDepostUpdate(r.Cells("SOT").Value, r.Cells("SOI").Value, False)
                    End If
            End Select
        Next



    End Sub
    Private Sub fDepostUpdate(ByVal type_id As Integer, ByVal id As String, ByVal bStatus As Integer)
        Dim ReturnString As String
        Select Case type_id
            Case 41

                If bStatus = True Then
                    '1
                    ReturnString = "Update payment set DEPOSITED = '1' where ID = '" & id & "' limit 1;"
                Else
                    '0
                    ReturnString = "Update payment set DEPOSITED = '0' where ID = '" & id & "' limit 1;"
                End If
            Case 52
                If bStatus = True Then
                    '1
                    ReturnString = "Update sales_receipt set DEPOSITED = '1' where ID = '" & id & "' limit 1;"
                Else
                    '0
                    ReturnString = "Update sales_receipt set DEPOSITED = '0' where ID = '" & id & "' limit 1;"
                End If
            Case 64
                If bStatus = True Then
                    '1
                    ReturnString = "Update pos_log set DEPOSITED = '1' where ID = '" & id & "' limit 1;"
                Else
                    '0
                    ReturnString = "Update pos_log set DEPOSITED = '0' where ID = '" & id & "' limit 1;"
                End If
            Case Else
                ReturnString = ""
        End Select
        fExecutedOnly(ReturnString)
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

        f.AccessibleName = "deposit"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then

                gsID = f.AccessibleDescription
                gsNew = False

                fRefreshInfo()


            End If


        End If


    End Sub

    Private Sub dgvDeposit_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvDeposit.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If
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

                Try
                    Dim TMP_SQL As String = ""
                    Dim rd As OdbcDataReader = fReader("SELECT *  FROM `deposit_funds`  WHERE DEPOSIT_ID='" & gsID & "' and SOURCE_OBJECT_TYPE is not null and SOURCE_OBJECT_ID is not null")
                    While rd.Read
                        fDepostUpdate(rd("SOURCE_OBJECT_TYPE"), rd("SOURCE_OBJECT_ID"), False)
                    End While
                    rd.Close()
                    If TMP_SQL <> "" Then
                        fExecutedOnly(TMP_SQL)
                    End If
                Catch ex As Exception
                    fMessageboxWarning(ex.Message)
                    Exit Sub
                End Try

                fCursorLoadingOn(True)

                For I As Integer = 0 To dgvDeposit.Rows.Count - 1
                    With dgvDeposit.Rows(I)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next
                fSaveItem()

                '===========================================
                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0
                    fAccount_journal_Delete(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 81, gsID, dtpDATE.Value)
                End If
                '================================
                fExecutedOnly("DELETE FROM `deposit` WHERE ID='" & gsID & "' limit 1;")


                fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                fClear_Info()
                fComputed()
                gsID = ""
                gsNew = True
                fCursorLoadingOn(False)
            End If

        End If
    End Sub

    Private Sub frmDeposit_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged


    End Sub

    Private Sub frmDeposit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dgvDeposit.Columns
            .Item("Received_From").Width = 320

            .Item("ACCOUNT_NAME").Width = 350

            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        fDgvNotSort(dgvDeposit)
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

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles tsPayment.Click
        If dgvDeposit.Rows.Count <> 0 Then Exit Sub

        With frmDepositPayment
            frmDepositPayment.ShowDialog()
            If frmDepositPayment.gsOK = True Then
                Dim dgv As DataGridView = frmDepositPayment.dgvAvailable
                For i As Integer = 0 To dgv.Rows.Count - 1
                    If dgv.Rows(i).Cells(0).Value = True Then
                        Dim r As DataGridViewRow = dgv.Rows(i)
                        Dim prAccount_ID As Integer = 0
                        Dim Account_name As String = ""
                        Dim prCheck_No As String = ""

                        If r.Cells("SOT").Value = "41" Then
                            Try

                                Dim rd As OdbcDataReader = fReader("select p.UNDEPOSITED_FUNDS_ACCOUNT_ID,a.`NAME`,p.RECEIPT_REF_NO from payment as p inner join account as a on a.ID = p.UNDEPOSITED_FUNDS_ACCOUNT_ID where p.id = '" & r.Cells("SOI").Value & "' limit 1")
                                If rd.Read Then
                                    prAccount_ID = rd("UNDEPOSITED_FUNDS_ACCOUNT_ID")
                                    Account_name = rd("NAME")
                                    prCheck_No = fTextisNULL(rd("RECEIPT_REF_NO"))
                                End If
                                rd.Close()
                            Catch ex As Exception
                                fExecutedOnly(ex.Message)


                            End Try

                        ElseIf r.Cells("SOT").Value = "52" Then
                            Try

                                Dim rd As OdbcDataReader = fReader("select p.UNDEPOSITED_FUNDS_ACCOUNT_ID,a.`NAME`,p.PAYMENT_REF_NO from sales_receipt as p inner join account as a on a.ID = p.UNDEPOSITED_FUNDS_ACCOUNT_ID where p.id = '" & r.Cells("SOI").Value & "' limit 1")
                                If rd.Read Then
                                    prAccount_ID = rd("UNDEPOSITED_FUNDS_ACCOUNT_ID")
                                    Account_name = rd("NAME")
                                    prCheck_No = fTextisNULL(rd("PAYMENT_REF_NO"))
                                End If
                                rd.Close()
                            Catch ex As Exception
                                fExecutedOnly(ex.Message)

                            End Try

                        ElseIf r.Cells("SOT").Value = "64" Then
                            Try

                                Dim rd As OdbcDataReader = fReader("select p.UNDEPOSITED_FUNDS_ACCOUNT_ID,a.`NAME` from pos_log as p inner join account as a on a.ID = p.UNDEPOSITED_FUNDS_ACCOUNT_ID where p.id = '" & r.Cells("SOI").Value & "' limit 1")
                                If rd.Read Then
                                    prAccount_ID = rd("UNDEPOSITED_FUNDS_ACCOUNT_ID")
                                    Account_name = rd("NAME")
                                    prCheck_No = ""
                                End If
                                rd.Close()
                            Catch ex As Exception
                                fExecutedOnly(ex.Message)

                            End Try
                        End If

                        dgvDeposit.Rows.Add("N", r.Cells("CUSTOMER_ID").Value, r.Cells("RECEIVED FROM").Value, prAccount_ID, Account_name, r.Cells("payment_method_id").Value, r.Cells("payment method").Value, prCheck_No, Format(r.Cells("AMOUNT").Value, "STANDARD"), r.Cells("SOT").Value, r.Cells("SOI").Value, "A")
                    End If
                Next

                If frmDepositPayment.gsLocation_ID <> 0 Then
                    cmbLOCATION_ID.SelectedValue = frmDepositPayment.gsLocation_ID
                End If
            End If
            frmDepositPayment.Dispose()
        End With
        frmDepositPayment = Nothing
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs)

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
            fTransactionJournal(gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 81, cmbBANK_ACCOUNT_ID.SelectedValue, "", txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub



    Private Sub dgvDeposit_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvDeposit.RowStateChanged
        lblCount.Text = fDgvCounting(dgvDeposit)
    End Sub

    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        With frmDepositFunds
            .chkAuto.Checked = True
            .chkAuto.Visible = False
            .btnOK.Text = "Add"
            .gsDGV = dgvDeposit
            .ShowDialog()

            .Dispose()
        End With

        frmDepositFunds = Nothing
        fComputed()
    End Sub

    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click

        Try
            If dgvDeposit.Rows.Count <> 0 Then
                Dim i As Integer = dgvDeposit.CurrentRow.Index

                If fNumisNULL(dgvDeposit.Rows(i).Cells(0).Value) <> 0 Then
                    dgvDeposit.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvDeposit.Rows(i).Visible = False
                Else
                    dgvDeposit.Rows.RemoveAt(i)
                End If
                fComputed()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDeposit_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        If dgvDeposit.Columns.Count = 0 Then Exit Sub

        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)

        If gsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub tsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvDeposit, tsFindText.Text)
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

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub
End Class