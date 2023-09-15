<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSRestoSettings
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.cmbPrinterPage = New System.Windows.Forms.ComboBox()
        Me.btnSettings2 = New System.Windows.Forms.Button()
        Me.cmbPrinterPage2 = New System.Windows.Forms.ComboBox()
        Me.btnSettings3 = New System.Windows.Forms.Button()
        Me.cmbPrinterPage3 = New System.Windows.Forms.ComboBox()
        Me.chkSmallBoxMonitoring = New System.Windows.Forms.CheckBox()
        Me.numCUSTOM_DINE_IN_NO = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkMsgPrintPayment = New System.Windows.Forms.CheckBox()
        Me.btnSettings4 = New System.Windows.Forms.Button()
        Me.cmbPrinterPage4 = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT = New System.Windows.Forms.CheckBox()
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE = New System.Windows.Forms.CheckBox()
        Me.cmbPRINTER = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.numCUSTOM_DINE_IN_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(102, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Order Slip"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(123, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 16)
        Me.Label2.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(121, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bill Slip"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(106, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Payment"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(313, 361)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(113, 25)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(432, 361)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(113, 25)
        Me.btnCancel.TabIndex = 13
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(513, 25)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(32, 26)
        Me.btnSettings.TabIndex = 15
        Me.btnSettings.Text = "..."
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'cmbPrinterPage
        '
        Me.cmbPrinterPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterPage.FormattingEnabled = True
        Me.cmbPrinterPage.Location = New System.Drawing.Point(189, 26)
        Me.cmbPrinterPage.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrinterPage.Name = "cmbPrinterPage"
        Me.cmbPrinterPage.Size = New System.Drawing.Size(323, 24)
        Me.cmbPrinterPage.TabIndex = 14
        '
        'btnSettings2
        '
        Me.btnSettings2.Location = New System.Drawing.Point(513, 54)
        Me.btnSettings2.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings2.Name = "btnSettings2"
        Me.btnSettings2.Size = New System.Drawing.Size(32, 26)
        Me.btnSettings2.TabIndex = 17
        Me.btnSettings2.Text = "..."
        Me.btnSettings2.UseVisualStyleBackColor = True
        '
        'cmbPrinterPage2
        '
        Me.cmbPrinterPage2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterPage2.FormattingEnabled = True
        Me.cmbPrinterPage2.Location = New System.Drawing.Point(189, 55)
        Me.cmbPrinterPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrinterPage2.Name = "cmbPrinterPage2"
        Me.cmbPrinterPage2.Size = New System.Drawing.Size(323, 24)
        Me.cmbPrinterPage2.TabIndex = 16
        '
        'btnSettings3
        '
        Me.btnSettings3.Location = New System.Drawing.Point(513, 83)
        Me.btnSettings3.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings3.Name = "btnSettings3"
        Me.btnSettings3.Size = New System.Drawing.Size(32, 26)
        Me.btnSettings3.TabIndex = 19
        Me.btnSettings3.Text = "..."
        Me.btnSettings3.UseVisualStyleBackColor = True
        '
        'cmbPrinterPage3
        '
        Me.cmbPrinterPage3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterPage3.FormattingEnabled = True
        Me.cmbPrinterPage3.Location = New System.Drawing.Point(189, 84)
        Me.cmbPrinterPage3.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrinterPage3.Name = "cmbPrinterPage3"
        Me.cmbPrinterPage3.Size = New System.Drawing.Size(323, 24)
        Me.cmbPrinterPage3.TabIndex = 18
        '
        'chkSmallBoxMonitoring
        '
        Me.chkSmallBoxMonitoring.AutoSize = True
        Me.chkSmallBoxMonitoring.BackColor = System.Drawing.Color.Transparent
        Me.chkSmallBoxMonitoring.Location = New System.Drawing.Point(189, 155)
        Me.chkSmallBoxMonitoring.Name = "chkSmallBoxMonitoring"
        Me.chkSmallBoxMonitoring.Size = New System.Drawing.Size(213, 20)
        Me.chkSmallBoxMonitoring.TabIndex = 20
        Me.chkSmallBoxMonitoring.Text = "Use Small Box for Monitoring"
        Me.chkSmallBoxMonitoring.UseVisualStyleBackColor = False
        '
        'numCUSTOM_DINE_IN_NO
        '
        Me.numCUSTOM_DINE_IN_NO.Location = New System.Drawing.Point(189, 316)
        Me.numCUSTOM_DINE_IN_NO.Name = "numCUSTOM_DINE_IN_NO"
        Me.numCUSTOM_DINE_IN_NO.Size = New System.Drawing.Size(66, 23)
        Me.numCUSTOM_DINE_IN_NO.TabIndex = 21
        Me.numCUSTOM_DINE_IN_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(67, 318)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(103, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "DINE-IN  Table"
        '
        'chkMsgPrintPayment
        '
        Me.chkMsgPrintPayment.AutoSize = True
        Me.chkMsgPrintPayment.BackColor = System.Drawing.Color.Transparent
        Me.chkMsgPrintPayment.Location = New System.Drawing.Point(189, 181)
        Me.chkMsgPrintPayment.Name = "chkMsgPrintPayment"
        Me.chkMsgPrintPayment.Size = New System.Drawing.Size(241, 20)
        Me.chkMsgPrintPayment.TabIndex = 23
        Me.chkMsgPrintPayment.Text = "Pop-Message for Print Payment?"
        Me.chkMsgPrintPayment.UseVisualStyleBackColor = False
        '
        'btnSettings4
        '
        Me.btnSettings4.Location = New System.Drawing.Point(513, 112)
        Me.btnSettings4.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings4.Name = "btnSettings4"
        Me.btnSettings4.Size = New System.Drawing.Size(32, 26)
        Me.btnSettings4.TabIndex = 26
        Me.btnSettings4.Text = "..."
        Me.btnSettings4.UseVisualStyleBackColor = True
        '
        'cmbPrinterPage4
        '
        Me.cmbPrinterPage4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterPage4.FormattingEnabled = True
        Me.cmbPrinterPage4.Location = New System.Drawing.Point(189, 113)
        Me.cmbPrinterPage4.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrinterPage4.Name = "cmbPrinterPage4"
        Me.cmbPrinterPage4.Size = New System.Drawing.Size(323, 24)
        Me.cmbPrinterPage4.TabIndex = 25
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(83, 116)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Sales Report"
        '
        'chkPRINT_INVOICE_AFTER_PRINT_PAYMENT
        '
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.AutoSize = True
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.BackColor = System.Drawing.Color.Transparent
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Location = New System.Drawing.Point(189, 207)
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Name = "chkPRINT_INVOICE_AFTER_PRINT_PAYMENT"
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Size = New System.Drawing.Size(243, 20)
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.TabIndex = 27
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.Text = "Print Invoice after print payment"
        Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT.UseVisualStyleBackColor = False
        '
        'chkPRINT_OS_AFTER_SAVE_INVOICE
        '
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.AutoSize = True
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.BackColor = System.Drawing.Color.Transparent
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.Location = New System.Drawing.Point(189, 233)
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.Name = "chkPRINT_OS_AFTER_SAVE_INVOICE"
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.Size = New System.Drawing.Size(225, 20)
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.TabIndex = 28
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.Text = "Print Invoice After Save Entry"
        Me.chkPRINT_OS_AFTER_SAVE_INVOICE.UseVisualStyleBackColor = False
        '
        'cmbPRINTER
        '
        Me.cmbPRINTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRINTER.FormattingEnabled = True
        Me.cmbPRINTER.Location = New System.Drawing.Point(189, 285)
        Me.cmbPRINTER.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPRINTER.Name = "cmbPRINTER"
        Me.cmbPRINTER.Size = New System.Drawing.Size(356, 24)
        Me.cmbPRINTER.TabIndex = 30
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(47, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 16)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "POS Default Printer"
        '
        'FrmPOSRestoSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 398)
        Me.Controls.Add(Me.cmbPRINTER)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkPRINT_OS_AFTER_SAVE_INVOICE)
        Me.Controls.Add(Me.chkPRINT_INVOICE_AFTER_PRINT_PAYMENT)
        Me.Controls.Add(Me.btnSettings4)
        Me.Controls.Add(Me.cmbPrinterPage4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.chkMsgPrintPayment)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numCUSTOM_DINE_IN_NO)
        Me.Controls.Add(Me.chkSmallBoxMonitoring)
        Me.Controls.Add(Me.btnSettings3)
        Me.Controls.Add(Me.cmbPrinterPage3)
        Me.Controls.Add(Me.btnSettings2)
        Me.Controls.Add(Me.cmbPrinterPage2)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.cmbPrinterPage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSRestoSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        CType(Me.numCUSTOM_DINE_IN_NO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents cmbPrinterPage As ComboBox
    Friend WithEvents btnSettings2 As Button
    Friend WithEvents cmbPrinterPage2 As ComboBox
    Friend WithEvents btnSettings3 As Button
    Friend WithEvents cmbPrinterPage3 As ComboBox
    Friend WithEvents chkSmallBoxMonitoring As CheckBox
    Friend WithEvents Label5 As Label
    Private WithEvents numCUSTOM_DINE_IN_NO As NumericUpDown
    Friend WithEvents chkMsgPrintPayment As CheckBox
    Friend WithEvents btnSettings4 As Button
    Friend WithEvents cmbPrinterPage4 As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkPRINT_INVOICE_AFTER_PRINT_PAYMENT As CheckBox
    Friend WithEvents chkPRINT_OS_AFTER_SAVE_INVOICE As CheckBox
    Friend WithEvents cmbPRINTER As ComboBox
    Friend WithEvents Label7 As Label
End Class
