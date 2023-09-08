<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBillCredit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBillCredit))
        Me.lblINPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_RATE = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.lbsCredits = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPrintPageToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.spJournal = New System.Windows.Forms.ToolStripSeparator()
        Me.tsJournal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToCreditsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.cmbACCOUNTS_PAYABLE_ID = New System.Windows.Forms.ComboBox()
        Me.AccountLabel = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblAMOUNT_APPLIED = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbVENDOR_ID = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCount = New System.Windows.Forms.ToolStripLabel()
        Me.lbsTotal_Amount_Item = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel15 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.dgvExpenses = New System.Windows.Forms.DataGridView()
        Me.ToolStrip4 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCount2 = New System.Windows.Forms.ToolStripLabel()
        Me.lbsTotal_Amount_Expense = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.tsAddExpenses = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditExpenses = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveExpenses = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText2 = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbINPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip5.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvExpenses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip4.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblINPUT_TAX_VAT_METHOD
        '
        Me.lblINPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(455, 665)
        Me.lblINPUT_TAX_VAT_METHOD.Name = "lblINPUT_TAX_VAT_METHOD"
        Me.lblINPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(48, 25)
        Me.lblINPUT_TAX_VAT_METHOD.TabIndex = 119
        Me.lblINPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblINPUT_TAX_VAT_METHOD.Visible = False
        '
        'lblINPUT_TAX_RATE
        '
        Me.lblINPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_TAX_RATE.Location = New System.Drawing.Point(394, 665)
        Me.lblINPUT_TAX_RATE.Name = "lblINPUT_TAX_RATE"
        Me.lblINPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblINPUT_TAX_RATE.TabIndex = 124
        Me.lblINPUT_TAX_RATE.Text = "0"
        Me.lblINPUT_TAX_RATE.Visible = False
        '
        'lblINPUT_TAX_ACCOUNT_ID
        '
        Me.lblINPUT_TAX_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_TAX_ACCOUNT_ID.Location = New System.Drawing.Point(511, 665)
        Me.lblINPUT_TAX_ACCOUNT_ID.Name = "lblINPUT_TAX_ACCOUNT_ID"
        Me.lblINPUT_TAX_ACCOUNT_ID.Size = New System.Drawing.Size(51, 25)
        Me.lblINPUT_TAX_ACCOUNT_ID.TabIndex = 118
        Me.lblINPUT_TAX_ACCOUNT_ID.Visible = False
        '
        'lbsCredits
        '
        Me.lbsCredits.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbsCredits.BackColor = System.Drawing.Color.Transparent
        Me.lbsCredits.ForeColor = System.Drawing.Color.Blue
        Me.lbsCredits.Location = New System.Drawing.Point(945, 522)
        Me.lbsCredits.Name = "lbsCredits"
        Me.lbsCredits.Size = New System.Drawing.Size(167, 21)
        Me.lbsCredits.TabIndex = 123
        Me.lbsCredits.Text = "0.00"
        Me.lbsCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripSeparator3, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripSeparator4, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.spJournal, Me.tsJournal, Me.ToolStripLabel6, Me.ToolStripDropDownButton1, Me.ToolStripLabel8, Me.tsDelete, Me.ToolStripSeparator5, Me.ToolStripButton4, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1135, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 125
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.Image = Global.Automission.My.Resources.Resources.m_save_file
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(71, 52)
        Me.tsSaveNew.Text = "Save File"
        Me.tsSaveNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 55)
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
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(6, 55)
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
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.m_printing
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(41, 52)
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
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToCreditsToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Automission.My.Resources.Resources.m_applied
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(107, 52)
        Me.ToolStripDropDownButton1.Text = "Apply Credits"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToCreditsToolStripMenuItem
        '
        Me.ToCreditsToolStripMenuItem.Name = "ToCreditsToolStripMenuItem"
        Me.ToCreditsToolStripMenuItem.Size = New System.Drawing.Size(119, 22)
        Me.ToCreditsToolStripMenuItem.Text = "To Bills"
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.Automission.My.Resources.Resources.m_logs
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(41, 52)
        Me.ToolStripButton4.Text = "Logs"
        Me.ToolStripButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'cmbACCOUNTS_PAYABLE_ID
        '
        Me.cmbACCOUNTS_PAYABLE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbACCOUNTS_PAYABLE_ID.FormattingEnabled = True
        Me.cmbACCOUNTS_PAYABLE_ID.Location = New System.Drawing.Point(80, 99)
        Me.cmbACCOUNTS_PAYABLE_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbACCOUNTS_PAYABLE_ID.Name = "cmbACCOUNTS_PAYABLE_ID"
        Me.cmbACCOUNTS_PAYABLE_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbACCOUNTS_PAYABLE_ID.TabIndex = 16
        '
        'AccountLabel
        '
        Me.AccountLabel.AutoSize = True
        Me.AccountLabel.Location = New System.Drawing.Point(14, 103)
        Me.AccountLabel.Name = "AccountLabel"
        Me.AccountLabel.Size = New System.Drawing.Size(62, 16)
        Me.AccountLabel.TabIndex = 15
        Me.AccountLabel.Text = "Account"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(518, 98)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(345, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(451, 102)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(718, 72)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(145, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(639, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Reference"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(518, 72)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(110, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(471, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date "
        '
        'lblAMOUNT_APPLIED
        '
        Me.lblAMOUNT_APPLIED.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT_APPLIED.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT_APPLIED.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT_APPLIED.Location = New System.Drawing.Point(766, 522)
        Me.lblAMOUNT_APPLIED.Name = "lblAMOUNT_APPLIED"
        Me.lblAMOUNT_APPLIED.Size = New System.Drawing.Size(171, 21)
        Me.lblAMOUNT_APPLIED.TabIndex = 144
        Me.lblAMOUNT_APPLIED.Text = "0.00"
        Me.lblAMOUNT_APPLIED.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(1013, 503)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 16)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "Credit Balance"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(833, 503)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 16)
        Me.Label18.TabIndex = 142
        Me.Label18.Text = "Amount Applied"
        '
        'cmbVENDOR_ID
        '
        Me.cmbVENDOR_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbVENDOR_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbVENDOR_ID.FormattingEnabled = True
        Me.cmbVENDOR_ID.Location = New System.Drawing.Point(80, 72)
        Me.cmbVENDOR_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbVENDOR_ID.Name = "cmbVENDOR_ID"
        Me.cmbVENDOR_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbVENDOR_ID.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(25, 75)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 16)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Vendor"
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT.Location = New System.Drawing.Point(617, 522)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(143, 21)
        Me.lblAMOUNT.TabIndex = 139
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblINPUT_TAX_AMOUNT
        '
        Me.lblINPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblINPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblINPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblINPUT_TAX_AMOUNT.Location = New System.Drawing.Point(522, 522)
        Me.lblINPUT_TAX_AMOUNT.Name = "lblINPUT_TAX_AMOUNT"
        Me.lblINPUT_TAX_AMOUNT.Size = New System.Drawing.Size(93, 21)
        Me.lblINPUT_TAX_AMOUNT.TabIndex = 138
        Me.lblINPUT_TAX_AMOUNT.Text = "0.00"
        Me.lblINPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(14, 133)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1106, 331)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
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
        Me.TabPage1.Size = New System.Drawing.Size(1098, 302)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
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
        Me.dgvProductItem.Location = New System.Drawing.Point(3, 41)
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(1092, 232)
        Me.dgvProductItem.TabIndex = 4
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.lblCount, Me.lbsTotal_Amount_Item, Me.ToolStripLabel15})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 273)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1092, 25)
        Me.ToolStrip5.TabIndex = 150
        Me.ToolStrip5.Text = "ToolStrip5"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel3.Text = "Total Entry"
        '
        'lblCount
        '
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(15, 22)
        Me.lblCount.Text = "0"
        '
        'lbsTotal_Amount_Item
        '
        Me.lbsTotal_Amount_Item.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbsTotal_Amount_Item.Name = "lbsTotal_Amount_Item"
        Me.lbsTotal_Amount_Item.Size = New System.Drawing.Size(15, 22)
        Me.lbsTotal_Amount_Item.Text = "0"
        '
        'ToolStripLabel15
        '
        Me.ToolStripLabel15.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel15.Name = "ToolStripLabel15"
        Me.ToolStripLabel15.Size = New System.Drawing.Size(75, 22)
        Me.ToolStripLabel15.Text = "Total Item"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1092, 37)
        Me.ToolStrip2.TabIndex = 147
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
        Me.tsAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
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
        Me.tsEditItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
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
        Me.tsRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        '
        'tsFindText
        '
        Me.tsFindText.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsFindText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsFindText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvExpenses)
        Me.TabPage2.Controls.Add(Me.ToolStrip4)
        Me.TabPage2.Controls.Add(Me.ToolStrip3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage2.Size = New System.Drawing.Size(1098, 302)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Expenses"
        '
        'dgvExpenses
        '
        Me.dgvExpenses.AllowUserToAddRows = False
        Me.dgvExpenses.AllowUserToDeleteRows = False
        Me.dgvExpenses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvExpenses.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvExpenses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExpenses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvExpenses.Location = New System.Drawing.Point(3, 41)
        Me.dgvExpenses.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvExpenses.MultiSelect = False
        Me.dgvExpenses.Name = "dgvExpenses"
        Me.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExpenses.Size = New System.Drawing.Size(1092, 232)
        Me.dgvExpenses.TabIndex = 8
        '
        'ToolStrip4
        '
        Me.ToolStrip4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel1, Me.lblCount2, Me.lbsTotal_Amount_Expense, Me.ToolStripLabel7})
        Me.ToolStrip4.Location = New System.Drawing.Point(3, 273)
        Me.ToolStrip4.Name = "ToolStrip4"
        Me.ToolStrip4.Size = New System.Drawing.Size(1092, 25)
        Me.ToolStrip4.TabIndex = 149
        Me.ToolStrip4.Text = "ToolStrip4"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel1.Text = "Total Entry"
        '
        'lblCount2
        '
        Me.lblCount2.Name = "lblCount2"
        Me.lblCount2.Size = New System.Drawing.Size(15, 22)
        Me.lblCount2.Text = "0"
        '
        'lbsTotal_Amount_Expense
        '
        Me.lbsTotal_Amount_Expense.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.lbsTotal_Amount_Expense.Name = "lbsTotal_Amount_Expense"
        Me.lbsTotal_Amount_Expense.Size = New System.Drawing.Size(15, 22)
        Me.lbsTotal_Amount_Expense.Text = "0"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(106, 22)
        Me.ToolStripLabel7.Text = "Total Expenses"
        '
        'ToolStrip3
        '
        Me.ToolStrip3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddExpenses, Me.ToolStripSeparator1, Me.tsEditExpenses, Me.ToolStripSeparator2, Me.tsRemoveExpenses, Me.tsFindText2, Me.ToolStripLabel12})
        Me.ToolStrip3.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.Size = New System.Drawing.Size(1092, 37)
        Me.ToolStrip3.TabIndex = 148
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'tsAddExpenses
        '
        Me.tsAddExpenses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAddExpenses.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsAddExpenses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAddExpenses.Name = "tsAddExpenses"
        Me.tsAddExpenses.Size = New System.Drawing.Size(34, 34)
        Me.tsAddExpenses.Text = "&Add"
        Me.tsAddExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 37)
        '
        'tsEditExpenses
        '
        Me.tsEditExpenses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsEditExpenses.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsEditExpenses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsEditExpenses.Name = "tsEditExpenses"
        Me.tsEditExpenses.Size = New System.Drawing.Size(34, 34)
        Me.tsEditExpenses.Text = "&Edit"
        Me.tsEditExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 37)
        '
        'tsRemoveExpenses
        '
        Me.tsRemoveExpenses.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRemoveExpenses.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsRemoveExpenses.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRemoveExpenses.Name = "tsRemoveExpenses"
        Me.tsRemoveExpenses.Size = New System.Drawing.Size(34, 34)
        Me.tsRemoveExpenses.Text = "&Remove"
        Me.tsRemoveExpenses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsFindText2
        '
        Me.tsFindText2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsFindText2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsFindText2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsFindText2.Name = "tsFindText2"
        Me.tsFindText2.Size = New System.Drawing.Size(228, 37)
        '
        'ToolStripLabel12
        '
        Me.ToolStripLabel12.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel12.Name = "ToolStripLabel12"
        Me.ToolStripLabel12.Size = New System.Drawing.Size(34, 34)
        Me.ToolStripLabel12.Text = "Find"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(719, 503)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 16)
        Me.Label17.TabIndex = 137
        Me.Label17.Text = "Total "
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(306, 471)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(811, 23)
        Me.txtNOTES.TabIndex = 134
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(545, 503)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(69, 16)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "Input Tax"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(19, 476)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 16)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "Tax"
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(522, 519)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(594, 1)
        Me.Label15.TabIndex = 135
        '
        'cmbINPUT_TAX_ID
        '
        Me.cmbINPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbINPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbINPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbINPUT_TAX_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbINPUT_TAX_ID.FormattingEnabled = True
        Me.cmbINPUT_TAX_ID.Location = New System.Drawing.Point(54, 471)
        Me.cmbINPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbINPUT_TAX_ID.Name = "cmbINPUT_TAX_ID"
        Me.cmbINPUT_TAX_ID.Size = New System.Drawing.Size(171, 24)
        Me.cmbINPUT_TAX_ID.TabIndex = 132
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(255, 474)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(45, 16)
        Me.Label12.TabIndex = 133
        Me.Label12.Text = "Notes"
        '
        'frmBillCredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 546)
        Me.Controls.Add(Me.cmbINPUT_TAX_ID)
        Me.Controls.Add(Me.cmbACCOUNTS_PAYABLE_ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.AccountLabel)
        Me.Controls.Add(Me.cmbVENDOR_ID)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lbsCredits)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblAMOUNT_APPLIED)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.lblINPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblINPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.lblINPUT_TAX_RATE)
        Me.Controls.Add(Me.lblINPUT_TAX_ACCOUNT_ID)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmBillCredit"
        Me.Text = "frmBillCredit"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvExpenses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip4.ResumeLayout(False)
        Me.ToolStrip4.PerformLayout()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblINPUT_TAX_VAT_METHOD As Label
    Friend WithEvents lblINPUT_TAX_RATE As Label
    Friend WithEvents lblINPUT_TAX_ACCOUNT_ID As Label
    Friend WithEvents lbsCredits As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents tsJournal As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents lblAMOUNT_APPLIED As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbVENDOR_ID As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents lblINPUT_TAX_AMOUNT As Label
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents dgvExpenses As DataGridView
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbINPUT_TAX_ID As ComboBox
    Friend WithEvents Label12 As Label
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents tsAddExpenses As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsEditExpenses As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsRemoveExpenses As ToolStripButton
    Friend WithEvents cmbACCOUNTS_PAYABLE_ID As ComboBox
    Friend WithEvents AccountLabel As Label
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents tsFindText2 As ToolStripTextBox
    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripSeparator
    Friend WithEvents spJournal As ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ToCreditsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStrip4 As ToolStrip
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents lblCount2 As ToolStripLabel
    Friend WithEvents lbsTotal_Amount_Expense As ToolStripLabel
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents lblCount As ToolStripLabel
    Friend WithEvents lbsTotal_Amount_Item As ToolStripLabel
    Friend WithEvents ToolStripLabel15 As ToolStripLabel
End Class
