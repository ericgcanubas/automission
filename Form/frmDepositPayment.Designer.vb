<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDepositPayment
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsOk = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCheck = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsClear = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsCheckSelectedDate = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbPaymentMethod = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.tscmbLocation = New System.Windows.Forms.ToolStripComboBox()
        Me.dgvAvailable = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblTotal = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsApply = New System.Windows.Forms.ToolStripButton()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.dgvAvailable, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.AutoSize = False
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsOk, Me.ToolStripSeparator3, Me.tsCheck, Me.ToolStripSeparator2, Me.tsClear, Me.ToolStripSeparator4, Me.tsCheckSelectedDate, Me.ToolStripSeparator1, Me.ToolStripLabel4, Me.tscmbPaymentMethod, Me.ToolStripLabel5, Me.tscmbLocation})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(1118, 57)
        Me.ToolStrip1.TabIndex = 41
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsOk
        '
        Me.tsOk.Image = Global.Automission.My.Resources.Resources.check_box
        Me.tsOk.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsOk.Name = "tsOk"
        Me.tsOk.Size = New System.Drawing.Size(79, 54)
        Me.tsOk.Text = "&Apply"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 57)
        '
        'tsCheck
        '
        Me.tsCheck.Image = Global.Automission.My.Resources.Resources.to_do_list_cheked_all_icon
        Me.tsCheck.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCheck.Name = "tsCheck"
        Me.tsCheck.Size = New System.Drawing.Size(103, 54)
        Me.tsCheck.Text = "Check All"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 57)
        '
        'tsClear
        '
        Me.tsClear.Image = Global.Automission.My.Resources.Resources.to_do_list_icon
        Me.tsClear.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsClear.Name = "tsClear"
        Me.tsClear.Size = New System.Drawing.Size(96, 54)
        Me.tsClear.Text = "Clea&r All"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 57)
        '
        'tsCheckSelectedDate
        '
        Me.tsCheckSelectedDate.Image = Global.Automission.My.Resources.Resources.date_cal_icon
        Me.tsCheckSelectedDate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsCheckSelectedDate.Name = "tsCheckSelectedDate"
        Me.tsCheckSelectedDate.Size = New System.Drawing.Size(119, 54)
        Me.tsCheckSelectedDate.Text = "Date Range"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 57)
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(118, 54)
        Me.ToolStripLabel4.Text = "Payment Method"
        '
        'tscmbPaymentMethod
        '
        Me.tscmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbPaymentMethod.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscmbPaymentMethod.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmbPaymentMethod.Name = "tscmbPaymentMethod"
        Me.tscmbPaymentMethod.Size = New System.Drawing.Size(230, 57)
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(63, 54)
        Me.ToolStripLabel5.Text = "Location"
        '
        'tscmbLocation
        '
        Me.tscmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.tscmbLocation.FlatStyle = System.Windows.Forms.FlatStyle.Standard
        Me.tscmbLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tscmbLocation.Name = "tscmbLocation"
        Me.tscmbLocation.Size = New System.Drawing.Size(201, 57)
        '
        'dgvAvailable
        '
        Me.dgvAvailable.AllowUserToAddRows = False
        Me.dgvAvailable.AllowUserToDeleteRows = False
        Me.dgvAvailable.AllowUserToResizeColumns = False
        Me.dgvAvailable.AllowUserToResizeRows = False
        Me.dgvAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAvailable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvAvailable.ColumnHeadersHeight = 35
        Me.dgvAvailable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAvailable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAvailable.Location = New System.Drawing.Point(0, 57)
        Me.dgvAvailable.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.dgvAvailable.MultiSelect = False
        Me.dgvAvailable.Name = "dgvAvailable"
        Me.dgvAvailable.ReadOnly = True
        Me.dgvAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAvailable.Size = New System.Drawing.Size(1118, 435)
        Me.dgvAvailable.TabIndex = 3
        '
        'StatusStrip1
        '
        Me.StatusStrip1.AutoSize = False
        Me.StatusStrip1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblTotal, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 492)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(19, 0, 1, 0)
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(1118, 32)
        Me.StatusStrip1.TabIndex = 42
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblTotal
        '
        Me.lblTotal.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.ForeColor = System.Drawing.Color.Blue
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblTotal.Size = New System.Drawing.Size(39, 27)
        Me.lblTotal.Text = "0.00"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripStatusLabel2.ForeColor = System.Drawing.Color.Blue
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(113, 27)
        Me.ToolStripStatusLabel2.Text = "Total Payment :"
        Me.ToolStripStatusLabel2.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal
        '
        'tsApply
        '
        Me.tsApply.Image = Global.Automission.My.Resources.Resources.to_do_list_cheked_all_icon
        Me.tsApply.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsApply.Name = "tsApply"
        Me.tsApply.Size = New System.Drawing.Size(97, 43)
        Me.tsApply.Text = "Check All"
        '
        'frmDepositPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1118, 524)
        Me.Controls.Add(Me.dgvAvailable)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDepositPayment"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payment to Deposit"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        CType(Me.dgvAvailable, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents tsOk As ToolStripButton
    Friend WithEvents tsClear As ToolStripButton
    Friend WithEvents dgvAvailable As DataGridView
    Friend WithEvents ToolStripLabel4 As ToolStripLabel
    Friend WithEvents tscmbPaymentMethod As ToolStripComboBox
    Friend WithEvents ToolStripLabel5 As ToolStripLabel
    Friend WithEvents tscmbLocation As ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblTotal As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents tsCheckSelectedDate As ToolStripButton
    Friend WithEvents tsApply As ToolStripButton
    Friend WithEvents tsCheck As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
End Class
