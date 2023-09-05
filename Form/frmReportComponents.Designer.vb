<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportComponents
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
        Me.dgvReportComponent = New System.Windows.Forms.DataGridView()
        Me.lklDelete = New System.Windows.Forms.LinkLabel()
        Me.lklEdit = New System.Windows.Forms.LinkLabel()
        Me.lklNew = New System.Windows.Forms.LinkLabel()
        CType(Me.dgvReportComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvReportComponent
        '
        Me.dgvReportComponent.AllowUserToAddRows = False
        Me.dgvReportComponent.AllowUserToDeleteRows = False
        Me.dgvReportComponent.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReportComponent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvReportComponent.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvReportComponent.Location = New System.Drawing.Point(12, 24)
        Me.dgvReportComponent.Name = "dgvReportComponent"
        Me.dgvReportComponent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportComponent.Size = New System.Drawing.Size(764, 589)
        Me.dgvReportComponent.TabIndex = 3
        '
        'lklDelete
        '
        Me.lklDelete.AutoSize = True
        Me.lklDelete.BackColor = System.Drawing.Color.Transparent
        Me.lklDelete.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklDelete.Location = New System.Drawing.Point(81, 8)
        Me.lklDelete.Name = "lklDelete"
        Me.lklDelete.Size = New System.Drawing.Size(40, 13)
        Me.lklDelete.TabIndex = 10
        Me.lklDelete.TabStop = True
        Me.lklDelete.Text = "Delete"
        '
        'lklEdit
        '
        Me.lklEdit.AutoSize = True
        Me.lklEdit.BackColor = System.Drawing.Color.Transparent
        Me.lklEdit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklEdit.Location = New System.Drawing.Point(48, 8)
        Me.lklEdit.Name = "lklEdit"
        Me.lklEdit.Size = New System.Drawing.Size(27, 13)
        Me.lklEdit.TabIndex = 9
        Me.lklEdit.TabStop = True
        Me.lklEdit.Text = "Edit"
        '
        'lklNew
        '
        Me.lklNew.AutoSize = True
        Me.lklNew.BackColor = System.Drawing.Color.Transparent
        Me.lklNew.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lklNew.Location = New System.Drawing.Point(12, 8)
        Me.lklNew.Name = "lklNew"
        Me.lklNew.Size = New System.Drawing.Size(30, 13)
        Me.lklNew.TabIndex = 8
        Me.lklNew.TabStop = True
        Me.lklNew.Text = "New"
        '
        'frmReportComponents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(788, 625)
        Me.Controls.Add(Me.lklDelete)
        Me.Controls.Add(Me.lklEdit)
        Me.Controls.Add(Me.lklNew)
        Me.Controls.Add(Me.dgvReportComponent)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportComponents"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Components"
        CType(Me.dgvReportComponent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvReportComponent As DataGridView
    Friend WithEvents lklDelete As LinkLabel
    Friend WithEvents lklEdit As LinkLabel
    Friend WithEvents lklNew As LinkLabel
End Class
