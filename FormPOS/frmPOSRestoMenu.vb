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

    Private Sub FrmPOSOrderEntry_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If gsCloseCall = True Then
            bActiveFirst = False
            FrmSplash.Show()
            FrmSplash.Timer1.Enabled = True
            gsMenuSubID = 0
            gsMenuID = 0
            Me.Dispose()
        End If
    End Sub

    Private Sub FrmPOSOrderEntry_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsCloseCall = True Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub DgvProductItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvProductItem.RowStateChanged
        tsCOUNT.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Function CheckHasChange() As Boolean
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

        gsPOS_DEFAULT_PRINTER = GetDBAccessValueByText("POS_DEFAULT_PRINTER")
        SmallBox = CBool(Val(GetDBAccessValueByText("USE_SMALL_BOX")))
        CUSTOM_DINE_IN_NO = Val(GetDBAccessValueByText("CUSTOM_DINE_IN_NO"))
        Msg_Print_Payment = CBool(Val(GetDBAccessValueByText("MSG_PRINT_PAYMENT")))
        PRINT_INVOICE_AFTER_PRINT_PAYMENT = CBool(Val(GetDBAccessValueByText("PRINT_INVOICE_AFTER_PRINT_PAYMENT")))
        PRINT_OS_AFTER_SAVE_INVOICE = CBool(Val(GetDBAccessValueByText("PRINT_OS_AFTER_SAVE_INVOICE")))

        gsPOS_MACHINE_ID = GF_GetPosMachineId()
        gsPOS_SERVED_ONLY = GS_IsServedOnly()
        gsPOS_TYPE_ID = GF_PosMachineTypeMap()

        tslblCONNECT.Text = db_Connection_Name
        Me.Icon = gsIcon
        Me.Text = "POS"
        pcLOGO.BackgroundImage = gsImageNameApp
        pcLOGO.BackgroundImageLayout = ImageLayout.Stretch
        '  fBackGroundImageStyle(Me)
        pnlTOP.BackColor = Color.Transparent
        FlowLayoutPanel1.BorderStyle = BorderStyle.None

        GS_Label_Digital_LM(lblAMOUNT)
        GS_Label_Digital_LM(xlblTOTAL)
        GS_Label_Digital_M(lblOUTPUT_TAX_AMOUNT)



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









        gsUserDefaulLockNegativePerUser = GF_UserDefaulLockNegativePerUser()
        gsDefault_unit_price_level_id = GF_UserDefaultPriceLevel()
        gsDefault_LOCATION_ID = GetLoadLocationDefault()
        gsStorage_Location_ID = GetLoadStorageLocation()
        gsIncRefNoByLocation = GetIncRefNoByLocation()
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        ' LoadDefaultAccount()
        Me.AccessibleName = GF_GetStringFieldValue("tblsub_menu", "form", "frmSalesOrder", "sub_id")
        gsPETTY_CASH_ACCOUNT_ID = GetPettyCashAccount()
        gsCASH_OVER_SHORT_EXPENSES = GetCashOverShortExpense()
        gsPOSDefaultCustomer_ID = GetSystemSettingValueByText("POSDefaultCustomerId")
        gsPOS_RESTAURANT_TABLE_NO = GF_GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "RESTAURANT_TABLE_NO")
        gsDRAWER_ACCOUNT_ID = GF_GetStringFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "ACCOUNT_ID")
        gsDINE_IN_ID = GF_GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "DINE_IN_ID")
        gsTAKE_OUT_ID = GF_GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "TAKE_OUT_ID")
        gsDELIVERY_ID = GF_GetNumberFieldValue("POS_MACHINE", "ID", gsPOS_MACHINE_ID, "DELIVERY_ID")










        Ship_Via_count = 0

        If gsDINE_IN_ID = 0 Then
            rbDINE_IN.Visible = False
        Else
            Ship_Via_count += 1
            gsDINE_NAME = GF_GetStringFieldValue("ship_via", "id", gsDINE_IN_ID, "DESCRIPTION")
        End If

        If gsTAKE_OUT_ID = 0 Then
            rbTAKE_OUT.Visible = False
        Else
            Ship_Via_count += 1
            gsTAKE_OUT_NAME = GF_GetStringFieldValue("ship_via", "id", gsTAKE_OUT_ID, "DESCRIPTION")
        End If

        If gsDELIVERY_ID = 0 Then
            rbDELIVERY.Visible = False
        Else
            Ship_Via_count += 1
            gsDELIVERY_NAME = GF_GetStringFieldValue("ship_via", "id", gsDELIVERY_ID, "DESCRIPTION")
        End If


        '====================================================================
        GetPosCreate()
        LoadReference()


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

    Private Sub GetPosCreate()

        gsPOS_DATE = Date.Now
        If GF_GetNumberFieldValue("USER_DEFAULT", "USER_ID", gsUser_ID, "pos_select_date") <> 0 Then
            FrmSelectDate.ShowDialog()
            If FrmSelectDate.gsOK = True Then
                gsPOS_DATE = FrmSelectDate.dtpSelect.Value
            Else
                gsPOS_DATE = Date.Now
            End If
            FrmSelectDate.Dispose()
            FrmSelectDate = Nothing
        End If

        gsPOS_LOG_ID = 0
        Dim bStartNew As Boolean = False
        'POS LOG
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,STARTING_RECEIPT_NO,ENDING_RECEIPT_NO,STARTING_CASH_ID,CASH_COUNT_ID FROM POS_LOG WHERE POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  and DATE(recorded_On) ='{GetDateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and CASHIER_ID = '{gsCashier_ID}' ORDER BY ID DESC Limit 1;")
        If rd.Read Then
            If GF_NumIsNull(rd("CASH_COUNT_ID")) <> 0 Then
                FrmPOSLogSwitch.ShowDialog()
                bStartNew = FrmPOSLogSwitch.gsStartNew
                FrmPOSLogSwitch.Dispose()
                FrmPOSLogSwitch = Nothing
            End If
            If bStartNew = True Then
                GoTo NewPOS_LOG
            End If

            gsSTARTING_RECEIPT_NO = GF_NumIsNull(rd("STARTING_RECEIPT_NO"))
            gsPOS_LOG_ID = GF_NumIsNull(rd("ID"))
            gsSTARTING_CASH_ID = GF_NumIsNull(rd("STARTING_CASH_ID"))
            gsENDING_RECEIPT_NO = GF_NumIsNull(rd("ENDING_RECEIPT_NO"))
            gsCASH_COUNT_ID = GF_NumIsNull(rd("CASH_COUNT_ID"))

        Else
