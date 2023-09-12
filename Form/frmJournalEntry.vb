Public Class FrmJournalEntry
    Public tmp_dgv As DataGridView
    Public gsSave As Boolean = False
    Public gsAccount_ID As String
    Public gsDebit As Double
    Public gsCredit As Double
    Public gsNotes As String
    Public gsClass_ID As String

    Private Sub FrmJournalEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim sql_statement As String = "SELECT a.ID, a.`NAME` AS T FROM account AS a  Where a.INACTIVE ='0'  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        ComboBoxLoad(cmbAccounts, sql_statement, "ID", "T")

        ComboBoxLoad(cmbClass, "Select ID,NAME from CLASS", "ID", "NAME")
        ClearAndRefresh(Me)
        If gsAccount_ID <> "" Then
            cmbAccounts.SelectedValue = gsAccount_ID
            cmbAccounts.Enabled = False
            btnBrowse.Enabled = False

        Else
            chkAuto.Checked = True
            btnOk.Text = "&Add"
        End If

        If gsClass_ID <> "" Then
            cmbClass.SelectedValue = gsClass_ID

        End If

        numDebit.Value = gsDebit
        numCredit.Value = gsCredit
        txtNotes.Text = gsNotes


    End Sub


    Private Sub NumDebit_Enter(sender As Object, e As EventArgs) Handles numDebit.Enter
        BlueLight(numDebit)
    End Sub


    Private Sub NumDebit_Click(sender As Object, e As EventArgs) Handles numDebit.Click
        BlueLight(numDebit)
    End Sub

    Private Sub NumCredit_Click(sender As Object, e As EventArgs) Handles numCredit.Click
        BlueLight(numCredit)
    End Sub

    Private Sub NumCredit_Enter(sender As Object, e As EventArgs) Handles numCredit.Enter
        BlueLight(numCredit)
    End Sub

    Private Sub NumCredit_ValueChanged(sender As Object, e As EventArgs) Handles numCredit.ValueChanged
        If numCredit.Value <> 0 Then
            numDebit.Value = 0
        End If
    End Sub

    Private Sub NumDebit_ValueChanged(sender As Object, e As EventArgs) Handles numDebit.ValueChanged
        If numDebit.Value <> 0 Then
            numCredit.Value = 0
        End If
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        If cmbAccounts.Enabled = False Then Exit Sub

        With FrmChartOfAccount
            .gsFindMode = True
            .ShowIcon = False
            .ShowInTaskbar = False
            .StartPosition = FormStartPosition.CenterScreen
            .ShowDialog()

            If .gsFindID <> 0 Then

                cmbAccounts.SelectedValue = .gsFindID
                numDebit.Focus()
            End If
            .Dispose()

        End With
        FrmChartOfAccount = Nothing
    End Sub

    Private Sub CmbAccounts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbAccounts.SelectedIndexChanged
        ThisType.Text = GetStringFieldValueOneReturn($"SELECT atm.`DESCRIPTION` FROM account AS a INNER JOIN `account_type_map` AS atm  ON a.`TYPE` =  atm.`ID` WHERE a.`ID` ='{cmbAccounts.SelectedValue}' limit 1;")
    End Sub

    Private Sub CmbAccounts_LostFocus(sender As Object, e As EventArgs) Handles cmbAccounts.LostFocus
        cmbAccounts_SelectedIndexChanged(sender, e)
    End Sub



    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click


        If Val(cmbAccounts.SelectedValue) = 0 Then
            cmbAccounts.Focus()
            MessageBoxWarning("Account required!")
            Exit Sub
        End If

        If numDebit.Value = 0 And numCredit.Value = 0 Then
            MessageBoxWarning("Entry value required!")
            Exit Sub
        End If



        If chkAuto.Visible = True Then
            For i As Integer = 0 To tmp_dgv.Rows.Count - 1
                If tmp_dgv.Rows(i).Cells("ACCOUNT_ID").Value = cmbAccounts.SelectedValue Then
                    MessageBoxExclamation("Account is already exist!")
                    Exit Sub
                End If
            Next
        End If

        If chkAuto.Checked = False Then

            gsSave = True
            gsAccount_ID = cmbAccounts.SelectedValue
            gsDebit = numDebit.Value
            gsCredit = numCredit.Value
            gsNotes = txtNotes.Text
            gsClass_ID = cmbClass.SelectedValue
            Me.Close()

        Else
            Dim class_value As String
            If Val(cmbClass.SelectedValue) = 0 Then
                class_value = ""
            Else
                class_value = cmbClass.SelectedValue
            End If

            RowAddAccountJournal(tmp_dgv, True, cmbAccounts.SelectedValue, numDebit.Value, numCredit.Value, txtNotes.Text, class_value)
            ClearAndRefresh(Me)
            chkAuto.Checked = True
            cmbAccounts.Focus()
            btnOk.Text = "Add"
            btnOk.Refresh()
        End If
    End Sub

End Class