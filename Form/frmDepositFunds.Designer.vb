<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDepositFunds
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
        Me.cmbReceivedFrom = New System.Windows.Forms.ComboBox()
        Me.cmbAccounts = New System.Windows.Forms.ComboBox()
        Me.cmbPAYMENT_METHOD_ID = New System.Windows.Forms.ComboBox()
        Me.txtCheckNo = New System.Windows.Forms.TextBox()
        Me.numAmount = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbReceivedFrom
        '
        Me.cmbReceivedFrom.FormattingEnabled = True
        Me.cmbReceivedFrom.Location = New System.Drawing.Point(135, 15)
        Me.cmbReceivedFrom.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbReceivedFrom.Name = "cmbReceivedFrom"
        Me.cmbReceivedFrom.Size = New System.Drawing.Size(383, 24)
        Me.cmbReceivedFrom.TabIndex = 0
        '
        'cmbAccounts
        '
        Me.cmbAccounts.FormattingEnabled = True
        Me.cmbAccounts.Location = New System.Drawing.Point(135, 42)
        Me.cmbAccounts.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbAccounts.Name = "cmbAccounts"
        Me.cmbAccounts.Size = New System.Drawing.Size(383, 24)
        Me.cmbAccounts.TabIndex = 1
        '
        'cmbPAYMENT_METHOD_ID
        '
        Me.cmbPAYMENT_METHOD_ID.FormattingEnabled = True
        Me.cmbPAYMENT_METHOD_ID.Location = New System.Drawing.Point(135, 69)
        Me.cmbPAYMENT_METHOD_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPAYMENT_METHOD_ID.Name = "cmbPAYMENT_METHOD_ID"
        Me.cmbPAYMENT_METHOD_ID.Size = New System.Drawing.Size(383, 24)
        Me.cmbPAYMENT_METHOD_ID.TabIndex = 2
        '
        'txtCheckNo
        '
        Me.txtCheckNo.Location = New System.Drawing.Point(135, 96)
        Me.txtCheckNo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCheckNo.Name = "txtCheckNo"
        Me.txtCheckNo.Size = New System.Drawing.Size(383, 23)
        Me.txtCheckNo.TabIndex = 3
        '
        'numAmount
        '
        Me.numAmount.DecimalPlaces = 2
        Me.numAmount.Location = New System.Drawing.Point(135, 123)
        Me.numAmount.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numAmount.Maximum = New Decimal(New Integer() {276447231, 23283, 0, 0})
        Me.numAmount.Minimum = New Decimal(New Integer() {276447231, 23283, 0, -2147483648})
        Me.numAmount.Name = "numAmount"
        Me.numAmount.Size = New System.Drawing.Size(165, 23)
        Me.numAmount.TabIndex = 4
        Me.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(25, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Received From"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(72, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Account"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(15, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Payment Method"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(56, 100)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Check No."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(73, 127)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Amount"
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.BackColor = System.Drawing.Color.Transparent
        Me.chkAuto.Location = New System.Drawing.Point(135, 154)
        Me.chkAuto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(149, 20)
        Me.chkAuto.TabIndex = 13
        Me.chkAuto.Text = "Continuation Entry"
        Me.chkAuto.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(399, 146)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(119, 28)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmDepositFunds
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(532, 184)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.txtCheckNo)
        Me.Controls.Add(Me.cmbPAYMENT_METHOD_ID)
        Me.Controls.Add(Me.cmbAccounts)
        Me.Controls.Add(Me.cmbReceivedFrom)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDepositFunds"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit Funds"
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbReceivedFrom As ComboBox
    Friend WithEvents cmbAccounts As ComboBox
    Friend WithEvents cmbPAYMENT_METHOD_ID As ComboBox
    Friend WithEvents txtCheckNo As TextBox
    Friend WithEvents numAmount As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents chkAuto As CheckBox
    Friend WithEvents btnOK As Button
End Class
