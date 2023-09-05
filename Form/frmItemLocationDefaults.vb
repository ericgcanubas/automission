Public Class frmItemLocationDefaults
    Public bSave As Boolean
    Public purchase_id As Integer = 0
    Public sales_id As Integer = 0
    Public ship_id As Integer = 0
    Public dLocation As String = ""
    Private Sub frmItemLocationDefaults_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMaterialSkin(Me)
        Dim sQuery As String = " SELECT '0' AS `ID`, '' AS `NAME` UNION SELECT ID,`NAME` FROM unit_of_measure WHERE inactive ='0'"
        lblLocation.Text = dLocation
        fComboBox(cmbPurchases, sQuery, "ID", "NAME")
        fComboBox(cmbSales, sQuery, "ID", "NAME")
        fComboBox(cmbShipping, sQuery, "ID", "NAME")

        cmbPurchases.SelectedValue = purchase_id
        cmbSales.SelectedValue = sales_id
        cmbShipping.SelectedValue = ship_id
        bSave = False

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        purchase_id = fNumisNULL(cmbPurchases.SelectedValue)
        sales_id = fNumisNULL(cmbSales.SelectedValue)
        ship_id = fNumisNULL(cmbShipping.SelectedValue)
        If purchase_id = 0 And sales_id = 0 And ship_id = 0 Then

        Else
            If purchase_id = 0 Then
                fMessageboxWarning("Please select purchese unit")
                Exit Sub
            ElseIf sales_id = 0 Then
                fMessageboxWarning("Please select sales unit")
                Exit Sub
            ElseIf ship_id = 0 Then
                fMessageboxWarning("Please select shipping unit")
                Exit Sub
            End If
        End If
        Me.Close()
        bSave = True
    End Sub
End Class