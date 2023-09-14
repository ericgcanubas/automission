Imports System.Data.Odbc
Module modBillCredit
    Public Function GF_BillCreditAppliedAmount(ByRef prBill_Credit_ID As String, ByVal prVendor_ID As String) As Double

        If Trim(prBill_Credit_ID) = "" Or Trim(prVendor_ID) = "" Then
            Return 0
            Exit Function
        End If

        Dim dPayment As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_APPLIED)  as P  from bill_credit_bills as cmi inner join bill_credit as c on c.id = cmi.bill_Credit_ID where c.vendor_ID = '" & prVendor_ID & "' and cmi.bill_Credit_ID = '" & prBill_Credit_ID & "'")
            If rd.Read Then
                dPayment = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = GF_BillCreditAppliedAmount(prBill_Credit_ID, prVendor_ID)
            Else
                End
            End If
        End Try

        Return dPayment

    End Function
    Public Function GF_GetCreditAppliedBills(ByRef prBill_Credit_ID As String, ByVal prVendor_ID As String, ByVal prBill_ID As String) As Double

        If Trim(prBill_Credit_ID) = "" Or Trim(prVendor_ID) = "" Then
            Return 0
            Exit Function
        End If

        Dim dPayment As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select SUM(cmi.AMOUNT_APPLIED)  as P  from bill_credit_bills as cmi inner join bill_credit as c on c.id = cmi.bill_credit_ID where c.vendor_id = '" & prVendor_ID & "' and cmi.bill_credit_ID = '" & prBill_Credit_ID & "' and cmi.bill_ID = '" & prBill_ID & "'")
            If rd.Read Then
                dPayment = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dPayment = GF_GetCreditAppliedBills(prBill_Credit_ID, prVendor_ID, prBill_ID)
            Else
                End
            End If
        End Try
        Return dPayment

    End Function
    Public Function GF_GetCreditOtherBill(ByRef prBill_Credit_ID As String, ByVal prBill_id As String) As Double
        Dim dAmount As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select sum(amount_applied) as P from bill_credit_bills where bill_Credit_id = '" & prBill_Credit_ID & "' and Bill_ID <> '" & prBill_id & "'")
            If rd.Read Then
                dAmount = NumIsNull(rd("P"))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                dAmount = GF_GetCreditOtherBill(prBill_Credit_ID, prBill_id)
            Else
                End
            End If
        End Try
        Return dAmount
    End Function
End Module
