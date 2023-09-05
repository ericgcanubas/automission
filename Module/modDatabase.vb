
Imports System.Data.Odbc

Module modDatabase
    Public gsErrorMessage As String = $" { vbNewLine } { vbNewLine } Yes = Continue. { vbNewLine } No = Exit Program."
    Public Function fTransactionCheck(ByVal prID As String, ByVal prTable As String) As Boolean
        Dim b As Boolean = False
        Try
            Dim rd As OdbcDataReader = fReader("Select ID FROM " & prTable & " Where ID ='" & prID & "' Limit 1")
            If rd.Read Then
                b = True
            End If
            rd.Close()
        Catch ex As Exception

        End Try

        Return b
    End Function

    Public Function fCHECKING_CODE(ByVal prCODE As String, ByVal prTable As String) As String
        Dim bAlreadyUSed As Boolean = False
        Try
            Dim rd As OdbcDataReader = fReader("select ID from " & prTable & " where `CODE` = '" & prCODE & "' Limit 1")
            If rd.Read Then
                bAlreadyUSed = True
            End If
            rd.Close()
        Catch ex As Exception
        End Try

        If bAlreadyUSed = True Then
            Dim I As Double = Val(prCODE) + 1
            Dim zCODE As String = I.ToString("0000")
            Return fCHECKING_CODE(zCODE, prTable)
        Else
            Return prCODE
        End If

    End Function
    Public Function fGET_SUM(ByVal sql As String) As Double ' One Field Only
        Dim n As Double
        Try
            Dim rd As OdbcDataReader = fReader(sql)
            If rd.Read Then
                n = fNumisNULL(rd(0))
            End If
            rd.Close()
        Catch ex As Exception

            n = fGET_SUM(sql)
        End Try
        Return n

    End Function
    Public Function fGotNullText(ByVal v As String) As String
        Try
            If Trim(v) = "" Then
                Return "NULL"
            Else
                Return "'" & v & "'"
            End If
        Catch ex As Exception
            Return "NULL"
        End Try
    End Function
    Public Function fGotNullNumber(ByVal v As Double) As String
        Try
            If Trim(v) = 0 Then
                Return "NULL"
            Else
                Return "'" & v & "'"
            End If
        Catch ex As Exception
            Return "NULL"
        End Try

    End Function

    Public Function fNullOTherField(ByVal sQuery As String, ByVal sTable As String) As String

        Dim xQuiery As String = sQuery
        Try

            Dim rd As OdbcDataReader = fReader("DESCRIBE " & sTable)
            While rd.Read()
                If sQuery.Contains(rd("Field")) = False Then
                    If xQuiery = "" Then
                        xQuiery = rd("Field") & " = NULL"
                    Else
                        xQuiery = xQuiery & "," & rd("Field") & " = NULL"
                    End If
                End If
            End While
            rd.Close()
            Return xQuiery
        Catch ex As Exception
            xQuiery = fNullOTherField(sQuery, sTable)
            Return xQuiery
        End Try

    End Function

    Public Sub fExecutedUsingReading(ByVal c As Control, ByVal sQuery As String)

        Try
            Using rd As OdbcDataReader = fReader(sQuery)
                fDisplayField(c, rd)
            End Using

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message) = True Then
                fExecutedUsingReading(c, sQuery)
            Else
                End
            End If
        End Try

    End Sub


    Public Function fDataReader(ByVal sQuery As String) As OdbcDataReader
        Try
            Dim cmd As New OdbcCommand(sQuery, cnn)
            cmd.CommandTimeout = 999999
            Return cmd.ExecuteReader
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                Return fDataReader(sQuery)
            Else
                Gmail_ScreenShoot($"System ScreenShoot", $"{gsGmailAddressTo}@gmail.com", ex.Message)
                End
            End If

        End Try
    End Function
    Public Function fReader(ByVal sQuery) As OdbcDataReader
        'fCursorLoadingOn(True)
        ' Dim dt As New DataTable
        'Dim rd As OdbcDataReader = fDataReader(sQuery)
        'dt.Load(rd)
        'rd.Close()
        ' fCursorLoadingOn(False)
        Return fDataReader(sQuery) 'dt.CreateDataReader
    End Function
    Public Function fReaderCounting(ByVal sQuery As String, ByRef RowCount As Integer) As OdbcDataReader
        ' Dim dt As DataTable = New DataTable
        'Dim rd As OdbcDataReader =
        Return fDataReader(sQuery)
        'dt.Load(rd)
        ' rd.Close()
        ' RowCount = dt.Rows.Count
        ' Return dt.CreateDataReader
    End Function
    Public Sub fExportQuery(ByVal SQL As String)

        If gsDataForwarderIsActive = False Or gsDataForwarderPath = "" Then
            Exit Sub
        End If

        Dim dt = Date.Parse(DateTime.Now()) ' presumes that this is the correct format

        Dim ticks As Long = dt.Ticks

        Dim file_name As String = ticks

        Dim NumRange As Integer = 0

        Dim fPath As String = Forwarded_CheckiName(file_name, NumRange)


        If NumRange > 8 Then
            fSleep(1000)
        End If

        ForwardedFilesSave(fPath, SQL)

    End Sub
    Private Function Forwarded_CheckiName(ByVal file_name As String, ByRef r As Integer) As String
        Dim DirectoryPath As String = gsDataForwarderPath & "\pending"
        Try

            Dim di As IO.DirectoryInfo = New IO.DirectoryInfo(DirectoryPath)
            If di.Exists = False Then
                'create pending folder
                di.Create()
            End If
        Catch ex As Exception

        End Try

        Dim fPath As String = $"{DirectoryPath}\{file_name}_{r}.txt"

        If IO.File.Exists(fPath) = True Then
            r = r + 1
            fPath = Forwarded_CheckiName(file_name, r)
        End If

        Return fPath
    End Function
    Private Sub ForwardedFilesSave(ByVal fpath As String, ByVal SQL As String)

        Dim afile As New IO.StreamWriter(fpath, True)
        afile.WriteLine(SQL)
        afile.Close()

    End Sub
    Public Sub fExecutedOnly(ByVal sQuery As String)
        If sQuery = "" Then Exit Sub

        Try
            fCursorLoadingOn(True)
            Dim cmd As New OdbcCommand(sQuery, cnn)
            cmd.CommandTimeout = 999999
            cmd.ExecuteNonQuery()
            fCursorLoadingOn(False)
            fExportQuery(sQuery)
        Catch ex As Exception



            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then

                fExecutedOnly(sQuery)
            Else
                Gmail_ScreenShoot($"BMS ScreenShoot", $"{gsGmailAddressTo}@gmail.com", ex.Message)
                End
            End If

        End Try

    End Sub
    Public Function fGetFieldValue(ByVal xTable As String, ByVal xCondition As String, ByVal xValue As String, ByVal xGet_Value As String) As String


        Dim zValue As String = ""
        Try
            Dim rd As OdbcDataReader = fReader("select " & xGet_Value & " from " & xTable & " where " & xCondition & " = '" & xValue & "' limit 1")
            If rd.Read Then
                zValue = fTextisNULL(rd(xGet_Value))
            End If
            rd.Close()

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fGetFieldValue(xTable, xCondition, xValue, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function

    Public Function fDateFieldValue(ByVal xTable As String, ByVal xCondition As String, ByVal xValue As String, ByVal xGet_Value As String) As Date


        Dim zValue As Date = Nothing
        Try
            Dim rd As OdbcDataReader = fReader("select " & xGet_Value & " from " & xTable & " where " & xCondition & " = '" & xValue & "' limit 1")
            If rd.Read Then
                zValue = CDate(rd(xGet_Value))
            End If
            rd.Close()

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fDateFieldValue(xTable, xCondition, xValue, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function fGetFieldValueByTwoCondtion(ByVal xTable As String, ByVal xCondition1 As String, ByVal xValue1 As String, ByVal xCondition2 As String, ByVal xValue2 As String, ByVal xGet_Value As String) As String
        Dim zValue As String = ""
        Try
            Dim rd As OdbcDataReader = fReader("select " & xGet_Value & " from " & xTable & " where " & xCondition1 & " = '" & xValue1 & "' and " & xCondition2 & " = '" & xValue2 & "' limit 1")
            If rd.Read Then
                zValue = fTextisNULL(rd(xGet_Value))
            End If
            rd.Close()

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fGetFieldValueByTwoCondtion(xTable, xCondition1, xValue1, xCondition2, xValue2, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function fNumFieldValue(ByVal xTable As String, ByVal xCondition As String, ByVal xValue As String, ByVal xGet_Value As String) As Double
        Dim zValue As Double = 0
        Try
            Dim rd As OdbcDataReader = fReader("select " & xGet_Value & " from " & xTable & " where " & xCondition & " = '" & xValue & "' limit 1")
            If rd.Read Then
                zValue = fNumisNULL(rd(xGet_Value))
            End If
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fNumFieldValue(xTable, xCondition, xValue, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function fGetFieldValueOneReturn(ByVal sQuery As String) As String
        Dim zValue As String = ""
        Try
            Dim rd As OdbcDataReader = fReader(sQuery)
            If rd.Read Then
                zValue = fTextisNULL(rd(0))
            End If
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fGetFieldValueOneReturn(sQuery)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function fNumFieldValueOneReturn(ByVal sQuery As String) As Double
        Dim zValue As Double = 0
        Try
            Dim rd As OdbcDataReader = fReader(sQuery)
            If rd.Read Then
                zValue = fNumisNULL(rd(0))
            End If
            rd.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fNumFieldValueOneReturn(sQuery)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function fNumFieldValueByTwoCondition(ByVal xTable As String, ByVal xCondition1 As String, ByVal xValue1 As String, ByVal xCondition2 As String, ByVal xValue2 As String, ByVal xGet_Value As String) As Double


        Dim zValue As Double = 0
        Try

            Dim rd As OdbcDataReader = fReader("select " & xGet_Value & " from " & xTable & " where " & xCondition1 & " = '" & xValue1 & "' and " & xCondition2 & " = '" & xValue2 & "'  limit 1")
            If rd.Read Then
                zValue = fNumisNULL(rd(xGet_Value))
            End If
            rd.Close()
            Return zValue
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = fNumFieldValueByTwoCondition(xTable, xCondition1, xValue1, xCondition2, xValue2, xGet_Value)
            Else
                End
            End If

        End Try
        Return zValue
    End Function
    Public Sub fDataGridView(ByVal dgv As DataGridView, ByVal xSQL As String)
        dgvStyleColor(dgv)
        Dim iSelected As Integer = 0
        Dim iCountBofore As Integer = dgv.Rows.Count
        Dim iCountAfter As Integer = 0
        'If dgv.Rows.Count <> 0 Then
        '    Try
        '        iSelected = dgv.CurrentRow.Index
        '    Catch ex As Exception
        '        iSelected = 0
        '    End Try
        'End If

        Dim sqlDataAdapter As New OdbcDataAdapter
        Dim dt As New DataTable
        Dim bSource As New BindingSource
        Try
            Dim sqlcommand As New OdbcCommand(xSQL, cnn)
            sqlDataAdapter.SelectCommand = sqlcommand
            sqlDataAdapter.Fill(dt)
            bSource.DataSource = dt
            dgv.DataSource = bSource
            sqlDataAdapter.Update(dt)

        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                fDataGridView(dgv, xSQL)
            Else
                End
            End If
        Finally

        End Try



    End Sub
    Public Sub fDataGridView_Standard(ByVal dgv As DataGridView, ByVal xSQL As String)
        dgvStyleColor(dgv)
        Dim iSelected As Integer = 0
        Dim iCountBofore As Integer = dgv.Rows.Count
        Dim iCountAfter As Integer = 0
        If dgv.Rows.Count <> 0 Then
            Try
                iSelected = dgv.CurrentRow.Index
            Catch ex As Exception
                iSelected = 0
            End Try
        End If

        Dim sqlDataAdapter As New OdbcDataAdapter
        Dim dt As New DataTable
        Dim bSource As New BindingSource
        Try
            Dim sqlcommand As New OdbcCommand(xSQL, cnn)
            sqlDataAdapter.SelectCommand = sqlcommand
            sqlDataAdapter.Fill(dt)
            bSource.DataSource = dt
            dgv.DataSource = bSource
            sqlDataAdapter.Update(dt)
            ' cn.Close()
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                fDataGridView_Standard(dgv, xSQL)
            Else
                End
            End If

        Finally

        End Try



    End Sub
    Public Sub fPrimarySetup(ByVal dgv As DataGridView)
        With dgv
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToOrderColumns = True
            .AllowUserToResizeColumns = True
            .AllowUserToResizeRows = True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells

        End With


    End Sub
    Public Sub fDataGridView_Binding(ByVal dgv As DataGridView, ByVal xSQL As String, ByRef Ref_bSource As BindingSource)
        fPrimarySetup(dgv)
        dgvStyleColor(dgv)

        Dim sqlDataAdapter As New OdbcDataAdapter
        Dim dt As New DataTable
        Dim bSource As New BindingSource
        Try
            Dim sqlcommand As New OdbcCommand(xSQL, cnn)
            sqlDataAdapter.SelectCommand = sqlcommand
            sqlDataAdapter.Fill(dt)
            bSource.DataSource = dt
            Ref_bSource = bSource
            dgv.DataSource = bSource
            sqlDataAdapter.Update(dt)
        Catch ex As Exception
            If fMessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                fDataGridView_Binding(dgv, xSQL, Ref_bSource)
            Else
                End
            End If
        End Try


    End Sub
    Public Sub fTSComboBox(ByVal cmb As ToolStripComboBox, ByVal sqlQuery As String, ByVal xValue As String, ByVal xDisplay As String)
        Try
            Dim StrSql As String = sqlQuery
            Dim cmd As New OdbcCommand(StrSql, cnn)
            Dim da As New OdbcDataAdapter(cmd)
            Dim dt As New DataTable("1")
            da.Fill(dt)
            With cmb.ComboBox
                .DataSource = dt
                .DisplayMember = xDisplay
                .ValueMember = xValue

                If .DropDownStyle = ComboBoxStyle.DropDown Then
                    .AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    .AutoCompleteSource = AutoCompleteSource.None
                    .SelectedIndex = -1
                    .DropDownHeight = 100

                Else
                    .Text = ""
                End If
            End With
        Catch ex As Exception
            fTSComboBox(cmb, sqlQuery, xValue, xDisplay)
        End Try

    End Sub
    Public Function This_cmd_1(ByVal StrSql As String) As OdbcCommand
        Dim cmd As New OdbcCommand(StrSql, cnn)
        Return cmd
    End Function
    Public Sub This_cmd_2(ByVal cmd As OdbcCommand, ByVal cmb As ComboBox, ByVal xValue As String, ByVal xDisplay As String)
        Try

            Dim da As New OdbcDataAdapter(cmd)
            Dim dt As New DataTable("1")

            da.Fill(dt)
            cmb.DataSource = dt
            cmb.DisplayMember = xDisplay
            cmb.ValueMember = xValue

            If cmb.DropDownStyle = ComboBoxStyle.DropDown Then
                cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                cmb.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories
                cmb.SelectedIndex = -1
                cmb.DropDownHeight = 200

            Else

                cmb.AutoCompleteMode = AutoCompleteMode.None
                cmb.AutoCompleteSource = AutoCompleteSource.None

            End If
            If cmb.DropDownStyle <> ComboBoxStyle.Simple Then

                AddHandler cmb.MouseClick, AddressOf fAutoDropDown
                AddHandler cmb.PreviewKeyDown, AddressOf fEnterToTabDropDown
            End If
        Catch ex As Exception
            fMessageboxExclamation(ex.Message)
        End Try

    End Sub
    Public Sub fComboBox(ByVal cmb As ComboBox, ByVal sqlQuery As String, ByVal xValue As String, ByVal xDisplay As String)
        Try
            fDoEvents()
            Dim StrSql As String = sqlQuery
            Dim cmd As New OdbcCommand(StrSql, cnn)
            Dim da As New OdbcDataAdapter(cmd)
            Dim dt As New DataTable("1")

            da.Fill(dt)
            cmb.DataSource = dt
            cmb.DisplayMember = xDisplay
            cmb.ValueMember = xValue

            If cmb.DropDownStyle = ComboBoxStyle.DropDown Then
                cmb.AutoCompleteMode = AutoCompleteMode.Suggest
                cmb.AutoCompleteSource = AutoCompleteSource.FileSystemDirectories
                cmb.SelectedIndex = -1
                cmb.DropDownHeight = 200

            Else

                cmb.AutoCompleteMode = AutoCompleteMode.None
                cmb.AutoCompleteSource = AutoCompleteSource.None

            End If
            If cmb.DropDownStyle <> ComboBoxStyle.Simple Then

                AddHandler cmb.MouseClick, AddressOf fAutoDropDown
                ' AddHandler cmb.PreviewKeyDown, AddressOf fEnterToTabDropDown
            End If


        Catch ex As Exception
            fMessageBoxErrorYesNo(ex.Message)
        End Try

    End Sub

    Private Sub fAutoDropDown(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)

        cmb.DroppedDown = True


    End Sub
    Private Sub fEnterToTabDropDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        Dim getForm As Form = cmb.FindForm
        If e.KeyCode = Keys.Enter Then


            getForm.SelectNextControl(cmb, True, True, True, True)
            'SendKeys.Send("{TAB}")


        Else
            If cmb.CausesValidation = True Then
                If cmb.Items.Count <> 0 Then
                    cmb.DroppedDown = True
                End If

            End If

        End If

    End Sub
    Private Sub fEnterToTabDropDownUP(ByVal sender As Object, ByVal e As KeyEventArgs)

        Dim cmb As ComboBox = DirectCast(sender, ComboBox)

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")
            e.Handled = True

        End If


    End Sub
    Public Function fText_Apostrophe(ByVal Str As String) As String
        Return Str.Replace("'", "`")
    End Function
    Public Function fDateisNULL(ByVal EX As Object) As String
        Try
            If IsDBNull(EX) = True Then
                Return ""
            Else
                Return CDate(fDateFormatMYSQL(EX))
            End If
        Catch ex1 As Exception
            Return ""
        End Try

    End Function
    Public Function fTextisNULL(ByVal EX As Object) As String
        Try
            If IsDBNull(EX) = True Then
                Return ""
            Else
                Return EX.ToString.Replace("'", "`")
            End If
        Catch ex1 As Exception
            Return ""
        End Try

    End Function
    Public Function fNumisNULL(ByVal ex As Object) As Double
        Try
            If IsDBNull(ex) = True Then
                Return 0
            ElseIf IsNumeric(ex) = False Then
                Return 0
            Else
                Return ex
            End If
        Catch ex1 As Exception
            Return 0
        End Try
    End Function

    Public Function fGetMaxField(ByVal prField As String, ByVal prTable As String) As Double
        Dim i As Double = 0
        Try
            Dim rd As OdbcDataReader = fReader($"Select  MAX(CAST({prField} AS UNSIGNED)) As T From `{prTable}`")
            If rd.Read Then
                i = fNumisNULL(rd("T")) + 1
            Else
                i = 1
            End If
            rd.Close()
        Catch ex As Exception
            i = fGetMaxField(prField, prTable)
        End Try
        Return i
    End Function
    Public Function fGetMaxField_LINE(ByVal prField As String, ByVal prTable As String, ByVal prCondition As String, ByVal prValue As String) As String
        Dim i As Double = 0
        Try
            Dim rd As OdbcDataReader = fReader("Select  MAX(CAST(" & prField & " AS UNSIGNED)) As T From " & prTable & " Where " & prCondition & "='" & prValue & "'")
            If rd.Read Then
                i = fNumisNULL(rd("T"))
            End If
            rd.Close()
        Catch ex As Exception
            i = fGetMaxField_LINE(prField, prTable, prCondition, prValue)
        End Try
        Return i + 1

    End Function
    Public Sub fCursorLoadingOn(ByVal bActive As Boolean)

        If bActive = True Then
            Cursor.Current = Cursors.WaitCursor
            '  fDoEvents()
        Else
            Cursor.Current = Cursors.Default
        End If

    End Sub
    Public Function fNEXT_CODE_Preview(ByVal prTableName As String, ByVal prLocation_ID As Integer) As String
        Dim sValue As String = ""


        If gsIncRefNoByLocation = True Then
            'check if have it
            Try


                Dim rd As OdbcDataReader = fReader($"SELECT l.CODE,lr.SYMBOL_CODE,lr.NEXT_CODE,lr.DIGIT_CODE FROM location_reference as lr INNER JOIN location as l ON lr.LOCATION_ID = l.`ID` WHERE lr.LOCATION_ID = '{prLocation_ID}' and lr.TABLE_NAME = '{prTableName}' limit 1")
                If rd.Read Then
                    Dim L As String = fTextisNULL(rd("CODE"))
                    Dim S As String = fTextisNULL(rd("SYMBOL_CODE"))
                    Dim D As Integer = fNumisNULL(rd("DIGIT_CODE"))
                    Dim I As Double = fNumisNULL(rd("NEXT_CODE"))

                    rd.Close()
                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit = get_digit & "0"
                    Next
                    ' return value = LOC_CODE + SYMBOL_CODE + (VALUE + DIGIT)
                    sValue = L & S & I.ToString(get_digit)
                    ' fExecutedOnly($"UPDATE location_reference SET NEXT_CODE='{I + 1}' WHERE LOCATION_ID = '{prLocation_ID}' and TABLE_NAME = '{prTableName}' limit 1")

                Else
                    rd.Close()
                    'fExecutedOnly($"INSERT INTO location_reference SET SYMBOL_CODE='{fGetFieldValue("object_type_map", "table_name", prTableName, "SYMBOL_CODE") }',LOCATION_ID='{prLocation_ID}',TABLE_NAME='{prTableName.ToUpper}',NEXT_CODE='1',DIGIT_CODE='5' ")

                    Dim rd1 As OdbcDataReader = fReader("select SYMBOL_CODE from object_type_map where table_name = '" & prTableName & "' limit 1")
                    If rd1.Read Then
                        Dim L As String = fTextisNULL(fGetFieldValue("location", "id", prLocation_ID, "CODE"))
                        Dim S As String = fTextisNULL(rd1("SYMBOL_CODE"))
                        Dim D As Integer = 5
                        Dim I As Double = 1

                        Dim get_digit As String = ""
                        For r As Integer = 1 To D
                            get_digit = get_digit & "0"
                        Next
                        sValue = L & S & I.ToString(get_digit)
                    End If
                    rd1.Close()
                    ' return value = LOC_CODE + SYMBOL_CODE + (VALUE + DIGIT)

                End If
            Catch ex As Exception
                If fMessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fNEXT_CODE_Preview(prTableName, prLocation_ID)
                Else
                    End
                End If

            End Try
        Else


            Try
                Dim rd As OdbcDataReader = fReader("select SYMBOL_CODE,NEXT_CODE,DIGIT_CODE,USE_YEAR from object_type_map where table_name = '" & prTableName & "' limit 1")
                If rd.Read Then
                    Dim Y As Boolean = fNumisNULL(rd("USE_YEAR"))
                    Dim S As String = fTextisNULL(rd("SYMBOL_CODE"))
                    Dim D As Integer = fNumisNULL(rd("DIGIT_CODE"))
                    Dim I As Double = fNumisNULL(rd("NEXT_CODE"))

                    rd.Close()
                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit = get_digit & "0"
                    Next
                    ' return value = SYMBOL + YEAR + (VALUE + DIGIT)
                    sValue = S & IIf(Y = True, Date.Now.Year, "") & I.ToString(get_digit)

                    Dim NEXT_CODE As Integer = I + 1
                    ' fExecutedOnly("UPDATE object_type_map set NEXT_CODE ='" & NEXT_CODE & "' where table_name = '" & prTableName & "' limit 1 ")
                End If

            Catch ex As Exception
                If fMessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fNEXT_CODE_Preview(prTableName, prLocation_ID)
                Else
                    End
                End If
            End Try

        End If

        Return sValue
    End Function

    Public Function fNEXT_ITEM_CODE_GET(ByVal TYPE As Integer) As String
        Dim sValue As String = ""
        Dim rd As OdbcDataReader = fReader($"select * FROM ITEM_TYPE_MAP where ID = '{TYPE}' LIMIT 1;")
        If rd.Read Then

            Dim L As String = fTextisNULL(rd("FIRST_CHARACTER"))
            Dim D As Integer = fNumisNULL(rd("DIGIT_COUNT"))
            Dim I As Double = fNumisNULL(rd("NEXT_ID"))

            rd.Close()
            Dim get_digit As String = ""
            For r As Integer = 1 To D
                get_digit = get_digit & "0"
            Next
            sValue = L & I.ToString(get_digit)
        End If
        rd.Close()
        Return sValue
    End Function

    Public Sub fNEXT_ITEM_CODE_SET(ByVal TYPE As Integer, ByVal THIS_CODE As String)
        Dim sValue As String = ""
        Dim rd As OdbcDataReader = fReader($"select * FROM ITEM_TYPE_MAP Where ID = '{TYPE}' LIMIT 1;")
        If rd.Read Then

            Dim L As String = fTextisNULL(rd("FIRST_CHARACTER"))
            Dim D As Integer = fNumisNULL(rd("DIGIT_COUNT"))
            Dim I As Double = fNumisNULL(rd("NEXT_ID"))

            rd.Close()
            Dim get_digit As String = ""
            For r As Integer = 1 To D
                get_digit = get_digit & "0"
            Next
            sValue = L & I.ToString(get_digit)
            If sValue = THIS_CODE Then
                fExecutedOnly($"UPDATE item_type_map SET NEXT_ID='{I + 1}' WHERE ID = '{TYPE}' limit 1")
            End If
        End If
        rd.Close()

    End Sub

    Public Function fNEXT_CODE(ByVal prTableName As String, ByVal prLocation_ID As Integer) As String
        Dim sValue As String = ""


        If gsIncRefNoByLocation = True Then
            'check if have it
            Try


                Dim rd As OdbcDataReader = fReader($"SELECT l.CODE,lr.SYMBOL_CODE,lr.NEXT_CODE,lr.DIGIT_CODE FROM location_reference as lr INNER JOIN location as l ON lr.LOCATION_ID = l.`ID` WHERE lr.LOCATION_ID = '{prLocation_ID}' and lr.TABLE_NAME = '{prTableName}' limit 1")
                If rd.Read Then
                    Dim L As String = fTextisNULL(rd("CODE"))
                    Dim S As String = fTextisNULL(rd("SYMBOL_CODE"))
                    Dim D As Integer = fNumisNULL(rd("DIGIT_CODE"))
                    Dim I As Double = fNumisNULL(rd("NEXT_CODE"))

                    rd.Close()
                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit = get_digit & "0"
                    Next
                    ' return value = LOC_CODE + SYMBOL_CODE + (VALUE + DIGIT)
                    sValue = L & S & I.ToString(get_digit)
                    fExecutedOnly($"UPDATE location_reference SET NEXT_CODE='{I + 1}' WHERE LOCATION_ID = '{prLocation_ID}' and TABLE_NAME = '{prTableName}' limit 1")

                Else
                    rd.Close()
                    fExecutedOnly($"INSERT INTO location_reference SET SYMBOL_CODE='{fGetFieldValue("object_type_map", "table_name", prTableName, "SYMBOL_CODE") }',LOCATION_ID='{prLocation_ID}',TABLE_NAME='{prTableName.ToUpper}',NEXT_CODE='1',DIGIT_CODE='5' ")

                    sValue = fNEXT_CODE(prTableName, prLocation_ID)
                End If
            Catch ex As Exception
                If fMessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fNEXT_CODE(prTableName, prLocation_ID)
                Else
                    End
                End If
            End Try
        Else


            Try
                Dim rd As OdbcDataReader = fReader("select SYMBOL_CODE,NEXT_CODE,DIGIT_CODE,USE_YEAR from object_type_map where table_name = '" & prTableName & "' limit 1")
                If rd.Read Then
                    Dim Y As Boolean = fNumisNULL(rd("USE_YEAR"))
                    Dim S As String = fTextisNULL(rd("SYMBOL_CODE"))
                    Dim D As Integer = fNumisNULL(rd("DIGIT_CODE"))
                    Dim I As Double = fNumisNULL(rd("NEXT_CODE"))

                    rd.Close()
                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit = get_digit & "0"
                    Next
                    ' return value = SYMBOL + YEAR + (VALUE + DIGIT)
                    sValue = S & IIf(Y = True, Date.Now.Year, "") & I.ToString(get_digit)

                    Dim NEXT_CODE As Integer = I + 1
                    fExecutedOnly("UPDATE object_type_map set NEXT_CODE ='" & NEXT_CODE & "' where table_name = '" & prTableName & "' limit 1 ")
                End If

            Catch ex As Exception
                If fMessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = fNEXT_CODE(prTableName, prLocation_ID)
                Else
                    End
                End If
            End Try

        End If

        Return sValue
    End Function

End Module
