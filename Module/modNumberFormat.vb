Module modNumberFormat
    Public Function NumberFormatNoDecimal(ByVal prValue As Double) As String
        Return Math.Floor(Val(Format(prValue, "Fixed")))
    End Function

    Public Function NumberFormatFixed(ByVal prValue As Double) As String
        Return Format(prValue, "Fixed")
    End Function
    Public Function NumberFormatStandard(ByVal prValue As Double) As String
        Return Format(prValue, "Standard")
    End Function
    Public Function DateFormatStandard(ByVal prValue As Date) As String
        Return Format(prValue, "MM/dd/yyyy")
    End Function
    Public Function DateFormatMySql(ByVal prValue As Date) As String
        Return Format(prValue, "yyyy-MM-dd")
    End Function
    Public Function DateTimeFormatMySql(ByVal prValue As Object) As String
        Return Format(prValue, "yyyy-MM-dd HH:mm:ss")
    End Function
    Public Function GetDateNowStd() As String
        Return DateFormatStandard(Date.Now)
    End Function
    Public Function GetDateNow() As String
        Return DateFormatMySql(Date.Now)
    End Function
    Public Function GetDateTimeNowSql() As String
        Return DateTimeFormatMySql(DateTime.Now)
    End Function
    Public Function GetIPv4Address() As String
        GetIPv4Address = String.Empty
        Dim strHostName As String = System.Net.Dns.GetHostName()
        Dim iphe As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(strHostName)

        For Each ipheal As System.Net.IPAddress In iphe.AddressList
            If ipheal.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                GetIPv4Address = ipheal.ToString()
            End If
        Next
    End Function
End Module
