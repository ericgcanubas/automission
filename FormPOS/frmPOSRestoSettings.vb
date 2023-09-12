Public Class FrmPOSRestoSettings
    Private Sub FrmPOSRestoSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PRINT_OS_AFTER_SAVE_INVOICE
        SystemLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsPOS_DEFAULT_PRINTER

        fPOSRefreshFormat(cmbPrinterPage, frmSalesOrder.Name)
        frmSalesOrder = Nothing

        fPOSRefreshFormat(cmbPrinterPage2, frmInvoice.Name)
        frmInvoice = Nothing


        fPOSRefreshFormat(cmbPrinterPage3, frmReceivePayment.Name)
        frmReceivePayment = Nothing


        fPOSRefreshFormat(cmbPrinterPage4, "frmPOSLogResto")


        chkSmallBoxMonitoring.Checked = CBool(Val(GetDBAccessValueByText("USE_SMALL_BOX")))
        numCUSTOM_DINE_IN_NO.Value = Val(GetDBAccessValueByText("CUSTOM_DINE_IN_NO"))

        chkMsgPrintPayment.Checked = CBool(Val(GetDBAccessValueByText("MSG_PRINT_PAYMENT")))
        'PRINT_INVOICE_AFTER_PRINT_PAYMENT
        chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Checked = CBool(Val(GetDBAccessValueByText("PRINT_INVOICE_AFTER_PRINT_PAYMENT")))

        chkPRINT_OS_AFTER_SAVE_INVOICE.Checked = CBool(Val(GetDBAccessValueByText("PRINT_OS_AFTER_SAVE_INVOICE")))

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '========================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & frmSalesOrder.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage.SelectedValue & "' and [print_title] = '" & cmbPrinterPage.Text & "' and [form_name] = '" & frmSalesOrder.Name & "' ")

        '========================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & frmInvoice.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage2.SelectedValue & "' and [print_title] = '" & cmbPrinterPage2.Text & "' and [form_name] = '" & frmInvoice.Name & "' ")


        '=======================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & frmReceivePayment.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage3.SelectedValue & "' and [print_title] = '" & cmbPrinterPage3.Text & "' and [form_name] = '" & frmReceivePayment.Name & "' ")
        '========================================

        '=======================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & "frmPOSLogResto" & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage4.SelectedValue & "' and [print_title] = '" & cmbPrinterPage4.Text & "' and [form_name] = '" & "frmPOSLogResto" & "' ")
        '========================================


        gsPOS_DEFAULT_PRINTER = TextIsNull(cmbPRINTER.Text)
        SetDBAccessValue("POS_DEFAULT_PRINTER", gsPOS_DEFAULT_PRINTER)

        SetDBAccessValue("USE_SMALL_BOX", NumIsNull(chkSmallBoxMonitoring.Checked))
        SetDBAccessValue("CUSTOM_DINE_IN_NO", NumIsNull(numCUSTOM_DINE_IN_NO.Value))
        SetDBAccessValue("MSG_PRINT_PAYMENT", NumIsNull(chkMsgPrintPayment.Checked))
        SetDBAccessValue("PRINT_INVOICE_AFTER_PRINT_PAYMENT", NumIsNull(chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Checked))
        SetDBAccessValue("PRINT_OS_AFTER_SAVE_INVOICE", NumIsNull(chkPRINT_OS_AFTER_SAVE_INVOICE.Checked))

        Me.Close()

    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage.SelectedValue
        Catch ex As Exception

        End Try

        FrmPrintPageSettings.ThisForm = frmSalesOrder.Name
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            fPOSRefreshFormat(cmbPrinterPage, frmSalesOrder.Name)
        End If
        frmSalesOrder = Nothing

    End Sub


    Private Sub btnSettings2_Click(sender As Object, e As EventArgs) Handles btnSettings2.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage2.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage2.SelectedValue
        Catch ex As Exception
        End Try
        FrmPrintPageSettings.ThisForm = frmInvoice.Name
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            fPOSRefreshFormat(cmbPrinterPage2, frmInvoice.Name)
        End If
        frmInvoice = Nothing
    End Sub

    Private Sub btnSettings3_Click(sender As Object, e As EventArgs) Handles btnSettings3.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage3.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage3.SelectedValue
        Catch ex As Exception

        End Try

        FrmPrintPageSettings.ThisForm = frmReceivePayment.Name
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            fPOSRefreshFormat(cmbPrinterPage3, frmReceivePayment.Name)
        End If
        frmReceivePayment = Nothing
    End Sub

    Private Sub btnSettings4_Click(sender As Object, e As EventArgs) Handles btnSettings4.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage4.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage4.SelectedValue
        Catch ex As Exception

        End Try

        FrmPrintPageSettings.ThisForm = "frmPOSLogResto"
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            fPOSRefreshFormat(cmbPrinterPage4, "frmPOSLogResto")
        End If

    End Sub

    Private Sub cmbPrinterPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPrinterPage.SelectedIndexChanged

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class