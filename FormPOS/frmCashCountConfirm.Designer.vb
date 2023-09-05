<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCashCountConfirm
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
        Me.lblTOTAL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTOTALSALES = New System.Windows.Forms.Label()
        Me.lblSALES = New System.Windows.Forms.Label()
        Me.lblDISAMount = New System.Windows.Forms.Label()
        Me.lblDIS = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lblComment = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTOTAL
        '
        Me.lblTOTAL.BackColor = System.Drawing.Color.Black
        Me.lblTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTOTAL.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL.ForeColor = System.Drawing.Color.Lime
        Me.lblTOTAL.Location = New System.Drawing.Point(14, 87)
        Me.lblTOTAL.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTOTAL.Name = "lblTOTAL"
        Me.lblTOTAL.Size = New System.Drawing.Size(237, 44)
        Me.lblTOTAL.TabIndex = 14
        Me.lblTOTAL.Text = "0.00"
        Me.lblTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 68)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(97, 19)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "CASH COUNT"
        '
        'lblTOTALSALES
        '
        Me.lblTOTALSALES.BackColor = System.Drawing.Color.Black
        Me.lblTOTALSALES.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTOTALSALES.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTALSALES.ForeColor = System.Drawing.Color.Yellow
        Me.lblTOTALSALES.Location = New System.Drawing.Point(14, 23)
        Me.lblTOTALSALES.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTOTALSALES.Name = "lblTOTALSALES"
        Me.lblTOTALSALES.Size = New System.Drawing.Size(237, 42)
        Me.lblTOTALSALES.TabIndex = 16
        Me.lblTOTALSALES.Text = "0.00"
        Me.lblTOTALSALES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblSALES
        '
        Me.lblSALES.AutoSize = True
        Me.lblSALES.BackColor = System.Drawing.Color.Transparent
        Me.lblSALES.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSALES.Location = New System.Drawing.Point(10, 4)
        Me.lblSALES.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblSALES.Name = "lblSALES"
        Me.lblSALES.Size = New System.Drawing.Size(97, 19)
        Me.lblSALES.TabIndex = 17
        Me.lblSALES.Text = "TOTAL SALES"
        '
        'lblDISAMount
        '
        Me.lblDISAMount.BackColor = System.Drawing.Color.Black
        Me.lblDISAMount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDISAMount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDISAMount.ForeColor = System.Drawing.Color.Lime
        Me.lblDISAMount.Location = New System.Drawing.Point(14, 155)
        Me.lblDISAMount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDISAMount.Name = "lblDISAMount"
        Me.lblDISAMount.Size = New System.Drawing.Size(237, 44)
        Me.lblDISAMount.TabIndex = 18
        Me.lblDISAMount.Text = "0.00"
        Me.lblDISAMount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDIS
        '
        Me.lblDIS.AutoSize = True
        Me.lblDIS.BackColor = System.Drawing.Color.Transparent
        Me.lblDIS.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDIS.Location = New System.Drawing.Point(10, 135)
        Me.lblDIS.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblDIS.Name = "lblDIS"
        Me.lblDIS.Size = New System.Drawing.Size(97, 19)
        Me.lblDIS.TabIndex = 19
        Me.lblDIS.Text = "DISCRIPANCY"
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(74, 250)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(123, 41)
        Me.btnOK.TabIndex = 20
        Me.btnOK.Text = "&OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'lblComment
        '
        Me.lblComment.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblComment.ForeColor = System.Drawing.Color.Red
        Me.lblComment.Location = New System.Drawing.Point(12, 212)
        Me.lblComment.Name = "lblComment"
        Me.lblComment.Size = New System.Drawing.Size(239, 27)
        Me.lblComment.TabIndex = 21
        Me.lblComment.Text = "XXXXX"
        Me.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmCashCountConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(263, 295)
        Me.Controls.Add(Me.lblComment)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lblDISAMount)
        Me.Controls.Add(Me.lblDIS)
        Me.Controls.Add(Me.lblTOTALSALES)
        Me.Controls.Add(Me.lblSALES)
        Me.Controls.Add(Me.lblTOTAL)
        Me.Controls.Add(Me.Label7)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCashCountConfirm"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Count Confirm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTOTAL As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents lblTOTALSALES As Label
    Friend WithEvents lblSALES As Label
    Friend WithEvents lblDISAMount As Label
    Friend WithEvents lblDIS As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents lblComment As Label
End Class
