<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSContacts
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
        Me.dgvContact = New System.Windows.Forms.DataGridView()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.btnDefault = New System.Windows.Forms.Button()
        Me.btnNewContact = New System.Windows.Forms.Button()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        CType(Me.dgvContact, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvContact
        '
        Me.dgvContact.AllowUserToAddRows = False
        Me.dgvContact.AllowUserToDeleteRows = False
        Me.dgvContact.AllowUserToOrderColumns = True
        Me.dgvContact.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvContact.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvContact.Location = New System.Drawing.Point(5, 47)
        Me.dgvContact.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.dgvContact.MultiSelect = False
        Me.dgvContact.Name = "dgvContact"
        Me.dgvContact.ReadOnly = True
        Me.dgvContact.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvContact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvContact.Size = New System.Drawing.Size(606, 432)
        Me.dgvContact.TabIndex = 6
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(5, 13)
        Me.txtName.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(605, 26)
        Me.txtName.TabIndex = 8
        '
        'btnDefault
        '
        Me.btnDefault.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDefault.Location = New System.Drawing.Point(15, 486)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(86, 33)
        Me.btnDefault.TabIndex = 13
        Me.btnDefault.Text = "Default"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'btnNewContact
        '
        Me.btnNewContact.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewContact.Location = New System.Drawing.Point(107, 486)
        Me.btnNewContact.Name = "btnNewContact"
        Me.btnNewContact.Size = New System.Drawing.Size(86, 33)
        Me.btnNewContact.TabIndex = 14
        Me.btnNewContact.Text = "New"
        Me.btnNewContact.UseVisualStyleBackColor = True
        '
        'btnSelect
        '
        Me.btnSelect.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSelect.Location = New System.Drawing.Point(432, 486)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(86, 33)
        Me.btnSelect.TabIndex = 15
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(524, 486)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 33)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'frmPOSContacts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 527)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.btnNewContact)
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.dgvContact)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSContacts"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Contact"
        CType(Me.dgvContact, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvContact As DataGridView
    Friend WithEvents txtName As TextBox
    Friend WithEvents btnDefault As Button
    Friend WithEvents btnNewContact As Button
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnCancel As Button
End Class
