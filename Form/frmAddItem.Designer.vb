<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddItem
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.xlblnum_price = New System.Windows.Forms.Label()
        Me.numUnit_price = New System.Windows.Forms.NumericUpDown()
        Me.xlblLabel_Amount = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.chkTax = New System.Windows.Forms.CheckBox()
        Me.cmbUM = New System.Windows.Forms.ComboBox()
        Me.cmbDiscount_Type = New System.Windows.Forms.ComboBox()
        Me.xlblDISCOUNT = New System.Windows.Forms.Label()
        Me.numDiscountValue = New System.Windows.Forms.NumericUpDown()
        Me.cmbItem_Code = New System.Windows.Forms.ComboBox()
        Me.lblQty_Base = New System.Windows.Forms.Label()
        Me.xlblSelection = New System.Windows.Forms.Label()
        Me.cmbSelection = New System.Windows.Forms.ComboBox()
        Me.cmbItem_DESCRIPTION = New System.Windows.Forms.ComboBox()
        Me.xlblOnHand = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FindItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbPRICE_LEVEL = New System.Windows.Forms.ComboBox()
        Me.xxxlblPrice_level = New System.Windows.Forms.Label()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.xlblSearch = New System.Windows.Forms.Label()
        Me.xlblITEM_ID = New System.Windows.Forms.Label()
        Me.xlblDESCRIPTION = New System.Windows.Forms.Label()
        Me.picItem = New System.Windows.Forms.PictureBox()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.xlblExpired = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDateExpired = New System.Windows.Forms.DateTimePicker()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUnit_price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDiscountValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Barcode"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(6, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numQty
        '
        Me.numQty.InterceptArrowKeys = False
        Me.numQty.Location = New System.Drawing.Point(101, 64)
        Me.numQty.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numQty.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numQty.Minimum = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(165, 23)
        Me.numQty.TabIndex = 3
        Me.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(21, 97)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblnum_price
        '
        Me.xlblnum_price.BackColor = System.Drawing.Color.Transparent
        Me.xlblnum_price.Location = New System.Drawing.Point(21, 148)
        Me.xlblnum_price.Name = "xlblnum_price"
        Me.xlblnum_price.Size = New System.Drawing.Size(79, 22)
        Me.xlblnum_price.TabIndex = 9
        Me.xlblnum_price.Text = "Rate"
        Me.xlblnum_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numUnit_price
        '
        Me.numUnit_price.DecimalPlaces = 2
        Me.numUnit_price.InterceptArrowKeys = False
        Me.numUnit_price.Location = New System.Drawing.Point(101, 147)
        Me.numUnit_price.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numUnit_price.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numUnit_price.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.numUnit_price.Name = "numUnit_price"
        Me.numUnit_price.Size = New System.Drawing.Size(165, 23)
        Me.numUnit_price.TabIndex = 5
        Me.numUnit_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xlblLabel_Amount
        '
        Me.xlblLabel_Amount.BackColor = System.Drawing.Color.Transparent
        Me.xlblLabel_Amount.ForeColor = System.Drawing.Color.Black
        Me.xlblLabel_Amount.Location = New System.Drawing.Point(294, 172)
        Me.xlblLabel_Amount.Name = "xlblLabel_Amount"
        Me.xlblLabel_Amount.Size = New System.Drawing.Size(94, 23)
        Me.xlblLabel_Amount.TabIndex = 11
        Me.xlblLabel_Amount.Text = "Amount"
        Me.xlblLabel_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAmount
        '
        Me.lblAmount.BackColor = System.Drawing.Color.Transparent
        Me.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmount.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Navy
        Me.lblAmount.Location = New System.Drawing.Point(390, 171)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(177, 30)
        Me.lblAmount.TabIndex = 0
        Me.lblAmount.Text = "9,999,999.99"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkTax
        '
        Me.chkTax.BackColor = System.Drawing.Color.Transparent
        Me.chkTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTax.Location = New System.Drawing.Point(101, 212)
        Me.chkTax.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkTax.Name = "chkTax"
        Me.chkTax.Size = New System.Drawing.Size(62, 20)
        Me.chkTax.TabIndex = 6
        Me.chkTax.Text = "Tax"
        Me.chkTax.UseVisualStyleBackColor = False
        '
        'cmbUM
        '
        Me.cmbUM.BackColor = System.Drawing.Color.White
        Me.cmbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUM.FormattingEnabled = True
        Me.cmbUM.Location = New System.Drawing.Point(101, 92)
        Me.cmbUM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbUM.Name = "cmbUM"
        Me.cmbUM.Size = New System.Drawing.Size(164, 24)
        Me.cmbUM.TabIndex = 4
        '
        'cmbDiscount_Type
        '
        Me.cmbDiscount_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiscount_Type.FormattingEnabled = True
        Me.cmbDiscount_Type.Location = New System.Drawing.Point(101, 174)
        Me.cmbDiscount_Type.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbDiscount_Type.Name = "cmbDiscount_Type"
        Me.cmbDiscount_Type.Size = New System.Drawing.Size(73, 24)
        Me.cmbDiscount_Type.TabIndex = 8
        '
        'xlblDISCOUNT
        '
        Me.xlblDISCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.xlblDISCOUNT.Location = New System.Drawing.Point(7, 174)
        Me.xlblDISCOUNT.Name = "xlblDISCOUNT"
        Me.xlblDISCOUNT.Size = New System.Drawing.Size(93, 26)
        Me.xlblDISCOUNT.TabIndex = 18
        Me.xlblDISCOUNT.Text = "Discount"
        Me.xlblDISCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numDiscountValue
        '
        Me.numDiscountValue.DecimalPlaces = 2
        Me.numDiscountValue.InterceptArrowKeys = False
        Me.numDiscountValue.Location = New System.Drawing.Point(176, 174)
        Me.numDiscountValue.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numDiscountValue.Name = "numDiscountValue"
        Me.numDiscountValue.Size = New System.Drawing.Size(89, 23)
        Me.numDiscountValue.TabIndex = 9
        Me.numDiscountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbItem_Code
        '
        Me.cmbItem_Code.BackColor = System.Drawing.Color.Yellow
        Me.cmbItem_Code.CausesValidation = False
        Me.cmbItem_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbItem_Code.Enabled = False
        Me.cmbItem_Code.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbItem_Code.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItem_Code.ForeColor = System.Drawing.Color.Black
        Me.cmbItem_Code.FormattingEnabled = True
        Me.cmbItem_Code.Location = New System.Drawing.Point(264, -4)
        Me.cmbItem_Code.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbItem_Code.Name = "cmbItem_Code"
        Me.cmbItem_Code.Size = New System.Drawing.Size(17, 3)
        Me.cmbItem_Code.TabIndex = 1
        Me.cmbItem_Code.Visible = False
        '
        'lblQty_Base
        '
        Me.lblQty_Base.AutoSize = True
        Me.lblQty_Base.BackColor = System.Drawing.Color.Transparent
        Me.lblQty_Base.ForeColor = System.Drawing.Color.Blue
        Me.lblQty_Base.Location = New System.Drawing.Point(245, 213)
        Me.lblQty_Base.Name = "lblQty_Base"
        Me.lblQty_Base.Size = New System.Drawing.Size(15, 16)
        Me.lblQty_Base.TabIndex = 68
        Me.lblQty_Base.Text = "0"
        Me.lblQty_Base.Visible = False
        '
        'xlblSelection
        '
        Me.xlblSelection.BackColor = System.Drawing.Color.Transparent
        Me.xlblSelection.Location = New System.Drawing.Point(293, 148)
        Me.xlblSelection.Name = "xlblSelection"
        Me.xlblSelection.Size = New System.Drawing.Size(95, 16)
        Me.xlblSelection.TabIndex = 69
        Me.xlblSelection.Text = "Selection"
        Me.xlblSelection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.xlblSelection.Visible = False
        '
        'cmbSelection
        '
        Me.cmbSelection.FormattingEnabled = True
        Me.cmbSelection.Location = New System.Drawing.Point(390, 144)
        Me.cmbSelection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbSelection.Name = "cmbSelection"
        Me.cmbSelection.Size = New System.Drawing.Size(177, 24)
        Me.cmbSelection.TabIndex = 10
        Me.cmbSelection.Visible = False
        '
        'cmbItem_DESCRIPTION
        '
        Me.cmbItem_DESCRIPTION.BackColor = System.Drawing.Color.Yellow
        Me.cmbItem_DESCRIPTION.CausesValidation = False
        Me.cmbItem_DESCRIPTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbItem_DESCRIPTION.Enabled = False
        Me.cmbItem_DESCRIPTION.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItem_DESCRIPTION.ForeColor = System.Drawing.Color.Red
        Me.cmbItem_DESCRIPTION.FormattingEnabled = True
        Me.cmbItem_DESCRIPTION.Location = New System.Drawing.Point(288, -4)
        Me.cmbItem_DESCRIPTION.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbItem_DESCRIPTION.Name = "cmbItem_DESCRIPTION"
        Me.cmbItem_DESCRIPTION.Size = New System.Drawing.Size(11, 3)
        Me.cmbItem_DESCRIPTION.TabIndex = 2
        Me.cmbItem_DESCRIPTION.Visible = False
        '
        'xlblOnHand
        '
        Me.xlblOnHand.BackColor = System.Drawing.Color.White
        Me.xlblOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblOnHand.Location = New System.Drawing.Point(390, 119)
        Me.xlblOnHand.Name = "xlblOnHand"
        Me.xlblOnHand.Size = New System.Drawing.Size(177, 23)
        Me.xlblOnHand.TabIndex = 100001
        Me.xlblOnHand.Text = "0"
        Me.xlblOnHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindItemToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(651, 23)
        Me.MenuStrip1.TabIndex = 100002
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'FindItemToolStripMenuItem
        '
        Me.FindItemToolStripMenuItem.Name = "FindItemToolStripMenuItem"
        Me.FindItemToolStripMenuItem.Size = New System.Drawing.Size(69, 19)
        Me.FindItemToolStripMenuItem.Text = "&Find Item"
        Me.FindItemToolStripMenuItem.Visible = False
        '
        'cmbPRICE_LEVEL
        '
        Me.cmbPRICE_LEVEL.BackColor = System.Drawing.Color.White
        Me.cmbPRICE_LEVEL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRICE_LEVEL.FormattingEnabled = True
        Me.cmbPRICE_LEVEL.Location = New System.Drawing.Point(101, 119)
        Me.cmbPRICE_LEVEL.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbPRICE_LEVEL.Name = "cmbPRICE_LEVEL"
        Me.cmbPRICE_LEVEL.Size = New System.Drawing.Size(164, 24)
        Me.cmbPRICE_LEVEL.TabIndex = 7
        Me.cmbPRICE_LEVEL.Visible = False
        '
        'xxxlblPrice_level
        '
        Me.xxxlblPrice_level.BackColor = System.Drawing.Color.Transparent
        Me.xxxlblPrice_level.Location = New System.Drawing.Point(5, 124)
        Me.xxxlblPrice_level.Name = "xxxlblPrice_level"
        Me.xxxlblPrice_level.Size = New System.Drawing.Size(95, 16)
        Me.xxxlblPrice_level.TabIndex = 100004
        Me.xxxlblPrice_level.Text = "Price Group"
        Me.xxxlblPrice_level.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.xxxlblPrice_level.Visible = False
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.AllowUserToResizeColumns = False
        Me.dgvSearch.AllowUserToResizeRows = False
        Me.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSearch.Location = New System.Drawing.Point(3, 31)
        Me.dgvSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvSearch.MultiSelect = False
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersVisible = False
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.Size = New System.Drawing.Size(563, 10)
        Me.dgvSearch.TabIndex = 100006
        Me.dgvSearch.Visible = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(101, 7)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(466, 23)
        Me.txtSearch.TabIndex = 0
        '
        'xlblSearch
        '
        Me.xlblSearch.BackColor = System.Drawing.Color.Transparent
        Me.xlblSearch.ForeColor = System.Drawing.Color.Black
        Me.xlblSearch.Location = New System.Drawing.Point(6, 7)
        Me.xlblSearch.Name = "xlblSearch"
        Me.xlblSearch.Size = New System.Drawing.Size(93, 25)
        Me.xlblSearch.TabIndex = 100008
        Me.xlblSearch.Text = "Search Item"
        Me.xlblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblITEM_ID
        '
        Me.xlblITEM_ID.BackColor = System.Drawing.Color.White
        Me.xlblITEM_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblITEM_ID.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblITEM_ID.Location = New System.Drawing.Point(101, 37)
        Me.xlblITEM_ID.Name = "xlblITEM_ID"
        Me.xlblITEM_ID.Size = New System.Drawing.Size(164, 24)
        Me.xlblITEM_ID.TabIndex = 100009
        '
        'xlblDESCRIPTION
        '
        Me.xlblDESCRIPTION.BackColor = System.Drawing.Color.White
        Me.xlblDESCRIPTION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblDESCRIPTION.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblDESCRIPTION.Location = New System.Drawing.Point(271, 37)
        Me.xlblDESCRIPTION.Name = "xlblDESCRIPTION"
        Me.xlblDESCRIPTION.Size = New System.Drawing.Size(296, 54)
        Me.xlblDESCRIPTION.TabIndex = 100010
        '
        'picItem
        '
        Me.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picItem.Location = New System.Drawing.Point(573, 9)
        Me.picItem.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.picItem.Name = "picItem"
        Me.picItem.Size = New System.Drawing.Size(228, 188)
        Me.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picItem.TabIndex = 100011
        Me.picItem.TabStop = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.Location = New System.Drawing.Point(585, 206)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(101, 30)
        Me.btnOK.TabIndex = 100015
        Me.btnOK.Text = "[F1] &Add"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.Location = New System.Drawing.Point(692, 206)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(109, 30)
        Me.btnClose.TabIndex = 100016
        Me.btnClose.Text = "[ESC] &Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'xlblExpired
        '
        Me.xlblExpired.BackColor = System.Drawing.Color.Transparent
        Me.xlblExpired.Location = New System.Drawing.Point(272, 96)
        Me.xlblExpired.Name = "xlblExpired"
        Me.xlblExpired.Size = New System.Drawing.Size(114, 16)
        Me.xlblExpired.TabIndex = 100020
        Me.xlblExpired.Text = "Expired On"
        Me.xlblExpired.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.xlblExpired.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(193, 212)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 100021
        Me.Label6.Text = "Base "
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(298, 123)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 100022
        Me.Label7.Text = "On Hand"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpDateExpired
        '
        Me.dtpDateExpired.CustomFormat = "MMM/dd/yyyy"
        Me.dtpDateExpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateExpired.Location = New System.Drawing.Point(390, 92)
        Me.dtpDateExpired.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dtpDateExpired.Name = "dtpDateExpired"
        Me.dtpDateExpired.ShowCheckBox = True
        Me.dtpDateExpired.Size = New System.Drawing.Size(177, 23)
        Me.dtpDateExpired.TabIndex = 100023
        Me.dtpDateExpired.Visible = False
        '
        'frmAddItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(808, 247)
        Me.Controls.Add(Me.dgvSearch)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.xlblExpired)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.xlblITEM_ID)
        Me.Controls.Add(Me.picItem)
        Me.Controls.Add(Me.xlblSearch)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.cmbPRICE_LEVEL)
        Me.Controls.Add(Me.cmbItem_DESCRIPTION)
        Me.Controls.Add(Me.cmbSelection)
        Me.Controls.Add(Me.xlblSelection)
        Me.Controls.Add(Me.lblQty_Base)
        Me.Controls.Add(Me.cmbItem_Code)
        Me.Controls.Add(Me.numDiscountValue)
        Me.Controls.Add(Me.cmbDiscount_Type)
        Me.Controls.Add(Me.xlblDISCOUNT)
        Me.Controls.Add(Me.cmbUM)
        Me.Controls.Add(Me.chkTax)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.xlblLabel_Amount)
        Me.Controls.Add(Me.numUnit_price)
        Me.Controls.Add(Me.xlblnum_price)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.numQty)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.xxxlblPrice_level)
        Me.Controls.Add(Me.xlblDESCRIPTION)
        Me.Controls.Add(Me.xlblOnHand)
        Me.Controls.Add(Me.dtpDateExpired)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddItem"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "ADD ITEMS"
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUnit_price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDiscountValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents xlblnum_price As Label
    Friend WithEvents numUnit_price As NumericUpDown
    Friend WithEvents xlblLabel_Amount As Label
    Friend WithEvents lblAmount As Label
    Friend WithEvents chkTax As CheckBox
    Friend WithEvents cmbUM As ComboBox
    Friend WithEvents cmbDiscount_Type As ComboBox
    Friend WithEvents xlblDISCOUNT As Label
    Friend WithEvents numDiscountValue As NumericUpDown
    Friend WithEvents cmbItem_Code As ComboBox
    Friend WithEvents lblQty_Base As Label
    Friend WithEvents xlblSelection As Label
    Friend WithEvents cmbSelection As ComboBox
    Friend WithEvents cmbItem_DESCRIPTION As ComboBox
    Friend WithEvents xlblOnHand As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents cmbPRICE_LEVEL As ComboBox
    Friend WithEvents xxxlblPrice_level As Label
    Friend WithEvents FindItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents dgvSearch As DataGridView
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents xlblSearch As Label
    Friend WithEvents xlblITEM_ID As Label
    Friend WithEvents xlblDESCRIPTION As Label
    Friend WithEvents picItem As PictureBox
    Friend WithEvents btnOK As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents xlblExpired As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpDateExpired As DateTimePicker
End Class
