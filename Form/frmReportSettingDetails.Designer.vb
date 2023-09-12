<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportSettingDetails
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSUB_ID = New System.Windows.Forms.TextBox()
        Me.txtDESCRIPTION = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFORM = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbGROUP_LINE = New System.Windows.Forms.ComboBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtIMAGE_FILE = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.chkMODAL = New System.Windows.Forms.CheckBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report ID"
        '
        'txtSUB_ID
        '
        Me.txtSUB_ID.Location = New System.Drawing.Point(144, 18)
        Me.txtSUB_ID.Name = "txtSUB_ID"
        Me.txtSUB_ID.Size = New System.Drawing.Size(149, 23)
        Me.txtSUB_ID.TabIndex = 1
        '
        'txtDESCRIPTION
        '
        Me.txtDESCRIPTION.Location = New System.Drawing.Point(144, 43)
        Me.txtDESCRIPTION.Name = "txtDESCRIPTION"
        Me.txtDESCRIPTION.Size = New System.Drawing.Size(404, 23)
        Me.txtDESCRIPTION.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Description"
        '
        'txtFORM
        '
        Me.txtFORM.Location = New System.Drawing.Point(144, 68)
        Me.txtFORM.Name = "txtFORM"
        Me.txtFORM.Size = New System.Drawing.Size(404, 23)
        Me.txtFORM.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Report File"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Group Line"
        '
        'cmbGROUP_LINE
        '
        Me.cmbGROUP_LINE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGROUP_LINE.FormattingEnabled = True
        Me.cmbGROUP_LINE.Location = New System.Drawing.Point(144, 94)
        Me.cmbGROUP_LINE.Name = "cmbGROUP_LINE"
        Me.cmbGROUP_LINE.Size = New System.Drawing.Size(404, 24)
        Me.cmbGROUP_LINE.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(410, 168)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(138, 34)
        Me.btnSave.TabIndex = 8
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'txtIMAGE_FILE
        '
        Me.txtIMAGE_FILE.Location = New System.Drawing.Point(144, 121)
        Me.txtIMAGE_FILE.Name = "txtIMAGE_FILE"
        Me.txtIMAGE_FILE.Size = New System.Drawing.Size(149, 23)
        Me.txtIMAGE_FILE.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 125)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Ref Description"
        '
        'chkMODAL
        '
        Me.chkMODAL.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMODAL.Location = New System.Drawing.Point(16, 151)
        Me.chkMODAL.Name = "chkMODAL"
        Me.chkMODAL.Size = New System.Drawing.Size(146, 21)
        Me.chkMODAL.TabIndex = 12
        Me.chkMODAL.Text = "Data Set"
        Me.chkMODAL.UseVisualStyleBackColor = True
        '
        'chkActive
        '
        Me.chkActive.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActive.Location = New System.Drawing.Point(16, 176)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(146, 21)
        Me.chkActive.TabIndex = 13
        Me.chkActive.Text = "Is Active"
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'FrmReportSettingDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(568, 211)
        Me.Controls.Add(Me.chkActive)
        Me.Controls.Add(Me.chkMODAL)
        Me.Controls.Add(Me.txtIMAGE_FILE)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.cmbGROUP_LINE)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtFORM)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDESCRIPTION)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSUB_ID)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmReportSettingDetails"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Setting Details"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtSUB_ID As TextBox
    Friend WithEvents txtDESCRIPTION As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFORM As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbGROUP_LINE As ComboBox
    Friend WithEvents btnSave As Button
    Friend WithEvents txtIMAGE_FILE As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents chkMODAL As CheckBox
    Friend WithEvents chkActive As CheckBox
End Class
