
Public Class frmFundTransfer
    Public gsID As String = gsDocument_Finder_ID
    Public gsNew As Boolean = IIf(gsID = "", True, False)
    Dim f As Form = New frmFindDocument

    Dim tQuery As String
    Dim tChangeAccept As Boolean = False
    Private Function fCheckHasChange() As Boolean
        Dim HasChange As Boolean = False
        Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2)
        If squery <> tQuery Then
            HasChange = True
        End If
        Return HasChange
    End Function

    Private Sub frmFundTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tsTITLE.Text = gsSubMenuForm
        fBackGroundImageStyle(Me)
        fClear_Info()
        If gsNew = False Then
            fRefreshInfo()
        End If

    End Sub
    Private Sub fRefreshInfo()

        Try
            Dim sQuery As String = "select * from `fund_transfer` where ID ='" & gsID & "' Limit 1"
            fExecutedUsingReading(Me, sQuery)
            fExecutedUsingReading(GroupBox2, sQuery)
            fExecutedUsingReading(GroupBox1, sQuery)
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try

        tQuery = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2)

    End Sub
    Private Sub fRefreshComboBox()
        fComboBox(cmbTO_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '2','3','4','6','7','8','9')", "ID", "BANK")
        fComboBox(cmbFROM_ACCOUNT_ID, "SELECT a.ID,CONCAT(a.`NAME`, ' / ', atm.`DESCRIPTION`) AS `BANK`  FROM account AS a INNER JOIN account_type_map AS atm ON atm.`ID` = a.`TYPE` WHERE a.`type` IN ('0', '2','3','4','6','7','8','9')", "ID", "BANK")

        fComboBox(cmbFROM_LOCATION_ID, "Select * from location", "ID", "NAME")


        fComboBox(cmbFROM_NAME_ID, "SELECT c.`ID`, CONCAT(c.`NAME`,' / ',ctm.`DESCRIPTION` ) AS `NAMES` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE c.`INACTIVE` ='0' ORDER BY c.`TYPE`", "ID", "NAMES")
        fComboBox(cmbTO_NAME_ID, "SELECT c.`ID`, CONCAT(c.`NAME`,' / ',ctm.`DESCRIPTION` ) AS `NAMES` FROM contact AS c INNER JOIN  contact_type_map AS ctm ON ctm.`ID` = c.`TYPE` WHERE c.`INACTIVE` ='0' ORDER BY c.`TYPE`", "ID", "NAMES")


        fComboBox(cmbCLASS_ID, "Select ID,NAME from CLASS", "ID", "NAME")
        fSetToLocation()
    End Sub
    Private Sub fSetToLocation()
        Try

            fComboBox(cmbTO_LOCATION_ID, "Select * from location where ID <> '" & cmbFROM_LOCATION_ID.SelectedValue & "' ", "ID", "NAME")

        Catch ex As Exception

        End Try
    End Sub
    Private Sub fClear_Info()
        fRefreshComboBox()
        fCLean_and_refresh(Me)
        fCLean_and_refresh(GroupBox1)
        fCLean_and_refresh(GroupBox2)
        cmbFROM_LOCATION_ID.SelectedValue = gsDefault_LOCATION_ID
        cmbFROM_LOCATION_ID.Enabled = fLockLocation()
        dtpDATE.Value = fTransactionDefaultDate()
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        fCloseForm(Me)
    End Sub

    Private Sub cmbFROM_LOCATION_ID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFROM_LOCATION_ID.SelectedIndexChanged
        fSetToLocation()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If fACCESS_NEW_EDIT(Me, gsNew) = False Then
            Exit Sub
        End If

        If Val(cmbTO_ACCOUNT_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select to account")
            Exit Sub
        End If
        If Val(cmbTO_LOCATION_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select to location")
            Exit Sub
        End If
        If Val(cmbTO_NAME_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select to name")
            Exit Sub
        End If
        If Val(numAMOUNT.Value) = 0 Then
            fMessageboxWarning("Please enter amount value")
            Exit Sub
        End If

        ' FROM
        If Val(cmbFROM_ACCOUNT_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select from account")
            Exit Sub
        End If
        If Val(cmbFROM_LOCATION_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select from location")
            Exit Sub
        End If
        If Val(cmbFROM_NAME_ID.SelectedValue) = 0 Then
            fMessageboxWarning("Please select from name")
            Exit Sub
        End If

        If cmbTO_LOCATION_ID.SelectedValue = cmbFROM_ACCOUNT_ID.SelectedValue Then
            fMessageboxWarning("You cannot transfer between the same location")
            Exit Sub
        End If
        If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
            Exit Sub
        End If


        If gsNew = True Then


            If Trim(txtCODE.Text) = "" Then
                txtCODE.Text = fNEXT_CODE("FUND_TRANSFER", cmbFROM_LOCATION_ID.SelectedValue)
            End If

            lblINTER_LOCATION_ACCOUNT_ID.Text = gsINTER_LOCATION_ACCOUNT_ID
            dtpDATE.Checked = True
            Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2)

            gsID = fObjectTypeMap_ID("FUND_TRANSFER")
            squery = squery & ",ID='" & gsID & "',RECORDED_ON ='" & Format(Date.Now, "yyyy-MM-dd hh:mm:ss") & "'"
            squery = fNullOTherField(squery, "`FUND_TRANSFER`")
            fExecutedOnly("INSERT INTO `fund_transfer` SET " & squery)
            fTransactionDateSelectUpdate(dtpDATE.Value)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "New", cmbFROM_NAME_ID.SelectedValue, cmbFROM_ACCOUNT_ID.SelectedValue, fNumisNULL(numAMOUNT.Value), cmbFROM_LOCATION_ID.SelectedValue)
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else



            tChangeAccept = True
            Dim squery As String = fFieldCollector(Me) & "," & fFieldCollector(GroupBox1) & "," & fFieldCollector(GroupBox2)
            squery = squery & " WHERE ID = '" & gsID & "'"
            fExecutedOnly("UPDATE `fund_transfer` SET " & squery)
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
            fTransaction_Log(gsID, txtCODE.Text, Me.AccessibleName, "Edit", cmbFROM_NAME_ID.SelectedValue, cmbFROM_ACCOUNT_ID.SelectedValue, fNumisNULL(numAMOUNT.Value), cmbFROM_LOCATION_ID.SelectedValue)
        End If

        If fTransactionCheck(gsID, "FUND_TRANSFER") = False Then
            fMessageboxWarning("Please try again")
            Exit Sub
        End If

        '===========================================
        If gsSkipJournalEntry = False Then
            gsJOURNAL_NO_FORM = 0
            fAccount_Journal_SQL(cmbTO_ACCOUNT_ID.SelectedValue, cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue, 93, gsID, dtpDATE.Value, 0, numAMOUNT.Value, gsJOURNAL_NO_FORM)
            fAccount_Journal_SQL(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue, 93, gsID, dtpDATE.Value, 1, numAMOUNT.Value, gsJOURNAL_NO_FORM)

            fAccount_Journal_SQL(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue, 93, gsID, dtpDATE.Value, 0, numAMOUNT.Value, gsJOURNAL_NO_FORM)
            fAccount_Journal_SQL(cmbFROM_ACCOUNT_ID.SelectedValue, cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue, 93, gsID, dtpDATE.Value, 1, numAMOUNT.Value, gsJOURNAL_NO_FORM)

        End If
        '================================


        '   fJournalTransaction_Fund_Transfer(gsID)

        Try
            Dim btn As ToolStripButton = DirectCast(sender, ToolStripButton)
            If btn.Name = "tsSaveNew" Then
                fSetNew()
            End If
        Catch ex As Exception

        Finally
            If gsID <> "" Then
                gsNew = False
                fRefreshInfo()
            End If

        End Try


    End Sub
    Private Sub fSetNew()

        fClear_Info()
        gsID = ""
        gsNew = True

    End Sub
    Private Sub tsFind_Click(sender As Object, e As EventArgs) Handles tsFind.Click
        If fACCESS_FIND(Me) = False Then
            Exit Sub
        Else
            If gsNew = False And gsID <> "" Then
                If fCheckHasChange() = True Then
                    If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                        tChangeAccept = False
                        tsSaveNew_Click(sender, e)
                        If tChangeAccept = False Then
                            fMessageboxInfo("Cancel")
                            Exit Sub
                        End If
                    Else

                    End If
                End If
            End If
        End If

        f.AccessibleName = "fund_transfer"
        f.Size = New Point(gsMainWith - 50, gsMainHeight - 50)
        f.ShowDialog()
        If f.AccessibleDescription <> "" Then
            If f.AccessibleDescription <> "cancel" Then
                fClear_Info()
                gsID = f.AccessibleDescription
                gsNew = False



                fClear_Info()


                fRefreshInfo()

            End If


        End If


    End Sub

    Private Sub tsDelete_Click(sender As Object, e As EventArgs) Handles tsDelete.Click
        If gsNew = False Then
            If fACCESS_DELETE(Me) = False Then
                Exit Sub
            End If

            If fIsClosingDate(dtpDATE.Value, gsNew) = False Then
                Exit Sub
            End If

            If fMessageBoxQuestion(gsMessageQuestion) = True Then
                fCursorLoadingOn(True)
                If gsSkipJournalEntry = False Then
                    fJournalAccountRemoveFixed_Account_ID(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), 93, gsID, dtpDATE.Value, cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue)
                    fJournalAccountRemoveFixed_Account_ID(cmbFROM_ACCOUNT_ID.SelectedValue, 93, gsID, dtpDATE.Value, cmbFROM_LOCATION_ID.SelectedValue, cmbFROM_NAME_ID.SelectedValue)

                    fJournalAccountRemoveFixed_Account_ID(Val(lblINTER_LOCATION_ACCOUNT_ID.Text), 93, gsID, dtpDATE.Value, cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue)
                    fJournalAccountRemoveFixed_Account_ID(cmbTO_ACCOUNT_ID.SelectedValue, 93, gsID, dtpDATE.Value, cmbTO_LOCATION_ID.SelectedValue, cmbTO_NAME_ID.SelectedValue)
                End If
                fExecutedOnly("DELETE FROM `fund_transfer` WHERE ID ='" & gsID & "' limit 1;")
                fPop_Up_Msg(Me.Text, gsDeleteStr, True)
                fClear_Info()
                gsID = ""
                gsNew = True
                fCursorLoadingOn(False)
            End If
        End If
    End Sub

    Private Sub frmFundTransfer_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged

        If Me.Text = Me.Name Then Exit Sub
        gsID = gsDocument_Finder_ID
        gsNew = IIf(gsID = "", True, False)
        If gsNew = False Then
            fRefreshInfo()
        End If
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        If gsNew = True Then
            tsSaveNew_Click(sender, e)
        Else
            If fCheckHasChange() = True Then
                If fMessageBoxQuestion(gsMessageCheckEdit) = True Then
                    tChangeAccept = False
                    tsSaveNew_Click(sender, e)
                    If tChangeAccept = False Then
                        fMessageboxInfo("Cancel")
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End If
        End If

        If gsNew = False Then
            fTransactionJournal(gsID, dtpDATE.Value, cmbTO_LOCATION_ID.SelectedValue, 93, cmbTO_ACCOUNT_ID.SelectedValue, cmbTO_NAME_ID.Text, txtCODE.Text, txtNOTES.Text)
        End If
    End Sub

    Private Sub ToolStripDropDownButton2_Click(sender As Object, e As EventArgs) Handles ToolStripDropDownButton2.Click

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs) Handles tsDiscard.Click
        If gsNew = True Then
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
        fTransactionLog(Me, gsID)
    End Sub
End Class