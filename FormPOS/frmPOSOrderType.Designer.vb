<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPOSOrderType
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
        Me.btnDINE_IN = New System.Windows.Forms.Button()
        Me.btnTAKEOUT = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnDINE_IN
        '
        Me.btnDINE_IN.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDINE_IN.Location = New System.Drawing.Point(10, 12)
        Me.btnDINE_IN.Name = "btnDINE_IN"
        Me.btnDINE_IN.Size = New System.Drawing.Size(193, 73)
        Me.btnDINE_IN.TabIndex = 0
        Me.btnDINE_IN.Text = "DINE IN"
        Me.btnDINE_IN.UseVisualStyleBackColor = True
        '
        'btnTAKEOUT
        '
        Me.btnTAKEOUT.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTAKEOUT.Location = New System.Drawing.Point(10, 95)
        Me.btnTAKEOUT.Name = "btnTAKEOUT"
        Me.btnTAKEOUT.Size = New System.Drawing.Size(193, 73)
        Me.btnTAKEOUT.TabIndex = 1
        Me.btnTAKEOUT.Text = "TAKE OUT"
        Me.btnTAKEOUT.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCANCEL.Location = New System.Drawing.Point(11, 180)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(193, 73)
        Me.btnCANCEL.TabIndex = 2
        Me.btnCANCEL.Text = "CANCEL"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'frmPOSOrderType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(215, 264)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnTAKEOUT)
        Me.Controls.Add(Me.btnDINE_IN)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSOrderType"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Order Type"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnDINE_IN As Button
    Friend WithEvents btnTAKEOUT As Button
    Friend WithEvents btnCANCEL As Button
End Class
