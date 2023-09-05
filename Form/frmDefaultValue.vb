Imports System.Data.Odbc
Public Class frmDefaultValue
    Private Sub fControlRotation(ByVal prName As String, ByVal prValue As String)
        Try


            'tab 1
            For i As Integer = 0 To tpAccount.Controls.Count - 1
                If fGetObjectNow(prName, tpAccount, i) = True Then
                    fObject_Type(tpAccount, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 2
            For i As Integer = 0 To tpItem.Controls.Count - 1
                If fGetObjectNow(prName, tpItem, i) = True Then
                    fObject_Type(tpItem, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 3
            For i As Integer = 0 To tpPOS.Controls.Count - 1
                If fGetObjectNow(prName, tpPOS, i) = True Then
                    fObject_Type(tpPOS, i, prValue)
                    Exit Sub
                End If
            Next

            'tab 4
            For i As Integer = 0 To tpOther.Controls.Count - 1
                If fGetObjectNow(prName, tpOther, i) = True Then
                    fObject_Type(tpOther, i, prValue)
                    Exit Sub
                End If
            Next

        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
    End Sub
    Private Sub frmDefaultAccounts_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sQueryAccount As String = "SELECT a.ID, a.NAME  AS T FROM account AS a INNER JOIN account_type_map AS atm ON  atm.ID = a.TYPE  ORDER by FIELD(a.TYPE,'12','14','0','1','2','3','4','5','6','7','8','9','10','11','13'), a.NAME"


        Dim cmd As System.Data.Odbc.OdbcCommand = This_cmd_1(sQueryAccount)

        ' This_cmd_2(cmd, cmbDefaultAccountReceivableId, "ID", "T")
        fComboBox(cmbPOSDefaultCustomerId, "select c.id, c.`NAME` from contact as  c  where c.`type` in ('1') and c.inactive = '0' order by c.`NAME` ", "ID", "NAME")
        This_cmd_2(cmd, cmbDefaultAccountReceivableId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultAccountPayableId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultUndepositedFundAccountId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultItemAccountId, "ID", "T")
        This_cmd_2(cmd, cmbStockTransferAccountId, "ID", "T")
        This_cmd_2(cmd, cmbStockReceivedAccountId, "ID", "T")
        This_cmd_2(cmd, cmbInterLocationAccountId, "ID", "T")
        This_cmd_2(cmd, cmbDrawerAccountId, "ID", "T")
        This_cmd_2(cmd, cmbPettyCashAccountId, "ID", "T")
        This_cmd_2(cmd, cmbCashOverShortExpenseId, "ID", "T")

        This_cmd_2(cmd, cmbDefaultItemAssetAccountId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultItemCOGSAccountId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultItemIncomeAccountId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultItemOtherChargeAccountId, "ID", "T")
        This_cmd_2(cmd, cmbDefaultItemDiscountAccountId, "ID", "T")

        '

        fComboBox(cmbDefaultItemClassId, "select * from item_class  ", "ID", "DESCRIPTION")
        fComboBox(cmbmeasure_hours, "SELECT ID,NAME FROM `unit_of_measure`", "ID", "NAME")



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



        Dim rd As OdbcDataReader = fReader("select `NAME`,`VALUE` from system_settings  ")
        While rd.Read
            fControlRotation(rd("NAME"), rd("VALUE"))
        End While
        rd.Close()


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        fSaveSystemControl(tabMenu)
        Me.Close()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cmbDefaultItemClassId_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDefaultItemClassId.SelectedIndexChanged
        Dim CLASS_ID As Integer = 0
        Try
            CLASS_ID = cmbDefaultItemClassId.SelectedValue

        Catch ex As Exception

        End Try

        fComboBox(cmbDefaultItemSubClassId, $"SELECT * FROM item_sub_class WHERE CLASS_ID ='{CLASS_ID}' ", "ID", "DESCRIPTION")
    End Sub
End Class