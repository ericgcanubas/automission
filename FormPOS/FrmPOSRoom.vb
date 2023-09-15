Imports System.Data.Odbc
Public Class FrmPOSRoom

    Dim CheckInPanelHeight As Integer = 204
    Dim TimeWarning_Mins As Integer = 9
    Dim gsSelectAllRoom As Boolean = False
    Dim gsSelectAvailableRoom As Boolean = False
    Dim gsSelectNotAvailableRoom As Boolean = False
    Dim gsCheckInType As Integer = 10
    Dim INVOICE_ID_SQL As String = $" IFNULL((SELECT  ifnull(n.id,0)  FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id WHERE ni.item_id = i.`ID`  AND n.`CUSTOM_FIELD3` is null LIMIT 1),0) "
    Dim INVOICE_NULL_SQL As String = $" IFNULL((SELECT ifnull(n.CUSTOM_FIELD2, ifnull(n.id,NULL))  FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id WHERE ni.item_id = i.`ID`  AND n.`CUSTOM_FIELD3` is null LIMIT 1),NULL) "

    Dim INVOICE_CHECK_IN As String = $" IFNULL((SELECT concat(n.Date ,' ', n.CUSTOM_FIELD1) as `CHECK_IN`  FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id WHERE ni.item_id = i.`ID`  AND n.CUSTOM_FIELD3 is null  LIMIT 1),'') "
    Dim INVOICE_CHECK_OUT As String = $" IFNULL((SELECT concat(n.DISCOUNT_DATE ,' ', n.CUSTOM_FIELD2) as `CHECK_OUT`  FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id WHERE ni.item_id = i.`ID`  AND n.CUSTOM_FIELD3 is null  LIMIT 1),'2000-12-01 12:00:00') "
    Dim INVOICE_ITEM_QTY As String = $" IFNULL((SELECT sum(t.QUANTITY) FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id inner join invoice_items as t on t.invoice_id = n.id   WHERE t.UNIT_ID ='{gsMeasureHoursID}' and ni.item_id = i.`ID`  AND n.ship_via_id = '{gsCheckInType}'),0) "
    Dim INVOICE_BALANCE As String = $"IFNULL((SELECT  n.BALANCE_DUE  FROM  invoice AS n  INNER JOIN invoice_items AS ni ON  ni.invoice_id = n.id WHERE ni.item_id = i.`ID`  AND n.ship_via_id = '{gsCheckInType}' LIMIT 1),'0')"

    Public gsCloseCall As Boolean = False
    Private Sub TimeTrick()

        dgvList.Rows.Clear()
        Dim SQL As String = $"Select i.id, i.description,{INVOICE_ID_SQL} AS `invoice_id`, {INVOICE_CHECK_IN} as `CHECK_IN`, {INVOICE_CHECK_OUT}  as `CHECK_OUT`, {INVOICE_ITEM_QTY} as `HOURS`, {INVOICE_BALANCE} as `BALANCE` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' and  {INVOICE_NULL_SQL} is not null   ORDER BY i.description"
        Dim rd As OdbcDataReader = SqlReader(SQL)
        While rd.Read
            TimeCreate(rd("id"), rd("description"), rd("invoice_id"), CDate(rd("CHECK_IN")), CDate(rd("CHECK_OUT")), rd("HOURS"), rd("BALANCE"))
        End While
        rd.Close()

    End Sub
    Private Sub LoadRoomAll()
        gsSelectAllRoom = True
        gsSelectAvailableRoom = False
        gsSelectNotAvailableRoom = False
        flpBox.Controls.Clear()
        Dim SQL_DB As String = $"Select i.id, i.description, {INVOICE_ID_SQL} As `invoice_id`, {INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' ORDER BY i.id"
        Dim rd As OdbcDataReader = SqlReader(SQL_DB)
        While rd.Read
            CreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
        End While
        rd.Close()
    End Sub
    Private Sub TimeColumn()

        With dgvList.Columns

            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("DESCRIPTION", "Rooms")
            .Item("DESCRIPTION").Width = 270
            .Add("invoice_id", "invoice_id")
            .Item("invoice_id").Visible = False
            .Add("status", "Status")
            .Item("status").Width = 150
            .Add("TIME_STATUS", "TIME")
            .Item("TIME_STATUS").Width = 250
            .Add("hours", "No. Hours")
            .Item("hours").Width = 150
            .Item("hours").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("hours").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("TIME_OUT", "Time Out")
            .Item("TIME_OUT").Width = 250
            .Add("TIME_REMAIN", "Interval")
            .Item("TIME_REMAIN").Width = 100
            .Item("TIME_REMAIN").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("TIME_REMAIN").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("paid", "Paid")
            .Item("paid").Width = 50
        End With


    End Sub
    Private Sub TimeCreate(ByVal prId As Integer, ByVal prRoom As String, ByVal prInvoice_ID As String, ByVal prIN As DateTime, ByVal prOUT As DateTime, ByVal Hrs As Integer, ByVal BALANCE As Double)

        If prOUT = "2000-12-01 12:00:00" Then

            Dim paidStatus As String = IIf(BALANCE > 0, "No", "Yes")
            dgvList.Rows.Add(prId, prRoom, prInvoice_ID, "CHECK-IN", prIN, Hrs, prIN.AddHours(Hrs), "", paidStatus)
        Else
            Dim paidStatus As String = IIf(BALANCE > 0, "No", "Yes")
            dgvList.Rows.Add(prId, prRoom, prInvoice_ID, "CHECK-OUT", prOUT, "", "", "", paidStatus)
        End If


    End Sub
    Private Sub LoadGroup()
        Dim rd As OdbcDataReader = SqlReader($"SELECT g.`ID`,g.`DESCRIPTION` FROM item_group AS g INNER JOIN item AS i ON i.`GROUP_ID` = g.`ID` AND g.`ITEM_TYPE` = i.`TYPE` WHERE  i.`TYPE` ='{gsCheckInType}' GROUP BY g.`DESCRIPTION` order by g.ID")
        While rd.Read
            Dim tsbtn As New ToolStripButton With {
                .Name = $"tsbtn{rd("id")}",
                .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
                .TextImageRelation = TextImageRelation.ImageAboveText,
                .Image = My.Resources.ladder,
                .Tag = rd("id"),
                .Text = rd("DESCRIPTION")
            }
            AddHandler tsbtn.Click, AddressOf TsGroupBtn_Click
            tsPanel.Items.Add(tsbtn)
            Dim tsline As New ToolStripSeparator With {
                .Name = $"tsLine{rd("id")}"
            }
            tsPanel.Items.Add(tsline)
        End While
        rd.Close()






    End Sub
    Private Sub TsGroupBtn_Click(sender As Object, e As EventArgs)
        Dim ts As ToolStripButton = DirectCast(sender, ToolStripButton)

        gsSelectAllRoom = False
        gsSelectAvailableRoom = False
        gsSelectNotAvailableRoom = False
        flpBox.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.id,i.description, {INVOICE_ID_SQL} AS `invoice_id`,{INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' and i.GROUP_ID ='{  GF_NumIsNull(ts.Tag)}' AND i.inactive ='0' ORDER BY i.id")
        While rd.Read
            CreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
        End While
        rd.Close()

    End Sub

    Private Sub GetPosCreate()

        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID, RECORDED_ON,CASHIER_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and LOCATION_ID = '{gsDefault_LOCATION_ID}' and `CASH_COUNT_ID` is null ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            If gsCashier_ID <> GF_NumIsNull(rd("CASHIER_ID")) Then
                MessageBoxExclamation("Please set cash count from last user. ")
                gsCloseCall = True
                Exit Sub
            End If

            gsPOS_DATE = CDate(rd("RECORDED_ON"))
            gsSTARTING_RECEIPT_NO = GF_NumIsNull(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = GF_NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = GF_NumIsNull(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = GF_NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = GF_NumIsNull(rd("CASH_COUNT_ID"))

        Else

NewPOS_LOG:

            If MessageBoxPointOfSalesYesNO("Create New POS Shift log?") = True Then

                gsCASH_COUNT_ID = 0
                Dim sAMount As Double = 0
                gsSTARTING_CASH_ID = 0
                If GF_PosStartingCash() = True Then
                    FrmPOSStartingCash.ShowDialog()
                    sAMount = FrmPOSStartingCash.gsStartAmount
                    FrmPOSStartingCash.Dispose()
                    FrmPOSStartingCash = Nothing
                End If

                gsSTARTING_CASH_ID = ObjectTypeMapId("POS_STARTING_CASH")
                If DateFormatMySql(gsPOS_DATE) = DateFormatMySql(Date.Now.Date) Then
                    LOG_DATE = GetDateTimeNowSql()
                Else
                    LOG_DATE = $"{DateFormatMySql(gsPOS_DATE)} 08:00:01"
                End If

                SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{sAMount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
                fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
                GS_PosLogLoad()

            Else
                Dim rd_temp As OdbcDataReader = SqlReader($"select * from pos_log where location_id = '{gsDefault_LOCATION_ID}' order by id desc limit 1;")
                If rd_temp.Read Then
                    If gsCashier_ID = GF_NumIsNull(rd_temp("cashier_id")) Then

                        If MessageBoxPointOfSalesYesNO($"Do yo want to open the previous POS LOG No. {rd_temp("id")}") = True Then

                            gsPOS_DATE = CDate(rd_temp("RECORDED_ON"))
                            gsSTARTING_RECEIPT_NO = GF_NumIsNull(rd_temp("STARTING_RECEIPT_NO"))
                            gsPOS_LOG_ID = GF_NumIsNull(rd_temp("ID"))
                            gsSTARTING_CASH_ID = GF_NumIsNull(rd_temp("STARTING_CASH_ID"))
                            gsENDING_RECEIPT_NO = GF_NumIsNull(rd_temp("ENDING_RECEIPT_NO"))
                            gsCASH_COUNT_ID = GF_NumIsNull(rd_temp("CASH_COUNT_ID"))
                        End If

                    End If
                End If

            End If
        End If
        rd.Close()

        If gsPOS_LOG_ID <> 0 Then

            GS_CollectPosLogResto()

        End If

    End Sub
    Private Sub FrmPOSRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvList.Height = CheckInPanelHeight

        gsHours_Item_ID = GF_GetNumberFieldValueOneReturn($"SELECT ID from ITEM where BASE_UNIT_ID = '{gsMeasureHoursID}' limit 1;")
        If gsHours_Item_ID = 0 Then
            MessageBoxExclamation("no item hours created.")
        End If

        tsUsername.Text = gsUser_Name
        TimeColumn()
        LoadGroup()

        gsPOS_DEFAULT_PRINTER = GetDBAccessValueByText("POS_DEFAULT_PRINTER")

        'SmallBox = CBool(Val(GetDBAccessValueByText("USE_SMALL_BOX")))
        'CUSTOM_DINE_IN_NO = Val(GetDBAccessValueByText("CUSTOM_DINE_IN_NO"))
        'Msg_Print_Payment = CBool(Val(GetDBAccessValueByText("MSG_PRINT_PAYMENT")))
        'PRINT_INVOICE_AFTER_PRINT_PAYMENT = CBool(Val(GetDBAccessValueByText("PRINT_INVOICE_AFTER_PRINT_PAYMENT")))
        'PRINT_OS_AFTER_SAVE_INVOICE = CBool(Val(GetDBAccessValueByText("PRINT_OS_AFTER_SAVE_INVOICE")))

        gsPOS_MACHINE_ID = GF_GetPosMachineId()
        gsPOS_SERVED_ONLY = GS_IsServedOnly()
        gsPOS_TYPE_ID = GF_PosMachineTypeMap()

        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsStorage_Location_ID = GetLoadStorageLocation()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()

        Me.AccessibleName = GF_GetStringFieldValue("tblsub_menu", "form", "frmInvoice", "sub_id")

        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        gsPOSDefaultCustomer_ID = GetSystemSettingValueByText("POSDefaultCustomerId")
        gsPOS_RESTAURANT_TABLE_NO = GF_GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "RESTAURANT_TABLE_NO")
        gsDRAWER_ACCOUNT_ID = GF_GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")

        LoadRoomAll()
        LoadOtherMenu()

        TimeTrick()
        Timer1.Start()
        gsPOS_LOG_ID = 0
        gsPOS_DATE = Date.Now
        GetPosCreate()


    End Sub
    Private Sub LoadOtherMenu()
        Dim AddSalesWalkIn As New ToolStripButton With {
            .Name = $"tsAddSales",
            .Text = "Walk-In Entry",
            .Image = My.Resources.m_payment,
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
            .TextImageRelation = TextImageRelation.ImageAboveText
        }
        AddHandler AddSalesWalkIn.Click, AddressOf Report_Click
        tsPanel.Items.Add(AddSalesWalkIn)

        Dim RoomEntryList As New ToolStripButton With {
            .Name = $"tsList",
            .Text = "Room Entry List",
            .Image = My.Resources.to_do_list_icon,
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
            .TextImageRelation = TextImageRelation.ImageAboveText
        }
        AddHandler RoomEntryList.Click, AddressOf Entry_List_Click
        tsPanel.Items.Add(RoomEntryList)

        Dim PaymentList As New ToolStripButton With {
            .Name = $"tsPayList",
            .Text = "Payment List",
            .Image = My.Resources.receive_payment,
            .DisplayStyle = ToolStripItemDisplayStyle.ImageAndText,
            .TextImageRelation = TextImageRelation.ImageAboveText
        }
        AddHandler PaymentList.Click, AddressOf Payment_List_Click
        tsPanel.Items.Add(PaymentList)

    End Sub
    Private Sub Payment_List_Click(sender As Object, e As EventArgs)

        FrmPOSRoomPaymentList.ShowDialog()

        FrmPOSRoomPaymentList.Dispose()
        FrmPOSRoomPaymentList = Nothing
        If gsGotChangeData = True Then
            PreviewRefresh()
        End If


    End Sub
    Private Sub Entry_List_Click(sender As Object, e As EventArgs)

        FrmPOSRoomEntryList.ShowDialog()
        FrmPOSRoomEntryList.Dispose()
        FrmPOSRoomEntryList = Nothing

        PreviewRefresh()

    End Sub
    Private Sub Report_Click(sender As Object, e As EventArgs)
        FrmPOSRoomDetails.ID = 0
        FrmPOSRoomDetails.IsNew = True
        FrmPOSRoomDetails.Text = "Walk-In Cusomter"
        FrmPOSRoomDetails.gsWalkInCustomer = True
        FrmPOSRoomDetails.ShowDialog()
        FrmPOSRoomDetails.Dispose()
        FrmPOSRoomDetails = Nothing
    End Sub


    Private Sub LoadRoomAvailable()
        gsSelectAllRoom = False
        gsSelectAvailableRoom = True
        gsSelectNotAvailableRoom = False
        flpBox.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.id,i.description,{INVOICE_ID_SQL} AS `invoice_id`,{INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' ORDER BY i.description")
        While rd.Read
            If GF_TextIsNull(rd("Invoice_id")) = "0" Then
                CreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
            End If

        End While
        rd.Close()
    End Sub
    Private Sub LoadRoomNotAvailable()
        gsSelectAllRoom = False
        gsSelectAvailableRoom = False
        gsSelectNotAvailableRoom = True
        flpBox.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.id,i.description, {INVOICE_ID_SQL} AS `invoice_id`, {INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' ORDER BY i.description")
        While rd.Read
            If GF_TextIsNull(rd("Invoice_id")) <> "0" Then
                CreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
            End If
        End While
        rd.Close()
    End Sub
    Private Sub CreateRoom(ByVal prId As Integer, ByVal prDescription As String, ByVal Invoice_ID As String, ByVal CHK_OUT As DateTime)
        Dim btn As New Button With {
            .Name = btnRoom.Text & prId,
            .AccessibleName = prId,
            .Text = prDescription,
            .Size = btnRoom.Size,
            .Font = btnRoom.Font,
            .FlatStyle = btnRoom.FlatStyle,
            .Image = My.Resources.room_tag,
            .ImageAlign = ContentAlignment.TopCenter,
            .TextAlign = ContentAlignment.BottomCenter, '
            .Tag = Invoice_ID
        }
        If CHK_OUT = "2000-12-01 12:00:00" Then


            If Invoice_ID = 0 Then
                btn.BackColor = Color.DarkTurquoise
                btn.ForeColor = Color.Black
            Else
                btn.BackColor = Color.Crimson
                btn.ForeColor = Color.White

            End If
            AddHandler btn.Click, AddressOf BtnRoom_Click

        Else

            AddHandler btn.Click, AddressOf BtnSetAsAvailable_Click

            btn.BackColor = Color.Blue
            btn.ForeColor = Color.White
        End If


        flpBox.Controls.Add(btn)




    End Sub
    Private Sub BtnSetAsAvailable_Click(sender As Object, e As EventArgs)
        If MessageBoxPointOfSalesYesNO("Do you want to set as Available?") = True Then
            Dim btn As Button = DirectCast(sender, Button)
            SqlExecuted($"UPDATE invoice SET `CUSTOM_FIELD3` = '{GetDateTimeNowSql()}',`DEALER_ID`='{gsPOS_LOG_ID}'  WHERE `ID`= '{Val(btn.Tag)}' limit 1; ")
            PreviewRefresh()
        End If
    End Sub
    Private Sub BtnRoom_Click(sender As Object, e As EventArgs)

        Dim btn As Button = DirectCast(sender, Button)
        gsDocument_Finder_ID = Val(btn.Tag)
        FrmPOSRoomDetails.Text = btn.Text
        FrmPOSRoomDetails.gsRoomID = Val(btn.AccessibleName)
        FrmPOSRoomDetails.gsCHECK_IN = gsCheckInType
        FrmPOSRoomDetails.ShowDialog()


        FrmPOSRoomDetails.Dispose()
        FrmPOSRoomDetails = Nothing
        If gsGotChangeData = True Then
            PreviewRefresh()
        End If


    End Sub


    Private Sub PreviewRefresh()
        If gsSelectAllRoom = True Then
            LoadRoomAll()
        ElseIf gsSelectAvailableRoom = True Then
            LoadRoomAvailable()
        ElseIf gsSelectNotAvailableRoom = True Then
            LoadRoomNotAvailable()
        End If

        TimeTrick()
    End Sub
    Private Sub FrmPOSRoom_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            FrmSplash.Show()
            FrmSplash.Timer1.Enabled = True
            gsMenuSubID = 0
            gsMenuID = 0
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmPOSRoom_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub
    Private Sub TsAllRoom_Click(sender As Object, e As EventArgs) Handles tsAllRoom.Click
        LoadRoomAll()
    End Sub

    Private Sub TsAvailableRoom_Click(sender As Object, e As EventArgs) Handles tsAvailableRoom.Click
        LoadRoomAvailable()
    End Sub

    Private Sub TsNotAvailableRoom_Click(sender As Object, e As EventArgs) Handles tsNotAvailableRoom.Click
        LoadRoomNotAvailable()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        For N As Integer = 0 To dgvList.Rows.Count - 1
            With dgvList.Rows(N)

                Try
                    If .Cells("STATUS").Value = "CHECK-IN" Then
                        CountDownTime(N, CDate(.Cells("time_out").Value))
                    ElseIf .Cells("STATUS").Value = "CHECK-OUT" Then
                        RunningTime(N, CDate(.Cells("TIME_STATUS").Value))
                    End If


                Catch ex As Exception
                    dgvList.Rows(N).Cells("time_remain").Value = "00:00:00"
                End Try

            End With


        Next


    End Sub
    Private Sub RunningTime(ByVal N As Integer, ByVal prTimeOut As DateTime)
        Try
            Dim iSpan As TimeSpan = TimeSpan.FromSeconds(DateDiff(DateInterval.Second, prTimeOut, DateTime.Now))
            Dim xTimeValue As String
            If DateDiff(DateInterval.Second, prTimeOut, DateTime.Now) > 0 Then
                xTimeValue = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                       iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                       iSpan.Seconds.ToString.PadLeft(2, "0"c)
            Else
                xTimeValue = "00:00:00"
            End If

            dgvList.Rows(N).Cells("time_remain").Value = xTimeValue

            If iSpan.Hours <= 0 And (iSpan.Minutes) <= TimeWarning_Mins Then

                dgvList.Rows(N).DefaultCellStyle.ForeColor = Color.Yellow
                dgvList.Rows(N).DefaultCellStyle.BackColor = Color.Blue
                dgvList.Rows(N).DefaultCellStyle.SelectionForeColor = Color.Yellow
                dgvList.Rows(N).DefaultCellStyle.SelectionBackColor = Color.Blue
            Else
                dgvList.Rows(N).DefaultCellStyle.ForeColor = Color.Yellow
                dgvList.Rows(N).DefaultCellStyle.BackColor = Color.DarkBlue
                dgvList.Rows(N).DefaultCellStyle.SelectionForeColor = Color.Yellow
                dgvList.Rows(N).DefaultCellStyle.SelectionBackColor = Color.DarkBlue
            End If

        Catch ex As Exception
            dgvList.Rows(N).Cells("time_remain").Value = "00:00:00"
        End Try

    End Sub
    Private Sub CountDownTime(ByVal N As Integer, ByVal prTimeOut As DateTime)
        Try
            Dim iSpan As TimeSpan = TimeSpan.FromSeconds(DateDiff(DateInterval.Second, DateTime.Now, prTimeOut))
            Dim xTimeValue As String
            If DateDiff(DateInterval.Second, DateTime.Now, prTimeOut) > 0 Then
                xTimeValue = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                       iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                       iSpan.Seconds.ToString.PadLeft(2, "0"c)
            Else
                xTimeValue = "00:00:00"
            End If

            dgvList.Rows(N).Cells("time_remain").Value = xTimeValue

            If iSpan.Hours <= 0 And (iSpan.Minutes) <= TimeWarning_Mins Then

                dgvList.Rows(N).DefaultCellStyle.ForeColor = Color.Yellow
                dgvList.Rows(N).DefaultCellStyle.BackColor = Color.Maroon

            Else
                dgvList.Rows(N).DefaultCellStyle.ForeColor = Color.Black
                dgvList.Rows(N).DefaultCellStyle.BackColor = flpBox.BackColor
            End If

        Catch ex As Exception
            dgvList.Rows(N).Cells("time_remain").Value = "00:00:00"
        End Try


    End Sub
    Private Sub OpenRoom()
        If dgvList.Rows.Count <> 0 Then

            With dgvList.CurrentRow
                Dim Room_ID As Integer = .Cells("ID").Value
                Dim INVOICE_ID As Integer = .Cells("invoice_id").Value
                If .Cells("STATUS").Value = "CHECK-IN" Then
                    gsDocument_Finder_ID = INVOICE_ID
                    FrmPOSRoomDetails.Text = .Cells("description").Value

                    FrmPOSRoomDetails.gsRoomID = Room_ID
                    FrmPOSRoomDetails.gsCHECK_IN = gsCheckInType
                    FrmPOSRoomDetails.ShowDialog()


                    FrmPOSRoomDetails.Dispose()
                    FrmPOSRoomDetails = Nothing
                    If gsGotChangeData = True Then
                        PreviewRefresh()
                    End If
                ElseIf .Cells("STATUS").Value = "CHECK-OUT" Then

                    If MessageBoxPointOfSalesYesNO("Do you want to set as Available?") = True Then

                        SqlExecuted($"UPDATE invoice SET `CUSTOM_FIELD3` = '{GetDateTimeNowSql()}',`DEALER_ID`='{gsPOS_LOG_ID}'  WHERE `ID`= '{INVOICE_ID}' limit 1; ")
                        PreviewRefresh()
                    End If

                End If


            End With
        End If
    End Sub
    Private Sub DgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        OpenRoom()
    End Sub

    Private Sub FrmPOSRoom_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        gsCloseCall = False

        If gsPOS_LOG_ID <> 0 Then
            tsMenu.PerformClick()
        Else
            gsCloseCall = True
            Me.Close()
        End If


    End Sub

    Private Sub TsMenu_Click(sender As Object, e As EventArgs) Handles tsMenu.Click

        FrmPOSRoomLog.ShowDialog()
        FrmPOSRoomLog.Dispose()
        FrmPOSRoomLog = Nothing

        If gsCloseCall = True Then
            Me.Close()
        End If

    End Sub

    Private Sub TsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(GetVisibleIndex(False)).Cells("DESCRIPTION")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvList.Select()

            dgvList.CurrentCell = dgvList.Rows(GetVisibleIndex(True)).Cells("DESCRIPTION")
        Catch ex As Exception

        End Try

    End Sub
    Public Function GetVisibleIndex(ByVal isUp As Boolean) As Integer
        Dim This_number As Integer = dgvList.CurrentRow.Index
        Dim Current As Integer = dgvList.CurrentRow.Index
        If isUp = True Then

            For N As Integer = Current To 0 Step -1
                If dgvList.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If

            Next


        Else
            For N As Integer = Current To dgvList.Rows.Count - 1
                If dgvList.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If
            Next
        End If

        Return This_number
    End Function

    Private Sub TsShowRoom_Click(sender As Object, e As EventArgs) Handles tsShowRoom.Click
        OpenRoom()
    End Sub
End Class