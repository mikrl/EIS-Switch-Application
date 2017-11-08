Imports System.Text.RegularExpressions

Public Class AddJob
    Private dec_HiFreq As Decimal
    Private dec_LoFreq As Decimal
    Private dec_waitForPeriod As Decimal
    Private int_DataPointsPerDecade As Integer
    Private ts_timeToCompletion As TimeSpan
    Private int_NumChannels As Integer = 16
    Private lst_Panels As List(Of Panel) '(int_NumChannels)
    Private lst_Channels As List(Of Integer)
    Private bool_isLoaded As Boolean = False
    Private bool_customLogFile As Boolean = False
    'Private arr_Channels As New Integer(int_NumChannels)
    Private str_logFilePath As String
    Private str_defaultLogFilePath As String
    Private lst_SelectedChans As List(Of Integer)
    Private lst_Emails As List(Of Tuple(Of Boolean, String))
    Private int_boxLength As Integer = 100

    Public Sub setDefaultLogFilePath(ByVal str_filePath As String)
        str_defaultLogFilePath = str_filePath
    End Sub

    Public Function isCustomLogPath() As Boolean
        Return bool_customLogFile
    End Function

    Public Function getDefaultLogFilePath() As String
        Return str_defaultLogFilePath
    End Function

    Public Function getCustomLogFilePath() As String
        Return str_logFilePath
    End Function

    Public Sub setChannelText(ByVal intChanIdx, ByVal strPanelText)
        lst_Panels(intChanIdx).Controls(2).Text = strPanelText
    End Sub

    Public Function isLoaded() As Boolean
        Return bool_isLoaded
    End Function

    Public Sub setChannels(ByVal lstChans As List(Of Integer))
        If lst_Channels Is Nothing Then
            lst_Channels = New List(Of Integer)
            For int_i = 0 To int_NumChannels - 1 Step 1
                lst_Channels.Add(0)
            Next
        End If
        For intIdx As Integer = 0 To lstChans.Count - 1
            Dim bool_QueuedUp = False
            If lst_Channels(intIdx) <> 1 Then
                If lvw_JobList.Items.Count > 0 Then
                    For intJobIdx As Integer = 0 To lvw_JobList.Items.Count - 1
                        If Array.ConvertAll(lvw_JobList.Items(intJobIdx).SubItems(1).Text.Split(","), AddressOf Convert.ToInt32).Contains(intIdx + 1) Then
                            bool_QueuedUp = True
                            Exit For
                        End If
                    Next
                End If
                If bool_QueuedUp Then Continue For

                lst_Channels(intIdx) = lstChans(intIdx)
            End If
        Next

    End Sub

    Private Sub AddJob_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        bool_isLoaded = False
        tmrUpdatePanel.Dispose()
    End Sub

    Private Sub FrontPanel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        bool_customLogFile = False
        lst_Emails = New List(Of Tuple(Of Boolean, String))
        For int_chanIdx = 0 To lst_Channels.Count - 1 Step 1
            If lst_Channels(int_chanIdx) = 1 Then
                lst_Channels(int_chanIdx) = 0
            End If
        Next
        lvw_JobList.Items.Clear()
        lst_Emails.Clear()
        txt_Name.Text = ""
        txtLogfile.Text = str_defaultLogFilePath
        txtChannelsSelected.Text = ""
        loadChannels()

        'lblStep3.Location = New Point(480, 178)
        'gbxAddScan.Location = New Point(486, 206)

    End Sub



    Public Function getAddedChannels() As List(Of Integer)
        Return lst_Channels
    End Function

    Public Function getJobTime() As TimeSpan
        Return ts_timeToCompletion
    End Function

    Public Function getEmails() As List(Of Tuple(Of Boolean, String))
        Return lst_Emails
    End Function

    Private Sub loadChannels()
        lst_Panels = New List(Of Panel)
        Dim int_Counter As Integer = 1
        For y As Integer = 1 To System.Math.Ceiling(System.Math.Sqrt(int_NumChannels))
            For x As Integer = 1 To System.Math.Ceiling(System.Math.Sqrt(int_NumChannels))
                Dim pt_location As New Point(20 + (x - 1) * (int_boxLength + 10), 20 + (y - 1) * (int_boxLength + 10))
                Dim lbl_ChanLabel As New Label
                Dim lbl_Availability As New Label
                Dim lbl_TimeLeft As New Label
                Dim pnl_NewPanel As New Panel

                With pnl_NewPanel
                    .Name = "pnl_channel" & CStr(int_Counter)
                    .Size = New Point(int_boxLength, int_boxLength)
                    .Location = pt_location
                    .BorderStyle = BorderStyle.Fixed3D


                End With

                If int_Counter <= int_NumChannels Then

                    With lbl_ChanLabel
                        .Text = CStr(int_Counter)
                        .Location = New Point(0, 0)
                        .Enabled = False
                        '.ForeColor = Color.Gold

                    End With

                    AddHandler pnl_NewPanel.Click, AddressOf pnl_NewPanel_Click

                    With lbl_Availability
                        .Text = "Available"
                        .Location = New Point(20, 40)
                        .Enabled = False
                    End With

                    With lbl_TimeLeft
                        .Text = ""
                        .Location = New Point(20, 60)
                        .Enabled = False
                    End With


                    'MessageBox.Show("x: " & x & " y: " & y & " counter: " & int_Counter)
                    lst_Panels.Add(pnl_NewPanel)
                Else
                    With lbl_ChanLabel
                        .Text = "Not in use"
                        .Location = New Point(20, 40)
                    End With

                End If

                gbx_Channels.Controls.Add(pnl_NewPanel)
                pnl_NewPanel.Controls.Add(lbl_ChanLabel)
                pnl_NewPanel.Controls.Add(lbl_Availability)
                pnl_NewPanel.Controls.Add(lbl_TimeLeft)
                int_Counter += 1
                gbx_Channels.Size = New Point(pt_location.X + int_boxLength + 10, pt_location.Y + int_boxLength + 10)
                gbx_info.Size = New Point(gbx_Channels.Size.Width, 150)
                gbx_info.Location = New Point(gbx_Channels.Location.X, gbx_Channels.Location.Y + gbx_Channels.Size.Height)
                'Me.Size = New Point(gbx_info.Location.X + gbx_info.Size.Width + 20, gbx_info.Location.Y + gbx_info.Size.Height + 40)
                'Me.Size = New Point(gbx_Channels.Size.Width + 20, gbx_Channels.Size.Height + 250)
            Next
        Next
        For int_i = 0 To int_NumChannels - 1 Step 1
            lst_Channels.Add(0)
        Next
        bool_isLoaded = True
        'gbx_Channels.Size = pt_location
    End Sub

    Public Sub setChannelsStatus()
        For i As Integer = 0 To int_NumChannels - 1 Step 1
            Select Case lst_Channels(i)

                Case 0
                    DeactivateChannel(lst_Panels(i))

                Case 1
                    ActivateChannel(lst_Panels(i))

                Case 2
                    UpcomingChannel(lst_Panels(i))

                Case 3
                    CurrentChannel(lst_Panels(i))

                Case Else
                    MessageBox.Show("This should not appear.")

            End Select
        Next
    End Sub

    Private Function roundTimeSpan(ByVal ts As TimeSpan) As TimeSpan
        Dim tsRounded As TimeSpan
        If ts.Seconds < 500 Then
            tsRounded = New TimeSpan(ts.Hours, ts.Minutes, ts.Seconds)
        Else
            tsRounded = New TimeSpan(ts.Hours, ts.Minutes, ts.Seconds + 1)
        End If
        Return tsRounded
    End Function

    Public Function getQueuedJobs() As System.Windows.Forms.ListView.ListViewItemCollection
        Return lvw_JobList.Items
    End Function

    Private Sub txt_FreqHi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub txt_FreqLo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub txt_DataPointsPerDecade_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub txt_waitFor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back And e.KeyChar <> "." Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If

    End Sub

    Private Sub txt_Loop_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub





    Private Function LogSpace(ByVal dec_lowLimit As Decimal, ByVal dec_highLimit As Decimal, ByVal int_pointsPerDecade As Integer) As List(Of Decimal)

        Dim dec_logLow As Decimal = System.Math.Log10(dec_lowLimit)
        Dim dec_logHigh As Decimal = System.Math.Log10(dec_highLimit)
        Dim int_DataPoints As Int32 = System.Math.Ceiling((dec_logHigh - dec_logLow) * int_pointsPerDecade)
        ' number of decades is log10(f_hi/f_lo)
        ' multiply by data points per decade to get total points
        ' EC lab uses a ceiling ie 43.051 data points -> 44 data points

        Dim lst_LogSpace As New List(Of Decimal)

        Dim dec_delta As Decimal = (dec_logHigh - dec_logLow) / int_DataPoints
        Dim dec_nDelta As Decimal = 0
        Dim dec_logFreq = System.Math.Log10(dec_lowLimit)

        For i As Int32 = 0 To int_DataPoints Step 1
            'MessageBox.Show(i)
            lst_LogSpace.Add(System.Math.Pow(10, dec_logLow + dec_nDelta))
            'MessageBox.Show(lst_LogSpace(i))
            dec_nDelta += dec_delta
        Next

        Return lst_LogSpace
    End Function

    Private Function FreqMultiplier(ByVal int_Freq As Integer, ByVal str_Suffix As String) As Decimal
        Select Case str_Suffix
            Case "MHz"
                Return int_Freq * 1000000
            Case "KHz"
                Return int_Freq * 1000
            Case "Hz"
                Return int_Freq
            Case "mHz"
                Return int_Freq * 0.001
            Case Else
                MessageBox.Show("You shouldn't be seeing this.")
                Return -1
        End Select



    End Function

    Private Sub pnl_NewPanel_Click(ByVal sender As Object, ByVal e As EventArgs)

        If My.Computer.Keyboard.ShiftKeyDown Then
            For int_i As Integer = 0 To lst_Panels.Count - 1 Step 1
                If lst_Channels(int_i) = 0 Then
                    ActivateChannel(lst_Panels(int_i))
                    lst_Channels(int_i) = 1
                    If lst_Panels(int_i).Name = sender.Name Then Exit For
                End If
            Next

        Else
            For int_j As Integer = 0 To lst_Panels.Count - 1 Step 1
                If lst_Panels(int_j).Name = sender.Name Then
                    Select Case lst_Channels(int_j)
                        Case 0
                            ActivateChannel(sender)
                            lst_Channels(int_j) = 1
                        Case 1
                            DeactivateChannel(sender)
                            lst_Channels(int_j) = 0

                    End Select
                    Exit For
                End If
            Next
        End If
        setChannelsStatus()
        UpdateSelectedChannels()
    End Sub

    Private Sub UpdateSelectedChannels()
        Dim str_selectedChans As String = ""
        lst_SelectedChans = New List(Of Integer)

        For i As Integer = 0 To lst_Channels.Count - 1 Step 1

            Select Case lst_Channels(i)
                Case 1
                    If Not (lst_SelectedChans.Contains(i + 1)) Then
                        lst_SelectedChans.Add(i + 1)
                    End If
                Case Else
                    If lst_SelectedChans.Contains(i + 1) Then
                        lst_SelectedChans.Remove(i + 1)
                    End If
            End Select
        Next

        lst_SelectedChans.Sort()
        For j As Integer = 0 To lst_SelectedChans.Count - 1 Step 1
            str_selectedChans += CStr(lst_SelectedChans(j)) & ","
        Next
        If str_selectedChans <> "" Then
            txtChannelsSelected.Text = str_selectedChans.Substring(0, str_selectedChans.Length - 1)
        Else
            txtChannelsSelected.Text = ""
        End If
    End Sub

    Private Sub ActivateChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).Controls(1).Text = "Selected"
                lst_Panels(i).BackColor = Color.Green
                Exit For
            End If
        Next
    End Sub

    Private Sub DeactivateChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).Controls(1).Text = "Available"
                lst_Panels(i).BackColor = System.Drawing.SystemColors.Control
                Exit For
            End If
        Next
    End Sub

    Private Sub CurrentChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).Controls(1).Text = "Scanning..."
                lst_Panels(i).BackColor = Color.DodgerBlue
                Exit For
            End If
        Next
    End Sub

    Private Sub UpcomingChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).Controls(1).Text = "In queue"
                lst_Panels(i).BackColor = Color.Yellow
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim lstSelectedChans As List(Of String) = txtChannelsSelected.Text.Split(",").ToList
        For Each selectedChan In lstSelectedChans
            lst_Channels(CInt(selectedChan) - 1) = 0
        Next
        setChannelsStatus()
        txtChannelsSelected.Text = ""
        Me.Close()
    End Sub





    Private Sub chbEmail_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chbEmail.CheckedChanged
        lblEmail.Enabled = chbEmail.Checked
        txtEmail.Enabled = chbEmail.Checked
    End Sub

    Private Sub btnAddJob_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJob.Click


        If txt_Name.Text = "" Then
            MessageBox.Show("Please enter a username.")
            Exit Sub
        End If

        If txtChannelsSelected.Text = "" Then
            MessageBox.Show("Please select some channels.")
            'btnAddJob.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If

        Dim strUser As String = txt_Name.Text
        Dim strChannels As String = txtChannelsSelected.Text

        For Each item As ListViewItem In lvw_JobList.Items
            Dim strThisChanList As String = item.SubItems(1).Text
            If (strThisChanList.Split(",").Intersect(strChannels.Split(",")).Count() > 0) Then
                MessageBox.Show("Some of these channels are already selected.")
                Exit Sub
            End If
        Next





        Dim lstItemThisJob = New ListViewItem(strUser)
        lstItemThisJob.SubItems.AddRange({strChannels})

        lvw_JobList.Items.Add(lstItemThisJob)

        Dim tplThisEmail As Tuple(Of Boolean, String) = Tuple.Create(chbEmail.Checked, txtEmail.Text)
        lst_Emails.Add(tplThisEmail)

        For Each channel In strChannels.Split(",")
            lst_Channels(CInt(channel) - 1) = 2
        Next
        setChannelsStatus()
        txtChannelsSelected.Text = ""
        txt_Name.Text = ""
    End Sub

    Private Sub tmrUpdatePanel_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdatePanel.Tick
        If lst_Channels Is Nothing Then Exit Sub
        setChannelsStatus()
    End Sub

    Public Sub ChooseLogfile()
        If sfdLogFile.ShowDialog() = DialogResult.OK Then
            txtLogfile.Text = sfdLogFile.FileName
            str_logFilePath = sfdLogFile.FileName
            bool_customLogFile = True
        End If
    End Sub

    Private Sub btnSelectLogFolder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectLogFolder.Click
        chooselogfile()
    End Sub
End Class