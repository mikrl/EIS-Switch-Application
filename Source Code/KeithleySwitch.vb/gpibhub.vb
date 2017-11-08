Imports System.Timers

Public Class gpibhub
    Dim arr_boolDMMCon As Boolean()
    Dim arr_ovlDMM As PowerPacks.OvalShape()
    Dim tmrUpdatePanels As System.Timers.Timer

    Dim boolFormClosing As Boolean = False

    Dim frmDMM1 As MainUserForm
    Dim frmDMM2 As MainUserForm
    Dim frmDMM3 As MainUserForm


    Public Sub setBoolCons(ByVal intDMM As Integer, ByVal boolConnected As Boolean)
        arr_boolDMMCon(intDMM) = boolConnected
    End Sub

    Private Sub updateLEDColors()
        For int_idx As Integer = 0 To arr_boolDMMCon.Length - 1
            If arr_ovlDMM(int_idx).IsDisposed Then Continue For

            If arr_boolDMMCon(int_idx) Then
                setLEDColor(arr_ovlDMM(int_idx), Color.Chartreuse)
            Else
                setLEDColor(arr_ovlDMM(int_idx), Color.Red)
            End If
        Next
    End Sub

    Private Sub gpibhub_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        tmrUpdatePanels.Stop()
        Application.DoEvents()

    End Sub

    Private Sub gpibhub_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        arr_boolDMMCon = {False, False, False}
        arr_ovlDMM = {ovlDMM1Con, ovlDMM2Con, ovlDMM3Con}
        StartUpdateTimer()
    End Sub

    Private Sub txtGPIB1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGPIB1.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub txtGPIB2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGPIB2.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub txtGPIB3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGPIB3.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub tmrVisible_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVisible.Tick
        updateLEDColors()
        Me.Visible = Not (arr_boolDMMCon(0) And arr_boolDMMCon(1) And arr_boolDMMCon(2))
    End Sub

    Private Sub btnCon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCon1.Click
        If txtGPIB1.Text = "" Then Exit Sub
        If Not frmDMM1 Is Nothing Then
            If frmDMM1.isOpen() Then Exit Sub
        End If
        frmDMM1 = New MainUserForm
        frmDMM1.Text = "Temperature Box #1"
        frmDMM1.Location = New Point(Screen.PrimaryScreen.Bounds.Width * (0.0 / 3.0), 0)
        frmDMM1.setGPIBOptions(0, CInt(txtGPIB1.Text))
        frmDMM1.Show()
    End Sub


    Private Sub btnCon2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCon2.Click
        If Not frmDMM2 Is Nothing Then
            If txtGPIB2.Text = "" Or frmDMM2.isOpen() Then Exit Sub
        End If
        frmDMM2 = New MainUserForm
        frmDMM2.Text = "Temperature Box #2"
        frmDMM2.Location = New Point(Screen.PrimaryScreen.Bounds.Width * (1.0 / 3.0), 0)
        frmDMM2.setGPIBOptions(1, CInt(txtGPIB2.Text))
        frmDMM2.Show()
    End Sub

    Private Sub btnCon3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCon3.Click
        If Not frmDMM3 Is Nothing Then
            If txtGPIB3.Text = "" Or frmDMM3.isOpen() Then Exit Sub
        End If
        frmDMM3 = New MainUserForm
        frmDMM3.Text = "Temperature Box #3"
        frmDMM3.Location = New Point(Screen.PrimaryScreen.Bounds.Width * (2.0 / 3.0), 0)
        frmDMM3.setGPIBOptions(2, CInt(txtGPIB3.Text))
        frmDMM3.Show()
    End Sub

    Private Sub StartUpdateTimer()
        ' Create a timer with a two second interval.
        tmrUpdatePanels = New System.Timers.Timer(100)
        ' Hook up the Elapsed event for the timer. 
        AddHandler tmrUpdatePanels.Elapsed, AddressOf OnTimedEvent
        If Not boolFormClosing Then
            tmrUpdatePanels.AutoReset = True
            tmrUpdatePanels.Enabled = True
        End If
    End Sub

    ' The event handler for the Timer.Elapsed event. 
    Private Sub OnTimedEvent(ByVal source As Object, ByVal e As ElapsedEventArgs)
        If boolFormClosing Or Not tmrUpdatePanels.Enabled Then Exit Sub
        Dim bool_isActive As Boolean
        For int_idx = 0 To 2
            Select Case int_idx
                Case 0
                    bool_isActive = Not (frmDMM1 Is Nothing OrElse Not frmDMM1.isConnected())
                Case 1
                    bool_isActive = Not (frmDMM2 Is Nothing OrElse Not frmDMM2.isConnected())
                Case 2
                    bool_isActive = Not (frmDMM3 Is Nothing OrElse Not frmDMM3.isConnected())
            End Select
            arr_boolDMMCon(int_idx) = bool_isActive
        Next
        updateLEDColors()
    End Sub

    Private Delegate Sub setLEDColorDelegate(ByVal ovl As PowerPacks.OvalShape, ByVal clr As Color)

    Private Sub setLEDColor(ByVal ovl As PowerPacks.OvalShape, ByVal clr As Color)
        If Me.IsDisposed Then Exit Sub
        If Me.InvokeRequired Then
            Me.Invoke(New setLEDColorDelegate(AddressOf setLEDColor), New Object() {ovl, clr})
        Else
            ovl.BackColor = clr
        End If
    End Sub

End Class