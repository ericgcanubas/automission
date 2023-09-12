Public Class FrmPrimaryKeyUpdater
    Private Sub FrmPrimaryKeyUpdater_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()
    End Sub

    Private Sub RefreshList()
        LoadDataGridView(dgvLIST, "select ID,TABLE_NAME,NEXT_ID from `object_type_map` ")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        For I As Integer = 0 To dgvLIST.Rows.Count - 1
            UpdateNextCode(dgvLIST.Rows(I).Cells(0).Value, dgvLIST.Rows(I).Cells(1).Value)

        Next

        RefreshList()
    End Sub

    Private Sub UpdateNextCode(ByVal ThisID As Integer, ByVal ThisTable As String)

        Dim LastID As Double = Val(GetMaxField("ID", ThisTable))
        If LastID = 0 Then

            If MessageBoxWarningYesNo(ThisTable & " this ID is 0. do you want to continue") = True Then
                SqlExecuted($"UPDATE `object_type_map` SET NEXT_ID = '{LastID + 1}' WHERE ID = '{ThisID}' Limit 1 ")
            End If

        Else
            SqlExecuted($"UPDATE `object_type_map` SET NEXT_ID = '{LastID + 1}' WHERE ID = '{ThisID}' Limit 1 ")
        End If


    End Sub
End Class