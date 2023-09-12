<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSRoomDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOSRoomDetails))
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.cmbSHIP_VIA_ID = New System.Windows.Forms.ComboBox()
        Me.txtPO_NUMBER = New System.Windows.Forms.TextBox()
        Me.cmbACCOUNTS_RECEIVABLE_ID = New System.Windows.Forms.ComboBox()
        Me.dtpDISCOUNT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.cmbSALES_REP_ID = New System.Windows.Forms.ComboBox()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.lblCount = New System.Windows.Forms.ToolStripLabel()
        Me.tsDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsUp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsTransfer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCLASS_ID = New System.Windows.Forms.ComboBox()
        Me.lblOUTPUT_TAX_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.dtpDUE_DATE = New System.Windows.Forms.DateTimePicker()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_TERMS_ID = New System.Windows.Forms.ComboBox()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.xxxlblCI = New System.Windows.Forms.Label()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lbxBalance = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_RATE = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblBALANCE_DUE = New System.Windows.Forms.Label()
        Me.lbxPaymentApplied = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripSeparator()
        Me.spJournal = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsMenu = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCustomer = New System.Windows.Forms.ToolStripButton()
        Me.tsCheckOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPayment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPrintPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.tsJournal = New System.Windows.Forms.ToolStripButton()
        Me.tsCancel = New System.Windows.Forms.ToolStripButton()
        Me.tsRoomName = New System.Windows.Forms.ToolStripLabel()
        Me.tsApplyCredits = New System.Windows.Forms.ToolStripButton()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lblOUTPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.cmbOUTPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.xxxCustomer = New System.Windows.Forms.Label()
        Me.dtpCUSTOM_FIELD1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpCUSTOM_FIELD2 = New System.Windows.Forms.DateTimePicker()
        Me.xxxCO = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCheckOut = New System.Windows.Forms.Button()
        Me.btnCustomer = New System.Windows.Forms.Button()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.dgvPaymentList = New System.Windows.Forms.DataGridView()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tsMenu.SuspendLayout()
        CType(Me.dgvPaymentList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(96, 72)
        Me.ToolStripLabel12.Text = "Total Entry"
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(425, 391)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(57, 22)
        Me.cmbCUSTOMER_ID.TabIndex = 85
        Me.cmbCUSTOMER_ID.Visible = False
        '
        'cmbSHIP_VIA_ID
        '
        Me.cmbSHIP_VIA_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSHIP_VIA_ID.Enabled = False
        Me.cmbSHIP_VIA_ID.FormattingEnabled = True
        Me.cmbSHIP_VIA_ID.Location = New System.Drawing.Point(59, 419)
        Me.cmbSHIP_VIA_ID.Name = "cmbSHIP_VIA_ID"
        Me.cmbSHIP_VIA_ID.Size = New System.Drawing.Size(123, 22)
        Me.cmbSHIP_VIA_ID.TabIndex = 115
        Me.cmbSHIP_VIA_ID.Visible = False
        '
        'txtPO_NUMBER
        '
        Me.txtPO_NUMBER.Location = New System.Drawing.Point(59, 395)
        Me.txtPO_NUMBER.Name = "txtPO_NUMBER"
        Me.txtPO_NUMBER.Size = New System.Drawing.Size(123, 22)
        Me.txtPO_NUMBER.TabIndex = 100
        Me.txtPO_NUMBER.Visible = False
        '
        'cmbACCOUNTS_RECEIVABLE_ID
        '
        Me.cmbACCOUNTS_RECEIVABLE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbACCOUNTS_RECEIVABLE_ID.FormattingEnabled = True
        Me.cmbACCOUNTS_RECEIVABLE_ID.Location = New System.Drawing.Point(227, 391)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Name = "cmbACCOUNTS_RECEIVABLE_ID"
        Me.cmbACCOUNTS_RECEIVABLE_ID.Size = New System.Drawing.Size(174, 22)
        Me.cmbACCOUNTS_RECEIVABLE_ID.TabIndex = 111
        Me.cmbACCOUNTS_RECEIVABLE_ID.Visible = False
        '
        'dtpDISCOUNT_DATE
        '
        Me.dtpDISCOUNT_DATE.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.dtpDISCOUNT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDISCOUNT_DATE.Location = New System.Drawing.Point(12, 201)
        Me.dtpDISCOUNT_DATE.Name = "dtpDISCOUNT_DATE"
        Me.dtpDISCOUNT_DATE.ShowCheckBox = True
        Me.dtpDISCOUNT_DATE.Size = New System.Drawing.Size(246, 33)
        Me.dtpDISCOUNT_DATE.TabIndex = 94
        '
        'cmbSALES_REP_ID
        '
        Me.cmbSALES_REP_ID.FormattingEnabled = True
        Me.cmbSALES_REP_ID.Location = New System.Drawing.Point(227, 435)
        Me.cmbSALES_REP_ID.Name = "cmbSALES_REP_ID"
        Me.cmbSALES_REP_ID.Size = New System.Drawing.Size(174, 22)
        Me.cmbSALES_REP_ID.TabIndex = 110
        Me.cmbSALES_REP_ID.Visible = False
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvProductItem)
        Me.TabPage1.Controls.Add(Me.ToolStrip5)
        Me.TabPage1.Controls.Add(Me.ToolStrip2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(685, 432)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Billing"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AllowUserToResizeColumns = False
        Me.dgvProductItem.AllowUserToResizeRows = False
        Me.dgvProductItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductItem.Location = New System.Drawing.Point(3, 68)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvProductItem.RowHeadersVisible = False
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(679, 286)
        Me.dgvProductItem.TabIndex = 0
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.ImageScalingSize = New System.Drawing.Size(50, 50)
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblCount, Me.ToolStripLabel12, Me.tsDown, Me.ToolStripLabel2, Me.tsUp, Me.ToolStripSeparator8})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 354)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(679, 75)
        Me.ToolStrip5.TabIndex = 154
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'lblCount
        '
        Me.lblCount.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lblCount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(24, 72)
        Me.lblCount.Text = "0"
        '
        'tsDown
        '
        Me.tsDown.Image = Global.Automission.My.Resources.Resources.arrow_down
        Me.tsDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDown.Name = "tsDown"
        Me.tsDown.Size = New System.Drawing.Size(57, 72)
        Me.tsDown.Text = "Down"
        Me.tsDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(14, 72)
        Me.ToolStripLabel2.Text = " "
        '
        'tsUp
        '
        Me.tsUp.Image = Global.Automission.My.Resources.Resources.arrow_up
        Me.tsUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUp.Name = "tsUp"
        Me.tsUp.Size = New System.Drawing.Size(54, 72)
        Me.tsUp.Text = "Up"
        Me.tsUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 75)
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsTransfer, Me.ToolStripSeparator7, Me.ToolStripSeparator6})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 3)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(679, 65)
        Me.ToolStrip2.TabIndex = 17
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAddItem
        '
        Me.tsAddItem.Image = CType(resources.GetObject("tsAddItem.Image"), System.Drawing.Image)
        Me.tsAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddItem.Name = "tsAddItem"
        Me.tsAddItem.Size = New System.Drawing.Size(88, 62)
        Me.tsAddItem.Text = "&Add Item"
        Me.tsAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(6, 65)
        '
        'tsEditItem
        '
        Me.tsEditItem.Image = CType(resources.GetObject("tsEditItem.Image"), System.Drawing.Image)
        Me.tsEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditItem.Name = "tsEditItem"
        Me.tsEditItem.Size = New System.Drawing.Size(89, 62)
        Me.tsEditItem.Text = "&Edit Item"
        Me.tsEditItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(6, 65)
        '
        'tsRemoveItem
        '
        Me.tsRemoveItem.Image = CType(resources.GetObject("tsRemoveItem.Image"), System.Drawing.Image)
        Me.tsRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemoveItem.Name = "tsRemoveItem"
        Me.tsRemoveItem.Size = New System.Drawing.Size(111, 62)
        Me.tsRemoveItem.Text = "&Delete Item"
        Me.tsRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsTransfer
        '
        Me.tsTransfer.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTransfer.Image = Global.Automission.My.Resources.Resources.transfer
        Me.tsTransfer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTransfer.Name = "tsTransfer"
        Me.tsTransfer.Size = New System.Drawing.Size(129, 62)
        Me.tsTransfer.Text = "Room Transfer"
        Me.tsTransfer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 65)
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 65)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(165, 18)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "CUSTOMER NAME"
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(227, 367)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(174, 22)
        Me.cmbCLASS_ID.TabIndex = 108
        Me.cmbCLASS_ID.Visible = False
        '
        'lblOUTPUT_TAX_ACCOUNT_ID
        '
        Me.lblOUTPUT_TAX_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Location = New System.Drawing.Point(80, 557)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Name = "lblOUTPUT_TAX_ACCOUNT_ID"
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Size = New System.Drawing.Size(51, 22)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.TabIndex = 117
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Visible = False
        '
        'dtpDUE_DATE
        '
        Me.dtpDUE_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDUE_DATE.Location = New System.Drawing.Point(236, 392)
        Me.dtpDUE_DATE.Name = "dtpDUE_DATE"
        Me.dtpDUE_DATE.ShowCheckBox = True
        Me.dtpDUE_DATE.Size = New System.Drawing.Size(134, 22)
        Me.dtpDUE_DATE.TabIndex = 88
        Me.dtpDUE_DATE.Visible = False
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(227, 411)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(174, 22)
        Me.cmbLOCATION_ID.TabIndex = 103
        Me.cmbLOCATION_ID.Visible = False
        '
        'txtCODE
        '
        Me.txtCODE.BackColor = System.Drawing.Color.White
        Me.txtCODE.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.txtCODE.Location = New System.Drawing.Point(12, 88)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.ReadOnly = True
        Me.txtCODE.Size = New System.Drawing.Size(246, 33)
        Me.txtCODE.TabIndex = 99
        '
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.AutoSize = True
        Me.lblTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(158, 565)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblTAXABLE_AMOUNT.TabIndex = 124
        Me.lblTAXABLE_AMOUNT.Text = "0.00"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 18)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "BILL NO."
        '
        'cmbPAYMENT_TERMS_ID
        '
        Me.cmbPAYMENT_TERMS_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_TERMS_ID.FormattingEnabled = True
        Me.cmbPAYMENT_TERMS_ID.Location = New System.Drawing.Point(236, 376)
        Me.cmbPAYMENT_TERMS_ID.Name = "cmbPAYMENT_TERMS_ID"
        Me.cmbPAYMENT_TERMS_ID.Size = New System.Drawing.Size(134, 22)
        Me.cmbPAYMENT_TERMS_ID.TabIndex = 86
        Me.cmbPAYMENT_TERMS_ID.Visible = False
        '
        'dtpDATE
        '
        Me.dtpDATE.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(12, 143)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(246, 33)
        Me.dtpDATE.TabIndex = 93
        '
        'xxxlblCI
        '
        Me.xxxlblCI.AutoSize = True
        Me.xxxlblCI.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxlblCI.Location = New System.Drawing.Point(13, 126)
        Me.xxxlblCI.Name = "xxxlblCI"
        Me.xxxlblCI.Size = New System.Drawing.Size(97, 18)
        Me.xxxlblCI.TabIndex = 89
        Me.xxxlblCI.Text = "CHECK-IN"
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.AutoSize = True
        Me.lblNONTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblNONTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(77, 565)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 125
        Me.lblNONTAXABLE_AMOUNT.Text = "0.00"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'lbxBalance
        '
        Me.lbxBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxBalance.BackColor = System.Drawing.Color.Transparent
        Me.lbxBalance.ForeColor = System.Drawing.Color.Red
        Me.lbxBalance.Location = New System.Drawing.Point(138, 459)
        Me.lbxBalance.Name = "lbxBalance"
        Me.lbxBalance.Size = New System.Drawing.Size(215, 26)
        Me.lbxBalance.TabIndex = 127
        Me.lbxBalance.Text = "0.00"
        Me.lbxBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbxBalance.Visible = False
        '
        'lblOUTPUT_TAX_RATE
        '
        Me.lblOUTPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_RATE.Location = New System.Drawing.Point(10, 560)
        Me.lblOUTPUT_TAX_RATE.Name = "lblOUTPUT_TAX_RATE"
        Me.lblOUTPUT_TAX_RATE.Size = New System.Drawing.Size(51, 22)
        Me.lblOUTPUT_TAX_RATE.TabIndex = 123
        Me.lblOUTPUT_TAX_RATE.Text = "0"
        Me.lblOUTPUT_TAX_RATE.Visible = False
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(286, 445)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(56, 14)
        Me.Label25.TabIndex = 126
        Me.Label25.Text = "Balance"
        Me.Label25.Visible = False
        '
        'lblBALANCE_DUE
        '
        Me.lblBALANCE_DUE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBALANCE_DUE.BackColor = System.Drawing.Color.Black
        Me.lblBALANCE_DUE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBALANCE_DUE.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBALANCE_DUE.ForeColor = System.Drawing.Color.Lime
        Me.lblBALANCE_DUE.Location = New System.Drawing.Point(983, 501)
        Me.lblBALANCE_DUE.Name = "lblBALANCE_DUE"
        Me.lblBALANCE_DUE.Size = New System.Drawing.Size(227, 47)
        Me.lblBALANCE_DUE.TabIndex = 122
        Me.lblBALANCE_DUE.Text = "0.00"
        Me.lblBALANCE_DUE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbxPaymentApplied
        '
        Me.lbxPaymentApplied.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxPaymentApplied.BackColor = System.Drawing.Color.Black
        Me.lbxPaymentApplied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lbxPaymentApplied.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxPaymentApplied.ForeColor = System.Drawing.Color.Yellow
        Me.lbxPaymentApplied.Location = New System.Drawing.Point(750, 501)
        Me.lbxPaymentApplied.Name = "lbxPaymentApplied"
        Me.lbxPaymentApplied.Size = New System.Drawing.Size(227, 47)
        Me.lbxPaymentApplied.TabIndex = 121
        Me.lbxPaymentApplied.Text = "0.00"
        Me.lbxPaymentApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Black
        Me.Label19.Location = New System.Drawing.Point(1099, 475)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(104, 25)
        Me.Label19.TabIndex = 120
        Me.Label19.Text = "Balance"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.Black
        Me.Label18.Location = New System.Drawing.Point(861, 473)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(116, 25)
        Me.Label18.TabIndex = 119
        Me.Label18.Text = "Payment"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(517, 5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(693, 463)
        Me.TabControl1.TabIndex = 128
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(6, 69)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(6, 69)
        Me.ToolStripLabel6.Visible = False
        '
        'spJournal
        '
        Me.spJournal.Name = "spJournal"
        Me.spJournal.Size = New System.Drawing.Size(6, 69)
        Me.spJournal.Visible = False
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(6, 69)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(6, 69)
        Me.ToolStripLabel3.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 69)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(6, 69)
        Me.ToolStripLabel1.Visible = False
        '
        'tsMenu
        '
        Me.tsMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tsMenu.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.tsMenu.Font = New System.Drawing.Font("Verdana", 13.0!)
        Me.tsMenu.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.tsMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripSeparator2, Me.tsCustomer, Me.ToolStripSeparator1, Me.tsCheckOut, Me.ToolStripSeparator3, Me.tsPayment, Me.ToolStripSeparator4, Me.tsFind, Me.ToolStripLabel3, Me.tsPrint, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.spJournal, Me.tsJournal, Me.ToolStripLabel6, Me.tsCancel, Me.tsRoomName, Me.tsApplyCredits, Me.ToolStripLabel8, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton1})
        Me.tsMenu.Location = New System.Drawing.Point(0, 461)
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(1221, 69)
        Me.tsMenu.Stretch = True
        Me.tsMenu.TabIndex = 92
        Me.tsMenu.Text = "ToolStrip1"
        Me.tsMenu.Visible = False
        '
        'tsSaveNew
        '
        Me.tsSaveNew.Image = CType(resources.GetObject("tsSaveNew.Image"), System.Drawing.Image)
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = tsSaveNew.Name
        Me.tsSaveNew.Size = New System.Drawing.Size(96, 66)
        Me.tsSaveNew.Text = "Save File"
        Me.tsSaveNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsDiscard
        '
        Me.tsDiscard.Image = CType(resources.GetObject("tsDiscard.Image"), System.Drawing.Image)
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(83, 66)
        Me.tsDiscard.Text = "Refresh"
        Me.tsDiscard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsDiscard.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 69)
        '
        'tsCustomer
        '
        Me.tsCustomer.Image = CType(resources.GetObject("tsCustomer.Image"), System.Drawing.Image)
        Me.tsCustomer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCustomer.Name = "tsCustomer"
        Me.tsCustomer.Size = New System.Drawing.Size(102, 66)
        Me.tsCustomer.Text = "Customer"
        Me.tsCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsCheckOut
        '
        Me.tsCheckOut.Image = CType(resources.GetObject("tsCheckOut.Image"), System.Drawing.Image)
        Me.tsCheckOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCheckOut.Name = "tsCheckOut"
        Me.tsCheckOut.Size = New System.Drawing.Size(108, 66)
        Me.tsCheckOut.Text = "Check-Out"
        Me.tsCheckOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 69)
        '
        'tsPayment
        '
        Me.tsPayment.Image = CType(resources.GetObject("tsPayment.Image"), System.Drawing.Image)
        Me.tsPayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPayment.Name = "tsPayment"
        Me.tsPayment.Size = New System.Drawing.Size(94, 66)
        Me.tsPayment.Text = "Payment"
        Me.tsPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 69)
        '
        'tsFind
        '
        Me.tsFind.Image = CType(resources.GetObject("tsFind.Image"), System.Drawing.Image)
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(88, 66)
        Me.tsFind.Text = "Find File"
        Me.tsFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsFind.Visible = False
        '
        'tsPrint
        '
        Me.tsPrint.Image = CType(resources.GetObject("tsPrint.Image"), System.Drawing.Image)
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(56, 66)
        Me.tsPrint.Text = "Print"
        Me.tsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewToolStripMenuItem, Me.SelectPrintPageToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(13, 66)
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'SelectPrintPageToolStripMenuItem
        '
        Me.SelectPrintPageToolStripMenuItem.Name = "SelectPrintPageToolStripMenuItem"
        Me.SelectPrintPageToolStripMenuItem.Size = New System.Drawing.Size(233, 26)
        Me.SelectPrintPageToolStripMenuItem.Text = "Select Print Page"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(79, 66)
        Me.ToolStripButton2.Text = "History"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton2.Visible = False
        '
        'tsJournal
        '
        Me.tsJournal.Image = CType(resources.GetObject("tsJournal.Image"), System.Drawing.Image)
        Me.tsJournal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsJournal.Name = "tsJournal"
        Me.tsJournal.Size = New System.Drawing.Size(79, 66)
        Me.tsJournal.Text = "Journal"
        Me.tsJournal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsJournal.Visible = False
        '
        'tsCancel
        '
        Me.tsCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsCancel.Image = CType(resources.GetObject("tsCancel.Image"), System.Drawing.Image)
        Me.tsCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCancel.Name = "tsCancel"
        Me.tsCancel.Size = New System.Drawing.Size(63, 66)
        Me.tsCancel.Text = "Close"
        Me.tsCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsRoomName
        '
        Me.tsRoomName.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsRoomName.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRoomName.Name = "tsRoomName"
        Me.tsRoomName.Size = New System.Drawing.Size(130, 66)
        Me.tsRoomName.Text = "Room 000"
        '
        'tsApplyCredits
        '
        Me.tsApplyCredits.Image = CType(resources.GetObject("tsApplyCredits.Image"), System.Drawing.Image)
        Me.tsApplyCredits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsApplyCredits.Name = "tsApplyCredits"
        Me.tsApplyCredits.Size = New System.Drawing.Size(134, 66)
        Me.tsApplyCredits.Text = "Apply Credits"
        Me.tsApplyCredits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsDelete
        '
        Me.tsDelete.Image = CType(resources.GetObject("tsDelete.Image"), System.Drawing.Image)
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(110, 66)
        Me.tsDelete.Text = "Delete File"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(6, 69)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(55, 66)
        Me.ToolStripButton1.Text = "Logs"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.Visible = False
        '
        'lblOUTPUT_TAX_VAT_METHOD
        '
        Me.lblOUTPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(23, 557)
        Me.lblOUTPUT_TAX_VAT_METHOD.Name = "lblOUTPUT_TAX_VAT_METHOD"
        Me.lblOUTPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(48, 22)
        Me.lblOUTPUT_TAX_VAT_METHOD.TabIndex = 118
        Me.lblOUTPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblOUTPUT_TAX_VAT_METHOD.Visible = False
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Black
        Me.lblAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAMOUNT.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Aqua
        Me.lblAMOUNT.Location = New System.Drawing.Point(517, 501)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(227, 47)
        Me.lblAMOUNT.TabIndex = 114
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOUTPUT_TAX_AMOUNT
        '
        Me.lblOUTPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblOUTPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblOUTPUT_TAX_AMOUNT.Location = New System.Drawing.Point(254, 476)
        Me.lblOUTPUT_TAX_AMOUNT.Name = "lblOUTPUT_TAX_AMOUNT"
        Me.lblOUTPUT_TAX_AMOUNT.Size = New System.Drawing.Size(77, 24)
        Me.lblOUTPUT_TAX_AMOUNT.TabIndex = 112
        Me.lblOUTPUT_TAX_AMOUNT.Text = "0.00"
        Me.lblOUTPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblOUTPUT_TAX_AMOUNT.Visible = False
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Black
        Me.Label17.Location = New System.Drawing.Point(617, 473)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(127, 25)
        Me.Label17.TabIndex = 107
        Me.Label17.Text = "Total Bills"
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(12, 412)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(305, 22)
        Me.txtNOTES.TabIndex = 102
        Me.txtNOTES.Visible = False
        '
        'cmbOUTPUT_TAX_ID
        '
        Me.cmbOUTPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOUTPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOUTPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOUTPUT_TAX_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOUTPUT_TAX_ID.FormattingEnabled = True
        Me.cmbOUTPUT_TAX_ID.Location = New System.Drawing.Point(37, 440)
        Me.cmbOUTPUT_TAX_ID.Name = "cmbOUTPUT_TAX_ID"
        Me.cmbOUTPUT_TAX_ID.Size = New System.Drawing.Size(92, 22)
        Me.cmbOUTPUT_TAX_ID.TabIndex = 95
        Me.cmbOUTPUT_TAX_ID.Visible = False
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(205, 478)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 14)
        Me.Label16.TabIndex = 105
        Me.Label16.Text = "Output Tax"
        Me.Label16.Visible = False
        '
        'xxxCustomer
        '
        Me.xxxCustomer.BackColor = System.Drawing.Color.White
        Me.xxxCustomer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xxxCustomer.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.xxxCustomer.Location = New System.Drawing.Point(12, 32)
        Me.xxxCustomer.Name = "xxxCustomer"
        Me.xxxCustomer.Size = New System.Drawing.Size(447, 37)
        Me.xxxCustomer.TabIndex = 98
        Me.xxxCustomer.Text = "XXXX"
        '
        'dtpCUSTOM_FIELD1
        '
        Me.dtpCUSTOM_FIELD1.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.dtpCUSTOM_FIELD1.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCUSTOM_FIELD1.Location = New System.Drawing.Point(289, 143)
        Me.dtpCUSTOM_FIELD1.Name = "dtpCUSTOM_FIELD1"
        Me.dtpCUSTOM_FIELD1.ShowUpDown = True
        Me.dtpCUSTOM_FIELD1.Size = New System.Drawing.Size(222, 33)
        Me.dtpCUSTOM_FIELD1.TabIndex = 130
        '
        'dtpCUSTOM_FIELD2
        '
        Me.dtpCUSTOM_FIELD2.Font = New System.Drawing.Font("Verdana", 15.75!)
        Me.dtpCUSTOM_FIELD2.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpCUSTOM_FIELD2.Location = New System.Drawing.Point(289, 201)
        Me.dtpCUSTOM_FIELD2.Name = "dtpCUSTOM_FIELD2"
        Me.dtpCUSTOM_FIELD2.ShowCheckBox = True
        Me.dtpCUSTOM_FIELD2.ShowUpDown = True
        Me.dtpCUSTOM_FIELD2.Size = New System.Drawing.Size(222, 33)
        Me.dtpCUSTOM_FIELD2.TabIndex = 132
        '
        'xxxCO
        '
        Me.xxxCO.AutoSize = True
        Me.xxxCO.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxCO.Location = New System.Drawing.Point(9, 180)
        Me.xxxCO.Name = "xxxCO"
        Me.xxxCO.Size = New System.Drawing.Size(115, 18)
        Me.xxxCO.TabIndex = 131
        Me.xxxCO.Text = "CHECK-OUT"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(289, 82)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(222, 48)
        Me.btnSave.TabIndex = 134
        Me.btnSave.Text = "Save File"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCheckOut
        '
        Me.btnCheckOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCheckOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCheckOut.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCheckOut.ForeColor = System.Drawing.Color.White
        Me.btnCheckOut.Location = New System.Drawing.Point(289, 241)
        Me.btnCheckOut.Name = "btnCheckOut"
        Me.btnCheckOut.Size = New System.Drawing.Size(222, 48)
        Me.btnCheckOut.TabIndex = 135
        Me.btnCheckOut.Text = "Check-Out"
        Me.btnCheckOut.UseVisualStyleBackColor = False
        '
        'btnCustomer
        '
        Me.btnCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCustomer.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCustomer.ForeColor = System.Drawing.Color.Black
        Me.btnCustomer.Image = Global.Automission.My.Resources.Resources.l_read
        Me.btnCustomer.Location = New System.Drawing.Point(465, 32)
        Me.btnCustomer.Name = "btnCustomer"
        Me.btnCustomer.Size = New System.Drawing.Size(46, 37)
        Me.btnCustomer.TabIndex = 136
        Me.btnCustomer.UseVisualStyleBackColor = False
        '
        'btnPayment
        '
        Me.btnPayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPayment.BackColor = System.Drawing.Color.Navy
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPayment.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.Color.Yellow
        Me.btnPayment.Location = New System.Drawing.Point(313, 499)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(198, 46)
        Me.btnPayment.TabIndex = 137
        Me.btnPayment.Text = "Payment"
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ForeColor = System.Drawing.Color.White
        Me.btnDelete.Location = New System.Drawing.Point(12, 241)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(246, 48)
        Me.btnDelete.TabIndex = 139
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(12, 499)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(200, 46)
        Me.btnClose.TabIndex = 140
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'dgvPaymentList
        '
        Me.dgvPaymentList.AllowUserToAddRows = False
        Me.dgvPaymentList.AllowUserToDeleteRows = False
        Me.dgvPaymentList.AllowUserToResizeColumns = False
        Me.dgvPaymentList.AllowUserToResizeRows = False
        Me.dgvPaymentList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPaymentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPaymentList.Location = New System.Drawing.Point(12, 295)
        Me.dgvPaymentList.MultiSelect = False
        Me.dgvPaymentList.Name = "dgvPaymentList"
        Me.dgvPaymentList.ReadOnly = True
        Me.dgvPaymentList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPaymentList.Size = New System.Drawing.Size(499, 173)
        Me.dgvPaymentList.TabIndex = 141
        '
        'frmPOSRoomDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(1221, 557)
        Me.Controls.Add(Me.dgvPaymentList)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnPayment)
        Me.Controls.Add(Me.btnCustomer)
        Me.Controls.Add(Me.btnCheckOut)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dtpDISCOUNT_DATE)
        Me.Controls.Add(Me.dtpCUSTOM_FIELD2)
        Me.Controls.Add(Me.xxxCO)
        Me.Controls.Add(Me.dtpCUSTOM_FIELD1)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.cmbSHIP_VIA_ID)
        Me.Controls.Add(Me.txtPO_NUMBER)
        Me.Controls.Add(Me.cmbACCOUNTS_RECEIVABLE_ID)
        Me.Controls.Add(Me.cmbSALES_REP_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCLASS_ID)
        Me.Controls.Add(Me.lblOUTPUT_TAX_ACCOUNT_ID)
        Me.Controls.Add(Me.dtpDUE_DATE)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbPAYMENT_TERMS_ID)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.xxxlblCI)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.lbxBalance)
        Me.Controls.Add(Me.lblOUTPUT_TAX_RATE)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lblBALANCE_DUE)
        Me.Controls.Add(Me.lbxPaymentApplied)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.tsMenu)
        Me.Controls.Add(Me.lblOUTPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.lblOUTPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.cmbOUTPUT_TAX_ID)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.xxxCustomer)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSRoomDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Room Details"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tsMenu.ResumeLayout(False)
        Me.tsMenu.PerformLayout()
        CType(Me.dgvPaymentList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
    Friend WithEvents cmbSHIP_VIA_ID As ComboBox
    Friend WithEvents txtPO_NUMBER As TextBox
    Friend WithEvents cmbACCOUNTS_RECEIVABLE_ID As ComboBox
    Friend WithEvents dtpDISCOUNT_DATE As DateTimePicker
    Friend WithEvents cmbSALES_REP_ID As ComboBox
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents lblCount As ToolStripLabel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents lblOUTPUT_TAX_ACCOUNT_ID As Label
    Friend WithEvents dtpDUE_DATE As DateTimePicker
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents cmbPAYMENT_TERMS_ID As ComboBox
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents xxxlblCI As Label
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents lbxBalance As Label
    Friend WithEvents lblOUTPUT_TAX_RATE As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblBALANCE_DUE As Label
    Friend WithEvents lbxPaymentApplied As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As ToolStripSeparator
    Friend WithEvents tsJournal As ToolStripButton
    Friend WithEvents spJournal As ToolStripSeparator
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripLabel4 As ToolStripSeparator
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsPrint As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents tsMenu As ToolStrip
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents ToolStripLabel7 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents lblOUTPUT_TAX_VAT_METHOD As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents lblOUTPUT_TAX_AMOUNT As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents cmbOUTPUT_TAX_ID As ComboBox
    Friend WithEvents Label16 As Label
    Friend WithEvents xxxCustomer As Label
    Friend WithEvents tsCancel As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsCustomer As ToolStripButton
    Friend WithEvents tsCheckOut As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsApplyCredits As ToolStripButton
    Friend WithEvents tsPayment As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents dtpCUSTOM_FIELD1 As DateTimePicker
    Friend WithEvents dtpCUSTOM_FIELD2 As DateTimePicker
    Friend WithEvents xxxCO As Label
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsTransfer As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsRoomName As ToolStripLabel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCheckOut As Button
    Friend WithEvents btnCustomer As Button
    Friend WithEvents btnPayment As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsDown As ToolStripButton
    Friend WithEvents tsUp As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents dgvPaymentList As DataGridView
End Class
