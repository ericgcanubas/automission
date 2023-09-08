<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBinLocation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBinLocation))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.tsCreate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsUpdate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsReload = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tsSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.dgvBinLocation = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvBinLocation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.tsCreate, Me.ToolStripSeparator1, Me.tsUpdate, Me.ToolStripSeparator2, Me.tsDelete, Me.ToolStripSeparator3, Me.tsReload, Me.ToolStripSeparator4, Me.tsTITLE, Me.ToolStripLabel1, Me.tsTxtSearch, Me.tsSearch, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(939, 55)
        Me.ToolStrip1.TabIndex = 38
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
        'tsCreate
        '
        Me.tsCreate.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsCreate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCreate.Name = "tsCreate"
        Me.tsCreate.Size = New System.Drawing.Size(50, 49)
        Me.tsCreate.Text = "Create"
        Me.tsCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'tsUpdate
        '
        Me.tsUpdate.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUpdate.Name = "tsUpdate"
        Me.tsUpdate.Size = New System.Drawing.Size(51, 49)
        Me.tsUpdate.Text = "Update"
        Me.tsUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 52)
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(48, 49)
        Me.tsDelete.Text = "Delete"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 52)
        '
        'tsReload
        '
        Me.tsReload.Image = Global.Automission.My.Resources.Resources.l_reload
        Me.tsReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReload.Name = "tsReload"
        Me.tsReload.Size = New System.Drawing.Size(50, 49)
        Me.tsReload.Text = "Reload"
        Me.tsReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 52)
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(88, 49)
        Me.ToolStripLabel1.Text = "        Search :"
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(171, 52)
        '
        'tsSearch
        '
        Me.tsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSearch.Image = Global.Automission.My.Resources.Resources.l_read
        Me.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(36, 49)
        Me.tsSearch.Text = "Search"
        Me.tsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 52)
        '
        'dgvBinLocation
        '
        Me.dgvBinLocation.AllowUserToAddRows = False
        Me.dgvBinLocation.AllowUserToDeleteRows = False
        Me.dgvBinLocation.AllowUserToOrderColumns = True
        Me.dgvBinLocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBinLocation.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvBinLocation.ColumnHeadersHeight = 35
        Me.dgvBinLocation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBinLocation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvBinLocation.Location = New System.Drawing.Point(0, 55)
        Me.dgvBinLocation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvBinLocation.MultiSelect = False
        Me.dgvBinLocation.Name = "dgvBinLocation"
        Me.dgvBinLocation.ReadOnly = True
        Me.dgvBinLocation.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvBinLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBinLocation.Size = New System.Drawing.Size(939, 183)
        Me.dgvBinLocation.TabIndex = 39
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 238)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 18, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(939, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 40
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
        'frmBinLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 260)
        Me.Controls.Add(Me.dgvBinLocation)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmBinLocation"
        Me.Text = "frmBinLocation"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvBinLocation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents dgvBinLocation As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblRow As ToolStripStatusLabel
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents tsCreate As ToolStripButton
    Friend WithEvents tsUpdate As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents tsReload As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsTxtSearch As ToolStripTextBox
    Friend WithEvents tsSearch As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class
