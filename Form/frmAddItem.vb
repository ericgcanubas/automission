﻿Imports System.Data.Odbc
Public Class frmAddItem


    Dim BS_ITEM As BindingSource
    Dim ItemType As Integer
    Dim gsRate_Type As Integer
    Dim DISC_NAME As String
    Public gsUseItemBatch As Boolean = False
    Public gsNON_DISCOUNTED_ITEM As Boolean = False
    Public gsNON_PORFOLIO_COMPUTATION As Boolean = False
    Public gsNonInventoryItem As Boolean = True
    Public gsNew As Boolean = False
    Dim f As Form = New frmFindItem
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

    Private Sub fMaster_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            If dgvSearch.Visible = True Then


                dgvSearch_KeyDown(sender, e)

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
    Private Sub btnCancel_Click(sender As Object, e As EventArgs)

    End Sub
    Private Function fCHECK_ITEM_ONHAND(ByVal prITEM_ID As Integer, ByVal prDESCRIPTION As String, ByVal prQTY As Double) As Boolean
        Dim bON_HAND As Boolean = True
        Dim iQty As Double = fQTY_ACTUAL_ON_DATE_LOCATION(prITEM_ID, gsDate, gsLOCATION_ID)

        Dim nQTY As Double = (numQty.Value * IIf(Val(lblQty_Base.Text) = 0, 1, Val(lblQty_Base.Text))) + fdgvGetQty(prITEM_ID)

        If iQty - nQTY <= -1 Then
            fMessageboxExclamation($"Not allowed negative inventory on  {prDESCRIPTION}. { Environment.NewLine} { Environment.NewLine} Sorry, unable to proceed.")
            bON_HAND = False
        End If

        Return bON_HAND
    End Function

    Private Function fdgvGetQty(ByVal prITEM_ID As Integer) As Double
        Dim qty As Double = 0
        If dgv.Rows.Count <> 0 Then

            For I As Integer = 0 To dgv.Rows.Count - 1
                If dgv.Rows(I).Cells("ITEM_ID").Value = prITEM_ID Then
                    qty = qty + (dgv.Rows(I).Cells("QTY").Value * Val(dgv.Rows(I).Cells("UNIT_QUANTITY_BASE").Value))
                End If
            Next
        End If
        Return qty
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)




    End Sub

    Private Sub fClearAll()
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

        fCLean_and_refresh(Me)
        xlblOnHand.Text = ""

        cmbUM.DataSource = Nothing
        xlblLabel_Amount.Text = lbl1
        xlblnum_price.Text = lbl2
        xlblSelection.Text = lbl3
        fMemberDiscount()
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
    Private Function fTotal_NOW(ByVal dgv As DataGridView) As Double
        Dim T As Double = 0

        For i As Integer = 0 To dgv.Rows.Count - 1
            With dgv.Rows(i)
                If .Visible = True Then

                    Select Case .Cells("ITEM_TYPE").Value
                        Case 4 ' OTHER CHARGE
                            T = 0
                        Case 5 ' SUB
                            T = fNumFormatFixed(.Cells("AMOUNT").Value)
                        Case 6 ' GROUP

                        Case 7 ' DISCOUNT
                            T = 0
                        Case Else
                            T = T + fNumFormatFixed(.Cells("AMOUNT").Value)
                    End Select

                End If

            End With
        Next

        Return T
    End Function

    Private Sub fComputation()
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

            lblAmount.Text = fNumFormatStandard(gsAmount)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' fLabel_Digital_S(lblAmount)

        If gsUseImageProduct = True Then
            Me.Size = New Size(824, 286)
            Me.Top = 0
            Me.Left = 0

        Else
            Me.Size = New Size(589, 286)
        End If



        dgvSearch.Size = New Size(563, 212)


        If gsCOST_AMOUNT_ONLY = False Then
            fComboBox(cmbItem_Code, gsItemCodeQuery, "ID", "CODE")
            fComboBox(cmbItem_DESCRIPTION, gsItemDescriptionQuery, "ID", "DESCRIPTION")
            fDataGridView_Binding(dgvSearch, gsItemSearchQuery, BS_ITEM)


            dgvSearch.Columns("GROUP").Width = 50
            dgvSearch.Columns("RATE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("RATE").Width = 40
            dgvSearch.Columns("RATE").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        ElseIf gsCOST_AMOUNT_ONLY = True And (sFormName = frmStockTransfer.Name Or sFormName = frmInventoryAdjustment.Name) Then
            fComboBox(cmbItem_Code, gsItemCodeZeroQuery, "ID", "CODE")
            fComboBox(cmbItem_DESCRIPTION, gsItemDescriptionZeroQuery, "ID", "DESCRIPTION")
            fDataGridView_Binding(dgvSearch, gsItemSearchZeroQuery, BS_ITEM)

            '  dgvSearch.Columns(2).Width = 200
            dgvSearch.Columns(3).Width = 60
            dgvSearch.Columns("COST").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("COST").Width = 60
            dgvSearch.Columns("COST").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        Else
            fComboBox(cmbItem_Code, gsItemCodeCostQuery, "ID", "CODE")
            fComboBox(cmbItem_DESCRIPTION, gsItemDescriptionCostQuery, "ID", "DESCRIPTION")
            fDataGridView_Binding(dgvSearch, gsItemSearchCostQuery, BS_ITEM)

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
        fComboBox(cmbDiscount_Type, " select '' as ID, '' as DESCRIPTION  FROM discount_type  UNION select ID,DESCRIPTION FROM discount_type ", "ID", "DESCRIPTION")

        fCLean_and_refresh(Me)
        If gsItem_ID <> "" Then
            cmbItem_Code.SelectedValue = gsItem_ID
            cmbItem_DESCRIPTION.SelectedValue = gsItem_ID
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
            FindItemToolStripMenuItem.Enabled = False
            txtSearch.Visible = False
            xlblSearch.Visible = False
            cmbUM_SelectedIndexChanged(sender, e)
            cmbItem_Code_LostFocus(sender, e)

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
                        fCheckPriceLevel_UNIT(gsItem_ID, gsUM)
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

            fGetExpiration(gsBATCH_ID, gsItem_ID, gsExpired_Date, gsGotExpired)
            dtpDateExpired.Checked = gsGotExpired
            If dtpDateExpired.Checked = True Then
                dtpDateExpired.Value = gsExpired_Date
            End If

            fComputation()

        Else
            numQty.Value = 1
        End If

        If gsSelection = True Then
            xlblSelection.Visible = True
            cmbSelection.Visible = True
            xlblSelection.Text = gsSelection_Label
            fComboBox(cmbSelection, gsSelection_Query, gsSelection_VALUE, gsSelection_DESCRIPTION)

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




        fDiscount_Effect()

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






    Private Sub numUnit_price_ValueChanged(sender As Object, e As EventArgs)
        fComputation()
    End Sub

    Private Sub fDiscount_Effect()
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

                fComputation()
            Catch ex As Exception

            End Try

        Else
            cmbDiscount_Type.SelectedIndex = -1

            numDiscountValue.Enabled = False
            numDiscountValue.Value = 0

            fComputation()
        End If
    End Sub
    Private Sub cmbDiscount_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount_Type.SelectedIndexChanged

        fDiscount_Effect()
    End Sub

    Private Sub numDiscountValue_ValueChanged(sender As Object, e As EventArgs) Handles numDiscountValue.ValueChanged
        fComputation()
    End Sub

    Private Sub cmbUM_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub numQty_GotFocus(sender As Object, e As EventArgs) Handles numQty.GotFocus
        dgvSearch.Visible = False
        txtSearch.Clear()
        fBlueLight(numQty)
        xlblOnHand.Text = fQTY_ACTUAL_ON_DATE_LOCATION(cmbItem_Code.SelectedValue, gsDate, gsLOCATION_ID)
        If fNumisNULL(cmbItem_Code.SelectedValue) = 0 Then
            txtSearch.Focus()
        End If
    End Sub
    Private Sub cmbItem_DESCRIPTION_LostFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.LostFocus
        fItemSelected(cmbItem_DESCRIPTION, cmbItem_Code)
    End Sub
    Private Sub cmbItem_Code_LostFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.LostFocus

        fItemSelected(cmbItem_Code, cmbItem_DESCRIPTION)

    End Sub

    Private Sub fCheckPriceLevel(ByVal prItem_ID As Double)
        If gsCOST_AMOUNT_ONLY = True Then
            'Must only price 
            Exit Sub
        End If

        Dim pl_SQL As String = $"select * from ((SELECT  '0'  AS ID  ,'Default' AS `CODE`) UNION (SELECT  pl.ID, pl.`CODE` FROM price_level AS  pl WHere pl.TYPE = '0' and pl.Inactive = '0' ) UNION (SELECT  pl.ID, pl.`CODE` FROM price_level_lines AS pll INNER JOIN price_level AS  pl ON pl.`ID`= pll.`PRICE_LEVEL_ID` WHERE pll.`ITEM_ID` = '{prItem_ID}' and pl.INACTIVE ='0' and pl.Type ='1' )) as T order by T.ID"
        fComboBox(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
        If cmbPRICE_LEVEL.Items.Count = 1 Then
            cmbPRICE_LEVEL.Visible = False
            xxxlblPrice_level.Visible = False
            cmbPRICE_LEVEL.CausesValidation = True
        Else
            cmbPRICE_LEVEL.Visible = True
            xxxlblPrice_level.Visible = True
        End If

    End Sub
    Private Sub fItemBatches(ByVal IS_EXPIRED As Boolean)
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
    Private Sub fCheckPriceLevel_UNIT(ByVal prItem_ID As Double, ByVal prUnit_ID As Double)
        If gsCOST_AMOUNT_ONLY = True Then
            'Must only price 
            Exit Sub
        End If

        Dim rd As OdbcDataReader = fReader($"SELECT pl.`ID`,pl.`CODE` FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{prItem_ID}' AND n.`UNIT_ID` = '{prUnit_ID}' AND pl.`INACTIVE` = '0' and pl.TYPE ='1'")
        If rd.Read Then
            cmbPRICE_LEVEL.CausesValidation = False
            Dim pl_SQL As String = $"select * from ((SELECT  '0'  AS ID  ,'Default' AS `CODE`) UNION (SELECT pl.`ID`,pl.`CODE` FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{prItem_ID}' AND n.`UNIT_ID` = '{prUnit_ID}' AND pl.`INACTIVE` = '0' and pl.TYPE ='1' )) as T order by T.ID"
            fComboBox(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
            If cmbPRICE_LEVEL.Items.Count = 1 Then
                cmbPRICE_LEVEL.Visible = False
                xxxlblPrice_level.Visible = False
            Else
                cmbPRICE_LEVEL.Visible = True
                xxxlblPrice_level.Visible = True
            End If

        Else
            fCheckPriceLevel(prItem_ID)
        End If
        rd.Close()
    End Sub
    Private Sub frmAddItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If sFormName = "" Then
            btnOK.Text = "[F1] &OK"
            btnClose.Text = "[ESC] &Close"

            chkTax.Checked = gsTax
            numUnit_price.Value = gsUnit_Price
        Else
            btnOK.Text = "[F1] &Add"
            btnClose.Text = "[ESC] &Close"
        End If

        fMemberDiscount()
        fDiscount_Effect()

        fdgvItemDisplay(dgvSearch)
    End Sub
    Private Sub fMemberDiscount()
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
    Private Sub numUnit_price_LostFocus(sender As Object, e As EventArgs) Handles numUnit_price.LostFocus
        fComputation()

    End Sub

    Private Sub numQty_LostFocus(sender As Object, e As EventArgs) Handles numQty.LostFocus
        fComputation()
        If sFormName <> "" Then
            If cmbUM.SelectedValue IsNot Nothing Then
                cmbUM_SelectedIndexChanged(sender, e)
            End If


        End If



    End Sub



    Private Sub numUnit_price_GotFocus(sender As Object, e As EventArgs) Handles numUnit_price.GotFocus
        fBlueLight(numUnit_price)
        dgvSearch.Visible = False
    End Sub

    Private Sub btnBrowse_GotFocus(sender As Object, e As EventArgs)

    End Sub


    Private Sub fItemSelected(ByVal cmbPrimary As ComboBox, cmbSecondary As ComboBox)
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
                'Format(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` =0 OR t.`TYPE` =4,c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) as `Rate`
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

                    Dim rd As OdbcDataReader = fReader(SQ)

                    If rd.Read Then
                        If gsUseImageProduct = True Then

                            fDisplayPhoto(fTextisNULL(rd("PIC_FILENAME")), picItem)


                        End If
                        ItemType = fNumisNULL(rd("TYPE"))
                        gsNON_DISCOUNTED_ITEM = fNumisNULL(rd("NON_DISCOUNTED_ITEM"))
                        gsNON_PORFOLIO_COMPUTATION = fNumisNULL(rd("NON_PORFOLIO_COMPUTATION"))
                        fItemBatches(CBool(fNumisNULL(rd("IS_EXPIRED"))))
                        If gsCOST_AMOUNT_ONLY = True And ItemType = 0 Then
                            _Unit_Rate = fNumisNULL(rd("COST"))
                        Else

                            _Unit_Rate = fNumisNULL(rd("RATE"))

                        End If

                        If ItemType <= 3 Then
                            Basic_Unit_ID = fNumisNULL(rd("BASE_UNIT_ID"))
                            chkTax.Checked = fNumisNULL(rd("TAXABLE"))

                        Else
                            Basic_Unit_ID = 0

                            chkTax.Checked = fNumisNULL(rd("TAXABLE"))
                        End If



                    End If
                    rd.Close()
                Catch ex As Exception
                    fMessageboxWarning(ex.Message)
                    Exit Sub
                End Try

                If Basic_Unit_ID > 0 Then

                    in_sql = "In ('" & Basic_Unit_ID & "'"


                    Try

                        Dim rd As OdbcDataReader = fReader("select UNIT_ID from item_units where ITEM_ID ='" & cmbPrimary.SelectedValue & "'")
                        While rd.Read
                            in_sql = in_sql & ",'" & rd("UNIT_ID") & "'"
                        End While
                        rd.Close()
                    Catch ex As Exception
                        fMessageboxWarning(ex.Message)
                        Exit Sub
                    End Try
                    in_sql = in_sql & ")"
                    fComboBox(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID " & in_sql, "ID", "SYMBOL")

                    lblQty_Base.Text = "1"
                Else
                    fComboBox(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID ='xxx' limit 1", "ID", "SYMBOL")
                End If

                If (Basic_Unit_ID) <> 0 Then

                    cmbUM.SelectedValue = Val(Basic_Unit_ID)

                End If

                If numQty.Enabled = True Then
                    numQty.Value = 1
                    fBlueLight(numQty)
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
                gsRate_Type = fNumFieldValue("ITEM", "ID", cmbItem_Code.SelectedValue, "RATE_TYPE")
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
                gsRate_Type = fNumFieldValue("ITEM", "ID", cmbItem_Code.SelectedValue, "RATE_TYPE")
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
                    fCheckPriceLevel(cmbPrimary.SelectedValue)

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




            fLOadUNitPrize()
            fDiscount_Effect()
            fComputation()
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try



    End Sub





    Private Sub numDiscountValue_GotFocus(sender As Object, e As EventArgs) Handles numDiscountValue.GotFocus
        fBlueLight(numDiscountValue)
        dgvSearch.Visible = False
    End Sub

    Private Sub cmbUM_GotFocus(sender As Object, e As EventArgs) Handles cmbUM.GotFocus
        fLOadUNitPrize()
        dgvSearch.Visible = False
    End Sub

    Private Sub NumQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged
        fComputation()
    End Sub


    Private Sub fLOadUNitPrize()
        If ItemType <= 4 Then


            If Basic_Unit_ID = fNumisNULL(cmbUM.SelectedValue) Then

                lblQty_Base.Text = "1"

                If lblAmount.Visible = True Then
                    If _Unit_Rate <> 0 Then

                        numUnit_price.Enabled = gsUserPriceLock
                        ' If numUnit_price.Value = 0 Then
                        numUnit_price.Value = _Unit_Rate
                            fBlueLight(numUnit_price)
                        '  End If

                    Else

                        numUnit_price.Value = 0
                        fBlueLight(numUnit_price)
                    End If

                End If

            Else

                Try
                    lblQty_Base.Text = "1"
                    If gsCOST_AMOUNT_ONLY = False Then
                        numUnit_price.Value = _Unit_Rate
                    End If

                    If cmbUM.SelectedValue Is Nothing Then Exit Sub

                    Dim rd As OdbcDataReader = fReader("select quantity as q, rate as r from item_units where unit_id = '" & fNumisNULL(cmbUM.SelectedValue) & "' and item_id ='" & cmbItem_Code.SelectedValue & "' limit 1")
                    If rd.Read Then
                        If fNumisNULL(rd("q")) <> 0 Then
                            lblQty_Base.Text = fNumisNULL(rd("q"))
                        End If

                        If lblAmount.Visible = True And gsCOST_AMOUNT_ONLY = False Then

                            If fNumisNULL(rd("r")) <> 0 Then
                                numUnit_price.Value = fNumisNULL(rd("r"))
                            End If

                        Else

                            If gsCOST_AMOUNT_ONLY = True Then
                                numUnit_price.Value = _Unit_Rate * fNumisNULL(rd("q"))
                            End If

                        End If
                    End If
                    rd.Close()

                Catch ex As Exception

                    fMessageboxWarning(ex.Message)
                End Try

            End If
        End If
    End Sub

    Private Sub cmbUM_LostFocus(sender As Object, e As EventArgs) Handles cmbUM.LostFocus
        fLOadUNitPrize()
    End Sub

    Private Sub cmbUexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Lblnum_price_Click(sender As Object, e As EventArgs) Handles xlblnum_price.Click

    End Sub

    Private Sub numUnit_price_ValueChanged_1(sender As Object, e As EventArgs) Handles numUnit_price.ValueChanged
        fComputation()
    End Sub

    Private Sub SearchItemToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub
    Public Sub Unit_Price_Level_Line()

    End Sub

    Private Sub CmbUM_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbUM.SelectedIndexChanged
        Dim UNIT_ID As Double = fNumisNULL(DirectCast(sender, ComboBox).SelectedValue)
        fLOadUNitPrize()
        fCheckPriceLevel_UNIT(cmbItem_Code.SelectedValue, UNIT_ID)
    End Sub

    Private Sub cmbPRICE_LEVEL_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPRICE_LEVEL.SelectedIndexChanged
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
                'Primary Price Level
                ' get price_level_Type
                Dim rd As OdbcDataReader = fReader($"select type,rate from price_level where id = '{cmbPRICE_LEVEL.SelectedValue}' limit 1")
                If rd.Read Then
                    If fNumisNULL(rd("type")) = 0 Then
                        'Fixed
                        Dim DISCOUNT_LESS As Double = _Unit_Rate * IIf(fNumisNULL(rd("rate")) < 100, CDbl(0 & "." & Format(fNumisNULL(rd("rate")), "00")), 1)
                        numUnit_price.Value = _Unit_Rate - DISCOUNT_LESS
                    ElseIf fNumisNULL(rd("type")) = 1 Then
                        'Per Item
                        numUnit_price.Value = fNumFieldValueByTwoCondition("Price_level_lines", "Price_level_ID", cmbPRICE_LEVEL.SelectedValue, "ITEM_ID", cmbItem_Code.SelectedValue, "CUSTOM_PRICE")
                    End If
                End If
                rd.Close()

            Else
                ' Unit Price Level
                ' get price_level_Type
                Dim rd As OdbcDataReader = fReader($"SELECT u.`CUSTOM_PRICE`  FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{cmbItem_Code.SelectedValue}' AND n.`UNIT_ID` = '{cmbUM.SelectedValue}' AND pl.ID ='{cmbPRICE_LEVEL.SelectedValue}' AND pl.`INACTIVE` = '0' AND pl.type ='1'  limit 1")
                If rd.Read Then
                    'Fixed
                    numUnit_price.Value = fNumisNULL(rd("CUSTOM_PRICE"))
                End If
                rd.Close()
            End If



        End If
        fComputation()

    End Sub

    Private Sub cmbUM_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUM.KeyDown
        If e.KeyCode = Keys.Enter Then
            numUnit_price.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtSearch.Focus()

        End If
        ' cmbItem_Code_KeyDown(sender, e)
    End Sub
    'Private Sub cmbItem_Code_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbItem_Code.KeyDown
    '    If e.KeyCode = Keys.Escape Then
    '        txtSearch.Focus()
    '    ElseIf e.KeyCode = Keys.Enter Then
    '        If cmbItem_Code.SelectedIndex = -1 Then
    '            txtSearch.Focus()
    '            Exit Sub
    '        End If
    '        If cmbItem_Code.SelectedValue = cmbItem_DESCRIPTION.SelectedValue Then
    '            ' numQty.Focus()


    '        End If


    '    End If
    'End Sub

    'Private Sub cmbItem_DESCRIPTION_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbItem_DESCRIPTION.KeyDown
    '    If e.KeyCode = Keys.Escape Then
    '        txtSearch.Focus()

    '    End If
    'End Sub

    Private Sub numQty_KeyDown(sender As Object, e As KeyEventArgs) Handles numQty.KeyDown


        fMaster_KeyDown(sender, e)

    End Sub

    Private Sub numUnit_price_KeyDown(sender As Object, e As KeyEventArgs) Handles numUnit_price.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub cmbPRICE_LEVEL_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPRICE_LEVEL.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub cmbDiscount_Type_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDiscount_Type.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub numDiscountValue_KeyDown(sender As Object, e As KeyEventArgs) Handles numDiscountValue.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub cmbSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSelection.SelectedIndexChanged

    End Sub

    Private Sub cmbSelection_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbSelection.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnAdd_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnCancel_KeyDown(sender As Object, e As KeyEventArgs)
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub FindItemToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FindItemToolStripMenuItem.Click
        Try
            f.AccessibleName = "A"
            f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
            f.ShowDialog()
            If f.AccessibleDescription <> "" Then
                If f.AccessibleDescription <> "cancel" Then
                    cmbItem_Code.SelectedValue = f.AccessibleDescription
                    cmbItem_Code_LostFocus(sender, e)

                    fBlueLight(numQty)
                    numQty.Focus()
                    fComputation()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub numDiscountValue_TextChanged(sender As Object, e As EventArgs) Handles numDiscountValue.TextChanged
        fComputation()
    End Sub

    Private Sub numQty_TextChanged(sender As Object, e As EventArgs) Handles numQty.TextChanged
        fComputation()
    End Sub

    Private Sub numUnit_price_TextChanged(sender As Object, e As EventArgs) Handles numUnit_price.TextChanged

    End Sub

    Private Sub numUnit_price_KeyPress(sender As Object, e As KeyPressEventArgs) Handles numUnit_price.KeyPress
        ' fComputation()
    End Sub


    Private Sub dgvSearch_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellDoubleClick
        If dgvSearch.Rows.Count <> 0 Then
            cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            dgvSearch.Visible = False
            txtSearch.Clear()

            fItemSelected(cmbItem_Code, cmbItem_DESCRIPTION)
        End If
    End Sub



    Private Sub cmbItem_DESCRIPTION_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbItem_DESCRIPTION.KeyPress

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
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

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

        fMaster_KeyDown(sender, e)

    End Sub

    Private Sub cmbItem_Code_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.GotFocus
        dgvSearch.Visible = False
    End Sub

    Private Sub cmbItem_DESCRIPTION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.SelectedIndexChanged

    End Sub

    Private Sub cmbItem_DESCRIPTION_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.GotFocus
        dgvSearch.Visible = False
    End Sub

    Private Sub cmbPRICE_LEVEL_GotFocus(sender As Object, e As EventArgs) Handles cmbPRICE_LEVEL.GotFocus
        dgvSearch.Visible = False
    End Sub

    Private Sub dgvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellContentClick

    End Sub

    Private Sub dgvSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvSearch.Rows.Count <> 0 Then

                cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
                cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
                fItemSelected(cmbItem_Code, cmbItem_DESCRIPTION)


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
            fMaster_KeyDown(sender, e)
        End If





    End Sub

    Private Sub cmbItem_DESCRIPTION_EnabledChanged(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.EnabledChanged
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        If cmb.Enabled = False Then
            cmb.ForeColor = Color.Red
        End If
    End Sub

    Private Sub cmbItem_Code_TextChanged(sender As Object, e As EventArgs) Handles cmbItem_Code.TextChanged
        xlblITEM_ID.Text = cmbItem_Code.Text
    End Sub

    Private Sub cmbItem_DESCRIPTION_TextChanged(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.TextChanged
        xlblDESCRIPTION.Text = cmbItem_DESCRIPTION.Text
    End Sub

    Private Sub xlblITEM_ID_Click(sender As Object, e As EventArgs) Handles xlblITEM_ID.Click

    End Sub

    Private Sub xlblDESCRIPTION_Click(sender As Object, e As EventArgs) Handles xlblDESCRIPTION.Click

    End Sub

    Private Sub chkTax_CheckedChanged(sender As Object, e As EventArgs) Handles chkTax.CheckedChanged

    End Sub

    Private Sub chkTax_GotFocus(sender As Object, e As EventArgs) Handles chkTax.GotFocus
        If numUnit_price.Value = 0 And numQty.Value <= 1 Then
            If ItemType = 4 Or ItemType = 7 Then
                numUnit_price.Select()
            End If
        End If
    End Sub

    Private Sub chkTax_KeyDown(sender As Object, e As KeyEventArgs) Handles chkTax.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        gsSave = False
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Trim(cmbItem_Code.Text) = "" Then
            fMessageboxInfo("Please select Item")
            Exit Sub
        End If
        If numDiscountValue.Value <> 0 And numUnit_price.Value = 0 And gsCOST_AMOUNT_ONLY = False Then
            fMessageboxInfo("Invalid applying discount with 0 prices is not available")
            numUnit_price.Focus()
            Exit Sub
        End If

        If gsCOST_AMOUNT_ONLY = False Then

        End If

        If cmbDiscount_Type.Text.Trim.Length <> 0 And numDiscountValue.Value = 0 And gsCOST_AMOUNT_ONLY = False Then
            fMessageboxInfo($"Invalid please enter {cmbDiscount_Type.Text.ToLower} discount")
            numDiscountValue.Focus()
            Exit Sub
        End If

        If gsNON_DISCOUNTED_ITEM = True Then
            If numDiscountValue.Value <> 0 Then
                'Counting 
                fMessageboxInfo("This item is not available in discount. please contact the administrator")
                Exit Sub
            End If
        End If

        If fGROUP_ITEM(ItemType, False) = True Then
            'Check Negative 
            Dim AllowedNI As Boolean = fAllowNegativeInventory()
            If AllowedNI = False Then

                Dim rd_group As OdbcDataReader = fReader($"SELECT i.ID as `ITEM_ID`,i.`DESCRIPTION`,ic.`Quantity`,i.`TYPE` FROM item_components AS ic INNER JOIN item AS i ON i.`ID` = ic.`COMPONENT_ID` WHERE ic.item_id = '{cmbItem_Code.SelectedValue}' ")
                While rd_group.Read

                    If fCHECK_ITEM_ONHAND(rd_group("ITEM_ID"), rd_group("DESCRIPTION"), rd_group("Quantity")) = False Then
                        Exit Sub
                    End If

                End While
                rd_group.Close()
            End If

        End If



        If fDISCOUNT_ITEM(ItemType) = True Or fOTHER_CHARGE_ITEM(ItemType) = True Then

        Else
            If sFormName = frmInventoryAdjustment.Name Then

            Else
                If numQty.Value = 0 Then
                    fMessageboxInfo("Please enter value for quantity")
                    numQty.Focus()
                    Exit Sub
                End If
            End If

        End If

        If sFormName = "" Or sFormName = frmInventoryAdjustment.Name Then

            If fInventoryAdjustmentGotLatestEntry(cmbItem_Code.SelectedValue, gsDate, gsLOCATION_ID) = True Then
                fMessageboxInfo("This item have latest entry. item cannot added.")
                Exit Sub
            End If

            gsSave = True
            gsItem_ID = cmbItem_Code.SelectedValue
            gsBATCH_ID = fSetExpiration(gsItem_ID, dtpDateExpired)
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
            fComputation()
            If frmInventoryAdjustment.Name = sFormName Then
                If gsNew = True Then
                    fAddItem_Inventory_Row(dgv, gsNew, gsItem_ID, gsUM, gsQty, gsBase_Qty, gsUnit_Price, "A", gsLOCATION_ID, gsDate, gsBATCH_ID)
                    dgv.Focus()
                    dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(fColVis(dgv)) 'Last Row HighLight
                    fClearAll()
                End If
            Else
                Me.Close()
            End If


        Else
            fComputation()
            gsSave = False
            gsItem_ID = cmbItem_Code.SelectedValue
            gsBATCH_ID = fSetExpiration(gsItem_ID, dtpDateExpired)
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
            Dim DISC_OTH_DECT As Boolean = False
            Dim bDiscount_item As Boolean = fDISCOUNT_ITEM(ItemType)

            'checking if is discount
            Dim D_TYPE As Integer = 0
            DISC_OTH_DECT = False
            gsRate_Type = 0
            If ItemType = 4 Or ItemType = 7 Then
                gsRate_Type = fNumFieldValue("ITEM", "ID", gsItem_ID, "RATE_TYPE")
                DISC_NAME = fGetFieldValue("DISCOUNT_TYPE", "ID", gsRate_Type, "DESCRIPTION")
                DISC_OTH_DECT = True
            End If

            If DISC_OTH_DECT = False Then
                gsDate = Date.Now()
                Select Case sFormName
                    Case frmStockTransfer.Name

                        fRow_Data_StockTransfer(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A", gsBATCH_ID)
                        GoTo down_now

                    Case frmStockReceived.Name
                        fRow_Data_StockReceived(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A", 0)
                        GoTo down_now
                    Case frmInvoice.Name.ToString
                        If ItemType > 1 Then
                            'Do Nothing
                        Else
                            If fAllowNegativeInventory() = False Then
                                If fCHECK_ITEM_ONHAND(cmbItem_Code.SelectedValue, cmbItem_DESCRIPTION.Text, numQty.Value) = False Then
                                    Exit Sub
                                End If
                            End If
                        End If

                        fRow_Data_Item_Invoice(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, "", gsPRICE_LEVEL_ID, 0, False, gsBATCH_ID)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmCreditMemo.Name.ToString
                        fRow_Data_Item_Credit_Memo(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsPRICE_LEVEL_ID, 0, False, gsBATCH_ID)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmSalesOrder.Name.ToString
                        fRow_Data_Item_Sales_Order(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, "", gsPRICE_LEVEL_ID, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmSalesReceipt.Name.ToString

                        If ItemType > 1 Then
                            'Do Nothing
                        Else

                            If fAllowNegativeInventory() = False Then
                                If fCHECK_ITEM_ONHAND(cmbItem_Code.SelectedValue, cmbItem_DESCRIPTION.Text, numQty.Value) = False Then
                                    Exit Sub
                                End If
                            End If

                        End If
                        fRow_Data_Item_Sales_Receipt(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsPRICE_LEVEL_ID, False, 0, gsBATCH_ID)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmEstimate.Name.ToString
                        fRow_Data_Item_Estimate(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsPRICE_LEVEL_ID)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmBills.Name.ToString
                        fRow_Data_Item_Bill(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, "", gsBATCH_ID)
                    Case frmBillCredit.Name.ToString
                        fRow_Data_Item_Bill_Credit(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, gsBATCH_ID)
                    Case frmPurchaseOrder.Name.ToString
                        fRow_Data_Item_Purchase_Order(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, 0)
                    Case frmPurchaseRequest.Name.ToString
                        fRow_Data_Item_Purchase_Request(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount)
                    Case frmWriteCheck.Name.ToString
                        fRow_Data_Item_Write_Check(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, gsBATCH_ID)
                End Select
down_now:
                dgv.Focus()
                If dgv.Rows.Count <> 0 Then
                    Try
                        dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(fColVis(dgv)) 'Last Row HighLight
                    Catch ex As Exception

                    End Try


                End If

            ElseIf DISC_OTH_DECT = True Then
                ' SET DISCOUNT


                Dim T As Double = fTotal_NOW(dgv)
                Dim L As Double = 0
                Select Case sFormName
                    Case frmInvoice.Name
                        'SUB TOTAL
                        '  fRow_Data_Item_Invoice(dgv, True, fGetFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", gsPRICE_LEVEL_ID, 0)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Invoice(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, 0, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmCreditMemo.Name
                        'SUB TOTAL
                        ' fRow_Data_Item_Credit_Memo(dgv, True, fGetFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, gsPRICE_LEVEL_ID, 0)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Credit_Memo(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, 0, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmSalesOrder.Name
                        'SUB TOTAL
                        ' fRow_Data_Item_Sales_Order(dgv, True, fGetFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", gsPRICE_LEVEL_ID)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Sales_Order(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmSalesReceipt.Name
                        'SUB TOTAL
                        ' fRow_Data_Item_Sales_Receipt(dgv, True, fGetFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, gsPRICE_LEVEL_ID)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Sales_Receipt(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, False, 0, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)

                    Case frmBills.Name
                        'SUB TOTAL

                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Bill(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", "", 0)

                    Case frmBillCredit.Name
                        'SUB TOTAL

                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Bill_Credit(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", 0)

                    Case frmPurchaseOrder.Name
                        'SUB TOTAL

                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Purchase_Order(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, 0)

                    Case frmWriteCheck.Name
                        'SUB TOTAL

                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Write_Check(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", 0)
                End Select
                dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(fColVis(dgv)) 'Last Row HighLight
            End If
            fClearAll()
            txtSearch.Focus()
        End If
    End Sub

    Private Sub frmAddItem_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnOK_KeyDown(sender As Object, e As KeyEventArgs) Handles btnOK.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub

    Private Sub btnClose_KeyDown(sender As Object, e As KeyEventArgs) Handles btnClose.KeyDown
        fMaster_KeyDown(sender, e)
    End Sub
    'Private Sub fDISCOUNT_OTHERCHARGE(ByRef T As Integer)
    '    Dim L As Double = 0
    '    Select Case ItemType
    '        Case 4
    '            'OTHER CHRGE
    '            If gsRate_Type = 0 Then
    '                gsUnit_Price = numUnit_price.Value
    '                gsAmount = fNumFormatFixed(gsUnit_Price)
    '            Else
    '                gsUnit_Price = numUnit_price.Value * -1
    '                L = T * (numUnit_price.Value / 100)
    '                gsAmount = fNumFormatFixed(L) * -1
    '            End If
    '        Case 7
    '            'DISCOUNT
    '            If gsRate_Type = 0 Then
    '                gsUnit_Price = numUnit_price.Value
    '                gsAmount = fNumFormatFixed(gsUnit_Price)
    '            Else
    '                gsUnit_Price = numUnit_price.Value * -1
    '                L = T * (numUnit_price.Value / 100)
    '                gsAmount = fNumFormatFixed(L) * -1
    '            End If
    '    End Select
    'End Sub

    Private Sub numQty_Click(sender As Object, e As EventArgs) Handles numQty.Click
        fnumPadKeyToTouch(numQty, "ENTER QUANTITY")
    End Sub

    Private Sub numUnit_price_Click(sender As Object, e As EventArgs) Handles numUnit_price.Click
        fnumPadKeyToTouch(numUnit_price, "CHANGE PRICE")
    End Sub

    Private Sub xlblLabel_Amount_Click(sender As Object, e As EventArgs) Handles xlblLabel_Amount.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub xlblDISCOUNT_Click(sender As Object, e As EventArgs) Handles xlblDISCOUNT.Click

    End Sub

    Private Sub dgvSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvSearch.KeyPress

    End Sub

    Private Sub btnLIST_Click(sender As Object, e As EventArgs)
        frmItemExpired.ShowDialog()
        frmItemExpired.Dispose()
        frmItemExpired = Nothing
    End Sub

    Private Sub xlblSearch_Click(sender As Object, e As EventArgs) Handles xlblSearch.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class