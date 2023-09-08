<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmConnectionList
    Inherits System.Windows.Forms.Form
    ' Inherits MaterialSkin.Controls.MaterialForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnectionList))
        Me.listCon = New System.Windows.Forms.ListBox()
        Me.BunifuThinButton21 = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.BunifuCustomLabel1 = New Bunifu.Framework.UI.BunifuCustomLabel()
        Me.SuspendLayout()
        '
        'listCon
        '
        Me.listCon.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.listCon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listCon.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listCon.ForeColor = System.Drawing.Color.Navy
        Me.listCon.FormattingEnabled = True
        Me.listCon.HorizontalExtent = 30
        Me.listCon.HorizontalScrollbar = True
        Me.listCon.ItemHeight = 20
        Me.listCon.Items.AddRange(New Object() {"asasdsadsa", "asdasd", "asddsa"})
        Me.listCon.Location = New System.Drawing.Point(5, 32)
        Me.listCon.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.listCon.Name = "listCon"
        Me.listCon.Size = New System.Drawing.Size(294, 224)
        Me.listCon.Sorted = True
        Me.listCon.TabIndex = 0
        '
        'BunifuThinButton21
        '
        Me.BunifuThinButton21.ActiveBorderThickness = 1
        Me.BunifuThinButton21.ActiveCornerRadius = 20
        Me.BunifuThinButton21.ActiveFillColor = System.Drawing.Color.Navy
        Me.BunifuThinButton21.ActiveForecolor = System.Drawing.Color.White
        Me.BunifuThinButton21.ActiveLineColor = System.Drawing.Color.Blue
        Me.BunifuThinButton21.BackColor = System.Drawing.Color.White
        Me.BunifuThinButton21.BackgroundImage = CType(resources.GetObject("BunifuThinButton21.BackgroundImage"), System.Drawing.Image)
        Me.BunifuThinButton21.ButtonText = "Connect"
        Me.BunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BunifuThinButton21.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuThinButton21.ForeColor = System.Drawing.Color.Navy
        Me.BunifuThinButton21.IdleBorderThickness = 1
        Me.BunifuThinButton21.IdleCornerRadius = 20
        Me.BunifuThinButton21.IdleFillColor = System.Drawing.Color.White
        Me.BunifuThinButton21.IdleForecolor = System.Drawing.Color.Navy
        Me.BunifuThinButton21.IdleLineColor = System.Drawing.Color.Navy
        Me.BunifuThinButton21.Location = New System.Drawing.Point(156, 259)
        Me.BunifuThinButton21.Margin = New System.Windows.Forms.Padding(5)
        Me.BunifuThinButton21.Name = "BunifuThinButton21"
        Me.BunifuThinButton21.Size = New System.Drawing.Size(143, 41)
        Me.BunifuThinButton21.TabIndex = 14
        Me.BunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BunifuCustomLabel1
        '
        Me.BunifuCustomLabel1.AutoSize = True
        Me.BunifuCustomLabel1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BunifuCustomLabel1.Location = New System.Drawing.Point(2, 13)
        Me.BunifuCustomLabel1.Name = "BunifuCustomLabel1"
        Me.BunifuCustomLabel1.Size = New System.Drawing.Size(125, 16)
        Me.BunifuCustomLabel1.TabIndex = 15
        Me.BunifuCustomLabel1.Text = "Select Connection"
        '
        'frmConnectionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(304, 304)
        Me.Controls.Add(Me.BunifuCustomLabel1)
        Me.Controls.Add(Me.BunifuThinButton21)
        Me.Controls.Add(Me.listCon)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnectionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents listCon As ListBox
    Friend WithEvents BunifuThinButton21 As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuCustomLabel1 As Bunifu.Framework.UI.BunifuCustomLabel
End Class
