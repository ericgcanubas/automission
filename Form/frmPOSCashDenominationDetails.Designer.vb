<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSCashDenominationDetails
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
        Me.txtCODE = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numNOMINAL_VALUE = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.chkINACTIVE = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.numNOMINAL_VALUE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(82, 19)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Code"
        '
        'txtCODE
        '
        Me.txtCODE.Location = New System.Drawing.Point(126, 16)
        Me.txtCODE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtCODE.Name = "txtCODE"
        Me.txtCODE.Size = New System.Drawing.Size(159, 23)
        Me.txtCODE.TabIndex = 1
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(126, 44)
        Me.txtDESCRIPTION.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(356, 23)
        Me.txtDESCRIPTION.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(42, 46)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(25, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Nominal Value"
        '
        'numNOMINAL_VALUE
        '
        Me.numNOMINAL_VALUE.DecimalPlaces = 2
        Me.numNOMINAL_VALUE.Location = New System.Drawing.Point(126, 72)
        Me.numNOMINAL_VALUE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.numNOMINAL_VALUE.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 0})
        Me.numNOMINAL_VALUE.Name = "numNOMINAL_VALUE"
        Me.numNOMINAL_VALUE.Size = New System.Drawing.Size(160, 23)
        Me.numNOMINAL_VALUE.TabIndex = 5
        Me.numNOMINAL_VALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.numNOMINAL_VALUE.ThousandsSeparator = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(83, 103)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Type"
        '
        'cmbTYPE
        '
        Me.cmbTYPE.AccessibleDescription = "0"
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(126, 100)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(159, 24)
        Me.cmbTYPE.TabIndex = 7
        '
        'chkINACTIVE
        '
        Me.chkINACTIVE.AutoSize = True
        Me.chkINACTIVE.BackColor = System.Drawing.Color.Transparent
        Me.chkINACTIVE.Location = New System.Drawing.Point(126, 131)
        Me.chkINACTIVE.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkINACTIVE.Name = "chkINACTIVE"
        Me.chkINACTIVE.Size = New System.Drawing.Size(80, 20)
        Me.chkINACTIVE.TabIndex = 8
        Me.chkINACTIVE.Text = "Inactive"
        Me.chkINACTIVE.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(303, 131)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 11
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(396, 131)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 12
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmPOSCashDenominationDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 174)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkINACTIVE)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numNOMINAL_VALUE)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCODE)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSCashDenominationDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Denomination Details"
        CType(Me.numNOMINAL_VALUE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtCODE As TextBox
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents numNOMINAL_VALUE As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents chkINACTIVE As CheckBox
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
End Class
