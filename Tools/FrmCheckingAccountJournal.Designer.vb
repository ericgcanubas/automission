<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCheckingAccountJournal
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
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.cmbOBJECT = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.dtpDATE1 = New System.Windows.Forms.DateTimePicker()
        Me.dtpDATE2 = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.btnShowMe = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbACCOUNT_ID = New System.Windows.Forms.ComboBox()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(86, 25)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(166, 21)
        Me.cmbLOCATION_ID.TabIndex = 0
        '
        'cmbOBJECT
        '
        Me.cmbOBJECT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOBJECT.FormattingEnabled = True
        Me.cmbOBJECT.Location = New System.Drawing.Point(86, 52)
        Me.cmbOBJECT.Name = "cmbOBJECT"
        Me.cmbOBJECT.Size = New System.Drawing.Size(166, 21)
        Me.cmbOBJECT.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Location"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Object Type"
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvList.Location = New System.Drawing.Point(15, 124)
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.Size = New System.Drawing.Size(719, 274)
        Me.dgvList.TabIndex = 4
        '
        'dtpDATE1
        '
        Me.dtpDATE1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE1.Location = New System.Drawing.Point(617, 26)
        Me.dtpDATE1.Name = "dtpDATE1"
        Me.dtpDATE1.Size = New System.Drawing.Size(117, 22)
        Me.dtpDATE1.TabIndex = 5
        '
        'dtpDATE2
        '
        Me.dtpDATE2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDATE2.Location = New System.Drawing.Point(617, 55)
        Me.dtpDATE2.Name = "dtpDATE2"
        Me.dtpDATE2.Size = New System.Drawing.Size(117, 22)
        Me.dtpDATE2.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(542, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Date Start"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(542, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Date End"
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(15, 95)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.btnRefresh.TabIndex = 9
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'btnShowMe
        '
        Me.btnShowMe.Location = New System.Drawing.Point(12, 404)
        Me.btnShowMe.Name = "btnShowMe"
        Me.btnShowMe.Size = New System.Drawing.Size(75, 23)
        Me.btnShowMe.TabIndex = 10
        Me.btnShowMe.Text = "Show Me"
        Me.btnShowMe.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(271, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 13)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Account "
        '
        'cmbACCOUNT_ID
        '
        Me.cmbACCOUNT_ID.FormattingEnabled = True
        Me.cmbACCOUNT_ID.Location = New System.Drawing.Point(345, 25)
        Me.cmbACCOUNT_ID.Name = "cmbACCOUNT_ID"
        Me.cmbACCOUNT_ID.Size = New System.Drawing.Size(166, 21)
        Me.cmbACCOUNT_ID.TabIndex = 11
        '
        'FrmCheckingAccountJournal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 430)
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
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCheckingAccountJournal"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Checking Account Journal"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents cmbOBJECT As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents dgvList As DataGridView
    Friend WithEvents dtpDATE1 As DateTimePicker
    Friend WithEvents dtpDATE2 As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents btnShowMe As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbACCOUNT_ID As ComboBox
End Class
