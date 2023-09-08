
Public Class FrmReportSettingDetails
    Public ID As Integer
    Public IsNew As Boolean = False


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Val(txtSUB_ID.Text) = 0 Then
            MessageBoxInfo("Please enter report id")
            Exit Sub
        End If

        If txtDESCRIPTION.Text = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If


        If IsNew = True Then
            ID = Val(txtSUB_ID.Text)

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO tblsub_menu ({SQL_Field}) VALUES ({SQL_Value}) ")
            SqlExecuted("INSERT INTO tblmenu_list SET MENU_ID ='5',SUB_ID ='" & ID & "',position_no='" & GetMaxFieldLine("position_no", "tblMENU_LIST", "MENU_ID", "5") & "'")
        Else
            SqlExecuted("UPDATE tblsub_menu SET " & SqlUpdate(Me).Replace(",SUB_ID ='" & ID & "'", "") & " Where SUB_ID ='" & ID & "'")


        End If
        Dim t As Integer = cmbGROUP_LINE.SelectedValue

        ClearAndRefresh(Me)
        btnSave.Text = "Save"
        txtSUB_ID.Text = GetMaxField("SUB_ID", "tblsub_menu")
        IsNew = True
        cmbGROUP_LINE.SelectedValue = t
    End Sub

    Private Sub frmReportSettingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        ComboBoxLoad(cmbGROUP_LINE, "select * from report_group ", "ID", "DESCRIPTION")
        If IsNew = True Then
            txtSUB_ID.Text = GetMaxField("SUB_ID", "tblsub_menu")
            chkActive.Checked = True
        Else
            btnSave.Text = "Update"
            txtSUB_ID.Enabled = False
            Try

                SqlExecutedUsingReading(Me, "select * from tblsub_menu where sub_id = '" & ID & "'")

            Catch ex As Exception

                MessageBoxWarning(ex.Message)
            End Try

        End If

    End Sub
End Class