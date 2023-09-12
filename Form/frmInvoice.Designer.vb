<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvoice))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPrintPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.spJournal = New System.Windows.Forms.ToolStripSeparator()
        Me.tsJournal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsApplyCredits = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToCreditMemoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.lblOUTPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbOUTPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.lblOUTPUT_TAX_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_RATE = New System.Windows.Forms.Label()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPO_NUMBER = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDISCOUNT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpDUE_DATE = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_TERMS_ID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbSHIP_VIA_ID = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AccountLabel = New System.Windows.Forms.Label()
        Me.cmbACCOUNTS_RECEIVABLE_ID = New System.Windows.Forms.ComboBox()
        Me.cmbSALES_REP_ID = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCLASS_ID = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblBALANCE_DUE = New System.Windows.Forms.Label()
        Me.lbxPaymentApplied = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lbxBalance = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCount = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripSeparator1, Me.tsFind, Me.ToolStripLabel3, Me.tsPrint, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.spJournal, Me.tsJournal, Me.ToolStripLabel6, Me.tsApplyCredits, Me.ToolStripLabel8, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton1, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1161, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.Image = Global.Automission.My.Resources.Resources.m_save_file
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = tsSaveNew.Name
        Me.tsSaveNew.Size = New System.Drawing.Size(71, 52)
        Me.tsSaveNew.Text = "Save File"
        Me.tsSaveNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(6, 55)
        '
        'tsDiscard
        '
        Me.tsDiscard.Image = Global.Automission.My.Resources.Resources.m_refresh
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(60, 52)
        Me.tsDiscard.Text = "Refresh"
        Me.tsDiscard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'tsFind
        '
        Me.tsFind.Image = Global.Automission.My.Resources.Resources.m_search
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(65, 52)
        Me.tsFind.Text = "Find File"
        Me.tsFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(6, 55)
        '
        'tsPrint
        '
        Me.tsPrint.Image = Global.Automission.My.Resources.Resources.m_printing
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(41, 52)
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
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(13, 52)
        '
        'PreviewToolStripMenuItem
        '
        Me.PreviewToolStripMenuItem.Name = "PreviewToolStripMenuItem"
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'SelectPrintPageToolStripMenuItem
        '
        Me.SelectPrintPageToolStripMenuItem.Name = "SelectPrintPageToolStripMenuItem"
        Me.SelectPrintPageToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SelectPrintPageToolStripMenuItem.Text = "Select Print Page"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.Automission.My.Resources.Resources.m_history_link
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(57, 52)
        Me.ToolStripButton2.Text = "History"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'spJournal
        '
        Me.spJournal.Name = "spJournal"
        Me.spJournal.Size = New System.Drawing.Size(6, 55)
        '
        'tsJournal
        '
        Me.tsJournal.Image = Global.Automission.My.Resources.Resources.m_journal_doc
        Me.tsJournal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsJournal.Name = "tsJournal"
        Me.tsJournal.Size = New System.Drawing.Size(57, 52)
        Me.tsJournal.Text = "Journal"
        Me.tsJournal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(6, 55)
        '
        'tsApplyCredits
        '
        Me.tsApplyCredits.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToCreditMemoToolStripMenuItem})
        Me.tsApplyCredits.Image = Global.Automission.My.Resources.Resources.m_applied
        Me.tsApplyCredits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsApplyCredits.Name = "tsApplyCredits"
        Me.tsApplyCredits.Size = New System.Drawing.Size(107, 52)
        Me.tsApplyCredits.Text = "Apply Credits"
        Me.tsApplyCredits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToCreditMemoToolStripMenuItem
        '
        Me.ToCreditMemoToolStripMenuItem.Name = "ToCreditMemoToolStripMenuItem"
        Me.ToCreditMemoToolStripMenuItem.Size = New System.Drawing.Size(177, 22)
        Me.ToCreditMemoToolStripMenuItem.Text = "To Credit Memo"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(6, 55)
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.m_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(80, 52)
        Me.tsDelete.Text = "Delete File"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.m_logs
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(41, 52)
        Me.ToolStripButton1.Text = "Logs"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsTITLE
        '
        Me.tsTITLE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTITLE.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.tsTITLE.Image = Global.Automission.My.Resources.Resources.back_icon_set
        Me.tsTITLE.Name = "tsTITLE"
        Me.tsTITLE.Size = New System.Drawing.Size(104, 52)
        Me.tsTITLE.Text = "TITLE "
        '
        'lblOUTPUT_TAX_VAT_METHOD
        '
        Me.lblOUTPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(416, 558)
        Me.lblOUTPUT_TAX_VAT_METHOD.Name = "lblOUTPUT_TAX_VAT_METHOD"
        Me.lblOUTPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(48, 25)
        Me.lblOUTPUT_TAX_VAT_METHOD.TabIndex = 19
        Me.lblOUTPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblOUTPUT_TAX_VAT_METHOD.Visible = False
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT.Location = New System.Drawing.Point(659, 461)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(117, 18)
        Me.lblAMOUNT.TabIndex = 15
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOUTPUT_TAX_AMOUNT
        '
        Me.lblOUTPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblOUTPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblOUTPUT_TAX_AMOUNT.Location = New System.Drawing.Point(576, 461)
        Me.lblOUTPUT_TAX_AMOUNT.Name = "lblOUTPUT_TAX_AMOUNT"
        Me.lblOUTPUT_TAX_AMOUNT.Size = New System.Drawing.Size(77, 18)
        Me.lblOUTPUT_TAX_AMOUNT.TabIndex = 14
        Me.lblOUTPUT_TAX_AMOUNT.Text = "0.00"
        Me.lblOUTPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(731, 439)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 11
        Me.Label17.Text = "Total"
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(581, 439)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 16)
        Me.Label16.TabIndex = 10
        Me.Label16.Text = "Output Tax"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(581, 459)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(567, 1)
        Me.Label15.TabIndex = 9
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(61, 463)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(327, 23)
        Me.txtNOTES.TabIndex = 8
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(12, 466)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 16)
        Me.Label14.TabIndex = 7
        Me.Label14.Text = "Notes"
        '
        'cmbOUTPUT_TAX_ID
        '
        Me.cmbOUTPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOUTPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOUTPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOUTPUT_TAX_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOUTPUT_TAX_ID.FormattingEnabled = True
        Me.cmbOUTPUT_TAX_ID.Location = New System.Drawing.Point(61, 435)
        Me.cmbOUTPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbOUTPUT_TAX_ID.Name = "cmbOUTPUT_TAX_ID"
        Me.cmbOUTPUT_TAX_ID.Size = New System.Drawing.Size(163, 24)
        Me.cmbOUTPUT_TAX_ID.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(26, 435)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 16)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Tax"
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AllowUserToResizeColumns = False
        Me.dgvProductItem.AllowUserToResizeRows = False
        Me.dgvProductItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvProductItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductItem.Location = New System.Drawing.Point(3, 41)
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvProductItem.RowHeadersVisible = False
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(1124, 147)
        Me.dgvProductItem.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1124, 37)
        Me.ToolStrip2.TabIndex = 17
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAddItem
        '
        Me.tsAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAddItem.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddItem.Name = "tsAddItem"
        Me.tsAddItem.Size = New System.Drawing.Size(34, 34)
        Me.tsAddItem.Text = "&Add"
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(6, 37)
        '
        'tsEditItem
        '
        Me.tsEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditItem.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditItem.Name = "tsEditItem"
        Me.tsEditItem.Size = New System.Drawing.Size(34, 34)
        Me.tsEditItem.Text = "&Edit"
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(6, 37)
        '
        'tsRemoveItem
        '
        Me.tsRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRemoveItem.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemoveItem.Name = "tsRemoveItem"
        Me.tsRemoveItem.Size = New System.Drawing.Size(34, 34)
        Me.tsRemoveItem.Text = "&Remove"
        '
        'tsFindText
        '
        Me.tsFindText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsFindText.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsFindText.Name = "tsFindText"
        Me.tsFindText.Size = New System.Drawing.Size(228, 37)
        '
        'ToolStripLabel11
        '
        Me.ToolStripLabel11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel11.Name = "ToolStripLabel11"
        Me.ToolStripLabel11.Size = New System.Drawing.Size(34, 34)
        Me.ToolStripLabel11.Text = "Find"
        '
        'lblOUTPUT_TAX_ACCOUNT_ID
        '
        Me.lblOUTPUT_TAX_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Location = New System.Drawing.Point(472, 558)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Name = "lblOUTPUT_TAX_ACCOUNT_ID"
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.TabIndex = 18
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Visible = False
        '
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.AutoSize = True
        Me.lblTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(641, 558)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblTAXABLE_AMOUNT.TabIndex = 76
        Me.lblTAXABLE_AMOUNT.Text = "0.00"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.AutoSize = True
        Me.lblNONTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblNONTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(593, 558)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 77
        Me.lblNONTAXABLE_AMOUNT.Text = "0.00"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'lblOUTPUT_TAX_RATE
        '
        Me.lblOUTPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_RATE.Location = New System.Drawing.Point(535, 558)
        Me.lblOUTPUT_TAX_RATE.Name = "lblOUTPUT_TAX_RATE"
        Me.lblOUTPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_RATE.TabIndex = 49
        Me.lblOUTPUT_TAX_RATE.Text = "0"
        Me.lblOUTPUT_TAX_RATE.Visible = False
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(90, 72)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'txtPO_NUMBER
        '
        Me.txtPO_NUMBER.Location = New System.Drawing.Point(286, 98)
        Me.txtPO_NUMBER.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPO_NUMBER.Name = "txtPO_NUMBER"
        Me.txtPO_NUMBER.Size = New System.Drawing.Size(146, 23)
        Me.txtPO_NUMBER.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(228, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "P.O No."
        '
        'dtpDISCOUNT_DATE
        '
        Me.dtpDISCOUNT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDISCOUNT_DATE.Location = New System.Drawing.Point(90, 150)
        Me.dtpDISCOUNT_DATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDISCOUNT_DATE.Name = "dtpDISCOUNT_DATE"
        Me.dtpDISCOUNT_DATE.ShowCheckBox = True
        Me.dtpDISCOUNT_DATE.Size = New System.Drawing.Size(134, 23)
        Me.dtpDISCOUNT_DATE.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 152)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Disc. Date"
        '
        'dtpDUE_DATE
        '
        Me.dtpDUE_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDUE_DATE.Location = New System.Drawing.Point(90, 125)
        Me.dtpDUE_DATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDUE_DATE.Name = "dtpDUE_DATE"
        Me.dtpDUE_DATE.ShowCheckBox = True
        Me.dtpDUE_DATE.Size = New System.Drawing.Size(134, 23)
        Me.dtpDUE_DATE.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 16)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Due Date"
        '
        'cmbPAYMENT_TERMS_ID
        '
        Me.cmbPAYMENT_TERMS_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_TERMS_ID.FormattingEnabled = True
        Me.cmbPAYMENT_TERMS_ID.Location = New System.Drawing.Point(90, 98)
        Me.cmbPAYMENT_TERMS_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPAYMENT_TERMS_ID.Name = "cmbPAYMENT_TERMS_ID"
        Me.cmbPAYMENT_TERMS_ID.Size = New System.Drawing.Size(134, 24)
        Me.cmbPAYMENT_TERMS_ID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pmt. Terms"
        '
        'cmbSHIP_VIA_ID
        '
        Me.cmbSHIP_VIA_ID.FormattingEnabled = True
        Me.cmbSHIP_VIA_ID.Location = New System.Drawing.Point(286, 123)
        Me.cmbSHIP_VIA_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSHIP_VIA_ID.Name = "cmbSHIP_VIA_ID"
        Me.cmbSHIP_VIA_ID.Size = New System.Drawing.Size(146, 24)
        Me.cmbSHIP_VIA_ID.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(229, 127)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 16)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Ship In"
        '
        'AccountLabel
        '
        Me.AccountLabel.AutoSize = True
        Me.AccountLabel.Location = New System.Drawing.Point(455, 152)
        Me.AccountLabel.Name = "AccountLabel"
        Me.AccountLabel.Size = New System.Drawing.Size(125, 16)
        Me.AccountLabel.TabIndex = 15
        Me.AccountLabel.Text = "Accts. Receivable"
        '
        'cmbACCOUNTS_RECEIVABLE_ID
        '
        Me.cmbACCOUNTS_RECEIVABLE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbACCOUNTS_RECEIVABLE_ID.FormattingEnabled = True
        Me.cmbACCOUNTS_RECEIVABLE_ID.Location = New System.Drawing.Point(584, 148)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Name = "cmbACCOUNTS_RECEIVABLE_ID"
        Me.cmbACCOUNTS_RECEIVABLE_ID.Size = New System.Drawing.Size(330, 24)
        Me.cmbACCOUNTS_RECEIVABLE_ID.TabIndex = 14
        '
        'cmbSALES_REP_ID
        '
        Me.cmbSALES_REP_ID.FormattingEnabled = True
        Me.cmbSALES_REP_ID.Location = New System.Drawing.Point(584, 123)
        Me.cmbSALES_REP_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSALES_REP_ID.Name = "cmbSALES_REP_ID"
        Me.cmbSALES_REP_ID.Size = New System.Drawing.Size(330, 24)
        Me.cmbSALES_REP_ID.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(512, 128)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Salesman"
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(286, 149)
        Me.cmbCLASS_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(146, 24)
        Me.cmbCLASS_ID.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(241, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Class"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(584, 97)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(330, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(517, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(791, 70)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(123, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(713, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Reference"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(584, 70)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(123, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(542, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date"
        '
        'lblBALANCE_DUE
        '
        Me.lblBALANCE_DUE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblBALANCE_DUE.BackColor = System.Drawing.Color.Transparent
        Me.lblBALANCE_DUE.ForeColor = System.Drawing.Color.Blue
        Me.lblBALANCE_DUE.Location = New System.Drawing.Point(918, 461)
        Me.lblBALANCE_DUE.Name = "lblBALANCE_DUE"
        Me.lblBALANCE_DUE.Size = New System.Drawing.Size(111, 18)
        Me.lblBALANCE_DUE.TabIndex = 23
        Me.lblBALANCE_DUE.Text = "0.00"
        Me.lblBALANCE_DUE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbxPaymentApplied
        '
        Me.lbxPaymentApplied.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxPaymentApplied.BackColor = System.Drawing.Color.Transparent
        Me.lbxPaymentApplied.ForeColor = System.Drawing.Color.Blue
        Me.lbxPaymentApplied.Location = New System.Drawing.Point(782, 460)
        Me.lbxPaymentApplied.Name = "lbxPaymentApplied"
        Me.lbxPaymentApplied.Size = New System.Drawing.Size(127, 20)
        Me.lbxPaymentApplied.TabIndex = 22
        Me.lbxPaymentApplied.Text = "0.00"
        Me.lbxPaymentApplied.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.ForeColor = System.Drawing.Color.Blue
        Me.Label19.Location = New System.Drawing.Point(925, 439)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 16)
        Me.Label19.TabIndex = 21
        Me.Label19.Text = "Unpaid Amount"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(818, 439)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(89, 16)
        Me.Label18.TabIndex = 20
        Me.Label18.Text = "Pmt. Applied"
        '
        'lbxBalance
        '
        Me.lbxBalance.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxBalance.BackColor = System.Drawing.Color.Transparent
        Me.lbxBalance.ForeColor = System.Drawing.Color.Red
        Me.lbxBalance.Location = New System.Drawing.Point(1038, 460)
        Me.lbxBalance.Name = "lbxBalance"
        Me.lbxBalance.Size = New System.Drawing.Size(105, 18)
        Me.lbxBalance.TabIndex = 81
        Me.lbxBalance.Text = "0.00"
        Me.lbxBalance.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(1059, 439)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(88, 16)
        Me.Label25.TabIndex = 80
        Me.Label25.Text = "Balance Due"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(9, 181)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1138, 246)
        Me.TabControl1.TabIndex = 82
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvProductItem)
        Me.TabPage1.Controls.Add(Me.ToolStrip5)
        Me.TabPage1.Controls.Add(Me.ToolStrip2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1130, 217)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel12, Me.lblCount})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 188)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1124, 25)
        Me.ToolStrip5.TabIndex = 154
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel12.Text = "Total Entry"
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(15, 22)
        Me.lblCount.Text = "0"
        '
        'FrmInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1161, 494)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.cmbSHIP_VIA_ID)
        Me.Controls.Add(Me.txtPO_NUMBER)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.AccountLabel)
        Me.Controls.Add(Me.cmbACCOUNTS_RECEIVABLE_ID)
        Me.Controls.Add(Me.dtpDISCOUNT_DATE)
        Me.Controls.Add(Me.cmbSALES_REP_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCLASS_ID)
        Me.Controls.Add(Me.lblOUTPUT_TAX_ACCOUNT_ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.dtpDUE_DATE)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.lblOUTPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbPAYMENT_TERMS_ID)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbxBalance)
        Me.Controls.Add(Me.lblOUTPUT_TAX_RATE)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.lblBALANCE_DUE)
        Me.Controls.Add(Me.lbxPaymentApplied)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.lblOUTPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbOUTPUT_TAX_ID)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TabControl1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmInvoice"
        Me.Text = "Invoice"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents tsJournal As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPO_NUMBER As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpDISCOUNT_DATE As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpDUE_DATE As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbPAYMENT_TERMS_ID As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbSALES_REP_ID As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbSHIP_VIA_ID As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbOUTPUT_TAX_ID As ComboBox
    Friend WithEvents Label13 As Label
    Friend WithEvents lblOUTPUT_TAX_AMOUNT As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents lblOUTPUT_TAX_VAT_METHOD As Label
    Friend WithEvents lblBALANCE_DUE As Label
    Friend WithEvents lbxPaymentApplied As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblOUTPUT_TAX_ACCOUNT_ID As Label
    Friend WithEvents lblOUTPUT_TAX_RATE As Label
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsPrint As ToolStripButton
    Friend WithEvents lbxBalance As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents AccountLabel As Label
    Friend WithEvents cmbACCOUNTS_RECEIVABLE_ID As ComboBox
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents tsApplyCredits As ToolStripDropDownButton
    Friend WithEvents ToCreditMemoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripSeparator
    Friend WithEvents spJournal As ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripSeparator
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents lblCount As ToolStripLabel
End Class
