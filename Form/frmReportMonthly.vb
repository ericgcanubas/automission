Imports System.DateTime
Imports System.Data.Odbc
Public Class frmReportMonthly
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
            gscryRpt = fViewReportOneParameterNumberOnly(Me.AccessibleName)
            Dim r As Double = fgetRunningTotal(Format(f, "yyyy-MM-dd"), Format(t, "yyyy-MM-dd"))
            Dim n As Integer = fgetnumberreleaseRT(r)
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, cmbYear.Text & " of " & cmbMonth.Text, "myremark")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ServiceFee"), "fixed_sf")
            fCryParameterInsertValue(gscryRpt, n, "mynum")
            fCryParameterInsertValue(gscryRpt, cmbYear.SelectedValue, "myyear")
            fCryParameterInsertValue(gscryRpt, cmbMonth.SelectedValue, "mymonth")
            fCryParameterInsertValue(gscryRpt, r, "running_total")

        Else

            Dim d As Date = New Date(Val(cmbYear.SelectedValue), cmbMonth.SelectedValue, 1)
            f = FirstDayOfMonth(d)
            t = (f.Month) & "/" & DaysInMonth(f.Year, f.Month) & "/" & (f.Year)
            gscryRpt = fViewReportOneParameterNumberOnly(Me.AccessibleName)
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, cmbYear.Text & " of " & cmbMonth.Text, "myremark")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ManagerRebites"), "rebates_percent")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ManagerGetDealerSalesTarget"), "dealer_must_get")
            fCryParameterInsertValue(gscryRpt, Format(f, "yyyy-MM-dd"), "d1")
            fCryParameterInsertValue(gscryRpt, Format(t, "yyyy-MM-dd"), "d2")


        End If
        fReportExporPDF(gscryRpt, Me.Text)
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