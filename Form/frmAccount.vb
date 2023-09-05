Imports System.Data.Odbc
Public Class frmAccount
    Public gsID As String
    Public gsNew As Boolean = True
    Public this_BS As BindingSource
    Public dgv As DataGridView
    Private Sub frmAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fclear_info()
        Me.Text = "Create account"
        If gsNew = False Then
            Me.Text = "Update account"
            fExecutedUsingReading(Me, "select * from account where ID = '" & gsID & "' Limit 1")
        End If


    End Sub
    Private Sub fclear_info()
        fComboBox(cmbTYPE, "select ID,DESCRIPTION from account_type_map ", "ID", "DESCRIPTION")
        fComboBox(cmbGROUP_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
        txtNAME.Text = ""
        chkINACTIVE.Checked = False
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub fAccountUpdateDgv()
        Dim xSQL As String
        xSQL = $"SELECT a.`ID`,a.`Name`,atm.`DESCRIPTION` AS `Type`,a.`BANK_ACCOUNT_NO` as `Bank Account No.`,a.`LINE_NO` as `Line No.`,IFNULL(ag.`NAME`,'') AS `Group of Accounts`, if(a.`Inactive`=0,'No','Yes') as `Inactive` FROM  account a LEFT OUTER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` LEFT OUTER JOIN account AS ag ON ag.`ID` = a.`GROUP_ACCOUNT_ID`  where  a.ID = '{gsID}' Order by a.`ID`"
        fBindDgvUpdate(dgv, xSQL, gsNew, this_BS)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cmbTYPE.SelectedIndex = -1 Then
            fMessageboxInfo("Please select account type")
            Exit Sub
        End If

        If txtNAME.Text.Length = 0 Then
            fMessageboxInfo("Please enter account name")
            Exit Sub
        End If

        Dim sqQuery As String = fFieldCollector(Me)

        If gsNew = True Then


            Try
                Dim rd As OdbcDataReader = fReader("select * from account WHERE NAME = '" & fTextisNULL(txtNAME.Text) & "' limit 1;")
                If rd.Read Then
                    rd.Close()
                    fMessageboxWarning("Account name is already exist!")
                    Exit Sub
                End If
                rd.Close()
            Catch ex As Exception
                fMessageboxWarning(ex.Message)
                Exit Sub
            End Try

            Dim i As Integer = fGetMaxField_LINE("`LINE_NO`", "ACCOUNT", "`TYPE`", cmbTYPE.SelectedValue)
            gsID = fObjectTypeMap_ID("ACCOUNT")
            fExecutedOnly("INSERT INTO account SET " & sqQuery & ", ID ='" & gsID & "',LINE_NO='" & i & "'")
            fclear_info()
            fPop_Up_Msg(Me.Text, gsSaveStr, True)

        Else

            fExecutedOnly("UPDATE account SET " & sqQuery & " WHERE ID = '" & gsID & "' limit 1")
            fclear_info()
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If

        fAccountUpdateDgv()
        gsNew = True
        gsID = ""
        Me.Text = "Create account"

        If fACCESS_NEW_EDIT(frmChartOfAccount, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class