Imports System.Data.Odbc
Module modUserType
    Public gsUserLoop As Integer
    Public gsProgressBar As ProgressBar
    Public Sub fUpdateUserTypeSecurity(ByVal prUser_Type_Id As String, ByVal prUserIdBase As Integer)

        gsUserLoop = 0
        gsProgressBar.Minimum = 0

        Try

            Dim rd1 As OdbcDataReader = SqlReader("SELECT ml.sub_id,sm.description,(SELECT `NAME` FROM system_security WHERE user_id ='" & prUserIdBase & "' AND `name` = sm.`Description` ) AS `user_value` FROM  tblmenu_list AS ml INNER JOIN tblsub_menu AS sm ON sm.sub_id = ml.sub_id  ORDER BY sm.description ")
            Dim dt As New DataTable
            dt.Load(rd1)
            gsProgressBar.Maximum = dt.Rows.Count
            rd1.Close()

            Dim rd As OdbcDataReader = SqlReader("SELECT ml.sub_id,sm.description,(SELECT `NAME` FROM system_security WHERE user_id ='" & prUserIdBase & "' AND `name` = sm.`Description` ) AS `user_value` FROM  tblmenu_list AS ml INNER JOIN tblsub_menu AS sm ON sm.sub_id = ml.sub_id  ORDER BY sm.description ")
            While rd.Read
                gsUserLoop = gsUserLoop + 1
                Dim bAdd As Boolean
                If TextIsNull(rd("user_value")) = "" Then
                    bAdd = False
                Else
                    bAdd = True
                End If
                fUpdateUserTypeValue(prUser_Type_Id, TextIsNull(rd("description")), bAdd)
                gsProgressBar.Value = gsUserLoop

            End While
            rd.Close()
            rd = Nothing
            rd = SqlReader("SELECT sm.menu_id,sm.description,(SELECT `NAME` FROM system_security WHERE user_id ='" & prUserIdBase & "' AND `name` = sm.`Description` ) AS `user_value` FROM  tblmenu AS sm  ORDER BY sm.description ")
            While rd.Read
                Dim bAdd As Boolean
                If TextIsNull(rd("user_value")) = "" Then
                    bAdd = False
                Else
                    bAdd = True
                End If
                fUpdateUserTypeValue(prUser_Type_Id, TextIsNull(rd("description")), bAdd)
            End While
            rd.Close()
            fUpdateUserTypeSecurityAccess(prUserIdBase, prUser_Type_Id)
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fUpdateUserTypeSecurity(prUser_Type_Id, prUserIdBase)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub fUpdateUserTypeValue(ByVal prUser_Type_id As Integer, ByVal prName_Select As String, ByVal bAdd As Boolean)

        Try
            Dim rd As OdbcDataReader = SqlReader("select * from user_type_system_security where `NAME` = '" & prName_Select & "' and USER_TYPE_ID ='" & prUser_Type_id & "' limit 1")
            If rd.Read Then
                If bAdd = False Then
                    SqlExecuted("DELETE FROM user_type_system_security Where `NAME` = '" & prName_Select & "' and USER_TYPE_ID ='" & prUser_Type_id & "'")
                End If
            Else
                If bAdd = True Then
                    SqlExecuted("INSERT INTO user_type_system_security SET `NAME` = '" & prName_Select & "',USER_TYPE_ID ='" & prUser_Type_id & "'")
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fUpdateUserTypeValue(prUser_Type_id, prName_Select, bAdd)
            Else
                End
            End If
        End Try

    End Sub

    Private Sub fUpdateUserTypeSecurityAccess(ByVal user_id As String, ByVal User_Type_ID As String)

        gsUserLoop = 0
        Try

            Dim rd1 As OdbcDataReader = SqlReader("select u.*,s.description,s.SUB_ID as 'IDx' from tblsub_menu as s inner join tblmenu_list ml on ml.sub_id = s.sub_id left outer join user_security_access as u  on u.sub_id = s.sub_id and u.user_id = '" & user_id & "' where s.access_control = '1' order by ml.menu_id,s.description")
            Dim dt As New DataTable
            dt.Load(rd1)
            gsProgressBar.Minimum = 0
            gsProgressBar.Maximum = dt.Rows.Count
            rd1.Close()

            Dim rd As OdbcDataReader = SqlReader("select u.*,s.description,s.SUB_ID as 'IDx' from tblsub_menu as s inner join tblmenu_list ml on ml.sub_id = s.sub_id left outer join user_security_access as u  on u.sub_id = s.sub_id and u.user_id = '" & user_id & "' where s.access_control = '1' order by ml.menu_id,s.description")
            While rd.Read
                gsUserLoop = gsUserLoop + 1
                fUpdateUserTypeSecurityAccessValue(User_Type_ID, NumIsNull(rd("IDx")), NumIsNull(rd("NEW")), NumIsNull(rd("EDIT")), NumIsNull(rd("DELETE")), NumIsNull(rd("FIND")), NumIsNull(rd("PRINT_PREVIEW")))
                gsProgressBar.Value = gsUserLoop
            End While
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fUpdateUserTypeSecurityAccess(user_id, User_Type_ID)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub fUpdateUserTypeSecurityAccessValue(ByVal user_type_id As String, ByVal sub_id As String, ByVal prNew As Integer, ByVal prEdit As Integer, ByVal prDelete As Integer, ByVal prFind As Integer, ByVal prPrint_View As Integer)

        Try

            Dim rd As OdbcDataReader = SqlReader("select * from user_type_security_access where user_type_id = '" & user_type_id & "' and sub_id = '" & sub_id & "' limit 1 ")
            If rd.Read Then
                SqlExecuted("UPDATE user_type_security_access set `new`='" & prNew & "',`edit` = '" & prEdit & "',`delete` = '" & prDelete & "',`find` = '" & prFind & "',`print_view`='" & prPrint_View & "' where user_type_id = '" & user_type_id & "' and sub_id = '" & sub_id & "'")
            Else
                SqlExecuted("INSERT INTO user_type_security_access set user_type_id = '" & user_type_id & "',sub_id = '" & sub_id & "',`new`='" & prNew & "',`edit` = '" & prEdit & "',`delete` = '" & prDelete & "',`find` = '" & prFind & "',`print_view`='" & prPrint_View & "'")
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub


    Public Sub fUserSecuritySettingSetUpdateControl(ByVal User_ID As String, ByVal BaseUserTypeID As String)
        gsUserLoop = 0

        Try

            Dim rd1 As OdbcDataReader = SqlReader("SELECT ml.sub_id,sm.description,sm.access_control,(SELECT `NAME` FROM user_type_system_security WHERE User_TYPE_ID ='" & BaseUserTypeID & "' AND `name` = sm.`Description` ) AS `user_value` FROM  tblmenu_list AS ml INNER JOIN tblsub_menu AS sm ON sm.sub_id = ml.sub_id  ORDER BY sm.description ")
            Dim dt As New DataTable
            dt.Load(rd1)
            gsProgressBar.Minimum = 0
            gsProgressBar.Maximum = dt.Rows.Count
            rd1.Close()

            Dim rd As OdbcDataReader = SqlReader("SELECT ml.sub_id,sm.description,sm.access_control,(SELECT `NAME` FROM user_type_system_security WHERE User_TYPE_ID ='" & BaseUserTypeID & "' AND `name` = sm.`Description` ) AS `user_value` FROM  tblmenu_list AS ml INNER JOIN tblsub_menu AS sm ON sm.sub_id = ml.sub_id  ORDER BY sm.description ")
            While rd.Read
                gsUserLoop = gsUserLoop + 1
                Dim bAdd As Boolean
                If TextIsNull(rd("user_value")) = "" Then
                    bAdd = False
                Else
                    bAdd = True
                End If
                fUserSetValue(User_ID, TextIsNull(rd("description")), bAdd)
                gsProgressBar.Value = gsUserLoop

            End While
            rd.Close()


            rd = Nothing
            rd = SqlReader("SELECT sm.menu_id,sm.description,(SELECT `NAME` FROM user_type_system_security WHERE user_type_ID ='" & BaseUserTypeID & "' AND `name` = sm.`Description` ) AS `user_value` FROM  tblmenu AS sm  ORDER BY sm.description ")
            While rd.Read
                Dim bAdd As Boolean
                If TextIsNull(rd("user_value")) = "" Then
                    bAdd = False
                Else
                    bAdd = True
                End If
                fUserSetValue(User_ID, TextIsNull(rd("description")), bAdd)

            End While
            rd.Close()
            fUpdateUserSecurityAccess(User_ID, BaseUserTypeID) 'Next
        Catch ex As Exception

            MessageBoxWarning(ex.Message)

        End Try

    End Sub
    Private Sub fUserSetValue(ByVal prUser_id As Integer, ByVal prName_Select As String, ByVal bAdd As Boolean)

        Try

            Dim rd As OdbcDataReader = SqlReader("select * from system_security where `NAME` = '" & prName_Select & "' and USER_ID ='" & prUser_id & "' limit 1")
            If rd.Read Then
                If bAdd = False Then
                    SqlExecuted("DELETE FROM system_security Where `NAME` = '" & prName_Select & "' and USER_ID ='" & prUser_id & "'")
                End If
            Else
                If bAdd = True Then
                    SqlExecuted("INSERT INTO system_security SET `NAME` = '" & prName_Select & "',USER_ID ='" & prUser_id & "'")
                End If
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)

        End Try

    End Sub
    '======
    Private Sub fUpdateUserSecurityAccess(ByVal user_id As String, ByVal User_Type_ID As String)
        gsUserLoop = 0

        Try

            Dim rd1 As OdbcDataReader = SqlReader("select u.*,s.description,s.SUB_ID as 'IDx' from tblsub_menu as s inner join tblmenu_list ml on ml.sub_id = s.sub_id left outer join user_type_security_access as u  on u.sub_id = s.sub_id and u.user_type_id = '" & User_Type_ID & "' where s.access_control = '1' order by ml.menu_id,s.description")
            Dim dt As New DataTable
            dt.Load(rd1)
            gsProgressBar.Minimum = 0
            gsProgressBar.Maximum = dt.Rows.Count

            rd1.Close()

            Dim rd As OdbcDataReader = SqlReader("select u.*,s.description,s.SUB_ID as 'IDx' from tblsub_menu as s inner join tblmenu_list ml on ml.sub_id = s.sub_id left outer join user_type_security_access as u  on u.sub_id = s.sub_id and u.user_type_id = '" & User_Type_ID & "' where s.access_control = '1' order by ml.menu_id,s.description")
            While rd.Read
                gsUserLoop = gsUserLoop + 1
                fUpdateUserSecurityAccessValue(user_id, NumIsNull(rd("IDx")), NumIsNull(rd("NEW")), NumIsNull(rd("EDIT")), NumIsNull(rd("DELETE")), NumIsNull(rd("FIND")), NumIsNull(rd("PRINT_VIEW")))
                gsProgressBar.Value = gsUserLoop
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub
    Private Sub fUpdateUserSecurityAccessValue(ByVal user_id As String, ByVal sub_id As String, ByVal prNew As Integer, ByVal prEdit As Integer, ByVal prDelete As Integer, ByVal prFind As Integer, ByVal prPrint_View As Integer)

        Try

            Dim rd As OdbcDataReader = SqlReader("select * from user_security_access where user_id = '" & user_id & "' and sub_id = '" & sub_id & "' limit 1 ")
            If rd.Read Then
                SqlExecuted("UPDATE user_security_access set `new`='" & prNew & "',`edit` = '" & prEdit & "',`delete` = '" & prDelete & "',`find` = '" & prFind & "',`print_preview`='" & prPrint_View & "',modify=now() where user_id = '" & user_id & "' and sub_id = '" & sub_id & "'")
            Else
                SqlExecuted("INSERT INTO user_security_access set user_id = '" & user_id & "',sub_id = '" & sub_id & "',`new`='" & prNew & "',`edit` = '" & prEdit & "',`delete` = '" & prDelete & "',`find` = '" & prFind & "',`print_preview`='" & prPrint_View & "',modify=now()")
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)

        End Try
    End Sub

    Public Sub fSecurityUpdate(ByVal prALL As Boolean, ByVal prUSERTYPE As Boolean, ByVal prUSER_ID As String, ByVal prUSER_TYPE_ID As String)

        frmUpdateSecurity.gsAll = prALL
        frmUpdateSecurity.gsUserType = prUSERTYPE
        frmUpdateSecurity.gsID = prUSER_ID
        frmUpdateSecurity.gsUSER_TYPE_ID = prUSER_TYPE_ID
        frmUpdateSecurity.ShowDialog()
        frmUpdateSecurity.Dispose()
        frmUpdateSecurity = Nothing
    End Sub

End Module
