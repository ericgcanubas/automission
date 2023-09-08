
Public Class FrmItem
    Public item_BS As BindingSource
    Private Sub fRefreshDataGrid()

        LoadDataGridViewBinding(dgvItem, "SELECT 
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
  m.`NAME` as `Manufacturer`,
  Format(i.Cost,2) as `Cost`,
  Format(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) as `Rate`,
   uom.`Name` as `Unit Of Measurement`,  
a_GL.`NAME` AS `G/L Account`,
  a_COGS.`NAME` AS `COGS Account`,
  a_asset.`NAME` AS `Asset Account`,
  if(i.`TAXABLE`=0,'No','Yes') AS `Tax`,
  if(i.`INACTIVE`='0','No','Yes') AS `Inactive` 

FROM
  item AS i 
  LEFT OUTER JOIN item_type_map AS itm 
    ON i.`TYPE` = itm.`ID` 
  LEFT OUTER JOIN item_group AS ig 
    ON ig.`ID` = i.`GROUP_ID` 
  LEFT OUTER JOIN item_sub_class AS isc 
    ON isc.`ID` = i.`SUB_CLASS_ID` 
  LEFT OUTER JOIN item_class AS ic 
    ON isc.`CLASS_ID` = ic.`ID` 
  LEFT OUTER JOIN stock_type_map AS stm 
    ON stm.`ID` = i.`STOCK_TYPE` 
  LEFT OUTER JOIN contact AS ctt 
    ON ctt.`ID` = i.`PREFERRED_VENDOR_ID` 
  LEFT OUTER JOIN manufacturer AS m 
    ON m.`ID` = i.`MANUFACTURER_ID` 
  LEFT OUTER JOIN  account AS a_GL
   ON a_GL.id = i.`GL_ACCOUNT_ID`
     LEFT OUTER JOIN  account AS a_COGS
   ON a_COGS.id = i.`COGS_ACCOUNT_ID`
  LEFT OUTER JOIN  account AS a_ASSET
   ON a_ASSET.id = i.`ASSET_ACCOUNT_ID` 
    LEFT OUTER JOIN `unit_of_measure` as uom 
    ON uom.`ID` = i.`BASE_UNIT_ID`
     ", item_BS)

        dgvItem.Columns(0).Visible = False

        ViewColumn(dgvItem, 3) ' 3 = for item

        fSearchload()
    End Sub


    Private Sub frmItem_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        fRefreshDataGrid()
    End Sub

    Private Sub NewRecordsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsCreate.Click

        If fACCESS_NEW_EDIT(Me, True) = False Then
            Exit Sub
        End If

        frmItemDetails.IsNew = True
        frmItemDetails.ID = 0
        frmItemDetails.dgv = dgvItem
        frmItemDetails.this_BS = item_BS
        frmItemDetails.bMain = True
        frmItemDetails.ShowDialog()
        frmItemDetails.Dispose()
        frmItemDetails = Nothing
        'fRefreshDataGrid()
    End Sub

    Private Sub dgvItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellContentClick

    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click



        ViewSwitch(dgvItem, 3) ' 3 = for item

        ViewColumn(dgvItem, 3) ' 3 = for item



    End Sub

    Private Sub EditsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        If dgvItem.Rows.Count = 0 Then
            MessageBoxInfo("data not found!")
            Exit Sub
        End If
        Try
            If fACCESS_NEW_EDIT(Me, False) = False Then
                Exit Sub
            End If
            dgvItem.Focus()
            Dim i As Integer = dgvItem.CurrentRow.Index
            Dim dID As String = dgvItem.Rows.Item(i).Cells(0).Value
            frmItemDetails.IsNew = False
            frmItemDetails.ID = dID
            frmItemDetails.dgv = dgvItem
            frmItemDetails.this_BS = item_BS
            '  frmItemDetails.this_BS = item_BS
            frmItemDetails.bMain = True
            frmItemDetails.ShowDialog()
            frmItemDetails.Dispose()
            frmItemDetails = Nothing
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

        ' fRefreshDataGrid()
    End Sub

    Private Sub dgvItem_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellContentDoubleClick

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsDelete.Click

        If dgvItem.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            dgvItem.Focus()
            Dim i As Integer = dgvItem.CurrentRow.Index
            Dim dID As String = dgvItem.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvItem.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From item where id='" & dID & "' limit 1;")
                DeleteNotify(Me)
                fRefreshDataGrid()
            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try


    End Sub

    Private Sub dgvItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellDoubleClick
        EditsToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub frmItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown

    End Sub

    Private Sub frmItem_Move(sender As Object, e As EventArgs) Handles Me.Move

    End Sub

    Private Sub ExportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportToolStripMenuItem.Click
        fExport(dgvItem, "Item_List_" & Format(DateTime.Now, "yyyy-MM-ddhhmmss"))
    End Sub

    Private Sub RefreshToolStripMenuItem_Click(sender As Object, e As EventArgs)
        fRefreshDataGrid()
    End Sub

    Private Sub tsbtnSearch_Click(sender As Object, e As EventArgs)
        'fRefreshDataGrid()

        fSearchload()

    End Sub
    Private Sub fSearchload()
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
    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub
    Private Sub dgvItem_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvItem.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count

    End Sub

    Private Sub BarcodeGeneratorToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsbtnSearch_Click_1(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        fRefreshDataGrid()
    End Sub
    Private Sub tscmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs)
        fSearchload()
    End Sub

    Private Sub BarcodeGeneratorToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BarcodeGeneratorToolStripMenuItem1.Click
        frmBarcode.dgv = dgvItem
        frmBarcode.ShowDialog()
        frmBarcode.Dispose()
        frmBarcode = Nothing
    End Sub

    Private Sub tsReports_Click(sender As Object, e As EventArgs) Handles tsReports.Click

    End Sub
End Class