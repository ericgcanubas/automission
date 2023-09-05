Public Class frmPrimaryKeyUpdater
    Private Sub frmPrimaryKeyUpdater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()
        fDataGridView(dgvLIST, "select ID,TABLE_NAME,NEXT_ID from `object_type_map` ")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For I As Integer = 0 To dgvLIST.Rows.Count - 1
            fUpdateNextCode(dgvLIST.Rows(I).Cells(0).Value, dgvLIST.Rows(I).Cells(1).Value)

        Next

        RefreshList()
    End Sub

    Private Sub fUpdateNextCode(ByVal ThisID As Integer, ByVal ThisTable As String)

        Dim LastID As Double = Val(fGetMaxField("ID", ThisTable))
        If LastID = 0 Then

            If fMessageboxWarningYesNo(ThisTable & " this ID is 0. do you want to continue") = True Then
                fExecutedOnly($"UPDATE `object_type_map` SET NEXT_ID = '{LastID + 1}' WHERE ID = '{ThisID}' Limit 1 ")
            End If

        Else
            fExecutedOnly($"UPDATE `object_type_map` SET NEXT_ID = '{LastID + 1}' WHERE ID = '{ThisID}' Limit 1 ")
        End If


    End Sub
End Class