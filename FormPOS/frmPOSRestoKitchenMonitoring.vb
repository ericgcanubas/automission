Imports System.Data.Odbc
Public Class FrmPOSRestoKitchenMonitoring
    Public gsCloseCall As Boolean

    Private Sub FrmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        '   If gsCloseCall = True Then
        bActiveFirst = False
        FrmSplash.Show()
        FrmSplash.Timer1.Enabled = True
        gsMenuSubID = 0
        gsMenuID = 0
        Me.Dispose()
        '   End If
    End Sub
    Private Sub FrmPOSRestoKitchenMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        OrderList()
    End Sub


    Private Sub OrderList()
        Timer1.Stop()
        FlowLayoutPanel1.Controls.Clear()
        Dim N As Integer = 0
        Dim rd As OdbcDataReader = SqlReader($"SELECT 
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
            WHERE i.`NOTES` <> '' and pts.`kitchen_status` = 0 AND i.`DATE` = '{DateFormatMySql(DateTime.Now.Date)}' limit 6")

        While rd.Read
            N += 1
            Dim BG As Color
            If GF_TextIsNull(rd("NOTES")).ToString.Contains("DINE-IN") = True Then
                BG = Color.NavajoWhite
            Else
                BG = Color.Yellow
            End If

            CreateObject(N, rd("ID"), rd("payment_id"), GF_NumIsNull(rd("SHIP_TO")), NumberFormatStandard(rd("AMOUNT_APPLIED")), rd("TIME_LOG"), BG)
        End While
        rd.Close()

        Timer1.Start()

    End Sub
    Private Sub ClickClose(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim ID As Integer = btn.AccessibleDescription

        SqlExecuted($"UPDATE pos_table_served SET kitchen_status = '1' WHERE ID ='{ID}' limit 1;")
        OrderList()

    End Sub
    Private Sub CreateObject(ByVal N As Integer, ByVal ID As Integer, ByVal Payment_ID As Integer, ByVal SERVED As String, ByVal TOTAL As String, ByVal RECORDED_TIME As String, ByVal BGC As Color)
        Dim NewPanel As New Panel With {
            .BackColor = BGC,
            .Name = $"pnl{N}",
            .Font = Panel1.Font,
            .Size = Panel1.Size,
            .BorderStyle = BorderStyle.FixedSingle
        }
        FlowLayoutPanel1.Controls.Add(NewPanel)

        Dim NewButtonClose As New Button With {
            .Name = $"btn{N}",
            .Size = btnDONE.Size,
            .AccessibleDescription = ID,
            .Location = btnDONE.Location,
            .BackColor = btnDONE.BackColor,
            .ForeColor = btnDONE.ForeColor,
            .Font = btnDONE.Font,
            .Text = "X"
        }

        AddHandler NewButtonClose.Click, AddressOf ClickClose

        NewPanel.Controls.Add(NewButtonClose)

        Dim NewLabelSERVED As New Label With {
            .Name = $"lblserved{N}",
            .BackColor = Color.White,
            .TextAlign = ContentAlignment.MiddleLeft,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = xlblSERVED.Location,
            .Font = xlblSERVED.Font,
            .Text = $"SERVING #{SERVED}",
            .AutoSize = False,
            .Size = xlblSERVED.Size
        }

        NewPanel.Controls.Add(NewLabelSERVED)

        Dim NewLabelTOTAL As New Label With {
            .Name = $"lbltotal{N}",
            .BackColor = Color.White,
            .TextAlign = ContentAlignment.MiddleLeft,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = xlblTOTAL.Location,
            .Font = xlblTOTAL.Font,
            .Text = $"ORDER AMOUNT : {TOTAL}",
            .AutoSize = False,
            .Size = xlblTOTAL.Size
        }

        NewPanel.Controls.Add(NewLabelTOTAL)

        Dim NewLabelTime As New Label With {
            .Name = $"lbltime{N}",
            .BackColor = Color.White,
            .Location = xlblTIME.Location,
            .Font = xlblTIME.Font,
            .TextAlign = ContentAlignment.MiddleLeft,
            .BorderStyle = BorderStyle.FixedSingle,
            .Size = xlblTIME.Size,
            .AutoSize = False,
            .AccessibleDescription = RECORDED_TIME,
            .Text = "HH:MM:SS"
        }
        NewPanel.Controls.Add(NewLabelTime)

        Dim NewDGV As New DataGridView With {
            .Name = $"dgv{N}",
            .RowHeadersVisible = False,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
            .MultiSelect = False,
            .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
            .AllowUserToOrderColumns = False,
            .AllowUserToResizeColumns = False,
            .AllowUserToResizeRows = False,
            .Size = dgvITEM.Size,
            .Location = dgvITEM.Location,
            .EditMode = DataGridViewEditMode.EditProgrammatically
        }
        NewPanel.Controls.Add(NewDGV)
        '=================

        OrderDetails(NewDGV, Payment_ID)

    End Sub

    Private Sub OrderDetails(ByVal prDGV As DataGridView, ByVal ID As Integer)

        Dim SQL As String = $"Select i.DESCRIPTION As `MENU`,ii.QUANTITY As `QTY`,ii.RATE As `PRICE`,ii.AMOUNT FROM payment_invoices As pn inner join invoice_items As ii On ii.invoice_id = pn.invoice_id inner join item As i On i.id = ii.item_id where ii.print_in_forms = '0' and  pn.payment_id = '{ID}'  "

        GS_LoadDataGridView(prDGV, SQL)
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


    Private Sub BtnCLOSE_Click(sender As Object, e As EventArgs) Handles btnCLOSE.Click
        Me.Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnReload.Click
        OrderList()
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

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        FrmPOSRestoKitchenMonitoringSettings.ShowDialog()
        FrmPOSRestoKitchenMonitoringSettings.Dispose()
        FrmPOSRestoKitchenMonitoringSettings = Nothing
    End Sub
End Class