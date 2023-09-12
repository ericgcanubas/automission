<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReferenceSettings
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
        Me.xmbMenu = New System.Windows.Forms.ComboBox()
        Me.numNEXT_CODE = New System.Windows.Forms.NumericUpDown()
        Me.numDIGIT_CODE = New System.Windows.Forms.NumericUpDown()
        Me.txtSYMBOL_CODE = New System.Windows.Forms.TextBox()
        Me.chkUSE_YEAR = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.theOutPut = New System.Windows.Forms.Label()
        Me.TheResult = New System.Windows.Forms.Label()
        CType(Me.numNEXT_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDIGIT_CODE, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'xmbMenu
        '
        Me.xmbMenu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.xmbMenu.FormattingEnabled = True
        Me.xmbMenu.Location = New System.Drawing.Point(135, 20)
        Me.xmbMenu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.xmbMenu.Name = "xmbMenu"
        Me.xmbMenu.Size = New System.Drawing.Size(159, 24)
        Me.xmbMenu.TabIndex = 0
        '
        'numNEXT_CODE
        '
        Me.numNEXT_CODE.AccessibleName = "0"
        Me.numNEXT_CODE.Location = New System.Drawing.Point(135, 49)
        Me.numNEXT_CODE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.numNEXT_CODE.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numNEXT_CODE.Name = "numNEXT_CODE"
        Me.numNEXT_CODE.Size = New System.Drawing.Size(160, 23)
        Me.numNEXT_CODE.TabIndex = 1
        '
        'numDIGIT_CODE
        '
        Me.numDIGIT_CODE.AccessibleName = "0"
        Me.numDIGIT_CODE.Location = New System.Drawing.Point(135, 77)
        Me.numDIGIT_CODE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.numDIGIT_CODE.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numDIGIT_CODE.Name = "numDIGIT_CODE"
        Me.numDIGIT_CODE.Size = New System.Drawing.Size(160, 23)
        Me.numDIGIT_CODE.TabIndex = 2
        '
        'txtSYMBOL_CODE
        '
        Me.txtSYMBOL_CODE.Location = New System.Drawing.Point(135, 103)
        Me.txtSYMBOL_CODE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtSYMBOL_CODE.Name = "txtSYMBOL_CODE"
        Me.txtSYMBOL_CODE.Size = New System.Drawing.Size(160, 23)
        Me.txtSYMBOL_CODE.TabIndex = 3
        '
        'chkUSE_YEAR
        '
        Me.chkUSE_YEAR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUSE_YEAR.Location = New System.Drawing.Point(13, 131)
        Me.chkUSE_YEAR.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.chkUSE_YEAR.Name = "chkUSE_YEAR"
        Me.chkUSE_YEAR.Size = New System.Drawing.Size(135, 21)
        Me.chkUSE_YEAR.TabIndex = 4
        Me.chkUSE_YEAR.Text = "Use Year"
        Me.chkUSE_YEAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 23)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Menu Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 51)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 16)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Next Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 80)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 16)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Digit "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 107)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(54, 16)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Symbol"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(190, 205)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(105, 28)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'theOutPut
        '
        Me.theOutPut.AutoSize = True
        Me.theOutPut.Location = New System.Drawing.Point(16, 170)
        Me.theOutPut.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.theOutPut.Name = "theOutPut"
        Me.theOutPut.Size = New System.Drawing.Size(53, 16)
        Me.theOutPut.TabIndex = 10
        Me.theOutPut.Text = "Output"
        '
        'TheResult
        '
        Me.TheResult.AutoSize = True
        Me.TheResult.Location = New System.Drawing.Point(131, 170)
        Me.TheResult.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.TheResult.Name = "TheResult"
        Me.TheResult.Size = New System.Drawing.Size(77, 16)
        Me.TheResult.TabIndex = 11
        Me.TheResult.Text = "#######"
        '
        'FrmReferenceSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(333, 246)
        Me.Controls.Add(Me.TheResult)
        Me.Controls.Add(Me.theOutPut)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkUSE_YEAR)
        Me.Controls.Add(Me.txtSYMBOL_CODE)
        Me.Controls.Add(Me.numDIGIT_CODE)
        Me.Controls.Add(Me.numNEXT_CODE)
        Me.Controls.Add(Me.xmbMenu)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReferenceSettings"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reference Settings"
        CType(Me.numNEXT_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDIGIT_CODE, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents xmbMenu As ComboBox
    Friend WithEvents numNEXT_CODE As NumericUpDown
    Friend WithEvents numDIGIT_CODE As NumericUpDown
    Friend WithEvents txtSYMBOL_CODE As TextBox
    Friend WithEvents chkUSE_YEAR As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents theOutPut As Label
    Friend WithEvents TheResult As Label
End Class
