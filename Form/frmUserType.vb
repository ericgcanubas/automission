Public Class frmUserType
    Private Sub frmUserType_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        With cmbUserType
            .Items.Clear()
            .Items.Add("Administrator")
            .Items.Add("Supervisor")
            .Items.Add("Documents")
            .Items.Add("Reports")

        End With

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class