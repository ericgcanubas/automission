﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmItemExpired
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmItemExpired))
        Me.dgvList = New System.Windows.Forms.DataGridView()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsColumn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCreate = New System.Windows.Forms.ToolStripButton()
        Me.tsUpdate = New System.Windows.Forms.ToolStripButton()
        Me.tsDelete = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsTITLE = New System.Windows.Forms.ToolStripLabel()
        Me.tsTxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.tsSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsReload = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblRow = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvList
        '
        Me.dgvList.AllowUserToAddRows = False
        Me.dgvList.AllowUserToDeleteRows = False
        Me.dgvList.AllowUserToOrderColumns = True
        Me.dgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders
        Me.dgvList.ColumnHeadersHeight = 35
        Me.dgvList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvList.Location = New System.Drawing.Point(0, 52)
        Me.dgvList.MultiSelect = False
        Me.dgvList.Name = "dgvList"
        Me.dgvList.ReadOnly = True
        Me.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader
        Me.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvList.Size = New System.Drawing.Size(769, 226)
        Me.dgvList.TabIndex = 61
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsColumn, Me.ToolStripSeparator1, Me.tsCreate, Me.tsUpdate, Me.tsDelete, Me.ToolStripSeparator3, Me.ToolStripButton1, Me.ToolStripSeparator4, Me.tsTITLE, Me.tsTxtSearch, Me.tsSearch, Me.ToolStripSeparator5, Me.tsReload})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(769, 52)
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
        Me.tsColumn.Size = New System.Drawing.Size(23, 49)
        Me.tsColumn.Text = "*"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'tsCreate
        '
        Me.tsCreate.Image = Global.Automission.My.Resources.Resources.l_create
        Me.tsCreate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCreate.Name = "tsCreate"
        Me.tsCreate.Size = New System.Drawing.Size(50, 49)
        Me.tsCreate.Text = "&Create"
        Me.tsCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsUpdate
        '
        Me.tsUpdate.Image = Global.Automission.My.Resources.Resources.l_update
        Me.tsUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsUpdate.Name = "tsUpdate"
        Me.tsUpdate.Size = New System.Drawing.Size(51, 49)
        Me.tsUpdate.Text = "&Update"
        Me.tsUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsDelete
        '
        Me.tsDelete.Image = Global.Automission.My.Resources.Resources.l_delete
        Me.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsDelete.Name = "tsDelete"
        Me.tsDelete.Size = New System.Drawing.Size(48, 49)
        Me.tsDelete.Text = "&Delete"
        Me.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.Automission.My.Resources.Resources.I_report
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(64, 49)
        Me.ToolStripButton1.Text = "&Reports"
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 52)
        '
        'tsTITLE
        '
        Me.tsTITLE.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsTITLE.Font = New System.Drawing.Font("Verdana", 14.25!)
        Me.tsTITLE.Image = Global.Automission.My.Resources.Resources.back_icon_set
        Me.tsTITLE.Name = "tsTITLE"
        Me.tsTITLE.Size = New System.Drawing.Size(104, 49)
        Me.tsTITLE.Text = "TITLE "
        '
        'tsTxtSearch
        '
        Me.tsTxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tsTxtSearch.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsTxtSearch.Name = "tsTxtSearch"
        Me.tsTxtSearch.Size = New System.Drawing.Size(200, 52)
        '
        'tsSearch
        '
        Me.tsSearch.Image = Global.Automission.My.Resources.Resources.l_read
        Me.tsSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsSearch.Name = "tsSearch"
        Me.tsSearch.Size = New System.Drawing.Size(51, 49)
        Me.tsSearch.Text = "&Search"
        Me.tsSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 52)
        '
        'tsReload
        '
        Me.tsReload.Image = Global.Automission.My.Resources.Resources.l_reload
        Me.tsReload.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsReload.Name = "tsReload"
        Me.tsReload.Size = New System.Drawing.Size(50, 49)
        Me.tsReload.Text = "Re&load"
        Me.tsReload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblRow})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 278)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(769, 22)
        Me.StatusStrip1.SizingGrip = False
        Me.StatusStrip1.TabIndex = 62
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(86, 17)
        Me.ToolStripStatusLabel1.Text = "Record Count :"
        '
        'lblRow
        '
        Me.lblRow.BackColor = System.Drawing.Color.Transparent
        Me.lblRow.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRow.Name = "lblRow"
        Me.lblRow.Size = New System.Drawing.Size(15, 17)
        Me.lblRow.Text = "0"
        '
        'frmItemExpired
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(769, 300)
        Me.Controls.Add(Me.dgvList)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemExpired"
        Me.Text = "Item Expired"
        CType(Me.dgvList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents dgvList As DataGridView
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
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents lblRow As ToolStripStatusLabel
End Class
