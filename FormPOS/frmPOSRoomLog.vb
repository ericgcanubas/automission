﻿Public Class frmPOSRoomLog
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        FrmPOSRoom.gsCloseCall = True
        Me.Close()

    End Sub

    Private Sub frmPOSRoomLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = gsIcon
        Me.Text = $"POS LOG  #{gsPOS_LOG_ID}  Date on {fDateFormatStandard(gsPOS_DATE)}"
        fLabel_Digital_M(lblTOTAL)
        fLabel_Digital_M(lblTransactionNo)
        lblCashierName.Text = fGetFieldValue("contact", "ID", gsCashier_ID, "Name")
        lblTOTAL.Text = fNumFormatStandard(gsPOS_TOTAL)
        lblTransactionNo.Text = gsPOS_TRANSACTION_COUNT
        fCOUNT_LOAD()
    End Sub

    Private Sub btnNEw_Click(sender As Object, e As EventArgs) Handles btnNEw.Click

        frmPOSRestoMenu.gsCloseCall = False
        Me.Close()
    End Sub

    Private Sub btnCC_Click(sender As Object, e As EventArgs) Handles btnCC.Click


        If Val(lblTOTAL.Text) <> 0 Then

            With frmPOSCashCount
                .Location = New Point(0, 0)
                .ShowDialog()
                .Dispose()
            End With
            frmPOSCashCount = Nothing
            fCOUNT_LOAD()

            If gsCASH_COUNT_ID <> 0 Then
                '  Gmail("TEST11", "TEST", "egcanubas@ewgroup.com.ph")
            End If


        Else
            fMessageboxInfo("No Sales Transaction")
        End If
    End Sub
    Private Sub fCOUNT_LOAD()
        fPOS_COUNT()

        If gsCASH_COUNT_ID <> 0 Then
            btnNEw.Enabled = False
            btnCC.Enabled = False
            ' btnVOID.Enabled = False
        Else
            btnNEw.Enabled = True
            btnCC.Enabled = True
            '    btnVOID.Enabled = True
        End If
    End Sub
    Private Sub fPOS_COUNT()
        gsCASH_COUNT_ID = fNumFieldValue("POS_LOG", "ID", gsPOS_LOG_ID, "CASH_COUNT_ID")
    End Sub
    Private Sub btnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        '  ContextMenuStrip1.Show(Me, btnReport.Location)
        fSalesReportReceipt()
    End Sub
    Private Sub fSalesSUmmaryCustomer()
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByCustomerSummary.rpt"
        Dim prPrint_Title As String = "Sales By Customer Summary"
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

        frmReportViewer.Text = "Sales Summary by Customer " & fDateTimeNow()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub

    Private Sub fSalesByItemSummary()
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "crySalesByItemDetailsLine.rpt"
        Dim prPrint_Title As String = "Sales By Summary"
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

        frmReportViewer.Text = "Sales Summary by Customer " & fDateTimeNow()
        frmReportViewer.WindowState = FormWindowState.Maximized
        frmReportViewer.ShowDialog()
        frmReportViewer.Dispose()
    End Sub
    Private Sub fTransactionLog()
        If btnCC.Enabled = True Then
            fMessageboxWarning("Invalid cash count entry required.")
            Exit Sub
        End If

        fMSgetFieldGetReports(gsResto_Sales_Print_Title, gsResto_Sales__File_Name, "frmPOSLogResto")
        If gsResto_Sales__File_Name = "" Then
            fMessageboxInfo("Report not set.")
            Exit Sub
        End If
        '   Gmail("TEST11", "TEST", "ecanubas@ewgroup.com.ph")
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = "cryPOSTransLogX.rpt" ' "cryPaymentLog.rpt"
        Dim prPrint_Title As String = $"{gsResto_Sales_Print_Title} (" & gsPOS_LOG_ID & ")"

        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, Val(gsPOS_LOG_ID), "pos_log_id")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")

        fCryParameterInsertValue(gscryRpt, fNumFieldValue("pos_cash_count", "ID", gsCASH_COUNT_ID, "TOTAL"), "cash_count")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
        fCryParameterInsertValue(gscryRpt, lblCashierName.Text, "user_name")
        fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        fReportExporPDF(gscryRpt, prPrint_Title)

        If gsAdmin_User = True Then
            gsToolPanelView = False
            frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            frmReportViewer.Text = "POS Preview " & fDateTimeNow()
            frmReportViewer.WindowState = FormWindowState.Normal
            frmReportViewer.ShowDialog()
            frmReportViewer.Dispose()
        Else
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If

    End Sub
    Private Sub fSalesReportReceipt()
        If btnCC.Enabled = True Then
            fMessageboxWarning("Invalid cash count entry required.")
            Exit Sub
        End If

        fMSgetFieldGetReports(gsResto_Sales_Print_Title, gsResto_Sales__File_Name, "frmPOSLogResto")
        If gsResto_Sales__File_Name = "" Then
            fMessageboxInfo("Report not set.")
            Exit Sub
        End If
        '   Gmail("TEST11", "TEST", "ecanubas@ewgroup.com.ph")
        fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Dim prFile_name As String = gsResto_Sales__File_Name ' "cryPaymentLog.rpt"
        Dim prPrint_Title As String = $"{gsResto_Sales_Print_Title} (" & gsPOS_LOG_ID & ")"

        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        fCryParameterInsertValue(gscryRpt, Val(gsPOS_LOG_ID), "pos_log_id")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")

        fCryParameterInsertValue(gscryRpt, fNumFieldValue("pos_cash_count", "ID", gsCASH_COUNT_ID, "TOTAL"), "cash_count")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
        fCryParameterInsertValue(gscryRpt, lblCashierName.Text, "user_name")
        fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        fReportExporPDF(gscryRpt, prPrint_Title)

        If gsAdmin_User = True Then
            gsToolPanelView = False
            frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            frmReportViewer.Text = "POS Preview " & fDateTimeNow()
            frmReportViewer.WindowState = FormWindowState.Normal
            frmReportViewer.ShowDialog()
            frmReportViewer.Dispose()
        Else
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        End If

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

    Private Sub btnPrintLog_Click(sender As Object, e As EventArgs) Handles btnPrintLog.Click
        fTransactionLog()
    End Sub
End Class