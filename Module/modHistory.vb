Imports System.Data.Odbc
Module modHistory


    Public Sub fHistoryList(ByVal prID As String, ByVal f As Form)
        Dim sQuery As String = ""
        If f.Name = "frmInvoice" Then
            'invoice
            sQuery = $"SELECT 
  * 
FROM
  (
    (SELECT 
      p.`ID`,
      '{gsTextReceivePayment}' AS `Type`,
      p.`DATE` AS `Date`,
      p.`CODE` AS `Reference No.`,
      pv.`AMOUNT_APPLIED` AS `Amount`,
      pv.`INVOICE_ID` 
    FROM
      payment_invoices AS pv 
      INNER JOIN payment AS p 
        ON pv.`PAYMENT_ID` = p.`ID`) 
    UNION
    (SELECT 
      c.`ID`,
      '{gsTextCreditMemo}' AS `Type`,
      c.`DATE` AS `Date`,
      c.`CODE` AS `Reference No.`,
      ci.`AMOUNT_APPLIED` AS `Amount`,
      ci.`INVOICE_ID` 
    FROM
      credit_memo_invoices AS ci 
      INNER JOIN credit_memo AS c 
        ON ci.`CREDIT_MEMO_ID` = c.`ID`) 
    UNION
    (SELECT 
      t.`ID`,
      '{gsTextTaxCredit}' AS `Type`,
      t.`DATE` AS `Date`,
      t.`CODE` AS `Reference No.`,
      ti.AMOUNT_WITHHELD AS `Amount`,
      ti.INVOICE_ID 
    FROM
      tax_credit_invoices AS ti 
      INNER JOIN tax_credit AS t 
        ON ti.tax_credit_id = t.`ID`) 
    UNION
    (SELECT 
      s.ID,
      '{gsTextSalesOrder}' AS `Type`,
      s.`DATE` AS `Date`,
      s.`CODE` AS `Reference No.`,
      s.`Amount`,
      ix.INVOICE_ID 
    FROM
      sales_order_items AS z 
      INNER JOIN sales_order AS s 
        ON s.ID = z.SALES_ORDER_ID 
      INNER JOIN invoice_items AS ix 
        ON ix.REF_LINE_ID = z.ID 
   GROUP BY s.ID )
  ) AS i WHERE i.INVOICE_ID = '" & prID & "' ORDER BY i.`Date`"

        ElseIf f.Name = "frmBills" Then
            sQuery = $"SELECT * FROM 
      ((SELECT  p.`ID`,'{gsTextBillPayment}' AS `Type`,p.`DATE` AS `Date`,p.`CODE` AS `Reference No.`,pv.`AMOUNT_PAID` AS `Amount`,pv.`BILL_ID`  FROM `check_bills` AS pv INNER JOIN  `Check` AS p ON pv.`CHECK_ID` = p.`ID`)
UNION (SELECT  c.`ID`,'{gsTextBillCredit}' AS `Type`,c.`DATE` AS `Date`,c.`CODE` AS `Reference No.`,ci.`AMOUNT_APPLIED` AS `Amount`,ci.`BILL_ID`   FROM bill_credit_bills AS ci INNER JOIN  bill_credit AS c ON ci.bill_credit_ID = c.`ID`)
UNION (SELECT  t.`ID`,'{gsTextWithholdingTax}' AS `Type`,t.`DATE` AS `Date`,t.`CODE` AS `Reference No.`,ti.AMOUNT_WITHHELD AS `Amount`,ti.`BILL_ID`   FROM `withholding_tax_bills` AS ti INNER JOIN  `withholding_tax` AS t ON ti.withholding_tax_ID = t.`ID`)
UNION (SELECT s.ID,
'{gsTextPurchaseOrder}' AS `Type`,
s.`DATE` AS `Date`,
s.CODE AS `Reference No.`,
s.`Amount`,
ix.BILL_ID 
FROM purchase_order_items AS z 
INNER JOIN purchase_Order AS s 
  ON s.ID = z.PO_ID 
INNER JOIN bill_items AS ix 
  ON ix.PO_ITEM_ID = z.ID GROUP BY s.ID
)
) AS i WHERE i.BILL_ID = '" & prID & "' ORDER BY i.`Date`"

        ElseIf f.Name = "frmEstimate" Then
            sQuery = $"SELECT * FROM
  (  (SELECT 
      s.ID,
      '{gsTextSalesOrder}' AS `Type`,
      s.`DATE` AS `Date`,
      s.`CODE` AS `Reference No.`,
      s.`Amount`,
      ix.Estimate_ID 
    FROM
      sales_order_items AS z 
      INNER JOIN sales_order AS s 
        ON s.ID = z.SALES_ORDER_ID 
      INNER JOIN estimate_items AS ix 
        ON ix.ID = z.ESTIMATE_LINE_ID 
   GROUP BY s.ID )

) AS s 
WHERE s.Estimate_ID = '" & prID & "' 
ORDER BY s.`Date` "
        ElseIf f.Name = "frmSalesOrder" Then
            sQuery = $"SELECT * FROM
  ( (SELECT i.ID,'{gsTextInvoice}' AS `Type`,i.`DATE` AS `Date`,i.`CODE` AS `Reference No.`, i.`AMOUNT`,so.`SALES_ORDER_ID` FROM invoice AS i INNER JOIN invoice_items AS ii ON ii.`INVOICE_ID` = i.`ID` INNER JOIN sales_order_items AS so ON so.ID = ii.`REF_LINE_ID`  GROUP BY i.ID
    )
UNION
(SELECT i.ID,'{gsTextEstimate}' AS `Type`,i.`DATE` AS `Date`,i.`CODE` AS `Reference No.`, i.`AMOUNT`,so.`SALES_ORDER_ID` FROM estimate AS i INNER JOIN estimate_items AS ii ON ii.`estimate_id` = i.`ID` INNER JOIN sales_order_items AS so ON so.ESTIMATE_LINE_ID = ii.ID  GROUP BY i.ID
    )

) AS s 
WHERE s.SALES_ORDER_ID = '" & prID & "' 
ORDER BY s.`Date` "

        ElseIf f.Name = "frmReceivePayment" Then
            sQuery = $"SELECT 
  * 
