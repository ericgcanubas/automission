
Public Class frmLocationDetails
    Public gsID As String
    Public gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLocationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fComboBox(cmbPRICE_LEVEL_ID, "SELECT `ID`,`DESCRIPTION` from price_level ", "ID", "DESCRIPTION")
        If gsID <> "" Then
            gsNew = False
            fRefresh()
        End If

    End Sub
    Private Sub fRefresh()

        Try

            Dim sQuery As String = "select * from location where id = '" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)

        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh()
            Else
                End
            End If
        End Try
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtNAME.Text.Trim = "" Then
            fMessageboxWarning("Please enter description")
            Exit Sub
        End If

        If txtCODE.Text.Trim.Length = 0 Then
            fMessageboxInfo("Please enter code")
            Exit Sub
        End If


        If gsNew = False Then
            fExecutedOnly("UPDATE location set  `CODE`='" & txtCODE.Text & "', `NAME` = '" & txtNAME.Text & "', PRICE_LEVEL_ID = " & fGotNullNumber(cmbPRICE_LEVEL_ID.SelectedValue) & ",inactive ='" & Val(chkINACTIVE.Checked) & "'  where id = '" & gsID & "' limit 1")

        Else
            gsID = fObjectTypeMap_ID("LOCATION")
            fExecutedOnly("INSERT INTO location set `CODE`='" & txtCODE.Text & "',`NAME` = '" & txtNAME.Text & "', PRICE_LEVEL_ID = " & fGotNullNumber(cmbPRICE_LEVEL_ID.SelectedValue) & ",inactive ='" & Val(chkINACTIVE.Checked) & "',Id = '" & gsID & "'")

        End If

        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If
        fBindDgvUpdate(Dgv, $"select  l.`ID`,l.`CODE`,l.`Name`,ifnull(p.DESCRIPTION,'') as `Price level`,l.Inactive from location as l left outer join price_level as p on p.ID = l.price_level_id WHERE  l.`ID` ='{gsID}' Limit 1;", gsNew, This_BS)
        fCLean_and_refresh(Me)
        gsNew = True
        gsID = ""

        If fACCESS_NEW_EDIT(frmLocation, gsNew) = False Then
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

                fRefresh()
            End If
        End If
    End Sub
End Class