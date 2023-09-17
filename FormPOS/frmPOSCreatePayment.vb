Imports System.Data.Odbc
Public Class FrmPOSCreatePayment
    Public gsOK As Boolean = False
    Public gsID As Integer
    Public gsTABLE_NO As Integer
    Public gsORDER_TYPE As Integer
    Public gsCUSTOMER_ID As Integer
    Public gsFullPAYMENT_REQUIRED As Boolean = True
    Public gsBundle As Boolean = False

    Private Function GetNextLogSerialNumber() As Integer
        Dim i As Integer = 0
        Dim rd As OdbcDataReader = SqlReader("select NEXT_LOG_SERIAL_NO from POS_MACHINE where ID = '" & gsPOS_MACHINE_ID & "' limit 1")
        If rd.Read Then
            i = GF_NumIsNull(rd("NEXT_LOG_SERIAL_NO"))
        End If
        rd.Close()
        SqlExecuted("Update pos_machine set NEXT_LOG_SERIAL_NO = '" & i + 1 & "' where ID ='" & gsPOS_MACHINE_ID & "' limit 1 ")
        Return 1
    End Function
    Private Sub Computed()
        Dim A As Double = 0
        Dim NS As Integer = 0

        For N As Integer = 0 To dgvAVAILABLE.Rows.Count - 1
            NS += GF_NumIsNull(dgvAVAILABLE.Rows(N).Cells("AMOUNT").Value)
        Next
        xlblAV_AMOUNT.Text = NumberFormatStandard(NS)

        For I As Integer = 0 To dgvSELECTED.Rows.Count - 1
            A += GF_NumIsNull(dgvSELECTED.Rows(I).Cells("AMOUNT_APPLIED").Value)
        Next
        lblAMOUNT_APPLIED.Text = NumberFormatStandard(A)

        Dim C As Double = A - numAMOUNT.Value
        If numAMOUNT.Value < A Then
            C = 0
        End If

        xlblCHANGE.Text = NumberFormatStandard(C)
    End Sub
    Private Sub FrmPOSServed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsFullPAYMENT_REQUIRED = True Then

        End If
        numAMOUNT.Value = 0
        xlblCustomer_Name.Text = GF_GetStringFieldValue("CONTACT", "id", gsCUSTOMER_ID, "NAME")
        Computed()

        GS_ComboBoxLoad(cmbPAYMENT_METHOD_ID, "SELECT ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")
        cmbPAYMENT_METHOD_ID.SelectedIndex = 0
        gsOK = False
        'Create ColumnView
        With dgvAVAILABLE.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("CODE", "SERVED NO.")
            .Add("AMOUNT", "AMOUNT")
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        With dgvSELECTED.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("CODE", "SERVED NO.")

            .Add("AMOUNT", "AMOUNT")
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").Visible = False

            .Add("AMOUNT_APPLIED", "AMT. APPLIED")
            .Item("AMOUNT_APPLIED").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT_APPLIED").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT_APPLIED").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End With

        AvailableInvoiceLoad()
        Computed()

        txtRECEIPT_REF_NO.Text = GF_GetNextReceiptNumber()
        txtRECEIPT_REF_NO.Enabled = False
        dtpRECEIPT_DATE.Value = gsPOS_DATE

        dtpRECEIPT_DATE.Enabled = False
        CmbPAYMENT_METHOD_ID_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub AvailableInvoiceLoad()
        dgvAVAILABLE.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT s.ID,s.CODE, s.AMOUNT FROM invoice as S  WHERE  s.CUSTOMER_ID ='{gsCUSTOMER_ID}' and s.LOCATION_ID ='{gsDefault_LOCATION_ID}' and s.SHIP_TO ='{gsTABLE_NO}'  and s.SHIP_VIA_ID='{gsORDER_TYPE}' and s.STATUS in('13')")
        While rd.Read
            dgvAVAILABLE.Rows.Add(rd(0), rd(1), rd(2))
        End While
        rd.Close()

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub GotAmountApplied(ByVal INVOICE_ID As Integer, ByRef BALANCE As Double)

        'Check History Payment
        Dim PAY_AMT As Double
        Dim rd As OdbcDataReader = SqlReader($"select sum(AMOUNT_APPLIED) as `PAY` from payment_invoices WHERE INVOICE_ID = '{INVOICE_ID}' ")
        If rd.Read Then
            PAY_AMT = GF_NumIsNull(rd("PAY"))
        End If
        rd.Close()

        BALANCE -= PAY_AMT

    End Sub
    Private Function IsTenderMustHigher() As Boolean

        Dim AMT As Double = numAMOUNT.Value
        Dim Get_Amount As Double = 0

        For N As Integer = 0 To dgvAVAILABLE.Rows.Count - 1
            Get_Amount += dgvAVAILABLE.Rows(N).Cells("AMOUNT").Value
        Next

        For N As Integer = 0 To dgvSELECTED.Rows.Count - 1
            Get_Amount += dgvSELECTED.Rows(N).Cells("AMOUNT").Value
        Next

        If Get_Amount > AMT Then

            Return False
        Else
            Return True
        End If

    End Function
    Private Sub BtnAddAll_Click(sender As Object, e As EventArgs) Handles btnAddAll.Click
        Dim DEPOSIT_AMT As Double = GetRemainingDeposit()

        For S As Integer = 0 To dgvAVAILABLE.Rows.Count - 1

            Dim A As DataGridViewRow = dgvAVAILABLE.Rows(0)
            Dim BALANCE As Double = GF_NumIsNull(A.Cells(2).Value)
            Dim AMT_APPLIED As Double
            GotAmountApplied(A.Cells(0).Value, BALANCE)
            If DEPOSIT_AMT > BALANCE Then
                AMT_APPLIED = BALANCE
                DEPOSIT_AMT -= AMT_APPLIED
            Else
                AMT_APPLIED = DEPOSIT_AMT
                DEPOSIT_AMT -= AMT_APPLIED
            End If

            If AMT_APPLIED > 0 Then
                dgvSELECTED.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value, AMT_APPLIED)
                dgvAVAILABLE.Rows.RemoveAt(0)
            ElseIf IsGotBundle() = True Then
                dgvSELECTED.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value, AMT_APPLIED)
                dgvAVAILABLE.Rows.RemoveAt(0)

            End If

        Next

        Computed()

    End Sub

    Private Sub BtnRemoveAll_Click(sender As Object, e As EventArgs) Handles btnRemoveAll.Click
        For S As Integer = 0 To dgvSELECTED.Rows.Count - 1
            Dim A As DataGridViewRow = dgvSELECTED.Rows(0)
            dgvAVAILABLE.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value)
            dgvSELECTED.Rows.RemoveAt(0)
        Next
        Computed()
    End Sub
    Private Function GetRemainingDeposit() As Double
        Dim D As Double = numAMOUNT.Value
        For I As Integer = 0 To dgvSELECTED.Rows.Count - 1
            D -= GF_NumIsNull(dgvSELECTED.Rows(I).Cells("AMOUNT_APPLIED").Value)
        Next

        Return D

    End Function
    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvAVAILABLE.Rows.Count = 0 Then Exit Sub
        Dim DEPOSIT_AMT As Double = GetRemainingDeposit()
        dgvAVAILABLE.Select()
        Dim A As DataGridViewRow = dgvAVAILABLE.CurrentRow

        Dim BALANCE As Double = GF_NumIsNull(A.Cells(2).Value)
        Dim AMT_APPLIED As Double
        GotAmountApplied(A.Cells(0).Value, BALANCE)
        If DEPOSIT_AMT > BALANCE Then
            AMT_APPLIED = BALANCE
        Else
            AMT_APPLIED = DEPOSIT_AMT
        End If

        If AMT_APPLIED > 0 Then
            dgvSELECTED.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value, AMT_APPLIED)
            dgvAVAILABLE.Rows.RemoveAt(dgvAVAILABLE.CurrentRow.Index)
        ElseIf IsGotBundle() = True Then
            dgvSELECTED.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value, AMT_APPLIED)
            dgvAVAILABLE.Rows.RemoveAt(dgvAVAILABLE.CurrentRow.Index)
        End If


        Computed()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvSELECTED.Rows.Count = 0 Then Exit Sub
        dgvSELECTED.Select()
        Dim A As DataGridViewRow = dgvSELECTED.CurrentRow
        dgvAVAILABLE.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value)
        dgvSELECTED.Rows.RemoveAt(dgvSELECTED.CurrentRow.Index)
        Computed()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        gsBundle = False
        If numAMOUNT.Value = 0 Then

            If IsGotBundle() = False Then
                MessageBoxInfo("Please enter tender amount")
                Exit Sub
            Else
                If MessageBoxPointOfSalesYesNO("Do you want to served this bundle?") = False Then
                    Exit Sub
                Else
                    gsBundle = True
                End If
            End If
        End If


        If gsFullPAYMENT_REQUIRED = True Then
            If IsTenderMustHigher() = False Then
                Exit Sub
            End If
        End If



        If dgvAVAILABLE.Rows.Count <> 0 And dgvSELECTED.Rows.Count = 0 Then
            Dim N As Double = 0
            For A As Integer = 0 To dgvAVAILABLE.Rows.Count - 1
                N += dgvAVAILABLE.Rows(A).Cells("AMOUNT").Value
            Next

            If N <= numAMOUNT.Value Then
                btnAddAll.PerformClick()
                GS_DoEvents()
            End If
        End If


        If dgvSELECTED.Rows.Count = 0 Then
            MessageBoxInfo("No served selected.")
            Exit Sub

        End If

        If dgvAVAILABLE.Rows.Count > 1 And IsGotBundle() = False Then
            If MessageBoxPointOfSalesYesNO("Are you sure create this payment?") = False Then
                Exit Sub
            End If
        End If



        gsID = ObjectTypeMapId("payment")
        'MAIN
        Dim SQL_INSERT As String = $"INSERT INTO `payment`
