Imports MySql.Data.MySqlClient
Public Class frmLessDiscountDetails
    Public gsNew As Boolean
    Public gsID As Integer

    Private Sub frmLessDiscountDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        If gsNew = False Then

            ' Dim cn As New MySqlConnection(mysqlConstr)
            ' cn.Open()
            fExecutedUsingReading(Me, "select * from less_discount_penalty where id = '" & gsID & "'")
            '  cn.Close()

        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If txtDESCRIPTION.Text = "" Then
            fMessageboxInfo("Please enter description")
            Exit Sub
        End If

        Dim sql As String = fFieldCollector(Me)

        If gsNew = False Then
            fExecutedOnly("UPDATE LESS_DISCOUNT_PENALTY set " & sql & " Where ID = '" & gsID & "'")
        Else
            gsID = fGetMaxField("ID", "less_discount_penalty")
            fExecutedOnly("INSERT INTO less_discount_penalty set " & sql & ",ID = '" & gsID & "'")
        End If
        Me.Close()


    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class