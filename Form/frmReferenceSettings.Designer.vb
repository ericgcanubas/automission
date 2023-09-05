<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReferenceSettings
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
        Me.xmbMenu.Location = New System.Drawing.Point(101, 16)
        Me.xmbMenu.Name = "xmbMenu"
        Me.xmbMenu.Size = New System.Drawing.Size(120, 21)
        Me.xmbMenu.TabIndex = 0
        '
        'numNEXT_CODE
        '
        Me.numNEXT_CODE.AccessibleName = "0"
        Me.numNEXT_CODE.Location = New System.Drawing.Point(101, 43)
        Me.numNEXT_CODE.Maximum = New Decimal(New Integer() {1410065407, 2, 0, 0})
        Me.numNEXT_CODE.Name = "numNEXT_CODE"
        Me.numNEXT_CODE.Size = New System.Drawing.Size(120, 22)
        Me.numNEXT_CODE.TabIndex = 1
        '
        'numDIGIT_CODE
        '
        Me.numDIGIT_CODE.AccessibleName = "0"
        Me.numDIGIT_CODE.Location = New System.Drawing.Point(101, 71)
        Me.numDIGIT_CODE.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numDIGIT_CODE.Name = "numDIGIT_CODE"
        Me.numDIGIT_CODE.Size = New System.Drawing.Size(120, 22)
        Me.numDIGIT_CODE.TabIndex = 2
        '
        'txtSYMBOL_CODE
        '
        Me.txtSYMBOL_CODE.Location = New System.Drawing.Point(101, 99)
        Me.txtSYMBOL_CODE.Name = "txtSYMBOL_CODE"
        Me.txtSYMBOL_CODE.Size = New System.Drawing.Size(100, 22)
        Me.txtSYMBOL_CODE.TabIndex = 3
        '
        'chkUSE_YEAR
        '
        Me.chkUSE_YEAR.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkUSE_YEAR.Location = New System.Drawing.Point(15, 127)
        Me.chkUSE_YEAR.Name = "chkUSE_YEAR"
        Me.chkUSE_YEAR.Size = New System.Drawing.Size(101, 17)
        Me.chkUSE_YEAR.TabIndex = 4
        Me.chkUSE_YEAR.Text = "Use Year"
        Me.chkUSE_YEAR.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Menu Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Next Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Digit "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Symbol"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(101, 189)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(120, 23)
        Me.btnSave.TabIndex = 9
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'theOutPut
        '
        Me.theOutPut.AutoSize = True
        Me.theOutPut.Location = New System.Drawing.Point(12, 161)
        Me.theOutPut.Name = "theOutPut"
        Me.theOutPut.Size = New System.Drawing.Size(45, 13)
        Me.theOutPut.TabIndex = 10
        Me.theOutPut.Text = "Output"
        '
        'TheResult
        '
        Me.TheResult.AutoSize = True
        Me.TheResult.Location = New System.Drawing.Point(98, 161)
        Me.TheResult.Name = "TheResult"
        Me.TheResult.Size = New System.Drawing.Size(56, 13)
        Me.TheResult.TabIndex = 11
        Me.TheResult.Text = "#######"
        '
        'frmReferenceSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(250, 224)
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
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReferenceSettings"
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
