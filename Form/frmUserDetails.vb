Imports System.Data.Odbc
Public Class FrmUserDetails
    Public ID As Integer
    Public IsNew As Boolean
    Public gsDgv As DataGridView
    Public gsBS As BindingSource
    Private Sub FrmUserDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbSTATUS, "select * from user_status_map", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbCONTACT_ID, "select * from contact where type ='2' and inactive ='0'", "ID", "NAME")
        ComboBoxLoad(cmbTYPE, "select * from USER_TYPE_MAP ", "ID", "DESCRIPTION")
        If IsNew = False Then
            SqlExecutedUsingReading(Me, "select * from user where id ='" & ID & "' Limit 1")
        End If

        If IsNew = False Then
            Me.Text = "USER :: EDIT"
            txtName.ReadOnly = True
        Else
            Me.Text = "USER :: NEW"
            txtName.ReadOnly = False
        End If

    End Sub
    Private Sub UserUpdateDgv()
        Dim xSQL As String
        xSQL = $"SELECT 
  u.`ID`,
  u.`Name`,
  u.`Description`,
  u.`PWD_NEVER_EXPIRES` as `Password Never Expires`,
  utm.`DESCRIPTION` AS `Type`,
 us.`DESCRIPTION` AS `Status`,
  c.`NAME` AS `Contact` ,
  u1.`NAME` AS `Registered By`,
  u.`REGISTERED_ON` as `Registered On`,
  u.`LOCKOUT_COUNTER` as `Lockout Counter`,
  u.`LOCKOUT_ON` as `Lockout On`,
  u.`EXPIRATION_DATE` as `Expiration Date`,
  u.`LOGIN_FAILED_ON` as `Login Failed  On`
FROM
  `user` AS u 
  LEFT OUTER JOIN contact AS c 
    ON c.id = u.`CONTACT_ID` 
    LEFT OUTER JOIN user_status_map AS us
    ON us.`ID` = u.`STATUS`
    LEFT OUTER JOIN `user` AS u1
ON u1.`ID` = u.`REGISTERED_BY_ID`
LEFT OUTER JOIN  user_type_map AS utm
ON utm.`ID` = u.`TYPE` WHERE u.ID = '{ID}' limit 1"

        BindingViewUpdate(gsDgv, xSQL, IsNew, gsBS)

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If Trim(txtName.Text) = "" Then
            MessageBoxWarning("Please enter name")
            Me.txtName.Focus()
            Exit Sub
        End If

        If txtName.Text.Length <= 3 Then
            MessageBoxWarning("Name must 4~12 character allowed")
            Exit Sub
        End If

        If IsNew = True Then

            If Trim(txsPassword.Text) = "" Then
                MessageBoxWarning("Password cannot be blank. please enter value")
                Exit Sub
            ElseIf Trim(txsConfirm_Password.Text) = "" Then
                MessageBoxWarning("Confirm password cannot be blank. please enter value")
                Exit Sub
            End If

            If txsPassword.Text <> txsConfirm_Password.Text Then
                MessageBoxExclamation("Password not match! please check the value")
                Exit Sub
            End If


            Try


                Dim rd As OdbcDataReader = SqlReader("select * from `User` where `NAME` = '" & txtName.Text & "' Limit 1")
                If rd.Read Then
                    rd.Close()
                    MessageBoxExclamation("(" & txtName.Text & ") is already used please use another name ")
                    Exit Sub
                End If
                rd.Close()
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
                Exit Sub
            End Try


            If dtpEXPIRATION_DATE.Checked = False Then


            Else

            End If


            Dim pass_date As DateTime = Date.Now
            ID = ObjectTypeMapId("USER")
            'ID,PASSWORD',PWD_NEVER_EXPIRES,PWD_CREATED_ON,TYPE

            Dim SQL_Field As String = ""
            Dim SQL_Value As String = ""
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO `user` ({SQL_Field},ID,PASSWORD,PWD_CREATED_ON) VALUES ({SQL_Value},{ID},'{Encrypt(txsPassword.Text)}','{DateFormatMySql(pass_date)}') ")

        Else
            Dim _pass_change As String = ""

            If Trim(txsPassword.Text) <> "" Or Trim(txsConfirm_Password.Text) <> "" Then
                If Trim(txsPassword.Text) = "" Then
                    MessageBoxWarning("Password cannot be blank. please enter value")
                    Exit Sub
                ElseIf Trim(txsConfirm_Password.Text) = "" Then
                    MessageBoxWarning("Confirm password cannot be blank. please enter value")
                    Exit Sub
                End If

                If txsPassword.Text <> txsConfirm_Password.Text Then
                    MessageBoxExclamation("Password not match! please check the value")
                    Exit Sub
                End If
                _pass_change = ",PWD_CREATED_ON='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',password='" & Encrypt(txsPassword.Text) & "'"
            End If

            'Dim bPassword_nvm_expire As Integer
            'If dtpEXPIRATION_DATE.Checked = False Then
            '    bPassword_nvm_expire = 1

            'Else
            '    bPassword_nvm_expire = 0
            'End If

            SqlExecuted("UPDATE `user` SET " & SqlUpdate(Me) & " " & _pass_change & " WHERE ID = '" & ID & "'")
        End If
        PrompNotify(Me.Text, SaveMsg, True)
        If MessageBoxQuestion("Do you want to apply security settings from user type = " & cmbTYPE.Text) = True Then

            fSecurityUpdate(False, False, ID, cmbTYPE.SelectedValue)

        End If
        UserUpdateDgv()
        ClearAndRefresh(Me)
        txsPassword.Text = ""
        txsConfirm_Password.Text = ""
        IsNew = True
        ID = 0
        If IsNew = False Then
            Me.Text = "USER :: EDIT"
            txtName.ReadOnly = True
        Else
            Me.Text = "USER :: NEW"
            txtName.ReadOnly = False
        End If




        If SecurityAccessMode(FrmUserList, IsNew) = False Then
            Me.Close()
        End If


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class