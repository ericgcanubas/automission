Public Class FrmPOSPayment

    Public gsTransTotal As Double = 0
    Public gsOk As Boolean = False
    Public gsPaymentMethod_ID As Integer
    Public gsAMOUNT As Double = 0
    Public gsPAYMENT_REF_NO As String
    Public gsCARD_NO As String
    Public gsNOTES As String
    'Dim PayDefaultMethod As Integer = 0
    Public gsRemove As Boolean = False
    Private Sub cmbPAYMENT_METHOD_ID_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbPAYMENT_METHOD_ID.SelectedValueChanged

        Dim card_no As Boolean = False

        Try



            Dim I As Integer = 0
            If cmbPAYMENT_METHOD_ID.Items.Count <> 0 Then
                I = Val(cmbPAYMENT_METHOD_ID.SelectedValue)
            End If

            Select Case I
                Case 1 'Cash
                    lbslREF_No.Text = "O.R No."
                    card_no = False

                Case 2 'Check
                    lbslREF_No.Text = "O.R No."
                    card_no = True
                    lbslCARD_NO.Text = "CHECK No."

                Case 3 'Master Card

                    lbslREF_No.Text = "APPROVAL No."
                    card_no = True

                    lbslCARD_NO.Text = "CARD NO."


                Case 4 'Others

                    lbslREF_No.Text = "APPROVAL No."
                    card_no = True

                    lbslCARD_NO.Text = "CARD NO."

                Case 5
                    lbslREF_No.Text = "APPROVAL No."
                    card_no = True

                    lbslCARD_NO.Text = "CARD NO."
                Case Else

            End Select


        Catch ex As Exception
            lbslREF_No.Text = "O.R No."
            card_no = False

        End Try

        lbslCARD_NO.Visible = card_no
        txtCARD_NO.Visible = card_no

    End Sub
    Private Sub CreateButton()
        FlowLayoutPanel1.Controls.Clear()


        cmbPAYMENT_METHOD_ID.SelectedIndex = -1
        Dim C As Integer = 0
        Dim X As Integer = 12 ' LEFT
        Dim Y As Integer = 74 ' TOP
        For I As Integer = 0 To cmbPAYMENT_METHOD_ID.Items.Count - 1
            C = C + 1
            cmbPAYMENT_METHOD_ID.SelectedIndex = I

            Dim rdButton As New RadioButton
            rdButton.Name = $"{cmbPAYMENT_METHOD_ID.SelectedValue}"
            rdButton.Text = cmbPAYMENT_METHOD_ID.Text
            rdButton.BackColor = SystemColors.Control

            rdButton.AutoSize = False
            rdButton.TextAlign = ContentAlignment.MiddleCenter
            rdButton.CheckAlign = ContentAlignment.TopCenter
            rdButton.Size = New Size(110, 73)
            rdButton.Appearance = Appearance.Normal
            rdButton.FlatStyle = FlatStyle.Popup
            rdButton.Location = New Point(X * I, Y)
            rdButton.Checked = False

            AddHandler rdButton.CheckedChanged, AddressOf fClickMethod

            FlowLayoutPanel1.Controls.Add(rdButton)

        Next




    End Sub
    Private Sub fClickMethod(sender As Object, e As EventArgs)
        Dim R As RadioButton = DirectCast(sender, RadioButton)
        cmbPAYMENT_METHOD_ID.SelectedValue = R.Name
        numAMOUNT.Select()

        BlueLight(numAMOUNT)
    End Sub
    Private Sub frmPOSPayment_Load(sender As Object, e As EventArgs) Handles Me.Load

        fLabel_Digital_M(xxxTOTAL)
        fLabel_Digital_M(xxxxCHANGE)

        CreateButton()
        xxxTOTAL.Text = NumberFormatStandard(gsTransTotal)
        gsOk = False

    End Sub
    Private Sub fCompute()
        Dim Change_Total As Double = gsTransTotal - numAMOUNT.Value

        If Change_Total < 0 Then
            Change_Total = Change_Total * -1
        Else
            Change_Total = 0
        End If
        xxxxCHANGE.Text = NumberFormatStandard(Change_Total)
    End Sub
    Private Sub txtPAYMENT_REF_NO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPAYMENT_REF_NO.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub txtCARD_NO_TextChanged(sender As Object, e As EventArgs) Handles txtCARD_NO.TextChanged

    End Sub

    Private Sub txtCARD_NO_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCARD_NO.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub frmPOSPayment_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        For N As Integer = 0 To FlowLayoutPanel1.Controls.Count - 1
            Dim B As RadioButton = FlowLayoutPanel1.Controls(N)

            If B.Name = gsPaymentMethod_ID Then
                B.PerformClick()
            End If

        Next
        rtbNOTES.Text = gsNOTES
        txtPAYMENT_REF_NO.Text = gsPAYMENT_REF_NO
        txtCARD_NO.Text = gsCARD_NO
        numAMOUNT.Value = 0
        BlueLight(numAMOUNT)
    End Sub


    Private Sub BtnOK_Click(sender As Object, e As EventArgs)


    End Sub



    Private Sub LbslREF_No_Click(sender As Object, e As EventArgs) Handles lbslREF_No.Click

    End Sub

    Private Sub NumAMOUNT_ValueChanged(sender As Object, e As EventArgs) Handles numAMOUNT.ValueChanged
        fCompute()
    End Sub

    Private Sub numAMOUNT_KeyDown(sender As Object, e As KeyEventArgs) Handles numAMOUNT.KeyDown
        fMaster_Keydown(sender, e)
    End Sub
    Private Sub fMaster_Keydown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then

            If rtbNOTES.Focused = True Then
                FlowLayoutPanel1.Select()
                Exit Sub

            End If

            If FlowLayoutPanel1.Focused = True Then
                txtPAYMENT_REF_NO.Select()
                Exit Sub
            End If

            If txtPAYMENT_REF_NO.Focused = True Then

                If txtCARD_NO.Visible = True Then
                    txtCARD_NO.Select()
                    Exit Sub
                Else
                    numAMOUNT.Select()
                End If

            End If

            If txtCARD_NO.Focused = True Then
                numAMOUNT.Select()
                Exit Sub
            End If

            If numAMOUNT.Focused = True Then
                btnOK.Select()
                Exit Sub
            End If



        ElseIf e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.A Then
            numAMOUNT.Select()

        End If

    End Sub



    Private Sub numAMOUNT_GotFocus(sender As Object, e As EventArgs) Handles numAMOUNT.GotFocus

    End Sub

    Private Sub LbslCARD_NO_Click(sender As Object, e As EventArgs) Handles lbslCARD_NO.Click

    End Sub

    Private Sub RtbNOTES_TextChanged(sender As Object, e As EventArgs) Handles rtbNOTES.TextChanged

    End Sub

    Private Sub rtbNOTES_KeyDown(sender As Object, e As KeyEventArgs) Handles rtbNOTES.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub

    Private Sub FlowLayoutPanel1_KeyDown(sender As Object, e As KeyEventArgs) Handles FlowLayoutPanel1.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        gsOk = False
        Me.Close()
    End Sub

    Private Sub btnOK_Click_1(sender As Object, e As EventArgs) Handles btnOK.Click
        If gsAMOUNT > numAMOUNT.Value Then
            PrompNotify("POS Payment", "Invalid tender amount", False)
            numAMOUNT.Select()
            BlueLight(numAMOUNT)
            Exit Sub
        End If

        If GF_IsPosOfficialReceiptRequired() = True And txtPAYMENT_REF_NO.Text.Length = 0 Then

            If txtPAYMENT_REF_NO.Text.Length = 0 Then
                MessageBoxExclamation($"{lbslREF_No.Text} is required.")
                Exit Sub
            End If
        End If

        gsOk = True
        gsPaymentMethod_ID = cmbPAYMENT_METHOD_ID.SelectedValue
        gsCARD_NO = txtCARD_NO.Text.Replace("'", "`")
        gsPAYMENT_REF_NO = txtPAYMENT_REF_NO.Text
        gsAMOUNT = numAMOUNT.Value
        gsNOTES = rtbNOTES.Text.Replace("'", "`")

        Me.Close()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub numAMOUNT_TextChanged(sender As Object, e As EventArgs) Handles numAMOUNT.TextChanged

    End Sub

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        gsRemove = True
        Me.Close()
    End Sub

    Private Sub frmPOSPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        fMaster_Keydown(sender, e)
    End Sub

    Private Sub BunifuSeparator1_Load(sender As Object, e As EventArgs) Handles BunifuSeparator1.Load

    End Sub
End Class