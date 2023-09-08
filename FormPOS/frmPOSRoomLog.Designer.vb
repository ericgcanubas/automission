<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSRoomLog
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
        Me.components = New System.ComponentModel.Container()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsSalesByCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSalesReceiptSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSalesByItemSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnCC = New System.Windows.Forms.Button()
        Me.btnNEw = New System.Windows.Forms.Button()
        Me.lblCashierName = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTransactionNo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTOTAL = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrintLog = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnExit.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.White
        Me.btnExit.Location = New System.Drawing.Point(11, 242)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(128, 67)
        Me.btnExit.TabIndex = 39
        Me.btnExit.Text = "LOGOUT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnReport
        '
        Me.btnReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnReport.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnReport.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.White
        Me.btnReport.Location = New System.Drawing.Point(145, 242)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(128, 67)
        Me.btnReport.TabIndex = 38
        Me.btnReport.Text = "Print Payment Received"
        Me.btnReport.UseVisualStyleBackColor = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSalesByCustomer, Me.tsSalesReceiptSummary, Me.tsSalesByItemSummary})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(234, 142)
        '
        'tsSalesByCustomer
        '
        Me.tsSalesByCustomer.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsSalesByCustomer.Name = "tsSalesByCustomer"
        Me.tsSalesByCustomer.Size = New System.Drawing.Size(233, 46)
        Me.tsSalesByCustomer.Text = "Sales by Customer"
        Me.tsSalesByCustomer.Visible = False
        '
        'tsSalesReceiptSummary
        '
        Me.tsSalesReceiptSummary.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsSalesReceiptSummary.Name = "tsSalesReceiptSummary"
        Me.tsSalesReceiptSummary.Size = New System.Drawing.Size(233, 46)
        Me.tsSalesReceiptSummary.Text = "Sales Collection"
        '
        'tsSalesByItemSummary
        '
        Me.tsSalesByItemSummary.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsSalesByItemSummary.Name = "tsSalesByItemSummary"
        Me.tsSalesByItemSummary.Size = New System.Drawing.Size(233, 46)
        Me.tsSalesByItemSummary.Text = "Sales Details"
        '
        'btnCC
        '
        Me.btnCC.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnCC.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCC.ForeColor = System.Drawing.Color.White
        Me.btnCC.Location = New System.Drawing.Point(215, 169)
        Me.btnCC.Name = "btnCC"
        Me.btnCC.Size = New System.Drawing.Size(196, 67)
        Me.btnCC.TabIndex = 37
        Me.btnCC.Text = "CASH COUNT"
        Me.btnCC.UseVisualStyleBackColor = False
        '
        'btnNEw
        '
        Me.btnNEw.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnNEw.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNEw.ForeColor = System.Drawing.Color.White
        Me.btnNEw.Location = New System.Drawing.Point(11, 169)
        Me.btnNEw.Name = "btnNEw"
        Me.btnNEw.Size = New System.Drawing.Size(196, 67)
        Me.btnNEw.TabIndex = 36
        Me.btnNEw.Text = "GOTO DASHBOARD"
        Me.btnNEw.UseVisualStyleBackColor = False
        '
        'lblCashierName
        '
        Me.lblCashierName.BackColor = System.Drawing.Color.Black
        Me.lblCashierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCashierName.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblCashierName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCashierName.Location = New System.Drawing.Point(11, 33)
        Me.lblCashierName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashierName.Name = "lblCashierName"
        Me.lblCashierName.Size = New System.Drawing.Size(396, 45)
        Me.lblCashierName.TabIndex = 35
        Me.lblCashierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 10)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(404, 21)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "User"
        '
        'lblTransactionNo
        '
        Me.lblTransactionNo.BackColor = System.Drawing.Color.Black
        Me.lblTransactionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionNo.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblTransactionNo.ForeColor = System.Drawing.Color.Aqua
        Me.lblTransactionNo.Location = New System.Drawing.Point(11, 102)
        Me.lblTransactionNo.Name = "lblTransactionNo"
        Me.lblTransactionNo.Size = New System.Drawing.Size(174, 43)
        Me.lblTransactionNo.TabIndex = 33
        Me.lblTransactionNo.Text = "0"
        Me.lblTransactionNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(174, 22)
        Me.Label4.TabIndex = 32
        Me.Label4.Text = "Count"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTOTAL
        '
        Me.lblTOTAL.BackColor = System.Drawing.Color.Black
        Me.lblTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTOTAL.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL.ForeColor = System.Drawing.Color.Yellow
        Me.lblTOTAL.Location = New System.Drawing.Point(188, 102)
        Me.lblTOTAL.Name = "lblTOTAL"
        Me.lblTOTAL.Size = New System.Drawing.Size(218, 43)
        Me.lblTOTAL.TabIndex = 31
        Me.lblTOTAL.Text = "0.00"
        Me.lblTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(186, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(218, 25)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "TOTAL"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrintLog
        '
        Me.btnPrintLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnPrintLog.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnPrintLog.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintLog.ForeColor = System.Drawing.Color.White
        Me.btnPrintLog.Location = New System.Drawing.Point(279, 242)
        Me.btnPrintLog.Name = "btnPrintLog"
        Me.btnPrintLog.Size = New System.Drawing.Size(128, 67)
        Me.btnPrintLog.TabIndex = 40
        Me.btnPrintLog.Text = "Print Transaction Log"
        Me.btnPrintLog.UseVisualStyleBackColor = False
        '
        'frmPOSRoomLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(412, 311)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnPrintLog)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnCC)
        Me.Controls.Add(Me.btnNEw)
        Me.Controls.Add(Me.lblCashierName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTransactionNo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTOTAL)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSRoomLog"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Room Log"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnExit As Button
    Friend WithEvents btnReport As Button
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents tsSalesReceiptSummary As ToolStripMenuItem
    Friend WithEvents tsSalesByItemSummary As ToolStripMenuItem
    Friend WithEvents btnCC As Button
    Friend WithEvents btnNEw As Button
    Friend WithEvents lblCashierName As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTransactionNo As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblTOTAL As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tsSalesByCustomer As ToolStripMenuItem
    Friend WithEvents btnPrintLog As Button
End Class
