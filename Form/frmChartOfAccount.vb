Imports System.Data.Odbc
Public Class FrmChartOfAccount
    Public item_BS As BindingSource
    Public gsFindMode As Boolean
    Public gsFindID As Double

    Private Sub RefreshData()
        Dim SQL As String = ""
        If gsFindMode = False Then
            SQL = "SELECT a.`ID`,a.`Name`,atm.`DESCRIPTION` AS `Type`,a.`BANK_ACCOUNT_NO` as `Bank Account No.`,a.`LINE_NO` as `Line No.`,IFNULL(ag.`NAME`,'') AS `Group of Accounts`, if(a.`Inactive`=0,'No','Yes') as `Inactive` FROM  account a LEFT OUTER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` LEFT OUTER JOIN account AS ag ON ag.`ID` = a.`GROUP_ACCOUNT_ID` Order by a.`ID`"
        Else
            SQL = $"SELECT a.`ID`,a.`Name`,atm.`DESCRIPTION` AS `Type`,a.`BANK_ACCOUNT_NO` as `Bank Account No.`,a.`LINE_NO` as `Line No.`,IFNULL(ag.`NAME`,'') AS `Group of Accounts`, if(a.`Inactive`=0,'No','Yes') as `Inactive` FROM  account a LEFT OUTER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` LEFT OUTER JOIN account AS ag ON ag.`ID` = a.`GROUP_ACCOUNT_ID` where a.INACTIVE ='0' Order by a.`ID`"
        End If

        LoadDataGridViewBinding(dgvAccount, SQL, item_BS)

        With dgvAccount.Columns
            .Item(0).Visible = False
        End With
        ViewColumn(dgvAccount, 18)


    End Sub


    Private Sub FrmCOA_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm

        gsFindID = 0
        If gsFindMode = True Then

            tsCreate.Visible = False
            tsDelete.Visible = False
            tsUpdate.Visible = False
            tsColumn.Visible = False
            tsTITLE.Visible = False
            ToolStripSeparator1.Visible = False
            ToolStripSeparator2.Visible = False
            ToolStripSeparator3.Visible = False

        End If


    End Sub


    Private Sub EditAccount()
        If dgvAccount.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If

        If SecurityAccessMode(Me, False) = False Then
            Exit Sub
        End If

        Try
            dgvAccount.Focus()
            Dim i As Integer = dgvAccount.CurrentRow.Index
            Dim ID As Integer = dgvAccount.Rows.Item(i).Cells(0).Value



            FrmAccount.BS = item_BS
            FrmAccount.View = dgvAccount
            FrmAccount.IsNew = False
            FrmAccount.ID = ID
            FrmAccount.ShowDialog()
            FrmAccount.Dispose()
            FrmAccount = Nothing

        Catch ex As Exception

        End Try

    End Sub
    Private Sub DgvCustomer_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvAccount.CellDoubleClick
        SelectData()
    End Sub
    Private Sub SelectData()
        If gsFindMode = False Then
            EditAccount()
        Else
            If dgvAccount.Rows.Count = 0 Then
                MessageBoxInfo("Data not found")
                Exit Sub
            End If
            gsFindID = dgvAccount.CurrentRow.Cells("ID").Value
            Me.Close()

        End If
    End Sub

    Private Sub SearchLoad()
        Try
            Dim strFInd As String = ""
            For I As Integer = 0 To dgvAccount.Columns.Count - 1

                If dgvAccount.Columns(I).Visible = True Then
                    If I > 0 Then


                        If strFInd = "" Then
                            strFInd = $"[{dgvAccount.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strFInd = strFInd & $" OR [{dgvAccount.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"

                        End If

                    End If
                End If


            Next


            item_BS.Filter = strFInd
        Catch ex As Exception

        End Try
    End Sub
    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub
    Private Sub DgvAccount_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvAccount.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub JournalEndingRecomToolStripMenuItem_Click(sender As Object, e As EventArgs)
        If gsAdmin_User = False Then Exit Sub
        FrmSelectLocation.ShowDialog()

        If FrmSelectLocation.gsOK = True Then
            CursorLoadingOn(True)
            Dim Loc_ID As Integer = FrmSelectLocation.cmbLOCATION_ID.SelectedValue
            For I As Integer = 0 To dgvAccount.Rows.Count - 1
                SetJournalAccount(dgvAccount.Rows(I).Cells("ID").Value, Loc_ID)
            Next
            CursorLoadingOn(False)
        End If
        FrmSelectLocation.Dispose()
        FrmSelectLocation = Nothing

    End Sub

    Private Sub SetJournalAccount(ByVal prAccount As Integer, ByVal prLocation As Integer)
        Dim BALANCE As Double = 0
        Dim TEMP_SQL As String = ""
        Dim rd As OdbcDataReader = SqlReader($"SELECT * FROM ACCOUNT_JOURNAL WHERE ACCOUNT_ID = '{prAccount}' and LOCATION_ID ='{prLocation}' ORDER BY OBJECT_DATE,ID ")

        While rd.Read

            If NumIsNull(rd("ENTRY_TYPE")) = 0 Then
                BALANCE += NumIsNull(rd("AMOUNT"))
            Else
                BALANCE -= NumIsNull(rd("AMOUNT"))
            End If
            TEMP_SQL &= $" UPDATE `ACCOUNT_JOURNAL` SET ENDING_BALANCE ='{BALANCE}' WHERE `ID`='{rd("ID")}' and LOCATION_ID ='{prLocation}' and ACCOUNT_ID ='{prAccount}'  limit 1;"
        End While

        If TEMP_SQL <> "" Then
            SqlExecuted(TEMP_SQL)
        End If


    End Sub
    Private Sub JournalAccount_Fixed_PREVIOUS_ID(ByVal prAccount As Integer, ByVal prLocation As Integer)

        Dim TEMP_SQL As String = ""
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID FROM ACCOUNT_JOURNAL WHERE ACCOUNT_ID = '{prAccount}' and LOCATION_ID ='{prLocation}' ORDER BY ID ")
        Dim PREVIOUS_ID As Integer = 0
        Dim SEQUENCE_NO As Integer = 0
        While rd.Read

            TEMP_SQL &= $" UPDATE `ACCOUNT_JOURNAL` SET PREVIOUS_ID={ GotNullNumber(PREVIOUS_ID)},SEQUENCE_NO='{SEQUENCE_NO}' WHERE `ID`='{rd("ID")}' and LOCATION_ID ='{prLocation}' and ACCOUNT_ID ='{prAccount}'  limit 1;"
            PREVIOUS_ID = NumIsNull(rd("ID"))
            SEQUENCE_NO += 1
        End While

        If TEMP_SQL <> "" Then
            SqlExecuted(TEMP_SQL)
        End If


    End Sub
    Private Sub DgvAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvAccount.KeyDown
        If gsFindMode = False Then


            If (e.KeyCode = Keys.U AndAlso e.Modifiers = Keys.Control) Then
                FrmSelectLocation.ShowDialog()

                If FrmSelectLocation.gsOK = True Then
                    Dim Loc_ID As Integer = FrmSelectLocation.cmbLOCATION_ID.SelectedValue
                    CursorLoadingOn(True)
                    Dim I As Integer = dgvAccount.CurrentRow.Index
                    SetJournalAccount(dgvAccount.Rows(I).Cells("ID").Value, Loc_ID)
                    CursorLoadingOn(False)
                End If
                FrmSelectLocation.Dispose()
                FrmSelectLocation = Nothing
            End If

        Else

            If e.KeyCode = Keys.Enter Then
                SelectData()
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then

            Else
                tsTxtSearch.Focus()
            End If

        End If
    End Sub

    Private Sub JouranlFIxedPreviewToolStripMenuItem_Click(sender As Object, e As EventArgs)

        If gsAdmin_User = False Then Exit Sub

        FrmSelectLocation.ShowDialog()
        If FrmSelectLocation.gsOK = True Then
            Dim Loc_ID As Integer = FrmSelectLocation.cmbLOCATION_ID.SelectedValue
            CursorLoadingOn(True)
            For I As Integer = 0 To dgvAccount.Rows.Count - 1
                JournalAccount_Fixed_PREVIOUS_ID(dgvAccount.Rows(I).Cells("ID").Value, Loc_ID)
            Next
            CursorLoadingOn(False)
        End If
        FrmSelectLocation.Dispose()
        FrmSelectLocation = Nothing


    End Sub


    Private Sub TsTxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles tsTxtSearch.KeyDown
        If e.KeyCode = Keys.Down Or e.KeyCode = Keys.Enter Then
            dgvAccount.Select()
        End If
    End Sub

    Private Sub TsCreate_Click(sender As Object, e As EventArgs) Handles tsCreate.Click
        If SecurityAccessMode(Me, True) = False Then
            Exit Sub
        End If
        FrmAccount.BS = item_BS
        FrmAccount.View = dgvAccount
        FrmAccount.IsNew = True
        FrmAccount.ID = 0
        FrmAccount.ShowDialog()
        FrmAccount.Dispose()
        FrmAccount = Nothing
    End Sub

    Private Sub TsUpdate_Click(sender As Object, e As EventArgs) Handles tsUpdate.Click
        EditAccount()
    End Sub

    Private Sub TsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If dgvAccount.Rows.Count = 0 Then
            MessageBoxWarning("Data not found")
            Exit Sub
        End If
        Try
            If SecurityAccessDelete(Me) = False Then

                Exit Sub
            End If
            dgvAccount.Focus()
            Dim i As Integer = dgvAccount.CurrentRow.Index
            Dim dID As String = dgvAccount.Rows.Item(i).Cells(0).Value
            Dim dName As String = dgvAccount.Rows.Item(i).Cells(1).Value
            If MessageBoxQuestion("Do you really want to delete  " & dName & "?") = True Then
                SqlExecuted("Delete From account where id='" & dID & "' limit 1;")
                DeleteNotify(Me)
                RefreshData()
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsSearch_Click(sender As Object, e As EventArgs) Handles tsSearch.Click
        SearchLoad()
    End Sub

    Private Sub TsColumn_Click(sender As Object, e As EventArgs) Handles tsColumn.Click
        ViewSwitch(dgvAccount, 18)
        ViewColumn(dgvAccount, 18)
    End Sub

    Private Sub TsReload_Click(sender As Object, e As EventArgs) Handles tsReload.Click
        RefreshData()
    End Sub

    Private Sub FrmChartOfAccount_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        RefreshData()
    End Sub
End Class