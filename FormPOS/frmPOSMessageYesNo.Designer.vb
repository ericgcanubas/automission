<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSMessageYesNo
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
        Me.btnYES = New System.Windows.Forms.Button()
        Me.btnNO = New System.Windows.Forms.Button()
        Me.lblmsg = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnYES
        '
        Me.btnYES.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnYES.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnYES.ForeColor = System.Drawing.Color.White
        Me.btnYES.Location = New System.Drawing.Point(12, 173)
        Me.btnYES.Name = "btnYES"
        Me.btnYES.Size = New System.Drawing.Size(163, 64)
        Me.btnYES.TabIndex = 0
        Me.btnYES.Text = "YES"
        Me.btnYES.UseVisualStyleBackColor = False
        '
        'btnNO
        '
        Me.btnNO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnNO.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNO.ForeColor = System.Drawing.Color.White
        Me.btnNO.Location = New System.Drawing.Point(282, 173)
        Me.btnNO.Name = "btnNO"
        Me.btnNO.Size = New System.Drawing.Size(163, 64)
        Me.btnNO.TabIndex = 1
        Me.btnNO.Text = "NO"
        Me.btnNO.UseVisualStyleBackColor = False
        '
        'lblmsg
        '
        Me.lblmsg.BackColor = System.Drawing.Color.Transparent
        Me.lblmsg.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblmsg.Location = New System.Drawing.Point(5, 9)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Size = New System.Drawing.Size(440, 135)
        Me.lblmsg.TabIndex = 2
        Me.lblmsg.Text = "Thank you."
        Me.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmPOSMessageYesNo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(457, 249)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblmsg)
        Me.Controls.Add(Me.btnNO)
        Me.Controls.Add(Me.btnYES)
        Me.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSMessageYesNo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Message"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnYES As Button
    Friend WithEvents btnNO As Button
    Friend WithEvents lblmsg As Label
End Class
