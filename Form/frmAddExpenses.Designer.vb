<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddExpenses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAddExpenses))
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.xlblSelection = New System.Windows.Forms.Label()
        Me.cmbAccounts = New System.Windows.Forms.ComboBox()
        Me.chkTax = New System.Windows.Forms.CheckBox()
        Me.numAmount = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rtbParticular = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ThisType = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(95, 171)
        Me.cmbClass.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(235, 24)
        Me.cmbClass.TabIndex = 86
        '
        'xlblSelection
        '
        Me.xlblSelection.AutoSize = True
        Me.xlblSelection.BackColor = System.Drawing.Color.Transparent
        Me.xlblSelection.Location = New System.Drawing.Point(47, 175)
        Me.xlblSelection.Name = "xlblSelection"
        Me.xlblSelection.Size = New System.Drawing.Size(41, 16)
        Me.xlblSelection.TabIndex = 92
        Me.xlblSelection.Text = "Class"
        '
        'cmbAccounts
        '
        Me.cmbAccounts.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbAccounts.FormattingEnabled = True
        Me.cmbAccounts.Location = New System.Drawing.Point(95, 15)
        Me.cmbAccounts.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbAccounts.Name = "cmbAccounts"
        Me.cmbAccounts.Size = New System.Drawing.Size(466, 24)
        Me.cmbAccounts.TabIndex = 72
        '
        'chkTax
        '
        Me.chkTax.BackColor = System.Drawing.Color.Transparent
        Me.chkTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTax.Location = New System.Drawing.Point(39, 209)
        Me.chkTax.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkTax.Name = "chkTax"
        Me.chkTax.Size = New System.Drawing.Size(55, 28)
        Me.chkTax.TabIndex = 84
        Me.chkTax.Text = "Tax"
        Me.chkTax.UseVisualStyleBackColor = False
        '
        'numAmount
        '
        Me.numAmount.DecimalPlaces = 2
        Me.numAmount.InterceptArrowKeys = False
        Me.numAmount.Location = New System.Drawing.Point(95, 66)
        Me.numAmount.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numAmount.Maximum = New Decimal(New Integer() {-1530494977, 232830, 0, 0})
        Me.numAmount.Minimum = New Decimal(New Integer() {-1530494977, 232830, 0, -2147483648})
        Me.numAmount.Name = "numAmount"
        Me.numAmount.Size = New System.Drawing.Size(235, 23)
        Me.numAmount.TabIndex = 81
        Me.numAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numAmount.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(32, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Account"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(33, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 16)
        Me.Label2.TabIndex = 94
        Me.Label2.Text = "Amount"
        '
        'rtbParticular
        '
        Me.rtbParticular.Location = New System.Drawing.Point(95, 96)
        Me.rtbParticular.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rtbParticular.Name = "rtbParticular"
        Me.rtbParticular.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.rtbParticular.Size = New System.Drawing.Size(490, 67)
        Me.rtbParticular.TabIndex = 85
        Me.rtbParticular.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(22, 101)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 96
        Me.Label3.Text = "Particular"
        '
        'ThisType
        '
        Me.ThisType.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ThisType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ThisType.Location = New System.Drawing.Point(95, 42)
        Me.ThisType.Name = "ThisType"
        Me.ThisType.Size = New System.Drawing.Size(466, 23)
        Me.ThisType.TabIndex = 98
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(51, 44)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "Type"
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Location = New System.Drawing.Point(562, 15)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(31, 26)
        Me.btnBrowse.TabIndex = 100017
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(413, 207)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 28)
        Me.btnOK.TabIndex = 100018
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(505, 207)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 100019
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmAddExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(602, 248)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.ThisType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rtbParticular)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbClass)
        Me.Controls.Add(Me.xlblSelection)
        Me.Controls.Add(Me.cmbAccounts)
        Me.Controls.Add(Me.chkTax)
        Me.Controls.Add(Me.numAmount)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddExpenses"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Expenses"
        CType(Me.numAmount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbClass As ComboBox
    Friend WithEvents xlblSelection As Label
    Friend WithEvents cmbAccounts As ComboBox
    Friend WithEvents chkTax As CheckBox
    Friend WithEvents numAmount As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents rtbParticular As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ThisType As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnBrowse As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
