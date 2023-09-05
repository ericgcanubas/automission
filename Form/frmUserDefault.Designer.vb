<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmUserDefault
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.cmbPRICE_LEVEL_ID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkLockNegativePerUser = New System.Windows.Forms.CheckBox()
        Me.chkPOS_SELECT_DATE = New System.Windows.Forms.CheckBox()
        Me.chkUSER_DISABLED = New System.Windows.Forms.CheckBox()
        Me.chkPRICE_LOCK = New System.Windows.Forms.CheckBox()
        Me.btnRemoveDefault = New System.Windows.Forms.Button()
        Me.btnSaveDefault = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Location"
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(96, 13)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(469, 24)
        Me.cmbLOCATION_ID.TabIndex = 1
        '
        'cmbPRICE_LEVEL_ID
        '
        Me.cmbPRICE_LEVEL_ID.FormattingEnabled = True
        Me.cmbPRICE_LEVEL_ID.Location = New System.Drawing.Point(96, 46)
        Me.cmbPRICE_LEVEL_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPRICE_LEVEL_ID.Name = "cmbPRICE_LEVEL_ID"
        Me.cmbPRICE_LEVEL_ID.Size = New System.Drawing.Size(469, 24)
        Me.cmbPRICE_LEVEL_ID.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(8, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Rate Level"
        '
        'chkLockNegativePerUser
        '
        Me.chkLockNegativePerUser.AutoSize = True
        Me.chkLockNegativePerUser.BackColor = System.Drawing.Color.Transparent
        Me.chkLockNegativePerUser.Location = New System.Drawing.Point(96, 85)
        Me.chkLockNegativePerUser.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkLockNegativePerUser.Name = "chkLockNegativePerUser"
        Me.chkLockNegativePerUser.Size = New System.Drawing.Size(214, 20)
        Me.chkLockNegativePerUser.TabIndex = 6
        Me.chkLockNegativePerUser.Text = "Item Negative Lock per User"
        Me.chkLockNegativePerUser.UseVisualStyleBackColor = False
        '
        'chkPOS_SELECT_DATE
        '
        Me.chkPOS_SELECT_DATE.AutoSize = True
        Me.chkPOS_SELECT_DATE.BackColor = System.Drawing.Color.Transparent
        Me.chkPOS_SELECT_DATE.Location = New System.Drawing.Point(96, 108)
        Me.chkPOS_SELECT_DATE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPOS_SELECT_DATE.Name = "chkPOS_SELECT_DATE"
        Me.chkPOS_SELECT_DATE.Size = New System.Drawing.Size(136, 20)
        Me.chkPOS_SELECT_DATE.TabIndex = 7
        Me.chkPOS_SELECT_DATE.Text = "POS Select Date"
        Me.chkPOS_SELECT_DATE.UseVisualStyleBackColor = False
        '
        'chkUSER_DISABLED
        '
        Me.chkUSER_DISABLED.AutoSize = True
        Me.chkUSER_DISABLED.BackColor = System.Drawing.Color.Transparent
        Me.chkUSER_DISABLED.Location = New System.Drawing.Point(351, 85)
        Me.chkUSER_DISABLED.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkUSER_DISABLED.Name = "chkUSER_DISABLED"
        Me.chkUSER_DISABLED.Size = New System.Drawing.Size(114, 20)
        Me.chkUSER_DISABLED.TabIndex = 8
        Me.chkUSER_DISABLED.Text = "User Disabled"
        Me.chkUSER_DISABLED.UseVisualStyleBackColor = False
        '
        'chkPRICE_LOCK
        '
        Me.chkPRICE_LOCK.AutoSize = True
        Me.chkPRICE_LOCK.BackColor = System.Drawing.Color.Transparent
        Me.chkPRICE_LOCK.Location = New System.Drawing.Point(351, 108)
        Me.chkPRICE_LOCK.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPRICE_LOCK.Name = "chkPRICE_LOCK"
        Me.chkPRICE_LOCK.Size = New System.Drawing.Size(93, 20)
        Me.chkPRICE_LOCK.TabIndex = 9
        Me.chkPRICE_LOCK.Text = "Price Lock"
        Me.chkPRICE_LOCK.UseVisualStyleBackColor = False
        '
        'btnRemoveDefault
        '
        Me.btnRemoveDefault.Location = New System.Drawing.Point(96, 149)
        Me.btnRemoveDefault.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRemoveDefault.Name = "btnRemoveDefault"
        Me.btnRemoveDefault.Size = New System.Drawing.Size(86, 28)
        Me.btnRemoveDefault.TabIndex = 10
        Me.btnRemoveDefault.Text = "Delete"
        Me.btnRemoveDefault.UseVisualStyleBackColor = True
        '
        'btnSaveDefault
        '
        Me.btnSaveDefault.Location = New System.Drawing.Point(479, 149)
        Me.btnSaveDefault.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveDefault.Name = "btnSaveDefault"
        Me.btnSaveDefault.Size = New System.Drawing.Size(86, 28)
        Me.btnSaveDefault.TabIndex = 11
        Me.btnSaveDefault.Text = "Save"
        Me.btnSaveDefault.UseVisualStyleBackColor = True
        '
        'frmUserDefault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 190)
        Me.Controls.Add(Me.btnSaveDefault)
        Me.Controls.Add(Me.btnRemoveDefault)
        Me.Controls.Add(Me.chkPRICE_LOCK)
        Me.Controls.Add(Me.chkUSER_DISABLED)
        Me.Controls.Add(Me.chkPOS_SELECT_DATE)
        Me.Controls.Add(Me.chkLockNegativePerUser)
        Me.Controls.Add(Me.cmbPRICE_LEVEL_ID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUserDefault"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "User Default"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents cmbPRICE_LEVEL_ID As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkLockNegativePerUser As CheckBox
    Friend WithEvents chkPOS_SELECT_DATE As CheckBox
    Friend WithEvents chkUSER_DISABLED As CheckBox
    Friend WithEvents chkPRICE_LOCK As CheckBox
    Friend WithEvents btnRemoveDefault As Button
    Friend WithEvents btnSaveDefault As Button
End Class
