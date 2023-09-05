
Module modUserDefault

    Public Function fUserDefaultLocation() As Integer
        Return fNumFieldValue("user_default", "user_id", gsUser_ID, "location_ID")
    End Function
    Public Function fUserDefaultPriceLevel() As Integer
        Return fNumFieldValue("user_default", "user_id", gsUser_ID, "price_level_ID")
    End Function
    Public Function fUserDefaulLockNegativePerUser() As Boolean

        Return fNumFieldValue("user_default", "user_id", gsUser_ID, "LockNegativePerUser")

    End Function
    Public Function fUserDefaulDisabled() As Boolean

        Return fNumFieldValue("user_default", "user_id", gsUser_ID, "user_disabled")

    End Function

    Public Function fUserPriceLock() As Boolean
        Dim b As Boolean = fNumFieldValue("user_default", "user_id", gsUser_ID, "price_lock")
        Return IIf(b = True, False, True)

    End Function
End Module
