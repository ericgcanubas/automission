<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOS_LOG_STATING_COUNT_FIXED
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
        Me.dtpDATE = New System.Windows.Forms.DateTimePicker()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.btnRUN = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPOS_MACHINE_ID = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbCASHIER_ID = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtSTART = New System.Windows.Forms.TextBox()
        Me.chkRESTO_MODE = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'dtpDATE
        '
        Me.dtpDATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE.Location = New System.Drawing.Point(147, 43)
        Me.dtpDATE.Name = "dtpDATE"
        Me.dtpDATE.Size = New System.Drawing.Size(188, 23)
        Me.dtpDATE.TabIndex = 0
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(147, 75)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(354, 24)
        Me.cmbLOCATION_ID.TabIndex = 1
        '
        'btnRUN
        '
        Me.btnRUN.Location = New System.Drawing.Point(412, 170)
        Me.btnRUN.Name = "btnRUN"
        Me.btnRUN.Size = New System.Drawing.Size(89, 24)
        Me.btnRUN.TabIndex = 2
        Me.btnRUN.Text = "Run"
        Me.btnRUN.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "DATE START :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "LOCATION :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 111)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "POS MACHINE :"
        '
        'cmbPOS_MACHINE_ID
        '
        Me.cmbPOS_MACHINE_ID.FormattingEnabled = True
        Me.cmbPOS_MACHINE_ID.Location = New System.Drawing.Point(147, 107)
        Me.cmbPOS_MACHINE_ID.Name = "cmbPOS_MACHINE_ID"
        Me.cmbPOS_MACHINE_ID.Size = New System.Drawing.Size(354, 24)
        Me.cmbPOS_MACHINE_ID.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "CASHIER :"
        '
        'cmbCASHIER_ID
        '
        Me.cmbCASHIER_ID.FormattingEnabled = True
        Me.cmbCASHIER_ID.Location = New System.Drawing.Point(147, 139)
        Me.cmbCASHIER_ID.Name = "cmbCASHIER_ID"
        Me.cmbCASHIER_ID.Size = New System.Drawing.Size(354, 24)
        Me.cmbCASHIER_ID.TabIndex = 7
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(416, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 25)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "S Cash Journal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtSTART
        '
        Me.txtSTART.Location = New System.Drawing.Point(454, 11)
        Me.txtSTART.Name = "txtSTART"
        Me.txtSTART.Size = New System.Drawing.Size(47, 23)
        Me.txtSTART.TabIndex = 10
        '
        'chkRESTO_MODE
        '
        Me.chkRESTO_MODE.AutoSize = True
        Me.chkRESTO_MODE.Location = New System.Drawing.Point(10, 14)
        Me.chkRESTO_MODE.Name = "chkRESTO_MODE"
        Me.chkRESTO_MODE.Size = New System.Drawing.Size(103, 20)
        Me.chkRESTO_MODE.TabIndex = 11
        Me.chkRESTO_MODE.Text = "Resto Mode"
        Me.chkRESTO_MODE.UseVisualStyleBackColor = True
        '
        'FrmPOS_LOG_STATING_COUNT_FIXED
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(519, 206)
        Me.Controls.Add(Me.chkRESTO_MODE)
        Me.Controls.Add(Me.txtSTART)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbCASHIER_ID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbPOS_MACHINE_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnRUN)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.dtpDATE)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FrmPOS_LOG_STATING_COUNT_FIXED"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS LOG-  STARTING CASH -CASH COUNT  (FIXED)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpDATE As DateTimePicker
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents btnRUN As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbPOS_MACHINE_ID As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbCASHIER_ID As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtSTART As TextBox
    Friend WithEvents chkRESTO_MODE As CheckBox
End Class
