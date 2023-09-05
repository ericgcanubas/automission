<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSTransactionList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOSTransactionList))
        Me.dgvLIST = New System.Windows.Forms.DataGridView()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.numLOG = New System.Windows.Forms.NumericUpDown()
        Me.miniToolStrip = New System.Windows.Forms.ToolStrip()
        Me.BunifuGradientPanel5 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel1 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.tsAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.tsUpdateItem = New System.Windows.Forms.ToolStripButton()
        Me.tsCancel = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        CType(Me.dgvLIST, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLOG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BunifuGradientPanel5.SuspendLayout()
        Me.BunifuGradientPanel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLIST
        '
        Me.dgvLIST.AllowUserToAddRows = False
        Me.dgvLIST.AllowUserToDeleteRows = False
        Me.dgvLIST.AllowUserToResizeColumns = False
        Me.dgvLIST.AllowUserToResizeRows = False
        Me.dgvLIST.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvLIST.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLIST.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvLIST.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvLIST.Location = New System.Drawing.Point(0, 29)
        Me.dgvLIST.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvLIST.MultiSelect = False
        Me.dgvLIST.Name = "dgvLIST"
        Me.dgvLIST.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLIST.Size = New System.Drawing.Size(699, 472)
        Me.dgvLIST.TabIndex = 0
        '
        'dtpDATE
        '
        Me.dtpDATE.Location = New System.Drawing.Point(273, 252)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(228, 23)
        Me.dtpDATE.TabIndex = 4
        Me.dtpDATE.Visible = False
        '
        'numLOG
        '
        Me.numLOG.Location = New System.Drawing.Point(631, 23)
        Me.numLOG.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numLOG.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numLOG.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.numLOG.Name = "numLOG"
        Me.numLOG.Size = New System.Drawing.Size(65, 23)
        Me.numLOG.TabIndex = 5
        Me.numLOG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numLOG.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'miniToolStrip
        '
        Me.miniToolStrip.AccessibleName = "New item selection"
        Me.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown
        Me.miniToolStrip.AutoSize = False
        Me.miniToolStrip.BackColor = System.Drawing.Color.Transparent
        Me.miniToolStrip.CanOverflow = False
        Me.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None
        Me.miniToolStrip.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.miniToolStrip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.miniToolStrip.Location = New System.Drawing.Point(309, 13)
        Me.miniToolStrip.Name = "miniToolStrip"
        Me.miniToolStrip.Size = New System.Drawing.Size(357, 46)
        Me.miniToolStrip.TabIndex = 9
        '
        'BunifuGradientPanel5
        '
        Me.BunifuGradientPanel5.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel5.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel5.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel5.Controls.Add(Me.Label2)
        Me.BunifuGradientPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BunifuGradientPanel5.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel5.GradientBottomRight = System.Drawing.Color.DodgerBlue
        Me.BunifuGradientPanel5.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.BunifuGradientPanel5.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel5.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel5.Name = "BunifuGradientPanel5"
        Me.BunifuGradientPanel5.Quality = 10
        Me.BunifuGradientPanel5.Size = New System.Drawing.Size(699, 29)
        Me.BunifuGradientPanel5.TabIndex = 162
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(182, 23)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Cashier Log List"
        '
        'BunifuGradientPanel1
        '
        Me.BunifuGradientPanel1.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel1.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel1.Controls.Add(Me.Label4)
        Me.BunifuGradientPanel1.Controls.Add(Me.ToolStrip2)
        Me.BunifuGradientPanel1.Controls.Add(Me.numLOG)
        Me.BunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.BunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.DodgerBlue
        Me.BunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.BunifuGradientPanel1.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel1.Location = New System.Drawing.Point(0, 501)
        Me.BunifuGradientPanel1.Name = "BunifuGradientPanel1"
        Me.BunifuGradientPanel1.Quality = 10
        Me.BunifuGradientPanel1.Size = New System.Drawing.Size(699, 49)
        Me.BunifuGradientPanel1.TabIndex = 163
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(647, 2)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Limit"
        '
        'ToolStrip2
        '
        Me.ToolStrip2.AutoSize = False
        Me.ToolStrip2.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsAdd, Me.ToolStripSeparator2, Me.ToolStripLabel1, Me.tsUpdateItem, Me.ToolStripSeparator1, Me.tsCancel})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 1)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(614, 46)
        Me.ToolStrip2.TabIndex = 9
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'tsAdd
        '
        Me.tsAdd.BackColor = System.Drawing.Color.Transparent
        Me.tsAdd.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsAdd.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAdd.Name = "tsAdd"
        Me.tsAdd.Size = New System.Drawing.Size(154, 43)
        Me.tsAdd.Text = "&New log - [F1]"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(83, 43)
        Me.ToolStripLabel1.Text = "               "
        '
        'tsUpdateItem
        '
        Me.tsUpdateItem.BackColor = System.Drawing.Color.Transparent
        Me.tsUpdateItem.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsUpdateItem.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsUpdateItem.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUpdateItem.Name = "tsUpdateItem"
        Me.tsUpdateItem.Size = New System.Drawing.Size(164, 43)
        Me.tsUpdateItem.Text = "&Select  - [enter]"
        '
        'tsCancel
        '
        Me.tsCancel.BackColor = System.Drawing.Color.Transparent
        Me.tsCancel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsCancel.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsCancel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCancel.Name = "tsCancel"
        Me.tsCancel.Size = New System.Drawing.Size(149, 43)
        Me.tsCancel.Text = "&Cancel - [Esc]"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 46)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 46)
        '
        'frmPOSTransactionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(699, 550)
        Me.Controls.Add(Me.dgvLIST)
        Me.Controls.Add(Me.BunifuGradientPanel1)
        Me.Controls.Add(Me.BunifuGradientPanel5)
        Me.Controls.Add(Me.dtpDATE)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSTransactionList"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Log"
        CType(Me.dgvLIST, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLOG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BunifuGradientPanel5.ResumeLayout(False)
        Me.BunifuGradientPanel5.PerformLayout()
        Me.BunifuGradientPanel1.ResumeLayout(False)
        Me.BunifuGradientPanel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvLIST As DataGridView
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents numLOG As NumericUpDown
    Friend WithEvents miniToolStrip As ToolStrip
    Friend WithEvents BunifuGradientPanel5 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents BunifuGradientPanel1 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents tsAdd As ToolStripButton
    Friend WithEvents tsUpdateItem As ToolStripButton
    Friend WithEvents tsCancel As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
End Class
