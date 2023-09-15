Imports System.Data.Odbc
Public Class FrmDefaultValue
    Private Sub ControlRotation(ByVal prName As String, ByVal prValue As String)
        Try


            'tab 1
            For i As Integer = 0 To tpAccount.Controls.Count - 1
                If GetSettingObject(prName, tpAccount, i) = True Then
                    SetSettingObject(tpAccount, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 2
            For i As Integer = 0 To tpItem.Controls.Count - 1
                If GetSettingObject(prName, tpItem, i) = True Then
                    SetSettingObject(tpItem, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 3
            For i As Integer = 0 To tpPOS.Controls.Count - 1
                If GetSettingObject(prName, tpPOS, i) = True Then
                    SetSettingObject(tpPOS, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 4
            For i As Integer = 0 To tpOther.Controls.Count - 1
                If GetSettingObject(prName, tpOther, i) = True Then
                    SetSettingObject(tpOther, i, prValue)
                    Exit Sub
                End If
            Next

        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Sub FrmDefaultAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sQueryAccount As String = "SELECT a.ID, a.NAME  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"


        Dim cmd As OdbcCommand = GF_CommandObject(sQueryAccount)

        ' GS_CommandObjectComboBoxLoad(cmd, cmbDefaultAccountReceivableId, "ID", "T")
        GS_ComboBoxLoad(cmbPOSDefaultCustomerId, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultAccountReceivableId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultAccountPayableId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultUndepositedFundAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultItemAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbStockTransferAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbStockReceivedAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbInterLocationAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDrawerAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbPettyCashAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbCashOverShortExpenseId, "ID", "T")

        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultItemAssetAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultItemCOGSAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultItemIncomeAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultItemOtherChargeAccountId, "ID", "T")
        GS_CommandObjectComboBoxLoad(cmd, cmbDefaultItemDiscountAccountId, "ID", "T")

        '

        GS_ComboBoxLoad(cmbDefaultItemClassId, "select * from item_class  ", "ID", "DESCRIPTION")
        GS_ComboBoxLoad(cmbmeasure_hours, "SELECT ID,NAME FROM `unit_of_measure`", "ID", "NAME")



        With cboDateRangeDefault.Items
            .Add("Today")
            .Add("Yesterday")
            .Add("Last 7 Days")
            .Add("Last 30 Days")
            .Add("This Month")
            .Add("Last Month")
            .Add("This Year")
            .Add("Last Year")
        End With



        Dim rd As OdbcDataReader = SqlReader("select `NAME`,`VALUE` from system_settings  ")
        While rd.Read
            ControlRotation(rd("NAME"), rd("VALUE"))
        End While
        rd.Close()


    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        SaveSystemControl(tabMenu)
        Me.Close()

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CmbDefaultItemClassId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDefaultItemClassId.SelectedIndexChanged
        Dim CLASS_ID As Integer = 0
        Try
            CLASS_ID = cmbDefaultItemClassId.SelectedValue

        Catch ex As Exception

        End Try

        GS_ComboBoxLoad(cmbDefaultItemSubClassId, $"SELECT * FROM item_sub_class WHERE CLASS_ID ='{CLASS_ID}' ", "ID", "DESCRIPTION")
    End Sub
End Class