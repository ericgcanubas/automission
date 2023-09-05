Public Class frmPOSTransactionList
    Public gsBS As BindingSource
    Public gsResume As Boolean = False
    Public gsNew As Boolean = False
    Public Select_POS_LOG_ID As Integer
    Dim FirstLoad As Boolean = True
    Private Sub frmPOSTransactionList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fReload()
    End Sub
    Private Sub fReload()
        Select_POS_LOG_ID = 0

        fDataGridView_Binding(dgvLIST, $"select pl.ID,pl.RECORDED_ON as `CREATED ON`,pl.TRANSACTION_DATE as `DATE`, format( ifnull( pl.TOTAL,0),2) as `SALES`, format( ifnull( PSC.AMOUNT,0),2) AS `STARTING CASH`, format( ifnull(PCC.TOTAL,0),2) AS `CASH COUNT`, if(ifnull( PL.CASH_COUNT_ID,0)=0,'No','Yes') as `COUNTED` from POS_LOG as pl LEFT OUTER JOIN POS_STARTING_CASH AS PSC ON  PSC.ID = PL.STARTING_CASH_ID  LEFT OUTER JOIN POS_CASH_COUNT AS PCC ON PCC.ID = PL.CASH_COUNT_ID WHERE pl.POS_MACHINE_ID = '{gsPOS_MACHINE_ID}' and pl.CASHIER_ID = '{gsCashier_ID}' and pl.LOCATION_ID = '{gsDefault_LOCATION_ID}'  order by pl.ID DESC LIMIT {numLOG.Value} ", gsBS)

        fDgvNotSort(dgvLIST)
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
    Private Sub dgvLIST_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvLIST.CellDoubleClick
        tsUpdateItem.PerformClick()
    End Sub

    Private Sub fKeydown(sender As Object, e As KeyEventArgs)

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

    Private Sub dgvLIST_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvLIST.KeyDown
        fKeydown(sender, e)
    End Sub

    Private Sub frmPOSTransactionList_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        fKeydown(sender, e)
    End Sub

    Private Sub numLOG_ValueChanged(sender As Object, e As EventArgs) Handles numLOG.ValueChanged
        If FirstLoad = False Then
            fReload()
        End If
    End Sub

    Private Sub frmPOSTransactionList_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        FirstLoad = False
    End Sub

    Private Sub tsCancel_Click(sender As Object, e As EventArgs) Handles tsCancel.Click
        gsResume = False
        gsNew = False
        Me.Close()
    End Sub

    Private Sub tsUpdateItem_Click(sender As Object, e As EventArgs) Handles tsUpdateItem.Click
        If dgvLIST.Rows.Count = 0 Then
            fMessageboxInfo("Data not found.")
            Exit Sub
        End If
        dgvLIST.Select()

        If dgvLIST.CurrentRow.Cells(6).Value = "Yes" Then
            fMessageboxInfo("This transaction has been cash counted. please contact the administrator to modify.")
            Exit Sub
        End If

        Select_POS_LOG_ID = dgvLIST.CurrentRow.Cells(0).Value

        gsResume = True
        gsNew = False

        Me.Close()
    End Sub

    Private Sub tsAdd_Click(sender As Object, e As EventArgs) Handles tsAdd.Click
        If dgvLIST.Rows.Count <> 0 Then

            For N As Integer = 0 To dgvLIST.Rows.Count - 1
                'checking got not cash count.
                Dim R As DataGridViewRow = dgvLIST.Rows(N)

                If R.Cells(6).Value = "No" Then
                    fMessageboxWarning("Please create cash count all pending pos log.")
                    Exit Sub
                End If
            Next

        End If

        Dim DatesSelected As Boolean = False
        gsPOS_DATE = Date.Now
        If fNumFieldValue("USER_DEFAULT", "USER_ID", gsUser_ID, "pos_select_date") <> 0 Then
            frmSelectDate.ShowDialog()

            If frmSelectDate.gsOK = True Then
                gsPOS_DATE = frmSelectDate.dtpSelect.Value
                DatesSelected = True
            Else
                fMessageboxWarning("Transaction canceled. please select date.")
                DatesSelected = False
            End If

            frmSelectDate.Dispose()
            frmSelectDate = Nothing
        Else
            DatesSelected = True
        End If

        If DatesSelected = False Then
            Exit Sub
        End If

        dtpDATE.Value = gsPOS_DATE

        If fIsClosingDate(dtpDATE.Value, True) = False Then
            Exit Sub
        End If

        gsResume = False
        gsNew = True
        Me.Close()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class