Module modAddExpenses
    Public Sub fAddRow_Data_Expenses(ByVal gsDGV As DataGridView, ByVal pradd As Boolean, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prTax As Boolean, ByVal prParticular As String, ByVal prClass_ID As String, ByVal prControl_Status As String)
        Dim sAccount_Name As String = fGetFieldValue("account", "ID", prAccount_ID, "NAME")
        Dim sclass_name As String = fGetFieldValue("class", "ID", prClass_ID, "NAME")
        Dim taxable_amount As Double = 0
        Dim tax_amount As Double = 0
        If pradd = True Then
            gsDGV.Rows.Add("N", sAccount_Name, fNumFormatStandard(prAmount), prTax, taxable_amount, tax_amount, prParticular, sclass_name, prClass_ID, prControl_Status, prAccount_ID)
            gsDGV.CurrentCell = gsDGV.Rows(gsDGV.Rows.Count - 1).Cells(fColVis(gsDGV))
        Else
            With gsDGV.Rows(gsDGV.CurrentRow.Index)
                .Cells("Account").Value = sAccount_Name
                .Cells("Amount").Value = fNumFormatStandard(prAmount)
                .Cells("Tax").Value = prTax
                .Cells("Taxable_Amount").Value = taxable_amount
                .Cells("Tax_Amount").Value = tax_amount
                .Cells("Particular").Value = prParticular
                .Cells("Class").Value = sclass_name
                .Cells("Class_ID").Value = prClass_ID
                .Cells("CONTROL_STATUS").Value = prControl_Status
                .Cells("Account_ID").Value = prAccount_ID
            End With
        End If
    End Sub
End Module
