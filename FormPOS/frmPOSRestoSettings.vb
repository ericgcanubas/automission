Public Class FrmPOSRestoSettings
    Private Sub FrmPOSRestoSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'PRINT_OS_AFTER_SAVE_INVOICE
        SystemLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsPOS_DEFAULT_PRINTER
        GS_PosRefreshFormat(cmbPrinterPage, frmSalesOrder.Name)
        FrmSalesOrder = Nothing
        GS_PosRefreshFormat(cmbPrinterPage2, frmInvoice.Name)
        FrmInvoice = Nothing
        GS_PosRefreshFormat(cmbPrinterPage3, frmReceivePayment.Name)
        FrmReceivePayment = Nothing
        GS_PosRefreshFormat(cmbPrinterPage4, "frmPOSLogResto")


        chkSmallBoxMonitoring.Checked = CBool(Val(GetDBAccessValueByText("USE_SMALL_BOX")))
        numCUSTOM_DINE_IN_NO.Value = Val(GetDBAccessValueByText("CUSTOM_DINE_IN_NO"))

        chkMsgPrintPayment.Checked = CBool(Val(GetDBAccessValueByText("MSG_PRINT_PAYMENT")))
        chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Checked = CBool(Val(GetDBAccessValueByText("PRINT_INVOICE_AFTER_PRINT_PAYMENT")))

        chkPRINT_OS_AFTER_SAVE_INVOICE.Checked = CBool(Val(GetDBAccessValueByText("PRINT_OS_AFTER_SAVE_INVOICE")))

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '========================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & FrmSalesOrder.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage.SelectedValue & "' and [print_title] = '" & cmbPrinterPage.Text & "' and [form_name] = '" & FrmSalesOrder.Name & "' ")

        '========================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & FrmInvoice.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage2.SelectedValue & "' and [print_title] = '" & cmbPrinterPage2.Text & "' and [form_name] = '" & FrmInvoice.Name & "' ")


        '=======================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & FrmReceivePayment.Name & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage3.SelectedValue & "' and [print_title] = '" & cmbPrinterPage3.Text & "' and [form_name] = '" & FrmReceivePayment.Name & "' ")
        '========================================

        '=======================================
        DbAccessExecute("update tblprint set [print_default] = '0' where [form_name] = '" & "frmPOSLogResto" & "'  and  [print_default] = '1'  ")
        DbAccessExecute("update tblprint set [print_default] = '1' where [file_name] = '" & cmbPrinterPage4.SelectedValue & "' and [print_title] = '" & cmbPrinterPage4.Text & "' and [form_name] = '" & "frmPOSLogResto" & "' ")
        '========================================


        gsPOS_DEFAULT_PRINTER = GF_TextIsNull(cmbPRINTER.Text)
        SetDBAccessValue("POS_DEFAULT_PRINTER", gsPOS_DEFAULT_PRINTER)

        SetDBAccessValue("USE_SMALL_BOX", GF_NumIsNull(chkSmallBoxMonitoring.Checked))
        SetDBAccessValue("CUSTOM_DINE_IN_NO", GF_NumIsNull(numCUSTOM_DINE_IN_NO.Value))
        SetDBAccessValue("MSG_PRINT_PAYMENT", GF_NumIsNull(chkMsgPrintPayment.Checked))
        SetDBAccessValue("PRINT_INVOICE_AFTER_PRINT_PAYMENT", GF_NumIsNull(chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Checked))
        SetDBAccessValue("PRINT_OS_AFTER_SAVE_INVOICE", GF_NumIsNull(chkPRINT_OS_AFTER_SAVE_INVOICE.Checked))

        Me.Close()

    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage.SelectedValue
        Catch ex As Exception

        End Try

        FrmPrintPageSettings.ThisForm = FrmSalesOrder.Name
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            GS_PosRefreshFormat(cmbPrinterPage, FrmSalesOrder.Name)
        End If
        FrmSalesOrder = Nothing

    End Sub


    Private Sub BtnSettings2_Click(sender As Object, e As EventArgs) Handles btnSettings2.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage2.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage2.SelectedValue
        Catch ex As Exception
        End Try
        FrmPrintPageSettings.ThisForm = FrmInvoice.Name
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            GS_PosRefreshFormat(cmbPrinterPage2, FrmInvoice.Name)
        End If
        FrmInvoice = Nothing
    End Sub

    Private Sub BtnSettings3_Click(sender As Object, e As EventArgs) Handles btnSettings3.Click
        Try
            FrmPrintPageSettings.txtPRINT_TITLE.Text = cmbPrinterPage3.Text
            FrmPrintPageSettings.txtFILE_NAME.Text = cmbPrinterPage3.SelectedValue
        Catch ex As Exception

        End Try

        FrmPrintPageSettings.ThisForm = FrmReceivePayment.Name
        FrmPrintPageSettings.ShowDialog()
        Dim ClickOK As Boolean = FrmPrintPageSettings.gsClickOK
        FrmPrintPageSettings.Dispose()
        FrmPrintPageSettings = Nothing
        If ClickOK = True Then
            GS_PosRefreshFormat(cmbPrinterPage3, FrmReceivePayment.Name)
        End If
        FrmReceivePayment = Nothing
    End Sub

    Private Sub BtnSettings4_Click(sender As Object, e As EventArgs) Handles btnSettings4.Click
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
            GS_PosRefreshFormat(cmbPrinterPage4, "frmPOSLogResto")
        End If

    End Sub


End Class