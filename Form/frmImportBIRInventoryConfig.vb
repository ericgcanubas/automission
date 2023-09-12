Public Class FrmImportBIRInventoryConfig
    Public FirstLoad As Boolean = True

    Private Sub FrmImportBIRInventoryConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadDefault()
    End Sub
    Private Sub LoadDefault()
        Dim SQL As String
        If FirstLoad = True Then
            SQL = "select * from ImportBIRConfig  Where UseDefault = '1'"
        Else
            SQL = $"select * from ImportBIRConfig  Where id = {xnumID.Value}"

        End If

        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection())
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader(SQL, cn)
            If rd.Read Then
                xnumID.Value = NumIsNull(rd("ID"))
                txtSheetName.Text = TextIsNull(rd("SheetName"))
                txtProductCode.Text = TextIsNull(rd("ProductCode"))
                txtProductDescription.Text = TextIsNull(rd("ProductDescription"))
                txtUnitCost.Text = TextIsNull(rd("UnitCost"))
                txtQuantity.Text = TextIsNull(rd("Quantity"))
                txtMOU.Text = TextIsNull(rd("MOU"))
                chkUseDefault.Checked = NumIsNull(rd("UseDefault"))

            Else
                txtSheetName.Clear()
                txtProductCode.Clear()
                txtProductDescription.Clear()
                txtUnitCost.Clear()
                txtQuantity.Clear()
                txtMOU.Clear()
                chkUseDefault.Checked = False
            End If
            cn.Close()
        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        FirstLoad = False
    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim cn As New OleDb.OleDbConnection(DbAccessStringConnection())
        Try
            cn.Open()
            Dim rd As OleDb.OleDbDataReader = DbAccessReader($"select * from ImportBIRConfig  Where ID = {xnumID.Value} ", cn)
            If rd.Read Then
                cn.Close()
                DbAccessExecute($"UPDATE ImportBIRConfig SET SheetName='{txtSheetName.Text}',ProductCode='{txtProductCode.Text}',ProductDescription='{txtProductDescription.Text}',UnitCost='{txtUnitCost.Text}',Quantity='{txtQuantity.Text}',MOU='{txtMOU.Text}',UseDefault='{Val(chkUseDefault.Checked)}' Where ID ={xnumID.Value}")
                MessageBoxInfo("Successfully Update")
            Else
                cn.Close()

                If MessageBoxQuestion("New import setting do you want to save?") = True Then
                    DbAccessExecute($"INSERT INTO ImportBIRConfig  (SheetName,ProductCode,ProductDescription,UnitCost,Quantity,MOU,UseDefault) values('{txtSheetName.Text}','{txtProductCode.Text}','{txtProductDescription.Text}','{txtUnitCost.Text}','{txtQuantity.Text}','{txtMOU.Text}','{Val(chkUseDefault.Checked)}') ")
                    MessageBoxInfo("Successfully Added")
                End If
            End If


        Catch ex As Exception
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
        LoadDefault()
    End Sub

    Private Sub XnumID_ValueChanged(sender As Object, e As EventArgs) Handles xnumID.ValueChanged
        LoadDefault()
    End Sub
End Class