Imports System.Data.Odbc
Module modDetectUserLogin
    Public gsPCName As String = Environment.MachineName

    Public Function fGet_user_access_control(ByVal prUser_id As String) As Boolean
        Dim bUser As Boolean = False
        Dim rd As OdbcDataReader = fReader("select * from user_access_control where user_id = '" & prUser_id & "'  and `status` <> '0' ")

        If rd.Read Then
            bUser = True
        Else
            bUser = False
        End If
        rd.Close()

        Return bUser

    End Function
    Public Sub fLogout_user_access_control()
        fExecutedOnly("Update  user_access_control set `status` ='0' where user_id = '" & gsUser_ID & "'")
    End Sub

    Public Sub fInsert_user_access_control(ByVal prUser_ID As String)

        Dim rd As OdbcDataReader = fReader("select * from user_access_control where user_id = '" & prUser_ID & "'")
        If rd.Read Then
            fExecutedOnly("Update  user_access_control set last_login ='" & fDateNow() & "',status='1',pc_name = '" & gsPCName & "',ip_address = '" & GetIPv4Address() & "',req_ip_address ='' where user_id = '" & prUser_ID & "' ")
        Else
            fExecutedOnly("insert into  user_access_control set last_login ='" & fDateNow() & "',status='1',pc_name = '" & gsPCName & "',ip_address = '" & GetIPv4Address() & "',req_ip_address='', user_id = '" & prUser_ID & "' ")
        End If

    End Sub

End Module
