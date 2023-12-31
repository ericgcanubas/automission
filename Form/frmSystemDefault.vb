﻿Public Class FrmSystemDefault
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        gsDEFAULT_PRINTER = cmbPrinter.Text
        SetDBAccessValue("DEFAULT_PRINTER", gsDEFAULT_PRINTER) 'DEFAULT

        gsPOS_DEFAULT_PRINTER = cmbPOS_PRINTER.Text
        SetDBAccessValue("POS_DEFAULT_PRINTER", gsPOS_DEFAULT_PRINTER) 'POS DEFAULT

        SetDBAccessValue("ExportPDFLocation", txsExportPDFLocation.Text) 'TEMPORARY
        gsExportPDFLocation = txsExportPDFLocation.Text

        SetDBAccessValue("SCREEN_BUTTON", IIf(xchkUSE_SCREEN_BUTTON.Checked = True, 1, 0))
        SetDBAccessValue("POS_MACHINE_ID", xnumPOS_ID.Value) 'TEMPORARY
        SetDBAccessValue("OR_REQUIRED", xchkOR_REQUIRED.Checked)
        SetDBAccessValue("POS_DRAWER_ACCOUNT_ID_PER_UNIT", xcmbDrawerAccountId.SelectedValue)
        SetDBAccessValue("POS_STARTING_CASH", xchkPOS_STARTING_CASH.Checked)

        SetDBAccessValue("OpenCashDrawer", chkOpenCashDrawer.Checked)
        SetDBAccessValue("PrintOS", chkPrintOS.Checked)
        SetDBAccessValue("POSMultiMethod", chkPOSMultiMethod.Checked)
        SetDBAccessValue("UseCashDenomination", chkUseCashDenomination.Checked)
        SetDBAccessValue("CloseDateRunPerUnit", chkCloseDateRunPerUnit.Checked)


        SetDBAccessValue("DataForwarderIsActive", chkDataForwarderIsActive.Checked)
        SetDBAccessValue("DataForwarderPath", txtDataForwarderPath.Text)
        gsDataForwarderPath = txtDataForwarderPath.Text

        MessageBoxInfo(Me.Text & " =  Save")

    End Sub

    Private Sub BtnBrowser_Click(sender As Object, e As EventArgs) Handles btnBrowser.Click
        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            txsExportPDFLocation.Text = FolderBrowserDialog1.SelectedPath
        End If
    End Sub

    Private Sub FrmSystemDefault_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(xcmbDrawerAccountId, "SELECT a.ID, a.NAME  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME", "ID", "T")
        SystemLoadPrinter(cmbPrinter)
        cmbPrinter.Text = gsDEFAULT_PRINTER

        SystemLoadPrinter(cmbPOS_PRINTER)
        cmbPOS_PRINTER.Text = gsPOS_DEFAULT_PRINTER

        If cmbPrinter.Text = "" Then
            cmbPrinter.Text = gsPOS_WINDOWS_PRINTER
        End If

        If cmbPOS_PRINTER.Text = "" Then
            cmbPOS_PRINTER.Text = gsPOS_WINDOWS_PRINTER
        End If

        xchkUSE_SCREEN_BUTTON.Checked = gsUSE_SCREEN_BUTTON
        txsExportPDFLocation.Text = gsExportPDFLocation
        xnumPOS_ID.Value = GF_GetPosMachineId()
        xchkOR_REQUIRED.Checked = GF_IsPosOfficialReceiptRequired()
        xcmbDrawerAccountId.SelectedValue = GF_PosDrawerAccountIdPerUnit()
        xchkPOS_STARTING_CASH.Checked = GF_PosStartingCash()


        chkOpenCashDrawer.Checked = CBool(GetDBAccessValueByBool("OpenCashDrawer"))
        chkPrintOS.Checked = CBool(GetDBAccessValueByBool("PrintOS"))
        chkPOSMultiMethod.Checked = CBool(GetDBAccessValueByBool("POSMultiMethod"))
        chkUseCashDenomination.Checked = CBool(GetDBAccessValueByBool("UseCashDenomination"))
        chkCloseDateRunPerUnit.Checked = CBool(GetDBAccessValueByBool("CloseDateRunPerUnit"))

        chkDataForwarderIsActive.Checked = gsDataForwarderIsActive ' CBool(GetDBAccessValueByBool("DataForwarderIsActive"))
        txtDataForwarderPath.Text = gsDataForwarderPath
    End Sub

    Private Sub BtnPOS_Click(sender As Object, e As EventArgs) Handles btnPOS.Click
        FrmPOSSetting.ShowDialog()
        FrmPOSSetting.Dispose()
        FrmPOSSetting = Nothing
    End Sub
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


End Class