Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Public Class FrmImportBIRInventory
    Dim SheetName As String

    Dim col_code As String
    Dim col_desc As String
    Dim col_UnitCost As String
    Dim col_Quantity As String
    Dim col_MOU As String

    Dim row_code As Integer
    Dim row_desc As Integer
    Dim row_UnitCost As Integer
    Dim row_Quantity As Integer
    Dim row_MOU As Integer

    Dim Get_code_value As String
    Dim Get_desc_value As String
    Dim Get_Unit_Cost_value As Double
    Dim Get_Qty_value As Integer
    Dim Get_MOU_value As String

    Dim CantRun As Boolean = True

    Private Sub BtnBrowseFIle_Click(sender As Object, e As EventArgs) Handles btnBrowseFIle.Click
        OpenFileDialog1.Title = "Please Select Excel file"
        OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
        Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        If result = DialogResult.OK Then

            txtPath.Text = OpenFileDialog1.FileName
        End If

    End Sub
    Private Sub LoadDefault()
        Dim SQL As String
        CantRun = False
        SQL = "select * from ImportBIRConfig  Where UseDefault = '-1'"
        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection())
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader(SQL, cn)
            If rd.Read Then


                SheetName = GF_TextIsNull(rd("SheetName"))

                col_code = GetCol(GF_TextIsNull(rd("ProductCode")), True)
                row_code = Val(GetCol(GF_TextIsNull(rd("ProductCode")), False)) - 1

                col_desc = GetCol(GF_TextIsNull(rd("ProductDescription")), True)
                row_desc = Val(GetCol(GF_TextIsNull(rd("ProductDescription")), False)) - 1

                col_UnitCost = GetCol(GF_TextIsNull(rd("UnitCost")), True)
                row_UnitCost = Val(GetCol(GF_TextIsNull(rd("UnitCost")), False)) - 1

                col_Quantity = GetCol(GF_TextIsNull(rd("Quantity")), True)
                row_Quantity = Val(GetCol(GF_TextIsNull(rd("Quantity")), False)) - 1

                col_MOU = GetCol(GF_TextIsNull(rd("MOU")), True)
                row_MOU = Val(GetCol(GF_TextIsNull(rd("MOU")), False)) - 1

                CantRun = False

            Else
                CantRun = True
                MessageBoxExclamation("Configure not found.")
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            CantRun = True
        End Try

    End Sub
    Private Function GetCol(ByVal StrValue As String, ByVal IsChar As Boolean) As String
        Dim ReturnValue As String = ""
        If IsChar = True Then
            For I As Integer = 0 To StrValue.Length - 1
                If IsNumeric(StrValue.Substring(I, 1)) = False Then
                    ReturnValue &= StrValue.Substring(I, 1)
                End If
            Next
        Else
            For I As Integer = 0 To StrValue.Length - 1
                If IsNumeric(StrValue.Substring(I, 1)) = True Then
                    ReturnValue &= StrValue.Substring(I, 1)
                End If
            Next
        End If
        Return ReturnValue
    End Function

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        dgvCollectData.Rows.Clear()

        If txtPath.Text = "" Then
            MessageBoxWarning("File not found.")
            Exit Sub
        End If


        LoadDefault()

        If CantRun = True Then
            Exit Sub
        End If

        ' checking file
        If IO.File.Exists(txtPath.Text) = False Then
            MessageBoxWarning("The file doesn't exist")
            Exit Sub
        End If

        btnStart.Enabled = False
        ImportingData()
        If dgvCollectData.Rows.Count <> 0 Then
            btnChecking.Enabled = True
            btnChecking.PerformClick()

        End If




    End Sub
    Private Sub ImportingData()
        Try
            GS_CursorLoadingOn(True)
            Dim xlApp As Excel.Application
            Dim xlWorkBook As Excel.Workbook
            Dim xlWorkSheet As Excel.Worksheet
            Dim range As Excel.Range
            Dim rCnt As Integer
            'Dim cCnt As Integer
            'Dim Obj As Object



            xlApp = New Excel.Application
            xlWorkBook = xlApp.Workbooks.Open(txtPath.Text)
            xlWorkSheet = xlWorkBook.Worksheets(SheetName)

            range = xlWorkSheet.UsedRange

            'For rCnt = 1 To range.Rows.Count
            '    For cCnt = 1 To range.Columns.Count
            '        Obj = CType(range.Cells(rCnt, cCnt), Excel.Range)
            '        MsgBox(Obj.value)
            '    Next
            'Next
            pbStatus.Maximum = range.Rows.Count

            For rCnt = 1 To range.Rows.Count
                pbStatus.Value = rCnt
                lblSTATUS.Text = rCnt

                If row_code = rCnt Then

                    Get_code_value = CType(range.Cells(row_code, col_code), Excel.Range).Value
                    If Get_code_value = "" Then
                        Exit For
                    End If

                    row_code = rCnt + 1

                    Get_desc_value = CType(range.Cells(row_desc, col_desc), Excel.Range).Value
                    row_desc = rCnt + 1

                    Get_Unit_Cost_value = CType(range.Cells(row_UnitCost, col_UnitCost), Excel.Range).Value
                    row_UnitCost = rCnt + 1

                    Get_Qty_value = CType(range.Cells(row_Quantity, col_Quantity), Excel.Range).Value
                    row_Quantity = rCnt + 1

                    Get_MOU_value = CType(range.Cells(row_MOU, col_MOU), Excel.Range).Value
                    row_MOU = rCnt + 1

                    dgvCollectData.Rows.Add(Get_code_value, Get_desc_value.Replace("'", "`"), Get_Unit_Cost_value, Get_Qty_value, Get_MOU_value)

                End If

            Next
            pbStatus.Value = range.Rows.Count
            tssStatus.Text = "Data Collect :" & dgvCollectData.Rows.Count

            xlWorkBook.Save()
            xlWorkBook.Close()
            xlApp.Quit()

            ReleaseObject(xlApp)
            ReleaseObject(xlWorkBook)
            ReleaseObject(xlWorkSheet)
            GS_CursorLoadingOn(False)
            MessageBoxInfo("Import Complete.")
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                ImportingData()
            Else
                End
            End If
        End Try
    End Sub

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub BtnConfig_Click(sender As Object, e As EventArgs) Handles btnConfig.Click
        FrmImportBIRInventoryConfig.ShowDialog()
        FrmImportBIRInventoryConfig.Dispose()
        FrmImportBIRInventoryConfig = Nothing
    End Sub

    Private Sub BtnInventoryAdjustment_Click(sender As Object, e As EventArgs) Handles btnInventoryAdjustment.Click
        'Checking Item

        If dgvCollectData.Rows.Count = 0 Then
            MessageBoxExclamation("Data not found.")
            Exit Sub
        End If

        gsBIR_dgvImportBIRItemList = dgvCollectData

        FrmGotoInventoryAdjustment.ShowDialog()
        Dim okClick As Boolean = FrmGotoInventoryAdjustment.gsCLick
        FrmGotoInventoryAdjustment.Dispose()
        FrmGotoInventoryAdjustment = Nothing

        If okClick = True Then
            MessageBoxInfo("Transfer to Inventory adjustment Complete.")
            Me.Close()
        End If
    End Sub

    Private Sub BtnChecking_Click(sender As Object, e As EventArgs) Handles btnChecking.Click

        If dgvCollectData.Rows.Count = 0 Then
            MessageBoxInfo("Data not found.")

            Exit Sub

        End If
        btnChecking.Enabled = False
        GS_CursorLoadingOn(True)
        pbStatus.Value = 0
        pbStatus.Maximum = dgvCollectData.Rows.Count
        Dim StrItemSQL As String = ""
        Dim Count As Integer = 0
        For I As Integer = 0 To dgvCollectData.Rows.Count - 1
            lblSTATUS.Text = (I + 1)
            pbStatus.Value = (I + 1)
            With dgvCollectData.Rows(I)
                Dim rd As OdbcDataReader = SqlReader($"select `ID` from item where `code` = '{ .Cells("code").Value}' limit 1")
                If rd.Read Then
                    'Do nothing    
                Else
                    Count += 1
                    StrItemSQL &= CreateItem(dgvCollectData.Rows(I))
                End If
                rd.Close()
            End With
            GS_DoEvents()
        Next

        If StrItemSQL <> "" Then
            SqlExecuted(StrItemSQL)
            MessageBoxInfo($"{Count} = New item added. Checking Complete.")
        Else
            MessageBoxInfo("Checking Complete.")
        End If

        GS_CursorLoadingOn(False)
        btnInventoryAdjustment.Enabled = True
        btnInventoryAdjustment.PerformClick()

    End Sub
    Private Function CreateItem(ByVal dgvR As DataGridViewRow) As String
        Dim ID As Integer = ObjectTypeMapId("item")
        Return $"INSERT INTO `item` SET `ID`='{ID}',INACTIVE = '0',CODE = '{dgvR.Cells("CODE").Value}',TYPE = '0',BUNDLE_SET = '0',NON_PORFOLIO_COMPUTATION = '0',MANUFACTURER_ID = NULL,GL_ACCOUNT_ID = '37',PREFERRED_VENDOR_ID = NULL,TAXABLE = '1',COGS_ACCOUNT_ID = '47',RATE = NULL,COST = '{dgvR.Cells("COST").Value}',DESCRIPTION = '{dgvR.Cells("description").Value}',PURCHASE_DESCRIPTION = '{dgvR.Cells("description").Value}',ASSET_ACCOUNT_ID = '6',STOCK_TYPE = '0',BASE_UNIT_ID = '3',SHIPPING_UNIT_ID = NULL,SALES_UNIT_ID = NULL,PURCHASES_UNIT_ID = NULL,SUB_CLASS_ID = '29',GROUP_ID = '24',NOTES = '',RATE_TYPE = NULL,PAYMENT_METHOD_ID = NULL,PRINT_INDIVIDUAL_ITEMS = NULL,PICTURE = NULL,CUSTOM_FIELD1 = NULL,CUSTOM_FIELD2 = NULL,CUSTOM_FIELD3 = NULL,CUSTOM_FIELD4 = NULL,CUSTOM_FIELD5 = NULL;"

    End Function
End Class