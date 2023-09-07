
Public Class frmLocationDetails
    Public gsID As String
    Public gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLocationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbPRICE_LEVEL_ID, "SELECT `ID`,`DESCRIPTION` from price_level ", "ID", "DESCRIPTION")
        If gsID <> "" Then
            gsNew = False
            fRefresh()
        End If

    End Sub
    Private Sub fRefresh()

        Try

            Dim sQuery As String = "select * from location where id = '" & gsID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefresh()
            Else
                End
            End If
        End Try
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtNAME.Text.Trim = "" Then
            MessageBoxWarning("Please enter description")
            Exit Sub
        End If

        If txtCODE.Text.Trim.Length = 0 Then
            MessageBoxInfo("Please enter code")
            Exit Sub
        End If


        If gsNew = False Then
            SqlExecuted("UPDATE location set  `CODE`='" & txtCODE.Text & "', `NAME` = '" & txtNAME.Text & "', PRICE_LEVEL_ID = " & GotNullNumber(cmbPRICE_LEVEL_ID.SelectedValue) & ",inactive ='" & Val(chkINACTIVE.Checked) & "'  where id = '" & gsID & "' limit 1")

        Else
            gsID = ObjectTypeMapId("LOCATION")
            SqlExecuted("INSERT INTO location set `CODE`='" & txtCODE.Text & "',`NAME` = '" & txtNAME.Text & "', PRICE_LEVEL_ID = " & GotNullNumber(cmbPRICE_LEVEL_ID.SelectedValue) & ",inactive ='" & Val(chkINACTIVE.Checked) & "',Id = '" & gsID & "'")

        End If

        If gsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If
        BindingViewUpdate(Dgv, $"select  l.`ID`,l.`CODE`,l.`Name`,ifnull(p.DESCRIPTION,'') as `Price level`,l.Inactive from location as l left outer join price_level as p on p.ID = l.price_level_id WHERE  l.`ID` ='{gsID}' Limit 1;", gsNew, This_BS)
        ClearAndRefresh(Me)
        gsNew = True
        gsID = ""

        If fACCESS_NEW_EDIT(frmLocation, gsNew) = False Then
            Me.Close()
        End If

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs)
        If gsNew = True Then
            ClearAndRefresh(Me)
        Else

            If MessageBoxQuestion("Create new?") = True Then
                gsNew = True
                gsID = ""
                ClearAndRefresh(Me)
            Else

                fRefresh()
            End If
        End If
    End Sub
End Class