Imports System.Data.Odbc
Module modItemInventory






    Private Sub GS_FixedInventoryList(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal QUANTITY_END As Double, ByVal SEQUENCE_NO As Integer)
        Dim ENDING_QUANTITY As Double = QUANTITY_END
        Dim rd As OdbcDataReader = SqlReader($"SELECT ID,SOURCE_REF_TYPE,SOURCE_REF_ID,QUANTITY,SOURCE_REF_DATE,COST, ENDING_UNIT_COST from item_inventory WHERE SEQUENCE_NO > '{SEQUENCE_NO}' and LOCATION_ID = '{LOCATION_ID}' and ITEM_ID = '{ITEM_ID}' ORDER BY SEQUENCE_NO")
        While rd.Read

            Dim ENDING_UNIT_COST As Double = GF_NumIsNull(rd("ENDING_UNIT_COST"))
            ENDING_QUANTITY += GF_NumIsNull(rd("QUANTITY"))
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
                `SOURCE_REF_DATE` = '{ GetDateFormatMySql(rd("SOURCE_REF_DATE"))}'
            LIMIT 1")

        End While
        rd.Close()

    End Sub

    Public Function GS_IsInventoryLastEntry(ByVal ItemGrid As DataGridView, ByVal LOCATION_ID As Integer, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_DATE As Date) As Boolean
        Dim IsLastEntry As Boolean = True
        For i As Integer = 0 To ItemGrid.Rows.Count - 1
            With ItemGrid.Rows(i)


                If GF_NumIsNull(.Cells("ITEM_TYPE").Value) <= 1 Then



                    Dim ID As Integer = .Cells("ID").Value
                    Dim ITEM_ID As Integer = .Cells("ITEM_ID").Value

                    Dim SQL As String = $"select  n.SOURCE_REF_TYPE,n.SOURCE_REF_ID from item_inventory as n  where n.SOURCE_REF_DATE <='{GetDateNow()}' and n.location_id = '{LOCATION_ID}' and n.iTEM_ID = '{ITEM_ID}'  ORDER BY n.SOURCE_REF_DATE DESC,n.ID DESC LIMIT 1;"
                    Dim rd As OdbcDataReader = SqlReader(SQL)
                    If rd.Read Then

                        If SOURCE_REF_TYPE = GF_NumIsNull(rd("SOURCE_REF_TYPE")) And ID = GF_NumIsNull(rd("SOURCE_REF_ID")) Then

                        Else
                            IsLastEntry = False
                            rd.Close()
                            MessageBox.Show("Old transactions cannot be modified.", "System Warning.", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            Exit For
                        End If

                    End If
                    rd.Close()
                End If
            End With
        Next
        Return IsLastEntry


    End Function


    Public Sub GS_Item_Inventory_SQL(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal QUANTITY As Double, ByRef COST As Double, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal SOURCE_REF_DATE As Date, ByVal BATCH_ID As Integer)
        Dim PREVIOUS_ID As Integer = 0
        Dim SEQUENCE_NO As Integer = 0
        Dim LAST_QTY As Double = 0
        Dim LAST_COST As Double = 0

        Dim rd As OdbcDataReader = SqlReader($"select ID,PREVIOUS_ID,SEQUENCE_NO from item_inventory where SOURCE_REF_TYPE = '{SOURCE_REF_TYPE}' and SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE = '{GetDateFormatMySql(SOURCE_REF_DATE)}' and LOCATION_ID = '{LOCATION_ID}' and ITEM_ID = '{ITEM_ID}' limit 1;")

        Dim ENDING_UNIT_COST As Double
        Dim ENDING_QUANTITY As Double
        Dim ENDING_COST As Double

        If rd.Read Then
            'Update
            GS_Item_Inventory_Last_Ending_Qty(ITEM_ID, LOCATION_ID, SOURCE_REF_DATE, LAST_QTY, LAST_COST, SOURCE_REF_TYPE, SOURCE_REF_ID)
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
                `SOURCE_REF_DATE` = '{ GetDateFormatMySql(SOURCE_REF_DATE)}'
            ")

            '============ data ============
            '  GS_FixedInventoryList(ITEM_ID, LOCATION_ID, ENDING_QUANTITY, GF_NumIsNull(rd("SEQUENCE_NO")))

        Else

            GS_GET_PREVIOUS_ID(ITEM_ID, LOCATION_ID, PREVIOUS_ID, SEQUENCE_NO)
            GS_Item_Inventory_Last_Ending_Qty(ITEM_ID, LOCATION_ID, SOURCE_REF_DATE, LAST_QTY, LAST_COST, SOURCE_REF_TYPE, SOURCE_REF_ID)

            If COST > 0 Then
                LAST_COST = COST

            ElseIf LAST_COST = 0 Then
                LAST_COST = GF_GetNumberFieldValue("ITEM", "ID", ITEM_ID, "COST")
            End If

            ENDING_UNIT_COST = LAST_COST
            ENDING_QUANTITY = LAST_QTY + QUANTITY
            ENDING_COST = ENDING_QUANTITY * ENDING_UNIT_COST

            Dim This_ID As Integer = ObjectTypeMapId("ITEM_INVENTORY")

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
              `SOURCE_REF_DATE` = '{ GetDateFormatMySql(SOURCE_REF_DATE)}';")


        End If
        rd.Close()
        COST = ENDING_UNIT_COST

    End Sub

    Private Sub GS_GET_PREVIOUS_ID(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByRef R_PREVIOUS_ID As Integer, ByRef R_SEQUENCE_NO As Integer)
        'INSERT PURPOSE
        Dim rd As OdbcDataReader = SqlReader($"select * from item_inventory where ITEM_ID = '{ITEM_ID}' and LOCATION_ID = '{LOCATION_ID}' order by ID DESC limit 1; ")
        If rd.Read Then
            R_PREVIOUS_ID = GF_NumIsNull(rd("PREVIOUS_ID"))
            R_SEQUENCE_NO = GF_NumIsNull(rd("SEQUENCE_NO")) + 1
        Else
            R_PREVIOUS_ID = 0
            R_SEQUENCE_NO = 0
        End If
        rd.Close()

    End Sub
    Private Sub GS_Item_Inventory_Last_Ending_Qty(ByVal ITEM_ID As Integer, ByVal LOCATION_ID As Integer, ByVal DT As Date, ByRef ENDING_QUANTITY As Double, ByRef ENDING_UNIT_COST As Double, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer)

        Dim ID As Integer = GF_GetNumberFieldValueOneReturn($" SELECT IFNULL ( i.`ID`, 0 ) from item_inventory as i WHERE i.SOURCE_REF_DATE ='{GetDateFormatMySql(DT)}' and  i.SOURCE_REF_TYPE = '{SOURCE_REF_TYPE}' and  i.SOURCE_REF_ID = '{SOURCE_REF_ID}' limit 1 ")



        Dim SQL As String = $"select n.ENDING_QUANTITY,n.ENDING_UNIT_COST,i.COST,n.SEQUENCE_NO from item_inventory as n inner join item as i on i.id = n.item_id where n.SOURCE_REF_DATE <='{GetDateFormatMySql(DT)}' and n.location_id = '{LOCATION_ID}' and n.iTEM_ID = '{ITEM_ID}' AND n.ID <> {ID} ORDER BY n.SOURCE_REF_DATE DESC,n.ID DESC LIMIT 1;"
        Dim rd As OdbcDataReader = SqlReader(SQL)
        If rd.Read Then
            ENDING_QUANTITY = GF_NumIsNull(rd("ENDING_QUANTITY"))
            ENDING_UNIT_COST = GF_NumIsNull(rd("COST"))
        End If
        rd.Close()
    End Sub



End Module
