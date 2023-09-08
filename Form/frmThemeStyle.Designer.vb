<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmThemeStyle
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmThemeStyle))
        Me.dgvTheme = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCOLOR_CODE = New System.Windows.Forms.TextBox()
        Me.txtBANNER_PATH = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBACKGROUND_PATH = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTITLE = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtLEFT_BANNER_PATH = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsClose = New System.Windows.Forms.ToolStripButton()
        Me.tsSaveNew = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel7 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel6 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.dgvTheme, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTheme
        '
        Me.dgvTheme.AllowUserToAddRows = False
        Me.dgvTheme.AllowUserToDeleteRows = False
        Me.dgvTheme.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTheme.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvTheme.Location = New System.Drawing.Point(11, 71)
        Me.dgvTheme.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvTheme.Name = "dgvTheme"
        Me.dgvTheme.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvTheme.Size = New System.Drawing.Size(237, 198)
        Me.dgvTheme.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(256, 123)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Color Code"
        '
        'txtCOLOR_CODE
        '
        Me.txtCOLOR_CODE.Location = New System.Drawing.Point(381, 121)
        Me.txtCOLOR_CODE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtCOLOR_CODE.Name = "txtCOLOR_CODE"
        Me.txtCOLOR_CODE.Size = New System.Drawing.Size(160, 23)
        Me.txtCOLOR_CODE.TabIndex = 9
        '
        'txtBANNER_PATH
        '
        Me.txtBANNER_PATH.Location = New System.Drawing.Point(381, 146)
        Me.txtBANNER_PATH.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBANNER_PATH.Name = "txtBANNER_PATH"
        Me.txtBANNER_PATH.Size = New System.Drawing.Size(329, 23)
        Me.txtBANNER_PATH.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 148)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Banner Path"
        '
        'txtBACKGROUND_PATH
        '
        Me.txtBACKGROUND_PATH.Location = New System.Drawing.Point(381, 196)
        Me.txtBACKGROUND_PATH.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtBACKGROUND_PATH.Name = "txtBACKGROUND_PATH"
        Me.txtBACKGROUND_PATH.Size = New System.Drawing.Size(329, 23)
        Me.txtBACKGROUND_PATH.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(256, 198)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Background Path"
        '
        'txtTITLE
        '
        Me.txtTITLE.Location = New System.Drawing.Point(381, 95)
        Me.txtTITLE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtTITLE.Name = "txtTITLE"
        Me.txtTITLE.Size = New System.Drawing.Size(329, 23)
        Me.txtTITLE.TabIndex = 17
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(256, 97)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Title"
        '
        'txtLEFT_BANNER_PATH
        '
        Me.txtLEFT_BANNER_PATH.Location = New System.Drawing.Point(381, 171)
        Me.txtLEFT_BANNER_PATH.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtLEFT_BANNER_PATH.Name = "txtLEFT_BANNER_PATH"
        Me.txtLEFT_BANNER_PATH.Size = New System.Drawing.Size(329, 23)
        Me.txtLEFT_BANNER_PATH.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(256, 173)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Left Banner Path"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsClose, Me.tsSaveNew, Me.ToolStripLabel2, Me.ToolStripButton1, Me.ToolStripLabel1, Me.ToolStripLabel7, Me.ToolStripLabel6, Me.ToolStripButton2, Me.ToolStripLabel3, Me.ToolStripButton3, Me.ToolStripLabel4, Me.ToolStripLabel5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 37)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(727, 25)
        Me.ToolStrip1.TabIndex = 61
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsClose
        '
        Me.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsClose.Image = CType(resources.GetObject("tsClose.Image"), System.Drawing.Image)
        Me.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClose.Name = "tsClose"
        Me.tsClose.Size = New System.Drawing.Size(46, 22)
        Me.tsClose.Text = "Close"
        '
        'tsSaveNew
        '
        Me.tsSaveNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsSaveNew.Image = CType(resources.GetObject("tsSaveNew.Image"), System.Drawing.Image)
        Me.tsSaveNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSaveNew.Name = "tsSaveNew"
        Me.tsSaveNew.Size = New System.Drawing.Size(47, 22)
        Me.tsSaveNew.Text = "Apply"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(53, 22)
        Me.ToolStripButton1.Text = "Delete"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel1.Text = "       "
        '
        'ToolStripLabel7
        '
        Me.ToolStripLabel7.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel7.Name = "ToolStripLabel7"
        Me.ToolStripLabel7.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel7.Text = "       "
        '
        'ToolStripLabel6
        '
        Me.ToolStripLabel6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel6.Name = "ToolStripLabel6"
        Me.ToolStripLabel6.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel6.Text = "       "
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(39, 22)
        Me.ToolStripButton2.Text = "New"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(44, 22)
        Me.ToolStripButton3.Text = "Save"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel4.Text = "       "
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(42, 22)
        Me.ToolStripLabel5.Text = "       "
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(727, 37)
        Me.Panel1.TabIndex = 60
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(4, 5)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 25)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Theme Style"
        '
        'frmThemeStyle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(727, 277)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtLEFT_BANNER_PATH)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTITLE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBACKGROUND_PATH)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtBANNER_PATH)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCOLOR_CODE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvTheme)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmThemeStyle"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Theme Style"
        CType(Me.dgvTheme, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvTheme As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCOLOR_CODE As TextBox
    Friend WithEvents txtBANNER_PATH As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtBACKGROUND_PATH As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTITLE As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtLEFT_BANNER_PATH As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsClose As ToolStripButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents tsSaveNew As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripLabel2 As ToolStripSeparator
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents ToolStripLabel7 As ToolStripLabel
    Friend WithEvents ToolStripLabel6 As ToolStripLabel
    Friend WithEvents ToolStripButton2 As ToolStripButton
    Friend WithEvents ToolStripLabel3 As ToolStripSeparator
    Friend WithEvents ToolStripButton3 As ToolStripButton
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
End Class
