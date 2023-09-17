Imports System.Data.Odbc
Module modInvoiceCredit
    Public Function GF_GetCreditApplied_Amount(ByVal prCreditMemo_ID As Integer, ByVal prCustomer_ID As Integer) As Double
        Dim dPayment As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_APPLIED)  as P  from credit_memo_invoices as cmi inner join credit_memo as c on c.id = cmi.credit_memo_id where c.customer_id = '" & prCustomer_ID & "' and cmi.credit_memo_ID = '" & prCreditMemo_ID & "'")
            If rd.Read Then
                dPayment = GF_NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            dPayment = GF_GetCreditApplied_Amount(prCreditMemo_ID, prCustomer_ID)
        End Try
        Return dPayment

    End Function

    Public Function GF_GetCreditOtherInvoice(ByRef prCreditMemo_ID As Integer, ByVal prInvoice_id As Integer) As Double
        Dim dAmount As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select sum(amount_applied) as P from credit_memo_invoices where credit_memo_id = '" & prCreditMemo_ID & "' and Invoice_ID <> '" & prInvoice_id & "'")
            If rd.Read Then
                dAmount = GF_NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dAmount = GF_GetCreditOtherInvoice(prCreditMemo_ID, prInvoice_id)
            Else
                End
            End If

        End Try
        Return dAmount

    End Function

    Public Function GF_GetCreditApplied_Invoice(ByRef prCreditMemo_ID As Integer, ByVal prCustomer_ID As Integer, ByVal prInvoice_ID As Integer) As Double

        Dim dPayment As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_APPLIED)  as P  from credit_memo_invoices as cmi inner join credit_memo as c on c.id = cmi.credit_memo_id where c.customer_id = '" & prCustomer_ID & "' and cmi.credit_memo_ID = '" & prCreditMemo_ID & "' and cmi.invoice_id = '" & prInvoice_ID & "'")
            If rd.Read Then
                dPayment = GF_NumIsNull(rd("P"))
            End If
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = GF_GetCreditApplied_Invoice(prCreditMemo_ID, prCustomer_ID, prInvoice_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function




End Module
