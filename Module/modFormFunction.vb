Imports System.Data.Odbc
Imports System.Reflection

Module modFormFunction
    Public MainForm As Form
    Public Function fChecked(ByVal prCheckObj As CheckBox) As Integer
        If prCheckObj.Checked = True Then
            Return 1
        Else
            Return 0
        End If
    End Function
    Public Sub fToolSTRIP_ITEM(ByRef i As ToolStripMenuItem, ByVal prDesc As String, ByVal prSub_ID As String, ByVal Form_name As String, ByVal Image_name As String)
        Dim b As New ToolStripMenuItem
        b.Name = prDesc.Replace(" ", "")
        b.Text = prDesc

        If Image_name <> "" Then
            b.Tag = prSub_ID
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            b.Image = Image.FromFile(folder & Image_name)
            b.AccessibleName = Form_name
            b.AccessibleDescription = prSub_ID
            AddHandler b.Click, AddressOf ThisOpenMenuTool
        End If


        i.DropDownItems.Add(b)


    End Sub
    Public Sub fToolSTRIP_ITEM_Sub(ByRef i As ToolStripDropDownButton, ByVal prDesc As String, ByVal prSub_ID As String, ByVal Form_name As String, ByVal Image_name As String)
        Dim b As New ToolStripMenuItem
        b.Name = prDesc.Replace(" ", "")
        b.Text = prDesc

        If Image_name <> "" Then
            b.Tag = prSub_ID
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            b.Image = Image.FromFile(folder & Image_name)
            b.AccessibleName = Form_name
            b.AccessibleDescription = prSub_ID
            AddHandler b.Click, AddressOf ThisOpenMenuTool
        End If


        i.DropDownItems.Add(b)


    End Sub
    Public Function fdgvChange(ByVal org_dgv As DataGridView, ByVal tmp_dgv As DataGridView) As Boolean
        Dim HasChange As Boolean = False
        Try
            For r As Integer = 0 To org_dgv.Rows.Count - 1
                For c As Integer = 0 To org_dgv.Columns.Count - 1
                    If fTextisNULL(org_dgv.Rows(r).Cells(c).Value) <> fTextisNULL(tmp_dgv.Rows(r).Cells(c).Value) Then
                        HasChange = True
                        Exit For
                    End If
                Next

            Next
            If HasChange = False Then
                For r As Integer = 0 To tmp_dgv.Rows.Count - 1
                    For c As Integer = 0 To tmp_dgv.Columns.Count - 1
                        If fTextisNULL(tmp_dgv.Rows(r).Cells(c).Value) <> fTextisNULL(org_dgv.Rows(r).Cells(c).Value) Then
                            HasChange = True
                            Exit For
                        End If
                    Next

                Next
            End If
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
        Return HasChange
    End Function
    Public Function fGetObjectTypeMap_ID(ByVal prTABLE_NAME As String) As Double
        Return fNumFieldValue("OBJECT_TYPE_MAP", "TABLE_NAME", prTABLE_NAME, "ID")
    End Function
    Public Function fGetDocumentTypeMapID_FROM_OBJECT_ID(ByVal object_ID As Integer) As Double

        Return fNumFieldValueOneReturn($"SELECT o.`DOCUMENT_TYPE` FROM object_type_map AS o WHERE o.`ID` = '{object_ID}' AND o.`IS_DOCUMENT` = '1' limit 1;")

    End Function
    Public Function fObjectTypeMap_ID(ByVal prTABLE_NAME As String) As Double
        Dim I As Double = 0
        Dim rd As OdbcDataReader = fReader("SELECT NEXT_ID FROM  object_type_map WHERE TABLE_NAME = '" & prTABLE_NAME & "' LIMIT 1")
        If rd.Read Then
            I = fNumisNULL(rd("NEXT_ID"))
        Else
            fMessageboxExclamation(prTABLE_NAME & " table not found")
            End
        End If
        rd.Close()
        fObjectTypeMap_NEXT_ID_UPDATE(I, prTABLE_NAME)
        Return I
    End Function
    Private Sub fObjectTypeMap_NEXT_ID_UPDATE(ByVal prID_Number As Double, ByVal prTABLE_NAME As String)
        fExecutedOnly("UPDATE object_type_map SET NEXT_ID ='" & (prID_Number + 1) & "' WHERE TABLE_NAME = '" & prTABLE_NAME & "' LIMIT 1")
    End Sub
    Public Sub fObjectTypeMap_NEXT_ID_UPDATE0(ByVal prID_Number As Double, ByVal prNAME As String)
        fExecutedOnly("UPDATE object_type_map SET NEXT_ID ='" & (prID_Number + 1) & "' WHERE `NAME` = '" & prNAME & "' LIMIT 1")
    End Sub
    Public Function fObjectTypeMap(ByVal prTABLE_NAME As String) As Double
        Dim prID_Number As Double = 0

        Try
            'cn.Open()
            Dim rd As OdbcDataReader = fReader("SELECT NEXT_ID FROM WHERE TABLE_NAME = '" & prTABLE_NAME & "' LIMIT 1")
            If rd.Read Then
                prID_Number = fNumisNULL(rd("NEXT_ID"))
            Else
                prID_Number = 1
            End If
            rd.Close()
        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                prID_Number = fObjectTypeMap(prTABLE_NAME)
            Else
                End
            End If
        End Try
        Return prID_Number
    End Function

    Public Function fisDate(ByVal xp As String) As Date
        If IsDate(xp) = True Then
            Return xp
        Else
            Return Date.Now.Date
        End If
    End Function
    'Public Sub fDiscount_ReComputed(ByVal dgv As DataGridView)
    '    Dim T As Double = 0
    '    Dim sGROUP_ITEM_ACTIVE As Boolean = False
    '    Dim sGROUP_ITEM_ID As Integer = 0
    '    For i As Integer = 0 To dgv.Rows.Count - 1
    '        Dim d As DataGridViewRow = dgv.Rows(i)
    '        If d.Visible = True Then
    '            If d.Cells("ITEM_TYPE").Value = 5 Then
    '                If Format(d.Cells("AMOUNT").Value, "FIXED") <> Format(T, "FIXED") Then
    '                    d.Cells("AMOUNT").Value = Format(T, "FIXED")
    '                    If d.Cells("CONTROL_STATUS").Value = "S" Then
    '                        d.Cells("CONTROL_STATUS").Value = "E"
    '                    End If

    '                End If

    '            ElseIf fDISCOUNT_ITEM(d.Cells("ITEM_TYPE").Value) = True Then
    '                Dim L As Double = T * ((fNumisNULL(d.Cells("UNIT_PRICE").Value) * -1) / 100)
    '                T = T - Format(L, "FIXED")
    '                If Format(d.Cells("AMOUNT").Value, "FIXED") <> Format(L, "FIXED") * -1 Then
    '                    d.Cells("AMOUNT").Value = Format(L, "FIXED") * -1
    '                    If d.Cells("CONTROL_STATUS").Value = "S" Then
    '                        d.Cells("CONTROL_STATUS").Value = "E"
    '                    End If

    '                End If
    '            Else
    '                If sGROUP_ITEM_ACTIVE = True Then
    '                    If sGROUP_ITEM_ID = d.Cells("ITEM_ID").Value Then
    '                        sGROUP_ITEM_ACTIVE = False
    '                        T = T + Format(d.Cells("AMOUNT").Value, "FIXED")
    '                    End If
    '                ElseIf fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, sGROUP_ITEM_ACTIVE) = True Then
    '                    sGROUP_ITEM_ID = d.Cells("ITEM_ID").Value
    '                Else
    '                    T = T + Format(d.Cells("AMOUNT").Value, "FIXED")
    '                End If


    '            End If

    '        End If
    '    Next

    'End Sub
    Public Sub fGROUP_ReComputed(ByVal dgv As DataGridView)
        Dim T As Double = 0

        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0
        Dim sGROUP_AMOUNT_COLLECTION As Double = 0
        For i As Integer = 0 To dgv.Rows.Count - 1
            Dim d As DataGridViewRow = dgv.Rows(i)
            If d.Visible = True Then
                If fGROUP_ITEM(d.Cells("ITEM_TYPE").Value, sGROUP_ITEM_ACTIVE) = True Then

                    If sGROUP_ITEM_ID = 0 Then
                        sGROUP_ITEM_ID = d.Cells("ITEM_ID").Value
                        sGROUP_ITEM_COUNT = sGROUP_ITEM_COUNT + 1
                    ElseIf sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID <> d.Cells("ITEM_ID").Value Then
                        sGROUP_ITEM_COUNT = sGROUP_ITEM_COUNT + 1
                        sGROUP_AMOUNT_COLLECTION = sGROUP_AMOUNT_COLLECTION + d.Cells("AMOUNT").Value

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
    Public Sub fgsImagePathArrayClear()
        For i As Integer = 0 To 9999
            gsImagePathArray(i) = ""
        Next
    End Sub

    Public Function fGROUP_ITEM(ByVal prITEM_TYPE As Integer, ByVal prActive As Boolean) As Boolean
        Dim b As Boolean = False
        If prActive = False Then

            If prITEM_TYPE = 6 Then
                b = True
            End If

        Else
            b = prActive
        End If

        Return b

    End Function
    'Public Sub fDiscount_Set()
    '    For i As Integer = 0 To 9999
    '        gsDiscount_Item_ID(i) = ""
    '    Next

    '    Dim v As Integer = -1
    '    Try

    '        Dim rd As OdbcDataReader = fReader("select ID from item where `TYPE` = '7' ")
    '        While rd.Read
    '            v = v + 1
    '            gsDiscount_Item_ID(v) = fNumisNULL(rd("ID"))
    '        End While
    '        rd.Close()
    '    Catch ex As Exception

    '        fMessageboxError(ex)
    '    End Try

    'End Sub
    'Public Sub fOther_Charge_Set()
    '    'OTHER CHARGE & SERVICE CHARGE

    '    For i As Integer = 0 To 9999
    '        gsOther_Charge_Item_ID(i) = ""
    '    Next

    '    Dim v As Integer = -1
    '    Try

    '        Dim rd As OdbcDataReader = fReader("select ID from item where `TYPE` in ('3','4')  ")
    '        While rd.Read
    '            v = v + 1
    '            gsOther_Charge_Item_ID(v) = fNumisNULL(rd("ID"))
    '        End While
    '        rd.Close()
    '    Catch ex As Exception
    '        fMessageboxError(ex)
    '    End Try

    'End Sub

    Public Function fDISCOUNT_ITEM(ByVal prITEM_TYPE As Integer) As Boolean
        Dim b As Boolean = False
        If prITEM_TYPE = 7 Then
            b = True
        End If
        Return b

    End Function
    Public Function fOTHER_CHARGE_ITEM(ByVal prITEM_TYPE As Integer) As Boolean
        Dim b As Boolean = False
        If prITEM_TYPE = 4 Then
            b = True
        End If
        Return b

    End Function
    Public Sub fTSDate(ByVal cmb As ToolStripComboBox, ByVal d As Integer, ByVal bAllowedAll As Boolean)
        Try

            With cmb.ComboBox
                .DisplayMember = "Text"
                .ValueMember = "Value"
                Dim tb As New DataTable
                tb.Columns.Add("Text", GetType(String))
                tb.Columns.Add("Value", GetType(Integer))

                If d = 1 Then

                    If bAllowedAll = True Then
                        tb.Rows.Add("All Year", 0)
                    End If
                    Dim n As Integer = Date.Now.Year + 1
                    For i As Integer = n To 2015 Step -1
                        tb.Rows.Add(i, i)
                    Next
                    .DataSource = tb
                    If bAllowedAll = True Then
                        .SelectedIndex = 0
                    Else
                        .SelectedValue = Date.Now.Year
                    End If
                ElseIf d = 2 Then

                    If bAllowedAll = True Then
                        tb.Rows.Add("All Month", 0)
                    End If
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
                    .DataSource = tb

                    If bAllowedAll = True Then
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
            fMessageboxWarning(ex.Message)
        End Try
    End Sub

    Public Sub fYear(ByVal c As ComboBox)

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
    Public Sub fMonth(ByVal c As ComboBox)
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
    Public Function fComboBoxIndexValue(ByVal cmb As ComboBox) As String
        If cmb.SelectedIndex < 0 Then
            Return "NULL"

        Else
            Return "'" & Val(cmb.SelectedIndex) + 1 & "'"

        End If
    End Function



    Public Sub fBackGroundImageStyle(ByVal frm As Form)
        Exit Sub
        Try
            If gsPOS_Mode = True Then
                gsImageBackground = gsImageBackground
            End If
            fCursorLoadingOn(True)
            frm.Font = New Font("Open Sans", 8)
            frm.Icon = gsIcon
            frm.BackColor = ColorTranslator.FromHtml(gsColor_Code)
            For i As Integer = 0 To frm.Controls.Count - 1
                Select Case frm.Controls(i).Name


                    Case "Panel1"
                        Dim pnl As Panel = frm.Controls(i)
                        pnl.BackgroundImage = gsImageBackground
                        pnl.BackgroundImageLayout = ImageLayout.Stretch
                        pnl.BackColor = ColorTranslator.FromHtml(gsColor_Code)
                        pnl.BorderStyle = BorderStyle.None
                    Case "ToolStrip1"
                        Dim ts As ToolStrip = frm.Controls(i)
                        ts.BackgroundImage = gsImageBackground
                        ts.BackgroundImageLayout = ImageLayout.Stretch
                        ts.BackColor = ColorTranslator.FromHtml(gsColor_Code)
                    Case "StatusStrip1"
                        Dim ss As StatusStrip = frm.Controls(i)
                        ss.BackgroundImage = gsImageBackground
                        ss.BackgroundImageLayout = ImageLayout.Stretch
                        ss.BackColor = ColorTranslator.FromHtml(gsColor_Code)

                    Case "MenuStrip1"
                        Dim ms As MenuStrip = frm.Controls(i)
                        ms.BackgroundImage = gsImageBackground
                        ms.BackgroundImageLayout = ImageLayout.Stretch
                        ms.BackColor = ColorTranslator.FromHtml(gsColor_Code)

                    Case "dgvDocument"
                        Dim dgv As DataGridView = frm.Controls(i)
                        fDatagridViewMode(dgv)
                        dgv.BackgroundColor = ColorTranslator.FromHtml(gsColor_Code)
                    Case "dgvItem"
                        Dim dgv As DataGridView = frm.Controls(i)
                        fDatagridViewMode(dgv)
                    Case "GroupBox5"
                        Dim g As GroupBox = frm.Controls(i)
                        For x As Integer = 0 To g.Controls.Count - 1
                            Select Case fLeft(g.Controls(x).Name, 3)

                                Case "dgv"
                                    Dim dgv As DataGridView = g.Controls(x)
                                    fDatagridViewMode(dgv)
                            End Select
                        Next

                    Case Else
                        If fLeft(frm.Controls(i).Name, 3) = "gpb" Then
                            frm.Controls(i).BackgroundImage = gsImageBackground
                            frm.Controls(i).BackgroundImageLayout = ImageLayout.Stretch
                        End If

                End Select
            Next
            Dim bLabel As Boolean = False
            Dim bPicture As Boolean = False
            For i As Integer = 0 To frm.Controls.Count - 1
                If frm.Controls.Item(i).Name = "Panel1" Then
                    Dim c As Panel = frm.Controls.Item(i)
                    For v As Integer = 0 To c.Controls.Count - 1
                        If c.Controls.Item(v).Name = "PictureBox1" Then
                            c.Height = 50
                            Dim p As PictureBox = c.Controls.Item(v)
                            Dim sFileImage As String = fGetFieldValue("tblsub_menu", "form", frm.Name.Replace("Details", ""), "image_file")
                            If sFileImage <> "" Then
                                p.Image = Image.FromFile(Application.StartupPath & "/image/sub/" & sFileImage)
                            End If
                            p.Height = 45
                            p.Width = 50
                            p.BackColor = Color.Transparent
                            p.Parent = c
                            bPicture = True

                            If bPicture = True And bLabel = True Then
                                Exit For
                            End If

                        ElseIf c.Controls.Item(v).Name = "Label1" Then
                            Dim l As Label = c.Controls.Item(v)
                            l.Font = New Font(gsFont, 14, FontStyle.Bold)
                            l.Height = 50
                            l.TextAlign = ContentAlignment.MiddleCenter
                            l.Top = 10
                            l.Left = 50
                            l.BackColor = Color.Transparent
                            l.Parent = c
                            bLabel = True
                            'l.Text = fGetFieldValue("tblsub_menu", "form", frm.Name.Replace("Details", ""), "description")
                            If bPicture = True And bLabel = True Then
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            ' fMessageboxError(ex)
        Finally
            fCursorLoadingOn(False)
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
    Public Sub fCloseForm(ByVal f As Form)
        f.Close()
        Exit Sub
        Dim sFormName As String = f.Name
        Dim fName As String = fRemoveDigits(sFormName)
        If gscryRpt IsNot Nothing Then
            gscryRpt.Close()
            gscryRpt.Dispose()
            gscryRpt = Nothing
        End If


        Dim frm As New Form
        frm = fGetForm(fName)
        frm.Name = sFormName
        Dim tp As TabPage = New TabPage(sFormName)
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
            i_selected = i_selected - 1
            If i_selected > 0 Then
                gsTabControl.SelectTab(i_selected)
            End If
        End If

        fmenuSet()
    End Sub
    Public Sub fRefreshMenu()
        gsflpPanel.Visible = False
        fRemoveControl()
        Try
            Dim sQuery As String = ""
            Dim bMenuCountRead As Boolean = False
            If gsMenuID <> "" Then
                sQuery = "select sm.sub_id as menu_id,sm.description,form,image_file from tblmenu_list as ml  inner join tblsub_menu as sm on sm.sub_id = ml.sub_id where EXISTS (select * from system_security where `description` = `NAME` and user_id = '" & gsUser_ID & "' ) and  ml.menu_id = '" & gsMenuID & "' order by sm.description"
                bMainMenu = True
            Else
                iMenuCount = 0
                sQuery = "select * from tblmenu where EXISTS (select * from system_security where `description` = `NAME` and user_id = '" & gsUser_ID & "'  ) and first_display ='0' and status = '0' order by position_no"
                bMenuCountRead = True
                bMainMenu = True
            End If

            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                If bMenuCountRead = True Then
                    iMenuCount = iMenuCount + 1
                End If
                Dim file_path As String = ""
                Dim sForm As String = ""
                If gsMenuID <> "" Then
                    sForm = rd("form")
                End If
                If rd("image_file") <> "" Then
                    Dim path As String = AppDomain.CurrentDomain.BaseDirectory
                    If gsMenuID <> "" Then
                        file_path = path & "image\sub\" & rd("image_file")
                    Else
                        file_path = path & "image\menu\" & rd("image_file")

                    End If

                End If


                If bMainMenu = False Then
                    fAddPanel(gsflpPanelMain, rd("menu_id"), rd("description"), file_path, sForm)
                Else
                    If gsMenuID <> "" Then
                        fAddPanel(gsflpPanel, rd("menu_id"), rd("description"), file_path, sForm)
                    End If

                End If
            End While
            rd.Close()



            If gsMenuID <> "" Then
                gsMenuTitle.Text = fGetFieldValue("tblmenu", "menu_id", gsMenuID, "description")
            End If
        Catch ex As Exception

            MessageBox.Show(ex.Message)
        End Try
        gsflpPanel.Visible = True
        bMainMenu = True
        '   fCursorLoadingOn(False)
    End Sub
    Public Sub fRemoveControl()
        gsflpPanel.Controls.Clear()

    End Sub
    Public Sub fmenuSet()
        fCursorLoadingOn(True)
        If gsMenuID = "" Then
            If gsRefresh = True Then
                gsRefresh = False
                fRefreshMenu()
                For i As Integer = 0 To gsTabControl.Controls.Count - 1
                    gsTabControl.Controls.RemoveAt(0)
                Next
            End If
        Else
            If gsRefresh = True Then
                gsRefresh = False
                If gsMenuSubID = "" Then
                    fRefreshMenu()
                Else
                    If gsMenuSubID = "32" Then
                        For i As Integer = 0 To gsTabControl.Controls.Count - 1
                            If gsTabControl.Controls(i).AccessibleName = gsMenuSubID Then
                                If gsTabControl.Controls(i).Text = gsReportTabName Then
                                    gsTabControl.SelectTab(i)
                                    fCursorLoadingOn(False)
                                    Exit Sub
                                End If
                            End If

                        Next
                    ElseIf gsMenuSubID <> "31" Then
                        For i As Integer = 0 To gsTabControl.Controls.Count - 1
                            If gsTabControl.Controls(i).AccessibleName = gsMenuSubID Then
                                gsTabControl.SelectTab(i)
                                If gsDocument_Finder_ID <> "" Then
                                    Dim f As Form = gsTabControl.TabPages(i).Controls.Item(0)
                                    f.Text = gsDocument_Finder_ID
                                End If
                                fCursorLoadingOn(False)
                                Exit Sub
                            End If

                        Next


                    End If
                    '--------------------
                    If gsMenuSubID = "31" Then
                        'ReportView
                    ElseIf gsMenuSubID = "32" Then
                        'ReportSetup
                    Else

                        If fSystem_Security(gsMenuSubID) = False Then
                            Exit Sub
                        End If
                    End If



                    Try

                        fCursorLoadingOn(True)


                        Dim rd As OdbcDataReader = fReader("select * from tblsub_menu where sub_id = '" & gsMenuSubID & "' limit 1")
                        If rd.Read() Then
                            Dim frmName As String = rd("form")
                            Dim iModal As Integer = fNumisNULL(rd("modal"))
                            Dim sDescription As String = rd("description")
                            gsSubMenuForm = sDescription
                            rd.Close()

                            Dim objFRM As New Form()
                            objFRM = fGetForm(frmName)

                            If iModal = 0 Then

                                If gsMenuSubID = 32 Then
                                    objFRM.Name = frmName & gsREPORT_ID
                                End If
                                Dim tp As TabPage = New TabPage
                                If gsMenuSubID = 32 Then
                                    tp.Name = frmName & gsREPORT_ID
                                Else
                                    tp.Name = frmName
                                End If


                                tp.AccessibleName = gsMenuSubID
                                tp.ImageKey = gsMenuSubID

                                If gsMenuSubID = 32 Then
                                    tp.Text = "       " & gsReportTabName & " " & sDescription
                                ElseIf gsMenuSubID = 31 Then
                                    tp.Text = "       " & gsReportTabName & " Preview"
                                Else
                                    tp.Text = "       " & sDescription
                                End If

                                With objFRM
                                    .TopLevel = False
                                    .Dock = DockStyle.Fill
                                    .FormBorderStyle = FormBorderStyle.None
                                    .Visible = True
                                    .AutoScroll = True
                                    .AccessibleName = gsMenuSubID
                                End With
                                tp.Controls.Add(objFRM)
                                gsTabControl.Controls.Add(tp)

                                For i As Integer = 0 To gsTabControl.TabCount - 1
                                    If gsTabControl.TabPages(i).Name = tp.Name Then
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
                        fMessageboxWarning(ex.Message)
                    Finally
                        fCursorLoadingOn(False)
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
        fCursorLoadingOn(False)
    End Sub

    Public Sub fTabName(ByVal fName As String, ByVal prTabName As String)
        Exit Sub
        Dim frm As New Form
        frm = fGetForm(fName)
        Dim tp As TabPage = New TabPage(fName)
        For i As Integer = 0 To gsTabControl.Controls.Count - 1
            If gsTabControl.Controls(i).TabIndex = i Then
                gsTabControl.Controls.Item(i).Text = prTabName
                Exit For
            End If
        Next
        fmenuSet()
    End Sub
    Public Function fGetForm(ByVal frmName As String) As Form
        Dim frm As New Form()
        Try
            frm = DirectCast(CreateObjectInstance(frmName), Form)
            Return frm
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
            Return Nothing
        End Try
    End Function
    Public Sub fAddPanel(ByVal c As Control, ByVal vName As String, ByVal vText As String, ByVal image_path As String, ByVal xForm As String)
        Dim img As Image
        Dim p As Panel = New Panel
        Dim l As Label = New Label

        l.Name = "lbl" & vName
        l.Text = vText
        p.Name = "pnl" & vName
        p.AccessibleName = xForm
        If image_path <> "" Then


            Try
                img = Image.FromFile(image_path)
                If gsMenuID = "" Then
                    p.AccessibleDescription = "x"
                    p.BackgroundImage = img
                    p.BackgroundImageLayout = ImageLayout.Stretch
                Else
                    Dim pic As PictureBox = New PictureBox
                    pic.Name = "pic" & vName
                    pic.Image = img
                    pic.SizeMode = PictureBoxSizeMode.StretchImage
                    pic.Size = New Point(30, 30)
                    pic.Dock = DockStyle.Left
                    pic.BringToFront()
                    p.Controls.Add(pic)
                End If


            Catch ex As Exception
                fMessageboxWarning(ex.Message)
            End Try

            AddHandler p.MouseEnter, AddressOf fPanelEnter
            AddHandler p.MouseLeave, AddressOf fPanelLeave
            AddHandler p.Click, AddressOf fPanelClick
        End If

        If gsMenuID = "" Then
            p.Size = New Point(85, 70)
            l.Font = New Font("Open Sans", 8, FontStyle.Bold)
            l.ForeColor = Color.Black
        Else
            p.Size = New Point(210, 20)
            l.Font = New Font("Open Sans", 10, FontStyle.Regular)
            AddHandler l.MouseEnter, AddressOf fLabelEnter
            AddHandler l.MouseLeave, AddressOf fLabelLeave
            AddHandler l.Click, AddressOf fLabelClick
            l.ForeColor = Color.Black
        End If

        p.BackColor = Color.Transparent
        c.Controls.Add(p)
        l.BackColor = Color.Transparent
        l.AutoSize = True

        p.Controls.Add(l)

        If gsMenuID = "" Then
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

    Public Sub fPanelEnter(ByVal sender As Object, ByVal e As EventArgs)
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

    Public Sub fLabelEnter(ByVal sender As Object, ByVal e As EventArgs)
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
    Public Sub fPanelLeave(ByVal sender As Object, ByVal e As EventArgs)
        Dim p As Panel = DirectCast(sender, Panel)
        If p.AccessibleDescription <> "x" Then
            p.BackgroundImage = Nothing
        End If

        p.BackColor = Color.Transparent
        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Black
    End Sub

    Public Sub fLabelLeave(ByVal sender As Object, ByVal e As EventArgs)
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



    Public Sub fShowingTab(ByVal sender As Object, ByVal e As EventArgs)
        gsShowSubMenu = True
    End Sub
    Public Sub fHidingTab(ByVal sender As Object, ByVal e As EventArgs)
        gsShowSubMenu = False
    End Sub
    Public Sub fBlueLight(ByVal n As Object)
        n.Select(0, n.Value.ToString.Length + 3)
    End Sub

    Public Sub fPanelClick(ByVal sender As Object, ByVal e As EventArgs)

        Dim p As Panel = DirectCast(sender, Panel)
        p.BackColor = Color.Black
        Dim l As Label = CType(p.Controls("lbl" & p.Name.Replace("pnl", "")), Label)
        l.ForeColor = Color.Red

        If gsMenuID <> "" Then
            If p.Name.Replace("pnl", "") = 0 Then

                gsMenuSubID = ""
                gsMenuID = ""

            Else
                If p.AccessibleName = "" Then
                    gsMenuSubID = ""
                    gsMenuID = ""
                    gsMenuID = p.Name.Replace("pnl", "")

                Else
                    gsSubMenuForm = l.Text
                    gsMenuSubID = p.Name.Replace("pnl", "")
                End If


            End If
        Else
            gsMenuID = p.Name.Replace("pnl", "")
        End If
        gsRefresh = True
        fmenuSet()
    End Sub

    Public Sub fLabelClick(ByVal sender As Object, ByVal e As EventArgs)

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

        If gsMenuID <> "" Then
            If p.Name.Replace("pnl", "") = 0 Then
                gsMenuSubID = ""
                gsMenuID = ""
            Else
                If p.AccessibleName = "" Then
                    gsMenuSubID = ""
                    gsMenuID = ""
                    gsMenuID = p.Name

                Else
                    gsMenuSubID = p.Name.Replace("pnl", "")
                End If

            End If
        Else
            gsMenuID = p.Name.Replace("pnl", "")
        End If
        gsRefresh = True
        fmenuSet()
    End Sub

    Public Function fLeft(ByVal x As String, ByVal i As String) As String
        Return Microsoft.VisualBasic.Left(x, i)
    End Function
    Public Function fRight(ByVal x As String, ByVal i As String) As String
        Return Microsoft.VisualBasic.Right(x, i)
    End Function
    Public Sub fDataGrid_Switch(ByVal dgv As DataGridView, ByVal gsID As Integer)
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

            fMS_execute(sQuery)

            frmCheckList.Dispose()
            frmCheckList = Nothing
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
    End Sub
    Public Sub fDataGrid_Column(ByVal dgv As DataGridView, ByVal gsID As Integer)

        dgv.Columns(0).Visible = False

        Dim cn As New OleDb.OleDbConnection(fMS_Con)
        Try
            fCursorLoadingOn(True)
            cn.Open()
            Dim cmd As New OleDb.OleDbCommand("select * from tblcolumn where id = " & gsID & " ", cn)

            Dim rd As OleDb.OleDbDataReader = cmd.ExecuteReader
            If rd.Read Then
                For i As Integer = 1 To dgv.Columns.Count - 1
                    dgv.Columns(i).Visible = rd(i.ToString)
                Next

            Else
                fMS_execute("insert into tblcolumn (ID) values (" & gsID & ") ")
                fMessageboxInfo("New Row Added")
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            fMessageboxWarning(ex.Message)
        Finally
            fCursorLoadingOn(False)
        End Try
    End Sub
    Public Sub fComboBoxNull(ByVal cmb As ComboBox, ByVal prID_NAME As String, ByVal prDESC_NAME As String)
        fComboBox(cmb, "SELECT '' as " & prID_NAME & ", '' as " & prDESC_NAME & " ", prID_NAME, prDESC_NAME)
    End Sub

End Module
