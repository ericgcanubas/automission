
Public Class FrmItemClassDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub frmItemClassDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If ID > 0 Then

            Try
                SqlExecutedUsingReading(Me, "select * from item_class where id = '" & ID & "' limit 1")
                IsNew = False

            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter Item class description")
            Exit Sub
        End If

        If txtCODE.Text = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "item_class")), "0000")
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE item_class set " & SqlUpdate(Me) & " Where ID = '" & ID & "' ")
        Else
            ID = ObjectTypeMapId("item_class")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO item_class ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If


        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, "Select ID,Code,Description from item_class WHERE ID = '" & ID & "' limit 1", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True

        If SecurityAccessMode(frmItemClass, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class