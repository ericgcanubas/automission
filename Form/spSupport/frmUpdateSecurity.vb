Imports System.Data.Odbc
Public Class frmUpdateSecurity
    Public gsAll As Boolean = False
    Public gsUserType As Boolean = False
    Public gsID As String
    Public gsUSER_TYPE_ID As String
    Private Sub frmUpdateSecurity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsAll = False Then
            Me.Size = New Point(383, 72)
            gsProgressBar = ProgressBar1
            ProgressBar2.Visible = False
        Else
            Me.Size = New Point(383, 111)
            gsProgressBar = ProgressBar2
        End If


    End Sub

    Private Sub frmUpdateSecurity_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim user_counting As Integer = 0
        If gsAll = True Then
            If gsUserType = False Then
                'User all update source of user type
                '   Dim cn As New MySqlConnection(mysqlConstr)
                Try
                    'cn.Open()
                    Dim rd1 As OdbcDataReader = SqlReader("select ID from `user` where `Type` = '" & gsUSER_TYPE_ID & "'")
                    Dim dt As New DataTable
                    dt.Load(rd1)
                    ProgressBar1.Minimum = 0
                    ProgressBar1.Maximum = dt.Rows.Count
                    rd1.Close()
                    '  cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("select ID,`NAME` from `user` where `Type` = '" & gsUSER_TYPE_ID & "'")
                    While rd.Read
                        user_counting = user_counting + 1
                        Dim xName As String = GF_TextIsNull(rd("NAME"))

                        fUserSecuritySettingSetUpdateControl(GF_NumIsNull(rd("ID")), gsUSER_TYPE_ID)
                        ProgressBar1.Value = user_counting
                    End While
                    rd.Close()
                    MessageBoxInfo("Update successfully")
                    Me.Close()
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                End Try

            Else
                'All User type - not working
                MessageBoxInfo("Invalid procedure")
            End If

        Else
            If gsUserType = False Then
                '1 user update
                'User all update source of user type
                fUserSecuritySettingSetUpdateControl(gsID, gsUSER_TYPE_ID)
                MessageBoxInfo("User security update")
                Me.Close()
                Me.Close()
            Else
                '1 user type update
                fUpdateUserTypeSecurity(gsUSER_TYPE_ID, gsID)
                MessageBoxInfo("User security update")
                Me.Close()
            End If


        End If
    End Sub
End Class