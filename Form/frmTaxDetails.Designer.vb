<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTaxDetails
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
        Me.cmbTAX_TYPE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNAME = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numRATE = New System.Windows.Forms.NumericUpDown()
        Me.cmbVAT_METHOD = New System.Windows.Forms.ComboBox()
        Me.lbxVAT_METHOD = New System.Windows.Forms.Label()
        Me.cmbTAX_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.lbxTAX_ACCOUNT = New System.Windows.Forms.Label()
        Me.cmbASSET_ACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.lbxASSET_ACCOUNT = New System.Windows.Forms.Label()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numRATE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbTAX_TYPE
        '
        Me.cmbTAX_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTAX_TYPE.FormattingEnabled = True
        Me.cmbTAX_TYPE.Location = New System.Drawing.Point(117, 15)
        Me.cmbTAX_TYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTAX_TYPE.Name = "cmbTAX_TYPE"
        Me.cmbTAX_TYPE.Size = New System.Drawing.Size(300, 24)
        Me.cmbTAX_TYPE.TabIndex = 109
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(41, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 16)
        Me.Label4.TabIndex = 108
        Me.Label4.Text = "Tax Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(62, 48)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Name"
        '
        'txtNAME
        '
        Me.txtNAME.Location = New System.Drawing.Point(117, 44)
        Me.txtNAME.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(300, 23)
        Me.txtNAME.TabIndex = 111
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(70, 76)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 112
        Me.Label3.Text = "Rate"
        '
        'numRATE
        '
        Me.numRATE.AccessibleName = "0"
        Me.numRATE.Location = New System.Drawing.Point(117, 73)
        Me.numRATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numRATE.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numRATE.Name = "numRATE"
        Me.numRATE.Size = New System.Drawing.Size(97, 23)
        Me.numRATE.TabIndex = 113
        Me.numRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbVAT_METHOD
        '
        Me.cmbVAT_METHOD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVAT_METHOD.FormattingEnabled = True
        Me.cmbVAT_METHOD.Location = New System.Drawing.Point(117, 102)
        Me.cmbVAT_METHOD.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbVAT_METHOD.Name = "cmbVAT_METHOD"
        Me.cmbVAT_METHOD.Size = New System.Drawing.Size(302, 24)
        Me.cmbVAT_METHOD.TabIndex = 115
        '
        'lbxVAT_METHOD
        '
        Me.lbxVAT_METHOD.AutoSize = True
        Me.lbxVAT_METHOD.BackColor = System.Drawing.Color.Transparent
        Me.lbxVAT_METHOD.Location = New System.Drawing.Point(27, 106)
        Me.lbxVAT_METHOD.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbxVAT_METHOD.Name = "lbxVAT_METHOD"
        Me.lbxVAT_METHOD.Size = New System.Drawing.Size(83, 16)
        Me.lbxVAT_METHOD.TabIndex = 114
        Me.lbxVAT_METHOD.Text = "Vat Method"
        '
        'cmbTAX_ACCOUNT_ID
        '
        Me.cmbTAX_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbTAX_ACCOUNT_ID.Location = New System.Drawing.Point(117, 130)
        Me.cmbTAX_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTAX_ACCOUNT_ID.Name = "cmbTAX_ACCOUNT_ID"
        Me.cmbTAX_ACCOUNT_ID.Size = New System.Drawing.Size(302, 24)
        Me.cmbTAX_ACCOUNT_ID.TabIndex = 117
        '
        'lbxTAX_ACCOUNT
        '
        Me.lbxTAX_ACCOUNT.AutoSize = True
        Me.lbxTAX_ACCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lbxTAX_ACCOUNT.Location = New System.Drawing.Point(21, 134)
        Me.lbxTAX_ACCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbxTAX_ACCOUNT.Name = "lbxTAX_ACCOUNT"
        Me.lbxTAX_ACCOUNT.Size = New System.Drawing.Size(89, 16)
        Me.lbxTAX_ACCOUNT.TabIndex = 116
        Me.lbxTAX_ACCOUNT.Text = "Tax Account"
        '
        'cmbASSET_ACCOUNT_ID
        '
        Me.cmbASSET_ACCOUNT_ID.FormattingEnabled = True
        Me.cmbASSET_ACCOUNT_ID.Location = New System.Drawing.Point(117, 159)
        Me.cmbASSET_ACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbASSET_ACCOUNT_ID.Name = "cmbASSET_ACCOUNT_ID"
        Me.cmbASSET_ACCOUNT_ID.Size = New System.Drawing.Size(302, 24)
        Me.cmbASSET_ACCOUNT_ID.TabIndex = 119
        '
        'lbxASSET_ACCOUNT
        '
        Me.lbxASSET_ACCOUNT.AutoSize = True
        Me.lbxASSET_ACCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lbxASSET_ACCOUNT.Location = New System.Drawing.Point(8, 162)
        Me.lbxASSET_ACCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lbxASSET_ACCOUNT.Name = "lbxASSET_ACCOUNT"
        Me.lbxASSET_ACCOUNT.Size = New System.Drawing.Size(104, 16)
        Me.lbxASSET_ACCOUNT.TabIndex = 118
        Me.lbxASSET_ACCOUNT.Text = "Asset Account"
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.Location = New System.Drawing.Point(335, 74)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(80, 20)
        Me.chkINACTIVE.TabIndex = 120
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(217, 76)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 16)
        Me.Label5.TabIndex = 121
        Me.Label5.Text = "%"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(234, 204)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 122
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(331, 204)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 123
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmTaxDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 244)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.cmbASSET_ACCOUNT_ID)
        Me.Controls.Add(Me.lbxASSET_ACCOUNT)
        Me.Controls.Add(Me.cmbTAX_ACCOUNT_ID)
        Me.Controls.Add(Me.lbxTAX_ACCOUNT)
        Me.Controls.Add(Me.cmbVAT_METHOD)
        Me.Controls.Add(Me.lbxVAT_METHOD)
        Me.Controls.Add(Me.numRATE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbTAX_TYPE)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTaxDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tax"
        CType(Me.numRATE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmbTAX_TYPE As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNAME As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents numRATE As NumericUpDown
    Friend WithEvents cmbVAT_METHOD As ComboBox
    Friend WithEvents lbxVAT_METHOD As Label
    Friend WithEvents cmbTAX_ACCOUNT_ID As ComboBox
    Friend WithEvents lbxTAX_ACCOUNT As Label
    Friend WithEvents cmbASSET_ACCOUNT_ID As ComboBox
    Friend WithEvents lbxASSET_ACCOUNT As Label
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
