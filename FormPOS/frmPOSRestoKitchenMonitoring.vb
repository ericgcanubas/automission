Imports System.Data.Odbc
Public Class frmPOSRestoKitchenMonitoring
    Public gsCloseCall As Boolean

    Private Sub frmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '   If gsCloseCall = True Then
        bActiveFirst = False
        frmSplash.Show()
        frmSplash.Timer1.Enabled = True
        gsMenuSubID = ""
        gsMenuID = ""
        Me.Dispose()
        '   End If
    End Sub

    Private Sub frmPOSOrderEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmPOSRestoKitchenMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fORDERLIST()
    End Sub


    Private Sub fORDERLIST()
        Timer1.Stop()
        FlowLayoutPanel1.Controls.Clear()
        Dim N As Integer = 0
        Dim rd As OdbcDataReader = fReader($"SELECT 
          pts.id,
            pts.`payment_id`,
          DATE_FORMAT(pts.`recorded_on`,'%l:%i:%s %p') AS `TIME_LOG`,
          i.`SHIP_TO`,
          i.`NOTES`,
          p.AMOUNT_APPLIED
        From
          pos_table_served As pts 
          INNER Join payment AS p 
            On p.`ID` = pts.`payment_id` 
          INNER Join payment_invoices AS pn 
            On pn.`PAYMENT_ID` = p.`ID` 
            INNER Join invoice AS i ON
            i.`ID` = pn.`INVOICE_ID`
            WHERE i.`NOTES` <> '' and pts.`kitchen_status` = 0 AND i.`DATE` = '{fDateFormatMYSQL(DateTime.Now.Date)}' limit 6")

        While rd.Read
            N = N + 1
            Dim BG As Color
            If fTextisNULL(rd("NOTES")).ToString.Contains("DINE-IN") = True Then
                BG = Color.NavajoWhite
            Else
                BG = Color.Yellow
            End If

            fCreateObject(N, rd("ID"), rd("payment_id"), fNumisNULL(rd("SHIP_TO")), fNumFormatStandard(rd("AMOUNT_APPLIED")), rd("TIME_LOG"), BG)
        End While
        rd.Close()

        Timer1.Start()

    End Sub
    Private Sub ClickClose(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim ID As Integer = btn.AccessibleDescription

        fExecutedOnly($"UPDATE pos_table_served SET kitchen_status = '1' WHERE ID ='{ID}' limit 1;")
        fORDERLIST()

    End Sub
    Private Sub fCreateObject(ByVal N As Integer, ByVal ID As Integer, ByVal Payment_ID As Integer, ByVal SERVED As String, ByVal TOTAL As String, ByVal RECORDED_TIME As String, ByVal BGC As Color)

        Dim NewPanel As New Panel
        NewPanel.BackColor = BGC
        NewPanel.Name = $"pnl{N}"
        NewPanel.Font = Panel1.Font
        NewPanel.Size = Panel1.Size
        NewPanel.BorderStyle = BorderStyle.FixedSingle
        FlowLayoutPanel1.Controls.Add(NewPanel)

        Dim NewButtonClose As New Button
        NewButtonClose.Name = $"btn{N}"
        NewButtonClose.Size = btnDONE.Size
        NewButtonClose.AccessibleDescription = ID
        NewButtonClose.Location = btnDONE.Location
        NewButtonClose.BackColor = btnDONE.BackColor
        NewButtonClose.ForeColor = btnDONE.ForeColor
        NewButtonClose.Font = btnDONE.Font
        NewButtonClose.Text = "X"

        AddHandler NewButtonClose.Click, AddressOf ClickClose

        NewPanel.Controls.Add(NewButtonClose)

        Dim NewLabelSERVED As New Label
        NewLabelSERVED.Name = $"lblserved{N}"
        NewLabelSERVED.BackColor = Color.White
        NewLabelSERVED.TextAlign = ContentAlignment.MiddleLeft
        NewLabelSERVED.BorderStyle = BorderStyle.FixedSingle
        NewLabelSERVED.Location = xlblSERVED.Location
        NewLabelSERVED.Font = xlblSERVED.Font
        NewLabelSERVED.Text = $"SERVING #{SERVED}"
        NewLabelSERVED.AutoSize = False
        NewLabelSERVED.Size = xlblSERVED.Size

        NewPanel.Controls.Add(NewLabelSERVED)

        Dim NewLabelTOTAL As New Label
        NewLabelTOTAL.Name = $"lbltotal{N}"
        NewLabelTOTAL.BackColor = Color.White
        NewLabelTOTAL.TextAlign = ContentAlignment.MiddleLeft
        NewLabelTOTAL.BorderStyle = BorderStyle.FixedSingle
        NewLabelTOTAL.Location = xlblTOTAL.Location
        NewLabelTOTAL.Font = xlblTOTAL.Font
        NewLabelTOTAL.Text = $"ORDER AMOUNT : {TOTAL}"
        NewLabelTOTAL.AutoSize = False
        NewLabelTOTAL.Size = xlblTOTAL.Size

        NewPanel.Controls.Add(NewLabelTOTAL)

        Dim NewLabelTime As New Label
        NewLabelTime.Name = $"lbltime{N}"
        NewLabelTime.BackColor = Color.White

        NewLabelTime.Location = xlblTIME.Location
        NewLabelTime.Font = xlblTIME.Font
        NewLabelTime.TextAlign = ContentAlignment.MiddleLeft
        NewLabelTime.BorderStyle = BorderStyle.FixedSingle
        NewLabelTime.Size = xlblTIME.Size
        NewLabelTime.AutoSize = False
        NewLabelTime.AccessibleDescription = RECORDED_TIME
        NewLabelTime.Text = "HH:MM:SS"
        NewPanel.Controls.Add(NewLabelTime)

        Dim NewDGV As New DataGridView
        NewDGV.Name = $"dgv{N}"
        NewDGV.RowHeadersVisible = False
        NewDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        NewDGV.MultiSelect = False
        NewDGV.AllowUserToAddRows = False
        NewDGV.AllowUserToDeleteRows = False

        NewDGV.AllowUserToOrderColumns = False
        NewDGV.AllowUserToResizeColumns = False
        NewDGV.AllowUserToResizeRows = False

        NewDGV.Size = dgvITEM.Size
        NewDGV.Location = dgvITEM.Location
        NewDGV.EditMode = DataGridViewEditMode.EditProgrammatically
        NewPanel.Controls.Add(NewDGV)
        '=================

        fOrderDetails(NewDGV, Payment_ID)
    End Sub

    Private Sub fOrderDetails(ByVal prDGV As DataGridView, ByVal ID As Integer)

        Dim SQL As String = $"Select i.DESCRIPTION As `MENU`,ii.QUANTITY As `QTY`,ii.RATE As `PRICE`,ii.AMOUNT FROM payment_invoices As pn inner join invoice_items As ii On ii.invoice_id = pn.invoice_id inner join item As i On i.id = ii.item_id where ii.print_in_forms = '0' and  pn.payment_id = '{ID}'  "

        fDataGridView(prDGV, SQL)
        With prDGV.Columns
            .Item("MENU").Width = 260

            .Item("QTY").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("QTY").DefaultCellStyle.Format = "N0"
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("QTY").Width = 40

            .Item("PRICE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("PRICE").DefaultCellStyle.Format = "N2"
            .Item("PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("PRICE").Width = 60

            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").Width = 80
        End With


    End Sub
    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnDONE_Click(sender As Object, e As EventArgs) Handles btnDONE.Click

    End Sub

    Private Sub btnCLOSE_Click(sender As Object, e As EventArgs) Handles btnCLOSE.Click
        Me.Close()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        fORDERLIST()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        For N As Integer = 1 To FlowLayoutPanel1.Controls.Count


            Try
                Dim PNL As Panel = FlowLayoutPanel1.Controls($"pnl{N}")
                If IsNothing(PNL) = False Then

                    Dim lblTime As Label = PNL.Controls($"lblTIME{N}")
                    If IsNothing(lblTime) = False Then

                        Dim DTR As DateTime = CDate(lblTime.AccessibleDescription)
                        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(DateDiff(DateInterval.Second, DTR, DateTime.Now))
                        lblTime.Text = "Delay : " & iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                            iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                            iSpan.Seconds.ToString.PadLeft(2, "0"c)


                    End If

                End If
            Catch ex As Exception

            End Try

        Next
    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmPOSRestoKitchenMonitoringSettings.ShowDialog()
        frmPOSRestoKitchenMonitoringSettings.Dispose()
        frmPOSRestoKitchenMonitoringSettings = Nothing
    End Sub
End Class