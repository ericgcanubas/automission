Public Class frmPOSStartingCash
    Public gsStartAmount As Double
    Private Sub frmPOSStartingCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' fMaterialSkin(Me)
        numAMOUNT.Value = 0
        gsStartAmount = 0

    End Sub
    Private Sub BtnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click
        gsStartAmount = numAMOUNT.Value
        Me.Close()
    End Sub
    Private Sub numAMOUNT_KeyDown(sender As Object, e As KeyEventArgs) Handles numAMOUNT.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

    Private Sub frmPOSStartingCash_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If numAMOUNT.Value <= 0 Then
            If MessageBoxPointOfSalesYesNO("Are you sure no petty cash?") = False Then
                e.Cancel = True
            End If
        End If

    End Sub
End Class