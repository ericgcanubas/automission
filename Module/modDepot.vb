Imports System.Data.Odbc
Module modDepot

    Public Sub fDepotConnected(ByVal prOrder As ComboBox, ByVal prDealer As ComboBox, ByVal prSales_REP As ComboBox)
        fCursorLoadingOn(True)


        Try

            If prOrder Is Nothing Then
                Exit Sub
            End If

            If prOrder.SelectedIndex < 0 Then
                Exit Sub
            End If


            Dim rd As OdbcDataReader = fReader("select * from contact where id = '" & CStr(prOrder.SelectedValue.ToString) & "' Limit 1")
            If rd.Read Then
                Select Case fNumisNULL(rd("TYPE"))
                    Case 1
                        ' Dealer
                        prDealer.SelectedValue = fNumisNULL(rd("OTHER_CONTACT_ID"))
                        ' Manager
                        prSales_REP.SelectedValue = fNumisNULL(rd("SALES_REP_ID"))
                    Case 5
                        ' Manager
                        prDealer.SelectedValue = 0
                       ' prManager.SelectedValue = prOrder.SelectedValue
                    Case 6
                        ' Dealer
                        prDealer.SelectedValue = prOrder.SelectedValue

                        prSales_REP.SelectedValue = fNumisNULL(rd("SALES_REP_ID"))
                        ' Manager

                End Select

            End If
            rd.Close()
        Catch ex As Exception


            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fDepotConnected(prOrder, prDealer, prSales_REP)
            Else
                End
            End If
        End Try




        fCursorLoadingOn(False)
    End Sub



    Public Function fgetRunningTotal(ByVal dt1 As String, ByVal dt2 As String) As Double ' OVER ALL COLLECTION
        fCursorLoadingOn(True)

        Dim sqlx As String = "SELECT SUM(pv.`AMOUNT_APPLIED`)  FROM payment_invoices AS pv INNER JOIN  payment AS p ON p.`ID` = pv.`PAYMENT_ID` inner join invoice as i on pv.INVOICE_ID = i.ID WHERE i.`DATE` BETWEEN '" & dt1 & "' and '" & dt2 & "'"
        Dim sqls As String = "SELECT SUM(i.`AMOUNT`)   FROM sales_receipt AS i  WHERE i.`DATE` BETWEEN '" & dt1 & "' and '" & dt2 & "'"

        Dim n As Double = fGET_SUM(sqlx)
        n = n + fGET_SUM(sqls)

        Return n
        fCursorLoadingOn(False)
    End Function
    Public Function fgetRunningTotalByManager(ByVal dt1 As String, ByVal dt2 As String, ByVal prContact_ID As String)

        Dim sqlx As String = "SELECT SUM(pv.`AMOUNT_APPLIED`)  FROM payment_invoices AS pv INNER JOIN  payment AS p ON p.`ID` = pv.`PAYMENT_ID` inner join invoice as i on pv.INVOICE_ID = i.ID WHERE i.`DATE` BETWEEN '" & dt1 & "' and '" & dt2 & "' and  i.MANAGER_ID = '" & prContact_ID & "'"
        Dim sqls As String = "SELECT SUM(i.`AMOUNT`)   FROM sales_receipt AS i  WHERE i.`DATE` BETWEEN '" & dt1 & "' and '" & dt2 & "' and  i.MANAGER_ID = '" & prContact_ID & "'"

        Dim n As Double = fGET_SUM(sqlx)
        n = n + fGET_SUM(sqls)

        Return n

    End Function

    Public Function fgetRunningTotalByDealer(ByVal dt1 As String, ByVal dt2 As String, ByVal prContact_ID As String)

        Dim sqlx As String = "SELECT SUM(pv.`AMOUNT_APPLIED`)  FROM payment_invoices AS pv INNER JOIN  payment AS p ON p.`ID` = pv.`PAYMENT_ID` inner join invoice as i on pv.INVOICE_ID = i.ID WHERE i.`DATE` BETWEEN '" & dt1 & "' and '" & dt2 & "' and  i.DEALER_ID = '" & prContact_ID & "'"
        Dim sqls As String = "SELECT SUM(i.`AMOUNT`)   FROM sales_receipt AS i  WHERE i.`DATE` BETWEEN '" & dt1 & "' and '" & dt2 & "' and  i.DEALER_ID = '" & prContact_ID & "'"

        Dim n As Double = fGET_SUM(sqlx)
        n = n + fGET_SUM(sqls)

        Return n

    End Function
    Public Function fManagerHitSalesTargetViaDealer(ByVal dt1 As String, ByVal dt2 As String, ByVal prContact_ID As String, ByRef prRebate_AMOUNT As Double)
        Dim b As Boolean = False
        Dim sql As String = "SELECT 
  FORMAT(c.SALES_TARGET, 2) AS `Sales Target`,
  FORMAT(
    (SELECT 
      IFNULL(SUM(pv.`AMOUNT_APPLIED`), '0') 
    FROM
      payment_invoices AS pv 
      INNER JOIN payment AS p 
        ON p.`ID` = pv.`PAYMENT_ID` 
      INNER JOIN invoice AS i 
        ON pv.INVOICE_ID = i.ID 
    WHERE i.`DATE` BETWEEN '" & dt1 & "' 
      AND '" & dt2 & "' 
      AND i.DEALER_ID = c.ID) + 
    (SELECT 
      IFNULL(SUM(i.`AMOUNT`), '0') 
    FROM
      sales_receipt AS i 
    WHERE i.`DATE` BETWEEN '" & dt1 & "' 
      AND '" & dt2 & "' 
      AND i.DEALER_ID = c.ID),
    2
  )AS `Sales Collection`
FROM
   contact AS c 
  LEFT OUTER JOIN contact_group AS g 
    ON g.ID = c.GROUP_ID 
  LEFT OUTER JOIN contact AS s 
    ON c.OTHER_CONTACT_ID = s.ID 
    AND s.Type = '5' 
  LEFT OUTER JOIN payment_terms AS p 
    ON p.id = c.payment_terms_id 
  LEFT OUTER JOIN price_level AS pl 
    ON pl.id = c.price_level_id 
WHERE c.Type = '6' AND c.`OTHER_CONTACT_ID` = '" & prContact_ID & "' "

        ' Dim cn As New MySqlConnection(mysqlConstr)
        Try
            Dim n As Integer = 0
            Dim r As Double = 0
            'cn.Open()
            Dim rd As OdbcDataReader = fReader(sql)
            While rd.Read
                If fNumisNULL(rd(0)) <= fNumisNULL(rd(1)) Then
                    n = n + 1
                    r = r + fNumisNULL(rd(1))
                End If
            End While
            rd.Close()


            If Val(fSystemSettingValue("ManagerGetDealerSalesTarget")) <= n Then
                b = True
                prRebate_AMOUNT = r
            Else
                b = False
                prRebate_AMOUNT = 0
            End If

        Catch ex As Exception

            fMessageboxWarning(ex.Message)
        End Try

        Return b
    End Function
End Module
