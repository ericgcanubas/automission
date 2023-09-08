<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLocationDetails
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
        Me.txtNAME = New System.Windows.Forms.TextBox()
        Me.cmbPRICE_LEVEL_ID = New System.Windows.Forms.ComboBox()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtNAME
        '
        Me.txtNAME.Location = New System.Drawing.Point(99, 43)
        Me.txtNAME.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(322, 23)
        Me.txtNAME.TabIndex = 3
        '
        'cmbPRICE_LEVEL_ID
        '
        Me.cmbPRICE_LEVEL_ID.FormattingEnabled = True
        Me.cmbPRICE_LEVEL_ID.Location = New System.Drawing.Point(99, 71)
        Me.cmbPRICE_LEVEL_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPRICE_LEVEL_ID.Name = "cmbPRICE_LEVEL_ID"
        Me.cmbPRICE_LEVEL_ID.Size = New System.Drawing.Size(322, 24)
        Me.cmbPRICE_LEVEL_ID.TabIndex = 4
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkINACTIVE.Location = New System.Drawing.Point(99, 105)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(80, 20)
        Me.chkINACTIVE.TabIndex = 5
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(15, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(19, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "Price Level"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(54, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Code"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(99, 15)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(322, 23)
        Me.txtCODE.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(240, 105)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 65
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(335, 105)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 66
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmLocationDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 144)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.cmbPRICE_LEVEL_ID)
        Me.Controls.Add(Me.txtNAME)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLocationDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Location "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtNAME As TextBox
    Friend WithEvents cmbPRICE_LEVEL_ID As ComboBox
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
