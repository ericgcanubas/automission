<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubMenuGroup
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
        Me.dgvMenu = New System.Windows.Forms.DataGridView()
        Me.dgvSubMenu = New System.Windows.Forms.DataGridView()
        Me.dgvSUB_MENU_GROUP = New System.Windows.Forms.DataGridView()
        Me.dgvSUB_MENU_GROUP_DETAILS = New System.Windows.Forms.DataGridView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSubMenu, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSUB_MENU_GROUP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSUB_MENU_GROUP_DETAILS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvMenu
        '
        Me.dgvMenu.AllowUserToAddRows = False
        Me.dgvMenu.AllowUserToDeleteRows = False
        Me.dgvMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvMenu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMenu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvMenu.Location = New System.Drawing.Point(12, 30)
        Me.dgvMenu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.ReadOnly = True
        Me.dgvMenu.Size = New System.Drawing.Size(395, 185)
        Me.dgvMenu.TabIndex = 9
        '
        'dgvSubMenu
        '
        Me.dgvSubMenu.AllowUserToAddRows = False
        Me.dgvSubMenu.AllowUserToDeleteRows = False
        Me.dgvSubMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSubMenu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvSubMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubMenu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSubMenu.Location = New System.Drawing.Point(12, 238)
        Me.dgvSubMenu.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvSubMenu.Name = "dgvSubMenu"
        Me.dgvSubMenu.ReadOnly = True
        Me.dgvSubMenu.Size = New System.Drawing.Size(395, 289)
        Me.dgvSubMenu.TabIndex = 8
        '
        'dgvSUB_MENU_GROUP
        '
        Me.dgvSUB_MENU_GROUP.AllowUserToAddRows = False
        Me.dgvSUB_MENU_GROUP.AllowUserToDeleteRows = False
        Me.dgvSUB_MENU_GROUP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSUB_MENU_GROUP.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvSUB_MENU_GROUP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSUB_MENU_GROUP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSUB_MENU_GROUP.Location = New System.Drawing.Point(464, 30)
        Me.dgvSUB_MENU_GROUP.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvSUB_MENU_GROUP.Name = "dgvSUB_MENU_GROUP"
        Me.dgvSUB_MENU_GROUP.ReadOnly = True
        Me.dgvSUB_MENU_GROUP.Size = New System.Drawing.Size(397, 185)
        Me.dgvSUB_MENU_GROUP.TabIndex = 11
        '
        'dgvSUB_MENU_GROUP_DETAILS
        '
        Me.dgvSUB_MENU_GROUP_DETAILS.AllowUserToAddRows = False
        Me.dgvSUB_MENU_GROUP_DETAILS.AllowUserToDeleteRows = False
        Me.dgvSUB_MENU_GROUP_DETAILS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSUB_MENU_GROUP_DETAILS.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
        Me.dgvSUB_MENU_GROUP_DETAILS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSUB_MENU_GROUP_DETAILS.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSUB_MENU_GROUP_DETAILS.Location = New System.Drawing.Point(464, 238)
        Me.dgvSUB_MENU_GROUP_DETAILS.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvSUB_MENU_GROUP_DETAILS.Name = "dgvSUB_MENU_GROUP_DETAILS"
        Me.dgvSUB_MENU_GROUP_DETAILS.ReadOnly = True
        Me.dgvSUB_MENU_GROUP_DETAILS.Size = New System.Drawing.Size(397, 289)
        Me.dgvSUB_MENU_GROUP_DETAILS.TabIndex = 10
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(415, 327)
        Me.btnAdd.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(41, 33)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = ">"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(415, 368)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(41, 33)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "<"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 16)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Menu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 218)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Sub Menu"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(460, 10)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(115, 16)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Sub Menu Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(460, 218)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(164, 16)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Sub Menu Group Details"
        '
        'FrmSubMenuGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 528)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.dgvSUB_MENU_GROUP)
        Me.Controls.Add(Me.dgvSUB_MENU_GROUP_DETAILS)
        Me.Controls.Add(Me.dgvMenu)
        Me.Controls.Add(Me.dgvSubMenu)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "FrmSubMenuGroup"
        Me.Text = "Sub Menu Group"
        CType(Me.dgvMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSubMenu, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSUB_MENU_GROUP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSUB_MENU_GROUP_DETAILS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvMenu As DataGridView
    Friend WithEvents dgvSubMenu As DataGridView
    Friend WithEvents dgvSUB_MENU_GROUP As DataGridView
    Friend WithEvents dgvSUB_MENU_GROUP_DETAILS As DataGridView
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
End Class
