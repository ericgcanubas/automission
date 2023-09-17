
Module modUserDefault
    Public Function GF_UserDefaultLocation() As Integer
        Return GF_GetNumberFieldValue("user_default", "user_id", gsUser_ID, "location_ID")
    End Function
    Public Function GF_UserDefaultPriceLevel() As Integer
        Return GF_GetNumberFieldValue("user_default", "user_id", gsUser_ID, "price_level_ID")
    End Function
    Public Function GF_UserDefaulLockNegativePerUser() As Boolean
        Return GF_GetNumberFieldValue("user_default", "user_id", gsUser_ID, "LockNegativePerUser")
    End Function
    Public Function GF_UserDefaulDisabled() As Boolean
        Return GF_GetNumberFieldValue("user_default", "user_id", gsUser_ID, "user_disabled")
    End Function

    Public Function GF_UserPriceLock() As Boolean
        Dim b As Boolean = GF_GetNumberFieldValue("user_default", "user_id", gsUser_ID, "price_lock")
        Return IIf(b = True, False, True)
    End Function
End Module
