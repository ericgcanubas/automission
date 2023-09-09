Imports System.Data.Odbc
Public Class FrmApplyBillCredit
    Public gsID As String 'Bill Id
    Public gsVendor_ID As Integer
    Public gsLocation_ID As Integer
    Public gsOk As Boolean = False
    Public gsBalance As Double = 0
    Private Sub RefreshCredit()
        '   Dim cn As New MySqlConnection(mysqlConstr)
        Dim sQuery As String = "SELECT 
  m.id AS bill_credit_id,
  m.date,
  m.code,
  m.amount
FROM
  bill_credit AS m 
WHERE m.`vendor_ID` = '" & gsVendor_ID & "' 
  AND (m.amount - m.amount_applied) > '0' 

UNION

SELECT 
  m.id AS bill_credit_id,
  m.date,
  m.code,
  m.amount

FROM
  bill_credit AS m 
    INNER JOIN bill_credit_bills AS c 
    ON m.`ID` = c.`bill_credit_id` AND  c.bill_ID ='" & gsID & "' 
WHERE m.vendor_id = '" & gsVendor_ID & "' and m.location_id ='" & gsLocation_ID & "'"

        Try
            Dim bSelected As Boolean

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                Dim other_applied As Double = fGetCreditOtherBill(rd("bill_credit_id"), gsID)
                Dim credit_amount As Double = NumIsNull(rd("amount")) - other_applied
                Dim credit_applied As Double = fGetCreditApplied_Bill(rd("bill_credit_id"), gsVendor_ID, gsID)
                Dim credit_balance As Double = 0
                If credit_applied = 0 Then
                    bSelected = False
                Else
                    bSelected = True
                End If
                credit_balance = NumberFormatStandard(credit_amount - credit_applied)
                If credit_balance <> 0 Or bSelected = True Then
                    dgvAvailable.Rows.Add(rd("bill_credit_ID"), bSelected, GetDateNowStd, rd("code"), NumberFormatStandard(credit_amount), NumberFormatStandard(credit_applied), NumberFormatStandard(credit_balance))
                End If
            End While

            rd.Close()

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshCredit()
            Else
                End
            End If
        End Try
    End Sub

    Private Sub FrmApplyCredits_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim chk As New DataGridViewCheckBoxColumn With {
            .Name = "select",
            .HeaderText = " "
        }

        With dgvAvailable.Columns
            .Add("bill_credit_ID", "bill_credit_ID")
            .Item("bill_credit_ID").Visible = False

            .Add(chk)


            .Add("Date", "DATE")


            .Add("Number", "REFERENCE")


            .Add("credit_amount", "CREDIT AMT")
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

        RefreshCredit()
        lblDISCOUNT_USED.Text = NumberFormatStandard(fGetSumPaymentApplied(gsID, gsVendor_ID))
        lblAmount_Due.Text = NumberFormatStandard(gsBalance + GetBillSumCreditApplied(gsID, gsVendor_ID))
        FormComputed()
        DatagridViewMode(dgvAvailable)
    End Sub

    Private Sub FormComputed()

        Dim balance_due As Double
        Dim Amount_due As Double = Val(lblAmount_Due.Text)
        Dim credit_applied As Double = 0
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            credit_applied += NumberFormatFixed(dgvAvailable.Rows(i).Cells("credit_used").Value)
        Next
        balance_due = Amount_due - credit_applied

        lblCreditUsed.Text = NumberFormatStandard(credit_applied)
        lblBalance_Due.Text = NumberFormatStandard(balance_due)
        lblTotal.Text = NumberFormatStandard(credit_applied)
    End Sub
    Private Function SetBill_Credit_Bills(ByVal bSelected As Boolean, ByVal amt_appled As Double, ByVal prbill_Credit_ID As String) As Boolean
        Dim bUpdate As Boolean = False
        Try
            Dim rd_check As OdbcDataReader = SqlReader("select AMOUNT_APPLIED as a from bill_credit_bills where bill_Credit_ID ='" & prbill_Credit_ID & "' and bill_ID = '" & gsID & "' limit 1; ")
            If rd_check.Read Then
                If bSelected = True Then
                    'UPDATE
                    If amt_appled <> rd_check("a") Then
                        SqlExecuted("UPDATE bill_credit_bills set AMOUNT_APPLIED ='" & amt_appled & "' Where  bill_Credit_ID = '" & prbill_Credit_ID & "' and BILL_ID = '" & gsID & "' limit 1;")
                        bUpdate = True
                    End If
                Else
                    'DELETE
                    SqlExecuted("DELETE FROM bill_credit_bills Where  bill_Credit_ID = '" & prbill_Credit_ID & "' and BILL_ID = '" & gsID & "' limit 1;")
                    bUpdate = True
                End If
            Else
                'INSERT
                If bSelected = True Then
                    'GetMaxField("ID", "bill_credit_bills")
                    SqlExecuted("INSERT INTO bill_credit_bills set ID ='" & ObjectTypeMapId("BILL_CREDIT_BILLS") & "', bill_Credit_ID = '" & prbill_Credit_ID & "',BILL_ID = '" & gsID & "',AMOUNT_APPLIED ='" & amt_appled & "'")
                    bUpdate = True
                End If
            End If
            rd_check.Close()
        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                bUpdate = SetBill_Credit_Bills(bSelected, amt_appled, prbill_Credit_ID)
            Else
                End
            End If
        End Try


        Return bUpdate
    End Function

    Private Sub Bill_Credit_Update_Applied(ByVal prBill_Credit_ID As String, prORG_Amount As Double)

        Dim total_pay As Double = fGetCreditApplied_Bill(prBill_Credit_ID, gsVendor_ID, gsID) + fGetCreditOtherBill(prBill_Credit_ID, gsID) + GetBillSumTaxAppliedAmount(gsID, gsVendor_ID) + GetBillSumPaymentApplied(gsID, gsVendor_ID)

        Dim New_Balance As Double = prORG_Amount - total_pay

        Dim nStatus As Integer
        If 0 >= New_Balance Then
            nStatus = 15
        Else
            nStatus = 2
        End If

        Dim squery As String = "UPDATE bill_Credit SET AMOUNT_APPLIED ='" & total_pay & "',STATUS ='" & nStatus & "',STATUS_DATE ='" & GetDateTimeNowSql() & "' WHERE ID = '" & prBill_Credit_ID & "'"
        SqlExecuted(squery)

    End Sub



    Private Sub DgvAvailable_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAvailable.CellClick
        If dgvAvailable.Rows.Count = 0 Then Exit Sub
        If e.ColumnIndex = 1 Then
            SelectedClick(e.RowIndex)
        End If
    End Sub
    Private Sub SelectedClick(ByVal Index As Integer)
        Try


            Dim bseleted As Boolean = dgvAvailable.Rows(Index).Cells("select").Value

            If bseleted = False Then

                Dim invoice_balance As Double = NumberFormatFixed(lblBalance_Due.Text)
                Dim credit_balance As Double = 0
                Dim total_credit_used As Double = 0
                Dim credit_amt As Double = dgvAvailable.Rows(Index).Cells("credit_amount").Value
                For i As Integer = 0 To dgvAvailable.Rows.Count - 1
                    total_credit_used += dgvAvailable.Rows(i).Cells("credit_used").Value
                Next
                credit_balance = invoice_balance - total_credit_used
                With dgvAvailable.Rows(Index)
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
                With dgvAvailable.Rows(Index)
                    .Cells("select").Value = False
                    .Cells("credit_used").Value = NumberFormatStandard(0)
                    .Cells("credit_balance").Value = NumberFormatStandard(.Cells("credit_amount").Value)
                End With

            End If

            FormComputed()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                SelectedClick(Index)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub FrmApplyBillCredit_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvAvailable)
        dgvAvailable.Columns("Select").Width = 50
    End Sub
    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If dgvAvailable.Rows.Count = 0 Then
            MessageBoxWarning("Credit memo not found")
            Exit Sub
        End If
        For i As Integer = 0 To dgvAvailable.Rows.Count - 1
            With dgvAvailable.Rows(i)
                If SetBill_Credit_Bills(.Cells(1).Value, NumberFormatFixed(.Cells("credit_used").Value), .Cells(0).Value) = True Then
                    Bill_Credit_Update_Applied(.Cells(0).Value, NumberFormatFixed(.Cells("credit_amount").Value))
                End If
            End With
        Next
        SetUpdateBillBalance(gsID, gsVendor_ID)
        gsOk = True
        Me.Close()

        gsOk = True
        Me.Close()
    End Sub
End Class