﻿Imports System.Data.Odbc
Module modJournalAccount


    Dim sID As String




    Private Sub FGET_PREVIOUS_ACCOUNT(prAccount_ID As String, prLocation_ID As String, ByRef prSEQUENCE_No As Integer, ByRef prID As Double, ByRef prENDING_BALANCE As Double, ByVal ThisID As Integer)

        Try

            Dim sQuery As String = ""
            If ThisID <> 0 Then
                sQuery = "Select ID,SEQUENCE_NO,ENDING_BALANCE from ACCOUNT_JOURNAL WHERE ACCOUNT_ID = '" & prAccount_ID & "' AND location_id = '" & prLocation_ID & "' and  ID < '" & ThisID & "'  order by OBJECT_DATE DESC,ID DESC limit 1 "
            ElseIf prID = 0 Then
                sQuery = "Select ID,SEQUENCE_NO,ENDING_BALANCE from ACCOUNT_JOURNAL WHERE ACCOUNT_ID = '" & prAccount_ID & "' AND location_id = '" & prLocation_ID & "'  order by OBJECT_DATE DESC,ID DESC limit 1 "
            Else
                sQuery = "Select ID,SEQUENCE_NO,ENDING_BALANCE from ACCOUNT_JOURNAL WHERE ID = '" & prID & "' limit 1 "
            End If

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                prID = GF_NumIsNull(rd("ID"))
                prSEQUENCE_No = GF_NumIsNull(rd("SEQUENCE_NO"))
                prENDING_BALANCE = GF_NumIsNull(rd("ENDING_BALANCE"))
            Else
                prID = 0
                prSEQUENCE_No = 0
                prENDING_BALANCE = 0
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub

    Public Sub GS_POS_Starting_Cash_Delete(ByVal prSTART_ID As String, ByVal prDATE As Date, ByVal prLOCATION_ID As Integer)
        Dim prOBJECT_TYPE_ITEM_ID As String = GetObjectTypeMapID("POS_STARTING_CASH")
        Dim SQL As String = $"SELECT sc.`ID`,sc.`POS_MACHINE_ID`,sc.`CASHIER_ID`,sc.`AMOUNT`,sc.`DRAWER_ACCOUNT_ID`,sc.`PETTY_CASH_ACCOUNT_ID` FROM pos_starting_cash AS sc WHERE sc.ID ='{prSTART_ID}'  limit 1"
        Dim rd As OdbcDataReader = SqlReader(SQL)

        If rd.Read Then
            sID = GF_NumIsNull(prSTART_ID) 'POS STARTING CASH

            Dim sACCOUNT_DRAWER_ID As Integer = Val(rd("DRAWER_ACCOUNT_ID"))
            Dim sACCOUNT_PETTY_CASH_ID As Integer = Val(rd("PETTY_CASH_ACCOUNT_ID"))
            Dim SUBSIDAIRY_ID As Integer = GF_NumIsNull(rd("POS_MACHINE_ID"))

            GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_DRAWER_ID, prOBJECT_TYPE_ITEM_ID, sID, prDATE, prLOCATION_ID, SUBSIDAIRY_ID)
            GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_PETTY_CASH_ID, prOBJECT_TYPE_ITEM_ID, sID, prDATE, prLOCATION_ID, SUBSIDAIRY_ID)

        End If
    End Sub
    Public Sub GS_PosStartingCashJournal(ByVal prSTART_ID As String, ByVal prDATE As Date, ByVal prLOCATION_ID As Integer)
        Dim prOBJECT_TYPE_ITEM_ID As String = GetObjectTypeMapID("POS_STARTING_CASH")
        Dim dJOURNAL_NO As Integer = 0
        Dim primary_journal_no As Integer = 0

        Dim SQL As String = $"SELECT sc.`ID`,sc.`POS_MACHINE_ID`,sc.`CASHIER_ID`,sc.`AMOUNT`,sc.`DRAWER_ACCOUNT_ID`,sc.`PETTY_CASH_ACCOUNT_ID` FROM pos_starting_cash AS sc WHERE sc.pos_machine_id ='{gsPOS_MACHINE_ID}' and sc.ID ='{prSTART_ID}'  limit 1"
        Dim rd As OdbcDataReader = SqlReader(SQL)
        Dim xPREV_ID As Double = 0
        Dim iSEQUENCE_NO As Integer = 0

        If rd.Read Then

            Dim sAMOUNT As Double = GF_NumIsNull(rd("AMOUNT"))

            sID = GF_NumIsNull(prSTART_ID) 'STARTING CASH ID
            Dim sACCOUNT_DRAWER_ID As Integer = Val(rd("DRAWER_ACCOUNT_ID"))
            Dim sACCOUNT_PETTY_CASH_ID As Integer = Val(rd("PETTY_CASH_ACCOUNT_ID"))

            Dim Location_ID As String = prLOCATION_ID
            Dim sDATE As String = Format(prDATE, "yyyy-MM-dd")

            Dim dEnding_Balance As Double = 0
            Dim SUBSIDAIRY_ID As Integer = GF_NumIsNull(rd("POS_MACHINE_ID"))

            'UNDEPOSIT FUND / POS_CASH_COUNT '
            Dim xID As Double = fGET_TRANSACTION_JOURNAL(sACCOUNT_DRAWER_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 0, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
            If dJOURNAL_NO = 0 Then
                If primary_journal_no = 0 Then
                    primary_journal_no = GF_NumIsNull(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
                    dJOURNAL_NO = primary_journal_no
                Else
                    dJOURNAL_NO = primary_journal_no
                End If
            Else
                primary_journal_no = dJOURNAL_NO
            End If
            FGET_PREVIOUS_ACCOUNT(sACCOUNT_DRAWER_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
            fAccount_Journal(xID, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO, sACCOUNT_DRAWER_ID, Location_ID, SUBSIDAIRY_ID, 0, prOBJECT_TYPE_ITEM_ID, sID, sDATE, 0, sAMOUNT, dEnding_Balance, "CASHDRAWER")

            'CASH DRAWER / POS_LOG'
            xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_PETTY_CASH_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 1, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
            If dJOURNAL_NO = 0 Then
                If primary_journal_no = 0 Then
                    primary_journal_no = GF_NumIsNull(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
                    dJOURNAL_NO = primary_journal_no
                Else
                    dJOURNAL_NO = primary_journal_no
                End If

            End If

            FGET_PREVIOUS_ACCOUNT(sACCOUNT_PETTY_CASH_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
            fAccount_Journal(xID, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO, sACCOUNT_PETTY_CASH_ID, Location_ID, SUBSIDAIRY_ID, 0, prOBJECT_TYPE_ITEM_ID, sID, sDATE, 1, sAMOUNT, dEnding_Balance, "PETTYCASH")




        End If
    End Sub


    Public Sub GS_PosLogJournal(ByVal prPOS_ID As String, ByVal DS_ACCOUNT_ID As Integer, ByVal prDATE As Date)


        Dim prOBJECT_TYPE_ITEM_ID As String = GetObjectTypeMapID("POS_LOG")
        Dim dJOURNAL_NO As Integer = 0
        Dim primary_journal_no As Integer = 0

        Dim SQL As String = $"SELECT pl.`TOTAL` AS `LOG_TOTAL`,pc.`TOTAL` AS `COUNT_TOTAL`,(pl.`TOTAL` -  pc.`TOTAL`) AS `DS_TOTAL`,pl.`UNDEPOSITED_FUNDS_ACCOUNT_ID`,pl.`DRAWER_ACCOUNT_ID`,pl.`LOCATION_ID`,pl.`CASHIER_ID`,pl.`POS_MACHINE_ID` FROM POS_LOG AS pl INNER JOIN  POS_CASH_COUNT AS pc ON pl.`CASH_COUNT_ID` = pc.`ID`  WHERE pl.ID = '{prPOS_ID}' limit 1 "

        Dim rd As OdbcDataReader = SqlReader(SQL)
        Dim xPREV_ID As Double = 0
        Dim iSEQUENCE_NO As Integer = 0

        If rd.Read Then

            Dim LOG_TOTAL As Double = GF_NumIsNull(rd("LOG_TOTAL"))
            Dim COUNT_TOTAL As Double = GF_NumIsNull(rd("COUNT_TOTAL"))
            Dim DS_TOTAL As Double = GF_NumIsNull(rd("DS_TOTAL"))

            sID = GF_NumIsNull(prPOS_ID) 'POS LOG ID
            Dim sACCOUNT_DRAWER_ID As Integer = Val(rd("DRAWER_ACCOUNT_ID"))
            Dim sACCOUNT_UNDEPOSITED_ID As Integer = Val(rd("UNDEPOSITED_FUNDS_ACCOUNT_ID"))
            Dim sACCOUNT_DS_ID As Integer = DS_ACCOUNT_ID
            Dim Location_ID As String = Val(rd("LOCATION_ID"))
            Dim sDATE As String = Format(prDATE, "yyyy-MM-dd")

            Dim dEnding_Balance As Double = 0
            Dim SUBSIDAIRY_ID As Integer = GF_NumIsNull(rd("POS_MACHINE_ID"))

            'UNDEPOSIT FUND / POS_CASH_COUNT '
            Dim xID As Double = fGET_TRANSACTION_JOURNAL(sACCOUNT_UNDEPOSITED_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 0, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
            If dJOURNAL_NO = 0 Then
                If primary_journal_no = 0 Then
                    primary_journal_no = GF_NumIsNull(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
                    dJOURNAL_NO = primary_journal_no
                Else
                    dJOURNAL_NO = primary_journal_no
                End If
            Else
                primary_journal_no = dJOURNAL_NO
            End If
            FGET_PREVIOUS_ACCOUNT(sACCOUNT_UNDEPOSITED_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
            fAccount_Journal(xID, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO, sACCOUNT_UNDEPOSITED_ID, Location_ID, SUBSIDAIRY_ID, 0, prOBJECT_TYPE_ITEM_ID, sID, sDATE, 0, COUNT_TOTAL, dEnding_Balance, "UNDEPOSITED FUNDS")

            'CASH DRAWER / POS_LOG'
            xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_DRAWER_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 1, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)

            If dJOURNAL_NO = 0 Then
                If primary_journal_no = 0 Then
                    primary_journal_no = GF_NumIsNull(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
                    dJOURNAL_NO = primary_journal_no
                Else
                    dJOURNAL_NO = primary_journal_no
                End If
            Else
                primary_journal_no = dJOURNAL_NO
            End If

            FGET_PREVIOUS_ACCOUNT(sACCOUNT_DRAWER_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
            fAccount_Journal(xID, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO, sACCOUNT_DRAWER_ID, Location_ID, SUBSIDAIRY_ID, 0, prOBJECT_TYPE_ITEM_ID, sID, sDATE, 1, LOG_TOTAL, dEnding_Balance, "CASHDRAWER")

            If DS_TOTAL <> 0 Then
                'CASH DISCREPANCY

                If DS_TOTAL > 0 Then   'Debit
                    xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 0, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
                    If dJOURNAL_NO = 0 Then
                        If primary_journal_no = 0 Then
                            primary_journal_no = GF_NumIsNull(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
                            dJOURNAL_NO = primary_journal_no
                        Else
                            dJOURNAL_NO = primary_journal_no
                        End If
                    Else
                    End If
                    FGET_PREVIOUS_ACCOUNT(sACCOUNT_DS_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
                    fAccount_Journal(xID, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO, sACCOUNT_DS_ID, Location_ID, SUBSIDAIRY_ID, Year(sDATE), prOBJECT_TYPE_ITEM_ID, sID, sDATE, 0, DS_TOTAL, dEnding_Balance, "CASHDISCREPANCY")


                Else  'Credit

                    xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 1, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
                    If dJOURNAL_NO = 0 Then
                        If primary_journal_no = 0 Then
                            primary_journal_no = GF_NumIsNull(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
                            dJOURNAL_NO = primary_journal_no
                        Else
                            dJOURNAL_NO = primary_journal_no
                        End If
                    Else
                    End If
                    FGET_PREVIOUS_ACCOUNT(sACCOUNT_DS_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
                    fAccount_Journal(xID, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO, sACCOUNT_DS_ID, Location_ID, SUBSIDAIRY_ID, Year(sDATE), prOBJECT_TYPE_ITEM_ID, sID, sDATE, 1, DS_TOTAL, dEnding_Balance, "CASHDISCREPANCY")
                End If

            Else
                'Remove
                GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, sDATE, Location_ID, SUBSIDAIRY_ID)
            End If


        End If

    End Sub
    Public Sub GS_POS_LOG_JOURNAL_DELETE(ByVal prPOS_ID As String, ByVal DS_ACCOUNT_ID As Integer, ByVal prDATE As Date)


        Dim prOBJECT_TYPE_ITEM_ID As String = GetObjectTypeMapID("POS_LOG")
        Dim dJOURNAL_NO As Integer = 0

        Dim SQL As String = $"SELECT pl.`TOTAL` AS `LOG_TOTAL`,pc.`TOTAL` AS `COUNT_TOTAL`,(pl.`TOTAL` -  pc.`TOTAL`) AS `DS_TOTAL`,pl.`UNDEPOSITED_FUNDS_ACCOUNT_ID`,pl.`DRAWER_ACCOUNT_ID`,pl.`LOCATION_ID`,pl.`CASHIER_ID`,pl.`POS_MACHINE_ID` FROM POS_LOG AS pl INNER JOIN  POS_CASH_COUNT AS pc ON pl.`CASH_COUNT_ID` = pc.`ID`  WHERE pl.ID = '{prPOS_ID}' limit 1 "

        Dim rd As OdbcDataReader = SqlReader(SQL)
        Dim xPREV_ID As Double = 0
        Dim iSEQUENCE_NO As Integer = 0

        If rd.Read Then

            Dim LOG_TOTAL As Double = GF_NumIsNull(rd("LOG_TOTAL"))
            Dim COUNT_TOTAL As Double = GF_NumIsNull(rd("COUNT_TOTAL"))
            Dim DS_TOTAL As Double = GF_NumIsNull(rd("DS_TOTAL"))

            sID = GF_NumIsNull(prPOS_ID) 'POS LOG ID
            Dim sACCOUNT_DRAWER_ID As Integer = Val(rd("DRAWER_ACCOUNT_ID"))
            Dim sACCOUNT_UNDEPOSITED_ID As Integer = Val(rd("UNDEPOSITED_FUNDS_ACCOUNT_ID"))
            Dim sACCOUNT_DS_ID As Integer = DS_ACCOUNT_ID
            Dim Location_ID As String = Val(rd("LOCATION_ID"))
            Dim sDATE As String = Format(prDATE, "yyyy-MM-dd")

            Dim dEnding_Balance As Double = 0
            Dim SUBSIDAIRY_ID As Integer = GF_NumIsNull(rd("POS_MACHINE_ID"))

            'UNDEPOSIT FUND / POS_CASH_COUNT '
            Dim xID As Double = fGET_TRANSACTION_JOURNAL(sACCOUNT_UNDEPOSITED_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 0, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)

            FGET_PREVIOUS_ACCOUNT(sACCOUNT_UNDEPOSITED_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)

            GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_UNDEPOSITED_ID, prOBJECT_TYPE_ITEM_ID, sID, sDATE, Location_ID, SUBSIDAIRY_ID)


            'CASH DRAWER / POS_LOG'
            xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_DRAWER_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 1, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
            FGET_PREVIOUS_ACCOUNT(sACCOUNT_DRAWER_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
            GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_DRAWER_ID, prOBJECT_TYPE_ITEM_ID, sID, sDATE, Location_ID, SUBSIDAIRY_ID)

            If DS_TOTAL <> 0 Then
                'CASH DISCREPANCY

                If DS_TOTAL > 0 Then   'Debit
                    xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 0, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
                    FGET_PREVIOUS_ACCOUNT(sACCOUNT_DS_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
                    GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, sDATE, Location_ID, SUBSIDAIRY_ID)

                Else  'Credit

                    xID = fGET_TRANSACTION_JOURNAL(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, Location_ID, 1, sDATE, xPREV_ID, iSEQUENCE_NO, dJOURNAL_NO)
                    FGET_PREVIOUS_ACCOUNT(sACCOUNT_DS_ID, Location_ID, iSEQUENCE_NO, xPREV_ID, dEnding_Balance, xID)
                    GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, sDATE, Location_ID, SUBSIDAIRY_ID)

                End If

            Else
                'Remove

                GS_JournalAccountRemoveFixed_Account_ID(sACCOUNT_DS_ID, prOBJECT_TYPE_ITEM_ID, sID, sDATE, Location_ID, SUBSIDAIRY_ID)
            End If


        End If

    End Sub

    Private Sub fAccount_Journal(ByRef ID As Double, ByVal PREVIOUS_ID As Double, ByVal SEQUENCE_NO As Double,
                                ByVal JOURNAL_NO As Double, ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer,
                                ByVal SUBSIDIARY_ID As Integer, ByVal SEQUENCE_GROUP As Integer, ByVal OBJECT_TYPE As Integer,
                                ByVal OBJECT_ID As Integer, ByVal OBJECT_DATE As String, ByVal ENTRY_TYPE As Integer, ByVal AMOUNT As Double,
                                ByVal ENDING_BALANCE As Double, ByVal EXTENDED_OPTIONS As String)



        Dim SkipJournalEntry As Boolean = GetSystemSettingValueByText("SkipJournalEntry")

        If SkipJournalEntry = True Then
            Exit Sub
        End If

        If AMOUNT < 0 Then
            AMOUNT *= -1
        End If


        Dim dBALANCE As Double
        If ENTRY_TYPE = 0 Then
            dBALANCE = ENDING_BALANCE + AMOUNT
        Else
            dBALANCE = ENDING_BALANCE - AMOUNT
        End If

        If ID = 0 Then
            If Val(PREVIOUS_ID) = 0 Then
                SEQUENCE_NO = 0
            Else
                SEQUENCE_NO = Val(SEQUENCE_NO) + 1
            End If

            Dim xID As Double = ObjectTypeMapId("ACCOUNT_JOURNAL")

            SqlExecuted("INSERT INTO account_journal  SET ID = '" & xID & "', PREVIOUS_ID =" & GotNullNumber(PREVIOUS_ID) & ",SEQUENCE_NO = '" & SEQUENCE_NO & "',JOURNAL_NO = '" & JOURNAL_NO & "',
            ACCOUNT_ID = '" & ACCOUNT_ID & "',LOCATION_ID = '" & LOCATION_ID & "',SUBSIDIARY_ID='" & SUBSIDIARY_ID & "',
            SEQUENCE_GROUP = '" & SEQUENCE_GROUP & "',OBJECT_TYPE = '" & OBJECT_TYPE & "',OBJECT_ID = '" & OBJECT_ID & "',
            OBJECT_DATE = '" & OBJECT_DATE & "',ENTRY_TYPE = '" & ENTRY_TYPE & "',AMOUNT = '" & AMOUNT & "',ENDING_BALANCE ='" & dBALANCE & "',EXTENDED_OPTIONS = " & GF_GotNullText(EXTENDED_OPTIONS.Replace("INVENTORY", "")))

            fFixed_Ending_Balance(OBJECT_DATE, PREVIOUS_ID, ACCOUNT_ID, LOCATION_ID)

        Else
            ' When Amount is not Change the Update not procceed
            If GF_GetNumberFieldValueByTwoCondition("ACCOUNT_JOURNAL", "ID", ID, "ACCOUNT_ID", ACCOUNT_ID, "Amount") <> AMOUNT Then

                SqlExecuted("UPDATE account_journal  SET PREVIOUS_ID =" & GotNullNumber(PREVIOUS_ID) & ",SEQUENCE_NO = '" & SEQUENCE_NO & "',JOURNAL_NO = '" & JOURNAL_NO & "',
                ACCOUNT_ID = '" & ACCOUNT_ID & "',LOCATION_ID = '" & LOCATION_ID & "',SUBSIDIARY_ID='" & SUBSIDIARY_ID & "',
                SEQUENCE_GROUP = '" & SEQUENCE_GROUP & "',OBJECT_TYPE = '" & OBJECT_TYPE & "',OBJECT_ID = '" & OBJECT_ID & "',
                OBJECT_DATE = '" & OBJECT_DATE & "',ENTRY_TYPE = '" & ENTRY_TYPE & "',AMOUNT = '" & AMOUNT & "',ENDING_BALANCE ='" & dBALANCE & "',EXTENDED_OPTIONS = " & GF_GotNullText(EXTENDED_OPTIONS.Replace("INVENTORY", "")) & " WHERE ID = '" & ID & "' limit 1")
                'AUTO COMPUTED ENDING BALANCE
                ReConfigAccountJournalENDING_BALANCE(ACCOUNT_ID, LOCATION_ID, SUBSIDIARY_ID, SEQUENCE_NO, SEQUENCE_GROUP)

            End If

            ' TRT FIND IF GOT DUPLICATION
            Dim rdc As OdbcDataReader = SqlReader("SELECT * FROM account_journal AS j WHERE j.JOURNAL_NO <> '" & JOURNAL_NO & "'  AND j.`OBJECT_TYPE` = '" & OBJECT_TYPE & "' AND j.`OBJECT_ID` ='" & OBJECT_ID & "' AND j.`ENTRY_TYPE` = '" & ENTRY_TYPE & "' AND j.`OBJECT_DATE` = '" & OBJECT_DATE & "' AND account_ID ='" & ACCOUNT_ID & "' AND J.LOCATION_ID = '" & LOCATION_ID & "' Limit 1")
            If rdc.Read Then
                If MessageBoxWarningYesNo($"Duplicate Journal No. {GF_TextIsNull(rdc("JOURNAL_NO"))} found do you want to continue?") = True Then
                    'Doing to remove the duplicate
                    GS_JournalAccountRemoveFixed_Account_ID_SP(GF_NumIsNull(rdc("ACCOUNT_ID")), GF_NumIsNull(rdc("OBJECT_TYPE")), GF_NumIsNull(rdc("OBJECT_ID")), rdc("OBJECT_DATE"), LOCATION_ID, GF_NumIsNull(rdc("SUBSIDIARY_ID")), rdc("ID"))
                End If
            End If


        End If

    End Sub
    Private Sub fFixed_Ending_Balance(ByVal OBJECT_DATE As Date, ByVal PREVIOUS_ID As Integer, ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer)
        'Fixed
        'Previous ID
        'Ending Balance

        If OBJECT_DATE < DateTime.Now.Date Then
            'Ending Balance Fix
            Dim T_PREVIOUS_ID As Integer = 0
            Dim T_ENDING_BALANCE As Double = 0
            Dim sql_Fix As String = $"SELECT ID,PREVIOUS_ID,ENTRY_TYPE,AMOUNT,ENDING_BALANCE FROM ACCOUNT_JOURNAL WHERE ACCOUNT_ID ='{ACCOUNT_ID}' and ID >='{PREVIOUS_ID}' and LOCATION_ID ='{LOCATION_ID}' order by OBJECT_DATE DESC,ID DESC "

            Dim rd As OdbcDataReader = SqlReader(sql_Fix)

            While rd.Read
                If PREVIOUS_ID <> GF_NumIsNull(rd("ID")) Then

                    If GF_NumIsNull(rd("ENTRY_TYPE")) = 0 Then
                        T_ENDING_BALANCE += GF_NumIsNull(rd("AMOUNT"))
                    Else
                        T_ENDING_BALANCE -= GF_NumIsNull(rd("AMOUNT"))
                    End If

                    SqlExecuted($"UPDATE account_journal SET  PREVIOUS_ID ={GotNullNumber(T_PREVIOUS_ID)},ENDING_BALANCE = '{T_ENDING_BALANCE}' WHERE ID ='{rd("ID")}' and ACCOUNT_ID ='{ACCOUNT_ID}' and LOCATION_ID='{LOCATION_ID}'  limit 1;")
                    T_PREVIOUS_ID = rd("ID")
                Else
                    T_ENDING_BALANCE = GF_NumIsNull(rd("ENDING_BALANCE"))
                    T_PREVIOUS_ID = rd("ID")
                End If


            End While

        End If
    End Sub

    Public Sub fGET_PREVIOUS_INVENTORY_ITEM(ByVal prITEM_ID As Integer, ByVal prLocation_ID As Integer, ByRef prSEQUENCE_No As Integer, ByRef prID As Double, ByRef prENDING_QTY As Double, ByRef prENDING_UNIT_COST As Double, ByRef prENDING_COST As Double, ByVal prDATE As Date, ByVal ThisID As Integer)
        Try

            Dim sQuery As String = ""
            If ThisID <> 0 Then
                sQuery = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST,SOURCE_REF_DATE from ITEM_INVENTORY WHERE ITEM_ID = '" & prITEM_ID & "' AND location_id = '" & prLocation_ID & "' and ID < '" & ThisID & "' order by SOURCE_REF_DATE DESC,SEQUENCE_No DESC limit 1 "
            ElseIf prID = 0 Then
                sQuery = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST,SOURCE_REF_DATE from ITEM_INVENTORY WHERE ITEM_ID = '" & prITEM_ID & "' AND location_id = '" & prLocation_ID & "'  order by SOURCE_REF_DATE DESC,SEQUENCE_No DESC limit 1 "
            Else
                sQuery = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST,SOURCE_REF_DATE from ITEM_INVENTORY WHERE ID = '" & prID & "' order by SOURCE_REF_DATE DESC,SEQUENCE_No DESC limit 1 "
            End If

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                Dim dt As Date = rd("SOURCE_REF_DATE")
                prID = GF_NumIsNull(rd("ID"))

                If prSEQUENCE_No <> 0 Then
                    prSEQUENCE_No = prSEQUENCE_No
                Else

                    prSEQUENCE_No = GF_GetNumberFieldValueByTwoCondition("ITEM_INVENTORY", "ITEM_ID", prITEM_ID, "LOCATION_ID", prLocation_ID, "MAX(SEQUENCE_NO)")

                End If

                If prDATE >= dt Then
                    If prENDING_UNIT_COST = 0 Then
                        prENDING_UNIT_COST = GF_NumIsNull(rd("ENDING_UNIT_COST"))
                    Else
                        prENDING_UNIT_COST = prENDING_UNIT_COST
                    End If
                    prENDING_QTY = GF_NumIsNull(rd("ENDING_QUANTITY"))
                    prENDING_COST = GF_NumIsNull(rd("ENDING_COST"))
                End If
            Else
                prID = 0
                If prSEQUENCE_No <> 0 Then
                    prSEQUENCE_No = prSEQUENCE_No
                Else
                    prSEQUENCE_No = 0
                End If

                If prENDING_UNIT_COST = 0 Then
                    prENDING_UNIT_COST = 0
                Else
                    prENDING_UNIT_COST = prENDING_UNIT_COST
                End If

                prENDING_COST = 0

            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

    End Sub
    Private Function fGET_ITEM_INVENTORY(ByVal prITEM_ID As String, ByVal prSOURCE_REF_TYPE As Integer, ByVal prSOURCE_REF_ID As Double, ByVal prSOURCE_REF_DATE As String, ByVal prLocation_ID As Integer, ByRef prPREVIOUS_ID As Double, ByRef prSEQUENCE_NO As Double, ByRef prENDING_UNIT_COST As Double) As Double
        Dim prID As Double = 0

        Try

            Dim rd As OdbcDataReader = SqlReader("select ID,PREVIOUS_ID,SEQUENCE_NO,ENDING_UNIT_COST from ITEM_INVENTORY where ITEM_ID = '" & prITEM_ID & "' and SOURCE_REF_TYPE = '" & prSOURCE_REF_TYPE & "' and SOURCE_REF_ID = '" & prSOURCE_REF_ID & "' and SOURCE_REF_DATE = '" & prSOURCE_REF_DATE & "' and Location_ID = '" & prLocation_ID & "' order by SOURCE_REF_DATE DESC,SEQUENCE_No DESC limit 1")
            If rd.Read Then
                prID = GF_NumIsNull(rd("ID"))
                prPREVIOUS_ID = GF_NumIsNull(rd("PREVIOUS_ID"))
                prSEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO"))
                prENDING_UNIT_COST = GF_NumIsNull(rd("ENDING_UNIT_COST"))
            Else
                prENDING_UNIT_COST = 0
                prPREVIOUS_ID = 0
                prSEQUENCE_NO = 0
                prID = 0
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return prID
    End Function

    Private Function fGET_TRANSACTION_JOURNAL(ByVal prACCOUNT_ID As String, ByVal prOBJECT_TYPE As String, ByVal prOBJECT_ID As String, ByVal prLocation_ID As String, ByVal prENTRY_TYPE As Integer, ByVal prDATE As String, ByRef prPREVIOUS_ID As Double, ByRef prSEQUENCE_NO As Integer, ByRef prJOURNAL_NO As Double) As Double
        Dim prID As Double = 0

        Try

            Dim sQL As String = ""
            If prJOURNAL_NO = 0 Then
                sQL = "select ID,PREVIOUS_ID,SEQUENCE_NO,JOURNAL_NO from account_journal where ACCOUNT_ID = '" & prACCOUNT_ID & "' and OBJECT_TYPE = '" & prOBJECT_TYPE & "' and OBJECT_ID = '" & prOBJECT_ID & "' and OBJECT_DATE = '" & prDATE & "' and Location_ID = '" & prLocation_ID & "' and ENTRY_TYPE = '" & prENTRY_TYPE & "' limit 1"
            Else
                sQL = "select ID,PREVIOUS_ID,SEQUENCE_NO,JOURNAL_NO from account_journal where ACCOUNT_ID = '" & prACCOUNT_ID & "' and OBJECT_TYPE = '" & prOBJECT_TYPE & "' and OBJECT_ID = '" & prOBJECT_ID & "' and OBJECT_DATE = '" & prDATE & "' and Location_ID = '" & prLocation_ID & "' and ENTRY_TYPE = '" & prENTRY_TYPE & "' and JOURNAL_NO = '" & prJOURNAL_NO & "' limit 1"
            End If
            Dim rd As OdbcDataReader = SqlReader(sQL)
            If rd.Read Then
                prID = GF_NumIsNull(rd("ID"))
                prPREVIOUS_ID = GF_NumIsNull(rd("PREVIOUS_ID"))
                prSEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO"))
                prJOURNAL_NO = GF_NumIsNull(rd("JOURNAL_NO"))
            Else
                prPREVIOUS_ID = 0
                prSEQUENCE_NO = 0
                prJOURNAL_NO = 0
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        Return prID
    End Function



    Private Sub ReConfigAccountJournalENDING_BALANCE(ByVal prACCOUNT_ID As Integer, ByVal prLocation_ID As Integer, ByVal prSUBSIDIARY_ID As Double, ByVal prSEQUENCE_NO As Double, ByVal prSEQUENCE_GROUP As Double)

        Dim dEnding_Balance As Double = 0
        Dim sQuery As String = ""
        Dim bFirst As Boolean = False
        Try

            Dim sql_select As String = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO,ENTRY_TYPE,AMOUNT,ENDING_BALANCE from ACCOUNT_JOURNAL where  SEQUENCE_NO >= '" & prSEQUENCE_NO & "' and SUBSIDIARY_ID ='" & prSUBSIDIARY_ID & "' and ACCOUNT_ID = '" & prACCOUNT_ID & "' and Location_ID = '" & prLocation_ID & "' and SEQUENCE_GROUP = '" & prSEQUENCE_GROUP & "'  Order by SEQUENCE_NO,PREVIOUS_ID "

            Dim rd As OdbcDataReader = SqlReader(sql_select)
            While rd.Read
                If bFirst = False Then
                    dEnding_Balance = GF_NumIsNull(rd("ENDING_BALANCE"))
                Else
                    Dim dAmount As Double
                    If GF_NumIsNull(rd("ENTRY_TYPE")) = 0 Then
                        dAmount = GF_NumIsNull(rd("AMOUNT"))
                        dEnding_Balance += dAmount
                    Else
                        dAmount = GF_NumIsNull(rd("AMOUNT"))
                        dEnding_Balance -= dAmount
                    End If
                    sQuery &= fAccount_Journal_Collect_SQL(rd("ID"), GF_NumIsNull(rd("PREVIOUS_ID")), prACCOUNT_ID, GF_NumIsNull(rd("SEQUENCE_NO")), prSEQUENCE_GROUP, prSUBSIDIARY_ID, prLocation_ID, dEnding_Balance)
                End If
                bFirst = True


            End While
            rd.Close()
            If sQuery <> "" Then
                SqlExecuted(sQuery)
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        Finally

        End Try
    End Sub
    Private Function fAccount_Journal_Collect_SQL(ByVal prID As Double, ByVal prPREV_ID As Double, ByVal prACCOUNT_ID As Integer, ByVal prSEQUENCE_NO As Double, ByVal prSEQUENCE_GROUP As Integer, ByVal prSUBSIDIARY_ID As Double, ByVal prLOCATION_ID As Integer, ByVal prENDING_BALANCE As Double) As String
        Return "UPDATE account_journal SET ENDING_BALANCE = '" & prENDING_BALANCE & "' WHERE ID='" & prID & "' and PREVIOUS_ID='" & prPREV_ID & "' and ACCOUNT_ID ='" & prACCOUNT_ID & "' and SEQUENCE_NO='" & prSEQUENCE_NO & "' and SEQUENCE_GROUP = '" & prSEQUENCE_GROUP & "' and Location_ID = '" & prLOCATION_ID & "' and SUBSIDIARY_ID='" & prSUBSIDIARY_ID & "';"
    End Function



    Public Sub fItemInventoryRemoveFixedByType(ByVal prSOURCE_TYPE As Integer, ByVal prSOURCE_ID As Double, ByVal prSOURCE_DATE As Date, ByVal prItem_ID As Double, ByVal prLocation_ID As Integer)
        Dim prSEQUENCE_NO As Integer
        Dim bOpen As Boolean = False
        Dim sItem_Inventory As String = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO FROM ITEM_INVENTORY WHERE ITEM_ID='" & prItem_ID & "' and SOURCE_REF_TYPE= '" & prSOURCE_TYPE & "' and SOURCE_REF_ID ='" & prSOURCE_ID & "' and SOURCE_REF_DATE = '" & Format(prSOURCE_DATE, "yyyy-MM-dd") & "' and Location_ID='" & prLocation_ID & "' Limit 1"
        Dim prID As Double = 0
        Dim prPrev_ID As Double = 0

        Try
            Dim rd As OdbcDataReader = SqlReader(sItem_Inventory)
            If rd.Read Then
                bOpen = True
                prID = GF_NumIsNull(rd("ID"))
                prPrev_ID = GF_NumIsNull(rd("PREVIOUS_ID"))
                prSEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO"))
            End If
            rd.Close()
            rd = Nothing
            If bOpen = True Then
                Dim sSelect_SQL As String = "SELECT ID,SEQUENCE_NO,ENDING_QUANTITY,QUANTITY,ENDING_UNIT_COST FROM ITEM_INVENTORY WHERE ITEM_ID='" & prItem_ID & "' and Location_ID='" & prLocation_ID & "' and  SEQUENCE_NO >='" & prSEQUENCE_NO & "' ORDER BY SEQUENCE_NO,ID"
                Dim sQuery As String = ""
                rd = SqlReader(sSelect_SQL)
                While rd.Read
                    Dim ENDING_QUANTITY As Double
                    If prSEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO")) And prID = GF_NumIsNull(rd("ID")) Then
                        ENDING_QUANTITY = GF_NumIsNull(rd("ENDING_QUANTITY"))
                        sQuery = "DELETE FROM item_inventory WHERE ID='" & prID & "' and ITEM_ID='" & prItem_ID & "' and LOCATION_ID='" & prLocation_ID & "';"
                    Else
                        ENDING_QUANTITY = GF_NumIsNull(rd("ENDING_QUANTITY")) + GF_NumIsNull(rd("QUANTITY"))
                        sQuery = "UPDATE item_inventory SET ENDING_COST='" & GF_NumIsNull(rd("ENDING_UNIT_COST")) * ENDING_QUANTITY & "',ENDING_QUANTITY='" & ENDING_QUANTITY & "',PREVIOUS_ID = " & GotNullNumber(prPrev_ID) & " WHERE ID = '" & rd("ID") & "' and ITEM_ID = '" & prItem_ID & "' and LOCATION_ID='" & prLocation_ID & "';" & sQuery
                        prPrev_ID = GF_NumIsNull(rd("ID"))
                    End If


                End While
                rd.Close()
                If sQuery <> "" Then
                    SqlExecuted(sQuery)
                End If
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Public Sub fJournalAccountRemoveFixed(ByVal prTable_Name As String, ByVal prOBJECT_ID As String, ByVal prOBJECT_DATE As Date, ByVal prLocation_ID As Integer, ByVal prSUBSIDIARY_ID As Integer)
        Dim iObj_Type As Integer = GF_GetStringFieldValue("object_type_map", "TABLE_NAME", prTable_Name, "ID")

        Try
            Dim rd As OdbcDataReader = SqlReader("select ID,SEQUENCE_NO,SUBSIDIARY_ID,ACCOUNT_ID,SEQUENCE_GROUP from account_journal where OBJECT_TYPE = '" & iObj_Type & "' and OBJECT_ID = '" & prOBJECT_ID & "' and OBJECT_DATE = '" & Format(prOBJECT_DATE, "yyyy-MM-dd") & "' and Location_ID = '" & prLocation_ID & "' and SUBSIDIARY_ID = '" & prSUBSIDIARY_ID & "'")
            While rd.Read
                Journal_Account_Execute(rd("SEQUENCE_NO"), rd("SUBSIDIARY_ID"), rd("ACCOUNT_ID"), prLocation_ID, rd("SEQUENCE_GROUP"), rd("ID"))
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Sub Journal_Account_Execute(ByVal prSEQUENCE_NO As Integer, ByVal prSUBSIDIARY_ID As Integer, ByVal prACCOUNT_ID As Integer, ByVal prLocation_ID As Integer, prSEQUENCE_GROUP As Integer, ByVal prID As Double)
        Dim dPrevious_ID As Double = 0

        Dim sql_select As String = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO,ENTRY_TYPE,AMOUNT,ENDING_BALANCE from ACCOUNT_JOURNAL where SEQUENCE_NO >= '" & prSEQUENCE_NO & "'  and ACCOUNT_ID = '" & prACCOUNT_ID & "' and Location_ID = '" & prLocation_ID & "'  Order by SEQUENCE_NO,ID "
        Dim sQuery As String = ""
        Dim ENDING_BALANCE As Double = 0

        Try

            Dim rd As OdbcDataReader = SqlReader(sql_select)
            While rd.Read

                Dim ENTRY_TYPE As Integer
                Dim AMOUNT As Double
                If prSEQUENCE_NO = rd("SEQUENCE_NO") And prID = GF_NumIsNull(rd("ID")) Then
                    ENTRY_TYPE = GF_NumIsNull(rd("ENTRY_TYPE"))
                    AMOUNT = GF_NumIsNull(rd("AMOUNT"))
                    If ENTRY_TYPE = 0 Then
                        ENDING_BALANCE = GF_NumIsNull(rd("ENDING_BALANCE")) - AMOUNT
                    Else
                        ENDING_BALANCE = GF_NumIsNull(rd("ENDING_BALANCE")) + AMOUNT
                    End If
                    dPrevious_ID = GF_NumIsNull(rd("PREVIOUS_ID"))
                    SqlExecuted($"UPDATE account_journal SET PREVIOUS_ID = NULL WHERE ID = '{prID}' limit 1;")
                    SqlExecuted($"UPDATE account_journal SET PREVIOUS_ID = {GotNullNumber(dPrevious_ID)} WHERE PREVIOUS_ID = '{prID}' limit 1;")
                    SqlExecuted($"DELETE FROM account_journal WHERE ID ='" & prID & "' and SEQUENCE_NO = '" & GF_NumIsNull(rd("SEQUENCE_NO")) & "' and SUBSIDIARY_ID ='" & prSUBSIDIARY_ID & "' and ACCOUNT_ID = '" & prACCOUNT_ID & "' and Location_ID = '" & prLocation_ID & "' and SEQUENCE_GROUP = '" & prSEQUENCE_GROUP & "' limit 1;")

                Else

                    If sQuery <> "" Then
                        ENTRY_TYPE = GF_NumIsNull(rd("ENTRY_TYPE"))
                        AMOUNT = GF_NumIsNull(rd("AMOUNT"))
                        If ENTRY_TYPE = 0 Then
                            ENDING_BALANCE += AMOUNT
                        Else
                            ENDING_BALANCE -= AMOUNT
                        End If
                        SqlExecuted("UPDATE account_journal SET ENDING_BALANCE='" & ENDING_BALANCE & "',PREVIOUS_ID =" & GotNullNumber(dPrevious_ID) & " WHERE ID ='" & rd("ID") & "' and SEQUENCE_NO = '" & GF_NumIsNull(rd("SEQUENCE_NO")) & "' and SUBSIDIARY_ID ='" & prSUBSIDIARY_ID & "' and ACCOUNT_ID = '" & prACCOUNT_ID & "' and Location_ID = '" & prLocation_ID & "' and SEQUENCE_GROUP = '" & prSEQUENCE_GROUP & "' limit 1;")
                        dPrevious_ID = GF_NumIsNull(rd("ID"))
                    End If
                End If
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub


    Public Sub GS_JournalAccountRemoveFixed_Account_ID_SP(ByVal prAccount_ID As Integer, ByVal iObj_Type As Integer, ByVal prOBJECT_ID As String, ByVal prOBJECT_DATE As Date, ByVal prLocation_ID As Integer, ByVal prSUBSIDIARY_ID As Integer, ByVal prID As Integer)
        Try

            Dim rd As OdbcDataReader = SqlReader("select ID,SEQUENCE_NO,SUBSIDIARY_ID,ACCOUNT_ID,SEQUENCE_GROUP from account_journal where  Account_ID ='" & prAccount_ID & "' and OBJECT_TYPE = '" & iObj_Type & "' and OBJECT_ID = '" & prOBJECT_ID & "' and OBJECT_DATE = '" & Format(prOBJECT_DATE, "yyyy-MM-dd") & "' and Location_ID = '" & prLocation_ID & "' and SUBSIDIARY_ID = '" & prSUBSIDIARY_ID & "' and ID = '" & prID & "' limit 1")
            If rd.Read Then
                Journal_Account_Execute(rd("SEQUENCE_NO"), rd("SUBSIDIARY_ID"), rd("ACCOUNT_ID"), prLocation_ID, rd("SEQUENCE_GROUP"), rd("ID"))
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub



    Public Sub GS_JournalAccountRemoveFixed_Account_ID(ByVal prAccount_ID As Integer, ByVal iObj_Type As Integer, ByVal prOBJECT_ID As String, ByVal prOBJECT_DATE As Date, ByVal prLocation_ID As Integer, ByVal prSUBSIDIARY_ID As Integer)
        If prAccount_ID = 0 Then
            Exit Sub
        End If
        Try
            Dim rd As OdbcDataReader = SqlReader("select ID,SEQUENCE_NO,SUBSIDIARY_ID,ACCOUNT_ID,SEQUENCE_GROUP from account_journal where  Account_ID ='" & prAccount_ID & "' and OBJECT_TYPE = '" & iObj_Type & "' and OBJECT_ID = '" & prOBJECT_ID & "' and OBJECT_DATE = '" & Format(prOBJECT_DATE, "yyyy-MM-dd") & "' and Location_ID = '" & prLocation_ID & "' and SUBSIDIARY_ID = '" & prSUBSIDIARY_ID & "' limit 1")
            If rd.Read Then
                Journal_Account_Execute(GF_NumIsNull(rd("SEQUENCE_NO")), GF_NumIsNull(rd("SUBSIDIARY_ID")), GF_NumIsNull(rd("ACCOUNT_ID")), prLocation_ID, rd("SEQUENCE_GROUP"), rd("ID"))
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

End Module