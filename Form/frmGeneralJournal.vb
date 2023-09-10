Imports System.Data.Odbc
Public Class FrmGeneralJournal
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim f As Form = New FrmFindDocument
    Dim bItemRefresh As Boolean = False
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvDetails, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub frmGeneralJournal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
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

        ViewNotSort(dgvDetails)
        If IsNew = False Then
            fRefresh_Details()
        End If

    End Sub
    Private Sub fClearInfo()
        dtpDATE.Checked = True
        dtpDATE.Value = Date.Now
        fRefreshCombox()
        ClearAndRefresh(Me)

        dgvDetails.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
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
                d = d + NumberFormatFixed(NumIsNull(dgv.Rows(i).Cells("DEBIT").Value))
                c = c + NumberFormatFixed(NumIsNull(dgv.Rows(i).Cells("CREDIT").Value))
            End If
        Next

        lbld.Text = NumberFormatStandard(d)
        lblc.Text = NumberFormatStandard(c)

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
        Dim sQuery As String = "select * from `general_journal` where id = '" & ID & "' limit 1"
        Try

            SqlExecutedUsingReading(Me, sQuery)

            sQuery = "select g.`ID`,g.`account_id`,a.`name` as `Account_Name`, g.`entry_type`,g.`Debit`,g.`Credit`,g.`Amount`,g.`Notes`,g.`class_id`,c.`name` as `Class_Name` from general_journal_details as g left outer join `account` as a on a.ID = g.account_id left outer join class as c on c.id = g.class_id where g.general_journal_id = '" & ID & "'"
            dgvDetails.Rows.Clear()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
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
                dgvDetails.Rows.Add(rd("ID"), rd("Account_ID"), rd("account_name"), rd("entry_type"), d_amount, c_amount, rd("amount"), TextIsNull(rd("notes")), TextIsNull(rd("Class_ID")), TextIsNull(rd("class_name")), "S")
            End While

            rd.Close()
            fComputed_entry(dgvDetails, lblDEBIT, lblCREDIT)
            bItemRefresh = False

            tdgv = New DataGridView
            tdgv = dgvDetails
            tQuery = SqlUpdate(Me)
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh_Details()
            Else
                End
            End If
        End Try

    End Sub



    Private Sub fRefreshCombox()
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
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
            .gsDebit = NumberFormatFixed(NumIsNull(r.Cells("DEBIT").Value))
            .gsCredit = NumberFormatFixed(NumIsNull(r.Cells("CREDIT").Value))
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
            MessageBoxExclamation("Details required")
            Exit Sub
        End If

        If Val(lblDEBIT.Text) <> Val(lblCREDIT.Text) Then
            MessageBoxExclamation("Balance required!")
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
                txtCODE.Text = GetNextCode("general_journal", cmbLOCATION_ID.SelectedValue)
            End If

            ID = ObjectTypeMapId("general_journal")


            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO general_journal ({SQL_Field},ID,RECORDED_ON) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}') ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", "", "", 0, cmbLOCATION_ID.SelectedValue)
        Else

            tChangeAccept = True
            GotChangeTransaction("general_journal", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)
            SqlExecuted("UPDATE `general_journal` SET " & SqlUpdate(Me) & " Where `ID` = '" & ID & "'")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", "", "", 0, cmbLOCATION_ID.SelectedValue)

        End If







        If IsTransactionSuccess(ID, "GENERAL_JOURNAL") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        fSaveDetails()

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
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
            If ID > 0 Then
                IsNew = False
                fRefresh_Details()
            End If
        End Try


    End Sub
    Private Sub fSetNew()

        fClearInfo()
        ID = 0
        IsNew = True

    End Sub
    Private Sub fSaveDetails()
        gsJOURNAL_NO_FORM = 0

        For i As Integer = 0 To dgvDetails.Rows.Count - 1
            Dim r As DataGridViewRow = dgvDetails.Rows(i)

            Select Case r.Cells("CONTROL_STATUS").Value
                Case "S"
                    SqlExecuted("UPDATE `general_journal_details` Set LINE_NO='" & i & "' WHERE ID='" & r.Cells("ID").Value & "' and GENERAL_JOURNAL_ID='" & ID & "' limit 1;")
                    If gsGotChangeDate = True And gsSkipJournalEntry = False Then
                        'Main
                        AccountJournalChangeDate(dtpDATE.Value, NumIsNull(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                    End If
                    If gsGotChangeLocation1 = True And gsSkipJournalEntry = False Then
                        'Main
                        AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                    End If

                    If gsGotChangeLocation1 = False And gsGotChangeDate = False Then
                        If gsSkipJournalEntry = False Then
                            fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 84, r.Cells("ID").Value, dtpDATE.Value, r.Cells("ENTRY_TYPE").Value, IIf(r.Cells("ENTRY_TYPE").Value = 0, NumIsNull(r.Cells("DEBIT").Value), NumIsNull(r.Cells("CREDIT").Value)), gsJOURNAL_NO_FORM)
                        End If
                    End If

                Case "A"
                    Dim i_ID As Double = ObjectTypeMapId("general_journal_details")
                    SqlExecuted("INSERT INTO `general_journal_details` SET ID='" & i_ID & "',GENERAL_JOURNAL_ID='" & ID & "',LINE_NO='" & i & "',ACCOUNT_ID='" & r.Cells("ACCOUNT_ID").Value & "',ENTRY_TYPE='" & r.Cells("ENTRY_TYPE").Value & "',DEBIT=" & GotNullNumber(NumberFormatFixed(NumIsNull(r.Cells("DEBIT").Value))) & ",`CREDIT` = " & GotNullNumber(NumberFormatFixed(NumIsNull(r.Cells("CREDIT").Value))) & ",`AMOUNT` = " & GotNullNumber(NumberFormatFixed(NumIsNull(r.Cells("AMOUNT").Value))) & ",NOTES=" & GotNullText(TextIsNull(r.Cells("NOTES").Value)) & ",CLASS_ID=" & GotNullText(r.Cells("CLASS_ID").Value) & ";")
                    r.Cells("ID").Value = i_ID

                    '===========================================
                    If gsSkipJournalEntry = False Then
                        fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 84, r.Cells("ID").Value, dtpDATE.Value, r.Cells("ENTRY_TYPE").Value, IIf(r.Cells("ENTRY_TYPE").Value = 0, NumIsNull(r.Cells("DEBIT").Value), NumIsNull(r.Cells("CREDIT").Value)), gsJOURNAL_NO_FORM)
                    End If
                    '===========================================
                    r.Cells("CONTROL_STATUS").Value = "S"
                Case "E"

                    SqlExecuted("UPDATE `general_journal_details` Set LINE_NO='" & i & "', `ACCOUNT_ID`='" & r.Cells("ACCOUNT_ID").Value & "',ENTRY_TYPE='" & r.Cells("ENTRY_TYPE").Value & "',`DEBIT`=" & GotNullNumber(Format(NumIsNull(r.Cells("DEBIT").Value), "FIXED")) & ",`CREDIT` = " & GotNullNumber(NumberFormatFixed(NumIsNull(r.Cells("CREDIT").Value))) & ",`AMOUNT` = " & GotNullNumber(NumberFormatFixed(NumIsNull(r.Cells("AMOUNT").Value))) & ",`NOTES`=" & GotNullText(TextIsNull(r.Cells("NOTES").Value)) & ",CLASS_ID=" & GotNullText(r.Cells("CLASS_ID").Value) & " WHERE ID='" & r.Cells("ID").Value & "' and GENERAL_JOURNAL_ID='" & ID & "' limit 1;")
                    If gsGotChangeDate = True Then
                        'Main
                        AccountJournalChangeDate(dtpDATE.Value, NumIsNull(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, gsLast_Location_ID, gsLast_Date)
                    End If

                    If gsGotChangeLocation1 = True Then
                        'Main
                        AccountJournalChangeLocation(cmbLOCATION_ID.SelectedValue, NumIsNull(r.Cells("ACCOUNT_ID").Value), 84, r.Cells("ID").Value, dtpDATE.Value, gsLast_Location_ID)
                    End If
                    '===========================================
                    If gsSkipJournalEntry = False Then
                        fAccount_Journal_SQL(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 0, 84, r.Cells("ID").Value, dtpDATE.Value, r.Cells("ENTRY_TYPE").Value, IIf(r.Cells("ENTRY_TYPE").Value = 0, NumIsNull(r.Cells("DEBIT").Value), NumIsNull(r.Cells("CREDIT").Value)), gsJOURNAL_NO_FORM)
                    End If
                    '==========================================
                    r.Cells("CONTROL_STATUS").Value = "S"
                Case "D"
                    SqlExecuted("DELETE FROM general_journal_details WHERE ID='" & r.Cells("ID").Value & "' and GENERAL_JOURNAL_ID='" & ID & "' limit 1;")
                    If gsSkipJournalEntry = False Then
                        fAccount_journal_Delete(r.Cells("ACCOUNT_ID").Value, cmbLOCATION_ID.SelectedValue, 84, r.Cells("ID").Value, dtpDATE.Value)
                    End If

            End Select
        Next



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

        f.AccessibleName = "general_journal"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClearInfo()
                ID = f.AccessibleDescription
                IsNew = False
                fRefresh_Details()


            End If


        End If


    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then
            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

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


            If MessageBoxQuestion(gsMessageQuestion) = True Then
                ' fDeleteGeneralJournal(ID)

                For N As Integer = 0 To dgvDetails.Rows.Count - 1
                    dgvDetails.Rows(N).Cells("CONTROL_STATUS").Value = "D"
                Next

                fSaveDetails()


                SqlExecuted("DELETE FROM `general_journal` WHERE ID='" & ID & "' limit 1;")
                PrompNotify(Me.Text, DeleteMsg, True)
                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", "", "", 0, cmbLOCATION_ID.SelectedValue)
                fClearInfo()
                IsNew = True
                ID = ""

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

            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
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
        'PRINT ========================================================================

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
            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
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

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
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
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
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



        fTransactionJournal(dgvDetails.Rows(dgvDetails.CurrentRow.Index).Cells("ID").Value, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 84, dgvDetails.Rows(dgvDetails.CurrentRow.Index).Cells("account_id").Value, "", txtCODE.Text, txtNOTES.Text)

    End Sub



    Private Sub dgvDetails_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetails.CellContentClick

    End Sub

    Private Sub dgvDetails_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvDetails.RowStateChanged
        lblCount.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub frmGeneralJournal_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If IsNew = False Then

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

                If NumIsNull(dgvDetails.Rows(i).Cells(0).Value) <> 0 Then

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
        GetQuickFind(dgvDetails, tsFindText.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'Select Print Page ============================================================
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

        If IsNew = True Then Exit Sub

        If SecurityAccessPrint(Me) = False Then
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

            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(ID), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)
            If v = 2 Then
                gsToolPanelView = False
                GlobalPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        frmPrintPage.Dispose()
        frmPrintPage = Nothing

    End Sub
End Class