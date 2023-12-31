﻿Public Class FrmStatement
    Private Sub FrmStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DataRangeLoad()
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select * from contact where type='1'", "ID", "NAME")
        RefreshLocation()
    End Sub
    Private Sub DataRangeLoad()
        With cmbDateRange.Items
            .Add("Today")
            .Add("Yesterday")
            .Add("Last 7 Days")
            .Add("Last 30 Days")
            .Add("This Month")
            .Add("Last Month")
            .Add("This Year")
            .Add("Last Year")
            .Add("All Time")
            .Add("Custom Range")

        End With
        cmbDateRange.SelectedIndex = 4
    End Sub
    Private Sub SelectDateRange(ByVal prValue As String)
        Dim f As Date = Date.Now.Date
        Dim t As Date = Date.Now.Date
        Select Case prValue
            Case "Today"
                f = Date.Now.Date
                t = Date.Now.Date
            Case "Yesterday"
                f = Now.AddDays(-1)
                t = Now.AddDays(-1)
            Case "Last 7 Days"
                f = Now.AddDays(-7)
                t = Now.Date.Date
            Case "Last 30 Days"
                f = Now.AddDays(-30)
                t = Now.Date.Date
            Case "This Month"
                f = FirstDayOfMonth(Date.Now.Date)
                t = (f.Month) & "/" & System.DateTime.DaysInMonth(f.Year, f.Month) & "/" & (f.Year)
            Case "Last Month"
                f = FirstDayOfMonth(Date.Now.Date)
                f = f.AddMonths(-1)
                t = LastDayOfMonth(f)
            Case "This Year"
                f = "1/1/" & (Now.Year)
                t = "12/31/" & (Now.Year)
            Case "Last Year"
                f = "1/1/" & (Now.Year - 1)
                t = "12/31/" & (Now.Year - 1)
            Case "All Time"
                f = Date.Now.Date
                t = Date.Now.Date
            Case "Custom Range"
                dtpDATE_FROM.Checked = False
                dtpDATE_TO.Checked = False
        End Select

        dtpDATE_FROM.Value = f
        dtpDATE_TO.Value = t
    End Sub

    Private Sub RefreshLocation()

        GS_ComboBoxLoad(cmbLOCATION_ID, "SELECT  '*' AS `id`,'All Location' as `name`  UNION SELECT  `id`,`name` FROM location ", "ID", "NAME")
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID

    End Sub

    Private Sub CmbDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDateRange.SelectedIndexChanged
        SelectDateRange(cmbDateRange.Text)
    End Sub

    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub
    Private Sub ReportProcess()
        gscryRpt = ReportDocumentOneParameterNumberOnly("cryStandardStatement.rpt")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, cmbCUSTOMER_ID.SelectedValue, "customerid")
        CryParameterInsertValue(gscryRpt, IIf(cmbLOCATION_ID.SelectedValue = "*", "%", cmbLOCATION_ID.SelectedValue), "locationid")
        CryParameterInsertValue(gscryRpt, dtpDateStatement.Value, "myremark")
        CryParameterInsertValue(gscryRpt, dtpDateStatement.Value, "select_date")
        CryParameterInsertValue(gscryRpt, dtpDATE_FROM.Value, "select_date1")
        CryParameterInsertValue(gscryRpt, dtpDATE_TO.Value, "select_date2")
        CryParameterInsertValue(gscryRpt, Format(dtpDATE_FROM.Value, "MMMM dd") & " thought " & Format(dtpDATE_TO.Value, "MMMM dd, yyyy"), "date_remark")

    End Sub
    Private Sub TsPreview_Click(sender As Object, e As EventArgs) Handles tsPreview.Click
        If cmbCUSTOMER_ID.SelectedValue Is Nothing Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If
        ReportProcess()
        gsToolPanelView = False
        GlobalPreviewReport("Statement Report")
    End Sub

    Private Sub TsPrint_Click(sender As Object, e As EventArgs) Handles tsPrint.Click
        If cmbCUSTOMER_ID.SelectedValue Is Nothing Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If
        ReportProcess()
        gscryRpt.PrintToPrinter(1, False, 0, 0)
    End Sub
End Class