Imports System.Data.Odbc
Public Class FrmMenuSettingsSetup
    Public ID As Integer = 0
    Public gsMenuType As Boolean = True
    Public IsNew As Boolean = True
    Private Sub FrmMenuSettingsSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If gsMenuType = True Then
            'Main Menu

            GroupBox2.Visible = False
            Me.Width = GroupBox1.Width + 30
            Me.Height = GroupBox1.Height + 50
            If ID <> 0 Then
                '
                Try

                    Dim rd As OdbcDataReader = SqlReader("Select * from tblmenu where menu_id = '" & ID & "' Limit 1")
                    If rd.Read Then
                        numID1.Value = GF_NumIsNull(rd("MENU_ID"))
                        numID1.Enabled = False
                        txtDescription1.Text = GF_TextIsNull(rd("Description"))
                        cmbImage1.Text = GF_TextIsNull(rd("image_file"))
                        chkVisible.Checked = CBool(GF_NumIsNull(rd("visible")))
                        IsNew = False
                    End If
                    rd.Close()
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                End Try
            End If
        Else
            'Sub Menu
            GroupBox2.Location = GroupBox1.Location
            GroupBox1.Visible = False
            Me.Width = GroupBox2.Width + 30
            Me.Height = GroupBox2.Height + 50
            chkActive.Checked = True
            If ID <> 0 Then

                Try

                    Dim rd As OdbcDataReader = SqlReader("Select * from tblsub_menu where sub_id = '" & ID & "' Limit 1")
                    If rd.Read Then
                        numID2.Value = GF_NumIsNull(rd("SUB_ID"))
                        numID2.Enabled = False
                        txtDescription2.Text = GF_TextIsNull(rd("Description"))
                        cmbForm.Text = GF_TextIsNull(rd("form"))
                        cmbImage2.Text = GF_TextIsNull(rd("image_file"))
                        chkAccess_Control.Checked = GF_NumIsNull(rd("access_control"))
                        chkModal.Checked = GF_NumIsNull(rd("modal"))
                        chkActive.Checked = CBool(GF_NumIsNull(rd("active")))
                        IsNew = False
                    End If
                    rd.Close()
                Catch ex As Exception

                    MessageBoxWarning(ex.Message)
                End Try
            End If
        End If


    End Sub

    Private Sub BtnCancel1_Click(sender As Object, e As EventArgs) Handles btnCancel1.Click
        Me.Close()
    End Sub

    Private Sub BtnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        Me.Close()
    End Sub

    Private Sub BtnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click
        If Trim(txtDescription1.Text) = "" Then
            MessageBoxInfo("Please enter menu description")
            Exit Sub
        End If
        If Trim(cmbImage1.Text) = "" Then
            MessageBoxInfo("Please Image file")
            Exit Sub
        End If


        If numID1.Enabled = True Then
            If GF_GetNumberFieldValue("tblmenu", "MENU_ID", numID1.Value, "MENU_ID") <> 0 Then
                MessageBoxInfo("ID is already used!")
                Exit Sub
            End If
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE tblmenu SET visible='" & IIf(chkVisible.Checked = True, 1, 0) & "',description ='" & txtDescription1.Text & "',image_file = '" & cmbImage1.Text & "'  where MENU_ID = '" & numID1.Value & "'")
        Else
            SqlExecuted("INSERT INTO tblmenu SET visible='" & IIf(chkVisible.Checked = True, 1, 0) & "',description ='" & txtDescription1.Text & "',image_file = '" & cmbImage1.Text & "',MENU_ID = '" & numID1.Value & "',first_display ='0',position_no = '" & GF_GetMaxField("position_no", "tblmenu") & "'")
        End If
        Me.Close()
    End Sub

    Private Sub BtnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
        If Trim(txtDescription2.Text) = "" Then
            MessageBoxInfo("Please enter menu description")
            Exit Sub
        End If
        If Trim(cmbImage2.Text) = "" And chkModal.Checked = False Then
            MessageBoxInfo("Please select Image file")
            Exit Sub
        End If

        If Trim(cmbForm.Text) = "" Then
            MessageBoxInfo("Please select  form ")
            Exit Sub
        End If

        If numID2.Enabled = True Then
            If GF_GetNumberFieldValue("tblsub_menu", "sub_ID", numID2.Value, "sub_ID") <> 0 Then
                MessageBoxInfo("ID is already used!")
                Exit Sub
            End If
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE tblsub_menu SET description ='" & txtDescription2.Text & "',image_file = '" & cmbImage2.Text & "',form = '" & cmbForm.Text & "',access_control = '" & Val(chkAccess_Control.Checked) * -1 & "',modal = '" & Val(chkModal.Checked) * -1 & "',active='" & Val(chkActive.Checked) & "'  where sub_id = '" & numID2.Value & "'")
        Else
            SqlExecuted("INSERT INTO tblsub_menu SET description ='" & txtDescription2.Text & "',image_file = '" & cmbImage2.Text & "',sub_id = '" & numID2.Value & "',form = '" & cmbForm.Text & "',active='" & Val(chkActive.Checked) & "',access_control = '" & Val(chkAccess_Control.Checked) * -1 & "',modal = '" & Val(chkModal.Checked) * -1 & "' ")
        End If
        Me.Close()
    End Sub

    Private Sub NumID1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles numID1.MouseDoubleClick
        If numID1.Enabled = True Then
            numID1.Value = Val(GF_GetMaxField("menu_ID", "tblmenu"))
        End If
    End Sub
    Private Sub NumID2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles numID2.MouseDoubleClick
        If numID2.Enabled = True Then
            numID2.Value = Val(GF_GetMaxField("sub_ID", "tblsub_menu"))
        End If
    End Sub

    Private Sub ChkModal_CheckedChanged(sender As Object, e As EventArgs) Handles chkModal.CheckedChanged
        If chkModal.Enabled = True Then
            cmbImage2.Enabled = False
        Else
            cmbImage2.Enabled = True
        End If
    End Sub
End Class