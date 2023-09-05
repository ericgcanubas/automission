
Public Class frmUnitofMeasureDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmShipViaDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)

        If gsID <> "" Then
            Try
                fExecutedUsingReading(Me, "select * from unit_of_measure where id = '" & gsID & "' Limit 1")
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

                fExecutedUsingReading(Me, "select * from unit_of_measure where id = '" & gsID & "' Limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            fMessageboxInfo("Please enter unit of measure name")
            Exit Sub
        End If

        If Trim(txtSymbol.Text) = "" Then
            fMessageboxInfo("Please enter unit of measure symbol")
            Exit Sub
        End If


        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("UPDATE unit_of_measure set " & sql & " Where ID = '" & gsID & "' Limit 1")
        Else
            gsID = fObjectTypeMap_ID("unit_of_measure")
            fExecutedOnly("INSERT INTO unit_of_measure set " & sql & ",ID = '" & gsID & "'")
        End If
        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"Select ID,`Name`,Symbol, If(Inactive=0,'No','Yes') as `Inactive` from Unit_of_measure Where ID = '{gsID}' limit 1", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True
        If fACCESS_NEW_EDIT(frmUnitofMeasure, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class