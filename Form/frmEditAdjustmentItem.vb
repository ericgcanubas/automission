﻿Imports System.Data.Odbc
Public Class frmEditAdjustmentItem
    Public aITEM_ID As Integer
    Public aSOURCE_REF_ID As Integer
    Public aAdjustment_ID As Integer
    Public aLocation_ID As Integer
    Public aCLickOK As Boolean = False
    Public aDGV_Row As DataGridViewRow

    Public THIS_QUANTITY As Double
    Public END_QUANTITY As Integer
    Public E_U_COST As Double
    Public PREVIOUS_ID As Integer
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If numQTY.Value = 0 Then
            fMessageboxInfo("Zero not allowed.")
            Exit Sub
        End If

        Dim Last_QTY As Integer = fGetEndingQty(aITEM_ID, aLocation_ID, aSOURCE_REF_ID)
        Dim New_DIFF As Integer = 0

        New_DIFF = Last_QTY - numQTY.Value


        fExecutedOnly($"UPDATE inventory_adjustment_items SET QTY_DIFFERENCE ='{New_DIFF}'  WHERE item_id ='{aITEM_ID}' AND inventory_adjustment_id ='{aAdjustment_ID}' and ID ='{aSOURCE_REF_ID}' limit 1;")
        fExecutedOnly($"UPDATE item_inventory SET QUANTITY = '{New_DIFF}',ENDING_QUANTITY ='{numQTY.Value}'  WHERE source_ref_type='6' AND item_id ='{aITEM_ID}' AND location_id ='{aLocation_ID}' and SOURCE_REF_ID ='{aSOURCE_REF_ID}' limit 1;")
        aDGV_Row.Cells("QTY_DIFFERENCE").Value = New_DIFF
        aDGV_Row.Cells("CONTROL_STATUS").Value = "E"

        aCLickOK = True
        ' fMessageboxInfo("Click Tools -> Recompute New Cost.")
        Me.Close()


    End Sub
    Private Function fGetEndingQty(ByVal xITEM_ID As Integer, ByVal xLocation_ID As Integer, ByVal xSOURCE_REF_ID As Integer) As Integer
        Dim PREV_ID As Integer = 0
        Dim SEQ_NO As Integer = 0
        Dim DT As Date
        Dim rd As OdbcDataReader = fReader($"select SOURCE_REF_DATE,PREVIOUS_ID,SEQUENCE_NO from item_inventory  WHERE source_ref_type='6' AND item_id ='{xITEM_ID}' AND location_id ='{xLocation_ID}' and SOURCE_REF_ID ='{xSOURCE_REF_ID}' limit 1;")
        If rd.Read Then
            PREV_ID = fNumisNULL(rd("PREVIOUS_ID"))
            SEQ_NO = fNumisNULL(rd("SEQUENCE_NO"))
            DT = CDate(rd("SOURCE_REF_DATE"))

        End If
        rd.Close()
        Dim Qty As Integer = 0
        If PREV_ID <> 0 Then
            Dim PREV_rd As OdbcDataReader = fReader($"select ENDING_QUANTITY from item_inventory where SOURCE_REF_DATE <='{fDateFormatMYSQL(DT)}' and  SEQUENCE_NO < '{SEQ_NO}' and  ID < '{PREV_ID}' and location_id = '{xLocation_ID}' and iTEM_ID = '{xITEM_ID}' ORDER BY source_ref_date DESC LIMIT 1;")
            If PREV_rd.Read Then
                Qty = PREV_rd("ENDING_QUANTITY")
            End If
            PREV_rd.Close()


        End If
        Return Qty
    End Function
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        aCLickOK = False

        Me.Close()
    End Sub

    Private Sub frmEditAdjustmentItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim rd As OdbcDataReader = fReader($"SELECT PREVIOUS_ID,QUANTITY,ENDING_QUANTITY,ENDING_UNIT_COST,ENDING_COST FROM item_inventory WHERE source_ref_type='6' AND item_id ='{aITEM_ID}' AND location_id ='{aLocation_ID}' and SOURCE_REF_ID ='{aSOURCE_REF_ID}'")
        If rd.Read Then
            PREVIOUS_ID = fNumisNULL(rd("PREVIOUS_ID"))
            END_QUANTITY = fNumisNULL(rd("ENDING_QUANTITY"))
            THIS_QUANTITY = fNumisNULL(rd("QUANTITY"))
            E_U_COST = fNumisNULL(rd("ENDING_UNIT_COST"))

            numQTY.Value = END_QUANTITY
            numCOST.Value = E_U_COST
        End If
        rd.Close()

    End Sub
End Class