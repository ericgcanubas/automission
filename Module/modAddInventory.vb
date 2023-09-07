Imports System.Data.Odbc
Module modAddInventory
    Public Sub fAddItem_Inventory_Row(ByVal dgvItem As DataGridView, ByVal prAdd As Boolean, ByVal prItem_ID As String, ByVal prUNIT_ID As String, ByVal InQty As Integer, ByVal prUNIT_BASE_QUANTITY As Integer, ByVal prNew_Value As Double, ByVal prControl_Status As String, ByVal prLocation_ID As Integer, ByVal prDate As Date, ByVal prBATCH_ID As Integer)

        Dim Unit_Name As String = GetStringFieldValue("unit_of_measure", "ID", prUNIT_ID, "NAME")
        Dim Batch_NO As String = GetStringFieldValue("item_batches", "id", prBATCH_ID, "BATCH_NO")
        Dim dCurrent_Qty As Double = Val(fItemInventoryReturnValue(prItem_ID, prLocation_ID, 6, 0, prDate, "ENDING_QUANTITY"))
        Dim prNew_Qty As Double = InQty * prUNIT_BASE_QUANTITY
        Dim dQty_Diff As Integer = InQty - dCurrent_Qty
        Dim iAsset_Account_ID As Integer = 0
        Dim i_Asset_Value As Double = 0
        Dim i_DEFFERENCE_VALUE As Double = 0

        Dim dCOST As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select * from item where id = '" & prItem_ID & "' limit 1")
            If rd.Read() Then
                dCOST = NumIsNull(rd("COST"))
                iAsset_Account_ID = NumIsNull(rd("ASSET_ACCOUNT_ID"))
                If prNew_Value <> 0 Then
                    i_DEFFERENCE_VALUE = (dCOST * dQty_Diff) - (prNew_Value * dQty_Diff)
                    i_Asset_Value = prNew_Value * prNew_Qty
                Else
                    i_DEFFERENCE_VALUE = 0
                    i_Asset_Value = dCOST * prNew_Qty
                End If

                If prAdd = True Then
                    dgvItem.Rows.Add("N", prItem_ID, TextIsNull(rd("CODE")), TextIsNull(rd("DESCRIPTION")), prUNIT_ID, Unit_Name, dCurrent_Qty, prNew_Qty, dQty_Diff, dCOST, prNew_Value, i_Asset_Value, iAsset_Account_ID, prUNIT_BASE_QUANTITY, prControl_Status, i_DEFFERENCE_VALUE, prBATCH_ID, Batch_NO)
                Else
                    Dim i As Integer = dgvItem.CurrentRow.Index
                    With dgvItem.Rows(i)
                        .Cells(1).Value = prItem_ID
                        .Cells(2).Value = TextIsNull(rd("CODE"))
                        .Cells(3).Value = TextIsNull(rd("DESCRIPTION"))
                        .Cells(4).Value = prUNIT_ID
                        .Cells(5).Value = Unit_Name
                        .Cells(6).Value = dCurrent_Qty
                        .Cells(7).Value = prNew_Qty
                        .Cells(8).Value = dQty_Diff
                        .Cells(9).Value = dCOST
                        .Cells(10).Value = prNew_Value
                        .Cells(11).Value = i_Asset_Value
                        .Cells(12).Value = iAsset_Account_ID
                        .Cells(13).Value = prUNIT_BASE_QUANTITY
                        If Val(.Cells(0).Value) = 0 Then
                            .Cells(14).Value = "A"
                        Else
                            .Cells(14).Value = prControl_Status
                        End If
                        .Cells(15).Value = i_DEFFERENCE_VALUE
                        .Cells(16).Value = prBATCH_ID
                        .Cells(17).Value = Batch_NO
                    End With
                End If
            End If
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
End Module
