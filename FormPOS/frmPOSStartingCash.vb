﻿Public Class FrmPOSStartingCash
    Public gsStartAmount As Double
    Private Sub FrmPOSStartingCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        numAMOUNT.Value = 0
        gsStartAmount = 0

    End Sub
    Private Sub BtnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click
        gsStartAmount = numAMOUNT.Value
        Me.Close()
    End Sub
    Private Sub NumAMOUNT_KeyDown(sender As Object, e As KeyEventArgs) Handles numAMOUNT.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.Select()
        End If
    End Sub

    Private Sub FrmPOSStartingCash_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If numAMOUNT.Value <= 0 Then
            If MessageBoxPointOfSalesYesNO("Are you sure no petty cash?") = False Then
                e.Cancel = True
            End If
        End If

    End Sub
End Class