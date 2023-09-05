
Public Class frmItemGroupDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub frmItemSubClassDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fComboBox(cmbITEM_TYPE, "SELECT ID,DESCRIPTION FROM ITEM_TYPE_MAP", "ID", "DESCRIPTION")
        If gsID <> "" Then

            Try

                fExecutedUsingReading(Me, "select * from item_group where id = '" & gsID & "' limit 1")
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

                fExecutedUsingReading(Me, "select * from item_group where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            fMessageboxInfo("Please enter item group description")
            Exit Sub
        End If

        If Trim(cmbITEM_TYPE.Text) = "" Then
            fMessageboxInfo("Item type is required")
            Exit Sub
        End If

        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(Val(fGetMaxField("CODE", "item_group")), "0000")
        End If

        Dim sql As String = fFieldCollector(Me)

        If gsNew = False Then
            fExecutedOnly("UPDATE item_group set " & sql & " Where ID = '" & gsID & "' limit 1")
        Else
            gsID = fObjectTypeMap_ID("ITEM_GROUP")
            fExecutedOnly("INSERT INTO item_group set " & sql & ",ID = '" & gsID & "'")

        End If

        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"Select ig.ID,ig.Code,ig.Description,itm.Description as `Item Type` from item_group as ig inner join item_type_map as itm on itm.ID = ig.item_type Where ig.ID= '{gsID}'  limit 1", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True

        If fACCESS_NEW_EDIT(frmItemGroup, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class