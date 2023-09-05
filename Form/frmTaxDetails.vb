
Public Class frmTaxDetails

    Public gsID As String
    Public gsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub frmTaxDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fClear_Info()
        If gsID <> "" Then

            Try
                ' 
                fExecutedUsingReading(Me, "select  * from tax where id = '" & gsID & "' limit 1")

                gsNew = False
            Catch ex As Exception

                fMessageboxWarning(ex.Message)
            End Try
        End If

        numRATE.DecimalPlaces = 0


    End Sub
    Private Sub fClear_Info()
        fComboBox(cmbTAX_TYPE, "select ID,DESCRIPTION  from tax_type_map ", "ID", "DESCRIPTION")
        fCLean_and_refresh(Me)
    End Sub
    Private Sub fTax_Type(ByVal i As Integer)
        '9, 142 / 143, 140
        '9, 166 / 143, 163
        '9, 188 / 143, 186

        Select Case i
            Case 0
                fComboBoxNull(cmbVAT_METHOD, "ID", "NAME") ' NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False

                fComboBoxNull(cmbASSET_ACCOUNT_ID, "ID", "NAME") 'NULL

                cmbASSET_ACCOUNT_ID.Visible = False
                lbxASSET_ACCOUNT.Visible = False


                fComboBox(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"

            Case 1


                fComboBoxNull(cmbVAT_METHOD, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False

                fComboBoxNull(cmbASSET_ACCOUNT_ID, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbASSET_ACCOUNT_ID.Visible = False
                lbxASSET_ACCOUNT.Visible = False


                fComboBox(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"
            Case 2

                fComboBoxNull(cmbVAT_METHOD, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False


                fComboBox(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"

                fComboBox(cmbASSET_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbASSET_ACCOUNT_ID.Location = New Point(143, 163)
                lbxASSET_ACCOUNT.Location = New Point(9, 166)
                cmbASSET_ACCOUNT_ID.Visible = True
                lbxASSET_ACCOUNT.Visible = True
                lbxASSET_ACCOUNT.Text = "Tax Credit Account"

            Case 3

                '9, 142 / 143, 140
                '9, 166 / 143, 163
                '9, 188 / 143, 186

                fComboBox(cmbVAT_METHOD, "select ID,DESCRIPTION from vat_method_map ", "ID", "DESCRIPTION")
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDownList
                cmbVAT_METHOD.Location = New Point(143, 140)
                lbxVAT_METHOD.Location = New Point(9, 142)
                cmbVAT_METHOD.Visible = True
                lbxVAT_METHOD.Visible = True
                lbxVAT_METHOD.Text = "Vat Method"



                fComboBox(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 163)
                lbxTAX_ACCOUNT.Location = New Point(9, 166)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Output Tax Account"

                fComboBox(cmbASSET_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbASSET_ACCOUNT_ID.Location = New Point(143, 186)
                lbxASSET_ACCOUNT.Location = New Point(9, 188)
                cmbASSET_ACCOUNT_ID.Visible = True
                lbxASSET_ACCOUNT.Visible = True
                lbxASSET_ACCOUNT.Text = "Input Tax Account"


            Case 4


                fComboBoxNull(cmbVAT_METHOD, "ID", "NAME") ' NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbVAT_METHOD.Visible = False
                lbxVAT_METHOD.Visible = False

                fComboBoxNull(cmbASSET_ACCOUNT_ID, "ID", "NAME") 'NULL
                cmbVAT_METHOD.DropDownStyle = ComboBoxStyle.DropDown
                cmbASSET_ACCOUNT_ID.Visible = False
                lbxASSET_ACCOUNT.Visible = False


                fComboBox(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                cmbTAX_ACCOUNT_ID.Location = New Point(143, 140)
                lbxTAX_ACCOUNT.Location = New Point(9, 142)
                cmbTAX_ACCOUNT_ID.Visible = True
                lbxTAX_ACCOUNT.Visible = True
                lbxTAX_ACCOUNT.Text = "Tax Account"
            Case Else

                '' fComboBoxNull(cmbVAT_METHOD, "ID", "NAME")

                'fComboBox(cmbVAT_METHOD, "select ID,DESCRIPTION from vat_method_map ", "ID", "DESCRIPTION")
                'fComboBox(cmbTAX_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
                'fComboBox(cmbASSET_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")




        End Select

    End Sub

    Private Sub cmbTAX_TYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTAX_TYPE.SelectedIndexChanged
        Try
            fTax_Type(cmbTAX_TYPE.SelectedValue)
        Catch ex As Exception
            fTax_Type(0)
        End Try
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs)

        If gsNew = True Then
            fCLean_and_refresh(Me)
        Else

            If fMessageBoxQuestion("Create new?") = True Then
                gsNew = True
                gsID = ""
                fCLean_and_refresh(Me)
            Else

                fExecutedUsingReading(Me, "select  * from tax where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtNAME.Text) = "" Then
            fMessageboxInfo("Please enter name")
            Exit Sub
        End If
        Me.Enabled = False
        Dim sql As String = fFieldCollector(Me)
        If gsNew = False Then
            fExecutedOnly("Update tax set " & sql & " Where ID = '" & gsID & "' Limit 1")
        Else
            gsID = fObjectTypeMap_ID("TAX")
            fExecutedOnly("INSERT INTO tax set " & sql & ", ID ='" & gsID & "'")

        End If
        fSavePopUp(Me, gsNew)
        fBindDgvUpdate(Dgv, $"SELECT tx.`ID`,tx.`Name`,t.`DESCRIPTION` AS `Tax Type`, IF(IFNULL(tx.`Rate`,'') = '','', CONCAT(FORMAT(tx.`Rate`,0),'%')) AS `Rate`,l.`NAME` AS `Liability Account`,a.`NAME` AS `Asset Account`, tx.`Inactive` FROM tax AS tx  INNER JOIN tax_type_map AS t ON t.`ID` = tx.`TAX_TYPE` LEFT OUTER JOIN account AS l ON l.`ID` = tx.`TAX_ACCOUNT_ID`	 LEFT OUTER JOIN account AS a ON a.`ID` = tx.`ASSET_ACCOUNT_ID` WHERE tx.`ID` = '{gsID}' Limit 1", gsNew, This_BS)
        fClear_Info()
        gsID = ""
        gsNew = True
        Me.Enabled = True
        numRATE.DecimalPlaces = 0

        If fACCESS_NEW_EDIT(frmTax, gsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class