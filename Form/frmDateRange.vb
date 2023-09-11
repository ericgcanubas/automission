Public Class FrmDateRange
    Private Sub FrmDateRange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = gsReportName

        dtpDT1.Value = Date.Now.Date
        dtpDT2.Value = Date.Now.Date
    End Sub

    Private Sub ReportProccess()

        gscryRpt = ReportDocumentOneParameterNumberOnly(gsReportFileName)
        CryParameterInsertValue(gscryRpt, Format(dtpDT1.Value, "yyyy-MM-dd") & " 00:00:01", "dt1")
        CryParameterInsertValue(gscryRpt, Format(dtpDT2.Value, "yyyy-MM-dd") & " 23:59:59", "dt2")

        ReportExporPDF(gscryRpt, gsReportFileName)





    End Sub
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        ReportProccess()
        GlobalPreviewReport(gsReportName)
        Me.Close()

    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        ReportProccess()
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub
End Class