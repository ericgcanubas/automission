Public Class FrmDealerCustomerList
    Public gsDEALER_ID As String
    Private Sub frmDealerCustomerList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDataGridView(dgvProductItem, "select c.Account_No as `ACCT #`, c.`NAME` from contact as c where other_contact_id = '" & gsDEALER_ID & "' order by c.`name`")
    End Sub
End Class