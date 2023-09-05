Imports MySql.Data.MySqlClient
Public Class frmReportSettingDetails
    Public gsID As Integer
    Public gsNew As Boolean = False


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Val(txtSUB_ID.Text) = 0 Then
            fMessageboxInfo("Please enter report id")
            Exit Sub
        End If

        If txtDESCRIPTION.Text = "" Then
            fMessageboxInfo("Please enter description")
            Exit Sub
        End If
        Dim sQuery As String = fFieldCollector(Me)

        If gsNew = True Then
            gsID = Val(txtSUB_ID.Text)

            fExecutedOnly("INSERT INTO tblsub_menu SET " & sQuery)
            fExecutedOnly("INSERT INTO tblmenu_list SET MENU_ID ='5',SUB_ID ='" & gsID & "',position_no='" & fGetMaxField_LINE("position_no", "tblMENU_LIST", "MENU_ID", "5") & "'")
        Else
            fExecutedOnly("UPDATE tblsub_menu SET " & sQuery.Replace(",SUB_ID ='" & gsID & "'", "") & " Where SUB_ID ='" & gsID & "'")


        End If
        Dim t As Integer = cmbGROUP_LINE.SelectedValue

        fCLean_and_refresh(Me)
        btnSave.Text = "Save"
        txtSUB_ID.Text = fGetMaxField("SUB_ID", "tblsub_menu")
        gsNew = True
        cmbGROUP_LINE.SelectedValue = t
    End Sub

    Private Sub frmReportSettingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fBackGroundImageStyle(Me)
        fComboBox(cmbGROUP_LINE, "select * from report_group ", "ID", "DESCRIPTION")
        If gsNew = True Then
            txtSUB_ID.Text = fGetMaxField("SUB_ID", "tblsub_menu")
            chkActive.Checked = True
        Else
            btnSave.Text = "Update"
            txtSUB_ID.Enabled = False
            Try

                fExecutedUsingReading(Me, "select * from tblsub_menu where sub_id = '" & gsID & "'")

            Catch ex As Exception

                fMessageboxWarning(ex.Message)
            End Try

        End If

    End Sub
End Class