<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSTax
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOSTax))
        Me.btnVatZero = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnVatEx = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnVatIn = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnCancel = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.SuspendLayout()
        '
        'btnVatZero
        '
        Me.btnVatZero.ActiveBorderThickness = 1
        Me.btnVatZero.ActiveCornerRadius = 20
        Me.btnVatZero.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnVatZero.ActiveForecolor = System.Drawing.Color.White
        Me.btnVatZero.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnVatZero.BackColor = System.Drawing.SystemColors.Control
        Me.btnVatZero.BackgroundImage = CType(resources.GetObject("btnVatZero.BackgroundImage"), System.Drawing.Image)
        Me.btnVatZero.ButtonText = "0% Vat"
        Me.btnVatZero.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVatZero.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVatZero.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnVatZero.IdleBorderThickness = 1
        Me.btnVatZero.IdleCornerRadius = 20
        Me.btnVatZero.IdleFillColor = System.Drawing.Color.White
        Me.btnVatZero.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnVatZero.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnVatZero.Location = New System.Drawing.Point(9, 6)
        Me.btnVatZero.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.btnVatZero.Name = "btnVatZero"
        Me.btnVatZero.Size = New System.Drawing.Size(242, 67)
        Me.btnVatZero.TabIndex = 4
        Me.btnVatZero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVatEx
        '
        Me.btnVatEx.ActiveBorderThickness = 1
        Me.btnVatEx.ActiveCornerRadius = 20
        Me.btnVatEx.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnVatEx.ActiveForecolor = System.Drawing.Color.White
        Me.btnVatEx.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnVatEx.BackColor = System.Drawing.SystemColors.Control
        Me.btnVatEx.BackgroundImage = CType(resources.GetObject("btnVatEx.BackgroundImage"), System.Drawing.Image)
        Me.btnVatEx.ButtonText = "12% Vat (Exclusive)"
        Me.btnVatEx.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVatEx.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVatEx.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnVatEx.IdleBorderThickness = 1
        Me.btnVatEx.IdleCornerRadius = 20
        Me.btnVatEx.IdleFillColor = System.Drawing.Color.White
        Me.btnVatEx.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnVatEx.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnVatEx.Location = New System.Drawing.Point(9, 74)
        Me.btnVatEx.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.btnVatEx.Name = "btnVatEx"
        Me.btnVatEx.Size = New System.Drawing.Size(242, 67)
        Me.btnVatEx.TabIndex = 5
        Me.btnVatEx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVatIn
        '
        Me.btnVatIn.ActiveBorderThickness = 1
        Me.btnVatIn.ActiveCornerRadius = 20
        Me.btnVatIn.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnVatIn.ActiveForecolor = System.Drawing.Color.White
        Me.btnVatIn.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnVatIn.BackColor = System.Drawing.SystemColors.Control
        Me.btnVatIn.BackgroundImage = CType(resources.GetObject("btnVatIn.BackgroundImage"), System.Drawing.Image)
        Me.btnVatIn.ButtonText = "12% Vat (Inclusive)"
        Me.btnVatIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVatIn.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVatIn.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnVatIn.IdleBorderThickness = 1
        Me.btnVatIn.IdleCornerRadius = 20
        Me.btnVatIn.IdleFillColor = System.Drawing.Color.White
        Me.btnVatIn.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnVatIn.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnVatIn.Location = New System.Drawing.Point(9, 146)
        Me.btnVatIn.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.btnVatIn.Name = "btnVatIn"
        Me.btnVatIn.Size = New System.Drawing.Size(242, 67)
        Me.btnVatIn.TabIndex = 6
        Me.btnVatIn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.ActiveBorderThickness = 1
        Me.btnCancel.ActiveCornerRadius = 20
        Me.btnCancel.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnCancel.ActiveForecolor = System.Drawing.Color.White
        Me.btnCancel.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.BackgroundImage = CType(resources.GetObject("btnCancel.BackgroundImage"), System.Drawing.Image)
        Me.btnCancel.ButtonText = "Cancel"
        Me.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCancel.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnCancel.IdleBorderThickness = 1
        Me.btnCancel.IdleCornerRadius = 20
        Me.btnCancel.IdleFillColor = System.Drawing.Color.White
        Me.btnCancel.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnCancel.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnCancel.Location = New System.Drawing.Point(9, 217)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(9, 8, 9, 8)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(242, 67)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPOSTax
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(261, 292)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnVatIn)
        Me.Controls.Add(Me.btnVatEx)
        Me.Controls.Add(Me.btnVatZero)
        Me.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(8, 5, 8, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSTax"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Output Tax"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnVatZero As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnVatEx As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnVatIn As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnCancel As Bunifu.Framework.UI.BunifuThinButton2
End Class
