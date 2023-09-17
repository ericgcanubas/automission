Imports System.Globalization
Imports System.Drawing.Imaging
Imports System.Data.Odbc
Public Class FrmItemDetails
    Public GoLoad As Boolean = True
    Public bMain As Boolean = False
    Public IsNew As Boolean
    Public ID As Integer
    Public dgv As DataGridView
    Public this_BS As BindingSource
    Public bFirstLoad As Boolean = False
    Dim GetUploadImage As String

    Private Function GetUpdateSQL() As String

        Dim SqlUnit = SqlUpdate(tpUnits)
        Dim SqlComponents = SqlUpdate(tpComponents)
        Dim Result As String = SqlUpdate(Me) & "," & SqlUpdate(tpInfo) & "," & SqlUpdate(tpOther) & IIf(SqlUnit = "", "", "," & SqlUnit) & IIf(SqlComponents = "", "", "," & SqlComponents)
        Return Result
    End Function
    Private Sub GetInsertSQL(ByRef RefField As String, ByRef RefValue As String)

        Dim SQL_Field1 As String = ""
        Dim SQL_Value1 As String = ""
        SqlCreate(Me, SQL_Field1, SQL_Value1)

        Dim SQL_Field2 As String = ""
        Dim SQL_Value2 As String = ""
        SqlCreate(tpInfo, SQL_Field2, SQL_Value2)

        Dim SQL_Field3 As String = ""
        Dim SQL_Value3 As String = ""
        SqlCreate(tpOther, SQL_Field3, SQL_Value3)

        Dim SQL_Field4 As String = ""
        Dim SQL_Value4 As String = ""
        SqlCreate(tpUnits, SQL_Field4, SQL_Value4)

        Dim SQL_Field5 As String = ""
        Dim SQL_Value5 As String = ""
        SqlCreate(tpComponents, SQL_Field5, SQL_Value5)

        RefField = $"{SQL_Field1},{SQL_Field2},{SQL_Field3},{SQL_Field4},{SQL_Field5}"
        RefValue = $"{SQL_Value1},{SQL_Value2},{SQL_Value3},{SQL_Value4},{SQL_Value5}"
    End Sub

    Private Sub TypeOfItems(ByVal ItemTypeId As Integer)
        chkNON_PORFOLIO_COMPUTATION.Text = "NON-Computation"
        cmbRATE_TYPE.SelectedValue = 0
        rtbPURCHASE_DESCRIPTION.Clear()
        cmbPREFERRED_VENDOR_ID.SelectedValue = 0
        cmbMANUFACTURER_ID.SelectedValue = 0
        rtbDESCRIPTION.Clear()
        numCOST.Value = 0
        numRATE.Value = 0
        cmbCOGS_ACCOUNT_ID.SelectedValue = 0
        cmbASSET_ACCOUNT_ID.SelectedValue = 0
        cmbGL_ACCOUNT_ID.SelectedValue = 0
        chkTAXABLE.Checked = True
        cmbSTOCK_TYPE.SelectedValue = 0
        cmbGROUP_ID.SelectedValue = 0
        cmbCLASS_ID.SelectedValue = 0
        cmbSUB_CLASS_ID.SelectedValue = 0
        cmbBASE_UNIT_ID.SelectedIndex = 1

        cmbRATE_TYPE.Visible = False

        GS_ComboBoxLoad(cmbGROUP_ID, " select '0' as ID ,' ' as `Description` union select id,description from item_group where item_type = '" & ItemTypeId & "'", "ID", "DESCRIPTION")


        Select Case ItemTypeId
            Case 0 ' Inventory item
                'per object
                ControlItemInventory()
                PriceLevelLoad()

                OrderPreference()
                RefreshUnit_RelatedUnit()
            Case 1 ' Inventory Assembly
                ControlItemAssembly()
                tpComponents.Text = "Item Components"

                PriceLevelLoad()
                ComponentsColumn()
                ComponentLoad()
                OrderPreference()
                RefreshUnit_RelatedUnit()
            Case 2 ' Non-Inventory Item

                ControlNonItemInventory()

                RefreshUnit_RelatedUnit()
            Case 3 ' Service
                ControlItemServices()
                RefreshUnit_RelatedUnit()
            Case 4 ' Other Charge
                ControlOtherCharges()
            Case 5 ' sub total

                ControlItemSubTotal()
            Case 6 ' Group
                chkNON_PORFOLIO_COMPUTATION.Text = "Customize Select"
                ControlItemGroup()
                ComponentsColumnGroup()
                ComponentsByGroup()
            Case 7 ' Discount
                ControlItemDiscount()
            Case 8 ' Payment
                ControlPayment()
            Case 9

                ControlMenu()
                tpComponents.Text = "Ingredients list"

                PriceLevelLoad()
                ComponentsColumn()
                ComponentLoad()
                OrderPreference()
                RefreshUnit_RelatedUnit()

            Case 10

                ControlMenu()
                tpComponents.Text = "Item Hours"

                ' PriceLevelLoad()
                ComponentsColumn()
                ComponentLoad()
                dgvComponents.Columns("QTY").Visible = False
                dgvComponents.Columns("RATE").Visible = False
                'OrderPreference()
                'RefreshUnit_RelatedUnit()
        End Select



        'If tpComponents.Enabled = False And tpInventory.Enabled = False And tpUnits.Enabled = False And tpPriceLevel.Enabled = False Then
        '    TabControl1.Visible = False
        'Else
        '    TabControl1.Visible = True
        '    If tpComponents.Enabled = True Then
        '        TabControl1.SelectedIndex = 0
        '    ElseIf tpInventory.Enabled = True Then
        '        TabControl1.SelectedIndex = 1
        '    ElseIf tpUnits.Enabled = True Then
        '        TabControl1.SelectedIndex = 2
        '    ElseIf tpPriceLevel.Enabled = True Then
        '        TabControl1.SelectedIndex = 3
        '    End If
        'End If



        SetDefault()




    End Sub
    Private Sub ControlItemInventory()
        xlblPurchase_Description.Enabled = True
        rtbPURCHASE_DESCRIPTION.Enabled = True

        xlblPreferered.Enabled = True
        cmbPREFERRED_VENDOR_ID.Enabled = True

        xlblManufacture.Enabled = True
        cmbMANUFACTURER_ID.Enabled = True

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = True
        numCOST.Enabled = True

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = True
        cmbCOGS_ACCOUNT_ID.Enabled = True

        xlblASSET_ACCOUNT.Enabled = True
        cmbASSET_ACCOUNT_ID.Enabled = True

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = True
        cmbSTOCK_TYPE.Enabled = True


        xlblGROUP.Enabled = True
        cmbGROUP_ID.Enabled = True

        xlblCLASS.Enabled = True
        cmbCLASS_ID.Enabled = True

        xlblSUB_Class.Enabled = True
        cmbSUB_CLASS_ID.Enabled = True

        btnBrowse.Enabled = True
        btnDelete.Enabled = True




        tpComponents.Enabled = False
        tpInventory.Enabled = True
        tpUnits.Enabled = True
        tpPriceLevel.Enabled = True
    End Sub
    Private Sub ControlItemAssembly()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True


        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = True
        cmbCOGS_ACCOUNT_ID.Enabled = True

        xlblASSET_ACCOUNT.Enabled = True
        cmbASSET_ACCOUNT_ID.Enabled = True

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = True
        cmbSTOCK_TYPE.Enabled = True


        xlblGROUP.Enabled = True
        cmbGROUP_ID.Enabled = True

        xlblCLASS.Enabled = True
        cmbCLASS_ID.Enabled = True

        xlblSUB_Class.Enabled = True
        cmbSUB_CLASS_ID.Enabled = True

        btnBrowse.Enabled = True
        btnDelete.Enabled = True



        '========================
        tpComponents.Enabled = True
        tpInventory.Enabled = True
        tpUnits.Enabled = True
        tpPriceLevel.Enabled = True

    End Sub
    Private Sub ControlMenu()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True


        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = True
        cmbGROUP_ID.Enabled = True

        xlblCLASS.Enabled = True
        cmbCLASS_ID.Enabled = True

        xlblSUB_Class.Enabled = True
        cmbSUB_CLASS_ID.Enabled = True

        btnBrowse.Enabled = True
        btnDelete.Enabled = True



        '========================
        tpComponents.Enabled = True
        tpInventory.Enabled = False
        tpUnits.Enabled = False
        tpPriceLevel.Enabled = False

    End Sub
    Private Sub ControlNonItemInventory()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = True
        cmbGROUP_ID.Enabled = True

        xlblCLASS.Enabled = True
        cmbCLASS_ID.Enabled = True

        xlblSUB_Class.Enabled = True
        cmbSUB_CLASS_ID.Enabled = True

        btnBrowse.Enabled = True
        btnDelete.Enabled = True



        '========================


        tpComponents.Enabled = False
        tpInventory.Enabled = False
        tpUnits.Enabled = True
        tpPriceLevel.Enabled = True

    End Sub
    Private Sub ControlItemServices()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = True
        cmbGROUP_ID.Enabled = True

        xlblCLASS.Enabled = True
        cmbCLASS_ID.Enabled = True

        xlblSUB_Class.Enabled = True
        cmbSUB_CLASS_ID.Enabled = True

        btnBrowse.Enabled = True
        btnDelete.Enabled = True


        '===============
        tpComponents.Enabled = False
        tpInventory.Enabled = False
        tpUnits.Enabled = True
        tpPriceLevel.Enabled = True
    End Sub
    Private Sub ControlOtherCharges()
        cmbRATE_TYPE.Visible = True
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = False
        cmbGROUP_ID.Enabled = False

        xlblCLASS.Enabled = False
        cmbCLASS_ID.Enabled = False

        xlblSUB_Class.Enabled = False
        cmbSUB_CLASS_ID.Enabled = False

        btnBrowse.Enabled = False
        btnDelete.Enabled = False


        '=================
        tpComponents.Enabled = False
        tpInventory.Enabled = False
        tpUnits.Enabled = True
        tpPriceLevel.Enabled = True
        RefreshUnit_RelatedUnit()
    End Sub

    Private Sub ControlItemSubTotal()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = False
        numRATE.Enabled = False

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = False
        cmbGL_ACCOUNT_ID.Enabled = False

        chkTAXABLE.Enabled = False

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = False
        cmbGROUP_ID.Enabled = False

        xlblCLASS.Enabled = False
        cmbCLASS_ID.Enabled = False

        xlblSUB_Class.Enabled = False
        cmbSUB_CLASS_ID.Enabled = False

        btnBrowse.Enabled = False
        btnDelete.Enabled = False


        '===============
        tpComponents.Enabled = False
        tpInventory.Enabled = False
        tpUnits.Enabled = False
        tpPriceLevel.Enabled = False
    End Sub
    Private Sub ControlItemDiscount()
        cmbRATE_TYPE.Visible = True
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = True
        numRATE.Enabled = True

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = True

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = False
        cmbGROUP_ID.Enabled = False

        xlblCLASS.Enabled = False
        cmbCLASS_ID.Enabled = False

        xlblSUB_Class.Enabled = False
        cmbSUB_CLASS_ID.Enabled = False

        btnBrowse.Enabled = False
        btnDelete.Enabled = False

        tpComponents.Enabled = False
        tpInventory.Enabled = False
        tpUnits.Enabled = False
        tpPriceLevel.Enabled = False
    End Sub
    Private Sub ControlPayment()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = False
        numRATE.Enabled = False

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = True
        cmbGL_ACCOUNT_ID.Enabled = True

        chkTAXABLE.Enabled = False

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False


        xlblGROUP.Enabled = False
        cmbGROUP_ID.Enabled = False

        xlblCLASS.Enabled = False
        cmbCLASS_ID.Enabled = False

        xlblSUB_Class.Enabled = False
        cmbSUB_CLASS_ID.Enabled = False

        btnBrowse.Enabled = False
        btnDelete.Enabled = False


        tpComponents.Enabled = False
        tpInventory.Enabled = False
        tpUnits.Enabled = False
        tpPriceLevel.Enabled = False
    End Sub

    Private Sub ControlItemGroup()
        xlblPurchase_Description.Enabled = False
        rtbPURCHASE_DESCRIPTION.Enabled = False

        xlblPreferered.Enabled = False
        cmbPREFERRED_VENDOR_ID.Enabled = False

        xlblManufacture.Enabled = False
        cmbMANUFACTURER_ID.Enabled = False

        xlblDescription.Enabled = True
        rtbDESCRIPTION.Enabled = True

        xlblCOST.Enabled = False
        numCOST.Enabled = False

        xlblRate.Enabled = False
        numRATE.Enabled = False

        xlblCOGS_ACCOUNT.Enabled = False
        cmbCOGS_ACCOUNT_ID.Enabled = False

        xlblASSET_ACCOUNT.Enabled = False
        cmbASSET_ACCOUNT_ID.Enabled = False

        xlblINCOME_ACCOUNT.Enabled = False
        cmbGL_ACCOUNT_ID.Enabled = False

        chkTAXABLE.Enabled = False

        xlblStock_TYPE.Enabled = False
        cmbSTOCK_TYPE.Enabled = False



        xlblGROUP.Enabled = False
        cmbGROUP_ID.Enabled = False

        xlblCLASS.Enabled = True
        cmbCLASS_ID.Enabled = True
        xlblSUB_Class.Enabled = True
        cmbSUB_CLASS_ID.Enabled = True
        btnBrowse.Enabled = False
        btnDelete.Enabled = False

        tpComponents.Text = "Item List"


        tpComponents.Enabled = True
        tpInventory.Enabled = False
        tpUnits.Enabled = False
        tpPriceLevel.Enabled = False
    End Sub

    Private Sub RefreshComboBox()

        cmbASSET_ACCOUNT_ID.Visible = gsShowAccounts
        xlblASSET_ACCOUNT.Visible = gsShowAccounts

        cmbGL_ACCOUNT_ID.Visible = gsShowAccounts
        xlblINCOME_ACCOUNT.Visible = gsShowAccounts

        cmbCOGS_ACCOUNT_ID.Visible = gsShowAccounts
        xlblCOGS_ACCOUNT.Visible = gsShowAccounts

        Dim sql_statement As String = " select '0' as ID ,' ' as `NAME` union SELECT  a.ID, a.NAME FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE "
        GS_ComboBoxLoad(cmbASSET_ACCOUNT_ID, sql_statement, "ID", "NAME")
        GS_ComboBoxLoad(cmbGL_ACCOUNT_ID, sql_statement, "ID", "NAME")
        GS_ComboBoxLoad(cmbCOGS_ACCOUNT_ID, sql_statement, "ID", "NAME")


        GS_ComboBoxLoad(cmbPREFERRED_VENDOR_ID, "select ID,NAME from contact where type = '0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbMANUFACTURER_ID, "select ID, `NAME`  from manufacturer", "ID", "NAME")
        GS_ComboBoxLoad(cmbSTOCK_TYPE, "Select ID,DESCRIPTION from stock_type_map", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbRATE_TYPE, "Select ID,DESCRIPTION from rate_type_map", "ID", "DESCRIPTION")

        sql_statement = "select '0' as ID ,' ' as `NAME` union select ID, NAME as T from unit_of_measure where inactive='0'"
        GS_ComboBoxLoad(cmbBASE_UNIT_ID, sql_statement, "ID", "NAME")
        GS_ComboBoxLoad(cmbPURCHASES_UNIT_ID, sql_statement, "ID", "NAME")
        GS_ComboBoxLoad(cmbSALES_UNIT_ID, sql_statement, "ID", "NAME")
        GS_ComboBoxLoad(cmbSHIPPING_UNIT_ID, sql_statement, "ID", "NAME")
        GS_ComboBoxLoad(cmbCLASS_ID, "select '0' as ID ,' ' as `DESCRIPTION` union  Select ID,DESCRIPTION from item_class", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbSUB_CLASS_ID, "select '0' as ID ,' ' as `DESCRIPTION` union  Select ID,DESCRIPTION from item_sub_class ", "ID", "DESCRIPTION")

        GS_ComboBoxLoad(cmbTYPE, "select ID,DESCRIPTION from item_type_map WHERE INACTIVE = '0' ", "ID", "DESCRIPTION")
        GoLoad = False
        cmbTYPE.SelectedIndex = -1
        cmbTYPE.SelectedIndex = 0

    End Sub

    Private Sub FrmItemDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshComboBox()
        Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
        GeneralRefresh()

    End Sub
    Private Sub GeneralRefresh()
        bFirstLoad = True
        Dim tmp_sc As Integer = gsDefaultItemSubClassId
        Dim tmp_c As Integer = gsDefaultItemClassId
        If IsNew = False Then
            RefreshForm()
            Me.Text = "Update Item"
            cmbTYPE.Enabled = False
            tmp_sc = GF_GetNumberFieldValue("item", "id", ID, "sub_class_id")
            tmp_c = GF_GetNumberFieldValue("item_sub_class", "id", tmp_sc, "CLASS_ID")
        Else
            Me.Text = "Create Item"
            chkPRINT_INDIVIDUAL_ITEMS.Checked = GetSystemSettingValueByBool("InvisibleGroup")
        End If
        'checking
        Select Case cmbTYPE.SelectedValue
            Case 1
                ControlItemInventory()
            Case 2
                ControlItemAssembly()
            Case 3
                ControlNonItemInventory()
            Case 4
                ControlItemServices()
            Case 5
                ControlItemSubTotal()
            Case 6
                ControlItemGroup()
            Case 7
                ControlOtherCharges()
            Case 8
                ControlPayment()
        End Select
        bFirstLoad = False
        cmbCLASS_ID.SelectedIndex = -1
        cmbSUB_CLASS_ID.SelectedIndex = -1
        cmbCLASS_ID.SelectedValue = tmp_c
        cmbSUB_CLASS_ID.SelectedValue = tmp_sc


    End Sub
    Private Sub SetDefault()

        If IsNew = True Then
            txtCODE.Text = GF_GetNextItemCode(cmbTYPE.SelectedValue)
        End If

        If cmbTYPE.SelectedValue <= 1 Then
            cmbCOGS_ACCOUNT_ID.SelectedValue = gsDefaultItemCOGSAccountId
            cmbGL_ACCOUNT_ID.SelectedValue = gsDefaultItemIncomeAccountId
            cmbASSET_ACCOUNT_ID.SelectedValue = gsDefaultItemAssetAccountId
            cmbSTOCK_TYPE.SelectedIndex = 0
            cmbCLASS_ID.SelectedValue = gsDefaultItemClassId
            cmbSUB_CLASS_ID.SelectedValue = gsDefaultItemSubClassId

        ElseIf cmbTYPE.SelectedValue <= 3 Then

            cmbCOGS_ACCOUNT_ID.SelectedValue = 0
            cmbASSET_ACCOUNT_ID.SelectedValue = 0
            cmbSTOCK_TYPE.SelectedIndex = 0


            cmbGL_ACCOUNT_ID.SelectedValue = gsDefaultItemIncomeAccountId
            cmbCLASS_ID.SelectedValue = gsDefaultItemClassId
            cmbSUB_CLASS_ID.SelectedValue = gsDefaultItemSubClassId

        ElseIf cmbTYPE.SelectedIndex = 4 Then
            'other charge
            cmbCOGS_ACCOUNT_ID.SelectedValue = 0
            cmbGL_ACCOUNT_ID.SelectedValue = gsDefaultItemOtherChargeAccountId
            cmbASSET_ACCOUNT_ID.SelectedValue = 0
            cmbSTOCK_TYPE.SelectedIndex = 0
            cmbCLASS_ID.SelectedValue = 0
            cmbSUB_CLASS_ID.SelectedValue = 0
        ElseIf cmbTYPE.SelectedIndex = 7 Then
            'discount
            cmbCOGS_ACCOUNT_ID.SelectedValue = 0
            cmbGL_ACCOUNT_ID.SelectedValue = gsDefaultItemDiscountAccountId
            cmbASSET_ACCOUNT_ID.SelectedValue = 0
            cmbSTOCK_TYPE.SelectedIndex = 0
            cmbCLASS_ID.SelectedValue = 0
            cmbSUB_CLASS_ID.SelectedValue = 0

        ElseIf cmbTYPE.SelectedIndex = 9 Then

            cmbGL_ACCOUNT_ID.SelectedValue = gsDefaultItemIncomeAccountId
            cmbSTOCK_TYPE.SelectedIndex = 0
            cmbCLASS_ID.SelectedValue = gsDefaultItemClassId
            cmbSUB_CLASS_ID.SelectedValue = gsDefaultItemSubClassId
            chkPRINT_INDIVIDUAL_ITEMS.Checked = True

        End If



        Select Case cmbTYPE.SelectedValue
            Case 0
                chkTAXABLE.Checked = True
            Case 1
                chkTAXABLE.Checked = True

            Case 9
                chkTAXABLE.Checked = True
        End Select

    End Sub
    Private Sub RefreshForm()

        Try

            Dim sQuery As String = "SELECT
`TYPE`,  
`ID`,
  `CODE`,
  `DESCRIPTION`,
  `PURCHASE_DESCRIPTION`,
  `GROUP_ID`,
  `SUB_CLASS_ID`,
  `STOCK_TYPE`,
  `GL_ACCOUNT_ID`,
  `COGS_ACCOUNT_ID`,
  `ASSET_ACCOUNT_ID`,
  `TAXABLE`,
  `PREFERRED_VENDOR_ID`,
  `MANUFACTURER_ID`,
  `RATE`,
  `COST`,
  `RATE_TYPE`,
  `PAYMENT_METHOD_ID`,
  `NOTES`,
  `BASE_UNIT_ID`,
  `PURCHASES_UNIT_ID`,
  `SHIPPING_UNIT_ID`,
  `SALES_UNIT_ID`,
  `PRINT_INDIVIDUAL_ITEMS`,
  `PICTURE`,
  `INACTIVE`,
  `CUSTOM_FIELD1`,
  `CUSTOM_FIELD2`,
  `CUSTOM_FIELD3`,
  `CUSTOM_FIELD4`,
  `CUSTOM_FIELD5`,
  `NON_PORFOLIO_COMPUTATION`,
  `BUNDLE_SET`,
  `NON_DISCOUNTED_ITEM`,
  `PIC_FILENAME`,
   `IS_EXPIRED`
   from item where id = '" & ID & "' Limit 1"

            SqlExecutedUsingReading(Me, sQuery)
            ' TypeOfItems(cmbTYPE)

            If gsUseImageProduct = True Then

                GetUploadImage = ""
                GS_DisplayPhoto(lblPIC_FILENAME.Text, picItem)

            End If

        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub


    Private Sub CmbTYPE_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbTYPE.SelectedValueChanged
        Try
            If GoLoad = False Then
                TypeOfItems(Val(cmbTYPE.SelectedValue))
            End If
        Catch ex As Exception
            MessageBoxErrorYesNo(ex.Message)
        End Try
    End Sub
    Private Sub PriceLevelLoad()
        If dgvPriceLevel.Columns.Count = 0 Then
            With dgvPriceLevel.Columns
                .Clear()
                .Add("PRICE_LEVEL_ID", "ID")
                .Item("PRICE_LEVEL_ID").Visible = False

                .Add("PRICE_LEVEL", "Rate Level")

                .Add("CUSTOM_PRICE", "Custom Rate")
                .Item("CUSTOM_PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Add("STATUS", "STATUS")
                .Item("STATUS").Visible = False

                .Add("PRICE_LEVEL_LINES_ID", "PRICE_LEVEL_LINES_ID")
                .Item("PRICE_LEVEL_LINES_ID").Visible = False
            End With
            GS_ViewNotSort(dgvPriceLevel)
        End If

        dgvPriceLevel.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader(" SELECT p.`ID` as PRICE_LEVEL_ID ,p.`DESCRIPTION` as `PRICE_LEVEL`,format( pll.`CUSTOM_PRICE`,2) as `CUSTOM_PRICE`,pll.ID as `PRICE_LEVEL_LINE_ID` FROM price_level AS p LEFT OUTER JOIN price_level_lines AS pll ON p.id = pll.`PRICE_LEVEL_ID` AND pll.`ITEM_ID` ='" & ID & "' WHERE p.`TYPE` = '1' ")
        While rd.Read

            dgvPriceLevel.Rows.Add(rd("PRICE_LEVEL_ID"), GF_TextIsNull(rd("PRICE_LEVEL")), GF_TextIsNull(rd("CUSTOM_PRICE")), "s", GF_TextIsNull(rd("PRICE_LEVEL_LINE_ID")))

        End While

    End Sub
    Private Function IsItemCode() As Boolean
        Dim b As Boolean = False

        Try

            Dim rd As OdbcDataReader = SqlReader("select code from item where code = '" & txtCODE.Text & "' Limit 1")
            If rd.Read Then
                b = True
            Else
                b = False
            End If

            rd.Close()
            Return b
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
            Return b
        End Try
    End Function
    Private Sub DataSql(ByVal prDATA As String, ByVal ITEM_UNITS_ID As Integer)

        Dim Data As String = prDATA
        Dim DataID As String = ""
        Dim PRICE_LEVEL_ID As String = ""
        Dim PRICE_LEVEL As String = ""
        Dim CUSTOM_PRICE As String = ""
        Dim STATUS As String = ""
        If Data <> "" Then
            Dim Rnum As Integer = 0
            For N As Double = 0 To Data.Length - 1
                Dim S As String = Data.Substring(N, 1)
                If S = "," Then
                    Rnum += 1

                ElseIf S = ";" Then

                    Select Case STATUS
                        Case "s"

                        Case "n"
                            SqlExecuted($" INSERT INTO item_unit_price_levels  SET PRICE_LEVEL_ID = '{PRICE_LEVEL_ID}', CUSTOM_PRICE='{CUSTOM_PRICE}',ITEM_UNIT_LINE_ID='{ITEM_UNITS_ID}',ID='{ObjectTypeMapId("ITEM_UNIT_PRICE_LEVELS")}';")
                        Case "e"
                            SqlExecuted($" UPDATE item_unit_price_levels SET PRICE_LEVEL_ID = '{PRICE_LEVEL_ID}', CUSTOM_PRICE='{CUSTOM_PRICE}' WHERE ITEM_UNIT_LINE_ID='{ITEM_UNITS_ID}' and ID='{DataID}' Limit 1;")
                        Case "d"
                            SqlExecuted($" DELETE FROM item_unit_price_levels WHERE ITEM_UNIT_LINE_ID='{ITEM_UNITS_ID}' and ID='{DataID}' Limit 1;")
                    End Select

                    DataID = ""
                    PRICE_LEVEL_ID = ""
                    PRICE_LEVEL = ""
                    CUSTOM_PRICE = ""
                    STATUS = ""
                    Rnum = 0

                Else

                    Select Case Rnum
                        Case 0
                            DataID &= S
                        Case 1
                            PRICE_LEVEL_ID &= S
                        Case 2
                            PRICE_LEVEL &= S
                        Case 3
                            CUSTOM_PRICE &= S
                        Case 4
                            STATUS &= S
                    End Select
                End If
            Next
        End If

    End Sub

    Private Sub DgvPriceLevel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPriceLevel.CellDoubleClick
        tsRateLevelsClick.PerformClick()
    End Sub
    Private Sub ComponentsColumn()
        With dgvComponents.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("CODE", "Code")
            .Add("DESCRIPTION", "Description")
            .Add("QTY", "Qty")
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("RATE", "Rate")
            .Item("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("RATE").DefaultCellStyle.Format = "N2"
            If cmbTYPE.SelectedValue = 9 Then
                .Item("RATE").Visible = False
            Else
                .Item("RATE").Visible = True
            End If

            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
        End With
        With dgvComponents
            .Columns(1).Width = 100
            .Columns(2).Width = 200

            If cmbTYPE.SelectedValue = 9 Then
                .Columns(3).Width = 30
                .Columns(4).Width = 0
            Else
                .Columns(3).Width = 70
                .Columns(4).Width = 80
            End If

        End With
        GS_ViewNotSort(dgvComponents)
    End Sub

    Private Sub ComponentLoad()

        Dim TotalRate As Double = 0
        dgvComponents.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT ic.ID,i.Code,i.`DESCRIPTION`,ic.`Quantity`,ic.`Rate`,i.ID as `ITEM_ID` FROM item_components AS ic INNER JOIN item AS i ON i.`ID` = ic.`COMPONENT_ID` WHERE ic.item_id = '{ID}' ")
        While rd.Read
            dgvComponents.Rows.Add(rd("ID"), rd("CODE"), rd("DESCRIPTION"), GF_NumIsNull(rd("Quantity")), GF_NumIsNull(rd("RATE")), "s", rd("ITEM_ID"))
            TotalRate += GF_NumIsNull(rd("RATE"))
        End While
        numRATE.Value = TotalRate
        With dgvComponents
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 100
            .Columns(4).Width = 100
        End With
    End Sub
    Private Sub ComponentsColumnGroup()
        With dgvComponents.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("CODE", "Code")
            .Add("DESCRIPTION", "Description")
            .Add("QTY", "Qty")
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Add("RATE", "Rate")
            .Item("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("RATE").DefaultCellStyle.Format = "N2"
            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
        End With
        With dgvComponents
            .Columns(1).Width = 100
            .Columns(2).Width = 200
            .Columns(3).Width = 70
            .Columns(4).Width = 80
        End With
        GS_ViewNotSort(dgvComponents)
    End Sub
    Private Sub ComponentsByGroup()
        dgvComponents.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT ic.ID,i.Code,i.`DESCRIPTION`,ic.`Quantity`,ic.`Rate`,i.ID as `ITEM_ID` FROM item_components AS ic INNER JOIN item AS i ON i.`ID` = ic.`COMPONENT_ID` WHERE ic.item_id = '{ID}' ")
        While rd.Read
            dgvComponents.Rows.Add(rd("ID"), rd("CODE"), rd("DESCRIPTION"), GF_NumIsNull(rd("Quantity")), GF_NumIsNull(rd("RATE")), "s", rd("ITEM_ID"))
        End While
    End Sub
    Private Sub OrderPreference()
        With dgvOrder_Preference.Columns
            .Clear()
            .Add("ID", "ITEM_PREFERENCE_ID")
            .Item("ID").Visible = False

            .Add("LOCATION_ID", "LOCATION_ID")
            .Item("LOCATION_ID").Visible = False

            .Add("LOCATION", "Branch")
            .Add("ORDER_POINT", "Order Point")
            .Add("ORDER_QTY", "Order Qty")
            .Add("ORDER_LEADTIME", "Order Lead-time")
            .Add("ONHAND_MAX_LIMIT", "OnHand Max Limit")
            .Add("STOCK_BIN", "Stock Bin")

            .Add("STOCK_BIN_ID", "STOCK_BIN_ID")
            .Item("STOCK_BIN_ID").Visible = False

            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False
        End With

        With dgvOrder_Preference
            '  .Columns(0).Visible = False
            .Columns(2).Width = 110
            .Columns(3).Width = 60
            .Columns(4).Width = 60
            .Columns(5).Width = 60
            .Columns(6).Width = 70
            .Columns(7).Width = 70
        End With
        GS_ViewNotSort(dgvOrder_Preference)
        dgvOrder_Preference.ColumnHeadersHeight = 60


        Dim rd As OdbcDataReader = SqlReader("SELECT i.ID as `ITEM_PREFERENCE_ID`,l.`ID` as `LOCATION_ID`,l.`NAME` AS `LOCATION`, FORMAT( i.`ORDER_POINT`,1) as `ORDER_POINT`,FORMAT(i.`ORDER_QTY`,1) as `ORDER_QTY`,FORMAT(i.`ORDER_LEADTIME`,1) as `ORDER_LEADTIME`, FORMAT(i.`ONHAND_MAX_LIMIT`,1) as `ONHAND_MAX_LIMIT`,s.ID as `STOCK_BIN_ID`,s.`DESCRIPTION` AS `STOCK_BIN` FROM location AS l LEFT OUTER JOIN item_preference AS i ON i.`LOCATION_ID` = l.`ID` AND  i.item_id ='" & ID & "' LEFT OUTER JOIN stock_bin AS s ON i.`STOCK_BIN_ID` = s.`ID`")
        dgvOrder_Preference.Rows.Clear()

        While rd.Read
            With dgvOrder_Preference.Rows
                .Add(rd("ITEM_PREFERENCE_ID"), rd("LOCATION_ID"), rd("LOCATION"), GF_TextIsNull(rd("ORDER_POINT")).Replace(",", ""), GF_TextIsNull(rd("ORDER_QTY")).Replace(",", ""), GF_TextIsNull(rd("ORDER_LEADTIME")).Replace(",", ""), GF_TextIsNull(rd("ONHAND_MAX_LIMIT")).Replace(",", ""), GF_TextIsNull(rd("STOCK_BIN")), GF_TextIsNull(rd("STOCK_BIN_ID")), "s")
            End With
        End While


    End Sub


    Private Sub DgvOrder_Preference_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvOrder_Preference.CellDoubleClick
        tsInventoryClick.PerformClick()
    End Sub

    Private Sub RefreshUnit_RelatedUnit()

        With dgvReleted_Units.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False

            .Add("UNIT_ID", "UNIT_ID")
            .Item("UNIT_ID").Visible = False
            .Add("UNIT", "Size")
            .Add("SYMBOL", "Symbol")

            .Add("QTY", "Qty")
            .Item("QTY").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("RATE", "RATE")
            .Item("RATE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight

            .Add("BARCODE", "Barcode")
            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False

            .Add("DATA", "DATA")
            .Item("DATA").Visible = False

            GS_ViewNotSort(dgvReleted_Units)
        End With

        With dgvReleted_Units
            .Columns("UNIT").Width = 100
            .Columns("SYMBOL").Width = 60
            .Columns("QTY").Width = 70
            .Columns("RATE").Width = 70
            .Columns("BARCODE").Width = 110
        End With




        dgvReleted_Units.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader("SELECT ui.ID,u.`ID` as `UNIT_ID`,u.`NAME` as `UNIT`,u.`SYMBOL`, format(ui.`QUANTITY`,0) as `QTY` , format(ui.`RATE`,2) as `RATE`,ui.`BARCODE` FROM item_units AS ui INNER JOIN unit_of_measure AS u ON ui.`UNIT_ID` = u.`ID`  WHERE ui.`ITEM_ID` ='" & ID & "'")
        While rd.Read
            dgvReleted_Units.Rows.Add(GF_TextIsNull(rd("ID")), rd("UNIT_ID"), rd("UNIT"), rd("SYMBOL"), rd("QTY"), rd("RATE"), rd("BARCODE"), "s", SQL_UNIT_PRICE_LEVEL(GF_TextIsNull(rd("ID"))))
        End While

        'RefreshUnit_UM_PriceLevels()
        LocationDefaults()
    End Sub
    Private Function SQL_UNIT_PRICE_LEVEL(ByVal Related_ID As String) As String
        Dim StrCollect As String = ""
        Dim rd As OdbcDataReader = SqlReader("SELECT ipl.`ID`,ipl.PRICE_LEVEL_ID,p.`DESCRIPTION` as `PRICE_LEVEL`,format(ipl.`CUSTOM_PRICE`,2) as `CUSTOM_PRICE` FROM item_unit_price_levels AS ipl INNER JOIN price_level AS p ON p.`ID` = ipl.`PRICE_LEVEL_ID` WHERE ipl.`ITEM_UNIT_LINE_ID` ='" & Related_ID & "' and p.`TYPE` = '1' ")
        While rd.Read
            StrCollect &= $"{ GF_TextIsNull(rd("ID"))},{rd("PRICE_LEVEL_ID")},{rd("PRICE_LEVEL")},{ GF_NumIsNull(rd("CUSTOM_PRICE"))},s;"
        End While
        rd.Close()

        Return StrCollect

    End Function
    Private Sub RefreshUnit_PriceLevels_Recompute()
        Dim StrCollect As String = ""
        For I As Integer = 0 To dgvUM_Price_level.Rows.Count - 1
            With dgvUM_Price_level.Rows(I)
                StrCollect &= $"{ GF_NumIsNull(.Cells("ID").Value)},{ .Cells("PRICE_LEVEL_ID").Value},{ .Cells("PRICE_LEVEL").Value},{ GF_NumIsNull(.Cells("CUSTOM_PRICE").Value)},{ .Cells("STATUS").Value};"
            End With
        Next
        dgvReleted_Units.Rows(dgvReleted_Units.CurrentRow.Index).Cells("DATA").Value = StrCollect

    End Sub
    Private Sub RefreshUnit_UM_PriceLevels()

        With dgvUM_Price_level.Columns

            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False

            .Add("PRICE_LEVEL_ID", "PRICE_LEVEL_ID")
            .Item("PRICE_LEVEL_ID").Visible = False

            .Add("PRICE_LEVEL", "Rate Level")
            .Add("CUSTOM_PRICE", "Custom Rate")
            .Item("CUSTOM_PRICE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("CUSTOM_PRICE").DefaultCellStyle.Format = "N2"

            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False
            GS_ViewNotSort(dgvUM_Price_level)


        End With


        Dim i As Integer = 0
        Dim Related_ID As String = ""
        Try
            If dgvReleted_Units.Rows.Count <> 0 Then
                i = dgvReleted_Units.CurrentRow.Index
                Related_ID = dgvReleted_Units.Rows(i).Cells("ID").Value.ToString
            Else
                TabControl2.SelectTab(0)
                Exit Sub
            End If

        Catch ex As Exception
            TabControl2.SelectTab(0)
            Exit Sub
        End Try

        Dim Data As String = dgvReleted_Units.Rows(i).Cells("DATA").Value
        dgvUM_Price_level.Rows.Clear()
        If Data <> "" Then


            Dim RowID As String = ""
            Dim PRICE_LEVEL_ID As String = ""
            Dim PRICE_LEVEL As String = ""
            Dim CUSTOM_PRICE As String = ""
            Dim STATUS As String = ""

            Dim Rnum As Integer = 0
            For N As Double = 0 To Data.Length - 1
                Dim S As String = Data.Substring(N, 1)
                If S = "," Then
                    Rnum += 1
                ElseIf S = ";" Then
                    dgvUM_Price_level.Rows.Add(RowID, PRICE_LEVEL_ID, PRICE_LEVEL, CUSTOM_PRICE, STATUS)
                    RowID = ""
                    PRICE_LEVEL_ID = ""
                    PRICE_LEVEL = ""
                    CUSTOM_PRICE = ""
                    STATUS = ""
                    Rnum = 0
                Else
                    Select Case Rnum
                        Case 0
                            RowID &= S
                        Case 1
                            PRICE_LEVEL_ID &= S
                        Case 2
                            PRICE_LEVEL &= S
                        Case 3
                            CUSTOM_PRICE &= S
                        Case 4
                            STATUS &= S
                    End Select
                End If
            Next
        End If

    End Sub
    Private Sub LocationDefaults()

        If dgvLocation_Default.Columns.Count = 0 Then
            With dgvLocation_Default.Columns
                .Clear()
                .Add("LOCATION_ID", "LOCATION_ID")
                .Item("LOCATION_ID").Visible = False
                .Add("LOCATION", "Branch")

                .Add("PURCHASES_UNIT_ID", "PURCHASES_UNIT_ID")
                .Item("PURCHASES_UNIT_ID").Visible = False
                .Add("PURCHASES_UNIT", "P.O size")

                .Add("SALES_UNIT_ID", "SALES_UNIT_ID")
                .Item("SALES_UNIT_ID").Visible = False
                .Add("SALES_UNIT", "SRP size")

                .Add("SHIPPING_UNIT_ID", "SHIPPING_UNIT_ID")
                .Item("SHIPPING_UNIT_ID").Visible = False
                .Add("SHIPPING_UNIT", "Ship Size")


                .Add("STATUS", "STATUS")
                .Item("STATUS").Visible = False

                .Add("ITEM_LOCATION_UNITS_ID", "ITEM_LOCATION_UNITS_ID")
                .Item("ITEM_LOCATION_UNITS_ID").Visible = False
            End With
            dgvLocation_Default.Columns("LOCATION").Width = 120
            GS_ViewNotSort(dgvLocation_Default)
        End If




        Dim rd As OdbcDataReader = SqlReader("SELECT 
l.`ID` as `LOCATION_ID`,
l.`NAME` as `LOCATION`,
um_purchase.`ID` as `PURCHASES_UNIT_ID`,
um_purchase.`NAME` as `PURCHASES_UNIT`,
um_sales.`ID` as `SALES_UNIT_ID`,
um_sales.`NAME` as `SALES_UNIT`,
um_shipping.`ID` as `SHIPPING_UNIT_ID`,
um_shipping.`NAME` as `SHIPPING_UNIT`,
ilu.ID as `ITEM_LOCATION_UNITS_ID`
FROM  location AS l 
LEFT OUTER JOIN item_location_units AS ilu 
ON l.`ID` = ilu.`LOCATION_ID` AND ilu.`ITEM_ID` = '" & ID & "' 
LEFT OUTER JOIN unit_of_measure AS um_purchase 
ON um_purchase.`ID` = ilu.`PURCHASES_UNIT_ID` 
LEFT OUTER JOIN unit_of_measure AS um_sales 
ON um_sales.`ID` = ilu.`SALES_UNIT_ID` 
LEFT OUTER JOIN unit_of_measure AS um_shipping 
ON um_shipping.`ID` = ilu.`SHIPPING_UNIT_ID`")
        dgvLocation_Default.Rows.Clear()

        While rd.Read
            dgvLocation_Default.Rows.Add(rd("LOCATION_ID"), rd("LOCATION"), rd("PURCHASES_UNIT_ID"), rd("PURCHASES_UNIT"), rd("SALES_UNIT_ID"), rd("SALES_UNIT"), rd("SHIPPING_UNIT_ID"), rd("SHIPPING_UNIT"), "s", rd("ITEM_LOCATION_UNITS_ID"))
        End While
    End Sub
    Private Sub TabControl2_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl2.Selected
        If e.TabPageIndex = 1 Then
            RefreshUnit_UM_PriceLevels()
        End If
    End Sub
    Private Sub DgvLocation_Default_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLocation_Default.CellDoubleClick
        tsDefaultBranch.PerformClick()
    End Sub

    Private Sub CmbSUB_CLASS_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSUB_CLASS_ID.SelectedIndexChanged
        If bFirstLoad = True Then
            cmbCLASS_ID.SelectedValue = GF_NumIsNull(GF_GetStringFieldValue("ITEM_SUB_CLASS", "ID", GF_NumIsNull(cmbSUB_CLASS_ID.SelectedValue), "CLASS_ID"))
        End If
    End Sub

    Private Sub CmbClass_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCLASS_ID.SelectedIndexChanged
        If bFirstLoad = False Then
            GS_ComboBoxLoad(cmbSUB_CLASS_ID, "Select ID,DESCRIPTION from item_sub_class where CLASS_ID = '" & GF_NumIsNull(cmbCLASS_ID.SelectedValue) & "'", "ID", "DESCRIPTION")
        End If
    End Sub
    Private Sub DgvComponents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvComponents.CellDoubleClick
        EditTrans.PerformClick()
    End Sub
    Private Sub RtbPURCHASE_DESCRIPTION_LostFocus(sender As Object, e As EventArgs) Handles rtbPURCHASE_DESCRIPTION.LostFocus
        If IsNew = True Then
            Dim info As TextInfo = CultureInfo.InvariantCulture.TextInfo
            rtbDESCRIPTION.Text = rtbPURCHASE_DESCRIPTION.Text.ToUpper.Trim
        End If
    End Sub

    Private Sub RtbPURCHASE_DESCRIPTION_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbPURCHASE_DESCRIPTION.KeyDown
        If e.KeyCode = Keys.F1 Then
            rtbPURCHASE_DESCRIPTION.Text = rtbPURCHASE_DESCRIPTION.Text.ToUpper.Trim
        End If


    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = ""
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        Dim sep As String = String.Empty
        Dim I As Integer = 0
        For Each c As ImageCodecInfo In codecs
            I += 1
            Dim codecName As String = c.CodecName.Substring(8).Replace("Codec", "Files").Trim()
            OpenFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", OpenFileDialog1.Filter, sep, codecName, c.FilenameExtension)
            sep = "|"
        Next
        OpenFileDialog1.Filter = String.Format("{0}{1}{2} ({3})|{3}", OpenFileDialog1.Filter, sep, "All Files", "*.*")
        OpenFileDialog1.Title = "Select Upload Photos"
        OpenFileDialog1.FilterIndex = I + 1
        If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            GetUploadImage = OpenFileDialog1.FileName
            lblPIC_FILENAME.Text = My.Computer.FileSystem.GetName(GetUploadImage)
            Try
                picItem.Image = Image.FromFile(GetUploadImage)
            Catch ex As Exception
                MessageBoxExclamation(ex.Message)
            End Try

        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        lblPIC_FILENAME.Text = ""
        GetUploadImage = ""
        picItem.Image = Nothing
    End Sub
    Private Sub SaveIt()
        If txtCODE.Text.Length = 0 Then
            MessageBoxWarning("Please enter code item!")
            Exit Sub
        End If
        Dim LAST_TYPE_INDEX As Integer = cmbTYPE.SelectedIndex


        If IsNew = True Then
            If IsItemCode() = True Then
                MessageBoxExclamation("Code item Is already used!")
                Exit Sub
            End If

            If rtbDESCRIPTION.Text.Length = 0 Then
                MessageBoxInfo("Please enter item description")
                rtbDESCRIPTION.Select()
                Exit Sub
            End If

            'Checking Discription

            If Trim(rtbDESCRIPTION.Text) <> "" Then
                Dim IsUsed As Boolean = False
                Dim rd_des As OdbcDataReader = SqlReader($"SELECT * FROM item WHERE `DESCRIPTION` = '{GF_TextApostrophe(rtbDESCRIPTION.Text)}' limit 1; ")
                If rd_des.Read Then
                    IsUsed = True
                    MessageBoxInfo($"{xlblDescription.Text} => {rtbDESCRIPTION.Text} is already used.")
                End If
                rd_des.Close()

                If IsUsed = True Then
                    Exit Sub
                End If

            End If

            If Trim(rtbPURCHASE_DESCRIPTION.Text) <> "" Then
                Dim IsUsed As Boolean = False
                Dim rd_des As OdbcDataReader = SqlReader($"SELECT * FROM item WHERE `PURCHASE_DESCRIPTION` = '{GF_TextApostrophe(rtbPURCHASE_DESCRIPTION.Text)}' limit 1; ")
                If rd_des.Read Then
                    IsUsed = True
                    MessageBoxInfo($"{xlblPurchase_Description.Text} => {rtbPURCHASE_DESCRIPTION.Text} is already used.")
                End If
                rd_des.Close()

                If IsUsed = True Then
                    Exit Sub
                End If
            End If



            GS_CursorLoadingOn(True)
            ID = ObjectTypeMapId("item")


            GetInsertSQL(SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO item ({SQL_Field},ID) VALUES ({SQL_Value},'{ID}') ")
            GS_SetNextItemCode(cmbTYPE.SelectedValue, txtCODE.Text)

        Else
            GS_CursorLoadingOn(True)
            Dim sQuery As String = GetUpdateSQL()
            SqlExecuted("UPDATE item SET " & sQuery & " WHERE ID = '" & ID & "'")
        End If


        If cmbTYPE.SelectedValue <= 4 Then
            'RELATED UNITS

            For R As Integer = 0 To dgvReleted_Units.Rows.Count - 1
                With dgvReleted_Units.Rows(R)
                    Select Case .Cells("STATUS").Value
                        Case "s"

                        Case "n"
                            .Cells("ID").Value = ObjectTypeMapId("ITEM_UNITS")
                            SqlExecuted($"INSERT INTO item_units SET UNIT_ID='{ .Cells("UNIT_ID").Value}',QUANTITY='{ GF_NumIsNull(.Cells("QTY").Value)}',RATE='{GF_NumIsNull(.Cells("RATE").Value)}',BARCODE={GF_GotNullText(.Cells("BARCODE").Value)},ITEM_ID='{ID}',ID='{ .Cells("ID").Value}';")
                        Case "e"
                            SqlExecuted($"UPDATE item_units SET UNIT_ID='{ .Cells("UNIT_ID").Value}',QUANTITY='{ GF_NumIsNull(.Cells("QTY").Value)}',RATE='{GF_NumIsNull(.Cells("RATE").Value)}',BARCODE={ GF_GotNullText(.Cells("BARCODE").Value)} WHERE ITEM_ID='{ID}' and ID='{ .Cells("ID").Value}' limit 1;")
                        Case "d"
                            SqlExecuted($"DELETE FROM item_units  WHERE ITEM_ID='{ID}' and ID='{ .Cells("ID").Value}' limit 1;")
                    End Select
                    DataSql(.Cells("DATA").Value, .Cells("ID").Value)
                End With
            Next
            'ITEM_LOCATION_UNITS
            For U As Integer = 0 To dgvLocation_Default.Rows.Count - 1
                With dgvLocation_Default.Rows(U)
                    Select Case .Cells("STATUS").Value
                        Case "s"
                        Case "n"
                            SqlExecuted($" INSERT INTO item_location_units SET PURCHASES_UNIT_ID={GotNullNumber(GF_NumIsNull(.Cells("PURCHASES_UNIT_ID").Value))},SALES_UNIT_ID={GotNullNumber(GF_NumIsNull(.Cells("SALES_UNIT_ID").Value))},SHIPPING_UNIT_ID={GotNullNumber(GF_NumIsNull(.Cells("SHIPPING_UNIT_ID").Value))},LOCATION_ID='{ .Cells("LOCATION_ID").Value}',ITEM_ID='{ID}',ID='{ObjectTypeMapId("ITEM_LOCATION_UNITS")}';")
                        Case "e"
                            SqlExecuted($" UPDATE item_location_units SET PURCHASES_UNIT_ID={GotNullNumber(GF_NumIsNull(.Cells("PURCHASES_UNIT_ID").Value))},SALES_UNIT_ID={GotNullNumber(GF_NumIsNull(.Cells("SALES_UNIT_ID").Value))},SHIPPING_UNIT_ID={GotNullNumber(GF_NumIsNull(.Cells("SHIPPING_UNIT_ID").Value))} WHERE LOCATION_ID='{ .Cells("LOCATION_ID").Value}' and ITEM_ID='{ID}' and ID='{ .Cells("ITEM_LOCATION_UNITS_ID").Value}' limit 1;")
                        Case "d"
                            SqlExecuted($" DELETE FROM item_location_units  WHERE LOCATION_ID='{ .Cells("LOCATION_ID").Value}' and ITEM_ID='{ID}' and ID='{ .Cells("ITEM_LOCATION_UNITS_ID").Value}' limit 1;")
                    End Select
                End With
            Next

        End If
        If cmbTYPE.SelectedValue <= 4 Then
            'PRICE_LEVEL

            For P As Integer = 0 To dgvPriceLevel.Rows.Count - 1
                With dgvPriceLevel.Rows(P)
                    Select Case .Cells("STATUS").Value
                        Case "s"
                        Case "n"
                            SqlExecuted($"INSERT INTO price_level_lines SET CUSTOM_PRICE='{ GF_NumIsNull(.Cells("CUSTOM_PRICE").Value)}',PRICE_LEVEL_ID='{ .Cells("PRICE_LEVEL_ID").Value}',ITEM_ID='{ID}',ID='{ObjectTypeMapId("PRICE_LEVEL_LINES")}';")
                        Case "e"
                            SqlExecuted($"UPDATE price_level_lines SET CUSTOM_PRICE='{ GF_NumIsNull(.Cells("CUSTOM_PRICE").Value)}' WHERE PRICE_LEVEL_ID='{ .Cells("PRICE_LEVEL_ID").Value}' and ITEM_ID='{ID}' and ID='{ .Cells("PRICE_LEVEL_LINES_ID").Value}' Limit 1;")
                        Case "d"
                            SqlExecuted($"DELETE FROM price_level_lines WHERE PRICE_LEVEL_ID='{ .Cells("PRICE_LEVEL_ID").Value}' and ITEM_ID='{ID}' and ID='{ .Cells("PRICE_LEVEL_LINES_ID").Value}' Limit 1;")
                    End Select
                End With
            Next

        End If


        If cmbTYPE.SelectedValue = 6 Then
            'GROUP

            For G As Integer = 0 To dgvComponents.Rows.Count - 1
                With dgvComponents.Rows(G)
                    Select Case .Cells("STATUS").Value
                        Case "s" ' stable
                        Case "n" ' new
                            SqlExecuted($"INSERT INTO item_components SET ITEM_ID='{ID}',COMPONENT_ID='{ .Cells("ITEM_ID").Value}',QUANTITY='{ .Cells("QTY").Value}',RATE='{ .Cells("RATE").Value}',ID='{ObjectTypeMapId("ITEM_COMPONENTS")}';")
                        Case "e" ' edit
                            SqlExecuted($"UPDATE item_components SET COMPONENT_ID='{ .Cells("ITEM_ID").Value}',QUANTITY='{ .Cells("QTY").Value}',RATE='{ .Cells("RATE").Value}' WHERE ITEM_ID='{ID}' and ID='{ .Cells("ID").Value}' Limit 1;")
                        Case "d" ' delete
                            SqlExecuted($"DELETE FROM item_components  WHERE ITEM_ID='{ID}' and ID='{ .Cells("ID").Value}' Limit 1;")
                    End Select
                End With
            Next


        ElseIf cmbTYPE.SelectedValue = 1 Or cmbTYPE.SelectedValue = 9 Or cmbTYPE.SelectedValue = 10 Then
            'ASSEMBLY

            For A As Integer = 0 To dgvComponents.Rows.Count - 1
                With dgvComponents.Rows(A)
                    Select Case .Cells("STATUS").Value
                        Case "s" ' stable

                        Case "n" ' new
                            SqlExecuted($"INSERT INTO item_components SET ITEM_ID='{ID}',COMPONENT_ID='{ .Cells("ITEM_ID").Value}',QUANTITY='{ .Cells("QTY").Value}',RATE='{ .Cells("RATE").Value}',ID='{ObjectTypeMapId("ITEM_COMPONENTS")}';")
                        Case "e" ' edit
                            SqlExecuted($"UPDATE item_components SET COMPONENT_ID='{ .Cells("ITEM_ID").Value}',QUANTITY='{ .Cells("QTY").Value}',RATE='{ .Cells("RATE").Value}' WHERE ITEM_ID='{ID}' and ID='{ .Cells("ID").Value}' Limit 1;")
                        Case "d" ' delete
                            SqlExecuted($"DELETE FROM item_components  WHERE ITEM_ID='{ID}' and ID='{ .Cells("ID").Value}' Limit 1;")
                    End Select
                End With
            Next

        ElseIf cmbTYPE.SelectedValue <= 1 Then
            'INVENTORY TAB

            For S As Integer = 0 To dgvOrder_Preference.Rows.Count - 1
                With dgvOrder_Preference.Rows(S)
                    Select Case .Cells("STATUS").Value
                        Case "s" ' stable

                        Case "n" ' new
                            SqlExecuted($"INSERT INTO item_preference SET ITEM_ID='{ID}', LOCATION_ID='{ .Cells("LOCATION_ID").Value}',ORDER_POINT={GotNullNumber(GF_NumIsNull(.Cells("ORDER_POINT").Value))},ORDER_QTY={ GotNullNumber(GF_NumIsNull(.Cells("ORDER_QTY").Value))},ORDER_LEADTIME={ GotNullNumber(GF_NumIsNull(.Cells("ORDER_LEADTIME").Value))},ONHAND_MAX_LIMIT={GotNullNumber(GF_NumIsNull(.Cells("ONHAND_MAX_LIMIT").Value))},STOCK_BIN_ID={GotNullNumber(GF_NumIsNull(.Cells("STOCK_BIN_ID").Value))},ID='{ObjectTypeMapId("ITEM_PREFERENCE")}';")
                        Case "e" ' edit
                            SqlExecuted($"UPDATE item_preference SET ORDER_POINT={GotNullNumber(GF_NumIsNull(.Cells("ORDER_POINT").Value))},ORDER_QTY={ GotNullNumber(GF_NumIsNull(.Cells("ORDER_QTY").Value))},ORDER_LEADTIME={ GotNullNumber(GF_NumIsNull(.Cells("ORDER_LEADTIME").Value))},ONHAND_MAX_LIMIT={GotNullNumber(GF_NumIsNull(.Cells("ONHAND_MAX_LIMIT").Value))},STOCK_BIN_ID={ GotNullNumber(GF_NumIsNull(.Cells("STOCK_BIN_ID").Value))} WHERE ID='{ .Cells("ID").Value}' and ITEM_ID='{ID}' and LOCATION_ID='{ .Cells("LOCATION_ID").Value}' limit 1;")
                        Case "d" ' delete
                            SqlExecuted($"DELETE FROM item_preference WHERE ID='{ .Cells("ID").Value}' and ITEM_ID='{ID}' and LOCATION_ID='{ .Cells("LOCATION_ID").Value}' limit 1;")
                    End Select
                End With
            Next

        End If

        If GetUploadImage <> "" Then
            GF_UploadAttachment(GetUploadImage)
        End If

        picItem.Image = Nothing

        GS_ItemPerUpdate(dgv, ID, IsNew, this_BS, bMain)

        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If

        IsNew = True
        ID = 0
        ClearAndRefresh(Me)
        ClearAndRefresh(tpInfo)
        ClearAndRefresh(tpOther)

        GeneralRefresh()
        If SecurityAccessMode(FrmItem, IsNew) = False Then
            Me.Close()
        End If

        GS_DoEvents()

        cmbTYPE.SelectedIndex = LAST_TYPE_INDEX
        GS_CursorLoadingOn(False)
        SetDefault()
        Me.Text = "Create Item"
        Me.Refresh()
    End Sub
    Private Sub AddTrans_Click(sender As Object, e As EventArgs) Handles AddTrans.Click
        With FrmComponents

            If cmbTYPE.SelectedValue = 1 Then
                .CausesValidation = True
            ElseIf cmbTYPE.SelectedValue = 10 Then
                .HelpButton = True
            Else
                .CausesValidation = False
            End If

            .IsNew = True
            .gsDGV = dgvComponents
            .ID = ""
            .gsQTY = 1
            .gsRATE = 0
            If cmbTYPE.SelectedValue = 9 Then
                .numRate.Visible = False
                .xRate.Visible = False
            End If

            .ShowDialog()
            .Dispose()
        End With
        FrmComponents = Nothing

    End Sub

    Private Sub EditTrans_Click(sender As Object, e As EventArgs) Handles EditTrans.Click
        If dgvComponents.Rows.Count = 0 Then
            MessageBoxExclamation("Data Not Found")
            Exit Sub
        End If

        Me.dgvComponents.Focus()
        Dim i As Integer = dgvComponents.CurrentRow.Index
        Dim dComponents_ID As String = dgvComponents.Rows(i).Cells(0).Value
        With FrmComponents
            If cmbTYPE.SelectedValue = 1 Then
                .CausesValidation = True
            ElseIf cmbTYPE.SelectedValue = 10 Then
                .HelpButton = True
            Else
                .CausesValidation = False
            End If

            .gsDGV = dgvComponents
            .IsNew = False
            .gsITEM_ID = dgvComponents.Rows(i).Cells("ITEM_ID").Value
            .ID = dgvComponents.Rows(i).Cells("ID").Value
            .gsQTY = dgvComponents.Rows(i).Cells("QTY").Value
            .gsRATE = GF_NumIsNull(dgvComponents.Rows(i).Cells("RATE").Value)
            If cmbTYPE.SelectedValue = 9 Then
                .numRate.Visible = False
                .xRate.Visible = False
            End If
            .ShowDialog()
            .Dispose()
        End With
        FrmComponents = Nothing

    End Sub

    Private Sub DeleteTrans_Click(sender As Object, e As EventArgs) Handles DeleteTrans.Click
        If dgvComponents.Rows.Count = 0 Then
            MessageBoxExclamation("Data Not Found")
            Exit Sub
        End If
        Me.dgvComponents.Focus()
        Dim n As Integer = dgvComponents.CurrentRow.Index
        Dim dComponents_ID As String = dgvComponents.Rows(n).Cells(0).Value


        If GF_NumIsNull(dgvComponents.Rows(n).Cells(0).Value) <> 0 Then
            dgvComponents.Rows(n).Cells("STATUS").Value = "d"
            dgvComponents.Rows(n).Visible = False
        Else
            dgvComponents.Rows.RemoveAt(n)
        End If

    End Sub

    Private Sub TsAdd1_Click(sender As Object, e As EventArgs) Handles tsAdd1.Click
        Dim bSave As Boolean = False
        With FrmItemUnitRelated
            .ShowDialog()
            bSave = .bSave
            If bSave = True Then
                dgvReleted_Units.Rows.Add("", .cmbUnit.SelectedValue, .cmbUnit.Text, .cmbSymbol.Text, .numQty.Value, .numRate.Value, .txtBarcode.Text, "n", "")
            End If
            .Dispose()
        End With

        FrmItemUnitRelated = Nothing
    End Sub

    Private Sub TsEdit1_Click(sender As Object, e As EventArgs) Handles tsEdit1.Click
        If dgvReleted_Units.Rows.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvReleted_Units.CurrentRow.Index
        Dim R As DataGridViewRow = dgvReleted_Units.Rows(i)
        Dim bSave As Boolean = False

        Dim iID As Integer = 0
        Dim iQty As Double = 0
        Dim iRate As Double = 0
        Dim iBarcode As String = ""
        With FrmItemUnitRelated
            .iUnit_ID = R.Cells("UNIT_ID").Value
            .numQty.Value = GF_NumIsNull(R.Cells("QTY").Value)
            .numRate.Value = GF_NumIsNull(R.Cells("RATE").Value)
            .txtBarcode.Text = GF_TextIsNull(R.Cells("BARCODE").Value)
            .ShowDialog()
            bSave = .bSave
            If bSave = True Then
                R.Cells("UNIT_ID").Value = .cmbUnit.SelectedValue
                R.Cells("UNIT").Value = .cmbUnit.Text
                R.Cells("SYMBOL").Value = .cmbSymbol.Text
                R.Cells("QTY").Value = .numQty.Value
                R.Cells("RATE").Value = .numRate.Value
                R.Cells("BARCODE").Value = .txtBarcode.Text
                R.Cells("STATUS").Value = IIf(GF_NumIsNull(R.Cells("ID").Value) = 0, "n", "e")
            End If

            .Dispose()
        End With
        FrmItemUnitRelated = Nothing
    End Sub

    Private Sub TsDelete1_Click(sender As Object, e As EventArgs) Handles tsDelete1.Click
        If dgvReleted_Units.Rows.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvReleted_Units.CurrentRow.Index
        Dim xID As String = dgvReleted_Units.Rows(i).Cells(0).Value

        dgvReleted_Units.Focus()

        If GF_NumIsNull(dgvReleted_Units.Rows(i).Cells(0).Value) <> 0 Then
            dgvReleted_Units.Rows(i).Cells("STATUS").Value = "d"
            dgvReleted_Units.Rows(i).Visible = False
        Else
            dgvReleted_Units.Rows.RemoveAt(i)
        End If
    End Sub

    Private Sub TsAdd2_Click(sender As Object, e As EventArgs) Handles tsAdd2.Click
        If dgvReleted_Units.Rows.Count = 0 Then
            MessageBoxWarning("Releted size required!")
            Exit Sub
        End If
        'Dim i As Integer = dgvReleted_Units.CurrentRow.Index
        'Dim item_unit_id As String = dgvReleted_Units.Rows(i).Cells(0).Value


        Dim bSave As Boolean = False
        Dim iPrice_level As Integer = 0
        Dim iCustom_Price As Double = 0
        With FrmItemUnitMeasurePriceLevel
            .ShowDialog()
            bSave = .bSave
            If bSave = True Then
                dgvUM_Price_level.Rows.Add(0, .cmbPriceLevel.SelectedValue, .cmbPriceLevel.Text, .numCustomprice.Value, "n")
                RefreshUnit_PriceLevels_Recompute()
            End If
            .Dispose()
        End With
        FrmItemUnitMeasurePriceLevel = Nothing
    End Sub

    Private Sub TsEdit2_Click(sender As Object, e As EventArgs) Handles tsEdit2.Click
        If dgvReleted_Units.Rows.Count = 0 Then
            MessageBoxWarning("Releted size required!")
            Exit Sub
        End If

        Dim bSave As Boolean = False
        Dim i As Integer = dgvReleted_Units.CurrentRow.Index
        Dim item_unit_id As String = dgvReleted_Units.Rows(i).Cells(0).Value

        i = dgvUM_Price_level.CurrentRow.Index
        Dim R As DataGridViewRow = dgvUM_Price_level.Rows(i)
        Dim xID As String = R.Cells(0).Value
        With FrmItemUnitMeasurePriceLevel
            .iPrice_Level_id = R.Cells("PRICE_LEVEL_ID").Value
            .iCustomer_Price = R.Cells("CUSTOM_PRICE").Value
            .ShowDialog()
            bSave = .bSave

            If bSave = True Then
                R.Cells("PRICE_LEVEL_ID").Value = .cmbPriceLevel.SelectedValue
                R.Cells("PRICE_LEVEL").Value = .cmbPriceLevel.Text
                R.Cells("CUSTOM_PRICE").Value = .numCustomprice.Value
                R.Cells("STATUS").Value = IIf(GF_NumIsNull(R.Cells("ID").Value) = 0, "n", "e")
                RefreshUnit_PriceLevels_Recompute()

            End If
            .Dispose()
        End With
        FrmItemUnitMeasurePriceLevel = Nothing
    End Sub

    Private Sub TsDelete2_Click(sender As Object, e As EventArgs) Handles tsDelete2.Click
        If dgvUM_Price_level.Rows.Count = 0 Then
            MessageBoxInfo("Data not found!")
            Exit Sub
        End If

        Dim i As Integer = dgvUM_Price_level.CurrentRow.Index
        Dim xID As String = dgvUM_Price_level.Rows(i).Cells(0).Value

        dgvUM_Price_level.Focus()

        If GF_NumIsNull(dgvUM_Price_level.Rows(i).Cells("ID").Value) <> 0 Then
            dgvUM_Price_level.Rows(i).Cells("STATUS").Value = "d"
            dgvUM_Price_level.Rows(i).Visible = False
        Else
            dgvUM_Price_level.Rows.RemoveAt(i)
        End If
        RefreshUnit_PriceLevels_Recompute()
    End Sub

    Private Sub TsInventory_Click(sender As Object, e As EventArgs) Handles tsInventoryClick.Click
        If dgvOrder_Preference.Rows.Count = 0 Then
            MessageBoxWarning("Data Not Found")
            Exit Sub
        End If

        Dim i As Integer = dgvOrder_Preference.CurrentRow.Index
        With dgvOrder_Preference.Rows(i)


            Dim dID As String = dgvOrder_Preference.Rows.Item(i).Cells("LOCATION_ID").Value ' Location RowID
            Dim dDescription As String = dgvOrder_Preference.Rows.Item(i).Cells("LOCATION").Value 'Location Name



            Dim dSave As Boolean = False
            FrmItemPreference.bSave = dSave
            FrmItemPreference.gsDescription = dDescription 'Price Level RowID
            FrmItemPreference.gsOrderPoint = GF_NumIsNull(.Cells("ORDER_POINT").Value)
            FrmItemPreference.gsOrderQty = GF_NumIsNull(.Cells("ORDER_QTY").Value)
            FrmItemPreference.gsOrderLeadTime = GF_NumIsNull(.Cells("ORDER_LEADTIME").Value)
            FrmItemPreference.gsOnHandMaxLimit = GF_NumIsNull(.Cells("ONHAND_MAX_LIMIT").Value)
            FrmItemPreference.gsStock = GF_NumIsNull(.Cells("STOCK_BIN_ID").Value)
            FrmItemPreference.ShowDialog()
            dSave = FrmItemPreference.bSave
            If dSave = True Then

                .Cells("ORDER_POINT").Value = IIf(GF_NumIsNull(FrmItemPreference.gsOrderPoint) = 0, "", GF_NumIsNull(FrmItemPreference.gsOrderPoint))
                .Cells("ORDER_QTY").Value = IIf(GF_NumIsNull(FrmItemPreference.gsOrderQty) = 0, "", GF_NumIsNull(FrmItemPreference.gsOrderQty))
                .Cells("ORDER_LEADTIME").Value = IIf(GF_NumIsNull(FrmItemPreference.gsOrderLeadTime) = 0, "", GF_NumIsNull(FrmItemPreference.gsOrderLeadTime))
                .Cells("ONHAND_MAX_LIMIT").Value = IIf(GF_NumIsNull(FrmItemPreference.gsOnHandMaxLimit) = 0, "", GF_NumIsNull(FrmItemPreference.gsOnHandMaxLimit))
                .Cells("STOCK_BIN_ID").Value = IIf(GF_NumIsNull(FrmItemPreference.gsStock_bin_id) = 0, "", GF_NumIsNull(FrmItemPreference.gsStock_bin_id))

                If GF_NumIsNull(FrmItemPreference.gsStock_bin_id) <> 0 Then
                    .Cells("STOCK_BIN").Value = FrmItemPreference.cmbBinStock.Text
                Else
                    .Cells("STOCK_BIN").Value = ""
                End If

                If GF_NumIsNull(.Cells("ID").Value) = 0 Then
                    If GF_NumIsNull(.Cells("ORDER_POINT").Value) = 0 And GF_NumIsNull(.Cells("ORDER_QTY").Value) = 0 And GF_NumIsNull(.Cells("ORDER_LEADTIME").Value) = 0 And GF_NumIsNull(.Cells("ONHAND_MAX_LIMIT").Value) = 0 And GF_NumIsNull(.Cells("STOCK_BIN_ID").Value) = 0 Then
                        .Cells("STATUS").Value = "s"
                    Else
                        .Cells("STATUS").Value = "n"
                    End If

                Else

                    If GF_NumIsNull(.Cells("ORDER_POINT").Value) = 0 And GF_NumIsNull(.Cells("ORDER_QTY").Value) = 0 And GF_NumIsNull(.Cells("ORDER_LEADTIME").Value) = 0 And GF_NumIsNull(.Cells("ONHAND_MAX_LIMIT").Value) = 0 And GF_NumIsNull(.Cells("STOCK_BIN_ID").Value) = 0 Then
                        .Cells("STATUS").Value = "d"
                    Else
                        .Cells("STATUS").Value = "e"
                    End If
                End If
            End If
            .Dispose()
        End With
        FrmItemPreference = Nothing
    End Sub

    Private Sub TsDefaultBranch_Click(sender As Object, e As EventArgs) Handles tsDefaultBranch.Click
        If dgvLocation_Default.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If

        Dim i As Integer = dgvLocation_Default.CurrentRow.Index
        With dgvLocation_Default.Rows(i)

            Dim dSave As Boolean = False

            FrmItemLocationDefaults.dLocation = .Cells("LOCATION").Value
            FrmItemLocationDefaults.purchase_id = GF_NumIsNull(.Cells("PURCHASES_UNIT_ID").Value)
            FrmItemLocationDefaults.sales_id = GF_NumIsNull(.Cells("SALES_UNIT_ID").Value)
            FrmItemLocationDefaults.ship_id = GF_NumIsNull(.Cells("SHIPPING_UNIT_ID").Value)
            FrmItemLocationDefaults.ShowDialog()
            dSave = FrmItemLocationDefaults.bSave

            If dSave = True Then

                .Cells("PURCHASES_UNIT_ID").Value = FrmItemLocationDefaults.cmbPurchases.SelectedValue
                .Cells("PURCHASES_UNIT").Value = FrmItemLocationDefaults.cmbPurchases.Text

                .Cells("SALES_UNIT_ID").Value = FrmItemLocationDefaults.cmbSales.SelectedValue
                .Cells("SALES_UNIT").Value = FrmItemLocationDefaults.cmbSales.Text

                .Cells("SHIPPING_UNIT_ID").Value = FrmItemLocationDefaults.cmbShipping.SelectedValue
                .Cells("SHIPPING_UNIT").Value = FrmItemLocationDefaults.cmbShipping.Text

                If GF_TextIsNull(.Cells("ITEM_LOCATION_UNITS_ID").Value) = "" Then
                    If GF_NumIsNull(.Cells("PURCHASES_UNIT_ID").Value) = 0 And GF_NumIsNull(.Cells("SALES_UNIT_ID").Value) = 0 And GF_NumIsNull(.Cells("SHIPPING_UNIT_ID").Value) = 0 Then
                        .Cells("STATUS").Value = "s"
                    Else
                        .Cells("STATUS").Value = "n"
                    End If

                Else
                    If GF_NumIsNull(.Cells("PURCHASES_UNIT_ID").Value) = 0 And GF_NumIsNull(.Cells("SALES_UNIT_ID").Value) = 0 And GF_NumIsNull(.Cells("SHIPPING_UNIT_ID").Value) = 0 Then
                        .Cells("STATUS").Value = "d"
                    Else
                        .Cells("STATUS").Value = "e"
                    End If
                End If


                FrmItemLocationDefaults.Dispose()
                FrmItemLocationDefaults = Nothing

            End If
        End With
    End Sub

    Private Sub TsRateLevelsClick_Click(sender As Object, e As EventArgs) Handles tsRateLevelsClick.Click
        If dgvPriceLevel.Rows.Count = 0 Then
            MessageBoxWarning("Data Not Found")
            Exit Sub
        End If

        Dim i As Integer = dgvPriceLevel.CurrentRow.Index
        Dim dID As String = dgvPriceLevel.Rows.Item(i).Cells(0).Value
        Dim dDescription As String = dgvPriceLevel.Rows.Item(i).Cells(1).Value
        Dim dValue As String = 0
        If IsDBNull(dgvPriceLevel.Rows.Item(i).Cells(2).Value) = False Then
            dValue = Format(dgvPriceLevel.Rows.Item(i).Cells(2).Value, "fixed")
        End If

        Dim dSave As Boolean = False
        With FrmInsertValue
            .txtValue.TextAlign = HorizontalAlignment.Right
            .gsID = dID 'Price Level RowID
            .gsDescription = dDescription
            .gsFORM_NAME = "Price Level"
            .gsValue = dValue
            .ShowDialog()
            dSave = .bSave
            dValue = .gsValue
            .Dispose()
        End With
        FrmInsertValue = Nothing
        If dSave = True Then

            With dgvPriceLevel.Rows(i)
                .Cells("CUSTOM_PRICE").Value = IIf(Val(dValue) = 0, "", NumberFormatFixed(Val(dValue)))

                If GF_TextIsNull(.Cells("PRICE_LEVEL_LINES_ID").Value) = "" Then

                    If GF_NumIsNull(.Cells("CUSTOM_PRICE").Value) = 0 Then
                        .Cells("STATUS").Value = "s"
                    Else
                        .Cells("STATUS").Value = "n"
                    End If

                Else

                    If GF_NumIsNull(.Cells("CUSTOM_PRICE").Value) = 0 Then
                        .Cells("STATUS").Value = "d"
                    Else
                        .Cells("STATUS").Value = "e"
                    End If
                End If
            End With





        End If

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveIt()
    End Sub
End Class