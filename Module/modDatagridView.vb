Imports System.Data.Odbc
Module modDatagridView
    <System.Runtime.CompilerServices.Extension()>
    Public Function DataGridViewCounting(ByVal dgv As DataGridView) As Integer
        Dim N As Integer = 0
        For I As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(I).Visible = True Then
                N += 1
            End If
        Next
        Return N
    End Function

    Public Sub StatusGridUpdateRefresh(ByVal dgv As DataGridView)
        For i As Integer = 0 To dgv.Rows.Count - 1
            With dgv.Rows(i)
                Select Case .Cells("CONTROL_STATUS").Value
                    Case "S"
                       'Do nothing
                    Case "A"
                        .Cells("CONTROL_STATUS").Value = "S"
                    Case "E"
                        .Cells("CONTROL_STATUS").Value = "S"
                    Case "D"
                        dgv.Rows.RemoveAt(i)
                End Select
            End With
        Next
    End Sub
    Public Sub CheckSide(ByVal d As DataGridView)
        If d.Rows.Count = 0 Then Exit Sub
        Dim i As Integer = d.CurrentRow.Index
        d.Rows(i).Cells(0).Value = IIf(d.Rows(i).Cells(0).Value = True, False, True)
    End Sub
    Public Sub ViewStyleColor(ByVal dgv As DataGridView)

        dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249)
        dgv.DefaultCellStyle.SelectionBackColor = Color.DarkCyan
        dgv.DefaultCellStyle.SelectionForeColor = Color.White
        dgv.BackgroundColor = SystemColors.ControlLightLight
        If dgv.RowHeadersVisible = True Then
            dgv.RowHeadersWidth = 24
            dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
        End If

    End Sub
    Public Sub ViewExpensesDisplay(ByVal dgv As DataGridView)
        ViewStyleColor(dgv)
        With dgv.Columns
            .Item("ACCOUNT").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Item("PARTICULAR").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .Item("AMOUNT").Width = 250
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("TAX").Width = 40
            .Item("TAX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Item("TAX").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Item("CLASS").Width = 100
        End With
    End Sub

    Public Sub ViewItemDisplay(ByVal dgv As DataGridView)

        With dgv
            With .Columns
                .Item("CODE").Width = IIf(gsPOS_Mode = False, 60, 50)
                .Item("DESCRIPTION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
                .Item("DESCRIPTION").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                If gsPOS_Mode = True Then
                    .Item("DESCRIPTION").Width = 160
                End If
                If .Contains("QTY") = True Then
                    .Item("QTY").Width = IIf(gsPOS_Mode = False, 30, 25)
                    .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("QTY").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
                If .Contains("QUANTITY") = True Then
                    .Item("QUANTITY").Width = 40
                    .Item("QUANTITY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("QUANTITY").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

                End If

                If .Contains("UM") = True Then
                    .Item("UM").Width = IIf(gsPOS_Mode = False, 30, 25)
                End If
                If .Contains("UNIT_DESCRIPTION") = True Then
                    .Item("UNIT_DESCRIPTION").Width = 50
                End If

                Dim GotCost As Boolean = False


                If .Contains("UNIT_COST") = True Then
                    GotCost = True
                    If .Item("UNIT_COST").Visible = True Then
                        .Item("UNIT_COST").Width = 50
                        .Item("UNIT_COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("UNIT_COST").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("UNIT_COST").DefaultCellStyle.Format = "N2"
                    End If

                End If

                If .Contains("RATE") = True Then
                    .Item("RATE").Width = 50
                    .Item("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("RATE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("RATE").DefaultCellStyle.Format = "N2"
                End If

                If .Contains("UNIT_PRICE") = True Then
                    If .Item("UNIT_PRICE").Visible = True Then
                        If GotCost = True Then
                            .Item("UNIT_PRICE").Width = 50
                        Else
                            .Item("UNIT_PRICE").Width = IIf(gsPOS_Mode = False, 40, 40)

                        End If

                        .Item("UNIT_PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("UNIT_PRICE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("UNIT_PRICE").DefaultCellStyle.Format = "N2"
                    End If

                End If

                If .Contains("DISCOUNT_TYPE") = True Then

                    .Item("DISCOUNT_TYPE").Width = IIf(gsPOS_Mode = False, 50, 25)
                    .Item("DISCOUNT_TYPE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Item("DISCOUNT_TYPE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    .Item("DISCOUNT_TYPE").DefaultCellStyle.WrapMode = DataGridViewTriState.True

                    .Item("DISCOUNT_RATE").Width = IIf(gsPOS_Mode = False, 50, 30)
                    .Item("DISCOUNT_RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("DISCOUNT_RATE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("DISCOUNT_RATE").DefaultCellStyle.Format = "N2"
                End If
                If .Contains("AMOUNT") = True Then
                    If .Item("AMOUNT").Visible = True Then
                        .Item("AMOUNT").Width = IIf(gsPOS_Mode = False, 60, 55)
                        .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("AMOUNT").DefaultCellStyle.Format = "N2"
                    End If
                End If



                If .Contains("RETAIL_VALUE") = True Then
                    .Item("RETAIL_VALUE").Width = 80
                    .Item("RETAIL_VALUE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("RETAIL_VALUE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    .Item("RETAIL_VALUE").DefaultCellStyle.Format = "N2"
                End If

                If .Contains("TAX") = True Then
                    If .Item("TAX").Visible = True Then
                        .Item("TAX").Width = 30
                        .Item("TAX").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        .Item("TAX").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If

                End If
                If .Contains("FINAL_QTY") = True Then
                    If .Item("FINAL_QTY").Visible = True Then
                        .Item("FINAL_QTY").Width = 50
                        .Item("FINAL_QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                        .Item("FINAL_QTY").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                    End If

                End If
                If .Contains("CLOSED") = True Then
                    .Item("CLOSED").Width = 60
                End If

                If .Contains("CLASS") = True Then
                    .Item("CLASS").Width = 100
                End If


                If .Contains("BATCH_NO") = True Then
                    .Item("BATCH_NO").Width = 100
                End If

            End With

        End With
    End Sub
    Public Function CheckBoolType(ByVal Txt As String) As Boolean
        Select Case Txt.ToUpper
            Case "SELECTED"
                Return True
            Case "PRINT_IN_FORMS"
                Return True
            Case "TAX"

                Return True
            Case "CLOSED"
                Return True
            Case Else
                Return False

        End Select
    End Function
    Public Function CheckNumNoDecimal(ByVal Txt As String) As Boolean
        Select Case Txt.ToUpper
            Case "QTY"
                Return True
            Case "QUANTITY"
                Return True
            Case "FINAL_QTY"
                Return True
            Case "DISCOUNT_RATE"
                Return True
            Case "BATCH_ID"
                Return True
            Case Else
                Return False

        End Select
    End Function
    Public Function CheckNumStandard(ByVal Txt As String) As Boolean
        Select Case Txt.ToUpper
            Case "AMOUNT"

                Return True
            Case "RETAIL_VALUE"

                Return True

            Case "UNIT_RATE"

                Return True
            Case "UNIT_PRICE"
                Return True
            Case "UNIT_COST"

                Return True
            Case "DISC_RATE"

                Return True
            Case Else

                Return False

        End Select



    End Function
    Public Sub DatagridViewMode(ByVal dgv As DataGridView)
        Exit Sub
        If dgv.RowHeadersVisible = False Then Exit Sub
        dgv.RowHeadersVisible = False
        dgv.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv.MultiSelect = False
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.EditMode = DataGridViewEditMode.EditProgrammatically
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.ColumnHeadersHeight = 50
        dgv.AllowUserToResizeColumns = False
        dgv.AllowUserToResizeRows = False
        ViewStyleColor(dgv)
        AddHandler dgv.CellPainting, AddressOf CellPainting
    End Sub
    Public Sub ViewNotSort(ByVal dgv As DataGridView)
        ViewStyleColor(dgv)
        dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
        dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.Raised
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize

        dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgv.ColumnHeadersHeight = 40

        dgv.RowHeadersVisible = False

        ' dgv.ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 10, FontStyle.Regular)
        For i As Integer = 0 To dgv.Columns.Count - 1
            With dgv.Columns.Item(i)
                .SortMode = DataGridViewColumnSortMode.NotSortable
            End With
        Next
    End Sub
    Public Function ColumnViews(ByVal dgv As DataGridView) As Integer
        Dim C As Integer = 0
        For i As Integer = 0 To dgv.Columns.Count - 1
            If dgv.Columns(i).Visible = True Then
                C = i
                Exit For
            End If
        Next
        Return C
    End Function
    Public Sub CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs)
        If e.RowIndex < 0 Then
        End If
    End Sub
    Public Sub BindingViewUpdate(ByVal dgv As DataGridView, ByVal xSQL As String, ByVal gsNew As Boolean, ByVal this_BS As BindingSource)
        Try

            Dim rd As OdbcDataReader = SqlReader(xSQL)

            If rd.Read Then

                If gsNew = True Then

                    Dim dt As New DataTable
                    dt = CType(this_BS.DataSource, DataTable)
                    Dim DRow As DataRow = dt.NewRow()
                    For i As Integer = 0 To rd.FieldCount - 1
                        If IsDBNull(rd(i)) = True Then
                            '
                            DRow(i) = System.DBNull.Value
                        ElseIf IsNumeric(rd(i)) = True Then

                            DRow(i) = NumIsNull(rd(i))

                            If Int(rd(i)) = True Then
                                DRow(i) = NumIsNull(rd(i))
                            Else
                                DRow(i) = rd(i)
                            End If
                        Else
                            DRow(i) = TextIsNull(rd(i))
                        End If

                    Next
                    dt.Rows.Add(DRow)
                    dt.AcceptChanges()
                    this_BS.Position = dgv.Rows.Count - 1
                Else

                    For i As Integer = 0 To rd.FieldCount - 1

                        If IsDBNull(rd(i)) = True Then
                            '
                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = System.DBNull.Value
                        ElseIf IsNumeric(rd(i)) = True Then

                            If Int(rd(i)) = True Then
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = NumIsNull(rd(i))
                            Else
                                dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = TextIsNull(rd(i))
                            End If
                        Else
                            dgv.Rows(dgv.CurrentRow.Index).Cells(i).Value = TextIsNull(rd(i))
                        End If
                    Next

                    this_BS.Position = dgv.CurrentRow.Index
                End If

            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
End Module
