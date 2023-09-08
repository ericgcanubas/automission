Imports System.Data.Odbc
Public Class FrmApplyCredits
    Public gsID As String 'Invoice Id
    Public gsCustomer_ID As Integer
    Public gsLocation_ID As Integer
    Public gsOk As Boolean = False
    Public gsBalance As Double = 0
    Private Sub fRefreshCredit()
        '   Dim cn As New MySqlConnection(mysqlConstr)
        Dim sQuery As String = "SELECT 
  m.id AS credit_memo_id,
  m.date,
  m.code,
  m.amount
FROM
  credit_memo AS m 
WHERE m.`CUSTOMER_ID` = '" & gsCustomer_ID & "' 
  AND (m.amount - m.amount_applied) > '0' 

UNION

SELECT 
  m.id AS credit_memo_id,
  m.date,
  m.code,
  m.amount

FROM
  credit_memo AS m 
    INNER JOIN credit_memo_invoices AS c 
    ON m.`ID` = c.`credit_memo_id` AND  c.invoice_id ='" & gsID & "' 
WHERE m.customer_id = '" & gsCustomer_ID & "' and m.LOCATION_ID = '" & gsLocation_ID & "'"

        Try
            Dim bSelected As Boolean
            '   cn.Open()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                Dim other_applied As Double = fGetCreditOtherInvoice(rd("credit_memo_id"), gsID)
                Dim credit_amount As Double = NumIsNull(rd("amount")) - other_applied
                Dim credit_applied As Double = fGetCreditApplied_Invoice(rd("credit_memo_id"), gsCustomer_ID, gsID)

                Dim credit_balance As Double = 0

                If credit_applied = 0 Then
                    bSelected = False
                Else

                    bSelected = True
                End If

                credit_balance = NumberFormatFixed(credit_amount - credit_applied)
                dgvAvailable.Rows.Add(rd("credit_memo_id"), bSelected, DateFormatStandard(rd("date")), rd("code"), NumberFormatStandard(credit_amount), NumberFormatStandard(credit_applied), NumberFormatStandard(credit_balance))
            End While
            rd.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshCredit()
            Else
                End
            End If
        End Try
    End Sub

    Private Sub frmApplyCredits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim chk As New DataGridViewCheckBoxColumn
        chk.Name = "select"
        chk.HeaderText = " "
        With dgvAvailable.Columns

            .Add("credit_memo_id", "credit_memo_id")
            .Item("credit_memo_id").Visible = False

            .Add(chk)


            .Add("Date", "DATE")


            .Add("Number", "REFERENNCE")


            .Add("credit_amount", "CREDIT AMOUNT")
            .Item("credit_amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("credit_amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("credit_amount").DefaultCellStyle.Format = "N2"

            .Add("credit_used", "CREDIT USED")
            .Item("credit_used").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("credit_used").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("credit_used").DefaultCellStyle.Format = "N2"

            .Add("credit_balance", "CREDIT BALANCE")
            .Item("credit_balance").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("credit_balance").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("credit_balance").DefaultCellStyle.Format = "N2"

        End With

        fRefreshCredit()
        lblDISCOUNT_USED.Text = NumberFormatStandard(fGetSumPaymentApplied(gsID, gsCustomer_ID))
        lblAmount_Due.Text = NumberFormatStandard(gsBalance + fGetSumCreditApplied(gsID, gsCustomer_ID))
        fComputed()
        DatagridViewMode(dgvAvailable)
    End Sub

    Private Sub fComputed()

        Dim balance_due As Double = 0
        Dim Amount_due As Double = NumberFormatFixed(lblAmount_Due.Text)
        Dim credit_applied As Double = 0
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            credit_applied = credit_applied + NumberFormatFixed(dgvAvailable.Rows(i).Cells("credit_used").Value)
        Next
        balance_due = Amount_due - credit_applied

        lblCreditUsed.Text = NumberFormatStandard(credit_applied)
        lblBalance_Due.Text = NumberFormatStandard(balance_due)
        lblTotal.Text = NumberFormatStandard(credit_applied)
    End Sub
    Private Sub tsOk_Click(sender As Object, e As EventArgs)



    End Sub
    Private Function fSetCredit_Memo_invoice(ByVal bSelected As Boolean, ByVal amt_appled As Double, ByVal prCredit_Memo_ID As String) As Boolean
        Dim bUpdate As Boolean = False

        Try


            Dim rd_check As OdbcDataReader = SqlReader("select AMOUNT_APPLIED as a from credit_memo_invoices where CREDIT_MEMO_ID ='" & prCredit_Memo_ID & "' and INVOICE_ID = '" & gsID & "' ")

            If rd_check.Read Then
                If bSelected = True Then
                    'UPDATE
                    If amt_appled <> rd_check("a") Then
                        SqlExecuted("UPDATE credit_memo_invoices set AMOUNT_APPLIED ='" & amt_appled & "' Where  CREDIT_MEMO_ID = '" & prCredit_Memo_ID & "' and INVOICE_ID = '" & gsID & "'")
                        bUpdate = True
                    End If
                Else
                    'DELETE
                    SqlExecuted("DELETE FROM credit_memo_invoices Where  CREDIT_MEMO_ID = '" & prCredit_Memo_ID & "' and INVOICE_ID = '" & gsID & "'")
                    bUpdate = True
                End If
            Else
                'INSERT
                If bSelected = True Then
                    SqlExecuted("INSERT INTO credit_memo_invoices set ID ='" & GetMaxField("ID", "credit_memo_invoices") & "', CREDIT_MEMO_ID = '" & prCredit_Memo_ID & "',INVOICE_ID = '" & gsID & "',AMOUNT_APPLIED ='" & amt_appled & "'")
                    bUpdate = True
                End If

            End If

            rd_check.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                bUpdate = fSetCredit_Memo_invoice(bSelected, amt_appled, prCredit_Memo_ID)
            Else
                End
            End If
        End Try


        Return bUpdate
    End Function


    Private Sub fCredit_Memo_Balance_Update(ByVal prCredit_Memo_ID As String, prORG_Amount As Double)

        Dim total_pay As Double = fGetCreditApplied_Invoice(prCredit_Memo_ID, gsCustomer_ID, gsID) + fGetCreditOtherInvoice(prCredit_Memo_ID, gsID)

        Dim New_Balance As Double = prORG_Amount - total_pay


        Dim nStatus As Integer = 0
        If 0 >= New_Balance Then
            nStatus = 15
        Else
            nStatus = 2
        End If

        Dim squery As String = "UPDATE credit_memo SET AMOUNT_APPLIED ='" & total_pay & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & prCredit_Memo_ID & "'"
        SqlExecuted(squery)

    End Sub

    Private Sub tsCancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvAvailable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellContentClick

    End Sub

    Private Sub dgvAvailable_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellDoubleClick

    End Sub

    Private Sub dgvAvailable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellClick
        If dgvAvailable.Rows.Count = 0 Then Exit Sub
        If e.ColumnIndex = 1 Then

            fSelected_click(e.RowIndex)
        End If
    End Sub
    Private Sub fSelected_click(ByVal i_index As Integer)
        Try


            Dim bseleted As Boolean = dgvAvailable.Rows(i_index).Cells("select").Value

            If bseleted = False Then

                Dim invoice_balance As Double = NumberFormatFixed(lblBalance_Due.Text)
                Dim credit_balance As Double = 0
                Dim total_credit_used As Double = 0
                Dim credit_amt As Double = dgvAvailable.Rows(i_index).Cells("credit_amount").Value

                For i As Integer = 0 To dgvAvailable.Rows.Count - 1
                    total_credit_used = total_credit_used + dgvAvailable.Rows(i).Cells("credit_used").Value
                Next


                credit_balance = invoice_balance - total_credit_used

                With dgvAvailable.Rows(i_index)


                    If credit_balance > credit_amt Then
                        .Cells("select").Value = True
                        .Cells("credit_used").Value = NumberFormatStandard(credit_amt)
                        .Cells("credit_balance").Value = NumberFormatStandard(NumberFormatFixed(.Cells("credit_amount").Value) - credit_amt)
                    Else
                        If credit_balance <= 0 Then
                            Exit Sub
                        Else

                            .Cells("select").Value = True
                            .Cells("credit_used").Value = NumberFormatStandard(credit_balance)
                            .Cells("credit_balance").Value = NumberFormatStandard(NumberFormatFixed(.Cells("credit_amount").Value) - credit_balance)
                        End If
                    End If
                End With
            Else
                With dgvAvailable.Rows(i_index)
                    .Cells("select").Value = False
                    .Cells("credit_used").Value = NumberFormatStandard(0)
                    .Cells("credit_balance").Value = NumberFormatStandard(.Cells("credit_amount").Value)
                End With

            End If

            fComputed()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fSelected_click(i_index)
            Else
                End
            End If
        End Try
    End Sub

    Private Sub tsClear_Click(sender As Object, e As EventArgs)
        'For i As Integer = 0 To dgvAvailable.Rows.Count - 1
        '    If dgvAvailable.Rows(i).Cells(1).Value = True Then
        '        fSelected_click(i)
        '    End If
        'Next
    End Sub

    Private Sub tsApply_Click(sender As Object, e As EventArgs)
        'For i As Integer = 0 To dgvAvailable.Rows.Count - 1
        '    If dgvAvailable.Rows(i).Cells(1).Value = False Then
        '        fSelected_click(i)
        '    End If
        'Next
    End Sub

    Private Sub frmApplyCredits_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvAvailable)
        dgvAvailable.Columns("Select").Width = 50
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If dgvAvailable.Rows.Count = 0 Then
            MessageBoxWarning("Credit memo not found!")
            Exit Sub
        End If
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1

            With dgvAvailable.Rows(i)

                If fSetCredit_Memo_invoice(.Cells(1).Value, NumberFormatFixed(.Cells("credit_used").Value), .Cells(0).Value) = True Then

                    fCredit_Memo_Balance_Update(.Cells(0).Value, NumberFormatFixed(.Cells("credit_amount").Value))

                End If

            End With
        Next

        gsOk = True
        Me.Close()
    End Sub
End Class