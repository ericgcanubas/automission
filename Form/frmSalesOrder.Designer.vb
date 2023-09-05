<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSalesOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSalesOrder))
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPO_NUMBER = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDATE_NEEDED = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_TERMS_ID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
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
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.lblOUTPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
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
        Me.cmbOUTPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblOUTPUT_TAX_RATE = New System.Windows.Forms.Label()
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
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbCUSTOMER_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(107, 82)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(34, 86)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Customer"
        '
        'txtPO_NUMBER
        '
        Me.txtPO_NUMBER.Location = New System.Drawing.Point(319, 109)
        Me.txtPO_NUMBER.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPO_NUMBER.Name = "txtPO_NUMBER"
        Me.txtPO_NUMBER.Size = New System.Drawing.Size(131, 23)
        Me.txtPO_NUMBER.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(251, 112)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(65, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Ref# No."
        '
        'dtpDATE_NEEDED
        '
        Me.dtpDATE_NEEDED.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE_NEEDED.Location = New System.Drawing.Point(107, 137)
        Me.dtpDATE_NEEDED.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpDATE_NEEDED.Name = "dtpDATE_NEEDED"
        Me.dtpDATE_NEEDED.ShowCheckBox = True
        Me.dtpDATE_NEEDED.Size = New System.Drawing.Size(133, 23)
        Me.dtpDATE_NEEDED.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1, 140)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Date Received"
        '
        'cmbPAYMENT_TERMS_ID
        '
        Me.cmbPAYMENT_TERMS_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_TERMS_ID.FormattingEnabled = True
        Me.cmbPAYMENT_TERMS_ID.Location = New System.Drawing.Point(107, 110)
        Me.cmbPAYMENT_TERMS_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPAYMENT_TERMS_ID.Name = "cmbPAYMENT_TERMS_ID"
        Me.cmbPAYMENT_TERMS_ID.Size = New System.Drawing.Size(133, 24)
        Me.cmbPAYMENT_TERMS_ID.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 113)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Pmt Terms."
        '
        'cmbSALES_REP_ID
        '
        Me.cmbSALES_REP_ID.FormattingEnabled = True
        Me.cmbSALES_REP_ID.Location = New System.Drawing.Point(552, 134)
        Me.cmbSALES_REP_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSALES_REP_ID.Name = "cmbSALES_REP_ID"
        Me.cmbSALES_REP_ID.Size = New System.Drawing.Size(302, 24)
        Me.cmbSALES_REP_ID.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(477, 140)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 16)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Salesman"
        '
        'cmbCLASS_ID
        '
        Me.cmbCLASS_ID.FormattingEnabled = True
        Me.cmbCLASS_ID.Location = New System.Drawing.Point(921, 106)
        Me.cmbCLASS_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCLASS_ID.Name = "cmbCLASS_ID"
        Me.cmbCLASS_ID.Size = New System.Drawing.Size(174, 24)
        Me.cmbCLASS_ID.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(874, 110)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 16)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Class"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(552, 107)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(302, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(485, 113)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(921, 79)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(174, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(842, 82)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Reference"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(552, 80)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(133, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(508, 82)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.ToolStripLabel5, Me.ToolStripButton5, Me.ToolStripLabel8, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton4, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1149, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 31
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
        Me.ToolStripButton2.Text = "&History"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(98, 52)
        Me.ToolStripButton5.Text = "&Make Invoice"
        Me.ToolStripButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
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
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvProductItem.MultiSelect = False
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(1112, 198)
        Me.dgvProductItem.TabIndex = 0
        '
        'lblOUTPUT_TAX_VAT_METHOD
        '
        Me.lblOUTPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(765, 657)
        Me.lblOUTPUT_TAX_VAT_METHOD.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblOUTPUT_TAX_VAT_METHOD.Name = "lblOUTPUT_TAX_VAT_METHOD"
        Me.lblOUTPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(47, 25)
        Me.lblOUTPUT_TAX_VAT_METHOD.TabIndex = 42
        Me.lblOUTPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblOUTPUT_TAX_VAT_METHOD.Visible = False
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblAMOUNT.Location = New System.Drawing.Point(941, 521)
        Me.lblAMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(187, 21)
        Me.lblAMOUNT.TabIndex = 40
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOUTPUT_TAX_AMOUNT
        '
        Me.lblOUTPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOUTPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblOUTPUT_TAX_AMOUNT.ForeColor = System.Drawing.Color.Blue
        Me.lblOUTPUT_TAX_AMOUNT.Location = New System.Drawing.Point(733, 521)
        Me.lblOUTPUT_TAX_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblOUTPUT_TAX_AMOUNT.Name = "lblOUTPUT_TAX_AMOUNT"
        Me.lblOUTPUT_TAX_AMOUNT.Size = New System.Drawing.Size(173, 21)
        Me.lblOUTPUT_TAX_AMOUNT.TabIndex = 39
        Me.lblOUTPUT_TAX_AMOUNT.Text = "0.00"
        Me.lblOUTPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1112, 37)
        Me.ToolStrip2.TabIndex = 18
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
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.ForeColor = System.Drawing.Color.Blue
        Me.Label17.Location = New System.Drawing.Point(1082, 500)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 16)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Total "
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(319, 470)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTES.Size = New System.Drawing.Size(813, 23)
        Me.txtNOTES.TabIndex = 35
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.ForeColor = System.Drawing.Color.Blue
        Me.Label16.Location = New System.Drawing.Point(825, 500)
        Me.Label16.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(80, 16)
        Me.Label16.TabIndex = 37
        Me.Label16.Text = "Output Tax"
        '
        'cmbOUTPUT_TAX_ID
        '
        Me.cmbOUTPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbOUTPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbOUTPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbOUTPUT_TAX_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOUTPUT_TAX_ID.FormattingEnabled = True
        Me.cmbOUTPUT_TAX_ID.Location = New System.Drawing.Point(73, 470)
        Me.cmbOUTPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbOUTPUT_TAX_ID.Name = "cmbOUTPUT_TAX_ID"
        Me.cmbOUTPUT_TAX_ID.Size = New System.Drawing.Size(167, 24)
        Me.cmbOUTPUT_TAX_ID.TabIndex = 33
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(251, 474)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(61, 16)
        Me.Label14.TabIndex = 34
        Me.Label14.Text = "Remarks"
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Location = New System.Drawing.Point(17, 470)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
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
        Me.Label15.Location = New System.Drawing.Point(729, 518)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(401, 1)
        Me.Label15.TabIndex = 36
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.AutoSize = True
        Me.lblNONTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblNONTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(755, 695)
        Me.lblNONTAXABLE_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 77
        Me.lblNONTAXABLE_AMOUNT.Text = "0.00"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.AutoSize = True
        Me.lblTAXABLE_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblTAXABLE_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(827, 695)
        Me.lblTAXABLE_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(32, 17)
        Me.lblTAXABLE_AMOUNT.TabIndex = 76
        Me.lblTAXABLE_AMOUNT.Text = "0.00"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'lblOUTPUT_TAX_RATE
        '
        Me.lblOUTPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOUTPUT_TAX_RATE.Location = New System.Drawing.Point(706, 657)
        Me.lblOUTPUT_TAX_RATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblOUTPUT_TAX_RATE.Name = "lblOUTPUT_TAX_RATE"
        Me.lblOUTPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblOUTPUT_TAX_RATE.TabIndex = 78
        Me.lblOUTPUT_TAX_RATE.Text = "0"
        Me.lblOUTPUT_TAX_RATE.Visible = False
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
        Me.TabControl1.Size = New System.Drawing.Size(1126, 297)
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
        Me.TabPage1.Size = New System.Drawing.Size(1118, 268)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel12, Me.lblCount})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 239)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1112, 25)
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
        'frmSalesOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1149, 542)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.txtPO_NUMBER)
        Me.Controls.Add(Me.cmbSALES_REP_ID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.dtpDATE_NEEDED)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPAYMENT_TERMS_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbCLASS_ID)
        Me.Controls.Add(Me.lblOUTPUT_TAX_RATE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.lblOUTPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.lblOUTPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.cmbOUTPUT_TAX_ID)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmSalesOrder"
        Me.Text = "frmSalesOrder"
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
    Friend WithEvents txtPO_NUMBER As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpDATE_NEEDED As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbPAYMENT_TERMS_ID As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbSALES_REP_ID As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents cmbCLASS_ID As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents lblOUTPUT_TAX_VAT_METHOD As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents lblOUTPUT_TAX_AMOUNT As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents cmbOUTPUT_TAX_ID As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents lblOUTPUT_TAX_RATE As Label
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripSeparator
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents lblCount As ToolStripLabel
End Class
