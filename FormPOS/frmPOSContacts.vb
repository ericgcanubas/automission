Public Class frmPOSContacts
    Public gsContact_ID As String
    Public gsOK As Boolean = False
    Public gsContact_Type As Integer = 0
    Public gsNewContact As Boolean = False

    Private Function fGetnameContact() As String

        Select Case gsContact_Type
            Case 0
                Return "Vendor"
            Case 1
                Return "Customer"
            Case 2
                btnDefault.Text = "None"
                Return "Sales Rep."

            Case 3
                Return "Tax Agency"
            Case 4
                Return "Other Contacts"
            Case Else
                Return ""
        End Select

    End Function
    Private Sub frmPOSCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gsNewContact = False
        ' Me.BackColor = ColorTranslator.FromHtml(gsColor_Code)
        Me.Icon = gsIcon
        gsOK = False
        txtName.Text = "999999999999999"
        fRefresh()
        txtName.Clear()
        btnNewContact.Text = "New " & fGetnameContact()
        Me.Text = fGetnameContact()
    End Sub
    Private Sub fRefresh()
        Dim squery As String = "select c.ID,c.NAME,c.ACCOUNT_NO  as `Account No.` from contact as c  where c.INACTIVE = '0' and type ='" & gsContact_Type & "' and ( c.Name like '%" & txtName.Text.Replace("'", "`") & "%' or c.ACCOUNT_NO like '%" & txtName.Text.Replace("'", "`") & "%') order by c.`NAME` limit 100 "
        LoadDataGridView(dgvContact, squery)
        dgvContact.Columns(0).Visible = False

    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        fRefresh()
    End Sub
    Private Sub fselect()
        Try
            If dgvContact.Rows.Count = 0 Then Exit Sub
            gsContact_ID = dgvContact.Rows(dgvContact.CurrentRow.Index).Cells(0).Value
            gsOK = True
            Me.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fselect()
            Else
                End
            End If
        End Try

    End Sub
    Private Sub dgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvContact.CellDoubleClick
        fselect()
    End Sub
    Private Sub dgvCustomer_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            fselect()
        End If
    End Sub

    Private Sub txtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Down Then
            dgvContact.Focus()
        End If
    End Sub
    Private Sub frmPOSContacts_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ViewNotSort(dgvContact)
        dgvContact.Columns(1).Width = 250
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        If gsContact_Type = 2 Then
            gsContact_ID = 0
        Else
            gsContact_ID = gsPOSDefaultCustomer_ID
        End If
        gsOK = True
        Me.Close()
    End Sub

    Private Sub BtnNewContact_Click_1(sender As Object, e As EventArgs) Handles btnNewContact.Click
        gsNewContact = True
        Me.Close()
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        fselect()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsOK = False
        Me.Close()
    End Sub
    Private Sub fMaster_keydown()

    End Sub

    Private Sub txtName_Click(sender As Object, e As EventArgs) Handles txtName.Click
        fKeyBoardToTouch(txtName, Me.Text)
    End Sub
End Class