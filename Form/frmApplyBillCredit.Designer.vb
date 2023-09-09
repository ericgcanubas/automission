<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmApplyBillCredit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvAvailable = New System.Windows.Forms.DataGridView()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblBalance_Due = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblORG_AMOUNT = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCreditUsed = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblDISCOUNT_USED = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblAmount_Due = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblDATE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvAvailable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvAvailable)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 158)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(675, 195)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Available P.O Credits"
        '
        'dgvAvailable
        '
        Me.dgvAvailable.AllowUserToAddRows = False
        Me.dgvAvailable.AllowUserToDeleteRows = False
        Me.dgvAvailable.AllowUserToResizeColumns = False
        Me.dgvAvailable.AllowUserToResizeRows = False
        Me.dgvAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAvailable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvAvailable.ColumnHeadersHeight = 35
        Me.dgvAvailable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAvailable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAvailable.Location = New System.Drawing.Point(5, 20)
        Me.dgvAvailable.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvAvailable.MultiSelect = False
        Me.dgvAvailable.Name = "dgvAvailable"
        Me.dgvAvailable.ReadOnly = True
        Me.dgvAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAvailable.Size = New System.Drawing.Size(665, 171)
        Me.dgvAvailable.TabIndex = 3
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(16, 365)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(169, 22)
        Me.lblTotal.TabIndex = 14
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblBalance_Due)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.lblORG_AMOUNT)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.lblCreditUsed)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblDISCOUNT_USED)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblCODE)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblAmount_Due)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblDATE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 10)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(675, 140)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Purchase Order"
        '
        'lblBalance_Due
        '
        Me.lblBalance_Due.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblBalance_Due.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblBalance_Due.Location = New System.Drawing.Point(513, 105)
        Me.lblBalance_Due.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblBalance_Due.Name = "lblBalance_Due"
        Me.lblBalance_Due.Size = New System.Drawing.Size(152, 25)
        Me.lblBalance_Due.TabIndex = 19
        Me.lblBalance_Due.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(415, 110)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Balance Due"
        '
        'lblORG_AMOUNT
        '
        Me.lblORG_AMOUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblORG_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblORG_AMOUNT.Location = New System.Drawing.Point(105, 76)
        Me.lblORG_AMOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblORG_AMOUNT.Name = "lblORG_AMOUNT"
        Me.lblORG_AMOUNT.Size = New System.Drawing.Size(195, 25)
        Me.lblORG_AMOUNT.TabIndex = 17
        Me.lblORG_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(44, 80)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Amount"
        '
        'lblCreditUsed
        '
        Me.lblCreditUsed.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCreditUsed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditUsed.Location = New System.Drawing.Point(513, 78)
        Me.lblCreditUsed.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCreditUsed.Name = "lblCreditUsed"
        Me.lblCreditUsed.Size = New System.Drawing.Size(152, 25)
        Me.lblCreditUsed.TabIndex = 15
        Me.lblCreditUsed.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(421, 82)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Credit Used"
        '
        'lblDISCOUNT_USED
        '
        Me.lblDISCOUNT_USED.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDISCOUNT_USED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDISCOUNT_USED.Location = New System.Drawing.Point(513, 50)
        Me.lblDISCOUNT_USED.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDISCOUNT_USED.Name = "lblDISCOUNT_USED"
        Me.lblDISCOUNT_USED.Size = New System.Drawing.Size(152, 25)
        Me.lblDISCOUNT_USED.TabIndex = 13
        Me.lblDISCOUNT_USED.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(405, 54)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(101, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Discount Used"
        '
        'lblCODE
        '
        Me.lblCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCODE.Location = New System.Drawing.Point(513, 23)
        Me.lblCODE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(152, 25)
        Me.lblCODE.TabIndex = 9
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(405, 27)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 16)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Reference No."
        '
        'lblAmount_Due
        '
        Me.lblAmount_Due.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAmount_Due.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmount_Due.Location = New System.Drawing.Point(105, 103)
        Me.lblAmount_Due.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAmount_Due.Name = "lblAmount_Due"
        Me.lblAmount_Due.Size = New System.Drawing.Size(195, 25)
        Me.lblAmount_Due.TabIndex = 5
        Me.lblAmount_Due.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 107)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Amount Due"
        '
        'lblDATE
        '
        Me.lblDATE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDATE.Location = New System.Drawing.Point(105, 49)
        Me.lblDATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDATE.Name = "lblDATE"
        Me.lblDATE.Size = New System.Drawing.Size(195, 25)
        Me.lblDATE.TabIndex = 3
        Me.lblDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(63, 52)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Date"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Location = New System.Drawing.Point(105, 22)
        Me.lblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(290, 25)
        Me.lblName.TabIndex = 1
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(49, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Vendor"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(496, 361)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 28)
        Me.btnOK.TabIndex = 42
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(592, 361)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 43
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmApplyBillCredit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(691, 398)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblTotal)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmApplyBillCredit"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apply Bill Credits"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvAvailable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents dgvAvailable As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblBalance_Due As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblORG_AMOUNT As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents lblCreditUsed As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblDISCOUNT_USED As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblCODE As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblAmount_Due As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblDATE As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
