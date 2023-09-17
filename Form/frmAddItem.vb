Imports System.Data.Odbc
Public Class FrmAddItem


    Dim BS_ITEM As BindingSource
    Dim ItemType As Integer
    Dim gsRate_Type As Integer
    Dim DISC_NAME As String
    Public gsUseItemBatch As Boolean = False
    Public gsNON_DISCOUNTED_ITEM As Boolean = False
    Public gsNON_PORFOLIO_COMPUTATION As Boolean = False
    Public gsNonInventoryItem As Boolean = True
    Public gsNew As Boolean = False
    Dim f As Form = New FrmFindItem
    Public gsCOST_AMOUNT_ONLY As Boolean = False
    Public gsMEMBER As Boolean = False
    Public gsMEMEBER_DISCOUNT As Double = 0
    Public dgv As DataGridView
    Public gscmbOUTPUT_TAX_ID As ComboBox
    Public gslblOUTPUT_TAX_AMOUNT As Label
    Public gslblAMOUNT As Label
    Public gslblTAXABLE_AMOUNT As Label
    Public gslblNONTAXABLE_AMOUNT As Label
    Public gslblOUTPUT_TAX_RATE As Label
    Public gsSalesSubTotal As Double


    Public sFormName As String = ""
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer
    Public gsTotalSales As Double

    Public gsPRICE_LEVEL_ID As String
    Public gsBATCH_ID As Integer
    Dim gsGotExpired As Boolean
    Dim gsExpired_Date As Date
    Public gsSelection As Boolean = False
    Public gsSelection_Query As String = ""
    Public gsSelection_VALUE As String = ""
    Public gsSelection_DESCRIPTION As String = ""
    Public gsSelection_ID As String = ""
    Public gsSelection_Label As String = ""

    Public gsSave As Boolean = False
    Public gsItem_ID As String
    Public gsItem_Description As String
    Public gsQty As String
    Public gsUM As String
    Public gsUnit_Price As Double
    Public gsDiscount_Type As String
    Public gsDiscount_Rate As String
    Public gsAmount As Double
    Public gsOriginal_Amount As Double
    Public gsTax As Boolean
    Public gsBase_Qty As Double

    Public gsLOCATION_ID As Integer
    Public gsDate As Date = Date.Now
    Dim Basic_Unit_ID As Integer = 0
    Dim _Unit_Rate As Double

    Private Sub MasterKeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Enter Then
            If dgvSearch.Visible = True Then
                DgvSearch_KeyDown(sender, e)
                If cmbItem_Code.SelectedValue <> 0 Then
                End If
            ElseIf txtSearch.Focused = True Then

                If cmbItem_Code.SelectedValue <> 0 Then
                    If numQty.Enabled = True Then
                        numQty.Select()
                    ElseIf cmbUM.Items.Count <> 0 And cmbUM.Enabled = True Then
                        cmbUM.Select()
                    ElseIf numUnit_price.Enabled = True Then
                        numUnit_price.Select()
                    Else
                        btnOK.Select()
                    End If
                End If

            ElseIf numQty.Focused = True Then
                If cmbUM.Items.Count <> 0 And cmbUM.Enabled = True Then

                    cmbUM.Select()

                ElseIf numUnit_price.Enabled = True Then
                    numUnit_price.Select()
                Else
                    btnOK.Select()
                End If
            ElseIf cmbUM.Focused = True Then

                If numUnit_price.Enabled = True Then
                    numUnit_price.Select()
                ElseIf cmbDiscount_Type.Enabled = True Then
                    numDiscountValue.Select()
                Else
                    btnOK.Select()
                End If

            ElseIf numUnit_price.Focused = True Then
                If cmbDiscount_Type.Enabled = True Then
                    cmbDiscount_Type.Select()
                Else
                    btnOK.Select()
                End If
            ElseIf cmbDiscount_Type.Focused = True Then
                If numDiscountValue.Enabled = True Then
                    numDiscountValue.Select()

                Else
                    btnOK.Select()
                End If

            ElseIf numDiscountValue.Focused = True Then

                btnOK.Select()

            Else

                btnOK.Focus()

            End If

        ElseIf e.KeyCode = Keys.Down Or e.KeyCode = Keys.Up Then
            If dgvSearch.Visible = True Then

                dgvSearch.Focus()
            End If


        ElseIf e.KeyCode = Keys.Escape Then
            If txtSearch.Visible = False Then
                btnClose.PerformClick()
            Else


                If dgvSearch.Visible = False And txtSearch.Focused = True Then
                    btnClose.PerformClick()


                End If
                dgvSearch.Visible = False
                txtSearch.Focus()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            btnOK.PerformClick()
        Else
            If dgvSearch.Focused = True Then
                txtSearch.Focus()
            End If


        End If
    End Sub
    Private Function IsItemOnHand(ByVal prITEM_ID As Integer, ByVal prDESCRIPTION As String, ByVal prQTY As Double) As Boolean
        Dim bON_HAND As Boolean = True
        Dim iQty As Double = QtyActualOnDateLocation(prITEM_ID, gsDate, gsLOCATION_ID)
        Dim nQTY As Double = (numQty.Value * IIf(Val(lblQty_Base.Text) = 0, 1, Val(lblQty_Base.Text))) + GetQtyFromView(prITEM_ID)
        If iQty - nQTY <= -1 Then
            MessageBoxExclamation($"Not allowed negative inventory on  {prDESCRIPTION}. { Environment.NewLine} { Environment.NewLine} Sorry, unable to proceed.")
            bON_HAND = False
        End If

        Return bON_HAND
    End Function

    Private Function GetQtyFromView(ByVal prITEM_ID As Integer) As Double
        Dim qty As Double = 0
        For I As Integer = 0 To dgv.Rows.Count - 1
            If dgv.Rows(I).Cells("ITEM_ID").Value = prITEM_ID Then
                qty += (dgv.Rows(I).Cells("QTY").Value * Val(dgv.Rows(I).Cells("UNIT_QUANTITY_BASE").Value))
            End If
        Next
        Return qty
    End Function
    Private Sub ClearAllFromForm()
        gsItem_ID = ""
        gsUnit_Price = 0
        gsDiscount_Rate = ""
        gsAmount = 0
        gsTax = 0
        gsBase_Qty = 0
        gsOriginal_Amount = 0
        gsSelection_ID = ""
        numUnit_price.Value = 0
        numQty.Value = 0
        numDiscountValue.Value = 0
        _Unit_Rate = 0
        Basic_Unit_ID = 0
        dtpDateExpired.Checked = False
        dtpDateExpired.Visible = False
        xlblExpired.Visible = False

        If gsUseImageProduct = True Then
            picItem.Image = Nothing
        End If
        Dim lbl1 As String = xlblLabel_Amount.Text
        Dim lbl2 As String = xlblnum_price.Text
        Dim lbl3 As String = xlblSelection.Text

        ClearAndRefresh(Me)
        xlblOnHand.Text = ""

        cmbUM.DataSource = Nothing
        xlblLabel_Amount.Text = lbl1
        xlblnum_price.Text = lbl2
        xlblSelection.Text = lbl3
        MemberDiscounted()
        numQty.Value = 1
        dgvSearch.Visible = False

        Try
            If cmbUM.SelectedValue = 0 Then

            Else
                txtSearch.Focus()
            End If

        Catch ex As Exception

        End Try
        cmbItem_Code.Enabled = False
        cmbItem_DESCRIPTION.Enabled = False
        numUnit_price.Enabled = gsUserPriceLock
        numQty.Enabled = True
    End Sub
    Private Function GetTotal(ByVal dgv As DataGridView) As Double
        Dim TotalAmount As Double = 0

        For i As Integer = 0 To dgv.Rows.Count - 1
            With dgv.Rows(i)
                If .Visible = True Then

                    Select Case .Cells("ITEM_TYPE").Value
                        Case 4 ' OTHER CHARGE
                            TotalAmount = 0
                        Case 5 ' SUB
                            TotalAmount = NumberFormatFixed(.Cells("AMOUNT").Value)
                        Case 6 ' GROUP

                        Case 7 ' DISCOUNT
                            TotalAmount = 0
                        Case Else
                            TotalAmount += NumberFormatFixed(.Cells("AMOUNT").Value)
                    End Select

                End If

            End With
        Next

        Return TotalAmount
    End Function

    Private Sub ItemComputation()
        Try
            If lblAmount.Visible = False Then
                Exit Sub
            End If

            If Trim(cmbDiscount_Type.Text) <> "" Then

                gsOriginal_Amount = numUnit_price.Value * numQty.Value
                Select Case cmbDiscount_Type.SelectedValue
                    Case 0
                        gsAmount = gsOriginal_Amount - numDiscountValue.Value
                    Case 1
                        Dim DISCOUNT_LESS As Double = gsOriginal_Amount * IIf(numDiscountValue.Value < 100, CDbl(0 & "." & Format(numDiscountValue.Value, "00")), 1)
                        gsAmount = gsOriginal_Amount - DISCOUNT_LESS
                    Case Else
                        gsAmount = gsOriginal_Amount
                End Select
            Else
                gsOriginal_Amount = numUnit_price.Value * numQty.Value
                gsAmount = gsOriginal_Amount
            End If

            lblAmount.Text = NumberFormatStandard(gsAmount)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub FrmAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsUseImageProduct = True Then
            Me.Size = New Size(824, 286)
            Me.Top = 0
            Me.Left = 0

        Else
            Me.Size = New Size(589, 286)
        End If
        dgvSearch.Size = New Size(563, 212)
        If gsCOST_AMOUNT_ONLY = False Then
            GS_ComboBoxLoad(cmbItem_Code, gsItemCodeQuery, "ID", "CODE")
            GS_ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionQuery, "ID", "DESCRIPTION")
            GS_LoadDataGridViewBinding(dgvSearch, gsItemSearchQuery, BS_ITEM)

            dgvSearch.Columns("GROUP").Width = 50
            dgvSearch.Columns("RATE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("RATE").Width = 40
            dgvSearch.Columns("RATE").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        ElseIf gsCOST_AMOUNT_ONLY = True And (sFormName = FrmStockTransfer.Name Or sFormName = FrmInventoryAdjustment.Name) Then
            GS_ComboBoxLoad(cmbItem_Code, gsItemCodeZeroQuery, "ID", "CODE")
            GS_ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionZeroQuery, "ID", "DESCRIPTION")
            GS_LoadDataGridViewBinding(dgvSearch, gsItemSearchZeroQuery, BS_ITEM)

            '  dgvSearch.Columns(2).Width = 200
            dgvSearch.Columns(3).Width = 60
            dgvSearch.Columns("COST").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("COST").Width = 60
            dgvSearch.Columns("COST").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        Else
            GS_ComboBoxLoad(cmbItem_Code, gsItemCodeCostQuery, "ID", "CODE")
            GS_ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionCostQuery, "ID", "DESCRIPTION")
            GS_LoadDataGridViewBinding(dgvSearch, gsItemSearchCostQuery, BS_ITEM)

            ' dgvSearch.Columns(2).Width = 250
            dgvSearch.Columns(3).Width = 80
            dgvSearch.Columns("UNIT").Width = 20
            dgvSearch.Columns("COST").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("COST").Width = 40

            dgvSearch.Columns("COST").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        End If

        dgvSearch.Columns(0).Visible = False
        dgvSearch.Columns(1).Width = 90
        GS_ComboBoxLoad(cmbDiscount_Type, " select '' as ID, '' as DESCRIPTION  FROM discount_type  UNION select ID,DESCRIPTION FROM discount_type ", "ID", "DESCRIPTION")

        ClearAndRefresh(Me)
        If gsItem_ID <> "" Then
            cmbItem_Code.SelectedValue = gsItem_ID
            cmbItem_DESCRIPTION.SelectedValue = gsItem_ID
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
            FindItemToolStripMenuItem.Enabled = False
            txtSearch.Visible = False
            xlblSearch.Visible = False

            CmbItem_Code_LostFocus(sender, e)

            Me.Text = "Edit Item"
            sFormName = ""
        Else
            Me.Text = "Add Item"
        End If

        If lblAmount.Visible = False Then
            xlblnum_price.Text = "New Value :"
        End If

        If Trim(cmbItem_Code.Text) <> "" Then

            cmbUM.SelectedValue = Val(gsUM)
            If gsCOST_AMOUNT_ONLY = False Then
                If cmbPRICE_LEVEL.SelectedValue = gsPRICE_LEVEL_ID Then
                    cmbPRICE_LEVEL.SelectedValue = Val(gsPRICE_LEVEL_ID)

                Else

                    If Val(gsUM) <> 0 Then
                        CheckPriceLevelUnits(gsItem_ID, gsUM)
                        cmbPRICE_LEVEL.SelectedValue = Val(gsPRICE_LEVEL_ID)
                    End If

                End If
            End If
            numQty.Value = gsQty
            numUnit_price.Value = gsUnit_Price
            chkTax.Checked = gsTax
            If gsDiscount_Type <> "" Then
                cmbDiscount_Type.SelectedValue = gsDiscount_Type
            End If

            If Trim(cmbDiscount_Type.Text) <> "" Then
                numDiscountValue.Value = gsDiscount_Rate
            End If

            GS_GetExpiration(gsBATCH_ID, gsItem_ID, gsExpired_Date, gsGotExpired)
            dtpDateExpired.Checked = gsGotExpired
            If dtpDateExpired.Checked = True Then
                dtpDateExpired.Value = gsExpired_Date
            End If

            ItemComputation()

        Else
            numQty.Value = 1
        End If

        If gsSelection = True Then
            xlblSelection.Visible = True
            cmbSelection.Visible = True
            xlblSelection.Text = gsSelection_Label
            GS_ComboBoxLoad(cmbSelection, gsSelection_Query, gsSelection_VALUE, gsSelection_DESCRIPTION)

            If Trim(gsSelection_ID) <> "" Then
                cmbSelection.SelectedValue = gsSelection_ID
            End If
        Else
            xlblSelection.Visible = False
            cmbSelection.SelectedValue = False
        End If

        If gsCOST_AMOUNT_ONLY = False Then
            xlblnum_price.Text = gsCUSTOM_RATE
        Else
            xlblnum_price.Text = gsCUSTOM_COST
        End If




        DiscountEffect()

        cmbItem_Code.Enabled = False
        cmbItem_DESCRIPTION.Enabled = False




        If sFormName = "frmStockTransfer" Then

            cmbDiscount_Type.SelectedValue = 0
            xlblDISCOUNT.Text = "Rate :"
            xlblDISCOUNT.Visible = False
            numDiscountValue.Value = 0
            numDiscountValue.Visible = False

        ElseIf sFormName = "frmPurchaseRequest" Then
            xlblnum_price.Visible = False
            numUnit_price.Visible = False
            xlblLabel_Amount.Visible = False
            lblAmount.Visible = False
            chkTax.Visible = False

        End If
        dgvSearch.Columns("DESCRIPTION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
    End Sub
    Private Sub DiscountEffect()
        If gsNON_DISCOUNTED_ITEM = False Then

            Try
                Select Case cmbDiscount_Type.SelectedValue.ToString

                    Case "0"
                        numDiscountValue.Enabled = True
                        numDiscountValue.DecimalPlaces = 2
                        numDiscountValue.Maximum = 999999999999
                    Case "1"
                        numDiscountValue.Enabled = True
                        numDiscountValue.DecimalPlaces = 0
                        numDiscountValue.Maximum = 100
                        numDiscountValue.Value = 50
                    Case Else
                        numDiscountValue.Enabled = False
                        numDiscountValue.Value = 0
                End Select

                ItemComputation()
            Catch ex As Exception

            End Try

        Else
            cmbDiscount_Type.SelectedIndex = -1

            numDiscountValue.Enabled = False
            numDiscountValue.Value = 0

            ItemComputation()
        End If
    End Sub
    Private Sub CmbDiscount_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount_Type.SelectedIndexChanged
        DiscountEffect()
    End Sub

    Private Sub NumDiscountValue_ValueChanged(sender As Object, e As EventArgs) Handles numDiscountValue.ValueChanged
        ItemComputation()
    End Sub

    Private Sub NumQty_GotFocus(sender As Object, e As EventArgs) Handles numQty.GotFocus
        dgvSearch.Visible = False
        txtSearch.Clear()
        BlueLight(numQty)
        xlblOnHand.Text = QtyActualOnDateLocation(cmbItem_Code.SelectedValue, gsDate, gsLOCATION_ID)
        If GF_NumIsNull(cmbItem_Code.SelectedValue) = 0 Then
            txtSearch.Focus()
        End If
    End Sub
    Private Sub CmbItem_DESCRIPTION_LostFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.LostFocus
        ItemSelector(cmbItem_DESCRIPTION, cmbItem_Code)
    End Sub
    Private Sub CmbItem_Code_LostFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.LostFocus
        ItemSelector(cmbItem_Code, cmbItem_DESCRIPTION)
    End Sub

    Private Sub CheckingPriceLevel(ByVal prItem_ID As Double)
        If gsCOST_AMOUNT_ONLY = True Then
            Exit Sub
        End If

        Dim pl_SQL As String = $"select * from ((SELECT  '0'  AS ID  ,'Default' AS `CODE`) UNION (SELECT  pl.ID, pl.`CODE` FROM price_level AS  pl WHere pl.TYPE = '0' and pl.Inactive = '0' ) UNION (SELECT  pl.ID, pl.`CODE` FROM price_level_lines AS pll INNER JOIN price_level AS  pl ON pl.`ID`= pll.`PRICE_LEVEL_ID` WHERE pll.`ITEM_ID` = '{prItem_ID}' and pl.INACTIVE ='0' and pl.Type ='1' )) as T order by T.ID"
        GS_ComboBoxLoad(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
        If cmbPRICE_LEVEL.Items.Count = 1 Then
            cmbPRICE_LEVEL.Visible = False
            xxxlblPrice_level.Visible = False
            cmbPRICE_LEVEL.CausesValidation = True
        Else
            cmbPRICE_LEVEL.Visible = True
            xxxlblPrice_level.Visible = True
        End If

    End Sub
    Private Sub ItemBatches(ByVal IS_EXPIRED As Boolean)
        dtpDateExpired.Checked = False
        dtpDateExpired.Visible = False
        xlblExpired.Visible = False
        If gsUseItemBatch = False Then
            Exit Sub
        End If
        If IS_EXPIRED = True Then
            dtpDateExpired.Checked = False
            dtpDateExpired.Visible = True
            xlblExpired.Visible = True
        End If

    End Sub
    Private Sub CheckPriceLevelUnits(ByVal prItem_ID As Double, ByVal prUnit_ID As Double)
        If gsCOST_AMOUNT_ONLY = True Then
            'Must only price 
            Exit Sub
        End If

        Dim rd As OdbcDataReader = SqlReader($"SELECT pl.`ID`,pl.`CODE` FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{prItem_ID}' AND n.`UNIT_ID` = '{prUnit_ID}' AND pl.`INACTIVE` = '0' and pl.TYPE ='1'")
        If rd.Read Then
            cmbPRICE_LEVEL.CausesValidation = False
            Dim pl_SQL As String = $"select * from ((SELECT  '0'  AS ID  ,'Default' AS `CODE`) UNION (SELECT pl.`ID`,pl.`CODE` FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{prItem_ID}' AND n.`UNIT_ID` = '{prUnit_ID}' AND pl.`INACTIVE` = '0' and pl.TYPE ='1' )) as T order by T.ID"
            GS_ComboBoxLoad(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
            If cmbPRICE_LEVEL.Items.Count = 1 Then
                cmbPRICE_LEVEL.Visible = False
                xxxlblPrice_level.Visible = False
            Else
                cmbPRICE_LEVEL.Visible = True
                xxxlblPrice_level.Visible = True
            End If

        Else
            CheckingPriceLevel(prItem_ID)
        End If
        rd.Close()
    End Sub
    Private Sub FrmAddItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If sFormName = "" Then
            btnOK.Text = "[F1] &OK"
            btnClose.Text = "[ESC] &Close"

            chkTax.Checked = gsTax
            numUnit_price.Value = gsUnit_Price
        Else
            btnOK.Text = "[F1] &Add"
            btnClose.Text = "[ESC] &Close"
        End If

        MemberDiscounted()
        DiscountEffect()

        GS_ViewItemDisplay(dgvSearch)
    End Sub
    Private Sub MemberDiscounted()
        If gsMEMBER = True Then
            cmbDiscount_Type.SelectedValue = 1
            numDiscountValue.Value = gsMEMEBER_DISCOUNT
            cmbDiscount_Type.Enabled = False
            numDiscountValue.Enabled = False
        Else
            cmbDiscount_Type.Enabled = True
            numDiscountValue.Enabled = True
        End If
    End Sub
    Private Sub NumUnit_price_LostFocus(sender As Object, e As EventArgs) Handles numUnit_price.LostFocus
        ItemComputation()
    End Sub

    Private Sub NumQty_LostFocus(sender As Object, e As EventArgs) Handles numQty.LostFocus
        ItemComputation()
        If sFormName <> "" Then
            If cmbUM.SelectedValue IsNot Nothing Then
            End If
        End If
    End Sub
    Private Sub NumUnit_price_GotFocus(sender As Object, e As EventArgs) Handles numUnit_price.GotFocus
        BlueLight(numUnit_price)
        dgvSearch.Visible = False
    End Sub

    Private Sub ItemSelector(ByVal cmbPrimary As ComboBox, cmbSecondary As ComboBox)
        Try
            xlblOnHand.Text = ""

            If cmbPrimary.SelectedValue IsNot Nothing Then
                cmbUM.DataSource = Nothing
                numUnit_price.Value = 0
                numUnit_price.Enabled = gsUserPriceLock
                cmbUM.Enabled = True
                numQty.Enabled = True
                numDiscountValue.Enabled = True
                cmbDiscount_Type.Enabled = True

                cmbSecondary.SelectedValue = cmbPrimary.SelectedValue
                Dim in_sql As String = ""

                Try
                    Dim SQ As String = "select i.IS_EXPIRED,
i.NON_PORFOLIO_COMPUTATION,
i.PIC_FILENAME,
i.NON_DISCOUNTED_ITEM,
i.BUNDLE_SET,
i.TYPE,
i.COST,
(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`)) as `RATE`,
i.BASE_UNIT_ID,
i.TAXABLE from ITEM as i WHERE i.ID ='" & cmbPrimary.SelectedValue & "' Limit 1"

                    Dim rd As OdbcDataReader = SqlReader(SQ)

                    If rd.Read Then
                        If gsUseImageProduct = True Then

                            GS_DisplayPhoto(GF_TextIsNull(rd("PIC_FILENAME")), picItem)


                        End If
                        ItemType = GF_NumIsNull(rd("TYPE"))
                        gsNON_DISCOUNTED_ITEM = GF_NumIsNull(rd("NON_DISCOUNTED_ITEM"))
                        gsNON_PORFOLIO_COMPUTATION = GF_NumIsNull(rd("NON_PORFOLIO_COMPUTATION"))
                        ItemBatches(CBool(GF_NumIsNull(rd("IS_EXPIRED"))))
                        If gsCOST_AMOUNT_ONLY = True And ItemType = 0 Then
                            _Unit_Rate = GF_NumIsNull(rd("COST"))
                        Else

                            _Unit_Rate = GF_NumIsNull(rd("RATE"))

                        End If

                        If ItemType <= 3 Then
                            Basic_Unit_ID = GF_NumIsNull(rd("BASE_UNIT_ID"))
                            chkTax.Checked = GF_NumIsNull(rd("TAXABLE"))

                        Else
                            Basic_Unit_ID = 0

                            chkTax.Checked = GF_NumIsNull(rd("TAXABLE"))
                        End If



                    End If
                    rd.Close()
                Catch ex As Exception
                    MessageBoxWarning(ex.Message)
                    Exit Sub
                End Try

                If Basic_Unit_ID > 0 Then

                    in_sql = "In ('" & Basic_Unit_ID & "'"


                    Try

                        Dim rd As OdbcDataReader = SqlReader("select UNIT_ID from item_units where ITEM_ID ='" & cmbPrimary.SelectedValue & "'")
                        While rd.Read
                            in_sql = in_sql & ",'" & rd("UNIT_ID") & "'"
                        End While
                        rd.Close()
                    Catch ex As Exception
                        MessageBoxWarning(ex.Message)
                        Exit Sub
                    End Try
                    in_sql &= ")"
                    GS_ComboBoxLoad(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID " & in_sql, "ID", "SYMBOL")

                    lblQty_Base.Text = "1"
                Else
                    GS_ComboBoxLoad(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID ='xxx' limit 1", "ID", "SYMBOL")
                End If

                If (Basic_Unit_ID) <> 0 Then

                    cmbUM.SelectedValue = Val(Basic_Unit_ID)

                End If

                If numQty.Enabled = True Then
                    numQty.Value = 1
                    BlueLight(numQty)
                End If

            Else
                numUnit_price.Enabled = gsUserPriceLock
                cmbUM.Enabled = True
                numQty.Enabled = True
                cmbSecondary.Text = ""
                cmbUM.Text = ""
            End If
            numUnit_price.DecimalPlaces = 2
            numUnit_price.ThousandsSeparator = True

            If ItemType = 5 Then ' Sub total
                numUnit_price.Enabled = False
                cmbUM.Enabled = False
                numQty.Enabled = False
                numDiscountValue.Enabled = False
                cmbDiscount_Type.Enabled = False
            ElseIf ItemType = 7 Then ' Discount
                gsRate_Type = GF_GetNumberFieldValue("ITEM", "ID", cmbItem_Code.SelectedValue, "RATE_TYPE")
                If gsRate_Type = 0 Then
                    numUnit_price.DecimalPlaces = 2
                    numUnit_price.ThousandsSeparator = True
                Else
                    numUnit_price.DecimalPlaces = 0
                    numUnit_price.ThousandsSeparator = False
                End If
                numUnit_price.Value = _Unit_Rate
                numQty.Enabled = False
                cmbUM.Enabled = False
                numDiscountValue.Enabled = False
                cmbDiscount_Type.Enabled = False
            ElseIf ItemType = 6 Then ' GROUP
                numQty.Enabled = True
                cmbUM.Enabled = False
                numUnit_price.Enabled = False
                numDiscountValue.Enabled = True
                cmbDiscount_Type.Enabled = True
                If gsNON_PORFOLIO_COMPUTATION = True Then
                    numQty.Enabled = False
                    numQty.Value = 1
                    _Unit_Rate = 0
                    numUnit_price.Value = _Unit_Rate
                Else
                    numUnit_price.Value = _Unit_Rate
                End If
            ElseIf ItemType = 4 Then 'Other Discount
                gsRate_Type = GF_GetNumberFieldValue("ITEM", "ID", cmbItem_Code.SelectedValue, "RATE_TYPE")
                If gsRate_Type = 0 Then
                    numUnit_price.DecimalPlaces = 2
                    numUnit_price.ThousandsSeparator = True
                Else
                    numUnit_price.DecimalPlaces = 0
                    numUnit_price.ThousandsSeparator = False
                End If
                numUnit_price.Value = _Unit_Rate
                numQty.Enabled = False
                cmbUM.Enabled = False
                numDiscountValue.Enabled = False
                cmbDiscount_Type.Enabled = False
                numUnit_price.Enabled = True

                numQty.Value = 1

                numUnit_price.Value = 0
            Else

                numQty.Enabled = True
                cmbUM.Enabled = True
                If ItemType <= 4 And gsCOST_AMOUNT_ONLY = False Then
                    CheckingPriceLevel(cmbPrimary.SelectedValue)

                    If cmbPRICE_LEVEL.Visible = True Then
                        If gsDefault_unit_price_level_id <> 0 Then
                            cmbPRICE_LEVEL.SelectedValue = gsDefault_unit_price_level_id
                        End If

                    Else
                        numUnit_price.Value = _Unit_Rate
                    End If
                Else
                    numUnit_price.Value = _Unit_Rate
                End If
            End If




            LoadUnitPrice()
            DiscountEffect()
            ItemComputation()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try



    End Sub





    Private Sub NumDiscountValue_GotFocus(sender As Object, e As EventArgs) Handles numDiscountValue.GotFocus
        BlueLight(numDiscountValue)
        dgvSearch.Visible = False
    End Sub

    Private Sub CmbUM_GotFocus(sender As Object, e As EventArgs) Handles cmbUM.GotFocus
        LoadUnitPrice()
        dgvSearch.Visible = False
    End Sub

    Private Sub NumQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged
        ItemComputation()
    End Sub
    Private Sub LoadUnitPrice()
        If ItemType <= 4 Then
            If Basic_Unit_ID = GF_NumIsNull(cmbUM.SelectedValue) Then
                lblQty_Base.Text = "1"
                If lblAmount.Visible = True Then
                    If _Unit_Rate <> 0 Then
                        numUnit_price.Enabled = gsUserPriceLock
                        ' If numUnit_price.Value = 0 Then
                        numUnit_price.Value = _Unit_Rate
                        BlueLight(numUnit_price)
                        '  End If

                    Else

                        numUnit_price.Value = 0
                        BlueLight(numUnit_price)
                    End If

                End If

            Else

                Try
                    lblQty_Base.Text = "1"
                    If gsCOST_AMOUNT_ONLY = False Then
                        numUnit_price.Value = _Unit_Rate
                    End If

                    If cmbUM.SelectedValue Is Nothing Then Exit Sub

                    Dim rd As OdbcDataReader = SqlReader("select quantity as q, rate as r from item_units where unit_id = '" & GF_NumIsNull(cmbUM.SelectedValue) & "' and item_id ='" & cmbItem_Code.SelectedValue & "' limit 1")
                    If rd.Read Then
                        If GF_NumIsNull(rd("q")) <> 0 Then
                            lblQty_Base.Text = GF_NumIsNull(rd("q"))
                        End If

                        If lblAmount.Visible = True And gsCOST_AMOUNT_ONLY = False Then

                            If GF_NumIsNull(rd("r")) <> 0 Then
                                numUnit_price.Value = GF_NumIsNull(rd("r"))
                            End If

                        Else

                            If gsCOST_AMOUNT_ONLY = True Then
                                numUnit_price.Value = _Unit_Rate * GF_NumIsNull(rd("q"))
                            End If

                        End If
                    End If
                    rd.Close()

                Catch ex As Exception

                    MessageBoxWarning(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub CmbUM_LostFocus(sender As Object, e As EventArgs) Handles cmbUM.LostFocus
        LoadUnitPrice()
    End Sub
    Private Sub NumUnit_price_ValueChanged(sender As Object, e As EventArgs) Handles numUnit_price.ValueChanged
        ItemComputation()
    End Sub
    Private Sub CmbUM_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbUM.SelectedIndexChanged
        Dim UNIT_ID As Double = GF_NumIsNull(DirectCast(sender, ComboBox).SelectedValue)
        LoadUnitPrice()
        CheckPriceLevelUnits(cmbItem_Code.SelectedValue, UNIT_ID)
    End Sub

    Private Sub CmbPRICE_LEVEL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPRICE_LEVEL.SelectedIndexChanged
        If gsCOST_AMOUNT_ONLY = True Then Exit Sub

        If cmbUM.Items.Count = 0 Then
            numUnit_price.Enabled = False
        Else
            numUnit_price.Enabled = gsUserPriceLock
        End If

        If cmbPRICE_LEVEL.SelectedIndex = 0 Then
            numUnit_price.Value = _Unit_Rate
        Else

            If cmbPRICE_LEVEL.CausesValidation = True Then

                Dim rd As OdbcDataReader = SqlReader($"select type,rate from price_level where id = '{cmbPRICE_LEVEL.SelectedValue}' limit 1")
                If rd.Read Then
                    If GF_NumIsNull(rd("type")) = 0 Then
                        'Fixed
                        Dim DISCOUNT_LESS As Double = _Unit_Rate * IIf(GF_NumIsNull(rd("rate")) < 100, CDbl(0 & "." & Format(GF_NumIsNull(rd("rate")), "00")), 1)
                        numUnit_price.Value = _Unit_Rate - DISCOUNT_LESS
                    ElseIf GF_NumIsNull(rd("type")) = 1 Then
                        'Per Item
                        numUnit_price.Value = GF_GetNumberFieldValueByTwoCondition("Price_level_lines", "Price_level_ID", cmbPRICE_LEVEL.SelectedValue, "ITEM_ID", cmbItem_Code.SelectedValue, "CUSTOM_PRICE")
                    End If
                End If
                rd.Close()

            Else
                ' Unit Price Level
                ' get price_level_Type
                Dim rd As OdbcDataReader = SqlReader($"SELECT u.`CUSTOM_PRICE`  FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{cmbItem_Code.SelectedValue}' AND n.`UNIT_ID` = '{cmbUM.SelectedValue}' AND pl.ID ='{cmbPRICE_LEVEL.SelectedValue}' AND pl.`INACTIVE` = '0' AND pl.type ='1'  limit 1")
                If rd.Read Then
                    'Fixed
                    numUnit_price.Value = GF_NumIsNull(rd("CUSTOM_PRICE"))
                End If
                rd.Close()
            End If



        End If
        ItemComputation()

    End Sub

    Private Sub CmbUM_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUM.KeyDown
        If e.KeyCode = Keys.Enter Then
            numUnit_price.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtSearch.Focus()

        End If

    End Sub
    Private Sub NumQty_KeyDown(sender As Object, e As KeyEventArgs) Handles numQty.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub NumUnit_price_KeyDown(sender As Object, e As KeyEventArgs) Handles numUnit_price.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub CmbPRICE_LEVEL_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPRICE_LEVEL.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub CmbDiscount_Type_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDiscount_Type.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub NumDiscountValue_KeyDown(sender As Object, e As KeyEventArgs) Handles numDiscountValue.KeyDown
        MasterKeyDown(sender, e)
    End Sub
    Private Sub CmbSelection_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSelection.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub BtnAdd_KeyDown(sender As Object, e As KeyEventArgs)
        MasterKeyDown(sender, e)
    End Sub

    Private Sub BtnCancel_KeyDown(sender As Object, e As KeyEventArgs)
        MasterKeyDown(sender, e)
    End Sub

    Private Sub FindItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindItemToolStripMenuItem.Click
        Try
            f.AccessibleName = "A"
            f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
            f.ShowDialog()
            If f.AccessibleDescription <> "" Then
                If f.AccessibleDescription <> "cancel" Then
                    cmbItem_Code.SelectedValue = f.AccessibleDescription
                    CmbItem_Code_LostFocus(sender, e)

                    BlueLight(numQty)
                    numQty.Focus()
                    ItemComputation()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumDiscountValue_TextChanged(sender As Object, e As EventArgs) Handles numDiscountValue.TextChanged
        ItemComputation()
    End Sub

    Private Sub NumQty_TextChanged(sender As Object, e As EventArgs) Handles numQty.TextChanged
        ItemComputation()
    End Sub

    Private Sub DgvSearch_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellDoubleClick
        If dgvSearch.Rows.Count <> 0 Then
            cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            dgvSearch.Visible = False
            txtSearch.Clear()

            ItemSelector(cmbItem_Code, cmbItem_DESCRIPTION)
        End If
    End Sub


    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        Try
            If txtSearch.Text.Length = 0 Then


                dgvSearch.Visible = False

                Exit Sub

            End If
            BS_ITEM.Filter = $" (CODE like '%{txtSearch.Text}%') or (DESCRIPTION like '%{txtSearch.Text}%')  "

            dgvSearch.Columns(0).Visible = False
            If dgvSearch.Visible = False Then
                dgvSearch.Visible = True
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

        MasterKeyDown(sender, e)

    End Sub

    Private Sub CmbItem_Code_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.GotFocus
        dgvSearch.Visible = False
    End Sub

    Private Sub CmbItem_DESCRIPTION_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.GotFocus
        dgvSearch.Visible = False
    End Sub

    Private Sub CmbPRICE_LEVEL_GotFocus(sender As Object, e As EventArgs) Handles cmbPRICE_LEVEL.GotFocus
        dgvSearch.Visible = False
    End Sub
    Private Sub DgvSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvSearch.Rows.Count <> 0 Then

                cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
                cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
                ItemSelector(cmbItem_Code, cmbItem_DESCRIPTION)


                dgvSearch.Visible = False
                txtSearch.Focus()

                If numQty.Enabled = True Then
                    numQty.Focus()
                    Exit Sub
                ElseIf numUnit_price.Enabled = True Then
                    numUnit_price.Focus()
                    Exit Sub
                Else
                    txtSearch.Focus()
                    Exit Sub
                End If
            End If

        ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

        Else
            MasterKeyDown(sender, e)
        End If





    End Sub

    Private Sub CmbItem_DESCRIPTION_EnabledChanged(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.EnabledChanged
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        If cmb.Enabled = False Then
            cmb.ForeColor = Color.Red
        End If
    End Sub

    Private Sub CmbItem_Code_TextChanged(sender As Object, e As EventArgs) Handles cmbItem_Code.TextChanged
        xlblITEM_ID.Text = cmbItem_Code.Text
    End Sub

    Private Sub CmbItem_DESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.TextChanged
        xlblDESCRIPTION.Text = cmbItem_DESCRIPTION.Text
    End Sub
    Private Sub ChkTax_GotFocus(sender As Object, e As EventArgs) Handles chkTax.GotFocus
        If numUnit_price.Value = 0 And numQty.Value <= 1 Then
            If ItemType = 4 Or ItemType = 7 Then
                numUnit_price.Select()
            End If
        End If
    End Sub

    Private Sub ChkTax_KeyDown(sender As Object, e As KeyEventArgs) Handles chkTax.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        gsSave = False
        Me.Close()
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If Trim(cmbItem_Code.Text) = "" Then
            MessageBoxInfo("Please select Item")
            Exit Sub
        End If
        If numDiscountValue.Value <> 0 And numUnit_price.Value = 0 And gsCOST_AMOUNT_ONLY = False Then
            MessageBoxInfo("Invalid applying discount with 0 prices is not available")
            numUnit_price.Focus()
            Exit Sub
        End If

        If gsCOST_AMOUNT_ONLY = False Then

        End If

        If cmbDiscount_Type.Text.Trim.Length <> 0 And numDiscountValue.Value = 0 And gsCOST_AMOUNT_ONLY = False Then
            MessageBoxInfo($"Invalid please enter {cmbDiscount_Type.Text.ToLower} discount")
            numDiscountValue.Focus()
            Exit Sub
        End If

        If gsNON_DISCOUNTED_ITEM = True Then
            If numDiscountValue.Value <> 0 Then
                'Counting 
                MessageBoxInfo("This item is not available in discount. please contact the administrator")
                Exit Sub
            End If
        End If

        If IsGroupItem(ItemType, False) = True Then
            'Check Negative 
            Dim AllowedNI As Boolean = IsAllowNegativeInventory()
            If AllowedNI = False Then

                Dim rd_group As OdbcDataReader = SqlReader($"SELECT i.ID as `ITEM_ID`,i.`DESCRIPTION`,ic.`Quantity`,i.`TYPE` FROM item_components AS ic INNER JOIN item AS i ON i.`ID` = ic.`COMPONENT_ID` WHERE ic.item_id = '{cmbItem_Code.SelectedValue}' ")
                While rd_group.Read

                    If IsItemOnHand(rd_group("ITEM_ID"), rd_group("DESCRIPTION"), rd_group("Quantity")) = False Then
                        Exit Sub
                    End If

                End While
                rd_group.Close()
            End If

        End If



        If IsDiscountItem(ItemType) = True Or IsOtherChargeItem(ItemType) = True Then

        Else
            If sFormName = FrmInventoryAdjustment.Name Then

            Else
                If numQty.Value = 0 Then
                    MessageBoxInfo("Please enter value for quantity")
                    numQty.Focus()
                    Exit Sub
                End If
            End If

        End If

        If sFormName = "" Or sFormName = FrmInventoryAdjustment.Name Then

            If GF_InventoryAdjustmentGotLatestEntry(cmbItem_Code.SelectedValue, gsDate, gsLOCATION_ID) = True Then
                MessageBoxInfo("This item have latest entry. item cannot added.")
                Exit Sub
            End If

            gsSave = True
            gsItem_ID = cmbItem_Code.SelectedValue
            gsBATCH_ID = GF_SetExpiration(gsItem_ID, dtpDateExpired)
            gsItem_Description = cmbItem_DESCRIPTION.Text
            gsQty = numQty.Value
            gsUM = cmbUM.SelectedValue
            gsBase_Qty = Val(lblQty_Base.Text)
            gsUnit_Price = numUnit_price.Value
            gsDiscount_Type = cmbDiscount_Type.SelectedValue
            gsDiscount_Rate = numDiscountValue.Value



            gsTax = chkTax.Checked
            gsPRICE_LEVEL_ID = cmbPRICE_LEVEL.SelectedValue
            If gsSelection = True Then
                gsSelection_ID = cmbSelection.SelectedValue
            End If
            ItemComputation()
            If FrmInventoryAdjustment.Name = sFormName Then
                If gsNew = True Then
                    GS_AddItemInventoryRow(dgv, gsNew, gsItem_ID, gsUM, gsQty, gsBase_Qty, gsUnit_Price, "A", gsLOCATION_ID, gsDate, gsBATCH_ID)
                    dgv.Focus()
                    dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
                    ClearAllFromForm()
                End If
            Else
                Me.Close()
            End If


        Else
            ItemComputation()
            gsSave = False
            gsItem_ID = cmbItem_Code.SelectedValue
            gsBATCH_ID = GF_SetExpiration(gsItem_ID, dtpDateExpired)
            gsItem_Description = cmbItem_DESCRIPTION.Text
            gsQty = numQty.Value
            gsUM = cmbUM.SelectedValue
            gsBase_Qty = Val(lblQty_Base.Text)
            gsUnit_Price = numUnit_price.Value
            gsDiscount_Type = cmbDiscount_Type.SelectedValue
            gsDiscount_Rate = numDiscountValue.Value
            gsTax = chkTax.Checked
            gsPRICE_LEVEL_ID = cmbPRICE_LEVEL.SelectedValue

            If gsSelection = True Then
                gsSelection_ID = cmbSelection.SelectedValue
            End If
            Dim DISC_OTH_DECT As Boolean
            Dim bDiscount_item As Boolean = IsDiscountItem(ItemType)

            'checking if is discount

            DISC_OTH_DECT = False
            gsRate_Type = 0
            If ItemType = 4 Or ItemType = 7 Then
                gsRate_Type = GF_GetNumberFieldValue("ITEM", "ID", gsItem_ID, "RATE_TYPE")
                DISC_NAME = GF_GetStringFieldValue("DISCOUNT_TYPE", "ID", gsRate_Type, "DESCRIPTION")
                DISC_OTH_DECT = True
            End If

            If DISC_OTH_DECT = False Then
                gsDate = Date.Now()
                Select Case sFormName
                    Case FrmStockTransfer.Name

                        GS_RowDataStockTransfer(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A", gsBATCH_ID)
                        GoTo down_now

                    Case FrmStockReceived.Name
                        GS_RowDataStockReceived(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A", 0)
                        GoTo down_now
                    Case FrmInvoice.Name.ToString
                        If ItemType > 1 Then
                            'Do Nothing
                        Else
                            If IsAllowNegativeInventory() = False Then
                                If IsItemOnHand(cmbItem_Code.SelectedValue, cmbItem_DESCRIPTION.Text, numQty.Value) = False Then
                                    Exit Sub
                                End If
                            End If
                        End If

                        GS_RowDataItemInvoice(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, "", gsPRICE_LEVEL_ID, 0, False, gsBATCH_ID)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmCreditMemo.Name.ToString
                        GS_RowDataItemCreditMemo(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsPRICE_LEVEL_ID, 0, False, gsBATCH_ID)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmSalesOrder.Name.ToString
                        GS_RowDataItemSalesOrder(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, "", gsPRICE_LEVEL_ID, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmSalesReceipt.Name.ToString

                        If ItemType > 1 Then
                            'Do Nothing
                        Else

                            If IsAllowNegativeInventory() = False Then
                                If IsItemOnHand(cmbItem_Code.SelectedValue, cmbItem_DESCRIPTION.Text, numQty.Value) = False Then
                                    Exit Sub
                                End If
                            End If

                        End If
                        GS_RowDataItemSalesReceipt(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsPRICE_LEVEL_ID, False, 0, gsBATCH_ID)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmEstimate.Name.ToString
                        GS_RowDataItemEstimate(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsPRICE_LEVEL_ID)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmBills.Name.ToString
                        GS_RowDataItemBills(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, "", gsBATCH_ID)
                    Case FrmBillCredit.Name.ToString
                        GS_RowDataItemBillCredit(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, gsBATCH_ID)
                    Case FrmPurchaseOrder.Name.ToString
                        GS_RowDataItemPurchaseOrder(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, 0)
                    Case FrmPurchaseRequest.Name.ToString
                        GS_RowDataItemPurchaseRequest(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount)
                    Case FrmWriteCheck.Name.ToString
                        GS_RowDataItemWriteCheck(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, gsBATCH_ID)
                End Select
down_now:
                dgv.Focus()
                If dgv.Rows.Count <> 0 Then
                    Try
                        dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
                    Catch ex As Exception

                    End Try


                End If

            ElseIf DISC_OTH_DECT = True Then
                ' SET DISCOUNT
                Dim TotalAmount As Double = GetTotal(dgv)

                Select Case sFormName
                    Case FrmInvoice.Name
                        'SUB TOTAL
                        '  GS_RowDataItemInvoice(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", TotalAmount, False, "", "A", 0, "", TotalAmount, "", gsPRICE_LEVEL_ID, 0)
                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemInvoice(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, 0, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmCreditMemo.Name
                        'SUB TOTAL
                        ' GS_RowDataItemCreditMemo(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", TotalAmount, False, "", "A", 0, "", TotalAmount, gsPRICE_LEVEL_ID, 0)
                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemCreditMemo(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, 0, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmSalesOrder.Name
                        'SUB TOTAL
                        ' GS_RowDataItemSalesOrder(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", TotalAmount, False, "", "A", 0, "", TotalAmount, "", gsPRICE_LEVEL_ID)
                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemSalesOrder(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmSalesReceipt.Name
                        'SUB TOTAL
                        ' GS_RowDataItemSalesReceipt(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", TotalAmount, False, "", "A", 0, "", TotalAmount, gsPRICE_LEVEL_ID)
                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemSalesReceipt(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, False, 0, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)

                    Case FrmBills.Name
                        'SUB TOTAL

                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemBills(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", "", 0)

                    Case FrmBillCredit.Name
                        'SUB TOTAL

                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemBillCredit(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", 0)

                    Case FrmPurchaseOrder.Name
                        'SUB TOTAL

                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemPurchaseOrder(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, 0)

                    Case FrmWriteCheck.Name
                        'SUB TOTAL

                        gsAmount = GS_DiscountOtherCharge(TotalAmount, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemWriteCheck(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", 0)
                End Select
                dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
            End If
            ClearAllFromForm()
            txtSearch.Focus()
        End If
    End Sub

    Private Sub FrmAddItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub BtnOK_KeyDown(sender As Object, e As KeyEventArgs) Handles btnOK.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub BtnClose_KeyDown(sender As Object, e As KeyEventArgs) Handles btnClose.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub NumQty_Click(sender As Object, e As EventArgs) Handles numQty.Click
        NumberPadKeyToTouch(numQty, "ENTER QUANTITY")
    End Sub

    Private Sub NumUnit_price_Click(sender As Object, e As EventArgs) Handles numUnit_price.Click
        NumberPadKeyToTouch(numUnit_price, "CHANGE PRICE")
    End Sub
    Private Sub BtnLIST_Click(sender As Object, e As EventArgs)
        FrmItemExpired.ShowDialog()
        FrmItemExpired.Dispose()
        FrmItemExpired = Nothing
    End Sub
End Class