Public Class FrmPOSLog
    Public gsType As Integer
    Private Sub FrmPOSLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bgpanelSales.Visible = gsDisplayTotalSales
        lblTOTAL.Visible = gsDisplayTotalSales
        bgpanelEntry.Visible = gsDisplayTransactionNo
        lblTransactionNo.Visible = gsDisplayTransactionNo

        If gsDisplayTotalSales = True Or gsDisplayTransactionNo = True Then
            Me.Size = New Size(436, 369)
        Else
            Me.Size = New Size(436, 288)
        End If

        GS_Label_Digital_M(lblTOTAL)
        GS_Label_Digital_M(lblTransactionNo)


        Me.Icon = gsIcon
        Me.Text = $"[POINT OF SALES] Transaction On { DateFormatStandard(gsPOS_DATE)}"

        gsType = 0
        lblCashierName.Text = GF_GetStringFieldValue("contact", "ID", gsCashier_ID, "Name")
        lblMachineName.Text = GF_GetStringFieldValue("pos_machine", "ID", gsPOS_MACHINE_ID, "NAME")
        lblCreated_On.Text = CDate(LOG_DATE)

        lblTOTAL.Text = NumberFormatStandard(gsPOS_TOTAL)
        lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        CountLoad()

    End Sub
    Private Sub CountLoad()
        PosCountLoad()

        If gsCASH_COUNT_ID <> 0 Then



        End If
    End Sub
    Private Sub PosCountLoad()
        gsCASH_COUNT_ID = GF_GetNumberFieldValue("POS_LOG", "ID", gsPOS_LOG_ID, "CASH_COUNT_ID")
    End Sub
    Private Sub SalesSummaryCustomer()
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByCustomerSummary.rpt"

        gsToolPanelView = False
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "fdate")
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "tdate")
        CryParameterInsertValue(gscryRpt, "*", "customerid")
        CryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        CryParameterInsertValue(gscryRpt, "*", "statusid")
        CryParameterInsertValue(gscryRpt, "*", "doctype")
        CryParameterInsertValue(gscryRpt, "*", "salesrepid")
        CryParameterInsertValue(gscryRpt, "*", "customergroupid")
        CryParameterInsertValue(gscryRpt, "*", "item_code_id")
        CryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        CryParameterInsertValue(gscryRpt, "*", "item_group_id")
        CryParameterInsertValue(gscryRpt, "", "freference")
        CryParameterInsertValue(gscryRpt, "", "treference")

        CryParameterInsertValue(gscryRpt, "Daily Report", "myremark")
        CryParameterInsertValue(gscryRpt, DateFormatStandard(gsPOS_DATE), "date_remark")
        CryParameterInsertValue(gscryRpt, "", "amount_label")
        CryParameterInsertValue(gscryRpt, "false", "accrual")
        CryParameterInsertValue(gscryRpt, "", "basis_label")
        CryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")

        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        FrmReportViewer.Text = "Sales Summary by Buyers " & GetDateTimeNowSql()
        FrmReportViewer.WindowState = FormWindowState.Maximized
        FrmReportViewer.ShowDialog()
        FrmReportViewer.Dispose()
    End Sub

    Private Sub SalesByItemSummary()
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByItemSummary.rpt"

        gsToolPanelView = False
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "fdate")
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "tdate")
        CryParameterInsertValue(gscryRpt, "*", "customerid")
        CryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        CryParameterInsertValue(gscryRpt, "*", "statusid")
        CryParameterInsertValue(gscryRpt, "*", "doctype")
        CryParameterInsertValue(gscryRpt, "*", "salesrepid")
        CryParameterInsertValue(gscryRpt, "*", "customergroupid")
        CryParameterInsertValue(gscryRpt, "*", "item_code_id")
        CryParameterInsertValue(gscryRpt, "*", "item_class_id")
        CryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        CryParameterInsertValue(gscryRpt, "*", "item_group_id")
        CryParameterInsertValue(gscryRpt, "", "freference")
        CryParameterInsertValue(gscryRpt, "", "treference")

        CryParameterInsertValue(gscryRpt, "Daily Report", "myremark")
        CryParameterInsertValue(gscryRpt, DateFormatStandard(gsPOS_DATE), "date_remark")
        CryParameterInsertValue(gscryRpt, "", "amount_label")
        CryParameterInsertValue(gscryRpt, "false", "accrual")
        CryParameterInsertValue(gscryRpt, "", "basis_label")
        CryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")

        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        FrmReportViewer.Text = "Sales Summary by Buyers " & GetDateTimeNowSql()
        FrmReportViewer.WindowState = FormWindowState.Maximized
        FrmReportViewer.ShowDialog()
        FrmReportViewer.Dispose()
    End Sub
    Private Sub BtnReport_Click(sender As Object, e As EventArgs)
        ctmReport.Show(Me, btnReport.Location)

    End Sub
    Private Sub SalesReceiptList()
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesReceiptList.rpt"

        gsToolPanelView = False
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "fdate")
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "tdate")
        CryParameterInsertValue(gscryRpt, "*", "customerid")
        CryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        CryParameterInsertValue(gscryRpt, "*", "statusid")
        CryParameterInsertValue(gscryRpt, "*", "doctype")
        CryParameterInsertValue(gscryRpt, "*", "salesrepid")
        CryParameterInsertValue(gscryRpt, "*", "customergroupid")
        CryParameterInsertValue(gscryRpt, "*", "item_code_id")
        CryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        CryParameterInsertValue(gscryRpt, "*", "item_group_id")
        CryParameterInsertValue(gscryRpt, "", "freference")
        CryParameterInsertValue(gscryRpt, "", "treference")

        CryParameterInsertValue(gscryRpt, "Daily Report", "myremark")
        CryParameterInsertValue(gscryRpt, DateFormatStandard(gsPOS_DATE), "date_remark")
        CryParameterInsertValue(gscryRpt, "", "amount_label")
        CryParameterInsertValue(gscryRpt, "false", "accrual")
        CryParameterInsertValue(gscryRpt, "", "basis_label")
        CryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")

        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        FrmReportViewer.Text = "Sales Invoice List " & GetDateTimeNowSql()
        FrmReportViewer.WindowState = FormWindowState.Maximized
        FrmReportViewer.ShowDialog()
        FrmReportViewer.Dispose()

    End Sub
    Private Sub DailyPOSlog()
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "cryPOSTransactionLog.rpt"
        gsToolPanelView = False
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "fdate")
        CryParameterInsertValue(gscryRpt, DateFormatMySql(gsPOS_DATE), "tdate")
        CryParameterInsertValue(gscryRpt, "*", "customerid")
        CryParameterInsertValue(gscryRpt, gsPOS_LOG_ID, "pos_log_id")
        CryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        CryParameterInsertValue(gscryRpt, gsCashier_ID, "cashierid")
        CryParameterInsertValue(gscryRpt, gsPOS_MACHINE_ID, "pos_machine_id")
        CryParameterInsertValue(gscryRpt, "*", "pay_method_id")
        CryParameterInsertValue(gscryRpt, "*", "customergroupid")
        CryParameterInsertValue(gscryRpt, "*", "item_code_id")
        CryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        CryParameterInsertValue(gscryRpt, "*", "item_group_id")
        CryParameterInsertValue(gscryRpt, "*", "item_class_id")


        CryParameterInsertValue(gscryRpt, GF_GetStringFieldValue("location", "id", gsDefault_LOCATION_ID, "NAME"), "myremark")
        CryParameterInsertValue(gscryRpt, DateFormatStandard(gsPOS_DATE), "date_remark")
        CryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        FrmReportViewer.Text = "POS Log " & GetDateTimeNowSql()
        FrmReportViewer.WindowState = FormWindowState.Maximized
        FrmReportViewer.ShowDialog()
        FrmReportViewer.Dispose()
    End Sub
    Private Sub TsSalesReceiptSummary_Click(sender As Object, e As EventArgs) Handles tsSalesReceiptSummary.Click

        SalesReceiptList()
    End Sub

    Private Sub TsSalesByCustomer_Click(sender As Object, e As EventArgs) Handles tsSalesByCustomer.Click
        SalesSummaryCustomer()
    End Sub

    Private Sub TsSalesByItemSummary_Click(sender As Object, e As EventArgs) Handles tsSalesByItemSummary.Click
        SalesByItemSummary()
    End Sub

    Private Sub TsPOSLOG_Click(sender As Object, e As EventArgs) Handles tsPOSLOG.Click
        DailyPOSlog()
    End Sub

    Private Sub NewEntry()

        If gsCASH_COUNT_ID <> 0 Then
            MessageBoxInfo("Invalid. transaction alreadhy cash count")
            Exit Sub

        End If
        gsType = 1
        Me.Close()
    End Sub


    Private Sub BtnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click

        NewEntry()
    End Sub
    Private Sub CashCount()
        If gsCASH_COUNT_ID <> 0 Then
            MessageBoxInfo("Invalid. transaction alreadhy cash count")
            Exit Sub

        End If

        If Val(lblTOTAL.Text) <> 0 Then
            With FrmPOSCashCount
                .ShowDialog()
                .Dispose()
            End With
            FrmPOSCashCount = Nothing
            CountLoad()
        End If
    End Sub
    Private Sub BtnCashCount_Click(sender As Object, e As EventArgs) Handles btnCashCount.Click
        CashCount()
    End Sub
    Private Sub ListLoad()
        If gsCASH_COUNT_ID <> 0 Then
            MessageBoxInfo("Invalid. transaction alreadhy cash count")
            Exit Sub
        End If
        If Val(lblTOTAL.Text) = 0 Then
            MessageBoxInfo("Transaction not found.")
            Exit Sub
        End If


        FrmPOSVoidEntry.ShowDialog()
        Dim IsVoid As Boolean = FrmPOSVoidEntry.gsGotVoid
        FrmPOSVoidEntry.Dispose()
        FrmPOSVoidEntry = Nothing

        If IsVoid = True Then
            GS_CollectPosLog()
            GS_PosLogLoad()
            lblTOTAL.Text = NumberFormatStandard(gsPOS_TOTAL)
            lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        End If
    End Sub
    Private Sub BtnVOID_Click_1(sender As Object, e As EventArgs) Handles btnVOID.Click
        ListLoad()
    End Sub
    Private Sub ExitFun()
        gsType = 0
        Me.Close()
    End Sub
    Private Sub BtnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click
        ExitFun()
    End Sub
    Private Sub ReportSet()
        ctmReport.Show(Me, btnReport.Location)
    End Sub
    Private Sub BtnReport_Click_1(sender As Object, e As EventArgs) Handles btnReport.Click
        ReportSet()
    End Sub
    Private Sub Settings()
        FrmPOSLogSettings.ShowDialog()
        FrmPOSLogSettings.Dispose()
        FrmPOSLogSettings = Nothing
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Settings()
    End Sub

    Private Sub FrmPOSLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        KeyDownMaster(sender, e)
    End Sub
    Private Sub KeyDownMaster(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.N
                NewEntry()
            Case Keys.C
                CashCount()
            Case Keys.E
                ListLoad()
            Case Keys.L
                ExitFun()
            Case Keys.R
                ReportSet()
            Case Keys.S
                Settings()
        End Select
    End Sub

    Private Sub BtnNew_KeyDown(sender As Object, e As KeyEventArgs) Handles btnNew.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BtnCashCount_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCashCount.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BtnVOID_KeyDown(sender As Object, e As KeyEventArgs) Handles btnVOID.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BtnExit_KeyDown(sender As Object, e As KeyEventArgs) Handles btnExit.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BtnReport_KeyDown(sender As Object, e As KeyEventArgs) Handles btnReport.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BtnSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSettings.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BunifuGradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles bgpanelSales.Paint

    End Sub

    Private Sub BunifuGradientPanel2_KeyDown(sender As Object, e As KeyEventArgs) Handles bgpanelSales.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles bgpanelEntry.Paint

    End Sub

    Private Sub BunifuGradientPanel1_KeyDown(sender As Object, e As KeyEventArgs) Handles bgpanelEntry.KeyDown
        KeyDownMaster(sender, e)
    End Sub

    Private Sub BunifuGradientPanel5_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel5.Paint

    End Sub

    Private Sub BunifuGradientPanel5_KeyDown(sender As Object, e As KeyEventArgs) Handles BunifuGradientPanel5.KeyDown
        KeyDownMaster(sender, e)
    End Sub
End Class