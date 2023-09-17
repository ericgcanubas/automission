Imports System.Drawing.Printing
Imports System.Data.Odbc
Public Class FrmPOSRoomPayment
    Public gsOK As Boolean = False
    Public gsID As Integer

    Public gsFullPAYMENT_REQUIRED As Boolean = True

    Public gsInvoice_ID As Integer

    Public gsPaymentMethodID As Integer = 1
    Dim gsCustomer_ID As Integer

    Public gsValue As String
    Public gsEnter As Boolean = False

    Private Sub FrmPOSCreatePaymentMultiMethod_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MethodList()
        MethodListSet()
        gsCustomer_ID = GF_GetNumberFieldValue("INVOICE", "ID", gsInvoice_ID, "CUSTOMER_ID")
        xlblCustomer_Name.Text = GF_GetStringFieldValue("CONTACT", "id", gsCustomer_ID, "NAME")
        gsOK = False
        txtRECEIPT_REF_NO.Text = GF_GetNextReceiptNumber()
        txtRECEIPT_REF_NO.ReadOnly = True
        dtpRECEIPT_DATE.Value = gsPOS_DATE
        dtpRECEIPT_DATE.Enabled = False

        dtpCARD_EXPIRY_DATE.Checked = False

        gsEnter = False
        GetValue()

        lblAMOUNT_APPLIED.Text = GetInvoiceAmount()
        xlblCHANGE.Text = "0.00"
        Computed()

    End Sub
    Private Function GetInvoiceAmount() As Double
        Dim ThisAMOUNT As Double = GF_GetNumberFieldValue("INVOICE", "ID", gsInvoice_ID, "BALANCE_DUE")
        Return ThisAMOUNT
    End Function

    Private Function GetNextLogSerialNumber() As Integer
        Dim i As Integer = 0
        Dim rd As OdbcDataReader = SqlReader("select NEXT_LOG_SERIAL_NO from POS_MACHINE where ID = '" & gsPOS_MACHINE_ID & "' limit 1;")
        If rd.Read Then
            i = GF_NumIsNull(rd("NEXT_LOG_SERIAL_NO"))
        End If
        rd.Close()
        SqlExecuted("Update pos_machine set NEXT_LOG_SERIAL_NO = '" & i + 1 & "' where ID ='" & gsPOS_MACHINE_ID & "' limit 1;")
        Return 1
    End Function
    Private Sub MethodList()
        With dgvMethod.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("METHOD", "METHOD")
        End With
        With dgvMethod.Rows
            .Clear()
            Dim rd As OdbcDataReader = SqlReader("SELECT ID,DESCRIPTION FROM PAYMENT_METHOD ")
            While rd.Read
                .Add(rd("ID"), rd("DESCRIPTION"))
            End While

        End With


    End Sub
    Private Sub MethodListSet()
        With dgvMethodSet
            .Columns.Clear()
            .Columns.Add("ID", "ID")
            .Columns.Item("ID").Visible = False
            .Columns.Add("METHOD", "METHOD")
            .Columns.Add("AMOUNT", "AMOUNT")
            .Columns("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("AMOUNT").DefaultCellStyle.Format = "N2"
            .Columns("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns.Add("APPLIED", "APPLIED")
            .Columns("APPLIED").Visible = False
        End With


    End Sub
    Private Sub Computed()
        Dim TOTAL As Double = 0
        For I As Integer = 0 To dgvMethodSet.Rows.Count - 1
            TOTAL += dgvMethodSet.Rows(I).Cells("AMOUNT").Value
        Next

        lblAMOUNT.Text = NumberFormatStandard(TOTAL)
        Dim C As Double = TOTAL - GF_NumIsNull(lblAMOUNT_APPLIED.Text)
        If C <= 0 Then
            C = 0
        End If
        xlblCHANGE.Text = NumberFormatStandard(C)
    End Sub
    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If dgvMethodSet.Rows.Count = 0 Then
            MessageBoxInfo("No payment method found.")
            Exit Sub
        End If

        If GF_NumIsNull(lblAMOUNT.Text) < GF_NumIsNull(lblAMOUNT_APPLIED.Text) Then
            MessageBoxWarning("Invalid payment tender must higher value.")
            Exit Sub
        End If
        '==============================
        gsID = ObjectTypeMapId("payment")
        'MAIN
        Dim SQL_INSERT As String = $"INSERT INTO `payment`
SET `ID` = '{gsID}',
  `RECORDED_ON` = '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}',
  `CODE` = '{GF_GetNextCode("PAYMENT", gsDefault_LOCATION_ID)}',
  `DATE` = '{DateFormatMySql(gsPOS_DATE)}',
  `CUSTOMER_ID` = '{gsCustomer_ID}',
  `LOCATION_ID` = '{gsDefault_LOCATION_ID}',
  `AMOUNT` = '{GF_NumIsNull(lblAMOUNT.Text)}',
  `AMOUNT_APPLIED` = '{ GF_NumIsNull(lblAMOUNT_APPLIED.Text)}',
  `PAYMENT_METHOD_ID` = '{gsPaymentMethodID}',
  `CARD_NO` = '{txtCARD_NO.Text}',
  `CARD_EXPIRY_DATE` = {IIf(dtpCARD_EXPIRY_DATE.Checked = True, $"'{DateFormatMySql(dtpCARD_EXPIRY_DATE.Value)}'", "null")},
  `RECEIPT_REF_NO` = '{txtRECEIPT_REF_NO.Text}',
  `RECEIPT_DATE` = {IIf(dtpRECEIPT_DATE.Checked = True, $"'{DateFormatMySql(dtpRECEIPT_DATE.Value)}'", "null")},
  `NOTES` = '{txtNOTES.Text}',
  `UNDEPOSITED_FUNDS_ACCOUNT_ID` = '{gsDRAWER_ACCOUNT_ID}',
  `OVERPAYMENT_ACCOUNT_ID` = NULL,
  `STATUS` = '15',
  `STATUS_DATE` = '{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}',
  `DEPOSITED` = '0',
  `POS_LOG_ID` = '{gsPOS_LOG_ID}',
  `POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}',
  `CASH_COUNT_ID` = NULL,
  `ACCOUNTS_RECEIVABLE_ID` = '{gsDefault_ACCOUNTS_RECEIVABLE_ID}';"

        SqlExecuted(SQL_INSERT)

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            GS_AccountJournalExecute(gsDRAWER_ACCOUNT_ID, gsDefault_LOCATION_ID, gsCustomer_ID, 41, gsID, gsPOS_DATE, 0, NumberFormatFixed(lblAMOUNT_APPLIED.Text), gsJOURNAL_NO_FORM)
        End If
        '================================
        'ITEM

        '===========================================
        Dim ThisID As Integer = ObjectTypeMapId("PAYMENT_INVOICES")

        Dim ThisAMOUNT As Double = GF_NumIsNull(lblAMOUNT_APPLIED.Text)

        SqlExecuted($"INSERT INTO `payment_invoices`
   SET `ID` = '{ThisID}',
  `PAYMENT_ID` = '{gsID}',
  `INVOICE_ID` = '{gsInvoice_ID}',
  `DISCOUNT` = NULL,
  `AMOUNT_APPLIED` = '{ThisAMOUNT}',
  `DISCOUNT_ACCOUNT_ID` = NULL,
  `ACCOUNTS_RECEIVABLE_ID` = '{gsDefault_ACCOUNTS_RECEIVABLE_ID}',
  `PENALTY_PAID` = NULL;")
        '======================================================

        '======================================================
        If gsSkipJournalEntry = False Then
            GS_AccountJournalExecute(gsDefault_ACCOUNTS_RECEIVABLE_ID, gsDefault_LOCATION_ID, gsInvoice_ID, 42, ThisID, gsPOS_DATE, 1, ThisAMOUNT, gsJOURNAL_NO_FORM)
        End If

        '=====================================================
        GS_UpdateInvoiceBalance(gsInvoice_ID, gsCustomer_ID)

        For I As Integer = 0 To dgvMethodSet.Rows.Count - 1
            SqlExecuted($"INSERT INTO payment_multi_method SET PAYMENT_ID = '{gsID}',PAYMENT_METHOD_ID ='{ dgvMethodSet.Rows(I).Cells("ID").Value }',AMOUNT_APPLIED='{dgvMethodSet.Rows(I).Cells("APPLIED").Value}'")
        Next

        GS_UpdateNextReceiptNumber()

        gsOK = True
        ' POS _LOG UPDATE

        If gsSTARTING_RECEIPT_NO = 0 Then
            gsSTARTING_RECEIPT_NO = Val(txtRECEIPT_REF_NO.Text)
            gsENDING_RECEIPT_NO = gsSTARTING_RECEIPT_NO
        Else
            gsENDING_RECEIPT_NO = Val(txtRECEIPT_REF_NO.Text)
        End If

        If gsOpenCashDrawer = True Then
            Dim Ppage As New PageSettings
            With Ppage
                .Margins.Left = 1
                .Margins.Right = 1
                .Margins.Top = 1
                .Margins.Bottom = 1
                .Landscape = False
                PrintDocument1.DefaultPageSettings = Ppage
            End With
            PrintDocument1.Print()
        End If

        GS_CollectPosLogResto()
        GS_PosLogLoad()

        Me.Close()
    End Sub


    Private Sub GetValue()

        GetLimit()
        xxlblValue.Text = gsValue

    End Sub


    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        gsValue &= "0"
        GetValue()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        gsValue &= "1"
        GetValue()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        gsValue &= "2"
        GetValue()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        gsValue &= "3"
        GetValue()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        gsValue &= "4"
        GetValue()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        gsValue &= "5"
        GetValue()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        gsValue &= "6"
        GetValue()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        gsValue &= "7"
        GetValue()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        gsValue &= "8"
        GetValue()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        gsValue &= "9"
        GetValue()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If gsValue.Contains(".") = True Then

        Else
            gsValue &= "."
            GetValue()
        End If

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Try
            Dim L As Integer = GF_NumIsNull(gsValue.Length)
            If L = 0 Then
                gsValue = ""
            Else
                gsValue = gsValue.ToString.Remove(L - 1)
            End If
        Catch ex As Exception

        End Try


        GetValue()
    End Sub

    Private Sub GetLimit()
        If gsValue = "" Then
            Exit Sub
        End If
        Dim got_point As Boolean = False
        Dim got_point_i As Integer = 0
        Dim Get_Collect As String = ""
        For N As Integer = 0 To gsValue.Length - 1

            If gsValue.Substring(N, 1) = "." Then
                got_point = True
                Get_Collect &= gsValue.Substring(N, 1)
            Else
                If got_point = True Then
                    If got_point_i < 2 Then
                        Get_Collect &= gsValue.Substring(N, 1)

                    Else
                        Exit For
                    End If
                    got_point_i += 1
                Else
                    Get_Collect &= gsValue.Substring(N, 1)
                End If

            End If

            If N > 10 Then
                Exit For
            End If
        Next

        gsValue = Get_Collect
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click

        If dgvMethodSet.Rows.Count = 0 Then
            Exit Sub
        End If

        With dgvMethodSet.CurrentRow
            dgvMethod.Rows.Add(.Cells("ID").Value, .Cells("METHOD").Value)
            dgvMethodSet.Rows.RemoveAt(.Index)
        End With

        Computed()
    End Sub

    Private Function GetAlreadyCredit() As Double

        Dim gsCollect As Double = 0

        For N As Integer = 0 To dgvMethodSet.Rows.Count - 1
            gsCollect += dgvMethodSet.Rows(N).Cells("APPLIED").Value
        Next

        Return gsCollect

    End Function
    Private Sub BtnAdded_Click(sender As Object, e As EventArgs) Handles btnAdded.Click
        If GF_NumIsNull(xxlblValue.Text) = 0 Then
            MessageBoxExclamation($"No {xxMETHOD_LABEL.Text} Value ")
            Exit Sub
        End If

        If dgvMethod.Rows.Count = 0 Then Exit Sub
        Dim BAL As Double = GF_NumIsNull(lblAMOUNT_APPLIED.Text) - GetAlreadyCredit()
        If BAL <= 0 Then
            MessageBoxInfo("Invalid entry transaction.")
            Exit Sub
        End If

        Dim Applied As Double = IIf(GF_NumIsNull(xxlblValue.Text) >= BAL, BAL, GF_NumIsNull(xxlblValue.Text))

        With dgvMethod.CurrentRow
            dgvMethodSet.Rows.Add(.Cells("ID").Value, .Cells("METHOD").Value, NumberFormatStandard(GF_NumIsNull(xxlblValue.Text)), Applied)
            xxlblValue.Text = ""
            gsValue = ""
            dgvMethod.Rows.RemoveAt(.Index)
        End With

        Computed()
    End Sub
    Private Sub DgvMethod_SelectionChanged(sender As Object, e As EventArgs) Handles dgvMethod.SelectionChanged
        If dgvMethod.Rows.Count <> 0 Then
            xxMETHOD_LABEL.Text = dgvMethod.CurrentRow.Cells("METHOD").Value
        Else
            xxMETHOD_LABEL.Text = ""
        End If
    End Sub
    Private Sub TxtCARD_NO_Click(sender As Object, e As EventArgs) Handles txtCARD_NO.Click
        KeyBoardToTouch(txtCARD_NO, "CARD NO.")
    End Sub
    Private Sub TxtNOTES_Click(sender As Object, e As EventArgs) Handles txtNOTES.Click
        KeyBoardToTouch(txtNOTES, "NOTES")
    End Sub


    Private Function GotVisibleIndex(ByVal dgv As DataGridView, ByVal isUp As Boolean) As Integer
        Dim This_number As Integer = dgv.CurrentRow.Index
        Dim Current As Integer = dgv.CurrentRow.Index
        If isUp = True Then

            For N As Integer = Current To 0 Step -1
                If dgv.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If

            Next


        Else
            For N As Integer = Current To dgv.Rows.Count - 1
                If dgv.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If

                End If

            Next
        End If

        Return This_number
    End Function

    Private Sub BtnDownA_Click(sender As Object, e As EventArgs) Handles btnDownA.Click
        Try
            If dgvMethod.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvMethod.Select()
            dgvMethod.CurrentCell = dgvMethod.Rows(GotVisibleIndex(dgvMethod, False)).Cells("METHOD")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpA_Click(sender As Object, e As EventArgs) Handles btnUpA.Click
        Try
            If dgvMethod.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvMethod.Select()
            dgvMethod.CurrentCell = dgvMethod.Rows(GotVisibleIndex(dgvMethod, True)).Cells("METHOD")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnDownB_Click(sender As Object, e As EventArgs) Handles btnDownB.Click
        Try
            If dgvMethodSet.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvMethodSet.Select()
            dgvMethodSet.CurrentCell = dgvMethodSet.Rows(GotVisibleIndex(dgvMethodSet, False)).Cells("METHOD")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpB_Click(sender As Object, e As EventArgs) Handles btnUpB.Click
        Try
            If dgvMethodSet.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvMethodSet.Select()
            dgvMethodSet.CurrentCell = dgvMethodSet.Rows(GotVisibleIndex(dgvMethodSet, True)).Cells("METHOD")
        Catch ex As Exception
        End Try
    End Sub
End Class