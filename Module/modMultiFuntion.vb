﻿Imports System.Data.Odbc
Module modMultiFuntion
    Public Sub GS_ColumnGrid_U_SalesOrder(ByVal dgvProductItem As DataGridView)
        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = gsCUSTOM_TAX,
            .Name = "TAX"
        }

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", gsCUSTOM_CODE) '1
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '2
            .Add("QTY", gsCUSTOM_QTY) '3
            .Add("UM", gsCUSTOM_UNIT) '4
            .Add("UNIT_PRICE", gsCUSTOM_RATE) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8
            .Add(chk) '9

            .Add("UNIT_ID", "UNIT_ID") '10
            .Item("UNIT_ID").Visible = False

            .Add("CONTROL_STATUS", "CONTROL_STATUS") '11
            .Item("CONTROL_STATUS").Visible = False

            ' Control_Status_value
            ' S - Stable
            ' A - Added
            ' E - Editted
            ' D - Deleted

            .Add("RATE_TYPE", "RATE_TYPE") '12
            .Item("RATE_TYPE").Visible = False

            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '13
            .Item("UNIT_QUANTITY_BASE").Visible = False

            .Add("DISCOUNT_ID", "DISCOUNT_ID") '14
            .Item("DISCOUNT_ID").Visible = False

            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '15
            .Item("TAXABLE_AMOUNT").Visible = False

            .Add("TAX_AMOUNT", "TAX_AMOUNT") '16
            .Item("TAX_AMOUNT").Visible = False


            .Add("ESTIMATE_LINE_ID", "ESTIMATE_LINE_ID") '17
            .Item("ESTIMATE_LINE_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '18
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '19
            .Item("ITEM_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL") '20
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") '21
            .Item("ITEM_TYPE").Visible = False

            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") ' 22
            .Item("PRINT_IN_FORMS").Visible = False

            .Add("GROUP_LINE_ID", "GROUP_LINE_ID") '23
            .Item("GROUP_LINE_ID").Visible = False
        End With
    End Sub
    Public Sub ColumnGrid_U_SalesReceipt(ByVal dgvProductItem As DataGridView)
        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = gsCUSTOM_TAX,
            .Name = "TAX"
        }

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item("ID").Visible = False
            .Add("CODE", gsCUSTOM_CODE) '1
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '2
            .Add("QTY", gsCUSTOM_QTY) '3
            .Add("UM", gsCUSTOM_UNIT) '4
            .Add("UNIT_PRICE", gsCUSTOM_RATE) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8
            .Add(chk) '9
            .Add("UNIT_ID", "UNIT_ID") '10
            .Item("UNIT_ID").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS") '11
            .Item("CONTROL_STATUS").Visible = False
            ' Control_Status_value
            ' S - Stable
            ' A - Added
            ' E - Editted
            ' D - Deleted
            .Add("RATE_TYPE", "RATE_TYPE") '12
            .Item("RATE_TYPE").Visible = False

            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '13
            .Item("UNIT_QUANTITY_BASE").Visible = False

            .Add("DISCOUNT_ID", "DISCOUNT_ID") '14
            .Item("DISCOUNT_ID").Visible = False

            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '15
            .Item("TAXABLE_AMOUNT").Visible = False

            .Add("TAX_AMOUNT", "TAX_AMOUNT") '16
            .Item("TAX_AMOUNT").Visible = False

            .Add("COGS_ACCOUNT_ID", "COGS_ACCOUNT_ID") '17
            .Item("COGS_ACCOUNT_ID").Visible = False

            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID") '18
            .Item("ASSET_ACCOUNT_ID").Visible = False

            .Add("INCOME_ACCOUNT_ID", "INCOME_ACCOUNT_ID") '19
            .Item("INCOME_ACCOUNT_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL_ID") '20
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '21
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '22
            .Item("ITEM_ID").Visible = False
            '================================================================
            .Add("POS_TRX_TYPE", "POS_TRX_TYPE") '23
            .Item("POS_TRX_TYPE").Visible = False
            .Add("POS_EDIT_QTY", "POS_EDIT_QTY") '24
            .Item("POS_EDIT_QTY").Visible = False
            .Add("POS_NOTES", "POS_NOTES") '25
            .Item("POS_NOTES").Visible = False
            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") '26
            .Item("PRINT_IN_FORMS").Visible = False
            .Add("DEPOSITED", "DEPOSITED") '27
            .Item("DEPOSITED").Visible = False
            .Add("ITEM_TYPE", "ITEM_TYPE") '28
            .Item("ITEM_TYPE").Visible = False
            .Add("NON_DISCOUNTED_ITEM", "NON_DISCOUNTED_ITEM") '29
            .Item("NON_DISCOUNTED_ITEM").Visible = False
            .Add("GROUP_LINE_ID", "GROUP_LINE_ID") ' 30
            .Item("GROUP_LINE_ID").Visible = False

            .Add("BATCH_ID", "BATCH_ID") '31
            .Item("BATCH_ID").Visible = False

            .Add("BATCH_NO", gsCUSTOM_BATCH) '32
            .Item("BATCH_NO").Visible = gsExpiredReference

        End With

    End Sub
    Public Sub GS_ColumnGrid_U_Invoice(ByVal dgvProductItem As DataGridView)
        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = gsCUSTOM_TAX,
            .Name = "TAX"
        }

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", gsCUSTOM_CODE) '1
            .Add("DESCRIPTION", gsCUSTOM_DESCRIPTION) '2
            .Add("QTY", gsCUSTOM_QTY) '3
            .Add("UM", gsCUSTOM_UNIT) '4
            .Add("UNIT_PRICE", gsCUSTOM_RATE) '5
            .Add("DISCOUNT_TYPE", gsCUSTOM_DISC_TYPE) '6
            .Add("DISCOUNT_RATE", gsCUSTOM_DISC_RATE) '7
            .Add("AMOUNT", gsCUSTOM_AMOUNT) '8
            .Add(chk) '9
            .Add("UNIT_ID", "UNIT_ID") '10
            .Item("UNIT_ID").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS") '11
            .Item("CONTROL_STATUS").Visible = False
            .Add("RATE_TYPE", "RATE_TYPE") '12
            .Item("RATE_TYPE").Visible = False
            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '13
            .Item("UNIT_QUANTITY_BASE").Visible = False
            .Add("DISCOUNT_ID", "DISCOUNT_ID") '14
            .Item("DISCOUNT_ID").Visible = False
            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '15
            .Item("TAXABLE_AMOUNT").Visible = False
            .Add("TAX_AMOUNT", "TAX_AMOUNT") '16
            .Item("TAX_AMOUNT").Visible = False
            .Add("COGS_ACCOUNT_ID", "COGS_ACCOUNT_ID") '17
            .Item("COGS_ACCOUNT_ID").Visible = False
            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID") '18
            .Item("ASSET_ACCOUNT_ID").Visible = False
            .Add("INCOME_ACCOUNT_ID", "INCOME_ACCOUNT_ID") '19
            .Item("INCOME_ACCOUNT_ID").Visible = False
            .Add("REF_LINE_ID", "REF_LINE_ID") '20
            .Item("REF_LINE_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '21
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '22
            .Item("ITEM_ID").Visible = False


            .Add("GROUP_LINE_ID", "GROUP_LINE_ID") '23
            .Item("GROUP_LINE_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL_ID") '24
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") ' 25
            .Item("ITEM_TYPE").Visible = False

            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") ' 26
            .Item("PRINT_IN_FORMS").Visible = False

            .Add("BATCH_ID", "BATCH_ID") '27
            .Item("BATCH_ID").Visible = False
            .Add("BATCH_NO", gsCUSTOM_BATCH) '28
            .Item("BATCH_NO").Visible = gsExpiredReference

        End With

    End Sub
    Private Function GF_Check_Payment_Bill(ByVal prBill_ID As String, ByVal prCheck_ID As String) As Boolean
        Dim b As Boolean = False

        Try
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select ID from `check_bills` where check_id ='" & prCheck_ID & "' and bill_ID = '" & prBill_ID & "'limit 1")
            If rd.Read Then
                b = True
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                b = GF_Check_Payment_Bill(prBill_ID, prCheck_ID)
            Else
                End
            End If
        End Try
        Return b
    End Function
    Private Function GF_CheckPaymentInvoice(ByVal prInvoice_ID As String, ByVal prPayment_ID As String) As Boolean
        Dim b As Boolean = False
        '  Dim cn As New MySqlConnection(mysqlConstr)
        Try
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select ID from payment_invoices where payment_id ='" & prPayment_ID & "' and invoice_id = '" & prInvoice_ID & "'limit 1")
            If rd.Read Then
                b = True
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                b = GF_CheckPaymentInvoice(prInvoice_ID, prPayment_ID)
            Else
                End
            End If
        End Try
        Return b
    End Function
    Public Sub GS_PaymentSaving(ByVal dgvUnpaid As DataGridView, ByVal gsID As Integer, ByVal isBill As Boolean, ByVal prLocation_ID As Integer, ByVal prDate As Date, ByVal prContact_ID As Integer)

        Dim PayItemID(100) As String
        Dim PayItemRun As Integer = 0

        For i As Integer = 0 To dgvUnpaid.Rows.Count - 1
            Dim GET_LAST_DISCOUNT_ID As Integer = 0
            With dgvUnpaid.Rows(i)
                If .Cells("SELECTED").Value = True Then
                    If isBill = True Then
                        'Bill Payment
                        If GF_Check_Payment_Bill(.Cells("BILL_ID").Value, gsID) = True Then

                            GET_LAST_DISCOUNT_ID = GF_GetNumberFieldValueOneReturn($"SELECT DISCOUNT_ACCOUNT_ID FROM `CHECK_BILLS` WHERE ID ='" & .Cells("ID").Value & "' and CHECK_ID ='" & gsID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                            SqlExecuted("UPDATE `check_bills` SET DISCOUNT=" & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT").Value)) & ",AMOUNT_PAID = " & GotNullNumber(GF_NumIsNull(.Cells("PAYMENT").Value)) & ",DISCOUNT_ACCOUNT_ID=" & GF_GotNullText(.Cells("DISCOUNT_ACCOUNT_ID").Value) & ",ACCOUNTS_PAYABLE_ID=" & GF_GotNullText(.Cells("ACCOUNTS_PAYABLE_ID").Value) & " WHERE ID ='" & .Cells("ID").Value & "' and CHECK_ID ='" & gsID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                            PayItemID(PayItemRun) = .Cells("BILL_ID").Value
                            PayItemRun += 1
                            If GF_NumIsNull(.Cells("DISCOUNT_ACCOUNT_ID").Value) <> 0 Then
                                GET_LAST_DISCOUNT_ID = .Cells("DISCOUNT_ACCOUNT_ID").Value
                            End If
                        Else
                            Dim i_ID As Double = ObjectTypeMapId("CHECK_BILLS")
                            SqlExecuted("INSERT INTO `check_bills` Set ID='" & i_ID & "',CHECK_ID='" & gsID & "',BILL_ID='" & .Cells("BILL_ID").Value & "',DISCOUNT=" & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT").Value)) & ", AMOUNT_PAID = " & GotNullNumber(GF_NumIsNull(.Cells("PAYMENT").Value)) & ",DISCOUNT_ACCOUNT_ID=" & GF_GotNullText(.Cells("DISCOUNT_ACCOUNT_ID").Value) & ",ACCOUNTS_PAYABLE_ID=" & GF_GotNullText(.Cells("ACCOUNTS_PAYABLE_ID").Value) & ";")
                            PayItemID(PayItemRun) = .Cells("BILL_ID").Value
                            PayItemRun += 1
                            .Cells("ID").Value = i_ID
                            If GF_NumIsNull(.Cells("DISCOUNT_ACCOUNT_ID").Value) <> 0 Then
                                GET_LAST_DISCOUNT_ID = .Cells("DISCOUNT_ACCOUNT_ID").Value
                            End If

                        End If
                        '======================================================
                        If gsSkipJournalEntry = False Then
                            GS_AccountJournalExecute(.Cells("ACCOUNTS_PAYABLE_ID").Value, prLocation_ID, .Cells("BILL_ID").Value, 58, .Cells("ID").Value, prDate, 0, GF_NumIsNull(.Cells("PAYMENT").Value), gsJOURNAL_NO_FORM)
                            If GF_NumIsNull(.Cells("DISCOUNT").Value) <> 0 Then
                                'if got discount
                                GS_AccountJournalExecute(GET_LAST_DISCOUNT_ID, prLocation_ID, .Cells("BILL_ID").Value, 58, .Cells("ID").Value, prDate, 0, GF_NumIsNull(.Cells("DISCOUNT").Value), gsJOURNAL_NO_FORM)
                                If IsDate(.Cells("DISC_DATE").Value) = True Then
                                    SqlExecuted($"UPDATE bill SET DISCOUNT_DATE  = '{GetDateFormatMySql(.Cells("DISC_DATE").Value)}'  WHERE ID = '{ .Cells("BILL_ID").Value}'  limit 1;")
                                Else
                                    SqlExecuted($"UPDATE bill SET DISCOUNT_DATE  = NULL  WHERE ID = '{ .Cells("BILL_ID").Value}'  limit 1;")
                                    GS_AccountJournalDelete(GET_LAST_DISCOUNT_ID, prLocation_ID, 58, GF_NumIsNull(.Cells("ID").Value), prDate)
                                End If

                            Else
                                GS_AccountJournalDelete(GET_LAST_DISCOUNT_ID, prLocation_ID, 58, GF_NumIsNull(.Cells("ID").Value), prDate)

                            End If

                        End If

                        '  GS_SetUpdateBillBalance(.Cells("BILL_ID").Value, prContact_ID)

                    Else
                        'Invoice
                        '======================================================

                        If GF_CheckPaymentInvoice(.Cells("INVOICE_ID").Value, gsID) = True Then
                            GET_LAST_DISCOUNT_ID = GF_GetNumberFieldValueOneReturn($"SELECT DISCOUNT_ACCOUNT_ID FROM `PAYMENT_INVOICES` WHERE ID ='" & .Cells("ID").Value & "' and PAYMENT_ID ='" & gsID & "' and INVOICE_ID ='" & .Cells("INVOICE_ID").Value & "' limit 1;")
                            SqlExecuted("UPDATE `payment_invoices` SET DISCOUNT=" & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT").Value)) & ",AMOUNT_APPLIED = " & GotNullNumber(GF_NumIsNull(.Cells("PAYMENT").Value)) & ",DISCOUNT_ACCOUNT_ID=" & GF_GotNullText(.Cells("DISCOUNT_ACCOUNT_ID").Value) & ",ACCOUNTS_RECEIVABLE_ID=" & GF_GotNullText(.Cells("ACCOUNTS_RECEIVABLE_ID").Value) & " WHERE ID ='" & .Cells("ID").Value & "' and PAYMENT_ID ='" & gsID & "' and INVOICE_ID ='" & .Cells("INVOICE_ID").Value & "' limit 1;")
                            PayItemID(PayItemRun) = .Cells("INVOICE_ID").Value

                            PayItemRun += 1
                            If GF_NumIsNull(.Cells("DISCOUNT_ACCOUNT_ID").Value) <> 0 Then
                                GET_LAST_DISCOUNT_ID = .Cells("DISCOUNT_ACCOUNT_ID").Value
                            End If
                        Else
                            Dim i_ID As Double = ObjectTypeMapId("PAYMENT_INVOICES")
                            SqlExecuted("INSERT INTO `payment_invoices` Set ID='" & i_ID & "',PAYMENT_ID='" & gsID & "',INVOICE_ID='" & .Cells("INVOICE_ID").Value & "',DISCOUNT=" & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT").Value)) & ", AMOUNT_APPLIED = " & GotNullNumber(GF_NumIsNull(.Cells("PAYMENT").Value)) & ",DISCOUNT_ACCOUNT_ID=" & GF_GotNullText(.Cells("DISCOUNT_ACCOUNT_ID").Value) & ",ACCOUNTS_RECEIVABLE_ID=" & GF_GotNullText(.Cells("ACCOUNTS_RECEIVABLE_ID").Value) & ";")
                            PayItemID(PayItemRun) = .Cells("INVOICE_ID").Value
                            PayItemRun += 1
                            .Cells("ID").Value = i_ID
                            If GF_NumIsNull(.Cells("DISCOUNT_ACCOUNT_ID").Value) <> 0 Then
                                GET_LAST_DISCOUNT_ID = .Cells("DISCOUNT_ACCOUNT_ID").Value
                            End If

                        End If
                        '======================================================
                        If gsSkipJournalEntry = False Then
                            GS_AccountJournalExecute(.Cells("ACCOUNTS_RECEIVABLE_ID").Value, prLocation_ID, .Cells("INVOICE_ID").Value, 42, .Cells("ID").Value, prDate, 1, GF_NumIsNull(.Cells("PAYMENT").Value), gsJOURNAL_NO_FORM)
                            If GF_NumIsNull(.Cells("DISCOUNT").Value) <> 0 Then
                                'if got discount
                                GS_AccountJournalExecute(GET_LAST_DISCOUNT_ID, prLocation_ID, .Cells("INVOICE_ID").Value, 42, .Cells("ID").Value, prDate, 1, GF_NumIsNull(.Cells("DISCOUNT").Value), gsJOURNAL_NO_FORM)
                                If IsDate(.Cells("DISC_DATE").Value) = True Then
                                    SqlExecuted($"UPDATE invoice SET DISCOUNT_DATE  = '{GetDateFormatMySql(.Cells("DISC_DATE").Value)}'  WHERE ID = '{ .Cells("INVOICE_ID").Value}' and LOCATION_ID ='{prLocation_ID}' limit 1;") 'UPDATE BILL got DISCOUNT
                                Else
                                    SqlExecuted($"UPDATE invoice SET DISCOUNT_DATE  = NULL  WHERE ID = '{ .Cells("INVOICE_ID").Value}'  limit 1;") 'UPDATE BILL got DISCOUNT

                                    GS_AccountJournalDelete(GET_LAST_DISCOUNT_ID, prLocation_ID, 42, GF_NumIsNull(.Cells("ID").Value), prDate)
                                End If

                            Else
                                GS_AccountJournalDelete(GET_LAST_DISCOUNT_ID, prLocation_ID, 42, GF_NumIsNull(.Cells("ID").Value), prDate)

                            End If

                        End If


                    End If
                Else
                    'Delete
                    If isBill = True Then

                        If GF_Check_Payment_Bill(.Cells("BILL_ID").Value, gsID) = True Then
                            If gsSkipJournalEntry = False Then

                                GET_LAST_DISCOUNT_ID = GF_GetNumberFieldValueOneReturn($"SELECT DISCOUNT_ACCOUNT_ID FROM `check_bills` WHERE ID ='" & .Cells("ID").Value & "' and CHECK_ID ='" & gsID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                                GS_AccountJournalDelete(GF_NumIsNull(.Cells("ACCOUNTS_PAYABLE_ID").Value), prLocation_ID, 58, GF_NumIsNull(.Cells("ID").Value), prDate)
                                GS_AccountJournalDelete(GET_LAST_DISCOUNT_ID, prLocation_ID, 58, GF_NumIsNull(.Cells("ID").Value), prDate)

                            End If
                            SqlExecuted("DELETE FROM `check_bills` WHERE ID='" & .Cells("ID").Value & "' and CHECK_ID='" & gsID & "' and BILL_ID ='" & .Cells("BILL_ID").Value & "' limit 1;")
                            PayItemID(PayItemRun) = .Cells("BILL_ID").Value

                            PayItemRun += 1

                            'GS_SetUpdateBillBalance(.Cells("BILL_ID").Value, prContact_ID)

                        End If
                    Else
                        'Invoice

                        If GF_CheckPaymentInvoice(.Cells("INVOICE_ID").Value, gsID) = True Then
                            If gsSkipJournalEntry = False Then
                                GET_LAST_DISCOUNT_ID = GF_GetNumberFieldValueOneReturn($"SELECT DISCOUNT_ACCOUNT_ID FROM `PAYMENT_INVOICES` WHERE ID ='" & .Cells("ID").Value & "' and PAYMENT_ID ='" & gsID & "' and INVOICE_ID ='" & .Cells("INVOICE_ID").Value & "' limit 1;")
                                GS_AccountJournalDelete(GF_NumIsNull(.Cells("ACCOUNTS_RECEIVABLE_ID").Value), prLocation_ID, 42, GF_NumIsNull(.Cells("ID").Value), prDate)
                                GS_AccountJournalDelete(GET_LAST_DISCOUNT_ID, prLocation_ID, 42, GF_NumIsNull(.Cells("ID").Value), prDate)
                            End If
                            SqlExecuted("DELETE FROM `payment_invoices` WHERE ID='" & .Cells("ID").Value & "' and PAYMENT_ID='" & gsID & "' and INVOICE_ID ='" & .Cells("INVOICE_ID").Value & "' limit 1;")
                            PayItemID(PayItemRun) = .Cells("INVOICE_ID").Value
                            PayItemRun += 1

                            ' SetUpdateInvoiceBalance(.Cells("INVOICE_ID").Value, prContact_ID)

                        End If
                    End If
                End If

            End With
        Next

        For N As Integer = 0 To PayItemRun - 1
            'Update Balance
            If isBill = True Then
                GS_SetUpdateBillBalance(PayItemID(N), prContact_ID)
            Else
                GS_UpdateInvoiceBalance(PayItemID(N), prContact_ID)
            End If

        Next

    End Sub
End Module
