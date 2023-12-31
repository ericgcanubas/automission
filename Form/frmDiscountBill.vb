﻿Public Class FrmDiscountBill
    Public gsDISCOUNT_AMOUNT As Double = 0
    Public gsDISCOUNT_ACCOUNT_ID As String
    Public gsDISCOUNT_DATE As Date
    Public gsOK As Boolean = False
    Private Sub FrmDiscountBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sql_statement As String = "SELECT a.ID, a.NAME AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  where a.TYPE ='11' "
        GS_ComboBoxLoad(cmbDiscount_Account, sql_statement, "ID", "T")
        numAmount_of_Discount.Value = gsDISCOUNT_AMOUNT
        lblDISCOUNT.Text = Format(gsDISCOUNT_AMOUNT, "Standard")
        cmbDiscount_Account.SelectedValue = Val(gsDISCOUNT_ACCOUNT_ID)

    End Sub
    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If numAmount_of_Discount.Value = 0 Then
            MessageBoxInfo("Please enter discount amount")
            numAmount_of_Discount.Focus()
            Exit Sub
        End If

        If Val(cmbDiscount_Account.SelectedValue) = 0 Then
            MessageBoxInfo("Please select discount account")
            Exit Sub
        End If

        gsOK = True
        gsDISCOUNT_DATE = dtpDISCOUNT_DATE.Value
        gsDISCOUNT_AMOUNT = numAmount_of_Discount.Value
        gsDISCOUNT_ACCOUNT_ID = cmbDiscount_Account.SelectedValue
        Me.Close()
    End Sub
End Class