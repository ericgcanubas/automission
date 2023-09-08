Imports System.Data.Odbc
Module modQuantityOnHand


    Public Function fQTY_ACTUAL_ON_DATE_LOCATION(ByVal prItem_ID As Integer, ByVal dt As Date, ByVal sLocation_ID As String) As Double

        Dim sON_HAND As String

        If sLocation_ID = "" Then
            sON_HAND = $"(SELECT SUM(T.TOTAL_TARGET) AS TOTAL FROM (SELECT (SELECT  ixx.`ENDING_QUANTITY` FROM item_inventory AS ixx WHERE ixx.item_id = ix.item_id AND ixx.`LOCATION_ID` = ix.location_id ORDER BY ixx.`ID` DESC LIMIT 1 ) AS TOTAL_TARGET FROM item_inventory AS ix WHERE ix.item_id = i.ID GROUP BY ix.location_id) AS T LIMIT 1)  "
        Else
            sON_HAND = "(SELECT format( ix.`ENDING_QUANTITY`,0) FROM item_inventory AS ix WHERE ix.item_id = i.ID AND ix.`LOCATION_ID` = '" & sLocation_ID & "' AND ix.SOURCE_REF_DATE <= '" & DateFormatMySql(dt) & "' ORDER BY ix.`SOURCE_REF_DATE` DESC,ix.ID DESC LIMIT 1 ) "
        End If

        Dim sQuery As String = "SELECT " & sON_HAND & "  AS `TOTAL_QTY` FROM item AS i WHere i.`ID` ='" & prItem_ID & "' limit 1"


        Dim i As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                i = NumIsNull(rd("TOTAL_QTY"))
            End If
            rd.Close()
        Catch ex As Exception

        End Try

        Return i
    End Function




End Module
