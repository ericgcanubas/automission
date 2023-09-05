
Public Class frmClassDetails
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Public gsID As String = ""
    Dim gsNew As Boolean = True
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub frmClassDetails_Load(sender As Object, e As EventArgs) Handles Me.Load

        If gsID <> "" Then

            Try

                fExecutedUsingReading(Me, "select * from class where id = '" & gsID & "' Limit 1")

                gsNew = False
            Catch ex As Exception


            End Try

        End If

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

                fExecutedUsingReading(Me, "select * from class where id = '" & gsID & "' Limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            fMessageboxInfo("Please enter class name")
            Exit Sub
        End If
        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("UPDATE class set " & sql & " Where ID ='" & gsID & "' limit 1")
        Else
            gsID = fObjectTypeMap_ID("CLASS")
            fExecutedOnly("INSERT INTO class set " & sql & ",ID ='" & gsID & "'")

        End If
        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"Select ID,`Name`, if(`Inactive`=0,'No','Yes') as `Inactive` from Class Where `ID` = '{gsID}'", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True
        If fACCESS_NEW_EDIT(frmClass, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class