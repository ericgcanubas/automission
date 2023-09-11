Imports System.Data.Odbc
Public Class FrmInventoryReComputed

    Public gsITEM_ID As Integer
    Public gsLOCATION_ID As Integer
    Dim Qty As Double
    Dim Qty_End As Double
    Dim Cost As Double
    Dim Ending_unit_cost As Double
    Dim Ending_cost As Double
    Dim DateStart As Date

    Private Function LatestAdjustment() As Boolean
        Dim B As Boolean
        Dim rd As OdbcDataReader = SqlReader($"SELECT SOURCE_REF_DATE,QUANTITY,ENDING_QUANTITY,COST FROM item_inventory  AS i WHERE i.`ITEM_ID` = '{gsITEM_ID}' AND i.`LOCATION_ID` = '{gsLOCATION_ID}' AND i.`SOURCE_REF_ID` = '6' Limit 1 ")
        If rd.Read Then
            DateStart = rd("SOURCE_REF_DATE")
            Qty = NumIsNull(rd("QUANTITY"))
            Qty_End = NumIsNull(rd("ENDING_QUANTITY"))
            Cost = NumIsNull(rd("COST"))
            Ending_unit_cost = NumIsNull(rd("ENDING_UNIT_COST"))
            Ending_cost = NumIsNull(rd("ENDING_COST"))
            B = True
        Else

            Qty = 0
            B = False
        End If
        rd.Close()
        Return B
    End Function
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()



    End Sub
End Class