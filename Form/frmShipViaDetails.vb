
Public Class frmShipViaDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)

        If gsID <> "" Then
            Try
                fExecutedUsingReading(Me, "select * from ship_via where id = '" & gsID & "' limit 1")
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

                fExecutedUsingReading(Me, "select * from ship_via where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            fMessageboxInfo("Please enter ship via description")
            Exit Sub
        End If

        If txtCODE.Text = "" Then
            txtCODE.Text = Format(Val(fGetMaxField("CODE", "ship_via")), "0000")
        End If

        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("UPDATE ship_via set " & sql & " Where ID = '" & gsID & "' Limit 1")
        Else

            gsID = fObjectTypeMap_ID("ship_via")

            fExecutedOnly("INSERT INTO ship_via set " & sql & ",ID = '" & gsID & "'")

        End If
        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"Select ID,Code,Description from Ship_via WHERE ID='{gsID}' limit 1 ", gsNew, This_BS)
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
End Class