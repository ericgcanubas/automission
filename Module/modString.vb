Module modString
    Public Function GF_TitleCase(ByVal MyString As String) As String
        Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(MyString.ToLower)
    End Function
    Public Function GF_RemoveDigits(ByVal S As String) As String
        Return System.Text.RegularExpressions.Regex.Replace(S, "\d", "")
    End Function
End Module
