Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Configuration
Module modEmail
    Public Sub Gmail(ByVal SUBJECT As String, ByVal BODY As String, ByVal EMAIL As String)
        If gsGmailUsername = "" Then Exit Sub
        If gsGmailPassword = "" Then Exit Sub
        '   If gsGmailAddressTo = "" Then Exit Sub

        ' If gsAdmin_User = True Then Exit Sub

        Try

            Using mm As New MailMessage($"{gsGmailUsername}@gmail.com", EMAIL)
                mm.Subject = SUBJECT
                mm.Body = BODY
                mm.IsBodyHtml = False
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential($"{gsGmailUsername}@gmail.com", gsGmailPassword)
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = Integer.Parse(587)

                smtp.Send(mm)
                '  System.Threading.Thread.Sleep(3000)
            End Using
        Catch ex As Exception
            If gsAdmin_User = True Then
                MessageBoxWarning(ex.Message)
            End If
        End Try



    End Sub

    Public Sub Gmail_ScreenShoot(ByVal SUBJECT As String, ByVal EMAIL As String, ByVal ErrorMsg As String)
        If gsGmailUsername = "" Then Exit Sub
        If gsGmailPassword = "" Then Exit Sub
        If gsGmailAddressTo = "" Then Exit Sub





        ' If gsAdmin_User = True Then Exit Sub

        Try
            'BYTES ARRAY OF IMAGE SO WE CAN PUT IN MEMORY STREAM
            Dim myImageData() As Byte = Nothing
            'GRAB IMAGE FROM FILE AND PUT IN MEMORY STREAM
            Dim bmp As System.Drawing.Bitmap = ScreenShotNow()
            Dim file_name As String = $"{Application.StartupPath}\image\{gsUser_Name}-desktop-screen-shoot.Jpg"
            bmp.Save(file_name, System.Drawing.Imaging.ImageFormat.Jpeg)
            Using myImage = Image.FromFile(file_name)
                Dim IC As New ImageConverter
                myImageData = DirectCast(IC.ConvertTo(myImage, GetType(Byte())), Byte())
            End Using

            Using mm As New MailMessage($"{gsGmailUsername}@gmail.com", EMAIL)
                mm.Subject = SUBJECT
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient()
                smtp.Host = "smtp.gmail.com"
                smtp.EnableSsl = True
                Dim NetworkCred As New NetworkCredential($"{gsGmailUsername}@gmail.com", gsGmailPassword)
                smtp.UseDefaultCredentials = True
                smtp.Credentials = NetworkCred
                smtp.Port = Integer.Parse(587)
                mm.Body = "<html><body>" &
            $"<p>Username:{gsUser_Name} | DateTime:{GetDateTimeNowSql()} | On {IIf(gsPOS_Mode = True, "POS", "BMS")}.</p>" &
            $"<p>Error Message: {ErrorMsg}</p>" &
            "<p>Hi 👋, This file is capture from BMS system</p>" &
            "<p>This message was created and sent with:</p>" &
            "<p><img src='cid:dc'/></p>" &
            "<p>Read more about it on <a href='https://www.facebook.com/ericgcanubas/'>Please message on ERIC G. Canubas</a> page.</p>" &
            "</body></html>"

                mm.Attachments.Add(New Attachment(file_name) With {.ContentId = "dc"})
                smtp.Send(mm)
                System.Threading.Thread.Sleep(3000)
            End Using
        Catch ex As Exception
            If gsAdmin_User = True Then
                MessageBoxWarning(ex.Message)
            End If


        End Try
    End Sub

End Module
