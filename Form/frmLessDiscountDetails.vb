
Public Class FrmLessDiscountDetails
    Public IsNew As Boolean = True
    Public ID As Integer

    Private Sub frmLessDiscountDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If IsNew = False Then
            SqlExecutedUsingReading(Me, "select * from LESS_DISCOUNT_PENALTY where id = '" & ID & "'")
        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

        If txtDESCRIPTION.Text = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If



        If IsNew = False Then
            SqlExecuted("UPDATE LESS_DISCOUNT_PENALTY set " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
        Else
            ID = GetMaxField("ID", "LESS_DISCOUNT_PENALTY")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO LESS_DISCOUNT_PENALTY ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If
        Me.Close()


    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
End Class