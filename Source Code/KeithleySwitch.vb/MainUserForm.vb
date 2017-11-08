Imports System.Threading
Imports System.Net.Mail
Imports System.Timers
Imports System.Text

Public Class MainUserForm

    'Configuration variable
    Private intDMMPosition As Integer   'The Nth DMM N in {0,1,2}, for the front panel

    'UI variables
    Private bool_FormClosed = False
    Private lst_Panels As List(Of Panel)
    Private lst_Channels As List(Of Integer)
    Private lst_AddedChannels As List(Of Integer)
    Private int_boxLength As Integer = 100
    Private int_NumChannels As Integer = 16
    Private lstEmails As New List(Of Tuple(Of Boolean, String))
    Private frmAddJob As AddJob
    Private frmDelooper As Delooper
    Private frmAbout_ As frmAbout


    'Timing variables

    Private bool_scanInProgress = False
    Private bool_scanCrashed = False
    Private bool_waitingForScanToCatchUp = False
    Private bool_firstRunCompleted = False
    Private bool_Started As Boolean = False
    Private bool_scanAborted As Boolean = False
    Private bool_forceCompletion As Boolean = False
    Private tsUpdatedTime As TimeSpan
    Private lstTimeInfo As List(Of TimeSpan)
    Private tmrUpdatePanels As New Timers.Timer

    'GPIB variables
    Private boolGpibDebug As Boolean = True

    Private boolGpibConnected As Boolean
    Private arrGpibAddresses As Integer() = {16}
    Private lstGpibDevices As List(Of Device)
    Private GpibDev As Device
    Private int_KeithleyAddr As Integer
    Private int_CurrentChan As Integer
    Private int_CurrentReset As Integer
    Private bool_waitingForTrigger As Boolean = False
    Private arr_PinList As Tuple(Of Integer, Integer)() = lstPins()
    Private strErrorMask As Array = {False, False, False, False, False}    '{Connection, close a pin, open all, set up trigger, read register}

    Public Function isOpen() As Boolean
        Return Not bool_FormClosed
    End Function

    Public Function isConnected() As Boolean
        Return boolGpibConnected
    End Function

    Public Sub setGPIBOptions(ByVal intDMMPos As Integer, ByVal intDMMAddr As Integer)
        int_KeithleyAddr = intDMMAddr
        intDMMPosition = intDMMPos
    End Sub

    Private Sub MainUserForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        bool_FormClosed = True
        If bool_scanInProgress Then bool_scanAborted = True
        Try
            If boolGpibConnected Then
                boolGpibConnected = False

                GpibDev.Write("*RST")                                 'put keithley into reset mode, update lcd display for user
                Threading.Thread.Sleep(100)
                GpibDev.Write(":DISP:TEXT:STAT OFF")
                Threading.Thread.Sleep(100)

            End If
        Finally
        End Try

    End Sub

    Private Sub MainUserForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        bool_FormClosed = False
        strErrorMask = {False, False, False, False, False}
        updateButtons()

        GpibDev = Connect()       'connects Keithley at address 16

        If Not GpibDev Is Nothing Then
            OpenAllRelays()             'sends the open all relay command to ensure all channels are open before scan
            loadFrontPanel()            'loads UI, channel panels, positions all groupboxes etc
            boolGpibConnected = True
            'gpibhub.setBoolCons(intDMMPosition, True)
        Else
            MessageBox.Show("The multimeter with address " & CStr(int_KeithleyAddr) & " is not connected." & vbCrLf & "Please connect the multimeter and set its GPIB address to " & CStr(int_KeithleyAddr) & ".")
            Me.Close()
        End If

    End Sub

    Private Function Connect() As Device
        Try
            Dim Gpib As New Device(0, CByte(int_KeithleyAddr), 0)       'Connect keithley
            Gpib.Write("*RST")                                 'put keithley into reset mode, update lcd display for user
            Threading.Thread.Sleep(100)
            Gpib.Write(":DISP:TEXT:STAT ON")
            Threading.Thread.Sleep(100)
            Gpib.Write(":DISP:TEXT:DATA 'INITIALISING'")
            Threading.Thread.Sleep(2000)
            Gpib.Write("DISP:TEXT:DATA '" & CStr(int_KeithleyAddr) & " CONNECTED'")
            Return Gpib
        Catch
            boolGpibConnected = False
            strErrorMask(0) = True
            Return Nothing
        End Try
    End Function

    Private Function genErrorString() As String
        Dim strError As String = ""

        If strErrorMask(0) Then
            strError = strError & "Error occurred while attempting connection" & vbCrLf
        End If
        If strErrorMask(1) Then
            strError = strError & "Error occurred while switching channels" & vbCrLf
        End If
        If strErrorMask(2) Then
            strError = strError & "Error occurred while opening all channels" & vbCrLf
        End If
        If strErrorMask(3) Then
            strError = strError & "Error occurred while setting up trigger" & vbCrLf
        End If
        If strErrorMask(4) Then
            strError = strError & "Error occurred while reading Keithley register" & vbCrLf
        End If

        strErrorMask = {False, False, False, False, False}
        Return strError
    End Function

    Private Sub loadFrontPanel()
        lst_Panels = New List(Of Panel)
        lst_Channels = New List(Of Integer)
        lst_AddedChannels = New List(Of Integer)
        Dim int_Counter As Integer = 1

        '2x2 Array of panels, iterate over x and y
        For y As Integer = 1 To System.Math.Ceiling(System.Math.Sqrt(int_NumChannels))
            For x As Integer = 1 To System.Math.Ceiling(System.Math.Sqrt(int_NumChannels))

                Dim pt_location As New Point(20 + (x - 1) * (int_boxLength + 10), 20 + (y - 1) * (int_boxLength + 10)) 'gets x,y position for this panel

                'initialises labels for each panel
                Dim lbl_ChanLabel As New Label
                Dim lbl_Availability As New Label
                Dim lbl_TimeLeft As New Label
                Dim pnl_NewPanel As New Panel

                'sets the channel properties, with name format pnl_channel1 eg for first channel
                With pnl_NewPanel

                    .Name = "pnl_channel" & CStr(int_Counter)
                    .Size = New Point(int_boxLength, int_boxLength)
                    .Location = pt_location
                    .BorderStyle = BorderStyle.Fixed3D
                End With

                'because the panel array is a square, if there are more spots than channels _
                'only makes panel usable if channel number is less than or equal to channel index
                If int_Counter <= int_NumChannels Then

                    With lbl_ChanLabel

                        .Text = CStr(int_Counter)
                        .Location = New Point(0, 0)
                        .Enabled = False
                    End With

                    With lbl_Availability

                        .Text = "Available"
                        .Location = New Point(20, 40)
                        .Enabled = False
                    End With

                    With lbl_TimeLeft

                        .Text = TimeSpan.Zero.ToString
                        .Location = New Point(20, 65)
                        .Enabled = False
                        .Visible = False
                    End With

                    lst_Panels.Add(pnl_NewPanel)
                Else

                    With lbl_ChanLabel

                        .Text = "Not in use"
                        .Location = New Point(20, 40)
                    End With
                End If

                'Adds panels to groupbox and labels to panels
                gbx_Channels.Controls.Add(pnl_NewPanel)
                pnl_NewPanel.Controls.Add(lbl_ChanLabel)
                pnl_NewPanel.Controls.Add(lbl_Availability)
                pnl_NewPanel.Controls.Add(lbl_TimeLeft)
                int_Counter += 1

                'below sets sizes of all group boxes on UI, makes it look good
                gbx_Channels.Size = New Point(pt_location.X + int_boxLength + 10, pt_location.Y + int_boxLength + 10)

                gbx_colours.Size = New Point(gbx_Channels.Size.Width, 65)
                gbx_colours.Location = New Point(gbx_Channels.Location.X, gbx_Channels.Location.Y + gbx_Channels.Size.Height)

                gbx_StartScan.Size = New Point(gbx_Channels.Size.Width, 220)
                gbx_StartScan.Location = New Point(gbx_Channels.Location.X, gbx_colours.Location.Y + gbx_colours.Size.Height)
                'Me.Size = New Point(gbx_Channels.Size.Width + 35, gbx_StartScan.Location.Y + gbx_StartScan.Size.Height + 50)
                'Me.Size = New Point(640, 1056)
                Me.Size = New Point(Screen.PrimaryScreen.Bounds.Width / 3, Screen.PrimaryScreen.Bounds.Height - 40)

            Next
        Next
        'Inits lists that hold channel information (lst_Channels)
        'and the channel info returned from the add job form (lst_AddedChannels)
        For int_i = 0 To int_NumChannels - 1 Step 1
            lst_Channels.Add(0)
            lst_AddedChannels.Add(0)
        Next
    End Sub

    Private Sub updatePanelColor()
        '{0,1,2,3} == {free, selected, in use this job, in use now} == {system grey, green, yellow, blue}
        Dim int_i As Integer = 0
        For Each panel In lst_Panels
            Select Case lst_Channels(int_i)
                Case 0
                    panel.BackColor = System.Drawing.SystemColors.Control
                Case 1
                    panel.BackColor = Color.Green
                Case 2
                    panel.BackColor = Color.Yellow
                Case 3
                    panel.BackColor = Color.DodgerBlue
            End Select
            int_i += 1
        Next
    End Sub

    Public Function getChannelsStatus() As List(Of Integer)
        'Returns channel list for the add job form to correctly load channels
        '{0,1,2,3} == {free, selected, in use this job, in use now}
        Return lst_Channels

    End Function

    Public Function copyList(ByVal lstOldList As List(Of Integer)) As List(Of Integer)
        'deep copies a list
        Dim lstNewList As New List(Of Integer)
        For Each entry In lstOldList
            lstNewList.Add(entry)
        Next
        Return lstNewList
    End Function

    Public Function copyList(ByVal lstOldList As List(Of Panel)) As List(Of Panel)
        'overloaded version of above
        Dim lstNewList As New List(Of Panel)
        For Each entry In lstOldList
            lstNewList.Add(entry)
        Next
        Return lstNewList
    End Function

    Private Sub setChannelsStatus()
        'iterates through channel status list and updates panels to match status
        '{0,1,2,3} == {free, selected, in use this job, in use now} == {system grey, green, yellow, blue}
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

            End Select
        Next
    End Sub

    Private Sub ActivateChannel(ByVal sender As Object)

        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                updatePanelText(lst_Panels(i), 1, "Selected")
                updatePanelLabelVisibility(lst_Panels(i), 2, False)
                'updatePanelText(lst_Panels(i), 2, "")
                updatePanelColour(lst_Panels(i), Color.Green)
                Exit For
            End If
        Next
    End Sub

    Private Sub DeactivateChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                updatePanelText(lst_Panels(i), 1, "Available")
                updatePanelLabelVisibility(lst_Panels(i), 2, False)
                'updatePanelText(lst_Panels(i), 2, "")
                updatePanelColour(lst_Panels(i), System.Drawing.SystemColors.Control)
                Exit For
            End If
        Next
    End Sub

    Private Sub CurrentChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                updatePanelText(lst_Panels(i), 1, "Scanning...")
                updatePanelLabelVisibility(lst_Panels(i), 2, True)
                updatePanelText(lst_Panels(i), 2, TimeSpan.Zero.ToString)
                updatePanelColour(lst_Panels(i), Color.DodgerBlue)
                Exit For
            End If
        Next
    End Sub

    Private Sub UpcomingChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                updatePanelText(lst_Panels(i), 1, "In queue")
                updatePanelLabelVisibility(lst_Panels(i), 2, False)
                'updatePanelText(lst_Panels(i), 2, "")
                updatePanelColour(lst_Panels(i), Color.Yellow)
                Exit For
            End If
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

    Private Sub StartScanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartScanToolStripMenuItem.Click

        If Not boolGpibConnected Then
            MessageBox.Show("Please connect a DMM (Setup -> Configure Keithley DMM)")
            Exit Sub
        End If

        frmAddJob = New AddJob

        frmAddJob.setDefaultLogFilePath("C:\EISLog\logfile_DMM" & CStr(intDMMPosition + 1) & ".txt")
        frmAddJob.setChannels(lst_Channels)
        tmrUpdateAddJobPanels.Start()
        'tmrUpdatePanels.Start()

        If frmAddJob.ShowDialog() = Windows.Forms.DialogResult.OK Then

            Dim itemCollection As ListView.ListViewItemCollection = frmAddJob.getQueuedJobs()
            For int_i As Integer = 0 To itemCollection.Count - 1 Step 1
                Dim item As New ListViewItem(itemCollection(int_i).Text)
                item.SubItems.AddRange( _
                    {itemCollection(int_i).SubItems(1).Text, _
                     "TBD", _
                     "TBD"})

                lvwQueuedJobs.Items.Add(item)
            Next

            lstEmails.AddRange(frmAddJob.getEmails())

            For Each item As ListViewItem In lvwQueuedJobs.Items
                Dim lstChanList As List(Of String) = item.SubItems(1).Text.Split(",").ToList

                For Each channel As String In lstChanList
                    lst_AddedChannels.Item(CInt(channel) - 1) = 1
                Next

                Dim lst_NewChannelStatus As List(Of Integer) = copyList(lst_Channels)

                For int_i As Integer = 0 To lst_AddedChannels.Count() - 1

                    If (lst_AddedChannels(int_i) = 1) Then

                        lst_NewChannelStatus(int_i) = 2
                        lst_AddedChannels(int_i) = 0    'reset the added channel list as we add each channel to the queue
                    End If
                Next
                lst_Channels = copyList(lst_NewChannelStatus)
                updatePanelColor()
                setChannelsStatus()
            Next
        End If
        tmrUpdateAddJobPanels.Stop()
        'tmrUpdatePanels.Stop()
        '     End Using

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If lvwQueuedJobs.Items.Count() = 0 Then Exit Sub

        Dim lstStrChannels As List(Of String) = lvwQueuedJobs.Items(0).SubItems(1).Text.Split(",").ToList
        Dim arrIntChannels As Integer() = Array.ConvertAll(lvwQueuedJobs.Items(0).SubItems(1).Text.Split(","), Function(str) Int32.Parse(str))

        bool_scanInProgress = True
        bool_firstRunCompleted = False
        bool_Started = False
        bool_waitingForScanToCatchUp = True
        bool_scanAborted = False

        updateButtons()

        lvwQueuedJobs.Items(0).SubItems(3).Text = roundTimeSpan(DateTime.Now.TimeOfDay).ToString()

        Dim trdScan As New Threading.Thread(AddressOf EISTest)
        trdScan.Name = "Scan"
        trdScan.Start(arrIntChannels) 'deals with the multimeter commands
    End Sub

    Private Function removeFirstChannel(ByVal str As String) As String
        If str Is Nothing Then Return Nothing
        Dim lstStr As List(Of String) = str.Split(",").ToList
        lstStr.RemoveAt(0)
        Return Join(lstStr.ToArray, ",")
    End Function

    Private Sub countDown(ByVal lstUsedChannels As List(Of String))

        Dim tsOldTime As TimeSpan
        Dim tsTimeNow As TimeSpan
        Dim tupEmailInfoThisJob As Tuple(Of Boolean, String) = lstEmails.Item(0)
        Dim intTimeDifference As Integer

        Do Until (bool_Started Or bool_scanAborted Or bool_forceCompletion)
            Threading.Thread.Sleep(250)
        Loop

        tsOldTime = roundTimeSpan(DateTime.Now.TimeOfDay)
        Do While (bool_scanInProgress And Not bool_scanCrashed)

            tsTimeNow = roundTimeSpan(DateTime.Now.TimeOfDay)
            intTimeDifference = tsTimeNow.TotalSeconds - tsOldTime.TotalSeconds

            If getJobTime() <> "TBD" Then
                Dim tsCurrentJobTime As TimeSpan = TimeSpan.Parse(getJobTime())
                tsCurrentJobTime = tsCurrentJobTime.Subtract(TimeSpan.FromSeconds(intTimeDifference))

                If tsCurrentJobTime.TotalSeconds < 1 Then

                    Do Until bool_waitingForScanToCatchUp Or bool_scanAborted Or bool_FormClosed
                        If bool_firstRunCompleted Then
                            tsCurrentJobTime = TimeSpan.Parse(getJobTime())
                            bool_waitingForScanToCatchUp = False
                        Else
                            Threading.Thread.Sleep(100)
                        End If
                    Loop
                Else
                    setJobTime(lvwQueuedJobs, tsCurrentJobTime.ToString())
                    Application.DoEvents()
                End If
            End If
            tsOldTime = tsTimeNow
            Threading.Thread.Sleep(1000)
        Loop
        updateButtons()
        If bool_scanAborted Or bool_scanCrashed Then Exit Sub

        If tupEmailInfoThisJob.Item1 Then
            sendEmail(getLvwFirstItem, lstUsedChannels, tupEmailInfoThisJob.Item2, lstTimeInfo)
        End If

        removeJobFromQueue("countdown function")
        lstEmails.RemoveAt(0)
        resetScanParams()

    End Sub

    Private Sub countUp(ByVal lstUsedChannels As List(Of String))
        While bool_scanInProgress And Not bool_scanCrashed And Not bool_FormClosed
            For int_idx As Integer = 0 To lst_Channels.Count - 1
                If lst_Channels(int_idx) = 3 Then
                    Dim teststr As String = getTimeOnPanel(lst_Panels(int_idx))
                    updatePanelText(lst_Panels(int_idx), 2, TimeSpan.Parse(getTimeOnPanel(lst_Panels(int_idx))).Add(TimeSpan.FromSeconds(1)).ToString)
                    System.Threading.Thread.Sleep(1000)
                End If
            Next
        End While
    End Sub

    Private Sub sendEmail(ByVal ltmJobInfo As ListViewItem, ByVal lstUsedChannels As List(Of String), ByVal strAddress As String, ByVal lstTimingInfo As List(Of TimeSpan))

        Dim strUsername As String = ltmJobInfo.SubItems(0).Text
        Try
            Dim SmtpServer As New SmtpClient()
            Dim mail As New MailMessage()
            Dim attachments As New List(Of String)

            SmtpServer.UseDefaultCredentials = False
            SmtpServer.EnableSsl = True
            SmtpServer.Credentials = New Net.NetworkCredential("dahngarbagechecker@gmail.com", "dahnlab2016")
            SmtpServer.Port = 587
            SmtpServer.Host = "smtp.gmail.com"

            mail = New MailMessage()
            mail.From = New MailAddress("dahngarbagechecker@gmail.com")
            mail.To.Add(strAddress)
            mail.Subject = strUsername & ": EIS scan completion " & Date.Now.ToString

            Dim strBody As String = ""
            Dim intIdx As Integer = 0
            Dim decMean As Decimal = 0
            Dim decMeanSqr As Decimal = 0
            Dim decStdDev As Decimal

            For Each tsTime In lstTimingInfo
                decMean += tsTime.TotalSeconds / lstTimingInfo.Count
                decMeanSqr += Math.Pow(tsTime.TotalSeconds, 2) / lstTimingInfo.Count
            Next

            decStdDev = Math.Sqrt(decMeanSqr - Math.Pow(decMean, 2))

            For Each strChannel In lstUsedChannels
                strBody = strBody & "Channel " & strChannel & ": " & lstTimingInfo(intIdx).ToString & vbCrLf
                intIdx += 1
            Next

            mail.Body = strBody & "Mean time: " & TimeSpan.FromSeconds(decMean).ToString & vbCrLf & "Standard deviation: " & CStr(decStdDev) & " seconds"

            SmtpServer.Send(mail)
            'MsgBox("mail send")
        Catch ex As Exception
            'MsgBox("Exception of some type")
            'writeToLog(ex.Message)

        End Try
    End Sub

    Private Sub abortCurrentScan()
        For Each channel In getCurrentChannels().Split(",").ToList()
            lst_Channels(CInt(channel) - 1) = 0
        Next
        setChannelsStatus()
        removeJobFromQueue("abort function")
        resetScanParams()
    End Sub

    Private Sub resetCurrentScan(ByVal strInitChannels As String, ByVal strInitTime As String)
        For Each channel In strInitChannels.Split(",").ToList()
            lst_Channels(CInt(channel) - 1) = 2
        Next
        setCurrentChannels(lvwQueuedJobs, strInitChannels)
        setJobTime(lvwQueuedJobs, strInitTime)
        setStartTime(lvwQueuedJobs, "TBD")
        setChannelsStatus()
        resetScanParams()
        GpibDev.Write("*RST")
    End Sub

    'GPIB SCANNING CAPABILITY BELOW'

    Private Sub EISTest(ByVal arrScanList As Integer())

        Dim strFileName As String
        If frmAddJob.isCustomLogPath() Then
            strFileName = frmAddJob.getCustomLogFilePath()
            'Dim strFileName As String = "C:\EISLog\logfile_DMM" & CStr(intDMMPosition + 1) & ".txt"
        Else
            strFileName = frmAddJob.getDefaultLogFilePath()
        End If

        'Dim intOffset As Integer = 0
        Dim byScanStart As Byte() = New UTF8Encoding(True).GetBytes("Scan started at " & Now.ToString & " by " & getLvwFirstItem().SubItems(0).Text & vbCrLf)
        Dim byChannelStart As Byte()
        Dim byChannelDone As Byte()
        Dim byScanDone As Byte()
        Dim byScanRetry As Byte()
        Dim byScanReset As Byte()
        Dim byScanAborted As Byte()
        Dim byScanCrashed As Byte()

        Dim fsLogFile As System.IO.FileStream = System.IO.File.Open(strFileName, IO.FileMode.Create)

        fsLogFile.Write(byScanStart, 0, byScanStart.Length)
        'intOffset += byScanStart.Length

        strErrorMask = {False, False, False, False, False}  'Reset error mask
        Dim int_Channels As Integer = arrScanList.Count

        'If scan fails due to exception, user can retry, the next 4 variables keep track of orig settings
        Dim int_ChannelsRetry As Integer = arrScanList.Count
        Dim str_ChannelsRetry As String = getCurrentChannels()
        Dim str_JobTimeRetry As String = getJobTime()
        Dim lst_ChannelsRetry As List(Of Integer) = copyList(lst_Channels)

