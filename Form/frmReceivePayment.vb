Imports System.Data.Odbc

Public Class frmReceivePayment
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim f As Form = New frmFindDocument
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

    Private Sub frmReceivePayment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AccountLabel.Visible = gsShowAccounts
        cmbACCOUNTS_RECEIVABLE_ID.Visible = gsShowAccounts
        spJournal.Visible = gsShowAccounts
        tsJournal.Visible = gsShowAccounts

        tsTITLE.Text = gsSubMenuForm

        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = " "
        chk.Name = "SELECTED"
        With dgvInvoice.Columns
            .Add("ID", "ID")
            .Item(0).Visible = False
            .Add(chk)
            .Item(1).Width = 30 '1
            .Add("DATE", "DATE") '2
            .Item("DATE").Width = 150
            .Add("NUMBER", "REF NO.") '3
            .Item("NUMBER").Width = 150
            .Add("ORG_AMOUNT", "AMOUNT") '4
            .Item("ORG_AMOUNT").Width = 150
            .Item("ORG_AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISC_DATE", "DISC. DATE") '5
            .Item("DISC_DATE").Width = 130
            .Add("DUE_DATE", "DUE DATE") ' 6
            .Item("DUE_DATE").Width = 100
            .Item("DUE_DATE").DefaultCellStyle.Format = "MM/dd/yyyy"
            .Add("ACCOUNTS_RECEIVABLE_ID", "ACCOUNTS_RECEIVABLE_ID") '7
            .Item("ACCOUNTS_RECEIVABLE_ID").Visible = False
            .Add("BALANCE_DUE", "BALANCE DUE") '8
            .Item("BALANCE_DUE").Width = 80
            .Item("BALANCE_DUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISCOUNT", "DISCOUNT") '9
            .Item("DISCOUNT").Width = 80
            .Item("DISCOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("BALANCE_REMAINING", "TOTAL BALANCE") '8
            .Item("BALANCE_REMAINING").Width = 80
            .Item("BALANCE_REMAINING").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("PAYMENT", "PAYMENT") ' 10
            .Item("PAYMENT").Width = 80
            .Item("PAYMENT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("INVOICE_ID", "INVOICE_ID")
            .Item("INVOICE_ID").Visible = False
            .Add("DISCOUNT_ACCOUNT_ID", "DISCOUNT_ACCOUNT_ID")
            .Item("DISCOUNT_ACCOUNT_ID").Visible = False

        End With

        fClear_Info()

        If IsNew = False Then
            fRefreshInfo()

        End If

    End Sub

    Private Sub fClear_Info()
        fComboxRefresh()

        Me.dgvInvoice.Rows.Clear()
        ClearAndRefresh(Me)

        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_METHOD_ID.SelectedIndex = 0
        cmbPAYMENT_METHOD_ID.SelectedValue = fPaymentMethodDefault()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub fRefreshInfo()

        Dim sQuery As String = "select * from payment where id ='" & ID & "'  limit 1;"
        Try
            SqlExecutedUsingReading(Me, sQuery)
            fCheckInvoice()
            tdgv = New DataGridView
            tdgv = dgvInvoice
            tQuery = SqlUpdate(Me)
        Catch ex As Exception
            fRefreshInfo()
        Finally



        End Try



    End Sub
    Private Sub fComboxRefresh()
        ComboBoxLoad(cmbCUSTOMER_ID, "select * from contact where type='1'", "ID", "NAME")
        ComboBoxLoad(cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")
    End Sub
    Private Sub cmbPAYMENT_METHOD_ID_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedValueChanged
        Try

            Dim I As Integer = 0
            If cmbPAYMENT_METHOD_ID.Items.Count <> 0 Then
                I = Val(cmbPAYMENT_METHOD_ID.SelectedValue)
            End If

            Select Case I
                Case 1 'Cash
                    OR_No.Visible = False
                    txtRECEIPT_REF_NO.Visible = False
                    OR_DATE.Visible = False
                    dtpRECEIPT_DATE.Visible = False


                    CARD_EXPIRED_DATE.Visible = False
                    dtpCARD_EXPIRY_DATE.Visible = False
                    CARD_NO.Visible = False
                    txtCARD_NO.Visible = False
                Case 2 'Check

                    OR_No.Visible = True
                    txtRECEIPT_REF_NO.Visible = True
                    OR_DATE.Visible = True
                    dtpRECEIPT_DATE.Visible = True


                    CARD_EXPIRED_DATE.Visible = False
                    dtpCARD_EXPIRY_DATE.Visible = False
                    CARD_NO.Visible = False
                    txtCARD_NO.Visible = False

                Case 3 'Master Card
                    OR_No.Visible = True
                    txtRECEIPT_REF_NO.Visible = True
                    OR_DATE.Visible = False
                    dtpRECEIPT_DATE.Visible = False


                    CARD_EXPIRED_DATE.Visible = True
                    dtpCARD_EXPIRY_DATE.Visible = True
                    CARD_NO.Visible = True
                    txtCARD_NO.Visible = True
                Case 4 'Others

                    OR_No.Visible = True
                    txtRECEIPT_REF_NO.Visible = True
                    OR_DATE.Visible = False
                    dtpRECEIPT_DATE.Visible = False


                    CARD_EXPIRED_DATE.Visible = True
                    dtpCARD_EXPIRY_DATE.Visible = True
                    CARD_NO.Visible = True
                    txtCARD_NO.Visible = True

                Case 5

                    OR_No.Visible = True
                    txtRECEIPT_REF_NO.Visible = True
                    OR_DATE.Visible = False
                    dtpRECEIPT_DATE.Visible = False


                    CARD_EXPIRED_DATE.Visible = True
                    dtpCARD_EXPIRY_DATE.Visible = True
                    CARD_NO.Visible = True
                    txtCARD_NO.Visible = True

                Case Else
                    OR_No.Visible = False
                    txtRECEIPT_REF_NO.Visible = False
                    OR_DATE.Visible = False
                    dtpRECEIPT_DATE.Visible = False

                    CARD_EXPIRED_DATE.Visible = False
                    dtpCARD_EXPIRY_DATE.Visible = False
                    CARD_NO.Visible = False
                    txtCARD_NO.Visible = False

            End Select
        Catch ex As Exception
            OR_No.Visible = False
            txtRECEIPT_REF_NO.Visible = False
            OR_DATE.Visible = False
            dtpRECEIPT_DATE.Visible = False


            CARD_EXPIRED_DATE.Visible = False
            dtpCARD_EXPIRY_DATE.Visible = False
            CARD_NO.Visible = False
            txtCARD_NO.Visible = False
        End Try
    End Sub
    Private Sub fAdditem(ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As Date, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prDisc_date As String, ByVal prDue_Date As String, ByVal prACCOUNTS_RECEIVABLE_ID As Integer, ByVal prBalance_due As String, ByVal prDiscount As Double, ByVal prPayment As Double, ByVal prInvoice_ID As String, ByVal prDISCOUNT_ACCOUNT_ID As String)
        dgvInvoice.Rows.Add(gsID, prSelect, DateFormatStandard(prDate), prCode, NumberFormatStandard(prOrg_Amount), prDisc_date, prDue_Date, prACCOUNTS_RECEIVABLE_ID, NumberFormatStandard(prBalance_due), NumberFormatStandard(prDiscount), NumberFormatStandard(prBalance_due), NumberFormatStandard(prPayment), prInvoice_ID, prDISCOUNT_ACCOUNT_ID)
    End Sub
    Private Sub fEdititem(ByVal gsID As String, ByVal prSelect As Boolean, ByVal prDate As String, ByVal prCode As String, ByVal prOrg_Amount As Double, ByVal prDisc_date As String, ByVal prACCOUNTS_RECEIVABLE_ID As Integer, ByVal prBalance_due As String, ByVal prDiscount As Double, ByVal prPayment As Double, ByVal prInvoice_ID As String, ByVal prDISCOUNT_ACCOUNT_ID As String)
        If dgvInvoice.Rows.Count <> 0 Then
            Dim i As Integer = dgvInvoice.CurrentRow.Index
            With dgvInvoice.Rows(i)
                .Cells("ID").Value = gsID
                .Cells("SELECTED").Value = prSelect
                .Cells("DATE").Value = prDate
                .Cells("NUMBER").Value = prCode
                .Cells("ORG_AMOUNT").Value = NumberFormatStandard(prOrg_Amount)
                .Cells("DISC_DATE").Value = prDisc_date
                .Cells("ACCOUNTS_RECEIVABLE_ID").Value = prACCOUNTS_RECEIVABLE_ID
                .Cells("BALANCE_DUE").Value = NumberFormatStandard(prBalance_due)
                .Cells("DISCOUNT").Value = NumberFormatStandard(prDiscount)
                .Cells("BALANCE_REMAINING").Value = NumIsNull(.Cells("BALANCE_DUE").Value)
                .Cells("PAYMENT").Value = NumberFormatStandard(prPayment)
                .Cells("INVOICE_ID").Value = prInvoice_ID
                .Cells("DISCOUNT_ACCOUNT_ID").Value = TextIsNull(prDISCOUNT_ACCOUNT_ID)
            End With
        End If
    End Sub
    Private Sub fCustomer_Invoice(ByVal prCustomer_ID As String, ByVal LOCATION_ID As Integer)
        dgvInvoice.Rows.Clear()
        dgvInvoice.Columns("SELECTED").Width = 30
        dtpDATE.Checked = True
        Try
            Dim nSQL As String = $"SELECT 
  i.ID,
  i.DATE,
  i.CODE,
  i.DISCOUNT_DATE,
  i.DUE_DATE,
  i.AMOUNT,
  i.`BALANCE_DUE`,
  i.`ACCOUNTS_RECEIVABLE_ID`
FROM
  invoice AS i 
WHERE  EXISTS 
  (SELECT 
    pv.`INVOICE_ID` AS ID 
  FROM
    `payment_invoices` AS pv 
    INNER JOIN `payment` AS p 
      ON p.id = pv.`PAYMENT_ID`
  WHERE  p.`CUSTOMER_ID` = '{prCustomer_ID}' AND p.ID ='{ID}') 
  AND i.`CUSTOMER_ID` ='{prCustomer_ID}' OR i.`BALANCE_DUE` >='0' AND i.`CUSTOMER_ID` ='{prCustomer_ID}'  LIMIT 1000;"

            Dim rd As OdbcDataReader = SqlReader(nSQL)

            While rd.Read
                Dim invoice_ID As String = rd("ID")
                Dim dPayment As Double = 0



                Dim sLine_ID As String = ""
                Dim dDiscount As Double = 0
                Dim sDISCOUNT_ACCOUNT_ID As String = ""


                fGetAppliedPayment(invoice_ID, ID, sLine_ID, dPayment, dDiscount, sDISCOUNT_ACCOUNT_ID)

                Dim dBalance As Double = NumIsNull(rd("BALANCE_DUE")) + dPayment


                Dim bSelected As Boolean = False
                If dPayment <> 0 Then
                    bSelected = True
                End If


                'Open New Item Transaction
                If dBalance > 0 Then

                    fAdditem(sLine_ID, bSelected, rd("Date"), rd("CODE"), rd("AMOUNT"), DateIsNull(rd("DISCOUNT_DATE")), DateIsNull(rd("DUE_DATE")), NumIsNull(rd("ACCOUNTS_RECEIVABLE_ID")), dBalance, dDiscount, dPayment, invoice_ID, sDISCOUNT_ACCOUNT_ID)

                End If
            End While
            rd.Close()

            fCheckInvoice()

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fCustomer_Invoice(prCustomer_ID, LOCATION_ID)
            Else
                End
            End If
        End Try




    End Sub
    Private Sub fGetAppliedPayment(ByVal prInvoice_ID As String, ByVal prPayment_ID As String, ByRef refPayment_ID_Line As String, ByRef refPayment_Applied As Double, ByRef refDiscount As Double, ByRef refDISCOUNT_ACCOUNT_ID As String)

        Try

            Dim sQuery As String = "Select ID,AMOUNT_APPLIED,DISCOUNT,DISCOUNT_ACCOUNT_ID,PENALTY_PAID from payment_invoices where payment_id = '" & prPayment_ID & "' and invoice_id = '" & prInvoice_ID & "' Limit 1"
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                refPayment_ID_Line = rd("ID")
                refPayment_Applied = NumIsNull(rd("AMOUNT_APPLIED"))
                refDiscount = NumIsNull(rd("DISCOUNT"))
                refDISCOUNT_ACCOUNT_ID = TextIsNull(rd("DISCOUNT_ACCOUNT_ID"))

            Else

                refPayment_Applied = 0
                refPayment_ID_Line = "N"
                refDiscount = 0
                refDISCOUNT_ACCOUNT_ID = ""
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fGetAppliedPayment(prInvoice_ID, prPayment_ID, refPayment_ID_Line, refPayment_Applied, refDiscount, refDISCOUNT_ACCOUNT_ID)
            Else
                End
            End If

        End Try

    End Sub
    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        Try
            fCustomer_Invoice(cmbCUSTOMER_ID.SelectedValue, cmbLOCATION_ID.SelectedValue)
        Catch ex As Exception

        End Try

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
        F.TabIndex = Val(gsDocument_Finder_ID)
        gsDocument_Finder_ID = 0

    End Sub
    Private Sub fCheckInvoice()
        Dim bNotSelected As Boolean = True
        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
            If dgvInvoice.Rows(i).Cells(1).Value = True Then
                bNotSelected = False
                Exit For
            End If
        Next

        numAMOUNT.Enabled = bNotSelected

        Dim dPayment As Double = 0
        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
            If dgvInvoice.Rows(i).Cells(1).Value = True Then
                dPayment = dPayment + (NumIsNull(dgvInvoice.Rows(i).Cells("PAYMENT").Value) + NumIsNull(dgvInvoice.Rows(i).Cells("DISCOUNT").Value))
            End If
        Next
        lblAMOUNT_APPLIED.Text = NumberFormatStandard(dPayment)
    End Sub
    Private Sub dgvInvoice_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellClick
        Try


            If e.ColumnIndex = 1 Then

                If dgvInvoice.Rows.Count = 0 Then
                    Exit Sub
                End If
                ' Requiredments
                Dim bPay As Double = 0

                If numAMOUNT.Value = 0 Then
                    MessageBoxExclamation("No amount Value")
                    Exit Sub
                Else
                    If NumIsNull(cmbPAYMENT_METHOD_ID.SelectedValue) = 0 Then
                        MessageBoxExclamation("Please select payment method")
                        Exit Sub
                    End If
                End If


                With dgvInvoice.Rows(e.RowIndex)
                    Dim b As Boolean = .Cells(1).Value

                    If b = True Then
                        b = False
                        bPay = 0

                    Else
                        b = True
                        bPay = numAMOUNT.Value
                        Dim dSelect_balance As Double = NumIsNull(.Cells("BALANCE_REMAINING").Value)
                        'get remaining amount
                        Dim dAmount_remain As Double = 0
                        Dim Balance_Due As Double = 0
                        Dim Remaining_balance As Double = 0
                        Dim dPayment As Double = 0

                        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
                            If dgvInvoice.Rows(i).Cells(1).Value = True And i <> e.RowIndex Then
                                dPayment = dPayment + (NumIsNull(dgvInvoice.Rows(i).Cells("PAYMENT").Value) + NumIsNull(dgvInvoice.Rows(i).Cells("DISCOUNT").Value))
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

                    fEdititem(.Cells(0).Value, b, .Cells(2).Value, .Cells(3).Value, .Cells(4).Value, .Cells(5).Value, .Cells("ACCOUNTS_RECEIVABLE_ID").Value, .Cells(8).Value, .Cells(9).Value, bPay, .Cells("INVOICE_ID").Value, .Cells("DISCOUNT_ACCOUNT_ID").Value)
                End With

                fCheckInvoice()
            End If
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Select Customer")
            Exit Sub
        End If

        If numAMOUNT.Value = 0 Then
            MessageBoxWarning("Payment Amount value is 0")
            Exit Sub
        End If


        If NumIsNull(cmbPAYMENT_METHOD_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select payment method")
            Exit Sub
        End If


        If fACCESS_NEW_EDIT(Me, IsNew) = False Then
            Exit Sub
        End If

        Dim bValue_is_checked As Boolean = False
        For i As Integer = 0 To dgvInvoice.Rows.Count - 1
            If dgvInvoice.Rows(i).Cells(1).Value = True Then
                bValue_is_checked = True
                Exit For
            End If
        Next


        If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then

            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("PAYMENT", cmbLOCATION_ID.SelectedValue)
            End If

            lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text = gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID

            ID = ObjectTypeMapId("payment")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO payment ({SQL_Field},ID,RECORDED_ON,STATUS,STATUS_DATE,DEPOSITED) VALUES ({SQL_Value},{ID},'{GetDateTimeNowSql()}',15,'{GetDateTimeNowSql()}',0) ")

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(numAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else



            tChangeAccept = True
            SqlExecuted("UPDATE payment SET " & SqlUpdate(Me) & " WHERE ID ='" & ID & "'")
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(numAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(Val(lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 41, ID, dtpDATE.Value, 0, NumberFormatFixed(lblAMOUNT_APPLIED.Text), gsJOURNAL_NO_FORM)
        End If
        '================================

        fPaymentSaving(dgvInvoice, ID, False, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, cmbCUSTOMER_ID.SelectedValue)

        If IsTransactionSuccess(ID, "PAYMENT") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        End If
        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If




        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            Else

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

    End Sub





    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click

        If fACCESS_FIND(Me) = False Then
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

        f.AccessibleName = "payment"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()

        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                ID = f.AccessibleDescription
                IsNew = False
                ''
                fClear_Info()
                If IsNew = False Then
                    dtpDATE.Checked = True
                    fRefreshInfo()
                End If
            End If
        End If

    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

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

    Private Sub btnDiscount_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnCredit_Click(sender As Object, e As EventArgs)

    End Sub
    Private Function fInvoiceBalance_Update(ByVal gsInvoice As String, prORG_Amount As Double) As Double

        Dim total_pay As Double = fGetSumPaymentApplied(gsInvoice, cmbCUSTOMER_ID.SelectedValue) + fGetSumCreditApplied(gsInvoice, cmbCUSTOMER_ID.SelectedValue) + fInvoiceSumTaxApplied_Amount(gsInvoice, cmbCUSTOMER_ID.SelectedValue)
        Dim New_Balance As Double = prORG_Amount - total_pay
        Dim squery As String
        Dim nStatus As Integer = 0
        If 0 >= New_Balance Then
            nStatus = 11
        Else
            nStatus = 2
        End If
        squery = "UPDATE invoice SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsInvoice & "'"
        SqlExecuted(squery)
        Return New_Balance
    End Function

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then

            If fACCESS_DELETE(Me) = False Then
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
                    Exit Sub
                End If
            End If

            If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            Try
                If MessageBoxQuestion(gsMessageQuestion) = True Then
                    CursorLoadingOn(True)


                    For i As Integer = 0 To dgvInvoice.Rows.Count - 1

                        With dgvInvoice.Rows(i)
                            .Cells("SELECTED").Value = False
                        End With
                    Next

                    fPaymentSaving(dgvInvoice, ID, False, cmbLOCATION_ID.SelectedValue, dtpDATE.Value, cmbCUSTOMER_ID.SelectedValue)

                    '===========================================
                    If gsSkipJournalEntry = False Then
                        gsJOURNAL_NO_FORM = 0
                        fAccount_journal_Delete(NumIsNull(lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 41, ID, dtpDATE.Value)
                    End If
                    '================================

                    SqlExecuted("DELETE FROM `payment` where ID = '" & ID & "' limit 1;")

                    PrompNotify(Me.Text, DeleteMsg, True)
                    fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(numAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                    IsNew = True
                    ID = 0
                    CursorLoadingOn(False)
                    fClear_Info()

                End If
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try


        End If
    End Sub

    Private Sub frmReceivePayment_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmReceivePayment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
            fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
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

    Private Sub SelectPagePrintToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPagePrintToolStripMenuItem.Click
        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        End If
        If IsNew = True Then Exit Sub
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
            fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
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
            fCryParameterInsertValue(gscryRpt, Val(ID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
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
        '5
        If IsNew = False Then
            Dim getACCOUNT_ID As Integer = 5
            Dim rd As OdbcDataReader = SqlReader($"select ACCOUNT_ID from account_journal where OBJECT_TYPE ='41' and OBJECT_ID ='{ID}' and OBJECT_DATE = '{DateFormatMySql(dtpDATE.Value)}' and ENTRY_TYPE ='0' and LOCATION_ID ='{cmbLOCATION_ID.SelectedValue}' limit 1 ")
            If rd.Read Then
                getACCOUNT_ID = NumIsNull(rd("ACCOUNT_ID"))
            End If
            rd.Close()
            fTransactionJournal(ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, 41, getACCOUNT_ID, cmbCUSTOMER_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(ID, Me)
    End Sub
    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, ID)
    End Sub
    Private Sub frmReceivePayment_TabIndexChanged(sender As Object, e As EventArgs) Handles Me.TabIndexChanged
        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If IsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        cmbCUSTOMER_ID_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsFindText.TextChanged
        fGetQuickFind(dgvInvoice, tsFindText.Text)
    End Sub

    Private Sub DiscountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiscountToolStripMenuItem.Click
        If dgvInvoice.Rows.Count = 0 Then
            MessageBoxWarning("Invoice not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvInvoice.CurrentRow.Index
        Dim d As DataGridViewRow = dgvInvoice.Rows(i)
        With frmDiscountInvoice
            .lblName.Text = cmbCUSTOMER_ID.Text
            .lblDATE.Text = d.Cells(2).Value
            .lblCreditUsed.Text = ""
            .lblCODE.Text = d.Cells(3).Value
            .lblAMOUNT.Text = NumberFormatStandard(NumIsNull(d.Cells("ORG_AMOUNT").Value))
            .lblAmount_Due.Text = NumberFormatStandard(NumIsNull(d.Cells("ORG_AMOUNT").Value) - NumIsNull(d.Cells("PAYMENT").Value))
            .lblBALANCE.Text = NumIsNull(d.Cells("ORG_AMOUNT").Value) - NumIsNull(d.Cells("PAYMENT").Value)
            .lblDISCOUNT_DATE.Text = d.Cells(5).Value
            .lblTERMS.Text = GetStringFieldValue("PAYMENT_TERMS", "ID", GetStringFieldValue("invoice", "ID", d.Cells("INVOICE_ID").Value, "PAYMENT_TERMS_ID"), "DESCRIPTION")
            .lblSuggested_Discount.Text = "0"
            .gsDISCOUNT_ACCOUNT_ID = d.Cells(10).Value
            .gsDISCOUNT_AMOUNT = d.Cells(7).Value
            .ShowDialog()
            If .gsOK = True Then
                d.Cells("DISCOUNT_ACCOUNT_ID").Value = .gsDISCOUNT_ACCOUNT_ID
                d.Cells("DISCOUNT").Value = NumberFormatStandard(.gsDISCOUNT_AMOUNT)
                fCheckInvoice()
            End If
            .Dispose()
        End With
        frmDiscountInvoice = Nothing
    End Sub

    Private Sub CreditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CreditToolStripMenuItem.Click
        If dgvInvoice.Rows.Count = 0 Then
            MessageBoxWarning("Invoice not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvInvoice.CurrentRow.Index
        Dim d As DataGridViewRow = dgvInvoice.Rows(i)
        With frmApplyCredits
            .gsID = d.Cells(9).Value
            .gsCustomer_ID = cmbCUSTOMER_ID.SelectedValue
            .gsLocation_ID = cmbLOCATION_ID.SelectedValue
            .lblName.Text = cmbCUSTOMER_ID.Text
            .lblCODE.Text = txtCODE.Text
            .lblDATE.Text = dtpDATE.Value
            .lblORG_AMOUNT.Text = NumberFormatStandard(d.Cells(4).Value)
            .gsBalance = NumberFormatFixed(d.Cells(4).Value - d.Cells(8).Value)

            .ShowDialog()
            If .gsOk = True Then
                'DO NOTHING
                Dim p As Double = NumberFormatFixed(d.Cells(8).Value)

                If MessageBoxQuestion("Do you want apply credit?") = True Then
                    Dim bd As Double = fInvoiceBalance_Update(d.Cells(9).Value, d.Cells(4).Value)
                    d.Cells(6).Value = NumberFormatStandard(bd + p)
                End If
            End If
            .Dispose()

        End With
        frmApplyCredits = Nothing
    End Sub
End Class