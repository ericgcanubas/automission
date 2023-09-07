
Imports System.Data.Odbc

Module modDatabase
    Public gsErrorMessage As String = $" { vbNewLine } { vbNewLine } Yes = Continue. { vbNewLine } No = Exit Program."
    Public Function IsTransactionSuccess(ByVal prID As String, ByVal prTable As String) As Boolean
        Dim ReturnValue As Boolean = False
        Try
            Dim rd As OdbcDataReader = SqlReader("Select ID FROM " & prTable & " Where ID ='" & prID & "' Limit 1")
            If rd.Read Then
                ReturnValue = True
            End If
            rd.Close()
        Catch ex As Exception

        End Try
        Return ReturnValue
    End Function

    Public Function CheckingCodeReference(ByVal prCODE As String, ByVal prTable As String) As String
        Dim bAlreadyUSed As Boolean = False
        Try
            Dim rd As OdbcDataReader = SqlReader("select ID from " & prTable & " where `CODE` = '" & prCODE & "' Limit 1")
            If rd.Read Then
                bAlreadyUSed = True
            End If
            rd.Close()
        Catch ex As Exception
        End Try

        If bAlreadyUSed = True Then
            Dim I As Double = Val(prCODE) + 1
            Dim zCODE As String = I.ToString("0000")
            Return CheckingCodeReference(zCODE, prTable)
        Else
            Return prCODE
        End If

    End Function
    Public Function GetSummary(ByVal sql As String) As Double ' One Field Only
        Dim n As Double
        Try
            Dim rd As OdbcDataReader = SqlReader(sql)
            If rd.Read Then
                n = NumIsNull(rd(0))
            End If
            rd.Close()
        Catch ex As Exception

            n = GetSummary(sql)
        End Try
        Return n

    End Function
    Public Function GotNullText(ByVal v As String) As String
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
    Public Function GotNullNumber(ByVal v As Double) As String
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

    Public Sub NullOTherField(ByVal Field As String, ByVal sTable As String, ByRef ReturnField As String, ByRef ReturnValue As String)

        Dim Field_ As String = ""
        Dim Value_ As String = ""

        Try

            Dim rd As OdbcDataReader = SqlReader("DESCRIBE " & sTable)
            While rd.Read()
                If Field.Contains(rd("Field")) = False Then
                    If (Field_ = "") Then
                        Field_ &= Field_ & rd("Field")
                        Value_ &= Value_ & " NULL "
                    Else
                        Field_ = Field_ & "," & rd("Field")
                        Value_ &= Value_ & ", NULL "
                    End If
                End If
            End While
            rd.Close()

            ReturnField = Field_
            ReturnValue = Value_

        Catch ex As Exception
            NullOTherField(Field, sTable, ReturnField, ReturnValue)

        End Try

    End Sub


    Public Sub SqlExecutedUsingReading(ByVal c As Control, ByVal sQuery As String)

        Try
            Using rd As OdbcDataReader = SqlReader(sQuery)
                DisplayFields(c, rd)
            End Using

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message) = True Then
                SqlExecutedUsingReading(c, sQuery)
            Else
                End
            End If
        End Try

    End Sub


    Public Function DataReader(ByVal sQuery As String) As OdbcDataReader
        Try
            Dim cmd As New OdbcCommand(sQuery, cnn) With {
                .CommandTimeout = 999999
            }
            Return cmd.ExecuteReader
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                Return DataReader(sQuery)
            Else
                Gmail_ScreenShoot($"System ScreenShoot", $"{gsGmailAddressTo}@gmail.com", ex.Message)
                End
            End If

        End Try
    End Function
    Public Function SqlReader(ByVal sQuery) As OdbcDataReader

        Return DataReader(sQuery) 'dt.CreateDataReader
    End Function
    Public Function ReaderCounting(ByVal sQuery As String, ByRef RowCount As Integer) As OdbcDataReader
        Dim dt As New DataTable
        Dim rd As OdbcDataReader = DataReader(sQuery)
        dt.Load(rd)
        RowCount = dt.Rows.Count
        Return rd
    End Function
    Public Sub ExportQuery(ByVal SQL As String)

        If gsDataForwarderIsActive = False Or gsDataForwarderPath = "" Then
            Exit Sub
        End If

        Dim dt = Date.Parse(DateTime.Now()) ' presumes that this is the correct format

        Dim ticks As Long = dt.Ticks

        Dim file_name As String = ticks

        Dim NumRange As Integer = 0

        Dim fPath As String = ForwardedCheckingName(file_name, NumRange)


        If NumRange > 8 Then
            fSleep(1000)
        End If

        ForwardedFilesSave(fPath, SQL)

    End Sub
    Private Function ForwardedCheckingName(ByVal file_name As String, ByRef I As Integer) As String
        Dim DirectoryPath As String = gsDataForwarderPath & "\pending"
        Try

            Dim FileIO As New IO.DirectoryInfo(DirectoryPath)
            If FileIO.Exists = False Then
                FileIO.Create()
            End If
        Catch ex As Exception

        End Try

        Dim StrPath As String = $"{DirectoryPath}\{file_name}_{I}.txt"

        If IO.File.Exists(StrPath) = True Then
            I += 1
            StrPath = ForwardedCheckingName(file_name, I)
        End If

        Return StrPath
    End Function
    Private Sub ForwardedFilesSave(ByVal fpath As String, ByVal SQL As String)

        Dim afile As New IO.StreamWriter(fpath, True)
        afile.WriteLine(SQL)
        afile.Close()

    End Sub
    Public Sub SqlExecuted(ByVal sQuery As String)
        If sQuery = "" Then Exit Sub

        Try
            CursorLoadingOn(True)
            Dim cmd As New OdbcCommand(sQuery, cnn) With {
                .CommandTimeout = 999999
            }
            cmd.ExecuteNonQuery()
            CursorLoadingOn(False)
            ExportQuery(sQuery)
        Catch ex As Exception



            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then

                SqlExecuted(sQuery)
            Else
                Gmail_ScreenShoot($"BMS ScreenShoot", $"{gsGmailAddressTo}@gmail.com", ex.Message)
                End
            End If

        End Try

    End Sub
    Public Function GetStringFieldValue(ByVal xTable As String, ByVal xCondition As String, ByVal xValue As String, ByVal xGet_Value As String) As String


        Dim zValue As String = ""
        Try
            Dim rd As OdbcDataReader = SqlReader("select " & xGet_Value & " from " & xTable & " where " & xCondition & " = '" & xValue & "' limit 1")
            If rd.Read Then
                zValue = TextIsNull(rd(xGet_Value))
            End If
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetStringFieldValue(xTable, xCondition, xValue, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function

    Public Function GetDateFieldValue(ByVal xTable As String, ByVal xCondition As String, ByVal xValue As String, ByVal xGet_Value As String) As Date


        Dim zValue As Date = Nothing
        Try
            Dim rd As OdbcDataReader = SqlReader("select " & xGet_Value & " from " & xTable & " where " & xCondition & " = '" & xValue & "' limit 1")
            If rd.Read Then
                zValue = CDate(rd(xGet_Value))
            End If
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetDateFieldValue(xTable, xCondition, xValue, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function GetStringFieldValueByTwoCondtion(ByVal xTable As String, ByVal xCondition1 As String, ByVal xValue1 As String, ByVal xCondition2 As String, ByVal xValue2 As String, ByVal xGet_Value As String) As String
        Dim zValue As String = ""
        Try
            Dim rd As OdbcDataReader = SqlReader("select " & xGet_Value & " from " & xTable & " where " & xCondition1 & " = '" & xValue1 & "' and " & xCondition2 & " = '" & xValue2 & "' limit 1")
            If rd.Read Then
                zValue = TextIsNull(rd(xGet_Value))
            End If
            rd.Close()

        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetStringFieldValueByTwoCondtion(xTable, xCondition1, xValue1, xCondition2, xValue2, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function GetNumberFieldValue(ByVal xTable As String, ByVal xCondition As String, ByVal xValue As String, ByVal xGet_Value As String) As Double
        Dim zValue As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("select " & xGet_Value & " from " & xTable & " where " & xCondition & " = '" & xValue & "' limit 1")
            If rd.Read Then
                zValue = NumIsNull(rd(xGet_Value))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetNumberFieldValue(xTable, xCondition, xValue, xGet_Value)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function GetStringFieldValueOneReturn(ByVal sQuery As String) As String
        Dim zValue As String = ""
        Try
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                zValue = TextIsNull(rd(0))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetStringFieldValueOneReturn(sQuery)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function GetNumberFieldValueOneReturn(ByVal sQuery As String) As Double
        Dim zValue As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader(sQuery)
            If rd.Read Then
                zValue = NumIsNull(rd(0))
            End If
            rd.Close()
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetNumberFieldValueOneReturn(sQuery)
            Else
                End
            End If
        End Try
        Return zValue
    End Function
    Public Function GetNumberFieldValueByTwoCondition(ByVal xTable As String, ByVal xCondition1 As String, ByVal xValue1 As String, ByVal xCondition2 As String, ByVal xValue2 As String, ByVal xGet_Value As String) As Double


        Dim zValue As Double = 0
        Try

            Dim rd As OdbcDataReader = SqlReader("select " & xGet_Value & " from " & xTable & " where " & xCondition1 & " = '" & xValue1 & "' and " & xCondition2 & " = '" & xValue2 & "'  limit 1")
            If rd.Read Then
                zValue = NumIsNull(rd(xGet_Value))
            End If
            rd.Close()
            Return zValue
        Catch ex As Exception
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                zValue = GetNumberFieldValueByTwoCondition(xTable, xCondition1, xValue1, xCondition2, xValue2, xGet_Value)
            Else
                End
            End If

        End Try
        Return zValue
    End Function
    Public Sub LoadDataGridView(ByVal dgv As DataGridView, ByVal xSQL As String)
        ViewStyleColor(dgv)
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
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                LoadDataGridView(dgv, xSQL)
            Else
                End
            End If
        Finally

        End Try



    End Sub
    Public Sub LoadDataGridViewStandard(ByVal dgv As DataGridView, ByVal xSQL As String)
        ViewStyleColor(dgv)
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
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                LoadDataGridViewStandard(dgv, xSQL)
            Else
                End
            End If

        Finally

        End Try



    End Sub
    Public Sub ViewPrimarySetup(ByVal dgv As DataGridView)
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
    Public Sub LoadDataGridViewBinding(ByVal dgv As DataGridView, ByVal xSQL As String, ByRef Ref_bSource As BindingSource)
        ViewPrimarySetup(dgv)
        ViewStyleColor(dgv)

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
            If MessageBoxErrorYesNo(ex.Message & gsErrorMessage) = True Then
                LoadDataGridViewBinding(dgv, xSQL, Ref_bSource)
            Else
                End
            End If
        End Try


    End Sub
    Public Sub TSComboBoxLoad(ByVal cmb As ToolStripComboBox, ByVal sqlQuery As String, ByVal xValue As String, ByVal xDisplay As String)
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
            TSComboBoxLoad(cmb, sqlQuery, xValue, xDisplay)
        End Try

    End Sub
    Public Function CommandObject(ByVal StrSql As String) As OdbcCommand
        Dim cmd As New OdbcCommand(StrSql, cnn)
        Return cmd
    End Function
    Public Sub CommandObjectComboBoxLoad(ByVal cmd As OdbcCommand, ByVal cmb As ComboBox, ByVal xValue As String, ByVal xDisplay As String)
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

                AddHandler cmb.MouseClick, AddressOf AutoDropDownComboBox
                AddHandler cmb.PreviewKeyDown, AddressOf EnterToTabDropDown
            End If
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try

    End Sub
    Public Sub ComboBoxLoad(ByVal cmb As ComboBox, ByVal sqlQuery As String, ByVal xValue As String, ByVal xDisplay As String)
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

                AddHandler cmb.MouseClick, AddressOf AutoDropDownComboBox
                ' AddHandler cmb.PreviewKeyDown, AddressOf EnterToTabDropDown
            End If


        Catch ex As Exception
            MessageBoxErrorYesNo(ex.Message)
        End Try

    End Sub

    Private Sub AutoDropDownComboBox(ByVal sender As Object, ByVal e As MouseEventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        cmb.DroppedDown = True
    End Sub
    Private Sub EnterToTabDropDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
        Dim cmb As ComboBox = DirectCast(sender, ComboBox)
        Dim getForm As Form = cmb.FindForm
        If e.KeyCode = Keys.Enter Then
            getForm.SelectNextControl(cmb, True, True, True, True)
            'SendKeys.Send("{TAB}"
        Else
            If cmb.CausesValidation = True Then
                If cmb.Items.Count <> 0 Then
                    cmb.DroppedDown = True
                End If

            End If

        End If

    End Sub
    Private Sub EnterToTabDropDownUP(ByVal sender As Object, ByVal e As KeyEventArgs)

        Dim cmb As ComboBox = DirectCast(sender, ComboBox)

        If e.KeyCode = Keys.Enter Then

            SendKeys.Send("{TAB}")
            e.Handled = True

        End If


    End Sub
    Public Function TextApostrophe(ByVal Str As String) As String
        Return Str.Replace("'", "`")
    End Function
    Public Function DateIsNull(ByVal EX As Object) As String
        Try
            If IsDBNull(EX) = True Then
                Return ""
            Else
                Return CDate(DateFormatMySql(EX))
            End If
        Catch ex1 As Exception
            Return ""
        End Try

    End Function
    Public Function TextIsNull(ByVal EX As Object) As String
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
    Public Function NumIsNull(ByVal ex As Object) As Double
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

    Public Function GetMaxField(ByVal prField As String, ByVal prTable As String) As Double
        Dim i As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader($"Select  MAX(CAST({prField} AS UNSIGNED)) As T From `{prTable}`")
            If rd.Read Then
                i = NumIsNull(rd("T")) + 1
            Else
                i = 1
            End If
            rd.Close()
        Catch ex As Exception
            i = GetMaxField(prField, prTable)
        End Try
        Return i
    End Function
    Public Function GetMaxFieldLine(ByVal prField As String, ByVal prTable As String, ByVal prCondition As String, ByVal prValue As String) As String
        Dim i As Double = 0
        Try
            Dim rd As OdbcDataReader = SqlReader("Select  MAX(CAST(" & prField & " AS UNSIGNED)) As T From " & prTable & " Where " & prCondition & "='" & prValue & "'")
            If rd.Read Then
                i = NumIsNull(rd("T"))
            End If
            rd.Close()
        Catch ex As Exception
            i = GetMaxFieldLine(prField, prTable, prCondition, prValue)
        End Try
        Return i + 1

    End Function
    Public Sub CursorLoadingOn(ByVal bActive As Boolean)

        If bActive = True Then
            Cursor.Current = Cursors.WaitCursor
            '  fDoEvents()
        Else
            Cursor.Current = Cursors.Default
        End If

    End Sub
    Public Function NextCodePreview(ByVal prTableName As String, ByVal prLocation_ID As Integer) As String
        Dim sValue As String = ""
        If gsIncRefNoByLocation = True Then
            'check if have it
            Try


                Dim rd As OdbcDataReader = SqlReader($"SELECT l.CODE,lr.SYMBOL_CODE,lr.NEXT_CODE,lr.DIGIT_CODE FROM location_reference as lr INNER JOIN location as l ON lr.LOCATION_ID = l.`ID` WHERE lr.LOCATION_ID = '{prLocation_ID}' and lr.TABLE_NAME = '{prTableName}' limit 1")
                If rd.Read Then
                    Dim L As String = TextIsNull(rd("CODE"))
                    Dim S As String = TextIsNull(rd("SYMBOL_CODE"))
                    Dim D As Integer = NumIsNull(rd("DIGIT_CODE"))
                    Dim I As Double = NumIsNull(rd("NEXT_CODE"))

                    rd.Close()
                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit &= "0"
                    Next

                    sValue = L & S & I.ToString(get_digit)

                Else
                    rd.Close()

                    Dim rd1 As OdbcDataReader = SqlReader("select SYMBOL_CODE from object_type_map where table_name = '" & prTableName & "' limit 1")
                    If rd1.Read Then
                        Dim L As String = TextIsNull(GetStringFieldValue("location", "id", prLocation_ID, "CODE"))
                        Dim S As String = TextIsNull(rd1("SYMBOL_CODE"))
                        Dim D As Integer = 5
                        Dim I As Double = 1

                        Dim get_digit As String = ""
                        For r As Integer = 1 To D
                            get_digit &= "0"
                        Next
                        sValue = L & S & I.ToString(get_digit)
                    End If
                    rd1.Close()


                End If
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = NextCodePreview(prTableName, prLocation_ID)
                Else
                    End
                End If

            End Try
        Else


            Try
                Dim rd As OdbcDataReader = SqlReader("select SYMBOL_CODE,NEXT_CODE,DIGIT_CODE,USE_YEAR from object_type_map where table_name = '" & prTableName & "' limit 1")
                If rd.Read Then
                    Dim Y As Boolean = NumIsNull(rd("USE_YEAR"))
                    Dim S As String = TextIsNull(rd("SYMBOL_CODE"))
                    Dim D As Integer = NumIsNull(rd("DIGIT_CODE"))
                    Dim I As Double = NumIsNull(rd("NEXT_CODE"))

                    rd.Close()
                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit &= "0"
                    Next

                    sValue = S & IIf(Y = True, Date.Now.Year, "") & I.ToString(get_digit)
                    Dim NEXT_CODE As Integer = I + 1

                End If

            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    sValue = NextCodePreview(prTableName, prLocation_ID)
                Else
                    End
                End If
            End Try

        End If

        Return sValue
    End Function

    Public Function GetNextItemCode(ByVal TYPE As Integer) As String
        Dim sValue As String = ""
        Dim rd As OdbcDataReader = SqlReader($"select * FROM ITEM_TYPE_MAP where ID = '{TYPE}' LIMIT 1;")
        If rd.Read Then
            Dim L As String = TextIsNull(rd("FIRST_CHARACTER"))
            Dim D As Integer = NumIsNull(rd("DIGIT_COUNT"))
            Dim I As Double = NumIsNull(rd("NEXT_ID"))

            rd.Close()
            Dim get_digit As String = ""
            For r As Integer = 1 To D
                get_digit &= "0"
            Next
            sValue = L & I.ToString(get_digit)
        End If
        rd.Close()
        Return sValue
    End Function

    Public Sub SetNextItemCode(ByVal TYPE As Integer, ByVal THIS_CODE As String)

        Dim rd As OdbcDataReader = SqlReader($"select * FROM ITEM_TYPE_MAP Where ID = '{TYPE}' LIMIT 1;")
        If rd.Read Then

            Dim L As String = TextIsNull(rd("FIRST_CHARACTER"))
            Dim D As Integer = NumIsNull(rd("DIGIT_COUNT"))
            Dim I As Double = NumIsNull(rd("NEXT_ID"))

            Dim GetDigit As String = ""
            For r As Integer = 1 To D
                GetDigit &= "0"
            Next
            Dim ReturnValue As String = L & I.ToString(GetDigit)
            If ReturnValue = THIS_CODE Then
                SqlExecuted($"UPDATE item_type_map SET NEXT_ID='{I + 1}' WHERE ID = '{TYPE}'")
            End If
        End If
        rd.Close()

    End Sub

    Public Function GetNextCode(ByVal prTableName As String, ByVal prLocation_ID As Integer) As String
        Dim ReturnValue As String = ""
        If gsIncRefNoByLocation = True Then
            Try


                Dim rd As OdbcDataReader = SqlReader($"SELECT l.CODE,lr.SYMBOL_CODE,lr.NEXT_CODE,lr.DIGIT_CODE FROM location_reference as lr INNER JOIN location as l ON lr.LOCATION_ID = l.`ID` WHERE lr.LOCATION_ID = '{prLocation_ID}' and lr.TABLE_NAME = '{prTableName}' limit 1")
                If rd.Read Then
                    Dim L As String = TextIsNull(rd("CODE"))
                    Dim S As String = TextIsNull(rd("SYMBOL_CODE"))
                    Dim D As Integer = NumIsNull(rd("DIGIT_CODE"))
                    Dim I As Double = NumIsNull(rd("NEXT_CODE"))
                    Dim GetDigit As String = ""
                    For r As Integer = 1 To D
                        GetDigit &= "0"
                    Next

                    ReturnValue = L & S & I.ToString(GetDigit)
                    SqlExecuted($"UPDATE location_reference SET NEXT_CODE='{I + 1}' WHERE LOCATION_ID = '{prLocation_ID}' and TABLE_NAME = '{prTableName}' limit 1")

                Else

                    SqlExecuted($"INSERT INTO location_reference SET SYMBOL_CODE='{GetStringFieldValue("object_type_map", "table_name", prTableName, "SYMBOL_CODE") }',LOCATION_ID='{prLocation_ID}',TABLE_NAME='{prTableName.ToUpper}',NEXT_CODE='1',DIGIT_CODE='5' ")
                    ReturnValue = GetNextCode(prTableName, prLocation_ID)
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    ReturnValue = GetNextCode(prTableName, prLocation_ID)
                Else
                    End
                End If
            End Try
        Else


            Try
                Dim rd As OdbcDataReader = SqlReader("select SYMBOL_CODE,NEXT_CODE,DIGIT_CODE,USE_YEAR from object_type_map where table_name = '" & prTableName & "' limit 1")
                If rd.Read Then
                    Dim Y As Boolean = NumIsNull(rd("USE_YEAR"))
                    Dim S As String = TextIsNull(rd("SYMBOL_CODE"))
                    Dim D As Integer = NumIsNull(rd("DIGIT_CODE"))
                    Dim I As Double = NumIsNull(rd("NEXT_CODE"))


                    Dim get_digit As String = ""
                    For r As Integer = 1 To D
                        get_digit &= "0"
                    Next

                    ReturnValue = S & IIf(Y = True, Date.Now.Year, "") & I.ToString(get_digit)

                    Dim NEXT_CODE As Integer = I + 1
                    SqlExecuted("UPDATE object_type_map set NEXT_CODE ='" & NEXT_CODE & "' where table_name = '" & prTableName & "'")
                End If
                rd.Close()
            Catch ex As Exception
                If MessageBoxErrorYesNo(ex.Message) = True Then
                    ReturnValue = GetNextCode(prTableName, prLocation_ID)
                Else
                    End
                End If
            End Try

        End If

        Return ReturnValue
    End Function

End Module
