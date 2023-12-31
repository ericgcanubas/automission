﻿
Public Class FrmTaxDetails

    Public ID As Integer
    Public IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub FrmTaxDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ClearInfo()
        If ID > 0 Then
            Try
                SqlExecutedUsingReading(Me, "select  * from tax where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If

        numRATE.DecimalPlaces = 0


    End Sub
    Private Sub ClearInfo()
        GS_ComboBoxLoad(cmbTAX_TYPE, "select ID,DESCRIPTION  from tax_type_map ", "ID", "DESCRIPTION")
        ClearAndRefresh(Me)
    End Sub
    Private Sub TaxType(ByVal i As Integer)
        '9, 142 / 143, 140
        '9, 166 / 143, 163
        '9, 188 / 143, 186

        Select Case i
            Case 0
                ComboBoxNull(cmbVAT_METHOD, "ID", "NAME") ' NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False

                ComboBoxNull(cmbASSET_ACCOUNT_ID, "ID", "NAME") 'NULL

                cmbASSET_ACCOUNT_ID.Visible = False
                lbxASSET_ACCOUNT.Visible = False


                GS_ComboBoxLoad(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"

            Case 1


                ComboBoxNull(cmbVAT_METHOD, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False

                ComboBoxNull(cmbASSET_ACCOUNT_ID, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbASSET_ACCOUNT_ID.Visible = False
                lbxASSET_ACCOUNT.Visible = False


                GS_ComboBoxLoad(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"
            Case 2

                ComboBoxNull(cmbVAT_METHOD, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False


                GS_ComboBoxLoad(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"

                GS_ComboBoxLoad(cmbASSET_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbASSET_ACCOUNT_ID.Location = New Point(143, 163)
                lbxASSET_ACCOUNT.Location = New Point(9, 166)
                cmbASSET_ACCOUNT_ID.Visible = True
                lbxASSET_ACCOUNT.Visible = True
                lbxASSET_ACCOUNT.Text = "Tax Credit Account"

            Case 3

                '9, 142 / 143, 140
                '9, 166 / 143, 163
                '9, 188 / 143, 186

                GS_ComboBoxLoad(cmbVAT_METHOD, "select ID,DESCRIPTION from vat_method_map ", "ID", "DESCRIPTION")
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDownList
                cmbVAT_METHOD.Location = New Point(143, 140)
                lbxVAT_METHOD.Location = New Point(9, 142)
                cmbVAT_METHOD.Visible = True
                lbxVAT_METHOD.Visible = True
                lbxVAT_METHOD.Text = "Vat Method"



                GS_ComboBoxLoad(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 163)
                lbxTAX_ACCOUNT.Location = New Point(9, 166)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Output Tax Account"

                GS_ComboBoxLoad(cmbASSET_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbASSET_ACCOUNT_ID.Location = New Point(143, 186)
                lbxASSET_ACCOUNT.Location = New Point(9, 188)
                cmbASSET_ACCOUNT_ID.Visible = True
                lbxASSET_ACCOUNT.Visible = True
                lbxASSET_ACCOUNT.Text = "Input Tax Account"


            Case 4


                ComboBoxNull(cmbVAT_METHOD, "ID", "NAME") ' NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False

                ComboBoxNull(cmbASSET_ACCOUNT_ID, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbASSET_ACCOUNT_ID.Visible = False
                lbxASSET_ACCOUNT.Visible = False


                GS_ComboBoxLoad(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"
            Case Else

                '' ComboBoxNull(cmbVAT_METHOD, "ID", "NAME")

                'GS_ComboBoxLoad(cmbVAT_METHOD, "select ID,DESCRIPTION from vat_method_map ", "ID", "DESCRIPTION")
                'GS_ComboBoxLoad(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                'GS_ComboBoxLoad(cmbASSET_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")

        End Select

    End Sub

    Private Sub CmbTAX_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTAX_TYPE.SelectedIndexChanged
        Try
            TaxType(cmbTAX_TYPE.SelectedValue)
        Catch ex As Exception
            TaxType(0)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            MessageBoxInfo("Please enter name")
            Exit Sub
        End If
        Me.Enabled = False

        If IsNew = False Then
            SqlExecuted("Update tax set " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
        Else
            ID = ObjectTypeMapId("TAX")
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO tax ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
        End If

        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"SELECT tx.`ID`,tx.`Name`,t.`DESCRIPTION` AS `Tax Type`, IF(IFNULL(tx.`Rate`,'') = '','', CONCAT(FORMAT(tx.`Rate`,0),'%')) AS `Rate`,l.`NAME` AS `Liability Account`,a.`NAME` AS `Asset Account`, tx.`Inactive` FROM tax AS tx  INNER JOIN tax_type_map AS t ON t.`ID` = tx.`TAX_TYPE` LEFT OUTER JOIN account AS l ON l.`ID` = tx.`TAX_ACCOUNT_ID`	 LEFT OUTER JOIN account AS a ON a.`ID` = tx.`ASSET_ACCOUNT_ID` WHERE tx.`ID` = '{ID}' Limit 1", IsNew, This_BS)
        ClearInfo()
        ID = 0
        IsNew = True
        Me.Enabled = True
        numRATE.DecimalPlaces = 0

        If SecurityAccessMode(FrmTax, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class