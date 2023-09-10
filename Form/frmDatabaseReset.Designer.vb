<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDatabaseReset
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
        Me.btnRESET = New System.Windows.Forms.Button()
        Me.chkTableList = New System.Windows.Forms.CheckedListBox()
        Me.btnCheckAll = New System.Windows.Forms.Button()
        Me.btnUncheckAll = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkItem = New System.Windows.Forms.CheckBox()
        Me.chkVendor = New System.Windows.Forms.CheckBox()
        Me.chkCustomer = New System.Windows.Forms.CheckBox()
        Me.chkEmployee = New System.Windows.Forms.CheckBox()
        Me.chkTaxAgency = New System.Windows.Forms.CheckBox()
        Me.chkOtherContacts = New System.Windows.Forms.CheckBox()
        Me.chkManager = New System.Windows.Forms.CheckBox()
        Me.chkDealer = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkTransactionLog = New System.Windows.Forms.CheckBox()
        Me.chkUsers = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnRESET
        '
        Me.btnRESET.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRESET.ForeColor = System.Drawing.Color.White
        Me.btnRESET.Location = New System.Drawing.Point(414, 318)
        Me.btnRESET.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnRESET.Name = "btnRESET"
        Me.btnRESET.Size = New System.Drawing.Size(137, 31)
        Me.btnRESET.TabIndex = 0
        Me.btnRESET.Text = "Reset"
        Me.btnRESET.UseVisualStyleBackColor = False
        '
        'chkTableList
        '
        Me.chkTableList.FormattingEnabled = True
        Me.chkTableList.Location = New System.Drawing.Point(3, 4)
        Me.chkTableList.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkTableList.Name = "chkTableList"
        Me.chkTableList.Size = New System.Drawing.Size(382, 292)
        Me.chkTableList.TabIndex = 1
        '
        'btnCheckAll
        '
        Me.btnCheckAll.Location = New System.Drawing.Point(3, 316)
        Me.btnCheckAll.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCheckAll.Name = "btnCheckAll"
        Me.btnCheckAll.Size = New System.Drawing.Size(93, 27)
        Me.btnCheckAll.TabIndex = 2
        Me.btnCheckAll.Text = "Check All"
        Me.btnCheckAll.UseVisualStyleBackColor = True
        '
        'btnUncheckAll
        '
        Me.btnUncheckAll.Location = New System.Drawing.Point(99, 316)
        Me.btnUncheckAll.Margin = New System.Windows.Forms.Padding(2)
        Me.btnUncheckAll.Name = "btnUncheckAll"
        Me.btnUncheckAll.Size = New System.Drawing.Size(93, 27)
        Me.btnUncheckAll.TabIndex = 3
        Me.btnUncheckAll.Text = "Uncheck All"
        Me.btnUncheckAll.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 31)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Include"
        '
        'chkItem
        '
        Me.chkItem.AutoSize = True
        Me.chkItem.Checked = True
        Me.chkItem.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkItem.Location = New System.Drawing.Point(414, 49)
        Me.chkItem.Margin = New System.Windows.Forms.Padding(2)
        Me.chkItem.Name = "chkItem"
        Me.chkItem.Size = New System.Drawing.Size(56, 20)
        Me.chkItem.TabIndex = 6
        Me.chkItem.Text = "Item"
        Me.chkItem.UseVisualStyleBackColor = True
        '
        'chkVendor
        '
        Me.chkVendor.AutoSize = True
        Me.chkVendor.Checked = True
        Me.chkVendor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkVendor.Location = New System.Drawing.Point(414, 137)
        Me.chkVendor.Margin = New System.Windows.Forms.Padding(2)
        Me.chkVendor.Name = "chkVendor"
        Me.chkVendor.Size = New System.Drawing.Size(71, 20)
        Me.chkVendor.TabIndex = 7
        Me.chkVendor.Text = "Vendor"
        Me.chkVendor.UseVisualStyleBackColor = True
        '
        'chkCustomer
        '
        Me.chkCustomer.AutoSize = True
        Me.chkCustomer.Checked = True
        Me.chkCustomer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkCustomer.Location = New System.Drawing.Point(414, 155)
        Me.chkCustomer.Margin = New System.Windows.Forms.Padding(2)
        Me.chkCustomer.Name = "chkCustomer"
        Me.chkCustomer.Size = New System.Drawing.Size(88, 20)
        Me.chkCustomer.TabIndex = 8
        Me.chkCustomer.Text = "Customer"
        Me.chkCustomer.UseVisualStyleBackColor = True
        '
        'chkEmployee
        '
        Me.chkEmployee.AutoSize = True
        Me.chkEmployee.Checked = True
        Me.chkEmployee.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEmployee.Location = New System.Drawing.Point(414, 173)
        Me.chkEmployee.Margin = New System.Windows.Forms.Padding(2)
        Me.chkEmployee.Name = "chkEmployee"
        Me.chkEmployee.Size = New System.Drawing.Size(88, 20)
        Me.chkEmployee.TabIndex = 9
        Me.chkEmployee.Text = "Employee"
        Me.chkEmployee.UseVisualStyleBackColor = True
        '
        'chkTaxAgency
        '
        Me.chkTaxAgency.AutoSize = True
        Me.chkTaxAgency.Checked = True
        Me.chkTaxAgency.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTaxAgency.Location = New System.Drawing.Point(414, 190)
        Me.chkTaxAgency.Margin = New System.Windows.Forms.Padding(2)
        Me.chkTaxAgency.Name = "chkTaxAgency"
        Me.chkTaxAgency.Size = New System.Drawing.Size(102, 20)
        Me.chkTaxAgency.TabIndex = 10
        Me.chkTaxAgency.Text = "Tax Agency"
        Me.chkTaxAgency.UseVisualStyleBackColor = True
        '
        'chkOtherContacts
        '
        Me.chkOtherContacts.AutoSize = True
        Me.chkOtherContacts.Checked = True
        Me.chkOtherContacts.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOtherContacts.Location = New System.Drawing.Point(414, 208)
        Me.chkOtherContacts.Margin = New System.Windows.Forms.Padding(2)
        Me.chkOtherContacts.Name = "chkOtherContacts"
        Me.chkOtherContacts.Size = New System.Drawing.Size(128, 20)
        Me.chkOtherContacts.TabIndex = 11
        Me.chkOtherContacts.Text = "Other Contacts"
        Me.chkOtherContacts.UseVisualStyleBackColor = True
        '
        'chkManager
        '
        Me.chkManager.AutoSize = True
        Me.chkManager.Checked = True
        Me.chkManager.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkManager.Location = New System.Drawing.Point(414, 225)
        Me.chkManager.Margin = New System.Windows.Forms.Padding(2)
        Me.chkManager.Name = "chkManager"
        Me.chkManager.Size = New System.Drawing.Size(82, 20)
        Me.chkManager.TabIndex = 12
        Me.chkManager.Text = "Manager"
        Me.chkManager.UseVisualStyleBackColor = True
        '
        'chkDealer
        '
        Me.chkDealer.AutoSize = True
        Me.chkDealer.Checked = True
        Me.chkDealer.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDealer.Location = New System.Drawing.Point(414, 243)
        Me.chkDealer.Margin = New System.Windows.Forms.Padding(2)
        Me.chkDealer.Name = "chkDealer"
        Me.chkDealer.Size = New System.Drawing.Size(67, 20)
        Me.chkDealer.TabIndex = 13
        Me.chkDealer.Text = "Dealer"
        Me.chkDealer.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(395, 123)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Contacts"
        '
        'chkTransactionLog
        '
        Me.chkTransactionLog.AutoSize = True
        Me.chkTransactionLog.Checked = True
        Me.chkTransactionLog.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkTransactionLog.Location = New System.Drawing.Point(414, 66)
        Me.chkTransactionLog.Margin = New System.Windows.Forms.Padding(2)
        Me.chkTransactionLog.Name = "chkTransactionLog"
        Me.chkTransactionLog.Size = New System.Drawing.Size(131, 20)
        Me.chkTransactionLog.TabIndex = 15
        Me.chkTransactionLog.Text = "Transaction Log"
        Me.chkTransactionLog.UseVisualStyleBackColor = True
        '
        'chkUsers
        '
        Me.chkUsers.AutoSize = True
        Me.chkUsers.Location = New System.Drawing.Point(415, 86)
        Me.chkUsers.Margin = New System.Windows.Forms.Padding(2)
        Me.chkUsers.Name = "chkUsers"
        Me.chkUsers.Size = New System.Drawing.Size(62, 20)
        Me.chkUsers.TabIndex = 16
        Me.chkUsers.Text = "Users"
        Me.chkUsers.UseVisualStyleBackColor = True
        '
        'FrmDatabaseReset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(562, 353)
        Me.Controls.Add(Me.chkUsers)
        Me.Controls.Add(Me.chkTransactionLog)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkDealer)
        Me.Controls.Add(Me.chkManager)
        Me.Controls.Add(Me.chkOtherContacts)
        Me.Controls.Add(Me.chkTaxAgency)
        Me.Controls.Add(Me.chkEmployee)
        Me.Controls.Add(Me.chkCustomer)
        Me.Controls.Add(Me.chkVendor)
        Me.Controls.Add(Me.chkItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnUncheckAll)
        Me.Controls.Add(Me.btnCheckAll)
        Me.Controls.Add(Me.chkTableList)
        Me.Controls.Add(Me.btnRESET)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmDatabaseReset"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Reset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRESET As Button
    Friend WithEvents chkTableList As CheckedListBox
    Friend WithEvents btnCheckAll As Button
    Friend WithEvents btnUncheckAll As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents chkItem As CheckBox
    Friend WithEvents chkVendor As CheckBox
    Friend WithEvents chkCustomer As CheckBox
    Friend WithEvents chkEmployee As CheckBox
    Friend WithEvents chkTaxAgency As CheckBox
    Friend WithEvents chkOtherContacts As CheckBox
    Friend WithEvents chkManager As CheckBox
    Friend WithEvents chkDealer As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkTransactionLog As CheckBox
    Friend WithEvents chkUsers As CheckBox
End Class
