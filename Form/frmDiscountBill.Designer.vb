<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDiscountBill
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpDISCOUNT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.cmbDiscount_Account = New System.Windows.Forms.ComboBox()
        Me.numAmount_of_Discount = New System.Windows.Forms.NumericUpDown()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.lblSuggested_Discount = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblTERMS = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblBALANCE = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblDISCOUNT = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblAmount_Due = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCreditUsed = New System.Windows.Forms.Label()
        Me.lblDATE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numAmount_of_Discount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dtpDISCOUNT_DATE)
        Me.GroupBox2.Controls.Add(Me.cmbDiscount_Account)
        Me.GroupBox2.Controls.Add(Me.numAmount_of_Discount)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.lblSuggested_Discount)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.lblTERMS)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 268)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(497, 206)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Discount"
        '
        'dtpDISCOUNT_DATE
        '
        Me.dtpDISCOUNT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDISCOUNT_DATE.Location = New System.Drawing.Point(176, 34)
        Me.dtpDISCOUNT_DATE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dtpDISCOUNT_DATE.Name = "dtpDISCOUNT_DATE"
        Me.dtpDISCOUNT_DATE.Size = New System.Drawing.Size(141, 23)
        Me.dtpDISCOUNT_DATE.TabIndex = 16
        '
        'cmbDiscount_Account
        '
        Me.cmbDiscount_Account.FormattingEnabled = True
        Me.cmbDiscount_Account.Location = New System.Drawing.Point(176, 117)
        Me.cmbDiscount_Account.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDiscount_Account.Name = "cmbDiscount_Account"
        Me.cmbDiscount_Account.Size = New System.Drawing.Size(261, 24)
        Me.cmbDiscount_Account.TabIndex = 15
        '
        'numAmount_of_Discount
        '
        Me.numAmount_of_Discount.DecimalPlaces = 2
        Me.numAmount_of_Discount.Location = New System.Drawing.Point(176, 145)
        Me.numAmount_of_Discount.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numAmount_of_Discount.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numAmount_of_Discount.Name = "numAmount_of_Discount"
        Me.numAmount_of_Discount.Size = New System.Drawing.Size(142, 23)
        Me.numAmount_of_Discount.TabIndex = 14
        Me.numAmount_of_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(107, 121)
        Me.Label24.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 16)
        Me.Label24.TabIndex = 13
        Me.Label24.Text = "Account"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(109, 148)
        Me.Label25.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(57, 16)
        Me.Label25.TabIndex = 12
        Me.Label25.Text = "Amount"
        '
        'lblSuggested_Discount
        '
        Me.lblSuggested_Discount.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSuggested_Discount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSuggested_Discount.Location = New System.Drawing.Point(176, 89)
        Me.lblSuggested_Discount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblSuggested_Discount.Name = "lblSuggested_Discount"
        Me.lblSuggested_Discount.Size = New System.Drawing.Size(141, 25)
        Me.lblSuggested_Discount.TabIndex = 11
        Me.lblSuggested_Discount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(31, 94)
        Me.Label19.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(139, 16)
        Me.Label19.TabIndex = 10
        Me.Label19.Text = "Suggested Discount"
        '
        'lblTERMS
        '
        Me.lblTERMS.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblTERMS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTERMS.Location = New System.Drawing.Point(176, 62)
        Me.lblTERMS.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTERMS.Name = "lblTERMS"
        Me.lblTERMS.Size = New System.Drawing.Size(141, 25)
        Me.lblTERMS.TabIndex = 9
        Me.lblTERMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(120, 66)
        Me.Label21.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(46, 16)
        Me.Label21.TabIndex = 8
        Me.Label21.Text = "Terms"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(67, 42)
        Me.Label23.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(100, 16)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "Discount Date"
        '
        'lblBALANCE
        '
        Me.lblBALANCE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblBALANCE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBALANCE.Location = New System.Drawing.Point(176, 210)
        Me.lblBALANCE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblBALANCE.Name = "lblBALANCE"
        Me.lblBALANCE.Size = New System.Drawing.Size(154, 25)
        Me.lblBALANCE.TabIndex = 15
        Me.lblBALANCE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(77, 215)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = "Balance Due"
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAMOUNT.Location = New System.Drawing.Point(176, 183)
        Me.lblAMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(154, 25)
        Me.lblAMOUNT.TabIndex = 13
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(77, 187)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(90, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Org. Amount"
        '
        'lblDISCOUNT
        '
        Me.lblDISCOUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDISCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDISCOUNT.Location = New System.Drawing.Point(176, 156)
        Me.lblDISCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDISCOUNT.Name = "lblDISCOUNT"
        Me.lblDISCOUNT.Size = New System.Drawing.Size(154, 25)
        Me.lblDISCOUNT.TabIndex = 11
        Me.lblDISCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(97, 160)
        Me.Label15.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "Discount"
        '
        'lblCODE
        '
        Me.lblCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCODE.Location = New System.Drawing.Point(176, 129)
        Me.lblCODE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(154, 25)
        Me.lblCODE.TabIndex = 9
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(71, 134)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 16)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Reference No."
        '
        'lblAmount_Due
        '
        Me.lblAmount_Due.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAmount_Due.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmount_Due.Location = New System.Drawing.Point(176, 102)
        Me.lblAmount_Due.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAmount_Due.Name = "lblAmount_Due"
        Me.lblAmount_Due.Size = New System.Drawing.Size(154, 25)
        Me.lblAmount_Due.TabIndex = 7
        Me.lblAmount_Due.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(72, 107)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(87, 16)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Amount Due"
        '
        'lblCreditUsed
        '
        Me.lblCreditUsed.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCreditUsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditUsed.Location = New System.Drawing.Point(176, 75)
        Me.lblCreditUsed.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCreditUsed.Name = "lblCreditUsed"
        Me.lblCreditUsed.Size = New System.Drawing.Size(154, 25)
        Me.lblCreditUsed.TabIndex = 5
        Me.lblCreditUsed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDATE
        '
        Me.lblDATE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDATE.Location = New System.Drawing.Point(176, 48)
        Me.lblDATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDATE.Name = "lblDATE"
        Me.lblDATE.Size = New System.Drawing.Size(154, 25)
        Me.lblDATE.TabIndex = 3
        Me.lblDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(128, 53)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Date"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Location = New System.Drawing.Point(176, 21)
        Me.lblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(312, 25)
        Me.lblName.TabIndex = 1
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(105, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Supplier"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblBALANCE)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblAMOUNT)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblDISCOUNT)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.lblCODE)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblAmount_Due)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblCreditUsed)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblDATE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 11)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(497, 250)
        Me.GroupBox1.TabIndex = 32
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Purchase Order"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(82, 80)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Credit Used"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(333, 527)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 27)
        Me.btnOK.TabIndex = 34
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(425, 527)
        Me.btnCANCEL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(86, 27)
        Me.btnCANCEL.TabIndex = 35
        Me.btnCANCEL.Text = "Cancel"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'frmDiscountBill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 565)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiscountBill"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Discount P.O"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numAmount_of_Discount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbDiscount_Account As ComboBox
    Friend WithEvents numAmount_of_Discount As NumericUpDown
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblSuggested_Discount As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents lblTERMS As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents lblBALANCE As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblDISCOUNT As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents lblCODE As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblAmount_Due As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCreditUsed As Label
    Friend WithEvents lblDATE As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpDISCOUNT_DATE As DateTimePicker
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCANCEL As Button
End Class
