<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemUnitRelated
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
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.cmbSymbol = New System.Windows.Forms.ComboBox()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.numRate = New System.Windows.Forms.NumericUpDown()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbUnit
        '
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(82, 15)
        Me.cmbUnit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(179, 24)
        Me.cmbUnit.TabIndex = 0
        '
        'cmbSymbol
        '
        Me.cmbSymbol.FormattingEnabled = True
        Me.cmbSymbol.Location = New System.Drawing.Point(264, 15)
        Me.cmbSymbol.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSymbol.Name = "cmbSymbol"
        Me.cmbSymbol.Size = New System.Drawing.Size(101, 24)
        Me.cmbSymbol.TabIndex = 1
        '
        'numQty
        '
        Me.numQty.Location = New System.Drawing.Point(82, 42)
        Me.numQty.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numQty.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(125, 23)
        Me.numQty.TabIndex = 2
        Me.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numRate
        '
        Me.numRate.DecimalPlaces = 2
        Me.numRate.Location = New System.Drawing.Point(82, 69)
        Me.numRate.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numRate.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numRate.Name = "numRate"
        Me.numRate.Size = New System.Drawing.Size(125, 23)
        Me.numRate.TabIndex = 3
        Me.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(82, 96)
        Me.txtBarcode.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(283, 23)
        Me.txtBarcode.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(14, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Unit Size"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(16, 44)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Quantity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(40, 71)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Rate"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(16, 100)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Barcode"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(279, 141)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 28)
        Me.btnOK.TabIndex = 12
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmItemUnitRelated
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(374, 186)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.numRate)
        Me.Controls.Add(Me.numQty)
        Me.Controls.Add(Me.cmbSymbol)
        Me.Controls.Add(Me.cmbUnit)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemUnitRelated"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Unit Related"
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbUnit As ComboBox
    Friend WithEvents cmbSymbol As ComboBox
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents numRate As NumericUpDown
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnOK As Button
End Class
