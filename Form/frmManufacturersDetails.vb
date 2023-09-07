
Public Class frmManufacturersDetails
    Public ID As String
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If ID <> "" Then

            Try

                SqlExecutedUsingReading(Me, "select * from manufacturer where id = '" & ID & "' limit 1")

                IsNew = False

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            MessageBoxInfo("Please enter manufacturer name")
            Exit Sub
        End If

        If txtCODE.Text = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "manufacturer")), "0000")
        End If


        If IsNew = False Then
            SqlExecuted("UPDATE manufacturer set " & SqlUpdate(Me) & " Where ID = '" & ID & "' limit 1")
        Else
            ID = ObjectTypeMapId("manufacturer")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO manufacturer ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
        End If

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        BindingViewUpdate(Dgv, $"Select ID,Code,`Name` from Manufacturer WHERE ID='{ID}' limit 1", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = ""
        IsNew = True


        If fACCESS_NEW_EDIT(frmManufacturers, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs)
        If IsNew = True Then
            ClearAndRefresh(Me)
        Else
            If MessageBoxQuestion("Create new?") = True Then
                IsNew = True
                ID = ""
                ClearAndRefresh(Me)
            Else

                SqlExecutedUsingReading(Me, "select * from manufacturer where id = '" & ID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class