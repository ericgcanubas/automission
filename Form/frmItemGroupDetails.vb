
Public Class frmItemGroupDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub frmItemSubClassDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbITEM_TYPE, "SELECT ID,DESCRIPTION FROM ITEM_TYPE_MAP", "ID", "DESCRIPTION")
        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from item_group where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter item group description")
            Exit Sub
        End If

        If Trim(cmbITEM_TYPE.Text) = "" Then
            MessageBoxInfo("Item type is required")
            Exit Sub
        End If

        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "item_group")), "0000")
        End If



        If IsNew = False Then
            SqlExecuted("UPDATE item_group SET " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
        Else
            ID = ObjectTypeMapId("ITEM_GROUP")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO item_group ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"Select ig.ID,ig.Code,ig.Description,itm.Description as `Item Type` from item_group as ig inner join item_type_map as itm on itm.ID = ig.item_type Where ig.ID= '{ID}'  limit 1", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True

        If fACCESS_NEW_EDIT(frmItemGroup, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class