Imports System.Data.Odbc
Imports System.Reflection

Module modFormFunction
    Public MainForm As Form


    Public Function CheckBoxObject(ByVal prCheckObj As CheckBox) As Integer
        If prCheckObj.Checked = True Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Sub ToolStripItemComponent(ByRef i As ToolStripMenuItem, ByVal prDesc As String, ByVal prSub_ID As String, ByVal Form_name As String, ByVal Image_name As String)
        Dim TSMenuItem As New ToolStripMenuItem With {
            .Name = prDesc.Replace(" ", ""),
            .Text = prDesc
        }

        If Image_name <> "" Then
            TSMenuItem.Tag = prSub_ID
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            TSMenuItem.Image = Image.FromFile(folder & Image_name)
            TSMenuItem.AccessibleName = Form_name
            TSMenuItem.AccessibleDescription = prSub_ID
            AddHandler TSMenuItem.Click, AddressOf ThisOpenMenuTool
        End If
        i.DropDownItems.Add(TSMenuItem)
    End Sub
    Public Sub ToolStripDropDownObject(ByRef i As ToolStripDropDownButton, ByVal prDesc As String, ByVal prSub_ID As String, ByVal Form_name As String, ByVal Image_name As String)
        Dim TSDropDownObject As New ToolStripMenuItem With {
            .Name = prDesc.Replace(" ", ""),
            .Text = prDesc
        }
        If Image_name <> "" Then
            TSDropDownObject.Tag = prSub_ID
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            TSDropDownObject.Image = Image.FromFile(folder & Image_name)
            TSDropDownObject.AccessibleName = Form_name
            TSDropDownObject.AccessibleDescription = prSub_ID
            AddHandler TSDropDownObject.Click, AddressOf ThisOpenMenuTool
        End If
        i.DropDownItems.Add(TSDropDownObject)
    End Sub
    Public Function DataGridGotChange(ByVal org_dgv As DataGridView, ByVal tmp_dgv As DataGridView) As Boolean
        Dim HasChange As Boolean = False
        Try
            For r As Integer = 0 To org_dgv.Rows.Count - 1
                For c As Integer = 0 To org_dgv.Columns.Count - 1
                    If GF_TextIsNull(org_dgv.Rows(r).Cells(c).Value) <> GF_TextIsNull(tmp_dgv.Rows(r).Cells(c).Value) Then
                        HasChange = True
                        Exit For
                    End If
                Next

            Next
            If HasChange = False Then
                For r As Integer = 0 To tmp_dgv.Rows.Count - 1
                    For c As Integer = 0 To tmp_dgv.Columns.Count - 1
                        If GF_TextIsNull(tmp_dgv.Rows(r).Cells(c).Value) <> GF_TextIsNull(org_dgv.Rows(r).Cells(c).Value) Then
                            HasChange = True
                            Exit For
                        End If
                    Next

                Next
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return HasChange
    End Function
    Public Function GetObjectTypeMapID(ByVal prTABLE_NAME As String) As Integer
        Return GF_GetNumberFieldValue("OBJECT_TYPE_MAP", "TABLE_NAME", prTABLE_NAME, "ID")
    End Function
    Public Function GetDocumentTypeMapIdFromObjectId(ByVal object_ID As Integer) As Integer
        Return GF_GetNumberFieldValueOneReturn($"SELECT o.`DOCUMENT_TYPE` FROM object_type_map AS o WHERE o.`ID` = '{object_ID}' AND o.`IS_DOCUMENT` = '1' limit 1;")
    End Function
    Public Function ObjectTypeMapId(ByVal prTABLE_NAME As String) As Integer
        Dim I As Integer
        Dim rd As OdbcDataReader = SqlReader("SELECT NEXT_ID FROM  object_type_map WHERE TABLE_NAME = '" & prTABLE_NAME & "' LIMIT 1")
        If rd.Read Then
            I = GF_NumIsNull(rd("NEXT_ID"))
        Else
            MessageBoxExclamation(prTABLE_NAME & " table not found")
            End
        End If
        rd.Close()
        ObjectTypeMapNextIdUpdateByTableName(I, prTABLE_NAME)
        Return I
    End Function
    Private Sub ObjectTypeMapNextIdUpdateByTableName(ByVal prID_Number As Double, ByVal prTABLE_NAME As String)
        SqlExecuted("UPDATE object_type_map SET NEXT_ID ='" & (prID_Number + 1) & "' WHERE TABLE_NAME = '" & prTABLE_NAME & "' LIMIT 1")
    End Sub
    Public Sub ObjectTypeMapNextIdUpdateByName(ByVal prID_Number As Double, ByVal prNAME As String)
        SqlExecuted("UPDATE object_type_map SET NEXT_ID ='" & (prID_Number + 1) & "' WHERE `NAME` = '" & prNAME & "' LIMIT 1")
    End Sub
    Public Function ObjectTypeMap(ByVal prTABLE_NAME As String) As Integer
        Dim NextID As Integer

        Try
            Dim rd As OdbcDataReader = SqlReader("SELECT NEXT_ID FROM WHERE TABLE_NAME = '" & prTABLE_NAME & "' LIMIT 1")
            If rd.Read Then
                NextID = GF_NumIsNull(rd("NEXT_ID"))
            Else
                NextID = 1
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                NextID = ObjectTypeMap(prTABLE_NAME)
            Else
                End
            End If
        End Try
        Return NextID
    End Function

    Public Function FixDate(ByVal xp As String) As Date
        If IsDate(xp) = True Then
            Return xp
        Else
            Return Date.Now.Date
        End If
    End Function
    Public Sub GoupItemComputed(ByVal dgv As DataGridView)
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0
        Dim sGROUP_AMOUNT_COLLECTION As Double = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            Dim d As DataGridViewRow = dgv.Rows(i)
            If d.Visible = True Then
                If IsGroupItem(d.Cells("ITEM_TYPE").Value, sGROUP_ITEM_ACTIVE) = True Then

                    If sGROUP_ITEM_ID = 0 Then
                        sGROUP_ITEM_ID = d.Cells("ITEM_ID").Value
                        sGROUP_ITEM_COUNT += 1
                    ElseIf sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID <> d.Cells("ITEM_ID").Value Then
                        sGROUP_ITEM_COUNT += 1
                        sGROUP_AMOUNT_COLLECTION += d.Cells("AMOUNT").Value

                    ElseIf sGROUP_ITEM_ID = d.Cells("ITEM_ID").Value Then
                        d.Cells("AMOUNT").Value = sGROUP_AMOUNT_COLLECTION
                        sGROUP_ITEM_ID = 0
                        sGROUP_ITEM_COUNT = 0
                        sGROUP_ITEM_ACTIVE = False

                        If d.Cells("CONTROL_STATUS").Value = "S" Then
                            d.Cells("CONTROL_STATUS").Value = "E"
                        End If

                    End If
                End If
            End If
        Next

    End Sub
    Public Sub ImagePathArrayClear()
        For i As Integer = 0 To 9999
            gsImagePathArray(i) = ""
        Next
    End Sub

    Public Function IsGroupItem(ByVal ItemType As Integer, ByVal IsActive As Boolean) As Boolean
        Dim ReturnValue As Boolean = False
        If IsActive = False Then
            If ItemType = 6 Then
                ReturnValue = True
            End If
        Else
            ReturnValue = IsActive
        End If

        Return ReturnValue

    End Function
    Public Function IsDiscountItem(ByVal ItemType As Integer) As Boolean
        Dim ReturnValue As Boolean = False
        If ItemType = 7 Then
            ReturnValue = True
        End If
        Return ReturnValue
    End Function
    Public Function IsOtherChargeItem(ByVal ItemType As Integer) As Boolean
        Dim ReturnValue As Boolean = False
        If ItemType = 4 Then
            ReturnValue = True
        End If
        Return ReturnValue

    End Function
    Public Sub DateTSComboBoxLoad(ByVal cmb As ToolStripComboBox, ByVal Num As Integer, ByVal IsAllowedAll As Boolean)
        Try

            With cmb.ComboBox
                .DisplayMember = "Text"
                .ValueMember = "Value"
                Dim DataTableList As New DataTable
                DataTableList.Columns.Add("Text", GetType(String))
                DataTableList.Columns.Add("Value", GetType(Integer))

                If Num = 1 Then

                    If IsAllowedAll = True Then
                        DataTableList.Rows.Add("All Year", 0)
                    End If
                    Dim n As Integer = Date.Now.Year + 1
                    For i As Integer = n To 2015 Step -1
                        DataTableList.Rows.Add(i, i)
                    Next
                    .DataSource = DataTableList
                    If IsAllowedAll = True Then
                        .SelectedIndex = 0
                    Else
                        .SelectedValue = Date.Now.Year
                    End If
                ElseIf Num = 2 Then

                    If IsAllowedAll = True Then
                        DataTableList.Rows.Add("All Month", 0)
                    End If
                    DataTableList.Rows.Add("January", 1)
                    DataTableList.Rows.Add("February", 2)
                    DataTableList.Rows.Add("March", 3)
                    DataTableList.Rows.Add("April", 4)
                    DataTableList.Rows.Add("May", 5)
                    DataTableList.Rows.Add("June", 6)
                    DataTableList.Rows.Add("July", 7)
                    DataTableList.Rows.Add("Auguest", 8)
                    DataTableList.Rows.Add("September", 9)
                    DataTableList.Rows.Add("October", 10)
                    DataTableList.Rows.Add("November", 11)
                    DataTableList.Rows.Add("December", 12)
                    .DataSource = DataTableList

                    If IsAllowedAll = True Then
                        .SelectedIndex = 0
                    Else
                        .SelectedValue = Date.Now.Month
                    End If

                End If


                If .DropDownStyle = ComboBoxStyle.DropDown Then
                    .AutoCompleteMode = AutoCompleteMode.Suggest
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                    .SelectedIndex = -1
                    .DropDownHeight = 100

                End If

            End With

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Public Sub YearlyComboBoxLoad(ByVal c As ComboBox)

        c.DisplayMember = "Text"
        c.ValueMember = "Value"
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Integer))

        Dim n As Integer = Date.Now.Year + 1
        For i As Integer = n To 2015 Step -1
            tb.Rows.Add(i, i)
        Next

        c.DataSource = tb

        c.SelectedValue = Date.Now.Year
    End Sub
    Public Sub MonthlyComboBoxLoad(ByVal c As ComboBox)
        c.DisplayMember = "Text"
        c.ValueMember = "Value"
        Dim tb As New DataTable
        tb.Columns.Add("Text", GetType(String))
        tb.Columns.Add("Value", GetType(Integer))
        tb.Rows.Add("January", 1)
        tb.Rows.Add("February", 2)
        tb.Rows.Add("March", 3)
        tb.Rows.Add("April", 4)
        tb.Rows.Add("May", 5)
        tb.Rows.Add("June", 6)
        tb.Rows.Add("July", 7)
        tb.Rows.Add("Auguest", 8)
        tb.Rows.Add("September", 9)
        tb.Rows.Add("October", 10)
        tb.Rows.Add("November", 11)
        tb.Rows.Add("December", 12)
        c.DataSource = tb
        c.SelectedValue = Date.Now.Month
    End Sub
    Public Function ComboBoxSelected(ByVal cmb As ComboBox) As String
        If cmb.SelectedIndex < 0 Then
            Return "NULL"

        Else
            Return "'" & Val(cmb.SelectedIndex) + 1 & "'"

        End If
    End Function
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
    Public Sub ClosedForm(ByVal f As Form)
        f.Close()
        Exit Sub
        Dim sFormName As String = f.Name
        Dim fName As String = GF_RemoveDigits(sFormName)
        If gscryRpt IsNot Nothing Then
            gscryRpt.Close()
            gscryRpt.Dispose()
            gscryRpt = Nothing
        End If


        Dim frm As New Form
        frm = GetFormModule(fName)
        frm.Name = sFormName
        Dim TPage As New TabPage(sFormName)
        Dim i_selected As Integer = 0
        Dim x_select As Integer = gsTabControl.SelectedIndex
        For i As Integer = 0 To gsTabControl.Controls.Count - 1
            If gsTabControl.Controls.Item(i).Name = sFormName And i = x_select Then
                frm.Close()
                frm.Dispose()
                i_selected = i
                gsTabControl.Controls.RemoveAt(i)
                If gsTabControl.Controls.Count = 0 Then
                    gsTabControl.Visible = False
                End If
                Exit For
            End If
        Next

        If gsTabControl.Controls.Count <> 0 Then
            i_selected -= 1
            If i_selected > 0 Then
                gsTabControl.SelectTab(i_selected)
            End If
        End If

        MenuSet()
    End Sub
    Public Sub RefreshMenuModule()
        gsflpPanel.Visible = False
        RemoveControl()
        Try
            Dim sQuery As String = ""
            Dim bMenuCountRead As Boolean = False
            If gsMenuID > 0 Then
                sQuery = "select sm.sub_id as menu_id,sm.description,form,image_file from tblmenu_list as ml  inner join tblsub_menu as sm on sm.sub_id = ml.sub_id where EXISTS (select * from system_security where `description` = `NAME` and user_id = '" & gsUser_ID & "' ) and  ml.menu_id = '" & gsMenuID & "' order by sm.description"
                bMainMenu = True
            Else
                iMenuCount = 0
                sQuery = "select * from tblmenu where EXISTS (select * from system_security where `description` = `NAME` and user_id = '" & gsUser_ID & "'  ) and first_display ='0' and status = '0' order by position_no"
                bMenuCountRead = True
                bMainMenu = True
            End If

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                If bMenuCountRead = True Then
                    iMenuCount += 1
                End If
                Dim file_path As String = ""
                Dim sForm As String = ""
                If gsMenuID > 0 Then
                    sForm = rd("form")
                End If
                If rd("image_file") <> "" Then
                    Dim path As String = AppDomain.CurrentDomain.BaseDirectory
                    If gsMenuID > 0 Then
                        file_path = path & "image\sub\" & rd("image_file")
                    Else
                        file_path = path & "image\menu\" & rd("image_file")

                    End If

                End If


                If bMainMenu = False Then
                    AddingPanel(gsflpPanelMain, rd("menu_id"), rd("description"), file_path, sForm)
                Else
                    If gsMenuID > 0 Then
                        AddingPanel(gsflpPanel, rd("menu_id"), rd("description"), file_path, sForm)
                    End If

                End If
            End While
            rd.Close()



            If gsMenuID > 0 Then
                gsMenuTitle.Text = GF_GetStringFieldValue("tblmenu", "menu_id", gsMenuID, "description")
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
        gsflpPanel.Visible = True
        bMainMenu = True
        '   GS_CursorLoadingOn(False)
    End Sub
    Public Sub RemoveControl()
        gsflpPanel.Controls.Clear()

    End Sub
    Public Sub MenuSet()
        GS_CursorLoadingOn(True)
        If gsMenuID <= 0 Then
            If gsRefresh = True Then
                gsRefresh = False
                RefreshMenuModule()
                For i As Integer = 0 To gsTabControl.Controls.Count - 1
                    gsTabControl.Controls.RemoveAt(0)
                Next
            End If
        Else
            If gsRefresh = True Then
                gsRefresh = False
                If gsMenuSubID <= 0 Then
                    RefreshMenuModule()
                Else
                    If gsMenuSubID = 32 Then
                        For i As Integer = 0 To gsTabControl.Controls.Count - 1
                            If gsTabControl.Controls(i).AccessibleName = gsMenuSubID Then
                                If gsTabControl.Controls(i).Text = gsReportTabName Then
                                    gsTabControl.SelectTab(i)
                                    GS_CursorLoadingOn(False)
                                    Exit Sub
                                End If
                            End If

                        Next
                    ElseIf gsMenuSubID <> 31 Then
                        For i As Integer = 0 To gsTabControl.Controls.Count - 1
                            If gsTabControl.Controls(i).AccessibleName = gsMenuSubID Then
                                gsTabControl.SelectTab(i)
                                If gsDocument_Finder_ID > 0 Then
                                    Dim f As Form = gsTabControl.TabPages(i).Controls.Item(0)
                                    f.Text = gsDocument_Finder_ID
                                End If
                                GS_CursorLoadingOn(False)
                                Exit Sub
                            End If

                        Next


                    End If
                    '--------------------
                    If gsMenuSubID = 31 Then
                        'ReportView
                    ElseIf gsMenuSubID = 32 Then
                        'ReportSetup
                    Else

                        If SecuritySystemModule(gsMenuSubID) = False Then
                            Exit Sub
                        End If
                    End If



                    Try

                        GS_CursorLoadingOn(True)


                        Dim rd As OdbcDataReader = SqlReader("select * from tblsub_menu where sub_id = '" & gsMenuSubID & "' limit 1")
                        If rd.Read() Then
                            Dim frmName As String = rd("form")
                            Dim iModal As Integer = GF_NumIsNull(rd("modal"))
                            Dim sDescription As String = rd("description")
                            gsSubMenuForm = sDescription
                            rd.Close()

                            Dim objFRM As New Form()
                            objFRM = GetFormModule(frmName)

                            If iModal = 0 Then

                                If gsMenuSubID = 32 Then
                                    objFRM.Name = frmName & gsREPORT_ID
                                End If
                                Dim TPage As New TabPage
                                If gsMenuSubID = 32 Then
                                    TPage.Name = frmName & gsREPORT_ID
                                Else
                                    TPage.Name = frmName
                                End If


                                TPage.AccessibleName = gsMenuSubID
                                TPage.ImageKey = gsMenuSubID

                                If gsMenuSubID = 32 Then
                                    TPage.Text = "       " & gsReportTabName & " " & sDescription
                                ElseIf gsMenuSubID = 31 Then
                                    TPage.Text = "       " & gsReportTabName & " Preview"
                                Else
                                    TPage.Text = "       " & sDescription
                                End If

                                With objFRM
                                    .TopLevel = False
                                    .Dock = DockStyle.Fill
                                    .FormBorderStyle = FormBorderStyle.None
                                    .Visible = True
                                    .AutoScroll = True
                                    .AccessibleName = gsMenuSubID
                                End With
                                TPage.Controls.Add(objFRM)
                                gsTabControl.Controls.Add(TPage)

                                For i As Integer = 0 To gsTabControl.TabCount - 1
                                    If gsTabControl.TabPages(i).Name = TPage.Name Then
                                        gsTabControl.SelectTab(i)
                                    End If
                                Next

                            Else
                                'On Top Only
                                objFRM.ShowDialog()
                                objFRM.Dispose()
                                objFRM = Nothing
                            End If
                        Else
                            rd.Close()
                        End If

                    Catch ex As Exception
                        MessageBoxWarning(ex.Message)
                    Finally
                        GS_CursorLoadingOn(False)
                    End Try




                End If
            End If
        End If

        If gsTabControl.TabCount <> 0 Then
            gsTabControl.Visible = True
            '  gsSystem_Name.Visible = False

        Else
            ' gsSystem_Name.Visible = True

        End If
        GS_CursorLoadingOn(False)
    End Sub


    Public Function GetFormModule(ByVal frmName As String) As Form

        Try
            Dim frm As Form = DirectCast(CreateObjectInstance(frmName), Form)
            Return frm
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub AddingPanel(ByVal c As Control, ByVal vName As String, ByVal vText As String, ByVal image_path As String, ByVal xForm As String)
        Dim img As Image
        Dim p As New Panel With {
            .Name = "pnl" & vName,
            .AccessibleName = xForm
        }

        Dim l As New Label With {
            .Name = "lbl" & vName,
            .Text = vText
        }

        If image_path <> "" Then


            Try
                img = Image.FromFile(image_path)
                If gsMenuID <= 0 Then
                    p.AccessibleDescription = "x"
                    p.BackgroundImage = img
                    p.BackgroundImageLayout = ImageLayout.Stretch
                Else
                    Dim pic As New PictureBox With {
                        .Name = "pic" & vName,
                        .Image = img,
                        .SizeMode = PictureBoxSizeMode.StretchImage,
                        .Size = New Point(30, 30),
                        .Dock = DockStyle.Left
                    }
                    pic.BringToFront()
                    p.Controls.Add(pic)
                End If


            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try

            AddHandler p.MouseEnter, AddressOf PanelEntered
            AddHandler p.MouseLeave, AddressOf PanelLeaved
            AddHandler p.Click, AddressOf PanelClick
        End If

        If gsMenuID <= 0 Then
            p.Size = New Point(85, 70)
            l.Font = New Font("Open Sans", 8, FontStyle.Bold)
            l.ForeColor = Color.Black
        Else
            p.Size = New Point(210, 20)
            l.Font = New Font("Open Sans", 10, FontStyle.Regular)
            AddHandler l.MouseEnter, AddressOf LabelEntered
            AddHandler l.MouseLeave, AddressOf LabelLeaved
            AddHandler l.Click, AddressOf LabelClick
            l.ForeColor = Color.Black
        End If

        p.BackColor = Color.Transparent
        c.Controls.Add(p)
        l.BackColor = Color.Transparent
        l.AutoSize = True

        p.Controls.Add(l)

        If gsMenuID <= 0 Then
            p.BorderStyle = BorderStyle.None
            l.TextAlign = ContentAlignment.MiddleLeft
            l.Dock = DockStyle.Top
        Else
            p.BorderStyle = BorderStyle.None
            l.TextAlign = ContentAlignment.BottomRight
            l.BringToFront()
            l.Dock = DockStyle.Left
        End If

    End Sub

    Public Sub PanelEntered(ByVal sender As Object, ByVal e As EventArgs)
        Dim img As Image = gsImageBackground
        Dim p As Panel = DirectCast(sender, Panel)
        p.BackColor = Color.White
        If p.AccessibleDescription <> "x" Then
            p.BackgroundImage = img
            p.BackgroundImageLayout = ImageLayout.Stretch
        End If

        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Blue
    End Sub

    Public Sub LabelEntered(ByVal sender As Object, ByVal e As EventArgs)
        Dim c As Label = DirectCast(sender, Label)
        Dim f As Panel = gsflpPanel
        Dim p As New Panel
        For i As Integer = 0 To f.Controls.Count - 1
            If f.Controls(i).Name.Replace("pnl", "") = c.Name.Replace("lbl", "") Then
                p = f.Controls(i)
                Exit For
            End If

        Next

        Dim img As Image = gsImageBackground
        p.BackColor = Color.White
        If p.AccessibleDescription <> "x" Then
            p.BackgroundImage = img
            p.BackgroundImageLayout = ImageLayout.Stretch
        End If

        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Black
    End Sub
    Public Sub PanelLeaved(ByVal sender As Object, ByVal e As EventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        If p.AccessibleDescription <> "x" Then
            p.BackgroundImage = Nothing
        End If

        p.BackColor = Color.Transparent
        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Black
    End Sub

    Public Sub LabelLeaved(ByVal sender As Object, ByVal e As EventArgs)
        Dim c As Label = DirectCast(sender, Label)
        Dim f As Panel = gsflpPanel
        Dim p As New Panel
        For i As Integer = 0 To f.Controls.Count - 1
            If f.Controls(i).Name.Replace("pnl", "") = c.Name.Replace("lbl", "") Then
                p = f.Controls(i)
                Exit For
            End If

        Next

        If p.AccessibleDescription <> "x" Then
            p.BackgroundImage = Nothing
        End If

        p.BackColor = Color.Transparent
        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Black
    End Sub



    Public Sub ShowingTab(ByVal sender As Object, ByVal e As EventArgs)
        gsShowSubMenu = True
    End Sub
    Public Sub HidingTab(ByVal sender As Object, ByVal e As EventArgs)
        gsShowSubMenu = False
    End Sub
    Public Sub BlueLight(ByVal n As Object)
        n.Select(0, n.Value.ToString.Length + 3)
    End Sub

    Public Sub PanelClick(ByVal sender As Object, ByVal e As EventArgs)

        Dim p As Panel = DirectCast(sender, Panel)
        p.BackColor = Color.Black
        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Red

        If gsMenuID > 0 Then
            If p.Name.Replace("pnl", "") = 0 Then

                gsMenuSubID = 0
                gsMenuID = 0

            Else
                If p.AccessibleName = "" Then
                    gsMenuSubID = 0
                    gsMenuID = 9
                    gsMenuID = GF_NumIsNull(p.Name.Replace("pnl", ""))

                Else
                    gsSubMenuForm = l.Text
                    gsMenuSubID = GF_NumIsNull(p.Name.Replace("pnl", ""))
                End If


            End If
        Else
            gsMenuID = GF_NumIsNull(p.Name.Replace("pnl", ""))
        End If
        gsRefresh = True
        MenuSet()
    End Sub

    Public Sub LabelClick(ByVal sender As Object, ByVal e As EventArgs)

        Dim l As Label = DirectCast(sender, Label)



        Dim f As Panel = gsflpPanel
        Dim p As New Panel
        For i As Integer = 0 To f.Controls.Count - 1
            If f.Controls(i).Name.Replace("pnl", "") = l.Name.Replace("lbl", "") Then
                p = f.Controls(i)
                Exit For
            End If
        Next
        p.BackColor = Color.Black
        '  Dim p As Panel = CType(l.Controls("pnl" & l.Name.Replace("lbl", "")), Panel)
        l.ForeColor = Color.Red

        If gsMenuID > 0 Then
            If p.Name.Replace("pnl", "") = 0 Then
                gsMenuSubID = 0
                gsMenuID = 0
            Else
                If p.AccessibleName = "" Then
                    gsMenuSubID = 0
                    gsMenuID = 0
                    gsMenuID = p.Name

                Else
                    gsMenuSubID = p.Name.Replace("pnl", "")
                End If

            End If
        Else
            gsMenuID = p.Name.Replace("pnl", "")
        End If
        gsRefresh = True
        MenuSet()
    End Sub

    Public Function StrLeft(ByVal x As String, ByVal i As String) As String
        Return Microsoft.VisualBasic.Left(x, i)
    End Function
    Public Function StrRight(ByVal x As String, ByVal i As String) As String
        Return Microsoft.VisualBasic.Right(x, i)
    End Function
    Public Sub ViewSwitch(ByVal dgv As DataGridView, ByVal gsID As Integer)
        Try
            For i As Integer = 0 To dgv.Columns.Count - 1
                If i = 0 Then

                Else
                    frmCheckList.CheckedListBox1.Items.Add(dgv.Columns(i).HeaderText, dgv.Columns(i).Visible)
                End If
            Next



            frmCheckList.ShowDialog()
            Dim sQuery As String = ""
            Dim c As CheckedListBox = frmCheckList.CheckedListBox1
            For i As Integer = 0 To c.Items.Count - 1

                If sQuery = "" Then
                    sQuery = "update tblcolumn set [" & i + 1 & "] = " & c.GetItemChecked(i) & ""
                Else

                    sQuery = sQuery & ",[" & i + 1 & "] = " & c.GetItemChecked(i) & ""
                End If

            Next
            sQuery = sQuery & " where [ID] = " & gsID

            DbAccessExecute(sQuery)

            frmCheckList.Dispose()
            frmCheckList = Nothing
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Public Sub ViewColumn(ByVal dgv As DataGridView, ByVal gsID As Integer)

        dgv.Columns(0).Visible = False

        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
        Try
            GS_CursorLoadingOn(True)
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand("select * from tblcolumn where id = " & gsID & " ", cn)

            Dim rd As OleDb.OleDbDataReader = cmd.ExecuteReader
            If rd.Read Then
                For i As Integer = 1 To dgv.Columns.Count - 1
                    dgv.Columns(i).Visible = rd(i.ToString)
                Next

            Else
                DbAccessExecute("insert into tblcolumn (ID) values (" & gsID & ") ")
                MessageBoxInfo("New Row Added")
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            MessageBoxWarning(ex.Message)
        Finally
            GS_CursorLoadingOn(False)
        End Try
    End Sub
    Public Sub ComboBoxNull(ByVal cmb As ComboBox, ByVal prID_NAME As String, ByVal prDESC_NAME As String)
        GS_ComboBoxLoad(cmb, "SELECT '' as " & prID_NAME & ", '' as " & prDESC_NAME & " ", prID_NAME, prDESC_NAME)
    End Sub

End Module
