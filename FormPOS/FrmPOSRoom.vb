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
    Private Sub fTimeTrick()

        dgvList.Rows.Clear()
        Dim SQL As String = $"Select i.id, i.description,{INVOICE_ID_SQL} AS `invoice_id`, {INVOICE_CHECK_IN} as `CHECK_IN`, {INVOICE_CHECK_OUT}  as `CHECK_OUT`, {INVOICE_ITEM_QTY} as `HOURS`, {INVOICE_BALANCE} as `BALANCE` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' and  {INVOICE_NULL_SQL} is not null   ORDER BY i.description"
        Dim rd As OdbcDataReader = SqlReader(SQL)
        While rd.Read
            fTimeCreate(rd("id"), rd("description"), rd("invoice_id"), CDate(rd("CHECK_IN")), CDate(rd("CHECK_OUT")), rd("HOURS"), rd("BALANCE"))
        End While
        rd.Close()

    End Sub
    Private Sub fLoadRoomAll()
        gsSelectAllRoom = True
        gsSelectAvailableRoom = False
        gsSelectNotAvailableRoom = False
        flpBox.Controls.Clear()
        Dim SQL_DB As String = $"Select i.id, i.description, {INVOICE_ID_SQL} As `invoice_id`, {INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' ORDER BY i.id"
        Dim rd As OdbcDataReader = SqlReader(SQL_DB)
        While rd.Read
            fCreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
        End While
        rd.Close()
    End Sub
    Private Sub fTimeColumn()

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
    Private Sub fTimeCreate(ByVal prId As Integer, ByVal prRoom As String, ByVal prInvoice_ID As String, ByVal prIN As DateTime, ByVal prOUT As DateTime, ByVal Hrs As Integer, ByVal BALANCE As Double)

        If prOUT = "2000-12-01 12:00:00" Then

            Dim paidStatus As String = IIf(BALANCE > 0, "No", "Yes")
            dgvList.Rows.Add(prId, prRoom, prInvoice_ID, "CHECK-IN", prIN, Hrs, prIN.AddHours(Hrs), "", paidStatus)
        Else
            Dim paidStatus As String = IIf(BALANCE > 0, "No", "Yes")
            dgvList.Rows.Add(prId, prRoom, prInvoice_ID, "CHECK-OUT", prOUT, "", "", "", paidStatus)
        End If


    End Sub
    Private Sub fLoadGroup()
        Dim rd As OdbcDataReader = SqlReader($"SELECT g.`ID`,g.`DESCRIPTION` FROM item_group AS g INNER JOIN item AS i ON i.`GROUP_ID` = g.`ID` AND g.`ITEM_TYPE` = i.`TYPE` WHERE  i.`TYPE` ='{gsCheckInType}' GROUP BY g.`DESCRIPTION` order by g.ID")
        While rd.Read
            Dim tsbtn As New ToolStripButton
            tsbtn.Name = $"tsbtn{rd("id")}"
            tsbtn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
            tsbtn.TextImageRelation = TextImageRelation.ImageAboveText
            tsbtn.Image = My.Resources.ladder
            tsbtn.Tag = rd("id")
            tsbtn.Text = rd("DESCRIPTION")
            AddHandler tsbtn.Click, AddressOf tsGroupBtn_Click
            tsPanel.Items.Add(tsbtn)
            Dim tsline As New ToolStripSeparator
            tsline.Name = $"tsLine{rd("id")}"
            tsPanel.Items.Add(tsline)
        End While
        rd.Close()






    End Sub
    Private Sub tsGroupBtn_Click(sender As Object, e As EventArgs)
        Dim ts As ToolStripButton = DirectCast(sender, ToolStripButton)

        gsSelectAllRoom = False
        gsSelectAvailableRoom = False
        gsSelectNotAvailableRoom = False
        flpBox.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.id,i.description, {INVOICE_ID_SQL} AS `invoice_id`,{INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' and i.GROUP_ID ='{  NumIsNull(ts.Tag)}' AND i.inactive ='0' ORDER BY i.id")
        While rd.Read
            fCreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
        End While
        rd.Close()

    End Sub

    Private Sub fGET_POS_CREATE()





        Dim bStartNew As Boolean = False
        'POS LOG   DATE(recorded_On) ='{DateFormatMySql(gsPOS_DATE)}'
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID, RECORDED_ON,CASHIER_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and LOCATION_ID = '{gsDefault_LOCATION_ID}' and `CASH_COUNT_ID` is null ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            If gsCashier_ID <> NumIsNull(rd("CASHIER_ID")) Then
                MessageBoxExclamation("Please set cash count from last user. ")
                gsCloseCall = True
                Exit Sub
            End If

            'If NumIsNull(rd("CASH_COUNT_ID")) <> 0 Then
            '    FrmPOSLogSwitch.ShowDialog()
            '    bStartNew = FrmPOSLogSwitch.gsStartNew
            '    FrmPOSLogSwitch.Dispose()
            '    FrmPOSLogSwitch = Nothing
            'End If

            'If bStartNew = True Then
            '    GoTo NewPOS_LOG
            'End If

            gsPOS_DATE = CDate(rd("RECORDED_ON"))
            gsSTARTING_RECEIPT_NO = NumIsNull(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = NumIsNull(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = NumIsNull(rd("CASH_COUNT_ID"))

        Else

NewPOS_LOG:

            If MessageBoxPointOfSalesYesNO("Create New POS Shift log?") = True Then

                gsCASH_COUNT_ID = 0
                Dim sAMount As Double = 0
                gsSTARTING_CASH_ID = 0
                If fPOS_STARTING_CASH() = True Then
                    frmPOSStartingCash.ShowDialog()
                    sAMount = frmPOSStartingCash.gsStartAmount
                    frmPOSStartingCash.Dispose()
                    frmPOSStartingCash = Nothing
                End If

                gsSTARTING_CASH_ID = ObjectTypeMapId("POS_STARTING_CASH")
                If DateFormatMySql(gsPOS_DATE) = DateFormatMySql(Date.Now.Date) Then
                    LOG_DATE = GetDateTimeNowSql()
                Else
                    LOG_DATE = $"{DateFormatMySql(gsPOS_DATE)} 08:00:01"
                End If

                SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{sAMount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
                fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
                fPOS_LOG()

            Else
                Dim rd_temp As OdbcDataReader = SqlReader($"select * from pos_log where location_id = '{gsDefault_LOCATION_ID}' order by id desc limit 1;")
                If rd_temp.Read Then
                    If gsCashier_ID = NumIsNull(rd_temp("cashier_id")) Then

                        If MessageBoxPointOfSalesYesNO($"Do yo want to open the previous POS LOG No. {rd_temp("id")}") = True Then

                            gsPOS_DATE = CDate(rd_temp("RECORDED_ON"))
                            gsSTARTING_RECEIPT_NO = NumIsNull(rd_temp("STARTING_RECEIPT_NO"))
                            gsPOS_LOG_ID = NumIsNull(rd_temp("ID"))
                            gsSTARTING_CASH_ID = NumIsNull(rd_temp("STARTING_CASH_ID"))
                            gsENDING_RECEIPT_NO = NumIsNull(rd_temp("ENDING_RECEIPT_NO"))
                            gsCASH_COUNT_ID = NumIsNull(rd_temp("CASH_COUNT_ID"))
                        End If

                    End If
                End If

            End If
        End If
        rd.Close()

        If gsPOS_LOG_ID <> 0 Then

            fCollect_POSLog_Resto()

        End If

    End Sub
    Private Sub FrmPOSRoom_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dgvList.Height = CheckInPanelHeight

        gsHours_Item_ID = GetNumberFieldValueOneReturn($"SELECT ID from ITEM where BASE_UNIT_ID = '{gsMeasureHoursID}' limit 1;")
        If gsHours_Item_ID = 0 Then
            MessageBoxExclamation("no item hours created.")
        End If

        tsUsername.Text = gsUser_Name
        fTimeColumn()
        fLoadGroup()

        gsPOS_DEFAULT_PRINTER = fGet_System_VALUE("POS_DEFAULT_PRINTER")

        'SmallBox = CBool(Val(fGet_System_VALUE("USE_SMALL_BOX")))
        'CUSTOM_DINE_IN_NO = Val(fGet_System_VALUE("CUSTOM_DINE_IN_NO"))
        'Msg_Print_Payment = CBool(Val(fGet_System_VALUE("MSG_PRINT_PAYMENT")))
        'PRINT_INVOICE_AFTER_PRINT_PAYMENT = CBool(Val(fGet_System_VALUE("PRINT_INVOICE_AFTER_PRINT_PAYMENT")))
        'PRINT_OS_AFTER_SAVE_INVOICE = CBool(Val(fGet_System_VALUE("PRINT_OS_AFTER_SAVE_INVOICE")))

        gsPOS_MACHINE_ID = fPOS_MACHINE_ID()
        gsPOS_SERVED_ONLY = fGET_SERVED_ONLY()
        gsPOS_TYPE_ID = fPOS_machine_type_map()

        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsStorage_Location_ID = GetLoadStorageLocation()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()

        Me.AccessibleName = GetStringFieldValue("tblsub_menu", "form", "frmInvoice", "sub_id")

        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        gsPOSDefaultCustomer_ID = GetSystemSettingValueByText("POSDefaultCustomerId")
        gsPOS_RESTAURANT_TABLE_NO = GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "RESTAURANT_TABLE_NO")
        gsDRAWER_ACCOUNT_ID = GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")

        fLoadRoomAll()
        fLoadOtherMenu()

        fTimeTrick()
        Timer1.Start()
        gsPOS_LOG_ID = 0
        gsPOS_DATE = Date.Now
        fGET_POS_CREATE()


    End Sub
    Private Sub fLoadOtherMenu()

        Dim AddSalesWalkIn As New ToolStripButton
        AddSalesWalkIn.Name = $"tsAddSales"
        AddSalesWalkIn.Text = "Walk-In Entry"
        AddSalesWalkIn.Image = My.Resources.m_payment
        AddSalesWalkIn.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        AddSalesWalkIn.TextImageRelation = TextImageRelation.ImageAboveText
        AddHandler AddSalesWalkIn.Click, AddressOf Report_Click
        tsPanel.Items.Add(AddSalesWalkIn)

        Dim RoomEntryList As New ToolStripButton
        RoomEntryList.Name = $"tsList"
        RoomEntryList.Text = "Room Entry List"
        RoomEntryList.Image = My.Resources.to_do_list_icon
        RoomEntryList.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        RoomEntryList.TextImageRelation = TextImageRelation.ImageAboveText
        AddHandler RoomEntryList.Click, AddressOf Entry_List_Click
        tsPanel.Items.Add(RoomEntryList)

        Dim PaymentList As New ToolStripButton
        PaymentList.Name = $"tsPayList"
        PaymentList.Text = "Payment List"
        PaymentList.Image = My.Resources.receive_payment
        PaymentList.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText
        PaymentList.TextImageRelation = TextImageRelation.ImageAboveText
        AddHandler PaymentList.Click, AddressOf Payment_List_Click
        tsPanel.Items.Add(PaymentList)

    End Sub
    Private Sub Payment_List_Click(sender As Object, e As EventArgs)

        FrmPOSRoomPaymentList.ShowDialog()

        FrmPOSRoomPaymentList.Dispose()
        FrmPOSRoomPaymentList = Nothing
        If gsGotChangeData = True Then
            fPreviewRefresh()
        End If


    End Sub
    Private Sub Entry_List_Click(sender As Object, e As EventArgs)

        FrmPOSRoomEntryList.ShowDialog()
        FrmPOSRoomEntryList.Dispose()
        FrmPOSRoomEntryList = Nothing

        fPreviewRefresh()

    End Sub
    Private Sub Report_Click(sender As Object, e As EventArgs)
        frmPOSRoomDetails.ID = 0
        frmPOSRoomDetails.IsNew = True
        frmPOSRoomDetails.Text = "Walk-In Cusomter"
        frmPOSRoomDetails.gsWalkInCustomer = True
        frmPOSRoomDetails.ShowDialog()
        frmPOSRoomDetails.Dispose()
        frmPOSRoomDetails = Nothing
    End Sub


    Private Sub fLoadRoomAvailable()
        gsSelectAllRoom = False
        gsSelectAvailableRoom = True
        gsSelectNotAvailableRoom = False
        flpBox.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.id,i.description,{INVOICE_ID_SQL} AS `invoice_id`,{INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' ORDER BY i.description")
        While rd.Read
            If TextIsNull(rd("Invoice_id")) = "0" Then
                fCreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
            End If

        End While
        rd.Close()
    End Sub
    Private Sub fLoadRoomNotAvailable()
        gsSelectAllRoom = False
        gsSelectAvailableRoom = False
        gsSelectNotAvailableRoom = True
        flpBox.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT i.id,i.description, {INVOICE_ID_SQL} AS `invoice_id`, {INVOICE_CHECK_OUT} as `CHECK_OUT` FROM item AS i WHERE i.type ='10' AND i.inactive ='0' ORDER BY i.description")
        While rd.Read
            If TextIsNull(rd("Invoice_id")) <> "0" Then
                fCreateRoom(rd("id"), rd("description"), rd("Invoice_id"), rd("CHECK_OUT"))
            End If
        End While
        rd.Close()
    End Sub
    Private Sub fCreateRoom(ByVal prId As Integer, ByVal prDescription As String, ByVal Invoice_ID As String, ByVal CHK_OUT As DateTime)
        Dim btn As New Button
        btn.Name = btnRoom.Text & prId
        btn.AccessibleName = prId
        btn.Text = prDescription
        btn.Size = btnRoom.Size
        btn.Font = btnRoom.Font
        btn.FlatStyle = btnRoom.FlatStyle
        btn.Image = My.Resources.room_tag
        btn.ImageAlign = ContentAlignment.TopCenter
        btn.TextAlign = ContentAlignment.BottomCenter '
        btn.Tag = Invoice_ID
        If CHK_OUT = "2000-12-01 12:00:00" Then


            If Invoice_ID = 0 Then
                btn.BackColor = Color.DarkTurquoise
                btn.ForeColor = Color.Black
            Else
                btn.BackColor = Color.Crimson
                btn.ForeColor = Color.White

            End If
            AddHandler btn.Click, AddressOf btnRoom_Click

        Else

            AddHandler btn.Click, AddressOf btnSetAsAvailable_Click

            btn.BackColor = Color.Blue
            btn.ForeColor = Color.White
        End If


        flpBox.Controls.Add(btn)




    End Sub
    Private Sub btnSetAsAvailable_Click(sender As Object, e As EventArgs)
        If MessageBoxPointOfSalesYesNO("Do you want to set as Available?") = True Then
            Dim btn As Button = DirectCast(sender, Button)
            SqlExecuted($"UPDATE invoice SET `CUSTOM_FIELD3` = '{GetDateTimeNowSql()}',`DEALER_ID`='{gsPOS_LOG_ID}'  WHERE `ID`= '{Val(btn.Tag)}' limit 1; ")
            fPreviewRefresh()
        End If
    End Sub
    Private Sub btnRoom_Click(sender As Object, e As EventArgs)

        Dim btn As Button = DirectCast(sender, Button)
        gsDocument_Finder_ID = Val(btn.Tag)
        frmPOSRoomDetails.Text = btn.Text
        frmPOSRoomDetails.gsRoomID = Val(btn.AccessibleName)
        frmPOSRoomDetails.gsCHECK_IN = gsCheckInType
        frmPOSRoomDetails.ShowDialog()


        frmPOSRoomDetails.Dispose()
        frmPOSRoomDetails = Nothing
        If gsGotChangeData = True Then
            fPreviewRefresh()
        End If


    End Sub


    Private Sub fPreviewRefresh()
        If gsSelectAllRoom = True Then
            fLoadRoomAll()
        ElseIf gsSelectAvailableRoom = True Then
            fLoadRoomAvailable()
        ElseIf gsSelectNotAvailableRoom = True Then
            fLoadRoomNotAvailable()
        End If

        fTimeTrick()
    End Sub
    Private Sub FrmPOSRoom_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


        If gsCloseCall = True Then
            bActiveFirst = False
            frmSplash.Show()
            frmSplash.Timer1.Enabled = True
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

    Private Sub tsExit_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsAllRoom_Click(sender As Object, e As EventArgs) Handles tsAllRoom.Click
        fLoadRoomAll()
    End Sub

    Private Sub tsAvailableRoom_Click(sender As Object, e As EventArgs) Handles tsAvailableRoom.Click
        fLoadRoomAvailable()
    End Sub

    Private Sub tsNotAvailableRoom_Click(sender As Object, e As EventArgs) Handles tsNotAvailableRoom.Click
        fLoadRoomNotAvailable()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick


        For N As Integer = 0 To dgvList.Rows.Count - 1
            With dgvList.Rows(N)

                Try
                    If .Cells("STATUS").Value = "CHECK-IN" Then
                        fCountDownTime(N, CDate(.Cells("time_out").Value))
                    ElseIf .Cells("STATUS").Value = "CHECK-OUT" Then
                        fRunningTime(N, CDate(.Cells("TIME_STATUS").Value))
                    End If


                Catch ex As Exception
                    dgvList.Rows(N).Cells("time_remain").Value = "00:00:00"
                End Try

            End With


        Next


    End Sub
    Private Sub fRunningTime(ByVal N As Integer, ByVal prTimeOut As DateTime)
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
    Private Sub fCountDownTime(ByVal N As Integer, ByVal prTimeOut As DateTime)
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
    Private Sub fOpenRoom()
        If dgvList.Rows.Count <> 0 Then

            With dgvList.CurrentRow
                Dim Room_ID As Integer = .Cells("ID").Value
                Dim INVOICE_ID As Integer = .Cells("invoice_id").Value
                If .Cells("STATUS").Value = "CHECK-IN" Then
                    gsDocument_Finder_ID = INVOICE_ID
                    frmPOSRoomDetails.Text = .Cells("description").Value

                    frmPOSRoomDetails.gsRoomID = Room_ID
                    frmPOSRoomDetails.gsCHECK_IN = gsCheckInType
                    frmPOSRoomDetails.ShowDialog()


                    frmPOSRoomDetails.Dispose()
                    frmPOSRoomDetails = Nothing
                    If gsGotChangeData = True Then
                        fPreviewRefresh()
                    End If
                ElseIf .Cells("STATUS").Value = "CHECK-OUT" Then

                    If MessageBoxPointOfSalesYesNO("Do you want to set as Available?") = True Then

                        SqlExecuted($"UPDATE invoice SET `CUSTOM_FIELD3` = '{GetDateTimeNowSql()}',`DEALER_ID`='{gsPOS_LOG_ID}'  WHERE `ID`= '{INVOICE_ID}' limit 1; ")
                        fPreviewRefresh()
                    End If

                End If


            End With
        End If
    End Sub
    Private Sub dgvList_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellContentClick

    End Sub

    Private Sub dgvList_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvList.CellDoubleClick
        fOpenRoom()
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

    Private Sub tsMenu_Click(sender As Object, e As EventArgs) Handles tsMenu.Click

        frmPOSRoomLog.ShowDialog()
        frmPOSRoomLog.Dispose()
        frmPOSRoomLog = Nothing

        If gsCloseCall = True Then
            Me.Close()
        End If

    End Sub

    Private Sub tsDown_Click(sender As Object, e As EventArgs) Handles tsDown.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If
            dgvList.Select()
            dgvList.CurrentCell = dgvList.Rows(fCheckingGotVisibleIndex(False)).Cells("DESCRIPTION")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tsUp_Click(sender As Object, e As EventArgs) Handles tsUp.Click
        Try
            If dgvList.Rows.Count = 0 Then
                Exit Sub
            End If

            dgvList.Select()

            dgvList.CurrentCell = dgvList.Rows(fCheckingGotVisibleIndex(True)).Cells("DESCRIPTION")
        Catch ex As Exception

        End Try

    End Sub
    Public Function fCheckingGotVisibleIndex(ByVal isUp As Boolean) As Integer
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

    Private Sub tsShowRoom_Click(sender As Object, e As EventArgs) Handles tsShowRoom.Click
        fOpenRoom()
    End Sub
End Class