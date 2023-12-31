﻿Public Class FrmItemExpiredDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub FrmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(cmbITEM_ID, "SELECT ID,CODE FROM ITEM WHERE `INACTIVE` ='0' ", "", "")

        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from item_batches where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If

    End Sub
    Private Sub GotBatchNo()
        txtBATCH_NO.Text = Format(Val(GF_GetMaxFieldLine("BATCH_NO", "item_batches", "ITEM_ID", cmbITEM_ID.SelectedValue)), "0000")
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If txtBATCH_NO.Text = "" Then
            GotBatchNo()
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

        If SecurityAccessMode(FrmShipVia, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CmbITEM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbITEM_ID.SelectedIndexChanged
        If IsNew = True Then
            GotBatchNo()
        End If

    End Sub
End Class