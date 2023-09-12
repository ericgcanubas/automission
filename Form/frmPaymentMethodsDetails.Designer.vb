<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPaymentMethodsDetails
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
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_TYPE = New System.Windows.Forms.ComboBox()
        Me.cmbGL_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(114, 42)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(375, 23)
        Me.txtDESCRIPTION.TabIndex = 97
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(31, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Description"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(114, 15)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(165, 23)
        Me.txtCODE.TabIndex = 95
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(71, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(10, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Payment Type"
        '
        'cmbPAYMENT_TYPE
        '
        Me.cmbPAYMENT_TYPE.AccessibleDescription = "0"
        Me.cmbPAYMENT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_TYPE.FormattingEnabled = True
        Me.cmbPAYMENT_TYPE.Location = New System.Drawing.Point(114, 69)
        Me.cmbPAYMENT_TYPE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPAYMENT_TYPE.Name = "cmbPAYMENT_TYPE"
        Me.cmbPAYMENT_TYPE.Size = New System.Drawing.Size(375, 24)
        Me.cmbPAYMENT_TYPE.TabIndex = 99
        '
        'cmbGL_ACCOUNT_ID
        '
        Me.cmbGL_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbGL_ACCOUNT_ID.Location = New System.Drawing.Point(114, 96)
        Me.cmbGL_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbGL_ACCOUNT_ID.Name = "cmbGL_ACCOUNT_ID"
        Me.cmbGL_ACCOUNT_ID.Size = New System.Drawing.Size(375, 24)
        Me.cmbGL_ACCOUNT_ID.TabIndex = 101
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(22, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "G/L Account"
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(312, 134)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 28)
        Me.btnOk.TabIndex = 102
        Me.btnOk.Text = "&Save"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(406, 134)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 103
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmPaymentMethodsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 176)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.cmbGL_ACCOUNT_ID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbPAYMENT_TYPE)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPaymentMethodsDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Methods"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbPAYMENT_TYPE As ComboBox
    Friend WithEvents cmbGL_ACCOUNT_ID As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
End Class
