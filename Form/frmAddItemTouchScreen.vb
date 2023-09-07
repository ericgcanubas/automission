Imports System.Data.Odbc
Public Class frmAddItemTouchScreen


    Dim BS_ITEM As BindingSource
    Dim ItemType As Integer
    Dim gsRate_Type As Integer
    Dim DISC_NAME As String
    Dim bSearching As Boolean = False
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
    Public gsBATCH_ID As Integer = 0

    Public gsLOCATION_ID As Integer
    Public gsDate As Date = Date.Now
    Dim Basic_Unit_ID As Integer = 0
    Dim _Unit_Rate As Double
    Private Sub fSearchEnter()
        bSearching = True
        Try
            If txtSearch.Text.Length = 0 Then
                dgvSearch.Visible = True
                Exit Sub
            End If
            BS_ITEM.Filter = $" (CODE like '%{txtSearch.Text}%') or (DESCRIPTION like '%{txtSearch.Text}%')  "
        Catch ex As Exception

        End Try
        bSearching = False
        Search_Select()
    End Sub
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
                numDiscountValue.Select()
            ElseIf numDiscountValue.Focused = True Then
                btnOK.Select()

            Else

                txtSearch.Focus()

            End If

        ElseIf e.KeyCode = Keys.Down Then
            If dgvSearch.Visible = True Then

                dgvSearch.Focus()

            End If
        ElseIf e.KeyCode = Keys.Up Then

            If dgvSearch.Focused = True Then
                If dgvSearch.CurrentRow.Index = 0 Then
                    txtSearch.Select()
                Else
                    dgvSearch.Select()
                End If
            End If

        ElseIf e.KeyCode = Keys.Escape Then


            If txtSearch.Focused = True Then
                btnClose.PerformClick()
            End If
            dgvSearch.Visible = True
            txtSearch.Focus()

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
    Private Sub fCategory_Class()
        flp_Category.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader("select  * from item_class ")
        While rd.Read
            Dim NewButton As New Button
            NewButton.Name = $"btnclass{rd(0)}"
            NewButton.Text = rd("description")
            NewButton.Size = New Size(88, 57)
            NewButton.BackColor = Color.DarkBlue
            NewButton.ForeColor = Color.White

            NewButton.AccessibleName = rd(0)
            NewButton.Tag = 0
            AddHandler NewButton.Click, AddressOf fButtonClass_Click
            flp_Category.Controls.Add(NewButton)

        End While
        rd.Close()


    End Sub
    Private Sub fButtonClass_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim Class_ID As Integer = btn.AccessibleName
        flp_Category.Controls.Clear()

        bSearching = True
        BS_ITEM.Filter = $" CLASS_ID ='{Class_ID}' "
        Dim rd As OdbcDataReader = SqlReader($"select  * from item_sub_class where class_id ='{Class_ID}' ")
        While rd.Read
            Dim NewButton As New Button
            NewButton.Name = $"btnsubclass{rd(0)}"
            NewButton.Text = rd("description")
            NewButton.Size = New Size(88, 57)
            NewButton.AccessibleName = rd(0)
            NewButton.BackColor = Color.DarkMagenta
            NewButton.ForeColor = Color.White
            NewButton.AccessibleDescription = rd("CLASS_ID")
            NewButton.Tag = 1
            AddHandler NewButton.Click, AddressOf fButtonSub_Class_Click
            flp_Category.Controls.Add(NewButton)
        End While
        rd.Close()
        bSearching = False
        Search_Select()

        Dim BackButton As New Button
        BackButton.Name = $"btnBACK"
        BackButton.Text = "Back"
        BackButton.BackColor = Color.Black
        BackButton.ForeColor = Color.White
        BackButton.Size = New Size(88, 57)
        AddHandler BackButton.Click, AddressOf fBackButton
        flp_Category.Controls.Add(BackButton)
    End Sub
    Private Sub fButtonSub_Class_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim sub_Class_ID As Integer = btn.AccessibleName
        bSearching = True
        BS_ITEM.Filter = $" SUB_CLASS_ID ='{sub_Class_ID}' "
        bSearching = False
        Search_Select()
    End Sub
    Private Sub fBackButton(sender As Object, e As EventArgs)
        fCategory_Class()

        bSearching = True
        BS_ITEM.Filter = $""
        bSearching = False
        Search_Select()
    End Sub
    Private Function fCHECK_ITEM_ONHAND(ByVal prITEM_ID As Integer, ByVal prDESCRIPTION As String, ByVal prQTY As Double) As Boolean
        Dim bON_HAND As Boolean = True
        Dim iQty As Double = fQTY_ACTUAL_ON_DATE_LOCATION(prITEM_ID, gsDate, gsLOCATION_ID)

        Dim nQTY As Double = (numQty.Value * IIf(Val(lblQty_Base.Text) = 0, 1, Val(lblQty_Base.Text))) + fdgvGetQty(prITEM_ID)

        If iQty - nQTY <= -1 Then
            MessageBoxExclamation($"Not allowed negative inventory on  {prDESCRIPTION}. { Environment.NewLine} { Environment.NewLine} Sorry, unable to proceed.")
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
        fMemberDiscount()
        numQty.Value = 1


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
                            T = NumberFormatFixed(.Cells("AMOUNT").Value)
                        Case 6 ' GROUP

                        Case 7 ' DISCOUNT
                            T = 0
                        Case Else
                            T = T + NumberFormatFixed(.Cells("AMOUNT").Value)
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

            lblAmount.Text = NumberFormatStandard(gsAmount)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub frmAddItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fMaterialSkin(Me)


        Dim gsItemCodeQuery_ As String
        Dim gsItemDescriptionQuery_ As String
        Dim gsItemSearchQuery_resto_ As String

        If gsCOST_AMOUNT_ONLY = False Then


            If gsMeasureHoursID <> 0 Then

                gsItemCodeQuery_ = $"select ID,CODE from item where inactive ='0' and `type` not in ('5','10') order by `CODE` "
                gsItemDescriptionQuery_ = $"select ID, DESCRIPTION from item where inactive ='0' and `type` not in ('5','10') and base_unit_id <> '{gsMeasureHoursID}' order by `DESCRIPTION`"
                gsItemSearchQuery_resto_ = $"SELECT i.ID, i.CODE, i.DESCRIPTION, UCASE(IFNULL(g.`DESCRIPTION`, IF(i.`TYPE` = 6,'GROUP SET',''))) AS `GROUP`,FORMAT(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` IN ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) AS `RATE`,i.SUB_CLASS_ID,sc.CLASS_ID,i.GROUP_ID FROM ITEM AS I LEFT OUTER JOIN  item_sub_class AS sc ON sc.ID =  i.SUB_CLASS_ID LEFT OUTER JOIN item_group AS g ON g.`ID` = i.`GROUP_ID`  WHERE  i.BUNDLE_SET = '0' AND i.INACTIVE = '0' AND  i.`type` NOT IN  ('6','5','10')
