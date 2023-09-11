<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmGotoInventoryAdjustment
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.cmbADJUSTMENT_TYPE_ID = New System.Windows.Forms.ComboBox()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGoto = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 14)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date as Of"
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(194, 14)
        Me.dtpDATE.Margin = New System.Windows.Forms.Padding(5)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(330, 29)
        Me.dtpDATE.TabIndex = 1
        '
        'cmbADJUSTMENT_TYPE_ID
        '
        Me.cmbADJUSTMENT_TYPE_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbADJUSTMENT_TYPE_ID.FormattingEnabled = True
        Me.cmbADJUSTMENT_TYPE_ID.Location = New System.Drawing.Point(194, 46)
        Me.cmbADJUSTMENT_TYPE_ID.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbADJUSTMENT_TYPE_ID.Name = "cmbADJUSTMENT_TYPE_ID"
        Me.cmbADJUSTMENT_TYPE_ID.Size = New System.Drawing.Size(330, 29)
        Me.cmbADJUSTMENT_TYPE_ID.TabIndex = 2
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(194, 78)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(330, 29)
        Me.cmbLOCATION_ID.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(147, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Adjustment Type :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 78)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 21)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Location From"
        '
        'btnGoto
        '
        Me.btnGoto.Location = New System.Drawing.Point(194, 132)
        Me.btnGoto.Margin = New System.Windows.Forms.Padding(5)
        Me.btnGoto.Name = "btnGoto"
        Me.btnGoto.Size = New System.Drawing.Size(334, 37)
        Me.btnGoto.TabIndex = 6
        Me.btnGoto.Text = "Goto Inventory Adjustment"
        Me.btnGoto.UseVisualStyleBackColor = True
        '
        'FrmGotoInventoryAdjustment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 21.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(538, 203)
        Me.Controls.Add(Me.btnGoto)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.cmbADJUSTMENT_TYPE_ID)
        Me.Controls.Add(Me.dtpDATE)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmGotoInventoryAdjustment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Goto Inventory Adjustment"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents cmbADJUSTMENT_TYPE_ID As ComboBox
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnGoto As Button
End Class
