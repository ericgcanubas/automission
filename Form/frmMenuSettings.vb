Imports System.IO
Public Class FrmMenuSettings
    Private Sub frmMenuSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fFormLoad()
        fMainMenu()
        fSub()

        fRefreshImageList()
        fRefreshImageList_menu()
    End Sub

    Private Sub fMainMenu()
        Try
            LoadDataGridView(dgvMenu, "select menu_id as `ID`,`Description`,`Image_file` as `Image File`, if(Visible = 1, 'True','False') as Visible  From tblmenu where menu_id <> '5' ")
            dgvMenu.Columns(0).Width = 50
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub
    Private Sub fSub()
        Try

            LoadDataGridView(dgvSub, "select s.sub_id as `ID`,s.`Description`,s.`Form`, s.`image_file` as `Image File` from tblsub_menu as s where s.group_line ='0' ")
            dgvSub.Columns(0).Width = 50
        Catch ex As Exception
            MessageBoxWarning(ex.Message)

        End Try
    End Sub
    Private Sub fSUbMenu()
        Try
            If dgvMenu.Rows.Count = 0 Then dgvSubMenu.Rows.Clear() : Exit Sub

            Dim i As Integer = dgvMenu.CurrentRow.Index
            Dim id As Integer = dgvMenu.Rows(i).Cells(0).Value
            LoadDataGridView(dgvSubMenu, "select s.sub_id as `ID`,s.`Description` from tblsub_menu as s inner join tblmenu_list as l on l.sub_id = s.sub_id where l.menu_id ='" & id & "' ")
            dgvSubMenu.Columns(0).Width = 50
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub
    Private Sub fFormLoad()
        Try
            Dim myAssembly As System.Reflection.Assembly = System.Reflection.Assembly.GetExecutingAssembly()

            Dim types As Type() = myAssembly.GetTypes()
            For Each t As Type In types
                If UCase(t.BaseType.ToString) = "SYSTEM.WINDOWS.FORMS.FORM" Then

                    lstForms.Items.Add(t.Name.ToString)
                End If
            Next
        Catch ex As Exception
            ' fMessageboxError(ex)
        End Try


    End Sub
    Private Sub fRefreshImageList()
        Try


            Dim filepath As String = Application.StartupPath & "\image\sub\"
            'Set ListView view mode to show Large Icons
            lvImage.View = View.LargeIcon

            Dim dirs As String() = Directory.GetDirectories(filepath)
            Dim dir As String

            For Each dir In dirs
                dir = dir.Replace(dir.Substring(0, dir.LastIndexOf("\") + 1), "")
                lvImage.Items.Add(New ListViewItem(dir, dir))
            Next



            Dim filesList As String() = Directory.GetFiles(filepath)
            Dim files As String
            Dim files2 As String

            For Each files In filesList
                files2 = files.Replace(files.Substring(0, files.LastIndexOf("\") + 1), "")

                ImageList1.Images.Add(files2, Bitmap.FromFile(files))

            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        fLoadImage()
    End Sub
    Private Sub fLoadImage()

        For i As Integer = 0 To ImageList1.Images.Count - 1
            lvImage.Items.Add(ImageList1.Images.Keys(i).ToString, i)
        Next


    End Sub

    Private Sub dgvMenu_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellContentClick

    End Sub

    Private Sub dgvMenu_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.CellClick

    End Sub

    Private Sub dgvMenu_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvMenu.RowStateChanged

    End Sub

    Private Sub dgvMenu_Enter(sender As Object, e As EventArgs) Handles dgvMenu.Enter

    End Sub

    Private Sub dgvMenu_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.RowEnter

    End Sub

    Private Sub dgvMenu_RowValidated(sender As Object, e As DataGridViewCellEventArgs) Handles dgvMenu.RowValidated

    End Sub

    Private Sub dgvMenu_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMenu.SelectionChanged
        fSUbMenu()
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click


        Dim cmbI As ComboBox = frmMenuSettingsSetup.cmbImage1
        For i As Integer = 0 To lvMENU.Items.Count - 1
            cmbI.Items.Add(lvMENU.Items(i).Text)
        Next

        frmMenuSettingsSetup.ShowDialog()
        frmMenuSettingsSetup.Dispose()
        frmMenuSettingsSetup = Nothing
        fMainMenu()
    End Sub

    Private Sub AddToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem1.Click
        frmMenuSettingsSetup.gsMenuType = False
        Dim cmbF As ComboBox = frmMenuSettingsSetup.cmbForm

        For i As Integer = 0 To lstForms.Items.Count - 1
            cmbF.Items.Add(lstForms.Items(i))
        Next
        Dim cmbI As ComboBox = frmMenuSettingsSetup.cmbImage2
        For i As Integer = 0 To lvImage.Items.Count - 1
            cmbI.Items.Add(lvImage.Items(i).Text)
        Next


        frmMenuSettingsSetup.ShowDialog()
        frmMenuSettingsSetup.Dispose()
        frmMenuSettingsSetup = Nothing
        fSub()
    End Sub



    Private Sub fRefreshImageList_menu()
        Try


            Dim filepath As String = Application.StartupPath & "\image\menu\"
            'Set ListView view mode to show Large Icons
            lvMENU.View = View.LargeIcon

            Dim dirs As String() = Directory.GetDirectories(filepath)
            Dim dir As String

            For Each dir In dirs
                dir = dir.Replace(dir.Substring(0, dir.LastIndexOf("\") + 1), "")
                lvMENU.Items.Add(New ListViewItem(dir, dir))
            Next

            ''Create ImageList objects. 
            'Dim imageListLarge As New ImageList()
            'imageListLarge.ImageSize = New Size(100, 100)

            Dim filesList As String() = Directory.GetFiles(filepath)
            Dim files As String
            Dim files2 As String
            ' Dim c As Integer = -1
            For Each files In filesList
                files2 = files.Replace(files.Substring(0, files.LastIndexOf("\") + 1), "")
                ' files2 = files2.Replace(".png", "")
                ImageList2.Images.Add(files2, Bitmap.FromFile(files))
                '     c = c + 1
            Next

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        fLoadImage_menu()
    End Sub
    Private Sub fLoadImage_menu()

        For i As Integer = 0 To ImageList2.Images.Count - 1
            lvMENU.Items.Add(ImageList2.Images.Keys(i).ToString, i)
        Next


    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem1.Click
        Try
            frmMenuSettingsSetup.ID = dgvSub.Rows(dgvSub.CurrentRow.Index).Cells("ID").Value
            frmMenuSettingsSetup.gsMenuType = False
            Dim cmbF As ComboBox = frmMenuSettingsSetup.cmbForm

            For i As Integer = 0 To lstForms.Items.Count - 1
                cmbF.Items.Add(lstForms.Items(i))
            Next
            Dim cmbI As ComboBox = frmMenuSettingsSetup.cmbImage2
            For i As Integer = 0 To lvImage.Items.Count - 1
                cmbI.Items.Add(lvImage.Items(i).Text)
            Next


            frmMenuSettingsSetup.ShowDialog()
            frmMenuSettingsSetup.Dispose()
            frmMenuSettingsSetup = Nothing
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
        fSub()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        Try
            Dim cmbI As ComboBox = frmMenuSettingsSetup.cmbImage1
            For i As Integer = 0 To lvMENU.Items.Count - 1
                cmbI.Items.Add(lvMENU.Items(i).Text)
            Next
            frmMenuSettingsSetup.ID = dgvMenu.Rows(dgvMenu.CurrentRow.Index).Cells("ID").Value
            frmMenuSettingsSetup.ShowDialog()
            frmMenuSettingsSetup.Dispose()
            frmMenuSettingsSetup = Nothing
            fMainMenu()
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvMenu.Rows.Count = 0 Then
            MessageBoxInfo("Menu not found!")
            Exit Sub
        End If

        If dgvSub.Rows.Count = 0 Then
            MessageBoxInfo("Sub menu not found!")
            Exit Sub
        End If

        Dim menu_id As Integer = dgvMenu.Rows(dgvMenu.CurrentRow.Index).Cells(0).Value
        Dim sub_id As Integer = dgvSub.Rows(dgvSub.CurrentRow.Index).Cells(0).Value

        SqlExecuted("INSERT INTO tblmenu_list SET menu_id ='" & menu_id & "',sub_id='" & sub_id & "',position_no = '" & Val(GetMaxFieldLine("position_no", "tblmenu_list", "menu_id", menu_id)) & "'  ")

        fSub()
        fSUbMenu()
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvSubMenu.Rows.Count = 0 Then

            Exit Sub
        End If

        Dim i As Integer = dgvSubMenu.Rows(dgvSubMenu.CurrentRow.Index).Cells(0).Value
        SqlExecuted("DELETE FROM tblmenu_list where sub_id = '" & i & "'")
        fSub()
        fSUbMenu()
    End Sub
    Private Sub dgvSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellDoubleClick
        EditToolStripMenuItem1_Click(sender, e)
    End Sub
End Class