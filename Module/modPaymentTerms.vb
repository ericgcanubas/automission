Imports System.Data.Odbc
Module modPaymentTerms

    Public Sub fSetDueDate_PaymentTerms(ByVal prPayment_Terms As ComboBox, ByRef prDue_date As DateTimePicker, ByVal prTransaction_date As DateTimePicker)
        If prPayment_Terms.Text = "" Then Exit Sub

        Dim dt As Date = prTransaction_date.Value
        'Dim cn As New MySqlConnection(mysqlConstr)
        Dim N As Integer = 0
        Try

            '   cn.Open()
            Dim rd As OdbcDataReader = fReader("select `TYPE`,NET_DUE,DATE_MONTH_PARAM,DATE_DAY_PARAM,DATE_MIN_DAYS from payment_terms where id = '" & CStr(prPayment_Terms.SelectedValue.ToString) & "' and INACTIVE ='0' limit 1 ")
            If rd.Read Then
                Select Case fNumisNULL(rd("TYPE"))
                    Case 0
                        N = fNumisNULL(rd("NET_DUE"))
                        prDue_date.Value = dt.AddDays(N)
                    Case 1
                    Case 2
                    Case 3
                    Case 4
                    Case 5
                        Dim M As Integer = fNumisNULL(rd("DATE_MONTH_PARAM"))
                        Dim D As Integer = fNumisNULL(rd("DATE_DAY_PARAM"))
                        If M = 0 Then
                            M = dt.Month
                        End If
                        If D = 0 Then
                            D = dt.Day
                        End If
                        N = fNumisNULL(rd("NET_DUE"))
                        dt = M & "/" & D & "/" & (N + Date.Now.Year)
                        prDue_date.Value = dt
                End Select
            End If
            rd.Close()
        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fSetDueDate_PaymentTerms(prPayment_Terms, prDue_date, prTransaction_date)
            Else
                End
            End If
        Finally

        End Try

    End Sub

End Module
