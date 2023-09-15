Public Class FrmPOSRoomPaymentList

    Dim strQuery As String = $"(select ifnull(item_id,0) from invoice_items as ni inner join item as m on m.id = ni.item_id where ni.invoice_id = i.id  and m.type ='10' limit 1)"
    Private Sub FrmPOSRoomEntryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fPaymentLoad()
        gsGotChangeData = False
    End Sub

    Private Sub fPaymentLoad()

        GS_LoadDataGridView(dgvList, $"SELECT p.`ID`,i.`ID` AS `INVOICE_ID`,ifnull({strQuery},0) as `ROOM_ID`,p.`CODE` as `PAYMENT No.`, pn.`AMOUNT_APPLIED` AS `PAYMENT` FROM payment AS p INNER JOIN payment_invoices AS pn ON pn.`PAYMENT_ID` = p.`ID` inner join invoice as i on i.id = pn.INVOICE_ID  where p.`POS_LOG_ID` = '{gsPOS_LOG_ID}' order by p.ID ")
        dgvList.Columns("ID").Visible = False
        dgvList.Columns("INVOICE_ID").Visible = False
        dgvList.Columns("ROOM_ID").Visible = False

    End Sub
    Private Sub fClick()
        If dgvList.Rows.Count <> 0 Then
            gsGotChangeData = False
            Dim ROOM_ID As Integer = GF_NumIsNull(dgvList.CurrentRow.Cells("ROOM_ID").Value)
            Dim INVOICE_ID As Integer = GF_NumIsNull(dgvList.CurrentRow.Cells("INVOICE_ID").Value)
            gsDocument_Finder_ID = INVOICE_ID
            Dim ROOM_NAME As String = GF_GetStringFieldValue("ITEM", "id", ROOM_ID, "description")
            frmPOSRoomDetails.IsNew = INVOICE_ID
            frmPOSRoomDetails.gsWalkInCustomer = IIf(ROOM_NAME = "", True, False)
            frmPOSRoomDetails.Text = IIf(ROOM_NAME = "", "Walk-in customer", ROOM_NAME)
            frmPOSRoomDetails.IsNew = False
            frmPOSRoomDetails.gsRoomID = ROOM_ID
            frmPOSRoomDetails.ShowDialog()

            frmPOSRoomDetails.Dispose()
            frmPOSRoomDetails = Nothing

            If gsGotChangeData = True Then
                fPaymentLoad()
            End If
        End If
    End Sub
    Private Sub tsShowRoom_Click(sender As Object, e As EventArgs) Handles tsShowRoom.Click
        fClick()
    End Sub
    Private Sub tsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(fCheckingGotVisibleIndex(False)).Cells("PAYMENT No.")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(fCheckingGotVisibleIndex(True)).Cells("PAYMENT No.")
        Catch ex As Exception
        End Try

    End Sub
    Public Function fCheckingGotVisibleIndex(ByVal isUp As Boolean) As Integer
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

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
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
            fPaymentLoad()
            gsGotChangeData = True

            GS_CollectPosLogResto()
            GS_PosLogLoad()
        End If


    End Sub
End Class