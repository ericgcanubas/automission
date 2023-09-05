Imports System.Data.Odbc
Public Class frmUserDefault
    Public gsID As String
    Private Sub frmUserDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        fComboBox(cmbPRICE_LEVEL_ID, "select * from price_level where inactive ='0' ", "ID", "DESCRIPTION")

        Dim sQuery As String = "select * from user_default where USER_ID = '" & gsID & "' Limit 1"
        fExecutedUsingReading(Me, sQuery)

        cmbLOCATION_ID.Enabled = True


        Dim rd As OdbcDataReader = fReader("select * from user_default where USER_ID = '" & gsID & "' Limit 1")
        If rd.Read Then
            btnRemoveDefault.Visible = True
        Else
            btnRemoveDefault.Visible = False
        End If
        rd.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnRemoveDefault_Click(sender As Object, e As EventArgs) Handles btnRemoveDefault.Click
        Dim rd As OdbcDataReader = fReader("select * from user_default where USER_ID = '" & gsID & "' Limit 1")

        If rd.Read Then
            fExecutedOnly("DELETE FROM user_default  Where  USER_ID = '" & gsID & "' ")
            fPop_Up_Msg(Me.Text, gsDeleteStr, True)
            Me.Close()
        Else

        End If
    End Sub

    Private Sub btnSaveDefault_Click(sender As Object, e As EventArgs) Handles btnSaveDefault.Click
        Dim sql As String = fFieldCollector(Me)

        Dim rd As OdbcDataReader = fReader("select * from user_default where USER_ID = '" & gsID & "' Limit 1")

        If rd.Read Then
            fExecutedOnly("UPDATE user_default SET  " & sql & " Where  USER_ID = '" & gsID & "' limit 1;")
        Else
            fExecutedOnly("INSERT INTO user_default SET  USER_ID = '" & gsID & "'," & sql)
        End If
        fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Me.Close()

    End Sub

    Private Sub chkUSER_DISABLED_CheckedChanged(sender As Object, e As EventArgs) Handles chkUSER_DISABLED.CheckedChanged

    End Sub
End Class