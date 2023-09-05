Module modJournal
    Public Sub fTransactionJournal(ByVal prID As String, gsDate As Date, gsLoc_Id As Integer, ByVal prObject_type As Integer, ByVal prAccount_ID As Integer, ByVal prContact_NAME As String, ByVal prCode As String, ByVal prNotes As String)
        With frmAccountJournalTransaction

            .gsID = prID
            .gsLocation_Id = gsLoc_Id
            .objDate = gsDate
            .gsAccount_Id = prAccount_ID
            .gsObject_Type = prObject_type
            .ShowDialog()
            .Dispose()
            frmAccountJournalTransaction = Nothing
        End With
    End Sub

    Public Sub fRow_Add_Account(ByVal dgv As DataGridView, ByVal prAdd As Boolean, ByVal prAccount_ID As String, ByVal prDebit As Double, ByVal prCredit As Double, ByVal prNotes As String, ByVal prClass_ID As String)
        Dim prAccount_Name As String = fGetFieldValue("ACCOUNT", "ID", prAccount_ID, "NAME")
        Dim d_amount As String = ""
        Dim c_amount As String = ""
        Dim prEntry_Type As Integer
        Dim prEntry_Value As Double = 0

        If prDebit <> 0 Then
            'Debit
            prEntry_Type = 0
            prEntry_Value = prDebit
            d_amount = fNumFormatStandard(prEntry_Value)
        ElseIf prCredit <> 0 Then
            'Credit
            prEntry_Type = 1
            prEntry_Value = prCredit
            c_amount = fNumFormatStandard(prEntry_Value)
        End If

        If prAdd = True Then
            dgv.Rows.Add("N", prAccount_ID, prAccount_Name, prEntry_Type, d_amount, c_amount, prEntry_Value, prNotes, prClass_ID, fGetFieldValue("CLASS", "ID", prClass_ID, "NAME"), "A")
            dgv.Refresh()
            dgv.Rows(dgv.Rows.Count - 1).Selected = True

        Else

            Dim i As Integer = dgv.CurrentRow.Index
            With dgv.Rows(i)

                If Val(.Cells(0).Value) = 0 Then
                    .Cells("CONTROL_STATUS").Value = "A"
                Else
                    .Cells("CONTROL_STATUS").Value = "E"
                End If

                .Cells("ACCOUNT_ID").Value = prAccount_ID
                .Cells("ACCOUNT_NAME").Value = prAccount_Name
                .Cells("ENTRY_TYPE").Value = prEntry_Type
                .Cells("DEBIT").Value = d_amount
                .Cells("CREDIT").Value = c_amount
                .Cells("AMOUNT").Value = prEntry_Value
                .Cells("NOTES").Value = prNotes
                .Cells("CLASS_ID").Value = prClass_ID
                .Cells("CLASS").Value = fGetFieldValue("CLASS", "ID", prClass_ID, "NAME")
            End With



        End If


    End Sub
End Module
