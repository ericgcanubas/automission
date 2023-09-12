<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemLocationDefaults
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
        Me.cmbPurchases = New System.Windows.Forms.ComboBox()
        Me.cmbSales = New System.Windows.Forms.ComboBox()
        Me.cmbShipping = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbPurchases
        '
        Me.cmbPurchases.FormattingEnabled = True
        Me.cmbPurchases.Location = New System.Drawing.Point(115, 36)
        Me.cmbPurchases.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPurchases.Name = "cmbPurchases"
        Me.cmbPurchases.Size = New System.Drawing.Size(169, 24)
        Me.cmbPurchases.TabIndex = 0
        '
        'cmbSales
        '
        Me.cmbSales.FormattingEnabled = True
        Me.cmbSales.Location = New System.Drawing.Point(115, 63)
        Me.cmbSales.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbSales.Name = "cmbSales"
        Me.cmbSales.Size = New System.Drawing.Size(169, 24)
        Me.cmbSales.TabIndex = 1
        '
        'cmbShipping
        '
        Me.cmbShipping.FormattingEnabled = True
        Me.cmbShipping.Location = New System.Drawing.Point(115, 90)
        Me.cmbShipping.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbShipping.Name = "cmbShipping"
        Me.cmbShipping.Size = New System.Drawing.Size(169, 24)
        Me.cmbShipping.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(13, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Purchase Unit"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(13, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Sales Unit"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(13, 93)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(93, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Shipping Unit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(13, 10)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Location"
        '
        'lblLocation
        '
        Me.lblLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocation.Location = New System.Drawing.Point(115, 9)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(300, 23)
        Me.lblLocation.TabIndex = 9
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(330, 131)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(85, 28)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FrmItemLocationDefaults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 170)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbShipping)
        Me.Controls.Add(Me.cmbSales)
        Me.Controls.Add(Me.cmbPurchases)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItemLocationDefaults"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Location Defaults"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbPurchases As ComboBox
    Friend WithEvents cmbSales As ComboBox
    Friend WithEvents cmbShipping As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents btnOK As Button
End Class
