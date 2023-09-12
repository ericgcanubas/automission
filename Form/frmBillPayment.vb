Imports System.Data.Odbc
Public Class FrmBillPayment
    Public ID As Integer = gsDocument_Finder_ID
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
    Private Sub FrmBillPayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_PAYABLE_ID.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts
        spJournal.Visible = gsShowAccounts
        tsTITLE.Text = gsSubMenuForm

        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = "  ",
            .Name = "SELECTED"
        }

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
        ClearInfo()
        If IsNew = False Then
            RefreshInfo()

        End If
    End Sub
    Private Sub ClearInfo()
        ComboBoxRefresh()
        ClearAndRefresh(Me)
        dgvBill.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = 0
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
        cmbACCOUNTS_PAYABLE_ID.SelectedValue = gsDefault_ACCOUNTS_PAYABALE_ID
        GotCheckPaymentbill()
    End Sub
    Private Sub ComboBoxRefresh()
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        ComboBoxLoad(cmbBANK_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '6')", "ID", "BANK")
        ComboBoxLoad(cmbPAY_TO_ID, "select * from contact where type='0'", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_PAYABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 5", "ID", "NAME")

    End Sub

    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbBANK_ACCOUNT_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select bank account")
            Exit Sub
        End If

        If Val(cmbPAY_TO_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Select Vendor")
            Exit Sub
        End If

        If NumIsNull(cmbLOCATION_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select location.")
            Exit Sub
        End If

        If numAMOUNT.Value = 0 Then
            MessageBoxWarning("Payment Amount value is 0")
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
                txtCODE.Text = GetNextCode("CHECK", cmbLOCATION_ID.SelectedValue)
            End If


            ID = ObjectTypeMapId("CHECK")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO `check`  ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE,PRINTED,`TYPE`) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',15,'{GetDateTimeNowSql()}',0,1)  ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "New", cmbPAY_TO_ID.SelectedValue, "", NumIsNull(numAMOUNT.Value), cmbLOCATION_ID.SelectedValue)

        Else


            tChangeAccept = True
            If gsSkipJournalEntry = False Then
                '=============================================================================
                GotChangeTransaction("`CHECK`", ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue)

                If gsGotChangeDate = True Then
                    'Main
                    AccountJournalChangeDate(dtpDATE.Value, NumIsNull(cmbACCOUNTS_PAYABLE_ID.SelectedValue), 57, ID, gsLast_Location_ID, gsLast_Date)
                End If

            End If


            Dim sQuery As String = SqlUpdate(Me)
            sQuery = sQuery & ",STATUS_DATE = '" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            SqlExecuted("UPDATE `check` SET " & sQuery & " WHERE ID ='" & ID & "' and `TYPE`='1' ")
            SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbPAY_TO_ID.SelectedValue, "", NumIsNull(numAMOUNT.Value), cmbLOCATION_ID.SelectedValue)

        End If

        If IsTransactionSuccess(ID, "`CHECK`") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        End If


        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, cmbPAY_TO_ID.SelectedValue, 57, ID, dtpDATE.Value, 1, NumberFormatFixed(lbsAMOUNT_APPLIED.Text), gsJOURNAL_NO_FORM)
        End If


        fPaymentSaving(dgvBill, ID, True, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, cmbPAY_TO_ID.SelectedValue)
        gsGotChangeDate = False
        gsGotChangeLocation1 = False
        gsGotChangeLocation2 = False

        If IsNew = True Then

            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

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

    End Sub

    Private Sub RefreshInfo()
        Dim sQuery As String = "select * from `check` where `Type` = '1' and id ='" & ID & "' limit 1"
        Try
            SqlExecutedUsingReading(Me, sQuery)

            If Val(ID) <> 0 Then
                cmbPAY_TO_ID.Enabled = False
                cmbLOCATION_ID.Enabled = False
                cmbBANK_ACCOUNT_ID.Enabled = False

                cmbACCOUNTS_PAYABLE_ID.Enabled = False
                GotCheckPaymentbill()
            End If
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo()
            Else
                End
            End If
        Finally
            tdgv = New DataGridView
            tdgv = dgvBill
            tQuery = SqlUpdate(Me)
        End Try

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


        f.AccessibleName = "bill_payment"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then

            If f.AccessibleDescription <> "cancel" Then
                ID = f.AccessibleDescription
                IsNew = False

                ClearInfo()
                If IsNew = False Then
                    dtpDATE.Checked = True
                    RefreshInfo()

                End If
            End If

        End If


    End Sub
    Private Sub PaymentBill()
        Dim prPAY_ID As Integer = NumIsNull(cmbPAY_TO_ID.SelectedValue)

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
  WHERE  p.`PAY_TO_ID` = '" & prPAY_ID & "' AND p.ID ='" & ID & "') 
  AND i.`VENDOR_ID` ='" & prPAY_ID & "' OR i.`BALANCE_DUE` >='0' AND i.`VENDOR_ID` ='" & prPAY_ID & "'  limit 1000;"


            Dim rd As OdbcDataReader = SqlReader(sQuery)

            While rd.Read
                Dim bill_ID As String = NumIsNull(rd("ID"))
                Dim dPayment As Double = 0
                Dim sLine_ID As String = ""
                Dim dDiscount As Double = 0
                Dim sDISCOUNT_ACCOUNT_ID As String = ""
                Dim sACCOUNTS_PAYABLE_ID As String = ""

                GetAppliedPayment(bill_ID, ID, sLine_ID, dPayment, dDiscount, sDISCOUNT_ACCOUNT_ID, sACCOUNTS_PAYABLE_ID)

                If sACCOUNTS_PAYABLE_ID = "" Then
                    sACCOUNTS_PAYABLE_ID = TextIsNull(rd("ACCOUNTS_PAYABLE_ID"))
                End If

                Dim dBalance As Double = NumIsNull(rd("BALANCE_DUE")) + dPayment

                Dim bSelected As Boolean = False
                If dPayment <> 0 Then
                    bSelected = True
                End If

                'Open New Item Transaction
                If dBalance <> 0 Then
                    AddBilling(sLine_ID, bSelected, rd("Date"), rd("CODE"), NumIsNull(rd("AMOUNT")), TextIsNull(rd("DISCOUNT_DATE")), dBalance, dDiscount, dPayment, bill_ID, sDISCOUNT_ACCOUNT_ID, sACCOUNTS_PAYABLE_ID)
                End If

            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                PaymentBill()
            Else
                End
            End If
        End Try
        CheckingBill()

    End Sub
    Private Sub GetAppliedPayment(ByVal prbill_ID As String, ByVal prPayment_ID As String, ByRef refPayment_ID_Line As String, ByRef refPayment_Applied As Double, ByRef refDiscount As Double, ByRef refDISCOUNT_ACCOUNT_ID As String, ByRef refACCOUNTS_PAYABLE_ID As String)

        Try
            Dim sQuery As String = "Select ID,AMOUNT_PAID,DISCOUNT,DISCOUNT_ACCOUNT_ID,ACCOUNTS_PAYABLE_ID from check_bills where check_id = '" & prPayment_ID & "' and bill_id = '" & prbill_ID & "' Limit 1"
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                refPayment_ID_Line = rd("ID")
                refPayment_Applied = rd("AMOUNT_PAID")
                refDiscount = NumIsNull(rd("DISCOUNT"))
                refDISCOUNT_ACCOUNT_ID = TextIsNull(rd("DISCOUNT_ACCOUNT_ID"))
                refACCOUNTS_PAYABLE_ID = TextIsNull(rd("ACCOUNTS_PAYABLE_ID"))
            Else
                refPayment_Applied = 0
                refPayment_ID_Line = "N"
                refDiscount = 0
                refDISCOUNT_ACCOUNT_ID = ""
                refACCOUNTS_PAYABLE_ID = ""
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                GetAppliedPayment(prbill_ID, prPayment_ID, refPayment_ID_Line, refPayment_Applied, refDiscount, refDISCOUNT_ACCOUNT_ID, refACCOUNTS_PAYABLE_ID)
            Else
                End
            End If

        End Try

    End Sub
    Private Sub AddBilling(ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As Date, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prDisc_date As String, ByVal prBalance_due As String, ByVal prDiscount As Double, ByVal prPayment As Double, ByVal prBill_ID As String, ByVal prDISCOUNT_ACCOUNT_ID As String, ByVal prACCOUNTS_PAYABLE_ID As String)
        dgvBill.Rows.Add(gsID, prSelect, Format(prDate, "MM/dd/yyyy"), prCode, NumberFormatStandard(prOrg_Amount), prDisc_date, NumberFormatStandard(prBalance_due), NumberFormatStandard(prDiscount), NumberFormatStandard(prPayment), prBill_ID, prDISCOUNT_ACCOUNT_ID, prACCOUNTS_PAYABLE_ID)
    End Sub
    Private Sub CheckingBill()


        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                Exit For
            End If
        Next

        Dim dPayment As Double = 0

        For i As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(i).Cells(1).Value = True Then
                dPayment += (NumIsNull(dgvBill.Rows(i).Cells(8).Value) + NumIsNull(dgvBill.Rows(i).Cells(7).Value))
            End If
        Next


        lbsAMOUNT_APPLIED.Text = Format(dPayment, "Standard")
    End Sub
    Private Sub DgvBill_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvBill.CellClick
        If e.ColumnIndex = 1 Then

            If dgvBill.Rows.Count = 0 Then
                Exit Sub
            End If

            Dim bPay As Double
            If numAMOUNT.Value = 0 Then
                MessageBoxExclamation("No amount Value")
                Exit Sub
            End If


            With dgvBill.Rows(e.RowIndex)
                Dim b As Boolean = .Cells(1).Value

                If b = True Then
                    b = False
                    bPay = 0

                Else
                    b = True
                    bPay = numAMOUNT.Value
                    Dim dSelect_balance As Double = NumIsNull(.Cells(6).Value)
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
                            dPayment += (NumIsNull(dgvBill.Rows(i).Cells(8).Value) + NumIsNull(dgvBill.Rows(i).Cells(7).Value))
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
                    MessageBoxExclamation("Can`t apply greater than the total payment")
                    Exit Sub
                End If
                Edititem_with_Row(e.RowIndex, .Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, bPay, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
            End With

            CheckingBill()
        End If
        GotCheckPaymentbill()
    End Sub
    Private Sub GotCheckPaymentbill()
        For I As Integer = 0 To dgvBill.Rows.Count - 1
            If dgvBill.Rows(I).Cells(1).Value = True Then
                numAMOUNT.Enabled = False
                Exit Sub
            End If
        Next

        numAMOUNT.Enabled = True
    End Sub

    Private Sub Edititem_with_Row(ByVal I As Integer, ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As String, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prDisc_date As String, ByVal prBalance_due As String, ByVal prDiscount As Double, ByVal prPayment As Double, ByVal prInvoice_ID As String, ByVal prDISCOUNT_ACCOUNT_ID As String, ByVal prACCOUNTS_PAYABLE_ID As String)

        With dgvBill.Rows(I)
            .Cells(0).Value = gsID
            .Cells(1).Value = prSelect
            .Cells(2).Value = prDate
            .Cells(3).Value = prCode
            .Cells(4).Value = NumberFormatStandard(prOrg_Amount)
            .Cells(5).Value = prDisc_date
            .Cells(6).Value = NumberFormatStandard(prBalance_due)
            .Cells(7).Value = NumberFormatStandard(prDiscount)
            .Cells(8).Value = NumberFormatStandard(prPayment)
            .Cells(9).Value = prInvoice_ID
            .Cells(10).Value = TextIsNull(prDISCOUNT_ACCOUNT_ID)
            .Cells(11).Value = TextIsNull(prACCOUNTS_PAYABLE_ID)
        End With

    End Sub
    Private Sub CmbPAY_TO_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAY_TO_ID.SelectedIndexChanged
        Try
            PaymentBill()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If IsNew = False Then

            If SecurityAccessDelete(Me) = False Then
                Exit Sub
            End If

            If IsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            If IsNew = False And ID > 0 Then ' if got change
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

                For i As Integer = 0 To dgvBill.Rows.Count - 1

                    With dgvBill.Rows(i)
                        .Cells("SELECTED").Value = False
                    End With
                Next

                fPaymentSaving(dgvBill, ID, True, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, cmbPAY_TO_ID.SelectedValue)

                '===========================================
                If gsSkipJournalEntry = False Then
                    gsJOURNAL_NO_FORM = 0
                    fAccount_journal_Delete(cmbBANK_ACCOUNT_ID.SelectedValue, cmbLOCATION_ID.SelectedValue, 57, ID, dtpDATE.Value)
                End If
                '================================

                SqlExecuted("DELETE FROM `check` where ID = '" & ID & "' limit 1;")
                PrompNotify(Me.Text, DeleteMsg, True)

                SetTransactionLog(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbPAY_TO_ID.SelectedValue, "", NumIsNull(numAMOUNT.Value), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                IsNew = True
                ID = 0
                CursorLoadingOn(False)
            End If


        End If

    End Sub

    Private Sub FrmBillPayment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvBill.Columns("SELECTED").Width = 30

        ViewNotSort(dgvBill)

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

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

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
            AccountTransactionJournalEntry(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 57, cmbBANK_ACCOUNT_ID.SelectedValue, cmbPAY_TO_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ShowTransactionLog(Me, ID)
    End Sub

    Private Sub SelectPagePrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPagePrintToolStripMenuItem.Click
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

        If SecurityAccessPrint(Me) = False Then
            Exit Sub
        End If

        FrmPrintPage.frmName = Me.Name
        FrmPrintPage.ShowDialog()

        Dim v As Integer = FrmPrintPage.prValue
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
                GlobalPreviewReport(prPrint_Title)
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)

            End If



        End If
        FrmPrintPage.Dispose()
        FrmPrintPage = Nothing
    End Sub

    Private Sub FrmBillPayment_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged

        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)

        If IsNew = False Then
            RefreshInfo()
        End If
    End Sub
    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        PaymentBill()
    End Sub
    Private Function IsBillAlreadyCheck() As Boolean
        Dim AlreadyCheck As Boolean = False
        For I As Integer = 0 To dgvBill.Rows.Count - 1
            With dgvBill.Rows(I).Cells("SELECTED")
                If NumIsNull(.Value) <> 0 Then
                    AlreadyCheck = True
                End If
            End With

        Next

        Return AlreadyCheck
    End Function
    Private Function IsCheckSaveBillPayment() As Boolean
        Dim not_related As Boolean = False
        Dim Selected_Location_ID As Integer = cmbLOCATION_ID.SelectedValue
        For I As Integer = 0 To dgvBill.Rows.Count - 1
            With dgvBill.Rows(I)
                If NumIsNull(.Cells("SELECTED").Value) <> 0 Then
                    If GetNumberFieldValue("bill", "id", .Cells("BILL_ID").Value, "LOCATION_ID") <> Selected_Location_ID Then
                        not_related = True
                    End If
                End If
            End With

        Next

        Return not_related
    End Function
    Private Sub TsCheckAll_Click(sender As Object, e As EventArgs) Handles tsCheckAll.Click
        If dgvBill.Rows.Count = 0 Then
            Exit Sub
        End If
        ' Requiredments
        Dim bPay As Double
        If numAMOUNT.Value = 0 Then
            MessageBoxExclamation("No amount Value")
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
                    Dim dSelect_balance As Double = NumIsNull(.Cells(6).Value)
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
                            dPayment += (NumIsNull(dgvBill.Rows(i).Cells(8).Value) + NumIsNull(dgvBill.Rows(i).Cells(7).Value))
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
                    MessageBoxExclamation("Can`t apply greater than the total payment")
                    Exit Sub
                End If
                Edititem_with_Row(N, .Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, bPay, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
            End With

            CheckingBill()

            GotCheckPaymentbill()

            '==================
        Next
    End Sub

    Private Sub TsUncheckAll_Click(sender As Object, e As EventArgs) Handles tsUncheckAll.Click
        If dgvBill.Rows.Count = 0 Then
            Exit Sub
        End If

        Dim bPay As Double
        If numAMOUNT.Value = 0 Then
            MessageBoxExclamation("No amount Value")
            Exit Sub
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
                    Dim dSelect_balance As Double = NumIsNull(.Cells(6).Value)
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
                            dPayment += (NumIsNull(dgvBill.Rows(i).Cells(8).Value) + NumIsNull(dgvBill.Rows(i).Cells(7).Value))
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
                    MessageBoxExclamation("Can`t apply greater than the total payment")
                    Exit Sub
                End If
                Edititem_with_Row(N, .Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells(6).Value, .Cells(7).Value, bPay, .Cells(9).Value, .Cells(10).Value, .Cells(11).Value)
            End With

            CheckingBill()

            GotCheckPaymentbill()

            '==================
        Next
    End Sub



    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        GetQuickFind(dgvBill, tsFindText.Text)
    End Sub

    Private Sub DiscountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscountToolStripMenuItem.Click
        If dgvBill.Rows.Count = 0 Then
            MessageBoxWarning("Bill not found!")
            Exit Sub
        End If
        Dim i As Integer = dgvBill.CurrentRow.Index
        Dim d As DataGridViewRow = dgvBill.Rows(i)
        With FrmDiscountBill
            .lblName.Text = cmbPAY_TO_ID.Text
            .lblDATE.Text = d.Cells(2).Value
            .lblCreditUsed.Text = ""
            .lblCODE.Text = d.Cells(3).Value
            .lblAMOUNT.Text = NumberFormatStandard(NumIsNull(d.Cells("ORG_AMOUNT").Value))
            .lblAmount_Due.Text = NumberFormatStandard(NumIsNull(d.Cells("ORG_AMOUNT").Value) - NumIsNull(d.Cells("PAYMENT").Value))
            .lblBALANCE.Text = NumIsNull(d.Cells("ORG_AMOUNT").Value) - NumIsNull(d.Cells("PAYMENT").Value)
            If IsDate(d.Cells("DISC_DATE").Value) = True Then
                .dtpDISCOUNT_DATE.Value = CDate(d.Cells("DISC_DATE").Value)
            Else
                .dtpDISCOUNT_DATE.Value = Date.Now.Date
            End If

            .lblTERMS.Text = GetStringFieldValue("PAYMENT_TERMS", "ID", GetStringFieldValue("BILL", "ID", d.Cells("BILL_ID").Value, "PAYMENT_TERMS_ID"), "DESCRIPTION")
            .lblSuggested_Discount.Text = "0"
            .gsDISCOUNT_ACCOUNT_ID = d.Cells("DISCOUNT_ACCOUNT_ID").Value
            .gsDISCOUNT_AMOUNT = d.Cells("DISCOUNT").Value
            .ShowDialog()
            If .gsOK = True Then
                d.Cells("DISCOUNT_ACCOUNT_ID").Value = .gsDISCOUNT_ACCOUNT_ID
                d.Cells("DISCOUNT").Value = NumberFormatStandard(.gsDISCOUNT_AMOUNT)
                d.Cells("DISC_DATE").Value = .dtpDISCOUNT_DATE.Value.ToShortDateString
                CheckingBill()
            End If
            .Dispose()
        End With
        FrmDiscountBill = Nothing
    End Sub

    Private Sub CreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditToolStripMenuItem.Click

        If dgvBill.Rows.Count = 0 Then
            MessageBoxWarning("Bill not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvBill.CurrentRow.Index
        Dim d As DataGridViewRow = dgvBill.Rows(i)
        With FrmApplyBillCredit
            .gsID = d.Cells(9).Value
            .gsVendor_ID = cmbPAY_TO_ID.SelectedValue
            .gsLocation_ID = cmbLOCATION_ID.SelectedValue
            .lblName.Text = cmbPAY_TO_ID.Text
            .lblCODE.Text = txtCODE.Text
            .lblDATE.Text = dtpDATE.Value
            .lblORG_AMOUNT.Text = NumberFormatStandard(d.Cells(4).Value)
            .gsBalance = NumberFormatFixed(d.Cells(4).Value - d.Cells(8).Value)
            .ShowDialog()
            If .gsOk = True Then
                'DO NOTHING
                Dim p As Double = NumberFormatFixed(d.Cells(8).Value)
                'UPDATE BILL BALANCE
                If MessageBoxQuestion("Do you want apply credit?") = True Then
                    MessageBoxInfo("Not applicable")
                    Exit Sub
                    'Dim bd As Double = SetBillBalanceUpdate(d.Cells(9).Value, d.Cells(4).Value)
                    'd.Cells(6).Value = NumberFormatStandard(bd + p)

                End If
            End If
            .Dispose()

        End With
        FrmApplyBillCredit = Nothing
    End Sub

    Private Sub ToolStrip2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles ToolStrip2.ItemClicked

    End Sub
End Class