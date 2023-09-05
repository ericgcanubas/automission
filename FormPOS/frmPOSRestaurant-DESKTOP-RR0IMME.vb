Public Class frmPOSRestaurant
    Public gsJustClick As Boolean = False
    Public gsMemberDiscount As Double = 0
    Public gsID As Integer = 0
    Dim bNewContact As Boolean = False
    Public gsIsOrder As Boolean = True
    Public gsTableSelect As Integer = 1
    Public gsNew As Boolean = False
    Dim bRefreshItem As Boolean = False
    Dim bEntryAddItem As Boolean = False
    Dim f As Form = New frmFindDocument
    Public gsCloseCall As Boolean = False
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Dim SelectTable As Boolean = False
    Public gsPOS_SERVED_ONLY As Boolean = True
    Public gsNO_DINEIN As Integer = 0
    Public gsNO_TAKEOUT As Integer = 0
    Public gsNO_DELIVERY As Integer = 0
    Dim Ship_Via_count As Integer = 0

    Private Sub frmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            frmSplash.Show()
            frmSplash.Timer1.Enabled = True
            gsMenuSubID = ""
            gsMenuID = ""
            Me.Dispose()
        End If
    End Sub

    Private Sub frmPOSOrderEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub dgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        tsCOUNT.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf fdgvChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub POS_Rest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = gsIcon
        pcLOGO.BackgroundImage = gsImageNameApp
        pcLOGO.BackgroundImageLayout = ImageLayout.Stretch
        fBackGroundImageStyle(Me)
        pnlTOP.BackColor = Color.Transparent
        FlowLayoutPanel1.BorderStyle = BorderStyle.None

        fLabel_Digital_L(lblAMOUNT)
        fLabel_Digital_L(xlblTOTAL)
        fLabel_Digital_M(lblOUTPUT_TAX_AMOUNT)

        gsPOS_MACHINE_ID = fPOS_MACHINE_ID()
        gsPOS_SERVED_ONLY = fGET_SERVED_ONLY()
        gsPOS_TYPE_ID = fPOS_machine_type_map()

        If gsPOS_SERVED_ONLY = True Then
            btnPRINTBILL.Visible = False
            btnCreatePayment.Visible = False
            btnPRINTBILL_Fake.Visible = True
            btnCreatePayment_Fake.Visible = True
            pnlOP.Visible = False
            btnPRINTOS.Visible = False

            btnPRINTBILL_Fake.Text = btnPRINTOS.Text
            btnPRINTBILL_Fake.BackColor = btnPRINTOS.BackColor
            btnPRINTBILL_Fake.Image = btnPRINTOS.Image

        Else

        End If









        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = fLoadLocationDefault()
        gsStorage_Location_ID = fLoadStorageLocation()
        gsIncRefNoByLocation = fIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
        fDefaultAccountLoad()
        Me.AccessibleName = fGetFieldValue("tblsub_menu", "form", "frmSalesOrder", "sub_id")
        gsPETTY_CASH_ACCOUNT_ID = fPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = fCashOverShortExpense()
        gsPOSDefaultCustomer_ID = fSystemSettingValue("POSDefaultCustomerId")
        gsPOS_RESTAURANT_TABLE_NO = fGetFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "RESTAURANT_TABLE_NO")

        gsDINE_IN_ID = fNumFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "DINE_IN_ID")
        gsTAKE_OUT_ID = fNumFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "TAKE_OUT_ID")
        gsDELIVERY_ID = fNumFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "DELIVERY_ID")










        Ship_Via_count = 0

        If gsDINE_IN_ID = 0 Then
            rbDINE_IN.Visible = False
        Else
            Ship_Via_count = Ship_Via_count + 1
            gsDINE_NAME = fGetFieldValue("ship_via", "id", gsDINE_IN_ID, "DESCRIPTION")
        End If

        If gsTAKE_OUT_ID = 0 Then
            rbTAKE_OUT.Visible = False
        Else
            Ship_Via_count = Ship_Via_count + 1
            gsTAKE_OUT_NAME = fGetFieldValue("ship_via", "id", gsTAKE_OUT_ID, "DESCRIPTION")
        End If

        If gsDELIVERY_ID = 0 Then
            rbDELIVERY.Visible = False
        Else
            Ship_Via_count = Ship_Via_count + 1
            gsDELIVERY_NAME = fGetFieldValue("ship_via", "id", gsDELIVERY_ID, "DESCRIPTION")
        End If


        '====================================================================
        fGET_POS_CREATE()
        fLoad_Reference()


        '===================
        If Ship_Via_count = 1 Then


            If gsDINE_IN_ID = 0 Then
                rbDINE_IN.Visible = False
            Else
                rbDINE_IN.BackColor = btnMENU.BackColor
            End If

            If gsTAKE_OUT_ID = 0 Then
                rbTAKE_OUT.Visible = False
            Else
                rbTAKE_OUT.BackColor = btnMENU.BackColor
            End If

            If gsDELIVERY_ID = 0 Then
                rbDELIVERY.Visible = False
            Else
                rbDELIVERY.BackColor = btnMENU.BackColor
            End If

        End If
    End Sub

    Private Sub fGET_POS_CREATE()

        gsPOS_DATE = Date.Now
        If fNumFieldValue("USER_DEFAULT", "USER_ID", gsUser_ID, "pos_select_date") <> 0 Then
            frmSelectDate.ShowDialog()
            If frmSelectDate.gsOK = True Then
                gsPOS_DATE = frmSelectDate.dtpSelect.Value
            Else
                gsPOS_DATE = Date.Now
            End If
            frmSelectDate.Dispose()
            frmSelectDate = Nothing
        End If

        gsPOS_LOG_ID = 0
        Dim bStartNew As Boolean = False
        'POS LOG
        Dim rd As DataTableReader = fReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and DATE(recorded_On) ='{fDateFormatMYSQL(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and CASHIER_ID = '{gsCashier_ID}' ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            If fNumisNULL(rd("CASH_COUNT_ID")) <> 0 Then
                FrmPOSLogSwitch.ShowDialog()
                bStartNew = FrmPOSLogSwitch.gsStartNew
                FrmPOSLogSwitch.Dispose()
                FrmPOSLogSwitch = Nothing
            End If
            If bStartNew = True Then
                GoTo NewPOS_LOG
            End If

            gsSTARTING_RECEIPT_NO = fNumisNULL(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = fNumisNULL(rd("ID"))
            gsSTARTING_CASH_ID = fNumisNULL(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = fNumisNULL(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = fNumisNULL(rd("CASH_COUNT_ID"))

        Else
NewPOS_LOG:
            gsCASH_COUNT_ID = 0
            Dim sAMount As Double = 0
            gsSTARTING_CASH_ID = 0
            If fPOS_STARTING_CASH() = True Then
                frmPOSStartingCash.ShowDialog()
                sAMount = frmPOSStartingCash.gsStartAmount
                frmPOSStartingCash.Dispose()
                frmPOSStartingCash = Nothing
            End If
            gsSTARTING_CASH_ID = fObjectTypeMap_ID("POS_STARTING_CASH")

            If fDateFormatMYSQL(gsPOS_DATE) = fDateFormatMYSQL(Date.Now.Date) Then
                LOG_DATE = fDateTimeNow()
            Else
                LOG_DATE = $"{fDateFormatMYSQL(gsPOS_DATE)} 08:00:01"
            End If
            fExecutedOnly($"INSERT INTO POS_STARTING_CASH SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{sAMount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
            fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
            fPOS_LOG()

        End If
        rd.Close()
        fCollect_POSLog_Resto()
    End Sub
    Private Sub fHeader_SalesOrder_Refresh()

        If rbDINE_IN.Checked = True Then
            fDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{gsTableSelect}'  and SHIP_VIA_ID='{gsDINE_IN_ID}' and s.STATUS in('16','12')  ")
        ElseIf rbTAKE_OUT.Checked = True Then
            fDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{gsTableSelect}'  and SHIP_VIA_ID='{gsTAKE_OUT_ID}' and  s.STATUS in ('16','12')  ")
        ElseIf rbDELIVERY.Checked = True Then
            fDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{gsTableSelect}'  and SHIP_VIA_ID='{gsDELIVERY_ID}' and  s.STATUS in ('16','12')  ")
        End If
        dgvSalesOrder.Columns(0).Visible = False
        fDgvNotSort(dgvSalesOrder)
        dgvSalesOrder.ColumnHeadersHeight = 24

        Try
            With dgvSalesOrder.Columns
                If .Count <> 0 Then
                    .Item(0).Visible = False
                    .Item(1).Width = 150
                End If
            End With

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fHeader_Invoice_Refresh()
        If rbDINE_IN.Checked = True Then
            fDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{gsTableSelect}'  and SHIP_VIA_ID='{gsDINE_IN_ID}' and  s.STATUS ='13'  ")
        ElseIf rbTAKE_OUT.Checked = True Then
            fDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{gsTableSelect}'  and SHIP_VIA_ID='{gsTAKE_OUT_ID}' and s.STATUS ='13'  ")
        ElseIf rbDELIVERY.Checked = True Then
            fDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{gsTableSelect}'  and SHIP_VIA_ID='{gsDELIVERY_ID}' and s.STATUS ='13'  ")
        End If
        dgvInvoice.Columns(0).Visible = False
        fDgvNotSort(dgvInvoice)
        dgvInvoice.ColumnHeadersHeight = 24
        Try
            With dgvInvoice.Columns
                If .Count <> 0 Then
                    .Item(0).Visible = False
                    .Item(1).Width = 150
                End If
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fRefreshTable()
        Try
            Timer1.Stop()

            gsJustClick = False
            xlblTABLE_NO.Text = ""

            dgvInvoice.Columns.Clear()
            '  dgvInvoice.Rows.Clear()
            dgvSalesOrder.Columns.Clear()
            '   dgvSalesOrder.Rows.Clear()
            fCLean_and_refresh(Me)

            If rbDINE_IN.Checked = True Then
                xlblTABLE_TYPE.Text = $"{gsDINE_NAME} TABLE #"
            ElseIf rbTAKE_OUT.Checked = True Then
                xlblTABLE_TYPE.Text = $"{gsTAKE_OUT_NAME} #"
            ElseIf rbDELIVERY.Checked = True Then
                xlblTABLE_TYPE.Text = $"{gsDELIVERY_NAME} #"
            End If

            FLP_TABLE.Controls.Clear()
            If rbDINE_IN.Checked = True Then
                Dim SQL As String = ""
                For T As Integer = 1 To gsPOS_RESTAURANT_TABLE_NO
                    Dim xSQL_RECORD As String = $"(SELECT D.RECORDED_ON FROM ((SELECT s.RECORDED_ON,s.SHIP_TO FROM sales_order AS s INNER JOIN ship_via AS v ON v.id = s.SHIP_VIA_ID WHERE s.SHIP_VIA_ID = '{gsDINE_IN_ID}' AND  s.ship_to = '{T}' AND s.`STATUS` IN('16','12') ORDER BY s.id)
UNION ALL 
(SELECT s.RECORDED_ON,s.SHIP_TO FROM invoice AS s INNER JOIN ship_via AS v ON v.id = s.SHIP_VIA_ID WHERE s.SHIP_VIA_ID = '{gsDINE_IN_ID}' AND  s.ship_to = '{T}' AND s.`STATUS` IN ('13')  AND NOT
EXISTS(SELECT o.id FROM sales_order_items AS o INNER JOIN invoice_items AS v ON v.REF_LINE_ID  = o.id WHERE v.invoice_id = s.id  )
ORDER BY s.id)
UNION ALL
(SELECT s.RECORDED_ON,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no ='{T}' and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDINE_IN_ID}' order by s.ID )
) AS D ORDER BY D.RECORDED_ON  LIMIT 1)"



                    Dim xSQL_STATUS As String = $"(SELECT D.STATUS FROM ((SELECT 0 as `STATUS`,s.SHIP_TO FROM sales_order AS s INNER JOIN ship_via AS v ON v.id = s.SHIP_VIA_ID WHERE s.SHIP_VIA_ID = '{gsDINE_IN_ID}' AND  s.ship_to = '{T}' AND s.`STATUS` IN('16','12') ORDER BY s.id)
UNION ALL 
(SELECT 0 as `STATUS`,s.SHIP_TO FROM invoice AS s INNER JOIN ship_via AS v ON v.id = s.SHIP_VIA_ID WHERE s.SHIP_VIA_ID = '{gsDINE_IN_ID}' AND  s.ship_to = '{T}' AND s.`STATUS` IN ('13')  AND NOT
EXISTS(SELECT o.id FROM sales_order_items AS o INNER JOIN invoice_items AS v ON v.REF_LINE_ID  = o.id WHERE v.invoice_id = s.id  )
ORDER BY s.id)
UNION ALL
(SELECT 1 as `STATUS`,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no ='{T}' and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDINE_IN_ID}' order by s.ID )
) AS D ORDER BY D.STATUS  LIMIT 1)"


                    If SQL = "" Then
                        SQL = $"(SELECT '{T}'  as `T_NO`, {xSQL_RECORD} as this_record,{xSQL_STATUS} as this_status)"
                    Else
                        SQL = SQL & $" UNION ALL (SELECT '{T}'  as `T_NO`, {xSQL_RECORD} as this_record,{xSQL_STATUS} as this_status) "
                    End If
                    'fCreateTableAdd_DINE_IN(T, Color.Cyan)
                    'must change

                Next
                Dim rd_dine As DataTableReader = fReader(SQL)
                While rd_dine.Read
                    Dim DTT As String
                    Dim This_Label As String = ""
                    Dim This_Status As String = ""
                    Dim This_Color As Color
                    If IsDate(rd_dine("this_record")) = True Then

                        DTT = fDateTimeFormatStandard(rd_dine("this_record")).ToString
                        If fNumisNULL(rd_dine("this_status")) = 0 Then
                            This_Label = "Accommodated"
                            This_Color = Color.Khaki
                        Else
                            This_Label = "Served"
                            This_Color = Color.Yellow
                        End If
                    Else
                        This_Color = Color.Cyan
                        This_Label = "Available"
                        DTT = ""
                    End If
                    'Available = cyan
                    'Served = Aqua
                    'Accommodated = SkyBlue
                    fCreate_Box(rd_dine("T_NO"), This_Color, This_Label, This_Status, DTT)
                End While
                rd_dine.Close()

                fGetDefaultTable(gsTableSelect)
            ElseIf rbTAKE_OUT.Checked = True Then
                Dim N As Integer = 0
                Dim rd As DataTableReader = fReader($"select  D.RECORDED_ON,D.SHIP_TO, D.`STATUS` from ((SELECT s.RECORDED_ON,s.SHIP_TO, 0 as `STATUS` FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsTAKE_OUT_ID}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsTAKE_OUT_ID}' and  s.ship_to > '0' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO`,1 as `STATUS` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsTAKE_OUT_ID}' order by s.id ) ) as D order by D.RECORDED_ON  limit {gsPOS_RESTAURANT_TABLE_NO} ")
                While rd.Read
                    N = N + 1
                    Dim DTT As DateTime = fDateTimeFormatStandard(rd("RECORDED_ON"))

                    Dim This_label As String
                    If fNumisNULL(rd("STATUS")) = 0 Then
                        This_label = "On-going"
                        fCreate_Box(N, Color.YellowGreen, This_label, fNumisNULL(rd("ship_to")), DTT.ToString)
                    Else
                        This_label = "Waiting"
                        fCreate_Box(N, Color.LightBlue, This_label, fNumisNULL(rd("ship_to")), DTT.ToString)
                    End If


                End While
                rd.Close()
                fGetDefaultTable(gsTableSelect)
            ElseIf rbDELIVERY.Checked = True Then
                Dim rd As DataTableReader = fReader($"select D.RECORDED_ON,D.SHIP_TO, D.`STATUS`  from ((SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDELIVERY_ID}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDELIVERY_ID}' and  s.ship_to > '0' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id) UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDELIVERY_ID}' order by s.ID ) UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO`,1 as `STATUS` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDELIVERY_ID}' order by s.ID )) as D order by D.RECORDED_ON  limit {gsPOS_RESTAURANT_TABLE_NO} ")
                Dim N As Integer = 0
                While rd.Read
                    N = N + 1
                    Dim DTT As DateTime = fDateTimeFormatStandard(rd("RECORDED_ON"))

                    Dim This_label As String
                    If fNumisNULL(rd("STATUS")) = 0 Then
                        This_label = "On-going"
                    Else
                        This_label = "Waiting"
                    End If


                    fCreate_Box(N, Color.DarkOrange, This_label, fNumisNULL(rd("ship_to")), DTT.ToString)
                End While
                rd.Close()
                fGetDefaultTable(gsTableSelect)
            End If

        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
        fNotifyNumber()
        Timer1.Start()
    End Sub



    Private Sub fGetDefaultTable(ByVal S As Integer)
        ' Get Defualt First Entry

        If FLP_TABLE.Controls.Count = 0 Then
            Exit Sub
        End If
        fclear_Info()

        If S = 0 Then
            Exit Sub
        End If

        Try


            If rbDINE_IN.Checked = True Then

                Dim PNL As Panel = FLP_TABLE.Controls($"pnl{S}")
                Dim BN As Button = PNL.Controls($"btnOrder{S}")

                gsJustClick = False
                BN.PerformClick()
            Else

                Dim PNL As Panel = FLP_TABLE.Controls($"pnl{S}")
                Dim BN As Button = PNL.Controls($"btnOrder{S}")


                gsJustClick = False
                BN.PerformClick()
            End If
        Catch ex As Exception

            '            fMessageboxInfo("Please try again can`t open " & ex.Message)
        End Try


    End Sub
    Private Sub fCreateTableAdd_DINE_IN(ByVal N As Integer, ByVal C As Color)
        Dim LABEL_BUTTON As String = ""
        Dim LABEL_STATUS As String = ""
        Dim LABEL_RECORD As String = ""
        If rbDINE_IN.Checked = True Then
            fDINE_IN_CONTROL(N, LABEL_BUTTON, LABEL_STATUS, LABEL_RECORD)
            fCreate_Box(N, C, LABEL_BUTTON, LABEL_STATUS, LABEL_RECORD)
        End If
    End Sub
    Private Sub fCreate_Box(ByVal N As Integer, ByVal C As Color, ByVal LABEL_BUTTON As String, ByVal LABEL_STATUS As String, ByVal LABEL_RECORD As String)
        Dim NewPanel As New Panel
        NewPanel.Name = $"pnl{N}"
        NewPanel.AccessibleName = LABEL_BUTTON
        NewPanel.Size = New Size(119, 130)
        NewPanel.BorderStyle = BorderStyle.FixedSingle

        'Table Number
        Dim NewLabelNum As New Label
        NewLabelNum.Name = $"lblnum{N}"
        NewLabelNum.AutoSize = True
        NewLabelNum.Text = N
        NewLabelNum.Font = New Font("Verdana", 14.25, FontStyle.Bold)
        NewLabelNum.Location = New Point(0, 0)
        NewPanel.Controls.Add(NewLabelNum)


        'Order Type
        Dim NewLabelOrderType As New Label
        NewLabelOrderType.Name = $"lblSTATUS{N}"
        NewLabelOrderType.AutoSize = False
        NewLabelOrderType.Size = New Size(80, 39)
        NewLabelOrderType.Text = IIf(LABEL_STATUS = "", "", "#" & LABEL_STATUS)
        NewLabelOrderType.TextAlign = ContentAlignment.MiddleCenter
        NewLabelOrderType.Font = New Font("Verdana", 9.75, FontStyle.Regular)
        NewLabelOrderType.Location = New Point(30, 0)
        NewPanel.Controls.Add(NewLabelOrderType)


        'Button Function
        Dim NewButton As New Button
        NewButton.Name = $"btnOrder{N}"
        NewButton.TextAlign = ContentAlignment.MiddleCenter
        NewButton.AutoSize = False
        NewButton.Size = New Size(117, 50)
        NewButton.Text = LABEL_BUTTON
        NewButton.AccessibleDescription = LABEL_STATUS
        NewButton.Tag = N
        If rbTAKE_OUT.Checked = True Or rbDELIVERY.Checked = True Then
            NewButton.AccessibleName = Val(LABEL_BUTTON)
        End If


        If rbDINE_IN.Checked = True Then

            NewButton.BackColor = C

        Else

            NewButton.BackColor = C

        End If


        NewButton.Location = New Point(0, 40)
        AddHandler NewButton.Click, AddressOf fBUTTON_CLICK
        NewPanel.Controls.Add(NewButton)


        'Time Label
        Dim NewLabelTime As New Label
        NewLabelTime.Name = $"lblTime{N}"
        NewLabelTime.AutoSize = False
        NewLabelTime.Size = New Size(118, 35)
        NewLabelTime.Text = "00:00"
        NewLabelTime.TextAlign = ContentAlignment.MiddleCenter
        NewLabelTime.Font = New Font("Verdana", 12, FontStyle.Bold)
        NewLabelTime.Location = New Point(0, 93)
        NewPanel.Controls.Add(NewLabelTime)

        'RECORDED LABEL
        Dim NewDATETIME_RECORD As New Label
        NewDATETIME_RECORD.Name = $"lblRECORD{N}"
        NewDATETIME_RECORD.AutoSize = False
        NewDATETIME_RECORD.Size = New Size(118, 35)
        NewDATETIME_RECORD.Text = LABEL_RECORD
        NewDATETIME_RECORD.TextAlign = ContentAlignment.MiddleCenter
        NewDATETIME_RECORD.Font = New Font("Verdana", 12, FontStyle.Bold)
        NewDATETIME_RECORD.Location = New Point(0, 0)
        NewDATETIME_RECORD.Visible = False
        NewPanel.Controls.Add(NewDATETIME_RECORD)


        FLP_TABLE.Controls.Add(NewPanel)
    End Sub

    Private Sub fBUTTON_CLICK(sender As Object, e As EventArgs)

        SelectTable = True
        Dim Btn As Button = DirectCast(sender, Button)

        If rbDINE_IN.Checked = True Then

            gsTableSelect = Btn.Tag
            Dim P As Panel = FLP_TABLE.Controls($"pnl{gsTableSelect}")
            P.BackColor = Color.MediumPurple
            P.ForeColor = Color.White
            Btn.ForeColor = Color.Black

            If Btn.Text = "Served" Then
                pnlTOP2.Enabled = False


            Else
                pnlTOP2.Enabled = True
            End If



            xlblTABLE_TYPE.Text = $"{gsDINE_NAME} #"
            xlblTABLE_NO.Text = gsTableSelect.ToString("00#")

        ElseIf rbTAKE_OUT.Checked = True Then

            gsTableSelect = Btn.AccessibleDescription
            Dim P As Panel = FLP_TABLE.Controls($"pnl{Btn.Tag}")

            P.BackColor = Color.MediumPurple
            P.ForeColor = Color.White
            Btn.ForeColor = Color.Black

            xlblTABLE_TYPE.Text = $"{gsTAKE_OUT_NAME} #"
            xlblTABLE_NO.Text = gsTableSelect.ToString("00#")

        ElseIf rbDELIVERY.Checked = True Then

            gsTableSelect = Btn.AccessibleDescription
            Dim P As Panel = FLP_TABLE.Controls($"pnl{gsTableSelect}")
            P.BackColor = Color.MediumPurple
            P.ForeColor = Color.White
            Btn.ForeColor = Color.Black

            xlblTABLE_TYPE.Text = $"{gsDELIVERY_NAME} #"
            xlblTABLE_NO.Text = gsTableSelect.ToString("00#")

        End If

        fHeader_SalesOrder_Refresh()
        fHeader_Invoice_Refresh()
        dgvProductItem.Rows.Clear()
        fclear_Info()
        fComputed()

        fControlEnable(True)

        If gsJustClick = True Then
            If Btn.Text = "Served" Or Btn.Text = "Waiting" Then

                frmPOSTableDetails.gsTABLE_NO = gsTableSelect
                If rbDELIVERY.Checked = True Then
                    frmPOSTableDetails.gsORDER_TYPE = gsDELIVERY_ID
                ElseIf rbDINE_IN.Checked = True Then
                    frmPOSTableDetails.gsORDER_TYPE = gsDINE_IN_ID
                ElseIf rbTAKE_OUT.Checked = True Then
                    frmPOSTableDetails.gsORDER_TYPE = gsTAKE_OUT_ID
                End If
                frmPOSTableDetails.ShowDialog()
                If frmPOSTableDetails.gsClickOk = True Then
                    fRefreshTable()
                End If
                frmPOSTableDetails.Dispose()
                frmPOSTableDetails = Nothing

            End If

        End If
        gsJustClick = True
    End Sub
    Private Function fGetPanelByAccessbleName(ByVal N As Integer) As Integer
        Exit Function
        Dim R As Integer = 1
        For I As Integer = 1 To FLP_TABLE.Controls.Count
            Dim NewPanel As Panel = FLP_TABLE.Controls($"pnl{I}")
            If Val(NewPanel.AccessibleName) = N Then
                R = I
                Exit For
            End If
        Next

        Return R

    End Function
    Private Sub fControlEnable(ByVal B As Boolean)
        btnMENU.Enabled = B
        pnlOther.Enabled = B
        tsITEM_MENU.Enabled = B
        FLP_TABLE.Enabled = B
        pnlTOP.Enabled = B
        pnlTOP2.Enabled = B
        pnlOther.Enabled = IIf(B = True, False, True)
        If pnlOther.Enabled = True Then
            If gsNew = True Then
                btnDELETE.Enabled = False
            Else
                btnDELETE.Enabled = True
            End If
        End If

        tsITEM_MENU.Enabled = IIf(B = True, False, True)


    End Sub

    Private Sub fDINE_IN_CONTROL(ByVal T As Integer, ByRef BUTTON_LABEL As String, ByRef STATUS_LABEL As String, ByRef DT_RECORD As String)

        Dim rd As DataTableReader = fReader($"select D.RECORDED_ON from ((SELECT s.RECORDED_ON,s.SHIP_TO FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id)) as D order by D.RECORDED_ON  limit 1;")
        If rd.Read Then
            Dim DTT As DateTime = fDateTimeFormatStandard(rd("RECORDED_ON"))
            DT_RECORD = DTT.ToString
            BUTTON_LABEL = "Accommodated"
            STATUS_LABEL = ""
        Else

            '    rd = fReader($"SELECT s.STATUS_DATE FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in('13') order by s.id limit 1;")
            'If rd.Read Then
            '        Dim DTT As DateTime = fDateTimeFormatStandard(rd("STATUS_DATE"))
            '        DT_RECORD = DTT.ToString
            '        BUTTON_LABEL = "Accommodated"
            '        STATUS_LABEL = "TABLE NO."
            '    Else
            STATUS_LABEL = ""
            DT_RECORD = ""
            BUTTON_LABEL = "Available"



            ' End If
        End If
        rd.Close()
    End Sub


    Private Sub fLoad_Reference()

        If gsIsOrder = True Then
            fcolumnGrid_Sales_order()
            fdgvItemDisplay(dgvProductItem)
            fHide_Standard_Column()
            fDgvNotSort(dgvProductItem)
            fclear_Info()
            If gsNew = False Then
                fRefreshInfo_sales_order(gsID)
                fRefreshItem_sales_order(gsID)
            End If

        Else

            fcolumnGrid_Invoice()
            fdgvItemDisplay(dgvProductItem)
            fHide_Standard_Column()
            fDgvNotSort(dgvProductItem)
            fclear_Info()
            'Received
            If gsNew = False Then
                fRefreshInfo_Invoice(gsID)
                fRefreshItem_Invoice(gsID)
            End If
        End If


    End Sub
    Private Sub fclear_Info()

        fRefreshCombo()
        fCLean_and_refresh(Me)

        cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
        cmbCUSTOMER_ID.SelectedValue = gsPOSDefaultCustomer_ID
        cmbSALES_REP_ID.SelectedIndex = -1
        xlblCustomer_Name.Visible = True
        xlblAcctNo.Visible = True
        xlblSalesRep.Visible = True

        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = fLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = fPaymentTermsDefault()
        dtpDATE.Value = gsPOS_DATE
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID


        fCODELABEL()
        fComputed()

    End Sub

    Private Sub fCODELABEL()



        If gsIsOrder = True And gsPOS_SERVED_ONLY = False Then

            xlblCODE_TITLE.Text = "ORDER NO."

            xlblCustomer_Name.ForeColor = btnNEWORDER.BackColor
            xlblCustomer_Name.BackColor = btnNEWORDER.ForeColor

            xlblCustomerTItle.ForeColor = btnNEWORDER.ForeColor
            xlblCustomerTItle.BackColor = btnNEWORDER.BackColor

            xlblAcctNo.ForeColor = btnNEWORDER.BackColor
            xlblAcctNo.BackColor = btnNEWORDER.ForeColor

            xlblAcctnoTitle.ForeColor = btnNEWORDER.ForeColor
            xlblAcctnoTitle.BackColor = btnNEWORDER.BackColor

            xlblCODE_TITLE.ForeColor = btnNEWORDER.BackColor
            xlblCODE_TITLE.BackColor = btnNEWORDER.ForeColor

            lblCODE.ForeColor = btnNEWORDER.ForeColor
            lblCODE.BackColor = btnNEWORDER.BackColor


            xlblTABLE_NO.ForeColor = btnNEWORDER.BackColor
            xlblTABLE_NO.BackColor = btnNEWORDER.ForeColor

            xlblTABLE_TYPE.ForeColor = btnNEWORDER.ForeColor
            xlblTABLE_TYPE.BackColor = btnNEWORDER.BackColor
        Else
            xlblCODE_TITLE.Text = "SERVED NO."
            xlblCustomer_Name.ForeColor = btnRECEIVED_ORDER.BackColor
            xlblCustomer_Name.BackColor = btnRECEIVED_ORDER.ForeColor

            xlblCustomerTItle.ForeColor = btnRECEIVED_ORDER.ForeColor
            xlblCustomerTItle.BackColor = btnRECEIVED_ORDER.BackColor

            xlblAcctNo.ForeColor = btnRECEIVED_ORDER.BackColor
            xlblAcctNo.BackColor = btnRECEIVED_ORDER.ForeColor

            xlblAcctnoTitle.ForeColor = btnRECEIVED_ORDER.ForeColor
            xlblAcctnoTitle.BackColor = btnRECEIVED_ORDER.BackColor

            xlblCODE_TITLE.ForeColor = btnRECEIVED_ORDER.BackColor
            xlblCODE_TITLE.BackColor = btnRECEIVED_ORDER.ForeColor

            lblCODE.ForeColor = btnRECEIVED_ORDER.ForeColor
            lblCODE.BackColor = btnRECEIVED_ORDER.BackColor


            xlblTABLE_NO.ForeColor = btnRECEIVED_ORDER.BackColor
            xlblTABLE_NO.BackColor = btnRECEIVED_ORDER.ForeColor

            xlblTABLE_TYPE.ForeColor = btnRECEIVED_ORDER.ForeColor
            xlblTABLE_TYPE.BackColor = btnRECEIVED_ORDER.BackColor
        End If
    End Sub


    Private Sub fRefreshInfo_Invoice(ByVal id As Integer)
        Try

            Dim sQuery As String = "select * from invoice where ID = '" & id & "' Limit 1;"
            fExecutedUsingReading(Me, sQuery)

        Catch ex As Exception
            fMessageboxError(ex)
        End Try
    End Sub
    Private Sub fRefreshInfo_sales_order(ByVal prID As Integer)

        Try

            Dim sQuery As String = "select * from sales_order where ID = '" & prID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)


            'cn.Close()
        Catch ex As Exception

            fMessageboxError(ex)

        End Try
    End Sub


    Private Sub fRefreshItem_sales_order(prID As String)
        dgvProductItem.Rows.Clear()
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0

        Dim sQuery As String = "SELECT 
  ii.`ID`,
  i.`CODE`,
  i.`DESCRIPTION`,
  ii.`QUANTITY`,
  u.`SYMBOL`,
  ii.`RATE`,
  d.`DESCRIPTION`,
  ii.`DISCOUNT_RATE`,
  ii.`AMOUNT`,
  ii.`TAXABLE`,
  u.`ID` AS UNIT_ID,
  'S' AS `CONTROL_STATUS`,
  rt.`ID` AS `RATE_TYPE`,
  ii.`UNIT_BASE_QUANTITY`,
  d.`ID` AS `DISCOUNT_ID`,
  ii.`TAXABLE_AMOUNT`,
  ii.`TAX_AMOUNT`,
  ii.`ESTIMATE_LINE_ID`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`GROUP_LINE_ID`,
