Public Class FrmAddExpenses

    Public sFormName As String = ""


    Public gsAccount_ID As String
    Public gsClass_ID As String
    Public gsAmount As Double = 0
    Public gsTax As Boolean = False
    Public gsParticular As String = ""
    Public gsSave As Boolean = False
    Public gsDGV As DataGridView
    Public gsNew As Boolean = False




    Private Sub FrmAddExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sql_statement As String = "SELECT a.ID, a.`NAME` AS T FROM account AS a  Where a.INACTIVE ='0'  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        GS_ComboBoxLoad(cmbAccounts, sql_statement, "ID", "T")
        GS_ComboBoxLoad(cmbClass, "Select ID,NAME from CLASS", "ID", "NAME")
        If gsAccount_ID <> "" Then
            cmbAccounts.SelectedValue = gsAccount_ID
            cmbAccounts.Enabled = False
            btnBrowse.Enabled = False

        End If

        If gsClass_ID <> "" Then
            cmbClass.SelectedValue = gsClass_ID
        End If

        numAmount.Value = gsAmount
        chkTax.Checked = gsTax
        rtbParticular.Text = gsParticular
    End Sub
    Private Sub CmbAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccounts.SelectedIndexChanged
        ThisType.Text = GF_GetStringFieldValueOneReturn($"SELECT atm.`DESCRIPTION` FROM account AS a INNER JOIN `account_type_map` AS atm  ON a.`TYPE` =  atm.`ID` WHERE a.`ID` ='{cmbAccounts.SelectedValue}' limit 1;")
    End Sub

    Private Sub CmbAccounts_Leave(sender As Object, e As EventArgs) Handles cmbAccounts.Leave
        If Trim(cmbAccounts.Text) <> "" Then
            numAmount.Focus()
            BlueLight(numAmount)
        End If
    End Sub

    Private Sub NumAmount_GotFocus(sender As Object, e As EventArgs) Handles numAmount.GotFocus
        BlueLight(numAmount)
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs)
        If cmbAccounts.Enabled = False Then Exit Sub
        With FrmChartOfAccount
            .gsFindMode = True
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

            If .gsFindID <> 0 Then
                cmbAccounts.SelectedValue = .gsFindID
                numAmount.Focus()
            End If
            .Dispose()

        End With
        FrmChartOfAccount = Nothing

    End Sub



    Private Sub CmbAccounts_LostFocus(sender As Object, e As EventArgs) Handles cmbAccounts.LostFocus
        CmbAccounts_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Trim(cmbAccounts.Text) = "" Then
            MessageBoxInfo("Please select account")
            Exit Sub
        End If
        gsSave = True
        gsAccount_ID = cmbAccounts.SelectedValue
        gsAmount = numAmount.Value
        gsTax = chkTax.Checked
        gsParticular = rtbParticular.Text.ToString.Replace("'", "`")
        gsClass_ID = cmbClass.SelectedValue
        If gsNew = True Then
            If gsSave = True Then
                GS_AddRowDataExpenses(gsDGV, True, gsAccount_ID, gsAmount, gsTax, gsParticular, gsClass_ID, "A")
                ClearAndRefresh(Me)
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub FrmAddExpenses_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If gsNew = True Then
            btnOK.Text = "&Add"
        Else
            btnOK.Text = "&Save"
        End If
    End Sub
End Class