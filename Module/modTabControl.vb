Module modTabControl
    Public Sub fTabStyle(ByVal sender As Object, ByVal e As DrawItemEventArgs, ByVal t As Windows.Forms.TabControl)
        Dim c As Color = ColorTranslator.FromHtml(gsColor_Code)
        Dim CurrentTab As TabPage = t.TabPages(e.Index)
        ' Dim ItemRect As Rectangle = TabControl1.GetTabRect(e.Index)

        Dim ItemRect As Rectangle = New Rectangle(e.Bounds.X, e.Bounds.Y + 4, e.Bounds.Width + 6, e.Bounds.Height - 8)
        Dim TextoColor As New Color
        Dim BotonColorFondo As New Color
        BotonColorFondo = Color.DarkSlateBlue
        TextoColor = Color.Black 'Color.FromArgb(217, 215, 141)
        Dim FillBrush As New SolidBrush(BotonColorFondo)
        Dim FillBruchBG As New SolidBrush(c)
        Dim TextBrush As New SolidBrush(TextoColor)
        Dim TextBrushSelect As New SolidBrush(c)
        Dim sf As New StringFormat
        sf.Alignment = StringAlignment.Center
        sf.LineAlignment = StringAlignment.Center

        ItemRect.Inflate(3, 3)

        'Splash paint over whole control
        e.Graphics.FillRectangle(FillBruchBG, t.ClientRectangle)
        For i As Integer = 0 To t.TabPages.Count - 1

            t.TabPages(i).BorderStyle = BorderStyle.None
            t.TabPages(i).BackColor = c

            ItemRect = t.GetTabRect(i)
            'Next we'll paint the TabItem with our Fill Brush
            'Now draw the text.
            Dim f As Font
            If t.SelectedTab.Text = t.TabPages(i).Text Then
                f = New Font(e.Font, FontStyle.Bold)
            Else
                f = e.Font
            End If

            e.Graphics.FillRectangle(FillBruchBG, ItemRect)
            e.Graphics.DrawString(t.TabPages(i).Text, f, TextBrush, RectangleF.op_Implicit(ItemRect), sf)
            ControlPaint.DrawBorder3D(e.Graphics, ItemRect, Border3DStyle.Flat, Border3DSide.Right)

            'Reset any Graphics rotation
            e.Graphics.ResetTransform()

        Next

        FillBrush.Dispose()
        TextBrush.Dispose()
    End Sub

End Module
