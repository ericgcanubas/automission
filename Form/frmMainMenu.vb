Imports System.Data.Odbc
Public Class frmMainMenu
    Dim ApplicationClick As Boolean = False
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Dim NewPartIndex As Integer
    Private Sub fApplication()
        Dim thisSearch As String = txtSearchMenu.Text.Replace("'", "")
        Dim i As Integer = 0
        Dim rd As OdbcDataReader = fReader($"select * from tblmenu as m where EXISTS (select * from system_security where `description` = `NAME` and user_id = '" & gsUser_ID & "' ) and first_display ='0' and menu_id in ('1','2','3','4') and visible ='1' order by position_no")

        Dim myIndex As Integer = 0
        While rd.Read
            If fNumisNULL(rd("visible")) = 1 Then


                myIndex = gsImgList.Images.IndexOfKey(rd("DESCRIPTION"))
                trvApplication.Nodes.Add(rd("MENU_ID"), rd("DESCRIPTION"), myIndex).Tag = 0
                trvApplication.Nodes.Item(i).NodeFont = New Font(trvApplication.Font, FontStyle.Bold)
                NewPartIndex = NewPartIndex + 1
                Dim rd_sub As OdbcDataReader = fReader("select ml.sub_id,sm.description,sm.access_control from  tblmenu_list as ml inner join tblsub_menu as sm on sm.sub_id = ml.sub_id  where  ml.menu_id = '" & rd("menu_id") & "' and sm.description like '%" & thisSearch & "%' and sm.active <> '0' order by sm.description")
                While rd_sub.Read
                    Dim T As Integer = fNumisNULL(rd_sub("access_control"))
                    myIndex = gsImgList.Images.IndexOfKey(rd_sub("sub_id"))

                    trvApplication.Nodes(i).Nodes.Add(rd_sub("sub_id"), rd_sub("description"), myIndex).ForeColor = Color.DarkBlue 'Tag = rd("MENU_ID")
                End While
                rd_sub.Close()

                i = i + 1
            End If
        End While

        rd.Close()

    End Sub
    Private Sub fReport()
        Dim thisSearch As String = txtSearchMenu.Text.Replace("'", "")
        Dim myIndex As Integer = 0
        Dim sType As String = ""
        Dim int3 As Integer = 0
        Dim i As Integer = NewPartIndex - 1
        myIndex = gsImgList.Images.IndexOfKey("Reports")
        trvApplication.Nodes.Add(NewPartIndex.ToString, "Reports", myIndex).Tag = 0
        trvApplication.Nodes.Item(i).NodeFont = New Font(trvApplication.Font, FontStyle.Bold)

        Dim rd As OdbcDataReader = fReader("select r.Description as `Report_Group` , s.SUB_ID as `ID` ,s.Description as `Title`,s.FORM as `File`,s.IMAGE_File as `ref_desc` from tblsub_menu  as s inner join report_group as r on r.id = s.group_line  inner join system_security ss ON ss.NAME = s.DESCRIPTION where ss.USER_ID = '" & gsUser_ID & "' and s.DESCRIPTION  like '%" & thisSearch & "%' and s.active <> '0' order by r.ID,s.Description ")


        While rd.Read

            If sType <> fTextisNULL(rd("Report_Group")) Then
                int3 = int3 + 1
                myIndex = gsImgList.Images.IndexOfKey("print")
                trvApplication.Nodes(i).Nodes.Add(rd("ref_desc") & $"-{int3}", rd("Report_Group"), myIndex).Tag = 0
            End If
            Dim N As Integer = trvApplication.Nodes(i).Nodes.Count - 1
            myIndex = gsImgList.Images.IndexOfKey("report")
            trvApplication.Nodes(i).Nodes(N).Nodes.Add(rd("ID"), rd("Title"), myIndex).ForeColor = Color.DarkBlue 'Tag =' NewPartIndex

            sType = fTextisNULL(rd("Report_Group"))
        End While

        rd.Close()



    End Sub
    Private Sub fLoadUtilities()
        'Utility
        Dim thisSearch As String = txtSearchMenu.Text.Replace("'", "")
        Dim myIndex As Integer = 0
        Dim sType As String = ""
        Dim int3 As Integer = 0
        Dim i As Integer = NewPartIndex - 1
        myIndex = gsImgList.Images.IndexOfKey("Utility")
        trvApplication.Nodes.Add(NewPartIndex.ToString, "Other List", myIndex).Tag = 0
        trvApplication.Nodes.Item(i).NodeFont = New Font(trvApplication.Font, FontStyle.Bold)

        Dim rd As OdbcDataReader = fReader("select sg.description as `Report_Group`,s.sub_id ,s.Description as `sub_desc`,s.`Form`,s.image_file from tblsub_group as sg inner join tblsub_group_details as sgd on sg.group_id = sgd.group_id inner join tblsub_menu as s on s.sub_id = sgd.sub_id where  sg.group_id > '0' and s.DESCRIPTION  like '%" & thisSearch & "%' and s.active <>'0' order by sg.description , s.description ")
        While rd.Read

            If sType <> fTextisNULL(rd("Report_Group")) Then
                myIndex = gsImgList.Images.IndexOfKey("doc-group")
                int3 = int3 + 1
                trvApplication.Nodes(i).Nodes.Add(rd("Report_Group") & $"-{int3}", rd("Report_Group"), myIndex).Tag = 0
            End If

            Dim N As Integer = trvApplication.Nodes(i).Nodes.Count - 1
            myIndex = gsImgList.Images.IndexOfKey(rd("sub_id"))
            trvApplication.Nodes(i).Nodes(N).Nodes.Add(rd("sub_id"), rd("sub_desc"), myIndex).ForeColor = Color.DarkBlue 'Tag = NewPartIndex





            sType = fTextisNULL(rd("Report_Group"))
        End While

        rd.Close()

        '    Dim t As New ToolStripDropDownButton
        '    Try

        '        Dim rd As OdbcDataReader = fReader("select sg.description as `GROUP_NAME`,s.sub_id ,s.Description as `sub_desc`,s.`Form`,s.image_file from tblsub_group as sg inner join tblsub_group_details as sgd on sg.group_id = sgd.group_id inner join tblsub_menu as s on s.sub_id = sgd.sub_id where  sg.group_id > '0' order by sg.description , s.description ")
        '
        '       While rd.Read
        '            Dim n_desc As String = rd("GROUP_NAME")
        '            If temp_group_desc <> n_desc Then
        '                If temp_group_desc <> "" Then
        '                    TSSubMenu.Items.Add(t)
        '                End If
        '                t = New ToolStripDropDownButton
        '                t.Name = n_desc.Replace(" ", "")
        '                t.Text = n_desc
        '                Dim img As String = "Documents-icon.png"
        '                Dim filename As String = System.IO.Path.Combine($"{New Uri(CurrentPath).LocalPath}\image\sub", img)
        '                t.ImageAlign = ContentAlignment.MiddleLeft
        '                t.Image = Image.FromFile(filename)
        '                fToolSTRIP_ITEM_Sub(t, rd("sub_desc"), rd("sub_id"), rd("Form"), rd("Image_file"))

        '            Else
        '                fToolSTRIP_ITEM_Sub(t, rd("sub_desc"), rd("sub_id"), rd("form"), rd("image_file"))
        '            End If
        '            temp_group_desc = n_desc
        '        End While


        '        rd.Close()
        '    Catch ex As Exception
        '        If fMessageBoxErrorYesNo(ex.Message) = True Then

        '        Else
        '            End
        '        End If
        '    End Try
    End Sub
    Private Sub fLoadApplication()
        trvApplication.Nodes.Clear()

        NewPartIndex = 1
        Try
            trvApplication.BeginUpdate()
            fApplication()
            fReport()
            NewPartIndex = NewPartIndex + 1
            fLoadUtilities()
            trvApplication.EndUpdate()

            If txtSearchMenu.Text.Length > 2 Then
                trvApplication.ExpandAll()
            End If
        Catch ex As Exception

            If fMessageBoxErrorYesNo(ex.Message) = True Then
                '
            Else
                End
            End If
        End Try
    End Sub
    Private Sub fAddMenuToolSeparator(ByVal icount As Integer)
        With TSQuickAcces
            Dim b As New ToolStripSeparator
            b.Name = "separator" & icount
            b.Text = "separator" & icount
            .Items.Add(b)
        End With
    End Sub
    Private Sub QuickAccess()
        Try


            Dim rd As OdbcDataReader = fReader($"select s.sub_id,s.description,s.image_file,s.Form from tblsub_group_details as sgd  inner join tblsub_menu as s on s.sub_id =  sgd.sub_id  where sgd.group_id = '0' and s.active <> '0' order by sgd.ID ")
            Dim separator_count As Integer = 0
            While rd.Read

                If fNumisNULL(rd("sub_id")) = 0 Then

                    separator_count = separator_count + 1
                    'fAddMenuToolSeparator(separator_count)
                Else




                    Dim TB As New ToolStripButton

                    TB.Name = rd("description").ToString.Replace(" ", "")
                    TB.Text = rd("description")
                    TB.AccessibleName = rd("Form")
                    TB.ForeColor = Color.Black
                    TB.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
                    TB.TextImageRelation = TextImageRelation.ImageAboveText
                    TB.ImageAlign = ContentAlignment.MiddleCenter
                    Dim img As String = rd("image_file")
                    Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub"
                    Dim filename As String = System.IO.Path.Combine(folder, img)

                    TB.Image = Image.FromFile(filename)
                    TB.Tag = rd("sub_id")

                    TSQuickAcces.Items.Add(TB)
                    AddHandler TB.Click, AddressOf ThisOpenMenu
                End If
            End While


            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                QuickAccess()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub fLoadReport()
        Dim sType As String = ""

        Dim s As New ToolStripSeparator
        Dim int3 As Integer = 0

        Try

            Dim t As New ToolStripMenuItem

            ' cn.Open()
            Dim rd As OdbcDataReader = fReader("select r.Description as `Report_Group` , s.SUB_ID as `ID` ,s.Description as `Title`,s.FORM as `File`,s.IMAGE_File as `ref_desc` from tblsub_menu  as s inner join report_group as r on r.id = s.group_line  inner join system_security ss ON ss.NAME = s.DESCRIPTION where ss.USER_ID = '" & gsUser_ID & "' and s.active <> '0'  order by r.ID,s.Description ")
            While rd.Read

                If sType <> fTextisNULL(rd("Report_Group")) Then

                    int3 = 1
                    'ReportsToolStripMenuItem
                    Dim n As New ToolStripMenuItem
                    n.Name = rd("ID")
                    n.Text = rd("Title")
                    n.AccessibleDescription = rd("ref_desc") 'Reference 'Type
                    n.AccessibleName = rd("File") 'File
                    AddHandler n.Click, AddressOf fWhenClickReport
                    t = New ToolStripMenuItem
                    t.Name = fTextisNULL(rd("Report_Group")).Replace(" ", "")
                    t.Text = fTextisNULL(rd("Report_Group"))
                    t.DropDownItems.Add(n)

                    ReportsToolStripMenuItem.DropDownItems.Add(t)

                    sType = fTextisNULL(rd("Report_Group"))
                Else
                    int3 = int3 + 1
                    If int3 = 3 Then
                        s = New ToolStripSeparator
                        s.Name = "Line_" & rd("ID")
                        t.DropDownItems.Add(s)
                        int3 = 1
                    End If
                    Dim n As New ToolStripMenuItem
                    n.Name = rd("ID")
                    n.Text = rd("Title") 'Description
                    n.AccessibleDescription = rd("ref_desc") 'Reference
                    n.AccessibleName = rd("File") 'FIle
                    AddHandler n.Click, AddressOf fWhenClickReport
                    t.DropDownItems.Add(n)

                End If
                'ReportsToolStripMenuItem
            End While
            ReportsToolStripMenuItem.DropDownItems.Add(t)
            rd.Close()
        Catch ex As Exception
            fMessageboxInfo(ex.Message)

        Finally

        End Try
    End Sub

    Private Sub fWhenClickReport(ByVal sender As Object, ByVal e As EventArgs)
        'gsReportType = "sales"
        'fShowReportSetup("crySalesByCustomerDetails.rpt", "Sales by Customer Details")
        Dim t As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        gsReportType = t.AccessibleDescription
        gsReportTabName = t.Text
        gsREPORT_ID = t.Name
        gsMenuSubID = "32"
        gsReportTabName = t.Text
        gsReportFileName = t.AccessibleName

        Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
        Dim img As Image = Image.FromFile(folder & "report_setup.png")
        Dim R As New frmReportSetup



        TabFormOpen(R, Me.MyTab, img)
        gsMenuSubID = ""
    End Sub
    Private Sub OpenReport(ByVal ID As Integer, ByVal Title As String)


        gsReportType = ID
        gsReportTabName = Title
        gsREPORT_ID = ID
        gsMenuSubID = "32"
        gsReportTabName = Title
        gsReportFileName = fGetFieldValue("tblsub_menu", "SUB_ID", ID, "Form")

        Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
        Dim img As Image = Image.FromFile(folder & "report_setup.png")
        Dim R As New frmReportSetup
        R.Text = Title


        TabFormOpen(R, Me.MyTab, img)
        gsMenuSubID = ""
    End Sub
    Private Sub fShowReportSetup(ByVal prReportFileName As String, ByVal prTabname As String)

        gsReportTabName = prTabname
        gsReportFileName = prReportFileName
        gsRefresh = True
        ' fmenuSet()


    End Sub

    Private Sub FrmMainMenu_Load(sender As Object, e As EventArgs) Handles Me.Load ' Loading Form


        If gsUser_Name.ToLower <> "itme" Then
            MenuToolStripMenuItem.Visible = False
            ToolStripMenuItem1.Visible = False
            ThemeToolStripMenuItem.Visible = False

            ResetToolStripMenuItem.Visible = False
            SubMenuGroupToolStripMenuItem.Visible = False
            PowerToolsToolStripMenuItem.Visible = False
        End If



        Me.trvApplication.ImageList = gsImgList
        fLoadApplication()

        gsDEFAULT_PRINTER = fGet_System_VALUE("DEFAULT_PRINTER")
        '  fMaterialSkin(Me)
        Me.Icon = gsIcon
        QuickAccess()
        fLoadReport()
        'MenuMainLoad()
        'If TSMenu.Items.Count <> 0 Then
        '    TSMenu.Items(0).PerformClick()
        'End If

        gsMainWith = Me.Width - Me.Width / 4
        gsMainHeight = Me.Height - Me.Height / 6


        'If gsSideBarMenuPostionRight = True Then
        '    myPanel.Left = gsMainWith - myPanel.Width
        '    MyTab.Left = 5
        '    TSToolMenu.Left = 5
        'End If

        UtilityToolStripMenuItem.DropDownItems.Add(gsUtility)
        gsFolderDialog = FolderBrowserDialog1

        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = fLoadLocationDefault()


        Me.cmbSearchType.SelectedIndex = 2
        Me.Text = gsSystemName & " v." & Application.ProductVersion & " - " & fSystemSettingValue("CompanyName")

        tssConnection.Text = "Server : " & db_Connection
        tssDatabase.Text = "Database : " & db_name
        tssSystemVer.Text = "Product Version : " & Application.ProductVersion
        tssUser_ID.Text = gsUser_ID
        tssUsername.Text = "User : " & gsUser_Name


    End Sub

    Private Sub SadasToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub FindDocumentToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindDocumentToolStripMenuItem.Click
        OpenFormBySubId(13)

    End Sub

    Private Sub FindItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindItemToolStripMenuItem.Click
        OpenFormBySubId(14)
    End Sub

    Private Sub SecurityToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ' OpenFormBySubId(30) already new setup from use -> security
    End Sub

    Private Sub UserToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UserToolStripMenuItem.Click
        OpenFormBySubId(12)

    End Sub

    Private Sub SystemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SystemToolStripMenuItem.Click
        OpenFormBySubId(87)
    End Sub

    Private Sub MenuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuToolStripMenuItem.Click
        OpenFormBySubId(88)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        OpenFormBySubId(89)
    End Sub

    Private Sub SubMenuGroupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SubMenuGroupToolStripMenuItem.Click
        OpenFormBySubId(91)
    End Sub

    Private Sub ThemeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ThemeToolStripMenuItem.Click
        frmThemeStyle.ShowDialog()
        frmThemeStyle.Dispose()
        frmThemeStyle = Nothing
    End Sub

    Private Sub ResetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ResetToolStripMenuItem.Click
        frmDatabaseReset.ShowDialog()
        frmDatabaseReset.Dispose()
        frmDatabaseReset = Nothing
    End Sub

    Private Sub AccountJournalErrorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountJournalErrorsToolStripMenuItem.Click
        If gsAdmin_User = 0 Then
            Exit Sub
        End If

        frmAccountJournalError.ShowDialog()
        frmAccountJournalError.Dispose()
        frmAccountJournalError = Nothing
    End Sub

    Private Sub AccountJournalDuplicateRemoveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AccountJournalDuplicateRemoveToolStripMenuItem.Click
        If gsAdmin_User = 0 Then
            Exit Sub
        End If
        frmDuplicateJournalAccounts.ShowDialog()
        frmDuplicateJournalAccounts.Dispose()
        frmDuplicateJournalAccounts = Nothing
    End Sub

    Private Sub PrimaryKeyUpdaterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrimaryKeyUpdaterToolStripMenuItem.Click
        If gsAdmin_User = 0 Then
            Exit Sub
        End If
        frmPrimaryKeyUpdater.ShowDialog()
        frmPrimaryKeyUpdater.Dispose()
        frmPrimaryKeyUpdater = Nothing
    End Sub

    Private Sub ItemInventoryFixedEndingQtyToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemInventoryFixedEndingQtyToolStripMenuItem.Click
        If gsAdmin_User = True Then
            frmSelectDate.ShowDialog()
            If frmSelectDate.gsOK = True Then
                frmSelectLocation.ShowDialog()
                If frmSelectLocation.gsOK = True Then
                    Dim L As Integer = frmSelectLocation.cmbLOCATION_ID.SelectedValue
                    fDoEvents()
                    Dim rd As OdbcDataReader = fReader("Select ID from `ITEM` WHERE `TYPE` ='0' and INACTIVE ='0'")
                    While rd.Read
                        fReCalculateInventory(rd("ID"), L, frmSelectDate.dtpSelect.Value)
                    End While
                End If
                frmSelectLocation.Dispose()
                frmSelectLocation = Nothing
            End If
            frmSelectDate.Dispose()
            frmSelectDate = Nothing
        End If
    End Sub

    Private Sub POSFixedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles POSFixedToolStripMenuItem.Click
        If gsAdmin_User = True Then

            frmPOS_LOG_STATING_COUNT_FIXED.ShowDialog()
            frmPOS_LOG_STATING_COUNT_FIXED.Dispose()
            frmPOS_LOG_STATING_COUNT_FIXED = Nothing


        End If

    End Sub

    Private Sub SCheckingJournalMissingValueToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SCheckingJournalMissingValueToolStripMenuItem.Click

    End Sub

    Private Sub SalesVsTaxSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesVsTaxSalesToolStripMenuItem.Click
        If gsAdmin_User = True Then
            FrmSalesVatSales.ShowDialog()
            FrmSalesVatSales.Dispose()
            FrmSalesVatSales = Nothing
        End If
    End Sub

    Private Sub ItemCostUpdaterTransactionToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemCostUpdaterTransactionToolStripMenuItem.Click
        If gsAdmin_User = True Then
            FrmItemInventoryCostUpdate.ShowDialog()
            FrmItemInventoryCostUpdate.Dispose()
            FrmItemInventoryCostUpdate = Nothing
        End If
    End Sub

    Private Sub ItemSalesTaxRecomputedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemSalesTaxRecomputedToolStripMenuItem.Click
        If gsAdmin_User = True Then
            FrmSalesTaxRecompute.ShowDialog()
            FrmSalesTaxRecompute.Dispose()
            FrmSalesTaxRecompute = Nothing
        End If
    End Sub

    Private Sub BIRInventoryReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BIRInventoryReportToolStripMenuItem.Click
        FrmImportBIRInventory.ShowDialog()
        FrmImportBIRInventory.Dispose()
        FrmImportBIRInventory = Nothing
    End Sub

    Private Sub frmMainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim r As Integer = fMessageBoxQuestionYesNoCancel("Yes = Log-out " & vbNewLine & "No = Close Program ")
        If r = 1 Then
            fLogout_user_access_control()
        ElseIf r = 2 Then
            fLogout_user_access_control()
            End
            e.Cancel = True
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub frmMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        bActiveFirst = False
        frmSplash.Show()
        frmSplash.Timer1.Enabled = True
        gsMenuSubID = ""
        gsMenuID = ""
        Me.Dispose()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        pnlSearch.Visible = False
    End Sub
    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles txtSearch.LostFocus
        fLostFocus()
    End Sub
    Private Sub fLostFocus()
        If Trim(txtSearch.Text) = "" Then
            txtSearch.Text = "Search Here"
            txtSearch.Font = New Font(gsFont, 8, FontStyle.Italic)
            txtSearch.ForeColor = Color.Gray
            pnlSearch.Visible = False

        End If
    End Sub
    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles txtSearch.GotFocus
        If txtSearch.Text = "Search Here" Then
            txtSearch.Clear()
            txtSearch.Font = New Font(gsFont, 8, FontStyle.Regular)
            txtSearch.ForeColor = Color.Black
            pnlSearch.Visible = False

        End If
    End Sub

    Public Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then

            fQuickSearch()
        ElseIf e.KeyCode = Keys.Down Then
            If dgvSearch.Rows.Count <> 0 Then
                dgvSearch.Focus()
            End If

        ElseIf e.KeyCode = Keys.Escape Then
            txtSearch.Clear()
        End If
    End Sub
    Public Sub fQuickSearch()
        Try
            If Trim(txtSearch.Text) = "" Then Exit Sub

            Dim t As Integer = cmbSearchType.SelectedIndex
            Dim sQuery As String = ""
            fCursorLoadingOn(True)

            Select Case t
                Case 0
                    sQuery = "SELECT s.`sub_id`,m.`description` AS `Category`, s.`Description` AS `Menu`  FROM tblsub_menu AS s INNER JOIN  tblmenu_list  AS ml ON ml.`sub_id` = s.`sub_id`  INNER JOIN tblmenu AS m ON m.`menu_id` =  ml.`menu_id` inner join system_security as ss on s.`description` = ss.`NAME` and ss.`user_id` = '" & gsUser_ID & "'   WHERE ml.menu_id IN ('1','2','3','4','5','6','7')  AND s.`Description` LIKE '%" & txtSearch.Text & "%' "
                    fDataGridView(dgvSearch, sQuery)
                    dgvSearch.Columns(0).Visible = False
                    If dgvSearch.Rows.Count <> 0 Then
                        pnlSearch.Visible = True

                    Else
                        pnlSearch.Visible = False

                    End If

                Case 1

                    sQuery = fContactTransaction(txtSearch.Text)
                    fDataGridView(dgvSearch, sQuery)
                    dgvSearch.Columns(0).Visible = False
                    If dgvSearch.Rows.Count <> 0 Then
                        pnlSearch.Visible = True
                    Else
                        pnlSearch.Visible = False
                    End If

                    dgvSearch.Columns(1).Width = 80
                    dgvSearch.Columns(2).Width = 100
                    dgvSearch.Columns(3).Width = 100
                Case 2
                    sQuery = fReferenceTransaction(txtSearch.Text)
                    fDataGridView(dgvSearch, sQuery)
                    dgvSearch.Columns(0).Visible = False
                    If dgvSearch.Rows.Count <> 0 Then
                        pnlSearch.Visible = True

                    Else
                        pnlSearch.Visible = False

                    End If

                    dgvSearch.Columns(1).Width = 80
                    dgvSearch.Columns(2).Width = 100
                    dgvSearch.Columns(3).Width = 100

            End Select



        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fQuickSearch()
            Else
                End
            End If
        Finally
            fCursorLoadingOn(False)
        End Try
    End Sub

    Private Sub cmbSearchType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSearchType.SelectedIndexChanged

        pnlSearch.Visible = False


    End Sub
    Private Function fReferenceTransaction(ByVal prFind As String) As String

        Dim sALl_Document_SQL As String = $"select * from (
