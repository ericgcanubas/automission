Public Class FrmHistory
    Public gsQuery As String
    Public gsSelect As Boolean
    Public gsType As String
    Public gsID As String
    Dim bClose As Boolean = False
    Private Sub FrmHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsSelect = False
        GS_LoadDataGridView(dgvDocument, gsQuery)
        dgvDocument.Columns(0).Visible = False
        dgvDocument.Columns(dgvDocument.Columns.Count - 1).Visible = False
        dgvDocument.Columns(dgvDocument.Columns.Count - 2).DefaultCellStyle.Format = "N2"
        If dgvDocument.Rows.Count = 0 Then

            bClose = True
            MessageBoxExclamation("Not available")

        End If
    End Sub
    Private Sub DgvDocument_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellDoubleClick
        If dgvDocument.Rows.Count <> 0 Then
            gsSelect = True
            gsType = dgvDocument.Rows(e.RowIndex).Cells("Type").Value
            gsID = dgvDocument.Rows(e.RowIndex).Cells(0).Value
            Me.Close()
        End If
    End Sub

    Private Sub FrmHistory_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If bClose = True Then
            Me.Visible = False
            Me.Close()
        End If
    End Sub
End Class