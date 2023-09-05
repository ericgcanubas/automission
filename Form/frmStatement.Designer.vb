<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatement))
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsPrint = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsPreview = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.gpbReport = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gpbLocation = New System.Windows.Forms.GroupBox()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.dtpDATE_FROM = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpDATE_TO = New System.Windows.Forms.DateTimePicker()
        Me.cmbDateRange = New System.Windows.Forms.ComboBox()
        Me.gpbDateRange = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dtpDateStatement = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1.SuspendLayout()
        Me.gpbLocation.SuspendLayout()
        Me.gpbDateRange.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(17, 71)
        Me.ToolStripLabel3.Text = "  "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(50, 60)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsClose, Me.tsPrint, Me.ToolStripLabel2, Me.ToolStripSeparator1, Me.ToolStripLabel1, Me.tsPreview, Me.ToolStripLabel3, Me.ToolStripSeparator2, Me.ToolStripLabel4, Me.ToolStripLabel5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(910, 74)
        Me.ToolStrip1.TabIndex = 18
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(46, 71)
        Me.tsClose.Text = "Close"
        '
        'tsPrint
        '
        Me.tsPrint.Image = CType(resources.GetObject("tsPrint.Image"), System.Drawing.Image)
        Me.tsPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPrint.Name = "tsPrint"
        Me.tsPrint.Size = New System.Drawing.Size(54, 71)
        Me.tsPrint.Text = "&Print"
        Me.tsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(17, 71)
        Me.ToolStripLabel2.Text = "  "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 74)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(17, 71)
        Me.ToolStripLabel1.Text = "  "
        '
        'tsPreview
        '
        Me.tsPreview.Image = CType(resources.GetObject("tsPreview.Image"), System.Drawing.Image)
        Me.tsPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPreview.Name = "tsPreview"
        Me.tsPreview.Size = New System.Drawing.Size(62, 71)
        Me.tsPreview.Text = "P&review"
        Me.tsPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 74)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(112, 71)
        Me.ToolStripLabel4.Text = "                     "
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Segoe UI", 18.0!)
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(123, 71)
        Me.ToolStripLabel5.Text = "Statement"
        '
        'gpbReport
        '
        Me.gpbReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpbReport.Location = New System.Drawing.Point(16, 494)
        Me.gpbReport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbReport.Name = "gpbReport"
        Me.gpbReport.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbReport.Size = New System.Drawing.Size(265, 126)
        Me.gpbReport.TabIndex = 15
        Me.gpbReport.TabStop = False
        Me.gpbReport.Text = "Report Templete"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Location"
        '
        'gpbLocation
        '
        Me.gpbLocation.Controls.Add(Me.Label3)
        Me.gpbLocation.Controls.Add(Me.cmbLOCATION_ID)
        Me.gpbLocation.Location = New System.Drawing.Point(16, 388)
        Me.gpbLocation.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbLocation.Name = "gpbLocation"
        Me.gpbLocation.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbLocation.Size = New System.Drawing.Size(265, 98)
        Me.gpbLocation.TabIndex = 12
        Me.gpbLocation.TabStop = False
        Me.gpbLocation.Text = "Location Filter"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(8, 52)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(239, 24)
        Me.cmbLOCATION_ID.TabIndex = 10
        '
        'dtpDATE_FROM
        '
        Me.dtpDATE_FROM.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE_FROM.Location = New System.Drawing.Point(16, 84)
        Me.dtpDATE_FROM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE_FROM.Name = "dtpDATE_FROM"
        Me.dtpDATE_FROM.Size = New System.Drawing.Size(231, 23)
        Me.dtpDATE_FROM.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "To"
        '
        'dtpDATE_TO
        '
        Me.dtpDATE_TO.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE_TO.Location = New System.Drawing.Point(19, 148)
        Me.dtpDATE_TO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE_TO.Name = "dtpDATE_TO"
        Me.dtpDATE_TO.Size = New System.Drawing.Size(228, 23)
        Me.dtpDATE_TO.TabIndex = 7
        '
        'cmbDateRange
        '
        Me.cmbDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDateRange.FormattingEnabled = True
        Me.cmbDateRange.Location = New System.Drawing.Point(16, 27)
        Me.cmbDateRange.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbDateRange.Name = "cmbDateRange"
        Me.cmbDateRange.Size = New System.Drawing.Size(231, 24)
        Me.cmbDateRange.TabIndex = 0
        '
        'gpbDateRange
        '
        Me.gpbDateRange.Controls.Add(Me.Label2)
        Me.gpbDateRange.Controls.Add(Me.dtpDATE_TO)
        Me.gpbDateRange.Controls.Add(Me.dtpDATE_FROM)
        Me.gpbDateRange.Controls.Add(Me.Label1)
        Me.gpbDateRange.Controls.Add(Me.cmbDateRange)
        Me.gpbDateRange.Location = New System.Drawing.Point(16, 196)
        Me.gpbDateRange.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbDateRange.Name = "gpbDateRange"
        Me.gpbDateRange.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.gpbDateRange.Size = New System.Drawing.Size(265, 185)
        Me.gpbDateRange.TabIndex = 11
        Me.gpbDateRange.TabStop = False
        Me.gpbDateRange.Text = "Select Date Range"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtpDateStatement)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 124)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(265, 68)
        Me.GroupBox1.TabIndex = 19
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Statement Date"
        '
        'dtpDateStatement
        '
        Me.dtpDateStatement.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStatement.Location = New System.Drawing.Point(16, 26)
        Me.dtpDateStatement.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDateStatement.Name = "dtpDateStatement"
        Me.dtpDateStatement.Size = New System.Drawing.Size(231, 23)
        Me.dtpDateStatement.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.GroupBox2.Location = New System.Drawing.Point(289, 124)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(438, 68)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Customer"
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(23, 26)
        Me.cmbCUSTOMER_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(402, 24)
        Me.cmbCUSTOMER_ID.TabIndex = 1
        '
        'frmStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(910, 642)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.gpbReport)
        Me.Controls.Add(Me.gpbLocation)
        Me.Controls.Add(Me.gpbDateRange)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmStatement"
        Me.Text = "frmStatement"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.gpbLocation.ResumeLayout(False)
        Me.gpbLocation.PerformLayout()
        Me.gpbDateRange.ResumeLayout(False)
        Me.gpbDateRange.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents tsPrint As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tsPreview As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents gpbReport As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents gpbLocation As GroupBox
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents dtpDATE_FROM As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpDATE_TO As DateTimePicker
    Friend WithEvents cmbDateRange As ComboBox
    Friend WithEvents gpbDateRange As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents dtpDateStatement As DateTimePicker
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
End Class
