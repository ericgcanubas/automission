<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserDetails
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.cmbSTATUS = New System.Windows.Forms.ComboBox()
        Me.dtpEXPIRATION_DATE = New System.Windows.Forms.DateTimePicker()
        Me.txsPassword = New System.Windows.Forms.TextBox()
        Me.txsConfirm_Password = New System.Windows.Forms.TextBox()
        Me.cmbCONTACT_ID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.chkAUTHORIZED_PASSWORD = New System.Windows.Forms.CheckBox()
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.BtnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(66, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Username"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(142, 10)
        Me.txtName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtName.MaxLength = 12
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(178, 23)
        Me.txtName.TabIndex = 19
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(142, 37)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(437, 23)
        Me.txtDESCRIPTION.TabIndex = 20
        '
        'cmbSTATUS
        '
        Me.cmbSTATUS.AccessibleDescription = "0"
        Me.cmbSTATUS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSTATUS.FormattingEnabled = True
        Me.cmbSTATUS.Location = New System.Drawing.Point(142, 91)
        Me.cmbSTATUS.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSTATUS.Name = "cmbSTATUS"
        Me.cmbSTATUS.Size = New System.Drawing.Size(178, 24)
        Me.cmbSTATUS.TabIndex = 21
        '
        'dtpEXPIRATION_DATE
        '
        Me.dtpEXPIRATION_DATE.Checked = False
        Me.dtpEXPIRATION_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEXPIRATION_DATE.Location = New System.Drawing.Point(142, 118)
        Me.dtpEXPIRATION_DATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dtpEXPIRATION_DATE.Name = "dtpEXPIRATION_DATE"
        Me.dtpEXPIRATION_DATE.ShowCheckBox = True
        Me.dtpEXPIRATION_DATE.Size = New System.Drawing.Size(178, 23)
        Me.dtpEXPIRATION_DATE.TabIndex = 22
        '
        'txsPassword
        '
        Me.txsPassword.Location = New System.Drawing.Point(142, 145)
        Me.txsPassword.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txsPassword.Name = "txsPassword"
        Me.txsPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txsPassword.Size = New System.Drawing.Size(178, 23)
        Me.txsPassword.TabIndex = 23
        '
        'txsConfirm_Password
        '
        Me.txsConfirm_Password.Location = New System.Drawing.Point(142, 172)
        Me.txsConfirm_Password.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txsConfirm_Password.Name = "txsConfirm_Password"
        Me.txsConfirm_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txsConfirm_Password.Size = New System.Drawing.Size(178, 23)
        Me.txsConfirm_Password.TabIndex = 24
        '
        'cmbCONTACT_ID
        '
        Me.cmbCONTACT_ID.FormattingEnabled = True
        Me.cmbCONTACT_ID.Location = New System.Drawing.Point(142, 200)
        Me.cmbCONTACT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCONTACT_ID.Name = "cmbCONTACT_ID"
        Me.cmbCONTACT_ID.Size = New System.Drawing.Size(437, 24)
        Me.cmbCONTACT_ID.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 40)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Fullname"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(89, 95)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 122)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 16)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Expiration Date"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(69, 149)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 16)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Password"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 176)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(123, 16)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Confirm Password"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 204)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 16)
        Me.Label8.TabIndex = 31
        Me.Label8.Text = "Contact Accounts"
        '
        'chkAUTHORIZED_PASSWORD
        '
        Me.chkAUTHORIZED_PASSWORD.AutoSize = True
        Me.chkAUTHORIZED_PASSWORD.Location = New System.Drawing.Point(340, 148)
        Me.chkAUTHORIZED_PASSWORD.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAUTHORIZED_PASSWORD.Name = "chkAUTHORIZED_PASSWORD"
        Me.chkAUTHORIZED_PASSWORD.Size = New System.Drawing.Size(163, 20)
        Me.chkAUTHORIZED_PASSWORD.TabIndex = 32
        Me.chkAUTHORIZED_PASSWORD.Text = "Authorized Password"
        Me.chkAUTHORIZED_PASSWORD.UseVisualStyleBackColor = True
        '
        'cmbTYPE
        '
        Me.cmbTYPE.AccessibleDescription = "0"
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(142, 64)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(178, 24)
        Me.cmbTYPE.TabIndex = 33
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(99, 68)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Type"
        '
        'btnSAVE
        '
        Me.btnSAVE.Location = New System.Drawing.Point(395, 243)
        Me.btnSAVE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(86, 28)
        Me.btnSAVE.TabIndex = 35
        Me.btnSAVE.Text = "&Save"
        Me.btnSAVE.UseVisualStyleBackColor = True
        '
        'BtnCancel
        '
        Me.BtnCancel.Location = New System.Drawing.Point(493, 243)
        Me.BtnCancel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(86, 28)
        Me.BtnCancel.TabIndex = 36
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'frmUserDetails
        '
        Me.AccessibleDescription = "0"
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(588, 277)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.btnSAVE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Controls.Add(Me.chkAUTHORIZED_PASSWORD)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbCONTACT_ID)
        Me.Controls.Add(Me.txsConfirm_Password)
        Me.Controls.Add(Me.txsPassword)
        Me.Controls.Add(Me.dtpEXPIRATION_DATE)
        Me.Controls.Add(Me.cmbSTATUS)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "USER DETAILS"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents cmbSTATUS As ComboBox
    Friend WithEvents dtpEXPIRATION_DATE As DateTimePicker
    Friend WithEvents txsPassword As TextBox
    Friend WithEvents txsConfirm_Password As TextBox
    Friend WithEvents cmbCONTACT_ID As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents chkAUTHORIZED_PASSWORD As CheckBox
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSAVE As Button
    Friend WithEvents BtnCancel As Button
End Class
