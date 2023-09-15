Imports System.Data.Odbc
Public Class FrmRequestForm
    Public gslocation_select_Id As Double
    Public gsVendor_select_Id As Double
    Public gsPR_select_Id As Double
    Public bClickOK As Boolean = False
    Public gsFirstLoad As Boolean = True

    Private Sub FrmRequestForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_LoadDataGridView(dgvRequest, "select r.ID, r.Date, r.Code, c.name as `Vendor`, l.name as `Location`,r.location_id,r.vendor_id from purchase_request as r inner join location as l on l.id = r.location_id inner join contact as c on c.ID = r.vendor_id  WHERE r.status ='2'  ")
        dgvRequest.Columns(0).Visible = False
        dgvRequest.Columns("location_id").Visible = False
        dgvRequest.Columns("vendor_id").Visible = False
        dgvRequest.Columns("Date").Width = 100
        dgvRequest.Columns("Code").Width = 120
        dgvRequest.Columns("Vendor").Width = 500
        ' dgvRequest.Columns("Vendor").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        ' dgvRequest.Columns("Location").Width = 40

        ColumnSelected()
        gsFirstLoad = False
    End Sub


    Private Sub ColumnSelected()
        Dim chk_selected As New DataGridViewCheckBoxColumn With {
            .HeaderText = "  ",
            .Name = "SELECTED"
        }

        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = "TAX",
            .Name = "TAX"
        }

        With dgvItem.Columns
            .Clear()
            .Add(chk_selected) '9
            .Item(0).Width = 30
            '  .Add("NUMBER", "Number") ' 11


            .Add("ID", "ID") ' 0
            .Item("ID").Visible = False

            .Add("CODE", "CODE") '1
            .Item("CODE").Width = 60
            .Add("DESCRIPTION", "DESCRIPTION") '2
            .Item("DESCRIPTION").Width = 250

            .Add("QTY", "QTY") '3
            .Item("QTY").Width = 60
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("UM", "UNIT") '4
            .Item("UM").Width = 70

            .Add("UNIT_PRICE", "COST") '5
            .Item("UNIT_PRICE").Width = 50
            .Item("UNIT_PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("DISCOUNT_TYPE", "DISC. TYPE") '6
            .Item("DISCOUNT_TYPE").Width = 70
            .Add("DISCOUNT_RATE", "DISC. RATE") '7
            .Item("DISCOUNT_RATE").Width = 70
            .Item("DISCOUNT_RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("AMOUNT", "AMOUNT") '8
            .Item("AMOUNT").Width = 100
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add(chk) '9
            .Item("Tax").Width = 30

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


            .Add("ORG_AMOUNT", "ORG_AMOUNT") '17
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '18
            .Item("ITEM_ID").Visible = False

        End With
    End Sub
    Private Sub RefreshItem()
        Dim n As Integer = 0

        If dgvRequest.Rows.Count = 0 Then Exit Sub
        Try
            n = dgvRequest.CurrentRow.Index
        Catch ex As Exception

        End Try

        Dim gsID As String = dgvRequest.Rows(n).Cells("ID").Value


        Dim sQuery As String = "SELECT '0' as `Selected`,
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
  's' AS `CONTROL_STATUS`,
  rt.`ID` AS `RATE_TYPE`,
  ii.`UNIT_BASE_QUANTITY`,
  d.`ID` AS `DISCOUNT_ID`,
  ii.`TAXABLE_AMOUNT`,
  ii.`TAX_AMOUNT`,
  ii.`ORG_AMOUNT`,
  ii.`ITEM_ID`
  
FROM

  purchase_request_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    WHERE  ii.`PR_ID` = '" & gsID & "' Order by ii.LINE_NO"






        dgvItem.Rows.Clear()
        'Dim cn As New MySqlConnection(mysqlConstr)
        Try
            Dim x As Integer = 0
            ' cn.Open()
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read


                dgvItem.Rows.Add()

                For i As Integer = 0 To rd.FieldCount - 1

                    If i = 4 Or i = 6 Or i = 8 Then
                        dgvItem.Rows(x).Cells(i).Value = GetTypeValue(GF_NumIsNull(rd(i)))
                    ElseIf i = 10 Then
                        Dim b As Boolean = GF_NumIsNull(rd(i))
                        dgvItem.Rows(x).Cells(i).Value = b
                    ElseIf i = 9 Then
                        dgvItem.Rows(x).Cells(i).Value = GF_NumIsNull(rd("RATE")) * GF_NumIsNull(rd("QUANTITY"))
                    ElseIf i = 0 Then
                        dgvItem.Rows(x).Cells(i).Value = False
                    Else
                        dgvItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))

                    End If

                Next


                x += 1


            End While
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshItem()
            Else
                End
            End If
        End Try


    End Sub

    Private Sub FrmRequestForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        With dgvItem.Columns
            .Item(0).Width = 30
            .Item("CODE").Width = 80
            .Item("DESCRIPTION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .Item("QTY").Width = 40
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("QTY").DefaultCellStyle.Format = "N1"
            .Item("UM").Width = 70
            .Item("UNIT_PRICE").Width = 50
            .Item("UNIT_PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("DISCOUNT_TYPE").Width = 50
            .Item("DISCOUNT_RATE").Width = 50
            .Item("DISCOUNT_RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").Width = 80
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"

            .Item("Tax").Width = 40


        End With
        RefreshItem()
    End Sub
    Private Sub CheckingSide(ByVal d As DataGridView)
        If d.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = d.CurrentRow.Index
        d.Rows(i).Cells(0).Value = IIf(d.Rows(i).Cells(0).Value = True, False, True)
    End Sub
    Private Function GetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function

    Private Sub DgvItem_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvItem.CellClick
        If e.ColumnIndex = 0 Then
            CheckingSide(dgvItem)
        End If
    End Sub

    Private Sub BtnCheckAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
        Dim d As DataGridView = dgvItem

        For i As Integer = 0 To d.Rows.Count - 1
            d.Rows(i).Cells(0).Value = True
        Next
    End Sub

    Private Sub BtnUncheckAll_Click(sender As Object, e As EventArgs) Handles btnUncheckAll.Click
        Dim d As DataGridView = dgvItem

        For i As Integer = 0 To d.Rows.Count - 1
            d.Rows(i).Cells(0).Value = False
        Next
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try


            If dgvItem.Rows.Count <> 0 Then

                For i As Integer = 0 To dgvItem.Rows.Count - 1
                    Dim d As DataGridViewRow = dgvItem.Rows(i)

                    GS_RowDataItemPurchaseOrder(gsDGV, True, d.Cells("ITEM_ID").Value, d.Cells("QTY").Value, d.Cells("UNIT_PRICE").Value, d.Cells("DISCOUNT_TYPE").Value, d.Cells("DISCOUNT_RATE").Value, d.Cells("AMOUNT").Value, d.Cells("TAX").Value, d.Cells("UNIT_ID").Value, "A", Val(d.Cells("UNIT_QUANTITY_BASE").Value), d.Cells("DISCOUNT_ID").Value, Val(d.Cells("ORG_AMOUNT").Value), d.Cells("ID").Value)

                Next
                gslocation_select_Id = dgvRequest.CurrentRow.Cells("location_id").Value
                gsVendor_select_Id = dgvRequest.CurrentRow.Cells("vendor_id").Value
                gsPR_select_Id = dgvRequest.CurrentRow.Cells("ID").Value

                bClickOK = True
                Me.Close()


            Else
                MessageBoxInfo("No item selected")
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub DgvRequest_SelectionChanged(sender As Object, e As EventArgs) Handles dgvRequest.SelectionChanged
        If gsFirstLoad = False Then
            RefreshItem()
        End If

    End Sub

End Class