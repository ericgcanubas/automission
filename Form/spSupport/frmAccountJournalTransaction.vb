Imports System.Data.Odbc
Public Class frmAccountJournalTransaction

    Public ID As Integer
    Public objDate As Date
    Public gsLocation_Id As Integer
    Public gsObject_Type As Integer
    Public gsAccount_Id As Integer
    Public journal_no As Integer
    Public type_name As String

    Private Sub FrmAccountJournalTransaction_Load(sender As Object, e As EventArgs) Handles Me.Load

        type_name = GF_GetStringFieldValue("object_type_map", "ID", gsObject_Type, "Name")
        DBAccessComboBoxLoad(cmbPageFormat, "select [file_name],[print_title] from tblprint Where [form_name] ='" & Me.Name & "' order by [print_default] desc ", "file_name", "print_title")

    End Sub
    Private Sub JournalAccountProccess(ByVal prFile As String, ByVal prTitle As String)

        Try
            Dim rd As OdbcDataReader = SqlReader($"SELECT  a.JOURNAL_NO  FROM account_journal AS a WHERE a.object_type = '{gsObject_Type}' AND a.object_id ='{ID}' AND a.account_id ='{gsAccount_Id}'   LIMIT 1")
            If rd.Read Then
                journal_no = GF_NumIsNull(rd("JOURNAL_NO"))
                gsReportFileName = prFile
                gsReportName = prTitle & " " & type_name
                gsReportTabName = "Journal (" & journal_no & ")"
                gscryRpt = ReportDocumentOneParameterNumberOnly(gsReportFileName)
                CryParameterInsertValue(gscryRpt, journal_no, "journal_no")
                CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
                CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                JournalAccountProccess(prFile, prTitle)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Me.Close()
        GS_CursorLoadingOn(True)
        JournalAccountProccess(cmbPageFormat.SelectedValue, cmbPageFormat.Text)
        If journal_no <> 0 Then

            gsToolPanelView = False

            FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            FrmReportViewer.Text = "Journal No. " & journal_no
            FrmReportViewer.WindowState = FormWindowState.Maximized
            FrmReportViewer.ShowDialog()
            FrmReportViewer.Dispose()
            FrmReportViewer = Nothing
        Else
            MessageBoxWarning("Journal not found.")
        End If
        GS_CursorLoadingOn(False)

    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Close()
        GS_CursorLoadingOn(True)
        JournalAccountProccess(cmbPageFormat.SelectedValue, cmbPageFormat.Text)
        If journal_no <> 0 Then
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        Else
            MessageBoxWarning("Journal not found.")
        End If

        GS_CursorLoadingOn(False)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class