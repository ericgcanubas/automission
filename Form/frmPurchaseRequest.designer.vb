<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPurchaseRequest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPurchaseRequest))
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_RATE = New System.Windows.Forms.Label()
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
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.cmbVENDOR_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_AMOUNT = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAddItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsEditItem = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsRemoveItem = New System.Windows.Forms.ToolStripButton()
        Me.tsFindText = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel11 = New System.Windows.Forms.ToolStripLabel()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.cmbINPUT_TAX_ID = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ToolStrip5 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel12 = New System.Windows.Forms.ToolStripLabel()
        Me.lblCount = New System.Windows.Forms.ToolStripLabel()
        Me.lblTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblNONTAXABLE_AMOUNT = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_VAT_METHOD = New System.Windows.Forms.Label()
        Me.lblINPUT_TAX_ACCOUNT_ID = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.ToolStrip5.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(514, 106)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(226, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(449, 110)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 16)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Location"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(743, 79)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(204, 23)
        Me.txtCODE.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(667, 82)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Reference"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(514, 79)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(146, 23)
        Me.dtpDATE.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(472, 82)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Date"
        '
        'lblINPUT_TAX_RATE
        '
        Me.lblINPUT_TAX_RATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_TAX_RATE.Location = New System.Drawing.Point(104, 309)
        Me.lblINPUT_TAX_RATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblINPUT_TAX_RATE.Name = "lblINPUT_TAX_RATE"
        Me.lblINPUT_TAX_RATE.Size = New System.Drawing.Size(51, 25)
        Me.lblINPUT_TAX_RATE.TabIndex = 73
        Me.lblINPUT_TAX_RATE.Text = "0"
        Me.lblINPUT_TAX_RATE.Visible = False
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel1, Me.tsDiscard, Me.ToolStripLabel2, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripButton1, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.ToolStripButton2, Me.ToolStripLabel8, Me.tsDelete, Me.ToolStripLabel7, Me.ToolStripButton4, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1163, 55)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 58
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
        'cmbVENDOR_ID
        '
        Me.cmbVENDOR_ID.FormattingEnabled = True
        Me.cmbVENDOR_ID.Location = New System.Drawing.Point(104, 79)
        Me.cmbVENDOR_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbVENDOR_ID.Name = "cmbVENDOR_ID"
        Me.cmbVENDOR_ID.Size = New System.Drawing.Size(342, 24)
        Me.cmbVENDOR_ID.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(48, 82)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Vendor"
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AllowUserToResizeColumns = False
        Me.dgvProductItem.AllowUserToResizeRows = False
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
        Me.dgvProductItem.Size = New System.Drawing.Size(1128, 209)
        Me.dgvProductItem.TabIndex = 0
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblAMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblAMOUNT.Location = New System.Drawing.Point(903, 470)
        Me.lblAMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(241, 21)
        Me.lblAMOUNT.TabIndex = 66
        Me.lblAMOUNT.Text = "0.00"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAMOUNT.Visible = False
        '
        'lblINPUT_TAX_AMOUNT
        '
        Me.lblINPUT_TAX_AMOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblINPUT_TAX_AMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblINPUT_TAX_AMOUNT.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblINPUT_TAX_AMOUNT.Location = New System.Drawing.Point(658, 470)
        Me.lblINPUT_TAX_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblINPUT_TAX_AMOUNT.Name = "lblINPUT_TAX_AMOUNT"
        Me.lblINPUT_TAX_AMOUNT.Size = New System.Drawing.Size(213, 21)
        Me.lblINPUT_TAX_AMOUNT.TabIndex = 65
        Me.lblINPUT_TAX_AMOUNT.Text = "0.00"
        Me.lblINPUT_TAX_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblINPUT_TAX_AMOUNT.Visible = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAddItem, Me.ToolStripLabel10, Me.tsEditItem, Me.ToolStripLabel9, Me.tsRemoveItem, Me.tsFindText, Me.ToolStripLabel11})
        Me.ToolStrip2.Location = New System.Drawing.Point(3, 4)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1128, 37)
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
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(83, 454)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(1068, 23)
        Me.txtNOTES.TabIndex = 61
        '
        'cmbINPUT_TAX_ID
        '
        Me.cmbINPUT_TAX_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbINPUT_TAX_ID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbINPUT_TAX_ID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbINPUT_TAX_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbINPUT_TAX_ID.FormattingEnabled = True
        Me.cmbINPUT_TAX_ID.Location = New System.Drawing.Point(539, 470)
        Me.cmbINPUT_TAX_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbINPUT_TAX_ID.Name = "cmbINPUT_TAX_ID"
        Me.cmbINPUT_TAX_ID.Size = New System.Drawing.Size(60, 24)
        Me.cmbINPUT_TAX_ID.TabIndex = 59
        Me.cmbINPUT_TAX_ID.Visible = False
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Location = New System.Drawing.Point(28, 457)
        Me.Label14.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 16)
        Me.Label14.TabIndex = 60
        Me.Label14.Text = "Notes"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Location = New System.Drawing.Point(14, 139)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1142, 308)
        Me.TabControl1.TabIndex = 67
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
        Me.TabPage1.Size = New System.Drawing.Size(1134, 279)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Item Entry"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ToolStrip5
        '
        Me.ToolStrip5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel12, Me.lblCount})
        Me.ToolStrip5.Location = New System.Drawing.Point(3, 250)
        Me.ToolStrip5.Name = "ToolStrip5"
        Me.ToolStrip5.Size = New System.Drawing.Size(1128, 25)
        Me.ToolStrip5.TabIndex = 156
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
        'lblTAXABLE_AMOUNT
        '
        Me.lblTAXABLE_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTAXABLE_AMOUNT.Location = New System.Drawing.Point(168, 137)
        Me.lblTAXABLE_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTAXABLE_AMOUNT.Name = "lblTAXABLE_AMOUNT"
        Me.lblTAXABLE_AMOUNT.Size = New System.Drawing.Size(51, 25)
        Me.lblTAXABLE_AMOUNT.TabIndex = 74
        Me.lblTAXABLE_AMOUNT.Text = "0"
        Me.lblTAXABLE_AMOUNT.Visible = False
        '
        'lblNONTAXABLE_AMOUNT
        '
        Me.lblNONTAXABLE_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNONTAXABLE_AMOUNT.Location = New System.Drawing.Point(229, 137)
        Me.lblNONTAXABLE_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblNONTAXABLE_AMOUNT.Name = "lblNONTAXABLE_AMOUNT"
        Me.lblNONTAXABLE_AMOUNT.Size = New System.Drawing.Size(51, 25)
        Me.lblNONTAXABLE_AMOUNT.TabIndex = 75
        Me.lblNONTAXABLE_AMOUNT.Text = "0"
        Me.lblNONTAXABLE_AMOUNT.Visible = False
        '
        'lblINPUT_TAX_VAT_METHOD
        '
        Me.lblINPUT_TAX_VAT_METHOD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_TAX_VAT_METHOD.Location = New System.Drawing.Point(306, 137)
        Me.lblINPUT_TAX_VAT_METHOD.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblINPUT_TAX_VAT_METHOD.Name = "lblINPUT_TAX_VAT_METHOD"
        Me.lblINPUT_TAX_VAT_METHOD.Size = New System.Drawing.Size(51, 25)
        Me.lblINPUT_TAX_VAT_METHOD.TabIndex = 76
        Me.lblINPUT_TAX_VAT_METHOD.Text = "0"
        Me.lblINPUT_TAX_VAT_METHOD.Visible = False
        '
        'lblINPUT_TAX_ACCOUNT_ID
        '
        Me.lblINPUT_TAX_ACCOUNT_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblINPUT_TAX_ACCOUNT_ID.Location = New System.Drawing.Point(367, 137)
        Me.lblINPUT_TAX_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblINPUT_TAX_ACCOUNT_ID.Name = "lblINPUT_TAX_ACCOUNT_ID"
        Me.lblINPUT_TAX_ACCOUNT_ID.Size = New System.Drawing.Size(51, 25)
        Me.lblINPUT_TAX_ACCOUNT_ID.TabIndex = 77
        Me.lblINPUT_TAX_ACCOUNT_ID.Text = "0"
        Me.lblINPUT_TAX_ACCOUNT_ID.Visible = False
        '
        'frmPurchaseRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1163, 494)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblINPUT_TAX_ACCOUNT_ID)
        Me.Controls.Add(Me.lblINPUT_TAX_VAT_METHOD)
        Me.Controls.Add(Me.lblNONTAXABLE_AMOUNT)
        Me.Controls.Add(Me.lblTAXABLE_AMOUNT)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.cmbVENDOR_ID)
        Me.Controls.Add(Me.lblINPUT_TAX_RATE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.lblINPUT_TAX_AMOUNT)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.cmbINPUT_TAX_ID)
        Me.Controls.Add(Me.Label14)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmPurchaseRequest"
        Me.Text = "frmPurchaseRequest"
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
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents lblINPUT_TAX_RATE As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents lblINPUT_TAX_AMOUNT As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents cmbINPUT_TAX_ID As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents PreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton4 As ToolStripButton
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAddItem As ToolStripButton
    Friend WithEvents ToolStripLabel10 As ToolStripSeparator
    Friend WithEvents tsEditItem As ToolStripButton
    Friend WithEvents ToolStripLabel9 As ToolStripSeparator
    Friend WithEvents tsRemoveItem As ToolStripButton
    Friend WithEvents cmbVENDOR_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents tsFindText As ToolStripTextBox
    Friend WithEvents ToolStripLabel11 As ToolStripLabel
    Friend WithEvents SelectPrintPageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripSeparator
    Friend WithEvents ToolStripLabel8 As ToolStripSeparator
    Friend WithEvents ToolStripLabel7 As ToolStripSeparator
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents ToolStrip5 As ToolStrip
    Friend WithEvents ToolStripLabel12 As ToolStripLabel
    Friend WithEvents lblCount As ToolStripLabel
    Friend WithEvents lblTAXABLE_AMOUNT As Label
    Friend WithEvents lblNONTAXABLE_AMOUNT As Label
    Friend WithEvents lblINPUT_TAX_VAT_METHOD As Label
    Friend WithEvents lblINPUT_TAX_ACCOUNT_ID As Label
End Class
