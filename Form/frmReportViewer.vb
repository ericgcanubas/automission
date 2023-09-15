Imports CrystalDecisions.Windows.Forms

Public Class FrmReportViewer
    Dim rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
    Public gsSearchRedBox As String
    Private Sub FrmReportViewer_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim formats As Integer
        formats = (CrystalDecisions.Shared.ViewerExportFormats.PdfFormat Or CrystalDecisions.Shared.ViewerExportFormats.XLSXFormat Or CrystalDecisions.Shared.ViewerExportFormats.ExcelFormat Or CrystalDecisions.Shared.ViewerExportFormats.WordFormat)

        CrystalReportViewer1.AllowedExportFormats = formats

        gsToolPanelView = False
        If gsToolPanelView = False Then
            'Default
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.None
        Else
            CrystalReportViewer1.ToolPanelView = ToolPanelViewType.GroupTree
        End If

        gsToolPanelView = True

    End Sub

    Private Sub FrmReportViewer_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        Try

            rpt = gscryRpt

            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Refresh()
            CrystalReportViewer1.Zoom(1)
            Hide_Tab(CrystalReportViewer1)
            If gsSearchRedBox <> "" Then
                CrystalReportViewer1.SearchForText(gsSearchRedBox)
            End If

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try



    End Sub
    Private Sub Hide_Tab(ByVal cr As CrystalReportViewer)
        For Each control As Control In cr.Controls
            If (TypeOf control Is PageView) Then
                Dim tab As Windows.Forms.TabControl = CType(CType(control, PageView).Controls(0), Windows.Forms.TabControl)
                tab.ItemSize = New Size(0, 1)
                tab.SizeMode = TabSizeMode.Fixed
                tab.Appearance = TabAppearance.Buttons
            End If

        Next
    End Sub
    Private Sub DoWork(ByVal sender As Object, ByVal e As System.EventArgs)
        'Try
        '    If rpt IsNot Nothing Then
        '        rpt.Close()
        '        rpt.Dispose()
        '        rpt = Nothing
        '    End If
        'Catch ex As Exception

        'End Try


        '       ClosedForm(Me)

        If MessageBoxQuestion("Print now?") = True Then
            rpt.PrintToPrinter(1, False, 0, 0)
        End If
    End Sub

    Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load
        For Each ctrl As Control In CrystalReportViewer1.Controls
            If TypeOf ctrl Is ToolStrip Then
                If Me.WindowState = FormWindowState.Normal Then
                    Dim btnNew As New ToolStripButton With {
                        .Text = "&Quick Print",
                        .BackColor = Color.Transparent,
                        .Name = "mybutton",
                        .Alignment = ToolStripItemAlignment.Left
                    }
                    CType(ctrl, ToolStrip).Items.Add(btnNew)
                    AddHandler btnNew.Click, AddressOf DoWork
                    '    ctrl.BackgroundImage = gsImageBackground
                    ' ctrl.BackgroundImageLayout = ImageLayout.Stretch
                End If




            End If
        Next
    End Sub
    Private Sub FrmReportViewer_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        MasterKeyPrint(sender, e)
    End Sub
    Private Sub MasterKeyPrint(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.P AndAlso e.Modifiers = Keys.Control Then

            If MessageBoxQuestion("Print now?") = True Then
                rpt.PrintToPrinter(1, False, 0, 0)
            End If

        End If
    End Sub

    Private Sub CrystalReportViewer1_KeyDown(sender As Object, e As KeyEventArgs) Handles CrystalReportViewer1.KeyDown
        MasterKeyPrint(sender, e)
    End Sub
End Class