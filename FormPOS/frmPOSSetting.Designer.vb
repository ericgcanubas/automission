<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSSetting
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
        Me.xnumID = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNAME = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbACCOUNT_ID = New System.Windows.Forms.ComboBox()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.numNEXT_RECEIPT_NO = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPOS_PERMIT_NO = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numNEXT_LOG_SERIAL_NO = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.numNO_OF_DIGITS = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numRESTAURANT_TABLE_NO = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbDINE_IN_ID = New System.Windows.Forms.ComboBox()
        Me.cmbTAKE_OUT_ID = New System.Windows.Forms.ComboBox()
        Me.cmbDELIVERY_ID = New System.Windows.Forms.ComboBox()
        Me.chkRESTO_SERVED_ONLY = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        CType(Me.xnumID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNEXT_RECEIPT_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNEXT_LOG_SERIAL_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNO_OF_DIGITS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numRESTAURANT_TABLE_NO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 17)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POS Machine No."
        '
        'xnumID
        '
        Me.xnumID.Location = New System.Drawing.Point(163, 14)
        Me.xnumID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.xnumID.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.xnumID.Name = "xnumID"
        Me.xnumID.Size = New System.Drawing.Size(99, 23)
        Me.xnumID.TabIndex = 1
        Me.xnumID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 44)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Name"
        '
        'txtNAME
        '
        Me.txtNAME.Location = New System.Drawing.Point(163, 41)
        Me.txtNAME.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNAME.MaxLength = 50
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(319, 23)
        Me.txtNAME.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 70)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Type"
        '
        'cmbTYPE
        '
        Me.cmbTYPE.AccessibleDescription = "0"
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(163, 66)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(319, 24)
        Me.cmbTYPE.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 97)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Account "
        '
        'cmbACCOUNT_ID
        '
        Me.cmbACCOUNT_ID.FormattingEnabled = True
        Me.cmbACCOUNT_ID.Location = New System.Drawing.Point(163, 94)
        Me.cmbACCOUNT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbACCOUNT_ID.Name = "cmbACCOUNT_ID"
        Me.cmbACCOUNT_ID.Size = New System.Drawing.Size(419, 24)
        Me.cmbACCOUNT_ID.TabIndex = 7
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkINACTIVE.Location = New System.Drawing.Point(409, 314)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(96, 20)
        Me.chkINACTIVE.TabIndex = 8
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = True
        '
        'numNEXT_RECEIPT_NO
        '
        Me.numNEXT_RECEIPT_NO.Location = New System.Drawing.Point(163, 121)
        Me.numNEXT_RECEIPT_NO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numNEXT_RECEIPT_NO.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numNEXT_RECEIPT_NO.Name = "numNEXT_RECEIPT_NO"
        Me.numNEXT_RECEIPT_NO.Size = New System.Drawing.Size(208, 23)
        Me.numNEXT_RECEIPT_NO.TabIndex = 10
        Me.numNEXT_RECEIPT_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 123)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 16)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Next Receipt No."
        '
        'txtPOS_PERMIT_NO
        '
        Me.txtPOS_PERMIT_NO.Location = New System.Drawing.Point(163, 172)
        Me.txtPOS_PERMIT_NO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtPOS_PERMIT_NO.MaxLength = 50
        Me.txtPOS_PERMIT_NO.Name = "txtPOS_PERMIT_NO"
        Me.txtPOS_PERMIT_NO.Size = New System.Drawing.Size(319, 23)
        Me.txtPOS_PERMIT_NO.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 171)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 16)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "POS Permit No."
        '
        'numNEXT_LOG_SERIAL_NO
        '
        Me.numNEXT_LOG_SERIAL_NO.Location = New System.Drawing.Point(163, 199)
        Me.numNEXT_LOG_SERIAL_NO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numNEXT_LOG_SERIAL_NO.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numNEXT_LOG_SERIAL_NO.Name = "numNEXT_LOG_SERIAL_NO"
        Me.numNEXT_LOG_SERIAL_NO.Size = New System.Drawing.Size(208, 23)
        Me.numNEXT_LOG_SERIAL_NO.TabIndex = 18
        Me.numNEXT_LOG_SERIAL_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 202)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Next Log Serial No."
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(374, 372)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(101, 28)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(482, 372)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(101, 28)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'numNO_OF_DIGITS
        '
        Me.numNO_OF_DIGITS.Location = New System.Drawing.Point(163, 146)
        Me.numNO_OF_DIGITS.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numNO_OF_DIGITS.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numNO_OF_DIGITS.Name = "numNO_OF_DIGITS"
        Me.numNO_OF_DIGITS.Size = New System.Drawing.Size(208, 23)
        Me.numNO_OF_DIGITS.TabIndex = 12
        Me.numNO_OF_DIGITS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 146)
        Me.Label8.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(85, 16)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "No Of Digits"
        '
        'numRESTAURANT_TABLE_NO
        '
        Me.numRESTAURANT_TABLE_NO.Location = New System.Drawing.Point(163, 228)
        Me.numRESTAURANT_TABLE_NO.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numRESTAURANT_TABLE_NO.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numRESTAURANT_TABLE_NO.Name = "numRESTAURANT_TABLE_NO"
        Me.numRESTAURANT_TABLE_NO.Size = New System.Drawing.Size(99, 23)
        Me.numRESTAURANT_TABLE_NO.TabIndex = 20
        Me.numRESTAURANT_TABLE_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 230)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(139, 16)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Dine-in table count "
        '
        'cmbDINE_IN_ID
        '
        Me.cmbDINE_IN_ID.FormattingEnabled = True
        Me.cmbDINE_IN_ID.Location = New System.Drawing.Point(163, 254)
        Me.cmbDINE_IN_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDINE_IN_ID.Name = "cmbDINE_IN_ID"
        Me.cmbDINE_IN_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbDINE_IN_ID.TabIndex = 22
        '
        'cmbTAKE_OUT_ID
        '
        Me.cmbTAKE_OUT_ID.FormattingEnabled = True
        Me.cmbTAKE_OUT_ID.Location = New System.Drawing.Point(163, 281)
        Me.cmbTAKE_OUT_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTAKE_OUT_ID.Name = "cmbTAKE_OUT_ID"
        Me.cmbTAKE_OUT_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbTAKE_OUT_ID.TabIndex = 24
        '
        'cmbDELIVERY_ID
        '
        Me.cmbDELIVERY_ID.FormattingEnabled = True
        Me.cmbDELIVERY_ID.Location = New System.Drawing.Point(163, 308)
        Me.cmbDELIVERY_ID.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbDELIVERY_ID.Name = "cmbDELIVERY_ID"
        Me.cmbDELIVERY_ID.Size = New System.Drawing.Size(207, 24)
        Me.cmbDELIVERY_ID.TabIndex = 26
        '
        'chkRESTO_SERVED_ONLY
        '
        Me.chkRESTO_SERVED_ONLY.AutoSize = True
        Me.chkRESTO_SERVED_ONLY.Location = New System.Drawing.Point(269, 229)
        Me.chkRESTO_SERVED_ONLY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.chkRESTO_SERVED_ONLY.Name = "chkRESTO_SERVED_ONLY"
        Me.chkRESTO_SERVED_ONLY.Size = New System.Drawing.Size(106, 20)
        Me.chkRESTO_SERVED_ONLY.TabIndex = 27
        Me.chkRESTO_SERVED_ONLY.Text = "Served Only"
        Me.chkRESTO_SERVED_ONLY.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 311)
        Me.Label12.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 16)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Delivery Link"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 284)
        Me.Label11.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 16)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Take-Out Link"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 257)
        Me.Label10.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 16)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Dine-In Link"
        '
        'FrmPOSSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 410)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkRESTO_SERVED_ONLY)
        Me.Controls.Add(Me.cmbDELIVERY_ID)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.cmbTAKE_OUT_ID)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbDINE_IN_ID)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.numRESTAURANT_TABLE_NO)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.numNO_OF_DIGITS)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numNEXT_LOG_SERIAL_NO)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtPOS_PERMIT_NO)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numNEXT_RECEIPT_NO)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.cmbACCOUNT_ID)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtNAME)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.xnumID)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSSetting"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Setting"
        CType(Me.xnumID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNEXT_RECEIPT_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNEXT_LOG_SERIAL_NO, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNO_OF_DIGITS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numRESTAURANT_TABLE_NO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents xnumID As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNAME As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbACCOUNT_ID As ComboBox
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents numNEXT_RECEIPT_NO As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPOS_PERMIT_NO As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents numNEXT_LOG_SERIAL_NO As NumericUpDown
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents numNO_OF_DIGITS As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents numRESTAURANT_TABLE_NO As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents cmbDINE_IN_ID As ComboBox
    Friend WithEvents cmbTAKE_OUT_ID As ComboBox
    Friend WithEvents cmbDELIVERY_ID As ComboBox
    Friend WithEvents chkRESTO_SERVED_ONLY As CheckBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
End Class
