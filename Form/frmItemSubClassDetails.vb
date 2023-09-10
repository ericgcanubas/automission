
Public Class FrmItemSubClassDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public BS As BindingSource
    Public View As DataGridView
    Private Sub frmItemSubClassDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbCLASS_ID, "SELECT ID,DESCRIPTION FROM ITEM_CLASS", "ID", "DESCRIPTION")
        If ID > 0 Then

            Try
                SqlExecutedUsingReading(Me, "select * from item_sub_class where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try


        End If
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter item sub-class description")
            Exit Sub
        End If

        If Trim(cmbCLASS_ID.Text) = "" Then
            MessageBoxInfo("Item class is required")
            Exit Sub
        End If

        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "item_sub_class")), "0000")
        End If

        If IsNew = False Then
            Dim SQL As String = SqlUpdate(Me)
            SqlExecuted($"UPDATE item_sub_class set  {SQL} Where ID = '{ID}'")
        Else
            ID = ObjectTypeMapId("item_sub_class")

            SqlCreate(Me, SQL_FIELD, SQL_VALUE)
            SqlExecuted($"INSERT INTO item_sub_class ({SQL_FIELD},ID) VALUES ({SQL_VALUE},{ID})")
        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(View, $"select isc.ID, isc.Code,isc.Description, ic.Description as `Class` from item_sub_class as isc  inner join item_class as ic on ic.id = isc.class_id Where isc.ID = '{ID}' limit 1", IsNew, BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True


        If SecurityAccessMode(frmItemSubClass, IsNew) = False Then
            Me.Close()
        End If
    End Sub
End Class