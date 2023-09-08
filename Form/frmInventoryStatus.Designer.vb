<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventoryStatus
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInventoryStatus))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsItem = New System.Windows.Forms.ToolStripDropDownButton()
        Me.EditsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbSearch = New System.Windows.Forms.ToolStripComboBox()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbLocation = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tsItem, Me.tsClose, Me.ToolStripLabel1, Me.ToolStripLabel3, Me.tscmbSearch, Me.tsTxtSearch, Me.ToolStripLabel6, Me.ToolStripLabel2, Me.ToolStripLabel4, Me.tscmbLocation, Me.ToolStripLabel5, Me.tsbtnSearch})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 31)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(973, 40)
        Me.ToolStrip1.TabIndex = 19
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 37)
        Me.ToolStripButton1.Text = "*"
        '
        'tsItem
        '
        Me.tsItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditsToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.RefreshToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.tsItem.Image = CType(resources.GetObject("tsItem.Image"), System.Drawing.Image)
        Me.tsItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsItem.Name = "tsItem"
        Me.tsItem.Size = New System.Drawing.Size(43, 37)
        Me.tsItem.Text = "Files"
        Me.tsItem.Visible = False
        '
        'EditsToolStripMenuItem
        '
        Me.EditsToolStripMenuItem.Name = "EditsToolStripMenuItem"
        Me.EditsToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.EditsToolStripMenuItem.Text = "Edit"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(113, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(40, 37)
        Me.tsClose.Text = "Close"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(37, 37)
        Me.ToolStripLabel1.Text = "          "
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(71, 37)
        Me.ToolStripLabel3.Text = "Search Filter"
        '
        'tscmbSearch
        '
        Me.tscmbSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbSearch.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscmbSearch.Name = "tscmbSearch"
        Me.tscmbSearch.Size = New System.Drawing.Size(200, 40)
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(200, 40)
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(37, 37)
        Me.ToolStripLabel6.Text = "          "
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(6, 40)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(59, 37)
        Me.ToolStripLabel4.Text = "Location :"
        '
        'tscmbLocation
        '
        Me.tscmbLocation.BackColor = System.Drawing.Color.White
        Me.tscmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscmbLocation.Name = "tscmbLocation"
        Me.tscmbLocation.Size = New System.Drawing.Size(171, 40)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(6, 40)
        '
        'tsbtnSearch
        '
        Me.tsbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnSearch.Image = CType(resources.GetObject("tsbtnSearch.Image"), System.Drawing.Image)
        Me.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSearch.Name = "tsbtnSearch"
        Me.tsbtnSearch.Size = New System.Drawing.Size(50, 37)
        Me.tsbtnSearch.Text = "Refresh"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.White
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 31)
        Me.Panel1.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Inventory Status"
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.AllowUserToOrderColumns = True
        Me.dgvItem.AllowUserToResizeRows = False
        Me.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvItem.Location = New System.Drawing.Point(0, 71)
        Me.dgvItem.MultiSelect = False
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        Me.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItem.Size = New System.Drawing.Size(973, 402)
        Me.dgvItem.TabIndex = 20
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 473)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(973, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 35
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(86, 17)
        Me.ToolStripStatusLabel1.Text = "Record Count :"
        '
        'lblRow
        '
        Me.lblRow.BackColor = System.Drawing.Color.Transparent
        Me.lblRow.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(15, 17)
        Me.lblRow.Text = "0"
        '
        'frmInventoryStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(973, 495)
        Me.Controls.Add(Me.dgvItem)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmInventoryStatus"
        Me.Text = "frmInventoryStatus"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents tsItem As ToolStripDropDownButton
    Friend WithEvents EditsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents tscmbSearch As ToolStripComboBox
    Friend WithEvents tsTxtSearch As ToolStripTextBox
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents tscmbLocation As ToolStripComboBox
    Friend WithEvents ToolStripLabel5 As ToolStripSeparator
    Friend WithEvents tsbtnSearch As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvItem As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblRow As ToolStripStatusLabel
End Class
