Imports System.Drawing
Module modImages
    Public Function ScreenShotNow() As Bitmap
        Dim bounds As Rectangle
        Dim ScreenShot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        ScreenShot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(ScreenShot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Return ScreenShot
    End Function
End Module
