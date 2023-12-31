﻿Imports System.Data.Odbc
Public Class FrmCreditMemoInvoice
    Public gsID As String
    Public gsCustomer_ID As Integer
    Public gsLocation_ID As Integer
    Public gsOk As Boolean = False

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Computed()

        Dim credit_amount As Double = NumberFormatFixed(lblCreditAmount.Text)

        Dim total_amt As Double = 0

        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            total_amt += NumberFormatFixed(dgvAvailable.Rows(i).Cells("Amount_applied").Value)
        Next

        Dim remaining As Double = credit_amount - total_amt
        lblRemainingCredit.Text = NumberFormatStandard(remaining)
        lblTotal.Text = NumberFormatStandard(total_amt)

    End Sub


    Private Sub FrmCreditMemoInvoice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim chk As New DataGridViewCheckBoxColumn With {
            .Name = "select",
            .HeaderText = " "
        }

        With dgvAvailable.Columns
            .Add("invoice_id", "invoice_id")
            .Item("invoice_id").Visible = False
            .Add(chk)
            .Add("Date", "DATE")
            .Add("Number", "REFERENCE")
            .Add("Amount", "AMOUNT")
            .Item("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount").DefaultCellStyle.Format = "N2"
            .Add("Balance_Due", "UNPAID AMOUNT")
            .Item("Balance_Due").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Balance_Due").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Balance_Due").DefaultCellStyle.Format = "N2"

            .Add("Amount_applied", "CREDIT APPLIED")
            .Item("Amount_applied").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount_applied").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount_applied").DefaultCellStyle.Format = "N2"

        End With


        LoadInvoiceList()
        Computed()

    End Sub
    Private Sub LoadInvoiceList()
        dgvAvailable.Rows.Clear()
        Dim sQuery As String = "SELECT 
  i.id AS invoice_id,
  i.date,
  i.code,
  i.amount,
  i.balance_due 
FROM
  invoice AS i 
WHERE i.`CUSTOMER_ID` = '" & gsCustomer_ID & "' 
  AND i.`BALANCE_DUE` > '0' 
UNION
SELECT 
  i.id AS invoice_id,
  i.date,
  i.code,
  i.amount,
  i.balance_due 
FROM
  invoice AS i 
  INNER JOIN credit_memo_invoices AS c 
    ON i.`ID` = c.`INVOICE_ID` AND c.credit_memo_id ='" & gsID & "' 
