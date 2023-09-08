<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCreditMemo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCreditMemo))
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSALES_REP_ID = New System.Windows.Forms.ComboBox()
        Me.cmbACCOUNTS_RECEIVABLE_ID = New System.Windows.Forms.ComboBox()
        Me.AccountLabel = New System.Windows.Forms.Label()
        Me.cmbCLASS_ID = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbxUNAPPLIED_AMOUNT = New System.Windows.Forms.Label()
        Me.lblAMOUNT_APPLIED = New System.Windows.Forms.Label()
        Me.label001 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPrintPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.spJournal = New System.Windows.Forms.ToolStripSeparator()
        Me.tsJournal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsApplyCredits = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ApplyToInvoiceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GiveARefundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.lblOUTPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbOUTPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_RATE = New System.Windows.Forms.Label()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Salesman"
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(105, 69)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'cmbSALES_REP_ID
        '
        Me.cmbSALES_REP_ID.FormattingEnabled = True
        Me.cmbSALES_REP_ID.Location = New System.Drawing.Point(105, 97)
        Me.cmbSALES_REP_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSALES_REP_ID.Name = "cmbSALES_REP_ID"
        Me.cmbSALES_REP_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbSALES_REP_ID.TabIndex = 15
        '
        'cmbACCOUNTS_RECEIVABLE_ID
        '
        Me.cmbACCOUNTS_RECEIVABLE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbACCOUNTS_RECEIVABLE_ID.FormattingEnabled = True
        Me.cmbACCOUNTS_RECEIVABLE_ID.Location = New System.Drawing.Point(543, 121)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Name = "cmbACCOUNTS_RECEIVABLE_ID"
        Me.cmbACCOUNTS_RECEIVABLE_ID.Size = New System.Drawing.Size(285, 24)
        Me.cmbACCOUNTS_RECEIVABLE_ID.TabIndex = 16
        '
        'AccountLabel
        '
        Me.AccountLabel.AutoSize = True
        Me.AccountLabel.Location = New System.Drawing.Point(471, 125)
        Me.AccountLabel.Name = "AccountLabel"
        Me.AccountLabel.Size = New System.Drawing.Size(71, 16)
        Me.AccountLabel.TabIndex = 15
        Me.AccountLabel.Text = "A/R Acct."
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(893, 92)
        Me.cmbCLASS_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(174, 24)
        Me.cmbCLASS_ID.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(845, 94)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Class"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(543, 94)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(285, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(474, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(893, 65)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(174, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(847, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Code"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(543, 68)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(119, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(501, 71)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date"
        '
        'lbxUNAPPLIED_AMOUNT
        '
        Me.lbxUNAPPLIED_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbxUNAPPLIED_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lbxUNAPPLIED_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lbxUNAPPLIED_AMOUNT.Location = New System.Drawing.Point(1046, 559)
        Me.lbxUNAPPLIED_AMOUNT.Name = "lbxUNAPPLIED_AMOUNT"
        Me.lbxUNAPPLIED_AMOUNT.Size = New System.Drawing.Size(152, 22)
        Me.lbxUNAPPLIED_AMOUNT.TabIndex = 46
        Me.lbxUNAPPLIED_AMOUNT.Text = "0.00"
        Me.lbxUNAPPLIED_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAMOUNT_APPLIED
        '
        Me.lblAMOUNT_APPLIED.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT_APPLIED.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT_APPLIED.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT_APPLIED.Location = New System.Drawing.Point(881, 559)
        Me.lblAMOUNT_APPLIED.Name = "lblAMOUNT_APPLIED"
        Me.lblAMOUNT_APPLIED.Size = New System.Drawing.Size(157, 23)
        Me.lblAMOUNT_APPLIED.TabIndex = 45
        Me.lblAMOUNT_APPLIED.Text = "0.00"
        Me.lblAMOUNT_APPLIED.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'label001
        '
        Me.label001.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label001.AutoSize = True
        Me.label001.BackColor = System.Drawing.Color.Transparent
        Me.label001.ForeColor = System.Drawing.Color.Blue
        Me.label001.Location = New System.Drawing.Point(1087, 534)
        Me.label001.Name = "label001"
        Me.label001.Size = New System.Drawing.Size(109, 16)
        Me.label001.TabIndex = 44
        Me.label001.Text = "Un-Applied Amt"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(946, 534)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 16)
        Me.Label18.TabIndex = 43
        Me.Label18.Text = "Amt. Applied"
        '
        'lblOUTPUT_TAX_ACCOUNT_ID
        '
        Me.lblOUTPUT_TAX_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Location = New System.Drawing.Point(286, 548)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Name = "lblOUTPUT_TAX_ACCOUNT_ID"
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_ACCOUNT_ID.TabIndex = 41
        Me.lblOUTPUT_TAX_ACCOUNT_ID.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.spJournal, Me.tsJournal, Me.ToolStripLabel6, Me.tsDelete, Me.ToolStripLabel8, Me.tsApplyCredits, Me.ToolStripLabel7, Me.ToolStripButton4, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1217, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 31
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.Image = Global.Automission.My.Resources.Resources.m_save_file
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(63, 49)
        Me.tsSaveNew.Text = "Save File"
        Me.tsSaveNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(6, 52)
        '
        'tsDiscard
        '
        Me.tsDiscard.Image = Global.Automission.My.Resources.Resources.m_refresh
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(55, 49)
        Me.tsDiscard.Text = "Refresh"
        Me.tsDiscard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(6, 52)
        '
        'tsFind
        '
        Me.tsFind.Image = Global.Automission.My.Resources.Resources.m_search
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(57, 49)
        Me.tsFind.Text = "Find File"
        Me.tsFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.m_printing
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(37, 49)
        Me.ToolStripButton1.Text = "Print"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.ToolTipText = "Print"
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
        Me.PreviewToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.PreviewToolStripMenuItem.Text = "Preview"
        '
        'SelectPrintPageToolStripMenuItem
        '
        Me.SelectPrintPageToolStripMenuItem.Name = "SelectPrintPageToolStripMenuItem"
        Me.SelectPrintPageToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SelectPrintPageToolStripMenuItem.Text = "Select Print Page"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.Automission.My.Resources.Resources.m_history_link
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(51, 49)
        Me.ToolStripButton2.Text = "History"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'spJournal
        '
        Me.spJournal.Name = "spJournal"
        Me.spJournal.Size = New System.Drawing.Size(6, 52)
        '
        'tsJournal
        '
        Me.tsJournal.Image = Global.Automission.My.Resources.Resources.m_journal_doc
        Me.tsJournal.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsJournal.Name = "tsJournal"
        Me.tsJournal.Size = New System.Drawing.Size(52, 49)
        Me.tsJournal.Text = "Journal"
        Me.tsJournal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(6, 52)
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.m_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(71, 49)
        Me.tsDelete.Text = "Delete File"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(6, 52)
        '
        'tsApplyCredits
        '
        Me.tsApplyCredits.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApplyToInvoiceToolStripMenuItem, Me.GiveARefundToolStripMenuItem})
        Me.tsApplyCredits.Image = Global.Automission.My.Resources.Resources.m_applied
        Me.tsApplyCredits.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsApplyCredits.Name = "tsApplyCredits"
        Me.tsApplyCredits.Size = New System.Drawing.Size(97, 49)
        Me.tsApplyCredits.Text = "Apply Credits"
        Me.tsApplyCredits.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ApplyToInvoiceToolStripMenuItem
        '
        Me.ApplyToInvoiceToolStripMenuItem.Name = "ApplyToInvoiceToolStripMenuItem"
        Me.ApplyToInvoiceToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.ApplyToInvoiceToolStripMenuItem.Text = "Apply to Invoice"
        '
        'GiveARefundToolStripMenuItem
        '
        Me.GiveARefundToolStripMenuItem.Name = "GiveARefundToolStripMenuItem"
        Me.GiveARefundToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.GiveARefundToolStripMenuItem.Text = "Give a Refund"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.Automission.My.Resources.Resources.m_logs
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(37, 49)
        Me.ToolStripButton4.Text = "Logs"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsTITLE
        '
        Me.tsTITLE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTITLE.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.tsTITLE.Image = Global.Automission.My.Resources.Resources.back_icon_set
        Me.tsTITLE.Name = "tsTITLE"
        Me.tsTITLE.Size = New System.Drawing.Size(104, 49)
        Me.tsTITLE.Text = "TITLE "
        '
        'lblOUTPUT_TAX_VAT_METHOD
        '
        Me.lblOUTPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(353, 546)
        Me.lblOUTPUT_TAX_VAT_METHOD.Name = "lblOUTPUT_TAX_VAT_METHOD"
        Me.lblOUTPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(48, 25)
        Me.lblOUTPUT_TAX_VAT_METHOD.TabIndex = 42
        Me.lblOUTPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblOUTPUT_TAX_VAT_METHOD.Visible = False
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT.Location = New System.Drawing.Point(727, 558)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(151, 21)
        Me.lblAMOUNT.TabIndex = 40
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOUTPUT_TAX_AMOUNT
        '
        Me.lblOUTPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblOUTPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblOUTPUT_TAX_AMOUNT.Location = New System.Drawing.Point(615, 558)
        Me.lblOUTPUT_TAX_AMOUNT.Name = "lblOUTPUT_TAX_AMOUNT"
        Me.lblOUTPUT_TAX_AMOUNT.Size = New System.Drawing.Size(98, 21)
        Me.lblOUTPUT_TAX_AMOUNT.TabIndex = 39
        Me.lblOUTPUT_TAX_AMOUNT.Text = "0.00"
        Me.lblOUTPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvProductItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductItem.Location = New System.Drawing.Point(3, 41)
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(1176, 243)
        Me.dgvProductItem.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1176, 37)
        Me.ToolStrip2.TabIndex = 18
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAddItem
        '
        Me.tsAddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAddItem.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsAddItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddItem.Name = "tsAddItem"
        Me.tsAddItem.Size = New System.Drawing.Size(28, 28)
        Me.tsAddItem.Text = "&Add"
        Me.tsAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(6, 31)
        '
        'tsEditItem
        '
        Me.tsEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditItem.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsEditItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditItem.Name = "tsEditItem"
        Me.tsEditItem.Size = New System.Drawing.Size(28, 28)
        Me.tsEditItem.Text = "&Edit"
        Me.tsEditItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(6, 31)
        '
        'tsRemoveItem
        '
        Me.tsRemoveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRemoveItem.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsRemoveItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemoveItem.Name = "tsRemoveItem"
        Me.tsRemoveItem.Size = New System.Drawing.Size(28, 28)
        Me.tsRemoveItem.Text = "&Remove"
        Me.tsRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsFindText
        '
        Me.tsFindText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsFindText.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsFindText.Name = "tsFindText"
        Me.tsFindText.Size = New System.Drawing.Size(228, 31)
        '
        'ToolStripLabel11
        '
        Me.ToolStripLabel11.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel11.Name = "ToolStripLabel11"
        Me.ToolStripLabel11.Size = New System.Drawing.Size(30, 28)
        Me.ToolStripLabel11.Text = "Find"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(834, 534)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 16)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Total "
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(353, 495)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTES.Size = New System.Drawing.Size(850, 23)
        Me.txtNOTES.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(624, 534)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 16)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Output Tax"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(16, 498)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 16)
        Me.Label13.TabIndex = 32
        Me.Label13.Text = "Tax"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(599, 553)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(602, 1)
        Me.Label15.TabIndex = 36
        '
        'cmbOUTPUT_TAX_ID
        '
        Me.cmbOUTPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOUTPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOUTPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOUTPUT_TAX_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOUTPUT_TAX_ID.FormattingEnabled = True
        Me.cmbOUTPUT_TAX_ID.Location = New System.Drawing.Point(54, 495)
        Me.cmbOUTPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbOUTPUT_TAX_ID.Name = "cmbOUTPUT_TAX_ID"
        Me.cmbOUTPUT_TAX_ID.Size = New System.Drawing.Size(188, 24)
        Me.cmbOUTPUT_TAX_ID.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(282, 499)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Remarks"
        '
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.AutoSize = True
        Me.lblTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(185, 548)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblTAXABLE_AMOUNT.TabIndex = 47
        Me.lblTAXABLE_AMOUNT.Text = "0.00"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'lblOUTPUT_TAX_RATE
        '
        Me.lblOUTPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_RATE.Location = New System.Drawing.Point(125, 548)
        Me.lblOUTPUT_TAX_RATE.Name = "lblOUTPUT_TAX_RATE"
        Me.lblOUTPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_RATE.TabIndex = 48
        Me.lblOUTPUT_TAX_RATE.Text = "0"
        Me.lblOUTPUT_TAX_RATE.Visible = False
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.AutoSize = True
        Me.lblNONTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblNONTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(229, 553)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 78
        Me.lblNONTAXABLE_AMOUNT.Text = "0.00"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(14, 145)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1190, 342)
        Me.TabControl1.TabIndex = 79
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
        Me.TabPage1.Size = New System.Drawing.Size(1182, 313)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel12, Me.lblCount})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 284)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1176, 25)
        Me.ToolStrip5.TabIndex = 153
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(68, 22)
        Me.ToolStripLabel12.Text = "Total Entry"
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(14, 22)
        Me.lblCount.Text = "0"
        '
        'frmCreditMemo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1217, 582)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmbACCOUNTS_RECEIVABLE_ID)
        Me.Controls.Add(Me.AccountLabel)
        Me.Controls.Add(Me.lblOUTPUT_TAX_ACCOUNT_ID)
        Me.Controls.Add(Me.cmbCLASS_ID)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbSALES_REP_ID)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.lblOUTPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.lblOUTPUT_TAX_RATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lbxUNAPPLIED_AMOUNT)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.lblAMOUNT_APPLIED)
        Me.Controls.Add(Me.label001)
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
        Me.Controls.Add(Me.Label11)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCreditMemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Credit Memo"
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
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents lbxUNAPPLIED_AMOUNT As Label
    Friend WithEvents lblAMOUNT_APPLIED As Label
    Friend WithEvents label001 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents lblOUTPUT_TAX_ACCOUNT_ID As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents tsJournal As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents lblOUTPUT_TAX_VAT_METHOD As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents lblOUTPUT_TAX_AMOUNT As Label
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbOUTPUT_TAX_ID As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbSALES_REP_ID As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents lblOUTPUT_TAX_RATE As Label
    Friend WithEvents tsApplyCredits As ToolStripDropDownButton
    Friend WithEvents ApplyToInvoiceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GiveARefundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents cmbACCOUNTS_RECEIVABLE_ID As ComboBox
    Friend WithEvents AccountLabel As Label
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
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
