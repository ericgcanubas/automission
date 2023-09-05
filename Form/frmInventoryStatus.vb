Public Class frmInventoryStatus
    Dim dt As Date = Date.Now
    Dim sLocation_ID As String
    Public item_BS As BindingSource
    Dim FirstLoad As Boolean = True
    Dim xSQL As String

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        If Me.AccessibleName = "A" Then
            Me.Close()
        Else
            fCloseForm(Me)
        End If
    End Sub
    Private Sub fRefreshLocation()

        fTSComboBox(tscmbLocation, "SELECT `id`,`name` FROM location UNION SELECT '%' AS `id`,'All Location' AS `NAME`  ORDER BY `ID`", "ID", "NAME")

    End Sub
    Private Sub frmInventoryStatus_Load(sender As Object, e As EventArgs) Handles Me.Load
        fBackGroundImageStyle(Me)
        fRefreshLocation()
        Dim loc_value As String = gsDefault_LOCATION_ID
        tscmbLocation.ComboBox.SelectedValue = IIf(loc_value = "0", "*", loc_value)
        tscmbLocation.Enabled = fLockLocation()


        fStatusLoad()
    End Sub
    Private Sub fStatusLoad()

        Try


            sLocation_ID = tscmbLocation.ComboBox.SelectedValue
            Dim sON_HAND As String


            If sLocation_ID = "%" Then

                sON_HAND = "IFNULL((SELECT format(SUM(t1.`ENDING_QUANTITY`),0) FROM item_inventory t1
  JOIN (SELECT t0.`ITEM_ID`,t0.`LOCATION_ID`, MAX(t0.`SEQUENCE_NO`) AS SEQUENCE_NO FROM item_inventory  AS t0  GROUP BY t0.ITEM_ID,t0.`LOCATION_ID`) AS t2
    ON t1.`ITEM_ID` = t2.ITEM_ID AND  t1.LOCATION_ID = t2.LOCATION_ID AND t1.`SEQUENCE_NO` = t2.SEQUENCE_NO WHERE t1.ITEM_ID =i.`ID`),0)    as `On_Hand`"

            Else

                sON_HAND = "IFNULL((SELECT format( ifnull( ix.`ENDING_QUANTITY`,0),0) FROM item_inventory AS ix WHERE ix.item_id = i.ID AND ix.`LOCATION_ID` = '" & sLocation_ID & "' ORDER BY ix.`SOURCE_REF_DATE` DESC , ix.`ID` DESC LIMIT 1 ),0) as `On_Hand`"

            End If

            fDataGridView_Binding(dgvItem, $"Select * from (SELECT 
  i.ID,
  i.CODE AS `Code`,
  i.`PURCHASE_DESCRIPTION` AS `Purchase Description`,
{sON_HAND},
format(ip.ORDER_POINT,0) as `Order_Point`,
format(ip.ORDER_QTY,0) as `Order_Qty`,
format(ip.ORDER_LEADTIME,0) as `Order_Leadtime`,
format(ip.ONHAND_MAX_LIMIT,0) as `Onhand Max Limit`,
s.`DESCRIPTION` as `STOCK BIN`

FROM
item AS i 
left outer join item_preference as ip
on ip.ITEM_ID = i.ID and ip.LOCATION_ID  = '{tscmbLocation.ComboBox.SelectedValue}'
left outer join stock_bin as s 
on s.ID = ip.STOCK_BIN_ID
where i.inactive = '0' and i.type ='0') as  p WHERE p.On_Hand > -999999999999999999  order by p.On_Hand asc ", item_BS)

            With dgvItem
                .Columns(0).Visible = False
                ' fDataGrid_Column(dgvItem, 4)
            End With

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fStatusLoad()
            Else
                End
            End If

        End Try

        FirstLoad = False

    End Sub

    Private Sub dgvItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItem.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tscmbLocation_Click(sender As Object, e As EventArgs) Handles tscmbLocation.Click

    End Sub
    Private Sub tscmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbLocation.SelectedIndexChanged
        If FirstLoad = False Then
            fStatusLoad()

        End If
    End Sub
End Class