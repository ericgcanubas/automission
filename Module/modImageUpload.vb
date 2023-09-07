Module modImageUpload

    Public Function fUploadAttachment(ByVal Path As String) As Boolean


        If Path = "" Then
            Return False
            Exit Function
        End If

        If My.Computer.FileSystem.FileExists(Path) = True Then

            Dim FileName As String = My.Computer.FileSystem.GetName(Path)

            If gsUseImageProduct = True Then
                Dim SourceFile As String = gsImageSourceFolder
                If SourceFile = "" Then
                    MessageBoxWarning("Option-> Destination Attachment not set.")
                    Return False
                    Exit Function
                End If

                If My.Computer.FileSystem.FileExists(SourceFile & "\" & FileName) = True Then
                    If MessageBoxWarningYesNo("File is already exists do you want to overwrite?") = False Then
                        MessageBoxInfo("File Upload Canceled.")
                        Return False
                        Exit Function
                    End If
                End If

                Try
                    My.Computer.FileSystem.CopyFile(Path, SourceFile & "\" & FileName, True)

                    Return True
                Catch ex As Exception
                    Return False
                    MessageBoxWarning(ex.Message)
                End Try

            Else
                MessageBoxWarning("Option-> Inactive Attachment.")
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Sub fDisplayPhoto(ByVal FileName As String, ByVal picID As PictureBox)
        If gsUseImageProduct = False Then Exit Sub

        Try


            If FileName.Trim = "" Then
                picID.Image = Nothing
                Exit Sub
            End If

            Dim TransferPath As String = gsImageDestinationFolder
            Dim StoragePath As String = gsImageSourceFolder

            If My.Computer.FileSystem.FileExists(StoragePath & "\" & FileName) = False Then
                MessageBoxInfo("attachment not found.")
                Exit Sub
            End If

            If My.Computer.FileSystem.FileExists(TransferPath & "\" & FileName) = False Then

                My.Computer.FileSystem.CopyFile(StoragePath & "\" & FileName, TransferPath & "\" & FileName, True)
                Dim thisPath As String = TransferPath & "\" & FileName
                picID.Image = Image.FromFile(thisPath)
            Else

                Dim thisPath As String = TransferPath & "\" & FileName
                picID.Image = Image.FromFile(thisPath)

            End If
        Catch ex As Exception
            MessageBoxExclamation(ex.Message)
        End Try
    End Sub
End Module
