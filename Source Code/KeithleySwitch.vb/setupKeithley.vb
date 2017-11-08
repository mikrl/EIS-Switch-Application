Public Class setupKeithley
    Dim intGPIBAddr As Integer

    Public Function getGPIBAddr() As Integer
        Return intGPIBAddr
    End Function

    Private Sub txtAddr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddr.KeyPress
        If e.KeyChar <> ControlChars.Back Then
            e.Handled = Not (IsNumeric(e.KeyChar))
        End If
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        intGPIBAddr = CInt(txtAddr.Text)
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        intGPIBAddr = Nothing
        Me.Close()
    End Sub
End Class