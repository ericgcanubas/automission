<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAccount
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
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.txtNAME = New System.Windows.Forms.TextBox()
        Me.cmbGROUP_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.Save = New System.Windows.Forms.Button()
        Me.Cancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbTYPE
        '
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(155, 15)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(331, 24)
        Me.cmbTYPE.TabIndex = 41
        '
        'txtNAME
        '
        Me.txtNAME.Location = New System.Drawing.Point(155, 42)
        Me.txtNAME.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(331, 23)
        Me.txtNAME.TabIndex = 42
        '
        'cmbGROUP_ACCOUNT_ID
        '
        Me.cmbGROUP_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbGROUP_ACCOUNT_ID.Location = New System.Drawing.Point(155, 69)
        Me.cmbGROUP_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbGROUP_ACCOUNT_ID.Name = "cmbGROUP_ACCOUNT_ID"
        Me.cmbGROUP_ACCOUNT_ID.Size = New System.Drawing.Size(331, 24)
        Me.cmbGROUP_ACCOUNT_ID.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(52, 18)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 16)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Account Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(108, 46)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 16)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(28, 73)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 16)
        Me.Label4.TabIndex = 46
        Me.Label4.Text = "Group of Account"
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.Location = New System.Drawing.Point(155, 102)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(80, 20)
        Me.chkINACTIVE.TabIndex = 47
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'Save
        '
        Me.Save.Location = New System.Drawing.Point(308, 102)
        Me.Save.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Save.Name = "Save"
        Me.Save.Size = New System.Drawing.Size(86, 28)
        Me.Save.TabIndex = 50
        Me.Save.Text = "&Save"
        Me.Save.UseVisualStyleBackColor = True
        '
        'Cancel
        '
        Me.Cancel.Location = New System.Drawing.Point(400, 102)
        Me.Cancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(86, 28)
        Me.Cancel.TabIndex = 51
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.UseVisualStyleBackColor = True
        '
        'FrmAccount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 144)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.Save)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbGROUP_ACCOUNT_ID)
        Me.Controls.Add(Me.txtNAME)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmAccount"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents txtNAME As TextBox
    Friend WithEvents cmbGROUP_ACCOUNT_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents Save As Button
    Friend WithEvents Cancel As Button
End Class
