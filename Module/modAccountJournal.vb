Imports System.Data.Odbc
Module modAccountJournal
    Public Sub fINVENTORY_JOURNAL_VENDOR(ByVal dgv As DataGridView, ByVal N As Integer, ByVal IsDeducted As Boolean, ByVal Obj_Type As Integer, ByVal Src_Type As Integer, ByVal LOCATION_ID As Integer, ByVal DT As Date)

        Dim dgvROW As DataGridViewRow = dgv.Rows(N)
        With dgvROW

            If .Cells("ITEM_TYPE").Value = 5 Or .Cells("ITEM_TYPE").Value = 6 Then

            Else
                If .Cells("CONTROL_STATUS").Value <> "D" Then
                    'INVENTORY ITEM
                    Dim LAST_ENDING_UNIT_COST As Double = NumIsNull(.Cells("AMOUNT").Value) / NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value)


                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        'ITEM INVENTORY/ ASSEMBLY ONLY
                        Dim THIS_QTY As Double = NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) * NumIsNull(.Cells("QTY").Value)
                        fItem_Inventory_SQL(.Cells("ITEM_ID").Value, LOCATION_ID, IIf(IsDeducted = True, THIS_QTY * -1, THIS_QTY), LAST_ENDING_UNIT_COST, Src_Type, NumIsNull(.Cells("ID").Value), DT, NumIsNull(.Cells("BATCH_ID").Value))
                    End If

                    If gsSkipJournalEntry = False Then
                        'INCOME_ACCOUNT_ID
                        Dim AMT As Double = 0
                        If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                            AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                        Else
                            AMT = NumIsNull(.Cells("AMOUNT").Value)
                        End If

                        Dim E As Integer = 0

                        If NumIsNull(.Cells("AMOUNT").Value) <= 0 Then
                            E = IIf(IsDeducted = True, 0, 1)
                        Else
                            E = IIf(IsDeducted = True, 1, 0)
                        End If

                        fAccount_Journal_SQL(NumIsNull(.Cells("ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, NumIsNull(.Cells("ID").Value), DT, E, AMT, gsJOURNAL_NO_FORM)

                        If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                            'ITEM INVENTORY/ ASSEMBLY
                            'COST ONLY
                        End If


                    End If
                Else
                    'DELETE

                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        fItemInventoryRemove_SQL(Src_Type, NumIsNull(.Cells("ID").Value), DT, NumIsNull(.Cells("ITEM_ID").Value), LOCATION_ID)
                    End If

                    If gsSkipJournalEntry = False Then
                        fAccount_journal_Delete(NumIsNull(.Cells("ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, NumIsNull(.Cells("ID").Value), DT)
                    End If
                End If
            End If
        End With

    End Sub
    Public Sub fINVENTORY_JOURNAL_PROCESS(ByVal dgv As DataGridView, ByVal N As Integer, ByVal IsDeducted As Boolean, ByVal Obj_Type As Integer, ByVal Src_Type As Integer, ByVal LOCATION_ID As Integer, ByVal DT As Date)
        Dim StrSQL As String = ""
        Dim dgvROW As DataGridViewRow = dgv.Rows(N)
        With dgvROW

            If .Cells("ITEM_TYPE").Value = 5 Or .Cells("ITEM_TYPE").Value = 6 Then

            Else

                If .Cells("CONTROL_STATUS").Value <> "D" Then
                    'INVENTORY ITEM
                    Dim LAST_ENDING_UNIT_COST As Double = 0
                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                        'ITEM INVENTORY/ ASSEMBLY ONLY
                        Dim THIS_QTY As Double = NumIsNull(.Cells("UNIT_QUANTITY_BASE").Value) * NumIsNull(.Cells("QTY").Value)
                        fItem_Inventory_SQL(.Cells("ITEM_ID").Value, LOCATION_ID, IIf(IsDeducted = True, THIS_QTY * -1, THIS_QTY), LAST_ENDING_UNIT_COST, Src_Type, NumIsNull(.Cells("ID").Value), DT, NumIsNull(.Cells("BATCH_ID").Value))
                    End If

                    If gsSkipJournalEntry = False Then
                        'INCOME_ACCOUNT_ID
                        Dim AMT As Double = 0
                        If NumIsNull(.Cells("TAXABLE_AMOUNT").Value) <> 0 Then
                            AMT = NumIsNull(.Cells("TAXABLE_AMOUNT").Value)
                        Else
                            AMT = NumIsNull(.Cells("AMOUNT").Value)
                        End If

                        Dim E As Integer = 0

                        If NumIsNull(.Cells("AMOUNT").Value) <= 0 Then
                            E = IIf(IsDeducted = True, 0, 1)
                        Else
                            E = IIf(IsDeducted = True, 1, 0)
                        End If

                        fAccount_Journal_SQL(NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, NumIsNull(.Cells("ID").Value), DT, E, AMT, gsJOURNAL_NO_FORM)

                        If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                            'ITEM INVENTORY/ ASSEMBLY
                            'COST ONLY
                            Dim AMT_COST As Double = LAST_ENDING_UNIT_COST * NumIsNull(.Cells("QTY").Value)

                            If dgv.Columns.Contains("ASSET_ACCOUNT_ID") = True Then
                                fAccount_Journal_SQL(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, NumIsNull(.Cells("ID").Value), DT, IIf(IsDeducted = True, 1, 0), AMT_COST, gsJOURNAL_NO_FORM)

                            End If

                            If dgv.Columns.Contains("COGS_ACCOUNT_ID") = True Then

                                fAccount_Journal_SQL(NumIsNull(.Cells("COGS_ACCOUNT_ID").Value), LOCATION_ID, .Cells("ITEM_ID").Value, Obj_Type, NumIsNull(.Cells("ID").Value), DT, IIf(IsDeducted = True, 0, 1), AMT_COST, gsJOURNAL_NO_FORM)

                            End If

                        End If


                    End If

                Else
                    'DELETE
                    If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                     fItemInventoryRemove_SQL(Src_Type, NumIsNull(.Cells("ID").Value), DT, NumIsNull(.Cells("ITEM_ID").Value), LOCATION_ID)
                    End If

                    If gsSkipJournalEntry = False Then
                        fAccount_journal_Delete(NumIsNull(.Cells("INCOME_ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, NumIsNull(.Cells("ID").Value), DT)

                        If .Cells("ITEM_TYPE").Value = 0 Or .Cells("ITEM_TYPE").Value = 1 Then
                            'ITEM INVENTORY/ ASSEMBLY

                            'COST ONLY
                            If dgv.Columns.Contains("ASSET_ACCOUNT_ID") = True Then
                                'ASSET_ACCOUNT_ID
                                fAccount_journal_Delete(NumIsNull(.Cells("ASSET_ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, NumIsNull(.Cells("ID").Value), DT)
                            End If

                            If dgv.Columns.Contains("COGS_ACCOUNT_ID") = True Then
                                'COGS_ACCOUNT_ID
                                fAccount_journal_Delete(NumIsNull(.Cells("COGS_ACCOUNT_ID").Value), LOCATION_ID, Obj_Type, NumIsNull(.Cells("ID").Value), DT)
                            End If
                        End If
                    End If
                End If
            End If
        End With

    End Sub


    Public Sub fAccount_journal_Delete(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal OBJECT_TYPE As Integer, ByVal OBJECT_ID As Integer, ByVal OBJECT_DATE As Date)

        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,JOURNAL_NO,PREVIOUS_ID,ENDING_BALANCE,ENTRY_TYPE,AMOUNT FROM account_journal WHERE `ACCOUNT_ID` = '{ACCOUNT_ID}' and `LOCATION_ID` = '{LOCATION_ID}' and `OBJECT_TYPE` = '{OBJECT_TYPE}' and `OBJECT_ID` = '{OBJECT_ID}' and OBJECT_DATE = '{DateFormatMySql(OBJECT_DATE)}' limit 1;")
        If rd.Read Then
            SqlExecuted($"DELETE FROM account_journal WHERE `ID`= '{NumIsNull(rd("ID"))}' AND `ACCOUNT_ID` = '{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' and OBJECT_TYPE = '{OBJECT_TYPE}' and OBJECT_ID = '{OBJECT_ID}' and OBJECT_DATE = '{DateFormatMySql(OBJECT_DATE)}' limit 1;")
        End If
        rd.Close()

    End Sub
    Public Sub fItemInventoryRemove_SQL(ByVal prSOURCE_TYPE As Integer, ByVal prSOURCE_ID As Double, ByVal prSOURCE_DATE As Date, ByVal prItem_ID As Double, ByVal prLocation_ID As Integer)


        Dim prSEQUENCE_NO As Integer
        Dim bOpen As Boolean = False
        Dim sItem_Inventory As String = "SELECT ID,PREVIOUS_ID,SEQUENCE_NO FROM ITEM_INVENTORY WHERE ITEM_ID='" & prItem_ID & "' and SOURCE_REF_TYPE= '" & prSOURCE_TYPE & "' and SOURCE_REF_ID ='" & prSOURCE_ID & "' and SOURCE_REF_DATE = '" & DateFormatMySql(prSOURCE_DATE) & "' and Location_ID='" & prLocation_ID & "' Limit 1"
        Dim prID As Double = 0
        Dim prPrev_ID As Double = 0
        Dim ENDING_QUANTITY As Double = 0

        Try

            Dim rd As OdbcDataReader = SqlReader(sItem_Inventory)
            If rd.Read Then
                bOpen = True
                prID = NumIsNull(rd("ID"))
                prPrev_ID = NumIsNull(rd("PREVIOUS_ID"))
                prSEQUENCE_NO = NumIsNull(rd("SEQUENCE_NO"))
            End If
            rd.Close()

            rd = Nothing
            If bOpen = True Then
                Dim sSelect_SQL As String = "SELECT ID,SEQUENCE_NO,ENDING_QUANTITY,QUANTITY,ENDING_UNIT_COST FROM ITEM_INVENTORY WHERE ITEM_ID='" & prItem_ID & "' and Location_ID='" & prLocation_ID & "' and  SEQUENCE_NO >='" & prSEQUENCE_NO & "' ORDER BY SEQUENCE_NO,ID"

                rd = SqlReader(sSelect_SQL)
                While rd.Read
                    If prSEQUENCE_NO = NumIsNull(rd("SEQUENCE_NO")) And prID = NumIsNull(rd("ID")) Then
                        ENDING_QUANTITY = NumIsNull(rd("ENDING_QUANTITY"))
                        SqlExecuted("DELETE FROM item_inventory WHERE ID='" & prID & "' and ITEM_ID='" & prItem_ID & "' and LOCATION_ID='" & prLocation_ID & "';")

                    Else
                        ENDING_QUANTITY = NumIsNull(rd("ENDING_QUANTITY")) + NumIsNull(rd("QUANTITY"))
                        SqlExecuted("UPDATE item_inventory SET ENDING_COST='" & NumIsNull(rd("ENDING_UNIT_COST")) * ENDING_QUANTITY & "',ENDING_QUANTITY='" & ENDING_QUANTITY & "',PREVIOUS_ID = " & GotNullNumber(prPrev_ID) & " WHERE ID = '" & rd("ID") & "' and ITEM_ID = '" & prItem_ID & "' and LOCATION_ID='" & prLocation_ID & "';")
                        prPrev_ID = NumIsNull(rd("ID"))
                    End If
                End While
                rd.Close()
            End If
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try


    End Sub
    Public Sub fAccount_Journal_SQL(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal SUBSIDIARY_ID As Integer, ByVal OBJECT_TYPE As Integer, ByVal OBJECT_ID As Integer, ByVal OBJECT_DATE As Date, ByVal ENTRY_TYPE As Integer, ByVal THIS_AMOUNT As Double, ByRef THIS_JOURNAL_NO As Integer)
        If ACCOUNT_ID = 0 Then
            Exit Sub
        End If

        Dim SQL As String = ""
        If ACCOUNT_ID <> 0 Then
            Dim AMOUNT As Double = IIf(THIS_AMOUNT >= 0, THIS_AMOUNT, THIS_AMOUNT * -1)
            Dim THIS_ENDING_BALANCE As Double = 0
            Dim ENDING_BALANCE As Double = 0
            Dim THIS_ID As Integer = 0

            Dim rd As OdbcDataReader = SqlReader($"SELECT ID,JOURNAL_NO,PREVIOUS_ID,ENDING_BALANCE,ENTRY_TYPE,AMOUNT from account_journal WHERE ACCOUNT_ID = '{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' and OBJECT_TYPE = '{OBJECT_TYPE}' and OBJECT_ID = '{OBJECT_ID}' and OBJECT_DATE = '{DateFormatMySql(OBJECT_DATE)}' limit 1;")
            If rd.Read Then
                'update
                THIS_ID = NumIsNull(rd("ID"))
                THIS_JOURNAL_NO = NumIsNull(rd("JOURNAL_NO"))
                Select Case rd("ENTRY_TYPE")
                    Case 0
                        ENDING_BALANCE = NumIsNull(rd("ENDING_BALANCE")) - NumIsNull(rd("AMOUNT"))
                        ENDING_BALANCE = ENDING_BALANCE + AMOUNT
                    Case 1
                        ENDING_BALANCE = NumIsNull(rd("ENDING_BALANCE")) + NumIsNull(rd("AMOUNT"))
                        ENDING_BALANCE = ENDING_BALANCE - AMOUNT
                End Select

                ENDING_BALANCE = NumIsNull(rd("ENDING_BALANCE"))
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
                    THIS_JOURNAL_NO = fNEW_JOURNAL_NO()
                End If


                THIS_ID = ObjectTypeMapId("ACCOUNT_JOURNAL")

                SQL = $"INSERT INTO `account_journal`
   SET `ID` = '{THIS_ID}',
  `PREVIOUS_ID` = {fGet_Previous_ID(ACCOUNT_ID, LOCATION_ID)},
  `SEQUENCE_NO` = {fNEW_SEQUENCE_NO(ACCOUNT_ID, LOCATION_ID)},
  `JOURNAL_NO` = '{THIS_JOURNAL_NO}',
  `ACCOUNT_ID` = '{ACCOUNT_ID}',
  `LOCATION_ID` = '{LOCATION_ID}',
  `SUBSIDIARY_ID` = '{SUBSIDIARY_ID}',
  `SEQUENCE_GROUP` = {fNew_THIS_SEQUENCE_GROUP(ACCOUNT_ID, LOCATION_ID, ENTRY_TYPE, OBJECT_DATE)},
  `OBJECT_TYPE` = '{OBJECT_TYPE}',
  `OBJECT_ID` = '{OBJECT_ID}',
  `OBJECT_DATE` = '{DateFormatMySql(OBJECT_DATE)}',
  `ENTRY_TYPE` = '{ENTRY_TYPE}',
  `AMOUNT` = '{AMOUNT}',
  `ENDING_BALANCE` = ifnull( {fGet_Previous_Balance(ACCOUNT_ID, LOCATION_ID, ENTRY_TYPE, AMOUNT)},0),
  `EXTENDED_OPTIONS` = '';"


            End If
            rd.Close()
        End If
        SqlExecuted(SQL)

    End Sub

    Public Function fNEW_JOURNAL_NO() As Double
        Return Val(GetMaxField("JOURNAL_NO", "ACCOUNT_JOURNAL"))
    End Function
    Public Function fNEW_SEQUENCE_NO(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer) As String
        Return $"(Select  (MAX(CAST(SEQUENCE_NO AS UNSIGNED)) +1 ) From `ACCOUNT_JOURNAL` as a where ACCOUNT_ID ='{ACCOUNT_ID}' and LOCATION_ID ='{LOCATION_ID}' limit 1)"
    End Function
    Public Function fNew_THIS_SEQUENCE_GROUP(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal ENTRY_TYPE As Integer, ByVal DT As Date) As String
        Return $"(SELECT  IF(IFNULL((SELECT id FROM `ACCOUNT_JOURNAL` as a WHERE SEQUENCE_GROUP = '{DT.Date.Year}' AND  ACCOUNT_ID = '{ACCOUNT_ID}' AND LOCATION_ID = '{LOCATION_ID}' AND ENTRY_TYPE = '{ENTRY_TYPE}' LIMIT 1),0)=0,YEAR(CURDATE()),0) )"
    End Function

    'Private Sub fGet_Previous_id(ByVal IsUpdate As Boolean, ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByRef ENDING_BALANCE As Double, ByRef PREVIOUS_ID As Integer)
    '    If IsUpdate = True Then

    '        Dim rd As OdbcDataReader = SqlReader($"select ENDING_BALANCE,ID from account_journal where id = '{PREVIOUS_ID}' and  account_id = '{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' order by `ID` DESC  limit 1;")
    '        If rd.Read Then
    '            ENDING_BALANCE = NumIsNull(rd("ENDING_BALANCE"))
    '            PREVIOUS_ID = NumIsNull(rd("ID"))
    '        End If
    '        rd.Close()
    '    Else
    '        Dim rd As OdbcDataReader = SqlReader($"select ENDING_BALANCE,ID from account_journal where account_id = '{ACCOUNT_ID}' and LOCATION_ID = '{LOCATION_ID}' order by `ID` DESC  limit 1;")
    '        If rd.Read Then
    '            ENDING_BALANCE = NumIsNull(rd("ENDING_BALANCE"))
    '            PREVIOUS_ID = NumIsNull(rd("ID"))
    '        End If
    '        rd.Close()
    '    End If

    'End Sub
    Private Function fGet_Previous_ID(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer) As String

        Return $"(Select a.ID from account_journal as a  where a.account_id = '{ACCOUNT_ID}' and a.LOCATION_ID = '{LOCATION_ID}' order by a.`ID` DESC  limit 1)"


    End Function


    Private Function fGet_Previous_Balance(ByVal ACCOUNT_ID As Integer, ByVal LOCATION_ID As Integer, ByVal ENTRY As Integer, ByVal AMT As Double) As String

        Return $"(Select  (a.ENDING_BALANCE{IIf(ENTRY = 0, "+", "-")}{AMT}) from account_journal as a where a.account_id = '{ACCOUNT_ID}' and a.LOCATION_ID = '{LOCATION_ID}' order by a.`ID` DESC  limit 1)"


    End Function
End Module