i.TYPE as `ITEM_TYPE`,
ii.PRINT_IN_FORMS

FROM

  sales_order_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
   WHERE ii.`SALES_ORDER_ID` = '" & gsID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

            Dim rd As DataTableReader = fReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatStandard(fNumisNULL(rd(i)))
                        ElseIf fCheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatNoDecimal(fNumisNULL(rd(i)))
                        ElseIf fCheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(fNumisNULL(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = fNumisNULL(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = fTextisNULL(rd(i))
                            End If
                        End If
                    End With

                Next
                If CBool(fNumisNULL(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        Finally

            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = fFieldCollector(Me)

        End Try


    End Sub

    Private Function fgetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub fRefreshCombo()
        xlblCustomer_Name.Visible = False
        xlblAcctNo.Visible = False
        xlblSalesRep.Visible = False

        fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

        fComboBox(cmbCLASS_ID, "select * from class order by `NAME`", "ID", "NAME")
        fComboBox(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        fComboBox(cmbSALES_REP_ID, "select * from contact where type ='2' order by `NAME`", "ID", "NAME")
        fComboBox(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        fComboBox(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        fComboBox(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")

    End Sub
    Private Sub fcolumnGrid_Invoice()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "TAX"
        chk.Name = "TAX"

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", "CODE") '1
            .Add("DESCRIPTION", "DESCRIPTION") '2
            .Add("QTY", "QTY") '3
            .Add("UM", "UNIT") '4
            .Add("UNIT_PRICE", "RATE") '5
            .Add("DISCOUNT_TYPE", "DISC. TYPE") '6
            .Add("DISCOUNT_RATE", "DISC. RATE") '7

            .Add("AMOUNT", "AMOUNT") '8
            .Add(chk) '9
            .Add("UNIT_ID", "UNIT_ID") '10
            .Item("UNIT_ID").Visible = False
            .Add("CONTROL_STATUS", "CONTROL_STATUS") '11
            .Item("CONTROL_STATUS").Visible = False
            .Add("RATE_TYPE", "RATE_TYPE") '12
            .Item("RATE_TYPE").Visible = False
            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '13
            .Item("UNIT_QUANTITY_BASE").Visible = False
            .Add("DISCOUNT_ID", "DISCOUNT_ID") '14
            .Item("DISCOUNT_ID").Visible = False
            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '15
            .Item("TAXABLE_AMOUNT").Visible = False
            .Add("TAX_AMOUNT", "TAX_AMOUNT") '16
            .Item("TAX_AMOUNT").Visible = False
            .Add("COGS_ACCOUNT_ID", "COGS_ACCOUNT_ID") '17
            .Item("COGS_ACCOUNT_ID").Visible = False
            .Add("ASSET_ACCOUNT_ID", "ASSET_ACCOUNT_ID") '18
            .Item("ASSET_ACCOUNT_ID").Visible = False
            .Add("INCOME_ACCOUNT_ID", "INCOME_ACCOUNT_ID") '19
            .Item("INCOME_ACCOUNT_ID").Visible = False
            .Add("REF_LINE_ID", "REF_LINE_ID") '20
            .Item("REF_LINE_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '21
            .Item("ORG_AMOUNT").Visible = False
            .Add("ITEM_ID", "ITEM_ID") '22
            .Item("ITEM_ID").Visible = False

            .Add("GROUP_LINE_ID", "GROUP_LINE_ID") '23
            .Item("GROUP_LINE_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL_ID") '24
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") ' 25
            .Item("ITEM_TYPE").Visible = False

            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") ' 26
            .Item("PRINT_IN_FORMS").Visible = False

        End With

    End Sub
    Private Sub fHide_Standard_Column()
        With dgvProductItem

            .Columns("CODE").Visible = False
            .Columns("UM").Visible = False

            .Columns("DISCOUNT_TYPE").Visible = False
            .Columns("DISCOUNT_RATE").Visible = False
            .Columns("TAX").Visible = False
            .Columns("DESCRIPTION").Width = 200
            .Columns("DESCRIPTION").HeaderCell.Style.Font = New Font(Me.Font, FontStyle.Bold)
            .Columns("QTY").Width = 30
            .Columns("QTY").HeaderCell.Style.Font = New Font(Me.Font, FontStyle.Bold)
            .Columns("UNIT_PRICE").Width = 50
            .Columns("UNIT_PRICE").HeaderCell.Style.Font = New Font(Me.Font, FontStyle.Bold)
            .Columns("AMOUNT").Width = 130
            .Columns("AMOUNT").HeaderCell.Style.Font = New Font(Me.Font, FontStyle.Bold)

        End With
    End Sub
    Private Sub fcolumnGrid_Sales_order()
        Dim chk As New DataGridViewCheckBoxColumn
        chk.HeaderText = "TAX"
        chk.Name = "TAX"

        With dgvProductItem.Columns
            .Clear()
            .Add("ID", "ID") ' 0
            .Item(0).Visible = False
            .Add("CODE", "CODE") '1

            .Add("DESCRIPTION", "DESCRIPTION") '2

            .Add("QTY", "QTY") '3

            .Item(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("UM", "UNIT") '4

            .Add("UNIT_PRICE", "RATE") '5

            .Item(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("DISCOUNT_TYPE", "DISC. TYPE") '6

            .Add("DISCOUNT_RATE", "DISC. RATE") '7

            .Item(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("AMOUNT", "AMOUNT") '8

            .Item(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add(chk) '9


            .Add("UNIT_ID", "UNIT_ID") '10
            .Item("UNIT_ID").Visible = False

            .Add("CONTROL_STATUS", "CONTROL_STATUS") '11
            .Item("CONTROL_STATUS").Visible = False

            ' Control_Status_value
            ' S - Stable
            ' A - Added
            ' E - Editted
            ' D - Deleted

            .Add("RATE_TYPE", "RATE_TYPE") '12
            .Item("RATE_TYPE").Visible = False

            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '13
            .Item("UNIT_QUANTITY_BASE").Visible = False

            .Add("DISCOUNT_ID", "DISCOUNT_ID") '14
            .Item("DISCOUNT_ID").Visible = False

            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '15
            .Item("TAXABLE_AMOUNT").Visible = False

            .Add("TAX_AMOUNT", "TAX_AMOUNT") '16
            .Item("TAX_AMOUNT").Visible = False


            .Add("ESTIMATE_LINE_ID", "ESTIMATE_LINE_ID") '17
            .Item("ESTIMATE_LINE_ID").Visible = False

            .Add("ORG_AMOUNT", "ORG_AMOUNT") '18
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '19
            .Item("ITEM_ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL") '20
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("ITEM_TYPE", "ITEM_TYPE") '21
            .Item("ITEM_TYPE").Visible = False

            .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") ' 22
            .Item("PRINT_IN_FORMS").Visible = False


            .Add("GROUP_LINE_ID", "GROUP_LINE_ID")
            .Item("GROUP_LINE_ID").Visible = False
        End With

    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        fCloseForm(Me)
    End Sub


    Private Function fCheckifDiscountNext(ByVal ndex As Integer) As Boolean
        Try
            If fDISCOUNT_ITEM(dgvProductItem.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub fComputed()
        Try
            fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE)
            Dim dPayment_applied As Double = fGetSumPaymentApplied(gsID, cmbCUSTOMER_ID.SelectedValue) + fGetSumCreditApplied(gsID, cmbCUSTOMER_ID.SelectedValue) + fInvoiceSumTaxApplied_Amount(gsID, cmbCUSTOMER_ID.SelectedValue)
            lbxPaymentApplied.Text = fNumFormatStandard(dPayment_applied)
            Dim dBalance As Double = fNumisNULL(fNumFormatFixed(fNumisNULL(lblAMOUNT.Text))) - dPayment_applied
            lblBALANCE_DUE.Text = fNumFormatStandard(dBalance)
            lbxBalance.Text = IIf(dtpDUE_DATE.Value > Date.Now.Date, "0.00", fNumFormatStandard(dBalance))
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Select Case fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue)
            Case 14
                xlblTax.Text = "0% Vat"
            Case 12
                xlblTax.Text = "12% Vat(I)"
            Case 13
                xlblTax.Text = "12% Vat(E)"
            Case 2
        End Select
        Try
            '   cn.Open()
            Dim rd As DataTableReader = fReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & fNumisNULL(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = fTextisNULL(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = fTextisNULL(rd("TAX_ACCOUNT_ID"))
            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""
                lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            fMessageboxError(ex)
            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub fEditItem()
        If gsIsOrder = True Then
            fEdit_SO()
        Else
            fEdit_Invoice()
        End If

    End Sub

    Private Sub fEdit_Invoice()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                fMessageboxExclamation("Data Not Found!")
                Exit Sub
            End If
            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index
            If fCheckModify(dgvProductItem, I) = True Then
                Exit Sub
            End If
            Dim d As DataGridViewRow = dgvProductItem.Rows(I)


            If d.Cells("ITEM_TYPE").Value = 5 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fDISCOUNT_ITEM(d.Cells("ITEM_TYPE").Value) = True Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fNumisNULL(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem

                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                .sFormName = "frmInvoice"
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = fTextisNULL(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value)
                .gsDiscount_Rate = fNumisNULL(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value)
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsPRICE_LEVEL_ID = dgvProductItem.Rows.Item(I).Cells("PRICE_LEVEL_ID").Value

                .dgv = dgvProductItem
                .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
                .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
                .gslblAMOUNT = lblAMOUNT
                .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
                .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
                .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE

                .StartPosition = FormStartPosition.Manual
                Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height - (.Height)
                .Location = New Point(405, H_PC)

                frmAddItem.ShowDialog()

                If .gsSave = True Then
                    fRow_Data_Item_Invoice(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, dgvProductItem.Rows.Item(I).Cells("REF_LINE_ID").Value, .gsPRICE_LEVEL_ID, 0, False)

                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing

        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
    End Sub
    Private Sub fEdit_SO()
        Try
            If tsITEM_MENU.Enabled = False Then Exit Sub

            If dgvProductItem.Rows.Count = 0 Then
                fMessageboxExclamation("Data Not Found!")
                Exit Sub
            End If
            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index

            Dim d As DataGridViewRow = dgvProductItem.Rows(I)
            If d.Cells("ITEM_TYPE").Value = 5 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fDISCOUNT_ITEM(d.Cells("ITEM_TYPE").Value) = True Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            ElseIf fNumisNULL(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                fMessageboxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem
                .gsNonInventoryItem = True
                If fNumisNULL(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If

                .sFormName = "frmSalesOrder"
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value
                .gsDiscount_Rate = dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value
                .gsTax = dgvProductItem.Rows.Item(I).Cells("TAX").Value
                .gsPRICE_LEVEL_ID = dgvProductItem.Rows.Item(I).Cells("PRICE_LEVEL_ID").Value

                .dgv = dgvProductItem
                .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
                .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
                .gslblAMOUNT = lblAMOUNT
                .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
                .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
                .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE

                .StartPosition = FormStartPosition.Manual
                Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height - (.Height)
                .Location = New Point(405, H_PC)
                .ShowDialog()
                If .gsSave = True Then
                    fRow_Data_Item_Sales_Order(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, "", .gsPRICE_LEVEL_ID, False, 0)

                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing
        Catch ex As Exception
            fMessageboxInfo(ex.Message)
        End Try
    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        fEditItem()
    End Sub





    Private Sub dgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            fTax_Value(dgvProductItem)
            fComputed()
        End If
    End Sub
    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

    End Sub

    Private Sub fSaveInvoice()


        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Name")
            Exit Sub
        End If


        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item Enter")
            Exit Sub
        End If


        If cmbPAYMENT_TERMS_ID.Text = "" Then
            fMessageboxInfo("Please select payment terms")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(frmInvoice, gsNew) = False Then
            'Acccess Denied
            Exit Sub
        End If

        If gsNew = True Then

            If fIsClosingDate(gsPOS_DATE) = False Then
                Exit Sub
            End If
            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = fNEXT_CODE("INVOICE", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(pnlOther)
            gsID = fObjectTypeMap_ID("invoice")

            Dim ORDER_TYPE_ID As Integer = 0
            If rbDINE_IN.Checked = True Then
                ORDER_TYPE_ID = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                ORDER_TYPE_ID = gsTAKE_OUT_ID
                If gsTableSelect = 0 Then
                    gsTableSelect = fAutoNumber(gsTableSelect)
                End If
            ElseIf rbDELIVERY.Checked = True Then
                ORDER_TYPE_ID = gsDELIVERY_ID
                If gsTableSelect = 0 Then
                    gsTableSelect = fAutoNumber(gsTableSelect)
                End If
            End If


            squery = squery & ",ID = '" & gsID & "',RECORDED_ON = '" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "',SHIP_DATE ='" & fDateFormatMYSQL(gsPOS_DATE) & "',SHIP_VIA_ID='" & ORDER_TYPE_ID & "',SHIP_TO='" & gsTableSelect & "',STATUS='13',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "',IS_FC='0'"
            squery = fNullOTherField(squery, "invoice")
            fExecutedOnly("INSERT INTO invoice SET " & squery)
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else
            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If
            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)
            Dim bTotal_Balance As Double = fNumFormatFixed(lblBALANCE_DUE.Text)

            Dim nStatus As Integer = 0
            If 0 >= bTotal_Balance Then
                nStatus = 11
            Else
                nStatus = 13
            End If

            squery = squery & ",STATUS='" & nStatus & "',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "' WHERE ID = '" & gsID & "' limit 1;"
            fExecutedOnly("UPDATE invoice SET " & squery)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If

        If fTransactionCheck(gsID, "INVOICE") = False Then
            fMessageboxWarning("Please Try Again")
            Exit Sub
        Else


            '===========================================
            If gsSkipJournalEntry = False Then
                gsJOURNAL_NO_FORM = 0
                Dim A_SQL As String = fAccount_Journal_SQL(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, gsID, dtpDATE.Value, 0, fNumisNULL(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
                If fNumisNULL(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                    fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 23, gsID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
                Else
                    A_SQL = A_SQL & fAccount_Journal_SQL(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, gsID, dtpDATE.Value, 1, fNumisNULL(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
                End If
                fExecutedOnly(A_SQL)
            End If
            '================================
            fSaveItem_Invoice(gsID)


        End If

        If gsID <> 0 Then
            gsNew = True
            gsID = 0
            fclear_Info()
            fLoad_Reference()
            fControlEnable(True)
            Dim S As Integer = 0
            If rbDINE_IN.Checked = True Then
                S = gsTableSelect
                fRefreshTable()
            Else

                If rbTAKE_OUT.Checked = True Then

                    S = gsNO_TAKEOUT + 1

                ElseIf rbDINE_IN.Checked = True Then
                    S = gsNO_DELIVERY + 1

                End If
                gsTableSelect = S
                fRefreshTable()


            End If


            fGetDefaultTable(S)
        End If

        If rbDINE_IN.Checked = True Then
            If gsPOS_SERVED_ONLY = False Then
                If fMessagePOSYesNO("Create payment?") = True Then
                    fCreatePayment()
                End If
            Else
                fCreatePayment()
            End If

        Else

            fCreatePayment()

        End If

    End Sub
    Private Sub fRefreshItem_Invoice(ByVal xID As Integer)
        bRefreshItem = True
        dgvProductItem.Rows.Clear()
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim sGROUP_ITEM_COUNT As Integer = 0
        Dim sQuery As String = "SELECT 
  ii.`ID`,
  i.`CODE`,
  i.`DESCRIPTION`,
  ii.`QUANTITY`,
  u.`SYMBOL`,
  ii.`RATE`,
  d.`DESCRIPTION`,
  ii.`DISCOUNT_RATE`,
  ii.`AMOUNT`,
  ii.`TAXABLE`,
  u.`ID` AS UNIT_ID,
  'S' AS `CONTROL_STATUS`,
  rt.`ID` AS `RATE_TYPE`,
  ii.`UNIT_BASE_QUANTITY`,
  d.`ID` AS `DISCOUNT_ID`,
  ii.`TAXABLE_AMOUNT`,
  ii.`TAX_AMOUNT`,
  ii.`COGS_ACCOUNT_ID`,
  ii.`ASSET_ACCOUNT_ID`,
  ii.`INCOME_ACCOUNT_ID`,
  ii.`REF_LINE_ID`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`,
  ii.`GROUP_LINE_ID`,
  ii.`PRICE_LEVEL_ID`,
   i.TYPE as `ITEM_TYPE`,
  ii.PRINT_IN_FORMS
FROM

  invoice_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    WHERE  ii.`INVOICE_ID` = '" & gsID & "' Order by ii.LINE_NO"
        If dgvProductItem.Columns.Count = 0 Then Exit Sub

        Try
            Dim x As Integer = 0
            '  cn.Open()
            Dim rd As DataTableReader = fReader(sQuery)
            While rd.Read

                dgvProductItem.Rows.Add()

                If fNumisNULL(rd("GROUP_LINE_ID")) <> 0 Then

                    sGROUP_ITEM_ID = fNumisNULL(rd("GROUP_LINE_ID"))
                    sGROUP_ITEM_COUNT = sGROUP_ITEM_COUNT + 1

                Else
                    sGROUP_ITEM_COUNT = 0
                End If

                For i As Integer = 0 To rd.FieldCount - 1

                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatStandard(fNumisNULL(rd(i)))
                        ElseIf fCheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = fNumFormatNoDecimal(fNumisNULL(rd(i)))
                        ElseIf fCheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(fNumisNULL(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = fNumisNULL(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = fTextisNULL(rd(i))
                            End If
                        End If
                    End With

                Next

                If CBool(fNumisNULL(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If

                x = x + 1
            End While
            rd.Close()

        Catch ex As Exception
            fMessageboxError(ex)
        Finally
            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = fFieldCollector(Me)

        End Try
        bRefreshItem = False

    End Sub
    Private Function fAutoNumber(ByVal I As Integer) As Integer
        Dim N As Integer = 1
        If rbDELIVERY.Checked = True Then
            Dim rd As DataTableReader = fReader($"select NEXT_ID from pos_auto_number where ORDER_TYPE_ID = '{gsDELIVERY_ID}' and POS_MACHINE_ID='{gsPOS_MACHINE_ID}' limit 1;")
            If rd.Read Then
                N = fNumisNULL(rd("NEXT_ID"))
                fExecutedOnly($"UPDATE POS_AUTO_NUMBER SET NEXT_ID ='{N + 1}' WHERE ORDER_TYPE_ID='{gsDELIVERY_ID}'and POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  limit 1;")
            Else
                fExecutedOnly($"INSERT INTO POS_AUTO_NUMBER SET  ORDER_TYPE_ID='{gsDELIVERY_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',NEXT_ID ='2' ")
            End If
            rd.Close()
            Return N
        ElseIf rbTAKE_OUT.Checked = True Then
            Dim rd As DataTableReader = fReader($"select NEXT_ID from pos_auto_number where ORDER_TYPE_ID = '{gsTAKE_OUT_ID}' and POS_MACHINE_ID='{gsPOS_MACHINE_ID}' limit 1;")
            If rd.Read Then
                N = fNumisNULL(rd("NEXT_ID"))
                fExecutedOnly($"UPDATE POS_AUTO_NUMBER SET NEXT_ID ='{N + 1}' WHERE ORDER_TYPE_ID='{gsTAKE_OUT_ID}'and POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  limit 1;")
            Else
                fExecutedOnly($"INSERT INTO POS_AUTO_NUMBER  SET ORDER_TYPE_ID='{gsTAKE_OUT_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',NEXT_ID ='2' ")
            End If
            rd.Close()
            Return N
        Else
            Return I
        End If
    End Function
    Private Sub fSaveSalesOrder()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please Customer")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            fMessageboxInfo("No item Enter")
            Exit Sub
        End If

        If fACCESS_NEW_EDIT(frmSalesOrder, gsNew) = False Then
            Exit Sub
        End If

        If gsNew = True Then

            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If

            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = fNEXT_CODE("SALES_ORDER", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("sales_order")
            gsTableSelect = fAutoNumber(gsTableSelect)
            Dim ORDER_TYPE_ID As Integer = 0
            If rbDINE_IN.Checked = True Then
                ORDER_TYPE_ID = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                ORDER_TYPE_ID = gsTAKE_OUT_ID
            ElseIf rbDELIVERY.Checked = True Then
                ORDER_TYPE_ID = gsDELIVERY_ID
            End If

            squery = squery & $",ID='{gsID}',RECORDED_ON='{Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss")}',DATE_NEEDED='{fDateFormatMYSQL(Date.Now)}',SHIP_VIA_ID='{ORDER_TYPE_ID}',SHIP_TO='{gsTableSelect}',STATUS='16',STATUS_DATE ='" & Format(DateTime.Now, "yyyy-MM-dd HH:mm:ss") & "'"
            ' squery = fNullOTherField(squery, "sales_order")
            fExecutedOnly("INSERT INTO sales_order SET " & squery)
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        Else

            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If

            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me)
            squery = squery & " WHERE ID = '" & gsID & "' limit 1"
            fExecutedOnly("UPDATE sales_order SET " & squery)
            fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If fTransactionCheck(gsID, "sales_order") = False Then
            fMessageboxWarning("Please try again")
            Exit Sub
        Else
            fSaveItem_sales_order(gsID)  ' Save item
        End If


        If gsID <> 0 Then


            gsNew = True
            gsID = 0

            fclear_Info()
            fLoad_Reference()
            fControlEnable(True)
            Dim S As Integer = gsTableSelect
            fRefreshTable()
            fGetDefaultTable(S)
        End If


    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()
        gsID = ""
        gsNew = True

    End Sub
    Private Sub fEstimate_ITEM_UPDATE(ByVal prITEM_ID As Double, ByVal prINVOICED_QTY As Double, ByVal ADD_EDIT As Boolean)
        If prITEM_ID = 0 Then
            Exit Sub
        End If

        Dim SO_SQL As String

        Dim get_SO_ID As String = fGetFieldValue("estimate_items", "ID", prITEM_ID, "estimate_ID")

        If ADD_EDIT = True Then
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & prITEM_ID & "' Limit 1"
        Else
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = NULL,`CLOSED` = '0' where ID = '" & prITEM_ID & "' Limit 1"
        End If
        fExecutedOnly(SO_SQL)

        fExecutedOnly("Update Estimate set `STATUS` = '3'  where ID = '" & get_SO_ID & "' limit 1")
    End Sub
    Private Sub fSaveItem_Invoice(ByVal dID As Integer)

        Dim GET_SO_ID As Integer = 0
        If dgvProductItem.Rows.Count = 0 Then Exit Sub
        Dim sGROUP_ITEM_ID As Integer = 0

        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim SQL_SCRIPT As String = ""
        Dim InvSQL As String = ""
        Dim SQL_SO As String = ""
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = SQL_SCRIPT & "UPDATE INVOICE_ITEMS SET LINE_NO='" & i & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE INVOICE_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;"
                        InvSQL = InvSQL & fINVENTORY_JOURNAL(dgvProductItem.Rows(i))

                        If fGROUP_ITEM(fNumisNULL(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = fNumisNULL(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf fNumisNULL(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If


                    Case "A"

                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("INVOICE_ITEMS")
                        SQL_SCRIPT = SQL_SCRIPT & "INSERT INTO INVOICE_ITEMS SET PRINT_IN_FORMS ='" & fNumisNULL(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & i & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",REF_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("REF_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & ",INVOICE_ID ='" & dID & "',GROUP_LINE_ID = " & fGotNullNumber(sGROUP_ITEM_ID) & ";"
                        .Cells("ID").Value = i_ID
                        .Cells("CONTROL_STATUS").Value = "S"
                        InvSQL = InvSQL & fINVENTORY_JOURNAL(dgvProductItem.Rows(i))
                        SQL_SO = SQL_SO & fSO_ITEM_UPDATE(fNumisNULL(.Cells("REF_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True, GET_SO_ID)

                        If fGROUP_ITEM(fNumisNULL(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = fNumisNULL(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf fNumisNULL(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If
                    Case "E"
                        .Cells("CONTROL_STATUS").Value = "S"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = SQL_SCRIPT & "UPDATE INVOICE_ITEMS SET LINE_NO='" & i & "',QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',COGS_ACCOUNT_ID =" & fGotNullNumber(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value)) & ",ASSET_ACCOUNT_ID=" & fGotNullNumber(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value)) & ",INCOME_ACCOUNT_ID = " & fGotNullNumber(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value)) & ",REF_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("REF_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",PRICE_LEVEL_ID =" & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value)) & " WHERE INVOICE_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & " limit 1;"
                        InvSQL = InvSQL & fINVENTORY_JOURNAL(dgvProductItem.Rows(i))
                        SQL_SO = SQL_SO & fSO_ITEM_UPDATE(fNumisNULL(.Cells("REF_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True, GET_SO_ID)

                        If fGROUP_ITEM(fNumisNULL(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = fNumisNULL(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf fNumisNULL(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If

                    Case "D"

                        fExecutedOnly("DELETE FROM INVOICE_ITEMS WHERE INVOICE_ID ='" & dID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "' limit 1;")
                        SQL_SO = SQL_SO & fSO_ITEM_UPDATE(fNumisNULL(.Cells("REF_LINE_ID").Value), 0, False, GET_SO_ID)

                        fItemInventoryRemoveFixed(10, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue)
                        fDeleteItem_INVENTORY_ITEM_RECALCULATE_SINGLE(fNumisNULL(.Cells("ITEM_ID").Value), cmbLOCATION_ID.SelectedValue, dtpDATE.Value)

                        fJournalAccountRemoveFixed("INVOICE_ITEMS", .Cells("ID").Value, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, fNumisNULL(.Cells("ITEM_ID").Value))
                        fJournalAccountRemoveFixed("INVOICE_ITEMS", .Cells("ID").Value, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)

                End Select
            End With
        Next


        If SQL_SCRIPT <> "" Then
            fExecutedOnly(SQL_SCRIPT)
        End If
        If SQL_SO <> "" Then
            fExecutedOnly(SQL_SO)
        End If

        If InvSQL <> "" Then
            fExecutedOnly(InvSQL)
        End If


        Dim LAST_SO As Integer = 0
        For N As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(N)
                If fNumisNULL(.Cells("REF_LINE_ID").Value) <> 0 Then

                    Dim SO_ID As Integer = fNumFieldValue("sales_order_items", "id", fNumisNULL(.Cells("REF_LINE_ID").Value), "SALES_ORDER_ID")
                    If LAST_SO <> SO_ID Then
                        fCheck_Status_SO(SO_ID)
                    End If

                    LAST_SO = SO_ID
                End If
            End With
        Next



    End Sub
    Private Sub fCheck_Status_SO(ByVal THIS_SO_ID As Integer)

        Dim rd As DataTableReader = fReader($"select  * from sales_order_items Where SALES_ORDER_ID = '{THIS_SO_ID}' and `CLOSED` = '1' limit 1;")
        Dim E As Integer
        If rd.Read Then
            E = 12 ' item received
        Else
            E = 2
        End If
        rd.Close()
        fExecutedOnly($"Update sales_order set `STATUS` = '{E}'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}' limit 1")

    End Sub
    Private Sub fCheck_Status_SO_DEL(ByVal THIS_SO_ID As Integer)

        Dim SQL As String = $"UPDATE sales_order_items set `INVOICED_QTY` = NULL, `CLOSED` = '0'  Where SALES_ORDER_ID = '{THIS_SO_ID}';"
        SQL = SQL & $"Update sales_order set `STATUS` = '16'  where ID = '{THIS_SO_ID}' and LOCATION_ID='{cmbLOCATION_ID.SelectedValue}' limit 1;"

        fExecutedOnly(SQL)

    End Sub
    Private Function fSO_ITEM_UPDATE(ByVal REF_LINE_ID As Integer, ByVal prINVOICED_QTY As Double, ByVal isUPDATE As Boolean, ByRef THIS_SO_ID As Integer) As String

        Dim SO_SQL As String = ""
        If REF_LINE_ID <> 0 Then
            Dim Get_SO_ID As Integer = fNumFieldValue("sales_order_items", "ID", REF_LINE_ID, "SALES_ORDER_ID")
            If isUPDATE = True Then
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & REF_LINE_ID & "' Limit 1;"
            Else
                SO_SQL = "Update sales_order_items SET `INVOICED_QTY` = NULL,`CLOSED` = '0' where ID = '" & REF_LINE_ID & "' Limit 1;"
            End If
            THIS_SO_ID = Get_SO_ID
        End If

        Return SO_SQL
    End Function
    Private Function fINVENTORY_JOURNAL(ByVal dgvROW As DataGridViewRow) As String
        Dim StrSQL As String = ""
        With dgvROW

            If .Cells("ITEM_TYPE").Value = 5 Or .Cells("ITEM_TYPE").Value = 6 Then

            Else

                'INVENTORY ITEM
                Dim LAST_ENDING_UNIT_COST As Double = 0
                If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                    'ITEM INVENTORY/ ASSEMBLY ONLY
                    Dim THIS_QTY As Double = fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) * fNumisNULL(.Cells("QTY").Value)

                    StrSQL = StrSQL & fItem_Inventory_SQL(.Cells("ITEM_ID").Value, cmbLOCATION_ID.SelectedValue, THIS_QTY * -1, LAST_ENDING_UNIT_COST, 10, fNumisNULL(.Cells("ID").Value), dtpDATE.Value)
                End If

                If gsSkipJournalEntry = False Then
                    'INCOME_ACCOUNT_ID
                    Dim AMT As Double = 0
                    If fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                        AMT = fNumisNULL(.Cells("TAXABLE_AMOUNT").Value)
                    Else
                        AMT = fNumisNULL(.Cells("AMOUNT").Value)
                    End If

                    Dim E As Integer = 0
                    If fNumisNULL(.Cells("AMOUNT").Value) <= 0 Then
                        E = 0
                    Else
                        E = 1
                    End If

                    StrSQL = StrSQL & fAccount_Journal_SQL(fNumisNULL(.Cells("INCOME_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 24, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, E, AMT, gsJOURNAL_NO_FORM)

                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        'ITEM INVENTORY/ ASSEMBLY
                        'COST ONLY
                        Dim AMT_COST As Double = LAST_ENDING_UNIT_COST * fNumisNULL(.Cells("QTY").Value)
                        'ASSET_ACCOUNT_ID
                        StrSQL = StrSQL & fAccount_Journal_SQL(fNumisNULL(.Cells("ASSET_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 24, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 1, AMT_COST, gsJOURNAL_NO_FORM)
                        'COGS_ACCOUNT_ID
                        StrSQL = StrSQL & fAccount_Journal_SQL(fNumisNULL(.Cells("COGS_ACCOUNT_ID").Value), cmbLOCATION_ID.SelectedValue, .Cells("ITEM_ID").Value, 24, fNumisNULL(.Cells("ID").Value), dtpDATE.Value, 0, AMT_COST, gsJOURNAL_NO_FORM)

                    End If

                End If

            End If
        End With
        Return StrSQL
    End Function

    Private Sub fSaveItem_sales_order(ByVal dID As String)

        If dgvProductItem.Rows.Count = 0 Then Exit Sub
        Dim sGROUP_ITEM_ID As Integer = 0
        Dim sGROUP_ITEM_ACTIVE As Boolean = False
        Dim SQL_SCRIPT As String = ""
        Dim SQL_LIST As String = ""
        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            With dgvProductItem.Rows(i)


                Select Case .Cells("CONTROL_STATUS").Value

                    Case "S"
                        'UPDATE TAX ONLY
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE SALES_ORDER_ITEMS SET TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value))
                        fExecutedOnly(SQL_SCRIPT)
                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = fObjectTypeMap_ID("SALES_ORDER_ITEMS")
                        SQL_SCRIPT = "INSERT INTO SALES_ORDER_ITEMS SET  GROUP_LINE_ID = " & fGotNullNumber((.Cells("GROUP_LINE_ID").Value)) & ",PRINT_IN_FORMS ='" & fNumisNULL(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & fGetMaxField_LINE("LINE_NO", "SALES_ORDER_ITEMS", "SALES_ORDER_ID", dID) & "',ID='" & i_ID & "',QUANTITY ='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & ",SALES_ORDER_ID ='" & dID & "',CLOSED ='0',INVOICED_QTY= NULL,PRICE_LEVEL_ID = " & fGotNullNumber(fNumisNULL(.Cells("PRICE_LEVEL_ID").Value))
                        fExecutedOnly(SQL_SCRIPT)

                        fEstimate_ITEM_UPDATE(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True)

                        If fGROUP_ITEM(fNumisNULL(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = fNumisNULL(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf fNumisNULL(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If

                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, fNumisNULL(.Cells("AMOUNT").Value), fNumisNULL(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE SALES_ORDER_ITEMS SET QUANTITY='" & fNumisNULL(.Cells("QTY").Value) & "',RATE = '" & fNumisNULL(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & fGotNullNumber(fNumisNULL(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & fNumisNULL(.Cells("AMOUNT").Value) & "',TAXABLE='" & fNumisNULL(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & fNumisNULL(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & fNumisNULL(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & fNumisNULL(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & fGotNullNumber(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & fNumisNULL(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & fNumisNULL(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & fGotNullNumber(fNumisNULL(.Cells("UNIT_ID").Value)) & " WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & fGotNullNumber(fNumisNULL(.Cells("ID").Value)) & ""
                        fExecutedOnly(SQL_SCRIPT)
                        fEstimate_ITEM_UPDATE(fNumisNULL(.Cells("ESTIMATE_LINE_ID").Value), fNumisNULL(.Cells("QTY").Value), True)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM SALES_ORDER_ITEMS WHERE SALES_ORDER_ID ='" & dID & "' and ID = '" & fNumisNULL(.Cells("ID").Value) & "'"
                        fExecutedOnly(SQL_SCRIPT)
                End Select

            End With


        Next


    End Sub


    Private Sub dgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            fComputed()
        End If
    End Sub

    Private Sub frmSalesOrder_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

    End Sub

    Private Sub frmSalesOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height

        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = H_PC
        Me.Location = New Point(0, 0)
        If FLP_TABLE.Controls.Count = 0 And gsDINE_IN_ID <> 0 Then
            rbDINE_IN.Checked = True
        End If


        Timer1.Start()

        btnMENU.PerformClick()

    End Sub

    Private Sub cmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        If bEntryAddItem = True Then
            Exit Sub
        End If

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub

        If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        xlblCustomer_Name.Text = cmbCUSTOMER_ID.Text
        xlblAcctNo.Text = fGetFieldValue("CONTACT", "ID", fNumisNULL(cmbCUSTOMER_ID.SelectedValue), "ACCOUNT_NO")
        Dim rd As DataTableReader = fReader($"select TAX_ID from contact where id ='{fNumisNULL(cmbCUSTOMER_ID.SelectedValue)}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If fNumisNULL(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = fNumisNULL(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = fOutPutTaxDefault()
            End If
        End If

    End Sub

    'Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
    '    If gsNew = True Then
    '        tsSaveNew_Click(sender, e)
    '    Else
    '        If fCheckHasChange() = True Then
    '            If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
    '                tChangeAccept = False
    '                tsSaveNew_Click(sender, e)
    '                If tChangeAccept = False Then
    '                    fMessageboxInfo("Cancel")
    '                    Exit Sub
    '                End If
    '            Else
    '                Exit Sub
    '            End If
    '        End If
    '    End If
    '    If gsNew = False Then
    '        If fACCESS_PRINT_PREVIEW(Me) = False Then
    '            Exit Sub
    '        End If
    '        '   Dim prFile_name As String = "crySalesOrder.rpt"
    '        ' Dim prPrint_Title As String = "Sales Order"
    '        Dim prFile_name As String = ""
    '        Dim prPrint_Title As String = ""
    '        Dim cn As New OleDb.OleDbConnection(fMS_Con)
    '        Try
    '            cn.Open()
    '            Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
    '            If r.Read Then
    '                prPrint_Title = r("print_title")
    '                prFile_name = r("file_name")
    '            End If
    '            cn.Close()
    '        Catch ex As Exception
    '            If cn.State = ConnectionState.Open Then
    '                cn.Close()
    '            End If
    '        End Try



    '        gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
    '        fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
    '        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
    '        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
    '        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
    '        fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
    '        fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
    '        fReportExporPDF(gscryRpt, prPrint_Title)
    '        gsToolPanelView = False
    '        fPreviewReport(prPrint_Title)
    '    End If
    'End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'If gsNew = True Then
        '    tsSaveNew_Click(sender, e)
        'Else
        '    If fCheckHasChange() = True Then
        '        If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
        '            tChangeAccept = False
        '            tsSaveNew_Click(sender, e)
        '            If tChangeAccept = False Then
        '                fMessageboxInfo("Cancel")
        '                Exit Sub
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End If
        'End If
        'If gsNew = False Then
        '    If fACCESS_PRINT_PREVIEW(Me) = False Then
        '        Exit Sub
        '    End If
        '    '   Dim prFile_name As String = "crySalesOrder.rpt"
        '    '  Dim prPrint_Title As String = "Sales Order"
        '    Dim prFile_name As String = ""
        '    Dim prPrint_Title As String = ""
        '    Dim cn As New OleDb.OleDbConnection(fMS_Con)
        '    Try
        '        cn.Open()
        '        Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
        '        If r.Read Then
        '            prPrint_Title = r("print_title")
        '            prFile_name = r("file_name")
        '        End If
        '        cn.Close()
        '    Catch ex As Exception
        '        If cn.State = ConnectionState.Open Then
        '            cn.Close()
        '        End If
        '    End Try


        '    gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        '    fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
        '    fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        '    fReportExporPDF(gscryRpt, prPrint_Title)
        '    gscryRpt.PrintToPrinter(1, False, 0, 0)
        'End If


    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click

    End Sub
    Private Sub Discard_Sales_Order()
        If gsNew = True Then
            fclear_Info()

        Else
            If fMessageBoxQuestion("Create new?") = True Then
                gsNew = True
                gsID = ""
                fclear_Info()

            Else
                fclear_Info()
                fRefreshInfo_sales_order(gsID)
                fRefreshItem_sales_order(gsID)
            End If

        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        fHistoryList(gsID, Me)
    End Sub



    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click

    End Sub

    Private Sub cmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
        CustomerTax()
    End Sub
    Private Sub CustomerTax()
        Application.DoEvents()
        Dim s As Integer
        Try
            s = cmbCUSTOMER_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If gsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        Dim rd As DataTableReader = fReader($"select * from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If fNumisNULL(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = fNumisNULL(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub


    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If gsIsOrder = True Then
            fSales_order_add_item()
        Else
            fInvoice_add_item()
        End If


    End Sub
    Private Sub fInvoice_add_item()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Or cmbCUSTOMER_ID.SelectedValue Is Nothing Or cmbCUSTOMER_ID.Text = "" Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If

        With frmAddItemTouchScreen
            bRefreshItem = False
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE
            .sFormName = "frmInvoice"

            .StartPosition = FormStartPosition.Manual

            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            If gsMemberDiscount <> 0 Then
                .gsMEMBER = True
                .gsMEMEBER_DISCOUNT = gsMemberDiscount
            End If




            If My.Computer.Screen.WorkingArea.Width < 1200 Then

            Else
                .Size = New Size(FLP_TABLE.Size.Width, Me.Size.Height)
            End If

            .Location = New Point(0, 0)
            .ShowDialog()

        End With
        fComputed()
        frmAddItemTouchScreen.Dispose()
        frmAddItemTouchScreen = Nothing
    End Sub
    Private Sub fSales_order_add_item()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            fMessageboxInfo("Please select customer")
            Exit Sub
        End If



        With frmAddItemTouchScreen

            .sFormName = "frmSalesOrder"
            .gsLOCATION_ID = cmbLOCATION_ID.SelectedValue
            .gsDate = dtpDATE.Value
            .dgv = dgvProductItem
            .gscmbOUTPUT_TAX_ID = cmbOUTPUT_TAX_ID
            .gslblOUTPUT_TAX_AMOUNT = lblOUTPUT_TAX_AMOUNT
            .gslblAMOUNT = lblAMOUNT
            .gslblTAXABLE_AMOUNT = lblTAXABLE_AMOUNT
            .gslblNONTAXABLE_AMOUNT = lblNONTAXABLE_AMOUNT
            .gslblOUTPUT_TAX_RATE = lblOUTPUT_TAX_RATE
            .gsPRICE_LEVEL_ID = 0
            .StartPosition = FormStartPosition.Manual
            .gsNonInventoryItem = True



            If My.Computer.Screen.WorkingArea.Width < 1200 Then

            Else
                .Size = New Size(FLP_TABLE.Size.Width, Me.Size.Height)
            End If

            .Location = New Point(0, 0)
            .ShowDialog()

        End With
        fComputed()
        frmAddItemTouchScreen.Dispose()
        frmAddItemTouchScreen = Nothing
    End Sub
    Private Sub tsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        fEditItem()
    End Sub

    Private Sub tsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            fRemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            fComputed()
        End If
    End Sub



    Private Sub tsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsTextFind.TextChanged
        fGetQuickFind(dgvProductItem, tsTextFind.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'If gsNew = True Then
        '    tsSaveNew_Click(sender, e)
        'Else
        '    If fCheckHasChange() = True Then
        '        If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
        '            tChangeAccept = False
        '            tsSaveNew_Click(sender, e)
        '            If tChangeAccept = False Then
        '                fMessageboxInfo("Cancel")
        '                Exit Sub
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End If
        'End If

        'If gsNew = True Then Exit Sub

        'frmPrintPage.frmName = Me.Name
        'frmPrintPage.ShowDialog()

        'Dim v As Integer = frmPrintPage.prValue
        'If v = 1 Or v = 2 Then

        '    Dim prFile_name As String = ""
        '    Dim prPrint_Title As String = ""
        '    Dim cn As New OleDb.OleDbConnection(fMS_Con)
        '    Try
        '        cn.Open()
        '        Dim r As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
        '        If r.Read Then
        '            prPrint_Title = r("print_title")
        '            prFile_name = r("file_name")
        '        End If
        '        cn.Close()
        '    Catch ex As Exception
        '        If cn.State = ConnectionState.Open Then
        '            cn.Close()
        '        End If
        '    End Try

        '    gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
        '    fCryParameterInsertValue(gscryRpt, Val(gsID), "myid")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
        '    fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
        '    fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        '    fReportExporPDF(gscryRpt, prPrint_Title)
        '    If v = 2 Then
        '        gsToolPanelView = False

        '        fPreviewReport(prPrint_Title & "Report")
        '    Else
        '        gscryRpt.PrintToPrinter(1, False, 0, 0)

        '    End If



        'End If
        'frmPrintPage.Dispose()
        'frmPrintPage = Nothing

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        With FLP_TABLE
            If .Controls.Count = 0 Then Exit Sub


            If rbDINE_IN.Checked = True Then


                For N As Integer = 1 To gsPOS_RESTAURANT_TABLE_NO

                    Dim PNL As Panel = .Controls($"pnl{N}")
                    Dim Btn As Button = PNL.Controls($"btnOrder{N}")
                    If SelectTable = True And gsTableSelect <> N Then

                        PNL.BackColor = Color.White
                        PNL.ForeColor = Color.Black
                        Btn.ForeColor = Color.Black

                    End If


                    Dim GET_RECORD As Label = PNL.Controls($"lblRECORD{N}")
                    Dim GET_DISPLAY_TIME As Label = PNL.Controls($"lblTime{N}")
                    If GET_RECORD.Text <> "" Then

                        Dim DTR As DateTime = CDate(GET_RECORD.Text)
                        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(DateDiff(DateInterval.Second, DTR, DateTime.Now))
                        GET_DISPLAY_TIME.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Seconds.ToString.PadLeft(2, "0"c)

                    Else
                        GET_DISPLAY_TIME.Text = "00:00:00"
                    End If

                Next
            Else

                For N As Integer = 1 To FLP_TABLE.Controls.Count

                    Dim PNL As Panel = .Controls($"pnl{N}")
                    Dim Btn As Button = PNL.Controls($"btnOrder{N}")
                    If SelectTable = True And gsTableSelect <> Btn.AccessibleDescription Then

                        PNL.BackColor = Color.White
                        PNL.ForeColor = Color.Black
                        Btn.ForeColor = Color.Black

                    End If


                    Dim GET_RECORD As Label = PNL.Controls($"lblRECORD{N}")
                    Dim GET_DISPLAY_TIME As Label = PNL.Controls($"lblTime{N}")
                    If GET_RECORD.Text <> "" Then

                        Dim DTR As DateTime = CDate(GET_RECORD.Text)
                        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(DateDiff(DateInterval.Second, DTR, DateTime.Now))
                        GET_DISPLAY_TIME.Text = iSpan.Hours.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Minutes.ToString.PadLeft(2, "0"c) & ":" &
                        iSpan.Seconds.ToString.PadLeft(2, "0"c)

                    Else
                        GET_DISPLAY_TIME.Text = "00:00:00"
                    End If

                Next



            End If
        End With

        SelectTable = False
    End Sub


    Private Sub rbTAKE_OUT_CheckedChanged(sender As Object, e As EventArgs) Handles rbTAKE_OUT.CheckedChanged
        If rbTAKE_OUT.Checked = True Then

            If Ship_Via_count = 1 Then
                gsThemeNo = 0
            Else
                gsThemeNo = 4
            End If

            fMaterialSkin(Me)
            gsTableSelect = 0
            fRefreshTable()
            xxlblSalesman.Text = "SALES MAN"
        End If

    End Sub

    Private Sub rbDINE_IN_CheckedChanged(sender As Object, e As EventArgs) Handles rbDINE_IN.CheckedChanged

        If rbDINE_IN.Checked = True Then

            If Ship_Via_count = 1 Then
                gsThemeNo = 0
            Else
                gsThemeNo = 1
            End If
            fMaterialSkin(Me)
            gsTableSelect = 1
            fRefreshTable()
            xxlblSalesman.Text = "SALES MAN"
        End If

    End Sub
    Private Sub cmbSALES_REP_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSALES_REP_ID.SelectedIndexChanged
        xlblSalesRep.Text = ""
        Try
            Dim s As String = cmbSALES_REP_ID.SelectedValue
        Catch ex As Exception
            Exit Sub
        End Try
        If cmbSALES_REP_ID Is Nothing Then Exit Sub
        If gsNew = False Then Exit Sub
        If cmbSALES_REP_ID.Text = "" Then Exit Sub
        xlblSalesRep.Text = cmbSALES_REP_ID.Text


    End Sub

    Private Sub btnBACK_Click(sender As Object, e As EventArgs)


    End Sub



    Private Sub btnNEWORDER_Click(sender As Object, e As EventArgs) Handles btnNEWORDER.Click
        gsIsOrder = True
        gsID = 0
        gsNew = True
        fclear_Info()
        fLoad_Reference()
        fControlEnable(False)

    End Sub

    Private Sub btnRECEIVED_ORDER_Click(sender As Object, e As EventArgs) Handles btnRECEIVED_ORDER.Click
        Dim bGot_item_Added = False
        gsIsOrder = False
        If dgvSalesOrder.Rows.Count <> 0 Then
            dgvSalesOrder.Select()
            frmPOSServed.gsCUSTOMER_ID = fNumFieldValue("sales_order", "id", dgvSalesOrder.CurrentRow.Cells(0).Value, "CUSTOMER_ID")
        Else


            If rbDINE_IN.Checked = True Then

            ElseIf rbTAKE_OUT.Checked = True Then
                gsTableSelect = 0
            ElseIf rbDELIVERY.Checked = True Then
                gsTableSelect = 0
            End If

            GoTo CREATE_NOW

            frmPOSServed.gsCUSTOMER_ID = 0

        End If


        If rbDINE_IN.Checked = True Then
            frmPOSServed.gsORDER_TYPE = gsDINE_IN_ID
        ElseIf rbTAKE_OUT.Checked = True Then
            frmPOSServed.gsORDER_TYPE = gsTAKE_OUT_ID
        ElseIf rbDELIVERY.Checked = True Then
            frmPOSServed.gsORDER_TYPE = gsDELIVERY_ID
        End If

        frmPOSServed.gsTABLE_NO = gsTableSelect


        frmPOSServed.ShowDialog()
        gsTableSelect = frmPOSServed.gsTABLE_NO
        If frmPOSServed.gsOK = True Then
CREATE_NOW:


            gsID = 0
            gsNew = True
            fclear_Info()
            fLoad_Reference()
            fControlEnable(False)

            If frmPOSServed.dgvSELECTED.Rows.Count <> 0 Then
                bGot_item_Added = True
                Dim dgv_top As DataGridView = frmPOSServed.dgvSELECTED
                For I As Integer = 0 To dgv_top.Rows.Count - 1
                    Dim rd As DataTableReader = fReader($"select s.*,d.description as desc_name from SALES_ORDER_ITEMS as S left outer join discount_type as d on d.id =  s.DISCOUNT_TYPE  where S.SALES_ORDER_ID='{dgv_top.Rows(I).Cells(0).Value}' and S.GROUP_LINE_ID is null order by S.LINE_NO")
                    While rd.Read
                        fRow_Data_Item_Invoice(dgvProductItem, True, fNumisNULL(rd("ITEM_ID")), fNumisNULL(rd("QUANTITY")), fNumisNULL(rd("RATE")), fTextisNULL(rd("desc_name")), fNumisNULL(rd("DISCOUNT_TYPE")), fNumisNULL(rd("AMOUNT")), CBool(fNumisNULL(rd("TAXABLE"))), fNumisNULL(rd("UNIT_ID")), "A", fNumisNULL(rd("UNIT_BASE_QUANTITY")), fTextisNULL(rd("DISCOUNT_TYPE")), fNumisNULL(rd("ORG_AMOUNT")), fNumisNULL(rd("ID")), fTextisNULL(rd("PRICE_LEVEL_ID")), 0, CBool(fNumisNULL(rd("PRINT_IN_FORMS"))))
                    End While
                    rd.Close()
                Next
            End If
            If frmPOSServed.gsCUSTOMER_ID = 0 Then
                cmbCUSTOMER_ID.SelectedValue = gsPOSDefaultCustomer_ID
            Else
                cmbCUSTOMER_ID.SelectedValue = frmPOSServed.gsCUSTOMER_ID
            End If

        End If
        frmPOSServed.Dispose()
        frmPOSServed = Nothing
        If bGot_item_Added = True Then


            If rbDINE_IN.Checked = True Then

                If fMessagePOSYesNO($"Do you want to save this served order?") = True Then
                    btnSAVE.PerformClick()
                End If

            Else
                btnSAVE.PerformClick()
                btnCreatePayment.PerformClick()

            End If



        End If
    End Sub

    Private Sub btnPODERDER_DETAILS_Click(sender As Object, e As EventArgs) Handles btnPODERDER_DETAILS.Click
        If dgvSalesOrder.Rows.Count = 0 Then
            fMessageboxInfo("No order process created.")
            Exit Sub
        End If
        gsIsOrder = True
        dgvSalesOrder.Select()
        gsID = dgvSalesOrder.CurrentRow.Cells("ID").Value
        gsNew = False
        fclear_Info()
        fLoad_Reference()
        fControlEnable(False)
    End Sub

    Private Sub btnCANCEL_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSAVE_Click_1(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If gsIsOrder = True Then

            fSaveSalesOrder()
        Else
            fSaveInvoice()
        End If


    End Sub

    Private Sub btnCUSTOMER_Click_1(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
        frmPOSContacts.gsContact_Type = 1
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

            cmbCUSTOMER_ID.SelectedValue = frmPOSContacts.gsContact_ID
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing

        If bNewContact = True Then
            frmContactDetails.bNew = True
            '  frmContactDetails.PictureBox1.Image = tsCustomer.Image
            frmContactDetails.gsContact_Type = 1
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblCustomer_Name.Text = ""
                xlblAcctNo.Text = ""

                fComboBox(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = frmContactDetails.gsID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub btnSALESMAN_Click_1(sender As Object, e As EventArgs) Handles btnSALESMAN.Click
        frmPOSContacts.gsContact_Type = 2
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            If frmPOSContacts.gsContact_ID = 0 Then
                fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedIndex = -1
                xlblSalesRep.Text = ""
            Else
                fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmPOSContacts.gsContact_ID
            End If
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing
        If bNewContact = True Then
            '   frmContactDetails.PictureBox1.Image = tsSalesRep.Image
            frmContactDetails.bNew = True
            frmContactDetails.gsContact_Type = 2
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblSalesRep.Text = ""
                fComboBox(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmContactDetails.gsID
            End If
            frmContactDetails.Dispose()
            frmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub btnTAX_Click(sender As Object, e As EventArgs) Handles btnTAX.Click
        frmPOSTax.ShowDialog()
        If frmPOSTax.gsOk = True Then
            cmbOUTPUT_TAX_ID.SelectedValue = frmPOSTax.gsTax_Id
        End If


        frmPOSTax.Dispose()
        frmPOSTax = Nothing
    End Sub

    Private Sub btnCANCEL_Click_1(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        gsNew = True
        gsID = 0
        fclear_Info()
        fControlEnable(True)
    End Sub

    Private Sub btnVIEW_DETAILS_Click(sender As Object, e As EventArgs) Handles btnVIEW_DETAILS.Click
        If dgvInvoice.Rows.Count = 0 Then
            fMessageboxInfo("No order served created.")
            Exit Sub
        End If
        gsIsOrder = False
        dgvInvoice.Select()
        gsID = dgvInvoice.CurrentRow.Cells("ID").Value
        gsNew = False
        fclear_Info()
        fLoad_Reference()
        fControlEnable(False)
    End Sub



    Private Sub btnDELETE_Click(sender As Object, e As EventArgs) Handles btnDELETE.Click

        If gsIsOrder = True Then
            fDeletSalesOrder()
        Else
            fDeleteInvoice()
        End If

    End Sub
    Private Sub fDeleteInvoice()
        If gsNew = False Then
            If fACCESS_DELETE(frmInvoice) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If

            If fMessageBoxQuestion(gsMessageQuestion) = True Then


                Try

                    Dim rd As DataTableReader = fReader("select * from payment_invoices where invoice_id = '" & gsID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            fMessageboxWarning("Invalid delete invoice. payment are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            fExecutedOnly("delete from payment_invoices where invoice_id = '" & gsID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception

                    fMessageboxError(ex)
                    Exit Sub
                End Try
                'credit memo
                Try

                    Dim rd As DataTableReader = fReader("select * from `credit_memo_invoices` where invoice_id = '" & gsID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            fMessageboxWarning("Invalid delete invoice. credit memo are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            fExecutedOnly("delete from `credit_memo_invoices` where invoice_id = '" & gsID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception
                    'If cn.State = ConnectionState.Open Then
                    '    cn.Close()
                    'End If
                    fMessageboxError(ex)
                    Exit Sub
                End Try
                'tax credit
                Try
                    ' cn.Open()
                    Dim rd As DataTableReader = fReader("select * from `tax_credit_invoices` where invoice_id = '" & gsID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            fMessageboxWarning("Invalid delete invoice. tax credit are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            fExecutedOnly("delete from `tax_credit_invoices` where invoice_id = '" & gsID & "'")
                        End If


                    End If
                    rd.Close()
                Catch ex As Exception

                    fMessageboxError(ex)
                    Exit Sub
                End Try


                Try

                    Dim rd As DataTableReader = fReader("select REF_LINE_ID from `invoice_items` where INVOICE_ID = '" & gsID & "' and REF_LINE_ID  > '0' ")
                    Dim SO_ID As Integer = 0
                    While rd.Read
                        fSO_ITEM_UPDATE(fNumisNULL(rd("REF_LINE_ID")), 0, False, SO_ID)
                    End While
                    rd.Close()
                    fCheck_Status_SO(SO_ID)
                Catch ex As Exception
                    fMessageboxError(ex)
                    Exit Sub
                End Try

                fCursorLoadingOn(True)
                fJournalTransaction_Invoice_Delete(gsID)


                fDeleteItem_INVENTORY_ITEM_RECALCULATE(dgvProductItem, cmbLOCATION_ID.SelectedValue, dtpDATE.Value)


                fExecutedOnly("delete from invoice_items where invoice_id = '" & gsID & "'")
                fExecutedOnly("delete from invoice where id ='" & gsID & "' limit 1;")

                Dim LAST_SO As Integer = 0
                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        If fNumisNULL(.Cells("REF_LINE_ID").Value) <> 0 Then

                            Dim SO_ID As Integer = fNumFieldValue("sales_order_items", "id", fNumisNULL(.Cells("REF_LINE_ID").Value), "SALES_ORDER_ID")
                            If LAST_SO <> SO_ID Then
                                fCheck_Status_SO_DEL(SO_ID)
                            End If

                            LAST_SO = SO_ID
                        End If
                    End With
                Next

                fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                gsID = 0
                gsNew = True
                btnCANCEL.PerformClick()
                Dim S As Integer = gsTableSelect
                fRefreshTable()
                fGetDefaultTable(S)
                fCursorLoadingOn(False)
            End If


        End If

    End Sub
    Private Sub fDeletSalesOrder()
        If gsNew = False Then
            If fACCESS_DELETE(frmSalesOrder) = False Then
                Exit Sub
            End If
            If fIsClosingDate(dtpDATE.Value) = False Then
                Exit Sub
            End If
            If fMessageBoxQuestion(gsMessageQuestion) = True Then

                fExecutedOnly("DELETE FROM SALES_ORDER_ITEMS WHERE SALES_ORDER_ID = '" & gsID & "'")
                fExecutedOnly("DELETE FROM SALES_ORDER WHERE ID = '" & gsID & "'")
                fTransaction_Log(gsID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", fNumisNULL(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                gsID = 0
                gsNew = True
                btnCANCEL.PerformClick()
                Dim S As Integer = gsTableSelect
                fRefreshTable()
                fGetDefaultTable(S)

            End If

        End If
    End Sub



    Private Sub BtnCreatePayment_Click(sender As Object, e As EventArgs) Handles btnCreatePayment.Click
        fCreatePayment()
    End Sub
    Private Sub fCreatePayment()
        If dgvInvoice.Rows.Count = 0 Then
            fMessageboxInfo("No Served Order found.")
            Exit Sub
        End If

        If rbDELIVERY.Checked = True Then
            frmPOSCreatePayment.gsORDER_TYPE = gsDELIVERY_ID
        ElseIf rbDINE_IN.Checked = True Then
            frmPOSCreatePayment.gsORDER_TYPE = gsDINE_IN_ID
        ElseIf rbTAKE_OUT.Checked = True Then
            frmPOSCreatePayment.gsORDER_TYPE = gsTAKE_OUT_ID
        End If


        frmPOSCreatePayment.gsTABLE_NO = gsTableSelect
        dgvInvoice.Select()
        frmPOSCreatePayment.gsCUSTOMER_ID = fNumFieldValue("INVOICE", "ID", dgvInvoice.CurrentRow.Cells(0).Value, "CUSTOMER_ID")
        frmPOSCreatePayment.ShowDialog()
        If frmPOSCreatePayment.gsOK = True Then

            If fMessagePOSYesNO($"Do you want to Print Receipt?") = True Then
                Dim id As Integer = dgvInvoice.CurrentRow.Cells(0).Value
                Dim cn As New OleDb.OleDbConnection(fMS_Con)
                Dim prFile_name As String = "cryPOSRestoPayment.rpt"
                Dim prPrint_Title As String = "OFFICIAL RECEIPT"
                Dim ThisID As Integer = frmPOSCreatePayment.gsID
                gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
                fCryParameterInsertValue(gscryRpt, ThisID, "id")
                fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
                fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
                fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
                fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyTin"), "tin_number")
                fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
                fReportExporPDF(gscryRpt, prPrint_Title)

                If gsPOSPrintPreview = True Then
                    gsToolPanelView = False
                    frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                    frmReportViewer.Text = "POS Preview " & fDateTimeNow()
                    frmReportViewer.WindowState = FormWindowState.Normal
                    frmReportViewer.ShowDialog()
                    frmReportViewer.Dispose()
                Else
                    gscryRpt.PrintToPrinter(1, False, 0, 0)
                End If

            End If

            fOpenCashDrawer()

            gsNew = True
            gsID = 0

            fclear_Info()
            fLoad_Reference()
            fControlEnable(True)

            Dim S As Integer = gsTableSelect
            fRefreshTable()
            fGetDefaultTable(S)

        End If

        frmPOSCreatePayment.Dispose()
        frmPOSCreatePayment = Nothing

    End Sub
    Private Sub RbDELIVERY_CheckedChanged(sender As Object, e As EventArgs) Handles rbDELIVERY.CheckedChanged
        If rbDELIVERY.Checked = True Then

            If Ship_Via_count = 1 Then
                gsThemeNo = 0
            Else
                gsThemeNo = 2
            End If

            fMaterialSkin(Me)
            gsTableSelect = 1
            fRefreshTable()
            xxlblSalesman.Text = "DELIVERY MAN"
        End If
    End Sub

    Private Sub btnPRINTBILL_Click(sender As Object, e As EventArgs) Handles btnPRINTBILL.Click

        fPrintBill()
    End Sub

    Private Sub fPrintBill()
        If dgvInvoice.Rows.Count <> 0 Then
            dgvInvoice.Select()


            Dim id As Integer = dgvInvoice.CurrentRow.Cells(0).Value
            Dim prFile_name As String = "cryPOSRestoBill.rpt"
            Dim prPrint_Title As String = IIf(gsPOS_SERVED_ONLY = False, "BILLING SLIP", "ORDER SLIP")
            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(id), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyTin"), "tin_number")
            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)
            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                frmReportViewer.Text = "POS Preview " & fDateTimeNow()
                frmReportViewer.WindowState = FormWindowState.Normal
                frmReportViewer.ShowDialog()
                frmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If

        Else

        End If
    End Sub


    Private Sub fNotifyNumber()
        gsNO_DINEIN = Noti_Number(gsDINE_IN_ID)
        gsNO_TAKEOUT = Noti_Number(gsTAKE_OUT_ID)
        gsNO_DELIVERY = Noti_Number(gsDELIVERY_ID)

        rbDINE_IN.Text = $"{gsDINE_NAME}  ({gsNO_DINEIN})"
        rbTAKE_OUT.Text = $"{gsTAKE_OUT_NAME} ({gsNO_TAKEOUT})"
        rbDELIVERY.Text = $"{gsDELIVERY_NAME} ({gsNO_DELIVERY})"

    End Sub
    Private Function Noti_Number(ByVal prORDER_Type As Integer) As Integer
        Dim N As Integer = 0
        If prORDER_Type = 0 Then
            N = 0
        Else

            Dim SQL_R As String = ""

            SQL_R = $" UNION ALL (SELECT s.RECORDED_ON as `STATUS_DATE`,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > '{0}' and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{prORDER_Type}' order by s.ID)"

            Dim rd As DataTableReader = fReader($"select  count(*) as C from ((SELECT s.STATUS_DATE,s.SHIP_TO FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{prORDER_Type}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.STATUS_DATE,s.SHIP_TO FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{prORDER_Type}' and  s.ship_to > '0' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id) {SQL_R}) as D order by D.SHIP_TO  limit {gsPOS_RESTAURANT_TABLE_NO}")
            If rd.Read Then
                N = fNumisNULL(rd("C"))
            End If
            rd.Close()
        End If
        Return N
    End Function

    Private Sub frmPOSRestaurant_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged

    End Sub

    Private Sub PnlTOP2_Paint(sender As Object, e As PaintEventArgs) Handles pnlTOP2.Paint

    End Sub

    Private Sub BtnMENU_Click(sender As Object, e As EventArgs) Handles btnMENU.Click

        If gsNO_DINEIN <> 0 Or gsNO_TAKEOUT <> 0 Or gsNO_DELIVERY <> 0 Then
            frmPOSLogResto.gsRestoNotEmpty = True
        End If

        frmPOSLogResto.ShowDialog()
        frmPOSLogResto.Dispose()
        frmPOSLogResto = Nothing

        If gsCloseCall = True Then
            Me.Close()
        Else

            fControlEnable(True)
            If rbDINE_IN.Checked = True Then
                If Ship_Via_count = 1 Then
                    gsThemeNo = 0
                Else
                    gsThemeNo = 1
                End If


                fMaterialSkin(Me)
            ElseIf rbTAKE_OUT.Checked = True Then
                If Ship_Via_count = 1 Then
                    gsThemeNo = 0
                Else
                    gsThemeNo = 4
                End If


                fMaterialSkin(Me)
            ElseIf rbDELIVERY.Checked = True Then
                If Ship_Via_count = 1 Then
                    gsThemeNo = 0
                Else
                    gsThemeNo = 2
                End If
                fMaterialSkin(Me)
            Else

                If gsDINE_IN_ID <> 0 Then
                    rbDINE_IN.Checked = True
                ElseIf gsTAKE_OUT_ID <> 0 Then
                    rbTAKE_OUT.Checked = True
                ElseIf gsDELIVERY_ID <> 0 Then
                    rbDELIVERY.Checked = True
                End If

            End If


        End If


    End Sub

    Private Sub BtnPRINTBILL_Fake_Click(sender As Object, e As EventArgs) Handles btnPRINTBILL_Fake.Click
        btnPRINTBILL_Click(sender, e)
    End Sub

    Private Sub BtnCreatePayment_Fake_Click(sender As Object, e As EventArgs) Handles btnCreatePayment_Fake.Click
        BtnCreatePayment_Click(sender, e)
    End Sub

    Private Sub btnPRINTOS_Click(sender As Object, e As EventArgs) Handles btnPRINTOS.Click
        If dgvSalesOrder.Rows.Count <> 0 Then
            dgvSalesOrder.Select()
            Dim id As Integer = dgvSalesOrder.CurrentRow.Cells(0).Value
            '  Dim cn As New OleDb.OleDbConnection(fMS_Con)
            Dim prFile_name As String = "cryPOSOrderSlip.rpt"
            Dim prPrint_Title As String = "Order Slip"

            gscryRpt = fViewReportOneParameterNumberOnly(prFile_name)
            fCryParameterInsertValue(gscryRpt, Val(id), "myid")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyAddress"), "company_address")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("CompanyPhoneNo"), "company_phone")

            fCryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
            fReportExporPDF(gscryRpt, prPrint_Title)

            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                frmReportViewer.Text = "POS Preview " & fDateTimeNow()
                frmReportViewer.WindowState = FormWindowState.Normal
                frmReportViewer.ShowDialog()
                frmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If

        Else

        End If
    End Sub

    Private Sub tsUP_Click(sender As Object, e As EventArgs) Handles tsUP.Click
        If dgvProductItem.Rows.Count = 0 Then
            Exit Sub
        End If

        dgvProductItem.Select()

        dgvProductItem.CurrentCell = dgvProductItem.Rows(fCheckingGotVisibleIndex(True)).Cells("DESCRIPTION")
    End Sub

    Private Sub tsDOWN_Click(sender As Object, e As EventArgs) Handles tsDOWN.Click
        If dgvProductItem.Rows.Count = 0 Then
            Exit Sub
        End If
        dgvProductItem.Select()
        dgvProductItem.CurrentCell = dgvProductItem.Rows(fCheckingGotVisibleIndex(False)).Cells("DESCRIPTION")
    End Sub
    Public Function fCheckingGotVisibleIndex(ByVal isUp As Boolean) As Integer
        Dim This_number As Integer = dgvProductItem.CurrentRow.Index
        Dim Current As Integer = dgvProductItem.CurrentRow.Index
        If isUp = True Then

            For N As Integer = Current To 0 Step -1
                If dgvProductItem.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If
                End If

            Next


        Else
            For N As Integer = Current To dgvProductItem.Rows.Count - 1
                If dgvProductItem.Rows(N).Visible = True Then
                    If N <> Current Then
                        This_number = N
                        Exit For
                    End If

                End If

            Next
        End If

        Return This_number
    End Function


    Private Sub dgvInvoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellDoubleClick
        If btnRECEIVED_ORDER.Enabled = False Then
            Exit Sub
        End If
        dgvInvoice.Select()
        If dgvInvoice.Rows.Count <> 0 Then



            If dgvInvoice.CurrentRow.Index >= 0 Then
                With frmPOSRestoPendingToPaid
                    .gsID = dgvInvoice.CurrentRow.Cells(0).Value
                    .ShowDialog()
                    If .gsClickOK = True Then
                        gsNew = True
                        gsID = 0
                        fclear_Info()
                        fLoad_Reference()
                        fControlEnable(True)
                        Dim S As Integer = gsTableSelect
                        fRefreshTable()
                        fGetDefaultTable(S)

                    End If
                    .Dispose()
                End With
                frmPOSRestoPendingToPaid = Nothing
            End If
        End If

    End Sub

    Private Sub DgvInvoice_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick

    End Sub

    Private Sub btnOpenCashDrawer_Click(sender As Object, e As EventArgs) Handles btnOpenCashDrawer.Click
        fOpenCashDrawer()
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub FLP_TABLE_Paint(sender As Object, e As PaintEventArgs) Handles FLP_TABLE.Paint

    End Sub
End Class