FROM
  (
    (SELECT 
      i.ID,
      '{gsTextInvoice}' AS `Type`,
      i.`Date`,
      i.`Code` AS `Reference NO.`,
      i.`Amount`,
      p.PAYMENT_ID 
    FROM
      invoice AS i 
      INNER JOIN payment_invoices AS p 
        ON p.`INVOICE_ID` = i.`ID`) 
    UNION
    
(SELECT 
      t.ID,
      '{gsTextDeposit}' AS `Type`,
      t.`Date`,
      t.Code AS `Reference No.`,
      t.Amount,
      p.ID AS `PAYMENT_ID` 
    FROM
      deposit_funds AS d 
      INNER JOIN deposit AS t 
        ON t.ID = d.DEPOSIT_ID 
      INNER JOIN payment AS p 
        ON p.ID = d.SOURCE_OBJECT_ID 
        AND d.SOURCE_OBJECT_TYPE = '41' GROUP BY t.ID)
  ) AS s 
WHERE s.PAYMENT_ID = '" & prID & "' 
ORDER BY s.`Date`"

        ElseIf f.Name = "frmCreditMemo" Then
            sQuery = $"SELECT 
*
FROM
  (SELECT  i.ID,
  '{gsTextInvoice}' AS `Type`,
  i.`Date`,
  i.`Code` AS `Reference NO.`,
  i.`Amount`,
  p.`CREDIT_MEMO_ID` 
    FROM invoice AS i INNER JOIN credit_memo_invoices AS p ON p.`INVOICE_ID` = i.`ID` 
    ) AS s 
WHERE s.CREDIT_MEMO_ID = '" & prID & "' 
ORDER BY s.`Date` "

        ElseIf f.Name = "frmSalesReceipt" Then
            sQuery = $"SELECT 
  * 
