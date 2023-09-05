Imports System.Data.Odbc
Public Class frmSubDiscountDetails
    Public gsID As String
    Public gsNew As Boolean = True

    Private Sub frmSubDiscountDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvSub.Columns
            .Add("ID", "ID")
            .Item(0).Visible = False
            .Add("FROM", "From")
            .Add("TO", "To")
            .Add("PERCENT", "Percent")

        End With
        fDatagridViewMode(dgvSub)
        fBackGroundImageStyle(Me)
        If gsNew = False Then
            fRefreshDetials(gsID)
        End If
    End Sub
    Private Sub fRefreshDetials(ByVal prID As Integer)
        dgvSub.Rows.Clear()

        Try

            fExecutedUsingReading(Me, "select * from sub_discount where id = '" & gsID & "'")

            Dim rd As OdbcDataReader = fReader("select ID,AMOUNT_FROM,AMOUNT_TO,PERCENT FROM SUB_DISCOUNT_DETAILS WHERE sub_discount_ID = '" & gsID & "' ")
            While rd.Read
                dgvSub.Rows.Add(fNumisNULL(rd("ID")), fNumisNULL(rd("AMOUNT_FROM")), fNumisNULL(rd("AMOUNT_TO")), fNumisNULL(rd("PERCENT")))
            End While

            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fRefreshDetials(prID)
            Else
                End
            End If

        End Try
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If txtCODE.Text = "" Then
            fMessageboxInfo("Please enter code")
            Exit Sub
        End If

        If txtDESCRIPTION.Text = "" Then
            fMessageboxInfo("Please enter description")
            Exit Sub
        End If
        Try


            Dim sQuery As String = fFieldCollector(Me)

            If gsNew = True Then
                gsID = fGetMaxField("ID", "sub_discount")
                fExecutedOnly("INSERT INTO sub_discount SET ID = '" & gsID & "'," & sQuery)

            Else
                fExecutedOnly("UPDATE sub_discount SET " & sQuery & " Where ID = '" & gsID & "'")
            End If

            For i As Integer = 0 To dgvSub.Rows.Count - 1
                With dgvSub.Rows(i)
                    If gsNew = True Then

                        fExecutedOnly("INSERT INTO sub_discount_details SET sub_discount_id = '" & gsID & "',AMOUNT_FROM = '" & fNumisNULL(.Cells(1).Value) & "',AMOUNT_TO = '" & fNumisNULL(.Cells(2).Value) & "',PERCENT='" & fNumisNULL(.Cells(3).Value) & "'")
                    Else
                        If .Visible = False Then
                            fExecutedOnly("DELETE FROM sub_discount_details WHERE id = '" & .Cells(0).Value & "'and sub_discount_id = '" & gsID & "'")
                        ElseIf fNumisNULL(.Cells(0).Value) = 0 Then

                            fExecutedOnly("INSERT INTO sub_discount_details SET sub_discount_id = '" & gsID & "',AMOUNT_FROM = '" & fNumisNULL(.Cells(1).Value) & "',AMOUNT_TO = '" & fNumisNULL(.Cells(2).Value) & "',PERCENT='" & fNumisNULL(.Cells(3).Value) & "'")
                        Else
                            fExecutedOnly("UPDATE sub_discount_details SET AMOUNT_FROM = '" & fNumisNULL(.Cells(1).Value) & "',AMOUNT_TO = '" & fNumisNULL(.Cells(2).Value) & "',PERCENT='" & fNumisNULL(.Cells(3).Value) & "'WHERE id = '" & .Cells(0).Value & "'and sub_discount_id = '" & gsID & "'")
                        End If

                    End If
                End With

            Next


            Me.Close()
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub

    Private Sub numAMOUNT_FROM_ValueChanged(sender As Object, e As EventArgs) Handles numAMOUNT_FROM.ValueChanged

    End Sub

    Private Sub numAMOUNT_FROM_KeyDown(sender As Object, e As KeyEventArgs) Handles numAMOUNT_FROM.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub numTO_AMOUNT_ValueChanged(sender As Object, e As EventArgs) Handles numTO_AMOUNT.ValueChanged

    End Sub

    Private Sub numTO_AMOUNT_KeyDown(sender As Object, e As KeyEventArgs) Handles numTO_AMOUNT.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub numPercent_ValueChanged(sender As Object, e As EventArgs) Handles numPercent.ValueChanged

    End Sub

    Private Sub numPercent_KeyDown(sender As Object, e As KeyEventArgs) Handles numPercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            If numAMOUNT_FROM.Value = 0 And numTO_AMOUNT.Value = 0 Then
                fMessageboxInfo("Volume not set")
                Exit Sub
            End If
            If numPercent.Value = 0 Then
                fMessageboxInfo("Please enter percent")
            End If
            If dgvSub.Enabled = False Then
                Dim i As Integer = dgvSub.CurrentRow.Index
                With dgvSub.Rows(i)
                    .Cells(0).Value = IIf(fNumisNULL(.Cells(0).Value) = 0, "A", .Cells(0).Value)
                    .Cells(1).Value = numAMOUNT_FROM.Value
                    .Cells(2).Value = numTO_AMOUNT.Value
                    .Cells(3).Value = numPercent.Value

                End With
            Else
                dgvSub.Rows.Add("A", numAMOUNT_FROM.Value, numTO_AMOUNT.Value, numPercent.Value)
            End If
            dgvSub.Enabled = True
            fCLean_and_refresh(GroupBox1)
            numAMOUNT_FROM.Focus()
        End If
    End Sub

    Private Sub dgvSub_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellContentClick

    End Sub

    Private Sub dgvSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellDoubleClick
        If dgvSub.Rows.Count <> 0 Then

            numAMOUNT_FROM.Value = dgvSub.Rows(e.RowIndex).Cells(1).Value
            numTO_AMOUNT.Value = dgvSub.Rows(e.RowIndex).Cells(2).Value
            numPercent.Value = dgvSub.Rows(e.RowIndex).Cells(3).Value
            dgvSub.Enabled = False

        End If
    End Sub

    Private Sub dgvSub_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSub.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvSub.Rows.Count <> 0 Then
                Dim i As Integer = dgvSub.CurrentRow.Index
                If fNumisNULL(dgvSub.Rows(i).Cells(0).Value) = 0 Then
                    dgvSub.Rows.RemoveAt(i)
                Else
                    dgvSub.Rows(i).Visible = False
                End If





            End If
        End If

    End Sub
End Class