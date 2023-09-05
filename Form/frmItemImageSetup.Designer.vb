<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItemImageSetup
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
        Me.txtImageSourceFolder = New System.Windows.Forms.TextBox()
        Me.txtImageDestinationFolder = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.chkUseImageProduct = New System.Windows.Forms.CheckBox()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.btnBrowse1 = New System.Windows.Forms.Button()
        Me.btnBrowse2 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Source Folder"
        '
        'txtImageSourceFolder
        '
        Me.txtImageSourceFolder.Location = New System.Drawing.Point(146, 41)
        Me.txtImageSourceFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtImageSourceFolder.Name = "txtImageSourceFolder"
        Me.txtImageSourceFolder.Size = New System.Drawing.Size(535, 23)
        Me.txtImageSourceFolder.TabIndex = 1
        '
        'txtImageDestinationFolder
        '
        Me.txtImageDestinationFolder.Location = New System.Drawing.Point(146, 73)
        Me.txtImageDestinationFolder.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtImageDestinationFolder.Name = "txtImageDestinationFolder"
        Me.txtImageDestinationFolder.Size = New System.Drawing.Size(535, 23)
        Me.txtImageDestinationFolder.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Destination Folder"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(600, 124)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(115, 28)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'chkUseImageProduct
        '
        Me.chkUseImageProduct.AutoSize = True
        Me.chkUseImageProduct.Location = New System.Drawing.Point(146, 15)
        Me.chkUseImageProduct.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.chkUseImageProduct.Name = "chkUseImageProduct"
        Me.chkUseImageProduct.Size = New System.Drawing.Size(122, 20)
        Me.chkUseImageProduct.TabIndex = 5
        Me.chkUseImageProduct.Text = "Use Image File"
        Me.chkUseImageProduct.UseVisualStyleBackColor = True
        '
        'btnBrowse1
        '
        Me.btnBrowse1.Location = New System.Drawing.Point(683, 39)
        Me.btnBrowse1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowse1.Name = "btnBrowse1"
        Me.btnBrowse1.Size = New System.Drawing.Size(33, 28)
        Me.btnBrowse1.TabIndex = 6
        Me.btnBrowse1.Text = "..."
        Me.btnBrowse1.UseVisualStyleBackColor = True
        '
        'btnBrowse2
        '
        Me.btnBrowse2.Location = New System.Drawing.Point(683, 71)
        Me.btnBrowse2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowse2.Name = "btnBrowse2"
        Me.btnBrowse2.Size = New System.Drawing.Size(32, 28)
        Me.btnBrowse2.TabIndex = 7
        Me.btnBrowse2.Text = "..."
        Me.btnBrowse2.UseVisualStyleBackColor = True
        '
        'FrmItemImageSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 165)
        Me.Controls.Add(Me.btnBrowse2)
        Me.Controls.Add(Me.btnBrowse1)
        Me.Controls.Add(Me.chkUseImageProduct)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtImageDestinationFolder)
        Me.Controls.Add(Me.txtImageSourceFolder)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmItemImageSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Item Image Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtImageSourceFolder As TextBox
    Friend WithEvents txtImageDestinationFolder As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents chkUseImageProduct As CheckBox
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnBrowse1 As Button
    Friend WithEvents btnBrowse2 As Button
End Class
