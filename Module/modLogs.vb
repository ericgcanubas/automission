Module modLogs

    Public Sub fTransactionLog(ByVal f As Form, ByVal prID As Integer)

        Dim sub_id As Integer = f.AccessibleName

        Dim sQuery As String = "select DATE, u.NAME as `User`, tl.TRANSACTION_TYPE as `Type`,  tl.Amount, l.Name as `Location`   from transaction_log as tl inner join user as u on u.ID = tl.user_id inner join location as l on l.ID = tl.LOCATION_ID where tl.sub_id = '" & sub_id & "' and tl.transaction_id = '" & prID & "' "

        With frmUserLogs
            .AccessibleDescription = sQuery
            .ShowDialog()
            .Dispose()
        End With
        frmUserLogs = Nothing


    End Sub
    Public Sub fTransaction_Log(ByVal prTrans_ID As Integer, ByVal prReference As String, ByVal prSub_ID As String, ByVal prTrans_Type As String, ByVal prContact_ID As String, ByVal prAccount_ID As String, ByVal prAmount As Double, ByVal prLOCATION_ID As String)

        SqlExecuted("INSERT INTO transaction_log 
            (USER_ID,
            REFERENCE,
            DATE,
            SUB_ID,
            TRANSACTION_ID,
            TRANSACTION_TYPE,
            CONTACT_ID,
            ACCOUNT_ID,
            AMOUNT,
            LOCATION_ID)
            VALUE ('" & gsUser_ID & "',
            '" & prReference & "',
            '" & GetDateTimeNowSql() & "',
            '" & prSub_ID & "',
            '" & prTrans_ID & "',
            '" & prTrans_Type & "',
            '" & prContact_ID & "',
            '" & prAccount_ID & "',
            '" & prAmount & "',
            '" & prLOCATION_ID & "')")

    End Sub

End Module
