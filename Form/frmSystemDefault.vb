Public Class FrmSystemDefault
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        gsDEFAULT_PRINTER = cmbPrinter.Text
        fSET_SYSTEM_VALUE("DEFAULT_PRINTER", gsDEFAULT_PRINTER) 'DEFAULT

        gsPOS_DEFAULT_PRINTER = cmbPOS_PRINTER.Text
        fSET_SYSTEM_VALUE("POS_DEFAULT_PRINTER", gsPOS_DEFAULT_PRINTER) 'POS DEFAULT

        fSET_SYSTEM_VALUE("ExportPDFLocation", txsExportPDFLocation.Text) 'TEMPORARY
        gsExportPDFLocation = txsExportPDFLocation.Text

        fSET_SYSTEM_VALUE("SCREEN_BUTTON", IIf(xchkUSE_SCREEN_BUTTON.Checked = True, 1, 0))
        fSET_SYSTEM_VALUE("POS_MACHINE_ID", xnumPOS_ID.Value) 'TEMPORARY
        fSET_SYSTEM_VALUE("OR_REQUIRED", xchkOR_REQUIRED.Checked)
        fSET_SYSTEM_VALUE("POS_DRAWER_ACCOUNT_ID_PER_UNIT", xcmbDrawerAccountId.SelectedValue)
        fSET_SYSTEM_VALUE("POS_STARTING_CASH", xchkPOS_STARTING_CASH.Checked)

        fSET_SYSTEM_VALUE("OpenCashDrawer", chkOpenCashDrawer.Checked)
        fSET_SYSTEM_VALUE("PrintOS", chkPrintOS.Checked)
        fSET_SYSTEM_VALUE("POSMultiMethod", chkPOSMultiMethod.Checked)
        fSET_SYSTEM_VALUE("UseCashDenomination", chkUseCashDenomination.Checked)
        fSET_SYSTEM_VALUE("CloseDateRunPerUnit", chkCloseDateRunPerUnit.Checked)


        fSET_SYSTEM_VALUE("DataForwarderIsActive", chkDataForwarderIsActive.Checked)
        fSET_SYSTEM_VALUE("DataForwarderPath", txtDataForwarderPath.Text)
        gsDataForwarderPath = txtDataForwarderPath.Text

        MessageBoxInfo(Me.Text & " =  Save")

    End Sub

    Private Sub btnBrowser_Click(sender As Object, e As EventArgs) Handles btnBrowser.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txsExportPDFLocation.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub frmSystemDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(xcmbDrawerAccountId, "SELECT a.ID, a.NAME  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME", "ID", "T")
        fLoadPrinter(cmbPrinter)
        cmbPrinter.Text = gsDEFAULT_PRINTER

        fLoadPrinter(cmbPOS_PRINTER)
        cmbPOS_PRINTER.Text = gsPOS_DEFAULT_PRINTER

        If cmbPrinter.Text = "" Then
            cmbPrinter.Text = gsPOS_WINDOWS_PRINTER
        End If

        If cmbPOS_PRINTER.Text = "" Then
            cmbPOS_PRINTER.Text = gsPOS_WINDOWS_PRINTER
        End If

        xchkUSE_SCREEN_BUTTON.Checked = gsUSE_SCREEN_BUTTON
        txsExportPDFLocation.Text = gsExportPDFLocation
        xnumPOS_ID.Value = fPOS_MACHINE_ID()
        xchkOR_REQUIRED.Checked = fPOS_OR_Required()
        xcmbDrawerAccountId.SelectedValue = fPOS_Drawer_Account_PER_UNIT()
        xchkPOS_STARTING_CASH.Checked = fPOS_STARTING_CASH()


        chkOpenCashDrawer.Checked = CBool(fGet_System_VALUE_Bool("OpenCashDrawer"))
        chkPrintOS.Checked = CBool(fGet_System_VALUE_Bool("PrintOS"))
        chkPOSMultiMethod.Checked = CBool(fGet_System_VALUE_Bool("POSMultiMethod"))
        chkUseCashDenomination.Checked = CBool(fGet_System_VALUE_Bool("UseCashDenomination"))
        chkCloseDateRunPerUnit.Checked = CBool(fGet_System_VALUE_Bool("CloseDateRunPerUnit"))

        chkDataForwarderIsActive.Checked = gsDataForwarderIsActive ' CBool(fGet_System_VALUE_Bool("DataForwarderIsActive"))
        txtDataForwarderPath.Text = gsDataForwarderPath
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        frmPOSSetting.ShowDialog()
        frmPOSSetting.Dispose()
        frmPOSSetting = Nothing
    End Sub

    Private Sub grpExport_Enter(sender As Object, e As EventArgs) Handles grpExport.Enter

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

End Class