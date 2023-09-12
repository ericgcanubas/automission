<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLessDiscountDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLessDiscountDetails))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numDAY_FROM = New System.Windows.Forms.NumericUpDown()
        Me.numDAY_TO = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numLESS_PERCENT = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.numDAY_FROM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDAY_TO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLESS_PERCENT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Description"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(86, 101)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(225, 22)
        Me.txtDESCRIPTION.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From"
        '
        'numDAY_FROM
        '
        Me.numDAY_FROM.Location = New System.Drawing.Point(86, 129)
        Me.numDAY_FROM.Name = "numDAY_FROM"
        Me.numDAY_FROM.Size = New System.Drawing.Size(84, 22)
        Me.numDAY_FROM.TabIndex = 3
        Me.numDAY_FROM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numDAY_TO
        '
        Me.numDAY_TO.Location = New System.Drawing.Point(86, 157)
        Me.numDAY_TO.Name = "numDAY_TO"
        Me.numDAY_TO.Size = New System.Drawing.Size(84, 22)
        Me.numDAY_TO.TabIndex = 5
        Me.numDAY_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To"
        '
        'numLESS_PERCENT
        '
        Me.numLESS_PERCENT.DecimalPlaces = 2
        Me.numLESS_PERCENT.Location = New System.Drawing.Point(86, 185)
        Me.numLESS_PERCENT.Name = "numLESS_PERCENT"
        Me.numLESS_PERCENT.Size = New System.Drawing.Size(84, 22)
        Me.numLESS_PERCENT.TabIndex = 7
        Me.numLESS_PERCENT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 187)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Less Percent"
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkINACTIVE.Location = New System.Drawing.Point(8, 213)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(92, 17)
        Me.chkINACTIVE.TabIndex = 8
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSaveNew, Me.ToolStripLabel2, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 53)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(322, 25)
        Me.ToolStrip1.TabIndex = 72
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSaveNew.Image = CType(resources.GetObject("tsSaveNew.Image"), System.Drawing.Image)
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = tsSaveNew.Name
        Me.tsSaveNew.Size = New System.Drawing.Size(39, 22)
        Me.tsSaveNew.Text = "Save"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel2.Text = "       "
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 53)
        Me.Panel1.TabIndex = 71
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(188, 25)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Less Discount Details"
        '
        'frmLessDiscountDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 239)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.numLESS_PERCENT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numDAY_TO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numDAY_FROM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLessDiscountDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Less Discount Details"
        CType(Me.numDAY_FROM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDAY_TO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLESS_PERCENT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents numDAY_FROM As NumericUpDown
    Friend WithEvents numDAY_TO As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numLESS_PERCENT As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label5 As Label
End Class
