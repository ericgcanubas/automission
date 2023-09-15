Imports System.Data.Odbc
Module modBillTax

    Public Function GF_GetTexApplied_Bill(ByRef prWithholding_Tax_ID As String, ByVal prVendor_ID As String, ByVal prBill_ID As String) As Double

        If Trim(prWithholding_Tax_ID) = "" Or Trim(prVendor_ID) = "" Then
            Return 0
            Exit Function
        End If
        Dim dPayment As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_WITHHELD)  as P  from withholding_tax_bills as cmi inner join withholding_tax as c on c.id = cmi.withholding_Tax_ID where c.vendor_id = '" & prVendor_ID & "' and cmi.withholding_Tax_ID = '" & prWithholding_Tax_ID & "' and cmi.bill_ID = '" & prBill_ID & "'")
            If rd.Read Then
                dPayment = GF_NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                GF_GetTexApplied_Bill(prWithholding_Tax_ID, prVendor_ID, prBill_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function
    Public Function GF_GetTaxOtherBill(ByRef prWithholding_Tax_ID As String, ByVal prBill_id As String) As Double
        Dim dAmount As Double = 0

        Try

            Dim rd As OdbcDataReader = SqlReader("select sum(amount_withheld) as P from Withholding_Tax_Bills where Withholding_Tax_ID = '" & prWithholding_Tax_ID & "' and Bill_ID <> '" & prBill_id & "'")
            If rd.Read Then
                dAmount = GF_NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dAmount = GF_GetTaxOtherBill(prWithholding_Tax_ID, prBill_id)
            Else
                End
            End If
        End Try
        Return dAmount
    End Function
End Module
