﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInventoryReComputed
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
        Me.pbInventory = New System.Windows.Forms.ProgressBar()
        Me.pbJournal = New System.Windows.Forms.ProgressBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblInventoryStatus = New System.Windows.Forms.Label()
        Me.lblJournalStatus = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'pbInventory
        '
        Me.pbInventory.Location = New System.Drawing.Point(15, 32)
        Me.pbInventory.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.pbInventory.Name = "pbInventory"
        Me.pbInventory.Size = New System.Drawing.Size(325, 25)
        Me.pbInventory.TabIndex = 1
        '
        'pbJournal
        '
        Me.pbJournal.Location = New System.Drawing.Point(15, 94)
        Me.pbJournal.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.pbJournal.Name = "pbJournal"
        Me.pbJournal.Size = New System.Drawing.Size(325, 25)
        Me.pbJournal.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 13)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Inventory"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Journal"
        '
        'lblInventoryStatus
        '
        Me.lblInventoryStatus.Location = New System.Drawing.Point(127, 13)
        Me.lblInventoryStatus.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblInventoryStatus.Name = "lblInventoryStatus"
        Me.lblInventoryStatus.Size = New System.Drawing.Size(213, 16)
        Me.lblInventoryStatus.TabIndex = 7
        Me.lblInventoryStatus.Text = "0/0"
        Me.lblInventoryStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblJournalStatus
        '
        Me.lblJournalStatus.Location = New System.Drawing.Point(79, 77)
        Me.lblJournalStatus.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblJournalStatus.Name = "lblJournalStatus"
        Me.lblJournalStatus.Size = New System.Drawing.Size(261, 16)
        Me.lblJournalStatus.TabIndex = 8
        Me.lblJournalStatus.Text = "0/0"
        Me.lblJournalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Timer1
        '
        '
        'FrmInventoryReComputed
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(365, 135)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblJournalStatus)
        Me.Controls.Add(Me.lblInventoryStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.pbJournal)
        Me.Controls.Add(Me.pbInventory)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(5, 3, 5, 3)
        Me.Name = "FrmInventoryReComputed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory ReComputed"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbInventory As ProgressBar
    Friend WithEvents pbJournal As ProgressBar
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblInventoryStatus As Label
    Friend WithEvents lblJournalStatus As Label
    Friend WithEvents Timer1 As Timer
End Class
