<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceivePayment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReceivePayment))
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
        Me.SelectPagePrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.spJournal = New System.Windows.Forms.ToolStripSeparator()
        Me.tsJournal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpRECEIPT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.OR_DATE = New System.Windows.Forms.Label()
        Me.txtRECEIPT_REF_NO = New System.Windows.Forms.TextBox()
        Me.OR_No = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpCARD_EXPIRY_DATE = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CARD_EXPIRED_DATE = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_METHOD_ID = New System.Windows.Forms.ComboBox()
        Me.numAMOUNT = New System.Windows.Forms.NumericUpDown()
        Me.txtCARD_NO = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvInvoice = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.tsUncheckAll = New System.Windows.Forms.ToolStripButton()
        Me.tsCheckAll = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTool = New System.Windows.Forms.ToolStripSplitButton()
        Me.DiscountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.CARD_NO = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblAMOUNT_APPLIED = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbACCOUNTS_RECEIVABLE_ID = New System.Windows.Forms.ComboBox()
        Me.AccountLabel = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel8, Me.ToolStripButton2, Me.spJournal, Me.tsJournal, Me.ToolStripLabel6, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton4, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1067, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 7
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.Image = Global.Automission.My.Resources.Resources.m_save_file
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(71, 52)
        Me.tsSaveNew.Text = "&Save File"
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
        Me.tsDiscard.Text = "&Refresh"
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
        Me.tsFind.Text = "&Find File"
        Me.tsFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.m_printing
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(41, 52)
        Me.ToolStripButton1.Text = "&Print"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ToolStripButton1.ToolTipText = "Print"
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PreviewToolStripMenuItem, Me.SelectPagePrintToolStripMenuItem})
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
        'SelectPagePrintToolStripMenuItem
        '
        Me.SelectPagePrintToolStripMenuItem.Name = "SelectPagePrintToolStripMenuItem"
        Me.SelectPagePrintToolStripMenuItem.Size = New System.Drawing.Size(188, 22)
        Me.SelectPagePrintToolStripMenuItem.Text = "Select Page Print"
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Image = Global.Automission.My.Resources.Resources.m_history_link
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(57, 52)
        Me.ToolStripButton2.Text = "&History"
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
        Me.tsJournal.Text = "&Journal"
        Me.tsJournal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(6, 55)
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.m_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(80, 52)
        Me.tsDelete.Text = "&Delete File"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Image = Global.Automission.My.Resources.Resources.m_logs
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(41, 52)
        Me.ToolStripButton4.Text = "&Logs"
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
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(109, 82)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(32, 86)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'dtpRECEIPT_DATE
        '
        Me.dtpRECEIPT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRECEIPT_DATE.Location = New System.Drawing.Point(317, 110)
        Me.dtpRECEIPT_DATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpRECEIPT_DATE.Name = "dtpRECEIPT_DATE"
        Me.dtpRECEIPT_DATE.ShowCheckBox = True
        Me.dtpRECEIPT_DATE.Size = New System.Drawing.Size(134, 23)
        Me.dtpRECEIPT_DATE.TabIndex = 13
        '
        'OR_DATE
        '
        Me.OR_DATE.AutoSize = True
        Me.OR_DATE.Location = New System.Drawing.Point(246, 113)
        Me.OR_DATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.OR_DATE.Name = "OR_DATE"
        Me.OR_DATE.Size = New System.Drawing.Size(66, 16)
        Me.OR_DATE.TabIndex = 12
        Me.OR_DATE.Text = "O.R Date"
        '
        'txtRECEIPT_REF_NO
        '
        Me.txtRECEIPT_REF_NO.Location = New System.Drawing.Point(317, 137)
        Me.txtRECEIPT_REF_NO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtRECEIPT_REF_NO.Name = "txtRECEIPT_REF_NO"
        Me.txtRECEIPT_REF_NO.Size = New System.Drawing.Size(134, 23)
        Me.txtRECEIPT_REF_NO.TabIndex = 11
        '
        'OR_No
        '
        Me.OR_No.AutoSize = True
        Me.OR_No.Location = New System.Drawing.Point(255, 140)
        Me.OR_No.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.OR_No.Name = "OR_No"
        Me.OR_No.Size = New System.Drawing.Size(57, 16)
        Me.OR_No.TabIndex = 10
        Me.OR_No.Text = "O.R No."
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(527, 110)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(242, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(469, 114)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Branch"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(850, 81)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(164, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(749, 85)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Reference No."
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(527, 82)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(133, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(483, 85)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date"
        '
        'dtpCARD_EXPIRY_DATE
        '
        Me.dtpCARD_EXPIRY_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCARD_EXPIRY_DATE.Location = New System.Drawing.Point(850, 135)
        Me.dtpCARD_EXPIRY_DATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpCARD_EXPIRY_DATE.Name = "dtpCARD_EXPIRY_DATE"
        Me.dtpCARD_EXPIRY_DATE.ShowCheckBox = True
        Me.dtpCARD_EXPIRY_DATE.Size = New System.Drawing.Size(164, 23)
        Me.dtpCARD_EXPIRY_DATE.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(21, 140)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Pmt Method"
        '
        'CARD_EXPIRED_DATE
        '
        Me.CARD_EXPIRED_DATE.AutoSize = True
        Me.CARD_EXPIRED_DATE.Location = New System.Drawing.Point(782, 139)
        Me.CARD_EXPIRED_DATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.CARD_EXPIRED_DATE.Name = "CARD_EXPIRED_DATE"
        Me.CARD_EXPIRED_DATE.Size = New System.Drawing.Size(65, 16)
        Me.CARD_EXPIRED_DATE.TabIndex = 16
        Me.CARD_EXPIRED_DATE.Text = "Expired :"
        '
        'cmbPAYMENT_METHOD_ID
        '
        Me.cmbPAYMENT_METHOD_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_METHOD_ID.FormattingEnabled = True
        Me.cmbPAYMENT_METHOD_ID.Location = New System.Drawing.Point(109, 137)
        Me.cmbPAYMENT_METHOD_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPAYMENT_METHOD_ID.Name = "cmbPAYMENT_METHOD_ID"
        Me.cmbPAYMENT_METHOD_ID.Size = New System.Drawing.Size(127, 24)
        Me.cmbPAYMENT_METHOD_ID.TabIndex = 10
        '
        'numAMOUNT
        '
        Me.numAMOUNT.DecimalPlaces = 2
        Me.numAMOUNT.InterceptArrowKeys = False
        Me.numAMOUNT.Location = New System.Drawing.Point(109, 110)
        Me.numAMOUNT.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numAMOUNT.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.numAMOUNT.Name = "numAMOUNT"
        Me.numAMOUNT.Size = New System.Drawing.Size(128, 23)
        Me.numAMOUNT.TabIndex = 7
        Me.numAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCARD_NO
        '
        Me.txtCARD_NO.Location = New System.Drawing.Point(527, 137)
        Me.txtCARD_NO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCARD_NO.Name = "txtCARD_NO"
        Me.txtCARD_NO.Size = New System.Drawing.Size(242, 23)
        Me.txtCARD_NO.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(46, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Amount"
        '
        'dgvInvoice
        '
        Me.dgvInvoice.AllowUserToAddRows = False
        Me.dgvInvoice.AllowUserToDeleteRows = False
        Me.dgvInvoice.AllowUserToResizeColumns = False
        Me.dgvInvoice.AllowUserToResizeRows = False
        Me.dgvInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvInvoice.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvInvoice.Location = New System.Drawing.Point(3, 41)
        Me.dgvInvoice.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvInvoice.MultiSelect = False
        Me.dgvInvoice.Name = "dgvInvoice"
        Me.dgvInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvInvoice.Size = New System.Drawing.Size(1028, 122)
        Me.dgvInvoice.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsFindText, Me.ToolStripLabel11, Me.tsUncheckAll, Me.tsCheckAll, Me.ToolStripSeparator1, Me.tsTool})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1028, 37)
        Me.ToolStrip2.TabIndex = 11
        Me.ToolStrip2.Text = "ToolStrip2"
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
        'tsUncheckAll
        '
        Me.tsUncheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsUncheckAll.Image = Global.Automission.My.Resources.Resources.uncheck_box
        Me.tsUncheckAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUncheckAll.Name = "tsUncheckAll"
        Me.tsUncheckAll.Size = New System.Drawing.Size(34, 34)
        Me.tsUncheckAll.Text = "Unchecked All"
        '
        'tsCheckAll
        '
        Me.tsCheckAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsCheckAll.Image = Global.Automission.My.Resources.Resources.check_box
        Me.tsCheckAll.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCheckAll.Name = "tsCheckAll"
        Me.tsCheckAll.Size = New System.Drawing.Size(34, 34)
        Me.tsCheckAll.Text = "Auto Check"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 37)
        '
        'tsTool
        '
        Me.tsTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsTool.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DiscountToolStripMenuItem, Me.CreditToolStripMenuItem})
        Me.tsTool.Image = Global.Automission.My.Resources.Resources.l_config
        Me.tsTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTool.Name = "tsTool"
        Me.tsTool.Size = New System.Drawing.Size(46, 34)
        Me.tsTool.Text = "Applied Option"
        '
        'DiscountToolStripMenuItem
        '
        Me.DiscountToolStripMenuItem.Image = Global.Automission.My.Resources.Resources.i_desc
        Me.DiscountToolStripMenuItem.Name = "DiscountToolStripMenuItem"
        Me.DiscountToolStripMenuItem.Size = New System.Drawing.Size(145, 36)
        Me.DiscountToolStripMenuItem.Text = "Discount"
        '
        'CreditToolStripMenuItem
        '
        Me.CreditToolStripMenuItem.Image = Global.Automission.My.Resources.Resources.i_credit
        Me.CreditToolStripMenuItem.Name = "CreditToolStripMenuItem"
        Me.CreditToolStripMenuItem.Size = New System.Drawing.Size(145, 36)
        Me.CreditToolStripMenuItem.Text = "Credit"
        '
        'lblUNDEPOSITED_FUNDS_ACCOUNT_ID
        '
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Location = New System.Drawing.Point(759, 602)
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Name = "lblUNDEPOSITED_FUNDS_ACCOUNT_ID"
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Size = New System.Drawing.Size(31, 28)
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.TabIndex = 26
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Text = "5"
        Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID.Visible = False
        '
        'CARD_NO
        '
        Me.CARD_NO.AutoSize = True
        Me.CARD_NO.Location = New System.Drawing.Point(461, 143)
        Me.CARD_NO.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.CARD_NO.Name = "CARD_NO"
        Me.CARD_NO.Size = New System.Drawing.Size(59, 16)
        Me.CARD_NO.TabIndex = 14
        Me.CARD_NO.Text = "Card No"
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(109, 369)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTES.Size = New System.Drawing.Size(943, 23)
        Me.txtNOTES.TabIndex = 28
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(33, 373)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 27
        Me.Label14.Text = "Remarks"
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(945, 398)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(109, 16)
        Me.Label18.TabIndex = 23
        Me.Label18.Text = "Amount Applied"
        '
        'lblAMOUNT_APPLIED
        '
        Me.lblAMOUNT_APPLIED.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT_APPLIED.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT_APPLIED.Location = New System.Drawing.Point(834, 417)
        Me.lblAMOUNT_APPLIED.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAMOUNT_APPLIED.Name = "lblAMOUNT_APPLIED"
        Me.lblAMOUNT_APPLIED.Size = New System.Drawing.Size(213, 18)
        Me.lblAMOUNT_APPLIED.TabIndex = 32
        Me.lblAMOUNT_APPLIED.Text = "0.00"
        Me.lblAMOUNT_APPLIED.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(809, 417)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(247, 1)
        Me.Label15.TabIndex = 54
        '
        'cmbACCOUNTS_RECEIVABLE_ID
        '
        Me.cmbACCOUNTS_RECEIVABLE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbACCOUNTS_RECEIVABLE_ID.FormattingEnabled = True
        Me.cmbACCOUNTS_RECEIVABLE_ID.Location = New System.Drawing.Point(850, 108)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbACCOUNTS_RECEIVABLE_ID.Name = "cmbACCOUNTS_RECEIVABLE_ID"
        Me.cmbACCOUNTS_RECEIVABLE_ID.Size = New System.Drawing.Size(164, 24)
        Me.cmbACCOUNTS_RECEIVABLE_ID.TabIndex = 56
        '
        'AccountLabel
        '
        Me.AccountLabel.AutoSize = True
        Me.AccountLabel.Location = New System.Drawing.Point(779, 112)
        Me.AccountLabel.Name = "AccountLabel"
        Me.AccountLabel.Size = New System.Drawing.Size(66, 16)
        Me.AccountLabel.TabIndex = 55
        Me.AccountLabel.Text = "A/R Acct"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(14, 166)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1042, 196)
        Me.TabControl1.TabIndex = 57
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvInvoice)
        Me.TabPage1.Controls.Add(Me.ToolStrip2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1034, 167)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Debt Invoice"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'frmReceivePayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1067, 434)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmbACCOUNTS_RECEIVABLE_ID)
        Me.Controls.Add(Me.AccountLabel)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.lblAMOUNT_APPLIED)
        Me.Controls.Add(Me.dtpRECEIPT_DATE)
        Me.Controls.Add(Me.dtpCARD_EXPIRY_DATE)
        Me.Controls.Add(Me.OR_DATE)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.txtRECEIPT_REF_NO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.CARD_EXPIRED_DATE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.cmbPAYMENT_METHOD_ID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numAMOUNT)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCARD_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.CARD_NO)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblUNDEPOSITED_FUNDS_ACCOUNT_ID)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.OR_No)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmReceivePayment"
        Me.Text = "frmReceivePayment"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
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
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbPAYMENT_METHOD_ID As ComboBox
    Friend WithEvents numAMOUNT As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents dgvInvoice As DataGridView
    Friend WithEvents lblUNDEPOSITED_FUNDS_ACCOUNT_ID As Label
    Friend WithEvents txtRECEIPT_REF_NO As TextBox
    Friend WithEvents OR_No As Label
    Friend WithEvents dtpRECEIPT_DATE As DateTimePicker
    Friend WithEvents OR_DATE As Label
    Friend WithEvents dtpCARD_EXPIRY_DATE As DateTimePicker
    Friend WithEvents CARD_EXPIRED_DATE As Label
    Friend WithEvents txtCARD_NO As TextBox
    Friend WithEvents CARD_NO As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents SelectPagePrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents Label18 As Label
    Friend WithEvents lblAMOUNT_APPLIED As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents cmbACCOUNTS_RECEIVABLE_ID As ComboBox
    Friend WithEvents AccountLabel As Label
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents spJournal As ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripSeparator
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents tsUncheckAll As ToolStripButton
    Friend WithEvents tsCheckAll As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsTool As ToolStripSplitButton
    Friend WithEvents DiscountToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CreditToolStripMenuItem As ToolStripMenuItem
End Class
