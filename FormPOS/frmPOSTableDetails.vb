﻿Public Class frmPOSTableDetails
    Public gsTABLE_NO As Integer
    Public gsORDER_TYPE As Integer
    Public gsClickOk As Boolean = False
    Private Sub FrmPOSTableDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If gsORDER_TYPE = gsDINE_IN_ID Then
            Me.Text = "DINE-IN TABLE NO." & gsTABLE_NO
            btnOK.Text = "Set as Available"
        Else
            Me.Text = "ORDER NO." & gsTABLE_NO
            btnOK.Text = "Pick-up"
        End If

        gsClickOk = False

        fDataGridView(dgvPAYMENT, $"select  p.ID,p.RECORDED_ON as `Log`,p.RECEIPT_REF_NO as `O.R` ,p.AMOUNT_APPLIED  as `AMOUNT` from PAYMENT  as p inner join pos_table_served as s on s.PAYMENT_ID = p.ID WHERE  s.IS_ACTIVE <> '0' and s.table_no = '{gsTABLE_NO}' and s.pos_log_id = '{gsPOS_LOG_ID}' and s.cashier_id = '{gsCashier_ID}'")

        dgvPAYMENT.Columns(0).Visible = False


    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        gsClickOk = True

        fExecutedOnly($"UPDATE pos_table_served  SET IS_ACTIVE ='0' WHERE POS_LOG_ID = '{gsPOS_LOG_ID}' and TABLE_NO = '{gsTABLE_NO}' and CASHIER_ID = '{gsCashier_ID}' and ORDER_TYPE_ID = '{gsORDER_TYPE}' ")

        Me.Close()
    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnPRINT_RECEIPT_Click(sender As Object, e As EventArgs) Handles btnPRINT_RECEIPT.Click
        If dgvPAYMENT.Rows.Count = 0 Then
            fMessageboxInfo("Data not found.")
            Exit Sub
        End If

        dgvPAYMENT.Select()
        Dim ThisID As Integer
        Try
            ThisID = dgvPAYMENT.CurrentRow.Cells(0).Value
            If ThisID = 0 Then
                Exit Sub
            End If

            btnPRINT_RECEIPT.Enabled = False
            fSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)
            Dim prFile_name As String = gsPayment_File_Name
            Dim prPrint_Title As String = gsPayment_Print_Title
            gscryRpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(ThisID), "id")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyTin"), "tin_number")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                frmReportViewer.Text = "POS Preview " & fDateTimeNow()
                frmReportViewer.WindowState = FormWindowState.Normal
                frmReportViewer.ShowDialog()
                frmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If

        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try

        btnPRINT_RECEIPT.Enabled = True
    End Sub

    Private Sub frmPOSTableDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        dgvPAYMENT.Columns(1).Width = 300
        dgvPAYMENT.Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPAYMENT.Columns("AMOUNT").DefaultCellStyle.Format = "N2"
        dgvPAYMENT.Columns("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub BtnPRINTOS_Click(sender As Object, e As EventArgs) Handles btnPRINTOS.Click
        If dgvPAYMENT.Rows.Count = 0 Then
            fMessageboxInfo("File not found.")
            Exit Sub
        End If

        dgvPAYMENT.Select()
        Dim ThisID As Integer
        Try
            ThisID = fNumFieldValue("payment_invoices", "payment_id", dgvPAYMENT.CurrentRow.Cells(0).Value, "invoice_id")

            If ThisID = 0 Then
                Exit Sub
            End If

            btnPRINTOS.Enabled = False
            fSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)
            Dim prFile_name As String = gsInvoice_File_Name
            Dim prPrint_Title As String = gsInvoice_Print_Title
            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(ThisID), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyTin"), "tin_number")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                frmReportViewer.Text = "POS Preview " & fDateTimeNow()
                frmReportViewer.WindowState = FormWindowState.Normal
                frmReportViewer.ShowDialog()
                frmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If
        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try

        btnPRINTOS.Enabled = True


    End Sub
End Class