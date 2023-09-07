Imports System.Data.Odbc
Public Class frmPriceLevelDetails
    Public ID As Integer
    Dim IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView

    Private Sub fCreateColumn()
        With dgvProductItem.Columns
            .Add("ID", "ID")
            .Item("ID").Visible = False
            .Add("ITEM_ID", "ITEM_ID")
            .Item("ITEM_ID").Visible = False
            .Add("CODE", "Item Code")
            .Add("Description", "Description")
            .Add("Unit_Price", "Unit Price")
            .Add("Custom_Price", "Custom Price")
            .Add("STATUS", "STATUS")
            .Item("STATUS").Visible = False

        End With
        DatagridViewMode(dgvProductItem)
    End Sub
    Private Sub frmPriceLevelDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fCreateColumn()
        ComboBoxLoad(cmbITEM_CODE, "select ID,CODE from item where inactive ='0' ", "ID", "CODE")
        ComboBoxLoad(cmbTYPE, "Select * from price_level_type_map", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbITEM_GROUP_ID, "select * from item_group", "ID", "DESCRIPTION")
    End Sub

    Private Sub cmbTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTYPE.SelectedIndexChanged
        Try
            If cmbTYPE.SelectedValue = 0 Then
                GroupBox1.Visible = False
                numRate.Value = 0
                numRate.Visible = True
                cmbITEM_GROUP_ID.Text = ""
                cmbITEM_GROUP_ID.Visible = True
                Me.Size = New Size(617, 278)
            Else
                GroupBox1.Location = New Point(12, 180)
                numRate.Value = 0
                numRate.Visible = False
                cmbITEM_GROUP_ID.Text = ""
                cmbITEM_GROUP_ID.Visible = False
                GroupBox1.Visible = True
                Me.Size = New Size(708, 481)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmPriceLevelDetails_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        With dgvProductItem.Columns
            .Item("CODE").Width = 100
            .Item("Description").Width = 300
            .Item("Unit_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Item("Custom_Price").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End With
        cmbTYPE_SelectedIndexChanged(sender, e)

        If ID > 0 Then

            Try
                SqlExecutedUsingReading(Me, "select * from price_level where ID = '" & ID & "' Limit 1")
                If cmbTYPE.SelectedValue = 1 Then
                    fLoadItem()
                End If
                IsNew = False

            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try
        End If
        ViewNotSort(dgvProductItem)
    End Sub
    Private Sub cmbITEM_CODE_LostFocus(sender As Object, e As EventArgs) Handles cmbITEM_CODE.LostFocus
        Try
            lblDescription.Text = GetStringFieldValue("item", "ID", cmbITEM_CODE.SelectedValue, "Description")
            lblRate.Text = Format(GetNumberFieldValue("item", "ID", cmbITEM_CODE.SelectedValue, "Rate"), "Standard")
        Catch ex As Exception
            lblDescription.Text = ""
            lblRate.Text = ""
        End Try


    End Sub
    Private Sub fLoadItem()
        dgvProductItem.Rows.Clear()

        Try

            Dim rd As OdbcDataReader = SqlReader("select pll.ID,pll.Item_ID,i.CODE,i.Description,format(i.rate,2) as `Unit_price`, format(pll.custom_price,2) as `Custom_Price` from price_level_lines as pll inner join item  as i on i.id = pll.item_id where pll.price_level_id = '" & ID & "'")
            While rd.Read
                dgvProductItem.Rows.Add(rd("ID"), rd("ITEM_ID"), TextIsNull(rd("CODE")), TextIsNull(rd("Description")), Format(NumIsNull(rd("Unit_price")), "Standard"), Format(NumIsNull(rd("Custom_Price")), "Standard"), "S")
            End While
            rd.Close()
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Function fCheckIsAlreadyExist() As Boolean
        Dim b As Boolean = False

        For i As Integer = 0 To dgvProductItem.Rows.Count - 1
            Dim r As DataGridViewRow = dgvProductItem.Rows(i)
            If r.Cells("ITEM_ID").Value = cmbITEM_CODE.SelectedValue Then
                b = True
                Exit For

            End If
        Next

        Return b
    End Function
    Private Sub fAddRows()
        Dim b As Boolean = fCheckIsAlreadyExist()
        If b = False Then
            dgvProductItem.Rows.Add("N", cmbITEM_CODE.SelectedValue, cmbITEM_CODE.Text, lblDescription.Text, lblRate.Text, NumberFormatStandard(numCUSTOM_PRICE.Value), "A")
        Else
            Dim K As Boolean = False

            For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                Dim r As DataGridViewRow = dgvProductItem.Rows(i)
                If r.Cells("STATUS").Value = "D" Then
                    r.Cells("STATUS").Value = "E"
                    r.Visible = True
                    r.Cells("CUSTOM_PRICE").Value = NumberFormatStandard(numCUSTOM_PRICE.Value)
                    K = True
                    Exit For
                End If
            Next

            If K = False Then
                MessageBoxInfo("Item is already exist!")
            End If
        End If

    End Sub
    Private Sub fEditRows()
        With dgvProductItem.Rows(dgvProductItem.CurrentRow.Index)
            .Cells("CUSTOM_PRICE").Value = NumberFormatStandard(numCUSTOM_PRICE.Value)
            .Cells("STATUS").Value = IIf(.Cells("ID").Value.ToString = "N", "A", "E")
        End With

    End Sub
    Private Sub numCUSTOM_PRICE_KeyDown(sender As Object, e As KeyEventArgs) Handles numCUSTOM_PRICE.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(cmbITEM_CODE.SelectedValue) = 0 Or numCUSTOM_PRICE.Value = 0 Then
                Exit Sub
            End If

            If cmbITEM_CODE.Enabled = False Then
                fEditRows()
                ClearAndRefresh(GroupBox1)
                cmbITEM_CODE.Enabled = True
                dgvProductItem.Enabled = True
            Else

                fAddRows()
                ClearAndRefresh(GroupBox1)
            End If
        ElseIf e.KeyCode = Keys.Escape Then

            ClearAndRefresh(GroupBox1)
            cmbITEM_CODE.Enabled = True
            dgvProductItem.Enabled = True
            cmbITEM_CODE.Focus()

        End If
    End Sub

    Private Sub dgvProductItem_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellContentClick

    End Sub

    Private Sub dgvProductItem_KeyDown(sender As Object, e As KeyEventArgs) Handles dgvProductItem.KeyDown
        If e.KeyCode = Keys.Delete Then
            If dgvProductItem.Rows.Count <> 0 Then
                If MessageBoxQuestion("Are you sure to delete this line?") = True Then
                    With dgvProductItem.Rows(dgvProductItem.CurrentRow.Index)
                        If .Cells("ID").Value.ToString = "N" Then
                            dgvProductItem.Rows.RemoveAt(dgvProductItem.CurrentRow.Index)
                        Else
                            .Visible = False
                            .Cells("STATUS").Value = "D"
                        End If

                    End With
                End If
            End If
        End If
    End Sub

    Private Sub dgvProductItem_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProductItem.CellDoubleClick
        If dgvProductItem.Rows.Count <> 0 Then
            Dim r As DataGridViewRow = dgvProductItem.CurrentRow
            cmbITEM_CODE.SelectedValue = r.Cells("ITEM_ID").Value
            cmbITEM_CODE_LostFocus(sender, e)
            numCUSTOM_PRICE.Value = NumIsNull(r.Cells("CUSTOM_PRICE").Value)
            cmbITEM_CODE.Enabled = False
            dgvProductItem.Enabled = False
        End If
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub
    Private Sub fPerItemUpdate()

        If cmbTYPE.SelectedValue = 1 Then
            For i As Integer = 0 To dgvProductItem.Rows.Count - 1
                Dim r As DataGridViewRow = dgvProductItem.Rows(i)

                Select Case r.Cells("STATUS").Value
                    Case "S"

                    Case "A"
                        SqlExecuted("INSERT INTO price_level_lines SET custom_price = '" & Format(r.Cells("custom_price").Value) & "', price_level_id ='" & ID & "' , ID = '" & GetMaxField("ID", "price_level_lines") & "' , ITEM_ID = '" & r.Cells("ITEM_ID").Value & "'")
                    Case "E"
                        SqlExecuted("UPDATE price_level_lines SET custom_price = '" & NumberFormatFixed(r.Cells("custom_price").Value) & "' where price_level_id ='" & ID & "' and ID = '" & r.Cells("ID").Value & "' and ITEM_ID = '" & r.Cells("ITEM_ID").Value & "'")
                    Case "D"
                        SqlExecuted("DELETE FROM price_level_lines where price_level_id ='" & ID & "' and ID = '" & r.Cells("ID").Value & "' and ITEM_ID = '" & r.Cells("ITEM_ID").Value & "'")
                End Select

            Next

        Else
            SqlExecuted("DELETE FROM price_level_lines where price_level_id ='" & ID & "'")
        End If

    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter price level description")
            Exit Sub
        End If

        If cmbTYPE.SelectedValue = 1 Then
            numRate.Value = 0
            cmbITEM_GROUP_ID.Text = ""
            If dgvProductItem.Rows.Count = 0 Then
                MessageBoxInfo("No item entry")
                Exit Sub
            End If
        End If

        If Trim(txtCODE.Text) = "" Then
            txtCODE.Text = Format(GetMaxField("CODE", "price_level"), "0000")
        End If


        If IsNew = False Then
            SqlExecuted("UPDATE price_level set " & SqlUpdate(Me) & "  where ID = '" & ID & "' limit 1;")
        Else
            ID = ObjectTypeMapId("price_level")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO price_level ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")


        End If
        SaveNotify(Me, IsNew)
        fPerItemUpdate()
        BindingViewUpdate(Dgv, $"Select pl.ID,pl.Code,pl.Description, pltm.`Description` as `Type`,ig.Description as `Item Group`, IF(pl.`Inactive`=0,'No','Yes') as `Inactive` from price_level as pl inner join price_level_type_map as pltm on pltm.id = pl.`type` left outer join item_group as ig on ig.id = pl.item_group_id  WHERE pl.ID = '{ID}' limit 1", IsNew, This_BS)
        IsNew = True
        dgvProductItem.Rows.Clear()
        ClearAndRefresh(Me)
        ID = 0

        If fACCESS_NEW_EDIT(frmPriceLevel, IsNew) = False Then
            Me.Close()
        End If

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class