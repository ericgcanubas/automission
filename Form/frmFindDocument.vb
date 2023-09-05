Imports System.Data.Odbc
Public Class frmFindDocument
    Public firstLoad As Boolean = True
    Public gsSelected As Boolean = False
    Public gsGET_ID As String = ""
    Public item_BS As BindingSource

    Private Function fAllDocs() As String
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


        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextInvoice) = True, IIf(sALl_Document_SQL = "", DOC_INVOICE, $" UNION {DOC_INVOICE}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextSalesOrder) = True, IIf(sALl_Document_SQL = "", DOC_SALES_ORDER, $" UNION {DOC_SALES_ORDER}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextSalesReceipt) = True, IIf(sALl_Document_SQL = "", DOC_SALES_RECEIPT, $" UNION {DOC_SALES_RECEIPT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextReceivePayment) = True, IIf(sALl_Document_SQL = "", DOC_RECEIVED_PAYMENT, $" UNION {DOC_RECEIVED_PAYMENT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextCreditMemo) = True, IIf(sALl_Document_SQL = "", DOC_CREDIT_MEMO, $" UNION {DOC_CREDIT_MEMO}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextTaxCredit) = True, IIf(sALl_Document_SQL = "", DOC_TAXCREDIT, $" UNION {DOC_TAXCREDIT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextPurchaseOrder) = True, IIf(sALl_Document_SQL = "", DOC_PO, $" UNION {DOC_PO}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextPurchaseRequest) = True, IIf(sALl_Document_SQL = "", DOC_PR, $" UNION {DOC_PR}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextStockReceived) = True, IIf(sALl_Document_SQL = "", DOC_STOCK_RECEIVED, $" UNION {DOC_STOCK_RECEIVED}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextBills) = True, IIf(sALl_Document_SQL = "", DOC_BILL, $" UNION {DOC_BILL}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextBillCredit) = True, IIf(sALl_Document_SQL = "", DOC_BILL_CREDIT, $" UNION {DOC_BILL_CREDIT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextBillPayment) = True, IIf(sALl_Document_SQL = "", DOC_BILL_PAYMENT, $" UNION {DOC_BILL_PAYMENT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextWithholdingTax) = True, IIf(sALl_Document_SQL = "", DOC_WITH_HOLDING_TAX, $" UNION {DOC_WITH_HOLDING_TAX}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextStockTransfer) = True, IIf(sALl_Document_SQL = "", DOC_STOCK_TRANSFER, $" UNION {DOC_STOCK_TRANSFER}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextBuildAssembly) = True, IIf(sALl_Document_SQL = "", DOC_BUILD_ASSEMBLY, $" UNION {DOC_BUILD_ASSEMBLY}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextInventoryAdjustment) = True, IIf(sALl_Document_SQL = "", DOC_INVENTORY_ADJUSTMENT, $" UNION {DOC_INVENTORY_ADJUSTMENT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextGeneralJournal) = True, IIf(sALl_Document_SQL = "", DOC_GENERAL_JOURNAL, $" UNION {DOC_GENERAL_JOURNAL}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextWriteCheck) = True, IIf(sALl_Document_SQL = "", DOC_WRITECHECK, $" UNION {DOC_WRITECHECK}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextDeposit) = True, IIf(sALl_Document_SQL = "", DOC_DEPOSIT, $" UNION {DOC_DEPOSIT}"), "")
        sALl_Document_SQL = sALl_Document_SQL & IIf(UserSecurtySystemDOCShow(gsTextFundTransfer) = True, IIf(sALl_Document_SQL = "", DOC_FUND_TRANSFER, $" UNION {DOC_FUND_TRANSFER}"), "")

        Return " SELECT * from ( " & sALl_Document_SQL & ") as x order by x.`Date` desc,x.`ID` desc "


    End Function


    Private Sub frmFindDocument_Load(sender As Object, e As EventArgs) Handles Me.Load
        tsTITLE.Text = gsSubMenuForm
        Try
            If tscmbLocation.ComboBox.Items.Count = 0 Then
                fBackGroundImageStyle(Me)

                fRefreshLocation()
                Dim loc_value As String = gsDefault_LOCATION_ID
                tscmbLocation.ComboBox.SelectedValue = IIf(loc_value = "0", "%", loc_value)
                tscmbLocation.Enabled = fLockLocation()

                fRefresh()


                gsSelected = False
                firstLoad = False

                dgvDocument.ColumnHeadersHeight = 35

            End If


        Catch ex As Exception

        End Try

    End Sub
    Private Function fRefreshCreditMemo() As String
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
    Private Function fRefreshPayment() As String
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

    Private Function fRefreshInvoice() As String
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
    Private Function fRefreshSalesOrder() As String
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


    Private Function fRefreshFund_Transfer() As String
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
    Private Function fRefreshInventory_Adjustment() As String
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
    Private Function fRefreshPurchase_Order() As String
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
        fDataGridView(dgvDocument, sQuery_PO)
        Return sQuery_PO

    End Function

    Private Function fRefreshPurchase_Request() As String
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
        fDataGridView(dgvDocument, sQuery_PR)
        Return sQuery_PR

    End Function

    Private Function fRefreshSalesReceipt() As String
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
    Private Sub fRefreshGridColumn()
        Select Case Me.AccessibleName
            Case "invoice"

                fDataGrid_Column(dgvDocument, 6) ' 6 = for  Invoice
            Case "payment"

                fDataGrid_Column(dgvDocument, 7) ' 7 = for  payment
            Case "sales_order"

                fDataGrid_Column(dgvDocument, 8) ' 8 = for  sales_order
            Case "sales_receipt"

                fDataGrid_Column(dgvDocument, 9) ' 9 = for  sales_receipt
            Case "credit_memo"

                fDataGrid_Column(dgvDocument, 10) ' 10 = for  credit_memo
            Case "purchase_order"

                fDataGrid_Column(dgvDocument, 13)


            Case "bill"

                fDataGrid_Column(dgvDocument, 14)
            Case "bill_credit"

                fDataGrid_Column(dgvDocument, 15)
            Case "bill_payment"

                fDataGrid_Column(dgvDocument, 16)
            Case "withholding_tax"

                fDataGrid_Column(dgvDocument, 17)
            Case "stock_transfer"

                fDataGrid_Column(dgvDocument, 19)
            Case "build_assembly"

                fDataGrid_Column(dgvDocument, 20)
            Case "inventory_adjustment"

                fDataGrid_Column(dgvDocument, 21)
            Case "general_journal"

                fDataGrid_Column(dgvDocument, 22)
            Case "write_check"

                fDataGrid_Column(dgvDocument, 23)
            Case "deposit"

                fDataGrid_Column(dgvDocument, 24)
            Case "fund_transfer"

                fDataGrid_Column(dgvDocument, 25)
            Case "tax_credit"

                fDataGrid_Column(dgvDocument, 26)
            Case "estimate"

                fDataGrid_Column(dgvDocument, 27) ' 8 = for  sales_order

            Case "purchase_order"

                fDataGrid_Column(dgvDocument, 28)

            Case Else

                fDataGrid_Column(dgvDocument, 5) ' 5 = for  Default
        End Select

    End Sub


    Private Sub fRefreshLocation()
        fTSComboBox(tscmbLocation, "SELECT `id`,`name` FROM location UNION SELECT '%' AS `id`,'All Location' AS `NAME` ORDER BY `ID`", "ID", "NAME")
    End Sub
    Private Sub fRefresh()
        Dim SQL As String = ""
        fCursorLoadingOn(True)
        Select Case Me.AccessibleName
            Case "invoice"
                SQL = fRefreshInvoice()

            Case "payment"
                SQL = fRefreshPayment()

            Case "sales_order"
                SQL = fRefreshSalesOrder()

            Case "sales_receipt"
                SQL = fRefreshSalesReceipt()

            Case "credit_memo"
                SQL = fRefreshCreditMemo()

            Case "purchase_order"
                SQL = fRefreshPurchase_Order()
            Case "purchase_request"
                SQL = fRefreshPurchase_Request()
            Case "bill"
                SQL = fRefresh_Bills()

            Case "bill_credit"
                SQL = fRefresh_Bill_Credits()

            Case "bill_payment"
                SQL = fRefresh_Bill_Payment()

            Case "withholding_tax"
                SQL = fRefresh_Withholding_Tax()

            Case "stock_transfer"
                SQL = fRfreshStock_Transfer()

            Case "build_assembly"
                SQL = fRefreshBuild_Assembly()

            Case "inventory_adjustment"
                SQL = fRefreshInventory_Adjustment()

            Case "general_journal"
                SQL = fRefreshGeneral_Journal()

            Case "write_check"
                SQL = fRefresh_Write_Check()

            Case "deposit"
                SQL = fRefreshDeposit()

            Case "fund_transfer"
                SQL = fRefreshFund_Transfer()

            Case "tax_credit"
                SQL = fRefresh_Tax_Credit()

            Case "estimate"
                SQL = fRefreshEstimate()
            Case "stock_received"
                SQL = fRfreshStock_Received()
            Case Else
                tsTITLE.Visible = True
                tsItem.Visible = True
                SQL = fAllDocs()

        End Select

        fDataGridView_Binding(dgvDocument, SQL, item_BS)


        fRefreshGridColumn()
        '=======================================================================================
        For i As Integer = 0 To dgvDocument.Columns.Count - 1
            With dgvDocument.Columns(i)
                If .HeaderText = "Credit Limit" Or .HeaderText = "Amount" Or .HeaderText = "Balance" Then
                    dgvDocument.Columns(i).DefaultCellStyle.Format = "N2"
                End If
            End With
        Next

        fCursorLoadingOn(False)
        dgvDocument.Columns(0).Visible = False
        'If dgvDocument.Rows.Count = 0 Then
        '    dgvDocument.Visible = False

        'Else
        '    dgvDocument.Visible = True
        'End If
        fSearchload()
    End Sub

    Private Sub tstxtFindItem_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            fRefresh()
        ElseIf e.KeyCode = Keys.Down Then
            If dgvDocument.Rows.Count <> 0 Then
                dgvDocument.Focus()
            End If
        End If
    End Sub

    Private Sub dgvDocument_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub dgvDocument_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        gsSelected = False
        If Me.Dock = DockStyle.Fill Then
            fCloseForm(Me)
        Else
            Me.Close()
            Me.AccessibleDescription = ""
        End If

    End Sub

    Private Sub frmFindDocument_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If gsSelected = False Then
            Me.AccessibleDescription = "cancel"
        End If

    End Sub

    Private Sub tstxtFindItem_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub fDOC_Selected()
        dgvDocument.Enabled = False
        If dgvDocument.Rows.Count <> 0 Then

            If Me.Dock = DockStyle.Fill Then
                Dim sType As String = dgvDocument.Rows(dgvDocument.CurrentRow.Index).Cells("TYPE").Value
                Dim rd As OdbcDataReader = fReader($"select * from `tblsub_menu` where description = '{sType}' limit 1")
                Dim i As Integer = 0
                Dim F As Form = Nothing
                Dim Img As Image = Nothing
                If rd.Read Then
                    i = fNumisNULL(rd("sub_id"))
                    F = fGetForm(rd("Form"))
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
                gsDocument_Finder_ID = dgvDocument.Rows(dgvDocument.CurrentRow.Index).Cells("ID").Value
                F.TabIndex = gsDocument_Finder_ID
                gsDocument_Finder_ID = ""

            Else
                Dim x As Integer = dgvDocument.CurrentRow.Index
                Me.AccessibleDescription = dgvDocument.Rows(x).Cells(0).Value


                gsSelected = True
                Me.Close()
            End If
        End If

        dgvDocument.Enabled = True


    End Sub

    Private Sub dgvDocument_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellDoubleClick
        fDOC_Selected()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Select Case Me.AccessibleName
            Case "invoice"
                fDataGrid_Switch(dgvDocument, 6)
                fDataGrid_Column(dgvDocument, 6) ' 6 = for  Invoice
            Case "payment"
                fDataGrid_Switch(dgvDocument, 7)
                fDataGrid_Column(dgvDocument, 7) ' 7 = for  payment
            Case "sales_order"
                fDataGrid_Switch(dgvDocument, 8)
                fDataGrid_Column(dgvDocument, 8) ' 8 = for  sales_order
            Case "sales_receipt"
                fDataGrid_Switch(dgvDocument, 9)
                fDataGrid_Column(dgvDocument, 9) ' 9 = for  sales_receipt
            Case "credit_memo"
                fDataGrid_Switch(dgvDocument, 10)
                fDataGrid_Column(dgvDocument, 10) ' 10 = for  credit_memo

            Case "purchase_order"
                fDataGrid_Switch(dgvDocument, 13)
                fDataGrid_Column(dgvDocument, 13)
            Case "bill"
                fDataGrid_Switch(dgvDocument, 14)
                fDataGrid_Column(dgvDocument, 14)
            Case "bill_credit"
                fDataGrid_Switch(dgvDocument, 15)
                fDataGrid_Column(dgvDocument, 15)
            Case "bill_payment"
                fDataGrid_Switch(dgvDocument, 16)
                fDataGrid_Column(dgvDocument, 16)
            Case "withholding_tax"
                fDataGrid_Switch(dgvDocument, 17)
                fDataGrid_Column(dgvDocument, 17)
            Case "stock_transfer"
                fDataGrid_Switch(dgvDocument, 19)
                fDataGrid_Column(dgvDocument, 19)

            Case "build_assembly"
                fDataGrid_Switch(dgvDocument, 20)
                fDataGrid_Column(dgvDocument, 20)
            Case "inventory_adjustment"
                fDataGrid_Switch(dgvDocument, 21)
                fDataGrid_Column(dgvDocument, 21)
            Case "general_journal"
                fDataGrid_Switch(dgvDocument, 22)
                fDataGrid_Column(dgvDocument, 22)
            Case "write_check"
                fDataGrid_Switch(dgvDocument, 23)
                fDataGrid_Column(dgvDocument, 23)
            Case "deposit"
                fDataGrid_Switch(dgvDocument, 24)
                fDataGrid_Column(dgvDocument, 24)
            Case "fund_transfer"
                fDataGrid_Switch(dgvDocument, 25)
                fDataGrid_Column(dgvDocument, 25)

            Case "tax_credit"
                fDataGrid_Switch(dgvDocument, 26)
                fDataGrid_Column(dgvDocument, 26)

            Case "estimate"
                fDataGrid_Switch(dgvDocument, 27)
                fDataGrid_Column(dgvDocument, 27)
            Case Else
                fDataGrid_Switch(dgvDocument, 5)
                fDataGrid_Column(dgvDocument, 5) ' 5 = for  Default all Documents
        End Select
    End Sub

    Private Sub tsbtnSearch_Click(sender As Object, e As EventArgs) Handles tsbtnSearch.Click
        fRefresh()
    End Sub

    Private Function fRefresh_Bills() As String
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
    Private Function fRefresh_Bill_Credits() As String
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
    Private Function fRefresh_Withholding_Tax() As String
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
    Private Function fRefresh_Bill_Payment() As String
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
    Private Function fRefresh_Write_Check() As String
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

    Private Function fRfreshStock_Transfer() As String
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

    Private Function fRfreshStock_Received() As String
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
    Private Function fRefreshBuild_Assembly() As String
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

    Private Function fRefreshGeneral_Journal() As String
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
    Private Function fRefreshDeposit() As String
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

    Private Function fRefresh_Tax_Credit() As String
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

    Private Sub dgvDocument_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocument.CellContentClick

    End Sub

    Private Sub frmFindDocument_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        gsSelected = False

    End Sub

    Private Sub tscmbLocation_Click(sender As Object, e As EventArgs) Handles tscmbLocation.Click

    End Sub

    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        fDOC_Selected()
    End Sub

    Private Sub dgvDocument_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvDocument.KeyDown
        If e.KeyCode = Keys.Enter Then
            fDOC_Selected()
        End If

    End Sub
    Private Function fRefreshEstimate() As String
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

    Private Sub fSearchload()
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

    Private Sub tsTxtSearch_TextChanged(sender As Object, e As EventArgs) Handles tsTxtSearch.TextChanged
        fSearchload()
    End Sub

    Private Sub tscmbLocation_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tscmbLocation.SelectedIndexChanged
        If firstLoad = False Then
            fRefresh()
        End If

    End Sub

    Private Sub dgvDocument_RowStateChanged(sender As Object, e As DataGridViewRowStateChangedEventArgs) Handles dgvDocument.RowStateChanged
        lblRow.Text = DirectCast(sender, DataGridView).Rows.Count
    End Sub

    Private Sub tsTxtSearch_Click(sender As Object, e As EventArgs) Handles tsTxtSearch.Click

    End Sub

    Private Sub tscmbSearch_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tscmbSearch_SelectedIndexChanged(sender As Object, e As EventArgs)
        fSearchload()
    End Sub

    Private Sub ExportReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportReportToolStripMenuItem.Click
        fExport(dgvDocument, $"Summary Report {DateTime.Now()}")
    End Sub
End Class