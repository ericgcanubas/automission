<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSRestoKitchenMonitoring
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPOSRestoKitchenMonitoring))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.xlblTIME = New System.Windows.Forms.Label()
        Me.btnDONE = New System.Windows.Forms.Button()
        Me.xlblTOTAL = New System.Windows.Forms.Label()
        Me.xlblSERVED = New System.Windows.Forms.Label()
        Me.dgvITEM = New System.Windows.Forms.DataGridView()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnCLOSE = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.dgvITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.xlblTIME)
        Me.Panel1.Controls.Add(Me.btnDONE)
        Me.Panel1.Controls.Add(Me.xlblTOTAL)
        Me.Panel1.Controls.Add(Me.xlblSERVED)
        Me.Panel1.Controls.Add(Me.dgvITEM)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.ForeColor = System.Drawing.Color.Black
        Me.Panel1.Location = New System.Drawing.Point(38, 51)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(448, 360)
        Me.Panel1.TabIndex = 0
        Me.Panel1.Visible = False
        '
        'xlblTIME
        '
        Me.xlblTIME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTIME.Location = New System.Drawing.Point(146, 3)
        Me.xlblTIME.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.xlblTIME.Name = "xlblTIME"
        Me.xlblTIME.Size = New System.Drawing.Size(231, 23)
        Me.xlblTIME.TabIndex = 5
        Me.xlblTIME.Text = "DELAY : HH:MM:SS"
        Me.xlblTIME.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnDONE
        '
        Me.btnDONE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDONE.BackColor = System.Drawing.Color.Red
        Me.btnDONE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDONE.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDONE.ForeColor = System.Drawing.Color.White
        Me.btnDONE.Location = New System.Drawing.Point(380, 2)
        Me.btnDONE.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDONE.Name = "btnDONE"
        Me.btnDONE.Size = New System.Drawing.Size(65, 50)
        Me.btnDONE.TabIndex = 9
        Me.btnDONE.Text = "X"
        Me.btnDONE.UseVisualStyleBackColor = False
        '
        'xlblTOTAL
        '
        Me.xlblTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblTOTAL.Location = New System.Drawing.Point(3, 28)
        Me.xlblTOTAL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.xlblTOTAL.Name = "xlblTOTAL"
        Me.xlblTOTAL.Size = New System.Drawing.Size(374, 22)
        Me.xlblTOTAL.TabIndex = 8
        Me.xlblTOTAL.Text = "TOTAL ORDER : 000,000.00"
        '
        'xlblSERVED
        '
        Me.xlblSERVED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblSERVED.Location = New System.Drawing.Point(3, 3)
        Me.xlblSERVED.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.xlblSERVED.Name = "xlblSERVED"
        Me.xlblSERVED.Size = New System.Drawing.Size(139, 23)
        Me.xlblSERVED.TabIndex = 0
        Me.xlblSERVED.Text = "SERVING NO. ##"
        '
        'dgvITEM
        '
        Me.dgvITEM.AllowUserToAddRows = False
        Me.dgvITEM.AllowUserToDeleteRows = False
        Me.dgvITEM.AllowUserToResizeColumns = False
        Me.dgvITEM.AllowUserToResizeRows = False
        Me.dgvITEM.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvITEM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvITEM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Description, Me.Qty, Me.Price, Me.Amount})
        Me.dgvITEM.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvITEM.Location = New System.Drawing.Point(1, 53)
        Me.dgvITEM.Margin = New System.Windows.Forms.Padding(2)
        Me.dgvITEM.MultiSelect = False
        Me.dgvITEM.Name = "dgvITEM"
        Me.dgvITEM.ReadOnly = True
        Me.dgvITEM.RowHeadersVisible = False
        Me.dgvITEM.Size = New System.Drawing.Size(446, 306)
        Me.dgvITEM.TabIndex = 6
        '
        'Description
        '
        Me.Description.HeaderText = "Descripton"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 220
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.ReadOnly = True
        Me.Qty.Width = 40
        '
        'Price
        '
        Me.Price.HeaderText = "Price"
        Me.Price.Name = "Price"
        Me.Price.ReadOnly = True
        Me.Price.Width = 60
        '
        'Amount
        '
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Width = 80
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 33)
        Me.FlowLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(884, 409)
        Me.FlowLayoutPanel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Navy
        Me.Panel2.Controls.Add(Me.btnReload)
        Me.Panel2.Controls.Add(Me.btnSettings)
        Me.Panel2.Controls.Add(Me.btnCLOSE)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(884, 33)
        Me.Panel2.TabIndex = 13
        '
        'btnReload
        '
        Me.btnReload.BackColor = System.Drawing.Color.White
        Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReload.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReload.ForeColor = System.Drawing.Color.White
        Me.btnReload.Image = CType(resources.GetObject("btnReload.Image"), System.Drawing.Image)
        Me.btnReload.Location = New System.Drawing.Point(35, 1)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(30, 30)
        Me.btnReload.TabIndex = 12
        Me.btnReload.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.White
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.White
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.Location = New System.Drawing.Point(2, 1)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(30, 30)
        Me.btnSettings.TabIndex = 11
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'btnCLOSE
        '
        Me.btnCLOSE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCLOSE.BackColor = System.Drawing.Color.Purple
        Me.btnCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCLOSE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLOSE.ForeColor = System.Drawing.Color.White
        Me.btnCLOSE.Location = New System.Drawing.Point(853, 1)
        Me.btnCLOSE.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCLOSE.Name = "btnCLOSE"
        Me.btnCLOSE.Size = New System.Drawing.Size(30, 30)
        Me.btnCLOSE.TabIndex = 10
        Me.btnCLOSE.Text = "X"
        Me.btnCLOSE.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        '
        'frmPOSRestoKitchenMonitoring
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 442)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmPOSRestoKitchenMonitoring"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvITEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents dgvITEM As DataGridView
    Friend WithEvents xlblTIME As Label
    Friend WithEvents xlblSERVED As Label
    Friend WithEvents xlblTOTAL As Label
    Friend WithEvents btnDONE As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnCLOSE As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents Price As DataGridViewTextBoxColumn
    Friend WithEvents Amount As DataGridViewTextBoxColumn
End Class
