Public Class FrmFindItem
    Dim dt As Date = Date.Now
    Dim sLocation_ID As String
    Public item_BS As BindingSource
    Dim FirstLoad = True
    Dim xSQL As String
    Private Sub RefreshLocation()

        GS_TSComboBoxLoad(tscmbLocation, "SELECT `id`,`name` FROM location UNION SELECT '%' AS `id`,'All Location' AS `NAME`  ORDER BY `ID`", "ID", "NAME")

    End Sub
    Private Sub RefreshData()

        Try
            sLocation_ID = tscmbLocation.ComboBox.SelectedValue
            Dim sON_HAND As String
            If sLocation_ID = "%" Then

                sON_HAND = "( SELECT
	format( SUM( t1.`ENDING_QUANTITY` ), 0 ) 
	FROM
		item_inventory t1
		JOIN (
		SELECT
			t0.`ITEM_ID`,
			t0.`LOCATION_ID`,
			MAX( t0.`SEQUENCE_NO` ) AS SEQUENCE_NO 
		FROM
			item_inventory AS t0 
		GROUP BY
			t0.ITEM_ID,
			t0.`LOCATION_ID` 
		) AS t2 ON t1.`ITEM_ID` = t2.ITEM_ID 
		AND t1.LOCATION_ID = t2.LOCATION_ID 
		AND t1.`SEQUENCE_NO` = t2.SEQUENCE_NO 
	WHERE
	t1.ITEM_ID = i.`ID` 
	) AS `On Hand`"

            Else

                sON_HAND = "( SELECT
	format( ix.`ENDING_QUANTITY`, 0 ) 
	FROM
		item_inventory AS ix 
	WHERE
		ix.item_id = i.ID 
		AND ix.`LOCATION_ID` = '" & sLocation_ID & "' 
	ORDER BY
		ix.`SOURCE_REF_DATE` DESC,
		ix.`ID` DESC 
	LIMIT 1 
	) AS `On Hand`"

            End If

            GS_LoadDataGridViewBinding(dgvItem, "SELECT
	i.ID,
	i.CODE AS `Code`,
	i.`DESCRIPTION` AS `Description`,
	i.`PURCHASE_DESCRIPTION` AS `Purchase Description`,
	itm.`DESCRIPTION` AS `Type`,
	ig.`DESCRIPTION` AS `Group`,
	ic.`DESCRIPTION` AS `Class`,
	isc.`DESCRIPTION` AS `Sub Class`,
	stm.`DESCRIPTION` AS `Stock Type`,
	ctt.`NAME` AS `Vendor`,
	m.`NAME` AS `Manufacturer`,
	" & sON_HAND & ",
	Format( i.Cost, 2 ) AS `Cost`,
	Format(
	IF
		(
			i.`TYPE` = 6,(
			SELECT
				SUM(
				IF
					(
						t.`TYPE` IN ( '0', '2', '3', '4' ),
						c.`RATE`,
					IF
					( t.`TYPE` = 7,- c.`RATE`, 0 ))) 
			FROM
				item_components AS c
				INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` 
			WHERE
				c.ITEM_ID = i.ID 
			),
			i.`RATE` 
		),
		2 
	) AS `Rate`,
	uom.`Name` AS `Unit Of Measurement`,
	a_GL.`NAME` AS `G/L Account`,
	a_COGS.`NAME` AS `COGS Account`,
	a_asset.`NAME` AS `Asset Account`,
IF
	( i.`TAXABLE` = 0, 'No', 'Yes' ) AS `Tax`,
IF
	( i.`INACTIVE` = '0', 'No', 'Yes' ) AS `Inactive` 
FROM
	item AS i
	LEFT OUTER JOIN item_type_map AS itm ON i.`TYPE` = itm.`ID`
	LEFT OUTER JOIN item_group AS ig ON ig.`ID` = i.`GROUP_ID`
	LEFT OUTER JOIN item_sub_class AS isc ON isc.`ID` = i.`SUB_CLASS_ID`
	LEFT OUTER JOIN item_class AS ic ON isc.`CLASS_ID` = ic.`ID`
	LEFT OUTER JOIN stock_type_map AS stm ON stm.`ID` = i.`STOCK_TYPE`
	LEFT OUTER JOIN contact AS ctt ON ctt.`ID` = i.`PREFERRED_VENDOR_ID`
	LEFT OUTER JOIN manufacturer AS m ON m.`ID` = i.`MANUFACTURER_ID`
	LEFT OUTER JOIN account AS a_GL ON a_GL.id = i.`GL_ACCOUNT_ID`
	LEFT OUTER JOIN account AS a_COGS ON a_COGS.id = i.`COGS_ACCOUNT_ID`
	LEFT OUTER JOIN account AS a_ASSET ON a_ASSET.id = i.`ASSET_ACCOUNT_ID`
	LEFT OUTER JOIN `unit_of_measure` AS uom ON uom.`ID` = i.`BASE_UNIT_ID` 
WHERE
	i.inactive = '0'
    ", item_BS)

            With dgvItem
                .Columns(0).Visible = False
                ViewColumn(dgvItem, 4)
            End With
            Searchload()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshData()
            Else
                End
            End If
        End Try
        ' 4 = for find item

    End Sub
    Private Sub FrmFindItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm

        RefreshLocation()

        Dim loc_value As String = gsDefault_LOCATION_ID
        tscmbLocation.ComboBox.SelectedValue = IIf(loc_value = "0", "*", loc_value)
        tscmbLocation.Enabled = IsLockLocation()

        DataLoad()
    End Sub

    Private Sub TstxtFindItem_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            RefreshData()
        ElseIf e.KeyCode = Keys.Down Then
            If dgvItem.Rows.Count <> 0 Then
                dgvItem.Focus()
            End If
        End If
    End Sub
    Private Sub ItemSelected()
        If dgvItem.Rows.Count = 0 Then Exit Sub
        If Me.AccessibleName = "A" Then
            Me.AccessibleDescription = dgvItem.Rows(dgvItem.CurrentRow.Index).Cells(0).Value
            Me.Close()
        Else
            EditItem()
        End If
    End Sub
    Private Sub DgvItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellDoubleClick
        ItemSelected()
    End Sub
    Private Sub FrmFindItem_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.AccessibleDescription = "" Then
            Me.AccessibleDescription = "cancel"
        End If
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ViewSwitch(dgvItem, 4)
        ViewColumn(dgvItem, 4) ' 4 = for find item
    End Sub

    Private Sub TsbtnSearch_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        RefreshData()
    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EditsToolStripMenuItem.Click
        EditItem()
    End Sub
    Private Sub EditItem()
        If dgvItem.Rows.Count = 0 Then
            MessageBoxInfo("data not found!")
            Exit Sub
        End If
        Try
            If SecurityAccessMode(FrmItem, False) = False Then
                Exit Sub
            End If

            dgvItem.Focus()
            Dim i As Integer = dgvItem.CurrentRow.Index
            Dim dID As String = dgvItem.Rows.Item(i).Cells(0).Value

            FrmItemDetails.IsNew = False
            FrmItemDetails.dgv = dgvItem
            FrmItemDetails.this_BS = item_BS
            FrmItemDetails.ID = dID
            FrmItemDetails.bMain = False
            FrmItemDetails.ShowDialog()
            FrmItemDetails.Dispose()
            FrmItemDetails = Nothing
            'RefreshData()
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub DataLoad()

        Try

            If Me.AccessibleName = "A" Then
                tsItem.Visible = True
            End If

            RefreshData()
            dgvItem.ColumnHeadersHeight = 35
            dgvItem.Visible = True
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

        FirstLoad = False
    End Sub
    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If dgvItem.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessDelete(FrmItem) = False Then
                Exit Sub
            End If
            dgvItem.Focus()
            Dim i As Integer = dgvItem.CurrentRow.Index
            Dim dID As String = dgvItem.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvItem.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From item where id='" & dID & "'")
                RefreshData()

            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub DgvItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            ItemSelected()
        ElseIf (e.KeyCode = Keys.I AndAlso e.Modifiers = Keys.Control) Then
            If dgvItem.Rows.Count <> 0 Then
                InventoryVDetailsQuickView(dgvItem.CurrentRow.Cells("ID").Value, tscmbLocation.ComboBox.SelectedValue, gsBusinessDateStart, "")
            End If

        ElseIf (e.KeyCode = Keys.U AndAlso e.Modifiers = Keys.Control) Then
            If dgvItem.Rows.Count <> 0 And gsAdmin_User = True Then
                FrmSelectDate.ShowDialog()
                If FrmSelectDate.gsOK = True Then

                    'ReCalculateInventory(dgvItem.CurrentRow.Cells("ID").Value, tscmbLocation.ComboBox.SelectedValue, FrmSelectDate.dtpSelect.Value)


                End If
                FrmSelectDate.Dispose()
                FrmSelectDate = Nothing
            End If
        End If
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        RefreshData()
    End Sub
    Private Sub DgvItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItem.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub Searchload()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvItem.Columns.Count - 1
                If dgvItem.Columns(I).Visible = True Then
                    If I < 11 And I > 0 Then
                        If strFInd = "" Then
                            strFInd = $"[{dgvItem.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvItem.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        End If

                    End If
                End If
            Next
            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        Searchload()
    End Sub

    Private Sub TscmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbLocation.SelectedIndexChanged
        If FirstLoad = False Then
            RefreshData()
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        ExportingExcel(dgvItem, "Item_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub
    Private Sub TscmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs)
        Searchload()
    End Sub

    Private Sub BarcodeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BarcodeToolStripMenuItem.Click
        frmBarcode.dgv = dgvItem
        frmBarcode.ShowDialog()
        FrmBarcode.Dispose()
        FrmBarcode = Nothing
    End Sub

    Private Sub AddToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AddToolStripMenuItem.Click
        If SecurityAccessMode(FrmItem, True) = False Then
            Exit Sub
        End If
        FrmItemDetails.IsNew = True
        FrmItemDetails.ID = 0
        FrmItemDetails.dgv = dgvItem
        FrmItemDetails.this_BS = item_BS
        FrmItemDetails.bMain = False
        FrmItemDetails.ShowDialog()
        FrmItemDetails.Dispose()
        FrmItemDetails = Nothing
    End Sub
End Class