
Public Class frmManufacturersDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)

        If gsID <> "" Then

            Try

                fExecutedUsingReading(Me, "select * from manufacturer where id = '" & gsID & "' limit 1")

                gsNew = False

            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            fMessageboxInfo("Please enter manufacturer name")
            Exit Sub
        End If

        If txtCODE.Text = "" Then
            txtCODE.Text = Format(Val(fGetMaxField("CODE", "manufacturer")), "0000")
        End If

        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("UPDATE manufacturer set " & sql & " Where ID = '" & gsID & "' limit 1")
        Else
            gsID = fObjectTypeMap_ID("manufacturer")
            fExecutedOnly("INSERT INTO manufacturer set " & sql & ",ID = '" & gsID & "'")

        End If

        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If

        fBindDgvUpdate(Dgv, $"Select ID,Code,`Name` from Manufacturer WHERE ID='{gsID}' limit 1", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True


        If fACCESS_NEW_EDIT(frmManufacturers, gsNew) = False Then
            Me.Close()
        End If
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

                fExecutedUsingReading(Me, "select * from manufacturer where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class