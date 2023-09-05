<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSubMenuGroup
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
        Me.dgvMenu.Location = New System.Drawing.Point(9, 24)
        Me.dgvMenu.Name = "dgvMenu"
        Me.dgvMenu.ReadOnly = True
        Me.dgvMenu.Size = New System.Drawing.Size(296, 150)
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
        Me.dgvSubMenu.Location = New System.Drawing.Point(9, 193)
        Me.dgvSubMenu.Name = "dgvSubMenu"
        Me.dgvSubMenu.ReadOnly = True
        Me.dgvSubMenu.Size = New System.Drawing.Size(296, 235)
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
        Me.dgvSUB_MENU_GROUP.Location = New System.Drawing.Point(348, 24)
        Me.dgvSUB_MENU_GROUP.Name = "dgvSUB_MENU_GROUP"
        Me.dgvSUB_MENU_GROUP.ReadOnly = True
        Me.dgvSUB_MENU_GROUP.Size = New System.Drawing.Size(298, 150)
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
        Me.dgvSUB_MENU_GROUP_DETAILS.Location = New System.Drawing.Point(348, 193)
        Me.dgvSUB_MENU_GROUP_DETAILS.Name = "dgvSUB_MENU_GROUP_DETAILS"
        Me.dgvSUB_MENU_GROUP_DETAILS.ReadOnly = True
        Me.dgvSUB_MENU_GROUP_DETAILS.Size = New System.Drawing.Size(298, 235)
        Me.dgvSUB_MENU_GROUP_DETAILS.TabIndex = 10
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(311, 266)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(31, 27)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = ">"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(311, 299)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(31, 27)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "<"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Menu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 177)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Sub Menu"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(345, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Sub Menu Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(345, 177)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Sub Menu Group Details"
        '
        'frmSubMenuGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(651, 429)
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
        Me.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSubMenuGroup"
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
