
Public Class frmItemUnitMeasurePriceLevel
    Public bSave As Boolean
    Public iPrice_Level_id As Integer = 0
    Public iCustomer_Price As Double = 0

    Private Sub frmItemUnitMeasurePriceLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMaterialSkin(Me)
        ComboBoxLoad(cmbPriceLevel, "select ID,DESCRIPTION from price_level where INACTIVE = '0'", "ID", "DESCRIPTION")
        cmbPriceLevel.SelectedValue = iPrice_Level_id
        numCustomprice.Value = iCustomer_Price
        bSave = False

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        bSave = True
        iPrice_Level_id = cmbPriceLevel.SelectedValue
        iCustomer_Price = numCustomprice.Value
        Me.Close()
    End Sub
End Class