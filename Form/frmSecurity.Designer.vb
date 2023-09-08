<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSecurity
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSecurity))
        Me.trvMENU = New System.Windows.Forms.TreeView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.tsDiscard = New System.Windows.Forms.ToolStripButton()
        Me.tsFind = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripDropDownButton2 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tsOption = New System.Windows.Forms.ToolStripDropDownButton()
        Me.SaveConfigOnUserTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateAllUserTypeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel9 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel10 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton5 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel8 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton6 = New System.Windows.Forms.ToolStripButton()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvUser = New System.Windows.Forms.DataGridView()
        Me.dgvAccessControl = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFind2 = New System.Windows.Forms.TextBox()
        Me.chkPrint_Preview = New System.Windows.Forms.CheckBox()
        Me.chkFind = New System.Windows.Forms.CheckBox()
        Me.chkDelete = New System.Windows.Forms.CheckBox()
        Me.chkEdit = New System.Windows.Forms.CheckBox()
        Me.chkNew = New System.Windows.Forms.CheckBox()
        Me.chkAUTO = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtFind = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccessControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'trvMENU
        '
        Me.trvMENU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trvMENU.CheckBoxes = True
        Me.trvMENU.FullRowSelect = True
        Me.trvMENU.HideSelection = False
        Me.trvMENU.Location = New System.Drawing.Point(389, 101)
        Me.trvMENU.Name = "trvMENU"
        Me.trvMENU.Size = New System.Drawing.Size(326, 400)
        Me.trvMENU.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(26, 26)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel7, Me.ToolStripSeparator1, Me.tsSave, Me.ToolStripLabel1, Me.ToolStripLabel2, Me.tsDiscard, Me.tsFind, Me.ToolStripLabel3, Me.ToolStripDropDownButton2, Me.ToolStripLabel4, Me.tsOption, Me.ToolStripLabel5, Me.ToolStripLabel9, Me.ToolStripLabel10, Me.ToolStripLabel6, Me.ToolStripButton5, Me.ToolStripLabel8, Me.ToolStripButton6, Me.tsClose})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 32)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1299, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 64
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(84, 22)
        Me.ToolStripLabel7.Text = "                   "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsSave
        '
        Me.tsSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSave.Image = CType(resources.GetObject("tsSave.Image"), System.Drawing.Image)
        Me.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSave.Name = "tsSave"
        Me.tsSave.Size = New System.Drawing.Size(40, 22)
        Me.tsSave.Text = "Save"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(12, 22)
        Me.ToolStripLabel1.Text = " "
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
        Me.tsDiscard.Visible = False
        '
        'tsFind
        '
        Me.tsFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsFind.Image = CType(resources.GetObject("tsFind.Image"), System.Drawing.Image)
        Me.tsFind.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsFind.Name = "tsFind"
        Me.tsFind.Size = New System.Drawing.Size(36, 22)
        Me.tsFind.Text = "Find"
        Me.tsFind.Visible = False
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel3.Text = "       "
        '
        'ToolStripDropDownButton2
        '
        Me.ToolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripDropDownButton2.Image = CType(resources.GetObject("ToolStripDropDownButton2.Image"), System.Drawing.Image)
        Me.ToolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton2.Name = "ToolStripDropDownButton2"
        Me.ToolStripDropDownButton2.Size = New System.Drawing.Size(47, 22)
        Me.ToolStripDropDownButton2.Text = "Print"
        Me.ToolStripDropDownButton2.Visible = False
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel4.Text = "       "
        Me.ToolStripLabel4.Visible = False
        '
        'tsOption
        '
        Me.tsOption.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsOption.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveConfigOnUserTypeToolStripMenuItem, Me.UpdateAllUserTypeToolStripMenuItem})
        Me.tsOption.Image = CType(resources.GetObject("tsOption.Image"), System.Drawing.Image)
        Me.tsOption.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOption.Name = "tsOption"
        Me.tsOption.Size = New System.Drawing.Size(61, 22)
        Me.tsOption.Text = "Option"
        '
        'SaveConfigOnUserTypeToolStripMenuItem
        '
        Me.SaveConfigOnUserTypeToolStripMenuItem.Name = "SaveConfigOnUserTypeToolStripMenuItem"
        Me.SaveConfigOnUserTypeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.SaveConfigOnUserTypeToolStripMenuItem.Text = "Update User Type"
        '
        'UpdateAllUserTypeToolStripMenuItem
        '
        Me.UpdateAllUserTypeToolStripMenuItem.Name = "UpdateAllUserTypeToolStripMenuItem"
        Me.UpdateAllUserTypeToolStripMenuItem.Size = New System.Drawing.Size(181, 22)
        Me.UpdateAllUserTypeToolStripMenuItem.Text = "Update All User"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel5.Text = "       "
        Me.ToolStripLabel5.Visible = False
        '
        'ToolStripLabel9
        '
        Me.ToolStripLabel9.Name = "ToolStripLabel9"
        Me.ToolStripLabel9.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel9.Text = "       "
        '
        'ToolStripLabel10
        '
        Me.ToolStripLabel10.Name = "ToolStripLabel10"
        Me.ToolStripLabel10.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel10.Text = "       "
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel6.Text = "       "
        Me.ToolStripLabel6.Visible = False
        '
        'ToolStripButton5
        '
        Me.ToolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton5.Image = CType(resources.GetObject("ToolStripButton5.Image"), System.Drawing.Image)
        Me.ToolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton5.Name = "ToolStripButton5"
        Me.ToolStripButton5.Size = New System.Drawing.Size(90, 22)
        Me.ToolStripButton5.Text = "Apply Credits"
        Me.ToolStripButton5.Visible = False
        '
        'ToolStripLabel8
        '
        Me.ToolStripLabel8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ToolStripLabel8.Name = "ToolStripLabel8"
        Me.ToolStripLabel8.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel8.Text = "       "
        '
        'ToolStripButton6
        '
        Me.ToolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton6.Image = CType(resources.GetObject("ToolStripButton6.Image"), System.Drawing.Image)
        Me.ToolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton6.Name = "ToolStripButton6"
        Me.ToolStripButton6.Size = New System.Drawing.Size(49, 22)
        Me.ToolStripButton6.Text = "Delete"
        Me.ToolStripButton6.Visible = False
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
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1299, 32)
        Me.Panel1.TabIndex = 63
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(2, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Security"
        '
        'dgvUser
        '
        Me.dgvUser.AllowUserToAddRows = False
        Me.dgvUser.AllowUserToDeleteRows = False
        Me.dgvUser.AllowUserToOrderColumns = True
        Me.dgvUser.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUser.Location = New System.Drawing.Point(2, 104)
        Me.dgvUser.MultiSelect = False
        Me.dgvUser.Name = "dgvUser"
        Me.dgvUser.ReadOnly = True
        Me.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUser.Size = New System.Drawing.Size(381, 398)
        Me.dgvUser.TabIndex = 65
        '
        'dgvAccessControl
        '
        Me.dgvAccessControl.AllowUserToAddRows = False
        Me.dgvAccessControl.AllowUserToDeleteRows = False
        Me.dgvAccessControl.AllowUserToOrderColumns = True
        Me.dgvAccessControl.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAccessControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAccessControl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvAccessControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccessControl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAccessControl.Location = New System.Drawing.Point(721, 159)
        Me.dgvAccessControl.MultiSelect = False
        Me.dgvAccessControl.Name = "dgvAccessControl"
        Me.dgvAccessControl.ReadOnly = True
        Me.dgvAccessControl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvAccessControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccessControl.Size = New System.Drawing.Size(572, 341)
        Me.dgvAccessControl.TabIndex = 66
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFind2)
        Me.GroupBox1.Controls.Add(Me.chkPrint_Preview)
        Me.GroupBox1.Controls.Add(Me.chkFind)
        Me.GroupBox1.Controls.Add(Me.chkDelete)
        Me.GroupBox1.Controls.Add(Me.chkEdit)
        Me.GroupBox1.Controls.Add(Me.chkNew)
        Me.GroupBox1.Controls.Add(Me.chkAUTO)
        Me.GroupBox1.Location = New System.Drawing.Point(721, 86)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(572, 68)
        Me.GroupBox1.TabIndex = 67
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Access Control"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(399, 27)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Find"
        '
        'txtFind2
        '
        Me.txtFind2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind2.Location = New System.Drawing.Point(399, 42)
        Me.txtFind2.Name = "txtFind2"
        Me.txtFind2.Size = New System.Drawing.Size(167, 21)
        Me.txtFind2.TabIndex = 6
        '
        'chkPrint_Preview
        '
        Me.chkPrint_Preview.AutoSize = True
        Me.chkPrint_Preview.Checked = True
        Me.chkPrint_Preview.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrint_Preview.Location = New System.Drawing.Point(236, 46)
        Me.chkPrint_Preview.Name = "chkPrint_Preview"
        Me.chkPrint_Preview.Size = New System.Drawing.Size(113, 17)
        Me.chkPrint_Preview.TabIndex = 5
        Me.chkPrint_Preview.Text = "Print && Preview"
        Me.chkPrint_Preview.UseVisualStyleBackColor = True
        '
        'chkFind
        '
        Me.chkFind.AutoSize = True
        Me.chkFind.Checked = True
        Me.chkFind.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFind.Location = New System.Drawing.Point(181, 46)
        Me.chkFind.Name = "chkFind"
        Me.chkFind.Size = New System.Drawing.Size(49, 17)
        Me.chkFind.TabIndex = 4
        Me.chkFind.Text = "Find"
        Me.chkFind.UseVisualStyleBackColor = True
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Location = New System.Drawing.Point(116, 46)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(63, 17)
        Me.chkDelete.TabIndex = 3
        Me.chkDelete.Text = "Delete"
        Me.chkDelete.UseVisualStyleBackColor = True
        '
        'chkEdit
        '
        Me.chkEdit.AutoSize = True
        Me.chkEdit.Location = New System.Drawing.Point(64, 46)
        Me.chkEdit.Name = "chkEdit"
        Me.chkEdit.Size = New System.Drawing.Size(47, 17)
        Me.chkEdit.TabIndex = 2
        Me.chkEdit.Text = "Edit"
        Me.chkEdit.UseVisualStyleBackColor = True
        '
        'chkNew
        '
        Me.chkNew.AutoSize = True
        Me.chkNew.Checked = True
        Me.chkNew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNew.Location = New System.Drawing.Point(8, 46)
        Me.chkNew.Name = "chkNew"
        Me.chkNew.Size = New System.Drawing.Size(50, 17)
        Me.chkNew.TabIndex = 1
        Me.chkNew.Text = "New"
        Me.chkNew.UseVisualStyleBackColor = True
        '
        'chkAUTO
        '
        Me.chkAUTO.AutoSize = True
        Me.chkAUTO.Checked = True
        Me.chkAUTO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAUTO.Location = New System.Drawing.Point(7, 18)
        Me.chkAUTO.Name = "chkAUTO"
        Me.chkAUTO.Size = New System.Drawing.Size(307, 17)
        Me.chkAUTO.TabIndex = 0
        Me.chkAUTO.Text = "Auto apply when checked from (Menu Tree View)"
        Me.chkAUTO.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(386, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Menu Tree View"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(189, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 13)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Find User :"
        '
        'txtFind
        '
        Me.txtFind.Location = New System.Drawing.Point(257, 82)
        Me.txtFind.Name = "txtFind"
        Me.txtFind.Size = New System.Drawing.Size(126, 21)
        Me.txtFind.TabIndex = 70
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 17)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "User List"
        '
        'frmSecurity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1299, 511)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFind)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvAccessControl)
        Me.Controls.Add(Me.dgvUser)
        Me.Controls.Add(Me.trvMENU)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSecurity"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Security"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccessControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents trvMENU As TreeView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsSave As ToolStripButton
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents tsDiscard As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents tsFind As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripLabel
    Friend WithEvents ToolStripDropDownButton2 As ToolStripDropDownButton
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripButton5 As ToolStripButton
    Friend WithEvents ToolStripLabel8 As ToolStripLabel
    Friend WithEvents ToolStripButton6 As ToolStripButton
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dgvUser As DataGridView
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents dgvAccessControl As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkPrint_Preview As CheckBox
    Friend WithEvents chkFind As CheckBox
    Friend WithEvents chkDelete As CheckBox
    Friend WithEvents chkEdit As CheckBox
    Friend WithEvents chkNew As CheckBox
    Friend WithEvents chkAUTO As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolStripLabel9 As ToolStripLabel
    Friend WithEvents ToolStripLabel10 As ToolStripLabel
    Friend WithEvents tsOption As ToolStripDropDownButton
    Friend WithEvents SaveConfigOnUserTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UpdateAllUserTypeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents txtFind As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFind2 As TextBox
End Class
