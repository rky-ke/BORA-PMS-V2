Public Class frmaddstock

    Private Sub frmaddstock_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub

    Private Sub frmaddstock_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            conn.Open()
            cmd.Connection = conn
            cmd.CommandText = "UPDATE tblproduct SET p_stocks = '" & frmlist.currentstock + Val(TextBox1.Text) & "' WHERE id = '" & frmlist.addstockid & "'"
            cmd.ExecuteNonQuery()
            conn.Close()
            Call frmlist.med_list()
            MsgBox("medicine stocks updated", MsgBoxStyle.Information, "Update")
        End If
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub


    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Char.IsLetter(e.KeyChar) Or Char.IsSymbol(e.KeyChar) Or Char.IsPunctuation(e.KeyChar) Or Char.IsWhiteSpace(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.SelectionStart = Len(TextBox1.Text)
    End Sub

    Private Sub frmaddstock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class