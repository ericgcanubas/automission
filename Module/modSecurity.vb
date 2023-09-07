Imports System.Data.Odbc
Module modSecurity
    Public Function fSystem_Security(ByVal prSUB_ID As Integer) As Boolean
        Dim bAccess As Boolean = False
        '
        Try

            Dim rd As OdbcDataReader
            Dim xName As String = GetStringFieldValue("tblsub_menu", "SUB_ID", prSUB_ID, "DESCRIPTION")
            rd = SqlReader("select ID from system_security  where `NAME` = '" & xName & "' and user_id = '" & gsUser_ID & "' Limit 1")
            If rd.Read Then
                bAccess = True
            Else
                If fAccessDeniedIsYes("You are not allowed access to " & xName & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return bAccess
    End Function
    Public Function fACCESS_PRINT_PREVIEW(ByVal f As Form) As Boolean
        Dim bAccess As Boolean = False

        Try

            Dim rd As OdbcDataReader
            rd = SqlReader("select `PRINT_PREVIEW` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & f.Name & "' limit 1 ")
            If rd.Read Then
                If NumIsNull(rd("T")) = 0 Then
                    If fAccessDeniedIsYes("You are not allowed print or preview to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                        bAccess = True
                    End If
                Else
                    bAccess = True
                End If
            Else
                If fAccessDeniedIsYes("You are not allowed print or preview to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return bAccess
    End Function
    Public Function fACCESS_FIND(ByVal f As Form) As Boolean
        Dim bAccess As Boolean = False

        Try

            Dim rd As OdbcDataReader
            rd = SqlReader("select `FIND` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & f.Name & "' limit 1 ")
            If rd.Read Then
                If NumIsNull(rd("T")) = 0 Then
                    If fAccessDeniedIsYes("You are not allowed find to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                        bAccess = True
                    End If
                Else
                    bAccess = True
                End If
            Else
                If fAccessDeniedIsYes("You are not allowed find to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                bAccess = fACCESS_FIND(f)
            Else
                End
            End If
        End Try
        Return bAccess
    End Function
    Public Function fACCESS_DELETE(ByVal f As Form) As Boolean
        Dim bAccess As Boolean = False

        Try

            Dim xMsg As String


            xMsg = "You are not allowed delete to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator "

            Dim rd As OdbcDataReader
            rd = SqlReader("select `DELETE` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & f.Name & "' limit 1 ")
            If rd.Read Then
                If NumIsNull(rd("T")) = 0 Then

                    If fAccessDeniedIsYes(xMsg) = False Then


                        bAccess = True
                    End If
                Else
                    bAccess = True
                End If
            Else
                If fAccessDeniedIsYes(xMsg) = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                bAccess = fACCESS_DELETE(f)
            Else
                End
            End If
        End Try
        Return bAccess
    End Function
    Public Function fACCESS_NEW_EDIT(ByVal f As Form, ByVal bNew As Boolean) As Boolean







        Dim bAccess As Boolean = False
        ' Dim cn As New MySqlConnection(mysqlConstr)

        Try
            '   cn.Open()
            Dim rd As OdbcDataReader
            If bNew = True Then
                rd = SqlReader("select `NEW` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & f.Name & "' limit 1 ")
                If rd.Read Then
                    If NumIsNull(rd("T")) = 0 Then
                        If fAccessDeniedIsYes("You are not allowed add new to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                            bAccess = True
                        End If
                    Else
                        bAccess = True
                    End If
                Else
                    If fAccessDeniedIsYes("You are not allowed add new to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                        bAccess = True
                    End If
                End If







            Else
                rd = SqlReader("select `EDIT` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & f.Name & "' limit 1 ")
                If rd.Read Then
                    If NumIsNull(rd("T")) = 0 Then
                        If fAccessDeniedIsYes("You are not allowed edit to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                            bAccess = True
                        End If
                    Else
                        bAccess = True
                    End If

                Else
                    If fAccessDeniedIsYes("You are not allowed edit to " & GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the BMS administrator ") = False Then
                        bAccess = True
                    End If
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                bAccess = fACCESS_NEW_EDIT(f, bNew)
            Else
                End
            End If
        End Try

        Return bAccess

    End Function
    Public Function fAccessDeniedIsYes(ByVal Msg As String) As Boolean
        Dim bCancel As Boolean = True
        frmAccessDenied.gsCancel = bCancel
        frmAccessDenied.gsMessage = Msg
        frmAccessDenied.ShowDialog()
        bCancel = frmAccessDenied.gsCancel
        frmAccessDenied = Nothing
        Return bCancel
    End Function
End Module
