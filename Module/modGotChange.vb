Imports System.Data.Odbc
Module modGotChange
    Public gsGotChangeDate As Boolean
    Public gsGotChangeLocation1 As Boolean
    Public gsGotChangeLocation2 As Boolean


    Public gsLast_Date As Date
    Public gsLast_Location_ID As Integer
    Public gsLast_location_Transfer_ID As Integer

    Public Sub fGotChangeTransaction(ByVal prTable As String, ByVal prID As Integer, ByVal prDate As Date, ByVal prLocation_ID As Integer)
        Dim ThisDate As Date
        Dim ThisLocation_ID As Integer
        Dim rd As OdbcDataReader = fReader($"select DATE,LOCATION_ID from {prTable} where id = '{prID}' limit 1;")
        If rd.Read Then
            ThisDate = CDate(rd("DATE"))
            gsLast_Date = ThisDate
            ThisLocation_ID = fNumisNULL(rd("LOCATION_ID"))
            gsLast_Location_ID = ThisLocation_ID
        End If
        rd.Close()


        If ThisDate = prDate Then
            gsGotChangeDate = False
        Else
            gsGotChangeDate = True
        End If

        If ThisLocation_ID = prLocation_ID Then
            gsGotChangeLocation1 = False
        Else
            gsGotChangeLocation1 = True
        End If


    End Sub

    Public Sub fGotChangeTransaction_To_Stock_Transfer(ByVal prID As Integer, ByVal prBefore_Date1 As Date, ByVal prBefore_Location1 As Integer, ByVal prBefore_Location_Transfer2 As Integer)

        Dim ThisDate As Date
        Dim ThisLocation_ID As Integer
        Dim ThisLocation_Transfer_ID As Integer
        Dim rd As OdbcDataReader = fReader($"select DATE,LOCATION_ID,TRANSFER_TO_ID from stock_transfer where id = '{prID}' limit 1;")
        If rd.Read Then
            ThisDate = CDate(rd("DATE"))
            gsLast_Date = ThisDate

            ThisLocation_ID = fNumisNULL(rd("LOCATION_ID"))
            gsLast_Location_ID = ThisLocation_ID

            ThisLocation_Transfer_ID = fNumisNULL(rd("TRANSFER_TO_ID"))
            gsLast_location_Transfer_ID = ThisLocation_Transfer_ID
        End If
        rd.Close()

        If ThisDate = prBefore_Date1 Then
            gsGotChangeDate = False
        Else
            gsGotChangeDate = True

        End If

        If ThisLocation_ID = prBefore_Location1 Then
            gsGotChangeLocation1 = False
        Else

            gsGotChangeLocation1 = True
        End If


        If ThisLocation_Transfer_ID = prBefore_Location_Transfer2 Then
            gsGotChangeLocation2 = False
        Else

            gsGotChangeLocation2 = True
        End If
    End Sub
    Public Sub fGotChangeTransaction_To_Stock_Received(ByVal prID As Integer, ByVal prBefore_Date1 As Date, ByVal prBefore_Location1 As Integer, ByVal prBefore_Location_Transfer2 As Integer)

        Dim ThisDate As Date
        Dim ThisLocation_ID As Integer
        Dim ThisLocation_Transfer_ID As Integer
        Dim rd As OdbcDataReader = fReader($"select DATE,LOCATION_ID,TRANSFER_TO_ID from stock_Received where id = '{prID}' limit 1;")
        If rd.Read Then
            ThisDate = CDate(rd("DATE"))
            gsLast_Date = ThisDate

            ThisLocation_ID = fNumisNULL(rd("LOCATION_ID"))
            gsLast_Location_ID = ThisLocation_ID

            ThisLocation_Transfer_ID = fNumisNULL(rd("TRANSFER_TO_ID"))
            gsLast_location_Transfer_ID = ThisLocation_Transfer_ID
        End If
        rd.Close()

        If ThisDate = prBefore_Date1 Then
            gsGotChangeDate = False
        Else
            gsGotChangeDate = True

        End If

        If ThisLocation_ID = prBefore_Location1 Then
            gsGotChangeLocation1 = False
        Else

            gsGotChangeLocation1 = True
        End If


        If ThisLocation_Transfer_ID = prBefore_Location_Transfer2 Then
            gsGotChangeLocation2 = False
        Else

            gsGotChangeLocation2 = True
        End If
    End Sub

    Public Sub fJAccount(ByVal prAccount As Integer, ByVal prLocation As Integer)
        'NO NEED

        Exit Sub

        Dim BALANCE As Double = 0

        Dim rd As OdbcDataReader = fReader($"SELECT * FROM ACCOUNT_JOURNAL WHERE ACCOUNT_ID = '{prAccount}' and LOCATION_ID ='{prLocation}' ORDER BY OBJECT_DATE,ID ")

        While rd.Read

            If fNumisNULL(rd("ENTRY_TYPE")) = 0 Then
                BALANCE = BALANCE + fNumisNULL(rd("AMOUNT"))
            Else
                BALANCE = BALANCE - fNumisNULL(rd("AMOUNT"))
            End If

            fExecutedOnly($" UPDATE `account_journal` SET ENDING_BALANCE ='{BALANCE}' WHERE `ID`='{rd("ID")}' and LOCATION_ID ='{prLocation}' and ACCOUNT_ID ='{prAccount}'  limit 1;")

        End While




    End Sub
    Public Sub fAccount_journal_Change_date(ByVal prChangeDate As Date, ByVal account_id As Integer, ByVal object_type As Integer, ByVal object_id As Integer, ByVal location_id As Integer, ByVal L_object_date As Date)
        fExecutedOnly($"UPDATE account_journal SET object_date = '{fDateFormatMYSQL(prChangeDate)}' where account_id ='{account_id}' and object_type = '{object_type}' and object_id = '{object_id}' and location_id ='{location_id}' and object_date = '{fDateFormatMYSQL(L_object_date)}'  limit 1;")
        fJAccount(account_id, location_id)
    End Sub

    Public Sub fAccount_journal_Change_Location(ByVal change_location_id As Integer, ByVal account_id As Integer, ByVal object_type As Integer, ByVal object_id As Integer, ByVal object_date As Date, ByVal L_Location_ID As Integer)
        fExecutedOnly($"UPDATE account_journal SET location_id = '{change_location_id}' where account_id ='{account_id}' and object_type = '{object_type}' and object_id = '{object_id}' and object_date = '{fDateFormatMYSQL(object_date)}' and location_id ='{L_Location_ID}' limit 1;")
        fJAccount(account_id, change_location_id)
    End Sub

    Public Sub fItem_inventory_change_date(ByVal Change_SOURCE_REF_DATE As Date, ByVal item_id As Integer, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal LOCATION_ID As Integer, ByVal L_DATE As Date)
        fExecutedOnly($"UPDATE item_inventory SET SOURCE_REF_DATE = '{fDateFormatMYSQL(Change_SOURCE_REF_DATE)}' WHERE ITEM_ID = '{item_id}' and  LOCATION_ID = '{LOCATION_ID}' and SOURCE_REF_TYPE =' {SOURCE_REF_TYPE}' and  SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE ='{fDateFormatMYSQL(L_DATE)}' limit 1;")

        fReCalculateInventory(item_id, LOCATION_ID, Change_SOURCE_REF_DATE)

    End Sub
    Public Function fItem_inventory_change_date_Adjust(ByVal Change_SOURCE_REF_DATE As Date, ByVal item_id As Integer, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal LOCATION_ID As Integer, ByVal L_DATE As Date) As Double
        Dim QTY_ONHAND As Double = fQTY_ACTUAL_ON_DATE_LOCATION(item_id, Change_SOURCE_REF_DATE, LOCATION_ID)
        Dim QTY_END As Double = fNumFieldValueOneReturn($"SELECT ENDING_QUANTITY FROM item_inventory  WHERE ITEM_ID = '{item_id}' and  LOCATION_ID = '{LOCATION_ID}' and SOURCE_REF_TYPE =' {SOURCE_REF_TYPE}' and  SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE ='{fDateFormatMYSQL(L_DATE)}' limit 1;")
        Dim QTY_D As Double = QTY_END - QTY_ONHAND
        fExecutedOnly($"UPDATE item_inventory SET QUANTITY ='{QTY_D}',SOURCE_REF_DATE = '{fDateFormatMYSQL(Change_SOURCE_REF_DATE)}' WHERE ITEM_ID = '{item_id}' and  LOCATION_ID = '{LOCATION_ID}' and SOURCE_REF_TYPE =' {SOURCE_REF_TYPE}' and  SOURCE_REF_ID = '{SOURCE_REF_ID}' and SOURCE_REF_DATE ='{fDateFormatMYSQL(L_DATE)}' limit 1;")

        fReCalculateInventory(item_id, LOCATION_ID, Change_SOURCE_REF_DATE)

        Return QTY_D
    End Function
    Public Sub fItem_inventory_change_Location(ByVal Change_LOCATION_ID As Integer, ByVal item_id As Integer, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal SOURCE_REF_DATE As Date, ByVal L_LOCATION_ID As Integer)

        fExecutedOnly($"UPDATE item_inventory SET LOCATION_ID = '{Change_LOCATION_ID}' WHERE ITEM_ID = '{item_id}' and  SOURCE_REF_DATE = '{fDateFormatMYSQL(SOURCE_REF_DATE)}' and SOURCE_REF_TYPE =' {SOURCE_REF_TYPE}' and  SOURCE_REF_ID = '{SOURCE_REF_ID}' and LOCATION_ID ='{L_LOCATION_ID}' limit 1;")

        Dim UPDATE_DATE As Date = SOURCE_REF_DATE.AddDays(-1)

        fReCalculateInventory(item_id, Change_LOCATION_ID, UPDATE_DATE)
        fReCalculateInventory(item_id, L_LOCATION_ID, UPDATE_DATE)
    End Sub

    Public Function fItem_inventory_change_Location_Adjust(ByVal Change_LOCATION_ID As Integer, ByVal item_id As Integer, ByVal SOURCE_REF_TYPE As Integer, ByVal SOURCE_REF_ID As Integer, ByVal SOURCE_REF_DATE As Date, ByVal L_LOCATION_ID As Integer) As Double
        Dim QTY_ONHAND As Double = fQTY_ACTUAL_ON_DATE_LOCATION(item_id, SOURCE_REF_DATE, Change_LOCATION_ID)
        Dim QTY_END As Double = fNumFieldValueOneReturn($"SELECT ENDING_QUANTITY FROM item_inventory  WHERE ITEM_ID = '{item_id}' and  SOURCE_REF_DATE = '{fDateFormatMYSQL(SOURCE_REF_DATE)}' and SOURCE_REF_TYPE =' {SOURCE_REF_TYPE}' and  SOURCE_REF_ID = '{SOURCE_REF_ID}' and LOCATION_ID ='{L_LOCATION_ID}' limit 1;")
        Dim QTY_D As Double = QTY_ONHAND - QTY_END

        fExecutedOnly($"UPDATE item_inventory SET QUANTITY ='{QTY_D}',LOCATION_ID = '{Change_LOCATION_ID}' WHERE ITEM_ID = '{item_id}' and  SOURCE_REF_DATE = '{fDateFormatMYSQL(SOURCE_REF_DATE)}' and SOURCE_REF_TYPE =' {SOURCE_REF_TYPE}' and  SOURCE_REF_ID = '{SOURCE_REF_ID}' and LOCATION_ID ='{L_LOCATION_ID}' limit 1;")

        Dim UPDATE_DATE As Date = SOURCE_REF_DATE.AddDays(-1)
        fReCalculateInventory(item_id, Change_LOCATION_ID, UPDATE_DATE)
        fReCalculateInventory(item_id, L_LOCATION_ID, UPDATE_DATE)
        Return QTY_D
    End Function
End Module
