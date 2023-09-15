Public Class FrmPOSKeyboard
    Public gsIsPassword As Boolean = False
    Public gsValue As String
    Public gsEnter As Boolean
    Private Sub FrmPOSKeyboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsEnter = False
        If gsIsPassword = True Then
            txtVALUE.PasswordChar = "*"
        End If

        ChkShift_CheckedChanged(sender, e)
    End Sub

    Private Sub BtnENTER_Click(sender As Object, e As EventArgs) Handles btnENTER.Click
        gsEnter = True
        Me.Close()
    End Sub
    Private Sub ChangeValue()
        txtVALUE.Text = gsValue
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsEnter = False
        Me.Close()
    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles btn1.Click
        gsValue &= DirectCast(sender, Button).Text

        ChangeValue()
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles btn2.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles btn3.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles btn4.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles btn5.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles btn6.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn7_Click(sender As Object, e As EventArgs) Handles btn7.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn8_Click(sender As Object, e As EventArgs) Handles btn8.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn9_Click(sender As Object, e As EventArgs) Handles btn9.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub Btn0_Click(sender As Object, e As EventArgs) Handles btn0.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnMinus_Click(sender As Object, e As EventArgs) Handles btnMinus.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnQ_Click(sender As Object, e As EventArgs) Handles btnQ.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnW_Click(sender As Object, e As EventArgs) Handles btnW.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnE_Click(sender As Object, e As EventArgs) Handles btnE.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnR_Click(sender As Object, e As EventArgs) Handles btnR.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnT_Click(sender As Object, e As EventArgs) Handles btnT.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnY_Click(sender As Object, e As EventArgs) Handles btnY.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnU_Click(sender As Object, e As EventArgs) Handles btnU.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnI_Click(sender As Object, e As EventArgs) Handles btnI.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnO_Click(sender As Object, e As EventArgs) Handles btnO.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnP_Click(sender As Object, e As EventArgs) Handles btnP.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnUnderScore_Click(sender As Object, e As EventArgs) Handles btnUnderScore.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnNumSign_Click(sender As Object, e As EventArgs) Handles btnNumSign.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnA_Click(sender As Object, e As EventArgs) Handles btnA.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnD_Click(sender As Object, e As EventArgs) Handles btnD.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnF_Click(sender As Object, e As EventArgs) Handles btnF.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnG_Click(sender As Object, e As EventArgs) Handles btnG.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnH_Click(sender As Object, e As EventArgs) Handles btnH.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnJ_Click(sender As Object, e As EventArgs) Handles btnJ.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnK_Click(sender As Object, e As EventArgs) Handles btnK.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnL_Click(sender As Object, e As EventArgs) Handles btnL.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnASTRISK_Click(sender As Object, e As EventArgs) Handles btnASTRISK.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnZ_Click(sender As Object, e As EventArgs) Handles btnZ.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnX_Click(sender As Object, e As EventArgs) Handles btnX.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnC_Click(sender As Object, e As EventArgs) Handles btnC.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnV_Click(sender As Object, e As EventArgs) Handles btnV.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnB_Click(sender As Object, e As EventArgs) Handles btnB.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnN_Click(sender As Object, e As EventArgs) Handles btnN.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnM_Click(sender As Object, e As EventArgs) Handles btnM.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnPoint_Click(sender As Object, e As EventArgs) Handles btnPoint.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnQoute_Click(sender As Object, e As EventArgs) Handles btnQoute.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnALT_A_Click(sender As Object, e As EventArgs) Handles btnALT_A.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnALT_G_Click(sender As Object, e As EventArgs) Handles btnALT_G.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnCLeft_Click(sender As Object, e As EventArgs) Handles btnCLeft.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnCRight_Click(sender As Object, e As EventArgs) Handles btnCRight.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnSlashLeft_Click(sender As Object, e As EventArgs) Handles btnSlashLeft.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnSlashRight_Click(sender As Object, e As EventArgs) Handles btnSlashRight.Click
        gsValue &= DirectCast(sender, Button).Text
        ChangeValue()
    End Sub

    Private Sub BtnSpaceBar_Click(sender As Object, e As EventArgs) Handles btnSpaceBar.Click
        gsValue &= " "
        ChangeValue()
    End Sub

    Private Sub Btnback_Click(sender As Object, e As EventArgs) Handles btnback.Click
        If gsValue = "" Then
            Exit Sub
        End If

        Dim L As Integer = gsValue.Length
        If L = 0 Then
            gsValue = ""
        Else
            gsValue = gsValue.ToString.Remove(L - 1)
        End If

        ChangeValue()
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