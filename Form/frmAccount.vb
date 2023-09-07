Imports System.Data.Odbc
Public Class FrmAccount
    Public ID As Integer
    Public IsNew As Boolean = True
    Public BS As BindingSource
    Public View As DataGridView
    Private Sub FrmAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ClearInfo()
        Me.Text = "Create account"
        If IsNew = False Then
            Me.Text = "Update account"
            SqlExecutedUsingReading(Me, "select * from account where ID = '" & ID & "' Limit 1")
        End If


    End Sub
    Private Sub ClearInfo()
        ComboBoxLoad(cmbTYPE, "select ID,DESCRIPTION from account_type_map ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbGROUP_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
        txtNAME.Text = ""
        chkINACTIVE.Checked = False
    End Sub


    Private Sub AccountUpdateDgv()
        Dim xSQL As String
        xSQL = $"SELECT a.`ID`,a.`Name`,atm.`DESCRIPTION` AS `Type`,a.`BANK_ACCOUNT_NO` as `Bank Account No.`,a.`LINE_NO` as `Line No.`,IFNULL(ag.`NAME`,'') AS `Group of Accounts`, if(a.`Inactive`=0,'No','Yes') as `Inactive` FROM  account a LEFT OUTER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` LEFT OUTER JOIN account AS ag ON ag.`ID` = a.`GROUP_ACCOUNT_ID`  where  a.ID = '{ID}' Order by a.`ID`"
        BindingViewUpdate(View, xSQL, IsNew, BS)

    End Sub

    Private Sub Save_Click(sender As Object, e As EventArgs) Handles Save.Click
        If cmbTYPE.SelectedIndex = -1 Then
            MessageBoxInfo("Please select account type")
            Exit Sub
        End If

        If txtNAME.Text.Length = 0 Then
            MessageBoxInfo("Please enter account name")
            Exit Sub
        End If

        If IsNew = True Then
            Try
                Dim rd As OdbcDataReader = SqlReader("select * from account WHERE NAME = '" & TextIsNull(txtNAME.Text) & "' limit 1;")
                If rd.Read Then
                    rd.Close()
                    MessageBoxWarning("Account name is already exist!")
                    Exit Sub
                End If
                rd.Close()
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
                Exit Sub
            End Try

            Dim i As Integer = GetMaxFieldLine("`LINE_NO`", "ACCOUNT", "`TYPE`", cmbTYPE.SelectedValue)
            ID = ObjectTypeMapId("ACCOUNT")

            SqlCreate(Me, SQL_FIELD, SQL_VALUE)
            SqlExecuted($"INSERT INTO account ({SQL_FIELD},ID,LINE_NO) VALUES( {SQL_VALUE},{ID},{i})")
            ClearInfo()
            PrompNotify(Me.Text, SaveMsg, True)

        Else
            Dim SQL As String = SqlUpdate(Me)
            SqlExecuted($"UPDATE account SET {SQL} WHERE ID = '{ID}' limit 1")
            ClearInfo()
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        AccountUpdateDgv()
        IsNew = True
        ID = 0
        Me.Text = "Create account"

        If fACCESS_NEW_EDIT(frmChartOfAccount, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Click(sender As Object, e As EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub
End Class