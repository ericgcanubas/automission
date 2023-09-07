Imports System.Data.Odbc
Module modItemInventory

    Private Sub fFixedInventoryList(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal QUANTITY_END As Double, ByVal SEQUENCE_NO As Integer)
        Dim ENDING_QUANTITY As Double = QUANTITY_END
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,SOURCE_REF_TYPE,SOURCE_REF_ID,QUANTITY,SOURCE_REF_DATE,COST, ENDING_UNIT_COST from item_inventory WHERE SEQUENCE_NO > '{SEQUENCE_NO}' and LOCATION_ID = '{LOCATION_ID}' and ITEM_ID = '{ITEM_ID}' ORDER BY SEQUENCE_NO")
        While rd.Read

            Dim ENDING_UNIT_COST As Double = NumIsNull(rd("ENDING_UNIT_COST"))
            ENDING_QUANTITY = ENDING_QUANTITY + NumIsNull(rd("QUANTITY"))
            Dim ENDING_COST As Double = ENDING_QUANTITY * ENDING_UNIT_COST

            SqlExecuted($"UPDATE 
                `item_inventory`
            SET    
                `ENDING_QUANTITY` = '{ENDING_QUANTITY}',
                `ENDING_UNIT_COST` = '{ENDING_UNIT_COST}',
                `ENDING_COST` = '{ENDING_COST}'
            WHERE 
                `ID` = '{rd("ID")}' and
                `ITEM_ID` = '{ITEM_ID}' and 
                `LOCATION_ID` = '{LOCATION_ID}' and
                `SOURCE_REF_TYPE` = '{rd("SOURCE_REF_TYPE")}' and 
                `SOURCE_REF_ID` = '{rd("SOURCE_REF_ID")}' and
                `SOURCE_REF_DATE` = '{ DateFormatMySql(rd("SOURCE_REF_DATE"))}'
            LIMIT 1")

        End While
        rd.Close()

    End Sub

    Public Sub fItem_Inventory_SQL(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal QUANTITY As Double, ByRef COST As Double, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal SOURCE_REF_DATE As Date, ByVal BATCH_ID As Integer)

        Dim This_ID As Integer = 0
        Dim PREVIOUS_ID As Integer = 0
        Dim SEQUENCE_NO As Integer = 0
        Dim LAST_QTY As Double = 0
        Dim LAST_COST As Double = 0
        Dim ENDING_QUANTITY As Double = 0
        Dim ENDING_UNIT_COST As Double = 0
        Dim ENDING_COST As Double = 0

        Dim rd As OdbcDataReader = SqlReader($"select ID,PREVIOUS_ID,SEQUENCE_NO from item_inventory where SOURCE_REF_TYPE = '{SOURCE_REF_TYPE}' and SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE = '{DateFormatMySql(SOURCE_REF_DATE)}' and LOCATION_ID = '{LOCATION_ID}' and ITEM_ID = '{ITEM_ID}' limit 1;")

        If rd.Read Then
            'Update
            fItem_Inventory_Last_Ending_Qty(ITEM_ID, LOCATION_ID, NumIsNull(rd("PREVIOUS_ID")), NumIsNull(rd("SEQUENCE_NO")), SOURCE_REF_DATE, LAST_QTY, LAST_COST)
            If COST > 0 Then
                LAST_COST = COST
            End If

            ENDING_UNIT_COST = LAST_COST
            ENDING_QUANTITY = LAST_QTY + QUANTITY
            ENDING_COST = ENDING_QUANTITY * ENDING_UNIT_COST

            SqlExecuted($"UPDATE 
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
                `SOURCE_REF_DATE` = '{ DateFormatMySql(SOURCE_REF_DATE)}'
            LImIT 1;")

            '============ data ============
            fFixedInventoryList(ITEM_ID, LOCATION_ID, ENDING_QUANTITY, NumIsNull(rd("SEQUENCE_NO")))

        Else

            fGET_PREVIOUS_ID(ITEM_ID, LOCATION_ID, PREVIOUS_ID, SEQUENCE_NO)
            fItem_Inventory_Last_Ending_Qty(ITEM_ID, LOCATION_ID, 0, 0, SOURCE_REF_DATE, LAST_QTY, LAST_COST)

            If COST > 0 Then
                LAST_COST = COST
            End If

            ENDING_UNIT_COST = LAST_COST
            ENDING_QUANTITY = LAST_QTY + QUANTITY
            ENDING_COST = ENDING_QUANTITY * ENDING_UNIT_COST

            This_ID = ObjectTypeMapId("ITEM_INVENTORY")

            SqlExecuted($"INSERT INTO 
               `item_inventory`
            SET 
              `PREVIOUS_ID` = {GotNullNumber(PREVIOUS_ID)},
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
              `SOURCE_REF_DATE` = '{ DateFormatMySql(SOURCE_REF_DATE)}';")


        End If
        rd.Close()
        COST = ENDING_UNIT_COST

    End Sub

    Private Sub fGET_PREVIOUS_ID(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByRef R_PREVIOUS_ID As Integer, ByRef R_SEQUENCE_NO As Integer)
        'INSERT PURPOSE
        Dim rd As OdbcDataReader = SqlReader($"select * from item_inventory where ITEM_ID = '{ITEM_ID}' and LOCATION_ID = '{LOCATION_ID}' order by ID DESC limit 1; ")
        If rd.Read Then
            R_PREVIOUS_ID = NumIsNull(rd("PREVIOUS_ID"))
            R_SEQUENCE_NO = NumIsNull(rd("SEQUENCE_NO")) + 1
        Else
            R_PREVIOUS_ID = 0
            R_SEQUENCE_NO = 0
        End If
        rd.Close()

    End Sub
    Private Sub fItem_Inventory_Last_Ending_Qty(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal PREVIOUS_ID As Integer, ByVal SEQUENCE_NO As Integer, ByVal DT As Date, ByRef ENDING_QUANTITY As Double, ByRef ENDING_UNIT_COST As Double)
        Dim SQL As String
        If PREVIOUS_ID = 0 Then
            SQL = $"select n.ENDING_QUANTITY,n.ENDING_UNIT_COST,i.COST from item_inventory as n inner join item as i on i.id = n.item_id where n.SOURCE_REF_DATE <='{DateFormatMySql(DT)}'  and n.location_id = '{LOCATION_ID}' and n.iTEM_ID = '{ITEM_ID}' ORDER BY n.SOURCE_REF_DATE DESC,n.ID DESC  LIMIT 1;"
        Else
            SQL = $"select n.ENDING_QUANTITY,n.ENDING_UNIT_COST,i.COST from item_inventory as n inner join item as i on i.id = n.item_id where n.SOURCE_REF_DATE <='{DateFormatMySql(DT)}' and  n.SEQUENCE_NO < '{SEQUENCE_NO}'  and n.location_id = '{LOCATION_ID}' and n.iTEM_ID = '{ITEM_ID}' ORDER BY n.SOURCE_REF_DATE DESC,n.ID DESC LIMIT 1;"
        End If
        Dim rd As OdbcDataReader = SqlReader(SQL)
        If rd.Read Then
            ENDING_QUANTITY = NumIsNull(rd("ENDING_QUANTITY"))
            ENDING_UNIT_COST = NumIsNull(rd("COST"))
        End If
        rd.Close()
    End Sub

End Module
