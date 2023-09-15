Public Class FrmPOSRoomPaymentList

    Dim strQuery As String = $"(select ifnull(item_id,0) from invoice_items as ni inner join item as m on m.id = ni.item_id where ni.invoice_id = i.id  and m.type ='10' limit 1)"
    Private Sub FrmPOSRoomEntryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PaymentLoad()
        gsGotChangeData = False
    End Sub

    Private Sub PaymentLoad()

        GS_LoadDataGridView(dgvList, $"SELECT p.`ID`,i.`ID` AS `INVOICE_ID`,ifnull({strQuery},0) as `ROOM_ID`,p.`CODE` as `PAYMENT No.`, pn.`AMOUNT_APPLIED` AS `PAYMENT` FROM payment AS p INNER JOIN payment_invoices AS pn ON pn.`PAYMENT_ID` = p.`ID` inner join invoice as i on i.id = pn.INVOICE_ID  where p.`POS_LOG_ID` = '{gsPOS_LOG_ID}' order by p.ID ")
        dgvList.Columns("ID").Visible = False
        dgvList.Columns("INVOICE_ID").Visible = False
        dgvList.Columns("ROOM_ID").Visible = False

    End Sub
    Private Sub ClickList()
        If dgvList.Rows.Count <> 0 Then
            gsGotChangeData = False
            Dim ROOM_ID As Integer = GF_NumIsNull(dgvList.CurrentRow.Cells("ROOM_ID").Value)
            Dim INVOICE_ID As Integer = GF_NumIsNull(dgvList.CurrentRow.Cells("INVOICE_ID").Value)
            gsDocument_Finder_ID = INVOICE_ID
            Dim ROOM_NAME As String = GF_GetStringFieldValue("ITEM", "id", ROOM_ID, "description")
            FrmPOSRoomDetails.IsNew = INVOICE_ID
            FrmPOSRoomDetails.gsWalkInCustomer = IIf(ROOM_NAME = "", True, False)
            FrmPOSRoomDetails.Text = IIf(ROOM_NAME = "", "Walk-in customer", ROOM_NAME)
            FrmPOSRoomDetails.IsNew = False
            FrmPOSRoomDetails.gsRoomID = ROOM_ID
            FrmPOSRoomDetails.ShowDialog()

            FrmPOSRoomDetails.Dispose()
            FrmPOSRoomDetails = Nothing

            If gsGotChangeData = True Then
                PaymentLoad()
            End If
        End If
    End Sub
    Private Sub TsShowRoom_Click(sender As Object, e As EventArgs) Handles tsShowRoom.Click
        ClickList()
    End Sub
    Private Sub TsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(GetVisibleIndex(False)).Cells("PAYMENT No.")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(GetVisibleIndex(True)).Cells("PAYMENT No.")
        Catch ex As Exception
        End Try

    End Sub
    Public Function GetVisibleIndex(ByVal isUp As Boolean) As Integer
        Dim This_number As Integer = dgvList.CurrentRow.Index
        Dim Current As Integer = dgvList.CurrentRow.Index
        If isUp = True Then

            For N As Integer = Current To 0 Step -1
                If dgvList.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If
            Next

        Else
            For N As Integer = Current To dgvList.Rows.Count - 1
                If dgvList.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If

            Next
        End If

        Return This_number
    End Function

    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvList.Rows.Count = 0 Then
            MessageBoxInfo("Payment not found.")
            Exit Sub
        End If

        dgvList.Select()

        If MessageBoxPointOfSalesYesNO("Payment Delete?") = True Then

            Dim Payment_ID As Integer = dgvList.Rows(dgvList.CurrentRow.Index).Cells("ID").Value
            Dim Invoice_ID As Integer = dgvList.Rows(dgvList.CurrentRow.Index).Cells("INVOICE_ID").Value
            Dim Customer_ID As Integer = GF_GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "CUSTOMER_ID")

            'Payment Method
            SqlExecuted($"Delete From `payment_multi_method` WHERE payment_id ='{Payment_ID}'  ")
            'Payment Invoice
            SqlExecuted($"Delete From `payment_invoices` WHERE payment_id = '{Payment_ID}' ")
            'Payment
            SqlExecuted($"Delete From `payment` WHERE id = '{Payment_ID}' limit 1;")

            fUpdateInvoiceBalance(Invoice_ID, Customer_ID)
            PaymentLoad()
            gsGotChangeData = True

            GS_CollectPosLogResto()
            GS_PosLogLoad()
        End If


    End Sub
End Class