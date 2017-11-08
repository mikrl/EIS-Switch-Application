<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Delooper
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
        Me.lvwFilesToDeloop = New System.Windows.Forms.ListView()
        Me.filepath = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.numloops = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAddFiles = New System.Windows.Forms.Button()
        Me.ofdSelectFiles = New System.Windows.Forms.OpenFileDialog()
        Me.btnDeloop = New System.Windows.Forms.Button()
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvwFilesToDeloop
        '
        Me.lvwFilesToDeloop.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.filepath, Me.numloops})
        Me.lvwFilesToDeloop.Location = New System.Drawing.Point(12, 49)
        Me.lvwFilesToDeloop.Name = "lvwFilesToDeloop"
        Me.lvwFilesToDeloop.Size = New System.Drawing.Size(479, 97)
        Me.lvwFilesToDeloop.TabIndex = 0
        Me.lvwFilesToDeloop.UseCompatibleStateImageBehavior = False
        Me.lvwFilesToDeloop.View = System.Windows.Forms.View.Details
        '
        'filepath
        '
        Me.filepath.Text = "File Path"
        Me.filepath.Width = 157
        '
        'numloops
        '
        Me.numloops.Text = "Number of loops"
        Me.numloops.Width = 98
        '
        'btnAddFiles
        '
        Me.btnAddFiles.Location = New System.Drawing.Point(12, 152)
        Me.btnAddFiles.Name = "btnAddFiles"
        Me.btnAddFiles.Size = New System.Drawing.Size(260, 23)
        Me.btnAddFiles.TabIndex = 1
        Me.btnAddFiles.Text = "Add Files"
        Me.btnAddFiles.UseVisualStyleBackColor = True
        '
        'ofdSelectFiles
        '
        Me.ofdSelectFiles.Filter = "MPT text files|*.mpt"
        Me.ofdSelectFiles.Multiselect = True
        '
        'btnDeloop
        '
        Me.btnDeloop.Location = New System.Drawing.Point(12, 227)
        Me.btnDeloop.Name = "btnDeloop"
        Me.btnDeloop.Size = New System.Drawing.Size(260, 23)
        Me.btnDeloop.TabIndex = 2
        Me.btnDeloop.Text = "Break Loops Into Separate Files"
        Me.btnDeloop.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(12, 181)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(260, 23)
        Me.btnRemove.TabIndex = 3
        Me.btnRemove.Text = "Remove Selected Files"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'Delooper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 262)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.btnDeloop)
        Me.Controls.Add(Me.btnAddFiles)
        Me.Controls.Add(Me.lvwFilesToDeloop)
        Me.Name = "Delooper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Delooper"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvwFilesToDeloop As System.Windows.Forms.ListView
    Friend WithEvents filepath As System.Windows.Forms.ColumnHeader
    Friend WithEvents numloops As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnAddFiles As System.Windows.Forms.Button
    Friend WithEvents ofdSelectFiles As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnDeloop As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
End Class
