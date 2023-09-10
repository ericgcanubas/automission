
Public Class FrmPaymentMethodsDetails
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Public ID As Integer
    Public IsNew As Boolean = True
    Private Sub frmPaymentMethodsDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ClearInfoModule()

        If ID > 0 Then

            Try
                SqlExecutedUsingReading(Me, "select * from payment_method where id = '" & ID & "' limit 1")
                IsNew = False
            Catch ex As Exception
                MessageBoxWarning(ex.Message)
            End Try


        End If
    End Sub
    Private Sub ClearInfoModule()
        ComboBoxLoad(cmbPAYMENT_TYPE, "select ID,DESCRIPTION from payment_type_map", "ID", "DESCRIPTION")
        ComboBoxLoad(cmbGL_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
        txtCODE.Clear()
        txtDESCRIPTION.Clear()
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            MessageBoxInfo("Please enter description")
            Exit Sub
        End If

        Me.Enabled = False

        If IsNew = False Then
            SqlExecuted("UPDATE payment_method  SET " & SqlUpdate(Me) & " Where ID = '" & ID & "'")
        Else

            If Trim(txtCODE.Text) = "" Then
                Dim bCODE_INTEGER As Double = Val(GetMaxField("CODE", "payment_method"))
                txtCODE.Text = bCODE_INTEGER.ToString("0000")
            End If

            ID = ObjectTypeMapId("payment_method")

            SqlCreate(Me, SQL_Field, SQL_Value)
            SqlExecuted($"INSERT INTO payment_method ({SQL_Field},ID) VALUES ({SQL_Value},{ID}) ")

        End If
        SaveNotify(Me, IsNew)
        BindingViewUpdate(Dgv, $"SELECT pm.`ID`,pm.`Code`,pm.`Description`,p.`DESCRIPTION` AS `Payment Type`, CONCAT(a.`NAME` , ' / ' ,a.`TYPE`) AS `G/L Account` FROM payment_method AS pm LEFT OUTER JOIN  payment_type_map AS p ON p.`ID` = pm.`PAYMENT_TYPE` LEFT OUTER JOIN account AS a ON a.`ID` = pm.`GL_ACCOUNT_ID` Where pm.`ID` = '{ID}' limit 1", IsNew, This_BS)
        ClearInfoModule()

        ID = 0
        IsNew = True
        Me.Enabled = True

        If SecurityAccessMode(frmPaymentMethods, IsNew) = False Then
            Me.Close()
        End If
    End Sub
End Class