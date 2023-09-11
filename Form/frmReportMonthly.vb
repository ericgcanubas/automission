Imports System.DateTime
Imports System.Data.Odbc
Public Class FrmReportMonthly
    Dim f As Date
    Dim t As Date
    Private Sub frmDepotSalesAcheivementReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AccessibleName = gsReportFileName
        Me.Text = gsReportName
        YearlyComboBoxLoad(cmbYear)
        MonthlyComboBoxLoad(cmbMonth)


    End Sub
    Private Function fgetnumberreleaseRT(ByVal running_total As Double) As Integer
        Dim i As Integer = 0
        Dim v As Integer = 0
        Dim g As Double
        '   Dim cn As New MySqlConnection(mysqlConstr)
        Try
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader("select sales_target, service_fee_pct from service_fee where  sales_target > '0'   order by sales_target")
            While rd.Read
                i = i + 1
                If NumIsNull(rd("sales_target")) >= running_total Then

                    If g = 0 Then

                        g = running_total
                        v = i - 1
                        Exit While
                    End If
                End If
            End While

            rd.Close()
        Catch ex As Exception

            MessageBoxWarning(ex.Message)
        End Try
        Return v
    End Function


    Private Sub fReportProccess()
        If gsReportFileName = "cryInHouseDeportServiceFee.rpt" Then
            Dim d As Date = New Date(Val(cmbYear.SelectedValue), cmbMonth.SelectedValue, 1)
            f = FirstDayOfMonth(d)
            t = (f.Month) & "/" & DaysInMonth(f.Year, f.Month) & "/" & (f.Year)
            gscryRpt = ReportDocumentOneParameterNumberOnly(Me.AccessibleName)
            Dim r As Double = fgetRunningTotal(Format(f, "yyyy-MM-dd"), Format(t, "yyyy-MM-dd"))
            Dim n As Integer = fgetnumberreleaseRT(r)
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, cmbYear.Text & " of " & cmbMonth.Text, "myremark")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ServiceFee"), "fixed_sf")
            CryParameterInsertValue(gscryRpt, n, "mynum")
            CryParameterInsertValue(gscryRpt, cmbYear.SelectedValue, "myyear")
            CryParameterInsertValue(gscryRpt, cmbMonth.SelectedValue, "mymonth")
            CryParameterInsertValue(gscryRpt, r, "running_total")

        Else

            Dim d As Date = New Date(Val(cmbYear.SelectedValue), cmbMonth.SelectedValue, 1)
            f = FirstDayOfMonth(d)
            t = (f.Month) & "/" & DaysInMonth(f.Year, f.Month) & "/" & (f.Year)
            gscryRpt = ReportDocumentOneParameterNumberOnly(Me.AccessibleName)
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, cmbYear.Text & " of " & cmbMonth.Text, "myremark")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ManagerRebites"), "rebates_percent")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ManagerGetDealerSalesTarget"), "dealer_must_get")
            CryParameterInsertValue(gscryRpt, Format(f, "yyyy-MM-dd"), "d1")
            CryParameterInsertValue(gscryRpt, Format(t, "yyyy-MM-dd"), "d2")


        End If
        ReportExporPDF(gscryRpt, Me.Text)
    End Sub
    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click


        fReportProccess()

        GlobalPreviewReport(gsReportName)
        Me.Close()

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

        fReportProccess()

        gscryRpt.PrintToPrinter(1, False, 0, 0)
        Me.Close()
    End Sub
End Class