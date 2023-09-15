Imports System.Data.Odbc
Module modInvoice_payment

    Public Function fGetSumPaymentApplied(ByRef prInvoice_ID As String, ByVal prCustomer_ID As String) As Double
        If Trim(prInvoice_ID) = "" Or Trim(prCustomer_ID) = "" Then
            Return 0
            Exit Function
        End If

        Dim dPayment As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select SUM(pv.AMOUNT_APPLIED)  as P, SUM(pv.DISCOUNT) as D from payment_invoices as pv  inner join payment as p on p.id = pv.payment_id  where p.customer_id = '" & prCustomer_ID & "' and pv.invoice_id = '" & prInvoice_ID & "' and p.STATUS ='15'")
            If rd.Read Then
                dPayment = GF_NumIsNull(rd("P")) + GF_NumIsNull(rd("D"))
            End If

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = fGetSumPaymentApplied(prInvoice_ID, prCustomer_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function
    Public Sub fUpdateInvoiceBalance(ByVal prInvoice_ID As String, ByVal prCustomer_ID As String)




        Dim dTotal_Payment As Double = fGetSumPaymentApplied(prInvoice_ID, prCustomer_ID) + fGetSumCreditApplied(prInvoice_ID, prCustomer_ID) + fInvoiceSumTaxApplied_Amount(prInvoice_ID, prCustomer_ID)
        Dim dTotal_Amount As Double = GF_GetNumberFieldValue("INVOICE", "ID", prInvoice_ID, "AMOUNT")
        Dim dTotal_Balance As Double = dTotal_Amount - dTotal_Payment


        Dim nStatus As Integer = 0

        If 0 >= dTotal_Balance Then
            'Paid
            nStatus = 11
        Else
            'Not Paid
            nStatus = 13
        End If

        SqlExecuted("UPDATE invoice SET BALANCE_DUE ='" & NumberFormatFixed(dTotal_Balance) & "',STATUS='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "' WHERE Customer_ID ='" & prCustomer_ID & "' and ID ='" & prInvoice_ID & "' limit 1;")
    End Sub
    Public Function fGetSumCreditApplied(ByRef prInvoice_ID As String, ByVal prCustomer_ID As String) As Double

        If Trim(prInvoice_ID) = "" Or Trim(prCustomer_ID) = "" Then
            Return 0
            Exit Function
        End If
        Dim dPayment As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_APPLIED)  as P  from credit_memo_invoices as cmi inner join credit_memo as c on c.id = cmi.credit_memo_id where c.customer_id = '" & prCustomer_ID & "' and cmi.invoice_id = '" & prInvoice_ID & "'")
            If rd.Read Then
                dPayment = GF_NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = fGetSumCreditApplied(prInvoice_ID, prCustomer_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function


End Module
