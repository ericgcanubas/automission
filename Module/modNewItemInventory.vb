Imports System.Data.Odbc
Module modNewItemInventory

    Public Sub N_Item_Inventory(ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal SOURCE_REF_DATE As Date, ByVal ITEM_ID As Integer, ByVal COST As Integer, ByVal LOCATION_ID As Integer, ByVal QTY As Integer, ByVal ENTRY_COST As Double, ByVal IsAdded As Boolean, ByVal Optional BATCH_ID As Integer = 0)
        Dim N_QTY As Integer = 0
        If IsAdded = True Then
            N_QTY = QTY
        Else
            N_QTY = QTY * -1
        End If

        Dim rd As OdbcDataReader = SqlReader($"select * from item_inventory where SOURCE_REF_TYPE = '{SOURCE_REF_TYPE}' and SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE = '{DateFormatMySql(SOURCE_REF_DATE)}' and ITEM_ID = '{ITEM_ID}' limit 1;")
        If rd.Read Then

            'UPDATE
            If NumIsNull(rd("LOCATION_ID")) = LOCATION_ID Then

            Else
                'Change LOCATION
            End If

            If NumIsNull(rd("COST")) = COST Then

            Else
                'Change Cost
            End If

            If NumIsNull(rd("QTY")) = QTY Then

            Else
                'Change Cost
            End If



        Else
            'INSERT

            Dim N_SEQUENCE_NO As Integer = 0
            Dim N_ENDING_QTY As Integer = 0
            Dim N_ENDING_COST As Integer = 0
            Dim N_PREVIOUS_ID As Integer = 0
            'INSERT 
            'Checking Last Entry
            Dim c_rd As OdbcDataReader = SqlReader($"select ID,SEQUENCE_NO,ENDING_QUANTITY,ENDING_COST from item_inventory Where ITEM_ID = '{ITEM_ID}' and LOCATION_ID = '{LOCATION_ID}' order by SEQUENCE_NO DESC Limit 1")
            If c_rd.Read Then
                N_SEQUENCE_NO = NumIsNull(c_rd("SEQUENCE_NO"))
                N_ENDING_QTY = NumIsNull(c_rd("ENDING_QUANTITY"))
                N_ENDING_COST = NumIsNull(c_rd("ENDING_COST"))
                N_PREVIOUS_ID = NumIsNull(c_rd("ID"))
            End If
            c_rd.Close()


            N_ENDING_QTY = N_ENDING_QTY + N_QTY
            N_ENDING_COST = N_ENDING_QTY * ENTRY_COST

            Dim ThisID As Integer = ObjectTypeMapId("ITEM_INVENTORY")

            SqlExecuted($"INSERT INTO item_inventory SET ID = '{ThisID}',PREVIOUS_ID={GotNullNumber(N_PREVIOUS_ID)},SEQUENCE_NO='{N_SEQUENCE_NO + 1}',ITEM_ID ='{ITEM_ID}',LOCATION_ID ='{LOCATION_ID}',BATCH_ID={GotNullNumber(BATCH_ID)},SOURCE_REF_TYPE='{SOURCE_REF_TYPE}',SOURCE_REF_ID='{SOURCE_REF_ID}',SOURCE_REF_DATE='{DateFormatMySql(SOURCE_REF_DATE)}',QUANTITY='{N_QTY}',COST='{ENTRY_COST}',ENDING_QUANTITY='{N_ENDING_QTY}',ENDING_UNIT_COST='{ENTRY_COST}',ENDING_COST='{N_ENDING_COST}' ")


        End If
        rd.Close()
    End Sub

End Module
