<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmailSetup
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGmailUsername = New System.Windows.Forms.TextBox()
        Me.txtGmailPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtGmailAddressTo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Username"
        '
        'txtGmailUsername
        '
        Me.txtGmailUsername.Location = New System.Drawing.Point(111, 23)
        Me.txtGmailUsername.Name = "txtGmailUsername"
        Me.txtGmailUsername.Size = New System.Drawing.Size(158, 21)
        Me.txtGmailUsername.TabIndex = 1
        '
        'txtGmailPassword
        '
        Me.txtGmailPassword.Location = New System.Drawing.Point(111, 49)
        Me.txtGmailPassword.Name = "txtGmailPassword"
        Me.txtGmailPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtGmailPassword.Size = New System.Drawing.Size(158, 21)
        Me.txtGmailPassword.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Address To"
        '
        'txtGmailAddressTo
        '
        Me.txtGmailAddressTo.Location = New System.Drawing.Point(111, 84)
        Me.txtGmailAddressTo.Name = "txtGmailAddressTo"
        Me.txtGmailAddressTo.Size = New System.Drawing.Size(158, 21)
        Me.txtGmailAddressTo.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(276, 26)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "@gmail.com"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(276, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "@gmail.com"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(261, 135)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(91, 24)
        Me.btnOK.TabIndex = 8
        Me.btnOK.Text = "Save"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmEmailSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 171)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtGmailAddressTo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtGmailPassword)
        Me.Controls.Add(Me.txtGmailUsername)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEmailSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gmail Setup "
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtGmailUsername As TextBox
    Friend WithEvents txtGmailPassword As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtGmailAddressTo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOK As Button
End Class
