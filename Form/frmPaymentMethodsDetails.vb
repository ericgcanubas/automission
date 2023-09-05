
Public Class frmPaymentMethodsDetails
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Public gsID As String
    Public gsNew As Boolean = True
    Private Sub frmPaymentMethodsDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fBackGroundImageStyle(Me)
        fClear_Info()

        If gsID <> "" Then

            Try

                fExecutedUsingReading(Me, "select * from payment_method where id = '" & gsID & "' limit 1")

                gsNew = False
            Catch ex As Exception

                fMessageboxWarning(ex.Message)
            End Try


        End If
    End Sub
    Private Sub fClear_Info()
        fComboBox(cmbPAYMENT_TYPE, "select ID,DESCRIPTION from payment_type_map", "ID", "DESCRIPTION")
        fComboBox(cmbGL_ACCOUNT_ID, "SELECT i.ID, concat(i.`NAME`,' / ',atm.`DESCRIPTION`) as `NAME` from account as i inner join account_type_map as atm on atm.ID = i.`Type` where i.INACTIVE ='0'", "ID", "NAME")
        txtCODE.Clear()
        txtDESCRIPTION.Clear()
    End Sub
    Private Sub tsClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub tsSaveNew_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub tsDiscard_Click(sender As Object, e As EventArgs)
        If gsNew = True Then
            fCLean_and_refresh(Me)
        Else
            If fMessageBoxQuestion("Create new?") = True Then
                gsNew = True
                gsID = ""
                fCLean_and_refresh(Me)
            Else

                fExecutedUsingReading(Me, "select * from payment_method where id = '" & gsID & "' limit 1")
            End If
        End If
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If Trim(txtDESCRIPTION.Text) = "" Then
            fMessageboxInfo("Please enter description")
            Exit Sub
        End If

        Me.Enabled = False

        If gsNew = False Then

            Dim sql As String = fFieldCollector(Me)
            fExecutedOnly("UPDATE payment_method  set " & sql & " Where ID = '" & gsID & "' limit 1")
        Else

            If Trim(txtCODE.Text) = "" Then
                Dim bCODE_INTEGER As Double = Val(fGetMaxField("CODE", "payment_method"))
                txtCODE.Text = bCODE_INTEGER.ToString("0000")
            End If
            Dim sql As String = fFieldCollector(Me)
            gsID = fObjectTypeMap_ID("payment_method")
            fExecutedOnly("INSERT INTO payment_method  set " & sql & ",ID = '" & gsID & "'")


        End If
        If gsNew = True Then
            fPop_Up_Msg(Me.Text, gsSaveStr, True)
        Else
            fPop_Up_Msg(Me.Text, gsUpdateStr, True)
        End If
        fBindDgvUpdate(Dgv, $"SELECT pm.`ID`,pm.`Code`,pm.`Description`,p.`DESCRIPTION` AS `Payment Type`, CONCAT(a.`NAME` , ' / ' ,a.`TYPE`) AS `G/L Account` FROM payment_method AS pm LEFT OUTER JOIN  payment_type_map AS p ON p.`ID` = pm.`PAYMENT_TYPE` LEFT OUTER JOIN account AS a ON a.`ID` = pm.`GL_ACCOUNT_ID` Where pm.`ID` = '{gsID}' limit 1", gsNew, This_BS)
        fClear_Info()
        gsID = ""
        gsNew = True
        Me.Enabled = True
        If fACCESS_NEW_EDIT(frmPaymentMethods, gsNew) = False Then

            Me.Close()
        End If
    End Sub
End Class