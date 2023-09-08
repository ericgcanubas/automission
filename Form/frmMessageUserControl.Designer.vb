<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMessageUserControl
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
        Me.components = New System.ComponentModel.Container()
        Me.lblmsg = New System.Windows.Forms.Label()
        Me.btnYes = New System.Windows.Forms.Button()
        Me.btnNo = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblmsg
        '
        Me.lblmsg.BackColor = System.Drawing.Color.White
        Me.lblmsg.Location = New System.Drawing.Point(-3, 1)
        Me.lblmsg.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblmsg.Name = "lblmsg"
        Me.lblmsg.Size = New System.Drawing.Size(648, 115)
        Me.lblmsg.TabIndex = 0
        Me.lblmsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnYes
        '
        Me.btnYes.Location = New System.Drawing.Point(420, 125)
        Me.btnYes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnYes.Name = "btnYes"
        Me.btnYes.Size = New System.Drawing.Size(100, 28)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.Location = New System.Drawing.Point(533, 125)
        Me.btnNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnNo.Name = "btnNo"
        Me.btnNo.Size = New System.Drawing.Size(100, 28)
        Me.btnNo.TabIndex = 2
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'frmMessageUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 165)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.Controls.Add(Me.lblmsg)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMessageUserControl"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Message User Control"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblmsg As Label
    Friend WithEvents btnYes As Button
    Friend WithEvents btnNo As Button
    Friend WithEvents Timer1 As Timer
End Class
