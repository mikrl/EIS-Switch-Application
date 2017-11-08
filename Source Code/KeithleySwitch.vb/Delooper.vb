Imports System.Text.RegularExpressions

Public Class Delooper

    Private lstLoopPositions As New List(Of List(Of Tuple(Of Integer, Integer)))
    Private strDataStart As String = "freq/Hz Re(Z)/Ohm -Im(Z)/Ohm |Z|/Ohm Phase(Z)/deg time/s <Ewe>/V <I>/mA Cs/F Cp/F cycle number I Range |Ewe|/V |I|/A P/W Re(Y)/Ohm-1 Im(Y)/Ohm-1 |Y|/Ohm-1 Phase(Y)/deg"

    Private Sub btnAddFiles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddFiles.Click
        ofdSelectFiles.Title = "Select file(s)"
        ofdSelectFiles.ShowDialog()
    End Sub

    Private Sub ofdSelectFiles_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdSelectFiles.FileOk
        For Each strFilename In ofdSelectFiles.FileNames()
            Dim boolLoopIdxFound = False
            Dim intNumLoops As Integer
            Dim lst_strFileText As List(Of String) = My.Computer.FileSystem.ReadAllText(strFilename).Split(New String() {Environment.NewLine}, StringSplitOptions.None).ToList()
            Dim lstThisJob = New List(Of Tuple(Of Integer, Integer))
            For int_i As Integer = 0 To lst_strFileText.Count() - 1
                If Not boolLoopIdxFound AndAlso Regex.Match(lst_strFileText(int_i), ("(^Number of loops).*")).Success Then
                    intNumLoops = lst_strFileText(int_i).Substring(18)
                    boolLoopIdxFound = True
                    Continue For
                End If

                If boolLoopIdxFound Then
                    If Not Regex.Match(lst_strFileText(int_i), "(Loop [0-9]* from point number [0-9]* to [0-9]*)").Success Then Exit For
                    Dim intLoopStart As Integer = CInt(Regex.Matches(lst_strFileText(int_i), "[0-9]+").Item(1).ToString())
                    Dim intLoopEnd As Integer = CInt(Regex.Matches(lst_strFileText(int_i), "[0-9]+").Item(2).ToString())
                    Dim tpLoopIndices As Tuple(Of Integer, Integer) = Tuple.Create(intLoopStart, intLoopEnd)
                    lstThisJob.Add(tpLoopIndices)
                End If
            Next
            lstLoopPositions.Add(lstThisJob)
            lvwFilesToDeloop.Items.Add(New ListViewItem({strFilename, intNumLoops}))
        Next
    End Sub

    Private Sub btnDeloop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeloop.Click
        For int_idx As Integer = 0 To lvwFilesToDeloop.Items.Count - 1
            Dim strFileName As String = lvwFilesToDeloop.Items(int_idx).Text
            Dim lst_strFileText As List(Of String) = My.Computer.FileSystem.ReadAllText(strFileName).Split(New String() {Environment.NewLine}, StringSplitOptions.None).ToList()
            Dim intDataStart As Integer = lst_strFileText.LastIndexOf("") + 1
            Dim lst_AllUnloopedFiles As New List(Of List(Of String))

            For Each tupLoop In lstLoopPositions(int_idx)
                Dim lst_UnloopedFile As New List(Of String)
                lst_UnloopedFile.Add(lst_strFileText(intDataStart))
                lst_UnloopedFile.AddRange(lst_strFileText.GetRange(intDataStart + tupLoop.Item1 + 1, (tupLoop.Item2 - tupLoop.Item1) + 1))
                lst_AllUnloopedFiles.Add(lst_UnloopedFile)
            Next

            Dim int_loopIdx As Integer = 1
            For Each lst_fileTxt In lst_AllUnloopedFiles
                Dim str_fileTxt As String = Join(lst_fileTxt.ToArray, Environment.NewLine)
                'Console.WriteLine(str_fileTxt)
                'Console.Read()
                Dim test = strFileName.Substring(0, Len(strFileName) - 4) & "_loop" & CStr(int_loopIdx) & ".mpt"
                My.Computer.FileSystem.WriteAllText(strFileName.Substring(0, Len(strFileName) - 4) & "_loop" & CStr(int_loopIdx) & ".mpt", str_fileTxt, False)
                int_loopIdx += 1
            Next
        Next

        lvwFilesToDeloop.Items.Clear()
        lstLoopPositions.Clear()
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        For Each item As ListViewItem In lvwFilesToDeloop.SelectedItems
            item.Remove()
        Next
    End Sub
End Class