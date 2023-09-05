Imports System.Data.Odbc
Public Class frmContactDetails
    Dim f As Form
    Public gsTITLE As String
    Public gsOK As Boolean = False
    Public gsContact_Type As String = ""
    Public bNew As Boolean
    Public gsID As Integer
    Public gsDgv As DataGridView
    Public this_BS As BindingSource

    Private Sub fRefreshCombo()
        fComboBox(cmbTAX_ID, "select * from tax where tax_type='3'", "ID", "NAME")

        fComboBox(cmbGROUP_ID, "select * from contact_group", "ID", "DESCRIPTION")
        fComboBox(cmbPAYMENT_TERMS_ID, "select * from payment_terms", "ID", "DESCRIPTION")
        fComboBox(cmbSALES_REP_ID, "select * from contact  where type ='2' order by `NAME` ", "ID", "NAME")
        fComboBox(cmbPRICE_LEVEL_ID, "select * from price_level", "ID", "DESCRIPTION")
        fComboBox(cmbPREF_PAYMENT_METHOD_ID, "select * from payment_method", "ID", "DESCRIPTION")

        Select Case gsContact_Type
            Case "1"
                '  fComboBox(cmbOther_Contact_ID, "select * from contact where type ='6' order by `NAME`", "ID", "NAME")
                fComboBox(cmbREFERRAL_ID, "select * from contact where type in('6','1','2') order by `NAME` ", "ID", "NAME")
                On Error Resume Next
                cmbTAX_ID.SelectedIndex = 0
            Case "6"
                ' fComboBox(cmbOther_Contact_ID, "select * from contact where type ='6' order by `NAME` ", "ID", "NAME")
                fComboBox(cmbREFERRAL_ID, "select * from contact where type in('6','1','2') order by `NAME`", "ID", "NAME")
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
            fCheckingDiscountCardNumber()
        End If

    End Sub

    Private Sub fCheckingDiscountCardNumber()


        Dim rd As OdbcDataReader = fReader($"select next_number,prefix from discountcardnumber where location_id = '{gsDefault_LOCATION_ID}'  limit 1;")

        If rd.Read Then
            Dim get_digit As String = ""
            For r As Integer = 1 To 6
                get_digit = get_digit & "0"
            Next

            txtACCOUNT_NO.Text = fNumisNULL(rd("prefix")) & fNumisNULL(rd("next_number")).ToString(get_digit)
        Else

            fExecutedOnly($"INSERT INTO discountcardnumber SET  location_id = '{gsDefault_LOCATION_ID}',next_number ='1' ")
            fCheckingDiscountCardNumber()
        End If
        rd.Close()
    End Sub

    Private Sub fUpdateDiscountCardNumber()

        Dim rd As OdbcDataReader = fReader($"select next_number from discountcardnumber where location_id = '{gsDefault_LOCATION_ID}'  limit 1;")

        If rd.Read Then
            fExecutedOnly($"UPDATE discountcardnumber SET `next_number` = '{ fNumisNULL(rd("next_number")) + 1}' where location_id = '{gsDefault_LOCATION_ID}'  limit 1;")
        End If
        rd.Close()
    End Sub
    Private Sub fRefreshForm()
        fRefreshCombo()
        Try
            Dim sQuery As String = "select * from contact where id = '" & gsID & "' Limit 1;"
            fExecutedUsingReading(Me, sQuery)


        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshForm()
            Else
                End
            End If
        End Try
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        If gsPOS_Mode = True Then
            gsOK = False
        End If
        Me.Close()
    End Sub

    Private Sub frmContact_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If gsContact_Type = "" Then
            fMessageboxExclamation("Invalid contact type")
            Exit Sub
        Else
            If gsPOS_Mode = True Or (this_BS Is Nothing And gsDgv Is Nothing) Then
                tsSaveNew.Text = "&Save"

            End If

            Select Case gsContact_Type
                Case "0" ' Vendor
                    f = frmVendor
                    xlblTAX.Text = "Input Tax"
                    gsTITLE = "Seller"
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

                    If bNew = False Then
                        Me.Text = "Edit Seller"
                    Else
                        Me.Text = "New Seller"
                    End If

                Case "1" 'Customer
                    f = frmCustomer
                    xlblTAX.Text = "Output Tax"


                    dtpCUSTOM_FIELD4.Checked = True
                    gsTITLE = "Buyer"




                Case "2" 'Employee


                    f = frmEmployee
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




                Case "3" 'Tax Agency
                    gsTITLE = "Tax Agency"
                Case "4" 'Other Contacts
                    gsTITLE = "Other Contacts"

                Case "5" 'Manager
                    xlblTAX.Visible = False
                    cmbTAX_ID.Visible = False
                    f = frmManager

                    lbxDiscount.Visible = True
                    xnumDISCOUNT.Visible = True

                Case "6" 'Dealer
                    xlblTAX.Visible = False
                    cmbTAX_ID.Visible = False
                    f = frmDealer
                    gsTITLE = "Dealer"

            End Select
        End If


        fRefreshForm()

        If bNew = False Then
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
    Private Sub txtNAME_TextChanged(sender As Object, e As EventArgs) Handles txtNAME.TextChanged
        If bNew = True Then
            txtCOMPANY_NAME.Text = txtNAME.Text.Trim
            txtPRINT_NAME_AS.Text = txtNAME.Text.Trim

        End If
    End Sub

    Private Sub txtNAME_Click(sender As Object, e As EventArgs) Handles txtNAME.Click

        fKeyBoardToTouch(txtNAME, xlblName.Text)

    End Sub

    Private Sub TxtLAST_NAME_TextChanged(sender As Object, e As EventArgs) Handles txtLAST_NAME.TextChanged

    End Sub

    Private Sub BtnSAVE_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        If gsContact_Type = "" Then
            fMessageboxExclamation("No sign for contact type")
            Exit Sub
        End If
        If Trim(txtNAME.Text) = "" Then
            fMessageboxWarning("Please Enter Name")
            Exit Sub
        End If

        If bNew = True Then
            txtNAME.Text = Trim(txtNAME.Text.ToUpper)
            Try
                Dim rd As OdbcDataReader = fReader("select ID from contact where name ='" & txtNAME.Text & "' Limit 1")
                If rd.Read Then
                    fMessageboxExclamation("Name is already registered")
                    rd.Close()
                    Exit Sub
                End If
                rd.Close()

            Catch ex As Exception
                If fMessageBoxErrorYesNo(ex.Message) = True Then

                Else
                    End
                End If

                Exit Sub
            End Try

            If Trim(txtACCOUNT_NO.Text) = "" Then
                Dim dAcount_No As Double = Val(fGetMaxField_LINE("ACCOUNT_NO", "CONTACT", "TYPE", gsContact_Type))
                txtACCOUNT_NO.Text = dAcount_No.ToString("0000")
                fObjectTypeMap_NEXT_ID_UPDATE0(dAcount_No, fGetFieldValue("CONTACT_TYPE_MAP", "ID", gsContact_Type, "DESCRIPTION"))
            End If

            Dim sQuery As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("CONTACT")
            fExecutedOnly("INSERT INTO contact set " & sQuery & ", TYPE = '" & gsContact_Type & "',ID = '" & gsID & "'")
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
            If gsPOS_Mode = True Or (this_BS Is Nothing And gsDgv Is Nothing) Then

                'Must have a Function
                fUpdateDiscountCardNumber()

                gsOK = True
                Me.Close()
                Exit Sub
            End If
        Else
            Dim sQuery As String = fFieldCollector(Me)
            fExecutedOnly("UPDATE contact set " & sQuery & " where ID = '" & gsID & "' and TYPE = '" & gsContact_Type & "'")

            fPop_Up_Msg(Me.Text, gsUpdateStr, True)

        End If


        Dim sql_Refresh As String = ""
        Select Case gsContact_Type
            Case "0" 'VENDOR
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
WHERE c.Type = '0' and c.`ID` = '" & gsID & "' limit 1"

            Case "1" ' CUSTOMER
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
WHERE c.Type = '1' and c.ID = '" & gsID & "' limit 1"
            Case "2" 'EMPLOYEE
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
WHERE c.Type = '2' and c.`ID` = '" & gsID & "' limit 1"
            Case "3"

            Case "4"
            Case "5" 'MANAGER
            Case "6" 'DEALER
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
WHERE c.Type = '6' and c.`ID` = '" & gsID & "' limit 1"
        End Select



        fContactUpdate(gsDgv, bNew, this_BS, sql_Refresh)
        bNew = True
        gsID = 0
        fRefreshCombo()
        fCLean_and_refresh(Me)


        Me.Text = gsTITLE & " :: NEW"
        txtACCOUNT_NO.Enabled = True
        txtNAME.Enabled = True
        Me.Refresh()

        If fACCESS_NEW_EDIT(f, bNew) = False Then
            Me.Close()
        End If
    End Sub

    Private Sub BtnCANCEL_Click(sender As Object, e As EventArgs) Handles btnCANCEL.Click
        Me.Close()
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        fRefreshForm()
    End Sub

    Private Sub TxtCOMPANY_NAME_TextChanged(sender As Object, e As EventArgs) Handles txtCOMPANY_NAME.TextChanged

    End Sub

    Private Sub txtCOMPANY_NAME_Click(sender As Object, e As EventArgs) Handles txtCOMPANY_NAME.Click

        fKeyBoardToTouch(txtCOMPANY_NAME, xlblCompanyName.Text)


    End Sub

    Private Sub TxtFIRST_NAME_TextChanged(sender As Object, e As EventArgs) Handles txtFIRST_NAME.TextChanged

    End Sub

    Private Sub TxtMIDDLE_NAME_TextChanged(sender As Object, e As EventArgs) Handles txtMIDDLE_NAME.TextChanged

    End Sub

    Private Sub txtFIRST_NAME_Click(sender As Object, e As EventArgs) Handles txtFIRST_NAME.Click
        fKeyBoardToTouch(txtFIRST_NAME, "Firstname")
    End Sub

    Private Sub txtMIDDLE_NAME_Click(sender As Object, e As EventArgs) Handles txtMIDDLE_NAME.Click
        fKeyBoardToTouch(txtMIDDLE_NAME, "M.I")
    End Sub

    Private Sub txtLAST_NAME_Click(sender As Object, e As EventArgs) Handles txtLAST_NAME.Click
        fKeyBoardToTouch(txtLAST_NAME, "Lastname")
    End Sub

    Private Sub TxtCONTACT_PERSON_TextChanged(sender As Object, e As EventArgs) Handles txtCONTACT_PERSON.TextChanged

    End Sub

    Private Sub txtCONTACT_PERSON_Click(sender As Object, e As EventArgs) Handles txtCONTACT_PERSON.Click
        fKeyBoardToTouch(txtCONTACT_PERSON, xlblContactPerson.Text)
    End Sub

    Private Sub TxtTELEPHONE_NO_TextChanged(sender As Object, e As EventArgs) Handles txtTELEPHONE_NO.TextChanged

    End Sub

    Private Sub txtTELEPHONE_NO_Click(sender As Object, e As EventArgs) Handles txtTELEPHONE_NO.Click

        fKeyBoardToTouch(txtTELEPHONE_NO, xlblTeleNumber.Text)
    End Sub

    Private Sub TxtEMAIL_TextChanged(sender As Object, e As EventArgs) Handles txtEMAIL.TextChanged

    End Sub

    Private Sub txtEMAIL_Click(sender As Object, e As EventArgs) Handles txtEMAIL.Click
        fKeyBoardToTouch(txtEMAIL, xlblEmail.Text)
    End Sub

    Private Sub TxtMOBILE_NO_TextChanged(sender As Object, e As EventArgs) Handles txtMOBILE_NO.TextChanged

    End Sub

    Private Sub txtMOBILE_NO_Click(sender As Object, e As EventArgs) Handles txtMOBILE_NO.Click
        fKeyBoardToTouch(txtMOBILE_NO, xlblMobile.Text)
    End Sub

    Private Sub TxtFAX_NO_Click(sender As Object, e As EventArgs) Handles txtFAX_NO.Click
        fKeyBoardToTouch(txtFAX_NO, xlblFaxNumber.Text)
    End Sub
End Class