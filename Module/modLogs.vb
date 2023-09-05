Module modLogs

    Public Sub fTransactionLog(ByVal f As Form, ByVal prID As String)

        Dim sub_id As Integer = f.AccessibleName

        Dim sQuery As String = "select DATE, u.NAME as `User`, tl.TRANSACTION_TYPE as `Type`,  tl.Amount, l.Name as `Location`   from transaction_log as tl inner join user as u on u.ID = tl.user_id inner join location as l on l.ID = tl.LOCATION_ID where tl.sub_id = '" & sub_id & "' and tl.transaction_id = '" & prID & "' "

        With frmUserLogs
            .AccessibleDescription = sQuery
            .ShowDialog()
            .Dispose()
        End With
        frmUserLogs = Nothing


    End Sub
    Public Sub fTransaction_Log(ByVal prTrans_ID As String, ByVal prReference As String, ByVal prSub_ID As String, ByVal prTrans_Type As String, ByVal prContact_ID As String, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prLOCATION_ID As String)

        fExecutedOnly("INSERT INTO transaction_log SET USER_ID = '" & gsUser_ID & "',REFERENCE = '" & prReference & "',`DATE` = '" & Format(DateTime.Now, "yyyy-MM-dd hh:mm:ss") & "',SUB_ID = '" & prSub_ID & "',TRANSACTION_ID = '" & prTrans_ID & "',`TRANSACTION_TYPE`='" & prTrans_Type & "',CONTACT_ID = '" & prContact_ID & "',ACCOUNT_ID='" & prAccount_ID & "',AMOUNT = '" & prAmount & "', LOCATION_ID = '" & prLOCATION_ID & "'")

    End Sub

End Module
