Imports System.Data.Odbc
Module modInvoiceTax
    Public Function fInvoiceSumTaxApplied_Amount(ByRef prID As String, ByVal prCustomer_ID As String) As Double
        If Trim(prID) = "" Or Trim(prCustomer_ID) = "" Then
            Return 0
            Exit Function
        End If
        Dim dPayment As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_WITHHELD)  as P  from `tax_credit_invoices` as cmi inner join tax_credit as c on c.id = cmi.tax_credit_ID where c.Customer_ID = '" & prCustomer_ID & "' and cmi.Invoice_ID = '" & prID & "'")
            If rd.Read Then
                dPayment = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = fInvoiceSumTaxApplied_Amount(prID, prCustomer_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function
    Public Function fGetTexApplied_Invoice(ByRef prTAX_CREDIT_ID As String, ByVal prCustomer_ID As String, ByVal prInvoice_ID As String) As Double

        If Trim(prTAX_CREDIT_ID) = "" Or Trim(prCustomer_ID) = "" Then
            Return 0
            Exit Function
        End If
        Dim dPayment As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_WITHHELD)  as P  from TAX_CREDIT_invoices as cmi inner join TAX_CREDIT as c on c.id = cmi.TAX_CREDIT_ID where c.Customer_ID = '" & prCustomer_ID & "' and cmi.TAX_CREDIT_ID = '" & prTAX_CREDIT_ID & "' and cmi.Invoice_ID = '" & prInvoice_ID & "'")
            If rd.Read Then
                dPayment = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = fGetTexApplied_Invoice(prTAX_CREDIT_ID, prCustomer_ID, prInvoice_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function
    Public Function fGetTaxOtherInvoice(ByRef prTAX_CREDIT_ID As String, ByVal prInvoice_id As String) As Double
        Dim dAmount As Double = 0

        Try
            Dim rd As OdbcDataReader = SqlReader("select sum(AMOUNT_WITHHELD) as P from credit_Tax_invoices where credit_Tax_ID = '" & prTAX_CREDIT_ID & "' and Invoice_ID <> '" & prInvoice_id & "'")
            If rd.Read Then
                dAmount = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                dAmount = fGetTaxOtherInvoice(prTAX_CREDIT_ID, prInvoice_id)
            Else
                End
            End If
        End Try
        Return dAmount
    End Function
End Module
