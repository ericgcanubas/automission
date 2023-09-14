Imports System.Data.Odbc
Public Class FrmSplash
    Dim R_number As Integer = 0
    Dim F_number As Integer = 10
    Private Sub FrmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = gsIcon
        Me.Text = Application.ProductName & vbNewLine & " Version " & Application.ProductVersion
        lblSystem_Name.Text = Application.ProductName & vbNewLine & " Version " & Application.ProductVersion
        lblSystem_Name.BackColor = Color.Transparent
        Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\toolbar\"

        If gsPOS_Mode = True Then
            Me.BackgroundImage = Image.FromFile(folder & gsPath_Background)
        Else
            Me.BackgroundImage = Image.FromFile(folder & "default_background.jpg")
        End If

        Me.BackgroundImageLayout = ImageLayout.Stretch
        pbLoadingBar.Minimum = 0
        pbLoadingBar.Maximum = F_number

    End Sub

    Private Function RefreshImageList() As ImageList
        ImagePathArrayClear()
        Dim imglist As New ImageList With {
            .ImageSize = New Size(24, 24)
        }

        Dim Num As Integer = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select sub_id,image_file from tblsub_menu where group_line = '0' and  active <> '0' and  modal = '0' and image_file <> ''")
            While rd.Read
                Num += 1
                If Num = 53 Then
                    Num = Num
                End If
                Dim ImagePath As String = "\image\sub\" & rd("image_file")
                ImgListAddMore(imglist, rd("sub_id"), ImagePath)
            End While
            rd.Close()
            ImgListAddMore(imglist, GetStringFieldValue("tblmenu", "menu_id", "1", "description"), "\image\menu\customer.png")
            ImgListAddMore(imglist, GetStringFieldValue("tblmenu", "menu_id", "2", "description"), "\image\menu\vendor.png")
            ImgListAddMore(imglist, GetStringFieldValue("tblmenu", "menu_id", "3", "description"), "\image\menu\company.png")
            ImgListAddMore(imglist, GetStringFieldValue("tblmenu", "menu_id", "4", "description"), "\image\menu\banking.png")

            ImgListAddMore(imglist, "Reports", "\image\menu\reports.png")
            ImgListAddMore(imglist, "print", "\image\sub\print-icon.png")
            ImgListAddMore(imglist, "report", "\image\sub\report_setup.png")

            ImgListAddMore(imglist, "Utility", "\image\menu\utilities.png")
            ImgListAddMore(imglist, "doc-group", "\image\sub\Documents-Icon.png")
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshImageList()
            Else
                End
            End If
        End Try


        Return imglist

    End Function
    Private Sub ImgListAddMore(ByRef imglist As ImageList, ByVal ThisKey As String, ByVal ThisPath As String)
        Dim files As String = Application.StartupPath & ThisPath
        imglist.Images.Add(ThisKey, Bitmap.FromFile(files))
    End Sub

    Private Sub ClickMTButton(sender As Object, e As EventArgs)
        Dim b As ToolStripButton = DirectCast(sender, ToolStripButton)
        gsMenuSubID = b.AccessibleDescription
        gsRefresh = True
        MenuSet()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        LoadingMode()
    End Sub
    Private Sub LoadingMode()

        pbLoadingBar.Value = 0

        pbLoadingBar.Visible = True
        lblinitialization.Visible = True
        For R_number = 0 To F_number
            pbLoadingBar.Value = R_number
            GS_DoEvents()
            CursorLoadingOn(True)
            ' GF_Sleep(50)


            If R_number = 1 Then
                lblinitialization.Text = "Initialize ... "
                GS_DoEvents()
                gsStorage_Location_ID = GetLoadStorageLocation()
                gsIncRefNoByLocation = GetIncRefNoByLocation()
                gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
                gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()

            End If

            If R_number = 3 Then


                lblinitialization.Text = "Initialize image ..."
                gsImgList = New ImageList
                gsImgList = RefreshImageList()

            End If

            If R_number = 4 Then
                'PC Default
                lblinitialization.Text = "Initialize settings ..."
                GS_DoEvents()
                gsClose_Date_Run_Per_Unit = GetDBAccessValueByBool("CloseDateRunPerUnit")
                gsSkipJournalEntry = GetSystemSettingValueByBool("SkipJournalEntry")
                gsExpiredReference = GetSystemSettingValueByBool("ExpiredReference")
                If gsPOS_Mode = True Then
                    gsExpiredReference = False
                End If

                gsUseCashDenomination = GetSystemSettingValueByBool("UseCashDenomination")

                gsDisplayTransactionNo = GetSystemSettingValueByBool("DisplayTransactionNo")
                gsDisplayTotalSales = GetSystemSettingValueByBool("DisplayTotalSales")
                gsCashCountDisplayDiscripancy = GetSystemSettingValueByBool("CashCountDisplayDiscripancy")

                gsPOSPrintPreview = GetSystemSettingValueByBool("POSPrintPreview")
                gsPOSPopupNotes = GetSystemSettingValueByBool("POSPopupNotes")
                gsMultiMethod = GetSystemSettingValueByBool("POSMultiMethod")
                'POS_POPUP_NOTES
                gsPOSPrintOS = GetSystemSettingValueByBool("PrintOS")

                gsPOSVoidEntry = GetSystemSettingValueByBool("POSVoidEntry")
                gsOpenCashDrawer = GetSystemSettingValueByBool("OpenCashDrawer")
                gsUSE_SCREEN_BUTTON = CBool(Val(GetDBAccessValueByText("SCREEN_BUTTON")))

                gsGmailUsername = GetSystemSettingValueByText("GmailUsername")
                gsGmailPassword = Decrypt(GetSystemSettingValueByText("GmailPassword"))
                gsGmailAddressTo = GetSystemSettingValueByText("GmailAddressTo")

                gsUseImageProduct = CBool(Val(GetDBAccessValueByText("UseImageProduct")))
                gsImageSourceFolder = GetDBAccessValueByText("ImageSourceFolder")
                gsImageDestinationFolder = GetDBAccessValueByText("ImageDestinationFolder")

                gsDefault_Vendor_ID = GetSystemSettingValueByNumber("DefaultVendorID")
                gsSideBarMenuPostionRight = GetSystemSettingValueByBool("SideBarMenuPostionRight")
                gsShowAccounts = GetSystemSettingValueByBool("ShowAccounts")

                gsDRAWER_ACCOUNT_ID = GetDrawerAccount()

                gsPOS_MACHINE_ID = fPOS_MACHINE_ID()
                gsPOS_TYPE_ID = fPOS_machine_type_map()

                If gsPOS_Mode = False Then
                    LoadSubMenuTypeItem()
                Else

                End If

            End If

            If R_number = 5 Then
                lblinitialization.Text = "Initialize utility ..."
                GS_DoEvents()
                gsExportPDFLocation = GetDBAccessValueByText("ExportPDFLocation")
                gsDataForwarderPath = GetDBAccessValueByText("DataForwarderPath")
                gsDataForwarderIsActive = GetDBAccessValueByBool("DataForwarderIsActive")
                LoadUtility()

            End If

            If R_number = 6 Then
                lblinitialization.Text = "Initialize default value ..."
                GS_DoEvents()
                SystemSettingLoadDefaultValue()
            End If

            If R_number = 7 Then
                lblinitialization.Text = "Initialize default accounts ..."
                GS_DoEvents()
                LoadDefaultAccount()

            End If

            If R_number = 8 Then
                lblinitialization.Text = "Initialize securty ..."
                GS_DoEvents()
                fTax_Rate_Load()

            End If


            If R_number = 9 Then
                lblinitialization.Text = "Initialize report ..."
                GS_DoEvents()
                ReportDocumentOneParameterNumberOnly("crySalesReceipt.rpt") ' crystal report re connect

            End If

            If R_number = F_number Then


                pbLoadingBar.Value = F_number
                gsDateRangeDefault = GetSystemSettingValueByText("DateRangeDefault") 'DateRangeDefault
                'SelectedDateDefault
                gsSelectedDateDefault = GetSystemSettingValueByText("SelectedDateDefault")

                lblinitialization.Text = "Initialize completed ..."
                GS_DoEvents()

                Timer2.Start()
            End If
        Next

    End Sub
    Private Sub JustLogin()
        pbLoadingBar.Visible = False
        lblinitialization.Visible = False
        CloseDateRunLoad()
        CursorLoadingOn(False)

        FrmLogin.ShowDialog()
        If FrmLogin.IsLogin = False Then
            FrmConnectionList.Visible = True
        End If


        FrmLogin.Dispose()
        FrmLogin = Nothing
        Me.Dispose()

    End Sub
    Private Sub CloseDateRunLoad()
        If gsClose_Date_Run_Per_Unit = True Then
            Dim DT As Date = Date.Now.Date.AddDays(-1)

            SetSystemSettingUpdateByText("ClosingDate", DateFormatMySql(DT))

        End If
    End Sub

    Private Sub LoadUtility()
        gsUtility = New ToolStripMenuItem
        FrmMainMenu.UtilityToolStripMenuItem.DropDownItems.Clear()
        Dim temp_group_desc As String = ""
        Dim TSmenuItem As New ToolStripMenuItem
        Try

            Dim rd As OdbcDataReader = SqlReader("select sg.description as `GROUP_NAME`,s.sub_id ,s.Description as `sub_desc`,s.`Form`,s.image_file from tblsub_group as sg inner join tblsub_group_details as sgd on sg.group_id = sgd.group_id inner join tblsub_menu as s on s.sub_id = sgd.sub_id where  sg.group_id > '0' and s.active <> '0' order by sg.description , s.description ")
            While rd.Read
                Dim n_desc As String = rd("GROUP_NAME")
                If temp_group_desc <> n_desc Then
                    If temp_group_desc <> "" Then
                        FrmMainMenu.UtilityToolStripMenuItem.DropDownItems.Add(TSmenuItem)
                    End If

                    TSmenuItem = New ToolStripMenuItem With {
                        .Name = n_desc.Replace(" ", ""),
                        .Text = n_desc
                    }

                    ToolStripItemComponent(TSmenuItem, rd("sub_desc"), rd("sub_id"), rd("Form"), rd("Image_file"))

                Else
                    ToolStripItemComponent(TSmenuItem, rd("sub_desc"), rd("sub_id"), rd("form"), rd("image_file"))
                End If
                temp_group_desc = n_desc
            End While
            gsUtility = TSmenuItem

            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                LoadUtility()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub FrmSplash_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Timer1.Enabled = True
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        JustLogin()
    End Sub
End Class