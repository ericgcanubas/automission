Public Class FrmPOSRoomEntryList
    Private Sub FrmPOSRoomEntryList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        EntryList()


    End Sub

    Private Sub EntryList()
        Dim strQuery As String = $"(select ifnull(item_id,0) from invoice_items as ni inner join item as m on m.id = ni.item_id where ni.invoice_id = i.id  and m.type ='10' limit 1)"
        GS_LoadDataGridView(dgvList, $"select i.ID, ifnull( {strQuery},0) as `ROOM_ID`,i.CODE as `Billing No.`, format(i.AMOUNT,2) as `TOTAL`, format(i.BALANCE_DUE,2) as `BALANCE`,s.DESCRIPTION as `Status`  from invoice as i inner join ship_via as s on s.id = i.SHIP_VIA_ID where i.manager_id = '{gsPOS_LOG_ID}' order by i.id ")
        dgvList.Columns("ID").Visible = False
        dgvList.Columns("ROOM_ID").Visible = False

    End Sub

    Private Sub TsShowRoom_Click(sender As Object, e As EventArgs) Handles tsShowRoom.Click
        If dgvList.Rows.Count <> 0 Then
            gsGotChangeData = False
            Dim Room_ID As Integer = dgvList.CurrentRow.Cells("ROOM_ID").Value
            Dim INVOICE_ID As Integer = dgvList.CurrentRow.Cells("ID").Value
            gsDocument_Finder_ID = INVOICE_ID
            Dim ROOM_NAME As String = GF_GetStringFieldValue("ITEM", "id", Room_ID, "description")
            FrmPOSRoomDetails.IsNew = INVOICE_ID
            FrmPOSRoomDetails.gsWalkInCustomer = IIf(ROOM_NAME = "", True, False)
            FrmPOSRoomDetails.Text = IIf(ROOM_NAME = "", "Walk-in customer", ROOM_NAME)
            FrmPOSRoomDetails.IsNew = False
            FrmPOSRoomDetails.gsRoomID = Room_ID
            FrmPOSRoomDetails.ShowDialog()
            FrmPOSRoomDetails.Dispose()
            FrmPOSRoomDetails = Nothing
            If gsGotChangeData = True Then
                EntryList()
            End If
        End If
    End Sub
    Private Sub TsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(GetVisibleIndex(False)).Cells("Billing No.")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvList.Select()

            dgvList.CurrentCell = dgvList.Rows(GetVisibleIndex(True)).Cells("Billing No.")
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
End Class