WHERE i.customer_id = '" & gsCustomer_ID & "'  and i.location_id = '" & gsLocation_ID & "'"



        Try
            Dim bSelected As Boolean

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                Dim credit_applied As Double = GF_GetSumCreditApplied(rd("invoice_id"), gsCustomer_ID)


                If credit_applied = 0 Then
                    bSelected = False
                Else
                    bSelected = True
                End If

                dgvAvailable.Rows.Add(rd("invoice_id"), bSelected, Format(rd("date"), "MM/dd/yyyy"), rd("code"), NumberFormatStandard(rd("amount")), GF_NumIsNull(rd("balance_due")) + credit_applied, Format(credit_applied, "Standard"))

            End While



            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then

            Else
                End
            End If
        End Try


    End Sub
    Private Sub SelectedClick(ByVal Index As Integer)
        Try
            Dim bseleted As Boolean = dgvAvailable.Rows(Index).Cells("select").Value

            If bseleted = False Then

                Dim invoice_balance As Double = dgvAvailable.Rows(Index).Cells("balance_due").Value
                Dim credit_balance As Double = 0
                Dim total_amt As Double = 0
                Dim credit_amt As Double = NumberFormatFixed(lblCreditAmount.Text)

                For i As Integer = 0 To dgvAvailable.Rows.Count - 1
                    total_amt += dgvAvailable.Rows(i).Cells("Amount_applied").Value
                Next


                credit_balance = credit_amt - total_amt

                With dgvAvailable.Rows(Index)


                    If credit_balance > invoice_balance Then
                        .Cells("select").Value = True
                        .Cells("Amount_applied").Value = Format(invoice_balance, "Standard")
                    Else
                        If credit_balance <= 0 Then
                            Exit Sub
                        Else

                            .Cells("select").Value = True
                            .Cells("Amount_applied").Value = Format(credit_balance, "Standard")
                        End If
                    End If
                End With
            Else
                With dgvAvailable.Rows(Index)
                    .Cells("select").Value = False
                    .Cells("Amount_applied").Value = Format(0, "Standard")
                End With

            End If

            Computed()
        Catch ex As Exception

        End Try
    End Sub


    Private Sub DgvAvailable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellClick
        If dgvAvailable.Rows.Count = 0 Then Exit Sub
        If e.ColumnIndex = 1 Then
            SelectedClick(e.RowIndex)
        End If



    End Sub
    Private Function SetCreditMemoInvoice(ByVal bSelected As Boolean, ByVal amt_appled As Double, ByVal prInvoice_id As String) As Boolean
        Dim bUpdate As Boolean = False
        Try
            Dim rd_check As OdbcDataReader = SqlReader("select AMOUNT_APPLIED as a from credit_memo_invoices where CREDIT_MEMO_ID ='" & gsID & "' and INVOICE_ID = '" & prInvoice_id & "' ")
            If rd_check.Read Then
                If bSelected = True Then
                    'UPDATE
                    If amt_appled <> rd_check("a") Then
                        SqlExecuted("UPDATE credit_memo_invoices set AMOUNT_APPLIED ='" & amt_appled & "' Where  CREDIT_MEMO_ID = '" & gsID & "' and INVOICE_ID = '" & prInvoice_id & "'")
                        bUpdate = True

                    End If

                Else
                    'DELETE
                    SqlExecuted("DELETE FROM credit_memo_invoices Where  CREDIT_MEMO_ID = '" & gsID & "' and INVOICE_ID = '" & prInvoice_id & "'")
                    bUpdate = True
                End If
            Else
                'INSERT
                If bSelected = True Then
                    Dim i_ID As Double = ObjectTypeMapId("credit_memo_invoices")
                    SqlExecuted("INSERT INTO credit_memo_invoices set ID ='" & i_ID & "', CREDIT_MEMO_ID = '" & gsID & "',INVOICE_ID = '" & prInvoice_id & "' , AMOUNT_APPLIED ='" & amt_appled & "'")


                    bUpdate = True
                End If

            End If

            rd_check.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                bUpdate = SetCreditMemoInvoice(bSelected, amt_appled, prInvoice_id)
            Else
                End
            End If

        End Try


        Return bUpdate
    End Function

    Private Sub InvoiceBalanceUpdate(ByVal gsInvoice As String, prORG_Amount As Double)

        Dim total_pay As Double = GF_GetSumPaymentApplied(gsInvoice, gsCustomer_ID) + GF_GetSumCreditApplied(gsInvoice, gsCustomer_ID) + GF_InvoiceSumTaxApplied_Amount(gsInvoice, gsCustomer_ID)
        Dim New_Balance As Double = prORG_Amount - total_pay

        Dim squery As String

        Dim nStatus As Integer
        If 0 >= New_Balance Then
            nStatus = 11
        Else
            nStatus = 2
        End If
        squery = "UPDATE invoice SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsInvoice & "'"
        SqlExecuted(squery)

    End Sub

    Private Sub FrmCreditMemoInvoice_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        GS_ViewNotSort(dgvAvailable)
        dgvAvailable.Columns("Select").Width = 50
    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If dgvAvailable.Rows.Count = 0 Then
            MessageBoxWarning("Invoice not found!")
            Exit Sub
        End If



        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            With dgvAvailable.Rows(i)
                If SetCreditMemoInvoice(.Cells(1).Value, NumberFormatFixed(.Cells("Amount_applied").Value), .Cells(0).Value) = True Then
                    InvoiceBalanceUpdate(.Cells(0).Value, .Cells("Amount").Value)
                End If

            End With
        Next

        gsOk = True
        Me.Close()
    End Sub
End Class