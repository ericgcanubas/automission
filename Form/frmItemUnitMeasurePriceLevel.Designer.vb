<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemUnitMeasurePriceLevel
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
        Me.cmbPriceLevel = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numCustomprice = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.numCustomprice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbPriceLevel
        '
        Me.cmbPriceLevel.FormattingEnabled = True
        Me.cmbPriceLevel.Location = New System.Drawing.Point(105, 13)
        Me.cmbPriceLevel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPriceLevel.Name = "cmbPriceLevel"
        Me.cmbPriceLevel.Size = New System.Drawing.Size(318, 24)
        Me.cmbPriceLevel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Price Level"
        '
        'numCustomprice
        '
        Me.numCustomprice.DecimalPlaces = 2
        Me.numCustomprice.Location = New System.Drawing.Point(105, 44)
        Me.numCustomprice.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCustomprice.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numCustomprice.Name = "numCustomprice"
        Me.numCustomprice.Size = New System.Drawing.Size(122, 23)
        Me.numCustomprice.TabIndex = 2
        Me.numCustomprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 47)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Custom Price"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(304, 62)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(119, 28)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "&Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FrmItemUnitMeasurePriceLevel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 100)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numCustomprice)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPriceLevel)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItemUnitMeasurePriceLevel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Size - Rate Level"
        CType(Me.numCustomprice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbPriceLevel As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents numCustomprice As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOK As Button
End Class
