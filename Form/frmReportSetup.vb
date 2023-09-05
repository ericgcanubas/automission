'SELECT `ALL STOCK` AS `TYPE` ,`*` AS `VALUE` UNION
'Select Case`STOCK IN` AS `TYPE`,`STOCK IN` AS `VALUE` UNION
'Select Case`STOCK OUT` AS `TYPE`,`STOCK OUT` AS `VALUE`
Imports System.Data.Odbc
Public Class frmReportSetup

    Dim Report_Type As String
    Dim bIsDataSet As Boolean

    Private Sub frmReportSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fLoadPrinter(cmbPRINTER)
        cmbPRINTER.Text = gsDEFAULT_PRINTER
        If Trim(cmbPRINTER.Text) = "" Then
            cmbPRINTER.SelectedText = gsPOS_WINDOWS_PRINTER
        End If
        Dim Height_max As Integer = FlowLayoutPanel1.Height
        Me.Text = gsReportTabName
        Me.AccessibleDescription = gsREPORT_ID ' AS SUB ID
        ToolStripLabel5.Text = gsReportTabName

        fLoadComponent()
        bIsDataSet = fNumFieldValue("tblsub_menu", "sub_id", Me.AccessibleDescription, "modal")
    End Sub
    Private Function fLikeValue(ByVal prValue As String) As String
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
    Private Sub fStartReport()
        Try

            Dim dtp1 As DateTimePicker = Nothing
            Dim dtp2 As DateTimePicker = Nothing
            gscryRpt = fViewReportOneParameterNumberOnly(lklFileName.Text)

            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay"), "company_name")
            fCryParameterInsertValue(gscryRpt, fSystemSettingValue("ReportDisplay2"), "name_by")
            Dim stringArray(100) As String
            Dim intArray As Integer = 0
            Dim rd As OdbcDataReader = fReader("select r.ID,r.COMPONENT_ID,c.TYPE,c.NAME,c.SQL_STATEMENT,c.VALUE_NAME,c.DISPLAY_NAME,c.DEFAULT_VALUE,c.REPORT_PARAMETER_NAME,c.PARAMETER_ID1,c.VARIABLE_NAME1,c.PARAMETER_ID2,c.VARIABLE_NAME2,c.PARAMETER_ID3,c.VARIABLE_NAME3 from report_components as r inner join component as c on c.ID = r.COMPONENT_ID where sub_id = '" & Me.AccessibleDescription & "' order by r.LINE_NO")
            While rd.Read
                If fTextisNULL(rd("REPORT_PARAMETER_NAME")) <> "" Then

                    Select Case Val(rd("TYPE"))
                        Case 1

                            Dim txt As TextBox = fGetObject(rd("COMPONENT_ID"))

                            If bIsDataSet = False Then
                                fCryParameterInsertValue(gscryRpt, txt.Text, fTextisNULL(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = txt.Text
                                intArray = intArray + 1
                            End If

                        Case 2
                            Dim cmb As ComboBox = fGetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then
                                fCryParameterInsertValue(gscryRpt, fLikeValue(cmb.SelectedValue.ToString), fTextisNULL(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = cmb.SelectedValue
                                intArray = intArray + 1
                            End If
                        Case 3
                            Dim cmb As ComboBox = fGetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then

                                fCryParameterInsertValue(gscryRpt, fLikeValue(cmb.SelectedValue.ToString), fTextisNULL(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = cmb.SelectedValue
                                intArray = intArray + 1
                            End If
                        Case 4
                            Dim dt As DateTimePicker = fGetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then


                                fCryParameterInsertValue(gscryRpt, dt.Value, fTextisNULL(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = dt.Value
                                intArray = intArray + 1
                            End If
                            If dtp1 Is Nothing Then
                                dtp1 = dt
                            ElseIf dtp2 Is Nothing Then
                                dtp2 = dt
                            End If
                        Case 5
                            Dim num As NumericUpDown = fGetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then
                                fCryParameterInsertValue(gscryRpt, num.Value, fTextisNULL(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = num.Value
                                intArray = intArray + 1
                            End If
                        Case 6
                            Dim chk As CheckBox = fGetObject(rd("COMPONENT_ID"))
                            If bIsDataSet = False Then
                                fCryParameterInsertValue(gscryRpt, chk.Checked.ToString, fTextisNULL(rd("REPORT_PARAMETER_NAME")))
                            Else
                                stringArray(intArray) = chk.Checked.ToString
                                intArray = intArray + 1
                            End If
                        Case 7
                            Dim sResult As String = ""
                            Dim strField As String = ""
                            Dim bBool As Boolean = rd("DEFAULT_VALUE")
                            If fTextisNULL(rd("PARAMETER_ID1")) <> "" Then
                                Dim i As Integer = fNumFieldValue("component", "ID", rd("PARAMETER_ID1"), "Type")
                                strField = fhidden(rd("PARAMETER_ID1"), i, bBool)
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

                            If fTextisNULL(rd("PARAMETER_ID2")) <> "" Then

                                strField = strField & " - " & fhidden(rd("PARAMETER_ID2"), fNumFieldValue("component", "ID", rd("PARAMETER_ID2"), "Type"), bBool)
                                sResult = strField
                            End If

                            If fTextisNULL(rd("PARAMETER_ID3")) <> "" Then

                                strField = fhidden(rd("PARAMETER_ID3"), fNumFieldValue("component", "ID", rd("PARAMETER_ID3"), "Type"), bBool)

                            End If


                            fCryParameterInsertValue(gscryRpt, sResult, fTextisNULL(rd("REPORT_PARAMETER_NAME")))

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
                'dtp1.Value = fGet_System_VALUE("dtpDATE_FROM")
                'dtp2.Value = fGet_System_VALUE("dtpDATE_TO")

                fSET_SYSTEM_VALUE("dtpDATE_FROM", dtp1.Value)
                fSET_SYSTEM_VALUE("dtpDATE_TO", dtp2.Value)
            End If
        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try
    End Sub
    Private Function fhidden(ByVal prName As String, ByVal prType As Integer, ByVal bValue As Boolean) As String
        Try


            Select Case prType
                Case 1
                    Return ""
                Case 2
                    Dim cmb As ComboBox = fGetObject(prName)
                    If bValue = True Then
                        Return cmb.SelectedValue
                    Else
                        Return cmb.Text
                    End If

                Case 3
                    Dim cmb As ComboBox = fGetObject(prName)
                    If bValue = True Then
                        Return cmb.SelectedValue
                    Else
                        Return cmb.Text
                    End If
                Case 4
                    Dim dt As DateTimePicker = fGetObject(prName)
                    If bValue = True Then
                        Return Format(dt.Value, "MM/dd/yyyy")
                    Else
                        Return Format(dt.Value, "MM/dd/yyyy")
                    End If
                Case 5
                    Dim nn As NumericUpDown = fGetObject(prName)
                    If bValue = True Then
                        Return nn.Value
                    End If
                Case 6
                    Dim chk As CheckBox = fGetObject(prName)
                    If bValue = True Then
                        Return chk.Checked
                    Else
                        Dim lbl As Label = fGetObject("lbl" & chk.Name)
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
    Private Sub fDropDown(ByVal cmb As ComboBox)

        Dim sOP As String = "{AND_OR}"
        Dim rd As OdbcDataReader = fReader("SELECT * FROM COMPONENT WHERE ID = '" & cmb.Name & "' Limit 1")
        If rd.Read Then

            Dim sQUERY As String = rd("SQL_STATEMENT").ToString.Replace("`", "'")
            Dim prValue As String = ""
            If fNumisNULL(rd("PARAMETER_ID1")) <> 0 And fTextisNULL(rd("VARIABLE_NAME1")) <> "" Then
                prValue = fSearchComponent(FlowLayoutPanel1, fTextisNULL(rd("PARAMETER_ID1")))
                If prValue = "" Then
                    prValue = "*"
                End If
                sQUERY = sQUERY.Replace(rd("VARIABLE_NAME1"), prValue)

                sQUERY = sQUERY.Replace(sOP, IIf(prValue = "*", "OR", "AND"))
            End If

            If fNumisNULL(rd("PARAMETER_ID2")) <> 0 And fTextisNULL(rd("VARIABLE_NAME2")) <> "" Then

                prValue = fSearchComponent(FlowLayoutPanel1, fTextisNULL(rd("PARAMETER_ID2")))
                If prValue = "" Then
                    prValue = "*"
                End If
                sQUERY = sQUERY.Replace(rd("VARIABLE_NAME2"), prValue)
                sQUERY = sQUERY.Replace(sOP, IIf(prValue = "*", "OR", "AND"))
            End If

            If fNumisNULL(rd("PARAMETER_ID3")) <> 0 And fTextisNULL(rd("VARIABLE_NAME3")) <> "" Then
                prValue = fSearchComponent(FlowLayoutPanel1, fTextisNULL(rd("PARAMETER_ID3")))
                If prValue = "" Then
                    prValue = "*"
                End If
                sQUERY = sQUERY.Replace(rd("VARIABLE_NAME3"), prValue)
                sQUERY = sQUERY.Replace(sOP, IIf(prValue = "*", "OR", "AND"))
            End If

            '{AND_OR}  OR = "*" AND  <> "*"

            fComboBox(cmb, sQUERY, rd("VALUE_NAME"), rd("DISPLAY_NAME"))
            fDoEvents()
            ' cmb.SelectedIndex = -1
            cmb.SelectedValue = fTextisNULL(rd("DEFAULT_VALUE"))



        End If
    End Sub
    Private Function fSearchComponent(ByVal control As Control, ByVal prID As String) As String
        Dim value As String = ""
        For i As Integer = 0 To control.Controls.Count - 1
            Dim c As Control = control.Controls(i)
            If c.Name = prID Then
                value = fGetValue(c)
                Exit For
            Else
                If fLeft(c.Name, 3) = "pnl" Then
                    Dim pnl As Panel = c
                    value = fSearchComponent(pnl, prID)
                    If value <> "" Then
                        Exit For
                    End If

                End If
            End If

        Next
        Return value
    End Function

    Private Function fSearchComponent_Control(ByVal ctrl As Control, ByVal prID As String) As Control
        Dim value As Control = Nothing
        For i As Integer = 0 To ctrl.Controls.Count - 1
            Dim c As Control = ctrl.Controls(i)
            If c.Name = prID Then
                value = c
                Exit For
            Else
                If fLeft(c.Name, 3) = "pnl" Then
                    Dim pnl As Panel = c
                    value = fSearchComponent_Control(pnl, prID)
                    If value IsNot Nothing Then
                        Exit For
                    End If

                End If
            End If
        Next
        Return value
    End Function
    Public Function fGetValue(ByVal c As Control) As String
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

    'Private Sub fDropDownChange(sender As Object, e As EventArgs)
    '    Dim cmb As ComboBox = DirectCast(sender, ComboBox)
    '    If cmb IsNot Nothing Then
    '        Dim cbo As ComboBox = 
    '    End If
    'End Sub
    Private Function fAddPanel(ByVal prName As String, ByVal prWidth As Integer) As Panel
        Dim p As Panel = New Panel
        p.Name = "pnl" & prName
        p.Width = prWidth
        p.Height = 23
        FlowLayoutPanel1.Controls.Add(p)
        Return p
    End Function


    Private Sub frmReportSetup_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        fTabName(Me.Name, gsReportTabName)
        lklFileName.Text = gsReportFileName
    End Sub
    Private Sub fLoadComponent()
        Dim dtRange As ComboBox = Nothing
        Try

            Dim dtp1 As DateTimePicker = Nothing
            Dim dtp2 As DateTimePicker = Nothing
            Dim iLeft As Integer = 0
            Dim iTop As Integer = 0
            Dim rd As OdbcDataReader = fReader("select r.ID,r.COMPONENT_ID,c.TYPE,c.NAME,c.SQL_STATEMENT,c.VALUE_NAME,c.DISPLAY_NAME,c.DEFAULT_VALUE,c.REPORT_PARAMETER_NAME,c.PARAMETER_ID1,c.VARIABLE_NAME1,c.PARAMETER_ID2,c.VARIABLE_NAME2,c.PARAMETER_ID3,c.VARIABLE_NAME3 from report_components as r inner join component as c on c.ID = r.COMPONENT_ID where sub_id = '" & Me.AccessibleDescription & "' order by r.LINE_NO")
            While rd.Read

                Select Case fNumisNULL(rd("TYPE"))
                    Case 1

                        Dim p As Panel = fAddPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label
                        l.Name = "lbl" & rd("COMPONENT_ID")
                        l.Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        p.Controls.Add(l)

                        'TEXT
                        Dim txt As New TextBox
                        txt.Name = rd("COMPONENT_ID")
                        txt.AccessibleDescription = fTextisNULL(rd("SQL_STATEMENT"))
                        txt.AccessibleName = fTextisNULL(rd("DISPLAY_NAME"))
                        txt.Tag = fTextisNULL(rd("DISPLAY_NAME"))
                        txt.Left = 100
                        AddHandler txt.TextChanged, AddressOf fText_Change
                        p.Controls.Add(txt)

                    Case 2
                        Dim p As Panel = fAddPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label
                        l.Name = "lbl" & rd("COMPONENT_ID")
                        l.Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        p.Controls.Add(l)
                        'DROPDOWN STANDARD
                        Dim cmb As New ComboBox
                        cmb.Name = rd("COMPONENT_ID")

                        cmb.AccessibleDescription = fNumisNULL(rd("TYPE"))
                        cmb.AccessibleName = fTextisNULL(rd("REPORT_PARAMETER_NAME"))
                        cmb.Left = 100
                        cmb.Width = 300

                        fDropDown(cmb)
                        AddHandler cmb.SelectedIndexChanged, AddressOf fChangeDropDown_Change
                        p.Controls.Add(cmb)

                    Case 3
                        Dim p As Panel = fAddPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label
                        l.Name = "lbl" & rd("COMPONENT_ID")
                        l.Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        p.Controls.Add(l)
                        'DROPDOWN FIXED
                        Dim cmb As New ComboBox
                        cmb.Name = rd("COMPONENT_ID")

                        cmb.AccessibleDescription = fNumisNULL(rd("TYPE"))
                        cmb.AccessibleName = fTextisNULL(rd("REPORT_PARAMETER_NAME"))
                        cmb.DropDownStyle = ComboBoxStyle.DropDownList
                        cmb.Left = 100
                        cmb.Width = 300

                        fDropDown(cmb)
                        AddHandler cmb.SelectedIndexChanged, AddressOf fChangeDropDown_Change
                        p.Controls.Add(cmb)

                        If rd("NAME") = "LOCATION" Then
                            cmb.SelectedValue = gsDefault_LOCATION_ID
                            cmb.Enabled = fLockLocation()
                        End If
                    Case 4
                        Dim p As Panel = fAddPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label
                        l.Name = "lbl" & rd("COMPONENT_ID")
                        l.Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))

                        p.Controls.Add(l)
                        'DATE
                        Dim dt As New DateTimePicker
                        dt.Name = rd("COMPONENT_ID")
                        dt.AccessibleDescription = fNumisNULL(rd("TYPE"))
                        dt.AccessibleName = fTextisNULL(rd("REPORT_PARAMETER_NAME"))
                        dt.Left = 100
                        dt.Format = DateTimePickerFormat.Short
                        p.Controls.Add(dt)

                        If dtp1 Is Nothing Then
                            dtp1 = dt
                        ElseIf dtp2 Is Nothing Then
                            dtp2 = dt
                        End If

                        If fTextisNULL(rd("NAME")) = "SELECT_DATE" Then
                            If gsSelectedDateDefault = "Today" Then
                                dt.Value = Date.Now.Date
                            ElseIf gsSelectedDateDefault = "Yesterday" Then
                                dt.Value = Date.Now.Date.AddDays(-1)
                            End If
                        End If

                    Case 5
                    'NUMBER
                    Case 6
                        Dim p As Panel = fAddPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label
                        l.Name = "lbl" & rd("COMPONENT_ID")
                        l.Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        l.AccessibleDescription = fTextisNULL(rd("VALUE_NAME"))
                        l.AccessibleName = fTextisNULL(rd("DISPLAY_NAME"))
                        p.Controls.Add(l)
                        'CHECKBOX
                        Dim chk As New CheckBox
                        chk.Name = rd("COMPONENT_ID")
                        chk.AccessibleDescription = fNumisNULL(rd("TYPE"))
                        chk.AccessibleName = fTextisNULL(rd("REPORT_PARAMETER_NAME"))
                        chk.Left = 100
                        AddHandler chk.CheckedChanged, AddressOf fChecKBox_Change
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
                        Dim p As Panel = fAddPanel(rd("NAME") & rd("ID"), 400)
                        p.Top = iTop
                       ' BLANK PANEL
                    Case 9
                        Dim p As Panel = fAddPanel(rd("NAME"), 400)
                        p.Top = iTop
                        Dim l As New Label
                        l.Name = "lbl" & rd("COMPONENT_ID")
                        l.Text = fTitleCase(Trim(rd("NAME").ToString.Replace("_", " ").ToLower))
                        p.Controls.Add(l)
                        Dim cmb As ComboBox
                        cmb = fDataRangeLoad(rd("COMPONENT_ID"))
                        cmb.Left = 100
                        cmb.Width = 300
                        AddHandler cmb.SelectedIndexChanged, AddressOf fDateRange_Change
                        p.Controls.Add(cmb)
                        dtRange = cmb


                End Select
                iTop = iTop + 30
            End While
            If dtRange IsNot Nothing Then

                dtRange.Text = gsDateRangeDefault

            End If

            'If dtp1 IsNot Nothing And dtp2 IsNot Nothing Then
            '    dtp1.Value = fGet_System_VALUE("dtpDATE_FROM")
            '    dtp2.Value = fGet_System_VALUE("dtpDATE_TO")
            'End If
        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try
    End Sub
    Private Sub fChangeDropDown_Change(sender As Object, e As EventArgs)

        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        Dim rd As OdbcDataReader = fReader("select c.ID from report_components as r inner join component as c on c.ID = r.component_ID where r.SUB_ID = '" & Me.AccessibleDescription & "' and (c.PARAMETER_ID1 ='" & cmb.Name & "' or c.PARAMETER_ID2 ='" & cmb.Name & "' or PARAMETER_ID3 ='" & cmb.Name & "')")
        While rd.Read
            Dim c As Control = fSearchComponent_Control(FlowLayoutPanel1, rd("ID"))
            Try
                If c IsNot Nothing Then
                    Dim cbo As ComboBox = c
                    fDropDown(cbo)
                End If
            Catch ex As Exception
                fMessageboxExclamation(ex.Message)
            End Try



        End While
    End Sub
    Private Function fGET_STATEMENT_VALUE(ByVal sql As String, ByVal prDisplay As String, ByVal myValue As String) As String
        Dim sQuery As String = sql.Replace("`", "'")
        sQuery = sQuery.Replace(prDisplay, myValue)
        Dim rd As OdbcDataReader = fReader(sQuery)
        Dim strValue As String = ""
        If rd.Read Then
            strValue = fTextisNULL(rd(0))
        End If
        Return strValue
    End Function
    Private Function fGetObject(ByVal prName As String) As Control
        Return fSearchComponent_Control(FlowLayoutPanel1, prName)

    End Function

    Private Sub fChecKBox_Change(sender As Object, e As EventArgs)
        Dim chk As CheckBox = DirectCast(sender, CheckBox)
        Dim lbl As Label = fGetObject("lbl" & chk.Name)
        If chk.Checked = True Then

            lbl.Text = fTitleCase(lbl.AccessibleDescription)
        Else
            lbl.Text = fTitleCase(lbl.AccessibleName)
        End If
    End Sub
    Private Sub fText_Change(sender As Object, e As EventArgs)

        Dim txt As TextBox = DirectCast(sender, TextBox)
        Dim rd As OdbcDataReader = fReader("select c.ID from report_components as r inner join component as c on c.ID = r.component_ID where r.SUB_ID = '" & Me.AccessibleDescription & "' and (c.PARAMETER_ID1 ='" & txt.Name & "' or c.PARAMETER_ID2 ='" & txt.Name & "' or PARAMETER_ID3 ='" & txt.Name & "')")
        While rd.Read
            Dim c As Control = fSearchComponent_Control(FlowLayoutPanel1, rd("ID"))

            Try
                If c IsNot Nothing Then
                    Dim cbo As ComboBox = c
                    Select Case cbo.AccessibleDescription
                        Case 1
                        Case 2
                            '  fDropDown(cbo)
                            cbo.SelectedValue = fGET_STATEMENT_VALUE(txt.AccessibleDescription, txt.AccessibleName, txt.Text)
                        Case 3
                            ' fDropDown(cbo)
                            cbo.SelectedValue = fGET_STATEMENT_VALUE(txt.AccessibleDescription, txt.AccessibleName, txt.Text)
                    End Select




                End If
            Catch ex As Exception
                fMessageboxExclamation(ex.Message)
            End Try



        End While

    End Sub

    Private Sub tsClose_Click(sender As Object, e As EventArgs) Handles tsClose.Click

        fCloseForm(Me)
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        If cmbPRINTER.Text.Trim = "" Then
            fMessageboxInfo("Please select printer")
            Exit Sub
        End If

        fCursorLoadingOn(True)
        Try
            fSetDefaultPrinter(cmbPRINTER.Text)
            fStartReport()
            fPreviewReport(ToolStripLabel5.Text)




        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try

        fCursorLoadingOn(False)
        'fSetDefaultPrinter(gsDEFAULT_PRINTER)
    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsPrint.Click
        If cmbPRINTER.Text.Trim = "" Then
            fMessageboxInfo("Please select printer")
            Exit Sub
        End If
        fCursorLoadingOn(True)
        Try
            fSetDefaultPrinter(cmbPRINTER.Text)
            fDoEvents()
            fStartReport()
            gscryRpt.PrintToPrinter(1, False, 0, 0)
            fReportExporPDF(gscryRpt, ToolStripLabel5.Text)
            '  fSetDefaultPrinter(gsDEFAULT_PRINTER)
        Catch ex As Exception
            fMessageboxWarning(ex.Message)
        End Try
        fCursorLoadingOn(False)
    End Sub
    Private Sub fDateRange_Change(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        Dim rd As OdbcDataReader = fReader("select c.ID from report_components as r inner join component as c on c.ID = r.component_ID where r.SUB_ID = '" & Me.AccessibleDescription & "' and (c.PARAMETER_ID1 ='" & cmb.Name & "' or c.PARAMETER_ID2 ='" & cmb.Name & "' or PARAMETER_ID3 ='" & cmb.Name & "')")
        Dim dt1 As DateTimePicker = Nothing
        Dim dt2 As DateTimePicker = Nothing
        While rd.Read
            If dt1 Is Nothing Then
                dt1 = fGetObject(rd("ID"))
            ElseIf dt2 Is Nothing Then
                dt2 = fGetObject(rd("ID"))
            End If
        End While
        fSelectDateRange(cmb.Text, dt1, dt2)

    End Sub
    Private Sub cmbDateRange_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub lklFileName_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lklFileName.LinkClicked
        If gsAdmin_User = 0 Then
            Exit Sub
        End If
        With frmReportManager
            .gsSUB_ID = Me.AccessibleDescription
            .lblNAME.Text = ToolStripLabel5.Text
            .ShowDialog()
            .Dispose()
        End With
        frmReportManager = Nothing
        FlowLayoutPanel1.Visible = False
        FlowLayoutPanel1.Controls.Clear()
        fLoadComponent()
        FlowLayoutPanel1.Visible = True


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class