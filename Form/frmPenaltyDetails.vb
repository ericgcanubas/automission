Imports System.Data.Odbc
Public Class frmPenaltyDetails
    Public gsID As String = ""
    Private Sub frmPenaltyDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim penalty_rate As Double = 0
        Dim penalty_amount As Double = 0
        Dim balance_due As Double = 0
        Try
            'cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select * from invoice where id = '" & gsID & "' and penalty_type_id <> '0'")
            If rd.Read Then
                lblName.Text = GetStringFieldValue("CONTACT", "ID", rd("customer_id"), "NAME")
                Dim d As Integer = DateDiff(DateInterval.Day, fgetLastPaymentDate(gsID, rd("DUE_DATE")), Date.Now.Date)
                penalty_rate = NumIsNull(rd("penalty_rate"))
                balance_due = NumIsNull(rd("balance_due"))
                lblBALANCE_DUE.Text = Format(balance_due, "Standard")
                lblPENALTY_RATE.Text = penalty_rate & "% "
                lblDAY_OVER.Text = d
                Dim n As Double = balance_due * (penalty_rate / 100)
                lblPENALTY_AMOUNT.Text = Format(n, "standard")
                Dim y As Double = n / 30
                lblPENALTY_PER_DAY.Text = Format(y, "standard")
                lblPENALTY_TYPE.Text = GetStringFieldValue("penalty_type_map", "ID", NumIsNull(rd("penalty_type_id")), "DESCRIPTION")
                Select Case NumIsNull(rd("penalty_type_id"))
                    Case 1
                        penalty_amount = y * 1
                    Case 2
                        penalty_amount = y * d
                End Select
                lblTOTAL_PENALTY.Text = Format(penalty_amount, "Standard")
                lblTOTAL_BALANCE.Text = NumIsNull(rd("Balance_due")) + NumIsNull(rd("Penalty"))

            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub
    Private Function fgetLastPaymentDate(ByVal invoice_id As String, ByVal prDue_date As Date) As Date
        Dim d As Date = prDue_date
        Try
            Dim rd As OdbcDataReader = SqlReader("select p.date as `D`  from  payment as p  inner join payment_invoices  as pv where pv.invoice_id = '" & gsID & "' and pv.penalty_paid > 0 order by p.Date desc Limit 1")
            If rd.Read Then

                d = CDate(TextIsNull(rd("D")))
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return d
    End Function
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class