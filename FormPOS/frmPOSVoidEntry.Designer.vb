<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSVoidEntry
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
        Me.dgvSalesReceiptList = New System.Windows.Forms.DataGridView()
        Me.btnCLOSE = New System.Windows.Forms.Button()
        Me.btnVOID = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        CType(Me.dgvSalesReceiptList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSalesReceiptList
        '
        Me.dgvSalesReceiptList.AllowUserToAddRows = False
        Me.dgvSalesReceiptList.AllowUserToDeleteRows = False
        Me.dgvSalesReceiptList.AllowUserToResizeColumns = False
        Me.dgvSalesReceiptList.AllowUserToResizeRows = False
        Me.dgvSalesReceiptList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSalesReceiptList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSalesReceiptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSalesReceiptList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSalesReceiptList.Location = New System.Drawing.Point(3, 3)
        Me.dgvSalesReceiptList.MultiSelect = False
        Me.dgvSalesReceiptList.Name = "dgvSalesReceiptList"
        Me.dgvSalesReceiptList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.dgvSalesReceiptList.RowHeadersVisible = False
        Me.dgvSalesReceiptList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSalesReceiptList.Size = New System.Drawing.Size(738, 421)
        Me.dgvSalesReceiptList.TabIndex = 48
        '
        'btnCLOSE
        '
        Me.btnCLOSE.BackColor = System.Drawing.Color.White
        Me.btnCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCLOSE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLOSE.Location = New System.Drawing.Point(648, 430)
        Me.btnCLOSE.Name = "btnCLOSE"
        Me.btnCLOSE.Size = New System.Drawing.Size(92, 34)
        Me.btnCLOSE.TabIndex = 51
        Me.btnCLOSE.Text = "CLOSE"
        Me.btnCLOSE.UseVisualStyleBackColor = False
        '
        'btnVOID
        '
        Me.btnVOID.BackColor = System.Drawing.Color.DarkRed
        Me.btnVOID.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnVOID.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVOID.ForeColor = System.Drawing.Color.White
        Me.btnVOID.Location = New System.Drawing.Point(531, 430)
        Me.btnVOID.Name = "btnVOID"
        Me.btnVOID.Size = New System.Drawing.Size(112, 34)
        Me.btnVOID.TabIndex = 50
        Me.btnVOID.Text = "Remove"
        Me.btnVOID.UseVisualStyleBackColor = False
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.White
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPreview.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.Location = New System.Drawing.Point(3, 430)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(157, 34)
        Me.btnPreview.TabIndex = 52
        Me.btnPreview.Text = "Preview Details"
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'FrmPOSVoidEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(743, 467)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnCLOSE)
        Me.Controls.Add(Me.btnVOID)
        Me.Controls.Add(Me.dgvSalesReceiptList)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSVoidEntry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Entry List"
        CType(Me.dgvSalesReceiptList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvSalesReceiptList As DataGridView
    Friend WithEvents btnCLOSE As Button
    Friend WithEvents btnVOID As Button
    Friend WithEvents btnPreview As Button
End Class
