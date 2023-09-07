Imports System.Data.Odbc
Public Class FrmSalesTaxRecompute
    Private Sub FrmSalesTaxRecompute_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBoxLoad(cmbITEM_ID, "select ID,DESCRIPTION from ITEM  Where TYPE ='0' and INACTIVE='0' ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbLOCATION_ID, "select ID,NAME from location ", "ID", "NAME")

        cmbLOCATION_ID.SelectedValue = gsDefault_LOCATION_ID

    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Dim SQL As String
        If cmbITEM_ID.SelectedIndex = -1 Then
            MessageBoxInfo("Please select item")
            Exit Sub
        End If

        Dim rd As OdbcDataReader = SqlReader($"select * from item where id = '{cmbITEM_ID.SelectedValue}' limit 1")

        If rd.Read Then

            If dtpUseDate.Checked = False Then
                SQL = $"select sri.`ID`,sri.`AMOUNT`,sri.`TAXABLE`,sri.`TAXABLE_AMOUNT`,sri.`TAX_AMOUNT`,sri.`SALES_RECEIPT_ID`,sr.`OUTPUT_TAX_ID`,sr.`OUTPUT_TAX_ACCOUNT_ID`,sr.`OUTPUT_TAX_AMOUNT`,sr.`OUTPUT_TAX_RATE`,sr.`POS_LOG_ID`,sr.`DATE`,sri.INCOME_ACCOUNT_ID,sr.CUSTOMER_ID  from sales_receipt_items as sri inner join sales_receipt as sr on sr.id = sri.sales_receipt_id Where sri.`ITEM_ID`= '{cmbITEM_ID.SelectedValue}' and sr.`LOCATION_ID`  = '{cmbLOCATION_ID.SelectedValue}' "
            Else
                SQL = $"select sri.`ID`,sri.`AMOUNT`,sri.`TAXABLE`,sri.`TAXABLE_AMOUNT`,sri.`TAX_AMOUNT`,sri.`SALES_RECEIPT_ID`,sr.`OUTPUT_TAX_ID`,sr.`OUTPUT_TAX_ACCOUNT_ID`,sr.`OUTPUT_TAX_AMOUNT`,sr.`OUTPUT_TAX_RATE`,sr.`POS_LOG_ID`,sr.`DATE`,sri.INCOME_ACCOUNT_ID,sr.CUSTOMER_ID  from sales_receipt_items as sri inner join sales_receipt as sr on sr.id = sri.sales_receipt_id Where sri.`ITEM_ID`= '{cmbITEM_ID.SelectedValue}' and sr.`LOCATION_ID`  = '{cmbLOCATION_ID.SelectedValue}' and sr.DATE >='{DateFormatMySql(dtpUseDate.Value)}' "
            End If
            Dim Run As Integer = 0
            Dim Count As Integer

            Dim r As OdbcDataReader = ReaderCounting(SQL, Count)
            pbListofTransaction.Minimum = 0
            pbListofTransaction.Maximum = Count
            lblSTATUS.Text = $"0/{Count}"
            While r.Read

                Dim Out_put_Value As Double = 0
                Dim Item_amt_Value As Double = 0
                'Change SalesReceipt Item ================ GET ITEM
                Item_amt_Value = fUpdateSalesReceiptItem(NumIsNull(r("ID")), NumIsNull(r("AMOUNT")), NumIsNull(rd("TAXABLE")), NumIsNull(r("OUTPUT_TAX_ID")))
                'Change SalesReceipt ====================== GET TAX

                Out_put_Value = UpdateSalesReceiptOnly(r("SALES_RECEIPT_ID"))
                'Change Journal ===========================
                'Two Piece

                'ITEM
                SqlExecuted($"UPDATE account_journal SET AMOUNT='{Item_amt_Value}' WHERE OBJECT_TYPE = '53' and OBJECT_ID = '{r("ID")}' and ACCOUNT_ID = '{r("INCOME_ACCOUNT_ID")}' and SUBSIDIARY_ID ='{r("CUSTOMER_ID")}' and LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}' and `OBJECT_DATE` = '{DateFormatMySql(r("DATE"))}' limit 1; ")
                'TAX
                SqlExecuted($"UPDATE account_journal SET AMOUNT='{Out_put_Value}' WHERE OBJECT_TYPE = '52' and OBJECT_ID = '{r("SALES_RECEIPT_ID")}' and ACCOUNT_ID = '28' and SUBSIDIARY_ID ='{r("CUSTOMER_ID")}' and LOCATION_ID = '{cmbLOCATION_ID.SelectedValue}' and `OBJECT_DATE` = '{DateFormatMySql(r("DATE"))}' limit 1; ")

                'Change POS_LOG

                fPOS_LOG_TAX_UPDATE(r("POS_LOG_ID"))

                Run = Run + 1
                pbListofTransaction.Value = Run
                lblSTATUS.Text = $"{Run}/{Count}"
                fDoEvents()
            End While

        Else

            MessageBoxInfo("Item not found.")
        End If
    End Sub
    Private Sub fPOS_LOG_TAX_UPDATE(ByVal POS_LOG_ID As Integer)

        Dim SQL As String = $"SELECT SUM(s.`TAXABLE_AMOUNT`) AS `TAXABLE_AMOUNT`,SUM(s.`TAX_AMOUNT`) AS `TAX_AMOUNT`,SUM(IF(s.`TAXABLE` = 0,s.AMOUNT,0)) AS NON_TAXABLE_AMOUNT FROM sales_receipt_items AS s INNER JOIN item AS i ON i.`ID` = s.`ITEM_ID` INNER JOIN sales_receipt AS r ON r.`ID` = s.`SALES_RECEIPT_ID` WHERE  i.`TYPE` <> '6' AND r.`POS_LOG_ID` = '{POS_LOG_ID}'"

        Dim rd As OdbcDataReader = SqlReader(SQL)
        If rd.Read Then
            SqlExecuted($"UPDATE pos_log SET TAXABLE_AMOUNT ='{ NumIsNull(rd("TAXABLE_AMOUNT"))}',OUTPUT_TAX_AMOUNT='{ NumIsNull(rd("TAX_AMOUNT"))}',NONTAXABLE_AMOUNT='{ NumIsNull(rd("NON_TAXABLE_AMOUNT"))}'   WHERE ID = '{POS_LOG_ID}' limit 1; ")
        End If
        rd.Close()
    End Sub
    Private Function fUpdateSalesReceiptItem(ByVal ID As Integer, ByVal AMT As Double, ByVal prTaxable As Boolean, ByVal Tax_Type As Integer) As Double
        Dim Taxable_Amount As Double = 0
        Dim Tax_Amount As Double = 0

        Dim Return_value As Double = 0
        If prTaxable = True Then
            Dim dVat As Double = 0
            'add tax
            '  dVat = GetNumberFieldValue("TAX", "ID", TextIsNull(prTax_Type.SelectedValue), "RATE")
            dVat = fTax_Rate_Find(NumIsNull(Tax_Type))
            Tax_Amount = (dVat / 100) * AMT
            Taxable_Amount = Tax_Amount + AMT
            If Tax_Type = 12 Then
                'inclusive only
                Dim t As Double = (100 / 112)
                Tax_Amount = t * Tax_Amount
                AMT = AMT - Tax_Amount
                Taxable_Amount = AMT
                Return_value = AMT
            ElseIf Tax_Type = 13 Then
                Taxable_Amount = AMT
                Return_value = AMT

            Else
                Return_value = AMT
            End If
        Else
            Return_value = AMT
        End If

        SqlExecuted($"UPDATE sales_receipt_items set TAXABLE='{Val(prTaxable)}',TAXABLE_AMOUNT ='{ NumberFormatFixed(Taxable_Amount)}', TAX_AMOUNT = '{NumberFormatFixed(Tax_Amount)}'  WHERE id = '{ID}' limit 1;")

        Return AMT
    End Function

    Private Function UpdateSalesReceiptOnly(ByVal ID As Integer) As Double
        Dim OUT_PUT_TAX As Double = 0
        Dim SQL As String = $"select sum(s.`TAXABLE_AMOUNT`) as `TAXABLE_AMOUNT`,sum(s.`TAX_AMOUNT`) as `TAX_AMOUNT`,sum(if(s.`TAXABLE` = 0,s.AMOUNT,0)) as NON_TAXABLE_AMOUNT from sales_receipt_items as s inner join item as i on i.`ID` = s.`ITEM_ID` where  i.`TYPE` <> '6' and s.`SALES_RECEIPT_ID` =  '{ID}'"

        Dim rd As OdbcDataReader = SqlReader(SQL)
        If rd.Read Then

            SqlExecuted($"UPDATE sales_receipt SET OUTPUT_TAX_AMOUNT ='{ NumIsNull(rd("TAX_AMOUNT"))}',TAXABLE_AMOUNT ='{ NumIsNull(rd("TAXABLE_AMOUNT"))}',NONTAXABLE_AMOUNT='{ NumIsNull(rd("NON_TAXABLE_AMOUNT"))}' WHERE ID = '{ID}' limit 1;")
            OUT_PUT_TAX = NumIsNull(rd("TAX_AMOUNT"))
        End If
        rd.Close()

        Return OUT_PUT_TAX

    End Function



End Class