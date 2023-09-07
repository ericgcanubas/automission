
Public Class frmInventoryAdjustmentTypeDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmInventoryAdjustmentTypeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbACCOUNT_ID, "select `ID`,`NAME` from account where inactive='0'", "ID", "NAME")
        If ID <> 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from inventory_adjustment_type where ID = '" & ID & "' Limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try


        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
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

                SqlExecutedUsingReading(Me, "select * from inventory_adjustment_type where ID = '" & ID & "' Limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter adjustment type description")
            Exit Sub
        End If
        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "inventory_adjustment_type")), "0000")
        End If


        If IsNew = False Then
            SqlExecuted("Update inventory_adjustment_type SET " & SqlUpdate(Me) & " WHERE ID = '" & ID & "'")
        Else
            ID = ObjectTypeMapId("inventory_adjustment_type")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO inventory_adjustment_type ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"select i.ID,i.Code,i.Description, a.`Name`  as `Account` from Inventory_Adjustment_Type as i left outer join account as a on a.ID = i.account_id WHERE i.`ID` = '{ID}' limit 1", IsNew, This_BS)
        ClearAndRefresh(Me)
        IsNew = True
        ID = 0


        If fACCESS_NEW_EDIT(frmInventoryAdjustmentType, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class