FROM
  (
(SELECT 
      t.ID,
      '{gsTextDeposit}' AS `Type`,
      t.`Date`,
      t.Code AS `Reference No.`,
      t.Amount,
      p.ID as `SALES_RECEIPT_ID` 
    FROM
      deposit_funds AS d 
      INNER JOIN deposit AS t 
        ON t.ID = d.DEPOSIT_ID 
      INNER JOIN Sales_Receipt AS p 
        ON p.ID = d.SOURCE_OBJECT_ID 
        AND d.SOURCE_OBJECT_TYPE = '52' GROUP BY t.ID)
  ) AS s 
WHERE s.SALES_RECEIPT_ID = '" & prID & "' 
ORDER BY s.`Date` "
        ElseIf f.Name = "frmTaxCredit" Then
            'TAX CREDIT
            sQuery = $"SELECT 
  * 
FROM
  (SELECT 
    i.`ID`,
    '{gsTextInvoice}' AS `Type`,
    i.Date,
    i.`CODE` AS `Reference No.`,
    i.`Amount`,
    t.`TAX_CREDIT_ID` 
  FROM
    invoice AS i 
    INNER JOIN tax_credit_invoices AS t 
      ON t.`INVOICE_ID` = i.`ID` GROUP BY i.`ID` ) AS s 
WHERE s.TAX_CREDIT_ID ='" & prID & "'
 ORDER BY s.Date"

        ElseIf f.Name = "frmPurchaseOrder" Then
            'PURCHASE ORDER
            sQuery = $"SELECT * FROM (SELECT 
  b.ID,
  '{gsTextBills}' AS `Type`,
  b.`Date`,
  b.`CODE` AS `Reference No.`,
  b.`Amount`,
  po.`PO_ID` 
FROM
  bill AS b 
  INNER JOIN bill_items AS bi 
    ON bi.`BILL_ID` = b.`ID` 
  INNER JOIN purchase_order_items AS po 
    ON bi.`PO_ITEM_ID` = po.`ID` 
GROUP BY b.ID) AS s
WHERE s.PO_ID ='" & prID & "'
ORDER BY s.Date"
        ElseIf f.Name = "frmPurchaseRequest" Then
            'PURCHASE ORDER
            sQuery = $"SELECT 
  b.ID,
  '{gsTextPurchaseOrder}r' AS `Type`,
  b.`Date`,
  b.`CODE` AS `Reference No.`,
  c.`Name` as `Vendor`,
  b.`Amount`

FROM
  purchase_order AS b 
inner join contact as c
on c.ID = b.vendor_id
WHERE b.PR_ID ='" & prID & "'
ORDER BY b.Date"
        ElseIf f.Name = "frmBillPayment" Then
            'BILL PAYMENT
            sQuery = $"SELECT 
  * 
FROM
  (SELECT 
    b.ID,
    '{gsTextBills}' AS `Type`,
    b.`Date`,
    b.`CODE` AS `Reference No.`,
    b.`Amount`,
    c.`CHECK_ID` 
  FROM
    bill AS b 
    INNER JOIN check_bills AS c  
      ON c.`BILL_ID` = b.`ID` group by b.ID) AS s 
WHERE s.CHECK_ID ='" & prID & "' 
ORDER BY s.Date "

        ElseIf f.Name = "frmBillCredit" Then
            sQuery = $"SELECT 
  * 
FROM
  (SELECT 
    b.ID,
    '{gsTextBills}' AS `Type`,
    b.`Date`,
    b.`CODE` AS `Reference No.`,
    b.`Amount`,
    c.BILL_CREDIT_ID 
  FROM
    bill AS b 
    INNER JOIN bill_credit_bills AS c  
      ON c.`BILL_ID` = b.`ID` group by b.ID) AS s 
