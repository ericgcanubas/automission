<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserType
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.cmbUserType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOLD_PASSWORD = New System.Windows.Forms.TextBox()
        Me.txtNEW_PASSWORD = New System.Windows.Forms.TextBox()
        Me.txtCONFIRM_PASSWORD = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(371, 55)
        Me.Panel1.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Change User Type"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 55)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(371, 25)
        Me.ToolStrip1.TabIndex = 65
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(36, 22)
        Me.ToolStripLabel2.Text = "       "
        '
        'cmbUserType
        '
        Me.cmbUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUserType.FormattingEnabled = True
        Me.cmbUserType.Location = New System.Drawing.Point(147, 75)
        Me.cmbUserType.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbUserType.Name = "cmbUserType"
        Me.cmbUserType.Size = New System.Drawing.Size(210, 24)
        Me.cmbUserType.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "User Type"
        '
        'txtOLD_PASSWORD
        '
        Me.txtOLD_PASSWORD.Location = New System.Drawing.Point(147, 108)
        Me.txtOLD_PASSWORD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtOLD_PASSWORD.Name = "txtOLD_PASSWORD"
        Me.txtOLD_PASSWORD.Size = New System.Drawing.Size(210, 23)
        Me.txtOLD_PASSWORD.TabIndex = 68
        '
        'txtNEW_PASSWORD
        '
        Me.txtNEW_PASSWORD.Location = New System.Drawing.Point(147, 138)
        Me.txtNEW_PASSWORD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNEW_PASSWORD.Name = "txtNEW_PASSWORD"
        Me.txtNEW_PASSWORD.Size = New System.Drawing.Size(210, 23)
        Me.txtNEW_PASSWORD.TabIndex = 69
        '
        'txtCONFIRM_PASSWORD
        '
        Me.txtCONFIRM_PASSWORD.Location = New System.Drawing.Point(147, 167)
        Me.txtCONFIRM_PASSWORD.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCONFIRM_PASSWORD.Name = "txtCONFIRM_PASSWORD"
        Me.txtCONFIRM_PASSWORD.Size = New System.Drawing.Size(210, 23)
        Me.txtCONFIRM_PASSWORD.TabIndex = 70
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 16)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Old Password"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 16)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "New Password"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 16)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Confirm Password"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(148, 198)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(90, 30)
        Me.btnSave.TabIndex = 74
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(265, 198)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 30)
        Me.btnCancel.TabIndex = 75
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmUserType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 243)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCONFIRM_PASSWORD)
        Me.Controls.Add(Me.txtNEW_PASSWORD)
        Me.Controls.Add(Me.txtOLD_PASSWORD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUserType)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserType"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Type"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripLabel2 As ToolStripLabel
    Friend WithEvents cmbUserType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOLD_PASSWORD As TextBox
    Friend WithEvents txtNEW_PASSWORD As TextBox
    Friend WithEvents txtCONFIRM_PASSWORD As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
