Imports Microsoft.Office.Interop
Module modExport
    Public gsFolderDialog As FolderBrowserDialog
    Public Sub fExport(ByVal dgv As DataGridView, prFilename As String)
        Try



            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim misValue As Object = System.Reflection.Missing.Value

            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("sheet1")

            Try
                For CurrentRowIndex As Integer = 0 To dgv.RowCount - 1 'current row index
                    'xlWorkSheet.Cells(1, 1) = "With Headers"
                    Dim col As Integer = 0
                    For CurrentColumnIndex As Integer = 0 To dgv.ColumnCount - 1 'current column index within row index
                        If dgv.Columns(CurrentColumnIndex).Visible = True Then
                            xlWorkSheet.Cells(2, col + 1) = dgv.Columns(CurrentColumnIndex).HeaderText 'display header
                            xlWorkSheet.Cells(CurrentRowIndex + 3, col + 1) = dgv(CurrentColumnIndex, CurrentRowIndex).Value.ToString()
                            col = col + 1
                        End If

                    Next
                Next

            Catch ex As Exception
                MsgBox("Unable to extract data" & ex.Message, MsgBoxStyle.Critical)
                Exit Sub
            End Try


            xlWorkBook.Activate()

            '//get path
            gsFolderDialog.ShowDialog()
            Dim path As String = gsFolderDialog.SelectedPath

            xlWorkBook.SaveAs(path & "\" & prFilename & ".xls")
            'xlWorkSheet.SaveAs("burn permit export.xls")

            xlWorkBook.Close()
            xlApp.Quit()
        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try
    End Sub

End Module
