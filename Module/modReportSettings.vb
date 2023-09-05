
Imports MySql.Data.MySqlClient
Module modReportSettings
    Public gsREPORT_ID As String
    Public gsREPORT_FILE_NAME As String
    Public gsREPORT_TITLE_NAME As String

    Public Sub fSelectDateRange(ByVal prValue As String, ByVal dtpDATE_FROM As DateTimePicker, ByVal dtpDATE_TO As DateTimePicker)
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

End Module
