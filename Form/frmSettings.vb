Imports System.Data.Odbc
Public Class frmSettings








    Private Sub fControlRotation(ByVal prName As String, ByVal prValue As String)
        Try


            'tab 1
            For i As Integer = 0 To TabPage1.Controls.Count - 1
                If fGetObjectNow(prName, TabPage1, i) = True Then

                    fObject_Type(TabPage1, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 2
            For i As Integer = 0 To TabPage2.Controls.Count - 1
                If fGetObjectNow(prName, TabPage2, i) = True Then

                    fObject_Type(TabPage2, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 3
            For i As Integer = 0 To TabPage3.Controls.Count - 1
                If fGetObjectNow(prName, TabPage3, i) = True Then

                    fObject_Type(TabPage3, i, prValue)
                    Exit Sub

                End If
            Next

            'tab 4
            For i As Integer = 0 To TabPage4.Controls.Count - 1
                If fGetObjectNow(prName, TabPage4, i) = True Then

                    fObject_Type(TabPage4, i, prValue)
                    Exit Sub
                End If
            Next


            'tab 5
            For i As Integer = 0 To TabPage5.Controls.Count - 1
                If fGetObjectNow(prName, TabPage5, i) = True Then

                    fObject_Type(TabPage5, i, prValue)
                    Exit Sub
                End If
            Next



            'tab 6
            For i As Integer = 0 To TabPage6.Controls.Count - 1
                If fGetObjectNow(prName, TabPage6, i) = True Then

                    fObject_Type(TabPage6, i, prValue)
                    Exit Sub
                End If
            Next


            'tab 7
            For i As Integer = 0 To TabPage7.Controls.Count - 1
                If fGetObjectNow(prName, TabPage7, i) = True Then
                    fObject_Type(TabPage7, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 8
            For i As Integer = 0 To TabPage8.Controls.Count - 1

                If fGetObjectNow(prName, TabPage8, i) = True Then

                    fObject_Type(TabPage8, i, prValue)
                    Exit Sub

                End If
            Next
            'tab 9

            '===============================================================================
            For i As Integer = 0 To GroupBox1.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox1, i) = True Then

                    fObject_Type(GroupBox1, i, prValue)
                    Exit Sub

                End If
            Next


            For i As Integer = 0 To GroupBox2.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox2, i) = True Then
                    fObject_Type(GroupBox2, i, prValue)
                    Exit Sub

                End If
            Next


            For i As Integer = 0 To GroupBox3.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox3, i) = True Then
                    fObject_Type(GroupBox3, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox4.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox4, i) = True Then
                    fObject_Type(GroupBox4, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox5.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox5, i) = True Then
                    fObject_Type(GroupBox5, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox6.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox6, i) = True Then
                    fObject_Type(GroupBox6, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox7.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox7, i) = True Then
                    fObject_Type(GroupBox7, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox8.Controls.Count - 1
                If fGetObjectNow(prName, GroupBox8, i) = True Then
                    fObject_Type(GroupBox8, i, prValue)
                    Exit Sub
                End If
            Next

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Sub fRefreshSystemSettings()
        Try

            Dim rd As OdbcDataReader = SqlReader("select `NAME`,`VALUE` from system_settings  ")
            While rd.Read
                fControlRotation(rd("NAME"), rd("VALUE"))
            End While
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshSystemSettings()
            Else
                End
            End If

        End Try

    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsSYSTEM_UPGRADE <> 1 Then
            TabPage3.Visible = False
        End If

        'fBackGroundImageStyle(Me)
        fRefreshComboBox()
        fRefreshSystemSettings()
        numServiceFee.DecimalPlaces = 0
        numManagerRebites.DecimalPlaces = 0
        numManagerGetDealerSalesTarget.DecimalPlaces = 0



    End Sub
    Private Sub fRefreshComboBox()

        ComboBoxLoad(cmbDefaultVendorID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        '   Dim sQueryAccount As String = "SELECT a.ID, CONCAT(a.NAME ,' / ', atm.Description)  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        Dim sQueryAccount As String = "SELECT a.ID, a.NAME  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        ComboBoxLoad(cmbDefaultLocationId, "select * from location where inactive ='0' ", "ID", "NAME")
        ComboBoxLoad(cmbStorageLocationId, "select * from location where inactive ='0' ", "ID", "NAME")

        ComboBoxLoad(cmbNewTransactionsDefaultDate, "SELECT '0' AS ID , 'Use today`s date' AS `NAME` UNION SELECT '1' AS ID , 'Use the last entered date' AS `NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbDefaultPaymentMethodId, "select ID,DESCRIPTION from payment_method", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbDefaultPaymentTermsId, "select ID,DESCRIPTION from payment_terms", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbCreditLimitPolicy, "SELECT '0' AS ID , 'Promp warning message only' AS `NAME` UNION SELECT '1' AS ID , 'Enforce transaction blocking' AS `NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbArAgingLimit, "SELECT '0' AS ID , 'None' AS `NAME` UNION SELECT '1' AS ID , 'Current balance only' UNION SELECT '2' AS ID , '1 - 30 day past due' AS `NAME` UNION SELECT '3' AS ID ,'31 - 60 day past due' AS `NAME`UNION SELECT '4' AS ID ,'61 - 90 day past due' AS `NAME` ; ", "ID", "NAME")

        ComboBoxLoad(cmbFinanceChargeItemId, "select ID,concat(CODE,' / ',DESCRIPTION) as T from item where type='4' and inactive = '0' order by DESCRIPTION", "ID", "T")
        ComboBoxLoad(cmbDefaultItemStockType, "select ID,DESCRIPTION from stock_type_map", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbDefaultForecastingType, "SELECT '0' AS ID , 'Monthly' AS `NAME` UNION SELECT '1' AS ID , 'Weekly' AS `NAME` ", "ID", "NAME")
        ComboBoxLoad(cmbDefaultPenaltyType, "Select '0' as  ID, 'NO PENALTY' as DESCRIPTION UNION select ID,DESCRIPTION  FROM PENALTY_TYPE_MAP", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbTargetPenaltyDiscount, "select ID,DESCRIPTION FROM item where `TYPE` = '7' ", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbTaxPayableAccountId, sQueryAccount, "ID", "T")
        ComboBoxLoad(cmbTaxCreditAccountId, sQueryAccount, "ID", "T")
        ComboBoxLoad(cmbFinanceChargeAccountId, sQueryAccount, "ID", "T")




        ComboBoxLoad(cmbOutputTaxId, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        ComboBoxLoad(cmbInputTaxId, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
    End Sub
    Private Sub cmbDefaultPenaltyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDefaultPenaltyType.SelectedIndexChanged
        If cmbDefaultPenaltyType.SelectedValue IsNot Nothing Then

            If NumIsNull(cmbDefaultPenaltyType.SelectedValue) = 3 Then

                cmbTargetPenaltyDiscount.Enabled = True
            Else
                cmbTargetPenaltyDiscount.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnBrowser_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub frmSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        fDefaultAccountLoad()
    End Sub

    Private Sub btnPOS_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnEmailSetup_Click(sender As Object, e As EventArgs) Handles btnEmailSetup.Click

        frmEmailSetup.ShowDialog()
        frmEmailSetup.Dispose()
        frmEmailSetup = Nothing

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImageSetup.Click
        FrmItemImageSetup.ShowDialog()
        FrmItemImageSetup.Dispose()
        FrmItemImageSetup = Nothing

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        fSaveSystemControl(tabMenu)

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        fRefreshSystemSettings()
    End Sub

    Private Sub btnSystemDefault_Click(sender As Object, e As EventArgs) Handles btnSystemDefault.Click
        frmSystemDefault.ShowDialog()
        frmSystemDefault.Dispose()
        frmSystemDefault = Nothing

    End Sub

    Private Sub btnDefaultValue_Click(sender As Object, e As EventArgs) Handles btnDefaultValue.Click
        frmDefaultValue.ShowDialog()
        frmDefaultValue.Dispose()
        frmDefaultValue = Nothing
    End Sub
End Class