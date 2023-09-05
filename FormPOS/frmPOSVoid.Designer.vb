<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSVoid
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
        Me.dgvPAYMENT = New System.Windows.Forms.DataGridView()
        Me.dgvITEM = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblSales = New System.Windows.Forms.Label()
        Me.lblPAYMENT_CODE = New System.Windows.Forms.Label()
        Me.lblOR = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnDELETE = New System.Windows.Forms.Button()
        Me.lblPAID = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCLOSE = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.dgvPAYMENT, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvITEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPAYMENT
        '
        Me.dgvPAYMENT.AllowUserToAddRows = False
        Me.dgvPAYMENT.AllowUserToDeleteRows = False
        Me.dgvPAYMENT.AllowUserToResizeColumns = False
        Me.dgvPAYMENT.AllowUserToResizeRows = False
        Me.dgvPAYMENT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPAYMENT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPAYMENT.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvPAYMENT.Location = New System.Drawing.Point(12, 79)
        Me.dgvPAYMENT.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvPAYMENT.MultiSelect = False
        Me.dgvPAYMENT.Name = "dgvPAYMENT"
        Me.dgvPAYMENT.ReadOnly = True
        Me.dgvPAYMENT.RowHeadersVisible = False
        Me.dgvPAYMENT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPAYMENT.Size = New System.Drawing.Size(417, 402)
        Me.dgvPAYMENT.TabIndex = 0
        '
        'dgvITEM
        '
        Me.dgvITEM.AllowUserToAddRows = False
        Me.dgvITEM.AllowUserToDeleteRows = False
        Me.dgvITEM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvITEM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvITEM.Location = New System.Drawing.Point(435, 79)
        Me.dgvITEM.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvITEM.MultiSelect = False
        Me.dgvITEM.Name = "dgvITEM"
        Me.dgvITEM.ReadOnly = True
        Me.dgvITEM.RowHeadersVisible = False
        Me.dgvITEM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvITEM.Size = New System.Drawing.Size(371, 402)
        Me.dgvITEM.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(438, 8)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Payment Ref # :"
        Me.Label1.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(80, 492)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Total Sales"
        '
        'lblSales
        '
        Me.lblSales.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblSales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSales.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSales.Location = New System.Drawing.Point(12, 509)
        Me.lblSales.Name = "lblSales"
        Me.lblSales.Size = New System.Drawing.Size(155, 28)
        Me.lblSales.TabIndex = 6
        Me.lblSales.Text = "0.00"
        Me.lblSales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblPAYMENT_CODE
        '
        Me.lblPAYMENT_CODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblPAYMENT_CODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPAYMENT_CODE.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAYMENT_CODE.Location = New System.Drawing.Point(564, 4)
        Me.lblPAYMENT_CODE.Name = "lblPAYMENT_CODE"
        Me.lblPAYMENT_CODE.Size = New System.Drawing.Size(242, 23)
        Me.lblPAYMENT_CODE.TabIndex = 7
        Me.lblPAYMENT_CODE.Visible = False
        '
        'lblOR
        '
        Me.lblOR.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblOR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOR.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOR.Location = New System.Drawing.Point(564, 30)
        Me.lblOR.Name = "lblOR"
        Me.lblOR.Size = New System.Drawing.Size(242, 23)
        Me.lblOR.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(437, 33)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 16)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Office Receipt # :"
        '
        'btnDELETE
        '
        Me.btnDELETE.BackColor = System.Drawing.Color.DarkRed
        Me.btnDELETE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDELETE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDELETE.ForeColor = System.Drawing.Color.White
        Me.btnDELETE.Location = New System.Drawing.Point(608, 496)
        Me.btnDELETE.Name = "btnDELETE"
        Me.btnDELETE.Size = New System.Drawing.Size(89, 44)
        Me.btnDELETE.TabIndex = 12
        Me.btnDELETE.Text = "DELETE"
        Me.btnDELETE.UseVisualStyleBackColor = False
        '
        'lblPAID
        '
        Me.lblPAID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblPAID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPAID.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPAID.Location = New System.Drawing.Point(437, 509)
        Me.lblPAID.Name = "lblPAID"
        Me.lblPAID.Size = New System.Drawing.Size(149, 28)
        Me.lblPAID.TabIndex = 14
        Me.lblPAID.Text = "0.00"
        Me.lblPAID.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(482, 492)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Amount  Paid"
        '
        'btnCLOSE
        '
        Me.btnCLOSE.BackColor = System.Drawing.Color.White
        Me.btnCLOSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCLOSE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCLOSE.Location = New System.Drawing.Point(715, 498)
        Me.btnCLOSE.Name = "btnCLOSE"
        Me.btnCLOSE.Size = New System.Drawing.Size(92, 40)
        Me.btnCLOSE.TabIndex = 15
        Me.btnCLOSE.Text = "CLOSE"
        Me.btnCLOSE.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(12, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Entry List"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(438, 59)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Order Details"
        '
        'FrmPOSVoid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(819, 545)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnCLOSE)
        Me.Controls.Add(Me.lblPAID)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnDELETE)
        Me.Controls.Add(Me.lblOR)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblPAYMENT_CODE)
        Me.Controls.Add(Me.lblSales)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvITEM)
        Me.Controls.Add(Me.dgvPAYMENT)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSVoid"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Void Entry"
        CType(Me.dgvPAYMENT, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvITEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvPAYMENT As DataGridView
    Friend WithEvents dgvITEM As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblSales As Label
    Friend WithEvents lblPAYMENT_CODE As Label
    Friend WithEvents lblOR As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnDELETE As Button
    Friend WithEvents lblPAID As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCLOSE As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
End Class
