
Public Class frmItemSubClassDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmItemSubClassDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fComboBox(cmbCLASS_ID, "SELECT ID,DESCRIPTION FROM ITEM_CLASS", "ID", "DESCRIPTION")
        If gsID <> "" Then

            Try
                fExecutedUsingReading(Me, "select * from item_sub_class where id = '" & gsID & "' limit 1")
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
                fExecutedUsingReading(Me, "select * from item_sub_class where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            fMessageboxInfo("Please enter item sub-class description")
            Exit Sub
        End If

        If Trim(cmbCLASS_ID.Text) = "" Then
            fMessageboxInfo("Item class is required")
            Exit Sub
        End If

        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(Val(fGetMaxField("CODE", "item_sub_class")), "0000")
        End If

        Dim sql As String = fFieldCollector(Me)

        If gsNew = False Then
            fExecutedOnly("UPDATE item_sub_class set " & sql & " Where ID = '" & gsID & "' limit 1")
        Else
            gsID = fObjectTypeMap_ID("item_sub_class")
            fExecutedOnly("INSERT INTO item_sub_class set " & sql & ",ID = '" & gsID & "'")

        End If
        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If
        fBindDgvUpdate(Dgv, $"select isc.ID, isc.Code,isc.Description, ic.Description as `Class` from item_sub_class as isc  inner join item_class as ic on ic.id = isc.class_id Where isc.ID = '{gsID}' limit 1", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsID = ""
        gsNew = True


        If fACCESS_NEW_EDIT(frmItemSubClass, gsNew) = False Then
            Me.Close()
        End If
    End Sub
End Class