<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDeposit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDeposit))
        Me.cmbBANK_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgvDeposit = New System.Windows.Forms.DataGridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.PreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SelectPagePrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.spJournal = New System.Windows.Forms.ToolStripSeparator()
        Me.tsJournal = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPayment = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.cmbCASH_BACK_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numCASH_BACK_AMOUNT = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCASH_BACK_NOTES = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCount = New System.Windows.Forms.ToolStripLabel()
        CType(Me.dgvDeposit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.numCASH_BACK_AMOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbBANK_ACCOUNT_ID
        '
        Me.cmbBANK_ACCOUNT_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbBANK_ACCOUNT_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbBANK_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbBANK_ACCOUNT_ID.Location = New System.Drawing.Point(104, 79)
        Me.cmbBANK_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbBANK_ACCOUNT_ID.Name = "cmbBANK_ACCOUNT_ID"
        Me.cmbBANK_ACCOUNT_ID.Size = New System.Drawing.Size(329, 24)
        Me.cmbBANK_ACCOUNT_ID.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(34, 110)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 59
        Me.Label14.Text = "Remarks"
        '
        'txtNOTES
        '
        Me.txtNOTES.Location = New System.Drawing.Point(104, 106)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNOTES.Multiline = True
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTES.Size = New System.Drawing.Size(329, 52)
        Me.txtNOTES.TabIndex = 60
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Bank Acct."
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(513, 106)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(340, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(448, 110)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(709, 79)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(145, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(664, 82)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Code"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(513, 79)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(133, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(473, 82)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date"
        '
        'dgvDeposit
        '
        Me.dgvDeposit.AllowUserToAddRows = False
        Me.dgvDeposit.AllowUserToDeleteRows = False
        Me.dgvDeposit.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDeposit.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvDeposit.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDeposit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDeposit.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDeposit.Location = New System.Drawing.Point(3, 41)
        Me.dgvDeposit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvDeposit.MultiSelect = False
        Me.dgvDeposit.Name = "dgvDeposit"
        Me.dgvDeposit.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDeposit.Size = New System.Drawing.Size(1106, 171)
        Me.dgvDeposit.TabIndex = 0
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1106, 37)
        Me.ToolStrip2.TabIndex = 26
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
        Me.tsAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.tsEditItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.tsRemoveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT.Location = New System.Drawing.Point(890, 494)
        Me.lblAMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(239, 26)
        Me.lblAMOUNT.TabIndex = 55
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.ForeColor = System.Drawing.Color.Blue
        Me.Label18.Location = New System.Drawing.Point(1042, 478)
        Me.Label18.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(94, 16)
        Me.Label18.TabIndex = 54
        Me.Label18.Text = "Total Deposit"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripSeparator1, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.spJournal, Me.tsJournal, Me.ToolStripLabel6, Me.tsPayment, Me.ToolStripLabel8, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton4, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1144, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 62
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
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.m_printing
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(41, 52)
        Me.ToolStripButton1.Text = "Print"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'tsPayment
        '
        Me.tsPayment.Image = Global.Automission.My.Resources.Resources.m_payment
        Me.tsPayment.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPayment.Name = "tsPayment"
        Me.tsPayment.Size = New System.Drawing.Size(68, 52)
        Me.tsPayment.Text = "Payment"
        Me.tsPayment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        'cmbCASH_BACK_ACCOUNT_ID
        '
        Me.cmbCASH_BACK_ACCOUNT_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbCASH_BACK_ACCOUNT_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCASH_BACK_ACCOUNT_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCASH_BACK_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbCASH_BACK_ACCOUNT_ID.Location = New System.Drawing.Point(104, 443)
        Me.cmbCASH_BACK_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCASH_BACK_ACCOUNT_ID.Name = "cmbCASH_BACK_ACCOUNT_ID"
        Me.cmbCASH_BACK_ACCOUNT_ID.Size = New System.Drawing.Size(357, 24)
        Me.cmbCASH_BACK_ACCOUNT_ID.TabIndex = 64
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 448)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 16)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Return Acct."
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 475)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 65
        Me.Label4.Text = "Return Value"
        '
        'numCASH_BACK_AMOUNT
        '
        Me.numCASH_BACK_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numCASH_BACK_AMOUNT.DecimalPlaces = 2
        Me.numCASH_BACK_AMOUNT.Location = New System.Drawing.Point(104, 471)
        Me.numCASH_BACK_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCASH_BACK_AMOUNT.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        Me.numCASH_BACK_AMOUNT.Name = "numCASH_BACK_AMOUNT"
        Me.numCASH_BACK_AMOUNT.Size = New System.Drawing.Size(168, 23)
        Me.numCASH_BACK_AMOUNT.TabIndex = 66
        Me.numCASH_BACK_AMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCASH_BACK_AMOUNT.ThousandsSeparator = True
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(472, 449)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 67
        Me.Label5.Text = "Return remarks"
        '
        'txtCASH_BACK_NOTES
        '
        Me.txtCASH_BACK_NOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCASH_BACK_NOTES.Location = New System.Drawing.Point(587, 446)
        Me.txtCASH_BACK_NOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCASH_BACK_NOTES.Name = "txtCASH_BACK_NOTES"
        Me.txtCASH_BACK_NOTES.Size = New System.Drawing.Size(541, 23)
        Me.txtCASH_BACK_NOTES.TabIndex = 68
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.Location = New System.Drawing.Point(958, 494)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(177, 1)
        Me.Label15.TabIndex = 69
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
        Me.TabControl1.Size = New System.Drawing.Size(1120, 270)
        Me.TabControl1.TabIndex = 70
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvDeposit)
        Me.TabPage1.Controls.Add(Me.ToolStrip5)
        Me.TabPage1.Controls.Add(Me.ToolStrip2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 25)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabPage1.Size = New System.Drawing.Size(1112, 241)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Fund Details"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel12, Me.lblCount})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 212)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1106, 25)
        Me.ToolStrip5.TabIndex = 154
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
        'frmDeposit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1144, 516)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtCASH_BACK_NOTES)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbBANK_ACCOUNT_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numCASH_BACK_AMOUNT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbCASH_BACK_ACCOUNT_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmDeposit"
        Me.Text = "frmDeposit"
        CType(Me.dgvDeposit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.numCASH_BACK_AMOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.ToolStrip5.ResumeLayout(False)
        Me.ToolStrip5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbBANK_ACCOUNT_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents dgvDeposit As DataGridView
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents tsJournal As ToolStripButton
    Friend WithEvents tsPayment As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents Label14 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents cmbCASH_BACK_ACCOUNT_ID As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents numCASH_BACK_AMOUNT As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCASH_BACK_NOTES As TextBox
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents Label15 As Label
    Friend WithEvents SelectPagePrintToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripSeparator
    Friend WithEvents spJournal As ToolStripSeparator
    Friend WithEvents ToolStripLabel6 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripSeparator
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents lblCount As ToolStripLabel
End Class
