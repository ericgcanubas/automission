<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSServed
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
        Me.dgvAVAILABLE = New System.Windows.Forms.DataGridView()
        Me.dgvSELECTED = New System.Windows.Forms.DataGridView()
        Me.btnAddAll = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnRemoveAll = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.xlblCustomer_Name = New System.Windows.Forms.Label()
        CType(Me.dgvAVAILABLE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvSELECTED, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvAVAILABLE
        '
        Me.dgvAVAILABLE.AllowUserToAddRows = False
        Me.dgvAVAILABLE.AllowUserToDeleteRows = False
        Me.dgvAVAILABLE.AllowUserToResizeColumns = False
        Me.dgvAVAILABLE.AllowUserToResizeRows = False
        Me.dgvAVAILABLE.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAVAILABLE.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvAVAILABLE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAVAILABLE.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAVAILABLE.Location = New System.Drawing.Point(15, 33)
        Me.dgvAVAILABLE.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvAVAILABLE.MultiSelect = False
        Me.dgvAVAILABLE.Name = "dgvAVAILABLE"
        Me.dgvAVAILABLE.ReadOnly = True
        Me.dgvAVAILABLE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAVAILABLE.Size = New System.Drawing.Size(303, 210)
        Me.dgvAVAILABLE.TabIndex = 1
        '
        'dgvSELECTED
        '
        Me.dgvSELECTED.AllowUserToAddRows = False
        Me.dgvSELECTED.AllowUserToDeleteRows = False
        Me.dgvSELECTED.AllowUserToResizeColumns = False
        Me.dgvSELECTED.AllowUserToResizeRows = False
        Me.dgvSELECTED.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvSELECTED.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvSELECTED.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSELECTED.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvSELECTED.Location = New System.Drawing.Point(400, 33)
        Me.dgvSELECTED.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSELECTED.MultiSelect = False
        Me.dgvSELECTED.Name = "dgvSELECTED"
        Me.dgvSELECTED.ReadOnly = True
        Me.dgvSELECTED.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvSELECTED.Size = New System.Drawing.Size(351, 210)
        Me.dgvSELECTED.TabIndex = 2
        '
        'btnAddAll
        '
        Me.btnAddAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAddAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAddAll.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddAll.Location = New System.Drawing.Point(325, 33)
        Me.btnAddAll.Name = "btnAddAll"
        Me.btnAddAll.Size = New System.Drawing.Size(70, 48)
        Me.btnAddAll.TabIndex = 3
        Me.btnAddAll.Text = ">>"
        Me.btnAddAll.UseVisualStyleBackColor = False
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAdd.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(325, 87)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(70, 48)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = ">"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnRemove
        '
        Me.btnRemove.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemove.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemove.Location = New System.Drawing.Point(325, 141)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(70, 48)
        Me.btnRemove.TabIndex = 5
        Me.btnRemove.Text = "<"
        Me.btnRemove.UseVisualStyleBackColor = False
        '
        'btnRemoveAll
        '
        Me.btnRemoveAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRemoveAll.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRemoveAll.Location = New System.Drawing.Point(325, 195)
        Me.btnRemoveAll.Name = "btnRemoveAll"
        Me.btnRemoveAll.Size = New System.Drawing.Size(70, 48)
        Me.btnRemoveAll.TabIndex = 6
        Me.btnRemoveAll.Text = "<<"
        Me.btnRemoveAll.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOK.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Location = New System.Drawing.Point(563, 258)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(91, 44)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancel.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Location = New System.Drawing.Point(660, 258)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(91, 44)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(303, 23)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "AVAILABLE ORDER PROCESS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(400, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(347, 23)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SELECTED ORDER PROCESS"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 251)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(139, 24)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Customer :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.UseMnemonic = False
        '
        'xlblCustomer_Name
        '
        Me.xlblCustomer_Name.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.xlblCustomer_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.xlblCustomer_Name.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.xlblCustomer_Name.Location = New System.Drawing.Point(15, 274)
        Me.xlblCustomer_Name.Name = "xlblCustomer_Name"
        Me.xlblCustomer_Name.Size = New System.Drawing.Size(526, 23)
        Me.xlblCustomer_Name.TabIndex = 46
        Me.xlblCustomer_Name.Text = "JUAN DELA CRUZ"
        Me.xlblCustomer_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmPOSServed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(764, 309)
        Me.Controls.Add(Me.xlblCustomer_Name)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnRemoveAll)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnAddAll)
        Me.Controls.Add(Me.dgvSELECTED)
        Me.Controls.Add(Me.dgvAVAILABLE)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSServed"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Order Served"
        CType(Me.dgvAVAILABLE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvSELECTED, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvAVAILABLE As DataGridView
    Friend WithEvents dgvSELECTED As DataGridView
    Friend WithEvents btnAddAll As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnRemove As Button
    Friend WithEvents btnRemoveAll As Button
    Friend WithEvents btnOK As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents xlblCustomer_Name As Label
End Class
