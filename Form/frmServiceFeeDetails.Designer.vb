<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmServiceFeeDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmServiceFeeDetails))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.numSERVICE_FEE_PCT = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numSALES_TARGET = New System.Windows.Forms.NumericUpDown()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMONTH_SF = New System.Windows.Forms.ComboBox()
        Me.cmbYEAR_SF = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.numSERVICE_FEE_PCT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numSALES_TARGET, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 81)
        Me.Panel1.TabIndex = 63
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(3, 1)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 77)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(80, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Service Fee"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel2, Me.tsDiscard, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 81)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(408, 25)
        Me.ToolStrip1.TabIndex = 70
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSaveNew.Image = CType(resources.GetObject("tsSaveNew.Image"), System.Drawing.Image)
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(95, 22)
        Me.tsSaveNew.Text = "Save and New"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel2.Text = "       "
        '
        'tsDiscard
        '
        Me.tsDiscard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsDiscard.Image = CType(resources.GetObject("tsDiscard.Image"), System.Drawing.Image)
        Me.tsDiscard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDiscard.Name = "tsDiscard"
        Me.tsDiscard.Size = New System.Drawing.Size(56, 22)
        Me.tsDiscard.Text = "Discard"
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(44, 22)
        Me.tsClose.Text = "Close"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 124)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Description"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(174, 120)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(208, 25)
        Me.txtDESCRIPTION.TabIndex = 72
        '
        'numSERVICE_FEE_PCT
        '
        Me.numSERVICE_FEE_PCT.Location = New System.Drawing.Point(174, 157)
        Me.numSERVICE_FEE_PCT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numSERVICE_FEE_PCT.Name = "numSERVICE_FEE_PCT"
        Me.numSERVICE_FEE_PCT.Size = New System.Drawing.Size(65, 25)
        Me.numSERVICE_FEE_PCT.TabIndex = 73
        Me.numSERVICE_FEE_PCT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(142, 17)
        Me.Label3.TabIndex = 74
        Me.Label3.Text = "Service Fee Percentage"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 17)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "Sales Target"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'numSALES_TARGET
        '
        Me.numSALES_TARGET.DecimalPlaces = 2
        Me.numSALES_TARGET.Location = New System.Drawing.Point(174, 193)
        Me.numSALES_TARGET.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numSALES_TARGET.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.numSALES_TARGET.Name = "numSALES_TARGET"
        Me.numSALES_TARGET.Size = New System.Drawing.Size(140, 25)
        Me.numSALES_TARGET.TabIndex = 75
        Me.numSALES_TARGET.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numSALES_TARGET.ThousandsSeparator = True
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkINACTIVE.Location = New System.Drawing.Point(10, 304)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(180, 22)
        Me.chkINACTIVE.TabIndex = 77
        Me.chkINACTIVE.Text = "Service Fee is Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(243, 159)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(19, 17)
        Me.Label5.TabIndex = 78
        Me.Label5.Text = "%"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cmbMONTH_SF
        '
        Me.cmbMONTH_SF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMONTH_SF.FormattingEnabled = True
        Me.cmbMONTH_SF.Location = New System.Drawing.Point(174, 230)
        Me.cmbMONTH_SF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbMONTH_SF.Name = "cmbMONTH_SF"
        Me.cmbMONTH_SF.Size = New System.Drawing.Size(140, 25)
        Me.cmbMONTH_SF.TabIndex = 79
        '
        'cmbYEAR_SF
        '
        Me.cmbYEAR_SF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYEAR_SF.FormattingEnabled = True
        Me.cmbYEAR_SF.Location = New System.Drawing.Point(174, 265)
        Me.cmbYEAR_SF.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbYEAR_SF.Name = "cmbYEAR_SF"
        Me.cmbYEAR_SF.Size = New System.Drawing.Size(65, 25)
        Me.cmbYEAR_SF.TabIndex = 80
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 233)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 17)
        Me.Label6.TabIndex = 81
        Me.Label6.Text = "Month"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 268)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 17)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Year"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'frmServiceFeeDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 339)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbYEAR_SF)
        Me.Controls.Add(Me.cmbMONTH_SF)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numSALES_TARGET)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numSERVICE_FEE_PCT)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmServiceFeeDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Service Fee"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.numSERVICE_FEE_PCT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numSALES_TARGET, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents numSERVICE_FEE_PCT As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents numSALES_TARGET As NumericUpDown
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbMONTH_SF As ComboBox
    Friend WithEvents cmbYEAR_SF As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