SET `ID` = '{gsID}',
  `RECORDED_ON` = '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}',
  `CODE` = '{GF_GetNextCode("PAYMENT", gsDefault_LOCATION_ID)}',
  `DATE` = '{DateFormatMySql(gsPOS_DATE)}',
  `CUSTOMER_ID` = '{gsCUSTOMER_ID}',
  `LOCATION_ID` = '{gsDefault_LOCATION_ID}',
  `AMOUNT` = '{numAMOUNT.Value}',
  `AMOUNT_APPLIED` = '{ GF_NumIsNull(lblAMOUNT_APPLIED.Text)}',
  `PAYMENT_METHOD_ID` = '{cmbPAYMENT_METHOD_ID.SelectedValue}',
  `CARD_NO` = '{txtCARD_NO.Text}',
  `CARD_EXPIRY_DATE` = {IIf(dtpCARD_EXPIRY_DATE.Checked = True, $"'{DateFormatMySql(dtpCARD_EXPIRY_DATE.Value)}'", "null")},
  `RECEIPT_REF_NO` = '{txtRECEIPT_REF_NO.Text}',
  `RECEIPT_DATE` = {IIf(dtpRECEIPT_DATE.Checked = True, $"'{DateFormatMySql(dtpRECEIPT_DATE.Value)}'", "null")},
  `NOTES` = '{txtNOTES.Text}',
  `UNDEPOSITED_FUNDS_ACCOUNT_ID` = '{gsDRAWER_ACCOUNT_ID}',
  `OVERPAYMENT_ACCOUNT_ID` = NULL,
  `STATUS` = '15',
  `STATUS_DATE` = '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}',
  `DEPOSITED` = '0',
  `POS_LOG_ID` = '{gsPOS_LOG_ID}',
  `POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}',
  `CASH_COUNT_ID` = NULL,
  `ACCOUNTS_RECEIVABLE_ID` = '{gsDefault_ACCOUNTS_RECEIVABLE_ID}';"

        SqlExecuted(SQL_INSERT)

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            GS_AccountJournalExecute(gsDRAWER_ACCOUNT_ID, gsDefault_LOCATION_ID, gsCUSTOMER_ID, 41, gsID, gsPOS_DATE, 0, NumberFormatFixed(lblAMOUNT_APPLIED.Text), gsJOURNAL_NO_FORM)

        End If

        'ITEM

        For I As Integer = 0 To dgvSELECTED.Rows.Count - 1
            Dim ThisID As Integer = ObjectTypeMapId("PAYMENT_INVOICES")
            SqlExecuted($"INSERT INTO `payment_invoices`
SET `ID` = '{ThisID}',
  `PAYMENT_ID` = '{gsID}',
  `INVOICE_ID` = '{ GF_NumIsNull(dgvSELECTED.Rows(I).Cells("ID").Value)}',
  `DISCOUNT` = NULL,
  `AMOUNT_APPLIED` = '{GF_NumIsNull(dgvSELECTED.Rows(I).Cells("AMOUNT_APPLIED").Value)}',
  `DISCOUNT_ACCOUNT_ID` = NULL,
  `ACCOUNTS_RECEIVABLE_ID` = '{gsDefault_ACCOUNTS_RECEIVABLE_ID}',
  `PENALTY_PAID` = NULL;")

            SetUpdateInvoiceBalance(GF_NumIsNull(dgvSELECTED.Rows(I).Cells("ID").Value), gsCUSTOMER_ID)
            '======================================================
            If gsSkipJournalEntry = False Then
                GS_AccountJournalExecute(gsDefault_ACCOUNTS_RECEIVABLE_ID, gsDefault_LOCATION_ID, GF_NumIsNull(dgvSELECTED.Rows(I).Cells("ID").Value), 42, ThisID, gsPOS_DATE, 1, GF_NumIsNull(dgvSELECTED.Rows(I).Cells("AMOUNT_APPLIED").Value), gsJOURNAL_NO_FORM)
            End If
            '=====================================================
        Next

        GS_UpdateNextReceiptNumber()
        'Update INVOICE AND SALES_ORDER
        gsOK = True
        ' POS _LOG UPDATE

        If gsSTARTING_RECEIPT_NO = 0 Then
            gsSTARTING_RECEIPT_NO = Val(txtRECEIPT_REF_NO.Text)
            gsENDING_RECEIPT_NO = gsSTARTING_RECEIPT_NO
        Else
            gsENDING_RECEIPT_NO = Val(txtRECEIPT_REF_NO.Text)
        End If


        If gsDINE_IN_ID <> gsORDER_TYPE Then
            SqlExecuted($"INSERT INTO pos_table_served SET order_type_id='{gsORDER_TYPE}', RECORDED_ON = '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}', PAYMENT_ID ='{gsID}',IS_ACTIVE='-1',CASHIER_ID='{gsCashier_ID}', POS_LOG_ID = '{gsPOS_LOG_ID}',TABLE_NO='{gsTABLE_NO}';")

        End If

        GS_CollectPosLogResto()
        GS_PosLogLoad()

        Me.Close()


    End Sub
    Private Function IsGotBundle() As Boolean
        Dim N As Integer = 0
        For A As Integer = 0 To dgvAVAILABLE.Rows.Count - 1
            N += dgvAVAILABLE.Rows(A).Cells("AMOUNT").Value
        Next
        For A As Integer = 0 To dgvSELECTED.Rows.Count - 1
            N += dgvSELECTED.Rows(A).Cells("AMOUNT").Value
        Next
        If N = 0 Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub SetUpdateInvoiceBalance(ByVal prInvoice_ID As String, ByVal prCustomer_ID As String)

        Dim dTotal_Payment As Double = GF_GetSumPaymentApplied(prInvoice_ID, prCustomer_ID) + GF_GetSumCreditApplied(prInvoice_ID, prCustomer_ID) + GF_InvoiceSumTaxApplied_Amount(prInvoice_ID, prCustomer_ID)
        Dim dTotal_Amount As Double = GF_GetNumberFieldValue("INVOICE", "ID", prInvoice_ID, "AMOUNT")
        Dim dTotal_Balance As Double = dTotal_Amount - dTotal_Payment
        Dim nStatus As Integer
        If 0 >= dTotal_Balance Then
            'PAID
            nStatus = 11
            'SERVICE
            SetUpdateSalesOrderUsingInvoice(prInvoice_ID)
        Else
            'NOT PAID
            nStatus = 13
        End If

        SqlExecuted("UPDATE invoice SET BALANCE_DUE ='" & NumberFormatFixed(dTotal_Balance) & "',STATUS='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE Customer_ID ='" & prCustomer_ID & "' and ID ='" & prInvoice_ID & "' limit 1;")
    End Sub
    Private Sub SetUpdateSalesOrderUsingInvoice(ByVal INVOICE_ID As Integer)
        Dim TMP_SO_ID As Integer = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT soi.`SALES_ORDER_ID` FROM invoice_items AS ii INNER JOIN sales_order_items AS soi ON soi.`ID` = ii.`REF_LINE_ID`  AND ii.`ITEM_ID` = soi.`ITEM_ID` WHERE ii.`INVOICE_ID` ='{INVOICE_ID}' order by soi.`SALES_ORDER_ID`")
        While rd.Read
            If TMP_SO_ID <> GF_NumIsNull(rd("SALES_ORDER_ID")) Then
                SqlExecuted($"UPDATE sales_order SET STATUS ='14',STATUS_DATE= '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}' WHERE ID ='{GF_NumIsNull(rd("SALES_ORDER_ID"))}' limit 1;")
            End If

            TMP_SO_ID = GF_NumIsNull(rd("SALES_ORDER_ID"))
        End While
        rd.Close()



    End Sub
    Private Sub NumAMOUNT_ValueChanged(sender As Object, e As EventArgs) Handles numAMOUNT.ValueChanged
        Computed()
    End Sub

    Private Sub CmbPAYMENT_METHOD_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedIndexChanged
        Try

            Dim I As Integer = GF_NumIsNull(cmbPAYMENT_METHOD_ID.SelectedValue)




            Select Case I
                Case 1 'Cash
                    OR_No.Visible = True
                    txtRECEIPT_REF_NO.Visible = True
                    OR_DATE.Visible = True
                    dtpRECEIPT_DATE.Visible = True


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

    Private Sub BtnP_P_Click(sender As Object, e As EventArgs) Handles btnP_P.Click
        Try
            cmbPAYMENT_METHOD_ID.SelectedIndex = cmbPAYMENT_METHOD_ID.SelectedIndex + 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnP_N_Click(sender As Object, e As EventArgs) Handles btnP_N.Click
        Try
            cmbPAYMENT_METHOD_ID.SelectedIndex = cmbPAYMENT_METHOD_ID.SelectedIndex - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumAMOUNT_Click(sender As Object, e As EventArgs) Handles numAMOUNT.Click
        NumberPadKeyToTouch(numAMOUNT, xlblAMOUNT.Text)
    End Sub

    Private Sub BtnNumberKEY_Click(sender As Object, e As EventArgs) Handles btnNumberKEY.Click
        NumberPadKeyToTouch(numAMOUNT, xlblAMOUNT.Text)
    End Sub
    Private Sub TxtRECEIPT_REF_NO_Click(sender As Object, e As EventArgs) Handles txtRECEIPT_REF_NO.Click
        KeyBoardToTouch(txtRECEIPT_REF_NO, OR_No.Text)
    End Sub
    Private Sub TxtCARD_NO_Click(sender As Object, e As EventArgs) Handles txtCARD_NO.Click
        KeyBoardToTouch(txtCARD_NO, CARD_NO.Text)
    End Sub

    Private Sub NumAMOUNT_TextChanged(sender As Object, e As EventArgs) Handles numAMOUNT.TextChanged
        Computed()
    End Sub
    Private Sub TxtNOTES_Click(sender As Object, e As EventArgs) Handles txtNOTES.Click
        KeyBoardToTouch(txtNOTES, "NOTES")
    End Sub

    Private Sub FrmPOSCreatePayment_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If btnNumberKEY.Visible = True Then
            btnNumberKEY.PerformClick()
        End If

    End Sub

End Class