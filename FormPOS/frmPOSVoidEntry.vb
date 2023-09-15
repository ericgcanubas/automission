Imports System.Data.Odbc
Public Class FrmPOSVoidEntry
    Public gsGotVoid As Boolean


    Private Sub FrmPOSVoidEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()

        gsGotVoid = False
    End Sub
    Private Sub RefreshData()
        If gsPOSVoidEntry = True Then
            btnVOID.Text = "Void"
        Else
            btnVOID.Text = "Delete"
        End If

        GS_LoadDataGridView(dgvSalesReceiptList, $"select s.id,s.Date,s.Code,s.customer_id,c.NAME as `Customer`,s.PAYMENT_REF_NO as `O.R`,pm.description  as `Payment Method`, format( s.Amount,2) as `Total`,dst.Description as `Status` from sales_receipt as s inner join contact as c on c.id = s.customer_id inner join `payment_method` as pm on pm.id = s.payment_method_id  inner join document_status_map as dst on dst.id = s.STATUS  where s.POS_LOG_ID = '{gsPOS_LOG_ID}' and s.CASHIER_ID ='{gsCashier_ID}' and s.LOCATION_ID = '{gsDefault_LOCATION_ID}'   ")
        dgvSalesReceiptList.Columns(0).Visible = False
        dgvSalesReceiptList.Columns("customer_id").Visible = False
    End Sub
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
        Dim prFile_name As String = ""
        Dim prPrint_Title As String = ""
        Try
            cn.Open()
            Dim r As OleDb.OleDbDataReader = DbAccessReader("select [file_name],[print_title] from tblprint  where [form_name] = 'frmSalesReceipt' and  [print_default] = '1' ", cn)
            If r.Read Then
                prPrint_Title = r("print_title")
                prFile_name = r("file_name")
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        dgvSalesReceiptList.Select()
        Dim ThisID As Integer = dgvSalesReceiptList.CurrentRow.Cells(0).Value
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, Val(ThisID), "myid")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")
        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

        gsToolPanelView = False
        FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
        FrmReportViewer.Text = "POS Log " & GetDateTimeNowSql()
        FrmReportViewer.WindowState = FormWindowState.Maximized
        FrmReportViewer.ShowDialog()
        FrmReportViewer.Dispose()
    End Sub

    Private Sub BtnVOID_Click(sender As Object, e As EventArgs) Handles btnVOID.Click
        If dgvSalesReceiptList.Rows.Count <> 0 Then
            If SecurityAccessDelete(FrmSalesReceipt) = False Then

                Exit Sub
            End If

            If dgvSalesReceiptList.CurrentRow.Cells("Status").Value = "Void" Then
                PrompNotify(Me.Text, "Invalid entry already void.", False)
                Exit Sub
            End If

            If MessageBoxQuestion($"Do you want {btnVOID.Text.ToLower} this entry?") = True Then
                Dim ThisID As Integer
                Dim ThisDate As Date
                Dim UNDEPOSITED_FUNDS_ACCOUNT_ID As Integer
                Dim OUTPUT_TAX_ACCOUNT_ID As Integer = 0
                dgvSalesReceiptList.Select()
                With dgvSalesReceiptList.CurrentRow
                    ThisID = Val(.Cells(0).Value)
                    ThisDate = CDate(.Cells("Date").Value)

                    Dim rd As OdbcDataReader = SqlReader($"SELECT UNDEPOSITED_FUNDS_ACCOUNT_ID,OUTPUT_TAX_ACCOUNT_ID from sales_receipt WHERE `id` = '{ThisID}' and location_id = '{gsDefault_LOCATION_ID}' limit 1;")
                    If rd.Read Then
                        UNDEPOSITED_FUNDS_ACCOUNT_ID = GF_NumIsNull(rd("UNDEPOSITED_FUNDS_ACCOUNT_ID"))
                        OUTPUT_TAX_ACCOUNT_ID = GF_NumIsNull(rd("OUTPUT_TAX_ACCOUNT_ID"))
                    End If
                    rd.Close()
                    Dim rd_item As OdbcDataReader = SqlReader($"select s.id,s.item_id,i.type,i.GL_ACCOUNT_ID,i.COGS_ACCOUNT_ID,i.ASSET_ACCOUNT_ID from sales_receipt_items as s inner join item as i on i.id = s.item_id where sales_receipt_id = '{ThisID}' limit 1;")
                    While rd_item.Read
                        RemoveMoreReference(rd_item("type"), rd_item("id"), ThisDate, rd_item("item_id"), gsDefault_LOCATION_ID, GF_NumIsNull(rd_item("GL_ACCOUNT_ID")), GF_NumIsNull(rd_item("ASSET_ACCOUNT_ID")), GF_NumIsNull(rd_item("COGS_ACCOUNT_ID")))
                        'ReCalculateInventory(GF_NumIsNull(rd_item("ITEM_ID")), gsDefault_LOCATION_ID, ThisDate.AddDays(-1))

                    End While
                    rd_item.Close()

                    If gsSkipJournalEntry = False Then


                        GS_AccountJournalDelete(Val(UNDEPOSITED_FUNDS_ACCOUNT_ID), gsDefault_LOCATION_ID, 52, ThisID, ThisDate)
                        If GF_NumIsNull(OUTPUT_TAX_ACCOUNT_ID) <> 0 Then
                            GS_AccountJournalDelete(Val(OUTPUT_TAX_ACCOUNT_ID), gsDefault_LOCATION_ID, 52, ThisID, ThisDate)
                        End If

                    End If

                    If gsPOSVoidEntry = False Then

                        SqlExecuted($"DELETE FROM sales_receipt_items WHERE sales_receipt_id = '{ThisID}';")

                        SqlExecuted("DELETE FROM sales_receipt  WHERE `ID` ='" & ThisID & "' limit 1;")

                    Else

                        SqlExecuted("UPDATE sales_receipt SET `STATUS` = '7' WHERE `ID` ='" & ThisID & "' limit 1;")
                    End If



                    SetTransactionLog(ThisID, .Cells("Code").Value, 7, "Void", .Cells("customer_id").Value, "", GF_NumIsNull(.Cells("Total").Value), gsDefault_LOCATION_ID)
                End With
                RefreshData()
                gsGotVoid = True
            End If
        End If


    End Sub
    Private Sub RemoveMoreReference(ByVal ItemType As Integer, ByVal SALES_RECEIPT_ITEM_ID As Integer, ByVal DT As Date, ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal INCOME_ACCOUNT_ID As Integer, ByVal ASSET_ACCOUNT_ID As Integer, ByVal COGS_ACCOUNT_ID As Integer)

        If ItemType = 0 Or ItemType = 1 Then
            GS_ItemInventoryRemove(13, SALES_RECEIPT_ITEM_ID, DT, ITEM_ID, LOCATION_ID)
        End If

        If gsSkipJournalEntry = False Then
            'INCOME ACCOUNT ID
            GS_AccountJournalDelete(INCOME_ACCOUNT_ID, LOCATION_ID, 53, SALES_RECEIPT_ITEM_ID, DT)
            If ItemType = 0 Or ItemType = 1 Then
                'ITEM INVENTORY/ ASSEMBLY
                'COST ONLY
                'ASSET_ACCOUNT_ID
                GS_AccountJournalDelete(ASSET_ACCOUNT_ID, LOCATION_ID, 53, SALES_RECEIPT_ITEM_ID, DT)
                'COGS_ACCOUNT_ID
                GS_AccountJournalDelete(COGS_ACCOUNT_ID, LOCATION_ID, 53, SALES_RECEIPT_ITEM_ID, DT)
            End If
        End If

    End Sub
    Private Sub BtnCLOSE_Click(sender As Object, e As EventArgs) Handles btnCLOSE.Click
        Me.Close()
    End Sub


End Class