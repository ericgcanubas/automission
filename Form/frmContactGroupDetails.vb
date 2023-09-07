
Public Class frmContactGroupDetails
    Public dgv As DataGridView
    Public This_BS As BindingSource
    Public ID As Integer 
    Public IsNew As Boolean = True
    Private Sub frmContactGroupDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fclear_info()
        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select * from contact_group where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception


            End Try
        End If
    End Sub
    Private Sub fclear_info()
        ComboBoxLoad(cmbTYPE, "select ID,DESCRIPTION from contact_type_map", "ID", "DESCRIPTION")
        txtCODE.Clear()
        txtDescription.Clear()
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
                ID = ""
                ClearAndRefresh(Me)
            Else

                SqlExecutedUsingReading(Me, "select * from contact_group where id = '" & ID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtDescription.Text = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If

        If IsNew = False Then
            If txtCODE.Text = "" Then
                MessageBoxInfo("Please enter code.")
                Exit Sub
            End If

            Dim squery As String = SqlUpdate(Me)
            SqlExecuted("Update contact_group set " & squery & " Where ID = '" & ID & "' ")

        Else

            If Trim(txtCODE.Text) = "" Then
                Dim bCODE_INTEGER As Double = Val(GetMaxField("CODE", "contact_group"))
                txtCODE.Text = bCODE_INTEGER.ToString("0000")
            End If

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO contact_group ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(dgv, $"SELECT cg.ID,cg.`Code`,cg.`Description`, cm.`DESCRIPTION` AS `Type` FROM contact_group AS cg INNER JOIN contact_type_map AS cm ON cm.`ID` = cg.`TYPE` Where cg.ID = '{ID}' limit 1;", IsNew, This_BS)
        fclear_info()
        ID = ""
        IsNew = True
        If fACCESS_NEW_EDIT(frmContactGroup, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class