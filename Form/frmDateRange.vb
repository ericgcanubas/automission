Public Class frmDateRange
    Private Sub frmDateRange_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = gsReportName
        fBackGroundImageStyle(Me)
        dtpDT1.Value = Date.Now.Date
        dtpDT2.Value = Date.Now.Date
    End Sub

    Private Sub fReportProccess()

        gscryRpt = fViewReportOneParameterNumberOnly(gsReportFileName)
        fCryParameterInsertValue(gscryRpt, Format(dtpDT1.Value, "yyyy-MM-dd") & " 00:00:01", "dt1")
        fCryParameterInsertValue(gscryRpt, Format(dtpDT2.Value, "yyyy-MM-dd") & " 23:59:59", "dt2")

        fReportExporPDF(gscryRpt, gsReportTabName)
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        fReportProccess()
        fPreviewReport(gsReportName)
        Me.Close()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        fReportProccess()
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub
End Class