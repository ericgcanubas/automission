Public Class FrmPOSTransactionList
    Public gsBS As BindingSource
    Public gsResume As Boolean = False
    Public gsNew As Boolean = False
    Public Select_POS_LOG_ID As Integer
    Dim FirstLoad As Boolean = True
    Private Sub FrmPOSTransactionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ReloadList()
    End Sub
    Private Sub ReloadList()
        Select_POS_LOG_ID = 0

        GS_LoadDataGridViewBinding(dgvLIST, $"select pl.ID,pl.RECORDED_ON as `CREATED ON`,pl.TRANSACTION_DATE as `DATE`, format( ifnull( pl.TOTAL,0),2) as `SALES`, format( ifnull( PSC.AMOUNT,0),2) AS `STARTING CASH`, format( ifnull(PCC.TOTAL,0),2) AS `CASH COUNT`, if(ifnull( PL.CASH_COUNT_ID,0)=0,'No','Yes') as `COUNTED` from POS_LOG as pl LEFT OUTER JOIN POS_STARTING_CASH AS PSC ON  PSC.ID = PL.STARTING_CASH_ID  LEFT OUTER JOIN POS_CASH_COUNT AS PCC ON PCC.ID = PL.CASH_COUNT_ID WHERE pl.POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' and pl.CASHIER_ID = '{gsCashier_ID}' and pl.LOCATION_ID = '{gsDefault_LOCATION_ID}'  order by pl.ID DESC LIMIT {numLOG.Value} ", gsBS)

        GS_ViewNotSort(dgvLIST)
        With dgvLIST
            .Columns(0).Visible = False

            .Columns(1).Width = 150
            .Columns(2).Width = 80


            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight


            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

            .Columns(6).Width = 70
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

    End Sub
    Private Sub DgvLIST_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLIST.CellDoubleClick
        tsUpdateItem.PerformClick()
    End Sub

    Private Sub MasterKeyDown(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.F1 Then
            tsAdd.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            tsUpdateItem.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            tsCancel.PerformClick()
        Else
            dgvLIST.Select()
        End If
    End Sub

    Private Sub DgvLIST_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvLIST.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub FrmPOSTransactionList_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        MasterKeyDown(sender, e)
    End Sub

    Private Sub NumLOG_ValueChanged(sender As Object, e As EventArgs) Handles numLOG.ValueChanged
        If FirstLoad = False Then
            ReloadList()
        End If
    End Sub

    Private Sub FrmPOSTransactionList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FirstLoad = False
    End Sub

    Private Sub TsCancel_Click(sender As Object, e As EventArgs) Handles tsCancel.Click
        gsResume = False
        gsNew = False
        Me.Close()
    End Sub

    Private Sub TsUpdateItem_Click(sender As Object, e As EventArgs) Handles tsUpdateItem.Click
        If dgvLIST.Rows.Count = 0 Then
            MessageBoxInfo("Data not found.")
            Exit Sub
        End If
        dgvLIST.Select()

        If dgvLIST.CurrentRow.Cells(6).Value = "Yes" Then
            MessageBoxInfo("This transaction has been cash counted. please contact the administrator to modify.")
            Exit Sub
        End If

        Select_POS_LOG_ID = dgvLIST.CurrentRow.Cells(0).Value

        gsResume = True
        gsNew = False

        Me.Close()
    End Sub

    Private Sub TsAdd_Click(sender As Object, e As EventArgs) Handles tsAdd.Click
        If dgvLIST.Rows.Count <> 0 Then

            For N As Integer = 0 To dgvLIST.Rows.Count - 1
                'checking got not cash count.
                Dim R As DataGridViewRow = dgvLIST.Rows(N)

                If R.Cells(6).Value = "No" Then
                    MessageBoxWarning("Please create cash count all pending pos log.")
                    Exit Sub
                End If
            Next

        End If

        gsPOS_DATE = Date.Now

        Dim DatesSelected As Boolean
        If GF_GetNumberFieldValue("USER_DEFAULT", "USER_ID", gsUser_ID, "pos_select_date") <> 0 Then
            FrmSelectDate.ShowDialog()

            If FrmSelectDate.gsOK = True Then
                gsPOS_DATE = FrmSelectDate.dtpSelect.Value
                DatesSelected = True
            Else
                MessageBoxWarning("Transaction canceled. please select date.")
                DatesSelected = False
            End If

            FrmSelectDate.Dispose()
            FrmSelectDate = Nothing
        Else
            DatesSelected = True
        End If

        If DatesSelected = False Then
            Exit Sub
        End If

        dtpDATE.Value = gsPOS_DATE

        If IsClosingDate(dtpDATE.Value, True) = False Then
            Exit Sub
        End If

        gsResume = False
        gsNew = True
        Me.Close()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class