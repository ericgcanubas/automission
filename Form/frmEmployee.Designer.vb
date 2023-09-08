<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployee
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmployee))
        Me.dgvEmployee = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsColumn = New System.Windows.Forms.ToolStripButton()
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
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvEmployee
        '
        Me.dgvEmployee.AllowUserToAddRows = False
        Me.dgvEmployee.AllowUserToDeleteRows = False
        Me.dgvEmployee.AllowUserToOrderColumns = True
        Me.dgvEmployee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmployee.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvEmployee.ColumnHeadersHeight = 35
        Me.dgvEmployee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvEmployee.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvEmployee.Location = New System.Drawing.Point(0, 55)
        Me.dgvEmployee.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvEmployee.Name = "dgvEmployee"
        Me.dgvEmployee.ReadOnly = True
        Me.dgvEmployee.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvEmployee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmployee.Size = New System.Drawing.Size(885, 353)
        Me.dgvEmployee.TabIndex = 10
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 408)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(885, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 13
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(107, 17)
        Me.ToolStripStatusLabel1.Text = "Record Count :"
        '
        'lblRow
        '
        Me.lblRow.BackColor = System.Drawing.Color.Transparent
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(15, 17)
        Me.lblRow.Text = "0"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsColumn, Me.tsCreate, Me.ToolStripSeparator1, Me.tsUpdate, Me.ToolStripSeparator2, Me.tsDelete, Me.ToolStripSeparator3, Me.tsReload, Me.ToolStripSeparator4, Me.tsTITLE, Me.ToolStripLabel1, Me.tsTxtSearch, Me.tsSearch, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(885, 55)
        Me.ToolStrip1.TabIndex = 61
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsColumn
        '
        Me.tsColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsColumn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsColumn.Image = CType(resources.GetObject("tsColumn.Image"), System.Drawing.Image)
        Me.tsColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsColumn.Name = "tsColumn"
        Me.tsColumn.Size = New System.Drawing.Size(23, 52)
        Me.tsColumn.Text = "*"
        '
        'tsCreate
        '
        Me.tsCreate.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsCreate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCreate.Name = "tsCreate"
        Me.tsCreate.Size = New System.Drawing.Size(55, 52)
        Me.tsCreate.Text = "Create"
        Me.tsCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'tsUpdate
        '
        Me.tsUpdate.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUpdate.Name = "tsUpdate"
        Me.tsUpdate.Size = New System.Drawing.Size(58, 52)
        Me.tsUpdate.Text = "Update"
        Me.tsUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(53, 52)
        Me.tsDelete.Text = "Delete"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 55)
        '
        'tsReload
        '
        Me.tsReload.Image = Global.Automission.My.Resources.Resources.l_reload
        Me.tsReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReload.Name = "tsReload"
        Me.tsReload.Size = New System.Drawing.Size(54, 52)
        Me.tsReload.Text = "Reload"
        Me.tsReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 55)
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
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(104, 52)
        Me.ToolStripLabel1.Text = "        Search :"
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(150, 55)
        '
        'tsSearch
        '
        Me.tsSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsSearch.Image = Global.Automission.My.Resources.Resources.l_read
        Me.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(36, 52)
        Me.tsSearch.Text = "Search"
        Me.tsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 55)
        '
        'frmEmployee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(885, 430)
        Me.Controls.Add(Me.dgvEmployee)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.Name = "frmEmployee"
        Me.Text = "Employee"
        CType(Me.dgvEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvEmployee As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblRow As ToolStripStatusLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsColumn As ToolStripButton
    Friend WithEvents tsCreate As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsUpdate As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsReload As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tsTxtSearch As ToolStripTextBox
    Friend WithEvents tsSearch As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class
