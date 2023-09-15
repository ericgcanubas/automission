<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSPayment
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
        Me.txtCARD_NO = New System.Windows.Forms.TextBox()
        Me.lbslCARD_NO = New System.Windows.Forms.Label()
        Me.txtPAYMENT_REF_NO = New System.Windows.Forms.TextBox()
        Me.lbslREF_No = New System.Windows.Forms.Label()
        Me.cmbPAYMENT_METHOD_ID = New System.Windows.Forms.ComboBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numAMOUNT = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rtbNOTES = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.xxxTOTAL = New System.Windows.Forms.Label()
        Me.xxxxCHANGE = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BunifuSeparator1 = New Bunifu.Framework.UI.BunifuSeparator()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCARD_NO
        '
        Me.txtCARD_NO.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCARD_NO.Location = New System.Drawing.Point(252, 259)
        Me.txtCARD_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtCARD_NO.Name = "txtCARD_NO"
        Me.txtCARD_NO.Size = New System.Drawing.Size(224, 27)
        Me.txtCARD_NO.TabIndex = 3
        '
        'lbslCARD_NO
        '
        Me.lbslCARD_NO.BackColor = System.Drawing.Color.Transparent
        Me.lbslCARD_NO.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbslCARD_NO.ForeColor = System.Drawing.Color.Black
        Me.lbslCARD_NO.Location = New System.Drawing.Point(12, 260)
        Me.lbslCARD_NO.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbslCARD_NO.Name = "lbslCARD_NO"
        Me.lbslCARD_NO.Size = New System.Drawing.Size(237, 26)
        Me.lbslCARD_NO.TabIndex = 8
        Me.lbslCARD_NO.Text = "CARD No."
        Me.lbslCARD_NO.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPAYMENT_REF_NO
        '
        Me.txtPAYMENT_REF_NO.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPAYMENT_REF_NO.Location = New System.Drawing.Point(252, 224)
        Me.txtPAYMENT_REF_NO.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPAYMENT_REF_NO.Name = "txtPAYMENT_REF_NO"
        Me.txtPAYMENT_REF_NO.Size = New System.Drawing.Size(224, 31)
        Me.txtPAYMENT_REF_NO.TabIndex = 2
        '
        'lbslREF_No
        '
        Me.lbslREF_No.BackColor = System.Drawing.Color.Transparent
        Me.lbslREF_No.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbslREF_No.Location = New System.Drawing.Point(8, 223)
        Me.lbslREF_No.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lbslREF_No.Name = "lbslREF_No"
        Me.lbslREF_No.Size = New System.Drawing.Size(242, 31)
        Me.lbslREF_No.TabIndex = 6
        Me.lbslREF_No.Text = "O.R No."
        Me.lbslREF_No.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbPAYMENT_METHOD_ID
        '
        Me.cmbPAYMENT_METHOD_ID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPAYMENT_METHOD_ID.FormattingEnabled = True
        Me.cmbPAYMENT_METHOD_ID.Location = New System.Drawing.Point(298, 23)
        Me.cmbPAYMENT_METHOD_ID.Margin = New System.Windows.Forms.Padding(4)
        Me.cmbPAYMENT_METHOD_ID.Name = "cmbPAYMENT_METHOD_ID"
        Me.cmbPAYMENT_METHOD_ID.Size = New System.Drawing.Size(170, 26)
        Me.cmbPAYMENT_METHOD_ID.TabIndex = 3
        Me.cmbPAYMENT_METHOD_ID.Visible = False
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.DimGray
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(8, 56)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(469, 163)
        Me.FlowLayoutPanel1.TabIndex = 93
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(219, 33)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Tender"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'numAMOUNT
        '
        Me.numAMOUNT.DecimalPlaces = 2
        Me.numAMOUNT.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numAMOUNT.Location = New System.Drawing.Point(252, 359)
        Me.numAMOUNT.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.numAMOUNT.Name = "numAMOUNT"
        Me.numAMOUNT.Size = New System.Drawing.Size(224, 40)
        Me.numAMOUNT.TabIndex = 1
        Me.numAMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numAMOUNT.ThousandsSeparator = True
        Me.numAMOUNT.Value = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.numAMOUNT.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 2)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "NOTES :"
        '
        'rtbNOTES
        '
        Me.rtbNOTES.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.rtbNOTES.Location = New System.Drawing.Point(8, 18)
        Me.rtbNOTES.Name = "rtbNOTES"
        Me.rtbNOTES.Size = New System.Drawing.Size(469, 34)
        Me.rtbNOTES.TabIndex = 100
        Me.rtbNOTES.Text = ""
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 318)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(219, 33)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "Total"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xxxTOTAL
        '
        Me.xxxTOTAL.BackColor = System.Drawing.Color.Black
        Me.xxxTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xxxTOTAL.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxTOTAL.ForeColor = System.Drawing.Color.Lime
        Me.xxxTOTAL.Location = New System.Drawing.Point(252, 312)
        Me.xxxTOTAL.Name = "xxxTOTAL"
        Me.xxxTOTAL.Size = New System.Drawing.Size(224, 44)
        Me.xxxTOTAL.TabIndex = 102
        Me.xxxTOTAL.Text = "0.00"
        Me.xxxTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'xxxxCHANGE
        '
        Me.xxxxCHANGE.BackColor = System.Drawing.Color.Black
        Me.xxxxCHANGE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xxxxCHANGE.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xxxxCHANGE.ForeColor = System.Drawing.Color.Yellow
        Me.xxxxCHANGE.Location = New System.Drawing.Point(251, 395)
        Me.xxxxCHANGE.Name = "xxxxCHANGE"
        Me.xxxxCHANGE.Size = New System.Drawing.Size(225, 48)
        Me.xxxxCHANGE.TabIndex = 104
        Me.xxxxCHANGE.Text = "0.00"
        Me.xxxxCHANGE.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(30, 403)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(219, 33)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Change"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BunifuSeparator1
        '
        Me.BunifuSeparator1.BackColor = System.Drawing.Color.Transparent
        Me.BunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.BunifuSeparator1.LineThickness = 1
        Me.BunifuSeparator1.Location = New System.Drawing.Point(75, 290)
        Me.BunifuSeparator1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.BunifuSeparator1.Name = "BunifuSeparator1"
        Me.BunifuSeparator1.Size = New System.Drawing.Size(402, 24)
        Me.BunifuSeparator1.TabIndex = 105
        Me.BunifuSeparator1.Transparency = 255
        Me.BunifuSeparator1.Vertical = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOK.Location = New System.Drawing.Point(252, 449)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(98, 55)
        Me.btnOK.TabIndex = 106
        Me.btnOK.Text = "&Save"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(378, 449)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(98, 55)
        Me.btnCancel.TabIndex = 107
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(12, 449)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(98, 55)
        Me.btnDelete.TabIndex = 108
        Me.btnDelete.Text = "&Remove"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'FrmPOSPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(481, 513)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.xxxxCHANGE)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.xxxTOTAL)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rtbNOTES)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numAMOUNT)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCARD_NO)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.lbslCARD_NO)
        Me.Controls.Add(Me.txtPAYMENT_REF_NO)
        Me.Controls.Add(Me.lbslREF_No)
        Me.Controls.Add(Me.cmbPAYMENT_METHOD_ID)
        Me.Controls.Add(Me.BunifuSeparator1)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSPayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment"
        CType(Me.numAMOUNT, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtCARD_NO As TextBox
    Friend WithEvents lbslCARD_NO As Label
    Friend WithEvents txtPAYMENT_REF_NO As TextBox
    Friend WithEvents lbslREF_No As Label
    Friend WithEvents cmbPAYMENT_METHOD_ID As ComboBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents numAMOUNT As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents rtbNOTES As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents xxxTOTAL As Label
    Friend WithEvents xxxxCHANGE As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BunifuSeparator1 As Bunifu.Framework.UI.BunifuSeparator
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnDelete As Button
End Class
