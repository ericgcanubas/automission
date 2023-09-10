
Public Class FrmLocationDetails
    Public ID As String
    Public IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmLocationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbPRICE_LEVEL_ID, "SELECT `ID`,`DESCRIPTION` from price_level ", "ID", "DESCRIPTION")
        If ID > 0 Then
            IsNew = False
            fRefresh()
        End If

    End Sub
    Private Sub fRefresh()

        Try

            Dim sQuery As String = "select * from location where id = '" & ID & "' Limit 1"
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


        If IsNew = False Then
            SqlExecuted("UPDATE location set  `CODE`='" & txtCODE.Text & "', `NAME` = '" & txtNAME.Text & "', PRICE_LEVEL_ID = " & GotNullNumber(cmbPRICE_LEVEL_ID.SelectedValue) & ",inactive ='" & Val(chkINACTIVE.Checked) & "'  where id = '" & ID & "' limit 1")

        Else
            ID = ObjectTypeMapId("LOCATION")
            SqlExecuted("INSERT INTO location set `CODE`='" & txtCODE.Text & "',`NAME` = '" & txtNAME.Text & "', PRICE_LEVEL_ID = " & GotNullNumber(cmbPRICE_LEVEL_ID.SelectedValue) & ",inactive ='" & Val(chkINACTIVE.Checked) & "',Id = '" & ID & "'")

        End If

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If
        BindingViewUpdate(Dgv, $"select  l.`ID`,l.`CODE`,l.`Name`,ifnull(p.DESCRIPTION,'') as `Price level`,l.Inactive from location as l left outer join price_level as p on p.ID = l.price_level_id WHERE  l.`ID` ='{ID}' Limit 1;", IsNew, This_BS)
        ClearAndRefresh(Me)
        IsNew = True
        ID = 0

        If SecurityAccessMode(frmLocation, IsNew) = False Then
            Me.Close()
        End If

    End Sub

End Class