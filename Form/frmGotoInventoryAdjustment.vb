Public Class FrmGotoInventoryAdjustment
    Public gsCLick As Boolean = False
    Private Sub FrmGotoInventoryAdjustment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fComboBox(cmbADJUSTMENT_TYPE_ID, "select ID,DESCRIPTION FROM inventory_adjustment_type ", "ID", "DESCRIPTION")
        fComboBox(cmbLOCATION_ID, "Select * from location", "ID", "NAME")

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub

    Private Sub btnGoto_Click(sender As Object, e As EventArgs) Handles btnGoto.Click

        gsMenuSubID = "25"
        gsRefresh = True
        fmenuSet()

        gsBIR_Active = True
        gsBIR_Date = dtpDATE.Value
        gsBIR_Adjustment_Type_ID = cmbADJUSTMENT_TYPE_ID.SelectedValue
        gsBIR_LOCATION_ID = cmbLOCATION_ID.SelectedValue
        gsDocument_Finder_ID = DateTime.Now
        gsRefresh = True
        gsCLick = True
        fmenuSet()
        Me.Close()


    End Sub
End Class