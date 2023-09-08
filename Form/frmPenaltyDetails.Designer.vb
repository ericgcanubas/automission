<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPenaltyDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPenaltyDetails))
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblBALANCE_DUE = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblPENALTY_TYPE = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDAY_OVER = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblPENALTY_RATE = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPENALTY_AMOUNT = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblPENALTY_PER_DAY = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblTOTAL_PENALTY = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblTOTAL_BALANCE = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel2.Text = "       "
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 62)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(462, 25)
        Me.ToolStrip1.TabIndex = 93
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(55, 55)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(69, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Penalty"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(462, 62)
        Me.Panel1.TabIndex = 92
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Name"
        '
        'lblName
        '
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblName.Location = New System.Drawing.Point(123, 97)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(327, 24)
        Me.lblName.TabIndex = 95
        '
        'lblBALANCE_DUE
        '
        Me.lblBALANCE_DUE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBALANCE_DUE.Location = New System.Drawing.Point(123, 131)
        Me.lblBALANCE_DUE.Name = "lblBALANCE_DUE"
        Me.lblBALANCE_DUE.Size = New System.Drawing.Size(146, 24)
        Me.lblBALANCE_DUE.TabIndex = 97
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 96
        Me.Label4.Text = "Balance Due"
        '
        'lblPENALTY_TYPE
        '
        Me.lblPENALTY_TYPE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPENALTY_TYPE.Location = New System.Drawing.Point(123, 164)
        Me.lblPENALTY_TYPE.Name = "lblPENALTY_TYPE"
        Me.lblPENALTY_TYPE.Size = New System.Drawing.Size(146, 24)
        Me.lblPENALTY_TYPE.TabIndex = 99
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 164)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 98
        Me.Label6.Text = "Penalty Type"
        '
        'lblDAY_OVER
        '
        Me.lblDAY_OVER.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDAY_OVER.Location = New System.Drawing.Point(123, 199)
        Me.lblDAY_OVER.Name = "lblDAY_OVER"
        Me.lblDAY_OVER.Size = New System.Drawing.Size(146, 24)
        Me.lblDAY_OVER.TabIndex = 101
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 199)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 100
        Me.Label8.Text = "Day Over"
        '
        'lblPENALTY_RATE
        '
        Me.lblPENALTY_RATE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPENALTY_RATE.Location = New System.Drawing.Point(123, 232)
        Me.lblPENALTY_RATE.Name = "lblPENALTY_RATE"
        Me.lblPENALTY_RATE.Size = New System.Drawing.Size(146, 24)
        Me.lblPENALTY_RATE.TabIndex = 103
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 233)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(88, 13)
        Me.Label10.TabIndex = 102
        Me.Label10.Text = "Penalty Rate (%)"
        '
        'lblPENALTY_AMOUNT
        '
        Me.lblPENALTY_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPENALTY_AMOUNT.Location = New System.Drawing.Point(123, 266)
        Me.lblPENALTY_AMOUNT.Name = "lblPENALTY_AMOUNT"
        Me.lblPENALTY_AMOUNT.Size = New System.Drawing.Size(146, 24)
        Me.lblPENALTY_AMOUNT.TabIndex = 105
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 266)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(91, 13)
        Me.Label12.TabIndex = 104
        Me.Label12.Text = "Penalty  Amount"
        '
        'lblPENALTY_PER_DAY
        '
        Me.lblPENALTY_PER_DAY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPENALTY_PER_DAY.Location = New System.Drawing.Point(123, 299)
        Me.lblPENALTY_PER_DAY.Name = "lblPENALTY_PER_DAY"
        Me.lblPENALTY_PER_DAY.Size = New System.Drawing.Size(146, 24)
        Me.lblPENALTY_PER_DAY.TabIndex = 107
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 299)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 106
        Me.Label14.Text = "Penalty  Per Day"
        '
        'lblTOTAL_PENALTY
        '
        Me.lblTOTAL_PENALTY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTOTAL_PENALTY.Location = New System.Drawing.Point(123, 333)
        Me.lblTOTAL_PENALTY.Name = "lblTOTAL_PENALTY"
        Me.lblTOTAL_PENALTY.Size = New System.Drawing.Size(146, 24)
        Me.lblTOTAL_PENALTY.TabIndex = 109
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 333)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 13)
        Me.Label16.TabIndex = 108
        Me.Label16.Text = "Total Penalty"
        '
        'lblTOTAL_BALANCE
        '
        Me.lblTOTAL_BALANCE.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTOTAL_BALANCE.Location = New System.Drawing.Point(123, 368)
        Me.lblTOTAL_BALANCE.Name = "lblTOTAL_BALANCE"
        Me.lblTOTAL_BALANCE.Size = New System.Drawing.Size(146, 24)
        Me.lblTOTAL_BALANCE.TabIndex = 111
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 369)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(74, 13)
        Me.Label18.TabIndex = 110
        Me.Label18.Text = "Total Balance"
        '
        'frmPenaltyDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 421)
        Me.Controls.Add(Me.lblTOTAL_BALANCE)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblTOTAL_PENALTY)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.lblPENALTY_PER_DAY)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblPENALTY_AMOUNT)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblPENALTY_RATE)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblDAY_OVER)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.lblPENALTY_TYPE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblBALANCE_DUE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPenaltyDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penalty"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblBALANCE_DUE As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblPENALTY_TYPE As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDAY_OVER As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblPENALTY_RATE As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lblPENALTY_AMOUNT As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents lblPENALTY_PER_DAY As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents lblTOTAL_PENALTY As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents lblTOTAL_BALANCE As Label
    Friend WithEvents Label18 As Label
End Class