SELECT 
  i.`ID`,
  i.`Date`,
  '{gsTextInvoice}' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`

FROM

  invoice AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN account AS a
   ON a.`ID` = i.`ACCOUNTS_RECEIVABLE_ID`
   LEFT OUTER JOIN account_type_map AS atm
   ON atm.`ID` = a.`TYPE`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
   
   UNION
   
   SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextSalesOrder & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
 
FROM
  sales_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
   
 
       UNION
   
   SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextReceivePayment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
 
FROM
  payment AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
   UNION
  
 SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextSalesReceipt & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  sales_receipt AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 

UNION

 SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextCreditMemo & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  credit_memo AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 

UNION

  SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextTaxCredit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `tax_credit` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`customer_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextPurchaseOrder & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
From
  purchase_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextBills & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  bill AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextBillCredit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  bill_credit AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextBillPayment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.Type ='1' and i.`CODE` LIKE '%" & prFind & "%' 

 UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextWithholdingTax & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `withholding_tax` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`WITHHELD_FROM_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextStockTransfer & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `stock_transfer` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PREPARED_BY_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextBuildAssembly & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`
FROM
  build_assembly AS i 
  LEFT OUTER JOIN item AS c 
  ON c.`ID` = i.`ASSEMBLY_ITEM_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextInventoryAdjustment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`
