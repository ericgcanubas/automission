<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSOrderEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOSOrderEntry))
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.lblOUTPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.tsCOUNT = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.cmbOUTPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.lblOUTPUT_TAX_RATE = New System.Windows.Forms.Label()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.txtPO_NUMBER = New System.Windows.Forms.TextBox()
        Me.cmbSALES_REP_ID = New System.Windows.Forms.ComboBox()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.dtpDATE_NEEDED = New System.Windows.Forms.DateTimePicker()
        Me.cmbPAYMENT_TERMS_ID = New System.Windows.Forms.ComboBox()
        Me.cmbCLASS_ID = New System.Windows.Forms.ComboBox()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.xlblAcctNo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.xlblCustomer_Name = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.xlblTax = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.xlblTOTAL = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.pcLOGO = New System.Windows.Forms.PictureBox()
        Me.btnSALESMAN = New System.Windows.Forms.Button()
        Me.btnCUSTOMER = New System.Windows.Forms.Button()
        Me.btnITEMLIST = New System.Windows.Forms.Button()
        Me.btnBACK = New System.Windows.Forms.Button()
        Me.btnPrintOnly = New System.Windows.Forms.Button()
        Me.btnTAX = New System.Windows.Forms.Button()
        Me.btnDISCON = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.xlblSalesRep = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.xlblTender = New System.Windows.Forms.Label()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.pcLOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.AutoSize = True
        Me.lblTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(267, 142)
        Me.lblTAXABLE_AMOUNT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblTAXABLE_AMOUNT.TabIndex = 110
        Me.lblTAXABLE_AMOUNT.Text = "0.00"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'tsDelete
        '
        Me.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDelete.Image = CType(resources.GetObject("tsDelete.Image"), System.Drawing.Image)
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(54, 22)
        Me.tsDelete.Text = "Delete"
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(47, 22)
        Me.tsClose.Text = "Close"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel7.Text = "       "
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripButton4.Text = "Logs"
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvProductItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductItem.Location = New System.Drawing.Point(0, 0)
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(823, 402)
        Me.dgvProductItem.TabIndex = 0
        '
        'lblOUTPUT_TAX_VAT_METHOD
        '
        Me.lblOUTPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(204, 104)
        Me.lblOUTPUT_TAX_VAT_METHOD.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOUTPUT_TAX_VAT_METHOD.Name = "lblOUTPUT_TAX_VAT_METHOD"
        Me.lblOUTPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(47, 25)
        Me.lblOUTPUT_TAX_VAT_METHOD.TabIndex = 109
        Me.lblOUTPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblOUTPUT_TAX_VAT_METHOD.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11, Me.ToolStripSeparator1, Me.ToolStripLabel12, Me.tsCOUNT})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 402)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(823, 47)
        Me.ToolStrip2.TabIndex = 18
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAddItem
        '
        Me.tsAddItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tsAddItem.Image = Global.Automission.My.Resources.Resources.add
        Me.tsAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddItem.Name = "tsAddItem"
        Me.tsAddItem.Size = New System.Drawing.Size(82, 44)
        Me.tsAddItem.Text = "&ADD"
        Me.tsAddItem.ToolTipText = "ADD"
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(6, 47)
        '
        'tsEditItem
        '
        Me.tsEditItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold)
        Me.tsEditItem.Image = Global.Automission.My.Resources.Resources.edit
        Me.tsEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditItem.Name = "tsEditItem"
        Me.tsEditItem.Size = New System.Drawing.Size(85, 44)
        Me.tsEditItem.Text = "&EDIT"
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(6, 47)
        '
        'tsRemoveItem
        '
        Me.tsRemoveItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRemoveItem.Image = Global.Automission.My.Resources.Resources.delete
        Me.tsRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemoveItem.Name = "tsRemoveItem"
        Me.tsRemoveItem.Size = New System.Drawing.Size(112, 44)
        Me.tsRemoveItem.Text = "&REMOVE"
        '
        'tsFindText
        '
        Me.tsFindText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsFindText.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsFindText.Name = "tsFindText"
        Me.tsFindText.Size = New System.Drawing.Size(300, 47)
        '
        'ToolStripLabel11
        '
        Me.ToolStripLabel11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel11.Name = "ToolStripLabel11"
        Me.ToolStripLabel11.Size = New System.Drawing.Size(35, 44)
        Me.ToolStripLabel11.Text = "Find"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 47)
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(66, 44)
        Me.ToolStripLabel12.Text = "COUNT :"
        '
        'tsCOUNT
        '
        Me.tsCOUNT.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsCOUNT.Name = "tsCOUNT"
        Me.tsCOUNT.Size = New System.Drawing.Size(17, 44)
        Me.tsCOUNT.Text = "0"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel8.Text = "       "
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.AutoSize = True
        Me.lblNONTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblNONTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(194, 142)
        Me.lblNONTAXABLE_AMOUNT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 111
        Me.lblNONTAXABLE_AMOUNT.Text = "0.00"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(157, 134)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNOTES.Multiline = True
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTES.Size = New System.Drawing.Size(159, 41)
        Me.txtNOTES.TabIndex = 103
        Me.txtNOTES.Visible = False
        '
        'cmbOUTPUT_TAX_ID
        '
        Me.cmbOUTPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOUTPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOUTPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOUTPUT_TAX_ID.FormattingEnabled = True
        Me.cmbOUTPUT_TAX_ID.Location = New System.Drawing.Point(43, 151)
        Me.cmbOUTPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbOUTPUT_TAX_ID.Name = "cmbOUTPUT_TAX_ID"
        Me.cmbOUTPUT_TAX_ID.Size = New System.Drawing.Size(134, 24)
        Me.cmbOUTPUT_TAX_ID.TabIndex = 101
        Me.cmbOUTPUT_TAX_ID.Visible = False
        '
        'lblOUTPUT_TAX_RATE
        '
        Me.lblOUTPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_RATE.Location = New System.Drawing.Point(145, 104)
        Me.lblOUTPUT_TAX_RATE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblOUTPUT_TAX_RATE.Name = "lblOUTPUT_TAX_RATE"
        Me.lblOUTPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_RATE.TabIndex = 112
        Me.lblOUTPUT_TAX_RATE.Text = "0"
        Me.lblOUTPUT_TAX_RATE.Visible = False
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(109, 22)
        Me.ToolStripButton5.Text = "Create Invoice"
        '
        'txtPO_NUMBER
        '
        Me.txtPO_NUMBER.Location = New System.Drawing.Point(15, 160)
        Me.txtPO_NUMBER.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPO_NUMBER.Name = "txtPO_NUMBER"
        Me.txtPO_NUMBER.Size = New System.Drawing.Size(134, 23)
        Me.txtPO_NUMBER.TabIndex = 83
        Me.txtPO_NUMBER.Visible = False
        '
        'cmbSALES_REP_ID
        '
        Me.cmbSALES_REP_ID.FormattingEnabled = True
        Me.cmbSALES_REP_ID.Location = New System.Drawing.Point(156, 135)
        Me.cmbSALES_REP_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbSALES_REP_ID.Name = "cmbSALES_REP_ID"
        Me.cmbSALES_REP_ID.Size = New System.Drawing.Size(133, 24)
        Me.cmbSALES_REP_ID.TabIndex = 96
        Me.cmbSALES_REP_ID.Visible = False
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(16, 84)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(133, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 81
        Me.cmbCUSTOMER_ID.Visible = False
        '
        'dtpDATE_NEEDED
        '
        Me.dtpDATE_NEEDED.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE_NEEDED.Location = New System.Drawing.Point(16, 134)
        Me.dtpDATE_NEEDED.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDATE_NEEDED.Name = "dtpDATE_NEEDED"
        Me.dtpDATE_NEEDED.ShowCheckBox = True
        Me.dtpDATE_NEEDED.Size = New System.Drawing.Size(133, 23)
        Me.dtpDATE_NEEDED.TabIndex = 86
        Me.dtpDATE_NEEDED.Visible = False
        '
        'cmbPAYMENT_TERMS_ID
        '
        Me.cmbPAYMENT_TERMS_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_TERMS_ID.FormattingEnabled = True
        Me.cmbPAYMENT_TERMS_ID.Location = New System.Drawing.Point(16, 110)
        Me.cmbPAYMENT_TERMS_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPAYMENT_TERMS_ID.Name = "cmbPAYMENT_TERMS_ID"
        Me.cmbPAYMENT_TERMS_ID.Size = New System.Drawing.Size(133, 24)
        Me.cmbPAYMENT_TERMS_ID.TabIndex = 82
        Me.cmbPAYMENT_TERMS_ID.Visible = False
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(156, 162)
        Me.cmbCLASS_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(133, 24)
        Me.cmbCLASS_ID.TabIndex = 94
        Me.cmbCLASS_ID.Visible = False
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(156, 109)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(133, 24)
        Me.cmbLOCATION_ID.TabIndex = 92
        Me.cmbLOCATION_ID.Visible = False
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel6.Text = "       "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(26, 26)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.ToolStripLabel5, Me.ToolStripButton3, Me.ToolStripLabel6, Me.ToolStripButton5, Me.ToolStripLabel8, Me.tsDelete, Me.tsClose, Me.ToolStripLabel7, Me.ToolStripButton4})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1156, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 99
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.ToolStrip1.Visible = False
        '
        'tsSaveNew
        '
        Me.tsSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSaveNew.Image = CType(resources.GetObject("tsSaveNew.Image"), System.Drawing.Image)
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(107, 22)
        Me.tsSaveNew.Text = "Save and New"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel1.Text = "       "
        '
        'tsDiscard
        '
        Me.tsDiscard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDiscard.Image = CType(resources.GetObject("tsDiscard.Image"), System.Drawing.Image)
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(60, 22)
        Me.tsDiscard.Text = "Discard"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel2.Text = "       "
        '
        'tsFind
        '
        Me.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsFind.Image = CType(resources.GetObject("tsFind.Image"), System.Drawing.Image)
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(39, 22)
        Me.tsFind.Text = "Find"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel3.Text = "       "
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripButton1.Text = "Print"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(13, 22)
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel4.Text = "       "
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripButton2.Text = "History"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel5.Text = "       "
        Me.ToolStripLabel5.Visible = False
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripButton3.Text = "Journal"
        Me.ToolStripButton3.Visible = False
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(156, 84)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(133, 23)
        Me.dtpDATE.TabIndex = 87
        Me.dtpDATE.Visible = False
        '
        'xlblAcctNo
        '
        Me.xlblAcctNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xlblAcctNo.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblAcctNo.Location = New System.Drawing.Point(859, 6)
        Me.xlblAcctNo.Name = "xlblAcctNo"
        Me.xlblAcctNo.Size = New System.Drawing.Size(180, 22)
        Me.xlblAcctNo.TabIndex = 166
        Me.xlblAcctNo.Text = "0000000000000"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(804, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 21)
        Me.Label3.TabIndex = 165
        Me.Label3.Text = " NO."
        '
        'lblCODE
        '
        Me.lblCODE.BackColor = System.Drawing.Color.Maroon
        Me.lblCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCODE.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold)
        Me.lblCODE.ForeColor = System.Drawing.Color.White
        Me.lblCODE.Location = New System.Drawing.Point(101, 91)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(198, 42)
        Me.lblCODE.TabIndex = 159
        Me.lblCODE.Text = "9999999999"
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblCODE.Visible = False
        '
        'xlblCustomer_Name
        '
        Me.xlblCustomer_Name.BackColor = System.Drawing.Color.Navy
        Me.xlblCustomer_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCustomer_Name.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold)
        Me.xlblCustomer_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xlblCustomer_Name.Location = New System.Drawing.Point(404, 31)
        Me.xlblCustomer_Name.Name = "xlblCustomer_Name"
        Me.xlblCustomer_Name.Size = New System.Drawing.Size(640, 42)
        Me.xlblCustomer_Name.TabIndex = 164
        Me.xlblCustomer_Name.Text = "JUAN DELA CRUZ"
        Me.xlblCustomer_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(404, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(640, 28)
        Me.Label2.TabIndex = 157
        Me.Label2.Text = "BUYER NAME"
        '
        'xlblTax
        '
        Me.xlblTax.BackColor = System.Drawing.Color.SpringGreen
        Me.xlblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTax.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblTax.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.xlblTax.Location = New System.Drawing.Point(1045, 3)
        Me.xlblTax.Name = "xlblTax"
        Me.xlblTax.Size = New System.Drawing.Size(184, 28)
        Me.xlblTax.TabIndex = 161
        Me.xlblTax.Text = "TAX LABEL"
        Me.xlblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOUTPUT_TAX_AMOUNT
        '
        Me.lblOUTPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblOUTPUT_TAX_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_AMOUNT.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUTPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.SpringGreen
        Me.lblOUTPUT_TAX_AMOUNT.Location = New System.Drawing.Point(1045, 31)
        Me.lblOUTPUT_TAX_AMOUNT.Name = "lblOUTPUT_TAX_AMOUNT"
        Me.lblOUTPUT_TAX_AMOUNT.Size = New System.Drawing.Size(185, 42)
        Me.lblOUTPUT_TAX_AMOUNT.TabIndex = 162
        Me.lblOUTPUT_TAX_AMOUNT.Text = "99,999.99"
        Me.lblOUTPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblTOTAL
        '
        Me.xlblTOTAL.AutoSize = True
        Me.xlblTOTAL.BackColor = System.Drawing.Color.Black
        Me.xlblTOTAL.Font = New System.Drawing.Font("Verdana", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblTOTAL.ForeColor = System.Drawing.Color.Lime
        Me.xlblTOTAL.Location = New System.Drawing.Point(409, 78)
        Me.xlblTOTAL.Name = "xlblTOTAL"
        Me.xlblTOTAL.Size = New System.Drawing.Size(235, 59)
        Me.xlblTOTAL.TabIndex = 160
        Me.xlblTOTAL.Text = "TOTAL :"
        Me.xlblTOTAL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Black
        Me.lblAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAMOUNT.Font = New System.Drawing.Font("Verdana", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Lime
        Me.lblAMOUNT.Location = New System.Drawing.Point(404, 73)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(827, 72)
        Me.lblAMOUNT.TabIndex = 163
        Me.lblAMOUNT.Text = "9,999,999.99"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'pcLOGO
        '
        Me.pcLOGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcLOGO.Location = New System.Drawing.Point(10, 6)
        Me.pcLOGO.Name = "pcLOGO"
        Me.pcLOGO.Size = New System.Drawing.Size(388, 194)
        Me.pcLOGO.TabIndex = 167
        Me.pcLOGO.TabStop = False
        '
        'btnSALESMAN
        '
        Me.btnSALESMAN.Location = New System.Drawing.Point(309, 285)
        Me.btnSALESMAN.Name = "btnSALESMAN"
        Me.btnSALESMAN.Size = New System.Drawing.Size(90, 73)
        Me.btnSALESMAN.TabIndex = 170
        Me.btnSALESMAN.Text = "[f8] " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SALESMAN"
        Me.btnSALESMAN.UseVisualStyleBackColor = True
        '
        'btnCUSTOMER
        '
        Me.btnCUSTOMER.Location = New System.Drawing.Point(210, 284)
        Me.btnCUSTOMER.Name = "btnCUSTOMER"
        Me.btnCUSTOMER.Size = New System.Drawing.Size(90, 73)
        Me.btnCUSTOMER.TabIndex = 169
        Me.btnCUSTOMER.Text = "[f7] " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "CUSTOMER"
        Me.btnCUSTOMER.UseVisualStyleBackColor = True
        '
        'btnITEMLIST
        '
        Me.btnITEMLIST.Location = New System.Drawing.Point(111, 284)
        Me.btnITEMLIST.Name = "btnITEMLIST"
        Me.btnITEMLIST.Size = New System.Drawing.Size(90, 73)
        Me.btnITEMLIST.TabIndex = 168
        Me.btnITEMLIST.Text = "[f6]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " ITEM list"
        Me.btnITEMLIST.UseVisualStyleBackColor = True
        '
        'btnBACK
        '
        Me.btnBACK.Location = New System.Drawing.Point(309, 364)
        Me.btnBACK.Name = "btnBACK"
        Me.btnBACK.Size = New System.Drawing.Size(90, 73)
        Me.btnBACK.TabIndex = 175
        Me.btnBACK.Text = "[F12]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " BACK"
        Me.btnBACK.UseVisualStyleBackColor = True
        '
        'btnPrintOnly
        '
        Me.btnPrintOnly.Location = New System.Drawing.Point(309, 206)
        Me.btnPrintOnly.Name = "btnPrintOnly"
        Me.btnPrintOnly.Size = New System.Drawing.Size(90, 73)
        Me.btnPrintOnly.TabIndex = 174
        Me.btnPrintOnly.Text = "[F4] PRINT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "[CTRL+f4] OPTION"
        Me.btnPrintOnly.UseVisualStyleBackColor = True
        '
        'btnTAX
        '
        Me.btnTAX.Location = New System.Drawing.Point(209, 206)
        Me.btnTAX.Name = "btnTAX"
        Me.btnTAX.Size = New System.Drawing.Size(90, 73)
        Me.btnTAX.TabIndex = 173
        Me.btnTAX.Text = "[f3]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "tax"
        Me.btnTAX.UseVisualStyleBackColor = True
        '
        'btnDISCON
        '
        Me.btnDISCON.Location = New System.Drawing.Point(110, 206)
        Me.btnDISCON.Name = "btnDISCON"
        Me.btnDISCON.Size = New System.Drawing.Size(90, 73)
        Me.btnDISCON.TabIndex = 172
        Me.btnDISCON.Text = "[f2]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RESET | NEW"
        Me.btnDISCON.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(10, 206)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 73)
        Me.btnSave.TabIndex = 171
        Me.btnSave.Text = "[F1] " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Save Entry"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(404, 631)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(826, 23)
        Me.Label1.TabIndex = 177
        Me.Label1.Text = "SALES MAN :"
        '
        'xlblSalesRep
        '
        Me.xlblSalesRep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblSalesRep.BackColor = System.Drawing.Color.Navy
        Me.xlblSalesRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblSalesRep.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblSalesRep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblSalesRep.Location = New System.Drawing.Point(404, 655)
        Me.xlblSalesRep.Name = "xlblSalesRep"
        Me.xlblSalesRep.Size = New System.Drawing.Size(826, 31)
        Me.xlblSalesRep.TabIndex = 176
        Me.xlblSalesRep.Text = "SELLER"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 689)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1380, 22)
        Me.StatusStrip1.TabIndex = 178
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.dgvProductItem)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Location = New System.Drawing.Point(404, 148)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(825, 451)
        Me.Panel1.TabIndex = 179
        '
        'xlblTender
        '
        Me.xlblTender.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblTender.BackColor = System.Drawing.Color.White
        Me.xlblTender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTender.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold)
        Me.xlblTender.ForeColor = System.Drawing.Color.Yellow
        Me.xlblTender.Location = New System.Drawing.Point(404, 602)
        Me.xlblTender.Name = "xlblTender"
        Me.xlblTender.Size = New System.Drawing.Size(826, 28)
        Me.xlblTender.TabIndex = 180
        Me.xlblTender.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPOSOrderEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1380, 711)
        Me.Controls.Add(Me.xlblTender)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.xlblSalesRep)
        Me.Controls.Add(Me.btnSALESMAN)
        Me.Controls.Add(Me.btnCUSTOMER)
        Me.Controls.Add(Me.btnITEMLIST)
        Me.Controls.Add(Me.btnBACK)
        Me.Controls.Add(Me.btnPrintOnly)
        Me.Controls.Add(Me.btnTAX)
        Me.Controls.Add(Me.btnDISCON)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pcLOGO)
        Me.Controls.Add(Me.xlblAcctNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblCODE)
        Me.Controls.Add(Me.xlblCustomer_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.xlblTax)
        Me.Controls.Add(Me.lblOUTPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.xlblTOTAL)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.lblOUTPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.cmbOUTPUT_TAX_ID)
        Me.Controls.Add(Me.lblOUTPUT_TAX_RATE)
        Me.Controls.Add(Me.txtPO_NUMBER)
        Me.Controls.Add(Me.cmbSALES_REP_ID)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.dtpDATE_NEEDED)
        Me.Controls.Add(Me.cmbPAYMENT_TERMS_ID)
        Me.Controls.Add(Me.cmbCLASS_ID)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPOSOrderEntry"
        Me.Text = "POS Order Entry"
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.pcLOGO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents lblOUTPUT_TAX_VAT_METHOD As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents cmbOUTPUT_TAX_ID As ComboBox
    Friend WithEvents lblOUTPUT_TAX_RATE As Label
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents txtPO_NUMBER As TextBox
    Friend WithEvents cmbSALES_REP_ID As ComboBox
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
    Friend WithEvents dtpDATE_NEEDED As DateTimePicker
    Friend WithEvents cmbPAYMENT_TERMS_ID As ComboBox
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents xlblAcctNo As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblCODE As Label
    Friend WithEvents xlblCustomer_Name As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents xlblTax As Label
    Friend WithEvents lblOUTPUT_TAX_AMOUNT As Label
    Friend WithEvents xlblTOTAL As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents pcLOGO As PictureBox
    Friend WithEvents btnSALESMAN As Button
    Friend WithEvents btnCUSTOMER As Button
    Friend WithEvents btnITEMLIST As Button
    Friend WithEvents btnBACK As Button
    Friend WithEvents btnPrintOnly As Button
    Friend WithEvents btnTAX As Button
    Friend WithEvents btnDISCON As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents xlblSalesRep As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents tsCOUNT As ToolStripLabel
    Friend WithEvents xlblTender As Label
End Class
