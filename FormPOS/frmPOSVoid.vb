﻿Imports System.Data.Odbc
Public Class FrmPOSVoid
    Public gsGotVoid As Boolean
    Dim FirstLoad As Boolean = True
    Dim isVoidFunction As Boolean = False


    Private Sub FrmPOSVoid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstLoad = True
        '  Selector()
        gsGotVoid = False
        POS_PaymentLoad()
    End Sub
    Private Sub POS_PaymentLoad()
        GS_LoadDataGridView(dgvPAYMENT, $"SELECT P.ID,P.CODE as `REF No.`,P.RECEIPT_REF_NO as `OR No.`, PN.AMOUNT_APPLIED as `PAID` FROM PAYMENT as P INNER JOIN PAYMENT_INVOICES AS PN on PN.PAYMENT_ID = P.ID  WHERE P.LOCATION_ID = '{gsDefault_LOCATION_ID}' and P.POS_LOG_ID = '{gsPOS_LOG_ID}' ")
        dgvPAYMENT.Columns(0).Visible = False

        dgvPAYMENT.Columns("PAID").DefaultCellStyle.Format = "N2"
        dgvPAYMENT.Columns("PAID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPAYMENT.Columns("PAID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        POSTotal()

    End Sub

    Private Sub DtpDATE_ValueChanged(sender As Object, e As EventArgs)
        POS_PaymentLoad()

    End Sub
    Private Sub POSTotal()
        Dim P As Double = 0
        For N As Integer = 0 To dgvPAYMENT.Rows.Count - 1
            P += GF_NumIsNull(dgvPAYMENT.Rows(N).Cells("PAID").Value)
        Next
        lblSales.Text = NumberFormatStandard(P)

    End Sub

    Private Sub Selector()
        Dim ID As Integer = 0
        If dgvPAYMENT.Rows.Count <> 0 Then
            dgvPAYMENT.Select()

            With dgvPAYMENT.CurrentRow

                ID = .Cells(0).Value
                lblPAYMENT_CODE.Text = .Cells(1).Value
                lblOR.Text = .Cells(2).Value
                lblPAID.Text = NumberFormatStandard(.Cells("PAID").Value)
            End With


        Else
            ID = 0
            lblPAYMENT_CODE.Text = ""
            lblOR.Text = ""
            lblPAID.Text = "0.00"
        End If

        GS_LoadDataGridView(dgvITEM, $"select ii.id,ii.ITEM_ID,i.DESCRIPTION,ii.QUANTITY as `QTY`,ii.RATE,ii.AMOUNT from payment_invoices as pn inner join invoice_items as ii  on ii.invoice_id = pn.invoice_id inner join item as i on i.id = ii.item_id  where ii.PRINT_IN_FORMS = '0' and  pn.payment_id = '{ID}' limit 100")

        With dgvITEM.Columns
            .Item("ID").Visible = False
            .Item("ITEM_ID").Visible = False
            '  .Item("DESCRIPTION").Width = 150

            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("QTY").DefaultCellStyle.Format = "N0"
            .Item("QTY").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("QTY").Width = 40

            .Item("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("RATE").DefaultCellStyle.Format = "N2"
            .Item("RATE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("RATE").Width = 55

            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").Width = 70
        End With

    End Sub

    Private Sub FrmPOSVoid_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FirstLoad = False
        Selector()
    End Sub

    Private Sub BtnCLOSE_Click(sender As Object, e As EventArgs) Handles btnCLOSE.Click
        Me.Close()

    End Sub

    Private Sub BtnDELETE_Click(sender As Object, e As EventArgs) Handles btnDELETE.Click

        If dgvITEM.Rows.Count <> 0 Then

            If SecurityAccessDelete(FrmReceivePayment) = False Then
                Exit Sub
            End If

            With dgvPAYMENT.CurrentRow
                Dim ID As Integer = GF_NumIsNull(.Cells(0).Value)
                If MessageBoxPointOfSalesYesNO("Do you want to delete this record?") = True Then
                    PaymentDelete(ID)
                End If
            End With

        End If


    End Sub

    Private Sub DirectPrint(ByVal ThisID As Integer)
        If MessageBoxPointOfSalesYesNO($"Do you want to Print?") = True Then

            Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection)
            Dim prFile_name As String = gsPayment_File_Name '' "cryPOSRestoPayment.rpt"
            Dim prPrint_Title As String = gsPayment_Print_Title '' "OFFICIAL RECEIPT"


            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, ThisID, "id")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            ReportExporPDF(gscryRpt, prPrint_Title)

            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                FrmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
                FrmReportViewer.WindowState = FormWindowState.Normal
                FrmReportViewer.ShowDialog()
                FrmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If

        End If
    End Sub
    Private Sub PaymentDelete(ByVal prID As Integer)

        DirectPrint(prID)

        Dim Invoice_ID As Integer
        Dim rd As OdbcDataReader = SqlReader($"select * from payment_invoices where payment_id = '{prID}'")
        If rd.Read Then
            Invoice_ID = rd("INVOICE_ID")
            InvoicingVoid(Invoice_ID)


            If gsPOSVoidEntry = False Then

                SqlExecuted("DELETE FROM payment_invoices WHERE ID='" & rd("ID") & "' and PAYMENT_ID='" & prID & "' and INVOICE_ID='" & Invoice_ID & "'")

            End If


        End If
        rd.Close()

        If gsPOSVoidEntry = False Then
            SqlExecuted("DELETE FROM payment WHERE ID = '" & prID & "' limit 1;")

            SetTransactionLog(prID, lblPAYMENT_CODE.Text, 3, "Delete", gsPOSDefaultCustomer_ID, "", GF_NumIsNull(lblPAID.Text), gsDefault_LOCATION_ID)

        Else
            SqlExecuted("UPDATE payment SET STATUS ='7' WHERE ID = '" & prID & "' limit 1;")

            SetTransactionLog(prID, lblPAYMENT_CODE.Text, 3, "Void", gsPOSDefaultCustomer_ID, "", GF_NumIsNull(lblPAID.Text), gsDefault_LOCATION_ID)

        End If

        gsGotVoid = True

        POS_PaymentLoad()
        MessageBoxInfo("Successfully Remove.")
        If dgvPAYMENT.Rows.Count = 0 Then
            btnCLOSE.PerformClick()
        End If


    End Sub
    Private Sub InvoicingVoid(ByVal Invoice_ID As Integer)
        If Invoice_ID <> 0 Then
            Dim DT As Date = ""
            Dim Loc_ID As Integer = ""
            Dim INVOICE_CODE As String = ""
            Dim r As OdbcDataReader = SqlReader($"select * from invoice where id ='{Invoice_ID}' limit 1")
            If r.Read() Then
                DT = CDate(r("DATE"))
                Loc_ID = GF_NumIsNull(r("LOCATION_ID"))
                INVOICE_CODE = GF_NumIsNull(r("CODE"))
            End If
            r.Close()




            'Inventory re-Compute
            If gsSkipJournalEntry = False Then
                gsJOURNAL_NO_FORM = 0
                Dim Account_ID As Integer = GF_GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "ACCOUNTS_RECEIVABLE_ID")
                Dim Tax_Acct_ID As Integer = GF_GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "OUTPUT_TAX_ACCOUNT_ID")
                GS_AccountJournalDelete(Account_ID, Loc_ID, 23, Invoice_ID, DT)
                If Tax_Acct_ID <> 0 Then
                    GS_AccountJournalDelete(Tax_Acct_ID, Loc_ID, 23, Invoice_ID, DT)
                End If

            End If

            DeletePOSVoid_Invoice_Item(Invoice_ID, DT, Loc_ID)

            If gsPOSVoidEntry = True Then
                SqlExecuted("UPDATE invoice SET STATUS ='7' where `ID` ='" & Invoice_ID & "' limit 1;")
                SetTransactionLog(Invoice_ID, INVOICE_CODE, 2, "Void", Loc_ID, "", GF_NumIsNull(lblPAID.Text), gsDefault_LOCATION_ID)

            Else
                'Delete
                SqlExecuted("DELETE from invoice_items where INVOICE_ID  = '" & Invoice_ID & "'")
                SqlExecuted("DELETE from invoice where `ID` ='" & Invoice_ID & "' limit 1;")
                SetTransactionLog(Invoice_ID, INVOICE_CODE, 2, "Delete", Loc_ID, "", GF_NumIsNull(lblPAID.Text), gsDefault_LOCATION_ID)

            End If


            'End re-compute
        End If
    End Sub
    Private Sub DgvPAYMENT_SelectionChanged(sender As Object, e As EventArgs) Handles dgvPAYMENT.SelectionChanged
        If FirstLoad = True Then

        Else
            Selector()
        End If
    End Sub
    Private Sub DeletePOSVoid_Invoice_Item(ByVal INVOICE_ID As Integer, ByVal DT As Date, ByVal Loc_ID As Integer)


        Dim rd As OdbcDataReader = SqlReader($"select n.id,n.item_id,i.type,n.ASSET_ACCOUNT_ID,n.COGS_ACCOUNT_ID from invoice_items as n inner join item as i on i.id = n.item_id where n.invoice_ID ='{INVOICE_ID}'  limit 1;")

        While rd.Read
            If rd("type") = 0 Or rd("type") = 1 Then
                GS_ItemInventoryRemove(10, rd("id"), DT, rd("ITEM_ID"), Loc_ID)
            End If

            If gsSkipJournalEntry = False Then
                GS_AccountJournalDelete(GF_NumIsNull(rd("INCOME_ACCOUNT_ID")), Loc_ID, 24, rd("id"), DT)

                If rd("type") = 0 Or rd("type") = 1 Then
                    'ITEM INVENTORY/ ASSEMBLY
                    GS_AccountJournalDelete(GF_NumIsNull(rd("ASSET_ACCOUNT_ID")), Loc_ID, 24, rd("id"), DT)
                    GS_AccountJournalDelete(GF_NumIsNull(rd("COGS_ACCOUNT_ID")), Loc_ID, 24, rd("id"), DT)
                End If
            End If
        End While

    End Sub

End Class