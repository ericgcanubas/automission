Imports System.Data.Odbc
Public Class frmMenuSettingsSetup
    Public ID As Integer = 0
    Public gsMenuType As Boolean = True
    Public IsNew As Boolean = True
    Private Sub frmMenuSettingsSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If gsMenuType = True Then
            'Main Menu

            GroupBox2.Visible = False
            Me.Width = GroupBox1.Width + 30
            Me.Height = GroupBox1.Height + 50
            If ID <> 0 Then
                '   Dim cn As New MySqlConnection(mysqlConstr)
                Try
                    'cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("Select * from tblmenu where menu_id = '" & ID & "' Limit 1")
                    If rd.Read Then
                        numID1.Value = NumIsNull(rd("MENU_ID"))
                        numID1.Enabled = False
                        txtDescription1.Text = TextIsNull(rd("Description"))
                        cmbImage1.Text = TextIsNull(rd("image_file"))
                        chkVisible.Checked = CBool(NumIsNull(rd("visible")))
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
                '  Dim cn As New MySqlConnection(mysqlConstr)
                Try
                    ' cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("Select * from tblsub_menu where sub_id = '" & ID & "' Limit 1")
                    If rd.Read Then
                        numID2.Value = NumIsNull(rd("SUB_ID"))
                        numID2.Enabled = False
                        txtDescription2.Text = TextIsNull(rd("Description"))
                        cmbForm.Text = TextIsNull(rd("form"))
                        cmbImage2.Text = TextIsNull(rd("image_file"))
                        chkAccess_Control.Checked = NumIsNull(rd("access_control"))
                        chkModal.Checked = NumIsNull(rd("modal"))
                        chkActive.Checked = CBool(NumIsNull(rd("active")))
                        IsNew = False
                    End If
                    rd.Close()
                Catch ex As Exception

                    MessageBoxWarning(ex.Message)
                End Try
            End If
        End If


    End Sub

    Private Sub btnCancel1_Click(sender As Object, e As EventArgs) Handles btnCancel1.Click
        Me.Close()
    End Sub

    Private Sub btnCancel2_Click(sender As Object, e As EventArgs) Handles btnCancel2.Click
        Me.Close()
    End Sub

    Private Sub btnSave1_Click(sender As Object, e As EventArgs) Handles btnSave1.Click
        If Trim(txtDescription1.Text) = "" Then
            MessageBoxInfo("Please enter menu description")
            Exit Sub
        End If
        If Trim(cmbImage1.Text) = "" Then
            MessageBoxInfo("Please Image file")
            Exit Sub
        End If


        If numID1.Enabled = True Then
            If GetNumberFieldValue("tblmenu", "MENU_ID", numID1.Value, "MENU_ID") <> 0 Then
                MessageBoxInfo("ID is already used!")
                Exit Sub
            End If
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE tblmenu SET visible='" & IIf(chkVisible.Checked = True, 1, 0) & "',description ='" & txtDescription1.Text & "',image_file = '" & cmbImage1.Text & "'  where MENU_ID = '" & numID1.Value & "'")
        Else
            SqlExecuted("INSERT INTO tblmenu SET visible='" & IIf(chkVisible.Checked = True, 1, 0) & "',description ='" & txtDescription1.Text & "',image_file = '" & cmbImage1.Text & "',MENU_ID = '" & numID1.Value & "',first_display ='0',position_no = '" & GetMaxField("position_no", "tblmenu") & "'")
        End If
        Me.Close()
    End Sub

    Private Sub btnSave2_Click(sender As Object, e As EventArgs) Handles btnSave2.Click
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
            If GetNumberFieldValue("tblsub_menu", "sub_ID", numID2.Value, "sub_ID") <> 0 Then
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

    Private Sub numID1_ValueChanged(sender As Object, e As EventArgs) Handles numID1.ValueChanged

    End Sub

    Private Sub numID1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles numID1.MouseDoubleClick
        If numID1.Enabled = True Then
            numID1.Value = Val(GetMaxField("menu_ID", "tblmenu"))
        End If
    End Sub

    Private Sub numID2_ValueChanged(sender As Object, e As EventArgs) Handles numID2.ValueChanged

    End Sub

    Private Sub numID2_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles numID2.MouseDoubleClick
        If numID2.Enabled = True Then
            numID2.Value = Val(GetMaxField("sub_ID", "tblsub_menu"))
        End If
    End Sub

    Private Sub chkModal_CheckedChanged(sender As Object, e As EventArgs) Handles chkModal.CheckedChanged
        If chkModal.Enabled = True Then
            cmbImage2.Enabled = False
        Else
            cmbImage2.Enabled = True
        End If
    End Sub
End Class