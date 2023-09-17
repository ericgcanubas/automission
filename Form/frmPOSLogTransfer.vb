Public Class FrmPOSLogTransfer
    Public ThisLocationID As Integer
    Public ThisPOSlogID As Integer
    Public ThisPOS_STARTING_CASH_ID As Integer
    Public ThisPOS_Cash_Count_ID As Integer
    Public ThisPOS_DATE As Date
    Public Transfer_ClickOK As Boolean


    Private Sub FrmPOSLogTransfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Transfer_ClickOK = False
        Dim sql As String = $"SELECT 
  p.`ID`,
  p.`RECORDED_ON` AS `Recorded On`,
 Format(p.`TOTAL`,2) as `TOTAL`,
 Format(  p.`GRAND_TOTAL`,2)  AS `Grand Total`,
  p.`TRANSACTION_COUNT` AS `Trans Count`   
FROM

  pos_log AS p 
  INNER JOIN contact AS c 
    ON c.`ID` = p.`CASHIER_ID` 
  INNER JOIN location AS l 
    ON l.`ID` = p.`LOCATION_ID` 
    INNER JOIN pos_machine AS m
    ON m.`ID` = p.`POS_MACHINE_ID`
    right outer JOIN pos_starting_cash AS s 
    ON s.`ID`  = p.`STARTING_CASH_ID`
    LEFT OUTER JOIN pos_cash_count AS cc 
    ON cc.`ID` = p.`CASH_COUNT_ID`
    WHERE p.`ID` <> '{ThisPOSlogID}' and p.`LOCATION_ID` = '{ThisLocationID}' and date(p.RECORDED_ON) ='{DateFormatMySql(ThisPOS_DATE)}' 
    ORDER BY p.`RECORDED_ON` desc"

        GS_LoadDataGridView(dgvPOSLog, sql)

    End Sub

    Private Sub BtnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click

        If dgvPOSLog.Rows.Count <> 0 Then
            Dim TransferPOSLogID As Integer = dgvPOSLog.CurrentRow.Cells(0).Value
            If MessageBoxQuestion("Are you sure want to transfer ?") = True Then

                'POS CASH COUNT
                GS_POS_LOG_JOURNAL_DELETE(ThisPOSlogID, gsCASH_OVER_SHORT_EXPENSES, ThisPOS_DATE)
                SqlExecuted($"UPDATE pos_log SET CASH_COUNT_ID = null WHERE ID ='{ThisPOSlogID}' Limit 1")
                SqlExecuted($"UPDATE sales_receipt SET CASH_COUNT_ID =null WHERE POS_LOG_ID='{ThisPOSlogID}' ")
                SqlExecuted($"DELETE FROM  pos_cash_count WHERE ID ='{ThisPOS_Cash_Count_ID}'")


                'POS STARTING CASH
                GS_POS_Starting_Cash_Delete(ThisPOS_STARTING_CASH_ID, ThisPOS_DATE, ThisLocationID)
                SqlExecuted($"UPDATE pos_log SET STARTING_CASH_ID = null WHERE ID ='{ThisPOSlogID}' Limit 1")
                SqlExecuted($"DELETE FROM pos_starting_cash WHERE id = '{ThisPOS_STARTING_CASH_ID}' limit 1;")

                'Sales Receipt update from new POS log
                SqlExecuted($"UPDATE sales_receipt SET POS_LOG_ID ='{TransferPOSLogID}' WHERE POS_LOG_ID ='{ThisPOSlogID}'  and LOCATION_ID ='{ThisLocationID}' ")

                'REMOVE POS LOG
                SqlExecuted($"DELETE FROM pos_log WHERE id = '{ThisPOSlogID}' limit 1;")



                Transfer_ClickOK = True
                MessageBoxInfo("Successful.")
                Me.Close()


            End If

        Else

            If ThisPOSlogID = 0 Then
                MessageBoxInfo("Data not found.")

                Exit Sub
            End If

            If MessageBoxWarningYesNo("Are you sure to delete This LOG?") = True Then
                'POS CASH COUNT
                GS_POS_LOG_JOURNAL_DELETE(ThisPOSlogID, gsCASH_OVER_SHORT_EXPENSES, ThisPOS_DATE)
                SqlExecuted($"UPDATE pos_log SET CASH_COUNT_ID = null WHERE ID ='{ThisPOSlogID}' Limit 1")
                SqlExecuted($"UPDATE sales_receipt SET CASH_COUNT_ID =null WHERE POS_LOG_ID='{ThisPOSlogID}' ")
                SqlExecuted($"DELETE FROM  pos_cash_count WHERE ID ='{ThisPOS_Cash_Count_ID}'")


                'POS STARTING CASH
                GS_POS_Starting_Cash_Delete(ThisPOS_STARTING_CASH_ID, ThisPOS_DATE, ThisLocationID)
                SqlExecuted($"UPDATE pos_log SET STARTING_CASH_ID = null WHERE ID ='{ThisPOSlogID}' Limit 1")
                SqlExecuted($"DELETE FROM pos_starting_cash WHERE id = '{ThisPOS_STARTING_CASH_ID}' limit 1;")

                'REMOVE POS LOG
                SqlExecuted($"DELETE FROM pos_log WHERE id = '{ThisPOSlogID}' limit 1;")
            End If

        End If
    End Sub
End Class