Imports System.Data.Odbc
Module modJournalAccountTrans


    Public Sub JA_SalesReceipt(ByVal ID As Integer)

        Dim rd As OdbcDataReader = SqlReader($"Select ID,DATE,LOCATION_ID,UNDEPOSITED_FUNDS_ACCOUNT_ID,AMOUNT,OUTPUT_TAX_AMOUNT,OUTPUT_TAX_ACCOUNT_ID,CUSTOMER_ID from sales_receipt where ID ='{ID}' limit 1 ")

        If rd.Read Then

        End If
        Dim rd_item As OdbcDataReader = SqlReader($"select i.ID,i.ITEM_ID,i.COGS_ACCOUNT_ID,i.ASSET_ACCOUNT_ID,i.INCOME_ACCOUNT_ID,i.RATE,i.AMOUNT,t.`TYPE`,i.`QUANTITY`,i.UNIT_BASE_QUANTITY,i.TAXABLE_AMOUNT,i.TAXABLE,i.TAX_AMOUNT from sales_receipt_items as i inner join item as t on i.ITEM_ID = t.ID where  t.`TYPE` in ('0','1','2','3','4','7') and i.SALES_RECEIPT_ID='{ID}' order by i.ACCOUNT_ID,i.COGS_ACCOUNT_ID,i.INCOME_ACCOUNT_ID ")
        While rd_item.Read

        End While



    End Sub
End Module
