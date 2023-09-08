<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUserList
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmUserList))
        Me.dgvUser = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsColumn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCreate = New System.Windows.Forms.ToolStripButton()
        Me.tsUpdate = New System.Windows.Forms.ToolStripButton()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.UpdateAccessToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DefaultToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tsSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsReload = New System.Windows.Forms.ToolStripButton()
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUser
        '
        Me.dgvUser.AllowUserToAddRows = False
        Me.dgvUser.AllowUserToDeleteRows = False
        Me.dgvUser.AllowUserToOrderColumns = True
        Me.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUser.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUser.Location = New System.Drawing.Point(0, 55)
        Me.dgvUser.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.dgvUser.MultiSelect = False
        Me.dgvUser.Name = "dgvUser"
        Me.dgvUser.ReadOnly = True
        Me.dgvUser.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUser.Size = New System.Drawing.Size(947, 474)
        Me.dgvUser.TabIndex = 9
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsColumn, Me.ToolStripSeparator1, Me.tsCreate, Me.tsUpdate, Me.tsDelete, Me.ToolStripSeparator3, Me.ToolStripDropDownButton1, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.tsTITLE, Me.tsTxtSearch, Me.tsSearch, Me.ToolStripSeparator5, Me.tsReload})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(947, 55)
        Me.ToolStrip1.TabIndex = 63
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsColumn
        '
        Me.tsColumn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsColumn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsColumn.Image = CType(resources.GetObject("tsColumn.Image"), System.Drawing.Image)
        Me.tsColumn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsColumn.Name = "tsColumn"
        Me.tsColumn.Size = New System.Drawing.Size(23, 52)
        Me.tsColumn.Text = "*"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 55)
        '
        'tsCreate
        '
        Me.tsCreate.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsCreate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCreate.Name = "tsCreate"
        Me.tsCreate.Size = New System.Drawing.Size(55, 52)
        Me.tsCreate.Text = "&Create"
        Me.tsCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsUpdate
        '
        Me.tsUpdate.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUpdate.Name = "tsUpdate"
        Me.tsUpdate.Size = New System.Drawing.Size(58, 52)
        Me.tsUpdate.Text = "&Update"
        Me.tsUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(53, 52)
        Me.tsDelete.Text = "&Delete"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpdateAccessToolStripMenuItem, Me.DefaultToolStripMenuItem})
        Me.ToolStripDropDownButton1.Image = Global.Automission.My.Resources.Resources.l_config
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(54, 52)
        Me.ToolStripDropDownButton1.Text = "&Tools"
        Me.ToolStripDropDownButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'UpdateAccessToolStripMenuItem
        '
        Me.UpdateAccessToolStripMenuItem.Name = "UpdateAccessToolStripMenuItem"
        Me.UpdateAccessToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.UpdateAccessToolStripMenuItem.Text = "Security"
        '
        'DefaultToolStripMenuItem
        '
        Me.DefaultToolStripMenuItem.Name = "DefaultToolStripMenuItem"
        Me.DefaultToolStripMenuItem.Size = New System.Drawing.Size(155, 22)
        Me.DefaultToolStripMenuItem.Text = "User Default"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 55)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.I_report
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(70, 52)
        Me.ToolStripButton1.Text = "&Reports"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 55)
        '
        'tsTITLE
        '
        Me.tsTITLE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTITLE.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.tsTITLE.Image = Global.Automission.My.Resources.Resources.back_icon_set
        Me.tsTITLE.Name = "tsTITLE"
        Me.tsTITLE.Size = New System.Drawing.Size(104, 52)
        Me.tsTITLE.Text = "TITLE "
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(228, 55)
        '
        'tsSearch
        '
        Me.tsSearch.Image = Global.Automission.My.Resources.Resources.l_read
        Me.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(57, 52)
        Me.tsSearch.Text = "&Search"
        Me.tsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 55)
        '
        'tsReload
        '
        Me.tsReload.Image = Global.Automission.My.Resources.Resources.l_reload
        Me.tsReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReload.Name = "tsReload"
        Me.tsReload.Size = New System.Drawing.Size(54, 52)
        Me.tsReload.Text = "Re&load"
        Me.tsReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmUserList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(947, 529)
        Me.Controls.Add(Me.dgvUser)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmUserList"
        Me.Text = "frmUserList"
        CType(Me.dgvUser, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvUser As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsColumn As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsCreate As ToolStripButton
    Friend WithEvents tsUpdate As ToolStripButton
    Friend WithEvents tsDelete As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripButton1 As ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents tsTITLE As ToolStripLabel
    Friend WithEvents tsTxtSearch As ToolStripTextBox
    Friend WithEvents tsSearch As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsReload As ToolStripButton
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
    Friend WithEvents UpdateAccessToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DefaultToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
End Class
