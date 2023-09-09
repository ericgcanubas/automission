Imports System.Data.Odbc
Public Class FrmFindDocument
    Public firstLoad As Boolean = True
    Public gsSelected As Boolean = False
    Public gsGET_ID As String = ""
    Public item_BS As BindingSource

    Private Function SqlAllDocs() As String
        Dim DOC_INVOICE As String = $"SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextInvoice & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
 ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  invoice AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN account AS a
   ON a.`ID` = i.`ACCOUNTS_RECEIVABLE_ID`
   LEFT OUTER JOIN account_type_map AS atm
   ON atm.`ID` = a.`TYPE`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"


        Dim DOC_SALES_ORDER As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextSalesOrder & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  sales_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
   
  "

        Dim DOC_RECEIVED_PAYMENT As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextReceivePayment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
   ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  payment AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"


        Dim DOC_SALES_RECEIPT As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextSalesReceipt & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
   ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  sales_receipt AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = i.`PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_CREDIT_MEMO As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextCreditMemo & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
   ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  credit_memo AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_TAXCREDIT As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextTaxCredit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
   ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `tax_credit` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`customer_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_PO As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextPurchaseOrder & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
   ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
From
  purchase_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        '====

        Dim DOC_PR As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextPurchaseRequest & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
   ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
From
  purchase_request AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"


        '===
        Dim DOC_BILL As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextBills & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  bill AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
   "
        Dim DOC_BILL_CREDIT As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextBillCredit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
   ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
   ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  bill_credit AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
