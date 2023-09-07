
Public Class frmFundTransfer
    Public ID As Integer = gsDocument_Finder_ID
    Public IsNew As Boolean = IIf(ID = 0, True, False)
    Dim Frm As Form = New frmFindDocument

    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = SqlUpdate(Me) & "," & SqlUpdate(GroupBox1) & "," & SqlUpdate(GroupBox2)
        If squery <> tQuery Then
            HasChange = True
        End If
        Return HasChange
    End Function

    Private Sub frmFundTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm

        fClear_Info()
        If IsNew = False Then
            fRefreshInfo()
        End If

    End Sub
    Private Sub fRefreshInfo()

        Try
            Dim sQuery As String = "select * from `fund_transfer` where ID ='" & ID & "' Limit 1"
            SqlExecutedUsingReading(Me, sQuery)
            SqlExecutedUsingReading(GroupBox2, sQuery)
            SqlExecutedUsingReading(GroupBox1, sQuery)
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

        tQuery = SqlUpdate(Me) & "," & SqlUpdate(GroupBox1) & "," & SqlUpdate(GroupBox2)

    End Sub
    Private Sub fRefreshComboBox()
        ComboBoxLoad(cmbTO_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '2','3','4','6','7','8','9')", "ID", "BANK")
        ComboBoxLoad(cmbFROM_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '2','3','4','6','7','8','9')", "ID", "BANK")

        ComboBoxLoad(cmbFROM_LOCATION_ID, "Select * from location", "ID", "NAME")


        ComboBoxLoad(cmbFROM_NAME_ID, "SELECT c.`ID`, CONCAT(c.`NAME`,' / ',ctm.`DESCRIPTION` ) AS `NAMES` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE c.`INACTIVE` ='0' ORDER BY c.`TYPE`", "ID", "NAMES")
        ComboBoxLoad(cmbTO_NAME_ID, "SELECT c.`ID`, CONCAT(c.`NAME`,' / ',ctm.`DESCRIPTION` ) AS `NAMES` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE c.`INACTIVE` ='0' ORDER BY c.`TYPE`", "ID", "NAMES")


        ComboBoxLoad(cmbCLASS_ID, "Select ID,NAME from CLASS", "ID", "NAME")
        fSetToLocation()
    End Sub
    Private Sub fSetToLocation()
        Try

            ComboBoxLoad(cmbTO_LOCATION_ID, "Select * from location where ID <> '" & cmbFROM_LOCATION_ID.SelectedValue & "' ", "ID", "NAME")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fClear_Info()
        fRefreshComboBox()
        ClearAndRefresh(Me)
        ClearAndRefresh(GroupBox1)
        ClearAndRefresh(GroupBox2)
        cmbFROM_LOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbFROM_LOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        ClosedForm(Me)
    End Sub

    Private Sub cmbFROM_LOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFROM_LOCATION_ID.SelectedIndexChanged
        fSetToLocation()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If fACCESS_NEW_EDIT(Me, IsNew) = False Then
            Exit Sub
        End If

        If Val(cmbTO_ACCOUNT_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Please select to account")
            Exit Sub
        End If
        If Val(cmbTO_LOCATION_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Please select to location")
            Exit Sub
        End If
        If Val(cmbTO_NAME_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Please select to name")
            Exit Sub
        End If
        If Val(numAMOUNT.Value) = 0 Then
            MessageBoxWarning("Please enter amount value")
            Exit Sub
        End If

        ' FROM
        If Val(cmbFROM_ACCOUNT_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Please select from account")
            Exit Sub
        End If
        If Val(cmbFROM_LOCATION_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Please select from location")
            Exit Sub
        End If
        If Val(cmbFROM_NAME_ID.SelectedValue) = 0 Then
            MessageBoxWarning("Please select from name")
            Exit Sub
        End If

        If cmbTO_LOCATION_ID.SelectedValue = cmbFROM_ACCOUNT_ID.SelectedValue Then
            MessageBoxWarning("You cannot transfer between the same location")
            Exit Sub
        End If
        If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
            Exit Sub
        End If


        If IsNew = True Then


            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = GetNextCode("FUND_TRANSFER", cmbFROM_LOCATION_ID.SelectedValue)
            End If

            lblINTER_LOCATION_ACCOUNT_ID.Text = gsINTER_LOCATION_ACCOUNT_ID
            dtpDATE.Checked = True
            ID = ObjectTypeMapId("FUND_TRANSFER")

            Dim SQL_Field0 As String = ""
            Dim SQL_Value0 As String = ""
            SqlCreate(Me, SQL_Field0, SQL_Value0)
            Dim SQL_Field1 As String = ""
            Dim SQL_Value1 As String = ""
            SqlCreate(GroupBox1, SQL_Field1, SQL_Value1)
            Dim SQL_Field2 As String = ""
            Dim SQL_Value2 As String = ""
            SqlCreate(GroupBox2, SQL_Field2, SQL_Value2)

            SqlExecuted($"INSERT INTO bill ({SQL_Field0},{SQL_Field1},{SQL_Field2},ID,RECORDED_ON) VALUES ({SQL_Value0},{SQL_Value1},{SQL_Value2},{ID},'{GetDateTimeNowSql()}') ")

            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "New", cmbFROM_NAME_ID.SelectedValue, cmbFROM_ACCOUNT_ID.SelectedValue, NumIsNull(numAMOUNT.Value), cmbFROM_LOCATION_ID.SelectedValue)
            PrompNotify(Me.Text, SaveMsg, True)

        Else
            tChangeAccept = True
            Dim squery As String = SqlUpdate(Me) & "," & SqlUpdate(GroupBox1) & "," & SqlUpdate(GroupBox2)
            SqlExecuted("UPDATE `fund_transfer` SET " & squery & " WHERE ID = '" & ID & "'")
            PrompNotify(Me.Text, UpdateMsg, True)
            fTransaction_Log(ID, txtCODE.Text, Me.AccessibleName, "Edit", cmbFROM_NAME_ID.SelectedValue, cmbFROM_ACCOUNT_ID.SelectedValue, NumIsNull(numAMOUNT.Value), cmbFROM_LOCATION_ID.SelectedValue)
        End If

        If IsTransactionSuccess(ID, "FUND_TRANSFER") = False Then
            MessageBoxWarning("Please try again")
            Exit Sub
        End If

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(cmbTO_ACCOUNT_ID.SelectedValue, cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue, 93, ID, dtpDATE.Value, 0, numAMOUNT.Value, gsJOURNAL_NO_FORM)
            fAccount_Journal_SQL(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue, 93, ID, dtpDATE.Value, 1, numAMOUNT.Value, gsJOURNAL_NO_FORM)

            fAccount_Journal_SQL(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue, 93, ID, dtpDATE.Value, 0, numAMOUNT.Value, gsJOURNAL_NO_FORM)
            fAccount_Journal_SQL(cmbFROM_ACCOUNT_ID.SelectedValue, cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue, 93, ID, dtpDATE.Value, 1, numAMOUNT.Value, gsJOURNAL_NO_FORM)

        End If
        '================================

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            End If
        Catch ex As Exception

        Finally
            If ID <> 0 Then
                IsNew = False
                fRefreshInfo()
            End If

        End Try


    End Sub
    Private Sub fSetNew()

        fClear_Info()
        ID = 0
        IsNew = True

    End Sub
    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub
        Else
            If IsNew = False And ID <> 0 Then
                If fCheckHasChange() = True Then
                    If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        tsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            MessageBoxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If
        End If

        Frm.AccessibleName = "fund_transfer"
        Frm.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        Frm.ShowDialog()
        If Frm.AccessibleDescription <> "" Then
            If Frm.AccessibleDescription <> "cancel" Then
                fClear_Info()
                ID = Frm.AccessibleDescription
                IsNew = False



                fClear_Info()


                fRefreshInfo()

            End If


        End If


    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If IsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value, IsNew) = False Then
                Exit Sub
            End If

            If MessageBoxQuestion(gsMessageQuestion) = True Then
                CursorLoadingOn(True)
                If gsSkipJournalEntry = False Then
                    fJournalAccountRemoveFixed_Account_ID(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), 93, ID, dtpDATE.Value, cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue)
                    fJournalAccountRemoveFixed_Account_ID(cmbFROM_ACCOUNT_ID.SelectedValue, 93, ID, dtpDATE.Value, cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue)

                    fJournalAccountRemoveFixed_Account_ID(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), 93, ID, dtpDATE.Value, cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue)
                    fJournalAccountRemoveFixed_Account_ID(cmbTO_ACCOUNT_ID.SelectedValue, 93, ID, dtpDATE.Value, cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue)
                End If
                SqlExecuted("DELETE FROM `fund_transfer` WHERE ID ='" & ID & "'")
                PrompNotify(Me.Text, DeleteMsg, True)
                fClear_Info()
                ID = 0
                IsNew = True
                CursorLoadingOn(False)
            End If
        End If
    End Sub

    Private Sub frmFundTransfer_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

        If Me.Text = Me.Name Then Exit Sub
        ID = gsDocument_Finder_ID
        IsNew = IIf(ID = 0, True, False)
        If IsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If IsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If MessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        MessageBoxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If IsNew = False Then
            fTransactionJournal(ID, dtpDATE.Value, cmbTO_LOCATION_ID.SelectedValue, 93, cmbTO_ACCOUNT_ID.SelectedValue, cmbTO_NAME_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If IsNew = True Then
            fSetNew()
        Else
            Dim R As Integer = fRefreshMessage()
            If R = 1 Then
                fSetNew()
            ElseIf R = 2 Then
                fClear_Info()
                fRefreshInfo()
            End If

        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        fTransactionLog(Me, ID)
    End Sub
End Class