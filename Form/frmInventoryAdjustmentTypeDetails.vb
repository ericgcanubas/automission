
Public Class frmInventoryAdjustmentTypeDetails
    Public gsID As String
    Dim gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub frmInventoryAdjustmentTypeDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fComboBox(cmbACCOUNT_ID, "select `ID`,`NAME` from account where inactive='0'", "ID", "NAME")
        If gsID <> "" Then
            Try
                fExecutedUsingReading(Me, "select * from inventory_adjustment_type where ID = '" & gsID & "' Limit 1")
                gsNew = False
            Catch ex As Exception
                fMessageboxWarning(ex.Message)
            End Try


        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
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

                fExecutedUsingReading(Me, "select * from inventory_adjustment_type where ID = '" & gsID & "' Limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            fMessageboxInfo("Please enter adjustment type description")
            Exit Sub
        End If
        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(Val(fGetMaxField("CODE", "inventory_adjustment_type")), "0000")
        End If

        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("Update inventory_adjustment_type Set " & sql & " Where ID = '" & gsID & "' Limit 1")
        Else
            gsID = fObjectTypeMap_ID("inventory_adjustment_type")
            fExecutedOnly("INSERT INTO inventory_adjustment_type Set " & sql & ", ID = '" & gsID & "'")
        End If
        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"select i.ID,i.Code,i.Description, a.`Name`  as `Account` from Inventory_Adjustment_Type as i left outer join account as a on a.ID = i.account_id WHERE i.`ID` = '{gsID}' limit 1", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsNew = True
        gsID = ""


        If fACCESS_NEW_EDIT(frmInventoryAdjustmentType, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class