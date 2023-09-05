<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuSettingsSetup
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkVisible = New System.Windows.Forms.CheckBox()
        Me.btnCancel1 = New System.Windows.Forms.Button()
        Me.btnSave1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbImage1 = New System.Windows.Forms.ComboBox()
        Me.txtDescription1 = New System.Windows.Forms.TextBox()
        Me.numID1 = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.chkModal = New System.Windows.Forms.CheckBox()
        Me.chkAccess_Control = New System.Windows.Forms.CheckBox()
        Me.btnCancel2 = New System.Windows.Forms.Button()
        Me.btnSave2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbImage2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbForm = New System.Windows.Forms.ComboBox()
        Me.txtDescription2 = New System.Windows.Forms.TextBox()
        Me.numID2 = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numID1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numID2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkVisible)
        Me.GroupBox1.Controls.Add(Me.btnCancel1)
        Me.GroupBox1.Controls.Add(Me.btnSave1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbImage1)
        Me.GroupBox1.Controls.Add(Me.txtDescription1)
        Me.GroupBox1.Controls.Add(Me.numID1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(649, 126)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Main Menu"
        '
        'chkVisible
        '
        Me.chkVisible.AutoSize = True
        Me.chkVisible.Location = New System.Drawing.Point(91, 90)
        Me.chkVisible.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkVisible.Name = "chkVisible"
        Me.chkVisible.Size = New System.Drawing.Size(84, 20)
        Me.chkVisible.TabIndex = 8
        Me.chkVisible.Text = "Is Visible"
        Me.chkVisible.UseVisualStyleBackColor = True
        '
        'btnCancel1
        '
        Me.btnCancel1.Location = New System.Drawing.Point(528, 81)
        Me.btnCancel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel1.Name = "btnCancel1"
        Me.btnCancel1.Size = New System.Drawing.Size(99, 34)
        Me.btnCancel1.TabIndex = 7
        Me.btnCancel1.Text = "Cancel"
        Me.btnCancel1.UseVisualStyleBackColor = True
        '
        'btnSave1
        '
        Me.btnSave1.Location = New System.Drawing.Point(419, 81)
        Me.btnSave1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave1.Name = "btnSave1"
        Me.btnSave1.Size = New System.Drawing.Size(99, 34)
        Me.btnSave1.TabIndex = 6
        Me.btnSave1.Text = "Save"
        Me.btnSave1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(378, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Image File"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(88, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Description"
        '
        'cmbImage1
        '
        Me.cmbImage1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImage1.FormattingEnabled = True
        Me.cmbImage1.Location = New System.Drawing.Point(383, 48)
        Me.cmbImage1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbImage1.Name = "cmbImage1"
        Me.cmbImage1.Size = New System.Drawing.Size(244, 24)
        Me.cmbImage1.TabIndex = 3
        '
        'txtDescription1
        '
        Me.txtDescription1.Location = New System.Drawing.Point(91, 47)
        Me.txtDescription1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescription1.Name = "txtDescription1"
        Me.txtDescription1.Size = New System.Drawing.Size(282, 23)
        Me.txtDescription1.TabIndex = 2
        '
        'numID1
        '
        Me.numID1.Location = New System.Drawing.Point(11, 48)
        Me.numID1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numID1.Name = "numID1"
        Me.numID1.Size = New System.Drawing.Size(72, 23)
        Me.numID1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkActive)
        Me.GroupBox2.Controls.Add(Me.chkModal)
        Me.GroupBox2.Controls.Add(Me.chkAccess_Control)
        Me.GroupBox2.Controls.Add(Me.btnCancel2)
        Me.GroupBox2.Controls.Add(Me.btnSave2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.cmbImage2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbForm)
        Me.GroupBox2.Controls.Add(Me.txtDescription2)
        Me.GroupBox2.Controls.Add(Me.numID2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 156)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(899, 126)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sub Menu"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Location = New System.Drawing.Point(11, 90)
        Me.chkActive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(84, 20)
        Me.chkActive.TabIndex = 18
        Me.chkActive.Text = "Is active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'chkModal
        '
        Me.chkModal.AutoSize = True
        Me.chkModal.Location = New System.Drawing.Point(383, 90)
        Me.chkModal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkModal.Name = "chkModal"
        Me.chkModal.Size = New System.Drawing.Size(129, 20)
        Me.chkModal.TabIndex = 17
        Me.chkModal.Text = "On Top Window"
        Me.chkModal.UseVisualStyleBackColor = True
        '
        'chkAccess_Control
        '
        Me.chkAccess_Control.AutoSize = True
        Me.chkAccess_Control.Location = New System.Drawing.Point(187, 90)
        Me.chkAccess_Control.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkAccess_Control.Name = "chkAccess_Control"
        Me.chkAccess_Control.Size = New System.Drawing.Size(125, 20)
        Me.chkAccess_Control.TabIndex = 16
        Me.chkAccess_Control.Text = "Access Control"
        Me.chkAccess_Control.UseVisualStyleBackColor = True
        '
        'btnCancel2
        '
        Me.btnCancel2.Location = New System.Drawing.Point(782, 86)
        Me.btnCancel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(99, 33)
        Me.btnCancel2.TabIndex = 15
        Me.btnCancel2.Text = "Cancel"
        Me.btnCancel2.UseVisualStyleBackColor = True
        '
        'btnSave2
        '
        Me.btnSave2.Location = New System.Drawing.Point(673, 86)
        Me.btnSave2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave2.Name = "btnSave2"
        Me.btnSave2.Size = New System.Drawing.Size(99, 33)
        Me.btnSave2.TabIndex = 14
        Me.btnSave2.Text = "Save"
        Me.btnSave2.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(632, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Image File"
        '
        'cmbImage2
        '
        Me.cmbImage2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbImage2.DropDownWidth = 50
        Me.cmbImage2.FormattingEnabled = True
        Me.cmbImage2.Location = New System.Drawing.Point(635, 52)
        Me.cmbImage2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbImage2.Name = "cmbImage2"
        Me.cmbImage2.Size = New System.Drawing.Size(244, 24)
        Me.cmbImage2.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(378, 31)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 16)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Form Module"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(88, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Description"
        '
        'cmbForm
        '
        Me.cmbForm.AllowDrop = True
        Me.cmbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbForm.DropDownWidth = 50
        Me.cmbForm.FormattingEnabled = True
        Me.cmbForm.Location = New System.Drawing.Point(383, 50)
        Me.cmbForm.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbForm.Name = "cmbForm"
        Me.cmbForm.Size = New System.Drawing.Size(244, 24)
        Me.cmbForm.TabIndex = 9
        '
        'txtDescription2
        '
        Me.txtDescription2.Location = New System.Drawing.Point(91, 49)
        Me.txtDescription2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtDescription2.Name = "txtDescription2"
        Me.txtDescription2.Size = New System.Drawing.Size(282, 23)
        Me.txtDescription2.TabIndex = 8
        '
        'numID2
        '
        Me.numID2.Location = New System.Drawing.Point(11, 50)
        Me.numID2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.numID2.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numID2.Name = "numID2"
        Me.numID2.Size = New System.Drawing.Size(72, 23)
        Me.numID2.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 16)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "ID"
        '
        'frmMenuSettingsSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(935, 297)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMenuSettingsSetup"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu Settings Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numID1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numID2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnCancel1 As Button
    Friend WithEvents btnSave1 As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbImage1 As ComboBox
    Friend WithEvents txtDescription1 As TextBox
    Friend WithEvents numID1 As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnCancel2 As Button
    Friend WithEvents btnSave2 As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbImage2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbForm As ComboBox
    Friend WithEvents txtDescription2 As TextBox
    Friend WithEvents numID2 As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents chkAccess_Control As CheckBox
    Friend WithEvents chkModal As CheckBox
    Friend WithEvents chkVisible As CheckBox
    Friend WithEvents chkActive As CheckBox
End Class
