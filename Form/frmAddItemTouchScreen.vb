Imports System.Data.Odbc
Public Class FrmAddItemTouchScreen


    Dim BS_ITEM As BindingSource
    Dim ItemType As Integer
    Dim gsRate_Type As Integer
    Dim DISC_NAME As String
    Dim bSearching As Boolean = False
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
    Private Sub SearchKeyEnter()
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
        SearchSelector()
    End Sub
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
    Private Sub LoadCategoryClass()
        flp_Category.Controls.Clear()
        Dim rd As OdbcDataReader = SqlReader("select  * from item_class ")
        While rd.Read
            Using NewButton As New Button With {
                .Name = $"btnclass{rd(0)}",
                .Text = rd("description"),
                .Size = New Size(88, 57),
                .BackColor = Color.DarkBlue,
                .ForeColor = Color.White,
                .AccessibleName = rd(0),
                .Tag = 0
            }
                AddHandler NewButton.Click, AddressOf ButtonClass_Click
                flp_Category.Controls.Add(NewButton)
            End Using
        End While
        rd.Close()


    End Sub
    Private Sub ButtonClass_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim Class_ID As Integer = btn.AccessibleName
        flp_Category.Controls.Clear()

        bSearching = True
        BS_ITEM.Filter = $" CLASS_ID ='{Class_ID}' "
        Dim rd As OdbcDataReader = SqlReader($"select  * from item_sub_class where class_id ='{Class_ID}' ")
        While rd.Read
            Using NewButton As New Button With {
                .Name = $"btnsubclass{rd(0)}",
                .Text = rd("description"),
                .Size = New Size(88, 57),
                .AccessibleName = rd(0),
                .BackColor = Color.DarkMagenta,
                .ForeColor = Color.White,
                .AccessibleDescription = rd("CLASS_ID"),
                .Tag = 1
            }
                AddHandler NewButton.Click, AddressOf ButtonSub_Class_Click
                flp_Category.Controls.Add(NewButton)
            End Using
        End While
        rd.Close()
        bSearching = False
        SearchSelector()

        Dim BackButton As New Button With {
            .Name = $"btnBACK",
            .Text = "Back",
            .BackColor = Color.Black,
            .ForeColor = Color.White,
            .Size = New Size(88, 57)
        }
        AddHandler BackButton.Click, AddressOf Me.BackButton
        flp_Category.Controls.Add(BackButton)
    End Sub
    Private Sub ButtonSub_Class_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim sub_Class_ID As Integer = btn.AccessibleName
        bSearching = True
        BS_ITEM.Filter = $" SUB_CLASS_ID ='{sub_Class_ID}' "
        bSearching = False
        SearchSelector()
    End Sub
    Private Sub BackButton(sender As Object, e As EventArgs)
        LoadCategoryClass()

        bSearching = True
        BS_ITEM.Filter = $""
        bSearching = False
        SearchSelector()
    End Sub
    Private Function IsItemOnHand(ByVal prITEM_ID As Integer, ByVal prDESCRIPTION As String, ByVal prQTY As Double) As Boolean
        Dim bON_HAND As Boolean = True
        Dim iQty As Double = QtyActualOnDateLocation(prITEM_ID, gsDate, gsLOCATION_ID)

        Dim nQTY As Double = (numQty.Value * IIf(Val(lblQty_Base.Text) = 0, 1, Val(lblQty_Base.Text))) + GetQty(prITEM_ID)

        If iQty - nQTY <= -1 Then
            MessageBoxExclamation($"Not allowed negative inventory on  {prDESCRIPTION}. { Environment.NewLine} { Environment.NewLine} Sorry, unable to proceed.")
            bON_HAND = False
        End If

        Return bON_HAND
    End Function

    Private Function GetQty(ByVal prITEM_ID As Integer) As Double
        Dim qty As Double = 0
        If dgv.Rows.Count <> 0 Then

            For I As Integer = 0 To dgv.Rows.Count - 1
                If dgv.Rows(I).Cells("ITEM_ID").Value = prITEM_ID Then
                    qty += (dgv.Rows(I).Cells("QTY").Value * Val(dgv.Rows(I).Cells("UNIT_QUANTITY_BASE").Value))
                End If
            Next
        End If
        Return qty
    End Function



    Private Sub FormClearAll()
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
        MemberDiscount()
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
    Private Function GetTotalNow(ByVal dgv As DataGridView) As Double
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
                            T += NumberFormatFixed(.Cells("AMOUNT").Value)
                    End Select

                End If

            End With
        Next

        Return T
    End Function

    Private Sub Computation()
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

                GS_ComboBoxLoad(cmbItem_Code, gsItemCodeQuery_, "ID", "CODE")
                GS_ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionQuery_, "ID", "DESCRIPTION")
                GS_LoadDataGridViewBinding(dgvSearch, gsItemSearchQuery_resto_, BS_ITEM)
            Else

                GS_ComboBoxLoad(cmbItem_Code, gsItemCodeQuery, "ID", "CODE")
                GS_ComboBoxLoad(cmbItem_DESCRIPTION, gsItemDescriptionQuery, "ID", "DESCRIPTION")
                GS_LoadDataGridViewBinding(dgvSearch, gsItemSearchQuery_resto, BS_ITEM)
            End If

            LoadCategoryClass()

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

        GS_ComboBoxLoad(cmbDiscount_Type, "select '' as ID, '' as DESCRIPTION  FROM discount_type  UNION select ID,DESCRIPTION FROM discount_type ", "ID", "DESCRIPTION")

        ClearAndRefresh(Me)
        If gsItem_ID <> "" Then
            cmbItem_Code.SelectedValue = gsItem_ID
            cmbItem_DESCRIPTION.SelectedValue = gsItem_ID
            cmbItem_Code.Enabled = False
            cmbItem_DESCRIPTION.Enabled = False
            FindItemToolStripMenuItem.Enabled = False
            txtSearch.Visible = True


            CmbItem_Code_LostFocus(sender, e)
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
                        SetCheckPriceLevelUnit(gsItem_ID, gsUM)
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


            Computation()

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
            xlblSelection.Visible = True
            xlblSelection.Text = "On Hand :"
        End If

        If gsCOST_AMOUNT_ONLY = False Then
            xlblnum_price.Text = "PRICE :"
        Else
            xlblnum_price.Text = "Cost :"
        End If



        GS_DoEvents()
        DiscountEffects()

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



    Private Sub NumUnit_price_ValueChanged(sender As Object, e As EventArgs)
        Computation()
    End Sub

    Private Sub DiscountEffects()
        If gsNON_DISCOUNTED_ITEM = False Then
            Try
                Select Case GF_NumIsNull(cmbDiscount_Type.SelectedValue)

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

                Computation()
            Catch ex As Exception

            End Try

        Else
            cmbDiscount_Type.SelectedIndex = -1

            numDiscountValue.Enabled = False
            numDiscountValue.Value = 0

            Computation()
        End If
    End Sub
    Private Sub CmbDiscount_Type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiscount_Type.SelectedIndexChanged

        DiscountEffects()
    End Sub

    Private Sub NumDiscountValue_ValueChanged(sender As Object, e As EventArgs) Handles numDiscountValue.ValueChanged
        Computation()
    End Sub
    Private Sub NumQty_GotFocus(sender As Object, e As EventArgs) Handles numQty.GotFocus
        dgvSearch.Visible = True
        BlueLight(numQty)
        xlblOnHand.Text = QtyActualOnDateLocation(cmbItem_Code.SelectedValue, gsDate, gsLOCATION_ID)
        If GF_NumIsNull(cmbItem_Code.SelectedValue) = 0 Then
            txtSearch.Focus()
        End If
    End Sub
    Private Sub CmbItem_DESCRIPTION_LostFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.LostFocus
        ItemSelection(cmbItem_DESCRIPTION, cmbItem_Code)
    End Sub
    Private Sub CmbItem_Code_LostFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.LostFocus

        ItemSelection(cmbItem_Code, cmbItem_DESCRIPTION)

    End Sub

    Private Sub SetCheckPriceLevel(ByVal prItem_ID As Double)
        If gsCOST_AMOUNT_ONLY = True Then
            'Must only price 
            Exit Sub
        End If

        Dim pl_SQL As String = $"select * from ((SELECT  '0'  AS ID  ,'Default' AS `CODE`) UNION (SELECT  pl.ID, pl.`CODE` FROM price_level AS  pl WHere pl.TYPE = '0' and pl.Inactive = '0' ) UNION (SELECT  pl.ID, pl.`CODE` FROM price_level_lines AS pll INNER JOIN price_level AS  pl ON pl.`ID`= pll.`PRICE_LEVEL_ID` WHERE pll.`ITEM_ID` = '{prItem_ID}' and pl.INACTIVE ='0' and pl.Type ='1' )) as T order by T.ID"
        GS_ComboBoxLoad(cmbPRICE_LEVEL, pl_SQL, "ID", "CODE")
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
    Private Sub SetCheckPriceLevelUnit(ByVal prItem_ID As Double, ByVal prUnit_ID As Double)
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
            SetCheckPriceLevel(prItem_ID)
        End If
        rd.Close()
    End Sub
    Private Sub FrmAddItem_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If sFormName = "" Then
            btnOK.Text = " OK"
            btnClose.Text = " Close"

            chkTax.Checked = gsTax
            numUnit_price.Value = gsUnit_Price
        Else
            btnOK.Text = " ADD"
            btnClose.Text = "Close"
        End If
        MemberDiscount()
        DiscountEffects()


        dgvSearch.Columns("DESCRIPTION").DefaultCellStyle.WrapMode = DataGridViewTriState.True
        SearchSelector()
    End Sub
    Private Sub MemberDiscount()
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
        Computation()
    End Sub

    Private Sub NumQty_LostFocus(sender As Object, e As EventArgs) Handles numQty.LostFocus
        Computation()
        If sFormName <> "" Then
            If cmbUM.SelectedValue IsNot Nothing Then

            End If
        End If

    End Sub



    Private Sub NumUnit_price_GotFocus(sender As Object, e As EventArgs) Handles numUnit_price.GotFocus
        BlueLight(numUnit_price)
        dgvSearch.Visible = True
    End Sub



    Private Sub ItemSelection(ByVal cmbPrimary As ComboBox, cmbSecondary As ComboBox)
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

                            GS_DisplayPhoto(GF_TextIsNull(rd("PIC_FILENAME")), picItem)


                        End If
                        ItemType = GF_NumIsNull(rd("TYPE"))
                        gsNON_PORFOLIO_COMPUTATION = GF_NumIsNull(rd("NON_PORFOLIO_COMPUTATION"))
                        gsNON_DISCOUNTED_ITEM = GF_NumIsNull(rd("NON_DISCOUNTED_ITEM"))
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
                    cmbUM.SelectedValue = Basic_Unit_ID
                    lblQty_Base.Text = "1"
                Else
                    GS_ComboBoxLoad(cmbUM, "select ID,SYMBOL from unit_of_measure where  ID ='xxx' limit 1", "ID", "SYMBOL")
                End If

                If Val(gsUM) <> 0 Then
                    cmbUM.SelectedValue = Val(gsUM)
                Else

                    BlueLight(numQty)
                    Computation()
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
                    SetCheckPriceLevel(cmbPrimary.SelectedValue)

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




            LoadItemUnitPrice()
            DiscountEffects()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try



    End Sub
    Private Sub NumDiscountValue_GotFocus(sender As Object, e As EventArgs) Handles numDiscountValue.GotFocus
        BlueLight(numDiscountValue)
        dgvSearch.Visible = True
    End Sub

    Private Sub CmbUM_GotFocus(sender As Object, e As EventArgs) Handles cmbUM.GotFocus
        LoadItemUnitPrice()
        dgvSearch.Visible = True
    End Sub

    Private Sub NumQty_ValueChanged(sender As Object, e As EventArgs) Handles numQty.ValueChanged
        Computation()
    End Sub


    Private Sub LoadItemUnitPrice()
        If ItemType <= 4 Then


            If Basic_Unit_ID = GF_NumIsNull(cmbUM.SelectedValue) Then

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

                        Dim rd As OdbcDataReader = SqlReader("select quantity as q, rate as r from item_units where unit_id = '" & GF_NumIsNull(cmbUM.SelectedValue) & "' and item_id ='" & cmbItem_Code.SelectedValue & "' limit 1")
                        If rd.Read Then
                            If GF_NumIsNull(rd("q")) <> 0 Then
                                lblQty_Base.Text = GF_NumIsNull(rd("q"))
                            End If

                            If lblAmount.Visible = True Then

                                If GF_NumIsNull(rd("r")) <> 0 Then
                                    numUnit_price.Value = rd("r")
                                End If
                            End If
                        End If
                        rd.Close()
                    End If
                Catch ex As Exception
                    If MessageBoxErrorYesNo(ex.Message) = True Then
                        LoadItemUnitPrice()

                    Else
                        End
                    End If

                End Try

            End If
        End If
    End Sub

    Private Sub CmbUM_LostFocus(sender As Object, e As EventArgs) Handles cmbUM.LostFocus
        LoadItemUnitPrice()
    End Sub
    Private Sub NumUnit_price_ValueChanged_1(sender As Object, e As EventArgs) Handles numUnit_price.ValueChanged
        Computation()
    End Sub
    Private Sub CmbUM_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbUM.SelectedIndexChanged
        Dim UNIT_ID As Double = GF_NumIsNull(DirectCast(sender, ComboBox).SelectedValue)
        LoadItemUnitPrice()
        SetCheckPriceLevelUnit(cmbItem_Code.SelectedValue, UNIT_ID)
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
                'Primary Price Level
                ' get price_level_Type
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
        Computation()

    End Sub

    Private Sub CmbUM_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbUM.KeyDown
        If e.KeyCode = Keys.Enter Then
            numUnit_price.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            txtSearch.Focus()

        End If
        ' cmbItem_Code_KeyDown(sender, e)
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
                    Computation()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub NumDiscountValue_TextChanged(sender As Object, e As EventArgs) Handles numDiscountValue.TextChanged
        Computation()
    End Sub

    Private Sub NumQty_TextChanged(sender As Object, e As EventArgs) Handles numQty.TextChanged
        Computation()
    End Sub

    Private Sub DgvSearch_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSearch.CellDoubleClick
        SearchSelector()
    End Sub
    Private Sub SearchSelector()
        If dgvSearch.Rows.Count <> 0 Then
            dgvSearch.Focus()
            cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
            xlblDESCRIPTION.Text = dgvSearch.CurrentRow.Cells(2).Value
            dgvSearch.Visible = True
            ItemSelection(cmbItem_Code, cmbItem_DESCRIPTION)
        End If
    End Sub
    Private Sub TxtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        SearchKeyEnter()
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown

        MasterKeyDown(sender, e)




    End Sub

    Private Sub CmbItem_Code_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_Code.GotFocus
        dgvSearch.Visible = True
    End Sub

    Private Sub CmbItem_DESCRIPTION_GotFocus(sender As Object, e As EventArgs) Handles cmbItem_DESCRIPTION.GotFocus
        dgvSearch.Visible = True
    End Sub

    Private Sub CmbPRICE_LEVEL_GotFocus(sender As Object, e As EventArgs) Handles cmbPRICE_LEVEL.GotFocus
        dgvSearch.Visible = True
    End Sub
    Private Sub DgvSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            If dgvSearch.Rows.Count <> 0 Then

                cmbItem_Code.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
                cmbItem_DESCRIPTION.SelectedValue = dgvSearch.CurrentRow.Cells(0).Value
                ItemSelection(cmbItem_Code, cmbItem_DESCRIPTION)
                GS_DoEvents()

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
            If numQty.Value = 0 Then
                MessageBoxInfo("Please enter value for quantity")
                numQty.Focus()
                Exit Sub
            End If
        End If

        If sFormName = "" Or sFormName = FrmInventoryAdjustment.Name Then

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
            'ItemComputation()
            'If frmInventoryAdjustment.Name = sFormName Then
            '    If IsNew = True Then
            '        GS_AddItemInventoryRow(dgv, IsNew, gsItem_ID, gsUM, gsQty, gsBase_Qty, gsUnit_Price, "A", gsLOCATION_ID, gsDate)
            '        dgv.Focus()
            '        dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
            '        ClearAllFromForm()
            '    End If
            'Else
            '    Me.Close()
            'End If


        Else
            Computation()
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
                    'Case frmStockTransfer.Name

                    '    ' GS_RowDataStockTransfer(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A")
                    '    GoTo down_now

                    'Case frmStockReceived.Name
                    '    GS_RowDataStockReceived(dgv, True, gsItem_ID, gsQty, gsBase_Qty, gsUM, gsUnit_Price, gsAmount, "A", 0)
                    '    GoTo down_now
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
                        'Case frmBills.Name.ToString
                        '    GS_RowDataItemBills(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID, "")
                        'Case frmBillCredit.Name.ToString
                        '    GS_RowDataItemBillCredit(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID)
                        'Case frmPurchaseOrder.Name.ToString
                        '    GS_RowDataItemPurchaseOrder(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, 0)
                        'Case frmPurchaseRequest.Name.ToString
                        '    GS_RowDataItemPurchaseRequest(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount)
                        'Case frmWriteCheck.Name.ToString
                        '    GS_RowDataItemWriteCheck(dgv, True, gsItem_ID, gsQty, gsUnit_Price, cmbDiscount_Type.Text, gsDiscount_Rate, gsAmount, gsTax, cmbUM.SelectedValue, "A", gsBase_Qty, gsDiscount_Type, gsOriginal_Amount, gsSelection_ID)

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


                Dim T As Double = GetTotalNow(dgv)

                Select Case sFormName
                    Case FrmInvoice.Name
                        'SUB TOTAL
                        '  GS_RowDataItemInvoice(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", gsPRICE_LEVEL_ID, 0)
                        gsAmount = GS_DiscountOtherCharge(T, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemInvoice(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, 0, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmCreditMemo.Name
                        'SUB TOTAL
                        ' GS_RowDataItemCreditMemo(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, gsPRICE_LEVEL_ID, 0)
                        gsAmount = GS_DiscountOtherCharge(T, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemCreditMemo(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, 0, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmSalesOrder.Name
                        'SUB TOTAL
                        ' GS_RowDataItemSalesOrder(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", gsPRICE_LEVEL_ID)
                        gsAmount = GS_DiscountOtherCharge(T, ItemType, gsRate_Type, gsUnit_Price)
                        GS_RowDataItemSalesOrder(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", gsPRICE_LEVEL_ID, False, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)
                    Case FrmSalesReceipt.Name
                        'SUB TOTAL
                        ' GS_RowDataItemSalesReceipt(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, gsPRICE_LEVEL_ID)
                        gsAmount = GS_DiscountOtherCharge(T, ItemType, gsRate_Type, gsUnit_Price)

                        GS_RowDataItemSalesReceipt(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, gsPRICE_LEVEL_ID, False, 0, 0)
                        GS_SalesCustomerComputation(dgv, gscmbOUTPUT_TAX_ID, gslblOUTPUT_TAX_AMOUNT, gslblAMOUNT, gslblTAXABLE_AMOUNT, gslblNONTAXABLE_AMOUNT, gslblOUTPUT_TAX_RATE, gsSalesSubTotal)

                        'Case frmBills.Name
                        '    'SUB TOTAL
                        '    ' GS_RowDataItemBills(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "", "")
                        '    GS_DiscountOtherCharge(T)
                        '    GS_RowDataItemBills(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "", "")

                        'Case frmBillCredit.Name
                        '    'SUB TOTAL
                        '    '  GS_RowDataItemBillCredit(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "")
                        '    GS_DiscountOtherCharge(T)
                        '    GS_RowDataItemBillCredit(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "")

                        'Case frmPurchaseOrder.Name
                        '    'SUB TOTAL
                        '    'GS_RowDataItemPurchaseOrder(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, 0)
                        '    GS_DiscountOtherCharge(T)
                        '    GS_RowDataItemPurchaseOrder(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, 0)

                        'Case frmWriteCheck.Name
                        '    'SUB TOTAL
                        '    ' GS_RowDataItemWriteCheck(dgv, True, GF_GetStringFieldValue("ITEM", "TYPE", "5", "ID"), 0, 0, "", "", T, False, "", "A", 0, "", T, "")
                        '    GS_DiscountOtherCharge(T)
                        '    GS_RowDataItemWriteCheck(dgv, True, gsItem_ID, 0, gsUnit_Price, DISC_NAME, "", gsAmount, gsTax, "", "A", 0, gsRate_Type, gsAmount, "")

                End Select
                dgv.CurrentCell = dgv.Rows(dgv.Rows.Count - 1).Cells(ColumnViews(dgv)) 'Last Row HighLight
            End If
            FormClearAll()
            SearchSelector()
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
    Private Sub DgvSearch_SelectionChanged(sender As Object, e As EventArgs) Handles dgvSearch.SelectionChanged
        If bSearching = False Then
            SearchSelector()
        End If
    End Sub

    Private Sub BtnUP_Click(sender As Object, e As EventArgs) Handles btnUP.Click
        BS_ITEM.MovePrevious()
    End Sub

    Private Sub BtnDOWN_Click(sender As Object, e As EventArgs) Handles btnDOWN.Click
        BS_ITEM.MoveNext()
    End Sub

    Private Sub BtnN_QTY_Click(sender As Object, e As EventArgs) Handles btnN_QTY.Click
        Try
            numQty.Value = numQty.Value - 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try


    End Sub

    Private Sub BtnP_QTY_Click(sender As Object, e As EventArgs) Handles btnP_QTY.Click
        Try
            numQty.Value = numQty.Value + 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub BtnN_Price_Click(sender As Object, e As EventArgs) Handles btnN_Price.Click
        Try
            numUnit_price.Value = numUnit_price.Value - 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub BtnP_Price_Click(sender As Object, e As EventArgs) Handles btnP_Price.Click
        Try
            numUnit_price.Value = numUnit_price.Value + 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub BtnN_DISC_Click(sender As Object, e As EventArgs) Handles btnN_DISC.Click

        If cmbDiscount_Type.SelectedIndex = 0 Then Exit Sub

        Try
            numDiscountValue.Value = numDiscountValue.Value - 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub BtnP_DISC_Click(sender As Object, e As EventArgs) Handles btnP_DISC.Click
        If cmbDiscount_Type.SelectedIndex = 0 Then Exit Sub

        Try
            numDiscountValue.Value = numDiscountValue.Value + 1
        Catch ex As Exception
            MessageBoxInfo(ex.Message)
        End Try
    End Sub

    Private Sub NumQty_Click(sender As Object, e As EventArgs) Handles numQty.Click
        NumberPadKeyToTouch(numQty, xlblQTY.Text)
    End Sub

    Private Sub NumUnit_price_Click(sender As Object, e As EventArgs) Handles numUnit_price.Click

        If numUnit_price.Enabled = True Then
            NumberPadKeyToTouch(numUnit_price, xlblnum_price.Text)
        End If

    End Sub

    Private Sub NumDiscountValue_Click(sender As Object, e As EventArgs) Handles numDiscountValue.Click
        NumberPadKeyToTouch(numDiscountValue, $"DISCOUNT {cmbDiscount_Type.Text}")
    End Sub

    Private Sub TxtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        KeyBoardToTouch(txtSearch, "SEARCH ITEM")
    End Sub
End Class