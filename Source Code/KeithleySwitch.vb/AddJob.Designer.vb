<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddJob
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
        Me.lvw_JobList = New System.Windows.Forms.ListView()
        Me.User = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Channels = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddJob = New System.Windows.Forms.Button()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.gbx_info = New System.Windows.Forms.GroupBox()
        Me.lblHelp2 = New System.Windows.Forms.Label()
        Me.lblHelp1 = New System.Windows.Forms.Label()
        Me.txtChannelsSelected = New System.Windows.Forms.TextBox()
        Me.lbl_selected = New System.Windows.Forms.Label()
        Me.lbl_Yel = New System.Windows.Forms.Label()
        Me.lbl_Grn = New System.Windows.Forms.Label()
        Me.lbl_Blu = New System.Windows.Forms.Label()
        Me.pnl_Grn = New System.Windows.Forms.Panel()
        Me.lbl_Ctrl = New System.Windows.Forms.Label()
        Me.pnl_Ctrl = New System.Windows.Forms.Panel()
        Me.pnl_Blu = New System.Windows.Forms.Panel()
        Me.pnl_Yel = New System.Windows.Forms.Panel()
        Me.gbx_Channels = New System.Windows.Forms.GroupBox()
        Me.gbxAddJob = New System.Windows.Forms.GroupBox()
        Me.btnSelectLogFolder = New System.Windows.Forms.Button()
        Me.lblTimingFile = New System.Windows.Forms.Label()
        Me.txtLogfile = New System.Windows.Forms.TextBox()
        Me.chbEmail = New System.Windows.Forms.CheckBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.lblStep1 = New System.Windows.Forms.Label()
        Me.lblStep2a = New System.Windows.Forms.Label()
        Me.gbxAddScan = New System.Windows.Forms.GroupBox()
        Me.lblStep3 = New System.Windows.Forms.Label()
        Me.tmrUpdatePanel = New System.Windows.Forms.Timer(Me.components)
        Me.sfdLogFile = New System.Windows.Forms.SaveFileDialog()
        Me.gbx_info.SuspendLayout()
        Me.gbxAddJob.SuspendLayout()
        Me.gbxAddScan.SuspendLayout()
        Me.SuspendLayout()
        '
        'lvw_JobList
        '
        Me.lvw_JobList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.User, Me.Channels})
        Me.lvw_JobList.Location = New System.Drawing.Point(16, 20)
        Me.lvw_JobList.Name = "lvw_JobList"
        Me.lvw_JobList.Size = New System.Drawing.Size(360, 84)
        Me.lvw_JobList.TabIndex = 0
        Me.lvw_JobList.UseCompatibleStateImageBehavior = False
        Me.lvw_JobList.View = System.Windows.Forms.View.Details
        '
        'User
        '
        Me.User.Text = "User"
        Me.User.Width = 82
        '
        'Channels
        '
        Me.Channels.Text = "Channels"
        Me.Channels.Width = 93
        '
        'btnAddJob
        '
        Me.btnAddJob.Location = New System.Drawing.Point(16, 112)
        Me.btnAddJob.Name = "btnAddJob"
        Me.btnAddJob.Size = New System.Drawing.Size(360, 23)
        Me.btnAddJob.TabIndex = 1
        Me.btnAddJob.Text = "Add Job"
        Me.btnAddJob.UseVisualStyleBackColor = True
        '
        'txt_Name
        '
        Me.txt_Name.Location = New System.Drawing.Point(65, 12)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(124, 20)
        Me.txt_Name.TabIndex = 5
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Location = New System.Drawing.Point(27, 15)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(32, 13)
        Me.lblUser.TabIndex = 7
        Me.lblUser.Text = "User:"
        '
        'gbx_info
        '
        Me.gbx_info.Controls.Add(Me.lblHelp2)
        Me.gbx_info.Controls.Add(Me.lblHelp1)
        Me.gbx_info.Controls.Add(Me.txtChannelsSelected)
        Me.gbx_info.Controls.Add(Me.lbl_selected)
        Me.gbx_info.Controls.Add(Me.lbl_Yel)
        Me.gbx_info.Controls.Add(Me.lbl_Grn)
        Me.gbx_info.Controls.Add(Me.lbl_Blu)
        Me.gbx_info.Controls.Add(Me.pnl_Grn)
        Me.gbx_info.Controls.Add(Me.lbl_Ctrl)
        Me.gbx_info.Controls.Add(Me.pnl_Ctrl)
        Me.gbx_info.Controls.Add(Me.pnl_Blu)
        Me.gbx_info.Controls.Add(Me.pnl_Yel)
        Me.gbx_info.Location = New System.Drawing.Point(12, 440)
        Me.gbx_info.Name = "gbx_info"
        Me.gbx_info.Size = New System.Drawing.Size(444, 162)
        Me.gbx_info.TabIndex = 26
        Me.gbx_info.TabStop = False
        '
        'lblHelp2
        '
        Me.lblHelp2.AutoSize = True
        Me.lblHelp2.Location = New System.Drawing.Point(12, 85)
        Me.lblHelp2.Name = "lblHelp2"
        Me.lblHelp2.Size = New System.Drawing.Size(199, 13)
        Me.lblHelp2.TabIndex = 9
        Me.lblHelp2.Text = "Shift-clicking selects a block of channels"
        '
        'lblHelp1
        '
        Me.lblHelp1.AutoSize = True
        Me.lblHelp1.Location = New System.Drawing.Point(12, 65)
        Me.lblHelp1.Name = "lblHelp1"
        Me.lblHelp1.Size = New System.Drawing.Size(190, 13)
        Me.lblHelp1.TabIndex = 8
        Me.lblHelp1.Text = "Clicking selects or deselects a channel"
        '
        'txtChannelsSelected
        '
        Me.txtChannelsSelected.Location = New System.Drawing.Point(101, 110)
        Me.txtChannelsSelected.Name = "txtChannelsSelected"
        Me.txtChannelsSelected.ReadOnly = True
        Me.txtChannelsSelected.Size = New System.Drawing.Size(337, 20)
        Me.txtChannelsSelected.TabIndex = 7
        '
        'lbl_selected
        '
        Me.lbl_selected.AutoSize = True
        Me.lbl_selected.Location = New System.Drawing.Point(3, 113)
        Me.lbl_selected.Name = "lbl_selected"
        Me.lbl_selected.Size = New System.Drawing.Size(99, 13)
        Me.lbl_selected.TabIndex = 6
        Me.lbl_selected.Text = "Selected Channels:"
        '
        'lbl_Yel
        '
        Me.lbl_Yel.Location = New System.Drawing.Point(239, 16)
        Me.lbl_Yel.Name = "lbl_Yel"
        Me.lbl_Yel.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Yel.TabIndex = 4
        Me.lbl_Yel.Text = "In Queue"
        '
        'lbl_Grn
        '
        Me.lbl_Grn.Location = New System.Drawing.Point(45, 16)
        Me.lbl_Grn.Name = "lbl_Grn"
        Me.lbl_Grn.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Grn.TabIndex = 2
        Me.lbl_Grn.Text = "Currently Selected"
        '
        'lbl_Blu
        '
        Me.lbl_Blu.Location = New System.Drawing.Point(336, 16)
        Me.lbl_Blu.Name = "lbl_Blu"
        Me.lbl_Blu.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Blu.TabIndex = 0
        Me.lbl_Blu.Text = "Active Channel"
        '
        'pnl_Grn
        '
        Me.pnl_Grn.BackColor = System.Drawing.Color.Green
        Me.pnl_Grn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Grn.Location = New System.Drawing.Point(6, 16)
        Me.pnl_Grn.Name = "pnl_Grn"
        Me.pnl_Grn.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Grn.TabIndex = 1
        '
        'lbl_Ctrl
        '
        Me.lbl_Ctrl.Location = New System.Drawing.Point(142, 16)
        Me.lbl_Ctrl.Name = "lbl_Ctrl"
        Me.lbl_Ctrl.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Ctrl.TabIndex = 3
        Me.lbl_Ctrl.Text = "Currently Free"
        '
        'pnl_Ctrl
        '
        Me.pnl_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Ctrl.Location = New System.Drawing.Point(101, 16)
        Me.pnl_Ctrl.Name = "pnl_Ctrl"
        Me.pnl_Ctrl.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Ctrl.TabIndex = 1
        '
        'pnl_Blu
        '
        Me.pnl_Blu.BackColor = System.Drawing.Color.DodgerBlue
        Me.pnl_Blu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Blu.Location = New System.Drawing.Point(295, 16)
        Me.pnl_Blu.Name = "pnl_Blu"
        Me.pnl_Blu.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Blu.TabIndex = 1
        '
        'pnl_Yel
        '
        Me.pnl_Yel.BackColor = System.Drawing.Color.Yellow
        Me.pnl_Yel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Yel.Location = New System.Drawing.Point(198, 16)
        Me.pnl_Yel.Name = "pnl_Yel"
        Me.pnl_Yel.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Yel.TabIndex = 1
        '
        'gbx_Channels
        '
        Me.gbx_Channels.Location = New System.Drawing.Point(12, 42)
        Me.gbx_Channels.Name = "gbx_Channels"
        Me.gbx_Channels.Size = New System.Drawing.Size(444, 392)
        Me.gbx_Channels.TabIndex = 27
        Me.gbx_Channels.TabStop = False
        Me.gbx_Channels.Text = "Channels"
        '
        'gbxAddJob
        '
        Me.gbxAddJob.Controls.Add(Me.btnSelectLogFolder)
        Me.gbxAddJob.Controls.Add(Me.lblTimingFile)
        Me.gbxAddJob.Controls.Add(Me.txtLogfile)
        Me.gbxAddJob.Controls.Add(Me.chbEmail)
        Me.gbxAddJob.Controls.Add(Me.txtEmail)
        Me.gbxAddJob.Controls.Add(Me.lblEmail)
        Me.gbxAddJob.Controls.Add(Me.lblUser)
        Me.gbxAddJob.Controls.Add(Me.txt_Name)
        Me.gbxAddJob.Location = New System.Drawing.Point(474, 50)
        Me.gbxAddJob.Name = "gbxAddJob"
        Me.gbxAddJob.Size = New System.Drawing.Size(416, 253)
        Me.gbxAddJob.TabIndex = 28
        Me.gbxAddJob.TabStop = False
        '
        'btnSelectLogFolder
        '
        Me.btnSelectLogFolder.Location = New System.Drawing.Point(11, 47)
        Me.btnSelectLogFolder.Name = "btnSelectLogFolder"
        Me.btnSelectLogFolder.Size = New System.Drawing.Size(136, 23)
        Me.btnSelectLogFolder.TabIndex = 35
        Me.btnSelectLogFolder.Text = "Select Scan Log Folder"
        Me.btnSelectLogFolder.UseVisualStyleBackColor = True
        '
        'lblTimingFile
        '
        Me.lblTimingFile.AutoSize = True
        Me.lblTimingFile.Location = New System.Drawing.Point(156, 53)
        Me.lblTimingFile.Name = "lblTimingFile"
        Me.lblTimingFile.Size = New System.Drawing.Size(82, 13)
        Me.lblTimingFile.TabIndex = 38
        Me.lblTimingFile.Text = "Log File Output:"
        '
        'txtLogfile
        '
        Me.txtLogfile.Location = New System.Drawing.Point(244, 50)
        Me.txtLogfile.Name = "txtLogfile"
        Me.txtLogfile.ReadOnly = True
        Me.txtLogfile.Size = New System.Drawing.Size(155, 20)
        Me.txtLogfile.TabIndex = 35
        '
        'chbEmail
        '
        Me.chbEmail.AutoSize = True
        Me.chbEmail.Location = New System.Drawing.Point(28, 101)
        Me.chbEmail.Name = "chbEmail"
        Me.chbEmail.Size = New System.Drawing.Size(120, 17)
        Me.chbEmail.TabIndex = 37
        Me.chbEmail.Text = "Email on completion"
        Me.chbEmail.UseVisualStyleBackColor = True
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Location = New System.Drawing.Point(65, 121)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(124, 20)
        Me.txtEmail.TabIndex = 36
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Enabled = False
        Me.lblEmail.Location = New System.Drawing.Point(24, 124)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(35, 13)
        Me.lblEmail.TabIndex = 35
        Me.lblEmail.Text = "Email:"
        '
        'btnOK
        '
        Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOK.Location = New System.Drawing.Point(16, 141)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(125, 23)
        Me.btnOK.TabIndex = 22
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(251, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(125, 23)
        Me.btnCancel.TabIndex = 21
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'lblStep1
        '
        Me.lblStep1.AutoSize = True
        Me.lblStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep1.Location = New System.Drawing.Point(7, 9)
        Me.lblStep1.Name = "lblStep1"
        Me.lblStep1.Size = New System.Drawing.Size(239, 25)
        Me.lblStep1.TabIndex = 30
        Me.lblStep1.Text = "Step 1: Select channels"
        '
        'lblStep2a
        '
        Me.lblStep2a.AutoSize = True
        Me.lblStep2a.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep2a.Location = New System.Drawing.Point(480, 17)
        Me.lblStep2a.Name = "lblStep2a"
        Me.lblStep2a.Size = New System.Drawing.Size(226, 25)
        Me.lblStep2a.TabIndex = 31
        Me.lblStep2a.Text = "Step 2: Enter user info"
        '
        'gbxAddScan
        '
        Me.gbxAddScan.Controls.Add(Me.btnOK)
        Me.gbxAddScan.Controls.Add(Me.btnCancel)
        Me.gbxAddScan.Controls.Add(Me.btnAddJob)
        Me.gbxAddScan.Controls.Add(Me.lvw_JobList)
        Me.gbxAddScan.Location = New System.Drawing.Point(479, 334)
        Me.gbxAddScan.Name = "gbxAddScan"
        Me.gbxAddScan.Size = New System.Drawing.Size(417, 172)
        Me.gbxAddScan.TabIndex = 33
        Me.gbxAddScan.TabStop = False
        '
        'lblStep3
        '
        Me.lblStep3.AutoSize = True
        Me.lblStep3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStep3.Location = New System.Drawing.Point(474, 306)
        Me.lblStep3.Name = "lblStep3"
        Me.lblStep3.Size = New System.Drawing.Size(376, 25)
        Me.lblStep3.TabIndex = 34
        Me.lblStep3.Text = "Step 3: Add job to queue and click OK"
        '
        'tmrUpdatePanel
        '
        Me.tmrUpdatePanel.Enabled = True
        '
        'sfdLogFile
        '
        Me.sfdLogFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*"
        '
        'AddJob
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(919, 666)
        Me.Controls.Add(Me.lblStep3)
        Me.Controls.Add(Me.gbxAddScan)
        Me.Controls.Add(Me.lblStep2a)
        Me.Controls.Add(Me.lblStep1)
        Me.Controls.Add(Me.gbxAddJob)
        Me.Controls.Add(Me.gbx_Channels)
        Me.Controls.Add(Me.gbx_info)
        Me.Name = "AddJob"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Scan Configuration"
        Me.gbx_info.ResumeLayout(False)
        Me.gbx_info.PerformLayout()
        Me.gbxAddJob.ResumeLayout(False)
        Me.gbxAddJob.PerformLayout()
        Me.gbxAddScan.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvw_JobList As System.Windows.Forms.ListView
    Friend WithEvents User As System.Windows.Forms.ColumnHeader
    Friend WithEvents Channels As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddJob As System.Windows.Forms.Button
    Friend WithEvents txt_Name As System.Windows.Forms.TextBox
    Friend WithEvents lblUser As System.Windows.Forms.Label
    Friend WithEvents gbx_info As System.Windows.Forms.GroupBox
    Friend WithEvents lblHelp2 As System.Windows.Forms.Label
    Friend WithEvents lblHelp1 As System.Windows.Forms.Label
    Friend WithEvents txtChannelsSelected As System.Windows.Forms.TextBox
    Friend WithEvents lbl_selected As System.Windows.Forms.Label
    Friend WithEvents lbl_Yel As System.Windows.Forms.Label
    Friend WithEvents lbl_Grn As System.Windows.Forms.Label
    Friend WithEvents lbl_Blu As System.Windows.Forms.Label
    Friend WithEvents pnl_Grn As System.Windows.Forms.Panel
    Friend WithEvents lbl_Ctrl As System.Windows.Forms.Label
    Friend WithEvents pnl_Ctrl As System.Windows.Forms.Panel
    Friend WithEvents pnl_Blu As System.Windows.Forms.Panel
    Friend WithEvents pnl_Yel As System.Windows.Forms.Panel
    Friend WithEvents gbx_Channels As System.Windows.Forms.GroupBox
    Friend WithEvents gbxAddJob As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents lblStep1 As System.Windows.Forms.Label
    Friend WithEvents lblStep2a As System.Windows.Forms.Label
    Friend WithEvents gbxAddScan As System.Windows.Forms.GroupBox
    Friend WithEvents lblStep3 As System.Windows.Forms.Label
    Friend WithEvents tmrUpdatePanel As System.Windows.Forms.Timer
    Friend WithEvents chbEmail As System.Windows.Forms.CheckBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents lblTimingFile As System.Windows.Forms.Label
    Friend WithEvents txtLogfile As System.Windows.Forms.TextBox
    Friend WithEvents btnSelectLogFolder As System.Windows.Forms.Button
    Friend WithEvents sfdLogFile As System.Windows.Forms.SaveFileDialog
End Class
