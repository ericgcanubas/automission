<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSCashCount
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
        Me.numCASH = New System.Windows.Forms.NumericUpDown()
        Me.numCHECK = New System.Windows.Forms.NumericUpDown()
        Me.numCreditCard = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numOtherPayment = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.lblTOTAL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.gpbCD = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.xlblStartingCash = New System.Windows.Forms.Label()
        CType(Me.numCASH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCHECK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCreditCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOtherPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpbCD.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'numCASH
        '
        Me.numCASH.DecimalPlaces = 2
        Me.numCASH.Location = New System.Drawing.Point(120, 18)
        Me.numCASH.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCASH.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numCASH.Name = "numCASH"
        Me.numCASH.Size = New System.Drawing.Size(137, 23)
        Me.numCASH.TabIndex = 0
        Me.numCASH.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCASH.ThousandsSeparator = True
        '
        'numCHECK
        '
        Me.numCHECK.DecimalPlaces = 2
        Me.numCHECK.Location = New System.Drawing.Point(120, 44)
        Me.numCHECK.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCHECK.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numCHECK.Name = "numCHECK"
        Me.numCHECK.Size = New System.Drawing.Size(137, 23)
        Me.numCHECK.TabIndex = 1
        Me.numCHECK.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCHECK.ThousandsSeparator = True
        '
        'numCreditCard
        '
        Me.numCreditCard.DecimalPlaces = 2
        Me.numCreditCard.Location = New System.Drawing.Point(120, 70)
        Me.numCreditCard.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCreditCard.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numCreditCard.Name = "numCreditCard"
        Me.numCreditCard.Size = New System.Drawing.Size(137, 23)
        Me.numCreditCard.TabIndex = 2
        Me.numCreditCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCreditCard.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(17, 20)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Cash"
        '
        'numOtherPayment
        '
        Me.numOtherPayment.DecimalPlaces = 2
        Me.numOtherPayment.Location = New System.Drawing.Point(120, 97)
        Me.numOtherPayment.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numOtherPayment.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numOtherPayment.Name = "numOtherPayment"
        Me.numOtherPayment.Size = New System.Drawing.Size(137, 23)
        Me.numOtherPayment.TabIndex = 4
        Me.numOtherPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numOtherPayment.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(17, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Check"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(17, 71)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Credit Card"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(17, 98)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Others"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(17, 244)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Notes"
        '
        'txtNOTES
        '
        Me.txtNOTES.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtNOTES.Location = New System.Drawing.Point(21, 262)
        Me.txtNOTES.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNOTES.MaxLength = 200
        Me.txtNOTES.Multiline = True
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTES.Size = New System.Drawing.Size(238, 191)
        Me.txtNOTES.TabIndex = 9
        '
        'lblTOTAL
        '
        Me.lblTOTAL.BackColor = System.Drawing.Color.Black
        Me.lblTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTOTAL.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL.ForeColor = System.Drawing.Color.Lime
        Me.lblTOTAL.Location = New System.Drawing.Point(20, 202)
        Me.lblTOTAL.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTOTAL.Name = "lblTOTAL"
        Me.lblTOTAL.Size = New System.Drawing.Size(237, 38)
        Me.lblTOTAL.TabIndex = 12
        Me.lblTOTAL.Text = "0.00"
        Me.lblTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 183)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 19)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Actual Count"
        '
        'btnSAVE
        '
        Me.btnSAVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSAVE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSAVE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSAVE.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.Location = New System.Drawing.Point(272, 461)
        Me.btnSAVE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(104, 36)
        Me.btnSAVE.TabIndex = 14
        Me.btnSAVE.Text = "&Save"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCANCEL.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCANCEL.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCANCEL.Location = New System.Drawing.Point(396, 461)
        Me.btnCANCEL.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(99, 36)
        Me.btnCANCEL.TabIndex = 15
        Me.btnCANCEL.Text = "&Cancel"
        Me.btnCANCEL.UseVisualStyleBackColor = False
        '
        'gpbCD
        '
        Me.gpbCD.Controls.Add(Me.FlowLayoutPanel1)
        Me.gpbCD.Location = New System.Drawing.Point(269, 10)
        Me.gpbCD.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpbCD.Name = "gpbCD"
        Me.gpbCD.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gpbCD.Size = New System.Drawing.Size(226, 443)
        Me.gpbCD.TabIndex = 16
        Me.gpbCD.TabStop = False
        Me.gpbCD.Text = "Cash Denomination Count"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 18)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(220, 423)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.NumericUpDown1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(213, 23)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New System.Drawing.Point(142, 0)
        Me.NumericUpDown1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(66, 23)
        Me.NumericUpDown1.TabIndex = 1
        Me.NumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 16)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "1000 bill"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 147)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Petty Cash"
        '
        'xlblStartingCash
        '
        Me.xlblStartingCash.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblStartingCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblStartingCash.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblStartingCash.ForeColor = System.Drawing.Color.Red
        Me.xlblStartingCash.Location = New System.Drawing.Point(120, 144)
        Me.xlblStartingCash.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblStartingCash.Name = "xlblStartingCash"
        Me.xlblStartingCash.Size = New System.Drawing.Size(137, 24)
        Me.xlblStartingCash.TabIndex = 18
        Me.xlblStartingCash.Text = "0.00"
        Me.xlblStartingCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FrmPOSCashCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 504)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.xlblStartingCash)
        Me.Controls.Add(Me.gpbCD)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnSAVE)
        Me.Controls.Add(Me.lblTOTAL)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numOtherPayment)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numCreditCard)
        Me.Controls.Add(Me.numCHECK)
        Me.Controls.Add(Me.numCASH)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSCashCount"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "POS Cash Count"
        CType(Me.numCASH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCHECK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCreditCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOtherPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpbCD.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents numCASH As NumericUpDown
    Friend WithEvents numCHECK As NumericUpDown
    Friend WithEvents numCreditCard As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents numOtherPayment As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents lblTOTAL As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSAVE As Button
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents gpbCD As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents xlblStartingCash As Label
End Class
