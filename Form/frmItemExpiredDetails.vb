Public Class frmItemExpiredDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbITEM_ID, "SELECT ID,CODE FROM ITEM WHERE `INACTIVE` ='0' ", "", "")

        If gsID <> "" Then
            Try
                fExecutedUsingReading(Me, "select * from item_batches where id = '" & gsID & "' limit 1")
                gsNew = False
            Catch ex As Exception
                fMessageboxWarning(ex.Message)
            End Try
        End If

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs)
        If gsNew = True Then
            fCLean_and_refresh(Me)
        Else
            If fMessageBoxQuestion("Create new?") = True Then
                gsNew = True
                gsID = ""
                fCLean_and_refresh(Me)
            Else

                fExecutedUsingReading(Me, "select * from item_batches where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub
    Private Sub fGotBatchNo()
        txtBATCH_NO.Text = Format(Val(fGetMaxField_LINE("BATCH_NO", "item_batches", "ITEM_ID", cmbITEM_ID.SelectedValue)), "0000")
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click


        If txtBATCH_NO.Text = "" Then
            fGotBatchNo()
        End If

        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("UPDATE item_batches SET " & sql & " Where ID = '" & gsID & "' Limit 1")
        Else

            gsID = fObjectTypeMap_ID("item_batches")

            fExecutedOnly("INSERT INTO item_batches SET " & sql & ",ID = '" & gsID & "'")

        End If
        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"SELECT b.`ID`,i.`CODE`,i.`PURCHASE_DESCRIPTION` AS `DESCRIPTION`,b.`BATCH_NO` AS `BATCH #`,b.`EXPIRY_DATE` AS `EXPIRED ON`  FROM `item_batches`  AS b INNER JOIN item AS i ON i.`ID` = b.`ITEM_ID` WHERE i.`INACTIVE` = '0' and b.id = '{gsID}' limit 1;", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True

        If fACCESS_NEW_EDIT(frmShipVia, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbITEM_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbITEM_ID.SelectedIndexChanged
        If gsNew = True Then
            fGotBatchNo()
        End If

    End Sub
End Class