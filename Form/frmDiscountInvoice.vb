Public Class FrmDiscountInvoice
    Public gsDISCOUNT_AMOUNT As Double = 0
    Public gsDISCOUNT_ACCOUNT_ID As String
    Public gsOK As Boolean = False
    Private Sub frmDiscount_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim sql_statement As String = "SELECT a.ID, CONCAT(a.NAME ,' / ', atm.Description)  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE "
        ComboBoxLoad(cmbDiscount_Account, sql_statement, "ID", "T")

        numAmount_of_Discount.Value = gsDISCOUNT_AMOUNT
        lblDISCOUNT.Text = Format(gsDISCOUNT_AMOUNT, "Standard")

        cmbDiscount_Account.SelectedValue = Val(gsDISCOUNT_ACCOUNT_ID)

    End Sub

    Private Sub tsCancel_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsOk_Click(sender As Object, e As EventArgs)

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
        gsDISCOUNT_AMOUNT = numAmount_of_Discount.Value
        gsDISCOUNT_ACCOUNT_ID = cmbDiscount_Account.SelectedValue
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class