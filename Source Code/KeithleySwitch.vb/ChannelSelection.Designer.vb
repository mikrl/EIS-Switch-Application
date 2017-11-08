<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChannelSelection
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
        Me.gbx_Channels = New System.Windows.Forms.GroupBox()
        Me.pnl_Grn = New System.Windows.Forms.Panel()
        Me.pnl_Ctrl = New System.Windows.Forms.Panel()
        Me.pnl_Blu = New System.Windows.Forms.Panel()
        Me.pnl_Yel = New System.Windows.Forms.Panel()
        Me.lbl_Grn = New System.Windows.Forms.Label()
        Me.lbl_Ctrl = New System.Windows.Forms.Label()
        Me.lbl_Blu = New System.Windows.Forms.Label()
        Me.lbl_Yel = New System.Windows.Forms.Label()
        Me.gbx_info = New System.Windows.Forms.GroupBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.lblHelp2 = New System.Windows.Forms.Label()
        Me.lblHelp1 = New System.Windows.Forms.Label()
        Me.txt_Selected = New System.Windows.Forms.TextBox()
        Me.lbl_selected = New System.Windows.Forms.Label()
        Me.txtWaiting = New System.Windows.Forms.TextBox()
        Me.txtFirstRun = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gbx_info.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbx_Channels
        '
        Me.gbx_Channels.Location = New System.Drawing.Point(0, 12)
        Me.gbx_Channels.Name = "gbx_Channels"
        Me.gbx_Channels.Size = New System.Drawing.Size(444, 392)
        Me.gbx_Channels.TabIndex = 0
        Me.gbx_Channels.TabStop = False
        Me.gbx_Channels.Text = "Channels"
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
        Me.pnl_Blu.Location = New System.Drawing.Point(196, 16)
        Me.pnl_Blu.Name = "pnl_Blu"
        Me.pnl_Blu.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Blu.TabIndex = 1
        '
        'pnl_Yel
        '
        Me.pnl_Yel.BackColor = System.Drawing.Color.Yellow
        Me.pnl_Yel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnl_Yel.Location = New System.Drawing.Point(291, 16)
        Me.pnl_Yel.Name = "pnl_Yel"
        Me.pnl_Yel.Size = New System.Drawing.Size(30, 30)
        Me.pnl_Yel.TabIndex = 1
        '
        'lbl_Grn
        '
        Me.lbl_Grn.Location = New System.Drawing.Point(45, 16)
        Me.lbl_Grn.Name = "lbl_Grn"
        Me.lbl_Grn.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Grn.TabIndex = 2
        Me.lbl_Grn.Text = "Currently Selected"
        '
        'lbl_Ctrl
        '
        Me.lbl_Ctrl.Location = New System.Drawing.Point(142, 16)
        Me.lbl_Ctrl.Name = "lbl_Ctrl"
        Me.lbl_Ctrl.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Ctrl.TabIndex = 3
        Me.lbl_Ctrl.Text = "Currently Free"
        '
        'lbl_Blu
        '
        Me.lbl_Blu.Location = New System.Drawing.Point(237, 16)
        Me.lbl_Blu.Name = "lbl_Blu"
        Me.lbl_Blu.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Blu.TabIndex = 0
        Me.lbl_Blu.Text = "Active Channel"
        '
        'lbl_Yel
        '
        Me.lbl_Yel.Location = New System.Drawing.Point(332, 16)
        Me.lbl_Yel.Name = "lbl_Yel"
        Me.lbl_Yel.Size = New System.Drawing.Size(50, 33)
        Me.lbl_Yel.TabIndex = 4
        Me.lbl_Yel.Text = "In Queue"
        '
        'gbx_info
        '
        Me.gbx_info.Controls.Add(Me.Label2)
        Me.gbx_info.Controls.Add(Me.Label1)
        Me.gbx_info.Controls.Add(Me.txtFirstRun)
        Me.gbx_info.Controls.Add(Me.txtWaiting)
        Me.gbx_info.Controls.Add(Me.btnCancel)
        Me.gbx_info.Controls.Add(Me.btnAdd)
        Me.gbx_info.Controls.Add(Me.lblHelp2)
        Me.gbx_info.Controls.Add(Me.lblHelp1)
        Me.gbx_info.Controls.Add(Me.txt_Selected)
        Me.gbx_info.Controls.Add(Me.lbl_selected)
        Me.gbx_info.Controls.Add(Me.lbl_Yel)
        Me.gbx_info.Controls.Add(Me.lbl_Grn)
        Me.gbx_info.Controls.Add(Me.lbl_Blu)
        Me.gbx_info.Controls.Add(Me.pnl_Grn)
        Me.gbx_info.Controls.Add(Me.lbl_Ctrl)
        Me.gbx_info.Controls.Add(Me.pnl_Ctrl)
        Me.gbx_info.Controls.Add(Me.pnl_Blu)
        Me.gbx_info.Controls.Add(Me.pnl_Yel)
        Me.gbx_info.Location = New System.Drawing.Point(0, 402)
        Me.gbx_info.Name = "gbx_info"
        Me.gbx_info.Size = New System.Drawing.Size(444, 250)
        Me.gbx_info.TabIndex = 5
        Me.gbx_info.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(212, 136)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 11
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(6, 136)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(196, 23)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add Selected Channels"
        Me.btnAdd.UseVisualStyleBackColor = True
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
        'txt_Selected
        '
        Me.txt_Selected.Location = New System.Drawing.Point(101, 110)
        Me.txt_Selected.Name = "txt_Selected"
        Me.txt_Selected.ReadOnly = True
        Me.txt_Selected.Size = New System.Drawing.Size(337, 20)
        Me.txt_Selected.TabIndex = 7
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
        'txtWaiting
        '
        Me.txtWaiting.Location = New System.Drawing.Point(87, 190)
        Me.txtWaiting.Name = "txtWaiting"
        Me.txtWaiting.ReadOnly = True
        Me.txtWaiting.Size = New System.Drawing.Size(100, 20)
        Me.txtWaiting.TabIndex = 6
        '
        'txtFirstRun
        '
        Me.txtFirstRun.Location = New System.Drawing.Point(302, 190)
        Me.txtFirstRun.Name = "txtFirstRun"
        Me.txtFirstRun.ReadOnly = True
        Me.txtFirstRun.Size = New System.Drawing.Size(100, 20)
        Me.txtFirstRun.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(-3, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Waiting for scan"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(220, 193)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "First loop done"
        '
        'ChannelSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(456, 662)
        Me.Controls.Add(Me.gbx_info)
        Me.Controls.Add(Me.gbx_Channels)
        Me.Name = "ChannelSelection"
        Me.Text = "ChannelSelection"
        Me.gbx_info.ResumeLayout(False)
        Me.gbx_info.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbx_Channels As System.Windows.Forms.GroupBox
    Friend WithEvents pnl_Grn As System.Windows.Forms.Panel
    Friend WithEvents pnl_Ctrl As System.Windows.Forms.Panel
    Friend WithEvents pnl_Blu As System.Windows.Forms.Panel
    Friend WithEvents pnl_Yel As System.Windows.Forms.Panel
    Friend WithEvents lbl_Grn As System.Windows.Forms.Label
    Friend WithEvents lbl_Ctrl As System.Windows.Forms.Label
    Friend WithEvents lbl_Blu As System.Windows.Forms.Label
    Friend WithEvents lbl_Yel As System.Windows.Forms.Label
    Friend WithEvents gbx_info As System.Windows.Forms.GroupBox
    Friend WithEvents txt_Selected As System.Windows.Forms.TextBox
    Friend WithEvents lbl_selected As System.Windows.Forms.Label
    Friend WithEvents lblHelp2 As System.Windows.Forms.Label
    Friend WithEvents lblHelp1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstRun As System.Windows.Forms.TextBox
    Friend WithEvents txtWaiting As System.Windows.Forms.TextBox
End Class
