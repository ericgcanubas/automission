Module modColor
    ReadOnly gsGBottomLeft As Color = Color.White
    ReadOnly gsGBottomRight As Color = Color.MidnightBlue
    ReadOnly gsGTopLeft As Color = Color.LightCyan
    ReadOnly gsGTopRight As Color = Color.LightBlue

    Public Sub GS_BunifuGradietPanel(ByVal G As Bunifu.Framework.UI.BunifuGradientPanel)
        G.GradientBottomLeft = gsGBottomLeft
        G.GradientBottomRight = gsGBottomRight
        G.GradientTopLeft = gsGTopLeft
        G.GradientTopRight = gsGTopRight


    End Sub
End Module
