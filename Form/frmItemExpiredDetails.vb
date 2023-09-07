Public Class frmItemExpiredDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbITEM_ID, "SELECT ID,CODE FROM ITEM WHERE `INACTIVE` ='0' ", "", "")

        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from item_batches where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs)
        If IsNew = True Then
            ClearAndRefresh(Me)
        Else
            If MessageBoxQuestion("Create new?") = True Then
                IsNew = True
                ID = 0
                ClearAndRefresh(Me)
            Else

                SqlExecutedUsingReading(Me, "select * from item_batches where id = '" & ID & "' limit 1")
            End If
        End If
    End Sub
    Private Sub fGotBatchNo()
        txtBATCH_NO.Text = Format(Val(GetMaxFieldLine("BATCH_NO", "item_batches", "ITEM_ID", cmbITEM_ID.SelectedValue)), "0000")
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If txtBATCH_NO.Text = "" Then
            fGotBatchNo()
        End If


        If IsNew = False Then
            SqlExecuted("UPDATE item_batches SET " & SqlUpdate(Me) & " Where ID = '" & ID & "' ")
        Else

            ID = ObjectTypeMapId("item_batches")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO item_batches ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If
        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"SELECT b.`ID`,i.`CODE`,i.`PURCHASE_DESCRIPTION` AS `DESCRIPTION`,b.`BATCH_NO` AS `BATCH #`,b.`EXPIRY_DATE` AS `EXPIRED ON`  FROM `item_batches`  AS b INNER JOIN item AS i ON i.`ID` = b.`ITEM_ID` WHERE i.`INACTIVE` = '0' and b.id = '{ID}' limit 1;", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True

        If fACCESS_NEW_EDIT(frmShipVia, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbITEM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbITEM_ID.SelectedIndexChanged
        If IsNew = True Then
            fGotBatchNo()
        End If

    End Sub
End Class