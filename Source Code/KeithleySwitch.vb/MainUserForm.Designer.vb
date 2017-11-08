<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainUserForm
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
        Me.gbx_Channels = New System.Windows.Forms.GroupBox()
        Me.gbx_colours = New System.Windows.Forms.GroupBox()
        Me.lbl_Yel = New System.Windows.Forms.Label()
        Me.lbl_Blu = New System.Windows.Forms.Label()
        Me.lbl_Ctrl = New System.Windows.Forms.Label()
        Me.pnl_Ctrl = New System.Windows.Forms.Panel()
        Me.pnl_Blu = New System.Windows.Forms.Panel()
        Me.pnl_Yel = New System.Windows.Forms.Panel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.tstMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.StartScanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lvwQueuedJobs = New System.Windows.Forms.ListView()
        Me.User = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Channels = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TimeComplete = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TimeStarted = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.gbx_StartScan = New System.Windows.Forms.GroupBox()
        Me.btnReconnect = New System.Windows.Forms.Button()
        Me.lblBypass = New System.Windows.Forms.Label()
        Me.lblAbort = New System.Windows.Forms.Label()
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.btnForceComplete = New System.Windows.Forms.Button()
        Me.tmrUpdateAddJobPanels = New System.Windows.Forms.Timer(Me.components)
        Me.gbx_colours.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.gbx_StartScan.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx_Channels
        '
        Me.gbx_Channels.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbx_Channels.Location = New System.Drawing.Point(10, 30)
        Me.gbx_Channels.Name = "gbx_Channels"
        Me.gbx_Channels.Size = New System.Drawing.Size(444, 392)
        Me.gbx_Channels.TabIndex = 29
        Me.gbx_Channels.TabStop = False
        Me.gbx_Channels.Text = "Channels"
        '
        'gbx_colours
        '
        Me.gbx_colours.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbx_colours.Controls.Add(Me.lbl_Yel)
        Me.gbx_colours.Controls.Add(Me.lbl_Blu)
        Me.gbx_colours.Controls.Add(Me.lbl_Ctrl)
        Me.gbx_colours.Controls.Add(Me.pnl_Ctrl)
        Me.gbx_colours.Controls.Add(Me.pnl_Blu)
        Me.gbx_colours.Controls.Add(Me.pnl_Yel)
        Me.gbx_colours.Location = New System.Drawing.Point(6, 431)
        Me.gbx_colours.Name = "gbx_colours"
        Me.gbx_colours.Size = New System.Drawing.Size(444, 65)
        Me.gbx_colours.TabIndex = 28
        Me.gbx_colours.TabStop = False
        '
        'lbl_Yel
        '
        Me.lbl_Yel.Location = New System.Drawing.Point(394, 19)
        Me.lbl_Yel.Name = "lbl_Yel"
        Me.lbl_Yel.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Yel.TabIndex = 4
        Me.lbl_Yel.Text = "In Queue"
        '
        'lbl_Blu
        '
        Me.lbl_Blu.Location = New System.Drawing.Point(243, 19)
        Me.lbl_Blu.Name = "lbl_Blu"
        Me.lbl_Blu.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Blu.TabIndex = 0
        Me.lbl_Blu.Text = "Active Channel"
        '
        'lbl_Ctrl
        '
        Me.lbl_Ctrl.Location = New System.Drawing.Point(72, 19)
        Me.lbl_Ctrl.Name = "lbl_Ctrl"
        Me.lbl_Ctrl.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Ctrl.TabIndex = 3
        Me.lbl_Ctrl.Text = "Currently Free"
        '
        'pnl_Ctrl
        '
        Me.pnl_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Ctrl.Location = New System.Drawing.Point(36, 20)
        Me.pnl_Ctrl.Name = "pnl_Ctrl"
        Me.pnl_Ctrl.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Ctrl.TabIndex = 1
        '
        'pnl_Blu
        '
        Me.pnl_Blu.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnl_Blu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Blu.Location = New System.Drawing.Point(207, 20)
        Me.pnl_Blu.Name = "pnl_Blu"
        Me.pnl_Blu.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Blu.TabIndex = 1
        '
        'pnl_Yel
        '
        Me.pnl_Yel.BackColor = System.Drawing.Color.Yellow
        Me.pnl_Yel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Yel.Location = New System.Drawing.Point(358, 19)
        Me.pnl_Yel.Name = "pnl_Yel"
        Me.pnl_Yel.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Yel.TabIndex = 1
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tstMenu})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(471, 24)
        Me.MenuStrip1.TabIndex = 30
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'tstMenu
        '
        Me.tstMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StartScanToolStripMenuItem, Me.ExportDataToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.tstMenu.Name = "tstMenu"
        Me.tstMenu.Size = New System.Drawing.Size(37, 20)
        Me.tstMenu.Text = "&File"
        '
        'StartScanToolStripMenuItem
        '
        Me.StartScanToolStripMenuItem.Name = "StartScanToolStripMenuItem"
        Me.StartScanToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.StartScanToolStripMenuItem.Text = "&Start scan"
        '
        'ExportDataToolStripMenuItem
        '
        Me.ExportDataToolStripMenuItem.Name = "ExportDataToolStripMenuItem"
        Me.ExportDataToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.ExportDataToolStripMenuItem.Text = "&Process Data"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.AboutToolStripMenuItem.Text = "&About"
        '
        'lvwQueuedJobs
        '
        Me.lvwQueuedJobs.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.User, Me.Channels, Me.TimeComplete, Me.TimeStarted})
        Me.lvwQueuedJobs.Location = New System.Drawing.Point(6, 16)
        Me.lvwQueuedJobs.Name = "lvwQueuedJobs"
        Me.lvwQueuedJobs.Size = New System.Drawing.Size(442, 73)
        Me.lvwQueuedJobs.TabIndex = 0
        Me.lvwQueuedJobs.UseCompatibleStateImageBehavior = False
        Me.lvwQueuedJobs.View = System.Windows.Forms.View.Details
        '
        'User
        '
        Me.User.Text = "User"
        Me.User.Width = 63
        '
        'Channels
        '
        Me.Channels.Text = "Channels"
        Me.Channels.Width = 62
        '
        'TimeComplete
        '
        Me.TimeComplete.Text = "Time Remaining"
        Me.TimeComplete.Width = 97
        '
        'TimeStarted
        '
        Me.TimeStarted.Text = "Started At"
        Me.TimeStarted.Width = 72
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(6, 97)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(116, 52)
        Me.btnStart.TabIndex = 31
        Me.btnStart.Text = "Start Scan"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(332, 97)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(116, 52)
        Me.btnRemove.TabIndex = 32
        Me.btnRemove.Text = "Remove Queued Job"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'gbx_StartScan
        '
        Me.gbx_StartScan.Controls.Add(Me.btnReconnect)
        Me.gbx_StartScan.Controls.Add(Me.lblBypass)
        Me.gbx_StartScan.Controls.Add(Me.lblAbort)
        Me.gbx_StartScan.Controls.Add(Me.btnAbort)
        Me.gbx_StartScan.Controls.Add(Me.btnForceComplete)
        Me.gbx_StartScan.Controls.Add(Me.btnRemove)
        Me.gbx_StartScan.Controls.Add(Me.btnStart)
        Me.gbx_StartScan.Controls.Add(Me.lvwQueuedJobs)
        Me.gbx_StartScan.Location = New System.Drawing.Point(6, 502)
        Me.gbx_StartScan.Name = "gbx_StartScan"
        Me.gbx_StartScan.Size = New System.Drawing.Size(453, 220)
        Me.gbx_StartScan.TabIndex = 33
        Me.gbx_StartScan.TabStop = False
        '
        'btnReconnect
        '
        Me.btnReconnect.Location = New System.Drawing.Point(6, 155)
        Me.btnReconnect.Name = "btnReconnect"
        Me.btnReconnect.Size = New System.Drawing.Size(116, 23)
        Me.btnReconnect.TabIndex = 36
        Me.btnReconnect.Text = "Reconnect"
        Me.btnReconnect.UseVisualStyleBackColor = True
        '
        'lblBypass
        '
        Me.lblBypass.AutoSize = True
        Me.lblBypass.Location = New System.Drawing.Point(163, 200)
        Me.lblBypass.Name = "lblBypass"
        Me.lblBypass.Size = New System.Drawing.Size(205, 13)
        Me.lblBypass.TabIndex = 35
        Me.lblBypass.Text = "Switches through to the end of the routine"
        '
        'lblAbort
        '
        Me.lblAbort.AutoSize = True
        Me.lblAbort.Location = New System.Drawing.Point(226, 141)
        Me.lblAbort.Name = "lblAbort"
        Me.lblAbort.Size = New System.Drawing.Size(57, 13)
        Me.lblAbort.TabIndex = 34
        Me.lblAbort.Text = "Quits scan"
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(198, 109)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(116, 29)
        Me.btnAbort.TabIndex = 34
        Me.btnAbort.Text = "Abort Scan"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'btnForceComplete
        '
        Me.btnForceComplete.Location = New System.Drawing.Point(198, 168)
        Me.btnForceComplete.Name = "btnForceComplete"
        Me.btnForceComplete.Size = New System.Drawing.Size(116, 29)
        Me.btnForceComplete.TabIndex = 33
        Me.btnForceComplete.Text = "Bypass Triggers"
        Me.btnForceComplete.UseVisualStyleBackColor = True
        '
        'tmrUpdateAddJobPanels
        '
        '
        'MainUserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(471, 727)
        Me.Controls.Add(Me.gbx_StartScan)
        Me.Controls.Add(Me.gbx_Channels)
        Me.Controls.Add(Me.gbx_colours)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainUserForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Front Panel"
        Me.gbx_colours.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gbx_StartScan.ResumeLayout(False)
        Me.gbx_StartScan.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbx_Channels As System.Windows.Forms.GroupBox
    Friend WithEvents gbx_colours As System.Windows.Forms.GroupBox
    Friend WithEvents lbl_Yel As System.Windows.Forms.Label
    Friend WithEvents lbl_Blu As System.Windows.Forms.Label
    Friend WithEvents lbl_Ctrl As System.Windows.Forms.Label
    Friend WithEvents pnl_Ctrl As System.Windows.Forms.Panel
    Friend WithEvents pnl_Blu As System.Windows.Forms.Panel
    Friend WithEvents pnl_Yel As System.Windows.Forms.Panel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents tstMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StartScanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lvwQueuedJobs As System.Windows.Forms.ListView
    Friend WithEvents User As System.Windows.Forms.ColumnHeader
    Friend WithEvents Channels As System.Windows.Forms.ColumnHeader
    Friend WithEvents TimeComplete As System.Windows.Forms.ColumnHeader
    Friend WithEvents TimeStarted As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents gbx_StartScan As System.Windows.Forms.GroupBox
    Friend WithEvents ExportDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAbort As System.Windows.Forms.Button
    Friend WithEvents btnForceComplete As System.Windows.Forms.Button
    Friend WithEvents lblBypass As System.Windows.Forms.Label
    Friend WithEvents lblAbort As System.Windows.Forms.Label
    Friend WithEvents tmrUpdateAddJobPanels As System.Windows.Forms.Timer
    Friend WithEvents btnReconnect As System.Windows.Forms.Button
End Class
