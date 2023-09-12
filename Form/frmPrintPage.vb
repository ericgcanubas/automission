Public Class FrmPrintPage
    Public frmName As String
    Public prValue As Integer = 0
    Private Sub FrmPrintPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        RefreshList()

        SystemLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsDEFAULT_PRINTER
        prValue = 0
    End Sub
    Private Sub RefreshList()
        DBAccessComboBoxLoad(cmbPrinterPage, "select [file_name],[print_title] from tblprint Where [form_name] ='" & frmName & "' order by [print_default] desc ", "file_name", "print_title")
    End Sub
    Private Sub BtnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        If cmbPRINTER.Text.Trim = "" Then
            MessageBoxInfo("Please select printer")
            Exit Sub
        End If
        SystemSetDefaultPrinter(cmbPRINTER.Text)

        prValue = 2 ' preview
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & frmName & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage.SelectedValue & "' and [print_title] = '" & cmbPrinterPage.Text & "' and [form_name] = '" & frmName & "' ")
        Me.Close()
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If cmbPRINTER.Text.Trim = "" Then
            MessageBoxInfo("Please select printer")
            Exit Sub
        End If

        SystemSetDefaultPrinter(cmbPRINTER.Text)
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & frmName & "' and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage.SelectedValue & "' and [print_title] = '" & cmbPrinterPage.Text & "' and [form_name] = '" & frmName & "' ")
        prValue = 1 ' print
        Me.Close()
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage.SelectedValue
        Catch ex As Exception

        End Try



        FrmPrintPageSettings.ThisForm = frmName
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            RefreshList()
        End If



    End Sub
End Class