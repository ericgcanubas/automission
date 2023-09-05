<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.tabMenu = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.dtpBusinessStart = New System.Windows.Forms.DateTimePicker()
        Me.txtReportDisplay2 = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.txtReportDisplay = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.rtbCompanyAddress = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCompanyMobileNo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCompanyFaxNo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCompanyPhoneNo = New System.Windows.Forms.TextBox()
        Me.txtCompanyEmailAddress = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLegalName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbBusinessType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCompanyName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.btnEmailSetup = New System.Windows.Forms.Button()
        Me.chkNotUseStorageLocation = New System.Windows.Forms.CheckBox()
        Me.cmbStorageLocationId = New System.Windows.Forms.ComboBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.chkLockLocation = New System.Windows.Forms.CheckBox()
        Me.chkIncRefNoByLocation = New System.Windows.Forms.CheckBox()
        Me.chkAllowTransactionLinkToMultiLocation = New System.Windows.Forms.CheckBox()
        Me.chkAllowListQuickAdd = New System.Windows.Forms.CheckBox()
        Me.chkLockDefaultLocation = New System.Windows.Forms.CheckBox()
        Me.cmbNewTransactionsDefaultDate = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbDefaultLocationId = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.chkSkipJournalEntry = New System.Windows.Forms.CheckBox()
        Me.numSmallestCurrencyValue = New System.Windows.Forms.NumericUpDown()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkClosingDatePassword = New System.Windows.Forms.CheckBox()
        Me.dtpClosingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.numDateWarningDaysFuture = New System.Windows.Forms.NumericUpDown()
        Me.numDateWarningDaysPast = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.chkHideInactiveCustomer = New System.Windows.Forms.CheckBox()
        Me.chkEnableBatchNumberInSalesOrder = New System.Windows.Forms.CheckBox()
        Me.chkWarnWhenPriceBelowCost = New System.Windows.Forms.CheckBox()
        Me.chkAllowPriceLevel = New System.Windows.Forms.CheckBox()
        Me.chkAllowBlankInSellingPrice = New System.Windows.Forms.CheckBox()
        Me.chkAllowPriceOverride = New System.Windows.Forms.CheckBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.chkUseUndepositedFunds = New System.Windows.Forms.CheckBox()
        Me.chkAutoCalcPayments = New System.Windows.Forms.CheckBox()
        Me.chkAutoApplyPayments = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.chkShowPostdatedTransactions = New System.Windows.Forms.CheckBox()
        Me.chkPrintDueDateOnStatement = New System.Windows.Forms.CheckBox()
        Me.chkCreateStatementWithZeroBalance = New System.Windows.Forms.CheckBox()
        Me.chkShowInvoiceDetailsOnStatement = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbArAgingLimit = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cmbCreditLimitPolicy = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cmbDefaultPaymentMethodId = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbDefaultPaymentTermsId = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.numRunningPenaltyRate = New System.Windows.Forms.NumericUpDown()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.numFixedPenaltyRate = New System.Windows.Forms.NumericUpDown()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.CheckBox20 = New System.Windows.Forms.CheckBox()
        Me.CheckBox19 = New System.Windows.Forms.CheckBox()
        Me.cmbFinanceChargeItemId = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cmbFinanceChargeAccountId = New System.Windows.Forms.ComboBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.numFinanceChargeGracePeriod = New System.Windows.Forms.NumericUpDown()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.numFinanceChargeAnnualInterestRate = New System.Windows.Forms.NumericUpDown()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.btnImageSetup = New System.Windows.Forms.Button()
        Me.chkSkipInventoryEntry = New System.Windows.Forms.CheckBox()
        Me.chkLockQtyNeededInBuildAssembly = New System.Windows.Forms.CheckBox()
        Me.chkAllowZeroOnHand = New System.Windows.Forms.CheckBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.chkShowQtyOnSO = New System.Windows.Forms.CheckBox()
        Me.chkShowExpiryDate = New System.Windows.Forms.CheckBox()
        Me.chkShowBatchNo = New System.Windows.Forms.CheckBox()
        Me.chkShowLastPurchaseInfo = New System.Windows.Forms.CheckBox()
        Me.chkShowUnitCost = New System.Windows.Forms.CheckBox()
        Me.chkShowStockBin = New System.Windows.Forms.CheckBox()
        Me.chkShowItemFinderMaximized = New System.Windows.Forms.CheckBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.numSafetyStockPctLevel = New System.Windows.Forms.NumericUpDown()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbDefaultForecastingType = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.chkInvisibleGroup = New System.Windows.Forms.CheckBox()
        Me.chkExpiredReference = New System.Windows.Forms.CheckBox()
        Me.chkDefaultItemTaxable = New System.Windows.Forms.CheckBox()
        Me.cmbDefaultItemStockType = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TabPage7 = New System.Windows.Forms.TabPage()
        Me.cmbTaxCreditAccountId = New System.Windows.Forms.ComboBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.cmbTaxPayableAccountId = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.cmbInputTaxId = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.cmbExpandedWithholdingTaxId = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.cmbOutputTaxId = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.txtCompanyTin = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TabPage8 = New System.Windows.Forms.TabPage()
        Me.cmbDefaultVendorID = New System.Windows.Forms.ComboBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cmbTargetPenaltyDiscount = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.cmbDefaultPenaltyType = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.numServiceFee = New System.Windows.Forms.NumericUpDown()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.numManagerGetDealerSalesTarget = New System.Windows.Forms.NumericUpDown()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.numManagerRebites = New System.Windows.Forms.NumericUpDown()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSystemDefault = New System.Windows.Forms.Button()
        Me.btnDefaultValue = New System.Windows.Forms.Button()
        Me.tabMenu.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.numSmallestCurrencyValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numDateWarningDaysFuture, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDateWarningDaysPast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        CType(Me.numRunningPenaltyRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFixedPenaltyRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFinanceChargeGracePeriod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFinanceChargeAnnualInterestRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.numSafetyStockPctLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage7.SuspendLayout()
        Me.TabPage8.SuspendLayout()
        CType(Me.numServiceFee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numManagerGetDealerSalesTarget, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numManagerRebites, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabMenu
        '
        Me.tabMenu.Controls.Add(Me.TabPage1)
        Me.tabMenu.Controls.Add(Me.TabPage2)
        Me.tabMenu.Controls.Add(Me.TabPage3)
        Me.tabMenu.Controls.Add(Me.TabPage4)
        Me.tabMenu.Controls.Add(Me.TabPage5)
        Me.tabMenu.Controls.Add(Me.TabPage6)
        Me.tabMenu.Controls.Add(Me.TabPage7)
        Me.tabMenu.Controls.Add(Me.TabPage8)
        Me.tabMenu.Location = New System.Drawing.Point(17, 12)
        Me.tabMenu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tabMenu.Name = "tabMenu"
        Me.tabMenu.SelectedIndex = 0
        Me.tabMenu.Size = New System.Drawing.Size(873, 438)
        Me.tabMenu.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label59)
        Me.TabPage1.Controls.Add(Me.dtpBusinessStart)
        Me.TabPage1.Controls.Add(Me.txtReportDisplay2)
        Me.TabPage1.Controls.Add(Me.Label41)
        Me.TabPage1.Controls.Add(Me.txtReportDisplay)
        Me.TabPage1.Controls.Add(Me.Label40)
        Me.TabPage1.Controls.Add(Me.rtbCompanyAddress)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtCompanyMobileNo)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.txtCompanyFaxNo)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.txtCompanyPhoneNo)
        Me.TabPage1.Controls.Add(Me.txtCompanyEmailAddress)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtLegalName)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.cmbBusinessType)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtCompanyName)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage1.Size = New System.Drawing.Size(865, 409)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Company"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(215, 322)
        Me.Label59.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(102, 16)
        Me.Label59.TabIndex = 21
        Me.Label59.Text = "Business Start"
        '
        'dtpBusinessStart
        '
        Me.dtpBusinessStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBusinessStart.Location = New System.Drawing.Point(219, 342)
        Me.dtpBusinessStart.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpBusinessStart.Name = "dtpBusinessStart"
        Me.dtpBusinessStart.Size = New System.Drawing.Size(183, 23)
        Me.dtpBusinessStart.TabIndex = 20
        '
        'txtReportDisplay2
        '
        Me.txtReportDisplay2.Location = New System.Drawing.Point(431, 206)
        Me.txtReportDisplay2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtReportDisplay2.Name = "txtReportDisplay2"
        Me.txtReportDisplay2.Size = New System.Drawing.Size(333, 23)
        Me.txtReportDisplay2.TabIndex = 19
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(427, 185)
        Me.Label41.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(176, 16)
        Me.Label41.TabIndex = 18
        Me.Label41.Text = "Secondary Report Display"
        '
        'txtReportDisplay
        '
        Me.txtReportDisplay.Location = New System.Drawing.Point(431, 155)
        Me.txtReportDisplay.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtReportDisplay.Name = "txtReportDisplay"
        Me.txtReportDisplay.Size = New System.Drawing.Size(333, 23)
        Me.txtReportDisplay.TabIndex = 17
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(427, 134)
        Me.Label40.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(154, 16)
        Me.Label40.TabIndex = 16
        Me.Label40.Text = "Primary Report Display"
        '
        'rtbCompanyAddress
        '
        Me.rtbCompanyAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbCompanyAddress.Location = New System.Drawing.Point(24, 92)
        Me.rtbCompanyAddress.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rtbCompanyAddress.Name = "rtbCompanyAddress"
        Me.rtbCompanyAddress.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbCompanyAddress.Size = New System.Drawing.Size(377, 120)
        Me.rtbCompanyAddress.TabIndex = 4
        Me.rtbCompanyAddress.Text = ""
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 322)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(102, 16)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Mobile Number"
        '
        'txtCompanyMobileNo
        '
        Me.txtCompanyMobileNo.Location = New System.Drawing.Point(24, 342)
        Me.txtCompanyMobileNo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCompanyMobileNo.Name = "txtCompanyMobileNo"
        Me.txtCompanyMobileNo.Size = New System.Drawing.Size(185, 23)
        Me.txtCompanyMobileNo.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(213, 270)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Fax Number"
        '
        'txtCompanyFaxNo
        '
        Me.txtCompanyFaxNo.Location = New System.Drawing.Point(216, 289)
        Me.txtCompanyFaxNo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCompanyFaxNo.Name = "txtCompanyFaxNo"
        Me.txtCompanyFaxNo.Size = New System.Drawing.Size(185, 23)
        Me.txtCompanyFaxNo.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 270)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Phone Number"
        '
        'txtCompanyPhoneNo
        '
        Me.txtCompanyPhoneNo.Location = New System.Drawing.Point(24, 289)
        Me.txtCompanyPhoneNo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCompanyPhoneNo.Name = "txtCompanyPhoneNo"
        Me.txtCompanyPhoneNo.Size = New System.Drawing.Size(185, 23)
        Me.txtCompanyPhoneNo.TabIndex = 10
        '
        'txtCompanyEmailAddress
        '
        Me.txtCompanyEmailAddress.Location = New System.Drawing.Point(24, 236)
        Me.txtCompanyEmailAddress.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCompanyEmailAddress.Name = "txtCompanyEmailAddress"
        Me.txtCompanyEmailAddress.Size = New System.Drawing.Size(377, 23)
        Me.txtCompanyEmailAddress.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(21, 217)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Email Address"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(427, 73)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Legal Name"
        '
        'txtLegalName
        '
        Me.txtLegalName.Location = New System.Drawing.Point(431, 92)
        Me.txtLegalName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtLegalName.Name = "txtLegalName"
        Me.txtLegalName.Size = New System.Drawing.Size(335, 23)
        Me.txtLegalName.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(21, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Postal Address"
        '
        'cmbBusinessType
        '
        Me.cmbBusinessType.FormattingEnabled = True
        Me.cmbBusinessType.Location = New System.Drawing.Point(431, 42)
        Me.cmbBusinessType.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbBusinessType.Name = "cmbBusinessType"
        Me.cmbBusinessType.Size = New System.Drawing.Size(335, 24)
        Me.cmbBusinessType.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(427, 22)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Business Type"
        '
        'txtCompanyName
        '
        Me.txtCompanyName.Location = New System.Drawing.Point(24, 42)
        Me.txtCompanyName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCompanyName.Name = "txtCompanyName"
        Me.txtCompanyName.Size = New System.Drawing.Size(377, 23)
        Me.txtCompanyName.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Company Name"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label63)
        Me.TabPage2.Controls.Add(Me.btnEmailSetup)
        Me.TabPage2.Controls.Add(Me.chkNotUseStorageLocation)
        Me.TabPage2.Controls.Add(Me.cmbStorageLocationId)
        Me.TabPage2.Controls.Add(Me.Label62)
        Me.TabPage2.Controls.Add(Me.chkLockLocation)
        Me.TabPage2.Controls.Add(Me.chkIncRefNoByLocation)
        Me.TabPage2.Controls.Add(Me.chkAllowTransactionLinkToMultiLocation)
        Me.TabPage2.Controls.Add(Me.chkAllowListQuickAdd)
        Me.TabPage2.Controls.Add(Me.chkLockDefaultLocation)
        Me.TabPage2.Controls.Add(Me.cmbNewTransactionsDefaultDate)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.cmbDefaultLocationId)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage2.Size = New System.Drawing.Size(865, 409)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "General"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label63
        '
        Me.Label63.Location = New System.Drawing.Point(365, 176)
        Me.Label63.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(488, 22)
        Me.Label63.TabIndex = 17
        Me.Label63.Text = "Notes : email sending for Error (screen shoot) and login entry"
        '
        'btnEmailSetup
        '
        Me.btnEmailSetup.Location = New System.Drawing.Point(369, 145)
        Me.btnEmailSetup.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnEmailSetup.Name = "btnEmailSetup"
        Me.btnEmailSetup.Size = New System.Drawing.Size(195, 27)
        Me.btnEmailSetup.TabIndex = 16
        Me.btnEmailSetup.Text = "Auto Send Email  Setup"
        Me.btnEmailSetup.UseVisualStyleBackColor = True
        '
        'chkNotUseStorageLocation
        '
        Me.chkNotUseStorageLocation.AutoSize = True
        Me.chkNotUseStorageLocation.Location = New System.Drawing.Point(739, 96)
        Me.chkNotUseStorageLocation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkNotUseStorageLocation.Name = "chkNotUseStorageLocation"
        Me.chkNotUseStorageLocation.Size = New System.Drawing.Size(78, 20)
        Me.chkNotUseStorageLocation.TabIndex = 15
        Me.chkNotUseStorageLocation.Text = "Not Use"
        Me.chkNotUseStorageLocation.UseVisualStyleBackColor = True
        '
        'cmbStorageLocationId
        '
        Me.cmbStorageLocationId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbStorageLocationId.FormattingEnabled = True
        Me.cmbStorageLocationId.Location = New System.Drawing.Point(245, 91)
        Me.cmbStorageLocationId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbStorageLocationId.Name = "cmbStorageLocationId"
        Me.cmbStorageLocationId.Size = New System.Drawing.Size(469, 24)
        Me.cmbStorageLocationId.TabIndex = 14
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(23, 95)
        Me.Label62.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(120, 16)
        Me.Label62.TabIndex = 13
        Me.Label62.Text = "Storage Location"
        '
        'chkLockLocation
        '
        Me.chkLockLocation.AutoSize = True
        Me.chkLockLocation.Location = New System.Drawing.Point(739, 27)
        Me.chkLockLocation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkLockLocation.Name = "chkLockLocation"
        Me.chkLockLocation.Size = New System.Drawing.Size(61, 20)
        Me.chkLockLocation.TabIndex = 12
        Me.chkLockLocation.Text = "Lock "
        Me.chkLockLocation.UseVisualStyleBackColor = True
        '
        'chkIncRefNoByLocation
        '
        Me.chkIncRefNoByLocation.AutoSize = True
        Me.chkIncRefNoByLocation.Location = New System.Drawing.Point(27, 236)
        Me.chkIncRefNoByLocation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkIncRefNoByLocation.Name = "chkIncRefNoByLocation"
        Me.chkIncRefNoByLocation.Size = New System.Drawing.Size(399, 20)
        Me.chkIncRefNoByLocation.TabIndex = 11
        Me.chkIncRefNoByLocation.Text = "Increment reference number by location && prefixes code"
        Me.chkIncRefNoByLocation.UseVisualStyleBackColor = True
        '
        'chkAllowTransactionLinkToMultiLocation
        '
        Me.chkAllowTransactionLinkToMultiLocation.AutoSize = True
        Me.chkAllowTransactionLinkToMultiLocation.Location = New System.Drawing.Point(27, 208)
        Me.chkAllowTransactionLinkToMultiLocation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAllowTransactionLinkToMultiLocation.Name = "chkAllowTransactionLinkToMultiLocation"
        Me.chkAllowTransactionLinkToMultiLocation.Size = New System.Drawing.Size(297, 20)
        Me.chkAllowTransactionLinkToMultiLocation.TabIndex = 10
        Me.chkAllowTransactionLinkToMultiLocation.Text = "Allow Transaction-link from multiple table"
        Me.chkAllowTransactionLinkToMultiLocation.UseVisualStyleBackColor = True
        '
        'chkAllowListQuickAdd
        '
        Me.chkAllowListQuickAdd.AutoSize = True
        Me.chkAllowListQuickAdd.Location = New System.Drawing.Point(27, 180)
        Me.chkAllowListQuickAdd.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAllowListQuickAdd.Name = "chkAllowListQuickAdd"
        Me.chkAllowListQuickAdd.Size = New System.Drawing.Size(326, 20)
        Me.chkAllowListQuickAdd.TabIndex = 9
        Me.chkAllowListQuickAdd.Text = "Automactically  add new record in drop down"
        Me.chkAllowListQuickAdd.UseVisualStyleBackColor = True
        '
        'chkLockDefaultLocation
        '
        Me.chkLockDefaultLocation.AutoSize = True
        Me.chkLockDefaultLocation.Location = New System.Drawing.Point(27, 151)
        Me.chkLockDefaultLocation.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkLockDefaultLocation.Name = "chkLockDefaultLocation"
        Me.chkLockDefaultLocation.Size = New System.Drawing.Size(272, 20)
        Me.chkLockDefaultLocation.TabIndex = 8
        Me.chkLockDefaultLocation.Text = "Limit Transactions to default location"
        Me.chkLockDefaultLocation.UseVisualStyleBackColor = True
        '
        'cmbNewTransactionsDefaultDate
        '
        Me.cmbNewTransactionsDefaultDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNewTransactionsDefaultDate.FormattingEnabled = True
        Me.cmbNewTransactionsDefaultDate.Location = New System.Drawing.Point(245, 58)
        Me.cmbNewTransactionsDefaultDate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbNewTransactionsDefaultDate.Name = "cmbNewTransactionsDefaultDate"
        Me.cmbNewTransactionsDefaultDate.Size = New System.Drawing.Size(469, 24)
        Me.cmbNewTransactionsDefaultDate.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(23, 62)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 16)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = " Default Date"
        '
        'cmbDefaultLocationId
        '
        Me.cmbDefaultLocationId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultLocationId.FormattingEnabled = True
        Me.cmbDefaultLocationId.Location = New System.Drawing.Point(245, 25)
        Me.cmbDefaultLocationId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultLocationId.Name = "cmbDefaultLocationId"
        Me.cmbDefaultLocationId.Size = New System.Drawing.Size(469, 24)
        Me.cmbDefaultLocationId.TabIndex = 5
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 25)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 16)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Default Location"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.chkSkipJournalEntry)
        Me.TabPage3.Controls.Add(Me.numSmallestCurrencyValue)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage3.Size = New System.Drawing.Size(865, 409)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Accounting"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'chkSkipJournalEntry
        '
        Me.chkSkipJournalEntry.AutoSize = True
        Me.chkSkipJournalEntry.Location = New System.Drawing.Point(37, 309)
        Me.chkSkipJournalEntry.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkSkipJournalEntry.Name = "chkSkipJournalEntry"
        Me.chkSkipJournalEntry.Size = New System.Drawing.Size(144, 20)
        Me.chkSkipJournalEntry.TabIndex = 8
        Me.chkSkipJournalEntry.Text = "Skip Journal Entry"
        Me.chkSkipJournalEntry.UseVisualStyleBackColor = True
        '
        'numSmallestCurrencyValue
        '
        Me.numSmallestCurrencyValue.DecimalPlaces = 2
        Me.numSmallestCurrencyValue.Location = New System.Drawing.Point(229, 274)
        Me.numSmallestCurrencyValue.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numSmallestCurrencyValue.Name = "numSmallestCurrencyValue"
        Me.numSmallestCurrencyValue.Size = New System.Drawing.Size(93, 23)
        Me.numSmallestCurrencyValue.TabIndex = 7
        Me.numSmallestCurrencyValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(37, 277)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(148, 16)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Round amunt nearest"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkClosingDatePassword)
        Me.GroupBox2.Controls.Add(Me.dtpClosingDate)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Location = New System.Drawing.Point(29, 164)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(489, 91)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Closing Date"
        '
        'chkClosingDatePassword
        '
        Me.chkClosingDatePassword.AutoSize = True
        Me.chkClosingDatePassword.Location = New System.Drawing.Point(295, 41)
        Me.chkClosingDatePassword.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkClosingDatePassword.Name = "chkClosingDatePassword"
        Me.chkClosingDatePassword.Size = New System.Drawing.Size(149, 20)
        Me.chkClosingDatePassword.TabIndex = 2
        Me.chkClosingDatePassword.Text = "Password Required"
        Me.chkClosingDatePassword.UseVisualStyleBackColor = True
        '
        'dtpClosingDate
        '
        Me.dtpClosingDate.Checked = False
        Me.dtpClosingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpClosingDate.Location = New System.Drawing.Point(83, 41)
        Me.dtpClosingDate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpClosingDate.Name = "dtpClosingDate"
        Me.dtpClosingDate.ShowCheckBox = True
        Me.dtpClosingDate.Size = New System.Drawing.Size(199, 23)
        Me.dtpClosingDate.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 41)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 16)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Date"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.numDateWarningDaysFuture)
        Me.GroupBox1.Controls.Add(Me.numDateWarningDaysPast)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(29, 38)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(489, 116)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Date Warnings"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(291, 76)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(121, 16)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "day of the future"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(291, 38)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(115, 16)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "days in the past"
        '
        'numDateWarningDaysFuture
        '
        Me.numDateWarningDaysFuture.Location = New System.Drawing.Point(189, 74)
        Me.numDateWarningDaysFuture.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numDateWarningDaysFuture.Name = "numDateWarningDaysFuture"
        Me.numDateWarningDaysFuture.Size = New System.Drawing.Size(93, 23)
        Me.numDateWarningDaysFuture.TabIndex = 6
        Me.numDateWarningDaysFuture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDateWarningDaysPast
        '
        Me.numDateWarningDaysPast.Location = New System.Drawing.Point(189, 38)
        Me.numDateWarningDaysPast.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numDateWarningDaysPast.Name = "numDateWarningDaysPast"
        Me.numDateWarningDaysPast.Size = New System.Drawing.Size(93, 23)
        Me.numDateWarningDaysPast.TabIndex = 5
        Me.numDateWarningDaysPast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 74)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(159, 16)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Warning if Transaction "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 38)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(159, 16)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Warning if Transaction "
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.chkHideInactiveCustomer)
        Me.TabPage4.Controls.Add(Me.chkEnableBatchNumberInSalesOrder)
        Me.TabPage4.Controls.Add(Me.chkWarnWhenPriceBelowCost)
        Me.TabPage4.Controls.Add(Me.chkAllowPriceLevel)
        Me.TabPage4.Controls.Add(Me.chkAllowBlankInSellingPrice)
        Me.TabPage4.Controls.Add(Me.chkAllowPriceOverride)
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Controls.Add(Me.GroupBox4)
        Me.TabPage4.Controls.Add(Me.GroupBox3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage4.Size = New System.Drawing.Size(865, 409)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Sales & Customer"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'chkHideInactiveCustomer
        '
        Me.chkHideInactiveCustomer.AutoSize = True
        Me.chkHideInactiveCustomer.Location = New System.Drawing.Point(408, 273)
        Me.chkHideInactiveCustomer.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkHideInactiveCustomer.Name = "chkHideInactiveCustomer"
        Me.chkHideInactiveCustomer.Size = New System.Drawing.Size(191, 20)
        Me.chkHideInactiveCustomer.TabIndex = 8
        Me.chkHideInactiveCustomer.Text = "Hide in Active Customers"
        Me.chkHideInactiveCustomer.UseVisualStyleBackColor = True
        '
        'chkEnableBatchNumberInSalesOrder
        '
        Me.chkEnableBatchNumberInSalesOrder.AutoSize = True
        Me.chkEnableBatchNumberInSalesOrder.Location = New System.Drawing.Point(408, 251)
        Me.chkEnableBatchNumberInSalesOrder.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkEnableBatchNumberInSalesOrder.Name = "chkEnableBatchNumberInSalesOrder"
        Me.chkEnableBatchNumberInSalesOrder.Size = New System.Drawing.Size(258, 20)
        Me.chkEnableBatchNumberInSalesOrder.TabIndex = 7
        Me.chkEnableBatchNumberInSalesOrder.Text = "Enable batch number in sales order"
        Me.chkEnableBatchNumberInSalesOrder.UseVisualStyleBackColor = True
        '
        'chkWarnWhenPriceBelowCost
        '
        Me.chkWarnWhenPriceBelowCost.AutoSize = True
        Me.chkWarnWhenPriceBelowCost.Location = New System.Drawing.Point(408, 229)
        Me.chkWarnWhenPriceBelowCost.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkWarnWhenPriceBelowCost.Name = "chkWarnWhenPriceBelowCost"
        Me.chkWarnWhenPriceBelowCost.Size = New System.Drawing.Size(273, 20)
        Me.chkWarnWhenPriceBelowCost.TabIndex = 6
        Me.chkWarnWhenPriceBelowCost.Text = "Warn when selling price is below cost"
        Me.chkWarnWhenPriceBelowCost.UseVisualStyleBackColor = True
        '
        'chkAllowPriceLevel
        '
        Me.chkAllowPriceLevel.AutoSize = True
        Me.chkAllowPriceLevel.Location = New System.Drawing.Point(408, 206)
        Me.chkAllowPriceLevel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAllowPriceLevel.Name = "chkAllowPriceLevel"
        Me.chkAllowPriceLevel.Size = New System.Drawing.Size(229, 20)
        Me.chkAllowPriceLevel.TabIndex = 5
        Me.chkAllowPriceLevel.Text = "Allow user to select price level"
        Me.chkAllowPriceLevel.UseVisualStyleBackColor = True
        '
        'chkAllowBlankInSellingPrice
        '
        Me.chkAllowBlankInSellingPrice.AutoSize = True
        Me.chkAllowBlankInSellingPrice.Location = New System.Drawing.Point(408, 183)
        Me.chkAllowBlankInSellingPrice.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAllowBlankInSellingPrice.Name = "chkAllowBlankInSellingPrice"
        Me.chkAllowBlankInSellingPrice.Size = New System.Drawing.Size(197, 20)
        Me.chkAllowBlankInSellingPrice.TabIndex = 4
        Me.chkAllowBlankInSellingPrice.Text = "Allow blank in selling price"
        Me.chkAllowBlankInSellingPrice.UseVisualStyleBackColor = True
        '
        'chkAllowPriceOverride
        '
        Me.chkAllowPriceOverride.AutoSize = True
        Me.chkAllowPriceOverride.Location = New System.Drawing.Point(408, 160)
        Me.chkAllowPriceOverride.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAllowPriceOverride.Name = "chkAllowPriceOverride"
        Me.chkAllowPriceOverride.Size = New System.Drawing.Size(155, 20)
        Me.chkAllowPriceOverride.TabIndex = 3
        Me.chkAllowPriceOverride.Text = "Allow price override"
        Me.chkAllowPriceOverride.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkUseUndepositedFunds)
        Me.GroupBox5.Controls.Add(Me.chkAutoCalcPayments)
        Me.GroupBox5.Controls.Add(Me.chkAutoApplyPayments)
        Me.GroupBox5.Location = New System.Drawing.Point(21, 288)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox5.Size = New System.Drawing.Size(367, 108)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Receive Payments"
        '
        'chkUseUndepositedFunds
        '
        Me.chkUseUndepositedFunds.AutoSize = True
        Me.chkUseUndepositedFunds.Location = New System.Drawing.Point(16, 81)
        Me.chkUseUndepositedFunds.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkUseUndepositedFunds.Name = "chkUseUndepositedFunds"
        Me.chkUseUndepositedFunds.Size = New System.Drawing.Size(180, 20)
        Me.chkUseUndepositedFunds.TabIndex = 3
        Me.chkUseUndepositedFunds.Text = "Use Undeposited Funds"
        Me.chkUseUndepositedFunds.UseVisualStyleBackColor = True
        '
        'chkAutoCalcPayments
        '
        Me.chkAutoCalcPayments.AutoSize = True
        Me.chkAutoCalcPayments.Location = New System.Drawing.Point(16, 53)
        Me.chkAutoCalcPayments.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAutoCalcPayments.Name = "chkAutoCalcPayments"
        Me.chkAutoCalcPayments.Size = New System.Drawing.Size(191, 20)
        Me.chkAutoCalcPayments.TabIndex = 2
        Me.chkAutoCalcPayments.Text = "Auto calculate payments"
        Me.chkAutoCalcPayments.UseVisualStyleBackColor = True
        '
        'chkAutoApplyPayments
        '
        Me.chkAutoApplyPayments.AutoSize = True
        Me.chkAutoApplyPayments.Location = New System.Drawing.Point(16, 25)
        Me.chkAutoApplyPayments.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAutoApplyPayments.Name = "chkAutoApplyPayments"
        Me.chkAutoApplyPayments.Size = New System.Drawing.Size(166, 20)
        Me.chkAutoApplyPayments.TabIndex = 1
        Me.chkAutoApplyPayments.Text = "Auto apply payments"
        Me.chkAutoApplyPayments.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.chkShowPostdatedTransactions)
        Me.GroupBox4.Controls.Add(Me.chkPrintDueDateOnStatement)
        Me.GroupBox4.Controls.Add(Me.chkCreateStatementWithZeroBalance)
        Me.GroupBox4.Controls.Add(Me.chkShowInvoiceDetailsOnStatement)
        Me.GroupBox4.Location = New System.Drawing.Point(408, 16)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox4.Size = New System.Drawing.Size(351, 137)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Statement"
        '
        'chkShowPostdatedTransactions
        '
        Me.chkShowPostdatedTransactions.AutoSize = True
        Me.chkShowPostdatedTransactions.Location = New System.Drawing.Point(25, 97)
        Me.chkShowPostdatedTransactions.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowPostdatedTransactions.Name = "chkShowPostdatedTransactions"
        Me.chkShowPostdatedTransactions.Size = New System.Drawing.Size(221, 20)
        Me.chkShowPostdatedTransactions.TabIndex = 3
        Me.chkShowPostdatedTransactions.Text = "Show postdated transactions"
        Me.chkShowPostdatedTransactions.UseVisualStyleBackColor = True
        '
        'chkPrintDueDateOnStatement
        '
        Me.chkPrintDueDateOnStatement.AutoSize = True
        Me.chkPrintDueDateOnStatement.Location = New System.Drawing.Point(25, 75)
        Me.chkPrintDueDateOnStatement.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPrintDueDateOnStatement.Name = "chkPrintDueDateOnStatement"
        Me.chkPrintDueDateOnStatement.Size = New System.Drawing.Size(179, 20)
        Me.chkPrintDueDateOnStatement.TabIndex = 2
        Me.chkPrintDueDateOnStatement.Text = "Print due on statement"
        Me.chkPrintDueDateOnStatement.UseVisualStyleBackColor = True
        '
        'chkCreateStatementWithZeroBalance
        '
        Me.chkCreateStatementWithZeroBalance.AutoSize = True
        Me.chkCreateStatementWithZeroBalance.Location = New System.Drawing.Point(25, 54)
        Me.chkCreateStatementWithZeroBalance.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkCreateStatementWithZeroBalance.Name = "chkCreateStatementWithZeroBalance"
        Me.chkCreateStatementWithZeroBalance.Size = New System.Drawing.Size(265, 20)
        Me.chkCreateStatementWithZeroBalance.TabIndex = 1
        Me.chkCreateStatementWithZeroBalance.Text = "Create statement with zero balance"
        Me.chkCreateStatementWithZeroBalance.UseVisualStyleBackColor = True
        '
        'chkShowInvoiceDetailsOnStatement
        '
        Me.chkShowInvoiceDetailsOnStatement.AutoSize = True
        Me.chkShowInvoiceDetailsOnStatement.Location = New System.Drawing.Point(25, 32)
        Me.chkShowInvoiceDetailsOnStatement.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowInvoiceDetailsOnStatement.Name = "chkShowInvoiceDetailsOnStatement"
        Me.chkShowInvoiceDetailsOnStatement.Size = New System.Drawing.Size(255, 20)
        Me.chkShowInvoiceDetailsOnStatement.TabIndex = 0
        Me.chkShowInvoiceDetailsOnStatement.Text = "Show invoice details on statement"
        Me.chkShowInvoiceDetailsOnStatement.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbArAgingLimit)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.cmbCreditLimitPolicy)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.cmbDefaultPaymentMethodId)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.cmbDefaultPaymentTermsId)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Location = New System.Drawing.Point(21, 16)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox3.Size = New System.Drawing.Size(367, 265)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Sales"
        '
        'cmbArAgingLimit
        '
        Me.cmbArAgingLimit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArAgingLimit.FormattingEnabled = True
        Me.cmbArAgingLimit.Location = New System.Drawing.Point(17, 219)
        Me.cmbArAgingLimit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbArAgingLimit.Name = "cmbArAgingLimit"
        Me.cmbArAgingLimit.Size = New System.Drawing.Size(335, 24)
        Me.cmbArAgingLimit.TabIndex = 11
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 199)
        Me.Label20.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(106, 16)
        Me.Label20.TabIndex = 10
        Me.Label20.Text = "A/R Aging Limit"
        '
        'cmbCreditLimitPolicy
        '
        Me.cmbCreditLimitPolicy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCreditLimitPolicy.FormattingEnabled = True
        Me.cmbCreditLimitPolicy.Location = New System.Drawing.Point(17, 164)
        Me.cmbCreditLimitPolicy.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCreditLimitPolicy.Name = "cmbCreditLimitPolicy"
        Me.cmbCreditLimitPolicy.Size = New System.Drawing.Size(335, 24)
        Me.cmbCreditLimitPolicy.TabIndex = 9
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 144)
        Me.Label19.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(124, 16)
        Me.Label19.TabIndex = 8
        Me.Label19.Text = "Credit Limit Policy"
        '
        'cmbDefaultPaymentMethodId
        '
        Me.cmbDefaultPaymentMethodId.FormattingEnabled = True
        Me.cmbDefaultPaymentMethodId.Location = New System.Drawing.Point(17, 111)
        Me.cmbDefaultPaymentMethodId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultPaymentMethodId.Name = "cmbDefaultPaymentMethodId"
        Me.cmbDefaultPaymentMethodId.Size = New System.Drawing.Size(335, 24)
        Me.cmbDefaultPaymentMethodId.TabIndex = 7
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 91)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(118, 16)
        Me.Label18.TabIndex = 6
        Me.Label18.Text = "Payment Method"
        '
        'cmbDefaultPaymentTermsId
        '
        Me.cmbDefaultPaymentTermsId.FormattingEnabled = True
        Me.cmbDefaultPaymentTermsId.Location = New System.Drawing.Point(17, 57)
        Me.cmbDefaultPaymentTermsId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultPaymentTermsId.Name = "cmbDefaultPaymentTermsId"
        Me.cmbDefaultPaymentTermsId.Size = New System.Drawing.Size(335, 24)
        Me.cmbDefaultPaymentTermsId.TabIndex = 5
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 37)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(108, 16)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Payment Terms"
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.numRunningPenaltyRate)
        Me.TabPage5.Controls.Add(Me.Label39)
        Me.TabPage5.Controls.Add(Me.numFixedPenaltyRate)
        Me.TabPage5.Controls.Add(Me.Label38)
        Me.TabPage5.Controls.Add(Me.CheckBox20)
        Me.TabPage5.Controls.Add(Me.CheckBox19)
        Me.TabPage5.Controls.Add(Me.cmbFinanceChargeItemId)
        Me.TabPage5.Controls.Add(Me.Label25)
        Me.TabPage5.Controls.Add(Me.cmbFinanceChargeAccountId)
        Me.TabPage5.Controls.Add(Me.Label24)
        Me.TabPage5.Controls.Add(Me.NumericUpDown6)
        Me.TabPage5.Controls.Add(Me.Label23)
        Me.TabPage5.Controls.Add(Me.numFinanceChargeGracePeriod)
        Me.TabPage5.Controls.Add(Me.Label22)
        Me.TabPage5.Controls.Add(Me.numFinanceChargeAnnualInterestRate)
        Me.TabPage5.Controls.Add(Me.Label21)
        Me.TabPage5.Location = New System.Drawing.Point(4, 25)
        Me.TabPage5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage5.Size = New System.Drawing.Size(865, 409)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Finance Charge"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'numRunningPenaltyRate
        '
        Me.numRunningPenaltyRate.Location = New System.Drawing.Point(240, 229)
        Me.numRunningPenaltyRate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numRunningPenaltyRate.Name = "numRunningPenaltyRate"
        Me.numRunningPenaltyRate.Size = New System.Drawing.Size(93, 23)
        Me.numRunningPenaltyRate.TabIndex = 23
        Me.numRunningPenaltyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(17, 231)
        Me.Label39.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(174, 16)
        Me.Label39.TabIndex = 22
        Me.Label39.Text = "Running Penalty rate (%)"
        '
        'numFixedPenaltyRate
        '
        Me.numFixedPenaltyRate.Location = New System.Drawing.Point(240, 182)
        Me.numFixedPenaltyRate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numFixedPenaltyRate.Name = "numFixedPenaltyRate"
        Me.numFixedPenaltyRate.Size = New System.Drawing.Size(93, 23)
        Me.numFixedPenaltyRate.TabIndex = 21
        Me.numFixedPenaltyRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(17, 185)
        Me.Label38.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(157, 16)
        Me.Label38.TabIndex = 20
        Me.Label38.Text = "Fixed Penalty rate (%)"
        '
        'CheckBox20
        '
        Me.CheckBox20.AutoSize = True
        Me.CheckBox20.Location = New System.Drawing.Point(25, 338)
        Me.CheckBox20.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.CheckBox20.Name = "CheckBox20"
        Me.CheckBox20.Size = New System.Drawing.Size(293, 20)
        Me.CheckBox20.TabIndex = 19
        Me.CheckBox20.Text = "Create finance charge details on invoice"
        Me.CheckBox20.UseVisualStyleBackColor = True
        '
        'CheckBox19
        '
        Me.CheckBox19.AutoSize = True
        Me.CheckBox19.Location = New System.Drawing.Point(25, 295)
        Me.CheckBox19.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.CheckBox19.Name = "CheckBox19"
        Me.CheckBox19.Size = New System.Drawing.Size(363, 20)
        Me.CheckBox19.TabIndex = 18
        Me.CheckBox19.Text = "Assess finance charges on overdue finance charge"
        Me.CheckBox19.UseVisualStyleBackColor = True
        '
        'cmbFinanceChargeItemId
        '
        Me.cmbFinanceChargeItemId.FormattingEnabled = True
        Me.cmbFinanceChargeItemId.Location = New System.Drawing.Point(395, 85)
        Me.cmbFinanceChargeItemId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbFinanceChargeItemId.Name = "cmbFinanceChargeItemId"
        Me.cmbFinanceChargeItemId.Size = New System.Drawing.Size(371, 24)
        Me.cmbFinanceChargeItemId.TabIndex = 17
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(391, 65)
        Me.Label25.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(144, 16)
        Me.Label25.TabIndex = 16
        Me.Label25.Text = "Finance Charge Item"
        '
        'cmbFinanceChargeAccountId
        '
        Me.cmbFinanceChargeAccountId.FormattingEnabled = True
        Me.cmbFinanceChargeAccountId.Location = New System.Drawing.Point(395, 39)
        Me.cmbFinanceChargeAccountId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbFinanceChargeAccountId.Name = "cmbFinanceChargeAccountId"
        Me.cmbFinanceChargeAccountId.Size = New System.Drawing.Size(371, 24)
        Me.cmbFinanceChargeAccountId.TabIndex = 15
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(391, 20)
        Me.Label24.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 16)
        Me.Label24.TabIndex = 14
        Me.Label24.Text = "G/L Account"
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.Location = New System.Drawing.Point(240, 133)
        Me.NumericUpDown6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(93, 23)
        Me.NumericUpDown6.TabIndex = 13
        Me.NumericUpDown6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(17, 133)
        Me.Label23.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(169, 16)
        Me.Label23.TabIndex = 12
        Me.Label23.Text = "Minimum Finance Charge"
        '
        'numFinanceChargeGracePeriod
        '
        Me.numFinanceChargeGracePeriod.Location = New System.Drawing.Point(240, 86)
        Me.numFinanceChargeGracePeriod.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numFinanceChargeGracePeriod.Name = "numFinanceChargeGracePeriod"
        Me.numFinanceChargeGracePeriod.Size = New System.Drawing.Size(93, 23)
        Me.numFinanceChargeGracePeriod.TabIndex = 11
        Me.numFinanceChargeGracePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 86)
        Me.Label22.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(138, 16)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Grace Period (days)"
        '
        'numFinanceChargeAnnualInterestRate
        '
        Me.numFinanceChargeAnnualInterestRate.Location = New System.Drawing.Point(240, 41)
        Me.numFinanceChargeAnnualInterestRate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numFinanceChargeAnnualInterestRate.Name = "numFinanceChargeAnnualInterestRate"
        Me.numFinanceChargeAnnualInterestRate.Size = New System.Drawing.Size(93, 23)
        Me.numFinanceChargeAnnualInterestRate.TabIndex = 9
        Me.numFinanceChargeAnnualInterestRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 41)
        Me.Label21.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(189, 16)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Annual Intereset rate ( % )"
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.btnImageSetup)
        Me.TabPage6.Controls.Add(Me.chkSkipInventoryEntry)
        Me.TabPage6.Controls.Add(Me.chkLockQtyNeededInBuildAssembly)
        Me.TabPage6.Controls.Add(Me.chkAllowZeroOnHand)
        Me.TabPage6.Controls.Add(Me.GroupBox8)
        Me.TabPage6.Controls.Add(Me.GroupBox7)
        Me.TabPage6.Controls.Add(Me.GroupBox6)
        Me.TabPage6.Location = New System.Drawing.Point(4, 25)
        Me.TabPage6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage6.Size = New System.Drawing.Size(865, 409)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Inventory"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'btnImageSetup
        '
        Me.btnImageSetup.Location = New System.Drawing.Point(17, 422)
        Me.btnImageSetup.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnImageSetup.Name = "btnImageSetup"
        Me.btnImageSetup.Size = New System.Drawing.Size(195, 27)
        Me.btnImageSetup.TabIndex = 19
        Me.btnImageSetup.Text = "Item Image Setup"
        Me.btnImageSetup.UseVisualStyleBackColor = True
        '
        'chkSkipInventoryEntry
        '
        Me.chkSkipInventoryEntry.AutoSize = True
        Me.chkSkipInventoryEntry.Location = New System.Drawing.Point(17, 358)
        Me.chkSkipInventoryEntry.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkSkipInventoryEntry.Name = "chkSkipInventoryEntry"
        Me.chkSkipInventoryEntry.Size = New System.Drawing.Size(162, 20)
        Me.chkSkipInventoryEntry.TabIndex = 6
        Me.chkSkipInventoryEntry.Text = "Skip Inventory Entry"
        Me.chkSkipInventoryEntry.UseVisualStyleBackColor = True
        '
        'chkLockQtyNeededInBuildAssembly
        '
        Me.chkLockQtyNeededInBuildAssembly.AutoSize = True
        Me.chkLockQtyNeededInBuildAssembly.Location = New System.Drawing.Point(17, 330)
        Me.chkLockQtyNeededInBuildAssembly.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkLockQtyNeededInBuildAssembly.Name = "chkLockQtyNeededInBuildAssembly"
        Me.chkLockQtyNeededInBuildAssembly.Size = New System.Drawing.Size(285, 20)
        Me.chkLockQtyNeededInBuildAssembly.TabIndex = 5
        Me.chkLockQtyNeededInBuildAssembly.Text = "Look quantity needed in build assembly"
        Me.chkLockQtyNeededInBuildAssembly.UseVisualStyleBackColor = True
        '
        'chkAllowZeroOnHand
        '
        Me.chkAllowZeroOnHand.AutoSize = True
        Me.chkAllowZeroOnHand.Location = New System.Drawing.Point(17, 302)
        Me.chkAllowZeroOnHand.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAllowZeroOnHand.Name = "chkAllowZeroOnHand"
        Me.chkAllowZeroOnHand.Size = New System.Drawing.Size(194, 20)
        Me.chkAllowZeroOnHand.TabIndex = 4
        Me.chkAllowZeroOnHand.Text = "Allow negative  inventory"
        Me.chkAllowZeroOnHand.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.chkShowQtyOnSO)
        Me.GroupBox8.Controls.Add(Me.chkShowExpiryDate)
        Me.GroupBox8.Controls.Add(Me.chkShowBatchNo)
        Me.GroupBox8.Controls.Add(Me.chkShowLastPurchaseInfo)
        Me.GroupBox8.Controls.Add(Me.chkShowUnitCost)
        Me.GroupBox8.Controls.Add(Me.chkShowStockBin)
        Me.GroupBox8.Controls.Add(Me.chkShowItemFinderMaximized)
        Me.GroupBox8.Location = New System.Drawing.Point(320, 122)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox8.Size = New System.Drawing.Size(432, 159)
        Me.GroupBox8.TabIndex = 2
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Item Finder"
        '
        'chkShowQtyOnSO
        '
        Me.chkShowQtyOnSO.AutoSize = True
        Me.chkShowQtyOnSO.Location = New System.Drawing.Point(251, 92)
        Me.chkShowQtyOnSO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowQtyOnSO.Name = "chkShowQtyOnSO"
        Me.chkShowQtyOnSO.Size = New System.Drawing.Size(118, 20)
        Me.chkShowQtyOnSO.TabIndex = 6
        Me.chkShowQtyOnSO.Text = "Show S.O qty"
        Me.chkShowQtyOnSO.UseVisualStyleBackColor = True
        '
        'chkShowExpiryDate
        '
        Me.chkShowExpiryDate.AutoSize = True
        Me.chkShowExpiryDate.Location = New System.Drawing.Point(251, 64)
        Me.chkShowExpiryDate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowExpiryDate.Name = "chkShowExpiryDate"
        Me.chkShowExpiryDate.Size = New System.Drawing.Size(141, 20)
        Me.chkShowExpiryDate.TabIndex = 5
        Me.chkShowExpiryDate.Text = "Show expiry date"
        Me.chkShowExpiryDate.UseVisualStyleBackColor = True
        '
        'chkShowBatchNo
        '
        Me.chkShowBatchNo.AutoSize = True
        Me.chkShowBatchNo.Location = New System.Drawing.Point(251, 36)
        Me.chkShowBatchNo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowBatchNo.Name = "chkShowBatchNo"
        Me.chkShowBatchNo.Size = New System.Drawing.Size(158, 20)
        Me.chkShowBatchNo.TabIndex = 4
        Me.chkShowBatchNo.Text = "Show batch number"
        Me.chkShowBatchNo.UseVisualStyleBackColor = True
        '
        'chkShowLastPurchaseInfo
        '
        Me.chkShowLastPurchaseInfo.AutoSize = True
        Me.chkShowLastPurchaseInfo.Location = New System.Drawing.Point(19, 121)
        Me.chkShowLastPurchaseInfo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowLastPurchaseInfo.Name = "chkShowLastPurchaseInfo"
        Me.chkShowLastPurchaseInfo.Size = New System.Drawing.Size(185, 20)
        Me.chkShowLastPurchaseInfo.TabIndex = 3
        Me.chkShowLastPurchaseInfo.Text = "Show last purchase info"
        Me.chkShowLastPurchaseInfo.UseVisualStyleBackColor = True
        '
        'chkShowUnitCost
        '
        Me.chkShowUnitCost.AutoSize = True
        Me.chkShowUnitCost.Location = New System.Drawing.Point(19, 92)
        Me.chkShowUnitCost.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowUnitCost.Name = "chkShowUnitCost"
        Me.chkShowUnitCost.Size = New System.Drawing.Size(126, 20)
        Me.chkShowUnitCost.TabIndex = 2
        Me.chkShowUnitCost.Text = "Show unit cost"
        Me.chkShowUnitCost.UseVisualStyleBackColor = True
        '
        'chkShowStockBin
        '
        Me.chkShowStockBin.AutoSize = True
        Me.chkShowStockBin.Location = New System.Drawing.Point(19, 64)
        Me.chkShowStockBin.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowStockBin.Name = "chkShowStockBin"
        Me.chkShowStockBin.Size = New System.Drawing.Size(127, 20)
        Me.chkShowStockBin.TabIndex = 1
        Me.chkShowStockBin.Text = "Show stock bin"
        Me.chkShowStockBin.UseVisualStyleBackColor = True
        '
        'chkShowItemFinderMaximized
        '
        Me.chkShowItemFinderMaximized.AutoSize = True
        Me.chkShowItemFinderMaximized.Location = New System.Drawing.Point(19, 36)
        Me.chkShowItemFinderMaximized.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkShowItemFinderMaximized.Name = "chkShowItemFinderMaximized"
        Me.chkShowItemFinderMaximized.Size = New System.Drawing.Size(140, 20)
        Me.chkShowItemFinderMaximized.TabIndex = 0
        Me.chkShowItemFinderMaximized.Text = "Maximize Window"
        Me.chkShowItemFinderMaximized.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.numSafetyStockPctLevel)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Controls.Add(Me.cmbDefaultForecastingType)
        Me.GroupBox7.Controls.Add(Me.Label29)
        Me.GroupBox7.Location = New System.Drawing.Point(17, 122)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox7.Size = New System.Drawing.Size(295, 159)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Forcasting"
        '
        'numSafetyStockPctLevel
        '
        Me.numSafetyStockPctLevel.Location = New System.Drawing.Point(21, 114)
        Me.numSafetyStockPctLevel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numSafetyStockPctLevel.Name = "numSafetyStockPctLevel"
        Me.numSafetyStockPctLevel.Size = New System.Drawing.Size(141, 23)
        Me.numSafetyStockPctLevel.TabIndex = 11
        Me.numSafetyStockPctLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(16, 95)
        Me.Label30.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(165, 16)
        Me.Label30.TabIndex = 10
        Me.Label30.Text = "Safty Stock Level ( % )"
        '
        'cmbDefaultForecastingType
        '
        Me.cmbDefaultForecastingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultForecastingType.FormattingEnabled = True
        Me.cmbDefaultForecastingType.Location = New System.Drawing.Point(21, 59)
        Me.cmbDefaultForecastingType.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultForecastingType.Name = "cmbDefaultForecastingType"
        Me.cmbDefaultForecastingType.Size = New System.Drawing.Size(225, 24)
        Me.cmbDefaultForecastingType.TabIndex = 1
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(16, 39)
        Me.Label29.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(39, 16)
        Me.Label29.TabIndex = 0
        Me.Label29.Text = "Type"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.chkInvisibleGroup)
        Me.GroupBox6.Controls.Add(Me.chkExpiredReference)
        Me.GroupBox6.Controls.Add(Me.chkDefaultItemTaxable)
        Me.GroupBox6.Controls.Add(Me.cmbDefaultItemStockType)
        Me.GroupBox6.Controls.Add(Me.Label26)
        Me.GroupBox6.Location = New System.Drawing.Point(17, 27)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox6.Size = New System.Drawing.Size(735, 86)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Item default"
        '
        'chkInvisibleGroup
        '
        Me.chkInvisibleGroup.AutoSize = True
        Me.chkInvisibleGroup.Location = New System.Drawing.Point(490, 30)
        Me.chkInvisibleGroup.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkInvisibleGroup.Name = "chkInvisibleGroup"
        Me.chkInvisibleGroup.Size = New System.Drawing.Size(202, 20)
        Me.chkInvisibleGroup.TabIndex = 20
        Me.chkInvisibleGroup.Text = "Always Invisiable on Group"
        Me.chkInvisibleGroup.UseVisualStyleBackColor = True
        '
        'chkExpiredReference
        '
        Me.chkExpiredReference.AutoSize = True
        Me.chkExpiredReference.Location = New System.Drawing.Point(303, 52)
        Me.chkExpiredReference.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkExpiredReference.Name = "chkExpiredReference"
        Me.chkExpiredReference.Size = New System.Drawing.Size(171, 20)
        Me.chkExpiredReference.TabIndex = 19
        Me.chkExpiredReference.Text = "Expired Ref# on Seller"
        Me.chkExpiredReference.UseVisualStyleBackColor = True
        '
        'chkDefaultItemTaxable
        '
        Me.chkDefaultItemTaxable.AutoSize = True
        Me.chkDefaultItemTaxable.Location = New System.Drawing.Point(303, 25)
        Me.chkDefaultItemTaxable.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkDefaultItemTaxable.Name = "chkDefaultItemTaxable"
        Me.chkDefaultItemTaxable.Size = New System.Drawing.Size(110, 20)
        Me.chkDefaultItemTaxable.TabIndex = 18
        Me.chkDefaultItemTaxable.Text = "Item Taxable"
        Me.chkDefaultItemTaxable.UseVisualStyleBackColor = True
        '
        'cmbDefaultItemStockType
        '
        Me.cmbDefaultItemStockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultItemStockType.FormattingEnabled = True
        Me.cmbDefaultItemStockType.Location = New System.Drawing.Point(21, 49)
        Me.cmbDefaultItemStockType.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultItemStockType.Name = "cmbDefaultItemStockType"
        Me.cmbDefaultItemStockType.Size = New System.Drawing.Size(273, 24)
        Me.cmbDefaultItemStockType.TabIndex = 17
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(16, 30)
        Me.Label26.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(82, 16)
        Me.Label26.TabIndex = 16
        Me.Label26.Text = "Stock Type"
        '
        'TabPage7
        '
        Me.TabPage7.Controls.Add(Me.cmbTaxCreditAccountId)
        Me.TabPage7.Controls.Add(Me.Label56)
        Me.TabPage7.Controls.Add(Me.cmbTaxPayableAccountId)
        Me.TabPage7.Controls.Add(Me.Label55)
        Me.TabPage7.Controls.Add(Me.cmbInputTaxId)
        Me.TabPage7.Controls.Add(Me.Label52)
        Me.TabPage7.Controls.Add(Me.cmbExpandedWithholdingTaxId)
        Me.TabPage7.Controls.Add(Me.Label33)
        Me.TabPage7.Controls.Add(Me.cmbOutputTaxId)
        Me.TabPage7.Controls.Add(Me.Label32)
        Me.TabPage7.Controls.Add(Me.txtCompanyTin)
        Me.TabPage7.Controls.Add(Me.Label31)
        Me.TabPage7.Location = New System.Drawing.Point(4, 25)
        Me.TabPage7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage7.Name = "TabPage7"
        Me.TabPage7.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage7.Size = New System.Drawing.Size(865, 409)
        Me.TabPage7.TabIndex = 6
        Me.TabPage7.Text = "Tax"
        Me.TabPage7.UseVisualStyleBackColor = True
        '
        'cmbTaxCreditAccountId
        '
        Me.cmbTaxCreditAccountId.FormattingEnabled = True
        Me.cmbTaxCreditAccountId.Location = New System.Drawing.Point(21, 249)
        Me.cmbTaxCreditAccountId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTaxCreditAccountId.Name = "cmbTaxCreditAccountId"
        Me.cmbTaxCreditAccountId.Size = New System.Drawing.Size(731, 24)
        Me.cmbTaxCreditAccountId.TabIndex = 40
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(16, 229)
        Me.Label56.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(133, 16)
        Me.Label56.TabIndex = 39
        Me.Label56.Text = "Tax Credit Account"
        '
        'cmbTaxPayableAccountId
        '
        Me.cmbTaxPayableAccountId.FormattingEnabled = True
        Me.cmbTaxPayableAccountId.Location = New System.Drawing.Point(21, 187)
        Me.cmbTaxPayableAccountId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTaxPayableAccountId.Name = "cmbTaxPayableAccountId"
        Me.cmbTaxPayableAccountId.Size = New System.Drawing.Size(731, 24)
        Me.cmbTaxPayableAccountId.TabIndex = 38
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(16, 167)
        Me.Label55.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(145, 16)
        Me.Label55.TabIndex = 37
        Me.Label55.Text = "Tax Payable Account"
        '
        'cmbInputTaxId
        '
        Me.cmbInputTaxId.FormattingEnabled = True
        Me.cmbInputTaxId.Location = New System.Drawing.Point(399, 112)
        Me.cmbInputTaxId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbInputTaxId.Name = "cmbInputTaxId"
        Me.cmbInputTaxId.Size = New System.Drawing.Size(351, 24)
        Me.cmbInputTaxId.TabIndex = 21
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(395, 92)
        Me.Label52.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(69, 16)
        Me.Label52.TabIndex = 20
        Me.Label52.Text = "Input Tax"
        '
        'cmbExpandedWithholdingTaxId
        '
        Me.cmbExpandedWithholdingTaxId.FormattingEnabled = True
        Me.cmbExpandedWithholdingTaxId.Location = New System.Drawing.Point(21, 112)
        Me.cmbExpandedWithholdingTaxId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbExpandedWithholdingTaxId.Name = "cmbExpandedWithholdingTaxId"
        Me.cmbExpandedWithholdingTaxId.Size = New System.Drawing.Size(351, 24)
        Me.cmbExpandedWithholdingTaxId.TabIndex = 19
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(16, 92)
        Me.Label33.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(200, 16)
        Me.Label33.TabIndex = 18
        Me.Label33.Text = "Expanded Withoutholding Tax"
        '
        'cmbOutputTaxId
        '
        Me.cmbOutputTaxId.FormattingEnabled = True
        Me.cmbOutputTaxId.Location = New System.Drawing.Point(399, 48)
        Me.cmbOutputTaxId.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbOutputTaxId.Name = "cmbOutputTaxId"
        Me.cmbOutputTaxId.Size = New System.Drawing.Size(351, 24)
        Me.cmbOutputTaxId.TabIndex = 17
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(395, 28)
        Me.Label32.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 16)
        Me.Label32.TabIndex = 16
        Me.Label32.Text = "Output Tax"
        '
        'txtCompanyTin
        '
        Me.txtCompanyTin.Location = New System.Drawing.Point(21, 48)
        Me.txtCompanyTin.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCompanyTin.Name = "txtCompanyTin"
        Me.txtCompanyTin.Size = New System.Drawing.Size(351, 23)
        Me.txtCompanyTin.TabIndex = 3
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(16, 28)
        Me.Label31.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(112, 16)
        Me.Label31.TabIndex = 2
        Me.Label31.Text = "Taxpayer ID No."
        '
        'TabPage8
        '
        Me.TabPage8.Controls.Add(Me.cmbDefaultVendorID)
        Me.TabPage8.Controls.Add(Me.Label64)
        Me.TabPage8.Controls.Add(Me.Label43)
        Me.TabPage8.Controls.Add(Me.cmbTargetPenaltyDiscount)
        Me.TabPage8.Controls.Add(Me.Label42)
        Me.TabPage8.Controls.Add(Me.cmbDefaultPenaltyType)
        Me.TabPage8.Controls.Add(Me.Label37)
        Me.TabPage8.Controls.Add(Me.numServiceFee)
        Me.TabPage8.Controls.Add(Me.Label36)
        Me.TabPage8.Controls.Add(Me.numManagerGetDealerSalesTarget)
        Me.TabPage8.Controls.Add(Me.Label35)
        Me.TabPage8.Controls.Add(Me.Label34)
        Me.TabPage8.Controls.Add(Me.numManagerRebites)
        Me.TabPage8.Controls.Add(Me.Label28)
        Me.TabPage8.Controls.Add(Me.Label27)
        Me.TabPage8.Location = New System.Drawing.Point(4, 25)
        Me.TabPage8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage8.Name = "TabPage8"
        Me.TabPage8.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabPage8.Size = New System.Drawing.Size(865, 409)
        Me.TabPage8.TabIndex = 7
        Me.TabPage8.Text = "Others"
        Me.TabPage8.UseVisualStyleBackColor = True
        '
        'cmbDefaultVendorID
        '
        Me.cmbDefaultVendorID.FormattingEnabled = True
        Me.cmbDefaultVendorID.Location = New System.Drawing.Point(205, 193)
        Me.cmbDefaultVendorID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultVendorID.Name = "cmbDefaultVendorID"
        Me.cmbDefaultVendorID.Size = New System.Drawing.Size(331, 24)
        Me.cmbDefaultVendorID.TabIndex = 34
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(24, 197)
        Me.Label64.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(104, 16)
        Me.Label64.TabIndex = 33
        Me.Label64.Text = "Default Vendor"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(24, 164)
        Me.Label43.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(165, 16)
        Me.Label43.TabIndex = 31
        Me.Label43.Text = "Target Penalty Discount"
        '
        'cmbTargetPenaltyDiscount
        '
        Me.cmbTargetPenaltyDiscount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTargetPenaltyDiscount.FormattingEnabled = True
        Me.cmbTargetPenaltyDiscount.Location = New System.Drawing.Point(205, 160)
        Me.cmbTargetPenaltyDiscount.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTargetPenaltyDiscount.Name = "cmbTargetPenaltyDiscount"
        Me.cmbTargetPenaltyDiscount.Size = New System.Drawing.Size(331, 24)
        Me.cmbTargetPenaltyDiscount.TabIndex = 30
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(24, 130)
        Me.Label42.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(145, 16)
        Me.Label42.TabIndex = 29
        Me.Label42.Text = "Default Penalty Type"
        '
        'cmbDefaultPenaltyType
        '
        Me.cmbDefaultPenaltyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDefaultPenaltyType.FormattingEnabled = True
        Me.cmbDefaultPenaltyType.Location = New System.Drawing.Point(203, 127)
        Me.cmbDefaultPenaltyType.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDefaultPenaltyType.Name = "cmbDefaultPenaltyType"
        Me.cmbDefaultPenaltyType.Size = New System.Drawing.Size(331, 24)
        Me.cmbDefaultPenaltyType.TabIndex = 28
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(264, 28)
        Me.Label37.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(20, 16)
        Me.Label37.TabIndex = 27
        Me.Label37.Text = "%"
        '
        'numServiceFee
        '
        Me.numServiceFee.Location = New System.Drawing.Point(203, 26)
        Me.numServiceFee.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numServiceFee.Name = "numServiceFee"
        Me.numServiceFee.Size = New System.Drawing.Size(55, 23)
        Me.numServiceFee.TabIndex = 26
        Me.numServiceFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(267, 95)
        Me.Label36.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(135, 16)
        Me.Label36.TabIndex = 25
        Me.Label36.Text = "Dealer Sales Target"
        '
        'numManagerGetDealerSalesTarget
        '
        Me.numManagerGetDealerSalesTarget.Location = New System.Drawing.Point(203, 92)
        Me.numManagerGetDealerSalesTarget.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numManagerGetDealerSalesTarget.Name = "numManagerGetDealerSalesTarget"
        Me.numManagerGetDealerSalesTarget.Size = New System.Drawing.Size(55, 23)
        Me.numManagerGetDealerSalesTarget.TabIndex = 24
        Me.numManagerGetDealerSalesTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(24, 95)
        Me.Label35.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(165, 16)
        Me.Label35.TabIndex = 23
        Me.Label35.Text = "If Manager Rebites gets"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(264, 63)
        Me.Label34.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(20, 16)
        Me.Label34.TabIndex = 22
        Me.Label34.Text = "%"
        '
        'numManagerRebites
        '
        Me.numManagerRebites.Location = New System.Drawing.Point(203, 60)
        Me.numManagerRebites.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numManagerRebites.Name = "numManagerRebites"
        Me.numManagerRebites.Size = New System.Drawing.Size(55, 23)
        Me.numManagerRebites.TabIndex = 21
        Me.numManagerRebites.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(24, 63)
        Me.Label28.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(116, 16)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "Manager Rebites"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(24, 28)
        Me.Label27.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(124, 16)
        Me.Label27.TabIndex = 19
        Me.Label27.Text = "Fixed Service Fee"
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSave.Location = New System.Drawing.Point(644, 474)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 28)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnCancel.Location = New System.Drawing.Point(770, 474)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(120, 28)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSystemDefault
        '
        Me.btnSystemDefault.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSystemDefault.Location = New System.Drawing.Point(17, 474)
        Me.btnSystemDefault.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSystemDefault.Name = "btnSystemDefault"
        Me.btnSystemDefault.Size = New System.Drawing.Size(104, 28)
        Me.btnSystemDefault.TabIndex = 5
        Me.btnSystemDefault.Text = "PC &Default"
        Me.btnSystemDefault.UseVisualStyleBackColor = True
        '
        'btnDefaultValue
        '
        Me.btnDefaultValue.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnDefaultValue.Location = New System.Drawing.Point(128, 474)
        Me.btnDefaultValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnDefaultValue.Name = "btnDefaultValue"
        Me.btnDefaultValue.Size = New System.Drawing.Size(122, 28)
        Me.btnDefaultValue.TabIndex = 51
        Me.btnDefaultValue.Text = "Default &Value"
        Me.btnDefaultValue.UseVisualStyleBackColor = True
        '
        'frmSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(902, 524)
        Me.Controls.Add(Me.btnDefaultValue)
        Me.Controls.Add(Me.btnSystemDefault)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.tabMenu)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Settings"
        Me.tabMenu.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.numSmallestCurrencyValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numDateWarningDaysFuture, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDateWarningDaysPast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        CType(Me.numRunningPenaltyRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFixedPenaltyRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFinanceChargeGracePeriod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFinanceChargeAnnualInterestRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.numSafetyStockPctLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage7.ResumeLayout(False)
        Me.TabPage7.PerformLayout()
        Me.TabPage8.ResumeLayout(False)
        Me.TabPage8.PerformLayout()
        CType(Me.numServiceFee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numManagerGetDealerSalesTarget, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numManagerRebites, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tabMenu As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents TabPage7 As TabPage
    Friend WithEvents Label8 As Label
    Friend WithEvents txtCompanyMobileNo As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCompanyFaxNo As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtCompanyPhoneNo As TextBox
    Friend WithEvents txtCompanyEmailAddress As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLegalName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbBusinessType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCompanyName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkIncRefNoByLocation As CheckBox
    Friend WithEvents chkAllowTransactionLinkToMultiLocation As CheckBox
    Friend WithEvents chkAllowListQuickAdd As CheckBox
    Friend WithEvents chkLockDefaultLocation As CheckBox
    Friend WithEvents cmbNewTransactionsDefaultDate As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbDefaultLocationId As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents chkSkipJournalEntry As CheckBox
    Friend WithEvents numSmallestCurrencyValue As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents dtpClosingDate As DateTimePicker
    Friend WithEvents Label11 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents numDateWarningDaysFuture As NumericUpDown
    Friend WithEvents numDateWarningDaysPast As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents cmbCreditLimitPolicy As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents cmbDefaultPaymentMethodId As ComboBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbDefaultPaymentTermsId As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents chkHideInactiveCustomer As CheckBox
    Friend WithEvents chkEnableBatchNumberInSalesOrder As CheckBox
    Friend WithEvents chkWarnWhenPriceBelowCost As CheckBox
    Friend WithEvents chkAllowPriceLevel As CheckBox
    Friend WithEvents chkAllowBlankInSellingPrice As CheckBox
    Friend WithEvents chkAllowPriceOverride As CheckBox
    Friend WithEvents chkUseUndepositedFunds As CheckBox
    Friend WithEvents chkAutoCalcPayments As CheckBox
    Friend WithEvents chkAutoApplyPayments As CheckBox
    Friend WithEvents chkShowPostdatedTransactions As CheckBox
    Friend WithEvents chkPrintDueDateOnStatement As CheckBox
    Friend WithEvents chkCreateStatementWithZeroBalance As CheckBox
    Friend WithEvents chkShowInvoiceDetailsOnStatement As CheckBox
    Friend WithEvents cmbArAgingLimit As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents CheckBox20 As CheckBox
    Friend WithEvents CheckBox19 As CheckBox
    Friend WithEvents cmbFinanceChargeItemId As ComboBox
    Friend WithEvents Label25 As Label
    Friend WithEvents cmbFinanceChargeAccountId As ComboBox
    Friend WithEvents Label24 As Label
    Friend WithEvents NumericUpDown6 As NumericUpDown
    Friend WithEvents Label23 As Label
    Friend WithEvents numFinanceChargeGracePeriod As NumericUpDown
    Friend WithEvents Label22 As Label
    Friend WithEvents numFinanceChargeAnnualInterestRate As NumericUpDown
    Friend WithEvents Label21 As Label
    Friend WithEvents chkSkipInventoryEntry As CheckBox
    Friend WithEvents chkLockQtyNeededInBuildAssembly As CheckBox
    Friend WithEvents chkAllowZeroOnHand As CheckBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents chkShowQtyOnSO As CheckBox
    Friend WithEvents chkShowExpiryDate As CheckBox
    Friend WithEvents chkShowBatchNo As CheckBox
    Friend WithEvents chkShowLastPurchaseInfo As CheckBox
    Friend WithEvents chkShowUnitCost As CheckBox
    Friend WithEvents chkShowStockBin As CheckBox
    Friend WithEvents chkShowItemFinderMaximized As CheckBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents numSafetyStockPctLevel As NumericUpDown
    Friend WithEvents Label30 As Label
    Friend WithEvents cmbDefaultForecastingType As ComboBox
    Friend WithEvents Label29 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents cmbDefaultItemStockType As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents cmbExpandedWithholdingTaxId As ComboBox
    Friend WithEvents Label33 As Label
    Friend WithEvents cmbOutputTaxId As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents txtCompanyTin As TextBox
    Friend WithEvents Label31 As Label
    Friend WithEvents rtbCompanyAddress As RichTextBox
    Friend WithEvents chkDefaultItemTaxable As CheckBox
    Friend WithEvents TabPage8 As TabPage
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents numManagerGetDealerSalesTarget As NumericUpDown
    Friend WithEvents Label35 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents numManagerRebites As NumericUpDown
    Friend WithEvents numServiceFee As NumericUpDown
    Friend WithEvents Label37 As Label
    Friend WithEvents numFixedPenaltyRate As NumericUpDown
    Friend WithEvents Label38 As Label
    Friend WithEvents numRunningPenaltyRate As NumericUpDown
    Friend WithEvents Label39 As Label
    Friend WithEvents txtReportDisplay As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents txtReportDisplay2 As TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents cmbDefaultPenaltyType As ComboBox
    Friend WithEvents Label43 As Label
    Friend WithEvents cmbTargetPenaltyDiscount As ComboBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents cmbInputTaxId As ComboBox
    Friend WithEvents Label52 As Label
    Friend WithEvents cmbTaxPayableAccountId As ComboBox
    Friend WithEvents Label55 As Label
    Friend WithEvents cmbTaxCreditAccountId As ComboBox
    Friend WithEvents Label56 As Label
    Friend WithEvents chkLockLocation As CheckBox
    Friend WithEvents chkClosingDatePassword As CheckBox
    Friend WithEvents Label59 As Label
    Friend WithEvents dtpBusinessStart As DateTimePicker
    Friend WithEvents cmbStorageLocationId As ComboBox
    Friend WithEvents Label62 As Label
    Friend WithEvents chkNotUseStorageLocation As CheckBox
    Friend WithEvents btnEmailSetup As Button
    Friend WithEvents Label63 As Label
    Friend WithEvents btnImageSetup As Button
    Friend WithEvents cmbDefaultVendorID As ComboBox
    Friend WithEvents Label64 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSystemDefault As Button
    Friend WithEvents btnDefaultValue As Button
    Friend WithEvents chkExpiredReference As CheckBox
    Friend WithEvents chkInvisibleGroup As CheckBox
End Class
