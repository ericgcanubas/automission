Public Class FrmPOSselection

    Public LastButton As Button
    Private Sub BtnExit_Click(sender As Object, e As EventArgs)
        gsPOSEntryType = 0
        Me.Close()

    End Sub
    Private Sub FrmPOSselection_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' POSTypeEntry()
    End Sub

    Private Sub FrmPOSselection_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        gsPublicButton.Focus()
    End Sub
End Class