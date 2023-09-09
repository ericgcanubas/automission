Imports System.Data.Odbc
Public Class FrmBillCreditBills
    Public gsID As String
    Public gsVendor_ID As Integer
    Public gsLocation_ID As Integer
    Public gsOk As Boolean = False

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Computed()

        Dim credit_amount As Double = NumberFormatFixed(lblCreditAmount.Text)
        Dim remaining As Double
        Dim total_amt As Double = 0

        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            total_amt += NumberFormatFixed(dgvAvailable.Rows(i).Cells("Amount_applied").Value)
        Next
        remaining = credit_amount - total_amt
        lblRemainingCredit.Text = NumberFormatStandard(remaining)
        lblTotal.Text = NumberFormatStandard(total_amt)

    End Sub


    Private Sub FrmBillCreditBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim chk As New DataGridViewCheckBoxColumn With {
            .Name = "select",
            .HeaderText = " "
        }

        With dgvAvailable.Columns
            .Add("bill_id", "bill_id")
            .Item("bill_id").Visible = False

            .Add(chk)

            .Add("Date", "DATE")
            .Add("Number", "REFERENCE")

            .Add("Amount", "ORG. AMOUNT")

            .Item("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount").DefaultCellStyle.Format = "N2"


            .Add("Balance_Due", "BALANCE DUE")
            .Item("Balance_Due").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Balance_Due").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Balance_Due").DefaultCellStyle.Format = "N2"

            .Add("Amount_applied", "AMT. APPLIED")
            .Item("Amount_applied").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount_applied").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Amount_applied").DefaultCellStyle.Format = "N2"

        End With

        LoadBillingList()
        Computed()
        DatagridViewMode(dgvAvailable)
    End Sub
    Private Sub LoadBillingList()
        dgvAvailable.Rows.Clear()
        Dim sQuery As String = "SELECT 
  i.id AS bill_id,
  i.date,
  i.code,
  i.amount,
  i.balance_due 
FROM
  bill AS i 
WHERE i.`VENDOR_ID` = '" & gsVendor_ID & "' 
  AND i.`BALANCE_DUE` > '0' 
UNION
SELECT 
  i.id AS bill_id,
  i.date,
  i.code,
  i.amount,
  i.balance_due 
FROM
  bill AS i 
  INNER JOIN bill_credit_bills AS c 
    ON i.`ID` = c.`BILL_ID` AND c.bill_credit_id ='" & gsID & "' 
