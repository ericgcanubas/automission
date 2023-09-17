Imports System.Data.Odbc
Module modAccountJournal
    Public Sub GS_InventoryJournalVendors(ByVal dgv As DataGridView, ByVal N As Integer, ByVal IsDeducted As Boolean, ByVal Obj_Type As Integer, ByVal Src_Type As Integer, ByVal LOCATION_ID As Integer, ByVal DT As Date, ByVal COST As Double)

        Dim dgvROW As DataGridViewRow = dgv.Rows(N)
        With dgvROW

            If .Cells("ITEM_TYPE").Value = 5 Or .Cells("ITEM_TYPE").Value = 6 Then

            Else
                If .Cells("CONTROL_STATUS").Value <> "D" Then
                    'INVENTORY ITEM
                    Dim LAST_ENDING_UNIT_COST_ As Double = GF_NumIsNull(.Cells("AMOUNT").Value) / GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value)


                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        'ITEM INVENTORY/ ASSEMBLY ONLY
                        Dim THIS_QTY As Double = GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) * GF_NumIsNull(.Cells("QTY").Value)
                        GS_Item_Inventory_SQL(.Cells("ITEM_ID").Value, LOCATION_ID, IIf(IsDeducted = True, THIS_QTY * -1, THIS_QTY), COST, Src_Type, GF_NumIsNull(.Cells("ID").Value), DT, GF_NumIsNull(.Cells("BATCH_ID").Value))
                    End If

                    If gsSkipJournalEntry = False Then
                        'INCOME_ACCOUNT_ID
                        Dim AMT As Double = 0
                        If GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                            AMT = GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                        Else
                            AMT = GF_NumIsNull(.Cells("AMOUNT").Value)
                        End If

                        Dim E As Integer = 0

                        If GF_NumIsNull(.Cells("AMOUNT").Value) <= 0 Then
                            E = IIf(IsDeducted = True, 0, 1)
                        Else
                            E = IIf(IsDeducted = True, 1, 0)
                        End If

                        GS_AccountJournalExecute(GF_NumIsNull(.Cells("ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT, E, AMT, gsJOURNAL_NO_FORM)

                        If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                            'ITEM INVENTORY/ ASSEMBLY
                            'COST ONLY
                        End If


                    End If
                Else
                    'DELETE

                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        GS_ItemInventoryRemove(Src_Type, GF_NumIsNull(.Cells("ID").Value), DT, GF_NumIsNull(.Cells("ITEM_ID").Value), LOCATION_ID)
                    End If

                    If gsSkipJournalEntry = False Then
                        GS_AccountJournalDelete(GF_NumIsNull(.Cells("ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT)
                    End If
                End If
            End If
        End With

    End Sub
    Public Sub GS_InventoryJournalProcess(ByVal dgv As DataGridView, ByVal N As Integer, ByVal IsDeducted As Boolean, ByVal Obj_Type As Integer, ByVal Src_Type As Integer, ByVal LOCATION_ID As Integer, ByVal DT As Date)
        Dim StrSQL As String = ""
        Dim dgvROW As DataGridViewRow = dgv.Rows(N)
        With dgvROW

            If .Cells("ITEM_TYPE").Value = 5 Or .Cells("ITEM_TYPE").Value = 6 Then

            Else

                If .Cells("CONTROL_STATUS").Value <> "D" Then
                    'INVENTORY ITEM
                    Dim LAST_ENDING_UNIT_COST As Double = 0
                    If .Cells("ITEM_TYPE").Value <= 1 Then
                        'ITEM INVENTORY/ ASSEMBLY ONLY
                        Dim THIS_QTY As Double = GF_NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) * GF_NumIsNull(.Cells("QTY").Value)
                        GS_Item_Inventory_SQL(.Cells("ITEM_ID").Value, LOCATION_ID, IIf(IsDeducted = True, THIS_QTY * -1, THIS_QTY), LAST_ENDING_UNIT_COST, Src_Type, GF_NumIsNull(.Cells("ID").Value), DT, GF_NumIsNull(.Cells("BATCH_ID").Value))
                    End If

                    If gsSkipJournalEntry = False Then
                        'INCOME_ACCOUNT_ID
                        Dim AMT As Double = 0
                        If GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                            AMT = GF_NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                        Else
                            AMT = GF_NumIsNull(.Cells("AMOUNT").Value)
                        End If

                        Dim E As Integer = 0

                        If GF_NumIsNull(.Cells("AMOUNT").Value) <= 0 Then
                            E = IIf(IsDeducted = True, 0, 1)
                        Else
                            E = IIf(IsDeducted = True, 1, 0)
                        End If

                        GS_AccountJournalExecute(GF_NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT, E, AMT, gsJOURNAL_NO_FORM)

                        If .Cells("ITEM_TYPE").Value <= 1 Then
                            'ITEM INVENTORY/ ASSEMBLY
                            'COST ONLY
                            Dim AMT_COST As Double = LAST_ENDING_UNIT_COST * GF_NumIsNull(.Cells("QTY").Value)

                            If dgv.Columns.Contains("ASSET_ACCOUNT_ID") = True Then
                                GS_AccountJournalExecute(GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT, IIf(IsDeducted = True, 1, 0), AMT_COST, gsJOURNAL_NO_FORM)

                            End If

                            If dgv.Columns.Contains("COGS_ACCOUNT_ID") = True Then

                                GS_AccountJournalExecute(GF_NumIsNull(.Cells("COGS_ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT, IIf(IsDeducted = True, 0, 1), AMT_COST, gsJOURNAL_NO_FORM)

                            End If

                        End If


                    End If

                Else
                    'DELETE
                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        GS_ItemInventoryRemove(Src_Type, GF_NumIsNull(.Cells("ID").Value), DT, GF_NumIsNull(.Cells("ITEM_ID").Value), LOCATION_ID)
                    End If

                    If gsSkipJournalEntry = False Then
                        GS_AccountJournalDelete(GF_NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT)

                        If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                            'ITEM INVENTORY/ ASSEMBLY

                            'COST ONLY
                            If dgv.Columns.Contains("ASSET_ACCOUNT_ID") = True Then
                                'ASSET_ACCOUNT_ID
                                GS_AccountJournalDelete(GF_NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT)
                            End If

                            If dgv.Columns.Contains("COGS_ACCOUNT_ID") = True Then
                                'COGS_ACCOUNT_ID
                                GS_AccountJournalDelete(GF_NumIsNull(.Cells("COGS_ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, GF_NumIsNull(.Cells("ID").Value), DT)
                            End If
                        End If
                    End If
                End If
            End If
        End With

    End Sub
    Public Sub GS_AccountJournalDelete(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal OBJECT_TYPE As Integer, ByVal OBJECT_ID As Integer, ByVal OBJECT_DATE As Date)

        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,JOURNAL_NO,PREVIOUS_ID,ENDING_BALANCE,ENTRY_TYPE,AMOUNT FROM account_journal WHERE `ACCOUNT_ID` = '{ACCOUNT_ID}' and `LOCATION_ID` = '{LOCATION_ID}' and `OBJECT_TYPE` = '{OBJECT_TYPE}' and `OBJECT_ID` = '{OBJECT_ID}' and OBJECT_DATE = '{DateFormatMySql(OBJECT_DATE)}' limit 1;")
        If rd.Read Then
            SqlExecuted($"DELETE FROM account_journal WHERE `ID`= '{GF_NumIsNull(rd("ID"))}' AND `ACCOUNT_ID` = '{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' and OBJECT_TYPE = '{OBJECT_TYPE}' and OBJECT_ID = '{OBJECT_ID}' and OBJECT_DATE = '{DateFormatMySql(OBJECT_DATE)}' limit 1;")
        End If
        rd.Close()

    End Sub
    Public Sub GS_ItemInventoryRemove(ByVal prSOURCE_TYPE As Integer, ByVal prSOURCE_ID As Double, ByVal prSOURCE_DATE As Date, ByVal prItem_ID As Double, ByVal prLocation_ID As Integer)


        Dim prSEQUENCE_NO As Integer
        Dim sItem_Inventory As String = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO FROM ITEM_INVENTORY WHERE ITEM_ID='" & prItem_ID & "' and SOURCE_REF_TYPE= '" & prSOURCE_TYPE & "' and SOURCE_REF_ID ='" & prSOURCE_ID & "' and SOURCE_REF_DATE = '" & DateFormatMySql(prSOURCE_DATE) & "' and Location_ID='" & prLocation_ID & "' Limit 1"
        Dim prID As Double = 0

        Try

            Dim rd As OdbcDataReader = SqlReader(sItem_Inventory)
            If rd.Read Then
                Dim bOpen As Boolean = True
                prID = GF_NumIsNull(rd("ID"))
                Dim prPrev_ID As Double = GF_NumIsNull(rd("PREVIOUS_ID"))
                prSEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO"))
            End If
            rd.Close()
            SqlExecuted("DELETE FROM item_inventory WHERE ID='" & prID & "' and ITEM_ID='" & prItem_ID & "' and LOCATION_ID='" & prLocation_ID & "';")

            'rd = Nothing
            'If bOpen = True Then
            '    Dim sSelect_SQL As String = "SELECT ID,SEQUENCE_NO,ENDING_QUANTITY,QUANTITY,ENDING_UNIT_COST FROM ITEM_INVENTORY WHERE ITEM_ID='" & prItem_ID & "' and Location_ID='" & prLocation_ID & "' and  SEQUENCE_NO >='" & prSEQUENCE_NO & "' ORDER BY SEQUENCE_NO,ID"

            '    rd = SqlReader(sSelect_SQL)
            '    While rd.Read
            '        If prSEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO")) And prID = GF_NumIsNull(rd("ID")) Then
            '            ENDING_QUANTITY = GF_NumIsNull(rd("ENDING_QUANTITY"))

            '        Else
            '            ENDING_QUANTITY = GF_NumIsNull(rd("ENDING_QUANTITY")) + GF_NumIsNull(rd("QUANTITY"))
            '            SqlExecuted("UPDATE item_inventory SET ENDING_COST='" & GF_NumIsNull(rd("ENDING_UNIT_COST")) * ENDING_QUANTITY & "',ENDING_QUANTITY='" & ENDING_QUANTITY & "',PREVIOUS_ID = " & GotNullNumber(prPrev_ID) & " WHERE ID = '" & rd("ID") & "' and ITEM_ID = '" & prItem_ID & "' and LOCATION_ID='" & prLocation_ID & "';")
            '            prPrev_ID = GF_NumIsNull(rd("ID"))
            '        End If
            '    End While
            '    rd.Close()
            'End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try


    End Sub
    Public Sub GS_AccountJournalExecute(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal SUBSIDIARY_ID As Integer, ByVal OBJECT_TYPE As Integer, ByVal OBJECT_ID As Integer, ByVal OBJECT_DATE As Date, ByVal ENTRY_TYPE As Integer, ByVal THIS_AMOUNT As Double, ByRef THIS_JOURNAL_NO As Integer)
        If ACCOUNT_ID = 0 Then
            Exit Sub
        End If

        Dim SQL As String = ""
        If ACCOUNT_ID <> 0 Then
            Dim AMOUNT As Double = IIf(THIS_AMOUNT >= 0, THIS_AMOUNT, THIS_AMOUNT * -1)
            Dim ENDING_BALANCE As Double

            Dim rd As OdbcDataReader = SqlReader($"SELECT ID,JOURNAL_NO,PREVIOUS_ID,ENDING_BALANCE,ENTRY_TYPE,AMOUNT from account_journal WHERE ACCOUNT_ID = '{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' and OBJECT_TYPE = '{OBJECT_TYPE}' and OBJECT_ID = '{OBJECT_ID}' and OBJECT_DATE = '{DateFormatMySql(OBJECT_DATE)}' limit 1;")
            Dim THIS_ID As Integer

            If rd.Read Then
                'update
                THIS_ID = GF_NumIsNull(rd("ID"))
                THIS_JOURNAL_NO = GF_NumIsNull(rd("JOURNAL_NO"))
                'Dim THIS_BAL As Double
                'Select Case rd("ENTRY_TYPE")
                '    Case 0
                '        THIS_BAL = GF_NumIsNull(rd("ENDING_BALANCE")) - GF_NumIsNull(rd("AMOUNT"))
                '        ENDING_BALANCE = THIS_BAL + AMOUNT
                '    Case 1
                '        THIS_BAL = GF_NumIsNull(rd("ENDING_BALANCE")) + GF_NumIsNull(rd("AMOUNT"))
                '        ENDING_BALANCE = THIS_BAL - AMOUNT
                'End Select

                ENDING_BALANCE = GF_NumIsNull(rd("ENDING_BALANCE"))
                SQL = $"UPDATE `account_journal`
SET 
  `ENTRY_TYPE` = '{ENTRY_TYPE}',
  `AMOUNT` = '{AMOUNT}',
  `SUBSIDIARY_ID` = '{SUBSIDIARY_ID}',
  `ENDING_BALANCE` = '{ENDING_BALANCE}',
  `EXTENDED_OPTIONS` = ''
WHERE `ID` = '{THIS_ID}' and
`ACCOUNT_ID` = '{ACCOUNT_ID}' and 
  `LOCATION_ID` = '{LOCATION_ID}' and
  `OBJECT_TYPE` = '{OBJECT_TYPE}' and
  `OBJECT_ID` = '{OBJECT_ID}' and
  `OBJECT_DATE` = '{DateFormatMySql(OBJECT_DATE)}' limit 1;"

            Else
                'insert
                If THIS_JOURNAL_NO = 0 Then
                    THIS_JOURNAL_NO = GF_GetNetJournalNumber()
                End If
                THIS_ID = ObjectTypeMapId("ACCOUNT_JOURNAL")

                SQL = $"INSERT INTO `account_journal`
   SET `ID` = '{THIS_ID}',
  `PREVIOUS_ID` = {GF_GetPreviousID(ACCOUNT_ID, LOCATION_ID)},
  `SEQUENCE_NO` = {GF_GetNewSequencesNo(ACCOUNT_ID, LOCATION_ID)},
  `JOURNAL_NO` = '{THIS_JOURNAL_NO}',
  `ACCOUNT_ID` = '{ACCOUNT_ID}',
  `LOCATION_ID` = '{LOCATION_ID}',
  `SUBSIDIARY_ID` = '{SUBSIDIARY_ID}',
  `SEQUENCE_GROUP` = {GF_GetNewSequenceGroup(ACCOUNT_ID, LOCATION_ID, ENTRY_TYPE, OBJECT_DATE)},
  `OBJECT_TYPE` = '{OBJECT_TYPE}',
  `OBJECT_ID` = '{OBJECT_ID}',
  `OBJECT_DATE` = '{DateFormatMySql(OBJECT_DATE)}',
  `ENTRY_TYPE` = '{ENTRY_TYPE}',
  `AMOUNT` = '{AMOUNT}',
  `ENDING_BALANCE` = ifnull( {GF_GetPreviousBalance(ACCOUNT_ID, LOCATION_ID, ENTRY_TYPE, AMOUNT)},0),
  `EXTENDED_OPTIONS` = '';"


            End If
            rd.Close()
        End If
        SqlExecuted(SQL)

    End Sub

    Public Function GF_GetNetJournalNumber() As Double
        Return Val(GF_GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
    End Function
    Public Function GF_GetNewSequencesNo(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer) As String
        Return $"(Select  (MAX(CAST(SEQUENCE_NO AS UNSIGNED)) +1 ) From `ACCOUNT_JOURNAL` as a where ACCOUNT_ID ='{ACCOUNT_ID}' and LOCATION_ID ='{LOCATION_ID}' limit 1)"
    End Function
    Public Function GF_GetNewSequenceGroup(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal ENTRY_TYPE As Integer, ByVal DT As Date) As String
        Return $"(SELECT  IF(IFNULL((SELECT id FROM `ACCOUNT_JOURNAL` as a WHERE SEQUENCE_GROUP = '{DT.Date.Year}' AND  ACCOUNT_ID = '{ACCOUNT_ID}' AND LOCATION_ID = '{LOCATION_ID}' AND ENTRY_TYPE = '{ENTRY_TYPE}' LIMIT 1),0)=0,YEAR(CURDATE()),0) )"
    End Function
    Private Function GF_GetPreviousID(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer) As String

        Return $"(Select a.ID from account_journal as a  where a.account_id = '{ACCOUNT_ID}' and a.LOCATION_ID = '{LOCATION_ID}' order by a.`ID` DESC  limit 1)"
    End Function
    Private Function GF_GetPreviousBalance(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal ENTRY As Integer, ByVal AMT As Double) As String
        Return $"(Select  (a.ENDING_BALANCE{IIf(ENTRY = 0, "+", "-")}{AMT}) from account_journal as a where a.account_id = '{ACCOUNT_ID}' and a.LOCATION_ID = '{LOCATION_ID}' order by a.`ID` DESC  limit 1)"
    End Function
End Module
