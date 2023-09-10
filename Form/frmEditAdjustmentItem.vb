Imports System.Data.Odbc
Public Class FrmEditAdjustmentItem
    Public aITEM_ID As Integer
    Public aSOURCE_REF_ID As Integer
    Public aAdjustment_ID As Integer
    Public aLocation_ID As Integer
    Public IsClickOk As Boolean = False
    Public DgViewRow As DataGridViewRow

    Public THIS_QUANTITY As Double
    Public END_QUANTITY As Integer
    Public E_U_COST As Double
    Public PREVIOUS_ID As Integer
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If numQTY.Value = 0 Then
            MessageBoxInfo("Zero not allowed.")
            Exit Sub
        End If

        Dim Last_QTY As Double = GetEndingQty(aITEM_ID, aLocation_ID, aSOURCE_REF_ID)
        Dim New_DIFF As Double = Last_QTY - numQTY.Value

        SqlExecuted($"UPDATE inventory_adjustment_items SET QTY_DIFFERENCE ='{New_DIFF}'  WHERE item_id ='{aITEM_ID}' AND inventory_adjustment_id ='{aAdjustment_ID}' and ID ='{aSOURCE_REF_ID}' limit 1;")
        SqlExecuted($"UPDATE item_inventory SET QUANTITY = '{New_DIFF}',ENDING_QUANTITY ='{numQTY.Value}'  WHERE source_ref_type='6' AND item_id ='{aITEM_ID}' AND location_id ='{aLocation_ID}' and SOURCE_REF_ID ='{aSOURCE_REF_ID}' limit 1;")
        DgViewRow.Cells("QTY_DIFFERENCE").Value = New_DIFF
        DgViewRow.Cells("CONTROL_STATUS").Value = "E"

        IsClickOk = True

        Me.Close()


    End Sub
    Private Function GetEndingQty(ByVal xITEM_ID As Integer, ByVal xLocation_ID As Integer, ByVal xSOURCE_REF_ID As Integer) As Integer
        Dim PREV_ID As Integer = 0
        Dim SEQ_NO As Integer = 0
        Dim DT As Date
        Dim rd As OdbcDataReader = SqlReader($"select SOURCE_REF_DATE,PREVIOUS_ID,SEQUENCE_NO from item_inventory  WHERE source_ref_type='6' AND item_id ='{xITEM_ID}' AND location_id ='{xLocation_ID}' and SOURCE_REF_ID ='{xSOURCE_REF_ID}' limit 1;")
        If rd.Read Then
            PREV_ID = NumIsNull(rd("PREVIOUS_ID"))
            SEQ_NO = NumIsNull(rd("SEQUENCE_NO"))
            DT = CDate(rd("SOURCE_REF_DATE"))

        End If
        rd.Close()
        Dim Qty As Integer = 0
        If PREV_ID <> 0 Then
            Dim PREV_rd As OdbcDataReader = SqlReader($"select ENDING_QUANTITY from item_inventory where SOURCE_REF_DATE <='{DateFormatMySql(DT)}' and  SEQUENCE_NO < '{SEQ_NO}' and  ID < '{PREV_ID}' and location_id = '{xLocation_ID}' and iTEM_ID = '{xITEM_ID}' ORDER BY source_ref_date DESC LIMIT 1;")
            If PREV_rd.Read Then
                Qty = PREV_rd("ENDING_QUANTITY")
            End If
            PREV_rd.Close()


        End If
        Return Qty
    End Function
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        IsClickOk = False

        Me.Close()
    End Sub

    Private Sub FrmEditAdjustmentItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim rd As OdbcDataReader = SqlReader($"SELECT PREVIOUS_ID,QUANTITY,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST FROM item_inventory WHERE source_ref_type='6' AND item_id ='{aITEM_ID}' AND location_id ='{aLocation_ID}' and SOURCE_REF_ID ='{aSOURCE_REF_ID}'")
        If rd.Read Then
            PREVIOUS_ID = NumIsNull(rd("PREVIOUS_ID"))
            END_QUANTITY = NumIsNull(rd("ENDING_QUANTITY"))
            THIS_QUANTITY = NumIsNull(rd("QUANTITY"))
            E_U_COST = NumIsNull(rd("ENDING_UNIT_COST"))

            numQTY.Value = END_QUANTITY
            numCOST.Value = E_U_COST
        End If
        rd.Close()

    End Sub
End Class