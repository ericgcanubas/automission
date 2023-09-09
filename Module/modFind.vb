Imports System.Data.Odbc
Module modFind


    Public Sub GetQuickFind(ByVal dgv As DataGridView, ByVal prValue As String)
        For C As Integer = 0 To dgv.Columns.Count - 1
            If dgv.Columns(C).Visible = True Then
                For R As Integer = 0 To dgv.Rows.Count - 1
                    If dgv.Item(C, R).Value.ToString.ToLower Like $"*{prValue.Trim.ToLower}*" Then
                        dgv.CurrentCell = dgv.Rows(R).Cells(C)
                        Exit Sub
                    End If
                Next
            End If
        Next


    End Sub
    Public Function UserSecurtySystemDOCShow(ByVal prNAME As String) As Boolean
        Dim B As Boolean
        Dim rd As OdbcDataReader = SqlReader($"SELECT `ID` FROM `system_security` WHERE user_id ='{gsUser_ID}' and `NAME` ='{prNAME}' limit 1")

        If rd.Read Then
            B = True
        Else
            B = False
        End If

        Return B
    End Function
End Module
