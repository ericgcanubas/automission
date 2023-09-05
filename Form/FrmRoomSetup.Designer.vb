<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoomSetup
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
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.dtpROOM_CHECK_IN = New System.Windows.Forms.DateTimePicker()
        Me.dtpROOM_CHECK_OUT = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(17, 49)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(138, 17)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "Use Day/Night Rate"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'dtpROOM_CHECK_IN
        '
        Me.dtpROOM_CHECK_IN.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpROOM_CHECK_IN.Location = New System.Drawing.Point(119, 72)
        Me.dtpROOM_CHECK_IN.Name = "dtpROOM_CHECK_IN"
        Me.dtpROOM_CHECK_IN.ShowUpDown = True
        Me.dtpROOM_CHECK_IN.Size = New System.Drawing.Size(117, 21)
        Me.dtpROOM_CHECK_IN.TabIndex = 131
        '
        'dtpROOM_CHECK_OUT
        '
        Me.dtpROOM_CHECK_OUT.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpROOM_CHECK_OUT.Location = New System.Drawing.Point(119, 99)
        Me.dtpROOM_CHECK_OUT.Name = "dtpROOM_CHECK_OUT"
        Me.dtpROOM_CHECK_OUT.ShowUpDown = True
        Me.dtpROOM_CHECK_OUT.Size = New System.Drawing.Size(117, 21)
        Me.dtpROOM_CHECK_OUT.TabIndex = 132
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 133
        Me.Label1.Text = "Check In Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 134
        Me.Label2.Text = "Check Out Time"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(599, 413)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 135
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'FrmRoomSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(685, 446)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpROOM_CHECK_OUT)
        Me.Controls.Add(Me.dtpROOM_CHECK_IN)
        Me.Controls.Add(Me.CheckBox1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRoomSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Room Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents dtpROOM_CHECK_IN As DateTimePicker
    Friend WithEvents dtpROOM_CHECK_OUT As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As Button
End Class
