Imports System.Data.Odbc
Public Class FrmDatabaseReset
    Private Sub FrmDatabaseReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkTableList.Items.Clear()
        Dim rd As OdbcDataReader = SqlReader("select description from document_type_map order by id")
        While rd.Read
            chkTableList.Items.Add(rd("description"), True)
        End While
        rd.Close()

    End Sub

    Private Sub BtnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
        For I As Integer = 0 To chkTableList.Items.Count - 1
            chkTableList.SetItemChecked(I, True)

        Next
    End Sub

    Private Sub BtnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click
        For I As Integer = 0 To chkTableList.Items.Count - 1
            chkTableList.SetItemChecked(I, False)
        Next
    End Sub

    Private Sub BtnRESET_Click(sender As Object, e As EventArgs) Handles btnRESET.Click

        If MessageBoxQuestion("Are you sure to reset this data?") = True Then


            For I As Integer = 0 To chkTableList.Items.Count - 1
                If chkTableList.GetItemChecked(I) = True Then
                    GS_DoEvents()
                    Dim DOC_ID As Integer = GetNumberFieldValue("DOCUMENT_TYPE_MAP", "DESCRIPTION", chkTableList.Items(I), "ID")

                    Dim rd_object As OdbcDataReader = SqlReader($"select * from object_type_map where DOCUMENT_TYPE ='{DOC_ID}' order by ID Desc  ")
                    While rd_object.Read
                        'JOURNAL
                        GS_DoEvents()
                        SqlExecuted($"DELETE FROM account_journal WHERE OBJECT_TYPE ='{rd_object("ID")}'")
                        'MAIN
                        GS_DoEvents()
                        SqlExecuted($"DELETE FROM `{rd_object("TABLE_NAME").ToString.ToLower()}` ")

                        If rd_object("TABLE_NAME") = "PAYMENT_INVOICES" Then

                            SqlExecuted($" TRUNCATE TABLE payment_multi_method;")

                        End If


                        'CODE
                        GS_DoEvents()
                        SqlExecuted($"UPDATE location_reference SET NEXT_CODE = '1' Where TABLE_NAME ='{rd_object("TABLE_NAME")}'")
                        'ID
                        GS_DoEvents()
                        SqlExecuted($"UPDATE object_type_map SET NEXT_ID = '1',NEXT_CODE='1' Where ID ='{rd_object("ID")}'")
                    End While
                    'INVENTORY
                    GS_DoEvents()

                    SqlExecuted($"DELETE FROM item_inventory WHERE SOURCE_REF_TYPE ='{DOC_ID}'")

                End If
            Next
            'INCLUDE
            If chkItem.Checked = True Then
                SqlExecuted($"DELETE FROM item_components")
                SqlExecuted($"DELETE FROM item where `type` not in ('4','5','7') ")
            End If
            If chkVendor.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='0' ")
            End If
            If chkCustomer.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='1' ")
            End If
            If chkEmployee.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='2' ")
            End If
            If chkTaxAgency.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='3' ")
            End If
            If chkOtherContacts.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='4' ")
            End If
            If chkManager.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='5' ")
            End If
            If chkDealer.Checked = True Then
                SqlExecuted($"DELETE FROM contact where `type` ='6' ")
            End If
            If chkTransactionLog.Checked = True Then
                SqlExecuted($"TRUNCATE TABLE transaction_log ")
            End If

            If chkUsers.Checked = True Then

                SqlExecuted($"TRUNCATE user_security_access ")
                SqlExecuted($"TRUNCATE TABLE user_default ")
                SqlExecuted($"TRUNCATE TABLE system_security ")
                SqlExecuted($"TRUNCATE TABLE user ")
                SqlExecuted($"UPDATE object_type_map SET NEXT_ID = '2',NEXT_CODE='1' Where ID ='89'")
                SqlExecuted($"INSERT INTO `backend_std`.`user`
            (`ID`,
             `NAME`,
             `DESCRIPTION`,
             `PASSWORD`,
             `PWD_CREATED_ON`,
             `PWD_NEVER_EXPIRES`,
             `TYPE`,
             `STATUS`,
             `CONTACT_ID`,
             `REGISTERED_BY_ID`,
             `REGISTERED_ON`,
             `LOCKOUT_COUNTER`,
             `LOCKOUT_ON`,
             `EXPIRATION_DATE`,
             `LOGIN_FAILED_ON`,
             `AUTHORIZED_PASSWORD`,
             `LOGIN_STATUS`)
VALUES ('1',
        'itme',
        'NRmacANXZLxcP3FyLn0u+fQEfntDUOQiRuhYv8lVjYc=',
        'PASSWORD',
        '{DateFormatMySql(Date.Now)}',
        null,
        '0',
        '0',
        null,
        null,
        null,
        null,
        null,
        null,
       null,
        '1',
        '0');")

            End If


            MessageBoxInfo("Successfully reset")
        End If
    End Sub
End Class