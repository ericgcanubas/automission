Imports System.Data.Odbc
Module modStyle
    Public gsColor_Code As String = SystemColors.ControlLight.ToArgb
    Public gsPath_Banner As String = ""
    Public gsPath_Background As String = ""
    Public gsPath_left As String = ""

    Public Sub fThemeLoad()
        gsImageBackground = Nothing
        gsImageNameApp = Nothing
        gsLeftApp = Nothing
        gsColor_Code = SystemColors.ControlLight.ToArgb
        gsPath_Banner = ""
        gsPath_Background = ""
        gsPath_left = ""

        Try
            gsImageBackground = Image.FromFile(Application.StartupPath & "\image\toolbar\" & gsPath_Banner)
            gsImageNameApp = Image.FromFile(Application.StartupPath & "\image\toolbar\" & gsPath_Background)
            gsLeftApp = Image.FromFile(Application.StartupPath & "\image\toolbar\" & gsPath_left)
        Catch ex As Exception

        End Try





        Try



            Dim rd As OdbcDataReader = fReader("select * from theme where active = '1'  limit 1 ")
            If rd.Read Then
                gsColor_Code = rd("color_code")
                gsPath_Banner = rd("banner")
                gsPath_left = rd("left_banner")
                gsPath_Background = rd("background")

                gsImageBackground = Image.FromFile(Application.StartupPath & "\image\toolbar\" & gsPath_Banner)
                gsImageNameApp = Image.FromFile(Application.StartupPath & "\image\toolbar\" & gsPath_Background)
                gsLeftApp = Image.FromFile(Application.StartupPath & "\image\toolbar\" & gsPath_left)

            End If
            rd.Close()

        Catch ex As Exception

            fMessageboxWarning(ex.Message)
        End Try

    End Sub



End Module
