<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountJournalDuplicateRemove
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
        Me.dgvCLASS = New System.Windows.Forms.DataGridView()
        Me.btnReferesh = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblRunning = New System.Windows.Forms.Label()
        CType(Me.dgvCLASS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCLASS
        '
        Me.dgvCLASS.AllowUserToAddRows = False
        Me.dgvCLASS.AllowUserToDeleteRows = False
        Me.dgvCLASS.AllowUserToOrderColumns = True
        Me.dgvCLASS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCLASS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCLASS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvCLASS.Location = New System.Drawing.Point(4, 38)
        Me.dgvCLASS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvCLASS.Name = "dgvCLASS"
        Me.dgvCLASS.ReadOnly = True
        Me.dgvCLASS.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvCLASS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCLASS.Size = New System.Drawing.Size(1233, 481)
        Me.dgvCLASS.TabIndex = 14
        '
        'btnReferesh
        '
        Me.btnReferesh.Location = New System.Drawing.Point(4, 2)
        Me.btnReferesh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReferesh.Name = "btnReferesh"
        Me.btnReferesh.Size = New System.Drawing.Size(100, 28)
        Me.btnReferesh.TabIndex = 13
        Me.btnReferesh.Text = "Refresh"
        Me.btnReferesh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(112, 2)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Remove All"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Location = New System.Drawing.Point(412, 9)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(103, 16)
        Me.lblTotal.TabIndex = 16
        Me.lblTotal.Text = "Total Record 0"
        '
        'lblRunning
        '
        Me.lblRunning.AutoSize = True
        Me.lblRunning.Location = New System.Drawing.Point(595, 9)
        Me.lblRunning.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRunning.Name = "lblRunning"
        Me.lblRunning.Size = New System.Drawing.Size(114, 16)
        Me.lblRunning.TabIndex = 17
        Me.lblRunning.Text = "Total Progress 0"
        '
        'frmAccountJournalDuplicateRemove
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1239, 523)
        Me.Controls.Add(Me.lblRunning)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dgvCLASS)
        Me.Controls.Add(Me.btnReferesh)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmAccountJournalDuplicateRemove"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Journal Duplicate Remove"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvCLASS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCLASS As DataGridView
    Friend WithEvents btnReferesh As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents lblTotal As Label
    Friend WithEvents lblRunning As Label
End Class
