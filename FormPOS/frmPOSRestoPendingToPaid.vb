Imports System.Data.Odbc
Public Class FrmPOSRestoPendingToPaid
    Public gsID As Integer
    Public gsClickOK As Boolean = False
    Private Sub FrmPOSRestoPendingToPaid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsClickOK = False
        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        Dim rd As OdbcDataReader = SqlReader($"select  * from `invoice` where id = '{gsID}' LIMIT 1;")
        If rd.Read Then
            lblCODE.Text = GF_TextIsNull(rd("CODE"))
            lblAMOUNT.Text = NumberFormatStandard(GF_NumIsNull(rd("AMOUNT")))
            cmbCUSTOMER_ID.SelectedValue = GF_NumIsNull(rd("CUSTOMER_ID"))
        End If
        rd.Close()
    End Sub
    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        gsClickOK = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If GF_NumIsNull(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If
        If Trim(txtNOTE.Text) = "" Then
            MessageBoxInfo("Please enter notes/ remarks")
            Exit Sub
        End If

        SqlExecuted($"UPDATE invoice SET CUSTOMER_ID = '{cmbCUSTOMER_ID.SelectedValue}',STATUS='1',STATUS_DATE='{GetDateFormatMySql(Date.Now.Date)}',NOTES='{txtNOTE.Text.Replace("'", "`")}' WHERE ID = '{gsID}' limit 1;")

        GetUpdateSO_UsingINVOICE(gsID)

        gsClickOK = True
        Me.Close()

    End Sub
    Private Sub GetUpdateSO_UsingINVOICE(ByVal INVOICE_ID As Integer)
        Dim TMP_SO_ID As Integer = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT soi.`SALES_ORDER_ID` FROM invoice_items AS ii INNER JOIN sales_order_items AS soi ON soi.`ID` = ii.`REF_LINE_ID`  AND ii.`ITEM_ID` = soi.`ITEM_ID` WHERE ii.`INVOICE_ID` ='{INVOICE_ID}' order by soi.`SALES_ORDER_ID`")
        While rd.Read
            If TMP_SO_ID <> GF_NumIsNull(rd("SALES_ORDER_ID")) Then
                SqlExecuted($"UPDATE sales_order SET STATUS ='14',STATUS_DATE= '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}' WHERE ID ='{GF_NumIsNull(rd("SALES_ORDER_ID"))}' limit 1;")
            End If

            TMP_SO_ID = GF_NumIsNull(rd("SALES_ORDER_ID"))
        End While
        rd.Close()



    End Sub
    Private Sub BtnCUSTOMER_Click(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
        Dim bNewContact As Boolean = False
        FrmPOSContacts.gsContact_Type = 1
        FrmPOSContacts.ShowDialog()
        If FrmPOSContacts.gsOK = True Then
            GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
            cmbCUSTOMER_ID.SelectedValue = FrmPOSContacts.gsContact_ID
        Else
            bNewContact = FrmPOSContacts.gsNewContact
        End If
        FrmPOSContacts.Dispose()
        FrmPOSContacts = Nothing

        If bNewContact = True Then
            FrmContactDetails.IsNew = True
            FrmContactDetails.ContactTypeId = 1
            FrmContactDetails.ShowDialog()
            If FrmContactDetails.gsOK = True Then
                GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = FrmContactDetails.ID
            End If
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
        End If
    End Sub
    Private Sub TxtNOTE_Click(sender As Object, e As EventArgs) Handles txtNOTE.Click
        KeyBoardToTouch(txtNOTE, "Please enter Notes/Remarks")

    End Sub
    Private Sub CmbCUSTOMER_ID_Click(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.Click
        cmbCUSTOMER_ID.DroppedDown = True
    End Sub
End Class