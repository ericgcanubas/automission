
Public Class FrmItemUnitMeasurePriceLevel
    Public bSave As Boolean
    Public iPrice_Level_id As Integer = 0
    Public iCustomer_Price As Double = 0

    Private Sub FrmItemUnitMeasurePriceLevel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GS_ComboBoxLoad(cmbPriceLevel, "select ID,DESCRIPTION from price_level where INACTIVE = '0'", "ID", "DESCRIPTION")
        cmbPriceLevel.SelectedValue = iPrice_Level_id
        numCustomprice.Value = iCustomer_Price
        bSave = False

    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        bSave = True
        iPrice_Level_id = cmbPriceLevel.SelectedValue
        iCustomer_Price = numCustomprice.Value
        Me.Close()
    End Sub
End Class