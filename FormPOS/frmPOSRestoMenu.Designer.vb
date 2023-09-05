<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOSRestoMenu
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOSRestoMenu))
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.cmbSALES_REP_ID = New System.Windows.Forms.ComboBox()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.lblOUTPUT_TAX_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.cmbCLASS_ID = New System.Windows.Forms.ComboBox()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.cmbPAYMENT_TERMS_ID = New System.Windows.Forms.ComboBox()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.lblOUTPUT_TAX_RATE = New System.Windows.Forms.Label()
        Me.lblBALANCE_DUE = New System.Windows.Forms.Label()
        Me.lbxPaymentApplied = New System.Windows.Forms.Label()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPrintPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.tsApplyCredits = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToCreditMemoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.lblOUTPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.cmbOUTPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.xlblSalesRep = New System.Windows.Forms.Label()
        Me.xxlblSalesman = New System.Windows.Forms.Label()
        Me.tsITEM_MENU = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsTextFind = New System.Windows.Forms.ToolStripTextBox()
        Me.tsCOUNT = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel()
        Me.tsUP = New System.Windows.Forms.ToolStripButton()
        Me.tsDOWN = New System.Windows.Forms.ToolStripButton()
        Me.xlblAcctNo = New System.Windows.Forms.Label()
        Me.xlblAcctnoTitle = New System.Windows.Forms.Label()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.xlblCustomer_Name = New System.Windows.Forms.Label()
        Me.xlblCustomerTItle = New System.Windows.Forms.Label()
        Me.xlblTax = New System.Windows.Forms.Label()
        Me.xlblCODE_TITLE = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.xlblTOTAL = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tslblCONNECT = New System.Windows.Forms.ToolStripStatusLabel()
        Me.FLP_TABLE = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlTOP = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.rbDINE_IN = New System.Windows.Forms.RadioButton()
        Me.rbTAKE_OUT = New System.Windows.Forms.RadioButton()
        Me.rbDELIVERY = New System.Windows.Forms.RadioButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlTOP2 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlOP = New System.Windows.Forms.Panel()
        Me.btnNEWORDER = New System.Windows.Forms.Button()
        Me.dgvSalesOrder = New System.Windows.Forms.DataGridView()
        Me.btnPODERDER_DETAILS = New System.Windows.Forms.Button()
        Me.pnlOS = New System.Windows.Forms.Panel()
        Me.btnVIEW_DETAILS = New System.Windows.Forms.Button()
        Me.btnRECEIVED_ORDER = New System.Windows.Forms.Button()
        Me.dgvInvoice = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPRINTBILL_Fake = New System.Windows.Forms.Button()
        Me.btnCreatePayment_Fake = New System.Windows.Forms.Button()
        Me.pcLOGO = New System.Windows.Forms.PictureBox()
        Me.xlblTABLE_NO = New System.Windows.Forms.Label()
        Me.pnlOther = New System.Windows.Forms.Panel()
        Me.txtPO_NUMBER = New System.Windows.Forms.TextBox()
        Me.dtpDISCOUNT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.cmbACCOUNTS_RECEIVABLE_ID = New System.Windows.Forms.ComboBox()
        Me.btnTAX = New System.Windows.Forms.Button()
        Me.btnSALESMAN = New System.Windows.Forms.Button()
        Me.btnCUSTOMER = New System.Windows.Forms.Button()
        Me.btnDELETE = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.dtpDUE_DATE = New System.Windows.Forms.DateTimePicker()
        Me.lbxBalance = New System.Windows.Forms.Label()
        Me.xlblTABLE_TYPE = New System.Windows.Forms.Label()
        Me.btnMENU = New System.Windows.Forms.Button()
        Me.btnPRINTOS = New System.Windows.Forms.Button()
        Me.btnCreatePayment = New System.Windows.Forms.Button()
        Me.btnPRINTBILL = New System.Windows.Forms.Button()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tsITEM_MENU.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlTOP.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlTOP2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.pnlOP.SuspendLayout()
        CType(Me.dgvSalesOrder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOS.SuspendLayout()
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.pcLOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(26, 79)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(122, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 85
        Me.cmbCUSTOMER_ID.Visible = False
        '
        'cmbSALES_REP_ID
        '
        Me.cmbSALES_REP_ID.FormattingEnabled = True
        Me.cmbSALES_REP_ID.Location = New System.Drawing.Point(299, 109)
        Me.cmbSALES_REP_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSALES_REP_ID.Name = "cmbSALES_REP_ID"
        Me.cmbSALES_REP_ID.Size = New System.Drawing.Size(44, 24)
        Me.cmbSALES_REP_ID.TabIndex = 111
        Me.cmbSALES_REP_ID.Visible = False
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AllowUserToResizeColumns = False
        Me.dgvProductItem.AllowUserToResizeRows = False
        Me.dgvProductItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductItem.Location = New System.Drawing.Point(0, 55)
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvProductItem.RowHeadersVisible = False
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(715, 166)
        Me.dgvProductItem.TabIndex = 0
        '
        'lblOUTPUT_TAX_ACCOUNT_ID
        '
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Location = New System.Drawing.Point(601, 59)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Name = "lblOUTPUT_TAX_ACCOUNT_ID"
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.TabIndex = 118
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Visible = False
        '
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTAXABLE_AMOUNT.AutoSize = True
        Me.lblTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(367, 111)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblTAXABLE_AMOUNT.TabIndex = 125
        Me.lblTAXABLE_AMOUNT.Text = "0.00"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(154, 79)
        Me.cmbCLASS_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(82, 24)
        Me.cmbCLASS_ID.TabIndex = 108
        Me.cmbCLASS_ID.Visible = False
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(299, 139)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(51, 24)
        Me.cmbLOCATION_ID.TabIndex = 104
        Me.cmbLOCATION_ID.Visible = False
        '
        'cmbPAYMENT_TERMS_ID
        '
        Me.cmbPAYMENT_TERMS_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_TERMS_ID.FormattingEnabled = True
        Me.cmbPAYMENT_TERMS_ID.Location = New System.Drawing.Point(26, 104)
        Me.cmbPAYMENT_TERMS_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPAYMENT_TERMS_ID.Name = "cmbPAYMENT_TERMS_ID"
        Me.cmbPAYMENT_TERMS_ID.Size = New System.Drawing.Size(122, 24)
        Me.cmbPAYMENT_TERMS_ID.TabIndex = 84
        Me.cmbPAYMENT_TERMS_ID.Visible = False
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblNONTAXABLE_AMOUNT.AutoSize = True
        Me.lblNONTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblNONTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(366, 69)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 126
        Me.lblNONTAXABLE_AMOUNT.Text = "0.00"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(26, 131)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(122, 23)
        Me.dtpDATE.TabIndex = 92
        Me.dtpDATE.Visible = False
        '
        'lblOUTPUT_TAX_RATE
        '
        Me.lblOUTPUT_TAX_RATE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_RATE.Location = New System.Drawing.Point(99, 141)
        Me.lblOUTPUT_TAX_RATE.Name = "lblOUTPUT_TAX_RATE"
        Me.lblOUTPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_RATE.TabIndex = 124
        Me.lblOUTPUT_TAX_RATE.Text = "0"
        Me.lblOUTPUT_TAX_RATE.Visible = False
        '
        'lblBALANCE_DUE
        '
        Me.lblBALANCE_DUE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBALANCE_DUE.BackColor = System.Drawing.Color.Transparent
        Me.lblBALANCE_DUE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBALANCE_DUE.ForeColor = System.Drawing.Color.Blue
        Me.lblBALANCE_DUE.Location = New System.Drawing.Point(640, 66)
        Me.lblBALANCE_DUE.Name = "lblBALANCE_DUE"
        Me.lblBALANCE_DUE.Size = New System.Drawing.Size(69, 18)
        Me.lblBALANCE_DUE.TabIndex = 123
        Me.lblBALANCE_DUE.Text = "0.00"
        Me.lblBALANCE_DUE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblBALANCE_DUE.Visible = False
        '
        'lbxPaymentApplied
        '
        Me.lbxPaymentApplied.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxPaymentApplied.BackColor = System.Drawing.Color.Transparent
        Me.lbxPaymentApplied.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbxPaymentApplied.ForeColor = System.Drawing.Color.Blue
        Me.lbxPaymentApplied.Location = New System.Drawing.Point(272, 90)
        Me.lbxPaymentApplied.Name = "lbxPaymentApplied"
        Me.lbxPaymentApplied.Size = New System.Drawing.Size(127, 20)
        Me.lbxPaymentApplied.TabIndex = 122
        Me.lbxPaymentApplied.Text = "0.00"
        Me.lbxPaymentApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lbxPaymentApplied.Visible = False
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel6.Text = "       "
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel5.Text = "       "
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel4.Text = "       "
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel3.Text = "       "
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel2.Text = "       "
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel1.Text = "       "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(26, 26)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripLabel3, Me.tsPrint, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.ToolStripLabel5, Me.ToolStripButton3, Me.ToolStripLabel6, Me.tsApplyCredits, Me.ToolStripLabel8, Me.tsClose, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.ShowItemToolTips = False
        Me.ToolStrip1.Size = New System.Drawing.Size(1380, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 93
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
        'tsDiscard
        '
        Me.tsDiscard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDiscard.Image = CType(resources.GetObject("tsDiscard.Image"), System.Drawing.Image)
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(60, 22)
        Me.tsDiscard.Text = "Discard"
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
        'tsPrint
        '
        Me.tsPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsPrint.Image = CType(resources.GetObject("tsPrint.Image"), System.Drawing.Image)
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(42, 22)
        Me.tsPrint.Text = "Print"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewToolStripMenuItem, Me.SelectPrintPageToolStripMenuItem})
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(13, 22)
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'SelectPrintPageToolStripMenuItem
        '
        Me.SelectPrintPageToolStripMenuItem.Name = "SelectPrintPageToolStripMenuItem"
        Me.SelectPrintPageToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.SelectPrintPageToolStripMenuItem.Text = "Select Print Page"
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
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(58, 22)
        Me.ToolStripButton3.Text = "Journal"
        '
        'tsApplyCredits
        '
        Me.tsApplyCredits.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsApplyCredits.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToCreditMemoToolStripMenuItem})
        Me.tsApplyCredits.Image = CType(resources.GetObject("tsApplyCredits.Image"), System.Drawing.Image)
        Me.tsApplyCredits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsApplyCredits.Name = "tsApplyCredits"
        Me.tsApplyCredits.Size = New System.Drawing.Size(108, 22)
        Me.tsApplyCredits.Text = "Apply Credits"
        '
        'ToCreditMemoToolStripMenuItem
        '
        Me.ToCreditMemoToolStripMenuItem.Name = "ToCreditMemoToolStripMenuItem"
        Me.ToCreditMemoToolStripMenuItem.Size = New System.Drawing.Size(179, 22)
        Me.ToCreditMemoToolStripMenuItem.Text = "To Credit Memo"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel8.Text = "       "
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
        'tsDelete
        '
        Me.tsDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDelete.Image = CType(resources.GetObject("tsDelete.Image"), System.Drawing.Image)
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(54, 22)
        Me.tsDelete.Text = "Delete"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripLabel7.Text = "       "
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripButton1.Text = "Logs"
        '
        'lblOUTPUT_TAX_VAT_METHOD
        '
        Me.lblOUTPUT_TAX_VAT_METHOD.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(99, 79)
        Me.lblOUTPUT_TAX_VAT_METHOD.Name = "lblOUTPUT_TAX_VAT_METHOD"
        Me.lblOUTPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(48, 25)
        Me.lblOUTPUT_TAX_VAT_METHOD.TabIndex = 119
        Me.lblOUTPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblOUTPUT_TAX_VAT_METHOD.Visible = False
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(154, 102)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOTES.Multiline = True
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(0, 24)
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
        Me.cmbOUTPUT_TAX_ID.Location = New System.Drawing.Point(154, 75)
        Me.cmbOUTPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbOUTPUT_TAX_ID.Name = "cmbOUTPUT_TAX_ID"
        Me.cmbOUTPUT_TAX_ID.Size = New System.Drawing.Size(82, 24)
        Me.cmbOUTPUT_TAX_ID.TabIndex = 97
        Me.cmbOUTPUT_TAX_ID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.xlblSalesRep)
        Me.Panel1.Controls.Add(Me.xxlblSalesman)
        Me.Panel1.Controls.Add(Me.dgvProductItem)
        Me.Panel1.Controls.Add(Me.tsITEM_MENU)
        Me.Panel1.Location = New System.Drawing.Point(513, 336)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(717, 223)
        Me.Panel1.TabIndex = 129
        '
        'xlblSalesRep
        '
        Me.xlblSalesRep.BackColor = System.Drawing.Color.Navy
        Me.xlblSalesRep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblSalesRep.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblSalesRep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblSalesRep.Location = New System.Drawing.Point(407, 26)
        Me.xlblSalesRep.Name = "xlblSalesRep"
        Me.xlblSalesRep.Size = New System.Drawing.Size(304, 25)
        Me.xlblSalesRep.TabIndex = 178
        Me.xlblSalesRep.Text = "SELLER"
        '
        'xxlblSalesman
        '
        Me.xxlblSalesman.AutoSize = True
        Me.xxlblSalesman.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxlblSalesman.Location = New System.Drawing.Point(409, 12)
        Me.xxlblSalesman.Name = "xxlblSalesman"
        Me.xxlblSalesman.Size = New System.Drawing.Size(84, 14)
        Me.xxlblSalesman.TabIndex = 179
        Me.xxlblSalesman.Text = "SALES MAN"
        '
        'tsITEM_MENU
        '
        Me.tsITEM_MENU.AutoSize = False
        Me.tsITEM_MENU.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsITEM_MENU.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.tsITEM_MENU.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripSeparator3, Me.tsEditItem, Me.ToolStripSeparator1, Me.tsRemoveItem, Me.tsTextFind, Me.tsCOUNT, Me.ToolStripLabel9, Me.ToolStripSeparator2, Me.ToolStripLabel10, Me.tsUP, Me.tsDOWN})
        Me.tsITEM_MENU.Location = New System.Drawing.Point(0, 0)
        Me.tsITEM_MENU.Name = "tsITEM_MENU"
        Me.tsITEM_MENU.Size = New System.Drawing.Size(715, 55)
        Me.tsITEM_MENU.TabIndex = 6
        Me.tsITEM_MENU.Text = "ToolStrip2"
        '
        'tsAddItem
        '
        Me.tsAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAddItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsAddItem.Image = CType(resources.GetObject("tsAddItem.Image"), System.Drawing.Image)
        Me.tsAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddItem.Name = "tsAddItem"
        Me.tsAddItem.Size = New System.Drawing.Size(44, 52)
        Me.tsAddItem.Text = " ADD "
        Me.tsAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 55)
        '
        'tsEditItem
        '
        Me.tsEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsEditItem.Image = CType(resources.GetObject("tsEditItem.Image"), System.Drawing.Image)
        Me.tsEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditItem.Name = "tsEditItem"
        Me.tsEditItem.Size = New System.Drawing.Size(44, 52)
        Me.tsEditItem.Text = "EDIT"
        Me.tsEditItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'tsRemoveItem
        '
        Me.tsRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRemoveItem.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsRemoveItem.Image = CType(resources.GetObject("tsRemoveItem.Image"), System.Drawing.Image)
        Me.tsRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemoveItem.Name = "tsRemoveItem"
        Me.tsRemoveItem.Size = New System.Drawing.Size(44, 52)
        Me.tsRemoveItem.Text = "REMOVE"
        Me.tsRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsTextFind
        '
        Me.tsTextFind.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.tsTextFind.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTextFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTextFind.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsTextFind.Name = "tsTextFind"
        Me.tsTextFind.Size = New System.Drawing.Size(200, 55)
        Me.tsTextFind.Visible = False
        '
        'tsCOUNT
        '
        Me.tsCOUNT.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsCOUNT.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsCOUNT.Name = "tsCOUNT"
        Me.tsCOUNT.Size = New System.Drawing.Size(17, 52)
        Me.tsCOUNT.Text = "0"
        Me.tsCOUNT.Visible = False
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(66, 52)
        Me.ToolStripLabel9.Text = "COUNT :"
        Me.ToolStripLabel9.Visible = False
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(44, 52)
        Me.ToolStripLabel10.Text = "         "
        '
        'tsUP
        '
        Me.tsUP.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsUP.Image = CType(resources.GetObject("tsUP.Image"), System.Drawing.Image)
        Me.tsUP.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUP.Name = "tsUP"
        Me.tsUP.Size = New System.Drawing.Size(44, 52)
        Me.tsUP.Text = "SELECT UP"
        Me.tsUP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsUP.ToolTipText = " UP "
        '
        'tsDOWN
        '
        Me.tsDOWN.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsDOWN.Image = CType(resources.GetObject("tsDOWN.Image"), System.Drawing.Image)
        Me.tsDOWN.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDOWN.Name = "tsDOWN"
        Me.tsDOWN.Size = New System.Drawing.Size(44, 52)
        Me.tsDOWN.Text = "SELECT DOWN"
        Me.tsDOWN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'xlblAcctNo
        '
        Me.xlblAcctNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblAcctNo.BackColor = System.Drawing.Color.Black
        Me.xlblAcctNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblAcctNo.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblAcctNo.ForeColor = System.Drawing.Color.White
        Me.xlblAcctNo.Location = New System.Drawing.Point(856, 217)
        Me.xlblAcctNo.Name = "xlblAcctNo"
        Me.xlblAcctNo.Size = New System.Drawing.Size(188, 26)
        Me.xlblAcctNo.TabIndex = 166
        Me.xlblAcctNo.Text = "0000000000000"
        Me.xlblAcctNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xlblAcctnoTitle
        '
        Me.xlblAcctnoTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblAcctnoTitle.BackColor = System.Drawing.Color.Black
        Me.xlblAcctnoTitle.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblAcctnoTitle.ForeColor = System.Drawing.Color.White
        Me.xlblAcctnoTitle.Location = New System.Drawing.Point(801, 218)
        Me.xlblAcctnoTitle.Name = "xlblAcctnoTitle"
        Me.xlblAcctnoTitle.Size = New System.Drawing.Size(58, 21)
        Me.xlblAcctnoTitle.TabIndex = 165
        Me.xlblAcctnoTitle.Text = " NO."
        '
        'lblCODE
        '
        Me.lblCODE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCODE.BackColor = System.Drawing.Color.Black
        Me.lblCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCODE.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCODE.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCODE.Location = New System.Drawing.Point(513, 244)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(144, 42)
        Me.lblCODE.TabIndex = 159
        Me.lblCODE.Text = "9999999999"
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xlblCustomer_Name
        '
        Me.xlblCustomer_Name.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblCustomer_Name.BackColor = System.Drawing.Color.Black
        Me.xlblCustomer_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCustomer_Name.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold)
        Me.xlblCustomer_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xlblCustomer_Name.Location = New System.Drawing.Point(658, 244)
        Me.xlblCustomer_Name.Name = "xlblCustomer_Name"
        Me.xlblCustomer_Name.Size = New System.Drawing.Size(386, 42)
        Me.xlblCustomer_Name.TabIndex = 164
        Me.xlblCustomer_Name.Text = "JUAN DELA CRUZ"
        Me.xlblCustomer_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xlblCustomerTItle
        '
        Me.xlblCustomerTItle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblCustomerTItle.BackColor = System.Drawing.Color.Black
        Me.xlblCustomerTItle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCustomerTItle.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCustomerTItle.ForeColor = System.Drawing.Color.White
        Me.xlblCustomerTItle.Location = New System.Drawing.Point(658, 216)
        Me.xlblCustomerTItle.Name = "xlblCustomerTItle"
        Me.xlblCustomerTItle.Size = New System.Drawing.Size(386, 28)
        Me.xlblCustomerTItle.TabIndex = 157
        Me.xlblCustomerTItle.Text = "BUYER NAME"
        '
        'xlblTax
        '
        Me.xlblTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblTax.BackColor = System.Drawing.Color.Black
        Me.xlblTax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTax.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblTax.ForeColor = System.Drawing.Color.White
        Me.xlblTax.Location = New System.Drawing.Point(1045, 216)
        Me.xlblTax.Name = "xlblTax"
        Me.xlblTax.Size = New System.Drawing.Size(184, 28)
        Me.xlblTax.TabIndex = 161
        Me.xlblTax.Text = "TAX LABEL"
        Me.xlblTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblCODE_TITLE
        '
        Me.xlblCODE_TITLE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblCODE_TITLE.BackColor = System.Drawing.Color.Black
        Me.xlblCODE_TITLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCODE_TITLE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCODE_TITLE.ForeColor = System.Drawing.Color.White
        Me.xlblCODE_TITLE.Location = New System.Drawing.Point(513, 216)
        Me.xlblCODE_TITLE.Name = "xlblCODE_TITLE"
        Me.xlblCODE_TITLE.Size = New System.Drawing.Size(144, 28)
        Me.xlblCODE_TITLE.TabIndex = 158
        Me.xlblCODE_TITLE.Text = "ENTRY NO."
        '
        'lblOUTPUT_TAX_AMOUNT
        '
        Me.lblOUTPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Black
        Me.lblOUTPUT_TAX_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_AMOUNT.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOUTPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblOUTPUT_TAX_AMOUNT.Location = New System.Drawing.Point(1045, 244)
        Me.lblOUTPUT_TAX_AMOUNT.Name = "lblOUTPUT_TAX_AMOUNT"
        Me.lblOUTPUT_TAX_AMOUNT.Size = New System.Drawing.Size(184, 42)
        Me.lblOUTPUT_TAX_AMOUNT.TabIndex = 162
        Me.lblOUTPUT_TAX_AMOUNT.Text = "99,999.99"
        Me.lblOUTPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblTOTAL
        '
        Me.xlblTOTAL.AutoSize = True
        Me.xlblTOTAL.BackColor = System.Drawing.Color.Black
        Me.xlblTOTAL.Font = New System.Drawing.Font("Verdana", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblTOTAL.ForeColor = System.Drawing.Color.Lime
        Me.xlblTOTAL.Location = New System.Drawing.Point(662, 289)
        Me.xlblTOTAL.Name = "xlblTOTAL"
        Me.xlblTOTAL.Size = New System.Drawing.Size(182, 45)
        Me.xlblTOTAL.TabIndex = 160
        Me.xlblTOTAL.Text = "TOTAL :"
        Me.xlblTOTAL.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Black
        Me.lblAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAMOUNT.Font = New System.Drawing.Font("Verdana", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Lime
        Me.lblAMOUNT.Location = New System.Drawing.Point(513, 286)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(717, 52)
        Me.lblAMOUNT.TabIndex = 163
        Me.lblAMOUNT.Text = "9,999,999.99"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tslblCONNECT})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 659)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1237, 19)
        Me.StatusStrip1.TabIndex = 167
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(67, 14)
        Me.ToolStripStatusLabel1.Text = "CONNECT :"
        '
        'tslblCONNECT
        '
        Me.tslblCONNECT.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tslblCONNECT.Name = "tslblCONNECT"
        Me.tslblCONNECT.Size = New System.Drawing.Size(128, 14)
        Me.tslblCONNECT.Text = "ToolStripStatusLabel2"
        '
        'FLP_TABLE
        '
        Me.FLP_TABLE.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FLP_TABLE.AutoScroll = True
        Me.FLP_TABLE.BackColor = System.Drawing.Color.White
        Me.FLP_TABLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FLP_TABLE.Location = New System.Drawing.Point(4, 66)
        Me.FLP_TABLE.Name = "FLP_TABLE"
        Me.FLP_TABLE.Size = New System.Drawing.Size(505, 592)
        Me.FLP_TABLE.TabIndex = 172
        '
        'pnlTOP
        '
        Me.pnlTOP.AutoScroll = True
        Me.pnlTOP.BackColor = System.Drawing.Color.Transparent
        Me.pnlTOP.Controls.Add(Me.FlowLayoutPanel1)
        Me.pnlTOP.Location = New System.Drawing.Point(122, -1)
        Me.pnlTOP.Name = "pnlTOP"
        Me.pnlTOP.Size = New System.Drawing.Size(386, 64)
        Me.pnlTOP.TabIndex = 173
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.rbDINE_IN)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbTAKE_OUT)
        Me.FlowLayoutPanel1.Controls.Add(Me.rbDELIVERY)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(386, 64)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'rbDINE_IN
        '
        Me.rbDINE_IN.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbDINE_IN.BackColor = System.Drawing.Color.DimGray
        Me.rbDINE_IN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbDINE_IN.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDINE_IN.ForeColor = System.Drawing.Color.White
        Me.rbDINE_IN.Location = New System.Drawing.Point(3, 3)
        Me.rbDINE_IN.Name = "rbDINE_IN"
        Me.rbDINE_IN.Size = New System.Drawing.Size(122, 56)
        Me.rbDINE_IN.TabIndex = 0
        Me.rbDINE_IN.TabStop = True
        Me.rbDINE_IN.Text = "DINE IN"
        Me.rbDINE_IN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbDINE_IN.UseVisualStyleBackColor = False
        '
        'rbTAKE_OUT
        '
        Me.rbTAKE_OUT.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbTAKE_OUT.BackColor = System.Drawing.Color.Green
        Me.rbTAKE_OUT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbTAKE_OUT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTAKE_OUT.ForeColor = System.Drawing.Color.White
        Me.rbTAKE_OUT.Location = New System.Drawing.Point(131, 3)
        Me.rbTAKE_OUT.Name = "rbTAKE_OUT"
        Me.rbTAKE_OUT.Size = New System.Drawing.Size(122, 56)
        Me.rbTAKE_OUT.TabIndex = 1
        Me.rbTAKE_OUT.TabStop = True
        Me.rbTAKE_OUT.Text = "TAKE OUT"
        Me.rbTAKE_OUT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbTAKE_OUT.UseVisualStyleBackColor = False
        '
        'rbDELIVERY
        '
        Me.rbDELIVERY.Appearance = System.Windows.Forms.Appearance.Button
        Me.rbDELIVERY.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.rbDELIVERY.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rbDELIVERY.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDELIVERY.ForeColor = System.Drawing.Color.White
        Me.rbDELIVERY.Location = New System.Drawing.Point(259, 3)
        Me.rbDELIVERY.Name = "rbDELIVERY"
        Me.rbDELIVERY.Size = New System.Drawing.Size(122, 56)
        Me.rbDELIVERY.TabIndex = 2
        Me.rbDELIVERY.TabStop = True
        Me.rbDELIVERY.Text = "DELIVERY"
        Me.rbDELIVERY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.rbDELIVERY.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'pnlTOP2
        '
        Me.pnlTOP2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlTOP2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlTOP2.Controls.Add(Me.FlowLayoutPanel2)
        Me.pnlTOP2.Location = New System.Drawing.Point(514, 68)
        Me.pnlTOP2.Name = "pnlTOP2"
        Me.pnlTOP2.Size = New System.Drawing.Size(716, 146)
        Me.pnlTOP2.TabIndex = 174
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlOP)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlOS)
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel2.Controls.Add(Me.pcLOGO)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(714, 144)
        Me.FlowLayoutPanel2.TabIndex = 0
        '
        'pnlOP
        '
        Me.pnlOP.Controls.Add(Me.btnNEWORDER)
        Me.pnlOP.Controls.Add(Me.dgvSalesOrder)
        Me.pnlOP.Controls.Add(Me.btnPODERDER_DETAILS)
        Me.pnlOP.Location = New System.Drawing.Point(3, 3)
        Me.pnlOP.Name = "pnlOP"
        Me.pnlOP.Size = New System.Drawing.Size(350, 139)
        Me.pnlOP.TabIndex = 0
        '
        'btnNEWORDER
        '
        Me.btnNEWORDER.BackColor = System.Drawing.Color.White
        Me.btnNEWORDER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNEWORDER.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNEWORDER.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNEWORDER.Image = CType(resources.GetObject("btnNEWORDER.Image"), System.Drawing.Image)
        Me.btnNEWORDER.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNEWORDER.Location = New System.Drawing.Point(3, 1)
        Me.btnNEWORDER.Name = "btnNEWORDER"
        Me.btnNEWORDER.Size = New System.Drawing.Size(82, 72)
        Me.btnNEWORDER.TabIndex = 5
        Me.btnNEWORDER.Text = "NEW PROCESS"
        Me.btnNEWORDER.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNEWORDER.UseVisualStyleBackColor = False
        '
        'dgvSalesOrder
        '
        Me.dgvSalesOrder.AllowUserToAddRows = False
        Me.dgvSalesOrder.AllowUserToDeleteRows = False
        Me.dgvSalesOrder.AllowUserToResizeColumns = False
        Me.dgvSalesOrder.AllowUserToResizeRows = False
        Me.dgvSalesOrder.BackgroundColor = System.Drawing.Color.AntiqueWhite
        Me.dgvSalesOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesOrder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSalesOrder.Location = New System.Drawing.Point(86, 0)
        Me.dgvSalesOrder.MultiSelect = False
        Me.dgvSalesOrder.Name = "dgvSalesOrder"
        Me.dgvSalesOrder.ReadOnly = True
        Me.dgvSalesOrder.RowHeadersVisible = False
        Me.dgvSalesOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSalesOrder.Size = New System.Drawing.Size(261, 136)
        Me.dgvSalesOrder.TabIndex = 0
        '
        'btnPODERDER_DETAILS
        '
        Me.btnPODERDER_DETAILS.BackColor = System.Drawing.Color.White
        Me.btnPODERDER_DETAILS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPODERDER_DETAILS.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPODERDER_DETAILS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnPODERDER_DETAILS.Image = CType(resources.GetObject("btnPODERDER_DETAILS.Image"), System.Drawing.Image)
        Me.btnPODERDER_DETAILS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPODERDER_DETAILS.Location = New System.Drawing.Point(3, 79)
        Me.btnPODERDER_DETAILS.Name = "btnPODERDER_DETAILS"
        Me.btnPODERDER_DETAILS.Size = New System.Drawing.Size(82, 57)
        Me.btnPODERDER_DETAILS.TabIndex = 7
        Me.btnPODERDER_DETAILS.Text = "EDIT"
        Me.btnPODERDER_DETAILS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPODERDER_DETAILS.UseVisualStyleBackColor = False
        '
        'pnlOS
        '
        Me.pnlOS.Controls.Add(Me.btnVIEW_DETAILS)
        Me.pnlOS.Controls.Add(Me.btnRECEIVED_ORDER)
        Me.pnlOS.Controls.Add(Me.dgvInvoice)
        Me.pnlOS.Location = New System.Drawing.Point(359, 3)
        Me.pnlOS.Name = "pnlOS"
        Me.pnlOS.Size = New System.Drawing.Size(350, 139)
        Me.pnlOS.TabIndex = 1
        '
        'btnVIEW_DETAILS
        '
        Me.btnVIEW_DETAILS.BackColor = System.Drawing.Color.White
        Me.btnVIEW_DETAILS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVIEW_DETAILS.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVIEW_DETAILS.ForeColor = System.Drawing.Color.Black
        Me.btnVIEW_DETAILS.Image = CType(resources.GetObject("btnVIEW_DETAILS.Image"), System.Drawing.Image)
        Me.btnVIEW_DETAILS.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnVIEW_DETAILS.Location = New System.Drawing.Point(3, 79)
        Me.btnVIEW_DETAILS.Name = "btnVIEW_DETAILS"
        Me.btnVIEW_DETAILS.Size = New System.Drawing.Size(85, 57)
        Me.btnVIEW_DETAILS.TabIndex = 8
        Me.btnVIEW_DETAILS.Text = "EDIT SRV"
        Me.btnVIEW_DETAILS.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnVIEW_DETAILS.UseVisualStyleBackColor = False
        '
        'btnRECEIVED_ORDER
        '
        Me.btnRECEIVED_ORDER.BackColor = System.Drawing.Color.White
        Me.btnRECEIVED_ORDER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRECEIVED_ORDER.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRECEIVED_ORDER.ForeColor = System.Drawing.Color.Black
        Me.btnRECEIVED_ORDER.Image = CType(resources.GetObject("btnRECEIVED_ORDER.Image"), System.Drawing.Image)
        Me.btnRECEIVED_ORDER.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRECEIVED_ORDER.Location = New System.Drawing.Point(3, 3)
        Me.btnRECEIVED_ORDER.Name = "btnRECEIVED_ORDER"
        Me.btnRECEIVED_ORDER.Size = New System.Drawing.Size(85, 70)
        Me.btnRECEIVED_ORDER.TabIndex = 6
        Me.btnRECEIVED_ORDER.Text = "NEW SERVED"
        Me.btnRECEIVED_ORDER.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRECEIVED_ORDER.UseVisualStyleBackColor = False
        '
        'dgvInvoice
        '
        Me.dgvInvoice.AllowUserToAddRows = False
        Me.dgvInvoice.AllowUserToDeleteRows = False
        Me.dgvInvoice.AllowUserToResizeColumns = False
        Me.dgvInvoice.AllowUserToResizeRows = False
        Me.dgvInvoice.BackgroundColor = System.Drawing.Color.White
        Me.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvInvoice.Location = New System.Drawing.Point(90, 3)
        Me.dgvInvoice.Name = "dgvInvoice"
        Me.dgvInvoice.RowHeadersVisible = False
        Me.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoice.Size = New System.Drawing.Size(257, 133)
        Me.dgvInvoice.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnPRINTBILL_Fake)
        Me.Panel2.Controls.Add(Me.btnCreatePayment_Fake)
        Me.Panel2.Location = New System.Drawing.Point(3, 148)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(150, 145)
        Me.Panel2.TabIndex = 14
        '
        'btnPRINTBILL_Fake
        '
        Me.btnPRINTBILL_Fake.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnPRINTBILL_Fake.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPRINTBILL_Fake.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINTBILL_Fake.ForeColor = System.Drawing.Color.White
        Me.btnPRINTBILL_Fake.Image = CType(resources.GetObject("btnPRINTBILL_Fake.Image"), System.Drawing.Image)
        Me.btnPRINTBILL_Fake.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPRINTBILL_Fake.Location = New System.Drawing.Point(3, 2)
        Me.btnPRINTBILL_Fake.Name = "btnPRINTBILL_Fake"
        Me.btnPRINTBILL_Fake.Size = New System.Drawing.Size(144, 66)
        Me.btnPRINTBILL_Fake.TabIndex = 12
        Me.btnPRINTBILL_Fake.Text = "PRINT BILL"
        Me.btnPRINTBILL_Fake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPRINTBILL_Fake.UseVisualStyleBackColor = False
        Me.btnPRINTBILL_Fake.Visible = False
        '
        'btnCreatePayment_Fake
        '
        Me.btnCreatePayment_Fake.BackColor = System.Drawing.Color.Crimson
        Me.btnCreatePayment_Fake.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreatePayment_Fake.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreatePayment_Fake.ForeColor = System.Drawing.Color.White
        Me.btnCreatePayment_Fake.Image = CType(resources.GetObject("btnCreatePayment_Fake.Image"), System.Drawing.Image)
        Me.btnCreatePayment_Fake.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreatePayment_Fake.Location = New System.Drawing.Point(3, 72)
        Me.btnCreatePayment_Fake.Name = "btnCreatePayment_Fake"
        Me.btnCreatePayment_Fake.Size = New System.Drawing.Size(144, 66)
        Me.btnCreatePayment_Fake.TabIndex = 13
        Me.btnCreatePayment_Fake.Text = "PAYMENT"
        Me.btnCreatePayment_Fake.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreatePayment_Fake.UseVisualStyleBackColor = False
        Me.btnCreatePayment_Fake.Visible = False
        '
        'pcLOGO
        '
        Me.pcLOGO.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.pcLOGO.Location = New System.Drawing.Point(159, 148)
        Me.pcLOGO.Name = "pcLOGO"
        Me.pcLOGO.Size = New System.Drawing.Size(188, 145)
        Me.pcLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcLOGO.TabIndex = 15
        Me.pcLOGO.TabStop = False
        '
        'xlblTABLE_NO
        '
        Me.xlblTABLE_NO.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblTABLE_NO.BackColor = System.Drawing.Color.Black
        Me.xlblTABLE_NO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTABLE_NO.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.xlblTABLE_NO.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.xlblTABLE_NO.Location = New System.Drawing.Point(514, 312)
        Me.xlblTABLE_NO.Name = "xlblTABLE_NO"
        Me.xlblTABLE_NO.Size = New System.Drawing.Size(144, 25)
        Me.xlblTABLE_NO.TabIndex = 175
        Me.xlblTABLE_NO.Text = "SSS"
        Me.xlblTABLE_NO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlOther
        '
        Me.pnlOther.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOther.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlOther.Controls.Add(Me.txtPO_NUMBER)
        Me.pnlOther.Controls.Add(Me.dtpDISCOUNT_DATE)
        Me.pnlOther.Controls.Add(Me.cmbACCOUNTS_RECEIVABLE_ID)
        Me.pnlOther.Controls.Add(Me.btnTAX)
        Me.pnlOther.Controls.Add(Me.btnSALESMAN)
        Me.pnlOther.Controls.Add(Me.btnCUSTOMER)
        Me.pnlOther.Controls.Add(Me.btnDELETE)
        Me.pnlOther.Controls.Add(Me.btnCANCEL)
        Me.pnlOther.Controls.Add(Me.btnSAVE)
        Me.pnlOther.Controls.Add(Me.lblOUTPUT_TAX_ACCOUNT_ID)
        Me.pnlOther.Controls.Add(Me.lblBALANCE_DUE)
        Me.pnlOther.Controls.Add(Me.dtpDUE_DATE)
        Me.pnlOther.Controls.Add(Me.lbxBalance)
        Me.pnlOther.Location = New System.Drawing.Point(513, 561)
        Me.pnlOther.Name = "pnlOther"
        Me.pnlOther.Size = New System.Drawing.Size(717, 99)
        Me.pnlOther.TabIndex = 176
        '
        'txtPO_NUMBER
        '
        Me.txtPO_NUMBER.Location = New System.Drawing.Point(752, 12)
        Me.txtPO_NUMBER.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPO_NUMBER.Name = "txtPO_NUMBER"
        Me.txtPO_NUMBER.Size = New System.Drawing.Size(66, 23)
        Me.txtPO_NUMBER.TabIndex = 135
        Me.txtPO_NUMBER.Visible = False
        '
        'dtpDISCOUNT_DATE
        '
        Me.dtpDISCOUNT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDISCOUNT_DATE.Location = New System.Drawing.Point(752, 55)
        Me.dtpDISCOUNT_DATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDISCOUNT_DATE.Name = "dtpDISCOUNT_DATE"
        Me.dtpDISCOUNT_DATE.ShowCheckBox = True
        Me.dtpDISCOUNT_DATE.Size = New System.Drawing.Size(66, 23)
        Me.dtpDISCOUNT_DATE.TabIndex = 134
        Me.dtpDISCOUNT_DATE.Visible = False
        '
        'cmbACCOUNTS_RECEIVABLE_ID
        '
        Me.cmbACCOUNTS_RECEIVABLE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbACCOUNTS_RECEIVABLE_ID.FormattingEnabled = True
        Me.cmbACCOUNTS_RECEIVABLE_ID.Location = New System.Drawing.Point(720, 11)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Name = "cmbACCOUNTS_RECEIVABLE_ID"
        Me.cmbACCOUNTS_RECEIVABLE_ID.Size = New System.Drawing.Size(101, 24)
        Me.cmbACCOUNTS_RECEIVABLE_ID.TabIndex = 133
        Me.cmbACCOUNTS_RECEIVABLE_ID.Visible = False
        '
        'btnTAX
        '
        Me.btnTAX.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnTAX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTAX.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTAX.ForeColor = System.Drawing.Color.Blue
        Me.btnTAX.Image = CType(resources.GetObject("btnTAX.Image"), System.Drawing.Image)
        Me.btnTAX.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnTAX.Location = New System.Drawing.Point(615, 3)
        Me.btnTAX.Name = "btnTAX"
        Me.btnTAX.Size = New System.Drawing.Size(95, 91)
        Me.btnTAX.TabIndex = 132
        Me.btnTAX.Text = "TAX"
        Me.btnTAX.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTAX.UseVisualStyleBackColor = False
        '
        'btnSALESMAN
        '
        Me.btnSALESMAN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSALESMAN.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSALESMAN.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSALESMAN.ForeColor = System.Drawing.Color.Blue
        Me.btnSALESMAN.Image = CType(resources.GetObject("btnSALESMAN.Image"), System.Drawing.Image)
        Me.btnSALESMAN.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSALESMAN.Location = New System.Drawing.Point(514, 3)
        Me.btnSALESMAN.Name = "btnSALESMAN"
        Me.btnSALESMAN.Size = New System.Drawing.Size(95, 91)
        Me.btnSALESMAN.TabIndex = 131
        Me.btnSALESMAN.Text = "SALESMAN"
        Me.btnSALESMAN.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSALESMAN.UseVisualStyleBackColor = False
        '
        'btnCUSTOMER
        '
        Me.btnCUSTOMER.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCUSTOMER.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCUSTOMER.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCUSTOMER.ForeColor = System.Drawing.Color.Blue
        Me.btnCUSTOMER.Image = CType(resources.GetObject("btnCUSTOMER.Image"), System.Drawing.Image)
        Me.btnCUSTOMER.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCUSTOMER.Location = New System.Drawing.Point(412, 3)
        Me.btnCUSTOMER.Name = "btnCUSTOMER"
        Me.btnCUSTOMER.Size = New System.Drawing.Size(95, 91)
        Me.btnCUSTOMER.TabIndex = 130
        Me.btnCUSTOMER.Text = "CUSTOMER"
        Me.btnCUSTOMER.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCUSTOMER.UseVisualStyleBackColor = False
        '
        'btnDELETE
        '
        Me.btnDELETE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDELETE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDELETE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDELETE.ForeColor = System.Drawing.Color.Blue
        Me.btnDELETE.Image = CType(resources.GetObject("btnDELETE.Image"), System.Drawing.Image)
        Me.btnDELETE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDELETE.Location = New System.Drawing.Point(204, 3)
        Me.btnDELETE.Name = "btnDELETE"
        Me.btnDELETE.Size = New System.Drawing.Size(95, 91)
        Me.btnDELETE.TabIndex = 128
        Me.btnDELETE.Text = "DELETE"
        Me.btnDELETE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDELETE.UseVisualStyleBackColor = False
        '
        'btnCANCEL
        '
        Me.btnCANCEL.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCANCEL.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCANCEL.ForeColor = System.Drawing.Color.Blue
        Me.btnCANCEL.Image = CType(resources.GetObject("btnCANCEL.Image"), System.Drawing.Image)
        Me.btnCANCEL.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCANCEL.Location = New System.Drawing.Point(103, 3)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(95, 91)
        Me.btnCANCEL.TabIndex = 127
        Me.btnCANCEL.Text = "CANCEL"
        Me.btnCANCEL.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCANCEL.UseVisualStyleBackColor = False
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSAVE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.Blue
        Me.btnSAVE.Image = CType(resources.GetObject("btnSAVE.Image"), System.Drawing.Image)
        Me.btnSAVE.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSAVE.Location = New System.Drawing.Point(2, 3)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(95, 91)
        Me.btnSAVE.TabIndex = 126
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'dtpDUE_DATE
        '
        Me.dtpDUE_DATE.Location = New System.Drawing.Point(754, 37)
        Me.dtpDUE_DATE.Name = "dtpDUE_DATE"
        Me.dtpDUE_DATE.Size = New System.Drawing.Size(64, 23)
        Me.dtpDUE_DATE.TabIndex = 13
        Me.dtpDUE_DATE.Visible = False
        '
        'lbxBalance
        '
        Me.lbxBalance.AutoSize = True
        Me.lbxBalance.Location = New System.Drawing.Point(736, 14)
        Me.lbxBalance.Name = "lbxBalance"
        Me.lbxBalance.Size = New System.Drawing.Size(58, 16)
        Me.lbxBalance.TabIndex = 12
        Me.lbxBalance.Text = "Label11"
        Me.lbxBalance.Visible = False
        '
        'xlblTABLE_TYPE
        '
        Me.xlblTABLE_TYPE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblTABLE_TYPE.BackColor = System.Drawing.Color.Black
        Me.xlblTABLE_TYPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTABLE_TYPE.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblTABLE_TYPE.ForeColor = System.Drawing.Color.White
        Me.xlblTABLE_TYPE.Location = New System.Drawing.Point(514, 288)
        Me.xlblTABLE_TYPE.Name = "xlblTABLE_TYPE"
        Me.xlblTABLE_TYPE.Size = New System.Drawing.Size(144, 24)
        Me.xlblTABLE_TYPE.TabIndex = 179
        Me.xlblTABLE_TYPE.Text = "SSS"
        Me.xlblTABLE_TYPE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnMENU
        '
        Me.btnMENU.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnMENU.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnMENU.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMENU.ForeColor = System.Drawing.Color.White
        Me.btnMENU.Location = New System.Drawing.Point(3, 3)
        Me.btnMENU.Name = "btnMENU"
        Me.btnMENU.Size = New System.Drawing.Size(117, 55)
        Me.btnMENU.TabIndex = 180
        Me.btnMENU.Text = "BACK"
        Me.btnMENU.UseVisualStyleBackColor = False
        '
        'btnPRINTOS
        '
        Me.btnPRINTOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPRINTOS.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnPRINTOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPRINTOS.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINTOS.ForeColor = System.Drawing.Color.White
        Me.btnPRINTOS.Image = CType(resources.GetObject("btnPRINTOS.Image"), System.Drawing.Image)
        Me.btnPRINTOS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPRINTOS.Location = New System.Drawing.Point(713, -4)
        Me.btnPRINTOS.Name = "btnPRINTOS"
        Me.btnPRINTOS.Size = New System.Drawing.Size(154, 67)
        Me.btnPRINTOS.TabIndex = 181
        Me.btnPRINTOS.Text = "PRINT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SLIP"
        Me.btnPRINTOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPRINTOS.UseVisualStyleBackColor = False
        '
        'btnCreatePayment
        '
        Me.btnCreatePayment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCreatePayment.BackColor = System.Drawing.Color.Crimson
        Me.btnCreatePayment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreatePayment.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreatePayment.ForeColor = System.Drawing.Color.White
        Me.btnCreatePayment.Image = CType(resources.GetObject("btnCreatePayment.Image"), System.Drawing.Image)
        Me.btnCreatePayment.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreatePayment.Location = New System.Drawing.Point(1031, -2)
        Me.btnCreatePayment.Name = "btnCreatePayment"
        Me.btnCreatePayment.Size = New System.Drawing.Size(154, 66)
        Me.btnCreatePayment.TabIndex = 12
        Me.btnCreatePayment.Text = "PAYMENT"
        Me.btnCreatePayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreatePayment.UseVisualStyleBackColor = False
        '
        'btnPRINTBILL
        '
        Me.btnPRINTBILL.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPRINTBILL.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnPRINTBILL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPRINTBILL.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINTBILL.ForeColor = System.Drawing.Color.White
        Me.btnPRINTBILL.Image = CType(resources.GetObject("btnPRINTBILL.Image"), System.Drawing.Image)
        Me.btnPRINTBILL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPRINTBILL.Location = New System.Drawing.Point(874, -2)
        Me.btnPRINTBILL.Name = "btnPRINTBILL"
        Me.btnPRINTBILL.Size = New System.Drawing.Size(154, 66)
        Me.btnPRINTBILL.TabIndex = 11
        Me.btnPRINTBILL.Text = "PRINT " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "BILL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.btnPRINTBILL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPRINTBILL.UseVisualStyleBackColor = False
        '
        'frmPOSRestoMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1237, 678)
        Me.Controls.Add(Me.btnPRINTOS)
        Me.Controls.Add(Me.btnMENU)
        Me.Controls.Add(Me.btnCreatePayment)
        Me.Controls.Add(Me.btnPRINTBILL)
        Me.Controls.Add(Me.pnlOther)
        Me.Controls.Add(Me.pnlTOP2)
        Me.Controls.Add(Me.pnlTOP)
        Me.Controls.Add(Me.FLP_TABLE)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.xlblAcctNo)
        Me.Controls.Add(Me.xlblAcctnoTitle)
        Me.Controls.Add(Me.lblCODE)
        Me.Controls.Add(Me.xlblCustomer_Name)
        Me.Controls.Add(Me.xlblCustomerTItle)
        Me.Controls.Add(Me.xlblTax)
        Me.Controls.Add(Me.xlblCODE_TITLE)
        Me.Controls.Add(Me.lblOUTPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.xlblTOTAL)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.cmbSALES_REP_ID)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.cmbCLASS_ID)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.cmbPAYMENT_TERMS_ID)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.lblOUTPUT_TAX_RATE)
        Me.Controls.Add(Me.lbxPaymentApplied)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblOUTPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.cmbOUTPUT_TAX_ID)
        Me.Controls.Add(Me.xlblTABLE_TYPE)
        Me.Controls.Add(Me.xlblTABLE_NO)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmPOSRestoMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tsITEM_MENU.ResumeLayout(False)
        Me.tsITEM_MENU.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlTOP.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlTOP2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.pnlOP.ResumeLayout(False)
        CType(Me.dgvSalesOrder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOS.ResumeLayout(False)
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.pcLOGO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlOther.ResumeLayout(False)
        Me.pnlOther.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
    Friend WithEvents cmbSALES_REP_ID As ComboBox
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents lblOUTPUT_TAX_ACCOUNT_ID As Label
    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents cmbPAYMENT_TERMS_ID As ComboBox
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents lblOUTPUT_TAX_RATE As Label
    Friend WithEvents lblBALANCE_DUE As Label
    Friend WithEvents lbxPaymentApplied As Label
    Friend WithEvents tsApplyCredits As ToolStripDropDownButton
    Friend WithEvents ToCreditMemoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsPrint As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents lblOUTPUT_TAX_VAT_METHOD As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents cmbOUTPUT_TAX_ID As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents xlblAcctNo As Label
    Friend WithEvents xlblAcctnoTitle As Label
    Friend WithEvents lblCODE As Label
    Friend WithEvents xlblCustomer_Name As Label
    Friend WithEvents xlblCustomerTItle As Label
    Friend WithEvents xlblTax As Label
    Friend WithEvents xlblCODE_TITLE As Label
    Friend WithEvents lblOUTPUT_TAX_AMOUNT As Label
    Friend WithEvents xlblTOTAL As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents tsITEM_MENU As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents tsTextFind As ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripLabel9 As ToolStripLabel
    Friend WithEvents tsCOUNT As ToolStripLabel
    Friend WithEvents FLP_TABLE As FlowLayoutPanel
    Friend WithEvents pnlTOP As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pnlTOP2 As Panel
    Friend WithEvents dgvInvoice As DataGridView
    Friend WithEvents dgvSalesOrder As DataGridView
    Friend WithEvents xlblTABLE_NO As Label
    Friend WithEvents pnlOther As Panel
    Friend WithEvents lbxBalance As Label
    Friend WithEvents dtpDUE_DATE As DateTimePicker
    Friend WithEvents xlblSalesRep As Label
    Friend WithEvents xlblTABLE_TYPE As Label
    Friend WithEvents btnNEWORDER As Button
    Friend WithEvents btnRECEIVED_ORDER As Button
    Friend WithEvents btnVIEW_DETAILS As Button
    Friend WithEvents btnPODERDER_DETAILS As Button
    Friend WithEvents btnTAX As Button
    Friend WithEvents btnSALESMAN As Button
    Friend WithEvents btnCUSTOMER As Button
    Friend WithEvents btnDELETE As Button
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents btnSAVE As Button
    Friend WithEvents cmbACCOUNTS_RECEIVABLE_ID As ComboBox
    Friend WithEvents dtpDISCOUNT_DATE As DateTimePicker
    Friend WithEvents txtPO_NUMBER As TextBox
    Friend WithEvents btnPRINTBILL As Button
    Friend WithEvents btnCreatePayment As Button
    Friend WithEvents xxlblSalesman As Label
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents rbDINE_IN As RadioButton
    Friend WithEvents rbTAKE_OUT As RadioButton
    Friend WithEvents rbDELIVERY As RadioButton
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents pnlOP As Panel
    Friend WithEvents pnlOS As Panel
    Friend WithEvents btnMENU As Button
    Friend WithEvents btnPRINTBILL_Fake As Button
    Friend WithEvents btnCreatePayment_Fake As Button
    Friend WithEvents ToolStripLabel10 As ToolStripLabel
    Friend WithEvents tsUP As ToolStripButton
    Friend WithEvents tsDOWN As ToolStripButton
    Friend WithEvents btnPRINTOS As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents pcLOGO As PictureBox
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tslblCONNECT As ToolStripStatusLabel
End Class
