Imports System.Data.Odbc
Public Class FrmSubDiscountDetails
    Public ID As Integer
    Public IsNew As Boolean = True

    Private Sub FrmSubDiscountDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With dgvSub.Columns
            .Add("ID", "ID")
            .Item(0).Visible = False
            .Add("FROM", "From")
            .Add("TO", "To")
            .Add("PERCENT", "Percent")

        End With


        If IsNew = False Then
            RefreshDetials()
        End If
    End Sub
    Private Sub RefreshDetials()
        dgvSub.Rows.Clear()

        Try

            SqlExecutedUsingReading(Me, "select * from sub_discount where id = '" & ID & "'")

            Dim rd As OdbcDataReader = SqlReader("select ID,AMOUNT_FROM,AMOUNT_TO,PERCENT FROM SUB_DISCOUNT_DETAILS WHERE sub_discount_ID = '" & ID & "' ")
            While rd.Read
                dgvSub.Rows.Add(GF_NumIsNull(rd("ID")), GF_NumIsNull(rd("AMOUNT_FROM")), GF_NumIsNull(rd("AMOUNT_TO")), GF_NumIsNull(rd("PERCENT")))
            End While

            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                RefreshDetials()
            Else
                End
            End If

        End Try
    End Sub
    Private Sub TsSaveNew_Click(sender As Object, e As EventArgs) Handles tsSaveNew.Click
        If txtCODE.Text = "" Then
            MessageBoxInfo("Please enter code")
            Exit Sub
        End If

        If txtDESCRIPTION.Text = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If
        Try

            If IsNew = True Then
                ID = GF_GetMaxField("ID", "sub_discount")
                SqlCreate(Me, SQL_Field, SQL_Value)
                SqlExecuted($"INSERT INTO sub_discount ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")
            Else
                SqlExecuted("UPDATE sub_discount SET " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
            End If

            For i As Integer = 0 To dgvSub.Rows.Count - 1
                With dgvSub.Rows(i)
                    If IsNew = True Then

                        SqlExecuted("INSERT INTO sub_discount_details SET sub_discount_id = '" & ID & "',AMOUNT_FROM = '" & GF_NumIsNull(.Cells(1).Value) & "',AMOUNT_TO = '" & GF_NumIsNull(.Cells(2).Value) & "',PERCENT='" & GF_NumIsNull(.Cells(3).Value) & "'")
                    Else
                        If .Visible = False Then
                            SqlExecuted("DELETE FROM sub_discount_details WHERE id = '" & .Cells(0).Value & "'and sub_discount_id = '" & ID & "'")
                        ElseIf GF_NumIsNull(.Cells(0).Value) = 0 Then

                            SqlExecuted("INSERT INTO sub_discount_details SET sub_discount_id = '" & ID & "',AMOUNT_FROM = '" & GF_NumIsNull(.Cells(1).Value) & "',AMOUNT_TO = '" & GF_NumIsNull(.Cells(2).Value) & "',PERCENT='" & GF_NumIsNull(.Cells(3).Value) & "'")
                        Else
                            SqlExecuted("UPDATE sub_discount_details SET AMOUNT_FROM = '" & GF_NumIsNull(.Cells(1).Value) & "',AMOUNT_TO = '" & GF_NumIsNull(.Cells(2).Value) & "',PERCENT='" & GF_NumIsNull(.Cells(3).Value) & "'WHERE id = '" & .Cells(0).Value & "'and sub_discount_id = '" & ID & "'")
                        End If

                    End If
                End With
            Next
            Me.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub

    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click
        Me.Close()
    End Sub
    Private Sub NumAMOUNT_FROM_KeyDown(sender As Object, e As KeyEventArgs) Handles numAMOUNT_FROM.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub NumTO_AMOUNT_KeyDown(sender As Object, e As KeyEventArgs) Handles numTO_AMOUNT.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub NumPercent_KeyDown(sender As Object, e As KeyEventArgs) Handles numPercent.KeyDown
        If e.KeyCode = Keys.Enter Then
            If numAMOUNT_FROM.Value = 0 And numTO_AMOUNT.Value = 0 Then
                MessageBoxInfo("Volume not set")
                Exit Sub
            End If
            If numPercent.Value = 0 Then
                MessageBoxInfo("Please enter percent")
            End If
            If dgvSub.Enabled = False Then
                Dim i As Integer = dgvSub.CurrentRow.Index
                With dgvSub.Rows(i)
                    .Cells(0).Value = IIf(GF_NumIsNull(.Cells(0).Value) = 0, "A", .Cells(0).Value)
                    .Cells(1).Value = numAMOUNT_FROM.Value
                    .Cells(2).Value = numTO_AMOUNT.Value
                    .Cells(3).Value = numPercent.Value

                End With
            Else
                dgvSub.Rows.Add("A", numAMOUNT_FROM.Value, numTO_AMOUNT.Value, numPercent.Value)
            End If
            dgvSub.Enabled = True
            ClearAndRefresh(GroupBox1)
            numAMOUNT_FROM.Focus()
        End If
    End Sub

    Private Sub DgvSub_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSub.CellDoubleClick
        If dgvSub.Rows.Count <> 0 Then
            numAMOUNT_FROM.Value = dgvSub.Rows(e.RowIndex).Cells(1).Value
            numTO_AMOUNT.Value = dgvSub.Rows(e.RowIndex).Cells(2).Value
            numPercent.Value = dgvSub.Rows(e.RowIndex).Cells(3).Value
            dgvSub.Enabled = False

        End If
    End Sub

    Private Sub DgvSub_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvSub.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvSub.Rows.Count <> 0 Then
                Dim i As Integer = dgvSub.CurrentRow.Index
                If GF_NumIsNull(dgvSub.Rows(i).Cells(0).Value) = 0 Then
                    dgvSub.Rows.RemoveAt(i)
                Else
                    dgvSub.Rows(i).Visible = False
                End If
            End If
        End If

    End Sub
End Class