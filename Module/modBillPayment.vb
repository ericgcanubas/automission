Imports System.Data.Odbc
Module modBillPayment
    Public Sub SetUpdateBillBalance(ByVal prBill_ID As String, ByVal prVendor_ID As String)

        Dim dTotal_Payment As Double = GetBillSumPaymentApplied(prBill_ID, prVendor_ID) + GetBillSumCreditApplied(prBill_ID, prVendor_ID) + GetBillSumTaxAppliedAmount(prBill_ID, prVendor_ID)
        Dim dTotal_Amount As Double = GetNumberFieldValue("BILL", "ID", prBill_ID, "AMOUNT") 'ORIGINAL AMOUNT
        Dim dTotal_Balance As Double = dTotal_Amount - dTotal_Payment
        Dim nStatus As Integer
        If 0 >= dTotal_Balance Then
            'Paid
            nStatus = 11
        Else
            'Not Paid
            nStatus = 13
        End If

        SqlExecuted("UPDATE bill SET BALANCE_DUE ='" & NumberFormatFixed(dTotal_Balance) & "',STATUS='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "' WHERE Vendor_ID ='" & prVendor_ID & "' and ID ='" & prBill_ID & "' limit 1;")

    End Sub
    Public Function GetBillSumPaymentApplied(ByRef prBill_ID As String, ByVal prVendor_ID As String) As Double
        If Trim(prVendor_ID) = "" Or Trim(prBill_ID) = "" Then
            Return 0
            Exit Function
        End If

        Dim dPayment As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select SUM(pv.AMOUNT_PAID)  as P, SUM(pv.DISCOUNT) as D from `Check_bills` as pv  inner join `check` as p on p.id = pv.check_ID  where p.PAY_TO_ID = '" & prVendor_ID & "' and pv.Bill_ID = '" & prBill_ID & "' and p.STATUS ='15' ")
            If rd.Read Then
                dPayment = NumIsNull(rd("P")) + NumIsNull(rd("D"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = GetBillSumPaymentApplied(prBill_ID, prVendor_ID)
            Else
                End
            End If
        End Try
        Return dPayment
    End Function

    Public Function GetBillSumCreditApplied(ByRef prBill_ID As String, ByVal prVendor_ID As String) As Double
        If Trim(prBill_ID) = "" Or Trim(prVendor_ID) = "" Then
            Return 0
            Exit Function
        End If
        Dim dPayment As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_APPLIED)  as P  from bill_credit_bills as cmi inner join bill_credit as c on c.id = cmi.bill_credit_ID where c.vendor_ID = '" & prVendor_ID & "' and cmi.bill_ID = '" & prBill_ID & "'")
            If rd.Read Then
                dPayment = NumIsNull(rd("P"))
            End If
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = GetBillSumCreditApplied(prBill_ID, prVendor_ID)
            Else
                End
            End If
        End Try
        Return dPayment
    End Function

    Public Function GetBillSumTaxAppliedAmount(ByRef prID As String, ByVal prVendor_ID As String) As Double

        If Trim(prID) = "" Or Trim(prVendor_ID) = "" Then
            Return 0
            Exit Function
        End If
        Dim dPayment As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_WITHHELD)  as P  from `withholding_tax_bills` as cmi inner join withholding_tax as c on c.id = cmi.withholding_tax_ID where c.WITHHELD_FROM_ID = '" & prVendor_ID & "' and cmi.Bill_ID = '" & prID & "'")
            If rd.Read Then
                dPayment = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = GetBillSumTaxAppliedAmount(prID, prVendor_ID)
            Else
                End
            End If
        End Try
        Return dPayment
    End Function
End Module
