<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplash
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblSystem_Name = New System.Windows.Forms.Label()
        Me.lblinitialization = New System.Windows.Forms.Label()
        Me.pbLoadingBar = New System.Windows.Forms.ProgressBar()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 150
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1022, 486)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(222, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Copyright @ 2018 All Right Reserved "
        '
        'lblSystem_Name
        '
        Me.lblSystem_Name.AutoSize = True
        Me.lblSystem_Name.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblSystem_Name.Location = New System.Drawing.Point(13, 418)
        Me.lblSystem_Name.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSystem_Name.Name = "lblSystem_Name"
        Me.lblSystem_Name.Size = New System.Drawing.Size(92, 13)
        Me.lblSystem_Name.TabIndex = 3
        Me.lblSystem_Name.Text = "SYSTEM_NAME"
        '
        'lblinitialization
        '
        Me.lblinitialization.BackColor = System.Drawing.Color.Transparent
        Me.lblinitialization.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblinitialization.ForeColor = System.Drawing.Color.White
        Me.lblinitialization.Location = New System.Drawing.Point(114, 459)
        Me.lblinitialization.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblinitialization.Name = "lblinitialization"
        Me.lblinitialization.Size = New System.Drawing.Size(252, 15)
        Me.lblinitialization.TabIndex = 5
        Me.lblinitialization.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblinitialization.Visible = False
        '
        'pbLoadingBar
        '
        Me.pbLoadingBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbLoadingBar.ForeColor = System.Drawing.Color.Lime
        Me.pbLoadingBar.Location = New System.Drawing.Point(0, 477)
        Me.pbLoadingBar.Margin = New System.Windows.Forms.Padding(1)
        Me.pbLoadingBar.MarqueeAnimationSpeed = 1
        Me.pbLoadingBar.Maximum = 10
        Me.pbLoadingBar.Name = "pbLoadingBar"
        Me.pbLoadingBar.Size = New System.Drawing.Size(500, 23)
        Me.pbLoadingBar.Step = 100
        Me.pbLoadingBar.TabIndex = 7
        Me.pbLoadingBar.Visible = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(500, 500)
        Me.Controls.Add(Me.lblinitialization)
        Me.Controls.Add(Me.lblSystem_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbLoadingBar)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Name = "frmSplash"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Business Management System"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents lblSystem_Name As Label
    Friend WithEvents lblinitialization As Label
    Friend WithEvents pbLoadingBar As ProgressBar
    Friend WithEvents Timer2 As Timer
End Class
