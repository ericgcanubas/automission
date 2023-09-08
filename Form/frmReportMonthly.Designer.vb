<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportMonthly
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
        Me.cmbMonth = New System.Windows.Forms.ComboBox()
        Me.cmbYear = New System.Windows.Forms.ComboBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbMonth
        '
        Me.cmbMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonth.FormattingEnabled = True
        Me.cmbMonth.Location = New System.Drawing.Point(14, 16)
        Me.cmbMonth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbMonth.Name = "cmbMonth"
        Me.cmbMonth.Size = New System.Drawing.Size(149, 25)
        Me.cmbMonth.TabIndex = 0
        '
        'cmbYear
        '
        Me.cmbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYear.FormattingEnabled = True
        Me.cmbYear.Location = New System.Drawing.Point(169, 16)
        Me.cmbYear.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbYear.Name = "cmbYear"
        Me.cmbYear.Size = New System.Drawing.Size(58, 25)
        Me.cmbYear.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(71, 55)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 28)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(152, 55)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 28)
        Me.btnPreview.TabIndex = 3
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'frmReportMonthly
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(243, 95)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cmbYear)
        Me.Controls.Add(Me.cmbMonth)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportMonthly"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Depot Sales Acheivement Report"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPreview As Button
End Class
