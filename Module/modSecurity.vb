Imports System.Data.Odbc
Module modSecurity
    Public Function SecuritySystemModule(ByVal prSUB_ID As Integer) As Boolean
        Dim bAccess As Boolean = False
        '
        Try
            Dim rd As OdbcDataReader
            Dim xName As String = GF_GetStringFieldValue("tblsub_menu", "SUB_ID", prSUB_ID, "DESCRIPTION")
            rd = SqlReader("select ID from system_security  where `NAME` = '" & xName & "' and user_id = '" & gsUser_ID & "' Limit 1")
            If rd.Read Then
                bAccess = True
            Else
                If IsAccessDenied("You are not allowed access to " & xName & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return bAccess
    End Function
    Public Function SecurityAccessPrint(ByVal f As Form) As Boolean
        Dim bAccess As Boolean = False

        Try

            Dim rd As OdbcDataReader
            rd = SqlReader("select `PRINT_PREVIEW` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & f.Name & "' limit 1 ")
            If rd.Read Then
                If GF_NumIsNull(rd("T")) = 0 Then
                    If IsAccessDenied("You are not allowed print or preview to " & GF_GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                        bAccess = True
                    End If
                Else
                    bAccess = True
                End If
            Else
                If IsAccessDenied("You are not allowed print or preview to " & GF_GetStringFieldValue("tblsub_menu", "FORM", f.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return bAccess
    End Function
    Public Function SecurityAccessFind(ByVal Frm As Form) As Boolean
        Dim bAccess As Boolean = False

        Try

            Dim rd As OdbcDataReader
            rd = SqlReader("select `FIND` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & Frm.Name & "' limit 1 ")
            If rd.Read Then
                If GF_NumIsNull(rd("T")) = 0 Then
                    If IsAccessDenied("You are not allowed find to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                        bAccess = True
                    End If
                Else
                    bAccess = True
                End If
            Else
                If IsAccessDenied("You are not allowed find to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                bAccess = SecurityAccessFind(Frm)
            Else
                End
            End If
        End Try
        Return bAccess
    End Function
    Public Function SecurityAccessDelete(ByVal Frm As Form) As Boolean
        Dim bAccess As Boolean = False
        Try
            Dim xMsg As String
            xMsg = "You are not allowed delete to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator "
            Dim rd As OdbcDataReader
            rd = SqlReader("select `DELETE` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & Frm.Name & "' limit 1 ")
            If rd.Read Then
                If GF_NumIsNull(rd("T")) = 0 Then

                    If IsAccessDenied(xMsg) = False Then


                        bAccess = True
                    End If
                Else
                    bAccess = True
                End If
            Else
                If IsAccessDenied(xMsg) = False Then
                    bAccess = True
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                bAccess = SecurityAccessDelete(Frm)
            Else
                End
            End If
        End Try
        Return bAccess
    End Function
    Public Function SecurityAccessMode(ByVal Frm As Form, ByVal IsNew As Boolean) As Boolean

        Dim bAccess As Boolean = False


        Try

            Dim rd As OdbcDataReader
            If IsNew = True Then
                rd = SqlReader("select `NEW` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & Frm.Name & "' limit 1 ")
                If rd.Read Then
                    If GF_NumIsNull(rd("T")) = 0 Then
                        If IsAccessDenied("You are not allowed add new to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                            bAccess = True
                        End If
                    Else
                        bAccess = True
                    End If
                Else
                    If IsAccessDenied("You are not allowed add new to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                        bAccess = True
                    End If
                End If







            Else
                rd = SqlReader("select `EDIT` as T from user_security_access as u inner join tblsub_menu as s on s.sub_id = u.sub_id where u.user_id = '" & gsUser_ID & "' and s.FORM = '" & Frm.Name & "' limit 1 ")
                If rd.Read Then
                    If GF_NumIsNull(rd("T")) = 0 Then
                        If IsAccessDenied("You are not allowed edit to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                            bAccess = True
                        End If
                    Else
                        bAccess = True
                    End If

                Else
                    If IsAccessDenied("You are not allowed edit to " & GF_GetStringFieldValue("tblsub_menu", "FORM", Frm.Name, "DESCRIPTION") & " or perform the request function operation. For more information, contact the system administrator ") = False Then
                        bAccess = True
                    End If
                End If
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                bAccess = SecurityAccessMode(Frm, IsNew)
            Else
                End
            End If
        End Try

        Return bAccess

    End Function
    Public Function IsAccessDenied(ByVal Msg As String) As Boolean
        Dim bCancel As Boolean = True
        frmAccessDenied.gsCancel = bCancel
        frmAccessDenied.gsMessage = Msg
        frmAccessDenied.ShowDialog()
        bCancel = frmAccessDenied.gsCancel
        frmAccessDenied = Nothing
        Return bCancel
    End Function
End Module
