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
        Me.PBItemList.Location = New System.Drawing.Point(20, 142)
        Me.PBItemList.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PBItemList.Name = "PBItemList"
        Me.PBItemList.Size = New System.Drawing.Size(541, 28)
        Me.PBItemList.TabIndex = 0
        '
        'PBInventory
        '
        Me.PBInventory.Location = New System.Drawing.Point(20, 195)
        Me.PBInventory.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.PBInventory.Name = "PBInventory"
        Me.PBInventory.Size = New System.Drawing.Size(541, 28)
        Me.PBInventory.TabIndex = 1
        '
        'lblItemList
        '
        Me.lblItemList.AutoSize = True
        Me.lblItemList.Location = New System.Drawing.Point(20, 123)
        Me.lblItemList.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblItemList.Name = "lblItemList"
        Me.lblItemList.Size = New System.Drawing.Size(65, 16)
        Me.lblItemList.TabIndex = 2
        Me.lblItemList.Text = "Item List"
        '
        'lblInventory
        '
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Location = New System.Drawing.Point(16, 174)
        Me.lblInventory.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(71, 16)
        Me.lblInventory.TabIndex = 3
        Me.lblInventory.Text = "Inventory"
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(15, 249)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(191, 28)
        Me.btnStart.TabIndex = 6
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(375, 249)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(184, 28)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Close"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cmbLOCATION_ID
        '
        Me.cmbLOCATION_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLOCATION_ID.FormattingEnabled = True
        Me.cmbLOCATION_ID.Location = New System.Drawing.Point(20, 36)
        Me.cmbLOCATION_ID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbLOCATION_ID.Name = "cmbLOCATION_ID"
        Me.cmbLOCATION_ID.Size = New System.Drawing.Size(344, 24)
        Me.cmbLOCATION_ID.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(110, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Select Location"
        '
        'chkBaseOnItemCost
        '
        Me.chkBaseOnItemCost.AutoSize = True
        Me.chkBaseOnItemCost.Location = New System.Drawing.Point(376, 67)
        Me.chkBaseOnItemCost.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkBaseOnItemCost.Name = "chkBaseOnItemCost"
        Me.chkBaseOnItemCost.Size = New System.Drawing.Size(150, 20)
        Me.chkBaseOnItemCost.TabIndex = 10
        Me.chkBaseOnItemCost.Text = "Base On Item Cost"
        Me.chkBaseOnItemCost.UseVisualStyleBackColor = True
        '
        'cmbITEM
        '
        Me.cmbITEM.Enabled = False
        Me.cmbITEM.FormattingEnabled = True
        Me.cmbITEM.Location = New System.Drawing.Point(19, 93)
        Me.cmbITEM.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbITEM.Name = "cmbITEM"
        Me.cmbITEM.Size = New System.Drawing.Size(542, 24)
        Me.cmbITEM.TabIndex = 11
        '
        'chkUseSelectItem
        '
        Me.chkUseSelectItem.AutoSize = True
        Me.chkUseSelectItem.Location = New System.Drawing.Point(24, 67)
        Me.chkUseSelectItem.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkUseSelectItem.Name = "chkUseSelectItem"
        Me.chkUseSelectItem.Size = New System.Drawing.Size(148, 20)
        Me.chkUseSelectItem.TabIndex = 12
        Me.chkUseSelectItem.Text = "Use Selected Item"
        Me.chkUseSelectItem.UseVisualStyleBackColor = True
        '
        'dtpDateStart
        '
        Me.dtpDateStart.Checked = False
        Me.dtpDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateStart.Location = New System.Drawing.Point(373, 34)
        Me.dtpDateStart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpDateStart.Name = "dtpDateStart"
        Me.dtpDateStart.ShowCheckBox = True
        Me.dtpDateStart.Size = New System.Drawing.Size(184, 23)
        Me.dtpDateStart.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(372, 16)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(129, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Use Start On Date"
        '
        'FrmItemInventoryCostUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 292)
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
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
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
