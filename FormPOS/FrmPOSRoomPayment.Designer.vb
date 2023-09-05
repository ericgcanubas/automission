<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSRoomPayment
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
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnAdded = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.xlblCustomer_Name = New System.Windows.Forms.Label()
        Me.dgvMethod = New System.Windows.Forms.DataGridView()
        Me.dgvMethodSet = New System.Windows.Forms.DataGridView()
        Me.xxMETHOD_LABEL = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpCARD_EXPIRY_DATE = New System.Windows.Forms.DateTimePicker()
        Me.CARD_EXPIRED_DATE = New System.Windows.Forms.Label()
        Me.txtCARD_NO = New System.Windows.Forms.TextBox()
        Me.CARD_NO = New System.Windows.Forms.Label()
        Me.lblAMOUNT = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xlblCHANGE = New System.Windows.Forms.Label()
        Me.lblAMOUNT_APPLIED = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNOTES = New System.Windows.Forms.TextBox()
        Me.dtpRECEIPT_DATE = New System.Windows.Forms.DateTimePicker()
        Me.txtRECEIPT_REF_NO = New System.Windows.Forms.TextBox()
        Me.OR_No = New System.Windows.Forms.Label()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.xxlblValue = New System.Windows.Forms.Label()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnDownA = New System.Windows.Forms.Button()
        Me.btnUpA = New System.Windows.Forms.Button()
        Me.btnUpB = New System.Windows.Forms.Button()
        Me.btnDownB = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.dgvMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMethodSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.Purple
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.ForeColor = System.Drawing.Color.White
        Me.btnRemove.Location = New System.Drawing.Point(455, 102)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(63, 65)
        Me.btnRemove.TabIndex = 96
        Me.btnRemove.Text = "<"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnAdded
        '
        Me.btnAdded.BackColor = System.Drawing.Color.Purple
        Me.btnAdded.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdded.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdded.ForeColor = System.Drawing.Color.White
        Me.btnAdded.Location = New System.Drawing.Point(455, 29)
        Me.btnAdded.Name = "btnAdded"
        Me.btnAdded.Size = New System.Drawing.Size(63, 65)
        Me.btnAdded.TabIndex = 95
        Me.btnAdded.Text = ">"
        Me.btnAdded.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(523, 13)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(116, 14)
        Me.Label9.TabIndex = 118
        Me.Label9.Text = "Method Selected"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(254, 13)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 14)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Method List"
        '
        'xlblCustomer_Name
        '
        Me.xlblCustomer_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblCustomer_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCustomer_Name.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCustomer_Name.Location = New System.Drawing.Point(15, 437)
        Me.xlblCustomer_Name.Name = "xlblCustomer_Name"
        Me.xlblCustomer_Name.Size = New System.Drawing.Size(567, 36)
        Me.xlblCustomer_Name.TabIndex = 115
        Me.xlblCustomer_Name.Text = "JUAN DELA CRUZ"
        Me.xlblCustomer_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgvMethod
        '
        Me.dgvMethod.AllowUserToAddRows = False
        Me.dgvMethod.AllowUserToDeleteRows = False
        Me.dgvMethod.AllowUserToResizeColumns = False
        Me.dgvMethod.AllowUserToResizeRows = False
        Me.dgvMethod.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMethod.BackgroundColor = System.Drawing.Color.White
        Me.dgvMethod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMethod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvMethod.Location = New System.Drawing.Point(257, 29)
        Me.dgvMethod.MultiSelect = False
        Me.dgvMethod.Name = "dgvMethod"
        Me.dgvMethod.ReadOnly = True
        Me.dgvMethod.RowHeadersVisible = False
        Me.dgvMethod.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMethod.Size = New System.Drawing.Size(193, 141)
        Me.dgvMethod.TabIndex = 41
        '
        'dgvMethodSet
        '
        Me.dgvMethodSet.AllowUserToAddRows = False
        Me.dgvMethodSet.AllowUserToDeleteRows = False
        Me.dgvMethodSet.AllowUserToResizeColumns = False
        Me.dgvMethodSet.AllowUserToResizeRows = False
        Me.dgvMethodSet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMethodSet.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvMethodSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMethodSet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvMethodSet.Location = New System.Drawing.Point(522, 29)
        Me.dgvMethodSet.MultiSelect = False
        Me.dgvMethodSet.Name = "dgvMethodSet"
        Me.dgvMethodSet.ReadOnly = True
        Me.dgvMethodSet.RowHeadersVisible = False
        Me.dgvMethodSet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMethodSet.Size = New System.Drawing.Size(351, 141)
        Me.dgvMethodSet.TabIndex = 44
        '
        'xxMETHOD_LABEL
        '
        Me.xxMETHOD_LABEL.AutoSize = True
        Me.xxMETHOD_LABEL.BackColor = System.Drawing.Color.Transparent
        Me.xxMETHOD_LABEL.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxMETHOD_LABEL.Location = New System.Drawing.Point(10, 13)
        Me.xxMETHOD_LABEL.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.xxMETHOD_LABEL.Name = "xxMETHOD_LABEL"
        Me.xxMETHOD_LABEL.Size = New System.Drawing.Size(71, 16)
        Me.xxMETHOD_LABEL.TabIndex = 119
        Me.xxMETHOD_LABEL.Text = "Selected"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(13, 413)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(237, 24)
        Me.Label7.TabIndex = 116
        Me.Label7.Text = "Customer"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label7.UseMnemonic = False
        '
        'dtpCARD_EXPIRY_DATE
        '
        Me.dtpCARD_EXPIRY_DATE.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpCARD_EXPIRY_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpCARD_EXPIRY_DATE.Location = New System.Drawing.Point(414, 346)
        Me.dtpCARD_EXPIRY_DATE.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpCARD_EXPIRY_DATE.Name = "dtpCARD_EXPIRY_DATE"
        Me.dtpCARD_EXPIRY_DATE.ShowCheckBox = True
        Me.dtpCARD_EXPIRY_DATE.Size = New System.Drawing.Size(161, 26)
        Me.dtpCARD_EXPIRY_DATE.TabIndex = 114
        '
        'CARD_EXPIRED_DATE
        '
        Me.CARD_EXPIRED_DATE.AutoSize = True
        Me.CARD_EXPIRED_DATE.BackColor = System.Drawing.Color.Transparent
        Me.CARD_EXPIRED_DATE.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CARD_EXPIRED_DATE.Location = New System.Drawing.Point(411, 330)
        Me.CARD_EXPIRED_DATE.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CARD_EXPIRED_DATE.Name = "CARD_EXPIRED_DATE"
        Me.CARD_EXPIRED_DATE.Size = New System.Drawing.Size(110, 16)
        Me.CARD_EXPIRED_DATE.TabIndex = 113
        Me.CARD_EXPIRED_DATE.Text = "Card Expired :"
        '
        'txtCARD_NO
        '
        Me.txtCARD_NO.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCARD_NO.Location = New System.Drawing.Point(259, 346)
        Me.txtCARD_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCARD_NO.Name = "txtCARD_NO"
        Me.txtCARD_NO.Size = New System.Drawing.Size(153, 26)
        Me.txtCARD_NO.TabIndex = 112
        '
        'CARD_NO
        '
        Me.CARD_NO.AutoSize = True
        Me.CARD_NO.BackColor = System.Drawing.Color.Transparent
        Me.CARD_NO.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CARD_NO.Location = New System.Drawing.Point(263, 331)
        Me.CARD_NO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.CARD_NO.Name = "CARD_NO"
        Me.CARD_NO.Size = New System.Drawing.Size(79, 16)
        Me.CARD_NO.TabIndex = 111
        Me.CARD_NO.Text = "Card No. :"
        '
        'lblAMOUNT
        '
        Me.lblAMOUNT.BackColor = System.Drawing.Color.Black
        Me.lblAMOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAMOUNT.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMOUNT.ForeColor = System.Drawing.Color.Lime
        Me.lblAMOUNT.Location = New System.Drawing.Point(718, 300)
        Me.lblAMOUNT.Name = "lblAMOUNT"
        Me.lblAMOUNT.Size = New System.Drawing.Size(153, 30)
        Me.lblAMOUNT.TabIndex = 110
        Me.lblAMOUNT.Text = "999,999.99"
        Me.lblAMOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(616, 301)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 28)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "TENDER"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.UseMnemonic = False
        '
        'xlblCHANGE
        '
        Me.xlblCHANGE.BackColor = System.Drawing.Color.Black
        Me.xlblCHANGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCHANGE.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCHANGE.ForeColor = System.Drawing.Color.Plum
        Me.xlblCHANGE.Location = New System.Drawing.Point(718, 364)
        Me.xlblCHANGE.Name = "xlblCHANGE"
        Me.xlblCHANGE.Size = New System.Drawing.Size(153, 31)
        Me.xlblCHANGE.TabIndex = 107
        Me.xlblCHANGE.Text = "999,999.99"
        Me.xlblCHANGE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAMOUNT_APPLIED
        '
        Me.lblAMOUNT_APPLIED.BackColor = System.Drawing.Color.Black
        Me.lblAMOUNT_APPLIED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAMOUNT_APPLIED.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAMOUNT_APPLIED.ForeColor = System.Drawing.Color.Yellow
        Me.lblAMOUNT_APPLIED.Location = New System.Drawing.Point(718, 332)
        Me.lblAMOUNT_APPLIED.Name = "lblAMOUNT_APPLIED"
        Me.lblAMOUNT_APPLIED.Size = New System.Drawing.Size(153, 30)
        Me.lblAMOUNT_APPLIED.TabIndex = 106
        Me.lblAMOUNT_APPLIED.Text = "999,999.99"
        Me.lblAMOUNT_APPLIED.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(619, 333)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 28)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "BILL"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.UseMnemonic = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(619, 363)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 30)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "CHANGE"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.UseMnemonic = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(411, 286)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "O.R Date"
        '
        'btnCANCEL
        '
        Me.btnCANCEL.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCANCEL.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCANCEL.ForeColor = System.Drawing.Color.White
        Me.btnCANCEL.Location = New System.Drawing.Point(762, 404)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(111, 81)
        Me.btnCANCEL.TabIndex = 103
        Me.btnCANCEL.Text = "CANCEL"
        Me.btnCANCEL.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(263, 371)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 16)
        Me.Label5.TabIndex = 102
        Me.Label5.Text = "Notes :"
        '
        'txtNOTES
        '
        Me.txtNOTES.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNOTES.Location = New System.Drawing.Point(259, 387)
        Me.txtNOTES.Name = "txtNOTES"
        Me.txtNOTES.Size = New System.Drawing.Size(318, 27)
        Me.txtNOTES.TabIndex = 101
        '
        'dtpRECEIPT_DATE
        '
        Me.dtpRECEIPT_DATE.Font = New System.Drawing.Font("Verdana", 11.25!)
        Me.dtpRECEIPT_DATE.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRECEIPT_DATE.Location = New System.Drawing.Point(414, 303)
        Me.dtpRECEIPT_DATE.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpRECEIPT_DATE.Name = "dtpRECEIPT_DATE"
        Me.dtpRECEIPT_DATE.ShowCheckBox = True
        Me.dtpRECEIPT_DATE.Size = New System.Drawing.Size(161, 26)
        Me.dtpRECEIPT_DATE.TabIndex = 100
        '
        'txtRECEIPT_REF_NO
        '
        Me.txtRECEIPT_REF_NO.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRECEIPT_REF_NO.Location = New System.Drawing.Point(259, 303)
        Me.txtRECEIPT_REF_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtRECEIPT_REF_NO.Name = "txtRECEIPT_REF_NO"
        Me.txtRECEIPT_REF_NO.Size = New System.Drawing.Size(153, 27)
        Me.txtRECEIPT_REF_NO.TabIndex = 99
        '
        'OR_No
        '
        Me.OR_No.AutoSize = True
        Me.OR_No.BackColor = System.Drawing.Color.Transparent
        Me.OR_No.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OR_No.Location = New System.Drawing.Point(256, 286)
        Me.OR_No.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.OR_No.Name = "OR_No"
        Me.OR_No.Size = New System.Drawing.Size(70, 16)
        Me.OR_No.TabIndex = 98
        Me.OR_No.Text = "O.R No. :"
        '
        'btnSAVE
        '
        Me.btnSAVE.BackColor = System.Drawing.Color.DarkGreen
        Me.btnSAVE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSAVE.ForeColor = System.Drawing.Color.White
        Me.btnSAVE.Location = New System.Drawing.Point(649, 404)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(111, 81)
        Me.btnSAVE.TabIndex = 97
        Me.btnSAVE.Text = "SAVE"
        Me.btnSAVE.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Coral
        Me.Button12.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button12.ForeColor = System.Drawing.Color.White
        Me.Button12.Image = Global.Automission.My.Resources.Resources.back_icon_set
        Me.Button12.Location = New System.Drawing.Point(169, 300)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(82, 81)
        Me.Button12.TabIndex = 93
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Navy
        Me.Button4.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(7, 144)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(82, 81)
        Me.Button4.TabIndex = 85
        Me.Button4.Text = "4"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Navy
        Me.Button3.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(169, 222)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(82, 81)
        Me.Button3.TabIndex = 84
        Me.Button3.Text = "3"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Navy
        Me.Button2.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(88, 222)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(82, 81)
        Me.Button2.TabIndex = 83
        Me.Button2.Text = "2"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Navy
        Me.Button1.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(7, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(82, 81)
        Me.Button1.TabIndex = 82
        Me.Button1.Text = "1"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'xxlblValue
        '
        Me.xxlblValue.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xxlblValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xxlblValue.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxlblValue.Location = New System.Drawing.Point(7, 29)
        Me.xxlblValue.Name = "xxlblValue"
        Me.xxlblValue.Size = New System.Drawing.Size(243, 34)
        Me.xxlblValue.TabIndex = 94
        Me.xxlblValue.Text = "9,999,999.00"
        Me.xxlblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Blue
        Me.Button11.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button11.ForeColor = System.Drawing.Color.White
        Me.Button11.Location = New System.Drawing.Point(88, 300)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(82, 81)
        Me.Button11.TabIndex = 92
        Me.Button11.Text = "."
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.Navy
        Me.Button10.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button10.ForeColor = System.Drawing.Color.White
        Me.Button10.Location = New System.Drawing.Point(7, 300)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(82, 81)
        Me.Button10.TabIndex = 91
        Me.Button10.Text = "0"
        Me.Button10.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Navy
        Me.Button9.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button9.ForeColor = System.Drawing.Color.White
        Me.Button9.Location = New System.Drawing.Point(169, 66)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(82, 81)
        Me.Button9.TabIndex = 90
        Me.Button9.Text = "9"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Navy
        Me.Button8.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(88, 66)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(82, 81)
        Me.Button8.TabIndex = 89
        Me.Button8.Text = "8"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Navy
        Me.Button7.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(7, 66)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(82, 81)
        Me.Button7.TabIndex = 88
        Me.Button7.Text = "7"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Navy
        Me.Button6.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(169, 144)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(82, 81)
        Me.Button6.TabIndex = 87
        Me.Button6.Text = "6"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Navy
        Me.Button5.Font = New System.Drawing.Font("Verdana", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(88, 144)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(82, 81)
        Me.Button5.TabIndex = 86
        Me.Button5.Text = "5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'btnDownA
        '
        Me.btnDownA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDownA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDownA.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownA.ForeColor = System.Drawing.Color.White
        Me.btnDownA.Image = Global.Automission.My.Resources.Resources.arrow_down
        Me.btnDownA.Location = New System.Drawing.Point(257, 173)
        Me.btnDownA.Name = "btnDownA"
        Me.btnDownA.Size = New System.Drawing.Size(80, 61)
        Me.btnDownA.TabIndex = 120
        Me.btnDownA.UseVisualStyleBackColor = False
        '
        'btnUpA
        '
        Me.btnUpA.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUpA.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpA.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpA.ForeColor = System.Drawing.Color.White
        Me.btnUpA.Image = Global.Automission.My.Resources.Resources.arrow_up
        Me.btnUpA.Location = New System.Drawing.Point(370, 173)
        Me.btnUpA.Name = "btnUpA"
        Me.btnUpA.Size = New System.Drawing.Size(80, 61)
        Me.btnUpA.TabIndex = 121
        Me.btnUpA.UseVisualStyleBackColor = False
        '
        'btnUpB
        '
        Me.btnUpB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnUpB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnUpB.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpB.ForeColor = System.Drawing.Color.White
        Me.btnUpB.Image = Global.Automission.My.Resources.Resources.arrow_up
        Me.btnUpB.Location = New System.Drawing.Point(632, 172)
        Me.btnUpB.Name = "btnUpB"
        Me.btnUpB.Size = New System.Drawing.Size(80, 61)
        Me.btnUpB.TabIndex = 123
        Me.btnUpB.UseVisualStyleBackColor = False
        '
        'btnDownB
        '
        Me.btnDownB.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDownB.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDownB.Font = New System.Drawing.Font("Verdana", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDownB.ForeColor = System.Drawing.Color.White
        Me.btnDownB.Image = Global.Automission.My.Resources.Resources.arrow_down
        Me.btnDownB.Location = New System.Drawing.Point(522, 172)
        Me.btnDownB.Name = "btnDownB"
        Me.btnDownB.Size = New System.Drawing.Size(80, 61)
        Me.btnDownB.TabIndex = 122
        Me.btnDownB.UseVisualStyleBackColor = False
        '
        'FrmPOSRoomPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(880, 490)
        Me.Controls.Add(Me.btnUpB)
        Me.Controls.Add(Me.btnDownB)
        Me.Controls.Add(Me.btnUpA)
        Me.Controls.Add(Me.btnDownA)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.dgvMethodSet)
        Me.Controls.Add(Me.btnAdded)
        Me.Controls.Add(Me.dgvMethod)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.xlblCustomer_Name)
        Me.Controls.Add(Me.xxMETHOD_LABEL)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpCARD_EXPIRY_DATE)
        Me.Controls.Add(Me.CARD_EXPIRED_DATE)
        Me.Controls.Add(Me.txtCARD_NO)
        Me.Controls.Add(Me.CARD_NO)
        Me.Controls.Add(Me.lblAMOUNT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.xlblCHANGE)
        Me.Controls.Add(Me.lblAMOUNT_APPLIED)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNOTES)
        Me.Controls.Add(Me.dtpRECEIPT_DATE)
        Me.Controls.Add(Me.txtRECEIPT_REF_NO)
        Me.Controls.Add(Me.OR_No)
        Me.Controls.Add(Me.btnSAVE)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.xxlblValue)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSRoomPayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.Text = "Payment"
        CType(Me.dgvMethod, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMethodSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRemove As Button
    Friend WithEvents btnAdded As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents xlblCustomer_Name As Label
    Friend WithEvents dgvMethod As DataGridView
    Friend WithEvents dgvMethodSet As DataGridView
    Friend WithEvents xxMETHOD_LABEL As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dtpCARD_EXPIRY_DATE As DateTimePicker
    Friend WithEvents CARD_EXPIRED_DATE As Label
    Friend WithEvents txtCARD_NO As TextBox
    Friend WithEvents CARD_NO As Label
    Friend WithEvents lblAMOUNT As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents xlblCHANGE As Label
    Friend WithEvents lblAMOUNT_APPLIED As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtNOTES As TextBox
    Friend WithEvents dtpRECEIPT_DATE As DateTimePicker
    Friend WithEvents txtRECEIPT_REF_NO As TextBox
    Friend WithEvents OR_No As Label
    Friend WithEvents btnSAVE As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents xxlblValue As Label
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents btnDownA As Button
    Friend WithEvents btnUpA As Button
    Friend WithEvents btnUpB As Button
    Friend WithEvents btnDownB As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
