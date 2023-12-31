﻿Imports System.Data.Odbc
Public Class FrmSettings
    Private Sub ControlRotation(ByVal prName As String, ByVal prValue As String)
        Try


            'tab 1
            For i As Integer = 0 To TabPage1.Controls.Count - 1
                If GetSettingObject(prName, TabPage1, i) = True Then

                    SetSettingObject(TabPage1, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 2
            For i As Integer = 0 To TabPage2.Controls.Count - 1
                If GetSettingObject(prName, TabPage2, i) = True Then

                    SetSettingObject(TabPage2, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 3
            For i As Integer = 0 To TabPage3.Controls.Count - 1
                If GetSettingObject(prName, TabPage3, i) = True Then

                    SetSettingObject(TabPage3, i, prValue)
                    Exit Sub

                End If
            Next

            'tab 4
            For i As Integer = 0 To TabPage4.Controls.Count - 1
                If GetSettingObject(prName, TabPage4, i) = True Then

                    SetSettingObject(TabPage4, i, prValue)
                    Exit Sub
                End If
            Next


            'tab 5
            For i As Integer = 0 To TabPage5.Controls.Count - 1
                If GetSettingObject(prName, TabPage5, i) = True Then

                    SetSettingObject(TabPage5, i, prValue)
                    Exit Sub
                End If
            Next



            'tab 6
            For i As Integer = 0 To TabPage6.Controls.Count - 1
                If GetSettingObject(prName, TabPage6, i) = True Then

                    SetSettingObject(TabPage6, i, prValue)
                    Exit Sub
                End If
            Next


            'tab 7
            For i As Integer = 0 To TabPage7.Controls.Count - 1
                If GetSettingObject(prName, TabPage7, i) = True Then
                    SetSettingObject(TabPage7, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 8
            For i As Integer = 0 To TabPage8.Controls.Count - 1

                If GetSettingObject(prName, TabPage8, i) = True Then

                    SetSettingObject(TabPage8, i, prValue)
                    Exit Sub

                End If
            Next
            'tab 9

            '===============================================================================
            For i As Integer = 0 To GroupBox1.Controls.Count - 1
                If GetSettingObject(prName, GroupBox1, i) = True Then

                    SetSettingObject(GroupBox1, i, prValue)
                    Exit Sub

                End If
            Next


            For i As Integer = 0 To GroupBox2.Controls.Count - 1
                If GetSettingObject(prName, GroupBox2, i) = True Then
                    SetSettingObject(GroupBox2, i, prValue)
                    Exit Sub

                End If
            Next


            For i As Integer = 0 To GroupBox3.Controls.Count - 1
                If GetSettingObject(prName, GroupBox3, i) = True Then
                    SetSettingObject(GroupBox3, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox4.Controls.Count - 1
                If GetSettingObject(prName, GroupBox4, i) = True Then
                    SetSettingObject(GroupBox4, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox5.Controls.Count - 1
                If GetSettingObject(prName, GroupBox5, i) = True Then
                    SetSettingObject(GroupBox5, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox6.Controls.Count - 1
                If GetSettingObject(prName, GroupBox6, i) = True Then
                    SetSettingObject(GroupBox6, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox7.Controls.Count - 1
                If GetSettingObject(prName, GroupBox7, i) = True Then
                    SetSettingObject(GroupBox7, i, prValue)
                    Exit Sub
                End If
            Next

            For i As Integer = 0 To GroupBox8.Controls.Count - 1
                If GetSettingObject(prName, GroupBox8, i) = True Then
                    SetSettingObject(GroupBox8, i, prValue)
                    Exit Sub
                End If
            Next

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Sub RefreshSystemSettings()
        Try

            Dim rd As OdbcDataReader = SqlReader("select `NAME`,`VALUE` from system_settings  ")
            While rd.Read
                ControlRotation(rd("NAME"), rd("VALUE"))
            End While
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshSystemSettings()
            Else
                End
            End If

        End Try

    End Sub

    Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If gsSYSTEM_UPGRADE <> 1 Then
            TabPage3.Visible = False
        End If

        RefreshComboBox()
        RefreshSystemSettings()
        numServiceFee.DecimalPlaces = 0
        numManagerRebites.DecimalPlaces = 0
        numManagerGetDealerSalesTarget.DecimalPlaces = 0



    End Sub
    Private Sub RefreshComboBox()

        GS_ComboBoxLoad(cmbDefaultVendorID, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('0') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        '   Dim sQueryAccount As String = "SELECT a.ID, CONCAT(a.NAME ,' / ', atm.Description)  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        Dim sQueryAccount As String = "SELECT a.ID, a.NAME  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"
        GS_ComboBoxLoad(cmbDefaultLocationId, "select * from location where inactive ='0' ", "ID", "NAME")
        GS_ComboBoxLoad(cmbStorageLocationId, "select * from location where inactive ='0' ", "ID", "NAME")

        GS_ComboBoxLoad(cmbNewTransactionsDefaultDate, "SELECT '0' AS ID , 'Use today`s date' AS `NAME` UNION SELECT '1' AS ID , 'Use the last entered date' AS `NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbDefaultPaymentMethodId, "select ID,DESCRIPTION from payment_method", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbDefaultPaymentTermsId, "select ID,DESCRIPTION from payment_terms", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbCreditLimitPolicy, "SELECT '0' AS ID , 'Promp warning message only' AS `NAME` UNION SELECT '1' AS ID , 'Enforce transaction blocking' AS `NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbArAgingLimit, "SELECT '0' AS ID , 'None' AS `NAME` UNION SELECT '1' AS ID , 'Current balance only' UNION SELECT '2' AS ID , '1 - 30 day past due' AS `NAME` UNION SELECT '3' AS ID ,'31 - 60 day past due' AS `NAME`UNION SELECT '4' AS ID ,'61 - 90 day past due' AS `NAME` ; ", "ID", "NAME")

        GS_ComboBoxLoad(cmbFinanceChargeItemId, "select ID,concat(CODE,' / ',DESCRIPTION) as T from item where type='4' and inactive = '0' order by DESCRIPTION", "ID", "T")
        GS_ComboBoxLoad(cmbDefaultItemStockType, "select ID,DESCRIPTION from stock_type_map", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbDefaultForecastingType, "SELECT '0' AS ID , 'Monthly' AS `NAME` UNION SELECT '1' AS ID , 'Weekly' AS `NAME` ", "ID", "NAME")
        GS_ComboBoxLoad(cmbDefaultPenaltyType, "Select '0' as  ID, 'NO PENALTY' as DESCRIPTION UNION select ID,DESCRIPTION  FROM PENALTY_TYPE_MAP", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbTargetPenaltyDiscount, "select ID,DESCRIPTION FROM item where `TYPE` = '7' ", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbTaxPayableAccountId, sQueryAccount, "ID", "T")
        GS_ComboBoxLoad(cmbTaxCreditAccountId, sQueryAccount, "ID", "T")
        GS_ComboBoxLoad(cmbFinanceChargeAccountId, sQueryAccount, "ID", "T")




        GS_ComboBoxLoad(cmbOutputTaxId, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
        GS_ComboBoxLoad(cmbInputTaxId, "select * from tax where tax_type='3' order by ID DESC", "ID", "NAME")
    End Sub
    Private Sub CmbDefaultPenaltyType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDefaultPenaltyType.SelectedIndexChanged
        If cmbDefaultPenaltyType.SelectedValue IsNot Nothing Then

            If GF_NumIsNull(cmbDefaultPenaltyType.SelectedValue) = 3 Then

                cmbTargetPenaltyDiscount.Enabled = True
            Else
                cmbTargetPenaltyDiscount.Enabled = False
            End If
        End If
    End Sub


    Private Sub FrmSettings_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        LoadDefaultAccount()
    End Sub
    Private Sub BtnEmailSetup_Click(sender As Object, e As EventArgs) Handles btnEmailSetup.Click

        FrmEmailSetup.ShowDialog()
        FrmEmailSetup.Dispose()
        FrmEmailSetup = Nothing

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnImageSetup.Click
        FrmItemImageSetup.ShowDialog()
        FrmItemImageSetup.Dispose()
        FrmItemImageSetup = Nothing

    End Sub
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveSystemControl(tabMenu)

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RefreshSystemSettings()
    End Sub

    Private Sub BtnSystemDefault_Click(sender As Object, e As EventArgs) Handles btnSystemDefault.Click
        FrmSystemDefault.ShowDialog()
        FrmSystemDefault.Dispose()
        FrmSystemDefault = Nothing

    End Sub

    Private Sub BtnDefaultValue_Click(sender As Object, e As EventArgs) Handles btnDefaultValue.Click
        FrmDefaultValue.ShowDialog()
        FrmDefaultValue.Dispose()
        FrmDefaultValue = Nothing
    End Sub
End Class