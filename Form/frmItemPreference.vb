Public Class FrmItemPreference
    Public bSave As Boolean
    Public gsDescription As String
    Public gsOrderPoint As Double
    Public gsOrderQty As Double
    Public gsOrderLeadTime As Integer
    Public gsOnHandMaxLimit As Double
    Public gsStock As String
    Public gsStock_bin_id As String
    Private Sub frmItemPreference_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbBinStock, "select ID,DESCRIPTION from stock_bin", "ID", "DESCRIPTION")
        ClearAndRefresh(Me)
        lblDescription.Text = gsDescription
        numOrderPoint.Value = gsOrderPoint
        numOrderQty.Value = gsOrderQty
        numOrderLeadTime.Value = gsOrderLeadTime
        numOnHandMaxLimit.Value = gsOnHandMaxLimit
        cmbBinStock.SelectedValue = gsStock
        bSave = False
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        gsOrderPoint = numOrderPoint.Value
        gsOrderQty = numOrderQty.Value
        gsOrderLeadTime = numOrderLeadTime.Value
        gsOnHandMaxLimit = numOnHandMaxLimit.Value
        gsStock = cmbBinStock.SelectedText
        gsStock_bin_id = cmbBinStock.SelectedValue
        bSave = True
        Me.Close()
    End Sub
End Class