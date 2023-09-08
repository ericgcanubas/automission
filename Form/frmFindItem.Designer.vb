<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFindItem
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFindItem))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsItem = New System.Windows.Forms.ToolStripDropDownButton()
        Me.AddToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbLocation = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tsItem, Me.ToolStripLabel1, Me.ToolStripLabel3, Me.tsTxtSearch, Me.ToolStripLabel2, Me.ToolStripLabel4, Me.tscmbLocation, Me.ToolStripLabel5, Me.tsbtnSearch, Me.tsTITLE})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(885, 55)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 52)
        Me.ToolStripButton1.Text = "*"
        '
        'tsItem
        '
        Me.tsItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddToolStripMenuItem, Me.EditsToolStripMenuItem, Me.ExportToolStripMenuItem, Me.BarcodeToolStripMenuItem})
        Me.tsItem.Image = CType(resources.GetObject("tsItem.Image"), System.Drawing.Image)
        Me.tsItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsItem.Name = "tsItem"
        Me.tsItem.Size = New System.Drawing.Size(47, 49)
        Me.tsItem.Text = "Item"
        Me.tsItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsItem.Visible = False
        '
        'AddToolStripMenuItem
        '
        Me.AddToolStripMenuItem.Image = Global.Automission.My.Resources.Resources.l_create
        Me.AddToolStripMenuItem.Name = "AddToolStripMenuItem"
        Me.AddToolStripMenuItem.Size = New System.Drawing.Size(137, 38)
        Me.AddToolStripMenuItem.Text = "Create"
        '
        'EditsToolStripMenuItem
        '
        Me.EditsToolStripMenuItem.Image = Global.Automission.My.Resources.Resources.l_update
        Me.EditsToolStripMenuItem.Name = "EditsToolStripMenuItem"
        Me.EditsToolStripMenuItem.Size = New System.Drawing.Size(137, 38)
        Me.EditsToolStripMenuItem.Text = "Update"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(137, 38)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'BarcodeToolStripMenuItem
        '
        Me.BarcodeToolStripMenuItem.Name = "BarcodeToolStripMenuItem"
        Me.BarcodeToolStripMenuItem.Size = New System.Drawing.Size(137, 38)
        Me.BarcodeToolStripMenuItem.Text = "Barcode"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(79, 49)
        Me.ToolStripLabel3.Text = "Search Filter"
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(200, 52)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(54, 49)
        Me.ToolStripLabel4.Text = "Location"
        '
        'tscmbLocation
        '
        Me.tscmbLocation.BackColor = System.Drawing.Color.White
        Me.tscmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscmbLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmbLocation.Name = "tscmbLocation"
        Me.tscmbLocation.Size = New System.Drawing.Size(200, 52)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(6, 52)
        '
        'tsbtnSearch
        '
        Me.tsbtnSearch.Image = Global.Automission.My.Resources.Resources.l_reload
        Me.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSearch.Name = "tsbtnSearch"
        Me.tsbtnSearch.Size = New System.Drawing.Size(50, 49)
        Me.tsbtnSearch.Text = "Reload"
        Me.tsbtnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsTITLE
        '
        Me.tsTITLE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTITLE.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.tsTITLE.Image = Global.Automission.My.Resources.Resources.back_icon_set
        Me.tsTITLE.Name = "tsTITLE"
        Me.tsTITLE.Size = New System.Drawing.Size(104, 49)
        Me.tsTITLE.Text = "TITLE "
        Me.tsTITLE.Visible = False
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.AllowUserToOrderColumns = True
        Me.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvItem.Location = New System.Drawing.Point(0, 55)
        Me.dgvItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvItem.MultiSelect = False
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        Me.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItem.Size = New System.Drawing.Size(885, 370)
        Me.dgvItem.TabIndex = 18
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 425)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 18, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(885, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 34
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(107, 17)
        Me.ToolStripStatusLabel1.Text = "Record Count :"
        '
        'lblRow
        '
        Me.lblRow.BackColor = System.Drawing.Color.Transparent
        Me.lblRow.ForeColor = System.Drawing.Color.Blue
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(15, 17)
        Me.lblRow.Text = "0"
        '
        'frmFindItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 447)
        Me.ControlBox = False
        Me.Controls.Add(Me.dgvItem)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmFindItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Find Item"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
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
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents tscmbLocation As ToolStripComboBox
    Friend WithEvents tsbtnSearch As ToolStripButton
    Friend WithEvents dgvItem As DataGridView
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel5 As ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents tsTxtSearch As ToolStripTextBox
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblRow As ToolStripStatusLabel
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BarcodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AddToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripLabel1 As ToolStripSeparator
    Friend WithEvents tsTITLE As ToolStripLabel
End Class
