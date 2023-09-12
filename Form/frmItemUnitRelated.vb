Public Class FrmItemUnitRelated
    Public bSave As Boolean = False
    Public iUnit_ID As Integer = 0


    Private Sub FrmItemUnitRelated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbUnit, "select * from unit_of_measure where inactive ='0'", "ID", "NAME")
        ComboBoxLoad(cmbSymbol, "select * from unit_of_measure where inactive ='0'", "ID", "SYMBOL")
        cmbUnit.SelectedValue = iUnit_ID
        cmbSymbol.SelectedValue = iUnit_ID
        bSave = False

    End Sub

    Private Sub CmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnit.SelectedIndexChanged
        Try
            cmbSymbol.SelectedValue = cmbUnit.SelectedValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CmbSymbol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSymbol.SelectedIndexChanged
        Try
            cmbUnit.SelectedValue = cmbSymbol.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        bSave = True
        Me.Close()
    End Sub
End Class