UNION
SELECT i.ID, i.CODE, i.DESCRIPTION, UCASE(IFNULL(g.`DESCRIPTION`, IF(i.`TYPE` = 6,'GROUP SET',''))) AS `GROUP`,FORMAT(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` IN ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) AS `RATE`,i.SUB_CLASS_ID,sc.CLASS_ID,i.GROUP_ID FROM ITEM AS I LEFT OUTER JOIN  item_sub_class AS sc ON sc.ID =  i.SUB_CLASS_ID LEFT OUTER JOIN item_group AS g ON g.`ID` = i.`GROUP_ID`  WHERE EXISTS (SELECT * FROM item_components AS ic WHERE ic.`ITEM_ID` ='{gsPOS_SELECTED_ROOM_ID}' AND i.`ID` = ic.`COMPONENT_ID` ) AND i.BUNDLE_SET = '0' AND i.INACTIVE = '0' AND  i.`type` NOT IN  ('1','2','3','4','5','10') "

                ComboBoxLoad(cmbItem_Code, gsItemCodeQuery_, "ID", "CODE")
                ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionQuery_, "ID", "DESCRIPTION")
                LoadDataGridViewBinding(dgvSearch, gsItemSearchQuery_resto_, BS_ITEM)
            Else

                ComboBoxLoad(cmbItem_Code, gsItemCodeQuery, "ID", "CODE")
                ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionQuery, "ID", "DESCRIPTION")
                LoadDataGridViewBinding(dgvSearch, gsItemSearchQuery_resto, BS_ITEM)
            End If

            fCategory_Class()

            '   dgvSearch.Columns("DESCRIPTION").Width = 100
            If dgvSearch.Columns.Count <> 0 Then
                dgvSearch.Columns("GROUP").Visible = False

                dgv.Columns("CODE").Visible = False

                dgvSearch.Columns("SUB_CLASS_ID").Visible = False
                dgvSearch.Columns("CLASS_ID").Visible = False
                dgvSearch.Columns("GROUP_ID").Visible = False
                dgvSearch.Columns("RATE").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                ' dgvSearch.Columns("RATE").Width = 70
                dgvSearch.Columns("RATE").Visible = False
                dgvSearch.Columns("RATE").DefaultCellStyle.Format = "N2"
                dgvSearch.Columns("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If

            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        ElseIf gsCOST_AMOUNT_ONLY = True And (sFormName = frmStockTransfer.Name Or sFormName = frmInventoryAdjustment.Name) Then
            ComboBoxLoad(cmbItem_Code, gsItemCodeZeroQuery, "ID", "CODE")
            ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionZeroQuery, "ID", "DESCRIPTION")
            LoadDataGridViewBinding(dgvSearch, gsItemSearchZeroQuery, BS_ITEM)

            '  dgvSearch.Columns(2).Width = 200
            dgvSearch.Columns(3).Width = 60
            dgvSearch.Columns("COST").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("COST").Width = 60
            dgvSearch.Columns("COST").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        Else
            ComboBoxLoad(cmbItem_Code, gsItemCodeCostQuery, "ID", "CODE")
            ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionCostQuery, "ID", "DESCRIPTION")
            LoadDataGridViewBinding(dgvSearch, gsItemSearchCostQuery, BS_ITEM)

            ' dgvSearch.Columns(2).Width = 250
            dgvSearch.Columns(3).Width = 60
            dgvSearch.Columns("COST").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvSearch.Columns("COST").Width = 80

            dgvSearch.Columns("COST").DefaultCellStyle.Format = "N2"
            dgvSearch.Columns("COST").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
        End If
        If dgvSearch.Columns.Count <> 0 Then
            dgvSearch.Columns(0).Visible = False
            dgvSearch.Columns(1).Visible = False
        End If

        ComboBoxLoad(cmbDiscount_Type, "select '' as ID, '' as DESCRIPTION  FROM discount_type  UNION select ID,DESCRIPTION FROM discount_type ", "ID", "DESCRIPTION")

        ClearAndRefresh(Me)
        If gsItem_ID <> "" Then
            cmbItem_Code.SelectedValue = gsItem_ID
            cmbItem_DESCRIPTION.SelectedValue = gsItem_ID
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
            FindItemToolStripMenuItem.Enabled = False
            txtSearch.Visible = True

            cmbUM_SelectedIndexChanged(sender, e)
            cmbItem_Code_LostFocus(sender, e)
            Me.Text = "EDIT ITEMS"
            sFormName = ""
        Else
            Me.Text = "ADD ITEMS"
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


            fComputation()

        Else
            numQty.Value = 1
        End If

        If gsSelection = True Then
            xlblSelection.Visible = True
            cmbSelection.Visible = True
            xlblSelection.Text = gsSelection_Label
            ComboBoxLoad(cmbSelection, gsSelection_Query, gsSelection_VALUE, gsSelection_DESCRIPTION)

            If Trim(gsSelection_ID) <> "" Then
                cmbSelection.SelectedValue = gsSelection_ID
            End If
        Else
            xlblSelection.Visible = True
            xlblSelection.Text = "On Hand :"
        End If

        If gsCOST_AMOUNT_ONLY = False Then
            xlblnum_price.Text = "PRICE :"
        Else
            xlblnum_price.Text = "Cost :"
        End If



        fDoEvents()
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


        'for awhile
        xxxlblPrice_level.Visible = False
        cmbPRICE_LEVEL.Visible = False

        xxxlblUnitTYpe.Visible = False
        cmbUM.Visible = False



        xlblITEM_ID.Visible = False
        xxxlblCODE.Visible = False

        numDiscountValue.Visible = False
        cmbDiscount_Type.Visible = False


        btnN_DISC.Visible = False
        btnP_DISC.Visible = False

        xlblDISCOUNT.Visible = False

        xxxDISCOUNT_VALUE.Visible = False

        chkTax.Visible = False
        dgvSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvSearch.Columns("DESCRIPTION").Width = 200
        dgvSearch.Columns("RATE").Width = 70
    End Sub



    Private Sub numUnit_price_ValueChanged(sender As Object, e As EventArgs)
        fComputation()
    End Sub

    Private Sub fDiscount_Effect()
        If gsNON_DISCOUNTED_ITEM = False Then



            Try
                Select Case NumIsNull(cmbDiscount_Type.SelectedValue)

                    Case 0
                        numDiscountValue.Enabled = True
                        numDiscountValue.DecimalPlaces = 2
                        numDiscountValue.Maximum = 999999999999
                    Case 1
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
        dgvSearch.Visible = True

        BlueLight(numQty)
        xlblOnHand.Text = fQTY_ACTUAL_ON_DATE_LOCATION(cmbItem_Code.SelectedValue, gsDate, gsLOCATION_ID)
        If NumIsNull(cmbItem_Code.SelectedValue) = 0 Then
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
        ComboBoxLoad(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
        If cmbPRICE_LEVEL.Items.Count = 1 Then
            cmbPRICE_LEVEL.Visible = False
            xxxlblPrice_level.Visible = False
            cmbPRICE_LEVEL.CausesValidation = True

            btnPLNeg.Visible = False
            btnPLPO.Visible = False
        Else
            cmbPRICE_LEVEL.Visible = True
            xxxlblPrice_level.Visible = True
            btnPLNeg.Visible = True
            btnPLPO.Visible = True
        End If

    End Sub
    Private Sub fCheckPriceLevel_UNIT(ByVal prItem_ID As Double, ByVal prUnit_ID As Double)
        If gsCOST_AMOUNT_ONLY = True Then
            'Must only price 
            Exit Sub
        End If

        Dim rd As OdbcDataReader = SqlReader($"SELECT pl.`ID`,pl.`CODE` FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{prItem_ID}' AND n.`UNIT_ID` = '{prUnit_ID}' AND pl.`INACTIVE` = '0' and pl.TYPE ='1'")
        If rd.Read Then
            cmbPRICE_LEVEL.CausesValidation = False
            Dim pl_SQL As String = $"select * from ((SELECT  '0'  AS ID  ,'Default' AS `CODE`) UNION (SELECT pl.`ID`,pl.`CODE` FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{prItem_ID}' AND n.`UNIT_ID` = '{prUnit_ID}' AND pl.`INACTIVE` = '0' and pl.TYPE ='1' )) as T order by T.ID"
            ComboBoxLoad(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
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
            btnOK.Text = " OK"
            btnClose.Text = " Close"

            chkTax.Checked = gsTax
            numUnit_price.Value = gsUnit_Price
        Else
            btnOK.Text = " ADD"
            btnClose.Text = "Close"
        End If
        fMemberDiscount()
        fDiscount_Effect()


        dgvSearch.Columns("DESCRIPTION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        Search_Select()
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
        BlueLight(numUnit_price)
        dgvSearch.Visible = True
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

                    Dim rd As OdbcDataReader = SqlReader("select i.NON_PORFOLIO_COMPUTATION,i.PIC_FILENAME,i.NON_DISCOUNTED_ITEM,i.BUNDLE_SET,i.TYPE,
i.COST,
(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`)) as `RATE`,
i.BASE_UNIT_ID,
i.TAXABLE from ITEM as i WHERE i.ID ='" & cmbPrimary.SelectedValue & "' Limit 1")

                    If rd.Read Then
                        If gsUseImageProduct = True Then

                            fDisplayPhoto(TextIsNull(rd("PIC_FILENAME")), picItem)


                        End If
                        ItemType = NumIsNull(rd("TYPE"))
                        gsNON_PORFOLIO_COMPUTATION = NumIsNull(rd("NON_PORFOLIO_COMPUTATION"))
                        gsNON_DISCOUNTED_ITEM = NumIsNull(rd("NON_DISCOUNTED_ITEM"))
                        If gsCOST_AMOUNT_ONLY = True And ItemType = 0 Then
                            _Unit_Rate = NumIsNull(rd("COST"))
                        Else

                            _Unit_Rate = NumIsNull(rd("RATE"))

                        End If

                        If ItemType <= 3 Then
                            Basic_Unit_ID = NumIsNull(rd("BASE_UNIT_ID"))
                            chkTax.Checked = NumIsNull(rd("TAXABLE"))

                        Else
                            Basic_Unit_ID = 0

                            chkTax.Checked = NumIsNull(rd("TAXABLE"))
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
                    in_sql = in_sql & ")"
                    ComboBoxLoad(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID " & in_sql, "ID", "SYMBOL")
                    cmbUM.SelectedValue = Basic_Unit_ID
                    lblQty_Base.Text = "1"
                Else
                    ComboBoxLoad(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID ='xxx' limit 1", "ID", "SYMBOL")
                End If

                If Val(gsUM) <> 0 Then
                    cmbUM.SelectedValue = Val(gsUM)
                Else

                    BlueLight(numQty)
                    fComputation()
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
                gsRate_Type = GetNumberFieldValue("ITEM", "ID", cmbItem_Code.SelectedValue, "RATE_TYPE")
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
                gsRate_Type = GetNumberFieldValue("ITEM", "ID", cmbItem_Code.SelectedValue, "RATE_TYPE")
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
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try



    End Sub





    Private Sub numDiscountValue_GotFocus(sender As Object, e As EventArgs) Handles numDiscountValue.GotFocus
        BlueLight(numDiscountValue)
        dgvSearch.Visible = True
    End Sub

    Private Sub cmbUM_GotFocus(sender As Object, e As EventArgs) Handles cmbUM.GotFocus
        fLOadUNitPrize()
        dgvSearch.Visible = True
    End Sub

    Private Sub NumQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged
        fComputation()
    End Sub


    Private Sub fLOadUNitPrize()
        If ItemType <= 4 Then


            If Basic_Unit_ID = NumIsNull(cmbUM.SelectedValue) Then

                lblQty_Base.Text = "1"

                If lblAmount.Visible = True Then
                    If _Unit_Rate <> 0 Then

                        numUnit_price.Enabled = gsUserPriceLock
                        If numUnit_price.Value = 0 Then
                            numUnit_price.Value = _Unit_Rate
                            BlueLight(numUnit_price)
                        End If

                    Else

                        numUnit_price.Value = 0
                        BlueLight(numUnit_price)
                    End If

                End If

            Else

                Try
                    If gsCOST_AMOUNT_ONLY = False Then

                        lblQty_Base.Text = "1"
                        numUnit_price.Value = _Unit_Rate
                        If cmbUM.SelectedValue Is Nothing Then Exit Sub

                        Dim rd As OdbcDataReader = SqlReader("select quantity as q, rate as r from item_units where unit_id = '" & NumIsNull(cmbUM.SelectedValue) & "' and item_id ='" & cmbItem_Code.SelectedValue & "' limit 1")
                        If rd.Read Then
                            If NumIsNull(rd("q")) <> 0 Then
                                lblQty_Base.Text = NumIsNull(rd("q"))
                            End If

                            If lblAmount.Visible = True Then

                                If NumIsNull(rd("r")) <> 0 Then
                                    numUnit_price.Value = rd("r")
                                End If
                            End If
                        End If
                        rd.Close()
                    End If
                Catch ex As Exception
                    If MessageBoxErrorYesNo(ex.Message) = True Then
                        fLOadUNitPrize()

                    Else
                        End
                    End If

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
        Dim UNIT_ID As Double = NumIsNull(DirectCast(sender, ComboBox).SelectedValue)
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
                Dim rd As OdbcDataReader = SqlReader($"select type,rate from price_level where id = '{cmbPRICE_LEVEL.SelectedValue}' limit 1")
                If rd.Read Then
                    If NumIsNull(rd("type")) = 0 Then
                        'Fixed
                        Dim DISCOUNT_LESS As Double = _Unit_Rate * IIf(NumIsNull(rd("rate")) < 100, CDbl(0 & "." & Format(NumIsNull(rd("rate")), "00")), 1)
                        numUnit_price.Value = _Unit_Rate - DISCOUNT_LESS
                    ElseIf NumIsNull(rd("type")) = 1 Then
                        'Per Item
                        numUnit_price.Value = GetNumberFieldValueByTwoCondition("Price_level_lines", "Price_level_ID", cmbPRICE_LEVEL.SelectedValue, "ITEM_ID", cmbItem_Code.SelectedValue, "CUSTOM_PRICE")
                    End If
                End If
                rd.Close()

            Else
                ' Unit Price Level
                ' get price_level_Type
                Dim rd As OdbcDataReader = SqlReader($"SELECT u.`CUSTOM_PRICE`  FROM item_unit_price_levels AS u INNER JOIN price_level AS pl ON pl.`ID` = u.`PRICE_LEVEL_ID` INNER JOIN item_units AS n ON n.ID = u.ITEM_UNIT_LINE_ID WHERE n.ITEM_ID = '{cmbItem_Code.SelectedValue}' AND n.`UNIT_ID` = '{cmbUM.SelectedValue}' AND pl.ID ='{cmbPRICE_LEVEL.SelectedValue}' AND pl.`INACTIVE` = '0' AND pl.type ='1'  limit 1")
                If rd.Read Then
                    'Fixed
                    numUnit_price.Value = NumIsNull(rd("CUSTOM_PRICE"))
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

                    BlueLight(numQty)
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
        Search_Select()
    End Sub


    Private Sub Search_Select()
        If dgvSearch.Rows.Count <> 0 Then
            dgvSearch.Focus()
            cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            xlblDESCRIPTION.Text = dgvSearch.CurrentRow.Cells(2).Value
            dgvSearch.Visible = True


            fItemSelected(cmbItem_Code, cmbItem_DESCRIPTION)
        End If
    End Sub
    Private Sub cmbItem_DESCRIPTION_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbItem_DESCRIPTION.KeyPress

    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        fSearchEnter()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

        fMaster_KeyDown(sender, e)




    End Sub

    Private Sub cmbItem_Code_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.GotFocus
        dgvSearch.Visible = True
    End Sub

    Private Sub cmbItem_DESCRIPTION_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.SelectedIndexChanged

    End Sub

    Private Sub cmbItem_DESCRIPTION_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.GotFocus
        dgvSearch.Visible = True
    End Sub

    Private Sub cmbPRICE_LEVEL_GotFocus(sender As Object, e As EventArgs) Handles cmbPRICE_LEVEL.GotFocus
        dgvSearch.Visible = True
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
                fDoEvents()

                dgvSearch.Visible = True

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
            Dim AllowedNI As Boolean = fAllowNegativeInventory()
            If AllowedNI = False Then

                Dim rd_group As OdbcDataReader = SqlReader($"SELECT i.ID as `ITEM_ID`,i.`DESCRIPTION`,ic.`Quantity`,i.`TYPE` FROM item_components AS ic INNER JOIN item AS i ON i.`ID` = ic.`COMPONENT_ID` WHERE ic.item_id = '{cmbItem_Code.SelectedValue}' ")
                While rd_group.Read

                    If fCHECK_ITEM_ONHAND(rd_group("ITEM_ID"), rd_group("DESCRIPTION"), rd_group("Quantity")) = False Then
                        Exit Sub
                    End If

                End While
                rd_group.Close()
            End If

        End If



        If IsDiscountItem(ItemType) = True Or IsOtherChargeItem(ItemType) = True Then

        Else
            If numQty.Value = 0 Then
                MessageBoxInfo("Please enter value for quantity")
                numQty.Focus()
                Exit Sub
            End If
        End If

        If sFormName = "" Or sFormName = frmInventoryAdjustment.Name Then

            'gsSave = True
            'gsItem_ID = cmbItem_Code.SelectedValue
            'gsItem_Description = cmbItem_DESCRIPTION.Text
            'gsQty = numQty.Value
            'gsUM = cmbUM.SelectedValue
            'gsBase_Qty = Val(lblQty_Base.Text)
            'gsUnit_Price = numUnit_price.Value
            'gsDiscount_Type = cmbDiscount_Type.SelectedValue
            'gsDiscount_Rate = numDiscountValue.Value



            'gsTax = chkTax.Checked
            'gsPRICE_LEVEL_ID = cmbPRICE_LEVEL.SelectedValue
            'If gsSelection = True Then
            '    gsSelection_ID = cmbSelection.SelectedValue
            'End If
            'fComputation()
            'If frmInventoryAdjustment.Name = sFormName Then
            '    If IsNew = True Then
            '        fAddItem_Inventory_Row(dgv, IsNew, gsItem_ID, gsUM, gsQty, gsBase_Qty, gsUnit_Price, "A", gsLOCATION_ID, gsDate)
            '        dgv.Focus()
            '        dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
            '        fClearAll()
            '    End If
            'Else
            '    Me.Close()
            'End If


        Else
            fComputation()
            gsSave = False
            gsItem_ID = cmbItem_Code.SelectedValue
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
            Dim bDiscount_item As Boolean = IsDiscountItem(ItemType)

            'checking if is discount
            Dim D_TYPE As Integer = 0
            DISC_OTH_DECT = False
            gsRate_Type = 0
            If ItemType = 4 Or ItemType = 7 Then
                gsRate_Type = GetNumberFieldValue("ITEM", "ID", gsItem_ID, "RATE_TYPE")
                DISC_NAME = GetStringFieldValue("DISCOUNT_TYPE", "ID", gsRate_Type, "DESCRIPTION")
                DISC_OTH_DECT = True
            End If








            If DISC_OTH_DECT = False Then
                gsDate = Date.Now()
                Select Case sFormName
                    'Case frmStockTransfer.Name

                    '    ' fRow_Data_StockTransfer(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A")
                    '    GoTo down_now

                    'Case frmStockReceived.Name
                    '    fRow_Data_StockReceived(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A", 0)
                    '    GoTo down_now
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
                        'Case frmBills.Name.ToString
                        '    fRow_Data_Item_Bill(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, "")
                        'Case frmBillCredit.Name.ToString
                        '    fRow_Data_Item_Bill_Credit(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID)
                        'Case frmPurchaseOrder.Name.ToString
                        '    fRow_Data_Item_Purchase_Order(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, 0)
                        'Case frmPurchaseRequest.Name.ToString
                        '    fRow_Data_Item_Purchase_Request(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount)
                        'Case frmWriteCheck.Name.ToString
                        '    fRow_Data_Item_Write_Check(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID)

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


                Dim T As Double = fTotal_NOW(dgv)
                Dim L As Double = 0
                Select Case sFormName
                    Case frmInvoice.Name
                        'SUB TOTAL
                        '  fRow_Data_Item_Invoice(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", gsPRICE_LEVEL_ID, 0)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Invoice(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, 0, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmCreditMemo.Name
                        'SUB TOTAL
                        ' fRow_Data_Item_Credit_Memo(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, gsPRICE_LEVEL_ID, 0)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Credit_Memo(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, 0, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmSalesOrder.Name
                        'SUB TOTAL
                        ' fRow_Data_Item_Sales_Order(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", gsPRICE_LEVEL_ID)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)
                        fRow_Data_Item_Sales_Order(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, False, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case frmSalesReceipt.Name
                        'SUB TOTAL
                        ' fRow_Data_Item_Sales_Receipt(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, gsPRICE_LEVEL_ID)
                        gsAmount = fDISCOUNT_OTHERCHARGE(T, ItemType, gsRate_Type, gsUnit_Price)

                        fRow_Data_Item_Sales_Receipt(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, False, 0, 0)
                        fSales_Customer_Computation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)

                        'Case frmBills.Name
                        '    'SUB TOTAL
                        '    ' fRow_Data_Item_Bill(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", "")
                        '    fDISCOUNT_OTHERCHARGE(T)
                        '    fRow_Data_Item_Bill(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", "")

                        'Case frmBillCredit.Name
                        '    'SUB TOTAL
                        '    '  fRow_Data_Item_Bill_Credit(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "")
                        '    fDISCOUNT_OTHERCHARGE(T)
                        '    fRow_Data_Item_Bill_Credit(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "")

                        'Case frmPurchaseOrder.Name
                        '    'SUB TOTAL
                        '    'fRow_Data_Item_Purchase_Order(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, 0)
                        '    fDISCOUNT_OTHERCHARGE(T)
                        '    fRow_Data_Item_Purchase_Order(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, 0)

                        'Case frmWriteCheck.Name
                        '    'SUB TOTAL
                        '    ' fRow_Data_Item_Write_Check(dgv, True, GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "")
                        '    fDISCOUNT_OTHERCHARGE(T)
                        '    fRow_Data_Item_Write_Check(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "")

                End Select
                dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
            End If
            fClearAll()
            Search_Select()
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


    Private Sub dgvSearch_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellClick
        ' Search_Select()
    End Sub

    Private Sub dgvSearch_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSearch.SelectionChanged
        If bSearching = False Then
            Search_Select()
        End If
    End Sub

    Private Sub btnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        BS_ITEM.MovePrevious()
    End Sub

    Private Sub btnDOWN_Click(sender As Object, e As EventArgs) Handles btnDOWN.Click
        BS_ITEM.MoveNext()
    End Sub

    Private Sub btnN_QTY_Click(sender As Object, e As EventArgs) Handles btnN_QTY.Click
        Try
            numQty.Value = numQty.Value - 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try


    End Sub

    Private Sub btnP_QTY_Click(sender As Object, e As EventArgs) Handles btnP_QTY.Click
        Try
            numQty.Value = numQty.Value + 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub btnN_Price_Click(sender As Object, e As EventArgs) Handles btnN_Price.Click
        Try
            numUnit_price.Value = numUnit_price.Value - 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub btnP_Price_Click(sender As Object, e As EventArgs) Handles btnP_Price.Click
        Try
            numUnit_price.Value = numUnit_price.Value + 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub btnN_DISC_Click(sender As Object, e As EventArgs) Handles btnN_DISC.Click

        If cmbDiscount_Type.SelectedIndex = 0 Then Exit Sub

        Try
            numDiscountValue.Value = numDiscountValue.Value - 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub btnP_DISC_Click(sender As Object, e As EventArgs) Handles btnP_DISC.Click
        If cmbDiscount_Type.SelectedIndex = 0 Then Exit Sub

        Try
            numDiscountValue.Value = numDiscountValue.Value + 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub numQty_Click(sender As Object, e As EventArgs) Handles numQty.Click
        fnumPadKeyToTouch(numQty, xlblQTY.Text)
    End Sub

    Private Sub numUnit_price_Click(sender As Object, e As EventArgs) Handles numUnit_price.Click

        If numUnit_price.Enabled = True Then
            fnumPadKeyToTouch(numUnit_price, xlblnum_price.Text)
        Else

            If MessageBoxErrorYesNo("SSSSS") = True Then


            End If

        End If

    End Sub

    Private Sub numDiscountValue_Click(sender As Object, e As EventArgs) Handles numDiscountValue.Click
        fnumPadKeyToTouch(numDiscountValue, $"DISCOUNT {cmbDiscount_Type.Text}")
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        fKeyBoardToTouch(txtSearch, "SEARCH ITEM")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnUTPO.Click

    End Sub
End Class