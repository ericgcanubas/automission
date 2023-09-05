<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSLogTransfer
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
        Me.dgvPOSLog = New System.Windows.Forms.DataGridView()
        Me.btnTransfer = New System.Windows.Forms.Button()
        CType(Me.dgvPOSLog, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPOSLog
        '
        Me.dgvPOSLog.AllowUserToAddRows = False
        Me.dgvPOSLog.AllowUserToDeleteRows = False
        Me.dgvPOSLog.AllowUserToResizeColumns = False
        Me.dgvPOSLog.AllowUserToResizeRows = False
        Me.dgvPOSLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPOSLog.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvPOSLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPOSLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPOSLog.Location = New System.Drawing.Point(12, 12)
        Me.dgvPOSLog.MultiSelect = False
        Me.dgvPOSLog.Name = "dgvPOSLog"
        Me.dgvPOSLog.ReadOnly = True
        Me.dgvPOSLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPOSLog.Size = New System.Drawing.Size(699, 344)
        Me.dgvPOSLog.TabIndex = 0
        '
        'btnTransfer
        '
        Me.btnTransfer.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer.Location = New System.Drawing.Point(593, 362)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(118, 28)
        Me.btnTransfer.TabIndex = 1
        Me.btnTransfer.Text = "Transfer Now.."
        Me.btnTransfer.UseVisualStyleBackColor = True
        '
        'FrmPOSLogTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 392)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.dgvPOSLog)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSLogTransfer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POSLog Transfer"
        CType(Me.dgvPOSLog, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvPOSLog As DataGridView
    Friend WithEvents btnTransfer As Button
End Class
