Imports Tulpep.NotificationWindow
Module modNotify
    Public Const SaveMsg As String = "Successfully saved."
    Public Const DeleteMsg As String = "Successfully deleted."
    Public Const UpdateMsg As String = "Successfully updated."

    Public Sub SaveNotify(ByVal Frm As Form, ByVal IsNewEntry As Boolean)
        If IsNewEntry = True Then
            PrompNotify(Frm.Text, SaveMsg, True)
        Else
            PrompNotify(Frm.Text, UpdateMsg, True)
        End If
    End Sub
    Public Sub DeleteNotify(ByVal Frm As Form)
        PrompNotify(Frm.Text, DeleteMsg, True)

    End Sub
    Public Sub PrompNotify(ByVal prTitle As String, ByVal prConText As String, ByVal IsInfo As Boolean)
        Dim N As New PopupNotifier With {
            .TitleText = prTitle,
            .BorderColor = Color.White,
            .HeaderColor = Color.Black,
            .BodyColor = Color.Black,
            .TitleColor = Color.Yellow,
            .ContentColor = Color.White,
            .ShowOptionsButton = False,
            .ShowCloseButton = False
        }

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
