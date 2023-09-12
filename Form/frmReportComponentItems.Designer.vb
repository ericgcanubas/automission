<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportComponentItems
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
        Me.cmbTYPE = New System.Windows.Forms.ComboBox()
        Me.txtNAME = New System.Windows.Forms.TextBox()
        Me.rtbSQL_STATEMENT = New System.Windows.Forms.RichTextBox()
        Me.txtVALUE_NAME = New System.Windows.Forms.TextBox()
        Me.txtDISPLAY_NAME = New System.Windows.Forms.TextBox()
        Me.cmbPARAMETER_ID1 = New System.Windows.Forms.ComboBox()
        Me.txtREPORT_PARAMETER_NAME = New System.Windows.Forms.TextBox()
        Me.btnSAVE = New System.Windows.Forms.Button()
        Me.btnCANCEL = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDEFAULT_VALUE = New System.Windows.Forms.TextBox()
        Me.txtVARIABLE_NAME1 = New System.Windows.Forms.TextBox()
        Me.txtVARIABLE_NAME2 = New System.Windows.Forms.TextBox()
        Me.cmbPARAMETER_ID2 = New System.Windows.Forms.ComboBox()
        Me.txtVARIABLE_NAME3 = New System.Windows.Forms.TextBox()
        Me.cmbPARAMETER_ID3 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'cmbTYPE
        '
        Me.cmbTYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTYPE.FormattingEnabled = True
        Me.cmbTYPE.Location = New System.Drawing.Point(197, 15)
        Me.cmbTYPE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(415, 24)
        Me.cmbTYPE.TabIndex = 0
        '
        'txtNAME
        '
        Me.txtNAME.Location = New System.Drawing.Point(197, 48)
        Me.txtNAME.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(415, 23)
        Me.txtNAME.TabIndex = 1
        '
        'rtbSQL_STATEMENT
        '
        Me.rtbSQL_STATEMENT.Location = New System.Drawing.Point(197, 82)
        Me.rtbSQL_STATEMENT.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rtbSQL_STATEMENT.Name = "rtbSQL_STATEMENT"
        Me.rtbSQL_STATEMENT.Size = New System.Drawing.Size(415, 117)
        Me.rtbSQL_STATEMENT.TabIndex = 2
        Me.rtbSQL_STATEMENT.Text = ""
        '
        'txtVALUE_NAME
        '
        Me.txtVALUE_NAME.Location = New System.Drawing.Point(197, 208)
        Me.txtVALUE_NAME.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVALUE_NAME.Name = "txtVALUE_NAME"
        Me.txtVALUE_NAME.Size = New System.Drawing.Size(252, 23)
        Me.txtVALUE_NAME.TabIndex = 3
        '
        'txtDISPLAY_NAME
        '
        Me.txtDISPLAY_NAME.Location = New System.Drawing.Point(197, 240)
        Me.txtDISPLAY_NAME.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDISPLAY_NAME.Name = "txtDISPLAY_NAME"
        Me.txtDISPLAY_NAME.Size = New System.Drawing.Size(415, 23)
        Me.txtDISPLAY_NAME.TabIndex = 4
        '
        'cmbPARAMETER_ID1
        '
        Me.cmbPARAMETER_ID1.FormattingEnabled = True
        Me.cmbPARAMETER_ID1.Location = New System.Drawing.Point(197, 306)
        Me.cmbPARAMETER_ID1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPARAMETER_ID1.Name = "cmbPARAMETER_ID1"
        Me.cmbPARAMETER_ID1.Size = New System.Drawing.Size(252, 24)
        Me.cmbPARAMETER_ID1.TabIndex = 5
        Me.cmbPARAMETER_ID1.Tag = "0"
        '
        'txtREPORT_PARAMETER_NAME
        '
        Me.txtREPORT_PARAMETER_NAME.Location = New System.Drawing.Point(197, 272)
        Me.txtREPORT_PARAMETER_NAME.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtREPORT_PARAMETER_NAME.Name = "txtREPORT_PARAMETER_NAME"
        Me.txtREPORT_PARAMETER_NAME.Size = New System.Drawing.Size(415, 23)
        Me.txtREPORT_PARAMETER_NAME.TabIndex = 6
        '
        'btnSAVE
        '
        Me.btnSAVE.Location = New System.Drawing.Point(404, 422)
        Me.btnSAVE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(100, 34)
        Me.btnSAVE.TabIndex = 7
        Me.btnSAVE.Text = "Save"
        Me.btnSAVE.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(512, 422)
        Me.btnCANCEL.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(100, 34)
        Me.btnCANCEL.TabIndex = 8
        Me.btnCANCEL.Text = "Cancel"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 52)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 110)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Select Statement"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 212)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Value && Default"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 244)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 16)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Display"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 310)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(162, 16)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "1. Parameter && Variable"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 276)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 16)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Report Parameter"
        '
        'txtDEFAULT_VALUE
        '
        Me.txtDEFAULT_VALUE.Location = New System.Drawing.Point(459, 208)
        Me.txtDEFAULT_VALUE.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtDEFAULT_VALUE.Name = "txtDEFAULT_VALUE"
        Me.txtDEFAULT_VALUE.Size = New System.Drawing.Size(152, 23)
        Me.txtDEFAULT_VALUE.TabIndex = 16
        '
        'txtVARIABLE_NAME1
        '
        Me.txtVARIABLE_NAME1.Location = New System.Drawing.Point(459, 306)
        Me.txtVARIABLE_NAME1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVARIABLE_NAME1.Name = "txtVARIABLE_NAME1"
        Me.txtVARIABLE_NAME1.Size = New System.Drawing.Size(152, 23)
        Me.txtVARIABLE_NAME1.TabIndex = 17
        Me.txtVARIABLE_NAME1.Tag = "0"
        '
        'txtVARIABLE_NAME2
        '
        Me.txtVARIABLE_NAME2.Location = New System.Drawing.Point(459, 341)
        Me.txtVARIABLE_NAME2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVARIABLE_NAME2.Name = "txtVARIABLE_NAME2"
        Me.txtVARIABLE_NAME2.Size = New System.Drawing.Size(152, 23)
        Me.txtVARIABLE_NAME2.TabIndex = 19
        Me.txtVARIABLE_NAME2.Tag = "0"
        '
        'cmbPARAMETER_ID2
        '
        Me.cmbPARAMETER_ID2.FormattingEnabled = True
        Me.cmbPARAMETER_ID2.Location = New System.Drawing.Point(197, 341)
        Me.cmbPARAMETER_ID2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPARAMETER_ID2.Name = "cmbPARAMETER_ID2"
        Me.cmbPARAMETER_ID2.Size = New System.Drawing.Size(252, 24)
        Me.cmbPARAMETER_ID2.TabIndex = 18
        Me.cmbPARAMETER_ID2.Tag = "0"
        '
        'txtVARIABLE_NAME3
        '
        Me.txtVARIABLE_NAME3.Location = New System.Drawing.Point(459, 375)
        Me.txtVARIABLE_NAME3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtVARIABLE_NAME3.Name = "txtVARIABLE_NAME3"
        Me.txtVARIABLE_NAME3.Size = New System.Drawing.Size(152, 23)
        Me.txtVARIABLE_NAME3.TabIndex = 21
        Me.txtVARIABLE_NAME3.Tag = "0"
        '
        'cmbPARAMETER_ID3
        '
        Me.cmbPARAMETER_ID3.FormattingEnabled = True
        Me.cmbPARAMETER_ID3.Location = New System.Drawing.Point(197, 375)
        Me.cmbPARAMETER_ID3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cmbPARAMETER_ID3.Name = "cmbPARAMETER_ID3"
        Me.cmbPARAMETER_ID3.Size = New System.Drawing.Size(252, 24)
        Me.cmbPARAMETER_ID3.TabIndex = 20
        Me.cmbPARAMETER_ID3.Tag = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 345)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(162, 16)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "2. Parameter && Variable"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 379)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(162, 16)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "3. Parameter && Variable"
        '
        'FrmReportComponentItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(628, 470)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtVARIABLE_NAME3)
        Me.Controls.Add(Me.cmbPARAMETER_ID3)
        Me.Controls.Add(Me.txtVARIABLE_NAME2)
        Me.Controls.Add(Me.cmbPARAMETER_ID2)
        Me.Controls.Add(Me.txtVARIABLE_NAME1)
        Me.Controls.Add(Me.txtDEFAULT_VALUE)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCANCEL)
        Me.Controls.Add(Me.btnSAVE)
        Me.Controls.Add(Me.txtREPORT_PARAMETER_NAME)
        Me.Controls.Add(Me.cmbPARAMETER_ID1)
        Me.Controls.Add(Me.txtDISPLAY_NAME)
        Me.Controls.Add(Me.txtVALUE_NAME)
        Me.Controls.Add(Me.rtbSQL_STATEMENT)
        Me.Controls.Add(Me.txtNAME)
        Me.Controls.Add(Me.cmbTYPE)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportComponentItems"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Component Items"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmbTYPE As ComboBox
    Friend WithEvents txtNAME As TextBox
    Friend WithEvents rtbSQL_STATEMENT As RichTextBox
    Friend WithEvents txtVALUE_NAME As TextBox
    Friend WithEvents txtDISPLAY_NAME As TextBox
    Friend WithEvents cmbPARAMETER_ID1 As ComboBox
    Friend WithEvents txtREPORT_PARAMETER_NAME As TextBox
    Friend WithEvents btnSAVE As Button
    Friend WithEvents btnCANCEL As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDEFAULT_VALUE As TextBox
    Friend WithEvents txtVARIABLE_NAME1 As TextBox
    Friend WithEvents txtVARIABLE_NAME2 As TextBox
    Friend WithEvents cmbPARAMETER_ID2 As ComboBox
    Friend WithEvents txtVARIABLE_NAME3 As TextBox
    Friend WithEvents cmbPARAMETER_ID3 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
End Class
