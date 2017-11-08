<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class gpibhub
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
        Me.btnCon1 = New System.Windows.Forms.Button()
        Me.btnCon2 = New System.Windows.Forms.Button()
        Me.btnCon3 = New System.Windows.Forms.Button()
        Me.txtGPIB3 = New System.Windows.Forms.TextBox()
        Me.txtGPIB2 = New System.Windows.Forms.TextBox()
        Me.txtGPIB1 = New System.Windows.Forms.TextBox()
        Me.lblDMM1 = New System.Windows.Forms.Label()
        Me.lblDMM2 = New System.Windows.Forms.Label()
        Me.lblDMM3 = New System.Windows.Forms.Label()
        Me.tmrVisible = New System.Windows.Forms.Timer(Me.components)
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.ovlDMM3Con = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.ovlDMM2Con = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.ovlDMM1Con = New Microsoft.VisualBasic.PowerPacks.OvalShape()
        Me.lblDMM1Con = New System.Windows.Forms.Label()
        Me.lblDMM2Con = New System.Windows.Forms.Label()
        Me.lblDMM3Con = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCon1
        '
        Me.btnCon1.Location = New System.Drawing.Point(155, 30)
        Me.btnCon1.Name = "btnCon1"
        Me.btnCon1.Size = New System.Drawing.Size(75, 23)
        Me.btnCon1.TabIndex = 0
        Me.btnCon1.Text = "Connect"
        Me.btnCon1.UseVisualStyleBackColor = True
        '
        'btnCon2
        '
        Me.btnCon2.Location = New System.Drawing.Point(155, 100)
        Me.btnCon2.Name = "btnCon2"
        Me.btnCon2.Size = New System.Drawing.Size(75, 23)
        Me.btnCon2.TabIndex = 1
        Me.btnCon2.Text = "Connect"
        Me.btnCon2.UseVisualStyleBackColor = True
        '
        'btnCon3
        '
        Me.btnCon3.Location = New System.Drawing.Point(155, 170)
        Me.btnCon3.Name = "btnCon3"
        Me.btnCon3.Size = New System.Drawing.Size(75, 23)
        Me.btnCon3.TabIndex = 2
        Me.btnCon3.Text = "Connect"
        Me.btnCon3.UseVisualStyleBackColor = True
        '
        'txtGPIB3
        '
        Me.txtGPIB3.Location = New System.Drawing.Point(124, 170)
        Me.txtGPIB3.MaxLength = 2
        Me.txtGPIB3.Name = "txtGPIB3"
        Me.txtGPIB3.ReadOnly = True
        Me.txtGPIB3.Size = New System.Drawing.Size(21, 20)
        Me.txtGPIB3.TabIndex = 3
        Me.txtGPIB3.Text = "22"
        '
        'txtGPIB2
        '
        Me.txtGPIB2.Location = New System.Drawing.Point(124, 100)
        Me.txtGPIB2.MaxLength = 2
        Me.txtGPIB2.Name = "txtGPIB2"
        Me.txtGPIB2.ReadOnly = True
        Me.txtGPIB2.Size = New System.Drawing.Size(21, 20)
        Me.txtGPIB2.TabIndex = 4
        Me.txtGPIB2.Text = "21"
        '
        'txtGPIB1
        '
        Me.txtGPIB1.Location = New System.Drawing.Point(124, 30)
        Me.txtGPIB1.MaxLength = 2
        Me.txtGPIB1.Name = "txtGPIB1"
        Me.txtGPIB1.ReadOnly = True
        Me.txtGPIB1.Size = New System.Drawing.Size(21, 20)
        Me.txtGPIB1.TabIndex = 5
        Me.txtGPIB1.Text = "20"
        '
        'lblDMM1
        '
        Me.lblDMM1.AutoSize = True
        Me.lblDMM1.Location = New System.Drawing.Point(8, 30)
        Me.lblDMM1.Name = "lblDMM1"
        Me.lblDMM1.Size = New System.Drawing.Size(115, 13)
        Me.lblDMM1.TabIndex = 6
        Me.lblDMM1.Text = "Multimeter #1 Address:"
        '
        'lblDMM2
        '
        Me.lblDMM2.AutoSize = True
        Me.lblDMM2.Location = New System.Drawing.Point(8, 100)
        Me.lblDMM2.Name = "lblDMM2"
        Me.lblDMM2.Size = New System.Drawing.Size(115, 13)
        Me.lblDMM2.TabIndex = 7
        Me.lblDMM2.Text = "Multimeter #2 Address:"
        '
        'lblDMM3
        '
        Me.lblDMM3.AutoSize = True
        Me.lblDMM3.Location = New System.Drawing.Point(8, 173)
        Me.lblDMM3.Name = "lblDMM3"
        Me.lblDMM3.Size = New System.Drawing.Size(115, 13)
        Me.lblDMM3.TabIndex = 8
        Me.lblDMM3.Text = "Multimeter #3 Address:"
        '
        'tmrVisible
        '
        Me.tmrVisible.Interval = 500
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.ovlDMM3Con, Me.ovlDMM2Con, Me.ovlDMM1Con})
        Me.ShapeContainer1.Size = New System.Drawing.Size(284, 281)
        Me.ShapeContainer1.TabIndex = 9
        Me.ShapeContainer1.TabStop = False
        '
        'ovlDMM3Con
        '
        Me.ovlDMM3Con.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.ovlDMM3Con.Location = New System.Drawing.Point(90, 195)
        Me.ovlDMM3Con.Name = "ovlDMM3Con"
        Me.ovlDMM3Con.Size = New System.Drawing.Size(16, 16)
        '
        'ovlDMM2Con
        '
        Me.ovlDMM2Con.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.ovlDMM2Con.Location = New System.Drawing.Point(90, 125)
        Me.ovlDMM2Con.Name = "ovlDMM2Con"
        Me.ovlDMM2Con.Size = New System.Drawing.Size(16, 16)
        '
        'ovlDMM1Con
        '
        Me.ovlDMM1Con.BackColor = System.Drawing.SystemColors.Control
        Me.ovlDMM1Con.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.ovlDMM1Con.Location = New System.Drawing.Point(90, 55)
        Me.ovlDMM1Con.Name = "ovlDMM1Con"
        Me.ovlDMM1Con.Size = New System.Drawing.Size(16, 16)
        '
        'lblDMM1Con
        '
        Me.lblDMM1Con.AutoSize = True
        Me.lblDMM1Con.Location = New System.Drawing.Point(44, 59)
        Me.lblDMM1Con.Name = "lblDMM1Con"
        Me.lblDMM1Con.Size = New System.Drawing.Size(37, 13)
        Me.lblDMM1Con.TabIndex = 10
        Me.lblDMM1Con.Text = "Status"
        '
        'lblDMM2Con
        '
        Me.lblDMM2Con.AutoSize = True
        Me.lblDMM2Con.Location = New System.Drawing.Point(44, 129)
        Me.lblDMM2Con.Name = "lblDMM2Con"
        Me.lblDMM2Con.Size = New System.Drawing.Size(37, 13)
        Me.lblDMM2Con.TabIndex = 11
        Me.lblDMM2Con.Text = "Status"
        '
        'lblDMM3Con
        '
        Me.lblDMM3Con.AutoSize = True
        Me.lblDMM3Con.Location = New System.Drawing.Point(44, 199)
        Me.lblDMM3Con.Name = "lblDMM3Con"
        Me.lblDMM3Con.Size = New System.Drawing.Size(37, 13)
        Me.lblDMM3Con.TabIndex = 12
        Me.lblDMM3Con.Text = "Status"
        '
        'gpibhub
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 281)
        Me.Controls.Add(Me.lblDMM3Con)
        Me.Controls.Add(Me.lblDMM2Con)
        Me.Controls.Add(Me.lblDMM1Con)
        Me.Controls.Add(Me.lblDMM3)
        Me.Controls.Add(Me.lblDMM2)
        Me.Controls.Add(Me.lblDMM1)
        Me.Controls.Add(Me.txtGPIB1)
        Me.Controls.Add(Me.txtGPIB2)
        Me.Controls.Add(Me.txtGPIB3)
        Me.Controls.Add(Me.btnCon3)
        Me.Controls.Add(Me.btnCon2)
        Me.Controls.Add(Me.btnCon1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "gpibhub"
        Me.Text = "Keithley Config"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCon1 As System.Windows.Forms.Button
    Friend WithEvents btnCon2 As System.Windows.Forms.Button
    Friend WithEvents btnCon3 As System.Windows.Forms.Button
    Friend WithEvents txtGPIB3 As System.Windows.Forms.TextBox
    Friend WithEvents txtGPIB2 As System.Windows.Forms.TextBox
    Friend WithEvents txtGPIB1 As System.Windows.Forms.TextBox
    Friend WithEvents lblDMM1 As System.Windows.Forms.Label
    Friend WithEvents lblDMM2 As System.Windows.Forms.Label
    Friend WithEvents lblDMM3 As System.Windows.Forms.Label
    Friend WithEvents tmrVisible As System.Windows.Forms.Timer
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents ovlDMM1Con As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents ovlDMM3Con As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents ovlDMM2Con As Microsoft.VisualBasic.PowerPacks.OvalShape
    Friend WithEvents lblDMM1Con As System.Windows.Forms.Label
    Friend WithEvents lblDMM2Con As System.Windows.Forms.Label
    Friend WithEvents lblDMM3Con As System.Windows.Forms.Label
End Class
