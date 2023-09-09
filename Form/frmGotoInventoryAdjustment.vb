Public Class FrmGotoInventoryAdjustment
    Public gsCLick As Boolean = False
    Private Sub FrmGotoInventoryAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbADJUSTMENT_TYPE_ID, "select ID,DESCRIPTION FROM inventory_adjustment_type ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbLOCATION_ID, "Select * from location", "ID", "NAME")

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        dtpDATE.Value = TransactionDefaultDate()
    End Sub

    Private Sub btnGoto_Click(sender As Object, e As EventArgs) Handles btnGoto.Click

        gsMenuSubID = "25"
        gsRefresh = True
        MenuSet()

        gsBIR_Active = True
        gsBIR_Date = dtpDATE.Value
        gsBIR_Adjustment_Type_ID = cmbADJUSTMENT_TYPE_ID.SelectedValue
        gsBIR_LOCATION_ID = cmbLOCATION_ID.SelectedValue
        gsDocument_Finder_ID = 0
        gsRefresh = True
        gsCLick = True
        MenuSet()
        Me.Close()


    End Sub
End Class