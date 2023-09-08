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
        Me.cmbTYPE.Location = New System.Drawing.Point(148, 12)
        Me.cmbTYPE.Name = "cmbTYPE"
        Me.cmbTYPE.Size = New System.Drawing.Size(312, 21)
        Me.cmbTYPE.TabIndex = 0
        '
        'txtNAME
        '
        Me.txtNAME.Location = New System.Drawing.Point(148, 39)
        Me.txtNAME.Name = "txtNAME"
        Me.txtNAME.Size = New System.Drawing.Size(312, 22)
        Me.txtNAME.TabIndex = 1
        '
        'rtbSQL_STATEMENT
        '
        Me.rtbSQL_STATEMENT.Location = New System.Drawing.Point(148, 67)
        Me.rtbSQL_STATEMENT.Name = "rtbSQL_STATEMENT"
        Me.rtbSQL_STATEMENT.Size = New System.Drawing.Size(312, 96)
        Me.rtbSQL_STATEMENT.TabIndex = 2
        Me.rtbSQL_STATEMENT.Text = ""
        '
        'txtVALUE_NAME
        '
        Me.txtVALUE_NAME.Location = New System.Drawing.Point(148, 169)
        Me.txtVALUE_NAME.Name = "txtVALUE_NAME"
        Me.txtVALUE_NAME.Size = New System.Drawing.Size(190, 22)
        Me.txtVALUE_NAME.TabIndex = 3
        '
        'txtDISPLAY_NAME
        '
        Me.txtDISPLAY_NAME.Location = New System.Drawing.Point(148, 195)
        Me.txtDISPLAY_NAME.Name = "txtDISPLAY_NAME"
        Me.txtDISPLAY_NAME.Size = New System.Drawing.Size(312, 22)
        Me.txtDISPLAY_NAME.TabIndex = 4
        '
        'cmbPARAMETER_ID1
        '
        Me.cmbPARAMETER_ID1.FormattingEnabled = True
        Me.cmbPARAMETER_ID1.Location = New System.Drawing.Point(148, 249)
        Me.cmbPARAMETER_ID1.Name = "cmbPARAMETER_ID1"
        Me.cmbPARAMETER_ID1.Size = New System.Drawing.Size(190, 21)
        Me.cmbPARAMETER_ID1.TabIndex = 5
        Me.cmbPARAMETER_ID1.Tag = "0"
        '
        'txtREPORT_PARAMETER_NAME
        '
        Me.txtREPORT_PARAMETER_NAME.Location = New System.Drawing.Point(148, 221)
        Me.txtREPORT_PARAMETER_NAME.Name = "txtREPORT_PARAMETER_NAME"
        Me.txtREPORT_PARAMETER_NAME.Size = New System.Drawing.Size(312, 22)
        Me.txtREPORT_PARAMETER_NAME.TabIndex = 6
        '
        'btnSAVE
        '
        Me.btnSAVE.Location = New System.Drawing.Point(303, 343)
        Me.btnSAVE.Name = "btnSAVE"
        Me.btnSAVE.Size = New System.Drawing.Size(75, 28)
        Me.btnSAVE.TabIndex = 7
        Me.btnSAVE.Text = "Save"
        Me.btnSAVE.UseVisualStyleBackColor = True
        '
        'btnCANCEL
        '
        Me.btnCANCEL.Location = New System.Drawing.Point(384, 343)
        Me.btnCANCEL.Name = "btnCANCEL"
        Me.btnCANCEL.Size = New System.Drawing.Size(75, 28)
        Me.btnCANCEL.TabIndex = 8
        Me.btnCANCEL.Text = "Cancel"
        Me.btnCANCEL.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Type"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 89)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Select Statement"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 172)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Value && Default"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 198)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Display"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 252)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(127, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "1. Parameter && Variable"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 224)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Report Parameter"
        '
        'txtDEFAULT_VALUE
        '
        Me.txtDEFAULT_VALUE.Location = New System.Drawing.Point(344, 169)
        Me.txtDEFAULT_VALUE.Name = "txtDEFAULT_VALUE"
        Me.txtDEFAULT_VALUE.Size = New System.Drawing.Size(115, 22)
        Me.txtDEFAULT_VALUE.TabIndex = 16
        '
        'txtVARIABLE_NAME1
        '
        Me.txtVARIABLE_NAME1.Location = New System.Drawing.Point(344, 249)
        Me.txtVARIABLE_NAME1.Name = "txtVARIABLE_NAME1"
        Me.txtVARIABLE_NAME1.Size = New System.Drawing.Size(115, 22)
        Me.txtVARIABLE_NAME1.TabIndex = 17
        Me.txtVARIABLE_NAME1.Tag = "0"
        '
        'txtVARIABLE_NAME2
        '
        Me.txtVARIABLE_NAME2.Location = New System.Drawing.Point(344, 277)
        Me.txtVARIABLE_NAME2.Name = "txtVARIABLE_NAME2"
        Me.txtVARIABLE_NAME2.Size = New System.Drawing.Size(115, 22)
        Me.txtVARIABLE_NAME2.TabIndex = 19
        Me.txtVARIABLE_NAME2.Tag = "0"
        '
        'cmbPARAMETER_ID2
        '
        Me.cmbPARAMETER_ID2.FormattingEnabled = True
        Me.cmbPARAMETER_ID2.Location = New System.Drawing.Point(148, 277)
        Me.cmbPARAMETER_ID2.Name = "cmbPARAMETER_ID2"
        Me.cmbPARAMETER_ID2.Size = New System.Drawing.Size(190, 21)
        Me.cmbPARAMETER_ID2.TabIndex = 18
        Me.cmbPARAMETER_ID2.Tag = "0"
        '
        'txtVARIABLE_NAME3
        '
        Me.txtVARIABLE_NAME3.Location = New System.Drawing.Point(344, 305)
        Me.txtVARIABLE_NAME3.Name = "txtVARIABLE_NAME3"
        Me.txtVARIABLE_NAME3.Size = New System.Drawing.Size(115, 22)
        Me.txtVARIABLE_NAME3.TabIndex = 21
        Me.txtVARIABLE_NAME3.Tag = "0"
        '
        'cmbPARAMETER_ID3
        '
        Me.cmbPARAMETER_ID3.FormattingEnabled = True
        Me.cmbPARAMETER_ID3.Location = New System.Drawing.Point(148, 305)
        Me.cmbPARAMETER_ID3.Name = "cmbPARAMETER_ID3"
        Me.cmbPARAMETER_ID3.Size = New System.Drawing.Size(190, 21)
        Me.cmbPARAMETER_ID3.TabIndex = 20
        Me.cmbPARAMETER_ID3.Tag = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 280)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "2. Parameter && Variable"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 308)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(127, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "3. Parameter && Variable"
        '
        'frmReportComponentItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 376)
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
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmReportComponentItems"
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
