Public Class frmCreditLimit



    Private Sub fData()
        If cmbCONTACT.Text = "" Then
            MessageBoxInfo("Please select contact")
            Exit Sub
        End If

        gsReportFileName = "cryCreditLimitStatus.rpt"
        gsReportName = "Credit Limit Status "
        gsReportTabName = "Credit Limit Status Report"

        gscryRpt = fViewReportOneParameterNumberOnly(gsReportFileName)
        fCryParameterInsertValue(gscryRpt, cmbCONTACT.SelectedValue, "contact_id")
        fCryParameterInsertValue(gscryRpt, cmbLOCATION_ID.SelectedValue, "location_id")

        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
        fCryParameterInsertValue(gscryRpt, cmbLOCATION_ID.Text, "myremark")

    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        CursorLoadingOn(True)
        fData()
        fPreviewReport(gsReportTabName)
        Me.Close()
        CursorLoadingOn(False)
    End Sub

    Private Sub frmCreditLimit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbCONTACT, " select '*' as `ID`,'ALL CONTACTS' as `NAME`  UNION select ID,NAME from CONTACT where `TYPE` in ('1','5','6') ", "ID", "NAME")
        cmbCONTACT.SelectedValue = "*"
        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        CursorLoadingOn(True)
        fData()
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
        CursorLoadingOn(False)
    End Sub


End Class