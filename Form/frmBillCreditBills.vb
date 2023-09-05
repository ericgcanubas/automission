Imports System.Data.Odbc
Public Class frmBillCreditBills
    Public gsID As String
    Public gsVendor_ID As Integer
    Public gsLocation_ID As Integer
    Public gsOk As Boolean = False

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub fComputed()

        Dim credit_amount As Double = fNumFormatFixed(lblCreditAmount.Text)
        Dim remaining As Double = 0
        Dim total_amt As Double = 0

        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            total_amt = total_amt + fNumFormatFixed(dgvAvailable.Rows(i).Cells("Amount_applied").Value)
        Next
        remaining = credit_amount - total_amt
        lblRemainingCredit.Text = fNumFormatStandard(remaining)
        lblTotal.Text = fNumFormatStandard(total_amt)

    End Sub


    Private Sub frmBillCreditBill_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        Dim chk As New DataGridViewCheckBoxColumn
        chk.Name = "select"
        chk.HeaderText = " "

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

        fBillList()
        fComputed()
        fDatagridViewMode(dgvAvailable)
    End Sub
    Private Sub fBillList()
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
            Dim rd As OdbcDataReader = fReader(sQuery)
            While rd.Read
                Dim credit_applied As Double = fBillSumCreditApplied(rd("bill_id"), gsVendor_ID)
                If credit_applied = 0 Then
                    bSelected = False
                Else
                    bSelected = True
                End If
                dgvAvailable.Rows.Add(rd("bill_id"), bSelected, fDateFormatStandard(rd("date")), rd("code"), fNumFormatStandard(rd("amount")), fNumFormatStandard(rd("balance_due") + credit_applied), fNumFormatStandard(credit_applied))
            End While
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fBillList()
            Else
                End
            End If

        End Try
    End Sub
    Private Sub fSelected_click(ByVal i_index As Integer)
        Try
            Dim bseleted As Boolean = dgvAvailable.Rows(i_index).Cells("select").Value
            If bseleted = False Then

                Dim bill_balance As Double = dgvAvailable.Rows(i_index).Cells("balance_due").Value
                Dim credit_balance As Double = 0
                Dim total_amt As Double = 0
                Dim credit_amt As Double = fNumFormatFixed(lblCreditAmount.Text)
                For i As Integer = 0 To dgvAvailable.Rows.Count - 1
                    total_amt = total_amt + dgvAvailable.Rows(i).Cells("amount_applied").Value
                Next
                credit_balance = credit_amt - total_amt
                With dgvAvailable.Rows(i_index)
                    If credit_balance > bill_balance Then
                        .Cells("select").Value = True
                        .Cells("Amount_applied").Value = fNumFormatStandard(bill_balance)
                    Else
                        If credit_balance <= 0 Then
                            Exit Sub
                        Else
                            .Cells("select").Value = True
                            .Cells("Amount_applied").Value = fNumFormatStandard(credit_balance)
                        End If
                    End If
                End With
            Else
                With dgvAvailable.Rows(i_index)
                    .Cells("select").Value = False
                    .Cells("Amount_applied").Value = fNumFormatStandard(0)
                End With
            End If
            fComputed()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub tsCancel_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvAvailable_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellContentClick
    End Sub

    Private Sub dgvAvailable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellClick
        If dgvAvailable.Rows.Count = 0 Then Exit Sub
        If e.ColumnIndex = 1 Then
            fSelected_click(e.RowIndex)
        End If
    End Sub

    Private Sub tsApply_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            If dgvAvailable.Rows(i).Cells(1).Value = False Then
                fSelected_click(i)
            End If
        Next
    End Sub

    Private Sub tsClear_Click(sender As Object, e As EventArgs)
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            If dgvAvailable.Rows(i).Cells(1).Value = True Then
                fSelected_click(i)
            End If
        Next
    End Sub

    Private Sub tsOk_Click(sender As Object, e As EventArgs)


    End Sub

    Private Function fSetbill_credit_bills(ByVal bSelected As Boolean, ByVal amt_appled As Double, ByVal prbill_ID As String) As Boolean
        Dim bUpdate As Boolean = False

        Try

            Dim rd_check As OdbcDataReader = fReader("select AMOUNT_APPLIED as a from bill_credit_bills where BILL_CREDIT_ID ='" & gsID & "' and BILL_ID = '" & prbill_ID & "' ")
            If rd_check.Read Then
                If bSelected = True Then
                    'UPDATE
                    If amt_appled <> rd_check("a") Then
                        fExecutedOnly("UPDATE bill_credit_bills set AMOUNT_APPLIED ='" & amt_appled & "' Where  BILL_CREDIT_ID = '" & gsID & "' and BILL_ID = '" & prbill_ID & "'")
                        bUpdate = True
                    End If
                Else
                    'DELETE
                    fExecutedOnly("DELETE FROM bill_credit_bills Where  BILL_CREDIT_ID = '" & gsID & "' and BILL_ID = '" & prbill_ID & "'")
                    bUpdate = True
                End If
            Else
                'INSERT
                If bSelected = True Then
                    Dim i_ID As Double = fObjectTypeMap_ID("bill_credit_bills")
                    fExecutedOnly("INSERT INTO bill_credit_bills set ID ='" & i_ID & "', BILL_CREDIT_ID = '" & gsID & "',BILL_ID = '" & prbill_ID & "' , AMOUNT_APPLIED ='" & amt_appled & "'")
                    bUpdate = True
                End If

            End If

            rd_check.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                bUpdate = fSetbill_credit_bills(bSelected, amt_appled, prbill_ID)
            Else
                End
            End If
        End Try


        Return bUpdate
    End Function

    Private Sub fBillBalance_Update(ByVal gsBill As String, prORG_Amount As Double)

        Dim total_pay As Double = fBillSumPaymentApplied(gsBill, gsVendor_ID) + fBillSumCreditApplied(gsBill, gsVendor_ID) + fBillSumTaxApplied_Amount(gsBill, gsVendor_ID)
        Dim New_Balance As Double = prORG_Amount - total_pay

        Dim squery As String

        Dim nStatus As Integer = 0
        If 0 >= New_Balance Then
            nStatus = 11
        Else
            nStatus = 13
        End If
        squery = "UPDATE bill SET BALANCE_DUE ='" & New_Balance & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & fDateTimeNow() & "' WHERE ID = '" & gsBill & "'"
        fExecutedOnly(squery)

    End Sub

    Private Sub frmBillCreditBills_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fDgvNotSort(dgvAvailable)
        dgvAvailable.Columns("Select").Width = 50
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dgvAvailable.Rows.Count = 0 Then
            fMessageboxWarning("Bill not found!")
            Exit Sub
        End If
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            With dgvAvailable.Rows(i)
                If fSetbill_credit_bills(.Cells(1).Value, fNumFormatFixed(.Cells("Amount_applied").Value), .Cells(0).Value) = True Then
                    fBillBalance_Update(.Cells(0).Value, .Cells("Amount").Value)
                End If
            End With
        Next
        gsOk = True
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class