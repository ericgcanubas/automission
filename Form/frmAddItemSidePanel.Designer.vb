<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddItemSidePanel
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
        Me.components = New System.ComponentModel.Container()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.xlblITEM_ID = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.picItem = New System.Windows.Forms.PictureBox()
        Me.xlblSearch = New System.Windows.Forms.Label()
        Me.stxtSearch = New System.Windows.Forms.TextBox()
        Me.cmbPRICE_LEVEL = New System.Windows.Forms.ComboBox()
        Me.FindItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmbItem_DESCRIPTION = New System.Windows.Forms.ComboBox()
        Me.cmbSelection = New System.Windows.Forms.ComboBox()
        Me.xlblSelection = New System.Windows.Forms.Label()
        Me.lblQty_Base = New System.Windows.Forms.Label()
        Me.cmbItem_Code = New System.Windows.Forms.ComboBox()
        Me.numDiscountValue = New System.Windows.Forms.NumericUpDown()
        Me.cmbDiscount_Type = New System.Windows.Forms.ComboBox()
        Me.xlblDISCOUNT = New System.Windows.Forms.Label()
        Me.cmbUM = New System.Windows.Forms.ComboBox()
        Me.chkTax = New System.Windows.Forms.CheckBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.xlblLabel_Amount = New System.Windows.Forms.Label()
        Me.numUnit_price = New System.Windows.Forms.NumericUpDown()
        Me.xlblnum_price = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.xxxlblPrice_level = New System.Windows.Forms.Label()
        Me.xlblDESCRIPTION = New System.Windows.Forms.Label()
        Me.xlblOnHand = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.xlblExpired = New System.Windows.Forms.Label()
        Me.dtpDateExpired = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDiscountValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUnit_price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvSearch
        '
        Me.dgvSearch.AllowUserToAddRows = False
        Me.dgvSearch.AllowUserToDeleteRows = False
        Me.dgvSearch.AllowUserToResizeColumns = False
        Me.dgvSearch.AllowUserToResizeRows = False
        Me.dgvSearch.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSearch.Location = New System.Drawing.Point(2, 31)
        Me.dgvSearch.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvSearch.MultiSelect = False
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersVisible = False
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.ShowCellErrors = False
        Me.dgvSearch.ShowCellToolTips = False
        Me.dgvSearch.ShowEditingIcon = False
        Me.dgvSearch.ShowRowErrors = False
        Me.dgvSearch.Size = New System.Drawing.Size(442, 152)
        Me.dgvSearch.TabIndex = 100040
        '
        'xlblITEM_ID
        '
        Me.xlblITEM_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblITEM_ID.BackColor = System.Drawing.Color.White
        Me.xlblITEM_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblITEM_ID.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblITEM_ID.Location = New System.Drawing.Point(4, 208)
        Me.xlblITEM_ID.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblITEM_ID.Name = "xlblITEM_ID"
        Me.xlblITEM_ID.Size = New System.Drawing.Size(251, 19)
        Me.xlblITEM_ID.TabIndex = 100042
        Me.xlblITEM_ID.Text = "999999999999"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(259, 485)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(98, 54)
        Me.btnOK.TabIndex = 100046
        Me.btnOK.Text = "[INSERT] &ADD"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'picItem
        '
        Me.picItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picItem.Location = New System.Drawing.Point(259, 189)
        Me.picItem.Margin = New System.Windows.Forms.Padding(5, 2, 5, 2)
        Me.picItem.Name = "picItem"
        Me.picItem.Size = New System.Drawing.Size(186, 108)
        Me.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picItem.TabIndex = 100044
        Me.picItem.TabStop = False
        '
        'xlblSearch
        '
        Me.xlblSearch.AutoSize = True
        Me.xlblSearch.BackColor = System.Drawing.Color.Transparent
        Me.xlblSearch.ForeColor = System.Drawing.Color.Black
        Me.xlblSearch.Location = New System.Drawing.Point(4, 9)
        Me.xlblSearch.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblSearch.Name = "xlblSearch"
        Me.xlblSearch.Size = New System.Drawing.Size(50, 14)
        Me.xlblSearch.TabIndex = 100041
        Me.xlblSearch.Text = "Search"
        Me.xlblSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stxtSearch
        '
        Me.stxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stxtSearch.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stxtSearch.Location = New System.Drawing.Point(56, 6)
        Me.stxtSearch.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.stxtSearch.Name = "stxtSearch"
        Me.stxtSearch.Size = New System.Drawing.Size(387, 23)
        Me.stxtSearch.TabIndex = 100018
        '
        'cmbPRICE_LEVEL
        '
        Me.cmbPRICE_LEVEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbPRICE_LEVEL.BackColor = System.Drawing.Color.White
        Me.cmbPRICE_LEVEL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRICE_LEVEL.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPRICE_LEVEL.FormattingEnabled = True
        Me.cmbPRICE_LEVEL.Location = New System.Drawing.Point(4, 416)
        Me.cmbPRICE_LEVEL.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbPRICE_LEVEL.Name = "cmbPRICE_LEVEL"
        Me.cmbPRICE_LEVEL.Size = New System.Drawing.Size(169, 22)
        Me.cmbPRICE_LEVEL.TabIndex = 100026
        Me.cmbPRICE_LEVEL.Visible = False
        '
        'FindItemToolStripMenuItem
        '
        Me.FindItemToolStripMenuItem.Name = "FindItemToolStripMenuItem"
        Me.FindItemToolStripMenuItem.Size = New System.Drawing.Size(69, 22)
        Me.FindItemToolStripMenuItem.Text = "&Find Item"
        Me.FindItemToolStripMenuItem.Visible = False
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Maroon
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(359, 485)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(85, 53)
        Me.btnClose.TabIndex = 100047
        Me.btnClose.Text = "[ESC] &CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'cmbItem_DESCRIPTION
        '
        Me.cmbItem_DESCRIPTION.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbItem_DESCRIPTION.BackColor = System.Drawing.Color.Yellow
        Me.cmbItem_DESCRIPTION.CausesValidation = False
        Me.cmbItem_DESCRIPTION.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbItem_DESCRIPTION.Enabled = False
        Me.cmbItem_DESCRIPTION.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItem_DESCRIPTION.ForeColor = System.Drawing.Color.Red
        Me.cmbItem_DESCRIPTION.FormattingEnabled = True
        Me.cmbItem_DESCRIPTION.Location = New System.Drawing.Point(343, 115)
        Me.cmbItem_DESCRIPTION.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbItem_DESCRIPTION.Name = "cmbItem_DESCRIPTION"
        Me.cmbItem_DESCRIPTION.Size = New System.Drawing.Size(13, 26)
        Me.cmbItem_DESCRIPTION.TabIndex = 100020
        Me.cmbItem_DESCRIPTION.Visible = False
        '
        'cmbSelection
        '
        Me.cmbSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbSelection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSelection.FormattingEnabled = True
        Me.cmbSelection.Location = New System.Drawing.Point(262, 368)
        Me.cmbSelection.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbSelection.Name = "cmbSelection"
        Me.cmbSelection.Size = New System.Drawing.Size(183, 22)
        Me.cmbSelection.TabIndex = 100031
        Me.cmbSelection.Visible = False
        '
        'xlblSelection
        '
        Me.xlblSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblSelection.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.xlblSelection.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblSelection.Location = New System.Drawing.Point(259, 346)
        Me.xlblSelection.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblSelection.Name = "xlblSelection"
        Me.xlblSelection.Size = New System.Drawing.Size(185, 19)
        Me.xlblSelection.TabIndex = 100036
        Me.xlblSelection.Text = "Selection"
        Me.xlblSelection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.xlblSelection.Visible = False
        '
        'lblQty_Base
        '
        Me.lblQty_Base.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQty_Base.AutoSize = True
        Me.lblQty_Base.BackColor = System.Drawing.Color.Transparent
        Me.lblQty_Base.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty_Base.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblQty_Base.Location = New System.Drawing.Point(157, 371)
        Me.lblQty_Base.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblQty_Base.Name = "lblQty_Base"
        Me.lblQty_Base.Size = New System.Drawing.Size(16, 14)
        Me.lblQty_Base.TabIndex = 100035
        Me.lblQty_Base.Text = "0"
        '
        'cmbItem_Code
        '
        Me.cmbItem_Code.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbItem_Code.BackColor = System.Drawing.Color.Yellow
        Me.cmbItem_Code.CausesValidation = False
        Me.cmbItem_Code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.cmbItem_Code.Enabled = False
        Me.cmbItem_Code.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbItem_Code.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbItem_Code.ForeColor = System.Drawing.Color.Black
        Me.cmbItem_Code.FormattingEnabled = True
        Me.cmbItem_Code.Location = New System.Drawing.Point(309, 115)
        Me.cmbItem_Code.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbItem_Code.Name = "cmbItem_Code"
        Me.cmbItem_Code.Size = New System.Drawing.Size(21, 26)
        Me.cmbItem_Code.TabIndex = 100019
        Me.cmbItem_Code.Visible = False
        '
        'numDiscountValue
        '
        Me.numDiscountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numDiscountValue.DecimalPlaces = 2
        Me.numDiscountValue.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDiscountValue.InterceptArrowKeys = False
        Me.numDiscountValue.Location = New System.Drawing.Point(73, 505)
        Me.numDiscountValue.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numDiscountValue.Name = "numDiscountValue"
        Me.numDiscountValue.Size = New System.Drawing.Size(103, 22)
        Me.numDiscountValue.TabIndex = 100029
        Me.numDiscountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbDiscount_Type
        '
        Me.cmbDiscount_Type.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbDiscount_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiscount_Type.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiscount_Type.FormattingEnabled = True
        Me.cmbDiscount_Type.Location = New System.Drawing.Point(4, 505)
        Me.cmbDiscount_Type.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDiscount_Type.Name = "cmbDiscount_Type"
        Me.cmbDiscount_Type.Size = New System.Drawing.Size(67, 22)
        Me.cmbDiscount_Type.TabIndex = 100027
        '
        'xlblDISCOUNT
        '
        Me.xlblDISCOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblDISCOUNT.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.xlblDISCOUNT.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblDISCOUNT.Location = New System.Drawing.Point(3, 485)
        Me.xlblDISCOUNT.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblDISCOUNT.Name = "xlblDISCOUNT"
        Me.xlblDISCOUNT.Size = New System.Drawing.Size(173, 19)
        Me.xlblDISCOUNT.TabIndex = 100033
        Me.xlblDISCOUNT.Text = "Discount"
        Me.xlblDISCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbUM
        '
        Me.cmbUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbUM.BackColor = System.Drawing.Color.White
        Me.cmbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUM.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUM.FormattingEnabled = True
        Me.cmbUM.Location = New System.Drawing.Point(4, 368)
        Me.cmbUM.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbUM.Name = "cmbUM"
        Me.cmbUM.Size = New System.Drawing.Size(92, 22)
        Me.cmbUM.TabIndex = 100022
        '
        'chkTax
        '
        Me.chkTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkTax.BackColor = System.Drawing.Color.Transparent
        Me.chkTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTax.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTax.Location = New System.Drawing.Point(186, 319)
        Me.chkTax.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkTax.Name = "chkTax"
        Me.chkTax.Size = New System.Drawing.Size(52, 22)
        Me.chkTax.TabIndex = 100025
        Me.chkTax.Text = "Tax "
        Me.chkTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTax.UseVisualStyleBackColor = False
        '
        'lblAmount
        '
        Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmount.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Navy
        Me.lblAmount.Location = New System.Drawing.Point(259, 459)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(186, 23)
        Me.lblAmount.TabIndex = 100016
        Me.lblAmount.Text = "9,999,999.99"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblLabel_Amount
        '
        Me.xlblLabel_Amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblLabel_Amount.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.xlblLabel_Amount.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblLabel_Amount.ForeColor = System.Drawing.Color.Black
        Me.xlblLabel_Amount.Location = New System.Drawing.Point(259, 440)
        Me.xlblLabel_Amount.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblLabel_Amount.Name = "xlblLabel_Amount"
        Me.xlblLabel_Amount.Size = New System.Drawing.Size(186, 18)
        Me.xlblLabel_Amount.TabIndex = 100032
        Me.xlblLabel_Amount.Text = "Amount"
        Me.xlblLabel_Amount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numUnit_price
        '
        Me.numUnit_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numUnit_price.DecimalPlaces = 2
        Me.numUnit_price.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numUnit_price.InterceptArrowKeys = False
        Me.numUnit_price.Location = New System.Drawing.Point(4, 461)
        Me.numUnit_price.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numUnit_price.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numUnit_price.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.numUnit_price.Name = "numUnit_price"
        Me.numUnit_price.Size = New System.Drawing.Size(172, 22)
        Me.numUnit_price.TabIndex = 100023
        Me.numUnit_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xlblnum_price
        '
        Me.xlblnum_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblnum_price.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.xlblnum_price.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblnum_price.Location = New System.Drawing.Point(4, 440)
        Me.xlblnum_price.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblnum_price.Name = "xlblnum_price"
        Me.xlblnum_price.Size = New System.Drawing.Size(172, 20)
        Me.xlblnum_price.TabIndex = 100030
        Me.xlblnum_price.Text = "Price"
        Me.xlblnum_price.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 344)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(172, 23)
        Me.Label5.TabIndex = 100028
        Me.Label5.Text = "Size"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numQty
        '
        Me.numQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numQty.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numQty.InterceptArrowKeys = False
        Me.numQty.Location = New System.Drawing.Point(4, 320)
        Me.numQty.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numQty.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numQty.Minimum = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(92, 22)
        Me.numQty.TabIndex = 100021
        Me.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(4, 298)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 100024
        Me.Label4.Text = "Quantity"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(4, 186)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(251, 21)
        Me.Label1.TabIndex = 100017
        Me.Label1.Text = "Barcode"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xxxlblPrice_level
        '
        Me.xxxlblPrice_level.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xxxlblPrice_level.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.xxxlblPrice_level.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxlblPrice_level.Location = New System.Drawing.Point(4, 394)
        Me.xxxlblPrice_level.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xxxlblPrice_level.Name = "xxxlblPrice_level"
        Me.xxxlblPrice_level.Size = New System.Drawing.Size(172, 21)
        Me.xxxlblPrice_level.TabIndex = 100039
        Me.xxxlblPrice_level.Text = "Price Group"
        Me.xxxlblPrice_level.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.xxxlblPrice_level.Visible = False
        '
        'xlblDESCRIPTION
        '
        Me.xlblDESCRIPTION.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblDESCRIPTION.BackColor = System.Drawing.Color.White
        Me.xlblDESCRIPTION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblDESCRIPTION.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblDESCRIPTION.Location = New System.Drawing.Point(4, 247)
        Me.xlblDESCRIPTION.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblDESCRIPTION.Name = "xlblDESCRIPTION"
        Me.xlblDESCRIPTION.Size = New System.Drawing.Size(251, 50)
        Me.xlblDESCRIPTION.TabIndex = 100043
        '
        'xlblOnHand
        '
        Me.xlblOnHand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblOnHand.BackColor = System.Drawing.Color.White
        Me.xlblOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblOnHand.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblOnHand.Location = New System.Drawing.Point(100, 320)
        Me.xlblOnHand.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.xlblOnHand.Name = "xlblOnHand"
        Me.xlblOnHand.Size = New System.Drawing.Size(76, 22)
        Me.xlblOnHand.TabIndex = 100037
        Me.xlblOnHand.Text = "0"
        Me.xlblOnHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(4, 228)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(251, 18)
        Me.Label2.TabIndex = 100045
        Me.Label2.Text = "Description"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindItemToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(1473, 26)
        Me.MenuStrip1.TabIndex = 100038
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(100, 299)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 100048
        Me.Label3.Text = "Onhand"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(117, 371)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 14)
        Me.Label6.TabIndex = 100049
        Me.Label6.Text = "Base "
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblExpired
        '
        Me.xlblExpired.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblExpired.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.xlblExpired.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblExpired.Location = New System.Drawing.Point(259, 299)
        Me.xlblExpired.Name = "xlblExpired"
        Me.xlblExpired.Size = New System.Drawing.Size(186, 20)
        Me.xlblExpired.TabIndex = 100052
        Me.xlblExpired.Text = "Expired On"
        Me.xlblExpired.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.xlblExpired.Visible = False
        '
        'dtpDateExpired
        '
        Me.dtpDateExpired.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtpDateExpired.CustomFormat = "MMM/dd/yyyy"
        Me.dtpDateExpired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateExpired.Location = New System.Drawing.Point(263, 321)
        Me.dtpDateExpired.Name = "dtpDateExpired"
        Me.dtpDateExpired.ShowCheckBox = True
        Me.dtpDateExpired.Size = New System.Drawing.Size(182, 22)
        Me.dtpDateExpired.TabIndex = 100053
        '
        'frmAddItemSidePanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(448, 541)
        Me.Controls.Add(Me.dtpDateExpired)
        Me.Controls.Add(Me.xlblExpired)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.xlblDESCRIPTION)
        Me.Controls.Add(Me.xlblITEM_ID)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.picItem)
        Me.Controls.Add(Me.stxtSearch)
        Me.Controls.Add(Me.cmbPRICE_LEVEL)
        Me.Controls.Add(Me.btnClose)
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
        Me.Controls.Add(Me.xlblOnHand)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvSearch)
        Me.Controls.Add(Me.xlblSearch)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddItemSidePanel"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Item"
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDiscountValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUnit_price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSearch As DataGridView
    Friend WithEvents xlblITEM_ID As Label
    Friend WithEvents btnOK As Button
    Friend WithEvents picItem As PictureBox
    Friend WithEvents xlblSearch As Label
    Friend WithEvents stxtSearch As TextBox
    Friend WithEvents cmbPRICE_LEVEL As ComboBox
    Friend WithEvents FindItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnClose As Button
    Friend WithEvents cmbItem_DESCRIPTION As ComboBox
    Friend WithEvents cmbSelection As ComboBox
    Friend WithEvents xlblSelection As Label
    Friend WithEvents lblQty_Base As Label
    Friend WithEvents cmbItem_Code As ComboBox
    Friend WithEvents numDiscountValue As NumericUpDown
    Friend WithEvents cmbDiscount_Type As ComboBox
    Friend WithEvents xlblDISCOUNT As Label
    Friend WithEvents cmbUM As ComboBox
    Friend WithEvents chkTax As CheckBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents xlblLabel_Amount As Label
    Friend WithEvents numUnit_price As NumericUpDown
    Friend WithEvents xlblnum_price As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents xxxlblPrice_level As Label
    Friend WithEvents xlblDESCRIPTION As Label
    Friend WithEvents xlblOnHand As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents xlblExpired As Label
    Friend WithEvents dtpDateExpired As DateTimePicker
End Class
