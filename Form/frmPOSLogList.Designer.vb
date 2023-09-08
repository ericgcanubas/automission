<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSLogList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOSLogList))
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.RecomputeJournalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbLocation = New System.Windows.Forms.ToolStripComboBox()
        Me.tsbtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripSeparator()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvLog = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblRow
        '
        Me.lblRow.BackColor = System.Drawing.Color.Transparent
        Me.lblRow.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(15, 17)
        Me.lblRow.Text = "0"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 310)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 17, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(784, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 18
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(86, 17)
        Me.ToolStripStatusLabel1.Text = "Record Count :"
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(175, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(79, 22)
        Me.ToolStripLabel3.Text = "Search Filter"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripLabel1.Text = "          "
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(43, 22)
        Me.tsClose.Text = "Close"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RecomputeJournalToolStripMenuItem, Me.ExportToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = CType(resources.GetObject("ToolStripDropDownButton1.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(45, 22)
        Me.ToolStripDropDownButton1.Text = "Files"
        '
        'RecomputeJournalToolStripMenuItem
        '
        Me.RecomputeJournalToolStripMenuItem.Name = "RecomputeJournalToolStripMenuItem"
        Me.RecomputeJournalToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.RecomputeJournalToolStripMenuItem.Text = "Recompute Journal"
        '
        'ExportToolStripMenuItem
        '
        Me.ExportToolStripMenuItem.Name = "ExportToolStripMenuItem"
        Me.ExportToolStripMenuItem.Size = New System.Drawing.Size(183, 22)
        Me.ExportToolStripMenuItem.Text = "Export"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "*"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripDropDownButton1, Me.tsClose, Me.ToolStripLabel1, Me.ToolStripLabel3, Me.tsTxtSearch, Me.ToolStripLabel5, Me.ToolStripLabel4, Me.tscmbLocation, Me.tsbtnSearch, Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 32)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(784, 25)
        Me.ToolStrip1.TabIndex = 17
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(63, 22)
        Me.ToolStripLabel4.Text = "Location :"
        '
        'tscmbLocation
        '
        Me.tscmbLocation.BackColor = System.Drawing.Color.White
        Me.tscmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscmbLocation.Name = "tscmbLocation"
        Me.tscmbLocation.Size = New System.Drawing.Size(200, 25)
        '
        'tsbtnSearch
        '
        Me.tsbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbtnSearch.Image = CType(resources.GetObject("tsbtnSearch.Image"), System.Drawing.Image)
        Me.tsbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbtnSearch.Name = "tsbtnSearch"
        Me.tsbtnSearch.Size = New System.Drawing.Size(55, 17)
        Me.tsbtnSearch.Text = "Refresh"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(6, 25)
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(1, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(35, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(39, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POS Log"
        '
        'Panel1
        '
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(784, 32)
        Me.Panel1.TabIndex = 15
        '
        'dgvLog
        '
        Me.dgvLog.AllowUserToAddRows = False
        Me.dgvLog.AllowUserToDeleteRows = False
        Me.dgvLog.AllowUserToOrderColumns = True
        Me.dgvLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvLog.ColumnHeadersHeight = 35
        Me.dgvLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLog.Location = New System.Drawing.Point(0, 57)
        Me.dgvLog.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.dgvLog.MultiSelect = False
        Me.dgvLog.Name = "dgvLog"
        Me.dgvLog.ReadOnly = True
        Me.dgvLog.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLog.Size = New System.Drawing.Size(784, 253)
        Me.dgvLog.TabIndex = 16
        '
        'frmPOSLogList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 332)
        Me.Controls.Add(Me.dgvLog)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmPOSLogList"
        Me.Text = "POS Log List"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRow As ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tsTxtSearch As ToolStripTextBox
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripLabel5 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents tscmbLocation As ToolStripComboBox
    Friend WithEvents tsbtnSearch As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents RecomputeJournalToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgvLog As DataGridView
End Class
