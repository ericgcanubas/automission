Public Class frmMessageUserControLoading
    Dim n As Integer = 11
    Dim str_dot As String = ""
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        n = n - 1

        If str_dot.Length <= 3 Then

            str_dot = str_dot & "."
        Else
            str_dot = ""
        End If

        lblwait.Text = "Please wait " & str_dot

        If n = 0 Then
            btnOk.Enabled = True
            btnOk.Text = "Ok"
            Timer1.Stop()
        Else
            btnOk.Text = "Ok (" & n & ")"
        End If



    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        SqlExecuted("update user_access_control set `status`= '0', req_ip_address ='' where `status`= '2' and req_ip_address = '" & GetIPv4Address() & "' and user_id = '" & gsUser_ID & "'")

        Me.Close()
    End Sub
End Class