NewPOS_LOG:
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

            If GetDateFormatMySql(gsPOS_DATE) = GetDateFormatMySql(Date.Now.Date) Then
                LOG_DATE = GetDateTimeNowSql()
            Else
                LOG_DATE = $"{GetDateFormatMySql(gsPOS_DATE)} 08:00:01"
            End If
            SqlExecuted($"INSERT INTO pos_starting_cash SET ID = '{gsSTARTING_CASH_ID}',RECORDED_ON='{LOG_DATE}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',CASHIER_ID='{gsCashier_ID}',AMOUNT='{sAMount}',POSTED='0',DRAWER_ACCOUNT_ID='{gsDRAWER_ACCOUNT_ID}',PETTY_CASH_ACCOUNT_ID='{gsPETTY_CASH_ACCOUNT_ID}' ")
            GS_PosStartingCashJournal(gsSTARTING_CASH_ID, gsPOS_DATE, gsDefault_LOCATION_ID)
            GS_PosLogLoad()

        End If
        rd.Close()
        GS_CollectPosLogResto()
    End Sub
    Private Sub HeaderSalesOrderRefresh()

        If rbDINE_IN.Checked = True Then
            GS_LoadDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDINE_IN_ID}' and s.STATUS in('16','12')  ")
        ElseIf rbTAKE_OUT.Checked = True Then
            GS_LoadDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsTAKE_OUT_ID}' and  s.STATUS in ('16','12')  ")
        ElseIf rbDELIVERY.Checked = True Then
            GS_LoadDataGridView(dgvSalesOrder, $"SELECT s.ID,s.CODE as `ORDER NO.`, d.DESCRIPTION as `STATUS` FROM sales_order as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDELIVERY_ID}' and  s.STATUS in ('16','12')  ")
        End If
        dgvSalesOrder.Columns(0).Visible = False
        GS_ViewNotSort(dgvSalesOrder)
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
    Private Sub Header_Invoice_Refresh()
        If rbDINE_IN.Checked = True Then
            GS_LoadDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDINE_IN_ID}' and  s.STATUS ='13'  ")
        ElseIf rbTAKE_OUT.Checked = True Then
            GS_LoadDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsTAKE_OUT_ID}' and s.STATUS ='13'  ")
        ElseIf rbDELIVERY.Checked = True Then
            GS_LoadDataGridView(dgvInvoice, $"SELECT s.ID,s.CODE as `SERVED NO.`, d.DESCRIPTION as `STATUS` FROM invoice as s inner join document_status_map as d on d.id = s.STATUS where  SHIP_TO ='{numTableSelected}'  and SHIP_VIA_ID='{gsDELIVERY_ID}' and s.STATUS ='13'  ")
        End If
        dgvInvoice.Columns(0).Visible = False
        GS_ViewNotSort(dgvInvoice)
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

    Private Sub RefreshTable()
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
                        SQL &= $" UNION ALL (SELECT '{T}'  as `T_NO`, {xSQL_RECORD} as this_record,{xSQL_STATUS} as this_status) "
                    End If
                    'CreateTableAdd_DINE_IN(T, Color.Cyan)
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
                        If GF_NumIsNull(rd_dine("this_status")) = 0 Then
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
                    CreateBox(rd_dine("T_NO"), This_Color, This_Label, This_Status, DTT)
                End While
                rd_dine.Close()

                GetDefaultTable(numTableSelected)
            ElseIf rbTAKE_OUT.Checked = True Then
                Dim N As Integer = 0
                Dim rd As OdbcDataReader = SqlReader($"select  D.RECORDED_ON,D.SHIP_TO, D.`STATUS` from ((SELECT s.RECORDED_ON,s.SHIP_TO, 0 as `STATUS` FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsTAKE_OUT_ID}' and  s.ship_to > '0' and s.`STATUS` in ('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO, if(s.STATUS=16,1,0) as `STATUS` FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsTAKE_OUT_ID}' and  s.ship_to > '0' and s.`STATUS` in ('13','16')  and NOT EXISTS (select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO`,1 as `STATUS` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsTAKE_OUT_ID}' order by s.id ) ) as D order by D.RECORDED_ON  limit {gsPOS_RESTAURANT_TABLE_NO} ")
                While rd.Read
                    N += 1
                    Dim DTT As DateTime = DateTimeFormatMySql(rd("RECORDED_ON"))

                    Dim This_label As String
                    If GF_NumIsNull(rd("STATUS")) = 0 Then
                        This_label = "On-going"
                        CreateBox(N, Color.YellowGreen, This_label, GF_NumIsNull(rd("ship_to")), DTT.ToString)
                    Else
                        This_label = "Waiting"
                        CreateBox(N, Color.LightBlue, This_label, GF_NumIsNull(rd("ship_to")), DTT.ToString)
                    End If


                End While
                rd.Close()
                GetDefaultTable(numTableSelected)
            ElseIf rbDELIVERY.Checked = True Then
                Dim rd As OdbcDataReader = SqlReader($"select D.RECORDED_ON,D.SHIP_TO, D.`STATUS`  from ((SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDELIVERY_ID}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO,0 as `STATUS` FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDELIVERY_ID}' and  s.ship_to > '0' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id) UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDELIVERY_ID}' order by s.ID ) UNION ALL (SELECT s.RECORDED_ON,s.table_no as `SHIP_TO`,1 as `STATUS` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > 0 and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{gsDELIVERY_ID}' order by s.ID )) as D order by D.RECORDED_ON  limit {gsPOS_RESTAURANT_TABLE_NO} ")
                Dim N As Integer = 0
                While rd.Read
                    N += 1
                    Dim DTT As DateTime = DateTimeFormatMySql(rd("RECORDED_ON"))

                    Dim This_label As String
                    If GF_NumIsNull(rd("STATUS")) = 0 Then
                        This_label = "On-going"
                    Else
                        This_label = "Waiting"
                    End If


                    CreateBox(N, Color.DarkOrange, This_label, GF_NumIsNull(rd("ship_to")), DTT.ToString)
                End While
                rd.Close()
                GetDefaultTable(numTableSelected)
            End If

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
        NotifyNumber()
        Timer1.Start()
    End Sub



    Private Sub GetDefaultTable(ByVal S As Integer)
        ' Get Defualt First Entry

        If FLP_TABLE.Controls.Count = 0 Then
            Exit Sub
        End If
        ClearInfo()

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
    Private Sub CreateTableAdd_DINE_IN(ByVal N As Integer, ByVal C As Color)
        Dim LABEL_BUTTON As String = ""
        Dim LABEL_STATUS As String = ""
        Dim LABEL_RECORD As String = ""
        If rbDINE_IN.Checked = True Then
            DineInControl(N, LABEL_BUTTON, LABEL_STATUS, LABEL_RECORD)
            CreateBox(N, C, LABEL_BUTTON, LABEL_STATUS, LABEL_RECORD)
        End If
    End Sub
    Private Sub CreateBox(ByVal N As Integer, ByVal C As Color, ByVal LABEL_BUTTON As String, ByVal LABEL_STATUS As String, ByVal LABEL_RECORD As String)
        Dim NewPanel As New Panel With {
            .Name = $"pnl{N}",
            .AccessibleName = LABEL_BUTTON
        }

        If SmallBox = False Then
            NewPanel.Size = New Size(119, 130)
        Else
            NewPanel.Font = New Font("Verdana", 7, FontStyle.Regular)
            NewPanel.Size = New Size(89, 100)

        End If
        NewPanel.BorderStyle = BorderStyle.FixedSingle

        'Table Number
        Dim NewLabelNum As New Label With {
            .Name = $"lblnum{N}",
            .AutoSize = True,
            .Text = N
        }
        If SmallBox = False Then
            NewLabelNum.Font = New Font("Verdana", 14.25, FontStyle.Bold)
        Else
            NewLabelNum.Font = New Font("Verdana", 14.25, FontStyle.Bold)
        End If
        NewLabelNum.Location = New Point(0, 0)
        NewPanel.Controls.Add(NewLabelNum)


        'Order Type
        Dim NewLabelOrderType As New Label With {
            .Name = $"lblSTATUS{N}",
            .AutoSize = False
        }

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
        Dim NewButton As New Button With {
            .Name = $"btnOrder{N}",
            .TextAlign = ContentAlignment.MiddleCenter,
            .AutoSize = False
        }

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

        AddHandler NewButton.Click, AddressOf ButtonClick
        NewPanel.Controls.Add(NewButton)
        'Time Label
        Dim NewLabelTime As New Label With {
            .Name = $"lblTime{N}",
            .AutoSize = False
        }

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
        Dim NewDATETIME_RECORD As New Label With {
            .Name = $"lblRECORD{N}",
            .AutoSize = False
        }

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

    Private Sub ButtonClick(sender As Object, e As EventArgs)

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

        HeaderSalesOrderRefresh()
        Header_Invoice_Refresh()
        dgvProductItem.Rows.Clear()
        ClearInfo()
        Computed()

        ControlEnable(True)

        If gsJustClick = True Then
            If Btn.Text = "Served" Or Btn.Text = "Waiting" Then

                If numTableSelected = 0 Then
                    Exit Sub
                End If


                If rbDELIVERY.Checked = True Then

                    FrmPOSTableDetails.gsTABLE_NO = numTableSelected
                    FrmPOSTableDetails.gsORDER_TYPE = gsDELIVERY_ID
                    FrmPOSTableDetails.ShowDialog()
                    If FrmPOSTableDetails.gsClickOk = True Then
                        RefreshTable()
                    End If
                    FrmPOSTableDetails.Dispose()
                    FrmPOSTableDetails = Nothing
                ElseIf rbDINE_IN.Checked = True Then

                    FrmPOSTableDetails.gsTABLE_NO = numTableSelected
                    FrmPOSTableDetails.gsORDER_TYPE = gsDINE_IN_ID
                    FrmPOSTableDetails.ShowDialog()
                    If FrmPOSTableDetails.gsClickOk = True Then
                        RefreshTable()
                    End If
                    FrmPOSTableDetails.Dispose()
                    FrmPOSTableDetails = Nothing
                ElseIf rbTAKE_OUT.Checked = True Then

                    Dim rd_16 As OdbcDataReader = SqlReader($"select * from invoice WHERE DATE = '{ GetDateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and SHIP_DATE ='" & GetDateFormatMySql(gsPOS_DATE) & "' and SHIP_VIA_ID='" & gsTAKE_OUT_ID & "' and SHIP_TO='" & numTableSelected & "' and STATUS = '16' limit 1;")
                    If rd_16.Read Then

                        Dim GET_ID As Integer = GF_NumIsNull(rd_16("id"))

                        If MessageBoxPointOfSalesYesNO("Pick up?") = True Then

                            SqlExecuted($"UPDATE invoice SET `STATUS` = '14' WHERE `DATE` = '{GetDateFormatMySql(gsPOS_DATE)}' and `LOCATION_ID` = '{gsDefault_LOCATION_ID}' and `SHIP_DATE` ='" & GetDateFormatMySql(gsPOS_DATE) & "' and SHIP_VIA_ID='" & gsTAKE_OUT_ID & "' and SHIP_TO='" & numTableSelected & "' and STATUS = '16' limit 1;")
                            RefreshTable()

                        Else
                            GS_DoEvents()
                            If MessageBoxPointOfSalesYesNO("Print Order slip?") = True Then
                                Report_billPrint(GET_ID)
                            End If
                        End If

                    Else

                        FrmPOSTableDetails.gsTABLE_NO = numTableSelected
                        FrmPOSTableDetails.gsORDER_TYPE = gsTAKE_OUT_ID
                        FrmPOSTableDetails.ShowDialog()
                        If FrmPOSTableDetails.gsClickOk = True Then
                            RefreshTable()
                        End If
                        FrmPOSTableDetails.Dispose()
                        FrmPOSTableDetails = Nothing
                    End If
                    rd_16.Close()

                End If


            End If

        End If
        gsJustClick = True
    End Sub

    Private Sub ControlEnable(ByVal B As Boolean)
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

    Private Sub DineInControl(ByVal T As Integer, ByRef BUTTON_LABEL As String, ByRef STATUS_LABEL As String, ByRef DT_RECORD As String)

        Dim rd As OdbcDataReader = SqlReader($"select D.RECORDED_ON from ((SELECT s.RECORDED_ON,s.SHIP_TO FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.RECORDED_ON,s.SHIP_TO FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{gsDINE_IN_ID}' and  s.ship_to = '{T}' and s.`STATUS` in ('13')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id)) as D order by D.RECORDED_ON  limit 1;")
        If rd.Read Then
            Dim DTT As DateTime = DateTimeFormatMySql(rd("RECORDED_ON"))
            DT_RECORD = DTT.ToString
            BUTTON_LABEL = "Accommodated"
            STATUS_LABEL = ""
        Else

            STATUS_LABEL = ""
            DT_RECORD = ""
            BUTTON_LABEL = "Available"



            ' End If
        End If
        rd.Close()
    End Sub


    Private Sub LoadReference()

        If IsOrder = True Then
            ColumnGrid_Sales_order()
            GS_ViewItemDisplay(dgvProductItem)
            Hide_Standard_Column()
            GS_ViewNotSort(dgvProductItem)
            ClearInfo()
            If IsNew = False Then
                RefreshInfo_sales_order(ID)
                RefreshItem_sales_order(ID)
            End If

        Else

            ColumnGridInvoice()
            GS_ViewItemDisplay(dgvProductItem)
            Hide_Standard_Column()
            GS_ViewNotSort(dgvProductItem)
            ClearInfo()
            'Received
            If IsNew = False Then
                RefreshInfo_Invoice(ID)
                RefreshItemInvoice(ID)
            End If
        End If


    End Sub
    Private Sub ClearInfo()

        RefreshCombo()
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


        CodeLabels()
        Computed()

    End Sub

    Private Sub CodeLabels()

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


    Private Sub RefreshInfo_Invoice(ByVal id As Integer)
        Try

            Dim sQuery As String = "select * from invoice where ID = '" & id & "' Limit 1;"
            SqlExecutedUsingReading(Me, sQuery)

        Catch ex As Exception

            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo_Invoice(id)
            Else
                End
            End If
        End Try
    End Sub
    Private Sub RefreshInfo_sales_order(ByVal prID As Integer)

        Try

            Dim sQuery As String = "select * from sales_order where ID = '" & prID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)


            'cn.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshInfo_sales_order(prID)
            Else
                End
            End If


        End Try
    End Sub


    Private Sub RefreshItem_sales_order(prID As String)
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
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = GF_NumIsNull(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                            End If
                        End If
                    End With

                Next
                If CBool(GF_NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If
                x += 1
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        Finally

            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try


    End Sub

    Private Function GetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub RefreshCombo()
        xlblCustomer_Name.Visible = False
        xlblAcctNo.Visible = False
        xlblSalesRep.Visible = False

        GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

        GS_ComboBoxLoad(cmbCLASS_ID, "select * from class order by `NAME`", "ID", "NAME")
        GS_ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms ORDER BY ID DESC", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbSALES_REP_ID, "select * from contact where type ='2' order by `NAME`", "ID", "NAME")
        GS_ComboBoxLoad(cmbLOCATION_ID, "select * from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbOUTPUT_TAX_ID, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        GS_ComboBoxLoad(cmbACCOUNTS_RECEIVABLE_ID, "SELECT i.`ID`,i.`NAME` FROM account AS i WHERE  i.`TYPE` = 1", "ID", "NAME")

    End Sub
    Private Sub ColumnGridInvoice()
        GS_ColumnGrid_U_Invoice(dgvProductItem)
    End Sub
    Private Sub Hide_Standard_Column()
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
    Private Sub ColumnGrid_Sales_order()
        GS_ColumnGrid_U_SalesOrder(dgvProductItem)

    End Sub
    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        ClosedForm(Me)
    End Sub


    Private Function IfDiscountNext(ByVal ndex As Integer) As Boolean
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
    Private Sub Computed()
        Try
            Dim gsSalesSubTotal As Double = 0
            GS_SalesCustomerComputation(dgvProductItem, cmbOUTPUT_TAX_ID, lblOUTPUT_TAX_AMOUNT, lblAMOUNT, lblTAXABLE_AMOUNT, lblNONTAXABLE_AMOUNT, lblOUTPUT_TAX_RATE, gsSalesSubTotal)
            Dim dPayment_applied As Double = GF_GetSumPaymentApplied(ID, cmbCUSTOMER_ID.SelectedValue) + GF_GetSumCreditApplied(ID, cmbCUSTOMER_ID.SelectedValue) + GF_InvoiceSumTaxApplied_Amount(ID, cmbCUSTOMER_ID.SelectedValue)
            lbxPaymentApplied.Text = NumberFormatStandard(dPayment_applied)
            Dim dBalance As Double = GF_NumIsNull(NumberFormatFixed(GF_NumIsNull(lblAMOUNT.Text))) - dPayment_applied
            lblBALANCE_DUE.Text = NumberFormatStandard(dBalance)
            lbxBalance.Text = IIf(dtpDUE_DATE.Value > Date.Now.Date, "0.00", NumberFormatStandard(dBalance))
        Catch ex As Exception

        End Try


    End Sub

    Private Sub CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOUTPUT_TAX_ID.SelectedIndexChanged
        Computed()
        Select Case GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue)
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
            Dim rd As OdbcDataReader = SqlReader("select VAT_METHOD,TAX_ACCOUNT_ID from tax where ID ='" & GF_NumIsNull(cmbOUTPUT_TAX_ID.SelectedValue) & "' limit 1")
            If rd.Read Then
                lblOUTPUT_TAX_VAT_METHOD.Text = GF_TextIsNull(rd("VAT_METHOD"))
                lblOUTPUT_TAX_ACCOUNT_ID.Text = GF_TextIsNull(rd("TAX_ACCOUNT_ID"))
            Else
                lblOUTPUT_TAX_VAT_METHOD.Text = ""
                lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                CmbOUTPUT_TAX_ID_SelectedIndexChanged(sender, e)
            Else
                End
            End If

            lblOUTPUT_TAX_VAT_METHOD.Text = ""
            lblOUTPUT_TAX_ACCOUNT_ID.Text = ""
        End Try
    End Sub

    Private Sub EditItem()
        If IsOrder = True Then
            Edit_SalesOrder()
        Else
            EditInvoice()
        End If

    End Sub

    Private Sub EditInvoice()
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
            ElseIf GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With FrmAddItem

                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
                    bAlreadySave = False
                Else
                    bAlreadySave = True
                End If
                .sFormName = "frmInvoice"
                .gsItem_ID = dgvProductItem.Rows.Item(I).Cells("ITEM_ID").Value
                .gsUM = dgvProductItem.Rows.Item(I).Cells("UNIT_ID").Value
                .gsUnit_Price = dgvProductItem.Rows.Item(I).Cells("UNIT_PRICE").Value
                .gsQty = dgvProductItem.Rows.Item(I).Cells("QTY").Value
                .gsDiscount_Type = GF_TextIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_ID").Value)
                .gsDiscount_Rate = GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("DISCOUNT_RATE").Value)
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

                FrmAddItem.ShowDialog()

                If .gsSave = True Then
                    GS_RowDataItemInvoice(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, dgvProductItem.Rows.Item(I).Cells("REF_LINE_ID").Value, .gsPRICE_LEVEL_ID, 0, False, .gsBATCH_ID)

                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing

        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub
    Private Sub Edit_SalesOrder()
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
            ElseIf GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value) <> 0 Then
                MessageBoxInfo("Invalid to Edit")
                Exit Sub
            End If

            With FrmAddItem
                .gsNonInventoryItem = True
                If GF_NumIsNull(dgvProductItem.Rows.Item(I).Cells("ID").Value) = 0 Then
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
                    GS_RowDataItemSalesOrder(dgvProductItem, False, .gsItem_ID, .gsQty, .gsUnit_Price, .cmbDiscount_Type.Text, .gsDiscount_Rate, .gsAmount, .gsTax, .cmbUM.SelectedValue, "E", .gsBase_Qty, .gsDiscount_Type, .gsOriginal_Amount, "", .gsPRICE_LEVEL_ID, False, 0)

                End If
            End With
            Computed()
            FrmAddItem.Dispose()
            FrmAddItem = Nothing
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub DgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        EditItem()
    End Sub
    Private Sub DgvProductItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellClick
        If e.ColumnIndex = 9 Then
            If e.RowIndex = -1 Then
                Exit Sub
            End If
            GS_TaxValue(dgvProductItem)
            Computed()
        End If
    End Sub
    Private Sub SaveInvoice()

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
        If SecurityAccessMode(FrmInvoice, IsNew) = False Then
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

            If GF_NumIsNull(lblAMOUNT.Text) < 1 Then
                txtNOTES.Text = txtNOTES.Text & " FREE MEAL/COUPON PAID"
            End If

            FrmPOSRestoNoteDT.Dispose()
            FrmPOSRestoNoteDT = Nothing
        Else

            If GF_NumIsNull(lblAMOUNT.Text) < 1 Then
                txtNOTES.Text = "FREE MEAL/COUPON PAID"
            Else
                txtNOTES.Text = ""
            End If

        End If


        If IsNew = True Then


            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = GF_GetNextCode("INVOICE", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            If GF_NumIsNull(lblAMOUNT.Text) < 1 Then
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
                    numTableSelected = GetNextInvoiceTodayCountNumber() + 1
                End If
            ElseIf rbDELIVERY.Checked = True Then
                ORDER_TYPE_ID = gsDELIVERY_ID
                If numTableSelected = 0 Then
                    numTableSelected = GetNextInvoiceTodayCountNumber() + 1
                End If
            End If
            Dim bTotal_Balance As Double = NumberFormatFixed(lblBALANCE_DUE.Text)
            Dim nStatus As Integer = IIf(GF_NumIsNull(lblAMOUNT.Text) <= 0, 16, 13)

            SqlExecuted($"INSERT INTO invoice ({SQL_Field1},{SQL_Field2},ID,RECORDED_ON,SHIP_DATE,SHIP_VIA_ID,SHIP_TO,STATUS,STATUS_DATE,IS_FC) VALUES ({SQL_Value1},{SQL_Value2},'{ID}','{GetDateTimeNowSql()}','{GetDateFormatMySql(gsPOS_DATE)}','{ORDER_TYPE_ID}','{numTableSelected}','{nStatus}',{GetDateTimeNowSql()},0) ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)


        Else
            '    If IsClosingDate(dtpDATE.Value) = False Then
            '        Exit Sub
            '    End If

            If GF_NumIsNull(lblAMOUNT.Text) < 1 Then
                lblAMOUNT.Text = "0"
            End If

            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me)
            Dim bTotal_Balance As Double = NumberFormatFixed(lblBALANCE_DUE.Text)
            Dim nStatus As Integer = IIf(GF_NumIsNull(lblAMOUNT.Text) <= 0, 16, 13)
            squery = squery & $",STATUS='" & nStatus & "',STATUS_DATE ='" & GetDateTimeNowSql() & "' WHERE ID = '" & ID & "'"
            SqlExecuted($"UPDATE invoice SET {squery},STATUS='{nStatus}',STATUS_DATE ='{ GetDateTimeNowSql()}' WHERE ID = '{ID}'")
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        End If

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            GS_AccountJournalExecute(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 0, GF_NumIsNull(lblAMOUNT.Text), gsJOURNAL_NO_FORM)
            If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) = 0 Then
                GS_JournalAccountRemoveFixed_Account_ID(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), 23, ID, dtpDATE.Value, cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue)
            Else
                GS_AccountJournalExecute(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, cmbCUSTOMER_ID.SelectedValue, 23, ID, dtpDATE.Value, 1, GF_NumIsNull(lblOUTPUT_TAX_AMOUNT.Text), gsJOURNAL_NO_FORM)
            End If

        End If
        '================================
        SaveInvoiceItem(ID, dgvProductItem, cmbOUTPUT_TAX_ID, cmbLOCATION_ID, dtpDATE)

        If GF_IsTransactionSuccess(ID, "INVOICE") = False Then
            MessageBoxWarning("Please Try Again")
            Exit Sub
        End If

        Dim Got_Zero_Amount As Double = GF_NumIsNull(lblAMOUNT.Text)

        If Got_Zero_Amount < 1 Then
            Report_billPrint(ID)

            If MessageBoxPointOfSalesYesNO($"Print again {gsInvoice_Print_Title.ToUpper}?") = True Then
                Report_billPrint(ID)
            End If

        End If

        btnSAVE.Enabled = True

        If ID <> 0 Then

            Dim S As Integer = 0
            If rbDINE_IN.Checked = True Then
                S = numTableSelected
                RefreshTable()

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
                RefreshTable()

            End If
            IsNew = True
            ID = 0
            ClearInfo()
            LoadReference()
            ControlEnable(True)

            GetDefaultTable(S)
        End If



        If rbDINE_IN.Checked = True Then
            If gsPOS_SERVED_ONLY = False Then
                If MessageBoxPointOfSalesYesNO("Create payment?") = True Then
                    CreatePayment()
                End If
            Else

                If PRINT_OS_AFTER_SAVE_INVOICE = True Then
                    PrintBill()
                End If
            End If

        Else

            If Got_Zero_Amount > 0 Then
                CreatePayment()
            End If


        End If

    End Sub
    Private Sub RefreshItemInvoice(ByVal xID As Integer)
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

                If GF_NumIsNull(rd("GROUP_LINE_ID")) <> 0 Then

                    sGROUP_ITEM_ID = GF_NumIsNull(rd("GROUP_LINE_ID"))
                    sGROUP_ITEM_COUNT += 1

                Else
                    sGROUP_ITEM_COUNT = 0
                End If

                For i As Integer = 0 To rd.FieldCount - 1

                    With dgvProductItem.Columns(i)
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvProductItem.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else


                            If sGROUP_ITEM_COUNT <> 0 And sGROUP_ITEM_ID = GF_NumIsNull(rd("ITEM_ID")) And i = 1 Then
                                sGROUP_ITEM_COUNT = 0
                                sGROUP_ITEM_ID = 0
                                sGROUP_ITEM_ACTIVE = False
                                dgvProductItem.Rows(x).Cells(i).Value = ""
                            Else
                                dgvProductItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                            End If
                        End If
                    End With

                Next

                If CBool(GF_NumIsNull(rd("PRINT_IN_FORMS"))) = True Then
                    dgvProductItem.Rows(x).Visible = False
                End If

                x += 1
            End While
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItemInvoice(xID)
            Else
                End
            End If
        Finally
            Computed()
            tdgv = New DataGridView
            tdgv = dgvProductItem
            tQuery = SqlUpdate(Me)

        End Try
        bRefreshItem = False

    End Sub
    Private Function GetNextInvoiceTodayCountNumber() As Integer
        Dim N As Integer = 0
        If rbTAKE_OUT.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select  COUNT(*) as T FROM INVOICE WHERE DATE = '{GetDateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and SHIP_DATE ='{GetDateFormatMySql(gsPOS_DATE)}' and SHIP_VIA_ID ='{gsTAKE_OUT_ID}' limit 100  ")
            If rd.Read Then
                N = GF_NumIsNull(rd("T"))
            End If
            rd.Close()
        ElseIf rbDELIVERY.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select  COUNT(*) as T FROM INVOICE WHERE DATE = '{GetDateFormatMySql(gsPOS_DATE)}' and LOCATION_ID = '{gsDefault_LOCATION_ID}' and SHIP_DATE ='{GetDateFormatMySql(gsPOS_DATE)}' and SHIP_VIA_ID ='{gsDELIVERY_ID}' limit 100  ")
            If rd.Read Then
                N = GF_NumIsNull(rd("T"))
            End If
            rd.Close()
        End If

        Return N
    End Function

    Private Function AutoNumber(ByVal I As Integer) As Integer
        Dim N As Integer = 1
        If rbDELIVERY.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select NEXT_ID from pos_auto_number where ORDER_TYPE_ID = '{gsDELIVERY_ID}' and POS_MACHINE_ID='{gsPOS_MACHINE_ID}' limit 1;")
            If rd.Read Then
                N = GF_NumIsNull(rd("NEXT_ID"))
                SqlExecuted($"UPDATE pos_auto_number SET NEXT_ID ='{N + 1}' WHERE ORDER_TYPE_ID='{gsDELIVERY_ID}'and POS_MACHINE_ID='{gsPOS_MACHINE_ID}'  limit 1;")
            Else
                SqlExecuted($"INSERT INTO pos_auto_number SET  ORDER_TYPE_ID='{gsDELIVERY_ID}',POS_MACHINE_ID='{gsPOS_MACHINE_ID}',NEXT_ID ='2' ")
            End If
            rd.Close()
            Return N
        ElseIf rbTAKE_OUT.Checked = True Then
            Dim rd As OdbcDataReader = SqlReader($"select NEXT_ID from pos_auto_number where ORDER_TYPE_ID = '{gsTAKE_OUT_ID}' and POS_MACHINE_ID='{gsPOS_MACHINE_ID}' limit 1;")
            If rd.Read Then
                N = GF_NumIsNull(rd("NEXT_ID"))
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
    Private Sub SaveSalesOrder()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please Customer")
            Exit Sub
        End If

        If dgvProductItem.Rows.Count = 0 Then
            MessageBoxInfo("No item Enter")
            Exit Sub
        End If

        If SecurityAccessMode(FrmSalesOrder, IsNew) = False Then
            Exit Sub
        End If

        If IsNew = True Then

            If Trim(lblCODE.Text) = "" Then
                lblCODE.Text = GF_GetNextCode("SALES_ORDER", cmbLOCATION_ID.SelectedValue)
            End If

            dtpDATE.Checked = True

            SqlCreate(Me, SQL_Field, SQL_Value)

            ID = ObjectTypeMapId("sales_order")
            numTableSelected = AutoNumber(numTableSelected)
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
                            VALUES ({ID},'{GetDateTimeNowSql()}','{GetDateFormatMySql(Date.Now)}','{ORDER_TYPE_ID}','numTableSelected',16,{GetDateTimeNowSql()})  ")
            SetTransactionDateSelectUpdate(dtpDATE.Value)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "New", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

        Else



            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me)
            squery = squery & " WHERE ID = '" & ID & "' limit 1"
            SqlExecuted("UPDATE sales_order SET " & squery)
            SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Edit", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
        End If

        If GF_IsTransactionSuccess(ID, "sales_order") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        Else
            SaveItem_sales_order(ID)  ' Save item
        End If


        If ID <> 0 Then


            IsNew = True
            ID = 0

            ClearInfo()
            LoadReference()
            ControlEnable(True)
            Dim S As Integer = numTableSelected
            RefreshTable()
            GetDefaultTable(S)
        End If


    End Sub
    Private Sub SetNew()
        ClearInfo()
        dgvProductItem.Rows.Clear()
        Computed()
        ID = 0
        IsNew = True

    End Sub
    Private Sub SetEstimateItemUpdate(ByVal prITEM_ID As Double, ByVal prINVOICED_QTY As Double, ByVal ADD_EDIT As Boolean)
        If prITEM_ID = 0 Then
            Exit Sub
        End If

        Dim SO_SQL As String
        Dim get_SO_ID As String = GF_GetStringFieldValue("estimate_items", "ID", prITEM_ID, "estimate_ID")

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




    Private Sub SaveItem_sales_order(ByVal dID As String)

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
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "' WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value))
                        SqlExecuted(SQL_SCRIPT)
                    Case "A"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        Dim i_ID As Double = ObjectTypeMapId("SALES_ORDER_ITEMS")
                        SQL_SCRIPT = "INSERT INTO sales_order_items SET  GROUP_LINE_ID = " & GotNullNumber((.Cells("GROUP_LINE_ID").Value)) & ",PRINT_IN_FORMS ='" & GF_NumIsNull(.Cells("PRINT_IN_FORMS").Value) & "',LINE_NO='" & GF_GetMaxFieldLine("LINE_NO", "SALES_ORDER_ITEMS", "SALES_ORDER_ID", dID) & "',ID='" & i_ID & "',QUANTITY ='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & ",SALES_ORDER_ID ='" & dID & "',CLOSED ='0',INVOICED_QTY= NULL,PRICE_LEVEL_ID = " & GotNullNumber(GF_NumIsNull(.Cells("PRICE_LEVEL_ID").Value))
                        SqlExecuted(SQL_SCRIPT)

                        SetEstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)

                        If IsGroupItem(GF_NumIsNull(.Cells("ITEM_TYPE").Value), sGROUP_ITEM_ACTIVE) = True And sGROUP_ITEM_ID = 0 Then
                            sGROUP_ITEM_ID = GF_NumIsNull(.Cells("ITEM_ID").Value)
                            sGROUP_ITEM_ACTIVE = True
                        ElseIf GF_NumIsNull(.Cells("ITEM_ID").Value) = sGROUP_ITEM_ID Then
                            sGROUP_ITEM_ID = 0
                            sGROUP_ITEM_ACTIVE = False
                        End If

                    Case "E"
                        GS_Tax_Computation(cmbOUTPUT_TAX_ID, GF_NumIsNull(.Cells("AMOUNT").Value), GF_NumIsNull(.Cells("TAX").Value), dgvProductItem.Rows(i))
                        SQL_SCRIPT = "UPDATE sales_order_items SET QUANTITY='" & GF_NumIsNull(.Cells("QTY").Value) & "',RATE = '" & GF_NumIsNull(.Cells("UNIT_PRICE").Value) & "',DISCOUNT_TYPE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_ID").Value)) & ",DISCOUNT_RATE = " & GotNullNumber(GF_NumIsNull(.Cells("DISCOUNT_RATE").Value)) & ",AMOUNT = '" & GF_NumIsNull(.Cells("AMOUNT").Value) & "',TAXABLE='" & GF_NumIsNull(.Cells("TAX").Value) & "',UNIT_BASE_QUANTITY='" & GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) & "',TAXABLE_AMOUNT = '" & GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) & "',TAX_AMOUNT='" & GF_NumIsNull(.Cells("TAX_AMOUNT").Value) & "',ESTIMATE_LINE_ID =" & GotNullNumber(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value)) & ",ORG_AMOUNT='" & GF_NumIsNull(.Cells("ORG_AMOUNT").Value) & "',ITEM_ID ='" & GF_NumIsNull(.Cells("ITEM_ID").Value) & "',UNIT_ID =" & GotNullNumber(GF_NumIsNull(.Cells("UNIT_ID").Value)) & " WHERE SALES_ORDER_ID ='" & dID & "' and ID = " & GotNullNumber(GF_NumIsNull(.Cells("ID").Value)) & ""
                        SqlExecuted(SQL_SCRIPT)
                        SetEstimateItemUpdate(GF_NumIsNull(.Cells("ESTIMATE_LINE_ID").Value), GF_NumIsNull(.Cells("QTY").Value), True)
                    Case "D"
                        SQL_SCRIPT = "DELETE FROM sales_order_items WHERE SALES_ORDER_ID ='" & dID & "' and ID = '" & GF_NumIsNull(.Cells("ID").Value) & "'"
                        SqlExecuted(SQL_SCRIPT)
                End Select

            End With


        Next


    End Sub


    Private Sub DgvProductItem_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles dgvProductItem.RowsAdded
        If bRefreshItem = False Then
            Computed()
        End If
    End Sub



    Private Sub FrmSalesOrder_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If FLP_TABLE.Controls.Count = 0 And gsDINE_IN_ID <> 0 Then
            rbDINE_IN.Checked = True
        End If


        Timer1.Start()

        btnMENU.PerformClick()

    End Sub

    Private Sub CmbCUSTOMER_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.SelectedIndexChanged
        If bEntryAddItem = True Then
            Exit Sub
        End If

        If cmbCUSTOMER_ID Is Nothing Then Exit Sub
        If cmbCUSTOMER_ID.Enabled = False Then Exit Sub
        If cmbCUSTOMER_ID.Text = "" Then Exit Sub

        xlblCustomer_Name.Text = cmbCUSTOMER_ID.Text
        xlblAcctNo.Text = GF_GetStringFieldValue("CONTACT", "ID", GF_NumIsNull(cmbCUSTOMER_ID.SelectedValue), "ACCOUNT_NO")
        Dim rd As OdbcDataReader = SqlReader($"select TAX_ID from contact where id ='{GF_NumIsNull(cmbCUSTOMER_ID.SelectedValue)}' and `type` = '1' limit 1 ")
        If rd.Read Then
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            Else
                cmbOUTPUT_TAX_ID.SelectedValue = GetOutPutTaxDefault()
            End If
        End If

    End Sub


    Private Sub Discard_Sales_Order()
        If IsNew = True Then
            ClearInfo()

        Else
            If MessageBoxQuestion("Create new?") = True Then
                IsNew = True
                ID = 0
                ClearInfo()

            Else
                ClearInfo()
                RefreshInfo_sales_order(ID)
                RefreshItem_sales_order(ID)
            End If

        End If
    End Sub
    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        ShowHistoryList(ID, Me)
    End Sub

    Private Sub CmbCUSTOMER_ID_LostFocus(sender As Object, e As EventArgs) Handles cmbCUSTOMER_ID.LostFocus
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
            If GF_NumIsNull(rd("TAX_ID")) <> 0 Then
                cmbOUTPUT_TAX_ID.SelectedValue = GF_NumIsNull(rd("TAX_ID"))

            End If

        End If
        rd.Close()
    End Sub


    Private Sub TsAddItem_Click(sender As Object, e As EventArgs) Handles tsAddItem.Click
        If IsOrder = True Then
            Sales_order_add_item()
        Else
            InvoiceAddItems()
        End If


    End Sub
    Private Sub InvoiceAddItems()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Or cmbCUSTOMER_ID.SelectedValue Is Nothing Or cmbCUSTOMER_ID.Text = "" Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If

        With FrmAddItemTouchScreen
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
        Computed()
        FrmAddItemTouchScreen.Dispose()
        FrmAddItemTouchScreen = Nothing
    End Sub
    Private Sub Sales_order_add_item()
        If Val(cmbCUSTOMER_ID.SelectedValue) = 0 Then
            MessageBoxInfo("Please select customer")
            Exit Sub
        End If



        With FrmAddItemTouchScreen

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
        Computed()
        FrmAddItemTouchScreen.Dispose()
        FrmAddItemTouchScreen = Nothing
    End Sub
    Private Sub TsEditItem_Click(sender As Object, e As EventArgs) Handles tsEditItem.Click
        EditItem()
    End Sub

    Private Sub TsRemoveItem_Click(sender As Object, e As EventArgs) Handles tsRemoveItem.Click
        If dgvProductItem.Rows.Count <> 0 Then
            dgvProductItem.Select()
            GS_RemoveItems(dgvProductItem, dgvProductItem.CurrentRow.Index)
            Computed()
        End If
    End Sub



    Private Sub TsFindText_TextChanged(sender As Object, e As EventArgs) Handles tsTextFind.TextChanged
        GetQuickFind(dgvProductItem, tsTextFind.Text)
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


    Private Sub RbTAKE_OUT_CheckedChanged(sender As Object, e As EventArgs) Handles rbTAKE_OUT.CheckedChanged
        If rbTAKE_OUT.Checked = True Then

            If Ship_Via_count = 1 Then

            Else

            End If


            numTableSelected = 0
            RefreshTable()
            xxlblSalesman.Text = "SALES MAN"
        End If

    End Sub

    Private Sub RbDINE_IN_CheckedChanged(sender As Object, e As EventArgs) Handles rbDINE_IN.CheckedChanged

        If rbDINE_IN.Checked = True Then


            numTableSelected = 1
            RefreshTable()
            xxlblSalesman.Text = "SALES MAN"
        End If

    End Sub
    Private Sub CmbSALES_REP_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSALES_REP_ID.SelectedIndexChanged
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
    Private Sub BtnNEWORDER_Click(sender As Object, e As EventArgs) Handles btnNEWORDER.Click
        IsOrder = True
        ID = 0
        IsNew = True
        ClearInfo()
        LoadReference()
        ControlEnable(False)

    End Sub

    Private Sub BtnRECEIVED_ORDER_Click(sender As Object, e As EventArgs) Handles btnRECEIVED_ORDER.Click
        Dim bGot_item_Added = False
        IsOrder = False
        If dgvSalesOrder.Rows.Count <> 0 Then
            dgvSalesOrder.Select()
            FrmPOSServed.gsCUSTOMER_ID = GF_GetNumberFieldValue("sales_order", "id", dgvSalesOrder.CurrentRow.Cells(0).Value, "CUSTOMER_ID")

        Else
            If rbDINE_IN.Checked = True Then

            ElseIf rbTAKE_OUT.Checked = True Then
                numTableSelected = 0
            ElseIf rbDELIVERY.Checked = True Then
                numTableSelected = 0
            End If
            GoTo CREATE_NOW
            FrmPOSServed.gsCUSTOMER_ID = 0

        End If


        If rbDINE_IN.Checked = True Then
            FrmPOSServed.gsORDER_TYPE = gsDINE_IN_ID
        ElseIf rbTAKE_OUT.Checked = True Then
            FrmPOSServed.gsORDER_TYPE = gsTAKE_OUT_ID
        ElseIf rbDELIVERY.Checked = True Then
            FrmPOSServed.gsORDER_TYPE = gsDELIVERY_ID
        End If

        FrmPOSServed.gsTABLE_NO = numTableSelected


        FrmPOSServed.ShowDialog()
        numTableSelected = FrmPOSServed.gsTABLE_NO
        If FrmPOSServed.gsOK = True Then
