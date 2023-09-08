<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSStartingCash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOSStartingCash))
        Me.numAMOUNT = New System.Windows.Forms.NumericUpDown()
        Me.btnOK = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuGradientPanel5 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BunifuGradientPanel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'numAMOUNT
        '
        Me.numAMOUNT.DecimalPlaces = 2
        Me.numAMOUNT.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAMOUNT.Location = New System.Drawing.Point(8, 42)
        Me.numAMOUNT.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.numAMOUNT.Name = "numAMOUNT"
        Me.numAMOUNT.Size = New System.Drawing.Size(209, 39)
        Me.numAMOUNT.TabIndex = 0
        Me.numAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numAMOUNT.ThousandsSeparator = True
        Me.numAMOUNT.Value = New Decimal(New Integer() {999999999, 0, 0, 0})
        '
        'btnOK
        '
        Me.btnOK.ActiveBorderThickness = 1
        Me.btnOK.ActiveCornerRadius = 20
        Me.btnOK.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnOK.ActiveForecolor = System.Drawing.Color.White
        Me.btnOK.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.ButtonText = "OK"
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnOK.IdleBorderThickness = 1
        Me.btnOK.IdleCornerRadius = 20
        Me.btnOK.IdleFillColor = System.Drawing.Color.White
        Me.btnOK.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnOK.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnOK.Location = New System.Drawing.Point(16, 82)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(197, 45)
        Me.btnOK.TabIndex = 3
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuGradientPanel5
        '
        Me.BunifuGradientPanel5.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel5.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel5.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel5.Controls.Add(Me.Label2)
        Me.BunifuGradientPanel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.BunifuGradientPanel5.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel5.GradientBottomRight = System.Drawing.Color.DodgerBlue
        Me.BunifuGradientPanel5.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.BunifuGradientPanel5.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel5.Location = New System.Drawing.Point(0, 0)
        Me.BunifuGradientPanel5.Name = "BunifuGradientPanel5"
        Me.BunifuGradientPanel5.Quality = 10
        Me.BunifuGradientPanel5.Size = New System.Drawing.Size(228, 35)
        Me.BunifuGradientPanel5.TabIndex = 164
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(42, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Petty Cash"
        '
        'frmPOSStartingCash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(228, 134)
        Me.Controls.Add(Me.BunifuGradientPanel5)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.numAMOUNT)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSStartingCash"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PETTY CASH"
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BunifuGradientPanel5.ResumeLayout(False)
        Me.BunifuGradientPanel5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents numAMOUNT As NumericUpDown
    Friend WithEvents btnOK As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuGradientPanel5 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label2 As Label
End Class
