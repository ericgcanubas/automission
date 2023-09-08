<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubDiscountDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSubDiscountDetails))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.numPercent = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numTO_AMOUNT = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numAMOUNT_FROM = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvSub = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numTO_AMOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAMOUNT_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSub, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(19, 62)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(123, 23)
        Me.txtCODE.TabIndex = 13
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(152, 62)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(362, 23)
        Me.txtDESCRIPTION.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(147, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Description"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numPercent)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.numTO_AMOUNT)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.numAMOUNT_FROM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dgvSub)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 115)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(498, 338)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Vol Details"
        '
        'numPercent
        '
        Me.numPercent.Location = New System.Drawing.Point(360, 55)
        Me.numPercent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numPercent.Name = "numPercent"
        Me.numPercent.Size = New System.Drawing.Size(130, 23)
        Me.numPercent.TabIndex = 19
        Me.numPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(355, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Percentage"
        '
        'numTO_AMOUNT
        '
        Me.numTO_AMOUNT.DecimalPlaces = 2
        Me.numTO_AMOUNT.Location = New System.Drawing.Point(179, 55)
        Me.numTO_AMOUNT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numTO_AMOUNT.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numTO_AMOUNT.Name = "numTO_AMOUNT"
        Me.numTO_AMOUNT.Size = New System.Drawing.Size(160, 23)
        Me.numTO_AMOUNT.TabIndex = 17
        Me.numTO_AMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(176, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Vol To"
        '
        'numAMOUNT_FROM
        '
        Me.numAMOUNT_FROM.DecimalPlaces = 2
        Me.numAMOUNT_FROM.Location = New System.Drawing.Point(8, 55)
        Me.numAMOUNT_FROM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numAMOUNT_FROM.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numAMOUNT_FROM.Name = "numAMOUNT_FROM"
        Me.numAMOUNT_FROM.Size = New System.Drawing.Size(160, 23)
        Me.numAMOUNT_FROM.TabIndex = 15
        Me.numAMOUNT_FROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 16)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Vol From"
        '
        'dgvSub
        '
        Me.dgvSub.AllowUserToAddRows = False
        Me.dgvSub.AllowUserToDeleteRows = False
        Me.dgvSub.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSub.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSub.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSub.Location = New System.Drawing.Point(8, 90)
        Me.dgvSub.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvSub.Name = "dgvSub"
        Me.dgvSub.ReadOnly = True
        Me.dgvSub.Size = New System.Drawing.Size(482, 241)
        Me.dgvSub.TabIndex = 13
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel2, Me.tsDiscard, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(527, 25)
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSaveNew.Image = CType(resources.GetObject("tsSaveNew.Image"), System.Drawing.Image)
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(44, 22)
        Me.tsSaveNew.Text = "Save"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel2.Text = "       "
        '
        'tsDiscard
        '
        Me.tsDiscard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDiscard.Image = CType(resources.GetObject("tsDiscard.Image"), System.Drawing.Image)
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(59, 22)
        Me.tsDiscard.Text = "Discard"
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(46, 22)
        Me.tsClose.Text = "Close"
        '
        'frmSubDiscountDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 471)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSubDiscountDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sub Discount Details"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numPercent, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numTO_AMOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAMOUNT_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSub, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents numPercent As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents numTO_AMOUNT As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents numAMOUNT_FROM As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvSub As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsClose As ToolStripButton
End Class
