
Public Class FrmBinLocationDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = "Create Bin"
        If ID > 0 Then

            Try

                SqlExecutedUsingReading(Me, "select * from stock_bin where id = '" & ID & "' limit 1")
                txtCODE.Enabled = False
                IsNew = False
                Me.Text = "Update Bin"
            Catch ex As Exception

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

                SqlExecutedUsingReading(Me, "select * from stock_bin where id = '" & ID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter stock bin description")
            Exit Sub
        End If

        If txtCODE.Text = "" Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "stock_bin")), "0000")
        End If


        If IsNew = False Then
            SqlExecuted("UPDATE stock_bin set " & SqlUpdate(Me) & " Where ID = '" & ID & "' limit 1;")
        Else
            ID = ObjectTypeMapId("stock_bin")
            Dim SQL_Field As String = ""
            Dim SQL_Value As String = ""
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO stock_bin ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
        End If
        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"Select ID,Code,Description from stock_bin Where ID = '{ID}' limit 1;", IsNew, This_BS)
        ClearAndRefresh(Me)
        ID = 0
        IsNew = True
        txtCODE.Enabled = True
        Me.Text = "Create Bin"
        If fACCESS_NEW_EDIT(frmBinLocation, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class