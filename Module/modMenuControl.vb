Imports System.Data.Odbc
Imports System.Reflection
Module modMenuControl

    Public CurrentPath As String = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase)
    Public Sub ThisOpenMenuTool(sender As Object, e As EventArgs)

        If gsMenuSubID = "32" Then

        Else

        End If
        gsMenuSubID = ""
        Dim Btn As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)



        Dim Img As Image = Btn.Image
        Dim f As Form = GetForm(Btn.AccessibleName)
        If f Is Nothing Then
            fMessageboxExclamation("Menu not found.")
            Exit Sub
        End If
        Dim bAllowed As Boolean = True
        gsSubMenuForm = Btn.Text
        f.Text = Btn.Text
        f.Tag = Btn.Tag


        If bAllowed = True Then

            TabFormOpen(f, frmMainMenu.MyTab, Img)

        Else
            fMessageboxExclamation("No access control.")
        End If


    End Sub
    Public Sub ThisOpenMenu(sender As Object, e As EventArgs)
        Dim Btn As ToolStripButton = DirectCast(sender, ToolStripButton)
        Dim Img As Image = Btn.Image

        Dim f As Form = GetForm(Btn.AccessibleName)
        If f Is Nothing Then
            fMessageboxExclamation("Menu not found.")
            Exit Sub
        End If
        Dim bAllowed As Boolean = True
        gsSubMenuForm = Btn.Text
        f.Text = Btn.Text
        f.Tag = Btn.Tag

        If bAllowed = True Then

            TabFormOpen(f, frmMainMenu.MyTab, Img)

        Else
            fMessageboxExclamation("No access control.")
        End If


    End Sub
    Public Sub TabFormOpen(ByVal F As Form, ByVal T As MdiTabControl.TabControl, ByVal img As Image)

        ' F.BackColor = Color.White
        Dim This_Sub_ID As String = F.Tag
        Dim SQL As String = $"select  * from tblsub_menu where sub_id = '{This_Sub_ID}' limit 1;"


        Dim bModal As Boolean = False
        If gsMenuSubID = "32" Then
            bModal = False



            For n As Integer = 0 To T.TabPages.Count - 1
                Dim fm As Form = T.TabPages.Item(n).Form
                If fm.Text = F.Text Then

                    T.TabPages(n).Select()
                    Exit Sub
                End If
            Next n


        ElseIf gsMenuSubID = "31" Then
            bModal = False

        Else

            Dim GetForms = System.Windows.Forms.Application.OpenForms
            For i As Int16 = 0I To GetForms.Count - 1I
                If GetForms.Item(i).Name = F.Name Then
                    GetForms.Item(i).Activate()

                    For n As Integer = 0 To T.TabPages.Count - 1
                        Dim fm As Form = T.TabPages.Item(n).Form
                        If fm.Name = F.Name Then

                            T.TabPages(n).Select()
                            Exit Sub
                        End If
                    Next n
                End If
            Next i


            Dim rd As OdbcDataReader = fReader(SQL)

            If rd.Read Then
                bModal = fNumisNULL(rd("modal"))

            End If
            rd.Close()
            If fSystem_Security(This_Sub_ID) = False Then
                Exit Sub
            End If

        End If


        Try



            Dim bmp As System.Drawing.Bitmap = img
            Dim ico As System.Drawing.Icon = System.Drawing.Icon.FromHandle(bmp.GetHicon())
            F.Icon = ico
            F.AccessibleName = This_Sub_ID

            'banner_default.jpg
            If F.Contains(F.Controls("Panel1")) = True Then



                Dim p As Panel = F.Controls("Panel1")

                Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\toolbar\"
                ' p.BackgroundImage = Image.FromFile(folder & "banner_default1.jpg")
                ' p.BackgroundImageLayout = ImageLayout.Stretch
                Dim L As Label = p.Controls("Label1")
                Dim Pic As PictureBox = p.Controls("PictureBox1")
                Pic.Image = img
                ' Pic.BackColor = Color.Transparent
                Pic.Parent = p

                'L.BackColor = Color.Transparent
                L.Parent = p
                ' L.ForeColor = Color.Whit
            Else

                Dim TS As ToolStrip = F.Controls("ToolStrip1")
                If TS IsNot Nothing Then
                    Dim L As ToolStripLabel = TS.Items("tsTITLE")
                    L.Image = img
                End If


            End If
        Catch ex As Exception
        End Try
        ' BackGroundForm(F)
        Try
            If bModal = False Then

                T.TabPages.Add(F)
            Else
                F.ShowDialog()
                F.Dispose()
                F = Nothing
            End If
        Catch ex As Exception

        End Try

    End Sub
    Public Function CreateObjectInstance(ByVal objectName As String) As Object
        Dim obj As Object
        Try
            If objectName.LastIndexOf(".") = -1 Then
                objectName = [Assembly].GetEntryAssembly.GetName.Name & "." & objectName
            End If

            obj = [Assembly].GetEntryAssembly.CreateInstance(objectName)

        Catch ex As Exception
            obj = Nothing
        End Try
        Return obj

    End Function
    Public Function GetForm(ByVal frmName As String) As Form

        Dim frm As New Form()
        Try
            frm = DirectCast(CreateObjectInstance(frmName), Form)
            Return frm
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
            Return Nothing
        End Try


    End Function

    Public Sub OpenFormBySubId(ByVal sub_ID As Integer)
        Dim rd As OdbcDataReader = fReader($"select * from `tblsub_menu` where sub_id = '{sub_ID}' limit 1")
        Dim i As Integer = 0
        Dim F As Form = Nothing
        Dim Img As Image = Nothing
        Dim bModal As Boolean = False
        If rd.Read Then
            i = fNumisNULL(rd("sub_id"))
            F = fGetForm(rd("Form"))
            Try
                Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
                Img = Image.FromFile(folder & rd("image_file"))
            Catch ex As Exception

            End Try

            gsSubMenuForm = rd("description")


            If F Is Nothing Then
                fMessageboxInfo("Form not found")
            Else
                F.Text = rd("description")
                F.Tag = sub_ID
                bModal = fNumisNULL(rd("modal"))


                If bModal = True Then
                    F.ShowDialog()
                    F.Dispose()
                    F = Nothing
                Else
                    TabFormOpen(F, frmMainMenu.MyTab, Img)
                End If

            End If
        End If
        rd.Close()



    End Sub

End Module
