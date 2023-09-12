Public Class FrmPOSLogResto
    Public gsGotVoid As Boolean
    Public gsRestoNotEmpty As Boolean = False
    Private Sub frmPOSLogResto_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Icon = gsIcon
        Me.Text = $"POS LOG Details #{gsPOS_LOG_ID}  Date on {DateFormatStandard(gsPOS_DATE)}"

        fLabel_Digital_M(lblTOTAL)
        fLabel_Digital_M(lblTransactionNo)

        lblCashierName.Text = GetStringFieldValue("contact", "ID", gsCashier_ID, "Name")
        lblTOTAL.Text = NumberFormatStandard(gsPOS_TOTAL)

        lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        fCOUNT_LOAD()
        gsThemeNo = 0
        fMaterialSkin(Me)
    End Sub

    Private Sub fCOUNT_LOAD()
        fPOS_COUNT()

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
    Private Sub fPOS_COUNT()
        gsCASH_COUNT_ID = GetNumberFieldValue("POS_LOG", "ID", gsPOS_LOG_ID, "CASH_COUNT_ID")
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        gsThemeNo = 0
        fMaterialSkin(Me)
        frmPOSRestoMenu.gsCloseCall = True
        Me.Close()

    End Sub

    Private Sub btnNEw_Click(sender As Object, e As EventArgs) Handles btnNEw.Click
        fCallReports()

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



        frmPOSRestoMenu.gsCloseCall = False
        Me.Close()
    End Sub

    Private Sub btnCC_Click(sender As Object, e As EventArgs) Handles btnCC.Click
        If gsRestoNotEmpty = True Then
            MessageBoxInfo("Please transaction not cleared.")
            Exit Sub
        End If

        If Val(lblTOTAL.Text) <> 0 Then

            With frmPOSCashCount
                .ShowDialog()
                .Dispose()
            End With
            frmPOSCashCount = Nothing
            fCOUNT_LOAD()

            If gsCASH_COUNT_ID <> 0 Then

                '  Gmail("TEST11", "TEST", "egcanubas@ewgroup.com.ph")
            End If


        Else
            MessageBoxInfo("No Sales Transaction")
        End If

    End Sub

    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        ContextMenuStrip1.Show(Me, btnReport.Location)
    End Sub
    Private Sub fSalesSUmmaryCustomer()
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByCustomerSummary.rpt"
        Dim prPrint_Title As String = "Sales By Customer Summary"
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
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        frmReportViewer.Text = "Sales Summary by Customer " & GetDateTimeNowSql()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub

    Private Sub fSalesByItemSummary()
        SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByItemSummary.rpt"
        Dim prPrint_Title As String = "Sales By Item Summary"
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
        frmReportViewer.CrystalReportViewer1.DisplayToolbar = True

        frmReportViewer.Text = "Sales Summary by Customer " & GetDateTimeNowSql()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub

    Private Sub fSalesReportReceipt()
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

        CryParameterInsertValue(gscryRpt, GetNumberFieldValue("pos_cash_count", "ID", gsCASH_COUNT_ID, "TOTAL"), "cash_count")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")

        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        ReportExporPDF(gscryRpt, prPrint_Title)

        If gsAdmin_User = True Then
            gsToolPanelView = False
            frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            frmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
            frmReportViewer.WindowState = FormWindowState.Normal
            frmReportViewer.ShowDialog()
            frmReportViewer.Dispose()
        Else
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub
    Private Sub btnVOID_Click(sender As Object, e As EventArgs) Handles btnVOID.Click
        If NumIsNull(lblTransactionNo.Text) = 0 Then
            MessageBoxInfo("No Entry available.")
            Exit Sub
        End If
        DbAccessGetFieldReports(gsPayment_Print_Title, gsPayment_File_Name, frmReceivePayment.Name)
        With FrmPOSVoid
            .ShowDialog()
            gsGotVoid = .gsGotVoid
            .Dispose()
        End With
        FrmPOSVoid = Nothing

        If gsGotVoid = True Then

            fDoEvents()
            btnExit.PerformClick()

        End If
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        FrmPOSRestoSettings.ShowDialog()
        FrmPOSRestoSettings.Dispose()
        FrmPOSRestoSettings = Nothing
        fCallReports()

    End Sub

    Private Sub fLoadReports()



    End Sub
    Private Sub fCallReports()

        DbAccessGetFieldReports(gsSalesOrder_Print_Title, gsSalesOrder_File_Name, frmSalesOrder.Name)
        DbAccessGetFieldReports(gsInvoice_Print_Title, gsInvoice_File_Name, frmInvoice.Name)
        DbAccessGetFieldReports(gsPayment_Print_Title, gsPayment_File_Name, frmReceivePayment.Name)



    End Sub

    Private Sub tsSalesReceiptSummary_Click(sender As Object, e As EventArgs) Handles tsSalesReceiptSummary.Click
        fSalesReportReceipt()
    End Sub

    Private Sub tsSalesByCustomer_Click(sender As Object, e As EventArgs) Handles tsSalesByCustomer.Click
        fSalesSUmmaryCustomer()
    End Sub

    Private Sub tsSalesByItemSummary_Click(sender As Object, e As EventArgs) Handles tsSalesByItemSummary.Click
        fSalesByItemSummary()
    End Sub
End Class