
Public Class FrmThemeStyle
    Private Sub FrmThemeStyle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub

    Private Sub RefreshData()

        GS_LoadDataGridView(dgvTheme, "Select * from theme ")
        dgvTheme.Columns(1).Visible = False
        dgvTheme.Columns(2).Visible = False
        dgvTheme.Columns(3).Visible = False
        dgvTheme.Columns(4).Visible = False
    End Sub


    Private Sub DgvTheme_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvTheme.CellClick
        Try
            If dgvTheme.Rows.Count = 0 Then Exit Sub
            txtTITLE.Enabled = False
            txtTITLE.Text = dgvTheme.Rows(e.RowIndex).Cells(0).Value
            txtCOLOR_CODE.Text = dgvTheme.Rows(e.RowIndex).Cells(1).Value
            txtBANNER_PATH.Text = dgvTheme.Rows(e.RowIndex).Cells(2).Value
            txtLEFT_BANNER_PATH.Text = dgvTheme.Rows(e.RowIndex).Cells(3).Value
            txtBACKGROUND_PATH.Text = dgvTheme.Rows(e.RowIndex).Cells(4).Value

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try

    End Sub



    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If dgvTheme.Rows.Count = 0 Then Exit Sub

        SqlExecuted("update theme set active = '0' ")
        SqlExecuted("update theme set active = '1' where title = '" & txtTITLE.Text & "'")
        MessageBoxInfo(txtTITLE.Text & " is apply")
        RefreshData()
    End Sub


    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        txtTITLE.Enabled = True
        txtTITLE.Clear()
        txtCOLOR_CODE.Clear()
        txtBANNER_PATH.Clear()
        txtLEFT_BANNER_PATH.Clear()
        txtBACKGROUND_PATH.Clear()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

        If txtTITLE.Enabled = False Then
            'EDIT
            SqlExecuted("UPDATE theme  SET color_code = '" & txtCOLOR_CODE.Text & "',banner='" & txtBANNER_PATH.Text & "',left_banner='" & txtLEFT_BANNER_PATH.Text & "',background = '" & txtBACKGROUND_PATH.Text & "' WHERE title = '" & txtTITLE.Text & "'")
            RefreshData()
        Else
            'New
            SqlExecuted("INSERT INTO theme  SET title = '" & txtTITLE.Text & "',color_code = '" & txtCOLOR_CODE.Text & "',banner='" & txtBANNER_PATH.Text & "',left_banner='" & txtLEFT_BANNER_PATH.Text & "',background = '" & txtBACKGROUND_PATH.Text & "'")
            RefreshData()
        End If
    End Sub
    Private Sub TxtCOLOR_CODE_DoubleClick(sender As Object, e As EventArgs) Handles txtCOLOR_CODE.DoubleClick
        txtCOLOR_CODE.Text = -1842205
    End Sub
End Class