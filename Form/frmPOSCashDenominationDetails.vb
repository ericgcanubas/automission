Public Class frmPOSCashDenominationDetails
    Public gsID As Integer
    Public gsOK As Boolean
    Private Sub FrmPOSCashDenominationDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbTYPE, " select  * from pos_cash_type_map", "id", "description")
        gsOK = False
        If gsID <> 0 Then
            fExecutedUsingReading(Me, $"SELECT * FROM pos_cash_denomination WHERE id = '{gsID}' limit 1;")

            Me.Text = "Edit"

        Else
            Me.Text = "New"
        End If
    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)





    End Sub

    Private Sub btnCancel_Click_1(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtDESCRIPTION.Text.Trim = "" Then
            fMessageboxInfo("Please enter description")
            Exit Sub
        End If

        If numNOMINAL_VALUE.Value = 0 Then
            fMessageboxInfo("Please enter amount nominal value")
            Exit Sub
        End If
        If txtCODE.Text.Length = 0 Then
            txtCODE.Text = Format(Val(fGetMaxField("CODE", "POS_CASH_DENOMINATION")), "0000")
        End If

        Dim SQL As String = fFieldCollector(Me)

        If gsID = 0 Then



            gsID = fObjectTypeMap_ID("POS_CASH_DENOMINATION")

            fExecutedOnly($"INSERT INTO pos_cash_denomination SET ID = '{gsID}',{SQL}")
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fExecutedOnly($"UPDATE pos_cash_denomination SET {SQL} WHERE ID = '{gsID}' limit 1;")
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If


        gsOK = True
        Me.Close()

    End Sub
End Class