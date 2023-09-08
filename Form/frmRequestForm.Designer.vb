<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRequestForm
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
        Me.dgvRequest = New System.Windows.Forms.DataGridView()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnUncheckAll = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.dgvRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvRequest
        '
        Me.dgvRequest.AllowUserToAddRows = False
        Me.dgvRequest.AllowUserToDeleteRows = False
        Me.dgvRequest.AllowUserToResizeColumns = False
        Me.dgvRequest.AllowUserToResizeRows = False
        Me.dgvRequest.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvRequest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvRequest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvRequest.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvRequest.Location = New System.Drawing.Point(4, 7)
        Me.dgvRequest.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvRequest.MultiSelect = False
        Me.dgvRequest.Name = "dgvRequest"
        Me.dgvRequest.ReadOnly = True
        Me.dgvRequest.RowHeadersVisible = False
        Me.dgvRequest.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRequest.Size = New System.Drawing.Size(900, 139)
        Me.dgvRequest.TabIndex = 0
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.AllowUserToResizeColumns = False
        Me.dgvItem.AllowUserToResizeRows = False
        Me.dgvItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvItem.Location = New System.Drawing.Point(4, 153)
        Me.dgvItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvItem.MultiSelect = False
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        Me.dgvItem.RowHeadersVisible = False
        Me.dgvItem.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItem.Size = New System.Drawing.Size(900, 364)
        Me.dgvItem.TabIndex = 1
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCheckAll.Location = New System.Drawing.Point(4, 521)
        Me.btnCheckAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(85, 25)
        Me.btnCheckAll.TabIndex = 2
        Me.btnCheckAll.Text = "Check All"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUncheckAll.Location = New System.Drawing.Point(97, 521)
        Me.btnUncheckAll.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(92, 25)
        Me.btnUncheckAll.TabIndex = 3
        Me.btnUncheckAll.Text = "Uncheck All"
        Me.btnUncheckAll.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(718, 522)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(85, 25)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(819, 522)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 25)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmRequestForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(911, 549)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnUncheckAll)
        Me.Controls.Add(Me.btnCheckAll)
        Me.Controls.Add(Me.dgvItem)
        Me.Controls.Add(Me.dgvRequest)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRequestForm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchase Request"
        CType(Me.dgvRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvItem As DataGridView
    Friend WithEvents dgvRequest As DataGridView
    Friend WithEvents btnCheckAll As Button
    Friend WithEvents btnUncheckAll As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnCancel As Button
End Class
