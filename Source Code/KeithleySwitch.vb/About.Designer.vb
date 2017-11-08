<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAbout
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
        Me.txtAuthor = New System.Windows.Forms.Label()
        Me.txtAbout2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtAuthor
        '
        Me.txtAuthor.AutoSize = True
        Me.txtAuthor.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAuthor.Location = New System.Drawing.Point(12, 29)
        Me.txtAuthor.Name = "txtAuthor"
        Me.txtAuthor.Size = New System.Drawing.Size(254, 25)
        Me.txtAuthor.TabIndex = 0
        Me.txtAuthor.Text = "Written by Michael Lynch"
        Me.txtAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtAbout2
        '
        Me.txtAbout2.AutoSize = True
        Me.txtAbout2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAbout2.Location = New System.Drawing.Point(13, 54)
        Me.txtAbout2.Name = "txtAbout2"
        Me.txtAbout2.Size = New System.Drawing.Size(237, 24)
        Me.txtAbout2.TabIndex = 1
        Me.txtAbout2.Text = "Dahn Group, summer 2017"
        Me.txtAbout2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAbout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 107)
        Me.Controls.Add(Me.txtAbout2)
        Me.Controls.Add(Me.txtAuthor)
        Me.Name = "frmAbout"
        Me.Text = "About"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAuthor As System.Windows.Forms.Label
    Friend WithEvents txtAbout2 As System.Windows.Forms.Label
End Class
