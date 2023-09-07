Imports System.Data.Odbc
Public Class frmUserDefault
    Public ID As Integer
    Private Sub frmUserDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbPRICE_LEVEL_ID, "select * from price_level where inactive ='0' ", "ID", "DESCRIPTION")

        Dim sQuery As String = "select * from user_default where USER_ID = '" & ID & "' Limit 1"
        SqlExecutedUsingReading(Me, sQuery)

        cmbLOCATION_ID.Enabled = True


        Dim rd As OdbcDataReader = SqlReader("select * from user_default where USER_ID = '" & ID & "' Limit 1")
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
        Dim rd As OdbcDataReader = SqlReader("select * from user_default where USER_ID = '" & ID & "' Limit 1")

        If rd.Read Then
            SqlExecuted("DELETE FROM user_default  Where  USER_ID = '" & ID & "' ")
            PrompNotify(Me.Text, DeleteMsg, True)
            Me.Close()
        Else

        End If
    End Sub

    Private Sub btnSaveDefault_Click(sender As Object, e As EventArgs) Handles btnSaveDefault.Click


        Dim rd As OdbcDataReader = SqlReader("select * from user_default where USER_ID = '" & ID & "' Limit 1")

        If rd.Read Then
            SqlExecuted("UPDATE user_default SET  " & SqlUpdate(Me) & " Where  USER_ID = '" & ID & "' ")
        Else
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO user_default ({SQL_Field},USER_ID) VALUES ({SQL_Value},{ID}) ")
        End If
        PrompNotify(Me.Text, SaveMsg, True)
        Me.Close()

    End Sub

    Private Sub chkUSER_DISABLED_CheckedChanged(sender As Object, e As EventArgs) Handles chkUSER_DISABLED.CheckedChanged

    End Sub
End Class