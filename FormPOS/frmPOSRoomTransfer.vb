Imports System.Data.Odbc
Public Class FrmPOSRoomTransfer
    Public gsTransfer_Item_ID As Integer
    Dim gsCheckInType As Integer = 10
    Dim INVOICE_ID_SQL As String = $" IFNULL((SELECT n.id FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id WHERE ni.item_id = i.`ID`  AND n.ship_via_id = '{gsCheckInType}' LIMIT 1),0) "


    Private Sub frmPOSRoomTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsTransfer_Item_ID = 0
        dgvList.Columns.Add("id", "id")
        dgvList.Columns("id").Visible = False
        dgvList.Columns.Add("description", "Rooms")
        fRefreshload()

    End Sub
    Private Sub fRefreshload()
        dgvList.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader($"Select i.id, i.description, {INVOICE_ID_SQL} AS `invoice_id` FROM item AS i WHERE i.type ='{gsCheckInType}' AND i.inactive ='0' ORDER BY i.description")
        While rd.Read
            If NumIsNull(rd("invoice_id")) = 0 Then
                dgvList.Rows.Add(rd("id"), rd("description"))

            End If

        End While
        rd.Close()

    End Sub
    Private Sub tsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(fCheckingGotVisibleIndex(False)).Cells("description")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvList.Select()

            dgvList.CurrentCell = dgvList.Rows(fCheckingGotVisibleIndex(True)).Cells("description")
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

    Private Sub tsShowRoom_Click(sender As Object, e As EventArgs) Handles tsShowRoom.Click
        Try
            dgvList.Select()
            gsTransfer_Item_ID = dgvList.CurrentRow.Cells("ID").Value
            Me.Close()
        Catch ex As Exception

        End Try

    End Sub
End Class