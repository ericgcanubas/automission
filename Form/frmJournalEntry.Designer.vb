<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmJournalEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJournalEntry))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbAccounts = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numDebit = New System.Windows.Forms.NumericUpDown()
        Me.numCredit = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNotes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbClass = New System.Windows.Forms.ComboBox()
        Me.chkAuto = New System.Windows.Forms.CheckBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ThisType = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numDebit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCredit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(19, 26)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account"
        '
        'cmbAccounts
        '
        Me.cmbAccounts.FormattingEnabled = True
        Me.cmbAccounts.Location = New System.Drawing.Point(82, 23)
        Me.cmbAccounts.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbAccounts.Name = "cmbAccounts"
        Me.cmbAccounts.Size = New System.Drawing.Size(380, 24)
        Me.cmbAccounts.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(37, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Debit"
        '
        'numDebit
        '
        Me.numDebit.DecimalPlaces = 2
        Me.numDebit.Location = New System.Drawing.Point(82, 75)
        Me.numDebit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numDebit.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numDebit.Name = "numDebit"
        Me.numDebit.Size = New System.Drawing.Size(160, 23)
        Me.numDebit.TabIndex = 3
        Me.numDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numDebit.ThousandsSeparator = True
        '
        'numCredit
        '
        Me.numCredit.DecimalPlaces = 2
        Me.numCredit.Location = New System.Drawing.Point(336, 75)
        Me.numCredit.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numCredit.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numCredit.Name = "numCredit"
        Me.numCredit.Size = New System.Drawing.Size(160, 23)
        Me.numCredit.TabIndex = 5
        Me.numCredit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numCredit.ThousandsSeparator = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(284, 79)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Credit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(9, 106)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Particular"
        '
        'txtNotes
        '
        Me.txtNotes.Location = New System.Drawing.Point(82, 102)
        Me.txtNotes.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtNotes.Multiline = True
        Me.txtNotes.Name = "txtNotes"
        Me.txtNotes.Size = New System.Drawing.Size(413, 58)
        Me.txtNotes.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(35, 166)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 16)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Class"
        '
        'cmbClass
        '
        Me.cmbClass.FormattingEnabled = True
        Me.cmbClass.Location = New System.Drawing.Point(82, 162)
        Me.cmbClass.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbClass.Name = "cmbClass"
        Me.cmbClass.Size = New System.Drawing.Size(413, 24)
        Me.cmbClass.TabIndex = 9
        '
        'chkAuto
        '
        Me.chkAuto.AutoSize = True
        Me.chkAuto.BackColor = System.Drawing.Color.Transparent
        Me.chkAuto.Location = New System.Drawing.Point(82, 197)
        Me.chkAuto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkAuto.Name = "chkAuto"
        Me.chkAuto.Size = New System.Drawing.Size(98, 20)
        Me.chkAuto.TabIndex = 12
        Me.chkAuto.Text = "Add && New"
        Me.chkAuto.UseVisualStyleBackColor = False
        Me.chkAuto.Visible = False
        '
        'btnBrowse
        '
        Me.btnBrowse.BackColor = System.Drawing.Color.Transparent
        Me.btnBrowse.BackgroundImage = CType(resources.GetObject("btnBrowse.BackgroundImage"), System.Drawing.Image)
        Me.btnBrowse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrowse.Location = New System.Drawing.Point(464, 23)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(32, 26)
        Me.btnBrowse.TabIndex = 76
        Me.btnBrowse.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(40, 51)
        Me.Label6.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 16)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Type"
        '
        'ThisType
        '
        Me.ThisType.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ThisType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ThisType.Location = New System.Drawing.Point(82, 50)
        Me.ThisType.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.ThisType.Name = "ThisType"
        Me.ThisType.Size = New System.Drawing.Size(413, 23)
        Me.ThisType.TabIndex = 78
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(318, 197)
        Me.btnOk.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(86, 28)
        Me.btnOk.TabIndex = 79
        Me.btnOk.Text = "&OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(410, 197)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 80
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmJournalEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 234)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.ThisType)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.chkAuto)
        Me.Controls.Add(Me.cmbClass)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtNotes)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numCredit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.numDebit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbAccounts)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmJournalEntry"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Journal Entry"
        CType(Me.numDebit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCredit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbAccounts As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents numDebit As NumericUpDown
    Friend WithEvents numCredit As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNotes As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbClass As ComboBox
    Friend WithEvents chkAuto As CheckBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents ThisType As Label
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
End Class
