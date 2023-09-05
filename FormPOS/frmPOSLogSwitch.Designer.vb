<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPOSLogSwitch
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblLastCashCount = New System.Windows.Forms.Label()
        Me.lblLastCountEntry = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLogCount = New System.Windows.Forms.Label()
        Me.lblTotalCountEntry = New System.Windows.Forms.Label()
        Me.lblTotalCashCount = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(19, 25)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date Transaction :"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 65)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 27)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Last Cash Count :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(194, 27)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Last Count Entry :"
        '
        'lblDate
        '
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDate.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(221, 23)
        Me.lblDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(165, 27)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "MM/DD/YYYY"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLastCashCount
        '
        Me.lblLastCashCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLastCashCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastCashCount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastCashCount.Location = New System.Drawing.Point(221, 65)
        Me.lblLastCashCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastCashCount.Name = "lblLastCashCount"
        Me.lblLastCashCount.Size = New System.Drawing.Size(165, 27)
        Me.lblLastCashCount.TabIndex = 4
        Me.lblLastCashCount.Text = "0.00"
        Me.lblLastCashCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLastCountEntry
        '
        Me.lblLastCountEntry.BackColor = System.Drawing.Color.Transparent
        Me.lblLastCountEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLastCountEntry.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLastCountEntry.Location = New System.Drawing.Point(221, 96)
        Me.lblLastCountEntry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastCountEntry.Name = "lblLastCountEntry"
        Me.lblLastCountEntry.Size = New System.Drawing.Size(165, 27)
        Me.lblLastCountEntry.TabIndex = 5
        Me.lblLastCountEntry.Text = "0"
        Me.lblLastCountEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(25, 195)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(190, 23)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "POS Log Count :"
        '
        'lblLogCount
        '
        Me.lblLogCount.BackColor = System.Drawing.Color.Transparent
        Me.lblLogCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLogCount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogCount.Location = New System.Drawing.Point(221, 195)
        Me.lblLogCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLogCount.Name = "lblLogCount"
        Me.lblLogCount.Size = New System.Drawing.Size(165, 27)
        Me.lblLogCount.TabIndex = 9
        Me.lblLogCount.Text = "0"
        Me.lblLogCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCountEntry
        '
        Me.lblTotalCountEntry.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCountEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCountEntry.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCountEntry.Location = New System.Drawing.Point(221, 164)
        Me.lblTotalCountEntry.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCountEntry.Name = "lblTotalCountEntry"
        Me.lblTotalCountEntry.Size = New System.Drawing.Size(165, 27)
        Me.lblTotalCountEntry.TabIndex = 13
        Me.lblTotalCountEntry.Text = "0"
        Me.lblTotalCountEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTotalCashCount
        '
        Me.lblTotalCashCount.BackColor = System.Drawing.Color.Transparent
        Me.lblTotalCashCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalCashCount.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCashCount.Location = New System.Drawing.Point(221, 134)
        Me.lblTotalCashCount.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCashCount.Name = "lblTotalCashCount"
        Me.lblTotalCashCount.Size = New System.Drawing.Size(165, 27)
        Me.lblTotalCashCount.TabIndex = 12
        Me.lblTotalCashCount.Text = "0.00"
        Me.lblTotalCashCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 164)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(193, 27)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Total Count Entry :"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(18, 134)
        Me.Label9.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(194, 27)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Total Cash Count :"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(221, 265)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(165, 57)
        Me.btnNew.TabIndex = 14
        Me.btnNew.Text = "CREATE NEW"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(18, 265)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(165, 57)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "View to Continue"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FrmPOSLogSwitch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 333)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.lblTotalCountEntry)
        Me.Controls.Add(Me.lblTotalCashCount)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblLogCount)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblLastCountEntry)
        Me.Controls.Add(Me.lblLastCashCount)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPOSLogSwitch"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "POS Log Switch"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblLastCashCount As Label
    Friend WithEvents lblLastCountEntry As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblLogCount As Label
    Friend WithEvents lblTotalCountEntry As Label
    Friend WithEvents lblTotalCashCount As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnNew As Button
    Friend WithEvents btnClose As Button
End Class
