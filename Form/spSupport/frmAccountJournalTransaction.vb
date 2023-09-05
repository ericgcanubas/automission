Imports System.Data.Odbc
Public Class frmAccountJournalTransaction

    Public gsID As String
    Public objDate As Date
    Public gsLocation_Id As Integer
    Public gsObject_Type As Integer
    Public gsAccount_Id As Integer
    Public journal_no As Integer
    Public type_name As String

    Private Sub frmAccountJournalTransaction_Load(sender As Object, e As EventArgs) Handles Me.Load

        fBackGroundImageStyle(Me)
        type_name = fGetFieldValue("object_type_map", "ID", gsObject_Type, "Name")

        ' Dim sQuery As String = "Select a.`NAME` as`Account`,  if(aj.entry_type = 0,format(aj.AMOUNT,2),'') as `Debit`, if(aj.entry_type = 1,format(aj.AMOUNT,2),'') as `Credit` from account_journal as aj inner join account as a on a.ID = aj.ACCOUNT_ID  where aj.Location_ID = '" & gsLocation_Id & "' and aj.Object_date = '" & Format(objDate, "yyyy-MM-dd") & "' and aj.JOURNAL_NO = (select a.JOURNAL_NO from account_journal as a  where a.object_type = '" & gsObject_Type & "' and a.object_id = '" & gsID & "' and a.account_id = '" & gsAccount_Id & "' limit 1)  "

        fMS_ComboBox(cmbPageFormat, "select [file_name],[print_title] from tblprint Where [form_name] ='" & Me.Name & "' order by [print_default] desc ", "file_name", "print_title")

    End Sub
    Private Sub fAJProccess(ByVal prFile As String, ByVal prTitle As String)


        Try




            Dim rd As OdbcDataReader = fReader($"SELECT  a.JOURNAL_NO  FROM account_journal AS a WHERE a.object_type = '{gsObject_Type}' AND a.object_id ='{gsID}' AND a.account_id ='{gsAccount_Id}'   LIMIT 1")
            If rd.Read Then
                journal_no = fNumisNULL(rd("JOURNAL_NO"))
                gsReportFileName = prFile
                gsReportName = prTitle & " " & type_name
                gsReportTabName = "Journal (" & journal_no & ")"
                gscryRpt = fViewReportOneParameterNumberOnly(gsReportFileName)
                fCryParameterInsertValue(gscryRpt, journal_no, "journal_no")
                fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
                fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            End If
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fAJProccess(prFile, prTitle)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        Me.Close()
        fCursorLoadingOn(True)
        fAJProccess(cmbPageFormat.SelectedValue, cmbPageFormat.Text)
        If journal_no <> 0 Then
            '  fReportExporPDF(gscryRpt, gsReportTabName)
            gsToolPanelView = False
            ' fPreviewReport(gsReportTabName)
            frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            frmReportViewer.Text = "Journal No. " & journal_no
            frmReportViewer.WindowState = FormWindowState.Maximized
            frmReportViewer.ShowDialog()
            frmReportViewer.Dispose()
            frmReportViewer = Nothing
        Else
            fMessageboxWarning("Journal not found.")
        End If
        fCursorLoadingOn(False)

    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Me.Close()
        fCursorLoadingOn(True)
        fAJProccess(cmbPageFormat.SelectedValue, cmbPageFormat.Text)
        If journal_no <> 0 Then
            gscryRpt.PrintToPrinter(1, False, 0, 0)
        Else
            fMessageboxWarning("Journal not found.")
        End If
        'fReportExporPDF(gscryRpt, gsReportTabName)
        fCursorLoadingOn(False)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class