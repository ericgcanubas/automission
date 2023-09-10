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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnectionList))
        Me.listCon = New System.Windows.Forms.ListBox()
        Me.BtnConnect = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.NewConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DeleteConnectionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'listCon
        '
        Me.listCon.Cursor = System.Windows.Forms.Cursors.Hand
        Me.listCon.Font = New System.Drawing.Font("Century Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.listCon.ForeColor = System.Drawing.Color.Navy
        Me.listCon.FormattingEnabled = True
        Me.listCon.HorizontalExtent = 30
        Me.listCon.HorizontalScrollbar = True
        Me.listCon.ItemHeight = 22
        Me.listCon.Items.AddRange(New Object() {"asasdsadsa", "asdasd", "asddsa"})
        Me.listCon.Location = New System.Drawing.Point(5, 4)
        Me.listCon.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.listCon.Name = "listCon"
        Me.listCon.Size = New System.Drawing.Size(294, 224)
        Me.listCon.Sorted = True
        Me.listCon.TabIndex = 0
        '
        'BtnConnect
        '
        Me.BtnConnect.BackColor = System.Drawing.Color.SteelBlue
        Me.BtnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnConnect.Font = New System.Drawing.Font("Century Gothic", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnConnect.ForeColor = System.Drawing.Color.White
        Me.BtnConnect.Location = New System.Drawing.Point(5, 232)
        Me.BtnConnect.Name = "BtnConnect"
        Me.BtnConnect.Size = New System.Drawing.Size(294, 43)
        Me.BtnConnect.TabIndex = 15
        Me.BtnConnect.Text = "Connect"
        Me.BtnConnect.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewConnectionToolStripMenuItem, Me.EditConnectionToolStripMenuItem, Me.DeleteConnectionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(196, 70)
        '
        'NewConnectionToolStripMenuItem
        '
        Me.NewConnectionToolStripMenuItem.Name = "NewConnectionToolStripMenuItem"
        Me.NewConnectionToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.NewConnectionToolStripMenuItem.Text = "New Connection"
        '
        'EditConnectionToolStripMenuItem
        '
        Me.EditConnectionToolStripMenuItem.Name = "EditConnectionToolStripMenuItem"
        Me.EditConnectionToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.EditConnectionToolStripMenuItem.Text = "Edit Connection"
        '
        'DeleteConnectionToolStripMenuItem
        '
        Me.DeleteConnectionToolStripMenuItem.Name = "DeleteConnectionToolStripMenuItem"
        Me.DeleteConnectionToolStripMenuItem.Size = New System.Drawing.Size(195, 22)
        Me.DeleteConnectionToolStripMenuItem.Text = "Delete Connection"
        '
        'FrmConnectionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(304, 281)
        Me.Controls.Add(Me.BtnConnect)
        Me.Controls.Add(Me.listCon)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnectionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection List"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listCon As ListBox
    Friend WithEvents BtnConnect As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents NewConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EditConnectionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeleteConnectionToolStripMenuItem As ToolStripMenuItem
End Class
