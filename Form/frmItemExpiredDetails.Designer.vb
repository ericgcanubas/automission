<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemExpiredDetails
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
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbITEM_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.xxcmbDESCRIPTION = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBATCH_NO = New System.Windows.Forms.TextBox()
        Me.dtpEXPIRY_DATE = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnFind = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(560, 113)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(99, 30)
        Me.btnCancel.TabIndex = 70
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(453, 113)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(99, 30)
        Me.btnSave.TabIndex = 69
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(55, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 16)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Item Code"
        '
        'cmbITEM_ID
        '
        Me.cmbITEM_ID.FormattingEnabled = True
        Me.cmbITEM_ID.Location = New System.Drawing.Point(133, 13)
        Me.cmbITEM_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbITEM_ID.Name = "cmbITEM_ID"
        Me.cmbITEM_ID.Size = New System.Drawing.Size(243, 24)
        Me.cmbITEM_ID.TabIndex = 73
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 16)
        Me.Label2.TabIndex = 74
        Me.Label2.Text = "Item Description"
        '
        'xxcmbDESCRIPTION
        '
        Me.xxcmbDESCRIPTION.FormattingEnabled = True
        Me.xxcmbDESCRIPTION.Location = New System.Drawing.Point(133, 40)
        Me.xxcmbDESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.xxcmbDESCRIPTION.Name = "xxcmbDESCRIPTION"
        Me.xxcmbDESCRIPTION.Size = New System.Drawing.Size(526, 24)
        Me.xxcmbDESCRIPTION.TabIndex = 75
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(55, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Batch No."
        '
        'txtBATCH_NO
        '
        Me.txtBATCH_NO.Location = New System.Drawing.Point(133, 67)
        Me.txtBATCH_NO.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtBATCH_NO.Name = "txtBATCH_NO"
        Me.txtBATCH_NO.Size = New System.Drawing.Size(199, 23)
        Me.txtBATCH_NO.TabIndex = 77
        '
        'dtpEXPIRY_DATE
        '
        Me.dtpEXPIRY_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpEXPIRY_DATE.Location = New System.Drawing.Point(514, 67)
        Me.dtpEXPIRY_DATE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpEXPIRY_DATE.Name = "dtpEXPIRY_DATE"
        Me.dtpEXPIRY_DATE.Size = New System.Drawing.Size(145, 23)
        Me.dtpEXPIRY_DATE.TabIndex = 78
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(423, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 16)
        Me.Label4.TabIndex = 79
        Me.Label4.Text = "Expiry Date"
        '
        'btnFind
        '
        Me.btnFind.BackColor = System.Drawing.Color.Black
        Me.btnFind.BackgroundImage = Global.Automission.My.Resources.Resources.m_search
        Me.btnFind.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnFind.Location = New System.Drawing.Point(377, 13)
        Me.btnFind.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFind.Name = "btnFind"
        Me.btnFind.Size = New System.Drawing.Size(30, 24)
        Me.btnFind.TabIndex = 80
        Me.btnFind.UseVisualStyleBackColor = False
        '
        'frmItemExpiredDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 150)
        Me.Controls.Add(Me.btnFind)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpEXPIRY_DATE)
        Me.Controls.Add(Me.txtBATCH_NO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.xxcmbDESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbITEM_ID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemExpiredDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Item Expired"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbITEM_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents xxcmbDESCRIPTION As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtBATCH_NO As TextBox
    Friend WithEvents dtpEXPIRY_DATE As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents btnFind As Button
End Class
