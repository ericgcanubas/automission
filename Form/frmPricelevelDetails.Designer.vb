<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPriceLevelDetails
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblRate = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.numCUSTOM_PRICE = New System.Windows.Forms.NumericUpDown()
        Me.cmbITEM_CODE = New System.Windows.Forms.ComboBox()
        Me.dgvProductItem = New System.Windows.Forms.DataGridView()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numRate = New System.Windows.Forms.NumericUpDown()
        Me.cmbITEM_GROUP_ID = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numCUSTOM_PRICE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(72, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 96
        Me.Label2.Text = "Code"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(121, 15)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(166, 23)
        Me.txtCODE.TabIndex = 97
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(121, 43)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(666, 23)
        Me.txtDESCRIPTION.TabIndex = 99
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(33, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Description"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(75, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Type"
        '
        'cmbTYPE
        '
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(121, 73)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(166, 24)
        Me.cmbTYPE.TabIndex = 101
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.lblRate)
        Me.GroupBox1.Controls.Add(Me.lblDescription)
        Me.GroupBox1.Controls.Add(Me.numCUSTOM_PRICE)
        Me.GroupBox1.Controls.Add(Me.cmbITEM_CODE)
        Me.GroupBox1.Controls.Add(Me.dgvProductItem)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 106)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(786, 375)
        Me.GroupBox1.TabIndex = 102
        Me.GroupBox1.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(662, 15)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 16)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Customer Rate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(554, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Rate"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(162, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Description"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Barcode"
        '
        'lblRate
        '
        Me.lblRate.BackColor = System.Drawing.Color.White
        Me.lblRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRate.Location = New System.Drawing.Point(547, 34)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(110, 26)
        Me.lblRate.TabIndex = 9
        Me.lblRate.Text = "0"
        Me.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblDescription
        '
        Me.lblDescription.BackColor = System.Drawing.Color.White
        Me.lblDescription.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDescription.Location = New System.Drawing.Point(167, 34)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(374, 26)
        Me.lblDescription.TabIndex = 8
        '
        'numCUSTOM_PRICE
        '
        Me.numCUSTOM_PRICE.DecimalPlaces = 2
        Me.numCUSTOM_PRICE.Location = New System.Drawing.Point(665, 34)
        Me.numCUSTOM_PRICE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numCUSTOM_PRICE.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numCUSTOM_PRICE.Name = "numCUSTOM_PRICE"
        Me.numCUSTOM_PRICE.Size = New System.Drawing.Size(111, 23)
        Me.numCUSTOM_PRICE.TabIndex = 7
        Me.numCUSTOM_PRICE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCUSTOM_PRICE.ThousandsSeparator = True
        '
        'cmbITEM_CODE
        '
        Me.cmbITEM_CODE.FormattingEnabled = True
        Me.cmbITEM_CODE.Location = New System.Drawing.Point(8, 34)
        Me.cmbITEM_CODE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbITEM_CODE.Name = "cmbITEM_CODE"
        Me.cmbITEM_CODE.Size = New System.Drawing.Size(149, 24)
        Me.cmbITEM_CODE.TabIndex = 5
        '
        'dgvProductItem
        '
        Me.dgvProductItem.AllowUserToAddRows = False
        Me.dgvProductItem.AllowUserToDeleteRows = False
        Me.dgvProductItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvProductItem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvProductItem.ColumnHeadersHeight = 35
        Me.dgvProductItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvProductItem.Location = New System.Drawing.Point(8, 68)
        Me.dgvProductItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvProductItem.Name = "dgvProductItem"
        Me.dgvProductItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvProductItem.Size = New System.Drawing.Size(768, 299)
        Me.dgvProductItem.TabIndex = 4
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.Location = New System.Drawing.Point(707, 78)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(80, 20)
        Me.chkINACTIVE.TabIndex = 103
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(23, 129)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 16)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "Rate"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(23, 161)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "Item Group"
        '
        'numRate
        '
        Me.numRate.Location = New System.Drawing.Point(121, 127)
        Me.numRate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numRate.Name = "numRate"
        Me.numRate.Size = New System.Drawing.Size(129, 23)
        Me.numRate.TabIndex = 107
        Me.numRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbITEM_GROUP_ID
        '
        Me.cmbITEM_GROUP_ID.FormattingEnabled = True
        Me.cmbITEM_GROUP_ID.Location = New System.Drawing.Point(121, 161)
        Me.cmbITEM_GROUP_ID.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbITEM_GROUP_ID.Name = "cmbITEM_GROUP_ID"
        Me.cmbITEM_GROUP_ID.Size = New System.Drawing.Size(407, 24)
        Me.cmbITEM_GROUP_ID.TabIndex = 108
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(619, 496)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 109
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(712, 496)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 110
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmPriceLevelDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 530)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmbITEM_GROUP_ID)
        Me.Controls.Add(Me.numRate)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPriceLevelDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Price level"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numCUSTOM_PRICE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvProductItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents dgvProductItem As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents numRate As NumericUpDown
    Friend WithEvents cmbITEM_GROUP_ID As ComboBox
    Friend WithEvents lblRate As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents numCUSTOM_PRICE As NumericUpDown
    Friend WithEvents cmbITEM_CODE As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
