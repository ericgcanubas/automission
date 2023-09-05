Public Class frmPOSNumpad
    Public gsValue As String
    Public gsEnter As Boolean = False
    Private Sub fGetValue()
        fGetLimit()
        lblValue.Text = gsValue

    End Sub
    Private Sub frmPOSNumpad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsEnter = False


        fGetValue()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        gsValue = gsValue & "0"
        fGetValue()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gsValue = gsValue & "1"
        fGetValue()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gsValue = gsValue & "2"
        fGetValue()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gsValue = gsValue & "3"
        fGetValue()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        gsValue = gsValue & "4"
        fGetValue()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        gsValue = gsValue & "5"
        fGetValue()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gsValue = gsValue & "6"
        fGetValue()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        gsValue = gsValue & "7"
        fGetValue()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        gsValue = gsValue & "8"
        fGetValue()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        gsValue = gsValue & "9"
        fGetValue()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            If gsValue.Contains(".") = True Then

            Else
                gsValue = gsValue & "."
                fGetValue()
            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            Dim L As Integer = fNumisNULL(gsValue.Length)
            If L = 0 Then
                gsValue = ""
            Else
                gsValue = gsValue.ToString.Remove(L - 1)
            End If
        Catch ex As Exception

        End Try


        fGetValue()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsEnter = False
        Me.Close()
    End Sub

    Private Sub btnEnter_Click(sender As Object, e As EventArgs) Handles btnEnter.Click
        gsEnter = True
        Me.Close()

    End Sub
    Private Sub fGetLimit()
        If gsValue = "" Then
            Exit Sub
        End If
        Dim got_point As Boolean = False
        Dim got_point_i As Integer = 0
        Dim Get_Collect As String = ""
        For N As Integer = 0 To gsValue.Length - 1

            If gsValue.Substring(N, 1) = "." Then
                got_point = True
                Get_Collect = Get_Collect & gsValue.Substring(N, 1)
            Else
                If got_point = True Then
                    If got_point_i < 2 Then
                        Get_Collect = Get_Collect & gsValue.Substring(N, 1)

                    Else
                        Exit For
                    End If
                    got_point_i = got_point_i + 1
                Else
                    Get_Collect = Get_Collect & gsValue.Substring(N, 1)
                End If

            End If

            If N > 10 Then
                Exit For
            End If
        Next

        gsValue = Get_Collect
    End Sub
End Class