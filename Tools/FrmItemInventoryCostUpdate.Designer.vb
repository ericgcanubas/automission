<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemInventoryCostUpdate
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
        Me.PBItemList = New System.Windows.Forms.ProgressBar()
        Me.PBInventory = New System.Windows.Forms.ProgressBar()
        Me.lblItemList = New System.Windows.Forms.Label()
        Me.lblInventory = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cmbLOCATION_ID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkBaseOnItemCost = New System.Windows.Forms.CheckBox()
        Me.cmbITEM = New System.Windows.Forms.ComboBox()
        Me.chkUseSelectItem = New System.Windows.Forms.CheckBox()
        Me.dtpDateStart = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PBItemList
        '
        Me.PBItemList.Location = New System.Drawing.Point(15, 127)
        Me.PBItemList.Name = "PBItemList"
        Me.PBItemList.Size = New System.Drawing.Size(406, 23)
        Me.PBItemList.TabIndex = 0
        '
        'PBInventory
        '
        Me.PBInventory.Location = New System.Drawing.Point(15, 170)
        Me.PBInventory.Name = "PBInventory"
        Me.PBInventory.Size = New System.Drawing.Size(406, 23)
        Me.PBInventory.TabIndex = 1
        '
        'lblItemList
        '
        Me.lblItemList.AutoSize = True
        Me.lblItemList.Location = New System.Drawing.Point(15, 111)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Size = New System.Drawing.Size(49, 13)
        Me.lblItemList.TabIndex = 2
        Me.lblItemList.Text = "Item List"
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Location = New System.Drawing.Point(12, 153)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(55, 13)
        Me.lblInventory.TabIndex = 3
        Me.lblInventory.Text = "Inventory"
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(12, 219)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(143, 23)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(282, 219)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(138, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(18, 29)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(256, 21)
        Me.cmbLOCATION_ID.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Select Location"
        '
        'chkBaseOnItemCost
        '
        Me.chkBaseOnItemCost.AutoSize = True
        Me.chkBaseOnItemCost.Location = New System.Drawing.Point(282, 66)
        Me.chkBaseOnItemCost.Name = "chkBaseOnItemCost"
        Me.chkBaseOnItemCost.Size = New System.Drawing.Size(119, 17)
        Me.chkBaseOnItemCost.TabIndex = 10
        Me.chkBaseOnItemCost.Text = "Base On Item Cost"
        Me.chkBaseOnItemCost.UseVisualStyleBackColor = True
        '
        'cmbITEM
        '
        Me.cmbITEM.Enabled = False
        Me.cmbITEM.FormattingEnabled = True
        Me.cmbITEM.Location = New System.Drawing.Point(18, 87)
        Me.cmbITEM.Name = "cmbITEM"
        Me.cmbITEM.Size = New System.Drawing.Size(404, 21)
        Me.cmbITEM.TabIndex = 11
        '
        'chkUseSelectItem
        '
        Me.chkUseSelectItem.AutoSize = True
        Me.chkUseSelectItem.Location = New System.Drawing.Point(18, 66)
        Me.chkUseSelectItem.Name = "chkUseSelectItem"
        Me.chkUseSelectItem.Size = New System.Drawing.Size(116, 17)
        Me.chkUseSelectItem.TabIndex = 12
        Me.chkUseSelectItem.Text = "Use Selected Item"
        Me.chkUseSelectItem.UseVisualStyleBackColor = True
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Checked = False
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStart.Location = New System.Drawing.Point(280, 28)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.ShowCheckBox = True
        Me.dtpDateStart.Size = New System.Drawing.Size(139, 22)
        Me.dtpDateStart.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(279, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Use Start On Date"
        '
        'FrmItemInventoryCostUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 254)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpDateStart)
        Me.Controls.Add(Me.chkUseSelectItem)
        Me.Controls.Add(Me.cmbITEM)
        Me.Controls.Add(Me.chkBaseOnItemCost)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbLOCATION_ID)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblInventory)
        Me.Controls.Add(Me.lblItemList)
        Me.Controls.Add(Me.PBInventory)
        Me.Controls.Add(Me.PBItemList)
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItemInventoryCostUpdate"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Cost Updater Transaction"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PBItemList As ProgressBar
    Friend WithEvents PBInventory As ProgressBar
    Friend WithEvents lblItemList As Label
    Friend WithEvents lblInventory As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents cmbLOCATION_ID As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkBaseOnItemCost As CheckBox
    Friend WithEvents cmbITEM As ComboBox
    Friend WithEvents chkUseSelectItem As CheckBox
    Friend WithEvents dtpDateStart As DateTimePicker
    Friend WithEvents Label2 As Label
End Class
