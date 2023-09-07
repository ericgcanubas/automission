Public Class frmCashCountConfirm
    Private Sub frmCashCountConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        lblTOTALSALES.Text = NumberFormatStandard(gsPOS_TOTAL)
        fLabel_Digital_M(lblTOTALSALES)

        If gsDisplayTotalSales = True Then

            lblSALES.Visible = True
            lblTOTALSALES.Visible = True

        End If

        lblTOTAL.Text = NumberFormatStandard(gsCashCOUNT_AMOUNT)
        fLabel_Digital_M(lblTOTAL)

        fLabel_Digital_M(lblDISAMount)

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

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub
End Class