<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConnectionSetup
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
        Me.txtConnectionName = New System.Windows.Forms.TextBox()
        Me.txtServer = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDatabase = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkPOS_MODE = New System.Windows.Forms.CheckBox()
        Me.cmbPOS_TYPE = New System.Windows.Forms.ComboBox()
        Me.btnSaveIT = New System.Windows.Forms.Button()
        Me.btnCanceled = New System.Windows.Forms.Button()
        Me.btnTesting = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(17, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Connection Name"
        '
        'txtConnectionName
        '
        Me.txtConnectionName.Location = New System.Drawing.Point(144, 15)
        Me.txtConnectionName.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtConnectionName.Name = "txtConnectionName"
        Me.txtConnectionName.Size = New System.Drawing.Size(193, 23)
        Me.txtConnectionName.TabIndex = 1
        '
        'txtServer
        '
        Me.txtServer.Location = New System.Drawing.Point(144, 42)
        Me.txtServer.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Size = New System.Drawing.Size(193, 23)
        Me.txtServer.TabIndex = 3
        Me.txtServer.Text = "localhost"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(89, 45)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Server"
        '
        'txtDatabase
        '
        Me.txtDatabase.Location = New System.Drawing.Point(144, 69)
        Me.txtDatabase.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Size = New System.Drawing.Size(193, 23)
        Me.txtDatabase.TabIndex = 5
        Me.txtDatabase.Text = "test"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(70, 73)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(69, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Database"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(144, 96)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(193, 23)
        Me.txtUsername.TabIndex = 7
        Me.txtUsername.Text = "root"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(68, 99)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Username"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(144, 123)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(193, 23)
        Me.txtPassword.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(70, 127)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Password"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(144, 151)
        Me.txtPort.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(193, 23)
        Me.txtPort.TabIndex = 11
        Me.txtPort.Text = "3306"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(105, 155)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 16)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Port"
        '
        'chkPOS_MODE
        '
        Me.chkPOS_MODE.BackColor = System.Drawing.Color.Transparent
        Me.chkPOS_MODE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPOS_MODE.Location = New System.Drawing.Point(40, 182)
        Me.chkPOS_MODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPOS_MODE.Name = "chkPOS_MODE"
        Me.chkPOS_MODE.Size = New System.Drawing.Size(99, 21)
        Me.chkPOS_MODE.TabIndex = 17
        Me.chkPOS_MODE.Text = "POS Mode"
        Me.chkPOS_MODE.UseVisualStyleBackColor = False
        '
        'cmbPOS_TYPE
        '
        Me.cmbPOS_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPOS_TYPE.FormattingEnabled = True
        Me.cmbPOS_TYPE.Items.AddRange(New Object() {"Cash Entry", "Order Entry", "Restaurant", "Kitchen Monitoring", "Room Master"})
        Me.cmbPOS_TYPE.Location = New System.Drawing.Point(144, 180)
        Me.cmbPOS_TYPE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cmbPOS_TYPE.Name = "cmbPOS_TYPE"
        Me.cmbPOS_TYPE.Size = New System.Drawing.Size(193, 24)
        Me.cmbPOS_TYPE.TabIndex = 19
        '
        'btnSaveIT
        '
        Me.btnSaveIT.Location = New System.Drawing.Point(144, 242)
        Me.btnSaveIT.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSaveIT.Name = "btnSaveIT"
        Me.btnSaveIT.Size = New System.Drawing.Size(86, 28)
        Me.btnSaveIT.TabIndex = 20
        Me.btnSaveIT.Text = "Save"
        Me.btnSaveIT.UseVisualStyleBackColor = True
        '
        'btnCanceled
        '
        Me.btnCanceled.Location = New System.Drawing.Point(251, 242)
        Me.btnCanceled.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCanceled.Name = "btnCanceled"
        Me.btnCanceled.Size = New System.Drawing.Size(86, 28)
        Me.btnCanceled.TabIndex = 21
        Me.btnCanceled.Text = "Cancel"
        Me.btnCanceled.UseVisualStyleBackColor = True
        '
        'btnTesting
        '
        Me.btnTesting.Location = New System.Drawing.Point(9, 242)
        Me.btnTesting.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnTesting.Name = "btnTesting"
        Me.btnTesting.Size = New System.Drawing.Size(86, 28)
        Me.btnTesting.TabIndex = 22
        Me.btnTesting.Text = "Test"
        Me.btnTesting.UseVisualStyleBackColor = True
        '
        'frmConnectionSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(350, 284)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnTesting)
        Me.Controls.Add(Me.btnCanceled)
        Me.Controls.Add(Me.btnSaveIT)
        Me.Controls.Add(Me.cmbPOS_TYPE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConnectionName)
        Me.Controls.Add(Me.chkPOS_MODE)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtServer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtUsername)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtDatabase)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConnectionSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtConnectionName As TextBox
    Friend WithEvents txtServer As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtDatabase As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkPOS_MODE As CheckBox
    Friend WithEvents cmbPOS_TYPE As ComboBox
    Friend WithEvents btnSaveIT As Button
    Friend WithEvents btnCanceled As Button
    Friend WithEvents btnTesting As Button
End Class