CREATE_NOW:


            ID = 0
            IsNew = True
            ClearInfo()
            LoadReference()
            ControlEnable(False)

            If FrmPOSServed.dgvSELECTED.Rows.Count <> 0 Then
                bGot_item_Added = True
                Dim dgv_top As DataGridView = FrmPOSServed.dgvSELECTED
                For I As Integer = 0 To dgv_top.Rows.Count - 1
                    Dim rd As OdbcDataReader = SqlReader($"select s.*,d.description as desc_name from SALES_ORDER_ITEMS as S left outer join discount_type as d on d.id =  s.DISCOUNT_TYPE  where S.SALES_ORDER_ID='{dgv_top.Rows(I).Cells(0).Value}' and S.GROUP_LINE_ID is null order by S.LINE_NO")
                    While rd.Read
                        GS_RowDataItemInvoice(dgvProductItem, True, GF_NumIsNull(rd("ITEM_ID")), GF_NumIsNull(rd("QUANTITY")), GF_NumIsNull(rd("RATE")), GF_TextIsNull(rd("desc_name")), GF_NumIsNull(rd("DISCOUNT_TYPE")), GF_NumIsNull(rd("AMOUNT")), CBool(GF_NumIsNull(rd("TAXABLE"))), GF_NumIsNull(rd("UNIT_ID")), "A", GF_NumIsNull(rd("UNIT_BASE_QUANTITY")), GF_TextIsNull(rd("DISCOUNT_TYPE")), GF_NumIsNull(rd("ORG_AMOUNT")), GF_NumIsNull(rd("ID")), GF_TextIsNull(rd("PRICE_LEVEL_ID")), 0, CBool(GF_NumIsNull(rd("PRINT_IN_FORMS"))), 0)
                    End While
                    rd.Close()
                Next
            End If
            If FrmPOSServed.gsCUSTOMER_ID = 0 Then
                cmbCUSTOMER_ID.SelectedValue = gsPOSDefaultCustomer_ID
            Else
                cmbCUSTOMER_ID.SelectedValue = FrmPOSServed.gsCUSTOMER_ID
            End If

        End If
        FrmPOSServed.Dispose()
        FrmPOSServed = Nothing
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

    Private Sub BtnPODERDER_DETAILS_Click(sender As Object, e As EventArgs) Handles btnPODERDER_DETAILS.Click
        If dgvSalesOrder.Rows.Count = 0 Then
            MessageBoxInfo("No order process created.")
            Exit Sub
        End If
        IsOrder = True
        dgvSalesOrder.Select()
        ID = dgvSalesOrder.CurrentRow.Cells("ID").Value
        IsNew = False
        ClearInfo()
        LoadReference()
        ControlEnable(False)
    End Sub



    Private Sub BtnSAVE_Click_1(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If IsOrder = True Then

            SaveSalesOrder()
        Else
            SaveInvoice()
        End If


    End Sub

    Private Sub BtnCUSTOMER_Click_1(sender As Object, e As EventArgs) Handles btnCUSTOMER.Click
        FrmPOSContacts.gsContact_Type = 1
        FrmPOSContacts.ShowDialog()

        If FrmPOSContacts.gsOK = True Then
            GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")

            cmbCUSTOMER_ID.SelectedValue = FrmPOSContacts.gsContact_ID
        Else
            bNewContact = FrmPOSContacts.gsNewContact
        End If
        FrmPOSContacts.Dispose()
        FrmPOSContacts = Nothing

        If bNewContact = True Then
            FrmContactDetails.IsNew = True

            FrmContactDetails.ContactTypeId = 1
            FrmContactDetails.ShowDialog()
            If FrmContactDetails.gsOK = True Then
                xlblCustomer_Name.Text = ""
                xlblAcctNo.Text = ""
                GS_ComboBoxLoad(cmbCUSTOMER_ID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
                cmbCUSTOMER_ID.SelectedValue = FrmContactDetails.ID
            End If
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub BtnSALESMAN_Click_1(sender As Object, e As EventArgs) Handles btnSALESMAN.Click
        FrmPOSContacts.gsContact_Type = 2
        FrmPOSContacts.ShowDialog()

        If FrmPOSContacts.gsOK = True Then
            If FrmPOSContacts.gsContact_ID = 0 Then
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedIndex = -1
                xlblSalesRep.Text = ""
            Else
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = FrmPOSContacts.gsContact_ID
            End If
        Else
            bNewContact = FrmPOSContacts.gsNewContact
        End If
        FrmPOSContacts.Dispose()
        FrmPOSContacts = Nothing
        If bNewContact = True Then
            '   frmContactDetails.PictureBox1.Image = tsSalesRep.Image
            FrmContactDetails.IsNew = True
            FrmContactDetails.ContactTypeId = 2
            FrmContactDetails.ShowDialog()
            If FrmContactDetails.gsOK = True Then
                xlblSalesRep.Text = ""
                GS_ComboBoxLoad(cmbSALES_REP_ID, "select id,`NAME` from contact where type ='2'", "ID", "NAME")
                cmbSALES_REP_ID.SelectedValue = FrmContactDetails.ID
            End If
            FrmContactDetails.Dispose()
            FrmContactDetails = Nothing
            bNewContact = False
        End If
    End Sub

    Private Sub BtnTAX_Click(sender As Object, e As EventArgs) Handles btnTAX.Click
        FrmPOSTax.ShowDialog()
        If FrmPOSTax.gsOk = True Then
            cmbOUTPUT_TAX_ID.SelectedValue = FrmPOSTax.gsTax_Id
        End If


        FrmPOSTax.Dispose()
        FrmPOSTax = Nothing
    End Sub

    Private Sub BtnCANCEL_Click_1(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        IsNew = True
        ID = 0
        ClearInfo()
        ControlEnable(True)
    End Sub

    Private Sub BtnVIEW_DETAILS_Click(sender As Object, e As EventArgs) Handles btnVIEW_DETAILS.Click
        If dgvInvoice.Rows.Count = 0 Then
            MessageBoxInfo("No order served created.")
            Exit Sub
        End If
        IsOrder = False
        dgvInvoice.Select()
        ID = dgvInvoice.CurrentRow.Cells("ID").Value
        IsNew = False
        ClearInfo()
        LoadReference()
        ControlEnable(False)
    End Sub



    Private Sub BtnDELETE_Click(sender As Object, e As EventArgs) Handles btnDELETE.Click

        If IsOrder = True Then
            DeletSalesOrder()
        Else
            DeleteInvoice()
        End If

    End Sub
    Private Sub DeleteInvoice()
        If IsNew = False Then
            If SecurityAccessDelete(FrmInvoice) = False Then
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

                    GS_AccountJournalDelete(Val(cmbACCOUNTS_RECEIVABLE_ID.SelectedValue), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    If GF_NumIsNull(lblOUTPUT_TAX_ACCOUNT_ID.Text) <> 0 Then
                        GS_AccountJournalDelete(Val(lblOUTPUT_TAX_ACCOUNT_ID.Text), cmbLOCATION_ID.SelectedValue, 23, ID, dtpDATE.Value)
                    End If

                End If
                '================================

                SqlExecuted("delete from invoice where id ='" & ID & "' limit 1;")
                SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)

                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True
                btnCANCEL.PerformClick()
                Dim S As Integer = numTableSelected
                RefreshTable()
                GetDefaultTable(S)
                GS_CursorLoadingOn(False)
            End If


        End If

    End Sub
    Private Sub DeletSalesOrder()
        If IsNew = False Then
            If SecurityAccessDelete(FrmSalesOrder) = False Then
                Exit Sub
            End If
            'If IsClosingDate(dtpDATE.Value) = False Then
            '    Exit Sub
            'End If
            If MessageBoxQuestion(gsMessageQuestion) = True Then

                SqlExecuted("DELETE FROM sales_order_items WHERE SALES_ORDER_ID = '" & ID & "'")
                SqlExecuted("DELETE FROM sales_order WHERE ID = '" & ID & "'")
                SetTransactionLog(ID, lblCODE.Text, Me.AccessibleName, "Delete", cmbCUSTOMER_ID.SelectedValue, "", GF_NumIsNull(lblAMOUNT.Text), cmbLOCATION_ID.SelectedValue)
                ClearInfo()
                dgvProductItem.Rows.Clear()
                Computed()
                ID = 0
                IsNew = True
                btnCANCEL.PerformClick()
                Dim S As Integer = numTableSelected
                RefreshTable()
                GetDefaultTable(S)

            End If

        End If
    End Sub



    Private Sub BtnCreatePayment_Click(sender As Object, e As EventArgs) Handles btnCreatePayment.Click
        CreatePayment()
    End Sub
    Private Sub CreatePayment()
        If dgvInvoice.Rows.Count = 0 Then
            MessageBoxInfo("No Served Order found.")
            Exit Sub
        End If
        dgvInvoice.Select()
        Dim Invoice_ID As Integer

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
        Dim isPaymentClick As Boolean

        Dim ThisID As Integer
        If gsMultiMethod = False Then

            If rbDELIVERY.Checked = True Then
                FrmPOSCreatePayment.gsORDER_TYPE = gsDELIVERY_ID
            ElseIf rbDINE_IN.Checked = True Then
                FrmPOSCreatePayment.gsORDER_TYPE = gsDINE_IN_ID
            ElseIf rbTAKE_OUT.Checked = True Then
                FrmPOSCreatePayment.gsORDER_TYPE = gsTAKE_OUT_ID
            End If

            FrmPOSCreatePayment.gsTABLE_NO = S
            FrmPOSCreatePayment.gsCUSTOMER_ID = GF_GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "CUSTOMER_ID")
            FrmPOSCreatePayment.ShowDialog()

            ThisID = FrmPOSCreatePayment.gsID
            isPaymentClick = FrmPOSCreatePayment.gsOK

            FrmPOSCreatePayment.Dispose()
            FrmPOSCreatePayment = Nothing

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
            FrmPOSCreatePaymentMultiMethod.gsCUSTOMER_ID = GF_GetNumberFieldValue("INVOICE", "ID", Invoice_ID, "CUSTOMER_ID")
            FrmPOSCreatePaymentMultiMethod.ShowDialog()
            ThisID = FrmPOSCreatePaymentMultiMethod.gsID
            isPaymentClick = FrmPOSCreatePaymentMultiMethod.gsOK
            FrmPOSCreatePaymentMultiMethod.Dispose()
            FrmPOSCreatePaymentMultiMethod = Nothing


        End If



        If isPaymentClick = True Then

            GS_DoEvents()
            If gsPOSPrintOS = True Then

                If rbDINE_IN.Checked = False Then
                    PrintBill()
                    GS_DoEvents()

                    If PRINT_INVOICE_AFTER_PRINT_PAYMENT = True Then
                        PrintBill()
                    End If
                End If

            Else
                'Another tregger
                ' or screening kitchen monitoring
            End If

            If Msg_Print_Payment = True Then
                If MessageBoxPointOfSalesYesNO($"Do you want to Print {gsPayment_Print_Title.ToUpper}?") = True Then
                    PaymentReceipt(ThisID)
                End If
            End If

            GS_OpenCashDrawer()
            numTableSelected = S
            RefreshTable()
        End If

        If isPaymentClick = True Then
            GS_DoEvents()
            IsNew = True
            ID = 0
            ClearInfo()
            LoadReference()
            ControlEnable(True)
            GetDefaultTable(S)
        End If

    End Sub
    Private Sub PaymentReceipt(ByVal ThisID As Integer)

        SystemSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)

        Try


            Dim prFile_name As String = gsPayment_File_Name '' "cryPOSRestoPayment.rpt"
            Dim prPrint_Title As String = gsPayment_Print_Title '' "OFFICIAL RECEIPT"
            gscryRpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, ThisID, "id")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")
            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")


            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                FrmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
                FrmReportViewer.WindowState = FormWindowState.Normal
                FrmReportViewer.ShowDialog()
                FrmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RbDELIVERY_CheckedChanged(sender As Object, e As EventArgs) Handles rbDELIVERY.CheckedChanged
        If rbDELIVERY.Checked = True Then

            If Ship_Via_count = 1 Then

            Else

            End If

            numTableSelected = 1
            RefreshTable()
            xxlblSalesman.Text = "SALE ON"

        End If
    End Sub

    Private Sub BtnPRINTBILL_Click(sender As Object, e As EventArgs) Handles btnPRINTBILL.Click
        btnPRINTBILL.Enabled = False
        PrintBill()
        btnPRINTBILL.Enabled = True
    End Sub
    Private Sub Report_billPrint(ByVal prID As Integer)

        SystemSetDefaultPrinter(gsPOS_DEFAULT_PRINTER)
        Dim prFile_name As String = gsInvoice_File_Name
        Dim prPrint_Title As String = gsInvoice_Print_Title
        gscryRpt = New CrystalDecisions.CrystalReports.Engine.ReportDocument
        gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
        CryParameterInsertValue(gscryRpt, Val(prID), "myid")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")
        CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyTin"), "tin_number")
        CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

        If gsPOSPrintPreview = True Then
            gsToolPanelView = False
            FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
            FrmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
            FrmReportViewer.WindowState = FormWindowState.Normal
            FrmReportViewer.ShowDialog()
            FrmReportViewer.Dispose()

        Else

            gscryRpt.PrintToPrinter(1, False, 0, 0)

        End If
    End Sub
    Private Sub PrintBill()
        If dgvInvoice.Rows.Count <> 0 Then
            dgvInvoice.Select()

            Try
                Dim id As Integer = dgvInvoice.CurrentRow.Cells(0).Value
                Report_billPrint(id)
            Catch ex As Exception

            End Try


        Else

        End If
    End Sub


    Private Sub NotifyNumber()
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

            Dim SQL_R As String = $" UNION ALL (SELECT s.RECORDED_ON as `STATUS_DATE`,s.table_no as `SHIP_TO` from pos_table_served as s where s.is_active <> '0'  and  s.table_no > '{0}' and s.CASHIER_ID ='{gsCashier_ID}' and s.POS_LOG_ID ='{gsPOS_LOG_ID}' and s.ORDER_TYPE_ID = '{prORDER_Type}' order by s.ID)"

            Dim rd As OdbcDataReader = SqlReader($"select  count(*) as C from ((SELECT s.STATUS_DATE,s.SHIP_TO FROM sales_order as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{prORDER_Type}' and  s.ship_to > '0' and s.`STATUS` in('16','12') order by s.id)  UNION ALL (SELECT s.STATUS_DATE,s.SHIP_TO FROM invoice as s inner join ship_via as v on v.id = s.SHIP_VIA_ID where s.SHIP_VIA_ID = '{prORDER_Type}' and  s.ship_to > '0' and s.`STATUS` in ('13','16')  and NOT EXISTS(select o.id from sales_order_items as o inner join invoice_items as v on v.REF_LINE_ID  = o.id where v.invoice_id = s.id  ) order by s.id) {SQL_R}) as D order by D.SHIP_TO  limit {gsPOS_RESTAURANT_TABLE_NO}")
            If rd.Read Then
                N = GF_NumIsNull(rd("C"))
            End If
            rd.Close()
        End If
        Return N
    End Function
    Private Sub BtnMENU_Click(sender As Object, e As EventArgs) Handles btnMENU.Click

        If gsNO_DINEIN <> 0 Or gsNO_TAKEOUT <> 0 Or gsNO_DELIVERY <> 0 Then
            FrmPOSLogResto.gsRestoNotEmpty = True
        End If

        FrmPOSLogResto.ShowDialog()
        FrmPOSLogResto.Dispose()
        FrmPOSLogResto = Nothing

        If gsCloseCall = True Then
            Me.Close()
        Else

            ControlEnable(True)
            If rbDINE_IN.Checked = True Then
                If Ship_Via_count = 1 Then

                Else

                End If



            ElseIf rbTAKE_OUT.Checked = True Then
                If Ship_Via_count = 1 Then

                Else

                End If



            ElseIf rbDELIVERY.Checked = True Then
                If Ship_Via_count = 1 Then

                Else

                End If

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
        BtnPRINTBILL_Click(sender, e)
        btnPRINTBILL_Fake.Enabled = True
    End Sub

    Private Sub BtnCreatePayment_Fake_Click(sender As Object, e As EventArgs) Handles btnCreatePayment_Fake.Click
        BtnCreatePayment_Click(sender, e)
    End Sub

    Private Sub BtnPRINTOS_Click(sender As Object, e As EventArgs) Handles btnPRINTOS.Click
        If dgvSalesOrder.Rows.Count <> 0 Then
            dgvSalesOrder.Select()
            Dim id As Integer = dgvSalesOrder.CurrentRow.Cells(0).Value

            Dim prFile_name As String = gsSalesOrder_File_Name
            Dim prPrint_Title As String = gsSalesOrder_Print_Title

            gscryRpt = ReportDocumentOneParameterNumberOnly(prFile_name)
            CryParameterInsertValue(gscryRpt, Val(id), "myid")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyAddress"), "company_address")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("CompanyPhoneNo"), "company_phone")

            CryParameterInsertValue(gscryRpt, prPrint_Title, "invoice_type_name")

            ReportExporPDF(gscryRpt, prPrint_Title)

            If gsPOSPrintPreview = True Then
                gsToolPanelView = False
                FrmReportViewer.CrystalReportViewer1.DisplayToolbar = True
                FrmReportViewer.Text = "POS Preview " & GetDateTimeNowSql()
                FrmReportViewer.WindowState = FormWindowState.Normal
                FrmReportViewer.ShowDialog()
                FrmReportViewer.Dispose()
            Else
                gscryRpt.PrintToPrinter(1, False, 0, 0)
            End If

        Else

        End If
    End Sub

    Private Sub TsUP_Click(sender As Object, e As EventArgs) Handles tsUP.Click
        If dgvProductItem.Rows.Count = 0 Then
            Exit Sub
        End If

        dgvProductItem.Select()

        dgvProductItem.CurrentCell = dgvProductItem.Rows(CheckingGotVisibleIndex(True)).Cells("DESCRIPTION")
    End Sub

    Private Sub TsDOWN_Click(sender As Object, e As EventArgs) Handles tsDOWN.Click
        If dgvProductItem.Rows.Count = 0 Then
            Exit Sub
        End If
        dgvProductItem.Select()
        dgvProductItem.CurrentCell = dgvProductItem.Rows(CheckingGotVisibleIndex(False)).Cells("DESCRIPTION")
    End Sub
    Public Function CheckingGotVisibleIndex(ByVal isUp As Boolean) As Integer
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


    Private Sub DgvInvoice_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvInvoice.CellDoubleClick
        If btnRECEIVED_ORDER.Enabled = False Then
            Exit Sub
        End If
        dgvInvoice.Select()
        If dgvInvoice.Rows.Count <> 0 Then



            If dgvInvoice.CurrentRow.Index >= 0 Then
                With FrmPOSRestoPendingToPaid
                    .gsID = dgvInvoice.CurrentRow.Cells(0).Value
                    .ShowDialog()
                    If .gsClickOK = True Then
                        IsNew = True
                        ID = 0
                        ClearInfo()
                        LoadReference()
                        ControlEnable(True)
                        Dim S As Integer = numTableSelected
                        RefreshTable()
                        GetDefaultTable(S)

                    End If
                    .Dispose()
                End With
                FrmPOSRestoPendingToPaid = Nothing
            End If
        End If

    End Sub
End Class