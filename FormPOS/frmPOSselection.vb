Public Class frmPOSselection

    Public LastButton As Button


    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        gsPOSEntryType = 0
        Me.Close()

    End Sub




    Private Sub frmPOSselection_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' POSTypeEntry()
    End Sub

    Private Sub frmPOSselection_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        gsPublicButton.Focus()
    End Sub
End Class