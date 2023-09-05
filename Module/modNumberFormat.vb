Module modNumberFormat



    Public Function fNumFormatNoDecimal(ByVal prValue As Double) As String
        Return Math.Floor(Val(Format(prValue, "Fixed")))
    End Function

    Public Function fNumFormatFixed(ByVal prValue As Double) As String
        Return Format(prValue, "Fixed")
    End Function
    Public Function fNumFormatStandard(ByVal prValue As Double) As String
        Return Format(prValue, "Standard")
    End Function
    Public Function fDateFormatStandard(ByVal prValue As Date) As String
        Return Format(prValue, "MM/dd/yyyy")
    End Function
    Public Function fDateFormatMYSQL(ByVal prValue As Date) As String
        Return Format(prValue, "yyyy-MM-dd")
    End Function
    Public Function fDateTimeFormatStandard(ByVal prValue As Object) As String
        Return Format(prValue, "yyyy-MM-dd HH:mm:ss")
    End Function
    Public Function fDateNowStd() As String
        Return fDateFormatStandard(Date.Now)
    End Function
    Public Function fDateNow() As String
        Return fDateFormatMYSQL(Date.Now)
    End Function
    Public Function fDateTimeNow() As String
        Return fDateTimeFormatStandard(DateTime.Now)
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
