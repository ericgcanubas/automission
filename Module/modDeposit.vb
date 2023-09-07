
Module modDeposit

    Public Sub fAdd_Deposit_fund(ByVal prDgv As DataGridView, ByVal prNew As Boolean, ByVal prReceived_ID As String, ByVal prAccount_ID As String, ByVal prPayment_Method_ID As String, ByVal prCheck_No As String, ByVal prAmount As Double)
        Dim Received_name As String = GetStringFieldValue("CONTACT", "ID", prReceived_ID, "NAME")
        Dim Account_name As String = GetStringFieldValue("ACCOUNT", "ID", prAccount_ID, "NAME")
        Dim Payment_method_name As String = GetStringFieldValue("PAYMENT_METHOD", "ID", prPayment_Method_ID, "DESCRIPTION")

        If prNew = True Then

            prDgv.Rows.Add("N", prReceived_ID, Received_name, prAccount_ID, Account_name, prPayment_Method_ID, Payment_method_name, prCheck_No, NumberFormatStandard(prAmount), 0, 0, "A")

        Else
            Dim i As Integer = prDgv.CurrentRow.Index

            With prDgv.Rows(i)

                If Val(.Cells("ID").Value) = 0 Then
                    .Cells("CONTROL_STATUS").Value = "A"
                Else
                    .Cells("CONTROL_STATUS").Value = "E"
                End If

                .Cells("RECEIVED_FROM_ID").Value = prReceived_ID
                .Cells("RECEIVED_FROM").Value = Received_name
                .Cells("ACCOUNT_ID").Value = prAccount_ID
                .Cells("ACCOUNT_NAME").Value = Account_name
                .Cells("PAYMENT_METHOD_ID").Value = prPayment_Method_ID
                .Cells("PAYMENT_METHOD_NAME").Value = Payment_method_name
                .Cells("CHECK_NO").Value = prCheck_No
                .Cells("AMOUNT").Value = Format(prAmount, "STANDARD")

            End With

        End If

    End Sub



End Module
