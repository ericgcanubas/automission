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


            '========================
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
            fDoEvents()
            CursorLoadingOn(True)
            ' fSleep(50)


            If R_number = 1 Then
                lblinitialization.Text = "Initialize ... "
                fDoEvents()
                gsStorage_Location_ID = fLoadStorageLocation()
                gsIncRefNoByLocation = fIncRefNoByLocation()
                gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
                gsCASH_OVER_SHORT_EXPENSES = fCashOverShortExpense()

            End If

            If R_number = 3 Then


                lblinitialization.Text = "Initialize image ..."
                gsImgList = New ImageList
                gsImgList = RefreshImageList()

            End If

            If R_number = 4 Then
                'PC Default
                lblinitialization.Text = "Initialize settings ..."
                fDoEvents()
                gsClose_Date_Run_Per_Unit = fGet_System_VALUE_Bool("CloseDateRunPerUnit")
                gsSkipJournalEntry = fSystemSettingValue_Bool("SkipJournalEntry")
                gsExpiredReference = fSystemSettingValue_Bool("ExpiredReference")
                If gsPOS_Mode = True Then
                    gsExpiredReference = False
                End If

                gsUseCashDenomination = fSystemSettingValue_Bool("UseCashDenomination")

                gsDisplayTransactionNo = fSystemSettingValue_Bool("DisplayTransactionNo")
                gsDisplayTotalSales = fSystemSettingValue_Bool("DisplayTotalSales")
                gsCashCountDisplayDiscripancy = fSystemSettingValue_Bool("CashCountDisplayDiscripancy")

                gsPOSPrintPreview = fSystemSettingValue_Bool("POSPrintPreview")
                gsPOSPopupNotes = fSystemSettingValue_Bool("POSPopupNotes")
                gsMultiMethod = fSystemSettingValue_Bool("POSMultiMethod")
                'POS_POPUP_NOTES
                gsPOSPrintOS = fSystemSettingValue_Bool("PrintOS")

                gsPOSVoidEntry = fSystemSettingValue_Bool("POSVoidEntry")
                gsOpenCashDrawer = fSystemSettingValue_Bool("OpenCashDrawer")
                gsUSE_SCREEN_BUTTON = CBool(Val(fGet_System_VALUE("SCREEN_BUTTON")))

                gsGmailUsername = fSystemSettingValue("GmailUsername")
                gsGmailPassword = Decrypt(fSystemSettingValue("GmailPassword"))
                gsGmailAddressTo = fSystemSettingValue("GmailAddressTo")

                gsUseImageProduct = CBool(Val(fGet_System_VALUE("UseImageProduct")))
                gsImageSourceFolder = fGet_System_VALUE("ImageSourceFolder")
                gsImageDestinationFolder = fGet_System_VALUE("ImageDestinationFolder")

                gsDefault_Vendor_ID = fSystemSettingValue_Num("DefaultVendorID")
                gsSideBarMenuPostionRight = fSystemSettingValue_Bool("SideBarMenuPostionRight")
                gsShowAccounts = fSystemSettingValue_Bool("ShowAccounts")

                gsDRAWER_ACCOUNT_ID = fDrawerAccount()

                gsPOS_MACHINE_ID = fPOS_MACHINE_ID()
                gsPOS_TYPE_ID = fPOS_machine_type_map()

                If gsPOS_Mode = False Then
                    fLoadSubMenuTypeItem()
                Else

                End If

            End If

            If R_number = 5 Then
                lblinitialization.Text = "Initialize utility ..."
                fDoEvents()
                gsExportPDFLocation = fGet_System_VALUE("ExportPDFLocation")
                gsDataForwarderPath = fGet_System_VALUE("DataForwarderPath")
                gsDataForwarderIsActive = fGet_System_VALUE_Bool("DataForwarderIsActive")
                LoadUtility()

            End If

            If R_number = 6 Then
                lblinitialization.Text = "Initialize default value ..."
                fDoEvents()
                fLoadDefaultValue()
            End If

            If R_number = 7 Then
                lblinitialization.Text = "Initialize default accounts ..."
                fDoEvents()
                fDefaultAccountLoad()

            End If

            If R_number = 8 Then
                lblinitialization.Text = "Initialize securty ..."
                fDoEvents()
                fTax_Rate_Load()

            End If


            If R_number = 9 Then
                lblinitialization.Text = "Initialize report ..."
                fDoEvents()
                fViewReportOneParameterNumberOnly("crySalesReceipt.rpt") ' crystal report re connect

            End If

            If R_number = F_number Then


                pbLoadingBar.Value = F_number
                gsDateRangeDefault = fSystemSettingValue("DateRangeDefault") 'DateRangeDefault
                'SelectedDateDefault
                gsSelectedDateDefault = fSystemSettingValue("SelectedDateDefault")

                lblinitialization.Text = "Initialize completed ..."
                fDoEvents()

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
        If FrmLogin.bLogin = False Then
            FrmConnectionList.Visible = True
        End If


        FrmLogin.Dispose()
        FrmLogin = Nothing
        Me.Dispose()

    End Sub
    Private Sub CloseDateRunLoad()
        If gsClose_Date_Run_Per_Unit = True Then
            Dim DT As Date = Date.Now.Date.AddDays(-1)

            fSystemSettingUpdateByString("ClosingDate", DateFormatMySql(DT))

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