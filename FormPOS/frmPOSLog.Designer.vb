<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPOSLog
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPOSLog))
        Me.lblTOTAL = New System.Windows.Forms.Label()
        Me.lblTransactionNo = New System.Windows.Forms.Label()
        Me.lblCashierName = New System.Windows.Forms.Label()
        Me.ctmReport = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tsSalesReceiptSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSalesByItemSummary = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsSalesByCustomer = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsPOSLOG = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMachineName = New System.Windows.Forms.Label()
        Me.lblCreated_On = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel5 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel3 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.BunifuGradientPanel4 = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSettings = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnReport = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnExit = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnVOID = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnCashCount = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.btnNew = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.bgpanelSales = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.bgpanelEntry = New Bunifu.Framework.UI.BunifuGradientPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ctmReport.SuspendLayout()
        Me.BunifuGradientPanel5.SuspendLayout()
        Me.BunifuGradientPanel3.SuspendLayout()
        Me.BunifuGradientPanel4.SuspendLayout()
        Me.bgpanelSales.SuspendLayout()
        Me.bgpanelEntry.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTOTAL
        '
        Me.lblTOTAL.BackColor = System.Drawing.Color.Black
        Me.lblTOTAL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTOTAL.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTAL.ForeColor = System.Drawing.Color.Yellow
        Me.lblTOTAL.Location = New System.Drawing.Point(139, 193)
        Me.lblTOTAL.Name = "lblTOTAL"
        Me.lblTOTAL.Size = New System.Drawing.Size(279, 43)
        Me.lblTOTAL.TabIndex = 1
        Me.lblTOTAL.Text = "0.00"
        Me.lblTOTAL.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransactionNo
        '
        Me.lblTransactionNo.BackColor = System.Drawing.Color.Black
        Me.lblTransactionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTransactionNo.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblTransactionNo.ForeColor = System.Drawing.Color.Aqua
        Me.lblTransactionNo.Location = New System.Drawing.Point(3, 193)
        Me.lblTransactionNo.Name = "lblTransactionNo"
        Me.lblTransactionNo.Size = New System.Drawing.Size(134, 43)
        Me.lblTransactionNo.TabIndex = 3
        Me.lblTransactionNo.Text = "0"
        Me.lblTransactionNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCashierName
        '
        Me.lblCashierName.BackColor = System.Drawing.Color.Black
        Me.lblCashierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCashierName.Font = New System.Drawing.Font("Verdana", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblCashierName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblCashierName.Location = New System.Drawing.Point(3, 30)
        Me.lblCashierName.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCashierName.Name = "lblCashierName"
        Me.lblCashierName.Size = New System.Drawing.Size(415, 43)
        Me.lblCashierName.TabIndex = 8
        Me.lblCashierName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctmReport
        '
        Me.ctmReport.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctmReport.ImageScalingSize = New System.Drawing.Size(40, 40)
        Me.ctmReport.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsSalesReceiptSummary, Me.tsSalesByItemSummary, Me.tsSalesByCustomer, Me.tsPOSLOG})
        Me.ctmReport.Name = "ContextMenuStrip1"
        Me.ctmReport.Size = New System.Drawing.Size(269, 188)
        '
        'tsSalesReceiptSummary
        '
        Me.tsSalesReceiptSummary.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsSalesReceiptSummary.Name = "tsSalesReceiptSummary"
        Me.tsSalesReceiptSummary.Size = New System.Drawing.Size(268, 46)
        Me.tsSalesReceiptSummary.Text = "Sales Entry List"
        '
        'tsSalesByItemSummary
        '
        Me.tsSalesByItemSummary.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsSalesByItemSummary.Name = "tsSalesByItemSummary"
        Me.tsSalesByItemSummary.Size = New System.Drawing.Size(268, 46)
        Me.tsSalesByItemSummary.Text = "Sales By Item Summary"
        '
        'tsSalesByCustomer
        '
        Me.tsSalesByCustomer.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsSalesByCustomer.Name = "tsSalesByCustomer"
        Me.tsSalesByCustomer.Size = New System.Drawing.Size(268, 46)
        Me.tsSalesByCustomer.Text = "Sales by Buyers"
        '
        'tsPOSLOG
        '
        Me.tsPOSLOG.Image = Global.Automission.My.Resources.Resources.printer_icon
        Me.tsPOSLOG.Name = "tsPOSLOG"
        Me.tsPOSLOG.Size = New System.Drawing.Size(268, 46)
        Me.tsPOSLOG.Text = "Daily POS Log"
        '
        'lblMachineName
        '
        Me.lblMachineName.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMachineName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMachineName.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMachineName.ForeColor = System.Drawing.Color.Black
        Me.lblMachineName.Location = New System.Drawing.Point(4, 263)
        Me.lblMachineName.Name = "lblMachineName"
        Me.lblMachineName.Size = New System.Drawing.Size(414, 23)
        Me.lblMachineName.TabIndex = 19
        Me.lblMachineName.Text = "XXXXXXX"
        '
        'lblCreated_On
        '
        Me.lblCreated_On.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCreated_On.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.lblCreated_On.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblCreated_On.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreated_On.ForeColor = System.Drawing.Color.Black
        Me.lblCreated_On.Location = New System.Drawing.Point(4, 308)
        Me.lblCreated_On.Name = "lblCreated_On"
        Me.lblCreated_On.Size = New System.Drawing.Size(414, 19)
        Me.lblCreated_On.TabIndex = 21
        Me.lblCreated_On.Text = "XXXXXX"
        '
        'BunifuGradientPanel5
        '
        Me.BunifuGradientPanel5.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel5.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel5.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel5.Controls.Add(Me.Label2)
        Me.BunifuGradientPanel5.GradientBottomLeft = System.Drawing.Color.White
        Me.BunifuGradientPanel5.GradientBottomRight = System.Drawing.Color.DodgerBlue
        Me.BunifuGradientPanel5.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.BunifuGradientPanel5.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel5.Location = New System.Drawing.Point(3, 1)
        Me.BunifuGradientPanel5.Name = "BunifuGradientPanel5"
        Me.BunifuGradientPanel5.Quality = 10
        Me.BunifuGradientPanel5.Size = New System.Drawing.Size(415, 29)
        Me.BunifuGradientPanel5.TabIndex = 163
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(99, 25)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Cashier"
        '
        'BunifuGradientPanel3
        '
        Me.BunifuGradientPanel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BunifuGradientPanel3.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel3.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel3.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel3.Controls.Add(Me.Label3)
        Me.BunifuGradientPanel3.GradientBottomLeft = System.Drawing.Color.WhiteSmoke
        Me.BunifuGradientPanel3.GradientBottomRight = System.Drawing.Color.Navy
        Me.BunifuGradientPanel3.GradientTopLeft = System.Drawing.Color.DarkSlateGray
        Me.BunifuGradientPanel3.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel3.Location = New System.Drawing.Point(2, 286)
        Me.BunifuGradientPanel3.Name = "BunifuGradientPanel3"
        Me.BunifuGradientPanel3.Quality = 10
        Me.BunifuGradientPanel3.Size = New System.Drawing.Size(416, 22)
        Me.BunifuGradientPanel3.TabIndex = 173
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 14)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Created On"
        '
        'BunifuGradientPanel4
        '
        Me.BunifuGradientPanel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.BunifuGradientPanel4.BackColor = System.Drawing.Color.Black
        Me.BunifuGradientPanel4.BackgroundImage = CType(resources.GetObject("BunifuGradientPanel4.BackgroundImage"), System.Drawing.Image)
        Me.BunifuGradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BunifuGradientPanel4.Controls.Add(Me.Label9)
        Me.BunifuGradientPanel4.GradientBottomLeft = System.Drawing.Color.WhiteSmoke
        Me.BunifuGradientPanel4.GradientBottomRight = System.Drawing.Color.Navy
        Me.BunifuGradientPanel4.GradientTopLeft = System.Drawing.Color.DarkSlateGray
        Me.BunifuGradientPanel4.GradientTopRight = System.Drawing.Color.LightBlue
        Me.BunifuGradientPanel4.Location = New System.Drawing.Point(3, 241)
        Me.BunifuGradientPanel4.Name = "BunifuGradientPanel4"
        Me.BunifuGradientPanel4.Quality = 10
        Me.BunifuGradientPanel4.Size = New System.Drawing.Size(415, 22)
        Me.BunifuGradientPanel4.TabIndex = 172
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 4)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(101, 14)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Machine name"
        '
        'btnSettings
        '
        Me.btnSettings.ActiveBorderThickness = 1
        Me.btnSettings.ActiveCornerRadius = 20
        Me.btnSettings.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnSettings.ActiveForecolor = System.Drawing.Color.White
        Me.btnSettings.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnSettings.BackColor = System.Drawing.SystemColors.Control
        Me.btnSettings.BackgroundImage = CType(resources.GetObject("btnSettings.BackgroundImage"), System.Drawing.Image)
        Me.btnSettings.ButtonText = "&Setting"
        Me.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSettings.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSettings.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnSettings.IdleBorderThickness = 1
        Me.btnSettings.IdleCornerRadius = 20
        Me.btnSettings.IdleFillColor = System.Drawing.Color.White
        Me.btnSettings.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnSettings.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnSettings.Location = New System.Drawing.Point(292, 115)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(122, 41)
        Me.btnSettings.TabIndex = 171
        Me.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnReport
        '
        Me.btnReport.ActiveBorderThickness = 1
        Me.btnReport.ActiveCornerRadius = 20
        Me.btnReport.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnReport.ActiveForecolor = System.Drawing.Color.White
        Me.btnReport.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnReport.BackColor = System.Drawing.SystemColors.Control
        Me.btnReport.BackgroundImage = CType(resources.GetObject("btnReport.BackgroundImage"), System.Drawing.Image)
        Me.btnReport.ButtonText = "&Reports"
        Me.btnReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReport.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReport.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnReport.IdleBorderThickness = 1
        Me.btnReport.IdleCornerRadius = 20
        Me.btnReport.IdleFillColor = System.Drawing.Color.White
        Me.btnReport.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnReport.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnReport.Location = New System.Drawing.Point(154, 115)
        Me.btnReport.Margin = New System.Windows.Forms.Padding(5)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(122, 41)
        Me.btnReport.TabIndex = 170
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExit
        '
        Me.btnExit.ActiveBorderThickness = 1
        Me.btnExit.ActiveCornerRadius = 20
        Me.btnExit.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnExit.ActiveForecolor = System.Drawing.Color.White
        Me.btnExit.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnExit.BackColor = System.Drawing.SystemColors.Control
        Me.btnExit.BackgroundImage = CType(resources.GetObject("btnExit.BackgroundImage"), System.Drawing.Image)
        Me.btnExit.ButtonText = "&Logout"
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnExit.IdleBorderThickness = 1
        Me.btnExit.IdleCornerRadius = 20
        Me.btnExit.IdleFillColor = System.Drawing.Color.White
        Me.btnExit.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnExit.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnExit.Location = New System.Drawing.Point(4, 115)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(122, 41)
        Me.btnExit.TabIndex = 169
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnVOID
        '
        Me.btnVOID.ActiveBorderThickness = 1
        Me.btnVOID.ActiveCornerRadius = 20
        Me.btnVOID.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnVOID.ActiveForecolor = System.Drawing.Color.White
        Me.btnVOID.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnVOID.BackColor = System.Drawing.SystemColors.Control
        Me.btnVOID.BackgroundImage = CType(resources.GetObject("btnVOID.BackgroundImage"), System.Drawing.Image)
        Me.btnVOID.ButtonText = "Entry &List"
        Me.btnVOID.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnVOID.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVOID.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnVOID.IdleBorderThickness = 1
        Me.btnVOID.IdleCornerRadius = 20
        Me.btnVOID.IdleFillColor = System.Drawing.Color.White
        Me.btnVOID.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnVOID.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnVOID.Location = New System.Drawing.Point(292, 75)
        Me.btnVOID.Margin = New System.Windows.Forms.Padding(5)
        Me.btnVOID.Name = "btnVOID"
        Me.btnVOID.Size = New System.Drawing.Size(122, 41)
        Me.btnVOID.TabIndex = 168
        Me.btnVOID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnCashCount
        '
        Me.btnCashCount.ActiveBorderThickness = 1
        Me.btnCashCount.ActiveCornerRadius = 20
        Me.btnCashCount.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnCashCount.ActiveForecolor = System.Drawing.Color.White
        Me.btnCashCount.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnCashCount.BackColor = System.Drawing.SystemColors.Control
        Me.btnCashCount.BackgroundImage = CType(resources.GetObject("btnCashCount.BackgroundImage"), System.Drawing.Image)
        Me.btnCashCount.ButtonText = "&Cash Count"
        Me.btnCashCount.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCashCount.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCashCount.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnCashCount.IdleBorderThickness = 1
        Me.btnCashCount.IdleCornerRadius = 20
        Me.btnCashCount.IdleFillColor = System.Drawing.Color.White
        Me.btnCashCount.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnCashCount.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnCashCount.Location = New System.Drawing.Point(154, 75)
        Me.btnCashCount.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCashCount.Name = "btnCashCount"
        Me.btnCashCount.Size = New System.Drawing.Size(122, 41)
        Me.btnCashCount.TabIndex = 167
        Me.btnCashCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnNew
        '
        Me.btnNew.ActiveBorderThickness = 1
        Me.btnNew.ActiveCornerRadius = 20
        Me.btnNew.ActiveFillColor = System.Drawing.Color.SeaGreen
        Me.btnNew.ActiveForecolor = System.Drawing.Color.White
        Me.btnNew.ActiveLineColor = System.Drawing.Color.SeaGreen
        Me.btnNew.BackColor = System.Drawing.SystemColors.Control
        Me.btnNew.BackgroundImage = CType(resources.GetObject("btnNew.BackgroundImage"), System.Drawing.Image)
        Me.btnNew.ButtonText = "&New Entry"
        Me.btnNew.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNew.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.ForeColor = System.Drawing.Color.SeaGreen
        Me.btnNew.IdleBorderThickness = 1
        Me.btnNew.IdleCornerRadius = 20
        Me.btnNew.IdleFillColor = System.Drawing.Color.White
        Me.btnNew.IdleForecolor = System.Drawing.Color.SeaGreen
        Me.btnNew.IdleLineColor = System.Drawing.Color.SeaGreen
        Me.btnNew.Location = New System.Drawing.Point(4, 74)
        Me.btnNew.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(122, 41)
        Me.btnNew.TabIndex = 166
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'bgpanelSales
        '
        Me.bgpanelSales.BackColor = System.Drawing.Color.Black
        Me.bgpanelSales.BackgroundImage = CType(resources.GetObject("bgpanelSales.BackgroundImage"), System.Drawing.Image)
        Me.bgpanelSales.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bgpanelSales.Controls.Add(Me.Label1)
        Me.bgpanelSales.GradientBottomLeft = System.Drawing.Color.White
        Me.bgpanelSales.GradientBottomRight = System.Drawing.Color.DodgerBlue
        Me.bgpanelSales.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.bgpanelSales.GradientTopRight = System.Drawing.Color.LightBlue
        Me.bgpanelSales.Location = New System.Drawing.Point(139, 164)
        Me.bgpanelSales.Name = "bgpanelSales"
        Me.bgpanelSales.Quality = 10
        Me.bgpanelSales.Size = New System.Drawing.Size(279, 29)
        Me.bgpanelSales.TabIndex = 165
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(146, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 23)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Total Sales"
        '
        'bgpanelEntry
        '
        Me.bgpanelEntry.BackColor = System.Drawing.Color.Black
        Me.bgpanelEntry.BackgroundImage = CType(resources.GetObject("bgpanelEntry.BackgroundImage"), System.Drawing.Image)
        Me.bgpanelEntry.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.bgpanelEntry.Controls.Add(Me.Label4)
        Me.bgpanelEntry.GradientBottomLeft = System.Drawing.Color.White
        Me.bgpanelEntry.GradientBottomRight = System.Drawing.Color.DodgerBlue
        Me.bgpanelEntry.GradientTopLeft = System.Drawing.Color.LightCyan
        Me.bgpanelEntry.GradientTopRight = System.Drawing.Color.LightBlue
        Me.bgpanelEntry.Location = New System.Drawing.Point(3, 164)
        Me.bgpanelEntry.Name = "bgpanelEntry"
        Me.bgpanelEntry.Quality = 10
        Me.bgpanelEntry.Size = New System.Drawing.Size(134, 29)
        Me.bgpanelEntry.TabIndex = 164
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(3, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 18)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "No. of Entry"
        '
        'frmPOSLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.BunifuGradientPanel3)
        Me.Controls.Add(Me.BunifuGradientPanel4)
        Me.Controls.Add(Me.lblCreated_On)
        Me.Controls.Add(Me.lblMachineName)
        Me.Controls.Add(Me.BunifuGradientPanel5)
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnVOID)
        Me.Controls.Add(Me.btnCashCount)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.bgpanelSales)
        Me.Controls.Add(Me.bgpanelEntry)
        Me.Controls.Add(Me.lblTransactionNo)
        Me.Controls.Add(Me.lblTOTAL)
        Me.Controls.Add(Me.lblCashierName)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPOSLog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Point of Sales - Log"
        Me.ctmReport.ResumeLayout(False)
        Me.BunifuGradientPanel5.ResumeLayout(False)
        Me.BunifuGradientPanel5.PerformLayout()
        Me.BunifuGradientPanel3.ResumeLayout(False)
        Me.BunifuGradientPanel3.PerformLayout()
        Me.BunifuGradientPanel4.ResumeLayout(False)
        Me.BunifuGradientPanel4.PerformLayout()
        Me.bgpanelSales.ResumeLayout(False)
        Me.bgpanelSales.PerformLayout()
        Me.bgpanelEntry.ResumeLayout(False)
        Me.bgpanelEntry.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblTOTAL As Label
    Friend WithEvents lblTransactionNo As Label
    Friend WithEvents lblCashierName As Label
    Friend WithEvents ctmReport As ContextMenuStrip
    Friend WithEvents tsSalesReceiptSummary As ToolStripMenuItem
    Friend WithEvents tsSalesByCustomer As ToolStripMenuItem
    Friend WithEvents tsSalesByItemSummary As ToolStripMenuItem
    Friend WithEvents tsPOSLOG As ToolStripMenuItem
    Friend WithEvents lblMachineName As Label
    Friend WithEvents lblCreated_On As Label
    Friend WithEvents BunifuGradientPanel5 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents bgpanelEntry As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents bgpanelSales As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnNew As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnCashCount As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnVOID As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnExit As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnReport As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btnSettings As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents BunifuGradientPanel4 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label9 As Label
    Friend WithEvents BunifuGradientPanel3 As Bunifu.Framework.UI.BunifuGradientPanel
    Friend WithEvents Label3 As Label
End Class
