Imports NationalInstruments
Imports NationalInstruments.NI4882
Imports System.Threading

Public Class MainForm

    'Private arrScanList = New Integer() {1, 2, 3, 4, 5, 6, 7, 8}
    Private GpibDev As Device
    Private int_ChanCount As Integer = 16
    Private int_KeithleyAddr As Integer
    Private int_CurrentChan As Integer
    Private int_CurrentReset As Integer
    Private bool_InScan As Boolean = False
    Public bool_isConnected As Boolean
    Public bool_isBusy As Boolean
    Private arr_PinList As Tuple(Of Integer, Integer)() = lstPins()
    Private bool_responseReceived As Boolean = False
    'Private bool_AbortScan = False
    Private trdEIS As Thread

    Public Sub setControlParams(ByVal addr As Integer)
        int_KeithleyAddr = addr
        bool_isConnected = True
    End Sub

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

    Private Sub MainForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If bool_isConnected Then
            Disconnect()
        End If

        Me.Dispose()
    End Sub

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        Dim test As Tuple(Of Integer, Integer)() = lstPins()
        'trdEIS = New Thread(AddressOf EISTest)
        int_CurrentChan = -1    'init to -1, this is the value corresponding to no connected channel
        'bool_isConnected = False
        bool_isBusy = False

        UpdateState()
        GpibDev = New Device(0, int_KeithleyAddr, 0)
        'txtCurrentChan.Text = "No multimeter connected"
        'UpdateTextBox(txtCurrentChan, "No multimeter connected")
        'MessageBox.Show(CStr(lstPins()))
    End Sub

    Private Sub UpdateState()

        Dim bool_EnableControl = bool_isConnected And Not (bool_isBusy)  'We want the controls to be enabled only if the multimeter is connected and not busy
        'btnOpenAll.Enabled = bool_EnableControl
        SetButtonState(btnOpenAll, bool_EnableControl)
        'MessageBox.Show("Is connected: " & CStr(bool_isConnected) & " Is busy: " & CStr(bool_isBusy) & " Is locked: " & CStr(bool_EnableControl))
        Dim myButtons = {btnChan1, btnChan2, btnChan3, btnChan4, _
                            btnChan5, btnChan6, btnChan7, btnChan8, _
                            btnChan9, btnChan10, btnChan11, btnChan12, _
                            btnChan13, btnChan14, btnChan15, btnChan16, _
                            btnDisconnect, btnRegister, btnTrigger, btnArmTrig, btnTestEIS}
        For Each btn In myButtons
            'btn.Enabled = bool_EnableControl
            SetButtonState(btn, bool_EnableControl)
        Next

    End Sub

    Private Delegate Sub SetButtonStateDelegate(ByVal btn As Button, ByVal enab As Boolean)

    Private Sub SetButtonState(ByVal btn As Button, ByVal enab As Boolean)
        If btn.InvokeRequired Then
            btn.Invoke(New SetButtonStateDelegate(AddressOf SetButtonState), New Object() {btn, enab})
        Else
            btn.Enabled = enab
        End If
    End Sub

    Private Delegate Sub UpdateTextBoxDelegate(ByVal txt As TextBox, ByVal str As String)

    Private Sub UpdateTextBox(ByVal txt As TextBox, ByVal str As String)
        If txt.InvokeRequired Then
            txt.Invoke(New UpdateTextBoxDelegate(AddressOf UpdateTextBox), New Object() {txt, str})
        Else
            txt.Text = str
        End If
    End Sub

    Private Sub Connect()

        'txtCurrentChan.Text = "Attempting connection."
        UpdateTextBox(txtCurrentChan, "Attempting connection.")
        int_KeithleyAddr = CInt(txtKeithleyAddr.Text)

        GpibDev = New Device(0, CByte(int_KeithleyAddr), 0)
        InitialiseKeithley()
        bool_isConnected = True
        UpdateState()
        'txtCurrentChan.Text = "Initialising..."
        UpdateTextBox(txtCurrentChan, "Initialising...")
        GpibDev.Write(":DISP:TEXT:DATA 'INITIALISING'")

    End Sub

    Private Sub Disconnect()
        GpibDev.Write(":DISP:TEXT:STAT OFF")
        GpibDev.Dispose()
        'txtCurrentChan.Text = "No multimeter connected"
        UpdateTextBox(txtCurrentChan, "No multimeter connected")
        bool_isConnected = False
        UpdateState()
    End Sub

    Private Sub btnOpenAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenAll.Click
        If int_CurrentChan = -1 Then Exit Sub
        'GpibDev.Write(":DISP:TEXT:STAT ON")
        OpenAllRelays()
        int_CurrentChan = -1
        'txtCurrentChan.Text = "Keithley connected at address " & CStr(int_KeithleyAddr) & "."
        UpdateTextBox(txtCurrentChan, "Keithley connected at address " & CStr(int_KeithleyAddr) & ".")
        GpibDev.Write(":DISP:TEXT:DATA 'CONNECTED'")
    End Sub

    Private Sub OpenAllRelays()
        UpdateTextBox(txtDebug, "")
        txtDebug.Text = ""
        'If int_CurrentChan = -1 Then Exit Sub
        bool_isBusy = True
        UpdateState()

        Dim str_ResetPins As String = ""
        Dim int_pinNo As Integer = 0

        For Each Pins In arr_PinList
            If int_pinNo < int_ChanCount Then
                str_ResetPins = str_ResetPins & CStr(Pins.Item2) & ","
            Else
                GoTo PinCountReached
            End If
            int_pinNo += 1
        Next
