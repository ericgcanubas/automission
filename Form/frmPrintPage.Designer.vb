<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrintPage
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
        Me.cmbPrinterPage = New System.Windows.Forms.ComboBox()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.cmbPRINTER = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmbPrinterPage
        '
        Me.cmbPrinterPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterPage.FormattingEnabled = True
        Me.cmbPrinterPage.Location = New System.Drawing.Point(107, 25)
        Me.cmbPrinterPage.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPrinterPage.Name = "cmbPrinterPage"
        Me.cmbPrinterPage.Size = New System.Drawing.Size(323, 24)
        Me.cmbPrinterPage.TabIndex = 0
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(430, 24)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(32, 28)
        Me.btnSettings.TabIndex = 4
        Me.btnSettings.Text = "..."
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'cmbPRINTER
        '
        Me.cmbPRINTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRINTER.FormattingEnabled = True
        Me.cmbPRINTER.Location = New System.Drawing.Point(107, 58)
        Me.cmbPRINTER.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPRINTER.Name = "cmbPRINTER"
        Me.cmbPRINTER.Size = New System.Drawing.Size(354, 24)
        Me.cmbPRINTER.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(14, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Print Format"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Printer Select"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(278, 103)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(86, 28)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(376, 103)
        Me.btnPreview.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(86, 28)
        Me.btnPreview.TabIndex = 9
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'frmPrintPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 141)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbPRINTER)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.cmbPrinterPage)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPrintPage"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Page"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbPrinterPage As ComboBox
    Friend WithEvents btnSettings As Button
    Friend WithEvents cmbPRINTER As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnPreview As Button
End Class
