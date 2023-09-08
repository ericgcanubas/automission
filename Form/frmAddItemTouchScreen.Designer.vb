<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmAddItemTouchScreen
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvSearch = New System.Windows.Forms.DataGridView()
        Me.xlblITEM_ID = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.cmbPRICE_LEVEL = New System.Windows.Forms.ComboBox()
        Me.FindItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cmbItem_DESCRIPTION = New System.Windows.Forms.ComboBox()
        Me.cmbSelection = New System.Windows.Forms.ComboBox()
        Me.xlblSelection = New System.Windows.Forms.Label()
        Me.lblQty_Base = New System.Windows.Forms.Label()
        Me.cmbItem_Code = New System.Windows.Forms.ComboBox()
        Me.numDiscountValue = New System.Windows.Forms.NumericUpDown()
        Me.cmbDiscount_Type = New System.Windows.Forms.ComboBox()
        Me.cmbUM = New System.Windows.Forms.ComboBox()
        Me.chkTax = New System.Windows.Forms.CheckBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.xlblLabel_Amount = New System.Windows.Forms.Label()
        Me.numUnit_price = New System.Windows.Forms.NumericUpDown()
        Me.xlblnum_price = New System.Windows.Forms.Label()
        Me.xxxlblUnitTYpe = New System.Windows.Forms.Label()
        Me.numQty = New System.Windows.Forms.NumericUpDown()
        Me.xlblQTY = New System.Windows.Forms.Label()
        Me.xxxlblCODE = New System.Windows.Forms.Label()
        Me.xxxlblPrice_level = New System.Windows.Forms.Label()
        Me.xlblDESCRIPTION = New System.Windows.Forms.Label()
        Me.xlblOnHand = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.flp_Category = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnP_QTY = New System.Windows.Forms.Button()
        Me.btnN_QTY = New System.Windows.Forms.Button()
        Me.btnP_Price = New System.Windows.Forms.Button()
        Me.btnN_Price = New System.Windows.Forms.Button()
        Me.btnN_DISC = New System.Windows.Forms.Button()
        Me.btnP_DISC = New System.Windows.Forms.Button()
        Me.xlblDISCOUNT = New System.Windows.Forms.Label()
        Me.btnPLNeg = New System.Windows.Forms.Button()
        Me.btnPLPO = New System.Windows.Forms.Button()
        Me.btnUTNeg = New System.Windows.Forms.Button()
        Me.btnUTPO = New System.Windows.Forms.Button()
        Me.btnDTNeg = New System.Windows.Forms.Button()
        Me.btnDTPO = New System.Windows.Forms.Button()
        Me.xxxDISCOUNT_VALUE = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnUP = New System.Windows.Forms.Button()
        Me.picItem = New System.Windows.Forms.PictureBox()
        Me.btnDOWN = New System.Windows.Forms.Button()
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDiscountValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numUnit_price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.flp_Category.SuspendLayout()
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvSearch.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSearch.Location = New System.Drawing.Point(2, 29)
        Me.dgvSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dgvSearch.MultiSelect = False
        Me.dgvSearch.Name = "dgvSearch"
        Me.dgvSearch.ReadOnly = True
        Me.dgvSearch.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSearch.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSearch.Size = New System.Drawing.Size(331, 212)
        Me.dgvSearch.TabIndex = 100040
        '
        'xlblITEM_ID
        '
        Me.xlblITEM_ID.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblITEM_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblITEM_ID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblITEM_ID.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblITEM_ID.Location = New System.Drawing.Point(93, 263)
        Me.xlblITEM_ID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblITEM_ID.Name = "xlblITEM_ID"
        Me.xlblITEM_ID.Size = New System.Drawing.Size(143, 25)
        Me.xlblITEM_ID.TabIndex = 100042
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.Red
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnClose.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(358, 589)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(170, 68)
        Me.btnClose.TabIndex = 100047
        Me.btnClose.Text = "[ESC] CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSearch.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.Location = New System.Drawing.Point(2, 2)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(331, 26)
        Me.txtSearch.TabIndex = 100018
        '
        'cmbPRICE_LEVEL
        '
        Me.cmbPRICE_LEVEL.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbPRICE_LEVEL.BackColor = System.Drawing.Color.White
        Me.cmbPRICE_LEVEL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPRICE_LEVEL.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPRICE_LEVEL.FormattingEnabled = True
        Me.cmbPRICE_LEVEL.Location = New System.Drawing.Point(401, 267)
        Me.cmbPRICE_LEVEL.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbPRICE_LEVEL.Name = "cmbPRICE_LEVEL"
        Me.cmbPRICE_LEVEL.Size = New System.Drawing.Size(91, 24)
        Me.cmbPRICE_LEVEL.TabIndex = 100026
        Me.cmbPRICE_LEVEL.Visible = False
        '
        'FindItemToolStripMenuItem
        '
        Me.FindItemToolStripMenuItem.Name = "FindItemToolStripMenuItem"
        Me.FindItemToolStripMenuItem.Size = New System.Drawing.Size(69, 20)
        Me.FindItemToolStripMenuItem.Text = "&Find Item"
        Me.FindItemToolStripMenuItem.Visible = False
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOK.BackColor = System.Drawing.Color.DarkGreen
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(358, 513)
        Me.btnOK.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(170, 68)
        Me.btnOK.TabIndex = 100046
        Me.btnOK.Text = "[F1] ADD"
        Me.btnOK.UseVisualStyleBackColor = False
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
        Me.cmbItem_DESCRIPTION.Location = New System.Drawing.Point(294, -4)
        Me.cmbItem_DESCRIPTION.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbItem_DESCRIPTION.Name = "cmbItem_DESCRIPTION"
        Me.cmbItem_DESCRIPTION.Size = New System.Drawing.Size(13, 29)
        Me.cmbItem_DESCRIPTION.TabIndex = 100020
        Me.cmbItem_DESCRIPTION.Visible = False
        '
        'cmbSelection
        '
        Me.cmbSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbSelection.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSelection.FormattingEnabled = True
        Me.cmbSelection.Location = New System.Drawing.Point(334, 378)
        Me.cmbSelection.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbSelection.Name = "cmbSelection"
        Me.cmbSelection.Size = New System.Drawing.Size(194, 24)
        Me.cmbSelection.TabIndex = 100031
        Me.cmbSelection.Visible = False
        '
        'xlblSelection
        '
        Me.xlblSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblSelection.AutoSize = True
        Me.xlblSelection.BackColor = System.Drawing.Color.Transparent
        Me.xlblSelection.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblSelection.Location = New System.Drawing.Point(333, 357)
        Me.xlblSelection.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblSelection.Name = "xlblSelection"
        Me.xlblSelection.Size = New System.Drawing.Size(74, 16)
        Me.xlblSelection.TabIndex = 100036
        Me.xlblSelection.Text = "Selection"
        Me.xlblSelection.Visible = False
        '
        'lblQty_Base
        '
        Me.lblQty_Base.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblQty_Base.AutoSize = True
        Me.lblQty_Base.BackColor = System.Drawing.Color.Transparent
        Me.lblQty_Base.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQty_Base.Location = New System.Drawing.Point(92, 622)
        Me.lblQty_Base.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblQty_Base.Name = "lblQty_Base"
        Me.lblQty_Base.Size = New System.Drawing.Size(19, 18)
        Me.lblQty_Base.TabIndex = 100035
        Me.lblQty_Base.Text = "0"
        Me.lblQty_Base.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblQty_Base.Visible = False
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
        Me.cmbItem_Code.Location = New System.Drawing.Point(315, -4)
        Me.cmbItem_Code.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbItem_Code.Name = "cmbItem_Code"
        Me.cmbItem_Code.Size = New System.Drawing.Size(21, 29)
        Me.cmbItem_Code.TabIndex = 100019
        Me.cmbItem_Code.Visible = False
        '
        'numDiscountValue
        '
        Me.numDiscountValue.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numDiscountValue.DecimalPlaces = 2
        Me.numDiscountValue.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numDiscountValue.InterceptArrowKeys = False
        Me.numDiscountValue.Location = New System.Drawing.Point(97, 558)
        Me.numDiscountValue.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.numDiscountValue.Name = "numDiscountValue"
        Me.numDiscountValue.Size = New System.Drawing.Size(132, 26)
        Me.numDiscountValue.TabIndex = 100029
        Me.numDiscountValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbDiscount_Type
        '
        Me.cmbDiscount_Type.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbDiscount_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDiscount_Type.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDiscount_Type.FormattingEnabled = True
        Me.cmbDiscount_Type.Location = New System.Drawing.Point(96, 497)
        Me.cmbDiscount_Type.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbDiscount_Type.Name = "cmbDiscount_Type"
        Me.cmbDiscount_Type.Size = New System.Drawing.Size(132, 25)
        Me.cmbDiscount_Type.TabIndex = 100027
        '
        'cmbUM
        '
        Me.cmbUM.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmbUM.BackColor = System.Drawing.Color.White
        Me.cmbUM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUM.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUM.FormattingEnabled = True
        Me.cmbUM.Location = New System.Drawing.Point(401, 322)
        Me.cmbUM.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cmbUM.Name = "cmbUM"
        Me.cmbUM.Size = New System.Drawing.Size(91, 24)
        Me.cmbUM.TabIndex = 100022
        '
        'chkTax
        '
        Me.chkTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkTax.BackColor = System.Drawing.Color.Transparent
        Me.chkTax.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTax.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTax.Location = New System.Drawing.Point(7, 592)
        Me.chkTax.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.chkTax.Name = "chkTax"
        Me.chkTax.Size = New System.Drawing.Size(66, 25)
        Me.chkTax.TabIndex = 100025
        Me.chkTax.Text = "Tax :"
        Me.chkTax.UseVisualStyleBackColor = False
        '
        'lblAmount
        '
        Me.lblAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblAmount.BackColor = System.Drawing.Color.White
        Me.lblAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAmount.Font = New System.Drawing.Font("Verdana", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.ForeColor = System.Drawing.Color.Black
        Me.lblAmount.Location = New System.Drawing.Point(334, 424)
        Me.lblAmount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(194, 53)
        Me.lblAmount.TabIndex = 100016
        Me.lblAmount.Text = "9,999,999.99"
        Me.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblLabel_Amount
        '
        Me.xlblLabel_Amount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblLabel_Amount.BackColor = System.Drawing.Color.Transparent
        Me.xlblLabel_Amount.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblLabel_Amount.ForeColor = System.Drawing.Color.Black
        Me.xlblLabel_Amount.Location = New System.Drawing.Point(337, 407)
        Me.xlblLabel_Amount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblLabel_Amount.Name = "xlblLabel_Amount"
        Me.xlblLabel_Amount.Size = New System.Drawing.Size(69, 19)
        Me.xlblLabel_Amount.TabIndex = 100032
        Me.xlblLabel_Amount.Text = "AMOUNT :"
        Me.xlblLabel_Amount.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'numUnit_price
        '
        Me.numUnit_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numUnit_price.DecimalPlaces = 2
        Me.numUnit_price.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numUnit_price.InterceptArrowKeys = False
        Me.numUnit_price.Location = New System.Drawing.Point(96, 440)
        Me.numUnit_price.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.numUnit_price.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numUnit_price.Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
        Me.numUnit_price.Name = "numUnit_price"
        Me.numUnit_price.Size = New System.Drawing.Size(132, 26)
        Me.numUnit_price.TabIndex = 100023
        Me.numUnit_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xlblnum_price
        '
        Me.xlblnum_price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblnum_price.AutoSize = True
        Me.xlblnum_price.BackColor = System.Drawing.Color.Transparent
        Me.xlblnum_price.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblnum_price.Location = New System.Drawing.Point(98, 424)
        Me.xlblnum_price.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblnum_price.Name = "xlblnum_price"
        Me.xlblnum_price.Size = New System.Drawing.Size(85, 16)
        Me.xlblnum_price.TabIndex = 100030
        Me.xlblnum_price.Text = "Unit Price :"
        '
        'xxxlblUnitTYpe
        '
        Me.xxxlblUnitTYpe.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xxxlblUnitTYpe.AutoSize = True
        Me.xxxlblUnitTYpe.BackColor = System.Drawing.Color.Transparent
        Me.xxxlblUnitTYpe.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxlblUnitTYpe.Location = New System.Drawing.Point(405, 300)
        Me.xxxlblUnitTYpe.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xxxlblUnitTYpe.Name = "xxxlblUnitTYpe"
        Me.xxxlblUnitTYpe.Size = New System.Drawing.Size(75, 16)
        Me.xxxlblUnitTYpe.TabIndex = 100028
        Me.xxxlblUnitTYpe.Text = "Unit Type"
        '
        'numQty
        '
        Me.numQty.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.numQty.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numQty.InterceptArrowKeys = False
        Me.numQty.Location = New System.Drawing.Point(96, 381)
        Me.numQty.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.numQty.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numQty.Minimum = New Decimal(New Integer() {-727379969, 232, 0, -2147483648})
        Me.numQty.Name = "numQty"
        Me.numQty.Size = New System.Drawing.Size(132, 26)
        Me.numQty.TabIndex = 100021
        Me.numQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'xlblQTY
        '
        Me.xlblQTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblQTY.AutoSize = True
        Me.xlblQTY.BackColor = System.Drawing.Color.Transparent
        Me.xlblQTY.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblQTY.Location = New System.Drawing.Point(100, 363)
        Me.xlblQTY.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblQTY.Name = "xlblQTY"
        Me.xlblQTY.Size = New System.Drawing.Size(70, 16)
        Me.xlblQTY.TabIndex = 100024
        Me.xlblQTY.Text = "Quantity"
        '
        'xxxlblCODE
        '
        Me.xxxlblCODE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xxxlblCODE.AutoSize = True
        Me.xxxlblCODE.BackColor = System.Drawing.Color.Transparent
        Me.xxxlblCODE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxlblCODE.ForeColor = System.Drawing.Color.Black
        Me.xxxlblCODE.Location = New System.Drawing.Point(99, 247)
        Me.xxxlblCODE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xxxlblCODE.Name = "xxxlblCODE"
        Me.xxxlblCODE.Size = New System.Drawing.Size(76, 16)
        Me.xxxlblCODE.TabIndex = 100017
        Me.xxxlblCODE.Text = "BARCODE"
        '
        'xxxlblPrice_level
        '
        Me.xxxlblPrice_level.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xxxlblPrice_level.AutoSize = True
        Me.xxxlblPrice_level.BackColor = System.Drawing.Color.Transparent
        Me.xxxlblPrice_level.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxlblPrice_level.Location = New System.Drawing.Point(405, 249)
        Me.xxxlblPrice_level.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xxxlblPrice_level.Name = "xxxlblPrice_level"
        Me.xxxlblPrice_level.Size = New System.Drawing.Size(86, 16)
        Me.xxxlblPrice_level.TabIndex = 100039
        Me.xxxlblPrice_level.Text = "Price Level"
        Me.xxxlblPrice_level.Visible = False
        '
        'xlblDESCRIPTION
        '
        Me.xlblDESCRIPTION.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblDESCRIPTION.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblDESCRIPTION.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblDESCRIPTION.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblDESCRIPTION.Location = New System.Drawing.Point(2, 322)
        Me.xlblDESCRIPTION.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblDESCRIPTION.Name = "xlblDESCRIPTION"
        Me.xlblDESCRIPTION.Size = New System.Drawing.Size(331, 32)
        Me.xlblDESCRIPTION.TabIndex = 100043
        '
        'xlblOnHand
        '
        Me.xlblOnHand.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.xlblOnHand.BackColor = System.Drawing.Color.White
        Me.xlblOnHand.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblOnHand.Location = New System.Drawing.Point(334, 377)
        Me.xlblOnHand.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblOnHand.Name = "xlblOnHand"
        Me.xlblOnHand.Size = New System.Drawing.Size(194, 26)
        Me.xlblOnHand.TabIndex = 100037
        Me.xlblOnHand.Text = "0"
        Me.xlblOnHand.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(-1, 307)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 100045
        Me.Label2.Text = "DESCRIPTION"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FindItemToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(9, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(531, 24)
        Me.MenuStrip1.TabIndex = 100038
        Me.MenuStrip1.Text = "MenuStrip1"
        Me.MenuStrip1.Visible = False
        '
        'flp_Category
        '
        Me.flp_Category.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flp_Category.AutoScroll = True
        Me.flp_Category.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.flp_Category.Controls.Add(Me.Button1)
        Me.flp_Category.Location = New System.Drawing.Point(334, 1)
        Me.flp_Category.Name = "flp_Category"
        Me.flp_Category.Size = New System.Drawing.Size(194, 240)
        Me.flp_Category.TabIndex = 100048
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 57)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnP_QTY
        '
        Me.btnP_QTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnP_QTY.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnP_QTY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP_QTY.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnP_QTY.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnP_QTY.Location = New System.Drawing.Point(245, 363)
        Me.btnP_QTY.Name = "btnP_QTY"
        Me.btnP_QTY.Size = New System.Drawing.Size(88, 52)
        Me.btnP_QTY.TabIndex = 100051
        Me.btnP_QTY.Text = "+"
        Me.btnP_QTY.UseVisualStyleBackColor = False
        '
        'btnN_QTY
        '
        Me.btnN_QTY.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnN_QTY.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnN_QTY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN_QTY.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN_QTY.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnN_QTY.Location = New System.Drawing.Point(1, 360)
        Me.btnN_QTY.Name = "btnN_QTY"
        Me.btnN_QTY.Size = New System.Drawing.Size(88, 52)
        Me.btnN_QTY.TabIndex = 100052
        Me.btnN_QTY.Text = "-"
        Me.btnN_QTY.UseVisualStyleBackColor = False
        '
        'btnP_Price
        '
        Me.btnP_Price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnP_Price.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnP_Price.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP_Price.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnP_Price.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnP_Price.Location = New System.Drawing.Point(245, 421)
        Me.btnP_Price.Name = "btnP_Price"
        Me.btnP_Price.Size = New System.Drawing.Size(88, 52)
        Me.btnP_Price.TabIndex = 100053
        Me.btnP_Price.Text = "+"
        Me.btnP_Price.UseVisualStyleBackColor = False
        '
        'btnN_Price
        '
        Me.btnN_Price.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnN_Price.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnN_Price.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN_Price.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN_Price.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnN_Price.Location = New System.Drawing.Point(1, 418)
        Me.btnN_Price.Name = "btnN_Price"
        Me.btnN_Price.Size = New System.Drawing.Size(88, 52)
        Me.btnN_Price.TabIndex = 100054
        Me.btnN_Price.Text = "-"
        Me.btnN_Price.UseVisualStyleBackColor = False
        '
        'btnN_DISC
        '
        Me.btnN_DISC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnN_DISC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnN_DISC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnN_DISC.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnN_DISC.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnN_DISC.Location = New System.Drawing.Point(1, 535)
        Me.btnN_DISC.Name = "btnN_DISC"
        Me.btnN_DISC.Size = New System.Drawing.Size(88, 52)
        Me.btnN_DISC.TabIndex = 100055
        Me.btnN_DISC.Text = "-"
        Me.btnN_DISC.UseVisualStyleBackColor = False
        Me.btnN_DISC.Visible = False
        '
        'btnP_DISC
        '
        Me.btnP_DISC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnP_DISC.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnP_DISC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP_DISC.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnP_DISC.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnP_DISC.Location = New System.Drawing.Point(245, 538)
        Me.btnP_DISC.Name = "btnP_DISC"
        Me.btnP_DISC.Size = New System.Drawing.Size(88, 52)
        Me.btnP_DISC.TabIndex = 100056
        Me.btnP_DISC.Text = "+"
        Me.btnP_DISC.UseVisualStyleBackColor = False
        Me.btnP_DISC.Visible = False
        '
        'xlblDISCOUNT
        '
        Me.xlblDISCOUNT.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xlblDISCOUNT.AutoSize = True
        Me.xlblDISCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.xlblDISCOUNT.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblDISCOUNT.Location = New System.Drawing.Point(98, 481)
        Me.xlblDISCOUNT.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xlblDISCOUNT.Name = "xlblDISCOUNT"
        Me.xlblDISCOUNT.Size = New System.Drawing.Size(121, 16)
        Me.xlblDISCOUNT.TabIndex = 100033
        Me.xlblDISCOUNT.Text = "DISCOUNT TYPE"
        '
        'btnPLNeg
        '
        Me.btnPLNeg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPLNeg.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPLNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPLNeg.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPLNeg.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnPLNeg.Location = New System.Drawing.Point(339, 243)
        Me.btnPLNeg.Name = "btnPLNeg"
        Me.btnPLNeg.Size = New System.Drawing.Size(59, 52)
        Me.btnPLNeg.TabIndex = 100057
        Me.btnPLNeg.Text = "-"
        Me.btnPLNeg.UseVisualStyleBackColor = False
        Me.btnPLNeg.Visible = False
        '
        'btnPLPO
        '
        Me.btnPLPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPLPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnPLPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPLPO.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPLPO.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnPLPO.Location = New System.Drawing.Point(469, 243)
        Me.btnPLPO.Name = "btnPLPO"
        Me.btnPLPO.Size = New System.Drawing.Size(59, 52)
        Me.btnPLPO.TabIndex = 100058
        Me.btnPLPO.Text = "+"
        Me.btnPLPO.UseVisualStyleBackColor = False
        Me.btnPLPO.Visible = False
        '
        'btnUTNeg
        '
        Me.btnUTNeg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUTNeg.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnUTNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUTNeg.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUTNeg.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnUTNeg.Location = New System.Drawing.Point(339, 295)
        Me.btnUTNeg.Name = "btnUTNeg"
        Me.btnUTNeg.Size = New System.Drawing.Size(59, 52)
        Me.btnUTNeg.TabIndex = 100059
        Me.btnUTNeg.Text = "-"
        Me.btnUTNeg.UseVisualStyleBackColor = False
        Me.btnUTNeg.Visible = False
        '
        'btnUTPO
        '
        Me.btnUTPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUTPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnUTPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUTPO.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUTPO.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnUTPO.Location = New System.Drawing.Point(469, 295)
        Me.btnUTPO.Name = "btnUTPO"
        Me.btnUTPO.Size = New System.Drawing.Size(59, 52)
        Me.btnUTPO.TabIndex = 100060
        Me.btnUTPO.Text = "+"
        Me.btnUTPO.UseVisualStyleBackColor = False
        Me.btnUTPO.Visible = False
        '
        'btnDTNeg
        '
        Me.btnDTNeg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDTNeg.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDTNeg.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDTNeg.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDTNeg.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnDTNeg.Location = New System.Drawing.Point(1, 477)
        Me.btnDTNeg.Name = "btnDTNeg"
        Me.btnDTNeg.Size = New System.Drawing.Size(88, 52)
        Me.btnDTNeg.TabIndex = 100061
        Me.btnDTNeg.Text = "-"
        Me.btnDTNeg.UseVisualStyleBackColor = False
        Me.btnDTNeg.Visible = False
        '
        'btnDTPO
        '
        Me.btnDTPO.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDTPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDTPO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDTPO.Font = New System.Drawing.Font("Verdana", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDTPO.ForeColor = System.Drawing.Color.DarkBlue
        Me.btnDTPO.Location = New System.Drawing.Point(245, 480)
        Me.btnDTPO.Name = "btnDTPO"
        Me.btnDTPO.Size = New System.Drawing.Size(88, 52)
        Me.btnDTPO.TabIndex = 100062
        Me.btnDTPO.Text = "+"
        Me.btnDTPO.UseVisualStyleBackColor = False
        Me.btnDTPO.Visible = False
        '
        'xxxDISCOUNT_VALUE
        '
        Me.xxxDISCOUNT_VALUE.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.xxxDISCOUNT_VALUE.AutoSize = True
        Me.xxxDISCOUNT_VALUE.BackColor = System.Drawing.Color.Transparent
        Me.xxxDISCOUNT_VALUE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxDISCOUNT_VALUE.Location = New System.Drawing.Point(99, 540)
        Me.xxxDISCOUNT_VALUE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xxxDISCOUNT_VALUE.Name = "xxxDISCOUNT_VALUE"
        Me.xxxDISCOUNT_VALUE.Size = New System.Drawing.Size(132, 16)
        Me.xxxDISCOUNT_VALUE.TabIndex = 100063
        Me.xxxDISCOUNT_VALUE.Text = "DISCOUNT VALUE"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 622)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 16)
        Me.Label3.TabIndex = 100064
        Me.Label3.Text = "QTY BASE"
        Me.Label3.Visible = False
        '
        'btnUP
        '
        Me.btnUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnUP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUP.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUP.Image = Global.Automission.My.Resources.Resources.arrow_up
        Me.btnUP.Location = New System.Drawing.Point(245, 242)
        Me.btnUP.Name = "btnUP"
        Me.btnUP.Size = New System.Drawing.Size(88, 60)
        Me.btnUP.TabIndex = 100049
        Me.btnUP.UseVisualStyleBackColor = False
        '
        'picItem
        '
        Me.picItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.picItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picItem.Location = New System.Drawing.Point(334, 243)
        Me.picItem.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.picItem.Name = "picItem"
        Me.picItem.Size = New System.Drawing.Size(194, 112)
        Me.picItem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picItem.TabIndex = 100044
        Me.picItem.TabStop = False
        '
        'btnDOWN
        '
        Me.btnDOWN.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDOWN.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDOWN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDOWN.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDOWN.Image = Global.Automission.My.Resources.Resources.arrow_down
        Me.btnDOWN.Location = New System.Drawing.Point(2, 242)
        Me.btnDOWN.Name = "btnDOWN"
        Me.btnDOWN.Size = New System.Drawing.Size(88, 60)
        Me.btnDOWN.TabIndex = 100050
        Me.btnDOWN.UseVisualStyleBackColor = False
        '
        'frmAddItemTouchScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(531, 664)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.xxxDISCOUNT_VALUE)
        Me.Controls.Add(Me.btnDTPO)
        Me.Controls.Add(Me.btnDTNeg)
        Me.Controls.Add(Me.btnUTPO)
        Me.Controls.Add(Me.btnUTNeg)
        Me.Controls.Add(Me.btnPLPO)
        Me.Controls.Add(Me.btnPLNeg)
        Me.Controls.Add(Me.btnP_Price)
        Me.Controls.Add(Me.btnP_DISC)
        Me.Controls.Add(Me.btnN_DISC)
        Me.Controls.Add(Me.btnN_Price)
        Me.Controls.Add(Me.btnN_QTY)
        Me.Controls.Add(Me.btnP_QTY)
        Me.Controls.Add(Me.btnUP)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.flp_Category)
        Me.Controls.Add(Me.xlblLabel_Amount)
        Me.Controls.Add(Me.dgvSearch)
        Me.Controls.Add(Me.xlblITEM_ID)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.picItem)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cmbItem_DESCRIPTION)
        Me.Controls.Add(Me.cmbSelection)
        Me.Controls.Add(Me.xlblSelection)
        Me.Controls.Add(Me.lblQty_Base)
        Me.Controls.Add(Me.cmbItem_Code)
        Me.Controls.Add(Me.numDiscountValue)
        Me.Controls.Add(Me.cmbDiscount_Type)
        Me.Controls.Add(Me.xlblDISCOUNT)
        Me.Controls.Add(Me.numUnit_price)
        Me.Controls.Add(Me.xlblnum_price)
        Me.Controls.Add(Me.numQty)
        Me.Controls.Add(Me.xlblQTY)
        Me.Controls.Add(Me.xxxlblCODE)
        Me.Controls.Add(Me.xxxlblPrice_level)
        Me.Controls.Add(Me.xlblDESCRIPTION)
        Me.Controls.Add(Me.xlblOnHand)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkTax)
        Me.Controls.Add(Me.btnDOWN)
        Me.Controls.Add(Me.cmbPRICE_LEVEL)
        Me.Controls.Add(Me.cmbUM)
        Me.Controls.Add(Me.xxxlblUnitTYpe)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddItemTouchScreen"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Search Item :"
        CType(Me.dgvSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDiscountValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numUnit_price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.flp_Category.ResumeLayout(False)
        CType(Me.picItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvSearch As DataGridView
    Friend WithEvents xlblITEM_ID As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents picItem As PictureBox
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents cmbPRICE_LEVEL As ComboBox
    Friend WithEvents FindItemToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnOK As Button
    Friend WithEvents cmbItem_DESCRIPTION As ComboBox
    Friend WithEvents cmbSelection As ComboBox
    Friend WithEvents xlblSelection As Label
    Friend WithEvents lblQty_Base As Label
    Friend WithEvents cmbItem_Code As ComboBox
    Friend WithEvents numDiscountValue As NumericUpDown
    Friend WithEvents cmbDiscount_Type As ComboBox
    Friend WithEvents cmbUM As ComboBox
    Friend WithEvents chkTax As CheckBox
    Friend WithEvents lblAmount As Label
    Friend WithEvents xlblLabel_Amount As Label
    Friend WithEvents numUnit_price As NumericUpDown
    Friend WithEvents xlblnum_price As Label
    Friend WithEvents xxxlblUnitTYpe As Label
    Friend WithEvents numQty As NumericUpDown
    Friend WithEvents xlblQTY As Label
    Friend WithEvents xxxlblCODE As Label
    Friend WithEvents xxxlblPrice_level As Label
    Friend WithEvents xlblDESCRIPTION As Label
    Friend WithEvents xlblOnHand As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents flp_Category As FlowLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents btnUP As Button
    Friend WithEvents btnDOWN As Button
    Friend WithEvents btnP_QTY As Button
    Friend WithEvents btnN_QTY As Button
    Friend WithEvents btnP_Price As Button
    Friend WithEvents btnN_Price As Button
    Friend WithEvents btnN_DISC As Button
    Friend WithEvents btnP_DISC As Button
    Friend WithEvents xlblDISCOUNT As Label
    Friend WithEvents btnPLNeg As Button
    Friend WithEvents btnPLPO As Button
    Friend WithEvents btnUTNeg As Button
    Friend WithEvents btnUTPO As Button
    Friend WithEvents btnDTNeg As Button
    Friend WithEvents btnDTPO As Button
    Friend WithEvents xxxDISCOUNT_VALUE As Label
    Friend WithEvents Label3 As Label
End Class
