Imports System.Data.Odbc
Public Class FrmUserDefault
    Public ID As Integer
    Private Sub FrmUserDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbPRICE_LEVEL_ID, "select * from price_level where inactive ='0' ", "ID", "DESCRIPTION")

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
    Private Sub BtnRemoveDefault_Click(sender As Object, e As EventArgs) Handles btnRemoveDefault.Click
        Dim rd As OdbcDataReader = SqlReader("select * from user_default where USER_ID = '" & ID & "' Limit 1")

        If rd.Read Then
            SqlExecuted("DELETE FROM user_default  Where  USER_ID = '" & ID & "' ")
            DeleteNotify(Me)

            Me.Close()
        Else

        End If
    End Sub

    Private Sub BtnSaveDefault_Click(sender As Object, e As EventArgs) Handles btnSaveDefault.Click
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

End Class