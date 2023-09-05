
Public Class frmContactGroupDetails
    Public dgv As DataGridView
    Public This_BS As BindingSource
    Public gsID As String
    Public gsNew As Boolean = True
    Private Sub frmContactGroupDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' fBackGroundImageStyle(Me)
        fclear_info()
        If gsID <> "" Then
            Try
                '
                fExecutedUsingReading(Me, "select * from contact_group where id = '" & gsID & "' limit 1")
                gsNew = False

            Catch ex As Exception


            End Try
        End If



    End Sub
    Private Sub fclear_info()
        fComboBox(cmbTYPE, "select ID,DESCRIPTION from contact_type_map", "ID", "DESCRIPTION")
        txtCODE.Clear()
        txtDescription.Clear()
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

                fExecutedUsingReading(Me, "select * from contact_group where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtDescription.Text = "" Then
            fMessageboxInfo("Please enter description")
            Exit Sub
        End If

        If gsNew = False Then
            If txtCODE.Text = "" Then
                fMessageboxInfo("Please enter code.")
                Exit Sub
            End If

            Dim squery As String = fFieldCollector(Me)
            fExecutedOnly("Update contact_group set " & squery & " Where ID = '" & gsID & "' limit 1")
        Else
            If Trim(txtCODE.Text) = "" Then
                Dim bCODE_INTEGER As Double = Val(fGetMaxField("CODE", "contact_group"))
                txtCODE.Text = bCODE_INTEGER.ToString("0000")
            End If
            Dim squery As String = fFieldCollector(Me)

            gsID = fObjectTypeMap_ID("contact_group")
            fExecutedOnly("INSERT INTO contact_group SET " & squery & ", ID = '" & gsID & "'")

        End If

        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(dgv, $"SELECT cg.ID,cg.`Code`,cg.`Description`, cm.`DESCRIPTION` AS `Type` FROM contact_group AS cg INNER JOIN contact_type_map AS cm ON cm.`ID` = cg.`TYPE` Where cg.ID = '{gsID}' limit 1;", gsNew, This_BS)
        fclear_info()
        gsID = ""
        gsNew = True
        If fACCESS_NEW_EDIT(frmContactGroup, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class