ScanStart:

        Try
            OpenAllRelays()

            Dim trdCountdown As New Threading.Thread(AddressOf countDown)
            trdCountdown.IsBackground = True
            trdCountdown.Name = "ScanTimer"
            trdCountdown.Start(getCurrentChannels().Split().ToList) 'deals with counting down the timer in the job list box

            Dim trdCountUp As New Threading.Thread(AddressOf countUp)
            trdCountUp.IsBackground = True
            trdCountUp.Name = "ChannelTimer"
            trdCountUp.Start() 'deals with counting up the timer on the currently selected channel

            Threading.Thread.Sleep(500)

            'Dim lstLoopTimes As New List(Of Tuple(Of Integer, TimeSpan))
            Dim dteStartTime As TimeSpan
            Dim dteEndTime As TimeSpan
            lstTimeInfo = New List(Of TimeSpan)

            setUpTrigger()
            'MessageBox.Show("Please run the EC-Lab routine now")
            Do While Not (bool_Started Or bool_scanAborted Or bool_forceCompletion)
                If getOperRegister()(10) = "1" Then

                    bool_Started = True
                End If
                Threading.Thread.Sleep(500)
            Loop

            If Not bool_scanAborted Then

                For Each channel In arrScanList

                    dteStartTime = DateTime.Now.TimeOfDay

                    byChannelStart = New UTF8Encoding(True).GetBytes("Channel " & CStr(channel) & " started at " & dteStartTime.ToString & vbCrLf)
                    fsLogFile.Write(byChannelStart, 0, byChannelStart.Length)
                    'intOffset += byChannelStart.Length

                    'fsLogFile.

                    bool_waitingForTrigger = True
                    lst_Channels(channel - 1) = 3

                    setChannelsStatus() ' something here throwing exception on formclose check it out
                    If Not bool_FormClosed Then SetChannel(channel)

                    Application.DoEvents()
                    Threading.Thread.Sleep(1000)

                    setUpTrigger()

                    Do While (bool_waitingForTrigger And Not bool_forceCompletion)
                        If getOperRegister()(10) = "1" Then
                            bool_waitingForTrigger = False
                        End If
                        Threading.Thread.Sleep(500)
                    Loop

                    lst_Channels(channel - 1) = 0
                    setChannelsStatus()

                    dteEndTime = DateTime.Now.TimeOfDay
                    tsUpdatedTime = TimeSpan.FromSeconds((int_Channels - 1) * roundTimeSpan(dteEndTime - dteStartTime).TotalSeconds)
                    If tsUpdatedTime.TotalSeconds < 0 Then tsUpdatedTime = TimeSpan.Zero
                    lstTimeInfo.Add(roundTimeSpan(dteEndTime - dteStartTime))
                    setJobTime(lvwQueuedJobs, tsUpdatedTime.ToString)

                    If Not bool_firstRunCompleted Then
                        bool_firstRunCompleted = True
                    End If

                    setCurrentChannels(lvwQueuedJobs, removeFirstChannel(getCurrentChannels()))
                    int_Channels -= 1


                    byChannelDone = New UTF8Encoding(True).GetBytes("Channel " & CStr(channel) & " completed at " & dteEndTime.ToString & " Total scan time: " & roundTimeSpan(dteEndTime - dteStartTime).ToString & vbCrLf)
                    If Not bool_scanAborted Then fsLogFile.Write(byChannelDone, 0, byChannelDone.Length)
                    'intOffset += byChannelStart.Length
                    'OpenAllRelays()
                    If bool_scanAborted Then
                        byScanAborted = New UTF8Encoding(True).GetBytes("Scan was aborted")
                        fsLogFile.Write(byScanAborted, 0, byScanAborted.Length)
                        Exit For
                    End If
                Next
            End If
            bool_scanInProgress = False
            'OpenAllRelays()

            If bool_scanAborted Then
                GpibDev.Write(":DISP:TEXT:DATA 'ABORTED'")
            Else
                byScanDone = New UTF8Encoding(True).GetBytes("Scan completed successfully at " & Now.ToString)
                fsLogFile.Write(byScanDone, 0, byScanDone.Length)
                GpibDev.Write(":DISP:TEXT:DATA 'DONE'")
            End If

        Catch
            byScanCrashed = New UTF8Encoding(True).GetBytes("Scan crashed at " & Now.ToString & vbCrLf)
            fsLogFile.Write(byScanCrashed, 0, byScanCrashed.Length)
            'intOffset += byScanCrashed.Length

            Dim bool_crashResolved As Boolean = False
            bool_forceCompletion = False
            bool_scanCrashed = True

            'bool_scanInProgress = False
            'updateButtons()
            If bool_scanAborted Then
                byScanAborted = New UTF8Encoding(True).GetBytes("Scan was aborted but crashed")
                fsLogFile.Write(byScanAborted, 0, byScanAborted.Length)
                'intOffset += byScanAborted.Length
                fsLogFile.Close()
                Exit Sub
            End If

            Do
                Select Case MessageBox.Show(genErrorString() & vbCrLf & "Please ensure the multimeter at address " & CStr(int_KeithleyAddr) & " is physically connected and operational." _
                                & vbCrLf & "You can either retry or cancel the scan", "Communication error during scan", MessageBoxButtons.RetryCancel)
                    Case Windows.Forms.DialogResult.Retry
                        byScanRetry = New UTF8Encoding(True).GetBytes("Retrying scan" & vbCrLf)
                        fsLogFile.Write(byScanRetry, 0, byScanRetry.Length)
                        'intOffset += byScanRetry.Length
                        MessageBox.Show("Please cancel the currently running EC-Lab routine")
                        GpibDev = Connect()
                        If Not GpibDev Is Nothing Then
                            'bool_scanInProgress = True
                            bool_crashResolved = True
                            int_Channels = int_ChannelsRetry
                            setCurrentChannels(lvwQueuedJobs, str_ChannelsRetry)
                            lst_Channels = lst_ChannelsRetry
                            setChannelsStatus()
                            'updateButtons()
                            GoTo ScanStart
                        End If
                    Case Windows.Forms.DialogResult.Cancel
                        Select Case MessageBox.Show("Remove current scan from queue?", "", MessageBoxButtons.YesNo)
                            Case Windows.Forms.DialogResult.Yes
                                byScanAborted = New UTF8Encoding(True).GetBytes("User aborted scan after crash leaving channels " & getLvwFirstItem.SubItems(1).Text & " uncompleted" & vbCrLf)
                                fsLogFile.Write(byScanAborted, 0, byScanAborted.Length)
                                'intOffset += byScanAborted.Length

                                abortCurrentScan()

                            Case Windows.Forms.DialogResult.No
                                byScanReset = New UTF8Encoding(True).GetBytes("Scan reset after crash")
                                fsLogFile.Write(byScanReset, 0, byScanReset.Length)
                                'intOffset += byScanReset.Length

                                resetCurrentScan(str_ChannelsRetry, str_JobTimeRetry)
                        End Select
                        bool_scanInProgress = False
                        updateButtons()
                        bool_crashResolved = True
                End Select
            Loop Until bool_crashResolved
        End Try
        fsLogFile.Close()
        bool_scanInProgress = False
        bool_scanCrashed = False
        OpenAllRelays()
        Threading.Thread.Sleep(2000)
        updateButtons()
    End Sub

    Private Sub OpenAllRelays()

        Dim str_ResetPins As String = ""
        'Dim int_pinNo As Integer = 0

        For Each Pins In arr_PinList
            str_ResetPins = str_ResetPins & CStr(Pins.Item2) & ","
        Next

        Try
            Dim str_CommandString As String = ":ROUT:MULT:CLOS (@" & str_ResetPins.Remove(str_ResetPins.Length - 1) & ")"
            GpibDev.Write(str_CommandString)
            Threading.Thread.Sleep(1000)
            GpibDev.Write(":ROUT:OPEN:ALL")
            int_CurrentChan = 0
            'updateTextBoxText(txtCurrChan, CStr(int_CurrentChan))


        Catch
            strErrorMask(2) = True
            Throw New GpibException
        End Try


    End Sub

    Private Function getOperRegister() As String
        Try
            GpibDev.Write("STAT:OPER:COND?")
            Dim strStatus As String = strDec2strBin(GpibDev.ReadString())
            Return strStatus
        Catch
            strErrorMask(4) = True
            Throw New GpibException
        End Try
    End Function

    Public Function lstPins() As Array
        Dim chan1 = Tuple.Create(102, 103)
        Dim chan2 = Tuple.Create(106, 107)
        Dim chan3 = Tuple.Create(110, 111)
        Dim chan4 = Tuple.Create(114, 115)
        Dim chan5 = Tuple.Create(122, 123)
        Dim chan6 = Tuple.Create(126, 127)
        Dim chan7 = Tuple.Create(130, 131)
        Dim chan8 = Tuple.Create(134, 135)
        Dim chan9 = Tuple.Create(202, 203)
        Dim chan10 = Tuple.Create(206, 207)
        Dim chan11 = Tuple.Create(210, 211)
        Dim chan12 = Tuple.Create(214, 215)
        Dim chan13 = Tuple.Create(222, 223)
        Dim chan14 = Tuple.Create(226, 227)
        Dim chan15 = Tuple.Create(230, 231)
        Dim chan16 = Tuple.Create(234, 235)
        Dim lst_Channels = New Tuple(Of Integer, Integer)() {chan1, chan2, chan3, chan4, chan5, chan6, chan7, chan8, _
                                                            chan9, chan10, chan11, chan12, chan13, chan14, chan15, chan16}



        Return (lst_Channels)
    End Function

    Private Sub SetChannel(ByVal int_ChannelNum As Integer)

        If int_CurrentChan = int_ChannelNum Then Exit Sub
        Dim int_SetPin As Integer = arr_PinList(int_ChannelNum - 1).Item1
        Dim int_ResetPin As Integer = arr_PinList(int_ChannelNum - 1).Item2
        If int_CurrentChan <> 0 Then
            ClosePin(int_CurrentReset)
            Threading.Thread.Sleep(250)
        End If

        ClosePin(int_SetPin)
        Threading.Thread.Sleep(250)
        GpibDev.Write(":ROUT:OPEN:ALL")
        int_CurrentChan = int_ChannelNum
        int_CurrentReset = int_ResetPin
        GpibDev.Write(":DISP:TEXT:DATA 'CHANNEL " & CStr(int_CurrentChan) & "'")
        GpibDev.Write(":DISP:TEXT:STAT ON")

    End Sub

    Private Sub ClosePin(ByVal int_PinToClose As Integer)
        Try
            Dim str_CommandString As String = ":ROUT:MULT:CLOS (@" & CStr(int_PinToClose) & ")"
            GpibDev.Write(str_CommandString)
        Catch
            strErrorMask(1) = True
            Throw New GpibException
        End Try


    End Sub

    Private Sub setUpTrigger()
        Try
            GpibDev.Write("ABOR")
            Threading.Thread.Sleep(50)
            GpibDev.Write("TRIG:SOUR EXT")
            Threading.Thread.Sleep(50)
            GpibDev.Write("TRIG:DEL 1")
            Threading.Thread.Sleep(50)
            GpibDev.Write("SAMP:COUN 1")
            Threading.Thread.Sleep(50)
            GpibDev.Write("TRIG:COUN 1")
            Threading.Thread.Sleep(50)
            GpibDev.Write("INIT:CONT OFF")
            Threading.Thread.Sleep(50)
            GpibDev.Write("INIT")
            Threading.Thread.Sleep(750)
        Catch
            strErrorMask(3) = True
            Throw New GpibException
        End Try

    End Sub

    Private Function strDec2strBin(ByVal strDec As String)
        'we only need 16 bits
        Dim strBin As String = ""

        Dim intDec As Integer = CInt(strDec)

        Do Until (intDec = 0)
            If (intDec Mod 2) Then
                strBin = strBin & "1"
            Else
                strBin = strBin & "0"
            End If
            intDec /= 2

        Loop
        Do Until (Len(strBin) = 16)
            strBin = strBin & "0"
        Loop

        Return strBin
    End Function

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvwQueuedJobs.Items.Count = 0 Then Exit Sub
        For Each channel As String In lvwQueuedJobs.Items(0).SubItems(1).Text.Split(",")
            lst_Channels(CInt(channel) - 1) = 0
        Next
        setChannelsStatus()
        lvwQueuedJobs.Items.RemoveAt(0)
    End Sub

    'MULTITHREADING DELEGATE ROUTINES BELOW'

    Private Delegate Function getPanelDisposedDelegate(ByVal pnl As Panel) As Boolean

    Private Function getPanelDisposed(ByVal pnl As Panel) As Boolean
        Dim bool_isDisposed As Boolean
        Try

            If pnl.InvokeRequired Then
                bool_isDisposed = pnl.Invoke(New getPanelDisposedDelegate(AddressOf getPanelDisposed), New Object() {pnl})
            Else
                bool_isDisposed = pnl.IsDisposed
            End If
        Catch
            bool_isDisposed = True
        End Try
        Return bool_isDisposed
    End Function

    Private Delegate Function getTextBoxDisposedDelegate(ByVal txt As TextBox) As Boolean

    Private Function getTextBoxDisposed(ByVal txt As TextBox) As Boolean
        Dim bool_isDisposed As Boolean
        Try

            If txt.InvokeRequired Then
                bool_isDisposed = txt.Invoke(New getTextBoxDisposedDelegate(AddressOf getTextBoxDisposed), New Object() {txt})
            Else
                bool_isDisposed = txt.IsDisposed
            End If
        Catch
            bool_isDisposed = True
        End Try
        Return bool_isDisposed
    End Function

    Private Delegate Sub updatePanelLabelVisibilityDelegate(ByVal pnl As Panel, ByVal ctrlIdx As Integer, ByVal bool As Boolean)

    Private Sub updatePanelLabelVisibility(ByVal pnl As Panel, ByVal ctrlIdx As Integer, ByVal bool As Boolean)
        If getPanelDisposed(pnl) Then Exit Sub
        If pnl.InvokeRequired Then
            pnl.Invoke(New updatePanelLabelVisibilityDelegate(AddressOf updatePanelLabelVisibility), New Object() {pnl, ctrlIdx, bool})
        Else
            pnl.Controls(ctrlIdx).Visible = bool
        End If
    End Sub

    Private Delegate Sub updatePanelTextDelegate(ByVal pnl As Panel, ByVal ctrlIdx As Integer, ByVal str As String)

    Private Sub updatePanelText(ByVal pnl As Panel, ByVal ctrlIdx As Integer, ByVal str As String)
        If getPanelDisposed(pnl) Then Exit Sub
        If pnl.InvokeRequired Then
            pnl.Invoke(New updatePanelTextDelegate(AddressOf updatePanelText), New Object() {pnl, ctrlIdx, str})
        Else
            pnl.Controls(ctrlIdx).Text = str
        End If
    End Sub

    Private Delegate Sub updateTextBoxTextDelegate(ByVal txtbx As TextBox, ByVal str As String)

    Private Sub updateTextBoxText(ByVal txtbx As TextBox, ByVal str As String)
        If getTextBoxDisposed(txtbx) Then Exit Sub
        If txtbx.InvokeRequired Then
            txtbx.Invoke(New updateTextBoxTextDelegate(AddressOf updateTextBoxText), New Object() {txtbx, str})
        Else
            txtbx.Text = str
        End If
    End Sub

    Private Delegate Sub updatePanelColourDelegate(ByVal pnl As Panel, ByVal colour As Color)

    Private Sub updatePanelColour(ByVal pnl As Panel, ByVal colour As Color)
        If getPanelDisposed(pnl) Then Exit Sub
        If pnl.InvokeRequired Then
            pnl.Invoke(New updatePanelColourDelegate(AddressOf updatePanelColour), New Object() {pnl, colour})
        Else
            pnl.BackColor = colour
        End If
    End Sub

    Private Delegate Sub removeJobFromQueueDelegate(ByVal str As String)

    Private Sub removeJobFromQueue(ByVal str As String)
        Dim calledfrom As String = str
        If Me.lvwQueuedJobs.InvokeRequired Then
            lvwQueuedJobs.Invoke(New removeJobFromQueueDelegate(AddressOf removeJobFromQueue), New Object() {str})
        Else
            lvwQueuedJobs.Items.RemoveAt(0)
        End If
    End Sub

    Private Delegate Function getBtnDisposedDelegate(ByVal btn As Button) As Boolean

    Private Function getBtnDisposed(ByVal btn As Button) As Boolean
        Dim bool_isDisposed As Boolean
        Try
            If btn.InvokeRequired Then
                bool_isDisposed = btn.Invoke(New getBtnDisposedDelegate(AddressOf getBtnDisposed), New Object() {btn})
            Else
                bool_isDisposed = btn.IsDisposed
            End If
        Catch
            bool_isDisposed = True
        End Try
        Return bool_isDisposed
    End Function


    Private Delegate Sub SetButtonStateDelegate(ByVal btn As Button, ByVal enab As Boolean)

    Private Sub SetButtonState(ByVal btn As Button, ByVal enab As Boolean)
        If getBtnDisposed(btn) Then Exit Sub
        If btn.InvokeRequired Then
            btn.Invoke(New SetButtonStateDelegate(AddressOf SetButtonState), New Object() {btn, enab})
        Else
            btn.Enabled = enab
        End If
    End Sub

    Private Delegate Sub setJobTimeDelegate(ByVal lvw As ListView, ByVal str As String)

    Private Sub setJobTime(ByVal lvw As ListView, ByVal str As String)

        If lvw.InvokeRequired Then
            lvw.Invoke(New setJobTimeDelegate(AddressOf setJobTime), New Object() {lvw, str})
        Else
            If lvw.Items.Count < 1 Then Exit Sub
            lvw.Items(0).SubItems(2).Text = str
        End If
    End Sub

    Private Delegate Sub setStartTimeDelegate(ByVal lvw As ListView, ByVal str As String)

    Private Sub setStartTime(ByVal lvw As ListView, ByVal str As String)
        If lvw.InvokeRequired Then
            lvw.Invoke(New setStartTimeDelegate(AddressOf setStartTime), New Object() {lvw, str})
        Else
            lvw.Items(0).SubItems(3).Text = str
        End If
    End Sub

    'Private Delegate Function getJobTimeDelegate() As String

    Private Function getJobTime() As String
        If getLvwFirstItem() Is Nothing Then Return TimeSpan.Zero.ToString()
        Return getLvwFirstItem().SubItems(2).Text
    End Function

    Private Function getCurrentChannels() As String
        If getLvwFirstItem() Is Nothing Then Return Nothing
        Return getLvwFirstItem().SubItems(1).Text
    End Function

    Private Function getTimeOnPanel(ByVal pnl As Panel) As String
        If pnl.Controls.Count < 3 Then Return Nothing
        Return pnl.Controls(2).Text
    End Function

    Private Delegate Function getLvwCountDelegate() As Integer

    Private Function getLvwCount() As Integer
        Dim intLvwCount As Integer
        If getLvwDisposed() Then Return 0
        If Me.lvwQueuedJobs.InvokeRequired Then
            intLvwCount = Me.lvwQueuedJobs.Invoke(New getLvwCountDelegate(AddressOf getLvwCount))
        Else
            intLvwCount = Me.lvwQueuedJobs.Items.Count
        End If
        Return intLvwCount
    End Function

    Private Delegate Function getLvwFirstItemDelegate() As ListViewItem

    Private Function getLvwFirstItem() As ListViewItem
        Dim lvwItem As ListViewItem
        If getLvwCount() < 1 Then Return Nothing
        If Me.lvwQueuedJobs.InvokeRequired Then
            lvwItem = Me.lvwQueuedJobs.Invoke(New getLvwFirstItemDelegate(AddressOf getLvwFirstItem))
        Else
            'If Me.lvwQueuedJobs.Items.Count < 1 Then Return Nothing
            lvwItem = Me.lvwQueuedJobs.Items(0)
        End If
        Return lvwItem
    End Function

    Private Delegate Function getLvwDisposedDelegate() As Boolean

    Private Function getLvwDisposed() As Boolean
        Dim bool_isDisposed As Boolean
        Try
            If Me.lvwQueuedJobs.InvokeRequired Then
                bool_isDisposed = Me.lvwQueuedJobs.Invoke(New getLvwDisposedDelegate(AddressOf getLvwDisposed))
            Else
                bool_isDisposed = lvwQueuedJobs.IsDisposed
            End If
        Catch
            bool_isDisposed = True
        End Try
        Return bool_isDisposed
    End Function

    Private Delegate Sub setCurrentChannelsDelegate(ByVal lvw As ListView, ByVal str As String)

    Private Sub setCurrentChannels(ByVal lvw As ListView, ByVal str As String)
        If lvw.Items.Count < 1 Then Exit Sub
        If lvw.InvokeRequired Then
            lvw.Invoke(New setCurrentChannelsDelegate(AddressOf setCurrentChannels), New Object() {lvw, str})
        Else
            lvw.Items(0).SubItems(1).Text = str
        End If
    End Sub

    Private Sub DebugToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MainForm.ShowDialog()
    End Sub

    Private Sub AboutToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout_ = New frmAbout
        frmAbout_.ShowDialog()
    End Sub

    Private Sub ExportDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportDataToolStripMenuItem.Click
        Delooper.ShowDialog()
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        SetButtonState(btnAbort, False)
        SetButtonState(btnForceComplete, False)
        bool_scanAborted = True
        abortCurrentScan()
        GpibDev.Write("*RST")
    End Sub

    Private Sub updateButtons()
        SetButtonState(btnAbort, bool_scanInProgress)
        SetButtonState(btnForceComplete, bool_scanInProgress)
        SetButtonState(btnStart, Not bool_scanInProgress)
        SetButtonState(btnRemove, Not bool_scanInProgress)
        'SetButtonState(btnReconnect, Not bool_Connected)
    End Sub

    Private Sub resetScanParams()
        'Timing variables
        bool_scanInProgress = False
        bool_scanCrashed = False
        bool_waitingForScanToCatchUp = False
        bool_firstRunCompleted = False
        bool_Started = False
        bool_forceCompletion = False

        'GPIB variables
        bool_waitingForTrigger = False

    End Sub

    Private Sub btnForceComplete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForceComplete.Click
        SetButtonState(btnForceComplete, False)
        SetButtonState(btnAbort, False)
        bool_Started = True
        bool_forceCompletion = True
    End Sub

    Private Sub StartUpdateTimer()
        ' Create a timer with a two second interval.
        tmrUpdatePanels = New System.Timers.Timer(100)
        ' Hook up the Elapsed event for the timer. 
        AddHandler tmrUpdatePanels.Elapsed, AddressOf OnTimedEvent

        tmrUpdatePanels.AutoReset = True
        tmrUpdatePanels.Enabled = True

    End Sub

    ' The event handler for the Timer.Elapsed event. 
    Private Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        If frmAddJob.isLoaded() Then frmAddJob.setChannels(lst_Channels)
    End Sub

    Private Sub tmrUpdateAddJobPanels_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrUpdateAddJobPanels.Tick
        If frmAddJob.isLoaded() Then
            frmAddJob.setChannels(lst_Channels)


            For int_idx As Integer = 0 To lst_Channels.Count - 1
                If lst_Channels(int_idx) = 3 Then
                    Dim strPanTime As String = getTimeOnPanel(lst_Panels(int_idx))
                    frmAddJob.setChannelText(int_idx, strPanTime)
                Else
                    frmAddJob.setChannelText(int_idx, "")
                End If
            Next





        End If
    End Sub

    Private Sub btnReconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconnect.Click
        GpibDev = Nothing
        GpibDev = Connect()
        If GpibDev Is Nothing Then MessageBox.Show("Reconnection failed!" & vbCrLf & "Please ensure the multimeter at address " & CStr(int_KeithleyAddr) & " is physically connected and operational.")
    End Sub

    Private Sub btnDbg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Debug = New MainForm
        Debug.setControlParams(int_KeithleyAddr)
        Debug.Show()
    End Sub
End Class