
Public Class FrmReportSetting
    Private Sub RefreshData()
        LoadDataGridView(dgvReport, "select s.SUB_ID as `Report ID`,s.Description,s.form as `Report file`, r.description as `Report Group`,s.image_file as `Ref Description` from tblsub_menu as s left outer join report_group as r on (r.id = s.group_line) inner join tblmenu_list as ml on (ml.sub_id = s.sub_id  and ml.menu_id = '5') ")
        DatagridViewMode(dgvReport)

    End Sub

    Private Sub FrmReportSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshData()
    End Sub

    Private Sub NewReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewReportToolStripMenuItem.Click
        FrmReportSettingDetails.IsNew = True
        FrmReportSettingDetails.ShowDialog()
        FrmReportSettingDetails.Dispose()
        FrmReportSettingDetails = Nothing
        RefreshData()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If
        FrmReportSettingDetails.ID = dgvReport.Rows(dgvReport.CurrentRow.Index).Cells(0).Value
        FrmReportSettingDetails.IsNew = False
        FrmReportSettingDetails.ShowDialog()
        FrmReportSettingDetails.Dispose()
        FrmReportSettingDetails = Nothing
        RefreshData()
    End Sub
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click

        FrmReportSettingDetails.IsNew = True
        FrmReportSettingDetails.ShowDialog()
        FrmReportSettingDetails.Dispose()
        FrmReportSettingDetails = Nothing

    End Sub

    Private Sub DgvReport_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellDoubleClick
        If dgvReport.Rows.Count <> 0 Then
            With FrmReportManager
                .gsSUB_ID = dgvReport.Rows(e.RowIndex).Cells(0).Value
                .lblNAME.Text = dgvReport.Rows(e.RowIndex).Cells(1).Value
                .ShowDialog()
                .Dispose()
            End With
            FrmReportManager = Nothing
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteToolStripMenuItem.Click

        If MessageBoxWarningYesNo("Are you sure to delete this report?") = True Then
            dgvReport.Select()
            With dgvReport.CurrentRow


                SqlExecuted($"DELETE FROM report_components WHERE SUB_ID = '{ .Cells(0).Value}' ")
                SqlExecuted($"DELETE FROM tblsub_menu WHERE `SUB_ID` ='{ .Cells(0).Value}' limit 1;")
                SqlExecuted($"DELETE FROM tblmenu_list WHERE MENU_ID ='5' and SUB_ID ='" & .Cells(0).Value & "' limit 1;")

            End With
            RefreshData()
        End If

    End Sub
End Class