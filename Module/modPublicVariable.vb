Imports System.Data.Odbc

Module modPublicVariable
    Public gsHours_Item_ID As Integer
    Public gsGotChangeData As Boolean = False
    Public gsStartingCash_Amount As Double = 0
    Public gsCashCOUNT_AMOUNT As Double = 0

    Public gsDisplayTransactionNo As Boolean
    Public gsDisplayTotalSales As Boolean
    Public gsCashCountDisplayDiscripancy As Boolean

    Public mysqlConstr As String
    Public gsSubMenuForm As String
    Public gsImgList As ImageList
    Public gsUtility As ToolStripMenuItem
    Public gsToolStrip As ToolStrip
    Public gsImageBackground As Image
    ' Public gsImageBackgroundPOS As Image = Image.FromFile(Application.StartupPath & "\image\toolbar\pos_banner.png")
    Public gsImageNameApp As Image
    Public gsLeftApp As Image
    Public gsMeasureHoursID As Integer

    Public gsShowAccounts As Boolean
    ' Public gsIcon As Image = Image.FromFile(Application.StartupPath & "\image\cp.ico")

    Public gsIcon As New System.Drawing.Icon(Application.StartupPath & "\image\ams.ico")

    ' Public gsProduct_LOGO As Image = Image.FromFile(Application.StartupPath & "\image\toolbar\Softwarematic_BMS.png")

    Public gsMenuID As Integer
    Public gsMenuSubID As Integer
    Public gsRefresh As Boolean = True
    Public gsMainWith As Double
    Public gsMainHeight As Double
    Public gsShowSubMenu As Boolean
    Public gsTabControl As Windows.Forms.TabControl
    Public gsSystem_Name As Label
    Public gsflpPanel As Panel
    Public gsflpPanelMain As Panel
    Public iMenuCount As Integer = 0
    Public gsMenuTitle As Label


    Public Const gsItemCodeQuery As String = "select ID,CODE from item where inactive ='0' and `type` not in ('5','10')  order by `CODE` "
    Public Const gsItemDescriptionQuery As String = "select ID, DESCRIPTION from item where inactive ='0' and `type` not in ('5','10') order by `DESCRIPTION`"

    Public Const gsItemSearchQuery As String = "SELECT i.ID, i.CODE, i.DESCRIPTION, UCASE(IFNULL(g.`DESCRIPTION`, IF(i.`TYPE` = 6,'GROUP SET',''))) AS `GROUP`, IF(i.NON_PORFOLIO_COMPUTATION=0, FORMAT(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2),0) AS `RATE` FROM ITEM AS I LEFT OUTER JOIN item_group AS g ON g.`ID` = i.`GROUP_ID`  WHERE i.INACTIVE = '0' and i.type <> '5' "
    Public Const gsItemSearchQuery_resto As String = "SELECT i.ID, i.CODE, i.DESCRIPTION, UCASE(IFNULL(g.`DESCRIPTION`, IF(i.`TYPE` = 6,'GROUP SET',''))) AS `GROUP`,FORMAT(IF (i.`TYPE`=6,(SELECT SUM( IF(t.`TYPE` in ('0','2','3','4'),c.`RATE`,IF(t.`TYPE` = 7,-c.`RATE`,0))) FROM item_components  AS c  INNER JOIN item AS t ON t.`ID` = c.`COMPONENT_ID` WHERE c.ITEM_ID = i.ID),i.`RATE`),2) AS `RATE`,i.SUB_CLASS_ID,sc.CLASS_ID,i.GROUP_ID FROM ITEM AS I LEFT OUTER JOIN  item_sub_class as sc on sc.ID =  i.SUB_CLASS_ID LEFT OUTER JOIN item_group AS g ON g.`ID` = i.`GROUP_ID`  WHERE i.INACTIVE = '0' and i.type not in  ('5','10')  "

    Public Const gsItemCodeGROUP As String = "select ID,CODE from item where inactive ='0' and `type` in ('0','1','2','3','4','7') order by `CODE` "
    Public Const gsItemDescriptionGROUP As String = "select ID, DESCRIPTION from item where inactive ='0' and `type` in ('0','1','2','3','4','7')  order by `DESCRIPTION`"
    Public Const gsItemSearchGROUP As String = "select ID, CODE,DESCRIPTION from item where inactive ='0' and `type` in ('0','1','2','3','4','7')  order by `DESCRIPTION`"


    Public Const gsItemCodeAssembly As String = "select ID,CODE from item where inactive ='0' and `type` in ('0') order by `CODE` "
    Public Const gsItemDescriptionAssembly As String = "select ID, DESCRIPTION from item where inactive ='0' and `type` in ('0')  order by `DESCRIPTION`"

    Public Const gsItemSearchAssembly As String = "select ID, CODE,DESCRIPTION from item where inactive ='0' and `type` in ('0')  order by `DESCRIPTION`"


    Public Const gsItemCodeCostQuery As String = "select ID,CODE from item where inactive ='0' and `type` IN ('0','4','7') order by `CODE` "
    Public Const gsItemDescriptionCostQuery As String = "select ID, PURCHASE_DESCRIPTION as DESCRIPTION from item where  inactive ='0' and `type` IN ('0','4','7') order by `PURCHASE_DESCRIPTION`"
    Public Const gsItemSearchCostQuery As String = "SELECT i.ID, i.CODE, i.`PURCHASE_DESCRIPTION` AS `DESCRIPTION`, u.`NAME` AS `UNIT`, FORMAT(i.`COST`,2) AS `COST` FROM ITEM AS I LEFT OUTER JOIN unit_of_measure AS u ON u.`ID` = i.`BASE_UNIT_ID`  WHERE i.INACTIVE = '0'  AND i.`type` IN ('0','4','7') ORDER BY i.`PURCHASE_DESCRIPTION`"


    Public Const gsItemCodeZeroQuery As String = "select ID,CODE from item where inactive ='0' and `type` IN ('0') order by `CODE` "
    Public Const gsItemDescriptionZeroQuery As String = "select ID, PURCHASE_DESCRIPTION as DESCRIPTION from item where  inactive ='0' and `type` IN ('0') order by `PURCHASE_DESCRIPTION`"
    Public Const gsItemSearchZeroQuery As String = "SELECT i.ID, i.CODE, i.`PURCHASE_DESCRIPTION` AS `DESCRIPTION`, u.`NAME` AS `UNIT`, FORMAT(i.`COST`,2) AS `COST` FROM ITEM AS I LEFT OUTER JOIN unit_of_measure AS u ON u.`ID` = i.`BASE_UNIT_ID`  WHERE i.INACTIVE = '0'  AND i.`type` IN ('0') ORDER BY i.`PURCHASE_DESCRIPTION`"

    Public Const gsItemCodeHoursList As String = "SELECT i.`ID`,i.`CODE`,i.`DESCRIPTION` FROM item AS i  WHERE  EXISTS (SELECT c.`ID` FROM item_components  AS c INNER JOIN item AS n ON n.`ID` = c.`ITEM_ID` WHERE c.`COMPONENT_ID` ='1712' AND n.`INACTIVE` ='0' ) AND i.`TYPE` ='6'  AND i.`INACTIVE` = '0' order by i.CODE "
    Public Const gsItemDescriptionHoursList As String = "SELECT i.`ID`,i.`CODE`,i.`DESCRIPTION` FROM item AS i  WHERE  EXISTS (SELECT c.`ID` FROM item_components  AS c INNER JOIN item AS n ON n.`ID` = c.`ITEM_ID` WHERE c.`COMPONENT_ID` ='1712' AND n.`INACTIVE` ='0' ) AND i.`TYPE` ='6'  AND i.`INACTIVE` = '0' order by i.DESCRIPTION"


    Public gsDateRangeDefault As String
    Public gsSelectedDateDefault As String

    Public gsSideBarMenuPostionRight As Boolean = False
    Public gsDefaultItemAssetAccountId As Integer
    Public gsDefaultItemIncomeAccountId As Integer
    Public gsDefaultItemCOGSAccountId As Integer
    Public gsDefaultItemDiscountAccountId As Integer
    Public gsDefaultItemOtherChargeAccountId As Integer

    Public gsDefaultItemClassId As Integer
    Public gsDefaultItemSubClassId As Integer
    Public gsDefaultItemGroupId As Integer

    Public gsDEFAULT_PRINTER As String

    Public gsDataForwarderPath As String = ""
    Public gsDataForwarderIsActive As Boolean = False

    Public gsSystemName As String
    Public cnn As New OdbcConnection()
    Public gsFirstDate As String = DateSerial(Year(DateTime.Now), Month(DateTime.Now), 1)
    Public gsDefault_unit_price_level_id As Integer
    Public gsUserDefaulLockNegativePerUser As Boolean
    Public gsClearObject As Boolean = False
    Public gsPOSDefaultCustomer_ID As String
    Public gsLoadingForm As Form
    Public gsPOS_Mode As Boolean

    Public gsDefault_Vendor_ID As Integer

    Public Const gsMessageCheckEdit As String = "Some value or have changed. do you want to save?"
    Public gsImagePathArray(9999) As String

    Public gsACCOUNT_TAG_ID(9999) As String

    Public bActiveFirst As Boolean = False
    Public bMainMenu As Boolean = False
    Public gsPC_Height As Integer
    Public gsDGV As New DataGridView
    Public Const gsFont As String = "Segoe UI"
    Public Const gsMessageQuestion As String = "Are you sure you want to delete this document and all its line items?"
    Public Const gsMessageClosingDate As String = "This document is closing date. do you want to proceed?"
    'ClosingDatePassword
    Public Const gsMessageClosingDatePassword As String = "This document is closing date. do you want to proceed?"
    Public gsForceDeleteInvoice As Boolean = True
    Public gsForceDeleteBill As Boolean = True


    Public gsUserPriceLock As Boolean
    Public gsJOURNAL_NO_FORM As Integer
    Public gsSkipJournalEntry As Boolean
    Public gsExpiredReference As Boolean
    Public gsUseCashDenomination As Boolean
    Public gsPOSPrintPreview As Boolean
    Public gsPOSPopupNotes As Boolean
    Public gsMultiMethod As Boolean

    Public gsPOSPrintOS As Boolean
    Public gsPOSVoidEntry As Boolean
    Public gsOpenCashDrawer As Boolean

    Public gsReportType As String
    Public gsUser_ID As Integer
    Public gsAdmin_User As Boolean
    Public gsUser_Name As String
    Public gsUserDescription As String
    Public gsContact_ID As String
    Public gsApproved_By As String = "WILFREDO L JUNSAY"
    Public gsBusinessDateStart As Date

    Public gsGmailUsername As String
    Public gsGmailPassword As String
    Public gsGmailAddressTo As String

    Public gsImageSourceFolder As String
    Public gsImageDestinationFolder As String
    Public gsUseImageProduct As Boolean


    Public gsDefault_ACCOUNTS_RECEIVABLE_ID As Integer = 4
    Public gsDefault_UNDEPOSITED_FUNDS_ACCOUNT_ID As Integer = 5
    Public gsDefault_ACCOUNTS_PAYABALE_ID As Integer = 21
    Public gsDefault_ITEM_ACCOUNT_ID As Integer = 6
    Public gsSTOCK_TRANSFER_ACCOUNT_ID As Integer = 100
    Public gsSTOCK_RECEIVED_ACCOUNT_ID As Integer = 576
    Public gsINTER_LOCATION_ACCOUNT_ID As Integer = 429

    ' Public gsTAX_PAYABLE_ACCOUNT_ID As String = "28"
    ' Public gsTAX_CREDIT_ACCOUNT_ID As String = "10"
    Public gsDefault_LOCATION_ID As Integer
    Public gsIncRefNoByLocation As Boolean

    Public gsStorage_Location_ID As Integer = 5

    Public db_Connection As String
    Public db_Connection_Name As String

    Public db_server As String
    Public db_username As String
    Public db_password As String
    Public db_name As String
    Public db_port As String


    Public gsReportFileName As String
    Public gsDocument_Finder_ID As Integer = 0
    Public gsHotKey As Boolean = False

    Public gsTextInvoice As String
    Public gsTextReceivePayment As String
    Public gsTextSalesOrder As String
    Public gsTextSalesReceipt As String
    Public gsTextEstimate As String
    Public gsTextCreditMemo As String
    Public gsTextTaxCredit As String

    Public gsTextPurchaseRequest As String
    Public gsTextPurchaseOrder As String
    Public gsTextBills As String
    Public gsTextBillCredit As String
    Public gsTextBillPayment As String
    Public gsTextWithholdingTax As String
    Public gsTextStockReceived As String

    Public gsTextBuildAssembly As String
    Public gsTextInventoryAdjustment As String
    Public gsTextStockTransfer As String
    Public gsTextGeneralJournal As String

    Public gsTextDeposit As String
    Public gsTextFundTransfer As String
    Public gsTextWriteCheck As String

    Public gsCashier_ID As Integer
    Public gsPOSEntryType As Integer
    Public gsPublicButton As Button

    Public gsSalesOrder_Print_Title As String
    Public gsSalesOrder_File_Name As String

    Public gsInvoice_Print_Title As String
    Public gsInvoice_File_Name As String

    Public gsPayment_Print_Title As String
    Public gsPayment_File_Name As String

    Public gsResto_Sales_Print_Title As String
    Public gsResto_Sales__File_Name As String




    Public gsSYSTEM_UPGRADE As Integer = 0

End Module
