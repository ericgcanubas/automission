Public Class FrmPOSKeyboard
    Public gsIsPassword As Boolean = False
    Public gsValue As String
    Public gsEnter As Boolean
    Private Sub frmPOSKeyboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsEnter = False
        If gsIsPassword = True Then
            txtVALUE.PasswordChar = "*"
        End If

        ChkShift_CheckedChanged(sender, e)
    End Sub

    Private Sub btnENTER_Click(sender As Object, e As EventArgs) Handles btnENTER.Click
        gsEnter = True
        Me.Close()
    End Sub
    Private Sub fChangeValue()
        txtVALUE.Text = gsValue
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsEnter = False
        Me.Close()
    End Sub

    Private Sub btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        gsValue = gsValue & DirectCast(sender, Button).Text

        fChangeValue()
    End Sub

    Private Sub btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnUnderScore_Click(sender As Object, e As EventArgs) Handles btnUnderScore.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnNumSign_Click(sender As Object, e As EventArgs) Handles btnNumSign.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnASTRISK_Click(sender As Object, e As EventArgs) Handles btnASTRISK.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnPoint_Click(sender As Object, e As EventArgs) Handles btnPoint.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnQoute_Click(sender As Object, e As EventArgs) Handles btnQoute.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnALT_A_Click(sender As Object, e As EventArgs) Handles btnALT_A.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnALT_G_Click(sender As Object, e As EventArgs) Handles btnALT_G.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnCLeft_Click(sender As Object, e As EventArgs) Handles btnCLeft.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnCRight_Click(sender As Object, e As EventArgs) Handles btnCRight.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnSlashLeft_Click(sender As Object, e As EventArgs) Handles btnSlashLeft.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnSlashRight_Click(sender As Object, e As EventArgs) Handles btnSlashRight.Click
        gsValue = gsValue & DirectCast(sender, Button).Text
        fChangeValue()
    End Sub

    Private Sub btnSpaceBar_Click(sender As Object, e As EventArgs) Handles btnSpaceBar.Click
        gsValue = gsValue & " "
        fChangeValue()
    End Sub

    Private Sub btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        If gsValue = "" Then
            Exit Sub
        End If

        Dim L As Integer = gsValue.Length
        If L = 0 Then
            gsValue = ""
        Else
            gsValue = gsValue.ToString.Remove(L - 1)
        End If

        fChangeValue()
    End Sub

    Private Sub LblTITLE_Click(sender As Object, e As EventArgs) Handles lblTITLE.Click

    End Sub

    Private Sub ChkShift_CheckedChanged(sender As Object, e As EventArgs) Handles chkShift.CheckedChanged
        If chkShift.Checked = True Then
            For N As Integer = 0 To Me.Controls.Count - 1
                If Controls.Item(N).BackColor = Color.Azure Then
                    Controls.Item(N).Text = UCase(Controls.Item(N).Text)
                End If
            Next
        Else
            For N As Integer = 0 To Me.Controls.Count - 1
                If Controls.Item(N).BackColor = Color.Azure Then
                    Controls.Item(N).Text = LCase(Controls.Item(N).Text)
                End If
            Next
        End If

    End Sub
End Class