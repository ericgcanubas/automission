<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemGroupDetails
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
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbITEM_TYPE = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(20, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(58, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "Code"
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(105, 40)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(289, 23)
        Me.txtDESCRIPTION.TabIndex = 66
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(105, 13)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(143, 23)
        Me.txtCODE.TabIndex = 65
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(26, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Item Type"
        '
        'cmbITEM_TYPE
        '
        Me.cmbITEM_TYPE.AccessibleDescription = "0"
        Me.cmbITEM_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbITEM_TYPE.FormattingEnabled = True
        Me.cmbITEM_TYPE.Location = New System.Drawing.Point(105, 68)
        Me.cmbITEM_TYPE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbITEM_TYPE.Name = "cmbITEM_TYPE"
        Me.cmbITEM_TYPE.Size = New System.Drawing.Size(289, 24)
        Me.cmbITEM_TYPE.TabIndex = 70
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(215, 116)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 73
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(308, 116)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 74
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmItemGroupDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(410, 160)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbITEM_TYPE)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemGroupDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Group"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbITEM_TYPE As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
