<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSalesTaxRecompute
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
        Me.cmbITEM_ID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpUseDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pbListofTransaction = New System.Windows.Forms.ProgressBar()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.lblSTATUS = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'cmbITEM_ID
        '
        Me.cmbITEM_ID.FormattingEnabled = True
        Me.cmbITEM_ID.Location = New System.Drawing.Point(16, 36)
        Me.cmbITEM_ID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbITEM_ID.Name = "cmbITEM_ID"
        Me.cmbITEM_ID.Size = New System.Drawing.Size(468, 24)
        Me.cmbITEM_ID.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Item Description"
        '
        'dtpUseDate
        '
        Me.dtpUseDate.Checked = False
        Me.dtpUseDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpUseDate.Location = New System.Drawing.Point(291, 83)
        Me.dtpUseDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpUseDate.Name = "dtpUseDate"
        Me.dtpUseDate.ShowCheckBox = True
        Me.dtpUseDate.Size = New System.Drawing.Size(193, 23)
        Me.dtpUseDate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(287, 63)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Use Date When Start"
        '
        'pbListofTransaction
        '
        Me.pbListofTransaction.Location = New System.Drawing.Point(16, 151)
        Me.pbListofTransaction.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbListofTransaction.Name = "pbListofTransaction"
        Me.pbListofTransaction.Size = New System.Drawing.Size(468, 28)
        Me.pbListofTransaction.TabIndex = 4
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(15, 118)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(100, 28)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'lblSTATUS
        '
        Me.lblSTATUS.Location = New System.Drawing.Point(281, 118)
        Me.lblSTATUS.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSTATUS.Name = "lblSTATUS"
        Me.lblSTATUS.Size = New System.Drawing.Size(203, 28)
        Me.lblSTATUS.TabIndex = 7
        Me.lblSTATUS.Text = "1/1"
        Me.lblSTATUS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 65)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Location"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(16, 85)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(193, 24)
        Me.cmbLOCATION_ID.TabIndex = 9
        '
        'FrmSalesTaxRecompute
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 186)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.lblSTATUS)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.pbListofTransaction)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpUseDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbITEM_ID)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSalesTaxRecompute"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Tax Recompute"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbITEM_ID As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpUseDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents pbListofTransaction As ProgressBar
    Friend WithEvents btnStart As Button
    Friend WithEvents lblSTATUS As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
End Class
