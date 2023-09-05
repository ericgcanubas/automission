Imports Tulpep.NotificationWindow
Module modNotify
    Public Const gsSaveStr As String = "Successfully saved."
    Public Const gsDeleteStr As String = "Successfully deleted."
    Public Const gsUpdateStr As String = "Successfully updated."

    Public Sub fSavePopUp(ByVal F As Form, ByVal bNew As Boolean)
        If bNew = True Then
            fPop_Up_Msg(F.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(F.Text, gsUpdateStr, True)
        End If
    End Sub
    Public Sub fDeletePopUp(ByVal F As Form)
        fPop_Up_Msg(F.Text, gsDeleteStr, True)

    End Sub
    Public Sub fPop_Up_Msg(ByVal prTitle As String, ByVal prConText As String, ByVal IsInfo As Boolean)

        Dim N As New PopupNotifier
        N.TitleText = prTitle


        N.BorderColor = Color.White
        N.HeaderColor = Color.Black

        N.BodyColor = Color.Black

        N.TitleColor = Color.Yellow

        N.ContentColor = Color.White

        N.ShowOptionsButton = False
        N.ShowCloseButton = False

        If IsInfo = True Then
            N.Image = My.Resources.Info_icon
        Else
            N.Image = My.Resources.warning_icon
        End If



        N.ContentFont = New Font("Verdana", 10, FontStyle.Regular)
        N.TitleFont = New Font("Verdana", 13, FontStyle.Bold)
        N.AnimationDuration = 500
        N.AnimationInterval = 500
        N.ShowGrip = False

        N.ContentText = vbNewLine & prConText
        N.Popup()
    End Sub
End Module
