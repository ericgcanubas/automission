<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCollectionList
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
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.pgbLoading2 = New System.Windows.Forms.ProgressBar()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.Preview = New System.Windows.Forms.Button()
        Me.lvCollect = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'dtpFrom
        '
        Me.dtpFrom.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFrom.Location = New System.Drawing.Point(18, 33)
        Me.dtpFrom.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(166, 23)
        Me.dtpFrom.TabIndex = 1
        '
        'dtpTo
        '
        Me.dtpTo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTo.Location = New System.Drawing.Point(228, 34)
        Me.dtpTo.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(181, 22)
        Me.dtpTo.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(192, 33)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 19)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 10)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 19)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Date Range"
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(571, 27)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(123, 39)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'pgbLoading2
        '
        Me.pgbLoading2.Location = New System.Drawing.Point(18, 79)
        Me.pgbLoading2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.pgbLoading2.Name = "pgbLoading2"
        Me.pgbLoading2.Size = New System.Drawing.Size(676, 36)
        Me.pgbLoading2.TabIndex = 7
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(213, 146)
        Me.btnPrint.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(100, 84)
        Me.btnPrint.TabIndex = 11
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        Me.btnPrint.Visible = False
        '
        'Preview
        '
        Me.Preview.Location = New System.Drawing.Point(322, 146)
        Me.Preview.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Preview.Name = "Preview"
        Me.Preview.Size = New System.Drawing.Size(100, 84)
        Me.Preview.TabIndex = 12
        Me.Preview.Text = "Preview"
        Me.Preview.UseVisualStyleBackColor = True
        Me.Preview.Visible = False
        '
        'lvCollect
        '
        Me.lvCollect.BackColor = System.Drawing.Color.Black
        Me.lvCollect.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvCollect.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvCollect.ForeColor = System.Drawing.Color.Lime
        Me.lvCollect.FullRowSelect = True
        Me.lvCollect.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvCollect.HideSelection = False
        Me.lvCollect.Location = New System.Drawing.Point(17, 125)
        Me.lvCollect.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.lvCollect.Name = "lvCollect"
        Me.lvCollect.Size = New System.Drawing.Size(676, 296)
        Me.lvCollect.TabIndex = 15
        Me.lvCollect.UseCompatibleStateImageBehavior = False
        Me.lvCollect.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Description"
        Me.ColumnHeader1.Width = 338
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Collection"
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColumnHeader2.Width = 328
        '
        'FrmCollectionList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(706, 426)
        Me.Controls.Add(Me.lvCollect)
        Me.Controls.Add(Me.Preview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pgbLoading2)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.dtpFrom)
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCollectionList"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Collection List"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents pgbLoading2 As ProgressBar
    Friend WithEvents btnPrint As Button
    Friend WithEvents Preview As Button
    Friend WithEvents lvCollect As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
End Class
