<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmComponents
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCode = New System.Windows.Forms.ComboBox()
        Me.cmbDescription = New System.Windows.Forms.ComboBox()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.numRate = New System.Windows.Forms.NumericUpDown()
        Me.xQty = New System.Windows.Forms.Label()
        Me.xRate = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(33, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Barcode"
        '
        'cmbCode
        '
        Me.cmbCode.FormattingEnabled = True
        Me.cmbCode.Location = New System.Drawing.Point(98, 15)
        Me.cmbCode.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbCode.Name = "cmbCode"
        Me.cmbCode.Size = New System.Drawing.Size(218, 24)
        Me.cmbCode.TabIndex = 1
        '
        'cmbDescription
        '
        Me.cmbDescription.FormattingEnabled = True
        Me.cmbDescription.Location = New System.Drawing.Point(98, 43)
        Me.cmbDescription.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDescription.Name = "cmbDescription"
        Me.cmbDescription.Size = New System.Drawing.Size(594, 24)
        Me.cmbDescription.TabIndex = 3
        '
        'numQty
        '
        Me.numQty.DecimalPlaces = 2
        Me.numQty.Location = New System.Drawing.Point(98, 71)
        Me.numQty.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numQty.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(135, 23)
        Me.numQty.TabIndex = 4
        Me.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numQty.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numRate
        '
        Me.numRate.DecimalPlaces = 2
        Me.numRate.Location = New System.Drawing.Point(98, 101)
        Me.numRate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numRate.Maximum = New Decimal(New Integer() {99999, 0, 0, 0})
        Me.numRate.Name = "numRate"
        Me.numRate.Size = New System.Drawing.Size(135, 23)
        Me.numRate.TabIndex = 5
        Me.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numRate.ThousandsSeparator = True
        '
        'xQty
        '
        Me.xQty.AutoSize = True
        Me.xQty.BackColor = System.Drawing.Color.Transparent
        Me.xQty.Location = New System.Drawing.Point(26, 74)
        Me.xQty.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xQty.Name = "xQty"
        Me.xQty.Size = New System.Drawing.Size(67, 16)
        Me.xQty.TabIndex = 6
        Me.xQty.Text = "Quanitity"
        '
        'xRate
        '
        Me.xRate.AutoSize = True
        Me.xRate.BackColor = System.Drawing.Color.Transparent
        Me.xRate.Location = New System.Drawing.Point(55, 103)
        Me.xRate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xRate.Name = "xRate"
        Me.xRate.Size = New System.Drawing.Size(37, 16)
        Me.xRate.TabIndex = 7
        Me.xRate.Text = "Rate"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(606, 101)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 28)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "&Update"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(14, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Description"
        '
        'frmComponents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 139)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.xRate)
        Me.Controls.Add(Me.xQty)
        Me.Controls.Add(Me.numRate)
        Me.Controls.Add(Me.numQty)
        Me.Controls.Add(Me.cmbDescription)
        Me.Controls.Add(Me.cmbCode)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmComponents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Components"
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCode As ComboBox
    Friend WithEvents cmbDescription As ComboBox
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents numRate As NumericUpDown
    Friend WithEvents xQty As Label
    Friend WithEvents xRate As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents Label2 As Label
End Class
