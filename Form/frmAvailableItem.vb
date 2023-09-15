Imports System.Data.Odbc
Public Class FrmAvailableItem
    Public gsCONTACT_ID As String
    Public gsType As Integer
    Public gsdgv As DataGridView
    Public gsLocation_Select_ID As Double
    Public gsContact_Select_ID As Double
    Public bClickOK As Boolean = False
    Dim firstload As Boolean = True
    ' Public PO_TO_PR_ID As String
    Public PR_TO_LOC_ID As String

    Private Sub ColumnGrid()
        Dim chk_selected As New DataGridViewCheckBoxColumn With {
            .HeaderText = "  ",
            .Name = "SELECTED"
        }

        Dim chk As New DataGridViewCheckBoxColumn With {
            .HeaderText = "Tax",
            .Name = "TAX"
        }

        With dgvItem.Columns
            .Clear()
            .Add(chk_selected) '0
            .Item("SELECTED").Width = 20
            .Add("ID", "ID") ' 1
            .Item("ID").Visible = False
            .Add("CODE", "CODE") '2
            .Item("CODE").Width = 110
            .Add("DESCRIPTION", "Description") '3
            .Add("QTY", "Qty") '4        
            .Item("QTY").Width = 60
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("UM", "U/M") '5
            .Item("UM").Width = 60

            .Add("UNIT_PRICE", "Unit Price") '6
            .Item("UNIT_PRICE").Width = 50
            .Item("UNIT_PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("DISCOUNT_TYPE", "Disc. Type") '7
            .Item("DISCOUNT_TYPE").Width = 70

            .Add("DISCOUNT_RATE", "Disc. Rate") '8
            .Item("DISCOUNT_RATE").Width = 50
            .Item("DISCOUNT_RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("AMOUNT", "Amount") '9
            .Item("AMOUNT").Width = 90
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add(chk) '10
            .Item("TAX").Width = 30

            .Add("UNIT_ID", "UNIT_ID") '11
            .Item("UNIT_ID").Visible = False

            .Add("CONTROL_STATUS", "CONTROL_STATUS") '12
            .Item("CONTROL_STATUS").Visible = False

            ' Control_Status_value
            ' S - Stable
            ' A - Added
            ' E - Editted
            ' D - Deleted

            .Add("RATE_TYPE", "RATE_TYPE") '13
            .Item("RATE_TYPE").Visible = False

            .Add("UNIT_QUANTITY_BASE", "UNIT_QUANTITY_BASE") '14
            .Item("UNIT_QUANTITY_BASE").Visible = False

            .Add("DISCOUNT_ID", "DISCOUNT_ID") '15
            .Item("DISCOUNT_ID").Visible = False

            .Add("TAXABLE_AMOUNT", "TAXABLE_AMOUNT") '16
            .Item("TAXABLE_AMOUNT").Visible = False

            .Add("TAX_AMOUNT", "TAX_AMOUNT") '17
            .Item("TAX_AMOUNT").Visible = False


            .Add("ORG_AMOUNT", "ORG_AMOUNT") '18
            .Item("ORG_AMOUNT").Visible = False

            .Add("ITEM_ID", "ITEM_ID") '19
            .Item("ITEM_ID").Visible = False

            If gsType <> 0 Then
                .Add("PRICE_LEVEL_ID", "PRICE_LEVEL_ID") '20
                .Item("PRICE_LEVEL_ID").Visible = False

                .Add("GROUP_LINE_ID", "GROUP_LINE_ID") '23
                .Item("GROUP_LINE_ID").Visible = False

                .Add("ITEM_TYPE", "ITEM_TYPE") '21
                .Item("ITEM_TYPE").Visible = False

                .Add("PRINT_IN_FORMS", "PRINT_IN_FORMS") ' 22
                .Item("PRINT_IN_FORMS").Visible = False
            End If



        End With
    End Sub
    Private Sub RefreshItem()

        Dim gsID As String = "0"
        Dim sQuery As String = ""
        If dgvDocument.Rows.Count = 0 Then
            gsID = "0"
        Else

            Try
                dgvDocument.Select()

                gsID = dgvDocument.Rows(dgvDocument.CurrentRow.Index).Cells("ID").Value
            Catch ex As Exception
                gsID = dgvDocument.Rows(0).Cells("ID").Value
            End Try
        End If




        Select Case gsType
            Case 0
                sQuery = "SELECT '1' as `Selected`,
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

  purchase_order_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    WHERE  ii.`PO_ID` = '" & gsID & "' Order by ii.LINE_NO"


            Case 1
                sQuery = "SELECT '1' as `Selected`,
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
  ii.`ITEM_ID`,
  ii.`PRICE_LEVEL_ID`,
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
    WHERE  ii.`sales_order_ID` = '" & gsID & "'  Order by ii.LINE_NO"
            Case 2

                sQuery = "SELECT '1' as `Selected`,
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
  ii.`ITEM_ID`,
  ii.`PRICE_LEVEL_ID`,
  ii.`GROUP_LINE_ID`,
  i.TYPE as `ITEM_TYPE`,
  ii.PRINT_IN_FORMS
  
FROM

  estimate_items AS ii 
  LEFT OUTER JOIN item AS i 
    ON i.id = ii.`ITEM_ID` 
  LEFT OUTER JOIN unit_of_measure AS u 
    ON u.`ID` = ii.`UNIT_ID` 
  LEFT OUTER JOIN discount_type AS d 
    ON d.`ID` = ii.`DISCOUNT_TYPE` 
  LEFT OUTER JOIN rate_type_map AS rt 
    ON rt.`ID` = ii.`RATE_TYPE`
    WHERE  ii.`estimate_ID` = '" & gsID & "' Order by ii.LINE_NO"


        End Select


        dgvItem.Rows.Clear()
        Try
            Dim x As Integer = 0

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            While rd.Read


                dgvItem.Rows.Add()

                For i As Integer = 0 To rd.FieldCount - 1
                    With dgvItem.Columns(i)
                        If GF_CheckNumStandard(.Name) = True Then
                            dgvItem.Rows(x).Cells(i).Value = NumberFormatStandard(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckNumNoDecimal(.Name) = True Then
                            dgvItem.Rows(x).Cells(i).Value = NumberFormatNoDecimal(GF_NumIsNull(rd(i)))
                        ElseIf GF_CheckBoolType(.Name) = True Then
                            dgvItem.Rows(x).Cells(i).Value = CBool(GF_NumIsNull(rd(i)))
                        Else
                            dgvItem.Rows(x).Cells(i).Value = GF_TextIsNull(rd(i))
                        End If
                    End With

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
    Private Function GetTypeValue(ByVal dt As String) As String
        If IsNumeric(dt) = True Then
            Return Format(dt, "Standard")
        Else
            Return dt
        End If
    End Function
    Private Sub FrmAvailableItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GS_ComboBoxLoad(cmbLOCATION_ID, "SELECT `id`,`name` FROM location UNION SELECT '' AS `id`,'All Location' AS `NAME` FROM location ORDER BY `ID`", "ID", "NAME")
        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        gsLocation_Select_ID = cmbLOCATION_ID.SelectedValue
        firstload = False
    End Sub

    Private Sub LoadPurchaseOrder()
        dgvItem.Rows.Clear()
        Me.Text = "Select Purchase order to Bills"
        Dim l As String = ""
        Try
            l = cmbLOCATION_ID.SelectedValue
        Catch ex As Exception

        End Try
        GS_LoadDataGridView(dgvDocument, "SELECT p.ID,
  p.CODE AS `Reference`,
  p.`Date`,
  t.`Description` AS `Payment Terms`,
  p.`Date_Expected` AS `Date Expected`,
  format(p.`Amount`,2) as `Amount` 
FROM
  purchase_order AS p 
  LEFT OUTER JOIN payment_terms AS t 
    ON t.ID = p.payment_terms_id 
    INNER JOIN purchase_order_items AS pt
    ON pt.`PO_ID` = p.`ID`
WHERE pt.`CLOSED` = '0'   AND 
p.vendor_id = '" & gsCONTACT_ID & "' and p.Location_id like '%" & l & "%'
    GROUP BY p.`CODE`")

        dgvDocument.Columns(0).Visible = False

        Try
            dgvDocument.RowHeadersWidth = 30
            dgvDocument.Columns("Reference").Width = 80
            dgvDocument.Columns("Date").Width = 70
            dgvDocument.Columns("Payment Terms").Width = 150
            dgvDocument.Columns("Date Expected").Width = 100
            dgvDocument.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgvDocument.Columns("Amount").Width = 150
            RefreshItem()
        Catch ex As Exception

        End Try

    End Sub
    Private Sub LoadSalesOrder()
        dgvItem.Rows.Clear()
        Me.Text = "Select  Sales Order to Invoice"
        Dim l As String = ""
        Try
            l = cmbLOCATION_ID.SelectedValue
        Catch ex As Exception

        End Try
        GS_LoadDataGridView(dgvDocument, "SELECT p.ID,
  p.CODE AS `Reference`,
  p.`Date`,
  t.`Description` AS `Payment Terms`,
  IFNULL(s.`NAME`,'') AS `Sales Rep.`,
  format(p.`Amount`,2) as `Amount` 
FROM
  sales_order AS p 
  LEFT OUTER JOIN payment_terms AS t 
    ON t.ID = p.payment_terms_id 
    INNER JOIN sales_order_items AS pt
    ON pt.`SALES_ORDER_ID` = p.`ID`
    left outer join contact as s
    on s.id = p.SALES_REP_ID
WHERE pt.`CLOSED` = '0'   AND 
p.customer_id = '" & gsCONTACT_ID & "' and p.Location_id like '%" & l & "%'
    GROUP BY p.`CODE`")

        dgvDocument.Columns(0).Visible = False

        Try

            dgvDocument.Columns("Reference").Width = 80
            dgvDocument.Columns("Date").Width = 70
            dgvDocument.Columns("Payment Terms").Width = 150
            dgvDocument.Columns("Sales Rep.").Width = 300
            dgvDocument.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgvDocument.Columns("Amount").Width = 150
            dgvDocument.RowHeadersWidth = 30
            RefreshItem()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadEstimate()
        dgvItem.Rows.Clear()
        Me.Text = "Select  Estimate to Sales Order"
        Dim l As String = ""
        Try
            l = cmbLOCATION_ID.SelectedValue
        Catch ex As Exception

        End Try
        GS_LoadDataGridView(dgvDocument, "SELECT p.ID,
  p.CODE AS `Reference`,
  p.`Date`,
  t.`Description` AS `Payment Terms`,
  IFNULL(s.`NAME`,'') AS `Sales Rep.`,
  format(p.`Amount`,2) as `Amount` 
FROM
  estimate AS p 
  LEFT OUTER JOIN payment_terms AS t 
    ON t.ID = p.payment_terms_id 
    INNER JOIN estimate_items AS pt
    ON pt.`estimate_ID` = p.`ID`
    left outer join contact as s
    on s.id = p.SALES_REP_ID
WHERE pt.`CLOSED` = '0'   AND 
p.customer_id = '" & gsCONTACT_ID & "' and p.Location_id like '%" & l & "%'
    GROUP BY p.`CODE`")

        dgvDocument.Columns(0).Visible = False

        Try
            dgvDocument.RowHeadersWidth = 30
            dgvDocument.Columns("Reference").Width = 80
            dgvDocument.Columns("Date").Width = 70
            dgvDocument.Columns("Payment Terms").Width = 150
            dgvDocument.Columns("Sales Rep.").Width = 300
            dgvDocument.Columns("Amount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
            dgvDocument.Columns("Amount").Width = 150
            RefreshItem()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub ChangeData()
        Select Case gsType
            Case 0 'purchase to bill
                LoadPurchaseOrder()
            Case 1
                LoadSalesOrder() 'sales order to invoice
            Case 2
                LoadEstimate() 'estimate To sales order
        End Select
    End Sub
    Private Sub BtnCheckAll_Click(sender As Object, e As EventArgs)
        Dim d As DataGridView = dgvItem
        For i As Integer = 0 To d.Rows.Count - 1
            d.Rows(i).Cells(0).Value = True
        Next

    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs)
        Dim d As DataGridView = dgvItem
        For i As Integer = 0 To d.Rows.Count - 1
            d.Rows(i).Cells(0).Value = False
        Next
    End Sub
    Private Sub CmbLOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbLOCATION_ID.SelectedIndexChanged
        If firstload = False Then
            ChangeData()
        End If

    End Sub
    Private Sub CheckingAvailable(ByVal prItem_ID As Integer)



        For i As Integer = 0 To dgvItem.Rows.Count - 1
            Dim d As DataGridViewRow = dgvItem.Rows(i)
            If d.Cells("ID").Value = prItem_ID Then
                d.Cells(0).Value = False
                d.Visible = True
            End If
        Next

    End Sub
    Private Sub FrmAvailableItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ColumnGrid()

        GS_ViewNotSort(dgvItem)
        ChangeData()

        dgvItem.Columns("SELECTED").Width = 20
        RefreshItem()
    End Sub

    Private Sub DgvDocument_SelectionChanged(sender As Object, e As EventArgs) Handles dgvDocument.SelectionChanged
        RefreshItem()
    End Sub

    Private Sub BtnOk_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try


            If dgvItem.Rows.Count <> 0 Then
                Select Case gsType
                    Case 0

                        gsLocation_Select_ID = gsStorage_Location_ID
                        PR_TO_LOC_ID = cmbLOCATION_ID.SelectedValue
                    Case Else
                        gsLocation_Select_ID = cmbLOCATION_ID.SelectedValue
                End Select

                For i As Integer = 0 To dgvItem.Rows.Count - 1
                    Dim d As DataGridViewRow = dgvItem.Rows(i)
                    If CBool(d.Cells("SELECTED").Value) = True Then

                        Select Case gsType
                            Case 0
                                GS_RowDataItemBills(gsdgv, True, d.Cells("ITEM_ID").Value, d.Cells("QTY").Value, d.Cells("UNIT_PRICE").Value, d.Cells("DISCOUNT_TYPE").Value, d.Cells("DISCOUNT_RATE").Value, d.Cells("AMOUNT").Value, d.Cells("TAX").Value, d.Cells("UNIT_ID").Value, "A", Val(d.Cells("UNIT_QUANTITY_BASE").Value), d.Cells("DISCOUNT_ID").Value, Val(d.Cells("ORG_AMOUNT").Value), 0, d.Cells("ID").Value, 0)
                            Case 1

                                GS_RowDataItemInvoice(gsdgv, True, d.Cells("ITEM_ID").Value, d.Cells("QTY").Value, d.Cells("UNIT_PRICE").Value, d.Cells("DISCOUNT_TYPE").Value, d.Cells("DISCOUNT_RATE").Value, d.Cells("AMOUNT").Value, d.Cells("TAX").Value, d.Cells("UNIT_ID").Value, "A", Val(d.Cells("UNIT_QUANTITY_BASE").Value), d.Cells("DISCOUNT_ID").Value, Val(d.Cells("ORG_AMOUNT").Value), GF_NumIsNull(d.Cells("ID").Value), GF_NumIsNull(d.Cells("PRICE_LEVEL_ID").Value), GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value), CBool(GF_NumIsNull(d.Cells("PRINT_IN_FORMS").Value)), 0)

                            Case 2
                                GS_RowDataItemSalesOrder(gsdgv, True, d.Cells("ITEM_ID").Value, d.Cells("QTY").Value, d.Cells("UNIT_PRICE").Value, d.Cells("DISCOUNT_TYPE").Value, d.Cells("DISCOUNT_RATE").Value, d.Cells("AMOUNT").Value, d.Cells("TAX").Value, d.Cells("UNIT_ID").Value, "A", Val(d.Cells("UNIT_QUANTITY_BASE").Value), d.Cells("DISCOUNT_ID").Value, Val(d.Cells("ORG_AMOUNT").Value), d.Cells("ID").Value, GF_NumIsNull(d.Cells("PRICE_LEVEL_ID").Value), CBool(GF_NumIsNull(d.Cells("PRINT_IN_FORMS").Value)), GF_NumIsNull(d.Cells("GROUP_LINE_ID").Value))

                        End Select
                    End If

                Next

                bClickOK = True
                Me.Close()


            Else
                MessageBoxInfo("No item selected")
            End If
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                BtnOk_Click(sender, e)
            Else
                End
            End If
        End Try
    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class