WHERE i.VENDOR_ID = '" & gsVendor_ID & "' and i.location_id ='" & gsLocation_ID & "' "

        Try
            Dim bSelected As Boolean
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                Dim credit_applied As Double = GetBillSumCreditApplied(rd("bill_id"), gsVendor_ID)
                If credit_applied = 0 Then
                    bSelected = False
                Else
                    bSelected = True
                End If
                dgvAvailable.Rows.Add(rd("bill_id"), bSelected, DateFormatStandard(rd("date")), rd("code"), NumberFormatStandard(rd("amount")), NumberFormatStandard(rd("balance_due") + credit_applied), NumberFormatStandard(credit_applied))
            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                LoadBillingList()
            Else
                End
            End If

        End Try
    End Sub
    Private Sub SelectorClick(ByVal Index As Integer)
        Try
            Dim bseleted As Boolean = dgvAvailable.Rows(Index).Cells("select").Value
            If bseleted = False Then

                Dim bill_balance As Double = dgvAvailable.Rows(Index).Cells("balance_due").Value
                Dim credit_balance As Double = 0
                Dim total_amt As Double = 0
                Dim credit_amt As Double = NumberFormatFixed(lblCreditAmount.Text)
                For i As Integer = 0 To dgvAvailable.Rows.Count - 1
                    total_amt += dgvAvailable.Rows(i).Cells("amount_applied").Value
                Next
                credit_balance = credit_amt - total_amt
                With dgvAvailable.Rows(Index)
                    If credit_balance > bill_balance Then
                        .Cells("select").Value = True
                        .Cells("Amount_applied").Value = NumberFormatStandard(bill_balance)
                    Else
                        If credit_balance <= 0 Then
                            Exit Sub
                        Else
                            .Cells("select").Value = True
                            .Cells("Amount_applied").Value = NumberFormatStandard(credit_balance)
                        End If
                    End If
                End With
            Else
                With dgvAvailable.Rows(Index)
                    .Cells("select").Value = False
                    .Cells("Amount_applied").Value = NumberFormatStandard(0)
                End With
            End If
            Computed()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub DgvAvailable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellClick
        If dgvAvailable.Rows.Count = 0 Then Exit Sub
        If e.ColumnIndex = 1 Then
            SelectorClick(e.RowIndex)
        End If
    End Sub
    Private Function SetBillCreditFromBills(ByVal bSelected As Boolean, ByVal amt_appled As Double, ByVal prbill_ID As String) As Boolean
        Dim bUpdate As Boolean = False

        Try

            Dim rd_check As OdbcDataReader = SqlReader("select AMOUNT_APPLIED as a from bill_credit_bills where BILL_CREDIT_ID ='" & gsID & "' and BILL_ID = '" & prbill_ID & "' ")
            If rd_check.Read Then
                If bSelected = True Then
                    'UPDATE
                    If amt_appled <> rd_check("a") Then
                        SqlExecuted("UPDATE bill_credit_bills set AMOUNT_APPLIED ='" & amt_appled & "' Where  BILL_CREDIT_ID = '" & gsID & "' and BILL_ID = '" & prbill_ID & "'")
                        bUpdate = True
                    End If
                Else
                    'DELETE
                    SqlExecuted("DELETE FROM bill_credit_bills Where  BILL_CREDIT_ID = '" & gsID & "' and BILL_ID = '" & prbill_ID & "'")
                    bUpdate = True
                End If
            Else
                'INSERT
                If bSelected = True Then
                    Dim i_ID As Double = ObjectTypeMapId("bill_credit_bills")
                    SqlExecuted("INSERT INTO bill_credit_bills set ID ='" & i_ID & "', BILL_CREDIT_ID = '" & gsID & "',BILL_ID = '" & prbill_ID & "' , AMOUNT_APPLIED ='" & amt_appled & "'")
                    bUpdate = True
                End If

            End If

            rd_check.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                bUpdate = SetBillCreditFromBills(bSelected, amt_appled, prbill_ID)
            Else
                End
            End If
        End Try


        Return bUpdate
    End Function

    Private Sub SetBillBalanceUpdate(ByVal gsBill As String, prORG_Amount As Double)

        Dim total_pay As Double = GetBillSumPaymentApplied(gsBill, gsVendor_ID) + GetBillSumCreditApplied(gsBill, gsVendor_ID) + GetBillSumTaxAppliedAmount(gsBill, gsVendor_ID)
        Dim New_Balance As Double = prORG_Amount - total_pay
        Dim squery As String
        Dim nStatus As Integer
        If 0 >= New_Balance Then
            nStatus = 11
        Else
            nStatus = 13
        End If
        squery = "UPDATE bill SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & GetDateTimeNowSql() & "' WHERE ID = '" & gsBill & "'"
        SqlExecuted(squery)

    End Sub

    Private Sub FrmBillCreditBills_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvAvailable)
        dgvAvailable.Columns("Select").Width = 50
    End Sub
    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dgvAvailable.Rows.Count = 0 Then
            MessageBoxWarning("Bill not found!")
            Exit Sub
        End If
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            With dgvAvailable.Rows(i)
                If SetBillCreditFromBills(.Cells(1).Value, NumberFormatFixed(.Cells("Amount_applied").Value), .Cells(0).Value) = True Then
                    SetBillBalanceUpdate(.Cells(0).Value, .Cells("Amount").Value)
                End If
            End With
        Next
        gsOk = True
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class