WHERE   i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_BILL_PAYMENT As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextBillPayment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull( c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.`Type` = '1' and i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"


        Dim DOC_WITH_HOLDING_TAX As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextWithholdingTax & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `withholding_tax` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`WITHHELD_FROM_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
"
        Dim DOC_STOCK_TRANSFER As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextStockTransfer & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.RETAIL_VALUE,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `stock_transfer` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PREPARED_BY_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
     WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"


        Dim DOC_STOCK_RECEIVED As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextStockReceived & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.RETAIL_VALUE,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `stock_received` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PREPARED_BY_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`TRANSFER_TO_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
     WHERE i.LOCATION_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_BUILD_ASSEMBLY As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextBuildAssembly & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 0.00 AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
      ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  build_assembly AS i 
  LEFT OUTER JOIN item AS c 
  ON c.`ID` = i.`ASSEMBLY_ITEM_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_INVENTORY_ADJUSTMENT As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextInventoryAdjustment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 0.00 AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     0.00 as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  inventory_adjustment AS i 
  LEFT OUTER JOIN inventory_adjustment_type AS c 
  ON c.`ID` = i.`ADJUSTMENT_TYPE_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_GENERAL_JOURNAL As String = "SELECT 
    i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextGeneralJournal & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  '' AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 0.00 AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
 ifNull((select ifNULL(sum(d.DEBIT),0) from General_Journal_details as d where d.General_Journal_ID = i.ID  and d.entry_type ='0'),0.00) as `Amount`,
 '' AS `Status`
FROM
  General_Journal AS i 
    LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim DOC_WRITECHECK As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextWriteCheck & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.`Type` = '0' and i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
"

        Dim DOC_DEPOSIT As String = "SELECT i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextDeposit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  a.`NAME` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 0.00 AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  '' AS `Status`
FROM
  Deposit AS i 
  LEFT OUTER JOIN account as a
   ON a.`ID` = i.`BANK_ACCOUNT_ID` 
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`LOCATION_ID` 
 WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
"

        Dim DOC_FUND_TRANSFER As String = "SELECT i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextFundTransfer & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 0.00 AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  '' AS `Status`
FROM
  Fund_Transfer AS i 
 LEFT OUTER JOIN contact as c
 ON c.ID = i.TO_NAME_ID
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`FROM_LOCATION_ID` 
 WHERE i.FROM_LOCATION_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'"

        Dim sALl_Document_SQL As String = ""


        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextInvoice) = True, IIf(sALl_Document_SQL = "", DOC_INVOICE, $" UNION {DOC_INVOICE}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextSalesOrder) = True, IIf(sALl_Document_SQL = "", DOC_SALES_ORDER, $" UNION {DOC_SALES_ORDER}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextSalesReceipt) = True, IIf(sALl_Document_SQL = "", DOC_SALES_RECEIPT, $" UNION {DOC_SALES_RECEIPT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextReceivePayment) = True, IIf(sALl_Document_SQL = "", DOC_RECEIVED_PAYMENT, $" UNION {DOC_RECEIVED_PAYMENT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextCreditMemo) = True, IIf(sALl_Document_SQL = "", DOC_CREDIT_MEMO, $" UNION {DOC_CREDIT_MEMO}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextTaxCredit) = True, IIf(sALl_Document_SQL = "", DOC_TAXCREDIT, $" UNION {DOC_TAXCREDIT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextPurchaseOrder) = True, IIf(sALl_Document_SQL = "", DOC_PO, $" UNION {DOC_PO}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextPurchaseRequest) = True, IIf(sALl_Document_SQL = "", DOC_PR, $" UNION {DOC_PR}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextStockReceived) = True, IIf(sALl_Document_SQL = "", DOC_STOCK_RECEIVED, $" UNION {DOC_STOCK_RECEIVED}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextBills) = True, IIf(sALl_Document_SQL = "", DOC_BILL, $" UNION {DOC_BILL}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextBillCredit) = True, IIf(sALl_Document_SQL = "", DOC_BILL_CREDIT, $" UNION {DOC_BILL_CREDIT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextBillPayment) = True, IIf(sALl_Document_SQL = "", DOC_BILL_PAYMENT, $" UNION {DOC_BILL_PAYMENT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextWithholdingTax) = True, IIf(sALl_Document_SQL = "", DOC_WITH_HOLDING_TAX, $" UNION {DOC_WITH_HOLDING_TAX}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextStockTransfer) = True, IIf(sALl_Document_SQL = "", DOC_STOCK_TRANSFER, $" UNION {DOC_STOCK_TRANSFER}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextBuildAssembly) = True, IIf(sALl_Document_SQL = "", DOC_BUILD_ASSEMBLY, $" UNION {DOC_BUILD_ASSEMBLY}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextInventoryAdjustment) = True, IIf(sALl_Document_SQL = "", DOC_INVENTORY_ADJUSTMENT, $" UNION {DOC_INVENTORY_ADJUSTMENT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextGeneralJournal) = True, IIf(sALl_Document_SQL = "", DOC_GENERAL_JOURNAL, $" UNION {DOC_GENERAL_JOURNAL}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextWriteCheck) = True, IIf(sALl_Document_SQL = "", DOC_WRITECHECK, $" UNION {DOC_WRITECHECK}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextDeposit) = True, IIf(sALl_Document_SQL = "", DOC_DEPOSIT, $" UNION {DOC_DEPOSIT}"), "")
        sALl_Document_SQL &= IIf(UserSecurtySystemDOCShow(gsTextFundTransfer) = True, IIf(sALl_Document_SQL = "", DOC_FUND_TRANSFER, $" UNION {DOC_FUND_TRANSFER}"), "")

        Return " SELECT * from ( " & sALl_Document_SQL & ") as x order by x.`Date` desc,x.`ID` desc "


    End Function


    Private Sub FrmFindDocument_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        Try
            If tscmbLocation.ComboBox.Items.Count = 0 Then

                RefreshLocation()
                Dim loc_value As String = gsDefault_LOCATION_ID
                tscmbLocation.ComboBox.SelectedValue = IIf(loc_value = "0", "%", loc_value)
                tscmbLocation.Enabled = IsLockLocation()
                RefreshMode()
                gsSelected = False
                firstLoad = False
                dgvDocument.ColumnHeadersHeight = 35
            End If
        Catch ex As Exception

        End Try

    End Sub
    Private Function RefreshCreditMemo() As String
        Dim sQuery_CreditMemo As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextCreditMemo & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull( c.`CREDIT_LIMIT`,0) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  sp.`NAME` AS `Sales Rep`,
  cl.`NAME`  AS `Class`,
  a.`NAME` AS `Account Name`,
  atm.`DESCRIPTION` AS `Account Type`,
  tx.`NAME` AS `Tax`,
  ttm.`DESCRIPTION` AS `Tax Type`,
  dsm.`DESCRIPTION` AS `Status`, 
  i.`STATUS_DATE`  AS `Status Date` 
FROM
  credit_memo AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN account AS a
   ON a.`ID` = i.`ACCOUNTS_RECEIVABLE_ID`
   LEFT OUTER JOIN account_type_map AS atm
   ON atm.`ID` = a.`TYPE`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`  
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC "
        Return sQuery_CreditMemo
    End Function
    Private Function RefreshPayment() As String
        Dim sQuery_invoice As String = " Select
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextReceivePayment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`, 
  i.`STATUS_DATE`  AS `Status Date` 
From
  payment As i 
  Left OUTER JOIN contact AS c 
    On c.`ID` = i.`CUSTOMER_ID` 
  Left OUTER JOIN payment_method AS pm 
    On pm.`ID` = i.`PAYMENT_METHOD_ID` 
  Left OUTER JOIN location AS l 
    On l.`ID` = i.`LOCATION_ID` 
   Left OUTER JOIN document_status_map AS dsm
   On dsm.`ID` = i.`STATUS`
  WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC  "
        Return sQuery_invoice
    End Function

    Private Function RefreshInvoice() As String
        Dim sQuery_invoice As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextInvoice & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull( c.`CREDIT_LIMIT`,0) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
   ifNull(i.AMOUNT,0.00) as `Amount`,
   ifNull(i.Balance_Due,0.00) as `Balance`,
  sp.`NAME` AS `Sales Rep`,
  cl.`NAME`  AS `Class`,
  pt.`DESCRIPTION` AS `Pmt Terms`,
  i.`DUE_DATE` AS `Due Date`,
  a.`NAME` AS `Account Name`,
  atm.`DESCRIPTION` AS `Account Type`,
  tx.`NAME` AS `Tax`,
  ttm.`DESCRIPTION` AS `Tax Type`,
  dsm.`DESCRIPTION` AS `Status`, 
  i.`STATUS_DATE`  AS `Status Date` 
FROM
  invoice AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN account AS a
   ON a.`ID` = i.`ACCOUNTS_RECEIVABLE_ID`
   LEFT OUTER JOIN account_type_map AS atm
   ON atm.`ID` = a.`TYPE`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC "

        Return sQuery_invoice

    End Function
    Private Function RefreshSalesOrder() As String
        Dim sQuery_salesOrder As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextSalesOrder & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Payment Terms`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`, 
  i.`STATUS_DATE`  AS `Status Date` 
FROM
  sales_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_terms AS pm 
    ON pm.`ID` = i.`payment_terms_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
   WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID  "
        Return sQuery_salesOrder
    End Function


    Private Function RefreshFund_Transfer() As String
        Dim sQuery As String = "SELECT i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextFundTransfer & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 '' AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  '' AS `Status`
FROM
  fund_Transfer AS i 
 LEFT OUTER JOIN contact as c
 ON c.ID = i.TO_NAME_ID
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`FROM_LOCATION_ID` 
 WHERE i.FROM_LOCATION_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
 order by i.ID DESC  "
        Return sQuery
    End Function
    Private Function RefreshInventory_Adjustment() As String
        Dim sQuery As String = "
SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextInventoryAdjustment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 '' AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  '0.00' as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  inventory_adjustment AS i 
  LEFT OUTER JOIN inventory_adjustment_type AS c 
  ON c.`ID` = i.`ADJUSTMENT_TYPE_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
      order by i.ID DESC  "
        Return sQuery
    End Function
    Private Function RefreshPurchase_Order() As String
        Dim sQuery_PO As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextPurchaseOrder & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  purchase_order AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
   WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'  order by i.ID DESC  "
        LoadDataGridView(dgvDocument, sQuery_PO)
        Return sQuery_PO

    End Function

    Private Function RefreshPurchase_Request() As String
        Dim sQuery_PR As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextPurchaseRequest & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  purchase_request AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
   WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'  order by i.ID DESC  "
        LoadDataGridView(dgvDocument, sQuery_PR)
        Return sQuery_PR

    End Function

    Private Function RefreshSalesReceipt() As String
        Dim sQuery_Sales_receipt = " SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextSalesReceipt & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  i.`PAYMENT_REF_NO` as `OR#`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull( c.`CREDIT_LIMIT`,0) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`, 
  i.`STATUS_DATE`  AS `Status Date` 
FROM
  sales_receipt AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = i.`PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
   WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'  order by i.ID DESC  "

        Return sQuery_Sales_receipt

    End Function
    Private Sub RefreshGridColumn()
        Select Case Me.AccessibleName
            Case "invoice"
                ViewColumn(dgvDocument, 6) ' 6 = for  Invoice
            Case "payment"

                ViewColumn(dgvDocument, 7) ' 7 = for  payment
            Case "sales_order"

                ViewColumn(dgvDocument, 8) ' 8 = for  sales_order
            Case "sales_receipt"

                ViewColumn(dgvDocument, 9) ' 9 = for  sales_receipt
            Case "credit_memo"

                ViewColumn(dgvDocument, 10) ' 10 = for  credit_memo
            Case "purchase_order"

                ViewColumn(dgvDocument, 13)
            Case "bill"

                ViewColumn(dgvDocument, 14)
            Case "bill_credit"

                ViewColumn(dgvDocument, 15)
            Case "bill_payment"

                ViewColumn(dgvDocument, 16)
            Case "withholding_tax"

                ViewColumn(dgvDocument, 17)
            Case "stock_transfer"

                ViewColumn(dgvDocument, 19)
            Case "build_assembly"

                ViewColumn(dgvDocument, 20)
            Case "inventory_adjustment"

                ViewColumn(dgvDocument, 21)
            Case "general_journal"

                ViewColumn(dgvDocument, 22)
            Case "write_check"

                ViewColumn(dgvDocument, 23)
            Case "deposit"

                ViewColumn(dgvDocument, 24)
            Case "fund_transfer"

                ViewColumn(dgvDocument, 25)
            Case "tax_credit"

                ViewColumn(dgvDocument, 26)
            Case "estimate"

                ViewColumn(dgvDocument, 27) ' 8 = for  sales_order

            Case "purchase_order"

                ViewColumn(dgvDocument, 28)

            Case Else

                ViewColumn(dgvDocument, 5) ' 5 = for  Default
        End Select

    End Sub


    Private Sub RefreshLocation()
        TSComboBoxLoad(tscmbLocation, "SELECT `id`,`name` FROM location UNION SELECT '%' AS `id`,'All Location' AS `NAME` ORDER BY `ID`", "ID", "NAME")
    End Sub
    Private Sub RefreshMode()
        Dim SQL As String = ""
        CursorLoadingOn(True)
        Select Case Me.AccessibleName
            Case "invoice"
                SQL = RefreshInvoice()

            Case "payment"
                SQL = RefreshPayment()

            Case "sales_order"
                SQL = RefreshSalesOrder()

            Case "sales_receipt"
                SQL = RefreshSalesReceipt()

            Case "credit_memo"
                SQL = RefreshCreditMemo()

            Case "purchase_order"
                SQL = RefreshPurchase_Order()
            Case "purchase_request"
                SQL = RefreshPurchase_Request()
            Case "bill"
                SQL = RefreshBills()

            Case "bill_credit"
                SQL = RefreshBillCredits()

            Case "bill_payment"
                SQL = Refresh_Bill_Payment()

            Case "withholding_tax"
                SQL = Refresh_Withholding_Tax()

            Case "stock_transfer"
                SQL = RefreshStock_Transfer()

            Case "build_assembly"
                SQL = RefreshBuild_Assembly()

            Case "inventory_adjustment"
                SQL = RefreshInventory_Adjustment()

            Case "general_journal"
                SQL = RefreshGeneral_Journal()

            Case "write_check"
                SQL = Refresh_Write_Check()

            Case "deposit"
                SQL = RefreshDeposit()

            Case "fund_transfer"
                SQL = RefreshFund_Transfer()

            Case "tax_credit"
                SQL = Refresh_Tax_Credit()

            Case "estimate"
                SQL = RefreshEstimate()
            Case "stock_received"
                SQL = RefreshStock_Received()
            Case Else
                tsTITLE.Visible = True
                tsItem.Visible = True
                SQL = SqlAllDocs()

        End Select

        LoadDataGridViewBinding(dgvDocument, SQL, item_BS)


        RefreshGridColumn()
        '=======================================================================================
        For i As Integer = 0 To dgvDocument.Columns.Count - 1
            With dgvDocument.Columns(i)
                If .HeaderText = "Credit Limit" Or .HeaderText = "Amount" Or .HeaderText = "Balance" Then
                    dgvDocument.Columns(i).DefaultCellStyle.Format = "N2"
                End If
            End With
        Next

        CursorLoadingOn(False)
        dgvDocument.Columns(0).Visible = False
        SearchLoad()
    End Sub

    Private Sub FrmFindDocument_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsSelected = False Then
            Me.AccessibleDescription = "cancel"
        End If

    End Sub
    Private Sub DocumentSelector()
        dgvDocument.Enabled = False
        If dgvDocument.Rows.Count <> 0 Then

            If Me.Dock = DockStyle.Fill Then
                Dim sType As String = dgvDocument.Rows(dgvDocument.CurrentRow.Index).Cells("TYPE").Value
                Dim rd As OdbcDataReader = SqlReader($"select * from `tblsub_menu` where description = '{sType}' limit 1")
                Dim i As Integer = 0
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

                For n As Integer = 0 To FrmMainMenu.MyTab.TabPages.Count - 1
                    Dim Frm As Form = FrmMainMenu.MyTab.TabPages.Item(n).Form
                    If Frm.Text = F.Text Then
                        Frm.Close()
                        Exit For
                    End If
                Next
                gsMenuSubID = i
                gsRefresh = True


                TabFormOpen(F, FrmMainMenu.MyTab, Img)
                gsDocument_Finder_ID = dgvDocument.Rows(dgvDocument.CurrentRow.Index).Cells("ID").Value
                F.TabIndex = gsDocument_Finder_ID
                gsDocument_Finder_ID = 0

            Else
                Dim x As Integer = dgvDocument.CurrentRow.Index
                Me.AccessibleDescription = dgvDocument.Rows(x).Cells(0).Value


                gsSelected = True
                Me.Close()
            End If
        End If

        dgvDocument.Enabled = True


    End Sub

    Private Sub DgvDocument_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellDoubleClick
        DocumentSelector()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Select Case Me.AccessibleName
            Case "invoice"
                ViewSwitch(dgvDocument, 6)
                ViewColumn(dgvDocument, 6) ' 6 = for  Invoice
            Case "payment"
                ViewSwitch(dgvDocument, 7)
                ViewColumn(dgvDocument, 7) ' 7 = for  payment
            Case "sales_order"
                ViewSwitch(dgvDocument, 8)
                ViewColumn(dgvDocument, 8) ' 8 = for  sales_order
            Case "sales_receipt"
                ViewSwitch(dgvDocument, 9)
                ViewColumn(dgvDocument, 9) ' 9 = for  sales_receipt
            Case "credit_memo"
                ViewSwitch(dgvDocument, 10)
                ViewColumn(dgvDocument, 10) ' 10 = for  credit_memo

            Case "purchase_order"
                ViewSwitch(dgvDocument, 13)
                ViewColumn(dgvDocument, 13)
            Case "bill"
                ViewSwitch(dgvDocument, 14)
                ViewColumn(dgvDocument, 14)
            Case "bill_credit"
                ViewSwitch(dgvDocument, 15)
                ViewColumn(dgvDocument, 15)
            Case "bill_payment"
                ViewSwitch(dgvDocument, 16)
                ViewColumn(dgvDocument, 16)
            Case "withholding_tax"
                ViewSwitch(dgvDocument, 17)
                ViewColumn(dgvDocument, 17)
            Case "stock_transfer"
                ViewSwitch(dgvDocument, 19)
                ViewColumn(dgvDocument, 19)

            Case "build_assembly"
                ViewSwitch(dgvDocument, 20)
                ViewColumn(dgvDocument, 20)
            Case "inventory_adjustment"
                ViewSwitch(dgvDocument, 21)
                ViewColumn(dgvDocument, 21)
            Case "general_journal"
                ViewSwitch(dgvDocument, 22)
                ViewColumn(dgvDocument, 22)
            Case "write_check"
                ViewSwitch(dgvDocument, 23)
                ViewColumn(dgvDocument, 23)
            Case "deposit"
                ViewSwitch(dgvDocument, 24)
                ViewColumn(dgvDocument, 24)
            Case "fund_transfer"
                ViewSwitch(dgvDocument, 25)
                ViewColumn(dgvDocument, 25)

            Case "tax_credit"
                ViewSwitch(dgvDocument, 26)
                ViewColumn(dgvDocument, 26)

            Case "estimate"
                ViewSwitch(dgvDocument, 27)
                ViewColumn(dgvDocument, 27)
            Case Else
                ViewSwitch(dgvDocument, 5)
                ViewColumn(dgvDocument, 5) ' 5 = for  Default all Documents
        End Select
    End Sub

    Private Sub TSbtnSearch_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        RefreshMode()
    End Sub

    Private Function RefreshBills() As String
        Dim sQuery_Bills As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextBills & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
    ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  bill AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
  WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID Desc"

        Return sQuery_Bills
    End Function
    Private Function RefreshBillCredits() As String
        Dim sQuery_Bill_credits As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextBillCredit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
    ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  bill_credit AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`VENDOR_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC "

        Return sQuery_Bill_credits
    End Function
    Private Function Refresh_Withholding_Tax() As String
        Dim sQuery As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextWithholdingTax & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
   ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `withholding_tax` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`WITHHELD_FROM_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC "
        Return sQuery
    End Function
    Private Function Refresh_Bill_Payment() As String
        Dim sQuery_Bill_Payments As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextBillPayment & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  i.AMOUNT as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE i.`Type` = '1' and i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC  "
        Return sQuery_Bill_Payments
    End Function
    Private Function Refresh_Write_Check() As String
        Dim sQuery As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextWriteCheck & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  i.AMOUNT as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `check` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PAY_To_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE   i.`Type` = '0' and i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC "
        Return sQuery
    End Function

    Private Function RefreshStock_Transfer() As String
        Dim sQuery As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextStockTransfer & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  i.RETAIL_VALUE as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `stock_transfer` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PREPARED_BY_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
order by i.ID DESC  "
        Return sQuery
    End Function

    Private Function RefreshStock_Received() As String
        Dim sQuery As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextStockReceived & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Prepared by`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  l.`NAME` AS `Received To`,
  loc.`NAME` as `Location From`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `stock_received` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`PREPARED_BY_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`TRANSFER_TO_ID` 
  left outer join location as loc
  on loc.Id = i.LOCATION_ID
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
    WHERE i.TRANSFER_TO_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
order by i.ID DESC  "
        Return sQuery
    End Function
    Private Function RefreshBuild_Assembly() As String
        Dim sQuery As String = "SELECT 
    i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextBuildAssembly & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`Description` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 '' AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  build_assembly AS i 
  LEFT OUTER JOIN item AS c 
  ON c.`ID` = i.`ASSEMBLY_ITEM_ID`
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'  order by i.ID DESC  "
        Return sQuery
    End Function

    Private Function RefreshGeneral_Journal() As String
        Dim sQuery As String = "SELECT 
    i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextGeneralJournal & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  '' AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 '' AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
  (select sum(d.DEBIT) from General_Journal_details as d where d.General_Journal_ID = i.ID  and d.entry_type ='0') as `Amount`,
  '' AS `Status`
FROM
  General_Journal AS i 
  LEFT OUTER JOIN location AS l 
   ON l.`ID` = i.`LOCATION_ID` 
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
 order by i.ID DESC "
        Return sQuery
    End Function
    Private Function RefreshDeposit() As String
        Dim sQuery As String = "SELECT 
    i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextDeposit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  a.`NAME` AS `Name`,
  '' AS `Contact Address`,
  '' AS `Print Name As`,
  '' AS `TIN`,
  '' AS `Contact Person`,
  '' AS `Telephone No`,
  '' AS `Mobile No`,
 '' AS `Fax No`,
 '' AS `Credit Limit`,
  '' AS `Default Payment Method`,
  l.`NAME` AS `Location`,
     ifNull(i.AMOUNT,0.00) as `Amount`,
  '' AS `Status`
FROM
  Deposit AS i 
  LEFT OUTER JOIN account as a
   ON a.`ID` = i.`BANK_ACCOUNT_ID` 
  LEFT OUTER JOIN location AS l
   ON l.`ID` = i.`LOCATION_ID` 
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "'
 order by i.ID DESC  "
        Return sQuery
    End Function

    Private Function Refresh_Tax_Credit() As String
        Dim sQuery As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` AS `Recorded On`,
  i.`Date`,
  '" & gsTextTaxCredit & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
  c.`CREDIT_LIMIT` AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Default Payment Method`,
  l.`NAME` AS `Location`,
   ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`
FROM
  `tax_credit` AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`customer_ID` 
  LEFT OUTER JOIN payment_method AS pm 
    ON pm.`ID` = c.`PREF_PAYMENT_METHOD_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
 WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC  "

        Return sQuery
    End Function
    Private Sub FrmFindDocument_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        gsSelected = False

    End Sub
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        DocumentSelector()
    End Sub

    Private Sub DgvDocument_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDocument.KeyDown
        If e.KeyCode = Keys.Enter Then
            DocumentSelector()
        End If

    End Sub
    Private Function RefreshEstimate() As String
        Dim sQuery As String = "SELECT 
  i.`ID`,
  i.`RECORDED_ON` as `Recorded On`,
  i.`Date`,
  '" & gsTextEstimate & "' AS `Type`,
  i.`CODE` AS `Reference No`,
  c.`NAME` AS `Name`,
  c.`POSTAL_ADDRESS` AS `Contact Address`,
  c.`PRINT_NAME_AS` AS `Print Name As`,
  c.`TAXPAYER_ID` AS `TIN`,
  c.`CONTACT_PERSON` AS `Contact Person`,
  c.`TELEPHONE_NO` AS `Telephone No`,
  c.`MOBILE_NO` AS `Mobile No`,
  c.`FAX_NO` AS `Fax No`,
 ifnull(c.`CREDIT_LIMIT`,0.00) AS `Credit Limit`,
  pm.`DESCRIPTION` AS `Payment Terms`,
  l.`NAME` AS `Location`,
  ifNull(i.AMOUNT,0.00) as `Amount`,
  dsm.`DESCRIPTION` AS `Status`, 
  i.`STATUS_DATE`  AS `Status Date` 
FROM
  estimate AS i 
  LEFT OUTER JOIN contact AS c 
    ON c.`ID` = i.`CUSTOMER_ID` 
  LEFT OUTER JOIN payment_terms AS pm 
    ON pm.`ID` = i.`payment_terms_ID` 
  LEFT OUTER JOIN location AS l 
    ON l.`ID` = i.`LOCATION_ID` 
  LEFT OUTER JOIN contact AS sp 
    ON sp.`ID` = i.`SALES_REP_ID` 
   LEFT OUTER JOIN class AS cl 
   ON cl.`ID` = i.`CLASS_ID`
   LEFT OUTER JOIN payment_terms AS pt
   ON pt.`ID` = i.`PAYMENT_TERMS_ID`
   LEFT OUTER JOIN tax  AS tx
   ON tx.`ID` = i.`OUTPUT_TAX_ID` 
   LEFT OUTER JOIN tax_type_map AS ttm
   ON ttm.`ID` = tx.`TAX_TYPE`
   LEFT OUTER JOIN document_status_map AS dsm
   ON dsm.`ID` = i.`STATUS`
   WHERE  i.Location_ID LIKE  '" & tscmbLocation.ComboBox.SelectedValue & "' order by i.ID DESC  "
        Return sQuery
    End Function

    Private Sub SearchLoad()
        Try

            Dim strSearch As String = ""

            For I As Integer = 0 To dgvDocument.Columns.Count - 1

                If dgvDocument.Columns(I).Visible = True Then

                    If I < 12 And I > 3 Then

                        If strSearch = "" Then
                            strSearch = strSearch & $"[{dgvDocument.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        Else
                            strSearch = strSearch & $" OR [{dgvDocument.Columns(I).HeaderText}] like '%" & tsTxtSearch.Text & "%'"
                        End If
                    End If
                End If



            Next


            item_BS.Filter = strSearch
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        SearchLoad()
    End Sub

    Private Sub TScmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbLocation.SelectedIndexChanged
        If firstLoad = False Then
            RefreshMode()
        End If

    End Sub

    Private Sub DgvDocument_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvDocument.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub
    Private Sub TScmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs)
        SearchLoad()
    End Sub

    Private Sub ExportReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportReportToolStripMenuItem.Click
        ExportingExcel(dgvDocument, $"Summary Report {DateTime.Now()}")
    End Sub
End Class