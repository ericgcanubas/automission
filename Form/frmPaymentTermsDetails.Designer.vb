<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPaymentTermsDetails
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
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numNET_DUE = New System.Windows.Forms.NumericUpDown()
        Me.lbxDayLabel = New System.Windows.Forms.Label()
        Me.cmbDATE_DAY_PARAM = New System.Windows.Forms.ComboBox()
        Me.cmbDATE_MONTH_PARAM = New System.Windows.Forms.ComboBox()
        Me.numDATE_MIN_DAYS = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numDISCOUNT_PCT = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numDISCOUNT_DUE = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.numNET_DUE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDATE_MIN_DAYS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDISCOUNT_PCT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDISCOUNT_DUE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(15, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 71
        Me.Label2.Text = "Code"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(96, 12)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(145, 21)
        Me.txtCODE.TabIndex = 72
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(96, 35)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(405, 21)
        Me.txtDESCRIPTION.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(15, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(15, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 75
        Me.Label4.Text = "Type"
        '
        'cmbTYPE
        '
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(96, 58)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(146, 21)
        Me.cmbTYPE.TabIndex = 76
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(15, 83)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 77
        Me.Label5.Text = "Net Due in"
        '
        'numNET_DUE
        '
        Me.numNET_DUE.Location = New System.Drawing.Point(96, 81)
        Me.numNET_DUE.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numNET_DUE.Name = "numNET_DUE"
        Me.numNET_DUE.Size = New System.Drawing.Size(64, 21)
        Me.numNET_DUE.TabIndex = 78
        '
        'lbxDayLabel
        '
        Me.lbxDayLabel.AutoSize = True
        Me.lbxDayLabel.BackColor = System.Drawing.Color.Transparent
        Me.lbxDayLabel.Location = New System.Drawing.Point(165, 84)
        Me.lbxDayLabel.Name = "lbxDayLabel"
        Me.lbxDayLabel.Size = New System.Drawing.Size(48, 13)
        Me.lbxDayLabel.TabIndex = 79
        Me.lbxDayLabel.Text = "day(s)."
        '
        'cmbDATE_DAY_PARAM
        '
        Me.cmbDATE_DAY_PARAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDATE_DAY_PARAM.FormattingEnabled = True
        Me.cmbDATE_DAY_PARAM.Location = New System.Drawing.Point(253, 81)
        Me.cmbDATE_DAY_PARAM.Name = "cmbDATE_DAY_PARAM"
        Me.cmbDATE_DAY_PARAM.Size = New System.Drawing.Size(119, 21)
        Me.cmbDATE_DAY_PARAM.TabIndex = 80
        '
        'cmbDATE_MONTH_PARAM
        '
        Me.cmbDATE_MONTH_PARAM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDATE_MONTH_PARAM.FormattingEnabled = True
        Me.cmbDATE_MONTH_PARAM.Location = New System.Drawing.Point(376, 82)
        Me.cmbDATE_MONTH_PARAM.Name = "cmbDATE_MONTH_PARAM"
        Me.cmbDATE_MONTH_PARAM.Size = New System.Drawing.Size(51, 21)
        Me.cmbDATE_MONTH_PARAM.TabIndex = 82
        '
        'numDATE_MIN_DAYS
        '
        Me.numDATE_MIN_DAYS.Location = New System.Drawing.Point(253, 105)
        Me.numDATE_MIN_DAYS.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numDATE_MIN_DAYS.Name = "numDATE_MIN_DAYS"
        Me.numDATE_MIN_DAYS.Size = New System.Drawing.Size(73, 21)
        Me.numDATE_MIN_DAYS.TabIndex = 84
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(15, 107)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(209, 13)
        Me.Label7.TabIndex = 83
        Me.Label7.Text = "Due the next period if issued within"
        '
        'numDISCOUNT_PCT
        '
        Me.numDISCOUNT_PCT.Location = New System.Drawing.Point(168, 130)
        Me.numDISCOUNT_PCT.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numDISCOUNT_PCT.Name = "numDISCOUNT_PCT"
        Me.numDISCOUNT_PCT.Size = New System.Drawing.Size(73, 21)
        Me.numDISCOUNT_PCT.TabIndex = 86
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(15, 135)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(137, 13)
        Me.Label8.TabIndex = 85
        Me.Label8.Text = "Discount Percentage is"
        '
        'numDISCOUNT_DUE
        '
        Me.numDISCOUNT_DUE.Location = New System.Drawing.Point(168, 154)
        Me.numDISCOUNT_DUE.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        Me.numDISCOUNT_DUE.Name = "numDISCOUNT_DUE"
        Me.numDISCOUNT_DUE.Size = New System.Drawing.Size(73, 21)
        Me.numDISCOUNT_DUE.TabIndex = 88
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(15, 156)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(109, 13)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Discount if paid in"
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.Location = New System.Drawing.Point(311, 158)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(72, 17)
        Me.chkINACTIVE.TabIndex = 89
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Location = New System.Drawing.Point(245, 159)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(48, 13)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "day(s)."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(330, 108)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(107, 13)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "days of due date."
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(341, 205)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 92
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(426, 205)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 93
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.Control
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.Location = New System.Drawing.Point(0, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(514, 43)
        Me.Label1.TabIndex = 94
        '
        'frmPaymentTermsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(514, 237)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.numDISCOUNT_DUE)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.numDISCOUNT_PCT)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.numDATE_MIN_DAYS)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbDATE_MONTH_PARAM)
        Me.Controls.Add(Me.cmbDATE_DAY_PARAM)
        Me.Controls.Add(Me.lbxDayLabel)
        Me.Controls.Add(Me.numNET_DUE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPaymentTermsDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment Terms"
        CType(Me.numNET_DUE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDATE_MIN_DAYS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDISCOUNT_PCT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDISCOUNT_DUE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents numNET_DUE As NumericUpDown
    Friend WithEvents lbxDayLabel As Label
    Friend WithEvents cmbDATE_DAY_PARAM As ComboBox
    Friend WithEvents cmbDATE_MONTH_PARAM As ComboBox
    Friend WithEvents numDATE_MIN_DAYS As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents numDISCOUNT_PCT As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents numDISCOUNT_DUE As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
End Class
