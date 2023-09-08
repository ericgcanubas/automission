<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSelectLocation
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
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(22, 21)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(257, 21)
        Me.cmbLOCATION_ID.TabIndex = 0
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(204, 68)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 20)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Control
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label2.Location = New System.Drawing.Point(0, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(291, 38)
        Me.Label2.TabIndex = 6
        '
        'frmSelectLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(291, 95)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSelectLocation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Location"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents btnOK As Button
    Friend WithEvents Label2 As Label
End Class
