Imports System.Data.Odbc
Public Class frmUserDetails
    Public gsID As String
    Public gsNew As Boolean
    Public gsDgv As DataGridView
    Public gsBS As BindingSource
    Private Sub frmUserDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fComboBox(cmbSTATUS, "select * from user_status_map", "ID", "DESCRIPTION")
        fComboBox(cmbCONTACT_ID, "select * from contact where type ='2' and inactive ='0'", "ID", "NAME")
        fComboBox(cmbTYPE, "select * from USER_TYPE_MAP ", "ID", "DESCRIPTION")
        If gsNew = False Then

            Dim squery As String = "select * from user where id ='" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, squery)

        End If

        If gsNew = False Then
            Me.Text = "USER :: EDIT"
            txtName.ReadOnly = True
        Else
            Me.Text = "USER :: NEW"
            txtName.ReadOnly = False
        End If

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)




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
ON utm.`ID` = u.`TYPE` WHERE u.ID = '{gsID}' limit 1"

        fBindDgvUpdate(gsDgv, xSQL, gsNew, gsBS)

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        Dim sQuery As String = fFieldCollector(Me)

        If Trim(txtName.Text) = "" Then
            fMessageboxWarning("Please enter name")
            Me.txtName.Focus()
            Exit Sub
        End If

        If txtName.Text.Length <= 3 Then
            fMessageboxWarning("Name must 4~12 character allowed")
            Exit Sub
        End If

        If gsNew = True Then

            If Trim(txsPassword.Text) = "" Then
                fMessageboxWarning("Password cannot be blank. please enter value")
                Exit Sub
            ElseIf Trim(txsConfirm_Password.Text) = "" Then
                fMessageboxWarning("Confirm password cannot be blank. please enter value")
                Exit Sub
            End If

            If txsPassword.Text <> txsConfirm_Password.Text Then
                fMessageboxExclamation("Password not match! please check the value")
                Exit Sub
            End If


            Try


                Dim rd As OdbcDataReader = fReader("select * from `User` where `NAME` = '" & txtName.Text & "' Limit 1")
                If rd.Read Then
                    rd.Close()
                    fMessageboxExclamation("(" & txtName.Text & ") is already used please use another name ")
                    Exit Sub
                End If
                rd.Close()
            Catch ex As Exception
                fMessageboxWarning(ex.Message)
                Exit Sub
            End Try

            Dim bPassword_nvm_expire As Integer = 0
            If dtpEXPIRATION_DATE.Checked = False Then
                bPassword_nvm_expire = 1

            Else

            End If


            Dim pass_date As DateTime = Date.Now
            gsID = fObjectTypeMap_ID("USER")
            'ID,PASSWORD',PWD_NEVER_EXPIRES,PWD_CREATED_ON,TYPE
            fExecutedOnly("INSERT INTO `user` set " & sQuery & ",ID ='" & gsID & "',PASSWORD='" & Encrypt(txsPassword.Text) & "',PWD_CREATED_ON='" & Format(pass_date, "yyyy-MM-dd hh:mm:ss") & "'")


        Else
            Dim _pass_change As String = ""

            If Trim(txsPassword.Text) <> "" Or Trim(txsConfirm_Password.Text) <> "" Then
                If Trim(txsPassword.Text) = "" Then
                    fMessageboxWarning("Password cannot be blank. please enter value")
                    Exit Sub
                ElseIf Trim(txsConfirm_Password.Text) = "" Then
                    fMessageboxWarning("Confirm password cannot be blank. please enter value")
                    Exit Sub
                End If

                If txsPassword.Text <> txsConfirm_Password.Text Then
                    fMessageboxExclamation("Password not match! please check the value")
                    Exit Sub
                End If

                _pass_change = ",PWD_CREATED_ON='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "',password='" & Encrypt(txsPassword.Text) & "'"


            End If




            Dim bPassword_nvm_expire As Integer = 0
            If dtpEXPIRATION_DATE.Checked = False Then
                bPassword_nvm_expire = 1

            Else
                bPassword_nvm_expire = 0
            End If

            fExecutedOnly("UPDATE `user` set " & sQuery & " " & _pass_change & " Where ID = '" & gsID & "' limit 1;")
        End If
        fPop_Up_Msg(Me.Text, gsSaveStr, True)
        If fMessageBoxQuestion("Do you want to apply security settings from user type = " & cmbTYPE.Text) = True Then

            fSecurityUpdate(False, False, gsID, cmbTYPE.SelectedValue)

        End If
        UserUpdateDgv()
        fCLean_and_refresh(Me)
        txsPassword.Text = ""
        txsConfirm_Password.Text = ""
        gsNew = True
        gsID = ""
        If gsNew = False Then
            Me.Text = "USER :: EDIT"
            txtName.ReadOnly = True
        Else
            Me.Text = "USER :: NEW"
            txtName.ReadOnly = False
        End If




        If fACCESS_NEW_EDIT(frmUserList, gsNew) = False Then
            Me.Close()
        End If


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub
End Class