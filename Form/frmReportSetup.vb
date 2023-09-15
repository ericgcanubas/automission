'SELECT `ALL STOCK` AS `TYPE` ,`*` AS `VALUE` UNION
'Select Case`STOCK IN` AS `TYPE`,`STOCK IN` AS `VALUE` UNION
'Select Case`STOCK OUT` AS `TYPE`,`STOCK OUT` AS `VALUE`
Imports System.Data.Odbc
Public Class FrmReportSetup

    Dim Report_Type As String
    Dim bIsDataSet As Boolean

    Private Sub FrmReportSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SystemLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsDEFAULT_PRINTER
        If Trim(cmbPRINTER.Text) = "" Then
            cmbPRINTER.SelectedText = gsPOS_WINDOWS_PRINTER
        End If
        Dim Height_max As Integer = FlowLayoutPanel1.Height
        Me.Text = gsReportTabName
        Me.AccessibleDescription = gsREPORT_ID ' AS SUB ID
        ToolStripLabel5.Text = gsReportTabName

        LoadComponent()
        bIsDataSet = GF_GetNumberFieldValue("tblsub_menu", "sub_id", Me.AccessibleDescription, "modal")
    End Sub
    Private Function LikeValueByString(ByVal prValue As String) As String
        If prValue = "*" Then
            Return "*"

        ElseIf prValue = "%" Then
            Return "%"
        Else

            If IsNumeric(prValue) = True Then
                Return prValue
            Else
                Return prValue
            End If


        End If
    End Function
    Private Sub StartReport()
        Try

            Dim dtp1 As DateTimePicker = Nothing
            Dim dtp2 As DateTimePicker = Nothing
            gscryRpt = ReportDocumentOneParameterNumberOnly(lklFileName.Text)

            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay"), "company_name")
            CryParameterInsertValue(gscryRpt, GetSystemSettingValueByText("ReportDisplay2"), "name_by")
            Dim stringArray(100) As String
            Dim intArray As Integer = 0
            Dim rd As OdbcDataReader = SqlReader("select r.ID,r.COMPONENT_ID,c.TYPE,c.NAME,c.SQL_STATEMENT,c.VALUE_NAME,c.DISPLAY_NAME,c.DEFAULT_VALUE,c.REPORT_PARAMETER_NAME,c.PARAMETER_ID1,c.VARIABLE_NAME1,c.PARAMETER_ID2,c.VARIABLE_NAME2,c.PARAMETER_ID3,c.VARIABLE_NAME3 from report_components as r inner join component as c on c.ID = r.COMPONENT_ID where sub_id = '" & Me.AccessibleDescription & "' order by r.LINE_NO")
            While rd.Read
                If GF_TextIsNull(rd("REPORT_PARAMETER_NAME")) <> "" Then

                    Select Case Val(rd("TYPE"))
                        Case 1

                            Dim txt As TextBox = GetObject(rd("COMPONENT_ID"))

                            If bIsDataSet = False Then
                                CryParameterInsertValue(gscryRpt, txt.Text, GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = txt.Text
                                intArray += 1
                            End If

                        Case 2
                            Dim cmb As ComboBox = GetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then
                                CryParameterInsertValue(gscryRpt, LikeValueByString(cmb.SelectedValue.ToString), GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = cmb.SelectedValue
                                intArray += 1
                            End If
                        Case 3
                            Dim cmb As ComboBox = GetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then

                                CryParameterInsertValue(gscryRpt, LikeValueByString(cmb.SelectedValue.ToString), GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = cmb.SelectedValue
                                intArray += 1
                            End If
                        Case 4
                            Dim dt As DateTimePicker = GetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then


                                CryParameterInsertValue(gscryRpt, dt.Value, GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = dt.Value
                                intArray += 1
                            End If
                            If dtp1 Is Nothing Then
                                dtp1 = dt
                            ElseIf dtp2 Is Nothing Then
                                dtp2 = dt
                            End If
                        Case 5
                            Dim num As NumericUpDown = GetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then
                                CryParameterInsertValue(gscryRpt, num.Value, GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = num.Value
                                intArray += 1
                            End If
                        Case 6
                            Dim chk As CheckBox = GetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then
                                CryParameterInsertValue(gscryRpt, chk.Checked.ToString, GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = chk.Checked.ToString
                                intArray += 1
                            End If
                        Case 7
                            Dim sResult As String = ""
                            Dim strField As String = ""
                            Dim bBool As Boolean = rd("DEFAULT_VALUE")
                            If GF_TextIsNull(rd("PARAMETER_ID1")) <> "" Then
                                Dim i As Integer = GF_GetNumberFieldValue("component", "ID", rd("PARAMETER_ID1"), "Type")
                                strField = HiddenByText(rd("PARAMETER_ID1"), i, bBool)
                                If i = 6 Then
                                    If bBool = False Then

                                        If strField.ToLower = rd("VARIABLE_NAME1").ToString.ToLower Then
                                            sResult = rd("VALUE_NAME")
                                        Else
                                            sResult = rd("DISPLAY_NAME")
                                        End If

                                    End If
                                Else
                                    sResult = strField
                                End If

                            End If

                            If GF_TextIsNull(rd("PARAMETER_ID2")) <> "" Then

                                strField = strField & " - " & HiddenByText(rd("PARAMETER_ID2"), GF_GetNumberFieldValue("component", "ID", rd("PARAMETER_ID2"), "Type"), bBool)
                                sResult = strField
                            End If

                            If GF_TextIsNull(rd("PARAMETER_ID3")) <> "" Then

                                strField = HiddenByText(rd("PARAMETER_ID3"), GF_GetNumberFieldValue("component", "ID", rd("PARAMETER_ID3"), "Type"), bBool)

                            End If


                            CryParameterInsertValue(gscryRpt, sResult, GF_TextIsNull(rd("REPORT_PARAMETER_NAME")))

                        Case 8

                        Case 9

                    End Select
                End If
            End While

            'If bIsDataSet = True Then
            '    If Me.AccessibleDescription = 96 Then
            '        fGeneralLedger(gscryRpt, stringArray(0).Replace("*", "%"), stringArray(5).Replace("*", "%"), stringArray(1), stringArray(2), stringArray(3), stringArray(4))


            '    End If

            'End If

            If dtp1 IsNot Nothing And dtp2 IsNot Nothing Then
                'dtp1.Value = GetDBAccessValueByText("dtpDATE_FROM")
                'dtp2.Value = GetDBAccessValueByText("dtpDATE_TO")

                SetDBAccessValue("dtpDATE_FROM", dtp1.Value)
                SetDBAccessValue("dtpDATE_TO", dtp2.Value)
            End If
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub
    Private Function HiddenByText(ByVal prName As String, ByVal prType As Integer, ByVal bValue As Boolean) As String
        Try


            Select Case prType
                Case 1
                    Return ""
                Case 2
                    Dim cmb As ComboBox = GetObject(prName)
                    If bValue = True Then
                        Return cmb.SelectedValue
                    Else
                        Return cmb.Text
                    End If

                Case 3
                    Dim cmb As ComboBox = GetObject(prName)
                    If bValue = True Then
                        Return cmb.SelectedValue
                    Else
                        Return cmb.Text
                    End If
                Case 4
                    Dim dt As DateTimePicker = GetObject(prName)
                    If bValue = True Then
                        Return Format(dt.Value, "MM/dd/yyyy")
                    Else
                        Return Format(dt.Value, "MM/dd/yyyy")
                    End If
                Case 5
                    Dim nn As NumericUpDown = GetObject(prName)
                    If bValue = True Then
                        Return nn.Value
                    End If
                Case 6
                    Dim chk As CheckBox = GetObject(prName)
                    If bValue = True Then
                        Return chk.Checked
                    Else
                        Dim lbl As Label = GetObject("lbl" & chk.Name)
                        Return lbl.Text
                    End If
                Case 7
                    Return ""
                Case 8
                    Return ""
                Case 9
                    Return ""
                Case Else
                    Return ""
            End Select
            Return ""
        Catch ex As Exception

        Finally

        End Try
        Return ""
    End Function
    Private Sub DropDownComboBox(ByVal cmb As ComboBox)

        Dim sOP As String = "{AND_OR}"
        Dim rd As OdbcDataReader = SqlReader("SELECT * FROM COMPONENT WHERE ID = '" & cmb.Name & "' Limit 1")
        If rd.Read Then

            Dim sQUERY As String = rd("SQL_STATEMENT").ToString.Replace("`", "'")
            Dim prValue As String
            If GF_NumIsNull(rd("PARAMETER_ID1")) <> 0 And GF_TextIsNull(rd("VARIABLE_NAME1")) <> "" Then
                prValue = SearchComponent(FlowLayoutPanel1, GF_TextIsNull(rd("PARAMETER_ID1")))
                If prValue = "" Then
                    prValue = "*"
                End If
                sQUERY = sQUERY.Replace(rd("VARIABLE_NAME1"), prValue)

                sQUERY = sQUERY.Replace(sOP, IIf(prValue = "*", "OR", "AND"))
            End If

            If GF_NumIsNull(rd("PARAMETER_ID2")) <> 0 And GF_TextIsNull(rd("VARIABLE_NAME2")) <> "" Then

                prValue = SearchComponent(FlowLayoutPanel1, GF_TextIsNull(rd("PARAMETER_ID2")))
                If prValue = "" Then
                    prValue = "*"
                End If
                sQUERY = sQUERY.Replace(rd("VARIABLE_NAME2"), prValue)
                sQUERY = sQUERY.Replace(sOP, IIf(prValue = "*", "OR", "AND"))
            End If

            If GF_NumIsNull(rd("PARAMETER_ID3")) <> 0 And GF_TextIsNull(rd("VARIABLE_NAME3")) <> "" Then
                prValue = SearchComponent(FlowLayoutPanel1, GF_TextIsNull(rd("PARAMETER_ID3")))
                If prValue = "" Then
                    prValue = "*"
                End If
                sQUERY = sQUERY.Replace(rd("VARIABLE_NAME3"), prValue)
                sQUERY = sQUERY.Replace(sOP, IIf(prValue = "*", "OR", "AND"))
            End If

            '{AND_OR}  OR = "*" AND  <> "*"

            GS_ComboBoxLoad(cmb, sQUERY, rd("VALUE_NAME"), rd("DISPLAY_NAME"))
            GS_DoEvents()
            ' cmb.SelectedIndex = -1
            cmb.SelectedValue = GF_TextIsNull(rd("DEFAULT_VALUE"))



        End If
    End Sub
    Private Function SearchComponent(ByVal control As Control, ByVal prID As String) As String
        Dim value As String = ""
        For i As Integer = 0 To control.Controls.Count - 1
            Dim c As Control = control.Controls(i)
            If c.Name = prID Then
                value = GetValueByText(c)
                Exit For
            Else
                If StrLeft(c.Name, 3) = "pnl" Then
                    Dim pnl As Panel = c
                    value = SearchComponent(pnl, prID)
                    If value <> "" Then
                        Exit For
                    End If

                End If
            End If

        Next
        Return value
    End Function

    Private Function SearchComponent_Control(ByVal ctrl As Control, ByVal prID As String) As Control
        Dim value As Control = Nothing
        For i As Integer = 0 To ctrl.Controls.Count - 1
            Dim c As Control = ctrl.Controls(i)
            If c.Name = prID Then
                value = c
                Exit For
            Else
                If StrLeft(c.Name, 3) = "pnl" Then
                    Dim pnl As Panel = c
                    value = SearchComponent_Control(pnl, prID)
                    If value IsNot Nothing Then
                        Exit For
                    End If

                End If
            End If
        Next
        Return value
    End Function
    Public Function GetValueByText(ByVal c As Control) As String
        Select Case Val(c.AccessibleDescription)
            Case 1
                Return c.Text
            Case 2
                Dim cmb As ComboBox = c
                Return cmb.SelectedValue

            Case 3
                Dim cmb As ComboBox = c
                Return cmb.SelectedValue
            Case 4
                Dim dt As DateTimePicker = c
                Return dt.Value
            Case 5
                Dim n As NumericUpDown = c
                Return n.Value
            Case Else

                'HIDDEN
                'BlANK_PANNEL
                Return Nothing
        End Select

    End Function


    Private Function AddingPanel(ByVal prName As String, ByVal prWidth As Integer) As Panel
        Dim p As New Panel With {
            .Name = "pnl" & prName,
            .Width = prWidth,
            .Height = 23
        }
        FlowLayoutPanel1.Controls.Add(p)
        Return p
    End Function


    Private Sub FrmReportSetup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        lklFileName.Text = gsReportFileName
    End Sub
    Private Sub LoadComponent()
        Dim dtRange As ComboBox = Nothing
        Try

            Dim dtp1 As DateTimePicker = Nothing
            Dim dtp2 As DateTimePicker = Nothing
            Dim iLeft As Integer = 0
            Dim iTop As Integer = 0
            Dim rd As OdbcDataReader = SqlReader("select r.ID,r.COMPONENT_ID,c.TYPE,c.NAME,c.SQL_STATEMENT,c.VALUE_NAME,c.DISPLAY_NAME,c.DEFAULT_VALUE,c.REPORT_PARAMETER_NAME,c.PARAMETER_ID1,c.VARIABLE_NAME1,c.PARAMETER_ID2,c.VARIABLE_NAME2,c.PARAMETER_ID3,c.VARIABLE_NAME3 from report_components as r inner join component as c on c.ID = r.COMPONENT_ID where sub_id = '" & Me.AccessibleDescription & "' order by r.LINE_NO")
            While rd.Read

                Select Case GF_NumIsNull(rd("TYPE"))
                    Case 1

                        Dim p As Panel = AddingPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label With {
                            .Name = "lbl" & rd("COMPONENT_ID"),
                            .Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        }
                        p.Controls.Add(l)

                        'TEXT
                        Dim txt As New TextBox With {
                            .Name = rd("COMPONENT_ID"),
                            .AccessibleDescription = GF_TextIsNull(rd("SQL_STATEMENT")),
                            .AccessibleName = GF_TextIsNull(rd("DISPLAY_NAME")),
                            .Tag = GF_TextIsNull(rd("DISPLAY_NAME")),
                            .Left = 100
                        }
                        AddHandler txt.TextChanged, AddressOf Text_Change
                        p.Controls.Add(txt)

                    Case 2
                        Dim p As Panel = AddingPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label With {
                            .Name = "lbl" & rd("COMPONENT_ID"),
                            .Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        }
                        p.Controls.Add(l)
                        'DROPDOWN STANDARD
                        Dim cmb As New ComboBox With {
                            .Name = rd("COMPONENT_ID"),
                            .AccessibleDescription = GF_NumIsNull(rd("TYPE")),
                            .AccessibleName = GF_TextIsNull(rd("REPORT_PARAMETER_NAME")),
                            .Left = 100,
                            .Width = 300
                        }

                        DropDownComboBox(cmb)
                        AddHandler cmb.SelectedIndexChanged, AddressOf ChangeDropDown_Change
                        p.Controls.Add(cmb)

                    Case 3
                        Dim p As Panel = AddingPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label With {
                            .Name = "lbl" & rd("COMPONENT_ID"),
                            .Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        }
                        p.Controls.Add(l)
                        'DROPDOWN FIXED
                        Dim cmb As New ComboBox With {
                            .Name = rd("COMPONENT_ID"),
                            .AccessibleDescription = GF_NumIsNull(rd("TYPE")),
                            .AccessibleName = GF_TextIsNull(rd("REPORT_PARAMETER_NAME")),
                            .DropDownStyle = ComboBoxStyle.DropDownList,
                            .Left = 100,
                            .Width = 300
                        }

                        DropDownComboBox(cmb)
                        AddHandler cmb.SelectedIndexChanged, AddressOf ChangeDropDown_Change
                        p.Controls.Add(cmb)

                        If rd("NAME") = "LOCATION" Then
                            cmb.SelectedValue = gsDefault_LOCATION_ID
                            cmb.Enabled = IsLockLocation()
                        End If
                    Case 4
                        Dim p As Panel = AddingPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label With {
                            .Name = "lbl" & rd("COMPONENT_ID"),
                            .Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        }

                        p.Controls.Add(l)
                        'DATE
                        Dim dt As New DateTimePicker With {
                            .Name = rd("COMPONENT_ID"),
                            .AccessibleDescription = GF_NumIsNull(rd("TYPE")),
                            .AccessibleName = GF_TextIsNull(rd("REPORT_PARAMETER_NAME")),
                            .Left = 100,
                            .Format = DateTimePickerFormat.Short
                        }
                        p.Controls.Add(dt)

                        If dtp1 Is Nothing Then
                            dtp1 = dt
                        ElseIf dtp2 Is Nothing Then
                            dtp2 = dt
                        End If

                        If GF_TextIsNull(rd("NAME")) = "SELECT_DATE" Then
                            If gsSelectedDateDefault = "Today" Then
                                dt.Value = Date.Now.Date
                            ElseIf gsSelectedDateDefault = "Yesterday" Then
                                dt.Value = Date.Now.Date.AddDays(-1)
                            End If
                        End If

                    Case 5
                    'NUMBER
                    Case 6
                        Dim p As Panel = AddingPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label With {
                            .Name = "lbl" & rd("COMPONENT_ID"),
                            .Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower)),
                            .AccessibleDescription = GF_TextIsNull(rd("VALUE_NAME")),
                            .AccessibleName = GF_TextIsNull(rd("DISPLAY_NAME"))
                        }
                        p.Controls.Add(l)
                        'CHECKBOX
                        Dim chk As New CheckBox With {
                            .Name = rd("COMPONENT_ID"),
                            .AccessibleDescription = GF_NumIsNull(rd("TYPE")),
                            .AccessibleName = GF_TextIsNull(rd("REPORT_PARAMETER_NAME")),
                            .Left = 100
                        }
                        AddHandler chk.CheckedChanged, AddressOf ChecKBox_Change
                        p.Controls.Add(chk)
                        If IsDBNull(rd("DEFAULT_VALUE")) = False Then
                            If CBool(rd("DEFAULT_VALUE")) = True Then
                                chk.Checked = True
                            Else
                                chk.Checked = False
                            End If
                        End If
                    Case 7
                        'HIDDEN PARAMETER

                    Case 8
                        Dim p As Panel = AddingPanel(rd("NAME") & rd("ID"), 400)
                        p.Top = iTop
                       ' BLANK PANEL
                    Case 9
                        Dim p As Panel = AddingPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label With {
                            .Name = "lbl" & rd("COMPONENT_ID"),
                            .Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        }
                        p.Controls.Add(l)
                        Dim cmb As ComboBox
                        cmb = GF_DataRangeLoad(rd("COMPONENT_ID"))
                        cmb.Left = 100
                        cmb.Width = 300
                        AddHandler cmb.SelectedIndexChanged, AddressOf DateRange_Change
                        p.Controls.Add(cmb)
                        dtRange = cmb


                End Select
                iTop += 30
            End While
            If dtRange IsNot Nothing Then

                dtRange.Text = gsDateRangeDefault

            End If

            'If dtp1 IsNot Nothing And dtp2 IsNot Nothing Then
            '    dtp1.Value = GetDBAccessValueByText("dtpDATE_FROM")
            '    dtp2.Value = GetDBAccessValueByText("dtpDATE_TO")
            'End If
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub
    Private Sub ChangeDropDown_Change(sender As Object, e As EventArgs)

        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        Dim rd As OdbcDataReader = SqlReader("select c.ID from report_components as r inner join component as c on c.ID = r.component_ID where r.SUB_ID = '" & Me.AccessibleDescription & "' and (c.PARAMETER_ID1 ='" & cmb.Name & "' or c.PARAMETER_ID2 ='" & cmb.Name & "' or PARAMETER_ID3 ='" & cmb.Name & "')")
        While rd.Read
            Dim c As Control = SearchComponent_Control(FlowLayoutPanel1, rd("ID"))
            Try
                If c IsNot Nothing Then
                    Dim cbo As ComboBox = c
                    DropDownComboBox(cbo)
                End If
            Catch ex As Exception
                MessageBoxExclamation(ex.Message)
            End Try



        End While
    End Sub
    Private Function GetStatementValue(ByVal sql As String, ByVal prDisplay As String, ByVal myValue As String) As String
        Dim sQuery As String = sql.Replace("`", "'")
        sQuery = sQuery.Replace(prDisplay, myValue)
        Dim rd As OdbcDataReader = SqlReader(sQuery)
        Dim strValue As String = ""
        If rd.Read Then
            strValue = GF_TextIsNull(rd(0))
        End If
        Return strValue
    End Function
    Private Function GetObject(ByVal prName As String) As Control
        Return SearchComponent_Control(FlowLayoutPanel1, prName)
    End Function
    Private Sub ChecKBox_Change(sender As Object, e As EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim lbl As Label = GetObject("lbl" & chk.Name)
        If chk.Checked = True Then

            lbl.Text = fTitleCase(lbl.AccessibleDescription)
        Else
            lbl.Text = fTitleCase(lbl.AccessibleName)
        End If
    End Sub
    Private Sub Text_Change(sender As Object, e As EventArgs)

        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim rd As OdbcDataReader = SqlReader("select c.ID from report_components as r inner join component as c on c.ID = r.component_ID where r.SUB_ID = '" & Me.AccessibleDescription & "' and (c.PARAMETER_ID1 ='" & txt.Name & "' or c.PARAMETER_ID2 ='" & txt.Name & "' or PARAMETER_ID3 ='" & txt.Name & "')")
        While rd.Read
            Dim c As Control = SearchComponent_Control(FlowLayoutPanel1, rd("ID"))

            Try
                If c IsNot Nothing Then
                    Dim cbo As ComboBox = c
                    Select Case cbo.AccessibleDescription
                        Case 1
                        Case 2
                            '  DropDownComboBox(cbo)
                            cbo.SelectedValue = GetStatementValue(txt.AccessibleDescription, txt.AccessibleName, txt.Text)
                        Case 3
                            ' DropDownComboBox(cbo)
                            cbo.SelectedValue = GetStatementValue(txt.AccessibleDescription, txt.AccessibleName, txt.Text)
                    End Select




                End If
            Catch ex As Exception
                MessageBoxExclamation(ex.Message)
            End Try



        End While

    End Sub

    Private Sub TsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click

        ClosedForm(Me)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If cmbPRINTER.Text.Trim = "" Then
            MessageBoxInfo("Please select printer")
            Exit Sub
        End If

        GS_CursorLoadingOn(True)
        Try
            SystemSetDefaultPrinter(cmbPRINTER.Text)
            StartReport()
            GlobalPreviewReport(ToolStripLabel5.Text)




        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try

        GS_CursorLoadingOn(False)
        'SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsPrint.Click
        If cmbPRINTER.Text.Trim = "" Then
            MessageBoxInfo("Please select printer")
            Exit Sub
        End If
        GS_CursorLoadingOn(True)
        Try
            SystemSetDefaultPrinter(cmbPRINTER.Text)
            GS_DoEvents()
            StartReport()
            gscryRpt.PrintToPrinter(1, False, 0, 0)
            ReportExporPDF(gscryRpt, ToolStripLabel5.Text)
            '  SystemSetDefaultPrinter(gsDEFAULT_PRINTER)
        Catch ex As Exception
            MessageBoxWarning(ex.Message)
        End Try
        GS_CursorLoadingOn(False)
    End Sub
    Private Sub DateRange_Change(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        Dim rd As OdbcDataReader = SqlReader("select c.ID from report_components as r inner join component as c on c.ID = r.component_ID where r.SUB_ID = '" & Me.AccessibleDescription & "' and (c.PARAMETER_ID1 ='" & cmb.Name & "' or c.PARAMETER_ID2 ='" & cmb.Name & "' or PARAMETER_ID3 ='" & cmb.Name & "')")
        Dim dt1 As DateTimePicker = Nothing
        Dim dt2 As DateTimePicker = Nothing
        While rd.Read
            If dt1 Is Nothing Then
                dt1 = GetObject(rd("ID"))
            ElseIf dt2 Is Nothing Then
                dt2 = GetObject(rd("ID"))
            End If
        End While
        fSelectDateRange(cmb.Text, dt1, dt2)

    End Sub

    Private Sub LklFileName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklFileName.LinkClicked
        If gsAdmin_User = 0 Then
            Exit Sub
        End If
        With FrmReportManager
            .gsSUB_ID = Me.AccessibleDescription
            .lblNAME.Text = ToolStripLabel5.Text
            .ShowDialog()
            .Dispose()
        End With
        FrmReportManager = Nothing
        FlowLayoutPanel1.Visible = False
        FlowLayoutPanel1.Controls.Clear()
        LoadComponent()
        FlowLayoutPanel1.Visible = True


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class