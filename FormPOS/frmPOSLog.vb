Public Class frmPOSLog
    Public gsType As Integer
    Private Sub frmPOSLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        bgpanelSales.Visible = gsDisplayTotalSales
        lblTOTAL.Visible = gsDisplayTotalSales
        bgpanelEntry.Visible = gsDisplayTransactionNo
        lblTransactionNo.Visible = gsDisplayTransactionNo

        If gsDisplayTotalSales = True Or gsDisplayTransactionNo = True Then
            Me.Size = New Size(436, 369)
        Else
            Me.Size = New Size(436, 288)
        End If

        fLabel_Digital_M(lblTOTAL)
        fLabel_Digital_M(lblTransactionNo)

        fMaterialSkin(Me)
        Me.Icon = gsIcon
        Me.Text = $"[POINT OF SALES] Transaction On { fDateFormatStandard(gsPOS_DATE)}"
        ' Me.BackColor = ColorTranslator.FromHtml(gsColor_Code)
        gsType = 0
        lblCashierName.Text = fGetFieldValue("contact", "ID", gsCashier_ID, "Name")
        lblMachineName.Text = fGetFieldValue("pos_machine", "ID", gsPOS_MACHINE_ID, "NAME")
        lblCreated_On.Text = CDate(LOG_DATE)

        lblTOTAL.Text = fNumFormatStandard(gsPOS_TOTAL)
        lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        fCOUNT_LOAD()

    End Sub
    Private Sub fCOUNT_LOAD()
        fPOS_COUNT()

        If gsCASH_COUNT_ID <> 0 Then



        End If
    End Sub
    Private Sub fPOS_COUNT()
        gsCASH_COUNT_ID = fNumFieldValue("POS_LOG", "ID", gsPOS_LOG_ID, "CASH_COUNT_ID")
    End Sub


    Private Sub BtnNEw_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnCC_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub fSalesSummaryCustomer()
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByCustomerSummary.rpt"
        Dim prPrint_Title As String = "Sales By Buyer Summary"
        gsToolPanelView = False
        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "fdate")
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "tdate")
        fCryParameterInsertValue(gscryRpt, "*", "customerid")
        fCryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        fCryParameterInsertValue(gscryRpt, "*", "statusid")
        fCryParameterInsertValue(gscryRpt, "*", "doctype")
        fCryParameterInsertValue(gscryRpt, "*", "salesrepid")
        fCryParameterInsertValue(gscryRpt, "*", "customergroupid")
        fCryParameterInsertValue(gscryRpt, "*", "item_code_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_group_id")
        fCryParameterInsertValue(gscryRpt, "", "freference")
        fCryParameterInsertValue(gscryRpt, "", "treference")

        fCryParameterInsertValue(gscryRpt, "Daily Report", "myremark")
        fCryParameterInsertValue(gscryRpt, fDateFormatStandard(gsPOS_DATE), "date_remark")
        fCryParameterInsertValue(gscryRpt, "", "amount_label")
        fCryParameterInsertValue(gscryRpt, "false", "accrual")
        fCryParameterInsertValue(gscryRpt, "", "basis_label")
        fCryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")

        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        frmReportViewer.Text = "Sales Summary by Buyers " & fDateTimeNow()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub

    Private Sub fSalesByItemSummary()
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByItemSummary.rpt"
        Dim prPrint_Title As String = "Sales By Item Summary"
        gsToolPanelView = False
        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "fdate")
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "tdate")
        fCryParameterInsertValue(gscryRpt, "*", "customerid")
        fCryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        fCryParameterInsertValue(gscryRpt, "*", "statusid")
        fCryParameterInsertValue(gscryRpt, "*", "doctype")
        fCryParameterInsertValue(gscryRpt, "*", "salesrepid")
        fCryParameterInsertValue(gscryRpt, "*", "customergroupid")
        fCryParameterInsertValue(gscryRpt, "*", "item_code_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_class_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_group_id")
        fCryParameterInsertValue(gscryRpt, "", "freference")
        fCryParameterInsertValue(gscryRpt, "", "treference")

        fCryParameterInsertValue(gscryRpt, "Daily Report", "myremark")
        fCryParameterInsertValue(gscryRpt, fDateFormatStandard(gsPOS_DATE), "date_remark")
        fCryParameterInsertValue(gscryRpt, "", "amount_label")
        fCryParameterInsertValue(gscryRpt, "false", "accrual")
        fCryParameterInsertValue(gscryRpt, "", "basis_label")
        fCryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")

        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        frmReportViewer.Text = "Sales Summary by Buyers " & fDateTimeNow()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub
    Private Sub BtnReport_Click(sender As Object, e As EventArgs)
        ctmReport.Show(Me, btnReport.Location)

    End Sub
    Private Sub fSalesReceiptList()
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesReceiptList.rpt"
        Dim prPrint_Title As String = "Sales Invoice List"
        gsToolPanelView = False
        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "fdate")
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "tdate")
        fCryParameterInsertValue(gscryRpt, "*", "customerid")
        fCryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        fCryParameterInsertValue(gscryRpt, "*", "statusid")
        fCryParameterInsertValue(gscryRpt, "*", "doctype")
        fCryParameterInsertValue(gscryRpt, "*", "salesrepid")
        fCryParameterInsertValue(gscryRpt, "*", "customergroupid")
        fCryParameterInsertValue(gscryRpt, "*", "item_code_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_group_id")
        fCryParameterInsertValue(gscryRpt, "", "freference")
        fCryParameterInsertValue(gscryRpt, "", "treference")

        fCryParameterInsertValue(gscryRpt, "Daily Report", "myremark")
        fCryParameterInsertValue(gscryRpt, fDateFormatStandard(gsPOS_DATE), "date_remark")
        fCryParameterInsertValue(gscryRpt, "", "amount_label")
        fCryParameterInsertValue(gscryRpt, "false", "accrual")
        fCryParameterInsertValue(gscryRpt, "", "basis_label")
        fCryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")

        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        frmReportViewer.Text = "Sales Invoice List " & fDateTimeNow()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()

    End Sub
    Private Sub fDailyPOSlog()
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "cryPOSTransactionLog.rpt"
        Dim prPrint_Title As String = "POS Transaction Log"
        gsToolPanelView = False
        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "fdate")
        fCryParameterInsertValue(gscryRpt, fDateFormatMYSQL(gsPOS_DATE), "tdate")
        fCryParameterInsertValue(gscryRpt, "*", "customerid")
        fCryParameterInsertValue(gscryRpt, gsPOS_LOG_ID, "pos_log_id")
        fCryParameterInsertValue(gscryRpt, gsDefault_LOCATION_ID, "locationid")
        fCryParameterInsertValue(gscryRpt, gsCashier_ID, "cashierid")
        fCryParameterInsertValue(gscryRpt, gsPOS_MACHINE_ID, "pos_machine_id")
        fCryParameterInsertValue(gscryRpt, "*", "pay_method_id")
        fCryParameterInsertValue(gscryRpt, "*", "customergroupid")
        fCryParameterInsertValue(gscryRpt, "*", "item_code_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_sub_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_group_id")
        fCryParameterInsertValue(gscryRpt, "*", "item_class_id")


        fCryParameterInsertValue(gscryRpt, fGetFieldValue("location", "id", gsDefault_LOCATION_ID, "NAME"), "myremark")
        fCryParameterInsertValue(gscryRpt, fDateFormatStandard(gsPOS_DATE), "date_remark")
        fCryParameterInsertValue(gscryRpt, $"Cashier {lblCashierName.Text}", "name_by")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        frmReportViewer.Text = "POS Log " & fDateTimeNow()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnVOID_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsSalesReceiptSummary_Click(sender As Object, e As EventArgs) Handles tsSalesReceiptSummary.Click

        fSalesReceiptList()
    End Sub

    Private Sub tsSalesByCustomer_Click(sender As Object, e As EventArgs) Handles tsSalesByCustomer.Click
        fSalesSummaryCustomer()
    End Sub

    Private Sub tsSalesByItemSummary_Click(sender As Object, e As EventArgs) Handles tsSalesByItemSummary.Click
        fSalesByItemSummary()
    End Sub

    Private Sub tsPOSLOG_Click(sender As Object, e As EventArgs) Handles tsPOSLOG.Click
        fDailyPOSlog()
    End Sub

    Private Sub fNewEntry()

        If gsCASH_COUNT_ID <> 0 Then
            fMessageboxInfo("Invalid. transaction alreadhy cash count")
            Exit Sub

        End If
        gsType = 1
        Me.Close()
    End Sub


    Private Sub btnNew_Click_1(sender As Object, e As EventArgs) Handles btnNew.Click

        fNewEntry()
    End Sub
    Private Sub fCashCount()
        If gsCASH_COUNT_ID <> 0 Then
            fMessageboxInfo("Invalid. transaction alreadhy cash count")
            Exit Sub

        End If

        If Val(lblTOTAL.Text) <> 0 Then
            With frmPOSCashCount
                .ShowDialog()
                .Dispose()
            End With
            frmPOSCashCount = Nothing
            fCOUNT_LOAD()
        End If
    End Sub
    Private Sub btnCashCount_Click(sender As Object, e As EventArgs) Handles btnCashCount.Click
        fCashCount()
    End Sub
    Private Sub fList()
        If gsCASH_COUNT_ID <> 0 Then
            fMessageboxInfo("Invalid. transaction alreadhy cash count")
            Exit Sub
        End If
        If Val(lblTOTAL.Text) = 0 Then
            fMessageboxInfo("Transaction not found.")
            Exit Sub
        End If

        Dim IsVoid As Boolean = False
        FrmPOSVoidEntry.ShowDialog()
        IsVoid = FrmPOSVoidEntry.gsGotVoid
        FrmPOSVoidEntry.Dispose()
        FrmPOSVoidEntry = Nothing

        If IsVoid = True Then
            fCollect_POSLog()
            fPOS_LOG()
            lblTOTAL.Text = fNumFormatStandard(gsPOS_TOTAL)
            lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        End If
    End Sub
    Private Sub btnVOID_Click_1(sender As Object, e As EventArgs) Handles btnVOID.Click
        fList()
    End Sub
    Private Sub fExit()
        gsType = 0
        Me.Close()
    End Sub
    Private Sub btnExit_Click_1(sender As Object, e As EventArgs) Handles btnExit.Click
        fExit()
    End Sub
    Private Sub fReport()
        ctmReport.Show(Me, btnReport.Location)
    End Sub
    Private Sub btnReport_Click_1(sender As Object, e As EventArgs) Handles btnReport.Click
        fReport()
    End Sub
    Private Sub fSettings()
        frmPOSLogSettings.ShowDialog()
        frmPOSLogSettings.Dispose()
        frmPOSLogSettings = Nothing
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        fSettings()
    End Sub

    Private Sub frmPOSLog_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        fkeyMaster(sender, e)
    End Sub
    Private Sub fkeyMaster(sender As Object, e As KeyEventArgs)

        Select Case e.KeyCode
            Case Keys.N
                fNewEntry()
            Case Keys.C
                fCashCount()
            Case Keys.E
                fList()
            Case Keys.L
                fExit()
            Case Keys.R
                fReport()
            Case Keys.S
                fSettings()
        End Select
    End Sub

    Private Sub btnNew_KeyDown(sender As Object, e As KeyEventArgs) Handles btnNew.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub btnCashCount_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCashCount.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub btnVOID_KeyDown(sender As Object, e As KeyEventArgs) Handles btnVOID.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub btnExit_KeyDown(sender As Object, e As KeyEventArgs) Handles btnExit.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub btnReport_KeyDown(sender As Object, e As KeyEventArgs) Handles btnReport.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub btnSettings_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSettings.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub BunifuGradientPanel2_Paint(sender As Object, e As PaintEventArgs) Handles bgpanelSales.Paint

    End Sub

    Private Sub BunifuGradientPanel2_KeyDown(sender As Object, e As KeyEventArgs) Handles bgpanelSales.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub BunifuGradientPanel1_Paint(sender As Object, e As PaintEventArgs) Handles bgpanelEntry.Paint

    End Sub

    Private Sub BunifuGradientPanel1_KeyDown(sender As Object, e As KeyEventArgs) Handles bgpanelEntry.KeyDown
        fkeyMaster(sender, e)
    End Sub

    Private Sub BunifuGradientPanel5_Paint(sender As Object, e As PaintEventArgs) Handles BunifuGradientPanel5.Paint

    End Sub

    Private Sub BunifuGradientPanel5_KeyDown(sender As Object, e As KeyEventArgs) Handles BunifuGradientPanel5.KeyDown
        fkeyMaster(sender, e)
    End Sub
End Class