<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmReportManager
    Inherits System.Windows.Forms.Form

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
        Me.dgvReportComponent = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNAME = New System.Windows.Forms.Label()
        Me.lklDelete = New System.Windows.Forms.LinkLabel()
        Me.lklEdit = New System.Windows.Forms.LinkLabel()
        Me.lklNew = New System.Windows.Forms.LinkLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.dgvReportComponent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
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
        Me.dgvReportComponent.Location = New System.Drawing.Point(9, 79)
        Me.dgvReportComponent.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvReportComponent.Name = "dgvReportComponent"
        Me.dgvReportComponent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvReportComponent.Size = New System.Drawing.Size(661, 448)
        Me.dgvReportComponent.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Report Name"
        '
        'lblNAME
        '
        Me.lblNAME.AutoSize = True
        Me.lblNAME.Location = New System.Drawing.Point(120, 24)
        Me.lblNAME.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNAME.Name = "lblNAME"
        Me.lblNAME.Size = New System.Drawing.Size(106, 16)
        Me.lblNAME.TabIndex = 4
        Me.lblNAME.Text = "XXXXXXXXXXX"
        '
        'lklDelete
        '
        Me.lklDelete.AutoSize = True
        Me.lklDelete.BackColor = System.Drawing.Color.Transparent
        Me.lklDelete.Location = New System.Drawing.Point(101, 59)
        Me.lklDelete.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lklDelete.Name = "lklDelete"
        Me.lklDelete.Size = New System.Drawing.Size(49, 16)
        Me.lklDelete.TabIndex = 7
        Me.lklDelete.TabStop = True
        Me.lklDelete.Text = "Delete"
        '
        'lklEdit
        '
        Me.lklEdit.AutoSize = True
        Me.lklEdit.BackColor = System.Drawing.Color.Transparent
        Me.lklEdit.Location = New System.Drawing.Point(57, 59)
        Me.lklEdit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lklEdit.Name = "lklEdit"
        Me.lklEdit.Size = New System.Drawing.Size(32, 16)
        Me.lklEdit.TabIndex = 6
        Me.lklEdit.TabStop = True
        Me.lklEdit.Text = "Edit"
        '
        'lklNew
        '
        Me.lklNew.AutoSize = True
        Me.lklNew.BackColor = System.Drawing.Color.Transparent
        Me.lklNew.Location = New System.Drawing.Point(9, 59)
        Me.lklNew.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lklNew.Name = "lklNew"
        Me.lklNew.Size = New System.Drawing.Size(35, 16)
        Me.lklNew.TabIndex = 5
        Me.lklNew.TabStop = True
        Me.lklNew.Text = "New"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(8, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(677, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.FileToolStripMenuItem.Text = "Components"
        '
        'FrmReportManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(677, 537)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.lklDelete)
        Me.Controls.Add(Me.lklEdit)
        Me.Controls.Add(Me.lklNew)
        Me.Controls.Add(Me.lblNAME)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvReportComponent)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmReportManager"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Manager"
        CType(Me.dgvReportComponent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvReportComponent As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents lblNAME As Label
    Friend WithEvents lklDelete As LinkLabel
    Friend WithEvents lklEdit As LinkLabel
    Friend WithEvents lklNew As LinkLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
End Class
