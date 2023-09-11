Public Class FrmCreditLimit



    Private Sub DataSet()
        If cmbCONTACT.Text = "" Then
            MessageBoxInfo("Please select contact")
            Exit Sub
        End If

        gsReportFileName = "cryCreditLimitStatus.rpt"
        gsReportName = "Credit Limit Status "
        gsReportTabName = "Credit Limit Status Report"

        gscryRpt = ReportDocumentOneParameterNumberOnly(gsReportFileName)
        CryParameterInsertValue(gscryRpt, cmbCONTACT.SelectedValue, "contact_id")
        CryParameterInsertValue(gscryRpt, cmbLOCATION_ID.SelectedValue, "location_id")

        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, cmbLOCATION_ID.Text, "myremark")

    End Sub

    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        CursorLoadingOn(True)
        DataSet()
        GlobalPreviewReport(gsReportTabName)
        Me.Close()
        CursorLoadingOn(False)
    End Sub

    Private Sub FrmCreditLimit_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbCONTACT, " select '*' as `ID`,'ALL CONTACTS' as `NAME`  UNION select ID,NAME from CONTACT where `TYPE` in ('1','5','6') ", "ID", "NAME")
        cmbCONTACT.SelectedValue = "*"
        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        CursorLoadingOn(True)
        DataSet()
        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
        CursorLoadingOn(False)
    End Sub


End Class