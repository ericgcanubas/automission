Imports System.Data.Odbc
Module modCreditLimit
    Public Sub GS_GotCreditLimitLineStatus(ByVal prLoc_ID As String, ByVal prCustomer_ID As String, ByRef prCL As Double, ByRef prBALANCE_DUE As Double)
        Dim sQuery As String = "SELECT   c.ACCOUNT_NO,'" & prLoc_ID & "'  AS `loc_id` ,IFNULL( c.`CREDIT_LIMIT`,0) AS `CL`,(
  (SELECT 
   IFNULL(SUM(i.`AMOUNT`),0)
  FROM
    invoice AS i 
    WHERE
       c.`ID` = i.`CUSTOMER_ID` AND i.location_id = loc_id
        
)
-
  ((SELECT 
 IFNULL(SUM(cr.`AMOUNT`),0)
  FROM
    credit_memo AS cr 
 WHERE
       c.`ID` = cr.`CUSTOMER_ID` AND cr.location_id = loc_id
)
+
  (SELECT 
    IFNULL( SUM( pn.`AMOUNT_APPLIED`),0) +  IFNULL(SUM(pn.`DISCOUNT`),0)
     AS `AMOUNT` 
  FROM
    payment_invoices AS pn 
    INNER JOIN payment AS p 
      ON p.ID = pn.PAYMENT_ID 

      WHERE  c.`ID` = p.`CUSTOMER_ID` AND p.location_id = loc_id

)+(  SELECT 
    IFNULL(SUM(tc.`AMOUNT_WITHHELD`),0) AS `AMOUNT` 
  FROM
    tax_credit_invoices AS tc 
    INNER JOIN tax_credit AS t 
      ON t.ID = tc.tax_Credit_ID 
   WHERE
       c.`ID` = t.`CUSTOMER_ID` AND t.location_id = loc_id
))
) AS BALANCE_DUE,c.`NAME`,cm.`DESCRIPTION` AS `Type`,c.ID AS  `CONTACT_ID`
FROM contact AS c
INNER JOIN contact_type_map AS cm ON c.`TYPE` = cm.`ID`
 WHERE c.`TYPE` IN('1','5','6')  AND c.credit_limit > 0  AND c.`ID` ='" & prCustomer_ID & "' limit 1"

        Try

            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                prCL = GF_NumIsNull(rd("CL"))
                prBALANCE_DUE = GF_NumIsNull(rd("BALANCE_DUE"))

            Else
                prCL = 0
                prBALANCE_DUE = 0
            End If

            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
End Module
