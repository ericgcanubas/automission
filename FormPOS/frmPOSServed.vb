Imports System.Data.Odbc
Public Class FrmPOSServed
    Public gsOK As Boolean = False
    Public gsTABLE_NO As Integer
    Public gsORDER_TYPE As Integer
    Public gsCUSTOMER_ID As Integer

    Private Sub FrmPOSServed_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xlblCustomer_Name.Text = GetStringFieldValue("CONTACT", "id", gsCUSTOMER_ID, "NAME")
        gsOK = False

        'Create Column
        With dgvAVAILABLE.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("CODE", "ORDER NO.")
            .Add("AMOUNT", "AMOUNT")
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        End With

        With dgvSELECTED.Columns
            .Clear()
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("CODE", "ORDER NO.")

            .Add("AMOUNT", "AMOUNT")
            .Item("AMOUNT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("AMOUNT").DefaultCellStyle.Format = "N2"
            .Item("AMOUNT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

        End With
        fAvailable_Load()

    End Sub
    Private Sub fAvailable_Load()
        dgvAVAILABLE.Rows.Clear()
        Dim rd As OdbcDataReader = SqlReader($"SELECT s.ID,s.CODE, s.AMOUNT FROM sales_order as s  WHERE s.CUSTOMER_ID = '{gsCUSTOMER_ID}' and s.LOCATION_ID ='{gsDefault_LOCATION_ID}' and  s.SHIP_TO ='{gsTABLE_NO}' and s.SHIP_VIA_ID='{gsORDER_TYPE}' and s.STATUS in('16')")
        While rd.Read
            dgvAVAILABLE.Rows.Add(rd(0), rd(1), rd(2))
        End While
        rd.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub BtnAddAll_Click(sender As Object, e As EventArgs) Handles btnAddAll.Click


        For S As Integer = 0 To dgvAVAILABLE.Rows.Count - 1
            Dim A As DataGridViewRow = dgvAVAILABLE.Rows(0)
            dgvSELECTED.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value)
            dgvAVAILABLE.Rows.RemoveAt(0)
        Next



    End Sub

    Private Sub BtnRemoveAll_Click(sender As Object, e As EventArgs) Handles btnRemoveAll.Click
        For S As Integer = 0 To dgvSELECTED.Rows.Count - 1
            Dim A As DataGridViewRow = dgvSELECTED.Rows(0)
            dgvAVAILABLE.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value)
            dgvSELECTED.Rows.RemoveAt(0)
        Next
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If dgvAVAILABLE.Rows.Count = 0 Then Exit Sub
        dgvAVAILABLE.Select()
        Dim A As DataGridViewRow = dgvAVAILABLE.CurrentRow
        dgvSELECTED.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value)
        dgvAVAILABLE.Rows.RemoveAt(dgvAVAILABLE.CurrentRow.Index)
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgvSELECTED.Rows.Count = 0 Then Exit Sub
        dgvSELECTED.Select()
        Dim A As DataGridViewRow = dgvSELECTED.CurrentRow
        dgvAVAILABLE.Rows.Add(A.Cells(0).Value, A.Cells(1).Value, A.Cells(2).Value)
        dgvSELECTED.Rows.RemoveAt(dgvSELECTED.CurrentRow.Index)

    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click


        If dgvSELECTED.Rows.Count = 0 Then

            If MessageBoxPointOfSalesYesNO("NEW ORDER SERVED ONLY?") = False Then

                Exit Sub
            Else
                gsTABLE_NO = 0
            End If


        End If

        gsOK = True

        Me.Close()


    End Sub
End Class