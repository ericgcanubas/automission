Public Class frmPOSLogSettings
    Private Sub frmPOSLogSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PRINT_OS_AFTER_SAVE_INVOICE
        fLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsPOS_DEFAULT_PRINTER

        fPOSRefreshFormat(cmbPrinterPage, frmSalesReceipt.Name)
        frmSalesReceipt = Nothing

        chkPOSPrintPreview.Checked = fSystemSettingValue_Bool("POSPrintPreview")
        xchkOR_REQUIRED.Checked = fGet_System_VALUE("OR_REQUIRED")
        xchkPOS_STARTING_CASH.Checked = fGet_System_VALUE_Bool("POS_STARTING_CASH")

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '========================================
        fMS_execute("update tblprint set [print_default] = '0' where [form_name] = '" & frmSalesReceipt.Name & "'  and  [print_default] = '1'  ")
        fMS_execute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage.SelectedValue & "' and [print_title] = '" & cmbPrinterPage.Text & "' and [form_name] = '" & frmSalesReceipt.Name & "' ")

        frmSalesReceipt = Nothing
        '========================================


        gsPOS_DEFAULT_PRINTER = TextIsNull(cmbPRINTER.Text)
        fSET_SYSTEM_VALUE("POS_DEFAULT_PRINTER", gsPOS_DEFAULT_PRINTER)




        fSET_SYSTEM_VALUE("OR_REQUIRED", xchkOR_REQUIRED.Checked)

        fSET_SYSTEM_VALUE("POS_STARTING_CASH", xchkPOS_STARTING_CASH.Checked)
        fSystemSettingUpdateByBool("POSPrintPreview", chkPOSPrintPreview.Checked)

        MessageBoxInfo("Please re-login again.")
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class