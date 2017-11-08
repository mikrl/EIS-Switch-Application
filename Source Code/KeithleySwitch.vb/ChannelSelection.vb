Public Class ChannelSelection
    Private int_NumChannels As Integer = 16
    Private lst_Panels As New List(Of Panel) '(int_NumChannels)
    Private lst_Channels As New List(Of Integer)
    Private lst_SelectedChans As New List(Of Integer)
    Private int_boxLength As Integer = 100
    'Private test As TimeSpan = AddJob.ts_timeToCompletion
    Public strChannels = ""

    Private Sub getChannelsStatus()
        'Need to find some way of passing data between currently running job and
        'this form to update selectable channels, {0,1,2,3} == {free, selected, in use this job, in use now}
        For i As Integer = 0 To int_NumChannels - 1 Step 1
            lst_Channels.Add(0)
        Next
    End Sub

    Private Sub setChannelsStatus()
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

    Private Sub loadChannels()
        Dim int_Counter As Integer = 1
        getChannelsStatus()
        Dim pt_location As New Point
        For y As Integer = 1 To System.Math.Ceiling(System.Math.Sqrt(int_NumChannels))
            For x As Integer = 1 To System.Math.Ceiling(System.Math.Sqrt(int_NumChannels))
                Dim pt_thisPanel As New Point(20 + (x - 1) * (int_boxLength + 10), 20 + (y - 1) * (int_boxLength + 10))
                Dim lbl_ChanLabel As New Label
                Dim lbl_Availability As New Label
                Dim pnl_NewPanel As New Panel

                With pnl_NewPanel
                    .Name = "pnl_channel" & CStr(int_Counter)
                    .Size = New Point(int_boxLength, int_boxLength)
                    .Location = pt_thisPanel
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

                    pnl_NewPanel.Controls.Add(lbl_Availability)
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
                int_Counter += 1
                
                'Me.Size = New Point(gbx_Channels.Size.Width + 20, gbx_Channels.Size.Height + 250)
                pt_location = pt_thisPanel
            Next
        Next
        gbx_Channels.Size = New Point(pt_location.X + int_boxLength + 10, pt_location.Y + int_boxLength + 10)
        gbx_info.Size = New Point(gbx_Channels.Size.Width, 250)
        gbx_info.Location = New Point(gbx_Channels.Location.X, gbx_Channels.Location.Y + gbx_Channels.Size.Height)
        Me.Size = New Point(gbx_info.Location.X + gbx_info.Size.Width + 20, gbx_info.Location.Y + gbx_info.Size.Height + 40)
        setChannelsStatus()
        'gbx_Channels.Size = pt_location
    End Sub

    Private Sub ChannelSelection_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub ChannelSelection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadChannels()
        
    End Sub

    Private Sub pnl_NewPanel_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Throw New NotImplementedException
        'MessageBox.Show(sender.Name)
        'setChannelsStatus()
        If My.Computer.Keyboard.ShiftKeyDown Then
            For int_i As Integer = 0 To lst_Panels.Count - 1 Step 1
                ActivateChannel(lst_Panels(int_i))
                lst_Channels(int_i) = 1
                If lst_Panels(int_i).Name = sender.Name Then Exit For
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

                        Case Else
                            MessageBox.Show("Not implemented yet")
                    End Select
                    'lst_Panels(i).BackColor = Color.Green
                    Exit For
                End If
            Next
        End If
        UpdateSelectedChannels()
    End Sub

    Private Sub UpdateSelectedChannels()
        Dim str_selectedChans As String = ""
        For i As Integer = 0 To lst_Channels.Count - 1 Step 1
            Select Case lst_Channels(i)
                Case 0
                    If lst_SelectedChans.Contains(i + 1) Then
                        lst_SelectedChans.Remove(i + 1)
                    End If
                Case 1
                    If Not (lst_SelectedChans.Contains(i + 1)) Then
                        lst_SelectedChans.Add(i + 1)
                    End If
            End Select
        Next
        lst_SelectedChans.Sort()
        For j As Integer = 0 To lst_SelectedChans.Count - 1 Step 1
            str_selectedChans += CStr(lst_SelectedChans(j)) & ","
        Next
        If str_selectedChans <> "" Then
            txt_Selected.Text = str_selectedChans.Substring(0, str_selectedChans.Length - 1)
        Else
            txt_Selected.Text = ""
        End If
    End Sub

    Private Sub ActivateChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).BackColor = Color.Green
                Exit For
            End If
        Next
    End Sub

    Private Sub DeactivateChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).BackColor = System.Drawing.SystemColors.Control
                Exit For
            End If
        Next
    End Sub

    Private Sub CurrentChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).BackColor = Color.DodgerBlue
                Exit For
            End If
        Next
    End Sub

    Private Sub UpcomingChannel(ByVal sender As Object)
        For i As Integer = 0 To lst_Panels.Count - 1 Step 1
            If lst_Panels(i).Name = sender.Name Then
                lst_Panels(i).BackColor = Color.Yellow
                Exit For
            End If
        Next
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
        'Me.Dispose()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        strChannels = txt_Selected.Text
        Me.Close()
        'Me.Dispose()
    End Sub
End Class