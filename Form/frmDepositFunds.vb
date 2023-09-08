Public Class FrmDepositFunds
    Public gsDGV As DataGridView
    Public gsSave As Boolean = False

    Public gsReceivedFrom_ID As String = ""
    Public gsAccount_ID As String = ""
    Public gsPayment_Method_ID As String = ""
    Public gsCheck_NO As String = ""
    Public gsAmount As Double = 0



    Private Sub frmDepositFunds_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbReceivedFrom, "SELECT c.`ID`, CONCAT(c.`NAME`,' / ',ctm.`DESCRIPTION` ) AS `PAY_TO` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE c.`INACTIVE` ='0' ORDER BY c.`TYPE`", "ID", "PAY_TO")
        Dim sql_statement As String = "SELECT a.ID, CONCAT(a.NAME ,' / ', atm.Description)  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        ComboBoxLoad(cmbAccounts, sql_statement, "ID", "T")
        ComboBoxLoad(cmbPAYMENT_METHOD_ID, "select ID,DESCRIPTION from PAYMENT_METHOD", "ID", "DESCRIPTION")



        If gsReceivedFrom_ID <> "" Then
            cmbReceivedFrom.SelectedValue = gsReceivedFrom_ID

        End If

        If gsAccount_ID <> "" Then
            cmbAccounts.SelectedValue = gsAccount_ID
        End If

        If gsPayment_Method_ID <> "" Then
            cmbPAYMENT_METHOD_ID.SelectedValue = gsPayment_Method_ID
        End If



        txtCheckNo.Text = gsCheck_NO
        numAmount.Value = gsAmount




    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        'If Val(cmbReceivedFrom.SelectedValue) = 0 Then
        '    MessageBoxWarning("Please select received from ")
        '    Exit Sub
        'End If

        If Val(cmbAccounts.SelectedValue) = 0 Then
            MessageBoxWarning("Please select accounts")
            Exit Sub
        End If

        If numAmount.Value = 0 Then
            MessageBoxWarning("Please enter amount")
            Exit Sub
        End If

        If chkAuto.Checked = False Then
            gsSave = True


            gsReceivedFrom_ID = cmbReceivedFrom.SelectedValue
            gsAccount_ID = cmbAccounts.SelectedValue
            gsPayment_Method_ID = cmbPAYMENT_METHOD_ID.SelectedValue
            gsCheck_NO = txtCheckNo.Text
            gsAmount = numAmount.Value

            Me.Close()
        Else
            gsSave = False

            gsReceivedFrom_ID = cmbReceivedFrom.SelectedValue
            gsAccount_ID = cmbAccounts.SelectedValue
            gsPayment_Method_ID = cmbPAYMENT_METHOD_ID.SelectedValue
            gsCheck_NO = txtCheckNo.Text
            gsAmount = numAmount.Value

            fAdd_Deposit_fund(gsDGV, True, gsReceivedFrom_ID, gsAccount_ID, gsPayment_Method_ID, gsCheck_NO, gsAmount)

            ClearAndRefresh(Me)
            cmbReceivedFrom.Focus()
            chkAuto.Checked = True
        End If
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs)

    End Sub
End Class