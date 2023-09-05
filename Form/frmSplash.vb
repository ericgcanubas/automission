Imports System.Data.Odbc
Public Class frmSplash
    Dim r As Integer = 0
    Dim f As Integer = 10
    Private Sub frmSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = gsIcon

        Me.Text = Application.ProductName & vbNewLine & " Version " & Application.ProductVersion
        lblSystem_Name.Text = Application.ProductName & vbNewLine & " Version " & Application.ProductVersion
        lblSystem_Name.BackColor = Color.Transparent


        Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\toolbar\"
        'temporary
        If gsPOS_Mode = True Then
            Me.BackgroundImage = Image.FromFile(folder & gsPath_Background)
        Else
            Me.BackgroundImage = Image.FromFile(folder & "default_background.jpg")
        End If

        Me.BackgroundImageLayout = ImageLayout.Stretch
        pbLoadingBar.Minimum = 0
        pbLoadingBar.Maximum = f

    End Sub

    Private Function fRefreshImageList() As ImageList
        fgsImagePathArrayClear()
        Dim imglist As New ImageList
        imglist.ImageSize = New Size(24, 24)
        Dim i As Integer = 0
        Try

            Dim rd As OdbcDataReader = fReader("select * from tblsub_menu where group_line = '0' and  active <> '0' and  modal = '0' and image_file <> ''")
            While rd.Read
                i = i + 1
                If i = 53 Then
                    i = i
                End If
                fAddMore(imglist, rd("sub_id"), "\image\sub\" & rd("image_file"))
            End While
            rd.Close()


            '========================
            fAddMore(imglist, fGetFieldValue("tblmenu", "menu_id", "1", "description"), "\image\menu\customer.png")
            fAddMore(imglist, fGetFieldValue("tblmenu", "menu_id", "2", "description"), "\image\menu\vendor.png")
            fAddMore(imglist, fGetFieldValue("tblmenu", "menu_id", "3", "description"), "\image\menu\company.png")
            fAddMore(imglist, fGetFieldValue("tblmenu", "menu_id", "4", "description"), "\image\menu\banking.png")

            fAddMore(imglist, "Reports", "\image\menu\reports.png")
            fAddMore(imglist, "print", "\image\sub\print-icon.png")
            fAddMore(imglist, "report", "\image\sub\report_setup.png")

            fAddMore(imglist, "Utility", "\image\menu\utilities.png")
            fAddMore(imglist, "doc-group", "\image\sub\Documents-Icon.png")
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshImageList()
            Else
                End
            End If
        End Try
        Return imglist

    End Function
    Private Sub fAddMore(ByRef imglist As ImageList, ByVal ThisKey As String, ByVal ThisPath As String)
        Dim files As String = Application.StartupPath & ThisPath


        imglist.Images.Add(ThisKey, Bitmap.FromFile(files))
    End Sub

    Private Sub fClickMTButton(sender As Object, e As EventArgs)
        Dim b As ToolStripButton = DirectCast(sender, ToolStripButton)
        gsMenuSubID = b.AccessibleDescription
        gsRefresh = True
        fmenuSet()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Timer1.Enabled = False
        fLoading()
    End Sub
    Private Sub fLoading()

        pbLoadingBar.Value = 0

        pbLoadingBar.Visible = True
        lblinitialization.Visible = True
        For r = 0 To f
            pbLoadingBar.Value = r
            fDoEvents()
            fCursorLoadingOn(True)
            ' fSleep(50)


            If r = 1 Then
                lblinitialization.Text = "Initialize ... "
                fDoEvents()
                gsStorage_Location_ID = fLoadStorageLocation()
                gsIncRefNoByLocation = fIncRefNoByLocation()
                gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
                gsCASH_OVER_SHORT_EXPENSES = fCashOverShortExpense()

            End If

            If r = 3 Then


                lblinitialization.Text = "Initialize image ..."
                gsImgList = New ImageList
                gsImgList = fRefreshImageList()

            End If

            If r = 4 Then
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

            If r = 5 Then
                lblinitialization.Text = "Initialize utility ..."
                fDoEvents()
                gsExportPDFLocation = fGet_System_VALUE("ExportPDFLocation")
                gsDataForwarderPath = fGet_System_VALUE("DataForwarderPath")
                gsDataForwarderIsActive = fGet_System_VALUE_Bool("DataForwarderIsActive")
                fLoadUtility()

            End If

            If r = 6 Then
                lblinitialization.Text = "Initialize default value ..."
                fDoEvents()
                fLoadDefaultValue()
            End If

            If r = 7 Then
                lblinitialization.Text = "Initialize default accounts ..."
                fDoEvents()
                fDefaultAccountLoad()

            End If

            If r = 8 Then
                lblinitialization.Text = "Initialize securty ..."
                fDoEvents()
                fTax_Rate_Load()

            End If


            If r = 9 Then
                lblinitialization.Text = "Initialize report ..."
                fDoEvents()
                fViewReportOneParameterNumberOnly("crySalesReceipt.rpt") ' crystal report re connect

            End If

            If r = f Then


                pbLoadingBar.Value = f
                gsDateRangeDefault = fSystemSettingValue("DateRangeDefault") 'DateRangeDefault
                'SelectedDateDefault
                gsSelectedDateDefault = fSystemSettingValue("SelectedDateDefault")

                lblinitialization.Text = "Initialize completed ..."
                fDoEvents()

                Timer2.Start()
            End If
        Next

    End Sub
    Private Sub fjustLogin()
        pbLoadingBar.Visible = False
        lblinitialization.Visible = False
        fCloseDateRunLoad()
        fCursorLoadingOn(False)

        frmLogin.ShowDialog()
        If frmLogin.bLogin = False Then
            frmConnectionList.Visible = True
        End If


        frmLogin.Dispose()
        frmLogin = Nothing
        Me.Dispose()

    End Sub
    Private Sub fCloseDateRunLoad()
        If gsClose_Date_Run_Per_Unit = True Then
            Dim DT As Date = Date.Now.Date.AddDays(-1)

            fSystemSettingUpdateByString("ClosingDate", fDateFormatMYSQL(DT))

        End If
    End Sub

    Private Sub fLoadUtility()
        gsUtility = New ToolStripMenuItem
        frmMainMenu.UtilityToolStripMenuItem.DropDownItems.Clear()
        Dim temp_group_desc As String = ""
        Dim t As New ToolStripMenuItem
        Try

            Dim rd As OdbcDataReader = fReader("select sg.description as `GROUP_NAME`,s.sub_id ,s.Description as `sub_desc`,s.`Form`,s.image_file from tblsub_group as sg inner join tblsub_group_details as sgd on sg.group_id = sgd.group_id inner join tblsub_menu as s on s.sub_id = sgd.sub_id where  sg.group_id > '0' and s.active <> '0' order by sg.description , s.description ")
            While rd.Read
                Dim n_desc As String = rd("GROUP_NAME")
                If temp_group_desc <> n_desc Then
                    If temp_group_desc <> "" Then
                        frmMainMenu.UtilityToolStripMenuItem.DropDownItems.Add(t)
                    End If
                    t = New ToolStripMenuItem
                    t.Name = n_desc.Replace(" ", "")
                    t.Text = n_desc

                    fToolSTRIP_ITEM(t, rd("sub_desc"), rd("sub_id"), rd("Form"), rd("Image_file"))

                Else
                    fToolSTRIP_ITEM(t, rd("sub_desc"), rd("sub_id"), rd("form"), rd("image_file"))
                End If
                temp_group_desc = n_desc
            End While
            gsUtility = t

            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fLoadUtility()
            Else
                End
            End If
        End Try

    End Sub



    Private Sub frmSplash_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Timer1.Enabled = True
    End Sub

    Private Sub frmSplash_RegionChanged(sender As Object, e As EventArgs) Handles Me.RegionChanged

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        fjustLogin()

    End Sub
End Class