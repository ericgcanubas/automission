Module modModify

    Public Function fCheckModify(ByVal dgv As DataGridView, ByVal ThisIndex As Integer) As Boolean
        Dim Got_DS_OT As Boolean = False
        For I As Integer = ThisIndex + 1 To dgv.Rows.Count - 1

            With dgv.Rows(I)
                If .Visible = True Then
                    If .Cells("ITEM_TYPE").Value = 4 Then
                        fMessageboxInfo("Invalid modify -> this row has other charge")
                        Got_DS_OT = True
                        Exit For
                    ElseIf .Cells("ITEM_TYPE").Value = 7 Then
                        fMessageboxInfo("Invalid modify -> this row has discount")
                        Got_DS_OT = True
                        Exit For
                    End If
                End If
            End With

        Next

        Return Got_DS_OT

    End Function

End Module
