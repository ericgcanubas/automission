<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemDetails
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.chkNON_DISCOUNTED_ITEM = New System.Windows.Forms.CheckBox()
        Me.chkBUNDLE_SET = New System.Windows.Forms.CheckBox()
        Me.chkNON_PORFOLIO_COMPUTATION = New System.Windows.Forms.CheckBox()
        Me.cmbMANUFACTURER_ID = New System.Windows.Forms.ComboBox()
        Me.xlblManufacture = New System.Windows.Forms.Label()
        Me.cmbGL_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.xlblINCOME_ACCOUNT = New System.Windows.Forms.Label()
        Me.cmbPREFERRED_VENDOR_ID = New System.Windows.Forms.ComboBox()
        Me.xlblPreferered = New System.Windows.Forms.Label()
        Me.chkTAXABLE = New System.Windows.Forms.CheckBox()
        Me.cmbCOGS_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.xlblCOGS_ACCOUNT = New System.Windows.Forms.Label()
        Me.xlblRate = New System.Windows.Forms.Label()
        Me.numRATE = New System.Windows.Forms.NumericUpDown()
        Me.xlblCOST = New System.Windows.Forms.Label()
        Me.numCOST = New System.Windows.Forms.NumericUpDown()
        Me.xlblDescription = New System.Windows.Forms.Label()
        Me.xlblPurchase_Description = New System.Windows.Forms.Label()
        Me.rtbDESCRIPTION = New System.Windows.Forms.RichTextBox()
        Me.rtbPURCHASE_DESCRIPTION = New System.Windows.Forms.RichTextBox()
        Me.dgvComponents = New System.Windows.Forms.DataGridView()
        Me.cmbRATE_TYPE = New System.Windows.Forms.ComboBox()
        Me.chkPRINT_INDIVIDUAL_ITEMS = New System.Windows.Forms.CheckBox()
        Me.dgvOrder_Preference = New System.Windows.Forms.DataGridView()
        Me.xlblASSET_ACCOUNT = New System.Windows.Forms.Label()
        Me.cmbASSET_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.xlblStock_TYPE = New System.Windows.Forms.Label()
        Me.cmbSTOCK_TYPE = New System.Windows.Forms.ComboBox()
        Me.cmbBASE_UNIT_ID = New System.Windows.Forms.ComboBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.tpOtherSize = New System.Windows.Forms.TabPage()
        Me.dgvReleted_Units = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsAdd1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEdit1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete1 = New System.Windows.Forms.ToolStripButton()
        Me.tpSizeRateLevel = New System.Windows.Forms.TabPage()
        Me.dgvUM_Price_level = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAdd2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEdit2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete2 = New System.Windows.Forms.ToolStripButton()
        Me.tpDefaultArea = New System.Windows.Forms.TabPage()
        Me.dgvLocation_Default = New System.Windows.Forms.DataGridView()
        Me.tsDefaultBranchClick = New System.Windows.Forms.ToolStrip()
        Me.tsDefaultBranch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvPriceLevel = New System.Windows.Forms.DataGridView()
        Me.xlblSUB_Class = New System.Windows.Forms.Label()
        Me.xlblGROUP = New System.Windows.Forms.Label()
        Me.xlblCLASS = New System.Windows.Forms.Label()
        Me.cmbSUB_CLASS_ID = New System.Windows.Forms.ComboBox()
        Me.cmbGROUP_ID = New System.Windows.Forms.ComboBox()
        Me.cmbCLASS_ID = New System.Windows.Forms.ComboBox()
        Me.rtbNOTES = New System.Windows.Forms.RichTextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lblPIC_FILENAME = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ThisImageLabel = New System.Windows.Forms.Label()
        Me.cmbPURCHASES_UNIT_ID = New System.Windows.Forms.ComboBox()
        Me.cmbSALES_UNIT_ID = New System.Windows.Forms.ComboBox()
        Me.cmbSHIPPING_UNIT_ID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tpInfo = New System.Windows.Forms.TabPage()
        Me.chkIS_EXPIRED = New System.Windows.Forms.CheckBox()
        Me.tpComponents = New System.Windows.Forms.TabPage()
        Me.TSPayment = New System.Windows.Forms.ToolStrip()
        Me.AddTrans = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.EditTrans = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.DeleteTrans = New System.Windows.Forms.ToolStripButton()
        Me.tpInventory = New System.Windows.Forms.TabPage()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.tsInventoryClick = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpUnits = New System.Windows.Forms.TabPage()
        Me.tpPriceLevel = New System.Windows.Forms.TabPage()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.tsRateLevelsClick = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tpOther = New System.Windows.Forms.TabPage()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.picItem = New System.Windows.Forms.PictureBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCOST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvComponents, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOrder_Preference, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl2.SuspendLayout()
        Me.tpOtherSize.SuspendLayout()
        CType(Me.dgvReleted_Units, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.tpSizeRateLevel.SuspendLayout()
        CType(Me.dgvUM_Price_level, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.tpDefaultArea.SuspendLayout()
        CType(Me.dgvLocation_Default, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsDefaultBranchClick.SuspendLayout()
        CType(Me.dgvPriceLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.tpInfo.SuspendLayout()
        Me.tpComponents.SuspendLayout()
        Me.TSPayment.SuspendLayout()
        Me.tpInventory.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.tpUnits.SuspendLayout()
        Me.tpPriceLevel.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.tpOther.SuspendLayout()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(95, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Type"
        '
        'cmbTYPE
        '
        Me.cmbTYPE.AccessibleDescription = "0"
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(137, 15)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(207, 24)
        Me.cmbTYPE.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(72, 47)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 16)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Barcode"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(137, 44)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(207, 23)
        Me.txtCODE.TabIndex = 11
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.Location = New System.Drawing.Point(362, 16)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(80, 20)
        Me.chkINACTIVE.TabIndex = 12
        Me.chkINACTIVE.Text = "Disabled"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'chkNON_DISCOUNTED_ITEM
        '
        Me.chkNON_DISCOUNTED_ITEM.AutoSize = True
        Me.chkNON_DISCOUNTED_ITEM.Location = New System.Drawing.Point(479, 17)
        Me.chkNON_DISCOUNTED_ITEM.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkNON_DISCOUNTED_ITEM.Name = "chkNON_DISCOUNTED_ITEM"
        Me.chkNON_DISCOUNTED_ITEM.Size = New System.Drawing.Size(169, 20)
        Me.chkNON_DISCOUNTED_ITEM.TabIndex = 21
        Me.chkNON_DISCOUNTED_ITEM.Text = "Non Discounted. Item"
        Me.chkNON_DISCOUNTED_ITEM.UseVisualStyleBackColor = True
        '
        'chkBUNDLE_SET
        '
        Me.chkBUNDLE_SET.AutoSize = True
        Me.chkBUNDLE_SET.Location = New System.Drawing.Point(362, 48)
        Me.chkBUNDLE_SET.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkBUNDLE_SET.Name = "chkBUNDLE_SET"
        Me.chkBUNDLE_SET.Size = New System.Drawing.Size(97, 20)
        Me.chkBUNDLE_SET.TabIndex = 20
        Me.chkBUNDLE_SET.Text = "Bundle Set"
        Me.chkBUNDLE_SET.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkBUNDLE_SET.UseVisualStyleBackColor = True
        '
        'chkNON_PORFOLIO_COMPUTATION
        '
        Me.chkNON_PORFOLIO_COMPUTATION.AutoSize = True
        Me.chkNON_PORFOLIO_COMPUTATION.Location = New System.Drawing.Point(479, 48)
        Me.chkNON_PORFOLIO_COMPUTATION.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkNON_PORFOLIO_COMPUTATION.Name = "chkNON_PORFOLIO_COMPUTATION"
        Me.chkNON_PORFOLIO_COMPUTATION.Size = New System.Drawing.Size(141, 20)
        Me.chkNON_PORFOLIO_COMPUTATION.TabIndex = 19
        Me.chkNON_PORFOLIO_COMPUTATION.Text = "Non-Computation"
        Me.chkNON_PORFOLIO_COMPUTATION.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkNON_PORFOLIO_COMPUTATION.UseVisualStyleBackColor = True
        '
        'cmbMANUFACTURER_ID
        '
        Me.cmbMANUFACTURER_ID.FormattingEnabled = True
        Me.cmbMANUFACTURER_ID.Location = New System.Drawing.Point(119, 171)
        Me.cmbMANUFACTURER_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbMANUFACTURER_ID.Name = "cmbMANUFACTURER_ID"
        Me.cmbMANUFACTURER_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbMANUFACTURER_ID.TabIndex = 18
        '
        'xlblManufacture
        '
        Me.xlblManufacture.AutoSize = True
        Me.xlblManufacture.Location = New System.Drawing.Point(23, 176)
        Me.xlblManufacture.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblManufacture.Name = "xlblManufacture"
        Me.xlblManufacture.Size = New System.Drawing.Size(95, 16)
        Me.xlblManufacture.TabIndex = 17
        Me.xlblManufacture.Text = "Manufacturer"
        '
        'cmbGL_ACCOUNT_ID
        '
        Me.cmbGL_ACCOUNT_ID.AccessibleDescription = "null"
        Me.cmbGL_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbGL_ACCOUNT_ID.Location = New System.Drawing.Point(448, 209)
        Me.cmbGL_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbGL_ACCOUNT_ID.Name = "cmbGL_ACCOUNT_ID"
        Me.cmbGL_ACCOUNT_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbGL_ACCOUNT_ID.TabIndex = 16
        '
        'xlblINCOME_ACCOUNT
        '
        Me.xlblINCOME_ACCOUNT.AutoSize = True
        Me.xlblINCOME_ACCOUNT.Location = New System.Drawing.Point(333, 213)
        Me.xlblINCOME_ACCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblINCOME_ACCOUNT.Name = "xlblINCOME_ACCOUNT"
        Me.xlblINCOME_ACCOUNT.Size = New System.Drawing.Size(115, 16)
        Me.xlblINCOME_ACCOUNT.TabIndex = 15
        Me.xlblINCOME_ACCOUNT.Text = "Income Account"
        '
        'cmbPREFERRED_VENDOR_ID
        '
        Me.cmbPREFERRED_VENDOR_ID.FormattingEnabled = True
        Me.cmbPREFERRED_VENDOR_ID.Location = New System.Drawing.Point(119, 143)
        Me.cmbPREFERRED_VENDOR_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPREFERRED_VENDOR_ID.Name = "cmbPREFERRED_VENDOR_ID"
        Me.cmbPREFERRED_VENDOR_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbPREFERRED_VENDOR_ID.TabIndex = 14
        '
        'xlblPreferered
        '
        Me.xlblPreferered.AutoSize = True
        Me.xlblPreferered.Location = New System.Drawing.Point(5, 146)
        Me.xlblPreferered.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblPreferered.Name = "xlblPreferered"
        Me.xlblPreferered.Size = New System.Drawing.Size(108, 16)
        Me.xlblPreferered.TabIndex = 13
        Me.xlblPreferered.Text = "Preferred Seller"
        '
        'chkTAXABLE
        '
        Me.chkTAXABLE.Location = New System.Drawing.Point(119, 48)
        Me.chkTAXABLE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkTAXABLE.Name = "chkTAXABLE"
        Me.chkTAXABLE.Size = New System.Drawing.Size(86, 26)
        Me.chkTAXABLE.TabIndex = 12
        Me.chkTAXABLE.Text = "Taxable"
        Me.chkTAXABLE.UseVisualStyleBackColor = True
        '
        'cmbCOGS_ACCOUNT_ID
        '
        Me.cmbCOGS_ACCOUNT_ID.AccessibleDescription = "null"
        Me.cmbCOGS_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbCOGS_ACCOUNT_ID.Location = New System.Drawing.Point(119, 209)
        Me.cmbCOGS_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCOGS_ACCOUNT_ID.Name = "cmbCOGS_ACCOUNT_ID"
        Me.cmbCOGS_ACCOUNT_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbCOGS_ACCOUNT_ID.TabIndex = 11
        '
        'xlblCOGS_ACCOUNT
        '
        Me.xlblCOGS_ACCOUNT.AutoSize = True
        Me.xlblCOGS_ACCOUNT.Location = New System.Drawing.Point(13, 213)
        Me.xlblCOGS_ACCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblCOGS_ACCOUNT.Name = "xlblCOGS_ACCOUNT"
        Me.xlblCOGS_ACCOUNT.Size = New System.Drawing.Size(104, 16)
        Me.xlblCOGS_ACCOUNT.TabIndex = 10
        Me.xlblCOGS_ACCOUNT.Text = "COGS Account"
        '
        'xlblRate
        '
        Me.xlblRate.AutoSize = True
        Me.xlblRate.Location = New System.Drawing.Point(395, 20)
        Me.xlblRate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblRate.Name = "xlblRate"
        Me.xlblRate.Size = New System.Drawing.Size(37, 16)
        Me.xlblRate.TabIndex = 9
        Me.xlblRate.Text = "Rate"
        '
        'numRATE
        '
        Me.numRATE.DecimalPlaces = 2
        Me.numRATE.Location = New System.Drawing.Point(447, 16)
        Me.numRATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numRATE.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numRATE.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.numRATE.Name = "numRATE"
        Me.numRATE.Size = New System.Drawing.Size(114, 23)
        Me.numRATE.TabIndex = 8
        Me.numRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numRATE.ThousandsSeparator = True
        '
        'xlblCOST
        '
        Me.xlblCOST.AutoSize = True
        Me.xlblCOST.Location = New System.Drawing.Point(77, 20)
        Me.xlblCOST.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblCOST.Name = "xlblCOST"
        Me.xlblCOST.Size = New System.Drawing.Size(37, 16)
        Me.xlblCOST.TabIndex = 7
        Me.xlblCOST.Text = "Cost"
        '
        'numCOST
        '
        Me.numCOST.DecimalPlaces = 2
        Me.numCOST.Location = New System.Drawing.Point(119, 17)
        Me.numCOST.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCOST.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numCOST.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.numCOST.Name = "numCOST"
        Me.numCOST.Size = New System.Drawing.Size(125, 23)
        Me.numCOST.TabIndex = 6
        Me.numCOST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCOST.ThousandsSeparator = True
        '
        'xlblDescription
        '
        Me.xlblDescription.AutoSize = True
        Me.xlblDescription.Location = New System.Drawing.Point(351, 79)
        Me.xlblDescription.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblDescription.Name = "xlblDescription"
        Me.xlblDescription.Size = New System.Drawing.Size(120, 16)
        Me.xlblDescription.TabIndex = 3
        Me.xlblDescription.Text = "Sales Description"
        '
        'xlblPurchase_Description
        '
        Me.xlblPurchase_Description.AutoSize = True
        Me.xlblPurchase_Description.Location = New System.Drawing.Point(10, 79)
        Me.xlblPurchase_Description.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblPurchase_Description.Name = "xlblPurchase_Description"
        Me.xlblPurchase_Description.Size = New System.Drawing.Size(106, 16)
        Me.xlblPurchase_Description.TabIndex = 2
        Me.xlblPurchase_Description.Text = "P.O Description"
        '
        'rtbDESCRIPTION
        '
        Me.rtbDESCRIPTION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbDESCRIPTION.DetectUrls = False
        Me.rtbDESCRIPTION.Location = New System.Drawing.Point(354, 96)
        Me.rtbDESCRIPTION.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rtbDESCRIPTION.Name = "rtbDESCRIPTION"
        Me.rtbDESCRIPTION.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbDESCRIPTION.Size = New System.Drawing.Size(323, 66)
        Me.rtbDESCRIPTION.TabIndex = 2
        Me.rtbDESCRIPTION.Text = ""
        '
        'rtbPURCHASE_DESCRIPTION
        '
        Me.rtbPURCHASE_DESCRIPTION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbPURCHASE_DESCRIPTION.DetectUrls = False
        Me.rtbPURCHASE_DESCRIPTION.Location = New System.Drawing.Point(11, 96)
        Me.rtbPURCHASE_DESCRIPTION.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rtbPURCHASE_DESCRIPTION.Name = "rtbPURCHASE_DESCRIPTION"
        Me.rtbPURCHASE_DESCRIPTION.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbPURCHASE_DESCRIPTION.Size = New System.Drawing.Size(333, 63)
        Me.rtbPURCHASE_DESCRIPTION.TabIndex = 1
        Me.rtbPURCHASE_DESCRIPTION.Text = ""
        '
        'dgvComponents
        '
        Me.dgvComponents.AllowUserToAddRows = False
        Me.dgvComponents.AllowUserToDeleteRows = False
        Me.dgvComponents.AllowUserToResizeColumns = False
        Me.dgvComponents.AllowUserToResizeRows = False
        Me.dgvComponents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvComponents.ColumnHeadersHeight = 35
        Me.dgvComponents.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvComponents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvComponents.Location = New System.Drawing.Point(3, 33)
        Me.dgvComponents.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvComponents.MultiSelect = False
        Me.dgvComponents.Name = "dgvComponents"
        Me.dgvComponents.ReadOnly = True
        Me.dgvComponents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvComponents.Size = New System.Drawing.Size(658, 316)
        Me.dgvComponents.TabIndex = 21
        '
        'cmbRATE_TYPE
        '
        Me.cmbRATE_TYPE.AccessibleDescription = "0"
        Me.cmbRATE_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRATE_TYPE.FormattingEnabled = True
        Me.cmbRATE_TYPE.Location = New System.Drawing.Point(447, 44)
        Me.cmbRATE_TYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbRATE_TYPE.Name = "cmbRATE_TYPE"
        Me.cmbRATE_TYPE.Size = New System.Drawing.Size(207, 24)
        Me.cmbRATE_TYPE.TabIndex = 42
        '
        'chkPRINT_INDIVIDUAL_ITEMS
        '
        Me.chkPRINT_INDIVIDUAL_ITEMS.AutoSize = True
        Me.chkPRINT_INDIVIDUAL_ITEMS.Location = New System.Drawing.Point(570, 7)
        Me.chkPRINT_INDIVIDUAL_ITEMS.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPRINT_INDIVIDUAL_ITEMS.Name = "chkPRINT_INDIVIDUAL_ITEMS"
        Me.chkPRINT_INDIVIDUAL_ITEMS.Size = New System.Drawing.Size(79, 20)
        Me.chkPRINT_INDIVIDUAL_ITEMS.TabIndex = 29
        Me.chkPRINT_INDIVIDUAL_ITEMS.Text = "Invisible"
        Me.chkPRINT_INDIVIDUAL_ITEMS.UseVisualStyleBackColor = False
        '
        'dgvOrder_Preference
        '
        Me.dgvOrder_Preference.AllowUserToAddRows = False
        Me.dgvOrder_Preference.AllowUserToDeleteRows = False
        Me.dgvOrder_Preference.AllowUserToResizeColumns = False
        Me.dgvOrder_Preference.AllowUserToResizeRows = False
        Me.dgvOrder_Preference.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvOrder_Preference.ColumnHeadersHeight = 40
        Me.dgvOrder_Preference.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOrder_Preference.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvOrder_Preference.Location = New System.Drawing.Point(3, 33)
        Me.dgvOrder_Preference.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvOrder_Preference.MultiSelect = False
        Me.dgvOrder_Preference.Name = "dgvOrder_Preference"
        Me.dgvOrder_Preference.ReadOnly = True
        Me.dgvOrder_Preference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOrder_Preference.Size = New System.Drawing.Size(658, 316)
        Me.dgvOrder_Preference.TabIndex = 4
        '
        'xlblASSET_ACCOUNT
        '
        Me.xlblASSET_ACCOUNT.AutoSize = True
        Me.xlblASSET_ACCOUNT.Location = New System.Drawing.Point(8, 7)
        Me.xlblASSET_ACCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblASSET_ACCOUNT.Name = "xlblASSET_ACCOUNT"
        Me.xlblASSET_ACCOUNT.Size = New System.Drawing.Size(104, 16)
        Me.xlblASSET_ACCOUNT.TabIndex = 3
        Me.xlblASSET_ACCOUNT.Text = "Asset Account"
        '
        'cmbASSET_ACCOUNT_ID
        '
        Me.cmbASSET_ACCOUNT_ID.AccessibleDescription = "null"
        Me.cmbASSET_ACCOUNT_ID.DropDownWidth = 300
        Me.cmbASSET_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbASSET_ACCOUNT_ID.Location = New System.Drawing.Point(8, 27)
        Me.cmbASSET_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbASSET_ACCOUNT_ID.Name = "cmbASSET_ACCOUNT_ID"
        Me.cmbASSET_ACCOUNT_ID.Size = New System.Drawing.Size(213, 24)
        Me.cmbASSET_ACCOUNT_ID.TabIndex = 2
        '
        'xlblStock_TYPE
        '
        Me.xlblStock_TYPE.AutoSize = True
        Me.xlblStock_TYPE.Location = New System.Drawing.Point(37, 108)
        Me.xlblStock_TYPE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblStock_TYPE.Name = "xlblStock_TYPE"
        Me.xlblStock_TYPE.Size = New System.Drawing.Size(82, 16)
        Me.xlblStock_TYPE.TabIndex = 1
        Me.xlblStock_TYPE.Text = "Stock Type"
        '
        'cmbSTOCK_TYPE
        '
        Me.cmbSTOCK_TYPE.AccessibleDescription = "0"
        Me.cmbSTOCK_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSTOCK_TYPE.FormattingEnabled = True
        Me.cmbSTOCK_TYPE.Location = New System.Drawing.Point(119, 105)
        Me.cmbSTOCK_TYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSTOCK_TYPE.Name = "cmbSTOCK_TYPE"
        Me.cmbSTOCK_TYPE.Size = New System.Drawing.Size(207, 24)
        Me.cmbSTOCK_TYPE.TabIndex = 0
        '
        'cmbBASE_UNIT_ID
        '
        Me.cmbBASE_UNIT_ID.FormattingEnabled = True
        Me.cmbBASE_UNIT_ID.Location = New System.Drawing.Point(224, 27)
        Me.cmbBASE_UNIT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbBASE_UNIT_ID.Name = "cmbBASE_UNIT_ID"
        Me.cmbBASE_UNIT_ID.Size = New System.Drawing.Size(105, 24)
        Me.cmbBASE_UNIT_ID.TabIndex = 1
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(223, 7)
        Me.Label32.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(68, 16)
        Me.Label32.TabIndex = 0
        Me.Label32.Text = "Base size"
        '
        'TabControl2
        '
        Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl2.Controls.Add(Me.tpOtherSize)
        Me.TabControl2.Controls.Add(Me.tpSizeRateLevel)
        Me.TabControl2.Controls.Add(Me.tpDefaultArea)
        Me.TabControl2.Location = New System.Drawing.Point(2, 60)
        Me.TabControl2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        Me.TabControl2.Size = New System.Drawing.Size(657, 279)
        Me.TabControl2.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TabControl2.TabIndex = 2
        '
        'tpOtherSize
        '
        Me.tpOtherSize.Controls.Add(Me.dgvReleted_Units)
        Me.tpOtherSize.Controls.Add(Me.ToolStrip1)
        Me.tpOtherSize.Location = New System.Drawing.Point(4, 25)
        Me.tpOtherSize.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpOtherSize.Name = "tpOtherSize"
        Me.tpOtherSize.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpOtherSize.Size = New System.Drawing.Size(649, 250)
        Me.tpOtherSize.TabIndex = 0
        Me.tpOtherSize.Text = "Other Size"
        Me.tpOtherSize.UseVisualStyleBackColor = True
        '
        'dgvReleted_Units
        '
        Me.dgvReleted_Units.AllowUserToAddRows = False
        Me.dgvReleted_Units.AllowUserToDeleteRows = False
        Me.dgvReleted_Units.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvReleted_Units.ColumnHeadersHeight = 35
        Me.dgvReleted_Units.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvReleted_Units.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvReleted_Units.Location = New System.Drawing.Point(5, 35)
        Me.dgvReleted_Units.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvReleted_Units.MultiSelect = False
        Me.dgvReleted_Units.Name = "dgvReleted_Units"
        Me.dgvReleted_Units.ReadOnly = True
        Me.dgvReleted_Units.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReleted_Units.Size = New System.Drawing.Size(639, 211)
        Me.dgvReleted_Units.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAdd1, Me.ToolStripSeparator1, Me.tsEdit1, Me.ToolStripSeparator6, Me.tsDelete1})
        Me.ToolStrip1.Location = New System.Drawing.Point(5, 4)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(639, 31)
        Me.ToolStrip1.TabIndex = 31
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsAdd1
        '
        Me.tsAdd1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAdd1.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsAdd1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAdd1.Name = "tsAdd1"
        Me.tsAdd1.Size = New System.Drawing.Size(28, 28)
        Me.tsAdd1.Text = "&Add"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 31)
        '
        'tsEdit1
        '
        Me.tsEdit1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEdit1.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsEdit1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEdit1.Name = "tsEdit1"
        Me.tsEdit1.Size = New System.Drawing.Size(28, 28)
        Me.tsEdit1.Text = "&Edit"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 31)
        '
        'tsDelete1
        '
        Me.tsDelete1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsDelete1.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsDelete1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete1.Name = "tsDelete1"
        Me.tsDelete1.Size = New System.Drawing.Size(28, 28)
        Me.tsDelete1.Text = "&Delete"
        '
        'tpSizeRateLevel
        '
        Me.tpSizeRateLevel.Controls.Add(Me.dgvUM_Price_level)
        Me.tpSizeRateLevel.Controls.Add(Me.ToolStrip2)
        Me.tpSizeRateLevel.Location = New System.Drawing.Point(4, 22)
        Me.tpSizeRateLevel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpSizeRateLevel.Name = "tpSizeRateLevel"
        Me.tpSizeRateLevel.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpSizeRateLevel.Size = New System.Drawing.Size(649, 256)
        Me.tpSizeRateLevel.TabIndex = 1
        Me.tpSizeRateLevel.Text = "Size rate levels"
        Me.tpSizeRateLevel.UseVisualStyleBackColor = True
        '
        'dgvUM_Price_level
        '
        Me.dgvUM_Price_level.AllowUserToAddRows = False
        Me.dgvUM_Price_level.AllowUserToDeleteRows = False
        Me.dgvUM_Price_level.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUM_Price_level.ColumnHeadersHeight = 35
        Me.dgvUM_Price_level.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUM_Price_level.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUM_Price_level.Location = New System.Drawing.Point(5, 35)
        Me.dgvUM_Price_level.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvUM_Price_level.MultiSelect = False
        Me.dgvUM_Price_level.Name = "dgvUM_Price_level"
        Me.dgvUM_Price_level.ReadOnly = True
        Me.dgvUM_Price_level.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUM_Price_level.Size = New System.Drawing.Size(639, 217)
        Me.dgvUM_Price_level.TabIndex = 1
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAdd2, Me.ToolStripSeparator2, Me.tsEdit2, Me.ToolStripSeparator3, Me.tsDelete2})
        Me.ToolStrip2.Location = New System.Drawing.Point(5, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(639, 31)
        Me.ToolStrip2.TabIndex = 32
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAdd2
        '
        Me.tsAdd2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAdd2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsAdd2.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsAdd2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAdd2.Name = "tsAdd2"
        Me.tsAdd2.Size = New System.Drawing.Size(28, 28)
        Me.tsAdd2.Text = "&Add"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 31)
        '
        'tsEdit2
        '
        Me.tsEdit2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEdit2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsEdit2.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsEdit2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEdit2.Name = "tsEdit2"
        Me.tsEdit2.Size = New System.Drawing.Size(28, 28)
        Me.tsEdit2.Text = "&Edit"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 31)
        '
        'tsDelete2
        '
        Me.tsDelete2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsDelete2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsDelete2.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsDelete2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete2.Name = "tsDelete2"
        Me.tsDelete2.Size = New System.Drawing.Size(28, 28)
        Me.tsDelete2.Text = "&Delete"
        '
        'tpDefaultArea
        '
        Me.tpDefaultArea.Controls.Add(Me.dgvLocation_Default)
        Me.tpDefaultArea.Controls.Add(Me.tsDefaultBranchClick)
        Me.tpDefaultArea.Location = New System.Drawing.Point(4, 22)
        Me.tpDefaultArea.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpDefaultArea.Name = "tpDefaultArea"
        Me.tpDefaultArea.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.tpDefaultArea.Size = New System.Drawing.Size(649, 256)
        Me.tpDefaultArea.TabIndex = 2
        Me.tpDefaultArea.Text = "Default Branch"
        Me.tpDefaultArea.UseVisualStyleBackColor = True
        '
        'dgvLocation_Default
        '
        Me.dgvLocation_Default.AllowUserToAddRows = False
        Me.dgvLocation_Default.AllowUserToDeleteRows = False
        Me.dgvLocation_Default.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLocation_Default.ColumnHeadersHeight = 35
        Me.dgvLocation_Default.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLocation_Default.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLocation_Default.Location = New System.Drawing.Point(5, 35)
        Me.dgvLocation_Default.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvLocation_Default.MultiSelect = False
        Me.dgvLocation_Default.Name = "dgvLocation_Default"
        Me.dgvLocation_Default.ReadOnly = True
        Me.dgvLocation_Default.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLocation_Default.Size = New System.Drawing.Size(639, 217)
        Me.dgvLocation_Default.TabIndex = 1
        '
        'tsDefaultBranchClick
        '
        Me.tsDefaultBranchClick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsDefaultBranchClick.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tsDefaultBranchClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDefaultBranch, Me.ToolStripSeparator7})
        Me.tsDefaultBranchClick.Location = New System.Drawing.Point(5, 4)
        Me.tsDefaultBranchClick.Name = "tsDefaultBranchClick"
        Me.tsDefaultBranchClick.Size = New System.Drawing.Size(639, 31)
        Me.tsDefaultBranchClick.TabIndex = 34
        Me.tsDefaultBranchClick.Text = "ToolStrip4"
        '
        'tsDefaultBranch
        '
        Me.tsDefaultBranch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsDefaultBranch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsDefaultBranch.Image = Global.Automission.My.Resources.Resources.l_config
        Me.tsDefaultBranch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDefaultBranch.Name = "tsDefaultBranch"
        Me.tsDefaultBranch.Size = New System.Drawing.Size(28, 28)
        Me.tsDefaultBranch.Text = "&Edit"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 31)
        '
        'dgvPriceLevel
        '
        Me.dgvPriceLevel.AllowUserToAddRows = False
        Me.dgvPriceLevel.AllowUserToDeleteRows = False
        Me.dgvPriceLevel.AllowUserToResizeColumns = False
        Me.dgvPriceLevel.AllowUserToResizeRows = False
        Me.dgvPriceLevel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPriceLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPriceLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPriceLevel.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPriceLevel.Location = New System.Drawing.Point(3, 33)
        Me.dgvPriceLevel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvPriceLevel.MultiSelect = False
        Me.dgvPriceLevel.Name = "dgvPriceLevel"
        Me.dgvPriceLevel.ReadOnly = True
        Me.dgvPriceLevel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPriceLevel.Size = New System.Drawing.Size(658, 316)
        Me.dgvPriceLevel.TabIndex = 2
        '
        'xlblSUB_Class
        '
        Me.xlblSUB_Class.AutoSize = True
        Me.xlblSUB_Class.Location = New System.Drawing.Point(369, 108)
        Me.xlblSUB_Class.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblSUB_Class.Name = "xlblSUB_Class"
        Me.xlblSUB_Class.Size = New System.Drawing.Size(73, 16)
        Me.xlblSUB_Class.TabIndex = 5
        Me.xlblSUB_Class.Text = "Sub-Class"
        '
        'xlblGROUP
        '
        Me.xlblGROUP.AutoSize = True
        Me.xlblGROUP.Location = New System.Drawing.Point(69, 81)
        Me.xlblGROUP.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblGROUP.Name = "xlblGROUP"
        Me.xlblGROUP.Size = New System.Drawing.Size(45, 16)
        Me.xlblGROUP.TabIndex = 4
        Me.xlblGROUP.Text = "Group"
        '
        'xlblCLASS
        '
        Me.xlblCLASS.AutoSize = True
        Me.xlblCLASS.Location = New System.Drawing.Point(400, 81)
        Me.xlblCLASS.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblCLASS.Name = "xlblCLASS"
        Me.xlblCLASS.Size = New System.Drawing.Size(41, 16)
        Me.xlblCLASS.TabIndex = 3
        Me.xlblCLASS.Text = "Class"
        '
        'cmbSUB_CLASS_ID
        '
        Me.cmbSUB_CLASS_ID.FormattingEnabled = True
        Me.cmbSUB_CLASS_ID.Location = New System.Drawing.Point(447, 105)
        Me.cmbSUB_CLASS_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSUB_CLASS_ID.Name = "cmbSUB_CLASS_ID"
        Me.cmbSUB_CLASS_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbSUB_CLASS_ID.TabIndex = 2
        '
        'cmbGROUP_ID
        '
        Me.cmbGROUP_ID.FormattingEnabled = True
        Me.cmbGROUP_ID.Location = New System.Drawing.Point(119, 78)
        Me.cmbGROUP_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbGROUP_ID.Name = "cmbGROUP_ID"
        Me.cmbGROUP_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbGROUP_ID.TabIndex = 1
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.AccessibleName = "0"
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(447, 78)
        Me.cmbCLASS_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbCLASS_ID.TabIndex = 1
        '
        'rtbNOTES
        '
        Me.rtbNOTES.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbNOTES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbNOTES.Location = New System.Drawing.Point(392, 28)
        Me.rtbNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.rtbNOTES.Name = "rtbNOTES"
        Me.rtbNOTES.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.rtbNOTES.Size = New System.Drawing.Size(262, 289)
        Me.rtbNOTES.TabIndex = 0
        Me.rtbNOTES.Text = ""
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Location = New System.Drawing.Point(246, 28)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(33, 30)
        Me.btnBrowse.TabIndex = 17
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(246, 65)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(33, 30)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "X"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'lblPIC_FILENAME
        '
        Me.lblPIC_FILENAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPIC_FILENAME.Location = New System.Drawing.Point(290, 257)
        Me.lblPIC_FILENAME.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblPIC_FILENAME.Name = "lblPIC_FILENAME"
        Me.lblPIC_FILENAME.Size = New System.Drawing.Size(77, 28)
        Me.lblPIC_FILENAME.TabIndex = 19
        Me.lblPIC_FILENAME.Visible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ThisImageLabel
        '
        Me.ThisImageLabel.Location = New System.Drawing.Point(8, 10)
        Me.ThisImageLabel.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ThisImageLabel.Name = "ThisImageLabel"
        Me.ThisImageLabel.Size = New System.Drawing.Size(123, 32)
        Me.ThisImageLabel.TabIndex = 20
        Me.ThisImageLabel.Text = "Image Product"
        '
        'cmbPURCHASES_UNIT_ID
        '
        Me.cmbPURCHASES_UNIT_ID.FormattingEnabled = True
        Me.cmbPURCHASES_UNIT_ID.Location = New System.Drawing.Point(331, 27)
        Me.cmbPURCHASES_UNIT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPURCHASES_UNIT_ID.Name = "cmbPURCHASES_UNIT_ID"
        Me.cmbPURCHASES_UNIT_ID.Size = New System.Drawing.Size(107, 24)
        Me.cmbPURCHASES_UNIT_ID.TabIndex = 43
        '
        'cmbSALES_UNIT_ID
        '
        Me.cmbSALES_UNIT_ID.FormattingEnabled = True
        Me.cmbSALES_UNIT_ID.Location = New System.Drawing.Point(441, 27)
        Me.cmbSALES_UNIT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSALES_UNIT_ID.Name = "cmbSALES_UNIT_ID"
        Me.cmbSALES_UNIT_ID.Size = New System.Drawing.Size(105, 24)
        Me.cmbSALES_UNIT_ID.TabIndex = 44
        '
        'cmbSHIPPING_UNIT_ID
        '
        Me.cmbSHIPPING_UNIT_ID.FormattingEnabled = True
        Me.cmbSHIPPING_UNIT_ID.Location = New System.Drawing.Point(549, 27)
        Me.cmbSHIPPING_UNIT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSHIPPING_UNIT_ID.Name = "cmbSHIPPING_UNIT_ID"
        Me.cmbSHIPPING_UNIT_ID.Size = New System.Drawing.Size(105, 24)
        Me.cmbSHIPPING_UNIT_ID.TabIndex = 45
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(328, 7)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 16)
        Me.Label6.TabIndex = 46
        Me.Label6.Text = "P.O size"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(438, 7)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 16)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "SRP size"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(546, 7)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 16)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Ship size"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tpInfo)
        Me.TabControl1.Controls.Add(Me.tpComponents)
        Me.TabControl1.Controls.Add(Me.tpInventory)
        Me.TabControl1.Controls.Add(Me.tpUnits)
        Me.TabControl1.Controls.Add(Me.tpPriceLevel)
        Me.TabControl1.Controls.Add(Me.tpOther)
        Me.TabControl1.Location = New System.Drawing.Point(6, 169)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(672, 380)
        Me.TabControl1.TabIndex = 49
        '
        'tpInfo
        '
        Me.tpInfo.Controls.Add(Me.chkIS_EXPIRED)
        Me.tpInfo.Controls.Add(Me.xlblPreferered)
        Me.tpInfo.Controls.Add(Me.xlblCOGS_ACCOUNT)
        Me.tpInfo.Controls.Add(Me.cmbRATE_TYPE)
        Me.tpInfo.Controls.Add(Me.xlblSUB_Class)
        Me.tpInfo.Controls.Add(Me.cmbCOGS_ACCOUNT_ID)
        Me.tpInfo.Controls.Add(Me.xlblGROUP)
        Me.tpInfo.Controls.Add(Me.xlblINCOME_ACCOUNT)
        Me.tpInfo.Controls.Add(Me.xlblCLASS)
        Me.tpInfo.Controls.Add(Me.cmbGL_ACCOUNT_ID)
        Me.tpInfo.Controls.Add(Me.cmbSUB_CLASS_ID)
        Me.tpInfo.Controls.Add(Me.chkTAXABLE)
        Me.tpInfo.Controls.Add(Me.cmbPREFERRED_VENDOR_ID)
        Me.tpInfo.Controls.Add(Me.xlblRate)
        Me.tpInfo.Controls.Add(Me.cmbGROUP_ID)
        Me.tpInfo.Controls.Add(Me.numRATE)
        Me.tpInfo.Controls.Add(Me.xlblManufacture)
        Me.tpInfo.Controls.Add(Me.cmbMANUFACTURER_ID)
        Me.tpInfo.Controls.Add(Me.cmbCLASS_ID)
        Me.tpInfo.Controls.Add(Me.xlblCOST)
        Me.tpInfo.Controls.Add(Me.xlblStock_TYPE)
        Me.tpInfo.Controls.Add(Me.numCOST)
        Me.tpInfo.Controls.Add(Me.cmbSTOCK_TYPE)
        Me.tpInfo.Location = New System.Drawing.Point(4, 25)
        Me.tpInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tpInfo.Name = "tpInfo"
        Me.tpInfo.Size = New System.Drawing.Size(664, 351)
        Me.tpInfo.TabIndex = 4
        Me.tpInfo.Text = "Reference"
        Me.tpInfo.UseVisualStyleBackColor = True
        '
        'chkIS_EXPIRED
        '
        Me.chkIS_EXPIRED.AutoSize = True
        Me.chkIS_EXPIRED.Location = New System.Drawing.Point(447, 148)
        Me.chkIS_EXPIRED.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkIS_EXPIRED.Name = "chkIS_EXPIRED"
        Me.chkIS_EXPIRED.Size = New System.Drawing.Size(108, 20)
        Me.chkIS_EXPIRED.TabIndex = 55
        Me.chkIS_EXPIRED.Text = "Expired Item"
        Me.chkIS_EXPIRED.UseVisualStyleBackColor = True
        '
        'tpComponents
        '
        Me.tpComponents.Controls.Add(Me.dgvComponents)
        Me.tpComponents.Controls.Add(Me.chkPRINT_INDIVIDUAL_ITEMS)
        Me.tpComponents.Controls.Add(Me.TSPayment)
        Me.tpComponents.Location = New System.Drawing.Point(4, 25)
        Me.tpComponents.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpComponents.Name = "tpComponents"
        Me.tpComponents.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpComponents.Size = New System.Drawing.Size(664, 351)
        Me.tpComponents.TabIndex = 2
        Me.tpComponents.Text = "Item List"
        Me.tpComponents.UseVisualStyleBackColor = True
        '
        'TSPayment
        '
        Me.TSPayment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSPayment.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.TSPayment.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddTrans, Me.ToolStripSeparator4, Me.EditTrans, Me.ToolStripSeparator5, Me.DeleteTrans})
        Me.TSPayment.Location = New System.Drawing.Point(3, 2)
        Me.TSPayment.Name = "TSPayment"
        Me.TSPayment.Size = New System.Drawing.Size(658, 31)
        Me.TSPayment.TabIndex = 30
        Me.TSPayment.Text = "ToolStrip1"
        '
        'AddTrans
        '
        Me.AddTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.AddTrans.Image = Global.Automission.My.Resources.Resources.l_create
        Me.AddTrans.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddTrans.Name = "AddTrans"
        Me.AddTrans.Size = New System.Drawing.Size(28, 28)
        Me.AddTrans.Text = "&Add"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 31)
        '
        'EditTrans
        '
        Me.EditTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.EditTrans.Image = Global.Automission.My.Resources.Resources.l_update
        Me.EditTrans.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EditTrans.Name = "EditTrans"
        Me.EditTrans.Size = New System.Drawing.Size(28, 28)
        Me.EditTrans.Text = "&Edit"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 31)
        '
        'DeleteTrans
        '
        Me.DeleteTrans.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.DeleteTrans.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.DeleteTrans.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.DeleteTrans.Name = "DeleteTrans"
        Me.DeleteTrans.Size = New System.Drawing.Size(28, 28)
        Me.DeleteTrans.Text = "&Delete"
        '
        'tpInventory
        '
        Me.tpInventory.Controls.Add(Me.dgvOrder_Preference)
        Me.tpInventory.Controls.Add(Me.ToolStrip3)
        Me.tpInventory.Location = New System.Drawing.Point(4, 25)
        Me.tpInventory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpInventory.Name = "tpInventory"
        Me.tpInventory.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpInventory.Size = New System.Drawing.Size(664, 351)
        Me.tpInventory.TabIndex = 0
        Me.tpInventory.Text = "Inventory"
        Me.tpInventory.UseVisualStyleBackColor = True
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsInventoryClick, Me.ToolStripSeparator8})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 2)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(658, 31)
        Me.ToolStrip3.TabIndex = 33
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'tsInventoryClick
        '
        Me.tsInventoryClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsInventoryClick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsInventoryClick.Image = Global.Automission.My.Resources.Resources.l_config
        Me.tsInventoryClick.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsInventoryClick.Name = "tsInventoryClick"
        Me.tsInventoryClick.Size = New System.Drawing.Size(28, 28)
        Me.tsInventoryClick.Text = "&Edit"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 31)
        '
        'tpUnits
        '
        Me.tpUnits.Controls.Add(Me.TabControl2)
        Me.tpUnits.Controls.Add(Me.Label11)
        Me.tpUnits.Controls.Add(Me.cmbSHIPPING_UNIT_ID)
        Me.tpUnits.Controls.Add(Me.Label7)
        Me.tpUnits.Controls.Add(Me.cmbPURCHASES_UNIT_ID)
        Me.tpUnits.Controls.Add(Me.cmbBASE_UNIT_ID)
        Me.tpUnits.Controls.Add(Me.Label6)
        Me.tpUnits.Controls.Add(Me.Label32)
        Me.tpUnits.Controls.Add(Me.cmbSALES_UNIT_ID)
        Me.tpUnits.Controls.Add(Me.xlblASSET_ACCOUNT)
        Me.tpUnits.Controls.Add(Me.cmbASSET_ACCOUNT_ID)
        Me.tpUnits.Location = New System.Drawing.Point(4, 25)
        Me.tpUnits.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpUnits.Name = "tpUnits"
        Me.tpUnits.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpUnits.Size = New System.Drawing.Size(664, 351)
        Me.tpUnits.TabIndex = 1
        Me.tpUnits.Text = "Size"
        Me.tpUnits.UseVisualStyleBackColor = True
        '
        'tpPriceLevel
        '
        Me.tpPriceLevel.Controls.Add(Me.dgvPriceLevel)
        Me.tpPriceLevel.Controls.Add(Me.ToolStrip5)
        Me.tpPriceLevel.Location = New System.Drawing.Point(4, 25)
        Me.tpPriceLevel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpPriceLevel.Name = "tpPriceLevel"
        Me.tpPriceLevel.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tpPriceLevel.Size = New System.Drawing.Size(664, 351)
        Me.tpPriceLevel.TabIndex = 3
        Me.tpPriceLevel.Text = "Rate Levels"
        Me.tpPriceLevel.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsRateLevelsClick, Me.ToolStripSeparator9})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 2)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(658, 31)
        Me.ToolStrip5.TabIndex = 35
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'tsRateLevelsClick
        '
        Me.tsRateLevelsClick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRateLevelsClick.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRateLevelsClick.Image = Global.Automission.My.Resources.Resources.l_config
        Me.tsRateLevelsClick.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRateLevelsClick.Name = "tsRateLevelsClick"
        Me.tsRateLevelsClick.Size = New System.Drawing.Size(28, 28)
        Me.tsRateLevelsClick.Text = "&Edit"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 31)
        '
        'tpOther
        '
        Me.tpOther.Controls.Add(Me.Label12)
        Me.tpOther.Controls.Add(Me.rtbNOTES)
        Me.tpOther.Controls.Add(Me.picItem)
        Me.tpOther.Controls.Add(Me.btnBrowse)
        Me.tpOther.Controls.Add(Me.btnDelete)
        Me.tpOther.Controls.Add(Me.lblPIC_FILENAME)
        Me.tpOther.Controls.Add(Me.ThisImageLabel)
        Me.tpOther.Location = New System.Drawing.Point(4, 25)
        Me.tpOther.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tpOther.Name = "tpOther"
        Me.tpOther.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.tpOther.Size = New System.Drawing.Size(664, 351)
        Me.tpOther.TabIndex = 5
        Me.tpOther.Text = "Others"
        Me.tpOther.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(391, 10)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 16)
        Me.Label12.TabIndex = 52
        Me.Label12.Text = "Notes "
        '
        'picItem
        '
        Me.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picItem.Location = New System.Drawing.Point(8, 28)
        Me.picItem.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.picItem.Name = "picItem"
        Me.picItem.Size = New System.Drawing.Size(228, 246)
        Me.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picItem.TabIndex = 16
        Me.picItem.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(499, 562)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 53
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(592, 562)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 54
        Me.btnCancel.Text = "&Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmItemDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(688, 599)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.chkBUNDLE_SET)
        Me.Controls.Add(Me.chkNON_DISCOUNTED_ITEM)
        Me.Controls.Add(Me.chkNON_PORFOLIO_COMPUTATION)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Controls.Add(Me.rtbPURCHASE_DESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.xlblPurchase_Description)
        Me.Controls.Add(Me.rtbDESCRIPTION)
        Me.Controls.Add(Me.xlblDescription)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item"
        CType(Me.numRATE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCOST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvComponents, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOrder_Preference, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl2.ResumeLayout(False)
        Me.tpOtherSize.ResumeLayout(False)
        Me.tpOtherSize.PerformLayout()
        CType(Me.dgvReleted_Units, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.tpSizeRateLevel.ResumeLayout(False)
        Me.tpSizeRateLevel.PerformLayout()
        CType(Me.dgvUM_Price_level, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.tpDefaultArea.ResumeLayout(False)
        Me.tpDefaultArea.PerformLayout()
        CType(Me.dgvLocation_Default, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsDefaultBranchClick.ResumeLayout(False)
        Me.tsDefaultBranchClick.PerformLayout()
        CType(Me.dgvPriceLevel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.tpInfo.ResumeLayout(False)
        Me.tpInfo.PerformLayout()
        Me.tpComponents.ResumeLayout(False)
        Me.tpComponents.PerformLayout()
        Me.TSPayment.ResumeLayout(False)
        Me.TSPayment.PerformLayout()
        Me.tpInventory.ResumeLayout(False)
        Me.tpInventory.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.tpUnits.ResumeLayout(False)
        Me.tpUnits.PerformLayout()
        Me.tpPriceLevel.ResumeLayout(False)
        Me.tpPriceLevel.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.tpOther.ResumeLayout(False)
        Me.tpOther.PerformLayout()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents xlblRate As Label
    Friend WithEvents numRATE As NumericUpDown
    Friend WithEvents xlblCOST As Label
    Friend WithEvents numCOST As NumericUpDown
    Friend WithEvents xlblDescription As Label
    Friend WithEvents xlblPurchase_Description As Label
    Friend WithEvents rtbDESCRIPTION As RichTextBox
    Friend WithEvents rtbPURCHASE_DESCRIPTION As RichTextBox
    Friend WithEvents chkTAXABLE As CheckBox
    Friend WithEvents cmbCOGS_ACCOUNT_ID As ComboBox
    Friend WithEvents xlblCOGS_ACCOUNT As Label
    Friend WithEvents cmbMANUFACTURER_ID As ComboBox
    Friend WithEvents xlblManufacture As Label
    Friend WithEvents cmbGL_ACCOUNT_ID As ComboBox
    Friend WithEvents xlblINCOME_ACCOUNT As Label
    Friend WithEvents cmbPREFERRED_VENDOR_ID As ComboBox
    Friend WithEvents xlblPreferered As Label
    Friend WithEvents dgvComponents As DataGridView
    Friend WithEvents cmbRATE_TYPE As ComboBox
    Friend WithEvents chkPRINT_INDIVIDUAL_ITEMS As CheckBox
    Friend WithEvents dgvOrder_Preference As DataGridView
    Friend WithEvents xlblASSET_ACCOUNT As Label
    Friend WithEvents cmbASSET_ACCOUNT_ID As ComboBox
    Friend WithEvents xlblStock_TYPE As Label
    Friend WithEvents cmbSTOCK_TYPE As ComboBox
    Friend WithEvents TabControl2 As Windows.Forms.TabControl
    Friend WithEvents tpOtherSize As TabPage
    Friend WithEvents dgvReleted_Units As DataGridView
    Friend WithEvents tpSizeRateLevel As TabPage
    Friend WithEvents dgvUM_Price_level As DataGridView
    Friend WithEvents tpDefaultArea As TabPage
    Friend WithEvents dgvLocation_Default As DataGridView
    Friend WithEvents cmbBASE_UNIT_ID As ComboBox
    Friend WithEvents Label32 As Label
    Friend WithEvents dgvPriceLevel As DataGridView
    Friend WithEvents xlblSUB_Class As Label
    Friend WithEvents xlblGROUP As Label
    Friend WithEvents xlblCLASS As Label
    Friend WithEvents cmbSUB_CLASS_ID As ComboBox
    Friend WithEvents cmbGROUP_ID As ComboBox
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents rtbNOTES As RichTextBox
    Friend WithEvents chkNON_PORFOLIO_COMPUTATION As CheckBox
    Friend WithEvents chkBUNDLE_SET As CheckBox
    Friend WithEvents chkNON_DISCOUNTED_ITEM As CheckBox
    Friend WithEvents picItem As PictureBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lblPIC_FILENAME As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ThisImageLabel As Label
    Friend WithEvents cmbPURCHASES_UNIT_ID As ComboBox
    Friend WithEvents cmbSALES_UNIT_ID As ComboBox
    Friend WithEvents cmbSHIPPING_UNIT_ID As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents tpComponents As TabPage
    Friend WithEvents tpInventory As TabPage
    Friend WithEvents tpUnits As TabPage
    Friend WithEvents tpPriceLevel As TabPage
    Friend WithEvents Label12 As Label
    Friend WithEvents TSPayment As ToolStrip
    Friend WithEvents AddTrans As ToolStripButton
    Friend WithEvents EditTrans As ToolStripButton
    Friend WithEvents DeleteTrans As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsAdd1 As ToolStripButton
    Friend WithEvents tsEdit1 As ToolStripButton
    Friend WithEvents tsDelete1 As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAdd2 As ToolStripButton
    Friend WithEvents tsEdit2 As ToolStripButton
    Friend WithEvents tsDelete2 As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tpInfo As TabPage
    Friend WithEvents tpOther As TabPage
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents tsInventoryClick As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsDefaultBranchClick As ToolStrip
    Friend WithEvents tsDefaultBranch As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents tsRateLevelsClick As ToolStripButton
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents chkIS_EXPIRED As CheckBox
End Class
