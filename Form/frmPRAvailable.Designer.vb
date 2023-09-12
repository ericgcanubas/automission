<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPRAvailable
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dgvDocument = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.dgvStock = New System.Windows.Forms.DataGridView()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnUncheckAll = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDocument, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.dgvDocument)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 39)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupBox1.Size = New System.Drawing.Size(673, 222)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Bills"
        '
        'dgvDocument
        '
        Me.dgvDocument.AllowUserToAddRows = False
        Me.dgvDocument.AllowUserToDeleteRows = False
        Me.dgvDocument.AllowUserToOrderColumns = True
        Me.dgvDocument.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDocument.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvDocument.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDocument.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvDocument.Location = New System.Drawing.Point(3, 18)
        Me.dgvDocument.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvDocument.MultiSelect = False
        Me.dgvDocument.Name = "dgvDocument"
        Me.dgvDocument.ReadOnly = True
        Me.dgvDocument.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDocument.Size = New System.Drawing.Size(667, 202)
        Me.dgvDocument.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Location"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(87, 9)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(226, 24)
        Me.cmbLOCATION_ID.TabIndex = 0
        '
        'dgvStock
        '
        Me.dgvStock.AllowUserToAddRows = False
        Me.dgvStock.AllowUserToDeleteRows = False
        Me.dgvStock.AllowUserToResizeRows = False
        Me.dgvStock.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvStock.ColumnHeadersHeight = 35
        Me.dgvStock.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvStock.Location = New System.Drawing.Point(16, 281)
        Me.dgvStock.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.dgvStock.MultiSelect = False
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.ReadOnly = True
        Me.dgvStock.RowHeadersVisible = False
        Me.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStock.Size = New System.Drawing.Size(669, 214)
        Me.dgvStock.TabIndex = 1
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(16, 622)
        Me.btnCheckAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(86, 27)
        Me.btnCheckAll.TabIndex = 3
        Me.btnCheckAll.Text = "Check All"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.Location = New System.Drawing.Point(109, 622)
        Me.btnUncheckAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(97, 27)
        Me.btnUncheckAll.TabIndex = 4
        Me.btnUncheckAll.Text = "Uncheck All"
        Me.btnUncheckAll.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(610, 506)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'FrmPRAvailable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(694, 537)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnUncheckAll)
        Me.Controls.Add(Me.btnCheckAll)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.dgvStock)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPRAvailable"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Request"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.dgvDocument, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents dgvStock As DataGridView
    Friend WithEvents dgvDocument As DataGridView
    Friend WithEvents btnCheckAll As Button
    Friend WithEvents btnUncheckAll As Button
    Friend WithEvents btnOK As Button
End Class