WHERE s.BILL_CREDIT_ID = '" & prID & "' 
ORDER BY s.Date "
        ElseIf f.Name = "frmWithholdingTax" Then
            sQuery = $"SELECT * FROM
  (SELECT 
    i.`ID`,
    '{gsTextBills}' AS `Type`,
    i.Date,
    i.`CODE` AS `Reference No.`,
    i.`Amount`,
    t.`WITHHOLDING_TAX_ID`
  FROM
    bill AS i 
    INNER JOIN withholding_tax_bills AS t 
      ON t.`BILL_ID` = i.`ID` GROUP BY i.`ID` ) AS s 
WHERE s.WITHHOLDING_TAX_ID ='" & prID & "'
 ORDER BY s.Date"
        ElseIf f.Name = "frmDeposit" Then

            sQuery = $"SELECT * FROM (
(SELECT o.ID,'{gsTextSalesReceipt}' AS `Type`,o.Date,o.`CODE` AS `Reference No.`,o.`Amount`,d.`DEPOSIT_ID` FROM sales_Receipt AS o INNER JOIN deposit_funds AS d ON d.`SOURCE_OBJECT_ID` = o.`ID` AND d.`SOURCE_OBJECT_TYPE` = '52' GROUP BY o.`ID`)  UNION
(SELECT p.ID,'{gsTextReceivePayment}' AS `Type`,p.Date,p.`CODE` AS `Reference No.`,p.`Amount`,d.`DEPOSIT_ID` FROM payment AS p  INNER JOIN payment_invoices AS o ON p.ID = o.payment_ID INNER JOIN deposit_funds AS d ON d.`SOURCE_OBJECT_ID` = p.`ID` AND d.`SOURCE_OBJECT_TYPE` = '41' GROUP BY o.`ID`) ) AS s 
WHERE s.DEPOSIT_ID ='" & prID & "'
 ORDER BY s.Date"
        ElseIf f.Name = "frmWriteCheck" Then


        End If

        fHistorySQL(sQuery)
    End Sub
    Private Sub fHistorySQL(ByVal prQuery As String)
        If prQuery = "" Then
            Exit Sub
        End If
        frmHistory.gsQuery = prQuery
        frmHistory.ShowDialog()
        With frmHistory
            If .gsSelect = True Then
                fSelected_History(.dgvDocument, .gsType, .gsID)
            End If
        End With

        frmHistory.Dispose()
        frmHistory = Nothing

    End Sub
    Private Sub fSelected_History(ByVal dgv As DataGridView, ByVal prType As String, ByVal prID As String)
        If dgv.Rows.Count = 0 Then Exit Sub

        Dim sType As String = prType
        Dim i As Integer = NumIsNull(GetNumberFieldValue("tblsub_menu", "Description", sType, "sub_id"))
        gsMenuSubID = i
        gsRefresh = True
        gsDocument_Finder_ID = prID ' dgv.Rows(dgv.CurrentRow.Index).Cells(dgv.Columns.Count - 1).Value


        '= New Set
        Dim rd As OdbcDataReader = SqlReader($"select * from `tblsub_menu` where sub_id = '{gsMenuSubID}' limit 1")
        Dim F As Form = Nothing
        Dim Img As Image = Nothing
        If rd.Read Then
            i = NumIsNull(rd("sub_id"))
            F = GetFormModule(rd("Form"))
            Dim folder As String = $"{New Uri(CurrentPath).LocalPath}\image\sub\"
            Img = Image.FromFile(folder & rd("image_file"))
            gsSubMenuForm = rd("description")
            F.Text = rd("description")
            F.Tag = i
        End If

        For n As Integer = 0 To frmMainMenu.MyTab.TabPages.Count - 1
            Dim Frm As Form = frmMainMenu.MyTab.TabPages.Item(n).Form
            If Frm.Text = F.Text Then
                Frm.Close()
                Exit For
            End If
        Next
        gsMenuSubID = i
        gsRefresh = True

        TabFormOpen(F, frmMainMenu.MyTab, Img)
        F.TabIndex = gsDocument_Finder_ID
        gsDocument_Finder_ID = 0



    End Sub
End Module
