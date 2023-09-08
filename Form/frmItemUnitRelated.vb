Public Class FrmItemUnitRelated
    Public bSave As Boolean
    Public iUnit_ID As Integer = 0
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmItemUnitRelated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMaterialSkin(Me)
        bSave = False
        ComboBoxLoad(cmbUnit, "select * from unit_of_measure where inactive ='0'", "ID", "NAME")
        ComboBoxLoad(cmbSymbol, "select * from unit_of_measure where inactive ='0'", "ID", "SYMBOL")
        cmbUnit.SelectedValue = iUnit_ID
        cmbSymbol.SelectedValue = iUnit_ID
        bSave = False
        '  Me.Close()
    End Sub

    Private Sub cmbUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbUnit.SelectedIndexChanged
        Try
            cmbSymbol.SelectedValue = cmbUnit.SelectedValue
        Catch ex As Exception
        End Try
    End Sub

    Private Sub cmbSymbol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSymbol.SelectedIndexChanged
        Try
            cmbUnit.SelectedValue = cmbSymbol.SelectedValue
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        bSave = True
        Me.Close()
    End Sub
End Class