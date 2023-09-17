Public Class FrmCashCountConfirm
    Private Sub FrmCashCountConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTOTALSALES.Text = NumberFormatStandard(gsPOS_TOTAL)
        GS_Label_Digital_M(lblTOTALSALES)

        If gsDisplayTotalSales = True Then

            lblSALES.Visible = True
            lblTOTALSALES.Visible = True

        End If

        lblTOTAL.Text = NumberFormatStandard(gsCashCOUNT_AMOUNT)
        GS_Label_Digital_M(lblTOTAL)

        GS_Label_Digital_M(lblDISAMount)

        Dim D_Amt As Double = gsCashCOUNT_AMOUNT - gsPOS_TOTAL
        lblDISAMount.Text = NumberFormatStandard(D_Amt)

        If D_Amt = 0 Then
            lblComment.Text = "No Discripancy "
        Else
            If D_Amt > 0 Then
                ' Positive
                lblComment.Text = "Over "
            Else
                'Negative
                lblComment.Text = "Short "
            End If
        End If

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class