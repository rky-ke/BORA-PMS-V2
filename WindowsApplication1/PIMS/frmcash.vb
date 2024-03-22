Public Class frmcash

    Private Sub TextBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.SelectionStart = Len(TextBox1.Text)
    End Sub

    Private Sub frmcash_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmcash_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Val(TextBox1.Text) < Val(frmcashregistry.lbltotal.Text) Then MsgBox("Cash is less that total", MsgBoxStyle.Exclamation, "Error") : Exit Sub
            Me.Hide()
            'Call frmcashregistry.compute_change()
            frmcashregistry.lblchange.Text = Val(Me.TextBox1.Text) - Val(frmcashregistry.lbltotal.Text)

            frmcashregistry.lblchange.Text = Format(Val(frmcashregistry.lblchange.Text), "# ##0.00")
            frmcashregistry.lblchange.Text = Trim(frmcashregistry.lblchange.Text)
            frmcashregistry.lblcash.Text = Format(Val(Me.TextBox1.Text), "# ##0.00")
            frmcashregistry.lblcash.Text = Trim(frmcashregistry.lblcash.Text)
            Me.Close()
        End If
    End Sub

    Private Sub frmcash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class