FROM
  inventory_adjustment AS i 
  LEFT OUTER JOIN inventory_adjustment_type AS c 
  ON c.`ID` = i.`ADJUSTMENT_TYPE_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.`CODE` LIKE '%" & prFind & "%' 
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextGeneralJournal & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  l.`Name` AS `Name`
FROM
  General_Journal AS i 
    LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
  WHERE i.`CODE` LIKE '%" & prFind & "%' 
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  '" & gsTextWriteCheck & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.type ='0' and i.`CODE` LIKE '%" & prFind & "%' 

UNION

  SELECT i.`ID`,
  i.`Date`,
  '" & gsTextDeposit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  a.`NAME` AS `Name`
FROM
  Deposit AS i 
  LEFT OUTER JOIN account as a
   ON a.`ID` = i.`BANK_ACCOUNT_ID` 
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`LOCATION_ID` 
  WHERE i.`CODE` LIKE '%" & prFind & "%' 

UNION
 
  SELECT i.`ID`,
  i.`Date`,
  '" & gsTextFundTransfer & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  Fund_Transfer AS i 
 LEFT OUTER JOIN contact as c
 ON c.ID = i.TO_NAME_ID
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`FROM_LOCATION_ID` 
  WHERE i.`CODE` LIKE '%" & prFind & "%') as a limit 100 
"
        Return sALl_Document_SQL

    End Function
    Private Sub fselected_Reference()
        Dim sType As String = dgvSearch.Rows(dgvSearch.CurrentRow.Index).Cells("TYPE").Value
        Dim i As Integer = fNumisNULL(fNumFieldValue("tblsub_menu", "Description", sType, "sub_id"))


        gsMenuSubID = i
        gsRefresh = True
        gsDocument_Finder_ID = dgvSearch.Rows(dgvSearch.CurrentRow.Index).Cells("ID").Value

        Dim rd As OdbcDataReader = fReader($"select * from `tblsub_menu` where sub_id = '{gsMenuSubID}' limit 1")
        Dim F As Form = Nothing
        Dim Img As Image = Nothing
        If rd.Read Then
            i = fNumisNULL(rd("sub_id"))
            F = fGetForm(rd("Form"))
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            Img = Image.FromFile(folder & rd("image_file"))
            gsSubMenuForm = rd("description")
            F.Text = rd("description")
            F.Tag = i
        End If

        For n As Integer = 0 To Me.MyTab.TabPages.Count - 1
            Dim Frm1 As Form = Me.MyTab.TabPages.Item(n).Form
            If Frm1.Text = F.Text Then
                Frm1.Close()
                Exit For
            End If
        Next
        gsMenuSubID = i
        gsRefresh = True

        TabFormOpen(F, Me.MyTab, Img)
        F.TabIndex = gsDocument_Finder_ID
        gsDocument_Finder_ID = ""

        'If gscryRpt IsNot Nothing Then
        '    gscryRpt.Close()
        '    gscryRpt.Dispose()
        '    gscryRpt = Nothing
        'End If

        'Dim fName As String = ""
        'Dim frm As New Form
        'frm = fGetForm(fName)
        'Dim tp As TabPage = New TabPage(fName)


        'Dim i_selected As Integer = 0

        'For x As Integer = 0 To gsTabControl.Controls.Count - 1
        '    If gsTabControl.Controls.Item(x).Name = fName Then
        '        i_selected = x
        '        gsTabControl.Controls.RemoveAt(x)
        '        If gsTabControl.Controls.Count = 0 Then
        '            gsTabControl.Visible = False
        '        End If
        '        Exit For
        '    End If


        'Next

        'If gsTabControl.Controls.Count <> 0 Then
        '    i_selected = i_selected - 1

        '    If i_selected > 0 Then
        '        gsTabControl.SelectTab(i_selected)

        '    End If

        'End If


    End Sub
    Private Sub fselected_search()
        Try
            fCursorLoadingOn(True)
            pnlSearch.Enabled = False
            Select Case cmbSearchType.SelectedIndex
                Case 0

                    If dgvSearch.Item(1, dgvSearch.CurrentRow.Index).Value = "Reports" Then

                        Try

                            Dim rd As OdbcDataReader = fReader("select r.Description as `Report_Group` , s.SUB_ID as `ID` ,s.Description as `Title`,s.FORM as `File`,s.IMAGE_File as `ref_desc` from tblsub_menu  as s inner join report_group as r on r.id = s.group_line  inner join system_security ss ON ss.NAME = s.DESCRIPTION where ss.USER_ID = '" & gsUser_ID & "' and s.SUB_ID = '" & dgvSearch.Item(0, dgvSearch.CurrentRow.Index).Value & "'  order by r.ID,s.Description")
                            If rd.Read Then
                                gsReportType = fTextisNULL(rd("ref_desc"))
                                gsReportTabName = fTextisNULL(rd("Title"))
                                fShowReportSetup(fTextisNULL(rd("File")), gsReportTabName)

                            End If
                            rd.Close()
                        Catch ex As Exception

                            If fMessageBoxErrorYesNo(ex.Message) = True Then

                            Else
                                End
                            End If
                        End Try

                    Else
                        gsMenuSubID = dgvSearch.Item(0, dgvSearch.CurrentRow.Index).Value
                        gsRefresh = True
                        fmenuSet()

                    End If


                Case 1
                    fselected_Reference()
                Case 2
                    fselected_Reference()
            End Select



        Catch ex As Exception

        Finally
            pnlSearch.Enabled = True
            txtSearch.Clear()
            fLostFocus()
            fCursorLoadingOn(False)
        End Try
    End Sub
    Private Sub dgvSearch_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellDoubleClick
        fselected_search()
    End Sub

    Private Sub dgvSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            fselected_search()
        ElseIf e.KeyCode = Keys.Escape Then
            txtSearch.Focus()
        End If
    End Sub
    Private Function fContactTransaction(ByVal prFind As String) As String

        Dim sALl_Document_SQL As String = "select * from (
SELECT 
  i.`ID`,
  i.`Date`,
  'Invoice' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`

