Imports System.Data.Odbc
Module modPenalty
    Public Function fInvoiceGotPenalty(ByVal prDate As Date, ByVal prOverDueDate As Date, ByVal orginal_amount As Double, ByVal prPenalty_Type As Integer, ByVal prPenalty As Integer, ByVal prNum As Integer, ByVal disc As Double) As Double
        Dim penalty_amount As Double = 0
        If prPenalty_Type = 1 Then
            Dim d As Integer = DateDiff(DateInterval.Day, prOverDueDate, prDate)
            If d > 0 Then
                Dim n As Double = orginal_amount * (prPenalty / 100)
                Dim y As Double = n / prNum
                penalty_amount = y * 1
            End If
        ElseIf prPenalty_Type = 2 Then
            Dim d As Integer = DateDiff(DateInterval.Day, prOverDueDate, prDate)
            If d > 0 Then
                Dim n As Double = orginal_amount * (prPenalty / 100)
                Dim y As Double = n / prNum
                penalty_amount = y * d
            End If
        ElseIf prPenalty_Type = 3 Then
            Dim d As Integer = DateDiff(DateInterval.Day, prOverDueDate, prDate)
            If d > 0 Then
                'implementation
                prPenalty = fLessDiscountPenaltyPercent(d)
                Dim n As Double = disc * (prPenalty / 100)
                penalty_amount = n

                If Math.Abs(n) >= Math.Abs(disc) Then
                    penalty_amount = disc
                Else
                    penalty_amount = n
                End If
            End If
        End If
        Return Math.Abs(penalty_amount)
    End Function
    Private Function fLessDiscountPenaltyPercent(ByVal d As Integer) As Double
        Dim percent As Double = 0
        CursorLoadingOn(True)
        Try
            For i As Integer = 1 To d
                If i = 1 Then
                    percent = percent + 3
                ElseIf i <= 30 Then
                    percent = percent + 1
                Else
                    percent = percent + 0.01
                End If
            Next


        Catch ex As Exception
            'If cn.State = ConnectionState.Open Then
            '    cn.Close()
            'End If
            'fMessageboxError(ex)
        Finally
            CursorLoadingOn(False)
        End Try
        Return percent
    End Function
    Public Sub fUpdatePenalty()
        Dim item_id As Integer = NumIsNull(fSystemSettingValue("TargetPenaltyDiscount"))
        Dim pPanalty_Paid As Double = 0
        '  Dim cn As New MySqlConnection(mysqlConstr)
        Try
            CursorLoadingOn(True)
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("Select i.ID,i.Due_date,i.Amount,i.Balance_Due,i.Penalty_rate,i.Penalty_type_Id,i.penalty,
(select  sum(ii.amount) FROM invoice_items as ii where ii.invoice_id = i.ID  and ii.item_id ='" & item_id & "') as basic_discount,
(select FORMAT(IFNULL(sum(penalty_paid),0),2) from payment_invoices where invoice_id = i.ID) as `Penalty_Paid`   from  Invoice as i where i.penalty_type_Id in ('1','2','3')  and i.BALANCE_DUE > 0 ")
            While rd.Read
                Dim p_rate As Double = 0
                Dim p_current As Double = fPanaltyComputed(Date.Now.Date, TextIsNull(rd("Due_date")), NumIsNull(rd("AMOUNT")), NumIsNull(rd("Penalty_type_Id")), NumIsNull(rd("Penalty_rate")), 30, NumIsNull(rd("ID")))
                Dim p_paid As Double = NumIsNull(rd("Penalty_Paid"))

                If NumIsNull(rd("BALANCE_DUE")) <> 0 Then
                    If NumIsNull(rd("penalty_type_Id")) = 3 Then
                        If NumIsNull(rd("basic_discount")) <> 0 Or (p_current + p_paid) <> 0 Then

                            p_rate = NumIsNull(Math.Abs((Math.Abs(p_current + p_paid) / NumIsNull(rd("basic_discount"))) * 100))
                        Else
                            p_rate = 0
                        End If

                    Else
                            p_rate = NumIsNull(rd("Penalty_rate"))
                    End If
                    SqlExecuted("UPDATE invoice  SET Penalty_rate = '" & p_rate & "',PENALTY = '" & p_current & "' Where ID = '" & rd("ID") & "' ")
                End If
            End While
            rd.Close()
        Catch ex As Exception

            MessageBoxWarning(ex.Message)
        Finally
            CursorLoadingOn(False)
        End Try
    End Sub



    Public Function fPanaltyComputed(ByVal prDate As Date, ByVal prOverDueDate As Date, ByVal orginal_amount As Double, ByVal prPenalty_Type As Integer, ByVal prPenalty As Integer, ByVal prNum As Integer, ByVal prInvoice_ID As Integer) As Double
        Dim Disc As Double = fgetDiscount_Invoice_item(prInvoice_ID)
        Dim A As Double = fInvoiceGotPenalty(prDate, prOverDueDate, NumIsNull(orginal_amount), prPenalty_Type, NumIsNull(prPenalty), prNum, Disc)
        Dim B As Double = fGetPenaltyPaidSum_DateRequired(prInvoice_ID, prDate)

        Return (NumberFormatFixed(A) - NumberFormatFixed(B))

    End Function



    Public Function fPanaltyComputed_PAYMENT(ByVal prDate As Date, ByVal prOverDueDate As Date, ByVal orginal_amount As Double, ByVal prPenalty_Type As Integer, ByVal prPenalty As Integer, ByVal prNum As Integer, ByVal prInvoice_ID As Integer, ByVal prPayment_ID As Integer) As Double
        '   Dim cn As New MySqlConnection(mysqlConstr)
        Dim gsDate As Date = prOverDueDate
        Dim actual_balance As Double = 0
        Try
            CursorLoadingOn(True)
            Dim iPay_paid As Double = 0
            Dim iPay_remain As Double = 0
            Dim iDiscount As Double = fgetDiscount_Invoice_item(prInvoice_ID)
            '   cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select p.date,ifnull(pv.penalty_paid,0) as pp ,  ifnull(pv.penalty_remaining,0) as pr  from payment_invoices  as pv  inner join  payment as p on p.id = pv.payment_id where pv.invoice_id = '" & prInvoice_ID & "' and pv.payment_id = '" & prPayment_ID & "' order by p.ID desc limit 1 ")
            If rd.Read Then
                gsDate = rd("date")
                iPay_paid = NumIsNull(rd("pp"))
                iPay_remain = NumIsNull(rd("pr"))
                actual_balance = fInvoiceGotPenalty(prDate, gsDate, orginal_amount, prPenalty_Type, prPenalty, prNum, iDiscount) + iPay_remain
            Else
                actual_balance = fInvoiceGotPenalty(prDate, gsDate, orginal_amount, prPenalty_Type, prPenalty, prNum, iDiscount)
            End If
            rd.Close()

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        Finally
            CursorLoadingOn(False)
        End Try

        Return actual_balance
    End Function
    Public Function fActualRunningPinalty(ByVal prInvoice_ID As String) As Double
        '  Dim cn As New MySqlConnection(mysqlConstr)
        Dim DUE_DATE As Date = Date.Now.Date
        Dim AMOUNT As Double = 0
        Dim PENALTY_TYPE_ID As Integer = 0
        Dim PENALTY_RATE As Double = 0
        Dim DISCOUNT_AMOUNT As Double = fgetDiscount_Invoice_item(prInvoice_ID)
        Try
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select DUE_DATE,AMOUNT,PENALTY_TYPE_ID,PENALTY_RATE from invoice where id = '" & prInvoice_ID & "' Limit 1")
            If rd.Read Then
                DUE_DATE = rd("DUE_DATE")
                AMOUNT = NumIsNull(rd("AMOUNT"))
                PENALTY_TYPE_ID = NumIsNull(rd("PENALTY_TYPE_ID"))
                PENALTY_RATE = NumIsNull(rd("PENALTY_RATE"))
                rd.Close()
            Else
                rd.Close()
                Return 0
            End If


        Catch ex As Exception

            MessageBoxWarning(ex.Message)
        Finally
            CursorLoadingOn(False)
        End Try

        Return fInvoiceGotPenalty(Date.Now.Date, DUE_DATE, AMOUNT, PENALTY_TYPE_ID, PENALTY_RATE, 30, DISCOUNT_AMOUNT)
    End Function

    Public Function fGetPenaltyPaidSumByID(ByVal prInvoice_ID As String, ByVal prPayment_ID As String) As Double

        Return GetSummary("select sum(PENALTY_PAID) as p from payment_invoices where invoice_id = '" & prInvoice_ID & "' and payment_ID < '" & prPayment_ID & "'")

    End Function
    Public Function fGetPenaltyPaidSum(ByVal prInvoice_ID As String) As Double

        Return GetSummary("select sum(PENALTY_PAID) as p from payment_invoices where invoice_id = '" & prInvoice_ID & "'")
    End Function
    Public Function fGetPenaltyPaidSum_DateRequired(ByVal prInvoice_ID As String, ByVal prDate As Date) As Double

        Return GetSummary("select sum(pv.PENALTY_PAID) as p from payment_invoices as pv inner join payment as p on p.id = pv.payment_id  where pv.invoice_id = '" & prInvoice_ID & "'  and p.`Date` <= '" & Format(prDate, "yyyy-MM-dd") & "'")
    End Function
    Public Function fGetPenaltyPaidSum_TargetBase(ByVal prInvoice_ID As String, ByVal prDate As Date, ByVal prPayment_ID As String) As Double

        Return Math.Abs(GetSummary("select sum(pv.PENALTY_PAID) as p from payment_invoices as pv inner join payment as p on p.id = pv.payment_id  where pv.invoice_id = '" & prInvoice_ID & "'  and p.`Date` <= '" & Format(prDate, "yyyy-MM-dd") & "' and p.ID <>  '" & prPayment_ID & "' "))
    End Function
    Public Function fgetDiscount_Invoice_item(ByVal prInvoice_id As Integer) As Double
        Dim disc As Double = 0

        Try
            CursorLoadingOn(True)

            Dim rd As OdbcDataReader = SqlReader("select AMOUNT from invoice_items where invoice_id = '" & prInvoice_id & "' and item_id = '" & NumIsNull(fSystemSettingValue("TargetPenaltyDiscount")) & "' limit 1")
            If rd.Read Then
                disc = Math.Abs(NumIsNull(rd("AMOUNT")))
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        Finally
            CursorLoadingOn(True)
        End Try
        Return disc
    End Function
End Module
