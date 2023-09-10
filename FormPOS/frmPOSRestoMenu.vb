Imports System.Data.Odbc
Public Class FrmPOSRestoMenu
    Public gsJustClick As Boolean = False
    Public gsMemberDiscount As Double = 0
    Public ID As Integer = 0
    Dim bNewContact As Boolean = False
    Public IsOrder As Boolean = True
    Public numTableSelected As Integer = 1
    Public IsNew As Boolean = False
    Dim bRefreshItem As Boolean = False
    Dim bEntryAddItem As Boolean = False
    Dim f As Form = New FrmFindDocument
    Public gsCloseCall As Boolean = False
    Dim tdgv As DataGridView
    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Dim SelectTable As Boolean = False

    Public gsNO_DINEIN As Integer = 0
    Public gsNO_TAKEOUT As Integer = 0
    Public gsNO_DELIVERY As Integer = 0
    Dim Ship_Via_count As Integer = 0
    Dim Msg_Print_Payment As Boolean = True
    Dim SmallBox As Boolean = True
    Dim PRINT_INVOICE_AFTER_PRINT_PAYMENT As Boolean = False
    Dim CUSTOM_DINE_IN_NO As Integer = 0
    Dim PRINT_OS_AFTER_SAVE_INVOICE As Boolean

    Private Sub frmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            frmSplash.Show()
            frmSplash.Timer1.Enabled = True
            gsMenuSubID = 0
            gsMenuID = 0
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
        Dim squery As String = SqlUpdate(Me)
        If squery <> tQuery Then
            HasChange = True
        ElseIf DataGridGotChange(dgvProductItem, tdgv) = True Then
            HasChange = True
        End If
        Return HasChange
    End Function
    Private Sub POS_Rest_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        gsPOS_DEFAULT_PRINTER = fGet_System_VALUE("POS_DEFAULT_PRINTER")
        SmallBox = CBool(Val(fGet_System_VALUE("USE_SMALL_BOX")))
        CUSTOM_DINE_IN_NO = Val(fGet_System_VALUE("CUSTOM_DINE_IN_NO"))
        Msg_Print_Payment = CBool(Val(fGet_System_VALUE("MSG_PRINT_PAYMENT")))
        PRINT_INVOICE_AFTER_PRINT_PAYMENT = CBool(Val(fGet_System_VALUE("PRINT_INVOICE_AFTER_PRINT_PAYMENT")))
        PRINT_OS_AFTER_SAVE_INVOICE = CBool(Val(fGet_System_VALUE("PRINT_OS_AFTER_SAVE_INVOICE")))

        gsPOS_MACHINE_ID = fPOS_MACHINE_ID()
        gsPOS_SERVED_ONLY = fGET_SERVED_ONLY()
        gsPOS_TYPE_ID = fPOS_machine_type_map()

        tslblCONNECT.Text = db_Connection_Name
        Me.Icon = gsIcon
        Me.Text = "POS"
        pcLOGO.BackgroundImage = gsImageNameApp
        pcLOGO.BackgroundImageLayout = ImageLayout.Stretch
        '  fBackGroundImageStyle(Me)
        pnlTOP.BackColor = Color.Transparent
        FlowLayoutPanel1.BorderStyle = BorderStyle.None

        fLabel_Digital_LM(lblAMOUNT)
        fLabel_Digital_LM(xlblTOTAL)
        fLabel_Digital_M(lblOUTPUT_TAX_AMOUNT)



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
        End If









        gsUserDefaulLockNegativePerUser = fUserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = fUserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsStorage_Location_ID = GetLoadStorageLocation()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        ' LoadDefaultAccount()
        Me.AccessibleName = GetStringFieldValue("tblsub_menu", "form", "frmSalesOrder", "sub_id")
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        gsPOSDefaultCustomer_ID = GetSystemSettingValueByText("POSDefaultCustomerId")
        gsPOS_RESTAURANT_TABLE_NO = GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "RESTAURANT_TABLE_NO")
        gsDRAWER_ACCOUNT_ID = GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")
        gsDINE_IN_ID = GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "DINE_IN_ID")
        gsTAKE_OUT_ID = GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "TAKE_OUT_ID")
        gsDELIVERY_ID = GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "DELIVERY_ID")










        Ship_Via_count = 0

        If gsDINE_IN_ID = 0 Then
            rbDINE_IN.Visible = False
        Else
            Ship_Via_count = Ship_Via_count + 1
            gsDINE_NAME = GetStringFieldValue("ship_via", "id", gsDINE_IN_ID, "DESCRIPTION")
        End If

        If gsTAKE_OUT_ID = 0 Then
            rbTAKE_OUT.Visible = False
        Else
            Ship_Via_count = Ship_Via_count + 1
            gsTAKE_OUT_NAME = GetStringFieldValue("ship_via", "id", gsTAKE_OUT_ID, "DESCRIPTION")
        End If

        If gsDELIVERY_ID = 0 Then
            rbDELIVERY.Visible = False
        Else
            Ship_Via_count = Ship_Via_count + 1
            gsDELIVERY_NAME = GetStringFieldValue("ship_via", "id", gsDELIVERY_ID, "DESCRIPTION")
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
        If GetNumberFieldValue("USER_DEFAULT", "USER_ID", gsUser_ID, "pos_select_date") <> 0 Then
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
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and DATE(recorded_On) ='{DateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and CASHIER_ID = '{gsCashier_ID}' ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            If NumIsNull(rd("CASH_COUNT_ID")) <> 0 Then
                FrmPOSLogSwitch.ShowDialog()
                bStartNew = FrmPOSLogSwitch.gsStartNew
                FrmPOSLogSwitch.Dispose()
                FrmPOSLogSwitch = Nothing
            End If
            If bStartNew = True Then
                GoTo NewPOS_LOG
            End If

            gsSTARTING_RECEIPT_NO = NumIsNull(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = NumIsNull(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = NumIsNull(rd("CASH_COUNT_ID"))

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
            gsSTARTING_CASH_ID = ObjectTypeMapId("POS_STARTING_CASH")

            If DateFormatMySql(gsPOS_DATE) = DateFormatMySql(Date.Now.Date) Then
                LOG_DATE = GetDateTimeNowSql()
            Else
                LOG_DATE = $"{DateFormatMySql(gsPOS_DATE)} 08:00:01"
            End If
            SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{sAMount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
            fPOS_STARTING_CASH_JOURNAL(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
            fPOS_LOG()

        End If
        rd.Close()
        fCollect_POSLog_Resto()
    End Sub
    Private Sub fHeader_SalesOrder_Refresh()

        If rbDINE_IN.Checked = True Then
            LoadDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDINE_IN_ID}' and s.STATUS in('16','12')  ")
        ElseIf rbTAKE_OUT.Checked = True Then
            LoadDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsTAKE_OUT_ID}' and  s.STATUS in ('16','12')  ")
        ElseIf rbDELIVERY.Checked = True Then
            LoadDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDELIVERY_ID}' and  s.STATUS in ('16','12')  ")
        End If
        dgvSalesOrder.Columns(0).Visible = False
        ViewNotSort(dgvSalesOrder)
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
            LoadDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDINE_IN_ID}' and  s.STATUS ='13'  ")
        ElseIf rbTAKE_OUT.Checked = True Then
            LoadDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsTAKE_OUT_ID}' and s.STATUS ='13'  ")
        ElseIf rbDELIVERY.Checked = True Then
            LoadDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDELIVERY_ID}' and s.STATUS ='13'  ")
        End If
        dgvInvoice.Columns(0).Visible = False
        ViewNotSort(dgvInvoice)
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
            ClearAndRefresh(Me)

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
                For T As Integer = 1 To IIf(CUSTOM_DINE_IN_NO = 0, gsPOS_RESTAURANT_TABLE_NO, CUSTOM_DINE_IN_NO)

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
                Dim rd_dine As OdbcDataReader = SqlReader(SQL)
                While rd_dine.Read
                    Dim DTT As String
                    Dim This_Label As String = ""
                    Dim This_Status As String = ""
                    Dim This_Color As Color
                    If IsDate(rd_dine("this_record")) = True Then

                        DTT = DateTimeFormatMySql(rd_dine("this_record")).ToString
                        If NumIsNull(rd_dine("this_status")) = 0 Then
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

                fGetDefaultTable(numTableSelected)
            ElseIf rbTAKE_OUT.Checked = True Then
                Dim N As Integer = 0
                Dim rd As OdbcDataReader = SqlReader($"select  D.RECORDED_ON,D.SHIP_TO, D.`STATUS` from ((SELECT s.RECORDED_ON,s.SHIP_TO, 0 as `STATUS` FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsTAKE_OUT_ID}' and  s.ship_to > '0' and s.`STATUS` in ('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO, if(s.STATUS=16,1,0) as `STATUS` FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsTAKE_OUT_ID}' and  s.ship_to > '0' and s.`STATUS` in ('13','16')  and NOT EXISTS (select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO`,1 as `STATUS` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsTAKE_OUT_ID}' order by s.id ) ) as D order by D.RECORDED_ON  limit {gsPOS_RESTAURANT_TABLE_NO} ")
                While rd.Read
                    N = N + 1
                    Dim DTT As DateTime = DateTimeFormatMySql(rd("RECORDED_ON"))

                    Dim This_label As String
                    If NumIsNull(rd("STATUS")) = 0 Then
                        This_label = "On-going"
                        fCreate_Box(N, Color.YellowGreen, This_label, NumIsNull(rd("ship_to")), DTT.ToString)
                    Else
                        This_label = "Waiting"
                        fCreate_Box(N, Color.LightBlue, This_label, NumIsNull(rd("ship_to")), DTT.ToString)
                    End If


                End While
                rd.Close()
                fGetDefaultTable(numTableSelected)
            ElseIf rbDELIVERY.Checked = True Then
                Dim rd As OdbcDataReader = SqlReader($"select D.RECORDED_ON,D.SHIP_TO, D.`STATUS`  from ((SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDELIVERY_ID}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDELIVERY_ID}' and  s.ship_to > '0' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id) UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDELIVERY_ID}' order by s.ID ) UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO`,1 as `STATUS` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDELIVERY_ID}' order by s.ID )) as D order by D.RECORDED_ON  limit {gsPOS_RESTAURANT_TABLE_NO} ")
                Dim N As Integer = 0
                While rd.Read
                    N = N + 1
                    Dim DTT As DateTime = DateTimeFormatMySql(rd("RECORDED_ON"))

                    Dim This_label As String
                    If NumIsNull(rd("STATUS")) = 0 Then
                        This_label = "On-going"
                    Else
                        This_label = "Waiting"
                    End If


                    fCreate_Box(N, Color.DarkOrange, This_label, NumIsNull(rd("ship_to")), DTT.ToString)
                End While
                rd.Close()
                fGetDefaultTable(numTableSelected)
            End If

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
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
                If IsNothing(PNL) = False Then
                    Dim BN As Button = PNL.Controls($"btnOrder{S}")
                    gsJustClick = False
                    BN.PerformClick()
                End If

            End If
        Catch ex As Exception

            '            MessageBoxInfo("Please try again can`t open " & ex.Message)
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

        If SmallBox = False Then
            NewPanel.Size = New Size(119, 130)
        Else
            NewPanel.Font = New Font("Verdana", 7, FontStyle.Regular)
            NewPanel.Size = New Size(89, 100)

        End If
        NewPanel.BorderStyle = BorderStyle.FixedSingle

        'Table Number
        Dim NewLabelNum As New Label
        NewLabelNum.Name = $"lblnum{N}"
        NewLabelNum.AutoSize = True
        NewLabelNum.Text = N
        If SmallBox = False Then
            NewLabelNum.Font = New Font("Verdana", 14.25, FontStyle.Bold)
        Else
            NewLabelNum.Font = New Font("Verdana", 14.25, FontStyle.Bold)
        End If
        NewLabelNum.Location = New Point(0, 0)
        NewPanel.Controls.Add(NewLabelNum)


        'Order Type
        Dim NewLabelOrderType As New Label
        NewLabelOrderType.Name = $"lblSTATUS{N}"
        NewLabelOrderType.AutoSize = False

        If SmallBox = False Then
            NewLabelOrderType.Size = New Size(80, 39)
        Else
            NewLabelOrderType.Size = New Size(80, 30)
        End If
        NewLabelOrderType.Text = IIf(LABEL_STATUS = "", "", "#" & LABEL_STATUS)
        NewLabelOrderType.TextAlign = ContentAlignment.MiddleCenter

        If SmallBox = False Then

            NewLabelOrderType.Font = New Font("Verdana", 9.75, FontStyle.Regular)
        Else
            NewLabelOrderType.Font = New Font("Verdana", 9.75, FontStyle.Regular)
        End If
        NewLabelOrderType.Location = New Point(30, 0)
        NewPanel.Controls.Add(NewLabelOrderType)


        'Button Function
        Dim NewButton As New Button
        NewButton.Name = $"btnOrder{N}"
        NewButton.TextAlign = ContentAlignment.MiddleCenter
        NewButton.AutoSize = False

        If SmallBox = False Then

            NewButton.Size = New Size(117, 50)
            NewButton.Location = New Point(0, 40)
        Else
            NewButton.Size = New Size(85, 35)
            NewButton.Location = New Point(0, 35)
        End If
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

        AddHandler NewButton.Click, AddressOf fBUTTON_CLICK
        NewPanel.Controls.Add(NewButton)
        'Time Label
        Dim NewLabelTime As New Label
        NewLabelTime.Name = $"lblTime{N}"
        NewLabelTime.AutoSize = False

        If SmallBox = False Then

            NewLabelTime.Size = New Size(118, 35)
            NewLabelTime.Location = New Point(0, 93)
            NewLabelTime.Font = New Font("Verdana", 12, FontStyle.Bold)
        Else
            NewLabelTime.Size = New Size(88, 35)
            NewLabelTime.Location = New Point(0, 68)
            NewLabelTime.Font = New Font("Verdana", 10, FontStyle.Bold)
        End If
        NewLabelTime.Text = "00:00"
        NewLabelTime.TextAlign = ContentAlignment.MiddleCenter


        NewPanel.Controls.Add(NewLabelTime)

        'RECORDED LABEL
        Dim NewDATETIME_RECORD As New Label
        NewDATETIME_RECORD.Name = $"lblRECORD{N}"
        NewDATETIME_RECORD.AutoSize = False

        If SmallBox = False Then
            NewDATETIME_RECORD.Size = New Size(118, 35)

        Else
            NewDATETIME_RECORD.Size = New Size(118, 35)
        End If
        NewDATETIME_RECORD.Text = LABEL_RECORD
        NewDATETIME_RECORD.TextAlign = ContentAlignment.MiddleCenter
        NewDATETIME_RECORD.Font = New Font("Verdana", 12, FontStyle.Bold)
        If SmallBox = False Then


        Else

        End If
        NewDATETIME_RECORD.Location = New Point(0, 0)
        NewDATETIME_RECORD.Visible = False
        NewPanel.Controls.Add(NewDATETIME_RECORD)


        FLP_TABLE.Controls.Add(NewPanel)
    End Sub

    Private Sub fBUTTON_CLICK(sender As Object, e As EventArgs)

        SelectTable = True
        Dim Btn As Button = DirectCast(sender, Button)

        If rbDINE_IN.Checked = True Then

            numTableSelected = Btn.Tag
            Dim P As Panel = FLP_TABLE.Controls($"pnl{numTableSelected}")
            P.BackColor = Color.MediumPurple
            P.ForeColor = Color.White
            Btn.ForeColor = Color.Black

            If Btn.Text = "Served" Then
                pnlTOP2.Enabled = False


            Else
                pnlTOP2.Enabled = True
            End If



            xlblTABLE_TYPE.Text = $"{gsDINE_NAME} #"
            xlblTABLE_NO.Text = numTableSelected.ToString("00#")

        ElseIf rbTAKE_OUT.Checked = True Then

            numTableSelected = Btn.AccessibleDescription

            Dim P As Panel = FLP_TABLE.Controls($"pnl{Btn.Tag}")

            P.BackColor = Color.MediumPurple
            P.ForeColor = Color.White
            Btn.ForeColor = Color.Black

            xlblTABLE_TYPE.Text = $"{gsTAKE_OUT_NAME} #"
            xlblTABLE_NO.Text = numTableSelected.ToString("00#")

        ElseIf rbDELIVERY.Checked = True Then

            numTableSelected = Btn.AccessibleDescription
            Dim P As Panel = FLP_TABLE.Controls($"pnl{numTableSelected}")
            P.BackColor = Color.MediumPurple
            P.ForeColor = Color.White
            Btn.ForeColor = Color.Black

            xlblTABLE_TYPE.Text = $"{gsDELIVERY_NAME} #"
            xlblTABLE_NO.Text = numTableSelected.ToString("00#")

        End If

        fHeader_SalesOrder_Refresh()
        fHeader_Invoice_Refresh()
        dgvProductItem.Rows.Clear()
        fclear_Info()
        fComputed()

        fControlEnable(True)

        If gsJustClick = True Then
            If Btn.Text = "Served" Or Btn.Text = "Waiting" Then

                If numTableSelected = 0 Then
                    Exit Sub
                End If


                If rbDELIVERY.Checked = True Then

                    frmPOSTableDetails.gsTABLE_NO = numTableSelected
                    frmPOSTableDetails.gsORDER_TYPE = gsDELIVERY_ID
                    frmPOSTableDetails.ShowDialog()
                    If frmPOSTableDetails.gsClickOk = True Then
                        fRefreshTable()
                    End If
                    frmPOSTableDetails.Dispose()
                    frmPOSTableDetails = Nothing
                ElseIf rbDINE_IN.Checked = True Then

                    frmPOSTableDetails.gsTABLE_NO = numTableSelected
                    frmPOSTableDetails.gsORDER_TYPE = gsDINE_IN_ID
                    frmPOSTableDetails.ShowDialog()
                    If frmPOSTableDetails.gsClickOk = True Then
                        fRefreshTable()
                    End If
                    frmPOSTableDetails.Dispose()
                    frmPOSTableDetails = Nothing
                ElseIf rbTAKE_OUT.Checked = True Then

                    Dim rd_16 As OdbcDataReader = SqlReader($"select * from invoice WHERE DATE = '{ DateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and SHIP_DATE ='" & DateFormatMySql(gsPOS_DATE) & "' and SHIP_VIA_ID='" & gsTAKE_OUT_ID & "' and SHIP_TO='" & numTableSelected & "' and STATUS = '16' limit 1;")
                    If rd_16.Read Then

                        Dim GET_ID As Integer = NumIsNull(rd_16("id"))

                        If MessageBoxPointOfSalesYesNO("Pick up?") = True Then

                            SqlExecuted($"UPDATE invoice SET `STATUS` = '14' WHERE `DATE` = '{DateFormatMySql(gsPOS_DATE)}' and `LOCATION_ID` = '{gsDefault_LOCATION_ID}' and `SHIP_DATE` ='" & DateFormatMySql(gsPOS_DATE) & "' and SHIP_VIA_ID='" & gsTAKE_OUT_ID & "' and SHIP_TO='" & numTableSelected & "' and STATUS = '16' limit 1;")
                            fRefreshTable()

                        Else
                            fDoEvents()
                            If MessageBoxPointOfSalesYesNO("Print Order slip?") = True Then
                                fPP_billPrint(GET_ID)
                            End If
                        End If

                    Else

                        frmPOSTableDetails.gsTABLE_NO = numTableSelected
                        frmPOSTableDetails.gsORDER_TYPE = gsTAKE_OUT_ID
                        frmPOSTableDetails.ShowDialog()
                        If frmPOSTableDetails.gsClickOk = True Then
                            fRefreshTable()
                        End If
                        frmPOSTableDetails.Dispose()
                        frmPOSTableDetails = Nothing
                    End If
                    rd_16.Close()

                End If


            End If

        End If
        gsJustClick = True
    End Sub
    'Private Function fGetPanelByAccessbleName(ByVal N As Integer) As Integer
    '    Exit Function
    '    Dim R As Integer = 1
    '    For I As Integer = 1 To FLP_TABLE.Controls.Count
    '        Dim NewPanel As Panel = FLP_TABLE.Controls($"pnl{I}")
    '        If Val(NewPanel.AccessibleName) = N Then
    '            R = I
    '            Exit For
    '        End If
    '    Next

    '    Return R

    'End Function
    Private Sub fControlEnable(ByVal B As Boolean)
        btnMENU.Enabled = B
        pnlOther.Enabled = B
        tsITEM_MENU.Enabled = B
        FLP_TABLE.Enabled = B
        pnlTOP.Enabled = B
        pnlTOP2.Enabled = B
        pnlOther.Enabled = IIf(B = True, False, True)
        If pnlOther.Enabled = True Then
            If IsNew = True Then
                btnDELETE.Enabled = False
            Else
                btnDELETE.Enabled = True
            End If
        End If

        tsITEM_MENU.Enabled = IIf(B = True, False, True)


    End Sub

    Private Sub fDINE_IN_CONTROL(ByVal T As Integer, ByRef BUTTON_LABEL As String, ByRef STATUS_LABEL As String, ByRef DT_RECORD As String)

        Dim rd As OdbcDataReader = SqlReader($"select D.RECORDED_ON from ((SELECT s.RECORDED_ON,s.SHIP_TO FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id)) as D order by D.RECORDED_ON  limit 1;")
        If rd.Read Then
            Dim DTT As DateTime = DateTimeFormatMySql(rd("RECORDED_ON"))
            DT_RECORD = DTT.ToString
            BUTTON_LABEL = "Accommodated"
            STATUS_LABEL = ""
        Else

            '    rd = SqlReader($"SELECT s.STATUS_DATE FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in('13') order by s.id limit 1;")
            'If rd.Read Then
            '        Dim DTT As DateTime = DateTimeFormatMySql(rd("STATUS_DATE"))
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

        If IsOrder = True Then
            fcolumnGrid_Sales_order()
            ViewItemDisplay(dgvProductItem)
            fHide_Standard_Column()
            ViewNotSort(dgvProductItem)
            fclear_Info()
            If IsNew = False Then
                fRefreshInfo_sales_order(ID)
                fRefreshItem_sales_order(ID)
            End If

        Else

            fcolumnGrid_Invoice()
            ViewItemDisplay(dgvProductItem)
            fHide_Standard_Column()
            ViewNotSort(dgvProductItem)
            fclear_Info()
            'Received
            If IsNew = False Then
                fRefreshInfo_Invoice(ID)
                fRefreshItem_Invoice(ID)
            End If
        End If


    End Sub
    Private Sub fclear_Info()

        fRefreshCombo()
        ClearAndRefresh(Me)

        cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
        cmbCUSTOMER_ID.SelectedValue = gsPOSDefaultCustomer_ID
        cmbSALES_REP_ID.SelectedIndex = -1
        xlblCustomer_Name.Visible = True
        xlblAcctNo.Visible = True
        xlblSalesRep.Visible = True

        dtpDATE.Checked = True
        dgvProductItem.Rows.Clear()
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbLOCATION_ID.Enabled = IsLockLocation()
        cmbPAYMENT_TERMS_ID.SelectedValue = GetPaymentTermsDefault()
        dtpDATE.Value = gsPOS_DATE
        cmbACCOUNTS_RECEIVABLE_ID.SelectedValue = gsDefault_ACCOUNTS_RECEIVABLE_ID


        fCODELABEL()
        fComputed()

    End Sub

    Private Sub fCODELABEL()



        If IsOrder = True And gsPOS_SERVED_ONLY = False Then

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
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo_Invoice(id)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub fRefreshInfo_sales_order(ByVal prID As Integer)

        Try

            Dim sQuery As String = "select * from sales_order where ID = '" & prID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)


            'cn.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshInfo_sales_order(prID)
            Else
                End
            End If


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
   WHERE ii.`SALES_ORDER_ID` = '" & ID & "' Order by ii.LINE_NO"


        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read
                dgvProductItem.Rows.Add()
                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(NumIsNull(rd(i)))
                        ElseIf CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(NumIsNull(rd(i)))
                        ElseIf CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(NumIsNull(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = NumIsNull(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = TextIsNull(rd(i))
                            End If
                        End If
                    End With

                Next
                If CBool(NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If
                x = x + 1
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        Finally

            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

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

        ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

        ComboBoxLoad(cmbCLASS_ID, "select * from class order by `NAME`", "ID", "NAME")
        ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2' order by `NAME`", "ID", "NAME")
        ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")

    End Sub
    Private Sub fcolumnGrid_Invoice()
        fcolumnGrid_U_Invoice(dgvProductItem)
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
        fcolumnGrid_U_SalesOrder(dgvProductItem)

    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub


    Private Function fCheckifDiscountNext(ByVal ndex As Integer) As Boolean
        Try
            If IsDiscountItem(dgvProductItem.Rows(ndex + 1).Cells("ITEM_TYPE").Value) = True Then
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
            Dim gsSalesSubTotal As Double = 0
            fSales_Customer_Computation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
            Dim dPayment_applied As Double = fGetSumPaymentApplied(ID, cmbCUSTOMER_ID.SelectedValue) + fGetSumCreditApplied(ID, cmbCUSTOMER_ID.SelectedValue) + fInvoiceSumTaxApplied_Amount(ID, cmbCUSTOMER_ID.SelectedValue)
            lbxPaymentApplied.Text = NumberFormatStandard(dPayment_applied)
            Dim dBalance As Double = NumIsNull(NumberFormatFixed(NumIsNull(lblAMOUNT.Text))) - dPayment_applied
            lblBALANCE_DUE.Text = NumberFormatStandard(dBalance)
            lbxBalance.Text = IIf(dtpDUE_DATE.Value > Date.Now.Date, "0.00", NumberFormatStandard(dBalance))
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        fComputed()
        Select Case NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue)
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
            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = TextIsNull(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = TextIsNull(rd("TAX_ACCOUNT_ID"))
            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""
                lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                cmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If

            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub fEditItem()
        If IsOrder = True Then
            fEdit_SO()
        Else
            fEdit_Invoice()
        End If

    End Sub

    Private Sub fEdit_Invoice()
        Try

            If dgvProductItem.Rows.Count = 0 Then
                MessageBoxExclamation("Data Not Found!")
                Exit Sub
            End If
            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index
            If fCheckModify(dgvProductItem, I) = True Then
                Exit Sub
            End If
            Dim d As DataGridViewRow = dgvProductItem.Rows(I)


            If d.Cells("ITEM_TYPE").Value = 5 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem

                If NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                .sFormName = "frmInvoice"
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = TextIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value)
                .gsDiscount_Rate = NumIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value)
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
                    fRow_Data_Item_Invoice(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, dgvProductItem.Rows.Item(I).Cells("REF_LINE_ID").Value, .gsPRICE_LEVEL_ID, 0, False, .gsBATCH_ID)

                End If
            End With
            fComputed()
            frmAddItem.Dispose()
            frmAddItem = Nothing

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Sub fEdit_SO()
        Try
            If tsITEM_MENU.Enabled = False Then Exit Sub

            If dgvProductItem.Rows.Count = 0 Then
                MessageBoxExclamation("Data Not Found!")
                Exit Sub
            End If
            Dim bAlreadySave As Boolean = False
            Dim I As Integer = dgvProductItem.CurrentRow.Index

            Dim d As DataGridViewRow = dgvProductItem.Rows(I)
            If d.Cells("ITEM_TYPE").Value = 5 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf IsDiscountItem(d.Cells("ITEM_TYPE").Value) = True Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            ElseIf NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With frmAddItem
                .gsNonInventoryItem = True
                If NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
            MessageBoxInfo(ex.Message)
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
            MessageBoxInfo("Please Name")
            Exit Sub
        End If
        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If
        If cmbPAYMENT_TERMS_ID.Text = "" Then
            MessageBoxInfo("Please select payment terms")
            Exit Sub
        End If
        If SecurityAccessMode(frmInvoice, IsNew) = False Then
            'Acccess Denied
            Exit Sub
        End If
        'Remarks
        If btnSAVE.Enabled = False Then

            Exit Sub
        End If
        btnSAVE.Enabled = False
        If gsPOSPopupNotes = True Then
            FrmPOSRestoNoteDT.ShowDialog()
            txtNOTES.Text = FrmPOSRestoNoteDT.gsRemarks

            If NumIsNull(lblAMOUNT.Text) < 1 Then
                txtNOTES.Text = txtNOTES.Text & " FREE MEAL/COUPON PAID"
            End If

            FrmPOSRestoNoteDT.Dispose()
            FrmPOSRestoNoteDT = Nothing
        Else

            If NumIsNull(lblAMOUNT.Text) < 1 Then
                txtNOTES.Text = "FREE MEAL/COUPON PAID"
            Else
                txtNOTES.Text = ""
            End If

        End If


        If IsNew = True Then


            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = GetNextCode("INVOICE", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            If NumIsNull(lblAMOUNT.Text) < 1 Then
                lblAMOUNT.Text = "0"
            End If

            Dim SQL_Field1 As String = ""
            Dim SQL_Value1 As String = ""

            Dim SQL_Field2 As String = ""
            Dim SQL_Value2 As String = ""

            SqlCreate(Me, SQL_Field1, SQL_Value1)
            SqlCreate(pnlOther, SQL_Field2, SQL_Value2)

            ID = ObjectTypeMapId("invoice")

            Dim ORDER_TYPE_ID As Integer = 0
            If rbDINE_IN.Checked = True Then
                ORDER_TYPE_ID = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                ORDER_TYPE_ID = gsTAKE_OUT_ID
                If numTableSelected = 0 Then
                    numTableSelected = fNextInvoiceTodayCountNumber() + 1
                End If
            ElseIf rbDELIVERY.Checked = True Then
                ORDER_TYPE_ID = gsDELIVERY_ID
                If numTableSelected = 0 Then
                    numTableSelected = fNextInvoiceTodayCountNumber() + 1
                End If
            End If
            Dim bTotal_Balance As Double = NumberFormatFixed(lblBALANCE_DUE.Text)
            Dim nStatus As Integer = IIf(NumIsNull(lblAMOUNT.Text) <= 0, 16, 13)

            SqlExecuted($"INSERT INTO invoice ({SQL_Field1},{SQL_Field2},ID,RECORDED_ON,SHIP_DATE,SHIP_VIA_ID,SHIP_TO,STATUS,STATUS_DATE,IS_FC) VALUES ({SQL_Value1},{SQL_Value2},'{ID}','{GetDateTimeNowSql()}','{DateFormatMySql(gsPOS_DATE)}','{ORDER_TYPE_ID}','{numTableSelected}','{nStatus}',{GetDateTimeNowSql()},0) ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)


        Else
            '    If IsClosingDate(dtpDATE.Value) = False Then
            '        Exit Sub
            '    End If

            If NumIsNull(lblAMOUNT.Text) < 1 Then
                lblAMOUNT.Text = "0"
            End If

            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me)
            Dim bTotal_Balance As Double = NumberFormatFixed(lblBALANCE_DUE.Text)
            Dim nStatus As Integer = 0
            nStatus = IIf(NumIsNull(lblAMOUNT.Text) <= 0, 16, 13)
            squery = squery & $",STATUS='" & nStatus & "',STATUS_DATE ='" & GetDateTimeNowSql() & "' WHERE ID = '" & ID & "'"
            SqlExecuted($"UPDATE invoice SET {squery},STATUS='{nStatus}',STATUS_DATE ='{ GetDateTimeNowSql()}' WHERE ID = '{ID}'")
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If



        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 0, NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                fJournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 23, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                fAccount_Journal_SQL(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 1, NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================
        SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

        If IsTransactionSuccess(ID, "INVOICE") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        Dim Got_Zero_Amount As Double = NumIsNull(lblAMOUNT.Text)

        If Got_Zero_Amount < 1 Then
            fPP_billPrint(ID)

            If MessageBoxPointOfSalesYesNO($"Print again {gsInvoice_Print_Title.ToUpper}?") = True Then
                fPP_billPrint(ID)
            End If

        End If

        btnSAVE.Enabled = True

        If ID <> 0 Then

            Dim S As Integer = 0
            If rbDINE_IN.Checked = True Then
                S = numTableSelected
                fRefreshTable()

            Else

                If IsNew = True Then

                    If rbTAKE_OUT.Checked = True Then
                        S = gsNO_TAKEOUT + 1
                    ElseIf rbDINE_IN.Checked = True Then
                        S = gsNO_DELIVERY + 1
                    End If

                Else
                    If rbTAKE_OUT.Checked = True Then
                        S = gsNO_TAKEOUT
                    ElseIf rbDINE_IN.Checked = True Then
                        S = gsNO_DELIVERY
                    End If
                End If

                numTableSelected = S
                fRefreshTable()

            End If
            IsNew = True
            ID = 0
            fclear_Info()
            fLoad_Reference()
            fControlEnable(True)

            fGetDefaultTable(S)
        End If



        If rbDINE_IN.Checked = True Then
            If gsPOS_SERVED_ONLY = False Then
                If MessageBoxPointOfSalesYesNO("Create payment?") = True Then
                    fCreatePayment()
                End If
            Else

                If PRINT_OS_AFTER_SAVE_INVOICE = True Then
                    fPrintBill()
                End If
            End If

        Else

            If Got_Zero_Amount > 0 Then
                fCreatePayment()
            End If


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
    WHERE  ii.`INVOICE_ID` = '" & ID & "' Order by ii.LINE_NO"
        If dgvProductItem.Columns.Count = 0 Then Exit Sub

        Try
            Dim x As Integer = 0
            '  cn.Open()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read

                dgvProductItem.Rows.Add()

                If NumIsNull(rd("GROUP_LINE_ID")) <> 0 Then

                    sGROUP_ITEM_ID = NumIsNull(rd("GROUP_LINE_ID"))
                    sGROUP_ITEM_COUNT = sGROUP_ITEM_COUNT + 1

                Else
                    sGROUP_ITEM_COUNT = 0
                End If

                For i As Integer = 0 To rd.FieldCount - 1

                    With dgvProductItem.Columns(i)
                        If fCheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(NumIsNull(rd(i)))
                        ElseIf CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(NumIsNull(rd(i)))
                        ElseIf CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(NumIsNull(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = NumIsNull(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = TextIsNull(rd(i))
                            End If
                        End If
                    End With

                Next

                If CBool(NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If

                x = x + 1
            End While
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshItem_Invoice(xID)
            Else
                End
            End If
        Finally
            fComputed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try
        bRefreshItem = False

    End Sub
    Private Function fNextInvoiceTodayCountNumber() As Integer
        Dim N As Integer = 0
        If rbTAKE_OUT.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select  COUNT(*) as T FROM INVOICE WHERE DATE = '{DateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and SHIP_DATE ='{DateFormatMySql(gsPOS_DATE)}' and SHIP_VIA_ID ='{gsTAKE_OUT_ID}' limit 100  ")
            If rd.Read Then
                N = NumIsNull(rd("T"))
            End If
            rd.Close()
        ElseIf rbDELIVERY.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select  COUNT(*) as T FROM INVOICE WHERE DATE = '{DateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and SHIP_DATE ='{DateFormatMySql(gsPOS_DATE)}' and SHIP_VIA_ID ='{gsDELIVERY_ID}' limit 100  ")
            If rd.Read Then
                N = NumIsNull(rd("T"))
            End If
            rd.Close()
        End If

        Return N
    End Function

    Private Function fAutoNumber(ByVal I As Integer) As Integer
        Dim N As Integer = 1
        If rbDELIVERY.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select NEXT_ID from pos_auto_number where ORDER_TYPE_ID = '{gsDELIVERY_ID}' and POS_MACHINE_ID='{gsPOS_MACHINE_ID}' limit 1;")
            If rd.Read Then
                N = NumIsNull(rd("NEXT_ID"))
                SqlExecuted($"UPDATE pos_auto_number SET NEXT_ID ='{N + 1}' WHERE ORDER_TYPE_ID='{gsDELIVERY_ID}'and POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  limit 1;")
            Else
                SqlExecuted($"INSERT INTO pos_auto_number SET  ORDER_TYPE_ID='{gsDELIVERY_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',NEXT_ID ='2' ")
            End If
            rd.Close()
            Return N
        ElseIf rbTAKE_OUT.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select NEXT_ID from pos_auto_number where ORDER_TYPE_ID = '{gsTAKE_OUT_ID}' and POS_MACHINE_ID='{gsPOS_MACHINE_ID}' limit 1;")
            If rd.Read Then
                N = NumIsNull(rd("NEXT_ID"))
                SqlExecuted($"UPDATE pos_auto_number SET NEXT_ID ='{N + 1}' WHERE ORDER_TYPE_ID='{gsTAKE_OUT_ID}'and POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  limit 1;")
            Else
                SqlExecuted($"INSERT INTO pos_auto_number  SET ORDER_TYPE_ID='{gsTAKE_OUT_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',NEXT_ID ='2' ")
            End If
            rd.Close()
            Return N
        Else
            Return I
        End If
    End Function
    Private Sub fSaveSalesOrder()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Customer")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If

        If SecurityAccessMode(frmSalesOrder, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then

            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = GetNextCode("SALES_ORDER", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            SqlCreate(Me, SQL_Field, SQL_Value)

            ID = ObjectTypeMapId("sales_order")
            numTableSelected = fAutoNumber(numTableSelected)
            Dim ORDER_TYPE_ID As Integer = 0
            If rbDINE_IN.Checked = True Then
                ORDER_TYPE_ID = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                ORDER_TYPE_ID = gsTAKE_OUT_ID
            ElseIf rbDELIVERY.Checked = True Then
                ORDER_TYPE_ID = gsDELIVERY_ID
            End If


            SqlExecuted($"INSERT INTO sales_order
                            (ID,RECORDED_ON,DATE_NEEDED,SHIP_VIA_ID,SHIP_TO,STATUS,STATUS_DATE) 
                            VALUES ({ID},'{GetDateTimeNowSql()}','{DateFormatMySql(Date.Now)}','{ORDER_TYPE_ID}','numTableSelected',16,{GetDateTimeNowSql()})  ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else



            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me)
            squery = squery & " WHERE ID = '" & ID & "' limit 1"
            SqlExecuted("UPDATE sales_order SET " & squery)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If IsTransactionSuccess(ID, "sales_order") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        Else
            fSaveItem_sales_order(ID)  ' Save item
        End If


        If ID <> 0 Then


            IsNew = True
            ID = 0

            fclear_Info()
            fLoad_Reference()
            fControlEnable(True)
            Dim S As Integer = numTableSelected
            fRefreshTable()
            fGetDefaultTable(S)
        End If


    End Sub
    Private Sub fSetNew()
        fclear_Info()
        dgvProductItem.Rows.Clear()
        fComputed()
        ID = 0
        IsNew = True

    End Sub
    Private Sub fEstimate_ITEM_UPDATE(ByVal prITEM_ID As Double, ByVal prINVOICED_QTY As Double, ByVal ADD_EDIT As Boolean)
        If prITEM_ID = 0 Then
            Exit Sub
        End If

        Dim SO_SQL As String

        Dim get_SO_ID As String = GetStringFieldValue("estimate_items", "ID", prITEM_ID, "estimate_ID")

        If ADD_EDIT = True Then
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = '" & prINVOICED_QTY & "' ,`CLOSED` = '1' where ID = '" & prITEM_ID & "' Limit 1"
        Else
            SO_SQL = "Update Estimate_items SET `FINAL_QTY` = NULL,`CLOSED` = '0' where ID = '" & prITEM_ID & "' Limit 1"
        End If
        SqlExecuted(SO_SQL)

        SqlExecuted("Update Estimate set `STATUS` = '3'  where ID = '" & get_SO_ID & "' limit 1")
    End Sub
    'Private Sub fSaveItem_Invoice()

    '    fInvoice_Save_item(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)


    'End Sub




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
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value))
                        SqlExecuted(SQL_SCRIPT)
                    Case "A"
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("SALES_ORDER_ITEMS")
                        SQL_SCRIPT = "INSERT INTO sales_order_items SET  GROUP_LINE_ID = " & GotNullNumber((.Cells("GROUP_LINE_ID").Value)) & ",PRINT_IN_FORMS ='" & NumIsNull(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & GetMaxFieldLine("LINE_NO", "SALES_ORDER_ITEMS", "SALES_ORDER_ID", dID) & "',ID='" & i_ID & "',QUANTITY ='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & ",SALES_ORDER_ID ='" & dID & "',CLOSED ='0',INVOICED_QTY= NULL,PRICE_LEVEL_ID = " & GotNullNumber(NumIsNull(.Cells("PRICE_LEVEL_ID").Value))
                        SqlExecuted(SQL_SCRIPT)

                        fEstimate_ITEM_UPDATE(NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), NumIsNull(.Cells("QTY").Value), True)

                        If IsGroupItem(NumIsNull(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = NumIsNull(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf NumIsNull(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If

                    Case "E"
                        fTax_Computation(cmbOUTPUT_TAX_ID, NumIsNull(.Cells("AMOUNT").Value), NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET QUANTITY='" & NumIsNull(.Cells("QTY").Value) & "',RATE = '" & NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & GotNullNumber(NumIsNull(.Cells("ID").Value)) & ""
                        SqlExecuted(SQL_SCRIPT)
                        fEstimate_ITEM_UPDATE(NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), NumIsNull(.Cells("QTY").Value), True)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM sales_order_items WHERE SALES_ORDER_ID ='" & dID & "' and ID = '" & NumIsNull(.Cells("ID").Value) & "'"
                        SqlExecuted(SQL_SCRIPT)
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
        'Dim H_PC As Integer = My.Computer.Screen.WorkingArea.Height

        'Me.Width = Screen.PrimaryScreen.Bounds.Width
        'Me.Height = H_PC
        'Me.Location = New Point(0, 0)
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
        xlblAcctNo.Text = GetStringFieldValue("CONTACT", "ID", NumIsNull(cmbCUSTOMER_ID.SelectedValue), "ACCOUNT_NO")
        Dim rd As OdbcDataReader = SqlReader($"select TAX_ID from contact where id ='{NumIsNull(cmbCUSTOMER_ID.SelectedValue)}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
            End If
        End If

    End Sub

    'Private Sub PreviewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PreviewToolStripMenuItem.Click
    '    If IsNew = True Then
    '        TsSaveNew_Click(sender, e)
    '    Else
    '        If IsCheckHasChange() = True Then
    '            If MessageBoxQuestion(gsMessageCheckEdit) = True Then
    '                tChangeAccept = False
    '                TsSaveNew_Click(sender, e)
    '                If tChangeAccept = False Then
    '                    MessageBoxInfo("Cancel")
    '                    Exit Sub
    '                End If
    '            Else
    '                Exit Sub
    '            End If
    '        End If
    '    End If
    '    If IsNew = False Then
    '        If SecurityAccessPrint(Me) = False Then
    '            Exit Sub
    '        End If
    '        '   Dim prFile_name As String = "crySalesOrder.rpt"
    '        ' Dim prPrint_Title As String = "Sales Order"
    '        Dim prFile_name As String = ""
    '        Dim prPrint_Title As String = ""
    '        Dim cn As New OleDb.OleDbConnection(fMS_Con)
    '        Try
    '            cn.Open()
    '            Dim R_number As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
    '            If R_number.Read Then
    '                prPrint_Title = R_number("print_title")
    '                prFile_name = R_number("file_name")
    '            End If
    '            cn.Close()
    '        Catch ex As Exception
    '            If cn.State = ConnectionState.Open Then
    '                cn.Close()
    '            End If
    '        End Try



    '        gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
    '        CryParameterInsertValue(gscryRpt, Val(ID), "myid")
    '        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
    '        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
    '        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
    '        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
    '        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
    '        ReportExporPDF(gscryRpt, prPrint_Title)
    '        gsToolPanelView = False
    '        GlobalPreviewReport(prPrint_Title)
    '    End If
    'End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        'If IsNew = True Then
        '    TsSaveNew_Click(sender, e)
        'Else
        '    If IsCheckHasChange() = True Then
        '        If MessageBoxQuestion(gsMessageCheckEdit) = True Then
        '            tChangeAccept = False
        '            TsSaveNew_Click(sender, e)
        '            If tChangeAccept = False Then
        '                MessageBoxInfo("Cancel")
        '                Exit Sub
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End If
        'End If
        'If IsNew = False Then
        '    If SecurityAccessPrint(Me) = False Then
        '        Exit Sub
        '    End If
        '    '   Dim prFile_name As String = "crySalesOrder.rpt"
        '    '  Dim prPrint_Title As String = "Sales Order"
        '    Dim prFile_name As String = ""
        '    Dim prPrint_Title As String = ""
        '    Dim cn As New OleDb.OleDbConnection(fMS_Con)
        '    Try
        '        cn.Open()
        '        Dim R_number As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
        '        If R_number.Read Then
        '            prPrint_Title = R_number("print_title")
        '            prFile_name = R_number("file_name")
        '        End If
        '        cn.Close()
        '    Catch ex As Exception
        '        If cn.State = ConnectionState.Open Then
        '            cn.Close()
        '        End If
        '    End Try


        '    gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
        '    CryParameterInsertValue(gscryRpt, Val(ID), "myid")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        '    CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        '    ReportExporPDF(gscryRpt, prPrint_Title)
        '    gscryRpt.PrintToPrinter(1, False, 0, 0)
        'End If


    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click

    End Sub
    Private Sub Discard_Sales_Order()
        If IsNew = True Then
            fclear_Info()

        Else
            If MessageBoxQuestion("Create new?") = True Then
                IsNew = True
                ID = 0
                fclear_Info()

            Else
                fclear_Info()
                fRefreshInfo_sales_order(ID)
                fRefreshItem_sales_order(ID)
            End If

        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
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
        If IsNew = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        Dim rd As OdbcDataReader = SqlReader($"select * from contact where id ='{s}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub


    Private Sub tsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If IsOrder = True Then
            fSales_order_add_item()
        Else
            fInvoice_add_item()
        End If


    End Sub
    Private Sub fInvoice_add_item()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Or cmbCUSTOMER_ID.SelectedValue Is Nothing Or cmbCUSTOMER_ID.Text = "" Then
            MessageBoxInfo("Please select customer")
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
                .Size = New Size(FLP_TABLE.Size.Width, My.Computer.Screen.WorkingArea.Height)
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
            MessageBoxInfo("Please select customer")
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
                .Size = New Size(FLP_TABLE.Size.Width, My.Computer.Screen.WorkingArea.Height)
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
        GetQuickFind(dgvProductItem, tsTextFind.Text)
    End Sub

    Private Sub SelectPrintPageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectPrintPageToolStripMenuItem.Click
        'If IsNew = True Then
        '    TsSaveNew_Click(sender, e)
        'Else
        '    If IsCheckHasChange() = True Then
        '        If MessageBoxQuestion(gsMessageCheckEdit) = True Then
        '            tChangeAccept = False
        '            TsSaveNew_Click(sender, e)
        '            If tChangeAccept = False Then
        '                MessageBoxInfo("Cancel")
        '                Exit Sub
        '            End If
        '        Else
        '            Exit Sub
        '        End If
        '    End If
        'End If

        'If IsNew = True Then Exit Sub

        'frmPrintPage.frmName = Me.Name
        'frmPrintPage.ShowDialog()

        'Dim v As Integer = frmPrintPage.prValue
        'If v = 1 Or v = 2 Then

        '    Dim prFile_name As String = ""
        '    Dim prPrint_Title As String = ""
        '    Dim cn As New OleDb.OleDbConnection(fMS_Con)
        '    Try
        '        cn.Open()
        '        Dim R_number As OleDb.OleDbDataReader = fMSgetReader("select [file_name],[print_title] from tblprint  where [form_name] = '" & Me.Name & "' and  [print_default] = '1' ", cn)
        '        If R_number.Read Then
        '            prPrint_Title = R_number("print_title")
        '            prFile_name = R_number("file_name")
        '        End If
        '        cn.Close()
        '    Catch ex As Exception
        '        If cn.State = ConnectionState.Open Then
        '            cn.Close()
        '        End If
        '    End Try

        '    gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
        '    CryParameterInsertValue(gscryRpt, Val(ID), "myid")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        '    CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        '    CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")
        '    ReportExporPDF(gscryRpt, prPrint_Title)
        '    If v = 2 Then
        '        gsToolPanelView = False

        '        GlobalPreviewReport(prPrint_Title & "Report")
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


                For N As Integer = 1 To IIf(CUSTOM_DINE_IN_NO = 0, gsPOS_RESTAURANT_TABLE_NO, CUSTOM_DINE_IN_NO)

                    Dim PNL As Panel = .Controls($"pnl{N}")
                    Dim Btn As Button = PNL.Controls($"btnOrder{N}")
                    If SelectTable = True And numTableSelected <> N Then

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
                    If SelectTable = True And numTableSelected <> Btn.AccessibleDescription Then

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
            numTableSelected = 0
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
            numTableSelected = 1
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
        If IsNew = False Then Exit Sub
        If cmbSALES_REP_ID.Text = "" Then Exit Sub
        xlblSalesRep.Text = cmbSALES_REP_ID.Text


    End Sub

    Private Sub btnBACK_Click(sender As Object, e As EventArgs)


    End Sub



    Private Sub btnNEWORDER_Click(sender As Object, e As EventArgs) Handles btnNEWORDER.Click
        IsOrder = True
        ID = 0
        IsNew = True
        fclear_Info()
        fLoad_Reference()
        fControlEnable(False)

    End Sub

    Private Sub btnRECEIVED_ORDER_Click(sender As Object, e As EventArgs) Handles btnRECEIVED_ORDER.Click
        Dim bGot_item_Added = False
        IsOrder = False
        If dgvSalesOrder.Rows.Count <> 0 Then
            dgvSalesOrder.Select()
            frmPOSServed.gsCUSTOMER_ID = GetNumberFieldValue("sales_order", "id", dgvSalesOrder.CurrentRow.Cells(0).Value, "CUSTOMER_ID")

        Else
            If rbDINE_IN.Checked = True Then

            ElseIf rbTAKE_OUT.Checked = True Then
                numTableSelected = 0
            ElseIf rbDELIVERY.Checked = True Then
                numTableSelected = 0
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

        frmPOSServed.gsTABLE_NO = numTableSelected


        frmPOSServed.ShowDialog()
        numTableSelected = frmPOSServed.gsTABLE_NO
        If frmPOSServed.gsOK = True Then
CREATE_NOW:


            ID = 0
            IsNew = True
            fclear_Info()
            fLoad_Reference()
            fControlEnable(False)

            If frmPOSServed.dgvSELECTED.Rows.Count <> 0 Then
                bGot_item_Added = True
                Dim dgv_top As DataGridView = frmPOSServed.dgvSELECTED
                For I As Integer = 0 To dgv_top.Rows.Count - 1
                    Dim rd As OdbcDataReader = SqlReader($"select s.*,d.description as desc_name from SALES_ORDER_ITEMS as S left outer join discount_type as d on d.id =  s.DISCOUNT_TYPE  where S.SALES_ORDER_ID='{dgv_top.Rows(I).Cells(0).Value}' and S.GROUP_LINE_ID is null order by S.LINE_NO")
                    While rd.Read
                        fRow_Data_Item_Invoice(dgvProductItem, True, NumIsNull(rd("ITEM_ID")), NumIsNull(rd("QUANTITY")), NumIsNull(rd("RATE")), TextIsNull(rd("desc_name")), NumIsNull(rd("DISCOUNT_TYPE")), NumIsNull(rd("AMOUNT")), CBool(NumIsNull(rd("TAXABLE"))), NumIsNull(rd("UNIT_ID")), "A", NumIsNull(rd("UNIT_BASE_QUANTITY")), TextIsNull(rd("DISCOUNT_TYPE")), NumIsNull(rd("ORG_AMOUNT")), NumIsNull(rd("ID")), TextIsNull(rd("PRICE_LEVEL_ID")), 0, CBool(NumIsNull(rd("PRINT_IN_FORMS"))), 0)
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

                If MessageBoxPointOfSalesYesNO($"Do you want to save this served order?") = True Then
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
            MessageBoxInfo("No order process created.")
            Exit Sub
        End If
        IsOrder = True
        dgvSalesOrder.Select()
        ID = dgvSalesOrder.CurrentRow.Cells("ID").Value
        IsNew = False
        fclear_Info()
        fLoad_Reference()
        fControlEnable(False)
    End Sub

    Private Sub btnCANCEL_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSAVE_Click_1(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If IsOrder = True Then

            fSaveSalesOrder()
        Else
            fSaveInvoice()
        End If


    End Sub

    Private Sub btnCUSTOMER_Click_1(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
        frmPOSContacts.gsContact_Type = 1
        frmPOSContacts.ShowDialog()

        If frmPOSContacts.gsOK = True Then
            ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

            cmbCUSTOMER_ID.SelectedValue = frmPOSContacts.gsContact_ID
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing

        If bNewContact = True Then
            frmContactDetails.IsNew = True

            frmContactDetails.ContactTypeId = 1
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblCustomer_Name.Text = ""
                xlblAcctNo.Text = ""
                ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = frmContactDetails.ID
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
                ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedIndex = -1
                xlblSalesRep.Text = ""
            Else
                ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmPOSContacts.gsContact_ID
            End If
        Else
            bNewContact = frmPOSContacts.gsNewContact
        End If
        frmPOSContacts.Dispose()
        frmPOSContacts = Nothing
        If bNewContact = True Then
            '   frmContactDetails.PictureBox1.Image = tsSalesRep.Image
            frmContactDetails.IsNew = True
            frmContactDetails.ContactTypeId = 2
            frmContactDetails.ShowDialog()
            If frmContactDetails.gsOK = True Then
                xlblSalesRep.Text = ""
                ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = frmContactDetails.ID
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
        IsNew = True
        ID = 0
        fclear_Info()
        fControlEnable(True)
    End Sub

    Private Sub btnVIEW_DETAILS_Click(sender As Object, e As EventArgs) Handles btnVIEW_DETAILS.Click
        If dgvInvoice.Rows.Count = 0 Then
            MessageBoxInfo("No order served created.")
            Exit Sub
        End If
        IsOrder = False
        dgvInvoice.Select()
        ID = dgvInvoice.CurrentRow.Cells("ID").Value
        IsNew = False
        fclear_Info()
        fLoad_Reference()
        fControlEnable(False)
    End Sub



    Private Sub btnDELETE_Click(sender As Object, e As EventArgs) Handles btnDELETE.Click

        If IsOrder = True Then
            fDeletSalesOrder()
        Else
            fDeleteInvoice()
        End If

    End Sub
    Private Sub fDeleteInvoice()
        If IsNew = False Then
            If SecurityAccessDelete(frmInvoice) = False Then
                Exit Sub
            End If

            'If IsClosingDate(dtpDATE.Value) = False Then
            '    Exit Sub
            'End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then


                Try

                    Dim rd As OdbcDataReader = SqlReader("select * from payment_invoices where invoice_id = '" & ID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            MessageBoxWarning("Invalid delete invoice. payment are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("delete from payment_invoices where invoice_id = '" & ID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try
                'credit memo
                Try

                    Dim rd As OdbcDataReader = SqlReader("select * from `credit_memo_invoices` where invoice_id = '" & ID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            MessageBoxWarning("Invalid delete invoice. credit memo are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("delete from `credit_memo_invoices` where invoice_id = '" & ID & "'")
                        End If
                    End If
                    rd.Close()
                Catch ex As Exception

                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try
                'tax credit
                Try
                    ' cn.Open()
                    Dim rd As OdbcDataReader = SqlReader("select * from `tax_credit_invoices` where invoice_id = '" & ID & "' limit 1")
                    If rd.Read Then
                        If gsForceDeleteInvoice = False Then
                            MessageBoxWarning("Invalid delete invoice. tax credit are applied")
                            rd.Close()
                            Exit Sub
                        Else
                            SqlExecuted("delete from `tax_credit_invoices` where invoice_id = '" & ID & "'")
                        End If


                    End If
                    rd.Close()
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try



                For N As Integer = 0 To dgvProductItem.Rows.Count - 1
                    With dgvProductItem.Rows(N)
                        .Cells("CONTROL_STATUS").Value = "D"
                    End With
                Next

                '===
                SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

                '====

                '===========================================
                If gsSkipJournalEntry = False Then

                    fAccount_journal_Delete(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    If NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        fAccount_journal_Delete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    End If

                End If
                '================================

                SqlExecuted("delete from invoice where id ='" & ID & "' limit 1;")
                SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                ID = 0
                IsNew = True
                btnCANCEL.PerformClick()
                Dim S As Integer = numTableSelected
                fRefreshTable()
                fGetDefaultTable(S)
                CursorLoadingOn(False)
            End If


        End If

    End Sub
    Private Sub fDeletSalesOrder()
        If IsNew = False Then
            If SecurityAccessDelete(frmSalesOrder) = False Then
                Exit Sub
            End If
            'If IsClosingDate(dtpDATE.Value) = False Then
            '    Exit Sub
            'End If
            If MessageBoxQuestion(gsMessageQuestion) = True Then

                SqlExecuted("DELETE FROM sales_order_items WHERE SALES_ORDER_ID = '" & ID & "'")
                SqlExecuted("DELETE FROM sales_order WHERE ID = '" & ID & "'")
                SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                fclear_Info()
                dgvProductItem.Rows.Clear()
                fComputed()
                ID = 0
                IsNew = True
                btnCANCEL.PerformClick()
                Dim S As Integer = numTableSelected
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
            MessageBoxInfo("No Served Order found.")
            Exit Sub
        End If
        dgvInvoice.Select()
        Dim Invoice_ID As Integer = 0

        Try
            Invoice_ID = dgvInvoice.CurrentRow.Cells(0).Value
        Catch ex As Exception
            MessageBoxWarning("Please select served no.")
            Exit Sub
        End Try

        If numTableSelected = 0 Then
            MessageBoxExclamation("No select table")
            Exit Sub
        End If

        Dim S As Integer = numTableSelected
        Dim ThisID As Integer = 0
        Dim isPaymentClick As Boolean = False

        If gsMultiMethod = False Then

            If rbDELIVERY.Checked = True Then
                frmPOSCreatePayment.gsORDER_TYPE = gsDELIVERY_ID
            ElseIf rbDINE_IN.Checked = True Then
                frmPOSCreatePayment.gsORDER_TYPE = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                frmPOSCreatePayment.gsORDER_TYPE = gsTAKE_OUT_ID
            End If

            frmPOSCreatePayment.gsTABLE_NO = S
            frmPOSCreatePayment.gsCUSTOMER_ID = GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "CUSTOMER_ID")
            frmPOSCreatePayment.ShowDialog()

            ThisID = frmPOSCreatePayment.gsID
            isPaymentClick = frmPOSCreatePayment.gsOK

            frmPOSCreatePayment.Dispose()
            frmPOSCreatePayment = Nothing

        Else

            'Pure Multi-payment

            If rbDELIVERY.Checked = True Then
                FrmPOSCreatePaymentMultiMethod.gsORDER_TYPE = gsDELIVERY_ID
            ElseIf rbDINE_IN.Checked = True Then
                FrmPOSCreatePaymentMultiMethod.gsORDER_TYPE = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                FrmPOSCreatePaymentMultiMethod.gsORDER_TYPE = gsTAKE_OUT_ID
            End If

            FrmPOSCreatePaymentMultiMethod.dgvINVOICE_LIST = dgvInvoice
            FrmPOSCreatePaymentMultiMethod.gsTABLE_NO = S
            FrmPOSCreatePaymentMultiMethod.gsCUSTOMER_ID = GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "CUSTOMER_ID")
            FrmPOSCreatePaymentMultiMethod.ShowDialog()
            ThisID = FrmPOSCreatePaymentMultiMethod.gsID
            isPaymentClick = FrmPOSCreatePaymentMultiMethod.gsOK
            FrmPOSCreatePaymentMultiMethod.Dispose()
            FrmPOSCreatePaymentMultiMethod = Nothing


        End If



        If isPaymentClick = True Then

            fDoEvents()
            If gsPOSPrintOS = True Then

                If rbDINE_IN.Checked = False Then
                    fPrintBill()
                    fDoEvents()

                    If PRINT_INVOICE_AFTER_PRINT_PAYMENT = True Then
                        fPrintBill()
                    End If
                End If

            Else
                'Another tregger
                ' or screening kitchen monitoring
            End If

            If Msg_Print_Payment = True Then
                If MessageBoxPointOfSalesYesNO($"Do you want to Print {gsPayment_Print_Title.ToUpper}?") = True Then
                    fPaymentReceipt(ThisID)
                End If
            End If

            fOpenCashDrawer()
            numTableSelected = S
            fRefreshTable()
        End If

        If isPaymentClick = True Then
            fDoEvents()
            IsNew = True
            ID = 0
            fclear_Info()
            fLoad_Reference()
            fControlEnable(True)
            fGetDefaultTable(S)
        End If

    End Sub
    Private Sub fPaymentReceipt(ByVal ThisID As Integer)

        fSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)

        Try


            Dim prFile_name As String = gsPayment_File_Name '' "cryPOSRestoPayment.rpt"
            Dim prPrint_Title As String = gsPayment_Print_Title '' "OFFICIAL RECEIPT"
            gscryRpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, ThisID, "id")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")


            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                frmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
                frmReportViewer.WindowState = FormWindowState.Normal
                frmReportViewer.ShowDialog()
                frmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RbDELIVERY_CheckedChanged(sender As Object, e As EventArgs) Handles rbDELIVERY.CheckedChanged
        If rbDELIVERY.Checked = True Then

            If Ship_Via_count = 1 Then
                gsThemeNo = 0
            Else
                gsThemeNo = 2
            End If

            fMaterialSkin(Me)
            numTableSelected = 1
            fRefreshTable()
            xxlblSalesman.Text = "SALE ON"

        End If
    End Sub

    Private Sub btnPRINTBILL_Click(sender As Object, e As EventArgs) Handles btnPRINTBILL.Click
        btnPRINTBILL.Enabled = False
        fPrintBill()
        btnPRINTBILL.Enabled = True
    End Sub
    Private Sub fPP_billPrint(ByVal prID As Integer)

        fSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)
        Dim prFile_name As String = gsInvoice_File_Name
        Dim prPrint_Title As String = gsInvoice_Print_Title
        gscryRpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, Val(prID), "myid")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")
        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

        If gsPOSPrintPreview = True Then
            gsToolPanelView = False
            frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            frmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
            frmReportViewer.WindowState = FormWindowState.Normal
            frmReportViewer.ShowDialog()
            frmReportViewer.Dispose()

        Else

            gscryRpt.PrintToPrinter(1, False, 0, 0)

        End If
    End Sub
    Private Sub fPrintBill()
        If dgvInvoice.Rows.Count <> 0 Then
            dgvInvoice.Select()

            Try
                Dim id As Integer = dgvInvoice.CurrentRow.Cells(0).Value
                fPP_billPrint(id)
            Catch ex As Exception

            End Try


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

            Dim rd As OdbcDataReader = SqlReader($"select  count(*) as C from ((SELECT s.STATUS_DATE,s.SHIP_TO FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{prORDER_Type}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.STATUS_DATE,s.SHIP_TO FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{prORDER_Type}' and  s.ship_to > '0' and s.`STATUS` in ('13','16')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id) {SQL_R}) as D order by D.SHIP_TO  limit {gsPOS_RESTAURANT_TABLE_NO}")
            If rd.Read Then
                N = NumIsNull(rd("C"))
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
        btnPRINTBILL_Fake.Enabled = False
        btnPRINTBILL_Click(sender, e)
        btnPRINTBILL_Fake.Enabled = True
    End Sub

    Private Sub BtnCreatePayment_Fake_Click(sender As Object, e As EventArgs) Handles btnCreatePayment_Fake.Click
        BtnCreatePayment_Click(sender, e)
    End Sub

    Private Sub btnPRINTOS_Click(sender As Object, e As EventArgs) Handles btnPRINTOS.Click
        If dgvSalesOrder.Rows.Count <> 0 Then
            dgvSalesOrder.Select()
            Dim id As Integer = dgvSalesOrder.CurrentRow.Cells(0).Value

            Dim prFile_name As String = gsSalesOrder_File_Name
            Dim prPrint_Title As String = gsSalesOrder_Print_Title

            gscryRpt = PublicViewReportOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(id), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")

            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

            ReportExporPDF(gscryRpt, prPrint_Title)

            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                frmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                frmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
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
                        IsNew = True
                        ID = 0
                        fclear_Info()
                        fLoad_Reference()
                        fControlEnable(True)
                        Dim S As Integer = numTableSelected
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

    Private Sub btnOpenCashDrawer_Click(sender As Object, e As EventArgs)


        '   fOpenCashDrawer()
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub FLP_TABLE_Paint(sender As Object, e As PaintEventArgs) Handles FLP_TABLE.Paint

    End Sub
End Class