Imports System.Data.Odbc
Public Class frmGeneralJournal
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim f As Form = New frmFindDocument
    Dim bItemRefresh As Boolean = False
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvDetails, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub frmGeneralJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fColumnGrid()
        fClearInfo()

        With dgvDetails.Columns
            .Item("ACCOUNT_NAME").Width = 250
            .Item("DEBIT").Width = 80
            .Item("DEBIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("DEBIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("CREDIT").Width = 80
            .Item("CREDIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("CREDIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("CLASS").Width = 100
        End With

        fDgvNotSort(dgvDetails)
        If gsNew = False Then
            fRefresh_Details()
        End If

    End Sub
    Private Sub fClearInfo()
        dtpDATE.Checked = True
        dtpDATE.Value = Date.Now
        fRefreshCombox()
        fCLean_and_refresh(Me)

        dgvDetails.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub fColumnGrid()
        With dgvDetails.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("ACCOUNT_ID", "ACCOUNT_ID")
            .Item("ACCOUNT_ID").Visible = False
            .Add("ACCOUNT_NAME", gsCUSTOM_ACCOUNT_NAME)

            .Add("ENTRY_TYPE", "ENTRY_TYPE")
            .Item("ENTRY_TYPE").Visible = False
            .Add("DEBIT", "Debit")

            .Add("CREDIT", "Credit")

            .Add("AMOUNT", "Amount")
            .Item("AMOUNT").Visible = False
            .Add("NOTES", gsCUSTOM_PARTICULAR)
            ' .Item("NOTES").Width = 200
            .Add("CLASS_ID", "CLASS_ID")
            .Item("CLASS_ID").Visible = False
            .Add("CLASS", gsCUSTOM_CLASS)

            .Add("CONTROL_STATUS", "CONTROL_STATUS")
            .Item("CONTROL_STATUS").Visible = False
        End With
    End Sub
    Private Sub fComputed_entry(ByVal dgv As DataGridView, ByVal lbld As ToolStripLabel, ByVal lblc As ToolStripLabel)
        Dim d As Double = 0
        Dim c As Double = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(i).Visible = True Then
                d = d + fNumFormatFixed(fNumisNULL(dgv.Rows(i).Cells("DEBIT").Value))
                c = c + fNumFormatFixed(fNumisNULL(dgv.Rows(i).Cells("CREDIT").Value))
            End If
        Next

        lbld.Text = fNumFormatStandard(d)
        lblc.Text = fNumFormatStandard(c)

        'collecting
        Dim wACCT_NAME As Integer
        Dim wDEBIT As Integer
        Dim wCREDIT As Integer
        With dgvDetails
            wACCT_NAME = .Columns("ACCOUNT_NAME").Width
            wDEBIT = .Columns("DEBIT").Width
            wCREDIT = .Columns("CREDIT").Width

        End With
        Dim N_Debit As Integer = (wACCT_NAME + wDEBIT) - (XXXXFF.Width + lblCount.Width)
        lblDEBIT.Width = N_Debit
        lblCREDIT.Width = wCREDIT


    End Sub
    Private Sub fRefresh_Details()
        bItemRefresh = True
        Dim sQuery As String = "select * from `general_journal` where id = '" & gsID & "' limit 1"
        Try

            fExecutedUsingReading(Me, sQuery)

            sQuery = "select g.`ID`,g.`account_id`,a.`name` as `Account_Name`, g.`entry_type`,g.`Debit`,g.`Credit`,g.`Amount`,g.`Notes`,g.`class_id`,c.`name` as `Class_Name` from general_journal_details as g left outer join `account` as a on a.ID = g.account_id left outer join class as c on c.id = g.class_id where g.general_journal_id = '" & gsID & "'"
            dgvDetails.Rows.Clear()
            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                Dim d_amount As String = ""
                Dim c_amount As String = ""
                If Val(rd("entry_type")) = 0 Then
                    'debit
                    d_amount = Format(rd("debit"), "Standard")
                Else
                    'credit
                    c_amount = Format(rd("credit"), "Standard")
                End If
                dgvDetails.Rows.Add(rd("ID"), rd("Account_ID"), rd("account_name"), rd("entry_type"), d_amount, c_amount, rd("amount"), fTextisNULL(rd("notes")), fTextisNULL(rd("Class_ID")), fTextisNULL(rd("class_name")), "S")
            End While

            rd.Close()
            fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
            bItemRefresh = False

            tdgv = New DataGridView
            tdgv = dgvDetails
            tQuery = fFieldCollector(Me)
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh_Details()
            Else
                End
            End If
        End Try

    End Sub



    Private Sub fRefreshCombox()
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub

    Private Sub lklNew_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub



    Private Sub fEntryEdit()
        If dgvDetails.Rows.Count = 0 Then
            Exit Sub
        End If
        With frmJournalEntry
            Dim r As DataGridViewRow = dgvDetails.Rows(dgvDetails.CurrentRow.Index)
            .gsAccount_ID = r.Cells("ACCOUNT_ID").Value
            .gsDebit = fNumFormatFixed(fNumisNULL(r.Cells("DEBIT").Value))
            .gsCredit = fNumFormatFixed(fNumisNULL(r.Cells("CREDIT").Value))
            .gsNotes = r.Cells("NOTES").Value
            .gsClass_ID = r.Cells("CLASS_ID").Value
            .chkAuto.Visible = False
            .chkAuto.Checked = False
            .cmbAccounts.Enabled = False
            .ShowDialog()

            If .gsSave = True Then
                fRow_Add_Account(dgvDetails, False, .gsAccount_ID, .gsDebit, .gsCredit, .gsNotes, .gsClass_ID)
            End If
            .Dispose()

        End With
        frmJournalEntry = Nothing
        fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
    End Sub

    Private Sub lklDelete_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

    End Sub
    Private Sub dgvDetails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetails.CellDoubleClick
        fEntryEdit()
    End Sub

    Private Sub dgvDetails_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvDetails.RowsAdded
        If bItemRefresh = False Then
            fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If dgvDetails.Rows.Count = 0 Then
            fMessageboxExclamation("Details required")
            Exit Sub
        End If

        If Val(lblDEBIT.Text) <> Val(lblCREDIT.Text) Then
            fMessageboxExclamation("Balance required!")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If

        Dim SQL_SCRIPT As String = ""
        If gsNew = True Then
            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("general_journal", cmbLOCATION_ID.SelectedValue)
            End If

            gsID = fObjectTypeMap_ID("general_journal")
            Dim sQuery As String = fFieldCollector(Me)
            SQL_SCRIPT = "INSERT INTO `general_journal` SET " & sQuery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "' ;"
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", "", "", 0, cmbLOCATION_ID.SelectedValue)
        Else


            tChangeAccept = True

            fGotChangeTransaction("general_journal", gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            Dim sQuery As String = fFieldCollector(Me)
            SQL_SCRIPT = "UPDATE `general_journal` SET " & sQuery & " Where `ID` = '" & gsID & "' limit 1;"
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", "", "", 0, cmbLOCATION_ID.SelectedValue)

        End If





        fSaveDetails()

        If fTransactionCheck(gsID, "GENERAL_JOURNAL") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        End If

        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If


        gsGotChangeDate = False
        gsGotChangeLocation1 = False

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()


            End If
        Catch ex As Exception

        Finally
            If gsID <> "" Then
                gsNew = False
                fRefresh_Details()
            End If
        End Try


    End Sub
    Private Sub fSetNew()

        fClearInfo()
        gsID = ""
        gsNew = True

    End Sub
    Private Sub fSaveDetails()
        gsJOURNAL_NO_FORM = 0

        For i As Integer = 0 To dgvDetails.Rows.Count - 1
            Dim r As DataGridViewRow = dgvDetails.Rows(i)

            Select Case r.Cells("CONTROL_STATUS").Value
                Case "S"
                    fExecutedOnly("UPDATE `general_journal_details` Set LINE_NO='" & i & "' WHERE ID='" & r.Cells("ID").Value & "' and GENERAL_JOURNAL_ID='" & gsID & "' limit 1;")
                    If gsGotChangeDate = True And gsSkipJournalEntry = False Then
                        'Main
                        fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                    End If
                    If gsGotChangeLocation1 = True And gsSkipJournalEntry = False Then
                        'Main
                        fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                    End If

                    If gsGotChangeLocation1 = False And gsGotChangeDate = False Then
                        If gsSkipJournalEntry = False Then
                            fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 84, r.Cells("ID").Value, dtpDATE.Value, r.Cells("ENTRY_TYPE").Value, IIf(r.Cells("ENTRY_TYPE").Value = 0, fNumisNULL(r.Cells("DEBIT").Value), fNumisNULL(r.Cells("CREDIT").Value)), gsJOURNAL_NO_FORM)
                        End If
                    End If

                Case "A"
                    Dim i_ID As Double = fObjectTypeMap_ID("general_journal_details")
                    fExecutedOnly("INSERT INTO `general_journal_details` SET ID='" & i_ID & "',GENERAL_JOURNAL_ID='" & gsID & "',LINE_NO='" & i & "',ACCOUNT_ID='" & r.Cells("ACCOUNT_ID").Value & "',ENTRY_TYPE='" & r.Cells("ENTRY_TYPE").Value & "',DEBIT=" & fGotNullNumber(fNumFormatFixed(fNumisNULL(r.Cells("DEBIT").Value))) & ",`CREDIT` = " & fGotNullNumber(fNumFormatFixed(fNumisNULL(r.Cells("CREDIT").Value))) & ",`AMOUNT` = " & fGotNullNumber(fNumFormatFixed(fNumisNULL(r.Cells("AMOUNT").Value))) & ",NOTES=" & fGotNullText(fTextisNULL(r.Cells("NOTES").Value)) & ",CLASS_ID=" & fGotNullText(r.Cells("CLASS_ID").Value) & ";")
                    r.Cells("ID").Value = i_ID

                    '===========================================
                    If gsSkipJournalEntry = False Then
                        fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 84, r.Cells("ID").Value, dtpDATE.Value, r.Cells("ENTRY_TYPE").Value, IIf(r.Cells("ENTRY_TYPE").Value = 0, fNumisNULL(r.Cells("DEBIT").Value), fNumisNULL(r.Cells("CREDIT").Value)), gsJOURNAL_NO_FORM)
                    End If
                    '===========================================
                    r.Cells("CONTROL_STATUS").Value = "S"
                Case "E"

                    fExecutedOnly("UPDATE `general_journal_details` Set LINE_NO='" & i & "', `ACCOUNT_ID`='" & r.Cells("ACCOUNT_ID").Value & "',ENTRY_TYPE='" & r.Cells("ENTRY_TYPE").Value & "',`DEBIT`=" & fGotNullNumber(Format(fNumisNULL(r.Cells("DEBIT").Value), "FIXED")) & ",`CREDIT` = " & fGotNullNumber(fNumFormatFixed(fNumisNULL(r.Cells("CREDIT").Value))) & ",`AMOUNT` = " & fGotNullNumber(fNumFormatFixed(fNumisNULL(r.Cells("AMOUNT").Value))) & ",`NOTES`=" & fGotNullText(fTextisNULL(r.Cells("NOTES").Value)) & ",CLASS_ID=" & fGotNullText(r.Cells("CLASS_ID").Value) & " WHERE ID='" & r.Cells("ID").Value & "' and GENERAL_JOURNAL_ID='" & gsID & "' limit 1;")
                    If gsGotChangeDate = True Then
                        'Main
                        fAccount_journal_Change_date(dtpDATE.Value, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                    End If

                    If gsGotChangeLocation1 = True Then
                        'Main
                        fAccount_journal_Change_Location(cmbLOCATION_ID.SelectedValue, fNumisNULL(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                    End If
                    '===========================================
                    If gsSkipJournalEntry = False Then
                        fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 84, r.Cells("ID").Value, dtpDATE.Value, r.Cells("ENTRY_TYPE").Value, IIf(r.Cells("ENTRY_TYPE").Value = 0, fNumisNULL(r.Cells("DEBIT").Value), fNumisNULL(r.Cells("CREDIT").Value)), gsJOURNAL_NO_FORM)
                    End If
                    '==========================================
                    r.Cells("CONTROL_STATUS").Value = "S"
                Case "D"
                    fExecutedOnly("DELETE FROM general_journal_details WHERE ID='" & r.Cells("ID").Value & "' and GENERAL_JOURNAL_ID='" & gsID & "' limit 1;")
                    If gsSkipJournalEntry = False Then
                        fAccount_journal_Delete(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 84, r.Cells("ID").Value, dtpDATE.Value)
                    End If

            End Select
        Next



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

        f.AccessibleName = "general_journal"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClearInfo()
                gsID = f.AccessibleDescription
                gsNew = False
                fRefresh_Details()


            End If


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
                ' fDeleteGeneralJournal(gsID)

                For N As Integer = 0 To dgvDetails.Rows.Count - 1
                    dgvDetails.Rows(N).Cells("CONTROL_STATUS").Value = "D"
                Next

                fSaveDetails()


                fExecutedOnly("DELETE FROM `general_journal` WHERE ID='" & gsID & "' limit 1;")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Delete", "", "", 0, cmbLOCATION_ID.SelectedValue)
                fClearInfo()
                gsNew = True
                gsID = ""

            End If


        End If
    End Sub

    Private Sub frmGeneralJournal_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
    End Sub

    Private Sub frmGeneralJournal_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
    End Sub

    Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
        'PREVIEW =====================================================================
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
        'PRINT ========================================================================

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

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then

                fRefresh_Details()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, gsID)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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
        If gsNew = True Then
            Exit Sub
        End If



        fTransactionJournal(dgvDetails.Rows(dgvDetails.CurrentRow.Index).Cells("ID").Value, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 84, dgvDetails.Rows(dgvDetails.CurrentRow.Index).Cells("account_id").Value, "", txtCODE.Text, txtNOTES.Text)

    End Sub



    Private Sub dgvDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetails.CellContentClick

    End Sub

    Private Sub dgvDetails_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvDetails.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub frmGeneralJournal_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If gsNew = False Then

            fRefresh_Details()
        End If
    End Sub

    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        With frmJournalEntry
            .tmp_dgv = dgvDetails
            .chkAuto.Checked = True
            .ShowDialog()

            If .gsSave = True Then
                fRow_Add_Account(dgvDetails, True, .gsAccount_ID, .gsDebit, .gsCredit, .gsNotes, .gsClass_ID)
            End If
            .Dispose()

        End With
        frmJournalEntry = Nothing
        fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
    End Sub

    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEntryEdit()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        Try
            If dgvDetails.Rows.Count <> 0 Then
                Dim i As Integer = dgvDetails.CurrentRow.Index

                If fNumisNULL(dgvDetails.Rows(i).Cells(0).Value) <> 0 Then

                    dgvDetails.Rows(i).Cells("CONTROL_STATUS").Value = "D"
                    dgvDetails.Rows(i).Visible = False

                Else
                    dgvDetails.Rows.RemoveAt(i)
                End If
                fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
            End If
        Catch ex As Exception

        End Try
        fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
    End Sub

    Private Sub GroupBox5_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub TsFindText_Click(sender As Object, e As EventArgs) Handles tsFindText.Click

    End Sub

    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvDetails, tsFindText.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'Select Print Page ============================================================
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
End Class