
Public Class FrmPortfolioReport
    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Trim(cmbSALES_MANAGER.Text) = "" Then
            MessageBoxInfo("Please select sales manager")
            Exit Sub
        End If
        fNowClick()
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub

    Private Sub frmPortfolioReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbSALES_MANAGER, " SELECT '%' as ID, '' as `NAME` UNION SELECT ID,`NAME` FROM contact WHERE `type`='2'", "ID", "NAME")
        dtpDate1.Value = Format(Now.Date.Year & "-01-01")

    End Sub
    Private Sub fNowClick()
        gsReportFileName = "cryPortfolio.rpt"
        gsReportName = "Portfolio Report "
        gsReportTabName = "Portfolio Report "

        gscryRpt = PublicViewReportOneParameterNumberOnly(gsReportFileName)
        CryParameterInsertValue(gscryRpt, cmbSALES_MANAGER.Text, "SALES_MANAGER_NAME")
        CryParameterInsertValue(gscryRpt, GetStringFieldValue("contact", "ID", cmbSALES_MANAGER.SelectedValue, "CUSTOM_FIELD1"), "POSITION")
        CryParameterInsertValue(gscryRpt, cmbSALES_MANAGER.SelectedValue, "sales_manager_id")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("TargetPenaltyDiscount"), "discount_id_item")
        CryParameterInsertValue(gscryRpt, dtpDate1.Value, "date1")
        CryParameterInsertValue(gscryRpt, dtpDate2.Value, "date2")

    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If Trim(cmbSALES_MANAGER.Text) = "" Then
            MessageBoxInfo("Please select sales manager")
            Exit Sub
        End If
        fNowClick()
        GlobalPreviewReport(gsReportTabName)
        Me.Close()
    End Sub
End Class