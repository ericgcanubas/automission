﻿Imports System.Data.Odbc
Module modItemInventory
    Public Sub fItem_Inventory_SQL(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal QUANTITY As Double, ByRef COST As Double, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal SOURCE_REF_DATE As Date, ByVal BATCH_ID As Integer)

        Dim This_ID As Integer = 0
        Dim PREVIOUS_ID As Integer = 0
        Dim SEQUENCE_NO As Integer = 0
        Dim LAST_QTY As Double = 0
        Dim LAST_COST As Double = 0
        Dim ENDING_QUANTITY As Double = 0
        Dim ENDING_UNIT_COST As Double = 0
        Dim ENDING_COST As Double = 0
        Dim rd As OdbcDataReader = fReader($"select ID,PREVIOUS_ID,SEQUENCE_NO from item_inventory where SOURCE_REF_TYPE = '{SOURCE_REF_TYPE}' and SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE = '{fDateFormatMYSQL(SOURCE_REF_DATE)}' and LOCATION_ID = '{LOCATION_ID}' and ITEM_ID = '{ITEM_ID}' limit 1;")
        If rd.Read Then
            'Update
            fItem_Inventory_Last_Ending_Qty(ITEM_ID, LOCATION_ID, fNumisNULL(rd("PREVIOUS_ID")), fNumisNULL(rd("SEQUENCE_NO")), SOURCE_REF_DATE, LAST_QTY, LAST_COST)

            If COST > 0 Then
                LAST_COST = COST
            End If

            ENDING_UNIT_COST = LAST_COST
            ENDING_QUANTITY = LAST_QTY + QUANTITY
            ENDING_COST = ENDING_QUANTITY * ENDING_UNIT_COST

            fExecutedOnly($"UPDATE 
                `item_inventory`
            SET 
                `BATCH_ID` = '{BATCH_ID}',
                `QUANTITY` = '{QUANTITY}',
                `COST` = '{COST}',
                `ENDING_QUANTITY` = '{ENDING_QUANTITY}',
                `ENDING_UNIT_COST` = '{ENDING_UNIT_COST}',
                `ENDING_COST` = '{ENDING_COST}'
            WHERE 
                `ID` = '{rd("ID")}' and
                `ITEM_ID` = '{ITEM_ID}' and 
                `LOCATION_ID` = '{LOCATION_ID}' and
                `SOURCE_REF_TYPE` = '{SOURCE_REF_TYPE}' and 
                `SOURCE_REF_ID` = '{SOURCE_REF_ID}' and
                `SOURCE_REF_DATE` = '{ fDateFormatMYSQL(SOURCE_REF_DATE)}'
            LImIT 1;")

        Else


            fGET_PREVIOUS_ID(ITEM_ID, LOCATION_ID, PREVIOUS_ID, SEQUENCE_NO)
            fItem_Inventory_Last_Ending_Qty(ITEM_ID, LOCATION_ID, 0, 0, SOURCE_REF_DATE, LAST_QTY, LAST_COST)
            If COST > 0 Then
                LAST_COST = COST
            End If
            ENDING_UNIT_COST = LAST_COST
            ENDING_QUANTITY = LAST_QTY + QUANTITY
            ENDING_COST = ENDING_QUANTITY * ENDING_UNIT_COST

            This_ID = fObjectTypeMap_ID("ITEM_INVENTORY")

            fExecutedOnly($"INSERT INTO 
               `item_inventory`
            SET 
              `PREVIOUS_ID` = {fGotNullNumber(PREVIOUS_ID)},
              `SEQUENCE_NO` = '{SEQUENCE_NO}',
              `BATCH_ID` = '{BATCH_ID}', 
              `QUANTITY` = '{QUANTITY}',
              `COST` = '{COST}',
              `ENDING_QUANTITY` = '{ENDING_QUANTITY}',
              `ENDING_UNIT_COST` = '{ENDING_UNIT_COST}',
              `ENDING_COST` = '{ENDING_COST}',
              `ID` = '{This_ID}',
              `ITEM_ID` = '{ITEM_ID}', 
              `LOCATION_ID` = '{LOCATION_ID}',
              `SOURCE_REF_TYPE` = '{SOURCE_REF_TYPE}', 
              `SOURCE_REF_ID` = '{SOURCE_REF_ID}',
              `SOURCE_REF_DATE` = '{ fDateFormatMYSQL(SOURCE_REF_DATE)}';")

        End If
        rd.Close()
        COST = ENDING_UNIT_COST

    End Sub

    Private Sub fGET_PREVIOUS_ID(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByRef R_PREVIOUS_ID As Integer, ByRef R_SEQUENCE_NO As Integer)
        'INSERT PURPOSE
        Dim rd As OdbcDataReader = fReader($"select * from item_inventory where ITEM_ID = '{ITEM_ID}' and LOCATION_ID = '{LOCATION_ID}' order by ID DESC limit 1; ")
        If rd.Read Then
            R_PREVIOUS_ID = fNumisNULL(rd("PREVIOUS_ID"))
            R_SEQUENCE_NO = fNumisNULL(rd("SEQUENCE_NO")) + 1
        Else
            R_PREVIOUS_ID = 0
            R_SEQUENCE_NO = 0
        End If
        rd.Close()

    End Sub
    Private Sub fItem_Inventory_Last_Ending_Qty(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal PREVIOUS_ID As Integer, ByVal SEQUENCE_NO As Integer, ByVal DT As Date, ByRef ENDING_QUANTITY As Double, ByRef ENDING_UNIT_COST As Double)
        Dim SQL As String
        If PREVIOUS_ID = 0 Then
            SQL = $"select n.ENDING_QUANTITY,n.ENDING_UNIT_COST,i.COST from item_inventory as n inner join item as i on i.id = n.item_id where n.SOURCE_REF_DATE <='{fDateFormatMYSQL(DT)}'  and n.location_id = '{LOCATION_ID}' and n.iTEM_ID = '{ITEM_ID}' ORDER BY n.SOURCE_REF_DATE DESC,n.ID DESC  LIMIT 1;"

        Else
            SQL = $"select n.ENDING_QUANTITY,n.ENDING_UNIT_COST,i.COST from item_inventory as n inner join item as i on i.id = n.item_id where n.SOURCE_REF_DATE <='{fDateFormatMYSQL(DT)}' and  n.SEQUENCE_NO < '{SEQUENCE_NO}'  and n.location_id = '{LOCATION_ID}' and n.iTEM_ID = '{ITEM_ID}' ORDER BY n.SOURCE_REF_DATE DESC,n.ID DESC LIMIT 1;"
        End If
        Dim rd As OdbcDataReader = fReader(SQL)
        If rd.Read Then
            ENDING_QUANTITY = fNumisNULL(rd("ENDING_QUANTITY"))
            ENDING_UNIT_COST = fNumisNULL(rd("COST"))
        End If
        rd.Close()
    End Sub

End Module