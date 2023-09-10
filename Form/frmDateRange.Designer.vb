<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDateRange
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
        Me.dtpDT1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpDT2 = New System.Windows.Forms.DateTimePicker()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dtpDT1
        '
        Me.dtpDT1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDT1.Location = New System.Drawing.Point(92, 13)
        Me.dtpDT1.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDT1.Name = "dtpDT1"
        Me.dtpDT1.Size = New System.Drawing.Size(138, 23)
        Me.dtpDT1.TabIndex = 0
        '
        'dtpDT2
        '
        Me.dtpDT2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDT2.Location = New System.Drawing.Point(92, 44)
        Me.dtpDT2.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpDT2.Name = "dtpDT2"
        Me.dtpDT2.Size = New System.Drawing.Size(138, 23)
        Me.dtpDT2.TabIndex = 1
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(130, 85)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(100, 30)
        Me.btnPreview.TabIndex = 2
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 44)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "From"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(22, 85)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 30)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmDateRange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(240, 123)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.dtpDT2)
        Me.Controls.Add(Me.dtpDT1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDateRange"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Date Range"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dtpDT1 As DateTimePicker
    Friend WithEvents dtpDT2 As DateTimePicker
    Friend WithEvents btnPreview As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPrint As Button
End Class