PinCountReached:
        Dim str_CommandString As String = ":ROUT:MULT:CLOS (@" & str_ResetPins.Remove(str_ResetPins.Length - 1) & ")"
        GpibDev.Write(str_CommandString)
        'txtCurrentChan.Text = "Keithley connected at address " & CStr(int_KeithleyAddr) & "."
        'GpibDev.Write(":DISP:TEXT:DATA 'CONNECTED'")
        'tmrPinFlip.Enabled = True
        Threading.Thread.Sleep(1000)
        GpibDev.Write(":ROUT:OPEN:ALL")
        bool_isBusy = False
        UpdateState()
        'tmrPinFlip.Start()
    End Sub

    Private Sub InitialiseKeithley()
        bool_isBusy = True
        UpdateState()
        GpibDev.Write("*RST")
        'GpibDev.Write(":DISP:TEXT:STAT ON")
        'tmrInit.Enabled = True
        tmrInit.Start()

    End Sub

    Private Sub KeithleyChannel()
        Dim str_display As String = ":DISP:TEXT:DATA 'CHANNEL " & CStr(int_CurrentChan) & "'"
        GpibDev.Write(":DISP:STAT:TEXT ON")
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            Connect()
        Catch ex As Exception
            MessageBox.Show("No Keithley found at this address.")
            'txtCurrentChan.Text = "Connection failure."
            UpdateTextBox(txtCurrentChan, "Connection failure.")
            bool_isConnected = False
            UpdateState()
            Exit Sub
        End Try

        OpenAllRelays()
        'txtCurrentChan.Text = "Keithley connected at address " & CStr(int_KeithleyAddr) & "."
        UpdateTextBox(txtCurrentChan, "Keithley connected at address " & CStr(int_KeithleyAddr) & ".")
        'txtStatusBytes.Text = "Ready to scan"
        Threading.Thread.Sleep(2000)
        GpibDev.Write(":DISP:TEXT:DATA 'DEBUG MODE'")

    End Sub

    Private Sub txtKeithleyAddr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKeithleyAddr.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If

    End Sub

    Private Sub tmrInit_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrInit.Tick
        'txtCurrentChan.Text = "Keithley connected at address " & CStr(int_KeithleyAddr) & "."
        UpdateTextBox(txtCurrentChan, "Keithley connected at address " & CStr(int_KeithleyAddr) & ".")
        bool_isBusy = False
        UpdateState()
        tmrInit.Enabled = False
    End Sub

    Private Sub SetChannel(ByVal int_ChannelNum As Integer)

        If int_CurrentChan = int_ChannelNum Then Exit Sub
        Dim int_SetPin As Integer = arr_PinList(int_ChannelNum - 1).Item1
        Dim int_ResetPin As Integer = arr_PinList(int_ChannelNum - 1).Item2
        If int_CurrentChan <> -1 Then
            'txtDebug.Text = txtDebug.Text & "(Re" & int_CurrentChan & ")"
            UpdateTextBox(txtDebug, txtDebug.Text & "(Re" & int_CurrentChan & ")")
            ClosePin(int_CurrentReset)
            Threading.Thread.Sleep(250)
        End If

        ClosePin(int_SetPin)
        UpdateTextBox(txtDebug, txtDebug.Text & "(Se" & int_ChannelNum & ")")
        '        txtDebug.Text = txtDebug.Text & "(Se" & int_ChannelNum & ")"
        Threading.Thread.Sleep(250)
        GpibDev.Write(":ROUT:OPEN:ALL")
        bool_isBusy = False
        UpdateState()
        int_CurrentChan = int_ChannelNum
        int_CurrentReset = int_ResetPin
        'txtCurrentChan.Text = "Keithley connected at address " & CStr(int_KeithleyAddr) & ". FRA Channel " & CStr(int_CurrentChan)
        UpdateTextBox(txtCurrentChan, "Keithley connected at address " & CStr(int_KeithleyAddr) & ". FRA Channel " & CStr(int_CurrentChan))
        GpibDev.Write(":DISP:TEXT:DATA 'CHANNEL " & CStr(int_CurrentChan) & "'")
        'GpibDev.Write(":DISP:TEXT:STAT ON")

    End Sub

    Private Sub ClosePin(ByVal int_PinToClose As Integer)
        bool_isBusy = True
        UpdateState()
        UpdateTextBox(txtCurrentChan, "Flipping some pins...")
        'txtCurrentChan.Text = "Flipping some pins..."
        Dim str_CommandString As String = ":ROUT:MULT:CLOS (@" & CStr(int_PinToClose) & ")"
        GpibDev.Write(str_CommandString)
        'tmrPinFlip.Enabled = True
        'tmrPinFlip.Start()
    End Sub

    Private Sub tmrPinFlip_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPinFlip.Tick
        GpibDev.Write(":ROUT:OPEN:ALL")
        bool_isBusy = False
        UpdateState()
        tmrPinFlip.Enabled = False
        tmrPinFlip.Dispose()
    End Sub

    Private Sub btnChan1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan1.Click
        SetChannel(1)
    End Sub

    Private Sub btnChan2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan2.Click
        SetChannel(2)
    End Sub

    Private Sub btnChan3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan3.Click
        SetChannel(3)
    End Sub

    Private Sub btnChan4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan4.Click
        SetChannel(4)
    End Sub

    Private Sub btnChan5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan5.Click
        SetChannel(5)
    End Sub

    Private Sub btnChan6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan6.Click
        SetChannel(6)
    End Sub

    Private Sub btnChan7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan7.Click
        SetChannel(7)
    End Sub

    Private Sub btnChan8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan8.Click
        SetChannel(8)
    End Sub

    Private Sub btnChan9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan9.Click
        SetChannel(9)
    End Sub

    Private Sub btnChan10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan10.Click
        SetChannel(10)
    End Sub

    Private Sub btnChan11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan11.Click
        SetChannel(11)
    End Sub

    Private Sub btnChan12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan12.Click
        SetChannel(12)
    End Sub

    Private Sub btnChan13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan13.Click
        SetChannel(13)
    End Sub

    Private Sub btnChan14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan14.Click
        SetChannel(14)
    End Sub

    Private Sub btnChan15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan15.Click
        SetChannel(15)
    End Sub

    Private Sub btnChan16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChan16.Click
        SetChannel(16)
    End Sub
    Private Sub btnDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisconnect.Click
        Disconnect()
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

    Private Sub btnRegister_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegister.Click
        bool_isBusy = True
        UpdateState()
        Dim strStatus As String = getOperRegister()
        'txtStatusBytes.Text = strStatus
        UpdateTextBox(txtStatusBytes, strStatus)
        UpdateTextBox(txtMeas, strStatus(4))
        UpdateTextBox(txtTrig, strStatus(5))
        UpdateTextBox(txtFilt, strStatus(8))
        UpdateTextBox(txtIdle, strStatus(10))
        'txtMeas.Text = strStatus(4)
        'txtTrig.Text = strStatus(5)
        'txtFilt.Text = strStatus(8)
        'txtIdle.Text = strStatus(10)
        bool_isBusy = False
        UpdateState()
    End Sub

    Private Function getOperRegister() As String
        GpibDev.Write("STAT:OPER:COND?")
        Dim strStatus As String = strDec2strBin(GpibDev.ReadString())
        Return strStatus
    End Function

    Private Sub setUpTrigger()
        GpibDev.Write("ABOR")
        GpibDev.Write("TRIG:SOUR EXT")
        GpibDev.Write("TRIG:DEL 1")
        GpibDev.Write("SAMP:COUN 1")
        GpibDev.Write("TRIG:COUN 1")
        'GpibDev.Write(":DISP:TEXT:STAT OFF")
        GpibDev.Write("INIT:CONT OFF")
        GpibDev.Write("INIT")
        Threading.Thread.Sleep(750)
    End Sub

    Private Sub btnTrigger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrigger.Click
        bool_isBusy = True
        UpdateState()
        setUpTrigger()

        'GpibDev.Write("")
        'GpibDev.Write("")
        'GpibDev.Write("")
        bool_isBusy = False
        UpdateState()
    End Sub

    Private Sub tmrDMMisIdle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrDMMisIdle.Tick
        If getOperRegister()(10) = "1" Then
            tmrDMMisIdle.Enabled = False
            'scanNextChannel()
            MessageBox.Show("Trigger received")
            bool_InScan = False
        End If
    End Sub

    Private Sub btnArmTrig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArmTrig.Click
        tmrDMMisIdle.Start()
        'tmrDMMisIdle.Enabled = True
    End Sub

    Private Sub EISTest()
        OpenAllRelays()
        bool_isBusy = True
        UpdateState()
        Threading.Thread.Sleep(500)
        Dim lstLoopTimes As New List(Of Tuple(Of Integer, TimeSpan))
        Dim dteStartTime As Date
        Dim dteEndTime As Date
        Dim tspElapsed As TimeSpan
        Dim bool_Started = False

        setUpTrigger()
        Do While Not (bool_Started)
            If getOperRegister()(10) = "1" Then
                'MessageBox.Show("Trigger received")
                bool_Started = True
                UpdateTextBox(txtDbgTrig, "(IN)")
            End If
            Threading.Thread.Sleep(50)
        Loop


        'txtChannelsScanned.Text = ""
        UpdateTextBox(txtChannelsScanned, "")
        Dim arrScanList = New Integer() {1, 2, 3, 4, 5, 6} ', 7, 8}
        For Each channel In arrScanList
            dteStartTime = Now
            bool_InScan = True

            UpdateTextBox(txtCurrentChan, "Scanning channel " & CStr(channel))

            SetChannel(channel)
            Application.DoEvents()
            Threading.Thread.Sleep(1000)

            setUpTrigger()
            Do While bool_InScan
                'Application.DoEvents()
                If getOperRegister()(10) = "1" Then
                    bool_InScan = False
                    UpdateTextBox(txtDbgTrig, txtDbgTrig.Text & "(Ch" & CStr(channel) & "d)")
                End If
                Threading.Thread.Sleep(50)
            Loop

            dteEndTime = Now
            tspElapsed = dteEndTime - dteStartTime

            Dim tupLoopTime = Tuple.Create(channel, tspElapsed)
            lstLoopTimes.Add(tupLoopTime)
            UpdateTextBox(txtChannelsScanned, txtChannelsScanned.Text & CStr(channel))
            'txtChannelsScanned.Text = txtChannelsScanned.Text & CStr(channel)
            Application.DoEvents()
        Next
        OpenAllRelays()
        bool_isBusy = False
        UpdateState()
        'My.Computer.FileSystem.WriteAllText("C:\EIS DATA\Michael Lynch\Scan timing\run1.txt", CStr(lstLoopTimes), True)
        'txtChannelsScanned.Text = ""
    End Sub

    Private Sub btnTestEIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestEIS.Click
        Me.trdEIS = New Thread(New ThreadStart(AddressOf Me.EISTest))
        Me.trdEIS.Start()
    End Sub

    Private Sub btnAbort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbort.Click
        If trdEIS.IsAlive Then
            trdEIS.Abort()
            OpenAllRelays()
            bool_isBusy = False
            UpdateState()
        End If
        'bool_AbortScan = True

    End Sub
End Class



