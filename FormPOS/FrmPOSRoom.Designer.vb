<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSRoom
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOSRoom))
        Me.tsPanel = New System.Windows.Forms.ToolStrip()
        Me.tsMenu = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsAllRoom = New System.Windows.Forms.ToolStripButton()
        Me.tsAvailableRoom = New System.Windows.Forms.ToolStripButton()
        Me.tsNotAvailableRoom = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.flpBox = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnRoom = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsDown = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsUp = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.tsShowRoom = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUsername = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tsPanel.SuspendLayout()
        Me.flpBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsPanel
        '
        Me.tsPanel.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.tsPanel.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsPanel.ImageScalingSize = New System.Drawing.Size(50, 50)
        Me.tsPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsMenu, Me.ToolStripSeparator2, Me.tsAllRoom, Me.tsAvailableRoom, Me.tsNotAvailableRoom, Me.ToolStripSeparator1, Me.ToolStripLabel1})
        Me.tsPanel.Location = New System.Drawing.Point(0, 0)
        Me.tsPanel.Name = "tsPanel"
        Me.tsPanel.Size = New System.Drawing.Size(771, 77)
        Me.tsPanel.TabIndex = 0
        Me.tsPanel.Text = "ToolStrip1"
        '
        'tsMenu
        '
        Me.tsMenu.Image = Global.Automission.My.Resources.Resources.Logout
        Me.tsMenu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsMenu.Name = "tsMenu"
        Me.tsMenu.Size = New System.Drawing.Size(77, 74)
        Me.tsMenu.Text = "Log Panel"
        Me.tsMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 77)
        '
        'tsAllRoom
        '
        Me.tsAllRoom.Image = CType(resources.GetObject("tsAllRoom.Image"), System.Drawing.Image)
        Me.tsAllRoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAllRoom.Name = "tsAllRoom"
        Me.tsAllRoom.Size = New System.Drawing.Size(75, 74)
        Me.tsAllRoom.Text = "All Room"
        Me.tsAllRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsAvailableRoom
        '
        Me.tsAvailableRoom.Image = CType(resources.GetObject("tsAvailableRoom.Image"), System.Drawing.Image)
        Me.tsAvailableRoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAvailableRoom.Name = "tsAvailableRoom"
        Me.tsAvailableRoom.Size = New System.Drawing.Size(75, 74)
        Me.tsAvailableRoom.Text = "Available"
        Me.tsAvailableRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsNotAvailableRoom
        '
        Me.tsNotAvailableRoom.Image = CType(resources.GetObject("tsNotAvailableRoom.Image"), System.Drawing.Image)
        Me.tsNotAvailableRoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsNotAvailableRoom.Name = "tsNotAvailableRoom"
        Me.tsNotAvailableRoom.Size = New System.Drawing.Size(104, 74)
        Me.tsNotAvailableRoom.Text = "Not Available"
        Me.tsNotAvailableRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 77)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(314, 74)
        Me.ToolStripLabel1.Text = "Room Monitoring"
        '
        'flpBox
        '
        Me.flpBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flpBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.flpBox.Controls.Add(Me.btnRoom)
        Me.flpBox.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.flpBox.Location = New System.Drawing.Point(0, 77)
        Me.flpBox.Name = "flpBox"
        Me.flpBox.Size = New System.Drawing.Size(771, 221)
        Me.flpBox.TabIndex = 1
        '
        'btnRoom
        '
        Me.btnRoom.BackColor = System.Drawing.Color.DarkTurquoise
        Me.btnRoom.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRoom.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRoom.Image = Global.Automission.My.Resources.Resources.room_tag
        Me.btnRoom.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnRoom.Location = New System.Drawing.Point(3, 3)
        Me.btnRoom.Name = "btnRoom"
        Me.btnRoom.Size = New System.Drawing.Size(100, 100)
        Me.btnRoom.TabIndex = 8
        Me.btnRoom.Text = "201"
        Me.btnRoom.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnRoom.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.dgvList)
        Me.Panel1.Controls.Add(Me.ToolStrip1)
        Me.Panel1.Controls.Add(Me.StatusStrip2)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 304)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(771, 330)
        Me.Panel1.TabIndex = 3
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToResizeColumns = False
        Me.dgvList.AllowUserToResizeRows = False
        Me.dgvList.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvList.Location = New System.Drawing.Point(0, 0)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.RowHeadersWidth = 30
        Me.dgvList.ShowCellErrors = False
        Me.dgvList.ShowCellToolTips = False
        Me.dgvList.ShowEditingIcon = False
        Me.dgvList.ShowRowErrors = False
        Me.dgvList.Size = New System.Drawing.Size(771, 237)
        Me.dgvList.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsDown, Me.ToolStripLabel2, Me.tsUp, Me.ToolStripSeparator3, Me.ToolStripLabel3, Me.tsShowRoom})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 237)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(771, 68)
        Me.ToolStrip1.TabIndex = 6
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsDown
        '
        Me.tsDown.Image = Global.Automission.My.Resources.Resources.arrow_down
        Me.tsDown.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDown.Name = "tsDown"
        Me.tsDown.Size = New System.Drawing.Size(55, 65)
        Me.tsDown.Text = "Down"
        Me.tsDown.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(22, 65)
        Me.ToolStripLabel2.Text = "   "
        '
        'tsUp
        '
        Me.tsUp.Image = Global.Automission.My.Resources.Resources.arrow_up
        Me.tsUp.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUp.Name = "tsUp"
        Me.tsUp.Size = New System.Drawing.Size(50, 65)
        Me.tsUp.Text = "  Up  "
        Me.tsUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsUp.ToolTipText = "  Up  "
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 68)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(70, 65)
        Me.ToolStripLabel3.Text = "               "
        '
        'tsShowRoom
        '
        Me.tsShowRoom.Image = Global.Automission.My.Resources.Resources.edit
        Me.tsShowRoom.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsShowRoom.Name = "tsShowRoom"
        Me.tsShowRoom.Size = New System.Drawing.Size(63, 65)
        Me.tsShowRoom.Text = "Modify"
        Me.tsShowRoom.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsUsername})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 305)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New System.Drawing.Size(771, 25)
        Me.StatusStrip2.TabIndex = 5
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(65, 20)
        Me.ToolStripStatusLabel1.Text = "User ID:"
        '
        'tsUsername
        '
        Me.tsUsername.Name = "tsUsername"
        Me.tsUsername.Size = New System.Drawing.Size(61, 20)
        Me.tsUsername.Text = "User ID"
        '
        'Timer1
        '
        '
        'FrmPOSRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(771, 634)
        Me.Controls.Add(Me.flpBox)
        Me.Controls.Add(Me.tsPanel)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Name = "FrmPOSRoom"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Room Monintoring"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.tsPanel.ResumeLayout(False)
        Me.tsPanel.PerformLayout()
        Me.flpBox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tsPanel As ToolStrip
    Friend WithEvents tsAvailableRoom As ToolStripButton
    Friend WithEvents tsNotAvailableRoom As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents flpBox As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents tsAllRoom As ToolStripButton
    Friend WithEvents btnRoom As Button
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tsUsername As ToolStripStatusLabel
    Friend WithEvents tsMenu As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsDown As ToolStripButton
    Friend WithEvents tsUp As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsShowRoom As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
End Class
