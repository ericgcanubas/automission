
Public Class FrmReportSetting
    Private Sub fRefresh()
        LoadDataGridView(dgvReport, "select s.SUB_ID as `Report ID`,s.Description,s.form as `Report file`, r.description as `Report Group`,s.image_file as `Ref Description` from tblsub_menu as s left outer join report_group as r on (r.id = s.group_line) inner join tblmenu_list as ml on (ml.sub_id = s.sub_id  and ml.menu_id = '5') ")

        DatagridViewMode(dgvReport)

    End Sub

    Private Sub frmReportSetting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fRefresh()
    End Sub

    Private Sub dgvReport_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellContentClick

    End Sub

    Private Sub NewReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewReportToolStripMenuItem.Click
        frmReportSettingDetails.IsNew = True
        frmReportSettingDetails.ShowDialog()
        frmReportSettingDetails.Dispose()
        frmReportSettingDetails = Nothing
        fRefresh()
    End Sub

    Private Sub EditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditToolStripMenuItem.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If
        frmReportSettingDetails.ID = dgvReport.Rows(dgvReport.CurrentRow.Index).Cells(0).Value
        frmReportSettingDetails.IsNew = False
        frmReportSettingDetails.ShowDialog()
        frmReportSettingDetails.Dispose()
        frmReportSettingDetails = Nothing
        fRefresh()
    End Sub

    Private Sub dgvReport_SelectionChanged(sender As Object, e As EventArgs) Handles dgvReport.SelectionChanged

    End Sub

    Private Sub dgvReportReference_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub



    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click

        frmReportSettingDetails.IsNew = True
        frmReportSettingDetails.ShowDialog()
        frmReportSettingDetails.Dispose()
        frmReportSettingDetails = Nothing

    End Sub

    Private Sub dgvReport_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReport.CellDoubleClick
        If dgvReport.Rows.Count <> 0 Then
            With frmReportManager
                .gsSUB_ID = dgvReport.Rows(e.RowIndex).Cells(0).Value
                .lblNAME.Text = dgvReport.Rows(e.RowIndex).Cells(1).Value
                .ShowDialog()
                .Dispose()
            End With
            frmReportManager = Nothing
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
            fRefresh()
        End If

    End Sub
End Class