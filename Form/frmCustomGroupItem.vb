Public Class frmCustomGroupItem
    Public gsITEM_ID As Integer
    Dim BS_LIST As BindingSource
    Dim FIRST_Load As Boolean = True
    Dim ClickOk As Boolean = False
    Private Sub frmCustomGroupItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "CUSTOM GROUP : " & GetStringFieldValue("item", "id", gsITEM_ID, "DESCRIPTION")
        Me.Refresh()
        LoadDataGridViewBinding(dgvList, $"select i.ID as `ITEM_ID`,i.CODE,i.DESCRIPTION, format(c.QUANTITY,0) as QTY, format(c.RATE/c.QUANTITY,2) as `RATE` from item_components as c inner join item as i on i.id = c.component_id where c.ITEM_ID = '{gsITEM_ID}' order by c.RATE DESC ", BS_LIST)
        dgvList.Columns(0).Visible = False

        With dgvSelected.Columns
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
            .Add("CODE", "CODE")
            .Add("DESCRIPTION", "DESCRIPTION")
            .Add("QTY", "QTY")
            .Item("QTY").DefaultCellStyle.Format = "N0"

            .Add("RATE", "RATE")
            .Item("RATE").DefaultCellStyle.Format = "N2"
        End With
        ViewItemDisplay(dgvList)
        ViewNotSort(dgvList)
        ViewItemDisplay(dgvSelected)
        ViewNotSort(dgvSelected)
        ' fJustFilter()
    End Sub
    Private Sub fJustFilter()
        Try
            If FIRST_Load = False Then
                '
                BS_LIST.Filter = $"  ( [DESCRIPTION] like '%{txtSearch.Text}%'  OR  [CODE] like '%{txtSearch.Text}%')  { IIf(chkNoRate.Checked = True, " AND [RATE] <= '0.000'  ", "") }   { IIf(chkShowRate.Checked = True, " AND [RATE] >= '1.000'  ", "") } "


            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        dgvList.Select()

        If dgvList.Rows.Count <> 0 Then

            Dim I As Integer = dgvList.CurrentRow.Index
            Dim r As DataGridViewRow = dgvList.Rows(I)
            dgvSelected.Rows.Add(r.Cells("ITEM_ID").Value, r.Cells("CODE").Value, r.Cells("DESCRIPTION").Value, r.Cells("QTY").Value, r.Cells("RATE").Value)
        Else
            MessageBoxInfo("Data Not found")
        End If
        fCompute()
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        fJustFilter()
    End Sub

    Private Sub chkShowRate_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowRate.CheckedChanged
        If chkShowRate.Checked = True Then

            fJustFilter()
            chkNoRate.Checked = False
        Else
            fJustFilter()

        End If

    End Sub

    Private Sub chkNoRate_CheckedChanged(sender As Object, e As EventArgs) Handles chkNoRate.CheckedChanged
        If chkNoRate.Checked = True Then

            fJustFilter()
            chkShowRate.Checked = False
        Else
            fJustFilter()
        End If


    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        dgvSelected.Select()

        If dgvSelected.Rows.Count <> 0 Then

            Dim I As Integer = dgvSelected.CurrentRow.Index
            dgvSelected.Rows.RemoveAt(I)

        Else
            MessageBoxInfo("Data Not found")
        End If
        fCompute()
    End Sub
    Private Sub fCompute()
        Dim D As Double = 0
        For I As Integer = 0 To dgvSelected.Rows.Count - 1
            D = D + dgvSelected.Rows(I).Cells("RATE").Value

        Next

        lblTOTAL.Text = NumberFormatStandard(D)
    End Sub



    Private Sub frmCustomGroupItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FIRST_Load = False
    End Sub

    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        dgvSelected.Rows.Clear()
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dgvSelected.Rows.Count = 0 Then
            MessageBoxInfo("Item not Set")
            Exit Sub
        End If
        ClickOk = True
        Me.Close()

    End Sub

    Private Sub frmCustomGroupItem_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If ClickOk = False Then

            dgvSelected.Rows.Clear()
        End If
    End Sub
End Class