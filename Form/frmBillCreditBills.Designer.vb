<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBillCreditBills
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
        Me.lblRemainingCredit = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblCreditAmount = New System.Windows.Forms.Label()
        Me.lblDATE = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvAvailable = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvAvailable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblRemainingCredit
        '
        Me.lblRemainingCredit.BackColor = System.Drawing.Color.White
        Me.lblRemainingCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRemainingCredit.Location = New System.Drawing.Point(536, 78)
        Me.lblRemainingCredit.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRemainingCredit.Name = "lblRemainingCredit"
        Me.lblRemainingCredit.Size = New System.Drawing.Size(141, 25)
        Me.lblRemainingCredit.TabIndex = 13
        Me.lblRemainingCredit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(406, 82)
        Me.Label13.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(116, 16)
        Me.Label13.TabIndex = 12
        Me.Label13.Text = "Remaining Credit"
        '
        'lblCODE
        '
        Me.lblCODE.BackColor = System.Drawing.Color.White
        Me.lblCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCODE.Location = New System.Drawing.Point(536, 50)
        Me.lblCODE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(141, 25)
        Me.lblCODE.TabIndex = 9
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(426, 55)
        Me.Label17.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(100, 16)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Reference No."
        '
        'lblCreditAmount
        '
        Me.lblCreditAmount.BackColor = System.Drawing.Color.White
        Me.lblCreditAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreditAmount.Location = New System.Drawing.Point(136, 78)
        Me.lblCreditAmount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblCreditAmount.Name = "lblCreditAmount"
        Me.lblCreditAmount.Size = New System.Drawing.Size(226, 25)
        Me.lblCreditAmount.TabIndex = 5
        Me.lblCreditAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDATE
        '
        Me.lblDATE.BackColor = System.Drawing.Color.White
        Me.lblDATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDATE.Location = New System.Drawing.Point(136, 50)
        Me.lblDATE.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDATE.Name = "lblDATE"
        Me.lblDATE.Size = New System.Drawing.Size(226, 25)
        Me.lblDATE.TabIndex = 3
        Me.lblDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(92, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Date"
        '
        'lblName
        '
        Me.lblName.BackColor = System.Drawing.Color.White
        Me.lblName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblName.Location = New System.Drawing.Point(136, 22)
        Me.lblName.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(541, 25)
        Me.lblName.TabIndex = 1
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(31, 82)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(101, 16)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Credit Amount"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(79, 26)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Vendor"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRemainingCredit)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.lblCODE)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.lblCreditAmount)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblDATE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.lblName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(693, 116)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Credits"
        '
        'lblTotal
        '
        Me.lblTotal.BackColor = System.Drawing.Color.Transparent
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Location = New System.Drawing.Point(60, 394)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(149, 23)
        Me.lblTotal.TabIndex = 14
        Me.lblTotal.Text = "0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(10, 397)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Total"
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
        Me.dgvAvailable.Size = New System.Drawing.Size(683, 226)
        Me.dgvAvailable.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.dgvAvailable)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 129)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(693, 250)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Available Bill"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(517, 395)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(86, 28)
        Me.btnOK.TabIndex = 137
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(609, 395)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 138
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmBillCreditBills
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(709, 433)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmBillCreditBills"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Apply Credit to PO"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvAvailable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblRemainingCredit As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents lblCODE As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents lblCreditAmount As Label
    Friend WithEvents lblDATE As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblName As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblTotal As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dgvAvailable As DataGridView
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
End Class
