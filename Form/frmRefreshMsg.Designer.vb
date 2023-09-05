<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRefreshMsg
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
        Me.btnCreateNew = New System.Windows.Forms.Button()
        Me.btnReload = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCreateNew
        '
        Me.btnCreateNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCreateNew.Location = New System.Drawing.Point(11, 85)
        Me.btnCreateNew.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCreateNew.Name = "btnCreateNew"
        Me.btnCreateNew.Size = New System.Drawing.Size(99, 37)
        Me.btnCreateNew.TabIndex = 0
        Me.btnCreateNew.Text = "&New"
        Me.btnCreateNew.UseVisualStyleBackColor = False
        '
        'btnReload
        '
        Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReload.Location = New System.Drawing.Point(118, 85)
        Me.btnReload.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(99, 37)
        Me.btnReload.TabIndex = 1
        Me.btnReload.Text = "&Reload"
        Me.btnReload.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancel.Location = New System.Drawing.Point(224, 85)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 37)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmRefreshMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(337, 137)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.btnCreateNew)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRefreshMsg"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Refresh"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnCreateNew As Button
    Friend WithEvents btnReload As Button
    Friend WithEvents btnCancel As Button
End Class
