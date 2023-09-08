<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEditAdjustmentItem
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numQTY = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.numCOST = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numQTY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCOST, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Quantity"
        '
        'numQTY
        '
        Me.numQTY.Location = New System.Drawing.Point(107, 15)
        Me.numQTY.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numQTY.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.numQTY.Minimum = New Decimal(New Integer() {276447231, 23283, 0, -2147483648})
        Me.numQTY.Name = "numQTY"
        Me.numQTY.Size = New System.Drawing.Size(183, 23)
        Me.numQTY.TabIndex = 1
        Me.numQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(109, 97)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(85, 26)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'numCOST
        '
        Me.numCOST.DecimalPlaces = 2
        Me.numCOST.Location = New System.Drawing.Point(107, 42)
        Me.numCOST.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCOST.Maximum = New Decimal(New Integer() {1316134911, 2328, 0, 0})
        Me.numCOST.Name = "numCOST"
        Me.numCOST.Size = New System.Drawing.Size(183, 23)
        Me.numCOST.TabIndex = 3
        Me.numCOST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cost"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(206, 97)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(85, 26)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmEditAdjustmentItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(304, 138)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numCOST)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numQTY)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmEditAdjustmentItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Adjustment Item"
        CType(Me.numQTY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCOST, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents numQTY As NumericUpDown
    Friend WithEvents btnSave As Button
    Friend WithEvents numCOST As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents btnCancel As Button
End Class
