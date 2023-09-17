Imports System.Drawing.Text
Module modFont
    Public pfc As New PrivateFontCollection

    Public Sub GS_Label_Digital_L(ByVal Lbl As Label)


        Lbl.Font = New Font(pfc.Families(0), 51, FontStyle.Bold)

    End Sub

    Public Sub GS_Label_Digital_LM(ByVal Lbl As Label)


        Lbl.Font = New Font(pfc.Families(0), 38, FontStyle.Bold)

    End Sub
    Public Sub GS_Label_Digital_M(ByVal Lbl As Label)


        Lbl.Font = New Font(pfc.Families(0), 30, FontStyle.Bold)

    End Sub

    Public Sub GS_Label_Digital_S(ByVal Lbl As Label)


        Lbl.Font = New Font(pfc.Families(0), 20, FontStyle.Bold)

    End Sub
End Module
