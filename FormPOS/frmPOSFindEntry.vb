Public Class FrmPOSFindEntry
    Dim BS As BindingSource
    Public GetID As Integer

    Private Sub FrmPOSFindEntry_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DataGrid()
        GetID = 0
    End Sub
    Private Sub DataGrid()
        GS_LoadDataGridViewBinding(dgvList, $"SELECT 
  s.`ID`,
  s.`CODE` AS `ENTRY NO.`,
  c.`NAME` AS `BUYER`,
  p.`DESCRIPTION` AS `Method`,
  s.`PAYMENT_REF_NO` AS `REF No.`,
  s.`AMOUNT` AS `TOTAL` 
FROM
  sales_receipt AS s 
  INNER JOIN contact AS c 
    ON c.`ID` = s.`CUSTOMER_ID` 
  INNER JOIN payment_method AS p 
    ON p.`ID` = s.`PAYMENT_METHOD_ID` 
    WHERE  s.`DATE` ='{ DateFormatMySql(gsPOS_DATE)}' AND s.`LOCATION_ID` ='{gsDefault_LOCATION_ID}' AND s.`POS_LOG_ID` = '{gsPOS_LOG_ID}'  AND s.`POS_MACHINE_ID` = '{gsPOS_MACHINE_ID}'
     ", BS)
        With dgvList.Columns
            .Item(0).Visible = False
            .Item("TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("TOTAL").DefaultCellStyle.Format = "N2"
            .Item("TOTAL").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
    End Sub
    Private Sub SearchLoad()
        Try

            Dim strSearch As String = ""

            For I As Integer = 0 To dgvList.Columns.Count - 1

                If dgvList.Columns(I).Visible = True Then

                    If I < 12 And I > 3 Then
                        If strSearch = "" Then
                            strSearch = strSearch & $"[{dgvList.Columns(I).HeaderText}] like '%" & txtFind.Text & "%'"
                        Else
                            strSearch = strSearch & $" OR [{dgvList.Columns(I).HeaderText}] like '%" & txtFind.Text & "%'"
                        End If
                    End If
                End If



            Next


            BS.Filter = strSearch
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TxtFind_TextChanged(sender As Object, e As EventArgs) Handles txtFind.TextChanged
        SearchLoad()
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If dgvList.Rows.Count = 0 Then Exit Sub

        GetID = dgvList.CurrentRow.Cells(0).Value
        Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub Master_keydown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then

            If dgvList.Rows.Count <> 0 Then

                If dgvList.Focused = True Then

                    btnSelect.Select()
                ElseIf btnSelect.Focused = True Then
                    btnSelect.PerformClick()

                End If

            End If
        Else
            If dgvList.Rows.Count <> 0 Then
                dgvList.Select()
            End If
        End If

    End Sub

    Private Sub DgvList_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvList.KeyDown
        Master_keydown(sender, e)
    End Sub

    Private Sub BtnSelect_KeyDown(sender As Object, e As KeyEventArgs) Handles btnSelect.KeyDown
        Master_keydown(sender, e)
    End Sub

    Private Sub BtnCancel_KeyDown(sender As Object, e As KeyEventArgs) Handles btnCancel.KeyDown
        Master_keydown(sender, e)
    End Sub

    Private Sub TxtFind_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFind.KeyDown
        Master_keydown(sender, e)
    End Sub

    Private Sub FrmPOSFindEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Master_keydown(sender, e)
    End Sub
End Class