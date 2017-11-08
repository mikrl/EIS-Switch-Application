<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnOpenAll = New System.Windows.Forms.Button()
        Me.txtCurrentChan = New System.Windows.Forms.TextBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.txtKeithleyAddr = New System.Windows.Forms.TextBox()
        Me.lblKeithley = New System.Windows.Forms.Label()
        Me.tmrInit = New System.Windows.Forms.Timer(Me.components)
        Me.btnChan1 = New System.Windows.Forms.Button()
        Me.btnChan2 = New System.Windows.Forms.Button()
        Me.btnChan3 = New System.Windows.Forms.Button()
        Me.btnChan4 = New System.Windows.Forms.Button()
        Me.btnChan5 = New System.Windows.Forms.Button()
        Me.btnChan6 = New System.Windows.Forms.Button()
        Me.btnChan7 = New System.Windows.Forms.Button()
        Me.btnChan8 = New System.Windows.Forms.Button()
        Me.tmrPinFlip = New System.Windows.Forms.Timer(Me.components)
        Me.txtStatusBytes = New System.Windows.Forms.TextBox()
        Me.btnDisconnect = New System.Windows.Forms.Button()
        Me.btnRegister = New System.Windows.Forms.Button()
        Me.btnTrigger = New System.Windows.Forms.Button()
        Me.lblStatBin = New System.Windows.Forms.Label()
        Me.txtMeas = New System.Windows.Forms.TextBox()
        Me.txtTrig = New System.Windows.Forms.TextBox()
        Me.txtFilt = New System.Windows.Forms.TextBox()
        Me.txtIdle = New System.Windows.Forms.TextBox()
        Me.lblMeas = New System.Windows.Forms.Label()
        Me.lblTrig = New System.Windows.Forms.Label()
        Me.lblFilt = New System.Windows.Forms.Label()
        Me.lblIdle = New System.Windows.Forms.Label()
        Me.tmrDMMisIdle = New System.Windows.Forms.Timer(Me.components)
        Me.btnArmTrig = New System.Windows.Forms.Button()
        Me.btnTestEIS = New System.Windows.Forms.Button()
        Me.lblChannelsCompleted = New System.Windows.Forms.Label()
        Me.txtChannelsScanned = New System.Windows.Forms.TextBox()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.txtDebug = New System.Windows.Forms.TextBox()
        Me.lbldbg = New System.Windows.Forms.Label()
        Me.lbldbg2 = New System.Windows.Forms.Label()
        Me.txtDbgTrig = New System.Windows.Forms.TextBox()
        Me.btnChan12 = New System.Windows.Forms.Button()
        Me.btnChan16 = New System.Windows.Forms.Button()
        Me.btnChan15 = New System.Windows.Forms.Button()
        Me.btnChan14 = New System.Windows.Forms.Button()
        Me.btnChan13 = New System.Windows.Forms.Button()
        Me.btnChan11 = New System.Windows.Forms.Button()
        Me.btnChan10 = New System.Windows.Forms.Button()
        Me.btnChan9 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnOpenAll
        '
        Me.btnOpenAll.Location = New System.Drawing.Point(239, 222)
        Me.btnOpenAll.Name = "btnOpenAll"
        Me.btnOpenAll.Size = New System.Drawing.Size(150, 23)
        Me.btnOpenAll.TabIndex = 2
        Me.btnOpenAll.Text = "Open All Relays"
        Me.btnOpenAll.UseVisualStyleBackColor = True
        '
        'txtCurrentChan
        '
        Me.txtCurrentChan.Location = New System.Drawing.Point(14, 389)
        Me.txtCurrentChan.Name = "txtCurrentChan"
        Me.txtCurrentChan.ReadOnly = True
        Me.txtCurrentChan.Size = New System.Drawing.Size(353, 20)
        Me.txtCurrentChan.TabIndex = 4
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(215, 12)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(153, 23)
        Me.btnConnect.TabIndex = 6
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtKeithleyAddr
        '
        Me.txtKeithleyAddr.Location = New System.Drawing.Point(106, 30)
        Me.txtKeithleyAddr.Name = "txtKeithleyAddr"
        Me.txtKeithleyAddr.Size = New System.Drawing.Size(100, 20)
        Me.txtKeithleyAddr.TabIndex = 8
        '
        'lblKeithley
        '
        Me.lblKeithley.AutoSize = True
        Me.lblKeithley.Location = New System.Drawing.Point(12, 33)
        Me.lblKeithley.Name = "lblKeithley"
        Me.lblKeithley.Size = New System.Drawing.Size(88, 13)
        Me.lblKeithley.TabIndex = 9
        Me.lblKeithley.Text = "Keithley Address:"
        '
        'tmrInit
        '
        Me.tmrInit.Interval = 1000
        '
        'btnChan1
        '
        Me.btnChan1.Location = New System.Drawing.Point(42, 71)
        Me.btnChan1.Name = "btnChan1"
        Me.btnChan1.Size = New System.Drawing.Size(75, 23)
        Me.btnChan1.TabIndex = 10
        Me.btnChan1.Text = "Channel 1"
        Me.btnChan1.UseVisualStyleBackColor = True
        '
        'btnChan2
        '
        Me.btnChan2.Location = New System.Drawing.Point(122, 71)
        Me.btnChan2.Name = "btnChan2"
        Me.btnChan2.Size = New System.Drawing.Size(75, 23)
        Me.btnChan2.TabIndex = 11
        Me.btnChan2.Text = "Channel 2"
        Me.btnChan2.UseVisualStyleBackColor = True
        '
        'btnChan3
        '
        Me.btnChan3.Location = New System.Drawing.Point(202, 71)
        Me.btnChan3.Name = "btnChan3"
        Me.btnChan3.Size = New System.Drawing.Size(75, 23)
        Me.btnChan3.TabIndex = 12
        Me.btnChan3.Text = "Channel 3"
        Me.btnChan3.UseVisualStyleBackColor = True
        '
        'btnChan4
        '
        Me.btnChan4.Location = New System.Drawing.Point(282, 71)
        Me.btnChan4.Name = "btnChan4"
        Me.btnChan4.Size = New System.Drawing.Size(75, 23)
        Me.btnChan4.TabIndex = 13
        Me.btnChan4.Text = "Channel 4"
        Me.btnChan4.UseVisualStyleBackColor = True
        '
        'btnChan5
        '
        Me.btnChan5.Location = New System.Drawing.Point(42, 101)
        Me.btnChan5.Name = "btnChan5"
        Me.btnChan5.Size = New System.Drawing.Size(75, 23)
        Me.btnChan5.TabIndex = 14
        Me.btnChan5.Text = "Channel 5"
        Me.btnChan5.UseVisualStyleBackColor = True
        '
        'btnChan6
        '
        Me.btnChan6.Location = New System.Drawing.Point(122, 101)
        Me.btnChan6.Name = "btnChan6"
        Me.btnChan6.Size = New System.Drawing.Size(75, 23)
        Me.btnChan6.TabIndex = 15
        Me.btnChan6.Text = "Channel 6"
        Me.btnChan6.UseVisualStyleBackColor = True
        '
        'btnChan7
        '
        Me.btnChan7.Location = New System.Drawing.Point(202, 101)
        Me.btnChan7.Name = "btnChan7"
        Me.btnChan7.Size = New System.Drawing.Size(75, 23)
        Me.btnChan7.TabIndex = 16
        Me.btnChan7.Text = "Channel 7"
        Me.btnChan7.UseVisualStyleBackColor = True
        '
        'btnChan8
        '
        Me.btnChan8.Location = New System.Drawing.Point(282, 101)
        Me.btnChan8.Name = "btnChan8"
        Me.btnChan8.Size = New System.Drawing.Size(75, 23)
        Me.btnChan8.TabIndex = 17
        Me.btnChan8.Text = "Channel 8"
        Me.btnChan8.UseVisualStyleBackColor = True
        '
        'tmrPinFlip
        '
        Me.tmrPinFlip.Interval = 1000
        '
        'txtStatusBytes
        '
        Me.txtStatusBytes.Location = New System.Drawing.Point(156, 266)
        Me.txtStatusBytes.Name = "txtStatusBytes"
        Me.txtStatusBytes.ReadOnly = True
        Me.txtStatusBytes.Size = New System.Drawing.Size(123, 20)
        Me.txtStatusBytes.TabIndex = 19
        '
        'btnDisconnect
        '
        Me.btnDisconnect.Location = New System.Drawing.Point(215, 42)
        Me.btnDisconnect.Name = "btnDisconnect"
        Me.btnDisconnect.Size = New System.Drawing.Size(153, 23)
        Me.btnDisconnect.TabIndex = 6
        Me.btnDisconnect.Text = "Disconnect"
        Me.btnDisconnect.UseVisualStyleBackColor = True
        '
        'btnRegister
        '
        Me.btnRegister.Location = New System.Drawing.Point(14, 266)
        Me.btnRegister.Name = "btnRegister"
        Me.btnRegister.Size = New System.Drawing.Size(136, 23)
        Me.btnRegister.TabIndex = 20
        Me.btnRegister.Text = "Read Operation Register"
        Me.btnRegister.UseVisualStyleBackColor = True
        '
        'btnTrigger
        '
        Me.btnTrigger.Location = New System.Drawing.Point(14, 295)
        Me.btnTrigger.Name = "btnTrigger"
        Me.btnTrigger.Size = New System.Drawing.Size(122, 23)
        Me.btnTrigger.TabIndex = 21
        Me.btnTrigger.Text = "Start Trigger Model"
        Me.btnTrigger.UseVisualStyleBackColor = True
        '
        'lblStatBin
        '
        Me.lblStatBin.AutoSize = True
        Me.lblStatBin.Location = New System.Drawing.Point(158, 250)
        Me.lblStatBin.Name = "lblStatBin"
        Me.lblStatBin.Size = New System.Drawing.Size(75, 13)
        Me.lblStatBin.TabIndex = 24
        Me.lblStatBin.Text = "Status (Binary)"
        '
        'txtMeas
        '
        Me.txtMeas.Location = New System.Drawing.Point(63, 363)
        Me.txtMeas.Name = "txtMeas"
        Me.txtMeas.ReadOnly = True
        Me.txtMeas.Size = New System.Drawing.Size(36, 20)
        Me.txtMeas.TabIndex = 25
        '
        'txtTrig
        '
        Me.txtTrig.Location = New System.Drawing.Point(147, 363)
        Me.txtTrig.Name = "txtTrig"
        Me.txtTrig.ReadOnly = True
        Me.txtTrig.Size = New System.Drawing.Size(36, 20)
        Me.txtTrig.TabIndex = 26
        '
        'txtFilt
        '
        Me.txtFilt.Location = New System.Drawing.Point(236, 363)
        Me.txtFilt.Name = "txtFilt"
        Me.txtFilt.ReadOnly = True
        Me.txtFilt.Size = New System.Drawing.Size(36, 20)
        Me.txtFilt.TabIndex = 27
        '
        'txtIdle
        '
        Me.txtIdle.Location = New System.Drawing.Point(320, 363)
        Me.txtIdle.Name = "txtIdle"
        Me.txtIdle.ReadOnly = True
        Me.txtIdle.Size = New System.Drawing.Size(36, 20)
        Me.txtIdle.TabIndex = 28
        '
        'lblMeas
        '
        Me.lblMeas.AutoSize = True
        Me.lblMeas.Location = New System.Drawing.Point(20, 366)
        Me.lblMeas.Name = "lblMeas"
        Me.lblMeas.Size = New System.Drawing.Size(40, 13)
        Me.lblMeas.TabIndex = 29
        Me.lblMeas.Text = "MEAS:"
        '
        'lblTrig
        '
        Me.lblTrig.AutoSize = True
        Me.lblTrig.Location = New System.Drawing.Point(105, 366)
        Me.lblTrig.Name = "lblTrig"
        Me.lblTrig.Size = New System.Drawing.Size(36, 13)
        Me.lblTrig.TabIndex = 30
        Me.lblTrig.Text = "TRIG:"
        '
        'lblFilt
        '
        Me.lblFilt.AutoSize = True
        Me.lblFilt.Location = New System.Drawing.Point(198, 366)
        Me.lblFilt.Name = "lblFilt"
        Me.lblFilt.Size = New System.Drawing.Size(32, 13)
        Me.lblFilt.TabIndex = 31
        Me.lblFilt.Text = "FILT:"
        '
        'lblIdle
        '
        Me.lblIdle.AutoSize = True
        Me.lblIdle.Location = New System.Drawing.Point(286, 366)
        Me.lblIdle.Name = "lblIdle"
        Me.lblIdle.Size = New System.Drawing.Size(34, 13)
        Me.lblIdle.TabIndex = 32
        Me.lblIdle.Text = "IDLE:"
        '
        'tmrDMMisIdle
        '
        '
        'btnArmTrig
        '
        Me.btnArmTrig.Location = New System.Drawing.Point(147, 295)
        Me.btnArmTrig.Name = "btnArmTrig"
        Me.btnArmTrig.Size = New System.Drawing.Size(122, 23)
        Me.btnArmTrig.TabIndex = 33
        Me.btnArmTrig.Text = "Arm Trigger Detection"
        Me.btnArmTrig.UseVisualStyleBackColor = True
        '
        'btnTestEIS
        '
        Me.btnTestEIS.Location = New System.Drawing.Point(17, 335)
        Me.btnTestEIS.Name = "btnTestEIS"
        Me.btnTestEIS.Size = New System.Drawing.Size(133, 23)
        Me.btnTestEIS.TabIndex = 34
        Me.btnTestEIS.Text = "Test EIS Switching"
        Me.btnTestEIS.UseVisualStyleBackColor = True
        '
        'lblChannelsCompleted
        '
        Me.lblChannelsCompleted.AutoSize = True
        Me.lblChannelsCompleted.Location = New System.Drawing.Point(153, 340)
        Me.lblChannelsCompleted.Name = "lblChannelsCompleted"
        Me.lblChannelsCompleted.Size = New System.Drawing.Size(98, 13)
        Me.lblChannelsCompleted.TabIndex = 35
        Me.lblChannelsCompleted.Text = "Channels scanned:"
        '
        'txtChannelsScanned
        '
        Me.txtChannelsScanned.Location = New System.Drawing.Point(256, 337)
        Me.txtChannelsScanned.Name = "txtChannelsScanned"
        Me.txtChannelsScanned.ReadOnly = True
        Me.txtChannelsScanned.Size = New System.Drawing.Size(118, 20)
        Me.txtChannelsScanned.TabIndex = 36
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(295, 308)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(75, 23)
        Me.btnAbort.TabIndex = 37
        Me.btnAbort.Text = "Abort Scan"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'txtDebug
        '
        Me.txtDebug.Location = New System.Drawing.Point(97, 415)
        Me.txtDebug.Name = "txtDebug"
        Me.txtDebug.ReadOnly = True
        Me.txtDebug.Size = New System.Drawing.Size(273, 20)
        Me.txtDebug.TabIndex = 38
        '
        'lbldbg
        '
        Me.lbldbg.AutoSize = True
        Me.lbldbg.Location = New System.Drawing.Point(22, 418)
        Me.lbldbg.Name = "lbldbg"
        Me.lbldbg.Size = New System.Drawing.Size(69, 13)
        Me.lbldbg.TabIndex = 39
        Me.lbldbg.Text = "Debug relays"
        '
        'lbldbg2
        '
        Me.lbldbg2.AutoSize = True
        Me.lbldbg2.Location = New System.Drawing.Point(15, 443)
        Me.lbldbg2.Name = "lbldbg2"
        Me.lbldbg2.Size = New System.Drawing.Size(76, 13)
        Me.lbldbg2.TabIndex = 40
        Me.lbldbg2.Text = "Debug triggers"
        '
        'txtDbgTrig
        '
        Me.txtDbgTrig.Location = New System.Drawing.Point(97, 440)
        Me.txtDbgTrig.Name = "txtDbgTrig"
        Me.txtDbgTrig.ReadOnly = True
        Me.txtDbgTrig.Size = New System.Drawing.Size(273, 20)
        Me.txtDbgTrig.TabIndex = 41
        '
        'btnChan12
        '
        Me.btnChan12.Location = New System.Drawing.Point(281, 130)
        Me.btnChan12.Name = "btnChan12"
        Me.btnChan12.Size = New System.Drawing.Size(75, 23)
        Me.btnChan12.TabIndex = 42
        Me.btnChan12.Text = "Channel 12"
        Me.btnChan12.UseVisualStyleBackColor = True
        '
        'btnChan16
        '
        Me.btnChan16.Location = New System.Drawing.Point(281, 159)
        Me.btnChan16.Name = "btnChan16"
        Me.btnChan16.Size = New System.Drawing.Size(75, 23)
        Me.btnChan16.TabIndex = 43
        Me.btnChan16.Text = "Channel 16"
        Me.btnChan16.UseVisualStyleBackColor = True
        '
        'btnChan15
        '
        Me.btnChan15.Location = New System.Drawing.Point(204, 159)
        Me.btnChan15.Name = "btnChan15"
        Me.btnChan15.Size = New System.Drawing.Size(75, 23)
        Me.btnChan15.TabIndex = 44
        Me.btnChan15.Text = "Channel 15"
        Me.btnChan15.UseVisualStyleBackColor = True
        '
        'btnChan14
        '
        Me.btnChan14.Location = New System.Drawing.Point(123, 159)
        Me.btnChan14.Name = "btnChan14"
        Me.btnChan14.Size = New System.Drawing.Size(75, 23)
        Me.btnChan14.TabIndex = 45
        Me.btnChan14.Text = "Channel 14"
        Me.btnChan14.UseVisualStyleBackColor = True
        '
        'btnChan13
        '
        Me.btnChan13.Location = New System.Drawing.Point(42, 159)
        Me.btnChan13.Name = "btnChan13"
        Me.btnChan13.Size = New System.Drawing.Size(75, 23)
        Me.btnChan13.TabIndex = 46
        Me.btnChan13.Text = "Channel 13"
        Me.btnChan13.UseVisualStyleBackColor = True
        '
        'btnChan11
        '
        Me.btnChan11.Location = New System.Drawing.Point(203, 130)
        Me.btnChan11.Name = "btnChan11"
        Me.btnChan11.Size = New System.Drawing.Size(75, 23)
        Me.btnChan11.TabIndex = 47
        Me.btnChan11.Text = "Channel 11"
        Me.btnChan11.UseVisualStyleBackColor = True
        '
        'btnChan10
        '
        Me.btnChan10.Location = New System.Drawing.Point(122, 130)
        Me.btnChan10.Name = "btnChan10"
        Me.btnChan10.Size = New System.Drawing.Size(75, 23)
        Me.btnChan10.TabIndex = 48
        Me.btnChan10.Text = "Channel 10"
        Me.btnChan10.UseVisualStyleBackColor = True
        '
        'btnChan9
        '
        Me.btnChan9.Location = New System.Drawing.Point(42, 130)
        Me.btnChan9.Name = "btnChan9"
        Me.btnChan9.Size = New System.Drawing.Size(75, 23)
        Me.btnChan9.TabIndex = 49
        Me.btnChan9.Text = "Channel 9"
        Me.btnChan9.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(401, 469)
        Me.Controls.Add(Me.btnChan9)
        Me.Controls.Add(Me.btnChan10)
        Me.Controls.Add(Me.btnChan11)
        Me.Controls.Add(Me.btnChan13)
        Me.Controls.Add(Me.btnChan14)
        Me.Controls.Add(Me.btnChan15)
        Me.Controls.Add(Me.btnChan16)
        Me.Controls.Add(Me.btnChan12)
        Me.Controls.Add(Me.txtDbgTrig)
        Me.Controls.Add(Me.lbldbg2)
        Me.Controls.Add(Me.lbldbg)
        Me.Controls.Add(Me.txtDebug)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.txtChannelsScanned)
        Me.Controls.Add(Me.lblChannelsCompleted)
        Me.Controls.Add(Me.btnTestEIS)
        Me.Controls.Add(Me.btnArmTrig)
        Me.Controls.Add(Me.lblIdle)
        Me.Controls.Add(Me.lblFilt)
        Me.Controls.Add(Me.lblTrig)
        Me.Controls.Add(Me.lblMeas)
        Me.Controls.Add(Me.txtIdle)
        Me.Controls.Add(Me.txtFilt)
        Me.Controls.Add(Me.txtTrig)
        Me.Controls.Add(Me.txtMeas)
        Me.Controls.Add(Me.lblStatBin)
        Me.Controls.Add(Me.btnTrigger)
        Me.Controls.Add(Me.btnRegister)
        Me.Controls.Add(Me.txtStatusBytes)
        Me.Controls.Add(Me.btnChan8)
        Me.Controls.Add(Me.btnChan7)
        Me.Controls.Add(Me.btnChan6)
        Me.Controls.Add(Me.btnChan5)
        Me.Controls.Add(Me.btnChan4)
        Me.Controls.Add(Me.btnChan3)
        Me.Controls.Add(Me.btnChan2)
        Me.Controls.Add(Me.btnChan1)
        Me.Controls.Add(Me.lblKeithley)
        Me.Controls.Add(Me.txtKeithleyAddr)
        Me.Controls.Add(Me.btnDisconnect)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtCurrentChan)
        Me.Controls.Add(Me.btnOpenAll)
        Me.Name = "MainForm"
        Me.Text = "Keithley 7705"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOpenAll As System.Windows.Forms.Button
    Friend WithEvents txtCurrentChan As System.Windows.Forms.TextBox
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents txtKeithleyAddr As System.Windows.Forms.TextBox
    Friend WithEvents lblKeithley As System.Windows.Forms.Label
    Friend WithEvents tmrInit As System.Windows.Forms.Timer
    Friend WithEvents btnChan1 As System.Windows.Forms.Button
    Friend WithEvents btnChan2 As System.Windows.Forms.Button
    Friend WithEvents btnChan3 As System.Windows.Forms.Button
    Friend WithEvents btnChan4 As System.Windows.Forms.Button
    Friend WithEvents btnChan5 As System.Windows.Forms.Button
    Friend WithEvents btnChan6 As System.Windows.Forms.Button
    Friend WithEvents btnChan7 As System.Windows.Forms.Button
    Friend WithEvents btnChan8 As System.Windows.Forms.Button
    Friend WithEvents tmrPinFlip As System.Windows.Forms.Timer
    Friend WithEvents txtStatusBytes As System.Windows.Forms.TextBox
    Friend WithEvents btnDisconnect As System.Windows.Forms.Button
    Friend WithEvents btnRegister As System.Windows.Forms.Button
    Friend WithEvents btnTrigger As System.Windows.Forms.Button
    Friend WithEvents lblStatBin As System.Windows.Forms.Label
    Friend WithEvents txtMeas As System.Windows.Forms.TextBox
    Friend WithEvents txtTrig As System.Windows.Forms.TextBox
    Friend WithEvents txtFilt As System.Windows.Forms.TextBox
    Friend WithEvents txtIdle As System.Windows.Forms.TextBox
    Friend WithEvents lblMeas As System.Windows.Forms.Label
    Friend WithEvents lblTrig As System.Windows.Forms.Label
    Friend WithEvents lblFilt As System.Windows.Forms.Label
    Friend WithEvents lblIdle As System.Windows.Forms.Label
    Friend WithEvents tmrDMMisIdle As System.Windows.Forms.Timer
    Friend WithEvents btnArmTrig As System.Windows.Forms.Button
    Friend WithEvents btnTestEIS As System.Windows.Forms.Button
    Friend WithEvents lblChannelsCompleted As System.Windows.Forms.Label
    Friend WithEvents txtChannelsScanned As System.Windows.Forms.TextBox
    Friend WithEvents btnAbort As System.Windows.Forms.Button
    Friend WithEvents txtDebug As System.Windows.Forms.TextBox
    Friend WithEvents lbldbg As System.Windows.Forms.Label
    Friend WithEvents lbldbg2 As System.Windows.Forms.Label
    Friend WithEvents txtDbgTrig As System.Windows.Forms.TextBox
    Friend WithEvents btnChan12 As System.Windows.Forms.Button
    Friend WithEvents btnChan16 As System.Windows.Forms.Button
    Friend WithEvents btnChan15 As System.Windows.Forms.Button
    Friend WithEvents btnChan14 As System.Windows.Forms.Button
    Friend WithEvents btnChan13 As System.Windows.Forms.Button
    Friend WithEvents btnChan11 As System.Windows.Forms.Button
    Friend WithEvents btnChan10 As System.Windows.Forms.Button
    Friend WithEvents btnChan9 As System.Windows.Forms.Button

End Class
