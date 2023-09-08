<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSCreatePayment
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.dgvSELECTED = New System.Windows.Forms.DataGridView()
        Me.dgvAVAILABLE = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAMOUNT_APPLIED = New System.Windows.Forms.Label()
        Me.xlblAMOUNT = New System.Windows.Forms.Label()
        Me.numAMOUNT = New System.Windows.Forms.NumericUpDown()
        Me.xlblCHANGE = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpRECEIPT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.dtpCARD_EXPIRY_DATE = New System.Windows.Forms.DateTimePicker()
        Me.OR_DATE = New System.Windows.Forms.Label()
        Me.txtRECEIPT_REF_NO = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CARD_EXPIRED_DATE = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_METHOD_ID = New System.Windows.Forms.ComboBox()
        Me.txtCARD_NO = New System.Windows.Forms.TextBox()
        Me.CARD_NO = New System.Windows.Forms.Label()
        Me.OR_No = New System.Windows.Forms.Label()
        Me.btnNumberKEY = New System.Windows.Forms.Button()
        Me.btnP_P = New System.Windows.Forms.Button()
        Me.btnP_N = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xlblCustomer_Name = New System.Windows.Forms.Label()
        Me.xlblAV_AMOUNT = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.dgvSELECTED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAVAILABLE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(341, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 23)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "SELECTED ORDER SERVED"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(263, 23)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "AVAILABLE ORDER SERVED"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(521, 468)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(116, 56)
        Me.btnCancel.TabIndex = 19
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Green
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(399, 468)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(116, 56)
        Me.btnOK.TabIndex = 18
        Me.btnOK.Text = "&SAVE"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveAll.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAll.Location = New System.Drawing.Point(278, 218)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(57, 40)
        Me.btnRemoveAll.TabIndex = 17
        Me.btnRemoveAll.Text = "<<"
        Me.btnRemoveAll.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemove.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(278, 175)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(57, 40)
        Me.btnRemove.TabIndex = 16
        Me.btnRemove.Text = "<"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(278, 133)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(57, 40)
        Me.btnAdd.TabIndex = 15
        Me.btnAdd.Text = ">"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnAddAll
        '
        Me.btnAddAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddAll.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAll.Location = New System.Drawing.Point(278, 90)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(57, 40)
        Me.btnAddAll.TabIndex = 14
        Me.btnAddAll.Text = ">>"
        Me.btnAddAll.UseVisualStyleBackColor = False
        '
        'dgvSELECTED
        '
        Me.dgvSELECTED.AllowUserToAddRows = False
        Me.dgvSELECTED.AllowUserToDeleteRows = False
        Me.dgvSELECTED.AllowUserToResizeColumns = False
        Me.dgvSELECTED.AllowUserToResizeRows = False
        Me.dgvSELECTED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSELECTED.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvSELECTED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSELECTED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSELECTED.Location = New System.Drawing.Point(340, 90)
        Me.dgvSELECTED.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSELECTED.MultiSelect = False
        Me.dgvSELECTED.Name = "dgvSELECTED"
        Me.dgvSELECTED.ReadOnly = True
        Me.dgvSELECTED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSELECTED.Size = New System.Drawing.Size(297, 169)
        Me.dgvSELECTED.TabIndex = 13
        '
        'dgvAVAILABLE
        '
        Me.dgvAVAILABLE.AllowUserToAddRows = False
        Me.dgvAVAILABLE.AllowUserToDeleteRows = False
        Me.dgvAVAILABLE.AllowUserToResizeColumns = False
        Me.dgvAVAILABLE.AllowUserToResizeRows = False
        Me.dgvAVAILABLE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAVAILABLE.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvAVAILABLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAVAILABLE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAVAILABLE.Location = New System.Drawing.Point(12, 90)
        Me.dgvAVAILABLE.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvAVAILABLE.MultiSelect = False
        Me.dgvAVAILABLE.Name = "dgvAVAILABLE"
        Me.dgvAVAILABLE.ReadOnly = True
        Me.dgvAVAILABLE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAVAILABLE.Size = New System.Drawing.Size(261, 169)
        Me.dgvAVAILABLE.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(341, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 35)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "TOTAL"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.UseMnemonic = False
        '
        'lblAMOUNT_APPLIED
        '
        Me.lblAMOUNT_APPLIED.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblAMOUNT_APPLIED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAMOUNT_APPLIED.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMOUNT_APPLIED.Location = New System.Drawing.Point(433, 260)
        Me.lblAMOUNT_APPLIED.Name = "lblAMOUNT_APPLIED"
        Me.lblAMOUNT_APPLIED.Size = New System.Drawing.Size(204, 35)
        Me.lblAMOUNT_APPLIED.TabIndex = 23
        Me.lblAMOUNT_APPLIED.Text = "999,999.99"
        Me.lblAMOUNT_APPLIED.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xlblAMOUNT
        '
        Me.xlblAMOUNT.BackColor = System.Drawing.Color.Transparent
        Me.xlblAMOUNT.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblAMOUNT.Location = New System.Drawing.Point(341, 333)
        Me.xlblAMOUNT.Name = "xlblAMOUNT"
        Me.xlblAMOUNT.Size = New System.Drawing.Size(135, 21)
        Me.xlblAMOUNT.TabIndex = 24
        Me.xlblAMOUNT.Text = "TENDER"
        Me.xlblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numAMOUNT
        '
        Me.numAMOUNT.DecimalPlaces = 2
        Me.numAMOUNT.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAMOUNT.Location = New System.Drawing.Point(480, 331)
        Me.numAMOUNT.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numAMOUNT.Name = "numAMOUNT"
        Me.numAMOUNT.Size = New System.Drawing.Size(156, 33)
        Me.numAMOUNT.TabIndex = 25
        Me.numAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numAMOUNT.ThousandsSeparator = True
        '
        'xlblCHANGE
        '
        Me.xlblCHANGE.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblCHANGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCHANGE.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCHANGE.Location = New System.Drawing.Point(480, 367)
        Me.xlblCHANGE.Name = "xlblCHANGE"
        Me.xlblCHANGE.Size = New System.Drawing.Size(157, 29)
        Me.xlblCHANGE.TabIndex = 27
        Me.xlblCHANGE.Text = "999,999.99"
        Me.xlblCHANGE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(352, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 30)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "CHANGE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label6.UseMnemonic = False
        '
        'dtpRECEIPT_DATE
        '
        Me.dtpRECEIPT_DATE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpRECEIPT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRECEIPT_DATE.Location = New System.Drawing.Point(143, 392)
        Me.dtpRECEIPT_DATE.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpRECEIPT_DATE.Name = "dtpRECEIPT_DATE"
        Me.dtpRECEIPT_DATE.ShowCheckBox = True
        Me.dtpRECEIPT_DATE.Size = New System.Drawing.Size(202, 31)
        Me.dtpRECEIPT_DATE.TabIndex = 36
        '
        'dtpCARD_EXPIRY_DATE
        '
        Me.dtpCARD_EXPIRY_DATE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCARD_EXPIRY_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCARD_EXPIRY_DATE.Location = New System.Drawing.Point(143, 489)
        Me.dtpCARD_EXPIRY_DATE.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpCARD_EXPIRY_DATE.Name = "dtpCARD_EXPIRY_DATE"
        Me.dtpCARD_EXPIRY_DATE.ShowCheckBox = True
        Me.dtpCARD_EXPIRY_DATE.Size = New System.Drawing.Size(202, 31)
        Me.dtpCARD_EXPIRY_DATE.TabIndex = 40
        '
        'OR_DATE
        '
        Me.OR_DATE.BackColor = System.Drawing.Color.Transparent
        Me.OR_DATE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OR_DATE.Location = New System.Drawing.Point(6, 392)
        Me.OR_DATE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.OR_DATE.Name = "OR_DATE"
        Me.OR_DATE.Size = New System.Drawing.Size(137, 23)
        Me.OR_DATE.TabIndex = 35
        Me.OR_DATE.Text = "Date"
        Me.OR_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtRECEIPT_REF_NO
        '
        Me.txtRECEIPT_REF_NO.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECEIPT_REF_NO.Location = New System.Drawing.Point(143, 358)
        Me.txtRECEIPT_REF_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRECEIPT_REF_NO.Name = "txtRECEIPT_REF_NO"
        Me.txtRECEIPT_REF_NO.Size = New System.Drawing.Size(202, 31)
        Me.txtRECEIPT_REF_NO.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(-2, 311)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(146, 23)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Pmt. Method"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CARD_EXPIRED_DATE
        '
        Me.CARD_EXPIRED_DATE.BackColor = System.Drawing.Color.Transparent
        Me.CARD_EXPIRED_DATE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CARD_EXPIRED_DATE.Location = New System.Drawing.Point(2, 495)
        Me.CARD_EXPIRED_DATE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CARD_EXPIRED_DATE.Name = "CARD_EXPIRED_DATE"
        Me.CARD_EXPIRED_DATE.Size = New System.Drawing.Size(142, 23)
        Me.CARD_EXPIRED_DATE.TabIndex = 39
        Me.CARD_EXPIRED_DATE.Text = "Expired"
        Me.CARD_EXPIRED_DATE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPAYMENT_METHOD_ID
        '
        Me.cmbPAYMENT_METHOD_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_METHOD_ID.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPAYMENT_METHOD_ID.FormattingEnabled = True
        Me.cmbPAYMENT_METHOD_ID.Location = New System.Drawing.Point(178, 308)
        Me.cmbPAYMENT_METHOD_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPAYMENT_METHOD_ID.Name = "cmbPAYMENT_METHOD_ID"
        Me.cmbPAYMENT_METHOD_ID.Size = New System.Drawing.Size(148, 31)
        Me.cmbPAYMENT_METHOD_ID.TabIndex = 31
        '
        'txtCARD_NO
        '
        Me.txtCARD_NO.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCARD_NO.Location = New System.Drawing.Point(143, 457)
        Me.txtCARD_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCARD_NO.Name = "txtCARD_NO"
        Me.txtCARD_NO.Size = New System.Drawing.Size(202, 31)
        Me.txtCARD_NO.TabIndex = 38
        '
        'CARD_NO
        '
        Me.CARD_NO.BackColor = System.Drawing.Color.Transparent
        Me.CARD_NO.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CARD_NO.Location = New System.Drawing.Point(2, 460)
        Me.CARD_NO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CARD_NO.Name = "CARD_NO"
        Me.CARD_NO.Size = New System.Drawing.Size(141, 23)
        Me.CARD_NO.TabIndex = 37
        Me.CARD_NO.Text = "Card No."
        Me.CARD_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OR_No
        '
        Me.OR_No.BackColor = System.Drawing.Color.Transparent
        Me.OR_No.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OR_No.Location = New System.Drawing.Point(6, 361)
        Me.OR_No.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.OR_No.Name = "OR_No"
        Me.OR_No.Size = New System.Drawing.Size(137, 23)
        Me.OR_No.TabIndex = 32
        Me.OR_No.Text = "O.R No."
        Me.OR_No.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnNumberKEY
        '
        Me.btnNumberKEY.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNumberKEY.Location = New System.Drawing.Point(480, 308)
        Me.btnNumberKEY.Name = "btnNumberKEY"
        Me.btnNumberKEY.Size = New System.Drawing.Size(70, 21)
        Me.btnNumberKEY.TabIndex = 41
        Me.btnNumberKEY.Text = "NUMKEY"
        Me.btnNumberKEY.UseVisualStyleBackColor = True
        '
        'btnP_P
        '
        Me.btnP_P.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnP_P.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP_P.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnP_P.Location = New System.Drawing.Point(329, 307)
        Me.btnP_P.Name = "btnP_P"
        Me.btnP_P.Size = New System.Drawing.Size(33, 33)
        Me.btnP_P.TabIndex = 42
        Me.btnP_P.Text = "+"
        Me.btnP_P.UseVisualStyleBackColor = False
        '
        'btnP_N
        '
        Me.btnP_N.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnP_N.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnP_N.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnP_N.Location = New System.Drawing.Point(143, 307)
        Me.btnP_N.Name = "btnP_N"
        Me.btnP_N.Size = New System.Drawing.Size(33, 33)
        Me.btnP_N.TabIndex = 43
        Me.btnP_N.Text = "-"
        Me.btnP_N.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(206, 24)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Buyer name"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.UseMnemonic = False
        '
        'xlblCustomer_Name
        '
        Me.xlblCustomer_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblCustomer_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCustomer_Name.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCustomer_Name.Location = New System.Drawing.Point(17, 34)
        Me.xlblCustomer_Name.Name = "xlblCustomer_Name"
        Me.xlblCustomer_Name.Size = New System.Drawing.Size(619, 34)
        Me.xlblCustomer_Name.TabIndex = 44
        Me.xlblCustomer_Name.Text = "JUAN DELA CRUZ"
        Me.xlblCustomer_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'xlblAV_AMOUNT
        '
        Me.xlblAV_AMOUNT.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.xlblAV_AMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblAV_AMOUNT.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblAV_AMOUNT.Location = New System.Drawing.Point(87, 260)
        Me.xlblAV_AMOUNT.Name = "xlblAV_AMOUNT"
        Me.xlblAV_AMOUNT.Size = New System.Drawing.Size(186, 35)
        Me.xlblAV_AMOUNT.TabIndex = 48
        Me.xlblAV_AMOUNT.Text = "999,999.99"
        Me.xlblAV_AMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 260)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 35)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "TOTAL"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label9.UseMnemonic = False
        '
        'txtNOTES
        '
        Me.txtNOTES.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNOTES.Location = New System.Drawing.Point(143, 427)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(493, 27)
        Me.txtNOTES.TabIndex = 49
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 427)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 23)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "NOTES"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmPOSCreatePayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(648, 529)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.xlblAV_AMOUNT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.xlblCustomer_Name)
        Me.Controls.Add(Me.btnP_N)
        Me.Controls.Add(Me.btnP_P)
        Me.Controls.Add(Me.btnNumberKEY)
        Me.Controls.Add(Me.cmbPAYMENT_METHOD_ID)
        Me.Controls.Add(Me.dtpRECEIPT_DATE)
        Me.Controls.Add(Me.dtpCARD_EXPIRY_DATE)
        Me.Controls.Add(Me.OR_DATE)
        Me.Controls.Add(Me.txtRECEIPT_REF_NO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CARD_EXPIRED_DATE)
        Me.Controls.Add(Me.txtCARD_NO)
        Me.Controls.Add(Me.CARD_NO)
        Me.Controls.Add(Me.OR_No)
        Me.Controls.Add(Me.xlblCHANGE)
        Me.Controls.Add(Me.numAMOUNT)
        Me.Controls.Add(Me.xlblAMOUNT)
        Me.Controls.Add(Me.lblAMOUNT_APPLIED)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.dgvSELECTED)
        Me.Controls.Add(Me.dgvAVAILABLE)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSCreatePayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAYMENT"
        CType(Me.dgvSELECTED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAVAILABLE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnRemoveAll As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnAddAll As Button
    Friend WithEvents dgvSELECTED As DataGridView
    Friend WithEvents dgvAVAILABLE As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents lblAMOUNT_APPLIED As Label
    Friend WithEvents xlblAMOUNT As Label
    Friend WithEvents numAMOUNT As NumericUpDown
    Friend WithEvents xlblCHANGE As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpRECEIPT_DATE As DateTimePicker
    Friend WithEvents dtpCARD_EXPIRY_DATE As DateTimePicker
    Friend WithEvents OR_DATE As Label
    Friend WithEvents txtRECEIPT_REF_NO As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents CARD_EXPIRED_DATE As Label
    Friend WithEvents cmbPAYMENT_METHOD_ID As ComboBox
    Friend WithEvents txtCARD_NO As TextBox
    Friend WithEvents CARD_NO As Label
    Friend WithEvents OR_No As Label
    Friend WithEvents btnNumberKEY As Button
    Friend WithEvents btnP_P As Button
    Friend WithEvents btnP_N As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents xlblCustomer_Name As Label
    Friend WithEvents xlblAV_AMOUNT As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents Label5 As Label
End Class
