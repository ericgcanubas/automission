﻿Imports System.Data.Odbc
Public Class frmPOSRestoPendingToPaid
    Public gsID As Integer
    Public gsClickOK As Boolean = False
    Private Sub frmPOSRestoPendingToPaid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsClickOK = False
        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        Dim rd As OdbcDataReader = fReader($"select  * from `invoice` where id = '{gsID}' LIMIT 1;")
        If rd.Read Then
            lblCODE.Text = fTextisNULL(rd("CODE"))
            lblAMOUNT.Text = fNumFormatStandard(fNumisNULL(rd("AMOUNT")))
            cmbCUSTOMER_ID.SelectedValue = fNumisNULL(rd("CUSTOMER_ID"))
        End If
        rd.Close()
    End Sub
    Private Sub btnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        gsClickOK = False
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If fNumisNULL(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If
        If Trim(txtNOTE.Text) = "" Then
            fMessageboxInfo("Please enter notes/ remarks")
            Exit Sub
        End If

        fExecutedOnly($"UPDATE invoice SET CUSTOMER_ID = '{cmbCUSTOMER_ID.SelectedValue}',STATUS='1',STATUS_DATE='{fDateFormatMYSQL(Date.Now.Date)}',NOTES='{txtNOTE.Text.Replace("'", "`")}' WHERE ID = '{gsID}' limit 1;")

        fGetUpdateSO_UsingINVOICE(gsID)

        gsClickOK = True
        Me.Close()

    End Sub
    Private Sub fGetUpdateSO_UsingINVOICE(ByVal INVOICE_ID As Integer)
        Dim TMP_SO_ID As Integer = 0
        Dim rd As OdbcDataReader = fReader($"SELECT soi.`SALES_ORDER_ID` FROM invoice_items AS ii INNER JOIN sales_order_items AS soi ON soi.`ID` = ii.`REF_LINE_ID`  AND ii.`ITEM_ID` = soi.`ITEM_ID` WHERE ii.`INVOICE_ID` ='{INVOICE_ID}' order by soi.`SALES_ORDER_ID`")
        While rd.Read
            If TMP_SO_ID <> fNumisNULL(rd("SALES_ORDER_ID")) Then
                fExecutedOnly($"UPDATE sales_order SET STATUS ='14',STATUS_DATE= '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}' WHERE ID ='{fNumisNULL(rd("SALES_ORDER_ID"))}' limit 1;")
            End If

            TMP_SO_ID = fNumisNULL(rd("SALES_ORDER_ID"))
        End While
        rd.Close()



    End Sub
    Private Sub btnCUSTOMER_Click(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
        Dim bNewContact As Boolean = False
        frmPOSContacts.gsContact_Type = 1
        frmPOSContacts.ShowDialog()
        If frmPOSContacts.gsOK = True Then
            fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
            cmbCUSTOMER_ID.SelectedValue = frmPOSContacts.gsContact_ID
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing

        If bNewContact = True Then
            frmContactDetails.bNew = True
            '  frmContactDetails.PictureBox1.Image = tsCustomer.Image
            frmContactDetails.gsContact_Type = 1
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = frmContactDetails.gsID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub txtNOTE_TextChanged(sender As Object, e As EventArgs) Handles txtNOTE.TextChanged

    End Sub

    Private Sub txtNOTE_Click(sender As Object, e As EventArgs) Handles txtNOTE.Click
        fKeyBoardToTouch(txtNOTE, "Please enter Notes/Remarks")

    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged

    End Sub

    Private Sub cmbCUSTOMER_ID_Click(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.Click
        cmbCUSTOMER_ID.DroppedDown = True

    End Sub
End Class