FROM

  invoice AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN account AS a
   ON a.`ID` = i.`ACCOUNTS_RECEIVABLE_ID`
   LEFT OUTER JOIN account_type_map AS atm
   ON atm.`ID` = a.`TYPE`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%' 
   
   UNION
   
   SELECT 
  i.`ID`,
  i.`Date`,
  'Sales Order' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
 
FROM
  sales_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%' 
   
 
       UNION
   
   SELECT 
  i.`ID`,
  i.`Date`,
  'Receive Payment' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
 
FROM
  payment AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%' 
   UNION
  
 SELECT 
  i.`ID`,
  i.`Date`,
  'Sales Receipt' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  sales_receipt AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'

UNION

 SELECT 
  i.`ID`,
  i.`Date`,
  'Credit Memo' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  credit_memo AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'

UNION

  SELECT 
  i.`ID`,
  i.`Date`,
  'Tax Credit' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `tax_credit` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`customer_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Purchase Order' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
From
  purchase_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Bills' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  bill AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Bill Credits' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  bill_credit AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Bill Payments' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.Type ='1' and  c.`NAME` LIKE '%" & prFind & "%'

 UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Withholding Tax' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `withholding_tax` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`WITHHELD_FROM_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Stock Transfer' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `stock_transfer` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PREPARED_BY_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`NAME` LIKE '%" & prFind & "%'

UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Build Assembly' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`
FROM
  build_assembly AS i 
  LEFT OUTER JOIN item AS c 
  ON c.`ID` = i.`ASSEMBLY_ITEM_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`Description` LIKE '%" & prFind & "%'
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Inventory Adjustment' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`
FROM
  inventory_adjustment AS i 
  LEFT OUTER JOIN inventory_adjustment_type AS c 
  ON c.`ID` = i.`ADJUSTMENT_TYPE_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE c.`Description` LIKE '%" & prFind & "%'
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'General Journal' AS `Type`,
  i.`CODE` AS `Reference No`,
  l.`Name` AS `Name`
FROM
  General_Journal AS i 
    LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
  WHERE l.`NAME` LIKE '%" & prFind & "%'
UNION

SELECT 
  i.`ID`,
  i.`Date`,
  'Write Check' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.Type ='0' and c.`NAME` LIKE '%" & prFind & "%'

UNION
  SELECT i.`ID`,
  i.`Date`,
  'Deposit' AS `Type`,
  i.`CODE` AS `Reference No`,
  a.`NAME` AS `Name`
FROM
  Deposit AS i 
  LEFT OUTER JOIN account as a
   ON a.`ID` = i.`BANK_ACCOUNT_ID` 
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`LOCATION_ID` 
  WHERE a.`NAME` LIKE '%" & prFind & "%'

UNION
 
  SELECT i.`ID`,
  i.`Date`,
  'Fund Transfer' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`
