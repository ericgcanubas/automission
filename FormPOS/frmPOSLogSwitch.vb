Imports System.Data.Odbc
Public Class FrmPOSLogSwitch
    Public gsStartNew As Boolean = False
    Private Sub FrmPOSLogSwitch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim POS_COUNT As Integer = 0
        Dim EntryCount As Integer = 0
        Dim CashCount As Double = 0
        lblDate.Text = DateFormatStandard(gsPOS_DATE)
        Dim rd As OdbcDataReader = SqlReader($"select  l.TRANSACTION_COUNT,c.TOTAL  from POS_LOG as l inner join  POS_CASH_COUNT as C  on c.ID = l.CASH_COUNT_ID Where  DATE(l.recorded_On) ='{DateFormatMySql(gsPOS_DATE)}' and l.POS_MACHINE_ID='{gsPOS_MACHINE_ID}' and l.CASHIER_ID = '{gsCashier_ID}' and l.LOCATION_ID ='{gsDefault_LOCATION_ID}'")

        While rd.Read
            EntryCount += GF_NumIsNull(rd("TRANSACTION_COUNT"))
            CashCount += GF_NumIsNull(rd("TOTAL"))

            lblLastCashCount.Text = GF_NumIsNull(rd("TOTAL"))
            lblLastCountEntry.Text = GF_NumIsNull(rd("TRANSACTION_COUNT"))

            POS_COUNT += 1

        End While

        lblTotalCashCount.Text = CashCount
        lblTotalCountEntry.Text = EntryCount
        lblLogCount.Text = POS_COUNT

        gsStartNew = False

    End Sub

    Private Sub BtnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        gsStartNew = True
        Me.Close()
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()
    End Sub
End Class