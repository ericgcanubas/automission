Public Class FrmPOSLogResto
    Public gsGotVoid As Boolean
    Public gsRestoNotEmpty As Boolean = False
    Private Sub FrmPOSLogResto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = gsIcon
        Me.Text = $"POS LOG Details #{gsPOS_LOG_ID}  Date on {DateFormatStandard(gsPOS_DATE)}"

        GS_Label_Digital_M(lblTOTAL)
        GS_Label_Digital_M(lblTransactionNo)

        lblCashierName.Text = GF_GetStringFieldValue("contact", "ID", gsCashier_ID, "Name")
        lblTOTAL.Text = NumberFormatStandard(gsPOS_TOTAL)

        lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        CountLoad()


    End Sub

    Private Sub CountLoad()
        PosCountLoad()

        If gsCASH_COUNT_ID <> 0 Then
            btnNEw.Enabled = False
            btnCC.Enabled = False
            btnVOID.Enabled = False
        Else
            btnNEw.Enabled = True
            btnCC.Enabled = True
            btnVOID.Enabled = True
        End If
    End Sub
    Private Sub PosCountLoad()
        gsCASH_COUNT_ID = GF_GetNumberFieldValue("POS_LOG", "ID", gsPOS_LOG_ID, "CASH_COUNT_ID")
    End Sub
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        FrmPOSRestoMenu.gsCloseCall = True
        Me.Close()

    End Sub

    Private Sub BtnNEw_Click(sender As Object, e As EventArgs) Handles btnNEw.Click
        CallReports()

        If gsPOS_SERVED_ONLY = False Then

            If gsSalesOrder_File_Name = "" Then
                MessageBoxQuestion("SO:No Report file found")
                Exit Sub
            End If

            If gsInvoice_File_Name = "" Then
                MessageBoxQuestion("NV:No Report file found")
                Exit Sub
            End If


            If gsPayment_File_Name = "" Then
                MessageBoxQuestion("PN:No Report file found")
                Exit Sub
            End If

        Else

            If gsInvoice_File_Name = "" Then
                MessageBoxQuestion("NV:No Report file found")
                Exit Sub
            End If


            If gsPayment_File_Name = "" Then
                MessageBoxQuestion("PN:No Report file found")
                Exit Sub
            End If

        End If



        FrmPOSRestoMenu.gsCloseCall = False
        Me.Close()
    End Sub

    Private Sub BtnCC_Click(sender As Object, e As EventArgs) Handles btnCC.Click
        If gsRestoNotEmpty = True Then
            MessageBoxInfo("Please transaction not cleared.")
            Exit Sub
        End If

        If Val(lblTOTAL.Text) <> 0 Then

            With FrmPOSCashCount
                .ShowDialog()
                .Dispose()
            End With
            FrmPOSCashCount = Nothing
            CountLoad()

            If gsCASH_COUNT_ID <> 0 Then

                '  Gmail("TEST11", "TEST", "egcanubas@ewgroup.com.ph")
            End If


        Else
            MessageBoxInfo("No Sales Transaction")
        End If

    End Sub

    Private Sub BtnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        ContextMenuStrip1.Show(Me, btnReport.Location)
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

        FrmReportViewer.Text = "Sales Summary by Customer " & GetDateTimeNowSql()
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

        FrmReportViewer.Text = "Sales Summary by Customer " & GetDateTimeNowSql()
        FrmReportViewer.WindowState = FormWindowState.Maximized
        FrmReportViewer.ShowDialog()
        FrmReportViewer.Dispose()
    End Sub

    Private Sub SalesReportReceipt()
        If gsRestoNotEmpty = True Then
            MessageBoxInfo("Please transaction not cleared.")
            Exit Sub
        End If

        DbAccessGetFieldReports(gsResto_Sales_Print_Title, gsResto_Sales__File_Name, "frmPOSLogResto")
        If gsResto_Sales__File_Name = "" Then
            MessageBoxInfo("Report not set.")
            Exit Sub
        End If
        '   Gmail("TEST11", "TEST", "ecanubas@ewgroup.com.ph")
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = gsResto_Sales__File_Name ' "cryPaymentLog.rpt"
        Dim prPrint_Title As String = $"{gsResto_Sales_Print_Title} (" & gsPOS_LOG_ID & ")"

        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, Val(gsPOS_LOG_ID), "pos_log_id")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")

        CryParameterInsertValue(gscryRpt, GF_GetNumberFieldValue("pos_cash_count", "ID", gsCASH_COUNT_ID, "TOTAL"), "cash_count")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")

        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        ReportExporPDF(gscryRpt, prPrint_Title)

        If gsAdmin_User = True Then
            gsToolPanelView = False
            FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            FrmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
            FrmReportViewer.WindowState = FormWindowState.Normal
            FrmReportViewer.ShowDialog()
            FrmReportViewer.Dispose()
        Else
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub
    Private Sub BtnVOID_Click(sender As Object, e As EventArgs) Handles btnVOID.Click
        If GF_NumIsNull(lblTransactionNo.Text) = 0 Then
            MessageBoxInfo("No Entry available.")
            Exit Sub
        End If
        DbAccessGetFieldReports(gsPayment_Print_Title, gsPayment_File_Name, FrmReceivePayment.Name)
        With FrmPOSVoid
            .ShowDialog()
            gsGotVoid = .gsGotVoid
            .Dispose()
        End With
        FrmPOSVoid = Nothing

        If gsGotVoid = True Then

            GS_DoEvents()
            btnExit.PerformClick()

        End If
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        FrmPOSRestoSettings.ShowDialog()
        FrmPOSRestoSettings.Dispose()
        FrmPOSRestoSettings = Nothing
        CallReports()

    End Sub

    Private Sub CallReports()

        DbAccessGetFieldReports(gsSalesOrder_Print_Title, gsSalesOrder_File_Name, FrmSalesOrder.Name)
        DbAccessGetFieldReports(gsInvoice_Print_Title, gsInvoice_File_Name, FrmInvoice.Name)
        DbAccessGetFieldReports(gsPayment_Print_Title, gsPayment_File_Name, FrmReceivePayment.Name)



    End Sub

    Private Sub TsSalesReceiptSummary_Click(sender As Object, e As EventArgs) Handles tsSalesReceiptSummary.Click
        SalesReportReceipt()
    End Sub

    Private Sub TsSalesByCustomer_Click(sender As Object, e As EventArgs) Handles tsSalesByCustomer.Click
        SalesSummaryCustomer()
    End Sub

    Private Sub TsSalesByItemSummary_Click(sender As Object, e As EventArgs) Handles tsSalesByItemSummary.Click
        SalesByItemSummary()
    End Sub
End Class