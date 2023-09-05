Module modSkin
    Public gsThemeNo As Integer = 0
    Public Function SkinPath() As String
        Dim path As String = AppDomain.CurrentDomain.BaseDirectory
        Return path & "sf\Skins\"
    End Function
    Public Sub fMaterialSkin(ByVal F As Form)
        Exit Sub
        'Dim skinManager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance
        'skinManager.AddFormToManage(F)
        'skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT
        'Select Case gsThemeNo
        '    Case 0 ' Default
        '        skinManager.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Blue900, MaterialSkin.Primary.Blue700, MaterialSkin.Primary.Blue900, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE)

        '    Case 1 'BlueGrey
        '        skinManager.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.BlueGrey900, MaterialSkin.Primary.BlueGrey700, MaterialSkin.Primary.BlueGrey900, MaterialSkin.Accent.LightBlue200, MaterialSkin.TextShade.WHITE)

        '    Case 2 'Orange
        '        skinManager.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Orange900, MaterialSkin.Primary.Orange700, MaterialSkin.Primary.Orange900, MaterialSkin.Accent.DeepOrange200, MaterialSkin.TextShade.WHITE)

        '    Case 3 'Yellow
        '        skinManager.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Yellow900, MaterialSkin.Primary.Yellow700, MaterialSkin.Primary.Yellow900, MaterialSkin.Accent.Amber200, MaterialSkin.TextShade.WHITE)

        '    Case 4 'Green
        '        skinManager.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Green900, MaterialSkin.Primary.Green700, MaterialSkin.Primary.Green900, MaterialSkin.Accent.LightGreen200, MaterialSkin.TextShade.WHITE)

        '    Case 5 'Pink
        '        skinManager.ColorScheme = New MaterialSkin.ColorScheme(MaterialSkin.Primary.Pink900, MaterialSkin.Primary.Pink700, MaterialSkin.Primary.Pink900, MaterialSkin.Accent.Purple200, MaterialSkin.TextShade.WHITE)

        'End Select


    End Sub
    Public Sub fMaterialSkin_Yellow(ByVal F As Form)
        'Dim skinManager As MaterialSkin.MaterialSkinManager = MaterialSkin.MaterialSkinManager.Instance
        'skinManager.AddFormToManage(F)
        'skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT


    End Sub
End Module
