Imports System.Data.Odbc
Public Class FrmContactDetails
    Dim Frm As Form
    Public gsTITLE As String
    Public gsOK As Boolean = False
    Public ContactTypeId As Integer
    Public IsNew As Boolean = False
    Public ID As Integer
    Public gsDgv As DataGridView
    Public this_BS As BindingSource

    Private Sub RefreshCombo()
        ComboBoxLoad(cmbTAX_ID, "select * from tax where tax_type='3'", "ID", "NAME")
        ComboBoxLoad(cmbGROUP_ID, "select * from contact_group", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbPAYMENT_TERMS_ID, "select * from payment_terms", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbSALES_REP_ID, "select * from contact  where type ='2' order by `NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbPRICE_LEVEL_ID, "select * from price_level", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbPREF_PAYMENT_METHOD_ID, "select * from payment_method", "ID", "DESCRIPTION")

        Select Case ContactTypeId
            Case 1
                ComboBoxLoad(cmbREFERRAL_ID, "select * from contact where type in ('6','1','2') order by `NAME` ", "ID", "NAME")
                On Error Resume Next
                cmbTAX_ID.SelectedIndex = 0
            Case 6
                ComboBoxLoad(cmbREFERRAL_ID, "select * from contact where type in('6','1','2') order by `NAME`", "ID", "NAME")
        End Select


        With cboSALUTATION
            .Items.Clear()
            .Items.Add("")
            .Items.Add("Dr")
            .Items.Add("Miss")
            .Items.Add("Mr.")
            .Items.Add("Mrs.")
            .Items.Add("Ms.")
            .Items.Add("Prof.")

        End With

        If gsPOS_Mode = True Then
            'Active From POS - Create Customer Only
            CheckingDiscountCardNumber()
        End If

    End Sub

    Private Sub CheckingDiscountCardNumber()
        Dim rd As OdbcDataReader = SqlReader($"select next_number,prefix from discountcardnumber where location_id = '{gsDefault_LOCATION_ID}'  limit 1;")
        If rd.Read Then
            Dim get_digit As String = ""
            For r As Integer = 1 To 6
                get_digit &= "0"
            Next

            txtACCOUNT_NO.Text = NumIsNull(rd("prefix")) & NumIsNull(rd("next_number")).ToString(get_digit)
        Else

            SqlExecuted($"INSERT INTO discountcardnumber SET  location_id = '{gsDefault_LOCATION_ID}',next_number ='1' ")
            CheckingDiscountCardNumber()
        End If
        rd.Close()
    End Sub

    Private Sub UpdateDiscountCardNumber()
        Dim rd As OdbcDataReader = SqlReader($"select next_number from discountcardnumber where location_id = '{gsDefault_LOCATION_ID}'  limit 1;")
        If rd.Read Then
            SqlExecuted($"UPDATE discountcardnumber SET `next_number` = '{ NumIsNull(rd("next_number")) + 1}' where location_id = '{gsDefault_LOCATION_ID}'  limit 1;")
        End If
        rd.Close()
    End Sub
    Private Sub RefreshForm()
        RefreshCombo()
        Try
            Dim sQuery As String = "select * from contact where id = '" & ID & "' Limit 1;"
            SqlExecutedUsingReading(Me, sQuery)


        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshForm()
            Else
                End
            End If
        End Try
    End Sub
    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        If gsPOS_Mode = True Then
            gsOK = False
        End If
        Me.Close()
    End Sub

    Private Sub FrmContact_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsPOS_Mode = True Or (this_BS Is Nothing And gsDgv Is Nothing) Then
            tsSaveNew.Text = "&Save"
        End If

        Select Case ContactTypeId
            Case 0 ' Vendor
                Frm = FrmVendor
                xlblTAX.Text = "Input Tax"
                gsTITLE = "Vendor"
                Label21.Visible = False
                Label23.Visible = False
                Label24.Visible = False
                xlblCardNUmber.Visible = False
                Label26.Visible = False
                Label27.Visible = False
                cmbSALES_REP_ID.Visible = False
                numCREDIT_LIMIT.Visible = False
                cmbPREF_PAYMENT_METHOD_ID.Visible = False
                txtCREDIT_CARD_NO.Visible = False
                dtpCREDIT_CARD_EXPIRY_DATE.Visible = False
                Label27.Visible = False
                cmbPRICE_LEVEL_ID.Visible = False
                chkAPPLY_FINANCE_CHARGE.Visible = False

                xnumDISCOUNT.Visible = False



            Case 1 'Customer
                Frm = FrmCustomer
                xlblTAX.Text = "Output Tax"
                dtpCUSTOM_FIELD4.Checked = True
                gsTITLE = "Customer"
            Case 2 'Employee


                Frm = FrmEmployee
                xlblTAX.Visible = False
                cmbTAX_ID.Visible = False
                gsTITLE = IIf(gsPOS_Mode = True, "Salesman", "Member")


                xlblLevel.Text = "Position"

                Label28.Visible = False
                Label29.Visible = False
                xlblOriented.Visible = False
                dtpCUSTOM_FIELD3.Visible = False
                dtpCUSTOM_FIELD4.Visible = False
                txtCUSTOM_FIELD5.Visible = False

            Case 3 'Tax Agency
                gsTITLE = "Tax Agency"
            Case 4 'Other Contacts
                gsTITLE = "Other Contacts"

            Case 5 'Manager
                xlblTAX.Visible = False
                cmbTAX_ID.Visible = False
                Frm = FrmManager

                lbxDiscount.Visible = True
                xnumDISCOUNT.Visible = True

            Case 6 'Dealer
                xlblTAX.Visible = False
                cmbTAX_ID.Visible = False
                Frm = FrmDealer
                gsTITLE = "Dealer"

        End Select


        RefreshForm()

        If IsNew = False Then
            Me.Text = gsTITLE & " :: EDIT"
            txtACCOUNT_NO.Enabled = True
            txtNAME.Enabled = True
        Else
            Me.Text = gsTITLE & " :: NEW"
            txtACCOUNT_NO.Enabled = True
            txtNAME.Enabled = True

        End If

        chkINACTIVE.Text = gsTITLE & " is inactive"
    End Sub
    Private Sub TxtNAME_TextChanged(sender As Object, e As EventArgs) Handles txtNAME.TextChanged
        If IsNew = True Then
            txtCOMPANY_NAME.Text = txtNAME.Text.Trim
            txtPRINT_NAME_AS.Text = txtNAME.Text.Trim

        End If
    End Sub

    Private Sub TxtNAME_Click(sender As Object, e As EventArgs) Handles txtNAME.Click

        KeyBoardToTouch(txtNAME, xlblName.Text)

    End Sub

    Private Sub TxtLAST_NAME_TextChanged(sender As Object, e As EventArgs) Handles txtLAST_NAME.TextChanged

    End Sub

    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click

        If Trim(txtNAME.Text) = "" Then
            MessageBoxWarning("Please Enter Name")
            Exit Sub
        End If

        If IsNew = True Then
            txtNAME.Text = Trim(txtNAME.Text.ToUpper)
            Try
                Dim rd As OdbcDataReader = SqlReader("select ID from contact where name ='" & txtNAME.Text & "' Limit 1")
                If rd.Read Then
                    MessageBoxExclamation("Name is already registered")
                    rd.Close()
                    Exit Sub
                End If
                rd.Close()

            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then

                Else
                    End
                End If

                Exit Sub
            End Try

            If Trim(txtACCOUNT_NO.Text) = "" Then
                Dim dAcount_No As Double = Val(GetMaxFieldLine("ACCOUNT_NO", "CONTACT", "TYPE", ContactTypeId))
                txtACCOUNT_NO.Text = dAcount_No.ToString("0000")
                ObjectTypeMapNextIdUpdateByName(dAcount_No, GetStringFieldValue("CONTACT_TYPE_MAP", "ID", ContactTypeId, "DESCRIPTION"))
            End If


            ID = ObjectTypeMapId("CONTACT")
            Dim SQL_Field As String = ""
            Dim SQL_Value As String = ""
            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO contact ({SQL_Field},ID,`TYPE`) VALUES ({SQL_Value},{ID},'{ContactTypeId}') ")
            PrompNotify(Me.Text, SaveMsg, True)
            If gsPOS_Mode = True Or (this_BS Is Nothing And gsDgv Is Nothing) Then

                'Must have a Function
                UpdateDiscountCardNumber()

                gsOK = True
                Me.Close()
                Exit Sub
            End If
        Else
            Dim sQuery As String = SqlUpdate(Me)
            SqlExecuted("UPDATE contact set " & sQuery & " where ID = '" & ID & "' and TYPE = '" & ContactTypeId & "'")
            PrompNotify(Me.Text, UpdateMsg, True)

        End If


        Dim sql_Refresh As String = ""
        Select Case ContactTypeId
            Case 0 'VENDOR
                sql_Refresh = "SELECT 
    c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  g.DESCRIPTION AS 'Group',
  p.DESCRIPTION AS 'Pmt. Terms',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
 if(c.Inactive=0,'No','Yes') as `Inactive` 
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
LEFT  OUTER JOIN contact AS s 
    ON c.sales_rep_id = s.ID 
    AND s.Type = '2' 
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
 LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '0' and c.`ID` = '" & ID & "' limit 1"

            Case 1 ' CUSTOMER
                sql_Refresh = "SELECT 
  c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  c.MOBILE_NO As `Mobile Number`,
  c.CUSTOM_FIELD4 as `Date Sign-In`,
  g.DESCRIPTION AS 'Group',
  s.name AS 'Sales Rep',
  d.name AS 'Dealer',
  p.DESCRIPTION AS 'Pmt. Terms',
  format(c.Credit_limit,2) AS 'Credit Limit',
  pl.DESCRIPTION AS 'Price Level',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
  if(c.Inactive=0,'No','Yes') as `Inactive` 
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
LEFT  OUTER JOIN contact AS s 
    ON c.sales_rep_id = s.ID 
    AND s.Type = '2' 
LEFT  OUTER JOIN contact AS d 
    ON c.other_contact_id = d.ID 
    AND d.Type = '6'
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
 LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '1' and c.ID = '" & ID & "' limit 1"
            Case 2 'EMPLOYEE
                sql_Refresh = "SELECT 
  c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  g.DESCRIPTION AS 'Group',
  s.name AS 'Sales Rep',
  p.DESCRIPTION AS 'Pmt. Terms',
  c.Credit_limit AS 'Credit Limit',
  pl.DESCRIPTION AS 'Price Level',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
  if(c.Inactive=0,'No','Yes') as `Inactive`
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
LEFT  OUTER JOIN contact AS s 
    ON c.sales_rep_id = s.ID 
    AND s.Type = '2' 
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
 LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '2' and c.`ID` = '" & ID & "' limit 1"
            Case 3

            Case 4
            Case 5 'MANAGER
            Case 6 'DEALER
                sql_Refresh = "SELECT 
  c.ID,
  c.Name,
  c.POSTAL_ADDRESS AS 'Postal Address',
  c.CONTACT_PERSON AS 'Contact Person',
  c.TELEPHONE_NO AS 'Telephone Number',
  g.DESCRIPTION AS 'Group',
  s.name AS 'Sale Manager',
  p.DESCRIPTION AS 'Pmt. Terms',
  format(c.Credit_limit,2) AS 'Credit Limit',
  pl.DESCRIPTION AS 'Price Level',
  c.ACCOUNT_NO AS 'Account Number',
  c.Taxpayer_id AS 'Taxpayer Id No.',
  c.Inactive 
FROM
  contact AS c 
 LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID
LEFT OUTER JOIN contact AS s 
    ON c.Sales_REP_ID = s.ID 
    AND s.Type = '2' 
 LEFT OUTER JOIN payment_terms AS p
    ON p.id = c.payment_terms_id 
 LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '6' and c.`ID` = '" & ID & "' limit 1"
        End Select



        fContactUpdate(gsDgv, IsNew, this_BS, sql_Refresh)
        IsNew = True
        ID = 0
        RefreshCombo()
        ClearAndRefresh(Me)


        Me.Text = gsTITLE & " :: NEW"
        txtACCOUNT_NO.Enabled = True
        txtNAME.Enabled = True
        Me.Refresh()

        If SecurityAccessMode(Frm, IsNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        RefreshForm()
    End Sub
    Private Sub TxtCOMPANY_NAME_Click(sender As Object, e As EventArgs) Handles txtCOMPANY_NAME.Click
        KeyBoardToTouch(txtCOMPANY_NAME, xlblCompanyName.Text)
    End Sub
    Private Sub TxtFIRST_NAME_Click(sender As Object, e As EventArgs) Handles txtFIRST_NAME.Click
        KeyBoardToTouch(txtFIRST_NAME, "Firstname")
    End Sub

    Private Sub TxtMIDDLE_NAME_Click(sender As Object, e As EventArgs) Handles txtMIDDLE_NAME.Click
        KeyBoardToTouch(txtMIDDLE_NAME, "M.I")
    End Sub
    Private Sub TxtLAST_NAME_Click(sender As Object, e As EventArgs) Handles txtLAST_NAME.Click
        KeyBoardToTouch(txtLAST_NAME, "Lastname")
    End Sub
    Private Sub TxtCONTACT_PERSON_Click(sender As Object, e As EventArgs) Handles txtCONTACT_PERSON.Click
        KeyBoardToTouch(txtCONTACT_PERSON, xlblContactPerson.Text)
    End Sub
    Private Sub TxtTELEPHONE_NO_Click(sender As Object, e As EventArgs) Handles txtTELEPHONE_NO.Click
        KeyBoardToTouch(txtTELEPHONE_NO, xlblTeleNumber.Text)
    End Sub
    Private Sub TxtEMAIL_Click(sender As Object, e As EventArgs) Handles txtEMAIL.Click
        KeyBoardToTouch(txtEMAIL, xlblEmail.Text)
    End Sub
    Private Sub TxtMOBILE_NO_Click(sender As Object, e As EventArgs) Handles txtMOBILE_NO.Click
        KeyBoardToTouch(txtMOBILE_NO, xlblMobile.Text)
    End Sub

    Private Sub TxtFAX_NO_Click(sender As Object, e As EventArgs) Handles txtFAX_NO.Click
        KeyBoardToTouch(txtFAX_NO, xlblFaxNumber.Text)
    End Sub
End Class