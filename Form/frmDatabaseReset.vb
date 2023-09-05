Imports System.Data.Odbc
Public Class frmDatabaseReset
    Private Sub frmDatabaseReset_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        chkTableList.Items.Clear()
        Dim rd As OdbcDataReader = fReader("select description from document_type_map order by id")
        While rd.Read
            chkTableList.Items.Add(rd("description"), True)
        End While
        rd.Close()

    End Sub

    Private Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
        For I As Integer = 0 To chkTableList.Items.Count - 1
            chkTableList.SetItemChecked(I, True)

        Next
    End Sub

    Private Sub btnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click
        For I As Integer = 0 To chkTableList.Items.Count - 1
            chkTableList.SetItemChecked(I, False)
        Next
    End Sub

    Private Sub btnRESET_Click(sender As Object, e As EventArgs) Handles btnRESET.Click

        If fMessageBoxQuestion("Are you sure to reset this data?") = True Then


            For I As Integer = 0 To chkTableList.Items.Count - 1
                If chkTableList.GetItemChecked(I) = True Then
                    fDoEvents()
                    Dim DOC_ID As Integer = fNumFieldValue("DOCUMENT_TYPE_MAP", "DESCRIPTION", chkTableList.Items(I), "ID")

                    Dim rd_object As OdbcDataReader = fReader($"select * from object_type_map where DOCUMENT_TYPE ='{DOC_ID}' order by ID Desc  ")
                    While rd_object.Read
                        'JOURNAL
                        fDoEvents()
                        fExecutedOnly($"DELETE FROM account_journal WHERE OBJECT_TYPE ='{rd_object("ID")}'")
                        'MAIN
                        fDoEvents()
                        fExecutedOnly($"DELETE FROM `{rd_object("TABLE_NAME").ToString.ToLower()}` ")

                        If rd_object("TABLE_NAME") = "PAYMENT_INVOICES" Then

                            fExecutedOnly($" TRUNCATE TABLE payment_multi_method;")

                        End If


                        'CODE
                        fDoEvents()
                        fExecutedOnly($"UPDATE location_reference SET NEXT_CODE = '1' Where TABLE_NAME ='{rd_object("TABLE_NAME")}'")
                        'ID
                        fDoEvents()
                        fExecutedOnly($"UPDATE object_type_map SET NEXT_ID = '1',NEXT_CODE='1' Where ID ='{rd_object("ID")}'")
                    End While
                    'INVENTORY
                    fDoEvents()

                    fExecutedOnly($"DELETE FROM item_inventory WHERE SOURCE_REF_TYPE ='{DOC_ID}'")

                End If
            Next
            'INCLUDE
            If chkItem.Checked = True Then
                fExecutedOnly($"DELETE FROM item_components")
                fExecutedOnly($"DELETE FROM item where `type` not in ('4','5','7') ")
            End If
            If chkVendor.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='0' ")
            End If
            If chkCustomer.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='1' ")
            End If
            If chkEmployee.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='2' ")
            End If
            If chkTaxAgency.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='3' ")
            End If
            If chkOtherContacts.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='4' ")
            End If
            If chkManager.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='5' ")
            End If
            If chkDealer.Checked = True Then
                fExecutedOnly($"DELETE FROM contact where `type` ='6' ")
            End If
            If chkTransactionLog.Checked = True Then
                fExecutedOnly($"TRUNCATE TABLE transaction_log ")
            End If

            fMessageboxInfo("Successfully reset")
        End If
    End Sub
End Class