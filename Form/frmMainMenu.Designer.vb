<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMainMenu))
        Me.MenuStrip1 = New System.Windows.Forms.ToolStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindDocumentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FindItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SystemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SubMenuGroupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ResetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ThemeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PowerToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountJournalErrorsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AccountJournalDuplicateRemoveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrimaryKeyUpdaterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemInventoryFixedEndingQtyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.POSFixedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SCheckingJournalMissingValueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalesVsTaxSalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemCostUpdaterTransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemSalesTaxRecomputedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MergeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BIRInventoryReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UtilityToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSQuickAcces = New System.Windows.Forms.ToolStrip()
        Me.MyTab = New MdiTabControl.TabControl()
        Me.cmbSearchType = New System.Windows.Forms.ComboBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssConnection = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssSystemVer = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssUser_ID = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssUsername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssDatabase = New System.Windows.Forms.ToolStripStatusLabel()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.pnlSearch = New System.Windows.Forms.Panel()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.BunifuGradientPanel4 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlSideMenuList = New System.Windows.Forms.Panel()
        Me.pnlApplication = New System.Windows.Forms.Panel()
        Me.btnSearchApp = New System.Windows.Forms.Button()
        Me.txtSearchMenu = New System.Windows.Forms.TextBox()
        Me.trvApplication = New System.Windows.Forms.TreeView()
        Me.pnlFavorate = New System.Windows.Forms.Panel()
        Me.btnQuickButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgpTOp = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.BunifuGradientPanel1 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.pnlSearch.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BunifuGradientPanel4.SuspendLayout()
        Me.pnlSideMenuList.SuspendLayout()
        Me.pnlApplication.SuspendLayout()
        Me.pnlFavorate.SuspendLayout()
        Me.bgpTOp.SuspendLayout()
        Me.BunifuGradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ReportsToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.UtilityToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1350, 37)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(41, 33)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(69, 33)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindDocumentToolStripMenuItem, Me.FindItemToolStripMenuItem, Me.UserToolStripMenuItem, Me.ToolStripSeparator1, Me.SettingsToolStripMenuItem, Me.PowerToolsToolStripMenuItem, Me.ImportToolStripMenuItem})
        Me.ToolsToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(53, 33)
        Me.ToolsToolStripMenuItem.Text = "Tools"
        '
        'FindDocumentToolStripMenuItem
        '
        Me.FindDocumentToolStripMenuItem.Name = "FindDocumentToolStripMenuItem"
        Me.FindDocumentToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.FindDocumentToolStripMenuItem.Text = "Find Document"
        '
        'FindItemToolStripMenuItem
        '
        Me.FindItemToolStripMenuItem.Name = "FindItemToolStripMenuItem"
        Me.FindItemToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.FindItemToolStripMenuItem.Text = "Find Item"
        '
        'UserToolStripMenuItem
        '
        Me.UserToolStripMenuItem.Name = "UserToolStripMenuItem"
        Me.UserToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.UserToolStripMenuItem.Text = "User"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(169, 6)
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SystemToolStripMenuItem, Me.MenuToolStripMenuItem, Me.ToolStripMenuItem1, Me.SubMenuGroupToolStripMenuItem, Me.ResetToolStripMenuItem, Me.ThemeToolStripMenuItem, Me.ToolStripSeparator2})
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'SystemToolStripMenuItem
        '
        Me.SystemToolStripMenuItem.Name = "SystemToolStripMenuItem"
        Me.SystemToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.SystemToolStripMenuItem.Text = "System"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(182, 22)
        Me.ToolStripMenuItem1.Text = "Reports"
        '
        'SubMenuGroupToolStripMenuItem
        '
        Me.SubMenuGroupToolStripMenuItem.Name = "SubMenuGroupToolStripMenuItem"
        Me.SubMenuGroupToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.SubMenuGroupToolStripMenuItem.Text = "Sub Menu Group"
        '
        'ResetToolStripMenuItem
        '
        Me.ResetToolStripMenuItem.Name = "ResetToolStripMenuItem"
        Me.ResetToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ResetToolStripMenuItem.Text = "Reset"
        '
        'ThemeToolStripMenuItem
        '
        Me.ThemeToolStripMenuItem.Name = "ThemeToolStripMenuItem"
        Me.ThemeToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.ThemeToolStripMenuItem.Text = "Theme"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(179, 6)
        '
        'PowerToolsToolStripMenuItem
        '
        Me.PowerToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AccountJournalErrorsToolStripMenuItem, Me.AccountJournalDuplicateRemoveToolStripMenuItem, Me.PrimaryKeyUpdaterToolStripMenuItem, Me.ItemInventoryFixedEndingQtyToolStripMenuItem, Me.POSFixedToolStripMenuItem, Me.SCheckingJournalMissingValueToolStripMenuItem, Me.SalesVsTaxSalesToolStripMenuItem, Me.ItemCostUpdaterTransactionToolStripMenuItem, Me.ItemSalesTaxRecomputedToolStripMenuItem, Me.MergeToolStripMenuItem})
        Me.PowerToolsToolStripMenuItem.Name = "PowerToolsToolStripMenuItem"
        Me.PowerToolsToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.PowerToolsToolStripMenuItem.Text = "Power Tools"
        '
        'AccountJournalErrorsToolStripMenuItem
        '
        Me.AccountJournalErrorsToolStripMenuItem.Name = "AccountJournalErrorsToolStripMenuItem"
        Me.AccountJournalErrorsToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.AccountJournalErrorsToolStripMenuItem.Text = "Account Journal Errors"
        '
        'AccountJournalDuplicateRemoveToolStripMenuItem
        '
        Me.AccountJournalDuplicateRemoveToolStripMenuItem.Name = "AccountJournalDuplicateRemoveToolStripMenuItem"
        Me.AccountJournalDuplicateRemoveToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.AccountJournalDuplicateRemoveToolStripMenuItem.Text = "Account Journal Duplicate Remove"
        '
        'PrimaryKeyUpdaterToolStripMenuItem
        '
        Me.PrimaryKeyUpdaterToolStripMenuItem.Name = "PrimaryKeyUpdaterToolStripMenuItem"
        Me.PrimaryKeyUpdaterToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.PrimaryKeyUpdaterToolStripMenuItem.Text = "Primary Key Updater"
        '
        'ItemInventoryFixedEndingQtyToolStripMenuItem
        '
        Me.ItemInventoryFixedEndingQtyToolStripMenuItem.Name = "ItemInventoryFixedEndingQtyToolStripMenuItem"
        Me.ItemInventoryFixedEndingQtyToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ItemInventoryFixedEndingQtyToolStripMenuItem.Text = "Item Inventory Fixed Ending Qty"
        '
        'POSFixedToolStripMenuItem
        '
        Me.POSFixedToolStripMenuItem.Name = "POSFixedToolStripMenuItem"
        Me.POSFixedToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.POSFixedToolStripMenuItem.Text = "POS Fixed"
        '
        'SCheckingJournalMissingValueToolStripMenuItem
        '
        Me.SCheckingJournalMissingValueToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JournalToolStripMenuItem, Me.ReferenceToolStripMenuItem})
        Me.SCheckingJournalMissingValueToolStripMenuItem.Name = "SCheckingJournalMissingValueToolStripMenuItem"
        Me.SCheckingJournalMissingValueToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.SCheckingJournalMissingValueToolStripMenuItem.Text = "Checking Journal Missing Value"
        '
        'JournalToolStripMenuItem
        '
        Me.JournalToolStripMenuItem.Name = "JournalToolStripMenuItem"
        Me.JournalToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.JournalToolStripMenuItem.Text = "Journal"
        '
        'ReferenceToolStripMenuItem
        '
        Me.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem"
        Me.ReferenceToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ReferenceToolStripMenuItem.Text = "Reference"
        '
        'SalesVsTaxSalesToolStripMenuItem
        '
        Me.SalesVsTaxSalesToolStripMenuItem.Name = "SalesVsTaxSalesToolStripMenuItem"
        Me.SalesVsTaxSalesToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.SalesVsTaxSalesToolStripMenuItem.Text = "Sales Vs Tax Sales"
        '
        'ItemCostUpdaterTransactionToolStripMenuItem
        '
        Me.ItemCostUpdaterTransactionToolStripMenuItem.Name = "ItemCostUpdaterTransactionToolStripMenuItem"
        Me.ItemCostUpdaterTransactionToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ItemCostUpdaterTransactionToolStripMenuItem.Text = "Item Cost Updater Transaction"
        '
        'ItemSalesTaxRecomputedToolStripMenuItem
        '
        Me.ItemSalesTaxRecomputedToolStripMenuItem.Name = "ItemSalesTaxRecomputedToolStripMenuItem"
        Me.ItemSalesTaxRecomputedToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.ItemSalesTaxRecomputedToolStripMenuItem.Text = "Item Sales Tax Recomputed"
        '
        'MergeToolStripMenuItem
        '
        Me.MergeToolStripMenuItem.Name = "MergeToolStripMenuItem"
        Me.MergeToolStripMenuItem.Size = New System.Drawing.Size(302, 22)
        Me.MergeToolStripMenuItem.Text = "Merge"
        '
        'ImportToolStripMenuItem
        '
        Me.ImportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BIRInventoryReportToolStripMenuItem})
        Me.ImportToolStripMenuItem.Name = "ImportToolStripMenuItem"
        Me.ImportToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ImportToolStripMenuItem.Text = "Import"
        Me.ImportToolStripMenuItem.Visible = False
        '
        'BIRInventoryReportToolStripMenuItem
        '
        Me.BIRInventoryReportToolStripMenuItem.Name = "BIRInventoryReportToolStripMenuItem"
        Me.BIRInventoryReportToolStripMenuItem.Size = New System.Drawing.Size(212, 22)
        Me.BIRInventoryReportToolStripMenuItem.Text = "BIR Inventory Report"
        '
        'UtilityToolStripMenuItem
        '
        Me.UtilityToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.UtilityToolStripMenuItem.Name = "UtilityToolStripMenuItem"
        Me.UtilityToolStripMenuItem.Size = New System.Drawing.Size(57, 33)
        Me.UtilityToolStripMenuItem.Text = "Utility"
        '
        'TSQuickAcces
        '
        Me.TSQuickAcces.AutoSize = False
        Me.TSQuickAcces.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.TSQuickAcces.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSQuickAcces.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.TSQuickAcces.ImageScalingSize = New System.Drawing.Size(30, 30)
        Me.TSQuickAcces.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.TSQuickAcces.Location = New System.Drawing.Point(232, 40)
        Me.TSQuickAcces.Name = "TSQuickAcces"
        Me.TSQuickAcces.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.TSQuickAcces.Size = New System.Drawing.Size(1118, 56)
        Me.TSQuickAcces.TabIndex = 1
        Me.TSQuickAcces.Text = "ToolStrip1"
        '
        'MyTab
        '
        Me.MyTab.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MyTab.BackHighColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.MyTab.BackLowColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MyTab.BorderColor = System.Drawing.Color.Black
        Me.MyTab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MyTab.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyTab.ForeColor = System.Drawing.Color.Black
        Me.MyTab.ForeColorDisabled = System.Drawing.Color.Black
        Me.MyTab.Location = New System.Drawing.Point(232, 96)
        Me.MyTab.MenuRenderer = Nothing
        Me.MyTab.Name = "MyTab"
        Me.MyTab.Size = New System.Drawing.Size(1118, 611)
        Me.MyTab.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed
        Me.MyTab.TabBackHighColor = System.Drawing.Color.White
        Me.MyTab.TabBackHighColorDisabled = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MyTab.TabBackLowColor = System.Drawing.Color.White
        Me.MyTab.TabBorderEnhanced = True
        Me.MyTab.TabCloseButtonImage = Nothing
        Me.MyTab.TabCloseButtonImageDisabled = Nothing
        Me.MyTab.TabCloseButtonImageHot = Nothing
        Me.MyTab.TabGlassGradient = True
        Me.MyTab.TabHeight = 30
        Me.MyTab.TabIconSize = New System.Drawing.Size(23, 23)
        Me.MyTab.TabIndex = 2
        '
        'cmbSearchType
        '
        Me.cmbSearchType.BackColor = System.Drawing.Color.White
        Me.cmbSearchType.DropDownHeight = 107
        Me.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchType.DropDownWidth = 80
        Me.cmbSearchType.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.cmbSearchType.FormattingEnabled = True
        Me.cmbSearchType.IntegralHeight = False
        Me.cmbSearchType.Items.AddRange(New Object() {"Menu & Report", "Contact Name", "Reference No."})
        Me.cmbSearchType.Location = New System.Drawing.Point(51, 6)
        Me.cmbSearchType.Name = "cmbSearchType"
        Me.cmbSearchType.Size = New System.Drawing.Size(140, 24)
        Me.cmbSearchType.TabIndex = 17
        Me.cmbSearchType.TabStop = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssConnection, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.tssSystemVer, Me.ToolStripStatusLabel3, Me.tssUser_ID, Me.ToolStripStatusLabel4, Me.tssUsername, Me.tssDatabase})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 707)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1350, 22)
        Me.StatusStrip1.TabIndex = 19
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssConnection
        '
        Me.tssConnection.Name = "tssConnection"
        Me.tssConnection.Size = New System.Drawing.Size(35, 17)
        Me.tssConnection.Text = "XXXX"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel1.Text = "    "
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel2.Text = "    "
        '
        'tssSystemVer
        '
        Me.tssSystemVer.Name = "tssSystemVer"
        Me.tssSystemVer.Size = New System.Drawing.Size(31, 17)
        Me.tssSystemVer.Text = "FFFF"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel3.Text = "    "
        '
        'tssUser_ID
        '
        Me.tssUser_ID.Name = "tssUser_ID"
        Me.tssUser_ID.Size = New System.Drawing.Size(31, 17)
        Me.tssUser_ID.Text = "EEEE"
        Me.tssUser_ID.Visible = False
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(19, 17)
        Me.ToolStripStatusLabel4.Text = "    "
        '
        'tssUsername
        '
        Me.tssUsername.Name = "tssUsername"
        Me.tssUsername.Size = New System.Drawing.Size(31, 17)
        Me.tssUsername.Text = "TTTT"
        '
        'tssDatabase
        '
        Me.tssDatabase.Name = "tssDatabase"
        Me.tssDatabase.Size = New System.Drawing.Size(35, 17)
        Me.tssDatabase.Text = "ZZZZ"
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Location = New System.Drawing.Point(51, 33)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(140, 23)
        Me.txtSearch.TabIndex = 21
        Me.txtSearch.TabStop = False
        Me.txtSearch.Tag = ""
        '
        'pnlSearch
        '
        Me.pnlSearch.BackColor = System.Drawing.Color.White
        Me.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlSearch.Controls.Add(Me.BunifuGradientPanel4)
        Me.pnlSearch.Controls.Add(Me.dgvSearch)
        Me.pnlSearch.Controls.Add(Me.btnClose)
        Me.pnlSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlSearch.Location = New System.Drawing.Point(301, 119)
        Me.pnlSearch.Name = "pnlSearch"
        Me.pnlSearch.Size = New System.Drawing.Size(642, 267)
        Me.pnlSearch.TabIndex = 23
        Me.pnlSearch.Visible = False
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSearch.Location = New System.Drawing.Point(2, 27)
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.Size = New System.Drawing.Size(637, 237)
        Me.dgvSearch.TabIndex = 17
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Location = New System.Drawing.Point(618, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(22, 21)
        Me.btnClose.TabIndex = 18
        Me.btnClose.Text = "X"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'BunifuGradientPanel4
        '
        Me.BunifuGradientPanel4.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel4.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel4.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel4.Controls.Add(Me.Label2)
        Me.BunifuGradientPanel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.BunifuGradientPanel4.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuGradientPanel4.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel4.GradientBottomRight = System.Drawing.Color.MidnightBlue
        Me.BunifuGradientPanel4.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.BunifuGradientPanel4.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel4.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel4.Name = "BunifuGradientPanel4"
        Me.BunifuGradientPanel4.Quality = 10
        Me.BunifuGradientPanel4.Size = New System.Drawing.Size(640, 26)
        Me.BunifuGradientPanel4.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(3, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(139, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Quick Search Result"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'pnlSideMenuList
        '
        Me.pnlSideMenuList.BackColor = System.Drawing.Color.White
        Me.pnlSideMenuList.Controls.Add(Me.pnlApplication)
        Me.pnlSideMenuList.Controls.Add(Me.pnlFavorate)
        Me.pnlSideMenuList.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSideMenuList.Location = New System.Drawing.Point(0, 40)
        Me.pnlSideMenuList.Name = "pnlSideMenuList"
        Me.pnlSideMenuList.Size = New System.Drawing.Size(232, 667)
        Me.pnlSideMenuList.TabIndex = 25
        '
        'pnlApplication
        '
        Me.pnlApplication.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlApplication.Controls.Add(Me.BunifuGradientPanel1)
        Me.pnlApplication.Controls.Add(Me.btnSearchApp)
        Me.pnlApplication.Controls.Add(Me.txtSearchMenu)
        Me.pnlApplication.Controls.Add(Me.trvApplication)
        Me.pnlApplication.Location = New System.Drawing.Point(3, 65)
        Me.pnlApplication.Name = "pnlApplication"
        Me.pnlApplication.Size = New System.Drawing.Size(226, 599)
        Me.pnlApplication.TabIndex = 2
        '
        'btnSearchApp
        '
        Me.btnSearchApp.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnSearchApp.BackgroundImage = Global.Automission.My.Resources.Resources.m_search
        Me.btnSearchApp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSearchApp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchApp.Location = New System.Drawing.Point(194, 29)
        Me.btnSearchApp.Name = "btnSearchApp"
        Me.btnSearchApp.Size = New System.Drawing.Size(21, 23)
        Me.btnSearchApp.TabIndex = 25
        Me.btnSearchApp.UseVisualStyleBackColor = False
        '
        'txtSearchMenu
        '
        Me.txtSearchMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearchMenu.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchMenu.Location = New System.Drawing.Point(3, 29)
        Me.txtSearchMenu.Name = "txtSearchMenu"
        Me.txtSearchMenu.Size = New System.Drawing.Size(188, 23)
        Me.txtSearchMenu.TabIndex = 22
        Me.txtSearchMenu.TabStop = False
        Me.txtSearchMenu.Tag = ""
        '
        'trvApplication
        '
        Me.trvApplication.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trvApplication.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.trvApplication.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvApplication.FullRowSelect = True
        Me.trvApplication.HideSelection = False
        Me.trvApplication.Location = New System.Drawing.Point(0, 55)
        Me.trvApplication.Name = "trvApplication"
        Me.trvApplication.Size = New System.Drawing.Size(224, 540)
        Me.trvApplication.TabIndex = 1
        '
        'pnlFavorate
        '
        Me.pnlFavorate.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlFavorate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlFavorate.Controls.Add(Me.btnQuickButton)
        Me.pnlFavorate.Controls.Add(Me.Label3)
        Me.pnlFavorate.Controls.Add(Me.Label1)
        Me.pnlFavorate.Controls.Add(Me.cmbSearchType)
        Me.pnlFavorate.Controls.Add(Me.txtSearch)
        Me.pnlFavorate.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlFavorate.Location = New System.Drawing.Point(3, 2)
        Me.pnlFavorate.Name = "pnlFavorate"
        Me.pnlFavorate.Size = New System.Drawing.Size(226, 63)
        Me.pnlFavorate.TabIndex = 1
        '
        'btnQuickButton
        '
        Me.btnQuickButton.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnQuickButton.BackgroundImage = Global.Automission.My.Resources.Resources.m_search
        Me.btnQuickButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnQuickButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuickButton.Location = New System.Drawing.Point(194, 33)
        Me.btnQuickButton.Name = "btnQuickButton"
        Me.btnQuickButton.Size = New System.Drawing.Size(21, 21)
        Me.btnQuickButton.TabIndex = 24
        Me.btnQuickButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 37)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 16)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Entry"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Type"
        '
        'bgpTOp
        '
        Me.bgpTOp.BackColor = System.Drawing.Color.Black
        Me.bgpTOp.BackgroundImage = CType(resources.GetObject("bgpTOp.BackgroundImage"), System.Drawing.Image)
        Me.bgpTOp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bgpTOp.Controls.Add(Me.MenuStrip1)
        Me.bgpTOp.Dock = System.Windows.Forms.DockStyle.Top
        Me.bgpTOp.GradientBottomLeft = System.Drawing.Color.White
        Me.bgpTOp.GradientBottomRight = System.Drawing.Color.MidnightBlue
        Me.bgpTOp.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.bgpTOp.GradientTopRight = System.Drawing.Color.LightBlue
        Me.bgpTOp.Location = New System.Drawing.Point(0, 0)
        Me.bgpTOp.Name = "bgpTOp"
        Me.bgpTOp.Quality = 10
        Me.bgpTOp.Size = New System.Drawing.Size(1350, 40)
        Me.bgpTOp.TabIndex = 0
        '
        'BunifuGradientPanel1
        '
        Me.BunifuGradientPanel1.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel1.Controls.Add(Me.Label4)
        Me.BunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.BunifuGradientPanel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.MidnightBlue
        Me.BunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.BunifuGradientPanel1.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel1.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel1.Name = "BunifuGradientPanel1"
        Me.BunifuGradientPanel1.Quality = 10
        Me.BunifuGradientPanel1.Size = New System.Drawing.Size(224, 26)
        Me.BunifuGradientPanel1.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(3, 5)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 16)
        Me.Label4.TabIndex = 19
        Me.Label4.Text = "Menu List"
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1350, 729)
        Me.Controls.Add(Me.pnlSearch)
        Me.Controls.Add(Me.MyTab)
        Me.Controls.Add(Me.TSQuickAcces)
        Me.Controls.Add(Me.pnlSideMenuList)
        Me.Controls.Add(Me.bgpTOp)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Company"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.pnlSearch.ResumeLayout(False)
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BunifuGradientPanel4.ResumeLayout(False)
        Me.BunifuGradientPanel4.PerformLayout()
        Me.pnlSideMenuList.ResumeLayout(False)
        Me.pnlApplication.ResumeLayout(False)
        Me.pnlApplication.PerformLayout()
        Me.pnlFavorate.ResumeLayout(False)
        Me.pnlFavorate.PerformLayout()
        Me.bgpTOp.ResumeLayout(False)
        Me.BunifuGradientPanel1.ResumeLayout(False)
        Me.BunifuGradientPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TSQuickAcces As ToolStrip
    Friend WithEvents MyTab As MdiTabControl.TabControl
    Friend WithEvents cmbSearchType As ComboBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UtilityToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents tssConnection As ToolStripStatusLabel
    Friend WithEvents tssDatabase As ToolStripStatusLabel
    Friend WithEvents tssSystemVer As ToolStripStatusLabel
    Friend WithEvents tssUser_ID As ToolStripStatusLabel
    Friend WithEvents tssUsername As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents FindDocumentToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FindItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UserToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents SettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PowerToolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SystemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SubMenuGroupToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ThemeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ResetToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AccountJournalErrorsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AccountJournalDuplicateRemoveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PrimaryKeyUpdaterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemInventoryFixedEndingQtyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents POSFixedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SCheckingJournalMissingValueToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalesVsTaxSalesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemCostUpdaterTransactionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ItemSalesTaxRecomputedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents BIRInventoryReportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pnlSearch As Panel
    Friend WithEvents dgvSearch As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents MergeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JournalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReferenceToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer1 As Timer
    Friend WithEvents pnlSideMenuList As Panel
    Friend WithEvents pnlApplication As Panel
    Friend WithEvents pnlFavorate As Panel
    Friend WithEvents trvApplication As TreeView
    Friend WithEvents btnSearchApp As Button
    Friend WithEvents txtSearchMenu As TextBox
    Friend WithEvents btnQuickButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As ToolStrip
    Friend WithEvents bgpTOp As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents BunifuGradientPanel4 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents BunifuGradientPanel1 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label4 As Label
End Class
