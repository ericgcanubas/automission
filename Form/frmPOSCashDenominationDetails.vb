Public Class FrmPOSCashDenominationDetails
    Public ID As Integer
    Public gsOK As Boolean
    Private Sub FrmPOSCashDenominationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbTYPE, " select  * from pos_cash_type_map", "id", "description")
        gsOK = False
        If ID > 0 Then
            SqlExecutedUsingReading(Me, $"SELECT * FROM pos_cash_denomination WHERE id = '{ID}' limit 1")
            Me.Text = "Edit"
        Else
            Me.Text = "New"
        End If
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtDESCRIPTION.Text.Trim = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If

        If numNOMINAL_VALUE.Value = 0 Then
            MessageBoxInfo("Please enter amount nominal value")
            Exit Sub
        End If

        If txtCODE.Text.Length = 0 Then
            txtCODE.Text = Format(Val(GetMaxField("CODE", "POS_CASH_DENOMINATION")), "0000")
        End If

        If ID = 0 Then
            ID = ObjectTypeMapId("POS_CASH_DENOMINATION")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO pos_cash_denomination ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            SqlExecuted($"UPDATE pos_cash_denomination SET {SqlUpdate(Me)} WHERE ID = '{ID}' ")
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        gsOK = True
        Me.Close()

    End Sub
End Class