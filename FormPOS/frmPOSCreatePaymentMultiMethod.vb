﻿Imports System.Data.Odbc
Public Class FrmPOSCreatePaymentMultiMethod
    Public gsOK As Boolean = False
    Public gsID As Integer
    Public gsTABLE_NO As Integer
    Public gsORDER_TYPE As Integer
    Public gsCUSTOMER_ID As Integer
    Public gsFullPAYMENT_REQUIRED As Boolean = True
    Public gsBundle As Boolean = False

    Public dgvINVOICE_LIST As DataGridView
    Public gsPaymentMethodID As Integer = 1


    Public gsValue As String
    Public gsEnter As Boolean = False

    Private Sub FrmPOSCreatePaymentMultiMethod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PayMethodList()
        SetMethodList()
        xlblCustomer_Name.Text = GF_GetStringFieldValue("CONTACT", "id", gsCUSTOMER_ID, "NAME")
        gsOK = False
        txtRECEIPT_REF_NO.Text = GF_GetNextReceiptNumber()
        txtRECEIPT_REF_NO.ReadOnly = True
        dtpRECEIPT_DATE.Value = gsPOS_DATE
        dtpRECEIPT_DATE.Enabled = False

        dtpCARD_EXPIRY_DATE.Checked = False

        gsEnter = False
        SetValue()

        lblAMOUNT_APPLIED.Text = GetInvoiceAmount()
        xlblCHANGE.Text = "0.00"
        Computed()

    End Sub
    Private Function GetInvoiceAmount() As Double

        Dim ThisAMOUNT As Double = 0
        For N As Integer = 0 To dgvINVOICE_LIST.Rows.Count - 1
            Dim ThisInvoice_ID As Integer = dgvINVOICE_LIST.Rows(N).Cells(0).Value
            ThisAMOUNT += GF_GetNumberFieldValue("INVOICE", "ID", ThisInvoice_ID, "AMOUNT")
        Next

        Return ThisAMOUNT
    End Function

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
    Private Sub PayMethodList()
        With dgvMethod.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("METHOD", "METHOD")


        End With
        With dgvMethod.Rows
            .Clear()
            Dim rd As OdbcDataReader = SqlReader("SELECT ID,DESCRIPTION FROM PAYMENT_METHOD ")
            While rd.Read
                .Add(rd("ID"), rd("DESCRIPTION"))
            End While

        End With


    End Sub
    Private Sub SetMethodList()
        With dgvMethodSet
            .Columns.Clear()
            .Columns.Add("ID", "ID")
            .Columns.Item("ID").Visible = False
            .Columns.Add("METHOD", "METHOD")
            .Columns.Add("AMOUNT", "AMOUNT")
            .Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("AMOUNT").DefaultCellStyle.Format = "N2"
            .Columns("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
    End Sub
    Private Sub Computed()
        Dim TOTAL As Double = 0
        For I As Integer = 0 To dgvMethodSet.Rows.Count - 1
            TOTAL += dgvMethodSet.Rows(I).Cells("AMOUNT").Value
        Next

        lblAMOUNT.Text = NumberFormatStandard(TOTAL)
        Dim C As Double = TOTAL - GF_NumIsNull(lblAMOUNT_APPLIED.Text)
        If C <= 0 Then
            C = 0
        End If
        xlblCHANGE.Text = NumberFormatStandard(C)
    End Sub
    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If dgvMethodSet.Rows.Count = 0 Then
            MessageBoxInfo("No payment method found.")
            Exit Sub
        End If

        If GF_NumIsNull(lblAMOUNT.Text) < GF_NumIsNull(lblAMOUNT_APPLIED.Text) Then
            MessageBoxWarning("Invalid payment tender must higher value.")
            Exit Sub
        End If

        '==============================
        gsID = ObjectTypeMapId("payment")
        'MAIN
        Dim SQL_INSERT As String = $"INSERT INTO `payment`
SET `ID` = '{gsID}',
  `RECORDED_ON` = '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}',
  `CODE` = '{GF_GetNextCode("PAYMENT", gsDefault_LOCATION_ID)}',
  `DATE` = '{GetDateFormatMySql(gsPOS_DATE)}',
  `CUSTOMER_ID` = '{gsCUSTOMER_ID}',
  `LOCATION_ID` = '{gsDefault_LOCATION_ID}',
  `AMOUNT` = '{GF_NumIsNull(lblAMOUNT.Text)}',
  `AMOUNT_APPLIED` = '{ GF_NumIsNull(lblAMOUNT_APPLIED.Text)}',
  `PAYMENT_METHOD_ID` = '{gsPaymentMethodID}',
  `CARD_NO` = '{txtCARD_NO.Text}',
  `CARD_EXPIRY_DATE` = {IIf(dtpCARD_EXPIRY_DATE.Checked = True, $"'{GetDateFormatMySql(dtpCARD_EXPIRY_DATE.Value)}'", "null")},
  `RECEIPT_REF_NO` = '{txtRECEIPT_REF_NO.Text}',
  `RECEIPT_DATE` = {IIf(dtpRECEIPT_DATE.Checked = True, $"'{GetDateFormatMySql(dtpRECEIPT_DATE.Value)}'", "null")},
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
        '================================
        'ITEM


        For N As Integer = 0 To dgvINVOICE_LIST.Rows.Count - 1
            Dim ThisID As Integer = ObjectTypeMapId("PAYMENT_INVOICES")
            Dim ThisInvoice_ID As Integer = dgvINVOICE_LIST.Rows(N).Cells(0).Value
            Dim ThisAMOUNT As Double = GF_GetNumberFieldValue("INVOICE", "ID", ThisInvoice_ID, "AMOUNT")

            SqlExecuted($"INSERT INTO `payment_invoices`
   SET `ID` = '{ThisID}',
  `PAYMENT_ID` = '{gsID}',
  `INVOICE_ID` = '{ThisInvoice_ID}',
  `DISCOUNT` = NULL,
  `AMOUNT_APPLIED` = '{ThisAMOUNT}',
  `DISCOUNT_ACCOUNT_ID` = NULL,
  `ACCOUNTS_RECEIVABLE_ID` = '{gsDefault_ACCOUNTS_RECEIVABLE_ID}',
  `PENALTY_PAID` = NULL;")

            '======================================================
            If gsSkipJournalEntry = False Then
                GS_AccountJournalExecute(gsDefault_ACCOUNTS_RECEIVABLE_ID, gsDefault_LOCATION_ID, ThisInvoice_ID, 42, ThisID, gsPOS_DATE, 1, ThisAMOUNT, gsJOURNAL_NO_FORM)
            End If
            '=====================================================
            SetUpdateInvoiceBalance(ThisInvoice_ID, gsCUSTOMER_ID)
        Next

        For I As Integer = 0 To dgvMethodSet.Rows.Count - 1
            SqlExecuted($"INSERT INTO payment_multi_method SET PAYMENT_ID = '{gsID}',PAYMENT_METHOD_ID ='{ dgvMethodSet.Rows(I).Cells("ID").Value }',AMOUNT_APPLIED='{dgvMethodSet.Rows(I).Cells("AMOUNT").Value}'")
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

        GS_CollectPosLogResto()
        GS_PosLogLoad()

        Me.Close()
    End Sub
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

    Private Sub SetValue()

        GetLimit()
        xxlblValue.Text = gsValue

    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        gsValue &= "0"
        SetValue()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gsValue &= "1"
        SetValue()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gsValue &= "2"
        SetValue()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gsValue &= "3"
        SetValue()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        gsValue &= "4"
        SetValue()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        gsValue &= "5"
        SetValue()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gsValue &= "6"
        SetValue()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        gsValue &= "7"
        SetValue()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        gsValue &= "8"
        SetValue()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        gsValue &= "9"
        SetValue()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If gsValue.Contains(".") = True Then

        Else
            gsValue &= "."
            SetValue()
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            Dim L As Integer = GF_NumIsNull(gsValue.Length)
            If L = 0 Then
                gsValue = ""
            Else
                gsValue = gsValue.ToString.Remove(L - 1)
            End If
        Catch ex As Exception

        End Try


        SetValue()
    End Sub

    Private Sub GetLimit()
        If gsValue = "" Then
            Exit Sub
        End If
        Dim got_point As Boolean = False
        Dim got_point_i As Integer = 0
        Dim Get_Collect As String = ""
        For N As Integer = 0 To gsValue.Length - 1

            If gsValue.Substring(N, 1) = "." Then
                got_point = True
                Get_Collect &= gsValue.Substring(N, 1)
            Else
                If got_point = True Then
                    If got_point_i < 2 Then
                        Get_Collect &= gsValue.Substring(N, 1)

                    Else
                        Exit For
                    End If
                    got_point_i += 1
                Else
                    Get_Collect &= gsValue.Substring(N, 1)
                End If

            End If

            If N > 10 Then
                Exit For
            End If
        Next

        gsValue = Get_Collect
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        If dgvMethodSet.Rows.Count = 0 Then
            Exit Sub
        End If

        With dgvMethodSet.CurrentRow
            dgvMethod.Rows.Add(.Cells("ID").Value, .Cells("METHOD").Value)
            dgvMethodSet.Rows.RemoveAt(.Index)
        End With

        Computed()
    End Sub

    Private Sub BtnAdded_Click(sender As Object, e As EventArgs) Handles btnAdded.Click
        If GF_NumIsNull(xxlblValue.Text) = 0 Then
            MessageBoxExclamation($"No {xxMETHOD_LABEL.Text} Value ")
            Exit Sub
        End If

        If dgvMethod.Rows.Count = 0 Then Exit Sub

        With dgvMethod.CurrentRow
            dgvMethodSet.Rows.Add(.Cells("ID").Value, .Cells("METHOD").Value, NumberFormatStandard(GF_NumIsNull(xxlblValue.Text)))
            xxlblValue.Text = ""
            gsValue = ""
            dgvMethod.Rows.RemoveAt(.Index)
        End With

        Computed()
    End Sub
    Private Sub DgvMethod_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMethod.SelectionChanged
        If dgvMethod.Rows.Count <> 0 Then
            xxMETHOD_LABEL.Text = dgvMethod.CurrentRow.Cells("METHOD").Value
        Else
            xxMETHOD_LABEL.Text = ""
        End If
    End Sub
    Private Sub TxtCARD_NO_Click(sender As Object, e As EventArgs) Handles txtCARD_NO.Click
        KeyBoardToTouch(txtCARD_NO, "CARD NO.")
    End Sub
    Private Sub TxtNOTES_Click(sender As Object, e As EventArgs) Handles txtNOTES.Click
        KeyBoardToTouch(txtNOTES, "NOTES")
    End Sub
End Class