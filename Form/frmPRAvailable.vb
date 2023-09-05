Imports System.Data.Odbc
Public Class frmPRAvailable
    Public gsFirest As Boolean = True

    Public dgv As DataGridView
    Private Sub frmPRAvailable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fCol()
        fComboBox(cmbLOCATION_ID, "SELECT ID,NAME FROM LOCATION WHERE INACTIVE='0'", "ID", "NAME")
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID


    End Sub

    Private Sub fBILL_LOAD()

        fDataGridView(dgvDocument, $"SELECT b.`ID`,b.`Date` ,b.CODE ,c.`Name` AS Vendor,l.NAME AS `From Location` FROM BILL AS b INNER JOIN CONTACT AS c ON c.ID = b.VENDOR_ID INNER JOIN LOCATION AS L ON l.ID = b.LOCATION_ID WHERE b.RECEIVED_LOCATION_ID ='{cmbLOCATION_ID.SelectedValue}' and NOT EXISTS(SELECT *  FROM stock_received_items as s inner join bill_items as i on i.id = s.bill_item_id  WHERE i.bill_id = b.ID )")
        dgvDocument.Columns(0).Visible = False

        fLoadRequest()
    End Sub
    Private Sub fCol()
        Dim chk_selected As New DataGridViewCheckBoxColumn
        chk_selected.HeaderText = "  "
        chk_selected.Name = "SELECTED"

        With dgvStock.Columns
            .Clear()
            .Add(chk_selected)

            .Add("ID", "ID")
            .Item("ID").Visible = False

            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
            .Add("CODE", "Code")
            .Add("DESCRIPTION", "Description")

            .Add("UNIT_ID", "UNIT_ID")
            .Item("UNIT_ID").Visible = False
            .Add("UNIT_BASE_QUANTITY", "UNIT_BASE_QUANTITY")
            .Item("UNIT_BASE_QUANTITY").Visible = False

            .Add("UNIT", "Unit")
            .Add("QTY", "Qty")
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            'Hiding Cost

            .Add("UNIT_COST", "UNIT_COST")
            .Item("UNIT_COST").Visible = False
            .Add("UNIT_PRICE", "UNIT_PRICE")
            .Item("UNIT_PRICE").Visible = False
        End With


    End Sub

    Private Sub fLoadRequest()

        dgvStock.Rows.Clear()

        If dgvDocument.Rows.Count = 0 Then Exit Sub
        dgvDocument.Select()

        Try


            Dim ID As Integer = dgvDocument.Rows(dgvDocument.CurrentRow.Index).Cells("ID").Value

            Dim rd As OdbcDataReader = fReader($"SELECT bl.ID,bl.ITEM_ID,i.CODE,i.PURCHASE_DESCRIPTION,bl.UNIT_ID,bl.UNIT_BASE_QUANTITY,u.SYMBOL,bl.QUANTITY,bl.RATE as `UNIT_COST`,i.RATE as `UNIT_PRICE` from BILL_ITEMS as bl inner join bill as b on b.id = bl.bill_id inner join item as i on i.id = bl.item_Id left outer join unit_of_measure as u on u.id = bl.UNIT_ID Where bl.BILL_ID = '{ID}' and NOT EXISTS (SELECT * FROM stock_received_items as r where  r.Bill_ITEM_ID = b.ID  )")
            While rd.Read
                dgvStock.Rows.Add(False, rd("ID"), rd("ITEM_ID"), rd("CODE"), rd("PURCHASE_DESCRIPTION"), fNumisNULL(rd("UNIT_ID")), fNumisNULL(rd("UNIT_BASE_QUANTITY")), fTextisNULL(rd("SYMBOL")), fNumisNULL(rd("QUANTITY")), fNumisNULL(rd("UNIT_COST")), fNumisNULL(rd("UNIT_PRICE")))
            End While
        Catch ex As Exception

        End Try
    End Sub



    Private Sub frmPRAvailable_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dgvStock.Columns
            .Item(0).Width = 30
            .Item("DESCRIPTION").Width = 500
            .Item("UNIT").Width = 60

        End With

        fBILL_LOAD()

        gsFirest = False

    End Sub

    Private Sub cmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        If gsFirest = True Then Exit Sub
        fBILL_LOAD()
    End Sub



    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If dgvStock.Rows.Count = 0 Then
            fMessageboxInfo("Item not found.")
            Exit Sub
        End If
        'Double check
        Dim T As Integer = 0
        For I As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(I)
                If .Cells(0).Value = True Then
                    T = T + 1
                End If
            End With
        Next
        If T = 0 Then
            fMessageboxInfo("Please select item.")
            Exit Sub
        End If
        For I As Integer = 0 To dgvStock.Rows.Count - 1
            With dgvStock.Rows(I)

                If .Cells(0).Value = True Then


                    fRow_Data_StockReceived(dgv, True, .Cells("ITEM_ID").Value, .Cells("QTY").Value, .Cells("UNIT_BASE_QUANTITY").Value, .Cells("UNIT_ID").Value, .Cells("UNIT_COST").Value, .Cells("UNIT_PRICE").Value, "A", .Cells("ID").Value)
                End If
            End With
        Next

        Me.Close()

    End Sub

    Private Sub dgvBILL_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvBILL_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvDocument.RowStateChanged

    End Sub

    Private Sub dgvDocument_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellContentClick

    End Sub

    Private Sub dgvDocument_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellClick
        fLoadRequest()
    End Sub

    Private Sub dgvStock_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellContentClick

    End Sub

    Private Sub dgvStock_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStock.CellClick
        If e.ColumnIndex = 0 Then
            fCheckSide(dgvStock)
        End If
    End Sub

    Private Sub btnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click

        Dim d As DataGridView = dgvStock
        If d.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To d.Rows.Count - 1
            d.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub btnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click

        Dim d As DataGridView = dgvStock
        If d.Rows.Count = 0 Then Exit Sub

        For i As Integer = 0 To d.Rows.Count - 1
            d.Rows(i).Cells(0).Value = False
        Next
    End Sub
End Class