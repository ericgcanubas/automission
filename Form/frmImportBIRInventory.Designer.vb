<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportBIRInventory
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
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowseFIle = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.pbStatus = New System.Windows.Forms.ProgressBar()
        Me.lblSTATUS = New System.Windows.Forms.Label()
        Me.btnConfig = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dgvCollectData = New System.Windows.Forms.DataGridView()
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tssStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnInventoryAdjustment = New System.Windows.Forms.Button()
        Me.btnChecking = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvCollectData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(11, 16)
        Me.txtPath.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(529, 20)
        Me.txtPath.TabIndex = 0
        '
        'btnBrowseFIle
        '
        Me.btnBrowseFIle.Location = New System.Drawing.Point(540, 15)
        Me.btnBrowseFIle.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBrowseFIle.Name = "btnBrowseFIle"
        Me.btnBrowseFIle.Size = New System.Drawing.Size(31, 22)
        Me.btnBrowseFIle.TabIndex = 1
        Me.btnBrowseFIle.Text = "..."
        Me.btnBrowseFIle.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(11, 41)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(104, 39)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start Import"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'pbStatus
        '
        Me.pbStatus.Location = New System.Drawing.Point(12, 115)
        Me.pbStatus.Name = "pbStatus"
        Me.pbStatus.Size = New System.Drawing.Size(679, 27)
        Me.pbStatus.TabIndex = 3
        '
        'lblSTATUS
        '
        Me.lblSTATUS.AutoSize = True
        Me.lblSTATUS.Location = New System.Drawing.Point(654, 99)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(37, 13)
        Me.lblSTATUS.TabIndex = 4
        Me.lblSTATUS.Text = "Status"
        '
        'btnConfig
        '
        Me.btnConfig.Location = New System.Drawing.Point(614, 16)
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.Size = New System.Drawing.Size(77, 23)
        Me.btnConfig.TabIndex = 5
        Me.btnConfig.Text = "Configure"
        Me.btnConfig.UseVisualStyleBackColor = True
        '
        'dgvCollectData
        '
        Me.dgvCollectData.AllowUserToAddRows = False
        Me.dgvCollectData.AllowUserToDeleteRows = False
        Me.dgvCollectData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCollectData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCollectData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvCollectData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCollectData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.code, Me.description, Me.cost, Me.qty, Me.unit})
        Me.dgvCollectData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCollectData.Location = New System.Drawing.Point(12, 148)
        Me.dgvCollectData.MultiSelect = False
        Me.dgvCollectData.Name = "dgvCollectData"
        Me.dgvCollectData.ReadOnly = True
        Me.dgvCollectData.RowHeadersVisible = False
        Me.dgvCollectData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCollectData.Size = New System.Drawing.Size(684, 363)
        Me.dgvCollectData.TabIndex = 6
        '
        'code
        '
        Me.code.FillWeight = 76.81525!
        Me.code.HeaderText = "Code"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        '
        'description
        '
        Me.description.FillWeight = 253.8071!
        Me.description.HeaderText = "Description"
        Me.description.Name = "description"
        Me.description.ReadOnly = True
        '
        'cost
        '
        Me.cost.FillWeight = 56.45921!
        Me.cost.HeaderText = "Cost"
        Me.cost.Name = "cost"
        Me.cost.ReadOnly = True
        '
        'qty
        '
        Me.qty.FillWeight = 56.45921!
        Me.qty.HeaderText = "Qty"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        '
        'unit
        '
        Me.unit.FillWeight = 56.45921!
        Me.unit.HeaderText = "Unit"
        Me.unit.Name = "unit"
        Me.unit.ReadOnly = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 514)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(708, 22)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tssStatus
        '
        Me.tssStatus.Name = "tssStatus"
        Me.tssStatus.Size = New System.Drawing.Size(0, 17)
        '
        'btnInventoryAdjustment
        '
        Me.btnInventoryAdjustment.Enabled = False
        Me.btnInventoryAdjustment.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInventoryAdjustment.Location = New System.Drawing.Point(436, 41)
        Me.btnInventoryAdjustment.Name = "btnInventoryAdjustment"
        Me.btnInventoryAdjustment.Size = New System.Drawing.Size(104, 39)
        Me.btnInventoryAdjustment.TabIndex = 8
        Me.btnInventoryAdjustment.Text = "Inv. Adjustment"
        Me.btnInventoryAdjustment.UseVisualStyleBackColor = True
        '
        'btnChecking
        '
        Me.btnChecking.Enabled = False
        Me.btnChecking.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChecking.Location = New System.Drawing.Point(210, 41)
        Me.btnChecking.Name = "btnChecking"
        Me.btnChecking.Size = New System.Drawing.Size(138, 39)
        Me.btnChecking.TabIndex = 9
        Me.btnChecking.Text = "Checking Unregistered Items"
        Me.btnChecking.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(148, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = ">>"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(378, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = ">>"
        '
        'FrmImportBIRInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 536)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnChecking)
        Me.Controls.Add(Me.btnInventoryAdjustment)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.dgvCollectData)
        Me.Controls.Add(Me.btnConfig)
        Me.Controls.Add(Me.lblSTATUS)
        Me.Controls.Add(Me.pbStatus)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.btnBrowseFIle)
        Me.Controls.Add(Me.txtPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmImportBIRInventory"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Import BIR Inventory"
        CType(Me.dgvCollectData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPath As TextBox
    Friend WithEvents btnBrowseFIle As Button
    Friend WithEvents btnStart As Button
    Friend WithEvents pbStatus As ProgressBar
    Friend WithEvents lblSTATUS As Label
    Friend WithEvents btnConfig As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents dgvCollectData As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssStatus As ToolStripStatusLabel
    Friend WithEvents code As DataGridViewTextBoxColumn
    Friend WithEvents description As DataGridViewTextBoxColumn
    Friend WithEvents cost As DataGridViewTextBoxColumn
    Friend WithEvents qty As DataGridViewTextBoxColumn
    Friend WithEvents unit As DataGridViewTextBoxColumn
    Friend WithEvents btnInventoryAdjustment As Button
    Friend WithEvents btnChecking As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
End Class
