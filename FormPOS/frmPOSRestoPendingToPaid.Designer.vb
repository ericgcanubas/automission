<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPOSRestoPendingToPaid
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
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNOTE = New System.Windows.Forms.TextBox()
        Me.cmbCUSTOMER_ID = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCUSTOMER = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 51)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SERVED # :"
        '
        'lblCODE
        '
        Me.lblCODE.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCODE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCODE.Location = New System.Drawing.Point(154, 47)
        Me.lblCODE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(178, 34)
        Me.lblCODE.TabIndex = 1
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAMOUNT.Location = New System.Drawing.Point(462, 46)
        Me.lblAMOUNT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(167, 34)
        Me.lblAMOUNT.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(349, 50)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 23)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "AMOUNT :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(48, 87)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 23)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "NOTES :"
        '
        'txtNOTE
        '
        Me.txtNOTE.Location = New System.Drawing.Point(154, 84)
        Me.txtNOTE.Multiline = True
        Me.txtNOTE.Name = "txtNOTE"
        Me.txtNOTE.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNOTE.Size = New System.Drawing.Size(475, 170)
        Me.txtNOTE.TabIndex = 5
        '
        'cmbCUSTOMER_ID
        '
        Me.cmbCUSTOMER_ID.FormattingEnabled = True
        Me.cmbCUSTOMER_ID.Location = New System.Drawing.Point(154, 12)
        Me.cmbCUSTOMER_ID.Name = "cmbCUSTOMER_ID"
        Me.cmbCUSTOMER_ID.Size = New System.Drawing.Size(420, 31)
        Me.cmbCUSTOMER_ID.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(5, 15)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(134, 23)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "CUSTOMER :"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(511, 268)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(118, 50)
        Me.btnCANCEL.TabIndex = 8
        Me.btnCANCEL.Text = "CANCEL"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(377, 268)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(118, 50)
        Me.btnOK.TabIndex = 9
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCUSTOMER
        '
        Me.btnCUSTOMER.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCUSTOMER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCUSTOMER.Location = New System.Drawing.Point(576, 12)
        Me.btnCUSTOMER.Name = "btnCUSTOMER"
        Me.btnCUSTOMER.Size = New System.Drawing.Size(53, 31)
        Me.btnCUSTOMER.TabIndex = 10
        Me.btnCUSTOMER.Text = "..."
        Me.btnCUSTOMER.UseVisualStyleBackColor = False
        '
        'frmPOSRestoPendingToPaid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 23.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(641, 332)
        Me.Controls.Add(Me.btnCUSTOMER)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbCUSTOMER_ID)
        Me.Controls.Add(Me.txtNOTE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblCODE)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSRestoPendingToPaid"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pending To Paid"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblCODE As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNOTE As TextBox
    Friend WithEvents cmbCUSTOMER_ID As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCUSTOMER As Button
End Class
