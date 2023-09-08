<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSystemDefault
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.xchkUSE_SCREEN_BUTTON = New System.Windows.Forms.CheckBox()
        Me.grpExport = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkDataForwarderIsActive = New System.Windows.Forms.CheckBox()
        Me.txtDataForwarderPath = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.btnBrowser = New System.Windows.Forms.Button()
        Me.txsExportPDFLocation = New System.Windows.Forms.TextBox()
        Me.chkPOSPopupNotes = New System.Windows.Forms.CheckBox()
        Me.xcmbDrawerAccountId = New System.Windows.Forms.ComboBox()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.xchkOR_REQUIRED = New System.Windows.Forms.CheckBox()
        Me.btnPOS = New System.Windows.Forms.Button()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.xnumPOS_ID = New System.Windows.Forms.NumericUpDown()
        Me.xchkPOS_STARTING_CASH = New System.Windows.Forms.CheckBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkPOSMultiMethod = New System.Windows.Forms.CheckBox()
        Me.chkPrintOS = New System.Windows.Forms.CheckBox()
        Me.chkPOSPrintPreview = New System.Windows.Forms.CheckBox()
        Me.chkUseCashDenomination = New System.Windows.Forms.CheckBox()
        Me.chkOpenCashDrawer = New System.Windows.Forms.CheckBox()
        Me.cmbPrinter = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPOS_PRINTER = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkCloseDateRunPerUnit = New System.Windows.Forms.CheckBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.grpExport.SuspendLayout()
        CType(Me.xnumPOS_ID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Transparent
        Me.btnSave.Location = New System.Drawing.Point(488, 464)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(86, 28)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'xchkUSE_SCREEN_BUTTON
        '
        Me.xchkUSE_SCREEN_BUTTON.AutoSize = True
        Me.xchkUSE_SCREEN_BUTTON.BackColor = System.Drawing.Color.Transparent
        Me.xchkUSE_SCREEN_BUTTON.Location = New System.Drawing.Point(425, 264)
        Me.xchkUSE_SCREEN_BUTTON.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.xchkUSE_SCREEN_BUTTON.Name = "xchkUSE_SCREEN_BUTTON"
        Me.xchkUSE_SCREEN_BUTTON.Size = New System.Drawing.Size(238, 20)
        Me.xchkUSE_SCREEN_BUTTON.TabIndex = 37
        Me.xchkUSE_SCREEN_BUTTON.Text = "Use Screen Keyboard && Numpad"
        Me.xchkUSE_SCREEN_BUTTON.UseVisualStyleBackColor = False
        '
        'grpExport
        '
        Me.grpExport.Controls.Add(Me.Button1)
        Me.grpExport.Controls.Add(Me.chkDataForwarderIsActive)
        Me.grpExport.Controls.Add(Me.txtDataForwarderPath)
        Me.grpExport.Controls.Add(Me.Label44)
        Me.grpExport.Controls.Add(Me.btnBrowser)
        Me.grpExport.Controls.Add(Me.txsExportPDFLocation)
        Me.grpExport.Location = New System.Drawing.Point(23, 91)
        Me.grpExport.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.grpExport.Name = "grpExport"
        Me.grpExport.Padding = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.grpExport.Size = New System.Drawing.Size(640, 165)
        Me.grpExport.TabIndex = 36
        Me.grpExport.TabStop = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(582, 123)
        Me.Button1.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(46, 23)
        Me.Button1.TabIndex = 73
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkDataForwarderIsActive
        '
        Me.chkDataForwarderIsActive.AutoSize = True
        Me.chkDataForwarderIsActive.BackColor = System.Drawing.Color.White
        Me.chkDataForwarderIsActive.Location = New System.Drawing.Point(8, 95)
        Me.chkDataForwarderIsActive.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkDataForwarderIsActive.Name = "chkDataForwarderIsActive"
        Me.chkDataForwarderIsActive.Size = New System.Drawing.Size(157, 20)
        Me.chkDataForwarderIsActive.TabIndex = 72
        Me.chkDataForwarderIsActive.Text = "Use Data Forwarder"
        Me.chkDataForwarderIsActive.UseVisualStyleBackColor = False
        '
        'txtDataForwarderPath
        '
        Me.txtDataForwarderPath.Location = New System.Drawing.Point(10, 123)
        Me.txtDataForwarderPath.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.txtDataForwarderPath.Name = "txtDataForwarderPath"
        Me.txtDataForwarderPath.Size = New System.Drawing.Size(569, 23)
        Me.txtDataForwarderPath.TabIndex = 71
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(5, 25)
        Me.Label44.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(197, 16)
        Me.Label44.TabIndex = 6
        Me.Label44.Text = "Path Export Report PDF Logs"
        '
        'btnBrowser
        '
        Me.btnBrowser.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrowser.Location = New System.Drawing.Point(582, 47)
        Me.btnBrowser.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnBrowser.Name = "btnBrowser"
        Me.btnBrowser.Size = New System.Drawing.Size(46, 24)
        Me.btnBrowser.TabIndex = 5
        Me.btnBrowser.Text = "..."
        Me.btnBrowser.UseVisualStyleBackColor = True
        '
        'txsExportPDFLocation
        '
        Me.txsExportPDFLocation.Location = New System.Drawing.Point(8, 48)
        Me.txsExportPDFLocation.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.txsExportPDFLocation.Name = "txsExportPDFLocation"
        Me.txsExportPDFLocation.Size = New System.Drawing.Size(571, 23)
        Me.txsExportPDFLocation.TabIndex = 4
        '
        'chkPOSPopupNotes
        '
        Me.chkPOSPopupNotes.AutoSize = True
        Me.chkPOSPopupNotes.BackColor = System.Drawing.Color.Transparent
        Me.chkPOSPopupNotes.Location = New System.Drawing.Point(232, 309)
        Me.chkPOSPopupNotes.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.chkPOSPopupNotes.Name = "chkPOSPopupNotes"
        Me.chkPOSPopupNotes.Size = New System.Drawing.Size(243, 20)
        Me.chkPOSPopupNotes.TabIndex = 56
        Me.chkPOSPopupNotes.Text = "POS Before Saving pop-up notes"
        Me.chkPOSPopupNotes.UseVisualStyleBackColor = False
        '
        'xcmbDrawerAccountId
        '
        Me.xcmbDrawerAccountId.FormattingEnabled = True
        Me.xcmbDrawerAccountId.Location = New System.Drawing.Point(29, 364)
        Me.xcmbDrawerAccountId.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.xcmbDrawerAccountId.Name = "xcmbDrawerAccountId"
        Me.xcmbDrawerAccountId.Size = New System.Drawing.Size(452, 24)
        Me.xcmbDrawerAccountId.TabIndex = 55
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.BackColor = System.Drawing.Color.Transparent
        Me.Label58.Location = New System.Drawing.Point(26, 343)
        Me.Label58.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(170, 16)
        Me.Label58.TabIndex = 54
        Me.Label58.Text = "Drawer Account Per Unit"
        '
        'xchkOR_REQUIRED
        '
        Me.xchkOR_REQUIRED.AutoSize = True
        Me.xchkOR_REQUIRED.BackColor = System.Drawing.Color.Transparent
        Me.xchkOR_REQUIRED.Location = New System.Drawing.Point(232, 287)
        Me.xchkOR_REQUIRED.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.xchkOR_REQUIRED.Name = "xchkOR_REQUIRED"
        Me.xchkOR_REQUIRED.Size = New System.Drawing.Size(252, 20)
        Me.xchkOR_REQUIRED.TabIndex = 53
        Me.xchkOR_REQUIRED.Text = "POS When Save O.R# is  Required"
        Me.xchkOR_REQUIRED.UseVisualStyleBackColor = False
        '
        'btnPOS
        '
        Me.btnPOS.Location = New System.Drawing.Point(106, 306)
        Me.btnPOS.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.btnPOS.Name = "btnPOS"
        Me.btnPOS.Size = New System.Drawing.Size(105, 27)
        Me.btnPOS.TabIndex = 52
        Me.btnPOS.Text = "Settings"
        Me.btnPOS.UseVisualStyleBackColor = True
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Location = New System.Drawing.Point(27, 286)
        Me.Label53.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(125, 16)
        Me.Label53.TabIndex = 51
        Me.Label53.Text = "POS Machine No. "
        '
        'xnumPOS_ID
        '
        Me.xnumPOS_ID.Location = New System.Drawing.Point(29, 305)
        Me.xnumPOS_ID.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.xnumPOS_ID.Name = "xnumPOS_ID"
        Me.xnumPOS_ID.Size = New System.Drawing.Size(65, 23)
        Me.xnumPOS_ID.TabIndex = 50
        '
        'xchkPOS_STARTING_CASH
        '
        Me.xchkPOS_STARTING_CASH.AutoSize = True
        Me.xchkPOS_STARTING_CASH.BackColor = System.Drawing.Color.Transparent
        Me.xchkPOS_STARTING_CASH.Location = New System.Drawing.Point(232, 264)
        Me.xchkPOS_STARTING_CASH.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.xchkPOS_STARTING_CASH.Name = "xchkPOS_STARTING_CASH"
        Me.xchkPOS_STARTING_CASH.Size = New System.Drawing.Size(148, 20)
        Me.xchkPOS_STARTING_CASH.TabIndex = 57
        Me.xchkPOS_STARTING_CASH.Text = "POS Starting Cash"
        Me.xchkPOS_STARTING_CASH.UseVisualStyleBackColor = False
        '
        'chkPOSMultiMethod
        '
        Me.chkPOSMultiMethod.AutoSize = True
        Me.chkPOSMultiMethod.BackColor = System.Drawing.Color.Transparent
        Me.chkPOSMultiMethod.Location = New System.Drawing.Point(232, 442)
        Me.chkPOSMultiMethod.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPOSMultiMethod.Name = "chkPOSMultiMethod"
        Me.chkPOSMultiMethod.Size = New System.Drawing.Size(152, 20)
        Me.chkPOSMultiMethod.TabIndex = 62
        Me.chkPOSMultiMethod.Text = "POS Multi-Methods"
        Me.chkPOSMultiMethod.UseVisualStyleBackColor = False
        '
        'chkPrintOS
        '
        Me.chkPrintOS.AutoSize = True
        Me.chkPrintOS.BackColor = System.Drawing.Color.Transparent
        Me.chkPrintOS.Location = New System.Drawing.Point(232, 396)
        Me.chkPrintOS.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPrintOS.Name = "chkPrintOS"
        Me.chkPrintOS.Size = New System.Drawing.Size(360, 20)
        Me.chkPrintOS.TabIndex = 61
        Me.chkPrintOS.Text = "POS After Create Payment Print O.S Automatically"
        Me.chkPrintOS.UseVisualStyleBackColor = False
        '
        'chkPOSPrintPreview
        '
        Me.chkPOSPrintPreview.AutoSize = True
        Me.chkPOSPrintPreview.BackColor = System.Drawing.Color.Transparent
        Me.chkPOSPrintPreview.Location = New System.Drawing.Point(232, 418)
        Me.chkPOSPrintPreview.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkPOSPrintPreview.Name = "chkPOSPrintPreview"
        Me.chkPOSPrintPreview.Size = New System.Drawing.Size(144, 20)
        Me.chkPOSPrintPreview.TabIndex = 60
        Me.chkPOSPrintPreview.Text = "POS Print Preview"
        Me.chkPOSPrintPreview.UseVisualStyleBackColor = False
        '
        'chkUseCashDenomination
        '
        Me.chkUseCashDenomination.AutoSize = True
        Me.chkUseCashDenomination.BackColor = System.Drawing.Color.Transparent
        Me.chkUseCashDenomination.Location = New System.Drawing.Point(232, 464)
        Me.chkUseCashDenomination.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkUseCashDenomination.Name = "chkUseCashDenomination"
        Me.chkUseCashDenomination.Size = New System.Drawing.Size(240, 20)
        Me.chkUseCashDenomination.TabIndex = 59
        Me.chkUseCashDenomination.Text = "Use Cash Denomination for Cash"
        Me.chkUseCashDenomination.UseVisualStyleBackColor = False
        '
        'chkOpenCashDrawer
        '
        Me.chkOpenCashDrawer.AutoSize = True
        Me.chkOpenCashDrawer.BackColor = System.Drawing.Color.Transparent
        Me.chkOpenCashDrawer.Location = New System.Drawing.Point(29, 413)
        Me.chkOpenCashDrawer.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.chkOpenCashDrawer.Name = "chkOpenCashDrawer"
        Me.chkOpenCashDrawer.Size = New System.Drawing.Size(148, 20)
        Me.chkOpenCashDrawer.TabIndex = 58
        Me.chkOpenCashDrawer.Text = "Open Cash Drawer"
        Me.chkOpenCashDrawer.UseVisualStyleBackColor = False
        '
        'cmbPrinter
        '
        Me.cmbPrinter.FormattingEnabled = True
        Me.cmbPrinter.Location = New System.Drawing.Point(181, 25)
        Me.cmbPrinter.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.cmbPrinter.Name = "cmbPrinter"
        Me.cmbPrinter.Size = New System.Drawing.Size(405, 24)
        Me.cmbPrinter.TabIndex = 64
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(29, 28)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 16)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Default Printer"
        '
        'cmbPOS_PRINTER
        '
        Me.cmbPOS_PRINTER.FormattingEnabled = True
        Me.cmbPOS_PRINTER.Location = New System.Drawing.Point(181, 58)
        Me.cmbPOS_PRINTER.Margin = New System.Windows.Forms.Padding(6, 4, 6, 4)
        Me.cmbPOS_PRINTER.Name = "cmbPOS_PRINTER"
        Me.cmbPOS_PRINTER.Size = New System.Drawing.Size(405, 24)
        Me.cmbPOS_PRINTER.TabIndex = 66
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(30, 62)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(134, 16)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Default POS Printer"
        '
        'chkCloseDateRunPerUnit
        '
        Me.chkCloseDateRunPerUnit.AutoSize = True
        Me.chkCloseDateRunPerUnit.Location = New System.Drawing.Point(29, 442)
        Me.chkCloseDateRunPerUnit.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkCloseDateRunPerUnit.Name = "chkCloseDateRunPerUnit"
        Me.chkCloseDateRunPerUnit.Size = New System.Drawing.Size(183, 20)
        Me.chkCloseDateRunPerUnit.TabIndex = 67
        Me.chkCloseDateRunPerUnit.Text = "Close Date Run Per Unit"
        Me.chkCloseDateRunPerUnit.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.Transparent
        Me.btnCancel.Location = New System.Drawing.Point(581, 464)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(86, 28)
        Me.btnCancel.TabIndex = 68
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'frmSystemDefault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(679, 504)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.chkCloseDateRunPerUnit)
        Me.Controls.Add(Me.cmbPOS_PRINTER)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPrinter)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkPOSMultiMethod)
        Me.Controls.Add(Me.chkPrintOS)
        Me.Controls.Add(Me.chkPOSPrintPreview)
        Me.Controls.Add(Me.chkUseCashDenomination)
        Me.Controls.Add(Me.chkOpenCashDrawer)
        Me.Controls.Add(Me.xchkPOS_STARTING_CASH)
        Me.Controls.Add(Me.chkPOSPopupNotes)
        Me.Controls.Add(Me.xcmbDrawerAccountId)
        Me.Controls.Add(Me.Label58)
        Me.Controls.Add(Me.xchkOR_REQUIRED)
        Me.Controls.Add(Me.btnPOS)
        Me.Controls.Add(Me.Label53)
        Me.Controls.Add(Me.xnumPOS_ID)
        Me.Controls.Add(Me.xchkUSE_SCREEN_BUTTON)
        Me.Controls.Add(Me.grpExport)
        Me.Controls.Add(Me.btnSave)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSystemDefault"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PC Default"
        Me.grpExport.ResumeLayout(False)
        Me.grpExport.PerformLayout()
        CType(Me.xnumPOS_ID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents xchkUSE_SCREEN_BUTTON As CheckBox
    Friend WithEvents grpExport As GroupBox
    Friend WithEvents Label44 As Label
    Friend WithEvents btnBrowser As Button
    Friend WithEvents txsExportPDFLocation As TextBox
    Friend WithEvents chkPOSPopupNotes As CheckBox
    Friend WithEvents xcmbDrawerAccountId As ComboBox
    Friend WithEvents Label58 As Label
    Friend WithEvents xchkOR_REQUIRED As CheckBox
    Friend WithEvents btnPOS As Button
    Friend WithEvents Label53 As Label
    Friend WithEvents xnumPOS_ID As NumericUpDown
    Friend WithEvents xchkPOS_STARTING_CASH As CheckBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents chkPOSMultiMethod As CheckBox
    Friend WithEvents chkPrintOS As CheckBox
    Friend WithEvents chkPOSPrintPreview As CheckBox
    Friend WithEvents chkUseCashDenomination As CheckBox
    Friend WithEvents chkOpenCashDrawer As CheckBox
    Friend WithEvents cmbPrinter As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPOS_PRINTER As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkCloseDateRunPerUnit As CheckBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents chkDataForwarderIsActive As CheckBox
    Friend WithEvents txtDataForwarderPath As TextBox
End Class
