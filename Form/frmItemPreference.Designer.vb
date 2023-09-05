<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmItemPreference
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
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numOrderPoint = New System.Windows.Forms.NumericUpDown()
        Me.numOrderQty = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numOrderLeadTime = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numOnHandMaxLimit = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbBinStock = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        CType(Me.numOrderPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOrderQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOrderLeadTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOnHandMaxLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(80, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Location"
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDescription.Location = New System.Drawing.Point(146, 9)
        Me.lblDescription.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(343, 23)
        Me.lblDescription.TabIndex = 1
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(61, 38)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Order Point"
        '
        'numOrderPoint
        '
        Me.numOrderPoint.Location = New System.Drawing.Point(146, 36)
        Me.numOrderPoint.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numOrderPoint.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numOrderPoint.Name = "numOrderPoint"
        Me.numOrderPoint.Size = New System.Drawing.Size(113, 23)
        Me.numOrderPoint.TabIndex = 3
        Me.numOrderPoint.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numOrderQty
        '
        Me.numOrderQty.Location = New System.Drawing.Point(146, 63)
        Me.numOrderQty.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numOrderQty.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numOrderQty.Name = "numOrderQty"
        Me.numOrderQty.Size = New System.Drawing.Size(113, 23)
        Me.numOrderQty.TabIndex = 5
        Me.numOrderQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(70, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Order Qty"
        '
        'numOrderLeadTime
        '
        Me.numOrderLeadTime.Location = New System.Drawing.Point(146, 90)
        Me.numOrderLeadTime.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numOrderLeadTime.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numOrderLeadTime.Name = "numOrderLeadTime"
        Me.numOrderLeadTime.Size = New System.Drawing.Size(113, 23)
        Me.numOrderLeadTime.TabIndex = 7
        Me.numOrderLeadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(28, 92)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(114, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Order Lead-time"
        '
        'numOnHandMaxLimit
        '
        Me.numOnHandMaxLimit.Location = New System.Drawing.Point(146, 117)
        Me.numOnHandMaxLimit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numOnHandMaxLimit.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numOnHandMaxLimit.Name = "numOnHandMaxLimit"
        Me.numOnHandMaxLimit.Size = New System.Drawing.Size(113, 23)
        Me.numOnHandMaxLimit.TabIndex = 9
        Me.numOnHandMaxLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(12, 119)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "On-Hand Max Limit"
        '
        'cmbBinStock
        '
        Me.cmbBinStock.FormattingEnabled = True
        Me.cmbBinStock.Location = New System.Drawing.Point(146, 144)
        Me.cmbBinStock.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbBinStock.Name = "cmbBinStock"
        Me.cmbBinStock.Size = New System.Drawing.Size(244, 24)
        Me.cmbBinStock.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(74, 148)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Stock Bin"
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(403, 142)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 28)
        Me.btnOK.TabIndex = 14
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'frmItemPreference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 182)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbBinStock)
        Me.Controls.Add(Me.numOnHandMaxLimit)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numOrderLeadTime)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numOrderQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numOrderPoint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemPreference"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Preference"
        CType(Me.numOrderPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOrderQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOrderLeadTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOnHandMaxLimit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents numOrderPoint As NumericUpDown
    Friend WithEvents numOrderQty As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents numOrderLeadTime As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents numOnHandMaxLimit As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbBinStock As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnOK As Button
End Class
