Imports System.Data.Odbc
Public Class FrmPaymentTermsDetails
    Public ID As Integer
    Public IsNew As Boolean = True
    Public This_BS As BindingSource
    Public Dgv As DataGridView
    Private Sub fComboSemiAnnual(ByVal cmb As ComboBox)
        cmb.Items.Clear()
        cmb.Items.Add("Jan / Jul")
        cmb.Items.Add("Feb / Aug")
        cmb.Items.Add("Mar / Sep")
        cmb.Items.Add("Apr / Oct")
        cmb.Items.Add("May / Nov")
        cmb.Items.Add("Jun / Dec")

        cmb.SelectedIndex = 0
    End Sub
    Private Sub fComboSemiMonth(ByVal cmb As ComboBox)
        cmb.Items.Clear()
        cmb.Items.Add("1 / 16 th")
        cmb.Items.Add("2 / 17 th")
        cmb.Items.Add("3 / 18 th")
        cmb.Items.Add("4 / 19 th")
        cmb.Items.Add("5 / 20 th")
        cmb.Items.Add("6 / 21 th")
        cmb.Items.Add("7 / 22 th")
        cmb.Items.Add("8 / 23 th")
        cmb.Items.Add("9 / 24 th")
        cmb.Items.Add("10 / 25 th")
        cmb.Items.Add("11 / 26 th")
        cmb.Items.Add("12 / 27 th")
        cmb.Items.Add("13 / 28 th")
        cmb.Items.Add("14 / 29 th")
        cmb.Items.Add("15 / 30 th")
        cmb.SelectedIndex = 0
    End Sub
    Private Sub fComboMonth(ByVal cmb As ComboBox)
        cmb.Items.Clear()
        cmb.Items.Add("Jan")
        cmb.Items.Add("Feb")
        cmb.Items.Add("Mar")
        cmb.Items.Add("Apr")
        cmb.Items.Add("May")
        cmb.Items.Add("Jun")
        cmb.Items.Add("Aug")
        cmb.Items.Add("Sep")
        cmb.Items.Add("Oct")
        cmb.Items.Add("Nov")
        cmb.Items.Add("Dec")
        cmb.SelectedIndex = 0
    End Sub
    Private Sub fComboWeekDay(ByVal cmb As ComboBox)
        cmb.Items.Clear()
        cmb.Items.Add("Mon")
        cmb.Items.Add("Tue")
        cmb.Items.Add("Wen")
        cmb.Items.Add("Thu")
        cmb.Items.Add("Fri")
        cmb.Items.Add("Sat")
        cmb.Items.Add("Sun")
        cmb.SelectedIndex = 0

    End Sub
    Private Sub fComboDay(ByVal cmb As ComboBox)
        cmb.Items.Clear()

        For i As Integer = 1 To 30

            cmb.Items.Add(fday(i))

        Next
        cmb.SelectedIndex = 0
    End Sub
    Private Function fday(ByVal i As Integer) As String
        Select Case i
            Case 1
                Return "1 st"
            Case 2
                Return "2 nd"
            Case 3
                Return "3 rd"
            Case Else
                Return i & " th"
        End Select
    End Function

    Private Sub frmPaymentTermsDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ComboBoxLoad(cmbTYPE, "SELECT * FROM PAYMENT_TERMS_TYPE_MAP", "ID", "DESCRIPTION")
        cmbTYPE_SelectedIndexChanged(sender, e)
        If ID > 0 Then
            fRefresh()
            IsNew = False

        End If

    End Sub
    Private Sub fRefresh()

        Try

            Dim sQuery As String = "select * from payment_terms where id = '" & ID & "' Limit 1"


            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                txtCODE.Text = rd("CODE")
                txtDESCRIPTION.Text = rd("DESCRIPTION")

                cmbTYPE.SelectedValue = NumIsNull(rd("TYPE"))
                numNET_DUE.Value = NumIsNull(rd("NET_DUE"))
                cmbDATE_DAY_PARAM.SelectedIndex = NumIsNull(rd("DATE_DAY_PARAM")) - 1
                cmbDATE_MONTH_PARAM.SelectedIndex = NumIsNull(rd("DATE_MONTH_PARAM")) - 1
                numDATE_MIN_DAYS.Value = NumIsNull(rd("DATE_MIN_DAYS"))
                numDISCOUNT_PCT.Value = NumIsNull(rd("DISCOUNT_PCT"))
                numDISCOUNT_DUE.Value = NumIsNull(rd("DISCOUNT_DUE"))
                chkINACTIVE.Checked = NumIsNull(rd("INACTIVE"))

            End If
            rd.Close()
        Catch ex As Exception

            MessageBoxWarning(ex.Message)
        End Try
    End Sub
    Private Sub cmbTYPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTYPE.SelectedIndexChanged
        Try
            Label7.Enabled = True
            Label11.Enabled = True
            numDATE_MIN_DAYS.Enabled = True
            Select Case cmbTYPE.SelectedValue
                Case 0

                    cmbDATE_MONTH_PARAM.Visible = False
                    cmbDATE_MONTH_PARAM.Items.Clear()
                    cmbDATE_DAY_PARAM.Visible = False
                    cmbDATE_DAY_PARAM.Items.Clear()
                    numDATE_MIN_DAYS.Enabled = False
                    Label7.Enabled = False
                    Label11.Enabled = False

                    lbxDayLabel.Text = "day(s)."
                Case 1
                    cmbDATE_MONTH_PARAM.Visible = False
                    cmbDATE_MONTH_PARAM.Items.Clear()
                    cmbDATE_DAY_PARAM.Visible = True
                    cmbDATE_DAY_PARAM.Items.Clear()
                    fComboWeekDay(cmbDATE_DAY_PARAM)
                    lbxDayLabel.Text = "week(s)."
                Case 2
                    cmbDATE_MONTH_PARAM.Visible = False
                    cmbDATE_MONTH_PARAM.Items.Clear()
                    cmbDATE_DAY_PARAM.Visible = True
                    cmbDATE_DAY_PARAM.Items.Clear()
                    fComboSemiMonth(cmbDATE_DAY_PARAM)
                    lbxDayLabel.Text = "semi-month(s)."
                Case 3
                    cmbDATE_MONTH_PARAM.Visible = False
                    cmbDATE_MONTH_PARAM.Items.Clear()
                    cmbDATE_DAY_PARAM.Visible = True
                    cmbDATE_DAY_PARAM.Items.Clear()
                    fComboDay(cmbDATE_DAY_PARAM)
                    lbxDayLabel.Text = "month(s)."
                Case 4
                    cmbDATE_MONTH_PARAM.Visible = True
                    fComboDay(cmbDATE_MONTH_PARAM)
                    cmbDATE_DAY_PARAM.Visible = True
                    cmbDATE_DAY_PARAM.Items.Clear()
                    fComboSemiAnnual(cmbDATE_DAY_PARAM)
                    lbxDayLabel.Text = "semi-annual."


                Case 5
                    cmbDATE_MONTH_PARAM.Visible = True
                    fComboDay(cmbDATE_MONTH_PARAM)
                    cmbDATE_DAY_PARAM.Visible = True
                    cmbDATE_DAY_PARAM.Items.Clear()
                    fComboMonth(cmbDATE_DAY_PARAM)
                    lbxDayLabel.Text = "year(s)."

            End Select
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If txtCODE.Text = "" Then
            MessageBoxWarning("Code is required!")
            Exit Sub
        End If

        If txtDESCRIPTION.Text = "" Then
            MessageBoxWarning("Description is required!")
            Exit Sub
        End If

        If IsNew = False Then
            SqlExecuted("UPDATE payment_terms SET CODE='" & txtCODE.Text & "',DESCRIPTION='" & txtDESCRIPTION.Text & "',`TYPE` = '" & cmbTYPE.SelectedValue & "',NET_DUE = '" & numNET_DUE.Value & "',DISCOUNT_PCT = '" & numDISCOUNT_PCT.Value & "',DISCOUNT_DUE = '" & numDISCOUNT_DUE.Value & "',DATE_MONTH_PARAM = " & ComboBoxSelected(cmbDATE_MONTH_PARAM) & ",DATE_MIN_DAYS = " & GotNullNumber(numDATE_MIN_DAYS.Value) & ",DATE_DAY_PARAM = " & ComboBoxSelected(cmbDATE_DAY_PARAM) & ",INACTIVE = '" & Val(chkINACTIVE.Checked) & "' WHERE ID = '" & ID & "'")

        Else
            ID = ObjectTypeMapId("PAYMENT_TERMS")
            SqlExecuted("INSERT INTO payment_terms SET CODE='" & txtCODE.Text & "',DESCRIPTION='" & txtDESCRIPTION.Text & "',`TYPE` = '" & cmbTYPE.SelectedValue & "',NET_DUE = '" & numNET_DUE.Value & "',DISCOUNT_PCT = '" & numDISCOUNT_PCT.Value & "',DISCOUNT_DUE = '" & numDISCOUNT_DUE.Value & "',DATE_MONTH_PARAM = " & ComboBoxSelected(cmbDATE_MONTH_PARAM) & ",DATE_MIN_DAYS = " & GotNullNumber(numDATE_MIN_DAYS.Value) & ",DATE_DAY_PARAM = " & ComboBoxSelected(cmbDATE_DAY_PARAM) & ",INACTIVE = '" & Val(chkINACTIVE.Checked) & "' ,ID = '" & ID & "'")

        End If
        If IsNew = True Then
            PrompNotify(Me.Text, SaveMsg, True)
        Else
            PrompNotify(Me.Text, UpdateMsg, True)
        End If
        BindingViewUpdate(Dgv, $"select  ID,CODE,DESCRIPTION,INACTIVE from payment_terms WHere ID = '{ID}' limit 1", IsNew, This_BS)
        ClearAndRefresh(Me)

        ID = 0
        IsNew = True

        If SecurityAccessMode(frmPaymentTerms, IsNew) = False Then
            Me.Close()
        End If
    End Sub
End Class