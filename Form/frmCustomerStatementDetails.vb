Imports System.Data.Odbc
Public Class FrmCustomerStatementDetails
    Private Sub FrmCustomerStatementDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        dtpFrom.Value = CDate("1/1/2016")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ReportProccess()
        ReportExporPDF(gscryRpt, "Customer Statement Details")
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub
    Private Sub ReportProccess()
        gscryRpt = ReportDocumentOneParameterNumberOnly("cryCustomerStatementDetails.rpt")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")


        Dim rd As OdbcDataReader = SqlReader("select * from contact where `TYPE` = '1' and ID='" & cmbCUSTOMER_ID.SelectedValue & "' limit 1")
        If rd.Read Then
            CryParameterInsertValue(gscryRpt, dtpFrom.Value, "fdate")
            CryParameterInsertValue(gscryRpt, dtpTo.Value, "tdate")
            CryParameterInsertValue(gscryRpt, cmbCUSTOMER_ID.Text, "myremark")
            CryParameterInsertValue(gscryRpt, TextIsNull(rd("ID")), "CUSTOMER_ID")
            CryParameterInsertValue(gscryRpt, TextIsNull(rd("CUSTOM_FIELD1")), "CUSTOMER_LEVEL")
            CryParameterInsertValue(gscryRpt, TextIsNull(rd("POSTAL_ADDRESS")), "date_remark")
        End If

    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        ReportProccess()
        ReportExporPDF(gscryRpt, "Customer Statement Details")
        GlobalPreviewReport("Customer Statement Details")
        Me.Close()
    End Sub
End Class