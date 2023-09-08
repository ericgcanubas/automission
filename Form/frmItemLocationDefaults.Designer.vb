<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemLocationDefaults
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
        Me.cmbPurchases = New System.Windows.Forms.ComboBox()
        Me.cmbSales = New System.Windows.Forms.ComboBox()
        Me.cmbShipping = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbPurchases
        '
        Me.cmbPurchases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPurchases.FormattingEnabled = True
        Me.cmbPurchases.Location = New System.Drawing.Point(69, 43)
        Me.cmbPurchases.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbPurchases.Name = "cmbPurchases"
        Me.cmbPurchases.Size = New System.Drawing.Size(122, 21)
        Me.cmbPurchases.TabIndex = 0
        '
        'cmbSales
        '
        Me.cmbSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSales.FormattingEnabled = True
        Me.cmbSales.Location = New System.Drawing.Point(69, 65)
        Me.cmbSales.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbSales.Name = "cmbSales"
        Me.cmbSales.Size = New System.Drawing.Size(122, 21)
        Me.cmbSales.TabIndex = 1
        '
        'cmbShipping
        '
        Me.cmbShipping.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbShipping.FormattingEnabled = True
        Me.cmbShipping.Location = New System.Drawing.Point(69, 87)
        Me.cmbShipping.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.cmbShipping.Name = "cmbShipping"
        Me.cmbShipping.Size = New System.Drawing.Size(122, 21)
        Me.cmbShipping.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(40, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "P.O"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(36, 68)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "SRP"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(34, 90)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Ship"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(19, 23)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Branch"
        '
        'lblLocation
        '
        Me.lblLocation.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLocation.Location = New System.Drawing.Point(69, 21)
        Me.lblLocation.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(235, 19)
        Me.lblLocation.TabIndex = 9
        '
        'btnOK
        '
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(229, 143)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 13
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label5.Location = New System.Drawing.Point(0, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(313, 45)
        Me.Label5.TabIndex = 14
        '
        'frmItemLocationDefaults
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(313, 177)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblLocation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbShipping)
        Me.Controls.Add(Me.cmbSales)
        Me.Controls.Add(Me.cmbPurchases)
        Me.Controls.Add(Me.Label5)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemLocationDefaults"
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
    Friend WithEvents Label5 As Label
End Class
