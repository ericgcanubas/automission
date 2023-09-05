Module modColor
    Dim gsGBottomLeft As Color = Color.White
    Dim gsGBottomRight As Color = Color.MidnightBlue
    Dim gsGTopLeft As Color = Color.LightCyan
    Dim gsGTopRight As Color = Color.LightBlue

    Public Sub fBPanel(ByVal G As Bunifu.Framework.UI.BunifuGradientPanel)
        G.GradientBottomLeft = gsGBottomLeft
        G.GradientBottomRight = gsGBottomRight
        G.GradientTopLeft = gsGTopLeft
        G.GradientTopRight = gsGTopRight


    End Sub
End Module
