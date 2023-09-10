
Public Class FrmShipViaDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from ship_via where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter ship via description")
            Exit Sub
        End If

        If txtCODE.Text = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "ship_via")), "0000")
        End If


        If IsNew = False Then
            SqlExecuted("UPDATE ship_via set " & SqlUpdate(Me) & " WHERE ID = '" & ID & "'")
        Else
            ID = ObjectTypeMapId("ship_via")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO ship_via ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"Select ID,Code,Description from Ship_via WHERE ID='{ID}' limit 1 ", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True
        If SecurityAccessMode(frmShipVia, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class