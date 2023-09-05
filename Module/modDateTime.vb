Module modDateTime
    'Get the first day of the month
    Public Function FirstDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Return New DateTime(sourceDate.Year, sourceDate.Month, 1)

    End Function

    'Get the last day of the month
    Public Function LastDayOfMonth(ByVal sourceDate As DateTime) As DateTime
        Dim lastDay As Date
        Try
            lastDay = New DateTime(sourceDate.Year, sourceDate.Month + 1, 1)
            Return lastDay.AddDays(-1)
        Catch ex As Exception
            ' fMessageboxError(ex)
            Return New DateTime(sourceDate.Year, sourceDate.Month, 31)

        End Try

    End Function
    Public Function fDataRangeLoad(ByVal prName As String) As ComboBox
        Dim cmb As ComboBox = New ComboBox
        cmb.Name = prName
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        With cmb.Items
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
        cmb.SelectedIndex = 0
        Return cmb
    End Function
End Module
