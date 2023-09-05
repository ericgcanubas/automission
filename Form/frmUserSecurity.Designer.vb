<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserSecurity
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtFind2 = New System.Windows.Forms.TextBox()
        Me.chkPrint_Preview = New System.Windows.Forms.CheckBox()
        Me.chkFind = New System.Windows.Forms.CheckBox()
        Me.chkDelete = New System.Windows.Forms.CheckBox()
        Me.chkEdit = New System.Windows.Forms.CheckBox()
        Me.chkNew = New System.Windows.Forms.CheckBox()
        Me.chkAUTO = New System.Windows.Forms.CheckBox()
        Me.trvMENU = New System.Windows.Forms.TreeView()
        Me.dgvAccessControl = New System.Windows.Forms.DataGridView()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.xxxUserID = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvAccessControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtFind2)
        Me.GroupBox1.Controls.Add(Me.chkPrint_Preview)
        Me.GroupBox1.Controls.Add(Me.chkFind)
        Me.GroupBox1.Controls.Add(Me.chkDelete)
        Me.GroupBox1.Controls.Add(Me.chkEdit)
        Me.GroupBox1.Controls.Add(Me.chkNew)
        Me.GroupBox1.Controls.Add(Me.chkAUTO)
        Me.GroupBox1.Location = New System.Drawing.Point(395, 5)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(583, 95)
        Me.GroupBox1.TabIndex = 69
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Access Control"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(402, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(34, 16)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Find"
        '
        'txtFind2
        '
        Me.txtFind2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtFind2.Location = New System.Drawing.Point(406, 52)
        Me.txtFind2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFind2.Name = "txtFind2"
        Me.txtFind2.Size = New System.Drawing.Size(170, 23)
        Me.txtFind2.TabIndex = 6
        '
        'chkPrint_Preview
        '
        Me.chkPrint_Preview.AutoSize = True
        Me.chkPrint_Preview.Checked = True
        Me.chkPrint_Preview.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrint_Preview.Location = New System.Drawing.Point(270, 57)
        Me.chkPrint_Preview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkPrint_Preview.Name = "chkPrint_Preview"
        Me.chkPrint_Preview.Size = New System.Drawing.Size(126, 20)
        Me.chkPrint_Preview.TabIndex = 5
        Me.chkPrint_Preview.Text = "Print && Preview"
        Me.chkPrint_Preview.UseVisualStyleBackColor = True
        '
        'chkFind
        '
        Me.chkFind.AutoSize = True
        Me.chkFind.Checked = True
        Me.chkFind.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFind.Location = New System.Drawing.Point(207, 57)
        Me.chkFind.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkFind.Name = "chkFind"
        Me.chkFind.Size = New System.Drawing.Size(53, 20)
        Me.chkFind.TabIndex = 4
        Me.chkFind.Text = "Find"
        Me.chkFind.UseVisualStyleBackColor = True
        '
        'chkDelete
        '
        Me.chkDelete.AutoSize = True
        Me.chkDelete.Location = New System.Drawing.Point(133, 57)
        Me.chkDelete.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkDelete.Name = "chkDelete"
        Me.chkDelete.Size = New System.Drawing.Size(68, 20)
        Me.chkDelete.TabIndex = 3
        Me.chkDelete.Text = "Delete"
        Me.chkDelete.UseVisualStyleBackColor = True
        '
        'chkEdit
        '
        Me.chkEdit.AutoSize = True
        Me.chkEdit.Location = New System.Drawing.Point(73, 57)
        Me.chkEdit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkEdit.Name = "chkEdit"
        Me.chkEdit.Size = New System.Drawing.Size(51, 20)
        Me.chkEdit.TabIndex = 2
        Me.chkEdit.Text = "Edit"
        Me.chkEdit.UseVisualStyleBackColor = True
        '
        'chkNew
        '
        Me.chkNew.AutoSize = True
        Me.chkNew.Checked = True
        Me.chkNew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkNew.Location = New System.Drawing.Point(9, 57)
        Me.chkNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkNew.Name = "chkNew"
        Me.chkNew.Size = New System.Drawing.Size(54, 20)
        Me.chkNew.TabIndex = 1
        Me.chkNew.Text = "New"
        Me.chkNew.UseVisualStyleBackColor = True
        '
        'chkAUTO
        '
        Me.chkAUTO.AutoSize = True
        Me.chkAUTO.Checked = True
        Me.chkAUTO.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAUTO.Location = New System.Drawing.Point(8, 22)
        Me.chkAUTO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAUTO.Name = "chkAUTO"
        Me.chkAUTO.Size = New System.Drawing.Size(353, 20)
        Me.chkAUTO.TabIndex = 0
        Me.chkAUTO.Text = "Auto apply when checked from (Menu Tree View)"
        Me.chkAUTO.UseVisualStyleBackColor = True
        '
        'trvMENU
        '
        Me.trvMENU.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.trvMENU.CheckBoxes = True
        Me.trvMENU.FullRowSelect = True
        Me.trvMENU.HideSelection = False
        Me.trvMENU.Location = New System.Drawing.Point(6, 10)
        Me.trvMENU.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.trvMENU.Name = "trvMENU"
        Me.trvMENU.Size = New System.Drawing.Size(382, 479)
        Me.trvMENU.TabIndex = 68
        '
        'dgvAccessControl
        '
        Me.dgvAccessControl.AllowUserToAddRows = False
        Me.dgvAccessControl.AllowUserToDeleteRows = False
        Me.dgvAccessControl.AllowUserToOrderColumns = True
        Me.dgvAccessControl.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvAccessControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAccessControl.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvAccessControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccessControl.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAccessControl.Location = New System.Drawing.Point(395, 112)
        Me.dgvAccessControl.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvAccessControl.MultiSelect = False
        Me.dgvAccessControl.Name = "dgvAccessControl"
        Me.dgvAccessControl.ReadOnly = True
        Me.dgvAccessControl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvAccessControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccessControl.Size = New System.Drawing.Size(583, 377)
        Me.dgvAccessControl.TabIndex = 70
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(789, 497)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 71
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(891, 497)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 72
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 503)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 16)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Username :"
        '
        'xxxUserID
        '
        Me.xxxUserID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xxxUserID.AutoSize = True
        Me.xxxUserID.BackColor = System.Drawing.Color.Transparent
        Me.xxxUserID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxUserID.ForeColor = System.Drawing.Color.Navy
        Me.xxxUserID.Location = New System.Drawing.Point(100, 505)
        Me.xxxUserID.Name = "xxxUserID"
        Me.xxxUserID.Size = New System.Drawing.Size(52, 14)
        Me.xxxUserID.TabIndex = 74
        Me.xxxUserID.Text = "XXXXX"
        '
        'frmUserSecurity
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(985, 532)
        Me.Controls.Add(Me.xxxUserID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.dgvAccessControl)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.trvMENU)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserSecurity"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Security"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvAccessControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtFind2 As TextBox
    Friend WithEvents chkPrint_Preview As CheckBox
    Friend WithEvents chkFind As CheckBox
    Friend WithEvents chkDelete As CheckBox
    Friend WithEvents chkEdit As CheckBox
    Friend WithEvents chkNew As CheckBox
    Friend WithEvents chkAUTO As CheckBox
    Friend WithEvents trvMENU As TreeView
    Friend WithEvents dgvAccessControl As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents xxxUserID As Label
End Class
