Public Class FrmPOSLogSettings
    Private Sub FrmPOSLogSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PRINT_OS_AFTER_SAVE_INVOICE
        SystemLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsPOS_DEFAULT_PRINTER

        GS_PosRefreshFormat(cmbPrinterPage, FrmSalesReceipt.Name)
        FrmSalesReceipt = Nothing

        chkPOSPrintPreview.Checked = GetSystemSettingValueByBool("POSPrintPreview")
        xchkOR_REQUIRED.Checked = GetDBAccessValueByText("OR_REQUIRED")
        xchkPOS_STARTING_CASH.Checked = GetDBAccessValueByBool("POS_STARTING_CASH")

    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '========================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & FrmSalesReceipt.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage.SelectedValue & "' and [print_title] = '" & cmbPrinterPage.Text & "' and [form_name] = '" & FrmSalesReceipt.Name & "' ")

        FrmSalesReceipt = Nothing
        '=======================================
        gsPOS_DEFAULT_PRINTER = GF_TextIsNull(cmbPRINTER.Text)
        SetDBAccessValue("POS_DEFAULT_PRINTER", gsPOS_DEFAULT_PRINTER)
        SetDBAccessValue("OR_REQUIRED", xchkOR_REQUIRED.Checked)
        SetDBAccessValue("POS_STARTING_CASH", xchkPOS_STARTING_CASH.Checked)
        SetSystemSettingUpdateByBool("POSPrintPreview", chkPOSPrintPreview.Checked)
        MessageBoxInfo("Please re-login again.")
        Me.Close()

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class