<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckingAccountReference
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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.btnShowMe = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpDATE2 = New System.Windows.Forms.DateTimePicker()
        Me.dtpDATE1 = New System.Windows.Forms.DateTimePicker()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbOBJECT = New System.Windows.Forms.ComboBox()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(357, 33)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 16)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Account "
        '
        'cmbACCOUNT_ID
        '
        Me.cmbACCOUNT_ID.FormattingEnabled = True
        Me.cmbACCOUNT_ID.Location = New System.Drawing.Point(456, 30)
        Me.cmbACCOUNT_ID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbACCOUNT_ID.Name = "cmbACCOUNT_ID"
        Me.cmbACCOUNT_ID.Size = New System.Drawing.Size(220, 24)
        Me.cmbACCOUNT_ID.TabIndex = 24
        '
        'btnShowMe
        '
        Me.btnShowMe.Location = New System.Drawing.Point(16, 496)
        Me.btnShowMe.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnShowMe.Name = "btnShowMe"
        Me.btnShowMe.Size = New System.Drawing.Size(100, 28)
        Me.btnShowMe.TabIndex = 23
        Me.btnShowMe.Text = "Show Me"
        Me.btnShowMe.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(16, 116)
        Me.btnRefresh.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(100, 28)
        Me.btnRefresh.TabIndex = 22
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(719, 65)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Date End"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(719, 36)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Date Start"
        '
        'dtpDATE2
        '
        Me.dtpDATE2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE2.Location = New System.Drawing.Point(819, 66)
        Me.dtpDATE2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpDATE2.Name = "dtpDATE2"
        Me.dtpDATE2.Size = New System.Drawing.Size(155, 23)
        Me.dtpDATE2.TabIndex = 19
        '
        'dtpDATE1
        '
        Me.dtpDATE1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE1.Location = New System.Drawing.Point(819, 31)
        Me.dtpDATE1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpDATE1.Name = "dtpDATE1"
        Me.dtpDATE1.Size = New System.Drawing.Size(155, 23)
        Me.dtpDATE1.TabIndex = 18
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(16, 151)
        Me.dgvList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.Size = New System.Drawing.Size(959, 337)
        Me.dgvList.TabIndex = 17
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Object Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Location"
        '
        'cmbOBJECT
        '
        Me.cmbOBJECT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOBJECT.FormattingEnabled = True
        Me.cmbOBJECT.Location = New System.Drawing.Point(111, 63)
        Me.cmbOBJECT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbOBJECT.Name = "cmbOBJECT"
        Me.cmbOBJECT.Size = New System.Drawing.Size(220, 24)
        Me.cmbOBJECT.TabIndex = 14
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(111, 30)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(220, 24)
        Me.cmbLOCATION_ID.TabIndex = 13
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(819, 496)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(156, 28)
        Me.Button1.TabIndex = 26
        Me.Button1.Text = "Fixed Journal"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmCheckingAccountReference
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(991, 535)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmbACCOUNT_ID)
        Me.Controls.Add(Me.btnShowMe)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtpDATE2)
        Me.Controls.Add(Me.dtpDATE1)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbOBJECT)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmCheckingAccountReference"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Checking Account Reference"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents cmbACCOUNT_ID As ComboBox
    Friend WithEvents btnShowMe As Button
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dtpDATE2 As DateTimePicker
    Friend WithEvents dtpDATE1 As DateTimePicker
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbOBJECT As ComboBox
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Button1 As Button
End Class
