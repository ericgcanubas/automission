Imports System.Data.Odbc
Public Class frmCustomerStatementDetails
    Private Sub frmCustomerStatementDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        dtpFrom.Value = CDate("1/1/2016")
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        fReportProccess()
        fReportExporPDF(gscryRpt, "Customer Statement Details")
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub
    Private Sub fReportProccess()
        gscryRpt = fViewReportOneParameterNumberOnly("cryCustomerStatementDetails.rpt")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")


        Dim rd As OdbcDataReader = fReader("select * from contact where `TYPE` = '1' and ID='" & cmbCUSTOMER_ID.SelectedValue & "' limit 1")
        If rd.Read Then
            fCryParameterInsertValue(gscryRpt, dtpFrom.Value, "fdate")
            fCryParameterInsertValue(gscryRpt, dtpTo.Value, "tdate")
            fCryParameterInsertValue(gscryRpt, cmbCUSTOMER_ID.Text, "myremark")
            fCryParameterInsertValue(gscryRpt, fTextisNULL(rd("ID")), "CUSTOMER_ID")
            fCryParameterInsertValue(gscryRpt, fTextisNULL(rd("CUSTOM_FIELD1")), "CUSTOMER_LEVEL")
            fCryParameterInsertValue(gscryRpt, fTextisNULL(rd("POSTAL_ADDRESS")), "date_remark")
        End If

    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        fReportProccess()
        fReportExporPDF(gscryRpt, "Customer Statement Details")
        fPreviewReport("Customer Statement Details")
        Me.Close()
    End Sub
End Class