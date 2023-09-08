<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSTableDetails
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOSTableDetails))
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.dgvPAYMENT = New System.Windows.Forms.DataGridView()
        Me.btnPRINT_RECEIPT = New System.Windows.Forms.Button()
        Me.btnPRINTOS = New System.Windows.Forms.Button()
        CType(Me.dgvPAYMENT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(318, 247)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(143, 67)
        Me.btnOK.TabIndex = 6
        Me.btnOK.Text = "Set as Available"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(469, 247)
        Me.btnCANCEL.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(96, 67)
        Me.btnCANCEL.TabIndex = 7
        Me.btnCANCEL.Text = "CANCEL"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'dgvPAYMENT
        '
        Me.dgvPAYMENT.AllowUserToAddRows = False
        Me.dgvPAYMENT.AllowUserToDeleteRows = False
        Me.dgvPAYMENT.AllowUserToResizeColumns = False
        Me.dgvPAYMENT.AllowUserToResizeRows = False
        Me.dgvPAYMENT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPAYMENT.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvPAYMENT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPAYMENT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPAYMENT.Location = New System.Drawing.Point(4, 8)
        Me.dgvPAYMENT.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvPAYMENT.Name = "dgvPAYMENT"
        Me.dgvPAYMENT.RowHeadersVisible = False
        Me.dgvPAYMENT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPAYMENT.Size = New System.Drawing.Size(561, 229)
        Me.dgvPAYMENT.TabIndex = 13
        '
        'btnPRINT_RECEIPT
        '
        Me.btnPRINT_RECEIPT.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPRINT_RECEIPT.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnPRINT_RECEIPT.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPRINT_RECEIPT.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINT_RECEIPT.ForeColor = System.Drawing.Color.White
        Me.btnPRINT_RECEIPT.Image = CType(resources.GetObject("btnPRINT_RECEIPT.Image"), System.Drawing.Image)
        Me.btnPRINT_RECEIPT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPRINT_RECEIPT.Location = New System.Drawing.Point(6, 247)
        Me.btnPRINT_RECEIPT.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPRINT_RECEIPT.Name = "btnPRINT_RECEIPT"
        Me.btnPRINT_RECEIPT.Size = New System.Drawing.Size(136, 67)
        Me.btnPRINT_RECEIPT.TabIndex = 12
        Me.btnPRINT_RECEIPT.Text = "PRINT " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "RECEIPT"
        Me.btnPRINT_RECEIPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPRINT_RECEIPT.UseVisualStyleBackColor = False
        '
        'btnPRINTOS
        '
        Me.btnPRINTOS.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPRINTOS.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.btnPRINTOS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPRINTOS.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPRINTOS.ForeColor = System.Drawing.Color.White
        Me.btnPRINTOS.Image = CType(resources.GetObject("btnPRINTOS.Image"), System.Drawing.Image)
        Me.btnPRINTOS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPRINTOS.Location = New System.Drawing.Point(149, 247)
        Me.btnPRINTOS.Name = "btnPRINTOS"
        Me.btnPRINTOS.Size = New System.Drawing.Size(136, 68)
        Me.btnPRINTOS.TabIndex = 182
        Me.btnPRINTOS.Text = "PRINT" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "ORDER" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SLIP"
        Me.btnPRINTOS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPRINTOS.UseVisualStyleBackColor = False
        '
        'frmPOSTableDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 322)
        Me.Controls.Add(Me.btnPRINTOS)
        Me.Controls.Add(Me.dgvPAYMENT)
        Me.Controls.Add(Me.btnPRINT_RECEIPT)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnOK)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSTableDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Details"
        CType(Me.dgvPAYMENT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents btnPRINT_RECEIPT As Button
    Friend WithEvents dgvPAYMENT As DataGridView
    Friend WithEvents btnPRINTOS As Button
End Class
