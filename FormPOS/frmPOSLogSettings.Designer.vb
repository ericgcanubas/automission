<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSLogSettings
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
        Me.cmbPRINTER = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.cmbPrinterPage = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkPOSPrintPreview = New System.Windows.Forms.CheckBox()
        Me.xchkPOS_STARTING_CASH = New System.Windows.Forms.CheckBox()
        Me.xchkOR_REQUIRED = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'cmbPRINTER
        '
        Me.cmbPRINTER.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRINTER.FormattingEnabled = True
        Me.cmbPRINTER.Location = New System.Drawing.Point(183, 57)
        Me.cmbPRINTER.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPRINTER.Name = "cmbPRINTER"
        Me.cmbPRINTER.Size = New System.Drawing.Size(284, 22)
        Me.cmbPRINTER.TabIndex = 53
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(26, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 14)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "POS Default Printer"
        '
        'btnSettings
        '
        Me.btnSettings.Location = New System.Drawing.Point(475, 27)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(32, 26)
        Me.btnSettings.TabIndex = 38
        Me.btnSettings.Text = "..."
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'cmbPrinterPage
        '
        Me.cmbPrinterPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPrinterPage.FormattingEnabled = True
        Me.cmbPrinterPage.Location = New System.Drawing.Point(183, 27)
        Me.cmbPrinterPage.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPrinterPage.Name = "cmbPrinterPage"
        Me.cmbPrinterPage.Size = New System.Drawing.Size(284, 22)
        Me.cmbPrinterPage.TabIndex = 37
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(394, 204)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(113, 30)
        Me.btnCancel.TabIndex = 36
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(265, 204)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(113, 30)
        Me.btnSave.TabIndex = 35
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(55, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 14)
        Me.Label2.TabIndex = 32
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(26, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(150, 14)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Default Receipt Format"
        '
        'chkPOSPrintPreview
        '
        Me.chkPOSPrintPreview.AutoSize = True
        Me.chkPOSPrintPreview.BackColor = System.Drawing.Color.Transparent
        Me.chkPOSPrintPreview.Location = New System.Drawing.Point(183, 133)
        Me.chkPOSPrintPreview.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.chkPOSPrintPreview.Name = "chkPOSPrintPreview"
        Me.chkPOSPrintPreview.Size = New System.Drawing.Size(139, 18)
        Me.chkPOSPrintPreview.TabIndex = 64
        Me.chkPOSPrintPreview.Text = "POS Print Preview"
        Me.chkPOSPrintPreview.UseVisualStyleBackColor = False
        '
        'xchkPOS_STARTING_CASH
        '
        Me.xchkPOS_STARTING_CASH.AutoSize = True
        Me.xchkPOS_STARTING_CASH.BackColor = System.Drawing.Color.Transparent
        Me.xchkPOS_STARTING_CASH.Location = New System.Drawing.Point(183, 86)
        Me.xchkPOS_STARTING_CASH.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.xchkPOS_STARTING_CASH.Name = "xchkPOS_STARTING_CASH"
        Me.xchkPOS_STARTING_CASH.Size = New System.Drawing.Size(142, 18)
        Me.xchkPOS_STARTING_CASH.TabIndex = 62
        Me.xchkPOS_STARTING_CASH.Text = "POS Starting Cash"
        Me.xchkPOS_STARTING_CASH.UseVisualStyleBackColor = False
        '
        'xchkOR_REQUIRED
        '
        Me.xchkOR_REQUIRED.AutoSize = True
        Me.xchkOR_REQUIRED.BackColor = System.Drawing.Color.Transparent
        Me.xchkOR_REQUIRED.Location = New System.Drawing.Point(183, 109)
        Me.xchkOR_REQUIRED.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.xchkOR_REQUIRED.Name = "xchkOR_REQUIRED"
        Me.xchkOR_REQUIRED.Size = New System.Drawing.Size(242, 18)
        Me.xchkOR_REQUIRED.TabIndex = 61
        Me.xchkOR_REQUIRED.Text = "POS When Save O.R# is  Required"
        Me.xchkOR_REQUIRED.UseVisualStyleBackColor = False
        '
        'frmPOSLogSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 237)
        Me.Controls.Add(Me.chkPOSPrintPreview)
        Me.Controls.Add(Me.xchkPOS_STARTING_CASH)
        Me.Controls.Add(Me.xchkOR_REQUIRED)
        Me.Controls.Add(Me.cmbPRINTER)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.cmbPrinterPage)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSLogSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbPRINTER As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSettings As Button
    Friend WithEvents cmbPrinterPage As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkPOSPrintPreview As CheckBox
    Friend WithEvents xchkPOS_STARTING_CASH As CheckBox
    Friend WithEvents xchkOR_REQUIRED As CheckBox
End Class
