Imports System.Data.Odbc
Module modAutoTransactionUpdate
    Public Sub GS_AutoUpdateTransaction(ByVal prCustomer_ID As String, ByVal prSales_Rep_ID As String, ByVal prDealer_ID As String)

        Dim sQuery As String = "SELECT (select count(*) from invoice where customer_id = '" & prCustomer_ID & "' ) as INVOICE_COUNT , (select count(*) from credit_memo where customer_id = '" & prCustomer_ID & "') AS CREDIT_MEMO_COUNT ,(select count(*) from SALES_RECEIPT where customer_id = '" & prCustomer_ID & "') as SALES_RECEIPT_COUNT "
        Dim bInvoice As Boolean = False
        Dim bCreditMeno As Boolean = False
        Dim bSalesReceipt As Boolean = False

        Try

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                If NumIsNull(rd(0)) <> 0 Then
                    bInvoice = True
                End If

                If NumIsNull(rd(1)) <> 0 Then
                    bCreditMeno = True
                End If

                If NumIsNull(rd(2)) <> 0 Then
                    bSalesReceipt = True
                End If


                If bInvoice = True Or bCreditMeno = True Or bSalesReceipt = True Then
                    Dim msg As String = ""
                    If bInvoice = True Then
                        msg = msg & NumIsNull(rd(0)) & " record. do you want to update all transaction for invoice " & vbNewLine
                    End If
                    If bCreditMeno = True Then
                        msg = msg & NumIsNull(rd(1)) & " record. do you want to update all transaction for credit memo " & vbNewLine
                    End If
                    If bSalesReceipt = True Then
                        msg = msg & NumIsNull(rd(2)) & " record. do you want to update all transaction for sales receipt " & vbNewLine
                    End If

                    If MessageBoxQuestion(msg) = True Then

                        If bInvoice = True Then
                            SqlExecuted("UPDATE invoice SET Sales_Rep_ID = " & GotNullNumber(Val(prSales_Rep_ID)) & ",DEALER_ID = " & GotNullNumber(Val(prDealer_ID)) & " WHERE customer_id = '" & prCustomer_ID & "'")
                        End If
                        If bCreditMeno = True Then
                            SqlExecuted("UPDATE credit_memo Sales_Rep_ID = " & GotNullNumber(Val(prSales_Rep_ID)) & ",DEALER_ID = " & GotNullNumber(Val(prDealer_ID)) & " WHERE customer_id = '" & prCustomer_ID & "'")
                        End If
                        If bSalesReceipt = True Then
                            SqlExecuted("UPDATE sales_receipt SET Sales_Rep_ID = " & GotNullNumber(Val(prSales_Rep_ID)) & ",DEALER_ID = " & GotNullNumber(Val(prDealer_ID)) & " WHERE customer_id = '" & prCustomer_ID & "'")
                        End If
                    End If
                End If
            End If
            rd.Close()

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                GS_AutoUpdateTransaction(prCustomer_ID, prSales_Rep_ID, prDealer_ID)
            Else
                End
            End If
        End Try


    End Sub

End Module