FROM
  Fund_Transfer AS i 
 LEFT OUTER JOIN contact as c
 ON c.ID = i.TO_NAME_ID
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`FROM_LOCATION_ID` 
  WHERE c.`NAME` LIKE '%" & prFind & "%') as a limit 100 
"
        Return sALl_Document_SQL

    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        pnlSearch.Visible = False
    End Sub

    Private Sub dgvSearch_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlSearch.MouseDown
        drag = True 'Sets the variable drag to true.

        mousex = Windows.Forms.Cursor.Position.X - pnlSearch.Left 'Sets variable mousex

        mousey = Windows.Forms.Cursor.Position.Y - pnlSearch.Top 'Sets variable mousey

    End Sub
    Private Sub dgvSearch_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlSearch.MouseUp
        drag = False 'Sets drag to false, so the form does not move according to the code in MouseMove
    End Sub
    Private Sub dgvSearch_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlSearch.MouseMove

        'If drag is set to true then move the form accordingly.

        If drag = True Then

            pnlSearch.Top = Windows.Forms.Cursor.Position.Y - mousey
            pnlSearch.Left = Windows.Forms.Cursor.Position.X - mousex

        End If


    End Sub

    Private Sub MergeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MergeToolStripMenuItem.Click
        If gsAdmin_User = True Then
            FrmMergeItem.ShowDialog()
            FrmMergeItem.Dispose()
            FrmMergeItem = Nothing
        End If
    End Sub

    Private Sub JournalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JournalToolStripMenuItem.Click
        If gsAdmin_User = True Then

            FrmCheckingAccountJournal.ShowDialog()
            FrmCheckingAccountJournal.Dispose()
            FrmCheckingAccountJournal = Nothing


        End If
    End Sub

    Private Sub ReferenceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReferenceToolStripMenuItem.Click
        If gsAdmin_User = True Then

            FrmCheckingAccountReference.ShowDialog()
            FrmCheckingAccountReference.Dispose()
            FrmCheckingAccountReference = Nothing


        End If
    End Sub

    Private Sub frmMainMenu_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fLostFocus()


        'Location = New Point(Width, Height)
        '   StartPosition = FormStartPosition.CenterScreen

        '  Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        '  Me.Dock = DockStyle.Fill
        'Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height
        '' Dim H_ As Integer = Screen.PrimaryScreen.Bounds.Height
        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = H_PC
        'Me.Location = New Point(0, 0)
        'Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' Me.WindowState = FormWindowState.Maximized

        '  Timer1.Stop()

    End Sub

    Private Sub TSSubMenu_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub myPanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub trvMENU_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvApplication.AfterSelect




    End Sub

    Private Sub trvApplication_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles trvApplication.BeforeSelect

        If ApplicationClick = True Then
            e.Cancel = True
            Exit Sub
        End If

        If e.Node.ForeColor = Color.DarkBlue Then
            Try

                Dim rd As OdbcDataReader = fReader($"select sub_id as id,description,group_line from  tblsub_menu where description = '{e.Node.Text}' limit 1; ")
                If rd.Read Then

                    If fNumisNULL(rd("group_line")) = 0 Then

                        OpenFormBySubId(rd("id"))
                    Else
                        OpenReport(rd("id"), rd("description"))

                    End If

                Else
                    fMessageboxInfo("Menu not found")
                End If
                rd.Close()


            Catch ex As Exception

            End Try

        End If
        'Select Case e.Node.Tag
        '    Case 1 ' buyers
        '        Dim N As Integer = e.Node.Name

        '        OpenFormBySubId(N)
        '    Case 2 ' seller
        '        Dim N As Integer = e.Node.Name
        '        OpenFormBySubId(N)
        '    Case 3 ' store
        '        Dim N As Integer = e.Node.Name
        '        OpenFormBySubId(N)
        '    Case 4 ' depository
        '        Dim N As Integer = e.Node.Name
        '        OpenFormBySubId(N)
        '    Case 5 ' reports
        '        Dim N As Integer = e.Node.Name

        '        OpenReport(N, e.Node.Text)
        '    Case 6 ' tools
        '        Dim N As Integer = e.Node.Name
        '        OpenFormBySubId(N)
        '    Case 7 ' utitl
        '        Dim N As Integer = e.Node.Name
        '        OpenFormBySubId(N)
        '    Case Else

        'End Select

        ApplicationClick = True
        e.Cancel = True
    End Sub

    Private Sub txtSearchMenu_TextChanged(sender As Object, e As EventArgs) Handles txtSearchMenu.TextChanged
        fLoadApplication()
    End Sub

    Private Sub btnSearchApp_Click(sender As Object, e As EventArgs) Handles btnSearchApp.Click
        fLoadApplication()
    End Sub

    Private Sub trvApplication_MouseUp(sender As Object, e As MouseEventArgs) Handles trvApplication.MouseUp
        ApplicationClick = False
    End Sub

    Private Sub pnlFavorate_Paint(sender As Object, e As PaintEventArgs) Handles pnlFavorate.Paint

    End Sub

    Private Sub TSQuickAcces_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles TSQuickAcces.ItemClicked

    End Sub

    Private Sub pnlSideMenuList_Paint(sender As Object, e As PaintEventArgs) Handles pnlSideMenuList.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnQuickButton.Click
        fQuickSearch()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class